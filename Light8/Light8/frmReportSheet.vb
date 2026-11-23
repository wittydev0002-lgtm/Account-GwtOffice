Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmReportSheet

    Private Sub frmReportSheet_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DetailedStockMovements()

        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor
        Dim arrItems As New ArrayList
        boolAbort = False
        arrItems = StockMovementsDetails(StartDate, EndDate)
        If boolAbort = True Then Exit Sub

        Dim dGrid As New AdvancedDataGridViewControl.AdvancedDatagridview

        frmLight8.pb1.Value = 0 : frmLight8.pb1.Maximum = arrItems.Count + 200
        For p As Integer = 0 To arrItems.Count - 1
            Dim strDetails() As String = Split(arrItems.Item(p), "|")
            If p = 0 Then
                dGrid.Columns.Add("Column1", "Item Code")
                dGrid.Columns.Add("Column2", "Current Qty")
                dGrid.Columns.Add("Column3", "Start Qty")
                dGrid.Columns.Add("Column4", "Received")
                dGrid.Columns.Add("Column5", "Trans.In")
                dGrid.Columns.Add("Column6", "Sold")
                dGrid.Columns.Add("Column7", "Trans.Out")
                dGrid.Columns.Add("Column8", "End Qty")
            End If
            dGrid.Rows.Add(strDetails(0), strDetails(1), strDetails(2), strDetails(3), strDetails(4),
                strDetails(5), strDetails(6), strDetails(7))
            frmLight8.pb1.Value = frmLight8.pb1.Value + 1
        Next

        frmLight8.pb1.Value = frmLight8.pb1.Maximum

        For j As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(j).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Detailed stock movements report print failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Function StockMovementsDetails(ByVal SelectedDateFrom As Date, ByVal SelectedDateTo As Date) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        'objCommand = New Data.OleDb.OleDbCommand("SELECT InventoryItems.ItemCode +'|'+ CONVERT(NVARCHAR, " _
        '    & "InventoryItems.Quantity), InventoryItems.GroupName, Sales.ItemCode FROM Sales, InventoryItems " _
        '    & "WHERE Sales.ItemCode = InventoryItems.ItemCode AND Sales.TransDate BETWEEN '" & SelectedDateFrom & "' " _
        '    & "AND '" & SelectedDateTo & "' GROUP BY InventoryItems.ItemCode, InventoryItems.GroupName, " _
        '    & "Sales.ItemCode, InventoryItems.Quantity", cnn)
        'objReader = objCommand.ExecuteReader

        objCommand = New Data.OleDb.OleDbCommand("SELECT InventoryItems.ItemCode +'|'+ CONVERT(NVARCHAR, " _
            & "InventoryItems.Quantity), InventoryItems.GroupName FROM InventoryItems " _
            & "WHERE InventoryItems.ItemCode IN (SELECT DISTINCT(ItemCode) FROM Sales WHERE " _
            & "Sales.TransDate BETWEEN '" & SelectedDateFrom & "' AND '" & SelectedDateTo & "')", cnn)
        objReader = objCommand.ExecuteReader

        Dim intCount As Integer = 0
        objCommand = New Data.OleDb.OleDbCommand("SELECT Count(DISTINCT ItemCode) FROM Sales WHERE " _
            & "Sales.TransDate BETWEEN '" & SelectedDateFrom & "' AND '" & SelectedDateTo & "'", cnn)
        Dim objReadCount As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReadCount.HasRows = True Then
            objReadCount.Read()
            intCount = CInt(objReadCount(0).ToString)
        End If
        objReadCount.Close()

        'Get also from the customer sales table
        objCommand = New Data.OleDb.OleDbCommand("SELECT Count(DISTINCT ItemCode) FROM CustomerSales WHERE " _
            & "CustomerSales.TransDate BETWEEN '" & SelectedDateFrom & "' AND '" & SelectedDateTo & "'", cnn)
        objReadCount = objCommand.ExecuteReader
        If objReadCount.HasRows = True Then
            objReadCount.Read()
            intCount = intCount + CInt(objReadCount(0).ToString)
        End If
        objReadCount.Close()

        With frmLight8.pb1
            .Value = 0
            .Maximum = intCount + 1
            .Visible = True
        End With

        While objReader.Read
            'Get the list of movements to date from the start date
            Dim intQuantitySold As Integer = 0
            Dim intQuantityReceived As Integer = 0
            Dim intQuantityTransferIn As Integer = 0
            Dim intQuantityTransferOut As Integer = 0

            Dim strBuffer() As String = Split(objReader(0).ToString, "|")

            Dim strSql As String

            '
            'Get the sales quantity
            '
            strSql = "SELECT SUM(Quantity) FROM Sales WHERE ItemCode = '" & strBuffer(0) & "' AND TransDate >= '" & StartDate & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReadQuantities As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantitySold = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            'Get from the customer sales tables as well
            strSql = "SELECT SUM(Quantity) FROM CustomerSales WHERE ItemCode = '" & strBuffer(0) & "' AND TransDate >= '" & StartDate & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantitySold = intQuantitySold + CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            '
            'Get the received quantity
            '
            strSql = "SELECT SUM(Quantity) FROM OrdersReceipt WHERE ItemCode = '" & strBuffer(0) & "' AND TransDate >= '" & StartDate & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantityReceived = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            '
            'Get the transfers in quantity
            '
            strSql = "SELECT SUM(Quantity) FROM InventoryTransfers WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate >= '" & StartDate & "' AND ReceivingBranch = '" & strUserBranch & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantityTransferIn = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            '
            'Get the transfers out quantity
            '
            strSql = "SELECT SUM(Quantity) FROM InventoryTransfers WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate >= '" & StartDate & "' AND SourceBranch = '" & strUserBranch & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantityTransferOut = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            'Current Balance + Transfers Out - Transfers in

            Dim intStartQuantities As Integer = CInt(strBuffer(1)) + ((intQuantityReceived + intQuantityTransferIn) - (intQuantitySold + intQuantityTransferOut))

            'Get the quantities based on the range dates
            '***************************************************************************************************************
            '
            intQuantityReceived = 0 : intQuantitySold = 0 : intQuantityTransferIn = 0 : intQuantityTransferOut = 0

            '
            'Get the sales quantity for the period in question
            '
            strSql = "SELECT SUM(Quantity) FROM Sales WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantitySold = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            'Accumulate the customer sales as well
            strSql = "SELECT SUM(Quantity) FROM CustomerSales WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantitySold = intQuantitySold + CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            '
            'Get the received quantity for the period
            '
            strSql = "SELECT SUM(Quantity) FROM OrdersReceipt WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantityReceived = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            '
            'Get the transfers in quantity for the period
            '
            strSql = "SELECT SUM(Quantity) FROM InventoryTransfers WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate BETWEEN '" & StartDate & "' AND '" & EndDate & "' AND ReceivingBranch = '" & strUserBranch & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantityTransferIn = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()

            '
            'Get the transfers out quantity for the period
            '
            strSql = "SELECT SUM(Quantity) FROM InventoryTransfers WHERE ItemCode = '" & strBuffer(0) & "' AND " _
                & "TransDate BETWEEN '" & StartDate & "' AND '" & EndDate & "' AND SourceBranch = '" & strUserBranch & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReadQuantities = objCommand.ExecuteReader
            If objReadQuantities.HasRows Then
                objReadQuantities.Read()
                If IsNumeric(objReadQuantities(0).ToString) Then intQuantityTransferOut = CInt(objReadQuantities(0).ToString)
            End If
            objReadQuantities.Close()


            '
            '** BUILD THE OUTPUT ARRAY TO SHOW AS FOLLOWS
            '
            'ITEM CODE|CURRENT-BAL|PERIOD START BAL|RECEIVED|TRANSFERS-IN|SOLD|TRANSFER OUT|END BAL
            '
            '/// intStartQuantities = (intQuantityReceived + intQuantityTransferIn) - (intQuantitySold + intQuantityTransferOut)
            intStartQuantities = (CInt(strBuffer(1)) + (intQuantityTransferOut + intQuantitySold)) - (intQuantityTransferIn + intQuantityReceived)

            If intStartQuantities < 0 Then intStartQuantities = 0
            Dim intEndQuantities As Integer = intStartQuantities + ((intQuantityReceived + intQuantityTransferIn) - (intQuantitySold + intQuantityTransferOut))

            arrReturn.Add(strBuffer(0) & "|" & strBuffer(1) & "|" & intStartQuantities & "|" & intQuantityReceived _
                & "|" & intQuantityTransferIn & "|" & intQuantitySold & "|" & intQuantityTransferOut & "|" & intEndQuantities)

            'Check that the item is not specific in nature. If it is then detail the serial numbers affected

            objCommand = New Data.OleDb.OleDbCommand("SELECT InventoryType FROM InventoryItems WHERE ItemCode = '" & strBuffer(0) & "'", cnn)
            Dim objReadItem As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadItem.HasRows Then
                objReadItem.Read()
                If objReadItem(0).ToString = "SPECIFIC" Then

                    'Select the serial numbers from received items table
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumbers FROM OrdersReceipt WHERE " _
                        & "ItemCode = '" & strBuffer(0).ToString & "' AND TransDate BETWEEN '" & SelectedDateFrom & "' " _
                        & "AND '" & SelectedDateTo & "'", cnn)
                    Dim objReadData As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    Dim arrReceived As New ArrayList
                    While objReadData.Read
                        If Not IsDBNull(objReadData(0).ToString) Then arrReceived.Add(UCase(objReadData(0).ToString))
                    End While
                    objReadData.Close()

                    'Select the serial numbers from transfers in items table
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumbers FROM InventoryTransfers WHERE " _
                        & "ItemCode = '" & strBuffer(0).ToString & "' AND TransDate BETWEEN '" & SelectedDateFrom & "' " _
                        & "AND '" & SelectedDateTo & "' AND ReceivingBranch = '" & strUserBranch & "'", cnn)
                    objReadData = objCommand.ExecuteReader
                    Dim arrTransfersIn As New ArrayList
                    While objReadData.Read
                        If Not IsDBNull(objReadData(0).ToString) Then arrTransfersIn.Add(UCase(objReadData(0).ToString))
                    End While
                    objReadData.Close()

                    'Select the serial numbers from transfers out items table
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumbers FROM InventoryTransfers WHERE " _
                        & "ItemCode = '" & strBuffer(0).ToString & "' AND TransDate BETWEEN '" & SelectedDateFrom & "' " _
                        & "AND '" & SelectedDateTo & "' AND SourceBranch = '" & strUserBranch & "'", cnn)
                    objReadData = objCommand.ExecuteReader
                    Dim arrTransfersOut As New ArrayList
                    While objReadData.Read
                        If Not IsDBNull(objReadData(0).ToString) Then arrTransfersOut.Add(UCase(objReadData(0).ToString))
                    End While
                    objReadData.Close()

                    'Select the serial numbers from Sales items table
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumbers FROM Sales WHERE " _
                        & "ItemCode = '" & strBuffer(0).ToString & "' AND TransDate BETWEEN '" & SelectedDateFrom & "' " _
                        & "AND '" & SelectedDateTo & "'", cnn)
                    objReadData = objCommand.ExecuteReader
                    Dim arrSales As New ArrayList
                    While objReadData.Read
                        If Not IsDBNull(objReadData(0).ToString) Then arrSales.Add(UCase(objReadData(0).ToString))
                    End While
                    objReadData.Close()

                    'Select the serial numbers from CustomerSales items table
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumbers FROM CustomerSales WHERE " _
                        & "ItemCode = '" & strBuffer(0).ToString & "' AND TransDate BETWEEN '" & SelectedDateFrom & "' " _
                        & "AND '" & SelectedDateTo & "'", cnn)
                    objReadData = objCommand.ExecuteReader
                    While objReadData.Read
                        If Not IsDBNull(objReadData(0).ToString) Then arrSales.Add(UCase(objReadData(0).ToString))
                    End While
                    objReadData.Close()

                    Dim intLines As Integer = 0
                    If intLines < arrReceived.Count Then intLines = arrReceived.Count
                    If intLines < arrTransfersIn.Count Then intLines = arrTransfersIn.Count
                    If intLines < arrTransfersOut.Count Then intLines = arrTransfersOut.Count
                    If intLines < arrSales.Count Then intLines = arrSales.Count

                    'Add the lines to the output array
                    '
                    For p As Integer = 0 To intLines - 1
                        'ITEM CODE|CURRENT-BAL|PERIOD START BAL|RECEIVED|TRANSFERS-IN|SOLD|TRANSFER OUT|END BAL
                        '

                        Dim strReceivedSerial As String = Nothing
                        Dim strTransInSerial As String = Nothing
                        Dim strSalesSerial As String = Nothing
                        Dim strTransOutSerial As String = Nothing

                        If (p < arrReceived.Count And arrReceived.Count > 0) Then strReceivedSerial = arrReceived.Item(p)
                        If (p < arrTransfersIn.Count And arrTransfersIn.Count > 0) Then strTransInSerial = arrTransfersIn.Item(p)
                        If (p < arrSales.Count And arrSales.Count > 0) Then strSalesSerial = arrSales.Item(p)
                        If (p < arrTransfersOut.Count And arrTransfersOut.Count > 0) Then strTransOutSerial = arrTransfersOut.Item(p)

                        arrReturn.Add("     Affected Serials| | |" & strReceivedSerial & "|" & strTransInSerial & "|" & strSalesSerial & "|" & strTransOutSerial & "| ")

                    Next

                End If
            End If
            objReadItem.Close()

            'Add blank line after each item
            'arrReturn.Add(" | | | | | | | ")

            frmLight8.pb1.Value = frmLight8.pb1.Value + 1

        End While
        objReader.Close()

        frmLight8.pb1.Value = frmLight8.pb1.Maximum

        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Detailed Stock movement report generation"
        gwt_comm.ShowErrorMessage()
    End Function

End Class