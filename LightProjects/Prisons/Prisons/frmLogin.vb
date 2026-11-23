Imports System.IO
Imports CommonLibrary
Imports CommonLibrary.Commons

Public Class frmLogin

    Dim intTrials As Integer
    Dim strEncPwd As String

    Private Sub txtPassword_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPassword.Enter
        txtPassword.SelectionLength = Len(txtPassword.Text)
    End Sub

    Private Sub txtUserName_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUsername.Enter
        txtUsername.SelectionLength = Len(txtUsername.Text)
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As System.EventArgs) Handles btnLogin.Click
        On Error GoTo RaiseErr

        'CheckRegistrationKey()
        boolApplicationRunning = False

        If File.Exists(Application.StartupPath & "\Data\PayCatalogue.txt") Then
            Dim objFileReader As New StreamReader(Application.StartupPath & "\Data\PayCatalogue.txt")
            Dim strLine As String = objFileReader.ReadLine
            objFileReader.Close()

            'Connect to the database
            Dim strConnectionFields() As String = Split(strLine, "|")

            gwt_comm = New CommonLibrary.Commons.CommonFunctions

            With gwt_comm
                CommonLibrary.Commons.boolAbort = False
                CommonLibrary.Commons.strConnection = strConnectionFields(1)
                .OpenDatabaseConnection()
                If CommonLibrary.Commons.boolConnectionStatus = False Then
                    MessageBox.Show("Application failed to connect to the database", "Database Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                If CommonLibrary.Commons.boolAbort = True Then Exit Sub
                Dim strEncryptedPassword As String = .UnEncryption(Me.txtPassword.Text.Trim())

                If txtUsername.Text = "" Then
                    MsgBox("Username is required. Please enter the username", MsgBoxStyle.Exclamation, "Invalid Username")
                    txtUsername.Focus()
                    Exit Sub
                End If

                Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Users " _
                    & "WHERE UserName = '" & txtUsername.Text & "' AND UserPassword = '" & strEncryptedPassword & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    gwt_comm.AssignUserRight(txtUsername.Text, strEncryptedPassword)
                    objReader.Close()

                    'Create the prisoners table if it does not exist here
                    Dim strSql As String = "IF OBJECT_ID(N'Prisoners', N'U') IS NULL " _
                        & "CREATE TABLE Prisoners ([PrisonNumber][INT] NOT NULL PRIMARY KEY IDENTITY (1,1), " _
                        & "[LastName][NVARCHAR](150) NOT NULL DEFAULT '', [FirstName][NVARCHAR](150) NOT NULL DEFAULT '', " _
                        & "[OtherNames][NVARCHAR](150) NOT NULL DEFAULT '', [IDNumber][NVARCHAR](35) NOT NULL DEFAULT '', " _
                        & "[BirthDate][SmallDateTime] NOT NULL, [Gender][NVARCHAR](20) NOT NULL DEFAULT 'Male', " _
                        & "[MaritalStatus][NVARCHAR](20) NOT NULL DEFAULT 'Single', " _
                        & "[Address][NVARCHAR](MAX) NOT NULL DEFAULT '', [Telephone][NVARCHAR](35) NOT NULL DEFAULT '', " _
                        & "[EmailAddress][NVARCHAR](MAX) NOT NULL DEFAULT '', [DateIn][SmallDateTime] NOT NULL, " _
                        & "[DateOut][SmallDateTime] NOT NULL, [Offence][NVARCHAR](MAX) NOT NULL DEFAULT '', " _
                        & "[Sentence][INT] NOT NULL DEFAULT 0, [Remarks][NVARCHAR](MAX) NOT NULL DEFAULT '', " _
                        & "[Status][NVARCHAR](35) NOT NULL DEFAULT 'SERVING')"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()

                    If Not String.IsNullOrEmpty(strPasswordComplexity) Then
                        If strPasswordExpiry.ToUpper = "YES" Then
                            If Not String.IsNullOrEmpty(strLastChangeDate) Then
                                If IsDate(strLastChangeDate) Then
                                    Dim dtDueDate As Date = DateAdd(DateInterval.Day, intPasswordDuration, CDate(strLastChangeDate))
                                    Dim intDaysLeft As Integer = DateDiff(DateInterval.Day, Now, dtDueDate)
                                    If intDaysLeft > 0 And intDaysLeft <= 5 Then
                                        'raise warning to change password before expiry
                                        MessageBox.Show("Your password will expire in " & intDaysLeft & " days time. Please change it", "Password About To Expire", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Else
                                        If intDaysLeft <= 0 Then
                                            MessageBox.Show("Your password has expired. System deactivating the account.", "Password Deactivation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            Dim objDeactivate As New Data.OleDb.OleDbCommand("DELETE FROM Users WHERE UserName = '" & strUserName & "'", cnn)
                                            objDeactivate.ExecuteNonQuery()
                                            End
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

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

            End With

        Else
            MessageBox.Show("The system database has not been configured correctly." & vbCrLf & _
                "Please contact your software supplier for assistance", _
                "Database Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
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
