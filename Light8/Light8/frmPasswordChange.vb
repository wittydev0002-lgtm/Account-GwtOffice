Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPasswordChange

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtNewPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNewPassword.KeyPress
        pbStrength.Value = gwt_comm.PasswordStrength(txtNewPassword.Text & e.KeyChar)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        'Check the organisation password policy
        If strPasswordComplexity.ToUpper = "YES" Then
            If pbStrength.Value <= 50 Then
                MessageBox.Show("The password does not meet the minimum complexity level. Please re-enter and include special characters", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        If txtConfirmPassword.Text <> txtNewPassword.Text Then
            MessageBox.Show("The confirmed password differs from the password", "Password Inconsistence", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNewPassword.Focus()
            txtNewPassword.SelectAll()
            Exit Sub
        End If
        If gwt_comm.UnEncryption(txtOldPassword.Text) = gwt_comm.UnEncryption(txtNewPassword.Text) Then
            MessageBox.Show("You cannot use the same password as the one you were using before", "Password Not Accepted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNewPassword.Focus()
            txtNewPassword.SelectAll()
            Exit Sub
        End If
        'Validate the user name and password
        Dim strOldPassword As String = gwt_comm.UnEncryption(txtOldPassword.Text)
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Users WHERE UserName = '" & txtLoginName.Text & "' AND UserPassword = '" & strOldPassword & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows = False Then
            MessageBox.Show("The old password does not exist in the system", "Non Existent User Profile", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        objReader.Close()
        'Update the password and then force re-login
        Dim strEncryptedPassword As String = gwt_comm.UnEncryption(txtNewPassword.Text)
        objCommand = New Data.OleDb.OleDbCommand("UPDATE Users SET UserPassword = '" & strEncryptedPassword & "', " _
            & "ChangeDate = '" & Now & "' WHERE UserName = '" & txtLoginName.Text & "'", cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Password has been changed successfully. System will shut down and you will have to re-login", "Password Change Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Password Update"
        ShowErrorMessage()
    End Sub

    Private Sub frmPasswordChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtLoginName.Text = strUserName
        txtLoginName.Enabled = False
    End Sub

    Private Sub frmPasswordChange_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 585 : Me.Height = 256
    End Sub

End Class