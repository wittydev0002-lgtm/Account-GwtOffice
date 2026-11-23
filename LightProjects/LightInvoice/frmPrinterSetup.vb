Option Explicit On

Imports System.Drawing.Printing
Imports System.IO
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPrinterSetup

    Private msrStreamToPrint As StreamReader
    Private mftPrintFont As Font

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmPrinterSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListAvailablePrinters()
    End Sub

    Private Sub ListAvailablePrinters()
        'This method uses the InstalledPrinters collection to fill a ListBox control 
        'of all availables controls
        For Each strPrinterName As String In PrinterSettings.InstalledPrinters
            ListBox1.Items.Add(strPrinterName)
        Next

        'Find the Default printer
        Dim PD As New PrintDocument
        ListBox1.SelectedItem = PD.DefaultPageSettings.PrinterSettings.PrinterName
    End Sub


    Private Sub btnSetDefaultPrinter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not SetDefaultSystemPrinter3(ListBox1.SelectedItem) Then
            MessageBox.Show("Error occured will trying to set the default printer!")
        End If
    End Sub

#Region " --- Change Printer settings for the current application --- "

    ' The PrintPage event is raised for each page to be printed.
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        'This example comes from MSDN
        'http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpref/html/frlrfsystemdrawingprintingprintdocumentclassprintpagetopic.asp
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing

        ' Calculate the number of lines per page.
        linesPerPage = ev.MarginBounds.Height / mftPrintFont.GetHeight(ev.Graphics)

        ' Iterate over the file, printing each line.
        While count < linesPerPage
            line = msrStreamToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * mftPrintFont.GetHeight(ev.Graphics)
            ev.Graphics.DrawString(line, mftPrintFont, Brushes.Black, leftMargin, yPos, New StringFormat)
            count += 1
        End While

        ' If more lines exist, print another page.
        If Not (line Is Nothing) Then
            ev.HasMorePages = True
        Else
            ev.HasMorePages = False
        End If
    End Sub

    Private Sub btnTestPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestPrint.Click
        Try
            'open a stream to printer in pd_PrintPage
            msrStreamToPrint = New StreamReader(Application.StartupPath & "\test.txt")
            'Set a font that will be used in pd_PrintPage
            mftPrintFont = New Font("Verdana", 10)
            Try
                Dim pd As New PrintDocument
                AddHandler pd.PrintPage, AddressOf pd_PrintPage
                ' Specify the printer to use
                pd.PrinterSettings.PrinterName = ListBox1.SelectedItem
                ' Set the page orientation to landscape.
                pd.DefaultPageSettings.Landscape = True
                pd.Print()
            Finally
                msrStreamToPrint.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region ' --- change Printer settings for the current application --- 

#Region " --- Method 1 --- "

    Private Function SetDefaultSystemPrinter(ByVal strPrinterName As String) As Boolean
        'ref: http://www.planet-source-code.com/URLSEO/vb/scripts/ShowCode!asp/txtCodeId!3053/lngWid!10/anyname.htm

        ' Imports System.Drawing.Printing
        ' Example: SetDefaultSystemPrinter("Lexmark T620") - local printer
        ' Example: SetDefaultSystemPrinter("\\Server01\Lexmark T522") - network printer
        Dim strOldPrinter As String = Nothing
        Dim WshNetwork As Object = Nothing
        Dim pd As New PrintDocument

        ' Set the default system printer
        Try
            strOldPrinter = pd.PrinterSettings.PrinterName '/ Get the system default printer
            WshNetwork = Microsoft.VisualBasic.CreateObject("WScript.Network")
            WshNetwork.SetDefaultPrinter(strPrinterName)
            pd.PrinterSettings.PrinterName = strPrinterName '/ Specify the printer to use.
            If pd.PrinterSettings.IsValid Then '/ Check that the printer exists
                Return True
            Else
                'MessageBox.Show("Printer <" & strPrinterName & "> is invalid.")
                WshNetwork.SetDefaultPrinter(strOldPrinter)
                Return False
            End If
        Catch exptd As Exception
            WshNetwork.SetDefaultPrinter(strOldPrinter)
            Return False
        Finally
            WshNetwork = Nothing
            pd = Nothing
        End Try
    End Function '/ SetDefaultSystemPrinter

#End Region     ' --- Method 1 ---

#Region " --- Method 2 --- "

    'ref: http://www.dotnet4all.com/dotnet-code/2004/11/changing-printers-in-visual-basic.html
    'Requires a reference to System.Management

    Private Function SetDefaultSystemPrinter2(ByVal strPrinterName As String) As Boolean
        Dim moReturn As Management.ManagementObjectCollection
        Dim moSearch As Management.ManagementObjectSearcher
        Dim mo As Management.ManagementObject

        moSearch = New Management.ManagementObjectSearcher("Select * from Win32_Printer")
        moReturn = moSearch.Get

        For Each mo In moReturn
            Dim objReturn As Object = Nothing
            'Debug.WriteLine(mo("Name"))
            If mo("Name").ToString.Trim.ToUpper = strPrinterName.Trim.ToUpper Then
                mo.InvokeMethod("SetDefaultPrinter", objReturn)
                Return True
            End If
        Next
        Return False
    End Function

#End Region ' --- Method 2 ---

#Region " --- Method 3 --- "

    'ref: http://www.vbcity.com/forums/topic.asp?tid=70315

    Private Declare Function WriteProfileString Lib "kernel32" Alias "WriteProfileStringA" _
    (ByVal lpszSection As String, ByVal lpszKeyName As String, _
    ByVal lpszString As String) As Long
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
         (ByVal hwnd As Long, ByVal wMsg As Long, _
         ByVal wParam As Long, ByVal lparam As String) As Long
    Private Const HWND_BROADCAST As Long = &HFFFF&
    Private Const WM_WININICHANGE As Long = &H1A

    Private Function SetDefaultSystemPrinter3(ByVal strPrinterName As String) As Boolean
        'this method does not valid if the change is correct and does not revert to previous printer if wrong
        Dim DeviceLine As String

        'rebuild a valid device line string 
        DeviceLine = strPrinterName & ",,"

        'Store the new printer information in the 
        '[WINDOWS] section of the WIN.INI file for 
        'the DEVICE= item 
        Call WriteProfileString("windows", "Device", DeviceLine)

        'Cause all applications to reload the INI file 
        Call SendMessage(HWND_BROADCAST, WM_WININICHANGE, 0, "windows")

        Return True
    End Function

#End Region ' --- Method 3 ---

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If Not IsNumeric(txtComPort.Text) And
            optUsb.Checked = True Then
            MessageBox.Show("Please enter a numeric value for the COM Port", "Invalid COM Port Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtComPort.Focus()
            Exit Sub
        Else
            If optSerial.Checked = True Then
                txtComPort.Text = "0"
            End If
        End If

        ' Specify the printer to use
        strSessionPrinter = ListBox1.SelectedItem
        ' Set the page orientation to landscape.

        Dim strPrinterConnectionType As String = "SERIAL"
        Dim intPrinterComNo As Integer = CInt(txtComPort.Text)
        If optUsb.Checked = True Then strPrinterConnectionType = "USB"

        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM PrinterSettings", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO PrinterSettings (ConnectionType, ComPort) " _
            & "VALUES ('" & strPrinterConnectionType & "', " & intPrinterComNo & ")", cnn)
        objCommand.ExecuteNonQuery()
        'MessageBox.Show("Printer settings saved successfully", MsgBoxStyle.Information, "Printer Setup")
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On printer setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmPrinterSetup_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 394 : Me.Height = 450
    End Sub

End Class