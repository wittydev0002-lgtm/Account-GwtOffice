Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.Drawing

Public Class frmSalesDailyPostings

    Private Sub frmSalesDailyPostings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        dGrid.Rows.Clear()

        lblSalesLessVat.Text = "0.00" : lblVat.Text = "0.00" : lblTotalSales.Text = "0.00"
        lblExpenses.Text = "0.00" : lblPostedSales.Text = "0.00" : lblAmountDue.Text = "0.00"
        lblCashedIn.Text = "0.00" : lblVariance.Text = "0.00"

        If UCase(strTaxComputationType) = "INCLUSIVE" Then
            strSql = "SELECT  SalesMain.UserName, SUM(SalesMain.Amount) AS [Amount], SUM(Taxes) FROM SalesMain WHERE " _
                & "TransDate = '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "' " _
                & "GROUP BY SalesMain.UserName ORDER BY SalesMain.UserName"
        Else
            strSql = "SELECT SalesMain.UserName, SUM(SalesMain.Amount + SalesMain.Taxes) AS [Amount], SUM(Taxes) FROM SalesMain WHERE " _
                & "TransDate = '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "' " _
                & "GROUP BY SalesMain.UserName ORDER BY SalesMain.UserName"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            With dGrid
                Dim strOperator As String = Nothing
                If Not IsDBNull(objReader(0).ToString) Then strOperator = UCase(objReader(0).ToString)
                .Rows.Add(strOperator, objReader(1), objReader(2))
            End With
        End While
        objReader.Close()

        'Get the customer settlements
        Dim dblCustomers As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "") Then
                Dim strUname As String = dGrid.Rows(i).Cells(0).Value.ToString
                objCommand = New Data.OleDb.OleDbCommand("SELECT SUM([Amount]) FROM CustomerTransactions WHERE " _
                    & "[TransactionType] = 'PAYMENT' AND [UserName] = '" & strUname & "' AND " _
                    & "[TransactionDate] = '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "'", cnn)
                objReader = objCommand.ExecuteReader()
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then dblCustomers = CDbl(objReader(0).ToString)
                End If
                objReader.Close()
                'Get the laybye payments
                objCommand = New Data.OleDb.OleDbCommand("SELECT SUM([Amount]) FROM LaybyTransactions WHERE " _
                    & "[TransType] = 'PAYMENT' AND [UserName] = '" & strUname & "' AND " _
                    & "[TransDate] = '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "'", cnn)
                objReader = objCommand.ExecuteReader()
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then dblCustomers = dblCustomers + CDbl(objReader(0).ToString)
                End If
                objReader.Close()
                dGrid.Rows(i).Cells(3).Value = Format(dblCustomers, "##0.00")
            End If
        Next


        'Get the daily expenses
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "") Then
                Dim strUname As String = dGrid.Rows(i).Cells(0).Value.ToString
                strSql = "SELECT CashbookTransactions.UserName, SUM(CashbookTransactions.Amount) FROM CashbookTransactions " _
                    & "WHERE TransactionType = 'CREDIT' AND CashbookTransactions.UserName = '" & strUname & "' AND " _
                    & "CashbookTransactions.TransactionDate = '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "' GROUP BY CashbookTransactions.UserName"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objReader = objCommand.ExecuteReader
                Dim dblExpense As Double = 0
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(1).ToString) Then dblExpense = CDbl(objReader(1).ToString)
                End If
                objReader.Close()
                dGrid.Rows(i).Cells(4).Value = Format((0 - dblExpense), "##0.00")
            End If
        Next


        'Get the sum of amounts posted to date
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "") Then
                Dim strUname As String = dGrid.Rows(i).Cells(0).Value.ToString
                strSql = "SELECT DailySalesPostings.TillOperator, SUM(DailySalesPostings.SalesAmount) FROM DailySalesPostings " _
                    & "WHERE DailySalesPostings.TillOperator = '" & strUname & "' AND DailySalesPostings.TransDate = " _
                    & "'" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "' GROUP BY DailySalesPostings.TillOperator"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objReader = objCommand.ExecuteReader
                Dim dblCashings As Double = 0
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(1).ToString) Then dblCashings = CDbl(objReader(1).ToString)
                End If
                objReader.Close()
                dGrid.Rows(i).Cells(5).Value = Format((0 - dblCashings), "##0.00")
            End If
        Next

        'Compute the net cash on hand
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblPostedToDate As Double = 0
            Dim dblAmount As Double = 0
            Dim dblTaxAmt As Double = 0
            Dim dblExpenseAmt As Double = 0
            Dim dblCustomersTotal As Double = 0
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(1).Value.ToString) Then
                    dblAmount = CDbl(dGrid.Rows(i).Cells(1).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    dblTaxAmt = CDbl(dGrid.Rows(i).Cells(2).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    dblCustomersTotal = CDbl(dGrid.Rows(i).Cells(3).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                    dblExpenseAmt = CDbl(dGrid.Rows(i).Cells(4).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                    dblPostedToDate = CDbl(dGrid.Rows(i).Cells(5).Value.ToString)
                End If
            End If
            Dim dblCashOnHand As Double = (dblAmount + dblTaxAmt + dblCustomersTotal) + (dblExpenseAmt + dblPostedToDate)
            dGrid.Rows(i).Cells(6).Value = Format(dblCashOnHand, "##0.00")
        Next

        'Compute the variances
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1
                Dim dblAmountDue As Double = 0
                Dim dblCashed As Double = 0
                If IsNumeric(.Rows(i).Cells(6).Value) Then
                    dblAmountDue = CDbl(.Rows(i).Cells(6).Value.ToString)
                End If
                If IsNumeric(.Rows(i).Cells(7).Value) Then
                    dblCashed = CDbl(.Rows(i).Cells(7).Value.ToString)
                End If
                ComputeValues(dblAmountDue, dblCashed, i)
            Next
        End With
        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Encountered error while trying to load sales for a given period"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPostTransactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPostTransactions.Click
        On Error GoTo RaiseErr
        If strPublicDirectCashbbookSalesPosting = "YES" Then
            MessageBox.Show("This company is not set to post transactions in this way." & vbCrLf & _
                "You can llow posting such transactions from organisation setup", "Process Not Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Check that the amount due is greater than 0

        Dim dblTotalTaking As Double = 0
        Dim dblDailyTaxes As Double = 0
        Dim dblAccountPayments As Double = 0
        Dim dblAmountDue As Double = 0

        With dGrid
            For i As Integer = 0 To .Rows.Count - 1
                Dim dblSalesAmount As Double = 0
                Dim dblTaxesAmount As Double = 0
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(1).Value.ToString) Then
                        dblSalesAmount = CDbl(.Rows(i).Cells(1).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(3).Value.ToString) Then
                        dblAccountPayments = dblAccountPayments + CDbl(.Rows(i).Cells(3).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(2).Value.ToString) Then
                        dblTaxesAmount = CDbl(.Rows(i).Cells(2).Value.ToString)
                        dblDailyTaxes = dblDailyTaxes + dblTaxesAmount
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(6).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(6).Value.ToString) Then
                        dblAmountDue = dblAmountDue + CDbl(.Rows(i).Cells(6).Value.ToString)
                    End If
                End If
                dblTotalTaking = dblTotalTaking + (dblSalesAmount + dblTaxesAmount + 0)
            Next
        End With

        If dblAmountDue = 0 Then
            MessageBox.Show("Transaction cannot be processed. Amount due from sales is zero", "Process Aborted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Cashbook postings
        boolAbort = False
        gwt_comm.CashbookSelection()
        'Dim f As New frmCashbookSelection
        'f.ShowDialog()
        If boolAbort = True Then Exit Sub

        Dim intSpecialKey As Integer = gwt_comm.SpecialKey()
        Dim intRef As Long = DateDiff(DateInterval.Day, CDate("01-JAN-1900"), CDate(gwt_comm.shortMonthDateFormat(Now)))

        Dim strCashbookDescription As String = "DAILY CASH SALES TOTAL"
        Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, " _
            & "TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, " _
            & "TransactionType, Reference, SpecialKey) VALUES " _
            & "('" & strPublicActiveCashbook & "', '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "', " _
            & "" & dblTotalTaking - CDbl(lblVariance.Text) & ", '" & strCashbookDescription & "', " _
            & "'" & strPublicSalesAccount & "', '" & strUserName & "', '" & strUserBranch & "', " _
            & "'DEBIT', " & intRef & ", " & intSpecialKey & ")", cnn)
        objCommand.ExecuteNonQuery()

        'Insert the account payments seperately
        strCashbookDescription = "DAILY ACCOUNTS PAYMENT TOTALS"
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, " _
            & "TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, " _
            & "TransactionType, Reference, SpecialKey) VALUES " _
            & "('" & strPublicActiveCashbook & "', '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "', " _
            & "" & dblAccountPayments & ", '" & strCashbookDescription & "', " _
            & "'" & strPublicDebtorsAccount & "', '" & strUserName & "', '" & strUserBranch & "', " _
            & "'DEBIT', " & intRef & ", " & intSpecialKey & ")", cnn)
        objCommand.ExecuteNonQuery()

        'Post the transactions to the general ledger
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                    & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                    & "('" & strPublicSalesAccount & "', '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "', " & dblTotalTaking - dblDailyTaxes & ", " _
                    & "'CREDIT', '" & strPublicActiveCashbook & "', '" & strCashbookDescription & "', " _
                    & "'" & strUserName & "', '" & strUserBranch & "', " & intRef & ", " & intSpecialKey & ")", cnn)
        objCommand.ExecuteNonQuery()

        'Post the taxes to the taxes control account
        If String.IsNullOrEmpty(strPublicTaxesAccount) Then
            MessageBox.Show("The taxes control account has not been setup. This will serious affect the trial balance", _
                "Taxes Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim strTransactionProcessStatus As String = gwt_comm.LedgerEntry("INSERT", gwt_comm.shortMonthDateFormat(dpProcessDate.Value), strPublicTaxesAccount,
                strPublicActiveCashbook, strCashbookDescription & "-TOTAL VAT COLLECTED", dblDailyTaxes, "CREDIT",
                intRef, , , , intRef, 0, 0, 0, intSpecialKey)
            If strTransactionProcessStatus <> "SUCCESS" Then GoTo RaiseErr
        End If

        'Post the transactions to the Daily sales takings
        With dGrid
            For i As Integer = 0 To dGrid.Rows.Count - 1

                Dim strOperator As String = Nothing
                Dim dblSalesAmount As Double = 0
                Dim dblAmountCashed As Double = 0
                Dim dblVariance As Double = 0

                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "") Then
                    strOperator = .Rows(i).Cells(0).Value.ToString
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(6).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(6).Value.ToString) Then
                        dblSalesAmount = CDbl(.Rows(i).Cells(6).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(7).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(7).Value.ToString) Then
                        dblAmountCashed = CDbl(.Rows(i).Cells(7).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(8).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(8).Value.ToString) Then
                        dblVariance = CDbl(.Rows(i).Cells(8).Value.ToString)
                    End If
                End If
                Dim strSql As String = "INSERT INTO DailySalesPostings ([TillOperator], [SalesAmount], [CashedAmount], " _
                    & "[Variance], [TransDate], [PostedBy], [SpecialKey]) VALUES ('" & strOperator & "', " _
                    & "" & dblSalesAmount & ", " & dblAmountCashed & ", " & dblVariance & ", " _
                    & "'" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "', '" & strUserName & "', " & intSpecialKey & ")"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                'Post to the staff debtors account if amount shotfalls greater than 0
                If dblVariance <> 0 Then
                    If Not String.IsNullOrEmpty(strPublicStaffDebtorsAccount) Then
                        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                            & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                            & "('" & strPublicStaffDebtorsAccount & "', '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "', " & dblVariance & ", " _
                            & "'DEBIT', '" & strPublicActiveCashbook & "', '" & UCase(strOperator) & "-POS SHORTFALL-" & UCase(gwt_comm.shortMonthDateFormat(dpProcessDate.Value)) & "', " _
                            & "'" & strUserName & "', '" & strUserBranch & "', " & intRef & ", " & intSpecialKey & ")", cnn)
                        objCommand.ExecuteNonQuery()
                    Else
                        MessageBox.Show("The system has detected that you have not set the staff debtors control account" & vbCrLf & _
                            "This will seriously affect the ledger account and trial balance", "Missing Special Staff Debtors Control Account", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

            Next
        End With
        LoadData()
        MessageBox.Show("Transactions processed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Encountered error while trying to process daily cashings"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellValidated
        If dGrid.CurrentCell.ColumnIndex = 7 Then
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(7).Value), "")) Then
                If Not IsNumeric(dGrid.CurrentCell.Value) Then
                    MessageBox.Show("Invalid Non Numeric Value Detected. Cell value defaulted to 0", _
                        "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGrid.CurrentCell.Value = "0"
                    ComputeValues(CDbl(dGrid.CurrentRow.Cells(6).Value.ToString), CDbl(dGrid.CurrentCell.Value.ToString), dGrid.CurrentRow.Index)
                    Exit Sub
                Else
                    ComputeValues(CDbl(dGrid.CurrentRow.Cells(6).Value.ToString), CDbl(dGrid.CurrentCell.Value.ToString), dGrid.CurrentRow.Index)
                End If
            End If
        End If
    End Sub

    Private Sub ComputeValues(ByVal AmountDue As Double, ByVal AmountCashed As Double, ByVal intRowIndex As Integer)
        Dim dblTaxes As Double = 0
        Dim dblSubTotal As Double = 0
        Dim dblPayable As Double = 0
        dGrid.Rows(intRowIndex).Cells(8).Value = Format((AmountDue - AmountCashed), "##0.00")
        ComputeTotals()
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex >= 3 And e.ColumnIndex <= 8 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
            ComputeTotals()
        End If
    End Sub

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
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

    Private Sub ComputeTotals()

        'Sales No Tax, Vat, Expenses, Posted Sales, Sales Due, Amt In, ShortFalls

        If dGrid.Rows.Count = 0 Then Exit Sub

        Dim dblSalesNoTax As Double = 0
        Dim dblVat As Double = 0
        Dim dblExpenses As Double = 0
        Dim dblPostedSales As Double = 0
        Dim dblSalesDue As Double = 0
        Dim dblAmountCashed As Double = 0
        Dim dblShortfalls As Double = 0
        Dim dblCustomerTotals As Double = 0

        With dGrid
            For i As Double = 0 To .Rows.Count - 1

                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(1).Value.ToString) Then
                        dblSalesNoTax = dblSalesNoTax + CDbl(.Rows(i).Cells(1).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(2).Value.ToString) Then
                        dblVat = dblVat + CDbl(.Rows(i).Cells(2).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(3).Value.ToString) Then
                        dblCustomerTotals = dblCustomerTotals + CDbl(.Rows(i).Cells(3).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(4).Value.ToString) Then
                        dblExpenses = dblExpenses + CDbl(.Rows(i).Cells(4).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(5).Value.ToString) Then
                        dblPostedSales = dblPostedSales + CDbl(.Rows(i).Cells(5).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(6).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(6).Value.ToString) Then
                        dblSalesDue = dblSalesDue + CDbl(.Rows(i).Cells(6).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(7).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(7).Value.ToString) Then
                        dblAmountCashed = dblAmountCashed + CDbl(.Rows(i).Cells(7).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(8).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(8).Value.ToString) Then
                        dblShortfalls = dblShortfalls + CDbl(.Rows(i).Cells(8).Value.ToString)
                    End If
                End If
            Next
        End With

        lblSalesLessVat.Text = Format(dblSalesNoTax, "#,##0.00")
        lblVat.Text = Format(dblVat, "#,##0.00")
        lblTotalSales.Text = Format((dblSalesNoTax + dblVat + dblCustomerTotals), "##0.00")
        lblExpenses.Text = Format(dblExpenses, "#,##0.00")
        lblPostedSales.Text = Format(dblPostedSales, "#,##0.00")
        lblAmountDue.Text = Format(dblSalesDue, "#,##0.00")
        lblCashedIn.Text = Format(dblAmountCashed, "#,##0.00")
        lblVariance.Text = Format(dblShortfalls, "#,##0.00")

    End Sub

    Private Sub dpProcessDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpProcessDate.ValueChanged
        LoadData()
    End Sub

    Private Sub btnPrintSalesSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintSalesSheet.Click
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        If UCase(strTaxComputationType) = "INCLUSIVE" Then
            strSql = "SELECT InventoryItems.GroupName, Sales.SalesPrice, Sales.Quantity, " _
                & "Sales.DiscountAllowed, Sales.Taxes, Sales.SerialNumbers, (((Sales.SalesPrice * Sales.Quantity) - DiscountAllowed) - 0) AS [Paid], " _
                & "InventoryItems.Category FROM Sales " _
                & "LEFT JOIN InventoryItems ON Sales.ItemCode = InventoryItems.ItemCode " _
                & "WHERE Sales.TransDate = '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "' ORDER BY InventoryItems.Category, Sales.ItemCode"
        Else
            strSql = "SELECT InventoryItems.GroupName, Sales.SalesPrice, Sales.Quantity, " _
                & "Sales.DiscountAllowed, Sales.Taxes, Sales.SerialNumbers, (((Sales.SalesPrice * Sales.Quantity) - DiscountAllowed) + Sales.Taxes) AS [Paid], " _
                & "InventoryItems.Category FROM Sales " _
                & "LEFT JOIN InventoryItems ON Sales.ItemCode = InventoryItems.ItemCode " _
                & "WHERE Sales.TransDate = '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "' ORDER BY InventoryItems.Category, Sales.ItemCode"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrPrintData As New ArrayList
        While objReader.Read
            Dim strItemName As String = Nothing
            Dim strUnitPrice As String = "0.00"
            Dim strQuantity As String = "1.00"
            Dim strDiscount As String = "0.00"
            Dim strTaxes As String = "0.00"
            Dim strSerial As String = Nothing
            Dim strAmtPaid As String = "0.00"
            Dim strCategory As String = Nothing
            If Not IsDBNull(objReader(0).ToString) Then strItemName = UCase(objReader(0).ToString)
            If IsNumeric(objReader(1).ToString) Then strUnitPrice = Format(CDbl(objReader(1).ToString), "##0.00")
            If IsNumeric(objReader(2).ToString) Then strQuantity = Format(CDbl(objReader(2).ToString), "##0.00")
            If IsNumeric(objReader(3).ToString) Then strDiscount = Format(CDbl(objReader(3).ToString), "##0.00")
            If IsNumeric(objReader(4).ToString) Then strTaxes = Format(CDbl(objReader(4).ToString), "##0.00")
            If Not IsDBNull(objReader(5).ToString) Then strSerial = UCase(objReader(5).ToString)
            If IsNumeric(objReader(6).ToString) Then strAmtPaid = Format(CDbl(objReader(6).ToString), "##0.00")
            If Not IsDBNull(objReader(7).ToString) Then strCategory = UCase(objReader(7).ToString)
            arrPrintData.Add(strItemName & ";" & strUnitPrice & ";" & strQuantity & ";" & strDiscount & ";" & _
                strTaxes & ";" & strSerial & ";" & strAmtPaid & ";" & strCategory)
        End While
        objReader.Close()

        'Get the laybye payments for that day
        arrPrintData.Add("ADD LAYBYE PAYMENTS; ; ; ; ; ; ;LAYBYES")
        objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, LaybyCustomers.AccountName) +'-'+ CONVERT(NVARCHAR, " _
            & "LaybyTransactions.AccountNumber) +';0;0;0;0;'+ CONVERT(NVARCHAR, LaybyTransactions.DocumentNumber) +';'+ " _
            & "CONVERT(NVARCHAR, CAST(SUM(LaybyTransactions.Amount) AS DECIMAL (10,2))) +';LAYBYES' AS [LineDetail] FROM LaybyTransactions " _
            & "LEFT OUTER JOIN LaybyCustomers ON LaybyCustomers.AccountNumber = LaybyTransactions.AccountNumber " _
            & "WHERE TransDate = '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "' AND TransType = 'PAYMENT' " _
            & " GROUP BY LaybyTransactions.AccountNumber, LaybyCustomers.AccountName, LaybyTransactions.DocumentNumber", cnn)
        objReader = objCommand.ExecuteReader()
        While objReader.Read
            arrPrintData.Add(objReader(0))
        End While
        objReader.Close()

        'Get the customer payments for that day
        arrPrintData.Add("ADD CUSTOMER ACCOUNT PAYMENTS; ; ; ; ; ; ;ACCOUNT PAYMENTS")
        objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, Customers.AccountName) +'-'+ " _
            & "CONVERT(NVARCHAR, CustomerTransactions.AccountNumber) +';0;0;0;0;'+ " _
            & "CONVERT(NVARCHAR, CustomerTransactions.ReferenceNumber) +';'+ " _
            & "CONVERT(NVARCHAR, CAST(SUM(CustomerTransactions.Amount) AS DECIMAL (10,2))) +';" _
            & "ACCOUNT PAYMENTS' AS [LineDetail] FROM CustomerTransactions LEFT OUTER JOIN Customers ON " _
            & "Customers.AccountNumber = CustomerTransactions.AccountNumber WHERE TransactionDate = '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "' " _
            & "AND TransactionType = 'PAYMENT' GROUP BY CustomerTransactions.AccountNumber, " _
            & "Customers.AccountName, CustomerTransactions.ReferenceNumber", cnn)
        objReader = objCommand.ExecuteReader()
        While objReader.Read
            arrPrintData.Add(objReader(0))
        End While
        objReader.Close()

        'Get the expenses for that day
        arrPrintData.Add("LESS EXPENSES; ; ; ; ; ; ;EXPENSES")
        strSql = "SELECT  (CashbookTransactions.Description +';0;0;0;0;'+ CashbookTransactions.ContraAccount +';'+ " _
            & "CONVERT(NVARCHAR, CAST((0 - CashbookTransactions.Amount) AS DECIMAL (10,2)))) +';EXPENSES' AS [ExpenseDetails] " _
            & "FROM CashbookTransactions WHERE TransactionType = 'CREDIT' AND TransactionDate = '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader()
        While objReader.Read
            arrPrintData.Add(objReader(0))
        End While
        objReader.Close()

        If arrPrintData.Count <= 0 Then
            MessageBox.Show("There are no items to print", "No Print Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Send the information to the printing class
        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 8
            .strColumnHeaders = "ITEM|UNIT PRICE|QTY|DISCOUNTS|TAXES|SERIAL/REC #|RECEIVED|"
            .strColumnAlignments = "0|2|2|2|2|0|2|0"
            .strColumnWidths = "200|80|50|80|60|100|80|0"
            .strFooterCaption = "Daily Sales Cashout"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "DAILY SALES SHEET : " & UCase(gwt_comm.shortMonthDateFormat(dpProcessDate.Value))
            .strMainHeader3 = UCase(strUserBranch)
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|YES|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = True
            .boolPrintTotals = True
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|YES|NO"
            .intKeyFieldIndex = 7
            .strPrintValues = strPrintDetails
        End With

        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()
        boolAbort = False
        gwt_comm.PrinterSelection()
        'Dim f As New frmPrinterSetup
        'f.ShowDialog()
        If boolAbort = True Then Exit Sub
        rpt.PrinterSettings.PrinterName = strSessionPrinter
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Encountered error while trying to print daily sales report"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function CellDetails(OperatorName As String) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList
        Dim strSql As String = "SELECT Description, TransactionType, " _
            & "CAST(Amount AS DECIMAL (10,2)) AS [Amt] FROM LedgerTransactions WHERE " _
            & "TransactionDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "' AND " _
            & "'" & gwt_comm.shortMonthDateFormat(dpProcessDate.Value) & "' AND UserName = '" & OperatorName & "' AND CostCode <> '0'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strDescription As String = Nothing
            Dim strType As String = Nothing
            Dim strAmount As String = "0.00"
            If Not IsDBNull(objReader(0).ToString) Then strDescription = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strType = objReader(1).ToString
            If IsNumeric(objReader(2).ToString) Then strAmount = Format(CDbl(objReader(2).ToString), "##0.00")
            arrReturn.Add(strDescription & "|" & strType & "|" & strAmount)
        End While
        objReader.Close()
        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Encountered error while trying to display cell details"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub ShowDetails()
        If dGrid.Rows.Count <= 0 Then Exit Sub
        boolAbort = False
        Dim arrDetailsToShow As New ArrayList
        Dim strOperator As String = dGrid.CurrentRow.Cells(0).Value.ToString
        arrDetailsToShow = CellDetails(strOperator)
        If boolAbort = True Then Exit Sub
        Dim dblTotal As Double = 0
        dGridDetails.Rows.Clear()
        For i As Integer = 0 To arrDetailsToShow.Count - 1
            Dim strBuffer() As String = Split(arrDetailsToShow.Item(i), "|")
            If IsNumeric(strBuffer(2)) Then dblTotal = dblTotal + CDbl(strBuffer(2))
            dGridDetails.Rows.Add(strBuffer(0), strBuffer(1), strBuffer(2))
        Next
        'Add the totals row at end
        dGridDetails.Rows.Add("TOTAL", " ", Format(dblTotal, "##0.00"))
        pnlDetails.Visible = True
    End Sub

    Private Sub btnCloseTip_Click(sender As System.Object, e As System.EventArgs) Handles btnCloseTip.Click
        pnlDetails.Visible = False
    End Sub

    Private Sub mnuExpenseDetails_Click(sender As System.Object, e As System.EventArgs) Handles mnuExpenseDetails.Click
        ShowDetails()
    End Sub

End Class
