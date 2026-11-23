Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Net
Imports System.Management
Imports System.Management.Instrumentation
Imports System.Drawing
Imports ComponentFactory.Krypton.Toolkit
Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCreditNotesListings

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

    Private Sub frmCreditNotes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        strCalledBy = "CUSTOMERS"
        LoadCreditData(dpStartCreditNote.Value, dpEndCreditNote.Value)
    End Sub


    Private Sub btnNewCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles btnNewCreditNote.Click
        boolEditStatus = False
        Dim frm As New frmDebitCreditNoteEntry
        frm.ShowDialog()
        LoadCreditData(dpStartCreditNote.Value, dpEndCreditNote.Value)
    End Sub

    Private Sub btnEditCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles btnEditCreditNote.Click
        If dGridCreditNotes.Rows.Count > 0 Then
            GetSelectedCreditNote()
            boolEditStatusTwo = True
            Dim frm As New frmDebitCreditNoteEntry
            frm.ShowDialog()
            LoadCreditData(dpStartCreditNote.Value, dpEndCreditNote.Value)
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
        LoadCreditData(CDate(gwt_comm.shortMonthDateFormat(dpStartCreditNote.Value)), CDate(gwt_comm.shortMonthDateFormat(dpEndCreditNote.Value)))
    End Sub

    Private Sub btnPrintCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintCreditNote.Click
        If dGridCreditNotes.Rows.Count <= 0 Then Exit Sub
        Dim intDocument As Integer = 0
        If Not Object.Equals(Convert.ToString(dGridCreditNotes.CurrentRow.Cells(1).Value), "") Then
            If IsNumeric(dGridCreditNotes.CurrentRow.Cells(1).Value.ToString) Then

                intSelectedTransaction = CInt(dGridCreditNotes.CurrentRow.Cells(1).Value.ToString)
                Dim strAccount As String = Nothing
                If Not Object.Equals(dGridCreditNotes.CurrentRow.Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridCreditNotes.CurrentRow.Cells(2).Value.ToString) Then
                        strAccount = dGridCreditNotes.CurrentRow.Cells(2).Value.ToString
                    End If
                End If
                DebitCreditNotePrint("CREDIT NOTE", intSelectedTransaction, strAccount)

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
            & "CAST(TransTotal AS DECIMAL (30,2)) AS [Amount] FROM CreditNotesMain " _
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
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Credit notes main details load"
        ShowErrorMessage()
    End Sub

    Private Sub mnuNewCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles mnuNewCreditNote.Click
        boolLoadedFromCustomerForm = True
        boolEditStatus = False
        GetSelectedCreditNote()
        boolAbort = False
        Dim frm As New frmCreditNoteEntry
        frm.ShowDialog()
    End Sub

    Private Sub btnListingPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnListingPrint.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim arrPrintData As New ArrayList

        For p As Integer = 0 To dGridCreditNotes.Rows.Count - 1
            Dim intDoc As Integer = 0
            Dim strDate As String = Nothing
            Dim strClient As String = Nothing
            Dim strClientName As String = Nothing
            Dim dblDiscount As Double = 0
            Dim dblTaxes As Double = 0
            Dim dblTotal As Double = 0

            With dGridCreditNotes
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

                If Not Object.Equals(.Rows(p).Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(2).Value.ToString) Then
                        strClient = .Rows(p).Cells(2).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(3).Value.ToString) Then
                        strClientName = .Rows(p).Cells(3).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(4).Value.ToString) Then
                            dblTotal = CDbl(.Rows(p).Cells(4).Value.ToString)
                        End If
                    End If
                End If
            End With

            arrPrintData.Add(CStr(intDoc) & ";" & strDate & ";" & strClient & ";" &
                             strClientName & ";" & CStr(Format(dblTotal, "##0.00")))
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
            .strColumnHeaders = "DATE|NOTE #|ACCOUNT #|ACCOUNT NAME|VALUE"
            .strColumnAlignments = "0|0|0|0|2"
            .strColumnWidths = "80|80|100|200|80"
            .strFooterCaption = "DEBIT NOTES LISTING"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "DEBIT NOTES LISTING "
            .strMainHeader3 = "PERIOD : " & UCase(gwt_comm.shortMonthDateFormat(dpStartCreditNote.Value)) & " - " & UCase(gwt_comm.shortMonthDateFormat(dpEndCreditNote.Value))
            .strColumnTotals = "NO|NO|NO|NO|YES"
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
            .VisibleColumns = "YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|YES|YES"
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

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If dGridCreditNotes.RowCount <= 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        If MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Not Object.Equals(dGridCreditNotes.CurrentRow.Cells(1).Value, Nothing) Then
                If IsNumeric(dGridCreditNotes.CurrentRow.Cells(1).Value.ToString) Then
                    intSelectedTransaction = CInt(dGridCreditNotes.CurrentRow.Cells(1).Value.ToString)
                    boolAbort = False
                    DeleteCreditNote(intSelectedTransaction)
                    If boolAbort = True Then Exit Sub
                    LoadCreditData(CDate(gwt_comm.shortMonthDateFormat(dpStartCreditNote.Value)), CDate(gwt_comm.shortMonthDateFormat(dpEndCreditNote.Value)))
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
        ShowErrorMessage()
    End Sub
End Class