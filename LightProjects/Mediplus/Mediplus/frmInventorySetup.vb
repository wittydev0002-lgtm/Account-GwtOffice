Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventorySetup
    Dim boolLoading As Boolean = True
    Dim boolSplitQuantityClicked As Boolean

    Private Sub btnAddCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCategory.Click
        Dim boolStatusBefore As Boolean = boolEditStatus
        boolEditStatus = False
        Dim f As New frmCategorySetup
        f.ShowDialog()
        boolEditStatus = boolStatusBefore
        LoadCategories()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SaveInventoryData()
    End Sub

    Private Sub SaveInventoryData()
        On Error GoTo RaiseErr
        'If String.IsNullOrEmpty(txtDescription.Text) Then
        '    MessageBox.Show("Please enter the item description such as color, size etc", MsgBoxStyle.Exclamation, "Invalid Data Entry")
        '    Exit Sub
        'End If
        Dim strSize As String = "1.00"

        If String.IsNullOrEmpty(txtItemCode.Text) Then
            MessageBox.Show("Please enter the Item Code Number", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboOfferType.Text) Then
            MessageBox.Show("Please specify the offer type from the dropdown list", "Missing Offer Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboOfferType.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtUnitPrice.Text) Then
            MessageBox.Show("Please enter a valid amount for selling price", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not IsNumeric(txtUnitCost.Text) Then
            MessageBox.Show("Please enter a valid amount for unit price", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not IsNumeric(txtQuantity.Text) Then
            MessageBox.Show("Please enter a valid value for quantity", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtGroupName.Text) Then
            MessageBox.Show("Please select the item name", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboLocation.Text) Then
            MessageBox.Show("Please select the location from the list provided", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboSubCategory.Text) Then
            MessageBox.Show("Please enter a valid sub category. If not set up, please them up", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboType.Text) Then
            MessageBox.Show("Please select a valid inventory type.", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not IsNumeric(txtMinimumLevel.Text) Then
            MessageBox.Show("Please enter a numeric value for minimum stock levels", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMinimumLevel.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtWarningLevel.Text) Then
            MessageBox.Show("Please enter a numeric value for warning stock levels", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtWarningLevel.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtIdealLevel.Text) Then
            MessageBox.Show("Please enter a numeric value for ideal stock levels", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtIdealLevel.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtMinimumLevel.Text) Then
            MessageBox.Show("Please enter a numeric value for minimum stock levels", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMinimumLevel.Focus()
            Exit Sub
        End If
        Dim strTaxStatus As String = "YES"
        Dim strBarcodeSerialStatus As String = "N"

        If Not String.IsNullOrEmpty(cboTax.Text) Then
            If UCase(cboTax.Text) = "NO" Then
                strTaxStatus = "NO"
            Else
                strTaxStatus = "YES"
            End If
        End If

        If chkBarcodeSerialStatus.Checked = True Then
            strBarcodeSerialStatus = "Y"
        End If

        Dim strInventorySaleStatus As String = "ACTIVE"
        If Not String.IsNullOrEmpty(cboInventoryStatus.Text) Then
            strInventorySaleStatus = UCase(cboInventoryStatus.Text)
        End If

        Dim strOffering As String = "PRODUCT"
        Select Case UCase(cboOfferType.Text)
            Case Is = "PRODUCT"
                strOffering = "PRODUCT"
            Case Is = "SERVICE"
                strOffering = "SERVICE"
            Case Is = "HIRE ITEM"
                strOffering = "HIRE ITEM"
            Case Else
                strOffering = "PRODUCT"
        End Select

        Dim intCnt As Integer = 0
        Dim strFoundItem As String = Nothing
        If Not String.IsNullOrEmpty(txtShortCode.Text) Then
            Dim objValidate As New Data.OleDb.OleDbCommand("SELECT COUNT(ShortCode), ItemCode FROM InventoryItems WHERE ShortCode = '" & txtShortCode.Text & "' GROUP BY ItemCode", cnn)
            Dim objReadValidity As Data.OleDb.OleDbDataReader = objValidate.ExecuteReader
            If objReadValidity.HasRows Then
                objReadValidity.Read()
                If IsNumeric(objReadValidity(0).ToString) Then intCnt = CInt(objReadValidity(0).ToString)
                If Not IsDBNull(objReadValidity(1).ToString) Then strFoundItem = objReadValidity(1).ToString
            End If
            objReadValidity.Close()
        End If

        'If boolEditStatus = False Then
        If intCnt > 0 Then
            If boolEditStatus = True Then
                If UCase(strFoundItem) = UCase(txtItemCode.Text) Then
                    'do nothing 
                Else
                    MessageBox.Show("The short code already exists. Please enter a different code", _
                        "Duplicate Short Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtShortCode.Focus()
                    Exit Sub
                End If
            Else
                MessageBox.Show("The short code already exists. Please enter a different code", _
                        "Duplicate Short Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtShortCode.Focus()
                Exit Sub
            End If
        End If

        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = False Then
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO InventoryItems " _
                & "(ItemCode, GroupName, Description, SellingPrice, CostPrice, Location, " _
                & "Category, SubCategory, Quantity, InventoryType, MinimumLevel, " _
                & "WarningLevel, IdealLevel, TaxStatus, FullBarcodeSerialStatus, Offering, ShortCode, " _
                & "SupplyPackaging, SalesPackaging, SupplyPackagingQuantity, SalesPackagingQuantity, " _
                & "Uom, MasterPackQty, PackItemCostPrice, PackItemSalePrice, Size, CostCode, Status) VALUES " _
                & "('" & txtItemCode.Text & "', '" & txtGroupName.Text & "', '', " _
                & "" & CDbl(txtUnitPrice.Text) & ", " & CDbl(txtUnitCost.Text) & ", '" & cboLocation.Text & "', " _
                & "'" & cboCategory.Text & "', '" & cboSubCategory.Text & "', " & txtQuantity.Text & ", '" & cboType.Text & "', " _
                & "" & txtMinimumLevel.Text & ", " & txtWarningLevel.Text & ", " & txtIdealLevel.Text & ", " _
                & "'" & strTaxStatus & "', '" & strBarcodeSerialStatus & "', '" & strOffering & "', '" & txtShortCode.Text & "', " _
                & "'NONW', 'NONE', 0, " _
                & "0, 'NONE', 0, " _
                & "0, 0, '" & strSize & "', " _
                & "0, '" & strInventorySaleStatus & "')", cnn)
            objCommand.ExecuteNonQuery()
        Else
            objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET " _
                & "GroupName = '" & txtGroupName.Text & "', " _
                & "Description = '', SellingPrice = " & CDbl(txtUnitPrice.Text) & ", " _
                & "CostPrice = " & CDbl(txtUnitCost.Text) & ", Location = '" & cboLocation.Text & "', " _
                & "Category = '" & cboCategory.Text & "', SubCategory = '" & cboSubCategory.Text & "', " _
                & "Quantity = " & txtQuantity.Text & ", InventoryType = '" & cboType.Text & "', " _
                & "MinimumLevel = " & txtMinimumLevel.Text & ", WarningLevel = " & txtWarningLevel.Text & ", FullBarcodeSerialStatus = '" & strBarcodeSerialStatus & "', " _
                & "IdealLevel = " & txtIdealLevel.Text & ", TaxStatus = '" & strTaxStatus & "', " _
                & "Offering = '" & strOffering & "', ShortCode = '" & txtShortCode.Text & "', Status = '" & strInventorySaleStatus & "', " _
                & "CostCode = " & CLng(lblCostCode.Text) & " WHERE ItemCode = '" & txtItemCode.Text & "'", cnn)
            objCommand.ExecuteNonQuery()


        End If

        'Update barcode
        If UCase(cboType.Text) = "GENERIC" Then
            If Not String.IsNullOrEmpty(txtBarcode.Text) Then
                'Check that the item barcode has been entered in the generic barcodes table
                objCommand = New Data.OleDb.OleDbCommand("SELECT ItemCode FROM GenericItemsBarcodes WHERE " _
                    & "Barcode = '" & txtBarcode.Text & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows = False Then
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO GenericItemsBarcodes (ItemCode, Barcode) " _
                        & "VALUES ('" & txtItemCode.Text & "', '" & txtBarcode.Text & "')", cnn)
                    objCommand.ExecuteNonQuery()
                Else
                    objReader.Read()
                    If UCase(txtItemCode.Text) <> UCase(objReader(0).ToString) Then
                        MessageBox.Show("The barcode you are trying to allocate to this item has already been allocated to another item", _
                            "Duplicate Barcode Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        boolEditStatus = True
                    Else
                        objCommand = New Data.OleDb.OleDbCommand("UPDATE GenericItemsBarcodes SET " _
                        & "Barcode = '" & txtBarcode.Text & "' WHERE ItemCode = '" & txtItemCode.Text & "'", cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                End If
                objReader.Close()
            End If
        End If

        If boolSplitQuantityClicked = True Then
            boolEditStatus = True
            Exit Sub
        End If
        If boolEditStatus = True Then
            Me.Hide()
            MessageBox.Show("Inventory item updated successfully", "Inventory Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            If MessageBox.Show("Inventory item saved successfully!!! Do you want to save more items?", _
                    "Inventory Save Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                ClearControls()
                txtItemCode.Focus()
            Else
                Me.Close()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        If Err.Number = 5 Then
            MessageBox.Show("Item Code already exist. Duplicates not allowed. Re-enter with a diffent code", _
                "Duplicate Item Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Setup"
            ShowErrorMessage()
        End If
    End Sub

    Private Function ShortCodeExists(ByVal strItemCode As String, ByVal strShortCode As String) As String()
        Dim strReturn(0 To 1) As String
        strReturn(0) = Nothing : strReturn(1) = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ItemCode, ShortCode FROM InventoryItems WHERE " _
            & "ItemCode = '" & strItemCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then strReturn(0) = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strReturn(1) = objReader(1).ToString
        End While
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Setup"
        ShowErrorMessage()
    End Function

    Private Sub LoadCategories()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Category FROM Categories ORDER BY Category", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        cboCategory.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboCategory.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Setup"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSubCategories(ByVal strCategory As String)
        On Error GoTo RaiseErr
        If boolLoading = True Then Exit Sub
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT distinct SubCategory FROM SubCategories " _
                & "WHERE Category = '" & strCategory & "' ORDER BY SubCategory", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        cboSubCategory.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboSubCategory.Items.Add(objReader(0).ToString)
        End While
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Setup"
        ShowErrorMessage()
    End Sub

    Private Sub LoadBranches()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT BranchName FROM Branches ORDER BY BranchName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboLocation.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Setup"
        ShowErrorMessage()
    End Sub

    Private Sub cboCategory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCategory.KeyPress
        If Asc(e.KeyChar) = 13 Then cboSubCategory.Focus()
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
        boolLoading = False
        LoadSubCategories(cboCategory.Text)
    End Sub

    Private Sub frmInventorySetup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F3 Then
            SaveInventoryData()
        End If
        If e.KeyValue = Keys.F1 Then

        End If
        If e.KeyValue = Keys.F5 Then

        End If
        If e.KeyValue = Keys.F6 Then

        End If
        If e.KeyValue = Keys.F7 Then

        End If
        If e.KeyValue = Keys.F8 Then

        End If
        If e.KeyValue = Keys.F9 Then

        End If
        If e.KeyValue = Keys.F10 Then
            Me.Close()
            'End
        End If
    End Sub

    Private Sub LoadCostCenters()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT CostCenterName +';'+ CONVERT(NVARCHAR, OrdinalNo) AS " _
            & "[CostCenters] FROM SystemCostCenters ORDER BY CostCenterName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        Dim intX As Integer = mCboCostCenters.Width - 55
        With mCboCostCenters
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intX) & ";50"
        End With
        'Get a count of the items
        Dim intItemsCount As Double = 1

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(OrdinalNo) FROM SystemCostCenters", cnn)

        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = intItemsCount + CDbl(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        mCboCostCenters.Items.Clear()

        Dim p As Double = 0
        DropDownItems(p) = New MTGCComboBoxItem(UCase("--- NONE ---"), UCase("0"))
        p = p + 1

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            mCboCostCenters.SelectedIndex = -1
            mCboCostCenters.Items.Clear()
            mCboCostCenters.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            mCboCostCenters.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Cost Center Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmInventorySetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        boolLoading = True
        If strAllowItemQtyChangeStatus = "NO" Then txtQuantity.ReadOnly = True Else txtQuantity.ReadOnly = False
        LoadBranches()
        LoadCategories()
        LoadCostCenters()
        If boolEditStatus = True Then
            LoadSelectedData()
            ItemHistory(strInventoryItemCode)
        Else
            strInventoryItemCode = Nothing
        End If
        boolLoading = False
        txtItemCode.Focus()
        If UCase(strUserStockUpdateStatus) = "NO" Then
            btnOK.Enabled = False
        Else
            btnOK.Enabled = True
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Inventory Table Update Error"
        ShowErrorMessage()
    End Sub

    Private Sub ClearControls()
        txtItemCode.Clear()
        txtMinimumLevel.Text = "0"
        txtIdealLevel.Text = "0"
        txtQuantity.Text = "0"
        txtUnitCost.Text = "0"
        txtUnitPrice.Text = "0"
        txtWarningLevel.Text = "0"
        txtItemCode.Focus()
    End Sub

    Private Sub txtItemCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemCode.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If e.KeyChar = " " Then
            If strCompanyAllowsSpacesOnItemCodes = "NO" Then e.Handled = True
        End If
        If Asc(e.KeyChar) = 13 Then txtGroupName.Focus()
    End Sub

    Private Sub txtGroupName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGroupName.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtUnitCost.Focus()
    End Sub

    Private Sub txtUnitCost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnitCost.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtUnitPrice.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtUnitPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnitPrice.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then cboTax.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub cboTax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTax.KeyPress
        If Asc(e.KeyChar) = 13 Then cboCategory.Focus()
    End Sub

    Private Sub cboSubCategory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSubCategory.KeyPress
        If Asc(e.KeyChar) = 13 Then cboLocation.Focus()
    End Sub

    Private Sub cboLocation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLocation.KeyPress
        If Asc(e.KeyChar) = 13 Then cboType.Focus()
    End Sub

    Private Sub cboType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboType.KeyPress
        If Asc(e.KeyChar) = 13 Then txtIdealLevel.Focus()
    End Sub

    Private Sub txtIdealLevel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdealLevel.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtMinimumLevel.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtMinimumLevel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMinimumLevel.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtWarningLevel.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtWarningLevel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWarningLevel.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtQuantity.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtQuantity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
        If strAllowItemQtyChangeStatus = "NO" Then
            e.Handled = True
            Exit Sub
        Else
            If UCase(strUserLevel) = "ADMINISTRATOR" Or UCase(strUserLevel) = "MANAGER" Then
                If e.KeyChar = "." Then Exit Sub
                If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
                If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
                If Asc(e.KeyChar) = 13 Then btnOK.Focus()
                If Not IsNumeric(e.KeyChar) Then e.Handled = True
            End If
        End If
    End Sub

    Private Sub LoadSelectedData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ItemCode, GroupName, Description, " _
            & "CAST(SellingPrice AS decimal(10,2)) AS SellingPrice, CAST(CostPrice AS decimal(10,2)) AS " _
            & "CostPrice, Location, Category, SubCategory, Quantity, InventoryType, " _
            & "MinimumLevel, WarningLevel, IdealLevel, TaxStatus, SerialNumbers, ItemColor, Size, " _
            & "FullBarcodeSerialStatus, Offering, ShortCode, SupplyPackaging, SalesPackaging, " _
            & "SupplyPackagingQuantity, SalesPackagingQuantity, Uom, MasterPackQty, Size, " _
            & "CostCode, Status FROM InventoryItems WHERE " _
            & "ItemCode = '" & strInventoryItemCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("ItemCode").ToString) Then txtItemCode.Text = objReader("ItemCode").ToString
            If Not IsDBNull(objReader("GroupName").ToString) Then txtGroupName.Text = objReader("GroupName").ToString
            If Not IsDBNull(objReader("SellingPrice").ToString) Then txtUnitPrice.Text = objReader("SellingPrice").ToString
            If Not IsDBNull(objReader("CostPrice").ToString) Then txtUnitCost.Text = objReader("CostPrice").ToString
            If Not IsDBNull(objReader("Location").ToString) Then cboLocation.Text = objReader("Location").ToString
            If Not IsDBNull(objReader("Category").ToString) Then cboCategory.Text = objReader("Category").ToString
            If Not IsDBNull(objReader("SubCategory").ToString) Then cboSubCategory.Text = objReader("SubCategory").ToString
            If Not IsDBNull(objReader("Quantity").ToString) Then txtQuantity.Text = objReader("Quantity").ToString
            If Not IsDBNull(objReader("InventoryType").ToString) Then cboType.Text = objReader("InventoryType").ToString
            If Not IsDBNull(objReader("MinimumLevel").ToString) Then txtMinimumLevel.Text = objReader("MinimumLevel").ToString
            If Not IsDBNull(objReader("WarningLevel").ToString) Then txtWarningLevel.Text = objReader("WarningLevel").ToString
            If Not IsDBNull(objReader("IdealLevel").ToString) Then txtIdealLevel.Text = objReader("IdealLevel").ToString
            If Not IsDBNull(objReader("TaxStatus").ToString) Then cboTax.Text = objReader("TaxStatus").ToString
            If Not IsDBNull(objReader("Offering").ToString) Then cboOfferType.Text = objReader("Offering").ToString
            If Not IsDBNull(objReader("FullBarcodeSerialStatus").ToString) Then
                If UCase(objReader("FullBarcodeSerialStatus").ToString) = "Y" Then chkBarcodeSerialStatus.Checked = True Else chkBarcodeSerialStatus.Checked = False
            End If
            If Not IsDBNull(objReader("ShortCode").ToString) Then txtShortCode.Text = objReader("ShortCode").ToString

            If Not IsDBNull(objReader("Status").ToString) Then cboInventoryStatus.Text = UCase(objReader("Status").ToString)

            lblCostCode.Text = "0"
            If Not IsDBNull(objReader("CostCode").ToString) Then lblCostCode.Text = objReader("CostCode").ToString
            'Get the cost code name
            objCommand = New Data.OleDb.OleDbCommand("SELECT CostCenterName FROM SystemCostCenters WHERE OrdinalNo = " & CDbl(lblCostCode.Text) & "", cnn)
            Dim objReadCostCenter As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadCostCenter.HasRows Then
                objReadCostCenter.Read()
                If Not IsDBNull(objReadCostCenter(0).ToString) Then mCboCostCenters.Text = UCase(objReadCostCenter(0).ToString)
            End If
            objReadCostCenter.Close()

        End If
        txtItemCode.Enabled = False
        objReader.Close()
        If UCase(cboType.Text) = "GENERIC" Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT Barcode FROM GenericItemsBarcodes WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then txtBarcode.Text = objReader(0).ToString
            End If
            objReader.Close()
            txtBarcode.Enabled = True
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Setup"
        ShowErrorMessage()
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        If UCase(cboType.Text) = "GENERIC" Then
            txtBarcode.Enabled = True
            chkBarcodeSerialStatus.Checked = True
        Else
            txtBarcode.Enabled = False
            chkBarcodeSerialStatus.Checked = False
        End If
    End Sub

    Private Sub ItemHistory(ByVal ItemCode As String)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT DATENAME (yyyy, Sales.TransDate ) as Month, " _
            & "DATEPART(mm, sales.transdate) as Year, SUM(Sales.Quantity) AS [Sold], " _
            & "cast((SUM((Sales.SalesPrice * Sales.Quantity) - Sales.DiscountAllowed )) AS DECIMAL (10,2)) as [Incomes], " _
            & "cast((SUM(Sales.CostPrice * Sales.Quantity)) AS DECIMAL (10,2)) as [Cost], " _
            & "cast((SUM((Sales.SalesPrice * Sales.Quantity) - Sales.DiscountAllowed - (Sales.CostPrice * Sales.Quantity))) AS DECIMAL (10,2)) as [Profit] " _
            & "FROM Sales WHERE ItemCode = '" & ItemCode & "' " _
            & "GROUP BY DATENAME (yyyy, sales.transdate),  DATEPART(mm, sales.transdate) ORDER BY Month, Year"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dgridHistory.Rows.Clear()
        While objReader.Read
            dgridHistory.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dgridHistory.Rows(dgridHistory.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If IsNumeric(objReader(1).ToString) Then
                dgridHistory.Rows(dgridHistory.Rows.Count - 1).Cells(1).Value = UCase(MonthName(CInt(objReader(1).ToString), True))
            End If
            If Not IsDBNull(objReader(2).ToString) Then dgridHistory.Rows(dgridHistory.Rows.Count - 1).Cells(3).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dgridHistory.Rows(dgridHistory.Rows.Count - 1).Cells(4).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then dgridHistory.Rows(dgridHistory.Rows.Count - 1).Cells(5).Value = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then dgridHistory.Rows(dgridHistory.Rows.Count - 1).Cells(6).Value = objReader(5).ToString
        End While
        objReader.Close()

        'Add total line

        If dgridHistory.Rows.Count > 0 Then

            Dim dblItemsSold As Double = 0
            Dim dblSales As Double = 0
            Dim dblCosts As Double = 0
            Dim dblProfits As Double = 0

            For i As Integer = 0 To dgridHistory.Rows.Count - 1
                dblItemsSold = dblItemsSold + CDbl(dgridHistory.Rows(i).Cells(3).Value.ToString)
                dblSales = dblSales + CDbl(dgridHistory.Rows(i).Cells(4).Value.ToString)
                dblCosts = dblCosts + CDbl(dgridHistory.Rows(i).Cells(5).Value.ToString)
                dblProfits = dblProfits + CDbl(dgridHistory.Rows(i).Cells(6).Value.ToString)
            Next

            dgridHistory.Rows.Add(1)

            With dgridHistory
                .Rows(.Rows.Count - 1).Cells(0).Value = ""
                .Rows(.Rows.Count - 1).Cells(1).Value = "TOTAL"
                .Rows(.Rows.Count - 1).Cells(3).Value = Format(dblItemsSold, "##0.00")
                .Rows(.Rows.Count - 1).Cells(4).Value = Format(dblSales, "##0.00")
                .Rows(.Rows.Count - 1).Cells(5).Value = Format(dblCosts, "##0.00")
                .Rows(.Rows.Count - 1).Cells(6).Value = Format(dblProfits, "##0.00")
            End With

            strSql = "select sum(OrdersReceipt.Quantity) as [Ordered], ItemCode from OrdersReceipt WHERE ItemCode = '" & ItemCode & "' GROUP BY ItemCode"
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory History Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnAddSubCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSubCategory.Click
        Dim boolStatusBefore As Boolean = boolEditStatus
        If String.IsNullOrEmpty(cboCategory.Text) Then
            MessageBox.Show("You have to select the category first before adding a sub category", "Missing Category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCategory.Focus()
            Exit Sub
        Else
            boolEditStatus = True
            strSelectedCategory = cboCategory.Text
            boolEditStatus = True
            Dim f As New frmCategorySetup
            f.ShowDialog()
            boolEditStatus = boolStatusBefore
            LoadCategories()
            cboCategory.Text = strSelectedCategory
        End If
    End Sub

    Private Sub mCboCostCenters_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCboCostCenters.SelectedIndexChanged

    End Sub

End Class