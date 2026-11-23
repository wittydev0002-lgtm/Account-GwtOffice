Imports CommonLibrary.Commons
Imports CommonLibrary .Commons .CommonFunctions 
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmCashbookIncomes

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex = 2 Then
            dGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString), "##0.00")
            ComputeTotals()
        End If
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

    Private Sub cboAccounts_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAccounts.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(2)
            dGrid.Focus()
        End If
    End Sub

    Private Sub cboAccounts_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccounts.LostFocus
        cboAccounts.Visible = False
    End Sub

    Private Sub cboAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccounts.SelectedIndexChanged
        CommitAccounts()
    End Sub

    Private Sub cboCostCenter_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCostCenter.LostFocus
        cboCostCenter.Visible = False
    End Sub

    Private Sub cboCostCenter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCostCenter.SelectedIndexChanged
        CommitCenter()
    End Sub

    Private Sub CommitCenter()
        On Error GoTo RaiseErr
        If cboCostCenter.Focused = False Then Exit Sub
        If Not cboCostCenter.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(3).Value = cboCostCenter.SelectedItem.Col1
        Else
            dGrid.CurrentRow.Cells(3).Value = Nothing
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On cost center information load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub CommitAccounts()
        On Error GoTo RaiseErr
        If cboAccounts.Focused = False Then Exit Sub
        If Not cboAccounts.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(1).Value = cboAccounts.SelectedItem.Col2
            lblDescription.Text = cboAccounts.SelectedItem.Col1
        Else
            dGrid.CurrentRow.Cells(0).Value = Nothing
            dGrid.CurrentRow.Cells(1).Value = Nothing
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
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
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Account Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmCashbookIncomes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblAccountNumber.Text = UCase(strPublicActiveCashbook)
        LoadAccounts()
        loadCostCenters()
        dGrid.Rows.Add(500)
        AlternateColors()
    End Sub

    Private Sub LoadCostCenters()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT CONVERT(NVARCHAR, OrdinalNo) +';'+ CostCenterName AS " _
            & "[Accounts] FROM SystemCostCenters ORDER BY CostCenterName"
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
            .ColumnWidth = "80;140"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(OrdinalNo) FROM SystemCostCenters", cnn)
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
            cboCostCenter.SelectedIndex = -1
            cboCostCenter.Items.Clear()
            cboCostCenter.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCostCenter.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Cost Center Details Load"
        gwt_comm.ShowErrorMessage()
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

    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter
        On Error GoTo RaiseErr
        If cboAccounts.Visible = True Then cboAccounts.Visible = False
        If cboCostCenter.Visible = True Then cboCostCenter.Visible = False
        If e.ColumnIndex = 1 Then
            LoadAccounts()
            cboAccounts.Size = dGrid.CurrentCell.Size
            cboAccounts.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + 95
            cboAccounts.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                cboAccounts.Text = Convert.ToString(dGrid.CurrentCell.Value)
                'Get the ledger account description 
                Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountName FROM LedgerAccounts WHERE AccountNumber = '" & dGrid.CurrentCell.Value.ToString & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then lblDescription.Text = objReader(0).ToString
                End If
                objReader.Close()
            Else
                cboAccounts.Text = ""
            End If
            cboAccounts.Visible = True
            cboAccounts.Focus()
            cboAccounts.SelectAll()
        End If
        If e.ColumnIndex = 3 Then
            cboCostCenter.Size = dGrid.CurrentCell.Size
            cboCostCenter.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + 95
            cboCostCenter.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left

            cboCostCenter.Visible = True
            cboCostCenter.Focus()
            cboCostCenter.SelectAll()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item code search"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals()
        With dGrid
            Dim dblTotal As Double = 0
            For i As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "")) Then
                    If IsNumeric(Convert.ToString(.Rows(i).Cells(2).Value)) Then
                        dblTotal = dblTotal + CDbl(Convert.ToString(.Rows(i).Cells(2).Value))
                    End If
                End If
            Next
            lblTotal.Text = Format(dblTotal, "##0.00")
        End With
    End Sub

    Private Sub dGrid_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dGrid.RowsRemoved
        Dim iBal As Integer = 300 - dGrid.Rows.Count
        dGrid.Rows.Add(iBal)
        AlternateColors()
        NumberAllRows()
    End Sub

    Private Sub NumberAllRows()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            dGrid.Rows(i).HeaderCell.Value = (i + 1)
        Next
    End Sub


    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        For i As Integer = 0 To dGrid.Rows.Count - 1

            Dim strDescription As String = Nothing
            Dim strAccount As String = Nothing
            Dim dblAmount As Double = 0
            Dim intCostCenter As Integer = 0

            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "") Then
                strDescription = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
            End If
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                strAccount = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
            End If
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    dblAmount = Convert.ToDouble(dGrid.Rows(i).Cells(2).Value)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    intCostCenter = Convert.ToInt16(dGrid.Rows(i).Cells(3).Value)
                End If
            End If

            If dblAmount <> 0 Then
                If Not String.IsNullOrEmpty(strAccount) Then
                    If Not String.IsNullOrEmpty(strDescription) Then
                        'Get the journal entry number
                        'This will enable deleting a record entry in both the cashbook and ledger based on the reference number

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

                        'post the transaction to the cashbook and relevent ledger
                        Dim intSpecialKey As Integer = gwt_comm.SpecialKey()

                        Dim strSql As String = "INSERT INTO CashbookTransactions (TransactionDate, Amount, " _
                                & "Description, ContraAccount, UserName, UserBranch, TransactionType, AccountNumber, " _
                                & "Status, PaymentMethod, FolioReference, Reference, SpecialKey) VALUES " _
                                & "('" & Format(dpDate.Value, "dd-MMM-yyyy") & "', " & dblAmount & ", '" & strDescription & "', " _
                                & "'" & lblAccountNumber.Text & "', '" & strUserName & "', '" & strUserBranch & "', 'DEBIT', " _
                                & "'" & strPublicActiveCashbook & "', 'N', 'CASH', '', " & lngJvEntryNumber & ", " & intSpecialKey & ")"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()

                        gwt_comm.LedgerEntry("INSERT", CStr(Format(dpDate.Value, "dd-MMM-yyyy")), strAccount, _
                            lblAccountNumber.Text, strDescription, dblAmount, "CREDIT", , lngJvEntryNumber, 0, 0, 0, 0, 0, 0, intSpecialKey, intCostCenter)

                    End If
                End If
            End If
        Next
        MessageBox.Show("Cashbook incomes posted successfully", "Transaction Posting Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Clear the grid entries
        dGrid.Rows.Clear()
        dGrid.Rows.Add(500)
        AlternateColors()
        lblTotal.Text = "0.00"
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On cashbook incomes capture"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
