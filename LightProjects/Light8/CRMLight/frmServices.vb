Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmServices

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub KryptonButton1_Click(sender As System.Object, e As System.EventArgs) Handles btnAccept.Click
        If Not String.IsNullOrEmpty(txtProduct.Text) Then
            dGrid.Rows.Add(txtProduct.Text)
            txtProduct.Clear() : txtProduct.Focus()
        Else
            MsgBox("Please enter a valid value for the product/service name", MsgBoxStyle.Exclamation, "Invald Product/Service Name")
            txtProduct.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAll.Click
        On Error GoTo RaiseErr
        Dim strProduct As String = Nothing
        For i As Integer = 0 To dGrid.Rows.Count - 1
            With dGrid
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then
                    strProduct = .Rows(i).Cells(0).Value.ToString
                    Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM CrmProducts WHERE " _
                        & "ProductName = '" & strProduct & "'", cnn)
                    objCommand.ExecuteNonQuery()
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO CrmProducts (ProductName) " _
                        & "VALUES ('" & strProduct & "')", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End With
        Next
        MsgBox("CRM Products Saved Succefully", MsgBoxStyle.Information, "CRM Products and Services Save Success")
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Description & vbCrLf & "On CRM products maintenance"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCategories()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ProductName FROM CrmProducts ORDER BY ProductName", cnn)
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
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Description & vbCrLf & "On CRM products maintenance"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmDrugCategories_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadCategories()
    End Sub

    Private Sub txtCategory_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtProduct.KeyPress
        If e.KeyChar = "'" Or e.KeyChar = "&" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then
            If Not String.IsNullOrEmpty(txtProduct.Text) Then
                dGrid.Rows.Add(txtProduct.Text)
                txtProduct.Clear() : txtProduct.Focus()
            Else
                MsgBox("Please enter a valid value for the product/service name", MsgBoxStyle.Exclamation, "Invald Product/Service Name")
                txtProduct.Focus()
                Exit Sub
            End If
        End If
    End Sub

End Class
