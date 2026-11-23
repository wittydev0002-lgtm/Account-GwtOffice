Imports CommonLibrary.Commons

Public Class frmExtractName

    Private Sub btnAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbort.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtExtractName.Text) Then
            MsgBox("Please enter a valid name for the extract", MsgBoxStyle.Exclamation, "Invalid Extract Name")
            txtExtractName.Focus()
            Exit Sub
        End If
        boolAbort = False
        StrExtractName = txtExtractName.Text
        Me.Close()
    End Sub

    Private Sub frmExtractName_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 440 : Me.Height = 160
    End Sub

End Class