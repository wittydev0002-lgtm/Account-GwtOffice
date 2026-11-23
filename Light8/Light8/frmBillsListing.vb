Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBillsListing

    Private Sub LoadDataByDate(ByVal StartingDate As Date, ByVal EndingDate As Date)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT BillEntries.BatchNumber, CONVERT(NVARCHAR, BillEntries.TransDate, 105) AS [Date], " _
            & "LedgerAccounts.AccountName, BillEntries.LedgerAccount, Suppliers.AccountName, BillEntries.SupplierAccount, " _
            & "BillEntries.Description, BillEntries.Quantity, BillEntries.Amount, (BillEntries.Amount * BillEntries.Quantity) " _
            & "AS [Payable], BillEntries.TransactionId, BillEntries.Status FROM BillEntries LEFT OUTER JOIN LedgerAccounts ON " _
            & "BillEntries.LedgerAccount = LedgerAccounts.AccountNumber LEFT OUTER JOIN Suppliers ON " _
            & "BillEntries.SupplierAccount = Suppliers.AccountNumber  " _
            & "WHERE TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(StartingDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndingDate) & "' " _
            & "ORDER BY BillEntries.TransactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5), objReader(6),
                objReader(7), objReader(8), objReader(9), objReader(10), objReader(11))
        End While
        objReader.Close()
        'AlternateColors()
        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Bill entries data load by date failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadDataByBatchNumber(ByVal StartBatchNumber As Integer, ByVal EndBatchNumber As Integer)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT BillEntries.BatchNumber, CONVERT(NVARCHAR, BillEntries.TransDate, 105) AS [Date], " _
            & "LedgerAccounts.AccountName, BillEntries.LedgerAccount, Suppliers.AccountName, BillEntries.SupplierAccount, " _
            & "BillEntries.Description, BillEntries.Quantity, BillEntries.Amount, (BillEntries.Amount * BillEntries.Quantity) " _
            & "AS [Payable], BillEntries.TransactionId, BillEntries.Status FROM BillEntries LEFT OUTER JOIN LedgerAccounts ON " _
            & "BillEntries.LedgerAccount = LedgerAccounts.AccountNumber LEFT OUTER JOIN Suppliers ON " _
            & "BillEntries.SupplierAccount = Suppliers.AccountNumber  " _
            & "WHERE BillEntries.BatchNumber BETWEEN " & StartBatchNumber & " AND " & EndBatchNumber & " " _
            & "ORDER BY BillEntries.TransactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5), objReader(6),
                objReader(7), objReader(8), objReader(9), objReader(10), objReader(11))
        End While
        objReader.Close()
        'AlternateColors()
        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Bill entries data load by batch number failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnProcessBatchSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessBatchSearch.Click
        If Not IsNumeric(txtBatchNumberFrom.Text) Or Not IsNumeric(txtBatchNumberTo.Text) Then
            MessageBox.Show("Either the start or end batch number is not numeric. Please enter valid range",
                "Invalid Batch Range", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        LoadDataByBatchNumber(CInt(txtBatchNumberFrom.Text), CInt(txtBatchNumberTo.Text))
    End Sub

    Private Sub btnProcessDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcessDate.Click
        LoadDataByDate(CDate(gwt_comm.shortMonthDateFormat(dpStartDate.Value)), CDate(gwt_comm.shortMonthDateFormat(dpEndDate.Value)))
    End Sub

    Private Sub frmBillsListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDataByDate(CDate(gwt_comm.shortMonthDateFormat(dpStartDate.Value)), CDate(gwt_comm.shortMonthDateFormat(dpEndDate.Value)))
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDataByDate(CDate(gwt_comm.shortMonthDateFormat(dpStartDate.Value)), CDate(gwt_comm.shortMonthDateFormat(dpEndDate.Value)))
    End Sub


    Private Sub ReverseTransaction(ByVal strCreditorAccount As String, ByVal dblQuantity As Double,
            ByVal dblAmount As Double, ByVal strLedgerAccount As String, ByVal BatchNumber As Integer,
            ByVal TransDate As Date, ByVal strDescription As String, ByVal TransactionId As Integer)
        On Error GoTo RaiseErr
        'Post the transaction to the bill entries account
        Dim strSql As String = "INSERT INTO BillEntries ([LedgerAccount],[SupplierAccount],[Quantity],[Amount], " _
            & "[BatchNumber],[TransDate],[UserName],[BranchName],[ChangeDate],[Description],[STATUS]) VALUES ('" & strLedgerAccount & "', " _
            & "'" & strCreditorAccount & "', " & dblQuantity & ", " & (0 - dblAmount) & ", " & BatchNumber & ", " _
            & "'" & gwt_comm.shortMonthDateFormat(TransDate) & "', '" & strUserName & "', '" & strUserBranch & "', " _
            & "'" & Now & "', '" & strDescription & "', 'INACTIVE')"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "UPDATE BillEntries SET Status = 'INACTIVE' WHERE TransactionId = " & TransactionId & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Post the transaction to the relevant ledger account
        If Not String.IsNullOrEmpty(strPublicCreditorsAccount) Then
            strSql = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
            & "[Description],[UserName],[UserBranch],[FolioReference]) VALUES " _
            & "('" & strLedgerAccount & "', '" & gwt_comm.shortMonthDateFormat(TransDate) & "', " & dblAmount & ", " _
            & "'CREDIT', '" & strPublicCreditorsAccount & "', '" & strDescription & "', '" & strUserName & "', " _
            & "'" & strUserBranch & "', 'BB" & CStr(BatchNumber) & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        'Post the transaction to the relevant ledger creditors control account
        If Not String.IsNullOrEmpty(strPublicCreditorsAccount) Then
            strSql = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
            & "[Description],[UserName],[UserBranch],[FolioReference]) VALUES " _
            & "('" & strPublicCreditorsAccount & "', '" & gwt_comm.shortMonthDateFormat(TransDate) & "', " & dblAmount & ", " _
            & "'DEBIT', '" & strLedgerAccount & "', '" & strDescription & "', '" & strUserName & "', " _
            & "'" & strUserBranch & "', 'BB" & CStr(BatchNumber) & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        'Post the transaction to creditors transactions
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SupplierTransactions " _
            & "([AccountNumber],[TransactionDate],[Amount],[TransactionType],[Description]," _
            & "[ReferenceNumber],[UserName],[BranchName]) VALUES ('" & strCreditorAccount & "', " _
            & "'" & gwt_comm.shortMonthDateFormat(TransDate) & "', " & dblAmount & ", 'BILL OUT', " _
            & "'" & strDescription & "', 'BB" & CStr(BatchNumber) & "', '" & strUserName & "', '" & strUserBranch & "')", cnn)
        objCommand.ExecuteNonQuery()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On bill entry reversal"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnReverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReverse.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        Dim strCreditorAccount As String = Nothing
        Dim dblQuantity As Double = 0
        Dim dblAmount As Double = 0
        Dim strLedgerAccount As String = Nothing
        Dim BatchNumber As Integer = 0
        Dim TransDate As Date = Now
        Dim strDescription As String = Nothing
        Dim intTransactionId As Integer = 0

        With dGrid

            If Not Object.Equals(Convert.ToString(.CurrentRow.Cells(11).Value), "") Then
                If UCase(.CurrentRow.Cells(11).Value.ToString) = "INACTIVE" Then
                    MessageBox.Show("This bill cannot be reversed. Bill has been reversed before",
                        "Bill Already Reversed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            If Not Object.Equals(Convert.ToString(.CurrentRow.Cells(10).Value), "") Then
                If IsNumeric(.CurrentRow.Cells(10).Value.ToString) Then
                    intTransactionId = CInt(.CurrentRow.Cells(10).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(.CurrentRow.Cells(5).Value), "") Then
                strCreditorAccount = .CurrentRow.Cells(5).Value.ToString
            End If
            If Not Object.Equals(Convert.ToString(.CurrentRow.Cells(7).Value), "") Then
                If IsNumeric(.CurrentRow.Cells(7).Value.ToString) Then
                    dblQuantity = CDbl(.CurrentRow.Cells(7).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(.CurrentRow.Cells(8).Value), "") Then
                If IsNumeric(.CurrentRow.Cells(8).Value.ToString) Then
                    dblAmount = CDbl(.CurrentRow.Cells(8).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(.CurrentRow.Cells(3).Value), "") Then
                strLedgerAccount = .CurrentRow.Cells(3).Value.ToString
            End If
            If Not Object.Equals(Convert.ToString(.CurrentRow.Cells(0).Value), "") Then
                If IsNumeric(.CurrentRow.Cells(0).Value.ToString) Then
                    BatchNumber = CDbl(.CurrentRow.Cells(0).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(.CurrentRow.Cells(6).Value), "") Then
                strDescription = .CurrentRow.Cells(6).Value.ToString
            End If
            If Not Object.Equals(Convert.ToString(.CurrentRow.Cells(1).Value), "") Then
                Dim strDate As String = .CurrentRow.Cells(1).Value.ToString
                Dim strBuffer() As String = Split(strDate, "-")
                strDate = strBuffer(0) & "-" & gwt_comm.getMonth(CInt(strBuffer(1))) & "-" & strBuffer(2)
                TransDate = CDate(strDate)
            End If

            boolAbort = False
            ReverseTransaction(strCreditorAccount, dblQuantity, dblAmount, strLedgerAccount, BatchNumber, TransDate, strDescription, intTransactionId)
            If boolAbort = False Then
                MessageBox.Show("Transaction has been reversed successfully",
                    "Bill Entry Reversal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                LoadDataByDate(CDate(gwt_comm.shortMonthDateFormat(dpStartDate.Value)), CDate(gwt_comm.shortMonthDateFormat(dpEndDate.Value)))
            End If

        End With
    End Sub

    'Private Sub AlternateColors()
    '    For i As Integer = 0 To dGrid.Rows.Count - 1 Step 2
    '        For j As Integer = 0 To dGrid.Columns.Count - 1
    '            Dim foreColor As Color = Color.Black
    '            Dim backColor As Color = Color.WhiteSmoke
    '            dGrid.Rows(i).Cells(j).Style.BackColor = backColor
    '            dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
    '        Next j
    '    Next i
    'End Sub

    Private Sub ComputeTotals()
        With dGrid
            Dim dblTotal As Double = 0
            For i As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(9).Value), "")) Then
                    If IsNumeric(Convert.ToString(.Rows(i).Cells(9).Value)) Then
                        dblTotal = dblTotal + CDbl(Convert.ToString(.Rows(i).Cells(9).Value))
                    End If
                End If
            Next
            lblTotal.Text = Format(dblTotal, "#,##0.00")
        End With
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr

        Dim arrData As New ArrayList

        With dGrid

            For i As Integer = 0 To .Rows.Count - 1

                Dim strLine As String = ";;;;;"

                Dim strCreditorAccount As String = Nothing
                Dim dblQuantity As Double = 0
                Dim dblAmount As Double = 0
                Dim strLedgerAccount As String = Nothing
                Dim BatchNumber As Integer = 0
                Dim TransDate As Date = Now
                Dim strDescription As String = Nothing
                Dim strDate As String = gwt_comm.shortMonthDateFormat(Now)

                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "") Then
                    strCreditorAccount = .Rows(i).Cells(5).Value.ToString
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(7).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(7).Value.ToString) Then
                        dblQuantity = CDbl(.Rows(i).Cells(7).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(8).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(8).Value.ToString) Then
                        dblAmount = CDbl(.Rows(i).Cells(8).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "") Then
                    strLedgerAccount = .Rows(i).Cells(3).Value.ToString
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(0).Value.ToString) Then
                        BatchNumber = CDbl(.Rows(i).Cells(0).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(6).Value), "") Then
                    strDescription = .Rows(i).Cells(6).Value.ToString
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "") Then
                    strDate = .Rows(i).Cells(1).Value.ToString
                    Dim strBuffer() As String = Split(strDate, "-")
                    strDate = strBuffer(0) & "-" & gwt_comm.getMonth(CInt(strBuffer(1))) & "-" & strBuffer(2)
                    TransDate = CDate(strDate)
                End If

                strLine = strDate & ";" & CStr(BatchNumber) & ";" & strLedgerAccount & ";" &
                    strCreditorAccount & ";" & strDescription & ";" & CStr(Format(dblAmount, "##0.00"))
                arrData.Add(strLine)

            Next

        End With

        'Send the details to the print array
        Dim strPrintDetails(0 To (arrData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrData.Item(i)
        Next

        If arrData.Count = 0 Then
            MessageBox.Show("No details to print were obtained from the system",
                "Printing Aborted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "DATE|BATCH|LEDGER #|CREDIT #|DESCRIPTION|AMOUNT"
            .strColumnAlignments = "0|2|0|0|0|2"
            .strColumnWidths = "80|60|100|100|220|80"
            .strFooterCaption = UCase("Bill transactions listing. Printed by " & strUserName)
            .strMainHeader2 = "BILL TRANSACTIONS LISTING"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|NO|YES"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("LightGray")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFontItalic
            .boolGroupDetails = False
            .boolPrintTotals = False
            .intBreakIndex = 0
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|YES"
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On bill entries print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frm As New frmBillEntry
        frm.ShowDialog()
    End Sub

End Class
