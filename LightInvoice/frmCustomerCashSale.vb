Imports System.IO
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCustomerCashSale

    Dim strSelectedReport As String
    Dim prFont As New Font("Arial", 8, FontStyle.Regular)
    Dim tlFont As New Font("Arial", 8, FontStyle.Bold)
    Dim HeaderFont As New Font("Arial", 12, FontStyle.Bold)

    Dim NameFont As New Font("Arial", 10, FontStyle.Bold)

    Dim strType As String
    Dim arrPrintDetails As ArrayList
    Dim boolSearchReturn As Boolean

    Dim strCustomerDetails As String
    Dim strInvoiceDetails As ArrayList
    Dim rsInvoiceTotals As String

    Dim dblInvoiceTotal As Double
    Dim dblTaxes As Double
    Dim dblDiscounts As Double
    Dim i As Double = 0
    Dim strvalue As String
    Dim strDate As Date
    Dim itm As Double
    Dim boolPrintFromPreview As Boolean
    Dim intPaymentReceiptNumber As Double
    Dim strCustomerAccountNumberPayments As String

    Dim strSalesRep As String
    Dim strCustomerName As String
    Dim strCustomerAddress As String
    Dim strCustomerTelephone As String
    Dim strCustomerFaxNumber As String
    Dim strCustomerVatNumber As String
    Dim strCustomerEmailAddress As String

    Dim boolExitingWhile As Boolean = False
    Dim intPage As Single = 1
    Dim intPageTotals As Double = 1

    Dim strItemType As String = Nothing

    Dim arrInvoiceData As ArrayList

    Public myfntDetailsFontBold As New System.Drawing.Font("Arial", 12, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Dim arrReceiptData As ArrayList

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmCustomerCashSale_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr

        If Not String.IsNullOrEmpty(strUserName) Then
            lblUserName.Text = UCase(strPublicActiveFullUserName)
        End If

        With Me.dGrid
            .Rows.Add(100)
        End With

        lblTransDate.Text = UCase(gwt_comm.shortMonthDateFormat(Now))

        dGrid.Focus()
        dGrid.CurrentCell = dGrid.Rows(0).Cells(0)
        dGrid.Rows(0).Cells(0).Selected = True
        dGrid.BeginEdit(False)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On form details load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellValidated
        If dGrid.CurrentCell.ColumnIndex = 4 Or dGrid.CurrentCell.ColumnIndex = 6 Or dGrid.CurrentCell.ColumnIndex = 3 Then
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value), "")) Then
                If Not IsNumeric(dGrid.CurrentCell.Value) Then
                    MessageBox.Show("Invalid Non Numeric Value Detected. Cell value defaulted to 0", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGrid.CurrentCell.Value = "0"
                    ComputeValues(CDbl(dGrid.CurrentRow.Cells(3).Value.ToString), CDbl(dGrid.CurrentRow.Cells(4).Value.ToString), dGrid.CurrentRow.Index, CDbl(dGrid.CurrentRow.Cells(6).Value.ToString), dblSalesTaxRate)
                    Exit Sub
                Else
                    ComputeValues(CDbl(dGrid.CurrentRow.Cells(3).Value.ToString), CDbl(dGrid.CurrentRow.Cells(4).Value.ToString), dGrid.CurrentRow.Index, CDbl(dGrid.CurrentRow.Cells(6).Value.ToString), dblSalesTaxRate)
                End If
            End If
        End If
    End Sub

    Private Sub dGrid_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGrid.KeyDown
        If e.KeyValue = 9 Then
            'frmCashoutItemTypes
            If dGrid.CurrentCell.ColumnIndex = 0 Then
                strPublicItemCode = Nothing
                strFullItemDetails = Nothing
                boolAbort = False
                gwt_comm.InventorySearch()
                If boolAbort = True Then Exit Sub
                CommitValueChanged()
                dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(1)
            End If
        End If
    End Sub

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr
        'If cboItems.Focused = False Then Exit Sub
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

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex >= 3 And e.ColumnIndex <= 8 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
            ComputeTotals()
        End If
    End Sub

    Private Sub dGrid_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dGrid.ColumnWidthChanged
        If e.Column.Index = 0 Then
            cboSerials.Width = dGrid.Columns(2).Width
            cboSerials.Refresh()
        End If
    End Sub

    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter
        On Error GoTo RaiseErr
        cboSerials.Visible = False
        If UCase(strPublicSalesProcessingType) <> "NORMAL" Then
            cboSerials.Visible = False
            Exit Sub
        End If

        If e.RowIndex < 0 Then Exit Sub

        If e.ColumnIndex = 2 Then

            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(0).Value), "") Then

                Dim objCommand As Data.OleDb.OleDbCommand
                Dim objReader As Data.OleDb.OleDbDataReader
                Dim strActiveTableName As String = "SerialNumbers"

                If boolDeliverySale = True Then
                    strActiveTableName = "CustomerDeliveries"
                End If

                objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumber FROM " & strActiveTableName & " " _
                    & "WHERE ItemCode = '" & dGrid.CurrentRow.Cells(0).Value.ToString & "' ORDER BY SerialNumber", cnn)
                objReader = objCommand.ExecuteReader

                With cboSerials
                    .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
                    .ColumnNum = 1
                    .HighlightBorderOnMouseEvents = True
                    .ManagingFastMouseMoving = True
                    .Enabled = True
                    .DropDownHeight = 110
                    .GridLineHorizontal = True
                    .GridLineVertical = True
                    .ColumnWidth = "180"

                    'Get a count of the items
                    Dim intItemsCount As Integer = 0
                    Dim sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(SerialNumber) FROM " & strActiveTableName & " " _
                        & "WHERE ItemCode = '" & dGrid.CurrentRow.Cells(0).Value.ToString & "'", cnn)
                    Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
                    If objCount.HasRows Then
                        objCount.Read()
                        If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
                    End If
                    objCount.Close()

                    Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

                    .Items.Clear()
                    Dim i As Integer = 0
                    Dim p As Integer = 0

                    'Continue to read until you reach the end of the file.
                    While objReader.Read
                        DropDownItems(p) = New MTGCComboBoxItem(objReader(0))
                        p = p + 1
                    End While
                    objReader.Close()

                    'Check and remove any serial numbers that may have been selected currents

                    If intItemsCount > 0 Then
                        .SelectedIndex = -1
                        .Items.Clear()
                        .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                        .Items.AddRange(DropDownItems)
                    End If

                    .Size = dGrid.CurrentCell.Size
                    .Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + (0 + 1)
                    .Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left + (11 - 1)
                    If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                        .Text = Convert.ToString(dGrid.CurrentCell.Value)
                    Else
                        .Text = ""
                    End If
                    .Visible = True '152
                    .Focus()
                    .SelectAll()

                End With
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item code search"
        ShowErrorMessage()
    End Sub

    Private Sub cboSerials_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSerials.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(2)
            If strPublicIgnoreSerialNumbers = "YES" Then dGrid.CurrentCell.Value = cboSerials.Text
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(3)
            dGrid.Focus()
        End If
    End Sub

    Private Sub cboSerials_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSerials.SelectedIndexChanged
        If cboSerials.Focused = False Then Exit Sub
        If Not cboSerials.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(2).Value = cboSerials.SelectedItem.Col1
        Else
            dGrid.CurrentRow.Cells(2).Value = Nothing
        End If
    End Sub

    Private Sub cboSerials_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSerials.LostFocus
        cboSerials.Visible = False
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
        lblSubTotal.Text = Format(dblSubTotal, "#,##0.00")
        lblTaxable.Text = Format((dblSubTotal - dblDiscountTotals - dblTaxesTotal), "#,##0.00")
        lblTaxes.Text = Format(dblTaxesTotal, "#,##0.00")
        lblDiscounts.Text = Format(dblDiscountTotals, "#,##0.00")
        lblPayable.Text = Format(dblTotalPayable, "#,##0.00")
        lblMainTotal.Text = lblPayable.Text
    End Sub

    Private Sub ComputeValues(ByVal dblUnitPrice As Double, ByVal intQuantity As Double, _
        ByVal intRowIndex As Double, _
        Optional ByVal dblDiscount As Double = 0, Optional ByVal dblTaxRate As Double = 0, Optional ByVal Taxable As Boolean = True)
        Dim dblTaxes As Double = 0
        Dim dblSubTotal As Double = 0
        Dim dblPayable As Double = 0

        'Compute the sub total
        dblSubTotal = dblUnitPrice * intQuantity
        dGrid.Rows(intRowIndex).Cells(5).Value = Format(dblSubTotal, "##0.00")

        'Compute the tax payable
        If Taxable = True Then
            If UCase(strTaxComputationType) = "INCLUSIVE" Then
                dblTaxes = ((dblUnitPrice * intQuantity) - dblDiscount) - (((dblUnitPrice * intQuantity) - dblDiscount) * (100 / (100 + dblSalesTaxRate)))
            Else
                dblTaxes = (dblSubTotal - dblDiscount) * (dblSalesTaxRate / 100) 'dblTaxRate
            End If
        Else
            dblTaxes = 0
        End If

        If UCase(strTaxComputationType) = "EXCLUSIVE" Then
            dblPayable = (dblSubTotal - dblDiscount) + dblTaxes
        Else
            dblPayable = (dblSubTotal - dblDiscount)
        End If

        dGrid.Rows(intRowIndex).Cells(7).Value = Format(dblTaxes, "##0.00")
        dGrid.Rows(intRowIndex).Cells(8).Value = Format(dblPayable, "##0.00")

        RecalculateAmount()
        ComputeTotals()

    End Sub

    Private Sub CheckSerialNumberEntry(ByVal ItemCode As String, ByVal SerialNumber As String)
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT InventoryType FROM InventoryItems WHERE ItemCode = '" & ItemCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim intQty As Double = 0
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(objReader(0).ToString) = "SPECIFIC" Then
                    'If boolDeliverySale = True Then
                    '    Exit Sub
                    'Else
                    If strPublicIgnoreSerialNumbers = "NO" Then
                        If String.IsNullOrEmpty(SerialNumber) Then
                            MessageBox.Show("Please enter the serial number for item code " & ItemCode, _
                                "Missing Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            boolAbort = True
                        End If
                    End If
                    'End If
                End If
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Serial Number Check"
        ShowErrorMessage()
    End Sub

    Private Sub checkAvailability(ByVal ItemCode As String)
        On Error GoTo RaiseErr
        If strIgnoreZeroQuantity = "YES" Then Exit Sub
        If String.IsNullOrEmpty(ItemCode) Then Exit Sub
        Dim strOffering As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Quantity, Offering FROM InventoryItems WHERE ItemCode = '" & ItemCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim intQty As Double = 0
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intQty = CDbl(objReader(0).ToString)
            If Not IsDBNull(objReader(1).ToString) Then strOffering = objReader(1).ToString
        End If
        objReader.Close()

        If UCase(strOffering) <> "PRODUCT" Then Exit Sub

        If intQty <= 0 Then
            MessageBox.Show("This item is not available in stock", "Item Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If strIgnoreZeroQuantity = "NO" Then
                With dGrid
                    For i As Integer = 0 To .ColumnCount - 1
                        If i = 0 Then
                            Dim dblQuantity As Double = 0
                            Dim dblUnitPrice As Double = 0
                            Dim dblDiscount As Double = 0
                            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(4).Value), "") Then
                                If IsNumeric(dGrid.CurrentRow.Cells(4).Value.ToString) Then
                                    dblQuantity = Convert.ToDouble(dGrid.CurrentRow.Cells(4).Value)
                                End If
                            End If
                            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(3).Value), "") Then
                                If IsNumeric(dGrid.CurrentRow.Cells(3).Value.ToString) Then
                                    dblUnitPrice = Convert.ToDouble(dGrid.CurrentRow.Cells(3).Value)
                                End If
                            End If
                            If Not Object.Equals(Convert.ToString(.CurrentRow.Cells(6).Value), "") Then
                                If IsNumeric(dGrid.CurrentRow.Cells(6).Value.ToString) Then
                                    dblDiscount = Convert.ToDouble(dGrid.CurrentRow.Cells(6).Value)
                                End If
                            End If
                            If IsNumeric(lblDiscounts.Text) Then
                                lblDiscounts.Text = Format(CDbl(lblDiscounts.Text) - dblDiscount, "##0.00")
                            End If
                            If IsNumeric(lblPayable.Text) Then
                                lblPayable.Text = Format(CDbl(lblPayable.Text) - (dblUnitPrice * dblQuantity), "##0.00")
                            End If
                            'lblSubTotal
                            If IsNumeric(lblSubTotal.Text) Then
                                lblSubTotal.Text = Format(CDbl(lblSubTotal.Text) - (dblUnitPrice * dblQuantity), "##0.00")
                            End If
                        End If
                        .CurrentRow.Cells(i).Value = Nothing
                    Next
                End With
                'recalculate totals
                ComputeTotals()
            Else
                boolAbort = True
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Item Quantity Check"
        ShowErrorMessage()
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

        lblSubTotal.Text = Format(dblSubs, "#,##0.00")
        lblTaxable.Text = Format((dblSubs - dblDis - dblTxs), "#,##0.00")
        lblTaxes.Text = Format(dblTxs, "#,##0.00")
        lblDiscounts.Text = Format(dblDis, "#,##0.00")
        lblPayable.Text = Format(dblMovingTotal, "#,##0.00")

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

    Private Sub btnOveride_Click(sender As System.Object, e As System.EventArgs) Handles btnOveride.Click
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
            boolAbort = False
            boolAuthorized = False
            gwt_comm.SuperUserAuthentication()
            If boolAbort = True Then Exit Sub
            gwt_comm.DateSpecification()
            If boolAbort = True Then Exit Sub
            If boolAuthorized = True Then
                lblTransDate.Text = UCase(gwt_comm.shortMonthDateFormat(dtSetDate))
                boolAuthorized = False
            End If
        End If
        If boolAbort = True Then Exit Sub

    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        If dGrid.Rows.Count > 0 Then
            dGrid.CurrentCell = dGrid.CurrentRow.Cells(1)
            dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
            Dim iBal As Integer = 100 - dGrid.Rows.Count
            dGrid.Rows.Add(iBal)
            RecalculateAmount()
            ComputeTotals()
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(strPublicSalesAccount) Then
            MessageBox.Show("Missing the default sales ledger control account. Please set it up. For now the default will be used", _
                "Missing Sales Control Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            strPublicSalesAccount = "0000"
        End If
        FinishSale()
        If strPublicSalesAccount = "0000" Then strPublicSalesAccount = Nothing
        lblTransDate.Text = UCase(gwt_comm.shortMonthDateFormat(Now))
    End Sub

    Private Sub FinishSale()

        Dim strSqlTransmit As String = Nothing
        Dim strSelectedId As String
        Dim strDescription As String
        Dim intQty As Double
        Dim dblUprice As Double
        Dim insertCustomer As String
        Dim dblTax As Double
        Dim i As Double
        Dim dpProcessDate As Date = gwt_comm.shortMonthDateFormat(DateTime.Now)
        Dim dblDisAmount As Double 'for discounts
        Dim dblSumTaxes As Double = 0, dblSumDiscounts As Double = 0, dblSumPayable As Double = 0
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim dbReader As Data.OleDb.OleDbDataReader

        Dim strTransactionProcessStatus As String = Nothing

        strTillPaymentMethod = Nothing
        arrReceiptData = New ArrayList

        Dim strPersonnel As String = "CASH PAYMENT"

        dblAmountTendered = 0
        dblAmountChange = 0

        dpProcessDate = CDate(lblTransDate.Text)

        If dGrid.Rows.Count <= 0 Then
            MessageBox.Show("No document transactions to print !!!", "Empty Document Transactions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'If Not String.IsNullOrEmpty(cboPersonnel.Text) Then
            strPersonnel = UCase(strUserName)
            'End If

            'Perform the till ring routine
            boolAbort = False
            dblSaleTotal = CDbl(lblPayable.Text)

            If dblSaleTotal <= 0 Then
                If UCase(strUserLevel) = "ADMINISTRATOR" Or UCase(strUserLevel) = "MANAGER" Then
                    'Do nothing. Allow process
                Else
                    MessageBox.Show("Sale cannot be processed when there are no valid sub total values", "Sale Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            strCustomerTelephoneNumber = Nothing
            strTillCustomerName = Nothing

            For i = 0 To dGrid.Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    Dim strItemSerialTest As String = Nothing
                    Dim strSelectedIdTest As String = Nothing
                    strSelectedIdTest = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                        strItemSerialTest = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
                    End If
                    'Validate the serial number entry
                    boolAbort = False
                    If boolDeliverySale = False Then
                        CheckSerialNumberEntry(strSelectedIdTest, strItemSerialTest)
                    End If
                    If boolAbort = True Then Exit Sub
                End If
            Next i

            Dim f As New frmTenderAmount
            f.ShowDialog()
            If boolAbort = True Then Exit Sub

            On Error GoTo RaiseErr
            Cursor = Cursors.WaitCursor

            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))

            Cursor = Cursors.WaitCursor

            arrInvoiceData = New ArrayList

            For i = 0 To dGrid.Rows.Count - 1

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then

                    Dim strItemSerialNo As String = Nothing
                    Dim strLineItemType As String = Nothing
                    strSelectedId = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                    strDescription = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
                    intQty = Convert.ToDouble(dGrid.Rows(i).Cells(4).Value)
                    dblTax = Convert.ToDouble(dGrid.Rows(i).Cells(7).Value)
                    dblUprice = Convert.ToDouble(dGrid.Rows(i).Cells(3).Value)
                    dblDisAmount = Convert.ToDouble(dGrid.Rows(i).Cells(6).Value)
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                        strItemSerialNo = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(9).Value), "")) Then
                        strLineItemType = Convert.ToString(dGrid.Rows(i).Cells(9).Value)
                    End If

                    Dim dblAmtPayable As Double = 0
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(8).Value), "")) Then
                        If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(8).Value.ToString) Then
                            If IsNumeric(dGrid.Rows(i).Cells(8).Value.ToString) Then
                                dblAmtPayable = CDbl(dGrid.Rows(i).Cells(8).Value)
                            End If
                        End If
                    End If

                    arrInvoiceData.Add(strSelectedId & "|" & strDescription & "|" & intQty & "|" & Format(dblUprice, "##0.00") & _
                        "|" & Format((dblUprice * intQty), "##0.00") & "|" & Format(dblDisAmount, "##0.00") & "|" & Format(dblTax, "##0.00") & _
                        "|" & Format(dblAmtPayable, "##0.00"))

                    'Update the description if set to do so
                    If UCase(strUpdateDescriptionOnSale) = "YES" Then
                        Dim objUpdateDesc As New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET GroupName = '" & strDescription & "' " _
                            & "WHERE ItemCode = '" & strSelectedId & "'", cnn)
                        objUpdateDesc.ExecuteNonQuery()
                    End If

                    'Get the item cost price
                    Dim dblItemCostPrice As Double = 0
                    Dim ojjGetCostPrice As New Data.OleDb.OleDbCommand("SELECT CostPrice FROM InventoryItems WHERE ItemCode = '" & strSelectedId & "'", cnn)
                    Dim objReadCostPrice As Data.OleDb.OleDbDataReader = ojjGetCostPrice.ExecuteReader
                    If objReadCostPrice.HasRows Then
                        objReadCostPrice.Read()
                        If IsNumeric(objReadCostPrice(0).ToString) Then dblItemCostPrice = CDbl(objReadCostPrice(0).ToString)
                    End If
                    objReadCostPrice.Close()
                    '

                    'get the item's base barcode
                    Dim strBaseBarCode As String = Nothing
                    Dim objGetBasebarcode As New Data.OleDb.OleDbCommand("SELECT [BarCodeNo], [CostPrice] FROM SerialNumbers WHERE ItemCode = '" & strSelectedId & "' AND SerialNumber = '" & strItemSerialNo & "'", cnn)
                    Dim objReadBasebarcode As Data.OleDb.OleDbDataReader = objGetBasebarcode.ExecuteReader
                    If objReadBasebarcode.HasRows Then
                        objReadBasebarcode.Read()
                        If Not IsDBNull(objReadBasebarcode(0).ToString) Then strBaseBarCode = objReadBasebarcode(0).ToString
                        If IsNumeric(objReadBasebarcode(1).ToString) Then
                            If CDbl(objReadBasebarcode(1).ToString) > 0 Then
                                dblItemCostPrice = CDbl(objReadBasebarcode(1).ToString)
                            End If
                        End If
                    End If
                    objReadBasebarcode.Close()

                    Dim intMasterKey As Integer = gwt_comm.SpecialKey()
                    If Not IsNumeric(txtKeyNumber.Text) Then txtKeyNumber.Text = intMasterKey

                    insertCustomer = "INSERT INTO SALES (CustomerId, InvoiceNumber, TransDate, ItemCode, Quantity, " _
                        & "SalesPrice, TransType, Description, Taxes, DiscountAllowed, ProductType, SerialNumbers, " _
                        & "UserName, SalesRep, CostPrice, KeyNumber, BaseBarcode) VALUES " _
                        & "('0000', " & CDbl(txtReference.Text) & ", '" & dpProcessDate & "', " _
                        & "'" & strSelectedId & "', " & intQty & ", " & dblUprice & ", 'CASH SALE', " _
                        & "'" & strDescription & "', " & dblTax & ", " & dblDisAmount & ", " _
                        & "'" & strLineItemType & "', '" & strItemSerialNo & "', '" & lblUserName.Text & "', " _
                        & "'" & strPersonnel & "', " & dblItemCostPrice & ", " & Convert.ToDouble(txtKeyNumber.Text) & ", " _
                        & "'" & strBaseBarCode & "')"
                    myCommand = New Data.OleDb.OleDbCommand(insertCustomer, cnn)
                    myCommand.ExecuteNonQuery()

                    'Insert into cost of sales
                    'strPublicCostOfSales
                    If Not String.IsNullOrEmpty(strPublicCostOfSales) And Not String.IsNullOrEmpty(strPublicPurchasesAccount) Then
                        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                            & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                            & "('" & strPublicCostOfSales & "', '" & dpProcessDate & "', " & dblItemCostPrice & ", " _
                            & "'DEBIT', '" & strPublicPurchasesAccount & "', '" & strDescription & "', " _
                            & "'" & strUserName & "', '" & strUserBranch & "', " & CDbl(txtReference.Text) & ", " & Convert.ToDouble(txtKeyNumber.Text) & ")", cnn)
                        myCommand.ExecuteNonQuery()
                        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                            & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                            & "('" & strPublicPurchasesAccount & "', '" & dpProcessDate & "', " & dblItemCostPrice & ", " _
                            & "'CREDIT', '" & strPublicCostOfSales & "', '" & strDescription & "', " _
                            & "'" & strUserName & "', '" & strUserBranch & "', " & CDbl(txtReference.Text) & ", " & Convert.ToDouble(txtKeyNumber.Text) & ")", cnn)
                        myCommand.ExecuteNonQuery()
                    Else
                        MessageBox.Show("The system has detected that you have not set the cost of sales account" & vbCrLf & _
                            "This will seriously affect the ledger account and trial balance", "Missing Cost of Sales Account", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                    ''If UCase(strWebConnectionType) = "REALTIME" Then
                    ''    strSqlTransmit = myCommand.CommandText
                    ''    strSqlTransmit = Replace(strSqlTransmit, "INTO SALES (", "INTO GroupSales (BranchName, ", 1)
                    ''    strSqlTransmit = Replace(strSqlTransmit, "VALUES (", "VALUES ('" & strUserBranch & "', ", 1)
                    ''    TransmitSale(strSqlTransmit)
                    ''End If

                    dblSumTaxes = dblSumTaxes + dblTax
                    dblSumDiscounts = dblSumDiscounts + dblDisAmount

                    If boolDeliverySale = False Then

                        'Update the products table

                        myCommand = New Data.OleDb.OleDbCommand("SELECT Offering FROM InventoryItems WHERE ItemCode = '" & strSelectedId & "'", cnn)
                        Dim objReadInventoryType As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
                        If objReadInventoryType.HasRows Then
                            objReadInventoryType.Read()
                            If Not IsDBNull(objReadInventoryType(0).ToString) Then
                                'Dim y As String = objReadInventoryType(0).ToString
                                If UCase(objReadInventoryType(0).ToString) = UCase("PRODUCT") Then
                                    Dim intStockBalance As Double = 0
                                    myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & strSelectedId & "'", cnn)
                                    dbReader = myCommand.ExecuteReader
                                    If dbReader.HasRows Then
                                        dbReader.Read()
                                        If IsNumeric(dbReader(0).ToString) Then intStockBalance = CDbl(dbReader(0).ToString) Else intStockBalance = 0
                                    Else
                                        intStockBalance = 0
                                    End If
                                    dbReader.Close()
                                    intStockBalance = intStockBalance - CDbl(dGrid.Rows(i).Cells(4).Value)
                                    myCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = " & intStockBalance & " WHERE ItemCode = '" & strSelectedId & "'", cnn)
                                    myCommand.ExecuteNonQuery()
                                End If
                            End If
                        End If
                        objReadInventoryType.Close()

                        ''If UCase(strWebConnectionType) = "REALTIME" Then
                        ''    strSqlTransmit = myCommand.CommandText
                        ''    strSqlTransmit = Replace(strSqlTransmit, "INTO CashbookTransactions", "INTO GroupCashbookTransactions", 1)
                        ''End If

                        'Update the table for serial numbers
                        If Not String.IsNullOrEmpty(strItemSerialNo) Then
                            Dim strDelete As String
                            If boolDeliverySale = True Then
                                strDelete = "DELETE FROM CustomerDeliveries WHERE ItemCode = '" & strSelectedId & "' AND SerialNumber = '" & strItemSerialNo & "'"
                            Else
                                strDelete = "DELETE FROM SerialNumbers WHERE ItemCode = '" & strSelectedId & "' AND SerialNumber = '" & strItemSerialNo & "'"
                            End If
                            myCommand = New Data.OleDb.OleDbCommand(strDelete, cnn)
                            myCommand.ExecuteNonQuery()
                        End If

                        'Update the quantities if it is made up of components. Applicable to services and products

                        Dim objCommandComponents As New Data.OleDb.OleDbCommand("SELECT MakeupItemCode, Quantity FROM InventoryComponents WHERE ItemCode = '" & strSelectedId & "'", cnn)
                        Dim objReadComponents As Data.OleDb.OleDbDataReader = objCommandComponents.ExecuteReader
                        While objReadComponents.Read
                            gwt_comm.UpdateComponentQuantitiesBasedOnSales(strSelectedId, objReadComponents(0).ToString, intQty)
                        End While
                        objReadComponents.Close()

                    End If

                    'Update the selling price based on the user flag

                    If UCase(strPublicAutoSellingPriceUpdate) = "YES" Then
                        myCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET SellingPrice = " & dblUprice & " " _
                            & "WHERE ItemCode = '" & strSelectedId & "'", cnn)
                        myCommand.ExecuteNonQuery()
                    End If

                End If

            Next i

            dblSumPayable = CDbl(lblTaxable.Text)

            'Add the record to the sales main
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO SalesMain (InvoiceNumber, CustomerId, " _
                & "TransDate, Discount, Taxes, Amount, UserName, SalesRep, ContactNumber, ContactName, " _
                & "KeyNumber, PaymentMethod, Cash, EcoCash, Swipe, Transfer, Other) VALUES " _
                & "(" & Convert.ToDouble(txtReference.Text) & ", '0000', '" & dpProcessDate & "', " & dblSumDiscounts & ", " _
                & "" & dblSumTaxes & ", " & dblSumPayable & ", '" & lblUserName.Text & "', '" & strPersonnel & "', " _
                & "'" & strCustomerTelephoneNumber & "', '" & strTillCustomerName & "', " _
                & "" & Convert.ToDouble(txtKeyNumber.Text) & ", '" & strTillPaymentMethod & "', " _
                & "" & dblAmountTenderedCash & ", " & dblAmountTenderedEcoCash & ", " & dblAmountTenderedSwipe & ", " _
                & "" & dblAmountTenderedTransfer & ", " & dblAmountTenderedOther & ")", cnn)
            myCommand.ExecuteNonQuery()

            If strPublicDirectCashbbookSalesPosting = "YES" Then

                'Update the cashbook with the values
                Dim strCashbookDescription As String = "CASH SALE - " & UCase(strPersonnel)
                myCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, TransactionType, Reference, KeyNumber) VALUES " _
                    & "('" & strPublicActiveCashbook & "', '" & dpProcessDate & "', " & dblSumPayable + CDbl(lblTaxes.Text) & ", '" & strCashbookDescription & "', '" & strPublicSalesAccount & "', '" & strUserName & "', " _
                    & "'" & strUserBranch & "', 'DEBIT', " & Convert.ToDouble(txtReference.Text) & ", " & Convert.ToDouble(txtKeyNumber.Text) & ")", cnn)
                myCommand.ExecuteNonQuery()
                '
                'Post the account to the contra ledger account
                '
                myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                    & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference]) VALUES " _
                    & "('" & strPublicSalesAccount & "', '" & dpProcessDate & "', " & dblSumPayable & ", 'CREDIT', " _
                    & "'" & strPublicActiveCashbook & "', '" & strCashbookDescription & "', '" & strUserName & "', " _
                    & "'" & strUserBranch & "', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
                myCommand.ExecuteNonQuery()

                'Update the taxes control account as well
                '
                If IsNumeric(lblTaxes.Text) Then
                    If CDbl(lblTaxes.Text) > 0 Then
                        If String.IsNullOrEmpty(strPublicTaxesAccount) Then
                            MessageBox.Show("The taxes control account has not been setup. This will serious affect the trial balance", _
                                "Taxes Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            strTransactionProcessStatus = gwt_comm.LedgerEntry("INSERT", dpProcessDate, strPublicTaxesAccount, _
                                strPublicActiveCashbook, "CASH SALE-" & txtReference.Text, CDbl(lblTaxes.Text), "CREDIT", _
                                txtReference.Text, , , , txtReference.Text, 0, 0, 0)
                            If strTransactionProcessStatus <> "SUCCESS" Then GoTo RaiseErr
                        End If
                    End If
                End If
            End If

            'Update the control numbers table
            Dim intNewInvoiceNumber As Double = CDbl(txtReference.Text)
            myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET CashSales = " & CDbl(txtReference.Text) & "", cnn)
            myCommand.ExecuteNonQuery()

            'Update the keynumbers
            Dim intNewKeyNumber As Double = CDbl(txtKeyNumber.Text)
            myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET KeyNumber = " & CDbl(txtKeyNumber.Text) & "", cnn)
            myCommand.ExecuteNonQuery()

            ''Update the gatepass status if delivery
            'If chkDeliverySale.Checked = True Then
            '    For p As Integer = 0 To arrSelectedItems.Count - 1
            '        Dim strBuffered() As String = Split(arrSelectedItems.Item(p), "|")
            '        myCommand = New Data.OleDb.OleDbCommand("UPDATE GatePasses SET Status = 'PROCESSED' " _
            '            & "WHERE TransactionId = " & strBuffered(strBuffered.Length - 1) & "", cnn)
            '        myCommand.ExecuteNonQuery()
            '    Next
            '    arrSelectedItems = Nothing
            'End If

            'Update the ticket status if it is based on tickets
            'If UCase(strPublicSalesProcessingType) <> "NORMAL" Then
            '    myCommand = New Data.OleDb.OleDbCommand("UPDATE TicketSalesMain SET Status = 'PROCESSED' WHERE InvoiceNumber = " & CDbl(txtTicketNumber.Text) & "", cnn)
            '    myCommand.ExecuteNonQuery()
            'End If

            strPublicCustomerId = "0000"

            If UCase(strPublicReceiptType) = "DESKTOP PRINTER" Then
                PrintReceiptQuote("CASH RECEIPT")
                'PrintInvoiceTypeCashSlip(CInt(txtReference.Text))
            Else
                If UCase(strPublicReceiptType) = "SOLID A5 RECEIPT" Then
                    If boolAbort = True Then Exit Sub
                    pdLaserReceipt.Print()
                Else
                    PrintInvoice(dpProcessDate)
                End If
            End If

            ''OpenCashdrawer()
            MessageBox.Show("Sales document generated successfully.", "Transaction Document Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.lblPayable.Text = "0.00"
            Me.lblSubTotal.Text = "0.00"
            Me.lblDiscounts.Text = "0.00"
            Me.lblTaxes.Text = "0.00"
            Me.lblTaxable.Text = "0.00"

            'Clear the controls
            dGrid.Rows.Clear()
            dGrid.Rows.Add(350)
            txtReference.Text = ""
            txtKeyNumber.Text = ""
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))
        lblTransDate.Text = gwt_comm.shortMonthDateFormat(Now)
        dblAmountChange = 0
            dblAmountTendered = 0
            boolDeliverySale = False
            Cursor = Cursors.Default


            lblMainTotal.Text = "0.00"

            Cursor = Cursors.Default
            Exit Sub
