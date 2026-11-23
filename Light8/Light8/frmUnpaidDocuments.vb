Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmUnpaidDocuments

    Dim strMainDetails As String
    Dim arrPrintDetails As ArrayList

    Dim prFont As New Font("Arial", 8, FontStyle.Bold)
    Dim tlFont As New Font("Arial", 8, FontStyle.Regular)
    Dim ftFont As New Font("Times New Roman", 6, FontStyle.Italic)
    Dim ItalicFont As New Font("Times New Roman", 8, FontStyle.Italic)
    Dim HeaderFont As New Font("Arial", 10, FontStyle.Bold)

    Dim intPage As Integer = 1
    Dim strSupplierName As String
    Dim strSupplierAddress1 As String
    Dim strSupplierAddress2 As String
    Dim strSupplierAddress3 As String
    Dim strSupplierAddress4 As String
    Dim strSupplierTelephone As String
    Dim strSupplierEmailAddress As String
    Dim strSupplierVatNumber As String
    Dim boolPrintFromPreview As Boolean
    Dim boolExitingWhile As Boolean
    Dim strValue As String
    Dim itm As Integer

    Dim strBuyerName As String
    Dim strOrderDate As String
    Dim strTotalValue As String

    Private Sub frmUnpaidInvoices_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If UCase(strCalledBy) = UCase("customers") Then
            Me.Text = "Unpaid Customer Invoices"
        Else
            Me.Text = "Unpaid Suppier Invoices"
        End If
        LoadUnpaids()
    End Sub

    Private Sub frmUnpaidInvoices_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 770 : Me.Height = 550
    End Sub

    Private Sub LoadUnpaids()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing
        
        If UCase(strCalledBy) = UCase("customers") Then
            'strSql = "SELECT CustomerSalesMain.InvoiceNumber AS [Doc.#], " _
            '    & "UPPER(REPLACE(CONVERT(CHAR(11), CustomerSalesMain.TransDate, 106), ' ', '-')) as [Date], " _
            '    & "Customers.AccountName AS [Client Name], CAST(CustomerSalesMain.Amount AS DECIMAL(10,2)) AS [Value], " _
            '    & "ISNULL((0 - SUM(CustomerTransactions.Amount)), 0) AS [Payments], " _
            '    & "CustomerSalesMain.Amount - SUM(CustomerTransactions.Amount) AS [Balance] " _
            '    & "FROM CustomerSalesMain LEFT OUTER JOIN Customers ON CustomerSalesMain.CustomerId = Customers.AccountNumber " _
            '    & "LEFT OUTER JOIN CustomerTransactions ON CustomerSalesMain.InvoiceNumber = CustomerTransactions.DocumentNumber " _
            '    & "WHERE CustomerSalesMain.Amount + CustomerTransactions.Amount <> 0 " _
            '    & "GROUP BY CustomerSalesMain.InvoiceNumber, CustomerSalesMain.TransDate, Customers.AccountName, CustomerSalesMain.Amount " _
            '    & "ORDER BY Customers.AccountName, CustomerSalesMain.TransDate, CustomerSalesMain.InvoiceNumber"

            strSql = "SELECT CustomerTransactions.ReferenceNumber AS [Doc.#], " _
                & "UPPER(REPLACE(CONVERT(CHAR(11), CustomerSalesMain.TransDate, 106), ' ', '-')) as [Date], Customers.AccountName AS [Client Name], " _
                & "CAST(CustomerSalesMain.Amount AS DECIMAL(10,2)) AS [Value], " _
                & "CAST((CustomerSalesMain.Amount - SUM(CustomerTransactions.Amount)) AS DECIMAL (30,2)) AS [Payments], " _
                & "CAST(SUM(CustomerTransactions.Amount) AS DECIMAL(10,2)) AS [Balance] FROM CustomerTransactions " _
                & "LEFT OUTER JOIN Customers ON CustomerTransactions.AccountNumber = Customers.AccountNumber " _
                & "LEFT OUTER JOIN CustomerSalesMain ON CustomerTransactions.ReferenceNumber = CustomerSalesMain.InvoiceNumber " _
                & "GROUP BY CustomerTransactions.ReferenceNumber, Customers.AccountName, CustomerSalesMain.Amount, CustomerSalesMain.TransDate " _
                & "ORDER BY CustomerSalesMain.TransDate, CustomerTransactions.ReferenceNumber"

        Else
            'strSql = "SELECT SupplierInvoicesMain.DocumentNumber AS [Doc.#], " _
            '    & "UPPER(REPLACE(CONVERT(CHAR(11), SupplierInvoicesMain.TransDate, 106), ' ', '-')) as [Date], " _
            '    & "Suppliers.AccountName AS [Client Name], CAST(SupplierInvoicesMain.Value AS DECIMAL(10,2)) AS [Value], " _
            '    & "ISNULL((0 - SUM(SupplierTransactions.Amount)), 0) AS [Payments], " _
            '    & "SupplierInvoicesMain.Value - SUM(SupplierTransactions.Amount) AS [Balance] " _
            '    & "FROM SupplierInvoicesMain " _
            '    & "LEFT OUTER JOIN Suppliers ON SupplierInvoicesMain.AccountNumber = Suppliers.AccountNumber " _
            '    & "LEFT OUTER JOIN SupplierTransactions ON SupplierInvoicesMain.DocumentNumber = SupplierTransactions.DocumentNumber " _
            '    & "WHERE SupplierInvoicesMain.Value + SupplierTransactions.Amount <> 0 " _
            '    & "GROUP BY SupplierInvoicesMain.DocumentNumber, SupplierInvoicesMain.TransDate, Suppliers.AccountName, SupplierInvoicesMain.Value " _
            '    & "ORDER BY Suppliers.AccountName, SupplierInvoicesMain.TransDate, SupplierInvoicesMain.DocumentNumber"
            strSql = "SELECT SupplierTransactions.ReferenceNumber AS [Doc.#], " _
                & "UPPER(REPLACE(CONVERT(CHAR(11), SupplierInvoicesMain.TransDate, 106), ' ', '-')) as [Date], Suppliers.AccountName AS [Client Name], " _
                & "CAST(SupplierInvoicesMain.Value AS DECIMAL(10,2)) AS [Value], " _
                & "CAST((SupplierInvoicesMain.Value - SUM(SupplierTransactions.Amount)) AS DECIMAL (30,2)) AS [Payments], " _
                & "CAST(SUM(SupplierTransactions.Amount) AS DECIMAL(10,2)) AS [Balance] FROM SupplierTransactions " _
                & "LEFT OUTER JOIN Suppliers ON SupplierTransactions.AccountNumber = Suppliers.AccountNumber " _
                & "LEFT OUTER JOIN SupplierInvoicesMain ON SupplierInvoicesMain.DocumentNumber = SupplierTransactions.DocumentNumber " _
                & "GROUP BY SupplierTransactions.ReferenceNumber, Suppliers.AccountName, SupplierInvoicesMain.Value, " _
                & "SupplierInvoicesMain.TransDate, SupplierInvoicesMain.DocumentNumber " _
                & "ORDER BY SupplierInvoicesMain.TransDate, SupplierInvoicesMain.DocumentNumber"

        End If

        dGrid.Columns.Clear()
        'Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        Dim dblTotal As Double = 0
        For i As Integer = 0 To dGrid.Columns.Count - 1
            If i > 2 Then
                dGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGrid.Columns(i).DefaultCellStyle.Format = "N2"
                dGrid.Columns(i).DefaultCellStyle.NullValue = "0.00"
            End If
        Next

        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(i).Cells(5).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(5).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                        dblTotal = dblTotal + CDbl(dGrid.Rows(i).Cells(5).Value.ToString)
                    End If
                End If
            End If
        Next

        lblTotal.Text = Format(dblTotal, "#,##0.00")

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On unpaid documents load"
        ShowErrorMessage()
    End Sub


    Private Sub PrintListing()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        If dGrid.Rows.Count <= 0 Then Exit Sub

        On Error GoTo RaiseErr
        Dim arrPrintData As New ArrayList
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1
                Dim strLineDetails As String = Nothing
                For p As Integer = 0 To .ColumnCount - 1
                    If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(p).Value), "")) Then
                        strLineDetails = strLineDetails & ";" & .Rows(i).Cells(p).Value.ToString
                    Else
                        strLineDetails = strLineDetails & ";" & ""
                    End If
                Next
                strLineDetails = Mid(strLineDetails, 2, strLineDetails.Length - 1)
                arrPrintData.Add(strLineDetails)
            Next
        End With

        Dim strPrintDetails(0 To arrPrintData.Count - 1) As String
        For i As Integer = 0 To arrPrintData.Count - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = arrPrintData.Count
            .intNumberOfColumns = dGrid.ColumnCount
            .strColumnHeaders = UCase("DOC.#|DATE|CLIENT NAME|INVOICED|PAID|BALANCE")
            .strColumnWidths = "100|60|80|180|80|180"
            .strColumnAlignments = "0|0|0|2|2|2"
            If UCase(strCalledBy) = UCase("Customers") Then .strFooterCaption = "Customers unpaid invoices" Else .strFooterCaption = "Suppliers unpaid invoices"
            If UCase(strCalledBy) = UCase("Customers") Then .strMainCaption = UCase("Customers unpaid invoices") Else .strMainCaption = UCase("Suppliers unpaid invoices")
            .strMainHeader2 = "AS AT " & gwt_comm.shortMonthDateFormat(Now)
            .strMainHeader3 = ""
            .GridColor = Color.FromName("WhiteSmoke")
            .BorderColor = Color.FromName("WhiteSmoke")
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFontItalic
            .DetailFont = fntDetailsFont
            .strColumnTotals = "NO|NO|NO|YES|YES|YES"
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .TitleColor = Color.Black
            .DetailColor = Color.Black
            .FooterColor = Color.Black
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|YES|YES|YES"
            .strSummaryTotals = "NO|NO|NO|YES|YES|YES"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On unpaid documents print"
        ShowErrorMessage()
    End Sub

    Private Sub PrintSelectedCustomerInvoice()
        If dGrid.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        boolPrinterAlreadySelected = False
        If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
                Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions

                Dim documentType As String = "INVOICE"
                Dim docNumber As Long = intSelectedTransaction
                If UCase(strPrintDocumentsTo) = UCase("pdf") Then
                    boolAbort = False
                    PrintCustomerPdfDocument(docNumber, documentType)
                    If boolAbort = False Then
                        Cursor = DefaultCursor
                        MessageBox.Show(documentType & " has been generated to pdf successfully",
                                "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                Else
                    gwt_comm.PrintCustomerDocument(docNumber, documentType)
                End If

            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Print Preview"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrintSelected_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSelected.Click
        If UCase(strCalledBy) = UCase("customers") Then
            PrintSelectedCustomerInvoice()
        Else
            PrintSelectedSupplierInvoice()
        End If
    End Sub

    Private Sub btnPrintListing_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintListing.Click
        PrintListing()
    End Sub

    Private Sub PrintSelectedSupplierInvoice()
        If dGrid.Rows.Count <= 0 Then Exit Sub
        Dim CurrentCellValue As String
        boolDisallowSave = False
        CurrentCellValue = dGrid.CurrentRow.Cells(0).Value
        intSelectedTransaction = CInt(CurrentCellValue)
        strOrderDate = dGrid.CurrentRow.Cells(1).Value
        strTotalValue = dGrid.CurrentRow.Cells(3).Value
        strBuyerName = Nothing ' dGrid.CurrentRow.Cells(5).Value

        boolAbort = False
        GenerateTransactionDocument(intSelectedTransaction)

        If boolAbort = True Then Exit Sub

        ppd.Document = pdWindows
        ppd.ShowDialog()
    End Sub

    Public Sub GenerateTransactionDocument(ByVal DocumentNumber As Long)
        On Error GoTo RaiseErr

        'Get the order main details
        Dim strAccountNumber As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, SupplierInvoicesMain.TransDate, 105) AS [Date], " _
            & "SupplierInvoicesMain.AccountNumber, Suppliers.AccountName, SupplierInvoicesMain.Value, SupplierInvoicesMain.Notes, " _
            & "SupplierInvoicesMain.Buyer, SupplierInvoicesMain.Discount, SupplierInvoicesMain.Taxes, SupplierInvoicesMain.OrderNumber, " _
            & "SupplierInvoicesMain.SupplierReference FROM SupplierInvoicesMain LEFT OUTER JOIN Suppliers ON SupplierInvoicesMain.AccountNumber " _
            & "= Suppliers.AccountNumber WHERE DocumentNumber = " & DocumentNumber & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(1).ToString) Then strAccountNumber = objReader(1).ToString
            strMainDetails = objReader(0) & "|" & objReader(1) & "|" & objReader(2) & "|" & objReader(3) & "|" & _
                objReader(4) & "|" & objReader(5) & "|" & objReader(6) & "|" & objReader(7) & "|" & objReader(8) & "|" & objReader(9)
        Else
            objReader.Close()
            MessageBox.Show("There is a problem printing this order. Missing key details", "Missing Key Order Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            boolAbort = True
            Exit Sub
        End If
        objReader.Close()

        'Get the order transactions
        arrPrintDetails = New ArrayList
        objCommand = New Data.OleDb.OleDbCommand("SELECT CAST(Quantity AS DECIMAL (30,2)) AS [Quantity], Description, " _
            & "CAST(CostPrice AS DECIMAL (30,2)) AS [CostPrice], CAST(Discount AS DECIMAL (30,2)) AS [Discount], " _
            & "CAST(Taxes AS DECIMAL (30,2)) AS [Taxes], CAST((((Quantity * CostPrice ) - Discount) + Taxes) AS DECIMAL (30,2)) AS [LineTotal] " _
            & "FROM SupplierInvoicesDetails WHERE DocumentNumber = " & DocumentNumber & "", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            arrPrintDetails.Add(objReader(0).ToString & "|" & objReader(1).ToString & "|" & objReader(2).ToString _
                & "|" & objReader(3).ToString & "|" & objReader(4).ToString & "|" & objReader(5).ToString)
        End While
        objReader.Close()

        'Get the supplier details
        objCommand = New Data.OleDb.OleDbCommand("SELECT Address1, Address2, Address3, Address4, " _
            & "AccountName, PhoneNumber, EmailAddress, VatNumber FROM Suppliers " _
            & "WHERE AccountNumber = '" & strAccountNumber & "'", cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strSupplierAddress1 = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strSupplierAddress2 = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strSupplierAddress3 = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then strSupplierAddress4 = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then strSupplierName = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then strSupplierTelephone = objReader(5).ToString
            If Not IsDBNull(objReader(6).ToString) Then strSupplierEmailAddress = objReader(6).ToString
            If Not IsDBNull(objReader(7).ToString) Then strSupplierVatNumber = objReader(7).ToString
        End If
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to print the order"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub pdWindows_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdWindows.PrintPage

        If boolPrintFromPreview = True Then
            'requery records
            boolAbort = False
            Me.GenerateTransactionDocument(CDbl(intSelectedTransaction))
            If boolAbort = True Then Exit Sub
            boolPrintFromPreview = False
        End If
        Dim strDType As String

        Dim strMain() As String = Split(strMainDetails, "|")

        strDType = UCase("SUPPLIER ORDER ACCEPTANCE")
        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer

        x1 = e.PageBounds.Left + 100
        y1 = e.PageBounds.Top + 100
        p1 = e.PageBounds.Width - 200
        y2 = e.PageBounds.Height - 200

        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        Dim strS As String = Nothing
        Dim Yc As Double
        Dim cols, lines As Double

        'Draw the document rectangle
        reccurrent = New Rectangle(x1, y1, p1, y2)
        e.Graphics.DrawRectangle(Pens.Black, reccurrent)

        'print the company logo
        Dim g As Graphics = e.Graphics
        g.DrawString(UCase("SUPPLIER ORDER ACCEPTANCE"), New Font("Arial", 16, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, Color.Black)), 350, e.PageBounds.Top + 110)
        'Draw a line after
        y1 = y1 + 40
        e.Graphics.DrawLine(Pens.Black, x1, y1, p1 + 100, y1)

        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                'Dont print the company name as it is taken care of by the logo
                strCompanyName = ""
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoXposition, intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
            End If
        End If

        y1 = y1 + 15

        'Print the company details at the extreme left of document
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, HeaderFont, Brushes.Black)
        y1 = y1 + 20

        If Not String.IsNullOrEmpty(strCompanyAddress1) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress1, tlFont, Brushes.Black)
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.", tlFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyBPNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.", tlFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyBPNumber), tlFont, Brushes.Black)
                y1 = y1 + 15
            End If
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress2) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress2, tlFont, Brushes.Black)
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO.", tlFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyVatNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO.", tlFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyVatNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress3) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress3, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyAddress4) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress4, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyTelephone) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "PHONE", tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 250, 80, UCase(strCompanyTelephone), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        'strCompanyContactCellNumber
        If Not String.IsNullOrEmpty(strCompanyContactCellNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 550, 80, "CELL NO", tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 550, 80, UCase(strCompanyContactCellNumber), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyFaxNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "FAX NO.", tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 250, 80, UCase(strCompanyFaxNumber), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyEmailAddress) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "E-MAIL", tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 250, 80, strCompanyEmailAddress, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        y1 = y1 + 5

        'print captions
        x1 = x1 + 10
        x2 = x1 + 50
        X3 = x2 + 140
        X4 = X3 + 100
        X5 = X4 + 100
        X6 = X5 + 100

        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        e.Graphics.DrawString("SUPPLIER DETAILS", prFont, Brushes.Black, x1, y1)
        e.Graphics.DrawString("TRANSACTION DETAILS", prFont, Brushes.Black, 500, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 15
        'e.Graphics.DrawString("VAT No.: " & strSupplierVatNumber, tlFont, Brushes.Black, x1, y1)
        'y1 = y1 + 15
        If strSupplierName.Length > 58 Then strSupplierName = Mid(strSupplierName, 1, 58)
        e.Graphics.DrawString(UCase(strSupplierName), tlFont, Brushes.Black, x1, y1)

        'Print the date
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "DATE", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(strMain(0)), tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "YOUR REF.", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(strMain(9)), tlFont, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress1, tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress2, tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "OUR REF.", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, Format(intSelectedTransaction, "000000"), prFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress3, tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "ORDER NO.", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(strMain(8)), tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress4, tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "BUYER", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(strMain(5)), tlFont, Brushes.Black)
        y1 += 15
        e.Graphics.DrawString("PHONE  : " & strSupplierTelephone, tlFont, Brushes.Black, x1, y1)
        y1 += 15
        e.Graphics.DrawString("E-MAIL : " & strSupplierEmailAddress, tlFont, Brushes.Black, x1, y1)
        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        'print captions
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 60, 80, "QTY", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 250, 80, "DESCRIPTION", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X3, y1, 120, 80, "UNIT PRICE", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 120, 80, "TAX", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, "DISCOUNT", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, "TOTAL", prFont, Brushes.Black)
        'draw a line after
        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 30
        itm = 0
        reccurrent = New Rectangle()
        boolExitingWhile = False
        Dim strBuffer() As String
        While itm < arrPrintDetails.Count

            strBuffer = Split(arrPrintDetails(itm), "|")

            'QUANTITY PRINTING
            Call gwt_comm.DrawStringInBoxCenter(e, x1, y1, 50, 60, strBuffer(0), tlFont, Brushes.Black)
            'UNIT PRICE PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, X3, y1, 120, 80, strBuffer(2), tlFont, Brushes.Black)
            'TAX PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 120, 80, strBuffer(4), tlFont, Brushes.Black)
            'DISCOUNT PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, strBuffer(3), tlFont, Brushes.Black)
            'LINE TOTAL PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, strBuffer(5), tlFont, Brushes.Black)

            'Print the description last as it is the column that will determine the next line position
            If Not strBuffer(1) Is Nothing Then strValue = strBuffer(1) Else strValue = ""
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 480, 80, strValue, tlFont, Brushes.Black)

            'Get the size of the address box
            e.Graphics.MeasureString(strValue, tlFont, New SizeF(200, 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * tlFont.Height + 5
            y1 = Math.Max(y1, Yc)

            itm = itm + 1 : Dim i As Integer = 0
            If itm = 23 Then
                'Print the page number of the statement
                Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, tlFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", prFont, Brushes.Black)
                e.HasMorePages = True
                boolExitingWhile = True
                intPage += 1
                Exit While
            End If
        End While

        'print totals
        'draw a line
        If boolExitingWhile = False Then
            y1 = y1 + 30
            e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
            y1 = y1 + 30

            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 120, 80, "TOTALS ", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 120, 80, Format(CDbl(strMain(7)), "#,##0.00"), prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, Format(CDbl(strMain(6)), "#,##0.00"), prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, Format(CDbl(strMain(3)), "#,##0.00"), prFont, Brushes.Black)

            y1 = y1 + 45
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 400, 80, strMain(4), ItalicFont, Brushes.Black)

            Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", prFont, Brushes.Black)

            e.HasMorePages = False
            Me.boolPrintFromPreview = True

        End If

    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        On Error GoTo RaiseErr
        If UCase(strCalledBy) = UCase("customers") Then
            PrintSelectedCustomerInvoice()
        Else
            PrintSelectedSupplierInvoice()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On document print preview"
        ShowErrorMessage()
    End Sub

End Class