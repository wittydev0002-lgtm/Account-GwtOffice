Imports System.Drawing
Imports System.Windows.Forms

Public Class DocumentPrint

    Inherits Drawing.Printing.PrintDocument


    '
    '** Public Variables
    '
    Public CompanyName As String

    Public CompanyAddress1 As String
    Public CompanyAddress2 As String
    Public CompanyAddress3 As String
    Public CompanyAddress4 As String
    Public CompanyTelephone As String
    Public CompanyEmail As String
    Public CompanyVatNumber As String
    Public CompanyBpNumber As String
    Public CompanyRegistrationNumber As String
    Public CompanyRegCaption As String

    '
    '** Customer Variables
    '

    Public MainCustomerName As String
    Public MainCustomerVat As String
    Public MainCustomerAddress1 As String
    Public MainCustomerAddress2 As String
    Public MainCustomerAddress3 As String
    Public MainCustomerAddress4 As String
    Public MainCustomerTelephone As String
    Public MainCustomerEmailAddress As String

    Public arrCompanyBankDetails As ArrayList

    Public FinalBalance As Double = 0

    '
    '** Document Data
    '

    Public DocValue1 As String
    Public DocValue2 As String
    Public DocValue3 As String
    Public DocValue4 As String
    Public DocValue5 As String
    Public DocValue6 As String

    Public DocValue1Caption As String
    Public DocValue2Caption As String
    Public DocValue3Caption As String
    Public DocValue4Caption As String
    Public DocValue5Caption As String
    Public DocValue6Caption As String

    Public arrDocumentInformation As ArrayList
    
    '
    '** END OF CUSTOMER DATA 
    '

    Public WatermarkPath As String
    'Public DetailFontRegular, MainTitleFont, SubTitleFont, DetailFontBold, FooterFont As System.Drawing.Font
    Public intNumberOfColumns As Integer

    Public PrintPageBorder As Boolean
    Public LogoXposition As Integer
    Public LogoYposition As Integer

    Public WatermarkXposition As Integer
    Public WatermarkYposition As Integer

    Public BrandsYposition As Integer
    Public BrandsXposition As Integer

    Public BrandImage1Path As String
    Public BrandImage2Path As String
    Public BrandImage3Path As String
    Public BrandImage4Path As String
    Public BrandsTiling As String

    
    Dim ColumnWidths() As Integer
    Dim ColumnHeaders() As String
    Dim ColumnAlignments() As Integer
    Dim X_Verticals() As Integer

    Public strColumnHeaders As String
    Public strColumnWidths As String
    Public strColumnAlignments As String

    Public SummaryCaptions As String
    Public SummaryValues As String

    Public PrintBankDetails As Boolean
    Public boolPrintCompanyNumber As Boolean

    '
    '** Local Variables 
    Dim itm As Integer
    Dim PageNum As Integer
    '

    Dim boolPrintingNextPage As Boolean
    Dim boolPrintCurrentPageHeaders As Boolean = True

    Dim dblTotal() As Double
    Dim dblSubTotal() As Double
    Dim boolAbort As Boolean
    Dim intLogoNextXPosition As Integer


    '** Page settings
    '
    Dim leftMargin As Integer
    Dim rightMargin As Integer
    Dim topMargin As Integer
    Dim bottomMargin As Integer
    Dim PrintAreaWidth As Integer
    Dim PrintAreaHeight As Integer
    Dim intTextHeight As Integer
    Dim intTextWidth As Integer

    Dim boolStillPrinting As Boolean
    Dim boolSummaryIntoNextPage As Boolean

    '** Brushes and pen
    '
    Dim myPen As System.Drawing.Pen
    Dim myBrush As System.Drawing.Brush

    '
    '** Other variables
    '
    Dim runningYposition As Integer
    Dim boolPrintHeaders As Boolean

    Dim Y1_Vertical_Cordinates As Integer
    Dim Y2_Vertical_Cordinates As Integer

    Public DrawVerticals As Boolean

    '*********************************************** PROPERTIES *****************************************

    Private boolDrawBorder As Boolean
    Private boolPrintSummary As Boolean
    Private boolDrawVerticalLines As Boolean
    Private boolDrawHorizontalLines As Boolean
    Private strLogoPath As String
    Private clrGridColor As System.Drawing.Color
    Private fntTitleFont As System.Drawing.Font
    Private fntFooterFont As System.Drawing.Font

    Private DetailFontRegular, DetailFontBold, MainTitleFont, SubTitleFont As System.Drawing.Font
    Private clrAlternateBackColor As System.Drawing.Color
    Private clrFooterColor As System.Drawing.Color
    Private clrTitleColor As System.Drawing.Color
    Private clrBorderColor As System.Drawing.Color

    Private clrDetailColor As System.Drawing.Color
    Public PrintData() As String
    Private intArrayCount As Integer

    Private intSortKeyIndex As Integer
    Private strFooter As String
    Private boolGroup As Boolean
    Private intGroupFieldIndex As Integer

    Private strDocumentHeader As String

    Private X_DocumentInfo As Integer
    Private Y_DocumentInfo As Integer

    Private strRightHeader As String
    Private strLeftHeader As String

    Public Property RightHeader() As String
        Get
            Return strRightHeader
        End Get
        Set(ByVal Value As String)
            strRightHeader = Value
        End Set
    End Property

    Public Property LeftHeader() As String
        Get
            Return strLeftHeader
        End Get
        Set(ByVal Value As String)
            strLeftHeader = Value
        End Set
    End Property

    Public Property DetailFont() As Drawing.Font
        Get
            Return DetailFontRegular
        End Get
        Set(ByVal Value As Drawing.Font)
            DetailFontRegular = Value
        End Set
    End Property

    Public Property FooterFont() As Drawing.Font
        Get
            Return fntFooterFont
        End Get
        Set(ByVal Value As Drawing.Font)
            fntFooterFont = Value
        End Set
    End Property

    Public Property HeaderFont() As Drawing.Font
        Get
            Return fntTitleFont
        End Get
        Set(ByVal Value As Drawing.Font)
            fntTitleFont = Value
        End Set
    End Property

    Public Property AlternateBackColor() As Drawing.Color
        Get
            Return clrAlternateBackColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrAlternateBackColor = Value
        End Set
    End Property

    Public Property GridColor() As Drawing.Color
        Get
            Return clrGridColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrGridColor = Value
        End Set
    End Property

    Public Property FooterColor() As Drawing.Color
        Get
            Return clrFooterColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrFooterColor = Value
        End Set
    End Property

    Public Property TitleColor() As Drawing.Color
        Get
            Return clrTitleColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrTitleColor = Value
        End Set
    End Property

    Public Property BorderColor() As Drawing.Color
        Get
            Return clrBorderColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrBorderColor = Value
        End Set
    End Property

    Public Property DetailColor() As Drawing.Color
        Get
            Return clrDetailColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrDetailColor = Value
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

    Public Property DocumentHeader() As String
        'Gets and set the page title
        Get
            Return strDocumentHeader
        End Get
        Set(ByVal Value As String)
            strDocumentHeader = Value
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

    Public Property LogoPath() As String
        Get
            Return strLogoPath
        End Get
        Set(ByVal Value As String)
            strLogoPath = Value
        End Set
    End Property

    Public Property VerticalLines() As Boolean
        Get
            Return boolDrawVerticalLines
        End Get
        Set(ByVal Value As Boolean)
            boolDrawVerticalLines = Value
        End Set
    End Property

    Public Property HorizontalLines() As Boolean
        Get
            Return boolDrawHorizontalLines
        End Get
        Set(ByVal Value As Boolean)
            boolDrawHorizontalLines = Value
        End Set
    End Property

    Public Property DrawBorder() As Boolean
        Get
            Return boolDrawBorder
        End Get
        Set(ByVal Value As Boolean)
            boolDrawBorder = Value
        End Set
    End Property

    Public Property PrintSummary() As Boolean
        Get
            Return boolPrintSummary
        End Get
        Set(ByVal Value As Boolean)
            boolPrintSummary = Value
        End Set
    End Property

    Private Sub DrawStringInBoxRight(ByVal ev As System.Drawing.Printing.PrintPageEventArgs,
        ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal sBrush As System.Drawing.Brush, ByVal sFnt As System.Drawing.Font)
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF(x1, y1, (x2 - 5), y2)
        sfCurrent.Alignment = Drawing.StringAlignment.Far
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Private Sub DrawStringInBoxLeft(ByVal ev As System.Drawing.Printing.PrintPageEventArgs,
        ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal sBrush As System.Drawing.Brush, ByVal sFnt As System.Drawing.Font)
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF(x1, y1, x2, y2)
        sfCurrent.Alignment = Drawing.StringAlignment.Near
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Private Sub DrawStringInBoxCenter(ByVal ev As System.Drawing.Printing.PrintPageEventArgs,
        ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal sBrush As System.Drawing.Brush, ByVal sFnt As System.Drawing.Font)
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF(x1, y1, x2 - 10, y2)
        sfCurrent.Alignment = Drawing.StringAlignment.Center
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Protected Overrides Sub OnBeginPrint(ByVal ev As Drawing.Printing.PrintEventArgs)
        ' Run base code
        MyBase.OnBeginPrint(ev)
        ' Sets the default font
        If DetailFontRegular Is Nothing Then
            DetailFontRegular = New Drawing.Font("Arial", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
        End If
        If DetailFontBold Is Nothing Then
            DetailFontBold = New Drawing.Font("Arial", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
        End If
        If MainTitleFont Is Nothing Then
            MainTitleFont = New Drawing.Font("Arial", 14, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
        End If
        If SubTitleFont Is Nothing Then
            SubTitleFont = New Drawing.Font("Arial", 12, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
        End If

        If fntFooterFont Is Nothing Then
            fntFooterFont = New Drawing.Font("Arial", 6, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
        End If

        If String.IsNullOrEmpty(BrandsTiling) Then BrandsTiling = "HORIZONTAL"
        If String.IsNullOrEmpty(BorderColor.ToString) Then BorderColor = Color.WhiteSmoke
        myBrush = Brushes.Black

        '
        '** Initialize column values
        '

        Dim strColCaptions() As String = Split(strColumnHeaders, "|")
        Dim strColWidths() As String = Split(strColumnWidths, "|")
        Dim strColAligns() As String = Split(strColumnAlignments, "|")

        ReDim ColumnHeaders(0 To (strColCaptions.Length - 1))
        ReDim ColumnWidths(0 To (strColWidths.Length - 1))
        ReDim ColumnAlignments(0 To (strColAligns.Length - 1))

        For p As Integer = 0 To intNumberOfColumns - 1
            Dim intColumnWidth As Integer = 0
            Dim intColumnAlignment As Integer = 0
            Dim strCaption As String = Nothing
            If IsNumeric(strColAligns(p)) Then intColumnAlignment = CInt(strColAligns(p))
            If IsNumeric(strColWidths(p)) Then intColumnWidth = CInt(strColWidths(p))
            If Not String.IsNullOrEmpty(strColCaptions(p)) Then strCaption = strColCaptions(p)
            ColumnHeaders(p) = strCaption
            ColumnAlignments(p) = intColumnAlignment
            ColumnWidths(p) = intColumnWidth
        Next

        '** Initialize the item counter
        '
        itm = 0
        boolStillPrinting = True
        boolPrintHeaders = True
        ' Initialize the page numbe
        PageNum = 1

        ReDim dblTotal(intNumberOfColumns - 1)
        ReDim dblSubTotal(intNumberOfColumns - 1)

        For iCnt As Integer = 0 To intNumberOfColumns - 1
            dblSubTotal(iCnt) = 0
            dblTotal(iCnt) = 0
        Next

        'get the print record array
        PageNum = 1 : boolPrintingNextPage = False

    End Sub

    Protected Overrides Sub OnPrintPage(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        MyBase.OnPrintPage(e)

        leftMargin = Convert.ToInt32(e.MarginBounds.Left)
        rightMargin = Convert.ToInt32(e.MarginBounds.Right)
        topMargin = Convert.ToInt32(e.MarginBounds.Top)
        bottomMargin = Convert.ToInt32(e.MarginBounds.Bottom)
        PrintAreaWidth = Convert.ToInt32(e.MarginBounds.Width)
        PrintAreaHeight = Convert.ToInt32(e.MarginBounds.Height)

        Dim arrX_verts As New ArrayList
        Dim intX_cum As Integer = leftMargin
        For x As Integer = 0 To ColumnWidths.Length - 2
            intX_cum = intX_cum + ColumnWidths(x)
            arrX_verts.Add(intX_cum)
        Next
        ReDim X_Verticals(0 To (arrX_verts.Count - 1))

        For x As Integer = 0 To arrX_verts.Count - 1
            X_Verticals(x) = CInt(arrX_verts.Item(x))
        Next

        If boolPrintingNextPage = False Then

            boolAbort = False
            PrintCompanyData(e) ' Draw document Head
            If boolAbort = True Then Exit Sub

            PrintClientNames(e, runningYposition) ' Print the customer details and/or alternate details as in the case of legal documents, defendant
            If boolAbort = True Then Exit Sub

            PrintDocumentInformation(e, Y_DocumentInfo, X_DocumentInfo, arrDocumentInformation)
            If boolAbort = True Then Exit Sub

            PrintDocumetData(e, runningYposition) ' Print the document transactions
            If boolAbort = True Then Exit Sub

        Else

            PrintBorder(e)
            'boolPrintingNextPage = True
            PrintDocumetData(e, runningYposition) ' Print the document transactions
            If boolAbort = True Then Exit Sub

        End If

        If boolStillPrinting = False Then
            boolSummaryIntoNextPage = False
            PrintSummaryData(e, runningYposition) ' End of document summary data
            If boolSummaryIntoNextPage = True Then Exit Sub
            If boolAbort = True Then Exit Sub

            'Print the banking details here
            runningYposition = runningYposition + 30

            If FinalBalance > 0 Then
                PrintBankingDetails(e, runningYposition)
            Else
                PrintBankingDetailsRequest(e, runningYposition)
            End If

            e.HasMorePages = False
            End If
        'e.HasMorePages = False

    End Sub

    Private Sub PrintHeaders(ByVal e As System.Drawing.Printing.PrintPageEventArgs, Optional Y As Integer = 275)
        On Error GoTo RaiseErr

        If boolPrintingNextPage = True Then
            If itm > PrintData.Length - 1 Then
                boolPrintCurrentPageHeaders = False
                Exit Sub
            End If
        End If

        If boolPrintHeaders = False Then Exit Sub

        Dim initialX As Integer = 100
        Dim x1 As Integer = 105
        For p As Integer = 0 To ColumnHeaders.Count - 1
            intTextHeight = Convert.ToInt32(DetailFontBold.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(ColumnWidths(p))
            DrawStringInBoxCenter(e, x1, Y, intTextWidth, intTextHeight, ColumnHeaders(p), myBrush, DetailFontBold)
            x1 = x1 + intTextWidth + 3
        Next
        Y = Y + intTextHeight + 5
        e.Graphics.DrawLine(myPen, initialX, Y, (PrintAreaWidth + initialX), Y)
        Y = Y + 10
        runningYposition = Y
        Exit Sub
RaiseErr:
        boolAbort = True
        System.Windows.Forms.MessageBox.Show(Err.Description & " Error Number " & Err.Number & vbCrLf & _
            "Error encountered in the Great Wits SmartDocumentWriter Headers Print", _
            "Smart Document Print Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
    End Sub

    Private Sub PrintCompanyData(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        On Error GoTo RaiseErr

        '** Print the logos and the watermark
        '
        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(LogoXposition, LogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
            End If
        End If

        'Draw the image watermark
        If Not String.IsNullOrEmpty(WatermarkPath) Then
            If System.IO.File.Exists(WatermarkPath) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(WatermarkPath)
                R = New Rectangle(WatermarkXposition, WatermarkYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
            End If
        End If

        '** Print the brand logos if any
        '

        Dim intBrandLogoYposition As Integer = BrandsYposition
        intLogoNextXPosition = BrandsXposition

        'If UCase(strInvoiceDesignType) = "CUSTOM" Then
        If Not String.IsNullOrEmpty(BrandImage1Path) Then
            If System.IO.File.Exists(BrandImage1Path) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(BrandImage1Path)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                If UCase(BrandsTiling) = UCase("Vertical") Then
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
        If Not String.IsNullOrEmpty(BrandImage2Path) Then
            If System.IO.File.Exists(BrandImage2Path) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(BrandImage2Path)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                If UCase(BrandsTiling) = UCase("Vertical") Then
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
        If Not String.IsNullOrEmpty(BrandImage3Path) Then
            If System.IO.File.Exists(BrandImage3Path) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(BrandImage3Path)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                If UCase(BrandsTiling) = UCase("Vertical") Then
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
        If Not String.IsNullOrEmpty(BrandImage4Path) Then
            If System.IO.File.Exists(BrandImage4Path) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(BrandImage4Path)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                If UCase(BrandsTiling) = UCase("Vertical") Then
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

        '
        '** Print the page border if set
        '
        If PrintPageBorder = True Then
            PrintBorder(e)
        End If

        'Write the document header and then draw a line after

        Dim Y As Integer = e.PageBounds.Top + 105
        Dim X1 As Integer = 100
        intTextHeight = Convert.ToInt32(MainTitleFont.GetHeight())
        DrawStringInBoxCenter(e, X1, Y, PrintAreaWidth, intTextHeight, UCase(DocumentHeader), myBrush, MainTitleFont)
        Y = Y + intTextHeight + 5

        'Draw the divider line
        myPen.Color = BorderColor
        e.Graphics.DrawLine(myPen, X1, Y, (PrintAreaWidth + X1), Y)
        Y = Y + 15

        '
        '** Write out the company name and address
        '
        intTextHeight = Convert.ToInt32(MainTitleFont.GetHeight()) + 10
        DrawStringInBoxLeft(e, X1 + 5, Y, PrintAreaWidth, intTextHeight, CompanyName, myBrush, MainTitleFont)
        Y = Y + intTextHeight

        Dim intYLeft As Integer = Y

        If Not String.IsNullOrEmpty(CompanyAddress1) Then
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString(CompanyAddress1, DetailFontRegular).Width) + 20
            DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, CompanyAddress1, myBrush, DetailFontRegular)
            Y = Y + intTextHeight
        End If

        'Write the company number on the left hand side
        If Not String.IsNullOrEmpty(CompanyRegistrationNumber) Then
            If boolPrintCompanyNumber = True Then
                Dim s As String = UCase(CompanyRegCaption) & " : " & UCase(CompanyRegistrationNumber)
                intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
                intTextWidth = Convert.ToInt32(e.Graphics.MeasureString(s, DetailFontRegular).Width) + 20
                Call DrawStringInBoxLeft(e, 400, intYLeft, intTextWidth, intTextHeight, s, myBrush, DetailFontRegular)
                intYLeft = intYLeft + intTextHeight
            End If
        End If

            If Not String.IsNullOrEmpty(CompanyAddress2) Then
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString(CompanyAddress2, DetailFontRegular).Width) + 20
            DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, CompanyAddress2, myBrush, DetailFontRegular)
            Y = Y + intTextHeight
        End If

        'Write the company number on the left hand side
        If Not String.IsNullOrEmpty(CompanyVatNumber) Then
            Dim s As String = UCase("VAT NO. ") & " : " & UCase(CompanyVatNumber)
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString(s, DetailFontRegular).Width) + 20
            Call DrawStringInBoxLeft(e, 400, intYLeft, intTextWidth, intTextHeight, s, myBrush, DetailFontRegular)
            intYLeft = intYLeft + intTextHeight
        End If

        If Not String.IsNullOrEmpty(CompanyAddress3) Then
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString(CompanyAddress3, DetailFontRegular).Width) + 20
            DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, CompanyAddress3, myBrush, DetailFontRegular)
            Y = Y + intTextHeight
        End If

        'Write the company number on the left hand side
        If Not String.IsNullOrEmpty(CompanyBpNumber) Then
            Dim s As String = UCase("BP   NO. ") & " : " & UCase(CompanyBpNumber)
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString(s, DetailFontRegular).Width) + 20
            Call DrawStringInBoxLeft(e, 400, intYLeft, intTextWidth, intTextHeight, s, myBrush, DetailFontRegular)
            intYLeft = intYLeft + intTextHeight
        End If

        If Not String.IsNullOrEmpty(CompanyAddress4) Then
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString(CompanyAddress4, DetailFontRegular).Width) + 20
            DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, CompanyAddress4, myBrush, DetailFontRegular)
            Y = Y + intTextHeight
        End If

        If Not String.IsNullOrEmpty(CompanyTelephone) Then
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString("PHONE : " & CompanyTelephone, DetailFontRegular).Width) + 20
            DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, "PHONE : " & CompanyTelephone, myBrush, DetailFontRegular)
            Y = Y + intTextHeight
        End If

        'Draw the divider line
        Y = Y + 5
        e.Graphics.DrawLine(myPen, X1, Y, (PrintAreaWidth + X1), Y)
        Y = Y + 5

        intTextHeight = Convert.ToInt32(SubTitleFont.GetHeight()) + 5
        DrawStringInBoxLeft(e, X1 + 5, Y, 300, intTextHeight, strRightHeader, myBrush, SubTitleFont)
        DrawStringInBoxLeft(e, X1 + 350, Y, 300, intTextHeight, strLeftHeader, myBrush, SubTitleFont)

        Y = Y + intTextHeight + 5
        e.Graphics.DrawLine(myPen, X1, Y, (PrintAreaWidth + X1), Y)
        Y = Y + 10

        runningYposition = Y

        Exit Sub
