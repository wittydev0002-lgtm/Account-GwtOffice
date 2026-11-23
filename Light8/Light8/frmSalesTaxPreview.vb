Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSalesTaxPreview

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
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
        boolAbort = False
        LoadTaxSalesDetails()
        If boolAbort = True Then Exit Sub
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
            strSql = "Select InvoiceNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                & "CAST(Amount AS DECIMAL (30,2)) AS [Amount], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                & "CAST(Taxes AS DECIMAL (30,2)) AS [Vat] from SalesMain WHERE TransDate BETWEEN " _
                & "'" & StartDate & "' AND '" & EndDate & "' AND TaxStatus = 'VARIABLE' order by InvoiceNumber, TransDate"

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

        If grdCash.RowCount > 0 Then
            grdCash.Rows(grdCash.Rows.Count - 1).Cells(6).Value = Format(dblCurrentMovingTotal, "##0.00")
        End If

        ''Display the totals after vat
        'With grd
        '    For i As Integer = 0 To grd.RowCount - 1
        '        Dim dblAmtBvat As Double = 0
        '        Dim dblAmtVat As Double = 0
        '        If Not Object.Equals(.Rows(i).Cells(2).Value, Nothing) Then
        '            If IsNumeric(.Rows(i).Cells(2).Value.ToString) Then
        '                dblAmtBvat = CDbl(.Rows(i).Cells(2).Value.ToString)
        '            End If
        '        End If
        '        If Not Object.Equals(.Rows(i).Cells(4).Value, Nothing) Then
        '            If IsNumeric(.Rows(i).Cells(4).Value.ToString) Then
        '                dblAmtVat = CDbl(.Rows(i).Cells(4).Value.ToString)
        '            End If
        '        End If
        '        grd.Rows(i).Cells(.Columns.Count - 1).Value = Format(dblAmtBvat + dblAmtVat, "##0.00")
        '        grd.Columns(.Columns.Count - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '        grd.Columns(.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        '    Next
        'End With

        ComputeTotals()
        AlternateColors()
        grdCash.Columns(6).DefaultCellStyle.BackColor = Color.LightGreen
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        ShowErrorMessage()
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
        ShowErrorMessage()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 13 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnCommit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCommit.Click
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to proceed? Please make sure that the data has been backed up before proceeding", _
                "Confirm Process", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [InvoiceNumber],[CustomerId],[Status],[Amount]," _
                & "[Taxes],[Discount],[TransDate],[OriginalInvoice],[SalesRep],[UserName],[ContactNumber]," _
                & "[ContactName],[ServiceCategory],[ExpensesRate],[CommissionRate] FROM SalesMain WHERE " _
                & "TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartFromTax.Value) & "' AND " _
                & "'" & gwt_comm.shortMonthDateFormat(dpEndToTax.Value) & "' ORDER BY InvoiceNumber", cnn)
            Dim objReadMain As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

            objCommand = New Data.OleDb.OleDbCommand("SELECT [InvoiceNumber],[CustomerId],[ItemCode],[Description]," _
                & "[DiscountAllowed],[Taxes],[TransType],[SalesPrice],[TransDate],[ProductType],[SerialNumbers]," _
                & "[OriginalInvoice],[SalesRep],[UserName],[Quantity],[CostPrice],[ExpensesRate],[ServiceCategory]," _
                & "[CommissionRate],[SourceSerialNo] FROM Sales WHERE TransDate Between '" & shortMonthDateFormat(CDate(dpStartFromTax.Value)) & "' " _
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
                arrMainSales.Add(objReadMain(0) & "|" & objReadMain(1) & "|" & objReadMain(2) & "|" & objReadMain(3) & _
                    "|" & objReadMain(4) & "|" & objReadMain(5) & "|" & objReadMain(6) & "|" & objReadMain(7) & "|" & objReadMain(8) & _
                    "|" & objReadMain(9) & "|" & objReadMain(10) & "|" & objReadMain(11) & "|" & objReadMain(12) & "|" & objReadMain(13) & _
                    "|" & objReadMain(14))
            End While
            objReadMain.Close()

            While objReader.Read
                arrSalesDetails.Add(objReader(0) & "|" & objReader(1) & "|" & objReader(2) & "|" & objReader(3) & _
                    "|" & objReader(4) & "|" & objReader(5) & "|" & objReader(6) & "|" & objReader(7) & "|" & objReader(8) & _
                    "|" & objReader(9) & "|" & objReader(10) & "|" & objReader(11) & "|" & objReader(12) & "|" & objReader(13) & _
                    "|" & objReader(14) & "|" & objReader(15) & "|" & objReader(16) & "|" & objReader(17) & "|" & objReader(18) & "|" & objReader(19))
            End While
            objReader.Close()

            While objReadCashbook.Read
                arrCashbookTransactions.Add(objReadCashbook(0) & "|" & objReadCashbook(1) & "|" & objReadCashbook(2) & "|" & objReadCashbook(3) & _
                    "|" & objReadCashbook(4) & "|" & objReadCashbook(5) & "|" & objReadCashbook(6) & "|" & objReadCashbook(7) & "|" & objReadCashbook(8) & _
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
                                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SalesMain ([InvoiceNumber],[CustomerId],[Status],[Amount]," _
                                    & "[Taxes],[Discount],[TransDate],[OriginalInvoice],[SalesRep],[UserName],[ContactNumber]," _
                                    & "[ContactName],[ServiceCategory],[ExpensesRate],[CommissionRate]) VALUES (" & CLng(grdCash.Rows(i).Cells(0).Value.ToString) & ", " _
                                    & "'" & strBuffer(1) & "', '" & strBuffer(2) & "', " _
                                    & "" & strBuffer(3) & ", " & strBuffer(4) & ", " _
                                    & "" & strBuffer(5) & ", '" & strBuffer(6) & "', " _
                                    & "" & strBuffer(7) & ", '" & strBuffer(8) & "', " _
                                    & "'" & strBuffer(9) & "', '" & strBuffer(10) & "', " _
                                    & "'" & strBuffer(11) & "', '" & strBuffer(12) & "', " _
                                    & "" & strBuffer(13) & ", " & strBuffer(14) & ")", cnn)
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
        ShowErrorMessage()
    End Sub

    Private Sub LoadFixedSales()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        dGridTransfers.Rows.Clear()

        'Compute the daily average based on the desired amount
        'Dim intDays As Integer = (DateDiff(DateInterval.Day, dpStartFrom.Value, dpEndTo.Value) + 1)
        'Dim intFinalDaysCount As Integer = 0
        'For n As Integer = 0 To intDays - 1
        '    Dim evalDate As Date = DateAdd(DateInterval.Day, n, CDate(Format(dpStartFrom.Value, "dd-MMM-yyyy")))
        '    If evalDate.DayOfWeek = DayOfWeek.Sunday Or evalDate.DayOfWeek = DayOfWeek.Sunday Then
        '        intFinalDaysCount = intDays - 1
        '    End If
        'Next
        Dim lngInvoiceNumber As Long = CLng(txtInvoiceNumber.Text)
        'Dim dblDailyAverage As Double = Math.Round((CDbl(txtAmount.Text) / intFinalDaysCount), 2)
        Dim dblCurrentMovingTotal As Double = 0

        'For intRuns As Integer = 0 To intDays - 1
        '    StartDate = DateAdd(DateInterval.Day, intRuns, CDate(Format(dpStartFrom.Value, "dd-MMM-yyyy")))
        '    EndDate = StartDate

        Dim strSql As String = Nothing
        strSql = "Select InvoiceNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "CAST(Amount AS DECIMAL (30,2)) AS [Amount], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
            & "CAST(Taxes AS DECIMAL (30,2)) AS [Vat] from SalesMain WHERE TransDate BETWEEN " _
            & "'" & gwt_comm.shortMonthDateFormat(dpStartFromTax.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpEndToTax.Value) & "' " _
            & "AND (PaymentMethod = 'Ecocash' or PaymentMethod = 'SWIPE' or PaymentMethod = 'Transfer') " _
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
        ShowErrorMessage()
    End Sub

End Class
