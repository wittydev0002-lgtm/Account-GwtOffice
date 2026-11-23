Imports System.Drawing.Printing
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPermitInvoicing

    Dim mybitMap As Bitmap

    Dim strSelectedReport As String
    Dim prFont As New Font("Arial", 6, FontStyle.Bold)
    Dim tlFont As New Font("Arial", 6, FontStyle.Regular)
    Dim HeaderFont As New Font("Arial", 10, FontStyle.Bold)
    Dim strType As String
    Dim arrPrintDetails As ArrayList
    Dim boolCloseButton As Boolean

    Dim myGR As Graphics
    Dim strFileName As String = Nothing

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

    Dim strCustomerName As String
    Dim strCustomerAddress As String
    Dim strCustomerTelephone As String
    Dim strCustomerFaxNumber As String
    Dim strCustomerVatNumber As String
    Dim strCustomerEmailAddress As String
    Dim strSalesRep As String

    Dim boolExitingWhile As Boolean = False
    Dim intPage As Single = 1
    Dim intPageTotals As Double = 1

    Dim strItemType As String = Nothing

    Dim strCustomerAddress1 As String
    Dim strCustomerAddress2 As String
    Dim strCustomerAddress3 As String
    Dim strCustomerAddress4 As String

    Public myfntDetailsFontBold As New System.Drawing.Font("Arial", 18, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
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

    Private Sub frmInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        cboSupplierName.Enabled = True
        cboItems.Visible = False
        dGrid.Rows.Add(350)
        AlternateColors()
        LoadData()
        'LoadEmployees()
        LoadCustomers()
        txtComments.Text = CommonLibrary.Commons.strPublicTermsAndConditions

        If boolLoadedFromCustomerForm = True Then
            btnAddNew.Enabled = ButtonEnabled.False
            btnFindAccount.Enabled = ButtonEnabled.False
            objCommand = New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM Customers WHERE " _
            & "AccountNumber = '" & strSelectedAccount & "'", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then txtAccountNumber.Text = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then cboSupplierName.Text = objReader(1).ToString
                cboSupplierName.Enabled = False
            End If
            objReader.Close()
        End If
        If boolEditStatusTwo = True Then
            chkOverrideNo.Enabled = False
            LoadSelectedInvoiceData()
            btnPrint.Enabled = ButtonEnabled.True
            'btnSaveNew.Enabled = False
            txtReference.Text = intSelectedTransaction
        Else
            btnPrint.Enabled = ButtonEnabled.False
            chkOverrideNo.Enabled = True
            Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("PermitInvoices"))
        End If
        cboItems.Visible = False

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmInvoice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F3 Then
            FinishSale()
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT ItemCode +';'+GroupName +';'+ CONVERT(NVARCHAR, " _
            & "CAST(SellingPrice AS DECIMAL (10,2))) +';'+ TaxStatus AS " _
            & "[Items] FROM InventoryItems WHERE Status = 'ACTIVE' ORDER BY ItemCode"
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
            .ColumnWidth = "160;180;60;60"
        End With
        'Get a count of the items
        Dim intItemsCount As Double = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Status = 'ACTIVE'", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount + 1) As MTGCComboBoxItem

        cboItems.Items.Clear()
        Dim i As Double = 0
        Dim p As Double = 0

        'Add extra 1st lines for comment
        DropDownItems(p) = New MTGCComboBoxItem("--- COMMENT ---", "", "0.00", "NO")
        p += 1
        DropDownItems(p) = New MTGCComboBoxItem("--- SERVICE ---", "", "0.00", "NO")
        p += 1
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2), strRecordText(3))
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
        If e.RowIndex < 0 Then Exit Sub
        If cboItems.Visible = True Then cboItems.Visible = False
        If e.ColumnIndex = 0 Then
            LoadData()
            cboItems.Size = dGrid.CurrentCell.Size
            cboItems.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top
            cboItems.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left
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
                    .Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top
                    .Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left
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

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr
        If cboItems.Focused = False Then Exit Sub
        Dim objCommand As Data.OleDb.OleDbCommand
        For z As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.CurrentRow.Cells(z).Value = Nothing
        Next
        Dim boolItemTaxable As Boolean = True
        RecalculateAmount()
        If Not cboItems.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(0).Value = cboItems.SelectedItem.Col1
            dGrid.CurrentRow.Cells(1).Value = cboItems.SelectedItem.Col2
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
            Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
            Dim dblDiscounts() As Double = gwt_comm.ItemOnSpecials(strCodeSelected, dblSalePrice)
            dGrid.CurrentRow.Cells(6).Value = CStr(Format((dblDiscounts(1) * CDbl(dGrid.CurrentRow.Cells(4).Value.ToString)), "##0.00"))

            ComputeValues(CDbl(dGrid.CurrentRow.Cells(3).Value.ToString), CDbl(dGrid.CurrentRow.Cells(4).Value.ToString), _
                dGrid.CurrentRow.Index, CDbl(dGrid.CurrentRow.Cells(6).Value.ToString), CommonLibrary.Commons.dblSalesTaxRate, boolItemTaxable)
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
            If UCase(CommonLibrary.Commons.strTaxComputationType) = "INCLUSIVE" Then
                dblTaxes = ((dblUnitPrice * intQuantity) - dblDiscount) - (((dblUnitPrice * intQuantity) - dblDiscount) * (100 / (100 + dblTaxRate)))
            Else
                dblTaxes = (dblSubTotal - dblDiscount) * (dblTaxRate / 100) 'dblTaxRate
            End If
        Else
            dblTaxes = 0
        End If

        If UCase(CommonLibrary.Commons.strTaxComputationType) = "EXCLUSIVE" Then
            dblPayable = (dblSubTotal - dblDiscount) + dblTaxes
        Else
            dblPayable = (dblSubTotal - dblDiscount)
        End If

        dGrid.Rows(intRowIndex).Cells(7).Value = Format(dblTaxes, "##0.00")
        dGrid.Rows(intRowIndex).Cells(8).Value = Format(dblPayable, "##0.00")

        RecalculateAmount()
        ComputeTotals()

    End Sub


    Private Sub cboItems_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.Validated
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(cboItems.Text) Then Exit Sub
        If UCase(cboItems.Text) = "--- COMMENT ---" Or UCase(cboItems.Text) = "--- SERVICE ---" Then
            Exit Sub
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM InventoryItems WHERE ItemCode = '" & cboItems.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows = False Then
            dGrid.CurrentRow.Cells(0).Value = Nothing
            dGrid.CurrentRow.Cells(1).Value = Nothing
            dGrid.CurrentRow.Cells(3).Value = Nothing
            dGrid.CurrentRow.Cells(4).Value = Nothing
            dGrid.CurrentRow.Cells(5).Value = Nothing
            dGrid.CurrentRow.Cells(6).Value = Nothing
            dGrid.CurrentRow.Cells(7).Value = Nothing
            dGrid.CurrentRow.Cells(8).Value = Nothing
        Else
            'Get the item type
            objReader.Read()
            If Not IsDBNull(objReader("InventoryType").ToString) Then dGrid.CurrentRow.Cells(9).Value = objReader("InventoryType").ToString
            'Load the serial numbers
            objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumber FROM SerialNumbers WHERE ItemCode = '" & cboItems.Text & "'", cnn)
            Dim objReadSerial As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            objCommand = New Data.OleDb.OleDbCommand("SELECT Category, SellingPrice FROM InventoryItems WHERE ItemCode = '" & cboItems.Text & "'", cnn)
            Dim objReadCategory As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadCategory.HasRows Then
                objReadCategory.Read()
                Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
                If Not IsDBNull(objReadCategory(0).ToString) Then
                    If UCase(objReadCategory(0).ToString) = "CELLPHONES" Then
                        If CDbl(objReadCategory(1).ToString) >= 100 And CDbl(objReadCategory(1).ToString) < 600 Then
                            dGrid.CurrentRow.Cells(6).Value = gwt_comm.RoundDown(objReadCategory(1) * 0.05)
                        End If
                        If CDbl(objReadCategory(1).ToString) >= 600 Then
                            dGrid.CurrentRow.Cells(6).Value = gwt_comm.RoundDown(objReadCategory(1) * 0.1)
                        End If
                    End If
                End If
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Sales Entry"
        ShowErrorMessage()
    End Sub

    Private Sub btnRemoveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveItem.Click
        If dGrid.Rows.Count > 0 Then
            dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
            RecalculateAmount()
            ComputeTotals()
        End If
    End Sub

    Private Sub btnSaveClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveClose.Click
        If String.IsNullOrEmpty(CommonLibrary.Commons.strPublicSalesAccount) Then
            MessageBox.Show("Missing the default sales ledger control account. Please set it up. For now the default will be used", _
                "Missing Sales Control Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CommonLibrary.Commons.strPublicSalesAccount = "0000"
        End If
        If String.IsNullOrEmpty(cboSupplierName.Text) Or _
            String.IsNullOrEmpty(txtAccountNumber.Text) Then
            MessageBox.Show("Missing the account number", "Missing Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNumber.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblFlightDetails.Text) Then
            MessageBox.Show("Please enter the flight details", "Missing Flight Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnFlightDetails.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboPermitType.Text) Then cboPermitType.Text = "Other"

        boolAbort = False
        FinishSale()
        If boolAbort = True Then Exit Sub

        'Dim ppd As New PrintPreviewDialog
        'ppd.Document = pdAirInvoice
        'ppd.ShowDialog()

        'If boolEditStatus = False Then
        ''boolAbort = False
        ''Dim f As New frmPrintCopies
        ''f.ShowDialog()
        ''If boolAbort = False Then
        ''    For i As Integer = 0 To intNumberOfPrintCopies - 1
        ''        'If strPublicPrinterType = "RAW" Then
        ''        '    PrintRawData()
        ''        'Else
        ''        PrintInvoice(Format(dpTransDate.Value, "dd-MMM-yyyy"))
        ''        'End If
        ''    Next
        ''Else
        ''    MessageBox.Show("Transaction Prcessed but not printed", "Invoice Generation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''End If
        'End If
        PrintCustomInvoice()

        If CommonLibrary.Commons.strPublicSalesAccount = "0000" Then CommonLibrary.Commons.strPublicSalesAccount = Nothing
        InitializeControls()
        Me.Close()
    End Sub

    Private Sub FinishSale()

        Dim strSelectedId As String
        Dim strDescription As String
        Dim intQty As Double
        Dim dblUprice As Double
        Dim insertCustomer As String
        Dim dblTax As Double
        Dim i As Double
        Dim dpProcessDate As Date = Format(dpTransDate.Value, "dd-MMM-yyyy")
        Dim dblDisAmount As Double 'for discounts
        Dim dblSumTaxes As Double = 0, dblSumDiscounts As Double = 0, dblSumPayable As Double = 0
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim dbReader As Data.OleDb.OleDbDataReader

        Dim gwt_comm As CommonLibrary.Commons.CommonFunctions

        If dGrid.Rows.Count <= 0 Then
            MessageBox.Show("No document transactions to print", "Empty Document Transactions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            boolAbort = True
            Exit Sub
        End If

        dblSaleTotal = CDbl(lblPayable.Text)

        'If dblSaleTotal <= 0 Then
        '    MessageBox.Show("Sale cannot be processed when there are no valid sub total values", MsgBoxStyle.Critical, "Sale Aborted")
        '    Exit Sub
        'End If

        ' ''Dim f As New frmTenderAmount
        ' ''f.ShowDialog()
        If boolAbort = True Then Exit Sub

        'Perform the till ring routine
        boolAbort = False

        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If boolEditStatusTwo = True Then
            'Reverse the items back to the stores First and then delete invoice data

            'Get the original sales data
            Dim strSql As String = "SELECT [InvoiceNumber],[CustomerId],[ItemCode],[Description],[Quantity]," _
                & "[DiscountAllowed],[Taxes],[TransType],[SalesPrice],[TransDate],[ProductType],[SerialNumbers]," _
                & "[OriginalInvoice],[SalesRep],[UserName] FROM CustomerPermitSales WHERE InvoiceNumber = " & intSelectedTransaction & ""
            Dim objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommandReverse.ExecuteReader
            While objReader.Read
                'Add the items back to the inventory
                If Not String.IsNullOrEmpty(objReader("SerialNumbers").ToString) Then
                    Dim lngComma As Long = InStr(1, objReader("SerialNumbers").ToString, ",", 1)
                    If lngComma > 0 Then
                        Dim strSeries() As String = Split(objReader("SerialNumbers").ToString, ",")
                        For n As Double = 0 To strSeries.Length - 1
                            If Not String.IsNullOrEmpty(strSeries(n)) Then
                                strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber) VALUES ('" & strSeries(n) & "', " _
                                    & "'" & objReader("SerialNumbers").ToString & "')"
                                objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
                                objCommandReverse.ExecuteNonQuery()
                            End If
                        Next
                    Else
                        strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber) VALUES ('" & objReader("ItemCode").ToString & "', " _
                            & "'" & objReader("SerialNumbers").ToString & "')"
                        objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommandReverse.ExecuteNonQuery()
                    End If
                End If
                'Update the inventory table
                strSql = "UPDATE InventoryItems SET InventoryItems.Quantity = (InventoryItems.Quantity + " & CDbl(objReader("Quantity").ToString) & ") " _
                    & "WHERE ItemCode = '" & objReader("ItemCode").ToString & "'"
                objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommandReverse.ExecuteNonQuery()
            End While

            Dim objDeleteInvoice As New Data.OleDb.OleDbCommand("DELETE FROM CustomerPermitSales WHERE InvoiceNumber = " & intSelectedTransaction & "", cnn)
            objDeleteInvoice.ExecuteNonQuery()
            objDeleteInvoice = New Data.OleDb.OleDbCommand("DELETE FROM CustomerPermitSalesMain WHERE InvoiceNumber = " & intSelectedTransaction & "", cnn)
            objDeleteInvoice.ExecuteNonQuery()
            txtReference.Text = intSelectedTransaction
        Else
            gwt_comm = New CommonLibrary.Commons.CommonFunctions
            If chkOverrideNo.Checked = False Then txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("PermitInvoices"))
        End If

        dpProcessDate = Format(dpTransDate.Value, "dd-MMM-yyyy")

        If chkOverideDate.Checked = True Then
            dpProcessDate = Format(dpTransDate.Value, "dd-MMM-yyyy")
        End If

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
                Dim objGetBasebarcode As New Data.OleDb.OleDbCommand("SELECT [BarCodeNo] FROM SerialNumbers WHERE " _
                    & "ItemCode = '" & strSelectedId & "' AND SerialNumber = '" & strItemSerialNo & "'", cnn)
                Dim objReadBasebarcode As Data.OleDb.OleDbDataReader = objGetBasebarcode.ExecuteReader
                If objReadBasebarcode.HasRows Then
                    objReadBasebarcode.Read()
                    If Not IsDBNull(objReadBasebarcode(0).ToString) Then strBaseBarCode = objReadBasebarcode(0).ToString
                End If
                objReadBasebarcode.Close()

                insertCustomer = "INSERT INTO CustomerPermitSales (CustomerId, InvoiceNumber, TransDate, ItemCode, Quantity, " _
                    & "SalesPrice, TransType, Description, Taxes, DiscountAllowed, ProductType, SerialNumbers, UserName, " _
                    & "SalesRep, OrderNumber, CostPrice, BaseBarcode, ProjectNumber, EntryType, ContactNumber, ContactName) VALUES " _
                    & "('" & txtAccountNumber.Text & "', " & CDbl(txtReference.Text) & ", '" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " _
                    & "'" & strSelectedId & "', " & intQty & ", " & dblUprice & ", '" & cboPermitType.Text & "', " _
                    & "'" & strDescription & "', " & dblTax & ", " & dblDisAmount & ", " _
                    & "'" & strLineItemType & "', '" & strItemSerialNo & "', '" & strUserName & "', ' ', " _
                    & "' ', " & dblItemCostPrice & ", '" & strBaseBarCode & "', 0, 'SERVICE', '', '')"
                myCommand = New Data.OleDb.OleDbCommand(insertCustomer, cnn)
                myCommand.ExecuteNonQuery()

                dblSumTaxes = dblSumTaxes + dblTax
                dblSumDiscounts = dblSumDiscounts + dblDisAmount


                'Update the products table

                myCommand = New Data.OleDb.OleDbCommand("SELECT Offering FROM InventoryItems WHERE ItemCode = '" & strSelectedId & "'", cnn)
                Dim objReadInventoryType As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
                If objReadInventoryType.HasRows Then
                    objReadInventoryType.Read()
                    If Not IsDBNull(objReadInventoryType(0).ToString) Then
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
                            intStockBalance = intStockBalance - intQty
                            myCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = " & intStockBalance & " " _
                                & "WHERE ItemCode = '" & strSelectedId & "'", cnn)
                            myCommand.ExecuteNonQuery()
                        End If
                    End If
                End If
                objReadInventoryType.Close()

                'Update the table for serial numbers
                If Not String.IsNullOrEmpty(strItemSerialNo) Then
                    myCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers WHERE ItemCode = '" & strSelectedId & "' " _
                        & "AND SerialNumber = '" & strItemSerialNo & "'", cnn)
                    myCommand.ExecuteNonQuery()
                End If


                'Update the quantities if it is made up of components. Applicable to services and products

                Dim objCommandComponents As New Data.OleDb.OleDbCommand("SELECT MakeupItemCode, Quantity FROM InventoryComponents WHERE ItemCode = '" & strSelectedId & "'", cnn)
                Dim objReadComponents As Data.OleDb.OleDbDataReader = objCommandComponents.ExecuteReader
                While objReadComponents.Read
                    gwt_comm = New CommonLibrary.Commons.CommonFunctions
                    gwt_comm.UpdateComponentQuantitiesBasedOnSales(strSelectedId, objReadComponents(0).ToString, intQty)
                End While
                objReadComponents.Close()

            End If

        Next i

        dblSumPayable = CDbl(lblPayable.Text)

        'Add the record to the sales main

        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO CustomerPermitSalesMain (InvoiceNumber, CustomerId, " _
            & "TransDate, Discount, Taxes, Amount, UserName, SalesRep, OrderNumber, Notes, ProjectNumber) VALUES " _
            & "(" & Convert.ToDouble(txtReference.Text) & ", '" & txtAccountNumber.Text & "', " _
            & "'" & Format(dpProcessDate, "dd-MMM-yyyy") & "', " & dblSumDiscounts & ", " & dblSumTaxes & ", " _
            & "" & dblSumPayable & ", '" & strUserName & "', ' ', " _
            & "' ', '" & txtComments.Text & "', 0)", cnn)
        myCommand.ExecuteNonQuery()

        'update the default sales account as well
        If String.IsNullOrEmpty(CommonLibrary.Commons.strPublicSalesAccount) Then
            MessageBox.Show("The sales control account has not been setup. This will seriously affect the trial balance",
                 "Sales Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference]) VALUES " _
                & "('" & CommonLibrary.Commons.strPublicSalesAccount & "', '" & dpProcessDate & "', " & dblSumPayable - CDbl(lblTaxes.Text) & ", 'CREDIT', " _
                & "'" & txtAccountNumber.Text & "', '" & cboSupplierName.Text & "', '" & strUserName & "', " _
                & "'" & strUserBranch & "', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
            myCommand.ExecuteNonQuery()
        End If

        'Update the debtors control account
        If String.IsNullOrEmpty(CommonLibrary.Commons.strPublicDebtorsAccount) Then
            MessageBox.Show("The debtors control account has not been setup. This will seriously affect the trial balance",
                 "Debtors Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference]) VALUES " _
                & "('" & CommonLibrary.Commons.strPublicDebtorsAccount & "', '" & dpProcessDate & "', " & dblSumPayable & ", 'DEBIT', " _
                & "'" & txtAccountNumber.Text & "', '" & cboSupplierName.Text & "', '" & strUserName & "', " _
                & "'" & strUserBranch & "', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
            myCommand.ExecuteNonQuery()
        End If

        'Update the taxes control account as well

        If IsNumeric(lblTaxes.Text) Then
            If CDbl(lblTaxes.Text) > 0 Then
                If String.IsNullOrEmpty(CommonLibrary.Commons.strPublicTaxesAccount) Then
                    MessageBox.Show("The taxes control account has not been setup. This will seriously affect the trial balance", _
                        "Taxes Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Dim strProcessStatus As String = gwt_comm.LedgerEntry("INSERT", dpProcessDate, CommonLibrary.Commons.strPublicTaxesAccount, _
                        txtAccountNumber.Text, cboSupplierName.Text, CDbl(lblTaxes.Text), "CREDIT", _
                        txtReference.Text, , , , txtReference.Text, 0, 0, 0)
                    If strProcessStatus <> "SUCCESS" Then GoTo RaiseErr
                End If
            End If
        End If

        'If from air cards update the value
        If boolCalledFromListing = True Then
            Dim objComAir As New Data.OleDb.OleDbCommand("UPDATE AirCardsMain SET InvoiceNumber = " & txtReference.Text & " " _
                & "WHERE JobNumber = " & intSelectedTransaction & ")", cnn)
            objComAir.ExecuteNonQuery()
        End If

        If chkOverrideNo.Checked = False Then
            'Update the control numbers table
            gwt_comm = New CommonLibrary.Commons.CommonFunctions
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("PermitInvoices"))
            'If boolEditStatusTwo = True Then
            myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET PermitInvoices = " & CDbl(txtReference.Text) & "", cnn)
            myCommand.ExecuteNonQuery()
            'End If
        End If

        strPublicCustomerId = txtAccountNumber.Text
        MessageBox.Show("Sales document generated successfully.", "Transaction Document Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Transaction Processing"
        ShowErrorMessage()
        If boolEditStatusTwo = False Then
            'Delete any invoices with this number that may have been saved and roolback
            Dim objRollBack As New Data.OleDb.OleDbCommand("DELETE FROM CustomerPermitSalesMain WHERE InvoiceNumber = " & CDbl(txtReference.Text) & "", cnn)
            objRollBack.ExecuteNonQuery()
            objRollBack = New Data.OleDb.OleDbCommand("DELETE FROM CustomerPermitSales WHERE InvoiceNumber = " & CDbl(txtReference.Text) & "", cnn)
            objRollBack.ExecuteNonQuery()
            'Get the last invoice number used
            objRollBack = New Data.OleDb.OleDbCommand("SELECT DISTINCT(InvoiceNumber) FROM CustomerPermitSalesMain ORDER BY InvoiceNumber DESC", cnn)
            Dim objReadRollBack As Data.OleDb.OleDbDataReader = objRollBack.ExecuteReader
            If objReadRollBack.HasRows Then
                objReadRollBack.Read()
                If IsNumeric(objReadRollBack(0).ToString) Then
                    objRollBack = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET Invoices = " & CDbl(objReadRollBack(0).ToString) & "", cnn)
                    objRollBack.ExecuteNonQuery()
                End If
            End If
            objReadRollBack.Close()
            gwt_comm = New CommonLibrary.Commons.CommonFunctions
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("PermitInvoices"))
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub chkOverideDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverideDate.CheckedChanged
        If chkOverideDate.Checked = True Then
            If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
                dpTransDate.Enabled = True
            Else
                boolAbort = False
                boolAuthorized = False
                Dim f As New frmSupervisorAuthorizaton
                f.ShowDialog()
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

    Private Sub PrintInvoice(ByVal dtReceiptDate As Date)
        On Error GoTo RaiseErr
        strType = UCase(CommonLibrary.Commons.strInvoiceHeader)
        strSelectedReport = Me.txtReference.Text

        arrPrintDetails = New ArrayList
        '
        'ADD THE BRANCH INFORMATION
        '

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        arrPrintDetails.Add(Space(2) & UCase(CommonLibrary.Commons.strInvoiceHeader))
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))

        arrPrintDetails.Add(Space(2) & "VAT NO. : " & UCase(CommonLibrary.Commons.strCompanyVatNumber))
        arrPrintDetails.Add(Space(2) & "BP  NO. : " & UCase(CommonLibrary.Commons.strCompanyBPNumber))

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))

        arrPrintDetails.Add(Space(2) & UCase(strCompanyName))
        arrPrintDetails.Add(Space(2) & UCase(CommonLibrary.Commons.strPublicBranchName))
        arrPrintDetails.Add(Space(2) & UCase(CommonLibrary.Commons.strPublicBranchAddress1))
        arrPrintDetails.Add(Space(2) & UCase(CommonLibrary.Commons.strPublicBranchAddress2))
        arrPrintDetails.Add(Space(2) & UCase(CommonLibrary.Commons.strPublicBranchAddress3))
        arrPrintDetails.Add(Space(2) & UCase(CommonLibrary.Commons.strPublicBranchAddress4))
        arrPrintDetails.Add(Space(2) & "PHONE: " & CommonLibrary.Commons.strPublicBranchTelephone)

        '
        'Print the customer account number and details
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        arrPrintDetails.Add(Space(2) & txtAccountNumber.Text)
        arrPrintDetails.Add(Space(2) & cboSupplierName.Text)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        '
        'Print based on the grid values
        '
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
                    arrPrintDetails.Add(Space(4) & Space(8 - strQuantity.Length) & strQuantity & " @ " & Space(18 - strUnitPrice.Length) & strUnitPrice & Space(4) & Space(18 - strLineTotal.Length) & strLineTotal)

                    dblVatTax = dblVatTax + Convert.ToDouble(.Rows(i).Cells(7).Value)
                End If
            Next
        End With


        'Add the dash line
        Dim strTaxCharged As String = Format(dblVatTax, "##0.00")

        Dim strTender As String = Format(dblAmountTendered, "##0.00")
        Dim strChange As String = Format(dblAmountChange, "##0.00")

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "|AMT + VAT|" & lblPayable.Text)


        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "|VAT AMT|" & strTaxCharged)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "|TENDERED|" & strTender)
        arrPrintDetails.Add(Space(2) & "|CHANGE|" & strChange)

        Dim strZimDate As String = Format(Now, "dd-MMM-yyyy")

        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(2) & "TILL OPER :" & UCase(strUserName) & Space(3))
        arrPrintDetails.Add(Space(2) & "SALES REP :")
        If cboItems.Text.Length > 30 Then
            arrPrintDetails.Add(Space(2) & UCase(Mid(strPublicActiveFullUserName, 1, 30)))
        Else
            arrPrintDetails.Add(Space(2) & UCase(strPublicActiveFullUserName))
        End If

        arrPrintDetails.Add(Space(1) & "DATE AND TIME " & strZimDate & " " & DatePart(DateInterval.Hour, Now) & ":" & DatePart(DateInterval.Minute, Now))
        arrPrintDetails.Add(Space(2) & UCase(CommonLibrary.Commons.strInvoiceHeader) & " DATE  " & Format(dtReceiptDate, "dd-MMM-yyyy"))
        arrPrintDetails.Add(Space(2) & " DOC NO " & txtReference.Text)
        arrPrintDetails.Add(Space(32))
        'arrPrintDetails.Add("** NO RETURNS ON TESTED ITEMS **")
        'arrPrintDetails.Add("* ORIGINAL PHONE 6MTH GUARANTE *")

        For i As Double = 0 To 14
            arrPrintDetails.Add(Space(32))
        Next

        'WRITE EVERY THING TO THE AUDIT FILE
        Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\invoicedata", True)
        For x As Double = 0 To arrPrintDetails.Count - 1
            objFileWriter.WriteLine(arrPrintDetails.Item(x))
        Next
        objFileWriter.Close()

        '' Allow the user to select a printer.
        'Dim pd As New PrintDialog()
        'pd.ShowDialog()
        'pd.PrinterSettings = New PrinterSettings()

        ''First allow the user to select the printer to which to print to
        ''Dim f As New frmPrinterSetup
        ''f.ShowDialog()
        'strSessionPrinter = pd.PrinterSettings.PrinterName
        'pdWindows.PrinterSettings.PrinterName = strSessionPrinter
        'If boolEditStatusTwo = True Then GenerateTransactionDocument(intSelectedTransaction) Else GenerateTransactionDocument(CDbl(txtReference.Text))

        boolPrinterAlreadySelected = False

        If CommonLibrary.Commons.strPrintInvoiceToPOS = "YES" Then
            Dim pd As New PrintDialog()
            pd.PrinterSettings = New PrinterSettings()
            Dim output As String = Chr(&H1D) & "V" & Chr(66) & Chr(0) 'Feeds paper & cut
            For n = 0 To arrPrintDetails.Count - 1
                Dim strPrintLineDetails As String = arrPrintDetails.Item(n) & vbCrLf
                CommonLibrary.Commons.RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintLineDetails)
            Next
        Else
            Dim intPrintReference As Double = 0
            If boolEditStatusTwo = True Then intPrintReference = intSelectedTransaction Else intPrintReference = CDbl(txtReference.Text)
            If UCase(CommonLibrary.Commons.strInvoiceDesignType) = "CUSTOM" Then
                PrintPreviewDialog1.Document = PrintDocument1
                PrintDocument1.Print()
            Else
                'Print generic invoice
                Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
                gwt_comm.PrintCustomerDocument(intPrintReference, "INVOICE")
            End If
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Sale Transaction Processing"
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
            Dim dblQuantity As Double = 0
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    dblQuantity = CDbl(dGrid.Rows(i).Cells(3).Value.ToString)
                End If
            End If
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
        lblPayable.Text = Format(dblMovingTotal, "#,##0.00")
        lblSubTotal.Text = Format(dblSubs, "#,##0.00")
        lblDiscounts.Text = Format(dblDis, "#,##0.00")
        lblTaxes.Text = Format(dblTxs, "#,##0.00")
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
        If UCase(CommonLibrary.Commons.strTaxComputationType) = UCase("INCLUSIVE") Then
            lblTaxable.Text = Format(((dblSubTotal - dblDiscountTotals) - dblTaxesTotal), "#,##0.00")
        Else
            lblTaxable.Text = Format(((dblSubTotal - dblDiscountTotals) + 0), "#,##0.00")
        End If
        lblTaxes.Text = Format(dblTaxesTotal, "#,##0.00")
        lblDiscounts.Text = Format(dblDiscountTotals, "#,##0.00")
        lblPayable.Text = Format(dblTotalPayable, "#,##0.00")
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
        'LoadEmployees()
        LoadCustomers()
    End Sub

    Private Sub btnFindAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindAccount.Click
        strPublicItemCode = Nothing
        strPublicItemDescription = Nothing
        boolAbort = False
        Dim f As New frmBrowseDebtors
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        txtAccountNumber.Text = strPublicItemCode
        cboSupplierName.Text = strPublicItemDescription
    End Sub

    Private Sub AutomaticDiscount(ByVal strItemCode As String, ByVal intActiveLine As Double)
        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Category, SellingPrice FROM InventoryItems WHERE ItemCode = '" & strItemCode & "'", cnn)
        Dim objReadCategory As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReadCategory.HasRows Then
            objReadCategory.Read()
            If Not IsDBNull(objReadCategory(0).ToString) Then
                If UCase(objReadCategory(0).ToString) = "CELLPHONES" Then
                    If CDbl(objReadCategory(1).ToString) >= 100 And CDbl(objReadCategory(1).ToString) < 600 Then
                        dGrid.Rows(intActiveLine).Cells(6).Value = gwt_comm.RoundDown(objReadCategory(1) * 0.05)
                    End If
                    If CDbl(objReadCategory(1).ToString) >= 600 Then
                        dGrid.Rows(intActiveLine).Cells(6).Value = gwt_comm.RoundDown(objReadCategory(1) * 0.1)
                    End If
                End If
            End If
        End If
        ComputeValues(CDbl(dGrid.Rows(intActiveLine).Cells(3).Value.ToString), _
            CDbl(dGrid.Rows(intActiveLine).Cells(4).Value.ToString), intActiveLine, _
            dGrid.Rows(intActiveLine).Cells(6).Value.ToString, CommonLibrary.Commons.dblSalesTaxRate)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error Encountered while attempting to apply automatic discount"
        ShowErrorMessage()
    End Sub

    Private Sub PrintRawData()

        On Error GoTo RaiseErr

        Dim arrRawData As New ArrayList

        GenerateTransactionDocument(CDbl(txtReference.Text))

        With arrRawData
            .Add(Space(10) & UCase(CommonLibrary.Commons.strInvoiceHeader))

            .Add(Space(10) & StrDup(90, "-"c))
            .Add(Space(10) & UCase(CommonLibrary.Commons.strCompanyAddress1))
            .Add(Space(10) & UCase(CommonLibrary.Commons.strCompanyAddress2))
            .Add(Space(10) & UCase(CommonLibrary.Commons.strCompanyAddress3))
            .Add(Space(10) & UCase(CommonLibrary.Commons.strCompanyAddress4))
            .Add(Space(10) & UCase("Phone   : " & strCompanyTelephone))
            .Add(Space(10) & UCase("FAX     : " & CommonLibrary.Commons.strCompanyFaxNumber))
            .Add(Space(10) & strCompanyEmailAddress)
            .Add(Space(10) & UCase("VAT NO. : " & CommonLibrary.Commons.strCompanyVatNumber))
            .Add(Space(10) & UCase("REG NO. : " & CommonLibrary.Commons.strCompanyRegistrationNumber))
            .Add(Space(10) & StrDup(90, "-"c))

            .Add(Space(10) & "CUSTOMER DETAILS" & Space(40) & "TRANSACTION DETAILS")
            .Add(Space(10) & "VAT NO. : " & UCase(strCustomerVatNumber) & Space(40) & "INVOICE NO.    : " & Format(CLng(txtReference.Text), "000000"))
            strCustomerName = cboSupplierName.Text
            If strCustomerName.Length > 58 Then strCustomerName = Mid(strCustomerName, 1, 58)
            .Add(Space(10) & UCase(strCustomerName) & "DATE    : " & UCase(Format(dpTransDate.Value, "dd-MMM-yyyy")))
            .Add(Space(10) & UCase(strCustomerAddress1) & Space(40))
            .Add(Space(10) & UCase(strCustomerAddress2))
            .Add(Space(10) & UCase(strCustomerAddress3))
            .Add(Space(10) & UCase(strCustomerAddress4))
            .Add(Space(10) & StrDup(90, "-"c))
            .Add(Space(10) & "QTY" & Space(2) & "DESCRIPTION" & Space(19) & Space(2) & "PRICE   " & Space(2) _
                 & "TAX     " & Space(2) & "DISCOUNT" & Space(2) & "TOTAL   ")
            .Add(Space(10) & StrDup(90, "-"c))

            itm = 0
            boolExitingWhile = False

            Dim strBuffer() As String
            While itm < strInvoiceDetails.Count
                strBuffer = Split(strInvoiceDetails(itm), "|")

                Dim strQty As String = ""
                Dim strDesc As String = Nothing
                Dim strPrice As String = "0.00"
                Dim strTax As String = "0.00"
                Dim strDiscount As String = "0.00"
                Dim strTotal As String = "0.00"

                If Not strBuffer(0) Is Nothing Then strQty = strBuffer(0)
                If Not strBuffer(3) Is Nothing Then strPrice = CStr(Format(CDbl(strBuffer(3)), "#,##0.00"))
                If Not strBuffer(4) Is Nothing Then strTax = CStr(Format(CDbl(strBuffer(4)), "#,##0.00"))
                If Not strBuffer(5) Is Nothing Then strDiscount = CStr(Format(CDbl(strBuffer(5)), "#,##0.00"))
                If Not strBuffer(6) Is Nothing Then strTotal = CStr(Format(CDbl(strBuffer(6)), "#,##0.00"))
                If Not strBuffer(2) Is Nothing Then strDesc = strBuffer(2)

                If strDesc.Length > 28 Then strDesc = Mid(strDesc, 1, 28)
                .Add(Space(10) & strvalue & Space(2) & strDesc & Space(30 - strDesc.Length) & Space(2) _
                     & Space(12 - strPrice.Length) & strPrice & Space(2) & Space(12 - strDiscount.Length) & strDiscount _
                     & Space(2) & Space(12 - strTax.Length) & strTax & Space(2) & Space(12 - strTotal.Length) & strTotal)

                itm = itm + 1

            End While

            'print totals
            .Add(Space(10) & StrDup(80, "-"c))
            .Add(Space(12) & "TOTALS " & Space(25) & Format(dblTaxes, "#,##0.00") & Space(3) & Format(dblDiscounts, "#,##0.00") _
                 & Space(3) & Format(dblInvoiceTotal, "#,##0.00"))
            .Add(Space(10) & StrDup(90, "-"c))
            .Add(Space(10) & "OUR BANK DETAILS : " & CommonLibrary.Commons.strCompanyBankName & _
                 " ACCOUNT NO : " & UCase(CommonLibrary.Commons.strCompanyAccountNumber) & " BANK CODE : " & _
                 UCase(CommonLibrary.Commons.strCompanyBranchCode))
            .Add(Space(10) & StrDup(90, "-"c))

            'Write details to the text file
            Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\Data\Invoice.dat", True)
            For p As Integer = 0 To .Count - 1
                objFileWriter.WriteLine(.Item(p).ToString)
            Next
            objFileWriter.Close()

            'send to the raw printing
            boolAbort = False
            If CommonLibrary.Commons.strRequestForReceiptPrinter = "YES" Then
                Dim f As New frmPrinterSetup
                f.ShowDialog()
                If boolAbort = True Then Exit Sub
                pdWindows.PrinterSettings.PrinterName = strSessionPrinter
            End If
            For n = 0 To .Count - 1
                Dim strPrintLineDetails As String = .Item(n) & vbCrLf
                CommonLibrary.Commons.RawPrinterHelper.SendStringToPrinter(pdWindows.PrinterSettings.PrinterName, strPrintLineDetails)
            Next

        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " - Error number: " & Err.Number & vbCrLf & "On Invoice dot matrix printing"
        ShowErrorMessage()
    End Sub

    Private Sub GenerateTransactionDocument(ByVal intDocumentNumber As Double)
        'get invoice number
        On Error GoTo RaiseErr
        Dim n As Integer = 0
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim strCustomerNumber As String = Nothing

        myCommand = New Data.OleDb.OleDbCommand("Select CONVERT(NVARCHAR, TransDate, 105) as [TransDate], " _
            & "Amount, Taxes, Discount, CustomerId, SalesRep, Notes " _
            & "FROM CustomerPermitSalesMain Where InvoiceNumber = " & intDocumentNumber & "", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            Dim strDateparts() As String = Split(dbReader(0).ToString, "-")
            If Not IsDBNull(dbReader(0).ToString) Then strDate = CDate(strDateparts(0) & "-" & MonthName(CDbl(strDateparts(1)), True) & "-" & strDateparts(2))
            If IsNumeric(dbReader(1).ToString) Then dblInvoiceTotal = CDbl(dbReader(1).ToString) Else dblInvoiceTotal = 0
            If IsNumeric(dbReader(2).ToString) Then dblTaxes = dbReader(2).ToString Else dblTaxes = 0
            If IsNumeric(dbReader(3).ToString) Then dblDiscounts = dbReader(3).ToString Else dblDiscounts = 0
            If Not IsDBNull(dbReader(4).ToString) Then strCustomerNumber = dbReader(4).ToString
            If Not IsDBNull(dbReader("SalesRep").ToString) Then strSalesRep = dbReader("SalesRep").ToString
            If Not IsDBNull(dbReader("Notes").ToString) Then CommonLibrary.Commons.strInvoiceComments = dbReader("Notes").ToString
        End If
        dbReader.Close()

        'Get the customer details
        myCommand = New Data.OleDb.OleDbCommand("SELECT AccountName, Address1, Address2, Address3, Address4, " _
            & "PhoneNumber, EmailAddress, VatNumber FROM Customers WHERE AccountNumber = '" & strCustomerNumber & "'", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            If Not IsDBNull(dbReader(0).ToString) Then strCustomerName = dbReader(0).ToString
            If Not IsDBNull(dbReader(1).ToString) Then strCustomerAddress1 = dbReader(1).ToString
            If Not IsDBNull(dbReader(2).ToString) Then strCustomerAddress2 = dbReader(2).ToString
            If Not IsDBNull(dbReader(3).ToString) Then strCustomerAddress3 = dbReader(3).ToString
            If Not IsDBNull(dbReader(4).ToString) Then strCustomerAddress4 = dbReader(4).ToString
            If Not IsDBNull(dbReader(5).ToString) Then strCustomerTelephone = dbReader(5).ToString
            If Not IsDBNull(dbReader(6).ToString) Then strCustomerEmailAddress = dbReader(6).ToString
            If Not IsDBNull(dbReader(7).ToString) Then strCustomerVatNumber = dbReader(7).ToString
        End If

        myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity, ItemCode, Description as [Description], SalesPrice, " _
            & "DiscountAllowed, Taxes, (((SalesPrice * Quantity) - DiscountAllowed) + Taxes) AS [Payable] " _
            & "from CustomerPermitSales where InvoiceNumber = " & intDocumentNumber & "", cnn)
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Invoice Generation Error"
        ShowErrorMessage()
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        Dim boolPriorEditStatus As Boolean = boolEditStatus
        boolEditStatus = False
        'Dim f As New frmCustomerDetails
        'f.ShowDialog()
        LoadCustomers()
        boolEditStatus = boolPriorEditStatus
    End Sub

    Private Sub dGrid_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dGrid.ColumnWidthChanged
        If e.Column.Index = 0 Then
            cboItems.Width = dGrid.Columns(0).Width
            cboItems.Refresh()
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

    Private Sub LoadSelectedInvoiceData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [CustomerId]," _
            & "[TransDate],[OrderNumber],[SalesRep],[Amount],[Discount],[Taxes],[InvoiceNumber], " _
            & "[Status],[UserName],[Notes], ProjectNumber FROM CustomerPermitSalesMain WHERE InvoiceNumber = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                txtAccountNumber.Text = objReader(0).ToString
                'Get the address and name details
                LoadSelectedSupplierDetails(txtAccountNumber.Text)
            End If
            If Not IsDBNull(objReader("InvoiceNumber").ToString) Then txtReference.Text = objReader("InvoiceNumber").ToString
            If IsDate(objReader("TransDate").ToString) Then dpTransDate.Value = CDate(objReader("TransDate").ToString)
            'If Not IsDBNull(objReader("OrderNumber").ToString) Then
            '    strPublicInvoiceOrderNumber = objReader("OrderNumber").ToString
            '    txtOrderNumber.Text = objReader("OrderNumber").ToString
            'End If
            'If Not IsDBNull(objReader("SalesRep").ToString) Then cboPersonnel.Text = objReader("SalesRep").ToString
            If Not IsDBNull(objReader("Notes").ToString) Then txtComments.Text = objReader("Notes").ToString
            'If Not IsDBNull(objReader("ProjectNumber").ToString) Then
            '    chkProjectStatus.Checked = True
            '    txtProjectNumber.Text = objReader("ProjectNumber").ToString
            '    cboProjects.Text = objReader("ProjectNumber").ToString
            'End If
        End If
        objReader.Close()

        objCommand = New Data.OleDb.OleDbCommand("SELECT TransDate, ItemCode, Quantity, " _
            & "SalesPrice, TransType, Description, Taxes, DiscountAllowed, ProductType, SerialNumbers, " _
            & "UserName, SalesRep, CustomerId, OrderNumber FROM CustomerPermitSales WHERE InvoiceNumber = " & intSelectedTransaction & "", cnn)
        objReader = objCommand.ExecuteReader
        Dim strAgent As String = Nothing
        Dim strCustomerNumber As String = Nothing
        With dGrid
            Dim i As Double = 0
            While objReader.Read
                'If Not IsDBNull(objReader("SalesRep").ToString) Then cboPersonnel.Text = objReader("SalesRep").ToString
                If Not IsDBNull(objReader("CustomerId").ToString) Then txtAccountNumber.Text = objReader("CustomerId").ToString
                'If Not IsDBNull(objReader("OrderNumber").ToString) Then txtOrderNumber.Text = objReader("OrderNumber").ToString
                If Not IsDBNull(objReader(1).ToString) Then .Rows(i).Cells(0).Value = objReader(1).ToString
                If Not IsDBNull(objReader(5).ToString) Then .Rows(i).Cells(1).Value = objReader(5).ToString
                If Not IsDBNull(objReader(9).ToString) Then .Rows(i).Cells(2).Value = objReader(9).ToString
                If IsNumeric(objReader(3).ToString) Then .Rows(i).Cells(3).Value = Format(CDbl(objReader(3).ToString), "##0.00") Else .Rows(i).Cells(3).Value = "0.00"
                If Not IsDBNull(objReader(2).ToString) Then .Rows(i).Cells(4).Value = objReader(2).ToString
                If IsNumeric(objReader(6).ToString) Then .Rows(i).Cells(7).Value = Format(CDbl(objReader(6).ToString), "##0.00") Else .Rows(i).Cells(6).Value = "0.00"
                If IsNumeric(objReader(7).ToString) Then .Rows(i).Cells(6).Value = Format(CDbl(objReader(7).ToString), "##0.00") Else .Rows(i).Cells(5).Value = "0.00"
                If Not IsDBNull(objReader(8).ToString) Then .Rows(i).Cells(9).Value = objReader(8).ToString

                Dim dblLinePayable As Double = 0
                Dim dblLineQty As Double = 0
                Dim dblLineVat As Double = 0
                Dim dblLineDiscounts As Double = 0
                Dim dblLineUnitPrice As Double = 0

                If IsNumeric(objReader(2).ToString) Then dblLineQty = CDbl(objReader(2).ToString)
                If IsNumeric(objReader(3).ToString) Then dblLineUnitPrice = CDbl(objReader(3).ToString)
                If IsNumeric(objReader(6).ToString) Then dblLineVat = CDbl(objReader(6).ToString)
                If IsNumeric(objReader(7).ToString) Then dblLineDiscounts = CDbl(objReader(7).ToString)

                dblLinePayable = ((dblLineQty * dblLineUnitPrice) - dblLineDiscounts) + dblLineVat
                Dim dblLineSubTotal As Double = (dblLineQty * dblLineUnitPrice) - dblLineDiscounts

                .Rows(i).Cells(8).Value = Format(dblLinePayable, "##0.00")
                .Rows(i).Cells(5).Value = Format(dblLineSubTotal, "##0.00")

                i = i + 1
            End While
            objReader.Close()
        End With
        'AutoAccountNameFill(txtAccountNumber.Text)
        cboItems.Visible = False
        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on invoice details Load"
        ShowErrorMessage()
    End Sub

    'Private Sub btnMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMail.Click
    '    If String.IsNullOrEmpty(CommonLibrary.Commons.strPublicSalesAccount) Then
    '        MessageBox.Show("Missing the default sales ledger control account. " _
    '            & "Please set it up. For now the default will be used", "Missing Sales Control Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        CommonLibrary.Commons.strPublicSalesAccount = "0000"
    '    End If
    '    If String.IsNullOrEmpty(cboSupplierName.Text) Or _
    '        String.IsNullOrEmpty(txtAccountNumber.Text) Then
    '        MessageBox.Show("Missing the account number", "Missing Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        txtAccountNumber.Focus()
    '        Exit Sub
    '    End If
    '    FinishSale()
    '    If CommonLibrary.Commons.strPublicSalesAccount = "0000" Then CommonLibrary.Commons.strPublicSalesAccount = Nothing

    '    mybitMap = New Bitmap(827, (583 * 2))
    '    myGR = Graphics.FromImage(mybitMap)

    '    GenerateTransactionDocument(CDbl(txtReference.Text))
    '    PrintInvoiceToImage()

    '    Me.picDocumentImage.Image = mybitMap

    '    'Kill the payslip file if it exists
    '    If System.IO.File.Exists(Application.StartupPath & "\Data\DocumentImage.jpeg") Then
    '        Kill(Application.StartupPath & "\Data\DocumentImage.jpeg")
    '    End If
    '    picDocumentImage.Image.Save(Application.StartupPath & "\Data\DocumentImage.jpeg")
    '    picDocumentImage.Image.Dispose()

    '    'Call the email form and send the document
    '    Dim f As New frmEmailDocument
    '    f.ShowDialog()
    '    InitializeControls()
    'End Sub

    Private Sub PrintInvoiceToImage()

        On Error GoTo RaiseErr

        Dim imageHeight As Double = mybitMap.Height
        Dim imageWidth As Double = mybitMap.Width
        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions

        Dim strDType As String
        strDType = UCase(CommonLibrary.Commons.strInvoiceHeader)
        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer
        'Dim xx1 AS DOUBLE, xx2 AS DOUBLE, yy1 AS DOUBLE, yy2 AS DOUBLE
        x1 = 100
        y1 = 100
        p1 = mybitMap.Width - 200
        y2 = mybitMap.Height - 200

        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        'Dim graCurrent As Graphics = myGR.Graphics
        Dim strS As String = Nothing
        Dim Yc As Double
        Dim cols, lines As Double

        'Draw the main border
        Dim sbCurrent As SolidBrush 'penCurrent As Pen
        reccurrent = New Rectangle(x1, y1, (x2 - 43), y2)
        myGR.DrawRectangle(Pens.Navy, reccurrent)
        Dim intRectangleWidth As Double = reccurrent.Width

        'print the company logo
        'Dim g As Graphics = myGR.Graphics
        myGR.DrawString(UCase(CommonLibrary.Commons.strInvoiceHeader), New Font("Arial", 24, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, Color.Black)), 500, 120)

        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strLogoPath) Then
            If System.IO.File.Exists(CommonLibrary.Commons.strLogoPath) Then
                'Dont print the company name as it is taken care of by the logo
                strCompanyName = ""
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(CommonLibrary.Commons.strLogoPath)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(CommonLibrary.Commons.intLogoXposition, CommonLibrary.Commons.intLogoYposition, objPicture.Width, objPicture.Height)
                myGR.DrawImage(objPicture.Image, R)
            End If
        End If

        y1 = y1 + 15

        'Print the company details at the extreme left of document
        Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 110, y1, 300, 80, strCompanyName, HeaderFont, Brushes.Black)
        y1 = y1 + 20

        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyAddress1) Then
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 110, y1, 250, 80, CommonLibrary.Commons.strCompanyAddress1, tlFont, Brushes.Black)
            'Print the company number
            If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 400, y1, 250, 80, "COY NO. : " & UCase(CommonLibrary.Commons.strCompanyRegistrationNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the company number
            If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 400, y1, 250, 80, "COY NO. : " & UCase(CommonLibrary.Commons.strCompanyRegistrationNumber), tlFont, Brushes.Black)
                y1 = y1 + 15
            End If
        End If

        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyAddress2) Then
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 110, y1, 250, 80, CommonLibrary.Commons.strCompanyAddress2, tlFont, Brushes.Black)
            'Print the vat number
            If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 400, y1, 250, 80, "VAT NO. : " & UCase(CommonLibrary.Commons.strCompanyRegistrationNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the vat number
            If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 400, y1, 250, 80, "VAT NO. : " & UCase(CommonLibrary.Commons.strCompanyRegistrationNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        End If

        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyAddress3) Then
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 110, y1, 250, 80, CommonLibrary.Commons.strCompanyAddress3, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyAddress4) Then
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 110, y1, 250, 80, CommonLibrary.Commons.strCompanyAddress4, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyTelephone) Then
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 110, y1, 250, 80, "PHONE  : " & UCase(CommonLibrary.Commons.strCompanyTelephone), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyFaxNumber) Then
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 110, y1, 250, 80, "FAX NO.: " & UCase(CommonLibrary.Commons.strCompanyFaxNumber), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyEmailAddress) Then
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 110, y1, 250, 80, "E-MAIL : " & CommonLibrary.Commons.strCompanyEmailAddress, tlFont, Brushes.Black)
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

        myGR.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        myGR.DrawString("CUSTOMER DETAILS", prFont, Brushes.Black, x1, y1)
        myGR.DrawString("TRANSACTION DETAILS", prFont, Brushes.Black, 500, y1)
        y1 = y1 + 20
        myGR.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 15
        myGR.DrawString("VAT No.: " & UCase(strCustomerVatNumber), tlFont, Brushes.Black, x1, y1) '& Space(20) & " VAT No.: " & UCase(strCustomerVatNumber)
        y1 = y1 + 15
        If strCustomerName.Length > 58 Then strCustomerName = Mid(strCustomerName, 1, 58)
        myGR.DrawString(UCase(strCustomerName), tlFont, Brushes.Black, x1, y1)
        'myGR.Graphics.DrawString(strCustomerName, tlFont, Brushes.Black, x1, y1)
        'Print the date
        myGR.DrawString("DATE : " & strDate, tlFont, Brushes.Black, 500, y1)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 500, y1, 300, 80, "INVOICE NO.   : " & Format(CLng(txtReference.Text), "000000"), tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 110, y1, 200, 80, strCustomerAddress1, tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 110, y1, 200, 80, strCustomerAddress2, tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 500, y1, 300, 80, "ORDER REF. NO.: ", tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 110, y1, 200, 80, strCustomerAddress3, tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 500, y1, 300, 80, "SALES AGENT   : " & UCase(strPublicActiveFullUserName), tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, 110, y1, 200, 80, strCustomerAddress4, tlFont, Brushes.Black)
        y1 += 15
        myGR.DrawString("PHONE :" & strCustomerTelephone & " E-MAIL : " & strCustomerEmailAddress, tlFont, Brushes.Black, x1, y1)

        y1 = y1 + 30
        myGR.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        'print captions
        Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, x1, y1, 60, 80, "QTY", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, x2, y1, 250, 80, "DESCRIPTION", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRightPictureBox(myGR, X3, y1, 120, 80, "UNIT PRICE", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRightPictureBox(myGR, X4, y1, 120, 80, "TAX", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRightPictureBox(myGR, X5, y1, 120, 80, "DISCOUNT", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRightPictureBox(myGR, X6, y1, 120, 80, "TOTAL", prFont, Brushes.Black)
        'draw a line after
        y1 = y1 + 30
        myGR.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 30
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
            If UCase(CommonLibrary.Commons.strTaxComputationType) = UCase("INCLUSIVE") Then
                strPrintPrice = Format(CDbl(strUnitPrice) - CDbl(strTaxAmount), "#,##0.00")
            Else
                strPrintPrice = Format(CDbl(strUnitPrice), "#,##.00")
            End If

            'QUANTITY PRINTING
            Call gwt_comm.DrawStringInBoxCenterPictureBox(myGR, x1, y1, 50, 60, strPrintQuantity, tlFont, Brushes.Black)
            'UNIT PRICE PRINTING
            Call gwt_comm.DrawStringInBoxRightPictureBox(myGR, X3, y1, 120, 80, strPrintPrice, tlFont, Brushes.Black)
            'TAX PRINTING
            Call gwt_comm.DrawStringInBoxRightPictureBox(myGR, X4, y1, 120, 80, strTaxAmount, tlFont, Brushes.Black)
            'DISCOUNT PRINTING
            Call gwt_comm.DrawStringInBoxRightPictureBox(myGR, X5, y1, 120, 80, strDiscountAmount, tlFont, Brushes.Black)

            'Total payable
            If UCase(CommonLibrary.Commons.strTaxComputationType) = UCase("INCLUSIVE") Then
                strPayableAfterTax = Format(((CDbl(strPrintQuantity) * CDbl(strUnitPrice)) - CDbl(strDiscountAmount)) - 0, "#,##0.00")
            Else
                strPayableAfterTax = Format(((CDbl(strPrintQuantity) * CDbl(strUnitPrice)) - CDbl(strDiscountAmount)) + CDbl(strTaxAmount), "#,##0.00")
            End If

            'LINE TOTAL PRINTING
            Call gwt_comm.DrawStringInBoxRightPictureBox(myGR, X6, y1, 120, 80, strPayableAfterTax, tlFont, Brushes.Black)

            'If Not strBuffer(6) Is Nothing Then strvalue = CStr(Format(CDbl(strBuffer(6)), "#,##0.00")) Else strvalue = "0.00"

            'Print the description last as it is the column that will determine the next line position
            If Not strBuffer(2) Is Nothing Then strvalue = strBuffer(2) Else strvalue = ""
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, x2, y1, 200, 80, strvalue, tlFont, Brushes.Black)
            'Get the size of the address box
            myGR.MeasureString(strvalue, tlFont, New SizeF(200, 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * tlFont.Height + 5
            y1 = Math.Max(y1, Yc)
            'y1 = y1 + 20
            itm = itm + 1 : i = 0
            If itm = 23 Then
                'Print the page number of the statement
                Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, x1, (imageHeight - 50), 120, 80, "Page " & intPage, tlFont, Brushes.Black)
                'print the compny bank details
                Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, x1, (imageHeight - 80), 600, 80, "OUR BANK DETAILS : " & UCase(CommonLibrary.Commons.strCompanyBankName) & _
                    " - ACCOUNT NO : " & UCase(CommonLibrary.Commons.strCompanyAccountNumber) & " BANK CODE : " & _
                    UCase(CommonLibrary.Commons.strCompanyBranchCode), prFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, X6 - 50, (imageHeight - 50), 200, 80, "powered by brainco intelligency", prFont, Brushes.Black)
                boolExitingWhile = True
                intPage += 1
                Exit While
            End If
        End While

        'print totals
        'draw a line
        If boolExitingWhile = False Then
            y1 = y1 + 30
            myGR.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
            y1 = y1 + 30
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, x1, y1, 120, 80, "TOTALS ", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRightPictureBox(myGR, X4, y1, 120, 80, Format(dblTaxes, "#,##0.00"), prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRightPictureBox(myGR, X5, y1, 120, 80, Format(dblDiscounts, "#,##0.00"), prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRightPictureBox(myGR, X6, y1, 120, 80, Format(dblInvoiceTotal, "#,##0.00"), prFont, Brushes.Black)

            'Print the receiver information
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, x1, imageHeight - 150, 220, 80, "ACCEPTED BY ....................................... ", tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, x1 + 210, imageHeight - 150, 200, 80, "SIGNATURE ..................................... ", tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, x1 + 420, imageHeight - 150, 200, 80, "DATE ...................................... ", tlFont, Brushes.Black)

            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, x1, (imageHeight - 50), 120, 80, "Page " & intPage, tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, x1, (imageHeight - 80), 600, 80, "OUR BANK DETAILS : " & CommonLibrary.Commons.strCompanyBankName & _
                " ACCOUNT NO : " & UCase(CommonLibrary.Commons.strCompanyAccountNumber) & " BANK CODE : " & _
                UCase(CommonLibrary.Commons.strCompanyBranchCode), tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeftPictureBox(myGR, X6 - 50, (imageHeight - 50), 200, 80, "powered by brainco intelligency", prFont, Brushes.Black)

        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On invoice image generation"
        ShowErrorMessage()
    End Sub

    Private Sub InitializeControls()
        Me.lblPayable.Text = "0.00"
        Me.lblSubTotal.Text = "0.00"
        Me.lblDiscounts.Text = "0.00"
        Me.lblTaxes.Text = "0.00"
        lblTaxable.Text = "0.00"
        'Clear the controls
        dGrid.Rows.Clear()
        dGrid.Rows.Add(350)
        AlternateColors()
        txtReference.Text = ""
        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
        txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("PermitInvoices"))
        dpTransDate.Enabled = False
        chkOverideDate.Checked = False
        Cursor = Cursors.Default
        If boolEditStatusTwo = True Then
            Me.Close()
        End If
        dpTransDate.Value = Now
        chkOverideDate.Checked = False
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        PrintCustomInvoice()
    End Sub

    Private Sub frmInvoice_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '950, 661
        'Me.Width = 950 : Me.Height = 661
    End Sub

    Private Sub LoadCustomers()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT AccountName +';'+AccountNumber AS [Customer] FROM Customers ORDER BY AccountName"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Set up the drop down combo box
        'Dim intWidth As Integer = cboSupplierName.Width - 50
        With cboSupplierName
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "250;100" '& intWidth - 250
        End With

        'Get a count of the items
        Dim intItemsCount As Double = 0

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(AccountNumber) FROM Customers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()

        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboSupplierName.Items.Clear()
        Dim p As Double = 0

        'Continue to read until you reach the end of the file.
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            End If
            p = p + 1
        End While
        objReader.Close()

        If intItemsCount > 0 Then
            cboSupplierName.SelectedIndex = -1
            cboSupplierName.Items.Clear()
            cboSupplierName.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboSupplierName.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " On customers details load"
        ShowErrorMessage()
    End Sub

    Private Sub cboSupplierName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSupplierName.SelectedIndexChanged
        txtAccountNumber.Clear()
        cboItems.Visible = False
        If Not cboSupplierName.SelectedItem Is Nothing Then
            txtAccountNumber.Text = cboSupplierName.SelectedItem.Col2
            LoadSelectedSupplierDetails(txtAccountNumber.Text)
        Else
            txtAccountNumber.Text = Nothing
        End If
    End Sub

    Private Sub LoadSelectedSupplierDetails(ByVal AccountNumber As String)
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Address1, Address2, Address3, Address4, " _
            & "PhoneNumber, EmailAddress, AccountName FROM Customers WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim strAddress As String = Nothing
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then txtAddress1.Text = objReader(0).ToString & vbCrLf
            If Not IsDBNull(objReader(1).ToString) Then txtAddress2.Text = objReader(1).ToString & vbCrLf
            If Not IsDBNull(objReader(2).ToString) Then txtAddress3.Text = objReader(2).ToString & vbCrLf
            If Not IsDBNull(objReader(3).ToString) Then txtAddress4.Text = objReader(3).ToString & vbCrLf
            If Not IsDBNull(objReader(4).ToString) Then txtPhoneNumber.Text = objReader(4).ToString & vbCrLf
            If Not IsDBNull(objReader(5).ToString) Then txtEmailAddress.Text = objReader(5).ToString

            If String.IsNullOrEmpty(cboSupplierName.Text) Then
                If Not IsDBNull(objReader("AccountName").ToString) Then cboSupplierName.Text = objReader("AccountName").ToString
            End If
        End While

        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " On selected creditors details load"
        ShowErrorMessage()
    End Sub

    Private Sub cboSerials_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSerials.KeyPress
        If Asc(e.KeyChar) = 13 Then
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

    Private Sub btnSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveNew.Click
        If String.IsNullOrEmpty(CommonLibrary.Commons.strPublicSalesAccount) Then
            MessageBox.Show("Missing the default sales ledger control account. " _
                & "Please set it up. For now the default will be used", "Missing Sales Control Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CommonLibrary.Commons.strPublicSalesAccount = "0000"
        End If
        If String.IsNullOrEmpty(cboSupplierName.Text) Or _
            String.IsNullOrEmpty(txtAccountNumber.Text) Then
            MessageBox.Show("Missing the account number", "Missing Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNumber.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblFlightDetails.Text) Then
            MessageBox.Show("Please enter the flight details", "Missing Flight Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnFlightDetails.Focus()
            Exit Sub
        End If
        boolAbort = False
        FinishSale()
        If boolAbort = True Then Exit Sub
        If boolEditStatus = False Then
            boolAbort = False
            Dim f As New frmPrintCopies
            f.ShowDialog()
            If boolAbort = False Then
                For i As Integer = 0 To intNumberOfPrintCopies - 1
                    If CommonLibrary.Commons.strPublicPrinterType = "RAW" Then
                        PrintRawData()
                    Else
                        PrintInvoice(Format(dpTransDate.Value, "dd-MMM-yyyy"))
                    End If
                Next
            Else
                MessageBox.Show("Transaction Prcessed but not printed", "Invoice Generation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If CommonLibrary.Commons.strPublicSalesAccount = "0000" Then CommonLibrary.Commons.strPublicSalesAccount = Nothing
        InitializeControls()
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim backColor As Color = Color.White
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
            Next
        Next
        For i As Integer = 0 To dGrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
                dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
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
            Dim strRecordText() As String = Split(strFullItemDetails, ";")
            Dim DropDownItems As MTGCComboBoxItem
            If UCase(CommonLibrary.Commons.strDefaultSearchFilter) = "DESCRIPTION" Then
                DropDownItems = New MTGCComboBoxItem(UCase(strRecordText(1)), UCase(strRecordText(0)), UCase(strRecordText(2)), UCase(strRecordText(3)))
            Else
                DropDownItems = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)), UCase(strRecordText(2)), UCase(strRecordText(3)))
            End If
            cboItems.SelectedItem = DropDownItems
            CommitValueChanged()
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(1)
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If boolPrintFromPreview = True Then
            'requery records
            boolAbort = False
            Me.GenerateTransactionDocument(CDbl(txtReference.Text))
            If boolAbort = True Then Exit Sub
            boolPrintFromPreview = False
        End If

        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions

        Dim strDType As String
        strDType = UCase(CommonLibrary.Commons.strInvoiceHeader)
        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer
        'Dim xx1 AS DOUBLE, xx2 AS DOUBLE, yy1 AS DOUBLE, yy2 AS DOUBLE
        x1 = e.PageBounds.Left + 100
        y1 = e.PageBounds.Top + 100
        p1 = e.PageBounds.Width - 200
        y2 = e.PageBounds.Height - 200

        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        Dim strS As String = Nothing
        Dim Yc As Double
        Dim cols, lines As Double

        'Draw the document rectangle
        reccurrent = New Rectangle(x1, y1, p1, y2)
        e.Graphics.DrawRectangle(Pens.Black, reccurrent)

        'print the company logo
        Dim g As Graphics = e.Graphics
        g.DrawString(UCase(CommonLibrary.Commons.strInvoiceHeader), New Font("Arial", 16, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, Color.Black)), 350, e.PageBounds.Top + 110)
        'Draw a line after
        y1 = y1 + 40
        '' ''e.Graphics.DrawLine(Pens.Black, x1, y1, p1 + 100, y1)

        Dim intLogoNextXPosition As Integer = CommonLibrary.Commons.intLogoXposition

        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strLogoPath) Then
            If System.IO.File.Exists(CommonLibrary.Commons.strLogoPath) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(CommonLibrary.Commons.strLogoPath)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(CommonLibrary.Commons.intLogoXposition, CommonLibrary.Commons.intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                intLogoNextXPosition = R.X + R.Width + 3
            End If
        End If

        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strBrandImage1) Then
            If System.IO.File.Exists(CommonLibrary.Commons.strBrandImage1) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(CommonLibrary.Commons.strBrandImage1)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoNextXPosition, CommonLibrary.Commons.intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                intLogoNextXPosition = R.X + R.Width + 3
            End If
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strBrandImage2) Then
            If System.IO.File.Exists(CommonLibrary.Commons.strBrandImage2) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(CommonLibrary.Commons.strBrandImage2)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoNextXPosition, CommonLibrary.Commons.intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                intLogoNextXPosition = R.X + R.Width + 3
            End If
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strBrandImage3) Then
            If System.IO.File.Exists(CommonLibrary.Commons.strBrandImage3) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(CommonLibrary.Commons.strBrandImage3)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoNextXPosition, CommonLibrary.Commons.intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                intLogoNextXPosition = R.X + R.Width + 3
            End If
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strBrandImage4) Then
            If System.IO.File.Exists(CommonLibrary.Commons.strBrandImage4) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(CommonLibrary.Commons.strBrandImage4)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoNextXPosition, CommonLibrary.Commons.intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                intLogoNextXPosition = R.X + R.Width + 3
            End If
        End If

        y1 = y1 + 15

        'print captions
        x1 = x1 + 10
        x2 = x1 + 50
        X3 = x2 + 140
        X4 = X3 + 100
        X5 = X4 + 100
        X6 = X5 + 100

        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20


        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, HeaderFont, Brushes.Black)
        y1 = y1 + 20

        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyAddress1) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, CommonLibrary.Commons.strCompanyAddress1, tlFont, Brushes.Black)
            'Print the company number
            If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "CK NO.  : " & UCase(CommonLibrary.Commons.strCompanyRegistrationNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the company number
            If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "CK NO.  : " & UCase(CommonLibrary.Commons.strCompanyRegistrationNumber), tlFont, Brushes.Black)
                y1 = y1 + 15
            End If
        End If

        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyAddress2) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, CommonLibrary.Commons.strCompanyAddress2, tlFont, Brushes.Black)
            'Print the vat number
            If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO. : " & UCase(CommonLibrary.Commons.strCompanyVatNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the vat number
            If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO. : " & UCase(CommonLibrary.Commons.strCompanyVatNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        End If

        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyAddress3) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, CommonLibrary.Commons.strCompanyAddress3, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyAddress4) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, CommonLibrary.Commons.strCompanyAddress4, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyTelephone) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "PHONE  : " & UCase(CommonLibrary.Commons.strCompanyTelephone), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        'strCompanyContactCellNumber
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyContactCellNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 550, 80, "CELL NO: " & UCase(CommonLibrary.Commons.strCompanyContactCellNumber), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyFaxNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "FAX NO.: " & UCase(CommonLibrary.Commons.strCompanyFaxNumber), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyEmailAddress) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "E-MAIL : " & CommonLibrary.Commons.strCompanyEmailAddress, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        y1 = y1 + 5

        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        e.Graphics.DrawString("CUSTOMER DETAILS", prFont, Brushes.Black, x1, y1)
        e.Graphics.DrawString("TRANSACTION DETAILS", prFont, Brushes.Black, 500, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 15
        e.Graphics.DrawString("VAT No.: " & strCustomerVatNumber, tlFont, Brushes.Black, x1, y1) '& Space(20) & " VAT No.: " & UCase(strCustomerVatNumber)
        y1 = y1 + 15
        If strCustomerName.Length > 58 Then strCustomerName = Mid(strCustomerName, 1, 58)
        e.Graphics.DrawString(UCase(strCustomerName), tlFont, Brushes.Black, x1, y1)
        'e.Graphics.DrawString(strCustomerName, tlFont, Brushes.Black, x1, y1)
        'Print the date
        e.Graphics.DrawString("DATE", tlFont, Brushes.Black, 500, y1)
        e.Graphics.DrawString(": " & strDate, tlFont, Brushes.Black, 580, y1)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "INVOICE NUM", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, ": " & Format(CLng(txtReference.Text), "000000"), tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress1, tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress2, tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "ORDER REF.NO.", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, ": " & UCase(CommonLibrary.Commons.strPublicInvoiceOrderNumber), tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress3, tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "SALES AGENT", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, ": " & UCase(strSalesRep), tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress4, tlFont, Brushes.Black)
        y1 += 15
        e.Graphics.DrawString("TELEPHONE : " & strCustomerTelephone, tlFont, Brushes.Black, x1, y1)
        y1 += 15
        e.Graphics.DrawString("E-MAIL    :" & strCustomerEmailAddress, tlFont, Brushes.Black, x1, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        Dim y1_before_headers As Integer = y1
        y1 = y1 + 12

        'print captions
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 60, 80, "QTY", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 250, 80, "DESCRIPTION", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, (X3 + 110), y1, 120, 80, "SUB TOTAL", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, (X4 + 80), y1, 120, 80, "TAX", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, (X5 + 50), y1, 120, 80, "DISCOUNT", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, (X6 + 20), y1, 120, 80, "TOTAL", prFont, Brushes.Black)
        'draw a line after
        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 30
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
            If UCase(CommonLibrary.Commons.strTaxComputationType) = UCase("INCLUSIVE") Then
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
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 50, 60, strPrintQuantity & strMeasureShortName, tlFont, Brushes.Black)
            'UNIT PRICE PRINTING
            If IsNumeric(strPrintQuantity) Then
                Call gwt_comm.DrawStringInBoxRight(e, (X3 + 110), y1, 120, 80, Format(((CDbl(strUnitPrice) * CDbl(strPrintQuantity)) - 0), "#,##0.00"), tlFont, Brushes.Black)
                'Call gwt_comm.DrawStringInBoxRight(e, (X3 + 110), y1, 120, 80, Format(((CDbl(strUnitPrice) * CDbl(strPrintQuantity)) - CDbl(strTaxAmount)), "#,##0.00"), tlFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxRight(e, (X3 + 110), y1, 120, 80, "", tlFont, Brushes.Black)
            End If

            'TAX PRINTING
            If IsNumeric(strPrintQuantity) Then
                Call gwt_comm.DrawStringInBoxRight(e, (X4 + 80), y1, 120, 80, strTaxAmount, tlFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxRight(e, (X4 + 80), y1, 120, 80, "", tlFont, Brushes.Black)
            End If

            'DISCOUNT PRINTING
            If IsNumeric(strPrintQuantity) Then
                Call gwt_comm.DrawStringInBoxRight(e, (X5 + 50), y1, 120, 80, strDiscountAmount, tlFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxRight(e, (X5 + 50), y1, 120, 80, "", tlFont, Brushes.Black)
            End If

            'Total payable
            If UCase(CommonLibrary.Commons.strTaxComputationType) = UCase("INCLUSIVE") Then
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
            Call gwt_comm.DrawStringInBoxRight(e, (X6 + 20), y1, 120, 80, strPayableAfterTax, tlFont, Brushes.Black)

            'If Not strBuffer(6) Is Nothing Then strvalue = CStr(Format(CDbl(strBuffer(6)), "#,##0.00")) Else strvalue = "0.00"

            'Print the description last as it is the column that will determine the next line position
            If IsNumeric(strPrintPrice) Then
                If CDbl(strPrintPrice) = 0 Then
                    strvalue = strBuffer(2)
                Else
                    If Not strBuffer(2) Is Nothing Then strvalue = strBuffer(2) & " @ " & strPrintPrice Else strvalue = ""
                End If
            Else
                If Not strBuffer(2) Is Nothing Then strvalue = strBuffer(2) Else strvalue = ""
            End If
            Call gwt_comm.DrawStringInBoxLeft(e, (x2 - 10), y1, 330, 80, strvalue, tlFont, Brushes.Black)

            'Get the size of the description box
            e.Graphics.MeasureString(strvalue, tlFont, New SizeF(330, 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * tlFont.Height + 5
            y1 = Math.Max(y1, Yc)
            'y1 = y1 + 20
            itm = itm + 1 : i = 0
            If itm = 23 Then
                'Print the page number of the statement
                Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, tlFont, Brushes.Black)
                'print the compny bank details
                Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 80, 600, 80, UCase(CommonLibrary.Commons.strCompanySlogan), prFont, Brushes.Black)
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

            'draw the drop down lines
            e.Graphics.DrawLine(Pens.Black, x1 + 35, y1_before_headers, x1 + 35, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, x2 + 310, y1_before_headers, x2 + 310, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, 540, y1_before_headers, 540, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, 610, y1_before_headers, 610, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, 680, y1_before_headers, 680, y1_after_headers)

            'DRAW THE BANKING DETAILS BOX


            y1 = e.PageBounds.Bottom - 280
            Dim y1_before_draw As Integer = y1
            e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, x1 + 350, y1)
            y1 = y1 + 6
            gwt_comm.DrawStringInBoxLeft(e, x1 + 5, y1, 100, 80, "BANK", prFont, Brushes.Black)
            gwt_comm.DrawStringInBoxLeft(e, x1 + 110, y1, 300, 80, UCase(CommonLibrary.Commons.strCompanyBankName), prFont, Brushes.Black)
            y1 = y1 + 15
            e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, x1 + 350, y1)
            y1 = y1 + 6
            gwt_comm.DrawStringInBoxLeft(e, x1 + 5, y1, 100, 80, "ACCOUNT NAME", prFont, Brushes.Black)
            gwt_comm.DrawStringInBoxLeft(e, x1 + 110, y1, 300, 80, UCase(CommonLibrary.Commons.strCompanyAccountName), prFont, Brushes.Black)
            y1 = y1 + 15
            e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, x1 + 350, y1)
            y1 = y1 + 6
            gwt_comm.DrawStringInBoxLeft(e, x1 + 5, y1, 100, 80, "ACCOUNT NUMBER", prFont, Brushes.Black)
            gwt_comm.DrawStringInBoxLeft(e, x1 + 110, y1, 300, 80, UCase(CommonLibrary.Commons.strCompanyAccountNumber), prFont, Brushes.Black)
            y1 = y1 + 15
            e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, x1 + 350, y1)
            Dim y1_after_draw As Integer = 1
            'Draw the two drop down lines in between and at end
            e.Graphics.DrawLine(Pens.Black, x1 + 100, y1_before_draw, x1 + 100, y1_before_draw + 62)
            e.Graphics.DrawLine(Pens.Black, x1 + 350, y1_before_draw, x1 + 350, y1_before_draw + 62)

            'DRAW THE RECTANLGE FOR TERMS AND CONDITIONS

            reccurrent = New Rectangle(x1 + 360, y1_before_draw, 250, 62)
            e.Graphics.DrawRectangle(Pens.Black, reccurrent)
            gwt_comm.DrawStringInBoxLeft(e, x1 + 360, y1_before_draw + 5, 230, 80, "TERMS AND CONDITIONS", prFont, Brushes.Black)
            gwt_comm.DrawStringInBoxLeft(e, x1 + 360, y1_before_draw + 20, 230, 200, CommonLibrary.Commons.strInvoiceComments, prFont, Brushes.Black)

            'Print the receiver information
            Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 150, 220, 80, "ACCEPTED BY ....................................... ", tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x1 + 210, e.PageBounds.Bottom - 150, 200, 80, "SIGNATURE ..................................... ", tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x1 + 420, e.PageBounds.Bottom - 150, 200, 80, "DATE ...................................... ", tlFont, Brushes.Black)

            Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxCenter(e, x1, e.PageBounds.Bottom - 80, 600, 80, UCase(CommonLibrary.Commons.strCompanySlogan), prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", prFont, Brushes.Black)

            e.HasMorePages = False
            Me.boolPrintFromPreview = True

        End If
    End Sub

    Private Sub chkOverrideNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverrideNo.CheckedChanged
        If boolEditStatusTwo = True Then Exit Sub
        If chkOverrideNo.Checked = True Then
            txtReference.Clear()
            txtReference.Enabled = True
        Else
            txtReference.Enabled = False
            'Get the next document number
            Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("PermitInvoices"))
        End If
    End Sub

    Private Sub txtReference_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReference.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            dGrid.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtReference_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtReference.Validating
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(txtReference.Text) Then
            If IsNumeric(txtReference.Text) Then
                Dim objCommand As New Data.OleDb.OleDbCommand("SELECT InvoiceNumber FROM CustomerPermitSalesMain WHERE InvoiceNumber = " & txtReference.Text & "", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    MessageBox.Show("The number entered already exists. Please try another one", _
                        "Duplicate Invoice Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtReference.Clear()
                    txtReference.Focus()
                    Exit Sub
                End If
                objReader.Close()
            Else
                MessageBox.Show("Please enter a numberic value for invoice number", "Invalid Invoice Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtReference.Clear()
                txtReference.Focus()
                Exit Sub
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On invoice number override"
        ShowErrorMessage()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        boolCloseButton = True
        CloseRoutine()
    End Sub

    Private Sub CloseRoutine()
        boolAbort = True
        CurrentActiveInvoiceNumber = 0
        Me.Close()
    End Sub

    Private Sub pdAirInvoice_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdAirInvoice.PrintPage
        On Error GoTo RaiseErr

        Dim myGraphics As Graphics = e.Graphics
        Dim myRectangle As Rectangle
        Dim myPen As New Pen(Color.Black)

        Dim intX As Integer = 530
        Dim intY As Integer = 100

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


        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Invoice #" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 20, strText, fntDetailsFontBold, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "JUL160445" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 20, strText, tlFont, Brushes.Black)

        'Second line boxes
        intY = intY + 28
        intX = 530

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Invoice Date" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFontBold, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "01-JAN-2016" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, tlFont, Brushes.Black)

        'Third line boxes
        intY = intY + 28
        intX = 530

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Due Date" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFontBold, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "31-JAN-2016" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, tlFont, Brushes.Black)

        'Fourth line boxes
        intY = intY + 28
        intX = 530

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Job #" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFontBold, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "TWT 250001" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, tlFont, Brushes.Black)

        'Fifth line boxes
        intY = intY + 28
        intX = 530

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Ref. #" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFontBold, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "F00847" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, tlFont, Brushes.Black)


        '********** DRAW THE HEADER LINES *******************
        '
        'HEADER BOX 1

        intY = intY + 56
        intX = 100
        intCellWidth = 150
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Operator" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, fntDetailsFontBold, Brushes.Black)

        'HEADER BOX 2
        intX = intX + intCellWidth + 3
        intCellWidth = 100
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Reg/Type" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, fntDetailsFontBold, Brushes.Black)

        'HEADER BOX 3
        intX = intX + intCellWidth + 3
        intCellWidth = 80
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Location" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, fntDetailsFontBold, Brushes.Black)

        'HEADER BOX 4
        intX = intX + intCellWidth + 3
        intCellWidth = 80
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Arrival" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, fntDetailsFontBold, Brushes.Black)

        'HEADER BOX 5
        intX = intX + intCellWidth + 3
        intCellWidth = 80
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Departure" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, fntDetailsFontBold, Brushes.Black)

        'HEADER BOX 6
        intX = intX + intCellWidth + 3
        intCellWidth = 125
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Captain Name" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, fntDetailsFontBold, Brushes.Black)


        '************ SECOND LINE HEADERS ***************************

        'HEADER BOX 1

        intY = intY + 26
        intX = 100
        intCellWidth = 150
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Absolute Flight Services" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, tlFont, Brushes.Black)

        'HEADER BOX 2
        intX = intX + intCellWidth + 3
        intCellWidth = 100
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "ZS-0PY/ADS" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, tlFont, Brushes.Black)

        'HEADER BOX 3
        intX = intX + intCellWidth + 3
        intCellWidth = 80
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "HTDA" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, tlFont, Brushes.Black)

        'HEADER BOX 4
        intX = intX + intCellWidth + 3
        intCellWidth = 80
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "02-FEB-2016" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, tlFont, Brushes.Black)

        'HEADER BOX 5
        intX = intX + intCellWidth + 3
        intCellWidth = 80
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "03-FEB-2016" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, tlFont, Brushes.Black)

        'HEADER BOX 6
        intX = intX + intCellWidth + 3
        intCellWidth = 125
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Embassy Phiri" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, tlFont, Brushes.Black)


        'BEGIN DETAILS PRINT BY PRINT FIRST THE BOXES

        'DRAW THE MAIN BOX

        intY = intY + 28
        intX = 100
        intCellWidth = 630
        intCellHeight = 600

        Dim intHeaderY As Integer = intY + 10

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)

        'Draw the first horizontal line
        intY = intY + 28
        e.Graphics.DrawLine(Pens.Black, intX, intY, 730, intY)

        'Draw the first vertical line 
        intX = 470
        e.Graphics.DrawLine(Pens.Black, intX, intY - 28, intX, 920)

        'Draw the first vertical line 
        intX = 550
        e.Graphics.DrawLine(Pens.Black, intX, intY - 28, intX, 920)

        'Draw the first vertical line 
        intX = 630
        e.Graphics.DrawLine(Pens.Black, intX, intY - 28, intX, 920)

        'Write out the headers
        Call gwt_comm.DrawStringInBoxLeft(e, 105, intHeaderY, 250, 20, "Service", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 475, intHeaderY, 80, 20, "Unit Price", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 555, intHeaderY, 80, 20, "Qty", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 635, intHeaderY, 100, 20, "Amount", tlFont, Brushes.Black)


        'Draw the total line box
        myRectangle = New Rectangle(x:=630, y:=925, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        Call gwt_comm.DrawStringInBoxRight(e, 535, 930, 80, 20, "TOTAL", fntDetailsFontBold, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, 630, 930, 100, 25, "250,000.00", fntDetailsFontBold, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, 100, 930, 300, 20, "VIA Aviation Limited", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 100, 942, 300, 20, "Terminal One", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 100, 954, 300, 20, "Dar es Salam International Airport", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 100, 966, 300, 20, "P O Box 3590", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 100, 978, 300, 20, "Dar es Salam, Tanzania", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 100, 990, 300, 20, "TIN Number 101-602-745", tlFont, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, 302, 930, 300, 20, "Banking Details", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 302, 942, 300, 20, "Beneficiary : VIA Aviation Limited", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 302, 954, 300, 20, "USD Account Number : 8004275", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 302, 966, 300, 20, "EUR Account Number : 6001414", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 302, 978, 300, 20, "Bank Name : Barclays Bank (T) Ltd", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 302, 990, 300, 20, "Swift Code : BARCTZTZ", tlFont, Brushes.Black)

        'Draw the logo

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
                R = New Rectangle(intLogoXposition, intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
            End If
        End If

        'Print Company Address

        intX = 105
        intY = 150

        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, strCompanyName, tlFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, strCompanyAddress1, tlFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, strCompanyAddress2, tlFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, strCompanyAddress3, tlFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, strCompanyAddress4, tlFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, strCompanyTelephone, tlFont, Brushes.Black)

        'Print Header
        Call gwt_comm.DrawStringInBoxLeft(e, 530, 60, 300, 40, "INVOICE", myfntDetailsFontBold, Brushes.Black)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Print"
        ShowErrorMessage()
    End Sub

    Private Sub DrawStringInBoxRight(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
                ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, _
                Optional ByVal strFontName As String = "Arial", _
                Optional ByVal intFontSize As Integer = 8, Optional ByVal FontColor As String = "Black", _
                Optional ByVal FontBold As Boolean = False, Optional ByVal FontItalic As Boolean = False, _
                Optional ByVal FontUnderline As Boolean = False, Optional ByVal BackColor As String = "White")
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF((x1 - 1), (y1 - 2), (x2 - 2), (y2 - y1))
        Dim fillColor As New SolidBrush(Drawing.Color.FromName(BackColor))
        ev.Graphics.FillRectangle(fillColor, recCurrent)
        sfCurrent.Alignment = Drawing.StringAlignment.Far
        Dim sBrush As System.Drawing.Brush = GetDefinedColor(FontColor)
        'Reset the font style according to parameters passed
        Dim sFnt As New Font(strFontName, intFontSize, FontStyle.Regular)
        If FontBold = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Bold)
        If FontItalic = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Italic)
        If FontUnderline = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Underline)
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Private Sub DrawStringInBoxLeft(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
                ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, _
                Optional ByVal strFontName As String = "Arial", _
                Optional ByVal intFontSize As Integer = 8, Optional ByVal FontColor As String = "Black", _
                Optional ByVal FontBold As Boolean = False, Optional ByVal FontItalic As Boolean = False, _
                Optional ByVal FontUnderline As Boolean = False, Optional ByVal BackColor As String = "White")
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF((x1 - 1), (y1 - 2), (x2 - 2), (y2 - y1))
        Dim fillColor As New SolidBrush(Drawing.Color.FromName(BackColor))
        ev.Graphics.FillRectangle(fillColor, recCurrent)
        sfCurrent.Alignment = Drawing.StringAlignment.Near
        Dim sBrush As System.Drawing.Brush = GetDefinedColor(FontColor)
        'Reset the font style according to parameters passed
        Dim sFnt As New Font(strFontName, intFontSize, FontStyle.Regular)
        If FontBold = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Bold)
        If FontItalic = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Italic)
        If FontUnderline = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Underline)
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Private Sub DrawStringInBoxCenter(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
                ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, _
                Optional ByVal strFontName As String = "Arial", _
                Optional ByVal intFontSize As Integer = 8, Optional ByVal FontColor As String = "Black", _
                Optional ByVal FontBold As Boolean = False, Optional ByVal FontItalic As Boolean = False, _
                Optional ByVal FontUnderline As Boolean = False, Optional ByVal BackColor As String = "White")
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF((x1 - 1), (y1 - 2), (x2 - 2), (y2 - y1))
        Dim fillColor As New SolidBrush(Drawing.Color.FromName(BackColor))
        ev.Graphics.FillRectangle(fillColor, recCurrent)
        sfCurrent.Alignment = Drawing.StringAlignment.Center
        Dim sBrush As System.Drawing.Brush = GetDefinedColor(FontColor)
        'Reset the font style according to parameters passed
        Dim sFnt As New Font(strFontName, intFontSize, FontStyle.Regular)
        If FontBold = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Bold)
        If FontItalic = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Italic)
        If FontUnderline = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Underline)
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Private Function GetDefinedColor(ByVal strColorName As String) As System.Drawing.Brush
        Dim ret As System.Drawing.Brush
        Select Case UCase(strColorName)
            Case Is = UCase("AliceBlue")
                ret = Brushes.AliceBlue
            Case Is = UCase("AntiqueWhite")
                ret = Brushes.AntiqueWhite
            Case Is = UCase("Aqua")
                ret = Brushes.Aqua
            Case Is = UCase("Aquamarine")
                ret = Brushes.Aquamarine
            Case Is = UCase("Azure")
                ret = Brushes.Azure
            Case Is = UCase("Beige")
                ret = Brushes.Beige
            Case Is = UCase("Bisque")
                ret = Brushes.Bisque
            Case Is = UCase("Black")
                ret = Brushes.Black
            Case Is = UCase("BlanchedAlmond")
                ret = Brushes.BlanchedAlmond
            Case Is = UCase("Blue")
                ret = Brushes.Blue
            Case Is = UCase("BlueViolet")
                ret = Brushes.BlueViolet
            Case Is = UCase("Brown")
                ret = Brushes.Brown
            Case Is = UCase("BurlyWood")
                ret = Brushes.BurlyWood
            Case Is = UCase("CadetBlue")
                ret = Brushes.CadetBlue
            Case Is = UCase("Chartreuse")
                ret = Brushes.Chartreuse
            Case Is = UCase("Chocolate")
                ret = Brushes.Chocolate
            Case Is = UCase("Coral")
                ret = Brushes.Coral
            Case Is = UCase("CornflowerBlue")
                ret = Brushes.CornflowerBlue
            Case Is = UCase("Cornsilk")
                ret = Brushes.Cornsilk
            Case Is = UCase("Crimson")
                ret = Brushes.Crimson
            Case Is = UCase("Cyan")
                ret = Brushes.Cyan
            Case Is = UCase("DarkBlue")
                ret = Brushes.DarkBlue
            Case Is = UCase("DarkCyan")
                ret = Brushes.DarkCyan
            Case Is = UCase("DarkGoldenrod")
                ret = Brushes.DarkGoldenrod
            Case Is = UCase("DarkGray")
                ret = Brushes.DarkGray
            Case Is = UCase("DarkGreen")
                ret = Brushes.DarkGreen
            Case Is = UCase("DarkKhaki")
                ret = Brushes.DarkKhaki
            Case Is = UCase("DarkMagenta")
                ret = Brushes.DarkMagenta
            Case Is = UCase("DarkOliveGreen")
                ret = Brushes.DarkOliveGreen
            Case Is = UCase("DarkOrange")
                ret = Brushes.DarkOrange
            Case Is = UCase("DarkOrchid")
                ret = Brushes.DarkOrchid
            Case Is = UCase("DarkRed")
                ret = Brushes.DarkRed
            Case Is = UCase("DarkSalmon")
                ret = Brushes.DarkSalmon
            Case Is = UCase("DarkSeaGreen")
                ret = Brushes.DarkSeaGreen
            Case Is = UCase("DarkSlateBlue")
                ret = Brushes.DarkSlateBlue
            Case Is = UCase("DarkSlateGray")
                ret = Brushes.DarkSlateGray
            Case Is = UCase("DarkTurquoise")
                ret = Brushes.DarkTurquoise
            Case Is = UCase("DarkViolet")
                ret = Brushes.DarkViolet
            Case Is = UCase("DeepPink")
                ret = Brushes.DeepPink
            Case Is = UCase("DeepSkyBlue")
                ret = Brushes.DeepSkyBlue
            Case Is = UCase("DimGray")
                ret = Brushes.DimGray
            Case Is = UCase("DodgerBlue")
                ret = Brushes.DodgerBlue
            Case Is = UCase("Firebrick")
                ret = Brushes.Firebrick
            Case Is = UCase("FloralWhite")
                ret = Brushes.FloralWhite
            Case Is = UCase("ForestGreen")
                ret = Brushes.ForestGreen
            Case Is = UCase("Fuchsia")
                ret = Brushes.Fuchsia
            Case Is = UCase("Gainsboro")
                ret = Brushes.Gainsboro
            Case Is = UCase("GhostWhite")
                ret = Brushes.GhostWhite
            Case Is = UCase("Gold")
                ret = Brushes.Gold
            Case Is = UCase("Goldenrod")
                ret = Brushes.Goldenrod
            Case Is = UCase("Gray")
                ret = Brushes.Gray
            Case Is = UCase("Green")
                ret = Brushes.Green
            Case Is = UCase("GreenYellow")
                ret = Brushes.GreenYellow
            Case Is = UCase("Honeydew")
                ret = Brushes.Honeydew
            Case Is = UCase("HotPink")
                ret = Brushes.HotPink
            Case Is = UCase("IndianRed")
                ret = Brushes.IndianRed
            Case Is = UCase("Indigo")
                ret = Brushes.Indigo
            Case Is = UCase("Ivory")
                ret = Brushes.Ivory
            Case Is = UCase("Khaki")
                ret = Brushes.Khaki
            Case Is = UCase("Lavender")
                ret = Brushes.Lavender
            Case Is = UCase("LavenderBlush")
                ret = Brushes.LavenderBlush
            Case Is = UCase("LawnGreen")
                ret = Brushes.LawnGreen
            Case Is = UCase("LemonChiffon")
                ret = Brushes.LemonChiffon
            Case Is = UCase("LightBlue")
                ret = Brushes.LightBlue
            Case Is = UCase("LightCoral")
                ret = Brushes.LightCoral
            Case Is = UCase("LightCyan")
                ret = Brushes.LightCyan
            Case Is = UCase("LightGoldenrodYellow")
                ret = Brushes.LightGoldenrodYellow
            Case Is = UCase("LightGray")
                ret = Brushes.LightGray
            Case Is = UCase("LightGreen")
                ret = Brushes.LightGreen
            Case Is = UCase("LightPink")
                ret = Brushes.LightPink
            Case Is = UCase("LightSalmon")
                ret = Brushes.LightSalmon
            Case Is = UCase("LightSeaGreen")
                ret = Brushes.LightSeaGreen
            Case Is = UCase("LightSkyBlue")
                ret = Brushes.LightSkyBlue
            Case Is = UCase("LightSlateGray")
                ret = Brushes.LightSlateGray
            Case Is = UCase("LightSteelBlue")
                ret = Brushes.LightSteelBlue
            Case Is = UCase("LightYellow")
                ret = Brushes.LightYellow
            Case Is = UCase("Lime")
                ret = Brushes.Lime
            Case Is = UCase("LimeGreen")
                ret = Brushes.LimeGreen
            Case Is = UCase("Linen")
                ret = Brushes.Linen
            Case Is = UCase("Magenta")
                ret = Brushes.Magenta
            Case Is = UCase("Maroon")
                ret = Brushes.Maroon
            Case Is = UCase("MediumAquamarine")
                ret = Brushes.MediumAquamarine
            Case Is = UCase("MediumBlue")
                ret = Brushes.MediumBlue
            Case Is = UCase("MediumOrchid")
                ret = Brushes.MediumOrchid
            Case Is = UCase("MediumPurple")
                ret = Brushes.MediumPurple
            Case Is = UCase("MediumSeaGreen")
                ret = Brushes.MediumSeaGreen
            Case Is = UCase("MediumSlateBlue")
                ret = Brushes.MediumSlateBlue
            Case Is = UCase("MediumSpringGreen")
                ret = Brushes.MediumSpringGreen
            Case Is = UCase("MediumTurquoise")
                ret = Brushes.MediumTurquoise
            Case Is = UCase("MediumVioletRed")
                ret = Brushes.MediumVioletRed
            Case Is = UCase("MidnightBlue")
                ret = Brushes.MidnightBlue
            Case Is = UCase("MintCream")
                ret = Brushes.MintCream
            Case Is = UCase("MistyRose")
                ret = Brushes.MistyRose
            Case Is = UCase("Moccasin")
                ret = Brushes.Moccasin
            Case Is = UCase("NavajoWhite")
                ret = Brushes.NavajoWhite
            Case Is = UCase("Navy")
                ret = Brushes.Navy
            Case Is = UCase("OldLace")
                ret = Brushes.OldLace
            Case Is = UCase("Olive")
                ret = Brushes.Olive
            Case Is = UCase("OliveDrab")
                ret = Brushes.OliveDrab
            Case Is = UCase("Orange")
                ret = Brushes.Orange
            Case Is = UCase("OrangeRed")
                ret = Brushes.OrangeRed
            Case Is = UCase("Orchid")
                ret = Brushes.Orchid
            Case Is = UCase("PaleGoldenrod")
                ret = Brushes.PaleGoldenrod
            Case Is = UCase("PaleGreen")
                ret = Brushes.PaleGreen
            Case Is = UCase("PaleTurquoise")
                ret = Brushes.PaleTurquoise
            Case Is = UCase("PaleVioletRed")
                ret = Brushes.PaleVioletRed
            Case Is = UCase("PapayaWhip")
                ret = Brushes.PapayaWhip
            Case Is = UCase("PeachPuff")
                ret = Brushes.PeachPuff
            Case Is = UCase("Peru")
                ret = Brushes.Peru
            Case Is = UCase("Pink")
                ret = Brushes.Pink
            Case Is = UCase("Plum")
                ret = Brushes.Plum
            Case Is = UCase("PowderBlue")
                ret = Brushes.PowderBlue
            Case Is = UCase("Purple")
                ret = Brushes.Purple
            Case Is = UCase("Red")
                ret = Brushes.Red
            Case Is = UCase("RosyBrown")
                ret = Brushes.RosyBrown
            Case Is = UCase("RoyalBlue")
                ret = Brushes.RoyalBlue
            Case Is = UCase("SaddleBrown")
                ret = Brushes.SaddleBrown
            Case Is = UCase("Salmon")
                ret = Brushes.Salmon
            Case Is = UCase("SandyBrown")
                ret = Brushes.SandyBrown
            Case Is = UCase("SeaGreen")
                ret = Brushes.SeaGreen
            Case Is = UCase("SeaShell")
                ret = Brushes.SeaShell
            Case Is = UCase("Sienna")
                ret = Brushes.Sienna
            Case Is = UCase("Silver")
                ret = Brushes.Silver
            Case Is = UCase("SkyBlue")
                ret = Brushes.SkyBlue
            Case Is = UCase("SlateBlue")
                ret = Brushes.SlateBlue
            Case Is = UCase("SlateGray")
                ret = Brushes.SlateGray
            Case Is = UCase("Snow")
                ret = Brushes.Snow
            Case Is = UCase("SpringGreen")
                ret = Brushes.SpringGreen
            Case Is = UCase("SteelBlue")
                ret = Brushes.SteelBlue
            Case Is = UCase("Tan")
                ret = Brushes.Tan
            Case Is = UCase("Teal")
                ret = Brushes.Teal
            Case Is = UCase("Thistle")
                ret = Brushes.Thistle
            Case Is = UCase("Tomato")
                ret = Brushes.Tomato
            Case Is = UCase("Turquoise")
                ret = Brushes.Turquoise
            Case Is = UCase("Violet")
                ret = Brushes.Violet
            Case Is = UCase("Wheat")
                ret = Brushes.Wheat
            Case Is = UCase("White")
                ret = Brushes.White
            Case Is = UCase("WhiteSmoke")
                ret = Brushes.WhiteSmoke
            Case Is = UCase("Yellow")
                ret = Brushes.Yellow
            Case Is = UCase("YellowGreen")
                ret = Brushes.YellowGreen
            Case Else
                ret = Brushes.Black
        End Select
        Return ret
    End Function

    Private Sub PrintCustomInvoice()
        On Error GoTo RaiseErr
        Dim objPrint As New PrintAirInvoice
        With objPrint
            .CustomerAddress1 = txtAddress1.Text
            .CustomerAddress2 = txtAddress2.Text
            .CustomerAddress3 = txtAddress3.Text
            .CustomerAddress4 = txtAddress4.Text
            .CustomerName = cboSupplierName.Text
            .CustomerTelephone = txtPhoneNumber.Text
            .CustomerEmailAddress = txtEmailAddress.Text
            .strPermitInvoiceNumber = txtReference.Text
            .strPermitInvoiceDate = Format(dpTransDate.Value, "dd-MMM-yyyy")

            Dim strBuffer() As String = Split(lblFlightDetails.Text, "|")

            .strPermitOperatorName = strBuffer(0)
            .strPermitRegistrationType = strBuffer(1)
            .strPermitLocation = strBuffer(2)
            .strPermitArrivalDate = strBuffer(3)
            .strPermitDepatureDate = strBuffer(4)
            .strPermitCaptainName = strBuffer(5)
            .strPermitJobNumber = strBuffer(6)
            .strPermitInvoiceDueDate = strBuffer(7)
            .strPermitReferenceNumber = strBuffer(8)

            If IsNumeric(lblPayable.Text) Then
                .dblInvoiceTotal = CDbl(lblPayable.Text)
            Else
                .dblInvoiceTotal = 0
            End If

            arrPrintDetails = New ArrayList
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

                        arrPrintDetails.Add(strDescription & "|" & strUnitPrice & "|" & strQuantity & "|" & strLineTotal)

                    End If
                Next
            End With

            .arrPrintData = arrPrintDetails

        End With

        Dim ppd As New PrintPreviewDialog
        ppd.Document = objPrint
        ppd.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnFlightDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnFlightDetails.Click
        boolAbort = False
        lblFlag.BackColor = Color.Red
        strFlightDetails = Nothing
        lblFlightDetails.Text = Nothing
        Dim frm As New frmFlightDetails
        frm.ShowDialog()
        If boolAbort = True Then
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(strFlightDetails) Then
            lblFlag.BackColor = Color.Green
            lblFlightDetails.Text = strFlightDetails
        End If
    End Sub

End Class
