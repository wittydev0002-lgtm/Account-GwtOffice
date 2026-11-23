Imports System
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.IO
Imports System.Runtime.InteropServices
Imports QRCoder


Public Class QRCodePrinter

    Private _printerName As String
    Private _qrImage As Image
    Private _companyName As String
    Private _printData As ArrayList
    Private _logoPath As String = Nothing

    Public Sub New(Optional ByVal printerName As String = "",
                   Optional ByVal companyName As String = "",
                   Optional ByVal logoPath As String = Nothing,
                   Optional ByVal printData As ArrayList = Nothing)
        _printerName = printerName
        _companyName = companyName
        _printData = printData
        _logoPath = logoPath
    End Sub

    ''' <summary>
    ''' Generate QR Code and print to POS thermal printer
    ''' </summary>
    Public Sub GenerateAndPrintQRCode(ByVal data As String,
                                      Optional ByVal pixelsPerModule As Integer = 20,
                                      Optional ByVal quietZoneModules As Integer = 4,
                                      Optional ByVal labelText As String = "",
                                      Optional ByVal paperWidthMm As Integer = 58,
                                      Optional ByVal printCopies As Integer = 1)
        Try
            ' Generate QR Code
            _qrImage = GenerateQRCode(data, pixelsPerModule, quietZoneModules)

            ' Print the QR Code
            PrintQRCode(labelText, paperWidthMm, printCopies)

        Catch ex As Exception
            Throw New Exception($"Error generating/printing QR code: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Generate QR Code image
    ''' </summary>
    Private Function GenerateQRCode(ByVal data As String,
                                    ByVal pixelsPerModule As Integer,
                                    ByVal quietZoneModules As Integer) As Image
        Try
            Using qrGenerator As New QRCodeGenerator()
                Using qrCodeData As QRCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q)
                    Using qrCode As New QRCode(qrCodeData)
                        ' Generate bitmap with specified settings
                        Dim bitmap As Bitmap = qrCode.GetGraphic(pixelsPerModule,
                                                                 Color.Black,
                                                                 Color.White,
                                                                 quietZoneModules)
                        Return bitmap
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception($"QR Code generation failed: {ex.Message}")
        End Try
    End Function

    ''' <summary>
    ''' Print QR Code to thermal printer
    ''' </summary>
    Private Sub PrintQRCode(ByVal labelText As String,
                            ByVal paperWidthMm As Integer,
                            ByVal printCopies As Integer)
        Try
            Dim printDoc As New PrintDocument()

            ' Set printer name
            If Not String.IsNullOrEmpty(_printerName) Then
                printDoc.PrinterSettings.PrinterName = _printerName
            End If

            ' Default printer if not specified
            If String.IsNullOrEmpty(printDoc.PrinterSettings.PrinterName) Then
                printDoc.PrinterSettings.PrinterName = GetDefaultPrinter()
            End If

            ' Set print settings for thermal printer
            printDoc.DefaultPageSettings.Landscape = False
            printDoc.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
            printDoc.DefaultPageSettings.PaperSize = New PaperSize("Thermal", 200, 400)

            ' Handle print event
            AddHandler printDoc.PrintPage, Sub(sender, e) PrintPageHandler(sender, e, labelText, paperWidthMm)

            ' Print with specified copies
            If printCopies > 1 Then
                printDoc.PrinterSettings.Copies = CShort(printCopies)
            End If

            printDoc.Print()

        Catch ex As Exception
            Throw New Exception($"Printing failed: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Print page event handler
    ''' </summary>
    Private Sub PrintPageHandler(ByVal sender As Object,
                                  ByVal e As PrintPageEventArgs,
                                  ByVal labelText As String,
                                  ByVal paperWidthMm As Integer)

        Dim receiptData As New ArrayList
        receiptData = _printData

        Try
            If _qrImage Is Nothing Then
                Throw New Exception("No QR code image to print")
            End If

            Dim g As Graphics = e.Graphics
            g.PageUnit = GraphicsUnit.Pixel

            ' Calculate print size (for 58mm paper, printable width ~48mm)
            Dim dpiX As Single = g.DpiX
            Dim printableWidth As Single = (paperWidthMm - 5) / 25.4F * dpiX ' 5mm margin
            Dim imageWidth As Single = _qrImage.Width
            Dim imageHeight As Single = _qrImage.Height

            ' Scale image to fit paper width
            Dim scaleFactor As Single = printableWidth / imageWidth
            Dim printWidth As Integer = CInt(imageWidth * scaleFactor)
            Dim printHeight As Integer = CInt(imageHeight * scaleFactor)

            ' Center horizontally
            Dim x As Single = (g.DpiX * 80 / 25.4F - printWidth) / 2
            Dim y As Single = 10


            ' print receipt data first
            '

            Dim logoPath As String = _logoPath
            Dim companyName As String = _companyName

            If Not Object.Equals(receiptData, Nothing) Then
                If Not String.IsNullOrEmpty(logoPath) Then
                    If System.IO.File.Exists(logoPath) Then
                        'Dont print the company name as it is taken care of by the logo
                        companyName = ""
                        Dim R As Drawing.Rectangle
                        Dim objPicture As New Windows.Forms.PictureBox
                        objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                        objPicture.Load(logoPath)
                        R = New Rectangle(x, y, objPicture.Width, objPicture.Height)
                        e.Graphics.DrawImage(objPicture.Image, R)
                        y = y + objPicture.Height
                    End If
                End If

                y = y + 15

                Using font As New Font("Arial", 8, FontStyle.Regular)
                    Dim textX As Single = 10 '(g.DpiX * 58 / 25.4F - textSize.Width) / 2
                    For i As Integer = 0 To receiptData.Count - 1
                        Dim textSize As SizeF = g.MeasureString(receiptData.Item(i), font)
                        g.DrawString(receiptData.Item(i).ToString, font, Brushes.Black, textX, y)
                        y += textSize.Height + 5
                    Next
                End Using

            End If


            'If i = 0 Then
            '        Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, arrPrintDetails.Item(i), tlFont, Brushes.Black)
            '    Else
            '        Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, arrPrintDetails.Item(i), prFont, Brushes.Black)
            '    End If
            '    y = y + 15


            ' End Receipt Data print














            '' Draw label text if provided
            'If Not String.IsNullOrEmpty(labelText) Then
            '    Using font As New Font("Arial", 10, FontStyle.Bold)
            '        Dim textSize As SizeF = g.MeasureString(labelText, font)
            '        Dim textX As Single = (g.DpiX * 58 / 25.4F - textSize.Width) / 2
            '        g.DrawString(labelText, font, Brushes.Black, textX, y)
            '        y += textSize.Height + 5
            '    End Using
            'End If

            ' Draw QR Code
            Dim destRect As New Rectangle(CInt(x), CInt(y - 100), CInt(printWidth * 0.75), CInt(printHeight * 0.75))
            g.DrawImage(_qrImage, destRect)

            ''' Add some bottom margin
            ''y += printHeight + 20

            ''' Add additional text (optional)
            ''Using font As New Font("Consolas", 8)
            ''    Dim footerText As String = UCase(companyName)
            ''    Dim footerSize As SizeF = g.MeasureString(footerText, font)
            ''    Dim footerX As Single = (g.DpiX * 58 / 25.4F - footerSize.Width) / 2
            ''    g.DrawString(footerText, font, Brushes.Black, footerX, y)
            ''End Using

            e.HasMorePages = False

        Catch ex As Exception
            Throw New Exception($"Print page error: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Get default printer name
    ''' </summary>
    Private Function GetDefaultPrinter() As String
        Try
            Dim printDoc As New PrintDocument()
            Return printDoc.PrinterSettings.PrinterName
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Get list of available printers
    ''' </summary>
    Public Function GetAvailablePrinters() As List(Of String)
        Dim printers As New List(Of String)()
        Try
            For Each printer As String In PrinterSettings.InstalledPrinters
                printers.Add(printer)
            Next
        Catch ex As Exception
            ' Handle error
        End Try
        Return printers
    End Function
End Class