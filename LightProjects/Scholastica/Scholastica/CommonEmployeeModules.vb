Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module CommonEmployeeModules

    Public Sub PrintFullMasterFileDetails(ByVal strEmployeeNumber As String)
        On Error GoTo RaiseErr
        '
        '**** PRINTING LOGIC IN GENERAL ****
        '
        '1 - Get the employee Main Details
        '2 - Get the employee contact details
        '3 - Get the employee bank details
        '4 - Get the employee employment details
        '5 - Get the employee payroll codes with values greater than 0

        '**** CREATING A VIRTUAL JOIN FOR ALL THE ****
        '
        'Load the employee file records into a virtual listbox
        'as you loop through the master file record, search the list box and grab data where employee number matches
        'For the contacts, banking and employment, append the records to the master record line
        '
        'arrMasteDetails = New ArrayList

        Dim strSql As String = "SELECT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName, " _
            & "EmployeeMaster.FirstName, EmployeeMaster.OtherNames, EmployeeMaster.IdNumber, " _
            & "EmployeeMaster.Gender, CONVERT(NVARCHAR, EmployeeMaster.BirthDate, 105) AS BirthDate, " _
            & "EmployeeMaster.MaritalStatus, " _
            & "EmployeeMaster.Address1, EmployeeMaster.Address2, EmployeeMaster.Address3, " _
            & "EmployeeMaster.Address4, EmployeeMaster.Telephone, EmployeeMaster.Cellphone, " _
            & "EmployeeMaster.EmailAddress, EmployeeMaster.ClockNo, EmployeeMaster.DirAmt, " _
            & "EmployeeMaster.DirPercent, CONVERT(NVARCHAR, EmployeeMaster.DischDate, 105) as " _
            & "DischDate, EmployeeMaster.DischRsn, " _
            & "EmployeeMaster.Inits, EmployeeMaster.StopFrom, EmployeeMaster.StopTo, " _
            & "EmployeeMaster.TaxCode, EmployeeMaster.TaxDependents, EmployeeMaster.TaxRef, " _
            & "EmployeeMaster.Title, EmployeeMaster.Status, Employment.EmployeeNo, " _
            & "CONVERT(NVARCHAR, Employment.HireDate, 105) AS HireDate, Employment.JobTitle, " _
            & "Employment.EmploymentStatus, " _
            & "Employment.Department, Employment.CostCenter, Employment.PayPoint, " _
            & "EmployeeContacts.EmployeeNo, EmployeeContacts.ContactPerson, " _
            & "EmployeeContacts.Relationship, EmployeeContacts.Address1 as ConAddr1, " _
            & "EmployeeContacts.Address2 as ConAddr2, EmployeeContacts.Address3 as ConAddr3, " _
            & "EmployeeContacts.Address4 as ConAddr4, EmployeeContacts.Telephone as ConPhone, " _
            & "EmployeeContacts.Cellphone as ConCellphone, EmployeeContacts.EmailAddress as ConEmail, " _
            & "EmployeeBanks.BankCode, EmployeeBanks.AccountType, EmployeeBanks.AccountHolder, " _
            & "EmployeeBanks.AccountNumber, EmployeeBanks.PayMethod  FROM EmployeeMaster LEFT JOIN " _
            & "Employment ON EmployeeMaster.EmployeeNo = Employment.EmployeeNo LEFT JOIN EmployeeContacts " _
            & "ON EmployeeMaster.EmployeeNo = EmployeeContacts.EmployeeNo LEFT JOIN EmployeeBanks ON " _
            & "EmployeeMaster.EmployeeNo = EmployeeBanks.EmployeeNo WHERE " _
            & "EmployeeMaster.EmployeeNo = '" & strEmployeeNumber & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        'Array to hold the full details
        If objReader.HasRows Then
            objReader.Read()
            Dim strColumn1 As String = Nothing, strColumn2 As String = Nothing, strColumn3 As String = Nothing
            strColumn1 = strEmployeeNumber.ToUpper
            If Not IsDBNull(objReader("ClockNo").ToString) Then strColumn2 = UCase(objReader("ClockNo").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("ContactPerson").ToString) Then strColumn3 = UCase(objReader("ContactPerson").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("EMP.NO.;" & strColumn1 & ";CLOCK NO;" & strColumn2 & ";KIN NAME;" & strColumn3)

            If Not IsDBNull(objReader("IdNumber").ToString) Then strColumn1 = UCase(objReader("ClockNo").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("DirAmt").ToString) Then strColumn2 = UCase(objReader("DirAmt").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("Relationship").ToString) Then strColumn3 = UCase(objReader("Relationship").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("ID NUMBER;" & strColumn1 & ";DIR. AMT;" & strColumn2 & ";RELATION;" & strColumn3)

            If Not IsDBNull(objReader("LastName").ToString) Then strColumn1 = UCase(objReader("LastName").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("DirPercent").ToString) Then strColumn2 = UCase(objReader("DirPercent").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("ConAddr1").ToString) Then strColumn3 = UCase(objReader("ConAddr1").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("LAST NAME;" & strColumn1 & ";DIR. %;" & strColumn2 & ";CON ADDR-1;" & strColumn3)

            If Not IsDBNull(objReader("FirstName").ToString) Then strColumn1 = UCase(objReader("FirstName").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("TaxCode").ToString) Then strColumn2 = UCase(objReader("TaxCode").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("ConAddr2").ToString) Then strColumn3 = UCase(objReader("ConAddr2").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("FIRST NAME;" & strColumn1 & ";TAX CODE;" & strColumn2 & ";CON ADDR-2;" & strColumn3)

            If Not IsDBNull(objReader("OtherNames").ToString) Then strColumn1 = UCase(objReader("OtherNames").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("DischDate").ToString) Then strColumn2 = UCase(objReader("DischDate").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("ConAddr3").ToString) Then strColumn3 = UCase(objReader("ConAddr3").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("OTHER NAMES;" & strColumn1 & ";TERM DTE;" & strColumn2 & ";CON ADDR-3;" & strColumn3)

            If Not IsDBNull(objReader("Title").ToString) Then strColumn1 = UCase(objReader("Title").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("DischRsn").ToString) Then strColumn2 = UCase(objReader("DischRsn").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("ConAddr4").ToString) Then strColumn3 = UCase(objReader("ConAddr4").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("TITLE;" & strColumn1 & ";TERM RSN;" & strColumn2 & ";CON ADDR-4;" & strColumn3)

            If Not IsDBNull(objReader("Gender").ToString) Then strColumn1 = UCase(objReader("Gender").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("StopFrom").ToString) Then strColumn2 = UCase(objReader("StopFrom").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("ConPhone").ToString) Then strColumn3 = UCase(objReader("ConPhone").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("GENDER;" & strColumn1 & ";STP FROM;" & strColumn2 & ";CON PHONE;" & strColumn3)

            If Not IsDBNull(objReader("BirthDate").ToString) Then strColumn1 = UCase(objReader("BirthDate").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("StopTo").ToString) Then strColumn2 = UCase(objReader("StopTo").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("ConCellPhone").ToString) Then strColumn3 = UCase(objReader("ConCellphone").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("DOB;" & strColumn1 & ";STP TO;" & strColumn2 & ";CON CELL;" & strColumn3)

            If Not IsDBNull(objReader("MaritalStatus").ToString) Then strColumn1 = UCase(objReader("MaritalStatus").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("TaxDependents").ToString) Then strColumn2 = UCase(objReader("TaxDependents").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("ConEmail").ToString) Then strColumn3 = UCase(objReader("ConEmail").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("MAR. STATUS;" & strColumn1 & ";TAX DEP;" & strColumn2 & ";CON EMAIL;" & strColumn3)

            If Not IsDBNull(objReader("Address1").ToString) Then strColumn1 = UCase(objReader("Address1").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("TaxRef").ToString) Then strColumn2 = UCase(objReader("TaxRef").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("BankCode").ToString) Then strColumn3 = UCase(objReader("BankCode").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("ADDR-1;" & strColumn1 & ";TAX REF;" & strColumn2 & ";BANK CDE;" & strColumn3)

            If Not IsDBNull(objReader("Address2").ToString) Then strColumn1 = UCase(objReader("Address2").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("HireDate").ToString) Then strColumn2 = UCase(objReader("HireDate").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("AccountNumber").ToString) Then strColumn3 = UCase(objReader("AccountNumber").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("ADDR-2;" & strColumn1 & ";HIRE DTE;" & strColumn2 & ";ACC. NUM;" & strColumn3)

            If Not IsDBNull(objReader("Address3").ToString) Then strColumn1 = UCase(objReader("Address3").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("JobTitle").ToString) Then strColumn2 = UCase(objReader("JobTitle").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("AccountType").ToString) Then strColumn3 = UCase(objReader("AccountType").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("ADDR-3;" & strColumn1 & ";JOB TITLE;" & strColumn2 & ";ACC. TYPE;" & strColumn3)

            If Not IsDBNull(objReader("Address4").ToString) Then strColumn1 = UCase(objReader("Address4").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("EmploymentStatus").ToString) Then strColumn2 = UCase(objReader("EmploymentStatus").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("AccountHolder").ToString) Then strColumn3 = UCase(objReader("AccountHolder").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("ADDR-4;" & strColumn1 & ";EMP STATUS;" & strColumn2 & ";ACC. HOLDER;" & strColumn3)

            If Not IsDBNull(objReader("Telephone").ToString) Then strColumn1 = UCase(objReader("Telephone").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("Department").ToString) Then strColumn2 = UCase(objReader("Department").ToString) Else strColumn2 = Nothing
            If Not IsDBNull(objReader("PayMethod").ToString) Then strColumn3 = UCase(objReader("PayMethod").ToString) Else strColumn3 = Nothing
            arrMasteDetails.Add("TELEPHONE;" & strColumn1 & ";DEPARTMENT;" & strColumn2 & ";PAY METHOD;" & strColumn3)

            strColumn3 = Nothing
            If Not IsDBNull(objReader("Cellphone").ToString) Then strColumn1 = UCase(objReader("Cellphone").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("CostCenter").ToString) Then strColumn2 = UCase(objReader("CostCenter").ToString) Else strColumn2 = Nothing
            arrMasteDetails.Add("CELL NUMBER;" & strColumn1 & ";COST CENTER;" & strColumn2 & ";;" & strColumn3)

            strColumn3 = Nothing
            If Not IsDBNull(objReader("EmailAddress").ToString) Then strColumn1 = UCase(objReader("EmailAddress").ToString) Else strColumn1 = Nothing
            If Not IsDBNull(objReader("PayPoint").ToString) Then strColumn2 = UCase(objReader("PayPoint").ToString) Else strColumn2 = Nothing
            arrMasteDetails.Add("E-MAIL;" & strColumn1 & ";PAY POINT;" & strColumn2 & ";;" & strColumn3)

        End If
        objReader.Close()
        '
        'Get the master file code details. Copy concept from the Payroll Register print
        '
        Dim arrPrintCodeValues As New ArrayList
        objCommand = New Data.OleDb.OleDbCommand("SELECT EmployeeCodes.Amount, SystemCodes.CodeNo, " _
            & "SystemCodes.Description  FROM EmployeeCodes LEFT JOIN SystemCodes ON EmployeeCodes.CodeNo " _
            & "= SystemCodes.CodeNo WHERE EmployeeCodes.EmployeeNo = '" & strEmployeeNumber & "' AND " _
            & "SystemCodes.DisplayStatus = 'Y' ORDER BY SystemCodes.CodeNo", cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            arrMasteDetails.Add(" ; ; ; ; ; ")
            arrMasteDetails.Add("**** PAYMENTS ****; ; ; ; ; ")
            arrMasteDetails.Add(" ; ; ; ; ; ")
            While objReader.Read
                Dim strCodeNo As String = "0000"
                Dim strCodeDescription As String = Nothing
                Dim strCodeValue As String = "0"
                If IsNumeric(objReader(0).ToString) Then
                    If CDbl(objReader(0).ToString) <> 0 Then
                        If IsNumeric(objReader(1).ToString) Then strCodeNo = Format(CInt(objReader(1).ToString), "0000")
                        If Not IsDBNull(objReader(2).ToString) Then strCodeDescription = UCase(objReader(2).ToString)
                        strCodeValue = CStr(Format(CDbl(objReader(0).ToString), "##0.00"))
                        arrPrintCodeValues.Add(strCodeNo & ";" & strCodeDescription & ";" & strCodeValue)
                    End If
                End If
            End While
        End If
        objReader.Close()

        'First format the amount string so that it is the same size of 10 characters including decimals
        Dim z As Integer = 0
        For z = 0 To arrPrintCodeValues.Count - 1
            Dim strBuffer() As String = Split(arrPrintCodeValues.Item(z), ";")
            strBuffer(2) = Space(16 - strBuffer(2).Length) & strBuffer(2)
            arrPrintCodeValues.Item(z) = strBuffer(0) & ";" & strBuffer(1) & ";" & strBuffer(2)
        Next

        'Make sure that the codes are printed in sets of twos
        Dim intRecordsCount As Integer = arrPrintCodeValues.Count
        Dim intIteration As Integer = 0
        If intRecordsCount Mod 2 = 0 Then
            intIteration = intRecordsCount / 2
        Else
            arrPrintCodeValues.Add(";;")
            intRecordsCount = intRecordsCount + 1
            intIteration = intRecordsCount / 2
        End If

        'Dim strPrintDetails(0 To (intIteration - 1)) As String
        Dim y As Integer = 0
        For p = 0 To intIteration - 1
            arrMasteDetails.Add(arrPrintCodeValues.Item(y) & ";" & arrPrintCodeValues(y + 1))
            y = y + 2
        Next
        '
        'Get the employee flags
        '
        strSql = "SELECT SystemFlagNames.FlagNo, SystemFlagNames.FlagName, " _
            & "EmployeeFlags.Flag  FROM SystemFlagNames LEFT JOIN EmployeeFlags ON " _
            & "SystemFlagNames.FlagNo = EmployeeFlags.OrdinalNo " _
            & "WHERE EmployeeFlags.EmployeeNo = '" & strEmployeeNumber & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        Dim arrFlags As New ArrayList
        While objReader.Read
            Dim strFlagName As String = Nothing
            Dim strFlagValue As String = Nothing
            If Not IsDBNull(objReader("FlagName").ToString) Then strFlagName = objReader("FlagName").ToString
            If Not IsDBNull(objReader("Flag").ToString) Then strFlagValue = objReader("Flag").ToString
            arrFlags.Add(strFlagName & ";" & strFlagValue)
        End While
        objReader.Close()
        '
        'Get the employee reference numbers
        '
        strSql = "SELECT SystemReferences.ReferenceName, EmployeeReferences.Reference FROM " _
            & "SystemReferences LEFT JOIN EmployeeReferences ON SystemReferences.OrdinalNo = " _
            & "EmployeeReferences.OrdinalNo AND EmployeeReferences.EmployeeNo = " _
            & "'" & strEmployeeNumber & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        Dim arrRefs As New ArrayList
        While objReader.Read
            Dim strRefName As String = Nothing
            Dim strRefValue As String = Nothing
            If Not IsDBNull(objReader("ReferenceName").ToString) Then strRefName = objReader("ReferenceName").ToString
            If Not IsDBNull(objReader("Reference").ToString) Then strRefValue = objReader("Reference").ToString
            arrRefs.Add(strRefName & ";" & strRefValue)
        End While
        objReader.Close()
        '
        'Get the date values
        '
        strSql = "SELECT SystemDates.DateName, CONVERT(NVARCHAR, EmployeeDates.DateValue, 105) " _
            & "AS DateValue  FROM SystemDates LEFT JOIN EmployeeDates ON SystemDates.OrdinalNo = " _
            & "EmployeeDates.OrdinalNo WHERE EmployeeDates.EmployeeNo = '" & strEmployeeNumber & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        Dim arrDates As New ArrayList
        While objReader.Read
            Dim strDateName As String = Nothing
            Dim strDateValue As String = Nothing
            If Not IsDBNull(objReader("DateName").ToString) Then strDateName = objReader("DateName").ToString
            If Not IsDBNull(objReader("DateValue").ToString) Then strDateValue = objReader("DateValue").ToString
            arrDates.Add(strDateName & ";" & strDateValue)
        End While
        objReader.Close()
        '
        'Check that the last item entries are equal in length. If not make them equal
        Dim intMaxLength As Integer = 0
        If arrFlags.Count > arrRefs.Count Then
            intMaxLength = arrFlags.Count
        Else
            intMaxLength = arrRefs.Count
        End If
        If intMaxLength < arrDates.Count Then
            intMaxLength = arrDates.Count
        End If

        For g = (arrFlags.Count + 1) To intMaxLength
            arrFlags.Add(" ; ")
        Next
        For g = (arrRefs.Count + 1) To intMaxLength
            arrRefs.Add(" ; ")
        Next
        For g = (arrDates.Count + 1) To intMaxLength
            arrDates.Add(" ; ")
        Next
        '
        'Now add the values to the master array. First add the headers and the blank lines
        '
        arrMasteDetails.Add(" ; ; ; ; ; ")
        arrMasteDetails.Add("**** FLAGS ****; ;**** REF.NOs. ****; ;**** DATES ****; ")
        arrMasteDetails.Add(" ; ; ; ; ; ")
        For g = 0 To intMaxLength - 1
            arrMasteDetails.Add(arrFlags.Item(g) & ";" & arrRefs.Item(g) & ";" & arrDates.Item(g))
        Next
        'Add 3 blank lines after
        For i = 0 To 2
            arrMasteDetails.Add(" ; ; ; ; ; ")
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Employee Master File Details Print"
        ShowErrorMessage()
    End Sub

    Public Sub GenerateMasterFileReport()

        '
        'Now that we have related the tables, we can start printing of the master details
        '
        Dim i As Integer = 0
        Dim strPrintDetails(0 To arrMasteDetails.Count - 1) As String
        For i = 0 To arrMasteDetails.Count - 1
            strPrintDetails(i) = arrMasteDetails.Item(i)
        Next

        gwt_comm.GetReportTaxPeriodNumber()

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "PERSONAL INFO| |TAXES/JOB INFO| |KIN/BANK INFO| "
            .strColumnAlignments = "0|0|0|0|0|0|"
            .strColumnWidths = "90|120|90|120|90|120"
            .strFooterCaption = "Employee full master file details " & Now
            .strMainCaption = UCase(strDefaultReportHeader)
            .strMainHeader2 = "MASTER FILE FULL DETAILS"
            .strMainHeader3 = "PERIOD NO " & intCurrentRunNumber
            .strColumnTotals = "NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("LightGray")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim ppdUserReports As New PrintPreviewDialog
        ppdUserReports.Document = rpt
        ppdUserReports.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Masterfile Details Print"
        ShowErrorMessage()
    End Sub

End Module
