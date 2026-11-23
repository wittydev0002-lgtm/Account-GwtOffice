Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoyalityCustmerTransactionEntries

    Dim arrPrintDetails As ArrayList
    Dim strType As String

    Dim dblExpensesRate As Double = 0
    Dim dblCommissionRate As Double = 0

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        If String.IsNullOrEmpty(cboServiceClass.Text) Then
            MessageBox.Show("Please enter the sales agent service classification", "Invalid Service Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboServiceClass.Focus()
            Exit Sub
        End If
        FinishSale()
    End Sub

    Private Sub FinishSale()

        Dim strSqlTransmit As String = Nothing
        Dim strSelectedId As String
        Dim strDescription As String
        Dim intQty As Double = 0
        Dim dblUprice As Double
        Dim strSalesTransaction As String
        Dim dblTax As Double
        Dim i As Double
        Dim dpProcessDate As Date = gwt_comm.shortMonthDateFormat(DateTime.Now)
        Dim dblDisAmount As Double 'for discounts
        Dim dblSumTaxes As Double = 0, dblSumDiscounts As Double = 0, dblSumPayable As Double = 0
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim dblItemCostPrice As Double = 0
        Dim dblLineAmountPayable As Double = 0
        Dim strLineItemType As String = Nothing
        Dim strItemSerialNo As String = Nothing

        dblAmountTendered = 0
        dblAmountChange = 0

        If String.IsNullOrEmpty(cboPersonnel.Text) Then
            MessageBox.Show("Please select the sales agent", "Missing Sales Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If dGridSales.Rows.Count <= 0 Then
            MessageBox.Show("No document transactions to print !!!", "Empty Document Transactions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Perform the till ring routine
        boolAbort = False

        'If dblSaleTotal <= 0 Then
        '    MessageBox.Show("Sale cannot be processed when there are no valid sub total values", MsgBoxStyle.Critical, "Sale Aborted")
        '    Exit Sub
        'End If


        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        dpProcessDate = gwt_comm.shortMonthDateFormat(dpTransDate.Value)
        'End If

        Cursor = Cursors.WaitCursor

        For i = 0 To dGridSales.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGridSales.Rows(i).Cells(0).Value), "")) Then

                strSelectedId = Nothing : strDescription = Nothing : strLineItemType = Nothing : intQty = 1
                dblUprice = 0 : dblDisAmount = 0 : dblTax = 0 : dblLineAmountPayable = 0 : dblItemCostPrice = 0
                Dim strShortCode As String = "0"
                Dim strUDate As String = gwt_comm.shortMonthDateFormat(Now)
                Dim strSalesRep As String = Nothing
                Dim strAccount As String = Nothing

                'strSelectedId = Convert.ToString(dGridSales.Rows(i).Cells(0).Value) 'Description

                'strItemSerialNo = Convert.ToString(dGridSales.Rows(i).Cells(1).Value) 'item code
                'intQty = Convert.ToDouble(dGridSales.Rows(i).Cells(3).Value)
                'dblUprice = Convert.ToDouble(dGridSales.Rows(i).Cells(4).Value)
                'dblDisAmount = Convert.ToDouble(dGridSales.Rows(i).Cells(5).Value)
                'dblTax = Convert.ToDouble(dGridSales.Rows(i).Cells(8).Value)

                'dblItemCostPrice = Convert.ToDouble(dGridSales.Rows(i).Cells(7).Value)

                strUDate = Convert.ToString(dGridSales.Rows(i).Cells(0).Value)
                strShortCode = Convert.ToString(dGridSales.Rows(i).Cells(1).Value)
                strDescription = Convert.ToString(dGridSales.Rows(i).Cells(2).Value)
                dblLineAmountPayable = Convert.ToDouble(dGridSales.Rows(i).Cells(5).Value)
                strSalesRep = Convert.ToString(dGridSales.Rows(i).Cells(3).Value)
                strAccount = Convert.ToString(dGridSales.Rows(i).Cells(6).Value)
                'Dim dblExRate As Double = Convert.ToDouble(dGridSales.Rows(i).Cells(9).Value)
                'Dim dblComRate As Double = Convert.ToDouble(dGridSales.Rows(i).Cells(10).Value)
                'Dim strServiceClass As String = Convert.ToString(dGridSales.Rows(i).Cells(11).Value)

                UpdateLoyalityDetails(strUDate, strDescription, strShortCode, dblLineAmountPayable, strSalesRep, "GENTS", strAccount)

            End If

        Next i


        MessageBox.Show("Sales document generated successfully.", "Transaction Document Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.lblSubTotal.Text = "0.00"
        Me.lblDiscounts.Text = "0.00"
        Me.lblTaxes.Text = "0.00"
        'Clear the controls
        dGridSales.Rows.Clear()
        cboPersonnel.Text = ""
        dpTransDate.Enabled = False
        chkOverideDate.Checked = False
        dblAmountChange = 0
        lblLoyalityAccountHolder.Text = ""
        txtLoyalityAccount.Clear()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Processing"
        gwt_comm.ShowErrorMessage()
    End Sub


    Private Sub chkOverideDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverideDate.CheckedChanged
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

    Private Sub GetInventory(ByVal strShortCode As String)
        On Error GoTo RaiseErr
        lblItemCode.Text = Nothing
        lblItemDescription.Text = Nothing
        txtPriceOnSale.Text = "0.00"
        txtSalesDiscount.Text = "0.00"
        txtSalesQty.Text = "1"
        txtSalesTax.Text = "0.00"
        Dim strSql As String = "SELECT ItemCode, GroupName, CONVERT(NVARCHAR, " _
            & "CAST(SellingPrice AS DECIMAL (30,2))), TaxStatus FROM InventoryItems " _
            & "WHERE ShortCode = '" & strShortCode & "' AND Status = 'ACTIVE'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then lblItemCode.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then lblItemDescription.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtPriceOnSale.Text = objReader(2).ToString Else txtPriceOnSale.Text = "0.00"
            txtSalesQty.Text = "1" : txtSalesDiscount.Text = "0.00"
            Dim dblDiscounts() As Double = gwt_comm.ItemOnSpecials(lblItemCode.Text, CDbl(txtPriceOnSale.Text))
            txtSalesDiscount.Text = Format(dblDiscounts(1), "##0.00")

            Dim dblTaxes As Double = 0, dblUnitPrice As Double = CDbl(txtPriceOnSale.Text), intQuantity As Integer = 1
            Dim dblSubTotal As Double = 0
            Dim dblPayable As Double = 0

            '*********** Compute the tax payable *********************

            ' Compute the sub total
            dblSubTotal = dblUnitPrice * intQuantity
            If UCase(strTaxComputationType) = "INCLUSIVE" Then
                dblTaxes = (dblUnitPrice * intQuantity) - ((dblUnitPrice * intQuantity) * (100 / (100 + dblSalesTaxRate)))
            Else
                dblTaxes = (dblSubTotal - CDbl(txtSalesDiscount.Text)) * (dblSalesTaxRate / 100) 'dblTaxRate
            End If


            If UCase(strTaxComputationType) = "EXCLUSIVE" Then
                dblPayable = (dblSubTotal - CDbl(txtSalesDiscount.Text)) + dblTaxes
            Else
                dblPayable = (dblSubTotal - CDbl(txtSalesDiscount.Text))
            End If
            txtSalesTax.Text = Format(dblTaxes, "##0.00")
            txtCurrentPayable.Text = Format(dblPayable, "##0.00")
        Else
            MessageBox.Show("Oops!! You have entered an invalid short code. Re-enter", "Invalid Short Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtShortCode.Focus()
            txtShortCode.SelectAll()
            Exit Sub
        End If

        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Fetch"
        gwt_comm.ShowErrorMessage()
    End Sub
    '    Private Sub LoadSalesData()
    '        On Error GoTo RaiseErr
    '        Dim strSql As String = Nothing
    '        Select Case UCase(strMainCompanyServiceOffering)
    '            Case Is = "PRODUCTS"
    '                strSql = "SELECT ItemCode +';'+GroupName +';'+ CONVERT(NVARCHAR, " _
    '                    & "CAST(SellingPrice AS DECIMAL (30,2))) +';'+ TaxStatus AS " _
    '                    & "[Items] FROM InventoryItems WHERE Offering = 'PRODUCT' AND Status = 'ACTIVE' ORDER BY ItemCode"
    '            Case Is = "SERVICES"
    '                strSql = "SELECT ItemCode +';'+GroupName +';'+ CONVERT(NVARCHAR, " _
    '                    & "CAST(SellingPrice AS DECIMAL (30,2))) +';'+ TaxStatus AS " _
    '                    & "[Items] FROM InventoryItems WHERE Offering = 'SERVICE' AND Status = 'ACTIVE' ORDER BY ItemCode"
    '            Case Is = "HIRING ITEMS"
    '                strSql = "SELECT ItemCode +';'+GroupName +';'+ CONVERT(NVARCHAR, " _
    '                    & "CAST(SellingPrice AS DECIMAL (30,2))) +';'+ TaxStatus AS " _
    '                    & "[Items] FROM InventoryItems WHERE Offering = 'HIRE ITEM' AND Status = 'ACTIVE' ORDER BY ItemCode"
    '            Case Else
    '                strSql = "SELECT ItemCode +';'+GroupName +';'+ CONVERT(NVARCHAR, " _
    '                    & "CAST(SellingPrice AS DECIMAL (30,2))) +';'+ TaxStatus AS " _
    '                    & "[Items] FROM InventoryItems WHERE Offering = 'PRODUCT' AND Status = 'ACTIVE' ORDER BY ItemCode"
    '        End Select

    '        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
    '        'Set up the drop down combo box
    '        With cboItems
    '            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
    '            .ColumnNum = 4
    '            .HighlightBorderOnMouseEvents = True
    '            .ManagingFastMouseMoving = True
    '            .Enabled = True
    '            .DropDownHeight = 110
    '            .GridLineHorizontal = True
    '            .GridLineVertical = True
    '            .ColumnWidth = "160;180;60;60"
    '        End With
    '        'Get a count of the items
    '        Dim intItemsCount As Double = 0

    '        Select Case UCase(strMainCompanyServiceOffering)
    '            Case Is = "PRODUCTS"
    '                sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'PRODUCT' AND Status = 'ACTIVE'", cnn)
    '            Case Is = "SERVICES"
    '                sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'SERVICE' AND Status = 'ACTIVE'", cnn)
    '            Case Is = "HIRING ITEMS"
    '                sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'HIRE ITEM' AND Status = 'ACTIVE'", cnn)
    '            Case Else
    '                sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'PRODUCT' AND Status = 'ACTIVE'", cnn)
    '        End Select

    '        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
    '        If objCount.HasRows Then
    '            objCount.Read()
    '            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
    '        End If
    '        objCount.Close()
    '        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

    '        cboItems.Items.Clear()
    '        Dim i As Double = 0
    '        Dim p As Double = 0
    '        'Continue to read until you reach the end of the file.
    '        While objReader.Read
    '            'File the listview with details.
    '            If Not IsDBNull(objReader(0).ToString) Then
    '                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
    '                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)), UCase(strRecordText(2)), UCase(strRecordText(3)))
    '            End If
    '            p = p + 1
    '        End While
    '        objReader.Close()
    '        'Load the banks to the combo box
    '        If intItemsCount > 0 Then
    '            cboItems.SelectedIndex = -1
    '            cboItems.Items.Clear()
    '            cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
    '            cboItems.Items.AddRange(DropDownItems)
    '        End If
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    'Private Sub cboItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItems.SelectedIndexChanged
    '    lblItemDescription.Text = ""
    '    lblCostPrice.Text = "0.00"
    '    If String.IsNullOrEmpty(cboItems.Text) Then Exit Sub
    '    lblItemDescription.Text = cboItems.SelectedItem.Col2
    '    'lblCostPrice.Text = cboItems.SelectedItem.Col3
    '    txtPriceOnSale.Text = cboItems.SelectedItem.Col3
    '    txtSalesQty.Text = "1"
    '    txtSalesDiscount.Text = "0.00"
    '    'txtSalesQty.Focus()
    '    'txtSalesQty.SelectAll()
    '    txtCurrentPayable.Text = cboItems.SelectedItem.Col3

    '    'Get the item type
    '    Dim strCodeSelected As String = cboItems.SelectedItem.Col1
    '    Dim dblSalePrice As Double = 0
    '    Dim objCommand As New Data.OleDb.OleDbCommand("SELECT InventoryType, SellingPrice FROM InventoryItems " _
    '        & "WHERE ItemCode = '" & strCodeSelected & "'", cnn)
    '    Dim objReadType As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '    If objReadType.HasRows Then
    '        objReadType.Read()

    '        '**************HAVE SIDE BUTTON TO VIEW SERIAL NUMBERS **********************************

    '        'If Not IsDBNull(objReadType(0).ToString) Then
    '        '    If UCase(objReadType(0).ToString) = "SPECIFIC" Then
    '        '        dGrid.CurrentRow.Cells(5).ReadOnly = True
    '        '    End If
    '        'End If
    '        If IsNumeric(objReadType(1).ToString) Then dblSalePrice = CDbl(objReadType(1).ToString)
    '    End If
    '    objReadType.Close()

    '    'Apply the discount
    '    Dim dblDiscounts() As Double = ItemOnSpecials(strCodeSelected, dblSalePrice)
    '    txtSalesDiscount.Text = CStr(Format((dblDiscounts(1) * CDbl(txtSalesQty.Text)), "##0.00"))

    'End Sub

    Private Sub btnAcceptSaleEntry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAcceptSaleEntry.Click
        If String.IsNullOrEmpty(lblLoyalityAccountHolder.Text) Then
            MessageBox.Show("Please enter the account holder number", "Missing Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLoyalityAccount.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboPersonnel.Text) Then
            MessageBox.Show("Please enter the sales agent", "Missing Sales Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPersonnel.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblItemDescription.Text) Then
            MessageBox.Show("Please select the item to enter", "Invalid Sales Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtShortCode.Focus()
            Exit Sub
        Else
            With dGridSales
                If Not IsNumeric(txtPriceOnSale.Text) Then txtPriceOnSale.Text = "0"
                If Not IsNumeric(txtSalesQty.Text) Then txtSalesQty.Text = "1"
                If Not IsNumeric(txtSalesDiscount.Text) Then txtSalesDiscount.Text = "0"
                .Rows.Add(gwt_comm.shortMonthDateFormat(dpTransDate.Value), txtShortCode.Text, lblItemDescription.Text, cboPersonnel.Text,
                    "GENTS", Format(((CDbl(txtPriceOnSale.Text) * CDbl(txtSalesQty.Text)) - CDbl(txtSalesDiscount.Text))), txtLoyalityAccount.Text)
                'reset controls and refocus cursor
                txtSalesQty.Text = "1"
                txtSalesDiscount.Text = "0.00"
                txtPriceOnSale.Text = "0.00"
                txtCurrentPayable.Text = "0.00"
                lblCostPrice.Text = "0.00"
                lblItemDescription.Text = ""
                txtShortCode.Text = ""
                txtShortCode.Focus()
                txtSalesTax.Text = "0.00"
            End With
        End If
        ComputeTotals()
        txtShortCode.Focus()
    End Sub

    Private Sub ComputeTotals()

        Dim dblSubTotal As Double = 0
        Dim dblTaxesTotal As Double = 0
        Dim dblDiscountTotals As Double = 0
        Dim dblTotalPayable As Double = 0

        If dGridSales.Rows.Count = 0 Then
            lblSubTotal.Text = "0.00"
            lblTaxes.Text = "0.00"
            lblDiscounts.Text = "0.00"
            Exit Sub
        Else
            For n As Double = 0 To dGridSales.Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(dGridSales.Rows(n).Cells(5).Value), "")) Then
                    dblSubTotal = dblSubTotal + CDbl(dGridSales.Rows(n).Cells(5).Value.ToString)
                    dblTotalPayable = dblTotalPayable + CDbl(dGridSales.Rows(n).Cells(5).Value.ToString)
                End If
                'If Not (Object.Equals(Convert.ToString(dGridSales.Rows(n).Cells(8).Value), "")) Then
                '    dblTaxesTotal = dblTaxesTotal + CDbl(dGridSales.Rows(n).Cells(8).Value.ToString)
                'End If
                'If Not (Object.Equals(Convert.ToString(dGridSales.Rows(n).Cells(5).Value), "")) Then
                '    dblDiscountTotals = dblDiscountTotals + CDbl(dGridSales.Rows(n).Cells(5).Value.ToString)
                'End If
                'If Not (Object.Equals(Convert.ToString(dGridSales.Rows(n).Cells(6).Value), "")) Then
                '    dblTotalPayable = dblTotalPayable + CDbl(dGridSales.Rows(n).Cells(6).Value.ToString)
                'End If
            Next
            lblSubTotal.Text = Format(((dblTotalPayable - dblTaxesTotal) + dblDiscountTotals), "##0.00")
            'lblSubTotal.Text = Format(dblSubTotal, "#,##0.00")
            lblTaxes.Text = Format(dblTaxesTotal, "##0.00")
            lblDiscounts.Text = Format(dblDiscountTotals, "##0.00")
        End If
    End Sub

    Private Sub txtSalesQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalesQty.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            txtSalesDiscount.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtSalesDiscount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalesDiscount.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            txtLoyalityAccount.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub frmScannedSales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F3 Then
            FinishSale()
        End If
        If e.KeyValue = Keys.F2 Then
            strPublicItemCode = Nothing
            strShortItemCode = Nothing
            intCallingForm = 1
            gwt_comm.InventorySearch()
            If Not String.IsNullOrEmpty(strShortItemCode) Then
                txtShortCode.Text = strShortItemCode
                txtShortCode.Focus()
                txtSalesQty.Focus()
            End If
        End If
        If e.KeyValue = Keys.F9 Then
            If dGridSales.Rows.Count > 0 Then
                dGridSales.Rows.RemoveAt(dGridSales.CurrentRow.Index)
                ComputeTotals()
            End If
        End If
        If e.KeyValue = Keys.F10 Then
            Me.Close()
            'End
        End If
    End Sub

    Private Sub frmClassicSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LoadSalesData()
        LoadPersonnel()
        LoadEmployeeClasses()
    End Sub

    Private Sub LoadEmployeeClasses()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT Description FROM SystemEmployeeClasses ORDER BY Description", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        cboServiceClass.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboServiceClass.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadPersonnel()
        If Not String.IsNullOrEmpty(strUserName) Then
            lblUserName.Text = UCase(Mid(strUserName, 1, 1)) & LCase(Mid(strUserName, 2, (strUserName.Length - 1)))
        End If
        On Error GoTo RaiseErr
        'Load the employee details
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames " _
            & "AS [EmployeeDetails] FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        cboPersonnel.Items.Clear()
        cboPersonnel.Items.Add("")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboPersonnel.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtShortCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShortCode.KeyPress
        If Asc(e.KeyChar) = 13 Then txtSalesQty.Focus()
    End Sub

    Private Sub txtShortCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtShortCode.Validating
        If String.IsNullOrEmpty(txtShortCode.Text) Then Exit Sub
        GetInventory(txtShortCode.Text)
    End Sub

    Private Sub txtNotes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNotes.KeyPress
        If Asc(e.KeyChar) = 13 Then btnAcceptSaleEntry.Focus()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If dGridSales.Rows.Count > 0 Then
            dGridSales.Rows.RemoveAt(dGridSales.CurrentRow.Index)
            ComputeTotals()
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        dGridSales.Rows.Clear()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadPersonnel()
    End Sub

    Private Sub txtLoyalityAccount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoyalityAccount.KeyPress
        If Asc(e.KeyChar) = 13 Then txtNotes.Focus()
    End Sub

    Private Sub txtLoyalityAccount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLoyalityAccount.Validating
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtLoyalityAccount.Text) Then Exit Sub
        lblLoyalityAccountHolder.Text = ""
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName FROM LoyalityCustomers WHERE AccountNumber = '" & txtLoyalityAccount.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then lblLoyalityAccountHolder.Text = objReader(0).ToString
        Else
            MessageBox.Show("The account number entered is not correct. Please re-enter", "Invalid Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLoyalityAccount.SelectAll()
            txtLoyalityAccount.Focus()
            Exit Sub
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Account Number Search"
        gwt_comm.ShowErrorMessage()
    End Sub


    Private Sub UpdateLoyalityDetails(ByVal strDate As String, ByVal Description As String, ByVal ShortCode As String, ByVal Amount As Double, ByVal strSalesRep As String, ByVal strCategory As String, ByVal AccountNumber As String)
        On Error GoTo RaiseErr
        Dim inDate As Date = Now
        If chkOverideDate.Checked = True Then inDate = dpTransDate.Value
        Dim strSql As String = "INSERT INTO LoyalityEntries (AccountNumber, TransDate, " _
            & "ItemShortCode, Description, SalesRep, UserName, Amount) VALUES " _
            & "('" & AccountNumber & "', '" & strDate & "', " _
            & "'" & ShortCode & "', '" & Description & "', '" & strSalesRep & "', '" & strUserName & "', " & Amount & ")"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Account Number Search"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        strPublicItemCode = Nothing
        strPublicItemDescription = Nothing
        boolAbort = False
        gwt_comm.CustomerSearch()
        If boolAbort = True Then Exit Sub
        txtLoyalityAccount.Text = strSelectedAccount
        lblLoyalityAccountHolder.Text = strSelectedAccountName
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        strPublicItemCode = Nothing
        strShortItemCode = Nothing
        intCallingForm = 1
        gwt_comm.InventorySearch()
        If Not String.IsNullOrEmpty(strShortItemCode) Then
            txtShortCode.Text = strShortItemCode
            txtShortCode.Focus()
            txtSalesQty.Focus()
        End If
    End Sub

    Private Sub btnNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewItem.Click
        boolEditStatus = False
        Dim f As New frmInventorySetup
        f.ShowDialog()
    End Sub

    Private Sub cboPersonnel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPersonnel.SelectedIndexChanged
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(cboPersonnel.Text) Then
            If UCase(cboPersonnel.Text) = "CASH SALE" Or _
                UCase(cboPersonnel.Text) = "CASH" Then
                Exit Sub
            Else
                Dim strNames() As String = Split(cboPersonnel.Text, " ")
                Dim objCommand As New Data.OleDb.OleDbCommand("SELECT EmployeeClass FROM EmployeeMaster " _
                    & "WHERE LastName = '" & strNames(0) & "' AND FirstName = '" & strNames(1) & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then cboServiceClass.Text = UCase(objReader(0).ToString)
                End If
                objReader.Close()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee class load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboServiceClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServiceClass.SelectedIndexChanged
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ExpensesRate, CommissionRate FROM HairDressingCommissions " _
                & "WHERE EmployeeClass = '" & cboServiceClass.Text & "'", cnn)
        Dim objReadRates As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReadRates.HasRows Then
            objReadRates.Read()
            If IsNumeric(objReadRates(0).ToString) Then dblExpensesRate = CDbl(objReadRates(0).ToString)
            If IsNumeric(objReadRates(1).ToString) Then dblCommissionRate = CDbl(objReadRates(1).ToString)
        End If
        objReadRates.Close()

        If dblExpensesRate <> 0 Then dblExpensesRate = dblExpensesRate / 100
        If dblCommissionRate <> 0 Then dblCommissionRate = dblCommissionRate / 100
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee class load"
        Cursor = Cursors.Default
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtSalesQty_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSalesQty.Validated
        If IsNumeric(txtSalesQty.Text) Then
            Dim dblQuantity As Double = 0
            Dim dblUnitPrice As Double = 0
            If IsNumeric(txtPriceOnSale.Text) Then
                Dim dblDiscount As Double = 0
                dblUnitPrice = CDbl(txtPriceOnSale.Text)
                If IsNumeric(txtSalesDiscount.Text) Then
                    dblDiscount = CDbl(txtSalesDiscount.Text)
                End If

                Dim dblSubTotal As Double = dblUnitPrice * dblQuantity
                Dim dblTaxes As Double = 0
                If UCase(strTaxComputationType) = "INCLUSIVE" Then
                    dblTaxes = (dblUnitPrice * dblQuantity) - ((dblUnitPrice * dblQuantity) * (100 / (100 + dblSalesTaxRate)))
                Else
                    dblTaxes = (dblSubTotal - CDbl(txtSalesDiscount.Text)) * (dblSalesTaxRate / 100) 'dblTaxRate
                End If

                Dim dblPayable As Double = 0
                If UCase(strTaxComputationType) = "EXCLUSIVE" Then
                    dblPayable = (dblSubTotal - CDbl(txtSalesDiscount.Text)) + dblTaxes
                Else
                    dblPayable = (dblSubTotal - CDbl(txtSalesDiscount.Text))
                End If
                txtSalesTax.Text = Format(dblTaxes, "##0.00")
                txtCurrentPayable.Text = Format(dblPayable, "##0.00")

            End If
        End If
    End Sub

    Private Sub frmLoyalityCustmerTransactionEntries_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 906 : Me.Height = 691
    End Sub

End Class
