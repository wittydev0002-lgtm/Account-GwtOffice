Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmFinancialYearEndClearDown

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        boolAbort = False
        Dim frm As Form
        If chkBackup.Checked = False Then
            If MessageBox.Show("Are you sure you want to proceed without a backup? " _
                 & "Once clear down is done all past financial year records are deleted",
                 "Confirm Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                gwt_comm.BackupDatabase()
                If boolAbort = True Then
                    MessageBox.Show("Process has been aborted", "Process Ended", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If
        Else
            gwt_comm.BackupDatabase()
            If boolAbort = True Then
                MessageBox.Show("Process has been aborted", "Process Ended", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If

        If chkClearDown.Checked = True Then
            ClearDown()
        End If
        If boolAbort = True Then Exit Sub
        If chkCalendar.Checked = True Then
            frm = New frmFinancialPeriods
            frm.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ClearDown()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        'Get the debtors balance as at the end of the close period

        If String.IsNullOrEmpty(strPublicReservesControlAccount) Then
            MessageBox.Show("The reserve account has not been set. Please set it up in special ledger accounts before proceeding",
                "Missing Reserve Control Account", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            boolAbort = True
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim arrDebtors As New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber FROM Customers ORDER BY AccountNumber", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                Dim dblCummulativeStatementBalance As Double = gwt_comm.CustomerTempTable(objReader(0).ToString, CDate(shortMonthDateFormat(dpDate.Value)))
                arrDebtors.Add(objReader(0).ToString & "|" & dblCummulativeStatementBalance)
            End If
        End While
        objReader.Close()

        'Get the creditors balances as at the period close as well

        Dim arrCreditors As New ArrayList

        'Get the profit and loss account that will be posted to the reserves account

        StartDate = CDate("01-JAN-2008")
        EndDate = CDate(shortMonthDateFormat(dpDate.Value))

        Dim Sales As SalesData = gwt_comm.GetSalesFigures(StartDate, EndDate)

        'Get the balances of all the expenditure accounts
        Dim dblExpensesTotal As Double = 0
        objCommand = New Data.OleDb.OleDbCommand("SELECT AccountNumber, Classification from ledgeraccounts WHERE AccountType = 'Expense'", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(objReader("Classification").ToString) <> UCase("-- Not Applicable --") Then
                    Dim Ledgers As LedgerFigures = gwt_comm.GetLedgerFigures(StartDate, EndDate, objReader(0).ToString)
                    dblExpensesTotal = dblExpensesTotal + Ledgers.ClosingBalance
                End If
            End If
        End While
        objReader.Close()

        'Get the total of other incomes
        Dim dblTotalOtherIncomes As Double = 0
        objCommand = New Data.OleDb.OleDbCommand("SELECT AccountNumber, Classification from ledgeraccounts WHERE AccountType = 'INCOME'", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(objReader("Classification").ToString) <> UCase("-- Not Applicable --") Then
                    Dim Ledgers As LedgerFigures = gwt_comm.GetLedgerFigures(StartDate, EndDate, objReader(0).ToString)
                    dblTotalOtherIncomes = dblTotalOtherIncomes + Ledgers.ClosingBalance
                End If
            End If
        End While
        objReader.Close()

        'Get the net profit figure
        Dim dblProfit As Double = (((Sales.GrossSales - Sales.CostOfSales) - dblExpensesTotal) + dblTotalOtherIncomes)

        'Get the values for the cashbooks

        Dim arrCashbookBalances As New ArrayList
        objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT AccountNumber from Cashbooks", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                Dim dblBalanceBefore() As Double = gwt_comm.CashbookAccountBalances(StartDate, EndDate, objReader(0).ToString)
                Dim dblBalanceBroughtDown As Double = dblBalanceBefore(1)
                arrCashbookBalances.Add(objReader(0).ToString & "|" & dblBalanceBroughtDown)
            End If
        End While
        objReader.Close()


        '*** NOW DROP ALL THE TRANSACTIONS BEFORE THE CUT OFF DATE ***

        '*** DROP EXPENSES TRANSACTIONS ***
        objCommand = New Data.OleDb.OleDbCommand("SELECT AccountNumber, Classification from ledgeraccounts WHERE AccountType = 'Expense'", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE " _
                    & "AccountNumber = '" & objReader(0).ToString & "' AND " _
                    & "TransactionDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
                objCommand.ExecuteNonQuery()
            End If
        End While

        '** DROP OTHER INCOMES ***
        objCommand = New Data.OleDb.OleDbCommand("SELECT AccountNumber, Classification from ledgeraccounts WHERE AccountType = 'INCOME'", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE " _
                    & "AccountNumber = '" & objReader(0).ToString & "' AND " _
                    & "TransactionDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
                objCommand.ExecuteNonQuery()
            End If
        End While

        '*** DROP ALL CASHBOOK TRANSACTIONS ***

        'objCommand = New Data.OleDb.OleDbCommand("SELECT AccountNumber from Cashbooks", cnn)
        'objReader = objCommand.ExecuteReader
        'While objReader.Read
        '    If Not IsDBNull(objReader(0).ToString) Then
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CashbookTransactions WHERE " _
            & "TransactionDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
        objCommand.ExecuteNonQuery()
        '    End If
        'End While

        '*** DROP THE SALES ***

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Sales WHERE " _
            & "TransDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SalesMain WHERE " _
            & "TransDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
        objCommand.ExecuteNonQuery()

        '*** DROP INVOICES ***
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSales WHERE " _
            & "TransDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSalesMain WHERE " _
            & "TransDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
        objCommand.ExecuteNonQuery()

        '*** DROP THE CUSTOMER TRANSACTIONS TABLE DETAILS ***
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerTransactions WHERE " _
            & "TransactionDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
        objCommand.ExecuteNonQuery()

        '*** DROP CREDIT NOTES ENTRIES ***
        objCommand = New Data.OleDb.OleDbCommand("SELECT NoteNumber FROM CreditNotesMain WHERE " _
            & "TransDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CreditNoteEntries WHERE " _
                & "NoteNumber = '" & objReader(0).ToString & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CreditNotesMain WHERE " _
                & "NoteNumber = '" & objReader(0).ToString & "'", cnn)
            objCommand.ExecuteNonQuery()
        End While
        objReader.Close()

        '*** DROP CONTROL ACCOUNT TRANSACTIONS ***


        '*** DROP THE VOIDED SALES TRANSACTIONS ***

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM VoidSales WHERE " _
            & "TransDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM VoidSalesMain WHERE " _
            & "TransDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
        objCommand.ExecuteNonQuery()

        '*** DROP THE TICKECT SALES TRANSACTIONS ***
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM TicketSales WHERE " _
            & "TransDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM TicketSalesMain WHERE " _
            & "TransDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
        objCommand.ExecuteNonQuery()


        'Post the debtors balances to the individual accounts
        For i As Integer = 0 To arrDebtors.Count - 1
            Dim strAccountDetails() As String = Split(arrDebtors.Item(i), "|")
            Dim intNextInvoiceNumber As Double = CDbl(gwt_comm.GetNextDocumentNumber("Invoices"))
            If CDbl(strAccountDetails(1)) <> 0 Then
                Dim strSql As String = "INSERT INTO CustomerSales ([InvoiceNumber],[CustomerId],[ItemCode],[Description],[Quantity],[DiscountAllowed]" _
                   & ", [Taxes], [TransType], [SalesPrice], [TransDate], [ProductType], [SerialNumbers]" _
                   & ",[OriginalInvoice],[SalesRep],[UserName],[OrderNumber]) VALUES (" & intNextInvoiceNumber & ", '" & strAccountDetails(0) & "', " _
                   & "'00000', 'YEAR END ROLL OVER BALANCE', 1, 0, 0, 'INVOICE', " & CDbl(strAccountDetails(1)) & ", " _
                   & "'" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "', " _
                   & "'GENERIC', '', 0,'NONE', '" & strUserName & "', '')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                strSql = "INSERT INTO CustomerSalesMain ([InvoiceNumber],[CustomerId],[Status],[Amount],[Taxes],[Discount],[TransDate]," _
                    & "[OriginalInvoice],[SalesRep],[UserName],[OrderNumber]) VALUES (" & intNextInvoiceNumber & ", '" & strAccountDetails(0) & "', " _
                    & "'', " & CDbl(strAccountDetails(1)) & ", 0,0, '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "', 0, '', " _
                    & "'" & strUserName & "', '')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                'Update the invoice numbers
                objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET Invoices = " & intNextInvoiceNumber & "", cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next

        '*** INITIALIZE CASHBOOKS ***
        For i As Integer = 0 To arrCashbookBalances.Count - 1
            Dim strAccountDetails() As String = Split(arrCashbookBalances.Item(i), "|")
            Dim intKeyCode As Long = gwt_comm.SpecialKey()
            Dim strType As String = "DEBIT"
            If CDbl(strAccountDetails(1)) <= 0 Then strType = "CREDIT"
            If CDbl(strAccountDetails(1)) <> 0 Then
                Dim strReferenceCode As String = Format(DateAdd(DateInterval.Day, 1, EndDate), "ddMMyy")
                Dim strSqlCash As String = "INSERT INTO CashbookTransactions ([TransactionDate],[Amount],[Description],[AccountNumber]," _
                    & "[ContraAccount],[UserName],[UserBranch],[Reference],[TransactionType],[Status],[PaymentMethod],[FolioReference]," _
                    & "[VatAmount],[KeyNumber],[Taxes],[VatNumber],[LinkedProject],[SpecialKey]) VALUES " _
                    & "('" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "', " & strAccountDetails(1) & ", " _
                    & "'YEAR END ROLL OVER BALANCE', '" & strAccountDetails(0) & "', '000000', '" & strUserName & "', " _
                    & "'" & strUserBranch & "', " & strReferenceCode & ", '" & strType & "', 'N', 'CASH', '0000', " _
                    & "0, " & intKeyCode & ", 0, '', 0, " & intKeyCode & ")"
                objCommand = New Data.OleDb.OleDbCommand(strSqlCash, cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next

        '*** INITIALIZE THE SPECIAL ACCOUNTS ***
        Dim arrControlAccounts As New ArrayList
        arrControlAccounts.Add(strPublicSalesAccount)
        arrControlAccounts.Add(strPublicDebtorsAccount)
        arrControlAccounts.Add(strPublicStaffDebtorsAccount)
        arrControlAccounts.Add(strPublicCreditorsAccount)
        arrControlAccounts.Add(strPublicPurchasesAccount)
        arrControlAccounts.Add(strPublicCashControlAccount)
        arrControlAccounts.Add(strPublicTaxesAccount)
        arrControlAccounts.Add(strPublicCostOfSales)
        arrControlAccounts.Add(strPublicInterCompanyControlAccount)
        arrControlAccounts.Add(strPublicLaschPremiumsControlAccount)

        For i As Integer = 0 To arrControlAccounts.Count - 1
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE " _
                & "AccountNumber = '" & arrControlAccounts.Item(i) & "' AND " _
                & "TransactionDate < '" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "'", cnn)
            objCommand.ExecuteNonQuery()
        Next

        '*** POST TO PROFIT AND LOSS ACCOUNT ***

        Dim intKey As Long = gwt_comm.SpecialKey()
        Dim strReference As String = Format(DateAdd(DateInterval.Day, 1, EndDate), "ddMMyyyy")

        Dim strSqlOne As String = "INSERT INTO [LedgerTransactions] ([TransactionDate],[AccountNumber],[Amount]," _
            & "[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch],[Reference],[FolioReference]," _
            & "[BranchCode],[DepartmentCode],[ReceiptNumber],[InvoiceNumber],[DebitNoteNumber],[CreditNoteNumber]," _
            & "[CostCode],[JournalNumber],[LinkedProject],[SpecialKey]) VALUES " _
            & "('" & shortMonthDateFormat(DateAdd(DateInterval.Day, 1, EndDate)) & "', " _
            & "'" & strPublicReservesControlAccount & "', " & dblProfit & ", 'CREDIT','000000','YEAR END CLEAR DOWN'," _
            & "'" & strUserName & "','" & strUserBranch & "','" & strReference & "','0000',0,0,0,0,0,0,0,0,0," & intKey & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSqlOne, cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default

        MessageBox.Show("Year end clear down completed successfully!!", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Year End Clear Down Process Run Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmFinancialYearEndClearDown_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 496 : Me.Height = 316
    End Sub

End Class
