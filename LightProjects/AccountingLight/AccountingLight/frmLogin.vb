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

            'PaymentType, PaymentDueIn
            If gwt_comm.CheckColumnExistence("Customers", "PaymentType") = False Then
                strSql = "ALTER TABLE Customers ADD [PaymentType][NVARCHAR](35) NOT NULL DEFAULT 'Account'"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                sqlCommand.ExecuteNonQuery()
            End If

            If gwt_comm.CheckColumnExistence("Customers", "PaymentDueIn") = False Then
                strSql = "ALTER TABLE Customers ADD [PaymentDueIn][INT] NOT NULL DEFAULT 0"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                sqlCommand.ExecuteNonQuery()
            End If

            If gwt_comm.CheckTableExistence("SystemAgingParameters") = False Then
                strSql = "IF OBJECT_ID(N'SystemAgingParameters', N'U') IS NULL CREATE TABLE SystemAgingParameters " _
                    & "([DueDays][INT] NOT NULL DEFAULT 0, [TransactionId][INT] NOT NULL PRIMARY KEY IDENTITY (1,1))"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                sqlCommand.ExecuteNonQuery()
            End If

            If gwt_comm.CheckTableExistence("CustomerInvoiceDeliveries") = False Then
                strSql = "CREATE TABLE CustomerInvoiceDeliveries ([InvoiceNumber][INT] NOT NULL REFERENCES " _
                    & "CustomerSalesMain (InvoiceNumber), [ItemCode][NVARCHAR](150) NOT NULL, " _
                    & "[QuantityDelivered][FLOAT] NOT NULL DEFAULT 0, [TransactionDate][SmallDateTime] NOT NULL DEFAULT GetDate(), " _
                    & "[DeliveryNoteNumber][INT] NOT NULL PRIMARY KEY, [UserName][NVARCHAR](50) NOT NULL, " _
                    & "[TransactionId][INT] NOT NULL IDENTITY (1,1), [Address1][NVARCHAR](150) NOT NULL DEFAULT '', " _
                    & "[Address2][NVARCHAR](150) NOT NULL DEFAULT '', [Address3][NVARCHAR](150) NOT NULL DEFAULT '', " _
                    & "[Address4][NVARCHAR](150) NOT NULL DEFAULT '')"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                sqlCommand.ExecuteNonQuery()
            End If
            'ServiceName FROM AirHandlingServices

            If gwt_comm.CheckTableExistence("AirHandlingServices") = False Then
                strSql = "CREATE TABLE AirHandlingServices ([TransactionId][INT] NOT NULL PRIMARY KEY IDENTITY (1,1), " _
                    & "[ServiceName][NVARCHAR](450) NOT NULL DEFAULT '')"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                sqlCommand.ExecuteNonQuery()
            End If

            If gwt_comm.CheckTableExistence("AirCardsMain") = False Then
                strSql = "CREATE TABLE AirCardsMain ([Location][NVARCHAR](250) NOT NULL DEFAULT '', " _
                    & "[ICAO][NVARCHAR](35) NOT NULL DEFAULT '', [JobNumber][INT] NOT NULL PRIMARY KEY, " _
                    & "[OperatorName][NVARCHAR](250) NOT NULL DEFAULT '', [BillTo][NVARCHAR](250) NOT NULL DEFAULT '', " _
                    & "[ReferenceNumber][NVARCHAR](35) NOT NULL DEFAULT '', [AccountType][NVARCHAR](35) NOT NULL DEFAULT '', " _
                    & "[Registry][NVARCHAR](35) NOT NULL DEFAULT '', [CallSign][NVARCHAR](150) NOT NULL DEFAULT '', " _
                    & "[MTOW][FLOAT] NOT NULL DEFAULT 0, [ETATime][NVARCHAR](4) NOT NULL DEFAULT '2400', " _
                    & "[ETADate][SmallDateTime] NOT NULL DEFAULT GETDATE(), [ICAOfrom][NVARCHAR](150) NOT NULL DEFAULT '', " _
                    & "[ETDTime][NVARCHAR](4) NOT NULL DEFAULT '2400', [ETDDate][SmallDateTime] NOT NULL DEFAULT GETDATE(), " _
                    & "[ICAOto][NVARCHAR](150) NOT NULL DEFAULT '', [CrewIn][INT] NOT NULL DEFAULT 0, " _
                    & "[CrewOut][INT] NOT NULL DEFAULT 0, [PAXin][INT] NOT NULL DEFAULT 0, [PAXout][INT] NOT NULL DEFAULT 0, " _
                    & "[PayMethod][NVARCHAR](35) NOT NULL DEFAULT 'CASH', [CreditCardType][NVARCHAR](50) NOT NULL DEFAULT '', " _
                    & "[CardHolderName][NVARCHAR](350) NOT NULL DEFAULT '', [CardNumber][NVARCHAR](35) NOT NULL DEFAULT '', " _
                    & "[CardExpiryDate][NVARCHAR](5) NOT NULL DEFAULT '', [AgentName][NVARCHAR](350) NOT NULL DEFAULT '', " _
                    & "[CrewName][NVARCHAR](350) NOT NULL DEFAULT '')"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                sqlCommand.ExecuteNonQuery()
            End If

            If gwt_comm.CheckTableExistence("AirCardDetails") = False Then
                strSql = "CREATE TABLE AirCardDetails ([JobNumber][INT] NOT NULL REFERENCES AirCardsMain (JobNumber), " _
                    & "[ServiceKey][INT] NOT NULL References AirHandlingServices (TransactionId), " _
                    & "[TransactionId][INT] NOT NULL PRIMARY KEY IDENTITY (1,1))"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                sqlCommand.ExecuteNonQuery()
            End If

            If gwt_comm.CheckColumnExistence("AirCardsMain", "TransDate") = False Then
                strSql = "ALTER TABLE AirCardsMain ADD [TransDate][SmallDateTime] NOT NULL DEFAULT GetDate()"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                sqlCommand.ExecuteNonQuery()
            End If
            'AirCardsMain
            If gwt_comm.CheckColumnExistence("AirCardsMain", "InvoiceNumber") = False Then
                strSql = "ALTER TABLE AirCardsMain ADD [InvoiceNumber][INT] NOT NULL DEFAULT 0"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                sqlCommand.ExecuteNonQuery()
            End If
            Me.Close()
            If gwt_comm.CheckTableExistence("CustomerPermitSales") = False Then
                strSql = "CREATE TABLE [CustomerPermitSales]([TransactionId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY," _
                    & "[InvoiceNumber] [int] NOT NULL DEFAULT ((0)),[CustomerId] [nvarchar](50) NOT NULL,[ItemCode] [nvarchar](150) NOT NULL," _
                    & "[Description] [nvarchar](250) NOT NULL DEFAULT (''),[QuantityOld] [int] NOT NULL DEFAULT ((0))," _
                    & "[DiscountAllowed] [float] NOT NULL DEFAULT ((0)),[Taxes] [float] NOT NULL DEFAULT ((0))," _
                    & "[TransType] [nvarchar](20) NOT NULL DEFAULT (''),[SalesPrice] [float] NOT NULL DEFAULT ((0))," _
                    & "[TransDate] [smalldatetime] NOT NULL,[ProductType] [nvarchar](50) NOT NULL DEFAULT ('Service')," _
                    & "[SerialNumbers] [nvarchar](150) NULL,[OriginalInvoice] [int] NOT NULL DEFAULT ((0))," _
                    & "[SalesRep] [nvarchar](350) NOT NULL,[UserName] [nvarchar](50) NOT NULL DEFAULT ('')," _
                    & "[OrderNumber] [nvarchar](150) NOT NULL DEFAULT (''),[Quantity] [float] NOT NULL DEFAULT ((0))," _
                    & "[CostPrice] [float] NOT NULL DEFAULT ((0)),[EntryType] [nvarchar](35) NOT NULL," _
                    & "[CommissionRate] [nvarchar](35) NOT NULL DEFAULT (''),[ExpensesRate] [nvarchar](35) NOT NULL DEFAULT ('')," _
                    & "[ServiceCategory] [nvarchar](35) NOT NULL DEFAULT (''),[ContactName] [nvarchar](35) NOT NULL DEFAULT ('')," _
                    & "[ContactNumber] [nvarchar](35) NOT NULL,[SpecialKey] [int] NOT NULL DEFAULT ((0))," _
                    & "[BaseBarcode] [nvarchar](35) NOT NULL DEFAULT (''), [ProjectNumber] [int] NOT NULL DEFAULT 0, " _
                    & "[CostCode] [int] NOT NULL DEFAULT ((0))) "
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                sqlCommand.ExecuteNonQuery()
            End If

            If gwt_comm.CheckTableExistence("CustomerPermitSalesMain") = False Then
                strSql = "CREATE TABLE [CustomerPermitSalesMain]([InvoiceNumber] [int] NOT NULL PRIMARY KEY," _
                    & "[CustomerId] [nvarchar](50) NOT NULL  DEFAULT ('0000'),[Status] [nvarchar](20) NOT NULL DEFAULT ('')," _
                    & "[Amount] [float] NOT NULL DEFAULT ((0)),[Taxes] [float] NOT NULL DEFAULT ((0))," _
                    & "[Discount] [float] NOT NULL DEFAULT ((0)),[TransDate] [smalldatetime] NOT NULL," _
                    & "[OriginalInvoice] [int] NOT NULL DEFAULT ((0)),[SalesRep] [nvarchar](350) NOT NULL DEFAULT ('')," _
                    & "[UserName] [nvarchar](50) NOT NULL DEFAULT (''),[OrderNumber] [nvarchar](150) NOT NULL DEFAULT ('')," _
                    & "[Notes] [nvarchar](350) NOT NULL DEFAULT (''),[SpecialKey] [int] NOT NULL DEFAULT ((0))," _
                    & "[ProjectNumber] [int] NOT NULL DEFAULT ((0)))"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                sqlCommand.ExecuteNonQuery()
            End If

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
        ShowErrorMessage()
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
        ShowErrorMessage()
    End Sub

End Class
