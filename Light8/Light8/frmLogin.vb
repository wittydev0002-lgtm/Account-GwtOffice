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

        'Connections saved from the Database Connection screen are stored protected
        Dim strConnectionFields As String = GtiResolveConnection(lblSelectedConnection.Text)
        gwt_comm = New CommonLibrary.Commons.CommonFunctions

        Cursor = Cursors.WaitCursor

        With gwt_comm

            CommonLibrary.Commons.boolAbort = False
            CommonLibrary.Commons.strConnection = strConnectionFields
            .OpenDatabaseConnection()

            'If cnn.DataSource.ToString <> "209.145.57.133" Then
            '    If UCase(cnn.DataSource.ToString) <> ".\" Then
            '        MessageBox.Show("This versions is configured for cloud usage only. Please contact your software supplier for help",
            '                        "Incompactable Version of Financial Light", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            '        End
            '    End If
            'End If

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

                'If gwt_comm.CheckColumnExistence("Company", "DefaultDateFormat") = False Then
                '    Dim objUpate As New Data.OleDb.OleDbCommand("ALTER TABLE Company ADD [DefaultDateFormat][NVARCHAR](250) NOT NULL DEFAULT 'American'", cnn)
                '    objUpate.ExecuteNonQuery()
                'End If

                gwt_comm.AssignUserRight(txtUsername.Text, strEncryptedPassword)
                objReader.Close()

                Dim strSql As String = Nothing

                If gwt_comm.CheckColumnExistence("SalesMain", "Cash") = False Then
                    strSql = "ALTER TABLE SalesMain ADD [Cash][FLOAT] NOT NULL DEFAULT 0"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                    strSql = "UPDATE SalesMain SET Cash = ((Amount + Taxes) - 0) WHERE PaymentMethod = 'Cash'"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                End If

                If gwt_comm.CheckColumnExistence("SalesMain", "EcoCash") = False Then
                    strSql = "ALTER TABLE SalesMain ADD [EcoCash][FLOAT] NOT NULL DEFAULT 0"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                    strSql = "UPDATE SalesMain SET EcoCash = ((Amount + Taxes) - 0) WHERE PaymentMethod = 'EcoCash'"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                End If

                If gwt_comm.CheckColumnExistence("SalesMain", "Swipe") = False Then
                    strSql = "ALTER TABLE SalesMain ADD [Swipe][FLOAT] NOT NULL DEFAULT 0"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                    strSql = "UPDATE SalesMain SET Swipe = ((Amount + Taxes) - 0) WHERE PaymentMethod = 'Swipe'"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                End If

                If gwt_comm.CheckColumnExistence("SalesMain", "Transfer") = False Then
                    strSql = "ALTER TABLE SalesMain ADD [Transfer][FLOAT] NOT NULL DEFAULT 0"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                    strSql = "UPDATE SalesMain SET Transfer = ((Amount + Taxes) - 0) WHERE PaymentMethod = 'Transfer'"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                End If

                If gwt_comm.CheckColumnExistence("SalesMain", "Other") = False Then
                    strSql = "ALTER TABLE SalesMain ADD [Other][FLOAT] NOT NULL DEFAULT 0"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                    strSql = "UPDATE SalesMain SET Other = ((Amount + Taxes) - 0) WHERE PaymentMethod = 'Other'"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                End If

                If gwt_comm.CheckTableExistence("BaleGrades") = True Then
                    If gwt_comm.CheckColumnExistence("BaleItems", "FileId") = False Then
                        strSql = "ALTER TABLE BaleItems ADD [FileId][NVARCHAR](35) NOT NULL DEFAULT ''"
                        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If

                If gwt_comm.CheckTableExistence("BaleGrades") = True Then
                    If gwt_comm.CheckTableExistence("BaleGrades") = False Then
                        strSql = "CREATE TABLE BaleGrades ([Grade][NVARCHAR](35) NOT NULL DEFAULT '')"
                        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If

                If gwt_comm.CheckTableExistence("FarmersData") = True Then
                    If gwt_comm.CheckColumnExistence("FarmersData", "CurrentRegStatusYear") = False Then
                        strSql = "ALTER TABLE FarmersData ADD [CurrentRegStatusYear][INT] NOT NULL DEFAULT 0"
                        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If

                If gwt_comm.CheckTableExistence("FarmersData") = True Then
                    If gwt_comm.CheckColumnExistence("FarmersData", "NextRegStatusYear") = False Then
                        strSql = "ALTER TABLE FarmersData ADD [NextRegStatusYear][INT] NOT NULL DEFAULT 0"
                        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If

                If gwt_comm.CheckTableExistence("FarmersData") = True Then
                    If gwt_comm.CheckColumnExistence("FarmersData", "Contractor") = False Then
                        strSql = "ALTER TABLE FarmersData ADD [Contractor][NVARCHAR](250) NOT NULL DEFAULT ''"
                        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If

                If gwt_comm.CheckTableExistence("FarmersData") = True Then
                    If gwt_comm.CheckColumnExistence("FarmersData", "Status") = False Then
                        strSql = "ALTER TABLE FarmersData ADD [Status][NVARCHAR](35) NOT NULL DEFAULT 'ACTIVE'"
                        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If

                If gwt_comm.CheckTableExistence("FarmersData") = True Then
                    If gwt_comm.CheckColumnExistence("FarmersData", "DecontractReason") = False Then
                        strSql = "ALTER TABLE FarmersData ADD [DecontractReason][NVARCHAR](MAX) NOT NULL DEFAULT ''"
                        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If

                If gwt_comm.CheckColumnExistence("InventoryItems", "RetailPrice") = False Then
                    strSql = "ALTER TABLE InventoryItems ADD [RetailPrice][FLOAT] NOT NULL DEFAULT 0"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                End If
                If gwt_comm.CheckColumnExistence("InventoryItems", "WholesalePrice") = False Then
                    strSql = "ALTER TABLE InventoryItems ADD [WholesalePrice][FLOAT] NOT NULL DEFAULT 0"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                End If
                If gwt_comm.CheckColumnExistence("InventoryItems", "SpecialPrice") = False Then
                    strSql = "ALTER TABLE InventoryItems ADD [SpecialPrice][FLOAT] NOT NULL DEFAULT 0"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                End If

                If gwt_comm.CheckColumnExistence("SystemKeyCurrencyRates", "UsdRate") = False Then
                    strSql = "ALTER TABLE SystemKeyCurrencyRates ADD [UsdRate][FLOAT] NOT NULL DEFAULT 1"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                End If

                If gwt_comm.CheckColumnExistence("CustomerSalesMain", "CurrencyUsed") = False Then
                    strSql = "ALTER TABLE [CustomerSalesMain] ADD [CurrencyUsed][NVARCHAR](35) NOT NULL DEFAULT ''"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                End If

                If gwt_comm.CheckColumnExistence("Company", "TillslipCopyPath") = False Then
                    strSql = "ALTER TABLE [Company] ADD [TillslipCopyPath][NVARCHAR](MAX) NOT NULL DEFAULT ''"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                End If

                If gwt_comm.CheckColumnExistence("Company", "PrintDocumentsTo") = False Then
                    strSql = "ALTER TABLE [Company] ADD [PrintDocumentsTo][NVARCHAR](35) NOT NULL DEFAULT 'DEFAULT'"
                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    sqlCommand.ExecuteNonQuery()
                End If

                ' Get the print to default 
                strSql = "SELECT [PrintDocumentsTo] FROM [Company] (NOLOCK)"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                Dim objReadPrn As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
                If objReadPrn.HasRows Then
                    objReadPrn.Read()
                    If Not IsDBNull(objReadPrn(0)) Then
                        If Not String.IsNullOrEmpty(Trim(objReadPrn(0).ToString)) Then
                            strPrintDocumentsTo = UCase(Trim(objReadPrn(0).ToString))
                        End If
                    End If
                End If
                objReadPrn.Close()

                ' Update inventory quantities based on type 
                '

                strSql = "SELECT [ItemCode] FROM 
                    [InventoryItems] (NOLOCK) 
                    WHERE [InventoryType] = 'SPECIFIC'"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                Dim objReadItems As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
                While objReadItems.Read
                    If Not IsDBNull(objReadItems(0)) Then
                        strSql = "SELECT COUNT(SerialNumber) 
                            FROM [SerialNumbers] (NOLOCK) 
                            WHERE [ItemCode] = '" & objReadItems(0).ToString & "'"
                        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objReader = sqlCommand.ExecuteReader
                        If objReader.HasRows Then
                            objReader.Read()
                            If Not IsDBNull(objReader(0)) Then
                                If IsNumeric(objReader(0).ToString) Then
                                    strSql = "UPDATE [InventoryItems] 
                                        SET [Quantity] = " & CDbl(objReader(0).ToString) & " 
                                        WHERE [ItemCode] = '" & objReadItems(0).ToString & "'"
                                    sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                    sqlCommand.ExecuteNonQuery()
                                End If
                            End If
                        End If
                    End If
                End While
                objReadItems.Close()

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

                ' Write out the last used connection
                '
                Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\Data\ActiveConnection.txt", False)
                objFileWriter.WriteLine(lblSelectedConnection.Text)
                objFileWriter.Close()

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
        gwt_comm.ShowErrorMessage()
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

    Private WithEvents lnkDatabaseConnection As LinkLabel

    'Link to enter the details of the database server (cloud or local)
    Private Sub AddDatabaseConnectionLink()
        If lnkDatabaseConnection IsNot Nothing Then Exit Sub
        lnkDatabaseConnection = New LinkLabel()
        lnkDatabaseConnection.Name = "lnkDatabaseConnection"
        lnkDatabaseConnection.Text = "Database connection..."
        lnkDatabaseConnection.AutoSize = True
        lnkDatabaseConnection.BackColor = Color.Transparent
        lnkDatabaseConnection.Location = New Point(95, 128)
        lnkDatabaseConnection.TabStop = False
        KryptonPanel1.Controls.Add(lnkDatabaseConnection)
        lnkDatabaseConnection.BringToFront()
    End Sub

    Private Sub lnkDatabaseConnection_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDatabaseConnection.LinkClicked
        Using f As New frmGtiDatabaseConnection
            f.ShowDialog(Me)
            If f.ConnectionSaved Then
                'Use the connection that was just saved
                chkSelectOtherCompany.Checked = False
                txtUsername.Enabled = True : txtPassword.Enabled = True : btnLogin.Enabled = True
                txtUsername.Focus()
            End If
        End Using
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        AddDatabaseConnectionLink()

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
            'New installation: no company database has been set up on this computer yet
            Directory.CreateDirectory(Application.StartupPath & "\Data")
            File.WriteAllText(Application.StartupPath & "\Data\PayCatalogue.txt", "")
            Cursor = Cursors.Default
            MessageBox.Show("No database has been set up on this computer yet." & vbCrLf &
                "Click 'Database connection...' and enter the details of the database server.", "Database Connection",
                MessageBoxButtons.OK, MessageBoxIcon.Information)
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