RaiseErr:
        boolAbort = True
        System.Windows.Forms.MessageBox.Show(Err.Description & " Error Number " & Err.Number & vbCrLf & _
            "Error encountered in the Great Wits SmartDocumentWriter Company Details Print", _
            "Smart Document Print Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
    End Sub

    Private Sub PrintBorder(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        myPen = New Pen(BorderColor)
        With Me.DefaultPageSettings
            Dim R As Drawing.Rectangle
            R = New Rectangle(.Margins.Left, .Margins.Top, PrintAreaWidth, _
                e.PageBounds.Height - (.Margins.Bottom + .Margins.Top))
            e.Graphics.DrawRectangle(myPen, rect:=R)
        End With
    End Sub

    Private Sub PrintDocumentInformation(ByVal e As System.Drawing.Printing.PrintPageEventArgs,
            ByVal Y_start As Integer, ByVal X_Start As Integer, ByVal ArrInfo As ArrayList)
        On Error GoTo RaiseErr
        Dim Y As Integer = Y_start
        Dim X1 As Integer = X_Start
        For p As Integer = 0 To ArrInfo.Count - 1
            Dim strBuffer() As String = Split(ArrInfo.Item(p), "|")
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            DrawStringInBoxLeft(e, X1 + 5, Y, 180, intTextHeight, strBuffer(0), myBrush, DetailFontRegular)
            DrawStringInBoxLeft(e, X1 + 190, Y, 5, intTextHeight, ":", myBrush, DetailFontRegular)
            DrawStringInBoxLeft(e, X1 + 195, Y, 100, intTextHeight, strBuffer(1), myBrush, DetailFontRegular)
            Y = Y + intTextHeight
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        System.Windows.Forms.MessageBox.Show(Err.Description & " Error Number " & Err.Number & vbCrLf & _
            "Error encountered in the Great Wits SmartDocumentWriter Company Details Print", _
            "Smart Document Print Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
    End Sub

    Private Sub PrintClientNames(ByVal e As System.Drawing.Printing.PrintPageEventArgs, Optional Ystart As Integer = 200)
        On Error GoTo RaiseErr

        Dim Y As Integer = Ystart
        Dim X1 As Integer = 100

        If Not String.IsNullOrEmpty(MainCustomerName) Then
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString(MainCustomerName, DetailFontRegular).Width) + 20
            DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, MainCustomerName, myBrush, DetailFontRegular)
            Y = Y + intTextHeight
        Else
            Y = Y + 15
        End If

        X_DocumentInfo = leftMargin + 350
        Y_DocumentInfo = Y

        If Not String.IsNullOrEmpty(MainCustomerAddress1) Then
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString(MainCustomerAddress1, DetailFontRegular).Width) + 20
            DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, MainCustomerAddress1, myBrush, DetailFontRegular)
            Y = Y + intTextHeight
        Else
            Y = Y + 15
        End If

        If Not String.IsNullOrEmpty(MainCustomerAddress2) Then
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString(MainCustomerAddress2, DetailFontRegular).Width) + 20
            DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, MainCustomerAddress2, myBrush, DetailFontRegular)
            Y = Y + intTextHeight
        Else
            Y = Y + 15
        End If

        If Not String.IsNullOrEmpty(MainCustomerAddress3) Then
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString(MainCustomerAddress3, DetailFontRegular).Width) + 20
            DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, MainCustomerAddress3, myBrush, DetailFontRegular)
            Y = Y + intTextHeight
        Else
            Y = Y + 15
        End If

        If Not String.IsNullOrEmpty(MainCustomerAddress4) Then
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString(MainCustomerAddress4, DetailFontRegular).Width) + 20
            DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, MainCustomerAddress4, myBrush, DetailFontRegular)
            Y = Y + intTextHeight
        Else
            Y = Y + 15
        End If

        If Not String.IsNullOrEmpty(MainCustomerTelephone) Then
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString("PHONE : " & MainCustomerTelephone, DetailFontRegular).Width) + 20
            DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, "PHONE : " & MainCustomerTelephone, myBrush, DetailFontRegular)
            Y = Y + intTextHeight
        Else
            Y = Y + 15
        End If

        If Not String.IsNullOrEmpty(MainCustomerEmailAddress) Then
            intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString("Email : " & MainCustomerEmailAddress, DetailFontRegular).Width) + 20
            DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, "Email : " & MainCustomerEmailAddress, myBrush, DetailFontRegular)
            Y = Y + intTextHeight
        Else
            Y = Y + 15
        End If

        If Not String.IsNullOrEmpty(MainCustomerVat) Then
            intTextHeight = Convert.ToInt32(DetailFontBold.GetHeight()) + 5
            intTextWidth = Convert.ToInt32(e.Graphics.MeasureString("VAT NUMBER : " & MainCustomerVat, DetailFontBold).Width) + 20
            DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, "VAT NUMBER : " & MainCustomerVat, myBrush, DetailFontBold)
            Y = Y + intTextHeight
        Else
            Y = Y + 15
        End If

        'Draw the divider line
        Y = Y + 5
        e.Graphics.DrawLine(myPen, X1, Y, (PrintAreaWidth + X1), Y)
        Y = Y + 15

        runningYposition = Y

        PrintHeaders(e, runningYposition)

        Exit Sub
