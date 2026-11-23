Imports CommonLibrary.Commons

Public Class frmPortfolioCostAmount

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a valid amount for the cost", "Invalid Cost Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
        dblNewCostPrice = CDbl(txtAmount.Text)
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub frmPortfolioCostAmount_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtAmount.Text = Format(dblNewCostPrice, "##0.00")
    End Sub

End Class