Imports CommonLibrary.Commons

Public Class frmLegalBranchTransactionsUpload

    Dim arrDuplicates As New ArrayList

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Function CheckForDuplicateRecord(SqlStatement As String, TableName As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim strComponents1() As String = Split(SqlStatement, " VALUES ")
        If strComponents1.Length < 2 Then
            Return boolReturn
            Exit Function
        End If
        'Check for the index of the defendentant Id first
        Dim intDefendantIdIndex As Integer = 0
        Dim intTransactionDateIndex As Integer = 0
        Dim intDescriptionIndex As Integer = 0
        Dim intFileIndex As Integer = 0

        Dim strSplitForId() As String = Split(strComponents1(0), ", ")
        strSplitForId(0) = Replace(strSplitForId(0), "INSERT INTO " & TableName & " (", "", 1)
        For p As Integer = 0 To strSplitForId.Length - 1
            If UCase(strSplitForId(p)) = UCase("[TransactionDate]") Then
                intTransactionDateIndex = p
            End If
            If UCase(TableName) = UCase("DefendantTransactions") Or UCase(TableName) = UCase("LegalActions") Then
                If UCase(strSplitForId(p)) = UCase("[DefendantId]") Then
                    intDefendantIdIndex = p
                End If
            End If
            If UCase(TableName) = UCase("DefendantTransactions") Then
                If UCase(strSplitForId(p)) = UCase("[Description]") Then
                    intDescriptionIndex = p
                End If
            End If
            If UCase(TableName) = UCase("TrustTransactions") Or UCase(TableName) = UCase("TrustCashbookTransactions") Then
                If UCase(Replace(strSplitForId(p), ")", "", 1)) = UCase("[FileId]") Then
                    intFileIndex = p
                End If
            End If
        Next

        Dim strSplitValue() As String = Split(strComponents1(1), ", ")
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim intReceiptNumber As Integer = 0
        If IsNumeric(strSplitValue(9)) Then
            intReceiptNumber = CInt(Trim(strSplitValue(9)))
        End If

        If UCase(TableName) = UCase("DefendantTransactions") Or UCase(TableName) = UCase("LegalActions") Then
            Dim strDefendantId As String = Replace(strSplitValue(intDefendantIdIndex), "(", "", 1)
            Dim strDateValue As String = Replace(strSplitValue(intTransactionDateIndex), "(", "", 1)
            Dim strDescription As String = Nothing
            Dim dblLineAmt As Double = 0

            If UCase(TableName) = UCase("DefendantTransactions") Then
                strDescription = Replace(strSplitValue(intDescriptionIndex), "(", "", 1)
            End If

            'Check for the record existence
            Dim strExec As String = Nothing
            If UCase(TableName) = UCase("DefendantTransactions") Then
                If IsNumeric(Trim(strSplitValue(7))) Then
                    dblLineAmt = CDbl(Trim(strSplitValue(7)))
                End If
                strExec = "SELECT DefendantId FROM " & TableName & " " _
                    & "WHERE DefendantId = " & strDefendantId & " AND TransactionDate = " & strDateValue & " " _
                    & "AND Description = " & strDescription & " AND Credit = " & dblLineAmt & " AND ReceiptNumber = " & intReceiptNumber & ""
            Else
                strExec = "SELECT DefendantId FROM " & TableName & " " _
                    & "WHERE DefendantId = " & strDefendantId & " AND TransactionDate = " & strDateValue & ""
            End If
            objCommand = New Data.OleDb.OleDbCommand(strExec, cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                boolReturn = True
                If UCase(TableName) = UCase("DefendantTransactions") Then
                    arrDuplicates.Add(strDefendantId & ";" & strDateValue & ";" & strDescription & ";" & _
                        CStr(Format(dblLineAmt, "#,##0.00")) & ";" & intReceiptNumber)
                End If
            End If
            objReader.Close()
        End If

        If UCase(TableName) = UCase("TrustTransactions") Or UCase(TableName) = UCase("TrustCashbookTransactions") Then
            Dim strFileId As String = Replace(strSplitValue(intFileIndex), "(", "", 1)
            strFileId = Replace(strSplitValue(intFileIndex), ")", "", 1)
            Dim strDateValue As String = Replace(strSplitValue(intTransactionDateIndex), "(", "", 1)
            'Check for the record existence
            objCommand = New Data.OleDb.OleDbCommand("SELECT FileId FROM " & TableName & " " _
                & "WHERE FileId = " & strFileId & " AND TransactionDate = " & strDateValue & "", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                boolReturn = True
            End If
            objReader.Close()
        End If

        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Import records duplicates analysis"
        ShowErrorMessage()
    End Function

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(txtFileName.Text) Then
            MessageBox.Show("Please enter the source file name", "Invalid File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFileName.Focus()
            Exit Sub
        End If
        arrDuplicates = New ArrayList
        ImportData()
        If arrDuplicates.Count > 0 Then
            GenerateDuplicatesReport()
        End If
    End Sub

    Private Sub ImportData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objFile As New System.IO.StreamReader(txtFileName.Text)
        Dim strData As String = objFile.ReadToEnd
        objFile.Close()
        Dim strLines() As String = Split(strData, vbCrLf)
        With ProgressBar1
            .Value = 0
            .Visible = True
            .Maximum = strLines.Length + 10
        End With
        For p As Integer = 0 To strLines.Length - 2
            If Not String.IsNullOrEmpty(strLines(p)) Then
                Dim strSplittedData() As String = Split(strLines(p), " ")
                Dim strTableName As String = strSplittedData(2)
                If CheckForDuplicateRecord(strLines(p), strTableName) = False Then
                    Dim objCommand As New Data.OleDb.OleDbCommand(strLines(p), cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
            ProgressBar1.Value = ProgressBar1.Value + 1
        Next
        ProgressBar1.Value = ProgressBar1.Maximum
        Cursor = Cursors.Default
        MessageBox.Show("Entries Uploaded Successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Import records duplicates analysis"
        ShowErrorMessage()
    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        ofd.ShowDialog()
        txtFileName.Text = ofd.FileName
    End Sub

    Private Sub frmLegalBranchTransactionsUpload_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 617 : Me.Height = 167
    End Sub

    Private Sub GenerateDuplicatesReport()
        On Error GoTo RaiseErr

        Dim strPrintDetails(0 To arrDuplicates.Count - 1) As String
        For p As Integer = 0 To arrDuplicates.Count - 1
            strPrintDetails(p) = Replace(arrDuplicates.Item(p), "'", "", 1)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 5
            .strColumnHeaders = "DEBTOR ID|DATE|DESCRIPTION|AMT|REC. NO"
            .strColumnWidths = "80|100|300|80|60"
            .strColumnAlignments = "0|0|0|2|0"
            .strFooterCaption = "REJECTED DUPLICATE TRANSACTIONS"
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = UCase("REJECTED DUPLICATE TRANSACTIONS")
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|NO"
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
            .boolGroupDetails = False
            .boolPrintTotals = False
            '.intBreakIndex = 7
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = True
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO"
            '.intKeyFieldIndex = 7
            .strPrintValues = strPrintDetails
        End With

        boolAbort = False
        Dim fr As New frmPrinterSetup
        fr.ShowDialog()
        If boolAbort = True Then Exit Sub

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Stock movements history print failure"
        ShowErrorMessage()
    End Sub

End Class