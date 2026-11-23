Imports System.Drawing.Printing
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSalesReturnsPlus

    Dim arrPrintDetails As ArrayList

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSalesData() As String = gwt_comm.SalesInventoryItems(strMainCompanyServiceOffering, strDefaultSearchFilter)
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSalesData(0), cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItemNew
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
        Dim intItemsCount As Integer = CDbl(strSalesData(1))
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem
        Dim DropDownItemsNew(intItemsCount - 1) As MTGCComboBoxItem

        cboItemNew.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2), strRecordText(3))
                DropDownItemsNew(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2), strRecordText(3))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboItemNew.SelectedIndex = -1
            cboItemNew.Items.Clear()
            cboItemNew.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboItemNew.Items.AddRange(DropDownItemsNew)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmSalesReturnsPlus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
        txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))
    End Sub

    Private Sub computeDifference()
        If Not IsNumeric(lblAmountNew.Text) Then lblAmountNew.Text = "0.00"
        If Not IsNumeric(lblReturnTotal.Text) Then lblReturnTotal.Text = "0.00"
        Dim dblItemsTotal As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1

            Dim intQty As Integer = 0
            Dim dblUnitPrice As Double = 0
            Dim dblDiscount As Double = 0
            Dim dblTaxes As Double = 0
            Dim dblPayable As Double = 0
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    intQty = CInt(dGrid.Rows(i).Cells(2).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    dblUnitPrice = CDbl(dGrid.Rows(i).Cells(3).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                    dblDiscount = CDbl(dGrid.Rows(i).Cells(5).Value.ToString)
                End If
            End If
            dblItemsTotal = dblItemsTotal + ((dblUnitPrice * intQty) - dblDiscount)
        Next
        txtTopUpAmount.Text = Format((dblItemsTotal - CDbl(lblReturnTotal.Text)), "##0.00")
    End Sub

    Private Sub cboItemNew_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItemNew.SelectedIndexChanged
        On Error Resume Next
        lblDescriptionNew.Text = "" : lblAmountNew.Text = ""
        lblDescriptionNew.Text = cboItemNew.SelectedItem.Col2
        lblAmountNew.Text = cboItemNew.SelectedItem.Col3
        On Error GoTo RaiseErr
        txtSerialNumbers.Items.Clear()
        Dim strItemType As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT InventoryType FROM InventoryItems WHERE ItemCode = '" & cboItemNew.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(objReader(0).ToString) = "SPECIFIC" Then
                    'Get the serial numbers
                    lblInventoryType.Text = "SPECIFIC"
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumber FROM SerialNumbers WHERE ItemCode = '" & cboItemNew.Text & "'", cnn)
                    Dim objReadSerials As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    While objReadSerials.Read
                        txtSerialNumbers.Items.Add(UCase(objReadSerials(0).ToString))
                    End While
                    objReadSerials.Close()
                Else
                    lblInventoryType.Text = "GENERIC"
                End If
            End If
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Serial Numbers Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If Not IsNumeric(txtDocNo.Text) Then
            MessageBox.Show("Please enter the original document number", "Missing Original Document Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocNo.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtReason.Text) Then
            MessageBox.Show("There must be a reason why item is exchanged. Please enter it", "Missing Reason For Exchange", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtReason.Focus()
            Exit Sub
        End If
        If Not IsNumeric(lblAmountOld.Text) Then lblAmountOld.Text = "0.00"
        If Not IsNumeric(txtTopUpAmount.Text) Then
            MessageBox.Show("The top up amount is invalid.", "Invalid Top Up Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If CDbl(txtTopUpAmount.Text) < 0 Then
            MessageBox.Show("Exchange transaction top up cannot be less than 0.", "Invalid Exchange Top Up Process", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim objCommand As Data.OleDb.OleDbCommand
        'Update the inventory serial numbers table
        For i As Integer = 0 To grdInvoice.Rows.Count - 1
            If grdInvoice.Rows(i).Cells(0).Value = True Then
                Dim strSalesItemCode As String = Nothing
                Dim strSalesSerialNo As String = Nothing
                If Not (Object.Equals(Convert.ToString(grdInvoice.Rows(i).Cells(1).Value), "")) Then
                    strSalesItemCode = grdInvoice.Rows(i).Cells(1).Value.ToString
                End If

                If Not (Object.Equals(Convert.ToString(grdInvoice.Rows(i).Cells(8).Value), "")) Then
                    strSalesSerialNo = grdInvoice.Rows(i).Cells(8).Value.ToString
                End If

                'Get the base barcode
                Dim strBaseBarcode As String = Nothing
                Dim strSourceSerialNumber As String = Nothing
                objCommand = New Data.OleDb.OleDbCommand("SELECT SourceSerialNo, BaseBarcode, CostPrice FROM Sales " _
                    & "WHERE InvoiceNumber = " & txtDocNo.Text & " AND Sales.ItemCode = '" & strSalesItemCode & "' " _
                    & "AND SerialNumbers = '" & strSalesSerialNo & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                Dim dblOriginalCostPrice As Double = 0
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then strSourceSerialNumber = objReader(0).ToString
                    If Not IsDBNull(objReader(1).ToString) Then strBaseBarcode = objReader(1).ToString
                    If IsNumeric(objReader(2).ToString) Then dblOriginalCostPrice = CDbl(objReader(2).ToString)
                End If
                objReader.Close()

                If Not String.IsNullOrEmpty(strSalesSerialNo) Then
                    Dim strSql As String = "INSERT INTO SerialNumbers ([ItemCode], [SerialNumber], [BarCodeNo], " _
                        & "[SourceSerialNo], [CostPrice], [Availability]) VALUES ('" & strSalesItemCode & "', " _
                        & "'" & strSalesSerialNo & "', '" & strBaseBarcode & "', " _
                        & "'" & Trim(strBaseBarcode & strSalesSerialNo) & "', " _
                        & "" & dblOriginalCostPrice & ", 'Y')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If

                'Update the inventory items table
                objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = (Quantity + 1) " _
                    & "WHERE ItemCode = '" & strSalesItemCode & "'", cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next

        '
        '=============================================================================================================
        'Reduce the values in the new item

        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strICode As String = Nothing
            Dim intQty As Integer = 0
            Dim strSerNo As String = Nothing
            Dim dblDiscount As Double = 0
            Dim dblUnitSellPrice As Double = 0
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strICode = dGrid.Rows(i).Cells(0).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                strSerNo = dGrid.Rows(i).Cells(1).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    intQty = CInt(dGrid.Rows(i).Cells(2).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                    dblDiscount = CInt(dGrid.Rows(i).Cells(5).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    dblUnitSellPrice = CInt(dGrid.Rows(i).Cells(3).Value.ToString)
                End If
            End If
            objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = (Quantity - " & intQty & ") " _
                & "WHERE ItemCode = '" & strICode & "'", cnn)
            objCommand.ExecuteNonQuery()

            'Get the new item base barcode
            Dim strNewItemBaseBarcode As String = Nothing
            Dim objGetBasebarcode As New Data.OleDb.OleDbCommand("SELECT [BarCodeNo] FROM SerialNumbers WHERE " _
                & "ItemCode = '" & strICode & "' AND SerialNumber = '" & strSerNo & "'", cnn)
            Dim objReadBasebarcode As Data.OleDb.OleDbDataReader = objGetBasebarcode.ExecuteReader
            If objReadBasebarcode.HasRows Then
                objReadBasebarcode.Read()
                If Not IsDBNull(objReadBasebarcode(0).ToString) Then strNewItemBaseBarcode = objReadBasebarcode(0).ToString
            End If
            objReadBasebarcode.Close()

            'Update the serial numbers table
            If Not String.IsNullOrEmpty(strSerNo) Then
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers WHERE ItemCode = '" & cboItemNew.Text & "' " _
                    & "AND SerialNumber = '" & strSerNo & "'", cnn)
                objCommand.ExecuteNonQuery()
            End If

            'Update the sales exchange table
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SalesExchanges ([TransactionDate]," _
            & "[OriginalDocNumber],[ItemCode],[CurrentSerialNumber],[OriginalSerialNumber], [DiscountAllowed], [SellingPrice]," _
            & "[Reason],[UserName],[BranchName], [BaseBarcode]) VALUES ('" & Format(dpDate.Value, "dd-MMM-yyyy") & "', " & CInt(txtDocNo.Text) & ", " _
            & "'" & strICode & "', '" & strSerNo & "', '', " & dblDiscount & ", " _
            & "" & dblUnitSellPrice & ", '" & txtReason.Text & "', '" & strUserName & "', '" & strUserBranch & "', '" & strNewItemBaseBarcode & "')", cnn)
            objCommand.ExecuteNonQuery()

        Next

        'Update the sales table with the top up amount and then reverse the original invoice
        'Reverse only the amount and ring the full amount value. Discount the amount with the diferrence

        '
        '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        'Get the new invoice number
        '
        txtReturnNumber.Text = CStr(gwt_comm.GetNextDocumentNumber("ItemReturns"))
        '
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strIcode As String = Nothing
            Dim strIDesc As String = Nothing
            Dim intQty As Integer = 0
            Dim dblAmount As Double = 0
            Dim strSerNo As String = Nothing

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strIcode = dGrid.Rows(i).Cells(0).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                strSerNo = dGrid.Rows(i).Cells(1).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    intQty = CInt(dGrid.Rows(i).Cells(2).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                    dblAmount = CInt(dGrid.Rows(i).Cells(4).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                strIDesc = dGrid.Rows(i).Cells(5).Value.ToString
            End If
            Dim dblDiscountingValue As Double = 0
            If i = 0 Then
                dblDiscountingValue = CDbl(lblAmountOld.Text)
            End If
            Dim insertCustomer As String = "INSERT INTO SALES (CustomerId, InvoiceNumber, TransDate, ItemCode, Quantity, " _
                        & "SalesPrice, TransType, Description, Taxes, DiscountAllowed, ProductType, SerialNumbers, " _
                        & "UserName, SalesRep, OriginalInvoice) VALUES " _
                        & "('0000', " & CInt(txtReference.Text) & ", '" & Format(dpDate.Value, "dd-MMM-yyyy") & "', " _
                        & "'" & strIcode & "', " & intQty & ", " & dblAmount & ", 'EXCHANGE TOPUP', " _
                        & "'" & strIDesc & "', 0, " & dblDiscountingValue & ", " _
                        & "'CASH SALE TOPUP', '" & strSerNo & "', '" & strUserName & "', " _
                        & "'" & strUserName & "', " & CInt(txtDocNo.Text) & ")"
            objCommand = New Data.OleDb.OleDbCommand(insertCustomer, cnn)
            objCommand.ExecuteNonQuery()
        Next

        'Add the record to the sales main
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SalesMain (InvoiceNumber, CustomerId, TransDate, " _
            & "Discount, Taxes, Amount, UserName, SalesRep, OriginalInvoice) VALUES " _
            & "(" & Convert.ToDouble(txtReference.Text) & ", '0000', '" & Format(dpDate.Value, "dd-MMM-yyyy") & "', " _
            & "" & CDbl(lblAmountOld.Text) & ", 0, " & CDbl(txtTopUpAmount.Text) & ", '" & strUserName & "', " _
            & "'" & strUserName & "', " & CInt(txtDocNo.Text) & ")", cnn)
        objCommand.ExecuteNonQuery()

        If strPublicDirectCashbbookSalesPosting = "YES" Then

            'Update the cashbook with the values
            Dim strCashbookDescription As String = "CASH SALE TOP UP - " & UCase(strUserName)
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, TransactionDate, " _
                & "Amount, Description, ContraAccount, UserName, UserBranch, TransactionType, Reference) VALUES " _
                & "('" & strPublicActiveCashbook & "', '" & Format(dpDate.Value, "dd-MMM-yyyy") & "', " & CDbl(txtTopUpAmount.Text) & ", " _
                & "'" & strCashbookDescription & "', '" & strPublicSalesAccount & "', '" & strUserName & "', " _
                & "'" & strUserBranch & "', 'DEBIT', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
            objCommand.ExecuteNonQuery()

            'Post the account to the contra ledger account
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch]) VALUES " _
                & "('" & strPublicSalesAccount & "', '" & Format(dpDate.Value, "dd-MMM-yyyy") & "', " & CDbl(txtTopUpAmount.Text) & ", " _
                & "'CREDIT', '" & strPublicActiveCashbook & "', '" & strCashbookDescription & "', " _
                & "'" & strUserName & "', '" & strUserBranch & "')", cnn)
            objCommand.ExecuteNonQuery()

        End If

        '=====================================================================================================================

        'Update the control numbers table
        objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET ItemReturns = " & CDbl(txtReturnNumber.Text) & "", cnn)
        objCommand.ExecuteNonQuery()

        'Update the control numbers table
        objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET CashSales = " & CDbl(txtReference.Text) & "", cnn)
        objCommand.ExecuteNonQuery()

        PrintExchangeReceipt()
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Item Exchange Processing"
        ShowErrorMessage()
    End Sub

    Private Sub PrintExchangeReceipt()
        On Error GoTo RaiseErr
        Dim strType As String = "ITEM EXCHANGE"
        Dim strSelectedReport As String = Me.txtReturnNumber.Text

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
        arrPrintDetails.Add(Space(2) & "PRODUCT EXCHANGE")
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        '
        arrPrintDetails.Add(Space(2) & " *** ORIGINAL  ITEMS *** ")
        arrPrintDetails.Add(Space(2) & StrDup(30, "-"c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))

        For ix As Integer = 0 To grdInvoice.Rows.Count - 1
            If grdInvoice.Rows(ix).Cells(0).Value = True Then
                Dim strSerNo As String = Nothing, strIDesc As String = Nothing
                Dim strAmount As String = "0.00"
                Dim strTax As String = "0.00"
                If Not (Object.Equals(Convert.ToString(grdInvoice.Rows(ix).Cells(8).Value), "")) Then
                    strSerNo = grdInvoice.Rows(ix).Cells(8).Value.ToString
                End If
                If Not (Object.Equals(Convert.ToString(grdInvoice.Rows(ix).Cells(2).Value), "")) Then
                    strIDesc = grdInvoice.Rows(ix).Cells(2).Value.ToString
                End If
                If Not (Object.Equals(Convert.ToString(grdInvoice.Rows(ix).Cells(7).Value), "")) Then
                    If IsNumeric(grdInvoice.Rows(ix).Cells(7).Value.ToString) Then
                        strAmount = Format(CDbl(grdInvoice.Rows(ix).Cells(7).Value.ToString), "##0.00")
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(grdInvoice.Rows(ix).Cells(6).Value), "")) Then
                    If IsNumeric(grdInvoice.Rows(ix).Cells(6).Value.ToString) Then
                        strTax = Format(CDbl(grdInvoice.Rows(ix).Cells(6).Value.ToString), "##0.00")
                    End If
                End If
                strAmount = CStr(CDbl(strAmount) + CDbl(strTax))

                arrPrintDetails.Add(Space(2) & UCase(strIDesc))
                arrPrintDetails.Add(Space(2) & "   S.N. " & UCase(strSerNo))
                arrPrintDetails.Add(Space(20) & Space(10 - (Format(CDbl(strAmount), "##0.00")).Length) & Format(CDbl(strAmount), "##0.00"))
                'Space(20) & Space(10 - (Format(dblAmount, "##0.00")).Length) & Format(dblAmount, "##0.00")
            End If
        Next

        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        arrPrintDetails.Add(Space(2) & UCase(" *** NEW ITEMS *** "))
        arrPrintDetails.Add(Space(2) & StrDup(30, "-"c))

        For i As Integer = 0 To dGrid.Rows.Count - 1

            Dim strIcode As String = Nothing
            Dim strIDesc As String = Nothing
            Dim intQty As Integer = 0
            Dim dblAmount As Double = 0
            Dim strSerNo As String = Nothing

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strIcode = dGrid.Rows(i).Cells(0).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                strSerNo = dGrid.Rows(i).Cells(1).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    intQty = CInt(dGrid.Rows(i).Cells(2).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                    dblAmount = CInt(dGrid.Rows(i).Cells(4).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                strIDesc = dGrid.Rows(i).Cells(5).Value.ToString
            End If
            Dim dblDiscountingValue As Double = 0
            If i = 0 Then
                dblDiscountingValue = CDbl(lblAmountOld.Text)
            End If

            arrPrintDetails.Add(Space(2) & UCase(strIcode))
            arrPrintDetails.Add(Space(10) & "REPLACING S.N. " & UCase(strSerNo))
            arrPrintDetails.Add(Space(20) & Space(10 - (Format(dblAmount, "##0.00")).Length) & Format(dblAmount, "##0.00"))
        Next

        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        arrPrintDetails.Add(Space(2) & "TOP UP AMOUNT    " & Format(CDbl(txtTopUpAmount.Text), "##0.00"))
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))


        Dim strZimDate As String = Format(dpDate.Value, "dd-MMM-yyyy")

        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(2) & "SALES REP " & UCase(strUserName) & Space(3))
        arrPrintDetails.Add(Space(1) & "DATE AND TIME " & strZimDate & " " & DatePart(DateInterval.Hour, Now) & ":" & DatePart(DateInterval.Minute, Now))
        arrPrintDetails.Add(Space(2) & "EXCHANGE DATE  " & Format(dpDate.Value, "dd-MMM-yyyy"))
        arrPrintDetails.Add(Space(2) & " DOC NO " & txtReturnNumber.Text)
        arrPrintDetails.Add(Space(32))
        For i As Integer = 0 To 14
            arrPrintDetails.Add(Space(32))
        Next

        'WRITE EVERY THING TO THE AUDIT FILE
        Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\EXCHANGETU", True)
        For x As Integer = 0 To arrPrintDetails.Count - 1
            objFileWriter.WriteLine(arrPrintDetails.Item(x))
        Next
        objFileWriter.Close()
        '
        'PRINTS FROM A FILE DIRECTLY TO THE PRINTER
        '
        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()

        If MessageBox.Show("Do you want to print the receipt right now?", "Confirm Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            For n = 0 To arrPrintDetails.Count - 1
                Dim strPrintLineDetails As String = arrPrintDetails.Item(n) & vbCrLf
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintLineDetails)
            Next
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Processing"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub txtDocNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDocNo.KeyPress
        If Asc(e.KeyChar) = 13 Then grdInvoice.Focus()
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If e.KeyChar = "." Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'Add the item to the grid and recalculate the top up amount
        If String.IsNullOrEmpty(cboItemNew.Text) Or String.IsNullOrEmpty(lblDescriptionNew.Text) _
            Or String.IsNullOrEmpty(lblAmountNew.Text) Then
            MessageBox.Show("Please select a valid item code for the new item", "Invalid Item Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboItemNew.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtQty.Text) Then
            MessageBox.Show("Please enter a valid value for quantity", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQty.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtDiscount.Text) Then txtDiscount.Text = "0.00"

        If UCase(lblInventoryType.Text) = "SPECIFIC" Then
            If String.IsNullOrEmpty(txtSerialNumbers.Text) Then
                MessageBox.Show("Missing Serial Number", "Missing Serial Number. Please select from the list of available numbers", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtSerialNumbers.Focus()
                Exit Sub
            End If
        End If

        With dGrid
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = cboItemNew.Text
            .Rows(.Rows.Count - 1).Cells(1).Value = txtSerialNumbers.Text
            .Rows(.Rows.Count - 1).Cells(2).Value = txtQty.Text
            .Rows(.Rows.Count - 1).Cells(3).Value = lblAmountNew.Text
            If IsNumeric(txtQty.Text) And IsNumeric(lblAmountNew.Text) Then
                If Not IsNumeric(txtDiscount.Text) Then txtDiscount.Text = "0"
                .Rows(.Rows.Count - 1).Cells(4).Value = Format((CDbl(txtQty.Text) * CDbl(lblAmountNew.Text)), "##0.00")
            End If
            .Rows(.Rows.Count - 1).Cells(5).Value = txtDiscount.Text
            .Rows(.Rows.Count - 1).Cells(6).Value = lblDescriptionNew.Text
        End With
        computeDifference()
        cboItemNew.Text = ""
        lblAmountNew.Text = "0.00"
        txtDiscount.Text = "0.00"
        lblDescriptionNew.Text = ""
        txtSerialNumbers.Items.Clear()
        cboItemNew.Focus()
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtSerialNumbers.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub LoadInvoiceData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing
        If strTaxComputationType = "EXCLUSIVE" Then
            strsql = "select ItemCode, Description, Quantity, CAST(SalesPrice AS " _
                & "DECIMAL(10,2)) AS [UnitPrice], CAST(DiscountAllowed AS DECIMAL(10,2)) AS [Discounts], " _
                & "CAST(Taxes AS DECIMAL(10,2)) AS [Taxes], CAST(((Quantity * SalesPrice) - " _
                & "DiscountAllowed + Taxes) AS DECIMAL(10,2)) AS [Payable], SerialNumbers, TransactionId from Sales WHERE " _
                & "InvoiceNumber = " & CInt(txtDocNo.Text) & ""
        Else
            strSql = "select ItemCode, Description, Quantity, CAST(SalesPrice AS " _
                & "DECIMAL(10,2)) AS [UnitPrice], CAST(DiscountAllowed AS DECIMAL(10,2)) AS [Discounts], " _
                & "CAST(Taxes AS DECIMAL(10,2)) AS [Taxes], CAST(((Quantity * SalesPrice) - " _
                & "DiscountAllowed - Taxes) AS DECIMAL(10,2)) AS [Payable], SerialNumbers, TransactionId from Sales WHERE " _
                & "InvoiceNumber = " & CInt(txtDocNo.Text) & ""
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        grdInvoice.Rows.Clear()
        While objReader.Read
            grdInvoice.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then grdInvoice.Rows(grdInvoice.Rows.Count - 1).Cells(1).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then grdInvoice.Rows(grdInvoice.Rows.Count - 1).Cells(2).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then grdInvoice.Rows(grdInvoice.Rows.Count - 1).Cells(3).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then grdInvoice.Rows(grdInvoice.Rows.Count - 1).Cells(4).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then grdInvoice.Rows(grdInvoice.Rows.Count - 1).Cells(5).Value = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then grdInvoice.Rows(grdInvoice.Rows.Count - 1).Cells(6).Value = objReader(5).ToString
            If Not IsDBNull(objReader(6).ToString) Then grdInvoice.Rows(grdInvoice.Rows.Count - 1).Cells(7).Value = objReader(6).ToString
            If Not IsDBNull(objReader(7).ToString) Then grdInvoice.Rows(grdInvoice.Rows.Count - 1).Cells(8).Value = objReader(7).ToString
            If Not IsDBNull(objReader(8).ToString) Then grdInvoice.Rows(grdInvoice.Rows.Count - 1).Cells(9).Value = objReader(8).ToString
        End While
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub txtDocNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDocNo.Validating
        LoadInvoiceData()
        ComputeTotals()
    End Sub

    Private Sub ComputeTotals()
        If grdInvoice.Rows.Count = 0 Then Exit Sub
        Dim dblSubTotal As Double = 0
        Dim dblTaxesTotal As Double = 0
        Dim dblDiscountTotals As Double = 0
        Dim dblTotalPayable As Double = 0
        For n As Integer = 0 To grdInvoice.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(grdInvoice.Rows(n).Cells(5).Value), "")) Then
                dblDiscountTotals = dblDiscountTotals + CDbl(grdInvoice.Rows(n).Cells(5).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(grdInvoice.Rows(n).Cells(6).Value), "")) Then
                dblTaxesTotal = dblTaxesTotal + CDbl(grdInvoice.Rows(n).Cells(6).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(grdInvoice.Rows(n).Cells(7).Value), "")) Then
                dblTotalPayable = dblTotalPayable + CDbl(grdInvoice.Rows(n).Cells(7).Value.ToString)
            End If
        Next
        'If strTaxComputationType = "INCLUSIVE" Then
        '    dblSubTotal = (dblTotalPayable - dblDiscountTotals) + dblTaxesTotal
        'Else
        '    dblSubTotal = (dblTotalPayable - dblDiscountTotals) '- dblTaxesTotal
        'End If
        'lblSubTotal.Text = Format(dblSubTotal, "#,##0.00")
        'lblTaxes.Text = Format(dblTaxesTotal, "#,##0.00")
        'lblDiscounts.Text = Format(dblDiscountTotals, "#,##0.00")
        lblAmountOld.Text = Format((dblTotalPayable + dblTaxesTotal), "#,##0.00")
    End Sub

    Private Sub grdInvoice_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdInvoice.MouseUp
        On Error GoTo RaiseErr
        If grdInvoice.Rows.Count = 0 Then Exit Sub
        If grdInvoice.CurrentCell.ColumnIndex = 0 Then
            Dim cell As DataGridViewCheckBoxCell = Me.grdInvoice.CurrentCell
            'Get the value of the current cell
            Dim checked As Boolean = cell.GetEditedFormattedValue(cell.RowIndex, DataGridViewDataErrorContexts.Parsing)
            'Change the other cell to the opposite value
            Dim dblValue As Double = 0

            Dim dblPayable As Double = 0
            Dim dblTaxes As Double = 0

            Dim n As Integer = grdInvoice.CurrentRow.Index
            If checked = True Then
                'If cell.ColumnIndex = 0 Then
                '    Me.grdInvoice.CurrentRow.Cells(2).Value = False
                'ElseIf cell.ColumnIndex = 2 Then
                '    Me.grdInvoice.CurrentRow.Cells(1).Value = False
                '    If Me.grdInvoice.CurrentRow.Cells(0).Value.ToString = "Neurological Examination" Then
                '    End If
                'End If

                If Not (Object.Equals(Convert.ToString(grdInvoice.Rows(n).Cells(6).Value), "")) Then
                    If IsNumeric(grdInvoice.Rows(n).Cells(6).Value.ToString) Then
                        dblTaxes = CDbl(grdInvoice.Rows(n).Cells(6).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(grdInvoice.Rows(n).Cells(7).Value), "")) Then
                    If IsNumeric(grdInvoice.Rows(n).Cells(7).Value.ToString) Then
                        dblPayable = CDbl(grdInvoice.Rows(n).Cells(7).Value.ToString)
                    End If
                End If
                dblValue = dblValue + dblPayable + dblTaxes
                lblReturnTotal.Text = Format((CDbl(lblReturnTotal.Text) + dblValue), "##0.00")
            Else
                If Not (Object.Equals(Convert.ToString(grdInvoice.Rows(n).Cells(6).Value), "")) Then
                    dblTaxes = CDbl(grdInvoice.Rows(n).Cells(6).Value.ToString)
                End If
                If Not (Object.Equals(Convert.ToString(grdInvoice.Rows(n).Cells(7).Value), "")) Then
                    dblPayable = CDbl(grdInvoice.Rows(n).Cells(7).Value.ToString)
                End If
                If CDbl(lblReturnTotal.Text) > 0 Then
                    lblReturnTotal.Text = Format((CDbl(lblReturnTotal.Text) - (dblPayable + dblTaxes)), "##0.00")
                End If
            End If
            Me.grdInvoice.EndEdit()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & "On Exchange Plus Processing"
        ShowErrorMessage()
    End Sub

    Private Sub frmSalesReturnsPlus_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '950, 620
        Me.Width = 950 : Me.Height = 620
    End Sub

End Class