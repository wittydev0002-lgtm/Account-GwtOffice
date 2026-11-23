Option Explicit On

Imports System.IO
Imports System.Text
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports ComponentFactory.Krypton.Toolkit

Public Class frmSplash

    Dim intTrials As Integer
    Dim strEncPwd As String

    Private Sub txtPassword_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPassword.Enter
        txtPassword.SelectionLength = Len(txtPassword.Text)
    End Sub

    Private Sub txtUserName_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUserName.Enter
        txtUserName.SelectionLength = Len(txtUserName.Text)
    End Sub

    Private Sub btnProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        On Error GoTo RaiseErr

        'CheckRegistrationKey()
        boolApplicationRunning = False

        If File.Exists(Application.StartupPath & "\Data\PayCatalogue.txt") Then
            Dim objFileReader As New StreamReader(Application.StartupPath & "\Data\PayCatalogue.txt")
            Dim strLine As String = objFileReader.ReadLine
            objFileReader.Close()

            'Connect to the database
            Dim strConnectionFields() As String = Split(strLine, "|")

            boolAbort = False
            strConnection = strConnectionFields(1)
            OpenDatabase()
            If boolConnectionStatus = False Then Exit Sub
            UpdateDatabase()

            If boolAbort = True Then Exit Sub

            Dim strEncryptedPassword As String = UnEncryption(Me.txtPassword.Text.Trim())
            Dim strLastChangeDate As String = Nothing

            If txtUserName.Text = "" Then
                MsgBox("Username is required. Please enter the username", MsgBoxStyle.Exclamation, "Invalid Username")
                txtUserName.Focus()
                Exit Sub
            End If
            'First get a count of the records in the system users table.
            Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Users " _
                & "WHERE UserName = '" & txtUserName.Text & "' AND UserPassword = '" & strEncryptedPassword & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader("UserLevel").ToString) Then strUserLevel = objReader("UserLevel").ToString
                If Not IsDBNull(objReader("UserName").ToString) Then strUserName = objReader("UserName").ToString
                If Not IsDBNull(objReader("BranchName").ToString) Then strUserBranch = objReader("BranchName").ToString
                If Not IsDBNull(objReader("GivenNames").ToString) Then strPublicActiveFullUserName = objReader("GivenNames").ToString
                If Not IsDBNull(objReader("ChangeDate").ToString) Then strLastChangeDate = objReader("ChangeDate").ToString

                objReader.Close()

                'AssignCompanyDetails()
                AssignDefaults()
                AssignCompanyDetails()
                GetKeyDataFields()
                AssignSmsHttpSettings()
                getBackupPath()
                GetPrinterSettings()

                'txtUserName.Focus()
                Me.Close()
                'frmMainController.ShowDialog()
                'End
            Else
                objReader.Close()
                MsgBox("Either the username or the password is invalid", MsgBoxStyle.Critical, "Invalid Login Details")
                If intTrials > 2 Then
                    End
                Else
                    intTrials = intTrials + 1
                    txtUserName.Focus()
                    Exit Sub
                End If
            End If
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

    Private Sub txtUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
        If Asc(e.KeyChar) = 13 Then txtPassword.Focus()
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then btnProceed.Focus()
    End Sub

    Private Sub cmdQuit_Click(sender As System.Object, e As System.EventArgs) Handles cmdQuit.Click
        End
    End Sub

End Class