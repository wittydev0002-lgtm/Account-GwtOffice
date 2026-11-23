Imports CommonLibrary.Commons

Public Class frmLegalActionsCostsReversals
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If IsNumeric(txtAmount.Text) Then
            dblPublicCostReversalAmount = CDbl(txtAmount.Text)
            boolAbort = False
            Me.Close()
        Else
            MessageBox.Show("Please enter a valid value for cost to reverse", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
    End Sub
End Class