Imports System.Drawing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class DocumentWriter

    ' Inherits all the functionality of a PrintDocument
    Inherits Drawing.Printing.PrintDocument

    'Passed from the calling procedure

    Public CustomerVatNumber As String
    Public CustomerBPNumber As String
    Public CustomerName As String
    Public CustomerAddress1 As String
    Public CustomerAddress2 As String
    Public CustomerAddress3 As String
    Public CustomerAddress4 As String
    Public CustomerTelephone As String
    Public CustomerEmailAddress As String
    Public ReferenceNumber As Long
    Public OrderNumber As String
    Public SalesRep As String
    Public PrintDate As String
    Public DocumentType As String

    Public DiscountAllowed As Double
    Public TaxesCharged As Double
    Public DocumentTotal As Double

    Public ColumnHeaders As String
    Public PrintBankingDetails As Boolean
    Public PrintSummaryTotals As Boolean
    Public DocumentNotes As String

    Dim fntPrintFont, titleFont, fntPrintFontBold As System.Drawing.Font
    Dim clrAlternateBackColor As System.Drawing.Color
    Dim clrFooterColor As System.Drawing.Color
    Dim clrTitleColor As System.Drawing.Color
    Dim clrBorderColor As System.Drawing.Color

    Dim clrDetailColor As System.Drawing.Color
    Dim fntTitleFont As System.Drawing.Font
    Dim fntFooterFont As System.Drawing.Font

    Dim clrGridColor As System.Drawing.Color
    'Dim strLogoPath As String

    Dim pageNum As Integer
    Dim boolPrintingNextPage As Boolean
    Dim strvalue As String

    'our user defined report will print as many columns as defined by the user
    Dim X() As Integer
    Dim W() As Integer
    Dim Y As Integer
    Dim itm As Integer
    Dim dtCurrent As Date
    Dim strNewSql As String
    Dim sNewDatabaseConnection As String

    Dim strFooter As String
    Dim strMainHeader As String

    Dim boolGenericReportFlag As Boolean

    Dim boolGroup As Boolean
    Dim intGroupFieldIndex As Integer
    Dim strBreakKey As String

    Dim dblTotal() As Double
    Dim dblSubTotal() As Double

    Private WithEvents objPageArgs As System.Drawing.Printing.PrintPageEventArgs
    Dim O As Object, P As System.Drawing.Printing.PrintPageEventArgs
    Dim R As Drawing.Rectangle
    Dim boolSummaryPrintTotals As Boolean
    Dim boolPrintSummary As Boolean
    Dim boolDrawSummaryChart As Boolean
    Dim boolDrawBorder As Boolean
    Dim boolDrawVerticalLines As Boolean
    Dim boolDrawHorizontalLines As Boolean

    Dim intLineCounter As Single

    Public strPrintValues() As String 'obtained from the sending module
    Public intNumberOfColumns As Integer

    'Declaration for parameters
    Public strColumnAlignments As String
    Public strColumnType As String 'Determines whether the column holds dates, numbers, text, currency. The default is the text
    Public strColumnHeaders As String

    Public strSummaryCaptions As String
    Public strSummaryValues As String
    Public strSummaryAlignments As String

    Public strColumnWidths As String
    Public strHighlightColors As String 'Default is black font
    Public strColumnTotals As String
    Public strColumnFormating As String
    Public boolPrintRecordCount As Boolean = False
    Public strSummaryTotals As String = Nothing
    Public VisibleColumns As String
    Public NewPageBreak As Boolean
    Public RestartPageNumbersOnGroupChange As Boolean
    Public strMainHeader2 As String = Nothing
    Public strMainHeader3 As String = Nothing

    Dim intArrayCount As Integer
    Dim strBuffer() As String
    Dim intSortKeyIndex As Integer

    'The following declarations handle the graph printing
    Public strCountValues As String
    Public intCountIndicatorField As Integer
    Public boolPrintGraph As Boolean = False
    Dim intGraphValues() As Double
    Dim boolIsPrintingGraph As Boolean = False
    Dim strGroupTitle As String = Nothing
    Dim boolPrintingFinalPage As Boolean = False

    Protected Overrides Sub OnBeginPrint(ByVal ev _
          As Drawing.Printing.PrintEventArgs)
        ' Run base code
        MyBase.OnBeginPrint(ev)
        ' Sets the default font
        If fntPrintFont Is Nothing Then
            fntPrintFont = New Drawing.Font("Arial", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
        End If
        If fntTitleFont Is Nothing Then
            fntTitleFont = New Drawing.Font("Arial", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
        End If
        If fntPrintFontBold Is Nothing Then
            fntPrintFontBold = New Drawing.Font("Arial", 7, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
        End If
        itm = 0
        ReDim dblTotal(intNumberOfColumns - 1)
        ReDim dblSubTotal(intNumberOfColumns - 1)
        Dim iCnt As Integer = 0
        For iCnt = 0 To intNumberOfColumns - 1
            dblSubTotal(iCnt) = 0
            dblTotal(iCnt) = 0
        Next
        'Get the count items for the graph and reset the values to 0 by redim
        If boolPrintGraph = True Then
            If Not String.IsNullOrEmpty(strCountValues) Then
                Dim strSplitCount() As String = Split(strCountValues, "|")
                ReDim intGraphValues(0 To strSplitCount.Length - 1)
            End If
        End If
        'get the print record array
        pageNum = 0 : boolPrintingNextPage = False
    End Sub

    Public Property DetailFont() As Drawing.Font
        'font used for the details printing
        Get
            Return fntPrintFont
        End Get
        Set(ByVal Value As Drawing.Font)
            fntPrintFont = Value
        End Set
    End Property

    Public Property FooterFont() As Drawing.Font
        'font used for the details printing
        Get
            Return fntFooterFont
        End Get
        Set(ByVal Value As Drawing.Font)
            fntFooterFont = Value
        End Set
    End Property

    Public Property HeaderFont() As Drawing.Font
        'the font that will be used for the report and page header
        Get
            Return fntTitleFont
        End Get
        Set(ByVal Value As Drawing.Font)
            fntTitleFont = Value
        End Set
    End Property

    Public Property AlternateBackColor() As Drawing.Color
        'For the alternate back color
        Get
            Return clrAlternateBackColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrAlternateBackColor = Value
        End Set
    End Property

    Public Property GridColor() As Drawing.Color
        'if grid lines will be printed, the grid color property is obtained here. Default is black
        Get
            Return clrGridColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrGridColor = Value
        End Set
    End Property

    Public Property FooterColor() As Drawing.Color
        'if grid lines will be printed, the grid color property is obtained here. Default is black
        Get
            Return clrFooterColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrFooterColor = Value
        End Set
    End Property

    Public Property TitleColor() As Drawing.Color
        'if grid lines will be printed, the grid color property is obtained here. Default is black
        Get
            Return clrTitleColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrTitleColor = Value
        End Set
    End Property

    Public Property BorderColor() As Drawing.Color
        'if grid lines will be printed, the grid color property is obtained here. Default is black
        Get
            Return clrBorderColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrBorderColor = Value
        End Set
    End Property

    Public Property DetailColor() As Drawing.Color
        'if grid lines will be printed, the grid color property is obtained here. Default is black
        Get
            Return clrDetailColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrDetailColor = Value
        End Set
    End Property

    Public Property SqlStatement() As String
        'if the details will be obtained from an sql statement
        Get
            Return strNewSql
        End Get
        Set(ByVal Value As String)
            strNewSql = Value
        End Set
    End Property

    Public Property intPrintRecordsCount() As Integer
        ' number of records that are being sent for printing
        Get
            Return intArrayCount
        End Get
        Set(ByVal Value As Integer)
            intArrayCount = Value
        End Set
    End Property

    Public Property intBreakIndex() As Integer
        ' determines index of the detail column that will trigger a group break
        Get
            Return intSortKeyIndex
        End Get
        Set(ByVal Value As Integer)
            intSortKeyIndex = Value
        End Set
    End Property

    Public Property strFooterCaption() As String
        ' Allows the user to print page footer
        Get
            Return strFooter
        End Get
        Set(ByVal Value As String)
            strFooter = Value
        End Set
    End Property

    Public Property strMainCaption() As String
        'Gets and set the page title
        Get
            Return strMainHeader
        End Get
        Set(ByVal Value As String)
            strMainHeader = Value
        End Set
    End Property

    Public Property boolGenericReport() As Boolean
        'determines if the report will be used for computed values or not
        Get
            Return boolGenericReportFlag
        End Get
        Set(ByVal Value As Boolean)
            boolGenericReportFlag = Value
        End Set
    End Property

    Public Property boolGroupDetails() As Boolean
        'Sets whether like items will be grouped or not
        Get
            Return boolGroup
        End Get
        Set(ByVal Value As Boolean)
            boolGroup = Value
        End Set
    End Property

    Public Property intKeyFieldIndex() As Integer
        'The index of the field that will trigger the grouping and sub totalling
        Get
            Return intGroupFieldIndex
        End Get
        Set(ByVal Value As Integer)
            intGroupFieldIndex = Value
        End Set
    End Property

    Public Property boolPrintTotals() As Boolean
        'Determines if the summary totals will be printed or not
        Get
            Return boolSummaryPrintTotals
        End Get
        Set(ByVal Value As Boolean)
            boolSummaryPrintTotals = Value
        End Set
    End Property

    Public Property strDatabaseConnectionString() As String
        'If connecting to the database, the connection string will be supplied and set thru this field
        Get
            Return sNewDatabaseConnection
        End Get
        Set(ByVal Value As String)
            sNewDatabaseConnection = Value
        End Set
    End Property

    Public Property LogoPath() As String
        'If the company logo will be printed this set the string path where the logo is located
        Get
            Return strLogoPath
        End Get
        Set(ByVal Value As String)
            strLogoPath = Value
        End Set
    End Property

    Public Property VerticalLines() As Boolean
        'determines if the report will be used for computed values or not
        Get
            Return boolDrawVerticalLines
        End Get
        Set(ByVal Value As Boolean)
            boolDrawVerticalLines = Value
        End Set
    End Property

    Public Property HorizontalLines() As Boolean
        'determines if the report will be used for computed values or not
        Get
            Return boolDrawHorizontalLines
        End Get
        Set(ByVal Value As Boolean)
            boolDrawHorizontalLines = Value
        End Set
    End Property

    Public Property DrawBorder() As Boolean
        'determines if the report will be used for computed values or not
        Get
            Return boolDrawBorder
        End Get
        Set(ByVal Value As Boolean)
            boolDrawBorder = Value
        End Set
    End Property

    Public Property DrawSummaryChart() As Boolean
        'determines if the report will be used for computed values or not
        Get
            Return boolDrawSummaryChart
        End Get
        Set(ByVal Value As Boolean)
            boolDrawSummaryChart = Value
        End Set
    End Property

    Public Property PrintSummary() As Boolean
        'determines if the report will be used for computed values or not
        Get
            Return boolPrintSummary
        End Get
        Set(ByVal Value As Boolean)
            boolPrintSummary = Value
        End Set
    End Property


    Protected Overrides Sub OnPrintPage(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        MyBase.OnPrintPage(e)

        'Declare the pen color for use now nd in future 
        Dim myPen As System.Drawing.Pen
        Dim myBrush As System.Drawing.Brush

        Dim intIterate As Integer = 0
        ReDim W(intNumberOfColumns - 1)
        ReDim X(intNumberOfColumns - 1)

        'Declarations for measuring string widths
        Dim zp As Integer = 0
        Dim xz As Integer = 0
        Dim yp As Integer = 0
        Dim intLongest As Integer = 0

        Dim intLinesMaximum As Integer = intDocumentLines '23
        If UCase(strMainCaption) = "GOODS RECEIVED NOTE" Then intLinesMaximum = 53

        'Set the column widths 

        Dim intHorizontalLineLength As Integer = DefaultPageSettings.PaperSize.Width - 200

        Dim strSplitter() As String = Split(strColumnWidths, "|")
        For intIterate = 0 To intNumberOfColumns - 1
            If IsNumeric(strSplitter(intIterate)) Then
                W(intIterate) = CInt(strSplitter(intIterate))
            Else
                W(intIterate) = 0
            End If
        Next

        myBrush = New SolidBrush(DetailColor)

        Dim strDType As String
        strDType = UCase(strMainCaption)
        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer

        x1 = e.PageBounds.Left + 100
        y1 = e.PageBounds.Top + 100
        p1 = e.PageBounds.Width - 200
        y2 = e.PageBounds.Height - 200

        'Initialise the key data values
        X(0) = e.PageBounds.Left + 100
        Y = e.PageBounds.Top + 100

        'Set the column print start positions. The First one will always start from the page left bounds
        'Hence we will only set the values from second column onwards. X(0) set on line 236
        For intIterate = 1 To intNumberOfColumns - 1
            If Not IsNumeric(strSplitter(intIterate)) Then strSplitter(intIterate) = "0"
            X(intIterate) = CInt(strSplitter(intIterate - 1)) + X(intIterate - 1)
        Next

        Dim pencurrent As New Pen(GridColor, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        Dim strS As String = Nothing
        Dim Yc As Double
        Dim cols, lines As Double
        Dim GridPen As New Pen(GridColor, 1)
        Dim g As Graphics = e.Graphics

        Dim intLogoNextXPosition As Integer = intLogoXposition

        If UCase(strMainCaption) <> "GOODS RECEIVED NOTE" Then

            If Not String.IsNullOrEmpty(strLogoPath) Then
                If System.IO.File.Exists(strLogoPath) Then
                    'Dont print the company name as it is taken care of by the logo
                    'strCompanyName = ""
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

            'Draw the image watermark
            If Not String.IsNullOrEmpty(strWatermarkPath) Then
                If System.IO.File.Exists(strWatermarkPath) Then
                    Dim R As Drawing.Rectangle
                    Dim objPicture As New Windows.Forms.PictureBox
                    objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                    objPicture.Load(strWatermarkPath)
                    'Dim intImageYLocation As Double = objPicture.Height
                    'intImageYLocation = y2 - intImageYLocation
                    R = New Rectangle(intWatermarkXposition, intWatermarkYposition, objPicture.Width, objPicture.Height)
                    e.Graphics.DrawImage(objPicture.Image, R)
                End If
            End If

            Dim intBrandLogoYposition As Integer = intBrandsYposition
            intLogoNextXPosition = intBrandsXposition

            'If UCase(strInvoiceDesignType) = "CUSTOM" Then
            If Not String.IsNullOrEmpty(strBrandImage1) Then
                If System.IO.File.Exists(strBrandImage1) Then
                    Dim R As Drawing.Rectangle
                    Dim objPicture As New Windows.Forms.PictureBox
                    objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                    objPicture.Load(strBrandImage1)
                    Dim intImageYLocation As Double = objPicture.Height
                    intImageYLocation = (100 - intImageYLocation) / 2
                    If UCase(strBrandsTiling) = UCase("Vertical") Then
                        R = New Rectangle(intLogoNextXPosition, intBrandLogoYposition, objPicture.Width, objPicture.Height)
                        e.Graphics.DrawImage(objPicture.Image, R)
                        intBrandLogoYposition = R.Y + R.Height + 3
                    Else
                        R = New Rectangle(intLogoNextXPosition, intBrandLogoYposition, objPicture.Width, objPicture.Height)
                        e.Graphics.DrawImage(objPicture.Image, R)
                        intLogoNextXPosition = R.X + R.Width + 3
                    End If
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
                    If UCase(strBrandsTiling) = UCase("Vertical") Then
                        R = New Rectangle(intLogoNextXPosition, intBrandLogoYposition, objPicture.Width, objPicture.Height)
                        e.Graphics.DrawImage(objPicture.Image, R)
                        intBrandLogoYposition = R.Y + R.Height + 3
                    Else
                        R = New Rectangle(intLogoNextXPosition, intBrandLogoYposition, objPicture.Width, objPicture.Height)
                        e.Graphics.DrawImage(objPicture.Image, R)
                        intLogoNextXPosition = R.X + R.Width + 3
                    End If
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
                    If UCase(strBrandsTiling) = UCase("Vertical") Then
                        R = New Rectangle(intLogoNextXPosition, intBrandLogoYposition, objPicture.Width, objPicture.Height)
                        e.Graphics.DrawImage(objPicture.Image, R)
                        intBrandLogoYposition = R.Y + R.Height + 3
                    Else
                        R = New Rectangle(intLogoNextXPosition, intBrandLogoYposition, objPicture.Width, objPicture.Height)
                        e.Graphics.DrawImage(objPicture.Image, R)
                        intLogoNextXPosition = R.X + R.Width + 3
                    End If
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
                    If UCase(strBrandsTiling) = UCase("Vertical") Then
                        R = New Rectangle(intLogoNextXPosition, intBrandLogoYposition, objPicture.Width, objPicture.Height)
                        e.Graphics.DrawImage(objPicture.Image, R)
                        intBrandLogoYposition = R.Y + R.Height + 3
                    Else
                        R = New Rectangle(intLogoNextXPosition, intBrandLogoYposition, objPicture.Width, objPicture.Height)
                        e.Graphics.DrawImage(objPicture.Image, R)
                        intLogoNextXPosition = R.X + R.Width + 3
                    End If
                End If
            End If
            'End If

        End If

        'Draw the document rectangle
        reccurrent = New Rectangle(x1, y1, p1, y2)
        e.Graphics.DrawRectangle(GridPen, reccurrent)

        'Write the document header and then draw a line after
        g.DrawString(UCase(strMainHeader), New Font("Arial", 16, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, Color.Black)), 250, e.PageBounds.Top + 110)
        y1 = y1 + 40
        e.Graphics.DrawLine(GridPen, x1, y1, p1 + 100, y1)

        y1 = y1 + 15

        Dim yDropDownLine_Top As Integer
        Dim y1_before_headers As Integer

        If UCase(strMainCaption) <> "GOODS RECEIVED NOTE" Then

            'Print the company details at the extreme left of document
            Call DrawStringInBoxLeft(e, 110, y1, 500, 80, strCompanyName, myBrush, HeaderFont)
            y1 = y1 + 20

            If Not String.IsNullOrEmpty(strCompanyAddress1) Then
                Call DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress1, myBrush, fntDetailsFont)
                'Print the company number
                If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                    If UCase(strCompanyCountry) = "SOUTH AFRICA" Then
                        Call DrawStringInBoxLeft(e, 400, y1, 250, 80, "CK NO.  : " & UCase(strCompanyRegistrationNumber), myBrush, fntDetailsFont)
                    Else
                        Call DrawStringInBoxLeft(e, 400, y1, 250, 80, "COY NO.  : " & UCase(strCompanyRegistrationNumber), myBrush, fntDetailsFont)
                    End If
                End If
                y1 = y1 + 15
            Else
                'Print the company number
                If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                    If UCase(strCompanyCountry) = "SOUTH AFRICA" Then
                        Call DrawStringInBoxLeft(e, 400, y1, 250, 80, "CK NO.  : " & UCase(strCompanyRegistrationNumber), myBrush, fntDetailsFont)
                    Else
                        Call DrawStringInBoxLeft(e, 400, y1, 250, 80, "COY NO.  : " & UCase(strCompanyRegistrationNumber), myBrush, fntDetailsFont)
                    End If
                    y1 = y1 + 15
                End If
            End If

            If Not String.IsNullOrEmpty(strCompanyAddress2) Then
                Call DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress2, myBrush, fntDetailsFont)
                'Print the vat number
                If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                    Call DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO. : " & UCase(strCompanyVatNumber), myBrush, fntDetailsFont)
                    Call DrawStringInBoxLeft(e, 550, y1, 250, 80, "BP NO.  : " & UCase(strCompanyBPNumber), myBrush, fntDetailsFont)
                End If
                y1 = y1 + 15
            Else
                'Print the vat number
                If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                    Call DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO. : " & UCase(strCompanyVatNumber), myBrush, fntDetailsFont)
                    Call DrawStringInBoxLeft(e, 550, y1, 250, 80, "BP NO.  : " & UCase(strCompanyBPNumber), myBrush, fntDetailsFont)
                End If
                y1 = y1 + 15
            End If

            If Not String.IsNullOrEmpty(strCompanyAddress3) Then
                Call DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress3, myBrush, fntDetailsFont)
                y1 = y1 + 15
            End If
            If Not String.IsNullOrEmpty(strCompanyAddress4) Then
                Call DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress4, myBrush, fntDetailsFont)
                y1 = y1 + 15
            End If
            If Not String.IsNullOrEmpty(strCompanyTelephone) Then
                Call DrawStringInBoxLeft(e, 110, y1, 250, 80, "PHONE  : " & UCase(strCompanyTelephone), myBrush, fntDetailsFont)
                y1 = y1 + 15
            End If
            'strCompanyContactCellNumber
            If Not String.IsNullOrEmpty(strCompanyContactCellNumber) Then
                Call DrawStringInBoxLeft(e, 110, y1, 550, 80, "CELL NO: " & UCase(strCompanyContactCellNumber), myBrush, fntDetailsFont)
                y1 = y1 + 15
            End If
            If Not String.IsNullOrEmpty(strCompanyFaxNumber) Then
                Call DrawStringInBoxLeft(e, 110, y1, 250, 80, "FAX NO.: " & UCase(strCompanyFaxNumber), myBrush, fntDetailsFont)
                y1 = y1 + 15
            End If
            If Not String.IsNullOrEmpty(strCompanyEmailAddress) Then
                Call DrawStringInBoxLeft(e, 110, y1, 250, 80, "E-MAIL : " & strCompanyEmailAddress, myBrush, fntDetailsFont)
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

            e.Graphics.DrawLine(GridPen, x1 - 10, y1, p1 + 100, y1)
            y1 = y1 + 20
            e.Graphics.DrawString("CUSTOMER DETAILS", fntDetailsFontBold, myBrush, x1, y1)
            e.Graphics.DrawString("TRANSACTION DETAILS", fntDetailsFontBold, myBrush, 500, y1)
            y1 = y1 + 20
            e.Graphics.DrawLine(GridPen, x1 - 10, y1, p1 + 100, y1)
            y1 = y1 + 15

            'Draw border around vat number
            yDropDownLine_Top = y1
            e.Graphics.DrawLine(GridPen, x1 - 10, y1, X4 + 20, y1)
            y1 = y1 + 3
            If UCase(strMainCaption) = "STUDENT STATEMENT" Then
                e.Graphics.DrawString("DATE IN", fntDetailsFontBold, myBrush, x1, y1)
            Else
                e.Graphics.DrawString("VAT NUM.", fntDetailsFontBold, myBrush, x1, y1) '& Space(20) & " VAT No.: " & UCase(CustomerVatNumber)
            End If
            e.Graphics.DrawString(CustomerVatNumber, fntDetailsFontBold, myBrush, x1 + 80, y1) 'CustomerVatNumber
            If UCase(strMainCaption) = "STUDENT STATEMENT" Then
                e.Graphics.DrawString("STD # ", fntDetailsFontBold, myBrush, x1 + 180, y1)
                e.Graphics.DrawString(UCase(strSelectedAccount), fntDetailsFontBold, myBrush, x1 + 230, y1)
            Else
                e.Graphics.DrawString("BP NUM. ", fntDetailsFontBold, myBrush, x1 + 180, y1) '& Space(20) & " VAT No.: " & UCase(CustomerVatNumber)
                e.Graphics.DrawString(CustomerBPNumber, fntDetailsFontBold, myBrush, x1 + 230, y1) 'CustomerVatNumber
            End If

            y1 = y1 + 12
            e.Graphics.DrawLine(GridPen, x1 - 10, y1, X4 + 20, y1)
            e.Graphics.DrawLine(GridPen, x1 + 75, yDropDownLine_Top, x1 + 75, y1)
            y1 = y1 + 3

            If Not String.IsNullOrEmpty(CustomerName) Then
                If CustomerName.Length > 58 Then CustomerName = Mid(CustomerName, 1, 58)
            End If
            e.Graphics.DrawString(UCase(CustomerName), fntDetailsFont, myBrush, x1, y1)

        End If

        'Print the date
        If UCase(strMainCaption) = "CUSTOMER STATEMENT" Then
            e.Graphics.DrawString("PERIOD", fntDetailsFontBold, myBrush, 500, y1)
            e.Graphics.DrawString(": " & UCase(Format(StartDate, "dd-MMM-yyyy") & " TO " & Format(EndDate, "dd-MMM-yyyy")), fntDetailsFont, myBrush, 580, y1)
        Else
            e.Graphics.DrawString("DATE", fntDetailsFontBold, myBrush, 500, y1)
            e.Graphics.DrawString(": " & PrintDate, fntDetailsFont, myBrush, 580, y1)
        End If
        y1 += 15

        If UCase(strMainCaption) = "AUCTION STATEMENT" Then
            Call DrawStringInBoxLeft(e, 500, y1, 300, 80, "CARD NO.", myBrush, fntDetailsFontBold)
        Else
            Call DrawStringInBoxLeft(e, 500, y1, 300, 80, "DOC. NO.", myBrush, fntDetailsFontBold)
        End If
        Call DrawStringInBoxLeft(e, 580, y1, 300, 80, ": " & UCase(strDocumentPrefix) & Format(ReferenceNumber, "000000"), myBrush, fntDetailsFont)
        If UCase(strMainCaption) <> "GOODS RECEIVED NOTE" Then
            Call DrawStringInBoxLeft(e, 110, y1, 200, 80, CustomerAddress1, myBrush, fntDetailsFont)
        End If
        y1 += 15
        If UCase(strMainCaption) <> "GOODS RECEIVED NOTE" Then
            Call DrawStringInBoxLeft(e, 110, y1, 200, 80, CustomerAddress2, myBrush, fntDetailsFont)
        End If
        If UCase(strMainCaption) <> "CUSTOMER STATEMENT" Then
            If UCase(strMainCaption) <> "AUCTION STATEMENT" Then
                If UCase(strMainCaption) <> "STUDENT STATEMENT" Then
                    Call DrawStringInBoxLeft(e, 500, y1, 300, 80, "ORDER NO.", myBrush, fntDetailsFontBold)
                    Call DrawStringInBoxLeft(e, 580, y1, 300, 80, ": " & UCase(strPublicInvoiceOrderNumber), myBrush, fntDetailsFont)
                End If
            End If
        End If
        y1 += 15
        If UCase(strMainCaption) <> "GOODS RECEIVED NOTE" Then
            Call DrawStringInBoxLeft(e, 110, y1, 200, 80, CustomerAddress3, myBrush, fntDetailsFont)
        End If

        If UCase(strMainCaption) <> "AUCTION STATEMENT" Then
            If UCase(strMainCaption) <> "STUDENT STATEMENT" Then
                Call DrawStringInBoxLeft(e, 500, y1, 300, 80, "REFER TO", myBrush, fntDetailsFontBold)
            End If
        End If

        If UCase(strMainCaption) <> "GOODS RECEIVED NOTE" Then
            If UCase(strMainCaption) <> "AUCTION STATEMENT" Then
                Call DrawStringInBoxLeft(e, 580, y1, 300, 80, ": " & UCase(SalesRep), myBrush, fntDetailsFont)
            End If
        Else
            Call DrawStringInBoxLeft(e, 580, y1, 300, 80, ": " & UCase(strCurrentUserFullNames), myBrush, fntDetailsFont)
        End If
        y1 += 15

        If UCase(strMainCaption) <> "GOODS RECEIVED NOTE" Then
            Call DrawStringInBoxLeft(e, 110, y1, 200, 80, CustomerAddress4, myBrush, fntDetailsFont)
            y1 += 18
            e.Graphics.DrawLine(GridPen, x1 - 10, y1, X4 + 20, y1)
            Dim yDropDownLine_Bottom As Integer = y1

            'Draw the tax and address dropdown line
            e.Graphics.DrawLine(GridPen, X4 + 20, yDropDownLine_Top, X4 + 20, yDropDownLine_Bottom)

            'Continue and print the rest
            y1 += 15
            e.Graphics.DrawString("TELEPHONE : " & CustomerTelephone, fntDetailsFont, myBrush, x1, y1)
            y1 += 15
            e.Graphics.DrawString("E-MAIL    :" & CustomerEmailAddress, fntDetailsFont, myBrush, x1, y1)
            y1 = y1 + 20

        End If

        e.Graphics.DrawLine(GridPen, x1 - 10, y1, p1 + 100, y1)
        y1_before_headers = y1
        y1 = y1 + 12

        'Begin print of page titles
        strSplitter = Split(strColumnHeaders, "|")
        myBrush = New SolidBrush(clrDetailColor)
        For intIterate = 0 To strSplitter.Length - 1
            Call DrawStringInBoxLeft(e, (X(intIterate) + 2), y1, W(intIterate), 80, strSplitter(intIterate), myBrush, fntDetailsFontBold)
            'e.Graphics.DrawString(strSplitter(intIterate), fntTitleFont, myBrush, X(intIterate), Y)
        Next

        'Always draw a line after the column titles. Check first the headers that they do not exceed column width 
        zp = 0 : xz = 0 : yp = 0 : intLongest = 0
        For zp = 0 To strSplitter.Length - 1
            xz = strSplitter(zp).Length
            If xz > yp Then
                yp = xz
                intLongest = zp
            End If
        Next
        e.Graphics.MeasureString(strSplitter(intLongest), fntDetailsFont, New SizeF(W(intLongest), 80), New StringFormat(), cols, lines)
        Yc = y1
        y1 = y1 + lines * (fntDetailsFont.Height + 1)
        y1 = Math.Max(y1, Yc)

        'Inserted the following code to draw the header line
        y1 = y1 + 2
        With Me.DefaultPageSettings
            myPen = New System.Drawing.Pen(clrGridColor)
            e.Graphics.DrawLine(myPen, .Margins.Left, y1, intHorizontalLineLength + 100, y1)
        End With
        y1 = y1 + 5

        '---------------------------------


        'itm = 0
        reccurrent = New Rectangle()
        boolPrintingNextPage = False

        Dim strBuffer() As String
        Dim i As Integer = 0
        Dim intLineNumber As Integer = 1

        While itm < strPrintValues.Length

            strBuffer = Split(strPrintValues(itm), "|")

            'Print details routine 
            Dim str As String = Nothing
            Dim strSplitterFormating() As String = Split(strColumnFormating, "|")
            Dim strSplitterAlignment() As String = Split(strColumnAlignments, "|")
            For intIterate = 0 To intNumberOfColumns - 1
                If Not String.IsNullOrEmpty(strBuffer(intIterate)) Then
                    If IsNumeric(strBuffer(intIterate)) And UCase(strSplitterFormating(intIterate)) = "YES" Then
                        str = CStr(Format(CDbl(strBuffer(intIterate)), "#,##0.00"))
                    Else
                        If IsDate(strBuffer(intIterate)) Then
                            If UCase(strSplitterFormating(intIterate)) = "YES" Then str = Format(CDate(strBuffer(intIterate)), "dd-MM-yyyy") Else str = strBuffer(intIterate)
                        Else
                            str = strBuffer(intIterate)
                        End If
                    End If
                Else
                    str = Nothing
                End If

                Select Case strSplitterAlignment(intIterate)
                    Case Is = "0"
                        Call DrawStringInBoxLeft(e, (X(intIterate) + 2), y1, W(intIterate), 80, str, myBrush, fntDetailsFont)
                    Case Is = "1"
                        Call DrawStringInBoxCenter(e, (X(intIterate) - 5), y1, W(intIterate), 80, str, myBrush, fntDetailsFont)
                    Case Is = "2"
                        Call DrawStringInBoxRight(e, (X(intIterate) - 5), y1, W(intIterate), 80, str, myBrush, fntDetailsFont)
                End Select
            Next

            zp = 0 : xz = 0 : yp = 0 : intLongest = 0
            For zp = 0 To strBuffer.Length - 1
                xz = strBuffer(zp).Length
                If xz > yp Then
                    yp = xz
                    intLongest = zp
                End If
            Next
            e.Graphics.MeasureString(strBuffer(intLongest), fntDetailsFont, New SizeF(W(intLongest), 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * (fntDetailsFont.Height + 1)
            y1 = Math.Max(y1, Yc) + 2

            itm = itm + 1 : i = 0
            intLineNumber = intLineNumber + 1

            If intLineNumber = intLinesMaximum Then
                'Print the page number of the statement

                Call DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & pageNum + 1, myBrush, fntDetailsFont)

                ''print the compny bank details
                'If PrintBankingDetails = True Then
                '    Call DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 80, 600, 80, "OUR BANK DETAILS : " & UCase(strCompanyBankName) & " - ACCOUNT NO : " & UCase(strCompanyAccountNumber) & " BANK CODE : " & UCase(strCompanyBranchCode), myBrush, fntDetailsFont)
                '    Call DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", myBrush, fntFooterFontItalic)
                'End If

                e.HasMorePages = True
                boolPrintingNextPage = True
                pageNum += 1
                Exit While
            End If

        End While

        y1 = y1 + 15
        'Draw the drop down lines.
        Dim y1_LastRow As Integer = y1
        Dim xDistance As Integer = x1 - 10
        For P As Integer = 0 To intNumberOfColumns - 2 'We less 2 because we will always have the last border line drawn
            xDistance = xDistance + W(P)
            e.Graphics.DrawLine(GridPen, xDistance, y1_before_headers, xDistance, y1_LastRow)
        Next

        'Draw the line immediately under to close transactions
        With Me.DefaultPageSettings
            myPen = New System.Drawing.Pen(clrGridColor)
            e.Graphics.DrawLine(myPen, .Margins.Left, y1, intHorizontalLineLength + 100, y1)
        End With

        Dim intY_NotesStart As Integer = 0

        'Adjust for unnecessary over prints on totals
        Dim boolNextpageTotalsOnly As Boolean = False
        If (y2 - y1) < 120 Then
            e.HasMorePages = True
            boolNextpageTotalsOnly = True
            pageNum += 1
            Exit Sub
        End If

        'print totals
        If boolPrintingNextPage = False Then
            If PrintSummaryTotals = True Then

                If boolNextpageTotalsOnly = True Then y1 = 530

                y1 = y1 + 30
                'e.Graphics.DrawLine(GridPen, x1 - 10, y1, p1 + 100, y1)
                Dim y1_after_headers As Integer = y1
                intY_NotesStart = y1

                y1 = y1 + 30
                Dim y1_before As Integer = y1

                Dim strCaptions() As String = Split(strSummaryCaptions, "|")
                Dim strCapValues() As String = Split(strSummaryValues, "|")
                Dim strCapAligns() As String = Split(strSummaryAlignments, "|")

                e.Graphics.DrawLine(GridPen, e.PageBounds.Right - 300, y1, e.PageBounds.Right - 100, y1)

                For z As Integer = 0 To strCaptions.Length - 1
                    Call DrawStringInBoxLeft(e, e.PageBounds.Right - 295, y1 + 3, 120, 80, UCase(strCaptions(z)), myBrush, fntDetailsFontBold)
                    Select Case CInt(strCapAligns(z))
                        Case Is = 0
                            Call DrawStringInBoxLeft(e, e.PageBounds.Right - 200, (y1 + 3), 105, 80, strCapValues(z), myBrush, fntDetailsFontBold)
                        Case Is = 1
                            Call DrawStringInBoxCenter(e, e.PageBounds.Right - 200, (y1 + 3), 105, 80, strCapValues(z), myBrush, fntDetailsFontBold)
                        Case Is = 2
                            Call DrawStringInBoxRight(e, e.PageBounds.Right - 200, (y1 + 3), 105, 80, strCapValues(z), myBrush, fntDetailsFontBold)
                    End Select
                    y1 = y1 + 20
                    e.Graphics.DrawLine(GridPen, e.PageBounds.Right - 300, y1, e.PageBounds.Right - 100, y1)
                Next

                Dim y1_after As Integer = y1
                e.Graphics.DrawLine(GridPen, e.PageBounds.Right - 300, y1_before, e.PageBounds.Right - 300, y1_after)
                e.Graphics.DrawLine(GridPen, e.PageBounds.Right - 200, y1_before, e.PageBounds.Right - 200, y1_after)
                y1 = y1 + 15
                'intY_NotesStart = y1_before
            End If

            'Print notes
            If Not String.IsNullOrEmpty(DocumentNotes) Then
                'y1 = y1 + 30
                reccurrent = New Rectangle(x1 + 5, intY_NotesStart, 300, 100)
                e.Graphics.DrawRectangle(GridPen, reccurrent)
                Call DrawStringInBoxLeft(e, (x1 + 5), intY_NotesStart + 3, 480, 80, "TERMS AND CONDITIONS", myBrush, fntDetailsFont)
                intY_NotesStart = intY_NotesStart + 15
                Call DrawStringInBoxLeft(e, (x1 + 5), intY_NotesStart, 280, 145, DocumentNotes, myBrush, fntDetailsFont)
            End If

            'Print the receiver information
            Call DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 150, 220, 80, "ACCEPTED BY ....................................... ", myBrush, fntDetailsFont)
            Call DrawStringInBoxLeft(e, x1 + 210, e.PageBounds.Bottom - 150, 200, 80, "SIGNATURE ..................................... ", myBrush, fntDetailsFont)
            Call DrawStringInBoxLeft(e, x1 + 420, e.PageBounds.Bottom - 150, 200, 80, "DATE ...................................... ", myBrush, fntDetailsFont)

            If PrintBankingDetails = True Then
                Call DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 135, 600, 80, "OUR BANK DETAILS : " & UCase(strCompanyBankName) & " BANK CODE : " & UCase(strCompanyBranchCode), myBrush, fntDetailsFont)
                Call DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 120, 600, 80, "           ACCOUNT NO : " & UCase(strCompanyAccountNumber), myBrush, fntDetailsFont)
            End If

            pageNum = pageNum + 1
            Call DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & pageNum, myBrush, fntHeaderFont)
            'Call DrawStringInBoxLeft(e, x1 + 200, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", myBrush, fntFooterFontItalic)

            e.HasMorePages = False
            'Me.boolPrintFromPreview = True

        End If

    End Sub

    Private Sub DrawStringInBoxRight(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
                ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal sBrush As System.Drawing.Brush, ByVal sFnt As System.Drawing.Font)
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF(x1, y1, (x2 - 5), y2)
        sfCurrent.Alignment = Drawing.StringAlignment.Far
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Private Sub DrawStringInBoxLeft(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
        ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal sBrush As System.Drawing.Brush, ByVal sFnt As System.Drawing.Font)
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF(x1, y1, x2, y2)
        sfCurrent.Alignment = Drawing.StringAlignment.Near
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Private Sub DrawStringInBoxCenter(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
        ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal sBrush As System.Drawing.Brush, ByVal sFnt As System.Drawing.Font)
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF(x1, y1, x2, y2)
        sfCurrent.Alignment = Drawing.StringAlignment.Center
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Private Function GetDefinedColor(ByVal strColorName As String) As Color
        Dim ret As System.Drawing.Color = Color.Black
        Select Case strColorName
            Case Is = "AliceBlue"
                ret = Color.AliceBlue
            Case Is = "AntiqueWhite"
                ret = Color.AntiqueWhite
            Case Is = "Aqua"
                ret = Color.Aqua
            Case Is = "Aquamarine"
                ret = Color.Aquamarine
            Case Is = "Azure"
                ret = Color.Azure
            Case Is = "Beige"
                ret = Color.Beige
            Case Is = "Bisque"
                ret = Color.Bisque
            Case Is = "Black"
                ret = Color.Black
            Case Is = "BlanchedAlmond"
                ret = Color.BlanchedAlmond
            Case Is = "Blue"
                ret = Color.Blue
            Case Is = "BlueViolet"
                ret = Color.BlueViolet
            Case Is = "Brown"
                ret = Color.Brown
            Case Is = "BurlyWood"
                ret = Color.BurlyWood
            Case Is = "CadetBlue"
                ret = Color.CadetBlue
            Case Is = "Chartreuse"
                ret = Color.Chartreuse
            Case Is = "Chocolate"
                ret = Color.Chocolate
            Case Is = "Coral"
                ret = Color.Coral
            Case Is = "CornflowerBlue"
                ret = Color.CornflowerBlue
            Case Is = "Cornsilk"
                ret = Color.Cornsilk
            Case Is = "Crimson"
                ret = Color.Crimson
            Case Is = "Cyan"
                ret = Color.Cyan
            Case Is = "DarkBlue"
                ret = Color.DarkBlue
            Case Is = "DarkCyan"
                ret = Color.DarkCyan
            Case Is = "DarkGoldenrod"
                ret = Color.DarkGoldenrod
            Case Is = "DarkGray"
                ret = Color.DarkGray
            Case Is = "DarkGreen"
                ret = Color.DarkGreen
            Case Is = "DarkKhaki"
                ret = Color.DarkKhaki
            Case Is = "DarkMagenta"
                ret = Color.DarkMagenta
            Case Is = "DarkOliveGreen"
                ret = Color.DarkOliveGreen
            Case Is = "DarkOrange"
                ret = Color.DarkOrange
            Case Is = "DarkOrchid"
                ret = Color.DarkOrchid
            Case Is = "DarkRed"
                ret = Color.DarkRed
            Case Is = "DarkSalmon"
                ret = Color.DarkSalmon
            Case Is = "DarkSeaGreen"
                ret = Color.DarkSeaGreen
            Case Is = "DarkSlateBlue"
                ret = Color.DarkSlateBlue
            Case Is = "DarkSlateGray"
                ret = Color.DarkSlateGray
            Case Is = "DarkTurquoise"
                ret = Color.DarkTurquoise
            Case Is = "DarkViolet"
                ret = Color.DarkViolet
            Case Is = "DeepPink"
                ret = Color.DeepPink
            Case Is = "DeepSkyBlue"
                ret = Color.DeepSkyBlue
            Case Is = "DimGray"
                ret = Color.DimGray
            Case Is = "DodgerBlue"
                ret = Color.DodgerBlue
            Case Is = "Firebrick"
                ret = Color.Firebrick
            Case Is = "FloralWhite"
                ret = Color.FloralWhite
            Case Is = "ForestGreen"
                ret = Color.ForestGreen
            Case Is = "Fuchsia"
                ret = Color.Fuchsia
            Case Is = "Gainsboro"
                ret = Color.Gainsboro
            Case Is = "GhostWhite"
                ret = Color.GhostWhite
            Case Is = "Gold"
                ret = Color.Gold
            Case Is = "Goldenrod"
                ret = Color.Goldenrod
            Case Is = "Gray"
                ret = Color.Gray
            Case Is = "Green"
                ret = Color.Green
            Case Is = "GreenYellow"
                ret = Color.GreenYellow
            Case Is = "Honeydew"
                ret = Color.Honeydew
            Case Is = "HotPink"
                ret = Color.HotPink
            Case Is = "IndianRed"
                ret = Color.IndianRed
            Case Is = "Indigo"
                ret = Color.Indigo
            Case Is = "Ivory"
                ret = Color.Ivory
            Case Is = "Khaki"
                ret = Color.Khaki
            Case Is = "Lavender"
                ret = Color.Lavender
            Case Is = "LavenderBlush"
                ret = Color.LavenderBlush
            Case Is = "LawnGreen"
                ret = Color.LawnGreen
            Case Is = "LemonChiffon"
                ret = Color.LemonChiffon
            Case Is = "LightBlue"
                ret = Color.LightBlue
            Case Is = "LightCoral"
                ret = Color.LightCoral
            Case Is = "LightCyan"
                ret = Color.LightCyan
            Case Is = "LightGoldenrodYellow"
                ret = Color.LightGoldenrodYellow
            Case Is = "LightGray"
                ret = Color.LightGray
            Case Is = "LightGreen"
                ret = Color.LightGreen
            Case Is = "LightPink"
                ret = Color.LightPink
            Case Is = "LightSalmon"
                ret = Color.LightSalmon
            Case Is = "LightSeaGreen"
                ret = Color.LightSeaGreen
            Case Is = "LightSkyBlue"
                ret = Color.LightSkyBlue
            Case Is = "LightSlateGray"
                ret = Color.LightSlateGray
            Case Is = "LightSteelBlue"
                ret = Color.LightSteelBlue
            Case Is = "LightYellow"
                ret = Color.LightYellow
            Case Is = "Lime"
                ret = Color.Lime
            Case Is = "LimeGreen"
                ret = Color.LimeGreen
            Case Is = "Linen"
                ret = Color.Linen
            Case Is = "Magenta"
                ret = Color.Magenta
            Case Is = "Maroon"
                ret = Color.Maroon
            Case Is = "MediumAquamarine"
                ret = Color.MediumAquamarine
            Case Is = "MediumBlue"
                ret = Color.MediumBlue
            Case Is = "MediumOrchid"
                ret = Color.MediumOrchid
            Case Is = "MediumPurple"
                ret = Color.MediumPurple
            Case Is = "MediumSeaGreen"
                ret = Color.MediumSeaGreen
            Case Is = "MediumSlateBlue"
                ret = Color.MediumSlateBlue
            Case Is = "MediumSpringGreen"
                ret = Color.MediumSpringGreen
            Case Is = "MediumTurquoise"
                ret = Color.MediumTurquoise
            Case Is = "MediumVioletRed"
                ret = Color.MediumVioletRed
            Case Is = "MidnightBlue"
                ret = Color.MidnightBlue
            Case Is = "MintCream"
                ret = Color.MintCream
            Case Is = "MistyRose"
                ret = Color.MistyRose
            Case Is = "Moccasin"
                ret = Color.Moccasin
            Case Is = "NavajoWhite"
                ret = Color.NavajoWhite
            Case Is = "Navy"
                ret = Color.Navy
            Case Is = "OldLace"
                ret = Color.OldLace
            Case Is = "Olive"
                ret = Color.Olive
            Case Is = "OliveDrab"
                ret = Color.OliveDrab
            Case Is = "Orange"
                ret = Color.Orange
            Case Is = "OrangeRed"
                ret = Color.OrangeRed
            Case Is = "Orchid"
                ret = Color.Orchid
            Case Is = "PaleGoldenrod"
                ret = Color.PaleGoldenrod
            Case Is = "PaleGreen"
                ret = Color.PaleGreen
            Case Is = "PaleTurquoise"
                ret = Color.PaleTurquoise
            Case Is = "PaleVioletRed"
                ret = Color.PaleVioletRed
            Case Is = "PapayaWhip"
                ret = Color.PapayaWhip
            Case Is = "PeachPuff"
                ret = Color.PeachPuff
            Case Is = "Peru"
                ret = Color.Peru
            Case Is = "Pink"
                ret = Color.Pink
            Case Is = "Plum"
                ret = Color.Plum
            Case Is = "PowderBlue"
                ret = Color.PowderBlue
            Case Is = "Purple"
                ret = Color.Purple
            Case Is = "Red"
                ret = Color.Red
            Case Is = "RosyBrown"
                ret = Color.RosyBrown
            Case Is = "RoyalBlue"
                ret = Color.RoyalBlue
            Case Is = "SaddleBrown"
                ret = Color.SaddleBrown
            Case Is = "Salmon"
                ret = Color.Salmon
            Case Is = "SandyBrown"
                ret = Color.SandyBrown
            Case Is = "SeaGreen"
                ret = Color.SeaGreen
            Case Is = "SeaShell"
                ret = Color.SeaShell
            Case Is = "Sienna"
                ret = Color.Sienna
            Case Is = "Silver"
                ret = Color.Silver
            Case Is = "SkyBlue"
                ret = Color.SkyBlue
            Case Is = "SlateBlue"
                ret = Color.SlateBlue
            Case Is = "SlateGray"
                ret = Color.SlateGray
            Case Is = "Snow"
                ret = Color.Snow
            Case Is = "SpringGreen"
                ret = Color.SpringGreen
            Case Is = "SteelBlue"
                ret = Color.SteelBlue
            Case Is = "Tan"
                ret = Color.Tan
            Case Is = "Teal"
                ret = Color.Teal
            Case Is = "Thistle"
                ret = Color.Thistle
            Case Is = "Tomato"
                ret = Color.Tomato
            Case Is = "Turquoise"
                ret = Color.Turquoise
            Case Is = "Violet"
                ret = Color.Violet
            Case Is = "Wheat"
                ret = Color.Wheat
            Case Is = "White"
                ret = Color.White
            Case Is = "WhiteSmoke"
                ret = Color.WhiteSmoke
            Case Is = "Yellow"
                ret = Color.Yellow
            Case Is = "YellowGreen"
                ret = Color.YellowGreen
        End Select
        Return ret
    End Function

End Class
