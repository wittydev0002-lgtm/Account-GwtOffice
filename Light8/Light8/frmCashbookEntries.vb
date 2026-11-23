Imports CommonLibrary
Imports CommonLibrary.Commons
Imports System.Windows.Forms

Public Class frmCashbookEntries

    Private Sub btnAccept_Click(sender As System.Object, e As System.EventArgs) Handles btnAccept.Click
        If String.IsNullOrEmpty(lblLedgerAccount.Text) Then
            MessageBox.Show("Please select the ledger account", "Invalid Ledger Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboContraAccount.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboContraAccount.Text) Then
            MessageBox.Show("Please select the ledger account", "Invalid Ledger Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboContraAccount.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblCostCenter.Text) Then
            MessageBox.Show("Please select the correct cost center", "Invalid Cost Center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCostCenter.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboCostCenter.Text) Then
            MessageBox.Show("Please select the correct cost center", "Invalid Cost Center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCostCenter.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please a description for the transaction", "Invalid Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please a valid amount for the transaction", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboCashbook.Text) Then
            MessageBox.Show("Please specify the cashbook", "Invalid Transaction Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCashbook.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblCashbook.Text) Then
            MessageBox.Show("Please specify the cashbook", "Invalid Transaction Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            lblCashbook.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboTransType.Text) Then
            MessageBox.Show("Please specify the transaction type", "Invalid Transaction Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboTransType.Focus()
            Exit Sub
        End If

        If CDbl(txtAmount.Text) = 0 Then
            MessageBox.Show("Amount must be not be equal to zero", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
        'Add the information to then grid
        With dGrid
            .Rows.Add(Format(dtTrans.Value, "dd-MMM-yyyy"), txtDescription.Text, _
                cboTransType.Text, lblCashbook.Text, lblLedgerAccount.Text, cboContraAccount.Text, _
                lblCostCenter.Text, txtReference.Text, txtAmount.Text)
            ComputeTotals()
            txtDescription.Clear()
            cboContraAccount.Text = Nothing
            cboCostCenter.SelectedIndex = 0
            txtReference.Clear()
            txtAmount.Text = "0.00"
            txtDescription.Focus()
        End With
    End Sub

    Private Sub frmCashbookEntries_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblCostCenter.Text = Nothing
        lblLedgerAccount.Text = Nothing
        LoadLedgerAccounts()
        LoadCostCenters()
        LoadCashbooks()
    End Sub

    Private Sub LoadLedgerAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM LedgerAccounts WHERE AccountType = 'Expense' OR " _
            & "AccountType = 'INCOME' ORDER BY AccountName"
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

    Private Sub cboContraAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboContraAccount.SelectedIndexChanged
        On Error Resume Next
        lblLedgerAccount.Text = Nothing
        If Not cboContraAccount.SelectedItem Is Nothing Then
            lblLedgerAccount.Text = cboContraAccount.SelectedItem.Col2
        End If
    End Sub

    Private Sub cboCostCenter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCostCenter.SelectedIndexChanged
        On Error Resume Next
        lblCostCenter.Text = ""
        If Not cboCostCenter.SelectedItem Is Nothing Then
            lblCostCenter.Text = cboCostCenter.SelectedItem.Col2
        End If
    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr
        Dim dblDebitTotal As Double = 0
        Dim dblCreditTotal As Double = 0
        For i As Integer = 0 To dGrid.RowCount - 1
            Dim strType As String = Nothing
            Dim dblAmount As Double = 0
            If Not Object.Equals(dGrid.Rows(i).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    strType = UCase(dGrid.Rows(i).Cells(3).Value.ToString)
                End If
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(8).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(8).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(8).Value.ToString) Then
                        dblAmount = CDbl(dGrid.Rows(i).Cells(8).Value.ToString)
                    End If
                End If
            End If
            If UCase(strType) = "CREDIT" Then
                dblCreditTotal = dblCreditTotal + dblAmount
            Else
                dblDebitTotal = dblDebitTotal + dblAmount
            End If
        Next
        lblDebits.Text = Format(dblDebitTotal, "#,##0.00")
        lblCredits.Text = Format(dblCreditTotal, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on amount totals computation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtDescription_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtReference.Focus()
        End If
    End Sub

    Private Sub txtReference_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtReference.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cboContraAccount.Focus()
        End If
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyValue = Keys.Enter Then
            cboCashbook.Focus()
        End If
    End Sub

    Private Sub cboTransType_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTransType.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnAccept.Focus()
        End If
    End Sub

    Private Sub dtTrans_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtTrans.KeyDown
        If e.KeyValue = Keys.Enter Then
            cboCostCenter.Focus()
        End If
    End Sub

    Private Sub dGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellClick
        On Error GoTo RaiseErr
        If dGrid.CurrentCell.ColumnIndex = 9 Then
            If MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
                ComputeTotals()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On cashbook transaction delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click

        If dGrid.Rows.Count <= 0 Then
            MessageBox.Show("No transactions have been captured. Process will be aborted", "Process Stopped", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        On Error GoTo RaiseErr

        Dim lngJvEntryNumber As Long = 1
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT TransactionId FROM LedgerTransactions ORDER BY TransactionId DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                lngJvEntryNumber = CLng(objReader(0).ToString) + 1
            End If
        End If
        objReader.Close()

        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions


        For p As Integer = 0 To dGrid.Rows.Count - 1

            Dim intSpecialKey As Integer = gwt_comm.SpecialKey()

            Dim strEntryType As String = Nothing
            Dim strDescription As String = Nothing
            Dim dblTransAmount As Double = 0
            Dim strTransDate As String = Nothing
            Dim strContraAccount As String = Nothing
            Dim strCostCode As String = Nothing
            Dim strReference As String = Nothing
            Dim strCashbook As String = Nothing

            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strTransDate = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    strDescription = dGrid.Rows(p).Cells(1).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    strEntryType = dGrid.Rows(p).Cells(2).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(3).Value.ToString) Then
                    strCashbook = dGrid.Rows(p).Cells(3).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(4).Value.ToString) Then
                    strContraAccount = dGrid.Rows(p).Cells(4).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(6).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(6).Value.ToString) Then
                    strCostCode = dGrid.Rows(p).Cells(6).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(7).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(7).Value.ToString) Then
                    strReference = dGrid.Rows(p).Cells(7).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(8).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(8).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(8).Value.ToString) Then
                        dblTransAmount = CDbl(dGrid.Rows(p).Cells(8).Value.ToString)
                    End If
                End If
            End If

            Dim strSql As String = "INSERT INTO CashbookTransactions (TransactionDate, Amount, Description, ContraAccount, " _
                    & "UserName, UserBranch, TransactionType, AccountNumber, Reference, VatAmount, VatNumber, LinkedProject, SpecialKey, UserReference) VALUES " _
                    & "('" & strTransDate & "', " & dblTransAmount & ", '" & strDescription & "', " _
                    & "'" & strContraAccount & "', '" & strUserName & "', '" & strUserBranch & "', '" & strEntryType & "', " _
                    & "'" & strCashbook & "', " & lngJvEntryNumber & ", 0, '', " _
                    & "0, " & intSpecialKey & ", '" & strReference & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            'Post the account to the contra ledger account based on the cost centers
            '
            Dim strContraType As String = Nothing
            If strEntryType = "DEBIT" Then strContraType = "CREDIT" Else strContraType = "DEBIT"

            Dim lngCostCode As Long = CLng(strCostCode)

            strSql = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
                & "[Description],[UserName],[UserBranch],[Reference], [CostCode], [SpecialKey], [FolioReference]) VALUES " _
                & "('" & strContraAccount & "', '" & strTransDate & "', " & dblTransAmount & ", " _
                & "'" & strContraType & "', '" & strCashbook & "', '" & strDescription & "', '" & strUserName & "', " _
                & "'" & strUserBranch & "', " & lngJvEntryNumber & ", " & lngCostCode & ", " & intSpecialKey & ", '" & strReference & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

        Next

        MessageBox.Show("Transactions have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        dGrid.Rows.Clear()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On cashbook transactions save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboCashbook_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCashbook.KeyDown
        If e.KeyValue = Keys.Enter Then
            cboTransType.Focus()
        End If
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

    Private Sub cboCashbook_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCashbook.SelectedIndexChanged
        lblCashbook.Text = ""
        If Not cboCashbook.SelectedItem Is Nothing Then
            lblCashbook.Text = cboCashbook.SelectedItem.Col2
        End If
    End Sub

    Private Sub frmCashbookEntries_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 756 : Me.Height = 545
    End Sub

End Class