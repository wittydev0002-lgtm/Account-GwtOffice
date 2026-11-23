Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmFarmersLoanRepayment

    Dim boolFormLoading As Boolean

    Private Sub frmFarmersLoanRepayment_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        If String.IsNullOrEmpty(strPublicLoansControlAccount) Then
            MessageBox.Show("You cannot advance any loan now because the loans control account has not been set. " _
                            & "To set it up, go to accounts menu and under setup, select Special Ledger Accounts",
                              "Missing Loan Control Account", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            grpMain.Enabled = False
            btnOK.Enabled = False
        Else
            grpMain.Enabled = True
            btnOK.Enabled = True
            lblLoanControlAccount.Text = strPublicLoansControlAccount
            LoadLoanAccounts()
            LoadCashbooAccounts()
        End If
        boolFormLoading = False
    End Sub

    Private Sub frmLoanRepayment_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 510 : Me.Height = 325
    End Sub

    Private Sub LoadLoanAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT LastName +' '+ FirstName +' '+ OtherNames +';'+ GrowerNumber AS " _
            & "[Accounts] FROM FarmersData ORDER BY LastName, FirstName, OtherNames"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboAccountHolder
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "120;80"
        End With

        Dim arrItems As New ArrayList

        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Get a count of the items
        Dim intItemsCount As Integer = arrItems.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboAccountHolder.Items.Clear()

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        If intItemsCount > 0 Then
            cboAccountHolder.SelectedIndex = -1
            cboAccountHolder.Items.Clear()
            cboAccountHolder.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboAccountHolder.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on loan account holders details"
        ShowErrorMessage()
    End Sub

    Private Sub LoadCashbooAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM Cashbooks ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboCashbookAccount
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "80;120"
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

        cboCashbookAccount.Items.Clear()
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
            cboCashbookAccount.SelectedIndex = -1
            cboCashbookAccount.Items.Clear()
            cboCashbookAccount.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCashbookAccount.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Cashbooks Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboCashbookAccount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCashbookAccount.KeyDown
        If e.KeyData = Keys.Enter Then
            txtAmount.Select()
        End If
    End Sub

    Private Sub cboAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCashbookAccount.SelectedIndexChanged
        If boolFormLoading = True Then Exit Sub
        lblCashbookAccount.Text = ""
        If Not cboCashbookAccount.SelectedItem Is Nothing Then
            lblCashbookAccount.Text = cboCashbookAccount.SelectedItem.Col2
        End If
    End Sub

    Private Sub cboAccountHolder_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboAccountHolder.KeyDown
        If e.KeyData = Keys.Enter Then
            cboCashbookAccount.Select()
        End If
    End Sub

    Private Sub cboAccountHolder_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAccountHolder.SelectedIndexChanged
        If boolFormLoading = True Then Exit Sub
        lblAccountLoanNumber.Text = ""
        If Not cboAccountHolder.SelectedItem Is Nothing Then
            lblAccountLoanNumber.Text = cboAccountHolder.SelectedItem.Col2
        End If
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click

        If String.IsNullOrEmpty(lblAccountLoanNumber.Text) Then
            MessageBox.Show("Please select the customer from the given list", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccountHolder.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(lblCashbookAccount.Text) Then
            MessageBox.Show("Please select the cashbook account", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCashbookAccount.Select()
            Exit Sub
        End If

        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a valid value for amount", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Select()
            Exit Sub
        Else
            If CInt(txtAmount.Text) <= 0 Then
                MessageBox.Show("Please enter a value greter then 0 for amount", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtAmount.Select()
                Exit Sub
            End If
        End If

        On Error GoTo RaiseErr

        Dim intSpecialKey As Integer = gwt_comm.SpecialKey

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        Dim strDate As String = shortMonthDateFormat(dpDate.Value)
        Dim strEntryType As String = "DEBIT"
        Dim dblAmount As Double = CDbl(txtAmount.Text)
        Dim strVatNumber As String = Nothing
        Dim dblVatAmount As Double = 0
        Dim intCostCenter As Integer = 0
        Dim intProjectNo As Integer = 0
        Dim strReference As String = Nothing
        Dim strDescription As String = cboAccountHolder.Text & "-" & lblAccountLoanNumber.Text
        Dim strRemarks As String = txtRemarks.Text

        'Add to the cashbook as a credit
        strSql = "INSERT INTO CashbookTransactions ([TransactionDate], [AccountNumber], [ContraAccount], " _
                    & "[Description], [TransactionType], [CostCode], [UserReference], [VatNumber], [VatAmount], " _
                    & "[Amount], [LinkedProject], [SpecialKey], [UserName], [UserBranch]) VALUES " _
                    & "('" & strDate & "', '" & lblCashbookAccount.Text & "', '" & lblLoanControlAccount.Text & "', " _
                    & "'" & strDescription & "', '" & strEntryType & "', " & intCostCenter & ", '" & strReference & "', " _
                    & "'" & strVatNumber & "', " & dblVatAmount & ", " & dblAmount & ", " & intProjectNo & ", " _
                    & "" & intSpecialKey & ", '" & strUserName & "', '" & strUserBranch & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Add to the loans control account
        strEntryType = "CREDIT"
        strSql = "INSERT INTO LedgerTransactions ([TransactionDate], [AccountNumber], [Amount], [TransactionType], " _
            & "[ContraAccount], [Description], [UserName], [UserBranch], [Reference], [CostCode], [LinkedProject], " _
            & "[SpecialKey]) VALUES ('" & strDate & "', '" & strPublicVatControlAccount & "', " & dblAmount & ", '" & strEntryType & "', " _
            & "'" & lblLoanControlAccount.Text & "', '" & strDescription & "', '" & strUserName & "', '" & strUserBranch & "', " _
            & "'" & strReference & "', " & intCostCenter & ", " & intProjectNo & ", " & intSpecialKey & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Add to the loans transaction account
        strSql = "INSERT LoanTransactions (AccountNumber, TransactionDate, CreditAmount, UserName, ChangeDate, SpecialKey, Remarks) VALUES " _
            & "('" & lblAccountLoanNumber.Text & "', '" & strDate & "', " & dblAmount & ", '" & strUserName & "', '" & Now & "', " _
            & "" & intSpecialKey & ", '" & strRemarks & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on loan repayment"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

End Class