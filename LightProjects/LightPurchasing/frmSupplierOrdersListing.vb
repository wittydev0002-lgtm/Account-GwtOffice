Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSupplierOrdersListing
    Private Sub frmSupplierOrdersListing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOrdersData()
    End Sub

    Private Function GetSelectedReceivedOrder()
        Dim intReturn As Integer = 0
        If dGridOrdersList.Rows.Count <= 0 Then
            Return 0
            Exit Function
        End If
        intReturn = CInt(dGridOrdersList.CurrentRow.Cells(0).Value.ToString)
        Return intReturn
    End Function

    Private Sub LoadOrdersData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT BatchNo AS [Batch], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date], " _
            & "CAST(SUM((Quantity * CostPrice) + OrdersReceipt.VatAmount) AS DECIMAL (10,2)) AS [Value], OrdersReceipt.Status, " _
            & "OrdersReceipt.SupplierId, Suppliers.AccountName FROM OrdersReceipt " _
            & "LEFT OUTER JOIN Suppliers ON OrdersReceipt.SupplierId = Suppliers.AccountNumber " _
            & "WHERE OrdersReceipt.SupplierId = '" & strSelectedAccount & "' " _
            & "GROUP BY BatchNo, TransDate, OrdersReceipt.Status, OrdersReceipt.SupplierId, Suppliers.AccountName " _
            & "ORDER BY AccountName, TransDate, BatchNo, Value, OrdersReceipt.Status"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        'grd.Rows.Clear()
        dGridOrdersList.Columns.Clear()

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridOrdersList.DataSource = dTable

        For p As Integer = 0 To dGridOrdersList.Columns.Count - 1
            dGridOrdersList.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            If p = 2 Then
                dGridOrdersList.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        With dGridOrdersList
            .Columns(.Columns.Count - 1).Visible = False
            .Columns(.Columns.Count - 2).Visible = False
        End With
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error on received orders preview"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If dGridOrdersList.RowCount <= 0 Then Exit Sub
        intSelectedBatchNumber = GetSelectedReceivedOrder()
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub dGridOrdersList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGridOrdersList.CellDoubleClick
        If dGridOrdersList.RowCount <= 0 Then Exit Sub
        intSelectedBatchNumber = GetSelectedReceivedOrder()
        boolAbort = False
        Me.Close()
    End Sub

End Class