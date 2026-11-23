Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmOrdersListing

    Dim strMainDetails As String
    Dim arrPrintDetails As ArrayList

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

    Private Sub btnNewOrder_Click(sender As System.Object, e As System.EventArgs) Handles btnNewOrder.Click
        If IntPublicReceiveGoods <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        boolEditStatus = False
        Dim f As New frmOrdersPlacement
        f.ShowDialog()
        LoadPurchaseOrdersData()
    End Sub


    Private Sub LoadPurchaseOrdersData()
        On Error GoTo RaiseErr
        dGridPurchaseOrders.Rows.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "[OrderNumber], [AccountNumber], [AccountHolder], CAST(Value AS DECIMAL (30,2)) AS [Value], [Buyer] " _
            & "FROM PurchasesOrderMain ORDER BY TransDate, OrderNumber", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGridPurchaseOrders.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On order details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnRefreshOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshOrders.Click
        LoadPurchaseOrdersData()
    End Sub

    Private Sub GetSelectedOrder()
        If dGridPurchaseOrders.Rows.Count <= 0 Then Exit Sub
        Dim CurrentCellValue As String
        boolDisallowSave = False
        CurrentCellValue = dGridPurchaseOrders.CurrentRow.Cells(1).Value
        intSelectedTransaction = CInt(CurrentCellValue)
        boolEditStatus = True
        Dim f As New frmOrdersPlacement
        f.ShowDialog()
        LoadPurchaseOrdersData()
    End Sub

    Private Sub dGridPurchaseOrders_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridPurchaseOrders.DoubleClick
        If IntPublicReceiveGoods = 0 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        GetSelectedOrder()
    End Sub

    Private Sub btnEditOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditOrder.Click
        If IntPublicReceiveGoods = 0 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        GetSelectedOrder()
    End Sub


    Private Sub btnSelectedOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectedOrder.Click
        If dGridPurchaseOrders.Rows.Count <= 0 Then Exit Sub
        Dim CurrentCellValue As String
        boolDisallowSave = False
        CurrentCellValue = dGridPurchaseOrders.CurrentRow.Cells(1).Value
        intSelectedTransaction = CInt(CurrentCellValue)
        strOrderDate = dGridPurchaseOrders.CurrentRow.Cells(0).Value
        strTotalValue = dGridPurchaseOrders.CurrentRow.Cells(4).Value
        strBuyerName = dGridPurchaseOrders.CurrentRow.Cells(5).Value

        boolAbort = False
        GenerateTransactionDocument(intSelectedTransaction)

        If boolAbort = True Then Exit Sub

        ppd.Document = pdOrders
        ppd.ShowDialog()
    End Sub

    Public Sub GenerateTransactionDocument(ByVal orderNumber As Long)
        On Error GoTo RaiseErr

        'Get the order main details
        Dim strAccountNumber As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "[AccountNumber], [AccountHolder], [Value], [Notes], [Buyer] FROM PurchasesOrderMain WHERE OrderNumber = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(1).ToString) Then strAccountNumber = objReader(1).ToString
            strMainDetails = objReader(0) & "|" & objReader(1) & "|" & objReader(2) & "|" & objReader(3) & "|" & objReader(4) & "|" & objReader(5)
        Else
            objReader.Close()
            MessageBox.Show("There is a problem printing this order. Missing key details", "Missing Key Order Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            boolAbort = True
            Exit Sub
        End If
        objReader.Close()

        'Get the order transactions
        arrPrintDetails = New ArrayList
        objCommand = New Data.OleDb.OleDbCommand("SELECT [ItemDetails], [Quantity], [UnitPrice] " _
            & "FROM PurchasesOrderDetails WHERE OrderNumber = " & intSelectedTransaction & "", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            arrPrintDetails.Add(objReader(0).ToString & "|" & objReader(1).ToString & "|" & objReader(2).ToString)
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to print the order"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub pdOrders_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdOrders.PrintPage

        If boolPrintFromPreview = True Then
            'requery records
            boolAbort = False
            Me.GenerateTransactionDocument(CDbl(intSelectedTransaction))
            If boolAbort = True Then Exit Sub
            boolPrintFromPreview = False
        End If
        Dim strDType As String
        strDType = UCase(strOrderHeader)
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
        g.DrawString(UCase(strOrderHeader), New Font("Arial", 16, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, Color.Black)), 350, e.PageBounds.Top + 110)
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
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, fntHeaderFont, Brushes.Black)
        y1 = y1 + 20

        If Not String.IsNullOrEmpty(strCompanyAddress1) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress1, fntDetailsFont, Brushes.Black)
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.", fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyBPNumber), fntDetailsFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.", fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyBPNumber), fntDetailsFont, Brushes.Black)
                y1 = y1 + 15
            End If
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress2) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress2, fntDetailsFont, Brushes.Black)
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO.", fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyVatNumber), fntDetailsFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO.", fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyVatNumber), fntDetailsFont, Brushes.Black)
            End If
            y1 = y1 + 15
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress3) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress3, fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyAddress4) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress4, fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyTelephone) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "PHONE", fntDetailsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 250, 80, UCase(strCompanyTelephone), fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        'strCompanyContactCellNumber
        If Not String.IsNullOrEmpty(strCompanyContactCellNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 550, 80, "CELL NO", fntDetailsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 550, 80, UCase(strCompanyContactCellNumber), fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyFaxNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "FAX NO.", fntDetailsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 250, 80, UCase(strCompanyFaxNumber), fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyEmailAddress) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "E-MAIL", fntDetailsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 250, 80, strCompanyEmailAddress, fntDetailsFont, Brushes.Black)
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
        e.Graphics.DrawString("SUPPLIER DETAILS", fntHeaderFont, Brushes.Black, x1, y1)
        e.Graphics.DrawString("TRANSACTION DETAILS", fntHeaderFont, Brushes.Black, 500, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 15
        'e.Graphics.DrawString("VAT No.: " & strSupplierVatNumber, fntDetailsFont, Brushes.Black, x1, y1)
        'y1 = y1 + 15
        If strSupplierName.Length > 58 Then strSupplierName = Mid(strSupplierName, 1, 58)
        e.Graphics.DrawString(UCase(strSupplierName), fntDetailsFont, Brushes.Black, x1, y1)

        'Print the date
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "DATE", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(strOrderDate), fntDetailsFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "VAT NO.", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(strSupplierVatNumber), fntDetailsFont, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress1, fntDetailsFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress2, fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "ORDER NO.", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, Format(intSelectedTransaction, "000000"), fntDetailsFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress3, fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "BUYER", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(strBuyerName), fntDetailsFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress4, fntDetailsFont, Brushes.Black)
        y1 += 15
        e.Graphics.DrawString("PHONE :" & strSupplierTelephone & " Email : " & strSupplierEmailAddress, fntDetailsFont, Brushes.Black, x1, y1)
        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        'print captions
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 60, 80, "QTY", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 480, 80, "DESCRIPTION", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, "UNIT PRICE", fntHeaderFont, Brushes.Black)
        'Call DrawStringInBoxRight(e, X4, y1, 120, 80, "TAX", fntHeaderFont, Brushes.Black)
        'Call DrawStringInBoxRight(e, X5, y1, 120, 80, "DISCOUNT", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, "TOTAL", fntHeaderFont, Brushes.Black)
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
            Dim strUnitPriceBeforeTax As String = "0.00"
            Dim strTaxAmount As String = "0.00"
            Dim strDiscountAmount As String = "0.00"
            Dim strUnitPrice As String = "0.00"
            Dim strPayableAfterTax As String = "0.00"
            Dim strPrintQuantity As String = "0"
            Dim strPrintPrice As String = "0.00"

            'Quantity
            If Not strBuffer(1) Is Nothing Then strValue = strBuffer(1) Else strValue = "0"
            strPrintQuantity = strValue
            'Unit Price
            If Not strBuffer(2) Is Nothing Then strValue = CStr(Format(CDbl(strBuffer(2)), "#,##0.00")) Else strValue = "0.00"
            strUnitPrice = strValue
            strPrintPrice = Format(CDbl(strUnitPrice) / CDbl(strPrintQuantity), "#,##0.00")
            strPayableAfterTax = strUnitPrice

            'QUANTITY PRINTING
            Call gwt_comm.DrawStringInBoxCenter(e, x1, y1, 50, 60, strPrintQuantity, fntDetailsFont, Brushes.Black)
            'UNIT PRICE PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, strPrintPrice, fntDetailsFont, Brushes.Black)
            'LINE TOTAL PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, strPayableAfterTax, fntDetailsFont, Brushes.Black)

            'Print the description last as it is the column that will determine the next line position
            If Not strBuffer(0) Is Nothing Then strValue = strBuffer(0) Else strValue = ""
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 480, 80, strValue, fntDetailsFont, Brushes.Black)

            'Get the size of the address box
            e.Graphics.MeasureString(strValue, fntDetailsFont, New SizeF(200, 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * fntDetailsFont.Height + 5
            y1 = Math.Max(y1, Yc)

            itm = itm + 1 : Dim i As Integer = 0
            If itm = 23 Then
                'Print the page number of the statement
                Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", fntHeaderFont, Brushes.Black)
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
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 120, 80, "TOTALS ", fntHeaderFont, Brushes.Black)

            Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, Format(CDbl(strTotalValue), "#,##0.00"), fntHeaderFont, Brushes.Black)

            Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, fntDetailsFont, Brushes.Black)
            'Call DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", fntHeaderFont, Brushes.Black)

            'Print the notes

            y1 = y1 + 45
            reccurrent = New Rectangle(x1 + 5, y1, 300, 100)
            e.Graphics.DrawRectangle(Pens.Gray, reccurrent)
            Call gwt_comm.DrawStringInBoxLeft(e, (x1 + 5), y1 + 3, 120, 80, "NOTES", fntHeaderFont, Brushes.Black)
            y1 = y1 + 25
            Dim strNotesForPrinting() As String = Split(strMainDetails, "|")
            Call gwt_comm.DrawStringInBoxLeft(e, (x1 + 5), y1, 280, 145, strNotesForPrinting(4), fntDetailsFont, Brushes.Black)

            e.HasMorePages = False
            Me.boolPrintFromPreview = True

        End If

    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        On Error GoTo RaiseErr
        dGridPurchaseOrders.Rows.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "[OrderNumber], [AccountNumber], [AccountHolder], CAST(Value AS DECIMAL (30,2)) AS [Value], [Buyer] " _
            & "FROM PurchasesOrderMain WHERE TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartFrom.Value) & "' " _
            & "AND '" & gwt_comm.shortMonthDateFormat(dpEndTo.Value) & "' ORDER BY TransDate, OrderNumber", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGridPurchaseOrders.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On order details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    'Private Sub txtSearchString_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim i As Integer = 0
    '    With dGridPurchaseOrders
    '        For i = 0 To .Rows.Count - 1
    '            Select Case UCase(cboSearchOptions.Text)
    '                Case Is = UCase("Account Number")
    '                    If UCase(Mid(.Rows(i).Cells(2).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
    '                        .FirstDisplayedCell = .Rows(i).Cells(2)
    '                        .FirstDisplayedCell.Selected = True
    '                        Exit Sub
    '                    End If
    '                Case Is = UCase("Account Name")
    '                    If UCase(Mid(.Rows(i).Cells(3).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
    '                        .FirstDisplayedCell = .Rows(i).Cells(3)
    '                        .FirstDisplayedCell.Selected = True
    '                        Exit Sub
    '                    End If
    '                Case Else
    '                    'Use the last name
    '                    If UCase(Mid(.Rows(i).Cells(3).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
    '                        .FirstDisplayedCell = .Rows(i).Cells(3)
    '                        .FirstDisplayedCell.Selected = True
    '                        Exit Sub
    '                    End If
    '            End Select
    '        Next
    '    End With
    'End Sub

    Private Sub btnSummaryOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSummaryOrders.Click

        If dGridPurchaseOrders.Rows.Count <= 0 Then Exit Sub

        On Error GoTo RaiseErr
        Dim arrPrintData As New ArrayList
        With dGridPurchaseOrders
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
            .intNumberOfColumns = dGridPurchaseOrders.ColumnCount
            .strColumnHeaders = UCase("DATE|ORDER#|ACCOUNT #|ACCOUNT NAME|VALUE|BUYER")
            .strColumnWidths = "100|60|80|180|80|180"
            .strColumnAlignments = "0|0|0|0|2|0"
            .strFooterCaption = "Orders Listing"
            .strMainCaption = UCase("ORDERS LISTING")
            .strMainHeader2 = "DATE RANGE : " & UCase(gwt_comm.shortMonthDateFormat(dpStartFrom.Value)) & " TO " & UCase(shortMonthDateFormat(CDate(dpEndTo.Value)))
            .strMainHeader3 = ""
            .GridColor = Color.FromName("WhiteSmoke")
            .BorderColor = Color.FromName("WhiteSmoke")
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFontItalic
            .DetailFont = fntDetailsFont
            .strColumnTotals = "NO|NO|NO|NO|YES|NO"
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
            .strColumnFormating = "NO|NO|NO|NO|YES|NO"
            .strSummaryTotals = "NO|NO|NO|NO|YES|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On order listing printing"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals()
        With dGridPurchaseOrders
            Dim dblTotal As Double = 0
            For i As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "")) Then
                    If IsNumeric(Convert.ToString(.Rows(i).Cells(4).Value)) Then
                        dblTotal = dblTotal + CDbl(Convert.ToString(.Rows(i).Cells(4).Value))
                    End If
                End If
            Next
            lblTotalOrders.Text = Format(dblTotal, "##0.00")
        End With
    End Sub


End Class