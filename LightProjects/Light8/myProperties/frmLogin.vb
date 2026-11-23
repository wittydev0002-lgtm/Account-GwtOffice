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

        Dim strEncryptedPassword As String = gwt_comm.UnEncryption(Me.txtPassword.Text.Trim())

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

            'Update the database 

            Dim strSql As String = Nothing

            If gwt_comm.CheckTableExistence("CustomerInvoiceDeliveries") = False Then
                strSql = "CREATE TABLE CustomerInvoiceDeliveries ([InvoiceNumber][INT] NOT NULL REFERENCES " _
                    & "CustomerSalesMain (InvoiceNumber), [ItemCode][NVARCHAR](150) NOT NULL, [QuantitySold][FLOAT] NOT NULL DEFAULT 0, " _
                    & "[QuantityDelivered][FLOAT] NOT NULL DEFAULT 0, [TransactionDate][SmallDateTime] NOT NULL DEFAULT GetDate(), " _
                    & "[DeliveryNoteNumber][INT] NOT NULL PRIMARY KEY, [UserName][NVARCHAR](50) NOT NULL, [TransactionId][INT] NOT NULL IDENTITY (1,1))"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                sqlCommand.ExecuteNonQuery()
            End If

            'InventoryShortCodeDescriptions (ShortCode, Description)
            If gwt_comm.CheckTableExistence("InventoryShortCodeDescriptions") = False Then
                strSql = "CREATE TABLE InventoryShortCodeDescriptions ([ShortCode][NVARCHAR](12) NOT NULL DEFAULT '', " _
                    & "[Description][NVARCHAR](450) NOT NULL DEFAULT '')"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                sqlCommand.ExecuteNonQuery()
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

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Login Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress
        If Asc(e.KeyChar) = 13 Then txtPassword.Focus()
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then btnLogin.Focus()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        On Error GoTo RaiseErr
        gwt_comm = New CommonLibrary.Commons.CommonFunctions
        With gwt_comm
            CommonLibrary.Commons.boolAbort = False
            .ShowCompanyList()
            If boolAbort = True Then End
            If CommonLibrary.Commons.boolConnectionStatus = False Then
                End
            End If
            'Write to the active connection file
            'strConnection
            Dim objFile As New System.IO.StreamWriter(Application.StartupPath & "\Data\ActiveConnection.txt", False)
            objFile.WriteLine(strConnection)
            objFile.Close()
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Login Error"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
