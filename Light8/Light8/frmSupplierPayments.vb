Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSupplierPayments

    Private Sub frmSupplierPayments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dGrid.Rows.Add(300)
        AlternateColors()
        NumberAllRows()
        LoadSuppliers()
        LoadCashbooks()
        dGrid.CurrentCell = dGrid.Rows(0).Cells(1)
    End Sub

    Private Sub LoadSuppliers()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM Suppliers WHERE CreditorType = 'NON TRADER' ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboSuppliers
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "180;100"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM Suppliers WHERE CreditorType = 'NON TRADER'", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboSuppliers.Items.Clear()
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
            cboSuppliers.SelectedIndex = -1
            cboSuppliers.Items.Clear()
            cboSuppliers.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboSuppliers.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Cashbooks Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SaveEntries()
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            For j As Integer = 0 To dGrid.ColumnCount - 1
                Dim backColor As Color = Color.White
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
            Next
        Next
        For i As Integer = 0 To dGrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
                dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub dGrid_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dGrid.CellBeginEdit
        If e.ColumnIndex > 0 And e.ColumnIndex <= 6 Then
            If (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(0).Value), "")) Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex = 5 Then
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

    Private Sub dGrid_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dGrid.RowsRemoved
        Dim iBal As Integer = 300 - dGrid.Rows.Count
        dGrid.Rows.Add(iBal)
        AlternateColors()
        NumberAllRows()
        ComputeTotals()
    End Sub

    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter
        On Error GoTo RaiseErr
        If cboSuppliers.Visible = True Then cboSuppliers.Visible = False
        If cboCashbook.Visible = True Then cboCashbook.Visible = False
        If e.ColumnIndex = 0 Then
            LoadSuppliers()
            cboSuppliers.Size = dGrid.CurrentCell.Size
            cboSuppliers.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + KryptonPanel1.Height + Bar1.Height
            cboSuppliers.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                cboSuppliers.Text = Convert.ToString(dGrid.CurrentCell.Value)
            Else
                cboSuppliers.Text = ""
            End If
            cboSuppliers.Visible = True '152
            cboSuppliers.Focus()
            cboSuppliers.SelectAll()
        End If

        If e.ColumnIndex = 4 Then
            If (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(0).Value), "")) Then Exit Sub
            LoadCashbooks()
            cboCashbook.Size = dGrid.CurrentCell.Size
            cboCashbook.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + KryptonPanel1.Height + Bar1.Height
            cboCashbook.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                cboCashbook.Text = Convert.ToString(dGrid.CurrentCell.Value)
            Else
                cboCashbook.Text = ""
            End If
            cboCashbook.Visible = True '152
            cboCashbook.Focus()
            cboCashbook.SelectAll()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item code search"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboSuppliers_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSuppliers.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(1)
            dGrid.Focus()
        End If
    End Sub

    Private Sub cboSuppliers_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSuppliers.LostFocus
        cboSuppliers.Visible = False
    End Sub

    Private Sub cboSuppliers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSuppliers.SelectedIndexChanged
        CommitValueChanged()
    End Sub

    Private Sub cboCashbook_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCashbook.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(5)
            dGrid.Focus()
        End If
    End Sub

    Private Sub cboCashbook_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCashbook.LostFocus
        cboSuppliers.Visible = False
    End Sub

    Private Sub cboCashbook_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCashbook.SelectedIndexChanged
        CommitCashbook()
    End Sub

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr
        If cboSuppliers.Focused = False Then Exit Sub
        If Not cboSuppliers.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(0).Value = cboSuppliers.SelectedItem.Col1
            dGrid.CurrentRow.Cells(1).Value = cboSuppliers.SelectedItem.Col2
            dGrid.CurrentRow.Cells(5).Value = "0"
        Else
            dGrid.CurrentRow.Cells(0).Value = Nothing
            dGrid.CurrentRow.Cells(1).Value = Nothing
            dGrid.CurrentRow.Cells(5).Value = ""
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On supplier information load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub CommitCashbook()
        On Error GoTo RaiseErr
        If cboCashbook.Focused = False Then Exit Sub
        If Not cboCashbook.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(4).Value = cboCashbook.SelectedItem.Col1
        Else
            dGrid.CurrentRow.Cells(4).Value = Nothing
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On cashbook information load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCashbooks()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountNumber +';'+AccountName AS " _
            & "[Accounts] FROM Cashbooks ORDER BY AccountNumber"
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

    Private Sub ComputeTotals()
        With dGrid
            Dim dblTotal As Double = 0
            For i As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "")) Then
                    If IsNumeric(Convert.ToString(.Rows(i).Cells(5).Value)) Then
                        dblTotal = dblTotal + CDbl(Convert.ToString(.Rows(i).Cells(5).Value))
                    End If
                End If
            Next
            lblTotalPayable.Text = Format(dblTotal, "#,##0.00")
        End With
    End Sub

    Private Sub chkOverrideDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverrideDate.CheckedChanged
        If chkOverrideDate.Checked = True Then
            If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
                dpDate.Enabled = True
            Else
                boolAbort = False
                boolAuthorized = False
                gwt_comm.SuperUserAuthentication()
                If boolAbort = True Then
                    chkOverrideDate.Checked = False
                    Exit Sub
                End If
                If boolAuthorized = True Then
                    dpDate.Enabled = True
                    boolAuthorized = False
                End If
            End If
        Else
            dpDate.Enabled = False
            boolAuthorized = False
        End If
    End Sub

    Private Sub SaveEntries()
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand

        With dGrid
            'First check that the mandatory information has been made
            For i As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then
                    If Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "") Then
                        MessageBox.Show("Missing cashbook account on entry line " & (i + 1), "Missing Cashbook Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "") Then
                        If Not IsNumeric(.Rows(i).Cells(5).Value.ToString) Then
                            MessageBox.Show("Please enter a valid value for amount on entry line " & (i + 1), "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Please enter a valid value for amount on entry line " & (i + 1), "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
            Next

            'Add the transactions to the table. The affected accounts are the cashbook, cashbook control, creditors control
            For i As Integer = 0 To dGrid.Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then
                    Dim strAccount As String = Nothing
                    Dim strDescription As String = Nothing
                    Dim strReference As String = Nothing
                    Dim strCashbook As String = Nothing
                    Dim dblAmount As Double = 0
                    Dim dblTaxAmount As Double = 0
                    Dim strName As String = Nothing
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "") Then
                        strName = .Rows(i).Cells(0).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "") Then
                        strAccount = .Rows(i).Cells(1).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "") Then
                        strReference = .Rows(i).Cells(2).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "") Then
                        strDescription = .Rows(i).Cells(3).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "") Then
                        strCashbook = .Rows(i).Cells(4).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "") Then
                        If IsNumeric(.Rows(i).Cells(5).Value.ToString) Then
                            dblAmount = CDbl(.Rows(i).Cells(5).Value.ToString)
                        End If
                    End If
                    'Get the vat figure if any
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(6).Value), "") Then
                        If IsNumeric(.Rows(i).Cells(6).Value.ToString) Then
                            dblTaxAmount = CDbl(.Rows(i).Cells(6).Value.ToString)
                        End If
                    End If

                    Dim intSpecialKey As Integer = gwt_comm.SpecialKey

                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SupplierTransactions " _
                        & "([AccountNumber],[TransactionDate],[Amount],[TransactionType],[Description]," _
                        & "[ReferenceNumber],[UserName],[BranchName],[Taxes], [SpecialKey]) VALUES ('" & strAccount & "', " _
                        & "'" & gwt_comm.shortMonthDateFormat(dpDate.Value) & "', " & dblAmount & ", 'PAYMENT', " _
                        & "'" & strDescription & "', '" & strReference & "', '" & strUserName & "', " _
                        & "'" & strUserBranch & "', " & dblTaxAmount & ", " & intSpecialKey & ")", cnn)
                    objCommand.ExecuteNonQuery()

                    'Credit the cashbook transaction
                    Dim strSql As String = "INSERT INTO CashbookTransactions (TransactionDate, Amount, Description, ContraAccount, " _
                                    & "UserName, UserBranch, TransactionType, AccountNumber, FolioReference, [SpecialKey]) VALUES " _
                                    & "('" & gwt_comm.shortMonthDateFormat(dpDate.Value) & "', " & dblAmount & ", '" & strDescription & "', " _
                                    & "'" & strPublicCreditorsAccount & "', '" & strUserName & "', '" & strUserBranch & "', 'CREDIT', " _
                                    & "'" & strCashbook & "', '" & strReference & "', " & intSpecialKey & ")"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                    'Post to the ledger cashbook control account if set
                    'If Not String.IsNullOrEmpty(strPublicCashControlAccount) Then
                    '    strSql = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
                    '    & "[Description],[UserName],[UserBranch],[FolioReference]) VALUES " _
                    '    & "('" & strPublicCashControlAccount & "', '" & Format(dpDate.Value, "dd-MMM-yyyy") & "', " & dblAmount & ", " _
                    '    & "'CREDIT', '" & strPublicCreditorsAccount & "', '" & strDescription & "', '" & strUserName & "', " _
                    '    & "'" & strUserBranch & "', '" & strReference & "')"
                    '    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    '    objCommand.ExecuteNonQuery()
                    'End If

                    'Post to the ledger creditots control account if set

                    If dblTaxAmount <> 0 Then
                        dblAmount = dblAmount - dblTaxAmount
                        If Not String.IsNullOrEmpty(strPublicVatControlAccount) Then
                            strSql = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
                            & "[Description],[UserName],[UserBranch],[FolioReference], [SpecialKey]) VALUES " _
                            & "('" & strPublicVatControlAccount & "', '" & gwt_comm.shortMonthDateFormat(dpDate.Value) & "', " & dblTaxAmount & ", " _
                            & "'DEBIT', '" & strPublicActiveCashbook & "', '" & strDescription & "', '" & strUserName & "', " _
                            & "'" & strUserBranch & "', '" & strReference & "', " & intSpecialKey & ")"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()
                        End If
                    End If

                    If Not String.IsNullOrEmpty(strPublicCreditorsAccount) Then
                        strSql = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
                        & "[Description],[UserName],[UserBranch],[FolioReference], [SpecialKey]) VALUES " _
                        & "('" & strPublicCreditorsAccount & "', '" & gwt_comm.shortMonthDateFormat(dpDate.Value) & "', " & dblAmount & ", " _
                        & "'DEBIT', '" & strPublicActiveCashbook & "', '" & strDescription & "', '" & strUserName & "', " _
                        & "'" & strUserBranch & "', '" & strReference & "', " & intSpecialKey & ")"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If

                End If
            Next
        End With

        MessageBox.Show("Payments processed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Clear the grid
        dGrid.Rows.Clear()
        dGrid.Rows.Add(300)
        AlternateColors()
        NumberAllRows()
        dGrid.CurrentCell = dGrid.Rows(0).Cells(1)

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On creditors payment entries save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub NumberAllRows()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            dGrid.Rows(i).HeaderCell.Value = (i + 1)
        Next
    End Sub

End Class
