Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSupervisorAuthorizaton

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        boolAbort = False
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtUserName.Text) Then
            MessageBox.Show("Please enter a valid user name", "Invalid User Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUserName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtPassword.Text) Then
            MessageBox.Show("Please enter a valid password", "Invalid Password Characters", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPassword.Focus()
            Exit Sub
        End If
        Dim strEncryptedPassword As String = gwt_comm.UnEncryption(Me.txtPassword.Text.Trim())
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Users WHERE UserName = " _
            & "'" & txtUserName.Text & "' AND UserPassword = '" & strEncryptedPassword & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("UserLevel").ToString) Then
                If UCase(objReader("UserLevel").ToString) = UCase("Manager") Or _
                    UCase(objReader("UserLevel").ToString) = UCase("Administrator") Then
                    boolAuthorized = True
                    objReader.Close()
                    Me.Close()
                Else
                    boolAuthorized = False
                    MessageBox.Show("You do not have the authority to execute this process", "Unauthorised User Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    objReader.Close()
                    Me.Close()
                End If
            End If
        Else
            MessageBox.Show("Password or user name invalid", "Unauthorised Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUserName.Focus()
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Password Validation"
        ShowErrorMessage()
    End Sub

    Private Sub txtUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
        If Asc(e.KeyChar) = 13 Then txtPassword.Focus()
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
    End Sub

End Class