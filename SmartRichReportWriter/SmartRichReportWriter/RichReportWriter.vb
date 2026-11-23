Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

' *** 0773633451 Mai Popo

Public Class RichReportWriter

    ' Inherits all the functionality of a PrintDocument
    Inherits Drawing.Printing.PrintDocument

    Dim strFooter As String
    Public strMainHeader1 As String
    Public strMainHeader2 As String
    Public strMainHeader3 As String
    Public intTitleXposition As Integer
    Public intFooterXposition As Integer
    Public intTitleYposition As Integer

    Public intPageNumXposition As Integer
    Public Data As String
    Public boolDrawBorder As Boolean

    Dim fntTitleFont As System.Drawing.Font
    Dim fntLongest As System.Drawing.Font
    Dim intLineCounter As Single

    Dim clrTitleColor As System.Drawing.Color
    Dim clrGridColor As System.Drawing.Color
    Dim clrFooterColor As System.Drawing.Color

    Dim strHeaderRow As String

    Dim pageNum As Integer
    Dim boolPrintingNextPage As Boolean
    Dim itm As Integer

    Dim Y As Integer
    Dim boolDrawHorizontalLines As Boolean

    Dim fntFooterFont As System.Drawing.Font
    Dim intArrayCount As Integer


    Dim Match As System.Text.RegularExpressions.MatchCollection

    Public Property intPrintRecordsCount() As Integer
        ' number of records that are being sent for printing
        Get
            Return intArrayCount
        End Get
        Set(ByVal Value As Integer)
            intArrayCount = Value
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

    Public Property strFooterCaption() As String
        ' Allows the user to print page footer
        Get
            Return strFooter
        End Get
        Set(ByVal Value As String)
            strFooter = Value
        End Set
    End Property

    Public Property HeaderRow() As String
        ' Allows the user to print page footer
        Get
            Return strHeaderRow
        End Get
        Set(ByVal Value As String)
            strHeaderRow = Value
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

    Public Property TitleColor() As Drawing.Color
        'if grid lines will be printed, the grid color property is obtained here. Default is black
        Get
            Return clrTitleColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrTitleColor = Value
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

    Public Property GridColor() As Drawing.Color
        'if grid lines will be printed, the grid color property is obtained here. Default is black
        Get
            Return clrGridColor
        End Get
        Set(ByVal Value As Drawing.Color)
            clrGridColor = Value
        End Set
    End Property

    Protected Overrides Sub OnBeginPrint(ByVal ev As Drawing.Printing.PrintEventArgs)

        ' Run base code
        MyBase.OnBeginPrint(ev)

        ' Sets the default font
        If fntTitleFont Is Nothing Then
            fntTitleFont = New Drawing.Font("Arial", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
        End If

        If fntFooterFont Is Nothing Then
            fntFooterFont = New Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
        End If

        itm = 0

        Match = Regex.Matches(Data, "<row\b[^>]*>(.*?)</row>")
        intArrayCount = Match.Count

        'get the print record array
        pageNum = 0
        boolPrintingNextPage = False

    End Sub

    Protected Overrides Sub OnPrintPage(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        MyBase.OnPrintPage(e)

        '
        'Declare the pen color for use now nd in future 
        '

        Dim myPen As System.Drawing.Pen
        Dim myBrush As System.Drawing.Brush

        '
        'THIS IS USER CODE FOR PAGE NUMBERS
        '

        intLineCounter = 1

        Dim intHorizontalLineLength As Integer = DefaultPageSettings.PaperSize.Width - 200

        Dim grdCurrent As Graphics = e.Graphics
        Dim recCurrent As Rectangle
        Dim sbCurrent As SolidBrush

        '
        'Print the report header.
        '

        myBrush = New SolidBrush(clrTitleColor)
        e.Graphics.DrawString(strMainHeader1, fntTitleFont, myBrush, intTitleXposition, intTitleYposition + 40)
        e.Graphics.DrawString(strMainHeader2, fntTitleFont, myBrush, intTitleXposition, intTitleYposition + 55)
        e.Graphics.DrawString(strMainHeader3, fntTitleFont, myBrush, intTitleXposition, intTitleYposition + 70)

        Dim cols, lines As Integer
        Dim intLongestHeight As Integer = 0
        Dim strLongestText As String
        Dim intLongestWidth As Integer = 0
        Dim Yc As Integer = 0

        '
        'Increament the value of y by 30
        '
        Y = Me.DefaultPageSettings.Margins.Top + 100
        Y = intTitleYposition + 70 + 20

        'Print the header row
        If Not String.IsNullOrEmpty(HeaderRow) Then
            Dim HeaderMatch As System.Text.RegularExpressions.MatchCollection = Regex.Matches(HeaderRow, "<header\b[^>]*>(.*?)</header>")
            Dim strHeaderData() As String = New String(HeaderMatch.Count) {}

            Dim strFontName As String = "Arial"
            Dim intFontSize As Integer = 8
            Dim strForeColor As String = "Black"
            Dim boolFontBold As Boolean = False
            Dim boolFontItalic As Boolean = False
            Dim boolFontUnderline As Boolean = False
            Dim strBackColor As String = "White"
            Dim intAlignment As Integer = 0
            Dim strText As String = Nothing
            Dim intX As Integer = 0
            Dim intCellWidth As Integer = 100
            Dim intCellHeight As Integer = 15

            For p As Integer = 0 To HeaderMatch.Count - 1
                strHeaderData(p) = HeaderMatch(p).Groups(1).Value
                Dim strBuffer() As String = Split(strHeaderData(p), ";")

                '** LOOP THRU THE DATA PROPERTIES ***

                For z As Integer = 0 To strBuffer.Length - 1
                    Dim strSplitActualValues() As String = Split(strBuffer(z), "=")
                    Select Case UCase(strSplitActualValues(0))
                        Case Is = "FN" 'Font name
                            strFontName = strSplitActualValues(1)
                        Case Is = "FS" 'Font size
                            intFontSize = CInt(strSplitActualValues(1))
                        Case Is = "FC" 'Fore color
                            strForeColor = strSplitActualValues(1)
                        Case Is = "FB" 'Font style bold
                            boolFontBold = strSplitActualValues(1)
                        Case Is = "FI" 'Font style italic
                            boolFontItalic = strSplitActualValues(1)
                        Case Is = "FU" 'font style underline
                            boolFontUnderline = strSplitActualValues(1)
                        Case Is = "BC" 'Back groud fill color
                            strBackColor = strSplitActualValues(1)
                        Case Is = "AL" 'Alignment 0=left; 1=center an 2=right
                            intAlignment = CInt(strSplitActualValues(1))
                        Case Is = "TEXT"
                            strText = strSplitActualValues(1)
                        Case Is = "CW"
                            intCellWidth = CInt(strSplitActualValues(1))
                        Case Is = "X"
                            If IsNumeric(strSplitActualValues(1)) Then
                                intX = CInt(strSplitActualValues(1))
                            End If
                        Case Is = "CH"
                            If IsNumeric(strSplitActualValues(1)) Then
                                intCellHeight = CInt(strSplitActualValues(1))
                            End If
                    End Select

                Next

                'Determine the cell height
                Dim fnt As New Font(strFontName, intFontSize)

                'Determine the cell height
                e.Graphics.MeasureString(strText, fnt, New SizeF(intCellWidth, 80), New StringFormat(), cols, lines)
                intCellHeight = Y + lines * (fnt.Height + 1)
                If intCellHeight > intLongestHeight Then
                    intLongestHeight = intCellHeight
                    fntLongest = fnt
                    strLongestText = strText
                    intLongestWidth = intCellWidth
                End If

                'Write details here
                Select Case intAlignment
                    Case Is = "0"
                        Call DrawStringInBoxLeft(e, intX, Y, intCellWidth, intCellHeight, strText, strFontName, intFontSize, strForeColor, boolFontBold, boolFontItalic, boolFontUnderline, strBackColor)
                    Case Is = "1"
                        Call DrawStringInBoxCenter(e, intX, Y, intCellWidth, intCellHeight, strText, strFontName, intFontSize, strForeColor, boolFontBold, boolFontItalic, boolFontUnderline, strBackColor)
                    Case Is = "2"
                        Call DrawStringInBoxRight(e, intX, Y, intCellWidth, intCellHeight, strText, strFontName, intFontSize, strForeColor, boolFontBold, boolFontItalic, boolFontUnderline, strBackColor)
                    Case Else 'Align left
                        Call DrawStringInBoxLeft(e, intX, Y, intCellWidth, intCellHeight, strText, strFontName, intFontSize, strForeColor, boolFontBold, boolFontItalic, boolFontUnderline, strBackColor)
                End Select

            Next
            Y = Y + 25
        End If


        '
        'If the drawborder value is set then draw the border 
        '
        If boolDrawBorder = True Then
            myPen = New Pen(clrGridColor)
            With Me.DefaultPageSettings
                recCurrent = New Rectangle(.Margins.Left, .Margins.Top, (intHorizontalLineLength), e.PageBounds.Height - (.Margins.Bottom + .Margins.Top))
                e.Graphics.DrawRectangle(myPen, rect:=recCurrent)
            End With
        End If

        '
        'Also print the page footed along the same line.
        '*** Get the footer color ****
        '
        myBrush = New SolidBrush(clrFooterColor)
        e.Graphics.DrawString(UCase(strFooter) & "  " & Now.ToShortDateString, fntFooterFont, myBrush, intFooterXposition, e.PageBounds.Bottom - 50)
        e.Graphics.DrawString("PAGE " & pageNum + 1, fntFooterFont, myBrush, intPageNumXposition, e.PageBounds.Bottom - 50)

        Dim strLineData() As String = New String(Match.Count) {}

        While itm < intArrayCount

            strLineData(itm) = Match(itm).Groups(1).Value ' (Index 1 is the first group)

            Dim strFontName As String = "Arial"
            Dim intFontSize As Integer = 8
            Dim strForeColor As String = "Black"
            Dim boolFontBold As Boolean = False
            Dim boolFontItalic As Boolean = False
            Dim boolFontUnderline As Boolean = False
            Dim strBackColor As String = "White"
            Dim intAlignment As Integer = 0
            Dim strText As String = Nothing
            Dim intX As Integer = 0
            Dim intYposition As Integer
            Dim intCellWidth As Integer = 100
            Dim intCellHeight As Integer = 15

            Dim innerMatch As System.Text.RegularExpressions.MatchCollection = Regex.Matches(strLineData(itm), "<data\b[^>]*>(.*?)</data>")
            Dim strInnerData() As String = New String(innerMatch.Count) {}

            '** LOOP THROU THE ROW ITEMS ***
            '

            intLongestHeight = 0
            strLongestText = Nothing
            intLongestWidth = 0
            Dim strLogoPath As String = Nothing
            Dim boolIsImage As Boolean = False

            For p As Integer = 0 To innerMatch.Count - 1

                strInnerData(p) = innerMatch(p).Groups(1).Value

                Dim strBuffer() As String = Split(strInnerData(p), ";")

                boolIsImage = False

                '** LOOP THRU THE DATA PROPERTIES ***

                For z As Integer = 0 To strBuffer.Length - 1
                    Dim strSplitActualValues() As String = Split(strBuffer(z), "=")
                    Select Case UCase(strSplitActualValues(0))
                        Case Is = "FN" 'Font name
                            strFontName = strSplitActualValues(1)
                        Case Is = "FS" 'Font size
                            intFontSize = CInt(strSplitActualValues(1))
                        Case Is = "FC" 'Fore color
                            strForeColor = strSplitActualValues(1)
                        Case Is = "FB" 'Font style bold
                            boolFontBold = strSplitActualValues(1)
                        Case Is = "FI" 'Font style italic
                            boolFontItalic = strSplitActualValues(1)
                        Case Is = "FU" 'font style underline
                            boolFontUnderline = strSplitActualValues(1)
                        Case Is = "BC" 'Back groud fill color
                            strBackColor = strSplitActualValues(1)
                        Case Is = "AL" 'Alignment 0=left; 1=center an 2=right
                            intAlignment = CInt(strSplitActualValues(1))
                        Case Is = "TEXT"
                            strText = strSplitActualValues(1)
                        Case Is = "IMAGE"
                            strLogoPath = strSplitActualValues(1)
                            boolIsImage = True
                        Case Is = "CW"
                            intCellWidth = CInt(strSplitActualValues(1))
                        Case Is = "X"
                            If IsNumeric(strSplitActualValues(1)) Then
                                intX = CInt(strSplitActualValues(1))
                            End If
                        Case Is = "Y"
                            If IsNumeric(strSplitActualValues(1)) Then
                                intYposition = CInt(strSplitActualValues(1))
                            End If
                        Case Is = "CH"
                            If IsNumeric(strSplitActualValues(1)) Then
                                intCellHeight = CInt(strSplitActualValues(1))
                            End If
                    End Select

                Next

                If boolIsImage = True Then
                    If System.IO.File.Exists(strLogoPath) Then
                        Dim R As Drawing.Rectangle
                        Dim objPicture As New Windows.Forms.PictureBox
                        objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                        objPicture.Load(strLogoPath)
                        Dim intImageYLocation As Double = objPicture.Height
                        intImageYLocation = (100 - intImageYLocation) / 2
                        R = New Rectangle(intX, intYposition, objPicture.Width, objPicture.Height)
                        e.Graphics.DrawImage(objPicture.Image, R)
                    End If
                Else

                    'Determine the cell height
                    Dim fnt As New Font(strFontName, intFontSize)

                    'Determine the cell height
                    e.Graphics.MeasureString(strText, fnt, New SizeF(intCellWidth, 80), New StringFormat(), cols, lines)
                    intCellHeight = Y + lines * (fnt.Height + 1)
                    If intCellHeight > intLongestHeight Then
                        intLongestHeight = intCellHeight
                        fntLongest = fnt
                        strLongestText = strText
                        intLongestWidth = intCellWidth
                    End If

                    'Write details here
                    Select Case intAlignment
                        Case Is = "0"
                            Call DrawStringInBoxLeft(e, intX, Y, intCellWidth, intCellHeight, strText, strFontName, intFontSize, strForeColor, boolFontBold, boolFontItalic, boolFontUnderline, strBackColor)
                        Case Is = "1"
                            Call DrawStringInBoxCenter(e, intX, Y, intCellWidth, intCellHeight, strText, strFontName, intFontSize, strForeColor, boolFontBold, boolFontItalic, boolFontUnderline, strBackColor)
                        Case Is = "2"
                            Call DrawStringInBoxRight(e, intX, Y, intCellWidth, intCellHeight, strText, strFontName, intFontSize, strForeColor, boolFontBold, boolFontItalic, boolFontUnderline, strBackColor)
                        Case Else 'Align left
                            Call DrawStringInBoxLeft(e, intX, Y, intCellWidth, intCellHeight, strText, strFontName, intFontSize, strForeColor, boolFontBold, boolFontItalic, boolFontUnderline, strBackColor)
                    End Select

                End If

            Next

            'Get the value of y based on the tallest height
            e.Graphics.MeasureString(strLongestText, fntLongest, New SizeF(intLongestWidth, 80), New StringFormat(), cols, lines)
            Yc = Y
            Y = Y + lines * (fntLongest.Height + 1)
            Y = Math.Max(Y, Yc)

            With Me.DefaultPageSettings
                'page header and the page footer
                Dim pageHeight As Integer = 0
                If Me.DefaultPageSettings.Landscape = True Then
                    pageHeight = Me.DefaultPageSettings.PaperSize.Width
                Else
                    pageHeight = Me.DefaultPageSettings.PaperSize.Height
                End If
                If Y > 0.9 * (pageHeight - (110)) Then '.Margins.Bottom
                    'User code inserted to monitor page counts
                    pageNum = pageNum + 1

                    'Continue with general code
                    e.HasMorePages = True
                    itm = itm + 1
                    Exit Sub
                Else
                    If boolDrawHorizontalLines = True Then
                        With Me.DefaultPageSettings
                            myPen = New System.Drawing.Pen(clrGridColor)
                            e.Graphics.DrawLine(myPen, .Margins.Left, Y, intHorizontalLineLength + 100, Y)
                        End With
                        Y = Y + 4
                    End If
                    itm = itm + 1
                End If
            End With

        End While


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
