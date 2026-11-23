Imports EltradeFPAx
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class frmPosTest
    Private Sub frmPosTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSerialPortNames()
    End Sub

    Private Sub GetSerialPortNames()
        cboComPort.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cboComPort.Items.Add(sp)
        Next
        Exit Sub
    End Sub

    Private Function FiscalReceiptPrint(ByVal CommPort As Integer) As Boolean

        'Dim boolReturn As Boolean = False

        'lblResult.ForeColor = System.Drawing.Color.Black
        'lblResult.Text = "..."

        'lblResult1.Text = ""

        'Dim efp As New EltradeFPAx.EltradeFprn
        'Dim res As Integer = efp.Init(CommPort, 115200, 0, 0, 0, Nothing)

        'If res > 0 Then
        '    lblResult.Text = efp.GetErrCodeText(res, 1)
        '    lblResult.ForeColor = Color.Red
        '    lblResult1.Text = efp.GetLastError(1)
        '    lblResult1.ForeColor = Color.Red
        'Else
        '    efp.GenerateLogFile = 1
        '    efp.LogFilePath = Application.StartupPath
        '    res = efp.StartBon(1, 1, "Cashier 1", "9000000001", "123456789", "BG123456789", "Company Name", "City", "Address", "MOL", "Receiver")

        '    'res = efp.StartBon(2, 0, UCase(strPublicActiveFullUserName), CStr(gwt_comm.GetNextDocumentNumber("CashSales")),
        '    '                 strTaxNumber, strCompanyVatNumber, UCase(strCompanyName), "HARARE",
        '    '                        "7 GEORGE SILUNDIKA AVE, KUWIRIRANA HSE", "MRP", "Recipient")

        '    If res > 0 Then
        '        lblResult.Text = efp.GetErrCodeText(res, 1)
        '        lblResult.ForeColor = Color.Red
        '        lblResult1.Text = efp.GetLastError(1)
        '        lblResult1.ForeColor = Color.Red
        '    Else
        '        res = efp.AddLine(" ", "", 1)
        '        If res = 0 Then res = efp.AddLine("Free text at the top of receipt,", "", 1)
        '        If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '        If (res = 0) Then res = efp.AddLine("Dbwidth sample", "DBWIDTH", 1)
        '        If (res = 0) Then res = efp.AddLine("Dbstrike sample", "DBSTRIKE", 1)
        '        If (res = 0) Then res = efp.AddLine("Underline sample", "UNDERLINE", 1)
        '        If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '        If (res = 0) Then res = efp.AddLine("Sample PLU with percentage add on", "", 1)
        '        If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '        If (res = 0) Then res = efp.AddPLU("1", "PLU number 1", 1.23, 1, 1)
        '        If (res = 0) Then res = efp.AddDiscount(1, 10.0)
        '        If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '        If (res = 0) Then res = efp.AddPLU("2", "PLU number 2", 2.34, 2.25, 2)
        '        If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '        If (res = 0) Then res = efp.AddPLU("3", "PLU number 3", 3.45, 5, 2)
        '        If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '        If (res = 0) Then res = efp.AddLine("Sample of PLU refund", "", 1)
        '        If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '        If (res = 0) Then res = efp.AddPLU("4", "PLU number 4", 1.55, -1, 2)
        '        If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '        If (res = 0) Then res = efp.AddLine("Sample of STL discount", "", 1)
        '        If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '        If (res = 0) Then res = efp.AddDiscount(2, -10.0)
        '        If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '        If (res = 0) Then res = efp.AddLine("Free text at the end of receipt.", "", 1)
        '        If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '        If (res = 0) Then res = efp.AddPayment(2, "CARD", 2, 1)
        '        If (res = 0) Then res = efp.AddPayment(1, "CASH", 100, 1)
        '        If (res = 0) Then res = efp.EndBon()
        '        If res > 0 Then
        '            lblResult.Text = efp.GetErrCodeText(res, 1)
        '            lblResult.ForeColor = Color.Red
        '            lblResult1.Text = efp.GetLastError(1)
        '            lblResult1.ForeColor = Color.Red
        '        Else
        '            lblResult.Text = "Print test receipt -> OK (Receipt number: " & efp.GetLastBonNumber() & ""
        '            boolReturn = True
        '        End If

        '    End If
        'End If

        'efp.Close()

        'Return boolReturn
    End Function

    Private Function FiscalPrintBarcode(ByVal commPort As Integer) As Boolean
        'Dim boolReturn As Boolean = False

        'lblResult.Text = "..."
        'lblResult1.Text = Nothing
        'Dim efp As New EltradeFPAx.EltradeFprn
        'Dim res As Integer = efp.Init(commPort, 115200, 0, 0, 0, "")
        'efp.GenerateLogFile = 1
        'efp.LogFilePath = Application.StartupPath

        'If res > 0 Then
        '    lblResult.Text = efp.GetErrCodeText(res, 1)
        '    lblResult.ForeColor = Color.Red
        '    lblResult.Text = efp.GetLastError(1)
        '    lblResult1.ForeColor = Color.Red
        'Else
        '    res = efp.AddLine(" ", "", 1)
        '    If (res = 0) Then res = efp.AddLine("Barcode samples ...", "", 1)
        '    If (res = 0) Then res = efp.AddLine("EAN 13; Height:90 Hri:2", "", 1)
        '    If (res = 0) Then res = efp.AddBarcode(2, 90, 2, "123456789012")
        '    If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '    If (res = 0) Then res = efp.AddLine("EAN 8; Height:120 Hri:1", "", 1)
        '    If (res = 0) Then res = efp.AddBarcode(3, 120, 1, "1234567")
        '    If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '    If (res = 0) Then res = efp.AddLine("UPC A; Height:90 Hri:0", "", 1)
        '    If (res = 0) Then res = efp.AddBarcode(0, 90, 0, "123456789012")
        '    If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '    If (res = 0) Then res = efp.AddLine("CODE39; Height:90 Hri:3", "", 1)
        '    If (res = 0) Then res = efp.AddBarcode(4, 90, 3, "1ABCD3")
        '    If (res = 0) Then res = efp.AddLine(" ", "", 1)
        '    If (res = 0) Then res = efp.AddLine("CODE128; Height:90 Hri:2", "", 1)
        '    If (res = 0) Then res = efp.AddBarcode(8, 90, 2, "ABCDEFGHIJKLMNOPQRST")
        '    If (res = 0) Then res = efp.EndBon()

        '    If res > 0 Then
        '        lblResult.Text = efp.GetErrCodeText(res, 1)
        '        lblResult.ForeColor = Color.Red
        '        lblResult1.Text = efp.GetLastError(1)
        '        lblResult1.ForeColor = Color.Red
        '    Else
        '        lblResult.Text = "Print barcode recept -> OK (Recept number: " & efp.GetLastBonNumber() & ")"
        '        boolReturn = True
        '    End If
        'End If

        'efp.Close()

        'Return boolReturn

    End Function

    Private Sub btnPrinReceipt_Click(sender As Object, e As EventArgs) Handles btnPrinReceipt.Click
        If String.IsNullOrEmpty(cboComPort.Text) Then
            MessageBox.Show("Please setup or select the fiscal printer COM port",
                "Invalid Printer COM Port", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboComPort.Select()
        Else
            Dim comPortNumber As Integer = 0
            Dim strExtractNumber As String = Regex.Replace(Trim(cboComPort.Text), "\D", "")
            strExtractNumber = Trim(strExtractNumber)
            If IsNumeric(strExtractNumber) Then
                comPortNumber = CLng(strExtractNumber)
                Dim boolStatus As Boolean = FiscalReceiptPrint(comPortNumber)
            End If
        End If
    End Sub

End Class