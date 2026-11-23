Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDrugCategories

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub KryptonButton1_Click(sender As System.Object, e As System.EventArgs) Handles btnAccept.Click
        If Not String.IsNullOrEmpty(txtCategory.Text) Then
            dGrid.Rows.Add(txtCategory.Text)
            txtCategory.Clear() : txtCategory.Focus()
        Else
            MsgBox("Please enter a valid value for the category", MsgBoxStyle.Exclamation, "Invald Category Name")
            txtCategory.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAll.Click
        On Error GoTo RaiseErr
        Dim strCategory As String = Nothing
        For i As Integer = 0 To dGrid.Rows.Count - 1
            With dGrid
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then
                    strCategory = .Rows(i).Cells(0).Value.ToString
                    Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM OchmasDrugCategories WHERE " _
                        & "CategoryName = '" & strCategory & "'", cnn)
                    objCommand.ExecuteNonQuery()
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO OchmasDrugCategories (CategoryName) " _
                        & "VALUES ('" & strCategory & "')", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End With
        Next
        MsgBox("Drug Categories Saved Succefully", MsgBoxStyle.Information, "Drug Categories Save Success")
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Description & vbCrLf & "On drug categories maintenance"
        ShowErrorMessage()
    End Sub

    Private Sub LoadCategories()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CategoryName FROM OchmasDrugCategories ORDER BY CategoryName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            With dGrid
                If Not IsDBNull(objReader(0).ToString) Then .Rows.Add(objReader(0).ToString)
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Description & vbCrLf & "On drug categories maintenance"
        ShowErrorMessage()
    End Sub

    Private Sub frmDrugCategories_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadCategories()
    End Sub

    Private Sub txtCategory_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCategory.KeyPress
        If e.KeyChar = "'" Or e.KeyChar = "&" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then btnAccept.Focus()
    End Sub

End Class
