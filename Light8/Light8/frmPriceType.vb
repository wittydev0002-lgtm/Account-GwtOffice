Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPriceType

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmPriceType_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboPriceType.Text = "Public"
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(cboPriceType.Text) Then
            MessageBox.Show("Please select the price type to use", "Missing Price Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPriceType.Select()
            Exit Sub
        End If
        strPriceType = cboPriceType.Text
        Me.Close()
    End Sub
End Class