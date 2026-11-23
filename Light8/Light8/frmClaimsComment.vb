Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons

Public Class frmClaimsComment

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtComment.Text) Then
            MessageBox.Show("Please type in something in the comment box", "Missing Comment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtComment.Focus()
            Exit Sub
        Else
            strCommonMessage = txtComment.Text
            boolAbort = False
            Me.Close()
        End If
    End Sub

    Private Sub frmClaimsComment_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 450 : Me.Height = 220
    End Sub

End Class
