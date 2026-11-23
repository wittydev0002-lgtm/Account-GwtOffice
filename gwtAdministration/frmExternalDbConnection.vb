Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmExternalDbConnection

    Private Sub frmExternalDbConnection_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmExternalDbConnection_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 621
        Me.Height = 228
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtDatabaseName.Text) Then
            MessageBox.Show("Process cannot be executed. Missing Database Name." & vbCrLf & "Please consult your service provider", "Insufficient Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDatabaseName.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtLoginName.Text) Then
            MessageBox.Show("Process cannot be executed. Missing Login Name." & vbCrLf & "Please consult your service provider", "Insufficient Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLoginName.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtServerName.Text) Then
            MessageBox.Show("Process cannot be executed. Missing Server Name." & vbCrLf & _
                "Please consult your service provider", "Insufficient Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtServerName.Select()
            Exit Sub
        End If

        eServerName = txtServerName.Text
        eDatabase = txtDatabaseName.Text
        ePassword = txtLoginPassword.Text
        eUserName = txtLoginName.Text

        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On external database settings"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

End Class