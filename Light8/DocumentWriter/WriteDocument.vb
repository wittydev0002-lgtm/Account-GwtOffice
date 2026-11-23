Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing
Imports System.Drawing.Graphics
Imports System.Windows.Forms

Public Class WriteDocument

    Inherits Drawing.Printing.PrintDocument

    'Customer variables
    Public sCustomerName As String
    Public sCustomerAddress1 As String
    Public sCustomerAddress2 As String
    Public sCustomerAddress3 As String
    Public sCustomerAddress4 As String
    Public sCustomerTelephone As String
    Public sCustomerEmailAddress As String
    Public sCustomerVatNumber As String
    Public sCustomerBpNumber As String

    Public PrintBrandImages As Boolean = False
    Public DrawBorder As Boolean = True

    ' for PrintDialog, PrintPreviewDialog and PrintDocument:
    Private prnDialog As System.Windows.Forms.PrintDialog
    Private prnPreview As System.Windows.Forms.PrintPreviewDialog
    Private prnDocument As System.Drawing.Printing.PrintDocument

    ' for Report:
    Private CurrentY As Integer
    Private CurrentX As Integer
    Private leftMargin As Integer
    Private rightMargin As Integer
    Private topMargin As Integer
    Private bottomMargin As Integer
    Private PrintAreaWidth As Integer
    Private PrintAreaHeight As Integer

    ' Font and Color:------------------
    ' Title Font
    Private InvTitleFontRegular As Font = New Font("Arial", 24, FontStyle.Regular)
    Private InvTitleFontBold As Font = New Font("Arial", 24, FontStyle.Bold)

    ' Title Font height
    Private InvTitleHeight As Integer
    ' SubTitle Font
    Private InvSubTitleFontRegular As Font = New Font("Arial", 14, FontStyle.Regular)
    Private InvSubTitleFontBold As Font = New Font("Arial", 14, FontStyle.Bold)

    ' SubTitle Font height
    Private InvSubTitleHeight As Integer
    ' Invoice Font
    Private DetailFontRegular As Font = New Font("Arial", 8, FontStyle.Regular)
    Private DetailFontBold As Font = New Font("Arial", 8, FontStyle.Bold)

    ' Invoice Font height
    Private DetailFontHeight As Integer
    ' Blue Color
    Private BlueBrush As SolidBrush = New SolidBrush(Color.Blue)
    ' Red Color
    Private RedBrush As SolidBrush = New SolidBrush(Color.Red)
    ' Black Color
    Private BlackBrush As SolidBrush = New SolidBrush(Color.Black)

    Private InvTitle As String
    Private InvSubTitle1 As String
    Private InvSubTitle2 As String
    Private InvSubTitle3 As String
    Private InvSubTitle4 As String
    Private InvSubTitleTelephone As String

    Private InvImage As String

    Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions

    Public Sub New()
        MyBase.New()

        'InitializeComponent()

        Me.prnDialog = New System.Windows.Forms.PrintDialog
        Me.prnPreview = New System.Windows.Forms.PrintPreviewDialog
        Me.prnDocument = New System.Drawing.Printing.PrintDocument
        ' The Event of 'PrintPage'
        AddHandler prnDocument.PrintPage, AddressOf prnDocument_PrintPage
    End Sub

    Protected Overrides Sub OnBeginPrint(ByVal ev As Drawing.Printing.PrintEventArgs)
        ' Run base code
        MyBase.OnBeginPrint(ev)
        
    End Sub

    Private Sub SetInvoiceHead(ev As System.Drawing.Printing.PrintPageEventArgs)


        MyBase.OnPrintPage(ev)

        leftMargin = Convert.ToInt32(ev.MarginBounds.Left)
        rightMargin = Convert.ToInt32(ev.MarginBounds.Right)
        topMargin = Convert.ToInt32(ev.MarginBounds.Top)
        bottomMargin = Convert.ToInt32(ev.MarginBounds.Bottom)
        PrintAreaWidth = Convert.ToInt32(ev.MarginBounds.Width)
        PrintAreaHeight = Convert.ToInt32(ev.MarginBounds.Height)

        CurrentY = topMargin
        CurrentX = leftMargin

        Dim intLogoNextXPosition As Integer = intLogoXposition

        'Draw the logos and watermarks
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
                ev.Graphics.DrawImage(objPicture.Image, R)
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
                ev.Graphics.DrawImage(objPicture.Image, R)
            End If
        End If

        Dim intBrandLogoYposition As Integer = intBrandsYposition
        intLogoNextXPosition = intBrandsXposition

        If PrintBrandImages = True Then

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
                        ev.Graphics.DrawImage(objPicture.Image, R)
                        intBrandLogoYposition = R.Y + R.Height + 3
                    Else
                        R = New Rectangle(intLogoNextXPosition, intBrandLogoYposition, objPicture.Width, objPicture.Height)
                        ev.Graphics.DrawImage(objPicture.Image, R)
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
                        ev.Graphics.DrawImage(objPicture.Image, R)
                        intBrandLogoYposition = R.Y + R.Height + 3
                    Else
                        R = New Rectangle(intLogoNextXPosition, intBrandLogoYposition, objPicture.Width, objPicture.Height)
                        ev.Graphics.DrawImage(objPicture.Image, R)
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
                        ev.Graphics.DrawImage(objPicture.Image, R)
                        intBrandLogoYposition = R.Y + R.Height + 3
                    Else
                        R = New Rectangle(intLogoNextXPosition, intBrandLogoYposition, objPicture.Width, objPicture.Height)
                        ev.Graphics.DrawImage(objPicture.Image, R)
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
                        ev.Graphics.DrawImage(objPicture.Image, R)
                        intBrandLogoYposition = R.Y + R.Height + 3
                    Else
                        R = New Rectangle(intLogoNextXPosition, intBrandLogoYposition, objPicture.Width, objPicture.Height)
                        ev.Graphics.DrawImage(objPicture.Image, R)
                        intLogoNextXPosition = R.X + R.Width + 3
                    End If
                End If
            End If

        End If

        'Draw border
        Dim myPen As System.Drawing.Pen
        Dim intHorizontalLineLength As Integer = PrintAreaWidth

        If DrawBorder = True Then
            myPen = New Pen(Brushes.LightGray)
            gwt_comm.DrawBorder(ev, leftMargin, topMargin, PrintAreaWidth, PrintAreaHeight, myPen)
        End If

        ' Draw Invoice Head:
        strCompanyName = "EMBASSY AND ASSOCIATES"
        If Not String.IsNullOrEmpty(strCompanyName) Then
            CurrentY = CurrentY + Convert.ToInt32(fntHeaderFont.GetHeight)
            gwt_comm.DrawStringInBoxLeft(ev, CurrentX, CurrentY, _
                Convert.ToInt32(ev.Graphics.MeasureString(strCompanyName, fntHeaderFont).Width), _
                Convert.ToSingle(fntHeaderFont.GetHeight()), strCompanyName, fntHeaderFont, Brushes.Black)
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress1) Then
            CurrentY = CurrentY + Convert.ToInt32(fntDetailsFont.GetHeight)
            gwt_comm.DrawStringInBoxLeft(ev, CurrentX, CurrentY, _
                Convert.ToInt32(ev.Graphics.MeasureString(strCompanyAddress1, fntDetailsFont).Width), _
                Convert.ToSingle(fntDetailsFont.GetHeight()), strCompanyAddress1, fntDetailsFont, Brushes.Black)
        End If
        If Not String.IsNullOrEmpty(strCompanyAddress2) Then
            CurrentY = CurrentY + Convert.ToInt32(fntDetailsFont.GetHeight)
            gwt_comm.DrawStringInBoxLeft(ev, CurrentX, CurrentY, _
                Convert.ToInt32(ev.Graphics.MeasureString(strCompanyAddress2, fntDetailsFont).Width), _
                Convert.ToSingle(fntDetailsFont.GetHeight()), strCompanyAddress2, fntDetailsFont, Brushes.Black)
        End If
        If Not String.IsNullOrEmpty(strCompanyAddress3) Then
            CurrentY = CurrentY + Convert.ToInt32(fntDetailsFont.GetHeight)
            gwt_comm.DrawStringInBoxLeft(ev, CurrentX, CurrentY, _
                Convert.ToInt32(ev.Graphics.MeasureString(strCompanyAddress3, fntDetailsFont).Width), _
                Convert.ToSingle(fntDetailsFont.GetHeight()), strCompanyAddress3, fntDetailsFont, Brushes.Black)
        End If
        If Not String.IsNullOrEmpty(strCompanyAddress4) Then
            CurrentY = CurrentY + Convert.ToInt32(fntDetailsFont.GetHeight)
            gwt_comm.DrawStringInBoxLeft(ev, CurrentX, CurrentY, _
                Convert.ToInt32(ev.Graphics.MeasureString(strCompanyAddress4, fntDetailsFont).Width), _
                Convert.ToSingle(fntDetailsFont.GetHeight()), strCompanyAddress4, fntDetailsFont, Brushes.Black)
        End If

        ' Draw line:
        'CurrentY = CurrentY + InvSubTitleHeight + 8
        'ev.Graphics.DrawLine(New Pen(Brushes.Black, 2), CurrentX, CurrentY, rightMargin, CurrentY)

    End Sub

    Protected Overrides Sub OnPrintPage(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        MyBase.OnPrintPage(e)
        SetInvoiceHead(e)
        e.HasMorePages = False
    End Sub

    Private Sub prnDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
       
    End Sub

End Class
