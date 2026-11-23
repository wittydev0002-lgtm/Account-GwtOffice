Imports System.IO
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

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

    Private Sub ActivateCompanySelection()
        MessageBox.Show("No company is set as default. Please select the company to work with from the list", "No Default Company", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        txtPassword.Clear() : txtUsername.Clear()
        chkSelectOtherCompany.Checked = True
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As System.EventArgs) Handles btnLogin.Click
        On Error GoTo RaiseErr

        'CheckRegistrationKey()
        boolApplicationRunning = False

        'Connect to the database

        If chkSelectOtherCompany.Checked = False Then
            If System.IO.File.Exists(Application.StartupPath & "\Data\ActiveConnection.txt") Then
                Dim objFileReader As New System.IO.StreamReader(Application.StartupPath & "\Data\ActiveConnection.txt")
                Dim strLine As String = objFileReader.ReadLine
                objFileReader.Close()
                If Not String.IsNullOrEmpty(strLine) Then
                    lblSelectedConnection.Text = strLine
                Else
                    ActivateCompanySelection()
                    Exit Sub
                End If
            Else
                ActivateCompanySelection()
                Exit Sub
            End If
        End If

        Dim strConnectionFields As String = lblSelectedConnection.Text
        gwt_comm = New CommonLibrary.Commons.CommonFunctions

        Cursor = Cursors.WaitCursor

        With gwt_comm

            CommonLibrary.Commons.boolAbort = False
            CommonLibrary.Commons.strConnection = strConnectionFields
            '.OpenDatabaseConnection()

            OpenCurrentDatabaseConnection()

            If CommonLibrary.Commons.boolConnectionStatus = False Then
                Cursor = Cursors.Default
                MessageBox.Show("Application failed to connect to the database", "Database Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Cursor = Cursors.Default
                Exit Sub
            End If

            If CommonLibrary.Commons.boolAbort = True Then Exit Sub
            Dim strEncryptedPassword As String = .UnEncryption(Me.txtPassword.Text.Trim())

            If txtUsername.Text = "" Then
                Cursor = Cursors.Default
                MsgBox("Username is required. Please enter the username", MsgBoxStyle.Exclamation, "Invalid Username")
                txtUsername.Focus()
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Users " _
                & "WHERE UserName = '" & txtUsername.Text & "' AND UserPassword = '" & strEncryptedPassword & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                gwt_comm.AssignUserRight(txtUsername.Text, strEncryptedPassword, "FINANCIAL")
                objReader.Close()

                Dim strSql As String = Nothing
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
                                        Cursor = Cursors.Default
                                        End
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                'Write out the last used connection
                Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\Data\ActiveConnection.txt", False)
                objFileWriter.WriteLine(lblSelectedConnection.Text)
                objFileWriter.Close()

                'gwt_comm = New CommonLibrary.Commons.CommonFunctions
                'gwt_comm.OpenDatabaseConnection()

                Me.Close()

            Else
                objReader.Close()
                MsgBox("Either the username or the password is invalid", MsgBoxStyle.Critical, "Invalid Login Details")
                If intTrials > 2 Then
                    Cursor = Cursors.Default
                    End
                Else
                    intTrials = intTrials + 1
                    txtUsername.Focus()
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

        End With

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & " on Login Error"
        ShowErrorMessage()
    End Sub

    Private Sub txtUsername_GotFocus(sender As Object, e As System.EventArgs) Handles txtUsername.GotFocus
        txtUsername.SelectAll()
    End Sub

    Private Sub txtUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress
        If Asc(e.KeyChar) = 13 Then txtPassword.Focus()
    End Sub

    Private Sub txtPassword_GotFocus(sender As Object, e As System.EventArgs) Handles txtPassword.GotFocus
        txtPassword.SelectAll()
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then btnLogin.Focus()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        On Error GoTo RaiseErr

        If chkSelectOtherCompany.Checked = False Then
            txtUsername.Select()
        Else
            cboCompany.Select()
        End If

        Dim intX1 As Integer = cboCompany.Width
        Dim intX2 As Integer = 0
        With cboCompany
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intX1) & ";" & CStr(intX2)
        End With

        'Get a count of the items
        Dim intItemsCount As Integer = 0

        Dim arrCompanies As New ArrayList

        Cursor = Cursors.WaitCursor

        If File.Exists(Application.StartupPath & "\Data\PayCatalogue.txt") Then
            Dim objFileReader As New System.IO.StreamReader(Application.StartupPath & "\Data\PayCatalogue.txt")
            Dim strFileData As String = objFileReader.ReadToEnd
            objFileReader.Close()
            Dim strConnections() As String = Split(strFileData, vbCrLf)
            For p As Integer = 0 To strConnections.Length - 1
                If Not String.IsNullOrEmpty(strConnections(p)) Then
                    arrCompanies.Add(strConnections(p))
                End If
            Next

            intItemsCount = arrCompanies.Count

            Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

            cboCompany.Items.Clear()
           
            For p As Integer = 0 To arrCompanies.Count - 1
                If Not IsDBNull(arrCompanies.Item(p)) Then
                    Dim strRecordText() As String = Split(arrCompanies.Item(p), "|")
                    DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
                End If
            Next

            If intItemsCount > 0 Then
                cboCompany.SelectedIndex = -1
                cboCompany.Items.Clear()
                cboCompany.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                cboCompany.Items.AddRange(DropDownItems)
            End If

        Else
            MessageBox.Show("Application is missing the database configuration files." & vbCrLf & _
                "Please contact your software provider", "Missing Configuration Settings",
                MessageBoxButtons.OK, MessageBoxIcon.Stop)
            boolDbCreateMode = True
            Me.Close()
        End If

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Login Error"
        MessageBox.Show(strErrorMessages, "Application Startup Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub

    Private Sub cboCompany_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCompany.SelectedIndexChanged
        lblSelectedConnection.Text = Nothing
        lblSelectedConnection.Text = cboCompany.SelectedItem.Col2.ToString
        If Not String.IsNullOrEmpty(lblSelectedConnection.Text) Then
            txtPassword.Enabled = True
            txtUsername.Enabled = True
            btnLogin.Enabled = True
            txtUsername.Focus()
        Else
            txtPassword.Enabled = False
            txtUsername.Enabled = False
            btnLogin.Enabled = False
        End If
    End Sub

    Private Sub chkSelectOtherCompany_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSelectOtherCompany.CheckedChanged
        If chkSelectOtherCompany.Checked = True Then
            pnlCompanies.Visible = True
        Else
            pnlCompanies.Visible = False
        End If
        lblSelectedConnection.Text = Nothing
    End Sub

End Class
