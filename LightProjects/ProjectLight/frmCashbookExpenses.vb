Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCashbookExpenses

    Dim boolEditingCostValues As Boolean

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub dpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpDate.ValueChanged
        LoadTransactions()
        ComputeTotals()
    End Sub

    Private Sub cboDebitAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDebitAccount.SelectedIndexChanged
        lblDebitAccount.Text = ""
        If Not cboDebitAccount.SelectedItem Is Nothing Then
            lblDebitAccount.Text = cboDebitAccount.SelectedItem.Col2
            CostingFigures()
        End If
    End Sub

    Private Sub CostingFigures()
        On Error GoTo RaiseErr
        If boolEditingCostValues = True Then Exit Sub
        If String.IsNullOrEmpty(lblDebitAccount.Text) Then Exit Sub
        If Not IsNumeric(txtAmount.Text) Then
            txtAmount.Text = "0.00"
        End If
        Dim strSql As String = "SELECT SystemCostCenters.OrdinalNo, SystemCostCenters.CostCenterName " _
            & "FROM SystemCostCenters ORDER BY SystemCostCenters.OrdinalNo"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridCosting.Rows.Clear()
        While objReader.Read
            dGridCosting.Rows.Add(objReader(0), objReader(1), "0.00", "0.00")
        End While
        objReader.Close()
        dGridCosting.Columns(3).ReadOnly = False
        'Get the values for the particular selected account
        For i As Integer = 0 To dGridCosting.Rows.Count - 1
            strSql = "SELECT CAST(AccountsAllocations.AllocationPercent AS DECIMAL (10,2)) AS [AllocationPercent] " _
                & "FROM AccountsAllocations WHERE AccountsAllocations.AccountNumber = '" & lblDebitAccount.Text & "' " _
                & "AND AccountsAllocations.CostCode = " & dGridCosting.Rows(i).Cells(0).Value.ToString & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                Dim dblRate As Double = 0
                If IsNumeric(objReader(0).ToString) Then
                    dGridCosting.Rows(i).Cells(2).Value = Format(CDbl(objReader(0).ToString), "##0.00")
                    dblRate = CDbl(objReader(0).ToString)
                End If
                ''Disable the users from making self allocations in this case
                dGridCosting.Columns(3).ReadOnly = True
                'Compute the allocation
                If dblRate <> 0 Then dGridCosting.Rows(i).Cells(3).Value = (dblRate * CDbl(txtAmount.Text)) / 100
            End If
            objReader.Close()
        Next
        If dGridCosting.Columns(3).ReadOnly = True Then
            txtAmount.Enabled = True
        Else
            txtAmount.Enabled = False
            txtAmount.Text = "0.00"
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger account cost centers percentages allocation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtNaration.Text) Then
            MessageBox.Show("Please enter the naration", "Invalid Naration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNaration.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboDebitAccount.Text) Then
            MessageBox.Show("Please enter the account number", "Invalid Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboDebitAccount.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblDebitAccount.Text) Then
            MessageBox.Show("Please enter a valid account number", "Invalid Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            lblDebitAccount.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a valid amount", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtVatAmount.Text) Then
            txtVatAmount.Text = "0.00"
        End If

        lngPublicLinkedProjectNumber = intSelectedProjectNumber

        'Make sure that the journal is balancing

        On Error GoTo RaiseErr

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

        Dim dblVatAmountTotal As Double = 0
        If IsNumeric(txtVatAmount.Text) Then dblVatAmountTotal = CDbl(txtVatAmount.Text)

        Dim intSpecialKey As Integer = gwt_comm.SpecialKey()

        Dim strEntryType As String = "CREDIT"
        Dim strSql As String = "INSERT INTO CashbookTransactions (TransactionDate, Amount, Description, ContraAccount, " _
                & "UserName, UserBranch, TransactionType, AccountNumber, Reference, VatAmount, VatNumber, LinkedProject, SpecialKey) VALUES " _
                & "('" & Format(dpDate.Value, "dd-MMM-yyyy") & "', " & CDbl(txtAmount.Text) & ", '" & txtNaration.Text & "', " _
                & "'" & lblDebitAccount.Text & "', '" & strUserName & "', '" & strUserBranch & "', '" & strEntryType & "', " _
                & "'" & strPublicActiveCashbook & "', " & lngJvEntryNumber & ", " & dblVatAmountTotal & ", '" & txtVatNumber.Text & "', " _
                & "" & lngPublicLinkedProjectNumber & ", " & intSpecialKey & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        '0772137984 Cellone R. Mugabe. Tracy
        If dblVatAmountTotal <> 0 Then
            'post to the vat control account
            If String.IsNullOrEmpty(strPublicTaxesAccount) Then
                MessageBox.Show("The taxes control account has not been setup. This will seriously affect the trial balance", _
                    "Taxes Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Dim strProcessStatus As String = gwt_comm.LedgerEntry("INSERT", Format(dpDate.Value, "dd-MMM-yyyy"), strPublicTaxesAccount, _
                    lblDebitAccount.Text, txtNaration.Text, dblVatAmountTotal, "DEBIT", _
                    lngJvEntryNumber, , , , lngJvEntryNumber, 0, 0, 0, intSpecialKey)
                If strProcessStatus <> "SUCCESS" Then GoTo RaiseErr
            End If
        End If

        'Post to the cash control account if set
        'If Not String.IsNullOrEmpty(strPublicCashControlAccount) Then
        '    strSql = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
        '    & "[Description],[UserName],[UserBranch],[Reference], [LinkedProject], [SpecialKey]) VALUES " _
        '    & "('" & strPublicCashControlAccount & "', '" & Format(dpDate.Value, "dd-MMM-yyyy") & "', " & CDbl(txtAmount.Text) & ", " _
        '    & "'" & strEntryType & "', '" & lblDebitAccount.Text & "', '" & txtNaration.Text & "', '" & strUserName & "', " _
        '    & "'" & strUserBranch & "', " & lngJvEntryNumber & ", " & lngPublicLinkedProjectNumber & ", " & intSpecialKey & ")"
        '    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        '    objCommand.ExecuteNonQuery()
        'End If

        'Post the account to the contra ledger account based on the cost centers
        '
        Dim strContraType As String = Nothing
        If strEntryType = "DEBIT" Then strContraType = "CREDIT" Else strContraType = "DEBIT"
        For i As Integer = 0 To dGridCosting.Rows.Count - 1
            Dim lngCostCode As Long = CLng(dGridCosting.Rows(i).Cells(0).Value.ToString)
            If CDbl(dGridCosting.Rows(i).Cells(3).Value.ToString) > 0 Then
                Dim dblPostAmount As Double = CDbl(dGridCosting.Rows(i).Cells(3).Value.ToString)
                strSql = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
                    & "[Description],[UserName],[UserBranch],[Reference], [CostCode], [SpecialKey]) VALUES " _
                    & "('" & lblDebitAccount.Text & "', '" & Format(dpDate.Value, "dd-MMM-yyyy") & "', " & dblPostAmount & ", " _
                    & "'" & strContraType & "', '" & strPublicActiveCashbook & "', '" & txtNaration.Text & "', '" & strUserName & "', " _
                    & "'" & strUserBranch & "', " & lngJvEntryNumber & ", " & lngCostCode & ", " & intSpecialKey & ")"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next

        LoadTransactions()
        ComputeTotals()
        txtAmount.Text = "0.00"
        txtNaration.Clear()
        lblDebitAccount.Text = ""
        cboDebitAccount.Text = ""
        dGridCosting.Rows.Clear()
        cboDebitAccount.Focus()
        txtVatAmount.Text = "0.00"
        txtVatNumber.Clear()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Cashbook Transaction Entry"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM LedgerAccounts WHERE AccountType = 'Expense' ORDER BY AccountNumber"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboDebitAccount
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "335;100"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM LedgerAccounts WHERE AccountType = 'Expense'", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboDebitAccount.Items.Clear()
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
            cboDebitAccount.SelectedIndex = -1
            cboDebitAccount.Items.Clear()
            cboDebitAccount.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboDebitAccount.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Account Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadTransactions()
        On Error GoTo RaiseErr
        dGridCredits.Rows.Clear()

        Dim strSql As String = Nothing

        strSql = "SELECT TransactionDate, Description, ContraAccount, Amount, TransactionId, " _
            & "Reference, TransactionType, VatAmount, VatNumber FROM CashbookTransactions WHERE " _
            & "TransactionDate = '" & Format(dpDate.Value, "dd-MMM-yyyy") & "' " _
            & "AND AccountNumber = '" & strPublicActiveCashbook & "' ORDER BY TransactionId"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)

        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader("TransactionType").ToString) Then
                If UCase(objReader("TransactionType").ToString) = "CREDIT" Then
                    With dGridCredits
                        .Rows.Add(1)
                        If IsDate(objReader("TransactionDate").ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = Format(CDate(objReader("TransactionDate").ToString), "dd-MMM-yyyy")
                        If Not IsDBNull(objReader("Description").ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader("Description").ToString
                        If Not IsDBNull(objReader("ContraAccount").ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader("ContraAccount").ToString
                        If IsNumeric(objReader("Amount").ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = Format(CDbl(objReader("Amount").ToString), "##0.00")
                        If Not IsDBNull(objReader("TransactionId").ToString) Then .Rows(.Rows.Count - 1).Cells(4).Value = objReader("TransactionId").ToString
                        If Not IsDBNull(objReader("Reference").ToString) Then .Rows(.Rows.Count - 1).Cells(5).Value = objReader("Reference").ToString
                        If IsNumeric(objReader("VatAmount").ToString) Then .Rows(.Rows.Count - 1).Cells(6).Value = Format(CDbl(objReader("VatAmount").ToString), "##0.00")
                        If Not IsDBNull(objReader("VatNumber").ToString) Then .Rows(.Rows.Count - 1).Cells(7).Value = objReader("VatNumber").ToString
                    End With
                End If
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Cashbook Transactions Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmCashbookExpenses_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        intSelectedProjectNumber = 0
        lblAccountNumber.Text = UCase(strPublicActiveCashbook)
        LoadData()
        LoadProjectOwners()
        LoadTransactions()
        ComputeTotals()
        If boolCalledFromProjects = True Then
            LoadCallingProject()
        End If
    End Sub

    Private Sub LoadCallingProject()
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        cboProjectOwner.Items.Clear()
        cboProject.Items.Clear()

        Dim strSql As String = "SELECT ProjectsMain.ContractNumber AS [Proj.#], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), ProjectsMain.TakeOnDate, 106), ' ', '-')) as [Date Taken], " _
            & "ProjectsMain.ContractName +'..'+ CONVERT(NVARCHAR, ContractNumber) AS [Contract Name], " _
            & "[Owner] AS [Owner], Customers.AccountName +'..'+ Customers.AccountNumber AS [Customer] " _
            & "FROM ProjectsMain " _
            & "LEFT OUTER JOIN Customers ON Customers.AccountNumber = ProjectsMain.CustomerNumber " _
            & "WHERE ProjectsMain.ContractNumber = " & lngPublicLinkedProjectNumber & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(4).ToString) Then
                cboProjectOwner.Items.Add(objReader(4).ToString)
            End If
            If Not IsDBNull(objReader(2).ToString) Then
                cboProject.Items.Add(objReader(2).ToString)
            End If
        End If
        objReader.Close()

        lblProjectNo.Text = lngPublicLinkedProjectNumber

        cboProject.SelectedIndex = 0
        cboProjectOwner.SelectedIndex = 0

        cboProject.Enabled = False
        cboProjectOwner.Enabled = False

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Cashbook calling project details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals()
        Dim dblTotalCredits As Double = 0
        Dim dblTotalDebits As Double = 0
        Dim dblBalance As Double = 0
        With dGridCredits
            For i As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "")) Then
                    If IsNumeric(.Rows(i).Cells(3).Value) Then
                        dblTotalCredits = dblTotalCredits + CDbl(.Rows(i).Cells(3).Value.ToString)
                    End If
                End If
            Next
        End With
        lblTotal.Text = Format(dblTotalCredits, "#,##0.00")
    End Sub

    Private Sub dGridCosting_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridCosting.CellEndEdit
        With dGridCosting
            If e.ColumnIndex = 3 Then
                If .CurrentCell.Value = Nothing Then
                    Exit Sub
                End If
                If Not IsNumeric(.CurrentCell.Value.ToString) Then
                    MessageBox.Show("Invalid data input", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    .CurrentCell.Value = "0.00"
                Else
                    .CurrentCell.Value = Format((CDbl(.CurrentCell.Value.ToString)), "##0.00")
                End If
            End If
        End With
    End Sub

    Private Sub dGridCosting_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridCosting.CellValueChanged
        On Error Resume Next
        If dGridCosting.CurrentCell.ColumnIndex = 3 Then
            boolEditingCostValues = True
            If Not (Object.Equals(Convert.ToString(dGridCosting.CurrentCell.Value), "")) Then
                If IsNumeric(dGridCosting.CurrentCell.Value.ToString) Then
                    dGridCosting.CurrentCell.Value = Format(CDbl(dGridCosting.CurrentCell.Value.ToString), "##0.00")
                Else
                    MessageBox.Show("Amount entered Is invalid. Default value of zero will be assigned",
                        "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGridCosting.CurrentCell.Value = "0.00"
                End If
            End If
            ComputeCostingTotal()
            boolEditingCostValues = False
        End If
    End Sub

    Private Sub ComputeCostingTotal()
        Dim dblTotal As Double = 0
        With dGridCosting
            For i As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "")) Then
                    If IsNumeric(.Rows(i).Cells(3).Value) Then
                        dblTotal = dblTotal + CDbl(.Rows(i).Cells(3).Value.ToString)
                    End If
                End If
            Next
        End With
        txtAmount.Text = Format(dblTotal, "##0.00")
        CalculateVat()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        If boolEditingCostValues = True Then Exit Sub
        CostingFigures()
        If chkAutoVat.Checked = True Then CalculateVat()
    End Sub

    Private Sub txtVatAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVatAmount.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            txtVatNumber.Focus()
            Exit Sub
        End If
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtVatAmount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVatAmount.Validating
        If IsNumeric(txtVatAmount.Text) Then
            txtVatAmount.Text = Format(CDbl(txtVatAmount.Text), "##0.00")
        End If
    End Sub

    Private Sub CalculateVat()
        Dim dblAmount As Double = 0
        txtVatAmount.Text = "0.00"
        If chkAutoVat.Checked = False Then Exit Sub
        If IsNumeric(txtAmount.Text) Then
            dblAmount = CDbl(txtAmount.Text)
        End If
        If dblAmount <> 0 Then txtVatAmount.Text = Format(((dblAmount * dblSalesTaxRate) / 100), "##0.00") Else txtVatAmount.Text = "0.00"
    End Sub

    Private Sub LoadProjectOwners()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AccountName +'..'+AccountNumber AS [Customer] FROM Customers ORDER BY AccountName"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        cboProjectOwner.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboProjectOwner.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Project Claims Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadClientProjects(ByVal CustomerNumber As String)
        On Error GoTo RaiseErr

        If boolFormInitializing = True Then Exit Sub
        Dim strSql As String = "SELECT ContractName +'..'+ CONVERT(NVARCHAR, ContractNumber) " _
            & "FROM ProjectsMain WHERE CustomerNumber = '" & CustomerNumber & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboProject.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboProject.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Project Claims Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboProjectOwner_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProjectOwner.Click
        If Not String.IsNullOrEmpty(cboProjectOwner.Text) Then
            Dim strSplit() As String = Split(cboProjectOwner.Text, "..")
            lblCustomerNo.Text = strSplit(1)
            LoadClientProjects(strSplit(1))
        End If
    End Sub

    Private Sub cboProjectOwner_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProjectOwner.LostFocus
        If Not String.IsNullOrEmpty(cboProjectOwner.Text) Then
            Dim strSplit() As String = Split(cboProjectOwner.Text, "..")
            lblCustomerNo.Text = strSplit(1)
            LoadClientProjects(strSplit(1))
        End If
    End Sub

    Private Sub cboProjectOwner_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProjectOwner.SelectedIndexChanged
        If boolCalledFromProjects = True Then Exit Sub
        If Not String.IsNullOrEmpty(cboProjectOwner.Text) Then
            Dim strSplit() As String = Split(cboProjectOwner.Text, "..")
            lblCustomerNo.Text = strSplit(1)
            LoadClientProjects(strSplit(1))
        End If
    End Sub

    Private Sub cboProject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProject.Click
        SelectProject()
    End Sub

    Private Sub cboProject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProject.SelectedIndexChanged
        If boolCalledFromProjects = True Then Exit Sub
        SelectProject()
    End Sub

    Private Sub SelectProject()
        intSelectedProjectNumber = 0
        If Not String.IsNullOrEmpty(cboProject.Text) Then
            Dim strSplit() As String = Split(cboProject.Text, "..")
            intSelectedProjectNumber = CInt(strSplit(1))
            lblProjectNo.Text = intSelectedProjectNumber
        End If
    End Sub

End Class