Public Class frmLogin

    Const TextTimerInterval As Integer = 15 ' In milliseconds
    Protected currentGradientShift As Integer = 10
    Protected gradiantStep As Integer = 5
    Dim intTrials As Integer = 0

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub

    Dim iTry As Integer
    Dim strEncPwd As String

    Private Sub txtPassword_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPassword.Enter
        txtPassword.SelectionLength = Len(txtPassword.Text)
    End Sub

    Private Sub txtUserName_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUsername.Enter
        txtUserName.SelectionLength = Len(txtUserName.Text)
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        On Error GoTo RaiseErr

        'CheckRegistrationKey()
        boolApplicationRunning = False

        Dim strEncryptedPassword As String = UnEncryption(Me.txtPassword.Text.Trim())
        Dim strLastChangeDate As String = Nothing

        If txtUsername.Text = "" Then
            MsgBox("Username is required. Please enter the username", MsgBoxStyle.Exclamation, "Invalid Username")
            txtUsername.Focus()
            Exit Sub
        End If

        'Login to the database first
        boolAbort = False
        OpenDatabaseConnection()
        If boolAbort = True Then Exit Sub

        'First get a count of the records in the system users table.
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Users " _
            & "WHERE UserName = '" & txtUsername.Text & "' AND UserPassword = '" & strEncryptedPassword & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader("UserName").ToString) Then strUserName = objReader("UserName").ToString
        End While
        objReader.Close()

        If Not String.IsNullOrEmpty(strUserName) Then
            boolUserConnectionSuccess = True
            boolApplicationStarting = False

            AssignCompanyDetails()
            GetTaxTables()
            If boolAbort = True Then End
            boolApplicationRunning = True

            Me.Close()
        Else
            objReader.Close()
            MsgBox("Either the username or the password is invalid", MsgBoxStyle.Critical, "Invalid Login Details")
            If intTrials > 2 Then
                End
            Else
                intTrials = intTrials + 1
                txtUsername.Focus()
                Exit Sub
            End If
        End If
        Exit Sub
RaiseErr:
        If boolCancelValidation = True Then Exit Sub
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Login Error"
        ShowErrorMessage()
    End Sub

    Private Sub txtUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress
        If Asc(e.KeyChar) = 13 Then txtPassword.Focus()
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then btnLogin.Focus()
    End Sub

End Class