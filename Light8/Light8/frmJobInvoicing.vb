Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmJobInvoicing

    Dim prFont As New Font("Arial", 8, FontStyle.Bold)
    Dim tlFont As New Font("Arial", 8, FontStyle.Regular)
    Dim HeaderFont As New Font("Arial", 12, FontStyle.Bold)
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
    Dim itm As Integer

    Dim boolPrintFromPreview As Boolean
    Dim intPaymentReceiptNumber As Integer
    Dim strCustomerAccountNumberPayments As String
    Dim strTermsAndConditions As String = Nothing
    Dim boolFormIsLoading As Boolean

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

    Private Sub frmJobCosting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boolFormIsLoading = True
        dGrid.Rows.Add(15)
        LoadEmployees()
        LoadData()
        'Load the details of the job cards
        LoadJobCardDetails()
        If boolEditStatus = False Then
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("JobInvoices"))
        Else
            txtReference.Text = intSelectedReferencedInvoice
            LoadMaterialsDetails()
        End If
        boolFormIsLoading = False
        Exit Sub
    End Sub

    Private Sub LoadJobCardDetails()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM JobCards WHERE ReferenceNumber = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            txtReference.Text = intSelectedTransaction
            If Not IsDBNull(objReader("CustomerName").ToString) Then txtAccountName.Text = objReader("CustomerName").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then sDocumentCustomerAddress1 = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then sDocumentCustomerAddress2 = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then sDocumentCustomerAddress3 = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then sDocumentCustomerAddress4 = objReader("Address4").ToString
            If Not IsDBNull(objReader("ContactNumber").ToString) Then sDocumentCustomerTelephone = objReader("ContactNumber").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then sDocumentCustomerEmailAddress = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("TaxNumber").ToString) Then sDocumentCustomerVatNumber = objReader("TaxNumber").ToString
            If IsDate(objReader("TransDate").ToString) Then dpDateOn.Value = CDate(objReader("TransDate").ToString)
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Job Card Details Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmJobCosting_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F3 Then
            If String.IsNullOrEmpty(txtAccountName.Text) Then
                MessageBox.Show("Please enter the prospect name", "Missing Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtAccountName.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(sDocumentCustomerAddress1) Then
                MessageBox.Show("Please enter the prospect address", "Missing Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                btnDetails.Focus()
                Exit Sub
            End If
            FinishTransaction()
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("JobInvoices"))
        End If
    End Sub

    Private Sub LoadEmployees()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT FirstName +' '+LastName AS " _
            & "[Personnel] FROM EmployeeMaster ORDER BY FirstName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        cboPersonnel.Items.Clear()
        Dim i As Double = 0
        Dim p As Double = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                cboPersonnel.Items.Add(objReader(0).ToString)
            End If
            p = p + 1
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Job Invoicing Personnel Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex >= 5 And e.ColumnIndex <= 8 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
                ComputeValues(CDbl(dGrid.CurrentRow.Cells(5).Value.ToString), CDbl(dGrid.CurrentRow.Cells(6).Value.ToString), dGrid.CurrentRow.Index, CDbl(dGrid.CurrentRow.Cells(8).Value.ToString), 0)
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
            ComputeTotals()
        End If
    End Sub

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGrid.EditingControlShowing
        Try
            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                'In order to prevent optical problems, we had to call the removeHandler twice
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComputeValues(ByVal dblUnitPrice As Double, ByVal intQuantity As Double, _
        ByVal intRowIndex As Double, _
        Optional ByVal dblDiscount As Double = 0, Optional ByVal dblTaxRate As Double = 0)
        Dim dblTaxes As Double = 0
        Dim dblSubTotal As Double = 0
        Dim dblPayable As Double = 0

        'Compute the sub total
        dblSubTotal = dblUnitPrice * intQuantity
        dGrid.Rows(intRowIndex).Cells(7).Value = Format(dblSubTotal, "##0.00")

        'Compute the tax payable
        dblTaxes = (dblSubTotal - dblDiscount) * dblTaxRate

        dblPayable = (dblSubTotal - dblDiscount) + dblTaxes

        dGrid.Rows(intRowIndex).Cells(9).Value = Format(dblTaxes, "##0.00")
        dGrid.Rows(intRowIndex).Cells(10).Value = Format(dblPayable, "##0.00")

        RecalculateAmount()
        ComputeTotals()

    End Sub

    Private Sub RecalculateAmount()
        Dim dblMovingTotal As Double = 0
        Dim dblSubs As Double = 0
        Dim dblTxs As Double = 0
        Dim dblDis As Double = 0
        For i As Double = 0 To dGrid.Rows.Count - 1
            Dim strValue As String = "0"
            Dim strValTx As String = "0"
            Dim strValDis As String = "0"
            Dim strValSubs As String = "0"
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(10).Value), "")) Then
                strValue = Convert.ToString(dGrid.Rows(i).Cells(10).Value)
                If IsNumeric(strValue) Then
                    dblMovingTotal = dblMovingTotal + CDbl(strValue)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(9).Value), "")) Then
                strValTx = Convert.ToString(dGrid.Rows(i).Cells(9).Value)
                If IsNumeric(strValTx) Then
                    dblTxs = dblTxs + CDbl(strValTx)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(8).Value), "")) Then
                strValDis = Convert.ToString(dGrid.Rows(i).Cells(8).Value)
                If IsNumeric(strValDis) Then
                    dblDis = dblDis + CDbl(strValDis)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "")) Then
                strValSubs = Convert.ToString(dGrid.Rows(i).Cells(7).Value)
                If IsNumeric(strValSubs) Then
                    dblSubs = dblSubs + CDbl(strValSubs)
                End If
            End If

        Next
        lblPayable.Text = Format(dblMovingTotal, "#,##0.00")
        lblSubTotal.Text = Format(dblSubs, "#,##0.00")
        lblDiscounts.Text = Format(dblDis, "#,##0.00")
        lblTaxes.Text = Format(dblTxs, "#,##0.00")
    End Sub

    Private Sub ComputeTotals()
        If dGrid.Rows.Count = 0 Then Exit Sub
        Dim dblSubTotal As Double = 0
        Dim dblTaxesTotal As Double = 0
        Dim dblDiscountTotals As Double = 0
        Dim dblTotalPayable As Double = 0
        For n As Double = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(7).Value), "")) Then
                dblSubTotal = dblSubTotal + CDbl(dGrid.Rows(n).Cells(7).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(9).Value), "")) Then
                dblTaxesTotal = dblTaxesTotal + CDbl(dGrid.Rows(n).Cells(9).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(8).Value), "")) Then
                dblDiscountTotals = dblDiscountTotals + CDbl(dGrid.Rows(n).Cells(8).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(10).Value), "")) Then
                dblTotalPayable = dblTotalPayable + CDbl(dGrid.Rows(n).Cells(10).Value.ToString)
            End If
        Next
        lblSubTotal.Text = Format(dblSubTotal, "#,##0.00")
        lblTaxes.Text = Format(dblTaxesTotal, "#,##0.00")
        lblDiscounts.Text = Format(dblDiscountTotals, "#,##0.00")
        lblPayable.Text = Format(dblTotalPayable, "#,##0.00")
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If boolPrintFromPreview = True Then
            'requery records
            boolAbort = False
            Me.GenerateTransactionDocument(CDbl(txtReference.Text))
            If boolAbort = True Then Exit Sub
            boolPrintFromPreview = False
        End If
        Dim strDType As String
        strDType = "JOB INVOICE"
        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer
        'Dim xx1 AS DOUBLE, xx2 AS DOUBLE, yy1 AS DOUBLE, yy2 AS DOUBLE
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

        'Print the watermark here
        'Dim g As Graphics = e.Graphics
        'g.TranslateTransform(200, 200)
        'g.RotateTransform(e.PageSettings.Landscape)
        'g.DrawString("DRAFT VERSION", New Font("Verdana", 75, FontStyle.Bold), New SolidBrush(Color.FromArgb(64, Color.Black)), 0, 0)

        'print the company logo
        Dim g As Graphics = e.Graphics
        g.DrawString("JOB INVOICE", New Font("Arial", 20, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, Color.Black)), 500, e.PageBounds.Top + 120)

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

        y1 = y1 + 30
        'Get the sales agent details
        'Print the company details at the extreme left of document
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, HeaderFont, Brushes.Black)
        'e.Graphics.DrawString(strDType, HeaderFont, Brushes.Black, 500, e.PageBounds.Top + 120)
        y1 = y1 + 20
        Dim strAddressInfo As String = strCompanyAddress1 & vbCrLf & strCompanyAddress2 & vbCrLf & _
            strCompanyAddress3 & vbCrLf & strCompanyAddress4 & vbCrLf & " Fax : " & strCompanyFaxNumber & vbCrLf & "Email   : " & sDocumentCustomerEmailAddress
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strAddressInfo, tlFont, Brushes.Black)
        'Get the size of the address box
        e.Graphics.MeasureString(strAddressInfo, tlFont, New SizeF(200, 80), New StringFormat(), cols, lines)
        Yc = y1
        y1 = y1 + lines * tlFont.Height + 5
        y1 = Math.Max(y1, Yc)
        Call gwt_comm.DrawStringInBoxLeft(e, 300, y1 - 18, 250, 80, "Vat No. : " & strCompanyVatNumber, tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 550, y1 - 18, 250, 80, "Reg. No : " & strCompanyRegistrationNumber, tlFont, Brushes.Black)
        'print captions
        x1 = x1 + 10
        x2 = x1 + 50
        X3 = x2 + 140
        X4 = X3 + 100
        X5 = X4 + 100
        X6 = X5 + 100

        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        e.Graphics.DrawString("CUSTOMER DETAILS", prFont, Brushes.Black, x1, y1)
        e.Graphics.DrawString("TRANSACTION DETAILS", prFont, Brushes.Black, 500, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 15
        e.Graphics.DrawString("VAT No.: " & UCase(strCustomerVatNumber), tlFont, Brushes.Black, x1, y1) '& Space(20) & " VAT No.: " & UCase(strCustomerVatNumber)
        y1 = y1 + 15
        If strCustomerName.Length > 58 Then strCustomerName = Mid(strCustomerName, 1, 58)
        e.Graphics.DrawString(UCase(strCustomerName), tlFont, Brushes.Black, x1, y1)
        'e.Graphics.DrawString(strCustomerName, tlFont, Brushes.Black, x1, y1)
        'Print the date
        e.Graphics.DrawString("DATE : " & strDate, tlFont, Brushes.Black, 500, y1)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "JOB CARD NO.   : " & Format(CLng(txtReference.Text), "000000"), tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress1, tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress2, tlFont, Brushes.Black)
        'Call DrawStringInBoxLeft(e, 500, y1, 300, 80, "ORDER REF. NO.: " & UCase(txtOrderNumber.Text), tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress3, tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress4, tlFont, Brushes.Black)
        y1 += 15
        ''Get the size of the address box
        'e.Graphics.MeasureString(strCustomerAddress, tlFont, New SizeF(200, 80), New StringFormat(), cols, lines)
        'Yc = y1
        'y1 = y1 + lines * tlFont.Height + 5
        'y1 = Math.Max(y1, Yc)
        e.Graphics.DrawString("PHONE :             Email : " & strCustomerEmailAddress, tlFont, Brushes.Black, x1, y1)
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
        While itm < strInvoiceDetails.Count
            strBuffer = Split(strInvoiceDetails(itm), "|")
            If Not strBuffer(0) Is Nothing Then strvalue = strBuffer(0) Else strvalue = "0"
            Call gwt_comm.DrawStringInBoxCenter(e, x1, y1, 50, 60, strvalue, tlFont, Brushes.Black)
            If Not strBuffer(3) Is Nothing Then strvalue = CStr(Format(CDbl(strBuffer(3)), "#,##0.00")) Else strvalue = "0.00"
            Call gwt_comm.DrawStringInBoxRight(e, X3, y1, 120, 80, strvalue, tlFont, Brushes.Black)
            If Not strBuffer(4) Is Nothing Then strvalue = CStr(Format(CDbl(strBuffer(4)), "#,##0.00")) Else strvalue = "0.00"
            Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 120, 80, strvalue, tlFont, Brushes.Black)
            If Not strBuffer(5) Is Nothing Then strvalue = CStr(Format(CDbl(strBuffer(5)), "#,##0.00")) Else strvalue = "0.00"
            Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, strvalue, tlFont, Brushes.Black)
            If Not strBuffer(6) Is Nothing Then strvalue = CStr(Format(CDbl(strBuffer(6)), "#,##0.00")) Else strvalue = "0.00"
            Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, strvalue, tlFont, Brushes.Black)
            'Print the description last as it is the column that will determine the next line position
            If Not strBuffer(2) Is Nothing Then strvalue = strBuffer(2) Else strvalue = ""
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 200, 80, strvalue, tlFont, Brushes.Black)
            'Get the size of the address box
            e.Graphics.MeasureString(strvalue, tlFont, New SizeF(200, 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * tlFont.Height + 5
            y1 = Math.Max(y1, Yc)
            'y1 = y1 + 20
            itm = itm + 1 : i = 0
            If itm = 23 Then
                'Print the page number of the statement
                Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, tlFont, Brushes.Black)
                'print the compny bank details
                'Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 80, 600, 80, "OUR BANK DETAILS : " & strCompanyBankName & " ACCOUNT NO : " & UCase(strCompanyAccountNumber) & " BANK CODE : " & UCase(strCompanyBranchCode), prFont, Brushes.Black)
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
            Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 120, 80, Format(dblTaxes, "#,##0.00"), prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, Format(dblDiscounts, "#,##0.00"), prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, Format(dblInvoiceTotal, "#,##0.00"), prFont, Brushes.Black)


            'PRINT THE TERMS AND CONDITIONS
            '

            y1 = y1 + 60
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 250, 80, "TERMS AND CONDITIONS", prFont, Brushes.Black)
            y1 = y1 + 20
            'strTermsAndConditions
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 400, 160, strTermsAndConditions, tlFont, Brushes.Black)

            Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, tlFont, Brushes.Black)
            'Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 80, 600, 80, "OUR BANK DETAILS : " & strCompanyBankName & " ACCOUNT NO : " & UCase(strCompanyAccountNumber) & " BANK CODE : " & UCase(strCompanyBranchCode), tlFont, Brushes.Black)
            For h As Integer = 0 To arrCompanyBankDetails.Count - 1
                Dim strSplit() As String = Split(arrCompanyBankDetails.Item(h), "|")
                Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 600, 80, "BANK DETAILS " & CStr(h + 1) & ": " & strSplit(1) & _
                    " ACCOUNT NO : " & UCase(strSplit(3)) & " BANK CODE : " & _
                    UCase(strSplit(0)), tlFont, Brushes.Black)
                y1 = y1 + 10
            Next
            Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", prFont, Brushes.Black)

            e.HasMorePages = False
            Me.boolPrintFromPreview = True

        End If
    End Sub

    Private Sub GenerateTransactionDocument(ByVal intDocumentNumber As Double)
        'get invoice number
        On Error GoTo RaiseErr
        Dim n As Integer = 0
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim strCustomerNumber As String = Nothing

        myCommand = New Data.OleDb.OleDbCommand("Select CONVERT(NVARCHAR, TransDate, 105) as [TransDate], Amount, Taxes, Discount, Terms " _
            & "FROM JobInvoiceMain Where ReferenceNumber = " & intDocumentNumber & "", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            Dim strDateparts() As String = Split(dbReader(0).ToString, "-")
            If Not IsDBNull(dbReader(0).ToString) Then strDate = CDate(strDateparts(0) & "-" & UCase(MonthName(CInt(strDateparts(1)), True)) & "-" & strDateparts(2))
            If IsNumeric(dbReader(1).ToString) Then dblInvoiceTotal = CDbl(dbReader(1).ToString) Else dblInvoiceTotal = 0
            If IsNumeric(dbReader(2).ToString) Then dblTaxes = dbReader(2).ToString Else dblTaxes = 0
            If IsNumeric(dbReader(3).ToString) Then dblDiscounts = dbReader(3).ToString Else dblDiscounts = 0
            If Not IsDBNull(dbReader(4).ToString) Then strTermsAndConditions = dbReader(4).ToString
        End If
        dbReader.Close()

        'Get the customer details
        myCommand = New Data.OleDb.OleDbCommand("SELECT CustomerName, Address1, Address2, Address3, Address4, " _
            & "ContactNumber, EmailAddress, TaxNumber FROM JobInvoiceMain WHERE ReferenceNumber = " & intDocumentNumber & "", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            If Not IsDBNull(dbReader(0).ToString) Then strCustomerName = dbReader(0).ToString
            If Not IsDBNull(dbReader(1).ToString) Then strCustomerAddress1 = dbReader(1).ToString
            If Not IsDBNull(dbReader(2).ToString) Then strCustomerAddress2 = dbReader(2).ToString
            If Not IsDBNull(dbReader(3).ToString) Then strCustomerAddress3 = dbReader(3).ToString
            If Not IsDBNull(dbReader(4).ToString) Then strCustomerAddress4 = dbReader(4).ToString
            If Not IsDBNull(dbReader(5).ToString) Then strCustomerTelephone = dbReader(5).ToString
            If Not IsDBNull(dbReader(6).ToString) Then strCustomerEmailAddress = dbReader(6).ToString
            If Not IsDBNull(dbReader(7).ToString) Then strCustomerVatNumber = dbReader(7).ToString
        End If
        dbReader.Close()

        myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity, ItemCode, Description +' '+ SerialNumbers as [Description], SalesPrice, " _
            & "DiscountAllowed, Taxes, (((SalesPrice * Quantity) - DiscountAllowed) + Taxes) AS [Payable] " _
            & "from JobInvoiceDetails where ReferenceNumber = " & intDocumentNumber & "", cnn)
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
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Invoice Generation Error"
        gwt_comm.ShowErrorMessage()
    End Sub


    Private Sub GenerateTransactionDocument(ByVal intDocumentNumber As Integer)
        'get invoice number
        On Error GoTo RaiseErr
        Dim n As Integer = 0
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim myCommand As Data.OleDb.OleDbCommand

        myCommand = New Data.OleDb.OleDbCommand("Select CONVERT(NVARCHAR, TransDate, 105) as [TransDate], CustomerName, " _
            & "Address1, Address2, Address3, Address4, ContactNumber, EmailAddress, QuoteValue, TotalTaxes, TotalDiscount, " _
            & "TaxNumber, Terms FROM JobInvoiceMain Where ReferenceNumber = " & intDocumentNumber & "", cnn)
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
            & "Discount, Tax, Payable from JobInvoiceDetails where ReferenceNumber = " & intDocumentNumber & "", cnn)
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
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Job Card Generation Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtAccountName.Text) Then
            MessageBox.Show("Please enter the customer name", "Missing Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(sDocumentCustomerAddress1) Then
            MessageBox.Show("Please enter the customer address", "Missing Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnDetails.Focus()
            Exit Sub
        End If

        If dGrid.Rows.Count <= 0 Then
            MessageBox.Show("No document transactions to print", "Empty Document Transactions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboPersonnel.Text) Then
            MessageBox.Show("Please select the name of the sales representative from the list provided", _
                "Missing Sales Agent Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPersonnel.Focus()
            Exit Sub
        End If

        FinishTransaction()
        'GetNextDocumentNumber()
        PrintDocumentInvoice()
        Me.Close()
    End Sub

    Private Sub chkOverideDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverideDate.CheckedChanged
        If chkOverideDate.Checked = True Then
            If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
                dpDateOn.Enabled = True
            Else
                boolAbort = False
                boolAuthorized = False
                gwt_comm.SuperUserAuthentication()
                If boolAbort = True Then
                    chkOverideDate.Checked = False
                    Exit Sub
                End If
                If boolAuthorized = True Then
                    dpDateOn.Enabled = True
                    boolAuthorized = False
                End If
            End If
        Else
            dpDateOn.Enabled = False
            boolAuthorized = False
        End If
    End Sub

    Private Sub FinishTransaction()

        Dim strSelectedId As String
        Dim strDescription As String
        Dim intQty As Double
        Dim dblUprice As Double
        Dim insertCustomer As String
        Dim dblTax As Double
        Dim i As Double
        Dim dpProcessDate As Date = gwt_comm.shortMonthDateFormat(DateTime.Now)
        Dim dblDisAmount As Double 'for discounts
        Dim dblSumTaxes As Double = 0, dblSumDiscounts As Double = 0, dblSumPayable As Double = 0
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim dbReader As Data.OleDb.OleDbDataReader

        'Perform the till ring routine
        boolAbort = False

        dblSaleTotal = CDbl(lblPayable.Text)

        If dblSaleTotal <= 0 Then
            MessageBox.Show("Sale cannot be processed when there are no valid sub total values", _
                "Sale Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' ''Dim f As New frmTenderAmount
        ' ''f.ShowDialog()
        If boolAbort = True Then Exit Sub

        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If boolEditStatus = True Then
            'Reverse the items back to the stores First and then delete invoice data

            'Get the original sales data
            Dim strSql As String = "SELECT [ReferenceNumber],[ItemCode],[Description],[Quantity]," _
                & "[DiscountAllowed],[Taxes],[SalesPrice],[SerialNumbers] FROM JobInvoiceDetails " _
                & "WHERE ReferenceNumber = " & intSelectedReferencedInvoice & ""
            Dim objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommandReverse.ExecuteReader
            While objReader.Read
                'Add the items back to the inventory
                If Not String.IsNullOrEmpty(objReader("SerialNumbers").ToString) Then
                    Dim lngComma As Long = InStr(1, objReader("SerialNumbers").ToString, ",", 1)
                    If lngComma > 0 Then
                        Dim strSeries() As String = Split(objReader("SerialNumbers").ToString, ",")
                        For n As Double = 0 To strSeries.Length - 1
                            If Not String.IsNullOrEmpty(strSeries(n)) Then
                                strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber) VALUES ('" & strSeries(n) & "', " _
                                    & "'" & objReader("SerialNumbers").ToString & "')"
                                objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
                                objCommandReverse.ExecuteNonQuery()
                            End If
                        Next
                    Else
                        strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber) VALUES ('" & objReader("ItemCode").ToString & "', " _
                            & "'" & objReader("SerialNumbers").ToString & "')"
                        objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommandReverse.ExecuteNonQuery()
                    End If
                End If
                'Update the inventory table
                strSql = "UPDATE InventoryItems SET InventoryItems.Quantity = (InventoryItems.Quantity + " & CDbl(objReader("Quantity").ToString) & ") " _
                    & "WHERE ItemCode = '" & objReader("ItemCode").ToString & "'"
                objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommandReverse.ExecuteNonQuery()
            End While

            Dim objDeleteInvoice As New Data.OleDb.OleDbCommand("DELETE FROM JobInvoiceDetails WHERE ReferenceNumber = " & intSelectedReferencedInvoice & "", cnn)
            objDeleteInvoice.ExecuteNonQuery()
            objDeleteInvoice = New Data.OleDb.OleDbCommand("DELETE FROM JobInvoiceMain WHERE ReferenceNumber = " & intSelectedReferencedInvoice & "", cnn)
            objDeleteInvoice.ExecuteNonQuery()
            txtReference.Text = intSelectedTransaction
        Else
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("JobInvoices"))
        End If
        If chkOverideDate.Checked = True Then
            dpProcessDate = gwt_comm.shortMonthDateFormat(dpDateOn.Value)
        End If

        For i = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then

                Dim strItemSerialNo As String = Nothing
                Dim strLineItemType As String = Nothing
                strSelectedId = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                strDescription = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
                intQty = Convert.ToDouble(dGrid.Rows(i).Cells(6).Value)
                dblTax = Convert.ToDouble(dGrid.Rows(i).Cells(9).Value)
                dblUprice = Convert.ToDouble(dGrid.Rows(i).Cells(5).Value)
                dblDisAmount = Convert.ToDouble(dGrid.Rows(i).Cells(8).Value)
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                    strItemSerialNo = Convert.ToString(dGrid.Rows(i).Cells(3).Value)
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(11).Value), "")) Then
                    strLineItemType = Convert.ToString(dGrid.Rows(i).Cells(11).Value)
                End If

                'Get the item cost price
                Dim dblItemCostPrice As Double = 0
                Dim ojjGetCostPrice As New Data.OleDb.OleDbCommand("SELECT CostPrice FROM InventoryItems WHERE ItemCode = '" & strSelectedId & "'", cnn)
                Dim objReadCostPrice As Data.OleDb.OleDbDataReader = ojjGetCostPrice.ExecuteReader
                If objReadCostPrice.HasRows Then
                    objReadCostPrice.Read()
                    If IsNumeric(objReadCostPrice(0).ToString) Then dblItemCostPrice = CDbl(objReadCostPrice(0).ToString)
                End If
                objReadCostPrice.Close()
                '
                insertCustomer = "INSERT INTO JobInvoiceDetails (ReferenceNumber, TransDate, ItemCode, Quantity, " _
                    & "SalesPrice, TransType, Description, Taxes, DiscountAllowed, ProductType, SerialNumbers, UserName, SalesRep, CostPrice) VALUES " _
                    & "(" & CDbl(txtReference.Text) & ", '" & gwt_comm.shortMonthDateFormat(dpProcessDate) & "', " _
                    & "'" & strSelectedId & "', " & intQty & ", " & dblUprice & ", 'JOB INVOICE', " _
                    & "'" & strDescription & "', " & dblTax & ", " & dblDisAmount & ", " _
                    & "'" & strLineItemType & "', '" & strItemSerialNo & "', '" & strUserName & "', '" & cboPersonnel.Text & "', " & dblItemCostPrice & ")"
                myCommand = New Data.OleDb.OleDbCommand(insertCustomer, cnn)
                myCommand.ExecuteNonQuery()

                dblSumTaxes = dblSumTaxes + dblTax
                dblSumDiscounts = dblSumDiscounts + dblDisAmount


                'Update the products table
                Dim intStockBalance As Double = 0
                myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & strSelectedId & "'", cnn)
                dbReader = myCommand.ExecuteReader
                If dbReader.HasRows Then
                    dbReader.Read()
                    If IsNumeric(dbReader(0).ToString) Then intStockBalance = CDbl(dbReader(0).ToString) Else intStockBalance = 0
                Else
                    intStockBalance = 0
                End If
                dbReader.Close()
                intStockBalance = intStockBalance - intQty
                myCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = " & intStockBalance & " " _
                    & "WHERE ItemCode = '" & strSelectedId & "'", cnn)
                myCommand.ExecuteNonQuery()

                'Update the table for serial numbers
                If Not String.IsNullOrEmpty(strItemSerialNo) Then
                    myCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers WHERE ItemCode = '" & strSelectedId & "' " _
                        & "AND SerialNumber = '" & strItemSerialNo & "'", cnn)
                    myCommand.ExecuteNonQuery()
                End If

            End If

        Next i

        dblSumPayable = CDbl(lblPayable.Text)

        'Add the record to the sales main

        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO JobInvoiceMain (ReferenceNumber, JobNumber, " _
            & "TransDate, Discount, Taxes, Amount, UserName, SalesRep, CustomerName, Address1, Address2, " _
            & "Address3, Address4, ContactNumber, EmailAddress, TaxNumber, UserBranch, Terms) VALUES " _
            & "(" & Convert.ToDouble(txtReference.Text) & ", " & intSelectedTransaction & ", " _
            & "'" & gwt_comm.shortMonthDateFormat(dpProcessDate) & "', " & dblSumDiscounts & ", " & dblSumTaxes & ", " _
            & "" & dblSumPayable & ", '" & strUserName & "', '" & cboPersonnel.Text & "', " _
            & "'" & txtAccountName.Text & "', '" & sDocumentCustomerAddress1 & "', '" & sDocumentCustomerAddress2 & "', " _
            & "'" & sDocumentCustomerAddress3 & "', '" & sDocumentCustomerAddress4 & "', '" & sDocumentCustomerTelephone & "', " _
            & "'" & sDocumentCustomerEmailAddress & "', '" & sDocumentCustomerVatNumber & "', '" & strUserBranch & "', " _
            & "'" & txtRepairsReport.Text & "')", cnn)
        myCommand.ExecuteNonQuery()

        'Update the job card data as well
        myCommand = New Data.OleDb.OleDbCommand("UPDATE JobCards SET Status = 'CLOSED', " _
            & "ContraInvoiceNumber = " & CInt(txtReference.Text) & ", JobValue = " & dblSumPayable & "" _
            & "WHERE ReferenceNumber = " & intSelectedTransaction & "", cnn)
        myCommand.ExecuteNonQuery()

        'update the default sales account as well
        If String.IsNullOrEmpty(strPublicSalesAccount) Then
            MessageBox.Show("The sales control account has not been setup. This will serious affect the trial balance", _
                "Sales Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference]) VALUES " _
                & "('" & strPublicSalesAccount & "', '" & dpProcessDate & "', " & dblSumPayable & ", 'CREDIT', '" & "JC-" & intSelectedTransaction & "', '" & txtAccountName.Text & "', '" & strUserName & "', '" & strUserBranch & "', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
            myCommand.ExecuteNonQuery()
        End If

        'Update the debtors control account
        'If String.IsNullOrEmpty(strPublicDebtorsAccount) Then
        '    MessageBox.Show("The debtors control account has not been setup. This will serious affect the trial balance", MsgBoxStyle.Exclamation, "Debtors Control Account Not Set")
        'Else
        '    myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference]) VALUES " _
        '        & "('" & strPublicDebtorsAccount & "', '" & dpProcessDate & "', " & dblSumPayable & ", 'DEBIT', '" & "JC-" & intSelectedTransaction & "', '" & txtAccountName.Text & "', '" & strUserName & "', '" & strUserBranch & "', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
        '    myCommand.ExecuteNonQuery()
        'End If

        'Update the control numbers table
        myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET JobInvoices = " & CDbl(txtReference.Text) & "", cnn)
        myCommand.ExecuteNonQuery()

        'strPublicCustomerId = txtAccountName.Text
        MessageBox.Show("Job Card Invoice document generated successfully.", "Transaction Document Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Transaction Processing"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadMaterialsDetails()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT TransDate, ItemCode, Quantity, " _
            & "SalesPrice, TransType, Description, Taxes, DiscountAllowed, ProductType, SerialNumbers, " _
            & "UserName, SalesRep FROM JobInvoiceDetails WHERE ReferenceNumber = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim strAgent As String = Nothing
        Dim strCustomerNumber As String = Nothing
        With dGrid
            Dim i As Double = 0
            While objReader.Read
                If Not IsDBNull(objReader("SalesRep").ToString) Then cboPersonnel.Text = objReader("SalesRep").ToString
                If Not IsDBNull(objReader(1).ToString) Then .Rows(i).Cells(0).Value = objReader(1).ToString
                If Not IsDBNull(objReader(5).ToString) Then .Rows(i).Cells(2).Value = objReader(5).ToString
                If Not IsDBNull(objReader(9).ToString) Then .Rows(i).Cells(3).Value = objReader(9).ToString
                If IsNumeric(objReader(3).ToString) Then .Rows(i).Cells(5).Value = Format(CDbl(objReader(3).ToString), "##0.00") Else .Rows(i).Cells(5).Value = "0.00"
                If Not IsDBNull(objReader(2).ToString) Then .Rows(i).Cells(6).Value = objReader(2).ToString
                If IsNumeric(objReader(6).ToString) Then .Rows(i).Cells(9).Value = Format(CDbl(objReader(6).ToString), "##0.00") Else .Rows(i).Cells(8).Value = "0.00"
                If IsNumeric(objReader(7).ToString) Then .Rows(i).Cells(8).Value = Format(CDbl(objReader(7).ToString), "##0.00") Else .Rows(i).Cells(7).Value = "0.00"
                If Not IsDBNull(objReader(8).ToString) Then .Rows(i).Cells(11).Value = objReader(8).ToString
                ComputeValues(CDbl(dGrid.Rows(i).Cells(5).Value.ToString), CDbl(dGrid.Rows(i).Cells(6).Value.ToString), dGrid.Rows(i).Index, dGrid.Rows(i).Cells(8).Value.ToString, dGrid.Rows(i).Cells(9).Value.ToString)
                i = i + 1
            End While
            objReader.Close()
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Job Card Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        PrintDocumentInvoice()
    End Sub

    Private Sub PrintDocumentInvoice()
        boolPrintFromPreview = True
        'Dim pd As New PrintDialog()
        'pd.ShowDialog()
        'pd.PrinterSettings = New PrinterSettings()
        'strSessionPrinter = pd.PrinterSettings.PrinterName


        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()

        If strRequestForReceiptPrinter = "YES" Then
            boolAbort = False
            gwt_comm.PrinterSelection()
            If boolAbort = True Then Exit Sub
            pd.PrinterSettings.PrinterName = strSessionPrinter
            PrintDocument1.PrinterSettings = pd.PrinterSettings
        End If

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()

        'PrintDocument1.PrinterSettings = pd.PrinterSettings '.PrinterName = strSessionPrinter
        'PrintPreviewDialog1.Document = PrintDocument1
        'PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub cboItems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboItems.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(1)
            dGrid.Focus()
        End If
    End Sub

    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter
        On Error GoTo RaiseErr
        If boolFormIsLoading = True Then Exit Sub
        If cboItems.Visible = True Then cboItems.Visible = False
        If e.ColumnIndex = 0 Then
            LoadData()
            cboItems.Size = dGrid.CurrentCell.Size
            cboItems.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top
            cboItems.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left + 3
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                cboItems.Text = Convert.ToString(dGrid.CurrentCell.Value)
            Else
                cboItems.Text = ""
            End If
            cboItems.Visible = True '152
            cboItems.Focus()
            cboItems.SelectAll()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Serial Numbers Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.SelectedIndexChanged
        CommitValueChanged()
    End Sub

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr
        If cboItems.Focused = False Then Exit Sub
        Dim objCommand As Data.OleDb.OleDbCommand
        For z As Integer = 0 To dGrid.Columns.Count - 1
            If z = 1 Or z = 4 Then
                'do nothing 
            Else
                dGrid.Rows(dGrid.CurrentRow.Index).Cells(z).Value = Nothing
            End If
        Next
        RecalculateAmount()
        If Not cboItems.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(0).Value = cboItems.SelectedItem.Col1
            dGrid.CurrentRow.Cells(2).Value = cboItems.SelectedItem.Col2
            dGrid.CurrentRow.Cells(5).Value = cboItems.SelectedItem.Col3
            dGrid.CurrentRow.Cells(3).Value = ""
            dGrid.CurrentRow.Cells(6).Value = "1"
            dGrid.CurrentRow.Cells(8).Value = "0"

            'Apply the discount
            Dim strCodeSelected As String = cboItems.Text
            Dim dblSalePrice As Double = 0
            objCommand = New Data.OleDb.OleDbCommand("SELECT InventoryType, SellingPrice FROM InventoryItems " _
                & "WHERE ItemCode = '" & strCodeSelected & "'", cnn)
            Dim objReadType As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadType.HasRows Then
                objReadType.Read()
                If Not IsDBNull(objReadType(0).ToString) Then
                    If UCase(objReadType(0).ToString) = "SPECIFIC" Then
                        dGrid.CurrentRow.Cells(6).ReadOnly = True
                    End If
                End If
                If IsNumeric(objReadType(1).ToString) Then dblSalePrice = CDbl(objReadType(1).ToString)
            End If
            objReadType.Close()
            Dim dblDiscounts() As Double = gwt_comm.ItemOnSpecials(strCodeSelected, dblSalePrice)
            dGrid.CurrentRow.Cells(8).Value = CStr(Format((dblDiscounts(1) * CDbl(dGrid.CurrentRow.Cells(6).Value.ToString)), "##0.00"))

            ComputeValues(CDbl(dGrid.CurrentRow.Cells(5).Value.ToString), CDbl(dGrid.CurrentRow.Cells(6).Value.ToString), dGrid.CurrentRow.Index, dGrid.CurrentRow.Cells(8).Value.ToString, 0)
        Else
            dGrid.CurrentRow.Cells(0).Value = Nothing
            dGrid.CurrentRow.Cells(2).Value = Nothing
            dGrid.CurrentRow.Cells(5).Value = Nothing
            dGrid.CurrentRow.Cells(6).Value = Nothing
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On discount computation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboItems_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.Validated
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(cboItems.Text) Then Exit Sub

        If UCase(cboItems.Text) = UCase("--- COMMENT ---") Or UCase(cboItems.Text) = UCase("--- SERVICE ---") Then Exit Sub

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM InventoryItems WHERE ItemCode = '" & cboItems.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows = False Then
            dGrid.CurrentRow.Cells(0).Value = Nothing
            dGrid.CurrentRow.Cells(2).Value = Nothing
            dGrid.CurrentRow.Cells(5).Value = Nothing
            dGrid.CurrentRow.Cells(6).Value = Nothing
            dGrid.CurrentRow.Cells(7).Value = Nothing
            dGrid.CurrentRow.Cells(8).Value = Nothing
            dGrid.CurrentRow.Cells(9).Value = Nothing
            dGrid.CurrentRow.Cells(10).Value = Nothing
        Else
            'Get the item type
            objReader.Read()
            If Not IsDBNull(objReader("InventoryType").ToString) Then dGrid.CurrentRow.Cells(11).Value = objReader("InventoryType").ToString
            'Load the serial numbers
            objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumber FROM SerialNumbers WHERE ItemCode = '" & cboItems.Text & "'", cnn)
            Dim objReadSerial As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            objCommand = New Data.OleDb.OleDbCommand("SELECT Category, SellingPrice FROM InventoryItems WHERE ItemCode = '" & cboItems.Text & "'", cnn)
            Dim objReadCategory As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadCategory.HasRows Then
                objReadCategory.Read()
                If Not IsDBNull(objReadCategory(0).ToString) Then
                    If UCase(objReadCategory(0).ToString) = "CELLPHONES" Then
                        If CDbl(objReadCategory(1).ToString) >= 100 And CDbl(objReadCategory(1).ToString) < 600 Then
                            dGrid.CurrentRow.Cells(8).Value = gwt_comm.RoundDown(objReadCategory(1) * 0.05)
                        End If
                        If CDbl(objReadCategory(1).ToString) >= 600 Then
                            dGrid.CurrentRow.Cells(8).Value = gwt_comm.RoundDown(objReadCategory(1) * 0.1)
                        End If
                    End If
                End If
            End If
        End If
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Sales Entry"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSalesData() As String = gwt_comm.SalesInventoryItems(strMainCompanyServiceOffering, strDefaultSearchFilter)
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSalesData(0), cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 4
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "160;180;60;60"
        End With
        'Get a count of the items
        Dim intItemsCount As Double = CDbl(strSalesData(1))
        Dim DropDownItems(intItemsCount + 1) As MTGCComboBoxItem

        cboItems.Items.Clear()
        Dim i As Double = 0
        Dim p As Double = 0

        'Add extra 1st lines for comment
        DropDownItems(p) = New MTGCComboBoxItem("--- COMMENT ---", "", "0.00", "NO")
        p += 1
        DropDownItems(p) = New MTGCComboBoxItem("--- SERVICE ---", "", "0.00", "NO")
        p += 1
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2), strRecordText(3))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboItems.SelectedIndex = -1
            cboItems.Items.Clear()
            cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboItems.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellClick
        intTotalSerialNumbersSelected = 0
        If boolFormIsLoading = True Then Exit Sub
        If dGrid.CurrentCell.ColumnIndex = 4 Then
            strSerialNumberForTransfer = Nothing
            Dim intRow As Double = dGrid.CurrentCell.RowIndex
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(0).Value), "")) Then
                strPublicItemCode = dGrid.CurrentRow.Cells(0).Value.ToString
                boolAbort = False
                Dim f As New frmSerialNumberSelection
                f.ShowDialog()
                If boolAbort = True Then Exit Sub
                If arrSelectedSerialNumbers.Count > 0 Then
                    If isItemAlreadyAdded(dGrid.CurrentRow.Cells(0).Value.ToString, arrSelectedSerialNumbers.Item(0)) = True Then
                        MessageBox.Show("Item cannot be added to transfer multiple time", "Process Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        For p As Integer = 0 To dGrid.Columns.Count - 1
                            If p = 1 Or p = 4 Then
                                'do nothing 
                            Else
                                dGrid.CurrentRow.Cells(p).Value = Nothing
                            End If
                        Next
                        RecalculateAmount()
                        Exit Sub
                    End If
                    dGrid.CurrentRow.Cells(3).Value = arrSelectedSerialNumbers.Item(0)
                    dGrid.CurrentRow.Cells(6).Value = "1" 'intTotalSerialNumbersSelected
                End If
                ComputeValues(CDbl(dGrid.CurrentRow.Cells(5).Value.ToString), CDbl(dGrid.CurrentRow.Cells(6).Value.ToString), dGrid.CurrentRow.Index, dGrid.CurrentRow.Cells(8).Value.ToString, 0)
            End If
        End If
        If dGrid.CurrentCell.ColumnIndex = 1 Then
            strPublicItemCode = Nothing
            gwt_comm.InventorySearch()
            If Not String.IsNullOrEmpty(strPublicItemCode) Then
                cboItems.Text = strPublicItemCode
            End If
        End If
    End Sub

    Public Function isItemAlreadyAdded(ByVal ItemCode As String, ByVal SerialNumber As String) As Boolean
        Dim boolReturn As Boolean = False
        For i As Double = 0 To dGrid.Rows.Count - 1
            Dim strCode As String = Nothing
            Dim strSerial As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strCode = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                strSerial = Convert.ToString(dGrid.Rows(i).Cells(3).Value)
            End If
            If UCase(strCode) = UCase(ItemCode) And UCase(strSerial) = UCase(SerialNumber) Then
                boolReturn = True
                Exit For
            End If
        Next
        Return boolReturn
    End Function

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnDetails_Click(sender As Object, e As System.EventArgs) Handles btnDetails.Click
        boolAbort = False
        Dim frm As New frmCustomerKeyInformation
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        txtContactDetails.Text = sDocumentCustomerAddress1 & " " & sDocumentCustomerAddress2 & " " & sDocumentCustomerAddress3 & " " & sDocumentCustomerTelephone
    End Sub

    Private Sub frmJobInvoicing_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 846 : Me.Height = 610
    End Sub

End Class
