Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCashbookEntriesNewFormat

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub frmCashbookEntriesNewFormat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dGridDebits.Enabled = False
        dGridCredits.Enabled = False
        SuperTabControl1.SelectedTabIndex = 0
        boolAbort = False
        CreateCashbookBatchTable()
        If boolAbort = True Then Exit Sub
        LoadData()
    End Sub

    Private Sub dGridDebits_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridDebits.CellEndEdit
        'If e.ColumnIndex = 0 Then
        '    If Not Object.Equals(dGridDebits.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, Nothing) Then
        '        If Not String.IsNullOrEmpty(dGridDebits.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString) Then
        '            If Not IsDate(dGridDebits.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
        '                MessageBox.Show("The entry is not a valid date. Please re-enter", "Invalid Date Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                dGridDebits.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
        '                dGridDebits.Rows(e.RowIndex).Cells(0).Selected = True
        '            End If
        '        End If
        '    End If
        'End If

        'If e.ColumnIndex = 1 Then
        '    lblActiveLedgerName.Text = Nothing

        '    If Not Object.Equals(dGridDebits.CurrentCell.Value, Nothing) Then
        '        If Not String.IsNullOrEmpty(dGridDebits.CurrentCell.Value) Then
        '            If IsValidLedgerAccount(dGridDebits.CurrentCell.Value) = False Then
        '                strSelectedAccount = Nothing
        '                gwt_comm.SearchForLedgerAccount()
        '                dGridDebits.Rows(dGridDebits.CurrentRow.Index).Cells(1).Value = strSelectedAccount
        '                'MessageBox.Show("The ledger account entered is invalid", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                'dGridDebits.Rows(dGridDebits.CurrentRow.Index).Cells(1).Value = Nothing
        '                'dGridDebits.Rows(dGridDebits.CurrentRow.Index).Cells(1).Selected = True
        '            End If
        '        End If
        '    End If
        'End If

        If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
            If IsNumeric(dGridDebits.CurrentCell.Value) Then
                dGridDebits.CurrentCell.Value = Format(CDbl(dGridDebits.CurrentCell.Value), "##0.00")
            Else
                dGridDebits.CurrentCell.Value = "0.00"
            End If
            ComputeTotals()
        End If

        'If e.ColumnIndex = dGridDebits.ColumnCount - 2 Then
        '    NewEntryRoutine(dGridDebits)
        'End If

    End Sub

    Private Sub dGridCredits_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridCredits.CellEndEdit
        'If e.ColumnIndex = 0 Then
        '    If Not Object.Equals(dGridCredits.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, Nothing) Then
        '        If Not String.IsNullOrEmpty(dGridCredits.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString) Then
        '            If Not IsDate(dGridCredits.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
        '                MessageBox.Show("The entry is not a valid date. Please re-enter", "Invalid Date Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                dGridCredits.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
        '                dGridCredits.Rows(e.RowIndex).Cells(0).Selected = True
        '            End If
        '        End If
        '    End If
        'End If

        'If e.ColumnIndex = 1 Then
        '    lblActiveLedgerName.Text = Nothing
        '    If Not Object.Equals(dGridCredits.CurrentCell.Value, Nothing) Then
        '        If Not String.IsNullOrEmpty(dGridCredits.CurrentCell.Value) Then
        '            If IsValidLedgerAccount(dGridCredits.CurrentCell.Value) = False Then
        '                MessageBox.Show("The ledger account entered is invalid", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                dGridCredits.Rows(dGridCredits.CurrentRow.Index).Cells(1).Value = Nothing
        '                dGridCredits.Rows(dGridCredits.CurrentRow.Index).Cells(1).Selected = True
        '            End If
        '        End If
        '    End If
        'End If

        If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
            If IsNumeric(dGridCredits.CurrentCell.Value) Then
                dGridCredits.CurrentCell.Value = Format(CDbl(dGridCredits.CurrentCell.Value), "##0.00")
            Else
                dGridCredits.CurrentCell.Value = "0.00"
            End If
            ComputeTotals()
        End If

        If e.ColumnIndex = dGridCredits.ColumnCount - 2 Then
            NewEntryRoutine(dGridCredits)
        End If

    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr

        Dim dblDebits As Double = 0
        Dim dblCredits As Double = 0

        For p As Integer = 0 To dGridDebits.Rows.Count - 1
            If Not Object.Equals(dGridDebits.Rows(p).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridDebits.Rows(p).Cells(4).Value.ToString) Then
                    If IsNumeric(dGridDebits.Rows(p).Cells(4).Value.ToString) Then
                        dblDebits = dblDebits + CDbl(dGridDebits.Rows(p).Cells(4).Value.ToString)
                    End If
                End If
            End If
        Next

        For p As Integer = 0 To dGridCredits.Rows.Count - 1
            If Not Object.Equals(dGridCredits.Rows(p).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridCredits.Rows(p).Cells(4).Value.ToString) Then
                    If IsNumeric(dGridCredits.Rows(p).Cells(4).Value.ToString) Then
                        dblCredits = dblCredits + CDbl(dGridCredits.Rows(p).Cells(4).Value.ToString)
                    End If
                End If
            End If
        Next

        lblDebits.Text = Format(dblDebits, "#,##0.00")
        lblCredits.Text = Format(dblCredits, "#,##0.00")
        lblBalance.Text = Format(((dblDebits - dblCredits) + CDbl(lblBalanceBefore.text)), "#,##0.00")

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On totals compuatation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadOpenBatches(ByVal Cashbook As String)
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT CONVERT(NVARCHAR, [TransDate], 105) AS [TransDate], [ContraAccount], [Description], " _
           & "[Reference], CAST(ISNULL([Amount], 0) AS DECIMAL (10,2)) AS [Amt], CAST(ISNULL([Tax], 0) AS DECIMAL (10,2)) AS [Tax], " _
           & "[LinkedProject], [TransType], [VatNumber], [TransactionId] FROM CashbookBatchTransactions WHERE [Cashbook] = '" & Cashbook & "' AND " _
           & "[Status] = 'OPEN' ORDER BY [TransDate]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader("TransType").ToString) Then
                If UCase(objReader("TransType").ToString) = "CREDIT" Then
                    With dGridCredits
                        .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), Format(CDbl(objReader(4).ToString), "##0.00"), _
                                  Format(CDbl(objReader(5).ToString), "##0.00"), objReader(8), objReader(6), objReader(9))
                    End With
                Else
                    With dGridDebits
                        .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), Format(CDbl(objReader(4).ToString), "##0.00"), _
                                  Format(CDbl(objReader(5).ToString), "##0.00"), objReader(8), objReader(6), objReader(9))
                    End With
                End If
            End If
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On cash book transactions load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccount.SelectedIndexChanged

        lblAccountDescription.Text = ""
        dGridCredits.Rows.Clear()
        dGridDebits.Rows.Clear()

        If Not cboAccount.SelectedItem Is Nothing Then
            lblAccountDescription.Text = cboAccount.SelectedItem.Col2
            strPublicActiveCashbookName = lblAccountDescription.Text
            lblBalanceBefore.Text = Format(GetCashBookBalance(cboAccount.Text), "##0.00")

            boolAbort = False
            'Load any open batches after selection
            LoadOpenBatches(cboAccount.Text)
            If boolAbort = True Then Exit Sub

            'Add 1 row and scroll to the last grid rows
            With dGridDebits
                .Rows.Add(1)
                .Columns(0).DefaultCellStyle.Format = "##-##-####"
                .FirstDisplayedScrollingRowIndex = .RowCount - 1
                .Rows(.RowCount - 1).Cells(0).Selected = True
            End With
            With dGridCredits
                .Rows.Add(1)
                .Columns(0).DefaultCellStyle.Format = "##-##-####"
                .FirstDisplayedScrollingRowIndex = .RowCount - 1
                .Rows(.RowCount - 1).Cells(0).Selected = True
            End With

            'enable grids here
            dGridDebits.Enabled = True
            dGridCredits.Enabled = True

            ComputeTotals()

        End If
    End Sub

    Private Sub LoadData()
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
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Cashbooks Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function GetCashBookBalance(CashbookAccount As String) As Double
        Dim dblReturn As Double = 0

        dblDebits = 0 : dblCredits = 0

        Dim strSql As String = "SELECT SUM(Amount) FROM cashbooktransactions WHERE TransactionType = 'DEBIT'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblDebits = CDbl(objReader(0).ToString)
        End If
        objReader.Close()

        strSql = "SELECT SUM(Amount) FROM cashbooktransactions WHERE TransactionType = 'CREDIT'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblCredits = CDbl(objReader(0).ToString)
        End If
        objReader.Close()

        dblReturn = dblDebits - dblCredits

        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on selected cashbook balance computation"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub ShowOpenBatches()
        On Error GoTo RaiseErr

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on selected cashbook open batches show"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGridCredits_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridCredits.KeyDown
        'If e.KeyValue = 9 Then
        '    If dGridCredits.CurrentCell.ColumnIndex = dGridCredits.Columns.Count - 2 Then
        '        Dim arrValidateErrors As New ArrayList
        '        arrValidateErrors = ValidateInput(dGridCredits, dGridCredits.CurrentRow.Index)
        '        If arrValidateErrors Is Nothing Then
        '            dGridCredits.Rows.Add(1)
        '            dGridCredits.Rows(dGridCredits.Rows.Count - 1).Cells(0).Value = dGridCredits.Rows(dGridCredits.Rows.Count - 2).Cells(0).Value
        '        Else
        '            If arrValidateErrors.Count = 0 Then
        '                dGridCredits.Rows.Add(1)
        '                dGridCredits.Rows(dGridCredits.Rows.Count - 1).Cells(0).Value = dGridCredits.Rows(dGridCredits.Rows.Count - 2).Cells(0).Value
        '            Else
        '                For p As Integer = 0 To arrValidateErrors.Count - 1
        '                    Dim strBuffer() As String = Split(arrValidateErrors.Item(p), "|")
        '                    MessageBox.Show(strBuffer(1), "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                    dGridCredits.CurrentRow.Cells(CInt(strBuffer(0))).Selected = True
        '                    lblActiveLedgerName.Text = Nothing
        '                Next
        '            End If
        '        End If
        '    End If
        '    If dGridCredits.CurrentCell.ColumnIndex = 1 Then
        '        strSelectedAccount = Nothing
        '        gwt_comm.SearchForLedgerAccount()
        '        dGridCredits.Rows(dGridCredits.CurrentRow.Index).Cells(1).Value = strSelectedAccount
        '    End If
        'End If
        If e.KeyValue = Keys.Enter Or e.KeyValue = 9 Then
            If dGridDebits.CurrentCell.ColumnIndex = dGridDebits.ColumnCount - 1 Then
                NewEntryRoutine(dGridDebits)
            End If
        End If
    End Sub

    Private Function ValidateInput(Grid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView, RowIndex As Integer) As ArrayList
        Dim arrReturn As New ArrayList

        Dim boolValidate As Boolean = False

        For j As Integer = 0 To Grid.ColumnCount - 1
            If Not Object.Equals(Grid.Rows(RowIndex).Cells(j).Value, Nothing) Then
                If String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(j).Value.ToString) Then
                    boolValidate = True
                End If
            End If
        Next

        If boolValidate = False Then Exit Function

        Dim strDateIn As String = Nothing
        Dim strAccountIn As String = Nothing
        Dim strDescriptionIn As String = Nothing
        Dim dblAmountIn As Double = 0

        If Not Object.Equals(Grid.Rows(RowIndex).Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(0).Value.ToString) Then
                strDateIn = Grid.Rows(RowIndex).Cells(0).Value.ToString
                If Not IsDate(strDateIn) Then
                    arrReturn.Add("0|Invalid Transaction Date")
                End If
            End If
        End If

        If Not Object.Equals(Grid.Rows(RowIndex).Cells(1).Value, Nothing) Then
            If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(1).Value.ToString) Then
                strAccountIn = Grid.Rows(RowIndex).Cells(1).Value.ToString
                If IsValidLedgerAccount(strAccountIn) = False Then
                    arrReturn.Add("1|Invalid Ledger Account")
                End If
            End If
        End If

        If Not Object.Equals(Grid.Rows(RowIndex).Cells(3).Value, Nothing) Then
            If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(3).Value.ToString) Then
                strDescriptionIn = Grid.Rows(RowIndex).Cells(3).Value.ToString
                If String.IsNullOrEmpty(strDescriptionIn) Then
                    arrReturn.Add("3|The description is required")
                End If
            End If
        End If

        If Not Object.Equals(Grid.Rows(RowIndex).Cells(4).Value, Nothing) Then
            If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(4).Value.ToString) Then
                If IsNumeric(Grid.Rows(RowIndex).Cells(4).Value.ToString) Then
                    dblAmountIn = CDbl(Grid.Rows(RowIndex).Cells(4).Value.ToString)
                    If dblAmountIn = 0 Then
                        arrReturn.Add("4|Amount should be greater than zero")
                    End If
                Else
                    arrReturn.Add("4|Amount entered is not numeric")
                End If
            End If
        End If

        Return arrReturn
    End Function

    Private Sub dGridDebits_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridDebits.KeyDown
        'If e.KeyValue = 9 Then
        '    If dGridDebits.CurrentCell.ColumnIndex = dGridDebits.Columns.Count - 2 Then
        '        Dim arrValidateErrors As New ArrayList
        '        arrValidateErrors = ValidateInput(dGridDebits, dGridDebits.CurrentRow.Index)
        '        If arrValidateErrors Is Nothing Then
        '            dGridDebits.Rows.Add(1)
        '            dGridDebits.Rows(dGridDebits.Rows.Count - 1).Cells(0).Value = dGridDebits.Rows(dGridDebits.Rows.Count - 2).Cells(0).Value
        '        Else
        '            If arrValidateErrors.Count = 0 Then
        '                dGridDebits.Rows.Add(1)
        '                dGridDebits.Rows(dGridDebits.Rows.Count - 1).Cells(0).Value = dGridDebits.Rows(dGridDebits.Rows.Count - 2).Cells(0).Value
        '            Else
        '                For p As Integer = 0 To arrValidateErrors.Count - 1
        '                    Dim strBuffer() As String = Split(arrValidateErrors.Item(p), "|")
        '                    MessageBox.Show(strBuffer(1), "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '                    dGridDebits.CurrentRow.Cells(CInt(strBuffer(0))).Selected = True
        '                    lblActiveLedgerName.Text = Nothing
        '                Next
        '            End If
        '        End If
        '    End If

        'End If
        'If e.KeyValue = 118 Then
        '    If dGridDebits.CurrentCell.ColumnIndex = 1 Then
        '        strSelectedAccount = Nothing
        '        gwt_comm.SearchForLedgerAccount()
        '        dGridDebits.Rows(dGridDebits.CurrentRow.Index).Cells(1).Value = strSelectedAccount
        '    End If
        'End If
        If e.KeyData = Keys.Enter Then
            If dGridDebits.CurrentCell.ColumnIndex = dGridDebits.ColumnCount - 1 Then
                NewEntryRoutine(dGridDebits)
            End If
        End If
        e.Handled = True

    End Sub

    Private Sub dGridDebits_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridDebits.EditingControlShowing
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

    Private Sub dGridCredits_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridCredits.EditingControlShowing
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

    Private Function IsValidLedgerAccount(LedgerAccount As String) As Boolean
        On Error GoTo RaiseErr
        lblActiveLedgerName.Text = Nothing
        Dim boolReturn As Boolean = False
        Dim strSql As String = "SELECT AccountName FROM LedgerAccounts WHERE AccountNumber = '" & LedgerAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            boolReturn = True
            If Not IsDBNull(objReader(0).ToString) Then lblActiveLedgerName.Text = objReader(0).ToString
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on ledger account validation"
        gwt_comm.ShowErrorMessage()
    End Function

    'Private Sub dGridDebits_CellValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dGridDebits.CellValidating
    '    If e.ColumnIndex = 1 Then
    '        lblActiveLedgerName.Text = Nothing
    '        If Not Object.Equals(dGridDebits.CurrentCell.Value, Nothing) Then
    '            If Not String.IsNullOrEmpty(dGridDebits.CurrentCell.Value) Then
    '                If IsValidLedgerAccount(dGridDebits.CurrentCell.Value) = False Then
    '                    MessageBox.Show("The ledger account entered is invalid", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    dGridDebits.Rows(dGridDebits.CurrentRow.Index).Cells(1).Value = Nothing
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub dGridCredits_CellValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dGridCredits.CellValidating
    '    If e.ColumnIndex = 1 Then
    '        lblActiveLedgerName.Text = Nothing
    '        If Not Object.Equals(dGridCredits.CurrentCell.Value, Nothing) Then
    '            If Not String.IsNullOrEmpty(dGridCredits.CurrentCell.Value) Then
    '                If IsValidLedgerAccount(dGridCredits.CurrentCell.Value) = False Then
    '                    MessageBox.Show("The ledger account entered is invalid", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                    dGridCredits.Rows(dGridCredits.CurrentRow.Index).Cells(1).Value = Nothing
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub CreateCashbookBatchTable()
        On Error GoTo RaiseErr
        Dim strSql As String = "IF OBJECT_ID(N'CashbookBatchTransactions', N'U') IS NULL " _
            & "CREATE TABLE CashbookBatchTransactions ([TransDate][SmallDateTime] NOT NULL DEFAULT GetDate(), " _
            & "[ContraAccount][NVARCHAR](35) NOT NULL DEFAULT '', [Description][NVARCHAR](150) NOT NULL DEFAULT '', " _
            & "[Reference][NVARCHAR](50) NOT NULL DEFAULT '', [Amount][FLOAT] NOT NULL DEFAULT 0, " _
            & "[TransType][NVARCHAR](20) NOT NULL DEFAULT '', [Tax][FLOAT] NOT NULL DEFAULT 0, [LinkedProject][INT] NOT NULL DEFAULT 0, " _
            & "[TransactionId][INT] NOT NULL PRIMARY KEY IDENTITY (1,1), [Cashbook][NVARCHAR](35) NOT NULL DEFAULT '', " _
            & "[Status][NVARCHAR](12) NOT NULL DEFAULT 'OPEN', [VatNumber][NVARCHAR](35) NOT NULL DEFAULT '')"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on cash book batch table creation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSaveToBatch_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveToBatch.Click
        boolAbort = False
        SaveToBatch(dGridDebits, "DEBIT", "OPEN")
        If boolAbort = True Then Exit Sub
        SaveToBatch(dGridCredits, "CREDIT", "OPEN")
        If boolAbort = True Then Exit Sub
        MessageBox.Show("Cash book transactions saved to batch file successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub SaveToBatch(Grid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView, ByVal TransType As String, ByVal Status As String)
        On Error GoTo RaiseErr

        Dim arrValidateErrors As New ArrayList
        arrValidateErrors = ValidateInput(Grid, Grid.Rows.Count - 1)
        If Not arrValidateErrors Is Nothing Then
            If arrValidateErrors.Count > 0 Then
                For p As Integer = 0 To arrValidateErrors.Count - 1
                    Dim strBuffer() As String = Split(arrValidateErrors.Item(p), "|")
                    MessageBox.Show(strBuffer(1), "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Grid.CurrentRow.Cells(CInt(strBuffer(0))).Selected = True
                    lblActiveLedgerName.Text = Nothing
                Next
                Exit Sub
            End If
        End If

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        For RowIndex As Integer = 0 To Grid.Rows.Count - 1

            Dim strDateIn As String = Nothing
            Dim strAccountIn As String = Nothing
            Dim strDescriptionIn As String = Nothing
            Dim dblAmountIn As Double = 0
            Dim strReference As String = Nothing '2
            Dim dblVat As Double = 0 '5
            Dim intProject As Integer = 0 '6
            Dim strVatNumber As String = Nothing
            Dim intTransId As Integer = 0

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(0).Value.ToString) Then
                    strDateIn = Grid.Rows(RowIndex).Cells(0).Value.ToString
                    Dim strBuffer() As String = Split(strDateIn, "-")
                    strDateIn = Format(CInt(strBuffer(0)), "00") & "-" & MonthName(CInt(strBuffer(1)), True) & "-" & Format(CInt(strBuffer(2)), "0000")
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(1).Value.ToString) Then
                    strAccountIn = Grid.Rows(RowIndex).Cells(1).Value.ToString
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(2).Value.ToString) Then
                    strReference = Grid.Rows(RowIndex).Cells(2).Value.ToString
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(3).Value.ToString) Then
                    strDescriptionIn = Grid.Rows(RowIndex).Cells(3).Value.ToString
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(4).Value.ToString) Then
                    If IsNumeric(Grid.Rows(RowIndex).Cells(4).Value.ToString) Then
                        dblAmountIn = CDbl(Grid.Rows(RowIndex).Cells(4).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(5).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(5).Value.ToString) Then
                    If IsNumeric(Grid.Rows(RowIndex).Cells(5).Value.ToString) Then
                        dblVat = CDbl(Grid.Rows(RowIndex).Cells(5).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(6).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(6).Value.ToString) Then
                    strVatNumber = Grid.Rows(RowIndex).Cells(6).Value.ToString
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(7).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(7).Value.ToString) Then
                    If IsNumeric(Grid.Rows(RowIndex).Cells(7).Value.ToString) Then
                        intProject = CDbl(Grid.Rows(RowIndex).Cells(7).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(8).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(8).Value.ToString) Then
                    If IsNumeric(Grid.Rows(RowIndex).Cells(8).Value.ToString) Then
                        intTransId = CInt(Grid.Rows(RowIndex).Cells(8).Value.ToString)
                    End If
                End If
            End If

            If Not String.IsNullOrEmpty(strDateIn) And Not String.IsNullOrEmpty(strDescriptionIn) And Not String.IsNullOrEmpty(strAccountIn) _
                And dblAmountIn <> 0 Then
                boolAbort = False
                DeleteTransaction(intTransId)
                If boolAbort = True Then Exit Sub
                strSql = "INSERT INTO CashbookBatchTransactions ([TransDate], [ContraAccount], [Description], [Reference], [Amount], " _
                    & "[TransType], [Tax], [LinkedProject], [Cashbook], [Status], [VatNumber]) VALUES ('" & strDateIn & "', '" & strAccountIn & "', " _
                    & "'" & strDescriptionIn & "', '" & strReference & "', " & dblAmountIn & ", '" & TransType & "', " & dblVat & ", " _
                    & "" & intProject & ", '" & cboAccount.Text & "', '" & Status & "', '" & strVatNumber & "')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If

        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on cash book batch transactions save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub PostToCashbook(Grid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView, ByVal TransType As String)
        On Error GoTo RaiseErr

        Dim arrValidateErrors As New ArrayList
        arrValidateErrors = ValidateInput(Grid, Grid.Rows.Count - 1)

        If Not arrValidateErrors Is Nothing Then
            For p As Integer = 0 To arrValidateErrors.Count - 1
                Dim strBuffer() As String = Split(arrValidateErrors.Item(p), "|")
                MessageBox.Show(strBuffer(1), "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Grid.CurrentRow.Cells(CInt(strBuffer(0))).Selected = True
                lblActiveLedgerName.Text = Nothing
            Next
            Exit Sub
        End If

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        For RowIndex As Integer = 0 To Grid.Rows.Count - 1

            Dim strDateIn As String = Nothing
            Dim strAccountIn As String = Nothing
            Dim strDescriptionIn As String = Nothing
            Dim dblAmountIn As Double = 0
            Dim strReference As String = Nothing '2
            Dim dblVat As Double = 0 '5
            Dim intProject As Integer = 0 '6
            Dim strVatNumber As String = Nothing
            Dim intTransId As Integer = 0

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(0).Value.ToString) Then
                    strDateIn = Grid.Rows(RowIndex).Cells(0).Value.ToString
                    Dim strBuffer() As String = Split(strDateIn, "-")
                    strDateIn = Format(CInt(strBuffer(0)), "00") & "-" & MonthName(CInt(strBuffer(1)), True) & "-" & Format(CInt(strBuffer(2)), "0000")
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(1).Value.ToString) Then
                    strAccountIn = Grid.Rows(RowIndex).Cells(1).Value.ToString
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(2).Value.ToString) Then
                    strReference = Grid.Rows(RowIndex).Cells(2).Value.ToString
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(3).Value.ToString) Then
                    strDescriptionIn = Grid.Rows(RowIndex).Cells(3).Value.ToString
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(4).Value.ToString) Then
                    If IsNumeric(Grid.Rows(RowIndex).Cells(4).Value.ToString) Then
                        dblAmountIn = CDbl(Grid.Rows(RowIndex).Cells(4).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(5).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(5).Value.ToString) Then
                    If IsNumeric(Grid.Rows(RowIndex).Cells(5).Value.ToString) Then
                        dblVat = CDbl(Grid.Rows(RowIndex).Cells(5).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(6).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(6).Value.ToString) Then
                    strVatNumber = Grid.Rows(RowIndex).Cells(6).Value.ToString
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(7).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(7).Value.ToString) Then
                    If IsNumeric(Grid.Rows(RowIndex).Cells(7).Value.ToString) Then
                        intProject = CDbl(Grid.Rows(RowIndex).Cells(7).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(Grid.Rows(RowIndex).Cells(8).Value, Nothing) Then
                If Not String.IsNullOrEmpty(Grid.Rows(RowIndex).Cells(8).Value.ToString) Then
                    If IsNumeric(Grid.Rows(RowIndex).Cells(8).Value.ToString) Then
                        intTransId = CDbl(Grid.Rows(RowIndex).Cells(8).Value.ToString)
                    End If
                End If
            End If

            Dim intSpecialKey As Integer = gwt_comm.SpecialKey()

            If Not String.IsNullOrEmpty(strDateIn) And Not String.IsNullOrEmpty(strDescriptionIn) And Not String.IsNullOrEmpty(strAccountIn) _
                And dblAmountIn <> 0 Then

                Dim strSqlLedger As String = Nothing

                If UCase(TransType) = "DEBIT" Then
                    strSql = "INSERT INTO CashbookTransactions (TransactionDate, Amount, Description, ContraAccount, " _
                       & "UserName, UserBranch, TransactionType, AccountNumber, UserReference, VatAmount, VatNumber, LinkedProject, SpecialKey) VALUES " _
                       & "('" & strDateIn & "', " & dblAmountIn & ", '" & strDescriptionIn & "', " _
                       & "'" & strAccountIn & "', '" & strUserName & "', '" & strUserBranch & "', '" & TransType & "', " _
                       & "'" & cboAccount.Text & "', '" & strReference & "', " & dblVat & ", '" & strVatNumber & "', " _
                       & "" & intProject & ", " & intSpecialKey & ")"
                Else
                    strSql = "INSERT INTO CashbookTransactions (TransactionDate, Amount, Description, ContraAccount, " _
                       & "UserName, UserBranch, TransactionType, AccountNumber, UserReference, VatAmount, VatNumber, LinkedProject, SpecialKey) VALUES " _
                       & "('" & strDateIn & "', " & dblAmountIn & ", '" & strDescriptionIn & "', " _
                       & "'" & strAccountIn & "', '" & strUserName & "', '" & strUserBranch & "', '" & TransType & "', " _
                       & "'" & cboAccount.Text & "', '" & strReference & "', " & dblVat & ", '" & strVatNumber & "', " _
                       & "" & intProject & ", " & intSpecialKey & ")"
                End If
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                'objCommand = New Data.OleDb.OleDbCommand(strSqlLedger, cnn)
                'objCommand.ExecuteNonQuery()

                If dblVat <> 0 Then
                    'post to the vat control account
                    If String.IsNullOrEmpty(strPublicTaxesAccount) Then
                        MessageBox.Show("The taxes control account has not been setup. This will seriously affect the trial balance", _
                            "Taxes Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Dim strProcessStatus As String = Nothing
                        If UCase(TransType) = "DEBIT" Then
                            strProcessStatus = gwt_comm.LedgerEntry("INSERT", strDateIn, strPublicTaxesAccount, _
                                strAccountIn, strDescriptionIn, dblVat, "DEBIT", _
                                strReference, , , , 0, 0, 0, 0, intSpecialKey)
                        Else
                            strProcessStatus = gwt_comm.LedgerEntry("INSERT", strDateIn, strPublicTaxesAccount, _
                                strAccountIn, strDescriptionIn, dblVat, "CREDIT", _
                                strReference, , , , 0, 0, 0, 0, intSpecialKey)
                        End If
                        If strProcessStatus <> "SUCCESS" Then GoTo RaiseErr
                    End If
                End If

                'Post to the ledger contra account
                Dim strContraType As String = Nothing
                If UCase(TransType) = "DEBIT" Then
                    strContraType = "CREDIT"
                Else
                    strContraType = "DEBIT"
                End If

                Dim lngCostCode As Long = 0 'This is the cost code. In future allow users to enter the cost code

                strSql = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
                    & "[Description],[UserName],[UserBranch],[Reference], [CostCode], [SpecialKey]) VALUES " _
                    & "('" & strAccountIn & "', '" & strDateIn & "', " & dblAmountIn & ", " _
                    & "'" & strContraType & "', '" & strPublicActiveCashbook & "', '" & strDescriptionIn & "', '" & strUserName & "', " _
                    & "'" & strUserBranch & "', '" & strReference & "', " & lngCostCode & ", " & intSpecialKey & ")"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                'Update status to closed in the cashbook batch transactions table
                strSql = "UPDATE CashbookBatchTransactions SET Status = 'CLOSED' WHERE TransactionId = " & intTransId & ""
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

            End If

        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on cash book batch transactions save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSaveAndClose_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAndClose.Click
        boolAbort = False
        SaveToBatch(dGridDebits, "DEBIT", "CLOSED")
        If boolAbort = True Then Exit Sub
        SaveToBatch(dGridCredits, "CREDIT", "CLOSED")
        If boolAbort = True Then Exit Sub
        PostToCashbook(dGridDebits, "DEBIT")
        If boolAbort = True Then Exit Sub
        PostToCashbook(dGridCredits, "CREDIT")
        If boolAbort = True Then Exit Sub
        MessageBox.Show("Cash book transactions saved to batch file and updated into cash book successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub DeleteTransaction(ByVal TransactionId As Integer)
        On Error GoTo RaiseErr
        Dim strSql As String = "DELETE FROM CashbookBatchTransactions WHERE TransactionId = " & TransactionId & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on cash book batch transactions delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If dGridDebits.Rows.Count > 0 Then
                If MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Transaction Delete", _
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    boolAbort = False
                    Dim intTransId As Integer = 0
                    If Not Object.Equals(dGridDebits.CurrentRow.Cells(dGridDebits.Columns.Count - 1).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(dGridDebits.CurrentRow.Cells(dGridDebits.Columns.Count - 1).Value.ToString) Then
                            If IsNumeric(dGridDebits.CurrentRow.Cells(dGridDebits.Columns.Count - 1).Value.ToString) Then
                                intTransId = CInt(dGridDebits.CurrentRow.Cells(dGridDebits.Columns.Count - 1).Value.ToString)
                                DeleteTransaction(intTransId)
                                If boolAbort = False Then
                                    MessageBox.Show("Transaction has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    dGridDebits.Rows.RemoveAt(dGridDebits.CurrentRow.Index)
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Else
            If dGridCredits.Rows.Count > 0 Then
                If MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Transaction Delete", _
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    boolAbort = False
                    Dim intTransId As Integer = 0
                    If Not Object.Equals(dGridCredits.CurrentRow.Cells(dGridCredits.Columns.Count - 1).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(dGridCredits.CurrentRow.Cells(dGridCredits.Columns.Count - 1).Value.ToString) Then
                            If IsNumeric(dGridCredits.CurrentRow.Cells(dGridCredits.Columns.Count - 1).Value.ToString) Then
                                intTransId = CInt(dGridCredits.CurrentRow.Cells(dGridCredits.Columns.Count - 1).Value.ToString)
                                DeleteTransaction(intTransId)
                                If boolAbort = False Then
                                    MessageBox.Show("Transaction has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    dGridCredits.Rows.RemoveAt(dGridCredits.CurrentRow.Index)
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dGridCredits_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridCredits.CellEnter
        If e.ColumnIndex = 1 Then
            strSelectedAccount = Nothing
            gwt_comm.SearchForLedgerAccount()
            dGridCredits.CurrentCell.Value = strSelectedAccount
        End If
    End Sub

    Private Sub dGridDebits_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridDebits.CellEnter
        If e.ColumnIndex = 1 Then
            strSelectedAccount = Nothing
            gwt_comm.SearchForLedgerAccount()
            dGridDebits.CurrentCell.Value = strSelectedAccount
        End If
    End Sub

    Private Sub NewEntryRoutine(ByVal myGrid As AdvancedDataGridViewControl.AdvancedDatagridview)
        If String.IsNullOrEmpty(strPublicActiveCashbook) Then Exit Sub
        myGrid.Rows.Add(1)
        myGrid.CurrentCell = myGrid.Rows(myGrid.Rows.Count - 1).Cells(0)
        myGrid.Rows(myGrid.Rows.Count - 1).Cells(0).Selected = True
        ComputeTotals()
    End Sub

End Class