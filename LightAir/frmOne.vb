Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmOne

    Dim strReportHeader As String

    Dim arrAccountTransactions As ArrayList
    Dim _originalSplitterDistance As Integer
    Dim _originalSplitterDistanceSub As Integer
    Dim _widthLeftRight As Integer
    Dim _CurrentSplitterDistance As Integer
    Dim intPriorSplitterDistance As Integer

    Dim boolFormLoading As Boolean
    Dim boolIncludeZeroBalance As Boolean = False

    Dim strTaxStatus As String = Nothing
    Dim strCustomerDetails As String
    Dim strInvoiceDetails As ArrayList
    Dim rsInvoiceTotals As String

    Dim dblInvoiceTotal As Double
    Dim dblTaxes As Double
    Dim dblDiscounts As Double
    Dim dblUnitPriceTotals As Double

    Dim i As Integer = 0
    Dim strvalue As String
    Dim strDate As String
    Dim itm As Integer
    Dim boolPrintFromPreview As Boolean
    Dim intPaymentReceiptNumber As Integer
    Dim strCustomerAccountNumberPayments As String
    Dim strTermsAndConditions As String = Nothing

    Dim strCustomerName As String
    Dim strCustomerAddress1 As String
    Dim strCustomerAddress2 As String
    Dim strCustomerAddress3 As String
    Dim strCustomerAddress4 As String
    Dim strCustomerTelephone As String
    Dim strCustomerEmailAddress As String
    Dim strCustomerVatNumber As String
    Dim strSalesRep As String

    Dim boolExitingWhile As Boolean = False
    Dim intPage As Single = 1
    Dim intPageTotals As Integer = 1

    Dim strItemType As String = Nothing
    Dim strOrderNumber As String = Nothing


    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub expandablePanel1_ExpandedChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles expandablePanel1.ExpandedChanged
        AdjustPanes()
    End Sub

    Private Sub GetSelected()
        On Error GoTo RaiseErr
        lblAccountName.Text = ""
        If tvAccounts.Nodes.Count > 0 Then
            strSelectedAccount = tvAccounts.SelectedNode.Tag
            Dim strSplit() As String = Split(tvAccounts.SelectedNode.Text, ":")
            strSelectedAccountName = strSplit(1)
            lblAccountName.Text = tvAccounts.SelectedNode.Text
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger Account Details Fetch"
        ShowErrorMessage()
    End Sub

    Private Sub AdjustPanes()
        If expandablePanel1.Expanded Then
            If (splitMain.Width - splitMain.Panel1.Width) < 200 Then intPriorSplitterDistance = splitMain.Width - 250
            splitMain.SplitterDistance = intPriorSplitterDistance
            splitMain.IsSplitterFixed = False
        Else
            intPriorSplitterDistance = splitMain.SplitterDistance
            splitMain.SplitterDistance = splitMain.Width - 32
            splitMain.IsSplitterFixed = True
        End If
    End Sub

    Private Sub frmOne_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        StartDate = Now : EndDate = Now
        tvReports.ExpandAll()
        boolAbort = False
        Dim frm As New frmLogin
        frm.ShowDialog()
        If boolAbort = True Then End
        LoadCashBooks()
        'add the ledger accounts and the treeview
        AddTreeNodes()
        cboCashbook.SelectedIndex = 0
        ViewAllTransactions(Format(dpDateFrom.Value, "dd-MMM-yyyy"), Format(dpDateTo.Value, "dd-MMM-yyyy"), lblCashbook.Text)
        If boolAbort = True Then Exit Sub
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
        ViewAllTransactions(Format(dpDateFrom.Value, "dd-MMM-yyyy"), Format(dpDateTo.Value, "dd-MMM-yyyy"), lblCashbook.Text)
    End Sub

    Private Sub btnEntries_Click(sender As Object, e As System.EventArgs) Handles btnEntries.Click
        Dim frm As New frmCashbookEntries
        frm.ShowDialog()
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

        'Drop and create temp cashbook
        strSql = "CREATE TABLE TempCb ([TransDate][SmallDateTime] NOT NULL, [Description][NVARCHAR](150) NOT NULL DEFAULT '', " _
            & "[ContraAccount][NVARCHAR](35) NOT NULL, [AccountName][NVARCHAR](150) NULL DEFAULT '', " _
            & "[CostCenter][INT] NULL DEFAULT 0, [CostCenterName][NVARCHAR](250) NULL DEFAULT '', " _
            & "[Reference][NVARCHAR](35) NULL DEFAULT '', [Debit][FLOAT] NULL DEFAULT 0, [Credit][FLOAT] NULL DEFAULT 0)"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Select first the debits and insert into the table
        Dim strSqlDebits As String = Nothing
        Dim strSqlCredits As String = Nothing
        If Cashbook = "0" Then
            strSqlDebits = "INSERT INTO TempCb " _
                & "(TransDate, Description, ContraAccount, AccountName, CostCenter, CostCenterName, Reference, Debit) " _
                & "SELECT CashbookTransactions.TransactionDate, CashbookTransactions.Description, " _
                & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName, " _
                & "CashbookTransactions.CostCode, SystemCostCenters.CostCenterName, " _
                & "CashbookTransactions.UserReference, CashbookTransactions.Amount FROM CashbookTransactions " _
                & "LEFT OUTER JOIN LedgerAccounts ON CashbookTransactions.ContraAccount = LedgerAccounts.AccountNumber " _
                & "LEFT OUTER JOIN SystemCostCenters ON CashbookTransactions.CostCode = SystemCostCenters.OrdinalNo " _
                & "WHERE CashbookTransactions.TransactionType = 'DEBIT' AND CashbookTransactions.TransactionDate " _
                & "BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND '" & Format(EndingDate, "dd-MMM-yyyy") & "'"

            strSqlCredits = "INSERT INTO TempCb " _
                & "(TransDate, Description, ContraAccount, AccountName, CostCenter, CostCenterName, Reference, Credit) " _
                & "SELECT CashbookTransactions.TransactionDate, CashbookTransactions.Description, " _
                & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName, " _
                & "CashbookTransactions.CostCode, SystemCostCenters.CostCenterName, " _
                & "CashbookTransactions.UserReference, CashbookTransactions.Amount FROM CashbookTransactions " _
                & "LEFT OUTER JOIN LedgerAccounts ON CashbookTransactions.ContraAccount = LedgerAccounts.AccountNumber " _
                & "LEFT OUTER JOIN SystemCostCenters ON CashbookTransactions.CostCode = SystemCostCenters.OrdinalNo " _
                & "WHERE CashbookTransactions.TransactionType = 'CREDIT' AND CashbookTransactions.TransactionDate " _
                & "BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND '" & Format(EndingDate, "dd-MMM-yyyy") & "'"
        Else
            strSqlDebits = "INSERT INTO TempCb " _
                & "(TransDate, Description, ContraAccount, AccountName, CostCenter, CostCenterName, Reference, Debit) " _
                & "SELECT CashbookTransactions.TransactionDate, CashbookTransactions.Description, " _
                & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName, " _
                & "CashbookTransactions.CostCode, SystemCostCenters.CostCenterName, " _
                & "CashbookTransactions.UserReference, CashbookTransactions.Amount FROM CashbookTransactions " _
                & "LEFT OUTER JOIN LedgerAccounts ON CashbookTransactions.ContraAccount = LedgerAccounts.AccountNumber " _
                & "LEFT OUTER JOIN SystemCostCenters ON CashbookTransactions.CostCode = SystemCostCenters.OrdinalNo " _
                & "WHERE CashbookTransactions.TransactionType = 'DEBIT' AND CashbookTransactions.TransactionDate " _
                & "BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND '" & Format(EndingDate, "dd-MMM-yyyy") & "' " _
                & "AND CashbookTransactions.AccountNumber = '" & Cashbook & "'"

            strSqlCredits = "INSERT INTO TempCb " _
                & "(TransDate, Description, ContraAccount, AccountName, CostCenter, CostCenterName, Reference, Credit) " _
                & "SELECT CashbookTransactions.TransactionDate, CashbookTransactions.Description, " _
                & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName, " _
                & "CashbookTransactions.CostCode, SystemCostCenters.CostCenterName, " _
                & "CashbookTransactions.UserReference, CashbookTransactions.Amount FROM CashbookTransactions " _
                & "LEFT OUTER JOIN LedgerAccounts ON CashbookTransactions.ContraAccount = LedgerAccounts.AccountNumber " _
                & "LEFT OUTER JOIN SystemCostCenters ON CashbookTransactions.CostCode = SystemCostCenters.OrdinalNo " _
                & "WHERE CashbookTransactions.TransactionType = 'CREDIT' AND CashbookTransactions.TransactionDate " _
                & "BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND '" & Format(EndingDate, "dd-MMM-yyyy") & "' " _
                & "AND CashbookTransactions.AccountNumber = '" & Cashbook & "'"
        End If

        objCommand = New Data.OleDb.OleDbCommand(strSqlDebits, cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand(strSqlCredits, cnn)
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
        strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date], [Description], " _
            & "[ContraAccount] AS [Contra #], [AccountName] AS [Account Name], " _
            & "[CostCenter] AS [Center], [CostCenterName] AS [Center Name], " _
            & "[Reference] AS [Ref.], CAST(Debit AS DECIMAL(10,2)) AS [Debit], " _
            & "CAST(Credit AS DECIMAL(10,2)) AS [Credit] FROM TempCb ORDER BY TransDate"

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
            dGridAll.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p = dGridAll.Columns.Count - 1 Then
                dGridAll.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            If p = dGridAll.Columns.Count - 2 Then
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

        'Get the balance brought forward
        Dim dblTopBalance As Double = 0
        If lblCashbook.Text = "0" Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT(AccountNumber) FROM CashbookTransactions ORDER BY AccountNumber", cnn)
            objReader = objCommand.ExecuteReader
            Dim dblAllCashbooksBalance As Double = 0
            While objReader.Read
                gwt_comm = New CommonLibrary.Commons.CommonFunctions
                Dim dblBalanceBefore() As Double = gwt_comm.CashbookAccountBalances(CDate(Format(dpDateFrom.Value, "dd-MMM-yyyy")), _
                        CDate(Format(DateAdd(DateInterval.Day, -1, dpStartDate.Value), "dd-MMM-yyyy")), objReader(0).ToString)
                dblAllCashbooksBalance = dblAllCashbooksBalance + dblBalanceBefore(1)
            End While
            objReader.Close()
            lblBalanceAll.Text = Format(dblAllCashbooksBalance, "##0.00")
            If dblAllCashbooksBalance < 0 Then lblCashbookBfBalanceType.Text = "CR" Else lblCashbookBfBalanceType.Text = "DR"
            dblTopBalance = dblAllCashbooksBalance
        Else
            gwt_comm = New CommonLibrary.Commons.CommonFunctions
            Dim dblBalanceBefore() As Double = gwt_comm.CashbookAccountBalances(CDate(Format(dpDateFrom.Value, "dd-MMM-yyyy")), _
                CDate(Format(DateAdd(DateInterval.Day, -1, dpStartDate.Value), "dd-MMM-yyyy")), lblCashbook.Text)
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
            If Not Object.Equals(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 3).Value.ToString) Then
                    If IsNumeric(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 3).Value.ToString) Then
                        dblDebit = CDbl(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 3).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 2).Value.ToString) Then
                    If IsNumeric(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 2).Value.ToString) Then
                        dblCredit = CDbl(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 2).Value.ToString)
                    End If
                End If
            End If
            Dim dblLineBalance As Double = (dblDebit - dblCredit) + dblPastBalance
            dblPastBalance = dblLineBalance
            dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 1).Value = Format(dblLineBalance, "##0.00")
        Next
        dGridAll.Columns(dGridAll.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dGridAll.Columns(dGridAll.Columns.Count - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Cashbook Transactions View All"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs)
        If dGridAll.Rows.Count <= 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        gwt_comm.PrintCashbookTransactions(CDbl(lblBalanceAll.Text), CDbl(lblBalance.Text), _
            UCase(lblCashbook.Text & ": " & cboCashbook.Text), dpStartDate.Value, dpEndDate.Value, dGridAll)
        Cursor = Cursors.Default
    End Sub

    Private Sub cboCashbook_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCashbook.SelectedIndexChanged
        lblCashbook.Text = ""
        lblCashbook.Text = cboCashbook.SelectedItem.Col2.ToString()
    End Sub

    Private Sub AddTreeNodes()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AccountNumber, AccountName FROM LedgerAccounts " _
            & "WHERE SubAccountOf = 'NONE' ORDER BY AccountName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim node As New TreeNode
            node.Text = objReader(0).ToString & ":" & objReader(1).ToString
            node.Tag = objReader(0).ToString
            AddNodes(node)
            tvAccounts.Nodes.Add(node)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Ledger Accounts Population"
        ShowErrorMessage()
    End Sub

    Private Sub AddNodes(ByRef node As TreeNode)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AccountNumber, AccountName FROM LedgerAccounts " _
            & "WHERE SubAccountOf = '" & node.Tag & "' ORDER BY AccountName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim nNode As New TreeNode
            nNode.Text = objReader(0).ToString & ":" & objReader(1).ToString
            nNode.Tag = objReader(0).ToString
            AddNodes(nNode)
            node.Nodes.Add(nNode)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Ledger Accounts Population"
        ShowErrorMessage()
    End Sub

    Private Sub tvAccounts_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvAccounts.AfterSelect
        If boolFormLoading = True Then Exit Sub
        dGridLedgers.Rows.Clear()
        On Error Resume Next
        strSelectedAccount = tvAccounts.SelectedNode.Tag
        Dim strSplit() As String = Split(tvAccounts.SelectedNode.Text, ":")
        strSelectedAccountName = strSplit(1)
        lblAccountName.Text = tvAccounts.SelectedNode.Text
        LoadSelectedLedgerAccountDetails(tvAccounts.SelectedNode.Tag)
    End Sub

    Private Sub LoadSelectedLedgerAccountDetails(ByVal AccountNumber As String)
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim dblLedgerBalanceBroughtDown() As Double = gwt_comm.LedgerAccountBalances(dpStartDate.Value, _
            dpEndDate.Value, AccountNumber)

        lblLedgerPeriodStartBalance.Text = Format(dblLedgerBalanceBroughtDown(0), "#,##0.00")

        'lblLedgerBFbalanceType
        If dblLedgerBalanceBroughtDown(0) < 0 Then lblLedgerBFbalanceType.Text = "CR" Else lblLedgerBFbalanceType.Text = "DR"

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransactionDate, 105) as [Date], " _
            & "Description, FolioReference, ContraAccount, CAST(Amount as DECIMAL (10,2)) AS [Amt], TransactionType, TransactionId, SpecialKey " _
            & "FROM LedgerTransactions WHERE AccountNumber = '" & AccountNumber & "' AND TransactionDate BETWEEN " _
            & "'" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridLedgers.Rows.Clear()
        Dim dblTotalLedgerDebits As Double = 0
        Dim dblTotalLedgerCredits As Double = 0
        While objReader.Read
            With dGridLedgers
                .Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
                If Not IsDBNull(objReader(5).ToString) Then
                    Dim strValue As String = objReader(4).ToString
                    If UCase(objReader(5).ToString) = "CREDIT" Then
                        .Rows(.Rows.Count - 1).Cells(5).Value = strValue
                        If IsNumeric(strValue) Then
                            dblTotalLedgerCredits = dblTotalLedgerCredits + CDbl(strValue)
                        End If
                    Else
                        .Rows(.Rows.Count - 1).Cells(4).Value = strValue
                        If IsNumeric(strValue) Then
                            dblTotalLedgerDebits = dblTotalLedgerDebits + CDbl(strValue)
                        End If
                    End If
                End If
                If Not IsDBNull(objReader(7).ToString) Then .Rows(.Rows.Count - 1).Cells(6).Value = objReader(7).ToString
            End With
        End While
        objReader.Close()
        lblLedgerCount.Text = Format(dGridLedgers.Rows.Count, "#,##0")
        lblLedgerDebits.Text = Format(dblTotalLedgerDebits, "#,##0.00")
        lblLedgerCredits.Text = Format(dblTotalLedgerCredits, "#,##0.00")
        lblLedgerMovement.Text = Format((dblTotalLedgerDebits - dblTotalLedgerCredits), "#,##0.00")
        lblLedgerEndBalance.Text = Format(((dblLedgerBalanceBroughtDown(0) + (dblTotalLedgerDebits - dblTotalLedgerCredits))), "#,##0.00")
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Leadger Account Transactions Load"
        ShowErrorMessage()
    End Sub

    Private Sub AlternateColors(Grid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView)
        For i As Integer = 0 To Grid.Rows.Count - 1 Step 2
            For j As Integer = 0 To Grid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                Grid.Rows(i).Cells(j).Style.BackColor = backColor
                Grid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub PrintCustomerBalances()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim arrCustomers As New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM Customers ORDER BY AccountName", cnn)
        Dim objReaderCustomers As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReaderCustomers.Read
            Dim dblBalance As Double = gwt_comm.GetBalance(objReaderCustomers(0).ToString)
            If boolIncludeZeroBalance = False Then
                If dblBalance <> 0 Then
                    arrCustomers.Add(UCase(objReaderCustomers(0).ToString) & ";" & UCase(objReaderCustomers(1).ToString) & ";" & dblBalance & ";")
                End If
            Else
                arrCustomers.Add(UCase(objReaderCustomers(0).ToString) & ";" & UCase(objReaderCustomers(1).ToString) & ";" & dblBalance & ";")
            End If
        End While

        'Send the information to the printer

        Dim strPrintDetails(0 To arrCustomers.Count - 1) As String
        For i As Integer = 0 To arrCustomers.Count - 1
            strPrintDetails(i) = arrCustomers.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 4
            .strColumnHeaders = "CUSTOMER NAME|ACCOUNT NO|AMOUNT|"
            .strColumnAlignments = "0|0|2|0"
            .strColumnWidths = "150|250|100|100"
            .strFooterCaption = "Customer balances report"
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = "CUSTOMER BALANCES"
            '.strMainHeader3 = "PERIOD COVERED " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " - " & UCase(Format(EndDate, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|YES|NO"
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
            .boolGroupDetails = False
            .boolPrintTotals = True
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|YES|NO"
            .strSummaryTotals = "NO|NO|YES|NO"
            '.intKeyFieldIndex = 7
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Balance printing"
        ShowErrorMessage()
    End Sub

    Private Sub btnFindData_Click(sender As System.Object, e As System.EventArgs) Handles btnFindData.Click
        strSelectedAccount = tvAccounts.SelectedNode.Tag
        Dim strSplit() As String = Split(tvAccounts.SelectedNode.Text, ":")
        strSelectedAccountName = strSplit(1)
        lblAccountName.Text = tvAccounts.SelectedNode.Text
        LoadSelectedLedgerAccountDetails(tvAccounts.SelectedNode.Tag)
    End Sub

    Private Sub btnLedgerAccounts_Click(sender As System.Object, e As System.EventArgs) Handles btnLedgerAccounts.Click
        Dim frm As New frmLedgerAccountsSetupListing
        frm.ShowDialog()
    End Sub

    Private Sub btnCashbooks_Click(sender As System.Object, e As System.EventArgs) Handles btnCashbooks.Click
        Dim frm As New frmCashBookListing
        frm.ShowDialog()
    End Sub

    Private Sub btnSpecialLedgers_Click(sender As System.Object, e As System.EventArgs) Handles btnSpecialLedgers.Click
        Dim frm As New frmSpecialLedgerAccounts
        frm.ShowDialog()
    End Sub

    Private Sub btnOrganisation_Click(sender As System.Object, e As System.EventArgs) Handles btnOrganisation.Click
        On Error GoTo RaiseErr
        Dim strFilename As String = Application.StartupPath & "\gwtOrganization.exe"
        Cursor = Cursors.WaitCursor
        Shell(strFilename, AppWinStyle.NormalFocus, False)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        MessageBox.Show("The called module is not licensed on your computer" & vbCrLf & _
            "Please contact your software provider for assistance", "Application Licensing Error",
            MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnNewJournal_Click(sender As System.Object, e As System.EventArgs) Handles btnNewJournal.Click
        boolEditStatus = False
        Dim frm As New frmJournalEntry
        frm.ShowDialog()
        LoadJournals()
    End Sub

    Private Sub LoadJournals()

    End Sub
End Class
