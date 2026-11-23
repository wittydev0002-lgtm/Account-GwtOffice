Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDebitNotesListings

    Private Sub btnNewCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles btnNewCreditNote.Click
        boolEditStatus = False
        Dim frm As New frmDebitCreditNoteEntry
        frm.ShowDialog()
        LoadTransactions()
    End Sub

    Private Sub LoadTransactions()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing

        strSql = "SELECT DebitNotesMain.NoteNumber AS [Note #], UPPER(REPLACE(CONVERT(CHAR(11), DebitNotesMain.TransDate, 106), ' ', '-')) as [Date], " _
            & "Suppliers.AccountNumber AS [Account], Suppliers.AccountName AS [Client], CAST(DebitNotesMain.TransTotal AS DECIMAL (30,2)) AS [Value], " _
            & "CAST(DebitNotesMain.Discount AS DECIMAL (30,2)) AS [Discounts], " _
            & "CAST(DebitNotesMain.Taxes AS DECIMAL (30,2)) AS [Taxes] FROM DebitNotesMain " _
            & "LEFT OUTER JOIN Suppliers ON DebitNotesMain.AccountId = Suppliers.AccountNumber " _
            & "WHERE DebitNotesMain.TransDate BETWEEN '" & shortMonthDateFormat(dpStartFrom.Value) & "' AND '" & shortMonthDateFormat(CDate(dpEndTo.Value)) & "' "

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p > 3 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On transactions load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEditCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles btnEditCreditNote.Click
        GetSelected()
    End Sub

    Private Sub GetSelected()
        If dGrid.RowCount <= 0 Then Exit Sub
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If IsNumeric(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                boolEditStatus = True
                intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
                Dim frm As New frmDebitCreditNoteEntry
                frm.ShowDialog()
                LoadTransactions()
            End If
        End If
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        GetSelected()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadTransactions()
    End Sub

    Private Sub btnProcess_Click(sender As System.Object, e As System.EventArgs) Handles btnProcess.Click
        LoadTransactions()
    End Sub

    Private Sub btnPrintSummary_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSummary.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim arrPrintData As New ArrayList

        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim intDoc As Integer = 0
            Dim strDate As String = Nothing
            Dim strClient As String = Nothing
            Dim dblDiscount As Double = 0
            Dim dblTaxes As Double = 0
            Dim dblTotal As Double = 0

            With dGrid
                If Not Object.Equals(.Rows(p).Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(0).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(0).Value.ToString) Then
                            intDoc = CInt(.Rows(p).Cells(0).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(1).Value.ToString) Then
                        strDate = .Rows(p).Cells(1).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(2).Value.ToString) Then
                        strClient = .Rows(p).Cells(2).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(3).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(3).Value.ToString) Then
                            dblDiscount = CDbl(.Rows(p).Cells(3).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(4).Value.ToString) Then
                            dblTaxes = CDbl(.Rows(p).Cells(4).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(5).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(5).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(5).Value.ToString) Then
                            dblTotal = CDbl(.Rows(p).Cells(5).Value.ToString)
                        End If
                    End If
                End If
            End With

            arrPrintData.Add(CStr(intDoc) & ";" & strDate & ";" & strClient & ";" &
                             CStr(Format(dblDiscount, "##0.00")) & ";" &
                             CStr(Format(dblTaxes, "##0.00")) & ";" & CStr(Format(dblTotal, "##0.00")))
        Next

        'Send the details to the print class

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "NOTE #|DATE|CLIENT|DISCOUNT|TAXES|VALUE"
            .strColumnAlignments = "0|0|0|2|2|2"
            .strColumnWidths = "80|80|200|80|80|80"
            .strFooterCaption = "DEBIT NOTES LISTING"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "DEBIT NOTES LISTING "
            .strMainHeader3 = "PERIOD : " & UCase(shortMonthDateFormat(dpStartFrom.Value)) & " - " & UCase(shortMonthDateFormat(dpEndTo.Value))
            .strColumnTotals = "NO|NO|NO|YES|YES|YES"
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
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|YES|YES|YES"
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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmDebitNotesListings_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        strCalledBy = Nothing
    End Sub

    Private Sub frmDebitNotesListings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Set the calling document for entries
        strCalledBy = "SUPPLIERS"
        LoadTransactions()
    End Sub

    Private Sub btnPrintSelected_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSelected.Click
        If dGrid.RowCount <= 0 Then Exit Sub
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If IsNumeric(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
                Dim strAccount As String = Nothing
                If Not Object.Equals(dGrid.CurrentRow.Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(2).Value.ToString) Then
                        strAccount = dGrid.CurrentRow.Cells(2).Value.ToString
                    End If
                End If
                DebitCreditNotePrint("DEBIT NOTE", intSelectedTransaction, strAccount)
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If dGrid.RowCount <= 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        If MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
                If IsNumeric(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                    intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
                    Dim intSpecialKey As Integer = 0
                    Dim strSql As String = "SELECT SpecialKey FROM DebitNotesMain WHERE NoteNumber = " & intSelectedTransaction & ""
                    Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                    Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        If IsNumeric(objReader(0).ToString) Then intSpecialKey = CInt(objReader(0).ToString)
                    End If
                    objReader.Close()
                    'If intSpecialKey = 0 Then
                    '    MessageBox.Show("The selected record can only be deleted manually", "Cannot Execute Called Process", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Cursor = Cursors.Default
                    '    Exit Sub
                    'End If

                    If intSpecialKey > 0 Then
                        'Delete the record starting with transactions
                        strSql = "DELETE FROM DebitNoteEntries WHERE SpecialKey = " & intSpecialKey & ""
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                        strSql = "DELETE FROM DebitNotesMain WHERE SpecialKey = " & intSpecialKey & ""
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                        strSql = "DELETE FROM LedgerTransactions WHERE SpecialKey = " & intSpecialKey & ""
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                        strSql = "DELETE FROM SupplierTransactions WHERE SpecialKey = " & intSpecialKey & ""
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If

                    LoadTransactions()

                    MessageBox.Show("Process has been completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End If
        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Listing Print"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class