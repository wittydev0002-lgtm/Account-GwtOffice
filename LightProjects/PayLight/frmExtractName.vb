Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmExtractName

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtExtractName.Text) Then
            MessageBox.Show("Please enter a valid name for the extract", "Invalid Extract Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtExtractName.Focus()
            Exit Sub
        End If
        boolAbort = False
        StrExtractName = txtExtractName.Text
        Me.Close()
    End Sub

End Class
