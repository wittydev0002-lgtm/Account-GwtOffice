Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDbConfiguration

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtCompanyName.Text) Then
            MessageBox.Show("Please enter the company name", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCompanyName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDatabaseName.Text) Then
            MessageBox.Show("Please enter the database name", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDatabaseName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtServerName.Text) Then
            MessageBox.Show("Please enter the server name", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtServerName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboAuthentication.Text) Then
            MessageBox.Show("Please select the authentication type", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAuthentication.Focus()
            Exit Sub
        End If

        If UCase(cboAuthentication.Text) = UCase("SQL Server Authentication") Then
            If String.IsNullOrEmpty(txtLoginName.Text) Then
                MessageBox.Show("Please enter the login name", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtLoginName.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtPassword.Text) Then
                MessageBox.Show("Please enter the password", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtPassword.Focus()
                Exit Sub
            End If
        End If

        strDatabaseName = txtDatabaseName.Text
        strNewCompanyName = txtCompanyName.Text
        strLoginName = txtLoginName.Text
        strServerName = txtServerName.Text
        strPassword = txtPassword.Text
        strAuthentication = cboAuthentication.Text
        boolAbort = False
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmDbConfiguration_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 549 : Me.Height = 278
    End Sub

End Class
