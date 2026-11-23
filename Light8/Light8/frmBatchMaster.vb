Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBatchMaster

    Private Sub btnNewGoodsIn_Click(sender As System.Object, e As System.EventArgs) Handles btnNewGoodsIn.Click
        Dim frm As New frmBatchTransactions
        frm.ShowDialog()
    End Sub

    Private Function GetSelectedReceivedOrder()
        Dim intReturn As Integer = 0
        If dGridBatchesList.Rows.Count <= 0 Then
            Return 0
            Exit Function
        End If
        intReturn = CInt(dGridBatchesList.CurrentRow.Cells(0).Value.ToString)
        Return intReturn
    End Function

    Private Sub LoadOrdersData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        StartDate = dpStartFromOrders.Value
        EndDate = dpEndToOrders.Value
        '" & Format(StartDate, "dd-MMM-yyyy") & "
        Dim strSql As String = "SELECT BatchNo AS [Batch], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date], " _
            & "CAST(SUM((Quantity * CostPrice) + OrdersReceipt.VatAmount) AS DECIMAL (30,2)) AS [Value], OrdersReceipt.Status, " _
            & "OrdersReceipt.SupplierId, Suppliers.AccountName FROM OrdersReceipt " _
            & "LEFT OUTER JOIN Suppliers ON OrdersReceipt.SupplierId = Suppliers.AccountNumber " _
            & "WHERE TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(StartDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndDate) & "' " _
            & "GROUP BY BatchNo, TransDate, OrdersReceipt.Status, OrdersReceipt.SupplierId, Suppliers.AccountName " _
            & "ORDER BY AccountName, TransDate, BatchNo, Value, OrdersReceipt.Status"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        'grd.Rows.Clear()
        dGridBatchesList.Columns.Clear()

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridBatchesList.DataSource = dTable

        For p As Integer = 0 To dGridBatchesList.Columns.Count - 1
            dGridBatchesList.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            If p = 2 Then
                dGridBatchesList.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        SelectionTotals()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error on received orders preview"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnGoOrders_Click(sender As System.Object, e As System.EventArgs) Handles btnGoOrders.Click
        LoadOrdersData()
    End Sub

    Private Sub SelectionTotals()
        On Error GoTo RaiseErr

        Dim dblProcessed As Double = 0
        Dim dblPending As Double = 0
        Dim dblGrandTotal As Double = 0

        Cursor = Cursors.WaitCursor
        For i As Integer = 0 To dGridBatchesList.RowCount - 1
            Dim dblValue As Double = CDbl(dGridBatchesList.Rows(i).Cells(2).Value.ToString)
            If UCase(dGridBatchesList.Rows(i).Cells(3).Value.ToString) = "PROCESSED" Then
                dblProcessed = dblProcessed + dblValue
            Else
                dblPending = dblPending + dblValue
            End If
        Next
        dblGrandTotal = dblPending + dblProcessed

        lblProcessedTotalOrders.Text = Format(dblProcessed, "##,#0.00")
        lblUnprocessedTotalOrders.Text = Format(dblPending, "##,#0.00")
        lblGrandTotalOrders.Text = Format(dblGrandTotal, "##,#0.00")

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Received Orders Ledger Posting"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub BatchTotals()
        On Error GoTo RaiseErr
        Dim dblProcessed As Double = 0
        Cursor = Cursors.WaitCursor
        For i As Integer = 0 To dGridBatchDetails.RowCount - 1
            Dim dblValue As Double = CDbl(dGridBatchDetails.Rows(i).Cells(6).Value.ToString)
            dblProcessed = dblProcessed + dblValue
        Next
        lblBatchCostTotalOrders.Text = Format(dblProcessed, "##,#0.00")
        lblEntriesCountOrders.Text = dGridBatchDetails.RowCount
        dblSelectedBatchTotal = dblProcessed
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Received Orders Ledger Posting"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadSelectedBatchData()

        If dGridBatchesList.RowCount <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Dim intBatchNumber As Integer = CInt(dGridBatchesList.CurrentRow.Cells(0).Value.ToString)
        intSelectedBatchNumber = intBatchNumber
        Dim strSql As String = "SELECT OrdersReceipt.ItemCode AS [Item Code], InventoryItems.GroupName AS [Description], " _
            & "OrdersReceipt.BaseBarcode + ''+ OrdersReceipt.SerialNumbers AS [Serial No.], CAST(OrdersReceipt.CostPrice " _
            & "AS DECIMAL (30,2)) AS [Unit Price], OrdersReceipt.Quantity AS [Qty], OrdersReceipt.VatAmount AS [VAT], " _
            & "CAST(((OrdersReceipt.CostPrice * OrdersReceipt.Quantity) + OrdersReceipt.VatAmount) AS DECIMAL (30,2)) AS [Total], OrdersReceipt.TransactionId " _
            & "FROM OrdersReceipt LEFT OUTER JOIN InventoryItems ON " _
            & "OrdersReceipt.ItemCode = InventoryItems.ItemCode WHERE OrdersReceipt.BatchNo = " & intBatchNumber & " " _
            & "ORDER BY OrdersReceipt.TransactionId"
        With dGridBatchDetails
            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New OleDb.OleDbDataAdapter(cmd)
            Dim dTable As New DataTable()
            da.Fill(dTable)
            .DataSource = dTable

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

            For p As Integer = 0 To .Columns.Count - 1
                .Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                'If p = 2 Then .Columns(p).Visible = False
                If p >= 3 Then
                    .Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Next
            .Columns(.ColumnCount - 1).Visible = False
        End With
        BatchTotals()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Received Orders Ledger Posting"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGridOrdersList_SelectionChanged(sender As Object, e As System.EventArgs) Handles dGridBatchesList.SelectionChanged
        LoadSelectedBatchData()
    End Sub

    Private Sub btnDeleteGoodsIn_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteGoodsIn.Click
        On Error GoTo RaiseErr

        If dGridBatchesList.RowCount <= 0 Then Exit Sub

        If Not Object.Equals(dGridBatchesList.CurrentRow.Cells(3).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridBatchesList.CurrentRow.Cells(3).Value.ToString) Then
                If UCase(dGridBatchesList.CurrentRow.Cells(3).Value.ToString) = "PROCESSED" Then
                    MessageBox.Show("Batch cannot be deleted as it has already been posted to accounts",
                        "Invalid Procedure", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If
        End If

        If MessageBox.Show("Are you sure you want to delete the selected batch?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor

            'Reverse quantities from inventory items table first
            Dim intBatchNumber As Integer = CInt(dGridBatchesList.CurrentRow.Cells(0).Value.ToString)
            intSelectedBatchNumber = intBatchNumber
            Dim strSql As String = "SELECT OrdersReceipt.ItemCode AS [Item Code], InventoryItems.GroupName AS [Description], " _
                & "OrdersReceipt.BaseBarcode + ''+ OrdersReceipt.SerialNumbers AS [Serial No.], CAST(OrdersReceipt.CostPrice " _
                & "AS DECIMAL (30,2)) AS [Unit Price], OrdersReceipt.Quantity AS [Qty], OrdersReceipt.VatAmount AS [VAT], " _
                & "CAST(((OrdersReceipt.CostPrice * OrdersReceipt.Quantity) + OrdersReceipt.VatAmount) AS DECIMAL (30,2)) AS [Total], OrdersReceipt.TransactionId " _
                & "FROM OrdersReceipt LEFT OUTER JOIN InventoryItems ON " _
                & "OrdersReceipt.ItemCode = InventoryItems.ItemCode WHERE OrdersReceipt.BatchNo = " & intBatchNumber & " " _
                & "ORDER BY OrdersReceipt.TransactionId"
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReader.Read
                Dim dblQty As Double = 0
                Dim strSerialNumber As String = Nothing
                If IsNumeric(objReader(4).ToString) Then dblQty = CDbl(objReader(4).ToString)
                If Not IsDBNull(objReader(2).ToString) Then
                    If Not String.IsNullOrEmpty(objReader(2).ToString) Then
                        strSerialNumber = objReader(2).ToString
                    End If
                End If

                If Not IsDBNull(objReader(0).ToString) Then
                    strSql = "UPDATE InventoryItems SET Quantity = (Quantity - " & dblQty & ") WHERE ItemCode = '" & objReader(0).ToString & "'"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                    If Not String.IsNullOrEmpty(strSerialNumber) Then
                        strSql = "DELETE FROM SerialNumbers WHERE ItemCode = '" & objReader(0).ToString & "' AND SerialNumber = '" & strSerialNumber & "'"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                    strSql = "DELETE FROM OrdersReceipt WHERE OrdersReceipt.TransactionId = " & objReader(7).ToString & ""
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End While
            objReader.Close()
            strSql = "DELETE FROM OrdersReceipt WHERE OrdersReceipt.BatchNo = " & intBatchNumber & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            MessageBox.Show("Batch has been deleted and inventory items reversed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadOrdersData()

        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Received Orders Ledger Posting"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrintReceivedOrder_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintReceivedOrder.Click
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
            Dim DocNumber As Integer = GetSelectedReceivedOrder()
            boolPrinterAlreadySelected = False
            Dim documentType As String = "GOODS RECEIVED NOTE"
            If DocNumber > 0 Then
                If UCase(strPrintDocumentsTo) = UCase("pdf") Then
                    boolAbort = False
                    PrintCustomerPdfDocument(DocNumber, documentType)
                    If boolAbort = False Then
                        Cursor = DefaultCursor
                        MessageBox.Show(documentType & " has been generated to pdf successfully",
                        "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                Else
                    gwt_comm.PrintCustomerDocument(DocNumber, documentType)
                End If
            Else
                MessageBox.Show("You do not have the right to access this part of the system",
                "Invoking Unauthorised Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Exit Sub
        End If
    End Sub


End Class