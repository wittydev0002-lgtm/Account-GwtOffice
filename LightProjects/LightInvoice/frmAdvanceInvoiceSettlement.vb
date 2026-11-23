Imports System.Drawing.Printing
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmAdvanceInvoiceSettlement

    Dim boolFormIsLoading As Boolean = True
    Dim dblCurrencyRate As Double = 1

    Dim prFont As New Font("Arial", 8, FontStyle.Regular)
    Dim tlFont As New Font("Arial", 8, FontStyle.Bold)
    Dim HeaderFont As New Font("Arial", 12, FontStyle.Bold)
    Dim boolSavingOnly As Boolean

    Dim strSelectedReport As String
    'Dim prFont As New Font("Arial", 6, FontStyle.Regular)
    'Dim tlFont As New Font("Arial", 6, FontStyle.Bold)
    'Dim HeaderFont As New Font("Arial", 12, FontStyle.Bold)
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

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    'Devotion 

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        With dGrid
            If .CurrentCell.ColumnIndex = 6 Then
                If Not IsNumeric(.CurrentCell.Value) Then
                    MessageBox.Show("Please enter a numeric value in this column. Value will be reset to zero",
                        "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    .CurrentCell.Value = "0.00"
                Else
                    .CurrentCell.Value = Format(CDbl(.CurrentCell.Value.ToString), "##0.00")

                    If CDbl(.CurrentCell.Value.ToString) < 0 Then
                        MessageBox.Show("Please enter a payment amount greater than 0", "Invalid Amount Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        .CurrentCell.Value = "0.00"
                        Exit Sub
                    End If
                    'Compute the row balance
                    Dim dblCurrentValue As Double = 0
                    Dim dblCurrentPayment As Double = 0
                    Dim dblCurrentCreditNote As Double = 0
                    If Not Object.Equals(Convert.ToString(.CurrentRow.Cells(2).Value), "") Then
                        If IsNumeric(.CurrentRow.Cells(2).Value.ToString) Then
                            dblCurrentValue = CDbl(.CurrentRow.Cells(2).Value.ToString)
                        End If
                    End If
                    If Not Object.Equals(Convert.ToString(.CurrentRow.Cells(3).Value), "") Then
                        If IsNumeric(.CurrentRow.Cells(3).Value.ToString) Then
                            dblCurrentPayment = CDbl(.CurrentRow.Cells(3).Value.ToString)
                        End If
                    End If
                    If Not Object.Equals(Convert.ToString(.CurrentRow.Cells(4).Value), "") Then
                        If IsNumeric(.CurrentRow.Cells(4).Value.ToString) Then
                            dblCurrentCreditNote = CDbl(.CurrentRow.Cells(4).Value.ToString)
                        End If
                    End If

                    Dim dblFinalBalance As Double = dblCurrentValue - (dblCurrentPayment + dblCurrentCreditNote + CDbl(.CurrentRow.Cells(6).Value.ToString))

                    If dblFinalBalance < 0 Then
                        MessageBox.Show("Amount paid is greater than the amount owing", "Process Stopped", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        .CurrentCell.Value = "0.00"
                    Else
                        .CurrentRow.Cells(5).Value = dblFinalBalance
                    End If
                    .CurrentCell.Style.BackColor = Color.LightGreen

                End If
                ' *** Compute the line total
                On Error Resume Next
                ComputeTotals()
                'ComputeCurrentTotalPaid()
            End If
        End With
    End Sub

    Private Sub ComputeTotals()
        With dGrid
            Dim dblTotal As Double = 0
            For i As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(6).Value), "")) Then
                    If IsNumeric(Convert.ToString(.Rows(i).Cells(6).Value)) Then
                        dblTotal = dblTotal + CDbl(Convert.ToString(.Rows(i).Cells(6).Value))
                    End If
                End If
            Next
            lblTotal.Text = Format(dblTotal, "##0.00")
            'Change based on the currency in use
            txtAmountExchange.Text = Format((CDbl(lblRate.Text) * dblTotal), "##0.00")
            'txtAmount.Text = txtAmountExchange.Text
        End With
    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGrid.EditingControlShowing
        Try
            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                'In order to prevent optical problems, we had to call the removeHandler twice
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dGrid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim numCols As Integer = dGrid.ColumnCount
            Dim numRows As Integer = dGrid.RowCount
            Dim currCell As DataGridViewCell = dGrid.CurrentCell
            If currCell.ColumnIndex = numCols - 1 Then
                If currCell.RowIndex < numRows - 1 Then
                    dGrid.CurrentCell = dGrid.Item(0, currCell.RowIndex + 1)
                End If
            Else
                dGrid.CurrentCell = dGrid.Item(currCell.ColumnIndex + 1, currCell.RowIndex)
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub LoadCustomers()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM Customers ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboAccountHolder
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "250;100"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM Customers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboAccountHolder.Items.Clear()
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
        With cboAccountHolder
            If intItemsCount > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on debtors Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If IntPublicCashSales <> 2 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        RecordUpdate("NORMAL")
        Me.Close()
    End Sub

    Private Sub RecordUpdate(UpdateType As String)
        If Not IsNumeric(lblRate.Text) Then
            MessageBox.Show("Please enter a valid amount for payment", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not IsNumeric(lblTotal.Text) Then
            MessageBox.Show("Please enter a valid amount for payment", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            dblAccountSettlementAmount = CDbl(lblTotal.Text)
            boolAbort = False
            'Me.Close() 1670190
        End If
        If String.IsNullOrEmpty(txtAccountNumber.Text) Or String.IsNullOrEmpty(cboAccountHolder.Text) Then
            MessageBox.Show("Please enter the account holder details", "Invalid Account Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccountHolder.Focus()
            Exit Sub
        End If
        If boolIsSpecialLedgerUpdate = True Then
            If String.IsNullOrEmpty(lblDebitAccount.Text) Then
                MessageBox.Show("Please select the contra ledger account", "No Contra Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboLedgerAccounts.Focus()
                Exit Sub
            End If
        End If
        boolAbort = False
        txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))
        CurrentActiveReceiptNumber = CInt(txtReference.Text) : StartDate = dpTransDate.Value : CurrentAmountReceived = CDbl(txtAmountExchange.Text)
        FinishSale()
    End Sub

    Private Sub RoundValues()
        If IsNumeric(lblTotal.Text) Then
            lblTotal.Text = Format((Math.Round(CDbl(lblTotal.Text), 0)), "##0.00")
        End If
        If IsNumeric(txtAmountExchange.Text) Then
            txtAmountExchange.Text = Format((Math.Round(CDbl(txtAmountExchange.Text), 0)), "##0.00")
        End If
    End Sub

    Private Sub cboCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurrency.SelectedIndexChanged
        On Error GoTo RaiseErr
        lblRate.Text = "0.00"
        lblRate.Text = Format(CDbl(cboCurrency.SelectedItem.Col2), "##0.000000")
        If IsNumeric(lblTotal.Text) Then
            If CDbl(lblTotal.Text) <> 0 Then
                txtAmountExchange.Text = Format(((CDbl(lblTotal.Text) / CDbl(lblRate.Text))), "##0.00")
            End If
        End If
        ComputeTotals()
        If strRoundOnExchange = "YES" Then RoundValues()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On exchange computation"
        ShowErrorMessage()
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

    Private Sub btnFindAccount_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFindAccount.Click
        strPublicItemCode = Nothing
        strPublicItemDescription = Nothing
        txtAccountNumber.Text = Nothing
        boolAbort = False
        Dim f As New frmBrowseDebtors
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        txtAccountNumber.Text = strPublicItemCode
        cboAccountHolder.Text = strPublicItemDescription
    End Sub

    Private Sub FinishSale()

        arrSettledInvoices = New ArrayList

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

        txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))

        Dim dblSpecialKey As Integer = gwt_comm.SpecialKey()

        If chkOverideDate.Checked = True Then
            dpProcessDate = Format(dpTransDate.Value, "dd-MMM-yyyy")
        End If

        dblSumPayable = dblAccountSettlementAmount

        If boolIsSpecialLedgerUpdate = True Then
            Dim strSqlQuery = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
                    & "[Description],[UserName],[UserBranch],[Reference], [CostCode], [SpecialKey]) VALUES " _
                    & "('" & lblDebitAccount.Text & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " & dblSumPayable & ", " _
                    & "'DEBIT', '" & strPublicActiveCashbook & "', 'DEBTORS LEDGER TO GENERAL LEDGER POSTING', '" & strUserName & "', " _
                    & "'" & strUserBranch & "', " & Convert.ToDouble(txtReference.Text) & ", 0, " & dblSpecialKey & ")"
            myCommand = New Data.OleDb.OleDbCommand(strSqlQuery, cnn)
            myCommand.ExecuteNonQuery()
        Else
            'Update the cashbook with the values
            Dim strCashbookDescription As String = "CASH RECEIPT - ACCOUNT PAYMENT " & UCase(strUserName)
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, TransactionDate, " _
                & "Amount, Description, ContraAccount, UserName, UserBranch, TransactionType, Reference, SpecialKey) VALUES " _
                & "('" & strPublicActiveCashbook & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " & dblSumPayable & ", " _
                & "'" & strCashbookDescription & "-" & txtAccountNumber.Text & "', '" & strPublicSalesAccount & "', " _
                & "'" & strUserName & "', '" & strUserBranch & "', 'DEBIT', " & Convert.ToDouble(txtReference.Text) & ", " & dblSpecialKey & ")", cnn)
            myCommand.ExecuteNonQuery()
        End If
        'Update the cash ledger control account as well
        'If String.IsNullOrEmpty(strPublicCashControlAccount) Then
        '    MessageBox.Show("The cash control account has not been defined. This will serious affect the trial balance.", MsgBoxStyle.Exclamation, "Cash Control Account Not Set")
        'Else
        '    myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
        '        & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
        '        & "('" & strPublicCashControlAccount & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " & dblSumPayable & ", " _
        '        & "'DEBIT', '" & txtAccountNumber.Text & "', '" & cboAccountHolder.Text & "', '" & strUserName & "', " _
        '        & "'" & strUserBranch & "', " & Convert.ToDouble(txtReference.Text) & ", " & dblSpecialKey & ")", cnn)
        '    myCommand.ExecuteNonQuery()
        'End If

        'If UCase(strWebConnectionType) = "REALTIME" Then
        '    strSqlTransmit = myCommand.CommandText
        '    strSqlTransmit = Replace(strSqlTransmit, "INTO CashbookTransactions (", "INTO GroupCashbookTransactions (BranchName, ", 1)
        '    strSqlTransmit = Replace(strSqlTransmit, "VALUES (", "VALUES ('" & strUserBranch & "', ", 1)
        '    TransmitSale(strSqlTransmit)
        'End If

        'Post the account to the contra debtors ledger account
        If String.IsNullOrEmpty(strPublicDebtorsAccount) Then
            MessageBox.Show("The debtors control account has not been defined. This will serious affect the trial balance.", _
                 "Debtors Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                & "('" & strPublicDebtorsAccount & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " & dblSumPayable & ", " _
                & "'CREDIT', '" & txtAccountNumber.Text & "', '" & cboAccountHolder.Text & "', '" & strUserName & "', " _
                & "'" & strUserBranch & "', " & Convert.ToDouble(txtReference.Text) & ", " & dblSpecialKey & ")", cnn)
            myCommand.ExecuteNonQuery()
        End If

        'If UCase(strWebConnectionType) = "REALTIME" Then
        '    strSqlTransmit = myCommand.CommandText
        '    strSqlTransmit = Replace(strSqlTransmit, "INTO LedgerTransactions (", "INTO GroupLedgerTransactions (BranchName, ", 1)
        '    strSqlTransmit = Replace(strSqlTransmit, "VALUES (", "VALUES ('" & strUserBranch & "', ", 1)
        '    TransmitSale(strSqlTransmit)
        'End If

        'Update the customer account. First initialize the moving totals

        dblSettlementInvoiceTotals = 0
        dblSettlementReceivedToDate = 0
        dblSettlementCreditNotesValue = 0
        dblSettlementReceivedCurrently = 0
        dblSettlementCurrentBalance = 0

        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(p).Cells(6).Value), Nothing) Then
                If IsNumeric(dGrid.Rows(p).Cells(6).Value) Then
                    Dim dblAmount As Double = CDbl(dGrid.Rows(p).Cells(6).Value.ToString)

                    Dim strRef As String = Nothing
                    If Not Object.Equals(Convert.ToString(dGrid.Rows(p).Cells(1).Value), Nothing) Then
                        strRef = dGrid.Rows(p).Cells(1).Value.ToString
                    End If

                    Dim strInvoiceValue As String = "0.00"
                    If Not Object.Equals(Convert.ToString(dGrid.Rows(p).Cells(2).Value), Nothing) Then
                        If IsNumeric(dGrid.Rows(p).Cells(2).Value) Then
                            strInvoiceValue = CStr(Format(CDbl(dGrid.Rows(p).Cells(2).Value.ToString), "##0.00"))
                        End If
                    End If

                    Dim strReceivedToDate As String = "0.00"
                    If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
                        If IsNumeric(dGrid.Rows(p).Cells(3).Value) Then
                            strReceivedToDate = CStr(Format(CDbl(dGrid.Rows(p).Cells(3).Value.ToString), "##0.00"))
                        End If
                    End If

                    Dim strCreditNotesValue As String = "0.00"
                    If Not Object.Equals(dGrid.Rows(p).Cells(4).Value, Nothing) Then
                        If IsNumeric(dGrid.Rows(p).Cells(4).Value) Then
                            strCreditNotesValue = CStr(Format(CDbl(dGrid.Rows(p).Cells(4).Value.ToString), "##0.00"))
                        End If
                    End If

                    Dim dblBalance As Double = CDbl(dGrid.Rows(p).Cells(5).Value.ToString)

                    Dim strComment As String = Nothing
                    If Not Object.Equals(dGrid.Rows(p).Cells(7).Value, Nothing) Then
                        strComment = dGrid.Rows(p).Cells(7).Value.ToString()
                    End If

                    Dim dblCurrentBalance As Double = CDbl(strInvoiceValue) - (CDbl(strReceivedToDate) + CDbl(strCreditNotesValue) + dblAmount)
                    'Details, inv#=1, val=2, received to date=3, crd note=4, paid now=6, balance
                    If dblAmount <> 0 Then

                        arrSettledInvoices.Add("PAYMENT " & UCase(strComment) & "|" & strRef & "|" & strInvoiceValue & "|" & strReceivedToDate & "|" & _
                            strCreditNotesValue & "|" & Format(dblAmount, "##0.00") & "|" & Format(dblCurrentBalance, "##0.00"))

                        dblSettlementInvoiceTotals = dblSettlementInvoiceTotals + CDbl(strInvoiceValue)
                        dblSettlementReceivedToDate = dblSettlementReceivedToDate + CDbl(strReceivedToDate)
                        dblSettlementCreditNotesValue = dblSettlementCreditNotesValue + CDbl(strCreditNotesValue)
                        dblSettlementReceivedCurrently = dblSettlementReceivedCurrently + dblAmount
                        dblSettlementCurrentBalance = dblSettlementCurrentBalance + dblCurrentBalance

                    End If

                    Dim strEntryDescription As String = "CASH PAYMENT"
                    If Not String.IsNullOrEmpty(strComment) Then strEntryDescription = UCase(Trim(strComment))

                    myCommand = New Data.OleDb.OleDbCommand("INSERT INTO CustomerTransactions ([AccountNumber],[TransactionDate]," _
                        & "[Amount],[TransactionType],[Description],[ReferenceNumber],[UserName],[BranchName], [SpecialKey], [Comments]) " _
                        & "VALUES('" & txtAccountNumber.Text & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " _
                        & "" & (0 - dblAmount) & ", 'PAYMENT', '" & strEntryDescription & "', '" & strRef & "', " _
                        & "'" & strUserName & "', '" & strUserBranch & "', " & dblSpecialKey & ", '" & strComment & "')", cnn)
                    myCommand.ExecuteNonQuery()

                    'Update the claims history payment
                    If Not String.IsNullOrEmpty(strRef) Then
                        myCommand = New Data.OleDb.OleDbCommand("UPDATE ConstructionClaimsHistory " _
                            & "SET PaymentDate1 = '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " _
                            & "PaymentAmount1 = " & dblAmount & ", Balance = " & dblBalance & " " _
                            & "WHERE InvoiceNumber = " & CDbl(strRef) & "", cnn)
                        myCommand.ExecuteNonQuery()
                    End If

                End If
            End If
        Next

        'Update the control numbers table
        myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET CashSales = " & CDbl(txtReference.Text) & "", cnn)
        myCommand.ExecuteNonQuery()

        strPublicCustomerId = txtAccountNumber.Text
        PrintInvoice(dpProcessDate)
        MessageBox.Show("Sales document generated successfully.", "Transaction Document Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
        dblAmountChange = 0
        txtAccountNumber.Clear()
        txtAccountNumber.Clear()

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


        Dim strSerial As String = txtAccountNumber.Text
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
        arrPrintDetails.Add(Space(2) & "TOTAL INCL. VAT " & Space(14 - Format(dblAccountSettlementAmount, "##0.00").Length) & Format(dblAccountSettlementAmount, "##0.00"))
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "VAT CHARGED     " & Space(14 - strTaxCharged.Length) & strTaxCharged)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "AMOUNT TENDERED " & Space(14 - strTender.Length) & strTender)
        arrPrintDetails.Add(Space(2) & "CHANGE" & Space(23 - strChange.Length) & strChange)

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
        arrPrintDetails.Add(Space(2) & "*** DOC NO *** " & txtReference.Text)
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

        boolPrinterAlreadySelected = False

        If UCase(strPublicPrinterType) = "RAW" Then
            If MessageBox.Show("Do you want to print the receipt right now?", "Confirm Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                If strRequestForReceiptPrinter = "YES" Then
                    boolAbort = False
                    Dim f As New frmPrinterSetup
                    f.ShowDialog()
                    If boolAbort = True Then Exit Sub
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
        Else
            'Print to an ordinary print
            SettlementDate = dpTransDate.Value
            strSelectedAccount = txtAccountNumber.Text
            gwt_comm.PrintCustomerDocument(0, "SETTLEMENT")  'For payments the document number is always 0
            'PrintPreviewDialog1.Document = pdWindows
            'PrintPreviewDialog1.ShowDialog()
        End If
        '-*- End If -*-
        'MessageBox.Show("Payslip preparation successful", MsgBoxStyle.Information, "Payslip Preparation Success")
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Processing"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadCurrencyData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CurrencyName +';'+ CONVERT(NVARCHAR, CurrencyRate) AS [Details] " _
            & "FROM Currencies ORDER BY CurrencyName", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        'Set up the drop down combo box
        With cboCurrency
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
        Dim intItemsCount As Integer = 0
        objCommand = New Data.OleDb.OleDbCommand("SELECT Count(CurrencyName) FROM Currencies", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboCurrency.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()
        With cboCurrency
            If intItemsCount > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With
        cboCurrency.SelectedText = strDefaultCurrency
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On currencies load"
        ShowErrorMessage()
    End Sub

    Private Sub TransmitSale(ByVal fileString As String)
        strDownloadingType = "SALES"
        ServerDestinationFolder = strWebMainBranch.Replace(" ", "") & "/DailySales"
        strDestinationBranch = strWebMainBranch
        gwt_comm.AddDataChanges(fileString)
    End Sub

    Private Sub frmAdvanceInvoiceSettlement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadCustomers()
        LoadCurrencyData()
        LoadLedgerAccounts()
        If boolReceptCustomerFromForm = True Then
            txtAccountNumber.Text = strSelectedAccount
            cboAccountHolder.Text = strSelectedAccountName
            'txtAccountNumber.Enabled = False : cboAccountHolder.Enabled = False
        End If
        dpTransDate.Enabled = False
        If boolIsSpecialLedgerUpdate = True Then
            pnlLedger.Visible = True
            cboLedgerAccounts.Visible = True
        Else
            pnlLedger.Visible = False
            cboLedgerAccounts.Visible = False
        End If
        lbl2.ForeColor = Color.White
        lbl2.BackColor = Color.Firebrick

        On Error GoTo RaiseErr
        If boolLoadedFromCustomerForm = True Then
            Dim objCommand As Data.OleDb.OleDbCommand
            Dim objReader As Data.OleDb.OleDbDataReader

            objCommand = New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM Customers WHERE " _
            & "AccountNumber = '" & strSelectedAccount & "'", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then txtAccountNumber.Text = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then cboAccountHolder.Text = objReader(1).ToString
                cboAccountHolder.Enabled = False
                LoadInvoices(txtAccountNumber.Text)
            End If
            objReader.Close()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Selected Customer Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadLedgerAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM LedgerAccounts ORDER BY AccountNumber"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboLedgerAccounts
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "335;100"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM LedgerAccounts", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboLedgerAccounts.Items.Clear()
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
            cboLedgerAccounts.SelectedIndex = -1
            cboLedgerAccounts.Items.Clear()
            cboLedgerAccounts.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboLedgerAccounts.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Account Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboAccountHolder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAccountHolder.KeyPress
        dGrid.Rows.Clear()
    End Sub

    Private Sub cboAccountHolder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountHolder.SelectedIndexChanged
        txtAccountNumber.Text = Nothing
        dGrid.Rows.Clear()
        txtAccountNumber.Text = cboAccountHolder.SelectedItem.Col2
        If Not String.IsNullOrEmpty(txtAccountNumber.Text) Then LoadInvoices(txtAccountNumber.Text)
    End Sub

    Private Sub LoadInvoices(ByVal AccountNumber As String)

        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        dGrid.Rows.Clear()
        If UCase(strTaxComputationType) = "INCLUSIVE" Then
            strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date], InvoiceNumber, " _
                & "CAST(SUM((SalesPrice * Quantity) - DiscountAllowed) AS DECIMAL (10,2)) as [Paid] " _
                & "FROM CustomerSales WHERE CustomerId = '" & AccountNumber & "' " _
                & "GROUP BY TransDate, InvoiceNumber ORDER BY TransDate, InvoiceNumber"
        Else
            strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date], InvoiceNumber, " _
                & "CAST(SUM((SalesPrice * Quantity) - DiscountAllowed + Taxes) AS DECIMAL (10,2)) as [Paid] " _
                & "FROM CustomerSales WHERE CustomerId = '" & AccountNumber & "' " _
                & "GROUP BY TransDate, InvoiceNumber ORDER BY Transdate, InvoiceNumber"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrTransactions As New ArrayList
        While objReader.Read
            If IsNumeric(objReader(2).ToString) Then
                If CDbl(objReader(2).ToString) <> 0 Then
                    dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), "0.00")
                End If
            End If
        End While
        objReader.Close()

        'Get the payments
        Dim dblUnmatchedPaymentsAmount As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                strSql = "SELECT CAST(SUM(0 - Amount) AS DECIMAL (10,2)) AS [Amt] FROM CustomerTransactions " _
                    & "WHERE AccountNumber = '" & AccountNumber & "' AND " _
                    & "ReferenceNumber = '" & dGrid.Rows(i).Cells(1).Value.ToString & "' AND " _
                    & "TransactionType = 'PAYMENT'"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objReader = objCommand.ExecuteReader
                Dim dblPayment As Double = 0
                While objReader.Read
                    If IsNumeric(objReader(0).ToString) Then dblPayment = dblPayment + CDbl(objReader(0).ToString)
                End While
                objReader.Close()
                If dblPayment <> 0 Then dGrid.Rows(i).Cells(3).Value = dblPayment
            End If
        Next

        'Get the credit notes
        Dim dblSumOfCredits As Double
        strSql = "SELECT CreditNotesMain.AccountId, CreditNoteEntries.Reference, " _
            & "SUM((CreditNoteEntries.Quantity * CreditNoteEntries.UnitPrice) + Taxes) AS [Values] FROM " _
            & "CreditNotesMain, CreditNoteEntries WHERE CreditNoteEntries.NoteNumber = CreditNotesMain.NoteNumber " _
            & "AND CreditNotesMain.AccountId = '" & AccountNumber & "' GROUP BY AccountId, CreditNoteEntries.Reference"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If IsNumeric(objReader(2).ToString) Then dblSumOfCredits = dblSumOfCredits + CDbl(objReader(2).ToString)
        End While
        objReader.Close()

        'Lets match the credit notes to the invoices
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                Dim strReference As String = dGrid.Rows(i).Cells(1).Value.ToString
                Dim dblCredits As Double = 0
                strSql = "SELECT CreditNotesMain.AccountId, CreditNoteEntries.Reference, " _
                & "SUM((CreditNoteEntries.Quantity * CreditNoteEntries.UnitPrice) + Taxes) AS [Values] FROM " _
                & "CreditNotesMain, CreditNoteEntries WHERE CreditNoteEntries.NoteNumber = CreditNotesMain.NoteNumber " _
                & "AND CreditNotesMain.AccountId = '" & AccountNumber & "' AND CreditNoteEntries.Reference = '" & strReference & "' " _
                & "GROUP BY AccountId, CreditNoteEntries.Reference"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objReader = objCommand.ExecuteReader
                While objReader.Read
                    If IsNumeric(objReader(2).ToString) Then
                        dGrid.Rows(i).Cells(4).Value = Format(CDbl(objReader(2).ToString), "##0.00")
                    End If
                    'dblCredits = dblSumOfCredits + CDbl(objReader(2).ToString)
                End While
                objReader.Close()
            End If
        Next

        'Get a sum of all payments matched and compare with the sum of all payments received, the difference is unmatched payments
        Dim dblAllPayments As Double = 0
        strSql = "SELECT CAST(SUM(0 - Amount) AS DECIMAL (10,2)) AS [Amt] FROM CustomerTransactions " _
                    & "WHERE AccountNumber = '" & AccountNumber & "' AND TransactionType = 'PAYMENT'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblAllPayments = CDbl(objReader(0).ToString)
        End If
        objReader.Close()

        Dim dblMatchedPayments As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    dblMatchedPayments = dblMatchedPayments + CDbl(dGrid.Rows(i).Cells(3).Value.ToString)
                End If
            End If
        Next

        'Sum up all the matched credit notes
        '
        Dim dblUnMatchedCreditNotes As Double = 0
        Dim dblMatchedCreditNotes As Double = 0

        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                    dblMatchedCreditNotes = dblMatchedCreditNotes + CDbl(dGrid.Rows(i).Cells(4).Value.ToString)
                End If
            End If
        Next
        dblUnMatchedCreditNotes = dblSumOfCredits - dblMatchedCreditNotes

        dblUnmatchedPaymentsAmount = dblAllPayments - dblMatchedPayments
        If dblUnmatchedPaymentsAmount <> 0 Then
            dGrid.Rows.Add("UNMATCHED", "", "0.00", dblUnmatchedPaymentsAmount, "0.00", "0.00")
        End If

        'Compute the balances
        '
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblValue As Double = 0
            Dim dblPaid As Double = 0
            Dim dblCreditNotes As Double = 0
            Dim dblBalance As Double = 0
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    dblValue = CDbl(dGrid.Rows(i).Cells(2).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    dblPaid = CDbl(dGrid.Rows(i).Cells(3).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                    dblCreditNotes = CDbl(dGrid.Rows(i).Cells(4).Value.ToString)
                End If
            End If
            dblBalance = dblValue - (dblPaid + dblCreditNotes)
            dGrid.Rows(i).Cells(5).Value = dblBalance
        Next

        'dGrid.Rows(dGrid.Rows.Count - 1).Cells(5).Value = "0.001"

        'Remove the rows which are fully paid
        '
        For Each dr As DataGridViewRow In dGrid.Rows
            'If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(5).Value), "") Then
            '    If IsNumeric(dGrid.CurrentRow.Cells(5).Value.ToString) Then
            '        If CDbl(dGrid.CurrentRow.Cells(5).Value.ToString) = 0 Then
            '            dGrid.Rows.Remove(dr)
            '        End If
            '    End If
            'End If
            If Not Object.Equals(Convert.ToString(dr.Cells(5).Value), "") Then
                If IsNumeric(dr.Cells(5).Value.ToString) Then
                    If CDbl(dr.Cells(5).Value.ToString) = 0 Then
                        dGrid.Rows.Remove(dr)
                    End If
                End If
            End If
        Next

        'Display the account balance
        Dim dblTotalBalances As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(i).Cells(5).Value.ToString, "") Then
                If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                    dblTotalBalances = dblTotalBalances + CDbl(dGrid.Rows(i).Cells(5).Value.ToString)
                End If
            End If
        Next
        lblAccountBalance.Text = Format(dblTotalBalances, "#,##0.00")

        ''Dim strLastPaymentAmount As String = "0.00"
        ''Dim strLastPaymentDate As String = Nothing
        ''While objReader.Read
        ''    arrTransactions.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" _
        ''        & objReader(2).ToString & ";1;;" & objReader(3).ToString & ";PAYMENT")
        ''    If IsDate(objReader(0).ToString) Then strLastPaymentDate = Format(CDate(objReader(0).ToString), "dd-MM-yyyy")
        ''    If IsNumeric(objReader(3).ToString) Then strLastPaymentAmount = CStr(Format(CDbl(objReader(3).ToString), "##0.00"))
        ''End While
        ''objReader.Close()

        ' ''Get the credit note entries
        ''strSql = "SELECT CONVERT(NVARCHAR, CreditNotesMain.TransDate, 105) as [Date], CreditNoteEntries.NoteNumber, " _
        ''    & "CreditNoteEntries.Description, SUM(CreditNoteEntries.Quantity) as [Qty], " _
        ''    & "CAST(SUM((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity) - 0) AS DECIMAL (10,2)) as [Paid] " _
        ''    & "FROM CreditNoteEntries, CreditNotesMain WHERE CreditNoteEntries.NoteNumber = CreditNotesMain.NoteNumber " _
        ''    & "AND CreditNotesMain.AccountId = '" & AccountNumber & "' AND ((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity) - 0) > 0 " _
        ''    & "GROUP BY CreditNotesMain.TransDate, CreditNoteEntries.NoteNumber, CreditNoteEntries.Description " _
        ''    & "ORDER BY CreditNotesMain.TransDate"
        ''objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        ''objReader = objCommand.ExecuteReader
        ''While objReader.Read
        ''    arrTransactions.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" _
        ''        & objReader(2).ToString & ";" & objReader(3).ToString & ";;" & objReader(4).ToString & ";CREDIT NOTE")
        ''End While
        ''objReader.Close()

        If dGrid.RowCount > 0 Then
            txtAmount.Enabled = True
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On customer invoices load"
        ShowErrorMessage()
    End Sub

    Private Sub pdWindows_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdWindows.PrintPage
        'This will send the printing to the windows type

        'Dim prFont As New Font("Arial", 6, FontStyle.Regular)
        'Dim tlFont As New Font("Arial", 6, FontStyle.Bold)
        'Dim HeaderFont As New Font("Arial", 12, FontStyle.Bold)

        Dim y1 As Integer = 10

        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                'Dont print the company name as it is taken care of by the logo
                strCompanyName = ""
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                R = New Rectangle(10, y1, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                y1 = y1 + objPicture.Height
            End If
        End If

        y1 = y1 + 15

        For i As Integer = 0 To arrPrintDetails.Count - 1
            If i = 0 Then
                Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, arrPrintDetails.Item(i), tlFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, arrPrintDetails.Item(i), prFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Next
        e.HasMorePages = False
    End Sub

    Private Sub cboLedgerAccounts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLedgerAccounts.SelectedIndexChanged
        lblDebitAccount.Text = ""
        If Not cboLedgerAccounts.SelectedItem Is Nothing Then
            lblDebitAccount.Text = cboLedgerAccounts.SelectedItem.Col2
        End If
    End Sub

    Private Sub MatchInvoicesAndPaymentsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MatchInvoicesAndPaymentsToolStripMenuItem.Click
        If dGrid.Rows.Count > 0 Then
            If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
                If dGrid.CurrentRow.Cells(0).Value = "UNMATCHED" Then
                    arrSelectedItems = New ArrayList
                    For i As Integer = 0 To dGrid.Rows.Count - 1
                        Dim strDate As String = Nothing
                        Dim strInvoice As String = Nothing
                        Dim strAmount As String = "0.00"
                        Dim strReceived As String = "0.00"
                        If Not Object.Equals(dGrid.Rows(i).Cells(0).Value, Nothing) Then
                            strDate = dGrid.Rows(i).Cells(0).Value.ToString
                        End If
                        If Not Object.Equals(dGrid.Rows(i).Cells(1).Value, Nothing) Then
                            strInvoice = dGrid.Rows(i).Cells(1).Value.ToString
                        End If
                        If Not Object.Equals(dGrid.Rows(i).Cells(2).Value, Nothing) Then
                            strAmount = dGrid.Rows(i).Cells(2).Value.ToString
                        End If
                        If Not Object.Equals(dGrid.Rows(i).Cells(3).Value, Nothing) Then
                            strReceived = dGrid.Rows(i).Cells(3).Value.ToString
                        End If
                        If CDbl(strReceived) <> CDbl(strAmount) Then
                            arrSelectedItems.Add(strDate & "|" & strInvoice & "|" & strAmount & "|0.00")
                        End If
                    Next
                    strSelectedAccount = txtAccountNumber.Text
                    Dim f As New frmMatchInvoicesToPayments
                    f.ShowDialog()
                    LoadInvoices(strSelectedAccount)

                Else
                    MessageBox.Show("This process cannot be called for this transaction", "Process Stopped", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub btnSpecialMatch_Click(sender As System.Object, e As System.EventArgs) Handles btnSpecialMatch.Click
        RecordUpdate("SPECIAL")
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown

    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As System.EventArgs) Handles txtAmount.TextChanged
        If Not IsNumeric(txtAmount.Text) Then
            txtAmount.Text = "0.00"
        End If
        If IsNumeric(txtAmount.Text) Then
            Dim dblRemainder As Double = CDbl(txtAmount.Text)
            For p As Integer = 0 To dGrid.Rows.Count - 1
                dGrid.Rows(p).Cells(6).Value = "0.00"
            Next
            For p As Integer = 0 To dGrid.Rows.Count - 1
                Dim dblBalance As Double = 0
                If Not Object.Equals(dGrid.Rows(p).Cells(5).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(5).Value.ToString) Then
                        If IsNumeric(dGrid.Rows(p).Cells(5).Value.ToString) Then
                            dblBalance = CDbl(dGrid.Rows(p).Cells(5).Value.ToString)
                            If dblBalance >= dblRemainder Then
                                dGrid.Rows(p).Cells(6).Value = dblRemainder
                                Exit For
                            Else
                                If dblBalance <= 0 Then
                                    dblBalance = 0 - dblRemainder
                                    dGrid.Rows(p).Cells(6).Value = dblBalance
                                    Exit For
                                Else
                                    dGrid.Rows(p).Cells(6).Value = dblBalance
                                    dblRemainder = dblRemainder - dblBalance
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        End If
    End Sub

End Class
