Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmJournals


    Private Sub btnNewJournal_Click(sender As System.Object, e As System.EventArgs) Handles btnNewJournal.Click
        boolEditStatus = False
        Dim frm As New frmJournalEntry
        frm.ShowDialog()
        LoadJournals(CDate(gwt_comm.shortMonthDateFormat(dpJvStartFrom.Value)), CDate(gwt_comm.shortMonthDateFormat(dpJvEndTo.Value)))
    End Sub

    Private Sub LoadJournals(ByVal sDate As Date, ByVal eDate As Date)
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, [TransDate], 105) AS [Date], [JournalNumber], " _
            & "CAST((SUM ([Amount]/2)) AS DECIMAL (30,2)) AS [Amount], [Status] from JournalEntries " _
            & "WHERE TransDate BETWEEN '" & sDate & "' AND '" & eDate & "' GROUP BY TransDate, JournalNumber, Status"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), Format(CInt(objReader(1).ToString), "000000"), objReader(2), objReader(3))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Journal listing load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ShowOpenJournals()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, [TransDate], 105) AS [Date], [JournalNumber], " _
            & "CAST((SUM ([Amount]/2)) AS DECIMAL (30,2)) AS [Amount], [Status] from JournalEntries " _
            & "WHERE Status = 'N' GROUP BY TransDate, JournalNumber, Status"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), Format(CInt(objReader(1).ToString), "000000"), objReader(2), objReader(3))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Journal listing load"
        ShowErrorMessage()
    End Sub

    Private Sub btnFindJournals_Click(sender As System.Object, e As System.EventArgs) Handles btnFindJournals.Click
        LoadJournals(CDate(gwt_comm.shortMonthDateFormat(dpJvStartFrom.Value)), CDate(gwt_comm.shortMonthDateFormat(dpJvEndTo.Value)))
    End Sub

    Private Sub btnEditJournal_Click(sender As System.Object, e As System.EventArgs) Handles btnEditJournal.Click
        ShowDetails()
    End Sub

    Private Sub ShowDetails()
        On Error GoTo RaiseErr
        If dGrid.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(1).Value.ToString)
        'intSelectedSpecialKey = CInt(dGrid.CurrentRow.Cells(3).Value.ToString)
        boolEditStatus = True
        Dim f As New frmJournalEntry
        f.ShowDialog()
        LoadJournals(CDate(gwt_comm.shortMonthDateFormat(dpJvStartFrom.Value)), CDate(gwt_comm.shortMonthDateFormat(dpJvEndTo.Value)))
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Journal details listing load"
        ShowErrorMessage()
    End Sub

    Private Sub PostJournal()

        On Error GoTo RaiseErr
        
        Dim strFlag As String = "Y"

        If Not Object.Equals(dGrid.CurrentRow.Cells(3).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(3).Value.ToString) Then
                strFlag = UCase(dGrid.CurrentRow.Cells(3).Value.ToString)
            End If
        End If

        Dim intJvnum As Integer = 0
        If Not Object.Equals(dGrid.CurrentRow.Cells(1).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                If IsNumeric(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                    intJvnum = CInt(dGrid.CurrentRow.Cells(1).Value.ToString)
                End If
            End If
        End If

        'Post the journal to the ledger

        If strFlag = "N" Then

            Dim strType As String = Nothing
            Dim strSql As String = "SELECT * FROM JournalEntries WHERE JournalNumber = " & intJvnum & ""
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            Dim intSpecialKey As Integer = gwt_comm.SpecialKey

            While objReader.Read

                Dim strTransDate As String = objReader("TransDate").ToString
                Dim strAccountNumber As String = Nothing
                Dim dblAmount As Double = 0
                Dim strDescription As String = Nothing
                Dim strFolio As String = Nothing
                Dim strCostCenter As String = Nothing

                If Not IsDBNull(objReader("Narration").ToString) Then strDescription = objReader("Narration").ToString
                If Not IsDBNull(objReader("FolioReference").ToString) Then strFolio = objReader("FolioReference").ToString
                If Not IsDBNull(objReader("CostCode").ToString) Then strCostCenter = objReader("CostCode").ToString

                If Not IsDBNull(objReader("TransactionType").ToString) Then strType = objReader("TransactionType").ToString
                If Not String.IsNullOrEmpty(objReader("AccountNumber").ToString) Then strAccountNumber = objReader("AccountNumber").ToString

                If UCase(strType) = "DEBIT" Then
                    strSql = "INSERT INTO LedgerTransactions ([TransactionDate],[AccountNumber],[Amount]," _
                        & "[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch],[Reference], " _
                        & "[FolioReference], [JournalNumber], [SpecialKey], [CostCode]) VALUES " _
                        & "('" & strTransDate & "', '" & strAccountNumber & "', " & dblAmount & ", " _
                        & "'" & strType & "','','" & strDescription & "', '" & strUserName & "', '" & strUserBranch & "', " _
                        & "" & intJvnum & ", '" & strFolio & "', " & intJvnum & ", " & intSpecialKey & ", '" & strCostCenter & "')"
                Else
                    strSql = "INSERT INTO LedgerTransactions ([TransactionDate],[AccountNumber],[Amount]," _
                        & "[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch],[Reference], " _
                        & "[FolioReference], [JournalNumber], [SpecialKey], [CostCode]) VALUES " _
                        & "('" & strTransDate & "', '" & strAccountNumber & "', " & dblAmount & ", " _
                        & "'" & strType & "','','" & strDescription & "', '" & strUserName & "', '" & strUserBranch & "', " _
                        & "" & intJvnum & ", '" & strFolio & "', " & intJvnum & ", " & intSpecialKey & ", '" & strCostCenter & "')"
                End If

                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

            End While
            objReader.Close()

            strSql = "UPDATE JournalEntries SET Status = 'Y' WHERE JournalNumber = " & intJvnum & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            MessageBox.Show("Journal has been posted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ShowOpenJournals()

        Else
            MessageBox.Show("This journal has already been posted", "Process Cannot Be Executed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Journal details listing load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        ShowDetails()
    End Sub

    Private Sub btnDeleteJournal_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteJournal.Click
        On Error GoTo RaiseErr

        Dim strFlag As String = "Y"
        If Not Object.Equals(dGrid.CurrentRow.Cells(3).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(3).Value.ToString) Then
                strFlag = UCase(dGrid.CurrentRow.Cells(3).Value.ToString)
            End If
        End If

        Dim intJvnum As Integer = 0
        If Not Object.Equals(dGrid.CurrentRow.Cells(1).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                If IsNumeric(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                    intJvnum = CInt(dGrid.CurrentRow.Cells(1).Value.ToString)
                End If
            End If
        End If

        If strFlag = "N" Then
            If intJvnum > 0 Then
                If MessageBox.Show("Are you sure you want to delete this journal?", "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM JournalEntries WHERE JournalNumber = " & intJvnum & "", cnn)
                    objCommand.ExecuteNonQuery()
                    MessageBox.Show("Journal has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadJournals(CDate(gwt_comm.shortMonthDateFormat(dpJvStartFrom.Value)), CDate(gwt_comm.shortMonthDateFormat(dpJvEndTo.Value)))
                End If
            End If
        Else
            MessageBox.Show("This journal cannot be deleted as it has already been posted", "Process Cannot Be Executed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Journal Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPost_Click(sender As System.Object, e As System.EventArgs) Handles btnPost.Click
        PostJournal()
    End Sub

    Private Sub btnPrintSeletedRowQuote_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSeletedRowQuote.Click
        PrintJournal()
    End Sub

    Private Sub btnPrintQuoteList_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintQuoteList.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim arrPrintData As New ArrayList

        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim intDoc As Integer = 0
            Dim strDate As String = Nothing
            Dim strSatatus As String = Nothing
            Dim dblTotal As Double = 0

            With dGrid
                If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(1).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(1).Value.ToString) Then
                            intDoc = CInt(.Rows(p).Cells(1).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(0).Value.ToString) Then
                        strDate = .Rows(p).Cells(0).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(3).Value.ToString) Then
                        strSatatus = .Rows(p).Cells(3).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(2).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(2).Value.ToString) Then
                            dblTotal = CDbl(.Rows(p).Cells(2).Value.ToString)
                        End If
                    End If
                End If
                
            End With

            arrPrintData.Add(CStr(intDoc) & ";" & strDate & ";" & strSatatus & ";" & CStr(Format(dblTotal, "##0.00")) & "; ")
        Next

        'Send the details to the print class

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 5
            .strColumnHeaders = "JV #|DATE|POSTED|AMOUNT|"
            .strColumnAlignments = "0|0|1|2|0"
            .strColumnWidths = "80|80|60|100|100"
            .strFooterCaption = "JOURNALS LISTING"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "JOURNALS LISTING "
            .strMainHeader3 = "PERIOD : " & UCase(gwt_comm.shortMonthDateFormat(dpJvStartFrom.Value)) & " - " & UCase(gwt_comm.shortMonthDateFormat(dpJvEndTo.Value))
            .strColumnTotals = "NO|NO|NO|YES|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
            .VerticalLines = True
            .GridColor = Color.LightGray
            .BorderColor = Color.FromName("LightGray")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|YES|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With

        Dim prnt As New PrintDialog   'frmPrinterSetup
        prnt.ShowDialog()


        strSessionPrinter = prnt.PrinterSettings.PrinterName.ToString

        rpt.PrinterSettings.PrinterName = strSessionPrinter

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Listing Print"
        ShowErrorMessage()
    End Sub

    Private Sub PrintJournal()

        If dGrid.RowCount <= 0 Then Exit Sub

        Cursor = Cursors.WaitCursor

        Dim intJvnum As Integer = 0
        If Not Object.Equals(dGrid.CurrentRow.Cells(1).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                If IsNumeric(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                    intJvnum = CInt(dGrid.CurrentRow.Cells(1).Value.ToString)
                End If
            End If
        End If

        'Get the selected Journal 

        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date], " _
            & "[AccountNumber],[Narration], [TransactionType], [FolioReference], [CostCode], CAST(Amount AS DECIMAL (30,2)) AS [Amount] " _
            & "FROM JournalEntries WHERE [JournalNumber] = " & intJvnum & ""

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrPrintData As New ArrayList

        While objReader.Read
            Dim strDate As String = Nothing
            Dim strAccount As String = Nothing
            Dim strNarration As String = Nothing
            Dim strType As String = Nothing
            Dim strFolio As String = Nothing
            Dim strCostCode As String = Nothing
            Dim strAmount As String = Nothing

            If Not IsDBNull(objReader(0).ToString) Then strDate = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strAccount = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strNarration = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then strType = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then strFolio = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then strCostCode = objReader(5).ToString
            If Not IsDBNull(objReader(6).ToString) Then strAmount = objReader(6).ToString
            If UCase(strType) = UCase("CREDIT") Then
                strAmount = Format((0 - CDbl(strAmount)), "##0.00")
            End If
            arrPrintData.Add(strDate & ";" & strAccount & ";" & strNarration & ";" & _
                strType & ";" & strFolio & ";" & strCostCode & ";" & strAmount)
        End While
        objReader.Close()

        'Send the details to the print class

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 7
            .strColumnHeaders = "DATE|ACCOUNT|NARRATION|TYPE|FOLIO|CENTER|AMOUNT"
            .strColumnAlignments = "0|0|0|0|0|0|2"
            .strColumnWidths = "80|80|180|60|60|60|80"
            .strFooterCaption = "JOURNALS DETAILS"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "JOURNALS DETAILS "
            .strMainHeader3 = "JOURNAL NO " & CStr(intJvnum)
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|YES"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
            .VerticalLines = True
            .GridColor = Color.LightGray
            .BorderColor = Color.FromName("LightGray")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|YES"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With

        Dim prnt As New PrintDialog   'frmPrinterSetup
        prnt.ShowDialog()


        strSessionPrinter = prnt.PrinterSettings.PrinterName.ToString

        rpt.PrinterSettings.PrinterName = strSessionPrinter

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Listing Print"
        ShowErrorMessage()
    End Sub

End Class