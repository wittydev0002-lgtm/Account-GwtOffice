
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInvoiceMain

    Dim boolFormLoading As Boolean
    Dim boolPrintFromPreview As Boolean
    Dim strReportHeader As String
    Public itm As Integer = 0

    Dim strTaxStatus As String = Nothing
    Dim strCustomerDetails As String
    Dim strInvoiceDetails As ArrayList
    Dim rsInvoiceTotals As String

    Dim dblInvoiceTotal As Double
    Dim dblTaxes As Double
    Dim dblDiscounts As Double
    Dim i As Integer = 0
    Dim strvalue As String
    Dim strDate As String
    Dim intPaymentReceiptNumber As Integer
    Dim strCustomerAccountNumberPayments As String
    Dim strTermsAndConditions As String = Nothing

    Dim strCustomerName As String
    Dim strCustomerAddress1 As String
    Dim strCustomerAddress2 As String
    Dim strCustomerAddress3 As String
    Dim strCustomerAddress4 As String
    Dim strCustomerTelephone As String
    Dim strCustomerEmailAddress As String
    Dim strCustomerVatNumber As String

    Dim boolExitingWhile As Boolean = False
    Dim intPage As Single = 1
    Dim intPageTotals As Integer = 1

    Dim strItemType As String = Nothing

    Private Sub frmInvoiceMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadProformas(dpStartFromProforma.Value, dpEndToProforma.Value)
        LoadCustomerData("ALL")
        LoadQuote()
        loadProformaEmployees()
        LoadCreditData(dpStartCreditNote.Value, dpEndCreditNote.Value)
        cboCustomerSearchBy.SelectedIndex = 1
    End Sub

    Private Sub btnNewCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnNewCustomer.Click
        If IntPublicCustomers <> 2 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        boolEditStatus = False
        Dim f As New frmCustomerDetails
        f.ShowDialog()
        LoadCustomerData("ALL")
    End Sub

    Private Sub btnEditCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnEditCustomer.Click
        If IntPublicCustomers <> 2 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        EditCustomerDetails()
    End Sub

    Private Sub EditCustomerDetails()
        GetSelectedCustomer()
        boolEditStatus = True
        boolAbort = False
        Dim f As New frmCustomerDetails
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        LoadCustomerData("ALL")
    End Sub

    Private Sub LoadCustomerData(Optional ByVal SearchFor As String = "ALL")
        On Error GoTo RaiseErr
        'dGrid.Rows.Clear()
        Dim strSql As String = Nothing

        'Select Case UCase(SearchFor)
        '    Case = "ALL"

        'End Select
        If UCase(SearchFor) = "ALL" Then
            strSql = "SELECT AccountNumber AS [Account No.], AccountName as [Name], " _
                & "PhoneNumber as [Telephone], CONVERT(NVARCHAR, TakeOnDate, 105) AS [Take On Date], " _
                & "REPLACE((Address1 +', '+ Address2 +', '+ Address3 +', '+ Address4), ', ,', '') AS [Address], " _
                & "EmailAddress as [Email Address], Cellphone AS [Cellphone] FROM " _
                & "Customers ORDER BY AccountName, AccountNumber"
        Else
            If UCase(cboCustomerSearchBy.Text) = UCase("Account Number") Then
                strSql = "SELECT AccountNumber AS [Account No.], AccountName as [Name], " _
                    & "PhoneNumber as [Telephone], CONVERT(NVARCHAR, TakeOnDate, 105) AS [Take On Date], " _
                    & "REPLACE((Address1 +', '+ Address2 +', '+ Address3 +', '+ Address4), ', ,', '') AS [Address], " _
                    & "EmailAddress as [Email Address], Cellphone AS [Cellphone] FROM " _
                    & "Customers WHERE AccountNumber LIKE '%" & SearchFor & "%' ORDER BY AccountNumber"
            Else
                strSql = "SELECT AccountNumber AS [Account No.], AccountName as [Name], " _
                    & "PhoneNumber as [Telephone], CONVERT(NVARCHAR, TakeOnDate, 105) AS [Take On Date], " _
                    & "REPLACE((Address1 +', '+ Address2 +', '+ Address3 +', '+ Address4), ', ,', '') AS [Address], " _
                    & "EmailAddress as [Email Address], Cellphone AS [Cellphone] FROM " _
                    & "Customers  WHERE AccountName LIKE '%" & SearchFor & "%' ORDER BY AccountName"
            End If
        End If




        dGridCustomers.Columns.Clear()
        Me.dGridCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridCustomers.DataSource = dTable
        For p As Integer = 0 To dGridCustomers.Columns.Count - 1
            If p = 4 Then
                dGridCustomers.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                dGridCustomers.Columns(p).Visible = False
            Else
                dGridCustomers.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End If
        Next
        AlternateColors(dGridCustomers)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Summary Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub AlternateColors(Grid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView)
        For i As Integer = 0 To Grid.Rows.Count - 1 Step 2
            For j As Integer = 0 To Grid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                Grid.Rows(i).Cells(j).Style.BackColor = backColor
                Grid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub GetSelectedCustomer()
        If dGridCustomers.Rows.Count > 0 Then
            strSelectedAccount = dGridCustomers.CurrentRow.Cells(0).Value.ToString
            strSelectedAccountName = dGridCustomers.CurrentRow.Cells(1).Value.ToString
        End If
    End Sub

    Private Sub btnDeleteCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteCustomer.Click
        DeleteCustomer()
    End Sub

    Private Sub DeleteCustomer()
        If IntPublicCustomers = 1 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        GetSelectedCustomer()
        If MessageBox.Show("Are you sure you want to delete this reord? Deleting " & vbCrLf & "customers may have adverse effect to your financial records", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM Customers WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSales WHERE CustomerId = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSalesMain WHERE CustomerId = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerTerms WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerTransactions WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE ContraAccount = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CashbookTransactions WHERE ContraAccount = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()

            objCommand = New Data.OleDb.OleDbCommand("SELECT NoteNumber FROM CreditNotesMain WHERE AccountId = '" & strSelectedAccount & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReader.Read
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CreditNoteEntries WHERE NoteNumber = " & objReader(0).ToString & "", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CreditNotesMain WHERE NoteNumber = " & objReader(0).ToString & "", cnn)
                objCommand.ExecuteNonQuery()
            End While

            MessageBox.Show("Customer record deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadCustomerData("ALL")
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Listing Search"
        ShowErrorMessage()
    End Sub


    Private Sub btnExportCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btnExportCustomers.Click
        If IntPublicCustomers <= 1 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim sfd As New SaveFileDialog
        sfd.ShowDialog()
        Dim strFileName As String = sfd.FileName
        If Not String.IsNullOrEmpty(strFileName) Then
            Cursor = Cursors.WaitCursor
            Dim strData As String = gwt_comm.ScriptCustomerData()
            Dim objFileWriter As New System.IO.StreamWriter(strFileName, False)
            objFileWriter.WriteLine(strData)
            objFileWriter.Close()
            Cursor = Cursors.Default
            MessageBox.Show("Customers Export File Generated Successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Details Export"
        ShowErrorMessage()
    End Sub

    Private Sub btnAccountSettlement_Click(sender As System.Object, e As System.EventArgs) Handles btnAccountSettlement.Click
        boolAbort = False
        Dim frm1 As New frmCashbookSelection
        frm1.ShowDialog()
        If boolAbort = True Then Exit Sub
        Dim frm2 As New frmAdvanceInvoiceSettlement
        frm2.ShowDialog()
    End Sub

    Private Sub btnRefreshCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshCustomers.Click
        LoadCustomerData("ALL")
    End Sub

    Private Sub btnNewInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnNewInvoice.Click
        boolEditStatusTwo = False
        boolLoadedFromCustomerForm = False
        Dim frm As New frmInvoice
        frm.ShowDialog()
        LoadInvoice(CDate(gwt_comm.shortMonthDateFormat(Now)), CDate(gwt_comm.shortMonthDateFormat(Now)))
    End Sub

    Private Sub btnEditInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnEditInvoice.Click
        If grd.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(grd.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(grd.CurrentRow.Cells(0).Value.ToString) Then
                boolEditStatusTwo = True
                boolLoadedFromCustomerForm = False
                intSelectedTransaction = CInt(grd.CurrentRow.Cells(0).Value.ToString)
                boolAbort = False
                Dim f As New frmInvoice
                f.ShowDialog()
                If boolAbort = True Then Exit Sub
                LoadInvoice(CDate(gwt_comm.shortMonthDateFormat(StartDate)), CDate(gwt_comm.shortMonthDateFormat(EndDate)))
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoices Edit"
        ShowErrorMessage()
    End Sub

    Private Sub btnRunInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnRunInvoice.Click
        LoadInvoice(CDate(gwt_comm.shortMonthDateFormat(StartDate)), CDate(gwt_comm.shortMonthDateFormat(EndDate)))
    End Sub

    Private Sub btnPrintSelected_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSelected.Click
        If grd.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        boolPrinterAlreadySelected = False
        If Not (Object.Equals(Convert.ToString(grd.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(grd.CurrentRow.Cells(0).Value.ToString) Then
                If UCase(CommonLibrary.Commons.strInvoiceDesignType) = "CUSTOM" Then
                    Dim f As New PrintDialog
                    f.ShowDialog()
                    boolEditStatusTwo = True
                    boolPrintFromPreview = True
                    PrintDocument2.PrinterSettings.PrinterName = f.PrinterSettings.PrinterName
                    PrintPreviewDialog1.Document = PrintDocument2
                    PrintPreviewDialog1.ShowDialog()
                Else
                    'Print generic invoice
                    intSelectedTransaction = CInt(grd.CurrentRow.Cells(0).Value.ToString)
                    Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
                    gwt_comm.PrintCustomerDocument(intSelectedTransaction, "INVOICE")
                End If
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Analysis"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintSummary_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSummary.Click
        If grd.RowCount <= 0 Then Exit Sub
        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
        gwt_comm.PrintDataGrid(grd, "INVOICES SUMMARY FOR PERIOD " & UCase(gwt_comm.shortMonthDateFormat(StartDate)) &
            " TO " & UCase(gwt_comm.shortMonthDateFormat(EndDate)))
    End Sub

    Private Sub btnDeliveryNote_Click(sender As System.Object, e As System.EventArgs) Handles btnDeliveryNote.Click
        If grd.Rows.Count <= 0 Then Exit Sub
        boolPrinterAlreadySelected = False
        intSelectedTransaction = CInt(grd.CurrentRow.Cells(0).Value.ToString)
        'strDeliveryNoteFrom = "INVOICES"
        'Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
        'gwt_comm.PrintCustomerDocument(intSelectedTransaction, "DELIVERY NOTE")
        'strDeliveryNoteFrom = Nothing
        Dim f As New frmInvoiceDeliveryNote
        f.ShowDialog()
    End Sub

    Private Sub btnRefreshInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshInvoice.Click
        LoadInvoice(CDate(gwt_comm.shortMonthDateFormat(Now)), CDate(gwt_comm.shortMonthDateFormat(Now)))
    End Sub

    Private Sub btnNewQuote_Click(sender As System.Object, e As System.EventArgs) Handles btnNewQuote.Click
        If IntPublicQuotations <> 2 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        boolEditStatusTwo = False
        Dim f As New frmQuotation
        f.ShowDialog()
        LoadQuote()
    End Sub

    Private Sub btnEditQuote_Click(sender As System.Object, e As System.EventArgs) Handles btnEditQuote.Click
        If IntPublicInvoicing = 0 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
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
        ShowErrorMessage()
    End Sub

    Private Sub LoadQuote()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing

        strSql = "SELECT ReferenceNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], CustomerName, " _
            & "CAST(QuoteValue AS DECIMAL (10,2)) AS [Value], CAST(TotalDiscount AS DECIMAL (10,2)) AS [Discounts], " _
            & "CAST(TotalTaxes AS DECIMAL (10,2)) AS [Taxes] FROM QuoteMain WHERE TransDate BETWEEN " _
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
        AlternateColors(dGridQuotes)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub


    Private Sub btnDeleteQuote_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteQuote.Click
        If IntPublicInvoicing <> 2 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
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
        ShowErrorMessage()
    End Sub

    Private Sub dGridQuotes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridQuotes.DoubleClick
        If IntPublicInvoicing = 0 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
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
        ShowErrorMessage()
    End Sub

    Private Sub btnRunQuote_Click(sender As System.Object, e As System.EventArgs) Handles btnRunQuote.Click
        LoadQuote()
    End Sub

    Private Sub btnPrintSeletedRowQuote_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSeletedRowQuote.Click
        If dGridQuotes.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridQuotes.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridQuotes.CurrentRow.Cells(0).Value.ToString) Then
                intSelectedTransaction = CInt(dGridQuotes.CurrentRow.Cells(0).Value.ToString)
                boolPrinterAlreadySelected = False
                gwt_comm.PrintCustomerDocument(intSelectedTransaction, "QUOTATION")
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Quotations Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintQuoteList_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintQuoteList.Click
        If dGridQuotes.RowCount <= 0 Then
            MessageBox.Show("No records to print", "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        gwt_comm.PrintDataGrid(dGridQuotes, "QUOTATIONS SUMMARY FROM " & UCase(gwt_comm.shortMonthDateFormat(StartDate)) & " TO " &
            UCase(gwt_comm.shortMonthDateFormat(EndDate)))
    End Sub

    Private Sub btnRefreshQuotes_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshQuotes.Click
        LoadQuote()
    End Sub

    Private Sub btnNewCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles btnNewCreditNote.Click
        boolEditStatusTwo = False
        Dim f As New frmCreditNoteEntry
        f.ShowDialog()
    End Sub

    Private Sub btnEditCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles btnEditCreditNote.Click
        If dGridCreditNotes.Rows.Count > 0 Then
            GetSelectedCreditNote()
            boolEditStatusTwo = True
            Dim f As New frmCreditNoteEntry
            f.ShowDialog()
        End If
    End Sub

    Private Sub GetSelectedCreditNote()
        boolLoadedFromCustomerForm = False
        intSelectedTransaction = 0
        If dGridCreditNotes.Rows.Count > 0 Then
            intSelectedTransaction = CInt(dGridCreditNotes.CurrentRow.Cells(1).Value.ToString)
        End If
    End Sub

    Private Sub btnRunCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles btnRunCreditNote.Click
        LoadCreditData(CDate(gwt_comm.shortMonthDateFormat(StartDate)), CDate(gwt_comm.shortMonthDateFormat(EndDate)))
    End Sub

    Private Sub btnPrintCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintCreditNote.Click
        If dGridCreditNotes.Rows.Count <= 0 Then Exit Sub
        Dim intDocument As Integer = 0
        If Not Object.Equals(Convert.ToString(dGridCreditNotes.CurrentRow.Cells(1).Value), "") Then
            If IsNumeric(dGridCreditNotes.CurrentRow.Cells(1).Value.ToString) Then
                intDocument = CDbl(dGridCreditNotes.CurrentRow.Cells(1).Value.ToString)
                boolPrinterAlreadySelected = False
                Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
                gwt_comm.PrintCustomerDocument(intDocument, "CREDIT NOTE")
            End If
        End If
    End Sub

    Private Sub btnRefreshCreditNotes_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshCreditNotes.Click
        LoadCreditData(CDate(gwt_comm.shortMonthDateFormat(Now)), CDate(gwt_comm.shortMonthDateFormat(Now)))
    End Sub

    Private Sub LoadCreditData(StartingDate As Date, EndingDate As Date)
        On Error GoTo RaiseErr
        dGridCreditNotes.Rows.Clear()
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) AS [Date]," _
            & "[NoteNumber], [AccountId] as [Account], Customers.AccountName AS [Customer], " _
            & "CAST(TransTotal AS DECIMAL (10,2)) AS [Amount] FROM CreditNotesMain " _
            & "LEFT OUTER JOIN Customers ON CreditNotesMain.AccountId = Customers.AccountNumber " _
            & "WHERE TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartCreditNote.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpEndCreditNote.Value) & "' ORDER BY NoteNumber"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            With dGridCreditNotes
                .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4))
            End With
        End While
        objReader.Close()
        'objCommand.CommandType = CommandType.Text

        'Dim da As New OleDb.OleDbDataAdapter(objCommand)
        'Dim dTable As New DataTable()
        'da.Fill(dTable)
        'dGridCreditNotes.DataSource = dTable

        'dGridCreditNotes.Columns(0).HeaderText = "Date"

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Credit notes main details load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadInvoice(StartingDate As Date, EndingDate As Date)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing

        strSql = "SELECT CustomerSalesMain.InvoiceNumber, CONVERT(NVARCHAR, CustomerSalesMain.TransDate, 105) AS [Date], Customers.AccountName, " _
                & "CAST(CustomerSalesMain.Amount AS DECIMAL (10,2)) AS [Value], CAST(CustomerSalesMain.Discount AS DECIMAL (10,2)) AS [Discounts], " _
                & "CAST(CustomerSalesMain.Taxes AS DECIMAL (10,2)) AS [Taxes] FROM CustomerSalesMain LEFT OUTER JOIN Customers ON " _
                & "CustomerSalesMain.CustomerId = Customers.AccountNumber WHERE TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(dpStartInvoice.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpEndInvoice.Value) & "' "

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim i As Integer = 0
        grd.Rows.Clear()
        While objReader.Read
            grd.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then grd.Rows(i).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then grd.Rows(i).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then grd.Rows(i).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then grd.Rows(i).Cells(3).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then grd.Rows(i).Cells(4).Value = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then grd.Rows(i).Cells(5).Value = objReader(5).ToString
            i = i + 1
        End While
        objReader.Read()

        'Calculate totals
        Dim dblMovingT As Double = 0
        Dim dblMovingTx As Double = 0
        Dim dblMovingDs As Double = 0
        Dim strValue As String
        For i = 0 To grd.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(grd.Rows(i).Cells(3).Value), "")) Then
                strValue = Convert.ToString(grd.Rows(i).Cells(3).Value)
                If IsNumeric(strValue) Then
                    dblMovingT = dblMovingT + CDbl(strValue)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(grd.Rows(i).Cells(4).Value), "")) Then
                strValue = Convert.ToString(grd.Rows(i).Cells(4).Value)
                If IsNumeric(strValue) Then
                    dblMovingTx = dblMovingTx + CDbl(strValue)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(grd.Rows(i).Cells(5).Value), "")) Then
                strValue = Convert.ToString(grd.Rows(i).Cells(5).Value)
                If IsNumeric(strValue) Then
                    dblMovingDs = dblMovingDs + CDbl(strValue)
                End If
            End If
        Next
        lblTotal.Text = Format(dblMovingT, "#,##0.00")
        lblTaxes.Text = Format(dblMovingTx, "#,##0.00")
        lblDiscounts.Text = Format(dblMovingDs, "#,##0.00")
        AlternateColors(grd)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub PrintCustomerStatements()
        On Error GoTo RaiseErr

        boolAbort = False
        gwt_comm.DateRangeSpecification()
        If boolAbort = True Then Exit Sub

        boolPrinterAlreadySelected = False

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT accountNumber FROM Customers ORDER BY AccountNumber", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        'Get the count of the records

        objCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(AccountNumber) FROM Customers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim intCount As Integer = 0
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()

        ProgressBarItem1.Value = 0
        ProgressBarItem1.Visible = True
        ProgressBarItem1.Maximum = intCount + 3

        intAgingDaysPerPeriod = 30
        intAgingIntervals = 4

        While objReader.Read

            LoadTransactions(objReader(0).ToString)

            Dim strStatementArray As New ArrayList

            'This is the new method for computing the aging balances

            Dim dblBalanceAtEndDate As Double = gwt_comm.CustomerBalanceOnSpecificDate(objReader(0).ToString, gwt_comm.shortMonthDateFormat(EndDate))
            Dim dblAgingBalances() As Double = gwt_comm.AgingBalances(dblBalanceAtEndDate, intAgingIntervals, intAgingDaysPerPeriod, gwt_comm.shortMonthDateFormat(EndDate), objReader(0).ToString)
            Dim dblCurrentPeriodBalance As Double = gwt_comm.BalanceFromCutoffToCurrent(objReader(0).ToString, gwt_comm.shortMonthDateFormat(EndDate))
            Dim dblTotalBalance As Double = gwt_comm.CustomerBalanceOnSpecificDate(objReader(0).ToString, gwt_comm.shortMonthDateFormat(Now))

            If dblBalanceAtEndDate <= 0 Then
                For p As Integer = 0 To dblAgingBalances.Length - 1
                    dblAgingBalances(p) = 0
                Next
            End If

            'Get the aging balances
            Dim arrAgeBalances As New ArrayList

            dblBetween00and30 = dblAgingBalances(0) '+ dblCurrentPeriodBalance
            dblBetween30and60 = dblAgingBalances(1)
            dblBetween60and90 = dblAgingBalances(2)
            dblOver90 = dblAgingBalances(3)

            'arrAgeBalances = gwt_comm.ComputeAgingBalances(dGridTransactions)

            ''Assign the age balances to common variables
            'dblBetween00and30 = CDbl(arrAgeBalances.Item(0))
            'dblBetween30and60 = CDbl(arrAgeBalances.Item(1))
            'dblBetween60and90 = CDbl(arrAgeBalances.Item(2))
            'dblOver90 = CDbl(arrAgeBalances.Item(3))

            Dim dblCummulativeStatementBalance As Double = 0

            'Get the balance brought forwd
            For i As Integer = 0 To dGridTransactions.Rows.Count - 3

                Dim dblDr As Double = 0
                Dim dblCr As Double = 0
                Dim strDt As String = Nothing

                If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(0).Value), "")) Then
                    strDt = dGridTransactions.Rows(i).Cells(0).Value.ToString
                End If
                strDt = Mid(strDt, 1, 2) & "-" & MonthName(CInt(Mid(strDt, 4, 2)), True) & "-" & Mid(strDt, 7, 4)

                If CDate(strDt) < CDate(gwt_comm.shortMonthDateFormat(StartDate)) Then
                    'If CDate(strDt) <= EndDate Then
                    If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(4).Value), "")) Then
                        If IsNumeric(dGridTransactions.Rows(i).Cells(4).Value.ToString) Then
                            dblDr = CDbl(dGridTransactions.Rows(i).Cells(4).Value.ToString)
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(5).Value), "")) Then
                        If IsNumeric(dGridTransactions.Rows(i).Cells(5).Value.ToString) Then
                            dblCr = CDbl(dGridTransactions.Rows(i).Cells(5).Value.ToString)
                        End If
                    End If
                    dblCummulativeStatementBalance = dblCummulativeStatementBalance + (dblDr - dblCr)
                    'End If
                End If

            Next

            strStatementArray.Add(UCase(gwt_comm.shortMonthDateFormat(StartDate)) & "|" & "Balance brought forward" & "| | | | |" & Format(dblCummulativeStatementBalance, "#,##0.00"))
            Dim dblBalance As Double = dblCummulativeStatementBalance

            For i As Integer = 0 To dGridTransactions.Rows.Count - 3
                Dim strDate As String = Nothing
                Dim strReference As String = Nothing
                Dim strDescription As String = Nothing
                Dim dblDebit As Double = 0
                Dim dblCredit As Double = 0
                Dim strProjectName As String = Nothing

                If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(0).Value), "")) Then
                    strDate = dGridTransactions.Rows(i).Cells(0).Value.ToString
                End If
                strDate = Mid(strDate, 1, 2) & "-" & MonthName(CInt(Mid(strDate, 4, 2)), True) & "-" & Mid(strDate, 7, 4)

                If CDate(strDate) >= CDate(gwt_comm.shortMonthDateFormat(StartDate)) Then
                    If CDate(strDate) <= CDate(gwt_comm.shortMonthDateFormat(EndDate)) Then
                        If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(1).Value), "")) Then
                            strReference = dGridTransactions.Rows(i).Cells(1).Value.ToString
                        End If
                        If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(2).Value), "")) Then
                            strDescription = dGridTransactions.Rows(i).Cells(2).Value.ToString
                        End If
                        If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(4).Value), "")) Then
                            If IsNumeric(dGridTransactions.Rows(i).Cells(4).Value.ToString) Then
                                dblDebit = CDbl(dGridTransactions.Rows(i).Cells(4).Value.ToString)
                            End If
                        End If
                        If Not (Object.Equals(Convert.ToString(dGridTransactions.Rows(i).Cells(5).Value), "")) Then
                            If IsNumeric(dGridTransactions.Rows(i).Cells(5).Value.ToString) Then
                                dblCredit = CDbl(dGridTransactions.Rows(i).Cells(5).Value.ToString)
                            End If
                        End If
                        dblBalance = dblBalance + (dblDebit - dblCredit)
                        'DATE, DESCRIPTION, REF, PROJECT, DEBIT, CREDIT, BALANCE
                        strStatementArray.Add(strDate & "|" & strDescription & "|" & strReference & "|" & strProjectName & "|" &
                            Format(dblDebit, "#,##0.00") & "|" & Format(dblCredit, "#,##0.00") & "|" &
                            Format(dblBalance, "#,##0.00"))
                    End If
                End If
            Next
            itm = 0

            'Here we have the balance as at the date of the statement print not the current balance
            dblCurrentStatementBalance = dblBalanceAtEndDate 'dblBalance
            'Adjustment of the moving balance ***

            arrStatementDetails = New ArrayList
            arrStatementDetails = strStatementArray

            If dblCummulativeStatementBalance <> 0 Or dblBalance <> 0 Then
                boolDirectPrinting = True
                gwt_comm.PrintCustomerDocument(intSelectedTransaction, "STATEMENT")
            End If


            Me.ProgressBarItem1.Value = Me.ProgressBarItem1.Value + 1

        End While

        Me.ProgressBarItem1.Value = Me.ProgressBarItem1.Maximum

        MessageBox.Show("Printing Completed Successfully", "Statements Print", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to print Customer Statements"
        ShowErrorMessage()
    End Sub

    Private Sub PrintCustomerBalances()

        Cursor = Cursors.WaitCursor

        Dim arrCustomers As New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM Customers ORDER BY AccountName", cnn)
        Dim objReaderCustomers As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReaderCustomers.Read
            Dim dblBalance As Double = gwt_comm.GetBalance(objReaderCustomers(0).ToString)
            'If boolIncludeZeroBalance = False Then
            If dblBalance <> 0 Then
                arrCustomers.Add(UCase(objReaderCustomers(0).ToString) & ";" & UCase(objReaderCustomers(1).ToString) & ";" & dblBalance & ";")
            End If
        End While

        'Send the information to the printer

        Dim strPrintDetails(0 To arrCustomers.Count - 1) As String
        For i As Integer = 0 To arrCustomers.Count - 1
            strPrintDetails(i) = arrCustomers.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 4
            .strColumnHeaders = "CUSTOMER NAME|ACCOUNT NO|AMOUNT|"
            .strColumnAlignments = "0|0|2|0"
            .strColumnWidths = "150|250|100|100"
            .strFooterCaption = "Customer balances report"
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = "CUSTOMER BALANCES"
            '.strMainHeader3 = "PERIOD COVERED " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " - " & UCase(Format(EndDate, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|YES|NO"
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
            .boolPrintTotals = True
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|YES|NO"
            .strSummaryTotals = "NO|NO|YES|NO"
            '.intKeyFieldIndex = 7
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Balance printing"
        ShowErrorMessage()
    End Sub

    Private Sub PrintCustomerBalancesAtSpecifiedDate()

        Cursor = Cursors.WaitCursor

        boolAbort = False
        gwt_comm.DateSpecification()
        If boolAbort = True Then Exit Sub

        Dim arrCustomers As New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM Customers ORDER BY AccountName", cnn)
        Dim objReaderCustomers As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReaderCustomers.Read
            Dim dblBalance As Double = gwt_comm.CustomerBalanceOnSpecificDate(objReaderCustomers(0).ToString, dtSetDate)
            If dblBalance <> 0 Then
                arrCustomers.Add(UCase(objReaderCustomers(0).ToString) & ";" & UCase(objReaderCustomers(1).ToString) & ";" & dblBalance & ";")
            End If
        End While

        'Send the information to the printer

        Dim strPrintDetails(0 To arrCustomers.Count - 1) As String
        For i As Integer = 0 To arrCustomers.Count - 1
            strPrintDetails(i) = arrCustomers.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 4
            .strColumnHeaders = "CUSTOMER NAME|ACCOUNT NO|AMOUNT|"
            .strColumnAlignments = "0|0|2|0"
            .strColumnWidths = "150|250|100|100"
            .strFooterCaption = "Customer balances report"
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = "CUSTOMER BALANCES AS AT " & UCase(gwt_comm.shortMonthDateFormat(dtSetDate))
            '.strMainHeader3 = "PERIOD COVERED " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " - " & UCase(Format(EndDate, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|YES|NO"
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
            .boolPrintTotals = True
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|YES|NO"
            .strSummaryTotals = "NO|NO|YES|NO"
            '.intKeyFieldIndex = 7
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Balance printing"
        ShowErrorMessage()
    End Sub

    Private Sub LoadTransactions(AccountNumber As String)
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        If UCase(strTaxComputationType) = "INCLUSIVE" Then
            strSql = "SELECT CONVERT(NVARCHAR, TransDate, 102) as [Date], InvoiceNumber, " _
                & "CAST(SUM((SalesPrice * Quantity) - DiscountAllowed) AS DECIMAL (10,2)) as [Paid] " _
                & "FROM CustomerSales WHERE CustomerId = '" & AccountNumber & "' " _
                & "GROUP BY TransDate, InvoiceNumber ORDER BY TransDate"
        Else
            strSql = "SELECT CONVERT(NVARCHAR, TransDate, 102) as [Date], InvoiceNumber, " _
                & "CAST(SUM((SalesPrice * Quantity) - DiscountAllowed + Taxes) AS DECIMAL (10,2)) as [Paid] " _
                & "FROM CustomerSales WHERE CustomerId = '" & AccountNumber & "' " _
                & "GROUP BY TransDate, InvoiceNumber ORDER BY TransDate"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrTransactions As New ArrayList
        While objReader.Read
            Dim strLine As String = Nothing
            For n As Integer = 0 To objReader.FieldCount - 1
                If n = 2 Then
                    strLine = strLine & ";POSTED INVOICE;0;" & objReader(n).ToString
                Else
                    strLine = strLine & ";" & objReader(n).ToString
                End If
            Next
            strLine = Mid(strLine, 2, (strLine.Length - 1)) & ";"
            arrTransactions.Add(strLine & ";INVOICE")
        End While
        objReader.Close()
        'Get the payments
        strSql = "SELECT CONVERT(NVARCHAR, TransactionDate, 102) AS [Dte], [ReferenceNumber], " _
            & "[Description], CAST(Amount AS DECIMAL (10,2)) AS [Amt] FROM CustomerTransactions " _
            & "WHERE AccountNumber = '" & AccountNumber & "' ORDER BY TransactionDate"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        Dim strLastPaymentAmount As String = "0.00"
        Dim strLastPaymentDate As String = Nothing
        While objReader.Read
            arrTransactions.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" _
                & objReader(2).ToString & ";1;;" & objReader(3).ToString & ";PAYMENT")
            If IsDate(objReader(0).ToString) Then strLastPaymentDate = Format(CDate(objReader(0).ToString), "dd-MM-yyyy")
            If IsNumeric(objReader(3).ToString) Then strLastPaymentAmount = CStr(Format(CDbl(objReader(3).ToString), "##0.00"))
        End While
        objReader.Close()

        'Get the credit note entries
        strSql = "SELECT CONVERT(NVARCHAR, CreditNotesMain.TransDate, 102) as [Date], CreditNoteEntries.NoteNumber, " _
            & "CreditNoteEntries.Description, SUM(CreditNoteEntries.Quantity) as [Qty], " _
            & "CAST(SUM((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity) + CreditNoteEntries.Taxes) AS DECIMAL (10,2)) as [Paid] " _
            & "FROM CreditNoteEntries, CreditNotesMain WHERE CreditNoteEntries.NoteNumber = CreditNotesMain.NoteNumber " _
            & "AND CreditNotesMain.AccountId = '" & AccountNumber & "' AND ((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity) - 0) > 0 " _
            & "GROUP BY CreditNotesMain.TransDate, CreditNoteEntries.NoteNumber, CreditNoteEntries.Description " _
            & "ORDER BY CreditNotesMain.TransDate"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            arrTransactions.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" _
                & objReader(2).ToString & ";" & objReader(3).ToString & ";;" & objReader(4).ToString & ";CREDIT NOTE")
        End While
        objReader.Close()

        If arrTransactions.Count > 0 Then arrTransactions.Sort()

        Dim dblDebitTotal As Double = 0
        Dim dblCreditTotal As Double = 0
        Dim dblBalance As Double = 0
        dGridTransactions.Rows.Clear()
        For i As Integer = 0 To arrTransactions.Count - 1
            dGridTransactions.Rows.Add(1)
            Dim strValues() As String = Split(arrTransactions(i), ";")
            For n As Integer = 0 To strValues.Length - 1
                With dGridTransactions
                    If n = 0 Then
                        'Format the date. Its in the format 2013.03.31
                        Dim strDate As String = Nothing
                        Dim strDateParts() As String = Split(strValues(0), ".")
                        strDate = strDateParts(2) & "-" & strDateParts(1) & "-" & strDateParts(0) 'UCase(MonthName(CInt(strDateParts(1)), True))
                        .Rows(.Rows.Count - 1).Cells(n).Value = UCase(strDate)
                    Else
                        .Rows(.Rows.Count - 1).Cells(n).Value = strValues(n)
                    End If
                End With
            Next n
            If IsNumeric(strValues(strValues.Length - 3)) Then
                dblDebitTotal = dblDebitTotal + CDbl(strValues(strValues.Length - 3))
            End If
            If IsNumeric(strValues(strValues.Length - 2)) Then
                dblCreditTotal = dblCreditTotal + CDbl(strValues(strValues.Length - 2))
            End If
        Next
        dblBalance = dblDebitTotal - dblCreditTotal

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Transactions Load"
        ShowErrorMessage()
    End Sub

    Private Sub PrintAgingAnalysis(Optional PrintOptions As String = "MENU")

        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim arrCustomerDetails As New ArrayList

        If PrintOptions = "MENU" Then

            boolAbort = False
            Dim f As New frmAgingAnalysisParameters
            f.ShowDialog()
            If boolAbort = True Then Exit Sub

            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM Customers ORDER BY AccountName", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReader.Read
                Dim dblBalance As Double = gwt_comm.CustomerBalanceOnSpecificDate(objReader(0).ToString, dtSetDate)
                If dblBalance <> 0 Then
                    Dim dblAgingBalances() As Double = gwt_comm.AgingBalances(dblBalance, intAgingIntervals, intAgingDaysPerPeriod, dtSetDate, objReader(0).ToString)
                    Dim dblCurrentPeriodBalance As Double = gwt_comm.BalanceFromCutoffToCurrent(objReader(0).ToString, dtSetDate)
                    Dim dblTotalBalance As Double = gwt_comm.CustomerBalanceOnSpecificDate(objReader(0).ToString, gwt_comm.shortMonthDateFormat(Now))
                    Dim strDetail As String = objReader(0).ToString & "|" & objReader(1).ToString & "|" & Format(dblCurrentPeriodBalance, "##0.00")

                    If dblBalance <= 0 Then
                        For p As Integer = 0 To dblAgingBalances.Length - 1
                            dblAgingBalances(p) = 0
                        Next
                    End If

                    For j As Integer = 0 To dblAgingBalances.Length - 1
                        strDetail = strDetail & "|" & Format(dblAgingBalances(j), "##0.00")
                    Next
                    strDetail = strDetail & "|" & Format(dblTotalBalance, "##0.00")
                    arrCustomerDetails.Add(strDetail)
                End If
            End While

        Else
            With dGridPreview
                For j As Integer = 0 To .RowCount - 1
                    Dim strLineDetails As String = Nothing
                    For c As Integer = 0 To .Columns.Count - 1
                        Dim strValue As String = Nothing
                        If Not Object.Equals(.Rows(j).Cells(c).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.Rows(j).Cells(c).Value.ToString) Then
                                strValue = .Rows(j).Cells(c).Value.ToString
                            End If
                        End If
                        strLineDetails = strLineDetails & strValue & "|"
                    Next
                    strLineDetails = Mid(strLineDetails, 1, strLineDetails.Length - 1)
                    arrCustomerDetails.Add(strLineDetails)
                Next
            End With
        End If

        'Get the aging headers

        Dim strAgingHeaders As String = Nothing
        Dim strAgingHeadersWidth As String = Nothing
        Dim strAgingColumnTotals As String = Nothing
        Dim strAgingColumnAlignment As String = Nothing
        Dim strVisibleColumns As String = Nothing

        If arrCustomerDetails.Count > 0 Then
            Dim strFields() As String = Split(arrCustomerDetails.Item(0), "|")
            For p As Integer = 3 To strFields.Length - 2
                Dim strPeriodHeader As String = Nothing
                If p = strFields.Length - 2 Then
                    strPeriodHeader = "OVER " & CStr((intAgingDaysPerPeriod * (p - 3)) + intAgingDaysPerPeriod) & " DAYS"
                Else
                    strPeriodHeader = CStr((intAgingDaysPerPeriod * (p - 3)) + intAgingDaysPerPeriod) & " DAYS"
                End If
                strAgingHeaders = strAgingHeaders & strPeriodHeader & "|"
                strAgingHeadersWidth = strAgingHeadersWidth & "72|"
                strAgingColumnTotals = strAgingColumnTotals & "YES|"
                strAgingColumnAlignment = strAgingColumnAlignment & "2|"
                strVisibleColumns = strVisibleColumns & "YES|"
            Next
        End If

        strAgingHeaders = Mid(strAgingHeaders, 1, strAgingHeaders.Length - 1)
        strAgingHeadersWidth = Mid(strAgingHeadersWidth, 1, strAgingHeadersWidth.Length - 1)
        strAgingColumnTotals = Mid(strAgingColumnTotals, 1, strAgingColumnTotals.Length - 1)
        strAgingColumnAlignment = Mid(strAgingColumnAlignment, 1, strAgingColumnAlignment.Length - 1)
        strVisibleColumns = Mid(strVisibleColumns, 1, strVisibleColumns.Length - 1)

        'Send the details to print here

        Dim strPrintDetails(0 To arrCustomerDetails.Count - 1) As String
        For i As Integer = 0 To arrCustomerDetails.Count - 1
            strPrintDetails(i) = Replace(arrCustomerDetails.Item(i), "|", ";", 1)
        Next

        Dim strCols As String = "ACCOUNT NO|CUSTOMER NAME|CURRENT|" & strAgingHeaders & "|TOTAL"
        Dim strBuffer() As String = Split(strCols, "|")
        Dim intNumberOfColumns As Integer = strBuffer.Length

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = intNumberOfColumns
            .strColumnHeaders = "ACCOUNT|NAME|CURRENT|" & strAgingHeaders & "|TOTAL"
            .strColumnWidths = "80|160|72|" & strAgingHeadersWidth & "|72"
            .strColumnAlignments = "0|0|2|" & strAgingColumnAlignment & "|2"
            .strFooterCaption = strReportHeader
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = UCase(strReportHeader)
            .strMainHeader3 = "PERIOD COVERED " & UCase(gwt_comm.shortMonthDateFormat(StartDate)) & " - " & UCase(gwt_comm.shortMonthDateFormat(EndDate))
            .strColumnTotals = "NO|NO|YES|" & strAgingColumnTotals & "|YES"
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
            .VisibleColumns = "YES|YES|YES|" & strVisibleColumns & "|YES"
            .strColumnFormating = "NO|NO|YES|" & strVisibleColumns & "|YES"
            .strSummaryTotals = "NO|NO|YES|" & strVisibleColumns & "|YES"
            '.intKeyFieldIndex = 7
            .strPrintValues = strPrintDetails
        End With

        boolAbort = False
        gwt_comm.PrinterSelection()
        If boolAbort = True Then Exit Sub

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On age analysis print"
        ShowErrorMessage()
    End Sub

    Private Sub loadProformaEmployees()
        On Error GoTo RaiseErr
        'Load the employee details
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames " _
            & "AS [EmployeeDetails] FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        cboUserProforma.Items.Clear()
        cboUserProforma.Items.Add("ALL")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboUserProforma.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadProformas(BeginingDate As Date, EndingDate As Date)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing

        If UCase(cboUserProforma.Text) = "ALL" Then
            strSql = "SELECT ReferenceNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], CustomerName, " _
                & "CAST(QuoteValue AS DECIMAL (10,2)) AS [Value], CAST(TotalDiscount AS DECIMAL (10,2)) AS [Discounts], " _
                & "CAST(TotalTaxes AS DECIMAL (10,2)) AS [Taxes] FROM ProformaMain WHERE TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(BeginingDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndingDate) & "'"
        Else
            If String.IsNullOrEmpty(cboUserProforma.Text) Then
                strSql = "SELECT ReferenceNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], CustomerName, " _
                & "CAST(QuoteValue AS DECIMAL (10,2)) AS [Value], CAST(TotalDiscount AS DECIMAL (10,2)) AS [Discounts], " _
                & "CAST(TotalTaxes AS DECIMAL (10,2)) AS [Taxes] FROM ProformaMain WHERE TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(BeginingDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndingDate) & "'"
            Else
                strSql = "SELECT ReferenceNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], CustomerName, " _
                    & "CAST(QuoteValue AS DECIMAL (10,2)) AS [Value], CAST(TotalDiscount AS DECIMAL (10,2)) AS [Discounts], " _
                    & "CAST(TotalTaxes AS DECIMAL (10,2)) AS [Taxes] FROM ProformaMain WHERE TransDate BETWEEN " _
                    & "'" & gwt_comm.shortMonthDateFormat(BeginingDate) & "' " _
                    & "AND '" & gwt_comm.shortMonthDateFormat(EndingDate) & "' AND SalesAgent = '" & cboUserProforma.Text & "'"
            End If
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim i As Integer = 0
        dGridProformas.Rows.Clear()
        While objReader.Read
            dGridProformas.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridProformas.Rows(i).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridProformas.Rows(i).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGridProformas.Rows(i).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dGridProformas.Rows(i).Cells(3).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then dGridProformas.Rows(i).Cells(4).Value = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then dGridProformas.Rows(i).Cells(5).Value = objReader(5).ToString
            i = i + 1
        End While
        objReader.Read()

        'Calculate totals
        Dim dblMovingT As Double = 0
        Dim dblMovingTx As Double = 0
        Dim dblMovingDs As Double = 0
        Dim strValue As String
        For i = 0 To dGridProformas.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGridProformas.Rows(i).Cells(3).Value), "")) Then
                strValue = Convert.ToString(dGridProformas.Rows(i).Cells(3).Value)
                If IsNumeric(strValue) Then
                    dblMovingT = dblMovingT + CDbl(strValue)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridProformas.Rows(i).Cells(4).Value), "")) Then
                strValue = Convert.ToString(dGridProformas.Rows(i).Cells(4).Value)
                If IsNumeric(strValue) Then
                    dblMovingTx = dblMovingTx + CDbl(strValue)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridProformas.Rows(i).Cells(5).Value), "")) Then
                strValue = Convert.ToString(dGridProformas.Rows(i).Cells(5).Value)
                If IsNumeric(strValue) Then
                    dblMovingDs = dblMovingDs + CDbl(strValue)
                End If
            End If
        Next
        lblTotalProforma.Text = Format(dblMovingT, "#,##0.00")
        lblTaxesProforma.Text = Format(dblMovingTx, "#,##0.00")
        lblDiscountsProforma.Text = Format(dblMovingDs, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmProformaInvoiceListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadProformaEmployees()
    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoProforma.Click
        LoadProformas(dpStartFromProforma.Value, dpEndToProforma.Value)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditProforma.Click
        If IntPublicInvoicing = 0 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        If dGridProformas.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridProformas.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridProformas.CurrentRow.Cells(0).Value.ToString) Then
                boolEditStatusTwo = True
                intSelectedTransaction = CInt(dGridProformas.CurrentRow.Cells(0).Value.ToString)
                Dim f As New frmProformaInvoice
                f.ShowDialog()
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Quotations Analysis"
        ShowErrorMessage()
    End Sub

    Private Sub dGridProformas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridProformas.CellClick
        If IntPublicInvoicing <> 2 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        If dGridProformas.Rows.Count <= 0 Then Exit Sub
        If dGridProformas.CurrentCell.ColumnIndex <> 6 Then Exit Sub
        'DeleteDocument()
    End Sub

    Private Sub DeleteDocument()
        On Error GoTo RaiseErr

        If Not (Object.Equals(Convert.ToString(dGridProformas.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridProformas.CurrentRow.Cells(0).Value.ToString) Then
                boolEditStatusTwo = True
                intSelectedTransaction = CInt(dGridProformas.CurrentRow.Cells(0).Value.ToString)
                If MessageBox.Show("Are you sure you want to delete this document?", "Confirm Proforma Invoice Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim objDelete As New Data.OleDb.OleDbCommand("DELETE FROM ProformaMain WHERE ReferenceNumber = " & intSelectedTransaction, cnn)
                    objDelete.ExecuteNonQuery()
                    objDelete = New Data.OleDb.OleDbCommand("DELETE FROM ProformaDetails WHERE ReferenceNumber = " & intSelectedTransaction, cnn)
                    objDelete.ExecuteNonQuery()
                    LoadProformas(dpStartFromProforma.Value, dpEndToProforma.Value)
                    MessageBox.Show("Proforma Invoice deleted successfully", "Proforma Invoice Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Cursor = Cursors.Default
                End If
            End If
        End If

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Proforma Invoice Delete"
        ShowErrorMessage()
    End Sub

    Private Sub dGridProformas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridProformas.DoubleClick
        If IntPublicInvoicing = 0 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        If dGridProformas.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridProformas.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridProformas.CurrentRow.Cells(0).Value.ToString) Then
                boolEditStatusTwo = True
                intSelectedTransaction = CInt(dGridProformas.CurrentRow.Cells(0).Value.ToString)
                Dim f As New frmProformaInvoice
                f.ShowDialog()
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Proforma Invoice Analysis"
        ShowErrorMessage()
    End Sub

    Private Sub GenerateProformaTransactionDocument(ByVal intDocumentNumber As Integer)
        'get invoice number
        On Error GoTo RaiseErr
        Dim n As Integer = 0
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim myCommand As Data.OleDb.OleDbCommand

        myCommand = New Data.OleDb.OleDbCommand("Select CONVERT(NVARCHAR, TransDate, 105) as [TransDate], CustomerName, " _
            & "Address1, Address2, Address3, Address4, ContactNumber, EmailAddress, QuoteValue, TotalTaxes, TotalDiscount, " _
            & "TaxNumber, Terms FROM ProformaMain Where ReferenceNumber = " & intDocumentNumber & "", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            If Not IsDBNull(dbReader(0).ToString) Then strDate = dbReader(0).ToString
            If Not IsDBNull(dbReader(1).ToString) Then strCustomerName = dbReader(1).ToString
            If Not IsDBNull(dbReader(2).ToString) Then strCustomerAddress1 = dbReader(2).ToString
            If Not IsDBNull(dbReader(3).ToString) Then strCustomerAddress2 = dbReader(3).ToString
            If Not IsDBNull(dbReader(4).ToString) Then strCustomerAddress3 = dbReader(4).ToString
            If Not IsDBNull(dbReader(5).ToString) Then strCustomerAddress4 = dbReader(5).ToString
            If Not IsDBNull(dbReader(6).ToString) Then strCustomerTelephone = dbReader(6).ToString
            If Not IsDBNull(dbReader(7).ToString) Then strCustomerEmailAddress = dbReader(7).ToString
            If IsNumeric(dbReader(8).ToString) Then dblInvoiceTotal = CDbl(dbReader(8).ToString) Else dblInvoiceTotal = 0
            If IsNumeric(dbReader(9).ToString) Then dblTaxes = dbReader(9).ToString Else dblTaxes = 0
            If IsNumeric(dbReader(10).ToString) Then dblDiscounts = dbReader(10).ToString Else dblDiscounts = 0
            If Not IsDBNull(dbReader(11).ToString) Then strCustomerVatNumber = dbReader(11).ToString
            If Not IsDBNull(dbReader(12).ToString) Then strTermsAndConditions = dbReader(12).ToString
        End If
        dbReader.Close()

        myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity, ItemCode, Description, UnitPrice, " _
            & "Discount, Tax, Payable from ProformaDetails where ReferenceNumber = " & intDocumentNumber & "", cnn)
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Proforma Invoice Generation Error"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintSummaryProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintSummaryProforma.Click
        gwt_comm.PrintDataGrid(dGridProformas, "PROFORMA INVOICES SUMMARY FROM " & UCase(gwt_comm.shortMonthDateFormat(dpStartFromProforma.Value)) & " TO " &
            UCase(gwt_comm.shortMonthDateFormat(dpEndToProforma.Value)))
    End Sub

    Private Sub btnNewProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewProforma.Click
        If IntPublicInvoicing <> 2 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        boolEditStatusTwo = False
        Dim f As New frmProformaInvoice
        f.ShowDialog()
    End Sub

    Private Sub btnPrintSelectedProforma_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSelectedProforma.Click
        If dGridProformas.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridProformas.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridProformas.CurrentRow.Cells(0).Value.ToString) Then
                intSelectedTransaction = CInt(dGridProformas.CurrentRow.Cells(0).Value.ToString)
                boolPrinterAlreadySelected = False
                gwt_comm.PrintCustomerDocument(intSelectedTransaction, "PROFORMA")
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Proforma Invoice Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnDeleteProforma_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteProforma.Click
        If IntPublicInvoicing <> 2 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        If dGridProformas.Rows.Count <= 0 Then Exit Sub
        DeleteDocument()
    End Sub

    Private Sub btnRefreshProforma_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshProforma.Click
        LoadProformas(dpStartFromProforma.Value, dpEndToProforma.Value)
    End Sub

    Private Sub dGridCustomers_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridCustomers.CellDoubleClick
        If e.RowIndex <= 0 Then Exit Sub
        If IntPublicCustomers <> 2 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        EditCustomerDetails()
    End Sub

    Private Sub tvReports_AfterSelect(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvReports.AfterSelect
        strReportHeader = UCase(tvReports.SelectedNode.Text)
        dGridPreview.Columns.Clear()
        Select Case UCase(strReportHeader)
            Case Is = UCase("Customer Balances")
                PreviewCustomerBalances()
            Case Is = UCase("A/R Aging Analysis")
                PreviewAgingAnalysis()
        End Select
    End Sub

    Private Sub tvReports_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvReports.DoubleClick
        On Error GoTo RaiseErr
        If Not Object.Equals(tvReports.SelectedNode, Nothing) Then
            strReportHeader = UCase(tvReports.SelectedNode.Text)
            PrintSelectedReport(strReportHeader)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Report Preview Error"
        ShowErrorMessage()
    End Sub

    Private Sub PrintSelectedReport(strSelectedNodeText As String, Optional PrintedFrom As String = Nothing)
        On Error GoTo RaiseErr
        Select Case UCase(strSelectedNodeText)
            Case Is = UCase("Customer Balances")
                PrintCustomerBalances()
            Case Is = UCase("Customer Balances At Specified Date")
                PrintCustomerBalancesAtSpecifiedDate()
            Case Is = UCase("Customer Statements")
                PrintCustomerStatements()
            Case Is = UCase("A/R Aging Analysis")
                If String.IsNullOrEmpty(PrintedFrom) Then
                    PrintAgingAnalysis()
                Else
                    PrintAgingAnalysis("PREVIEW")
                End If
        End Select

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Report Print Error"
        ShowErrorMessage()
    End Sub

    Private Sub PreviewCustomerBalances()
        On Error GoTo RaiseErr
        Dim arrCustomers As New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM Customers ORDER BY AccountName", cnn)
        Dim objReaderCustomers As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReaderCustomers.Read
            Dim dblBalance As Double = gwt_comm.GetBalance(objReaderCustomers(0).ToString)
            If dblBalance <> 0 Then
                arrCustomers.Add(UCase(objReaderCustomers(0).ToString) & "|" & UCase(objReaderCustomers(1).ToString) & "|" & dblBalance & "|")
            End If
        End While

        With dGridPreview
            .Columns.Add("AccountNo", "Account Number")
            .Columns.Add("AccountName", "Account Holder Name")
            .Columns.Add("Balance", "Balance")

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            For p As Integer = 0 To arrCustomers.Count - 1
                Dim strBuffer() As String = Split(arrCustomers.Item(p), "|")
                Dim dblBalance As Double = 0
                If IsNumeric(strBuffer(2)) Then dblBalance = CDbl(strBuffer(2))
                .Rows.Add(strBuffer(0), strBuffer(1), Format(dblBalance, "#,##0.00"))
            Next
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Report Preview Error"
        ShowErrorMessage()
    End Sub

    Private Sub PreviewAgingAnalysis()
        On Error GoTo RaiseErr

        boolAbort = False
        Dim f As New frmAgingAnalysisParameters
        f.ShowDialog()
        If boolAbort = True Then Exit Sub

        Cursor = Cursors.WaitCursor

        Dim arrCustomerDetails As New ArrayList

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM Customers ORDER BY AccountName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim dblBalance As Double = gwt_comm.CustomerBalanceOnSpecificDate(objReader(0).ToString, dtSetDate)
            If dblBalance <> 0 Then
                Dim dblAgingBalances() As Double = gwt_comm.AgingBalances(dblBalance, intAgingIntervals, intAgingDaysPerPeriod, dtSetDate, objReader(0).ToString)
                Dim dblCurrentPeriodBalance As Double = gwt_comm.BalanceFromCutoffToCurrent(objReader(0).ToString, dtSetDate)
                Dim dblTotalBalance As Double = gwt_comm.CustomerBalanceOnSpecificDate(objReader(0).ToString, gwt_comm.shortMonthDateFormat(Now))
                Dim strDetail As String = objReader(0).ToString & "|" & objReader(1).ToString & "|" & Format(dblCurrentPeriodBalance, "##0.00")

                If dblBalance <= 0 Then
                    For p As Integer = 0 To dblAgingBalances.Length - 1
                        dblAgingBalances(p) = 0
                    Next
                End If

                For j As Integer = 0 To dblAgingBalances.Length - 1
                    strDetail = strDetail & "|" & Format(dblAgingBalances(j), "##0.00")
                Next
                strDetail = strDetail & "|" & Format(dblTotalBalance, "##0.00")
                arrCustomerDetails.Add(strDetail)
            End If
        End While

        If arrCustomerDetails.Count > 0 Then
            Dim strFields() As String = Split(arrCustomerDetails.Item(0), "|")
            With dGridPreview
                For p As Integer = 0 To strFields.Length - 1
                    .Columns.Add("Column" & CStr((p + 1)), "")
                Next
                .Columns(0).HeaderText = "Account #"
                .Columns(1).HeaderText = "Account Holder Name"
                .Columns(2).HeaderText = "Current"
                .Columns(.Columns.Count - 1).HeaderText = "Total"

                For p As Integer = 3 To strFields.Length - 2
                    Dim strPeriodHeader As String = Nothing
                    If p = strFields.Length - 2 Then
                        strPeriodHeader = "OVER " & CStr((intAgingDaysPerPeriod * (p - 3)) + intAgingDaysPerPeriod) & " DAYS"
                    Else
                        strPeriodHeader = CStr((intAgingDaysPerPeriod * (p - 3)) + intAgingDaysPerPeriod) & " DAYS"
                    End If
                    .Columns(p).HeaderText = strPeriodHeader
                Next

                For p As Integer = 0 To arrCustomerDetails.Count - 1
                    strFields = Split(arrCustomerDetails.Item(p), "|")
                    .Rows.Add(1)
                    For n As Integer = 0 To strFields.Length - 1
                        If n > 1 Then
                            If IsNumeric(strFields(n)) Then
                                strFields(n) = Format(CDbl(strFields(n)), "#,##0.00")
                            End If
                        End If
                        .Rows(.Rows.Count - 1).Cells(n).Value = strFields(n)
                    Next
                Next

                For p As Integer = 0 To .Columns.Count - 1
                    .Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    If p > 1 Then
                        .Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If
                Next
            End With
        End If

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Report Preview Error"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintPreview_Click(sender As Object, e As System.EventArgs) Handles btnPrintPreview.Click
        On Error GoTo RaiseErr
        If Not Object.Equals(tvReports.SelectedNode, Nothing) Then
            strReportHeader = UCase(tvReports.SelectedNode.Text)
            If UCase(strReportHeader) = UCase("A/R Aging Analysis") Then
                PrintSelectedReport(strReportHeader, "PREVIEW")
                Exit Sub
            End If
            PrintSelectedReport(strReportHeader)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Report Preview Error"
        ShowErrorMessage()
    End Sub

    Private Sub btnDeleteInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteInvoice.Click
        If grd.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        If Not (Object.Equals(Convert.ToString(grd.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(grd.CurrentRow.Cells(0).Value.ToString) Then
                'boolEditStatusTwo = True
                intSelectedTransaction = CInt(grd.CurrentRow.Cells(0).Value.ToString)
                If MessageBox.Show("Are you sure you want to delete this document?", "Confirm Proforma Invoice Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim objDelete As New Data.OleDb.OleDbCommand("DELETE FROM CustomerSalesMain WHERE InvoiceNumber = " & intSelectedTransaction, cnn)
                    objDelete.ExecuteNonQuery()
                    objDelete = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSales WHERE InvoiceNumber = " & intSelectedTransaction, cnn)
                    objDelete.ExecuteNonQuery()

                    'Get the customer number for the invoice
                    Dim strCustomerNumber As String = Nothing
                    objDelete = New Data.OleDb.OleDbCommand("SELECT CustomerSalesMain.CustomerId FROM CustomerSalesMain " _
                        & "WHERE CustomerSalesMain.InvoiceNumber = " & intSelectedTransaction & "", cnn)
                    Dim objReader As Data.OleDb.OleDbDataReader = objDelete.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        If Not IsDBNull(objReader(0).ToString) Then
                            strCustomerNumber = objReader(0).ToString
                        End If
                    End If
                    objReader.Close()

                    'Remove the invoice from the customer transaction table as well
                    Dim strSql As String = "DELETE FROM CustomerTransactions WHERE ReferenceNumber = '" & intSelectedTransaction & "' " _
                        & "AND AccountNumber = '" & strCustomerNumber & "' AND TransactionType = 'INVOICE'"
                    objDelete = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objDelete.ExecuteNonQuery()

                    LoadInvoice(CDate(gwt_comm.shortMonthDateFormat(StartDate)), CDate(gwt_comm.shortMonthDateFormat(EndDate)))

                    MessageBox.Show("Invoice deleted successfully", "Proforma Invoice Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Cursor = Cursors.Default
                End If
            End If
        End If

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Proforma Invoice Analysis"
        ShowErrorMessage()
    End Sub

    Private Sub btnPayments_Click(sender As Object, e As EventArgs) Handles btnPayments.Click
        boolAbort = False
        Dim frm1 As New frmCashbookSelection
        frm1.ShowDialog()
        If boolAbort = True Then Exit Sub
        Dim frm2 As New frmAdvanceInvoiceSettlement
        frm2.ShowDialog()
    End Sub

    Private Sub txtSearchString_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If chkActiveSearch.Checked = True Then
            If Char.IsLetter(e.KeyChar) Then
                LoadCustomerData(txtSearchString.Text)
            End If
        Else
            If Asc(e.KeyChar) = 13 Then
                LoadCustomerData(txtSearchString.Text)
            End If
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        LoadCustomerData(txtSearchString.Text)
    End Sub

    Private Sub mnuOpen_Click(sender As System.Object, e As System.EventArgs) Handles mnuOpen.Click
        If IntPublicCustomers <> 2 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        EditCustomerDetails()
    End Sub

    Private Sub mnuDeleteCustomer_Click(sender As System.Object, e As System.EventArgs) Handles mnuDeleteCustomer.Click
        DeleteCustomer()
    End Sub

    Private Sub btnPrintAllCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintAllCustomers.Click

    End Sub

    Private Sub dGridCustomers_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dGridCustomers.CellMouseDown
        If e.Button = MouseButtons.Right Then
            ' Add this
            dGridCustomers.CurrentCell = dGridCustomers.Rows(e.RowIndex).Cells(e.ColumnIndex)
            ' Can leave these here - doesn't hurt
            dGridCustomers.Rows(e.RowIndex).Selected = True
            dGridCustomers.Focus()
        End If
    End Sub

    Private Sub mnuNewInvoice_Click(sender As System.Object, e As System.EventArgs) Handles mnuNewInvoice.Click
        boolLoadedFromCustomerForm = True
        boolEditStatus = False
        GetSelectedCustomer()
        Dim frm As New frmInvoice
        frm.ShowDialog()
        boolLoadedFromCustomerForm = False
    End Sub

    Private Sub mnuNewCustomerQuote_Click(sender As System.Object, e As System.EventArgs) Handles mnuNewCustomerQuote.Click
        boolLoadedFromCustomerForm = True
        boolEditStatus = False
        GetSelectedCustomer()
        Dim frm As New frmQuotation
        frm.ShowDialog()
        boolLoadedFromCustomerForm = False
    End Sub

    Private Sub mnuReceivePayment_Click(sender As System.Object, e As System.EventArgs) Handles mnuReceivePayment.Click
        boolLoadedFromCustomerForm = True
        boolEditStatus = False
        GetSelectedCustomer()
        boolAbort = False
        Dim frm1 As New frmCashbookSelection
        frm1.ShowDialog()
        If boolAbort = True Then Exit Sub
        Dim frm2 As New frmAdvanceInvoiceSettlement
        frm2.ShowDialog()
        boolLoadedFromCustomerForm = False
    End Sub

    Private Sub mnuPrintCustomerStatement_Click(sender As System.Object, e As System.EventArgs) Handles mnuPrintCustomerStatement.Click
        GetSelectedCustomer()
        Dim prntCom As New CommonLibrary.Commons.CommonFunctions
        prntCom.PrintCustomerStatement(strSelectedAccount)
    End Sub

    Private Sub mnuNewCashsale_Click(sender As System.Object, e As System.EventArgs) Handles mnuNewCashsale.Click
        boolLoadedFromCustomerForm = True
        boolEditStatus = False
        GetSelectedCustomer()
        boolAbort = False
        Dim frm1 As New frmCashbookSelection
        frm1.ShowDialog()
        If boolAbort = True Then Exit Sub
        Dim frm2 As New frmCustomerCashSale
        frm2.ShowDialog()
        boolLoadedFromCustomerForm = False
    End Sub

    Private Sub mnuNewCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles mnuNewCreditNote.Click
        boolLoadedFromCustomerForm = True
        boolEditStatus = False
        GetSelectedCustomer()
        boolAbort = False
        Dim frm As New frmCreditNoteEntry
        frm.ShowDialog()
    End Sub

End Class
