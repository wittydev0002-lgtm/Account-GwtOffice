Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSerialTracking

    Private Sub btnTrack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrack.Click
        SearchForItem()
    End Sub

    Private Sub SearchForItem()

        Cursor = Cursors.WaitCursor

        Dim strSqlReceipts As String = Nothing
        Dim strSqlStockTake As String = Nothing
        Dim strSqlStoresIssues As String = Nothing
        Dim strSqlStoresReturns As String = Nothing
        Dim strSqlSales As String = Nothing
        Dim strSqlVoidedSales As String = Nothing
        Dim strSqlInvoiceSales As String = Nothing
        Dim strSqlDisposals As String = Nothing
        Dim strSqlTransfersIn As String = Nothing
        Dim strSqlTransfersOut As String = Nothing
        Dim strSqlPasses As String = Nothing
        Dim strSqlExchanges As String = Nothing

        lblAvailability.Text = ""

        If chkWildCast.Checked = False Then
            'Search by serial number
            strSqlReceipts = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, OrdersReceipt.SerialNumbers, CONVERT(NVARCHAR, OrdersReceipt.TransDate, 105) AS [Date], OrdersReceipt.UserName FROM OrdersReceipt LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = OrdersReceipt.ItemCode WHERE OrdersReceipt.SerialNumbers = '" & txtSerialNumber.Text & "'"
            strSqlStockTake = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, StockTake.SerialNumber, CONVERT(NVARCHAR, StockTake.TransactionDate, 105) AS [Date], StockTake.UserName FROM stocktake LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = StockTake.ItemCode WHERE StockTake.SerialNumber = '" & txtSerialNumber.Text & "'"
            strSqlStoresIssues = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, StoresIssues.SerialNumbers, CONVERT(NVARCHAR, StoresIssues.TransactionDate, 105) AS [Date], StoresIssues.CollectedBy FROM StoresIssues LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = StoresIssues.ItemCode WHERE StoresIssues.SerialNumbers = '" & txtSerialNumber.Text & "'"
            strSqlStoresReturns = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, StoresReturns.SerialNumbers, CONVERT(NVARCHAR, StoresReturns.TransactionDate, 105) AS [Date], StoresReturns.ReturnedBy FROM StoresReturns LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = StoresReturns.ItemCode WHERE StoresReturns.SerialNumbers = '" & txtSerialNumber.Text & "'"
            strSqlSales = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, Sales.SerialNumbers, CONVERT(NVARCHAR, Sales.TransDate, 105) AS [Date], Sales.UserName FROM Sales LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = Sales.ItemCode WHERE Sales.SerialNumbers = '" & txtSerialNumber.Text & "'"
            strSqlVoidedSales = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, VoidSales.SerialNumbers, CONVERT(NVARCHAR, VoidSales.TransDate, 105) AS [Date], VoidSales.UserName FROM VoidSales LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = VoidSales.ItemCode WHERE VoidSales.SerialNumbers = '" & txtSerialNumber.Text & "'"
            strSqlInvoiceSales = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, CustomerSales.SerialNumbers, CONVERT(NVARCHAR, CustomerSales.TransDate, 105) AS [Date], CustomerSales.UserName FROM CustomerSales LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = CustomerSales.ItemCode WHERE CustomerSales.SerialNumbers = '" & txtSerialNumber.Text & "'"
            strSqlDisposals = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, DisposedInventory.SerialNumber, CONVERT(NVARCHAR, DisposedInventory.TransactionDate, 105) AS [Date], DisposedInventory.UserName FROM DisposedInventory LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = DisposedInventory.ItemCode WHERE DisposedInventory.SerialNumber = '" & txtSerialNumber.Text & "'"
            strSqlTransfersIn = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, InventoryTransfersIn.SerialNumber, CONVERT(NVARCHAR, InventoryTransfersIn.TransDate, 105) AS [Date], InventoryTransfersIn.UserName FROM InventoryTransfersIn LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = InventoryTransfersIn.ItemCode WHERE InventoryTransfersIn.SerialNumber = '" & txtSerialNumber.Text & "'"
            strSqlTransfersOut = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, InventoryTransfers.SerialNumber, CONVERT(NVARCHAR, InventoryTransfers.TransDate, 105) AS [Date], InventoryTransfers.UserName FROM InventoryTransfers LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = InventoryTransfers.ItemCode WHERE InventoryTransfers.SerialNumber = '" & txtSerialNumber.Text & "'"
            strSqlPasses = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, GatePasses.SerialNumber, CONVERT(NVARCHAR, GatePasses.TransDate, 105) AS [Date], GatePasses.UserName, GatePasses.PassType FROM GatePasses LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = GatePasses.ItemCode WHERE GatePasses.SerialNumber = '" & txtSerialNumber.Text & "'"
            strSqlExchanges = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, SalesExchanges.currentserialnumber, CONVERT(NVARCHAR, SalesExchanges.TransactionDate, 105) AS [Date], SalesExchanges.UserName, SalesExchanges.Reason FROM SalesExchanges LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = SalesExchanges.ItemCode WHERE SalesExchanges.currentserialnumber Like '%" & txtSerialNumber.Text & "%'"

            'Check that the item is still available in the serial numbers
            Dim objComStatus As New Data.OleDb.OleDbCommand("SELECT * FROM SerialNumbers WHERE SerialNumber = '" & txtSerialNumber.Text & "'", cnn)
            Dim objReadStatus As Data.OleDb.OleDbDataReader = objComStatus.ExecuteReader
            If objReadStatus.HasRows Then
                lblAvailability.StateCommon.LongText.Color1 = Color.Green
                lblAvailability.StateCommon.ShortText.Color1 = Color.Green
                lblAvailability.Text = "Item is available for sale"
            Else
                lblAvailability.StateCommon.LongText.Color1 = Color.Red
                lblAvailability.StateCommon.ShortText.Color1 = Color.Green
                lblAvailability.Text = "Item is not available for sale"
            End If
            objReadStatus.Close()

        Else
            'search by item code
            strSqlReceipts = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, OrdersReceipt.SerialNumbers, CONVERT(NVARCHAR, OrdersReceipt.TransDate, 105) AS [Date], OrdersReceipt.UserName FROM OrdersReceipt LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = OrdersReceipt.ItemCode WHERE InventoryItems.ItemCode = '" & cboItems.Text & "'"
            strSqlStockTake = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, StockTake.SerialNumber, CONVERT(NVARCHAR, StockTake.TransactionDate, 105) AS [Date], StockTake.UserName FROM stocktake LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = StockTake.ItemCode WHERE InventoryItems.ItemCode = '" & cboItems.Text & "'"
            strSqlStoresIssues = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, StoresIssues.SerialNumbers, CONVERT(NVARCHAR, StoresIssues.TransactionDate, 105) AS [Date], StoresIssues.CollectedBy FROM StoresIssues LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = StoresIssues.ItemCode WHERE InventoryItems.ItemCode = '" & cboItems.Text & "'"
            strSqlStoresReturns = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, StoresReturns.SerialNumbers, CONVERT(NVARCHAR, StoresReturns.TransactionDate, 105) AS [Date], StoresReturns.ReturnedBy FROM StoresReturns LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = StoresReturns.ItemCode WHERE InventoryItems.ItemCode = '" & cboItems.Text & "'"
            strSqlSales = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, Sales.SerialNumbers, CONVERT(NVARCHAR, Sales.TransDate, 105) AS [Date], Sales.UserName FROM Sales LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = Sales.ItemCode WHERE InventoryItems.ItemCode = '" & cboItems.Text & "'"
            strSqlVoidedSales = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, VoidSales.SerialNumbers, CONVERT(NVARCHAR, VoidSales.TransDate, 105) AS [Date], VoidSales.UserName FROM VoidSales LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = VoidSales.ItemCode WHERE InventoryItems.ItemCode = '" & cboItems.Text & "'"
            strSqlInvoiceSales = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, CustomerSales.SerialNumbers, CONVERT(NVARCHAR, CustomerSales.TransDate, 105) AS [Date], CustomerSales.UserName FROM CustomerSales LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = CustomerSales.ItemCode WHERE InventoryItems.ItemCode = '" & cboItems.Text & "'"
            strSqlDisposals = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, DisposedInventory.SerialNumber, CONVERT(NVARCHAR, DisposedInventory.TransactionDate, 105) AS [Date], DisposedInventory.UserName FROM DisposedInventory LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = DisposedInventory.ItemCode WHERE InventoryItems.ItemCode = '" & cboItems.Text & "'"
            strSqlTransfersIn = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, InventoryTransfersIn.SerialNumber, CONVERT(NVARCHAR, InventoryTransfersIn.TransDate, 105) AS [Date], InventoryTransfersIn.UserName FROM InventoryTransfersIn LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = InventoryTransfersIn.ItemCode WHERE InventoryItems.ItemCode = '" & cboItems.Text & "'"
            strSqlTransfersOut = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, InventoryTransfers.SerialNumber, CONVERT(NVARCHAR, InventoryTransfers.TransDate, 105) AS [Date], InventoryTransfers.UserName FROM InventoryTransfers LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = InventoryTransfers.ItemCode WHERE InventoryItems.ItemCode = '" & cboItems.Text & "'"
            strSqlPasses = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, GatePasses.SerialNumber, CONVERT(NVARCHAR, GatePasses.TransDate, 105) AS [Date], GatePasses.UserName, GatePasses.PassType FROM GatePasses LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = GatePasses.ItemCode WHERE GatePasses.ItemCode = '" & cboItems.Text & "'"
            strSqlExchanges = "SELECT InventoryItems.ItemCode, InventoryItems.GroupName, SalesExchanges.currentserialnumber, CONVERT(NVARCHAR, SalesExchanges.TransactionDate, 105) AS [Date], SalesExchanges.UserName, SalesExchanges.Reason FROM SalesExchanges LEFT OUTER JOIN InventoryItems ON InventoryItems.ItemCode = SalesExchanges.ItemCode WHERE SalesExchanges.ItemCode = '" & cboItems.Text & "'"

        End If

        Dim arrResults As New ArrayList

        Dim objCommand As New Data.OleDb.OleDbCommand(strSqlReceipts, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        'Get details of item when the item came into the shop
        While objReader.Read
            Dim strData As String = Nothing
            If Not IsDBNull(objReader(3).ToString) Then strData = strData & objReader(3).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(0).ToString) Then strData = strData & objReader(0).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(1).ToString) Then strData = strData & objReader(1).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(2).ToString) Then strData = strData & objReader(2).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(4).ToString) Then strData = strData & objReader(4).ToString & "|RECEIVING" Else strData = strData & "|RECEIVING"
            arrResults.Add(strData)
        End While
        objReader.Close()

        'Get details of item when stock take was done
        objCommand = New Data.OleDb.OleDbCommand(strSqlStockTake, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strData As String = Nothing
            If Not IsDBNull(objReader(3).ToString) Then strData = strData & objReader(3).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(0).ToString) Then strData = strData & objReader(0).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(1).ToString) Then strData = strData & objReader(1).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(2).ToString) Then strData = strData & objReader(2).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(4).ToString) Then strData = strData & objReader(4).ToString & "|STOCK TAKE" Else strData = strData & "|STOCK TAKE"
            arrResults.Add(strData)
        End While
        objReader.Close()

        'Get details of item when issued from stores
        objCommand = New Data.OleDb.OleDbCommand(strSqlStoresIssues, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strData As String = Nothing
            If Not IsDBNull(objReader(3).ToString) Then strData = strData & objReader(3).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(0).ToString) Then strData = strData & objReader(0).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(1).ToString) Then strData = strData & objReader(1).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(2).ToString) Then strData = strData & objReader(2).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(4).ToString) Then strData = strData & objReader(4).ToString & "|STORES ISSUES" Else strData = strData & "|STORES ISSUES"
            arrResults.Add(strData)
        End While
        objReader.Close()

        'Get details of item when returned to stores
        objCommand = New Data.OleDb.OleDbCommand(strSqlStoresReturns, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strData As String = Nothing
            If Not IsDBNull(objReader(3).ToString) Then strData = strData & objReader(3).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(0).ToString) Then strData = strData & objReader(0).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(1).ToString) Then strData = strData & objReader(1).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(2).ToString) Then strData = strData & objReader(2).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(4).ToString) Then strData = strData & objReader(4).ToString & "|STORES RETURNS" Else strData = strData & "|STORES RETURNS"
            arrResults.Add(strData)
        End While
        objReader.Close()

        'Get details of item when item sold out
        objCommand = New Data.OleDb.OleDbCommand(strSqlSales, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strData As String = Nothing
            If Not IsDBNull(objReader(3).ToString) Then strData = strData & objReader(3).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(0).ToString) Then strData = strData & objReader(0).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(1).ToString) Then strData = strData & objReader(1).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(2).ToString) Then strData = strData & objReader(2).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(4).ToString) Then strData = strData & objReader(4).ToString & "|CASH SALE" Else strData = strData & "|CASH SALE"
            arrResults.Add(strData)
        End While
        objReader.Close()

        'Get details of item when item sale was voided
        objCommand = New Data.OleDb.OleDbCommand(strSqlVoidedSales, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strData As String = Nothing
            If Not IsDBNull(objReader(3).ToString) Then strData = strData & objReader(3).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(0).ToString) Then strData = strData & objReader(0).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(1).ToString) Then strData = strData & objReader(1).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(2).ToString) Then strData = strData & objReader(2).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(4).ToString) Then strData = strData & objReader(4).ToString & "|VOIDED" Else strData = strData & "|VOIDED"
            arrResults.Add(strData)
        End While
        objReader.Close()

        'Get details of item when item invoiced to customer
        objCommand = New Data.OleDb.OleDbCommand(strSqlInvoiceSales, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strData As String = Nothing
            If Not IsDBNull(objReader(3).ToString) Then strData = strData & objReader(3).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(0).ToString) Then strData = strData & objReader(0).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(1).ToString) Then strData = strData & objReader(1).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(2).ToString) Then strData = strData & objReader(2).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(4).ToString) Then strData = strData & objReader(4).ToString & "|CUSTOMER INVOICE" Else strData = strData & "|CUSTOMER INVOICE"
            arrResults.Add(strData)
        End While
        objReader.Close()

        'Get details of item when item returned as false and disposed of
        objCommand = New Data.OleDb.OleDbCommand(strSqlDisposals, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strData As String = Nothing
            If Not IsDBNull(objReader(3).ToString) Then strData = strData & objReader(3).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(0).ToString) Then strData = strData & objReader(0).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(1).ToString) Then strData = strData & objReader(1).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(2).ToString) Then strData = strData & objReader(2).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(4).ToString) Then strData = strData & objReader(4).ToString & "|DISPOSAL" Else strData = strData & "|DISPOSAL"
            arrResults.Add(strData)
        End While
        objReader.Close()

        'Get details of item when item received through transfer
        objCommand = New Data.OleDb.OleDbCommand(strSqlTransfersIn, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strData As String = Nothing
            If Not IsDBNull(objReader(3).ToString) Then strData = strData & objReader(3).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(0).ToString) Then strData = strData & objReader(0).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(1).ToString) Then strData = strData & objReader(1).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(2).ToString) Then strData = strData & objReader(2).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(4).ToString) Then strData = strData & objReader(4).ToString & "|TRANSFERS IN" Else strData = strData & "|TRANSFERS IN"
            arrResults.Add(strData)
        End While
        objReader.Close()

        'Get details of item when stock transfered to other sites
        objCommand = New Data.OleDb.OleDbCommand(strSqlTransfersOut, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strData As String = Nothing
            If Not IsDBNull(objReader(3).ToString) Then strData = strData & objReader(3).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(0).ToString) Then strData = strData & objReader(0).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(1).ToString) Then strData = strData & objReader(1).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(2).ToString) Then strData = strData & objReader(2).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(4).ToString) Then strData = strData & objReader(4).ToString & "|TRANSFERS OUT" Else strData = strData & "|TRANSFERS OUT"
            arrResults.Add(strData)
        End While
        objReader.Close()

        'Get details of item when stock was taken out of the branch
        objCommand = New Data.OleDb.OleDbCommand(strSqlPasses, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strData As String = Nothing
            If Not IsDBNull(objReader(3).ToString) Then strData = strData & objReader(3).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(0).ToString) Then strData = strData & objReader(0).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(1).ToString) Then strData = strData & objReader(1).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(2).ToString) Then strData = strData & objReader(2).ToString & "|" Else strData = strData & "|"
            Dim strPassType As String = Nothing
            If Not IsDBNull(objReader("PassType").ToString) Then strPassType = UCase(objReader("PassType").ToString)
            If Not IsDBNull(objReader(4).ToString) Then strData = strData & objReader(4).ToString & "|GATE PASS EXIT - " & strPassType Else strData = strData & "|GATE PASS EXIT - " & strPassType
            arrResults.Add(strData)
        End While
        objReader.Close()

        'Get details of item exchanged
        objCommand = New Data.OleDb.OleDbCommand(strSqlExchanges, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strData As String = Nothing
            If Not IsDBNull(objReader(3).ToString) Then strData = strData & objReader(3).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(0).ToString) Then strData = strData & objReader(0).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(1).ToString) Then strData = strData & objReader(1).ToString & "|" Else strData = strData & "|"
            If Not IsDBNull(objReader(2).ToString) Then strData = strData & objReader(2).ToString & "|" Else strData = strData & "|"
            Dim strExchangeReason As String = Nothing
            If Not IsDBNull(objReader("Reason").ToString) Then strExchangeReason = UCase(objReader("Reason").ToString)
            If Not IsDBNull(objReader(4).ToString) Then strData = strData & objReader(4).ToString & "|EXCHANGE - " & strExchangeReason Else strData = strData & "|EXCHANGE - " & strExchangeReason
            arrResults.Add(strData)
        End While
        objReader.Close()

        'Sort the data in the array

        arrResults.Sort()

        'Go through the array and load to the grid bu spliting the values
        dGrid.Rows.Clear()
        For i As Integer = 0 To arrResults.Count - 1
            Dim strFields() As String = Split(arrResults.Item(i), "|")
            With dGrid
                .Rows.Add(1)
                .Rows(.Rows.Count - 1).Cells(0).Value = strFields(0)
                .Rows(.Rows.Count - 1).Cells(1).Value = strFields(1)
                .Rows(.Rows.Count - 1).Cells(2).Value = strFields(2)
                .Rows(.Rows.Count - 1).Cells(3).Value = strFields(3)
                .Rows(.Rows.Count - 1).Cells(4).Value = strFields(4)
                .Rows(.Rows.Count - 1).Cells(5).Value = strFields(5)
            End With
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On item serial track"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing
        strSql = "SELECT ItemCode +';'+GroupName AS " _
            & "[Items] FROM InventoryItems ORDER BY ItemCode"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "160;300"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboItems.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
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
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On items data load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmSerialTracking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
        cboItems.Enabled = False
    End Sub

    Private Sub chkWildCast_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWildCast.CheckedChanged
        If chkWildCast.Checked Then
            cboItems.Enabled = True
            txtSerialNumber.Enabled = False
        Else
            cboItems.Enabled = False
            txtSerialNumber.Enabled = True
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrPrintData As New ArrayList
        For n As Integer = 0 To dGrid.Rows.Count - 2
            Dim strDataRow As String = Nothing
            For i As Integer = 0 To dGrid.Columns.Count - 1
                If i = 0 Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(n).Cells(i).Value) Then strDataRow = dGrid.Rows(n).Cells(i).Value.ToString & ";" Else strDataRow = ";"
                Else
                    strDataRow = strDataRow & dGrid.Rows(n).Cells(i).Value.ToString & ";"
                End If
            Next
            strDataRow = Mid(strDataRow, 1, (strDataRow.Length - 1))
            arrPrintData.Add(strDataRow)
        Next

        'Add the details to the print class print array

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = UCase(arrPrintData.Item(i))
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "DATE|ITEM CODE|DESCRIPTION|SERIAL NO|OPERATOR|ACTION"
            .strColumnAlignments = "0|0|0|0|0|0"
            .strColumnWidths = "70|130|120|80|100|100"
            .strFooterCaption = "ITEM/PRODUCT TRACK"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "ITEM/PRODUCT TRACK - " & UCase(strUserBranch)
            .strColumnTotals = "NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("LightGray")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On item track report print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtSerialNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerialNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then SearchForItem()
    End Sub

    Private Sub frmSerialTracking_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 680 : Me.Height = 530
    End Sub

End Class