Imports System.Text.RegularExpressions
Imports System.Drawing

Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim strData As String = "<row><data>Text=Embassy;X=100;Y=15;FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;CH=20;AL=0;CW=200</data></row>"

        'Dim s As String = "<data>Hello world</data><data>Test 2</data>"
        Dim match As System.Text.RegularExpressions.MatchCollection = Regex.Matches(strData, "<row\b[^>]*>(.*?)</row>")

        Dim strLineData() As String = New String(match.Count) {}

        For i As Integer = 0 To match.Count - 1 'Step i + 1
            strLineData(i) = match(i).Groups(1).Value ' (Index 1 is the first group)

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

            Dim innerMatch As System.Text.RegularExpressions.MatchCollection = Regex.Matches(strLineData(i), "<data\b[^>]*>(.*?)</data>")
            Dim strInnerData() As String = New String(innerMatch.Count) {}

            For p As Integer = 0 To innerMatch.Count - 1

                strInnerData(p) = innerMatch(p).Groups(1).Value

                Dim strBuffer() As String = Split(strInnerData(p), ";")

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

                    'Determine the cell height
                    Dim fnt As New Font(strFontName, intFontSize)

                Next


            Next
        Next

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

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim rp As New SmartRichReportWriter.RichReportWriter
        With rp
            .strMainHeader1 = "Header 1"
            .strMainHeader2 = "Header 2"
            .strMainHeader3 = "Header 3"
            .intTitleXposition = 250
            .Data = "<row><data>text=Embassy;X=100;Y=15;FN=Arial;FS=6;FC=red;FB=False;FI=False;FU=False;BC=White;CH=20;AL=0;CW=200</data></row>"
            .boolDrawBorder = True
        End With
        Dim ppd As New PrintPreviewDialog
        ppd.Document = rp
        ppd.ShowDialog()

    End Sub
End Class
