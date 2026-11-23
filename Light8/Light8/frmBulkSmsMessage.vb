Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBulkSmsMessage

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If Not String.IsNullOrEmpty(txtMessage.Text) Then
            strBulkMessage = txtMessage.Text
            boolAbort = False
            Me.Close()
        Else
            MessageBox.Show("Please enter the SMS message", "SMS Message Missing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMessage.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub frmBulkSmsMessage_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 484 : Me.Height = 231
    End Sub

    Private Sub frmBulkSmsMessage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
