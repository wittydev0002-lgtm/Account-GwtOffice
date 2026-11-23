Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports System.Windows.Forms

Public Class frmCostPriceAdjustmentOnSales

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a numeric value for amount", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
        boolAbort = False
        dblNewCostPrice = CDbl(txtAmount.Text)
        Me.Close()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If e.KeyChar = "." Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            btnOK.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

End Class
