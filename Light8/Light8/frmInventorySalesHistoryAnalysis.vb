Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventorySalesHistoryAnalysis

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        On Error GoTo RaiseErr
        Dim strCategory As String = "ALL"
        Dim strSql As String = Nothing
        If cboCategory.Text = "-- ALL --" Then
            strSql = "SELECT Sales.ItemCode, Inventory.GroupName, SUM(Sales.Quantity) AS [Sold], " _
                & "cast((SUM((Sales.SalesPrice * Sales.Quantity) - Sales.DiscountAllowed )) AS DECIMAL (30,2)) as [Incomes], " _
                & "cast((SUM(Sales.CostPrice * Sales.Quantity)) AS DECIMAL (30,2)) as [Cost], " _
                & "cast((SUM((Sales.SalesPrice * Sales.Quantity) - Sales.DiscountAllowed - " _
                & "(Sales.CostPrice * Sales.Quantity))) AS DECIMAL (30,2)) as [Profit] FROM Sales " _
                & "where Sales.TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartDate.Value) & "' AND " _
                & "'" & gwt_comm.shortMonthDateFormat(dpEndDate.Value) & "' " _
                & "GROUP BY InventoryItems.GroupName, Sales.ItemCode, Sales.Quantity ORDER BY  Sales.ItemCode"
        Else
            strSql = "SELECT Sales.ItemCode, InventoryItems.GroupName, SUM(Sales.Quantity) AS [Sold], " _
                & "cast((SUM((Sales.SalesPrice * Sales.Quantity) - Sales.DiscountAllowed )) AS DECIMAL (30,2)) as [Incomes], " _
                & "cast((SUM(Sales.CostPrice * Sales.Quantity)) AS DECIMAL (30,2)) as [Cost], " _
                & "cast((SUM((Sales.SalesPrice * Sales.Quantity) - Sales.DiscountAllowed - " _
                & "(Sales.CostPrice * Sales.Quantity))) AS DECIMAL (30,2)) as [Profit] FROM Sales " _
                & "LEFT OUTER JOIN InventoryItems ON Sales.ItemCode = InventoryItems.ItemCode " _
                & "WHERE Sales.TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartDate.Value) & "' AND " _
                & "'" & gwt_comm.shortMonthDateFormat(dpEndDate.Value) & "' AND InventoryItems.Category = '" & cboCategory.Text & "' " _
                & "GROUP BY InventoryItems.GroupName, Sales.ItemCode, Sales.Quantity ORDER BY Sales.ItemCode"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Sales History Analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmInventorySalesHistoryAnalysis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCategories()
    End Sub

    Private Sub LoadCategories()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT Category FROM Categories ORDER BY Category", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboCategory.Items.Clear()
        cboCategory.Items.Add("-- ALL --")
        While objReader.Read
            cboCategory.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Sales History Analysis Categories Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        DataGridViewPrinter.StartPrint(dGrid, False, True, "Inventory Sales History Analysis", "Inventory Sales History Analysis")
    End Sub

End Class
