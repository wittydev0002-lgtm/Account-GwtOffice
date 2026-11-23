Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmInventoryItemsDeletedListing

    Private Sub frmInventoryItemsDeletedListing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ItemCode, GroupName, UserName, TransDate FROM InventoryItemsDeleted ORDER BY TransDate", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to load deleted items"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellContentClick
        If e.ColumnIndex = 4 Then
            If MessageBox.Show("Are you sure you want to undo this transaction?", "Confirm Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                UndoDelete(dGrid.CurrentRow.Cells(0).Value.ToString)
            End If
        End If
    End Sub

    Private Sub UndoDelete(ItemCode As String)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [ItemCode],[GroupName],[Description],[SellingPrice]," _
                    & "[CostPrice],[Location],[Category],[SubCategory],[Quantity],[InventoryType]," _
                    & "[MinimumLevel],[WarningLevel],[IdealLevel],[TaxStatus],[SerialNumbers],[BarCodeNo]," _
                    & "[ItemColor],[Size],[UnitOfMeasure],[FullBarcodeSerialStatus],[Offering],[Status]," _
                    & "[ShortCode],[Uom],[MasterPackQty],[InnerPackQty],[CaseLength],[CaseWidth]," _
                    & "[CaseHeight],[CaseWeight],[ProductLength],[ProductWidth],[ProductHeight]," _
                    & "[ProductWeight],[DateIntroduced],[SoUomName],[SoUomRatioStd],[SoUomRatio]," _
                    & "[PoUomName],[PoUomRatioStd],[PoUomRatio],[SupplyPackaging],[SalesPackaging]," _
                    & "[SupplyPackagingQuantity],[SalesPackagingQuantity],[PackItemCostPrice]," _
                    & "[PackItemSalePrice],[CostCode],[TaxCode],[ItemShortCode] FROM InventoryItemsDeleted WHERE ItemCode = '" & ItemCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            strSql = "INSERT INTO InventoryItems ([ItemCode],[GroupName],[Description],[SellingPrice]," _
            & "[CostPrice],[Location],[Category],[SubCategory],[Quantity],[InventoryType]," _
            & "[MinimumLevel],[WarningLevel],[IdealLevel],[TaxStatus],[SerialNumbers],[BarCodeNo]," _
            & "[ItemColor],[Size],[UnitOfMeasure],[FullBarcodeSerialStatus],[Offering],[Status]," _
            & "[ShortCode],[Uom],[MasterPackQty],[InnerPackQty],[CaseLength],[CaseWidth]," _
            & "[CaseHeight],[CaseWeight],[ProductLength],[ProductWidth],[ProductHeight]," _
            & "[ProductWeight],[DateIntroduced],[SoUomName],[SoUomRatioStd],[SoUomRatio]," _
            & "[PoUomName],[PoUomRatioStd],[PoUomRatio],[SupplyPackaging],[SalesPackaging]," _
            & "[SupplyPackagingQuantity],[SalesPackagingQuantity],[PackItemCostPrice]," _
            & "[PackItemSalePrice],[CostCode],[TaxCode],[ItemShortCode]) VALUES " _
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
            & "" & objReader("PackItemCostPrice") & ", " & objReader("PackItemSalePrice") & ", " _
            & "" & objReader("CostCode") & ", '" & objReader("TaxCode") & "', '" & objReader("ItemShortCode") & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        objReader.Close()

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM InventoryItemsDeleted WHERE Itemcode = '" & ItemCode & "'", cnn)
        objCommand.ExecuteNonQuery()

        'Reverse the serial numbers as well

        strSql = "SELECT [ItemCode],[SerialNumber],[BarCodeNo],[SourceSerialNo],[Availability],[CostPrice] " _
            & "FROM SerialNumbersDeleted WHERE ItemCode = '" & ItemCode & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            strSql = "INSERT INTO SerialNumbers ([ItemCode],[SerialNumber],[BarCodeNo],[SourceSerialNo]," _
                & "[Availability],[CostPrice]) VALUES ('" & objReader(0) & "', " _
                & "'" & objReader(1) & "', '" & objReader(2) & "', '" & objReader(3) & "', " _
                & "'" & objReader(4) & "', " & objReader(5) & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End While
        objReader.Close()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbersDeleted WHERE Itemcode = '" & ItemCode & "'", cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Inventory Item Delete reversed successfully", "Inventory Item Delete Undo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadData()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to load deleted items"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        'Assign the values to the print array
        Dim arrPrintData As New ArrayList
        For n As Integer = 0 To dGrid.Rows.Count - 1
            Dim strDataRow As String = Nothing
            For i As Integer = 0 To dGrid.ColumnCount - 2
                If i = 0 Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(n).Cells(i).Value.ToString) Then strDataRow = dGrid.Rows(n).Cells(i).Value.ToString & ";" Else strDataRow = ";"
                Else
                    strDataRow = strDataRow & dGrid.Rows(n).Cells(i).Value.ToString & ";"
                End If
            Next
            strDataRow = Mid(strDataRow, 1, (strDataRow.Length - 1))
            arrPrintData.Add(strDataRow)
        Next

        If arrPrintData.Count <= 0 Then
            MessageBox.Show("No details to print", "No Print Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            .intNumberOfColumns = 4
            .strColumnHeaders = "CODE|DESCRIPTION|DELETED BY|DATE-TIME"
            .strColumnAlignments = "0|0|0|0"
            .strColumnWidths = "200|220|100|100"
            .strFooterCaption = "Deleted Inventory List Report "
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "DELETED INVENTORY REPORT"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On deleted Inventory Report Print"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
