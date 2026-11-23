Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCashbookDataEntry

    Dim boolFormLoading As Boolean

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex = 8 Or e.ColumnIndex = 9 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
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

    Private Sub dpTransDate_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dpTransDate.KeyDown
        If e.KeyData = Keys.Enter Then
            cboCashbook.Select()
        End If
    End Sub

    Private Sub cboCashbook_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCashbook.KeyDown
        If e.KeyData = Keys.Enter Then
            cboEntryType.Select()
        End If
    End Sub

    Private Sub cboEntryType_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboEntryType.KeyDown
        If e.KeyData = Keys.Enter Then
            txtDescription.Select()
        End If
    End Sub

    Private Sub txtDescription_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescription.KeyDown
        If e.KeyData = Keys.Enter Then
            txtReference.Select()
        End If
    End Sub

    Private Sub txtReference_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtReference.KeyDown
        If e.KeyData = Keys.Enter Then
            cboLedgerAccounts.Select()
        End If
    End Sub

    Private Sub cboLedgerAccounts_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboLedgerAccounts.KeyDown
        If e.KeyData = Keys.Enter Then
            txtAmount.Select()
        End If
    End Sub

    Private Sub txtVatAmt_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtVatAmt.KeyDown
        If e.KeyData = Keys.Enter Then
            cboVatNo.Select()
        End If
    End Sub

    Private Sub cboVatNo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboVatNo.KeyDown
        If e.KeyData = Keys.Enter Then
            btnAccept.Select()
        End If
    End Sub

    Private Sub cboProjectLink_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboProjectLink.KeyDown
        If e.KeyData = Keys.Enter Then
            txtVatAmt.Select()
        End If
    End Sub

    Private Sub cboCostCenter_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCostCenter.KeyDown
        If e.KeyData = Keys.Enter Then
            cboProjectLink.Select()
        End If
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyData = Keys.Enter Then
            cboCostCenter.Select()
        End If
    End Sub

    Private Sub frmCashbookDataEntry_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If dGrid.Rows.Count > 0 Then
            If MessageBox.Show("You have items not saved. Do you want to save them before closing?", "Auto Save Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                SaveItems()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub frmCashbookDataEntry_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        txtAmount.BackColor = Color.Yellow
        boolAbort = False
        LoadCashbookAccounts()
        If boolAbort = True Then Exit Sub
        LoadLedgerAccounts()
        If boolAbort = True Then Exit Sub
        LoadCostCenters()
        If boolCalledFromProjects = True Then
            cboProjectLink.Text = "YES"
            lblProjectNo.Text = CStr(lngPublicLinkedProjectNumber)
        Else
            cboProjectLink.Text = "NO"
        End If

        cboEntryType.Text = "CREDIT"
        dpTransDate.Select()
        boolFormLoading = False
    End Sub

    Private Sub LoadCashbookAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountNumber +';'+AccountName AS " _
            & "[Accounts] FROM Cashbooks ORDER BY AccountName"
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
        strErrorMessages = Err.Description & " " & Err.Number & " on Cashbooks Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadLedgerAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM LedgerAccounts ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboLedgerAccounts
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

        Dim arrItems As New ArrayList
        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim intItemsCount As Integer = arrItems.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboLedgerAccounts.Items.Clear()

        For p As Integer = 0 To arrItems.Count - 1           '
            Dim strRecordText() As String = Split(arrItems.Item(p), ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        If intItemsCount > 0 Then
            cboLedgerAccounts.SelectedIndex = -1
            cboLedgerAccounts.Items.Clear()
            cboLedgerAccounts.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboLedgerAccounts.Items.AddRange(DropDownItems)
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Accounts Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadCostCenters()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = "SELECT SystemCostCenters.CostCenterName +';'+ CONVERT(NVARCHAR, SystemCostCenters.OrdinalNo) " _
            & "FROM SystemCostCenters ORDER BY SystemCostCenters.CostCenterName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        With cboCostCenter
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

        Dim arrCostCenters As New ArrayList

        arrCostCenters.Add("0;--None--")

        While objReader.Read
            arrCostCenters.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Get a count of the items
        Dim intItemsCount As Integer = arrCostCenters.Count


        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboCostCenter.Items.Clear()

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrCostCenters.Count - 1
            Dim strRecordText() As String = Split(arrCostCenters.Item(p), ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        If intItemsCount > 0 Then
            cboCostCenter.SelectedIndex = -1
            cboCostCenter.Items.Clear()
            cboCostCenter.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCostCenter.Items.AddRange(DropDownItems)
        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Cost Centers Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnBrowseLedger_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowseLedger.Click
        strSelectedAccount = Nothing
        gwt_comm.SearchForLedgerAccount()
        cboLedgerAccounts.Text = strSelectedAccount
        lblLedgerDescription.Text = strSelectedAccountName
        txtVatAmt.Select()
    End Sub

    Private Sub cboEntryType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEntryType.SelectedIndexChanged
        UpdateInformation()
    End Sub

    Private Sub UpdateInformation()
        With lblInfo
            If UCase(cboEntryType.Text) = UCase("DEBIT") Then
                .BackColor = Color.DarkGreen
                .ForeColor = Color.White
                .Text = "Receipts/Incomes"
            Else
                .BackColor = Color.Firebrick
                .ForeColor = Color.White
                .Text = "Expenses/Outflows"
            End If
        End With
    End Sub

    Private Sub cboCashbook_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCashbook.SelectedIndexChanged
        lblCashbookDescription.Text = ""
        If Not cboCashbook.SelectedItem Is Nothing Then
            lblCashbookDescription.Text = cboCashbook.SelectedItem.Col2
        End If
    End Sub

    Private Sub frmCashbookDataEntry_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 770 : Me.Height = 550
    End Sub

    Private Sub cboLedgerAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLedgerAccounts.SelectedIndexChanged
        lblLedgerAccount.Text = ""
        If Not cboLedgerAccounts.SelectedItem Is Nothing Then
            lblLedgerAccount.Text = cboLedgerAccounts.SelectedItem.Col2
        End If
    End Sub

    Private Sub btnAccept_Click(sender As System.Object, e As System.EventArgs) Handles btnAccept.Click
        'Validate the data
        If String.IsNullOrEmpty(lblCashbookDescription.Text) Then
            MessageBox.Show("Please select the cashbook", "Invalid Cashbook", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCashbook.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblLedgerAccount.Text) Then
            MessageBox.Show("Please select the ledger account", "Invalid Ledger Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboLedgerAccounts.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter description", "Missing Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Select()
            Exit Sub
        End If

        If Not IsNumeric(txtVatAmt.Text) Then txtVatAmt.Text = "0.00"
        If Not IsNumeric(lblCostCenter.Text) Then lblCostCenter.Text = "0"

        If CDbl(txtVatAmt.Text) <> 0 Then
            If String.IsNullOrEmpty(cboVatNo.Text) Then
                MessageBox.Show("You have entered VAT but no VAT Number", "Missing VAT Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboVatNo.Select()
                Exit Sub
            End If
        End If

        If UCase(cboProjectLink.Text) = "YES" Then
            If String.IsNullOrEmpty(lblProjectNo.Text) Then
                MessageBox.Show("You have linked this entry to a project and yet no project selected", "Missing Project Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboProjectLink.Select()
                Exit Sub
            End If
        End If

        If Not IsNumeric(txtAmount.Text) Then txtAmount.Text = "0.00"

        If CDbl(txtAmount.Text) = 0 Then
            MessageBox.Show("Transaction amount is zero (0). Process will not proceed", "Amount Zero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Select()
            Exit Sub
        End If

        If Not IsNumeric(lblProjectNo.Text) Then lblProjectNo.Text = "0"

        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        With dGrid
            dGrid.Rows.Add(UCase(gwt_comm.shortMonthDateFormat(dpTransDate.Value)), cboCashbook.Text, lblLedgerAccount.Text,
                    txtDescription.Text, cboEntryType.Text, lblCostCenter.Text, txtReference.Text,
                    cboVatNo.Text, Format(CDbl(txtVatAmt.Text), "##0.00"), Format(CDbl(txtAmount.Text), "##0.00"),
                    lblProjectNo.Text)
            ComputeTotals()
            ResetControls()
            txtDescription.Select()
        End With
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on transaction capture"
        ShowErrorMessage()
    End Sub

    Private Sub cboProjectLink_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProjectLink.SelectedIndexChanged
        If boolFormLoading = True Then Exit Sub
        lblProjectNo.Text = Nothing
        lngPublicLinkedProjectNumber = 0
        If UCase(cboProjectLink.Text) = UCase("YES") Then
            'Load then project selection
            boolAbort = False
            Dim frm As New frmProjectSelect
            frm.ShowDialog()
            If boolAbort = True Then Exit Sub
            lblProjectNo.Text = CStr(lngPublicLinkedProjectNumber)
            If lngPublicLinkedProjectNumber = 0 Then cboProjectLink.Text = "NO"
        End If
    End Sub

    Private Sub ResetControls()
        txtDescription.Clear()
        txtReference.Clear()
        cboLedgerAccounts.Text = ""
        txtVatAmt.Text = "0.00"
        cboVatNo.Items.Clear()
        cboProjectLink.Text = "NO"
        lblProjectNo.Text = "0"
        cboCostCenter.Text = "0"
        txtAmount.Text = "0.00"
    End Sub

    Private Sub ComputeTotals()

        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        lblCredits.Text = "0.00"
        lblDebits.Text = "0.00"
        lblBalance.Text = "0.00"

        Dim dblDebits As Double = 0
        Dim dblCredits As Double = 0
        Dim dblVatNet As Double = 0

        With dGrid

            For p As Integer = 0 To .RowCount - 1

                Dim strType As String = Nothing
                Dim dblAmount As Double = 0
                Dim dblVat As Double = 0

                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString) Then
                        strType = .Rows(p).Cells(4).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(8).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(8).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(8).Value.ToString) Then
                            dblVat = CDbl(.Rows(p).Cells(8).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(9).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(9).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(9).Value.ToString) Then
                            dblAmount = CDbl(.Rows(p).Cells(9).Value.ToString)
                        End If
                    End If
                End If

                If UCase(strType) = UCase("DEBIT") Then
                    dblDebits = dblDebits + dblAmount
                    dblVatNet = dblVatNet + dblVat
                Else
                    dblCredits = dblCredits + dblAmount
                    dblVatNet = dblVatNet - dblVat
                End If

            Next

        End With

        lblDebits.Text = Format(dblDebits, "#,##0.00")
        lblCredits.Text = Format(dblCredits, "#,##0.00")
        lblVat.Text = Format(dblVatNet, "#,##0.00")
        lblBalance.Text = Format(dblDebits - dblCredits, "#,##0.00")

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on transaction totals computation"
        ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        SaveItems()
    End Sub

    Private Sub SaveItems()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        With dGrid

            For p As Integer = 0 To .Rows.Count - 1

                Dim strDate As String = gwt_comm.shortMonthDateFormat(Now)
                Dim strCashbookAccount As String = Nothing
                Dim strLedgerAccount As String = Nothing
                Dim strDescription As String = Nothing
                Dim strEntryType As String = Nothing
                Dim intCostCenter As Integer = 0
                Dim strReference As String = Nothing
                Dim strVatNumber As String = Nothing
                Dim dblVatAmount As Double = 0
                Dim dblAmount As Double = 0
                Dim intProjectNo As Integer = 0

                If Not Object.Equals(.Rows(p).Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(0).Value.ToString) Then
                        strDate = .Rows(p).Cells(0).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(1).Value.ToString) Then
                        strCashbookAccount = .Rows(p).Cells(1).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(2).Value.ToString) Then
                        strLedgerAccount = .Rows(p).Cells(2).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(3).Value.ToString) Then
                        strDescription = .Rows(p).Cells(3).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString) Then
                        strEntryType = .Rows(p).Cells(4).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(5).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(5).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(5).Value.ToString) Then
                            intCostCenter = CInt(.Rows(p).Cells(5).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(6).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(6).Value.ToString) Then
                        strReference = .Rows(p).Cells(6).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(7).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(7).Value.ToString) Then
                        strVatNumber = .Rows(p).Cells(7).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(8).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(8).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(8).Value.ToString) Then
                            dblVatAmount = CDbl(.Rows(p).Cells(8).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(9).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(9).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(9).Value.ToString) Then
                            dblAmount = CDbl(.Rows(p).Cells(9).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(10).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(10).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(10).Value.ToString) Then
                            intProjectNo = CInt(.Rows(p).Cells(10).Value.ToString)
                        End If
                    End If
                End If

                'Get the special key
                Dim intSpecialKey As Integer = gwt_comm.SpecialKey

                'Insert into the cashbook

                Dim strSql As String = Nothing
                Dim objCommand As Data.OleDb.OleDbCommand

                strSql = "INSERT INTO CashbookTransactions ([TransactionDate], [AccountNumber], [ContraAccount], " _
                    & "[Description], [TransactionType], [CostCode], [UserReference], [VatNumber], [VatAmount], " _
                    & "[Amount], [LinkedProject], [SpecialKey], [UserName], [UserBranch]) VALUES " _
                    & "('" & strDate & "', '" & strCashbookAccount & "', '" & strLedgerAccount & "', " _
                    & "'" & strDescription & "', '" & strEntryType & "', " & intCostCenter & ", '" & strReference & "', " _
                    & "'" & strVatNumber & "', " & dblVatAmount & ", " & dblAmount & ", " & intProjectNo & ", " _
                    & "" & intSpecialKey & ", '" & strUserName & "', '" & strUserBranch & "')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                Dim strContraType As String = Nothing
                If UCase(strEntryType) = UCase("DEBIT") Then strContraType = UCase("CREDIT") Else strContraType = UCase("DEBIT")

                'Split the amount int the ledger to VAT and Ledger
                dblAmount = dblAmount - dblVatAmount
                strSql = "INSERT INTO LedgerTransactions ([TransactionDate], [AccountNumber], [Amount], [TransactionType], " _
                    & "[ContraAccount], [Description], [UserName], [UserBranch], [Reference], [CostCode], [LinkedProject], " _
                    & "[SpecialKey]) VALUES ('" & strDate & "', '" & strLedgerAccount & "', " & dblAmount & ", '" & strContraType & "', " _
                    & "'" & strCashbookAccount & "', '" & strDescription & "', '" & strUserName & "', '" & strUserBranch & "', " _
                    & "'" & strReference & "', " & intCostCenter & ", " & intProjectNo & ", " & intSpecialKey & ")"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                If dblVatAmount <> 0 Then
                    If Not String.IsNullOrEmpty(strPublicVatControlAccount) Then
                        strSql = "INSERT INTO LedgerTransactions ([TransactionDate], [AccountNumber], [Amount], [TransactionType], " _
                            & "[ContraAccount], [Description], [UserName], [UserBranch], [Reference], [CostCode], [LinkedProject], " _
                            & "[SpecialKey]) VALUES ('" & strDate & "', '" & strPublicVatControlAccount & "', " & dblAmount & ", '" & strContraType & "', " _
                            & "'" & strCashbookAccount & "', '" & strDescription & "', '" & strUserName & "', '" & strUserBranch & "', " _
                            & "'" & strReference & "', " & intCostCenter & ", " & intProjectNo & ", " & intSpecialKey & ")"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                End If

            Next

        End With

        Cursor = Cursors.Default
        dGrid.Rows.Clear()

        MessageBox.Show("Transactions have been posted successfully into the cash book", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on transaction totals computation"
        ShowErrorMessage()
    End Sub

    Private Sub btnClearAll_Click(sender As System.Object, e As System.EventArgs) Handles btnClearAll.Click
        ResetControls()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
        ComputeTotals()
    End Sub

    Private Sub cboCostCenter_Leave(sender As Object, e As System.EventArgs) Handles cboCostCenter.Leave
        If String.IsNullOrEmpty(cboCostCenter.Text) Then cboCostCenter.Text = "0"
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        ResetControls()
        dpTransDate.Select()
    End Sub

    Private Sub txtAmount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAmount.Validating
        If Not IsNumeric(txtAmount.Text) Then txtAmount.Text = "0.00"
        Dim dblComputedVat As Double = 0
        txtVatAmt.Enabled = True : cboVatNo.Enabled = True
        If CDbl(txtAmount.Text) = 0 Then
            txtVatAmt.Text = "0.00"
            txtVatAmt.Enabled = False
            cboVatNo.Enabled = False
        Else

            Select Case UCase(cboEntryType.Text)
                Case Is = UCase("DEBIT")
                    If boolPublicAutoCalculateReceiptsVat = True Then
                        If chkVatStatus.Checked = True Then
                            dblComputedVat = CDbl(txtAmount.Text) * (100 / (100 + dblSalesTaxRate))
                        Else
                            dblComputedVat = CDbl(txtAmount.Text) * (dblSalesTaxRate / 100)
                        End If
                    End If
                Case Is = UCase("CREDIT")
                    If boolPublicAutoCalculateExpensesVat = True Then
                        If chkVatStatus.Checked = True Then
                            dblComputedVat = CDbl(txtAmount.Text) - (CDbl(txtAmount.Text) * (100 / (100 + dblSalesTaxRate)))
                        Else
                            dblComputedVat = CDbl(txtAmount.Text) * (dblSalesTaxRate / 100)
                        End If
                    End If
            End Select
        End If
        txtVatAmt.Text = Format(dblComputedVat, "##0.00")
    End Sub

    Private Sub DeleteRowToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteRowToolStripMenuItem.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
        ComputeTotals()
    End Sub

    Private Sub mnuEditDate_Click(sender As System.Object, e As System.EventArgs) Handles mnuEditDate.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        boolAbort = False
        gwt_comm.DateSpecification()
        If boolAbort = True Then Exit Sub
        dGrid.CurrentRow.Cells(0).Value = gwt_comm.shortMonthDateFormat(dtSetDate)
    End Sub

    Private Sub txtDescription_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDescription.Validating
        If Not String.IsNullOrEmpty(txtDescription.Text) Then
            LoadPossibleVatNumbers(txtDescription.Text)
        End If
    End Sub

    Private Sub LoadPossibleVatNumbers(ByVal CustomerName As String)
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = "SELECT [VatNumber] + '|'+ [Description] FROM CashbookTransactions " _
            & "WHERE [Description] LIKE '%" & txtDescription.Text & "%'"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        With cboVatNo
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

        Dim arrValues As New ArrayList

        ' arrCostCenters.Add("0;--None--")

        While objReader.Read
            arrValues.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Add any that may have been added in the grid
        If gwt_comm.CheckTableExistence("Temp_Vats") = False Then
            strSql = "CREATE TABLE Temp_Vats ([Description][NVARCHAR](MAX) NOT NULL DEFAULT '', [VatNo][NVARCHAR](35) NOT NULL DEFAULT '')"
        Else
            strSql = "DELETE FROM Temp_Vats"
        End If
        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        sqlCommand.ExecuteNonQuery()

        For j As Integer = 0 To dGrid.RowCount - 1
            Dim strDesc As String = Nothing
            Dim strVat As String = Nothing
            If Not Object.Equals(dGrid.Rows(j).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(j).Cells(3).Value.ToString) Then
                    strDesc = dGrid.Rows(j).Cells(3).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(j).Cells(7).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(j).Cells(7).Value.ToString) Then
                    strVat = dGrid.Rows(j).Cells(7).Value.ToString
                End If
            End If
            strSql = "INSERT INTO Temp_Vats (Description, VatNo) VALUES ('" & strDesc & "', '" & strVat & "')"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            sqlCommand.ExecuteNonQuery()
        Next

        For p As Integer = 0 To arrValues.Count - 1
            Dim strSplitValues() As String = Split(arrValues.Item(p), "|")
            strSql = "INSERT INTO Temp_Vats (Description, VatNo) VALUES ('" & strSplitValues(1) & "', '" & strSplitValues(0) & "')"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            sqlCommand.ExecuteNonQuery()
        Next

        arrValues = New ArrayList

        'strSql = "SELECT DISTINCT([VatNo]) + '|'+ [Description] FROM Temp_Vats " _
        '    & "WHERE [Description] LIKE '%" & txtDescription.Text & "%' GROUP BY [Description] ORDER BY [Description]"
        strSql = "SELECT DISTINCT([VatNo]) + '|'+ [Description] AS [sVal] FROM Temp_Vats " _
            & "WHERE [Description] LIKE '%" & txtDescription.Text & "%' GROUP BY [Description], [VatNo] ORDER BY sVal"

        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
           arrValues.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Get a count of the items
        Dim intItemsCount As Integer = arrValues.Count


        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboVatNo.Items.Clear()

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrValues.Count - 1
            Dim strRecordText() As String = Split(arrValues.Item(p), "|")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        With cboVatNo
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
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On possible VAT numbers fetch"
        ShowErrorMessage()
    End Sub

    Private Sub cboCostCenter_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCostCenter.SelectedIndexChanged
        lblCostCenter.Text = Nothing
        If Not cboCostCenter.SelectedItem Is Nothing Then
            lblCostCenter.Text = cboCostCenter.SelectedItem.Col2
        End If
    End Sub
End Class