Imports System.Drawing.Printing
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmJobCardEntry

    Dim prFont As New Font("Verdana", 8, FontStyle.Bold)
    Dim tlFont As New Font("Verdana", 8, FontStyle.Regular)
    Dim HeaderFont As New Font("Verdana", 12, FontStyle.Bold)
    Dim strTaxStatus As String = Nothing
    Dim strCustomerDetails As String

    Dim i As Integer = 0
    Dim strvalue As String
    Dim strDate As String
    Dim itm As Integer
    Dim boolPrintFromPreview As Boolean
    Dim intPaymentReceiptNumber As Integer
    Dim strCustomerAccountNumberPayments As String

    Dim strCustomerName As String
    Dim strCustomerAddress1 As String
    Dim strCustomerAddress2 As String
    Dim strCustomerAddress3 As String
    Dim strCustomerAddress4 As String
    Dim strCustomerTelephone As String
    Dim strCustomerEmailAddress As String
    Dim strCustomerVatNumber As String

    Dim dblInspectionFee As Double

    Dim strProblemBrief As String
    Dim strItemStatus As String

    Dim intPage As Integer

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        boolAbort = False
        FinishTransaction()
        If boolAbort = True Then Exit Sub
        Cursor = Cursors.Default
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Job Card entry"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub pdJobCard_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdJobCard.PrintPage
        If boolPrintFromPreview = True Then
            'requery records
            boolAbort = False
            Me.GenerateTransactionDocument(CInt(txtReference.Text))
            If boolAbort = True Then Exit Sub
            boolPrintFromPreview = False
        End If
        Dim strDType As String
        strDType = "JOB CARD"
        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer
        'Dim xx1 As Integer, xx2 As Integer, yy1 As Integer, yy2 As Integer
        x1 = e.PageBounds.Left + 100
        y1 = e.PageBounds.Top + 100
        p1 = e.PageBounds.Width - 200
        y2 = e.PageBounds.Height - 200

        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        Dim strS As String = Nothing
        Dim Yc As Integer
        Dim cols, lines As Integer

        'Draw the document rectangle
        reccurrent = New Rectangle(x1, y1, p1, y2)
        e.Graphics.DrawRectangle(Pens.Black, reccurrent)

        'print the company logo
        Dim g As Graphics = e.Graphics
        g.DrawString("JOB CARD", New Font("Arial", 24, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, Color.Black)), 500, e.PageBounds.Top + 120)

        Dim intLogoNextXPosition As Integer = intLogoXposition

        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoXposition, intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                intLogoNextXPosition = R.X + R.Width + 3
            End If
        End If

        If Not String.IsNullOrEmpty(strBrandImage1) Then
            If System.IO.File.Exists(strBrandImage1) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strBrandImage1)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoNextXPosition, intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                intLogoNextXPosition = R.X + R.Width + 3
            End If
        End If
        If Not String.IsNullOrEmpty(strBrandImage2) Then
            If System.IO.File.Exists(strBrandImage2) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strBrandImage2)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoNextXPosition, intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                intLogoNextXPosition = R.X + R.Width + 3
            End If
        End If
        If Not String.IsNullOrEmpty(strBrandImage3) Then
            If System.IO.File.Exists(strBrandImage3) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strBrandImage3)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoNextXPosition, intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                intLogoNextXPosition = R.X + R.Width + 3
            End If
        End If
        If Not String.IsNullOrEmpty(strBrandImage4) Then
            If System.IO.File.Exists(strBrandImage4) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strBrandImage4)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoNextXPosition, intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                intLogoNextXPosition = R.X + R.Width + 3
            End If
        End If

        y1 = y1 + 30
        'Print the company details at the extreme left of document
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, HeaderFont, Brushes.Black)
        'e.Graphics.DrawString(strDType, HeaderFont, Brushes.Black, 500, e.PageBounds.Top + 120)
        y1 = y1 + 20
        Dim strAddressInfo As String = strCompanyAddress1 & vbCrLf & strCompanyAddress2 & vbCrLf & strCompanyAddress3 & vbCrLf & strCompanyAddress4 & vbCrLf & "Tel : " & strCompanyTelephone & " Fax : " & strCompanyFaxNumber & vbCrLf & "Email : " & strCompanyEmailAddress
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
        'If strCustomerName.Length > 58 Then strCustomerName = Mid(strCustomerName, 1, 58)
        e.Graphics.DrawString(UCase(strCustomerName), tlFont, Brushes.Black, x1, y1)
        'e.Graphics.DrawString(strCustomerName, tlFont, Brushes.Black, x1, y1)
        'Print the date
        e.Graphics.DrawString("DATE : " & strDate, tlFont, Brushes.Black, 500, y1)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "JOB CARD NO. : " & Format(CLng(txtReference.Text), "000000"), tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress1, tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress2, tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "ITEM DETAILS  : " & txtItemName.Text, tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress3, tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "SERIAL NUMBER : " & txtSerialNumber.Text, tlFont, Brushes.Black)
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
        ''Call DrawStringInBoxLeft(e, x1, y1, 60, 80, "QTY", prFont, Brushes.Black)
        ''Call DrawStringInBoxLeft(e, x2, y1, 250, 80, "DESCRIPTION", prFont, Brushes.Black)
        ''Call DrawStringInBoxRight(e, X3, y1, 120, 80, "UNIT PRICE", prFont, Brushes.Black)
        ''Call DrawStringInBoxRight(e, X4, y1, 120, 80, "TAX", prFont, Brushes.Black)
        ''Call DrawStringInBoxRight(e, X5, y1, 120, 80, "DISCOUNT", prFont, Brushes.Black)
        ''Call DrawStringInBoxRight(e, X6, y1, 120, 80, "TOTAL", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 300, 80, "FAULT REPORT", prFont, Brushes.Black)
        'draw a line after
        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 30
        itm = 0
        reccurrent = New Rectangle()

        'Print the description last as it is the column that will determine the next line position
        If Not strProblemBrief Is Nothing Then strvalue = strProblemBrief Else strvalue = ""
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 550, 80, strvalue, tlFont, Brushes.Black)
        'Get the size of the address box
        e.Graphics.MeasureString(strvalue, tlFont, New SizeF(550, 80), New StringFormat(), cols, lines)
        Yc = y1
        y1 = y1 + lines * tlFont.Height + 5
        y1 = Math.Max(y1, Yc)

        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 300, 80, "ITEM CONDITION", prFont, Brushes.Black)
        'draw a line after
        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 30


        'Print the INSPECTION FEE DETAILS
        Dim strChargePin As String = "YES"
        Dim strAerial As String = "YES"
        Dim strSwitchingOn As String = "YES"
        Dim strSignal As String = "YES"
        Dim strLcd As String = "YES"
        Dim strCracked As String = "YES"
        Dim strScratches As String = "YES"

        Dim arrItemStatus As New ArrayList
        arrItemStatus = GetItemStatus()

        For j As Integer = 0 To arritemstatus.count - 1
            Dim strSplitData() As String = Split(arrItemStatus.Item(j), "|")
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 150, 80, UCase(strSplitData(0)) & "(" & UCase(strSplitData(1)) & ")", tlFont, Brushes.Black)
            y1 = y1 + 15
        Next

        y1 = y1 + 20

        If Not strItemStatus Is Nothing Then strvalue = strItemStatus Else strvalue = ""
        Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 500, 80, strvalue, tlFont, Brushes.Black)
        'Get the size of the address box
        e.Graphics.MeasureString(strvalue, tlFont, New SizeF(500, 80), New StringFormat(), cols, lines)
        Yc = y1
        y1 = y1 + lines * tlFont.Height + 5
        y1 = Math.Max(y1, Yc)

        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 300, 80, "INSPECTION FEE PAID " & Format(dblInspectionFee, "##0.00"), prFont, Brushes.Black)

        y1 = y1 + 30
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 600, 80, strJobCardConditions, prFont, Brushes.Black)
        y1 = y1 + 15
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 600, 80, "Cheque payments must clear before phones are relased. Payments by RTGS to :", prFont, Brushes.Black)

        'y1 += 40
        'Call DrawStringInBoxLeft(e, x1, y1, 550, 80, Format(dblInspectionFee, "##0.00"), tlFont, Brushes.Black)

        e.HasMorePages = False
        Me.boolPrintFromPreview = True

    End Sub

    Private Sub GenerateTransactionDocument(ByVal intDocumentNumber As Integer)
        'get invoice number
        On Error GoTo RaiseErr
        Dim n As Integer = 0
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim myCommand As Data.OleDb.OleDbCommand

        myCommand = New Data.OleDb.OleDbCommand("Select CONVERT(NVARCHAR, TransDate, 105) as [TransDate], CustomerName, " _
            & "Address1, Address2, Address3, Address4, ContactNumber, EmailAddress, InspectionFee, " _
            & "TaxNumber, ProblemBrief, ItemState FROM JobCards Where ReferenceNumber = " & intDocumentNumber & "", cnn)
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
            If IsNumeric(dbReader(8).ToString) Then dblInspectionFee = CDbl(dbReader(8).ToString) Else dblInspectionFee = 0
            If Not IsDBNull(dbReader(9).ToString) Then strCustomerVatNumber = dbReader(9).ToString
            If Not IsDBNull(dbReader(10).ToString) Then strProblemBrief = dbReader(10).ToString
            If Not IsDBNull(dbReader(11).ToString) Then strItemStatus = dbReader(11).ToString
        End If
        dbReader.Close()

        boolPrintFromPreview = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Quote Generation Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub FinishTransaction()
        On Error GoTo RaiseErr
        If boolEditStatus = True Then
            Dim objDeleteOld As New Data.OleDb.OleDbCommand("DELETE FROM JobCards WHERE ReferenceNumber = " & txtReference.Text, cnn)
            objDeleteOld.ExecuteNonQuery()
        End If

        'First insert the job card details

        '[Cracked][NVARCHAR](3) NOT NULL DEFAULT 'NO'
        Dim strChargePin As String = "YES"
        Dim strAerial As String = "YES"
        Dim strSwitchingOn As String = "YES"
        Dim strSignal As String = "YES"
        Dim strLcd As String = "YES"
        Dim strCracked As String = "YES"
        Dim strScratches As String = "YES"

        Dim dtTransDate As String = Format(CInt(DatePart(DateInterval.Day, dpDateOn.Value)), "00") & _
            "-" & UCase(Mid((MonthName(DatePart(DateInterval.Month, dpDateOn.Value))), 1, 3)) & "-" & _
            DatePart(DateInterval.Year, dpDateOn.Value)
        Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO JobCards ([TransDate], " _
            & "[CustomerName], [Address1], [Address2], [Address3], [Address4], [ContactNumber], [EmailAddress], " _
            & "[UserName], [UserBranch], [ReferenceNumber], [ProblemBrief], [ItemState], [InspectionFee], [TaxNumber], " _
            & "[Status], [ItemName], [SerialNumber]) " _
            & "VALUES ('" & dtTransDate & "', '" & txtAccountName.Text & "', '" & sDocumentCustomerAddress1 & "', " _
            & "'" & sDocumentCustomerAddress2 & "', '" & sDocumentCustomerAddress3 & "', " _
            & "'" & sDocumentCustomerAddress4 & "', '" & sDocumentCustomerTelephone & "', '" & sDocumentCustomerEmailAddress & "', " _
            & "'" & strUserName & "', '" & strUserBranch & "', " & CInt(txtReference.Text) & ", " _
            & "'" & txtProblem.Text & "', '" & txtState.Text & "', " _
            & "" & CDbl(txtInspectionFee.Text) & ", '" & sDocumentCustomerVatNumber & "', '" & strSelectedStatus & "', " _
            & "'" & txtItemName.Text & "', '" & txtSerialNumber.Text & "')", cnn)
        objCommand.ExecuteNonQuery()

        UpdateItemConditions()

        If boolEditStatus = False Then

            objCommand = New Data.OleDb.OleDbCommand("Update ControlNumbers SET JobCards = " & CInt(txtReference.Text) & "", cnn)
            objCommand.ExecuteNonQuery()

            'Update the cashbook account as well as the sales account book
            Dim strCashbookDescription As String = "CASH SALE - " & UCase(strUserName)
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, " _
                & "TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, TransactionType, Reference) VALUES " _
                & "('" & strPublicActiveCashbook & "', '" & dtTransDate & "', " & CDbl(txtInspectionFee.Text) & ", " _
                & "'" & strCashbookDescription & "', '" & strPublicSalesAccount & "', '" & strUserName & "', " _
                & "'" & strUserBranch & "', 'DEBIT', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
            objCommand.ExecuteNonQuery()

            'Post the account to the contra ledger account
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber]," _
                & "[TransactionDate],[Amount],[TransactionType],[ContraAccount],[Description],[UserName]," _
                & "[UserBranch], [Reference]) VALUES " _
                & "('" & strPublicSalesAccount & "', '" & dtTransDate & "', " & CDbl(txtInspectionFee.Text) & ", " _
                & "'CREDIT', '" & strPublicActiveCashbook & "', '" & strCashbookDescription & "', " _
                & "'" & strUserName & "', '" & strUserBranch & "', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
            objCommand.ExecuteNonQuery()

        End If

        'Print the inspection fee document
        GenerateTransactionDocument(CInt(txtReference.Text))

        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()

        If strRequestForReceiptPrinter = "YES" Then
            boolAbort = False
            gwt_comm.PrinterSelection()
            If boolAbort = True Then Exit Sub
            pd.PrinterSettings.PrinterName = strSessionPrinter
            pdJobCard.PrinterSettings = pd.PrinterSettings
        End If

        PrintPreviewDialog1.Document = pdJobCard
        PrintPreviewDialog1.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        'roll back the transaction
        Dim objDelete As New Data.OleDb.OleDbCommand("DELETE FROM JobCards WHERE ReferenceNumber = " & txtReference.Text, cnn)
        objDelete.ExecuteNonQuery()
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Job Card Generation Error"
        gwt_comm.ShowErrorMessage()
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
            If Not IsDBNull(objReader("ProblemBrief").ToString) Then txtProblem.Text = objReader("ProblemBrief").ToString
            If IsDate(objReader("TransDate").ToString) Then dpDateOn.Value = CDate(objReader("TransDate").ToString)
            If Not IsDBNull(objReader("ItemState").ToString) Then txtState.Text = objReader("ItemState").ToString
            If IsNumeric(objReader("InspectionFee").ToString) Then txtInspectionFee.Text = Format(CDbl(objReader("InspectionFee").ToString), "##0.00")
            If Not IsDBNull(objReader("ItemName").ToString) Then txtItemName.Text = objReader("ItemName").ToString
            If Not IsDBNull(objReader("SerialNumber").ToString) Then txtSerialNumber.Text = objReader("SerialNumber").ToString
        End If
        objReader.Close()

        txtContactDetails.Text = sDocumentCustomerAddress1 & " " & sDocumentCustomerAddress2 & " " & sDocumentCustomerAddress3 & " " & sDocumentCustomerTelephone

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Job Card Details Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmJobCardEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = False Then
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("JobCards"))
        Else
            LoadJobCardDetails()
        End If
        LoadItemConditions()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtReference.Text) Then
            MessageBox.Show("Missing document number", "Missing Document Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountName.Text) Then
            MessageBox.Show("Please enter the prospect name", "Missing Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtProblem.Text) Then
            MessageBox.Show("Please enter the presenting problem", "Missing Problem Definition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtProblem.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtInspectionFee.Text) Then
            MessageBox.Show("Please enter the correct value for inspection fee", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtInspectionFee.Focus()
            Exit Sub
        End If
        SaveData()
    End Sub

    Private Sub btnDetails_Click(sender As Object, e As System.EventArgs) Handles btnDetails.Click
        boolAbort = False
        Dim frm As New frmCustomerKeyInformation
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        txtContactDetails.Text = sDocumentCustomerAddress1 & " " & sDocumentCustomerAddress2 & " " & sDocumentCustomerAddress3 & " " & sDocumentCustomerTelephone
    End Sub

    Private Function GetItemStatus() As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList
        For p As Integer = 0 To dGridAirCards.Rows.Count - 1
            Dim strDescription As String = Nothing
            If Not Object.Equals(dGridAirCards.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridAirCards.Rows(p).Cells(1).Value.ToString) Then
                    strDescription = dGridAirCards.Rows(p).Cells(1).Value.ToString
                End If
            End If
            If dGridAirCards.Rows(p).Cells(0).Value = True Then
                arrReturn.Add(strDescription & "|YES")
            End If
        Next
        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Item Condition Status Update"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub UpdateItemConditions()
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = "DELETE FROM JobCardItemCondition WHERE JobNumber = " & txtReference.Text & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        With dGridAirCards
            For p As Integer = 0 To dGridAirCards.RowCount - 1
                If .Rows(p).Cells(0).Value = True Then
                    strSql = "INSERT INTO JobCardItemCondition ([JobNumber], [ServiceKey]) VALUES " _
                        & "(" & txtReference.Text & ", " & CInt(.Rows(p).Cells(4).Value.ToString) & ")"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            Next
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Job Card Details Save Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadItemConditions()
        On Error GoTo RaiseErr
        dGridAirCards.Rows.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ServiceName, TransactionId FROM JobsServicesParameters ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGridAirCards.Rows.Add(False, objReader(0).ToString, objReader(1).ToString)
            End If
        End While
        objReader.Close()

        If boolEditStatus = True Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT ServiceKey FROM JobCardItemCondition " _
                & "WHERE JobNumber = " & intSelectedTransaction & "", cnn)
            objReader = objCommand.ExecuteReader
            While objReader.Read
                For p As Integer = 0 To dGridAirCards.RowCount - 1
                    If CInt(dGridAirCards.Rows(p).Cells(2).Value.ToString) = CInt(objReader(0).ToString) Then
                        dGridAirCards.Rows(p).Cells(0).Value = True
                        Exit For
                    End If
                Next
            End While
            objReader.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Job Card Details Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
