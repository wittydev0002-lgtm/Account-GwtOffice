Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBillEntry

    Dim boolFormLoading As Boolean

    Private Sub frmBillEntry_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 775 : Me.Height = 580
    End Sub

    Private Sub frmBillEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        txtBatchNumber.Text = CStr(gwt_comm.GetNextDocumentNumber("BillBatchNumber "))
        LoadAccounts()
        LoadSuppliers()
        dGrid.Rows.Add(300)

        NumberAllRows()
        ComputeTotals()
        dGrid.CurrentCell = dGrid.Rows(0).Cells(1)
        boolFormLoading = False
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        With dGrid
            If .CurrentCell.ColumnIndex = 5 Or .CurrentCell.ColumnIndex = 6 Then
                If Not IsNumeric(.CurrentCell.Value) Then
                    MessageBox.Show("Please enter a numeric value in this column. Value will be reset to zero",
                        "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    .CurrentCell.Value = "0.00"
                Else
                    If .CurrentCell.ColumnIndex = 6 Then
                        .CurrentCell.Value = Format(CDbl(.CurrentCell.Value.ToString), "##0.00")
                    End If
                End If
                ' *** Compute the line total
                On Error Resume Next
                .CurrentRow.Cells(.ColumnCount - 1).Value = Format((CDbl(.CurrentRow.Cells(.ColumnCount - 2).Value.ToString) * CDbl(.CurrentRow.Cells(.ColumnCount - 3).Value.ToString)), "##0.00")
                ComputeTotals()
            End If
        End With
    End Sub

    Private Sub ComputeTotals()
        With dGrid
            Dim dblTotal As Double = 0
            For i As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(7).Value), "")) Then
                    If IsNumeric(Convert.ToString(.Rows(i).Cells(7).Value)) Then
                        dblTotal = dblTotal + CDbl(Convert.ToString(.Rows(i).Cells(7).Value))
                    End If
                End If
            Next
            lblTotal.Text = Format(dblTotal, "##0.00")
        End With
    End Sub

    Private Sub dGrid_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dGrid.RowsRemoved
        Dim iBal As Integer = 300 - dGrid.Rows.Count
        dGrid.Rows.Add(iBal)
        'AlternateColors()
        'NumberAllRows()
    End Sub

    Private Sub NumberAllRows()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            dGrid.Rows(i).HeaderCell.Value = (i + 1)
        Next
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

    Private Sub cboSuppliers_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSuppliers.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(3)
            dGrid.Focus()
        End If
    End Sub

    Private Sub cboSuppliers_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSuppliers.LostFocus
        cboSuppliers.Visible = False
    End Sub

    Private Sub cboSuppliers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSuppliers.SelectedIndexChanged
        CommitValueChanged()
    End Sub

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr
        If cboSuppliers.Focused = False Then Exit Sub
        If Not cboSuppliers.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(2).Value = cboSuppliers.SelectedItem.Col1
            dGrid.CurrentRow.Cells(3).Value = cboSuppliers.SelectedItem.Col2
            dGrid.CurrentRow.Cells(5).Value = "1.00"
        Else
            dGrid.CurrentRow.Cells(2).Value = Nothing
            dGrid.CurrentRow.Cells(3).Value = Nothing
            dGrid.CurrentRow.Cells(5).Value = ""
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On supplier information load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboAccounts_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAccounts.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(1)
            dGrid.Focus()
        End If
    End Sub

    Private Sub cboAccounts_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccounts.LostFocus
        cboAccounts.Visible = False
    End Sub

    Private Sub cboAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccounts.SelectedIndexChanged
        CommitAccounts()
    End Sub

    Private Sub CommitAccounts()
        On Error GoTo RaiseErr
        If cboAccounts.Focused = False Then Exit Sub
        If Not cboAccounts.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(0).Value = cboAccounts.SelectedItem.Col1
            dGrid.CurrentRow.Cells(1).Value = cboAccounts.SelectedItem.Col2
        Else
            dGrid.CurrentRow.Cells(0).Value = Nothing
            dGrid.CurrentRow.Cells(1).Value = Nothing
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On accounts information load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM LedgerAccounts ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboAccounts
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
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM LedgerAccounts", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboAccounts.Items.Clear()
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
            cboAccounts.SelectedIndex = -1
            cboAccounts.Items.Clear()
            cboAccounts.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboAccounts.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Account Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadSuppliers()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM Suppliers ORDER BY AccountName"
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
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM Suppliers", cnn)
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
        strErrorMessages = Err.Description & " " & Err.Number & " on Supplier Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter
        On Error GoTo RaiseErr
        If cboSuppliers.Visible = True Then cboSuppliers.Visible = False
        If cboAccounts.Visible = True Then cboAccounts.Visible = False
        If e.ColumnIndex = 2 Then
            If (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(0).Value), "")) Then Exit Sub
            LoadSuppliers()
            cboSuppliers.Size = dGrid.CurrentCell.Size
            cboSuppliers.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + pnlTop.Height + 27
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

        If e.ColumnIndex = 0 Then
            LoadAccounts()
            cboAccounts.Size = dGrid.CurrentCell.Size
            cboAccounts.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + pnlTop.Height + 27
            cboAccounts.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                cboAccounts.Text = Convert.ToString(dGrid.CurrentCell.Value)
            Else
                cboAccounts.Text = ""
            End If
            cboAccounts.Visible = True
            cboAccounts.Focus()
            cboAccounts.SelectAll()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item code search"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub SaveTransactions()
        On Error GoTo RaiseErr

        Dim intProcessedRecords As Integer = 0
        With dGrid
            'Check that all the mandatory data has been completed
            For i As Integer = 0 To .Rows.Count - 1
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "") Then
                    If Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "") Then
                        MessageBox.Show("Please enter the creditor account number on entry number " & (i + 1),
                            "Missing Creditor Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "") Then
                        If Not IsNumeric(.Rows(i).Cells(5).Value.ToString) Then
                            MessageBox.Show("Please enter a valid quantity value on entry number " & (i + 1),
                                "Invalid Quantity Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(6).Value), "") Then
                        If Not IsNumeric(.Rows(i).Cells(6).Value.ToString) Then
                            MessageBox.Show("Please enter the correct amount value on entry number " & (i + 1),
                                "Invalid Amount Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                End If
            Next


            For i As Integer = 0 To .Rows.Count - 1
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "") Then
                    Dim strLedgerAccount As String = Nothing
                    Dim strCreditorAccount As String = Nothing
                    Dim strDescription As String = Nothing
                    Dim dblQuantity As Double = 0
                    Dim dblAmount As Double = 0

                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "") Then
                        strLedgerAccount = .Rows(i).Cells(1).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "") Then
                        strCreditorAccount = .Rows(i).Cells(3).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "") Then
                        strDescription = .Rows(i).Cells(4).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "") Then
                        If IsNumeric(.Rows(i).Cells(5).Value.ToString) Then
                            dblQuantity = CDbl(.Rows(i).Cells(5).Value.ToString)
                        End If
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(6).Value), "") Then
                        If IsNumeric(.Rows(i).Cells(6).Value.ToString) Then
                            dblAmount = CDbl(.Rows(i).Cells(6).Value.ToString)
                        End If
                    End If

                    'Post the transaction to the bill entries account
                    Dim strSql As String = "INSERT INTO BillEntries ([LedgerAccount],[SupplierAccount],[Quantity],[Amount], " _
                        & "[BatchNumber],[TransDate],[UserName],[BranchName],[ChangeDate],[Description]) VALUES ('" & strLedgerAccount & "', " _
                        & "'" & strCreditorAccount & "', " & dblQuantity & ", " & dblAmount & ", " & txtBatchNumber.Text & ", " _
                        & "'" & gwt_comm.shortMonthDateFormat(dpDate.Value) & "', '" & strUserName & "', '" & strUserBranch & "', " _
                        & "'" & Now & "', '" & strDescription & "')"
                    Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                    intProcessedRecords = intProcessedRecords + 1

                    'Post the transaction to the relevant ledger account
                    If Not String.IsNullOrEmpty(strPublicCreditorsAccount) Then
                        strSql = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
                        & "[Description],[UserName],[UserBranch],[FolioReference]) VALUES " _
                        & "('" & strLedgerAccount & "', '" & gwt_comm.shortMonthDateFormat(dpDate.Value) & "', " & dblAmount & ", " _
                        & "'DEBIT', '" & strPublicCreditorsAccount & "', '" & strDescription & "', '" & strUserName & "', " _
                        & "'" & strUserBranch & "', 'BB" & CStr(txtBatchNumber.Text) & "')"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If

                    'Post the transaction to the relevant ledger creditors control account
                    If Not String.IsNullOrEmpty(strPublicCreditorsAccount) Then
                        strSql = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
                        & "[Description],[UserName],[UserBranch],[FolioReference]) VALUES " _
                        & "('" & strPublicCreditorsAccount & "', '" & gwt_comm.shortMonthDateFormat(dpDate.Value) & "', " & dblAmount & ", " _
                        & "'CREDIT', '" & strLedgerAccount & "', '" & strDescription & "', '" & strUserName & "', " _
                        & "'" & strUserBranch & "', 'BB" & CStr(txtBatchNumber.Text) & "')"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If

                    'Post the transaction to creditors transactions
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SupplierTransactions " _
                        & "([AccountNumber],[TransactionDate],[Amount],[TransactionType],[Description]," _
                        & "[ReferenceNumber],[UserName],[BranchName]) VALUES ('" & strCreditorAccount & "', " _
                        & "'" & gwt_comm.shortMonthDateFormat(dpDate.Value) & "', " & dblAmount & ", 'BILL ENTRY', " _
                        & "'" & strDescription & "', 'BB" & txtBatchNumber.Text & "', '" & strUserName & "', '" & strUserBranch & "')", cnn)
                    objCommand.ExecuteNonQuery()

                End If

            Next
        End With

        If intProcessedRecords > 0 Then
            Dim objUpdateBatchNumber As New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET BillBatchNumber = " & CInt(txtBatchNumber.Text) + 1 & "", cnn)
            objUpdateBatchNumber.ExecuteNonQuery()
            txtBatchNumber.Text = CInt(txtBatchNumber.Text) + 1
        End If

        MessageBox.Show("Bill entries batch has been processed successfully",
            "Bill Transaction Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Clear the grid
        dGrid.Rows.Clear()
        dGrid.Rows.Add(300)
        'AlternateColors()
        NumberAllRows()
        ComputeTotals()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on bill entries save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveTransactions()
    End Sub

    Private Sub dGrid_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dGrid.ColumnWidthChanged
        If boolFormLoading = True Then Exit Sub
        On Error Resume Next
        If cboSuppliers.Visible = True Then
            If dGrid.CurrentCell.ColumnIndex = 2 Then
                cboSuppliers.Size = dGrid.CurrentCell.Size
            End If
        End If
        If cboAccounts.Visible = True Then
            If dGrid.CurrentCell.ColumnIndex = 0 Then
                cboAccounts.Size = dGrid.CurrentCell.Size
            End If
        End If
    End Sub

    Private Sub dGrid_Scroll(sender As Object, e As ScrollEventArgs) Handles dGrid.Scroll
        cboSuppliers.Visible = False
        cboAccounts.Visible = False
    End Sub

End Class
