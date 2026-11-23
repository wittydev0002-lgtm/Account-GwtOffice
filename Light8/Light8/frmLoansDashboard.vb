Public Class frmLoansDashboard
    Private Sub btnIssueLoan_Click(sender As Object, e As EventArgs) Handles btnIssueLoan.Click
        Dim frm As New frmIssueLoan
        frm.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class