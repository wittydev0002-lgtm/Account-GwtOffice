Imports System.Drawing.Printing
Imports ComponentFactory.Krypton.Toolkit
'Imports FPAX_TAN2000
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCashSales

    'Fiscal printer settings FP2000 supplied by Axis Solutions
    'Dim AxisFiscalPrinter As New FPAX_TAN2000.FPAX_TAN200
    'Dim lResult As Long

    Dim strSelectedReport As String
    Dim prFont As New Font("Arial", 8, FontStyle.Regular)
    Dim tlFont As New Font("Arial", 8, FontStyle.Bold)
    Dim HeaderFont As New Font("Arial", 12, FontStyle.Bold)
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

    Private Sub frmScannedSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim frm As New frmLogin
        frm.ShowDialog()

        If UCase(strPublicSalesProcessingType) = "NORMAL" Then
            lblBarcode.Visible = True
            txtBarcode.Visible = True
            lblTicket.Visible = False
            txtTicketNumber.Visible = False
            btnRemove.Enabled = True
            btnAccountPayment.Enabled = True
            btnExchange.Enabled = True
            btnExchangePlus.Enabled = True
            btnExpenses.Enabled = True
            btnLaybyePayment.Enabled = True
            btnSearch.Enabled = True
        Else
            lblBarcode.Visible = False
            txtBarcode.Visible = False
            lblTicket.Visible = True
            txtTicketNumber.Visible = True
            btnRemove.Enabled = False
            btnAccountPayment.Enabled = False
            btnExchange.Enabled = False
            btnExchangePlus.Enabled = False
            btnExpenses.Enabled = False
            btnLaybyePayment.Enabled = False
            dGrid.AllowUserToDeleteRows = False
            For i As Integer = 0 To dGrid.Columns.Count - 1
                dGrid.Columns(i).ReadOnly = True
            Next
            btnSearch.Enabled = False
        End If

        If Not String.IsNullOrEmpty(strUserName) Then
            lblUsername.Text = UCase(Mid(strUserName, 1, 1)) & LCase(Mid(strUserName, 2, (strUserName.Length - 1)))
        End If
        With Me.dGrid
            .Rows.Add(350)
        End With

        LoadData()
        On Error GoTo RaiseErr
        'Load the employee details
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames " _
            & "AS [EmployeeDetails] FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        cboPersonnel.Items.Clear()
        cboPersonnel.Items.Add("")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboPersonnel.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmScannedSales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F5 Then
            strPublicItemCode = Nothing
            Dim f As New frmFindInventory
            f.ShowDialog()
            If Not String.IsNullOrEmpty(strPublicItemCode) Then
                cboItems.Visible = True
                cboItems.SelectedText = strPublicItemCode
                cboItems.Focus()
            End If
        End If
        If e.KeyValue = Keys.F3 Then
            If btnFinish.Enabled = False Then Exit Sub
            FinishSale()
        End If
        If e.KeyValue = Keys.F4 Then
            boolProcessingAccountPayment = True
            strPublicItemCode = Nothing 'txtaccountnumber
            strPublicItemDescription = Nothing 'txtaccountholdername
            'Reset the grid
            dGrid.Rows.Clear()
            dGrid.Rows.Add(350)
            lblDiscounts.Text = "0.00"
            lblPayable.Text = "0.00"
            lblSubTotal.Text = "0.00"
            lblTaxable.Text = "0.00"
            lblTaxes.Text = "0.00"
            boolAbort = False
            Dim f As New frmBrowseDebtors
            f.ShowDialog()
            If boolAbort = True Then
                Exit Sub
            Else
                FinishSale()
            End If
            boolProcessingAccountPayment = False
        End If
        If e.KeyValue = Keys.F6 Then
            Dim f As New frmLaybyeSettlement
            f.ShowDialog()
        End If
        If e.KeyValue = Keys.F7 Then
            LoadData()
        End If
        If e.KeyValue = Keys.F8 Then
            Dim f As New frmSalesReturns
            f.ShowDialog()
        End If
        If e.KeyValue = Keys.F9 Then
            Dim f As New frmSalesReturnsPlus
            f.ShowDialog()
        End If
        If e.KeyValue = Keys.F10 Then
            Dim f As New frmCashbookExpenses
            f.ShowDialog()
        End If
        If e.KeyValue = Keys.F11 Then
            If dGrid.Rows.Count > 0 Then
                dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
                RecalculateAmount()
                ComputeTotals()
            End If
        End If
        If e.KeyValue = Keys.F10 Then
            'Me.Close()
            'End
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Select Case UCase(strMainCompanyServiceOffering)
            Case Is = "PRODUCTS"
                If UCase(strDefaultSearchFilter) = "DESCRIPTION" Then
                    strSql = "SELECT GroupName +';'+ ItemCode +';'+ CONVERT(NVARCHAR, " _
                        & "CAST(SellingPrice AS DECIMAL (10,2))) +';'+ TaxStatus AS " _
                        & "[Items] FROM InventoryItems WHERE Offering = 'PRODUCT' AND Status = 'ACTIVE' ORDER BY ItemCode"
                Else
                    strSql = "SELECT ItemCode +';'+ GroupName +';'+ CONVERT(NVARCHAR, " _
                        & "CAST(SellingPrice AS DECIMAL (10,2))) +';'+ TaxStatus AS " _
                        & "[Items] FROM InventoryItems WHERE Offering = 'PRODUCT' AND Status = 'ACTIVE' ORDER BY ItemCode"
                End If
            Case Is = "SERVICES"
                If UCase(strDefaultSearchFilter) = "DESCRIPTION" Then
                    strSql = "SELECT GroupName +';'+ ItemCode +';'+ CONVERT(NVARCHAR, " _
                        & "CAST(SellingPrice AS DECIMAL (10,2))) +';'+ TaxStatus AS " _
                        & "[Items] FROM InventoryItems WHERE Offering = 'SERVICE' AND Status = 'ACTIVE' ORDER BY ItemCode"
                Else
                    strSql = "SELECT ItemCode +';'+ GroupName +';'+ CONVERT(NVARCHAR, " _
                        & "CAST(SellingPrice AS DECIMAL (10,2))) +';'+ TaxStatus AS " _
                        & "[Items] FROM InventoryItems WHERE Offering = 'SERVICE' AND Status = 'ACTIVE' ORDER BY ItemCode"
                End If
            Case Is = "HIRING ITEMS"
                If UCase(strDefaultSearchFilter) = "DESCRIPTION" Then
                    strSql = "SELECT GroupName +';'+ ItemCode +';'+ CONVERT(NVARCHAR, " _
                        & "CAST(SellingPrice AS DECIMAL (10,2))) +';'+ TaxStatus AS " _
                        & "[Items] FROM InventoryItems WHERE Offering = 'HIRE ITEM' AND Status = 'ACTIVE' ORDER BY ItemCode"
                Else
                    strSql = "SELECT ItemCode +';'+ GroupName +';'+ CONVERT(NVARCHAR, " _
                        & "CAST(SellingPrice AS DECIMAL (10,2))) +';'+ TaxStatus AS " _
                        & "[Items] FROM InventoryItems WHERE Offering = 'HIRE ITEM' AND Status = 'ACTIVE' ORDER BY ItemCode"
                End If
            Case Else
                If UCase(strDefaultSearchFilter) = "DESCRIPTION" Then
                    strSql = "SELECT  GroupName +';'+ ItemCode +';'+ CONVERT(NVARCHAR, " _
                        & "CAST(SellingPrice AS DECIMAL (10,2))) +';'+ TaxStatus AS " _
                        & "[Items] FROM InventoryItems WHERE Status = 'ACTIVE' ORDER BY ItemCode"
                Else
                    strSql = "SELECT ItemCode +';'+ GroupName +';'+ CONVERT(NVARCHAR, " _
                        & "CAST(SellingPrice AS DECIMAL (10,2))) +';'+ TaxStatus AS " _
                        & "[Items] FROM InventoryItems WHERE Status = 'ACTIVE' ORDER BY ItemCode"
                End If
        End Select

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 4
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "180;180;60;60"
        End With
        'Get a count of the items
        Dim intItemsCount As Double = 0

        Select Case UCase(strMainCompanyServiceOffering)
            Case Is = "PRODUCTS"
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'PRODUCT' AND Status = 'ACTIVE'", cnn)
            Case Is = "SERVICES"
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'SERVICE' AND Status = 'ACTIVE'", cnn)
            Case Is = "HIRING ITEMS"
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'HIRE ITEM' AND Status = 'ACTIVE'", cnn)
            Case Else
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Status = 'ACTIVE'", cnn)
        End Select

        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboItems.Items.Clear()
        Dim i As Double = 0
        Dim p As Double = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)), UCase(strRecordText(2)), UCase(strRecordText(3)))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboItems.SelectedIndex = -1
            cboItems.Items.Clear()
            cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboItems.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter
        On Error GoTo RaiseErr
        'cboSerials.Visible = False
        If chkDeliverySale.Checked = True Then Exit Sub
        If UCase(strPublicSalesProcessingType) <> "NORMAL" Then
            cboItems.Visible = False
            cboSerials.Visible = False
            Exit Sub
        End If

        If e.RowIndex < 0 Then Exit Sub
        If cboItems.Visible = True Then cboItems.Visible = False
        If e.ColumnIndex = 0 Then
            LoadData()
            cboItems.Size = dGrid.CurrentCell.Size
            cboItems.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + (pnlTop.Height + 1)
            cboItems.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left + (navTab.Size.Width + 2)
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                cboItems.Text = Convert.ToString(dGrid.CurrentCell.Value)
            Else
                cboItems.Text = ""
            End If
            cboItems.Visible = True '152
            cboItems.Focus()
            cboItems.SelectAll()
        End If

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
                    .Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + (pnlTop.Height + 1)
                    .Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left + (navTab.Size.Width + 2)
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

    Private Sub cboItems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboItems.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(1)
            dGrid.Focus()
        End If
    End Sub

    Private Sub cboItems_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.LostFocus
        cboItems.Visible = False
    End Sub

    Private Sub cboItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.SelectedIndexChanged
        CommitValueChanged()
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

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr
        'If cboItems.Focused = False Then Exit Sub
        If chkDeliverySale.Checked = True Then Exit Sub
        Dim objCommand As Data.OleDb.OleDbCommand
        For z As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.CurrentRow.Cells(z).Value = Nothing
        Next

        Dim boolItemTaxable As Boolean = True

        RecalculateAmount()

        If boolSearchReturn = True Then
            Dim strRecordText() As String = Split(strFullItemDetails, ";")
            Dim DropDownItems As MTGCComboBoxItem
            If UCase(strDefaultSearchFilter) = "DESCRIPTION" Then
                DropDownItems = New MTGCComboBoxItem(UCase(strRecordText(1)), UCase(strRecordText(0)), UCase(strRecordText(2)), UCase(strRecordText(3)))
            Else
                DropDownItems = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)), UCase(strRecordText(2)), UCase(strRecordText(3)))
            End If
            cboItems.SelectedItem = DropDownItems
        End If

        If Not cboItems.SelectedItem Is Nothing Then
            If UCase(strDefaultSearchFilter) = "DESCRIPTION" Then
                dGrid.CurrentRow.Cells(1).Value = cboItems.SelectedItem.Col1
                dGrid.CurrentRow.Cells(0).Value = cboItems.SelectedItem.Col2
            Else
                dGrid.CurrentRow.Cells(0).Value = cboItems.SelectedItem.Col1
                dGrid.CurrentRow.Cells(1).Value = cboItems.SelectedItem.Col2
            End If
            dGrid.CurrentRow.Cells(3).Value = cboItems.SelectedItem.Col3
            dGrid.CurrentRow.Cells(4).Value = "1"
            dGrid.CurrentRow.Cells(6).Value = "0"

            If UCase(cboItems.SelectedItem.Col4) = "YES" Then boolItemTaxable = True Else boolItemTaxable = False

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

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If dGrid.Rows.Count > 0 Then
            dGrid.CurrentCell = dGrid.CurrentRow.Cells(1)
            dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
            Dim iBal As Integer = 350 - dGrid.Rows.Count
            dGrid.Rows.Add(iBal)
            RecalculateAmount()
            ComputeTotals()
        End If
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        If String.IsNullOrEmpty(strPublicSalesAccount) Then
            MessageBox.Show("Missing the default sales ledger control account. Please set it up. For now the default will be used", _
                "Missing Sales Control Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            strPublicSalesAccount = "0000"
        End If
        ' ''If chkCashAccount.Checked = True Then
        ' ''    If String.IsNullOrEmpty(txtAccountHolderName.Text) Or _
        ' ''        String.IsNullOrEmpty(txtAccountNumber.Text) Then
        ' ''        MessageBox.Show("Missing the account number", MsgBoxStyle.Exclamation, "Missing Account Number")
        ' ''        txtAccountNumber.Focus()
        ' ''        Exit Sub
        ' ''    End If
        ' ''End If

        FinishSale()
        If strPublicSalesAccount = "0000" Then strPublicSalesAccount = Nothing
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
        Dim dpProcessDate As Date = Format(DateTime.Now, "dd-MMM-yyyy")
        Dim dblDisAmount As Double 'for discounts
        Dim dblSumTaxes As Double = 0, dblSumDiscounts As Double = 0, dblSumPayable As Double = 0
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim dbReader As Data.OleDb.OleDbDataReader

        Dim strTransactionProcessStatus As String = Nothing

        strTillPaymentMethod = Nothing

        Dim strPersonnel As String = "CASH PAYMENT"

        dblAmountTendered = 0
        dblAmountChange = 0

        If boolProcessingAccountPayment = True Then
            boolAbort = False
            Dim f As New frmAccountSettlement
            f.ShowDialog()
            If boolAbort = True Then Exit Sub

            On Error GoTo RaiseErr
            Cursor = Cursors.WaitCursor

            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))

            dblSumPayable = dblAccountSettlementAmount

            If strPublicDirectCashbbookSalesPosting = "YES" Then

                'Update the cashbook with the values
                Dim strCashbookDescription As String = "CASH SALE - " & UCase(strPersonnel)
                myCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, " _
                    & "TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, " _
                    & "TransactionType, Reference) VALUES " _
                    & "('" & strPublicActiveCashbook & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " _
                    & "" & dblSumPayable & ", '" & strCashbookDescription & "-" & strPublicItemCode & "', " _
                    & "'" & strPublicSalesAccount & "', '" & strUserName & "', '" & strUserBranch & "', " _
                    & "'DEBIT', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
                myCommand.ExecuteNonQuery()

                If UCase(strWebConnectionType) = "REALTIME" Then
                    strSqlTransmit = myCommand.CommandText
                    strSqlTransmit = Replace(strSqlTransmit, "INTO CashbookTransactions (", "INTO GroupCashbookTransactions (BranchName, ", 1)
                    strSqlTransmit = Replace(strSqlTransmit, "VALUES (", "VALUES ('" & strUserBranch & "', ", 1)
                    TransmitSale(strSqlTransmit)
                End If

                'Post the account to the contra ledger account
                myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                    & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference]) VALUES " _
                    & "('" & strPublicSalesAccount & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " & dblSumPayable & ", " _
                    & "'CREDIT', '" & strPublicActiveCashbook & "', '" & strCashbookDescription & "-" & strPublicItemCode & "', " _
                    & "'" & strUserName & "', '" & strUserBranch & "', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
                myCommand.ExecuteNonQuery()

                If UCase(strWebConnectionType) = "REALTIME" Then
                    strSqlTransmit = myCommand.CommandText
                    strSqlTransmit = Replace(strSqlTransmit, "INTO LedgerTransactions (", "INTO GroupLedgerTransactions (BranchName, ", 1)
                    strSqlTransmit = Replace(strSqlTransmit, "VALUES (", "VALUES ('" & strUserBranch & "', ", 1)
                    TransmitSale(strSqlTransmit)
                End If

            End If

            'Update the customer account
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO CustomerTransactions ([AccountNumber],[TransactionDate]," _
                & "[Amount],[TransactionType],[Description],[ReferenceNumber],[UserName],[BranchName]) " _
                & "VALUES('" & strPublicItemCode & "', '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " _
                & "" & dblSumPayable & ", 'PAYMENT', 'CASH PAYMENT', '" & txtReference.Text & "', " _
                & "'" & strUserName & "', '" & strUserBranch & "')", cnn)
            myCommand.ExecuteNonQuery()

            'If UCase(strWebConnectionType) = "REALTIME" Then
            '    strSqlTransmit = myCommand.CommandText
            '    strSqlTransmit = Replace(strSqlTransmit, "INTO CustomerTransactions", "INTO GroupCustomerTransactions", 1)
            '    TransmitSale(strSqlTransmit)
            'End If

            'Update the control numbers table
            myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET CashSales = " & CDbl(txtReference.Text) & "", cnn)
            myCommand.ExecuteNonQuery()

            strPublicCustomerId = strPublicItemCode
            PrintInvoice(dpProcessDate)
            MessageBox.Show("Sales document generated successfully.", "Transaction Document Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dblAmountChange = 0

        Else

            If dGrid.Rows.Count <= 0 Then
                MessageBox.Show("No document transactions to print !!!", "Empty Document Transactions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If Not String.IsNullOrEmpty(cboPersonnel.Text) Then
                strPersonnel = UCase(cboPersonnel.Text)
                'MessageBox.Show("Please select the name of the sales representative from the list provided", "Missing Sales Agent Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'cboPersonnel.Focus()
                'Exit Sub
            End If
            'Perform the till ring routine
            boolAbort = False
            dblSaleTotal = CDbl(lblPayable.Text)

            If dblSaleTotal <= 0 Then
                MessageBox.Show("Sale cannot be processed when there are no valid sub total values", "Sale Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
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

                    arrInvoiceData.Add(strSelectedId & "|" & strDescription & "|" & intQty & "|" & Format(dblUprice, "##0.00") & _
                        "|" & Format((dblUprice * intQty), "##0.00") & "|" & Format(dblDisAmount, "##0.00") & "|" & Format(dblTax, "##0.00") & _
                        "|" & Format(((dblUprice * intQty) - dblDisAmount) + dblTax, "##0.00"))

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
                        & "'" & strLineItemType & "', '" & strItemSerialNo & "', '" & lblUsername.Text & "', " _
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
                        'Reset the items on quick selection
                        LoadData()
                    End If

                End If

            Next i

            'dblSumPayable = CDbl(lblPayable.Text) - CDbl(lblTaxes.Text)
            'lblTaxable

            dblSumPayable = CDbl(lblTaxable.Text)

            'Add the record to the sales main
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO SalesMain (InvoiceNumber, CustomerId, " _
                & "TransDate, Discount, Taxes, Amount, UserName, SalesRep, ContactNumber, ContactName, " _
                & "KeyNumber, PaymentMethod) VALUES " _
                & "(" & Convert.ToDouble(txtReference.Text) & ", '0000', '" & dpProcessDate & "', " & dblSumDiscounts & ", " _
                & "" & dblSumTaxes & ", " & dblSumPayable & ", '" & lblUsername.Text & "', '" & strPersonnel & "', " _
                & "'" & strCustomerTelephoneNumber & "', '" & strTillCustomerName & "', " _
                & "" & Convert.ToDouble(txtKeyNumber.Text) & ", '" & strTillPaymentMethod & "')", cnn)
            myCommand.ExecuteNonQuery()

            ''If UCase(strWebConnectionType) = "REALTIME" Then
            ''    strSqlTransmit = myCommand.CommandText
            ''    strSqlTransmit = Replace(strSqlTransmit, "INTO SalesMain (", "INTO GroupSalesMain (BranchName, ", 1)
            ''    strSqlTransmit = Replace(strSqlTransmit, "VALUES (", "VALUES ('" & strUserBranch & "', ", 1)
            ''    TransmitSale(strSqlTransmit)
            ''End If

            If strPublicDirectCashbbookSalesPosting = "YES" Then

                'Update the cashbook with the values
                Dim strCashbookDescription As String = "CASH SALE - " & UCase(strPersonnel)
                myCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, TransactionType, Reference, KeyNumber) VALUES " _
                    & "('" & strPublicActiveCashbook & "', '" & dpProcessDate & "', " & dblSumPayable + CDbl(lblTaxes.Text) & ", '" & strCashbookDescription & "', '" & strPublicSalesAccount & "', '" & strUserName & "', " _
                    & "'" & strUserBranch & "', 'DEBIT', " & Convert.ToDouble(txtReference.Text) & ", " & Convert.ToDouble(txtKeyNumber.Text) & ")", cnn)
                myCommand.ExecuteNonQuery()

                ''If UCase(strWebConnectionType) = "REALTIME" Then
                ''    strSqlTransmit = myCommand.CommandText
                ''    strSqlTransmit = Replace(strSqlTransmit, "INTO CashbookTransactions (", "INTO GroupCashbookTransactions (BranchName, ", 1)
                ''    strSqlTransmit = Replace(strSqlTransmit, "VALUES (", "VALUES ('" & strUserBranch & "', ", 1)
                ''    TransmitSale(strSqlTransmit)
                ''End If

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

                ''If UCase(strWebConnectionType) = "REALTIME" Then
                ''    strSqlTransmit = myCommand.CommandText
                ''    strSqlTransmit = Replace(strSqlTransmit, "INTO LedgerTransactions (", "INTO GroupLedgerTransactions (BranchName, ", 1)
                ''    strSqlTransmit = Replace(strSqlTransmit, "VALUES (", "VALUES ('" & strUserBranch & "', ", 1)
                ''    TransmitSale(strSqlTransmit)
                ''End If

                'Insert into the cashbook control account as well

                'strTransactionProcessStatus = LedgerEntry("INSERT", dpProcessDate, strPublicCashControlAccount, _
                '    strPublicSalesAccount, strCashbookDescription, dblSumPayable + CDbl(lblTaxes.Text), "DEBIT", _
                '    txtReference.Text, , , , txtReference.Text, 0, 0, 0)
                'If strTransactionProcessStatus <> "SUCCESS" Then GoTo RaiseErr


            End If

            'Update the control numbers table
            Dim intNewInvoiceNumber As Double = CDbl(txtReference.Text)
            myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET CashSales = " & CDbl(txtReference.Text) & "", cnn)
            myCommand.ExecuteNonQuery()

            'Update the keynumbers
            Dim intNewKeyNumber As Double = CDbl(txtKeyNumber.Text)
            myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET KeyNumber = " & CDbl(txtKeyNumber.Text) & "", cnn)
            myCommand.ExecuteNonQuery()

            'Update the gatepass status if delivery
            If chkDeliverySale.Checked = True Then
                For p As Integer = 0 To arrSelectedItems.Count - 1
                    Dim strBuffered() As String = Split(arrSelectedItems.Item(p), "|")
                    myCommand = New Data.OleDb.OleDbCommand("UPDATE GatePasses SET Status = 'PROCESSED' " _
                        & "WHERE TransactionId = " & strBuffered(strBuffered.Length - 1) & "", cnn)
                    myCommand.ExecuteNonQuery()
                Next
                arrSelectedItems = Nothing
            End If

            'Update the ticket status if it is based on tickets
            If UCase(strPublicSalesProcessingType) <> "NORMAL" Then
                myCommand = New Data.OleDb.OleDbCommand("UPDATE TicketSalesMain SET Status = 'PROCESSED' WHERE InvoiceNumber = " & CDbl(txtTicketNumber.Text) & "", cnn)
                myCommand.ExecuteNonQuery()
            End If

            strPublicCustomerId = "0000"

            If UCase(strPublicReceiptType) = "DESKTOP PRINTER" Then
                PrintReceiptQuote("CASH RECEIPT")
                'PrintInvoiceTypeCashSlip(CInt(txtReference.Text))
            Else
                PrintInvoice(dpProcessDate)
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
            If strPublicMaintainTransactionDate = "NO" Then cboPersonnel.Text = ""
            txtReference.Text = ""
            txtKeyNumber.Text = ""
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))
            'lblDate.Visible = False

            dblAmountChange = 0
            dblAmountTendered = 0
            boolDeliverySale = False
            chkDeliverySale.Checked = False
            Cursor = Cursors.Default

            ''If UCase(strWebConnectionType) = "REALTIME" Then
            ''    TransmitSaleToServer(intNewInvoiceNumber)
            ''End If

        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Processing"
        ShowErrorMessage()
    End Sub

    Private Sub PrintInvoiceTypeCashSlip(ByVal ReceiptNumber As Integer)
        GenerateTransactionDocument(ReceiptNumber)
        intSelectedTransaction = ReceiptNumber
        boolAbort = False
        Dim f As New frmPrinterSetup
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        PrintDocument1.PrinterSettings.PrinterName = strSessionPrinter
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
        boolPrintFromPreview = True
    End Sub

    Private Sub TransmitSaleToServer(ByVal intInvoiceNumber As Double)
        On Error GoTo RaiseErr
        Dim intBatchNumber As Double = gwt_comm.GetBatchNumber()
        Dim fileString As String = Nothing
        Dim strDetailedSales As String = Nothing

        Dim arrTransmittedInvoices As New ArrayList

        Dim strInvNo As String = "0"

        arrTransmittedInvoices.Add(intInvoiceNumber)
        Dim objGetSalesMainData As New Data.OleDb.OleDbCommand("SELECT [InvoiceNumber]," _
            & "[CustomerId],[Status],[Amount],[Taxes],[Discount]" _
            & ",CONVERT(NVARCHAR, [TransDate], 105) AS [TransDate], [SalesRep],[UserName]," _
            & "[OriginalInvoice] FROM SalesMain WHERE InvoiceNumber = " & intInvoiceNumber & "", cnn)
        Dim objReadSales As OleDb.OleDbDataReader = objGetSalesMainData.ExecuteReader
        While objReadSales.Read

            Dim strTaxCharged As String = "0.00"
            Dim strDiscountAllowed As String = "0.00"
            Dim strAmountPayable As String = "0.00"
            Dim strDate As String = Nothing
            Dim strCustomerId As String = Nothing
            Dim strStatus As String = Nothing
            Dim strSalesAgent As String = Nothing
            Dim strSalesUser As String = Nothing
            Dim intOriginalInvoice As Int16 = 0
            Dim strOriginatingBranch As String = Nothing

            If Not IsDBNull(objReadSales("TransDate").ToString) Then
                strDate = objReadSales("TransDate").ToString
                Dim strDateSplit() As String = Split(strDate, "-")
                strDate = strDateSplit(0) & "-" & MonthName(CDbl(strDateSplit(1)), True) & "-" & strDateSplit(2)
            End If
            If Not IsDBNull(objReadSales("Amount").ToString) Then
                If IsNumeric(objReadSales("Amount").ToString) Then
                    strAmountPayable = objReadSales("Amount").ToString
                End If
            End If
            If Not IsDBNull(objReadSales("Discount").ToString) Then
                If IsNumeric(objReadSales("Discount").ToString) Then
                    strDiscountAllowed = objReadSales("Discount").ToString
                End If
            End If
            If Not IsDBNull(objReadSales("Taxes").ToString) Then
                If IsNumeric(objReadSales("Taxes").ToString) Then
                    strTaxCharged = objReadSales("Taxes").ToString
                End If
            End If

            If Not IsDBNull(objReadSales("CustomerId").ToString) Then
                strCustomerId = objReadSales("CustomerId").ToString
            End If

            If Not IsDBNull(objReadSales("Status").ToString) Then
                strStatus = objReadSales("Status").ToString
            End If

            If Not IsDBNull(objReadSales("SalesRep").ToString) Then
                strSalesAgent = objReadSales("SalesRep").ToString
            End If
            If Not IsDBNull(objReadSales("UserName").ToString) Then
                strSalesUser = objReadSales("UserName").ToString
            End If
            If Not IsDBNull(objReadSales("OriginalInvoice").ToString) Then
                If IsNumeric(objReadSales("OriginalInvoice").ToString) Then
                    intOriginalInvoice = objReadSales("OriginalInvoice").ToString
                End If
            End If

            fileString = fileString & "MAIN SALES|" & intBatchNumber & "|" & strInvNo & "|" & strCustomerId & "|" _
                & strStatus & "|" & strAmountPayable & "|" & strTaxCharged & "|" & strDiscountAllowed & "|" & strDate & "|" _
                & strSalesAgent & "|" & strSalesUser & "|" & intOriginalInvoice & "|" & strUserBranch & "|" & strUserName & vbCrLf

        End While
        objReadSales.Close()

        'Transmit the sales details
        For i As Double = 0 To arrTransmittedInvoices.Count - 1
            Dim objSalesDetails As New Data.OleDb.OleDbCommand("SELECT [InvoiceNumber],[CustomerId]," _
                & "[ItemCode],[Description],[Quantity],[DiscountAllowed],[Taxes]" _
                & ",[TransType],[SalesPrice],[TransDate],[ProductType],[SerialNumbers],[OriginalInvoice]" _
                & ",[SalesRep],[UserName] FROM Sales WHERE InvoiceNumber = " & arrTransmittedInvoices.Item(i) & "", cnn)
            objReadSales = objSalesDetails.ExecuteReader
            While objReadSales.Read
                fileString = fileString & "DETAILED SALES|" & intBatchNumber & "|" & objReadSales(0).ToString & "|" & objReadSales(1).ToString & "|" _
                    & objReadSales(2).ToString & "|" & objReadSales(3).ToString & "|" & objReadSales(4).ToString & "|" _
                    & objReadSales(5).ToString & "|" & objReadSales(6).ToString & "|" & objReadSales(7).ToString & "|" _
                    & objReadSales(8).ToString & "|" & objReadSales(9).ToString & "|" & objReadSales(10).ToString & "|" _
                    & objReadSales(11).ToString & "|" & objReadSales(12).ToString & "|" & objReadSales(13).ToString & "|" _
                    & objReadSales(14).ToString & "|" & strUserBranch & "|" & strUserName & vbCrLf
            End While
            objReadSales.Close()
        Next

        Cursor = Cursors.WaitCursor
        boolAbort = False
        strDownloadingType = "SALES"
        ServerDestinationFolder = strWebMainBranch.Replace(" ", "") & "/DailySales"
        strDestinationBranch = strWebMainBranch
        'Transmit the main sales data first
        gwt_comm.AddDataChanges(fileString)
        If boolAbort = True Then
            MessageBox.Show("There were errors encountered when transmit sales data." & _
                vbCrLf & "Make sure that the connection is on and retry sending", "Data Transmission Failure", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim objUpdate As New Data.OleDb.OleDbCommand("UPDATE SalesTranmissonBatches SET BatchNo = (BatchNo + 1)", cnn)
            objUpdate.ExecuteNonQuery()
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Web Sales Data Transmissions"
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
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress1))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress2))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress3))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress4))
        arrPrintDetails.Add(Space(2) & "PHONE: " & strPublicBranchTelephone)
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
                        arrPrintDetails.Add(Space(4) & Space(5 - strQuantity.Length) & strQuantity & " @ " & Space(8 - strUnitPrice.Length) & strUnitPrice & Space(4) & Space(8 - strLineTotal.Length) & strLineTotal)
                        dblVatTax = dblVatTax + Convert.ToDouble(.Rows(i).Cells(7).Value)

                        If UCase(strPublicTaxFiscalStatus) = "YES" Then
                            Dim strFiscalUnitPrice As String = Format(CDbl(.Rows(i).Cells(3).Value.ToString), "###0.00")
                            Dim strFiscalItemCode As String = .Rows(i).Cells(0).Value.ToString
                            Dim strFiscalTaxCode As String = "A"
                            'Get the item taxcode
                            Dim objGetItemTaxCode As New Data.OleDb.OleDbCommand("SELECT TaxCode FROM InventoryItems WHERE ItemCode = '" & strFiscalItemCode & "'", cnn)
                            Dim objReadTaxCode As Data.OleDb.OleDbDataReader = objGetItemTaxCode.ExecuteReader
                            If objReadTaxCode.HasRows Then
                                objReadTaxCode.Read()
                                If Not IsDBNull(objReadTaxCode(0).ToString) Then strFiscalTaxCode = objReadTaxCode(0).ToString
                            End If
                            objReadTaxCode.Close()
                            arrFiscalReceiptItems.Add(strFiscalItemCode & "|" & strDescription & "|" & strFiscalUnitPrice & "|" & strQuantity & "|" & strFiscalTaxCode)
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

        Dim strZimDate As String = Format(Now, "dd-MMM-yyyy")

        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(2) & "TILL OPER :" & UCase(strUserName) & Space(3))
        arrPrintDetails.Add(Space(2) & "SALES REP :")
        If cboItems.Text.Length > 30 Then
            arrPrintDetails.Add(Space(2) & UCase(Mid(cboPersonnel.Text, 1, 30)))
        Else
            arrPrintDetails.Add(Space(2) & UCase(cboPersonnel.Text))
        End If

        arrPrintDetails.Add(Space(1) & "DATE AND TIME " & strZimDate & " " & DatePart(DateInterval.Hour, Now) & ":" & DatePart(DateInterval.Minute, Now))
        arrPrintDetails.Add(Space(2) & UCase(strReceiptHeader) & " DATE  " & Format(dtReceiptDate, "dd-MMM-yyyy"))
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
        'Try printing using the line printer
        ' Allow the user to select a file.
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
                    'RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, output)
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
        'lblPayable.Text = Format(dblMovingTotal, "#,##0.00")
        'lblSubTotal.Text = Format(((dblMovingTotal - dblTxs) + dblDiscounts), "#,##0.00")
        'lblDiscounts.Text = Format(dblDis, "#,##0.00")
        'lblTaxes.Text = Format(dblTxs, "#,##0.00")

        lblSubTotal.Text = Format(dblSubs, "#,##0.00")
        lblTaxable.Text = Format((dblSubs - dblDis - dblTxs), "#,##0.00")
        lblTaxes.Text = Format(dblTxs, "#,##0.00")
        lblDiscounts.Text = Format(dblDis, "#,##0.00")
        lblPayable.Text = Format(dblMovingTotal, "#,##0.00")

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
        'lblSubTotal.Text = Format(((dblTotalPayable - dblTaxesTotal) + dblDiscountTotals), "#,##0.00")
        lblSubTotal.Text = Format(dblSubTotal, "#,##0.00")
        lblTaxable.Text = Format((dblSubTotal - dblDiscountTotals - dblTaxesTotal), "#,##0.00")
        lblTaxes.Text = Format(dblTaxesTotal, "#,##0.00")
        lblDiscounts.Text = Format(dblDiscountTotals, "#,##0.00")
        lblPayable.Text = Format(dblTotalPayable, "#,##0.00")
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        strPublicItemCode = Nothing
        strFullItemDetails = Nothing
        Dim f As New frmFindInventory
        f.ShowDialog()
        If Not String.IsNullOrEmpty(strFullItemDetails) Then
            cboItems.Visible = True
            cboItems.Focus()
            cboItems.SelectedItem = Nothing
            'Dim strRecordText() As String = Split(strFullItemDetails, ";")
            'Dim DropDownItems As MTGCComboBoxItem
            'If UCase(strDefaultSearchFilter) = "DESCRIPTION" Then
            '    DropDownItems = New MTGCComboBoxItem(UCase(strRecordText(1)), UCase(strRecordText(0)), UCase(strRecordText(2)), UCase(strRecordText(3)))
            'Else
            '    DropDownItems = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)), UCase(strRecordText(2)), UCase(strRecordText(3)))
            'End If
            'cboItems.SelectedItem = DropDownItems
            boolSearchReturn = True
            cboItems.Focus()
            CommitValueChanged()
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(1)
        End If
        boolSearchReturn = False
    End Sub

    ' ''Private Sub chkCashAccount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCashAccount.CheckedChanged
    ' ''    If chkCashAccount.Checked = True Then
    ' ''        txtAccountHolderName.Enabled = True
    ' ''        txtAccountNumber.Enabled = True
    ' ''        btnFindAccount.Enabled = ButtonEnabled.True
    ' ''        chkDeliverySale.Enabled = False
    ' ''        dGrid.Enabled = False
    ' ''        cboItems.Visible = False
    ' ''        pnlLoyalty.Enabled = False
    ' ''        txtBarcode.Enabled = False
    ' ''    Else
    ' ''        txtAccountHolderName.Enabled = False
    ' ''        txtAccountNumber.Enabled = False
    ' ''        btnFindAccount.Enabled = ButtonEnabled.False
    ' ''        chkDeliverySale.Enabled = True
    ' ''        dGrid.Enabled = True
    ' ''        pnlLoyalty.Enabled = True
    ' ''        txtBarcode.Enabled = True
    ' ''    End If
    ' ''End Sub

    'Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
    '    Me.Close()
    '    'End
    'End Sub

    Private Sub btnExchangePlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExchangePlus.Click
        Dim f As New frmSalesReturnsPlus
        f.ShowDialog()
    End Sub

    Private Sub btnExchange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExchange.Click
        Dim f As New frmSalesReturns
        f.ShowDialog()
    End Sub

    Private Sub dGrid_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.LostFocus
        'cboItems.Visible = False
    End Sub

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        If Not String.IsNullOrEmpty(txtBarcode.Text) Then
            If Asc(e.KeyChar) = 13 Then
                e.Handled = True
                ProcessBarCode()
                Exit Sub
            End If
        End If
    End Sub

    '    Private Sub ReadBarcode()
    '        On Error GoTo RaiseErr
    '        If String.IsNullOrEmpty(txtBarcode.Text) Then Exit Sub
    '        'Get the current available line entry number
    '        cboItems.Visible = False
    '        Dim objCommand As Data.OleDb.OleDbCommand
    '        Dim intActiveLine AS DOUBLE = 0
    '        For i AS DOUBLE = 0 To dGrid.Rows.Count - 1
    '            If (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then

    '                Dim strNewBarCode As String = Nothing
    '                Dim strNewSerialNo As String = Nothing

    '                Dim strSourceSerialNo As String = Nothing

    '                intActiveLine = i

    '                'Reset the cell values
    '                For z AS DOUBLE = 0 To dGrid.Columns.Count - 1
    '                    If z <> 3 Then dGrid.Rows(intActiveLine).Cells(z).Value = Nothing
    '                Next

    '                RecalculateAmount()

    '                Dim strSql As String = Nothing

    '                'First search for the item under the generic items barcodes table
    '                'If the item is not there, then search for the item in the serial numbers
    '                'table which contains specific items barcode

    '                Dim strFoundItemCode As String = Nothing
    '                objCommand = New Data.OleDb.OleDbCommand("SELECT ItemCode FROM GenericItemsBarcodes WHERE Barcode = '" & txtBarcode.Text & "'", cnn)
    '                Dim objGetBarcode As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '                If objGetBarcode.HasRows Then
    '                    objGetBarcode.Read()
    '                    If Not IsDBNull(objGetBarcode(0).ToString) Then strFoundItemCode = objGetBarcode(0).ToString
    '                Else
    '                    'Search for the item under the specifics
    '                    If txtBarcode.Text.Length > 9 Then
    '                        strNewBarCode = Mid(txtBarcode.Text, 1, 9)
    '                        strNewSerialNo = Mid(txtBarcode.Text, 10, txtBarcode.Text.Length - 9)
    '                    Else
    '                        strNewBarCode = txtBarcode.Text
    '                        strNewSerialNo = ""
    '                    End If
    '                    objCommand = New Data.OleDb.OleDbCommand("SELECT ItemCode, SourceSerialNo FROM " _
    '                        & "SerialNumbers WHERE BarCodeNo = '" & strNewBarCode & "'", cnn)
    '                    Dim objGetSpecificBarCode As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '                    If objGetSpecificBarCode.HasRows Then
    '                        objGetSpecificBarCode.Read()
    '                        If Not IsDBNull(objGetSpecificBarCode(0).ToString) Then strFoundItemCode = objGetSpecificBarCode(0).ToString
    '                        If Not IsDBNull(objGetSpecificBarCode(1).ToString) Then strSourceSerialNo = objGetSpecificBarCode(1).ToString
    '                    End If
    '                    objGetSpecificBarCode.Close()
    '                End If
    '                objGetBarcode.Close()
    '                If Not String.IsNullOrEmpty(strFoundItemCode) Then
    '                    strSql = "SELECT ItemCode, GroupName, CONVERT(NVARCHAR, " _
    '                        & "CAST(SellingPrice AS DECIMAL (10,2))) AS [Price], TaxStatus " _
    '                        & "FROM InventoryItems WHERE ItemCode = '" & strFoundItemCode & "'"
    '                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
    '                    Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '                    If objReader.HasRows Then
    '                        objReader.Read()
    '                        If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(intActiveLine).Cells(0).Value = objReader(0).ToString
    '                        If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(intActiveLine).Cells(1).Value = objReader(1).ToString
    '                        If Not IsDBNull(objReader(2).ToString) Then dGrid.Rows(intActiveLine).Cells(4).Value = objReader(2).ToString
    '                        If Not String.IsNullOrEmpty(strNewSerialNo) Then
    '                            If strNewSerialNo.Length < 4 Then strNewSerialNo = strSourceSerialNo
    '                        End If
    '                        dGrid.Rows(intActiveLine).Cells(2).Value = strNewSerialNo
    '                        dGrid.Rows(intActiveLine).Cells(5).Value = "1"
    '                        dGrid.Rows(intActiveLine).Cells(7).Value = "0"
    '                        'Apply the discount
    '                        objCommand = New Data.OleDb.OleDbCommand("SELECT Category, SellingPrice FROM InventoryItems WHERE ItemCode = '" & objReader(0).ToString & "'", cnn)
    '                        Dim objReadCategory As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '                        If objReadCategory.HasRows Then
    '                            objReadCategory.Read()
    '                            If Not IsDBNull(objReadCategory(0).ToString) Then
    '                                If UCase(objReadCategory(0).ToString) = "CELLPHONES" Then
    '                                    If CDbl(objReadCategory(1).ToString) >= 100 And CDbl(objReadCategory(1).ToString) < 600 Then
    '                                        dGrid.Rows(intActiveLine).Cells(7).Value = RoundDown(objReadCategory(1) * 0.05)
    '                                    End If
    '                                    If CDbl(objReadCategory(1).ToString) >= 600 Then
    '                                        dGrid.Rows(intActiveLine).Cells(7).Value = RoundDown(objReadCategory(1) * 0.1)
    '                                    End If
    '                                End If
    '                            End If
    '                        End If
    '                        ComputeValues(CDbl(dGrid.Rows(intActiveLine).Cells(4).Value.ToString), CDBL(dGrid.Rows(intActiveLine).Cells(5).Value.ToString), intActiveLine, dGrid.Rows(intActiveLine).Cells(7).Value.ToString, 0)
    '                    Else
    '                        dGrid.Rows(intActiveLine).Cells(0).Value = Nothing
    '                        dGrid.Rows(intActiveLine).Cells(1).Value = Nothing
    '                        dGrid.Rows(intActiveLine).Cells(4).Value = Nothing
    '                        dGrid.Rows(intActiveLine).Cells(5).Value = Nothing
    '                    End If
    '                    objReader.Close()
    '                    Exit For
    '                Else
    '                    MessageBox.Show("Item barcode not found in the system", MsgBoxStyle.Critical, "Invalid Item Bar Code")
    '                    Exit Sub
    '                End If
    '            End If
    '        Next
    '        txtBarcode.Clear()
    '        txtBarcode.Focus()
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCritical & "Bar code fetch failure"
    '        ShowErrorMessage()
    '    End Sub

    Private Sub ProcessBarCode()

        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtBarcode.Text) Then Exit Sub

        'Get the current available line entry number
        cboItems.Visible = False

        boolAbort = False
        Dim strValues() As String = gwt_comm.ReadBarcode(txtBarcode.Text)
        If boolAbort = True Then Exit Sub

        'The return array contains the item code, transactionid, Foundstatus, serial number

        If String.IsNullOrEmpty(strValues(0)) Then
            MessageBox.Show("Item barcode not found in the system", "Invalid Item Bar Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim intActiveLine As Double = 0
        For i As Double = 0 To dGrid.Rows.Count - 1
            If (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                intActiveLine = i
                'Reset the cell values
                For z As Integer = 0 To dGrid.Columns.Count - 1
                    If z = 1 Then
                        'do nothing 
                    Else
                        dGrid.Rows(intActiveLine).Cells(z).Value = Nothing
                    End If
                Next

                RecalculateAmount()

                If UCase(strValues(4)) = "SPECIFIC" Then
                    If isItemAlreadyAdded(strValues(0), strValues(3)) = True Then
                        MessageBox.Show("Item cannot be added to transfer multiple time", "Process Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                Dim strSql As String = Nothing
                strSql = "SELECT ItemCode, GroupName, CONVERT(NVARCHAR, " _
                    & "CAST(SellingPrice AS DECIMAL (10,2))) AS [Price], TaxStatus, FullBarcodeSerialStatus " _
                    & "FROM InventoryItems WHERE ItemCode = '" & strValues(0) & "'"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(intActiveLine).Cells(0).Value = objReader(0).ToString
                    If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(intActiveLine).Cells(1).Value = objReader(1).ToString
                    If Not IsDBNull(objReader(2).ToString) Then dGrid.Rows(intActiveLine).Cells(3).Value = objReader(2).ToString

                    'Apply the discount
                    Dim dblDiscounts() As Double = gwt_comm.ItemOnSpecials(objReader(0).ToString, CDbl(objReader(2).ToString))

                    dGrid.Rows(intActiveLine).Cells(2).Value = strValues(3)
                    dGrid.Rows(intActiveLine).Cells(4).Value = "1"
                    dGrid.Rows(intActiveLine).Cells(6).Value = CStr(Format((dblDiscounts(1) * CDbl(dGrid.Rows(intActiveLine).Cells(4).Value.ToString)), "##0.00"))
                    dGrid.Rows(intActiveLine).Cells(10).Value = strValues(1)

                    'Apply the rates from specials into the cells

                    ComputeValues(CDbl(dGrid.Rows(intActiveLine).Cells(3).Value.ToString), _
                        CDbl(dGrid.Rows(intActiveLine).Cells(4).Value.ToString), intActiveLine, _
                            dGrid.Rows(intActiveLine).Cells(6).Value.ToString, 0)

                End If
                cboItems.Visible = False
                txtBarcode.Text = ""
                txtBarcode.Focus()
                Exit For
            End If
        Next
        txtBarcode.Clear()
        txtBarcode.Focus()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCritical & "Bar code fetch failure"
        ShowErrorMessage()
    End Sub

    Private Sub btnExpenses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpenses.Click
        Dim f As New frmCashbookExpenses
        f.ShowDialog()
    End Sub

    Private Sub cboItems_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboItems.Validating
        On Error GoTo RaiseErr
        boolAbort = False
        checkAvailability(cboItems.SelectedItem.Col1)
        If boolAbort = True Then
            cboItems.Text = ""
        End If
        Exit Sub
RaiseErr:
        If Err.Number = 91 Then
            Exit Sub
        Else
            strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Item Code Select Error"
            ShowErrorMessage()
        End If
    End Sub

    Private Sub dGrid_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dGrid.ColumnWidthChanged
        If e.Column.Index = 0 Then
            cboItems.Width = dGrid.Columns(0).Width
            cboItems.Refresh()
            cboSerials.Width = dGrid.Columns(2).Width
            cboSerials.Refresh()
        End If
    End Sub

    Public Function isItemAlreadyAdded(ByVal ItemCode As String, ByVal SerialNumber As String) As Boolean
        Dim boolReturn As Boolean = False
        For i As Double = 0 To dGrid.Rows.Count - 1
            Dim strCode As String = Nothing
            Dim strSerial As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strCode = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                strSerial = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
            End If
            If UCase(strCode) = UCase(ItemCode) And UCase(strSerial) = UCase(SerialNumber) Then
                boolReturn = True
                Exit For
            End If
        Next
        Return boolReturn
    End Function

    Private Sub chkDeliverySale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDeliverySale.CheckedChanged
        boolDeliverySale = False
        If chkDeliverySale.Checked = True Then
            If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
                boolAbort = False
                Dim frm1 As New frmDeliveryItemsView
                frm1.ShowDialog()
                If boolAbort = True Then
                    boolAuthorized = False
                    chkDeliverySale.Checked = False
                    Exit Sub
                End If
                If arrSelectedItems.Count > 0 Then
                    LoadDeliveryItems()
                    boolDeliverySale = True
                End If
            Else
                boolAbort = False
                boolAuthorized = False
                boolDeliverySale = False
                Dim f As New frmSupervisorAuthorizaton
                f.ShowDialog()
                If boolAuthorized = False Then
                    chkDeliverySale.Checked = False
                Else
                    boolAbort = False
                    Dim frm As New frmDeliveryItemsView
                    frm.ShowDialog()
                    If boolAbort = True Then
                        boolAuthorized = False
                        chkDeliverySale.Checked = False
                        Exit Sub
                    End If
                    If arrSelectedItems.Count > 0 Then
                        LoadDeliveryItems()
                        boolDeliverySale = True
                    End If
                End If
            End If
        Else
            'Clear the grid
            With Me.dGrid
                .Rows.Clear()
                .Rows.Add(350)
            End With
        End If
    End Sub

    Private Sub LoadDeliveryItems()
        On Error GoTo RaiseErr
        Dim intRowIndex As Integer = 0
        For i As Integer = 0 To arrSelectedItems.Count - 1
            Dim strBuffer() As String = Split(arrSelectedItems.Item(i), "|")
            '** BUFFER ITEMS -> Item Code, Description, Unit Price, Quantity, Payable, Serial, Full Serial, Tax Status
            '** GRID ITEMS -> Item Code, Description, Serial Number, Unit Price, Qty, Sub Total, Discount, Taxes, Payable, Type, SerialId
            Dim strType As String = "GENERIC"
            If Not String.IsNullOrEmpty(strBuffer(5)) Then strType = "SPECIFIC"

            For z As Integer = 0 To dGrid.Columns.Count - 1
                dGrid.Rows(intRowIndex).Cells(z).Value = Nothing
            Next
            RecalculateAmount()
            If Not String.IsNullOrEmpty(strBuffer(0)) Then
                dGrid.Rows(intRowIndex).Cells(0).Value = strBuffer(0)
                dGrid.Rows(intRowIndex).Cells(1).Value = strBuffer(1)
                dGrid.Rows(intRowIndex).Cells(3).Value = strBuffer(2)
                dGrid.Rows(intRowIndex).Cells(4).Value = strBuffer(3)
                dGrid.Rows(intRowIndex).Cells(6).Value = "0"
                dGrid.Rows(intRowIndex).Cells(9).Value = strType
                dGrid.Rows(intRowIndex).Cells(2).Value = strBuffer(5)
                dGrid.Rows(intRowIndex).Cells(10).Value = strBuffer(6)
                'Apply the discount
                Dim dblDiscounts() As Double = gwt_comm.ItemOnSpecials(strBuffer(0), CDbl(strBuffer(2)))
                dGrid.Rows(intRowIndex).Cells(6).Value = CStr(Format((dblDiscounts(1) * CDbl(dGrid.Rows(intRowIndex).Cells(4).Value.ToString)), "##0.00"))

                ComputeValues(CDbl(dGrid.Rows(intRowIndex).Cells(3).Value.ToString), CDbl(dGrid.Rows(intRowIndex).Cells(4).Value.ToString), dGrid.Rows(intRowIndex).Index, dGrid.Rows(intRowIndex).Cells(6).Value.ToString, 0)

                intRowIndex = intRowIndex + 1
            End If
        Next
        'Disable the first 3 columns from editing
        For n As Integer = 0 To 4
            dGrid.Columns(n).ReadOnly = True
        Next
        cboItems.Visible = False
        cboPersonnel.Focus()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to populate delivery items on to the sales form"
        ShowErrorMessage()
    End Sub

    Private Sub btnAccountPayment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccountPayment.Click
        boolProcessingAccountPayment = True
        strPublicItemCode = Nothing 'txtaccountnumber
        strPublicItemDescription = Nothing 'txtaccountholdername
        'Reset the grid
        dGrid.Rows.Clear()
        dGrid.Rows.Add(350)
        lblDiscounts.Text = "0.00"
        lblPayable.Text = "0.00"
        lblSubTotal.Text = "0.00"
        lblTaxable.Text = "0.00"
        lblTaxes.Text = "0.00"
        boolAbort = False
        Dim f As New frmBrowseDebtors
        f.ShowDialog()
        If boolAbort = True Then
            Exit Sub
        Else
            FinishSale()
        End If
        boolProcessingAccountPayment = False
    End Sub

    Private Sub btnPromacc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Just ge the customer account number and a flag that tells the system its a promacc and then return to this form
        'for completing sale processing

        'Dim f As New frmLoyaltyCustomerSales
        'f.ShowDialog()
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
        If chkDeliverySale.Checked = True Then Exit Sub
        If Not cboSerials.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(2).Value = cboSerials.SelectedItem.Col1
        Else
            dGrid.CurrentRow.Cells(2).Value = Nothing
        End If
    End Sub

    Private Sub cboSerials_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSerials.LostFocus
        cboSerials.Visible = False
    End Sub

    Private Sub chkLoyltyAccount_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLoyltyAccount.CheckStateChanged
        strSelectedAccount = Nothing
        strSelectedCustomerName = Nothing
        If chkLoyltyAccount.Checked Then
            boolAbort = False
            Dim f As New frmLoyaltyCustomerSales
            f.ShowDialog()
            If boolAbort = True Then
                chkLoyltyAccount.Checked = False
                Exit Sub
            Else
                lblLoyaltyAccountHolder.Text = strSelectedCustomerName
                lblLoyaltyAccountNumber.Text = strSelectedAccount
            End If
        End If
    End Sub

    Private Sub btnLaybyePayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaybyePayment.Click
        Dim f As New frmLaybyeSettlement
        f.ShowDialog()
    End Sub

    Private Sub LoadTicketDetails(ByVal TicketNumber As Long)
        On Error GoTo RaiseErr
        With Me.dGrid
            .Rows.Clear()
            .Rows.Add(350)
        End With
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM TicketSalesMain WHERE InvoiceNumber = " & TicketNumber & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If UCase(objReader("Status").ToString) <> "PENDING" Then
                MessageBox.Show("The selected ticket number can not be receipted right now as it has already been receipted", _
                    "Ticket Processed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btnFinish.Enabled = False
            Else
                btnFinish.Enabled = True
            End If

            'Show the ticket details
            If Not IsDBNull(objReader("SalesRep").ToString) Then
                cboPersonnel.Text = UCase(objReader("SalesRep").ToString)
            End If

            'Read the transactions

            objCommand = New Data.OleDb.OleDbCommand("SELECT TicketSales.ItemCode, TicketSales.Description, " _
                & "TicketSales.SerialNumbers, CAST(TicketSales.SalesPrice AS DECIMAL (10,2)) AS [SalesPrice], " _
                & "TicketSales.Quantity, CAST((TicketSales.SalesPrice * TicketSales.Quantity) AS DECIMAL (10,2)) as [SubTotal], " _
                & "CAST(TicketSales.DiscountAllowed AS DECIMAL (10,2)) AS [Discount], CAST(TicketSales.Taxes AS DECIMAL (10,2)) AS [Taxes], " _
                & "CAST((((TicketSales.SalesPrice * TicketSales.Quantity) - TicketSales.DiscountAllowed) + TicketSales.Taxes) AS DECIMAL (10,2)) AS [Payable], " _
                & "TicketSales.ProductType FROM TicketSales WHERE " _
                & "InvoiceNumber = " & TicketNumber & " ORDER BY TransactionId ", cnn)
            Dim objReadTransactions As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            Dim i As Integer = 0
            While objReadTransactions.Read
                With dGrid
                    If Not IsDBNull(objReadTransactions(0).ToString) Then .Rows(i).Cells(0).Value = objReadTransactions(0).ToString
                    If Not IsDBNull(objReadTransactions(1).ToString) Then .Rows(i).Cells(1).Value = objReadTransactions(1).ToString
                    If Not IsDBNull(objReadTransactions(2).ToString) Then .Rows(i).Cells(2).Value = objReadTransactions(2).ToString
                    If Not IsDBNull(objReadTransactions(3).ToString) Then .Rows(i).Cells(3).Value = objReadTransactions(3).ToString
                    If Not IsDBNull(objReadTransactions(4).ToString) Then .Rows(i).Cells(4).Value = objReadTransactions(4).ToString
                    If Not IsDBNull(objReadTransactions(5).ToString) Then .Rows(i).Cells(5).Value = objReadTransactions(5).ToString
                    If Not IsDBNull(objReadTransactions(6).ToString) Then .Rows(i).Cells(6).Value = objReadTransactions(6).ToString
                    If Not IsDBNull(objReadTransactions(7).ToString) Then .Rows(i).Cells(7).Value = objReadTransactions(7).ToString
                    If Not IsDBNull(objReadTransactions(8).ToString) Then .Rows(i).Cells(8).Value = objReadTransactions(8).ToString
                    If Not IsDBNull(objReadTransactions(9).ToString) Then .Rows(i).Cells(9).Value = objReadTransactions(9).ToString
                End With
                'Compute the line total
                ComputeValues(CDbl(dGrid.Rows(i).Cells(3).Value.ToString), CDbl(dGrid.Rows(i).Cells(4).Value.ToString), dGrid.Rows(i).Index, dGrid.Rows(i).Cells(6).Value.ToString, 0)
                i = i + 1
            End While
            objReadTransactions.Close()
            ComputeTotals()
        Else
            MessageBox.Show("This ticket number does not exist", "Invalid Ticket Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        objReader.Close()
        Me.ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On ticket details load"
        ShowErrorMessage()
    End Sub

    Private Sub txtTicketNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTicketNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not String.IsNullOrEmpty(txtTicketNumber.Text) Then
                LoadTicketDetails(CLng(txtTicketNumber.Text))
                Exit Sub
            End If
        End If
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If e.KeyChar = "." Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    'Private Sub txtTicketNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTicketNumber.TextChanged

    'End Sub

    Private Sub txtTicketNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTicketNumber.Validating
        If IsNumeric(txtTicketNumber.Text) Then
            LoadTicketDetails(CLng(txtTicketNumber.Text))
        End If
    End Sub

    Private Sub pdWindows_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdWindows.PrintPage
        'This will send the printing to the windows type

        'Dim prFont As New Font("Arial", 6, FontStyle.Regular)
        'Dim tlFont As New Font("Arial", 6, FontStyle.Bold)
        'Dim HeaderFont As New Font("Arial", 12, FontStyle.Bold)

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

    Private Sub btnDailySales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDailySales.Click
        If UCase(strUserLevel) = UCase("Cashier") Then
            MessageBox.Show("You do not have sufficient rights to perform this action. Contact your supervisor", "Invoking Unauthorized Process", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            Dim f As New frmDailySales
            f.ShowDialog()
        End If
    End Sub


    ' *********************** FISCALIZED RECEIPT PRINT AND MANAGEMENT CODE FOR AXIS SOLUTIONS

    'Private Sub MakeFiscalSell(ByVal ItemsSold As ArrayList)

    '    'Initialing the fiscal printer
    '    lResult = AxisFiscalPrinter.INIT_MY_FP(FiscalSerialPortNumber, FiscalBaudrate, False, False, FiscalPrinterSeriesNumber)
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to init connection with printer: " + Str(lResult))
    '        Exit Sub
    '    End If

    '    'Connecting to the fiscal printer
    '    lResult = AxisFiscalPrinter.CONNECT_TO_PRINTER()                                                 ' ***********connext to printer
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to connect to printer: " + Str(lResult))
    '        Exit Sub
    '    End If

    '    'Open Fiscal Receipt
    '    Dim sRecCnt As String
    '    Dim sGlobRecCnt As String

    '    lResult = AxisFiscalPrinter.CMD_48_0_0("1", "0000", "1", sRecCnt, sGlobRecCnt)
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to open fiscal receipt: " + Str(lResult))
    '    End If

    '    'Print the fiscal receipt
    '    For i As Integer = 0 To ItemsSold.Count - 1
    '        Dim strBuffer() As String = Split(ItemsSold.Item(i), "|")
    '        'arrFiscalReceiptItems.Add(strFiscalItemCode & "|" & strDescription & "|" & strFiscalUnitPrice & "|" & strQuantity & "|" & strFiscalTaxCode)
    '        lResult = AxisFiscalPrinter.CMD_49_0_9(strBuffer(0), strBuffer(1), strBuffer(4), strBuffer(2), strBuffer(3), "-")
    '        If lResult <> 0 Then
    '            MessageBox.Show("Failed to sell item: " + Str(lResult))
    '            Exit For
    '        End If
    '    Next

    '    'Send the totals here
    '    Dim sSubTotal As String
    '    Dim sTaxA As String
    '    Dim sTaxB As String
    '    Dim sTaxC As String
    '    Dim sTaxD As String
    '    Dim sTaxE As String
    '    Dim sTaxF As String

    '    '"-0.01" is = the discount as an absolute value. This should be the default
    '    lResult = AxisFiscalPrinter.CMD_51_0_2("1", "1", "-0.01", sSubTotal, sTaxA, sTaxB, sTaxC, sTaxD, sTaxE, sTaxF)
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to do subtotal: " + Str(lResult))
    '        Exit Sub
    '    End If

    '    'Send the tender amount
    '    Dim sPaidCode As String
    '    Dim sAmount As String

    '    lResult = AxisFiscalPrinter.CMD_53_0_0("P", dblAmountTendered, sPaidCode, sAmount)
    '    'lResult = ciPrinter.CMD_53_0_0("N", "2.00", sPaidCode, sAmount)
    '    'lResult = ciPrinter.CMD_53_0_0("P", "2.00", sPaidCode, sAmount)
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to do total: " + Str(lResult))
    '        Exit Sub
    '    End If

    '    'Close the fiscal receipt

    '    lResult = AxisFiscalPrinter.CMD_56_0_0(sRecCnt, sGlobRecCnt)
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to close fiscal receipt: " + Str(lResult))
    '        Exit Sub
    '    End If

    '    'Close connection
    '    lResult = AxisFiscalPrinter.CLOSE_CONNECTION()
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to close connection with printer: " + Str(lResult))
    '        Exit Sub
    '    End If

    'End Sub

    '' *********** cancel fiscal receipt **************************************** Used only when there is an error

    'Private Sub CancelFiscReceipt()
    '    lResult = AxisFiscalPrinter.CMD_60_0_0()
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to cancel fiscal receipt: " + Str(lResult))
    '        Exit Sub
    '    End If
    'End Sub


    ''**************** PRINTING OF NON-FISCAL RECEIPTS E.G. REPRINTS ***********************

    'Private Sub PrintNonFiscText(ByVal arrReceiptLines As ArrayList)         ' ***********print non fiscal text

    '    'Initialing the fiscal printer
    '    lResult = AxisFiscalPrinter.INIT_MY_FP(FiscalSerialPortNumber, FiscalBaudrate, False, False, FiscalPrinterSeriesNumber)
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to init connection with printer: " + Str(lResult))
    '        Exit Sub
    '    End If

    '    'Connecting to the fiscal printer
    '    lResult = AxisFiscalPrinter.CONNECT_TO_PRINTER()                                                 ' ***********connext to printer
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to connect to printer: " + Str(lResult))
    '        Exit Sub
    '    End If

    '    '***** OPEN NON FISCAL ************
    '    Dim sRecCnt As String
    '    Dim sGlobRecCnt As String

    '    lResult = AxisFiscalPrinter.CMD_48_0_0("1", "0000", "1", sRecCnt, sGlobRecCnt)
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to open fiscal receipt: " + Str(lResult))
    '    End If

    '    '************  START PRINTING THE FISCAL **************************

    '    lResult = AxisFiscalPrinter.CMD_38_0_0(sRecCnt, sGlobRecCnt)
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to open non fiscal receipt: " + Str(lResult))
    '        Exit Sub
    '    End If


    '    For i As Integer = 0 To arrReceiptLines.Count - 1
    '        lResult = AxisFiscalPrinter.CMD_42_0_0(arrReceiptLines.Item(i))
    '    Next
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to print non fiscal text: " + Str(lResult))
    '        Exit Sub
    '    End If

    '    '**** CLOSE NON FISCAL RECEIPT *********************

    '    lResult = AxisFiscalPrinter.CMD_39_0_0(sRecCnt, sGlobRecCnt)
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to close non fiscal receipt: " + Str(lResult))
    '        Exit Sub
    '    End If

    '    '**** CLOSE CONNECTION *****************************

    '    lResult = AxisFiscalPrinter.CLOSE_CONNECTION()
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to close connection with printer: " + Str(lResult))
    '        Exit Sub
    '    End If

    'End Sub

    'Private Sub btnPrintBarcode_Click()
    '    lResult = AxisFiscalPrinter.CMD_84_0_0("2", "123456789012")
    '    If lResult <> 0 Then
    '        MessageBox.Show("Failed to print barcode: " + Str(lResult))
    '        Exit Sub
    '    End If
    'End Sub



    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If boolPrintFromPreview = True Then
            'requery records
            boolAbort = False
            Me.GenerateTransactionDocument(intSelectedTransaction)
            If boolAbort = True Then Exit Sub
            boolPrintFromPreview = False
        End If
        Dim strDType As String
        strDType = "CASH SALE RECEIPT"
        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer
        'Dim xx1 As Integer, xx2 As Integer, yy1 As Integer, yy2 As Integer
        x1 = e.PageBounds.Left + 100
        y1 = e.PageBounds.Top + 100
        p1 = e.PageBounds.Width - 200
        y2 = e.PageBounds.Height - 200

        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        Dim strS As String = Nothing
        Dim Yc As Integer
        Dim cols, lines As Integer

        'Draw the document rectangle
        reccurrent = New Rectangle(x1, y1, p1, y2)
        e.Graphics.DrawRectangle(Pens.Black, reccurrent)

        'Print the watermark here
        Dim g As Graphics = e.Graphics
        g.DrawString(UCase(strDType), New Font("Arial", 16, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, Color.Black)), 350, e.PageBounds.Top + 110)
        'Draw a line after
        y1 = y1 + 40
        e.Graphics.DrawLine(Pens.Black, x1, y1, p1 + 100, y1)

        'print the company logo
        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                Dim intImageYLocation As Integer = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                'R = New Rectangle(100, intImageYLocation, objPicture.Width, objPicture.Height)

                R = New Rectangle(intLogoXposition, intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
            End If
        End If

        y1 = y1 + 15
        'Print the company details at the extreme left of document
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, HeaderFont, Brushes.Black)
        'e.Graphics.DrawString(strDType, HeaderFont, Brushes.Black, 500, e.PageBounds.Top + 120)
        y1 = y1 + 20

        If Not String.IsNullOrEmpty(strCompanyAddress1) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress1, prFont, Brushes.Black)
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.  : " & UCase(strCompanyBPNumber), prFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.  : " & UCase(strCompanyBPNumber), prFont, Brushes.Black)
                y1 = y1 + 15
            End If
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress2) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress2, prFont, Brushes.Black)
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO. : " & UCase(strCompanyVatNumber), prFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO. : " & UCase(strCompanyVatNumber), prFont, Brushes.Black)
            End If
            y1 = y1 + 15
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress3) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress3, prFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyAddress4) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress4, prFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyTelephone) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "PHONE  : " & UCase(strCompanyTelephone), prFont, Brushes.Black)
            y1 = y1 + 15
        End If
        'strCompanyContactCellNumber
        If Not String.IsNullOrEmpty(strCompanyContactCellNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 550, 80, "CELL NO: " & UCase(strCompanyContactCellNumber), prFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyFaxNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "FAX NO.: " & UCase(strCompanyFaxNumber), prFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyEmailAddress) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "E-MAIL : " & strCompanyEmailAddress, prFont, Brushes.Black)
            y1 = y1 + 15
        End If
        y1 = y1 + 5

        'print captions
        x1 = x1 + 10
        x2 = x1 + 50
        X3 = x2 + 140
        X4 = X3 + 100
        X5 = X4 + 100
        X6 = X5 + 100

        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        e.Graphics.DrawString("CUSTOMER DETAILS", prFont, Brushes.Black, x1, y1)
        e.Graphics.DrawString("TRANSACTION DETAILS", prFont, Brushes.Black, 500, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 15
        'e.Graphics.DrawString("VAT No.: " & UCase(strCustomerVatNumber), prFont, Brushes.Black, x1, y1) '& Space(20) & " VAT No.: " & UCase(strCustomerVatNumber)
        y1 = y1 + 15

        If Not String.IsNullOrEmpty(strCustomerName) Then
            If strCustomerName.Length > 58 Then strCustomerName = Mid(strCustomerName, 1, 58)
        End If

        e.Graphics.DrawString(UCase(strCustomerName), prFont, Brushes.Black, x1, y1)
        'e.Graphics.DrawString(strCustomerName, prFont, Brushes.Black, x1, y1)
        'Print the date
        e.Graphics.DrawString("DATE", prFont, Brushes.Black, 500, y1)
        e.Graphics.DrawString(": " & strDate, prFont, Brushes.Black, 580, y1)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "INVOICE NUM", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, ": " & Format(CLng(intSelectedTransaction), "000000"), prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, "", prFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, "", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "ORDER REF.NO.", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, ": " & "0", prFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, "", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "SALES AGENT", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, ": " & UCase(strSalesRep), prFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, "", prFont, Brushes.Black)
        y1 += 15
        'e.Graphics.DrawString("TELEPHONE : " & strCustomerTelephone, prFont, Brushes.Black, x1, y1)
        y1 += 15
        'e.Graphics.DrawString("E-MAIL    :" & strCustomerEmailAddress, prFont, Brushes.Black, x1, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        Dim y1_before_headers As Integer = y1
        y1 = y1 + 12
        'print captions
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 60, 80, "QTY", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 180, 80, "DESCRIPTION", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x2 + 270, y1, 80, 80, "UNIT ", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, (X3 + 110), y1, 120, 80, "SUB TTL", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, (X4 + 80), y1, 120, 80, "TAX", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, (X5 + 50), y1, 120, 80, "DISCOUNT", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, (X6 + 20), y1, 120, 80, "TOTAL", prFont, Brushes.Black)
        'draw a line after
        y1 = y1 + 18
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 18
        itm = 0
        reccurrent = New Rectangle()
        boolExitingWhile = False
        Dim strBuffer() As String
        While itm < strInvoiceDetails.Count
            strBuffer = Split(strInvoiceDetails(itm), "|")
            Dim strUnitPriceBeforeTax As String = "0.00"
            Dim strTaxAmount As String = "0.00"
            Dim strDiscountAmount As String = "0.00"
            Dim strUnitPrice As String = "0.00"
            Dim strPayableAfterTax As String = "0.00"
            Dim strPrintQuantity As String = "0"
            Dim strPrintPrice As String = "0.00"

            Dim strItemCodeNumber As String = strBuffer(1)

            Dim strInventoryMeasure As String = gwt_comm.InventoryMeasurement(strItemCodeNumber)
            Dim strMeasureShortName As String = Nothing
            If Not String.IsNullOrEmpty(strInventoryMeasure) Then
                strMeasureShortName = gwt_comm.MeasurementShortName(strInventoryMeasure)
            End If

            'Quantity
            If Not strBuffer(0) Is Nothing Then strvalue = strBuffer(0) Else strvalue = "0"
            strPrintQuantity = strvalue
            'Unit Price
            If Not strBuffer(3) Is Nothing Then strvalue = CStr(Format(CDbl(strBuffer(3)), "#,##0.00")) Else strvalue = "0.00"
            strUnitPrice = strvalue
            'Discount
            If Not strBuffer(4) Is Nothing Then strvalue = CStr(Format(CDbl(strBuffer(4)), "#,##0.00")) Else strvalue = "0.00"
            strDiscountAmount = strvalue
            'Tax Amount
            If Not strBuffer(5) Is Nothing Then strvalue = CStr(Format(CDbl(strBuffer(5)), "#,##0.00")) Else strvalue = "0.00"
            strTaxAmount = strvalue
            If UCase(strTaxComputationType) = UCase("INCLUSIVE") Then
                strPrintPrice = Format(((CDbl((strUnitPrice) * CDbl(strPrintQuantity)) - CDbl(strTaxAmount)) / CDbl(strPrintQuantity)), "#,##0.00")
            Else
                strPrintPrice = Format(CDbl(strUnitPrice), "#,##.00")
            End If

            If IsNumeric(strPrintPrice) Then
                If CDbl(strPrintPrice) = 0 Then
                    strPrintQuantity = ""
                End If
            End If

            'QUANTITY PRINTING
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 50, 60, strPrintQuantity & strMeasureShortName, prFont, Brushes.Black)
            'UNIT PRICE PRINTING
            If IsNumeric(strPrintQuantity) Then
                Call gwt_comm.DrawStringInBoxRight(e, (X3 + 110), y1, 120, 80, Format(((CDbl(strUnitPrice) * CDbl(strPrintQuantity)) - 0), "#,##0.00"), prFont, Brushes.Black)
                ' Call gwt_comm.DrawStringInBoxRight(e, (X3 + 110), y1, 120, 80, Format(((CDbl(strUnitPrice) * CDbl(strPrintQuantity)) - CDbl(strTaxAmount)), "#,##0.00"), tlFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxRight(e, (X3 + 110), y1, 120, 80, "", prFont, Brushes.Black)
            End If

            'TAX PRINTING
            If IsNumeric(strPrintQuantity) Then
                Call gwt_comm.DrawStringInBoxRight(e, (X4 + 80), y1, 120, 80, strTaxAmount, prFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxRight(e, (X4 + 80), y1, 120, 80, "", prFont, Brushes.Black)
            End If

            'DISCOUNT PRINTING
            If IsNumeric(strPrintQuantity) Then
                Call gwt_comm.DrawStringInBoxRight(e, (X5 + 50), y1, 120, 80, strDiscountAmount, prFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxRight(e, (X5 + 50), y1, 120, 80, "", prFont, Brushes.Black)
            End If

            'Total payable
            If UCase(strTaxComputationType) = UCase("INCLUSIVE") Then
                If IsNumeric(strPrintQuantity) Then
                    strPayableAfterTax = Format(((CDbl(strPrintQuantity) * CDbl(strUnitPrice)) - CDbl(strDiscountAmount)) - 0, "#,##0.00")
                Else
                    strPayableAfterTax = ""
                End If
            Else
                If IsNumeric(strPrintQuantity) Then
                    strPayableAfterTax = Format(((CDbl(strPrintQuantity) * CDbl(strUnitPrice)) - CDbl(strDiscountAmount)) + CDbl(strTaxAmount), "#,##0.00")
                Else
                    strPayableAfterTax = ""
                End If
            End If

            'LINE TOTAL PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, (X6 + 20), y1, 120, 80, strPayableAfterTax, prFont, Brushes.Black)

            'If Not strBuffer(6) Is Nothing Then strvalue = CStr(Format(CDbl(strBuffer(6)), "#,##0.00")) Else strvalue = "0.00"

            'Print the description last as it is the column that will determine the next line position
            If IsNumeric(strPrintPrice) Then
                If CDbl(strPrintPrice) = 0 Then
                    strvalue = strBuffer(2)
                Else
                    If Not strBuffer(2) Is Nothing Then strvalue = strBuffer(2) Else strvalue = ""
                End If
            Else
                If Not strBuffer(2) Is Nothing Then strvalue = strBuffer(2) Else strvalue = ""
            End If
            Call gwt_comm.DrawStringInBoxLeft(e, (x2 - 10), y1, 330, 80, strvalue, prFont, Brushes.Black)

            'Print the unit price
            Call gwt_comm.DrawStringInBoxRight(e, (x2 + 225), y1, 80, 80, strPrintPrice, prFont, Brushes.Black)

            'Get the size of the description box
            e.Graphics.MeasureString(strvalue, prFont, New SizeF(330, 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * prFont.Height + 5
            y1 = Math.Max(y1, Yc)
            'y1 = y1 + 20
            itm = itm + 1 : i = 0
            If itm = 23 Then
                'Print the page number of the statement
                Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, prFont, Brushes.Black)
                'print the compny bank details
                Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 80, 600, 80, "OUR BANK DETAILS : " & UCase(strCompanyBankName) & " - ACCOUNT NO : " & UCase(strCompanyAccountNumber) & " BANK CODE : " & UCase(strCompanyBranchCode), prFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", prFont, Brushes.Black)
                e.HasMorePages = True
                boolExitingWhile = True
                intPage += 1
                Exit While
            End If
        End While

        'print totals
        'draw a line
        If boolExitingWhile = False Then
            y1 = y1 + 30
            e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
            Dim y1_after_headers As Integer = y1
            y1 = y1 + 30
            Dim y1_before As Integer = y1
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1, X5 + 250, y1)
            Call gwt_comm.DrawStringInBoxLeft(e, (X5 + 55), y1 + 3, 120, 80, "GROSS TOTAL", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, (y1 + 3), 120, 80, Format(((dblInvoiceTotal - dblTaxes) + dblDiscounts), "#,##0.00"), prFont, Brushes.Black)
            y1 = y1 + 20
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1, X5 + 250, y1)
            Call gwt_comm.DrawStringInBoxLeft(e, (X5 + 55), y1 + 3, 120, 80, "LESS DISCOUNTS", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, (y1 + 3), 120, 80, Format(dblDiscounts, "#,##0.00"), prFont, Brushes.Black)
            y1 = y1 + 20
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1, X5 + 250, y1)
            Call gwt_comm.DrawStringInBoxLeft(e, (X5 + 55), y1 + 3, 120, 80, "SUB TOTAL", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, (y1 + 3), 120, 80, Format((dblInvoiceTotal - dblTaxes), "#,##0.00"), prFont, Brushes.Black)
            y1 = y1 + 20
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1, X5 + 250, y1)
            Call gwt_comm.DrawStringInBoxLeft(e, (X5 + 55), y1 + 3, 120, 80, "ADD TAXES", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, (y1 + 3), 120, 80, Format(dblTaxes, "#,##0.00"), prFont, Brushes.Black)
            y1 = y1 + 20
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1, X5 + 250, y1)
            Call gwt_comm.DrawStringInBoxLeft(e, (X5 + 55), y1 + 3, 120, 80, "NET PAYABLE", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, (y1 + 3), 120, 80, Format(dblInvoiceTotal, "#,##0.00"), prFont, Brushes.Black)
            y1 = y1 + 20
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1, X5 + 250, y1)
            Dim y1_after As Integer = y1
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1_before, X5 + 50, y1_after)
            e.Graphics.DrawLine(Pens.Black, X5 + 150, y1_before, X5 + 150, y1_after)
            y1 = y1 + 15
            'Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 120, 80, "TOTALS ", prFont, Brushes.Black)
            'Call gwt_comm.DrawStringInBoxRight(e, X3, y1, 120, 80, Format(dblUnitPriceTotals, "#,##0.00"), prFont, Brushes.Black)


            'draw the drop down lines
            e.Graphics.DrawLine(Pens.Black, x1 + 35, y1_before_headers, x1 + 35, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, x2 + 310, y1_before_headers, x2 + 310, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, x2 + 250, y1_before_headers, x2 + 250, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, 540, y1_before_headers, 540, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, 610, y1_before_headers, 610, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, 680, y1_before_headers, 680, y1_after_headers)

            'Print the receiver information
            Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 150, 220, 80, "ACCEPTED BY ....................................... ", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x1 + 210, e.PageBounds.Bottom - 150, 200, 80, "SIGNATURE ..................................... ", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x1 + 420, e.PageBounds.Bottom - 150, 200, 80, "DATE ...................................... ", prFont, Brushes.Black)

            'Print the banking details
            Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, prFont, Brushes.Black)
            'Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 80, 600, 80, "OUR BANK DETAILS : " & UCase(strCompanyBankName) & " ACCOUNT NO : " & UCase(strCompanyAccountNumber) & " BANK CODE : " & UCase(strCompanyBranchCode), tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", prFont, Brushes.Black)
            ' ''Print the terms and conditions

            y1 += 100
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 300, 80, "TERMS AND CONDITIONS ", tlFont, Brushes.Black)
            y1 += 20
            For np As Integer = 0 To arrConditionsOfSale.Count - 1
                Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 550, 80, arrConditionsOfSale.Item(np), prFont, Brushes.Black)
                y1 = y1 + 15
            Next

            e.HasMorePages = False
            Me.boolPrintFromPreview = True

        End If
    End Sub

    Private Sub GenerateTransactionDocument(ByVal intDocumentNumber As Integer)
        'get invoice number
        On Error GoTo RaiseErr
        Dim n As Integer = 0
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim strCustomerNumber As String = Nothing

        myCommand = New Data.OleDb.OleDbCommand("Select CONVERT(NVARCHAR, TransDate, 105) as [TransDate], Amount, Taxes, " _
            & "Discount, CustomerId, SalesRep FROM SalesMain Where InvoiceNumber = " & intDocumentNumber & "", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            Dim strDateparts() As String = Split(dbReader(0).ToString, "-")
            If Not IsDBNull(dbReader(0).ToString) Then strDate = CDate(strDateparts(0) & "-" & MonthName(CInt(strDateparts(1)), True) & "-" & strDateparts(2))
            If IsNumeric(dbReader(1).ToString) Then dblInvoiceTotal = CDbl(dbReader(1).ToString) Else dblInvoiceTotal = 0
            If IsNumeric(dbReader(2).ToString) Then dblTaxes = dbReader(2).ToString Else dblTaxes = 0
            If IsNumeric(dbReader(3).ToString) Then dblDiscounts = dbReader(3).ToString Else dblDiscounts = 0
            'If Not IsDBNull(dbReader(4).ToString) Then strCustomerNumber = dbReader(4).ToString
            If Not IsDBNull(dbReader("SalesRep").ToString) Then strSalesRep = dbReader("SalesRep").ToString
        End If
        dbReader.Close()

        myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity, ItemCode, Description +' * '+ CONVERT(NVARCHAR, SerialNumbers) as [Description], SalesPrice, " _
            & "DiscountAllowed, Taxes, (((SalesPrice * Quantity) - DiscountAllowed) + Taxes) AS [Payable] " _
            & "from Sales where InvoiceNumber = " & intDocumentNumber & "", cnn)
        dbReader = myCommand.ExecuteReader
        strInvoiceDetails = New ArrayList
        While dbReader.Read
            Dim strLine As String = Nothing
            For n = 0 To dbReader.FieldCount - 1
                If n = 0 Then
                    strLine = dbReader(n).ToString & "|"
                Else
                    strLine = strLine & dbReader(n).ToString & "|"
                End If
            Next
            strInvoiceDetails.Add(strLine)
        End While
        dbReader.Close()

        boolPrintFromPreview = False

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Cash receipt Generation Error"
        ShowErrorMessage()
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

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strPublicBranchAddress1))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strPublicBranchAddress1))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strPublicBranchAddress2))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strPublicBranchAddress2))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strPublicBranchAddress3))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strPublicBranchAddress3))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strPublicBranchAddress4))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strPublicBranchAddress4))

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

    Private Sub btnQuotation_Click(sender As System.Object, e As System.EventArgs) Handles btnQuotation.Click
        On Error GoTo RaiseErr

        boolAbort = False
        Dim frm As New frmInvoiceCustomerDetails
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        Dim strPersonnel As String = strUserName

        If dGrid.Rows.Count <= 0 Then
            MessageBox.Show("No document transactions to print !!!", "Empty Document Transactions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(cboPersonnel.Text) Then
            strPersonnel = UCase(cboPersonnel.Text)
            'MessageBox.Show("Please select the name of the sales representative from the list provided", "Missing Sales Agent Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'cboPersonnel.Focus()
            'Exit Sub
        End If
        'Perform the till ring routine
        boolAbort = False
        dblSaleTotal = CDbl(lblPayable.Text)

        If dblSaleTotal <= 0 Then
            MessageBox.Show("Sale cannot be processed when there are no valid sub total values", "Sale Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        strCustomerTelephoneNumber = Nothing
        strTillCustomerName = Nothing

        Cursor = Cursors.WaitCursor

        'arrInvoiceData = New ArrayList

        'For i = 0 To dGrid.Rows.Count - 1

        '    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then

        '        Dim strSelectedId As String = Nothing
        '        Dim strDescription As String = Nothing
        '        Dim intQty As Double = 0
        '        Dim dblTax As Double = 0
        '        Dim dblUprice As Double = 0
        '        Dim dblDisAmount As Double = 0
        '        Dim strItemSerialNo As String = Nothing
        '        Dim strLineItemType As String = Nothing

        '        strSelectedId = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
        '        strDescription = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
        '        intQty = Convert.ToDouble(dGrid.Rows(i).Cells(4).Value)
        '        dblTax = Convert.ToDouble(dGrid.Rows(i).Cells(7).Value)
        '        dblUprice = Convert.ToDouble(dGrid.Rows(i).Cells(3).Value)
        '        dblDisAmount = Convert.ToDouble(dGrid.Rows(i).Cells(6).Value)
        '        If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
        '            strItemSerialNo = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
        '        End If
        '        If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(9).Value), "")) Then
        '            strLineItemType = Convert.ToString(dGrid.Rows(i).Cells(9).Value)
        '        End If

        '        arrInvoiceData.Add(strSelectedId & "|" & strDescription & "|" & intQty & "|" & Format(dblUprice, "##0.00") & _
        '            "|" & Format((dblUprice * intQty), "##0.00") & "|" & Format(dblDisAmount, "##0.00") & "|" & Format(dblTax, "##0.00") & _
        '            "|" & Format(((dblUprice * intQty) - dblDisAmount) + dblTax, "##0.00"))

        '    End If

        'Next i

        Print_Quotation(Format(Now, "dd-MMM-yyyy"))
        'PrintReceiptQuote("QUOTATION")

        Me.lblPayable.Text = "0.00"
        Me.lblSubTotal.Text = "0.00"
        Me.lblDiscounts.Text = "0.00"
        Me.lblTaxes.Text = "0.00"
        Me.lblTaxable.Text = "0.00"
        'Clear the controls
        dGrid.Rows.Clear()
        dGrid.Rows.Add(350)
        If strPublicMaintainTransactionDate = "NO" Then cboPersonnel.Text = ""
        txtReference.Text = ""
        txtKeyNumber.Text = ""
        txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))
        dblAmountChange = 0
        dblAmountTendered = 0
        boolDeliverySale = False
        chkDeliverySale.Checked = False
        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Quotation Generation Error"
        ShowErrorMessage()
    End Sub


    Private Sub Print_Quotation(ByVal dtReceiptDate As Date)
        On Error GoTo RaiseErr
        strType = UCase("QUOTATION")
        strSelectedReport = Me.txtReference.Text

        Dim arrFiscalReceiptItems As New ArrayList

        arrPrintDetails = New ArrayList
        '
        'ADD THE BRANCH INFORMATION
        '
        arrPrintDetails.Add(Space(2) & UCase(strCompanyName))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchName))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress1))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress2))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress3))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress4))
        arrPrintDetails.Add(Space(2) & "PHONE: " & strPublicBranchTelephone)
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

        arrPrintDetails.Add(Space(12) & strFlyQuoteName)
        arrPrintDetails.Add(Space(12) & strFlyQuoteAddress1)
        arrPrintDetails.Add(Space(12) & strFlyQuoteAddress2)
        arrPrintDetails.Add(Space(12) & strFlyQuoteAddress3)
        arrPrintDetails.Add(Space(12) & strFlyQuoteAddress4)

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))

        Dim dblVatTax As Double = 0

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
                    arrPrintDetails.Add(Space(4) & Space(5 - strQuantity.Length) & strQuantity & " @ " & Space(8 - strUnitPrice.Length) & strUnitPrice & Space(4) & Space(8 - strLineTotal.Length) & strLineTotal)
                    dblVatTax = dblVatTax + Convert.ToDouble(.Rows(i).Cells(7).Value)

                    If UCase(strPublicTaxFiscalStatus) = "YES" Then
                        Dim strFiscalUnitPrice As String = Format(CDbl(.Rows(i).Cells(3).Value.ToString), "###0.00")
                        Dim strFiscalItemCode As String = .Rows(i).Cells(0).Value.ToString
                        Dim strFiscalTaxCode As String = "A"
                        'Get the item taxcode
                        Dim objGetItemTaxCode As New Data.OleDb.OleDbCommand("SELECT TaxCode FROM InventoryItems WHERE ItemCode = '" & strFiscalItemCode & "'", cnn)
                        Dim objReadTaxCode As Data.OleDb.OleDbDataReader = objGetItemTaxCode.ExecuteReader
                        If objReadTaxCode.HasRows Then
                            objReadTaxCode.Read()
                            If Not IsDBNull(objReadTaxCode(0).ToString) Then strFiscalTaxCode = objReadTaxCode(0).ToString
                        End If
                        objReadTaxCode.Close()
                        arrFiscalReceiptItems.Add(strFiscalItemCode & "|" & strDescription & "|" & strFiscalUnitPrice & "|" & strQuantity & "|" & strFiscalTaxCode)
                    End If

                End If
            Next
        End With


        'Add the dash line
        Dim strTaxCharged As String = Format(dblVatTax, "##0.00")

        Dim strTender As String = Format(dblAmountTendered, "##0.00")
        Dim strChange As String = Format(dblAmountChange, "##0.00")

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "TOTAL INCL. VAT " & Space(14 - lblPayable.Text.Length) & lblPayable.Text)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "VAT CHARGED     " & Space(14 - strTaxCharged.Length) & strTaxCharged)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        'arrPrintDetails.Add(Space(2) & "AMOUNT TENDERED " & Space(14 - strTender.Length) & strTender)
        'arrPrintDetails.Add(Space(2) & "CHANGE          " & Space(14 - strChange.Length) & strChange)

        Dim strZimDate As String = Format(Now, "dd-MMM-yyyy")

        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(2) & "TILL OPER :" & UCase(strUserName) & Space(3))
        arrPrintDetails.Add(Space(2) & "SALES REP :")
        If cboItems.Text.Length > 30 Then
            arrPrintDetails.Add(Space(2) & UCase(Mid(cboPersonnel.Text, 1, 30)))
        Else
            arrPrintDetails.Add(Space(2) & UCase(cboPersonnel.Text))
        End If

        arrPrintDetails.Add(Space(1) & "DATE AND TIME " & strZimDate & " " & DatePart(DateInterval.Hour, Now) & ":" & DatePart(DateInterval.Minute, Now))
        arrPrintDetails.Add(Space(2) & UCase(strReceiptHeader) & " DATE  " & Format(dtReceiptDate, "dd-MMM-yyyy"))
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
        Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\Quotations", True)
        For x As Double = 0 To arrPrintDetails.Count - 1
            objFileWriter.WriteLine(arrPrintDetails.Item(x))
        Next
        objFileWriter.Close()
        '
        'PRINTS FROM A FILE DIRECTLY TO THE PRINTER
        '
        'Try printing using the line printer
        ' Allow the user to select a file.
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
                Dim ppd As New PrintPreviewDialog
                ppd.Document = pdWindowsQuote
                pdWindowsQuote.Print()
            End If
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Quote Transaction Processing"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub pdWindowsQuote_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdWindowsQuote.PrintPage
        'This will send the printing to the windows type

        'Dim prFont As New Font("Arial", 6, FontStyle.Regular)
        'Dim tlFont As New Font("Arial", 6, FontStyle.Bold)
        'Dim HeaderFont As New Font("Arial", 12, FontStyle.Bold)

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