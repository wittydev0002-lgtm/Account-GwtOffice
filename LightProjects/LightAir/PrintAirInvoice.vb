Imports System.Drawing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class PrintAirInvoice

    Inherits Drawing.Printing.PrintDocument

    Public tlFont As New Font("Arial", 6, FontStyle.Regular)
    Public myfntDetailsFontBold As New System.Drawing.Font("Arial", 18, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Public dblInvoiceTotal As Double = 0

    Public arrPrintData As New ArrayList

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
    
    Public strPermitInvoiceNumber As String
    Public strPermitInvoiceDate As String
    Public strPermitInvoiceDueDate As String
    Public strPermitJobNumber As String
    Public strPermitReferenceNumber As String

    Public strPermitOperatorName As String
    Public strPermitRegistrationType As String
    Public strPermitLocation As String
    Public strPermitArrivalDate As String
    Public strPermitDepatureDate As String
    Public strPermitCaptainName As String

    Protected Overrides Sub OnPrintPage(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        MyBase.OnPrintPage(e)

        Dim myGraphics As Graphics = e.Graphics
        Dim myRectangle As Rectangle
        Dim myPen As New Pen(Color.Black)

        Dim intX As Integer = 530
        Dim intY As Integer = 100

        Dim strFontName As String = "Arial"
        Dim intFontSize As Integer = 8
        Dim strForeColor As String = "Black"
        Dim boolFontBold As Boolean = False
        Dim boolFontItalic As Boolean = False
        Dim boolFontUnderline As Boolean = False
        Dim strBackColor As String = "White"
        Dim intAlignment As Integer = 0
        Dim strText As String = Nothing
        Dim intCellWidth As Integer = 100
        Dim intCellHeight As Integer = 15


        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Invoice #" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 20, strText, fntDetailsFontBold, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = strPermitInvoiceNumber : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 20, strText, tlFont, Brushes.Black)

        'Second line boxes
        intY = intY + 28
        intX = 530

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Invoice Date" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFontBold, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = strPermitInvoiceDate : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, tlFont, Brushes.Black)

        'Third line boxes
        intY = intY + 28
        intX = 530

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Due Date" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFontBold, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = strPermitInvoiceDueDate : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, tlFont, Brushes.Black)

        'Fourth line boxes
        intY = intY + 28
        intX = 530

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Job #" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFontBold, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = strPermitJobNumber : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, tlFont, Brushes.Black)

        'Fifth line boxes
        intY = intY + 28
        intX = 530

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Ref. #" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, fntDetailsFontBold, Brushes.Black)

        intX = intX + 100
        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = strPermitReferenceNumber : boolFontBold = True
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 5, intY + 5, intCellWidth, 80, strText, tlFont, Brushes.Black)


        '********** DRAW THE HEADER LINES *******************
        '
        'HEADER BOX 1

        intY = intY + 56
        intX = 100
        intCellWidth = 150
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Operator" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, fntDetailsFontBold, Brushes.Black)

        'HEADER BOX 2
        intX = intX + intCellWidth + 3
        intCellWidth = 100
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Reg/Type" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, fntDetailsFontBold, Brushes.Black)

        'HEADER BOX 3
        intX = intX + intCellWidth + 3
        intCellWidth = 80
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Location" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, fntDetailsFontBold, Brushes.Black)

        'HEADER BOX 4
        intX = intX + intCellWidth + 3
        intCellWidth = 80
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Arrival" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, fntDetailsFontBold, Brushes.Black)

        'HEADER BOX 5
        intX = intX + intCellWidth + 3
        intCellWidth = 80
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Departure" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, fntDetailsFontBold, Brushes.Black)

        'HEADER BOX 6
        intX = intX + intCellWidth + 3
        intCellWidth = 125
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = "Captain Name" : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, fntDetailsFontBold, Brushes.Black)


        '************ SECOND LINE HEADERS ***************************

        'HEADER BOX 1

        intY = intY + 26
        intX = 100
        intCellWidth = 150
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = strPermitOperatorName : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, tlFont, Brushes.Black)

        'HEADER BOX 2
        intX = intX + intCellWidth + 3
        intCellWidth = 100
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = strPermitRegistrationType : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, tlFont, Brushes.Black)

        'HEADER BOX 3
        intX = intX + intCellWidth + 3
        intCellWidth = 80
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = strPermitLocation : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, tlFont, Brushes.Black)

        'HEADER BOX 4
        intX = intX + intCellWidth + 3
        intCellWidth = 80
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = strPermitArrivalDate : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, tlFont, Brushes.Black)

        'HEADER BOX 5
        intX = intX + intCellWidth + 3
        intCellWidth = 80
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = strPermitDepatureDate : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, tlFont, Brushes.Black)

        'HEADER BOX 6
        intX = intX + intCellWidth + 3
        intCellWidth = 125
        intCellHeight = 25

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        strText = strPermitCaptainName : boolFontBold = True
        Call gwt_comm.DrawStringInBoxCenter(e, intX + 5, intY + 5, intCellWidth, intCellHeight, strText, tlFont, Brushes.Black)


        'BEGIN DETAILS PRINT BY PRINT FIRST THE BOXES

        'DRAW THE MAIN BOX

        intY = intY + 28
        intX = 100
        intCellWidth = 630
        intCellHeight = 600

        Dim intHeaderY As Integer = intY + 10

        myRectangle = New Rectangle(x:=intX, y:=intY, Width:=intCellWidth, Height:=intCellHeight)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)

        'Draw the first horizontal line
        intY = intY + 28
        e.Graphics.DrawLine(Pens.Black, intX, intY, 730, intY)

        'Draw the first vertical line 
        intX = 470
        e.Graphics.DrawLine(Pens.Black, intX, intY - 28, intX, 920)

        'Draw the first vertical line 
        intX = 550
        e.Graphics.DrawLine(Pens.Black, intX, intY - 28, intX, 920)

        'Draw the first vertical line 
        intX = 630
        e.Graphics.DrawLine(Pens.Black, intX, intY - 28, intX, 920)

        'Write out the headers
        Call gwt_comm.DrawStringInBoxLeft(e, 105, intHeaderY, 250, 20, "Service", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 475, intHeaderY, 80, 20, "Unit Price", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 555, intHeaderY, 80, 20, "Qty", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 635, intHeaderY, 100, 20, "Amount", tlFont, Brushes.Black)

        Dim intYdetails As Integer = intHeaderY + 30

        For ip As Integer = 0 To arrPrintData.Count - 1
            Dim strValues() As String = Split(arrPrintData.Item(ip), "|")
            Call gwt_comm.DrawStringInBoxLeft(e, 105, intYdetails, 250, 20, strValues(0), tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, 475, intYdetails, 75, 20, strValues(1), tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, 555, intYdetails, 75, 20, strValues(2), tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, 635, intYdetails, 95, 20, strValues(3), tlFont, Brushes.Black)
            intYdetails = intYdetails + 15
        Next

        'Draw the total line box

        myRectangle = New Rectangle(x:=630, y:=925, Width:=100, Height:=25)
        myGraphics.DrawRectangle(pen:=myPen, rect:=myRectangle)
        Call gwt_comm.DrawStringInBoxRight(e, 535, 930, 80, 20, "TOTAL", fntDetailsFontBold, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, 630, 930, 100, 25, Format(dblInvoiceTotal, "#,##0.00"), fntDetailsFontBold, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, 100, 930, 300, 20, "VIA Aviation Limited", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 100, 942, 300, 20, "Terminal One", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 100, 954, 300, 20, "Dar es Salam International Airport", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 100, 966, 300, 20, "P O Box 3590", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 100, 978, 300, 20, "Dar es Salam, Tanzania", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 100, 990, 300, 20, "TIN Number 101-602-745", tlFont, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, 302, 930, 300, 20, "Banking Details", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 302, 942, 300, 20, "Beneficiary : VIA Aviation Limited", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 302, 954, 300, 20, "USD Account Number : 8004275", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 302, 966, 300, 20, "EUR Account Number : 6001414", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 302, 978, 300, 20, "Bank Name : Barclays Bank (T) Ltd", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 302, 990, 300, 20, "Swift Code : BARCTZTZ", tlFont, Brushes.Black)

        'Draw the logo

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

        'Print Company Address

        intX = 105
        intY = 150

        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, CustomerName, tlFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, CustomerAddress1, tlFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, CustomerAddress2, tlFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, CustomerAddress3, tlFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, CustomerAddress4, tlFont, Brushes.Black)
        intY = intY + 12
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 300, 20, CustomerTelephone, tlFont, Brushes.Black)

        'Print Header
        Call gwt_comm.DrawStringInBoxLeft(e, 530, 60, 300, 40, "INVOICE", myfntDetailsFontBold, Brushes.Black)

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Print"
        ShowErrorMessage()
    End Sub

    Private Sub DrawStringInBoxRight(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
                ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, _
                Optional ByVal strFontName As String = "Arial", _
                Optional ByVal intFontSize As Integer = 8, Optional ByVal FontColor As String = "Black", _
                Optional ByVal FontBold As Boolean = False, Optional ByVal FontItalic As Boolean = False, _
                Optional ByVal FontUnderline As Boolean = False, Optional ByVal BackColor As String = "White")
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF((x1 - 1), (y1 - 2), (x2 - 2), (y2 - y1))
        Dim fillColor As New SolidBrush(Drawing.Color.FromName(BackColor))
        ev.Graphics.FillRectangle(fillColor, recCurrent)
        sfCurrent.Alignment = Drawing.StringAlignment.Far
        Dim sBrush As System.Drawing.Brush = GetDefinedColor(FontColor)
        'Reset the font style according to parameters passed
        Dim sFnt As New Font(strFontName, intFontSize, FontStyle.Regular)
        If FontBold = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Bold)
        If FontItalic = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Italic)
        If FontUnderline = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Underline)
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Private Sub DrawStringInBoxLeft(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
                ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, _
                Optional ByVal strFontName As String = "Arial", _
                Optional ByVal intFontSize As Integer = 8, Optional ByVal FontColor As String = "Black", _
                Optional ByVal FontBold As Boolean = False, Optional ByVal FontItalic As Boolean = False, _
                Optional ByVal FontUnderline As Boolean = False, Optional ByVal BackColor As String = "White")
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF((x1 - 1), (y1 - 2), (x2 - 2), (y2 - y1))
        Dim fillColor As New SolidBrush(Drawing.Color.FromName(BackColor))
        ev.Graphics.FillRectangle(fillColor, recCurrent)
        sfCurrent.Alignment = Drawing.StringAlignment.Near
        Dim sBrush As System.Drawing.Brush = GetDefinedColor(FontColor)
        'Reset the font style according to parameters passed
        Dim sFnt As New Font(strFontName, intFontSize, FontStyle.Regular)
        If FontBold = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Bold)
        If FontItalic = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Italic)
        If FontUnderline = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Underline)
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Private Sub DrawStringInBoxCenter(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
                ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, _
                Optional ByVal strFontName As String = "Arial", _
                Optional ByVal intFontSize As Integer = 8, Optional ByVal FontColor As String = "Black", _
                Optional ByVal FontBold As Boolean = False, Optional ByVal FontItalic As Boolean = False, _
                Optional ByVal FontUnderline As Boolean = False, Optional ByVal BackColor As String = "White")
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF((x1 - 1), (y1 - 2), (x2 - 2), (y2 - y1))
        Dim fillColor As New SolidBrush(Drawing.Color.FromName(BackColor))
        ev.Graphics.FillRectangle(fillColor, recCurrent)
        sfCurrent.Alignment = Drawing.StringAlignment.Center
        Dim sBrush As System.Drawing.Brush = GetDefinedColor(FontColor)
        'Reset the font style according to parameters passed
        Dim sFnt As New Font(strFontName, intFontSize, FontStyle.Regular)
        If FontBold = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Bold)
        If FontItalic = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Italic)
        If FontUnderline = True Then sFnt = New Font(strFontName, intFontSize, FontStyle.Underline)
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Private Function GetDefinedColor(ByVal strColorName As String) As System.Drawing.Brush
        Dim ret As System.Drawing.Brush
        Select Case UCase(strColorName)
            Case Is = UCase("AliceBlue")
                ret = Brushes.AliceBlue
            Case Is = UCase("AntiqueWhite")
                ret = Brushes.AntiqueWhite
            Case Is = UCase("Aqua")
                ret = Brushes.Aqua
            Case Is = UCase("Aquamarine")
                ret = Brushes.Aquamarine
            Case Is = UCase("Azure")
                ret = Brushes.Azure
            Case Is = UCase("Beige")
                ret = Brushes.Beige
            Case Is = UCase("Bisque")
                ret = Brushes.Bisque
            Case Is = UCase("Black")
                ret = Brushes.Black
            Case Is = UCase("BlanchedAlmond")
                ret = Brushes.BlanchedAlmond
            Case Is = UCase("Blue")
                ret = Brushes.Blue
            Case Is = UCase("BlueViolet")
                ret = Brushes.BlueViolet
            Case Is = UCase("Brown")
                ret = Brushes.Brown
            Case Is = UCase("BurlyWood")
                ret = Brushes.BurlyWood
            Case Is = UCase("CadetBlue")
                ret = Brushes.CadetBlue
            Case Is = UCase("Chartreuse")
                ret = Brushes.Chartreuse
            Case Is = UCase("Chocolate")
                ret = Brushes.Chocolate
            Case Is = UCase("Coral")
                ret = Brushes.Coral
            Case Is = UCase("CornflowerBlue")
                ret = Brushes.CornflowerBlue
            Case Is = UCase("Cornsilk")
                ret = Brushes.Cornsilk
            Case Is = UCase("Crimson")
                ret = Brushes.Crimson
            Case Is = UCase("Cyan")
                ret = Brushes.Cyan
            Case Is = UCase("DarkBlue")
                ret = Brushes.DarkBlue
            Case Is = UCase("DarkCyan")
                ret = Brushes.DarkCyan
            Case Is = UCase("DarkGoldenrod")
                ret = Brushes.DarkGoldenrod
            Case Is = UCase("DarkGray")
                ret = Brushes.DarkGray
            Case Is = UCase("DarkGreen")
                ret = Brushes.DarkGreen
            Case Is = UCase("DarkKhaki")
                ret = Brushes.DarkKhaki
            Case Is = UCase("DarkMagenta")
                ret = Brushes.DarkMagenta
            Case Is = UCase("DarkOliveGreen")
                ret = Brushes.DarkOliveGreen
            Case Is = UCase("DarkOrange")
                ret = Brushes.DarkOrange
            Case Is = UCase("DarkOrchid")
                ret = Brushes.DarkOrchid
            Case Is = UCase("DarkRed")
                ret = Brushes.DarkRed
            Case Is = UCase("DarkSalmon")
                ret = Brushes.DarkSalmon
            Case Is = UCase("DarkSeaGreen")
                ret = Brushes.DarkSeaGreen
            Case Is = UCase("DarkSlateBlue")
                ret = Brushes.DarkSlateBlue
            Case Is = UCase("DarkSlateGray")
                ret = Brushes.DarkSlateGray
            Case Is = UCase("DarkTurquoise")
                ret = Brushes.DarkTurquoise
            Case Is = UCase("DarkViolet")
                ret = Brushes.DarkViolet
            Case Is = UCase("DeepPink")
                ret = Brushes.DeepPink
            Case Is = UCase("DeepSkyBlue")
                ret = Brushes.DeepSkyBlue
            Case Is = UCase("DimGray")
                ret = Brushes.DimGray
            Case Is = UCase("DodgerBlue")
                ret = Brushes.DodgerBlue
            Case Is = UCase("Firebrick")
                ret = Brushes.Firebrick
            Case Is = UCase("FloralWhite")
                ret = Brushes.FloralWhite
            Case Is = UCase("ForestGreen")
                ret = Brushes.ForestGreen
            Case Is = UCase("Fuchsia")
                ret = Brushes.Fuchsia
            Case Is = UCase("Gainsboro")
                ret = Brushes.Gainsboro
            Case Is = UCase("GhostWhite")
                ret = Brushes.GhostWhite
            Case Is = UCase("Gold")
                ret = Brushes.Gold
            Case Is = UCase("Goldenrod")
                ret = Brushes.Goldenrod
            Case Is = UCase("Gray")
                ret = Brushes.Gray
            Case Is = UCase("Green")
                ret = Brushes.Green
            Case Is = UCase("GreenYellow")
                ret = Brushes.GreenYellow
            Case Is = UCase("Honeydew")
                ret = Brushes.Honeydew
            Case Is = UCase("HotPink")
                ret = Brushes.HotPink
            Case Is = UCase("IndianRed")
                ret = Brushes.IndianRed
            Case Is = UCase("Indigo")
                ret = Brushes.Indigo
            Case Is = UCase("Ivory")
                ret = Brushes.Ivory
            Case Is = UCase("Khaki")
                ret = Brushes.Khaki
            Case Is = UCase("Lavender")
                ret = Brushes.Lavender
            Case Is = UCase("LavenderBlush")
                ret = Brushes.LavenderBlush
            Case Is = UCase("LawnGreen")
                ret = Brushes.LawnGreen
            Case Is = UCase("LemonChiffon")
                ret = Brushes.LemonChiffon
            Case Is = UCase("LightBlue")
                ret = Brushes.LightBlue
            Case Is = UCase("LightCoral")
                ret = Brushes.LightCoral
            Case Is = UCase("LightCyan")
                ret = Brushes.LightCyan
            Case Is = UCase("LightGoldenrodYellow")
                ret = Brushes.LightGoldenrodYellow
            Case Is = UCase("LightGray")
                ret = Brushes.LightGray
            Case Is = UCase("LightGreen")
                ret = Brushes.LightGreen
            Case Is = UCase("LightPink")
                ret = Brushes.LightPink
            Case Is = UCase("LightSalmon")
                ret = Brushes.LightSalmon
            Case Is = UCase("LightSeaGreen")
                ret = Brushes.LightSeaGreen
            Case Is = UCase("LightSkyBlue")
                ret = Brushes.LightSkyBlue
            Case Is = UCase("LightSlateGray")
                ret = Brushes.LightSlateGray
            Case Is = UCase("LightSteelBlue")
                ret = Brushes.LightSteelBlue
            Case Is = UCase("LightYellow")
                ret = Brushes.LightYellow
            Case Is = UCase("Lime")
                ret = Brushes.Lime
            Case Is = UCase("LimeGreen")
                ret = Brushes.LimeGreen
            Case Is = UCase("Linen")
                ret = Brushes.Linen
            Case Is = UCase("Magenta")
                ret = Brushes.Magenta
            Case Is = UCase("Maroon")
                ret = Brushes.Maroon
            Case Is = UCase("MediumAquamarine")
                ret = Brushes.MediumAquamarine
            Case Is = UCase("MediumBlue")
                ret = Brushes.MediumBlue
            Case Is = UCase("MediumOrchid")
                ret = Brushes.MediumOrchid
            Case Is = UCase("MediumPurple")
                ret = Brushes.MediumPurple
            Case Is = UCase("MediumSeaGreen")
                ret = Brushes.MediumSeaGreen
            Case Is = UCase("MediumSlateBlue")
                ret = Brushes.MediumSlateBlue
            Case Is = UCase("MediumSpringGreen")
                ret = Brushes.MediumSpringGreen
            Case Is = UCase("MediumTurquoise")
                ret = Brushes.MediumTurquoise
            Case Is = UCase("MediumVioletRed")
                ret = Brushes.MediumVioletRed
            Case Is = UCase("MidnightBlue")
                ret = Brushes.MidnightBlue
            Case Is = UCase("MintCream")
                ret = Brushes.MintCream
            Case Is = UCase("MistyRose")
                ret = Brushes.MistyRose
            Case Is = UCase("Moccasin")
                ret = Brushes.Moccasin
            Case Is = UCase("NavajoWhite")
                ret = Brushes.NavajoWhite
            Case Is = UCase("Navy")
                ret = Brushes.Navy
            Case Is = UCase("OldLace")
                ret = Brushes.OldLace
            Case Is = UCase("Olive")
                ret = Brushes.Olive
            Case Is = UCase("OliveDrab")
                ret = Brushes.OliveDrab
            Case Is = UCase("Orange")
                ret = Brushes.Orange
            Case Is = UCase("OrangeRed")
                ret = Brushes.OrangeRed
            Case Is = UCase("Orchid")
                ret = Brushes.Orchid
            Case Is = UCase("PaleGoldenrod")
                ret = Brushes.PaleGoldenrod
            Case Is = UCase("PaleGreen")
                ret = Brushes.PaleGreen
            Case Is = UCase("PaleTurquoise")
                ret = Brushes.PaleTurquoise
            Case Is = UCase("PaleVioletRed")
                ret = Brushes.PaleVioletRed
            Case Is = UCase("PapayaWhip")
                ret = Brushes.PapayaWhip
            Case Is = UCase("PeachPuff")
                ret = Brushes.PeachPuff
            Case Is = UCase("Peru")
                ret = Brushes.Peru
            Case Is = UCase("Pink")
                ret = Brushes.Pink
            Case Is = UCase("Plum")
                ret = Brushes.Plum
            Case Is = UCase("PowderBlue")
                ret = Brushes.PowderBlue
            Case Is = UCase("Purple")
                ret = Brushes.Purple
            Case Is = UCase("Red")
                ret = Brushes.Red
            Case Is = UCase("RosyBrown")
                ret = Brushes.RosyBrown
            Case Is = UCase("RoyalBlue")
                ret = Brushes.RoyalBlue
            Case Is = UCase("SaddleBrown")
                ret = Brushes.SaddleBrown
            Case Is = UCase("Salmon")
                ret = Brushes.Salmon
            Case Is = UCase("SandyBrown")
                ret = Brushes.SandyBrown
            Case Is = UCase("SeaGreen")
                ret = Brushes.SeaGreen
            Case Is = UCase("SeaShell")
                ret = Brushes.SeaShell
            Case Is = UCase("Sienna")
                ret = Brushes.Sienna
            Case Is = UCase("Silver")
                ret = Brushes.Silver
            Case Is = UCase("SkyBlue")
                ret = Brushes.SkyBlue
            Case Is = UCase("SlateBlue")
                ret = Brushes.SlateBlue
            Case Is = UCase("SlateGray")
                ret = Brushes.SlateGray
            Case Is = UCase("Snow")
                ret = Brushes.Snow
            Case Is = UCase("SpringGreen")
                ret = Brushes.SpringGreen
            Case Is = UCase("SteelBlue")
                ret = Brushes.SteelBlue
            Case Is = UCase("Tan")
                ret = Brushes.Tan
            Case Is = UCase("Teal")
                ret = Brushes.Teal
            Case Is = UCase("Thistle")
                ret = Brushes.Thistle
            Case Is = UCase("Tomato")
                ret = Brushes.Tomato
            Case Is = UCase("Turquoise")
                ret = Brushes.Turquoise
            Case Is = UCase("Violet")
                ret = Brushes.Violet
            Case Is = UCase("Wheat")
                ret = Brushes.Wheat
            Case Is = UCase("White")
                ret = Brushes.White
            Case Is = UCase("WhiteSmoke")
                ret = Brushes.WhiteSmoke
            Case Is = UCase("Yellow")
                ret = Brushes.Yellow
            Case Is = UCase("YellowGreen")
                ret = Brushes.YellowGreen
            Case Else
                ret = Brushes.Black
        End Select
        Return ret
    End Function
    
End Class
