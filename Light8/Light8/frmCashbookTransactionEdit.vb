Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmCashbookTransactionEdit

    Private Sub frmCashbookTransactionEdit_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr

        lblCostCenter.Text = Nothing
        lblLedgerAccount.Text = Nothing
        LoadLedgerAccounts()
        LoadCostCenters()

        boolAbort = False
        Dim strSql As String = "SELECT * FROM CashbookTransactions WHERE SpecialKey = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsDate(objReader("TransactionDate").ToString) Then dtTrans.Value = CDate(objReader("TransactionDate").ToString)
            If Not IsDBNull(objReader("Description").ToString) Then txtDescription.Text = objReader("Description")
            If Not IsDBNull(objReader("AccountNumber").ToString) Then
                cboCashbook.Text = CashbookAccountName(objReader("AccountNumber").ToString)
                lblCashbook.Text = objReader("AccountNumber").ToString
            End If

            If Not IsDBNull(objReader("ContraAccount").ToString) Then
                cboContraAccount.Text = LedgerAccountName(objReader("ContraAccount").ToString)
                lblLedgerAccount.Text = objReader("ContraAccount").ToString
            End If

            If Not IsDBNull(objReader("Reference").ToString) Then txtReference.Text = objReader("Reference").ToString
            If Not IsDBNull(objReader("TransactionType").ToString) Then cboTransType.Text = objReader("TransactionType").ToString
            If IsNumeric(objReader("Amount").ToString) Then txtAmount.Text = Format(CDbl(objReader("Amount").ToString), "##0.00")
            If Not IsDBNull(objReader("CostCode").ToString) Then cboCostCenter.Text = objReader("CostCode").ToString
        End If
        objReader.Close()

        'Load the affected Ledger Accounts
        strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), LedgerTransactions.TransactionDate, 106), ' ', '-')) as [Date], " _
            & "LedgerTransactions.Description AS [Description], LedgerTransactions.AccountNumber AS [Account], " _
            & "LedgerAccounts.AccountName AS [Account Name], " _
            & "LedgerTransactions.TransactionType AS [Entry Type], CAST(LedgerTransactions.Amount AS DECIMAL(10,2)) AS [Amount] " _
            & "FROM LedgerTransactions LEFT OUTER JOIN LedgerAccounts ON " _
            & "LedgerTransactions.AccountNumber = LedgerAccounts.AccountNumber WHERE SpecialKey = " & intSelectedTransaction & ""

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        For p As Integer = 0 To dGrid.ColumnCount - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            If p = dGrid.Columns.Count - 1 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        'Disable all controls save for description and amount
        dtTrans.Enabled = False
        cboCashbook.Enabled = False
        cboContraAccount.Enabled = False
        cboTransType.Enabled = False

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Cashbook Transaction Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function LedgerAccountName(AccountNumber As String) As String
        Dim strReturn As String = Nothing
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountName FROM LedgerAccounts " _
            & "WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Cashbook Transaction Load"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Function CashbookAccountName(AccountNumber As String) As String
        Dim strReturn As String = Nothing
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountName FROM Cashbooks " _
            & "WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Cashbook Transaction Load"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub frmCashbookTransactionEdit_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 740 : Me.Height = 515
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadLedgerAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM LedgerAccounts WHERE AccountType = 'Expense' OR " _
            & "AccountType = 'INCOME' ORDER BY AccountNumber"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboContraAccount
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "260;100"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM LedgerAccounts " _
            & "WHERE AccountType = 'Expense' OR AccountType = 'INCOME' ", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboContraAccount.Items.Clear()
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
            cboContraAccount.SelectedIndex = -1
            cboContraAccount.Items.Clear()
            cboContraAccount.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboContraAccount.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Account Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCostCenters()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT CostCenterName +';'+ CONVERT(NVARCHAR, OrdinalNo) AS " _
            & "[Accounts] FROM SystemCostCenters WHERE OrdinalNo <> 0 ORDER BY CostCenterName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboCostCenter
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "160;80"
        End With
        'Get a count of the items


        Dim arrItems As New ArrayList
        arrItems.Add("--NONE--;0")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                arrItems.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        Dim intItemsCount As Integer = arrItems.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboCostCenter.Items.Clear()

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        If intItemsCount > 0 Then
            cboCostCenter.SelectedIndex = -1
            cboCostCenter.Items.Clear()
            cboCostCenter.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCostCenter.Items.AddRange(DropDownItems)
        End If
        cboCostCenter.SelectedIndex = 0
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Cost Center Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCashbooks()
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM Cashbooks ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
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

        cboCashbook.Items.Clear()
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

End Class
