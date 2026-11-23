Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPayrollUserReportsListing

    'declare the array that will hold the calculations
    Dim strPrintCalculations As New ArrayList
    'declare the array that will hold the values for headers
    Dim strPrintHeaders As String
    'declare the employee payfields obtained from the run file
    Dim strEmployeeFields As New ArrayList
    Dim strCurrentPrintEmployeeFields As New ArrayList
    Dim strSortedEmployeeDetails() As String
    Dim strTemp() As String
    Dim strPrintRecord As ArrayList
    Dim dblValues(0 To 249) As Double
    Dim strCalcBuffer() As String
    Dim dblColumnValues As New ArrayList
    Dim strRecordToPrint() As String

    Private Sub tsNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsNew.Click
        boolEditStatus = False
        Dim F As New frmReportWriter
        F.ShowDialog()
        'Refresh the form
        LoadFormDetails()
    End Sub

    Private Sub tsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsEdit.Click
        boolEditStatus = True
        'Get the selected row report number
        Dim CurrentCell As DataGridViewCell
        CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(0)
        intSelectedReport = CInt(CurrentCell.Value)
        Dim f As New frmReportWriter
        f.ShowDialog()
        boolEditStatus = False
        LoadFormDetails()
    End Sub

    Private Sub frmUserReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadFormDetails()
    End Sub

    Private Sub LoadFormDetails()
        On Error GoTo RaiseErr

        'Check the table existence and create it if it does not exist
        Dim sqlCreateTable As New Data.OleDb.OleDbCommand("IF OBJECT_ID(N'SystemColumnReportHeaders', N'U') IS NULL CREATE " _
             & "TABLE [SystemColumnReportHeaders]([ReportNo] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY, " _
             & "[ReportName] [nvarchar](50) NOT NULL,[ReportHeader] [nvarchar](50) NOT NULL, " _
             & "[ReportFooter] [nvarchar](50) NULL,	[ColumnOneCaption] [nvarchar](50) NULL, " _
             & "[ColumnTwoCaption] [nvarchar](50) NULL,	[ColumnThreeCaption] [nvarchar](50) NULL, " _
             & "[ColumnFourCaption] [nvarchar](50) NULL,[ColumnFiveCaption] [nvarchar](50) NULL, " _
             & "[ColumnSixCaption] [nvarchar](50) NULL,	[ColumnOneWidth] [int] NOT NULL DEFAULT 0, " _
             & "[ColumnTwoWidth] [int] NOT NULL DEFAULT 0,[ColumnThreeWidth] [int] NOT NULL DEFAULT 0, " _
             & "[ColumnFourWidth] [int] NOT NULL DEFAULT 0,[ColumnFiveWidth] [int] NOT NULL DEFAULT 0, " _
             & "[ColumnSixWidth] [int] NOT NULL DEFAULT 0,[ColumnOneAlign] [int] NOT NULL DEFAULT 0, " _
             & "[ColumnTwoAlign] [int] NOT NULL DEFAULT 0,[ColumnThreeAlign] [int] NOT NULL DEFAULT 0, " _
             & "[ColumnFourAlign] [int] NOT NULL DEFAULT 0,[ColumnFiveAlign] [int] NOT NULL DEFAULT 0, " _
             & "[ColumnSixAlign] [int] NOT NULL DEFAULT 0, [SortMethod] [nvarchar] (350) NOT NULL DEFAULT '001', " _
             & "[Grouping][int] NOT NULL DEFAULT 0, [SuppressZero][nvarchar] (3) NOT NULL DEFAULT 'YES', " _
             & "[IncludeManuals][nvarchar] (3) NOT NULL DEFAULT 'NO')", cnn)
        sqlCreateTable.ExecuteNonQuery()
        sqlCreateTable = New Data.OleDb.OleDbCommand("IF OBJECT_ID(N'SystemColumnReportCalcs', N'U') IS NULL CREATE " _
            & "TABLE SystemColumnReportCalcs ([ReportNo][int] NOT NULL, " _
            & "[OrdinalNo][int] NOT NULL DEFAULT 0, [FieldFunctions][nvarchar] (350) NULL, " _
            & "[TransactionNo][int] NOT NULL PRIMARY KEY IDENTITY (1,1))", cnn)
        sqlCreateTable.ExecuteNonQuery()

        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT ReportNo, ReportName " _
            & "FROM SystemColumnReportHeaders ORDER BY ReportNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        dgrid.Rows.Clear()
        While objReader.Read
            dgrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(2).Value = objReader(1).ToString
        End While
        objReader.Close()
        If dgrid.Rows.Count <= 0 Then
            dgrid.Enabled = False
            tsDelete.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
            tsEdit.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
        Else
            dgrid.Enabled = True
            tsDelete.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
            tsEdit.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Column Reports Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrid.DoubleClick
        boolEditStatus = True
        'Get the selected row report number
        Dim CurrentCell As DataGridViewCell
        CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(0)
        intSelectedReport = CInt(CurrentCell.Value)
        Dim f As New frmReportWriter
        f.ShowDialog()
        boolEditStatus = False
        LoadFormDetails()
    End Sub

    Private Sub tsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDelete.Click
        'Get the selected row report number
        Dim CurrentCell As DataGridViewCell
        CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(0)
        intSelectedReport = CInt(CurrentCell.Value)
        DeleteReport()
    End Sub

    Private Sub DeleteReport()
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to delete the selected report?", _
                "Report Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemColumnReportHeaders WHERE ReportNo = " & intSelectedReport & "", cnn)
            sqlCommand.ExecuteNonQuery()
            sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemReportColumnCalcs WHERE ReportNo = " & intSelectedReport & "", cnn)
            sqlCommand.ExecuteNonQuery()
            MessageBox.Show("Report has been permanently deleted successfully", "Column Report Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LoadFormDetails()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Reports File Recreation Error"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    '    Private Sub PrintReport(ByVal reportnumber As Integer)

    '        'open the headers and calculations file based on the selected report
    '        On Error GoTo RaiseErr

    '        Dim objReaderHeaders As StreamReader
    '        Dim objReaderCalculations As StreamReader
    '        Dim objReaderRunfile As StreamReader
    '        Dim objReaderSortfile As StreamReader
    '        Dim strLineHeaders As String
    '        Dim strLineCalculations As String
    '        Dim strLine As String
    '        Dim strBuffer() As String
    '        Dim intCalcCnt As Integer

    '        objReaderHeaders = New StreamReader(strDatafilePath & "\UserReportsHeaders")
    '        objReaderCalculations = New StreamReader(strDatafilePath & "\UserReportsCalculations")
    '        objReaderRunfile = New StreamReader(strDatafilePath & "\PayRunfile")

    '        strLineHeaders = objReaderHeaders.ReadLine
    '        While Not strLineHeaders Is Nothing
    '            strBuffer = Split(strLineHeaders, ";")
    '            If strBuffer(0) = reportnumber Then
    '                'assign the string to the headers array
    '                strPrintHeaders = strLineHeaders
    '                Exit While
    '            End If
    '            strLineHeaders = objReaderHeaders.ReadLine
    '        End While
    '        objReaderHeaders.Close()
    '        strPrintCalculations.Clear()
    '        strLineCalculations = objReaderCalculations.ReadLine
    '        While Not strLineCalculations Is Nothing
    '            strBuffer = Split(strLineCalculations, ";")
    '            If strBuffer(0) = reportnumber Then
    '                If strBuffer(2) <> "" Then strPrintCalculations.Add(strLineCalculations)
    '            End If
    '            strLineCalculations = objReaderCalculations.ReadLine
    '        End While
    '        intCalcCnt = strPrintCalculations.Count

    '        strEmployeeFields.Clear()
    '        strLine = objReaderRunfile.ReadLine
    '        While Not strLine Is Nothing
    '            strEmployeeFields.Add(strLine)
    '            strLine = objReaderRunfile.ReadLine
    '        End While
    '        objReaderRunfile.Close()
    '        Dim intRunFileCnt As Integer
    '        intRunFileCnt = strEmployeeFields.Count

    '        'Read employee details from the sort file options
    '        Dim i As Integer = 0
    '        Dim intCnt As Integer
    '        objReaderSortfile = New StreamReader(strDatafilePath & "\TempSortFile")
    '        strLine = objReaderSortfile.ReadLine
    '        While Not strLine Is Nothing
    '            i = i + 1
    '            strLine = objReaderSortfile.ReadLine
    '        End While
    '        objReaderSortfile.Close()
    '        intCnt = i
    '        ReDim strSortedEmployeeDetails(0 To i)
    '        objReaderSortfile = New StreamReader(strDatafilePath & "\TempSortFile")
    '        strLine = objReaderSortfile.ReadLine
    '        i = 0
    '        While Not strLine Is Nothing
    '            strSortedEmployeeDetails(i) = strLine
    '            strLine = objReaderSortfile.ReadLine
    '            i = i + 1
    '        End While
    '        objReaderSortfile.Close()
    '        Dim intSortedEmployeesCnt As Integer
    '        intSortedEmployeesCnt = i
    '        'loop through the sorted file and perform the report calculations
    '        Array.Sort(strSortedEmployeeDetails)

    '        'rebuild a temporary report file based on the run file details
    '        Dim strOneLine As String
    '        Dim objStreamWriteNew As StreamWriter
    '        Dim strTestFlag As String = ""
    '        Dim strRecordHeader As String = ""
    '        objStreamWriteNew = New StreamWriter(strDatafilePath & "\EmpReportFile")

    '        For i = 0 To intRunFileCnt - 1
    '            strBuffer = Split(strEmployeeFields(i), ";")
    '            If strBuffer(0) <> strTestFlag Then
    '                'write first the record header
    '                If strOneLine <> "" Then objStreamWriteNew.WriteLine(strOneLine)
    '                strOneLine = strBuffer(0) & ";" & strBuffer(2)
    '                strTestFlag = strBuffer(0)
    '            Else
    '                strOneLine = strOneLine & ";" & strBuffer(2)
    '            End If
    '            If i = intRunFileCnt - 1 Then objStreamWriteNew.WriteLine(strOneLine) 'write the last line in file
    '        Next
    '        objStreamWriteNew.Close()
    '        'Read the report file and move column values based on the calculations file
    '        Dim objReaderReportFile As StreamReader
    '        objReaderReportFile = New StreamReader(strDatafilePath & "\EmpReportFile")
    '        strLine = objReaderReportFile.ReadLine
    '        Dim dblAssignColumn(0 To 5) As Double
    '        dblColumnValues.Clear()
    '        While Not strLine Is Nothing
    '            strBuffer = Split(strLine, ";")
    '            'loop through the calculations array and make column values
    '            dblAssignColumn(0) = 0 : dblAssignColumn(1) = 0 : dblAssignColumn(2) = 0
    '            dblAssignColumn(3) = 0 : dblAssignColumn(4) = 0 : dblAssignColumn(5) = 0
    '            For i = 0 To intCalcCnt - 1
    '                strCalcBuffer = Split(strPrintCalculations(i), ";")
    '                If strCalcBuffer(2) = "MOV" Then
    '                    dblAssignColumn(CInt(strCalcBuffer(7)) - 1) = strBuffer(CInt(strCalcBuffer(4)))
    '                End If
    '                If strCalcBuffer(2) = "ADD" Then
    '                    dblAssignColumn(CInt(strCalcBuffer(7)) - 1) = dblAssignColumn(CInt(strCalcBuffer(7)) - 1) + CDbl(strBuffer(CInt(strCalcBuffer(4)))) + CDbl(strBuffer(CInt(strCalcBuffer(6))))
    '                End If
    '                If strCalcBuffer(2) = "SUB" Then
    '                    dblAssignColumn(CInt(strCalcBuffer(7)) - 1) = CDbl(strBuffer(CInt(strCalcBuffer(4)))) - CDbl(strBuffer(CInt(strCalcBuffer(6))))
    '                End If
    '                If strCalcBuffer(2) = "DIV" Then
    '                    dblAssignColumn(CInt(strCalcBuffer(7)) - 1) = CDbl(strBuffer(CInt(strCalcBuffer(4)))) / CDbl(strBuffer(CInt(strCalcBuffer(6))))
    '                End If
    '                If strCalcBuffer(2) = "MUL" Then
    '                    dblAssignColumn(CInt(strCalcBuffer(7)) - 1) = CDbl(strBuffer(CInt(strCalcBuffer(4)))) * CDbl(strBuffer(CInt(strCalcBuffer(6))))
    '                End If
    '            Next
    '            'write the column values to an array
    '            dblColumnValues.Add(strBuffer(0) & ";" & dblAssignColumn(0) & ";" & dblAssignColumn(1) & _
    '                ";" & dblAssignColumn(2) & ";" & dblAssignColumn(3) & ";" & dblAssignColumn(4) & _
    '                ";" & dblAssignColumn(5))
    '            strLine = objReaderReportFile.ReadLine
    '        End While
    '        objReaderReportFile.Close()
    '        'Based on the print array generated, send to print
    '        'Get the count of the lines to print
    '        Dim intRowsToPrint As Integer, n As Integer
    '        intRowsToPrint = dblColumnValues.Count - 1
    '        'MessageBox.Show(dblColumnValues.Item(7))
    '        ReDim strRecordToPrint(0 To (strSortedEmployeeDetails.Length - 1))
    '        For i = 0 To strSortedEmployeeDetails.Length - 1
    '            If Not strSortedEmployeeDetails(i) Is Nothing Then
    '                strBuffer = Split(strSortedEmployeeDetails(i), ";")
    '                For n = 0 To dblColumnValues.Count - 1
    '                    strTemp = Split(dblColumnValues.Item(n), ";")
    '                    If strBuffer.Length > 3 Then
    '                        If strBuffer(4) = strTemp(0) Then
    '                            strRecordToPrint(i) = strBuffer(4) & ";" & strBuffer(0) & ";" & strBuffer(1) & " " & _
    '                                UCase(Mid(strBuffer(2), 1, 1)) & " " & UCase(Mid(strBuffer(3), 1, 1)) & _
    '                                ";" & strTemp(1) & ";" & strTemp(2) & ";" & strTemp(3) & _
    '                                ";" & strTemp(4) & ";" & strTemp(5) & ";" & strTemp(6)
    '                            Exit For
    '                        End If
    '                    End If
    '                Next
    '            End If
    '        Next

    '        Dim prnReport As New clsUserReports
    '        With prnReport
    '            .strPrintValues = strRecordToPrint
    '            .intBreakIndex = 1
    '            .intPrintRecordsCount = strRecordToPrint.Length
    '            .intCol1width = 150
    '            .intCol2width = 100
    '            .intCol3width = 100
    '            .intCol4width = 100
    '            .intCol5width = 100
    '            .intCol6width = 100
    '            .intCol1allignment = 0
    '            .intCol2allignment = 2
    '            .intCol3allignment = 2
    '            .intCol4allignment = 2
    '            .intCol5allignment = 2
    '            .intCol6allignment = 2
    '            .boolGroupDetails = True
    '            .boolCol1SubTotals = False
    '            .boolCol2SubTotals = True
    '            .boolCol3SubTotals = True
    '            .boolCol4SubTotals = True
    '            .boolCol5SubTotals = True
    '            .boolCol6SubTotals = True
    '            .boolCol1Totals = False
    '            .boolCol2Totals = True
    '            .boolCol3Totals = True
    '            .boolCol4Totals = True
    '            .boolCol5Totals = True
    '            .boolCol6Totals = True
    '            strBuffer = Split(strPrintHeaders, ";")
    '            .strMainCaption = strBuffer(1)
    '            .strHeader1caption = "Employee Details"
    '            .strHeader2caption = strBuffer(2)
    '            .strHeader3caption = strBuffer(4)
    '            .strHeader4caption = strBuffer(6)
    '            .strHeader5caption = strBuffer(8)
    '            .strHeader6caption = strBuffer(10)
    '            '.Print()
    '            ppd.Document = prnReport
    '            ppd.ShowDialog()
    '        End With
    '        Exit Sub
    'RaiseErr:
    '        MessageBox.Show(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Report Generation Error")
    '    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Get the selected report number
        If dgrid.Enabled = True Then
            If dgrid.Rows.Count > 0 Then
                intSelectedReport = CInt(dgrid.CurrentRow.Cells(0).Value.ToString)
                gwt_comm.PrintColumnReport(intSelectedReport)
            End If
        End If
    End Sub

End Class