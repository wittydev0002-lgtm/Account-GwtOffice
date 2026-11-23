Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCustomerName
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolabort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(txtName.Text) Then
            MessageBox.Show("Please enter the customer name",
                "Missing the Required Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtName.Select()
            Exit Sub
        End If
        strTillslipCustomerName = txtName.Text
        strTillCustomerVat = txtVatNo.Text
        strCustomerTin = txtTin.Text
        Me.Close()
    End Sub

End Class