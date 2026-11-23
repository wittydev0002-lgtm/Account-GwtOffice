Imports System.Net
Imports System.IO
Imports System.Text
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmWifiDashBoard

    Dim boolFormLoading As Boolean

    Dim strCloudAddress As String = Nothing
    Dim strftpCloudUserName As String = Nothing
    Dim strftpCloudPassword As String = Nothing
    Dim currentFilePath As String

    Dim boolProcessEnd As Boolean

    '#Region "Member Variables"

    '    Private netusers As New List(Of Netuser)    ' create a typed list of network users
    '    Private currentNetuser As Netuser         ' create a single netuser instance
    '    'Private currentPosition As Integer          ' used to hold current position
    '    Private currentFilePath As String           ' file path to current netuser file
    '    Private dirtyForm As Boolean                ' keep track of dirty forms

    '#End Region



    '#Region "Constructor"


    '    ''' <summary>
    '    ''' Constructor - create a new instance of
    '    ''' the contact list and setup the local
    '    ''' member variables
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public Sub New()

    '        ' This call is required by the Windows Form Designer.
    '        InitializeComponent()

    '        ' Add any initialization after the InitializeComponent() call.

    '        netusers = New List(Of Netuser)
    '        currentNetuser = New Netuser()
    '        netusers.Add(currentNetuser)
    '        'currentPosition = 0
    '        dirtyForm = False

    '    End Sub


    '#End Region

    Private Sub GetConnectionSettings()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ServerName, UserName, UserPassword FROM CloudSettings", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strCloudAddress = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strftpCloudUserName = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strftpCloudPassword = objReader(2).ToString
            btnPrint.Enabled = True
            btnIncomeAnalysis.Enabled = True
            btnGo.Enabled = True
            'DownLoadFileDetails(Application.StartupPath & "\NetData\voucher.txt", "SPEKE03_09.txt")
            'DownLoad()
        Else
            MessageBox.Show("The cloud connection settings have not been set. This process is disabled until you make the settings", _
                "Connection Settings", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnPrint.Enabled = False
            btnIncomeAnalysis.Enabled = False
            btnGo.Enabled = False
            boolProcessEnd = True
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On cloud connections settings"
        ShowErrorMessage()
    End Sub

    Private Sub btnSettings_Click(sender As System.Object, e As System.EventArgs) Handles btnSettings.Click
        Dim f As New frmWifiSettings
        f.ShowDialog()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Cursor = Cursors.WaitCursor
        boolAbort = False
        GetConnectionSettings()
        If boolProcessEnd = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If
        If boolAbort = True Then Exit Sub
        DownLoad()
        If boolAbort = True Then
            Exit Sub
        Else
            MessageBox.Show("File download completed successfully. 1 File Downloaded", _
                        "Online File Transmissions", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadFileDetails()
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
        boolAbort = True
    End Sub


    Private Sub DownLoad()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Timer1.Enabled = False
        ' Get the object used to communicate with the server.
        Dim request As FtpWebRequest = CType(WebRequest.Create("ftp://" & strCloudAddress & "financialLite1/voucher.txt"), FtpWebRequest)
        request.Method = WebRequestMethods.Ftp.DownloadFile

        ' This example assumes the FTP site uses anonymous logon.
        request.Credentials = New NetworkCredential(strftpCloudUserName, strftpCloudPassword)

        Dim response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)

        Dim responseStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(responseStream)
        Dim strData As String = reader.ReadToEnd()

        reader.Close()
        response.Close()

        'Write the details to the file

        Dim objFile As New StreamWriter(Application.StartupPath & "/NetData/voucher.txt", False)
        Dim strSplitter As String = "{ " & Chr(34) & "_id" & Chr(34) & " : {"   '{ "_id" : {
        Dim strDataLines() As String = Split(strData, strSplitter)
        With frmLight8.pb1
            .Value = 0
            .Maximum = strDataLines.Length
            .Visible = True
        End With
        For i As Integer = 0 To strDataLines.Length - 1
            objFile.WriteLine(strDataLines(i))
            frmLight8.pb1.Value = frmLight8.pb1.Value + 1
        Next
        objFile.Close()

        MessageBox.Show("Download Complete, status {0}" & vbCrLf & response.StatusDescription & vbCrLf & "Application will now format the data. Please wait ....", _
            "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        boolAbort = False
        'LoadFileDetails()
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        Timer1.Enabled = True
        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        Timer1.Enabled = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Wi-fi voucher file download"
        ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub frmWifiDashBoard_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        boolAbort = False
        ''currentFilePath = Application.StartupPath & "/WifiLog"
        ''CreateTempTable()
        boolProcessEnd = False
        GetConnectionSettings()
        If boolAbort = True Then Exit Sub
        'DownLoad()

        If boolProcessEnd = False Then Timer1.Enabled = True Else Timer1.Enabled = False
        If boolAbort = True Then Exit Sub
        LoadFileDetails()
        'OpenNetuserFile()
    End Sub

    Private Sub LoadFileDetails()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        'strCode, strSite, strDateAndTime, dblDuration, dblDataUsage, dblAmount
        With dGrid
            .Columns.Clear()
            .Columns.Add("Column1", "Voucher #")
            .Columns.Add("Column2", "Site ID")
            .Columns.Add("Column3", "Login Time")
            .Columns.Add("Column4", "Duration")
            .Columns.Add("Column5", "Usage")
            .Columns.Add("Column6", "Value")
            .Rows.Clear()
        End With

        Dim lngStart As Long = 1411824937

        If File.Exists(Application.StartupPath & "/NetData/voucher.txt") Then
            Dim objFileReader As New StreamReader(Application.StartupPath & "/NetData/voucher.txt")
            Dim strData As String = objFileReader.ReadToEnd
            objFileReader.Close()


            Dim dblTotalDataUsage As Double = 0
            Dim dlTotalAmountRemaining As Double = 0
            Dim dblTotalTime As Double = 0

            Dim strDetails() As String = Split(strData, vbCrLf)

            For i As Integer = 0 To strDetails.Length - 2
                If Not String.IsNullOrEmpty(strDetails(i)) Then
                    Dim arrRequiredData As New ArrayList
                    Dim strColumns() As String = Split(strDetails(i), ",")

                    Dim strCode As String = Nothing
                    Dim strSite As String = Nothing
                    Dim strDateAndTime As String = Nothing
                    Dim dblDuration As Double = 0
                    Dim dblDataUsage As Double = 0
                    Dim dblAmount As Double = 0

                    For p As Integer = 0 To strColumns.Length - 1
                        strColumns(p) = Replace(strColumns(p), "}", "", 1)
                        strColumns(p) = Replace(strColumns(p), Chr(34), "", 1)
                        Dim strFurtherSplit() As String = Split(strColumns(p), ":")

                        'strCode = Nothing : strSite = Nothing : strDateAndTime = Nothing : dblDuration = 0 : dblDataUsage = 0 : dblAmount = 0

                        Select Case UCase(Trim(strFurtherSplit(0)))
                            Case Is = UCase("site_id")
                                strSite = UCase(Trim(strFurtherSplit(1)))
                            Case Is = UCase("Code")
                                strCode = UCase(Trim(strFurtherSplit(1)))
                            Case Is = UCase("create_time")
                                strDateAndTime = UCase(Trim(strFurtherSplit(2)))
                                If IsNumeric(strDateAndTime) Then
                                    Dim myDate As System.DateTime
                                    myDate = New System.DateTime(1970, 1, 1, 0, 0, 0, 0)
                                    Dim dt As DateTime = myDate.AddSeconds(CLng(strDateAndTime))
                                    strDateAndTime = CStr(dt)
                                Else
                                    strDateAndTime = Nothing
                                End If
                            Case Is = UCase("duration")
                                If IsNumeric(UCase(Trim(strFurtherSplit(2)))) Then
                                    dblDuration = CDbl(UCase(Trim(strFurtherSplit(2))))
                                    dblTotalTime = dblTotalTime + dblDuration
                                End If
                            Case Is = UCase("used")
                                If IsNumeric(UCase(Trim(strFurtherSplit(1)))) Then
                                    dblDataUsage = CDbl(UCase(Trim(strFurtherSplit(1))))
                                    dblTotalDataUsage = dblTotalDataUsage + dblDataUsage
                                End If
                        End Select
                    Next

                    dGrid.Rows.Add(strCode, strSite, strDateAndTime, dblDuration, dblDataUsage, dblAmount)

                End If
            Next

            lblTotal.Text = Format(dGrid.Rows.Count, "#,##0.00")
            lblDataUsage.Text = Format(dblTotalDataUsage, "#,##0.00")
            lblTotalTimeUsed.Text = Format((dblTotalTime / (60 * 24)), "#,##0.00")

        End If

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Voucher File Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnFormatData_Click(sender As System.Object, e As System.EventArgs) Handles btnFormatData.Click
        LoadFileDetails()
    End Sub

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        LoadFilteredData(CDate(gwt_comm.shortMonthDateFormat(dpStartFrom.Value)), CDate(gwt_comm.shortMonthDateFormat(dpEndTo.Value)))
    End Sub

    Private Sub LoadFilteredData(StartingDate As Date, EndingDate As Date)
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT LoginDate, LoginTime, LogoutDate, LogoutTime, Voucher " _
            & "FROM TempNetusers WHERE LoginDate BETWEEN '" & StartingDate & "' AND " _
            & "'" & EndingDate & "' ORDER BY LoginDate"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            Dim dblDuration As Double = 0
            Dim strStartTime As String = CDate(gwt_comm.shortMonthDateFormat(CDate(objReader("LoginDate").ToString))) & " " & objReader("LoginTime").ToString
            Dim strEndTime As String = CDate(gwt_comm.shortMonthDateFormat(CDate(objReader("LogoutDate").ToString))) & " " & objReader("LogoutTime").ToString

            Dim strTempTime1 As String = Nothing
            Dim strTempTime2 As String = Nothing
            Dim strTime1 As String = Nothing
            Dim strTime2 As String = Nothing
            If CDate(strStartTime) > CDate(strEndTime) Then
                strTempTime1 = strStartTime
                strTempTime2 = strEndTime
                strTime2 = objReader("LoginTime").ToString
                strTime1 = objReader("LogoutTime").ToString
            Else
                strTempTime2 = strStartTime
                strTempTime1 = strEndTime
                strTime1 = objReader("LoginTime").ToString
                strTime2 = objReader("LogoutTime").ToString
            End If

            dblDuration = DateDiff(DateInterval.Minute, CDate(strTempTime2), CDate(strTempTime1))
            Dim dblCost As Double = (dblDuration * 1.5) / 100
            dGrid.Rows.Add(gwt_comm.shortMonthDateFormat(CDate(objReader(0).ToString)), strTime1,
                gwt_comm.shortMonthDateFormat(CDate(objReader(2).ToString)), strTime2, objReader(4), dblDuration, dblCost)
        End While
        objReader.Close()
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Voucher File Details Load"
        ShowErrorMessage()
    End Sub

    Public Sub CreateTempTable()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        'If temp crop table exists drop it
        Dim objCommand As New Data.OleDb.OleDbCommand("IF OBJECT_ID(N'TempNetusers', N'U') IS NOT NULL DROP TABLE TempNetusers", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("IF OBJECT_ID(N'TempNetusers', N'U') IS NULL CREATE TABLE TempNetusers " _
            & "([LoginDate][SmallDateTime] NULL, [LoginTime][NVARCHAR](20) NULL, [LogoutDate][SmallDateTime] NULL, " _
            & "[LogoutTime][NVARCHAR](20) NULL, [Voucher][NVARCHAR](20) NOT NULL)", cnn)
        objCommand.ExecuteNonQuery()
        Dim objFile As New StreamReader(currentFilePath)
        Dim strData As String = objFile.ReadToEnd
        objFile.Close()
        Dim strLines() As String = Split(strData, vbCrLf)
        With frmLight8.pb1
            .Value = 0
            .Maximum = strLines.Count
            .Visible = True
        End With
        For i As Integer = 0 To strLines.Length - 2
            Dim strFileds() As String = Split(strLines(i), "|")
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO TempNetusers " _
                & "(LoginDate, LoginTime, LogoutDate, LogoutTime, Voucher) VALUES " _
                & "('" & CDate(strFileds(0)) & "', '" & strFileds(1) & "', '" & CDate(strFileds(2)) & "', " _
                & "'" & strFileds(3) & "', '" & strFileds(4) & "')", cnn)
            objCommand.ExecuteNonQuery()
            frmLight8.pb1.Value = frmLight8.pb1.Value + 1
        Next
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Voucher File Details Load"
        ShowErrorMessage()
    End Sub


    'Private Sub LoadAllNetusers()
    '    Dim orderedCons = _
    '        (From netuser In netusers _
    '         Order By netuser.LoginDate Ascending, _
    '         netuser.LoginTime Ascending, _
    '         netuser.LogoutDate Ascending, _
    '         netuser.LogoutTime Ascending _
    '         Select netuser)

    '    ' create an instance of the full list form and pass it's
    '    ' constructor the list converted to a List
    '    Dim f As New frmFullList(orderedCons.ToList())
    '    f.Show()
    'End Sub

    'Private Sub OpenNetuserFile()
    '    ' deserialize file content into contacts 
    '    ' list to make it available to the application
    '    netusers = Serializer.Deserialize(currentFilePath)

    '    ' alphabetize the contact list
    '    ' by last, first, and middle name and
    '    ' push the results into a List<T>
    '    Dim orderedNetusers = _
    '                (From netuser In netusers _
    '                 Order By netuser.LoginDate Ascending, _
    '                  netuser.LoginTime Ascending, _
    '                  netuser.LoginDate Ascending _
    '                 Select netuser).ToList()

    '    ' set the network users list to the newly ordered list
    '    netusers = orderedNetusers

    '    ' Load network users

    '    For i As Integer = 0 To netusers.Count - 1
    '        currentNetuser = netusers.ElementAt(0)
    '        LoadCurrentContact()
    '    Next

    'End Sub

    'Private Sub LoadCurrentContact()
    '    ' update the form fields
    '    dGrid.Rows.Add(currentNetuser.LoginDate, currentNetuser.LoginTime, _
    '        currentNetuser.LogoutDate, currentNetuser.LogoutTime, currentNetuser.Voucher)
    'End Sub

    Private Sub btnGraphAnalysis_Click(sender As System.Object, e As System.EventArgs) Handles btnGraphAnalysis.Click
        Dim f As New frmWifiTrendAnalysis
        f.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        boolAbort = False

        On Error GoTo RaiseErr
        'Open a text file that contains the index of the last number
        If File.Exists(Application.StartupPath & "/Cellindex.txt") Then
            Dim objFileReader As New StreamReader(Application.StartupPath & "/Cellindex.txt")
            Dim strIndex As String = objFileReader.ReadLine
            objFileReader.Close()
            If IsNumeric(strIndex) Then
                intLastCellNumberIndex = CInt(strIndex)
            End If
        End If
        Dim strCell As String = DownLoadCellNumber()
        If boolAbort = True Then Exit Sub
        If Not String.IsNullOrEmpty(strCell) Then
            gwt_comm.SendWifiAutoSms(strCell)
            If boolAbort = True Then
                Exit Sub
            Else
                Dim objFilWriter As New StreamWriter(Application.StartupPath & "/Cellindex.txt", False)
                objFilWriter.WriteLine(intLastCellNumberIndex + 1)
                objFilWriter.Close()
            End If
        End If

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        'Write the message to the text file
        Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\AutoVouchererr.dat", True)
        objFileWriter.WriteLine(Err.Description & " error number " & Err.Number & " " & Now)
        objFileWriter.Close()
    End Sub

    Private Function DownLoadCellNumber() As String

        On Error GoTo RaiseErr
        Dim strErrorType As String = Nothing
        Dim CurrentCellNumber As String = Nothing

        ' Get the object used to communicate with the server.
        strErrorType = "  Connection to server activation"
        Dim x As String
        GetConnectionSettings()

        Dim request As FtpWebRequest = CType(WebRequest.Create("ftp://" & strCloudAddress & "public_html/page/resources/numbers.txt"), FtpWebRequest)
        request.Method = WebRequestMethods.Ftp.DownloadFile

        strErrorType = " File downloading"
        ' This example assumes the FTP site uses anonymous logon.
        request.Credentials = New NetworkCredential(strftpCloudUserName, strftpCloudPassword)
        Dim response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
        Dim responseStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(responseStream)
        Dim strData As String = reader.ReadToEnd()

        reader.Close()
        response.Close()

        strErrorType = "File read and cell number assignment"
        Dim strDataLines() As String = Split(strData, "+")
        CurrentCellNumber = "+" & strDataLines(intLastCellNumberIndex + 1)

        Return CurrentCellNumber

        Exit Function
RaiseErr:
        Cursor = Cursors.Default
        Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\AutoVouchererr.dat", True)
        objFileWriter.WriteLine(Err.Description & " error number " & Err.Number & strErrorType & " " & Now)
        objFileWriter.Close()
        boolAbort = True
    End Function

End Class
