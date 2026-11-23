Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmUnitsOfMeasure
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        If Not String.IsNullOrEmpty(txtCategory.Text) Then
            If Not String.IsNullOrEmpty(txtShortForm.Text) Then
                dGrid.Rows.Add(txtCategory.Text, txtShortForm.Text)
                txtCategory.Clear() : txtShortForm.Clear() : txtCategory.Focus()
            End If
        Else
            MessageBox.Show("Please enter a valid value for the measurements", "Invald Unit Of Measure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCategory.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        On Error GoTo RaiseErr
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strCategory As String = Nothing
            Dim strShortName As String = ""
            With dGrid
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then
                    strCategory = .Rows(i).Cells(0).Value.ToString
                    If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "")) Then
                        strShortName = .Rows(i).Cells(1).Value.ToString
                    End If
                    Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM OchmasUnitsOfMeasure WHERE " _
                        & "UnitOfMeasure = '" & strCategory & "'", cnn)
                    objCommand.ExecuteNonQuery()
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO OchmasUnitsOfMeasure (UnitOfMeasure, ShortName) " _
                        & "VALUES ('" & strCategory & "', '" & strShortName & "')", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End With
        Next
        MessageBox.Show("Units of Measure Saved Succefully", "Units of Measure Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Description & vbCrLf & "On units of measure maintenance"
        ShowErrorMessage()
    End Sub

    Private Sub LoadMeasures()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT UnitOfMeasure, ShortName FROM OchmasUnitsOfMeasure ORDER BY UnitOfMeasure", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            With dGrid
                If Not IsDBNull(objReader(0).ToString) Then .Rows.Add(objReader(0).ToString, objReader(1).ToString)
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Description & vbCrLf & "On units of measure maintenance"
        ShowErrorMessage()
    End Sub

    Private Sub frmUnitsOfMeasure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMeasures()
    End Sub

    Private Sub txtCategory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCategory.KeyPress
        If e.KeyChar = "'" Or e.KeyChar = "&" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtShortForm.Focus()
    End Sub

    Private Sub txtShortForm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShortForm.KeyPress
        If e.KeyChar = "'" Or e.KeyChar = "&" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then btnAccept.Focus()
    End Sub

    Private Sub frmUnitsOfMeasure_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 563 : Me.Height = 342
    End Sub

End Class
