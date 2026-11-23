Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports ComponentFactory.Krypton.Toolkit
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class frmAdministrationMain

    Dim strInvoiceDetails As ArrayList
    Dim prFont As New Font("Arial", 6, FontStyle.Bold)
    Dim tlFont As New Font("Arial", 6, FontStyle.Regular)
    Dim HeaderFont As New Font("Arial", 10, FontStyle.Bold)
    Dim strValue As String
    Dim itm As Integer
    Dim intPage As Integer
    Dim arrTransmittedInvoices As ArrayList
    Dim boolPrintFromPreview As Boolean
    Dim strCustomerAddress1 As String
    Dim strCustomerAddress2 As String
    Dim strCustomerAddress3 As String
    Dim strCustomerTelephone As String
    Dim strCustomerEmailaddress As String
    Dim strOrderNumber As String
    Dim strCustomerName As String
    Dim strCustomerVatNumber As String
    Dim strDate As String
    Dim strSalesRep As String
    Dim strCustomerAddress4 As String
    Dim boolExitingWhile As Boolean
    Dim dblInvoiceTotal As Double
    Dim dblTaxes As Double
    Dim dblDiscounts As Double
    Dim dblUnitPriceTotals As Double
    Dim i As Integer = 0

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        ProcessQuery()
    End Sub

    Private Sub ProcessQuery()
        'select SalesRep AS [Agent], CAST((sum(amount)) AS DECIMAL (10,2)) AS [SALES], CAST((SUM((Amount - (amount * .35)))) AS DECIMAL (10,2)) AS BASEAMOUNT, CAST((SUM(((Amount - (amount * .35)) * .50))) AS DECIMAL (10,2)) AS COMMISSION FROM SalesMain GROUP BY SalesRep

        LoadSalesDetails()
        LoadSalesByInventory()
        LoadJobData()
        LoadCommissionsData()
        LoadSalesCounts()
        LoadInvoice()
        StockMovements()
        LoadVoidedSalesDetails()

        LoadCurrencyBreakdowns()
        LoadSalesByCashier

        AlternateColors(dGrid)
        AlternateColors(dGridCommissions)
        AlternateColors(dGridJc)
        AlternateColors(dGridVoidedSales)
        AlternateColors(dGridInvoices)
        AlternateColors(dGridStockMovement)
        AlternateColors(dGridCashiers)

    End Sub

    Private Sub LoadSalesByCashier()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing
        strSql = "SELECT UserName AS [Cashier], 
            CAST(SUM(ISNULL([Ecocash],0)) AS DECIMAL (20,2)) AS [Ecocash], 
            CAST(SUM(ISNULL([Swipe], 0)) AS DECIMAL (20,2)) AS [Swipe], 
            CAST(SUM(ISNULL([Transfer], 0)) AS DECIMAL (20,2)) AS [Transfer], 
            CAST(SUM(ISNULL([USD], 0)) AS DECIMAL (20,2)) AS [USD], 
            CAST(SUM(ISNULL([Rand], 0)) AS DECIMAL (20,2)) AS [Rand],  
            CAST(SUM(ISNULL([Cash], 0)) AS DECIMAL (20,2)) AS [ZWL-Cash] FROM [SalesMain] 
			WHERE 
                [TransDate] BETWEEN '" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' 
                    AND '" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "'
			GROUP BY UserName"

        With dGridCashiers
            .Columns.Clear()
            Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New OleDb.OleDbDataAdapter(cmd)
            Dim dTable As New DataTable()
            da.Fill(dTable)
            .DataSource = dTable

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            For p As Integer = 0 To .Columns.Count - 1
                .Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                If p > 0 Then
                    .Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Next
        End With

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf &
            "On Sales by Cashier Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadCurrencyBreakdowns()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        dGridCurrencies.Rows.Clear()

        Dim arrData As New ArrayList

        Dim strSql As String = "SELECT SUM(ISNULL([Ecocash],0)), 
            SUM(ISNULL([Swipe], 0)), SUM(ISNULL([Transfer], 0)), 
            SUM(ISNULL([USD], 0)),  SUM(ISNULL([Rand], 0)),  
            SUM(ISNULL([Cash], 0)) FROM [SalesMain] 
            WHERE [TransDate] BETWEEN '" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' AND " _
            & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            With dGridCurrencies
                .Rows.Add("Ecocash", Format(CDbl(objReader(0).ToString), "##0.00"))
                .Rows.Add("Swipe", Format(CDbl(objReader(1).ToString), "##0.00"))
                .Rows.Add("Transfer", Format(CDbl(objReader(2).ToString), "##0.00"))
                .Rows.Add("USD", Format(CDbl(objReader(3).ToString), "##0.00"))
                .Rows.Add("Rand", Format(CDbl(objReader(4).ToString), "##0.00"))
                .Rows.Add("Bond Cash", Format(CDbl(objReader(5).ToString), "##0.00"))
            End With
        End If
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf &
            "On Sales Breakdown by Currency"
        ShowErrorMessage()
    End Sub

    Private Sub LoadVoidedSalesDetails()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        dGridVoidedSales.Rows.Clear()
        Dim strSql As String = "Select InvoiceNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "CAST(Amount AS DECIMAL (10,2)) AS [Amount], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
            & "CAST(Taxes AS DECIMAL (10,2)) AS [Vat] from VoidSalesMain WHERE TransDate BETWEEN " _
            & "'" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' AND " _
            & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' order by TransDate, InvoiceNumber"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGridVoidedSales.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridVoidedSales.Rows(dGridVoidedSales.Rows.Count - 1).Cells(0).Value = Format(CInt(objReader(0).ToString), "000000")
            If Not IsDBNull(objReader(1).ToString) Then dGridVoidedSales.Rows(dGridVoidedSales.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGridVoidedSales.Rows(dGridVoidedSales.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dGridVoidedSales.Rows(dGridVoidedSales.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then dGridVoidedSales.Rows(dGridVoidedSales.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
        End While
        ComputeVoidedSalesTotals()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        gwt_comm.ShowErrorMessage()
    End Sub


    Private Sub ComputeVoidedSalesTotals()
        Dim dblAmount As Double = 0
        Dim dblTaxes As Double = 0
        Dim dblDiscounts As Double = 0
        For n As Integer = 0 To dGridVoidedSales.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGridVoidedSales.Rows(n).Cells(2).Value), "")) Then
                If IsNumeric(dGridVoidedSales.Rows(n).Cells(2).Value.ToString) Then
                    dblAmount = dblAmount + CDbl(dGridVoidedSales.Rows(n).Cells(2).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridVoidedSales.Rows(n).Cells(3).Value), "")) Then
                If IsNumeric(dGridVoidedSales.Rows(n).Cells(3).Value.ToString) Then
                    dblDiscounts = dblDiscounts + CDbl(dGridVoidedSales.Rows(n).Cells(3).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridVoidedSales.Rows(n).Cells(4).Value), "")) Then
                If IsNumeric(dGridVoidedSales.Rows(n).Cells(4).Value.ToString) Then
                    dblTaxes = dblTaxes + CDbl(dGridVoidedSales.Rows(n).Cells(4).Value.ToString)
                End If
            End If
        Next
        lblVoidedSales.Text = "Total Received = " & Format(dblAmount, "#,##0.00")
        lblVoidedDiscounts.Text = "Total Discounts = " & Format(dblDiscounts, "#,##0.00")
        lblVoidedTaxes.Text = "Total Taxes = " & Format(dblTaxes, "#,##0.00")
    End Sub

    Private Sub dGridVoidedSales_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridVoidedSales.CellClick
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If dGridVoidedSales.CurrentCell.ColumnIndex = 5 Then
            If MessageBox.Show("Are you sure you want to unvoid this invoice", "Confirm Transaction Unvoid", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                intSelectedTransaction = CInt(dGridVoidedSales.CurrentRow.Cells(0).Value.ToString)
                UnvoidTransaction()
                'refresh the grid
                ComputeVoidedSalesTotals()
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On voided sales analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ViewVoidSaleDetails()
        If dGridVoidedSales.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridVoidedSales.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridVoidedSales.CurrentRow.Cells(0).Value.ToString) Then
                boolTransactionVoided = False
                boolLoadedFromVoidedSales = True
                intSelectedTransaction = CInt(dGridVoidedSales.CurrentRow.Cells(0).Value.ToString)
                Dim f As New frmSalesDetails
                f.ShowDialog()
                boolLoadedFromVoidedSales = False
                If boolTransactionVoided = True Then ComputeVoidedSalesTotals()
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub UnvoidTransaction()
        'Re-enter the value back to the database as negative
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim dblAmountTotal As Double = 0
        Dim dblTaxesTotal As Double = 0
        Dim dblDiscountsTotal As Double = 0

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim strOriginalSalesRep As String = Nothing

        Dim dblSumPayable As Double = CDbl(dGridVoidedSales.CurrentRow.Cells(2).Value.ToString)
        Dim dtOriginal As String = CStr(gwt_comm.shortMonthDateFormat(Now))

        strSql = "SELECT [InvoiceNumber],[CustomerId],[Status],[Amount],[Taxes],[Discount]," _
            & "[TransDate],[OriginalInvoice],[SalesRep],[UserName] FROM VoidSalesMain WHERE InvoiceNumber = " & intSelectedTransaction & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            dtOriginal = DatePart(DateInterval.Day, CDate(objReader(6).ToString)) & "-" & Mid(MonthName(DatePart(DateInterval.Month, CDate(objReader(6).ToString))), 1, 3) & "-" & DatePart(DateInterval.Year, CDate(objReader(6).ToString))

            strSql = "INSERT INTO SalesMain (InvoiceNumber, CustomerId, Status, Amount, Taxes, Discount, " _
                    & "TransDate, OriginalInvoice, SalesRep, UserName) VALUES (" & objReader(0).ToString & ", " _
                    & "'" & objReader(1).ToString & "', '" & objReader(2).ToString & "', " & objReader(3).ToString & ", " _
                    & "" & objReader(4).ToString & ", " & objReader(5).ToString & ", '" & dtOriginal & "', " _
                    & "" & objReader(7).ToString & ", '" & objReader(8).ToString & "', '" & strUserName & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            If Not IsDBNull(objReader("SalesRep").ToString) Then strOriginalSalesRep = objReader("SalesRep").ToString
            'If Not IsDBNull(objReader("TransDate").ToString) Then dtOriginal = Format(CDate(objReader("TransDate").ToString), "dd-MMM-yyyy")
        End If
        objReader.Close()

        'Get the original sales data
        strSql = "SELECT [InvoiceNumber],[CustomerId],[ItemCode],[Description],[Quantity]," _
            & "[DiscountAllowed],[Taxes],[TransType],[SalesPrice],[TransDate],[ProductType],[SerialNumbers]," _
            & "[OriginalInvoice],[SalesRep],[UserName], [BaseBarcode] FROM VoidSales WHERE InvoiceNumber = " & intSelectedTransaction & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            strSql = "INSERT INTO Sales (InvoiceNumber, CustomerId, ItemCode, Description, Quantity, DiscountAllowed, " _
                & "Taxes, TransType, SalesPrice, TransDate, ProductType, SerialNumbers, OriginalInvoice, SalesRep, UserName, BaseBarcode) " _
                & "VALUES (" & objReader(0).ToString & ", '" & objReader(1).ToString & "', '" & objReader(2).ToString & "', " _
                & "'" & objReader(3).ToString & "', " & objReader(4).ToString & ", " & objReader(5).ToString & ", " _
                & "" & objReader(6).ToString & ", '" & objReader(7).ToString & "', " & objReader(8).ToString & ", " _
                & "'" & dtOriginal & "', '" & objReader(10).ToString & "', '" & objReader(11).ToString & "', " _
                & "" & objReader(12).ToString & ", '" & objReader(13).ToString & "', '" & strUserName & "', " _
                & "'" & objReader("BaseBarcode").ToString & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            'Take off the items from to the inventory
            If Not String.IsNullOrEmpty(objReader("SerialNumbers").ToString) Then
                Dim lngComma As Long = InStr(1, objReader("SerialNumbers").ToString, ",", 1)
                If lngComma > 0 Then
                    Dim strSeries() As String = Split(objReader("SerialNumbers").ToString, ",")
                    For n As Integer = 0 To strSeries.Length - 1
                        If Not String.IsNullOrEmpty(strSeries(n)) Then
                            strSql = "DELETE FROM SerialNumbers WHERE ItemCode = '" & objReader("ItemCode").ToString & "' " _
                                & "AND ItemCode ='" & strSeries(n) & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()
                        End If
                    Next
                Else
                    strSql = "DELETE FROM SerialNumbers WHERE ItemCode = '" & objReader("ItemCode").ToString & "' " _
                        & "AND SerialNumber = '" & objReader("SerialNumbers").ToString & "'"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If

            'Update the inventory table
            strSql = "UPDATE InventoryItems SET InventoryItems.Quantity = (InventoryItems.Quantity - " & CInt(objReader("Quantity").ToString) & ") " _
                    & "WHERE ItemCode = '" & objReader("ItemCode").ToString & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End While
        objReader.Close()

        'Remove from the original voided sales table
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM VoidSales WHERE InvoiceNumber = " & intSelectedTransaction & "", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM VoidSalesMain WHERE InvoiceNumber = " & intSelectedTransaction & "", cnn)
        objCommand.ExecuteNonQuery()
        ''Add back to the cash book as well
        '    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CashbookTransactions WHERE Reference = " & intSelectedTransaction & "", cnn)
        '    objCommand.ExecuteNonQuery()
        ''Add back to the ledger account as well
        '    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE Reference = " & intSelectedTransaction & "", cnn)
        '    objCommand.ExecuteNonQuery()

        'Update the cashbook with the values
        Dim strCashbookDescription As String = "CASH SALE - " & UCase(strOriginalSalesRep)
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, TransactionType, Reference) VALUES " _
            & "('" & strPublicActiveCashbook & "', '" & dtOriginal & "', " & dblSumPayable & ", '" & strCashbookDescription & "', '" & strPublicSalesAccount & "', '" & strUserName & "', '" & strUserBranch & "', 'DEBIT', " & Convert.ToDouble(intSelectedTransaction) & ")", cnn)
        objCommand.ExecuteNonQuery()

        'Post the account to the contra ledger account
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference]) VALUES " _
           & "('" & strPublicSalesAccount & "', '" & dtOriginal & "', " & dblSumPayable & ", 'CREDIT', '" & strPublicActiveCashbook & "', '" & strCashbookDescription & "', '" & strUserName & "', '" & strUserBranch & "', " & Convert.ToDouble(intSelectedTransaction) & ")", cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default
        strPublicCustomerId = "0000"
        MessageBox.Show("Sales voided successfully.", "Transaction Void Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Void"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    '*********** End Sales Voiding ***********************

    Private Sub LoadInvoice()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing

        If UCase(cboUser.Text) = "--- ALL ---" Then
            strSql = "SELECT CustomerSalesMain.InvoiceNumber, CONVERT(NVARCHAR, CustomerSalesMain.TransDate, 105) AS [Date], Customers.AccountName, " _
                & "CAST(CustomerSalesMain.Amount AS DECIMAL (10,2)) AS [Value], CAST(CustomerSalesMain.Discount AS DECIMAL (10,2)) AS [Discounts], " _
                & "CAST(CustomerSalesMain.Taxes AS DECIMAL (10,2)) AS [Taxes] FROM CustomerSalesMain LEFT OUTER JOIN Customers ON " _
                & "CustomerSalesMain.CustomerId = Customers.AccountNumber WHERE TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' AND '" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' "

        Else
            strSql = "SELECT CustomerSalesMain.InvoiceNumber, CONVERT(NVARCHAR, CustomerSalesMain.TransDate, 105) AS [Date], Customers.AccountName, " _
                & "CAST(CustomerSalesMain.Amount AS DECIMAL (10,2)) AS [Value], CAST(CustomerSalesMain.Discount AS DECIMAL (10,2)) AS [Discounts], " _
                & "CAST(CustomerSalesMain.Taxes AS DECIMAL (10,2)) AS [Taxes] FROM CustomerSalesMain LEFT OUTER JOIN Customers ON " _
                & "CustomerSalesMain.CustomerId = Customers.AccountNumber WHERE TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' " _
                & "AND '" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' AND SalesRep = '" & cboUser.Text & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim i As Integer = 0
        With dGridInvoices
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then .Rows(i).Cells(0).Value = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then .Rows(i).Cells(1).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(i).Cells(2).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then .Rows(i).Cells(3).Value = objReader(3).ToString
                If Not IsDBNull(objReader(4).ToString) Then .Rows(i).Cells(4).Value = objReader(4).ToString
                If Not IsDBNull(objReader(5).ToString) Then .Rows(i).Cells(5).Value = objReader(5).ToString
                i = i + 1
            End While
            objReader.Read()

            'Calculate totals
            Dim dblMovingT As Double = 0
            Dim dblMovingTx As Double = 0
            Dim dblMovingDs As Double = 0
            Dim strValue As String
            For i = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "")) Then
                    strValue = Convert.ToString(.Rows(i).Cells(3).Value)
                    If IsNumeric(strValue) Then
                        dblMovingT = dblMovingT + CDbl(strValue)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "")) Then
                    strValue = Convert.ToString(.Rows(i).Cells(4).Value)
                    If IsNumeric(strValue) Then
                        dblMovingTx = dblMovingTx + CDbl(strValue)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "")) Then
                    strValue = Convert.ToString(.Rows(i).Cells(5).Value)
                    If IsNumeric(strValue) Then
                        dblMovingDs = dblMovingDs + CDbl(strValue)
                    End If
                End If
            Next

            .Rows.Add("", "", "TOTAL", Format(dblMovingT, "#,##0.00"), Format(dblMovingDs, "#,##0.00"), Format(dblMovingTx, "#,##0.00"))

        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadSalesCounts()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Sales.SalesRep, COUNT(Sales.ItemCode) AS Total, " _
            & "CAST(SUM((Quantity * SalesPrice) - DiscountAllowed) AS DECIMAL (10,2)) AS [Amount] " _
            & "FROM Sales WHERE Sales.TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' AND " _
            & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' " _
            & "GROUP BY SalesRep ORDER BY Total, SalesRep"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        With dGridCountBased
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(objReader(0), objReader(1), objReader(2))
            End While
            objReader.Close()
        End With
        AlternateColors(dGridCountBased)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Sales based on items sold load failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub AlternateColors(ByVal myGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView)
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

    Private Sub LoadCommissionsData()
        On Error GoTo RaiseErr

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT LastName, FirstName, OtherNames, " _
            & "EmployeeClass FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        dGridCommissions.Rows.Clear()

        While objReader.Read

            Dim strRepName As String = Nothing
            Dim strCurrentEmployeeClass As String = Nothing

            If Not IsDBNull(objReader(0).ToString) Then strRepName = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strRepName = strRepName & " " & objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strRepName = strRepName & " " & objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then strCurrentEmployeeClass = objReader(3).ToString

            'Get the expenses and commission rate

            Dim dblExpensesRate As Double = 0
            Dim dblCommissionRate As Double = 0

            strRepName = Trim(strRepName)

            '
            '*** FIRST GET THE FIGURE FOR STAFF PURCHASE
            '
            Dim dblAgentExpenses As Double = 0
            Dim strSqlStatement As String = "SELECT SUM(StaffSales.Payable) FROM StaffSales " _
                & "WHERE TransactionDate BETWEEN '" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' AND " _
                & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' AND SalesAgent = '" & strRepName & "'"
            Dim objCommandStaffSales As New Data.OleDb.OleDbCommand(strSqlStatement, cnn)
            Dim objReadStaffSales As Data.OleDb.OleDbDataReader = objCommandStaffSales.ExecuteReader
            If objReadStaffSales.HasRows Then
                objReadStaffSales.Read()
                If IsNumeric(objReadStaffSales(0).ToString) Then dblAgentExpenses = CDbl(objReadStaffSales(0).ToString)
            End If
            objReadStaffSales.Close()

            '
            ' **** GET THE SALES INFORMATION FIRST ****
            '

            Dim dblSumOfSales As Double = 0
            Dim dblSumOfExpenses As Double = 0
            Dim dblSumAfterPurchases As Double = 0
            Dim dblSumOfCommissions As Double = 0

            strSqlStatement = "SELECT SalesMain.InvoiceNumber, SalesMain.SalesRep, " _
                & "SUM(SalesMain.Amount) as [Sales], SalesMain.ExpensesRate, SalesMain.CommissionRate AS " _
                & "[Commission] FROM SalesMain WHERE SalesMain.TransDate " _
                & "BETWEEN '" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' AND " _
                & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' AND SalesRep = '" & strRepName & "' " _
                & "GROUP BY SalesMain.SalesRep, SalesMain.ExpensesRate, SalesMain.Amount, SalesMain.InvoiceNumber, " _
                & "SalesMain.CommissionRate ORDER BY SalesMain.SalesRep"
            objCommand = New Data.OleDb.OleDbCommand(strSqlStatement, cnn)
            Dim objReadBaseValues As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            Dim Cnt As Integer = 0
            While objReadBaseValues.Read
                If IsNumeric(objReadBaseValues(2).ToString) Then dblSumOfSales = dblSumOfSales + CDbl(objReadBaseValues(2).ToString)
                If IsNumeric(objReadBaseValues(3).ToString) Then
                    If Cnt = 0 Then
                        dblSumOfExpenses = dblSumOfExpenses + ((dblSumOfSales - dblAgentExpenses) * CDbl(objReadBaseValues(3).ToString))
                    Else
                        dblSumOfExpenses = dblSumOfExpenses + (CDbl(objReadBaseValues(2).ToString) * CDbl(objReadBaseValues(3).ToString))
                    End If
                End If
                If IsNumeric(objReadBaseValues(4).ToString) Then
                    If Cnt = 0 Then
                        dblSumOfCommissions = dblSumOfCommissions + ((CDbl(objReadBaseValues(2).ToString) - dblSumOfExpenses - dblAgentExpenses) * CDbl(objReadBaseValues(4).ToString))
                    Else
                        dblSumOfCommissions = dblSumOfCommissions + ((CDbl(objReadBaseValues(2).ToString) - (CDbl(objReadBaseValues(2).ToString) * CDbl(objReadBaseValues(3).ToString))) * CDbl(objReadBaseValues(4).ToString))
                    End If
                End If
                Cnt = Cnt + 1
            End While
            objReadBaseValues.Close()

            With dGridCommissions
                .Rows.Add(UCase(strRepName), dblSumOfSales, dblAgentExpenses, (dblSumOfSales - dblAgentExpenses), dblSumOfExpenses, (dblSumOfSales - dblAgentExpenses - dblSumOfExpenses), dblSumOfCommissions)
            End With

        End While
        objReader.Close()

        'Get the total line
        Dim dblValue As Double = 0
        Dim dblFees As Double = 0
        Dim dblTotal As Double = 0

        With dGridCommissions
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = "TOTALS"
            For p As Integer = 1 To .Columns.Count - 1
                dblValue = 0
                For i As Integer = 0 To .Rows.Count - 1
                    If IsNumeric(.Rows(i).Cells(p).Value) Then
                        dblValue = dblValue + CDbl(.Rows(i).Cells(p).Value.ToString)
                    End If
                Next
                .Rows(.Rows.Count - 1).Cells(p).Value = Format(dblValue, "##0.00")
                .Rows(.Rows.Count - 1).Cells(p).Style.BackColor = Color.FromArgb(195, 217, 242)
                .Rows(.Rows.Count - 1).Cells(p).Style.ForeColor = Color.Black
            Next
        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Commissions Calculations"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadJobData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ReferenceNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "CustomerName, CAST(JobValue AS DECIMAL (10,2)) AS [Value], CAST(InspectionFee AS DECIMAL (10,2)) AS [Fee], " _
            & "CAST((JobValue + InspectionFee) AS DECIMAL (10,2)) AS [Total] FROM JobCards " _
            & "WHERE TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' AND " _
            & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' ORDER BY ReferenceNumber", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridJc.Rows.Clear()
        While objReader.Read
            With dGridJc
                .Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
                If Not IsDBNull(objReader(4).ToString) Then .Rows(.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
                If Not IsDBNull(objReader(5).ToString) Then .Rows(.Rows.Count - 1).Cells(5).Value = objReader(5).ToString
            End With
        End While
        objReader.Close()

        'Get the total line
        Dim dblValue As Double = 0
        Dim dblFees As Double = 0
        Dim dblTotal As Double = 0

        For i As Integer = 0 To dGridJc.Rows.Count - 1
            If IsNumeric(dGridJc.Rows(i).Cells(3).Value) Then
                dblValue = dblValue + CDbl(dGridJc.Rows(i).Cells(3).Value.ToString)
            End If
            If IsNumeric(dGridJc.Rows(i).Cells(4).Value) Then
                dblFees = dblFees + CDbl(dGridJc.Rows(i).Cells(4).Value.ToString)
            End If
            If IsNumeric(dGridJc.Rows(i).Cells(5).Value) Then
                dblTotal = dblTotal + CDbl(dGridJc.Rows(i).Cells(5).Value.ToString)
            End If
        Next
        With dGridJc
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = ""
            .Rows(.Rows.Count - 1).Cells(1).Value = ""
            .Rows(.Rows.Count - 1).Cells(2).Value = "TOTALS"
            .Rows(.Rows.Count - 1).Cells(3).Value = Format(dblValue, "##0.00")
            .Rows(.Rows.Count - 1).Cells(4).Value = Format(dblFees, "##0.00")
            .Rows(.Rows.Count - 1).Cells(5).Value = Format(dblTotal, "##0.00")
            'Change the row line back color
            .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = Color.FromArgb(195, 217, 242)
            .Rows(.Rows.Count - 1).Cells(1).Style.BackColor = Color.FromArgb(195, 217, 242)
            .Rows(.Rows.Count - 1).Cells(2).Style.BackColor = Color.FromArgb(195, 217, 242)
            .Rows(.Rows.Count - 1).Cells(3).Style.BackColor = Color.FromArgb(195, 217, 242)
            .Rows(.Rows.Count - 1).Cells(4).Style.BackColor = Color.FromArgb(195, 217, 242)
            .Rows(.Rows.Count - 1).Cells(5).Style.BackColor = Color.FromArgb(195, 217, 242)
            'Make the font bold
            .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = Color.Black
            .Rows(.Rows.Count - 1).Cells(1).Style.ForeColor = Color.Black
            .Rows(.Rows.Count - 1).Cells(2).Style.ForeColor = Color.Black
            .Rows(.Rows.Count - 1).Cells(3).Style.ForeColor = Color.Black
            .Rows(.Rows.Count - 1).Cells(4).Style.ForeColor = Color.Black
            .Rows(.Rows.Count - 1).Cells(5).Style.ForeColor = Color.Black
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Job costing details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadSalesDetails()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        dGridAllData.Columns.Clear()

        Dim strSql As String = Nothing

        If Not IsNumeric(txtDocNumber.Text) Then txtDocNumber.Text = "0"

        Dim dblDivisionFactor As Double = (1 / (100 + dblSalesTaxRate)) * 100
        dblDivisionFactor = 1

        'PaymentMethod AS [Pay Method]

        If UCase(cboUser.Text) = "--- ALL ---" Then

            If UCase(strTaxComputationType) = "INCLUSIVE" Then
                strSql = "Select InvoiceNumber AS [Trans. ID], UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) AS [Date], " _
                    & "CAST((Amount * " & dblDivisionFactor & ") AS DECIMAL (10,2)) AS [Pre-Tax], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                    & "CAST(Taxes AS DECIMAL (10,2)) AS [Tax], CAST(((Amount + Taxes) - 0) AS DECIMAL (10,2)) AS [Total], " _
                    & "Cash as [Cash], EcoCash as [EcoCash], Swipe AS [Swipe], Transfer AS [Transfer], " _
                    & "Other AS [Other], SalesRep AS [Sales Rep], KeyNumber as [Doc. No], " _
                    & "SalesMain.Username as [Operator], SalesMain.Flag as [S] from SalesMain WHERE TransDate BETWEEN " _
                    & "'" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' AND " _
                    & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' order by TransDate, InvoiceNumber"

            Else
                strSql = "Select InvoiceNumber AS [Trans. ID], UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) AS [Date], " _
                    & "CAST(Amount AS DECIMAL (10,2)) AS [Pre-Tax], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                    & "CAST(Taxes AS DECIMAL (10,2)) AS [Tax], CAST(((Amount + Taxes) - 0) AS DECIMAL (10,2)) AS [Total], " _
                    & "Cash as [Cash], EcoCash as [EcoCash], Swipe AS [Swipe], Transfer AS [Transfer], " _
                    & "Other AS [Other], SalesRep AS [Sales Rep], KeyNumber as [Doc. No], " _
                    & "SalesMain.Username as [Operator], SalesMain.Flag as [S] from SalesMain WHERE TransDate BETWEEN " _
                    & "'" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' AND " _
                    & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' order by TransDate, InvoiceNumber"

            End If

        Else
            If UCase(strTaxComputationType) = "INCLUSIVE" Then

                strSql = "Select InvoiceNumber as [Trans. ID], UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) AS [Date], " _
                   & "CAST((Amount * " & dblDivisionFactor & ") AS DECIMAL (10,2)) AS [Pre-Tax], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                   & "CAST(Taxes AS DECIMAL (10,2)) AS [Tax], CAST(((Amount + Taxes) - 0) AS DECIMAL (10,2)) AS [Total], " _
                   & "Cash as [Cash], EcoCash as [EcoCash], Swipe AS [Swipe], Transfer AS [Transfer], " _
                   & "Other AS [Other], SalesRep AS [Sales Rep], KeyNumber as [Doc. No], SalesMain.Username as [Operator], SalesMain.Flag as [S] " _
                   & "from SalesMain WHERE UserName = '" & UCase(cboUser.Text) & "' " _
                   & "AND InvoiceNumber > " & (CInt(txtDocNumber.Text) - 1) & " AND TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' AND " _
                   & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' order by TransDate, InvoiceNumber"
            Else

                strSql = "Select InvoiceNumber as [Trans. ID], UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) AS [Date], " _
                   & "CAST(Amount AS DECIMAL (10,2)) AS [Pre-Tax], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                   & "CAST(Taxes AS DECIMAL (10,2)) AS [Tax], CAST(((Amount + Taxes) - 0) AS DECIMAL (10,2)) AS [Total], " _
                   & "Cash as [Cash], EcoCash as [EcoCash], Swipe AS [Swipe], Transfer AS [Transfer], " _
                   & "Other AS [Other], SalesRep AS [Sales Rep], KeyNumber as [Doc. No], SalesMain.Username as [Operator],  SalesMain.Flag as [S] " _
                   & "from SalesMain WHERE UserName = '" & UCase(cboUser.Text) & "' " _
                   & "AND InvoiceNumber > " & (CInt(txtDocNumber.Text) - 1) & " AND TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' AND " _
                   & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' order by TransDate, InvoiceNumber"

            End If

        End If

        'Populate the all sales grid
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridAllData.DataSource = dTable

        For p As Integer = 0 To dGridAllData.ColumnCount - 1
            dGridAllData.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p >= 2 And p <= 10 Then
                dGridAllData.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGridAllData.Columns(p).DefaultCellStyle.Format = "N2"
            End If
            'If p = dGridAllData.ColumnCount - 1 Then
            '    dGridAllData.Columns(p).Visible = False
            'End If
        Next
        'FormatSalesGrids(dGridAllData)
        'ComputeTotals(dGridAllData)

        'COMPUTE THE TOTALS

        Dim dblPreTaxAmount As Double = 0
        Dim dblTaxes As Double = 0
        Dim dblDiscounts As Double = 0
        Dim dblTotalSales As Double = 0

        Dim dblCash As Double = 0
        Dim dblEcocash As Double = 0
        Dim dblSwipes As Double = 0
        Dim dblTransfers As Double = 0
        Dim dblOthers As Double = 0

        With dGridAllData
            For n As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(2).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(2).Value.ToString) Then
                        dblPreTaxAmount = dblPreTaxAmount + CDbl(.Rows(n).Cells(2).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(3).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(3).Value.ToString) Then
                        dblDiscounts = dblDiscounts + CDbl(.Rows(n).Cells(3).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(4).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(4).Value.ToString) Then
                        dblTaxes = dblTaxes + CDbl(.Rows(n).Cells(4).Value.ToString)
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(5).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(5).Value.ToString) Then
                        dblTotalSales = dblTotalSales + CDbl(.Rows(n).Cells(5).Value.ToString)
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(6).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(6).Value.ToString) Then
                        dblCash = dblCash + CDbl(.Rows(n).Cells(6).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(7).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(7).Value.ToString) Then
                        dblEcocash = dblEcocash + CDbl(.Rows(n).Cells(7).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(8).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(8).Value.ToString) Then
                        dblSwipes = dblSwipes + CDbl(.Rows(n).Cells(8).Value.ToString)
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(9).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(9).Value.ToString) Then
                        dblTransfers = dblTransfers + CDbl(.Rows(n).Cells(9).Value.ToString)
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(10).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(10).Value.ToString) Then
                        dblOthers = dblOthers + CDbl(.Rows(n).Cells(10).Value.ToString)
                    End If
                End If

            Next

            lblPreTax.Text = Format(dblPreTaxAmount, "#,##0.00")
            lblDiscounts.Text = Format(dblDiscounts, "#,##0.00")
            lblTaxes.Text = Format(dblTaxes, "#,##0.00")
            lblCash.Text = Format(dblCash, "#,##0.00")
            lblEcocash.Text = Format(dblEcocash, "#,##0.00")
            lblSwipes.Text = Format(dblSwipes, "#,##0.00")
            lblTransfers.Text = Format(dblTransfers, "#,##0.00")

            Dim dblTot As Double = (dblCash + dblEcocash + dblSwipes + dblTransfers + dblOthers)

            lblTotals.Text = Format(dblTot, "#,##0.00")

        End With

        lblExpenses.Text = GetExpensesTotal()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        gwt_comm.ShowErrorMessage()
    End Sub


    Private Sub LoadSalesByInventory()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing

        If UCase(cboUser.Text) = "--- ALL ---" Then

            strSql = "SELECT Sales.Itemcode, Sales.Description, Sales.SerialNumbers, Sales.Quantity, " _
                & "CAST(sales.SalesPrice AS DECIMAL (10,2)) AS [Sale], CAST(sales.DiscountAllowed AS DECIMAL (10,2)) AS [Discount], " _
                & "CAST(Sales.CostPrice AS DECIMAL (10,2)) AS [Cost], CAST((Sales.SalesPrice - Sales.CostPrice) AS DECIMAL (10,2)) AS " _
                & "[Profit], TransactionId AS [Id], Sales.InvoiceNumber FROM Sales WHERE Sales.TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' " _
                & "AND '" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' order by ItemCode, TransDate"

        Else

            strSql = "SELECT Sales.Itemcode, Sales.Description, Sales.SerialNumbers, Sales.Quantity, " _
                & "CAST(sales.SalesPrice AS DECIMAL (10,2)) AS [Sale], CAST(sales.DiscountAllowed AS DECIMAL (10,2)) AS [Discount], " _
                & "CAST(Sales.CostPrice AS DECIMAL (10,2)) AS [Cost], CAST((Sales.SalesPrice - Sales.CostPrice) AS DECIMAL (10,2)) AS " _
                & "[Profit], TransactionId AS [Id], Sales.InvoiceNumber FROM Sales WHERE TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' and " _
                & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' AND Sales.UserName = '" & UCase(cboUser.Text) & "' " _
                & "AND Sales.InvoiceNumber > " & (CInt(txtDocNumber.Text) - 1) & " ORDER BY ItemCode, TransDate"

        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        With dGrid
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    If UCase(objReader(0).ToString) <> ("00000") Then
                        .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3),
                            objReader(4), objReader(5), objReader(6), objReader(7), objReader(8), objReader(9))
                    End If
                End If
            End While
        End With
        objReader.Close()

        'Add the sales from invoices

        If UCase(cboUser.Text) = "--- ALL ---" Then

            strSql = "SELECT CustomerSales.Itemcode, CustomerSales.Description, CustomerSales.SerialNumbers, CustomerSales.Quantity, " _
                & "CAST(CustomerSales.SalesPrice AS DECIMAL (10,2)) AS [Sale], CAST(CustomerSales.DiscountAllowed AS DECIMAL (10,2)) AS [Discount], " _
                & "CAST(CustomerSales.CostPrice AS DECIMAL (10,2)) AS [Cost], CAST((CustomerSales.SalesPrice - CustomerSales.CostPrice) AS DECIMAL (10,2)) AS " _
                & "[Profit], TransactionId AS [Id], CustomerSales.InvoiceNumber FROM CustomerSales WHERE CustomerSales.TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' " _
                & "AND '" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' order by ItemCode, TransDate"

        Else

            strSql = "SELECT CustomerSales.Itemcode, CustomerSales.Description, CustomerSales.SerialNumbers, CustomerSales.Quantity, " _
                & "CAST(CustomerSales.SalesPrice AS DECIMAL (10,2)) AS [Sale], CAST(CustomerSales.DiscountAllowed AS DECIMAL (10,2)) AS [Discount], " _
                & "CAST(CustomerSales.CostPrice AS DECIMAL (10,2)) AS [Cost], CAST((CustomerSales.SalesPrice - CustomerSales.CostPrice) AS DECIMAL (10,2)) AS " _
                & "[Profit], TransactionId AS [Id], CustomerSales.InvoiceNumber FROM CustomerSales WHERE TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)) & "' and " _
                & "'" & gwt_comm.shortMonthDateFormat(CDate(dpEndTo.Value)) & "' AND CustomerSales.UserName = '" & UCase(cboUser.Text) & "' " _
                & "AND CustomerSales.InvoiceNumber > " & (CInt(txtDocNumber.Text) - 1) & " ORDER BY ItemCode, TransDate"

        End If

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        With dGrid
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    If UCase(objReader(0).ToString) <> ("00000") Then
                        .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4),
                            objReader(5), objReader(6), objReader(7), objReader(8), objReader(9))
                    End If
                End If
            End While
        End With
        objReader.Close()

        dGrid.Columns(dGrid.ColumnCount - 2).Visible = False

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals(ByVal Grid As KryptonDataGridView)
        Dim dblPreTaxAmount As Double = 0
        Dim dblTaxes As Double = 0
        Dim dblDiscounts As Double = 0
        Dim dblCash As Double = 0
        Dim dblEcocash As Double = 0
        Dim dblSwipes As Double = 0
        Dim dblTransfers As Double = 0
        With Grid
            For n As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(2).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(2).Value.ToString) Then
                        dblPreTaxAmount = dblPreTaxAmount + CDbl(.Rows(n).Cells(2).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(3).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(3).Value.ToString) Then
                        dblDiscounts = dblDiscounts + CDbl(.Rows(n).Cells(3).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(4).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(4).Value.ToString) Then
                        dblTaxes = dblTaxes + CDbl(.Rows(n).Cells(4).Value.ToString)
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(9).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(9).Value.ToString) Then
                        dblCash = dblCash + CDbl(.Rows(n).Cells(9).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(10).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(10).Value.ToString) Then
                        dblEcocash = dblEcocash + CDbl(.Rows(n).Cells(10).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(11).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(11).Value.ToString) Then
                        dblSwipes = dblSwipes + CDbl(.Rows(n).Cells(11).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(12).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(12).Value.ToString) Then
                        dblTransfers = dblTransfers + CDbl(.Rows(n).Cells(12).Value.ToString)
                    End If
                End If
            Next

            lblPreTax.Text = Format(dblPreTaxAmount, "#,##0.00")
            lblDiscounts.Text = Format(dblDiscounts, "#,##0.00")
            lblTaxes.Text = Format(dblTaxes, "#,##0.00")
            lblCash.Text = Format(dblCash, "#,##0.00")
            lblEcocash.Text = Format(dblEcocash, "#,##0.00")
            lblSwipes.Text = Format(dblSwipes, "#,##0.00")
            lblTransfers.Text = Format(dblTransfers, "#,##0.00")
            lblTotals.Text = Format((dblCash + dblEcocash + dblSwipes + dblTransfers), "#,##0.00")
        End With

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        If UCase(SuperTabControl1.SelectedTab.Text) = UCase("Voided Sales") Then
            ViewVoidSaleDetails()
        Else
            If dGridAllData.Rows.Count <= 0 Then Exit Sub
            On Error GoTo RaiseErr
            Cursor = Cursors.WaitCursor
            If Not (Object.Equals(Convert.ToString(dGridAllData.CurrentRow.Cells(0).Value), "")) Then
                If IsNumeric(dGridAllData.CurrentRow.Cells(0).Value.ToString) Then
                    boolTransactionVoided = False
                    intSelectedTransaction = CInt(dGridAllData.CurrentRow.Cells(0).Value.ToString)
                    strCalledBy = Nothing
                    Dim f As New frmSalesDetails
                    f.ShowDialog()
                    If boolTransactionVoided = True Then LoadSalesDetails() Else ProcessQuery()
                End If
            End If
        End If

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On sales details viewing"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub PrintReceipt()
        On Error GoTo RaiseErr
        Dim arrPrintDetails As New ArrayList
        arrPrintDetails.Add(Space(2) & strCompanyName)
        arrPrintDetails.Add(Space(2) & strCompanyAddress1)
        arrPrintDetails.Add(Space(2) & strCompanyAddress2)
        arrPrintDetails.Add(Space(2) & strCompanyAddress3)
        arrPrintDetails.Add(Space(2) & "PHONE: " & strCompanyTelephone)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        arrPrintDetails.Add(Space(2) & "DATE FROM " & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)))
        arrPrintDetails.Add(Space(2) & "DATE TO   " & gwt_comm.shortMonthDateFormat(CDate(dpStartFrom.Value)))
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "REC.NO    AMOUNT      DISCOUNT     TAX")
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        Dim dblAmount As Double = 0
        Dim dblDiscounts As Double = 0
        Dim dblTaxes As Double = 0

        Dim strDoc As String = Nothing
        Dim strDate As String = Nothing
        Dim strAmount As String = "0.00"
        Dim strDiscount As String = "0.00"
        Dim strTaxes As String = "0.00"

        With dGridAllData
            For i As Integer = 0 To dGridAllData.Rows.Count - 1
                strDoc = Nothing
                strDate = Nothing
                strAmount = "0.00"
                strDiscount = "0.00"
                strTaxes = "0.00"
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then
                    strDoc = Format(CInt(Convert.ToString(.Rows(i).Cells(0).Value)), "00000")
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "")) Then
                    strAmount = Format(CDbl(Convert.ToString(.Rows(i).Cells(2).Value)), "##0.00")
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "")) Then
                    strDiscount = Format(CDbl(Convert.ToString(.Rows(i).Cells(3).Value)), "##0.00")
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "")) Then
                    strTaxes = Format(CDbl(Convert.ToString(.Rows(i).Cells(4).Value)), "##0.00")
                End If

                arrPrintDetails.Add(strDoc & Space(2) & Space(8 - strAmount.Length) & strAmount & Space(3) & Space(8 - strDiscount.Length) & strDiscount & Space(3) & Space(8 - strTaxes.Length) & strTaxes)

                dblAmount = dblAmount + CDbl(strAmount)
                dblDiscounts = dblDiscounts + CDbl(strDiscount)
                dblTaxes = dblTaxes + CDbl(strTaxes)

            Next
            'Add the total Line
            strAmount = CStr(Format(dblAmount, "##0.00"))
            strDiscount = CStr(Format(dblDiscounts, "##0.00"))
            strTaxes = CStr(Format(dblTaxes, "##0.00"))
            arrPrintDetails.Add("TOTAL" & Space(2) & Space(8 - strAmount.Length) & strAmount & Space(3) & Space(8 - strDiscount.Length) & strDiscount & Space(3) & Space(8 - strTaxes.Length) & strTaxes)
            arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
            For p As Integer = 0 To 14
                arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
            Next p
        End With

        'Send the details to the printer
        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()
        For n = 0 To arrPrintDetails.Count - 1
            Dim strPrintLineDetails As String = arrPrintDetails.Item(n) & vbCrLf
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintLineDetails)
        Next
        KryptonMessageBox.Show("Report printed successfully", "Sales Details Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis print"
        ShowErrorMessage()
    End Sub

    Private Sub btnTransmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransmit.Click
        FinishProcess()
        txtBatchNo.Text = gwt_comm.GetBatchNumber()
    End Sub

    Private Sub FinishProcess()

        If dGridAllData.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.Default
        intStartNumber = CInt(dGridAllData.Rows(0).Cells(0).Value.ToString)
        intEndNumber = CInt(dGridAllData.Rows(dGridAllData.Rows.Count - 1).Cells(0).Value.ToString)
        gwt_comm.SalesInternetTransfers(intStartNumber, intEndNumber, "CASH SALES")
        If boolAbort = False Then
            MessageBox.Show("Transmission performed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Transmissions"
        ShowErrorMessage()
    End Sub

    Private Sub frmSalesPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        LoadUsers()
        If boolAbort = True Then Exit Sub
        AssignExpenseCaptureStyle()
        If boolAbort = True Then Exit Sub
        LoadSalesDetails()
        If boolAbort = True Then Exit Sub

        SuperTabControl1.SelectedTabIndex = 0
        cboUser.SelectedIndex = 0
    End Sub

    Private Sub AssignExpenseCaptureStyle()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ClassicExpensesCaptureStatus FROM Company", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        boolClassicExpensesCapture = True
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(objReader(0).ToString) = "NO" Then
                    boolClassicExpensesCapture = False
                End If
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Expenses Capture Form Type Fetch"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadUsers()
        On Error GoTo RaiseErr
        cboUser.Items.Clear()
        cboUser.Items.Add("--- ALL ---")
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT UserName FROM Users ORDER BY UserName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboUser.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Usernames Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGridAllData_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridAllData.CellContentDoubleClick
        If dGridAllData.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridAllData.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridAllData.CurrentRow.Cells(0).Value.ToString) Then
                boolTransactionVoided = False
                intSelectedTransaction = CInt(dGridAllData.CurrentRow.Cells(0).Value.ToString)
                strCalledBy = Nothing
                Dim f As New frmSalesDetails
                f.ShowDialog()
                If boolTransactionVoided = True Then LoadSalesDetails()
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    'Private Sub dGridAllData_DoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridAllData.DoubleClick

    'End Sub

    Private Sub ViewAgentSalesDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAgentSalesDetailsToolStripMenuItem.Click
        'Get the selected agent name and then call the view details form
        If dGridCommissions.RowCount <= 0 Then Exit Sub
        strSelectedCustomerName = dGridCommissions.CurrentRow.Cells(0).Value
        StartDate = dpStartFrom.Value : EndDate = dpEndTo.Value
        Dim f As New frmSalesDetailedCommissionView
        f.ShowDialog()
        strSelectedCustomerName = Nothing
        'Reload the grid for commissions only
        LoadCommissionsData()
    End Sub

    Private Sub EnterAgentPurchasesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnterAgentPurchasesToolStripMenuItem.Click
        If dGridAllData.RowCount <= 0 Then Exit Sub
        intLinkedDocumentNumber = CInt(dGridAllData.CurrentRow.Cells(0).Value.ToString)
        Dim strBuffer() As String = Split(dGridAllData.CurrentRow.Cells(1).Value.ToString, "-")
        dpLinkedDate = CDate(strBuffer(0) & "-" & MonthName(CInt(strBuffer(1)), True) & "-" & strBuffer(2))
        Dim f As New frmSalesToAgents
        f.ShowDialog()
    End Sub

    Private Sub btnTaxInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaxInvoice.Click
        If dGridAllData.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim i As Integer = dGridAllData.CurrentRow.Index
        intSelectedTransaction = CInt(dGridAllData.Rows(i).Cells(0).Value.ToString)
        Dim boolTaxInvoiceDone As Boolean = False

        'Check that no saved invoice has been made against this record
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Count(DocumentNumber) FROM CashTaxInvoices WHERE DocumentNumber = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                If CInt(objReader(0).ToString) > 0 Then
                    boolTaxInvoiceDone = True
                End If
            End If
        End If
        objReader.Close()

        If boolTaxInvoiceDone = True Then
            MessageBox.Show("A tax invoice has already been done against this receipt" & vbCrLf & "You can re-print from the list of saved tax invoices", "Tax Invoice Already Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        boolPrintingSavedTaxInvoice = False
        boolAbort = False
        Dim f As New frmTaxInvoiceCustomerDetails
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        boolPrinterAlreadySelected = False
        gwt_comm.PrintCustomerDocument(intSelectedTransaction, "TAX INVOICE")

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Tax Invoice"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GenerateTransactionDocument(ByVal intDocumentNumber As Integer)
        'get invoice number
        On Error GoTo RaiseErr
        Dim n As Integer = 0
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim strCustomerNumber As String = Nothing

        myCommand = New Data.OleDb.OleDbCommand("Select CONVERT(NVARCHAR, TransDate, 105) as [TransDate], Amount, Taxes, " _
            & "Discount, CustomerId, OrderNumber, SalesRep " _
            & "FROM CustomerSalesMain Where InvoiceNumber = " & intDocumentNumber & "", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            Dim strDateparts() As String = Split(dbReader(0).ToString, "-")
            If Not IsDBNull(dbReader(0).ToString) Then strDate = CDate(strDateparts(0) & "-" & MonthName(CInt(strDateparts(1)), True) & "-" & strDateparts(2))
            If IsNumeric(dbReader(1).ToString) Then dblInvoiceTotal = CDbl(dbReader(1).ToString) Else dblInvoiceTotal = 0
            If IsNumeric(dbReader(2).ToString) Then dblTaxes = dbReader(2).ToString Else dblTaxes = 0
            If IsNumeric(dbReader(3).ToString) Then dblDiscounts = dbReader(3).ToString Else dblDiscounts = 0
            If Not IsDBNull(dbReader(4).ToString) Then strCustomerNumber = dbReader(4).ToString
            If Not IsDBNull(dbReader("OrderNumber").ToString) Then strOrderNumber = dbReader("OrderNumber").ToString
            If Not IsDBNull(dbReader("SalesRep").ToString) Then strSalesRep = dbReader("SalesRep").ToString
        End If
        dbReader.Close()

        'Get the customer details
        myCommand = New Data.OleDb.OleDbCommand("SELECT AccountName, Address1, Address2, Address3, Address4, " _
            & "PhoneNumber, EmailAddress, VatNumber FROM Customers WHERE AccountNumber = '" & strCustomerNumber & "'", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            If Not IsDBNull(dbReader(0).ToString) Then strCustomerName = dbReader(0).ToString
            If Not IsDBNull(dbReader(1).ToString) Then strCustomerAddress1 = dbReader(1).ToString
            If Not IsDBNull(dbReader(2).ToString) Then strCustomerAddress2 = dbReader(2).ToString
            If Not IsDBNull(dbReader(3).ToString) Then strCustomerAddress3 = dbReader(3).ToString
            If Not IsDBNull(dbReader(4).ToString) Then strCustomerAddress4 = dbReader(4).ToString
            If Not IsDBNull(dbReader(5).ToString) Then strCustomerTelephone = dbReader(5).ToString
            If Not IsDBNull(dbReader(6).ToString) Then strCustomerEmailaddress = dbReader(6).ToString
            If Not IsDBNull(dbReader(7).ToString) Then strCustomerVatNumber = dbReader(7).ToString
        End If

        myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity, ItemCode, Description as [Description], SalesPrice, " _
            & "DiscountAllowed, Taxes, (((SalesPrice * Quantity) - DiscountAllowed) + Taxes) AS [Payable] " _
            & "from CustomerSales where InvoiceNumber = " & intDocumentNumber & "", cnn)
        dbReader = myCommand.ExecuteReader
        strInvoiceDetails = New ArrayList
        While dbReader.Read
            Dim strLine As String = Nothing
            For n = 0 To dbReader.FieldCount - 1
                If n = 0 Then
                    strLine = dbReader(n).ToString & "|"
                Else
                    strLine = strLine & dbReader(n).ToString & "|"
                End If
            Next
            strInvoiceDetails.Add(strLine)
        End While
        dbReader.Close()

        boolPrintFromPreview = False

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Invoice Generation Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        boolAbort = False
        Dim f As New frmCostPriceAdjustmentOnSales
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        'Get the item id
        On Error GoTo RaiseErr
        Dim intId As Integer = CInt(dGrid.CurrentRow.Cells(dGrid.ColumnCount - 1).Value.ToString)
        Dim dblSalesPrc As Double = CDbl(dGrid.CurrentRow.Cells(4).Value.ToString)
        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE Sales SET CostPrice = " & dblNewCostPrice & " WHERE InvoiceNumber = " & intId & "", cnn)
        objCommand.ExecuteNonQuery()
        'Change the current cell value for the cost price
        dGrid.CurrentRow.Cells(6).Value = Format(dblNewCostPrice, "##0.00")
        dGrid.CurrentRow.Cells(7).Value = Format((dblSalesPrc - dblNewCostPrice), "##0.00")
        If KryptonMessageBox.Show("Cost Price adjusted successfully. Do you want to refresh items right away?",
                "Cost Price Update Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            LoadSalesByInventory()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On cost price adjustment after sales"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrintReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintReceipt.Click
        PrintReceipt()
    End Sub

    Private Sub BuildRXML(ByVal myGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView, ByVal strReportHeader As String)
        On Error GoTo RaiseErr
        Dim arrPrintDetails As New ArrayList
        If myGrid.Rows.Count <= 0 Then
            KryptonMessageBox.Show("No details to print. Process will be aborted", "Report Generation Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        With myGrid
            For i As Integer = 0 To .Rows.Count - 1
                Dim strLineData As String = Nothing
                For p As Integer = 0 To .ColumnCount - 1
                    'FN=Arial;FS=8;FC=White;FB=False;FI=False;FU=False;BC=Navy;RH=25
                    Dim strFontName As String = "Arial"
                    Dim intFontSize As Integer = 6
                    Dim strFontColor As String = "Black"
                    Dim strFontBold As String = "False"
                    Dim strFontItalic As String = "False"
                    Dim strFontUnderline As String = "False"
                    Dim strBackColor As String = "White"
                    Dim intRectangleHeight As Integer = 25
                    Dim strPrintData As String = Nothing

                    If .Columns(p).Visible = True Then
                        If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(p).Value), "")) Then
                            strPrintData = .Rows(i).Cells(p).Value.ToString
                            'Get the actual font and style used in the grid
                            Dim fnt As Font = .Rows(i).Cells(p).Style.Font
                            If fnt Is Nothing Then intFontSize = 6 Else intFontSize = fnt.Size
                            If fnt Is Nothing Then strFontName = "Ariel" Else strFontName = fnt.Name
                            Dim strFontStyle As String = "False"
                            If Not fnt Is Nothing Then strFontStyle = fnt.Style
                            If strFontStyle = "1" Then strFontBold = "True"
                            If strFontStyle = "2" Then strFontItalic = "True"
                            If strFontStyle = "3" Then ' Bold and italic
                                strFontBold = "True"
                                strFontItalic = "True"
                            End If
                            If strFontStyle = "4" Then strFontUnderline = "True"
                            If strFontStyle = "5" Then ' Bold and underline
                                strFontBold = "True"
                                strFontUnderline = "True"
                            End If
                            If strFontStyle = "6" Then ' italic and underline
                                strFontItalic = "True"
                                strFontUnderline = "True"
                            End If
                            If strFontStyle = "7" Then ' italic and underline
                                strFontItalic = "True"
                                strFontUnderline = "True"
                                strFontBold = "True"
                            End If

                            Dim intAlignment As Integer = 0

                            'Get the column alignment DataGridViewContentAlignment.MiddleCenter
                            Dim selectedCell As DataGridViewCell = .Rows(i).Cells(p)
                            Dim align As System.Drawing.ContentAlignment
                            'For Each selectedCell In .SelectedCells
                            align = selectedCell.InheritedStyle.Alignment
                            If selectedCell.InheritedStyle.Alignment = DataGridViewContentAlignment.MiddleLeft Then
                                intAlignment = 0
                            End If
                            If selectedCell.InheritedStyle.Alignment = DataGridViewContentAlignment.MiddleCenter Then
                                intAlignment = 1
                            End If
                            If selectedCell.InheritedStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                                intAlignment = 2
                            End If
                            'Next


                            strLineData = strLineData & strPrintData & "|FN=" & strFontName & ";FS=" & intFontSize _
                                & ";FC=" & strFontColor & ";FB=" & strFontBold & ";FI=" & strFontItalic & ";FU=" & strFontUnderline _
                                & ";BC=" & strBackColor & ";RH=" & intRectangleHeight & ";AL=" & intAlignment & "</d>"
                        Else
                            strLineData = strLineData & " |FN=" & strFontName & ";FS=" & intFontSize _
                                & ";FC=" & strFontColor & ";FB=" & strFontBold & ";FI=" & strFontItalic & ";FU=" & strFontUnderline _
                                & ";BC=" & strBackColor & ";RH=" & intRectangleHeight & ";AL=0</d>"
                        End If
                    End If
                Next
                strLineData = Mid(strLineData, 1, strLineData.Length - 4)
                arrPrintDetails.Add(strLineData)

            Next


            Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
            For i As Integer = 0 To arrPrintDetails.Count - 1
                strPrintDetails(i) = arrPrintDetails.Item(i)
            Next

            Dim strColumnHeaders As String = Nothing
            For i As Integer = 0 To .ColumnCount - 1
                If .Columns(i).Visible = True Then strColumnHeaders = strColumnHeaders & .Columns(i).HeaderText & "|"
            Next
            strColumnHeaders = Mid(strColumnHeaders, 1, (strColumnHeaders.Length - 1))

            'Request for print properties
            Dim prnt As New PrintDialog
            prnt.ShowDialog()

            Dim intPrintPageAreaWidth As Integer = prnt.PrinterSettings.DefaultPageSettings.PaperSize.Width _
                    - (prnt.PrinterSettings.DefaultPageSettings.Margins.Left + prnt.PrinterSettings.DefaultPageSettings.Margins.Right)

            'Widths are based on the percentage point of the paper size and the grid
            Dim strColumnWidths As String = Nothing
            Dim strColumsVisible As String = Nothing

            Dim intTotalGridWidth As Integer = 0
            'calculate the total column widths
            For y As Integer = 0 To .ColumnCount - 1
                intTotalGridWidth = intTotalGridWidth + .Columns(y).Width
            Next

            Dim intValidateWidth As Integer = 0
            For i As Integer = 0 To myGrid.ColumnCount - 1
                Dim intCurrentWidth As Integer = 0
                If .Columns(i).Visible = True Then
                    'Calculate the width based on the percentage in the grid
                    Dim intEqualWidth As Integer = intPrintPageAreaWidth / .Columns.Count
                    Dim intPercentagePrintArea As Integer = (.Columns(i).Width / intTotalGridWidth) * 100
                    intCurrentWidth = intPrintPageAreaWidth * (intPercentagePrintArea / 100)

                    strColumnWidths = strColumnWidths & intCurrentWidth & "|"

                    If intCurrentWidth = 0 Then
                        strColumsVisible = strColumsVisible & "NO" & "|"
                    Else
                        strColumsVisible = strColumsVisible & "YES" & "|"
                    End If
                    intValidateWidth = intValidateWidth + intCurrentWidth
                End If
            Next
            strColumnWidths = Mid(strColumnWidths, 1, (strColumnWidths.Length - 1))
            strColumsVisible = Mid(strColumsVisible, 1, (strColumsVisible.Length - 1))

            Dim intNumberOfColumns As Integer = 0
            For z As Integer = 0 To .Columns.Count - 1
                If .Columns(z).Visible = True Then intNumberOfColumns = intNumberOfColumns + 1
            Next

            Dim rpt As New SmartReportWriter.SmartReportWriter
            With rpt
                .intPrintRecordsCount = strPrintDetails.Length
                .intNumberOfColumns = intNumberOfColumns
                .strColumnHeaders = UCase(strColumnHeaders)
                .strColumnWidths = strColumnWidths
                .strFooterCaption = strReportHeader
                .strMainCaption = UCase(strReportHeader)
                .strMainHeader2 = "PERIOD COVERED " & UCase(StartDate.ToShortDateString) & " TO " & UCase(EndDate.ToShortDateString)
                .strMainHeader3 = ""
                .FooterColor = Color.FromName("Black")
                .TitleColor = Color.FromName("Black")
                .DrawBorder = True
                .HorizontalLines = True
                .VerticalLines = True
                .GridColor = Color.WhiteSmoke
                .BorderColor = Color.FromName("WhiteSmoke")
                .HeaderFont = New Font("Arial", 10, FontStyle.Bold)
                .FooterFont = New Font("Arial", 6, FontStyle.Bold)
                .boolGenericReport = False
                .strPrintValues = strPrintDetails
                .VisibleColumns = strColumsVisible
                .DetailColor = Color.Black
                .DetailFont = fntDetailsFont
                .boolPrintTotals = True
            End With

            Dim documentPreview As New PrintPreviewDialog
            documentPreview.Document = rpt
            documentPreview.ShowDialog()

        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Report Generation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnInventoryBased_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventoryBased.Click
        BuildRXML(dGrid, "Sales By Products Report")
    End Sub

    Private Sub StockMovements()
        On Error GoTo RaiseErr
        'Cursor = Cursors.WaitCursor

        ''LEFT OUTER JOIN InventoryItems " _
        ''& "ON Sales.ItemCode = InventoryItems.ItemCode WHERE TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        ''& "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' 

        'dGridStockMovement.Rows.Clear()

        'Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT InventoryItems.ItemCode, " _
        '    & "InventoryItems.GroupName, InventoryType FROM InventoryItems " _
        '    & "GROUP BY ItemCode, InventoryItems.GroupName, InventoryItems.InventoryType ORDER BY ItemCode", cnn)
        'Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        'While objReader.Read

        '    Dim objReadValues As Data.OleDb.OleDbDataReader
        '    Dim dblClosingQty As Double = 0
        '    Dim dblSalesQty As Double = 0
        '    Dim dblTransfersOut As Double = 0
        '    Dim dblDeliveryOut As Double = 0
        '    Dim dblReceivedQty As Double = 0
        '    Dim dblTransfersIn As Double = 0

        '    'Get the closing stock qty
        '    If UCase(objReader(2).ToString) = "SPECIFIC" Then
        '        objCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(ItemCode) FROM SerialNumbers WHERE ItemCode = '" & objReader(0).ToString & "'", cnn)
        '        objReadValues = objCommand.ExecuteReader
        '        If objReadValues.HasRows Then
        '            objReadValues.Read()
        '            If IsNumeric(objReadValues(0).ToString) Then dblClosingQty = CDbl(objReadValues(0).ToString)
        '        End If
        '        objReadValues.Close()
        '    Else
        '        objCommand = New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & objReader(0).ToString & "'", cnn)
        '        objReadValues = objCommand.ExecuteReader
        '        If objReadValues.HasRows Then
        '            objReadValues.Read()
        '            If IsNumeric(objReadValues(0).ToString) Then dblClosingQty = CDbl(objReadValues(0).ToString)
        '        End If
        '        objReadValues.Close()
        '    End If

        '    'Get the sales quantity this includes both cash and debtors

        '    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Quantity) FROM Sales WHERE ItemCode = '" & objReader(0).ToString & "' " _
        '        & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        '        & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "'", cnn)
        '    objReadValues = objCommand.ExecuteReader
        '    If objReadValues.HasRows Then
        '        objReadValues.Read()
        '        If IsNumeric(objReadValues(0).ToString) Then dblSalesQty = CDbl(objReadValues(0).ToString)
        '    End If
        '    objReadValues.Close()

        '    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Quantity) FROM CustomerSales WHERE ItemCode = '" & objReader(0).ToString & "' " _
        '        & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        '        & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "'", cnn)
        '    objReadValues = objCommand.ExecuteReader
        '    If objReadValues.HasRows Then
        '        objReadValues.Read()
        '        If IsNumeric(objReadValues(0).ToString) Then dblSalesQty = dblSalesQty + CDbl(objReadValues(0).ToString)
        '    End If
        '    objReadValues.Close()

        '    'Get the transfers out to branches
        '    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Quantity) from InventoryTransfers WHERE " _
        '        & "ReceivingBranch <> '" & strUserBranch & "' AND ItemCode = '" & objReader(0).ToString & "' " _
        '        & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        '        & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "'", cnn)
        '    objReadValues = objCommand.ExecuteReader
        '    If objReadValues.HasRows Then
        '        objReadValues.Read()
        '        If IsNumeric(objReadValues(0).ToString) Then dblTransfersOut = CDbl(objReadValues(0).ToString)
        '    End If
        '    objReadValues.Close()

        '    'Get the deliveries out

        '    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Quantity) from GatePasses WHERE " _
        '        & "PassType <> 'TRANSFER' AND ItemCode = '" & objReader(0).ToString & "' " _
        '        & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        '        & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "'", cnn)
        '    objReadValues = objCommand.ExecuteReader
        '    If objReadValues.HasRows Then
        '        objReadValues.Read()
        '        If IsNumeric(objReadValues(0).ToString) Then dblDeliveryOut = CDbl(objReadValues(0).ToString)
        '    End If
        '    objReadValues.Close()

        '    'Get the received items quantity
        '    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Quantity) from OrdersReceipt WHERE " _
        '        & "DestinationBranch <> '" & strUserBranch & "' AND ItemCode = '" & objReader(0).ToString & "' " _
        '        & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        '        & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "'", cnn)
        '    objReadValues = objCommand.ExecuteReader
        '    If objReadValues.HasRows Then
        '        objReadValues.Read()
        '        If IsNumeric(objReadValues(0).ToString) Then dblReceivedQty = CDbl(objReadValues(0).ToString)
        '    End If
        '    objReadValues.Close()

        '    'Get the transfers in 
        '    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Quantity) from InventoryTransfers WHERE " _
        '        & "ReceivingBranch = '" & strUserBranch & "' AND ItemCode = '" & objReader(0).ToString & "' " _
        '        & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        '        & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "'", cnn)
        '    objReadValues = objCommand.ExecuteReader
        '    If objReadValues.HasRows Then
        '        objReadValues.Read()
        '        If IsNumeric(objReadValues(0).ToString) Then dblTransfersIn = CDbl(objReadValues(0).ToString)
        '    End If
        '    objReadValues.Close()

        '    Dim dblOpeningStock As Double = (dblClosingQty + dblSalesQty + dblDeliveryOut + dblTransfersOut) - (dblTransfersIn + dblReceivedQty)
        '    dGridStockMovement.Rows.Add(objReader(0), objReader(1), dblClosingQty, dblSalesQty, dblDeliveryOut, dblTransfersOut, dblTransfersIn, dblReceivedQty, dblOpeningStock)

        'End While
        'objReader.Close()
        'Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Stock Movement Report Generation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnStockMovement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStockMovement.Click
        BuildRXML(dGridStockMovement, "Sales By Products Report")
    End Sub

    Private Sub mnuChangePayMethod_Click(sender As System.Object, e As System.EventArgs) Handles mnuChangePayMethod.Click

        If dGridAllData.RowCount <= 0 Then Exit Sub
        strPaymentMethod = Nothing
        boolAbort = False

        dblAmountTenderedCash = 0
        dblAmountTenderedEcoCash = 0
        dblAmountTenderedSwipe = 0
        dblAmountTenderedTransfer = 0
        dblAmountTenderedOther = 0

        dblReceiptAmount = 0

        If Not Object.Equals(dGridAllData.CurrentRow.Cells(5).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridAllData.CurrentRow.Cells(5).Value.ToString) Then
                If IsNumeric(dGridAllData.CurrentRow.Cells(5).Value.ToString) Then
                    dblReceiptAmount = CDbl(dGridAllData.CurrentRow.Cells(5).Value.ToString)
                End If
            End If
        End If

        Dim frm As New frmPayMethodChange
        frm.ShowDialog()

        If boolAbort = True Then Exit Sub

        On Error GoTo RaiseErr
        Dim intInvoice As Integer = CInt(dGridAllData.CurrentRow.Cells(0).Value.ToString)
        Dim strSql As String = "UPDATE SalesMain SET Cash = " & dblAmountTenderedCash & ", " _
            & "EcoCash = " & dblAmountTenderedEcoCash & ", Swipe = " & dblAmountTenderedSwipe & ", " _
            & "Transfer = " & dblAmountTenderedTransfer & ", Other = " & dblAmountTenderedOther & " WHERE " _
            & "InvoiceNumber = " & intInvoice & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        LoadSalesDetails()
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Payment Method Change"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnExpenses_Click(sender As System.Object, e As System.EventArgs) Handles btnExpenses.Click
        strPublicActiveCashbook = Nothing
        boolAbort = False
        gwt_comm.CashbookSelection()
        If boolAbort = True Then Exit Sub
        gwt_comm.ExpensesCapture(boolClassicExpensesCapture)
    End Sub

    Private Sub btnReconcilliation_Click(sender As System.Object, e As System.EventArgs) Handles btnReconcilliation.Click
        boolAbort = False
        LoadSalesDetails()
        If boolAbort = True Then Exit Sub
        On Error GoTo RaiseErr

        Dim dblDeemedCash As Double = 0
        dblDeemedCash = CDbl(lblTotals.Text) - (CDbl(lblEcocash.Text) + CDbl(lblTransfers.Text) + CDbl(lblSwipes.Text) + CDbl(lblExpenses.Text))
        arrSelectedItems = New ArrayList
        With arrSelectedItems
            .Add(lblTotals.Text)
            .Add("(" & lblTransfers.Text & ")")
            .Add("(" & lblSwipes.Text & ")")
            .Add("(" & lblEcocash.Text & ")")
            .Add(lblCash.Text)
            .Add("(" & lblExpenses.Text & ")")
            .Add(Format(dblDeemedCash, "##0.00"))
        End With
        Dim frm As New frmSalesReconcilliation
        frm.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Sales Reconcilliation Generate"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function GetExpensesTotal() As String
        On Error GoTo RaiseErr
        Dim strExpensesAmt As String = "0.00"
        Dim strSql As String = Nothing

        If boolClassicExpensesCapture = True Then
            strSql = "SELECT SUM(TotalAmt) FROM Temp_Expenses " _
                & "WHERE TransactionDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartFrom.Value) & "' AND " _
                & "'" & gwt_comm.shortMonthDateFormat(dpEndTo.Value) & "'"
        Else
            strSql = "SELECT ISNULL(SUM(Amount), 0) FROM CashbookTransactions " _
                & "WHERE TransactionDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartFrom.Value) & "' AND " _
                & "'" & gwt_comm.shortMonthDateFormat(dpEndTo.Value) & "' and TransactionType = 'CREDIT'"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                If IsNumeric(objReader(0).ToString) Then strExpensesAmt = Format(CDbl(objReader(0).ToString), "##0.00")
            End If
        End If
        'Dim strSql As String = "SELECT CAST(SUM(Amount) AS DECIMAL (10,2)) AS [Amt] FROM LedgerTransactions WHERE " _
        '    & "TransactionDate BETWEEN '" & Format(dpStartFrom.Value, "dd-MMM-yyyy") & "' AND " _
        '    & "'" & Format(dpEndTo.Value, "dd-MMM-yyyy") & "' AND TransactionType = 'DEBIT' AND CostCode <> '0'"
        'Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        'Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        'If objReader.HasRows Then
        '    objReader.Read()
        '    If IsNumeric(objReader(0).ToString) Then strExpensesAmt = Format(CDbl(objReader(0).ToString), "##0.00")
        'End If
        objReader.Close()
        Return strExpensesAmt
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Expenses Total Fetch"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub btnPosting_Click(sender As System.Object, e As System.EventArgs) Handles btnPosting.Click
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
            boolEditStatus = False
            Dim frm As New frmSalesDailyPostings
            frm.ShowDialog()
        Else
            gwt_comm.DenyAccess()
        End If
    End Sub

    Private Sub btnDailySalesSheet_Click(sender As System.Object, e As System.EventArgs) Handles btnDailySalesSheet.Click
        PrintDailySalesSheets()
    End Sub

    Public Sub PrintDailySalesSheets()
        On Error GoTo RaiseErr


        boolAbort = False
        gwt_comm.DateRangeSpecification()
        If boolAbort = True Then Exit Sub

        Dim objCommandDates As New Data.OleDb.OleDbCommand("SELECT DISTINCT TransDate FROM SalesMain WHERE TransDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
        Dim objReadDates As Data.OleDb.OleDbDataReader = objCommandDates.ExecuteReader

        boolAbort = False
        gwt_comm.PrinterSelection()
        If boolAbort = True Then Exit Sub

        'Get the count
        'objCommandDates = New Data.OleDb.OleDbCommand("SELECT DISTICT COUNT(TransDate) FROM SalesMain", cnn)

        While objReadDates.Read
            Dim strSql As String = Nothing
            If UCase(strTaxComputationType) = "INCLUSIVE" Then
                strSql = "SELECT InventoryItems.GroupName, Sales.SalesPrice, Sales.Quantity, " _
                    & "Sales.DiscountAllowed, (((Sales.SalesPrice * Sales.Quantity) - DiscountAllowed) - (((Sales.SalesPrice * Sales.Quantity) - DiscountAllowed) * (100 / (100 + dblSalesTaxRate))) AS [Taxes], " _
                    & "Sales.SerialNumbers, (((Sales.SalesPrice * Sales.Quantity) - DiscountAllowed) - 0) AS [Paid], " _
                    & "InventoryItems.Category FROM Sales " _
                    & "LEFT JOIN InventoryItems ON Sales.ItemCode = InventoryItems.ItemCode " _
                    & "WHERE Sales.TransDate = '" & gwt_comm.shortMonthDateFormat(CDate(objReadDates(0).ToString)) & "' ORDER BY InventoryItems.Category, Sales.ItemCode"
            Else
                strSql = "SELECT InventoryItems.GroupName, Sales.SalesPrice, Sales.Quantity, " _
                    & "Sales.DiscountAllowed, Sales.Taxes, Sales.SerialNumbers, (((Sales.SalesPrice * Sales.Quantity) - DiscountAllowed) + Sales.Taxes) AS [Paid], " _
                    & "InventoryItems.Category FROM Sales " _
                    & "LEFT JOIN InventoryItems ON Sales.ItemCode = InventoryItems.ItemCode " _
                    & "WHERE Sales.TransDate = '" & gwt_comm.shortMonthDateFormat(CDate(objReadDates(0).ToString)) & "' ORDER BY InventoryItems.Category, Sales.ItemCode"
            End If
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            Dim arrPrintData As New ArrayList
            While objReader.Read
                Dim strItemName As String = Nothing
                Dim strUnitPrice As String = "0.00"
                Dim strQuantity As String = "1.00"
                Dim strDiscount As String = "0.00"
                Dim strTaxes As String = "0.00"
                Dim strSerial As String = Nothing
                Dim strAmtPaid As String = "0.00"
                Dim strCategory As String = Nothing
                If Not IsDBNull(objReader(0).ToString) Then strItemName = UCase(objReader(0).ToString)
                If IsNumeric(objReader(1).ToString) Then strUnitPrice = Format(CDbl(objReader(1).ToString), "##0.00")
                If IsNumeric(objReader(2).ToString) Then strQuantity = Format(CDbl(objReader(2).ToString), "##0.00")
                If IsNumeric(objReader(3).ToString) Then strDiscount = Format(CDbl(objReader(3).ToString), "##0.00")
                If IsNumeric(objReader(4).ToString) Then strTaxes = Format(CDbl(objReader(4).ToString), "##0.00")
                If Not IsDBNull(objReader(5).ToString) Then strSerial = UCase(objReader(5).ToString)
                If IsNumeric(objReader(6).ToString) Then strAmtPaid = Format(CDbl(objReader(6).ToString), "##0.00")
                If Not IsDBNull(objReader(7).ToString) Then strCategory = UCase(objReader(7).ToString)
                arrPrintData.Add(strItemName & ";" & strUnitPrice & ";" & strQuantity & ";" & strDiscount & ";" & strTaxes & ";" & strSerial & ";" & strAmtPaid & ";" & strCategory)
            End While
            objReader.Close()

            'Get the laybye payments for that day
            arrPrintData.Add("ADD LAYBYE PAYMENTS; ; ; ; ; ; ;LAYBYES")
            objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, LaybyCustomers.AccountName) +'-'+ CONVERT(NVARCHAR, " _
                & "LaybyTransactions.AccountNumber) +';0;0;0;0;'+ CONVERT(NVARCHAR, LaybyTransactions.DocumentNumber) +';'+ " _
                & "CONVERT(NVARCHAR, CAST(SUM(LaybyTransactions.Amount) AS DECIMAL (10,2))) +';LAYBYES' AS [LineDetail] FROM LaybyTransactions " _
                & "LEFT OUTER JOIN LaybyCustomers ON LaybyCustomers.AccountNumber = LaybyTransactions.AccountNumber " _
                & "WHERE TransDate = '" & gwt_comm.shortMonthDateFormat(CDate(objReadDates(0).ToString)) & "' AND TransType = 'PAYMENT' " _
                & " GROUP BY LaybyTransactions.AccountNumber, LaybyCustomers.AccountName, LaybyTransactions.DocumentNumber", cnn)
            objReader = objCommand.ExecuteReader()
            While objReader.Read
                arrPrintData.Add(objReader(0))
            End While
            objReader.Close()

            'Get the customer payments for that day
            arrPrintData.Add("ADD CUSTOMER ACCOUNT PAYMENTS; ; ; ; ; ; ;ACCOUNT PAYMENTS")
            objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, Customers.AccountName) +'-'+ " _
                & "CONVERT(NVARCHAR, CustomerTransactions.AccountNumber) +';0;0;0;0;'+ " _
                & "CONVERT(NVARCHAR, CustomerTransactions.ReferenceNumber) +';'+ " _
                & "CONVERT(NVARCHAR, CAST(SUM(CustomerTransactions.Amount) AS DECIMAL (10,2))) +';" _
                & "ACCOUNT PAYMENTS' AS [LineDetail] FROM CustomerTransactions LEFT OUTER JOIN Customers ON " _
                & "Customers.AccountNumber = CustomerTransactions.AccountNumber WHERE TransactionDate = '" & gwt_comm.shortMonthDateFormat(CDate(objReadDates(0).ToString)) & "' " _
                & "AND TransactionType = 'PAYMENT' GROUP BY CustomerTransactions.AccountNumber, " _
                & "Customers.AccountName, CustomerTransactions.ReferenceNumber", cnn)
            objReader = objCommand.ExecuteReader()
            While objReader.Read
                arrPrintData.Add(objReader(0))
            End While
            objReader.Close()

            'Get the expenses for that day
            arrPrintData.Add("LESS EXPENSES; ; ; ; ; ; ;EXPENSES")
            strSql = "SELECT  (CashbookTransactions.Description +';0;0;0;0;'+ CashbookTransactions.ContraAccount +';'+ " _
                & "CONVERT(NVARCHAR, CAST((0 - CashbookTransactions.Amount) AS DECIMAL (10,2)))) +';EXPENSES' AS [ExpenseDetails] " _
                & "FROM CashbookTransactions WHERE TransactionType = 'CREDIT' AND TransactionDate = '" & gwt_comm.shortMonthDateFormat(CDate(objReadDates(0).ToString)) & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader()
            While objReader.Read
                arrPrintData.Add(objReader(0))
            End While
            objReader.Close()

            If arrPrintData.Count >= 0 Then

                'Send the information to the printing class
                Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
                For i As Integer = 0 To strPrintDetails.Length - 1
                    strPrintDetails(i) = arrPrintData.Item(i)
                Next
                Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
                With rpt
                    .intPrintRecordsCount = strPrintDetails.Length
                    .intNumberOfColumns = 8
                    .strColumnHeaders = "ITEM|UNIT PRICE|QTY|DISCOUNTS|TAXES|SERIAL/REC #|RECEIVED|"
                    .strColumnAlignments = "0|2|2|2|2|0|2|0"
                    .strColumnWidths = "200|80|50|80|60|100|80|0"
                    .strFooterCaption = "Daily Sales Cashout"
                    .strMainCaption = UCase(strCompanyName)
                    .strMainHeader2 = "DAILY SALES SHEET : " & UCase(gwt_comm.shortMonthDateFormat(CDate(objReadDates(0).ToString)))
                    .strMainHeader3 = UCase(strUserBranch)
                    .strColumnTotals = "NO|NO|NO|NO|NO|NO|YES|NO"
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
                    .boolGroupDetails = True
                    .boolPrintTotals = True
                    .boolGenericReport = False
                    .boolPrintRecordCount = True
                    .PrintSummary = True
                    .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|NO"
                    .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO|NO"
                    .strSummaryTotals = "NO|NO|NO|NO|NO|NO|YES|NO"
                    .intKeyFieldIndex = 7
                    .strPrintValues = strPrintDetails
                End With

                Dim pd As New PrintDialog()
                pd.PrinterSettings = New System.Drawing.Printing.PrinterSettings()

                rpt.PrinterSettings.PrinterName = strSessionPrinter
                rpt.Print()
            End If
            'Dim documentPreview As New PrintPreviewDialog
            'documentPreview.Document = rpt
            'documentPreview.print()
        End While
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Encountered error while trying to print daily sales report"
        gwt_comm.ShowErrorMessage()
    End Sub


    '----------------------------- TAX RETURNS PROGRAM -----------------------------------------

    Private Sub btnGoTax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoTax.Click
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter the desired value", "Mising Monthly Sales Total", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtInvoiceNumber.Text) Then
            MessageBox.Show("Please the starting invoice number", "Mising Invoice Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtInvoiceNumber.Focus()
            Exit Sub
        End If
        LoadTaxSalesDetails()
        LoadFixedSales()
    End Sub

    Private Sub LoadTaxSalesDetails()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        grdCash.Rows.Clear()

        'Compute the daily average based on the desired amount
        Dim intDays As Integer = (DateDiff(DateInterval.Day, dpStartFromTax.Value, dpEndToTax.Value) + 1)
        Dim intFinalDaysCount As Integer = 0
        For n As Integer = 0 To intDays - 1
            Dim evalDate As Date = DateAdd(DateInterval.Day, n, CDate(gwt_comm.shortMonthDateFormat(dpStartFromTax.Value)))
            If evalDate.DayOfWeek = DayOfWeek.Sunday Or evalDate.DayOfWeek = DayOfWeek.Sunday Then
                intFinalDaysCount = intDays - 1
            End If
        Next
        Dim lngInvoiceNumber As Long = CLng(txtInvoiceNumber.Text)
        Dim dblDailyAverage As Double = Math.Round((CDbl(txtAmount.Text) / intFinalDaysCount), 2)
        Dim dblCurrentMovingTotal As Double = 0

        For intRuns As Integer = 0 To intDays - 1
            StartDate = DateAdd(DateInterval.Day, intRuns, CDate(gwt_comm.shortMonthDateFormat(dpStartFromTax.Value)))
            EndDate = StartDate

            Dim strSql As String = Nothing
            strSql = "Select InvoiceNumber AS [Inv. #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                & "CAST(Cash AS DECIMAL (10,2)) AS [Amount], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                & "CAST(Taxes AS DECIMAL (10,2)) AS [Vat] from SalesMain WHERE TransDate BETWEEN " _
                & "'" & StartDate & "' AND '" & EndDate & "' ORDER by InvoiceNumber, TransDate"

            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            dblCurrentMovingTotal = 0

            While objReader.Read
                If dblCurrentMovingTotal < dblDailyAverage Then
                    grdCash.Rows.Add(1)
                    If Not IsDBNull(objReader(0).ToString) Then grdCash.Rows(grdCash.Rows.Count - 1).Cells(0).Value = Format(CInt(objReader(0).ToString), "000000")
                    If Not IsDBNull(objReader(1).ToString) Then grdCash.Rows(grdCash.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                    If Not IsDBNull(objReader(2).ToString) Then grdCash.Rows(grdCash.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
                    If Not IsDBNull(objReader(3).ToString) Then grdCash.Rows(grdCash.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
                    If Not IsDBNull(objReader(4).ToString) Then grdCash.Rows(grdCash.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
                    grdCash.Rows(grdCash.Rows.Count - 1).Cells(5).Value = lngInvoiceNumber
                    dblCurrentMovingTotal = dblCurrentMovingTotal + CDbl(objReader(2).ToString)
                    lngInvoiceNumber = lngInvoiceNumber + 1
                Else
                    grdCash.Rows(grdCash.Rows.Count - 1).Cells(6).Value = Format(dblCurrentMovingTotal, "##0.00")
                    Exit While
                End If
                grdCash.Rows(grdCash.Rows.Count - 1).Cells(grdCash.Columns.Count - 1).Value = Format(CDbl(objReader(2).ToString) + CDbl(objReader(4).ToString), "##0.00")
            End While
        Next
        grdCash.Rows(grdCash.Rows.Count - 1).Cells(6).Value = Format(dblCurrentMovingTotal, "##0.00")
        ComputeTotals()
        AlternateColors()
        grdCash.Columns(6).DefaultCellStyle.BackColor = Color.LightGreen
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub AlternateColors()
        With grdCash
            For i As Integer = 0 To .Rows.Count - 1
                For j As Integer = 0 To .Columns.Count - 1
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

    Private Sub ComputeTotals()
        Dim dblAmount As Double = 0
        Dim dblTaxes As Double = 0
        Dim dblDiscounts As Double = 0
        For n As Integer = 0 To grdCash.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(grdCash.Rows(n).Cells(2).Value), "")) Then
                If IsNumeric(grdCash.Rows(n).Cells(2).Value.ToString) Then
                    dblAmount = dblAmount + CDbl(grdCash.Rows(n).Cells(2).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(grdCash.Rows(n).Cells(3).Value), "")) Then
                If IsNumeric(grdCash.Rows(n).Cells(3).Value.ToString) Then
                    dblDiscounts = dblDiscounts + CDbl(grdCash.Rows(n).Cells(3).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(grdCash.Rows(n).Cells(4).Value), "")) Then
                If IsNumeric(grdCash.Rows(n).Cells(4).Value.ToString) Then
                    dblTaxes = dblTaxes + CDbl(grdCash.Rows(n).Cells(4).Value.ToString)
                End If
            End If
        Next
        txtSales.Text = Format(dblAmount, "#,##0.00")
        txtDiscounts.Text = Format(dblDiscounts, "#,##0.00")
        txtTaxes.Text = Format(dblTaxes, "#,##0.00")
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintTax.Click
        On Error GoTo RaiseErr
        Dim arrPrintDetails As New ArrayList
        Dim dblAmount As Double = 0
        Dim dblDiscounts As Double = 0
        Dim dblTaxes As Double = 0

        Dim strDoc As String = Nothing
        Dim strDate As String = Nothing
        Dim strAmount As String = "0.00"
        Dim strDiscount As String = "0.00"
        Dim strTaxes As String = "0.00"
        Dim strSubTotal As String = "0.00"

        With grdCash
            For i As Integer = 0 To grdCash.Rows.Count - 1
                strDoc = Nothing
                strDate = Nothing
                strAmount = "0.00"
                strDiscount = "0.00"
                strTaxes = "0.00"
                strSubTotal = Nothing

                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "")) Then
                    strDoc = Format(CInt(Convert.ToString(.Rows(i).Cells(5).Value)), "00000")
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "")) Then
                    strDate = Convert.ToString(.Rows(i).Cells(1).Value)
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "")) Then
                    strAmount = Format(CDbl(Convert.ToString(.Rows(i).Cells(2).Value)), "##0.00")
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "")) Then
                    strDiscount = Format(CDbl(Convert.ToString(.Rows(i).Cells(3).Value)), "##0.00")
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "")) Then
                    strTaxes = Format(CDbl(Convert.ToString(.Rows(i).Cells(4).Value)), "##0.00")
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(6).Value), "")) Then
                    strSubTotal = Format(CDbl(Convert.ToString(.Rows(i).Cells(6).Value)), "##0.00")
                End If

                arrPrintDetails.Add(strDate & ";" & strDoc & ";" & strAmount & ";" & strDiscount & ";" & strTaxes & ";" & strSubTotal)

                dblAmount = dblAmount + CDbl(strAmount)
                dblDiscounts = dblDiscounts + CDbl(strDiscount)
                dblTaxes = dblTaxes + CDbl(strTaxes)

            Next
            'Add the total Line
            strAmount = CStr(Format(dblAmount, "##0.00"))
            strDiscount = CStr(Format(dblDiscounts, "##0.00"))
            strTaxes = CStr(Format(dblTaxes, "##0.00"))

        End With

        'Add the details to the print class print array

        Dim strPrintDetails(0 To (arrPrintDetails.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "DATE|INVOICE NO|AMOUNT|DISCOUNT|TAX|SUB TOTAL"
            .strColumnAlignments = "0|0|2|2|2|2"
            .strColumnWidths = "100|100|100|100|100|100"
            .strFooterCaption = "MONTHLY TAX SALES"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "MONTHLY TAX SALES ANALYSIS"
            .strMainHeader3 = "PERIOD : " & UCase(gwt_comm.shortMonthDateFormat(dpStartFromTax.Value)) & " - " & UCase(gwt_comm.shortMonthDateFormat(dpEndToTax.Value))
            .strColumnTotals = "NO|NO|YES|YES|YES|YES"
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
            .boolGroupDetails = True
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = True
            .NewPageBreak = True
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|YES|YES"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        MessageBox.Show("Report printed successfully", "Sales Details Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 13 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCommit.Click
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to proceed? Please make sure that the data has been backed up before proceeding",
                "Confirm Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [InvoiceNumber],[CustomerId],[Status],[Cash],[EcoCash],[Swipe],[Transfer]," _
                & "[Taxes],[Discount],[TransDate],[OriginalInvoice],[SalesRep],[UserName],[ContactNumber]," _
                & "[ContactName],[ServiceCategory],[ExpensesRate],[CommissionRate] FROM SalesMain WHERE " _
                & "TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartFromTax.Value) & "' AND " _
                & "'" & gwt_comm.shortMonthDateFormat(dpEndToTax.Value) & "' ORDER BY InvoiceNumber", cnn)
            Dim objReadMain As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

            objCommand = New Data.OleDb.OleDbCommand("SELECT [InvoiceNumber],[CustomerId],[ItemCode],[Description]," _
                & "[DiscountAllowed],[Taxes],[TransType],[SalesPrice],[TransDate],[ProductType],[SerialNumbers]," _
                & "[OriginalInvoice],[SalesRep],[UserName],[Quantity],[CostPrice],[ExpensesRate],[ServiceCategory]," _
                & "[CommissionRate],[SourceSerialNo] FROM Sales WHERE TransDate Between '" & gwt_comm.shortMonthDateFormat(dpStartFromTax.Value) & "' " _
                & "AND '" & gwt_comm.shortMonthDateFormat(dpEndToTax.Value) & "' ORDER BY InvoiceNumber", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

            objCommand = New Data.OleDb.OleDbCommand("SELECT [TransactionDate],[Amount],[Description],[AccountNumber]," _
                & "[ContraAccount],[UserName],[UserBranch],[Reference],[TransactionType],[Status]," _
                & "[PaymentMethod],[FolioReference],[VatAmount] FROM CashbookTransactions WHERE TransactionDate " _
                & "BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartFromTax.Value) & "' AND " _
                & "'" & gwt_comm.shortMonthDateFormat(dpEndToTax.Value) & "' ORDER BY TransactionId", cnn)
            Dim objReadCashbook As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

            Dim arrMainSales As New ArrayList
            Dim arrSalesDetails As New ArrayList
            Dim arrCashbookTransactions As New ArrayList

            While objReadMain.Read
                arrMainSales.Add(objReadMain(0) & "|" & objReadMain(1) & "|" & objReadMain(2) & "|" & objReadMain(3) &
                    "|" & objReadMain(4) & "|" & objReadMain(5) & "|" & objReadMain(6) & "|" & objReadMain(7) & "|" & objReadMain(8) &
                    "|" & objReadMain(9) & "|" & objReadMain(10) & "|" & objReadMain(11) & "|" & objReadMain(12) & "|" & objReadMain(13) &
                    "|" & objReadMain(14) & "|" & objReadMain(15) & "|" & objReadMain(16) & "|" & objReadMain(17))
            End While
            objReadMain.Close()

            While objReader.Read
                arrSalesDetails.Add(objReader(0) & "|" & objReader(1) & "|" & objReader(2) & "|" & objReader(3) &
                    "|" & objReader(4) & "|" & objReader(5) & "|" & objReader(6) & "|" & objReader(7) & "|" & objReader(8) &
                    "|" & objReader(9) & "|" & objReader(10) & "|" & objReader(11) & "|" & objReader(12) & "|" & objReader(13) &
                    "|" & objReader(14) & "|" & objReader(15) & "|" & objReader(16) & "|" & objReader(17) & "|" & objReader(18) & "|" & objReader(19))
            End While
            objReader.Close()

            While objReadCashbook.Read
                arrCashbookTransactions.Add(objReadCashbook(0) & "|" & objReadCashbook(1) & "|" & objReadCashbook(2) & "|" & objReadCashbook(3) &
                    "|" & objReadCashbook(4) & "|" & objReadCashbook(5) & "|" & objReadCashbook(6) & "|" & objReadCashbook(7) & "|" & objReadCashbook(8) &
                    "|" & objReadCashbook(9) & "|" & objReadCashbook(10) & "|" & objReadCashbook(11) & "|" & objReadCashbook(12))
            End While
            objReadCashbook.Close()

            'Drop the records before recommitting them
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Sales WHERE TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(dpStartFromTax.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpEndToTax.Value) & "' " _
                & "AND TaxStatus = 'VARIABLE'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SalesMain WHERE TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(dpStartFromTax.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpEndToTax.Value) & "' " _
                & "AND TaxStatus = 'VARIABLE'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CashbookTransactions WHERE TransactionDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(dpStartFromTax.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpEndToTax.Value) & "' " _
                & "AND Description LIKE 'CASH SALE%'", cnn)
            objCommand.ExecuteNonQuery()

            pb1.Value = 0 : pb1.Maximum = grdCash.RowCount
            For p As Integer = 0 To arrMainSales.Count - 1
                Dim strBuffer() As String = Split(arrMainSales.Item(p), "|")
                For i As Integer = 0 To grdCash.RowCount - 1
                    If Not Object.Equals(Convert.ToString(grdCash.Rows(i).Cells(0).Value), "") Then
                        If IsNumeric(grdCash.Rows(i).Cells(0).Value.ToString) Then
                            If CDbl(strBuffer(0)) = CDbl(grdCash.Rows(i).Cells(0).Value.ToString) Then
                                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SalesMain ([InvoiceNumber],[CustomerId],[Status],[Cash],[EcoCash],[Swipe],[Transfer]," _
                                    & "[Taxes],[Discount],[TransDate],[OriginalInvoice],[SalesRep],[UserName],[ContactNumber]," _
                                    & "[ContactName],[ServiceCategory],[ExpensesRate],[CommissionRate]) VALUES (" & CLng(grdCash.Rows(i).Cells(0).Value.ToString) & ", " _
                                    & "'" & strBuffer(1) & "', '" & strBuffer(2) & "', " _
                                    & "" & strBuffer(3) & ", " & strBuffer(4) & ", " _
                                    & "" & strBuffer(5) & ", " & strBuffer(6) & ", " & strBuffer(7) & ", " _
                                    & "" & strBuffer(8) & ", '" & strBuffer(9) & "', " _
                                    & "" & strBuffer(10) & ", '" & strBuffer(11) & "', " _
                                    & "'" & strBuffer(12) & "', '" & strBuffer(13) & "', " _
                                    & "'" & strBuffer(14) & "', '" & strBuffer(15) & "', " _
                                    & "" & strBuffer(16) & ", " & strBuffer(17) & ")", cnn)
                                objCommand.ExecuteNonQuery()
                                Exit For
                            End If
                        End If
                    End If
                    pb1.Value = pb1.Value + 1
                Next
            Next

            'Add the transactions back to the cashbook
            pb1.Value = 0 : pb1.Maximum = grdCash.Rows.Count - 1
            For i As Integer = 0 To grdCash.RowCount - 1
                If Not Object.Equals(Convert.ToString(grdCash.Rows(i).Cells(0).Value), "") Then
                    If IsNumeric(grdCash.Rows(i).Cells(0).Value.ToString) Then
                        For p As Integer = 0 To arrCashbookTransactions.Count - 1
                            Dim strBuffer() As String = Split(arrCashbookTransactions.Item(p), "|")
                            If CDbl(strBuffer(7)) = CDbl(grdCash.Rows(i).Cells(0).Value.ToString) Then
                                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions ([TransactionDate],[Amount],[Description]," _
                                    & "[AccountNumber],[ContraAccount],[UserName],[UserBranch],[Reference],[TransactionType]," _
                                    & "[Status],[PaymentMethod],[FolioReference],[VatAmount]) VALUES ('" & strBuffer(0) & "', " _
                                    & "" & strBuffer(1) & ", '" & strBuffer(2) & "', '" & strBuffer(3) & "', '" & strBuffer(4) & "', " _
                                    & "'" & strBuffer(5) & "', '" & strBuffer(6) & "', " & strBuffer(7) & ", '" & strBuffer(8) & "', " _
                                    & "'" & strBuffer(9) & "', '" & strBuffer(10) & "', '" & strBuffer(11) & "', " & strBuffer(12) & ")", cnn)
                                objCommand.ExecuteNonQuery()
                                Exit For
                            End If
                        Next
                    End If
                End If
                pb1.Value = pb1.Value + 1
            Next

            pb1.Value = 0 : pb1.Maximum = grdCash.RowCount
            For p As Integer = 0 To arrSalesDetails.Count - 1
                Dim strBuffer() As String = Split(arrSalesDetails.Item(p), "|")
                For i As Integer = 0 To grdCash.RowCount - 1
                    If Not Object.Equals(Convert.ToString(grdCash.Rows(i).Cells(0).Value), "") Then
                        If IsNumeric(grdCash.Rows(i).Cells(0).Value.ToString) Then
                            If CDbl(strBuffer(0)) = CDbl(grdCash.Rows(i).Cells(0).Value.ToString) Then
                                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO Sales ([InvoiceNumber],[CustomerId],[ItemCode],[Description]," _
                                    & "[DiscountAllowed],[Taxes],[TransType],[SalesPrice],[TransDate],[ProductType],[SerialNumbers]," _
                                    & "[OriginalInvoice],[SalesRep],[UserName],[Quantity],[CostPrice],[ExpensesRate],[ServiceCategory]," _
                                    & "[CommissionRate],[SourceSerialNo]) VALUES (" & CLng(grdCash.Rows(i).Cells(0).Value.ToString) & ", " _
                                    & "'" & strBuffer(1) & "', '" & strBuffer(2) & "', " _
                                    & "'" & strBuffer(3) & "', " & strBuffer(4) & ", " _
                                    & "" & strBuffer(5) & ", '" & strBuffer(6) & "', " _
                                    & "" & strBuffer(7) & ", '" & strBuffer(8) & "', " _
                                    & "'" & strBuffer(9) & "', '" & strBuffer(10) & "', " _
                                    & "" & strBuffer(11) & ", '" & strBuffer(12) & "', " _
                                    & "'" & strBuffer(13) & "', " & strBuffer(14) & ", " _
                                    & "" & strBuffer(15) & ", " & strBuffer(16) & ", " _
                                    & "'" & strBuffer(17) & "', " & strBuffer(18) & ", " _
                                    & "'" & strBuffer(19) & "')", cnn)
                                objCommand.ExecuteNonQuery()
                                Exit For
                            End If
                        End If
                    End If
                    pb1.Value = pb1.Value + 1
                Next
            Next
        End If
        Cursor = Cursors.Default
        MessageBox.Show("Transactions committed successfully", "Tax Sales Synchronization", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Tax results commit"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadFixedSales()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        dGridTransfers.Rows.Clear()

        Dim lngInvoiceNumber As Long = CLng(txtInvoiceNumber.Text)
        Dim dblCurrentMovingTotal As Double = 0

        Dim strSql As String = Nothing
        strSql = "SELECT InvoiceNumber AS [Inv. #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "CAST((EcoCash) + (Swipe) + (Transfer) AS DECIMAL (10,2)) AS [Amount], " _
            & "CAST(Discount AS DECIMAL(10,2)) AS [Discounts], CAST(Taxes AS DECIMAL (10,2)) AS [Vat] FROM SalesMain " _
            & "WHERE TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartFromTax.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpEndToTax.Value) & "' " _
            & "ORDER BY InvoiceNumber, TransDate"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dblCurrentMovingTotal = 0

        While objReader.Read
            dGridTransfers.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridTransfers.Rows(dGridTransfers.Rows.Count - 1).Cells(0).Value = Format(CInt(objReader(0).ToString), "000000")
            If Not IsDBNull(objReader(1).ToString) Then dGridTransfers.Rows(dGridTransfers.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGridTransfers.Rows(dGridTransfers.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dGridTransfers.Rows(dGridTransfers.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then dGridTransfers.Rows(dGridTransfers.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
            dGridTransfers.Rows(dGridTransfers.Rows.Count - 1).Cells(5).Value = lngInvoiceNumber
            'dblCurrentMovingTotal = dblCurrentMovingTotal + CDbl(objReader(2).ToString)
            lngInvoiceNumber = lngInvoiceNumber + 1

            dGridTransfers.Rows(dGridTransfers.Rows.Count - 1).Cells(dGridTransfers.Columns.Count - 1).Value = Format(CDbl(objReader(2).ToString) + CDbl(objReader(4).ToString), "##0.00")
        End While
        'Next

        If dGridTransfers.RowCount > 0 Then
            dGridTransfers.Rows(dGridTransfers.Rows.Count - 1).Cells(6).Value = Format(dblCurrentMovingTotal, "##0.00")
        End If

        ''Display the totals after vat

        AlternateColors()
        dGridTransfers.Columns(7).DefaultCellStyle.BackColor = Color.LightGreen

        With dGridTransfers
            Dim dblAmt As Double = 0
            Dim dblTax As Double = 0
            Dim dblTotal As Double = 0
            For i As Integer = 0 To .Rows.Count - 1
                If Not Object.Equals(.Rows(i).Cells(2).Value, Nothing) Then
                    If IsNumeric(.Rows(i).Cells(2).Value.ToString) Then
                        dblAmt = dblAmt + CDbl(.Rows(i).Cells(2).Value.ToString)
                    End If
                    If IsNumeric(.Rows(i).Cells(4).Value.ToString) Then
                        dblTax = dblTax + CDbl(.Rows(i).Cells(4).Value.ToString)
                    End If
                    If IsNumeric(.Rows(i).Cells(7).Value.ToString) Then
                        dblTotal = dblTotal + CDbl(.Rows(i).Cells(7).Value.ToString)
                    End If
                End If
            Next
            .Rows.Add("", "", Format(dblAmt, "##0.00"), "0.00", Format(dblTax, "##0.00"), "", "", Format(dblTotal, "##0.00"))
        End With
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On transfer sales analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAlign_Click(sender As System.Object, e As System.EventArgs) Handles btnAlign.Click
        Dim frm As New frmResetReceiptNumbers
        frm.ShowDialog()
    End Sub

    Private Sub mnuSplitPayments_Click(sender As Object, e As EventArgs) Handles mnuSplitPayments.Click

    End Sub

    Private Sub mnuFlagReceipt_Click(sender As System.Object, e As System.EventArgs) Handles mnuFlagReceipt.Click
        If dGridAllData.RowCount <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Dim intInvoice As Integer = CInt(dGridAllData.CurrentRow.Cells(0).Value.ToString)
        Dim strFlag As String = "Y"
        If Not Object.Equals(dGridAllData.CurrentRow.Cells(dGridAllData.ColumnCount - 1).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridAllData.CurrentRow.Cells(dGridAllData.ColumnCount - 1).Value.ToString) Then
                strFlag = dGridAllData.CurrentRow.Cells(dGridAllData.ColumnCount - 1).Value.ToString
                If strFlag = "Y" Then strFlag = "N" Else strFlag = "Y"
            End If
        End If

        Dim strSql As String = "UPDATE SalesMain SET Flag = '" & strFlag & "' WHERE InvoiceNumber = " & intInvoice & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        dGridAllData.CurrentRow.Cells(dGridAllData.ColumnCount - 1).Value = strFlag

        Cursor = Cursors.Default

        MessageBox.Show("Transaction has been flagged", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Receipt Flagging"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSpecialDataTransfer_Click(sender As System.Object, e As System.EventArgs) Handles btnSpecialDataTransfer.Click
        On Error GoTo RaiseErr

        boolAbort = False
        Dim frm As New frmExternalDbConnection
        frm.showdialog()
        If boolAbort = True Then Exit Sub

        Cursor = Cursors.WaitCursor

        'Get the main sales table details
        Dim strSql As String = Nothing
        strSql = gwt_comm.ScriptTableFields("SalesMain", "SELECT")
        strSql = strSql & " WHERE Flag = 'Y'"

        strSql = gwt_comm.ScriptDataInsertStatement(strSql, "SalesMain")

        Dim strSales As String = gwt_comm.ScriptTableFields("Sales", "SELECT")
        strSales = strSales & " WHERE InvoiceNumber IN (SELECT InvoiceNumber FROM SalesMain WHERE Flag = 'Y')"
        Dim MySales As String = gwt_comm.ScriptDataInsertStatement(strSales, "Sales")

        strSql = strSql & MySales

        Dim strExternalConnection As String = "data source=" & eServerName & ";initial catalog=" & _
            eDatabase & ";User ID=" & eUserName & ";Password=" & ePassword & ";provider=SQLOLEDB"
        
        Dim exConn As New Data.OleDb.OleDbConnection(strExternalConnection)
        exConn.Open()

        Dim objCommand As Data.OleDb.OleDbCommand
        If MessageBox.Show("Do you want to empty the tables before adding these records?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SalesMain", exConn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Sales", exConn)
            objCommand.ExecuteNonQuery()
        End If

        Dim strInsertStatements() As String = Split(strSql, vbCrLf)

        With ProgressBar1
            .Value = 0
            .Maximum = strInsertStatements.Length
        End With

        For p As Integer = 0 To strInsertStatements.Length - 1
            If Not String.IsNullOrEmpty(strInsertStatements(p)) Then
                objCommand = New Data.OleDb.OleDbCommand(strInsertStatements(p), exConn)
                objCommand.ExecuteNonQuery()
            End If
            ProgressBar1.Value = ProgressBar1.Value + 1
        Next
        exConn.Close()

        'Delete the flagged receords from the active database
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Sales WHERE InvoiceNumber IN (SELECT InvoiceNumber FROM SalesMain WHERE Flag = 'Y')", cnn)
        objCommand.ExecuteNonQuery()

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SalesMain WHERE Flag = 'Y'", cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Data Transfer"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
