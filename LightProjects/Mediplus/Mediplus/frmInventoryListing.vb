Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventoryListing

    Dim strNavigateDirection As String = Nothing
    Dim boolHeaderClicked As Boolean = False
    Dim strViewMode As String = "USER BRANCH"

    Private Sub btnCloseTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim f As New frmInventorySetup
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim strViewStatus As String = "ALL"
        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
            & "FROM InventoryItems ORDER BY ItemCode"

        grd.Columns.Clear()
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        grd.DataSource = dTable

        Me.grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        If UCase(strUserLevel) <> "MANAGER" Then
            If UCase(strUserLevel) <> "ADMINISTRATOR" Then
                grd.Columns(4).Visible = False
            End If
        End If

        For p As Integer = 0 To grd.Columns.Count - 1
            grd.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p = 2 Then grd.Columns(p).Visible = False
            If p = 3 Or p = 4 Then
                grd.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Items Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmInventoryListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Bar1.Visible = False
        LoadData()
        'LoadBranches()
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
            btnEdit.Enabled = ButtonEnabled.True
            btnNew.Enabled = ButtonEnabled.True
            btnRefresh.Enabled = ButtonEnabled.True
            btnPrint.Enabled = ButtonEnabled.True
            btnChangeCodes.Enabled = ButtonEnabled.True
        Else
            Select Case IntPublicInventory
                Case Is = 2
                    btnEdit.Enabled = ButtonEnabled.True
                    btnNew.Enabled = ButtonEnabled.True
                    btnRefresh.Enabled = ButtonEnabled.True
                    btnPrint.Enabled = ButtonEnabled.True
                    btnChangeCodes.Enabled = ButtonEnabled.True
                Case Is = 1
                    btnEdit.Enabled = ButtonEnabled.True
                    btnNew.Enabled = ButtonEnabled.False
                    btnRefresh.Enabled = ButtonEnabled.True
                    btnPrint.Enabled = ButtonEnabled.True
                    btnChangeCodes.Enabled = ButtonEnabled.False
                Case Else
                    btnEdit.Enabled = ButtonEnabled.False
                    btnNew.Enabled = ButtonEnabled.False
                    btnRefresh.Enabled = ButtonEnabled.False
                    btnPrint.Enabled = ButtonEnabled.False
                    btnChangeCodes.Enabled = ButtonEnabled.False
            End Select
        End If

        'cboBranchView.Text = UCase(strUserBranch)
        'If UCase(strPublicStockManagementType) = "DE-CENTRALIZED" Then cboBranchView.Enabled = False Else cboBranchView.Enabled = True
        If UCase(strDefaultSearchFilter) = "DESCRIPTION" Then cboSearchBy.SelectedIndex = 1 Else cboSearchBy.SelectedIndex = 0
        Bar1.Visible = True
    End Sub

    Private Sub grd_ColumnDividerDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnDividerDoubleClickEventArgs) Handles grd.ColumnDividerDoubleClick
        boolHeaderClicked = True
    End Sub

    Private Sub grd_ColumnHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd.ColumnHeaderMouseDoubleClick
        boolHeaderClicked = True
    End Sub

    Private Sub grd_dblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.DoubleClick
        EditSelectedInventory()
    End Sub

    Private Sub EditSelectedInventory()
        If btnChangeCodes.Enabled = ButtonEnabled.False Then Exit Sub
        If boolHeaderClicked = True Then
            'boolHeaderClicked = False
            Exit Sub
        End If
        If grd.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedDetails()
            arrInventoryEditData = New ArrayList
            Dim iRowIndex As Integer = grd.CurrentRow.Index
            Dim f As New frmInventorySetup
            f.ShowDialog()
            If UCase(strActiveSearch) = "SEARCH ITEM" Then
                txtSearchString.Text = strInventoryItemCode
            Else
                If String.IsNullOrEmpty(txtSearchString.Text) Then
                    'LoadData()
                    'Set the current row data to updated view
                    With grd
                        If arrInventoryEditData.Count <= 0 Then Exit Sub
                        For p As Integer = 0 To arrInventoryEditData.Count - 1
                            .Rows(iRowIndex).Cells(p).Value = UCase(arrInventoryEditData.Item(p))
                        Next
                        .FirstDisplayedScrollingRowIndex = iRowIndex
                    End With
                Else
                    txtSearchString.Text = strActiveSearch
                    With grd
                        If Not arrInventoryEditData Is Nothing Then
                            For p As Integer = 0 To arrInventoryEditData.Count - 1
                                .Rows(iRowIndex).Cells(p).Value = UCase(arrInventoryEditData.Item(p))
                            Next
                            .FirstDisplayedScrollingRowIndex = iRowIndex
                        End If
                    End With
                End If
            End If
        End If
    End Sub

    Private Sub GetSelectedDetails()
        Dim CurrentCellValue As String
        CurrentCellValue = grd.CurrentRow.Cells(0).Value
        strActiviteStatus = grd.CurrentRow.Cells(6).Value
        strInventoryItemCode = CurrentCellValue
    End Sub

    'Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
    '    If grd.Rows.Count <= 0 Then Exit Sub
    '    strNavigateDirection = "First"
    '    grd.Rows(0).Selected = True
    '    grd.CurrentCell = grd(0, 0)
    '    txtRecordIndex.Text = CStr(grd.CurrentRow.Index + 1) & " of " & grd.Rows.Count
    'End Sub

    'Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
    '    If grd.CurrentRow.Index = grd.Rows.Count - 1 Or grd.Rows.Count <= 0 Then Exit Sub
    '    strNavigateDirection = "Next"
    '    grd.Rows(grd.CurrentRow.Index + 1).Selected = True
    '    grd.CurrentCell = grd(0, grd.CurrentRow.Index + 1)
    '    txtRecordIndex.Text = CStr(grd.CurrentRow.Index + 1) & " of " & grd.Rows.Count
    'End Sub

    'Private Sub btnPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
    '    If grd.CurrentRow.Index = 0 Or grd.Rows.Count <= 0 Then Exit Sub
    '    strNavigateDirection = "Previous"
    '    grd.Rows(grd.CurrentRow.Index - 1).Selected = True
    '    grd.CurrentCell = grd(0, grd.CurrentRow.Index - 1)
    '    txtRecordIndex.Text = CStr(grd.CurrentRow.Index + 1) & " of " & grd.Rows.Count
    'End Sub

    'Private Sub btnLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLast.Click
    '    If grd.Rows.Count <= 0 Then Exit Sub
    '    strNavigateDirection = "Last"
    '    grd.Rows(grd.Rows.Count - 1).Selected = True
    '    grd.CurrentCell = grd(0, grd.Rows.Count - 1)
    '    txtRecordIndex.Text = CStr(grd.CurrentRow.Index + 1) & " of " & grd.Rows.Count
    'End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        EditSelectedInventory()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        strActiveSearch = strFind
        Cursor = Cursors.WaitCursor

        grd.Columns.Clear()
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim strSql As String = Nothing

        Select Case cboSearchBy.Text
            Case Is = "Item Code"
                strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                    & "FROM InventoryItems WHERE ItemCode LIKE '%" & strFind & "%' ORDER BY ItemCode"

            Case Is = "Description" 'Use the group name
                strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                    & "FROM InventoryItems WHERE GroupName LIKE '%" & strFind & "%' ORDER BY GroupName, ItemCode"

            Case Is = "Category"
                strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                    & "FROM InventoryItems WHERE Category LIKE '%" & strFind & "%' ORDER BY Category, ItemCode"

            Case Is = "Sub Category"
                strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                    & "FROM InventoryItems WHERE SubCategory LIKE '%" & strFind & "%' ORDER BY SubCategory, ItemCode"

            Case Else
                strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                    & "FROM InventoryItems WHERE ItemCode LIKE '%" & strFind & "%' ORDER BY ItemCode"

        End Select

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        grd.DataSource = dTable

        Me.grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        For p As Integer = 0 To grd.Columns.Count - 1
            grd.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p = 2 Then grd.Columns(p).Visible = False
            If p = 3 Or p = 4 Then
                grd.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        'grd.Columns(2).Visible = False
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
        Exit Sub
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("select ItemCode, GroupName as [Description], " _
            & "Category, SubCategory, CAST(SellingPrice AS DECIMAL (10,2)) AS [Sale Price], " _
            & "CAST(CostPrice AS DECIMAL (10,2)) AS [Cost Price], Quantity from inventoryitems " _
            & "ORDER BY Category, SubCategory, GroupName, ItemCode", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        'Assign the values to the print array
        Dim arrPrintData As New ArrayList
        While objReader.Read
            Dim strDataRow As String = Nothing
            For i As Integer = 0 To objReader.FieldCount - 1
                If i = 0 Then
                    If Not IsDBNull(objReader(i).ToString) Then strDataRow = objReader(i).ToString & ";" Else strDataRow = ";"
                Else
                    strDataRow = strDataRow & objReader(i).ToString & ";"
                End If
            Next
            strDataRow = Mid(strDataRow, 1, (strDataRow.Length - 1))
            arrPrintData.Add(strDataRow)
        End While
        objReader.Close()

        If arrPrintData.Count <= 0 Then
            MessageBox.Show("No details to print", "No Print Details", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        'Add the details to the print class print array

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 7
            .strColumnHeaders = "CODE|DESCRIPTION|CATEGORY|SUB CAT.|SALE $|COST $|"
            .strColumnAlignments = "0|0|0|0|2|2|2"
            .strColumnWidths = "175|175|90|80|65|65|0"
            .strFooterCaption = "Inventory Analysis Report "
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "INVENTORY REPORT"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|YES|YES|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = True
            .boolPrintTotals = True
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|YES|YES|NO"
            .intKeyFieldIndex = 3
            .strPrintValues = strPrintDetails
        End With
        If strRequestForReceiptPrinter = "YES" Then
            boolAbort = False
            Dim f As New frmPrinterSetup
            f.ShowDialog()
            If boolAbort = True Then Exit Sub
            rpt.PrinterSettings.PrinterName = strSessionPrinter
        End If
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Report Print"
        ShowErrorMessage()
    End Sub

    Private Sub txtSearchString_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchString.TextChanged
        SearchForItem("")
    End Sub

    Private Sub DeleteSelectedItems()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrRemoveRows As New ArrayList
        If grd.Rows.Count > 0 Then
            'GetSelectedDetails()
            If MessageBox.Show("Are you sure you want to delete the selected items?", _
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                For i As Integer = 0 To grd.SelectedRows.Count - 1
                    strInventoryItemCode = grd.SelectedRows.Item(i).Cells(0).Value.ToString
                    Dim strSql As String = "SELECT [ItemCode],[GroupName],[Description],[SellingPrice]," _
                        & "[CostPrice],[Location],[Category],[SubCategory],[Quantity],[InventoryType]," _
                        & "[MinimumLevel],[WarningLevel],[IdealLevel],[TaxStatus],[SerialNumbers],[BarCodeNo]," _
                        & "[ItemColor],[Size],[UnitOfMeasure],[FullBarcodeSerialStatus],[Offering],[Status]," _
                        & "[ShortCode],[Uom],[MasterPackQty],[InnerPackQty],[CaseLength],[CaseWidth]," _
                        & "[CaseHeight],[CaseWeight],[ProductLength],[ProductWidth],[ProductHeight]," _
                        & "[ProductWeight],[DateIntroduced],[SoUomName],[SoUomRatioStd],[SoUomRatio]," _
                        & "[PoUomName],[PoUomRatioStd],[PoUomRatio],[SupplyPackaging],[SalesPackaging]," _
                        & "[SupplyPackagingQuantity],[SalesPackagingQuantity],[PackItemCostPrice]," _
                        & "[PackItemSalePrice],[CostCode],[TaxCode],[ItemShortCode] FROM InventoryItems WHERE ItemCode = '" & strInventoryItemCode & "'"
                    Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                    Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        strSql = "INSERT INTO InventoryItemsDeleted ([ItemCode],[GroupName],[Description],[SellingPrice]," _
                        & "[CostPrice],[Location],[Category],[SubCategory],[Quantity],[InventoryType]," _
                        & "[MinimumLevel],[WarningLevel],[IdealLevel],[TaxStatus],[SerialNumbers],[BarCodeNo]," _
                        & "[ItemColor],[Size],[UnitOfMeasure],[FullBarcodeSerialStatus],[Offering],[Status]," _
                        & "[ShortCode],[Uom],[MasterPackQty],[InnerPackQty],[CaseLength],[CaseWidth]," _
                        & "[CaseHeight],[CaseWeight],[ProductLength],[ProductWidth],[ProductHeight]," _
                        & "[ProductWeight],[DateIntroduced],[SoUomName],[SoUomRatioStd],[SoUomRatio]," _
                        & "[PoUomName],[PoUomRatioStd],[PoUomRatio],[SupplyPackaging],[SalesPackaging]," _
                        & "[SupplyPackagingQuantity],[SalesPackagingQuantity],[PackItemCostPrice]," _
                        & "[PackItemSalePrice],[CostCode],[TaxCode],[ItemShortCode], [UserName], [TransDate]) VALUES " _
                        & "('" & objReader("ItemCode") & "', '" & objReader("GroupName") & "', '" & objReader("Description") & "', " _
                        & "" & objReader("SellingPrice") & ", " & objReader("CostPrice") & ", " _
                        & "'" & objReader("Location") & "', '" & objReader("Category") & "', '" & objReader("SubCategory") & "', " & objReader("Quantity") & ", " _
                        & "'" & objReader("InventoryType") & "', " & objReader("MinimumLevel") & ", " & objReader("WarningLevel") & ", " & objReader("IdealLevel") & ", " _
                        & "'" & objReader("TaxStatus") & "', '" & objReader("SerialNumbers") & "', '" & objReader("BarCodeNo") & "', '" & objReader("ItemColor") & "', " _
                        & "'" & objReader("Size") & "', '" & objReader("UnitOfMeasure") & "', '" & objReader("FullBarcodeSerialStatus") & "', '" & objReader("Offering") & "', " _
                        & "'" & objReader("Status") & "', '" & objReader("ShortCode") & "', '" & objReader("Uom") & "', " & objReader("MasterPackQty") & ", " _
                        & "" & objReader("InnerPackQty") & ", " & objReader("CaseLength") & ", " & objReader("CaseWidth") & ", " & objReader("CaseHeight") & ", " _
                        & "" & objReader("CaseWeight") & ", " & objReader("ProductLength") & ", " & objReader("ProductWidth") & ", " & objReader("ProductHeight") & ", " _
                        & "" & objReader("ProductWeight") & ", '" & objReader("DateIntroduced") & "', '" & objReader("SoUomName") & "', '" & objReader("SoUomRatioStd") & "', " _
                        & "'" & objReader("SoUomRatio") & "', '" & objReader("PoUomName") & "', '" & objReader("PoUomRatioStd") & "', '" & objReader("PoUomRatio") & "', " _
                        & "'" & objReader("SupplyPackaging") & "', '" & objReader("SalesPackaging") & "', " & objReader("SupplyPackagingQuantity") & ", '" & objReader("SalesPackagingQuantity") & "', " _
                        & "" & objReader("PackItemCostPrice") & ", " & objReader("PackItemSalePrice") & ", " & objReader("CostCode") & ", '" & objReader("TaxCode") & "', " _
                        & "'" & objReader("ItemShortCode") & "', '" & strUserName & "', '" & Now & "')"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                    objReader.Close()

                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM InventoryItems WHERE Itemcode = '" & strInventoryItemCode & "'", cnn)
                    objCommand.ExecuteNonQuery()

                    'Store the deleted serial numbers as well
                    'SerialNumbersDeleted
                    strSql = "SELECT [ItemCode],[SerialNumber],[BarCodeNo],[SourceSerialNo],[Availability],[CostPrice] " _
                        & "FROM SerialNumbers WHERE ItemCode = '" & strInventoryItemCode & "'"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objReader = objCommand.ExecuteReader
                    While objReader.Read
                        strSql = "INSERT INTO SerialNumbersDeleted ([ItemCode],[SerialNumber],[BarCodeNo],[SourceSerialNo]," _
                            & "[Availability],[CostPrice], [UserName], [TransDate]) VALUES ('" & objReader(0) & "', " _
                            & "'" & objReader(1) & "', '" & objReader(2) & "', '" & objReader(3) & "', " _
                            & "'" & objReader(4) & "', " & objReader(5) & ", '" & strUserName & "', '" & Now & "')"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End While
                    objReader.Close()
                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers WHERE Itemcode = '" & strInventoryItemCode & "'", cnn)
                    objCommand.ExecuteNonQuery()
                    arrRemoveRows.Add(grd.SelectedRows.Item(i).Index)
                Next

                'Delete all the selected items from the grid
                'LoadData()
                For i As Integer = 0 To arrRemoveRows.Count - 1
                    grd.Rows.RemoveAt(CInt(arrRemoveRows.Item(i)))
                Next
                MessageBox.Show("Inventory Item Deleted successfully", "Inventory Item Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On inventory item delete"
        ShowErrorMessage()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        DeleteSelectedItems()
    End Sub

    Private Sub DeactivateInventoryItems()
        On Error GoTo RaiseErr
        If grd.Rows.Count <= 0 Then
            MessageBox.Show("Process cannot be executed as there are no inventory items", "No Inventory Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim arrRemoveRows As New ArrayList
        Cursor = Cursors.WaitCursor
        If MessageBox.Show("Are you sure you want to de-activate the selected inventory items?", "Confirm De-activation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            'GetSelectedDetails()

            For i As Integer = 0 To grd.SelectedRows.Count - 1
                strInventoryItemCode = grd.SelectedRows.Item(i).Cells(0).Value.ToString
                'Check that the quantity is zero and that there are no serial numbers attached
                Dim dblQty As Double = 0
                Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then dblQty = CDbl(objReader(0).ToString)
                End If
                objReader.Close()
                If dblQty <> 0 Then
                    MessageBox.Show("Item cannot be de-activated until you have resolved the quantity issue." & vbCrLf & _
                        "Currently there are " & dblQty & " units of this item in stock", _
                        "Process Cannot Proceed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                'Check the serial numbers as well
                Dim dblSerialCnt As Double = 0
                objCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(ItemCode) FROM SerialNumbers WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then dblSerialCnt = CDbl(objReader(0).ToString)
                End If
                objReader.Close()
                If dblSerialCnt <> 0 Then
                    MessageBox.Show("Item cannot be de-activated until you have resolved the serial numbers issue." & vbCrLf & _
                        "Currently there are " & dblSerialCnt & " units of this item in serial numbers", _
                        "Process Cannot Proceed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                objCommand = New Data.OleDb.OleDbCommand("Update InventoryItems SET Status = 'INACTIVE' " _
                    & "WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
                objCommand.ExecuteNonQuery()

                arrRemoveRows.Add(grd.SelectedRows.Item(i).Index)

            Next

            'Delete all the selected items from the grid
            'LoadData()
            For i As Integer = 0 To arrRemoveRows.Count - 1
                grd.Rows.RemoveAt(CInt(arrRemoveRows.Item(i)))
            Next
            MessageBox.Show("Inventory item de-activated from active inventory items", "Inventory De-activation", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Inventory De-activation"
        ShowErrorMessage()
    End Sub

    Private Sub btnDeactivateOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DeactivateInventoryItems()
    End Sub

    Private Sub mnuDeleteSelection_Click(sender As Object, e As EventArgs) Handles mnuDeleteSelection.Click
        DeleteSelectedItems()
    End Sub

    Private Sub mnuCopySelected_Click(sender As System.Object, e As System.EventArgs) Handles mnuCopySelected.Click
        If Me.grd.GetCellCount( _
            DataGridViewElementStates.Selected) > 0 Then
            Try
                ' Add the selection to the clipboard.
                Clipboard.SetDataObject( _
                    Me.grd.GetClipboardContent())
            Catch ex As System.Runtime.InteropServices.ExternalException
                strErrorMessages = ex.Message & vbCrLf & "Failed to copy to clip board"
                ShowErrorMessage()
            End Try
        End If
    End Sub

    Private Sub mnuFindMatching_Click(sender As System.Object, e As System.EventArgs) Handles mnuFindMatching.Click

    End Sub

    Private Sub mnuSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuSelectAll.Click
        grd.SelectAll()
    End Sub

End Class