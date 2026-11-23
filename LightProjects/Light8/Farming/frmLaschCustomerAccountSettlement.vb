Imports System.Drawing.Printing

Public Class frmLaschCustomerAccountSettlement

    Dim boolFormLoading As Boolean
    Dim dblCurrencyRate As Double = 1
    Dim strSelectedReport As String
    Dim prFont As New Font("Arial", 6, FontStyle.Regular)
    Dim tlFont As New Font("Arial", 6, FontStyle.Bold)
    Dim HeaderFont As New Font("Arial", 12, FontStyle.Bold)
    Dim strType As String
    Dim arrPrintDetails As ArrayList

    Dim strCustomerDetails As String
    Dim strInvoiceDetails As ArrayList
    Dim rsInvoiceTotals As String

    Dim dblInvoiceTotal As Double
    Dim dblTaxes As Double
    Dim dblDiscounts As Double
    Dim i As Double = 0
    Dim strvalue As String
    Dim strDate As Date
    Dim itm As Double
    Dim boolPrintFromPreview As Boolean
    Dim intPaymentReceiptNumber As Double
    Dim strCustomerAccountNumberPayments As String

    Dim strCustomerName As String
    Dim strCustomerAddress As String
    Dim strCustomerTelephone As String
    Dim strCustomerFaxNumber As String
    Dim strCustomerVatNumber As String
    Dim strCustomerEmailAddress As String

    Dim boolExitingWhile As Boolean = False
    Dim intPage As Single = 1
    Dim intPageTotals As Double = 1

    Dim strItemType As String = Nothing

    Private Sub cboName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboName.SelectedIndexChanged
        txtAccountHolderNumber.Text = cboName.SelectedItem.Col2
    End Sub

    Private Sub frmLaschCustomerAccountSettlement_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        LoadCashbooks()
        LoadData()
        LoadCurrencies()
        boolFormLoading = False
    End Sub

    Private Sub LoadCurrencies()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CurrencyName FROM Currencies ORDER BY CurrencyName", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboCurrency.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        cboCurrency.Text = UCase(strDefaultCurrency)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On currencies load"
        ShowErrorMessage()
    End Sub

    Private Sub cboAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccount.SelectedIndexChanged
        lblAccountDescription.Text = ""
        If Not cboAccount.SelectedItem Is Nothing Then
            lblAccountDescription.Text = cboAccount.SelectedItem.Col2
            strPublicActiveCashbook = cboAccount.SelectedItem.Col1
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT LastName +' '+FirstName +' '+ OtherNames +';'+ AccountNumber AS [Customer] " _
            & "FROM LaschCustomers ORDER BY LastName, FirstName, OtherNames"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Set up the drop down combo box
        Dim intWidth As Integer = cboName.Width - 50
        With cboName
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "250;80"
        End With

        'Get a count of the items
        Dim intItemsCount As Double = 0

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(AccountNumber) FROM LaschCustomers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()

        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboName.Items.Clear()
        Dim p As Double = 0

        'Continue to read until you reach the end of the file.
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            End If
            p = p + 1
        End While
        objReader.Close()

        If intItemsCount > 0 Then
            cboName.SelectedIndex = -1
            cboName.Items.Clear()
            cboName.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboName.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " On customers details load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadCashbooks()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountNumber +';'+AccountName AS " _
            & "[Accounts] FROM Cashbooks ORDER BY AccountNumber"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboAccount
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;180"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM Cashbooks", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboAccount.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()
        If intItemsCount > 0 Then
            cboAccount.SelectedIndex = -1
            cboAccount.Items.Clear()
            cboAccount.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboAccount.Items.AddRange(DropDownItems)
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Cashbooks Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtAmountExchange.Text) Then
            MessageBox.Show("Please enter a valid amount for payment", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        Else
            dblAccountSettlementAmount = CDbl(txtAmountExchange.Text)
            boolAbort = False
            'Me.Close()
        End If
        If String.IsNullOrEmpty(cboName.Text) Or String.IsNullOrEmpty(txtAccountHolderNumber.Text) Then
            MessageBox.Show("Please enter the account holder details", "Invalid Account Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboAccount.Text) Then
            MessageBox.Show("Please enter a valid amount for payment", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccount.Focus()
            Exit Sub
        End If
        boolAbort = False
        txtReference.Text = CStr(GetNextDocumentNumber("CashSales"))
        CurrentActiveReceiptNumber = CInt(txtReference.Text) : StartDate = dpTransDate.Value : CurrentAmountReceived = CDbl(txtAmountExchange.Text)
        FinishSale()
    End Sub

    Private Sub txtAmount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmount.Validating
        If String.IsNullOrEmpty(txtAmount.Text) Then Exit Sub
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        Else
            'Compute the values
            txtAmountExchange.Text = Format((CDbl(txtAmount.Text) / dblCurrencyRate), "##0.00")
            dblAmountTendered = CDbl(txtAmountExchange.Text)
            If strRoundOnExchange = "YES" Then dblAmountTendered = Math.Round(dblAmountTendered, 0)
            If strRoundOnExchange = "YES" Then RoundValues()
        End If
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub cboCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurrency.SelectedIndexChanged
        On Error GoTo RaiseErr
        If boolFormLoading = True Then Exit Sub

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CurrencyRate FROM Currencies WHERE CurrencyName = '" & cboCurrency.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblCurrencyRate = CDbl(objReader(0).ToString)
            If IsNumeric(txtAmount.Text) Then
                If CDbl(txtAmount.Text) <> 0 Then
                    txtAmountExchange.Text = Format(((CDbl(txtAmount.Text) / dblCurrencyRate)), "##0.00")
                End If
            End If
        End If
        objReader.Close()
        If strRoundOnExchange = "YES" Then RoundValues()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On exchange computation"
        ShowErrorMessage()
    End Sub

    Private Sub RoundValues()
        If IsNumeric(txtAmount.Text) Then
            txtAmount.Text = Format((Math.Round(CDbl(txtAmount.Text), 0)), "##0.00")
        End If

        If IsNumeric(txtAmountExchange.Text) Then
            txtAmountExchange.Text = Format((Math.Round(CDbl(txtAmountExchange.Text), 0)), "##0.00")
        End If
    End Sub

    Private Sub chkOverideDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverideDate.CheckedChanged
        If chkOverideDate.Checked = True Then
            If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
                dpTransDate.Enabled = True
            Else
                boolAbort = False
                boolAuthorized = False
                Dim f As New frmSupervisorAuthorizaton
                f.ShowDialog()
                If boolAbort = True Then
                    chkOverideDate.Checked = False
                    Exit Sub
                End If
                If boolAuthorized = True Then
                    dpTransDate.Enabled = True
                    boolAuthorized = False
                End If
            End If
        Else
            dpTransDate.Enabled = False
            boolAuthorized = False
        End If
    End Sub

    Private Sub FinishSale()
        Dim strSqlTransmit As String = Nothing
        Dim strSelectedId As String
        Dim strDescription As String
        Dim intQty As Double
        Dim dblUprice As Double
        Dim insertCustomer As String
        Dim dblTax As Double
        Dim i As Double
        Dim dpProcessDate As Date = Format(DateTime.Now, "dd-MMM-yyyy")
        Dim dblDisAmount As Double 'for discounts
        Dim dblSumTaxes As Double = 0, dblSumDiscounts As Double = 0, dblSumPayable As Double = 0
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim dbReader As Data.OleDb.OleDbDataReader

        dblAmountTendered = 0
        dblAmountChange = 0

        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        txtReference.Text = CStr(GetNextDocumentNumber("CashSales"))

        If chkOverideDate.Checked = True Then
            dpProcessDate = Format(dpTransDate.Value, "dd-MMM-yyyy")
        End If

        dblSumPayable = dblAccountSettlementAmount
        'Update the cashbook with the values
        Dim strCashbookDescription As String = "CASH SALE - ACCOUNT PAYMENT " & UCase(strUserName)
        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, TransactionType, Reference) VALUES " _
                & "('" & strPublicActiveCashbook & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " & dblSumPayable & ", '" & strCashbookDescription & "-" & txtAccountHolderNumber.Text & "', '" & strPublicSalesAccount & "', '" & strUserName & "', '" & strUserBranch & "', 'DEBIT', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
        myCommand.ExecuteNonQuery()

        If UCase(strWebConnectionType) = "REALTIME" Then
            strSqlTransmit = myCommand.CommandText
            strSqlTransmit = Replace(strSqlTransmit, "INTO CashbookTransactions (", "INTO GroupCashbookTransactions (BranchName, ", 1)
            strSqlTransmit = Replace(strSqlTransmit, "VALUES (", "VALUES ('" & strUserBranch & "', ", 1)
            'TransmitSale(strSqlTransmit)
        End If

        'Post the account to the contra debtors ledger account
        If String.IsNullOrEmpty(strPublicDebtorsAccount) Then
            MessageBox.Show("The debtors control account has not been defined. This will serious affect the trial balance.", _
                "Debtors Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference]) VALUES " _
                & "('" & strPublicDebtorsAccount & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " & dblSumPayable & ", 'CREDIT', '" & cboAccount.Text & "', '" & txtAccountHolderNumber.Text & "', '" & strUserName & "', '" & strUserBranch & "', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
            myCommand.ExecuteNonQuery()
        End If

        If UCase(strWebConnectionType) = "REALTIME" Then
            strSqlTransmit = myCommand.CommandText
            strSqlTransmit = Replace(strSqlTransmit, "INTO LedgerTransactions (", "INTO GroupLedgerTransactions (BranchName, ", 1)
            strSqlTransmit = Replace(strSqlTransmit, "VALUES (", "VALUES ('" & strUserBranch & "', ", 1)
            'TransmitSale(strSqlTransmit)
        End If

        'Update the customer account
        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LaschCustomerTransactions ([AccountNumber],[TransDate]," _
                & "[Credit],[Description],[DocumentNumber],[UserName],[ChangeDate]) " _
                & "VALUES('" & txtAccountHolderNumber.Text & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " _
                & "" & dblSumPayable & ", 'LOAN REPAYMENT', '" & txtReference.Text & "', " _
                & "'" & strUserName & "', '" & Now & "')", cnn)
        myCommand.ExecuteNonQuery()

        'Update the control numbers table
        myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET CashSales = " & CDbl(txtReference.Text) & "", cnn)
        myCommand.ExecuteNonQuery()

        strPublicCustomerId = txtAccountHolderNumber.Text
        PrintInvoice(dpProcessDate)
        MessageBox.Show("Sales document generated successfully.", "Transaction Document Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
        dblAmountChange = 0
        txtAccountHolderNumber.Clear()
        txtAmount.Text = "0.00"
        cboName.Text = ""
        cboAccount.Text = ""
        dpTransDate.Focus()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Account Settlement Processing"
        ShowErrorMessage()
    End Sub

    Private Sub PrintInvoice(ByVal dtReceiptDate As Date)
        On Error GoTo RaiseErr
        strType = "CASH SALE"
        strSelectedReport = Me.txtReference.Text

        arrPrintDetails = New ArrayList
        '
        'ADD THE BRANCH INFORMATION
        '
        arrPrintDetails.Add(Space(2) & UCase(strCompanyName))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchName))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress1))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress2))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress3))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress4))
        arrPrintDetails.Add(Space(2) & "PHONE: " & strPublicBranchTelephone)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        '
        'Print based on the grid values
        '
        If Not String.IsNullOrEmpty(strCustomerTelephoneNumber) Then
            arrPrintDetails.Add(Space(2) & "YOUR NO.: " & strCustomerTelephoneNumber)
            arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
            arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        End If
        Dim dblVatTax As Double = 0


        Dim strSerial As String = txtAccountHolderNumber.Text
        If strSerial.Length > 30 Then
            strSerial = Mid(strSerial, 1, 30) & vbCrLf & Mid(strSerial, 31, strSerial.Length)
        End If


        Dim strDescription As String = strSerial & " ACCOUNT SETTLEMENT"
        Dim strQuantity As String = "1"
        Dim strUnitPrice As String = "  "
        Dim strLineTotal As String = Format(dblAccountSettlementAmount, "##0.00")
        If strDescription.Length > 30 Then strDescription = Mid(strDescription, 1, 32)

        'Add the balance after payment line
        arrPrintDetails.Add(Space(2) & strDescription)


        'Add the dash line
        Dim strTaxCharged As String = Format(dblVatTax, "##0.00")

        Dim strTender As String = Format(dblAmountTendered, "##0.00")
        Dim strChange As String = Format(dblAmountChange, "##0.00")

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        If chkOrdinaryPrinter.Checked = True Then
            arrPrintDetails.Add(Space(2) & "|AMT + VAT|" & Format(dblAccountSettlementAmount, "##0.00"))
        Else
            arrPrintDetails.Add(Space(2) & "TOTAL INCL. VAT " & Space(14 - Format(dblAccountSettlementAmount, "##0.00").Length) & Format(dblAccountSettlementAmount, "##0.00"))
        End If

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))

        If chkOrdinaryPrinter.Checked = True Then
            arrPrintDetails.Add(Space(2) & "|VAT AMT|" & strTaxCharged)
        Else
            arrPrintDetails.Add(Space(2) & "VAT CHARGED     " & Space(14 - strTaxCharged.Length) & strTaxCharged)
        End If

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))

        If chkOrdinaryPrinter.Checked = True Then
            arrPrintDetails.Add(Space(2) & "|TENDERED|" & strTender)
        Else
            arrPrintDetails.Add(Space(2) & "AMOUNT TENDERED " & Space(14 - strTender.Length) & strTender)
        End If

        If chkOrdinaryPrinter.Checked = True Then
            arrPrintDetails.Add(Space(2) & "|CHANGE|" & strChange)
        Else
            arrPrintDetails.Add(Space(2) & "CHANGE          " & Space(14 - strChange.Length) & strChange)
        End If

        Dim strZimDate As String = Format(Now, "dd-MMM-yyyy")

        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(2) & "TILL OPER :" & UCase(strUserName) & Space(3))
        arrPrintDetails.Add(Space(2) & "SALES REP :")
        If strUserName.Length > 30 Then
            arrPrintDetails.Add(Space(2) & UCase(Mid(strUserName, 1, 30)))
        Else
            arrPrintDetails.Add(Space(2) & UCase(strUserName))
        End If

        arrPrintDetails.Add(Space(1) & "DATE AND TIME " & strZimDate & " " & DatePart(DateInterval.Hour, Now) & ":" & DatePart(DateInterval.Minute, Now))
        arrPrintDetails.Add(Space(2) & "RECEIPT DATE  " & Format(dtReceiptDate, "dd-MMM-yyyy"))
        arrPrintDetails.Add(Space(2) & " DOC NO " & txtReference.Text)
        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(1) & "CURRENCY : " & UCase(strSalesCurrency))
        arrPrintDetails.Add(Space(1) & "RATE USED: " & dblSaleExchangeRate)

        For i As Double = 0 To 14
            arrPrintDetails.Add(Space(32))
        Next

        'WRITE EVERY THING TO THE AUDIT FILE
        Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\TILLSLIP", True)
        For x As Double = 0 To arrPrintDetails.Count - 1
            objFileWriter.WriteLine(arrPrintDetails.Item(x))
        Next
        objFileWriter.Close()
        '
        'PRINTS FROM A FILE DIRECTLY TO THE PRINTER
        '
        'Try printing using the line printer
        ' Allow the user to select a file.
        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()

        If chkOrdinaryPrinter.Checked = True Then
            'Print to an ordinary print
            PrintPreviewDialog1.Document = pdWindows
            pdWindows.Print()
        Else
            'If (pd.ShowDialog() = DialogResult.OK) Then
            If MessageBox.Show("Do you want to print the receipt right now?", "Confirm Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If strRequestForReceiptPrinter = "YES" Then
                    Dim f As New frmPrinterSetup
                    f.ShowDialog()
                    pd.PrinterSettings.PrinterName = strSessionPrinter
                End If
                pb1.Value = 0 : pb1.Maximum = arrPrintDetails.Count
                For n = 0 To arrPrintDetails.Count - 1
                    Dim strPrintLineDetails As String = arrPrintDetails.Item(n) & vbCrLf
                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintLineDetails)
                    'RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s)
                    pb1.Value = pb1.Value + 1
                Next
            End If
        End If
        '-*- End If -*-
        'MessageBox.Show("Payslip preparation successful", MsgBoxStyle.Information, "Payslip Preparation Success")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Processing"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class