RaiseErr:
        boolAbort = True
        System.Windows.Forms.MessageBox.Show(Err.Description & " Error Number " & Err.Number & vbCrLf & _
            "Error encountered in the Great Wits SmartDocumentWriter Client Details Print", _
            "Smart Document Print Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
    End Sub

    Private Sub PrintDocumetData(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal Y As Integer)
        On Error GoTo RaiseErr

        MyBase.OnPrintPage(e)

        If boolPrintingNextPage = True Then
            'Print the column headers
            PrintHeaders(e, runningYposition)
            boolPrintingNextPage = False
        End If

        Y = runningYposition
        Y1_Vertical_Cordinates = Y

        While itm <= PrintData.Length - 1

            Dim X1 As Integer = 100 'Initialize the value of x
            Dim strBuffer() As String = Split(PrintData(itm), "|")

            For j As Integer = 0 To strBuffer.Length - 1
                intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
                intTextWidth = ColumnWidths(j)
                Dim strValue As String = strBuffer(j)
                Select Case ColumnAlignments(j)
                    Case Is = 0 'Left alignment
                        DrawStringInBoxLeft(e, X1 + 5, Y, intTextWidth, intTextHeight, strValue, myBrush, DetailFontRegular)
                    Case Is = 1 'center alignment
                        DrawStringInBoxCenter(e, X1 + 5, Y, intTextWidth, intTextHeight, strValue, myBrush, DetailFontRegular)
                    Case Is = 2 'Right allignment
                        DrawStringInBoxRight(e, X1 + 5, Y, intTextWidth, intTextHeight, strValue, myBrush, DetailFontRegular)
                End Select
                X1 = X1 + intTextWidth
            Next

            Y = Y + intTextHeight
            runningYposition = Y
            itm = itm + 1

            If Y >= (bottomMargin - 15) Then
                boolPrintingNextPage = True
                Y2_Vertical_Cordinates = Y
                'Print footer before increamenting page number
                PrintFooter(e)
                PageNum = PageNum + 1
                If DrawVerticals = True Then DrawVerticalLines(e, X_Verticals, Y1_Vertical_Cordinates, Y2_Vertical_Cordinates)

                runningYposition = topMargin + 15
                Exit While
            End If

        End While

        If boolPrintingNextPage = True Then
            boolStillPrinting = True
            e.HasMorePages = True
        Else
            'e.HasMorePages = False
            boolStillPrinting = False
            'Print footer before increamenting page number
            PrintFooter(e)
            'Print the vertical lines
            Y2_Vertical_Cordinates = Y
            PageNum = PageNum + 1

            If DrawVerticals = True Then
                If boolPrintCurrentPageHeaders = True Then
                    DrawVerticalLines(e, X_Verticals, Y1_Vertical_Cordinates, Y2_Vertical_Cordinates)
                End If
            End If
            'Draw the horizontal line
            e.Graphics.DrawLine(myPen, leftMargin, Y, PrintAreaWidth + leftMargin, Y)
            runningYposition = Y + 15
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        System.Windows.Forms.MessageBox.Show(Err.Description & " Error Number " & Err.Number & vbCrLf & _
            "Error encountered in the Great Wits SmartDocumentWriter Details Print", _
            "Smart Document Print Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
    End Sub

    Private Sub PrintSummaryData(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal Y As Integer)
        On Error GoTo RaiseErr

        'Check that the summary can fit before printing

        If (bottomMargin - Y) < 210 Then
            boolSummaryIntoNextPage = True
            boolPrintingNextPage = True
            runningYposition = 115
            boolPrintHeaders = False
            e.HasMorePages = True
            Exit Sub
        Else

            Dim x1 As Integer = 460
            Dim HorizontalLineLength As Integer = PrintAreaWidth - 400
            Dim intYstartPosition As Integer = Y

            Dim ptf1 As PointF
            Dim ptf2 As PointF

            If Not String.IsNullOrEmpty(SummaryCaptions) Then

                Dim strSummaryCaptions() As String = Split(SummaryCaptions, "|")

                If Not String.IsNullOrEmpty(SummaryValues) Then

                    Dim strSummaryValues() As String = Split(SummaryValues, "|")

                    For p As Integer = 0 To strSummaryCaptions.Length - 1

                        Dim dblValue As Double = 0
                        If IsNumeric(strSummaryValues(p)) Then
                            dblValue = CDbl(strSummaryValues(p))
                        End If

                        If p = 0 Then
                            'Y = Y + 5
                            ptf1 = New PointF(x1, Y)
                            ptf2 = New PointF(x1 + 250, Y)
                            e.Graphics.DrawLine(myPen, ptf1, ptf2)
                            Y = Y + 5
                        End If

                        intTextHeight = Convert.ToInt32(DetailFontRegular.GetHeight()) + 5
                        DrawStringInBoxLeft(e, x1 + 5, Y, 150, intTextHeight, strSummaryCaptions(p), myBrush, DetailFontRegular)
                        DrawStringInBoxRight(e, x1 + 155, Y, 100, intTextHeight, CStr(Format(dblValue, "#,##0.00")), myBrush, DetailFontRegular)

                        'Draw the line under
                        Y = Y + intTextHeight

                        ptf1 = New PointF(x1, Y)
                        ptf2 = New PointF(x1 + 250, Y)
                        e.Graphics.DrawLine(myPen, ptf1, ptf2)
                        Y = Y + 5

                    Next

                End If

            End If

            'Draw the drop down lines
            If intYstartPosition <> Y Then

                Y = Y - 5
                ptf1 = New PointF(x1, intYstartPosition)
                ptf2 = New PointF(x1, Y)
                e.Graphics.DrawLine(myPen, ptf1, ptf2)

                x1 = x1 + 150
                ptf1 = New PointF(x1, intYstartPosition)
                ptf2 = New PointF(x1, Y)
                e.Graphics.DrawLine(myPen, ptf1, ptf2)

                x1 = x1 + 100
                ptf1 = New PointF(x1, intYstartPosition)
                ptf2 = New PointF(x1, Y)
                e.Graphics.DrawLine(myPen, ptf1, ptf2)

            End If

        End If

        runningYposition = Y

        Exit Sub
RaiseErr:
        boolAbort = True
        System.Windows.Forms.MessageBox.Show(Err.Description & " Error Number " & Err.Number & vbCrLf & _
            "Error encountered in the Great Wits SmartDocumentWriter Summary Totals Print", _
            "Smart Document Print Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
    End Sub

    Private Sub PrintBankingDetails(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal Y As Integer)
        On Error GoTo RaiseErr

        If PrintBankDetails = True Then

            If (bottomMargin - Y) < 100 Then
                boolSummaryIntoNextPage = True
                boolPrintingNextPage = True
                runningYposition = 115
                boolPrintHeaders = False
                e.HasMorePages = True
                Exit Sub
            Else

                Dim x1 As Integer = 100

                If arrCompanyBankDetails.Count > 0 Then

                    Dim intBnkCount As Integer = 0
                    Dim yBank As Integer = runningYposition  'e.PageBounds.Bottom - 190
                    If arrCompanyBankDetails.Count > 4 Then intBnkCount = 3 Else intBnkCount = arrCompanyBankDetails.Count - 1

                    'Draw the main line
                    myPen.Color = BorderColor
                    'Dim recBank As New Rectangle(x1, yBank, 510, 90)
                    'e.Graphics.DrawRectangle(myPen, recBank)
                    yBank = yBank + 3
                    Call DrawStringInBoxLeft(e, (x1), yBank, 150, 80, "OUR BANKING DETAILS", myBrush, DetailFontBold)
                    yBank = yBank + 15
                    e.Graphics.DrawLine(myPen, x1, yBank, 610, yBank)

                    Dim y_Start_Vetics As Integer = yBank - 0

                    yBank = yBank + 3
                    Call DrawStringInBoxLeft(e, (x1), yBank, 150, 80, "BANK NAME", myBrush, DetailFontBold)
                    Call DrawStringInBoxLeft(e, (x1 + 150), yBank, 80, 80, "SORT CODE", myBrush, DetailFontBold)
                    Call DrawStringInBoxLeft(e, (x1 + 230), yBank, 150, 80, "ACCOUNT NAME", myBrush, DetailFontBold)
                    Call DrawStringInBoxLeft(e, (x1 + 405), yBank, 100, 80, "ACCOUNT NO.", myBrush, DetailFontBold)
                    yBank = yBank + 15
                    e.Graphics.DrawLine(myPen, x1, yBank, 610, yBank)
                    yBank = yBank + 3

                    For j As Integer = 0 To intBnkCount
                        Dim strSplitAccounts() As String = Split(arrCompanyBankDetails.Item(j), "|")
                        '51001|STEWARD BANK JOINA CITY|GREAT WITS TECHNOLOGIES PVT LTD|1006734495
                        Call DrawStringInBoxLeft(e, (x1), yBank, 150, 80, strSplitAccounts(1), myBrush, fntFooterFont)
                        Call DrawStringInBoxLeft(e, (x1 + 155), yBank, 80, 80, strSplitAccounts(0), myBrush, fntFooterFont)
                        Call DrawStringInBoxLeft(e, (x1 + 235), yBank, 170, 80, strSplitAccounts(2), myBrush, fntFooterFont)
                        Call DrawStringInBoxLeft(e, (x1 + 410), yBank, 100, 80, strSplitAccounts(3), myBrush, fntFooterFont)
                        yBank = yBank + 15
                        e.Graphics.DrawLine(myPen, x1, yBank, 610, yBank)
                        yBank = yBank + 3
                    Next

                    Dim Y_End_Vertics As Integer = yBank - 3

                    'Print verticals
                    e.Graphics.DrawLine(myPen, x1 + 150, y_Start_Vetics, x1 + 150, Y_End_Vertics)
                    e.Graphics.DrawLine(myPen, x1 + 230, y_Start_Vetics, x1 + 230, Y_End_Vertics)
                    e.Graphics.DrawLine(myPen, x1 + 400, y_Start_Vetics, x1 + 400, Y_End_Vertics)
                    e.Graphics.DrawLine(myPen, x1 + 510, y_Start_Vetics, x1 + 510, Y_End_Vertics)

                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        System.Windows.Forms.MessageBox.Show(Err.Description & " Error Number " & Err.Number & vbCrLf & _
                "Error encountered in the Great Wits SmartDocumentWriter Banking Details Print", _
                "Smart Document Print Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
    End Sub

    Private Sub PrintBankingDetailsRequest(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal Y As Integer)
        On Error GoTo RaiseErr

        If PrintBankDetails = True Then

            If (bottomMargin - Y) < 100 Then
                boolSummaryIntoNextPage = True
                boolPrintingNextPage = True
                runningYposition = 115
                boolPrintHeaders = False
                e.HasMorePages = True
                Exit Sub
            Else
                Dim x1 As Integer = 100
                Dim yBank As Integer = runningYposition
                yBank = yBank + 3
                Call DrawStringInBoxLeft(e, (x1), yBank, 600, 80, "PLEASE SUPPLY US WITH YOUR BANKING DATAILS IN ORDER FOR US TO PAY INTO", myBrush, DetailFontBold)
                yBank = yBank + 30
                e.Graphics.DrawLine(myPen, leftMargin, yBank, PrintAreaWidth + leftMargin, yBank)
            End If

        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        System.Windows.Forms.MessageBox.Show(Err.Description & " Error Number " & Err.Number & vbCrLf &
                "Error encountered in the Great Wits SmartDocumentWriter Banking Details Requests Print",
                "Smart Document Print Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
    End Sub

    Private Sub DrawVerticalLines(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal X_Cordinates() As Integer, ByVal Y1 As Integer, ByVal Y2 As Integer)
        On Error GoTo RaiseErr
        myPen = New Pen(BorderColor)
        If PageNum > 1 Then
            Y1 = Y1 - 45
        End If
        For p As Integer = 0 To X_Cordinates.Length - 1
            e.Graphics.DrawLine(myPen, X_Cordinates(p), Y1, X_Cordinates(p), Y2)
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        System.Windows.Forms.MessageBox.Show(Err.Description & " Error Number " & Err.Number & vbCrLf & _
            "Error encountered in the Great Wits SmartDocumentWriter Vertical Lines Print", _
            "Smart Document Print Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
    End Sub

    Private Sub PrintFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        On Error GoTo RaiseErr
        Dim Y_Footer As Integer = bottomMargin + 30
        Call DrawStringInBoxLeft(e, leftMargin, Y_Footer, 150, 80, "Page " & CStr(PageNum), myBrush, fntFooterFont)
        Call DrawStringInBoxLeft(e, leftMargin + 200, Y_Footer, 150, 80, strFooter, myBrush, fntFooterFont)
        Exit Sub
RaiseErr:
        boolAbort = True
        System.Windows.Forms.MessageBox.Show(Err.Description & " Error Number " & Err.Number & vbCrLf & _
            "Error encountered in the Great Wits SmartDocumentWriter Footer Details Print", _
            "Smart Document Print Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
    End Sub

End Class
