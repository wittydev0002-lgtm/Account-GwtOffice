Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmChangeCurrency

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(cboCurrency.Text) Then
            MessageBox.Show("Please select the currency to use for change",
                              "Missing Currency", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        changeCurrency = cboCurrency.Text
        boolAbort = False
        Me.Close()
    End Sub

End Class