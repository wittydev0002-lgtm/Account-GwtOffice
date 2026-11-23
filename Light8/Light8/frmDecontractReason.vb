Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDecontractReason

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtReason.Text) Then
            MessageBox.Show("Please enter the de-contracting reason", "Missing Reason", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtReason.Select()
            Exit Sub
        Else
            strDecontractingReason = txtReason.Text
            boolAbort = False
            Me.Close()
        End If
    End Sub
End Class