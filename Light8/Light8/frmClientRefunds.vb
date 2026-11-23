Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmClientRefunds

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmClientRefunds_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If UCase(strCalledBy) = UCase("customers") Then
            Me.Text = "Customer Refund Payment"
        Else
            Me.Text = "Supplier Refund Receipt"
        End If
        boolAbort = False
        LoadCashbooks()
        If boolAbort = True Then Exit Sub
        LoadClients()
    End Sub

    Private Sub cboCashbooks_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCashbooks.KeyDown
        If e.KeyData = Keys.Enter Then
            txtAmount.Select()
        End If
    End Sub

    Private Sub cboCashbooks_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCashbooks.SelectedIndexChanged
        lblCashbookAccount.Text = ""
        lblCashbookAccount.Text = cboCashbooks.SelectedItem.Col2
        strPublicActiveCashbookName = lblCashbookAccount.Text
    End Sub

    Private Sub LoadCashbooks()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM Cashbooks ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboCashbooks
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

        cboCashbooks.Items.Clear()
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
            cboCashbooks.SelectedIndex = -1
            cboCashbooks.Items.Clear()
            cboCashbooks.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCashbooks.Items.AddRange(DropDownItems)
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Cashbooks Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadClients()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        If UCase(strCalledBy) = UCase("Customers") Then
            strSql = "SELECT AccountName +';'+AccountNumber AS [Accounts] FROM Customers ORDER BY AccountName"
        Else
            strSql = "SELECT AccountName +';'+AccountNumber AS [Accounts] FROM Suppliers ORDER BY AccountName"
        End If

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboClients
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "250;100"
        End With

        Dim arrItems As New ArrayList
        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Get a count of the items
        Dim intItemsCount As Integer = arrItems.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboClients.Items.Clear()

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        With cboClients
            If intItemsCount > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on client details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboClients_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboClients.KeyDown
        If e.KeyData = Keys.Enter Then
            cboCashbooks.Select()
        End If
    End Sub

    Private Sub cboClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClients.SelectedIndexChanged
        lblClientAccount.Text = Nothing
        lblClientAccount.Text = cboClients.SelectedItem.Col2
    End Sub

    Private Sub cboPaymentMethod_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboPaymentMethod.KeyDown
        If e.KeyData = Keys.Enter Then
            If UCase(cboPaymentMethod.Text) = UCase("cheque") Then
                txtChequeNo.Select()
            Else
                txtReference.Select()
            End If
        End If
    End Sub

    Private Sub cboPaymentMethod_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPaymentMethod.SelectedIndexChanged
        If UCase(cboPaymentMethod.Text) = UCase("cheque") Then
            txtChequeNo.Enabled = True
        Else
            txtChequeNo.Enabled = False
        End If
    End Sub

    Private Sub chkOverideDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOverideDate.CheckedChanged
        If chkOverideDate.Checked = True Then
            If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
                dpTransDate.Enabled = True
            Else
                boolAbort = False
                boolAuthorized = False
                gwt_comm.SuperUserAuthentication()
                If boolAbort = True Then
                    chkOverideDate.Checked = False
                    Exit Sub
                End If
                If boolAuthorized = True Then
                    dpTransDate.Enabled = True
                    boolAuthorized = False
                End If
            End If
        Else
            dpTransDate.Enabled = False
            boolAuthorized = False
        End If
    End Sub

    Private Sub btnFindAccount_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFindAccount.Click
        strPublicItemCode = Nothing
        strPublicItemDescription = Nothing
        lblClientAccount.Text = Nothing
        boolAbort = False
        If UCase(strCalledBy) = UCase("suppliers") Then
            gwt_comm.SupplierSearch()
        Else
            gwt_comm.CustomerSearch()
        End If
        If boolAbort = True Then Exit Sub
        lblClientAccount.Text = strSelectedAccount
        cboClients.Text = strSelectedAccountName
    End Sub

    Private Sub dpTransDate_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dpTransDate.KeyDown
        If e.KeyData = Keys.Enter Then
            cboClients.Select()
        End If
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyData = Keys.Enter Then
            cboPaymentMethod.Select()
        End If
    End Sub

    Private Sub txtChequeNo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtChequeNo.KeyDown
        If e.KeyData = Keys.Enter Then
            txtReference.Select()
        End If
    End Sub

    Private Sub txtReference_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtReference.KeyDown
        If e.KeyData = Keys.Enter Then
            txtRemarks.Select()
        End If
    End Sub

    Private Sub txtRemarks_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyData = Keys.Enter Then
            btnOk.Select()
        End If
    End Sub

    Private Sub FinishProcess()

        '** This process affects : Cashbook, Ledger accounts, supplier/customer ledger
        '
        If String.IsNullOrEmpty(lblClientAccount.Text) Then
            MessageBox.Show("Please select the client from the given list", "Invalid Client Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClients.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(lblCashbookAccount.Text) Then
            MessageBox.Show("Please select the cashbook from the given list", "Invalid Cashbook Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            lblCashbookAccount.Select()
            Exit Sub
        End If

        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a valid amount", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboPaymentMethod.Text) Then
            MessageBox.Show("Please select the payment method", "Invalid Payment Method", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPaymentMethod.Select()
            Exit Sub
        End If

        If UCase(cboPaymentMethod.Text) = UCase("cheque") Then
            If String.IsNullOrEmpty(txtChequeNo.Text) Then
                MessageBox.Show("Missing cheque number where payment method is cheque", "Missing Cheque No", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtChequeNo.Select()
                Exit Sub
            End If
        End If

        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim intSpecialKey As Integer = gwt_comm.SpecialKey

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        Dim strEntryType As String = Nothing 'Based on the cashbook

        If UCase(strCalledBy) = UCase("customers") Then
            strEntryType = "CREDIT"
        Else
            strEntryType = "DEBIT"
        End If

        'Enter the transaction to the cashbook first
        '

        If Not IsNumeric(txtAmount.Text) Then txtAmount.Text = "0.00"

        Dim dblAmount As Double = CDbl(txtAmount.Text)
        Dim strCashbookAccount As String = lblCashbookAccount.Text
        Dim strClientAccount As String = lblClientAccount.Text
        Dim strEntryDescription As String = UCase(cboClients.Text) & " REFUND"

        strSql = "INSERT INTO CashbookTransactions (AccountNumber, TransactionDate, " _
               & "Amount, Description, ContraAccount, UserName, UserBranch, TransactionType, UserReference, SpecialKey) VALUES " _
               & "('" & strCashbookAccount & "', '" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', " & dblAmount & ", " _
               & "'" & strEntryDescription & "', '" & strClientAccount & "', " _
               & "'" & strUserName & "', '" & strUserBranch & "', '" & strEntryType & "', '" & txtReference.Text & "', " & intSpecialKey & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        '** Depending on the entry type, post to the norminal ledger accounts
        '

        Dim strContraType As String = Nothing
        Dim strPostingAccount As String = Nothing

        If UCase(strEntryType) = UCase("debit") Then strContraType = "CREDIT" Else strContraType = "DEBIT"
        If UCase(strCalledBy) = UCase("customers") Then strPostingAccount = strPublicDebtorsAccount Else strPostingAccount = strPublicCreditorsAccount

        strSql = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
                    & "[Description],[UserName],[UserBranch],[Reference], [CostCode], [SpecialKey]) VALUES " _
                    & "('" & strPostingAccount & "', '" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', " & dblAmount & ", " _
                    & "'" & strContraType & "', '" & strCashbookAccount & "', '" & strEntryDescription & "', '" & strUserName & "', " _
                    & "'" & strUserBranch & "', '" & txtReference.Text & "', 0, " & intSpecialKey & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        '** Update the customers/suppliers ledger accounts
        '
        Dim strTableName As String = Nothing
        If UCase(strCalledBy) = UCase("customers") Then strTableName = "CustomerTransactions" Else strTableName = "SupplierTransactions"

        strSql = "INSERT INTO " & strTableName & " ([AccountNumber],[TransactionDate]," _
            & "[Amount],[TransactionType],[Description],[ReferenceNumber],[UserName],[BranchName], [SpecialKey], [Comments]) " _
            & "VALUES('" & strClientAccount & "', '" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', " _
            & "" & (0 - dblAmount) & ", 'REFUND', '" & strEntryDescription & "', '" & txtReference.Text & "', " _
            & "'" & strUserName & "', '" & strUserBranch & "', " & intSpecialKey & ", '" & txtRemarks.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default
        MessageBox.Show("Refund has been processed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on client details Load"
        ShowErrorMessage()
    End Sub

End Class