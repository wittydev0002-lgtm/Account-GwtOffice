Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSpecialLedgerAccounts

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(cboAccount.Text) Or String.IsNullOrEmpty(lblAccountDescription.Text) Then
            MessageBox.Show("Please enter a valid account which has been set up in the ledger", _
                "Invalid Ledger Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccount.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboDebtors.Text) Or String.IsNullOrEmpty(lblDebtorsDescription.Text) Then
            MessageBox.Show("Please enter a valid debtors account which has been set up in the ledger", _
                "Invalid Debtors Ledger Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboDebtors.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboCreditors.Text) Or String.IsNullOrEmpty(lblCreditorsDescription.Text) Then
            MessageBox.Show("Please enter a valid creditor control account which has been set up in the ledger", _
                "Invalid Creditors Ledger Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCreditors.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboCreditors.Text) Or String.IsNullOrEmpty(lblCashControlDescription.Text) Then
            MessageBox.Show("Please enter a valid cash control account which has been set up in the ledger", _
                "Invalid Cash Control Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCashControl.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboAccount.Text) Or String.IsNullOrEmpty(lblAccountDescription.Text) Then
            MessageBox.Show("Please enter a valid sales control account which has been set up in the ledger", _
                "Invalid Sales Ledger Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccount.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboStaffDebtors.Text) Or String.IsNullOrEmpty(lblStaffDebtorsDescription.Text) Then
            MessageBox.Show("Please enter a valid staff debtors control account which has been set up in the ledger", _
                "Invalid Staff Debtors Ledger Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboStaffDebtors.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboCostOfSales.Text) Or String.IsNullOrEmpty(lblCostOfSales.Text) Then
            MessageBox.Show("Please enter a valid cost of sales control account which has been set up in the ledger", _
                "Invalid Cost of Sales Ledger Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCostOfSales.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboInterCompany.Text) Or String.IsNullOrEmpty(lblInterCompany.Text) Then
            If MessageBox.Show("Inter company control account has not been set. It may be a problem if you have to transfer stock or cash against other company branches. Are you sure you want to proceed", _
                "Invalid Cost of Sales Ledger Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = MsgBoxResult.No Then
                'cboInterCompany.Focus()
                'Exit Sub
            End If
        End If

        'If String.IsNullOrEmpty(cboLaschPremiumsControl.Text) Or String.IsNullOrEmpty(lblLaschPremiumsControl.Text) Then
        '    'If MessageBox.Show("Lasch insurance premiums control account has not been set. Are you sure you want to proceed", _
        '    '    "Invalid Lasch Premiums Ledger Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = MsgBoxResult.No Then
        '    '    'cboInterCompany.Focus()
        '    '    'Exit Sub
        '    'End If
        'End If

        Dim objCommand As Data.OleDb.OleDbCommand
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SpecialLedgerAccounts", cnn)
        objCommand.ExecuteNonQuery()
        Dim strSql As String = "INSERT INTO SpecialLedgerAccounts " _
            & "([SalesControl], [TradeDebtorsControl], [StaffDebtorsControl], [CreditorsControl], " _
            & "[PurchasesControl], [CashControl], [TaxControl], [CostOfSales], [InterCompanyControl], " _
            & "[LaschPremiumsControl], [ReservesControl], [TrustControl]) VALUES ('" & cboAccount.Text & "', '" & cboDebtors.Text & "', " _
            & "'" & cboStaffDebtors.Text & "', '" & cboCreditors.Text & "', '" & cboPurchases.Text & "', " _
            & "'" & cboCashControl.Text & "', '" & cboTaxControl.Text & "', '" & cboCostOfSales.Text & "', " _
            & "'" & cboInterCompany.Text & "', '" & cboLaschPremiumsControl.Text & "', " _
            & "'" & cboReservesControl.Text & "', '" & cboTrustControl.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strPublicSalesAccount = cboAccount.Text
        strPublicDebtorsAccount = cboDebtors.Text
        strPublicStaffDebtorsAccount = cboStaffDebtors.Text
        strPublicCreditorsAccount = cboCreditors.Text
        strPublicPurchasesAccount = cboPurchases.Text
        strPublicCashControlAccount = cboCashControl.Text
        strPublicTaxesAccount = cboTaxControl.Text
        strPublicCostOfSales = cboCostOfSales.Text
        strPublicInterCompanyControlAccount = cboInterCompany.Text
        strPublicLaschPremiumsControlAccount = cboLaschPremiumsControl.Text
        strPublicReservesControlAccount = cboReservesControl.Text
        strPublicTrustControlAccount = cboReservesControl.Text

        MessageBox.Show("Special ledger control accounts defined successfully", _
            "Special Ledger Control Accounts Definition", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On default sales control account setup"
        ShowErrorMessage()
    End Sub

    Private Sub cboAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccount.SelectedIndexChanged
        lblAccountDescription.Text = ""
        If Not cboAccount.SelectedItem Is Nothing Then
            lblAccountDescription.Text = cboAccount.SelectedItem.Col2
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountNumber +';'+AccountName AS " _
            & "[Accounts] FROM LedgerAccounts ORDER BY AccountNumber"
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
        With cboDebtors
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
        With cboCreditors
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
        With cboPurchases
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
        With cboCashControl
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

        With cboTaxControl
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

        With cboStaffDebtors
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

        With cboCostOfSales
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

        With cboInterCompany
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

        With cboLaschPremiumsControl
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

        With cboReservesControl
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

        With cboTrustControl
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
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM LedgerAccounts", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboAccount.Items.Clear()
        cboDebtors.Items.Clear()
        cboCreditors.Items.Clear()
        cboPurchases.Items.Clear()
        cboCashControl.Items.Clear()
        cboTaxControl.Items.Clear()
        cboStaffDebtors.Items.Clear()
        cboCostOfSales.Items.Clear()
        cboInterCompany.Items.Clear()
        cboLaschPremiumsControl.Items.Clear()
        cboReservesControl.Items.Clear()
        cboTrustControl.Items.Clear()

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

            cboDebtors.SelectedIndex = -1
            cboDebtors.Items.Clear()
            cboDebtors.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboDebtors.Items.AddRange(DropDownItems)

            cboCreditors.SelectedIndex = -1
            cboCreditors.Items.Clear()
            cboCreditors.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCreditors.Items.AddRange(DropDownItems)

            cboPurchases.SelectedIndex = -1
            cboPurchases.Items.Clear()
            cboPurchases.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboPurchases.Items.AddRange(DropDownItems)

            cboCashControl.SelectedIndex = -1
            cboCashControl.Items.Clear()
            cboCashControl.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCashControl.Items.AddRange(DropDownItems)

            cboTaxControl.SelectedIndex = -1
            cboTaxControl.Items.Clear()
            cboTaxControl.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboTaxControl.Items.AddRange(DropDownItems)

            cboStaffDebtors.SelectedIndex = -1
            cboStaffDebtors.Items.Clear()
            cboStaffDebtors.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboStaffDebtors.Items.AddRange(DropDownItems)

            cboCostOfSales.SelectedIndex = -1
            cboCostOfSales.Items.Clear()
            cboCostOfSales.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCostOfSales.Items.AddRange(DropDownItems)

            cboInterCompany.SelectedIndex = -1
            cboInterCompany.Items.Clear()
            cboInterCompany.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboInterCompany.Items.AddRange(DropDownItems)

            cboLaschPremiumsControl.SelectedIndex = -1
            cboLaschPremiumsControl.Items.Clear()
            cboLaschPremiumsControl.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboLaschPremiumsControl.Items.AddRange(DropDownItems)

            cboReservesControl.SelectedIndex = -1
            cboReservesControl.Items.Clear()
            cboReservesControl.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboReservesControl.Items.AddRange(DropDownItems)

            cboTrustControl.SelectedIndex = -1
            cboTrustControl.Items.Clear()
            cboTrustControl.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboTrustControl.Items.AddRange(DropDownItems)

        End If

        'Get the set accounts from the control accounts
        'Get the default control accounts
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT [SalesControl], [TradeDebtorsControl], " _
            & "[StaffDebtorsControl], [CreditorsControl], [PurchasesControl], [CashControl], " _
            & "[TaxControl], [CostOfSales], [InterCompanyControl], [LaschPremiumsControl], [ReservesControl], " _
            & "[TrustControl] FROM SpecialLedgerAccounts", cnn)
        objReader = sqlCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then cboAccount.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then cboDebtors.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then cboStaffDebtors.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then cboCreditors.Text = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then cboPurchases.Text = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then cboCashControl.Text = objReader(5).ToString
            If Not IsDBNull(objReader(6).ToString) Then cboTaxControl.Text = objReader(6).ToString
            If Not IsDBNull(objReader(7).ToString) Then cboCostOfSales.Text = objReader(7).ToString
            If Not IsDBNull(objReader(8).ToString) Then cboInterCompany.Text = objReader(8).ToString
            If Not IsDBNull(objReader(9).ToString) Then cboLaschPremiumsControl.Text = objReader(9).ToString
            If Not IsDBNull(objReader(10).ToString) Then cboReservesControl.Text = objReader(10).ToString
            If Not IsDBNull(objReader(11).ToString) Then cboTrustControl.Text = objReader(11).ToString
        End If
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Account Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmSalesLedgerAccountDefinition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub cboTrustControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTrustControl.SelectedIndexChanged
        lblTrustControl.Text = ""
        If Not cboTrustControl.SelectedItem Is Nothing Then
            lblTrustControl.Text = cboTrustControl.SelectedItem.Col2
        End If
    End Sub

    Private Sub cboDebtors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDebtors.SelectedIndexChanged
        lblDebtorsDescription.Text = ""
        If Not cboDebtors.SelectedItem Is Nothing Then
            lblDebtorsDescription.Text = cboDebtors.SelectedItem.Col2
        End If
    End Sub

    Private Sub cboCreditors_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCreditors.SelectedIndexChanged
        lblCreditorsDescription.Text = ""
        If Not cboCreditors.SelectedItem Is Nothing Then
            lblCreditorsDescription.Text = cboCreditors.SelectedItem.Col2
        End If
    End Sub

    Private Sub cboPurchases_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPurchases.SelectedIndexChanged
        lblPurchasesDescription.Text = ""
        If Not cboPurchases.SelectedItem Is Nothing Then
            lblPurchasesDescription.Text = cboPurchases.SelectedItem.Col2
        End If
    End Sub

    Private Sub cboTaxControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTaxControl.SelectedIndexChanged
        lblTaxControl.Text = ""
        If Not cboTaxControl.SelectedItem Is Nothing Then
            lblTaxControl.Text = cboTaxControl.SelectedItem.Col2
        End If
    End Sub

    Private Sub cboInterCompany_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboInterCompany.SelectedIndexChanged
        lblInterCompany.Text = ""
        If Not cboInterCompany.SelectedItem Is Nothing Then
            lblInterCompany.Text = cboInterCompany.SelectedItem.Col2
        End If
    End Sub

    Private Sub cboCashControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCashControl.SelectedIndexChanged
        lblCashControlDescription.Text = ""
        If Not cboCashControl.SelectedItem Is Nothing Then
            lblCashControlDescription.Text = cboCashControl.SelectedItem.Col2
        End If
    End Sub

    Private Sub cboStaffDebtors_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboStaffDebtors.SelectedIndexChanged
        lblStaffDebtorsDescription.Text = ""
        If Not cboStaffDebtors.SelectedItem Is Nothing Then
            lblStaffDebtorsDescription.Text = cboStaffDebtors.SelectedItem.Col2
        End If
    End Sub

    Private Sub cboCostOfSales_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCostOfSales.SelectedIndexChanged
        lblCostOfSales.Text = ""
        If Not cboCostOfSales.SelectedItem Is Nothing Then
            lblCostOfSales.Text = cboCostOfSales.SelectedItem.Col2
        End If
    End Sub

    Private Sub cboLaschPremiumsControl_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboLaschPremiumsControl.SelectedIndexChanged
        lblLaschPremiumsControl.Text = ""
        If Not cboLaschPremiumsControl.SelectedItem Is Nothing Then
            lblLaschPremiumsControl.Text = cboLaschPremiumsControl.SelectedItem.Col2
        End If
    End Sub

    Private Sub cboReservesControl_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboReservesControl.SelectedIndexChanged
        lblReservesControl.Text = ""
        If Not cboReservesControl.SelectedItem Is Nothing Then
            lblReservesControl.Text = cboReservesControl.SelectedItem.Col2
        End If
    End Sub

End Class