RaiseErr:
            Cursor = Cursors.Default
            boolAbort = True
            strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Processing"
            ShowErrorMessage()
    End Sub

    Private Sub TransmitSale(ByVal fileString As String)
        strDownloadingType = "SALES"
        ServerDestinationFolder = strWebMainBranch.Replace(" ", "") & "/DailySales"
        strDestinationBranch = strWebMainBranch
        gwt_comm.AddDataChanges(fileString)
    End Sub

    Private Sub PrintInvoice(ByVal dtReceiptDate As Date)
        On Error GoTo RaiseErr
        strType = UCase(strReceiptHeader)
        strSelectedReport = Me.txtReference.Text

        Dim arrFiscalReceiptItems As New ArrayList

        arrPrintDetails = New ArrayList
        '
        'ADD THE BRANCH INFORMATION
        '
        arrPrintDetails.Add(Space(2) & UCase(strCompanyName))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchName))
        arrPrintDetails.Add(Space(2) & UCase(strCompanyAddress1))
        arrPrintDetails.Add(Space(2) & UCase(strCompanyAddress2))
        arrPrintDetails.Add(Space(2) & UCase(strCompanyAddress3))
        arrPrintDetails.Add(Space(2) & UCase(strCompanyAddress4))
        arrPrintDetails.Add(Space(2) & "PHONE: " & strCompanyTelephone)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        '
        'Print based on the grid values
        '
        If Not String.IsNullOrEmpty(strCustomerTelephoneNumber) Then
            arrPrintDetails.Add(Space(2) & "YOUR NO.: " & strCustomerTelephoneNumber)
            arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
            arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        End If
        Dim dblVatTax As Double = 0


        If boolProcessingAccountPayment = False Then
            With dGrid
                For i As Double = 0 To .Rows.Count - 1
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                        Dim strSerial As String = Nothing
                        If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "")) Then
                            strSerial = Convert.ToString(.Rows(i).Cells(2).Value)
                            If strSerial.Length > 30 Then
                                strSerial = Mid(strSerial, 1, 30) & vbCrLf & Mid(strSerial, 31, strSerial.Length)
                            End If
                        End If

                        Dim strDescription As String = strSerial & " " & .Rows(i).Cells(1).Value.ToString
                        Dim strQuantity As String = .Rows(i).Cells(4).Value.ToString
                        Dim strUnitPrice As String = Format(CDbl(.Rows(i).Cells(3).Value.ToString), "#,##0.00")

                        Dim strLineTotal As String = Format(CDbl(.Rows(i).Cells(8).Value.ToString), "#,##0.00")
                        If strDescription.Length > 30 Then strDescription = Mid(strDescription, 1, 32)
                        arrPrintDetails.Add(Space(2) & strDescription)
                        arrPrintDetails.Add(Space(4) & Space(5 - strQuantity.Length) & strQuantity & " @ " & _
                            Space(8 - strUnitPrice.Length) & strUnitPrice & Space(4) & Space(8 - strLineTotal.Length) & strLineTotal)
                        dblVatTax = dblVatTax + Convert.ToDouble(.Rows(i).Cells(7).Value)

                        If UCase(strPublicTaxFiscalStatus) = "YES" Then
                            Dim strFiscalUnitPrice As String = Format(CDbl(.Rows(i).Cells(3).Value.ToString), "###0.00")
                            Dim strFiscalItemCode As String = .Rows(i).Cells(0).Value.ToString
                            Dim strFiscalTaxCode As String = "A"
                            'Get the item taxcode
                            Dim objGetItemTaxCode As New Data.OleDb.OleDbCommand("SELECT TaxCode FROM InventoryItems " _
                                & "WHERE ItemCode = '" & strFiscalItemCode & "'", cnn)
                            Dim objReadTaxCode As Data.OleDb.OleDbDataReader = objGetItemTaxCode.ExecuteReader
                            If objReadTaxCode.HasRows Then
                                objReadTaxCode.Read()
                                If Not IsDBNull(objReadTaxCode(0).ToString) Then strFiscalTaxCode = objReadTaxCode(0).ToString
                            End If
                            objReadTaxCode.Close()
                            arrFiscalReceiptItems.Add(strFiscalItemCode & "|" & strDescription & "|" & strFiscalUnitPrice & _
                                "|" & strQuantity & "|" & strFiscalTaxCode)
                        End If

                    End If
                Next
            End With

        Else

            Dim strSerial As String = UCase(strPublicItemCode)
            If strSerial.Length > 30 Then
                strSerial = Mid(strSerial, 1, 30) & vbCrLf & Mid(strSerial, 31, strSerial.Length)
            End If


            Dim strDescription As String = strSerial & " ACCOUNT SETTLEMENT"
            Dim strQuantity As String = "1"
            Dim strUnitPrice As String = "  "
            Dim strLineTotal As String = Format(dblAccountSettlementAmount, "##0.00")
            If strDescription.Length > 30 Then strDescription = Mid(strDescription, 1, 32)
            lblPayable.Text = Format(dblAccountSettlementAmount, "##0.00")
            'Add the balance after payment line
            arrPrintDetails.Add(Space(2) & strDescription)

        End If


        'Add the dash line
        Dim strTaxCharged As String = Format(dblVatTax, "##0.00")

        Dim strTender As String = Format(dblAmountTendered, "##0.00")
        Dim strChange As String = Format(dblAmountChange, "##0.00")

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "TOTAL INCL. VAT " & Space(14 - lblPayable.Text.Length) & lblPayable.Text)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "VAT CHARGED     " & Space(14 - strTaxCharged.Length) & strTaxCharged)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "AMOUNT TENDERED " & Space(14 - strTender.Length) & strTender)
        arrPrintDetails.Add(Space(2) & "CHANGE          " & Space(14 - strChange.Length) & strChange)

        Dim strZimDate As String = gwt_comm.shortMonthDateFormat(Now)

        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(2) & "TILL OPER :" & UCase(lblUserName.Text) & Space(3))
        arrPrintDetails.Add(Space(2) & "SALES REP :")

        If strUserName.Length > 30 Then
            arrPrintDetails.Add(Space(2) & UCase(Mid(strUserName, 1, 30)))
        Else
            arrPrintDetails.Add(Space(2) & UCase(strUserName))
        End If

        arrPrintDetails.Add(Space(1) & "DATE AND TIME " & strZimDate & " " & DatePart(DateInterval.Hour, Now) & ":" & DatePart(DateInterval.Minute, Now))
        arrPrintDetails.Add(Space(2) & UCase(strReceiptHeader) & " DATE  " & gwt_comm.shortMonthDateFormat(dtReceiptDate))
        arrPrintDetails.Add(Space(2) & " DOC NO " & txtReference.Text & ": KEY " & txtKeyNumber.Text)
        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(1) & "CURRENCY : " & UCase(strSalesCurrency))
        arrPrintDetails.Add(Space(1) & "RATE USED: " & dblSaleExchangeRate)
        If boolProcessingAccountPayment = False Then
            If arrConditionsOfSale.Count > 0 Then
                For j As Double = 0 To arrConditionsOfSale.Count - 1
                    arrPrintDetails.Add(UCase(arrConditionsOfSale.Item(j)))
                Next j
            End If
        End If
        For i As Double = 0 To 5
            arrPrintDetails.Add(Space(32))
        Next

        'WRITE EVERY THING TO THE AUDIT FILE
        Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\TILLSLIP", True)
        For x As Double = 0 To arrPrintDetails.Count - 1
            objFileWriter.WriteLine(arrPrintDetails.Item(x))
        Next
        objFileWriter.Close()
        '
        'PRINTS FROM A FILE DIRECTLY TO THE PRINTER
        '
        'Try printing using the line printer. Allow the user to select a file.

        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()
        Dim output As String = Chr(&H1D) & "V" & Chr(66) & Chr(0) 'Feeds paper & cut



        If strPublicConfirmReceiptPrint = "YES" Then
            If MessageBox.Show("Do you want to print the receipt right now?", "Confirm Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If strRequestForReceiptPrinter = "YES" Then
                    boolAbort = False
                    Dim f As New frmPrinterSetup
                    f.ShowDialog()
                    If boolAbort = True Then Exit Sub
                    pd.PrinterSettings.PrinterName = strSessionPrinter
                End If
                If UCase(strPublicPrinterType) = "RAW" Then
                    For n = 0 To arrPrintDetails.Count - 1
                        Dim strPrintLineDetails As String = arrPrintDetails.Item(n) & vbCrLf
                        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintLineDetails)
                    Next
                Else
                    Dim ppd As New PrintPreviewDialog
                    ppd.Document = pdWindows
                    pdWindows.Print()
                    Exit Sub
                End If

                'Cut the paper on thermal printers
                If strPublicCutReceipt = "YES" Then
                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, output)
                End If
            End If
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Processing"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub PrintReceiptQuote(DocumentType As String)
        On Error GoTo RaiseErr

        'Print the document number together with the vat number and document type (cash receipt or quote)
        Dim objFile As New System.IO.StreamWriter(Application.StartupPath & "\TestDoc.txt", True)

        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()

        'First Print the company details

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, Space(30) & UCase(DocumentType) & Space(30))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(Space(30) & UCase(DocumentType) & Space(30))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, "-"c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strCompanyName))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strCompanyName))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strPublicBranchName))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strPublicBranchName))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strCompanyAddress1))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strCompanyAddress1))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strCompanyAddress2))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strCompanyAddress2))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strCompanyAddress3))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strCompanyAddress3))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strCompanyAddress4))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strCompanyAddress4))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, "PHONE: " & strPublicBranchTelephone)
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine("PHONE: " & strPublicBranchTelephone)

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, "-"c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, "-"c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, "DOC.NO : " & txtReference.Text)
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine("DOC.NO : " & txtReference.Text)

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        If UCase(DocumentType) = "QUOTATION" Then
            For j As Integer = 0 To 2
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
                objFile.WriteLine(StrDup(110, " "c))
            Next j
            'strFlyQuoteName = Nothing
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strFlyQuoteName)
            objFile.WriteLine(strFlyQuoteName)
            'strFlyQuoteAddress1 = Nothing
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strFlyQuoteAddress1)
            objFile.WriteLine(strFlyQuoteAddress1)
            'strFlyQuoteAddress2 = Nothing
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strFlyQuoteAddress2)
            objFile.WriteLine(strFlyQuoteAddress2)
            'strFlyQuoteAddress3 = Nothing
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strFlyQuoteAddress3)
            objFile.WriteLine(strFlyQuoteAddress3)
            strFlyQuoteAddress4 = Nothing
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strFlyQuoteAddress4)
            objFile.WriteLine(strFlyQuoteAddress4)
        End If
        '
        'Print based on the grid values
        '
        'ITEM CODE, DESCRIPTION, UNIT PRICE, QTY, SUB TOTAL, DISCOUNTS, TAXES, PAYABLE

        Dim strHeader As String = "CODE           DESCRIPTION                      QTY      PRICE      SUB TTL     DISC.         TAX     PAYABLE   "

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strHeader)
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(strHeader)

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, "-"c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, "-"c))

        Dim dblSubTotal As Double = 0
        Dim dblDiscounts As Double = 0
        Dim dblVat As Double = 0
        Dim dblPayableTotal As Double = 0

        For n = 0 To arrInvoiceData.Count - 1
            Dim strPrintLineDetails() As String = Split(arrInvoiceData.Item(n), "|")
            If strPrintLineDetails(1).Length > 24 Then strPrintLineDetails(1) = Mid(strPrintLineDetails(1), 1, 24)
            If strPrintLineDetails(0).Length > 12 Then strPrintLineDetails(0) = Mid(strPrintLineDetails(0), 1, 12)
            Dim strPrintData As String = strPrintLineDetails(0) & Space(12 - strPrintLineDetails(0).Length) & Space(2) & _
                strPrintLineDetails(1) & Space(25 - strPrintLineDetails(1).Length) & _
                Space(12 - strPrintLineDetails(2).Length) & strPrintLineDetails(2) & _
                Space(8 - strPrintLineDetails(3).Length) & strPrintLineDetails(3) & _
                Space(12 - strPrintLineDetails(4).Length) & strPrintLineDetails(4) & _
                Space(12 - strPrintLineDetails(5).Length) & strPrintLineDetails(5) & _
                Space(12 - strPrintLineDetails(6).Length) & strPrintLineDetails(6) & _
                Space(12 - strPrintLineDetails(7).Length) & strPrintLineDetails(7)

            Dim strValT, strValD, strValV, strValP As String

            strValT = Replace(strPrintLineDetails(4), ",", "", 1)
            If IsNumeric(strValT) Then dblSubTotal = dblSubTotal + CDbl(strValT)

            strValD = Replace(strPrintLineDetails(5), ",", "", 1)
            If IsNumeric(strValD) Then dblDiscounts = dblDiscounts + CDbl(strValD)

            strValV = Replace(strPrintLineDetails(6), ",", "", 1)
            If IsNumeric(strValV) Then dblVat = dblVat + CDbl(strValV)

            strValP = Replace(strPrintLineDetails(7), ",", "", 1)
            If IsNumeric(strValP) Then dblPayableTotal = dblPayableTotal + CDbl(strValP)


            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintData)
            If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(strPrintData)
        Next


        'Print the totals

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, "-"c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, "-"c))

        Dim strSubValue As String = Format(dblSubTotal, "##0.00")
        Dim strDiscValue As String = Format(dblDiscounts, "##0.00")
        Dim strTaxValue As String = Format(dblVat, "##0.00")
        Dim strPayValue As String = Format(dblPayableTotal, "##0.00")

        Dim strTotalLine As String = "               TOTALS                                        " & _
            Space(12 - strSubValue.Length) & strSubValue & _
                Space(12 - strDiscValue.Length) & strDiscValue & _
                Space(12 - strTaxValue.Length) & strTaxValue & _
                Space(12 - strPayValue.Length) & strPayValue

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strTotalLine)
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(strTotalLine)

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, "-"c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, "-"c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        'Print the terms and condictions

        If arrConditionsOfSale.Count > 0 Then
            For j As Double = 0 To arrConditionsOfSale.Count - 1
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(arrConditionsOfSale.Item(j)))
                If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(arrConditionsOfSale.Item(j)))
            Next j
        End If

        For i As Integer = 0 To 9
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, "")
            If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine("")
        Next

        objFile.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Cash receipt Generation Error"
        ShowErrorMessage()
    End Sub

    Private Sub pdLaserReceipt_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdLaserReceipt.PrintPage
        On Error GoTo RaiseErr

        Dim myGraphics As Graphics = e.Graphics
        Dim myRectangle As Rectangle
        Dim myPen As New Pen(Color.Black)

        Dim intX As Integer = 265
        Dim intY As Integer = 50

        Dim strFontName As String = "Arial"
        Dim intFontSize As Integer = 8
        Dim strForeColor As String = "Black"
        Dim boolFontBold As Boolean = False
        Dim boolFontItalic As Boolean = False
        Dim boolFontUnderline As Boolean = False
        Dim strBackColor As String = "White"
        Dim intAlignment As Integer = 0
        Dim strText As String = Nothing
        Dim intCellWidth As Integer = 100
        Dim intCellHeight As Integer = 15


        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Receipt #" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 20, strText, fntDetailsFont, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = txtReference.Text : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 20, strText, fntDetailsFont, Brushes.Black)

        'Second line boxes
        intY = intY + 18
        intX = 265

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Date" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFont, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = UCase(gwt_comm.shortMonthDateFormat(Now)) : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFont, Brushes.Black)

        'Fourth line boxes
        intY = intY + 18
        intX = 265

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Time" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFont, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = UCase(CStr(Format(Now.Hour, "00")) & ":" & CStr(Format(Now.Minute, "00"))) : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFont, Brushes.Black)

        'Fifth line boxes
        intY = intY + 18
        intX = 265

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Cashier" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFont, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = UCase(strUserName) : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFont, Brushes.Black)


        'BEGIN DETAILS PRINT BY PRINT FIRST THE BOXES

        'DRAW THE MAIN BOX

        intY = intY + 25
        intX = 50
        intCellWidth = 415
        intCellHeight = 330

        Dim intHeaderY As Integer = intY + 10

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)

        'Draw the first horizontal line
        intY = intY + 28
        e.Graphics.DrawLine(Pens.Black, intX, intY, 465, intY)

        'Draw the first vertical line 
        intX = 240
        e.Graphics.DrawLine(Pens.Black, intX, intY - 28, intX, 460)

        'Draw the first vertical line 
        intX = 320
        e.Graphics.DrawLine(Pens.Black, intX, intY - 28, intX, 460)

        'Draw the first vertical line 
        intX = 380
        e.Graphics.DrawLine(Pens.Black, intX, intY - 28, intX, 460)

        'Write out the headers
        Call gwt_comm.DrawStringInBoxLeft(e, 55, intHeaderY, 250, 20, "Description", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxCenter(e, 240, intHeaderY, 80, 20, "Unit Price", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxCenter(e, 320, intHeaderY, 80, 20, "Qty", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxCenter(e, 380, intHeaderY, 100, 20, "Amount", fntDetailsFont, Brushes.Black)


        '********** PRINT DETAILS ******************
        intY = intY + 5
        Dim Yc As Integer
        Dim cols, lines As Double
        Dim intLast As Integer = arrInvoiceData.Count - 1
        For p As Integer = 0 To intLast

            Dim strSplitBuffer() As String = Split(arrInvoiceData.Item(p), "|")

            Dim dblQty As Double = 1
            If IsNumeric(strSplitBuffer(2)) Then
                dblQty = CDbl(strSplitBuffer(2))
            End If

            Dim strFullDescription As String = dblQty & " * " & UCase(strSplitBuffer(1)) & " " & UCase(strSplitBuffer(0))

            Call gwt_comm.DrawStringInBoxLeft(e, 55, intY, 190, 80, strFullDescription, fntDetailsFont, Brushes.Black)


            Dim dblUnitPrice As Double = CDbl(strSplitBuffer(7)) / dblQty

            Call gwt_comm.DrawStringInBoxRight(e, 240, intY, 80, 80, UCase(CStr(Format(dblUnitPrice, "##0.00"))), fntDetailsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, 280, intY, 80, 80, UCase(strSplitBuffer(2)), fntDetailsFont, Brushes.Black)
            'Dim dblPaid As Double = strSplitBuffer(7) 'CDbl(strSplitBuffer(3)) * CDbl(strSplitBuffer(2))
            'Call gwt_comm.DrawStringInBoxRight(e, 380, intY, 80, 80, UCase(Format(dblPaid, "##0.00")), fntDetailsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, 380, intY, 80, 80, strSplitBuffer(7), fntDetailsFont, Brushes.Black)

            e.Graphics.MeasureString(strFullDescription, fntDetailsFont, New SizeF(190, 80), New StringFormat(), cols, lines)
            Yc = intY
            intY = intY + lines * (fntDetailsFont.Height + 2)
            intY = Math.Max(intY, Yc)

        Next

        'Draw the total line box
        myRectangle = New Rectangle(x:=380, y:=463, Width:=85, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        Call gwt_comm.DrawStringInBoxRight(e, 268, 465, 100, 20, "TOTAL", fntDetailsFontBold, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, 380, 465, 85, 25, lblPayable.Text, fntDetailsFontBold, Brushes.Black)


        'Terms and conditions
        intY = 500

        Call gwt_comm.DrawStringInBoxLeft(e, 50, intY, 300, 20, "TERMS AND CONDITIONS OF SALE", fntDetailsFont, Brushes.Black)
        intY = intY + 15

        For p As Integer = 0 To arrConditionsOfSale.Count - 1
            Call gwt_comm.DrawStringInBoxLeft(e, 100, intY, 350, 20, arrConditionsOfSale.Item(p), fntDetailsFont, Brushes.Black)
            intY = intY + 15
        Next

        'Draw the logo
        Dim intLogoXpositionNow As Integer = 300
        Dim intLogoYpositionNow As Integer = 500

        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                'Dont print the company name as it is taken care of by the logo
                'strCompanyName = ""
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoXpositionNow, intLogoYpositionNow, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
            End If
        End If

        'Print Company Address

        intX = 55
        intY = 50

        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, strCompanyName, NameFont, Brushes.Black)
        intY = intY + 15
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, strCompanyAddress1, fntDetailsFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, strCompanyAddress2, fntDetailsFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, strCompanyAddress3, fntDetailsFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, strCompanyAddress4, fntDetailsFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, strCompanyTelephone, fntDetailsFont, Brushes.Black)

        'Print Header
        Call gwt_comm.DrawStringInBoxLeft(e, 150, 20, 300, 40, "CASH RECEIPT", myfntDetailsFontBold, Brushes.Black)

        e.HasMorePages = False

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Laser Receipt Print"
        ShowErrorMessage()
    End Sub

    Private Sub pdWindows_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdWindows.PrintPage
        'This will send the printing to the windows type

        Dim y1 As Integer = 10

        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                'Dont print the company name as it is taken care of by the logo
                strCompanyName = ""
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                R = New Rectangle(10, y1, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                y1 = y1 + objPicture.Height
            End If
        End If

        y1 = y1 + 15

        For i As Integer = 0 To arrPrintDetails.Count - 1
            If i = 0 Then
                Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, arrPrintDetails.Item(i), tlFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, arrPrintDetails.Item(i), prFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Next
        e.HasMorePages = False
    End Sub

    Private Sub pdWindowsQuote_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdWindowsQuote.PrintPage
        'This will send the printing to the windows type

        Dim y1 As Integer = 10

        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                'Dont print the company name as it is taken care of by the logo
                strCompanyName = ""
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                R = New Rectangle(10, y1, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                y1 = y1 + objPicture.Height
            End If
        End If

        y1 = y1 + 15

        For i As Integer = 0 To arrPrintDetails.Count - 1
            If i = 0 Then
                Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, "*********************************", tlFont, Brushes.Black)
                y1 = y1 + 15
                Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, "*            QUOTATION          *", tlFont, Brushes.Black)
                y1 = y1 + 15
                Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, "*********************************", tlFont, Brushes.Black)
                y1 = y1 + 15
                Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, arrPrintDetails.Item(i), tlFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, arrPrintDetails.Item(i), prFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Next
        e.HasMorePages = False
    End Sub


End Class
