Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLaybyeSalesPreview

    Dim arrTransmittedInvoices As ArrayList

    Private Sub frmLaybyeSalesPreview_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Preset the tab colors
        tabMain.Tabs(0).PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Orange
        tabMain.Tabs(1).PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Green
        LoadUsers()
    End Sub

    Private Sub LoadUsers()
        On Error GoTo RaiseErr
        cboUser.Items.Clear()
        cboUser.Items.Add("ALL")
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT UserName FROM Users ORDER BY UserName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboUser.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Usernames Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        LoadSalesDetails()
        LoadSalesByInventory()
        AlternateColors(dGrid)
        AlternateColors(grd)
    End Sub

    Private Sub AlternateColors(ByVal myGrid As AdvancedDataGridViewControl.AdvancedDatagridview)
        With myGrid
            For i As Integer = 0 To .Rows.Count - 1
                For j As Integer = 0 To .ColumnCount - 1
                    Dim backColor As Color = Color.White
                    .Rows(i).Cells(j).Style.BackColor = backColor
                Next
            Next
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

    Private Sub LoadSalesDetails()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        grd.Columns.Clear()
        Dim strSql As String = Nothing
        If UCase(cboUser.Text) = "ALL" Then
            strSql = "Select InvoiceNumber AS [Doc No.], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                & "CAST(Amount AS DECIMAL (30,2)) AS [Amt Received], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                & "CAST(Taxes AS DECIMAL (30,2)) AS [Tax], SalesRep AS [Sales Rep] from LaybySalesMain WHERE TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' AND " _
                & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' order by TransDate, InvoiceNumber"
        Else
            strSql = "Select InvoiceNumber as [Doc No.], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
               & "CAST(Amount AS DECIMAL (30,2)) AS [Amt Received], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
               & "CAST(Taxes AS DECIMAL (30,2)) AS [Tax], SalesRep AS [Sales Rep] from LaybySalesMain WHERE UserName = '" & UCase(cboUser.Text) & "' " _
               & "AND InvoiceNumber > 0 AND TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' AND " _
               & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' order by TransDate, InvoiceNumber"
        End If

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        grd.DataSource = dTable

        'Add the image column at the end

        Me.grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        For p As Integer = 0 To grd.Columns.Count - 1
            grd.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next

        ComputeTotals()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On lay-by sales analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadSalesByInventory()
        On Error GoTo RaiseErr
        dGrid.Columns.Clear()
        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing

        If UCase(cboUser.Text) = "ALL" Then
            strSql = "select LaybySales.ItemCode AS [Code], RTRIM(LaybySales.Description) as [Description], sum(LaybySales.Quantity) as [Qty], " _
                & "RTRIM(LaybySales.SerialNumbers) as [S.N.], CAST((sum(InventoryItems.SellingPrice * LaybySales.Quantity)) AS DECIMAL (30,2)) as " _
                & "[Sales $], CAST(sum(LaybySales.DiscountAllowed) AS DECIMAL (30,2)) AS [Discount], CAST((sum(LaybySales.Quantity) * sum(InventoryItems.CostPrice)) AS DECIMAL (30,2)) " _
                & "as [Cost $], CAST((sum(LaybySales.Quantity) * sum(InventoryItems.SellingPrice)) - " _
                & "(sum(LaybySales.DiscountAllowed) + (sum(InventoryItems.CostPrice) * sum(LaybySales.Quantity))) AS DECIMAL (30,2)) as " _
                & "[Profit] FROM LaybySales LEFT OUTER JOIN InventoryItems ON LaybySales.ItemCode = " _
                & "InventoryItems.ItemCode where LaybySales.TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' " _
                & "AND '" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' " _
                & "group by LaybySales.ItemCode, LaybySales.Description, LaybySales.SerialNumbers"
        Else
            strSql = "select LaybySales.ItemCode as [Code], RTRIM(LaybySales.Description) as [Description], sum(LaybySales.Quantity) as [Qty], " _
                & "RTRIM(LaybySales.SerialNumbers) as [S.N.], CAST((sum(InventoryItems.SellingPrice * LaybySales.Quantity)) AS DECIMAL (30,2)) as " _
                & "[Sales $], CAST(sum(LaybySales.DiscountAllowed) AS DECIMAL (30,2)) as [Discount], CAST((sum(LaybySales.Quantity) * sum(InventoryItems.CostPrice)) AS DECIMAL (30,2)) " _
                & "as [Cost $], CAST((sum(LaybySales.Quantity) * sum(InventoryItems.SellingPrice)) - " _
                & "(sum(LaybySales.DiscountAllowed) + (sum(InventoryItems.CostPrice) * sum(LaybySales.Quantity))) AS DECIMAL (30,2)) as " _
                & "[Profit] FROM LaybySales LEFT OUTER JOIN InventoryItems ON LaybySales.ItemCode = " _
                & "InventoryItems.ItemCode WHERE LaybySales.UserName = '" & UCase(cboUser.Text) & "' " _
                & "AND LaybySales.InvoiceNumber > 0 AND LaybySales.TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' " _
                & "AND '" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' " _
                & "group by LaybySales.ItemCode, LaybySales.Description, LaybySales.SerialNumbers"
        End If

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        'Add the image column at the end

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            If p = 2 Or p = 4 Or p = 5 Or p = 6 Or p = 7 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On lay-by sales analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals()
        Dim dblAmount As Double = 0
        Dim dblTaxes As Double = 0
        Dim dblDiscounts As Double = 0
        For n As Integer = 0 To grd.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(grd.Rows(n).Cells(2).Value), "")) Then
                If IsNumeric(grd.Rows(n).Cells(2).Value.ToString) Then
                    dblAmount = dblAmount + CDbl(grd.Rows(n).Cells(2).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(grd.Rows(n).Cells(3).Value), "")) Then
                If IsNumeric(grd.Rows(n).Cells(3).Value.ToString) Then
                    dblDiscounts = dblDiscounts + CDbl(grd.Rows(n).Cells(3).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(grd.Rows(n).Cells(4).Value), "")) Then
                If IsNumeric(grd.Rows(n).Cells(4).Value.ToString) Then
                    dblTaxes = dblTaxes + CDbl(grd.Rows(n).Cells(4).Value.ToString)
                End If
            End If
        Next
        txtSales.Text = Format((dblAmount - dblTaxes), "#,##0.00")
        txtDiscounts.Text = Format(dblDiscounts, "#,##0.00")
        txtTaxes.Text = Format(dblTaxes, "#,##0.00")
        lblGrossSales.Text = Format((dblAmount + 0), "#,##0.00")
    End Sub

End Class
