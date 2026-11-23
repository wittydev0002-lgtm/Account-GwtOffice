Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports System.Windows.Forms

Public Class frmImportBanksFileName

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not String.IsNullOrEmpty(txtFilename.Text) Then
            strSelectedFileName = txtFilename.Text
            boolAbort = False
            Me.Close()
        Else
            MessageBox.Show("Please enter the file name by browsing to the folder where located", "Missing File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFilename.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofd.ShowDialog()
        txtFilename.Text = ofd.FileName
    End Sub

End Class
