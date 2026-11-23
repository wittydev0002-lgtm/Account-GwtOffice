Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSalesQuantityUpdate

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If Not IsNumeric(txtQuantity.Text) Then
            MessageBox.Show("Please enter a valid value for quantity", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQuantity.Focus()
            Exit Sub
        Else
            dblPublicQuantityFilterMinimum = CDbl(txtQuantity.Text)
            boolAbort = False
            Me.Close()
        End If
    End Sub

End Class
