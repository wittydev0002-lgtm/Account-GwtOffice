Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmEmployeeClassesSetup

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Not String.IsNullOrEmpty(txtClassName.Text) Then
            dGrid.Rows.Add(txtClassName.Text)
            txtClassName.Clear()
            txtClassName.Focus()
        Else
            MessageBox.Show("Please type in the employee class", "Missing Class Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtClassName.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub LoadEmployeeClasses()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT Description FROM " _
            & "SystemEmployeeClasses ORDER BY Description", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Classes Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmEmployeeClassesSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadEmployeeClasses()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemEmployeeClasses", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strDescription As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strDescription = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                'Check that the record does not exist in the table
                objCommand = New Data.OleDb.OleDbCommand("SELECT Description FROM SystemEmployeeClasses " _
                    & "WHERE Description = '" & strDescription & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows = False Then
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemEmployeeClasses " _
                        & "(Description) VALUES ('" & strDescription & "')", cnn)
                    objCommand.ExecuteNonQuery()
                End If
                objReader.Close()
            End If
        Next
        MessageBox.Show("Employee Classes Saved Successfully", "Employee Classes Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Classes Save Error"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
