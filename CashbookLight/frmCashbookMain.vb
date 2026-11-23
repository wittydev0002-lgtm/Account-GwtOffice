Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Net
Imports System.Management
Imports System.Management.Instrumentation
Imports System.Drawing
Imports ComponentFactory.Krypton.Toolkit
Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCashbookMain

    Dim boolFormLoading As Boolean

    Private Sub btnEntries_Click(sender As System.Object, e As System.EventArgs) Handles btnEntries.Click
        Dim frm As New frmCashbookEntries
        frm.ShowDialog()
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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        ViewAllTransactions(Format(dpStartDate.Value, "dd-MMM-yyyy"), Format(dpEndDate.Value, "dd-MMM-yyyy"), lblCashbook.Text)
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
            & "[Reference][NVARCHAR](35) NULL DEFAULT '', [Debit][FLOAT] NULL DEFAULT 0, [Credit][FLOAT] NULL DEFAULT 0, " _
            & "[SpecialKey][INT] NOT NULL DEFAULT 0)"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Select first the debits and insert into the table
        Dim strSqlDebits As String = Nothing
        Dim strSqlCredits As String = Nothing
        If Cashbook = "0" Then
            strSqlDebits = "INSERT INTO TempCb " _
                & "(TransDate, Description, ContraAccount, AccountName, CostCenter, CostCenterName, Reference, Debit, SpecialKey) " _
                & "SELECT CashbookTransactions.TransactionDate, CashbookTransactions.Description, " _
                & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName, " _
                & "CashbookTransactions.CostCode, SystemCostCenters.CostCenterName, " _
                & "CashbookTransactions.UserReference, CashbookTransactions.Amount, SpecialKey FROM CashbookTransactions " _
                & "LEFT OUTER JOIN LedgerAccounts ON CashbookTransactions.ContraAccount = LedgerAccounts.AccountNumber " _
                & "LEFT OUTER JOIN SystemCostCenters ON CashbookTransactions.CostCode = SystemCostCenters.OrdinalNo " _
                & "WHERE CashbookTransactions.TransactionType = 'DEBIT' AND CashbookTransactions.TransactionDate " _
                & "BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND '" & Format(EndingDate, "dd-MMM-yyyy") & "'"

            strSqlCredits = "INSERT INTO TempCb " _
                & "(TransDate, Description, ContraAccount, AccountName, CostCenter, CostCenterName, Reference, Credit, SpecialKey) " _
                & "SELECT CashbookTransactions.TransactionDate, CashbookTransactions.Description, " _
                & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName, " _
                & "CashbookTransactions.CostCode, SystemCostCenters.CostCenterName, " _
                & "CashbookTransactions.UserReference, CashbookTransactions.Amount, SpecialKey FROM CashbookTransactions " _
                & "LEFT OUTER JOIN LedgerAccounts ON CashbookTransactions.ContraAccount = LedgerAccounts.AccountNumber " _
                & "LEFT OUTER JOIN SystemCostCenters ON CashbookTransactions.CostCode = SystemCostCenters.OrdinalNo " _
                & "WHERE CashbookTransactions.TransactionType = 'CREDIT' AND CashbookTransactions.TransactionDate " _
                & "BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND '" & Format(EndingDate, "dd-MMM-yyyy") & "'"
        Else
            strSqlDebits = "INSERT INTO TempCb " _
                & "(TransDate, Description, ContraAccount, AccountName, CostCenter, CostCenterName, Reference, Debit, SpecialKey) " _
                & "SELECT CashbookTransactions.TransactionDate, CashbookTransactions.Description, " _
                & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName, " _
                & "CashbookTransactions.CostCode, SystemCostCenters.CostCenterName, " _
                & "CashbookTransactions.UserReference, CashbookTransactions.Amount, SpecialKey FROM CashbookTransactions " _
                & "LEFT OUTER JOIN LedgerAccounts ON CashbookTransactions.ContraAccount = LedgerAccounts.AccountNumber " _
                & "LEFT OUTER JOIN SystemCostCenters ON CashbookTransactions.CostCode = SystemCostCenters.OrdinalNo " _
                & "WHERE CashbookTransactions.TransactionType = 'DEBIT' AND CashbookTransactions.TransactionDate " _
                & "BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND '" & Format(EndingDate, "dd-MMM-yyyy") & "' " _
                & "AND CashbookTransactions.AccountNumber = '" & Cashbook & "'"

            strSqlCredits = "INSERT INTO TempCb " _
                & "(TransDate, Description, ContraAccount, AccountName, CostCenter, CostCenterName, Reference, Credit, SpecialKey) " _
                & "SELECT CashbookTransactions.TransactionDate, CashbookTransactions.Description, " _
                & "CashbookTransactions.ContraAccount, LedgerAccounts.AccountName, " _
                & "CashbookTransactions.CostCode, SystemCostCenters.CostCenterName, " _
                & "CashbookTransactions.UserReference, CashbookTransactions.Amount, SpecialKey FROM CashbookTransactions " _
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
            & "CAST(Credit AS DECIMAL(10,2)) AS [Credit], SpecialKey as [Key] FROM TempCb ORDER BY TransDate"

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
                Dim dblBalanceBefore() As Double = gwt_comm.CashbookAccountBalances(CDate(Format(dpStartDate.Value, "dd-MMM-yyyy")), _
                        CDate(Format(DateAdd(DateInterval.Day, -1, dpStartDate.Value), "dd-MMM-yyyy")), objReader(0).ToString)
                dblAllCashbooksBalance = dblAllCashbooksBalance + dblBalanceBefore(1)
            End While
            objReader.Close()
            lblBalanceAll.Text = Format(dblAllCashbooksBalance, "##0.00")
            If dblAllCashbooksBalance < 0 Then lblCashbookBfBalanceType.Text = "CR" Else lblCashbookBfBalanceType.Text = "DR"
            dblTopBalance = dblAllCashbooksBalance
        Else
            gwt_comm = New CommonLibrary.Commons.CommonFunctions
            Dim dblBalanceBefore() As Double = gwt_comm.CashbookAccountBalances(CDate(Format(dpStartDate.Value, "dd-MMM-yyyy")), _
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
            If Not Object.Equals(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 4).Value.ToString) Then
                    If IsNumeric(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 4).Value.ToString) Then
                        dblDebit = CDbl(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 4).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 3).Value.ToString) Then
                    If IsNumeric(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 3).Value.ToString) Then
                        dblCredit = CDbl(dGridAll.Rows(p).Cells(dGridAll.Columns.Count - 3).Value.ToString)
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
        gwt_comm.ShowErrorMessage()
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

    Private Sub frmCashbookMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        boolFormLoading = True
        gwt_comm = New CommonLibrary.Commons.CommonFunctions
        gwt_comm.UserAuthentication()
        boolFormLoading = False
        LoadCashBooks()
        cboCashbook.SelectedIndex = 0
        ViewAllTransactions(Format(dpStartDate.Value, "dd-MMM-yyyy"), Format(dpEndDate.Value, "dd-MMM-yyyy"), lblCashbook.Text)
    End Sub

    Private Sub btnCashbooks_Click(sender As System.Object, e As System.EventArgs) Handles btnCashbooks.Click
        Dim frm As New frmCashBookListing
        frm.ShowDialog()
    End Sub

    Private Sub btnPrint_Click_1(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

    End Sub

    Private Sub btnRefreshInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshInvoice.Click
        cboCashbook.SelectedIndex = 0
        ViewAllTransactions(Format(dpStartDate.Value, "dd-MMM-yyyy"), Format(dpEndDate.Value, "dd-MMM-yyyy"), lblCashbook.Text)
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If dGridAll.RowCount <= 0 Then Exit Sub
        intSelectedTransaction = 0
        If Not Object.Equals(dGridAll.CurrentRow.Cells(dGridAll.ColumnCount - 2).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridAll.CurrentRow.Cells(dGridAll.ColumnCount - 2).Value.ToString) Then
                If IsNumeric(dGridAll.CurrentRow.Cells(dGridAll.ColumnCount - 2).Value.ToString) Then
                    intSelectedTransaction = CInt(dGridAll.CurrentRow.Cells(dGridAll.ColumnCount - 2).Value.ToString)
                    boolAbort = False
                    Dim frm As New frmCashbookTransactionEdit
                    frm.ShowDialog()
                    If boolAbort = True Then Exit Sub
                    ViewAllTransactions(Format(dpStartDate.Value, "dd-MMM-yyyy"), Format(dpEndDate.Value, "dd-MMM-yyyy"), lblCashbook.Text)
                End If
            End If
        End If
    End Sub
End Class
