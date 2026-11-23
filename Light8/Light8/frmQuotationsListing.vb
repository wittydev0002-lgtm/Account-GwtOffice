Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmQuotationsListing

    Private Sub btnNewQuote_Click(sender As System.Object, e As System.EventArgs) Handles btnNewQuote.Click
        If IntPublicQuotations <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        boolEditStatusTwo = False
        Dim f As New frmQuotation
        f.ShowDialog()
        LoadQuote()
    End Sub

    Private Sub LoadQuote()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing

        strSql = "SELECT ReferenceNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], CustomerName, " _
            & "CAST(QuoteValue AS DECIMAL (30,2)) AS [Value], CAST(TotalDiscount AS DECIMAL (30,2)) AS [Discounts], " _
            & "CAST(TotalTaxes AS DECIMAL (30,2)) AS [Taxes] FROM QuoteMain WHERE TransDate BETWEEN " _
            & "'" & gwt_comm.shortMonthDateFormat(dpStartQuote.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpEndQuote.Value) & "'"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim i As Integer = 0
        dGridQuotes.Rows.Clear()
        While objReader.Read
            dGridQuotes.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridQuotes.Rows(i).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridQuotes.Rows(i).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGridQuotes.Rows(i).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dGridQuotes.Rows(i).Cells(3).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then dGridQuotes.Rows(i).Cells(4).Value = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then dGridQuotes.Rows(i).Cells(5).Value = objReader(5).ToString
            i = i + 1
        End While
        objReader.Read()

        'Calculate totals
        Dim dblMovingT As Double = 0
        Dim dblMovingTx As Double = 0
        Dim dblMovingDs As Double = 0
        Dim strValue As String
        For i = 0 To dGridQuotes.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGridQuotes.Rows(i).Cells(3).Value), "")) Then
                strValue = Convert.ToString(dGridQuotes.Rows(i).Cells(3).Value)
                If IsNumeric(strValue) Then
                    dblMovingT = dblMovingT + CDbl(strValue)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridQuotes.Rows(i).Cells(4).Value), "")) Then
                strValue = Convert.ToString(dGridQuotes.Rows(i).Cells(4).Value)
                If IsNumeric(strValue) Then
                    dblMovingTx = dblMovingTx + CDbl(strValue)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridQuotes.Rows(i).Cells(5).Value), "")) Then
                strValue = Convert.ToString(dGridQuotes.Rows(i).Cells(5).Value)
                If IsNumeric(strValue) Then
                    dblMovingDs = dblMovingDs + CDbl(strValue)
                End If
            End If
        Next
        lblQuoteTotal.Text = Format(dblMovingT, "#,##0.00")
        lblQuoteTaxes.Text = Format(dblMovingTx, "#,##0.00")
        lblQuoteDiscounts.Text = Format(dblMovingDs, "#,##0.00")

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub


    Private Sub btnDeleteQuote_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteQuote.Click
        If IntPublicInvoicing <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If dGridQuotes.Rows.Count <= 0 Then Exit Sub
        DeleteQuotation()
    End Sub

    Private Sub DeleteQuotation()

        On Error GoTo RaiseErr

        If Not (Object.Equals(Convert.ToString(dGridQuotes.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridQuotes.CurrentRow.Cells(0).Value.ToString) Then
                boolEditStatusTwo = True
                intSelectedTransaction = CInt(dGridQuotes.CurrentRow.Cells(0).Value.ToString)
                If MessageBox.Show("Are you sure you want to delete this quotation?", "Confirm Quote Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim objDelete As New Data.OleDb.OleDbCommand("DELETE FROM QuoteMain WHERE ReferenceNumber = " & intSelectedTransaction, cnn)
                    objDelete.ExecuteNonQuery()
                    objDelete = New Data.OleDb.OleDbCommand("DELETE FROM QuoteDetails WHERE ReferenceNumber = " & intSelectedTransaction, cnn)
                    objDelete.ExecuteNonQuery()
                    LoadQuote()
                    MessageBox.Show("Quotation deleted successfully", "Quotation Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Cursor = Cursors.Default
                End If
            End If
        End If

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Quotations Analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGridQuotes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridQuotes.DoubleClick
        If IntPublicInvoicing = 0 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If dGridQuotes.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridQuotes.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridQuotes.CurrentRow.Cells(0).Value.ToString) Then
                boolEditStatusTwo = True
                intSelectedTransaction = CInt(dGridQuotes.CurrentRow.Cells(0).Value.ToString)
                Dim f As New frmQuotation
                f.ShowDialog()
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Quotations Analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnRunQuote_Click(sender As System.Object, e As System.EventArgs) Handles btnRunQuote.Click
        LoadQuote()
    End Sub

    Private Sub btnPrintSeletedRowQuote_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSeletedRowQuote.Click
        If dGridQuotes.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim documentType As String = "QUOTATION"
        boolAbort = False

        If Not (Object.Equals(Convert.ToString(dGridQuotes.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridQuotes.CurrentRow.Cells(0).Value.ToString) Then
                intSelectedTransaction = CInt(dGridQuotes.CurrentRow.Cells(0).Value.ToString)
                boolPrinterAlreadySelected = False
                If UCase(strPrintDocumentsTo) = UCase("pdf") Then
                    PrintCustomerPdfDocument(intSelectedTransaction, DocumentType)
                    If boolAbort = False Then
                        Cursor = DefaultCursor
                        MessageBox.Show(documentType & " has been generated to pdf successfully",
                            "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                Else
                    gwt_comm.PrintCustomerDocument(intSelectedTransaction, DocumentType)
                End If
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Quotations Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrintQuoteList_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintQuoteList.Click
        If dGridQuotes.RowCount <= 0 Then
            MessageBox.Show("No records to print", "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'gwt_comm.PrintDataGrid(dGridQuotes, "QUOTATIONS SUMMARY FROM " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " TO " &
        '    UCase(Format(EndDate, "dd-MMM-yyyy")))
    End Sub

    Private Sub btnRefreshQuotes_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshQuotes.Click
        LoadQuote()
    End Sub

    Private Sub btnEditQuote_Click(sender As System.Object, e As System.EventArgs) Handles btnEditQuote.Click
        If IntPublicInvoicing = 0 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If dGridQuotes.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridQuotes.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridQuotes.CurrentRow.Cells(0).Value.ToString) Then
                boolEditStatusTwo = True
                intSelectedTransaction = CInt(dGridQuotes.CurrentRow.Cells(0).Value.ToString)
                Dim f As New frmQuotation
                f.ShowDialog()
            End If
        End If
        LoadQuote()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Quotations Analysis"
        gwt_comm.ShowErrorMessage()
    End Sub
End Class