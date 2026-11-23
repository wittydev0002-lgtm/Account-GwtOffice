Imports System.Transactions

Public Class frmLaschPremiumPayments

    Dim boolLoading As Boolean

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

    Private Sub dGrid_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If boolLoading = True Then Exit Sub
        With dGrid
            Dim dblTotal As Double = 0
            If e.ColumnIndex = 2 Then
                If e.RowIndex = 0 Then
                    If IsNumeric(dGrid.CurrentCell.Value) Then
                        If CDbl(dGrid.CurrentCell.Value) = "36.00" Or CDbl(dGrid.CurrentCell.Value) = "0.00" Then
                            'do nothing 
                        Else
                            MessageBox.Show("Value for this field can only be 36.00 or 0.00", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            dGrid.CurrentCell.Value = "0.00"
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Invalid data input", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        dGrid.CurrentCell.Value = "0.00"
                        Exit Sub
                    End If
                End If
                If IsNumeric(dGrid.CurrentCell.Value) Then
                    ComputeTotal()
                End If
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")
                txtAmount.Text = Format(dblTotal, "##0.00")
            End If
        End With
        If e.ColumnIndex = 2 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
            ComputeTotal()
        End If
    End Sub

    Private Sub ComputeTotal()
        Dim dblTotal As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    dblTotal = dblTotal + CDbl(dGrid.Rows(i).Cells(2).Value.ToString)
                End If
            End If
        Next
        txtAmount.Text = Format(dblTotal, "##0.00")
    End Sub

    Private Sub cboAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccount.SelectedIndexChanged
        lblAccountDescription.Text = ""
        If Not cboAccount.SelectedItem Is Nothing Then
            lblAccountDescription.Text = cboAccount.SelectedItem.Col2
        End If
    End Sub

    'Private Sub cboName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboName.KeyPress
    '    txtAccountHolderNumber.Text = ""
    'End Sub

    Private Sub cboName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboName.SelectedIndexChanged
        txtAccountHolderNumber.Text = ""
        txtAccountHolderNumber.Text = cboName.SelectedItem.Col2
        LoadTransactions(txtAccountHolderNumber.Text)
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
        strErrorMessages = Err.Description & " " & Err.Number & " on Cashbooks Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmLaschPremiumPayments_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
        CustomerLoadData()
        dGrid.Rows.Add("APPLICATION FEES", "", "0.00")
        dGrid.Rows.Add("PREMIUM PAYMENTS", "", "0.00")
        ComputeTotal()
        dGridTransactions.Columns.Clear()
    End Sub

    Private Sub CustomerLoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT LastName +' '+FirstName +' '+ OtherNames +';'+ AccountNumber AS [Customer] " _
            & "FROM LaschCustomers ORDER BY LastName, FirstName, OtherNames"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Set up the drop down combo box
        Dim intWidth As Integer = cboName.Width - 50
        With cboName
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "250;80"
        End With

        'Get a count of the items
        Dim intItemsCount As Double = 0

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(AccountNumber) FROM LaschCustomers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()

        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboName.Items.Clear()
        Dim p As Double = 0

        'Continue to read until you reach the end of the file.
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            End If
            p = p + 1
        End While
        objReader.Close()

        If intItemsCount > 0 Then
            cboName.SelectedIndex = -1
            cboName.Items.Clear()
            cboName.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboName.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " On customers details load"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub txtAmount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmount.Validating
        If String.IsNullOrEmpty(txtAmount.Text) Then Exit Sub
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to proceed and save this transaction?", "Confirm Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblAccountDescription.Text) Then
            MessageBox.Show("Please select the cashbook account to use", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccount.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountHolderNumber.Text) Then
            MessageBox.Show("Please select the account holder name", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccount.Focus()
            Exit Sub
        End If
        
        Dim dpProcessDate As Date = Format(DateTime.Now, "dd-MMM-yyyy")
        txtReference.Text = CStr(GetNextDocumentNumber("CashSales"))

        If chkOverideDate.Checked = True Then
            dpProcessDate = Format(dpTransDate.Value, "dd-MMM-yyyy")
        End If

        Dim myCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = Nothing
        Dim strCashbookDescription As String = Nothing
        Dim dblSumPayable As Double = 0

        'Update the cashbook with the values

        'If IsNumeric(txtAmount.Text) Then dblSumPayable = CDbl(txtAmount.Text)

        Dim intKey As Integer = SpecialKey()

        ' Check for reciept number
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strReceipt As String = Nothing
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value) Then
                    If CDbl(dGrid.Rows(i).Cells(2).Value.ToString) <> 0 Then
                        If Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                            MessageBox.Show("Missing the receipt number. Please enter it", "Missing Receipt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Next

        'Make it a sql transaction
        Dim [option] = New TransactionOptions With {.IsolationLevel = IsolationLevel.ReadCommitted, .Timeout = TimeSpan.FromSeconds(60)}

        Using InputTransactions = New TransactionScope(TransactionScopeOption.Required, [option])

            For i As Integer = 0 To dGrid.Rows.Count - 1

                Dim strTransDescription As String = dGrid.Rows(i).Cells(0).Value.ToString
                Dim strReceiptNumber As String = Nothing

                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                    strReceiptNumber = dGrid.Rows(i).Cells(1).Value.ToString
                End If

                dblSumPayable = 0
                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "") Then
                    If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                        dblSumPayable = CDbl(dGrid.Rows(i).Cells(2).Value.ToString)
                    End If
                End If

                If dblSumPayable <> 0 Then

                    If UCase(strTransDescription) = "APPLICATION FEES" Then

                        strCashbookDescription = "APPLICATION FEES: " & UCase(cboName.Text) & "-" & UCase(txtAccountHolderNumber.Text)
                        strSql = "INSERT INTO CashbookTransactions (AccountNumber, TransactionDate, Amount, Description, ContraAccount, " _
                            & "UserName, UserBranch, TransactionType, Reference, SpecialKey, FolioReference) VALUES " _
                            & "('" & strPublicActiveCashbook & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " & dblSumPayable & ", " _
                            & "'" & strCashbookDescription & "-" & txtAccountHolderNumber.Text & "', '" & strPublicSalesAccount & "', " _
                            & "'" & strUserName & "', '" & strUserBranch & "', 'DEBIT', " & Convert.ToDouble(txtReference.Text) & ", " _
                            & "" & intKey & ", '" & strReceiptNumber & "')"
                        myCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        myCommand.ExecuteNonQuery()

                    Else
                        strCashbookDescription = "PREMIUM PAYMENTS: " & UCase(cboName.Text) & "-" & UCase(txtAccountHolderNumber.Text)
                        strSql = "INSERT INTO CashbookTransactions (AccountNumber, TransactionDate, Amount, Description, ContraAccount, " _
                            & "UserName, UserBranch, TransactionType, Reference, SpecialKey, FolioReference) VALUES " _
                            & "('" & strPublicActiveCashbook & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " & dblSumPayable & ", " _
                            & "'" & strCashbookDescription & "-" & txtAccountHolderNumber.Text & "', '" & strPublicSalesAccount & "', " _
                            & "'" & strUserName & "', '" & strUserBranch & "', 'DEBIT', " & Convert.ToDouble(txtReference.Text) & ", " _
                            & "" & intKey & ", '" & strReceiptNumber & "')"
                        myCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        myCommand.ExecuteNonQuery()
                    End If

                    'Post to the debtors control
                    myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                                & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [FolioReference], [SpecialKey]) VALUES " _
                                & "('" & strPublicDebtorsAccount & "', '" & dpProcessDate & "', " & dblSumPayable & ", 'CREDIT', " _
                                & "'" & cboAccount.Text & "', '" & strCashbookDescription & "', '" & strUserName & "', " _
                                & "'" & strUserBranch & "', '" & strReceiptNumber & "', " & intKey & ")", cnn)
                    myCommand.ExecuteNonQuery()

                    'Update the customer account

                    myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LaschCustomerTransactions ([AccountNumber],[TransDate]," _
                            & "[Credit],[Description],[DocumentNumber],[UserName],[ChangeDate]) " _
                            & "VALUES('" & txtAccountHolderNumber.Text & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " _
                            & "" & dblSumPayable & ", '" & strTransDescription & "-" & strReceiptNumber & "', " & txtReference.Text & ", " _
                            & "'" & strUserName & "', '" & Now & "')", cnn)
                    myCommand.ExecuteNonQuery()

                    'Update the control numbers table
                    myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET CashSales = " & CDbl(txtReference.Text) & "", cnn)
                    myCommand.ExecuteNonQuery()

                End If
            Next

            InputTransactions.Complete()

        End Using

        If MessageBox.Show("Transaction saved successfully. Do you want to capture more receipts", "Process Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            cboName.Text = ""
            txtAmount.Text = "0.00"
            dGrid.Rows(0).Cells(1).Value = ""
            dGrid.Rows(0).Cells(2).Value = "0.00"
            dGrid.Rows(1).Cells(1).Value = ""
            dGrid.Rows(1).Cells(2).Value = "0.00"
            txtAccountHolderNumber.Text = Nothing
            cboName.Focus()
        Else
            Me.Close()
            Exit Sub
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " On Lasch Premiums Payments"
        ShowErrorMessage()
    End Sub

    Private Sub cboName_TextChanged(sender As Object, e As System.EventArgs) Handles cboName.TextChanged
        txtAccountHolderNumber.Text = ""
    End Sub

    Private Sub LoadTransactions(AccountNumber As String)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, TransDate, 105) AS [DATE], DocumentNumber AS [Doc.#], " _
            & "Description, CAST(Debit AS DECIMAL (10,2)) AS [Debit], CAST(Credit AS DECIMAL (10,2)) AS [Credit] " _
            & "FROM LaschCustomerTransactions WHERE AccountNumber = '" & AccountNumber & "' ORDER BY TransDate"
        dGridTransactions.Columns.Clear()
        Me.dGridTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridTransactions.DataSource = dTable
        For p As Integer = 0 To dGridTransactions.Columns.Count - 1
            If p = 3 Or p = 4 Then
                dGridTransactions.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            dGridTransactions.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next

        'Compute the balance
        Dim dblDebits As Double = 0
        Dim dblCredits As Double = 0

        For i As Integer = 0 To dGridTransactions.Rows.Count - 1
            If IsNumeric(dGridTransactions.Rows(i).Cells(3).Value) Then dblDebits = dblDebits + CDbl(dGridTransactions.Rows(i).Cells(3).Value.ToString)
            If IsNumeric(dGridTransactions.Rows(i).Cells(4).Value) Then dblCredits = dblCredits + CDbl(dGridTransactions.Rows(i).Cells(4).Value.ToString)
        Next
        lblBalance.Text = Format((dblDebits - dblCredits), "##0.00")

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Lasch Customer Transactions Load"
        ShowErrorMessage()
    End Sub

End Class
