Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Net
Imports System.Management
Imports System.Management.Instrumentation
Imports System.Drawing
Imports ComponentFactory.Krypton.Toolkit
Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports DevComponents.DotNetBar.Metro.MetroForm
Imports DevComponents.DotNetBar.ProgressBarItem

Module CommonFunctions

    Public Sub ShowErrorMessage()
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Function NewStudentNumber() As Long
        Dim lngReturn As Long = 100001
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [StudentId] FROM [SC_Students] ORDER BY [StudentId] DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If IsNumeric(objReader(0).ToString) Then
                lngReturn = CLng(objReader(0).ToString) + 1
                Exit While
            End If
        End While
        objReader.Close()
        Return lngReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica New Student Number Allocation"
        ShowErrorMessage()
    End Function

    Public Sub GetOperationType()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT OperationType FROM SC_OperationsType"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                strSchoolOperationType = UCase(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        If gwt_comm.CheckColumnExistence("SC_Students", "StudentType") = False Then
            strSql = "ALTER TABLE SC_Students ADD [StudentType][NVARCHAR](35) NOT NULL DEFAULT 'Day'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Operation Type Get"
        ShowErrorMessage()
    End Sub

    Public Function AccountBalance(StudentId As String) As Double
        On Error GoTo RaiseErr
        Dim dblReturn As Double = 0
        Dim strSql As String = "SELECT CAST(SUM(SC_StudentTransactions.Debit - SC_StudentTransactions.Credit) AS DECIMAL (10,2)) AS [Balance] " _
            & "FROM SC_StudentTransactions WHERE SC_StudentTransactions.StudentId = '" & StudentId & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblReturn = CDbl(objReader(0).ToString)
            End If
        End If
        objReader.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Student Balance Fetch"
        ShowErrorMessage()
    End Function

    Public Sub GetStudentNumberAllocationFormular()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM SC_StudentNumberAllocationParms"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("Prefix").ToString) Then strStudentNumberPrefix = objReader("Prefix").ToString
            If Not IsDBNull(objReader("Suffix").ToString) Then strStudentNumberSuffix = objReader("Suffix").ToString
            If Not IsDBNull(objReader("Method").ToString) Then strStudentNumberAllocationMethod = objReader("Method").ToString
            If Not IsDBNull(objReader("AllocationBase").ToString) Then strStudentNumberAllocationBase = objReader("AllocationBase").ToString
            If Not IsDBNull(objReader("Seperator").ToString) Then strStudentNumberSeperator = objReader("Seperator").ToString
            If Not IsDBNull(objReader("SuffixBase").ToString) Then strStudentNumberSuffixBase = objReader("SuffixBase").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Student Number Allocation System"
        ShowErrorMessage()
    End Sub

    Public Function UserDefinedStudentNumber(Optional ByVal StudentClassShortName As String = Nothing) As String
        Dim strReturn As String = Nothing
        If UCase(strStudentNumberAllocationMethod) = "SYSTEM PLUS USER" Then
            If UCase(strStudentNumberAllocationBase) = "CLASS" Then
                Dim intNextNum As Integer = NextStudentClassNumber(StudentClassShortName)
                If UCase(strStudentNumberSuffixBase) = "YEAR" Then
                    strReturn = StudentClassShortName & strStudentNumberSeperator & Format(intNextNum, "000") & _
                        strStudentNumberSeperator & Format(DatePart(DateInterval.Year, Now), "0000")
                Else
                    If String.IsNullOrEmpty(strStudentNumberSuffix) Then
                        strReturn = StudentClassShortName & strStudentNumberSeperator & Format(intNextNum, "000")
                    Else
                        strReturn = StudentClassShortName & strStudentNumberSeperator & Format(intNextNum, "000") & _
                            strStudentNumberSeperator & strStudentNumberSuffix
                    End If
                End If
            Else
                'SYSTEM
                Dim lngNumber As Long = NewStudentNumber()
                If String.IsNullOrEmpty(strStudentNumberSuffix) Then
                    strReturn = strStudentNumberPrefix & strStudentNumberSeperator & CStr(lngNumber)
                Else
                    strReturn = strStudentNumberPrefix & strStudentNumberSeperator & CStr(lngNumber) & _
                        strStudentNumberSeperator & strStudentNumberSuffix
                End If
            End If
        End If
        Return strReturn
    End Function

    Public Function NextStudentClassNumber(ClassShortName As String) As Integer
        Dim intReturn As Integer = 1
        On Error GoTo RaiseErr
        Dim strYear As String = CStr(CInt(Format(DatePart(DateInterval.Year, Now), "0000")))

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SchoolAllocatedNumber FROM SC_Students WHERE ClassName IN " _
            & "(SELECT ClassName FROM SC_Classes WHERE ShortName = '" & ClassShortName & "') ORDER BY SchoolAllocatedNumber DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    Dim strLastNumber As String = objReader(0).ToString
                    Dim strBuffer() As String = Split(strLastNumber, strStudentNumberSeperator)
                    If strBuffer.Length >= 3 Then
                        Dim strNumber As String = Trim(strBuffer(1)) 'Replace(strLastNumber, ClassShortName & strStudentNumberSeperator, "", 1)
                        'strNumber = Replace(strNumber, strStudentNumberSeperator & strYear, "", 1)
                        If IsNumeric(strNumber) Then
                            strNumber = CInt(strNumber) + 1
                            intReturn = CInt(strNumber)
                            Exit While
                        End If
                    End If
                End If
            End If
        End While
        objReader.Close()
        Return intReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Student Number Allocation System"
        ShowErrorMessage()
    End Function

    Public Function GetConvenctionalBillingAmount(ByVal Frequency As String, ByVal StudentClass As String) As Double
        Dim dblReturn As Double = 0
        Dim strSql As String = "SELECT Termly, Monthly, Weekly, Daily, Hourly " _
                        & "FROM SC_PrivateFeeStructure WHERE [Class] = '" & StudentClass & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            Select Case UCase(Frequency)
                Case Is = UCase("Per Term")
                    If IsNumeric(objReader("Termly").ToString) Then
                        dblReturn = CDbl(objReader("Termly").ToString)
                    End If
                Case Is = UCase("Per Month")
                    If IsNumeric(objReader("Monthly").ToString) Then
                        dblReturn = CDbl(objReader("Monthly").ToString)
                    End If
                Case Is = UCase("Per Week")
                    If IsNumeric(objReader("Weekly").ToString) Then
                        dblReturn = CDbl(objReader("Weekly").ToString)
                    End If
                Case Is = UCase("Per Day")
                    If IsNumeric(objReader("Daily").ToString) Then
                        dblReturn = CDbl(objReader("Daily").ToString)
                    End If
                Case Is = UCase("Per Hour")
                    If IsNumeric(objReader("Hourly").ToString) Then
                        dblReturn = CDbl(objReader("Hourly").ToString)
                    End If
            End Select
        End If
        objReader.Close()
        Return dblReturn
    End Function

    Public Sub BilliableSubjectsLimit()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [SubjectsLimit] FROM SC_RemedialSubjectsMaximum", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intBilliableSubjectsLimit = objReader(0).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On maximum number of billiable subjects on remedial lessons feth"
        ShowErrorMessage()
    End Sub

    Public Sub NonConventionalBilling(ByRef ProgressBar1 As ProgressBar)
        On Error GoTo RaiseErr
        Dim intCount As Integer = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Count(StudentId) FROM SC_Students WHERE Status = 'ACTIVE'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intCount = CInt(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        With ProgressBar1
            .Visible = True
            .Maximum = intCount + 10
            .Value = 0
        End With

        objCommand = New Data.OleDb.OleDbCommand("SELECT StudentId, ClassName, BillingCategory, " _
            & "ConventionalOptions, SubjectOptions, BillingAmount FROM SC_Students WHERE Status = 'ACTIVE'", cnn)
        objReader = objCommand.ExecuteReader

        While objReader.Read

            Dim strStudentBillingCategory As String = Nothing
            Dim strFrequency As String = Nothing
            Dim strSubjectChoices As String = Nothing
            Dim dblBillamt As Double = 0

            'If objReader(0).ToString = "102400" Then
            '    MsgBox("here")
            'End If

            If Not IsDBNull(objReader(2).ToString) Then
                strStudentBillingCategory = objReader(2).ToString
            End If
            If Not IsDBNull(objReader(3).ToString) Then
                strFrequency = objReader(3).ToString
            End If
            If Not IsDBNull(objReader(4).ToString) Then
                strSubjectChoices = objReader(4).ToString
            End If
            If Not IsDBNull(objReader(5).ToString) Then
                If IsNumeric(objReader(5).ToString) Then
                    dblBillamt = CDbl(objReader(5).ToString)
                End If
            End If

            Dim strEntryDescription As String = Nothing

            Select Case UCase(strStudentBillingCategory)
                Case Is = UCase("Conventional")
                    dblBillamt = GetConvenctionalBillingAmount(strFrequency, objReader(1).ToString)
                    strEntryDescription = "STUDENT " & UCase(strFrequency) & " PAYMENT"
                Case Is = UCase("Remedial")
                    Dim intNumberOfSubjectsTaken As Integer = 0
                    'Get a count of the subject the student studies
                    Dim MySql As String = "SELECT Count(SubjectName) FROM SC_StudentSubjects WHERE StudentId = " & objReader(0).ToString & ""
                    objCommand = New Data.OleDb.OleDbCommand(MySql, cnn)
                    Dim objReadSubjects As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    If objReadSubjects.HasRows Then
                        objReadSubjects.Read()
                        If Not IsDBNull(objReadSubjects(0).ToString) Then
                            If IsNumeric(objReadSubjects(0).ToString) Then
                                intNumberOfSubjectsTaken = CInt(objReadSubjects(0).ToString)
                            End If
                        End If
                    End If
                    objReadSubjects.Close()

                    If intNumberOfSubjectsTaken > intBilliableSubjectsLimit Then
                        intNumberOfSubjectsTaken = intBilliableSubjectsLimit
                    End If

                    'Get the fees from here
                    MySql = "SELECT Fees FROM SC_SubjectsPaymentsTable WHERE Level = '" & strSubjectChoices & "' AND Subjects = " & intNumberOfSubjectsTaken & ""
                    objCommand = New Data.OleDb.OleDbCommand(MySql, cnn)
                    objReadSubjects = objCommand.ExecuteReader
                    If objReadSubjects.HasRows Then
                        objReadSubjects.Read()
                        If Not IsDBNull(objReadSubjects(0).ToString) Then
                            If IsNumeric(objReadSubjects(0).ToString) Then
                                dblBillamt = CDbl(objReadSubjects(1).ToString)
                            End If
                        End If
                    Else
                        dblBillamt = 0
                    End If
                    objReadSubjects.Close()
                    strEntryDescription = "FEE PAYMENT FOR " & UCase(intNumberOfSubjectsTaken) & " SUBJECTS"
                Case Else
                    strEntryDescription = "STUDENT " & UCase(strStudentBillingCategory) & " COMPUTED FEES PAYMENT"
            End Select

            If dblBillamt <> 0 Then
                Dim strSql As String = "INSERT INTO SC_StudentTransactions (StudentId, Description, Debit, " _
                    & "UserName, TransactionDate, CostCode, ReceiptNo, SchoolTerm, TermYear) VALUES " _
                    & "('" & objReader(0).ToString & "', '" & strEntryDescription & "', " _
                    & "" & dblBillamt & ", '" & strUserName & "', '" & Format(dtSetDate, "dd-MMM-yyyy") & "', " _
                    & "'', 0, '" & MonthName(DatePart(DateInterval.Month, dtSetDate), False) & "', " _
                    & "" & Format(DatePart(DateInterval.Year, dtSetDate), "0000") & ")"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If

            ProgressBar1.Value = ProgressBar1.Value + 1

        End While
        objReader.Close()
        ProgressBar1.Value = ProgressBar1.Maximum

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On non conventional billing"
        ShowErrorMessage()
    End Sub

    Public Function PastImmediateTransactions(ByVal StudentNumber As String) As ArrayList
        Dim arrReturn As New ArrayList
        arrReturn.Add(Nothing)
        arrReturn.Add(Nothing)
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT TransactionDate, SUM(Credit) AS [Credit] " _
            & "FROM SC_StudentTransactions a WHERE  StudentId = '" & StudentNumber & "' AND Credit > 0 AND " _
            & "TransactionDate = (SELECT MAX(TransactionDate) FROM SC_StudentTransactions b " _
            & "WHERE a.StudentId = b.StudentId) GROUP BY TransactionDate", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If IsDate(objReader(0).ToString) Then
                    arrReturn.Item(0) = Format(CDate(objReader(0).ToString), "dd-MMM-yyyy")
                End If
            End If
            If Not IsDBNull(objReader(1).ToString) Then
                If IsNumeric(objReader(1).ToString) Then
                    arrReturn.Item(1) = CDbl(objReader(1).ToString)
                End If
            End If
        End If
        objReader.Close()
        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On  past immediate financial transactions fetch"
        ShowErrorMessage()
    End Function

    Public Sub GetSpecialNotes()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Notes FROM SC_SpecialNotes"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    strReceiptSpecialNotes = objReader(0).ToString
                End If
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On receipt notes fetch"
        ShowErrorMessage()
    End Sub

End Module
