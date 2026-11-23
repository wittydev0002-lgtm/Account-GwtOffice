Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmTaxInvoiceCustomerDetails

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtAccountName.Text) Then
            MessageBox.Show("Please enter the customer name", "Missing Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the customer address", "Missing Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtVatNumber.Text) Then
            MessageBox.Show("Please enter the customer VAT number", "Missing VAT Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtVatNumber.Focus()
            Exit Sub
        End If
        sDocumentCustomerName = txtAccountName.Text
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

End Class
