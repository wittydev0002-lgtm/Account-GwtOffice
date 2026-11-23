Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Text
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel

Module CommonFunctions

    Public gwt_comm As CommonLibrary.Commons.CommonFunctions

    Public boolErrorFlag As Boolean
    Public dblDebits As Double
    Public dblCredits As Double
    Public intDebits As Integer
    Public intCredits As Integer
    Public boolFromSavedExtracts As Boolean
    Public strPublicPayrollRunFrequency As String

    Public Sub ShowErrorMessage()
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Function GetPeriodRunsCount() As Integer
        On Error GoTo RaiseErr
        Dim intNumberOfRuns As Integer = 12
        Dim strSql As String = "SELECT [NoOfPeriods] FROM SystemKeyData"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intNumberOfRuns = CInt(objReader(0).ToString)
            End If
        End If
        objReader.Close()
        Return intNumberOfRuns
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Calendar Parameter Update"
        ShowErrorMessage()
    End Function

    Public Sub PrintMultiColumnReport(ByVal intSelectedReport As Integer, ByVal myPrintPreviewDialog As PrintPreviewDialog)
        On Error GoTo RaiseErr

        'We are reading the employee details from the run file
        'The values from the codes and calculations are added to column totals
        'each record line has the employee number, surname and initials

        boolAbort = False
        Dim f As New frmReportDefinition
        f.ShowDialog()
        If boolAbort = True Then Exit Sub

        Dim dblTotal() As Double

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim objReadFields As Data.OleDb.OleDbDataReader
        Dim objReadSizes As Data.OleDb.OleDbDataReader
        Dim objReadAlignments As Data.OleDb.OleDbDataReader
        Dim objReadHeading As Data.OleDb.OleDbDataReader
        Dim arrReportDetails As New ArrayList

        Dim strReportHeader As String = Nothing

        'Get the report calculations first
        objCommand = New Data.OleDb.OleDbCommand("SELECT [CaptionA],[CaptionB],[CaptionC],[CaptionD],[CaptionE],[CaptionF],[CaptionG]" _
            & ",[CaptionH],[CaptionI],[CaptionJ],[CaptionK],[CaptionL],[CaptionM],[CaptionN]" _
            & ",[CaptionO],[CaptionP],[CaptionQ],[CaptionR],[CaptionS],[CaptionT],[CaptionU]" _
            & ",[CaptionV],[CaptionW],[CaptionX],[CaptionY],[CaptionZ] FROM MultiColumnReportCaptions " _
            & "WHERE ReportNo = " & intSelectedReport & "", cnn)
        objReader = objCommand.ExecuteReader

        objCommand = New Data.OleDb.OleDbCommand("SELECT [FieldA],[FieldB],[FieldC],[FieldD],[FieldE],[FieldF],[FieldG],[FieldH],[FieldI]" _
            & ",[FieldJ],[FieldK],[FieldL],[FieldM],[FieldN],[FieldO],[FieldP],[FieldQ],[FieldR]" _
            & ",[FieldS],[FieldT],[FieldU],[FieldV],[FieldW],[FieldX],[FieldY],[FieldZ] " _
            & "FROM MultiColumnReportFields WHERE ReportNo = " & intSelectedReport & "", cnn)
        objReadFields = objCommand.ExecuteReader

        objCommand = New Data.OleDb.OleDbCommand("SELECT [FieldA],[FieldB],[FieldC],[FieldD],[FieldE],[FieldF],[FieldG]" _
            & ",[FieldH],[FieldI],[FieldJ],[FieldK],[FieldL],[FieldM],[FieldN]" _
            & ",[FieldO],[FieldP],[FieldQ],[FieldR],[FieldS],[FieldT],[FieldU]" _
            & ",[FieldV],[FieldW],[FieldX],[FieldY],[FieldZ] FROM MultiColumnReportAlignments " _
            & "WHERE ReportNo = " & intSelectedReport & "", cnn)
        objReadAlignments = objCommand.ExecuteReader

        objCommand = New Data.OleDb.OleDbCommand("SELECT [FieldA],[FieldB],[FieldC],[FieldD],[FieldE],[FieldF],[FieldG],[FieldH],[FieldI]" _
            & ",[FieldJ],[FieldK],[FieldL],[FieldM],[FieldN],[FieldO],[FieldP],[FieldQ],[FieldR]" _
            & ",[FieldS],[FieldT],[FieldU],[FieldV],[FieldW],[FieldX],[FieldY],[FieldZ] " _
            & "FROM MultiColumnReportSizes WHERE ReportNo = " & intSelectedReport & "", cnn)
        objReadSizes = objCommand.ExecuteReader

        objCommand = New Data.OleDb.OleDbCommand("SELECT [ReportName] FROM MultiColumnReportHeaders WHERE ReportNo = " & intSelectedReport & "", cnn)
        objReadHeading = objCommand.ExecuteReader

        'Based on the fields, if the value is greater than 0 or not a formular, get the headers and other report elements
        Dim arrReportOutputFields As New ArrayList

        If objReadFields.HasRows = False Then
            MessageBox.Show("The report does not contain any output fields. Process aborted", "Report Print Abort", MessageBoxButtons.OK, MessageBoxIcon.Error)
            objReadFields.Close()
            Exit Sub
        Else
            objReadFields.Read()
            For i As Integer = 0 To objReadFields.FieldCount - 1
                If Not IsDBNull(objReadFields(i).ToString) Then
                    If IsNumeric(objReadFields(i).ToString) Then
                        'Check that the field is greater than 0
                        If CInt(Mid(objReadFields(i).ToString, 1, 1)) > 0 Then
                            arrReportOutputFields.Add(objReadFields(i).ToString & "|CODE|" & i)
                        End If
                    Else
                        If objReadFields(i).ToString.Length > 3 Then
                            If Mid(objReadFields(i).ToString, 1, 3) = "SUM" Then
                                arrReportOutputFields.Add(objReadFields(i).ToString & "|FORMULAR|" & i)
                            End If
                        End If
                    End If
                End If
            Next
            objReadFields.Close()
        End If

        'Assign the other elements that are dependent on the fields such as captions, sizes etc
        Dim arrCaptions As New ArrayList
        Dim arrSizes As New ArrayList
        Dim arrAlignment As New ArrayList
        Dim strBuffer() As String
        '
        If arrReportOutputFields.Count > 0 Then
            'Get the report captions
            If objReader.HasRows Then
                objReader.Read()
                For i As Integer = 0 To arrReportOutputFields.Count - 1
                    strBuffer = Split(arrReportOutputFields.Item(i), "|")
                    arrCaptions.Add(objReader(CInt(strBuffer(2))).ToString)
                Next
            End If
            'Get the report alignments
            If objReadAlignments.HasRows Then
                objReadAlignments.Read()
                For i As Integer = 0 To arrReportOutputFields.Count - 1
                    strBuffer = Split(arrReportOutputFields.Item(i), "|")
                    arrAlignment.Add(objReadAlignments(CInt(strBuffer(2))).ToString)
                Next
            End If
            'Get the report sizes
            If objReadSizes.HasRows Then
                objReadSizes.Read()
                For i As Integer = 0 To arrReportOutputFields.Count - 1
                    strBuffer = Split(arrReportOutputFields.Item(i), "|")
                    arrSizes.Add(objReadSizes(CInt(strBuffer(2))).ToString)
                Next
            End If
            'Get the report header
            If objReadHeading.HasRows Then
                objReadHeading.Read()
                If Not IsDBNull(objReadHeading(0).ToString) Then strReportHeader = objReadHeading(0).ToString
            End If
        End If

        Dim strSql As String = Nothing

        Select Case strSortOrder
            Case Is = "Department/Employee Number Sequence"
                strSql = "SELECT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName +' '+ SUBSTRING(EmployeeMaster.FirstName, 1,1) " _
                    & "+' '+ SUBSTRING(EmployeeMaster.OtherNames, 1,1) AS [EmployeeIdentity], Employment.Department, Employment.CostCenter, " _
                    & "Employment.PayPoint FROM EmployeeMaster LEFT OUTER JOIN Employment ON " _
                    & "EmployeeMaster.EmployeeNo = Employment.EmployeeNo ORDER BY Employment.Department, " _
                    & "EmployeeMaster.EmployeeNo"
            Case Is = "Department/Surname/Employee Number"
                strSql = "SELECT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName +' '+ SUBSTRING(EmployeeMaster.FirstName, 1,1) " _
                    & "+' '+ SUBSTRING(EmployeeMaster.OtherNames, 1,1) AS [EmployeeIdentity], Employment.Department, Employment.CostCenter, " _
                    & "Employment.PayPoint FROM EmployeeMaster LEFT OUTER JOIN Employment ON " _
                    & "EmployeeMaster.EmployeeNo = Employment.EmployeeNo ORDER BY Employment.Department, " _
                    & "EmployeeMaster.LastName, EmployeeMaster.EmployeeNo"
            Case Is = "Cost Code/Employee Number"
                strSql = "SELECT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName +' '+ SUBSTRING(EmployeeMaster.FirstName, 1,1) " _
                    & "+' '+ SUBSTRING(EmployeeMaster.OtherNames, 1,1) AS [EmployeeIdentity], Employment.CostCenter, Employment.Department, " _
                    & "Employment.PayPoint FROM EmployeeMaster LEFT OUTER JOIN Employment ON " _
                    & "EmployeeMaster.EmployeeNo = Employment.EmployeeNo ORDER BY Employment.CostCenter, " _
                    & "EmployeeMaster.EmployeeNo"
            Case Is = "Cost Code/Surname/Employee Number"
                strSql = "SELECT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName +' '+ SUBSTRING(EmployeeMaster.FirstName, 1,1) " _
                    & "+' '+ SUBSTRING(EmployeeMaster.OtherNames, 1,1) AS [EmployeeIdentity], Employment.CostCenter, Employment.Department, " _
                    & "Employment.PayPoint FROM EmployeeMaster LEFT OUTER JOIN Employment ON " _
                    & "EmployeeMaster.EmployeeNo = Employment.EmployeeNo ORDER BY Employment.CostCenter, " _
                    & "EmployeeMaster.LastName, EmployeeMaster.EmployeeNo"
            Case Is = "Paypoint/Employee Number Sequence"
                strSql = "SELECT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName +' '+ SUBSTRING(EmployeeMaster.FirstName, 1,1) " _
                    & "+' '+ SUBSTRING(EmployeeMaster.OtherNames, 1,1) AS [EmployeeIdentity], Employment.PayPoint, Employment.CostCenter, " _
                    & "Employment.Department FROM EmployeeMaster LEFT OUTER JOIN Employment ON " _
                    & "EmployeeMaster.EmployeeNo = Employment.EmployeeNo ORDER BY Employment.PayPoint, " _
                    & "EmployeeMaster.EmployeeNo"
            Case Is = "Paypoint/Surname Sequence"
                strSql = "SELECT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName +' '+ SUBSTRING(EmployeeMaster.FirstName, 1,1) " _
                    & "+' '+ SUBSTRING(EmployeeMaster.OtherNames, 1,1) AS [EmployeeIdentity], Employment.PayPoint, Employment.CostCenter, " _
                    & "Employment.Department FROM EmployeeMaster LEFT OUTER JOIN Employment ON " _
                    & "EmployeeMaster.EmployeeNo = Employment.EmployeeNo ORDER BY Employment.PayPoint, " _
                    & "EmployeeMaster.LastName, EmployeeMaster.EmployeeNo"
            Case Is = "Paypoint/Cost Code/Employee Number"
                strSql = "SELECT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName +' '+ SUBSTRING(EmployeeMaster.FirstName, 1,1) " _
                    & "+' '+ SUBSTRING(EmployeeMaster.OtherNames, 1,1) AS [EmployeeIdentity], Employment.PayPoint, Employment.CostCenter, " _
                    & "Employment.Department FROM EmployeeMaster LEFT OUTER JOIN Employment ON " _
                    & "EmployeeMaster.EmployeeNo = Employment.EmployeeNo ORDER BY Employment.PayPoint, " _
                    & "Employment.CostCode, EmployeeMaster.EmployeeNo"
            Case Is = "Employee Number Sequence"
                strSql = "SELECT EmployeeNo, LastName +' '+ SUBSTRING(FirstName, 1,1) +' '+ SUBSTRING(OtherNames, 1,1) as [EmployeeIdentity], EmployeeNo as [ECNUMM] FROM EmployeeMaster ORDER BY EmployeeNo"
            Case Else
                strSql = "SELECT EmployeeNo, LastName +' '+ SUBSTRING(FirstName, 1,1) +' '+ SUBSTRING(OtherNames, 1,1) as [EmployeeIdentity], EmployeeNo as [ECNUMM] FROM EmployeeMaster ORDER BY EmployeeNo"
        End Select

        'Close all open readers
        objReader.Close()
        objReadFields.Close()
        objReadSizes.Close()
        objReadAlignments.Close()
        objReadHeading.Close()

        'Generate report data
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        ReDim dblTotal(0 To arrReportOutputFields.Count - 1)
        Dim intColumnsCnt As Integer = arrReportOutputFields.Count

        'Add the column for employee number, employee details and the sort key
        intColumnsCnt = intColumnsCnt + 3

        While objReader.Read
            'Open the run table and check if the record exists in the run table
            objCommand = New Data.OleDb.OleDbCommand("SELECT EmployeeNo FROM EmployeeRunFile WHERE EmployeeNo = '" & objReader(0).ToString & "'", cnn)
            Dim objReadRunfile As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadRunfile.HasRows Then
                'Initialize totals
                For i = 0 To dblTotal.Length - 1
                    dblTotal(i) = 0
                Next
                Dim strOutputValues As String = Nothing
                Dim dblOutputValues(0 To intColumnsCnt) As Double

                For i As Integer = 0 To arrReportOutputFields.Count - 1
                    strBuffer = Split(arrReportOutputFields.Item(i), "|")
                    If UCase(strBuffer(1)) = "CODE" Then
                        dblOutputValues(i) = gwt_comm.ReturnCodeValue(objReader(0).ToString, CInt(strBuffer(0)))
                    Else
                        dblOutputValues(i) = gwt_comm.EvaluateExpressionsToMathFunctions(objReader(0).ToString, strBuffer(0))
                    End If
                    strOutputValues = strOutputValues & Format(dblOutputValues(i), "##,0.00") & ";"
                Next
                strOutputValues = Mid(strOutputValues, 1, (strOutputValues.Length - 1))
                arrReportDetails.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" & strOutputValues & ";" & objReader(2).ToString) 'Objreader(2).toString is the sort key identifier and is not visible
            End If
            objReadRunfile.Close()
        End While

        objReader.Close()

        'Get the company details
        gwt_comm.GetCompanyDetails()

        'Call the BraincoSmartReport writer to handle the output
        Dim intRecordsCount As Integer = arrReportDetails.Count
        Dim strPrintDetails(0 To (intRecordsCount - 1)) As String

        'Build the column headers string from the captions
        Dim strColumnHeaders As String = "EC No.|GIVEN NAMES"
        For i As Integer = 0 To arrCaptions.Count - 1
            strColumnHeaders = strColumnHeaders & "|" & arrCaptions.Item(i).ToString
        Next
        'Add the invisible column
        strColumnHeaders = strColumnHeaders & "| "

        'Build the column alignments as well
        Dim strColumnAlignments As String = "0|0"
        For i As Integer = 0 To arrSizes.Count - 1
            strColumnAlignments = strColumnAlignments & "|" & arrAlignment.Item(i).ToString
        Next
        'Add the invisible column
        strColumnAlignments = strColumnAlignments & "|0"

        'Build the columnwidths as well
        Dim strColumnWidths As String = "60|100"
        For i As Integer = 0 To arrSizes.Count - 1
            strColumnWidths = strColumnWidths & "|" & arrSizes.Item(i).ToString
        Next
        'Add the invisible column
        strColumnWidths = strColumnWidths & "|0"

        'Build the visibility string. REMEMBER the last column is not visible
        Dim strColumnVisibility As String = "YES|YES"
        For i As Integer = 0 To arrReportOutputFields.Count - 1
            strColumnVisibility = strColumnVisibility & "|YES"
        Next
        'Add the invisible column
        strColumnVisibility = strColumnVisibility & "|NO"

        'Build the string for the column summary totals
        Dim strColumnSummaryTotals As String = "NO|NO"
        For i As Integer = 0 To arrReportOutputFields.Count - 1
            strColumnSummaryTotals = strColumnSummaryTotals & "|YES"
        Next
        'Add the invisible column
        strColumnSummaryTotals = strColumnSummaryTotals & "|NO"

        'Build the string for the column summary totals
        Dim strColumnFormat As String = "NO|NO"
        For i As Integer = 0 To arrReportOutputFields.Count - 1
            strColumnFormat = strColumnFormat & "|NO"
        Next
        'Add the invisible column
        strColumnFormat = strColumnFormat & "|NO"

        For p = 0 To intRecordsCount - 1
            strPrintDetails(p) = arrReportDetails.Item(p)
        Next

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter

        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = intColumnsCnt
            .strColumnHeaders = UCase(strColumnHeaders)
            .strColumnAlignments = strColumnAlignments
            .strColumnWidths = strColumnWidths
            .strFooterCaption = strUserFooterText
            .strMainCaption = UCase(strDefaultReportHeader)
            .strMainHeader2 = UCase(strReportHeader)
            .strMainHeader3 = "PERIOD " & strReportPeriod & " RUN " & intReportRunNumber & " BETWEEN " & UCase(strReportStartDate) & " AND " & UCase(strReportEndDate)
            .strColumnTotals = strColumnSummaryTotals
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("LightGray")
            .DetailFont = fntUserDetailsFont
            .HeaderFont = fntUserHeaderFont
            .FooterFont = fntUserFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = False
            .VisibleColumns = strColumnVisibility
            .strColumnFormating = strColumnFormat
            .strSummaryTotals = strColumnSummaryTotals
            'Set the break key indicator
            .intKeyFieldIndex = (intColumnsCnt - 1)
            .strPrintValues = strPrintDetails
        End With

        myPrintPreviewDialog.Document = rpt
        myPrintPreviewDialog.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Multi Column Report Generation"
        ShowErrorMessage()
    End Sub

    Public Sub GetNextBatchNumber()
        'Get the number of the next batch from the payroll batches file
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT BatchNo " _
            & "FROM SystemBatchesControl ORDER BY BatchNo DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        intCurrentBatchNumber = 1
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intCurrentBatchNumber = CInt(objReader(0).ToString) + 1
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Batch Number Allocation"
        ShowErrorMessage()
    End Sub

    Public Sub PrintHeader(ByVal DetailLine As String, ByVal sFilename As String)
        On Error GoTo RaiseErr
        'open the file as new for writing details into
        Dim objStreamWriter As StreamWriter
        Dim inDirectory() As String = Split(sFilename, "\")
        Dim sDirectory As String = Nothing
        Dim i As Integer = 0
        For i = 0 To inDirectory.Length - 2
            sDirectory = sDirectory & inDirectory(i) & "\"
        Next
        sDirectory = Mid(sDirectory, 1, (sDirectory.Length - 1))
        If Not Directory.Exists(sFilename) Then
            Directory.CreateDirectory(sDirectory)
        End If
        objStreamWriter = New StreamWriter(sFilename, False)
        objStreamWriter.WriteLine(DetailLine)
        objStreamWriter.Close()
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "File Header Details Write Error")
        boolErrorFlag = True
    End Sub

    Public Sub PrintDetails(ByVal DetailLine As String, ByVal FileName As String)
        On Error GoTo RaiseErr
        'use the open file for writing record line into
        Dim objStreamWriter As StreamWriter
        objStreamWriter = New StreamWriter(FileName, True)
        'Write out the details.
        objStreamWriter.WriteLine(DetailLine)
        objStreamWriter.Close()
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Record Details Write Error")
        boolErrorFlag = True
    End Sub

    Public Sub PrintTrailer(ByVal TrailerLine As String, ByVal sFileName As String)
        On Error GoTo RaiseErr
        Dim objStreamWriter As StreamWriter
        objStreamWriter = New StreamWriter(sFileName, True)
        objStreamWriter.WriteLine(TrailerLine)
        objStreamWriter.Close()
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Trailer Details Write Error")
        boolErrorFlag = True
    End Sub

    Public Sub UpdateCalendar(ByVal PeriodStartingDate As Date, ByVal PayrollRunType As String, ByVal intNumberOfPeriods As Integer)
        On Error GoTo RaiseErr
        Dim dteStart As Date = PeriodStartingDate
        Dim dteEndDate As Date

        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemCalendar", cnn)
        sqlCommand.ExecuteNonQuery()

        Select Case UCase(PayrollRunType)
            Case Is = "WEEKLY"
                For p As Integer = 0 To intNumberOfPeriods - 1
                    'This year, this month, first day
                    Dim dteMthStart As Date = DateAdd(DateInterval.Day, (p * 7), dteStart)
                    'This year, next month, 0th day is this month's last day
                    dteEndDate = DateAdd(DateInterval.Day, 6, dteMthStart) '  DateSerial(dteMthStart.Year, dteMthStart.Day + 7, 0)
                    sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemCalendar " _
                        & "(TaxPeriod, RunInPeriod, RunsInPeriod, StartDate, EndDate, RunStatus) " _
                        & "VALUES (" & p + 1 & ", " & 1 & ", " _
                        & "" & 1 & ", '" & Format(dteMthStart, "dd-MMM-yyyy") & "', '" & Format(dteEndDate, "dd-MMM-yyyy") & "', " _
                        & "'N ')", cnn)
                    sqlCommand.ExecuteNonQuery()
                Next
            Case Is = "MONTHLY"
                For p As Integer = 0 To intNumberOfPeriods - 1
                    'This year, this month, first day
                    Dim dteMthStart As Date = DateSerial(dteStart.Year, dteStart.Month + p, 1)
                    'This year, next month, 0th day is this month's last day
                    dteEndDate = DateSerial(dteMthStart.Year, dteMthStart.Month + 1, 0)
                    sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemCalendar " _
                        & "(TaxPeriod, RunInPeriod, RunsInPeriod, StartDate, EndDate, RunStatus) " _
                        & "VALUES (" & p + 1 & ", " & 1 & ", " _
                        & "" & 1 & ", '" & Format(dteMthStart, "dd-MMM-yyyy") & "', '" & Format(dteEndDate, "dd-MMM-yyyy") & "', " _
                        & "'N ')", cnn)
                    sqlCommand.ExecuteNonQuery()
                Next
            Case Is = "FORTNIGHTLY"
                For p As Integer = 0 To intNumberOfPeriods - 1
                    'This year, this month, first day
                    Dim dteMthStart As Date = DateAdd(DateInterval.Day, (p * 14), dteStart)
                    'This year, next month, 0th day is this month's last day
                    dteEndDate = DateAdd(DateInterval.Day, 13, dteMthStart) '  DateSerial(dteMthStart.Year, dteMthStart.Day + 7, 0)
                    sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemCalendar " _
                        & "(TaxPeriod, RunInPeriod, RunsInPeriod, StartDate, EndDate, RunStatus) " _
                        & "VALUES (" & p + 1 & ", " & 1 & ", " _
                        & "" & 1 & ", '" & Format(dteMthStart, "dd-MMM-yyyy") & "', '" & Format(dteEndDate, "dd-MMM-yyyy") & "', " _
                        & "'N ')", cnn)
                    sqlCommand.ExecuteNonQuery()
                Next
            Case Else
                'Default to monthly run 
                For p As Integer = 0 To intNumberOfPeriods - 1
                    'This year, this month, first day
                    Dim dteMthStart As Date = DateSerial(dteStart.Year, dteStart.Month + p, 1)
                    'This year, next month, 0th day is this month's last day
                    dteEndDate = DateSerial(dteMthStart.Year, dteMthStart.Month + 1, 0)
                    sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemCalendar " _
                        & "(TaxPeriod, RunInPeriod, RunsInPeriod, StartDate, EndDate, RunStatus) " _
                        & "VALUES (" & p + 1 & ", " & 1 & ", " _
                        & "" & 1 & ", '" & Format(dteMthStart, "dd-MMM-yyyy") & "', '" & Format(dteEndDate, "dd-MMM-yyyy") & "', " _
                        & "'N ')", cnn)
                    sqlCommand.ExecuteNonQuery()
                Next
        End Select
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Calendar Parameter Update"
        ShowErrorMessage()
    End Sub

End Module
