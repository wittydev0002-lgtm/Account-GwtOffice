Imports System.Windows.Forms.DataVisualization.Charting
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventorySetup
    Dim boolLoading As Boolean = True
    Dim boolSplitQuantityClicked As Boolean

    Private Property strNewInventoryItemCode As String

    Private Sub btnAddCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New frmCategorySetup
        f.ShowDialog()
        LoadCategories()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If IntPublicInventory = 1 Or IntPublicInventory = 0 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        SaveInventoryData()
    End Sub

    Private Sub SaveInventoryData()
        On Error GoTo RaiseErr
        'If String.IsNullOrEmpty(txtDescription.Text) Then
        '    MessageBox.Show("Please enter the item description such as color, size etc", MsgBoxStyle.Exclamation, "Invalid Data Entry")
        '    Exit Sub
        'End If
        If Not IsNumeric(txtSize.Text) Then txtSize.Text = "1.00"

        If String.IsNullOrEmpty(txtItemCode.Text) Then
            MessageBox.Show("Please enter the Serial Number", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        If Not IsNumeric(txtSalesPackQuantity.Text) Then txtSalesPackQuantity.Text = "1"
        If Not IsNumeric(txtSupplyPackQuantity.Text) Then txtSupplyPackQuantity.Text = "1"

        If String.IsNullOrEmpty(cboSalesPackaging.Text) Then cboSalesPackaging.Text = "SINGLE"
        If String.IsNullOrEmpty(cboSupplyPackaging.Text) Then cboSupplyPackaging.Text = "SINGLE"

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
        'Check that the user has correctly entered quantity in the event of an item where there are 
        'specific serial numbers attached to products
        boolAbort = False
        ValidateSerialNumbers()
        If boolAbort = True Then Exit Sub

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
        'Else
        'If Not String.IsNullOrEmpty(strTestValues(1)) Then
        '    If UCase(strTestValues(1)) <> UCase(txtShortCode.Text) Then
        '        MessageBox.Show("The short code allocated differs from previous. Please enter" & vbCrLf & "a different code or use inventory item code change module to change it", MsgBoxStyle.Exclamation, "Inconsistant Short Code")
        '        txtShortCode.Focus()
        '        Exit Sub
        '    End If
        'End If
        'End If

        If String.IsNullOrEmpty(cboMeasurements.Text) Then cboMeasurements.Text = "NONE"
        If Not IsNumeric(txtStandardMeasure.Text) Then txtStandardMeasure.Text = "1"
        If Not IsNumeric(lblCostCode.Text) Then lblCostCode.Text = "0"

        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = False Then
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO InventoryItems " _
                & "(ItemCode, GroupName, Description, SellingPrice, CostPrice, Location, " _
                & "Category, SubCategory, Quantity, InventoryType, MinimumLevel, " _
                & "WarningLevel, IdealLevel, TaxStatus, FullBarcodeSerialStatus, Offering, ShortCode, " _
                & "SupplyPackaging, SalesPackaging, SupplyPackagingQuantity, SalesPackagingQuantity, " _
                & "Uom, MasterPackQty, PackItemCostPrice, PackItemSalePrice, Size, CostCode, Status) VALUES " _
                & "('" & txtItemCode.Text & "', '" & txtGroupName.Text & "', '" & txtDescription.Text & "', " _
                & "" & CDbl(txtUnitPrice.Text) & ", " & CDbl(txtUnitCost.Text) & ", '" & cboLocation.Text & "', " _
                & "'" & cboCategory.Text & "', '" & cboSubCategory.Text & "', " & txtQuantity.Text & ", '" & cboType.Text & "', " _
                & "" & txtMinimumLevel.Text & ", " & txtWarningLevel.Text & ", " & txtIdealLevel.Text & ", " _
                & "'" & strTaxStatus & "', '" & strBarcodeSerialStatus & "', '" & strOffering & "', '" & txtShortCode.Text & "', " _
                & "'" & cboSupplyPackaging.Text & "', '" & cboSalesPackaging.Text & "', " & CInt(txtSupplyPackQuantity.Text) & ", " _
                & "" & CInt(txtSalesPackQuantity.Text) & ", '" & cboMeasurements.Text & "', " & CDbl(txtStandardMeasure.Text) & ", " _
                & "" & txtUnitSupplyPrice.Text & ", " & txtUnitSalePrices.Text & ", '" & txtSize.Text & "', " _
                & "" & CLng(lblCostCode.Text) & ", '" & strInventorySaleStatus & "')", cnn)
            objCommand.ExecuteNonQuery()
        Else
            objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET " _
                & "GroupName = '" & txtGroupName.Text & "', " _
                & "Description = '" & txtDescription.Text & "', SellingPrice = " & CDbl(txtUnitPrice.Text) & ", " _
                & "CostPrice = " & CDbl(txtUnitCost.Text) & ", Location = '" & cboLocation.Text & "', " _
                & "Category = '" & cboCategory.Text & "', SubCategory = '" & cboSubCategory.Text & "', " _
                & "Quantity = " & txtQuantity.Text & ", InventoryType = '" & cboType.Text & "', " _
                & "MinimumLevel = " & txtMinimumLevel.Text & ", WarningLevel = " & txtWarningLevel.Text & ", FullBarcodeSerialStatus = '" & strBarcodeSerialStatus & "', " _
                & "IdealLevel = " & txtIdealLevel.Text & ", TaxStatus = '" & strTaxStatus & "', " _
                & "Offering = '" & strOffering & "', ShortCode = '" & txtShortCode.Text & "', " _
                & "SupplyPackaging = '" & cboSupplyPackaging.Text & "', SalesPackaging = '" & cboSalesPackaging.Text & "', " _
                & "SupplyPackagingQuantity = " & CInt(txtSupplyPackQuantity.Text) & ", " _
                & "SalesPackagingQuantity = " & CInt(txtSalesPackQuantity.Text) & ", " _
                & "Uom = '" & cboMeasurements.Text & "', MasterPackQty = " & CDbl(txtStandardMeasure.Text) & ", " _
                & "PackItemCostPrice = " & txtUnitSupplyPrice.Text & ", PackItemSalePrice = " & txtUnitSalePrices.Text & ", " _
                & "Size = '" & txtSize.Text & "', Status = '" & strInventorySaleStatus & "', " _
                & "CostCode = " & CLng(lblCostCode.Text) & " WHERE ItemCode = '" & txtItemCode.Text & "'", cnn)
            objCommand.ExecuteNonQuery()

            'If UCase(cboType.Text) = "GENERIC" Then
            '    objCommand = New Data.OleDb.OleDbCommand("UPDATE GenericItemsBarcodes SET " _
            '        & "Barcode = '" & txtBarcode.Text & "' WHERE ItemCode = '" & txtItemCode.Text & "'", cnn)
            '    objCommand.ExecuteNonQuery()
            'End If

            'Dim strCost As String = CStr(Format(CDbl(txtUnitCost.Text), "##0.00"))
            'Dim strSale As String = CStr(Format(CDbl(txtUnitPrice.Text), "##0.00"))

            'arrInventoryEditData = New ArrayList
            'arrInventoryEditData.Add(txtItemCode.Text)
            'arrInventoryEditData.Add(txtGroupName.Text)
            'arrInventoryEditData.Add(txtDescription.Text)
            'arrInventoryEditData.Add(strSale)
            'arrInventoryEditData.Add(strCost)
            'arrInventoryEditData.Add(cboLocation.Text)
            'arrInventoryEditData.Add(strActiviteStatus)
            'arrInventoryEditData.Add(cboCategory.Text)
            'arrInventoryEditData.Add(cboSubCategory.Text)
            'arrInventoryEditData.Add(txtQuantity.Text)
            'arrInventoryEditData.Add(cboType.Text)
            'arrInventoryEditData.Add(txtMinimumLevel.Text)
            'arrInventoryEditData.Add(txtWarningLevel.Text)
            'arrInventoryEditData.Add(txtIdealLevel.Text)
            'arrInventoryEditData.Add(cboTax.Text)

        End If

        '
        'Save the makeup
        '

        boolAbort = False
        SaveMakeUp()
        If boolAbort = True Then Exit Sub

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

        'Save the serial numbers as well
        SaveSerialNumbers()
        If boolAbort = True Then Exit Sub
        SaveLandedCosts()
        If boolAbort = True Then Exit Sub

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

    Private Sub ValidateSerialNumbers()
        'Check to make sure that the numbers for the serials and the quantity match
        If UCase(cboType.Text) = "SPECIFIC" Then
            Dim ArrSerialNo As New ArrayList
            For i As Integer = 0 To dGrid.Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    ArrSerialNo.Add(Convert.ToString(dGrid.Rows(i).Cells(0).Value))
                End If
            Next
            If CInt(txtQuantity.Text) <> ArrSerialNo.Count Then
                MessageBox.Show("The numbers of items and the serial numbers entered do not match. " _
                   & "Please correct this problem first", "Quantity Serial Numbers Count Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtQuantity.Focus()
                boolAbort = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub SaveSerialNumbers()
        On Error GoTo RaiseErr
        Dim objDeleteAll As New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers WHERE ItemCode = '" & txtItemCode.Text & "'", cnn)
        objDeleteAll.ExecuteNonQuery()
        Dim objCommand As Data.OleDb.OleDbCommand
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strSerialNo As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strSerialNo = Convert.ToString(dGrid.Rows(i).Cells(0).Value)

                If Not String.IsNullOrEmpty(strSerialNo) Then
                    'If strSerialNo.Length > 9 Then
                    '    strNewBarCode = Mid(strSerialNo, 1, 9)
                    '    strNewSerialNo = Mid(strSerialNo, 10, strSerialNo.Length - 9)
                    'Else
                    '    strNewBarCode = strSerialNo
                    '    strNewSerialNo = ""
                    'End If
                    'If strNewSerialNo.Length < 4 Then strNewSerialNo = strSerialNo

                    Dim strNewBarCode As String = Nothing
                    Dim strNewSerialNo As String = Nothing
                    Dim strBaseBarCode As String = Nothing

                    If Not String.IsNullOrEmpty(strSerialNo) Then
                        strNewBarCode = Space(intBarcodeLength - strSerialNo.Length) & strSerialNo
                        strNewSerialNo = Mid(strNewBarCode, (intBarcodeLength - (intBarcodeUserLength - 1)), intBarcodeUserLength)
                        strBaseBarCode = Mid(strNewBarCode, 1, (intBarcodeLength - intBarcodeUserLength))
                    End If

                    Dim strSql As String = Nothing
                    If chkBarcodeSerialStatus.Checked = False Then
                        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers WHERE ItemCode = " _
                        & "'" & txtItemCode.Text & "' AND SourceSerialNo = '" & strSerialNo & "'", cnn)
                        objCommand.ExecuteNonQuery()
                        strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber, BarCodeNo, SourceSerialNo) VALUES " _
                            & "('" & txtItemCode.Text & "', '" & strNewSerialNo & "', '" & strBaseBarCode & "', '" & strSerialNo & "')"
                    Else
                        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers WHERE ItemCode = " _
                        & "'" & txtItemCode.Text & "' AND SerialNumber = '" & strSerialNo & "'", cnn)
                        objCommand.ExecuteNonQuery()
                        strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber, BarCodeNo, SourceSerialNo) VALUES " _
                            & "('" & txtItemCode.Text & "', '" & strSerialNo & "', '" & strBaseBarCode & "', '" & strSerialNo & "')"
                    End If
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If

                'objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SerialNumbers (ItemCode, SerialNumber) " _
                '    & "VALUES ('" & txtItemCode.Text & "', '" & strSerialNo & "')", cnn)
                'objCommand.ExecuteNonQuery()
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Serial Numbers Update"
        ShowErrorMessage()
    End Sub

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

    Private Sub LoadSerials()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        If boolEditStatus = True Then
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SourceSerialNo, SerialNumber FROM SerialNumbers " _
                & "WHERE ItemCode = '" & strInventoryItemCode & "' ORDER BY SourceSerialNo", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReader.Read
                dGrid.Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then
                    dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                End If
                If Not IsDBNull(objReader(1).ToString) Then
                    dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                End If
            End While
            objReader.Close()
        End If
        AlternateColors()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Serial Numbers Update"
        ShowErrorMessage()
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
        LoadUnitsOfMeasure()
        LoadLandedCosts()
        If boolEditStatus = True Then
            btnCheck.Enabled = False
            btnEditCode.Enabled = True
            LoadSelectedData()
            ItemHistory(strInventoryItemCode)
            LoadSerials()
            LoadMakeup()
        Else
            btnCheck.Enabled = True
            btnEditCode.Enabled = False
            strInventoryItemCode = Nothing
            cboSalesPackaging.Text = "SINGLE"
            cboSupplyPackaging.Text = "SINGLE"
            cboMeasurements.Text = "NONE"
        End If
        boolLoading = False
        txtItemCode.Focus()
        If UCase(strUserStockUpdateStatus) = "NO" Then
            btnOK.Enabled = False
        Else
            btnOK.Enabled = True
        End If
        LoadProducts()
        TabControl1.SelectedTabIndex = 0
        TabControl2.SelectedTabIndex = 0
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Inventory Table Update Error"
        ShowErrorMessage()
    End Sub

    Private Sub ClearControls()
        txtItemCode.Clear()
        txtDescription.Clear()
        'txtGroupName.Clear()
        txtMinimumLevel.Text = "0"
        txtIdealLevel.Text = "0"
        txtQuantity.Text = "0"
        txtUnitCost.Text = "0"
        txtUnitPrice.Text = "0"
        txtWarningLevel.Text = "0"
        txtDescription.Clear()
        txtItemCode.Focus()
        dGrid.Rows.Clear()
        dGrid.Rows.Add(100)
    End Sub

    Private Sub txtItemCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemCode.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If e.KeyChar = " " Then
            If strCompanyAllowsSpacesOnItemCodes = "NO" Then
                e.KeyChar = "-"
            End If
            'e.Handled = True
        End If
        If Asc(e.KeyChar) = 13 Then txtGroupName.Focus()
    End Sub

    Private Sub txtShortCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShortCode.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If e.KeyChar = " " Then
            If strCompanyAllowsSpacesOnItemCodes = "NO" Then
                e.KeyChar = "-"
            End If
        End If
        If Asc(e.KeyChar) = 13 Then mCboCostCenters.Focus()
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
            If Not IsDBNull(objReader("Description").ToString) Then txtDescription.Text = objReader("Description").ToString
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

            If Not IsDBNull(objReader("SupplyPackaging").ToString) Then cboSupplyPackaging.Text = objReader("SupplyPackaging").ToString
            If Not IsDBNull(objReader("SalesPackaging").ToString) Then cboSalesPackaging.Text = objReader("SalesPackaging").ToString
            If Not IsDBNull(objReader("SupplyPackagingQuantity").ToString) Then txtSupplyPackQuantity.Text = objReader("SupplyPackagingQuantity").ToString
            If Not IsDBNull(objReader("SalesPackagingQuantity").ToString) Then txtSalesPackQuantity.Text = objReader("SalesPackagingQuantity").ToString
            If Not IsDBNull(objReader("Status").ToString) Then cboInventoryStatus.Text = UCase(objReader("Status").ToString)

            If Not IsDBNull(objReader("Uom").ToString) Then cboMeasurements.Text = objReader("Uom").ToString
            If Not IsDBNull(objReader("MasterPackQty").ToString) Then txtStandardMeasure.Text = objReader("MasterPackQty").ToString
            If Not IsDBNull(objReader("Size").ToString) Then
                If IsNumeric(objReader("Size").ToString) Then
                    txtSize.Text = Format(CDbl(objReader("Size").ToString), "##0.00")
                Else
                    txtSize.Text = "1.00"
                End If
            Else
                txtSize.Text = "1.00"
            End If

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

        GenerateStockMovementHistory()

        LoadSalesCostsMovements()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Setup"
        ShowErrorMessage()
    End Sub

    'Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
    '    'strSerializedItemNumbers = Nothing : strnewSerializedItemNumbers = Nothing
    '    If Not IsNumeric(txtQuantity.Text) Then
    '        MessageBox.Show("Serial Numbers cannot be maintained as the quantity entered is invalid", MsgBoxStyle.Exclamation, "Invalid Quantity Value")
    '        txtQuantity.Focus()
    '        Exit Sub
    '    End If
    '    If CInt(txtQuantity.Text) <= 0 Then
    '        MessageBox.Show("Serial Numbers cannot be maintained as there is no inventory item in stock", MsgBoxStyle.Exclamation, "Inventory Out of Stock")
    '        txtQuantity.Focus()
    '        Exit Sub
    '    End If
    '    If String.IsNullOrEmpty(txtItemCode.Text) Then
    '        MessageBox.Show("Serial Numbers cannot be maintained as there is no item code", MsgBoxStyle.Exclamation, "Missing Item Code")
    '        txtItemCode.Focus()
    '        Exit Sub
    '    End If
    '    If UCase(cboType.Text) = "SPECIFIC" Then
    '        boolStockTransfers = False
    '        strPublicItemCode = txtItemCode.Text
    '        intSerialItemsCount = CInt(txtQuantity.Text)
    '        Dim f As New frmSerializedItems
    '        f.ShowDialog()
    '        boolStockTransfers = False
    '    Else
    '        MessageBox.Show("Only items of specific type can be serialized", MsgBoxStyle.Exclamation, "Invalid Item Classfifaction")
    '        cboType.Focus()
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub btnSerialCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerialCount.Click
        Dim intCount As Integer = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                intCount = intCount + 1
            End If
        Next
        MessageBox.Show("Total serial numbers = " & intCount, "Serial Numbers Count", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub btnLoadImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadImage.Click
        ofd.ShowDialog()
        lblPicPath.Text = ofd.FileName
        If Not String.IsNullOrEmpty(lblPicPath.Text) Then
            If System.IO.File.Exists(lblPicPath.Text) Then
                picFace.Load(lblPicPath.Text)
            End If
        End If
    End Sub

    Private Sub btnSplits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSplits.Click
        boolSplitQuantityClicked = True
        If String.IsNullOrEmpty(txtItemCode.Text) Then
            MessageBox.Show("Please enter the item code first before calling this process", "Missing Item Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtItemCode.Focus()
            Exit Sub
        Else
            strSelectedInventoryItemCode = txtItemCode.Text
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ItemCode FROM InventoryItems WHERE ItemCode = '" & txtItemCode.Text & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows = False Then
                If boolEditStatus = False Then
                    'save the data first before proceeding
                    SaveInventoryData()
                End If
                'Else
                'MessageBox.Show("An item with a similar code already exist. Process will be terminated", MsgBoxStyle.Exclamation, "Duplicate Item Code")
                'objReader.Close()
                'Exit Sub
            End If
        End If
        boolAbort = False
        If IsNumeric(txtQuantity.Text) Then intSelectedInventoryQuantity = CInt(txtQuantity.Text) Else intSelectedInventoryQuantity = 0
        Dim f As New frmQuantitySplit
        f.ShowDialog()
        boolSplitQuantityClicked = False
        If boolAbort = False Then txtQuantity.Text = intSelectedInventoryReturnQuantity
        txtItemCode.Text = strSelectedInventoryItemCode
    End Sub

    Private Sub AlternateColors()
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1 Step 2
                For j As Integer = 0 To .Columns.Count - 1
                    Dim foreColor As Color = Color.Black
                    Dim backColor As Color = Color.WhiteSmoke
                    .Rows(i).Cells(j).Style.BackColor = backColor
                    .Rows(i).Cells(j).Style.ForeColor = foreColor
                Next j
            Next i
        End With
        With dgridHistory
            For i As Integer = 0 To .Rows.Count - 1 Step 2
                For j As Integer = 0 To .Columns.Count - 1
                    Dim foreColor As Color = Color.Black
                    Dim backColor As Color = Color.WhiteSmoke
                    .Rows(i).Cells(j).Style.BackColor = backColor
                    .Rows(i).Cells(j).Style.ForeColor = foreColor
                Next j
            Next i
        End With
    End Sub

    Private Sub btnAddCategory_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCategory.Click
        Dim boolStatusBefore As Boolean = boolEditStatus
        boolEditStatus = False
        Dim f As New frmCategorySetup
        f.ShowDialog()
        boolEditStatus = boolStatusBefore
        LoadCategories()
    End Sub

    Private Sub btnSpecialUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpecialUpdate.Click
        If UCase(strUserLevel) = "MANAGER" Or UCase(strUserLevel) = "ADMINISTRATOR" Then
            dblSelectedItemCostPrice = CDbl(txtUnitCost.Text)
            Dim f As New frmResetAndReinputInventory
            f.ShowDialog()
            LoadSelectedData()
            LoadSerials()
        Else
            MessageBox.Show("You do not have the right to perform this function", "Insufficient User Rights", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
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

        'Draw the graph

        Dim pointIndex As Integer
        For pointIndex = 0 To dgridHistory.Rows.Count - 3
            Chart1.Series("Series1").Points.AddY(CDbl(dgridHistory.Rows(pointIndex).Cells(4).Value.ToString))
            Chart1.Series("Series2").Points.AddY(CDbl(dgridHistory.Rows(pointIndex).Cells(5).Value.ToString))
        Next pointIndex

        ' Set series chart type
        Chart1.Series("Series1").ChartType = SeriesChartType.Line
        Chart1.Series("Series2").ChartType = SeriesChartType.Line

        ' Set point labels
        Chart1.Series("Series1").IsValueShownAsLabel = True
        Chart1.Series("Series2").IsValueShownAsLabel = True

        ' Enable X axis margin
        Chart1.ChartAreas("Default").AxisX.IsMarginVisible = True

        ' Show as 3D
        Chart1.ChartAreas("Default").Area3DStyle.Enable3D = False


        Exit Sub
RaiseErr:
        boolAbort = True
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

    Private Sub btnAddMakeup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMakeup.Click
        If String.IsNullOrEmpty(lblDescription.Text) Then
            MessageBox.Show("Please select the item code making up this inventory item", "Invalid Make-up Item Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboItems.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtMakeUpQuantity.Text) Then
            MessageBox.Show("Please enter the quantity for the item make-up", "Invalid Make-up Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQuantity.Focus()
            Exit Sub
        End If
        Dim dblCost As Double = 0
        If IsNumeric(lblCost.Text) Then dblCost = CDbl(lblCost.Text) * CDbl(txtMakeUpQuantity.Text)

        If CheckMakeupExistence(cboItems.Text) = True Then
            MessageBox.Show("Product already added to this service. Duplicate entry not allowed", _
                "Duplicate Makeup Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        With dGridMakeup
            .Rows.Add(cboItems.Text, lblDescription.Text, Format((CDbl(txtMakeUpQuantity.Text) * CDbl(txtQuantityPerService.Text)), "##0.00"), dblCost)
        End With

        'Compute the cost total
        '
        Dim dblTotal As Double = 0
        For i As Integer = 0 To dGridMakeup.Rows.Count - 1
            If IsNumeric(dGridMakeup.Rows(i).Cells(3).Value.ToString) Then
                dblTotal = dblTotal + CDbl(dGridMakeup.Rows(i).Cells(3).Value.ToString)
            End If
        Next
        txtComputedCost.Text = Format(dblTotal, "#,##0.00")

        cboItems.Text = ""
        lblDescription.Text = ""
        lblCost.Text = "0.00"
        txtMakeUpQuantity.Text = "1"

    End Sub

    Private Function CheckMakeupExistence(ByVal ItemCode As String) As Boolean
        Dim boolReturn As Boolean = False
        For i As Integer = 0 To dGridMakeup.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGridMakeup.Rows(i).Cells(0).Value), "")) Then
                If UCase(ItemCode) = UCase(dGridMakeup.Rows(i).Cells(0).Value.ToString) Then
                    boolReturn = True
                    Exit For
                End If
            End If
        Next
        Return boolReturn
    End Function

    Private Sub LoadMakeup()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT InventoryComponents.MakeupItemCode, InventoryItems.GroupName, " _
            & "InventoryComponents.Quantity, CAST(InventoryItems.CostPrice AS DECIMAL (10,2)) AS [CostPrice] " _
            & "FROM InventoryComponents LEFT OUTER JOIN InventoryItems " _
            & "ON InventoryComponents.MakeupItemCode = InventoryItems.ItemCode WHERE InventoryComponents.ItemCode = '" & strInventoryItemCode & "' " _
            & "ORDER BY InventoryComponents.MakeupItemCode", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGridMakeup.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3))
        End While
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Make-up Load"
        ShowErrorMessage()
    End Sub

    Private Sub SaveMakeUp()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM InventoryComponents WHERE ItemCode = '" & txtItemCode.Text & "'", cnn)
        objCommand.ExecuteNonQuery()
        For n As Integer = 0 To dGridMakeup.Rows.Count - 1
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO InventoryComponents (ItemCode, MakeupItemCode, Quantity) VALUES " _
                & "('" & txtItemCode.Text & "', '" & dGridMakeup.Rows(n).Cells(0).Value.ToString & "', " _
                & "" & dGridMakeup.Rows(n).Cells(2).Value.ToString & ")", cnn)
            objCommand.ExecuteNonQuery()
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Make-up Save"
        ShowErrorMessage()
    End Sub

    Private Sub LoadProducts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT ItemCode +';'+GroupName +';'+ CONVERT(NVARCHAR, " _
            & "CAST(PackItemCostPrice AS DECIMAL (10,2))) +';'+ CONVERT(NVARCHAR, SalesPackagingQuantity) AS " _
            & "[Items] FROM InventoryItems WHERE Offering = 'PRODUCT' AND Status = 'ACTIVE' " _
            & "AND ItemCode <> '" & strInventoryItemCode & "' ORDER BY ItemCode"
        'PackItemCostPrice, PackItemSalePrice
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

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'PRODUCT' AND Status = 'ACTIVE' AND ItemCode <> '" & strInventoryItemCode & "'", cnn)

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

    Private Sub cboItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItems.SelectedIndexChanged
        lblDescription.Text = Nothing : lblCost.Text = "0.00" : txtMakeUpQuantity.Text = "1"
        If Not cboItems.SelectedItem Is Nothing Then
            lblDescription.Text = cboItems.SelectedItem.Col2
            lblCost.Text = cboItems.SelectedItem.Col3
            txtQuantityPerService.Text = cboItems.SelectedItem.Col4
        End If
    End Sub

    Private Sub cboOfferType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOfferType.SelectedIndexChanged
        If UCase(cboOfferType.Text) = "PRODUCT" Or UCase(cboOfferType.Text) = "SERVICE" Then
            grpMakeUp.Enabled = True
        Else
            grpMakeUp.Enabled = False
        End If
    End Sub

    Private Sub txtSupplyPackQuantity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSupplyPackQuantity.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 13 Then cboSalesPackaging.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtSalesPackQuantity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalesPackQuantity.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub cboSupplyPackaging_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSupplyPackaging.SelectedIndexChanged
        If cboSupplyPackaging.Text = "PACK" Then
            txtSupplyPackQuantity.Enabled = True
        Else
            txtSupplyPackQuantity.Enabled = False
            txtSupplyPackQuantity.Text = "1"
        End If
    End Sub

    Private Sub cboSalesPackaging_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalesPackaging.SelectedIndexChanged
        If cboSalesPackaging.Text = "PACK" Then
            txtSalesPackQuantity.Enabled = True
        Else
            txtSalesPackQuantity.Enabled = False
            txtSalesPackQuantity.Text = "1"
        End If
    End Sub

    Private Sub ComputePackItemValues(ByVal SupplyQuantity As Double, ByVal SalesQuantity As Double, ByVal CostPrice As Double, ByVal SellingPrice As Double)

        Dim dblSupplyQuantity As Double = 1
        Dim dblSalesQuantity As Double = 1
        Dim dblCostPrice As Double = 0
        Dim dblSalesPrice As Double = 0

        Dim dblPackItemCostPrice As Double = 0
        Dim dblPackItemSalePrice As Double = 0

        If IsNumeric(txtUnitCost.Text) Then
            If CDbl(txtUnitCost.Text) > 0 Then
                dblCostPrice = CDbl(txtUnitCost.Text)
            End If
        End If
        If IsNumeric(txtUnitPrice.Text) Then
            If CDbl(txtUnitPrice.Text) > 0 Then
                dblSalesPrice = CDbl(txtUnitPrice.Text)
            End If
        End If

        If IsNumeric(txtSupplyPackQuantity.Text) Then
            If CDbl(txtSupplyPackQuantity.Text) > 1 Then
                dblSupplyQuantity = CDbl(txtSupplyPackQuantity.Text)
            End If
        End If

        If IsNumeric(txtSalesPackQuantity.Text) Then
            If CDbl(txtSalesPackQuantity.Text) > 1 Then
                dblSalesQuantity = CDbl(txtSalesPackQuantity.Text)
            End If
        End If

        If dblSupplyQuantity > 0 And dblCostPrice > 0 Then
            dblPackItemCostPrice = Math.Round((dblCostPrice / dblSupplyQuantity), 2)
        End If

        If dblSalesQuantity > 0 And dblSalesPrice > 0 Then
            dblPackItemSalePrice = Math.Round((dblSalesPrice / dblSupplyQuantity) * dblSalesQuantity, 2)
        End If

        txtUnitSupplyPrice.Text = Format(dblPackItemCostPrice, "###0.00")
        txtUnitSalePrices.Text = Format(dblPackItemSalePrice, "###0.00")

    End Sub

    Private Sub cboMeasurements_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMeasurements.SelectedIndexChanged
        If UCase(cboMeasurements.Text) = "NONE" Then txtStandardMeasure.Text = "1"
    End Sub

    Private Sub txtSupplyPackQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSupplyPackQuantity.TextChanged
        On Error Resume Next
        If Not IsNumeric(txtUnitCost.Text) Then txtUnitCost.Text = "0"
        If Not IsNumeric(txtUnitPrice.Text) Then txtUnitPrice.Text = "0"
        If Not IsNumeric(txtSupplyPackQuantity.Text) Then txtSupplyPackQuantity.Text = "1.00"
        If Not IsNumeric(txtSalesPackQuantity.Text) Then txtSalesPackQuantity.Text = "1.00"
        ComputePackItemValues(CDbl(txtSupplyPackQuantity.Text), CDbl(txtSalesPackQuantity.Text), CDbl(txtUnitCost.Text), CDbl(txtUnitPrice.Text))
        ComputePackQuantities()
    End Sub

    Private Sub txtSalesPackQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSalesPackQuantity.TextChanged
        On Error Resume Next
        If Not IsNumeric(txtUnitCost.Text) Then txtUnitCost.Text = "0"
        If Not IsNumeric(txtUnitPrice.Text) Then txtUnitPrice.Text = "0"
        If Not IsNumeric(txtSupplyPackQuantity.Text) Then txtSupplyPackQuantity.Text = "1.00"
        If Not IsNumeric(txtSalesPackQuantity.Text) Then txtSalesPackQuantity.Text = "1.00"
        ComputePackItemValues(CDbl(txtSupplyPackQuantity.Text), CDbl(txtSalesPackQuantity.Text), CDbl(txtUnitCost.Text), CDbl(txtUnitPrice.Text))
    End Sub

    Private Sub txtUnitCost_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtUnitCost.Validating
        On Error Resume Next
        If Not IsNumeric(txtUnitCost.Text) Then txtUnitCost.Text = "0"
        If Not IsNumeric(txtUnitPrice.Text) Then txtUnitPrice.Text = "0"
        If Not IsNumeric(txtSupplyPackQuantity.Text) Then txtSupplyPackQuantity.Text = "1.00"
        If Not IsNumeric(txtSalesPackQuantity.Text) Then txtSalesPackQuantity.Text = "1.00"
        ComputePackItemValues(CDbl(txtSupplyPackQuantity.Text), CDbl(txtSalesPackQuantity.Text), CDbl(txtUnitCost.Text), CDbl(txtUnitPrice.Text))
    End Sub

    Private Sub txtUnitPrice_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtUnitPrice.Validating
        On Error Resume Next
        If Not IsNumeric(txtUnitCost.Text) Then txtUnitCost.Text = "0"
        If Not IsNumeric(txtUnitPrice.Text) Then txtUnitPrice.Text = "0"
        If Not IsNumeric(txtSupplyPackQuantity.Text) Then txtSupplyPackQuantity.Text = "1.00"
        If Not IsNumeric(txtSalesPackQuantity.Text) Then txtSalesPackQuantity.Text = "1.00"
        ComputePackItemValues(CDbl(txtSupplyPackQuantity.Text), CDbl(txtSalesPackQuantity.Text), CDbl(txtUnitCost.Text), CDbl(txtUnitPrice.Text))
    End Sub

    Private Sub ComputePackQuantities()
        On Error Resume Next
        If IsNumeric(txtQuantity.Text) Then
            If CDbl(txtQuantity.Text) > 0 Then
                If IsNumeric(txtSupplyPackQuantity.Text) Then
                    If CDbl(txtSupplyPackQuantity.Text) > 0 Then
                        Dim dblFullPacks As Double = 0
                        Dim dblPartialPacks As Double = 0
                        dblFullPacks = Math.Floor(CDbl(txtQuantity.Text) / CDbl(txtSupplyPackQuantity.Text))
                        dblPartialPacks = CDbl(txtQuantity.Text) - (dblFullPacks * CDbl(txtSupplyPackQuantity.Text))
                        txtFullPacks.Text = Format((Math.Round(dblFullPacks, 2)), "##0.00")
                        txtPartialPacks.Text = Format((Math.Round(dblPartialPacks, 2)), "##0.00")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        On Error Resume Next
        ComputePackQuantities()
    End Sub

    Private Sub txtSize_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSize.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtStandardMeasure.Focus()
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtSize_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSize.Validating
        ValidatePackSizeToContents()
    End Sub

    Private Sub ValidatePackSizeToContents()
        'Validate based on standard measure and quanties in pack. Only warn the user
        If IsNumeric(txtSize.Text) Then
            If CDbl(txtSize.Text) > 0 Then
                If IsNumeric(txtSupplyPackQuantity.Text) Then
                    If CDbl(txtSupplyPackQuantity.Text) > 0 Then
                        If IsNumeric(txtStandardMeasure.Text) Then
                            If CDbl(txtStandardMeasure.Text) Then
                                Dim dblTest As Double = CDbl(txtSize.Text) / CDbl(txtStandardMeasure.Text)
                                If Math.Round(CDbl(txtSupplyPackQuantity.Text), 2) <> Math.Round(dblTest, 2) Then
                                    If MessageBox.Show("The computed quantities in pack do not tally to pack quantity." & vbCrLf & _
                                            "Do you want the system to adjust the figures?", "Inconsistant Pack Quantities", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                                        txtSupplyPackQuantity.Text = Format(dblTest, "##0.00")
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtStandardMeasure_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStandardMeasure.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtStandardMeasure_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtStandardMeasure.Validating
        ValidatePackSizeToContents()
    End Sub

    Private Sub txtMakeUpQuantity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMakeUpQuantity.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnAddMakeup.Focus()
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub mCboCostCenters_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCboCostCenters.SelectedIndexChanged
        lblCostCode.Text = "0"
        lblCostCode.Text = mCboCostCenters.SelectedItem.Col2
    End Sub

    Private Sub LoadUnitsOfMeasure()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT UnitOfMeasure FROM OchmasUnitsOfMeasure ORDER BY UnitOfMeasure", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboMeasurements.Items.Clear()
        cboMeasurements.Items.Add("NONE")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboMeasurements.Items.Add(objReader(0))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On units of measure load"
        ShowErrorMessage()
    End Sub

    Private Sub dGridLandedCosts_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridLandedCosts.CellEndEdit
        If dGridLandedCosts.CurrentCell.ColumnIndex = 2 Then
            If IsNumeric(dGridLandedCosts.CurrentCell.Value) Then dGridLandedCosts.CurrentCell.Value = Format(CDbl(dGridLandedCosts.CurrentCell.Value.ToString), "##0.00")
        End If
    End Sub

    Private Sub LoadLandedCosts()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT InventoryCostsParameters.OrdinalNo, InventoryCostsParameters.CostParameterName " _
            & "FROM InventoryCostsParameters ORDER BY InventoryCostsParameters.OrdinalNo"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(1).ToString) Then
                If Not String.IsNullOrEmpty(objReader(1).ToString) Then
                    Dim strSelect As String = "SELECT InventoryItemsCostsAnalysis.CostFactor FROM " _
                        & "InventoryItemsCostsAnalysis WHERE ItemCode = '" & strInventoryItemCode & "' " _
                        & "AND OrdinalNo = " & objReader(0).ToString & ""
                    Dim objCommandFactors As New Data.OleDb.OleDbCommand(strSelect, cnn)
                    Dim objReadFactors As Data.OleDb.OleDbDataReader = objCommandFactors.ExecuteReader

                    Dim dblFactor As Double = 0

                    If objReadFactors.HasRows Then
                        objReadFactors.Read()
                        If IsNumeric(objReadFactors(0).ToString) Then dblFactor = CDbl(objReadFactors(0).ToString)
                    End If
                    objCommandFactors.Clone()

                    dGridLandedCosts.Rows.Add(objReader(0), objReader(1), Format(dblFactor, "##0.00"))
                End If
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On landed costs details load"
        ShowErrorMessage()
    End Sub

    Private Sub SaveLandedCosts()
        On Error GoTo RaiseErr

        'First delete the records sitting in the current table
        Dim objCommandDelete As New Data.OleDb.OleDbCommand("DELETE FROM InventoryItemsCostsAnalysis " _
            & "WHERE ItemCode = '" & txtItemCode.Text & "'", cnn)
        objCommandDelete.ExecuteNonQuery()

        For i As Integer = 0 To dGridLandedCosts.Rows.Count - 1
            Dim intKey As Integer = 0
            Dim dblFactor As Double = 0
            If Not (Object.Equals(Convert.ToString(dGridLandedCosts.Rows(i).Cells(0).Value), "")) Then
                If IsNumeric(dGridLandedCosts.Rows(i).Cells(0).Value) Then
                    intKey = CInt(dGridLandedCosts.Rows(i).Cells(0).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridLandedCosts.Rows(i).Cells(2).Value), "")) Then
                If IsNumeric(dGridLandedCosts.Rows(i).Cells(2).Value) Then
                    dblFactor = CDbl(dGridLandedCosts.Rows(i).Cells(2).Value.ToString)
                End If
            End If

            Dim strSql As String = "INSERT INTO InventoryItemsCostsAnalysis " _
                & "([ItemCode], [OrdinalNo], [CostFactor]) VALUES ('" & txtItemCode.Text & "', " _
                & "" & intKey & ", " & dblFactor & ")"
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On landed costs details save"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintMovement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintMovement.Click
        ' Show Page Setup dialog
        ' Chart1.Printing.PageSetup()

        ' Print preview chart
        Chart1.Printing.PrintPreview()

        ' Print chart (without Printer dialog)
        ' Chart1.Printing.Print(False)

    End Sub

    Private Sub GenerateStockMovementHistory()
        On Error GoTo RaiseErr

        Dim arrSQL As New ArrayList

        With arrSQL
            .Add("IF NOT OBJECT_ID(N'Inventory_Temp_Table', N'U') IS NULL DROP TABLE Inventory_Temp_Table")
            .Add("SELECT DATENAME (yyyy, OrdersReceipt.TransDate ) as [TransYear], DATEPART(mm, OrdersReceipt.transdate) as [TransMonth], " _
                 & "SUM(Quantity) AS [Received] INTO Inventory_Temp_Table FROM OrdersReceipt WHERE ItemCode = '" & strInventoryItemCode & "' " _
                 & "GROUP BY DATEPART(month, TransDate), DATEPART(Year, TransDate), TransDate, Quantity ORDER BY TransDate")
            .Add("ALTER TABLE Inventory_Temp_Table ADD [TransfersIn][Float] NOT NULL DEFAULT 0, [Sales][Float] NOT NULL DEFAULT 0, [TransfersOut][Float] NOT NULL DEFAULT 0")
            .Add("INSERT INTO Inventory_Temp_Table (TransYear, TransMonth, TransfersIn) " _
                 & "SELECT DATENAME (yyyy, InventoryTransfers.TransDate ) as [TransYear], DATEPART(mm, InventoryTransfers.transdate) as [TransMonth], " _
                 & "SUM(Quantity) AS [TransfersIn] FROM InventoryTransfers WHERE ItemCode = '" & strInventoryItemCode & "' AND " _
                 & "ReceivingBranch = '" & strUserBranch & "' GROUP BY DATEPART(month, TransDate), DATEPART(Year, TransDate), TransDate, Quantity ORDER BY TransDate")
            .Add("INSERT INTO Inventory_Temp_Table (TransYear, TransMonth, Sales) " _
                 & "SELECT DATENAME (yyyy, Sales.TransDate ) as [TransYear], DATEPART(mm, Sales.transdate) as [TransMonth], SUM(Quantity) AS [Sales] " _
                 & "FROM Sales WHERE ItemCode = '" & strInventoryItemCode & "' GROUP BY DATEPART(month, TransDate), DATEPART(Year, TransDate), TransDate, " _
                 & "Quantity ORDER BY TransDate")
            .Add("INSERT INTO Inventory_Temp_Table (TransYear, TransMonth, Sales) SELECT DATENAME (yyyy, CustomerSales.TransDate ) as [TransYear], " _
                 & "DATEPART(mm, CustomerSales.transdate) as [TransMonth], SUM(Quantity) AS [Sales] FROM CustomerSales " _
                 & "WHERE ItemCode = '" & strInventoryItemCode & "' GROUP BY DATEPART(month, TransDate), DATEPART(Year, TransDate), TransDate, Quantity ORDER BY TransDate")
            .Add("INSERT INTO Inventory_Temp_Table (TransYear, TransMonth, TransfersOut) " _
                 & "SELECT DATENAME (yyyy, InventoryTransfers.TransDate ) as [TransYear], DATEPART(mm, InventoryTransfers.transdate) as [TransMonth], " _
                 & "SUM(Quantity) AS [TransfersOut] FROM InventoryTransfers WHERE ItemCode = '" & strInventoryItemCode & "' AND " _
                 & "SourceBranch = '" & strUserBranch & "' GROUP BY DATEPART(month, TransDate), DATEPART(Year, TransDate), TransDate, Quantity ORDER BY TransDate")
            .Add("UPDATE Inventory_Temp_Table SET Received = 0 WHERE Received is NULL")
            .Add("SELECT TransYear, TransMonth, SUM(Received) AS [Received], SUM(TransfersIn) as [TransfersIn], SUM(Sales) AS [SoldItems], " _
                 & "SUM(TransfersOut) AS [TransfersOut] FROM Inventory_Temp_Table GROUP BY TransYear, TransMonth ORDER BY TransYear, TransMonth")
        End With

        Dim objReader As Data.OleDb.OleDbDataReader
        For i As Integer = 0 To arrSQL.Count - 1
            Dim objCommand As New Data.OleDb.OleDbCommand(arrSQL.Item(i), cnn)
            If i = arrSQL.Count - 1 Then
                objReader = objCommand.ExecuteReader
            Else
                objCommand.ExecuteNonQuery()
            End If
        Next

        Dim dblNetMovement As Double = 0
        dGridStockMovement.Rows.Clear()
        While objReader.Read

            Dim dblReceived As Double = 0
            Dim dblTransferIn As Double = 0
            Dim dblSold As Double = 0
            Dim dblTransferOut As Double = 0

            Dim dblCurrentMovement As Double = 0

            If IsNumeric(objReader("Received").ToString) Then dblReceived = CDbl(objReader("Received").ToString)
            If IsNumeric(objReader("TransfersIn").ToString) Then dblTransferIn = CDbl(objReader("TransfersIn").ToString)
            If IsNumeric(objReader("SoldItems").ToString) Then dblSold = CDbl(objReader("SoldItems").ToString)
            If IsNumeric(objReader("TransfersOut").ToString) Then dblTransferOut = CDbl(objReader("TransfersOut").ToString)

            dblCurrentMovement = (dblReceived + dblTransferIn) - (dblTransferOut + dblSold)
            dblNetMovement = dblNetMovement + dblCurrentMovement

            dGridStockMovement.Rows.Add(objReader(0), UCase(MonthName(CInt(objReader(1).ToString), True)), _
                dblReceived, dblTransferIn, dblSold, dblTransferOut, dblCurrentMovement, dblNetMovement)

        End While

        objReader.Close()

        'Drop the temp inventory table
        Dim objDropCommand As New Data.OleDb.OleDbCommand(arrSQL.Item(0), cnn)
        objDropCommand.ExecuteNonQuery()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On stock movement history"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSalesCostsMovements()
        On Error GoTo RaiseErr
        Dim arrSQL As New ArrayList

        With arrSQL
            .Add("IF NOT OBJECT_ID(N'Inventory_Temp_Costs_Table', N'U') IS NULL DROP TABLE Inventory_Temp_Costs_Table")
            .Add("SELECT DISTINCT DATENAME (yyyy, Sales.TransDate ) as [TransYear], DATEPART(mm, Sales.transdate) as [TransMonth], " _
                 & "CAST(CostPrice AS DECIMAL (10,2)) AS [Cost], CAST(SalesPrice AS DECIMAL(10,2)) AS [Sale] INTO Inventory_Temp_Costs_Table " _
                 & "FROM Sales WHERE ItemCode = '" & strInventoryItemCode & "' GROUP BY DATEPART(month, TransDate), DATEPART(Year, TransDate), " _
                 & "CostPrice, SalesPrice, TransDate ORDER BY TransYear, TransMonth")
            .Add("INSERT INTO Inventory_Temp_Costs_Table (TransYear, TransMonth, Cost, Sale) " _
                 & "SELECT DISTINCT DATENAME (yyyy, CustomerSales.TransDate ) as [TransYear], DATEPART(mm, CustomerSales.transdate) as [TransMonth], " _
                 & "CAST(CostPrice AS DECIMAL (10,2)) AS [Cost], CAST(SalesPrice AS DECIMAL(10,2)) AS [Sale] FROM CustomerSales WHERE " _
                 & "ItemCode = '" & strInventoryItemCode & "' GROUP BY DATEPART(month, TransDate), DATEPART(Year, TransDate), CostPrice, SalesPrice, " _
                 & "TransDate ORDER BY TransYear, TransMonth")
            .Add("SELECT * FROM Inventory_Temp_Costs_Table")
        End With

        Dim objReader As Data.OleDb.OleDbDataReader
        For i As Integer = 0 To arrSQL.Count - 1
            Dim objCommand As New Data.OleDb.OleDbCommand(arrSQL.Item(i), cnn)
            If i = arrSQL.Count - 1 Then
                objReader = objCommand.ExecuteReader
            Else
                objCommand.ExecuteNonQuery()
            End If
        Next

        dGridCostsMovement.Rows.Clear()
        While objReader.Read

            Dim dblMargins As Double = 0
            Dim dblCostPrice As Double = 0
            Dim dblSellingPrice As Double = 0

            If IsNumeric(objReader("Cost").ToString) Then dblCostPrice = CDbl(objReader("Cost").ToString)
            If IsNumeric(objReader("Sale").ToString) Then dblSellingPrice = CDbl(objReader("Sale").ToString)

            dblMargins = ((dblSellingPrice - dblCostPrice) / dblCostPrice) * 100

            dGridCostsMovement.Rows.Add(objReader(0), UCase(MonthName(CInt(objReader(1).ToString), True)), _
                dblCostPrice, dblSellingPrice, Format(dblMargins, "##0.00"))

        End While
        'Drop the temp inventory table
        Dim objDropCommand As New Data.OleDb.OleDbCommand(arrSQL.Item(0), cnn)
        objDropCommand.ExecuteNonQuery()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On price movement history"
        ShowErrorMessage()
    End Sub

    Private Sub pdInventory_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdInventory.PrintPage

    End Sub

    Private Sub btnPrintSalesFigure_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSalesFigure.Click
        'gwt_comm.PrintDataGrid(dgridHistory, "SALES HISTORY FOR " & UCase(strInventoryItemCode))
    End Sub

    Private Sub btnCostsToSales_Click(sender As System.Object, e As System.EventArgs) Handles btnCostsToSales.Click
        'gwt_comm.PrintDataGrid(dGridCostsMovement, "COST TO SALES HISTORY FOR " & UCase(strInventoryItemCode))
    End Sub

    Private Sub btnStockMovements_Click(sender As System.Object, e As System.EventArgs) Handles btnStockMovements.Click
        'gwt_comm.PrintDataGrid(dGridStockMovement, "STOCK MOVEMENT HISTORY FOR " & UCase(strInventoryItemCode))
    End Sub

    Private Sub btnEditCode_Click(sender As System.Object, e As System.EventArgs) Handles btnEditCode.Click
        boolAbort = False
        Dim frm As New frmInventoryNewCode
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        strInventoryItemCode = strNewInventoryItemCode
        txtItemCode.Text = strNewInventoryItemCode
    End Sub

    Private Sub btnCheck_Click(sender As System.Object, e As System.EventArgs) Handles btnCheck.Click
        strPublicItemCode = Nothing
        boolAbort = False
        Dim frm As New frmFindInventory
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        txtItemCode.Text = strPublicItemCode
    End Sub

    Private Sub btnAddShortCodeDescriptions_Click(sender As System.Object, e As System.EventArgs) Handles btnAddShortCodeDescriptions.Click
        If Not String.IsNullOrEmpty(txtShortCode.Text) Then
            boolCalledFromListing = False
            boolEditStatus = False
            strselectedShortCode = txtShortCode.Text
            Dim frm As New frmShortCodeDescriptionSetup
            frm.ShowDialog()
        Else
            MessageBox.Show("You must enter the short code first", "Missing Short Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtShortCode.Focus()
        End If
    End Sub

End Class