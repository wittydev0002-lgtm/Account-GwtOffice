Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMonthlyAccounts


    Dim arrCostOfSales() As String

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        boolAbort = False : Cursor = Cursors.WaitCursor
        PreFormatGrid()
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If
        LoadSales()
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If
        LoadCostOfSales()
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If
        LoadExpenses()
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If
        ComputeProfit()
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If
        GridTotals()
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadSales()
        On Error GoTo RaiseErr
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                Dim dblSales As Double = 0
                Dim strDate As String = dGrid.Rows(i).Cells(0).Value.ToString
                Dim strSql As String = "Select CONVERT(NVARCHAR, TransDate, 105) AS [Date], CAST((Sum(Amount + 0)) " _
                    & "AS DECIMAL (10,2)) AS [Sales] FROM SalesMain WHERE TransDate Between " _
                    & "'" & strDate & "' AND '" & strDate & "' GROUP BY TransDate ORDER BY TransDate"
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

                While objReader.Read
                    With dGrid
                        If IsNumeric(objReader(1).ToString) Then
                            dblSales = dblSales + CDbl(objReader(1).ToString)
                        End If
                    End With
                End While
                objReader.Close()
                dGrid.Rows(i).Cells(1).Value = Format(dblSales, "##0.00")
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Sales Daily Analysis Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCostOfSales()
        On Error GoTo RaiseErr
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                Dim dblSalesCost As Double = 0
                Dim strDate As String = dGrid.Rows(i).Cells(0).Value.ToString
                Dim strSql As String = "select Sales.InvoiceNumber, Sales.itemcode, Sales.Quantity, " _
                    & "Sales.CostPrice, (Sales.Quantity * Sales.CostPrice ) as [Cost], " _
                    & "((Sales.SalesPrice * Sales.Quantity) - Sales.DiscountAllowed ) as [Sales], " _
                    & "((Sales.SalesPrice * Sales.Quantity) - (Sales.Quantity * Sales.CostPrice)) " _
                    & "AS [GrossProfit], Sales.TransDate FROM Sales WHERE Sales.TransDate " _
                    & "BETWEEN '" & strDate & "' AND '" & strDate & "'"
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

                While objReader.Read
                    With dGrid
                        If IsNumeric(objReader(4).ToString) Then
                            dblSalesCost = dblSalesCost + CDbl(objReader(4).ToString)
                        End If
                    End With
                End While
                objReader.Close()
                dGrid.Rows(i).Cells(2).Value = Format(dblSalesCost, "##0.00")
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Sales Daily Cost Of Sales Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadExpenses()
        On Error GoTo RaiseErr
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                Dim dblExpenses As Double = 0
                Dim strDate As String = dGrid.Rows(i).Cells(0).Value.ToString
                Dim strSql As String = "Select CONVERT(NVARCHAR, TransactionDate, 105) AS [Date], " _
                    & "CAST((Sum(Amount)) AS DECIMAL (10,2)) AS [Expenses] FROM CashbookTransactions " _
                    & "WHERE TransactionDate Between '" & strDate & "' AND '" & strDate & "'  AND " _
                    & "TransactionType = 'CREDIT' GROUP BY TransactionDate ORDER BY TransactionDate"
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

                While objReader.Read
                    With dGrid
                        If IsNumeric(objReader(1).ToString) Then
                            dblExpenses = dblExpenses + CDbl(objReader(1).ToString)
                        End If
                    End With
                End While
                objReader.Close()
                dGrid.Rows(i).Cells(4).Value = Format(dblExpenses, "##0.00")
                objReader.Close()
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Sales Operating Expenses Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub PreFormatGrid()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim intDatesCount As Integer = DateDiff(DateInterval.Day, dpStartFrom.Value, dpEndTo.Value) + 1
        dGrid.Rows.Add(intDatesCount)

        ReDim arrCostOfSales(0 To (intDatesCount - 1))

        For i = 1 To intDatesCount
            If i = 1 Then
                dGrid.Rows(i - 1).Cells(0).Value = Format(dpStartFrom.Value, "dd-MMM-yyyy")
            Else
                Dim dtNextDate As Date = DateAdd(DateInterval.Day, (i - 1), dpStartFrom.Value)
                dGrid.Rows(i - 1).Cells(0).Value = Format(dtNextDate, "dd-MMM-yyyy")
            End If
            dGrid.Rows(i - 1).Cells(1).Value = "0.00"
            dGrid.Rows(i - 1).Cells(2).Value = "0.00"
            dGrid.Rows(i - 1).Cells(3).Value = "0.00"
            dGrid.Rows(i - 1).Cells(4).Value = "0.00"
            dGrid.Rows(i - 1).Cells(5).Value = "0.00"
            dGrid.Rows(i - 1).Cells(6).Value = "0.00"
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Grid Preformatting Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeProfit()
        On Error GoTo RaiseErr
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblTotalExpenses As Double = 0
            Dim dblTotalSalesMade As Double = 0
            Dim dblTotalCOS As Double = 0
            Dim dblProfitMade As Double = 0
            Dim dblAllExpenses As Double = 0
            Dim dblGrossProfit As Double = 0
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(1).Value.ToString) Then
                    dblTotalSalesMade = CDbl(dGrid.Rows(i).Cells(1).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    dblTotalCOS = CDbl(dGrid.Rows(i).Cells(2).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                    dblTotalExpenses = CDbl(dGrid.Rows(i).Cells(4).Value.ToString)
                End If
            End If
            dblAllExpenses = dblTotalCOS + dblTotalExpenses
            dblProfitMade = dblTotalSalesMade - dblAllExpenses
            dblGrossProfit = dblTotalSalesMade - dblTotalCOS
            dGrid.Rows(i).Cells(3).Value = Format(dblGrossProfit, "##0.00")
            dGrid.Rows(i).Cells(5).Value = Format(dblAllExpenses, "##0.00")
            dGrid.Rows(i).Cells(6).Value = Format(dblProfitMade, "##0.00")
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Profit Computation Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GridTotals()
        On Error GoTo RaiseErr
        Dim dblSalesCol As Double = 0
        Dim dblSalesCostCol As Double = 0
        Dim dblExpensesCol As Double = 0
        Dim dblTotalExpensesCol As Double = 0
        Dim dblTotalProfit As Double = 0
        Dim dblGrossProfit As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(1).Value.ToString) Then
                    dblSalesCol = dblSalesCol + CDbl(dGrid.Rows(i).Cells(1).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    dblSalesCostCol = dblSalesCostCol + CDbl(dGrid.Rows(i).Cells(2).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    dblGrossProfit = dblGrossProfit + CDbl(dGrid.Rows(i).Cells(3).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                    dblExpensesCol = dblExpensesCol + CDbl(dGrid.Rows(i).Cells(4).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                    dblTotalExpensesCol = dblTotalExpensesCol + CDbl(dGrid.Rows(i).Cells(5).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(6).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(6).Value.ToString) Then
                    dblTotalProfit = dblTotalProfit + CDbl(dGrid.Rows(i).Cells(6).Value.ToString)
                End If
            End If
        Next
        dGrid.Rows.Add(1)
        With dGrid
            .Rows(.Rows.Count - 1).Cells(0).Value = "TOTAL"
            .Rows(.Rows.Count - 1).Cells(1).Value = dblSalesCol
            .Rows(.Rows.Count - 1).Cells(2).Value = dblSalesCostCol
            .Rows(.Rows.Count - 1).Cells(3).Value = dblGrossProfit
            .Rows(.Rows.Count - 1).Cells(4).Value = dblExpensesCol
            .Rows(.Rows.Count - 1).Cells(5).Value = dblTotalExpensesCol
            .Rows(.Rows.Count - 1).Cells(6).Value = dblTotalProfit
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Profit Computation Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
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
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 7
            .strColumnHeaders = "DATE|SALES|ORDER COSTS|GROSS PROFIT|EXPENSES|TOTAL COST|NET PROFIT"
            .strColumnAlignments = "0|2|2|2|2|2|2"
            .strColumnWidths = "80|80|90|90|90|90|90"
            .strFooterCaption = "Income Statement"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "PERIODIC INCOME STATEMENT - " & UCase(strUserBranch)
            .strMainHeader3 = "PERIOD FROM " & UCase(Format(dpStartFrom.Value, "dd-MMM-yyyy")) & " TO " & UCase(Format(dpEndTo.Value, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|YES|YES|YES|YES|YES|YES"
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
            .boolPrintTotals = True
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|YES|YES|YES|YES|YES|YES"
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
        strErrorMessages = Err.Description & " on error number " & Err.Number & vbCrLf & "On Current Stocks Sales Expectations"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class