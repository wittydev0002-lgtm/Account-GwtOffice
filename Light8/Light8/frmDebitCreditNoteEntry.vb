Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDebitCreditNoteEntry

    Dim boolFormLoading As Boolean

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub frmDebitCreditNoteEntry_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Enter Or e.KeyValue = 9 Or e.KeyValue = Keys.F5 Then
            If dGrid.CurrentCell.ColumnIndex = 0 Then
                strPublicItemCode = Nothing
                strFullItemDetails = Nothing
                boolAbort = False
                gwt_comm.InventorySearch()
                If boolAbort = True Then Exit Sub
                CommitValueChanged()
                dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(2)
            End If
        End If

        If e.KeyValue = Keys.F3 Then
            FinishTransaction()
        End If

    End Sub

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr
        
        Dim objCommand As Data.OleDb.OleDbCommand
        For z As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.CurrentRow.Cells(z).Value = Nothing
        Next

        Dim boolItemTaxable As Boolean = True

        RecalculateAmount()

        If Not String.IsNullOrEmpty(strFullItemDetails) Then

            Dim strSplitValues() As String = Split(strFullItemDetails, ";")

            dGrid.CurrentRow.Cells(0).Value = UCase(strSplitValues(0))
            dGrid.CurrentRow.Cells(1).Value = UCase(strSplitValues(1))
            dGrid.CurrentRow.Cells(3).Value = strSplitValues(2)
            dGrid.CurrentRow.Cells(4).Value = "1"
            dGrid.CurrentRow.Cells(6).Value = "0"

            If UCase(strSplitValues(4)) = "YES" Then boolItemTaxable = True Else boolItemTaxable = False

            'Get the item type
            dGrid.CurrentRow.Cells(5).ReadOnly = False
            Dim strCodeSelected As String = dGrid.CurrentRow.Cells(0).Value.ToString
            Dim dblSalePrice As Double = 0
            objCommand = New Data.OleDb.OleDbCommand("SELECT InventoryType, SellingPrice FROM InventoryItems " _
                & "WHERE ItemCode = '" & strCodeSelected & "'", cnn)
            Dim objReadType As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadType.HasRows Then
                objReadType.Read()
                If Not IsDBNull(objReadType(0).ToString) Then
                    If UCase(objReadType(0).ToString) = "SPECIFIC" Then
                        dGrid.CurrentRow.Cells(5).ReadOnly = True
                    End If
                End If
                If IsNumeric(objReadType(1).ToString) Then dblSalePrice = CDbl(objReadType(1).ToString)
            End If
            objReadType.Close()

            'Apply the discount
            Dim dblDiscounts() As Double = gwt_comm.ItemOnSpecials(strCodeSelected, dblSalePrice)
            dGrid.CurrentRow.Cells(6).Value = CStr(Format((dblDiscounts(1) * CDbl(dGrid.CurrentRow.Cells(4).Value.ToString)), "##0.00"))

            ComputeValues(CDbl(dGrid.CurrentRow.Cells(3).Value.ToString), CDbl(dGrid.CurrentRow.Cells(4).Value.ToString), dGrid.CurrentRow.Index, dGrid.CurrentRow.Cells(6).Value.ToString, 0, boolItemTaxable)
        Else
            dGrid.CurrentRow.Cells(0).Value = Nothing
            dGrid.CurrentRow.Cells(1).Value = Nothing
            dGrid.CurrentRow.Cells(3).Value = Nothing
            dGrid.CurrentRow.Cells(4).Value = Nothing
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On discount computation"
        ShowErrorMessage()
    End Sub

    Private Sub frmDebitCreditNoteEntry_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        LoadClients()
        dGrid.Rows.Add(25)
        If UCase(strCalledBy) = UCase("Customers") Then Me.Text = "Credit Note Entry" Else Me.Text = "Debit Note Entry"
        boolFormLoading = False
    End Sub

    Private Sub frmDebitNoteEntry_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 780 : Me.Height = 555
    End Sub

    Private Sub LoadClients()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        If strCalledBy = UCase("Customers") Then
            Me.Text = "Credit Note Entry"
            strSql = "SELECT AccountName +';'+AccountNumber AS [Customer] FROM Customers ORDER BY AccountName"
        Else
            Me.Text = "Debit Note Entry"
            strSql = "SELECT AccountName +';'+AccountNumber AS [Customer] FROM Suppliers ORDER BY AccountName"
        End If

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        Dim arrDataItems As New ArrayList

        'Set up the drop down combo box
        With cboClientDetails
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "200;80"
        End With

        arrDataItems.Add("--none--; ")

        While objReader.Read
            arrDataItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Get a count of the items
        Dim intItemsCount As Double = arrDataItems.Count - 1

        Dim DropDownItems(intItemsCount) As MTGCComboBoxItem

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrDataItems.Count - 1
            If Not IsDBNull(arrDataItems.Item(p)) Then
                Dim strRecordText() As String = Split(arrDataItems.Item(p), ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            End If
        Next

        If intItemsCount > 0 Then
            cboClientDetails.SelectedIndex = -1
            cboClientDetails.Items.Clear()
            cboClientDetails.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboClientDetails.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " On client names load"
        ShowErrorMessage()
    End Sub

    Private Sub cboClientDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClientDetails.SelectedIndexChanged
        If boolFormLoading = True Then Exit Sub
        lblAccountNumber.Text = Nothing
        LoadTransactions(cboClientDetails.SelectedItem.Col2)
        lblAccountNumber.Text = cboClientDetails.SelectedItem.Col2
    End Sub

    Private Sub LoadTransactions(ByVal AccountNumber As String)
        On Error GoTo RaiseErr

        If boolFormLoading = True Then Exit Sub

        cboTransactions.Enabled = True
        dGrid.Enabled = False

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If UCase(strCalledBy) = UCase("Customers") Then

            If gwt_comm.CheckColumnExistence("CustomerSalesMain", "CurrencyUsed") = False Then
                strSql = "ALTER TABLE [CustomerSalesMain] ADD [CurrencyUsed][NVARCHAR](35) NOT NULL DEFAULT ''"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If

            strSql = "SELECT CustomerSalesMain.InvoiceNumber AS [Doc #], UPPER(REPLACE(CONVERT(CHAR(11), CustomerSalesMain.TransDate, 106), ' ', '-')) as [Date], " _
                & "CAST(CustomerSalesMain.Discount AS DECIMAL (30,2)) AS [Discount], CAST(CustomerSalesMain.Taxes AS DECIMAL (30,2)) AS [Taxes], " _
                & "CAST(CustomerSalesMain.Amount AS DECIMAL (30,2)) AS [Amount], [CurrencyUsed] FROM CustomerSalesMain WHERE CustomerSalesMain.CustomerId = '" & AccountNumber & "' " _
                & "ORDER BY CustomerSalesMain.InvoiceNumber, CustomerSalesMain.TransDate"
        Else

            If gwt_comm.CheckColumnExistence("SupplierInvoicesMain", "CurrencyUsed") = False Then
                strSql = "ALTER TABLE [SupplierInvoicesMain] ADD [CurrencyUsed][NVARCHAR](35) NOT NULL DEFAULT ''"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If

            strSql = "SELECT SupplierInvoicesMain.DocumentNumber AS [Doc #], UPPER(REPLACE(CONVERT(CHAR(11), SupplierInvoicesMain.TransDate, 106), ' ', '-')) as [Date], " _
                & "CAST(SupplierInvoicesMain.Discount AS DECIMAL (30,2)) AS [Discount], CAST(SupplierInvoicesMain.Taxes AS DECIMAL (30,2)) AS [Taxes], " _
                & "CAST(SupplierInvoicesMain.Value AS DECIMAL (30,2)) AS [Amount], [CurrencyUsed] FROM SupplierInvoicesMain WHERE SupplierInvoicesMain.AccountNumber = '" & AccountNumber & "' " _
                & "ORDER BY SupplierInvoicesMain.DocumentNumber, SupplierInvoicesMain.TransDate"
        End If

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim arrTransactions As New ArrayList
        arrTransactions.Add("000;;;;;")

        While objReader.Read
            arrTransactions.Add(objReader(0) & ";" & objReader(1) & ";" & objReader(2) & ";" & objReader(3) & ";" & objReader(4) & ";" & objReader("CurrencyUsed"))
        End While
        objReader.Close()

        Dim intItemsCount As Integer = arrTransactions.Count - 0

        If intItemsCount <= 0 Then
            cboTransactions.Enabled = False
            Exit Sub
        Else
            dGrid.Enabled = True
        End If

        'Set up the drop down combo box
        With cboTransactions
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 6
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "60;100;80;80;80;80"
        End With

        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrTransactions.Count - 1
            If Not String.IsNullOrEmpty(arrTransactions.Item(p)) Then
                Dim strRecordText() As String = Split(arrTransactions.Item(p), ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)),
                    UCase(strRecordText(2)), UCase(strRecordText(3)), UCase(strRecordText(4)), UCase(strRecordText(5)))
            End If
        Next

        With cboTransactions
            If intItemsCount > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " On client transactions load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        UpdateCells()
        ComputeTotals()
    End Sub

    Private Sub UpdateCells()
        If boolFormLoading = True Then Exit Sub
        If IsNumeric(dGrid.CurrentCell.Value) Then
            dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")
        End If
        If dGrid.CurrentCell.ColumnIndex = 3 Or dGrid.CurrentCell.ColumnIndex = 4 _
            Or dGrid.CurrentCell.ColumnIndex = 6 Or dGrid.CurrentCell.ColumnIndex = 7 Then

            Dim dblColumn3 As Double = 0
            Dim dblColumn4 As Double = 0
            Dim dblColumn6 As Double = 0
            Dim dblColumn7 As Double = 0

            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(3).Value), "") Then
                If IsNumeric(dGrid.CurrentRow.Cells(3).Value.ToString) Then
                    dblColumn3 = CDbl(dGrid.CurrentRow.Cells(3).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(4).Value), "") Then
                If IsNumeric(dGrid.CurrentRow.Cells(4).Value.ToString) Then
                    dblColumn4 = CDbl(dGrid.CurrentRow.Cells(4).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(6).Value), "") Then
                If IsNumeric(dGrid.CurrentRow.Cells(6).Value.ToString) Then
                    dblColumn6 = CDbl(dGrid.CurrentRow.Cells(6).Value.ToString)
                End If
            End If

            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(7).Value), "") Then
                If IsNumeric(dGrid.CurrentRow.Cells(7).Value.ToString) Then
                    dblColumn7 = CDbl(dGrid.CurrentRow.Cells(7).Value.ToString)
                End If
            End If

            If dGrid.CurrentCell.ColumnIndex = 7 Then
                If dblColumn7 = 0 Then
                    ComputeValues(dblColumn3, dblColumn4, dGrid.CurrentRow.Index, dblColumn6, 0)
                End If
            Else
                ComputeValues(dblColumn3, dblColumn4, dGrid.CurrentRow.Index, dblColumn6, CommonLibrary.Commons.dblSalesTaxRate)
            End If

            dGrid.CurrentRow.Cells(4).Value = Format(dblColumn4, "##0.00")
        End If
        ComputeTotals()
    End Sub

    Private Sub cboSerials_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(2)
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(3)
            dGrid.Focus()
        End If
    End Sub

    Private Sub ComputeTotals()
        If dGrid.Rows.Count = 0 Then Exit Sub
        Dim dblSubTotal As Double = 0
        Dim dblTaxesTotal As Double = 0
        Dim dblDiscountTotals As Double = 0
        Dim dblTotalPayable As Double = 0
        For n As Double = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(5).Value), "")) Then
                dblSubTotal = dblSubTotal + CDbl(dGrid.Rows(n).Cells(5).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(7).Value), "")) Then
                dblTaxesTotal = dblTaxesTotal + CDbl(dGrid.Rows(n).Cells(7).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(6).Value), "")) Then
                dblDiscountTotals = dblDiscountTotals + CDbl(dGrid.Rows(n).Cells(6).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(8).Value), "")) Then
                dblTotalPayable = dblTotalPayable + CDbl(dGrid.Rows(n).Cells(8).Value.ToString)
            End If
        Next
        lblGross.Text = Format(dblSubTotal, "#,##0.00")
        lblSubTotal.Text = Format((dblSubTotal - dblDiscountTotals - dblTaxesTotal), "#,##0.00")
        lblTaxes.Text = Format(dblTaxesTotal, "#,##0.00")
        lblDiscounts.Text = Format(dblDiscountTotals, "#,##0.00")
        lblNetValue.Text = Format(dblTotalPayable, "#,##0.00")

    End Sub

    Private Sub ComputeValues(ByVal dblUnitPrice As Double, ByVal intQuantity As Double, _
        ByVal intRowIndex As Double, _
        Optional ByVal dblDiscount As Double = 0, Optional ByVal dblTaxRate As Double = 0, Optional ByVal Taxable As Boolean = True)
        Dim dblTaxes As Double = 0
        Dim dblSubTotal As Double = 0
        Dim dblPayable As Double = 0

        'Compute the sub total

        If Taxable = True Then
            If UCase(CommonLibrary.Commons.strTaxComputationType) = "INCLUSIVE" Then
                Dim dblTempTax As Double = 0
                dblTempTax = ((dblUnitPrice * intQuantity) - dblDiscount) - (((dblUnitPrice * intQuantity) - dblDiscount) * (100 / (100 + dblTaxRate)))
                dblSubTotal = (dblUnitPrice * intQuantity) - dblTempTax
            Else
                dblSubTotal = dblUnitPrice * intQuantity
            End If
        End If

        dGrid.Rows(intRowIndex).Cells(5).Value = Format(dblSubTotal, "##0.00")

        'Compute the tax payable
        If Taxable = True Then
            If UCase(CommonLibrary.Commons.strTaxComputationType) = "INCLUSIVE" Then
                dblTaxes = ((dblUnitPrice * intQuantity) - dblDiscount) - (((dblUnitPrice * intQuantity) - dblDiscount) * (100 / (100 + dblTaxRate)))
            Else
                dblTaxes = (dblSubTotal - dblDiscount) * (dblTaxRate / 100) 'dblTaxRate
            End If
        Else
            dblTaxes = 0
        End If

        'If UCase(CommonLibrary.Commons.strTaxComputationType) = "EXCLUSIVE" Then
        dblPayable = (dblSubTotal - dblDiscount) + dblTaxes
        'Else
        '    dblPayable = (dblSubTotal - dblDiscount)
        'End If

        dGrid.Rows(intRowIndex).Cells(7).Value = Format(dblTaxes, "##0.00")
        dGrid.Rows(intRowIndex).Cells(8).Value = Format(dblPayable, "##0.00")

        RecalculateAmount()
        ComputeTotals()

    End Sub

    Private Sub RecalculateAmount()
        Dim dblMovingTotal As Double = 0
        Dim dblSubs As Double = 0
        Dim dblTxs As Double = 0
        Dim dblDis As Double = 0
        For i As Double = 0 To dGrid.Rows.Count - 1
            Dim strValue As String = "0"
            Dim strValTx As String = "0"
            Dim strValDis As String = "0"
            Dim strValSubs As String = "0"
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(8).Value), "")) Then
                strValue = Convert.ToString(dGrid.Rows(i).Cells(8).Value)
                If IsNumeric(strValue) Then
                    dblMovingTotal = dblMovingTotal + CDbl(strValue)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "")) Then
                strValTx = Convert.ToString(dGrid.Rows(i).Cells(7).Value)
                If IsNumeric(strValTx) Then
                    dblTxs = dblTxs + CDbl(strValTx)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(6).Value), "")) Then
                strValDis = Convert.ToString(dGrid.Rows(i).Cells(6).Value)
                If IsNumeric(strValDis) Then
                    dblDis = dblDis + CDbl(strValDis)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                strValSubs = Convert.ToString(dGrid.Rows(i).Cells(5).Value)
                If IsNumeric(strValSubs) Then
                    dblSubs = dblSubs + CDbl(strValSubs)
                End If
            End If

        Next

        lblGross.Text = Format(dblSubs, "#,##0.00")
        lblDiscounts.Text = Format(dblDis, "#,##0.00")
        lblSubTotal.Text = Format((dblSubs - dblDis - dblTxs), "#,##0.00")
        lblTaxes.Text = Format(dblTxs, "#,##0.00")
        lblNetValue.Text = Format(dblMovingTotal, "#,##0.00")

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(lblAccountNumber.Text) Then
            MessageBox.Show("Please select the client from the list", "Missing Client Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClientDetails.Select()
            Exit Sub
        End If
        FinishTransaction()
    End Sub

    Private Sub FinishTransaction()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If boolEditStatus = True Then
            'Delete the record and then re-enter it

        End If

        Dim intSpecialKey As Integer = gwt_comm.SpecialKey
        Dim intDocumentNumber As Integer = 0
        Dim intOriginalDocNo As Integer = 0

        If IsNumeric(cboTransactions.Text) Then intOriginalDocNo = CInt(cboTransactions.Text)

        Dim strQuery As String = Nothing
        Dim objUpdate As Data.OleDb.OleDbCommand

        If gwt_comm.CheckColumnExistence("CreditNotesMain", "OriginalDocumentNo") = False Then
            strQuery = "ALTER TABLE [CreditNotesMain] ADD [OriginalDocumentNo][NVARCHAR](35) NOT NULL DEFAULT 0"
            objUpdate = New Data.OleDb.OleDbCommand(strQuery, cnn)
            objUpdate.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("CreditNotesMain", "Discount") = False Then
            strQuery = "ALTER TABLE [CreditNotesMain] ADD [Discount][FLOAT] NOT NULL DEFAULT 0"
            objUpdate = New Data.OleDb.OleDbCommand(strQuery, cnn)
            objUpdate.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("CreditNotesMain", "Taxes") = False Then
            strQuery = "ALTER TABLE [CreditNotesMain] ADD [Taxes][FLOAT] NOT NULL DEFAULT 0"
            objUpdate = New Data.OleDb.OleDbCommand(strQuery, cnn)
            objUpdate.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("CreditNoteEntries", "Discount") = False Then
            strQuery = "ALTER TABLE [CreditNoteEntries] ADD [Discount][FLOAT] NOT NULL DEFAULT 0"
            objUpdate = New Data.OleDb.OleDbCommand(strQuery, cnn)
            objUpdate.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("CreditNoteEntries", "SerialNo") = False Then
            strQuery = "ALTER TABLE [CreditNoteEntries] ADD [SerialNo][NVARCHAR](35) NOT NULL DEFAULT ''"
            objUpdate = New Data.OleDb.OleDbCommand(strQuery, cnn)
            objUpdate.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("CustomerTransactions", "DocumentNumber") = False Then
            strQuery = "ALTER TABLE [CustomerTransactions] ADD [DocumentNumber][NVARCHAR](35) Not NULL DEFAULT '0'"
            objUpdate = New Data.OleDb.OleDbCommand(strQuery, cnn)
            objUpdate.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("CustomerTransactions", "Taxes") = False Then
            strQuery = "ALTER TABLE [CustomerTransactions] ADD [Taxes][FLOAT] Not NULL DEFAULT 0"
            objUpdate = New Data.OleDb.OleDbCommand(strQuery, cnn)
            objUpdate.ExecuteNonQuery()
        End If

        Dim arrTransactions As New ArrayList

        With dGrid

            For p As Integer = 0 To .Rows.Count - 1
                Dim strItemCode As String = Nothing
                Dim strDescription As String = Nothing
                Dim dblUnitPrice As Double = 0
                Dim dblQuantity As Double = 0
                Dim dblTaxes As Double = 0
                Dim dblDiscount As Double = 0
                Dim strLineType As String = Nothing
                Dim strSerialNo As String = Nothing

                If Not Object.Equals(.Rows(p).Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(0).Value.ToString) Then
                        strItemCode = .Rows(p).Cells(0).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(1).Value.ToString) Then
                        strDescription = .Rows(p).Cells(1).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(2).Value.ToString) Then
                        strSerialNo = .Rows(p).Cells(2).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(3).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(3).Value.ToString) Then
                            dblUnitPrice = CDbl(.Rows(p).Cells(3).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(4).Value.ToString) Then
                            dblQuantity = CDbl(.Rows(p).Cells(4).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(6).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(6).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(6).Value.ToString) Then
                            dblDiscount = CDbl(.Rows(p).Cells(6).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(7).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(7).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(7).Value.ToString) Then
                            dblTaxes = CDbl(.Rows(p).Cells(7).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(9).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(9).Value.ToString) Then
                        strLineType = .Rows(p).Cells(9).Value.ToString
                    End If
                End If

                If ((dblQuantity * dblUnitPrice) - dblDiscount + dblTaxes) <> 0 Then
                    'ItemCode (0), Description(1), SerialNo(2), UnitPrice(3), Quantity(4), Discount(6), Taxes(7), SpecialKey, LineType(9)
                    arrTransactions.Add(strItemCode & "|" & strDescription & "|" & strSerialNo & "|" &
                            CStr(dblUnitPrice) & "|" & CStr(dblQuantity) & "|" & CStr(dblDiscount) & "|" &
                            CStr(dblTaxes) & "|" & CStr(intSpecialKey) & "|" & strLineType)
                End If
            Next

        End With


        'Add the main data first

        Dim strMainTableName As String = Nothing
        Dim strSubTableName As String = Nothing
        Dim strClientDataTableName As String = Nothing
        Dim strTransactionType As String = Nothing
        Dim ControlNumberField As String = Nothing

        If UCase(strCalledBy) = "CUSTOMERS" Then
            strMainTableName = "CreditNotesMain"
            strSubTableName = "CreditNoteEntries"
            strClientDataTableName = "CustomerTransactions"
            strTransactionType = "CREDIT NOTE"
            intDocumentNumber = gwt_comm.GetNextDocumentNumber("CreditNotes")
            ControlNumberField = "CreditNotes"
        Else
            intDocumentNumber = gwt_comm.GetNextDocumentNumber("DebitNotes")
            strMainTableName = "DebitNotesMain"
            strSubTableName = "DebitNoteEntries"
            strClientDataTableName = "SupplierTransactions"
            strTransactionType = "CREDIT NOTE"
            ControlNumberField = "DebitNotes"
        End If

        If gwt_comm.CheckColumnExistence(strMainTableName, "FiscalDay") = False Then
            strQuery = "ALTER TABLE [" & strMainTableName & "] ADD [FiscalDay][NVARCHAR](35) NOT NULL DEFAULT ''"
            objUpdate = New Data.OleDb.OleDbCommand(strQuery, cnn)
            objUpdate.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence(strMainTableName, "FiscalInvoiceNo") = False Then
            strQuery = "ALTER TABLE [" & strMainTableName & "] ADD [FiscalInvoiceNo][NVARCHAR](35) NOT NULL DEFAULT ''"
            objUpdate = New Data.OleDb.OleDbCommand(strQuery, cnn)
            objUpdate.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence(strMainTableName, "CurrencyUsed") = False Then
            strQuery = "ALTER TABLE [" & strMainTableName & "] ADD [CurrencyUsed][NVARCHAR](35) NOT NULL DEFAULT ''"
            objUpdate = New Data.OleDb.OleDbCommand(strQuery, cnn)
            objUpdate.ExecuteNonQuery()
        End If

        strSql = "INSERT INTO " & strMainTableName & " ([NoteNumber], [AccountId], [TransTotal], [TransDate], " _
                & "[Notes], [SpecialKey], [OriginalDocumentNo], [Discount], [Taxes], [UserName], 
                [FiscalDay], [FiscalInvoiceNo], [CurrencyUsed]) VALUES " _
                & "(" & intDocumentNumber & ", '" & lblAccountNumber.Text & "', " & CDbl(lblNetValue.Text) & ", " _
                & "'" & shortMonthDateFormat(dpDate.Value) & "', '" & txtNotes.Text & "', " _
                & "" & intSpecialKey & ", " & intOriginalDocNo & ", " & CDbl(lblDiscounts.Text) & ", " _
                & "" & CDbl(lblTaxes.Text) & ", '" & strUserName & "', '" & txtFiscalDay.Text & "', " _
                & "'" & txtFiscalInvoiceNo.Text & "', '" & lblCurrencyUsed.Text & "')"

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Add the transactions

        For p As Integer = 0 To arrTransactions.Count - 1
            Dim strBuffer() As String = Split(arrTransactions.Item(p), "|")
            'ItemCode (0), Description(1), SerialNo(2), UnitPrice(3), Quantity(4), Discount(6), Taxes(7), SpecialKey, LineType(9)
            strSql = "INSERT INTO " & strSubTableName & " ([NoteNumber], [ItemCode], [Description], [SerialNo], " _
                & "[UnitPrice], [Quantity], [Discount], [Taxes], [SpecialKey], [LineType]) VALUES " _
                & "(" & intDocumentNumber & ", '" & strBuffer(0) & "', '" & strBuffer(1) & "', '" & strBuffer(2) & "', " _
                & "" & CDbl(strBuffer(3)) & ", " & CDbl(strBuffer(4)) & ", " & CDbl(strBuffer(5)) & ", " _
                & "" & CDbl(strBuffer(6)) & ", " & CDbl(strBuffer(7)) & ", '" & strBuffer(8) & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Next

        'Add to the client transaction tables. Note the amount is in negative

        Dim strTransDescription As String = Nothing
        Dim strReferenceNumber As String = cboTransactions.Text

        strSql = "INSERT INTO " & strClientDataTableName & " ([AccountNumber], [TransactionDate], [Amount], [TransactionType], " _
            & "[Description], [ReferenceNumber], [UserName], [BranchName], [DocumentNumber], [Taxes], " _
            & "[SpecialKey], [Comments]) VALUES ('" & lblAccountNumber.Text & "', '" & shortMonthDateFormat(dpDate.Value) & "', " _
            & "" & 0 - CDbl(lblNetValue.Text) & ", '" & strTransactionType & "', '" & strTransDescription & "', " _
            & "'" & strReferenceNumber & "', '" & strUserName & "', '" & strUserBranch & "', " & intDocumentNumber & ", " _
            & "" & CDbl(lblTaxes.Text) & ", " & intSpecialKey & ", '" & txtNotes.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Post to the ledger accounts, if any

        Dim strPostingLedgerAccount As String = Nothing
        Dim strTaxTransType As String = Nothing
        Dim strNoteHeader As String = Nothing

        If UCase(strCalledBy) = UCase("CUSTOMERS") Then
            strPostingLedgerAccount = strPublicDebtorsAccount
            strTransactionType = "CREDIT"
            strTaxTransType = "DEBIT"
            strNoteHeader = "CREDIT NOTE"
        Else
            strPostingLedgerAccount = strPublicCreditorsAccount
            strTransactionType = "DEBIT"
            strTaxTransType = "CREDIT"
            strNoteHeader = "DEBIT NOTE"
        End If

        If String.IsNullOrEmpty(strPostingLedgerAccount) Then
            MessageBox.Show("The debtors control account has not been setup. This will seriously affect the trial balance",
                 "Debtors Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                & "('" & strPostingLedgerAccount & "', '" & shortMonthDateFormat(dpDate.Value) & "', " & CDbl(lblNetValue.Text) & ", '" & strTransactionType & "', " _
                & "'" & lblAccountNumber.Text & "', '" & cboClientDetails.Text & "', '" & strUserName & "', " _
                & "'" & strUserBranch & "', " & intDocumentNumber & ", " & intSpecialKey & ")", cnn)
            objCommand.ExecuteNonQuery()
        End If

        'Update the taxes control account as well
        If IsNumeric(lblTaxes.Text) Then
            If CDbl(lblTaxes.Text) > 0 Then
                If String.IsNullOrEmpty(strPublicTaxesAccount) Then
                    MessageBox.Show("The taxes control account has not been setup. This will seriously affect the trial balance", _
                        "Taxes Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Dim strProcessStatus As String = gwt_comm.LedgerEntry("INSERT", shortMonthDateFormat(dpDate.Value), CommonLibrary.Commons.strPublicTaxesAccount,
                        lblAccountNumber.Text, cboClientDetails.Text, CDbl(lblTaxes.Text), strTaxTransType,
                        , , , , 0, 0, intDocumentNumber, 0, intSpecialKey, 0)
                    If strProcessStatus <> "SUCCESS" Then GoTo RaiseErr
                End If
            End If
        End If

        'Update the control numbers
        objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET " & ControlNumberField & " = " & intDocumentNumber & "", cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default

        If MessageBox.Show("Transaction has been posted successfully. Do you want to print the document right now?",
            "Process Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            DebitCreditNotePrint(strNoteHeader, intDocumentNumber, lblAccountNumber.Text)
        End If

        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        If UCase(strCalledBy) = UCase("Suppliers") Then DeleteDebitNote(intDocumentNumber) Else DeleteCreditNote(intDocumentNumber)
        strErrorMessages = Err.Description & " " & Err.Number & " On transactions save"
        ShowErrorMessage()
    End Sub

    Private Sub cboTransactions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTransactions.SelectedIndexChanged
        If boolFormLoading = True Then Exit Sub
        txtFiscalDay.Text = "0"
        txtFiscalInvoiceNo.Text = Nothing
        If Not Object.Equals(cboTransactions.SelectedItem.Col1, Nothing) Then
            lblCurrencyUsed.Text = cboTransactions.SelectedItem.Col6
            Dim strFiscalDetails() As String = GetFiscalDetails(cboTransactions.SelectedItem.Col1)
            If IsNumeric(strFiscalDetails(0)) Then
                txtFiscalDay.Text = CInt(strFiscalDetails(0))
            Else
                txtFiscalDay.Text = "0"
            End If
            txtFiscalInvoiceNo.Text = strFiscalDetails(1)
        End If
    End Sub

    Private Function GetFiscalDetails(ByVal DocumentNumber As String) As String()
        Dim strReturn() As String = {"0", Nothing}

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        If UCase(strCalledBy) = UCase("Customers") Then
            strSql = "SELECT [FiscalDay], [FiscalInvoiceNo] 
                FROM [CustomerSalesMain] (NOLOCK) 
                WHERE [InvoiceNumber] = " & DocumentNumber & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0)) Then
                    If Not String.IsNullOrEmpty(Trim(objReader(0).ToString)) Then
                        strReturn(0) = Trim(objReader(0).ToString)
                    End If
                End If
                If Not IsDBNull(objReader(1)) Then
                    If Not String.IsNullOrEmpty(Trim(objReader(1).ToString)) Then
                        strReturn(1) = Trim(objReader(1).ToString)
                    End If
                End If
            End If
            objReader.Close()
        End If

        Return strReturn
        Exit Function
RaiseErr:
        Return strReturn
    End Function

End Class