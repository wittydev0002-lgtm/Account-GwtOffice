Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCashbookTransactions

    Dim boolFormLoading As Boolean

    Private Sub btnEntries_Click(sender As System.Object, e As System.EventArgs) Handles btnIncomes.Click
        'boolAbort = False
        'gwt_comm.CashbookSelection()
        'If boolAbort = True Then Exit Sub
        'Dim frm As New frmCashbookIncomes
        'frm.ShowDialog()
    End Sub

    Private Sub LoadCashBooks()
        On Error GoTo RaiseErr
        Dim objcommand As New Data.OleDb.OleDbCommand("SELECT AccountName +';'+ AccountNumber FROM Cashbooks ORDER BY AccountName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objcommand.ExecuteReader
        Dim arrItems As New ArrayList

        'Set up the drop down combo box
        With cboCashbook
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

        arrItems.Add("--ALL--;0")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                arrItems.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        Dim intItemsCount As Integer = arrItems.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboCashbook.Items.Clear()

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        If intItemsCount > 0 Then
            cboCashbook.SelectedIndex = -1
            cboCashbook.Items.Clear()
            cboCashbook.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCashbook.Items.AddRange(DropDownItems)
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Cashbooks Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        ViewAllTransactions(gwt_comm.shortMonthDateFormat(dpStartDate.Value), gwt_comm.shortMonthDateFormat(dpEndDate.Value), lblCashbook.Text)
    End Sub

    Private Sub ViewAllTransactions(StartingDate As Date, EndingDate As Date, Cashbook As String)
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
        With gwt_comm
            'Open the database
            If .CheckTableExistence("TempCb") = True Then
                objCommand = New Data.OleDb.OleDbCommand("DROP TABLE TempCb", cnn)
                objCommand.ExecuteNonQuery()
            End If
        End With

        ''Drop and create temp cashbook
        'strSql = "CREATE TABLE TempCb ([TransDate][SmallDateTime] NOT NULL, [Description][NVARCHAR](150) NOT NULL DEFAULT '', " _
        '    & "[ContraAccount][NVARCHAR](35) NOT NULL, [AccountName][NVARCHAR](150) NULL DEFAULT '', " _
        '    & "[CostCenter][INT] NULL DEFAULT 0, [CostCenterName][NVARCHAR](250) NULL DEFAULT '', " _
        '    & "[Reference][NVARCHAR](35) NULL DEFAULT '', [Debit][FLOAT] NULL DEFAULT 0, [Credit][FLOAT] NULL DEFAULT 0, " _
        '    & "[SpecialKey][INT] NOT NULL DEFAULT 0, [TransactionId][INT] NOT NULL DEFAULT 0)"
        'objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        'objCommand.ExecuteNonQuery()

        ''Select first the debits and insert into the table
        'Dim strSqlDebits As String = Nothing
        'Dim strSqlCredits As String = Nothing

        If Cashbook = "0" Then

            strSql = "SELECT MIN(CashbookTransactions.TransactionId) AS [ID], CashbookTransactions.TransactionDate as [TransactionDate], CashbookTransactions.Description, " _
                & "CashbookTransactions.UserReference AS [Reference], CashbookTransactions.SpecialKey, " _
                & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName AS [AccountName], " _
                & "CashbookTransactions.CostCode AS [Center], SystemCostCenters.CostCenterName AS [CostCenterName], " _
                & "SUM(CASE WHEN CashbookTransactions.TransactionType = 'DEBIT' THEN CashbookTransactions.Amount END) AS [Debit], " _
                & "SUM(CASE WHEN CashbookTransactions.TransactionType = 'CREDIT' THEN CashbookTransactions.Amount END) AS [Credit] " _
                & "INTO TempCb FROM CashbookTransactions " _
                & "LEFT OUTER JOIN LedgerAccounts ON CashbookTransactions.ContraAccount = LedgerAccounts.AccountNumber " _
                & "LEFT OUTER JOIN SystemCostCenters ON CashbookTransactions.CostCode = SystemCostCenters.OrdinalNo " _
                & "WHERE TransactionDate BETWEEN '" & gwt_comm.shortMonthDateFormat(StartingDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndingDate) & "' " _
                & "GROUP BY CashbookTransactions.TransactionDate, CashbookTransactions.Description, CashbookTransactions.TransactionId, " _
                & "CashbookTransactions.UserReference, CashbookTransactions.SpecialKey, CashbookTransactions.ContraAccount, " _
                & "LedgerAccounts.AccountName, CashbookTransactions.CostCode, SystemCostCenters.CostCenterName " _
                & "ORDER BY CashbookTransactions.TransactionDate, CashbookTransactions.TransactionId"

            'strSqlDebits = "INSERT INTO TempCb " _
            '    & "(TransDate, Description, ContraAccount, AccountName, CostCenter, CostCenterName, Reference, Debit, SpecialKey, TransactionId) " _
            '    & "SELECT CashbookTransactions.TransactionDate, CashbookTransactions.Description, " _
            '    & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName, " _
            '    & "CashbookTransactions.CostCode, SystemCostCenters.CostCenterName, " _
            '    & "CashbookTransactions.UserReference, CashbookTransactions.Amount, SpecialKey, TransactionId FROM CashbookTransactions " _
            '    & "LEFT OUTER JOIN LedgerAccounts ON CashbookTransactions.ContraAccount = LedgerAccounts.AccountNumber " _
            '    & "LEFT OUTER JOIN SystemCostCenters ON CashbookTransactions.CostCode = SystemCostCenters.OrdinalNo " _
            '    & "WHERE CashbookTransactions.TransactionType = 'DEBIT' AND CashbookTransactions.TransactionDate " _
            '    & "BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND '" & Format(EndingDate, "dd-MMM-yyyy") & "'"

            'strSqlCredits = "INSERT INTO TempCb " _
            '    & "(TransDate, Description, ContraAccount, AccountName, CostCenter, CostCenterName, Reference, Credit, SpecialKey, TransactionId) " _
            '    & "SELECT CashbookTransactions.TransactionDate, CashbookTransactions.Description, " _
            '    & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName, " _
            '    & "CashbookTransactions.CostCode, SystemCostCenters.CostCenterName, " _
            '    & "CashbookTransactions.UserReference, CashbookTransactions.Amount, SpecialKey, TransactionId FROM CashbookTransactions " _
            '    & "LEFT OUTER JOIN LedgerAccounts ON CashbookTransactions.ContraAccount = LedgerAccounts.AccountNumber " _
            '    & "LEFT OUTER JOIN SystemCostCenters ON CashbookTransactions.CostCode = SystemCostCenters.OrdinalNo " _
            '    & "WHERE CashbookTransactions.TransactionType = 'CREDIT' AND CashbookTransactions.TransactionDate " _
            '    & "BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND '" & Format(EndingDate, "dd-MMM-yyyy") & "'"
        Else

            strSql = "SELECT MIN(CashbookTransactions.TransactionId) AS [ID], CashbookTransactions.TransactionDate as [TransactionDate], CashbookTransactions.Description, " _
                & "CashbookTransactions.UserReference AS [Reference], CashbookTransactions.SpecialKey, " _
                & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName AS [AccountName], " _
                & "CashbookTransactions.CostCode AS [Center], SystemCostCenters.CostCenterName AS [CostCenterName], " _
                & "SUM(CASE WHEN CashbookTransactions.TransactionType = 'DEBIT' THEN CashbookTransactions.Amount END) AS [Debit], " _
                & "SUM(CASE WHEN CashbookTransactions.TransactionType = 'CREDIT' THEN CashbookTransactions.Amount END) AS [Credit] " _
                & "INTO TempCb FROM CashbookTransactions " _
                & "LEFT OUTER JOIN LedgerAccounts ON CashbookTransactions.ContraAccount = LedgerAccounts.AccountNumber " _
                & "LEFT OUTER JOIN SystemCostCenters ON CashbookTransactions.CostCode = SystemCostCenters.OrdinalNo " _
                & "WHERE TransactionDate BETWEEN '" & gwt_comm.shortMonthDateFormat(StartingDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndingDate) & "' " _
                & "AND CashbookTransactions.AccountNumber = '" & Cashbook & "' " _
                & "GROUP BY CashbookTransactions.TransactionDate, CashbookTransactions.Description, CashbookTransactions.TransactionId, " _
                & "CashbookTransactions.UserReference, CashbookTransactions.SpecialKey, CashbookTransactions.ContraAccount, " _
                & "LedgerAccounts.AccountName, CashbookTransactions.CostCode, SystemCostCenters.CostCenterName " _
                & "ORDER BY CashbookTransactions.TransactionDate, CashbookTransactions.TransactionId"

            'strSqlDebits = "INSERT INTO TempCb " _
            '    & "(TransDate, Description, ContraAccount, AccountName, CostCenter, CostCenterName, Reference, Debit, SpecialKey, TransactionId) " _
            '    & "SELECT CashbookTransactions.TransactionDate, CashbookTransactions.Description, " _
            '    & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName, " _
            '    & "CashbookTransactions.CostCode, SystemCostCenters.CostCenterName, " _
            '    & "CashbookTransactions.UserReference, CashbookTransactions.Amount, SpecialKey, TransactionId FROM CashbookTransactions " _
            '    & "LEFT OUTER JOIN LedgerAccounts ON CashbookTransactions.ContraAccount = LedgerAccounts.AccountNumber " _
            '    & "LEFT OUTER JOIN SystemCostCenters ON CashbookTransactions.CostCode = SystemCostCenters.OrdinalNo " _
            '    & "WHERE CashbookTransactions.TransactionType = 'DEBIT' AND CashbookTransactions.TransactionDate " _
            '    & "BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND '" & Format(EndingDate, "dd-MMM-yyyy") & "' " _
            '    & "AND CashbookTransactions.AccountNumber = '" & Cashbook & "'"

            'strSqlCredits = "INSERT INTO TempCb " _
            '    & "(TransDate, Description, ContraAccount, AccountName, CostCenter, CostCenterName, Reference, Credit, SpecialKey, TransactionId) " _
            '    & "SELECT CashbookTransactions.TransactionDate, CashbookTransactions.Description, " _
            '    & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName, " _
            '    & "CashbookTransactions.CostCode, SystemCostCenters.CostCenterName, " _
            '    & "CashbookTransactions.UserReference, CashbookTransactions.Amount, SpecialKey, TransactionId FROM CashbookTransactions " _
            '    & "LEFT OUTER JOIN LedgerAccounts ON CashbookTransactions.ContraAccount = LedgerAccounts.AccountNumber " _
            '    & "LEFT OUTER JOIN SystemCostCenters ON CashbookTransactions.CostCode = SystemCostCenters.OrdinalNo " _
            '    & "WHERE CashbookTransactions.TransactionType = 'CREDIT' AND CashbookTransactions.TransactionDate " _
            '    & "BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND '" & Format(EndingDate, "dd-MMM-yyyy") & "' " _
            '    & "AND CashbookTransactions.AccountNumber = '" & Cashbook & "'"
        End If

        'objCommand = New Data.OleDb.OleDbCommand(strSqlDebits, cnn)
        'objCommand.ExecuteNonQuery()
        'objCommand = New Data.OleDb.OleDbCommand(strSqlCredits, cnn)
        'objCommand.ExecuteNonQuery()

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Remove null values
        strSql = "UPDATE TempCb SET CostCenterName = '' WHERE CostCenterName = NULL"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        strSql = "UPDATE TempCb SET AccountName = '' WHERE AccountName = NULL"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        strSql = "UPDATE TempCb SET Reference = '' WHERE Reference = NULL"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        strSql = "UPDATE TempCb SET Debit = 0 WHERE Debit = NULL"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        strSql = "UPDATE TempCb SET Credit = 0 WHERE Credit = NULL"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Reader and populate the grid through binding
        strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "[Description], [ContraAccount] AS [Contra #], [AccountName] AS [Account Name], [Center] AS [Center], " _
            & "[CostCenterName] AS [Center Name], [Reference] AS [Ref.], CAST(Debit AS DECIMAL(10,2)) AS [Debit], " _
            & "CAST(Credit AS DECIMAL(10,2)) AS [Credit], SpecialKey as [Key], ID AS [ID] FROM TempCb ORDER BY TransactionDate"

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGridAll.Columns.Clear()
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridAll.DataSource = dTable

        Me.dGridAll.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGridAll.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGridAll.Columns.Count - 1
            dGridAll.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            If p = dGridAll.Columns.Count - 1 Then
                dGridAll.Columns(p).Visible = False
            End If
            If p = dGridAll.Columns.Count - 2 Then
                dGridAll.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            If p = dGridAll.Columns.Count - 3 Then
                dGridAll.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            If p = dGridAll.Columns.Count - 4 Then
                dGridAll.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        Dim TextColumn As New DataGridViewTextBoxColumn

        With TextColumn
            .HeaderText = "Balance"
            .Name = "Balance"
        End With
        ' Add the button column to the control.
        dGridAll.Columns.Insert(dGridAll.Columns.Count, TextColumn)

        Dim arrHeads As New ArrayList
        For q As Integer = 0 To dGridAll.ColumnCount - 1
            arrHeads.Add(dGridAll.Columns(q).HeaderText)
        Next

        'Get the balance brought forward
        Dim dblTopBalance As Double = 0
        If lblCashbook.Text = "0" Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT(AccountNumber) FROM CashbookTransactions ORDER BY AccountNumber", cnn)
            objReader = objCommand.ExecuteReader
            Dim dblAllCashbooksBalance As Double = 0
            While objReader.Read
                gwt_comm = New CommonLibrary.Commons.CommonFunctions
                Dim dblBalanceBefore() As Double = gwt_comm.CashbookAccountBalances(shortMonthDateFormat(CDate(dpStartDate.Value)),
                        CDate(gwt_comm.shortMonthDateFormat(DateAdd(DateInterval.Day, -1, dpStartDate.Value))), objReader(0).ToString)
                dblAllCashbooksBalance = dblAllCashbooksBalance + dblBalanceBefore(1)
            End While
            objReader.Close()
            lblBalanceAll.Text = Format(dblAllCashbooksBalance, "##0.00")
            If dblAllCashbooksBalance < 0 Then lblCashbookBfBalanceType.Text = "CR" Else lblCashbookBfBalanceType.Text = "DR"
            dblTopBalance = dblAllCashbooksBalance
        Else
            gwt_comm = New CommonLibrary.Commons.CommonFunctions
            Dim dblBalanceBefore() As Double = gwt_comm.CashbookAccountBalances(CDate(gwt_comm.shortMonthDateFormat(dpStartDate.Value)),
                CDate(gwt_comm.shortMonthDateFormat(DateAdd(DateInterval.Day, -1, dpStartDate.Value))), lblCashbook.Text)
            Dim dblBalanceBroughtDown As Double = dblBalanceBefore(1)
            lblBalanceAll.Text = Format(dblBalanceBroughtDown, "##0.00")
            If dblBalanceBroughtDown < 0 Then lblCashbookBfBalanceType.Text = "CR" Else lblCashbookBfBalanceType.Text = "DR"
            dblTopBalance = dblBalanceBroughtDown
        End If

        'Compute the period movements
        lblCountAll.Text = dGridAll.Rows.Count
        Dim dblTotalDebits As Double = 0
        Dim dblTotalCredits As Double = 0

        strSql = "SELECT CAST(SUM(Debit) AS DECIMAL(10,2)) AS [Debit], " _
            & "CAST(SUM(Credit) AS DECIMAL(10,2)) AS [Credit] FROM TempCb"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblTotalDebits = CDbl(objReader(0).ToString)
            If IsNumeric(objReader(1).ToString) Then dblTotalCredits = CDbl(objReader(1).ToString)
        End If
        objReader.Close()

        lblDebitsAll.Text = Format(dblTotalDebits, "#,##0.00")
        lblCreditsAll.Text = Format(dblTotalCredits, "#,##0.00")
        lblPeriodMovement.Text = Format((dblTotalDebits - dblTotalCredits), "#,##0.00")
        lblBalance.Text = Format((dblTopBalance + (dblTotalDebits - dblTotalCredits)), "#,##0.00")

        Dim dblPastBalance As Double = dblTopBalance
        For p As Integer = 0 To dGridAll.Rows.Count - 1
            Dim dblDebit As Double = 0
            Dim dblCredit As Double = 0
            If Not Object.Equals(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 5).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 5).Value.ToString) Then
                    If IsNumeric(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 5).Value.ToString) Then
                        dblDebit = CDbl(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 5).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 4).Value.ToString) Then
                    If IsNumeric(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 4).Value.ToString) Then
                        dblCredit = CDbl(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 4).Value.ToString)
                    End If
                End If
            End If
            Dim dblLineBalance As Double = (dblDebit - dblCredit) + dblPastBalance
            dblPastBalance = dblLineBalance
            dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 1).Value = Format(dblLineBalance, "##0.00")
        Next
        dGridAll.Columns(dGridAll.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dGridAll.Columns(dGridAll.Columns.Count - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'Add the recon column
        Dim rsColumn As New DataGridViewCheckBoxColumn

        With rsColumn
            .HeaderText = "RS"
            .Name = "Recon"
            .Width = 30
        End With

        For p As Integer = 0 To dGridAll.Columns.Count - 1
            If p = dGridAll.Columns.Count - 1 Then
                dGridAll.Columns(p).ReadOnly = False
            Else
                dGridAll.Columns(p).ReadOnly = True
            End If
        Next

        ' Add the button column to the control.
        dGridAll.Columns.Insert(dGridAll.Columns.Count, rsColumn)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Cashbook Transactions View All"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs)
        If dGridAll.Rows.Count <= 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        gwt_comm.PrintCashbookTransactions(lblCashbook.Text, dpStartDate.Value, dpEndDate.Value)
        Cursor = Cursors.Default
    End Sub

    Private Sub cboCashbook_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCashbook.SelectedIndexChanged
        lblCashbook.Text = ""
        lblCashbook.Text = cboCashbook.SelectedItem.Col2.ToString()
    End Sub

    Private Sub frmCashbookMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'gwt_comm = New CommonLibrary.Commons.CommonFunctions
        LoadCashBooks()
        cboCashbook.SelectedIndex = 0
        ViewAllTransactions(gwt_comm.shortMonthDateFormat(dpStartDate.Value), gwt_comm.shortMonthDateFormat(dpEndDate.Value), lblCashbook.Text)
    End Sub

    Private Sub btnCashbooks_Click(sender As System.Object, e As System.EventArgs) Handles btnCashbooks.Click
        Dim frm As New frmCashBookListing
        frm.ShowDialog()
    End Sub

    Private Sub btnRefreshInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshInvoice.Click
        cboCashbook.SelectedIndex = 0
        ViewAllTransactions(gwt_comm.shortMonthDateFormat(dpStartDate.Value), gwt_comm.shortMonthDateFormat(dpEndDate.Value), lblCashbook.Text)
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        'If dGridAll.RowCount <= 0 Then Exit Sub
        'intSelectedTransaction = 0
        'If Not Object.Equals(dGridAll.CurrentRow.Cells(dGridAll.ColumnCount - 3).Value, Nothing) Then
        '    If Not String.IsNullOrEmpty(dGridAll.CurrentRow.Cells(dGridAll.ColumnCount - 3).Value.ToString) Then
        '        If IsNumeric(dGridAll.CurrentRow.Cells(dGridAll.ColumnCount - 3).Value.ToString) Then
        '            intSelectedTransaction = CInt(dGridAll.CurrentRow.Cells(dGridAll.ColumnCount - 3).Value.ToString)
        '            boolAbort = False
        '            Dim frm As New frmCashbookTransactionEdit
        '            frm.ShowDialog()
        '            If boolAbort = True Then Exit Sub
        '            ViewAllTransactions(Format(dpStartDate.Value, "dd-MMM-yyyy"), Format(dpEndDate.Value, "dd-MMM-yyyy"), lblCashbook.Text)
        '        End If
        '    End If
        'End If
        If dGridAll.RowCount <= 0 Then Exit Sub
        intSelectedSpecialKey = CInt(dGridAll.CurrentRow.Cells(dGridAll.Columns.Count - 4).Value.ToString)
        strSelectedDate = dGridAll.CurrentRow.Cells(0).Value.ToString
        boolEditStatusTwo = True
        Dim fm As New frmLinkedTransactionsEdit
        fm.ShowDialog()
        boolEditStatusTwo = False
        ViewAllTransactions(gwt_comm.shortMonthDateFormat(dpStartDate.Value), gwt_comm.shortMonthDateFormat(dpEndDate.Value), lblCashbook.Text)
    End Sub

    Private Sub btnExpenses_Click(sender As System.Object, e As System.EventArgs) Handles btnExpenses.Click
        boolAbort = False
        gwt_comm.CashbookSelection()
        If boolAbort = True Then Exit Sub
        boolClassicExpensesCapture = False
        gwt_comm.ExpensesCapture(boolClassicExpensesCapture)
    End Sub

    Private Sub btnDeleteCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteCustomer.Click
        If dGridAll.RowCount <= 0 Then Exit Sub
        intSelectedSpecialKey = CInt(dGridAll.CurrentRow.Cells(dGridAll.Columns.Count - 4).Value.ToString)
        Dim fm As New frmLinkedTransactions
        fm.ShowDialog()
        ViewAllTransactions(gwt_comm.shortMonthDateFormat(dpStartDate.Value), gwt_comm.shortMonthDateFormat(dpEndDate.Value), lblCashbook.Text)

        '        If MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
        '            If Not IsNumeric(dGridAll.CurrentRow.Cells(dGridAll.Columns.Count - 4).Value) Then
        '                MessageBox.Show("Transaction cannot be deleted", "Process Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                Exit Sub
        '            End If
        '            Dim intKey As Integer = CInt(dGridAll.CurrentRow.Cells(dGridAll.Columns.Count - 4).Value.ToString)
        '            Dim intTransId As Integer = CInt(dGridAll.CurrentRow.Cells(dGridAll.Columns.Count - 3).Value.ToString)
        '            If intKey <> 0 Then
        '                If gwt_comm.DeleteSpecialKeyTransaction(intKey) = True Then
        '                    ViewAllTransactions(Format(dpStartDate.Value, "dd-MMM-yyyy"), Format(dpEndDate.Value, "dd-MMM-yyyy"), lblCashbook.Text)
        '                    MessageBox.Show("Transaction has been deleted successfully. ", "Cashbook Transaction Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                Else
        '                    Exit Sub
        '                End If
        '            Else
        '                Dim intReference As Integer = CInt(dGridAll.CurrentRow.Cells(4).Value.ToString)
        '                Dim strContraReference As String = UCase(strPublicActiveCashbook) & "-" & Format(intReference, "00000")
        '                Dim strLedgerReference As String = dGridAll.CurrentRow.Cells(6).Value.ToString
        '                Dim dblAmountOfTrans As Double = CDbl(dGridAll.CurrentRow.Cells(7).Value.ToString) + CDbl(dGridAll.CurrentRow.Cells(8).Value.ToString)
        '                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM CashbookTransactions WHERE " _
        '                    & "TransactionId = " & intTransId & " AND AccountNumber = '" & strPublicActiveCashbook & "'", cnn)
        '                objCommand.ExecuteNonQuery()
        '                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE " _
        '                    & "Reference = '" & strLedgerReference & "' AND ContraAccount = '" & UCase(strPublicActiveCashbook) & "' AND " _
        '                    & "Amount = " & dblAmountOfTrans & "", cnn)
        '                objCommand.ExecuteNonQuery()
        '                ViewAllTransactions(Format(dpStartDate.Value, "dd-MMM-yyyy"), Format(dpEndDate.Value, "dd-MMM-yyyy"), lblCashbook.Text)
        '                MessageBox.Show("Transaction has been deleted successfully. ", "Cashbook Transaction Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                'MessageBox.Show("This transaction cannot be deleted as was created in the legacy system" & vbCrLf &
        '                '                "You can only reverse this transaction by passing a journal", "Process Cannot Proceed", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                Exit Sub
        '            End If
        '        End If
        '        Exit Sub
        'RaiseErr:
        '        boolAbort = True
        '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On cashbook transaction delete"
        '        gwt_comm.ShowErrorMessage
    End Sub

    Private Sub btnPrintTransactions_Click(sender As Object, e As EventArgs) Handles btnPrintTransactions.Click
        Dim pnt As New CommonLibrary.Commons.CommonFunctions
        pnt.PrintCashbookTransactions(lblCashbook.Text, CDate(gwt_comm.shortMonthDateFormat(dpStartDate.Value)), CDate(gwt_comm.shortMonthDateFormat(dpEndDate.Value)))
    End Sub

    Private Sub btnPrintRecon_Click(sender As Object, e As EventArgs) Handles btnPrintRecon.Click
        PrintReconciliationStatement()
    End Sub

    Private Sub PrintReconciliationStatement()
        'print the cashbook information
        'First get the dates from
        boolAbort = False
        CurrentBankBalance(strPublicActiveCashbook)
        If boolAbort = True Then Exit Sub
        On Error GoTo RaiseErr
        Dim strPrintColOne As String = Nothing
        Dim strPrintColTwo As String = Nothing
        Dim strPrintColThree As String = Nothing
        Dim strPrintColFour As String = Nothing
        Dim strPrintColFive As String = Nothing
        Dim strPrintColSix As String = Nothing
        Dim dblBalanceBroughtDown As Double = 0
        Dim intRecCount As Integer
        Dim dblDebitTotal As Double = 0
        Dim dblCreditTotal As Double = 0
        Dim dblCurrentDebitTotal As Double = 0
        Dim dblCurrentCreditTotal As Double = 0
        Dim dblCurrentBalance As Double = 0
        Dim strPrintingListArray As New ArrayList
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim myCommand As Data.OleDb.OleDbCommand
        myCommand = New Data.OleDb.OleDbCommand("Select sum(Amount) as [DeditBalance] FROM CashbookTransactions " _
            & "WHERE AccountNumber = '" & strPublicActiveCashbook & "' AND TransactionType = 'DEBIT'", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows = True Then
            dbReader.Read() '
            If Not IsDBNull(dbReader(0).ToString) Then dblDebitTotal = CDbl(dbReader(0).ToString) Else dblDebitTotal = 0
        End If
        dbReader.Close()
        myCommand = New Data.OleDb.OleDbCommand("Select sum(Amount) as [CreditBalance] FROM CashbookTransactions " _
            & "WHERE AccountNumber = '" & strPublicActiveCashbook & "'  AND TransactionType = 'CREDIT'", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows = True Then
            dbReader.Read()
            If Not IsDBNull(dbReader(0).ToString) Then dblCreditTotal = CDbl(dbReader(0).ToString) Else dblCreditTotal = 0
        End If
        dbReader.Close()
        dblBalanceBroughtDown = dblDebitTotal - dblCreditTotal
        'Get the cashbook records from the specified time and send to prin
        myCommand = New Data.OleDb.OleDbCommand("SELECT * FROM CashbookTransactions WHERE Status = 'N' AND AccountNumber = '" & strPublicActiveCashbook & "' ORDER BY TransactionDate", cnn)
        dbReader = myCommand.ExecuteReader
        'Generate the balance line 

        '

        '

        strPrintColOne = " " : strPrintColTwo = "BALANCE PER CASHBOOK :"
        If dblBalanceBroughtDown < 0 Then strPrintColSix = CStr(Format(dblBalanceBroughtDown, "#,##0.00")) Else strPrintColSix = CStr(Format(dblBalanceBroughtDown, "#,##0.00"))
        strPrintingListArray.Add(strPrintColOne & ";" & strPrintColTwo & ";" & strPrintColThree & ";" & strPrintColFour & ";" & strPrintColFive & ";" & strPrintColSix)
        strPrintingListArray.Add(" ;;;;;")
        strPrintingListArray.Add(" ;Less Unpresented Items :;;;;")
        strPrintColSix = ""
        If dbReader.HasRows = True Then
            While dbReader.Read
                If IsDate(dbReader("TransactionDate").ToString) Then strPrintColOne = gwt_comm.shortMonthDateFormat(CDate(dbReader("TransactionDate").ToString)) Else strPrintColOne = ""
                If Not IsDBNull(dbReader("Description").ToString) Then strPrintColTwo = dbReader("Description").ToString Else strPrintColTwo = ""
                If Not IsDBNull(dbReader("Amount").ToString) Then strPrintColFive = CStr(Format(CDbl(dbReader("Amount").ToString), "#,##0.00")) Else strPrintColFive = "0.00"
                strPrintingListArray.Add(strPrintColOne & ";" & strPrintColTwo & ";" & strPrintColThree & ";" & strPrintColFour & ";" & strPrintColFive & ";" & strPrintColSix)
            End While
        End If
        dbReader.Close()
        'Add spaces after the transactions print
        strPrintingListArray.Add(" ;;;;;")
        strPrintingListArray.Add(" ;;;;;")
        'Print the sum totals of the uncleared
        myCommand = New Data.OleDb.OleDbCommand("SELECT sum(CAST(Amount AS DECIMAL (30,2))) as UnclearedTotal FROM CashbookTransactions WHERE " _
            & "Status = 'N' AND AccountNumber = '" & strPublicActiveCashbook & "'", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows = True Then
            dbReader.Read()
            If Not IsDBNull(dbReader(0).ToString) Then dblCurrentDebitTotal = dbReader(0).ToString Else dblCurrentDebitTotal = 0
        End If
        dbReader.Close()
        strPrintColOne = " " : strPrintColTwo = "TOTAL UNCLEARED AMOUNTS" : strPrintColThree = "" : strPrintColFour = "" : strPrintColFive = "---------------" : strPrintColSix = CStr(Format(dblCurrentDebitTotal, "#,##0.00"))
        strPrintingListArray.Add(strPrintColOne & ";" & strPrintColTwo & ";" & strPrintColThree & ";" & strPrintColFour & ";" & strPrintColFive & ";" & strPrintColSix)
        'Print the current transactions balance
        strPrintingListArray.Add(" ; ;;;;")
        'Get the bank balance
        dblCurrentBalance = lblBalance.Text 'dblBalanceBroughtDown - dblCurrentDebitTotal

        strPrintColOne = " " : strPrintColTwo = "BALANCE PER BANK " : strPrintColThree = "" : strPrintColFour = "" : strPrintColSix = CStr(Format(dblCurrentBalance, "#,##0.00")) : strPrintColFive = ""

        strPrintingListArray.Add(strPrintColOne & ";" & strPrintColTwo & ";" & strPrintColThree & ";" & strPrintColFour & ";" & strPrintColFive & ";" & strPrintColSix)
        intRecCount = strPrintingListArray.Count
        Dim strPrintDetails(0 To intRecCount - 1) As String ' strBatchPrintDetails(0 To (intRecCount - 1))

        For i = 0 To (intRecCount - 1)
            strPrintDetails(i) = strPrintingListArray.Item(i)
        Next
        Dim prnReport As New SmartColumnReportWriter.SmartColumnReportWriter
        With prnReport
            .intPrintRecordsCount = strPrintDetails.Length
            .strPrintValues = strPrintDetails
            .intNumberOfColumns = 6
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .strColumnWidths = "80|190|80|100|100|100"
            .strColumnAlignments = "0|0|0|0|2|2"
            .boolGenericReport = True
            .strMainCaption = UCase(strCompanyName) & " CASHBOOK RECONCILIATION AS AT " & UCase(gwt_comm.shortMonthDateFormat(Now))
            .strColumnHeaders = "DATE|DESCRIPTION|DEBIT|CREDIT| | "
            .strFooterCaption = "Bank Reconciliation Statement"

            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False

            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO"
            .strColumnTotals = "NO|NO|NO|NO|NO|NO"

            PrintPreviewDialog1.Document = prnReport
            PrintPreviewDialog1.ShowDialog()
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On cashbook/bank reconciliation update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub CurrentBankBalance(ByVal strCashBookAccount As String)
        On Error GoTo RaiseErr
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim dblClearedBalance As Double = 0
        Dim dblClearedDebits As Double = 0
        Dim dblClearedCredits As Double = 0

        myCommand = New Data.OleDb.OleDbCommand("SELECT sum(Amount) as ClearedDebits FROM CashbookTransactions WHERE AccountNumber = '" & strCashBookAccount & "' AND TransactionType = 'DEBIT' AND Status = 'Y'", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows = True Then
            dbReader.Read()
            If Not IsDBNull(dbReader(0).ToString) Then
                If IsNumeric(dbReader(0).ToString) Then dblClearedDebits = CDbl(dbReader(0).ToString) Else dblClearedDebits = 0
            Else
                dblClearedDebits = 0
            End If
        End If
        dbReader.Close()
        myCommand = New Data.OleDb.OleDbCommand("SELECT sum(Amount) as ClearedCredits FROM CashbookTransactions WHERE AccountNumber = '" & strCashBookAccount & "' AND TransactionType = 'CREDIT' AND Status = 'Y'", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows = True Then
            dbReader.Read()
            If Not IsDBNull(dbReader(0).ToString) Then
                If IsNumeric(dbReader(0).ToString) Then dblClearedCredits = CDbl(dbReader(0).ToString) Else dblClearedCredits = 0
            Else
                dblClearedCredits = 0
            End If
        End If
        dblClearedBalance = dblClearedDebits - dblClearedCredits
        Me.lblReconBankBalanceAmt.Text = CStr(Format(dblClearedBalance, "#,##0.00"))
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Reconciliation Bank Balance Computation Failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSaveRenconciliation_Click(sender As Object, e As EventArgs) Handles btnSaveRenconciliation.Click
        On Error GoTo RaiseErr
        'For i As Integer = 0 To dGridAll.Rows.Count - 1
        '    If Not (Object.Equals(Convert.ToString(dGridDebits.Rows(i).Cells(8).Value), "")) Then
        '        If UCase(dGridDebits.Rows(i).Cells(8).Value.ToString) = "BANK" Or
        '            UCase(dGridDebits.Rows(i).Cells(8).Value.ToString) = "TRANSFER" Then
        '            Dim strSql As String = Nothing
        '            dGridDebits.CurrentCell = dGridDebits.Rows(i).Cells(6)
        '            Dim cell As DataGridViewCheckBoxCell = Me.dGridDebits.CurrentCell
        '            'Get the value of the current cell
        '            Dim checked As Boolean = cell.GetEditedFormattedValue(cell.RowIndex, DataGridViewDataErrorContexts.Parsing)
        '            If checked = True Then
        '                strSql = "UPDATE CashbookTransactions SET Status = 'Y' WHERE TransactionId = " & CInt(dGridDebits.Rows(i).Cells(4).Value.ToString) & ""
        '            Else
        '                strSql = "UPDATE CashbookTransactions SET Status = 'N' WHERE TransactionId = " & CInt(dGridDebits.Rows(i).Cells(4).Value.ToString) & ""
        '            End If
        '            If Not String.IsNullOrEmpty(strSql) Then
        '                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        '                objCommand.ExecuteNonQuery()
        '            End If
        '        End If
        '    End If
        'Next

        ''Do the same for the credit grid items

        'For i As Integer = 0 To dGridCredits.Rows.Count - 1
        '    If Not (Object.Equals(Convert.ToString(dGridCredits.Rows(i).Cells(8).Value), "")) Then
        '        If UCase(dGridCredits.Rows(i).Cells(8).Value.ToString) = "BANK" Or
        '            UCase(dGridCredits.Rows(i).Cells(8).Value.ToString) = "TRANSFER" Then
        '            Dim strSql As String = Nothing
        '            dGridCredits.CurrentCell = dGridCredits.Rows(i).Cells(6)
        '            Dim cell As DataGridViewCheckBoxCell = Me.dGridCredits.CurrentCell
        '            'Get the value of the current cell
        '            Dim checked As Boolean = cell.GetEditedFormattedValue(cell.RowIndex, DataGridViewDataErrorContexts.Parsing)
        '            If checked = True Then
        '                strSql = "UPDATE CashbookTransactions SET Status = 'Y' WHERE TransactionId = " & CInt(dGridCredits.Rows(i).Cells(4).Value.ToString) & ""
        '            Else
        '                strSql = "UPDATE CashbookTransactions SET Status = 'N' WHERE TransactionId = " & CInt(dGridCredits.Rows(i).Cells(4).Value.ToString) & ""
        '            End If
        '            If Not String.IsNullOrEmpty(strSql) Then
        '                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        '                objCommand.ExecuteNonQuery()
        '            End If
        '        End If
        '    End If
        'Next

        'CurrentBankBalance(strPublicActiveCashbook)

        'MessageBox.Show("Bank reconciliation items updated successfully", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On cashbook/bank reconciliation update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnTransactions_Click(sender As System.Object, e As System.EventArgs) Handles btnTransactions.Click
        Dim frm As New frmCashbookDataEntry ' frmCashbookEntriesNewFormat
        frm.ShowDialog()
    End Sub

End Class