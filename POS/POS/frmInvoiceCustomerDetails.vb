Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInvoiceCustomerDetails

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtAccountName.Text) Then
            MessageBox.Show("Please enter the customer name", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountName.Focus()
            Exit Sub
        End If
        strFlyQuoteName = txtAccountName.Text
        strFlyQuoteAddress1 = txtAddress1.Text
        strFlyQuoteAddress2 = txtAddress2.Text
        strFlyQuoteAddress3 = txtAddress3.Text
        strFlyQuoteAddress4 = txtAddress4.Text
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub frmInvoiceCustomerDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        strFlyQuoteName = Nothing
        strFlyQuoteAddress1 = Nothing
        strFlyQuoteAddress2 = Nothing
        strFlyQuoteAddress3 = Nothing
        strFlyQuoteAddress4 = Nothing
    End Sub

End Class
