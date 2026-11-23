Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLegalActionName

    Private Sub frmLegalActionName_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtAction.Select()
    End Sub

    Private Sub frmLegalActionName_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 376
        Me.Height = 167
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtAction.Text) Then
            MessageBox.Show("Please enter an action name", "Missing Action Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAction.Focus()
            Exit Sub
        End If
        strAddedActionName = txtAction.Text
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub txtAction_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAction.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnOK.Focus()
        End If
    End Sub

End Class
