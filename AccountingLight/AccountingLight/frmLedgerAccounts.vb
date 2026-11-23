Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLedgerAccounts

    Dim boolSaving As Boolean = False

    Private Sub frmLedgerAccounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then
            btnAllocations.Enabled = True
            txtAccountNo.Enabled = False
        Else
            btnAllocations.Enabled = False
            txtAccountNo.Enabled = True
        End If
        boolAbort = False
        LoadGroupAccounts()
        If boolAbort = True Then Exit Sub
        LoadSelected()
    End Sub

    Private Sub LoadSelected()
        On Error GoTo RaiseErr
        If boolEditStatus = True Then
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName, AccountType, Classification, " _
                & "SubAccountOf, CashFlowCategory, TopLevelAccount, TopLevelStatus, " _
                & "TakeonDate FROM LedgerAccounts WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                chkTopLevelAccount.Checked = False
                If Not IsDBNull(objReader("AccountNumber").ToString) Then txtAccountNo.Text = objReader("AccountNumber").ToString
                If Not IsDBNull(objReader("AccountName").ToString) Then txtAccountName.Text = objReader("AccountName").ToString
                If Not IsDBNull(objReader("AccountType").ToString) Then cboType.Text = objReader("AccountType").ToString
                If Not IsDBNull(objReader("Classification").ToString) Then cboClass.Text = objReader("Classification").ToString
                If IsDate(objReader("TakeonDate").ToString) Then dpStart.Value = CDate(objReader("TakeonDate").ToString)
                If Not IsDBNull(objReader("CashFlowCategory").ToString) Then
                    cboCashFlow.Text = objReader("CashFlowCategory").ToString
                Else
                    cboCashFlow.Text = "None"
                End If
                cboGroupAccount.Text = Nothing
                If Not IsDBNull(objReader("SubAccountOf").ToString) Then
                    cboGroupAccount.SelectedText = objReader("SubAccountOf").ToString
                    'Get the account name
                    lblAccountName.Text = GetAccountName(objReader("SubAccountOf").ToString)
                Else
                    cboGroupAccount.SelectedText = "NONE"
                End If

                If Not IsDBNull(objReader("TopLevelAccount").ToString) Then
                    txtTopLevelAccount.Text = objReader("TopLevelAccount").ToString
                    lblTopAccountName.Text = GetAccountName(objReader("TopLevelAccount").ToString)
                End If
            End If
            objReader.Close()

            txtBalance.Enabled = False
            optDebit.Enabled = False
            optCredit.Enabled = False

        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger Account Details Load"
        ShowErrorMessage()
    End Sub

    Private Function GetAccountName(ByVal AccountNumber As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        'Get the account name
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountName FROM LedgerAccounts " _
            & "WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        Dim objReadMainAccount As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReadMainAccount.HasRows Then
            objReadMainAccount.Read()
            If Not IsDBNull(objReadMainAccount(0).ToString) Then
                strReturn = objReadMainAccount(0).ToString
            End If
        End If
        objReadMainAccount.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger Account Details Load"
        ShowErrorMessage()
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtAccountNo.Text) Then
            MessageBox.Show("Please enter the account number", "Invalid Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNo.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAccountName.Text) Then
            MessageBox.Show("Please enter the account name", "Invalid Account Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountName.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboType.Text) Then
            MessageBox.Show("Please enter the account type", "Invalid Account Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboType.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboClass.Text) Then
            MessageBox.Show("Please enter the account classification", "Invalid Account Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClass.Focus()
            Exit Sub
        End If

        If UCase(cboGroupAccount.Text) = UCase(txtAccountNo.Text) Or _
            UCase(txtAccountNo.Text) = UCase(txtTopLevelAccount.Text) Then
            MessageBox.Show("The top level or sub account of cannot be the same as the account number", "Invalid Accounts Grouping", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboGroupAccount.Focus()
            Exit Sub
        End If

        Dim strLevelStatus As String = "NO"

        Dim strCashflowCategory As String = "None"
        Dim strSubAccountOf As String = "None"

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If Not String.IsNullOrEmpty(cboCashFlow.Text) Then strCashflowCategory = cboCashFlow.Text
        If Not String.IsNullOrEmpty(cboGroupAccount.Text) Then strSubAccountOf = cboGroupAccount.Text
        If chkTopLevelAccount.Checked = True Then strLevelStatus = "YES"

        If boolEditStatus = False Then
            strSql = "INSERT INTO LedgerAccounts ([AccountNumber],[AccountName],[AccountType],[Classification]," _
                & "[UserBranch], [TakeonDate], [SubAccountOf], " _
                & "[CashFlowCategory], [TopLevelAccount], [TopLevelStatus]) VALUES " _
                & "('" & txtAccountNo.Text & "', '" & txtAccountName.Text & "','" & cboType.Text & "', " _
                & "'" & cboClass.Text & "', '" & strUserBranch & "', " _
                & "'" & Format(dpStart.Value, "dd-MMM-yyyy") & "', '" & strSubAccountOf & "', " _
                & "'" & strCashflowCategory & "', '" & txtTopLevelAccount.Text & "', '" & strLevelStatus & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            'Update the ledger account transactions with the starting balance
            Dim dblAmount As Double = 0
            Dim strTransactionType As String = "DEBIT"
            If optCredit.Checked = True Then strTransactionType = "CREDIT"
            strSql = "INSERT INTO LedgerTransactions ([TransactionDate],[Amount],[TransactionType],[Description],[UserName],[UserBranch], [ContraAccount], [AccountNumber]) VALUES " _
                & "('" & Format(dpStart.Value, "dd-MMM-yyyy") & "', " & dblAmount & ", '" & strTransactionType & "', 'START ON BALANCE', '" & strUserName & "', '" & strUserBranch & "', '00000', '" & txtAccountNo.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            If MessageBox.Show("Ledger Account Created Successfully. Do you want to create more accounts?", "Ledger Accounts Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                txtAccountName.Clear()
                txtAccountNo.Clear()
                txtBalance.Text = "0.00"
                boolSaving = True
                boolSaving = False
                cboCashFlow.Text = "None"
                cboGroupAccount.Text = ""
                lblAccountName.Text = ""
            Else
                Me.Close()
            End If
        Else
            strSql = "UPDATE LedgerAccounts SET AccountName = '" & txtAccountName.Text & "', AccountType = '" & cboType.Text & "', " _
                & "Classification = '" & cboClass.Text & "', TakeonDate = '" & Format(dpStart.Value, "dd-MMM-yyyy") & "', " _
                & "SubAccountOf = '" & strSubAccountOf & "', CashFlowCategory = '" & strCashflowCategory & "', " _
                & "TopLevelAccount = '" & txtTopLevelAccount.Text & "', TopLevelStatus = '" & strLevelStatus & "' " _
                & "WHERE AccountNumber = '" & txtAccountNo.Text & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Ledger Account Updated Successfully", "Ledger Account Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
        LoadGroupAccounts()
        Exit Sub
RaiseErr:
        boolAbort = True
        boolSaving = False
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger Accounts Setup"
        ShowErrorMessage()
    End Sub

    Private Sub txtBalance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBalance.KeyPress
        If Asc(e.KeyChar) = 13 Then optDebit.Focus()
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub LoadGroupAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AccountNumber +';'+ AccountName AS [Data] " _
            & "FROM LedgerAccounts WHERE TopLevelStatus = 'YES' ORDER BY AccountName"
        'WHERE SubAccountOf = 'None' 
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboGroupAccount
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .MaxDropDownItems = 10
            .DropDownHeight = 110
            .ColumnWidth = "80;200"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) " _
            & "FROM LedgerAccounts WHERE TopLevelStatus = 'YES' ", cnn)
        ' WHERE SubAccountOf = 'None'
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboGroupAccount.Items.Clear()
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
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboGroupAccount.SelectedIndex = -1
            cboGroupAccount.Items.Clear()
            cboGroupAccount.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboGroupAccount.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        boolSaving = False
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger Accounts Setup Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboGroupAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGroupAccount.SelectedIndexChanged
        lblAccountName.Text = ""
        txtTopLevelAccount.Text = "None"
        lblTopAccountName.Text = ""
        If Not cboGroupAccount.SelectedItem Is Nothing Then
            lblAccountName.Text = cboGroupAccount.SelectedItem.Col2
            txtTopLevelAccount.Text = GetTopLevelAccount(cboGroupAccount.Text)
            lblTopAccountName.Text = GetAccountName(txtTopLevelAccount.Text)
        End If
    End Sub

    Private Function GetTopLevelAccount(ByVal AccountNumber As String) As String
        Dim strReturn As String = "None"
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT TopLevelAccount FROM LedgerAccounts WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(objReader(0).ToString) <> "NONE" Then
                    strReturn = objReader(0).ToString
                End If
            End If
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        boolSaving = False
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger Accounts Setup Details Load"
        ShowErrorMessage()
    End Function

    Private Sub btnAllocations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllocations.Click
        strSelectedAccount = txtAccountNo.Text
        strSelectedAccountName = txtAccountName.Text
        Dim f As New frmAccountAllocations
        f.ShowDialog()
    End Sub

    Private Sub chkTopLevelAccount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTopLevelAccount.CheckedChanged
        If chkTopLevelAccount.Checked = False Then
            cboGroupAccount.Enabled = True
            If boolEditStatus = True Then LoadSelected()
        Else
            cboGroupAccount.Enabled = False
            cboGroupAccount.Text = "NONE"
        End If
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        cboClass.Items.Clear()
        Select Case UCase(cboType.Text)
            Case Is = UCase("Asset")
                cboClass.Items.Add("Fixed Asset")
                cboClass.Items.Add("Current Asset")
            Case Is = UCase("Liability")
                cboClass.Items.Add("Credit Card")
                cboClass.Items.Add("Loan Account")
                cboClass.Items.Add("Other Liability")
                cboClass.Items.Add("Short Term Liability")
                cboClass.Items.Add("Long Term Liability")
            Case Is = UCase("Equity")
                cboClass.Items.Add("Owners Equity")
                cboClass.Items.Add("Share Equity")
                cboClass.Items.Add("Debenture Equity")
            Case Is = UCase("Income")
                cboClass.Items.Add("Operating Income")
                cboClass.Items.Add("Non-operating Income")
            Case Is = UCase("Expense")
                cboClass.Items.Add("Cost of Sales")
                cboClass.Items.Add("Operating Expense")
                cboClass.Items.Add("Non-operating Expense")
            Case Is = UCase("Control")
                cboClass.Items.Add("NONE")
                cboClass.Items.Add("Balance Sheet Liability")
            Case Is = UCase("Header")
                cboClass.Items.Add("Asset")
                cboClass.Items.Add("Liability")
                cboClass.Items.Add("Equity")
                cboClass.Items.Add("Income")
                cboClass.Items.Add("Expense")
                cboClass.Items.Add("Control")
                cboClass.Items.Add("NONE")
            Case Is = UCase("Interest")
                cboClass.Items.Add("Interest Received")
                cboClass.Items.Add("Interest Paid")
        End Select
    End Sub

End Class