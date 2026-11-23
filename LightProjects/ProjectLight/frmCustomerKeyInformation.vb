Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCustomerKeyInformation

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the customer address", "Missing Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If
        sDocumentCustomerAddress1 = txtAddress1.Text
        sDocumentCustomerAddress2 = txtAddress2.Text
        sDocumentCustomerAddress3 = txtAddress3.Text
        sDocumentCustomerAddress4 = txtAddress4.Text
        sDocumentCustomerTelephone = txtTelephone.Text
        sDocumentCustomerVatNumber = txtVatNumber.Text
        sDocumentCustomerEmailAddress = txtEmailAddress.Text
        boolAbort = False
        Me.Close()
    End Sub


    Private Sub frmCustomerKeyInformation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtAddress1.Text = sDocumentCustomerAddress1
        txtAddress2.Text = sDocumentCustomerAddress2
        txtAddress3.Text = sDocumentCustomerAddress3
        txtAddress4.Text = sDocumentCustomerAddress4
        txtEmailAddress.Text = sDocumentCustomerEmailAddress
        txtTelephone.Text = sDocumentCustomerTelephone
        txtVatNumber.Text = sDocumentCustomerVatNumber
    End Sub

End Class
