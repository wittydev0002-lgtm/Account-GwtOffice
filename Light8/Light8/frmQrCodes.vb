Imports System.Drawing.Printing
Imports QRCoder

Public Class frmQrCodes
    Private Sub frmQrCodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAvailablePrinters()
    End Sub

    Private Sub LoadAvailablePrinters()
        Try
            cmbPrinters.Items.Clear()
            For Each printer As String In PrinterSettings.InstalledPrinters
                cmbPrinters.Items.Add(printer)
            Next

            If cmbPrinters.Items.Count > 0 Then
                cmbPrinters.SelectedIndex = 0
                lblStatus.Text = $"Found {cmbPrinters.Items.Count} printer(s)"
            Else
                lblStatus.Text = "No printers found"
            End If
        Catch ex As Exception
            lblStatus.Text = $"Error loading printers: {ex.Message}"
        End Try
    End Sub

    Private Sub btnSelectPrinter_Click(sender As Object, e As EventArgs) Handles btnSelectPrinter.Click
        LoadAvailablePrinters()
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Try
            If String.IsNullOrEmpty(txtData.Text) Then
                MessageBox.Show("Please enter data for QR code", "Warning",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Generate QR Code preview
            Using qrGenerator As New QRCoder.QRCodeGenerator()
                Using qrCodeData As QRCoder.QRCodeData = qrGenerator.CreateQrCode(txtData.Text, QRCoder.QRCodeGenerator.ECCLevel.Q)
                    Using qrCode As New QRCoder.QRCode(qrCodeData)
                        picQRPreview.Image = qrCode.GetGraphic(20, Color.Black, Color.White, 4)
                        lblStatus.Text = "QR Code generated successfully"
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error generating QR Code: {ex.Message}", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.Text = $"Error: {ex.Message}"
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            ' Validate inputs
            If String.IsNullOrEmpty(txtData.Text) Then
                MessageBox.Show("Please enter data for QR code", "Warning",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If cmbPrinters.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a printer", "Warning",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Disable button during printing
            btnPrint.Enabled = False
            lblStatus.Text = "Printing..."
            Me.Refresh()

            ' Create printer instance
            Dim selectedPrinter As String = cmbPrinters.SelectedItem.ToString()
            Dim printer As New QRCodePrinter(selectedPrinter)

            ' Print QR Code
            Dim labelText As String = If(String.IsNullOrEmpty(txtLabel.Text), "", txtLabel.Text)

            printer.GenerateAndPrintQRCode(
                data:=txtData.Text,
                pixelsPerModule:=20,
                quietZoneModules:=4,
                labelText:=labelText,
                paperWidthMm:=58,  ' 58mm standard thermal paper
                printCopies:=1
            )

            lblStatus.Text = "✅ QR Code printed successfully!"
            MessageBox.Show("QR Code printed successfully!", "Success",
                           MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            lblStatus.Text = $"❌ Error: {ex.Message}"
            MessageBox.Show($"Printing error: {ex.Message}", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnPrint.Enabled = True
        End Try
    End Sub

    'Private Sub PrintQRCodeExample()
    '    Try
    '        Dim printer As New QRCodePrinter("POS-58(Copy 1)")
    '        printer.GenerateAndPrintQRCode(
    '            "https://www.example.com",
    '            20, ' Pixels per module
    '            4,  ' Quiet zone
    '            "Scan me!",
    '            58, ' Paper width in mm
    '            1   ' Copies
    '        )
    '    Catch ex As Exception
    '        MessageBox.Show($"Error: {ex.Message}")
    '    End Try
    'End Sub

    '' ESC/POS direct printing
    'Private Sub PrintQRCodeESC_POS_Example()
    '    Try
    '        Dim printer As New ThermalPrinterESC_POS()
    '        printer.PrintQRCodeESC_POS(
    '            "https://www.example.com",
    '            "Your Thermal Printer Name",
    '            6,  ' Size (1-8)
    '            "M" ' Error correction level
    '        )
    '    Catch ex As Exception
    '        MessageBox.Show($"Error: {ex.Message}")
    '    End Try
    'End Sub

End Class