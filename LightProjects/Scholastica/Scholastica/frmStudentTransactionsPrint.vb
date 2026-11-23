Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmStudentTransactionsPrint

    Private Sub frmStudentTransactionsPrint_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadFinancials()
    End Sub

    Private Sub LoadFinancials()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "Description, Reference, CAST(Debit AS DECIMAL (10,2)) AS [Debit], CAST(Credit AS DECIMAL (10,2)) AS [Credit], " _
            & "Remarks FROM SC_StudentTransactions WHERE StudentId = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), _
                objReader(2), objReader(3), _
                objReader(4), objReader(5))
        End While
        objReader.Close()

        'Get the student details

        objCommand = New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames AS [Details] " _
            & "FROM SC_Students WHERE StudentId = '" & strSelectedAccount & "'", cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then Me.TextExtra = objReader(0).ToString
        End If
        objReader.Close()

        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Financials Load"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr
        Dim dblBalance As Double = 0
        Dim dblDebitTotal As Double = 0
        Dim dblCreditTotal As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblDebit As Double = 0
            Dim dblCredit As Double = 0
            If Not Object.Equals(dGrid.Rows(i).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                        dblDebit = CDbl(dGrid.Rows(i).Cells(3).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(4).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                        dblCredit = CDbl(dGrid.Rows(i).Cells(4).Value.ToString)
                    End If
                End If
            End If
            dblDebitTotal = dblDebitTotal + dblDebit
            dblCreditTotal = dblCreditTotal + dblCredit
            dblBalance = dblBalance + (dblDebit - dblCredit)
        Next
        lblBalance.Text = Format(dblBalance, "#,##0.00")
        lblDebits.Text = Format(dblDebitTotal, "#,##0.00")
        lblCredits.Text = Format(dblCreditTotal, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Financials Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        'PrintDataGrid(dGrid, Me.TextExtra & vbCrLf & "Statement")
        Dim arrPrintData As New ArrayList
        Dim dblDebitTotals As Double = 0
        Dim dblCreditTotals As Double = 0
        For p As Integer = 0 To dGrid.RowCount - 1
            Dim strDataRow As String = Nothing
            For i As Integer = 0 To dGrid.ColumnCount - 2
                Dim strData As String = Nothing
                If Not Object.Equals(dGrid.Rows(p).Cells(i).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(i).Value.ToString) Then
                        strData = dGrid.Rows(p).Cells(i).Value.ToString
                    End If
                End If
                If i = 3 Then
                    If IsNumeric(strData) Then dblDebitTotals = dblDebitTotals + CDbl(strData)
                End If
                If i = 4 Then
                    If IsNumeric(strData) Then dblCreditTotals = dblCreditTotals + CDbl(strData)
                End If
                strDataRow = strDataRow & strData & ";"
            Next
            strDataRow = Mid(strDataRow, 1, (strDataRow.Length - 1))
            arrPrintData.Add(strDataRow)
        Next

        Dim dblBalance As Double = dblDebitTotals - dblCreditTotals
        Dim dblTotals As Double = 0
        If dblDebitTotals > dblCreditTotals Then
            dblTotals = dblDebitTotals
        Else
            dblTotals = dblCreditTotals
        End If
        'Add blank line
        arrPrintData.Add(" ; ; ; ; ; ")
        If dblBalance < 0 Then
            arrPrintData.Add(" ;BALANCE; ; ;" & Format(dblBalance, "##0.00") & "; ")
        Else
            arrPrintData.Add(" ;BALANCE; ;" & Format(dblBalance, "##0.00") & "; ; ")
        End If

        arrPrintData.Add(" ;TOTAL; ;" & Format(dblTotals, "##0.00") & ";" & Format(dblTotals, "##0.00") & "; ")

        'Add the details to the print class print array

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "DATE|DESCRIPTION|REFERENCE|DEBIT|CREDIT|REMARKS"
            .strColumnAlignments = "0|0|0|2|2|0"
            .strColumnWidths = "80|140|80|80|80|160"
            .strFooterCaption = "Student Transactions Report"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = UCase(Me.TextExtra)
            .strMainHeader3 = "FINANCIAL STATEMENT"
            .strColumnTotals = "NO|NO|NO|NO|YES|YES|YES"
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
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 1
            .strPrintValues = strPrintDetails
        End With
        boolAbort = False
        Dim f As New frmPrinterSetup
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        rpt.PrinterSettings.PrinterName = strSessionPrinter
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Report Print"
        ShowErrorMessage()
    End Sub

End Class
