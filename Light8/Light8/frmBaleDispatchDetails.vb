Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBaleDispatchDetails

    Private Sub frmBaleDispatchDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmBaleDispatchDetails_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 541 : Me.Height = 227
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtDriverName.Text) Then
            MessageBox.Show("Please enter the driver details", "Invalid Driver Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub
End Class