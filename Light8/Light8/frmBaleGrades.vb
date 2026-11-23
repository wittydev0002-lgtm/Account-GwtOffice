Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmBaleGrades

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmBaleGrades_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadFormData()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        
        On Error GoTo RaiseErr
        
        Dim objCommand As Data.OleDb.OleDbCommand

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM BaleGrades", cnn)
        objCommand.ExecuteNonQuery()
        
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strGrade As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strGrade = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                Dim strSql As String = "INSERT INTO BaleGrades (Grade) VALUES ('" & strGrade & "')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next

        MessageBox.Show("Bale grade have been saved successfully", "Bale Grades Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Bale Grades Setup"
        ShowErrorMessage()
    End Sub

    Private Sub LoadFormData()
        On Error GoTo RaiseErr
        Dim objCmmand As New Data.OleDb.OleDbCommand("SELECT Grade FROM BaleGrades ORDER BY Grade", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmmand.ExecuteReader
        Dim i As Integer = 0
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Bale Grades Setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        AddGrade()
    End Sub

    Private Sub AddGrade()
        If String.IsNullOrEmpty(txtGrade.Text) Then
            MessageBox.Show("Please enter a valid value for grade", "Invalid Grade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGrade.Select()
            Exit Sub
        End If
        dGrid.Rows.Add(txtGrade.Text)
        txtGrade.Clear()
    End Sub

    Private Sub txtGrade_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrade.KeyPress
        If Asc(e.KeyChar) = 13 Then
            AddGrade()
        End If
    End Sub

    Private Sub frmBaleGrades_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 332 : Me.Height = 484
    End Sub

End Class