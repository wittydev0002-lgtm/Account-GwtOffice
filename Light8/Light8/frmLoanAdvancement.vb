Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoanAdvancement

    Dim boolFormLoading As Boolean

    Private Sub cboLoanType_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboLoanType.KeyDown
        If e.KeyData = Keys.Enter Then
            cboAccountHolder.Select()
        End If
    End Sub '

    Private Sub cboLoanType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLoanType.SelectedIndexChanged
        If boolFormLoading = True Then Exit Sub
        GetLoanDetails(cboLoanType.Text)
    End Sub

    Private Sub GetLoanDetails(ByVal LoanType As String)
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT InterestRate, MaximumCapital, " _
            & "MinimumRepaymentAmount, MinimumRepaymentPeriod FROM LoanTypes WHERE LoanName = '" & LoanType & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then lblInterestRate.Text = Format(CDbl(objReader(0).ToString), "#0.000000")
            If IsNumeric(objReader(1).ToString) Then lblCapitalMaximum.Text = Format(CDbl(objReader(1).ToString), "#0.00")
            If IsNumeric(objReader(2).ToString) Then lblMinimumAmount.Text = Format(CDbl(objReader(2).ToString), "#0.00")
            If IsNumeric(objReader(3).ToString) Then lblMinimumPeriod.Text = Format(CDbl(objReader(3).ToString), "#0.00")
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Loan details fetch error"
        ShowErrorMessage()
    End Sub

    Private Sub LoadLoans()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT LoanName FROM LoanTypes ORDER BY LoanName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboLoanType.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboLoanType.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Loan details fetch error"
        ShowErrorMessage()
    End Sub

    Private Sub frmLoanAdvancement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        If gwt_comm.CheckColumnExistence("LoanAdvances", "InterestRate") = False Then
            strSql = "ALTER TABLE LoanAdvances ADD [InterestRate][FLOAT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("LoanAdvances", "LoanType") = False Then
            strSql = "ALTER TABLE LoanAdvances ADD [LoanType][NVARCHAR] (250) NOT NULL DEFAULT ''"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

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
            LoadLoans()
            LoadCashbooAccounts()
        End If
        boolFormLoading = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmLoanAdvancement_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '680; 480
        Me.Width = 680
        Me.Height = 515 '680, 485
    End Sub

    'Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    lblAccountLoanNumber.Text = ""
    '    strPublicItemCode = Nothing : strPublicItemDescription = Nothing
    '    Dim f As New frmBrowseLoanCustomer
    '    f.ShowDialog()
    '    txtAccountNumber.Text = strPublicItemCode
    '    lblAccountLoanNumber.Text = strPublicItemDescription
    'End Sub

    Private Function GetCustomerName(ByVal AccountNumber As String) As String
        Dim strReturn As String = Nothing
        Dim strSql As String = "SELECT AccountName as [Customer Name] " _
            & "FROM Customers WHERE AccountNumber = '" & AccountNumber & "' AND " _
            & "CustomerType = 'LOAN' ORDER BY AccountNumber"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = UCase(objReader(0).ToString)
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "an aatempt to get the customer details has failed"
        ShowErrorMessage()
    End Function

    'Private Sub txtAccountNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then
    '        If Not String.IsNullOrEmpty(txtAccountNumber.Text) Then
    '            lblAccountLoanNumber.Text = UCase(GetCustomerName(txtAccountNumber.Text & e.KeyChar))
    '            Exit Sub
    '        Else
    '            Exit Sub
    '        End If
    '    End If
    '    If Asc(e.KeyChar) = 13 Then
    '        dpDate.Focus()
    '        Exit Sub
    '    End If
    '    lblAccountLoanNumber.Text = UCase(GetCustomerName(txtAccountNumber.Text & e.KeyChar))
    'End Sub

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
            txtCapital.Select()
        End If
    End Sub

    Private Sub cboCashbookAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCashbookAccount.SelectedIndexChanged
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

    Private Sub LoadLoanAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM LoanCustomers ORDER BY AccountName"
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

        If String.IsNullOrEmpty(cboLoanType.Text) Then
            MessageBox.Show("Please select the loan type", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboLoanType.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter the reason or description for loan advancement", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Select()
            Exit Sub
        End If

        If Not IsNumeric(txtCapital.Text) Then
            MessageBox.Show("Please enter a valid value for amount advanced", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCapital.Select()
            Exit Sub
        Else
            If CInt(txtCapital.Text) <= 0 Then
                MessageBox.Show("Please enter a value greter then 0 for amount advanced", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCapital.Select()
                Exit Sub
            End If
        End If

        If Not IsNumeric(txtPeriod.Text) Then
            MessageBox.Show("Please enter a valid value for repayment period", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPeriod.Select()
            Exit Sub
        Else
            If CInt(txtPeriod.Text) <= 0 Then
                MessageBox.Show("Please enter a value greter then 0 for repayment period", "Invalid Period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtPeriod.Select()
                Exit Sub
            End If
        End If

        If Not IsNumeric(txtRepayment.Text) Then
            MessageBox.Show("Please enter a valid value for repayment amount", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRepayment.Select()
            Exit Sub
        Else
            If CInt(txtRepayment.Text) <= 0 Then
                MessageBox.Show("Please enter a value greter then 0 for repayment amount", "Invalid Period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtRepayment.Select()
                Exit Sub
            End If
        End If

        If String.IsNullOrEmpty(cboFrequency.Text) Then
            MessageBox.Show("Please select the repayment frequency", "Missing Repayment Frequency", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboFrequency.Select()
            Exit Sub
        End If

        On Error GoTo RaiseErr

        Dim intSpecialKey As Integer = gwt_comm.SpecialKey
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        Dim strDate As String = gwt_comm.shortMonthDateFormat(dpDate.Value)
        Dim strEntryType As String = "CREDIT"
        Dim dblAmount As Double = CDbl(txtCapital.Text)
        Dim strVatNumber As String = Nothing
        Dim dblVatAmount As Double = 0
        Dim intCostCenter As Integer = 0
        Dim intProjectNo As Integer = 0
        Dim strReference As String = Nothing
        Dim strDescription As String = cboAccountHolder.Text & "-" & txtDescription.Text

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
        strEntryType = "DEBIT"
        strSql = "INSERT INTO LedgerTransactions ([TransactionDate], [AccountNumber], [Amount], [TransactionType], " _
            & "[ContraAccount], [Description], [UserName], [UserBranch], [Reference], [CostCode], [LinkedProject], " _
            & "[SpecialKey]) VALUES ('" & strDate & "', '" & strPublicVatControlAccount & "', " & dblAmount & ", '" & strEntryType & "', " _
            & "'" & lblLoanControlAccount.Text & "', '" & strDescription & "', '" & strUserName & "', '" & strUserBranch & "', " _
            & "'" & strReference & "', " & intCostCenter & ", " & intProjectNo & ", " & intSpecialKey & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Add to the loans transaction account
        Dim dblAmountDue As Double = CDbl(lblAmountDue.Text)
        strSql = "INSERT LoanTransactions (AccountNumber, TransactionDate, DebitAmount, UserName, ChangeDate, SpecialKey, Description) VALUES " _
            & "('" & lblAccountLoanNumber.Text & "', '" & strDate & "', " & dblAmountDue & ", '" & strUserName & "', '" & Now & "', " _
            & "" & intSpecialKey & ", '" & txtDescription.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Update load advances account
        strSql = "INSERT INTO LoanAdvances ([AccountNumber], [TransactionDate], [Amount], [DueValue], [Frequency], [PeriodStartDate], [LoanType], [InterestRate], [Period]) VALUES " _
            & "('" & lblAccountLoanNumber.Text & "', '" & strDate & "', " & dblAmount & ", " & dblAmountDue & ", '" & cboFrequency.Text & "', " _
            & "'" & gwt_comm.shortMonthDateFormat(dpInitialPaymentDate.Value) & "', '" & cboLoanType.Text & "', " & CDbl(lblInterestRate.Text) & ", " & CDbl(txtPeriod.Text) & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on loan advancement"
        ShowErrorMessage()
    End Sub

    Private Sub dpDate_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dpDate.KeyDown
        If e.KeyData = Keys.Enter Then
            cboLoanType.Select()
        End If
    End Sub

    Private Sub txtCapital_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCapital.KeyDown
        If e.KeyData = Keys.Enter Then
            txtPeriod.Select()
        End If
    End Sub

    Private Sub txtPeriod_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPeriod.KeyDown
        If e.KeyData = Keys.Enter Then
            txtRepayment.Select()
        End If
    End Sub

    Private Sub txtRepayment_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtRepayment.KeyDown
        If e.KeyData = Keys.Enter Then
            btnOK.Select()
        End If
    End Sub

    Private Function FutureValue(ByVal Capital As Double, ByVal Rate As Double, ByVal Period As Double) As Double
        Dim dblReturn As Double = 0
        dblReturn = Capital * (1 + (Rate / 100)) ^ (Period / 12)
        Return dblReturn
    End Function

    Private Sub txtCapital_Validated(sender As Object, e As System.EventArgs) Handles txtCapital.Validated
        'txtRepayment.Enabled = True
        If IsNumeric(txtCapital.Text) Then
            If CDbl(txtCapital.Text) <> 0 Then
                Dim dblCapital As Double = CDbl(txtCapital.Text)
                Dim dblRate As Double = CDbl(lblInterestRate.Text)
                Dim dblPeriod As Double = 0
                If IsNumeric(txtPeriod.Text) Then dblPeriod = CDbl(txtPeriod.Text)
                lblAmountDue.Text = Format(FutureValue(dblCapital, dblRate, dblPeriod), "##0.00")
                If dblPeriod > 0 Then
                    txtRepayment.Text = Format(CDbl(lblAmountDue.Text) / dblPeriod, "##0.00")
                    txtRepayment.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub txtPeriod_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPeriod.Validating
        If IsNumeric(txtPeriod.Text) Then
            If CDbl(txtPeriod.Text) <> 0 Then
                Dim dblPeriod As Double = CDbl(txtPeriod.Text)
                Dim dblRate As Double = CDbl(lblInterestRate.Text)
                Dim dblCapital As Double = 0
                If IsNumeric(txtCapital.Text) Then dblCapital = CDbl(txtCapital.Text)
                lblAmountDue.Text = Format(FutureValue(dblCapital, dblRate, dblPeriod), "##0.00")
                If dblPeriod > 0 Then
                    txtRepayment.Text = Format(CDbl(lblAmountDue.Text) / dblPeriod, "##0.00")
                    txtRepayment.Enabled = False
                End If
            End If
        End If
    End Sub

End Class
