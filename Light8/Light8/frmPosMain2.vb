'Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices.ComTypes
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports EltradeFPAx
'Imports Microsoft.Office.Interop.Outlook
'Imports Microsoft.Office.Interop.Excel

Public Class frmPosMain2

    Dim PrintFiscalReceipt As Boolean

    'Dim dblUS_Rate As Double = 1
    'Dim dblRand_Rate As Double = 0
    'Dim dblBond_Rate As Double = 0
    'Dim dblTransfer_Rate As Double = 0

    Dim strReceiptFiscalStatus As String

    Dim strSelectedReport As String
    Dim prFont As New System.Drawing.Font("Arial", 8, FontStyle.Regular)
    Dim tlFont As New System.Drawing.Font("Arial", 8, FontStyle.Bold)
    Dim HeaderFont As New System.Drawing.Font("Arial", 12, FontStyle.Bold)

    Dim NameFont As New System.Drawing.Font("Arial", 10, FontStyle.Bold)

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
    Dim boolItemTaxable As Boolean

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub ClearCurrentRowValues(ByVal RowIndex As Integer)
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Rows(RowIndex).Cells(p).Value = Nothing
        Next
    End Sub

    Private Sub frmPosMain_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Enter Or e.KeyValue = 9 Then
            If dGrid.CurrentCell.ColumnIndex = 0 Then
                If txtBarcode.Focused = True Then Exit Sub
                strPublicItemCode = Nothing
                strFullItemDetails = Nothing
                boolAbort = False
                gwt_comm.InventorySearch()
                If boolAbort = True Then Exit Sub
                'Dim frm As New frmPriceType
                'frm.ShowDialog()
                If boolAbort = True Then
                    'Clear the current row values
                    ClearCurrentRowValues(dGrid.CurrentRow.Index)
                    Exit Sub
                End If
                CommitValueChanged()
                dGrid.Select()
                dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(2)
            End If
        End If

        If e.KeyValue = Keys.F5 Then
            strPublicItemCode = Nothing
            strFullItemDetails = Nothing
            boolAbort = False
            gwt_comm.InventorySearch()
            If boolAbort = True Then Exit Sub
            If boolAbort = True Then
                'Clear the current row values
                ClearCurrentRowValues(dGrid.CurrentRow.Index)
                Exit Sub
            End If
            CommitValueChanged()
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(2)
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
            gwt_comm.CustomerSearch()
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

        If e.KeyValue = Keys.F8 Then
            Dim f As New frmSalesReturns
            f.ShowDialog()
        End If
        If e.KeyValue = Keys.F9 Then
            Dim f As New frmSalesReturnsPlus
            f.ShowDialog()
        End If
        If e.KeyValue = Keys.F10 Then
            boolAbort = False
            gwt_comm.CashbookSelection()
            If boolAbort = True Then Exit Sub
            gwt_comm.ExpensesCapture(boolClassicExpensesCapture)
        End If
        If e.KeyValue = Keys.F11 Then
            If dGrid.Rows.Count > 0 Then
                dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
                RecalculateAmount()
                ComputeTotals()
            End If
        End If

    End Sub

    Private Sub buttonDecoration()

        btnCheckEquivalence.BackColor = Color.FromArgb(108, 123, 144)
        btnOveride.BackColor = Color.FromArgb(108, 123, 144)

        btnBeginSale.BackColor = Color.FromArgb(16, 63, 145) ' Color.Magenta

        btnFinish.BackColor = Color.DarkGreen ' Color.FromArgb(108, 123, 144)
        btnPos.BackColor = Color.Firebrick ' Color.FromArgb(108, 123, 144)
        btnAccountPayment.BackColor = Color.FromArgb(108, 123, 144)
        btnExchange.BackColor = Color.FromArgb(108, 123, 144)
        btnAccountPayment.BackColor = Color.FromArgb(108, 123, 144)
        btnLaybyePayment.BackColor = Color.FromArgb(108, 123, 144)
        btnExchangePlus.BackColor = Color.FromArgb(108, 123, 144)
        btnSearch.BackColor = Color.FromArgb(108, 123, 144)
        btnExpenses.BackColor = Color.FromArgb(108, 123, 144)
        btnDailySales.BackColor = Color.FromArgb(108, 123, 144)
        btnDateOveride.BackColor = Color.FromArgb(108, 123, 144)
        btnRemove.BackColor = Color.FromArgb(108, 123, 144)
        mtZreport.BackColor = Color.FromArgb(108, 123, 144)
        btnKeyPads.BackColor = Color.FromArgb(108, 123, 144)
        btnRefresh.BackColor = Color.FromArgb(108, 123, 144)
        btnTestFiscalPrinter.BackColor = Color.FromArgb(108, 123, 144)
        btnPrintPeriodReport.BackColor = Color.FromArgb(108, 123, 144)
        btnCreditNote.BackColor = Color.FromArgb(108, 123, 144)

        btnCheckEquivalence.ForeColor = Color.White
        btnOveride.ForeColor = Color.White
        btnFinish.ForeColor = Color.White
        btnAccountPayment.ForeColor = Color.White
        btnPos.ForeColor = Color.White
        btnExchange.ForeColor = Color.White
        btnAccountPayment.ForeColor = Color.White
        btnLaybyePayment.ForeColor = Color.White
        btnExchangePlus.ForeColor = Color.White
        btnSearch.ForeColor = Color.White
        btnExpenses.ForeColor = Color.White
        btnDailySales.ForeColor = Color.White
        btnDateOveride.ForeColor = Color.White
        btnRemove.ForeColor = Color.White
        mtZreport.ForeColor = Color.White
        btnKeyPads.ForeColor = Color.White
        btnRefresh.ForeColor = Color.White
        btnTestFiscalPrinter.ForeColor = Color.White
        btnPrintPeriodReport.ForeColor = Color.White
        btnBeginSale.ForeColor = Color.White
        btnCreditNote.ForeColor = Color.White
        'btnFinish.ForeColor = Color.White

    End Sub

    Private Sub frmPosMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolAbort = False

        On Error GoTo RaiseErr

        buttonDecoration()

        'Add column for the fiscal status of the receipt
        If gwt_comm.CheckColumnExistence("SalesMain", "FiscalStatus") = False Then
            Dim objCommand As New Data.OleDb.OleDbCommand("ALTER TABLE SalesMain ADD [FiscalStatus][NVARCHAR](3) NOT NULL DEFAULT 'NO'", cnn)
            objCommand.ExecuteNonQuery()
        End If

        GetExpensesFormCaptureType()

        If boolAbort = True Then Exit Sub

        'If Not String.IsNullOrEmpty(strCompanyName) Then
        '    Me.Text = strCompanyName & " POS"
        'End If

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
            lblUserName.Text = UCase(strPublicActiveFullUserName)
        End If

        With Me.dGrid
            .Rows.Add(350)
        End With

        lblTransDate.Text = UCase(shortMonthDateFormat(Now))

        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames " _
            & "AS [EmployeeDetails] FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        cboPersonnel.Items.Clear()
        cboPersonnel.Items.Add("")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboPersonnel.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()

        Me.ActiveControl = Nothing

        dGrid.Focus()
        dGrid.CurrentCell = dGrid.Rows(0).Cells(0)
        dGrid.Rows(0).Cells(0).Selected = True
        dGrid.BeginEdit(False)

        Me.ActiveControl = dGrid
        dGrid.Select()
        dGrid.CurrentCell = dGrid.Rows(0).Cells(0)
        dGrid.CurrentCell.Selected = True
        dGrid.Focus()

        dGrid.Enabled = False
        btnFinish.Enabled = False

        btnBeginSale.ForeColor = Color.White

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on POS Initialize"
        ShowErrorMessage()
    End Sub

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        If Not String.IsNullOrEmpty(txtBarcode.Text) Then
            If Asc(e.KeyChar) = 13 Then
                e.Handled = True
                isBarCodeEntry = True
                ProcessBarCode()
                isBarCodeEntry = False
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ProcessBarCode()

        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtBarcode.Text) Then Exit Sub

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
                    & "CAST(SellingPrice AS DECIMAL (30,2))) AS [Price], TaxStatus, FullBarcodeSerialStatus " _
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

                    ComputeValues(CDbl(dGrid.Rows(intActiveLine).Cells(3).Value.ToString),
                        CDbl(dGrid.Rows(intActiveLine).Cells(4).Value.ToString), intActiveLine,
                            dGrid.Rows(intActiveLine).Cells(6).Value.ToString, 0)

                End If
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
        gwt_comm.ShowErrorMessage()
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

    Private Sub dGrid_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGrid.KeyDown
        If e.KeyValue = 9 Then
            'frmCashoutItemTypes
            If dGrid.CurrentCell.ColumnIndex = 0 Then
                strPublicItemCode = Nothing
                strFullItemDetails = Nothing
                boolAbort = False
                gwt_comm.InventorySearch()
                If boolAbort = True Then Exit Sub
                If boolAbort = True Then
                    'Clear the current row values
                    ClearCurrentRowValues(dGrid.CurrentRow.Index)
                    Exit Sub
                End If
                CommitValueChanged()
                Me.ActiveControl = dGrid
                dGrid.Select()
                dGrid.Focus()
                dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(2)
                dGrid.CurrentCell.Selected = True
                dGrid.Focus()
            End If
        End If
    End Sub

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr
        'If cboItems.Focused = False Then Exit Sub
        If chkDeliverySale.Checked = True Then Exit Sub
        Dim objCommand As Data.OleDb.OleDbCommand
        For z As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.CurrentRow.Cells(z).Value = Nothing
        Next

        boolItemTaxable = True

        RecalculateAmount()

        If Not String.IsNullOrEmpty(strFullItemDetails) Then

            Dim strSplitValues() As String = Split(strFullItemDetails, ";")

            dGrid.CurrentRow.Cells(0).Value = UCase(strSplitValues(0))
            dGrid.CurrentRow.Cells(1).Value = UCase(strSplitValues(1))
            dGrid.CurrentRow.Cells(3).Value = strSplitValues(2)
            dGrid.CurrentRow.Cells(4).Value = "1"
            dGrid.CurrentRow.Cells(6).Value = "0"

            If UCase(strSplitValues(4)) = "YES" Then
                boolItemTaxable = True
            Else
                boolItemTaxable = False
            End If

            'Get the item type
            dGrid.CurrentRow.Cells(5).ReadOnly = False
            Dim strCodeSelected As String = dGrid.CurrentRow.Cells(0).Value.ToString
            Dim dblSalePrice As Double = 0

            Dim strSqlQuery As String = Nothing

            Select Case UCase(strPriceType)
                Case Is = UCase("Public")
                    strSqlQuery = "SELECT InventoryType, SellingPrice * " & dblActiveSalesCurrencyRate & " AS [SellingPrice] FROM InventoryItems WHERE ItemCode = '" & strCodeSelected & "'"
                Case Is = UCase("Retail")
                    strSqlQuery = "SELECT InventoryType, RetailPrice * " & dblActiveSalesCurrencyRate & " AS [SellingPrice] FROM InventoryItems WHERE ItemCode = '" & strCodeSelected & "'"
                Case Is = UCase("Special")
                    strSqlQuery = "SELECT InventoryType, SpecialPrice * " & dblActiveSalesCurrencyRate & " AS [SellingPrice] FROM InventoryItems WHERE ItemCode = '" & strCodeSelected & "'"
                Case Is = UCase("Wholesale")
                    strSqlQuery = "SELECT InventoryType, WholesalePrice * " & dblActiveSalesCurrencyRate & " AS [SellingPrice] FROM InventoryItems WHERE ItemCode = '" & strCodeSelected & "'"
                Case Else
                    strSqlQuery = "SELECT InventoryType, SellingPrice * " & dblActiveSalesCurrencyRate & " AS [SellingPrice] FROM InventoryItems WHERE ItemCode = '" & strCodeSelected & "'"
            End Select

            objCommand = New Data.OleDb.OleDbCommand(strSqlQuery, cnn)
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

            dGrid.CurrentRow.Cells(3).Value = dblSalePrice

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

        'If UCase(strUserLevel) = UCase("administrator") Or
        '    UCase(strUserLevel) = UCase("Manager") Then
        '    dGrid.CurrentRow.Cells(3).ReadOnly = False
        'Else
        '    dGrid.CurrentRow.Cells(3).ReadOnly = True
        'End If

        'dGrid.CurrentRow.Cells(3).ReadOnly = False

        Me.ActiveControl = dGrid
        dGrid.Select()
        dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(2)
        dGrid.CurrentCell.Selected = True
        dGrid.Focus()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On discount computation"
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

    Private Sub ComputeValues(ByVal dblUnitPrice As Double,
                              ByVal intQuantity As Double,
                              ByVal intRowIndex As Double,
                              Optional ByVal dblDiscount As Double = 0,
                              Optional ByVal dblTaxRate As Double = 0,
                              Optional ByVal Taxable As Boolean = True)
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
                            MessageBox.Show("Please enter the serial number for item code " & ItemCode,
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

    Private Sub dGrid_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellValidated
        If dGrid.CurrentCell.ColumnIndex = 4 Or dGrid.CurrentCell.ColumnIndex = 6 Or dGrid.CurrentCell.ColumnIndex = 3 Or dGrid.CurrentCell.ColumnIndex = 7 Then
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value), "")) Then
                If Not IsNumeric(dGrid.CurrentCell.Value) Then
                    MessageBox.Show("Invalid Non Numeric Value Detected. Cell value defaulted to 0", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGrid.CurrentCell.Value = "0"
                    ComputeValues(CDbl(dGrid.CurrentRow.Cells(3).Value.ToString),
                                  CDbl(dGrid.CurrentRow.Cells(4).Value.ToString),
                                  dGrid.CurrentRow.Index,
                                  CDbl(dGrid.CurrentRow.Cells(6).Value.ToString),
                                  dblSalesTaxRate,
                                  boolItemTaxable)
                    Exit Sub
                Else
                    ComputeValues(CDbl(dGrid.CurrentRow.Cells(3).Value.ToString),
                                  CDbl(dGrid.CurrentRow.Cells(4).Value.ToString),
                                  dGrid.CurrentRow.Index,
                                  CDbl(dGrid.CurrentRow.Cells(6).Value.ToString),
                                  dblSalesTaxRate,
                                  boolItemTaxable)
                End If
            End If
        End If
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
        If chkDeliverySale.Checked = True Then Exit Sub
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
                    .Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left + (0 - 1)
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

    Private Sub btnLaybyePayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaybyePayment.Click
        Me.ActiveControl = Nothing
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
                MessageBox.Show("The selected ticket number can not be receipted right now as it has already been receipted",
                    "Ticket Processed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btnFinish.Enabled = False
            Else
                btnFinish.Enabled = True
                buttonDecoration()
            End If

            'Show the ticket details
            If Not IsDBNull(objReader("SalesRep").ToString) Then
                cboPersonnel.Text = UCase(objReader("SalesRep").ToString)
            End If

            'Read the transactions

            objCommand = New Data.OleDb.OleDbCommand("SELECT TicketSales.ItemCode, TicketSales.Description, " _
                & "TicketSales.SerialNumbers, CAST(TicketSales.SalesPrice AS DECIMAL (30,2)) AS [SalesPrice], " _
                & "TicketSales.Quantity, CAST((TicketSales.SalesPrice * TicketSales.Quantity) AS DECIMAL (30,2)) as [SubTotal], " _
                & "CAST(TicketSales.DiscountAllowed AS DECIMAL (30,2)) AS [Discount], CAST(TicketSales.Taxes AS DECIMAL (30,2)) AS [Taxes], " _
                & "CAST((((TicketSales.SalesPrice * TicketSales.Quantity) - TicketSales.DiscountAllowed) + TicketSales.Taxes) AS DECIMAL (30,2)) AS [Payable], " _
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

    Private Sub txtTicketNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTicketNumber.Validating
        If IsNumeric(txtTicketNumber.Text) Then
            LoadTicketDetails(CLng(txtTicketNumber.Text))
        End If
    End Sub

    Private Sub pdWindows_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdWindows.PrintPage

        ' This will send the printing to the windows type

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
        Me.ActiveControl = Nothing
        If UCase(strUserLevel) = UCase("Cashier") Then
            MessageBox.Show("You do not have sufficient rights to perform this action. Contact your supervisor", "Invoking Unauthorized Process", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            Dim f As New frmDailySales
            f.ShowDialog()
        End If
    End Sub

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
                'Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 80, 600, 80, "OUR BANK DETAILS : " & UCase(strCompanyBankName) & " - ACCOUNT NO : " & UCase(strCompanyAccountNumber) & " BANK CODE : " & UCase(strCompanyBranchCode), prFont, Brushes.Black)
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
        gwt_comm.ShowErrorMessage()
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
            Dim strPrintData As String = strPrintLineDetails(0) & Space(12 - strPrintLineDetails(0).Length) & Space(2) &
                strPrintLineDetails(1) & Space(25 - strPrintLineDetails(1).Length) &
                Space(12 - strPrintLineDetails(2).Length) & strPrintLineDetails(2) &
                Space(8 - strPrintLineDetails(3).Length) & strPrintLineDetails(3) &
                Space(12 - strPrintLineDetails(4).Length) & strPrintLineDetails(4) &
                Space(12 - strPrintLineDetails(5).Length) & strPrintLineDetails(5) &
                Space(12 - strPrintLineDetails(6).Length) & strPrintLineDetails(6) &
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

        Dim strTotalLine As String = "               TOTALS                                        " &
            Space(12 - strSubValue.Length) & strSubValue &
                Space(12 - strDiscValue.Length) & strDiscValue &
                Space(12 - strTaxValue.Length) & strTaxValue &
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
        gwt_comm.ShowErrorMessage()
    End Sub

    '    Private Sub btnQuotation_Click(sender As System.Object, e As System.EventArgs) Handles btnQuotation.Click
    '        Me.ActiveControl = Nothing
    '        On Error GoTo RaiseErr

    '        boolAbort = False
    '        Dim frm As New frmInvoiceCustomerDetails
    '        frm.ShowDialog()
    '        If boolAbort = True Then Exit Sub

    '        Dim strPersonnel As String = strUserName

    '        If dGrid.Rows.Count <= 0 Then
    '            MessageBox.Show("No document transactions to print !!!", "Empty Document Transactions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Exit Sub
    '        End If
    '        If Not String.IsNullOrEmpty(cboPersonnel.Text) Then
    '            strPersonnel = UCase(cboPersonnel.Text)
    '        End If

    '        'Perform the till ring routine
    '        boolAbort = False
    '        dblSaleTotal = CDbl(lblPayable.Text)

    '        If dblSaleTotal <= 0 Then
    '            MessageBox.Show("Sale cannot be processed when there are no valid sub total values", "Sale Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Exit Sub
    '        End If

    '        strCustomerTelephoneNumber = Nothing
    '        strTillCustomerName = Nothing

    '        Cursor = Cursors.WaitCursor

    '        Print_Quotation(Format(Now, "dd-MMM-yyyy"))

    '        Me.lblPayable.Text = "0.00"
    '        Me.lblSubTotal.Text = "0.00"
    '        Me.lblDiscounts.Text = "0.00"
    '        Me.lblTaxes.Text = "0.00"
    '        Me.lblTaxable.Text = "0.00"
    '        'Clear the controls
    '        dGrid.Rows.Clear()
    '        dGrid.Rows.Add(350)
    '        If strPublicMaintainTransactionDate = "NO" Then cboPersonnel.Text = ""
    '        txtReference.Text = ""
    '        txtKeyNumber.Text = ""
    '        txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))
    '        dblAmountChange = 0
    '        dblAmountTendered = 0
    '        boolDeliverySale = False
    '        chkDeliverySale.Checked = False
    '        Cursor = Cursors.Default

    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Quotation Generation Error"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub


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
        arrPrintDetails.Add(Space(2) & UCase(strCompanyAddress1))
        arrPrintDetails.Add(Space(2) & UCase(strCompanyAddress2))
        arrPrintDetails.Add(Space(2) & UCase(strCompanyAddress3))
        arrPrintDetails.Add(Space(2) & UCase(strCompanyAddress4))
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

        Dim strZimDate As String = shortMonthDateFormat(Now)

        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(2) & "TILL OPER :" & UCase(strUserName) & Space(3))
        arrPrintDetails.Add(Space(2) & "SALES REP :")
        If cboPersonnel.Text.Length > 30 Then
            arrPrintDetails.Add(Space(2) & UCase(Mid(cboPersonnel.Text, 1, 30)))
        Else
            arrPrintDetails.Add(Space(2) & UCase(cboPersonnel.Text))
        End If
        ' qqqqqqq
        arrPrintDetails.Add(Space(1) & "DATE AND TIME " & strZimDate & " " & DatePart(DateInterval.Hour, Now) & ":" & DatePart(DateInterval.Minute, Now))
        arrPrintDetails.Add(Space(2) & UCase(strReceiptHeader) & " DATE  " & shortMonthDateFormat(dtReceiptDate))
        arrPrintDetails.Add(Space(2) & " DOC NO " & txtReference.Text & ": KEY " & txtKeyNumber.Text)
        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(1) & "CURRENCY : " & UCase(lblActiveCurrency.Text))
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
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
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


        myRectangle = New Rectangle(x:=intX, y:=intY, width:=intCellWidth, height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Receipt #" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 20, strText, fntDetailsFont, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, width:=intCellWidth, height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = txtReference.Text : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 20, strText, fntDetailsFont, Brushes.Black)

        'Second line boxes
        intY = intY + 18
        intX = 265

        myRectangle = New Rectangle(x:=intX, y:=intY, width:=intCellWidth, height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Date" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFont, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, width:=100, height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = UCase(shortMonthDateFormat(Now)) : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFont, Brushes.Black)

        'Fourth line boxes
        intY = intY + 18
        intX = 265

        myRectangle = New Rectangle(x:=intX, y:=intY, width:=100, height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Time" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFont, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, width:=100, height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = UCase(CStr(Format(Now.Hour, "00")) & ":" & CStr(Format(Now.Minute, "00"))) : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFont, Brushes.Black)

        'Fifth line boxes
        intY = intY + 18
        intX = 265

        myRectangle = New Rectangle(x:=intX, y:=intY, width:=100, height:=intCellHeight + 3)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Cashier" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFont, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, width:=100, height:=intCellHeight + 3)
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

        myRectangle = New Rectangle(x:=intX, y:=intY, width:=intCellWidth, height:=intCellHeight)
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
        myRectangle = New Rectangle(x:=380, y:=463, width:=85, height:=25)
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

    Private Sub btnFinish_Click(sender As Object, e As System.EventArgs) Handles btnFinish.Click
        Me.ActiveControl = Nothing

        Dim dblMainTotal As Double = 0
        If IsNumeric(lblMainTotal.Text) Then dblMainTotal = CDbl(lblMainTotal.Text)

        If dblMainTotal <= 0 Then
            MessageBox.Show("Receipt value cannot be zero !!!",
                    "Empty Document Transactions", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If String.IsNullOrEmpty(strPublicSalesAccount) Then
            MessageBox.Show("Missing the default sales ledger control account. Please set it up. For now the default will be used",
                "Missing Sales Control Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            strPublicSalesAccount = "0000"
        End If

        PrintFiscalReceipt = True

        FinishSale()

        If boolAbort = False Then
            If strPublicSalesAccount = "0000" Then strPublicSalesAccount = Nothing
            lblTransDate.Text = UCase(shortMonthDateFormat(Now))

            dGrid.Enabled = False
            btnFinish.Enabled = False
            dGrid.Rows.Clear()
            dGrid.Rows.Add(350)
        Else
            dGrid.Select()
            dGrid.CurrentCell.Selected = True
        End If

    End Sub

    Private Sub FinishSale(Optional ByVal DocumentType As String = "RECEIPT")

        Dim strSqlTransmit As String = Nothing
        Dim strSelectedId As String
        Dim strDescription As String
        Dim intQty As Double
        Dim dblUprice As Double
        Dim insertCustomer As String
        Dim dblTax As Double
        Dim i As Double
        Dim dpProcessDate As Date = shortMonthDateFormat(DateTime.Now)
        Dim dblDisAmount As Double 'for discounts
        Dim dblSumTaxes As Double = 0, dblSumDiscounts As Double = 0, dblSumPayable As Double = 0
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim dbReader As Data.OleDb.OleDbDataReader

        Dim strTransactionProcessStatus As String = Nothing

        strTillPaymentMethod = Nothing
        arrReceiptData = New ArrayList
        strReceiptFiscalStatus = "NO"

        Dim strPersonnel As String = "CASH PAYMENT"

        dblAmountTendered = 0
        dblAmountChange = 0

        dpProcessDate = CDate(lblTransDate.Text)

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

                If UCase(DocumentType) = UCase("Credit note") Then
                    dblSumPayable = 0 - dblSumPayable
                End If

                'Update the cashbook with the values
                Dim strCashbookDescription As String = "CASH SALE - " & UCase(strPersonnel)
                myCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, " _
                    & "TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, " _
                    & "TransactionType, Reference) VALUES " _
                    & "('" & strPublicActiveCashbook & "', '" & shortMonthDateFormat(dpProcessDate) & "', " _
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
                    & "('" & strPublicSalesAccount & "', '" & shortMonthDateFormat(dpProcessDate) & "', " & dblSumPayable & ", " _
                    & "'CREDIT', '" & strPublicActiveCashbook & "', '" & strCashbookDescription & "-" & strSelectedAccount & "', " _
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
                & "VALUES('" & strSelectedAccount & "', '" & shortMonthDateFormat(dpProcessDate) & "', " _
                & "" & 0 - dblSumPayable & ", 'PAYMENT', 'CASH PAYMENT', '" & txtReference.Text & "', " _
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

            'Perform the till ring routine
            boolAbort = False
            dblSaleTotal = CDbl(lblPayable.Text)

            If dblSaleTotal <= 0 Then
                MessageBox.Show("No document transactions to print !!!",
                    "Empty Document Transactions", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If Not String.IsNullOrEmpty(cboPersonnel.Text) Then
                strPersonnel = UCase(cboPersonnel.Text)
            End If

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

            Dim f As New frmPosCashout ' frmTenderAmount2
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

                    arrInvoiceData.Add(strSelectedId & "|" & strDescription & "|" & intQty & "|" & Format(dblUprice, "##0.00") &
                        "|" & Format((dblUprice * intQty), "##0.00") & "|" & Format(dblDisAmount, "##0.00") & "|" & Format(dblTax, "##0.00") &
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

                    If UCase(DocumentType) = UCase("credit note") Then
                        dblUprice = 0 - dblUprice
                        dblTax = 0 - dblTax
                        dblDisAmount = 0 - dblDisAmount
                        dblItemCostPrice = 0 - dblItemCostPrice
                    End If

                    insertCustomer = "INSERT INTO SALES (CustomerId, InvoiceNumber, TransDate, ItemCode, Quantity, " _
                        & "SalesPrice, TransType, Description, Taxes, DiscountAllowed, ProductType, SerialNumbers, " _
                        & "UserName, SalesRep, CostPrice, KeyNumber, BaseBarcode) VALUES " _
                        & "('0000', " & CDbl(txtReference.Text) & ", '" & CStr(shortMonthDateFormat(dpProcessDate)) & "', " _
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
                            & "('" & strPublicCostOfSales & "', '" & CStr(shortMonthDateFormat(dpProcessDate)) & "', " & dblItemCostPrice & ", " _
                            & "'DEBIT', '" & strPublicPurchasesAccount & "', '" & strDescription & "', " _
                            & "'" & strUserName & "', '" & strUserBranch & "', " & CDbl(txtReference.Text) & ", " & Convert.ToDouble(txtKeyNumber.Text) & ")", cnn)
                        myCommand.ExecuteNonQuery()
                        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                            & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                            & "('" & strPublicPurchasesAccount & "', '" & shortMonthDateFormat(CDate(dpProcessDate)) & "', " & dblItemCostPrice & ", " _
                            & "'CREDIT', '" & strPublicCostOfSales & "', '" & strDescription & "', " _
                            & "'" & strUserName & "', '" & strUserBranch & "', " & CDbl(txtReference.Text) & ", " & Convert.ToDouble(txtKeyNumber.Text) & ")", cnn)
                        myCommand.ExecuteNonQuery()
                    Else
                        MessageBox.Show("The system has detected that you have not set the cost of sales account" & vbCrLf &
                            "This will seriously affect the ledger account and trial balance", "Missing Cost of Sales Account",
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

            strReceiptFiscalStatus = "YES"

            AssignRates()

            Select Case UCase(lblActiveCurrency.Text)
                Case = UCase("USD")
                    dblAmountTenderedUsd = dblSaleTotal
                Case = UCase("ZWL")
                    dblAmountTenderedCash = dblSaleTotal
                Case = UCase("RAND")
                    dblAmountTenderedRand = dblSaleTotal
                Case = UCase("PULA")
                    dblAmountTenderedOther = dblSaleTotal
                Case = UCase("ZWL-TRANSFER")
                    dblAmountTenderedTransfer = dblSaleTotal
                Case = UCase("ZWL-ECOCASH")
                    dblAmountTenderedEcoCash = dblSaleTotal
                Case = UCase("USD-SWIPE")
                    dblAmountTenderedUsd = dblSaleTotal
                Case = UCase("ZWL-SWIPE")
                    dblAmountTenderedSwipe = dblSaleTotal
                Case Else
                    dblAmountTenderedOther = dblSaleTotal
            End Select

            'If UCase(DocumentType) = UCase("credit note") Then
            '    dblSumTaxes = 
            'End If

            'Add the record to the sales main
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO SalesMain (InvoiceNumber, CustomerId, " _
                & "TransDate, Discount, Taxes, Amount, UserName, SalesRep, ContactNumber, ContactName, " _
                & "KeyNumber, PaymentMethod, " _
                & "Cash, EcoCash, Swipe, Transfer, Other, Rand, Usd, " _
                & "BondRate, RandRate, TransferRate, SwipeRate, EcocashRate, " _
                & "FiscalStatus, VatRate) VALUES " _
                & "(" & Convert.ToDouble(txtReference.Text) & ", '0000', '" & CStr(shortMonthDateFormat(dpProcessDate)) & "', " & dblSumDiscounts & ", " _
                & "" & dblSumTaxes & ", " & dblSumPayable & ", '" & lblUserName.Text & "', '" & strPersonnel & "', " _
                & "'" & strCustomerTelephoneNumber & "', '" & strTillCustomerName & "', " _
                & "" & Convert.ToDouble(txtKeyNumber.Text) & ", '" & strTillPaymentMethod & "', " _
                & "" & dblAmountTenderedCash & ", " & dblAmountTenderedEcoCash & ", " & dblAmountTenderedSwipe & ", " _
                & "" & dblAmountTenderedTransfer & ", " & dblAmountTenderedOther & ", " & dblAmountTenderedRand & ", " & dblAmountTenderedUsd & ", " _
                & "" & dblBond_Rate & ", " & dblRand_Rate & ", " & dblTransfer_Rate & ", " & dblSwipe_Rate & ", " & dblEcocash_Rate & ", " _
                & "'" & strReceiptFiscalStatus & "', " & dblSalesTaxRate & ")", cnn)
            myCommand.ExecuteNonQuery()

            'dblRand_Rate,dblBond_Rate, dblTransfer_Rate ,dblSwipe_Rate,dblEcocash_Rate
            'dblAmountTenderedCash 
            If strPublicDirectCashbbookSalesPosting = "YES" Then

                'Update the cashbook with the values
                Dim strCashbookDescription As String = "CASH SALE - " & UCase(strPersonnel)
                myCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, TransactionType, Reference, KeyNumber) VALUES " _
                    & "('" & strPublicActiveCashbook & "', '" & CStr(shortMonthDateFormat(dpProcessDate)) & "', " & dblSumPayable + CDbl(lblTaxes.Text) & ", '" & strCashbookDescription & "', '" & strPublicSalesAccount & "', '" & strUserName & "', " _
                    & "'" & strUserBranch & "', 'DEBIT', " & Convert.ToDouble(txtReference.Text) & ", " & Convert.ToDouble(txtKeyNumber.Text) & ")", cnn)
                myCommand.ExecuteNonQuery()
                '
                'Post the account to the contra ledger account
                '
                myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                    & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference]) VALUES " _
                    & "('" & strPublicSalesAccount & "', '" & CStr(shortMonthDateFormat(dpProcessDate)) & "', " & dblSumPayable & ", 'CREDIT', " _
                    & "'" & strPublicActiveCashbook & "', '" & strCashbookDescription & "', '" & strUserName & "', " _
                    & "'" & strUserBranch & "', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
                myCommand.ExecuteNonQuery()

                'Update the taxes control account as well
                '
                If IsNumeric(lblTaxes.Text) Then
                    If CDbl(lblTaxes.Text) > 0 Then
                        If String.IsNullOrEmpty(strPublicTaxesAccount) Then
                            MessageBox.Show("The taxes control account has not been setup. This will serious affect the trial balance",
                                "Taxes Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            strTransactionProcessStatus = gwt_comm.LedgerEntry("INSERT", CStr(shortMonthDateFormat(dpProcessDate)), strPublicTaxesAccount,
                                strPublicActiveCashbook, "CASH SALE-" & txtReference.Text, CDbl(lblTaxes.Text), "CREDIT",
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

            PrintInvoice(dpProcessDate, DocumentType)

            'If UCase(strPublicReceiptType) = "DESKTOP PRINTER" Then
            '    PrintReceiptQuote("CASH RECEIPT")
            '    'PrintInvoiceTypeCashSlip(CInt(txtReference.Text))
            'Else
            '    'mmm()
            '    If UCase(strPublicReceiptType) = "SOLID A5 RECEIPT" Then
            '        If boolAbort = True Then Exit Sub
            '        'Dim ppd As New PrintPreviewDialog
            '        'ppd.Document = pdLaserReceipt
            '        'ppd.ShowDialog()
            '        pdLaserReceipt.Print()
            '    Else
            '        PrintInvoice(dpProcessDate)
            '    End If
            'End If

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
            lblTransDate.Text = shortMonthDateFormat(Now)
            dblAmountChange = 0
            dblAmountTendered = 0
            boolDeliverySale = False
            chkDeliverySale.Checked = False
            Cursor = Cursors.Default
        End If

        lblMainTotal.Text = "0.00"

        Cursor = Cursors.Default

        dGrid.Select()

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Processing"
        ShowErrorMessage()
    End Sub

    Private Sub AssignRates()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT RandRate, BondRate, TransaferRate, SwipeRate, EcocashRate, UsdRate FROM SystemKeyCurrencyRates"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblRand_Rate = CDbl(objReader(0).ToString)
            If IsNumeric(objReader(1).ToString) Then dblBond_Rate = CDbl(objReader(1).ToString)
            If IsNumeric(objReader(2).ToString) Then dblTransfer_Rate = CDbl(objReader(2).ToString)
            If IsNumeric(objReader(3).ToString) Then dblSwipe_Rate = CDbl(objReader(3).ToString)
            If IsNumeric(objReader(4).ToString) Then dblEcocash_Rate = CDbl(objReader(4).ToString)
            If IsNumeric(objReader(5).ToString) Then dblUS_Rate = CDbl(objReader(5).ToString)
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Key Rates Load"
        ShowErrorMessage()
    End Sub

    Private Sub TransmitSale(ByVal fileString As String)
        strDownloadingType = "SALES"
        ServerDestinationFolder = strWebMainBranch.Replace(" ", "") & "/DailySales"
        strDestinationBranch = strWebMainBranch
        gwt_comm.AddDataChanges(fileString)
    End Sub

    Private Function getShortCode(ByVal itemCode As String) As String
        Dim strReturn As String = Nothing

        Dim strSql As String = "SELECT [ShortCode] FROM [InventoryItems] 
            WHERE [ItemCode] = '" & itemCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0)) Then
                If Not String.IsNullOrEmpty(Trim(objReader(0).ToString)) Then
                    strReturn = Trim(objReader(0).ToString)
                End If
            End If
        End If
        objReader.Close()

        Return strReturn
    End Function

    Private Sub PrintInvoice(ByVal dtReceiptDate As Date,
                             Optional ByVal DocumentType As String = "RECEIPT")
        On Error GoTo RaiseErr

        strCustomerTin = Nothing
        If MessageBox.Show("Do you want to print the customer name on receipt?",
            "Require Customer Name", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            strTillslipCustomerName = Nothing
            Dim boolCurrent As Boolean = boolAbort
            Dim frmName As New frmCustomerName
            frmName.ShowDialog()
            If boolAbort = True Then
                boolAbort = boolCurrent
            End If
        End If

        strType = UCase(strReceiptHeader)
        strSelectedReport = Me.txtReference.Text

        Dim arrFiscalReceiptItems As New ArrayList

        arrPrintDetails = New ArrayList
        '
        'ADD THE BRANCH INFORMATION
        '

        Dim strDocumentHeader As String = "TAX INVOICE"
        If UCase(DocumentType) <> UCase("credit note") Then
            arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
            strDocumentHeader = "************" & UCase(DocumentType) & "*************"
        End If

        If Not String.IsNullOrEmpty(Trim(strCompanyName)) Then
            arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
            arrPrintDetails.Add(Space(2) & UCase(strCompanyName))
        End If
        If Not String.IsNullOrEmpty(Trim(strPublicBranchName)) Then
            arrPrintDetails.Add(Space(2) & UCase(strPublicBranchName))
        End If
        If Not String.IsNullOrEmpty(Trim(strCompanyAddress1)) Then
            arrPrintDetails.Add(Space(2) & UCase(strCompanyAddress1))
        End If
        If Not String.IsNullOrEmpty(Trim(strCompanyAddress2)) Then
            arrPrintDetails.Add(Space(2) & UCase(strCompanyAddress2))
        End If
        If Not String.IsNullOrEmpty(Trim(strCompanyAddress3)) Then
            arrPrintDetails.Add(Space(2) & UCase(strCompanyAddress3))
        End If
        If Not String.IsNullOrEmpty(Trim(strCompanyAddress4)) Then
            arrPrintDetails.Add(Space(2) & UCase(strCompanyAddress4))
        End If
        If Not String.IsNullOrEmpty(Trim(strCompanyTelephone)) Then
            arrPrintDetails.Add(Space(2) & "PHONE: " & strCompanyTelephone)
        End If


        'arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))

        If Not String.IsNullOrEmpty(Trim(strTillslipCustomerName)) Then
            arrPrintDetails.Add(Space(2) & "CUSTOMER NAME: " & UCase(strTillslipCustomerName))
        End If

        If Not String.IsNullOrEmpty(Trim(strCustomerTin)) Then
            arrPrintDetails.Add(Space(2) & "CUSTOMER TIN : " & UCase(strCustomerTin))
        End If
        If Not String.IsNullOrEmpty(Trim(strCustomerTin)) Then
            arrPrintDetails.Add(Space(2) & "CUSTOMER VAT : " & UCase(strTillCustomerVat))
        End If

        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        'arrPrintDetails.Add(Space(2) & StrDup(30, "-"c))
        'arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        '
        'Print based on the grid values
        '
        If Not String.IsNullOrEmpty(strCustomerTelephoneNumber) Then
            arrPrintDetails.Add(Space(2) & "YOUR NO.: " & strCustomerTelephoneNumber)
            arrPrintDetails.Add(Space(2) & StrDup(30, "-"c))
            arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        End If
        Dim dblVatTax As Double = 0


        If boolProcessingAccountPayment = False Then

            With dGrid
                For i As Double = 0 To .Rows.Count - 1

                    Dim strShortCode As String = Nothing
                    strShortCode = getShortCode(Convert.ToString(dGrid.Rows(i).Cells(0).Value))

                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                        Dim strSerial As String = Nothing
                        If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "")) Then
                            strSerial = Convert.ToString(.Rows(i).Cells(2).Value)
                            If strSerial.Length > 30 Then
                                strSerial = Mid(strSerial, 1, 30) & vbCrLf & Mid(strSerial, 31, strSerial.Length)
                            End If
                        End If

                        Dim strDescription As String = strShortCode & " " & strSerial & " " & .Rows(i).Cells(1).Value.ToString
                        Dim strQuantity As String = .Rows(i).Cells(4).Value.ToString
                        Dim strUnitPrice As String = Format(CDbl(.Rows(i).Cells(3).Value.ToString), "#,##0.00")

                        Dim strTax As String = .Rows(i).Cells(7).Value.ToString
                        Dim strTaxFlag As String = ""
                        If IsNumeric(strTax) Then
                            If CDbl(strTax) <> 0 Then
                                strTaxFlag = "T"
                            End If
                        End If

                        Dim strLineTotal As String = Format(CDbl(.Rows(i).Cells(8).Value.ToString), "#,##0.00")
                        If strDescription.Length > 40 Then strDescription = Mid(strDescription, 1, 40)
                        arrPrintDetails.Add(Space(2) & strDescription)

                        If strUnitPrice.Length > 8 Then
                            arrPrintDetails.Add(Space(4) & Space(5 - strQuantity.Length) & strQuantity & " @ ")
                            arrPrintDetails.Add(Space(16 - strUnitPrice.Length) & strUnitPrice & Space(4) & Space(16 - strLineTotal.Length) & strLineTotal & strTaxFlag)
                        Else
                            arrPrintDetails.Add(Space(4) & Space(5 - strQuantity.Length) & strQuantity & " @ " &
                            Space(8 - strUnitPrice.Length) & strUnitPrice & Space(4) & Space(8 - strLineTotal.Length) & strLineTotal & strTaxFlag)
                        End If



                        dblVatTax = dblVatTax + Convert.ToDouble(.Rows(i).Cells(7).Value)

                        If UCase(strPublicTaxFiscalStatus) = "YES" Then

                            Dim strFiscalUnitPrice As String = Format(CDbl(.Rows(i).Cells(3).Value.ToString), "###0.00")
                            Dim strFiscalItemCode As String = .Rows(i).Cells(0).Value.ToString
                            Dim strFiscalTaxCode As String = "A"

                            ' Get the item tax-code
                            '
                            Dim objGetItemTaxCode As New Data.OleDb.OleDbCommand("SELECT TaxCode FROM InventoryItems " _
                                & "WHERE ItemCode = '" & strFiscalItemCode & "'", cnn)
                            Dim objReadTaxCode As Data.OleDb.OleDbDataReader = objGetItemTaxCode.ExecuteReader
                            If objReadTaxCode.HasRows Then
                                objReadTaxCode.Read()
                                If Not IsDBNull(objReadTaxCode(0).ToString) Then strFiscalTaxCode = objReadTaxCode(0).ToString
                            End If
                            objReadTaxCode.Close()

                            arrFiscalReceiptItems.Add(strFiscalItemCode & "|" & strDescription & "|" & strFiscalUnitPrice &
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
        Dim strBondChange As String = Format(dblAmountChangeBond, "##0.00")

        arrPrintDetails.Add(Space(2) & StrDup(30, "-"c))
        arrPrintDetails.Add(Space(2) & "SUBTOTAL        " & Space(14 - lblTaxable.Text.Length) & lblTaxable.Text)
        'arrPrintDetails.Add(Space(2) & StrDup(30, "-"c))
        arrPrintDetails.Add(Space(2) & "VAT CHARGED     " & Space(14 - strTaxCharged.Length) & strTaxCharged)
        'arrPrintDetails.Add(Space(2) & StrDup(30, "-"c))
        arrPrintDetails.Add(Space(2) & "INVOICE TOTAL " & Space(16 - lblPayable.Text.Length) & lblPayable.Text)
        arrPrintDetails.Add(Space(2) & StrDup(30, "-"c))

        arrPrintDetails.Add(Space(2) & "AMOUNT TENDERED " & Space(14 - strTender.Length) & strTender)
        'arrPrintDetails.Add(Space(2) & "CHANGE IN USD   " & Space(14 - strChange.Length) & strChange)
        'arrPrintDetails.Add(Space(2) & "CHANGE IN BOND  " & Space(14 - strChange.Length) & strBondChange)


        Dim strZimDate As String = shortMonthDateFormat(Now)

        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        arrPrintDetails.Add(Space(2) & "TILL OPER :" & UCase(lblUserName.Text) & Space(3))
        'arrPrintDetails.Add(Space(2) & "SALES REP :")

        If cboPersonnel.Text.Length > 30 Then
            arrPrintDetails.Add(Space(2) & UCase(Mid(cboPersonnel.Text, 1, 30)))
        Else
            arrPrintDetails.Add(Space(2) & UCase(cboPersonnel.Text))
        End If

        arrPrintDetails.Add(Space(1) & "DATE AND TIME " & strZimDate & " " & DatePart(DateInterval.Hour, Now) & ":" & DatePart(DateInterval.Minute, Now))
        'arrPrintDetails.Add(Space(2) & UCase(Trim(strReceiptHeader)) & " DATE  " & shortMonthDateFormat(dtReceiptDate))

        If UCase(DocumentType) <> UCase("RECEIPT") Then
            arrPrintDetails.Add(Space(2) & " CR " & txtReference.Text)
            arrPrintDetails.Add(Space(2) & " REF NO " & intOriginalDocumentNumber)
        Else
            arrPrintDetails.Add(Space(2) & " DOC NO " & txtReference.Text)
            arrPrintDetails.Add(Space(2) & " REF NO " & intOriginalDocumentNumber)
        End If

        arrPrintDetails.Add(Space(32))
        If UCase(lblActiveCurrency.Text) = "ZWL" Or
            UCase(lblActiveCurrency.Text) <> UCase("usd") Then
            lblActiveCurrency.Text = "ZiG"
        End If

        arrPrintDetails.Add(Space(1) & "CURRENCY " & UCase(lblActiveCurrency.Text))
        AssignRates()

        Dim strQuery As String = Nothing
        Dim objCommQ As Data.OleDb.OleDbCommand
        Dim objReadStatus As Data.OleDb.OleDbDataReader
        If gwt_comm.CheckColumnExistence("Company", "DisplayRateStatus") = False Then
            strQuery = "ALTER TABLE [Company] ADD [DisplayRateStatus][NVARCHAR](1) Not NULL DEFAULT 'N'"
            objCommQ = New Data.OleDb.OleDbCommand(strQuery, cnn)
            objCommQ.ExecuteNonQuery()
        End If

        Dim boolPrintRates As Boolean = False
        strQuery = "SELECT [DisplayRateStatus] FROM [Company]"
        objCommQ = New Data.OleDb.OleDbCommand(strQuery, cnn)
        objReadStatus = objCommQ.ExecuteReader
        If objReadStatus.HasRows Then
            objReadStatus.Read()
            If Not IsDBNull(objReadStatus(0)) Then
                If Not String.IsNullOrEmpty(objReadStatus(0).ToString) Then
                    If UCase(Trim(objReadStatus(0).ToString)) = "Y" Then
                        boolPrintRates = True
                    End If
                End If
            End If
        End If
        objReadStatus.Close()

        If boolPrintRates = True Then
            'dblBond_Rate & ", " & dblRand_Rate & ", " & dblTransfer_Rate
            arrPrintDetails.Add(Space(1) & "BOND RATE : " & dblBond_Rate)
            arrPrintDetails.Add(Space(1) & "RAND RATE : " & dblRand_Rate)
            arrPrintDetails.Add(Space(1) & "TRNF RATE : " & dblTransfer_Rate)
        End If

        If boolProcessingAccountPayment = False Then
            If arrConditionsOfSale.Count > 0 Then
                arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
                arrPrintDetails.Add(Space(2) & "***** TERMS AND CONDICTIONS *****")
                For j As Double = 0 To arrConditionsOfSale.Count - 1
                    arrPrintDetails.Add(UCase(arrConditionsOfSale.Item(j)))
                Next j
            End If
        End If

        If boolPrintQrCode = False Then
            For i As Double = 0 To 5
                arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
            Next
        End If

        ' Get the user defined path
        Dim strOutputFilePath As String = Nothing
        Dim objGetTillslipPath As New Data.OleDb.OleDbCommand("SELECT [TillslipCopyPath] FROM [Company]", cnn)
        Dim objReadTillslipPath As Data.OleDb.OleDbDataReader = objGetTillslipPath.ExecuteReader
        If objReadTillslipPath.HasRows Then
            objReadTillslipPath.Read()
            If Not IsDBNull(objReadTillslipPath(0)) Then
                If Not String.IsNullOrEmpty(Trim(objReadTillslipPath(0).ToString)) Then
                    strOutputFilePath = Trim(objReadTillslipPath(0).ToString)
                End If
            End If
        End If
        objReadTillslipPath.Close()

        'WRITE EVERY THING TO THE AUDIT FILE and the specified file
        '
        'Dim objsaleGeneric As System.IO.StreamWriter
        'Dim objFileWriter As New System.IO.StreamWriter(strOutputFilePath & "\receipt.txt", False)

        'If Not String.IsNullOrEmpty(strOutputFilePath) Then
        '    objsaleGeneric = New System.IO.StreamWriter(strOutputFilePath & "\receipt.txt", False)
        'End If

        ' GET THE CLIENT FISCUS STATUS

        Dim boolIsFiscalized As Boolean = False

        strQuery = "SELECT [FiscalStatus] FROM [RegionalTaxes] (NOLOCK)"
        objGetTillslipPath = New Data.OleDb.OleDbCommand(strQuery, cnn)
        objReadTillslipPath = objGetTillslipPath.ExecuteReader
        With objReadTillslipPath
            If .HasRows = True Then
                .Read()
                If Not IsDBNull(objReadTillslipPath(0)) Then
                    If Not String.IsNullOrEmpty(Trim(objReadTillslipPath(0).ToString)) Then
                        If Trim(objReadTillslipPath(0).ToString) = UCase("yes") Then
                            boolIsFiscalized = True
                        End If
                    End If
                End If
            End If
            .Close()
        End With

        If printToFiscalPrinter = True Then
            Dim objFileWriter As New System.IO.StreamWriter(strOutputFilePath & "\receipt.txt", False)
            For x As Double = 0 To arrPrintDetails.Count - 1
                objFileWriter.WriteLine(arrPrintDetails.Item(x))
                'If Not String.IsNullOrEmpty(strOutputFilePath) Then
                '    objsaleGeneric.WriteLine(arrPrintDetails.Item(x))
                'End If
            Next
            objFileWriter.Close()
            boolIsFiscalized = True
            Exit Sub
        End If

        'If Not String.IsNullOrEmpty(strOutputFilePath) Then
        '    objsaleGeneric.Close()
        'End If

        'If String.IsNullOrEmpty(Trim(strOutputFilePath)) Then
        strOutputFilePath = Application.StartupPath & "\Tillslip.txt"
        Dim objLocalFileWriter As New System.IO.StreamWriter(strOutputFilePath, False)
        For x As Double = 0 To arrPrintDetails.Count - 1
            objLocalFileWriter.WriteLine(arrPrintDetails.Item(x))
        Next
        objLocalFileWriter.Close()

        'End If

        'If Not String.IsNullOrEmpty(strOutputFilePath) Then
        'If boolIsFiscalized = True Then
        '    Exit Sub
        'Else

        '
        'PRINTS FROM A FILE DIRECTLY TO THE PRINTER
        '
        'Try printing using the line printer. Allow the user to select a file.

        qrcodePrintData = Replace(strCompanyName, " ", "", 1) & "_" &
            shortMonthDateFormat(Now) & "_" & txtReference.Text & "_" &
            CStr(intOriginalDocumentNumber)
        qrcodePrintData = qrcodePrintData.ToLower

        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()
        Dim output As String = Chr(&H1D) & "V" & Chr(66) & Chr(0) 'Feeds paper & cut
        Dim strPrintToFiscalPrinter As String = strPublicTaxFiscalStatus
        If PrintFiscalReceipt = False Then
            strPrintToFiscalPrinter = "NO"
        End If

        strPublicPrinterType = "WINDOWS"
        strRequestForReceiptPrinter = "YES"

        strQuery = "SELECT [RequestForReceiptPrinter] FROM [Company] (NOLOCK)"
        Dim objCom As New Data.OleDb.OleDbCommand(strQuery, cnn)
        Dim objRead As Data.OleDb.OleDbDataReader = objCom.ExecuteReader
        With objRead
            If .HasRows = True Then
                .Read()
                If Not IsDBNull(objRead(0)) Then
                    If Not String.IsNullOrEmpty(Trim(objRead(0).ToString)) Then
                        strRequestForReceiptPrinter = UCase(Trim(objRead(0).ToString))
                    End If
                End If
            End If
            .Close()
        End With

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

                ' PRINT THE QR CODE
                '
                If boolPrintQrCode = True Then

                    Dim selectedPrinter As String = strSessionPrinter 'cmbPrinters.SelectedItem.ToString()
                    Dim printer As New QRCodePrinter(selectedPrinter, strCompanyName, strLogoPath, arrPrintDetails)

                    ' Print QR Code
                    Dim labelText As String = Nothing 'If(String.IsNullOrEmpty(txtLabel.Text), "", txtLabel.Text)
                    Dim qrText As String = qrcodePrintData

                    printer.GenerateAndPrintQRCode(
                        data:=qrText, 'txtData.Text,
                        pixelsPerModule:=20,
                        quietZoneModules:=4,
                        labelText:=labelText,
                        paperWidthMm:=80,  ' 58mm standard thermal paper
                        printCopies:=1)

                Else
                    Dim ppd As New PrintPreviewDialog
                    ppd.Document = pdWindows
                    pdWindows.Print()
                End If
                Exit Sub
            End If

            'Cut the paper on thermal printers
            If strPublicCutReceipt = "YES" Then
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, output)
            End If
        End If


        'If strPrintToFiscalPrinter = "YES" Then
        '    'If strReceiptFiscalStatus = "YES" Then
        '    'Dim dblTotalAmountTenderedOnSale As Double = dblAmountTenderedCash + dblAmountTenderedEcoCash + dblAmountTenderedSwipe + dblAmountTenderedTransfer + dblAmountTenderedOther

        '    FiscalReceipt(arrFiscalReceiptItems, dblReceiptValue)
        '    Exit Sub
        '    'End If

        '    'End If
        'Else
        '    'If strPublicTaxFiscalStatus = "NO" Or strReceiptFiscalStatus = "NO" Then

        '    If strPublicConfirmReceiptPrint = "YES" Then
        '        If MessageBox.Show("Do you want to print the receipt right now?", "Confirm Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '            If strRequestForReceiptPrinter = "YES" Then
        '                boolAbort = False
        '                Dim f As New frmPrinterSetup
        '                f.ShowDialog()
        '                If boolAbort = True Then Exit Sub
        '                pd.PrinterSettings.PrinterName = strSessionPrinter
        '            End If
        '            If UCase(strPublicPrinterType) = "RAW" Then
        '                For n = 0 To arrPrintDetails.Count - 1
        '                    Dim strPrintLineDetails As String = arrPrintDetails.Item(n) & vbCrLf
        '                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintLineDetails)
        '                Next
        '            Else
        '                Dim ppd As New PrintPreviewDialog
        '                ppd.Document = pdWindows
        '                pdWindows.Print()
        '                Exit Sub
        '            End If

        '            'Cut the paper on thermal printers
        '            If strPublicCutReceipt = "YES" Then
        '                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, output)
        '            End If
        '        End If

        '    End If

        'End If

        'End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Processing"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAccountPayment_Click(sender As Object, e As System.EventArgs) Handles btnAccountPayment.Click
        Me.ActiveControl = Nothing
        boolProcessingAccountPayment = True
        strSelectedAccount = Nothing 'txtaccountnumber
        strSelectedAccountName = Nothing 'txtaccountholdername
        'Reset the grid
        dGrid.Rows.Clear()
        dGrid.Rows.Add(350)
        lblDiscounts.Text = "0.00"
        lblPayable.Text = "0.00"
        lblSubTotal.Text = "0.00"
        lblTaxable.Text = "0.00"
        lblTaxes.Text = "0.00"
        boolAbort = False
        'Browse for customer
        gwt_comm.CustomerSearch()

        If boolAbort = True Then
            boolProcessingAccountPayment = False
            Exit Sub
        Else
            FinishSale()
        End If
        boolProcessingAccountPayment = False
    End Sub

    Private Sub btnExchangePlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExchangePlus.Click
        Me.ActiveControl = Nothing
        Dim f As New frmSalesReturnsPlus
        f.ShowDialog()
    End Sub

    Private Sub btnExchange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExchange.Click
        Me.ActiveControl = Nothing
        Dim f As New frmSalesReturns
        f.ShowDialog()
    End Sub

    Private Sub GetExpensesFormCaptureType()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ClassicExpensesCaptureStatus FROM Company", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        boolClassicExpensesCapture = True
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(objReader(0).ToString) = "NO" Then
                    boolClassicExpensesCapture = False
                End If
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Expenses Capture"
        gwt_comm.ShowErrorMessage()
    End Sub
    Private Sub btnExpenses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpenses.Click
        Me.ActiveControl = Nothing
        boolAbort = False
        gwt_comm.CashbookSelection()
        If boolAbort = True Then Exit Sub
        gwt_comm.ExpensesCapture(boolClassicExpensesCapture)
    End Sub

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
                gwt_comm.SuperUserAuthentication()
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
        cboPersonnel.Focus()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to populate delivery items on to the sales form"
        ShowErrorMessage()
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
            MessageBox.Show("There were errors encountered when transmit sales data." &
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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click
        Me.ActiveControl = Nothing
        strPublicItemCode = Nothing
        strFullItemDetails = Nothing
        boolAbort = False
        gwt_comm.InventorySearch()
        If boolAbort = True Then Exit Sub
        If boolAbort = True Then
            'Clear the current row values
            ClearCurrentRowValues(dGrid.CurrentRow.Index)
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(strFullItemDetails) Then
            CommitValueChanged()
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(1)
        End If
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
                lblTransDate.Text = UCase(shortMonthDateFormat(dtSetDate))
                boolAuthorized = False
            End If
        End If
        If boolAbort = True Then Exit Sub
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Me.ActiveControl = Nothing
        If dGrid.Rows.Count > 0 Then
            dGrid.CurrentCell = dGrid.CurrentRow.Cells(1)
            dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
            Dim iBal As Integer = 350 - dGrid.Rows.Count
            dGrid.Rows.Add(iBal)
            RecalculateAmount()
            ComputeTotals()
        End If
    End Sub

    Private Sub FiscalReceipt(ByVal arrItems As ArrayList, ByVal AmountTendered As Double)
        'Dim obj As New EltradeFprn
        'With obj

        '    Dim lResult As Long = .Init(FiscalSerialPortNumber, FiscalBaudrate, 0, 1, 0, Nothing)

        '    If lResult <> 0 Then
        '        MessageBox.Show("Failed to init connection with printer: " & vbCrLf & .GetErrCodeText(lResult, 0),
        '            "Printer Initialize Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    End If

        '    .CurrencyID = intPublicFiscalCurrency

        '    ' Start the bon? Header printing
        '    '

        '    Dim strTaxNumber As String = "123456"

        '    Dim strQuery As String = "SELECT FiscalBonType FROM Company"
        '    Dim objCommGet As New Data.OleDb.OleDbCommand(strQuery, cnn)
        '    Dim objReadComm As Data.OleDb.OleDbDataReader = objCommGet.ExecuteReader
        '    If objReadComm.HasRows Then
        '        objReadComm.Read()
        '        If Not IsDBNull(objReadComm(0)) Then
        '            If IsNumeric(objReadComm(0).ToString) Then
        '                intFiscalBonType = CInt(objReadComm(0).ToString)
        '            End If
        '        End If
        '    End If
        '    objReadComm.Close()

        '    If intFiscalBonType = 0 Then intFiscalBonType = 2

        '    lResult = .StartBon(intFiscalBonType, 1, UCase(strPublicActiveFullUserName), CStr(gwt_comm.GetNextDocumentNumber("CashSales")),
        '                        strTaxNumber, strCompanyVatNumber, UCase(strCompanyName), "HARARE",
        '                        "7 GEORGE SILUNDIKA AVE, KUWIRIRANA HSE", "MRP", "Recipient")

        '    If lResult <> 0 Then
        '        MessageBox.Show("Failed to print key details: " & vbCrLf & .GetLastError(1),
        '            "Key Details Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    End If

        '    ' Print the items
        '    '
        '    Dim strTaxCode As String = "1"

        '    ' .Add("1003|SAMSUNG J4|170.00|3.00|" & strTaxCode)

        '    For i As Integer = 0 To arrItems.Count - 1
        '        Dim strBuffer() As String = Split(arrItems.Item(i), "|")
        '        'If Not IsNumeric(strBuffer(4)) Then
        '        strBuffer(4) = "1"

        '        If Not IsNumeric(strBuffer(2)) Then strBuffer(2) = "0"
        '        Dim dblItemValue As Double = CDbl(strBuffer(2)) * dblActiveExchangeRate
        '        dblItemValue = Math.Round(dblItemValue, 2)

        '        .PLUCurrencyID = intPublicFiscalCurrency
        '        lResult = .AddPLU(strBuffer(0), strBuffer(1), dblItemValue, strBuffer(3), strBuffer(4))

        '        If lResult <> 0 Then
        '            MessageBox.Show("Failed to print item: " & vbCrLf & .GetLastError(1),
        '            "Item Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            lResult = .EndBon()
        '            .Close()
        '            Cursor = DefaultCursor
        '            Exit Sub
        '        End If
        '    Next

        '    ' Add discount if any. Personally put discounts before comments
        '    '

        '    If IsNumeric(lblDiscounts.Text) Then
        '        If CDbl(lblDiscounts.Text) <> 0 Then
        '            .AddDiscount(3, 0 - CDbl(lblDiscounts.Text))
        '        End If
        '    End If

        '    ' Add the payment line
        '    '

        '    .AddPayment(1, "CASH", dblReceiptValue, 1)

        '    ' Add the comment and condition lines
        '    '

        '    Dim arrComments As New ArrayList
        '    With arrComments
        '        .Add("     ")
        '        .Add("*** 6 MONTH GUARANTEE ON ORIGINAL PHONES ***")
        '        .Add("*** 1 MONTH GUARANTEE ON PHONE BATTERIES ***")
        '        .Add("*** NO CASH REFUNDS ON ALL PRODUCTS SOLD ***")
        '    End With

        '    For i As Integer = 0 To arrComments.Count - 1
        '        .AddLine(arrComments.Item(i), "BOLD", 0)
        '    Next

        '    'End the receipt printing
        '    lResult = .EndBon()
        '    .Close()

        'End With
    End Sub

    Private Sub mtZreport_Click(sender As Object, e As EventArgs) Handles mtZreport.Click
        'Me.ActiveControl = Nothing
        'If strPublicTaxFiscalStatus = "YES" Then
        '    Dim obj As New EltradeFprn
        '    With obj
        '        Dim lResult As Long = .Init(FiscalSerialPortNumber, FiscalBaudrate, 0, 1, 0, Nothing)
        '        If lResult <> 0 Then
        '            MessageBox.Show("Failed to init connection with printer: " & vbCrLf & .GetErrCodeText(lResult, 0),
        '                "Printer Initialize Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            Exit Sub
        '        End If
        '        lResult = .RunZReport()
        '        'End the printing
        '        'lResult = .EndBon()
        '        .Close()
        '    End With
        'Else
        '    MessageBox.Show("You company is not fiscalized. Please contact your tax authorities for assistance", "Fiscal Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If
    End Sub

    Private Sub btnTestFiscalPrinter_Click(sender As Object, e As EventArgs) Handles btnTestFiscalPrinter.Click
        'Me.ActiveControl = Nothing
        'Dim obj As New EltradeFprn

        ''Dim intComport As Integer = InputBox("Please enter the printer com port number", "Com Port", "1")

        'boolAbort = False
        'Dim frm As New frmFiscalTestParameters
        'frm.ShowDialog()
        'If boolAbort = True Then Exit Sub

        'With obj
        '    Dim lResult As Long = .Init(intPublicTestFiscalCommPort, 115200, 0, 1, 0, Nothing)
        '    'var res = efp.Init(parseInt(comport.value, 10), 115200, 0, 0, 0, "");
        '    If lResult <> 0 Then
        '        MessageBox.Show("Failed to init connection with printer: " & vbCrLf & .GetLastError(1),
        '            "Printer Initialize Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    End If

        '    ' set the currency here based on user selection
        '    '
        '    ' 1 = ZWL
        '    ' 2 = USD
        '    ' 3 = RAND
        '    ' 4 = PULA
        '    '
        '    .CurrencyID = intPublicFiscalCurrency

        '    ' Start the bon? Header printing
        '    '
        '    Dim strQuery As String = "SELECT FiscalBonType FROM Company"
        '    Dim objCommGet As New Data.OleDb.OleDbCommand(strQuery, cnn)
        '    Dim objReadComm As Data.OleDb.OleDbDataReader = objCommGet.ExecuteReader
        '    If objReadComm.HasRows Then
        '        objReadComm.Read()
        '        If Not IsDBNull(objReadComm(0)) Then
        '            If IsNumeric(objReadComm(0).ToString) Then
        '                intFiscalBonType = CInt(objReadComm(0).ToString)
        '            End If
        '        End If
        '    End If
        '    objReadComm.Close()
        '    If intFiscalBonType = 0 Then intFiscalBonType = 2

        '    Dim strTaxNumber As String = "123456"
        '    lResult = .StartBon(intFiscalBonType, 0, UCase(strPublicActiveFullUserName), CStr(gwt_comm.GetNextDocumentNumber("CashSales")),
        '                        strTaxNumber, strCompanyVatNumber, UCase(strCompanyName), "HARARE",
        '                        "7 GEORGE SILUNDIKA AVE, KUWIRIRANA HSE", "MRP", "Recipient")
        '    If lResult <> 0 Then
        '        MessageBox.Show("Failed to print key details: " & vbCrLf & .GetErrCodeText(lResult, 0),
        '            "Key Details Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    End If

        '    'End the printing of the bon?
        '    ' lResult = .EndBon()

        '    'Print the items
        '    Dim strTaxCode As String = "1"

        '    '150.00 is the unit price
        '    '2.00 is the quantity
        '    '1001 is the item code

        '    Dim arrItems As New ArrayList
        '    With arrItems
        '        .Add("1001|SAMSUNG J2|1.00|2.00|" & strTaxCode)
        '        '.Add("1002|SAMSUNG J3|0.00|1.00|" & strTaxCode)
        '        '.Add("1003|SAMSUNG J4|0.00|3.00|" & strTaxCode)
        '        '.Add("1004|SAMSUNG J5|0.00|1.00|" & strTaxCode)
        '    End With

        '    For i As Integer = 0 To arrItems.Count - 1
        '        Dim strBuffer() As String = Split(arrItems.Item(i), "|")
        '        .PLUCurrencyID = intPublicFiscalCurrency
        '        lResult = .AddPLU(strBuffer(0), strBuffer(1), strBuffer(2), strBuffer(3), strBuffer(4))
        '        'lResult = .AddPLU("3", "PLU number 3", 3.45, 5, 2)
        '        If lResult <> 0 Then
        '            MessageBox.Show("Failed to print item: " & vbCrLf & .GetLastError(1),
        '            "Item Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            Exit Sub
        '        End If
        '    Next

        '    'Add discount if any. Personnaly put discounts before comments
        '    .AddDiscount(3, -50.0)

        '    'Add the payment line

        '    ' ********** PAYMENT CODES 
        '    '
        '    ' 1 = ZWL
        '    ' 2 = USD
        '    ' 3 = RAND
        '    ' 4 = PULA


        '    .AddPayment(1, "CASH", 2000, 1)

        '    'Add the comment and condition lines
        '    Dim arrComments As New ArrayList
        '    With arrComments
        '        .Add("     ")
        '        .Add("*** 6 MONTH GUARANTEE ON ORIGINAL PHONES ***")
        '        .Add("*** 1 MONTH GUARANTEE ON PHONE BATTERIES ***")
        '        .Add("*** NO CASH REFUNDS ON ALL PRODUCTS SOLD ***")
        '        '.Add(Nothing)
        '        '.Add(UCase(CStr(Now)))
        '    End With

        '    For i As Integer = 0 To arrComments.Count - 1
        '        .AddLine(arrComments.Item(i), "BOLD", 0)
        '    Next

        '    'lResult = .RunPrinterTest()
        '    'If lResult <> 0 Then
        '    '    MessageBox.Show("Test print failure: " & vbCrLf & .GetErrCodeText(lResult, 0),
        '    '        "Item Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    '    Exit Sub
        '    'End If

        '    'End the receipt printing
        '    lResult = .EndBon()
        '    .Close()

        'End With

        ''Dim frm As New frmPosTest
        ''frm.ShowDialog()

    End Sub

    Private Function GetProductSalesCount(ByVal ProductCode As String) As Integer
        On Error GoTo RaiseErr
        Dim intReturn As Integer = 0

        Dim FirstDay As Date = DateSerial(Today.Year, Today.Month, 1)
        Dim LastDay As Date = DateSerial(Today.Year, Today.Month + 1, 0)

        Dim strSql As String = "SELECT COUNT(ItemCode) FROM Sales WHERE ItemCode = '" & ProductCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intReturn = CInt(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        Return intReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On product sales count fetch"
        ShowErrorMessage()
        Return 0
    End Function

    Public Sub PrintRecept()

        'lblResults.ForeColor = Color.Black
        'lblResults.Text = "..."
        'lblResults.Text = ""

        'Dim efp As New EltradeFprn
        'Dim res As Long
        'res = efp.Init(intComPortNumber, 115200, 0, 0, 0, "")

        'Dim recepttype As Integer = 2

        'If res > 0 Then
        '    lblResults.Text = efp.GetErrCodeText(res, 1)
        '    lblResults.ForeColor = Color.Red
        '    lblResults.Text = efp.GetLastError(1)
        '    lblResults.ForeColor = Color.Red
        'Else
        '    res = efp.StartBon(recepttype, 1, "Cashier 1", "9000000001", "123456789", "BG123456789", "Company Name", "City", "Address", "MOL", "Receiver")
        '    If res > 0 Then
        '        lblResults.Text = efp.GetErrCodeText(res, 1)
        '        lblResults.ForeColor = Color.Red
        '        lblResults.Text = efp.GetLastError(1)
        '        lblResults.ForeColor = Color.Red
        '    Else
        '        res = efp.AddLine(" ", "", 1)
        '        If res = 0 Then
        '            res = efp.AddLine("Free text at the top of receipt.", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine(" ", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine("Dbwidth sample", "DBWIDTH", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine("Dbstrike sample", "DBSTRIKE", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine("Underline sample", "UNDERLINE", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine(" ", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine("Sample PLU with percentage add on", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine(" ", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddPlu("1", "PLU number 1", 1.23, 1, 0)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddDiscount(1, 10.0)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine(" ", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddPlu("2", "PLU number 2", 2.34, 2.25, 2)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine(" ", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddPlu("3", "PLU number 3", 3.45, 5, 2)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine(" ", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine("Sample of PLU refund", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine(" ", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddPlu("4", "PLU number 4", 1.55, -1, 2)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine(" ", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine("Sample of STL discount", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine(" ", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddDiscount(2, -10.0)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine(" ", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine("Free text at the end of receipt.", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddLine(" ", "", 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddPayment(2, "CARD", 2, 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.AddPayment(1, "CASH", 100, 1)
        '        End If
        '        If res = 0 Then
        '            res = efp.EndBon()
        '        End If
        '        If res > 0 Then
        '            lblResults.Text = efp.GetErrCodeText(res, 1)
        '            lblResults.ForeColor = Color.Red
        '            lblResults.Text = efp.GetLastError(1)
        '            lblResults.ForeColor = Color.Red
        '        Else
        '            lblResults.Text = "Print test recept -> OK (Recept number: " & efp.GetLastBonNumber() & ")"
        '        End If
        '    End If
        '    efp.Close()
        'End If
    End Sub

    Private Sub btnDateOveride_Click(sender As System.Object, e As System.EventArgs) Handles btnDateOveride.Click
        Me.ActiveControl = Nothing
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
            boolAbort = False
            boolAuthorized = False
            gwt_comm.SuperUserAuthentication()
            If boolAbort = True Then Exit Sub
            gwt_comm.DateSpecification()
            If boolAbort = True Then Exit Sub
            If boolAuthorized = True Then
                lblTransDate.Text = UCase(shortMonthDateFormat(dtSetDate))
                dGrid.Select()
                boolAuthorized = False
            End If
        End If
        If boolAbort = True Then Exit Sub
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Me.ActiveControl = Nothing
    End Sub

    Private Sub btnKeyPads_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyPads.Click
        Me.ActiveControl = Nothing

    End Sub

    Private Sub btnPrintPeriodReport_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintPeriodReport.Click
        'Me.ActiveControl = Nothing
        'If strPublicTaxFiscalStatus = "YES" Then
        '    Dim obj As New EltradeFprn
        '    With obj
        '        Dim lResult As Long = .Init(FiscalSerialPortNumber, FiscalBaudrate, 0, 1, 0, Nothing)
        '        If lResult <> 0 Then
        '            MessageBox.Show("Failed to init connection with printer: " & vbCrLf & .GetErrCodeText(lResult, 0),
        '                "Printer Initialize Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '            Exit Sub
        '        End If
        '        StartDate = Nothing
        '        EndDate = Nothing
        '        boolAbort = False
        '        gwt_comm.DateRangeSpecification()
        '        If boolAbort = False Then
        '            Dim strDetailLength As String = InputBox("Please enter number for report lenth.", "Fiscal Printer Report", "1", 500, 300)
        '            If Not IsNumeric(strDetailLength) Then strDetailLength = "1"
        '            lResult = .RunFMDateReport(StartDate, EndDate, CLng(strDetailLength))
        '            StartDate = Nothing
        '            EndDate = Nothing
        '        End If
        '        'End the printing
        '        'lResult = .EndBon()
        '        .Close()
        '    End With
        'Else
        '    MessageBox.Show("You company is not fiscalized. Please contact your tax authorities for assistance", "Fiscal Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If
    End Sub

    Private Sub btnCheckEquivalence_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckEquivalence.Click
        Dim frm As New frmDailyCurrencyEquivalence
        frm.ShowDialog()
    End Sub

    Private Sub btnPos_Click(sender As Object, e As EventArgs) Handles btnPos.Click
        Me.ActiveControl = Nothing

        Dim dblMainTotal As Double = 0
        If IsNumeric(lblMainTotal.Text) Then dblMainTotal = CDbl(lblMainTotal.Text)

        If dblMainTotal <= 0 Then
            MessageBox.Show("Receipt value cannot be zero !!!",
                    "Empty Document Transactions", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If String.IsNullOrEmpty(strPublicSalesAccount) Then
            MessageBox.Show("Missing the default sales ledger control account. Please set it up. For now the default will be used",
                "Missing Sales Control Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            strPublicSalesAccount = "0000"
        End If

        FinishSale()

        PrintFiscalReceipt = False

        If strPublicSalesAccount = "0000" Then strPublicSalesAccount = Nothing
        lblTransDate.Text = UCase(shortMonthDateFormat(Now))
    End Sub

    Private Sub btnBeginSale_Click(sender As Object, e As EventArgs) Handles btnBeginSale.Click
        boolAbort = False
        Dim frm As New frmBeginSale
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        dGrid.Enabled = True
        btnFinish.Enabled = True
        buttonDecoration()
        lblActiveCurrency.Text = UCase(strSaleCurrencyUsed)
    End Sub

    Private Sub dGrid_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dGrid.CellBeginEdit
        If UCase(dGrid.Columns(dGrid.CurrentCell.ColumnIndex).HeaderText) = UCase("Qty") Then
            e.Cancel = False
        Else
            e.Cancel = AllowOnFlyPriceChange()
        End If
    End Sub

    Private Function AllowOnFlyPriceChange() As Boolean

        On Error GoTo RaiseErr

        Dim boolReturn As Boolean = True

        Dim strSql As String = Nothing

        Dim objCommand As Data.OleDb.OleDbCommand
        If gwt_comm.CheckColumnExistence("Company", "AllowPriceChangeOnSale") = False Then
            strSql = "ALTER TABLE [Company] ADD 
	            [AllowPriceChangeOnSale][NVARCHAR](1) NOT NULL DEFAULT 'N'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        strSql = "SELECT [AllowPriceChangeOnSale] 
            FROM [Company]"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0)) Then
                If Not String.IsNullOrEmpty(Trim(objReader(0).ToString)) Then
                    If UCase(Trim(objReader(0).ToString)) = UCase("y") Then
                        boolReturn = False
                    End If
                End If
            End If
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        Return False
    End Function

    Private Sub dGrid_LostFocus(sender As Object, e As EventArgs) Handles dGrid.LostFocus

    End Sub

    Private Sub btnCreditNote_Click(sender As Object, e As EventArgs) Handles btnCreditNote.Click
        intOriginalDocumentNumber = 0
        boolAbort = True
        Dim frm As New frmCreditNoteOriginalNo
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        Me.ActiveControl = Nothing

        Dim dblMainTotal As Double = 0
        If IsNumeric(lblMainTotal.Text) Then dblMainTotal = CDbl(lblMainTotal.Text)

        If dblMainTotal <= 0 Then
            MessageBox.Show("Receipt value cannot be zero !!!",
                    "Empty Document Transactions", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If String.IsNullOrEmpty(strPublicSalesAccount) Then
            MessageBox.Show("Missing the default sales ledger control account. Please set it up. For now the default will be used",
                "Missing Sales Control Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            strPublicSalesAccount = "0000"
        End If

        PrintFiscalReceipt = True

        FinishSale("CREDIT NOTE")

        If boolAbort = False Then
            If strPublicSalesAccount = "0000" Then strPublicSalesAccount = Nothing
            lblTransDate.Text = UCase(shortMonthDateFormat(Now))

            dGrid.Enabled = False
            btnFinish.Enabled = False
            dGrid.Rows.Clear()
            dGrid.Rows.Add(350)
        Else
            dGrid.Select()
            dGrid.CurrentCell.Selected = True
        End If

    End Sub

    Private Sub btnPos_LostFocus(sender As Object, e As EventArgs) Handles btnPos.LostFocus

    End Sub
End Class
