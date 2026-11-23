Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module modEmployeeMasterFilePrint

    Dim strBlank As String = " |FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"

    Public Sub PrintMasterFileData()
        On Error GoTo RaiseErr
        Dim arrPrintDetails As New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [EmployeeNo],[LastName],[FirstName]," _
            & "[OtherNames],[IdNumber],[Gender],CONVERT(NVARCHAR, BirthDate, 105) AS [BirthDate], " _
            & "[MaritalStatus],[Address1],[Address2]," _
            & "[Address3],[Address4],[Telephone],[Cellphone],[EmailAddress],[ClockNo],[DirAmt]," _
            & "[DirPercent],[DischDate],[DischRsn],[Inits],[StopFrom],[StopTo],[TaxCode]," _
            & "[TaxDependents],[TaxRef],[Title],[Status] FROM EmployeeMaster", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strHeaderLine As String = MasterHeader(objReader("EmployeeNo"), objReader("LastName"),
                objReader("FirstName"), objReader("OtherNames"))
            arrPrintDetails.Add(strHeaderLine)
            '
            'Print the ID Number, Gender and date of birth
            '
            Dim strIdNumber = Nothing, strGender As String = Nothing, strDob As String = Nothing
            If Not IsDBNull(objReader("IdNumber").ToString) Then strIdNumber = objReader("IdNumber").ToString
            If Not IsDBNull(objReader("Gender").ToString) Then strIdNumber = objReader("Gender").ToString
            If Not IsDBNull(objReader("BirthDate").ToString) Then strIdNumber = objReader("BirthDate").ToString
            Dim strLine2 As String = "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>" _
                & "ID NUMBER|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>" _
                & UCase(strIdNumber) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>" _
                & "GENDER|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>" _
                & UCase(strGender) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>" _
                & "DOB|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>" _
                & UCase(strDob) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
            arrPrintDetails.Add(strLine2)

            '
            'Print the ID Number, Gender and date of birth
            '
            Dim Address1 As String = Nothing, strMaritalStatus As String = Nothing, strDirectiveAmt As String = "0.00"
            If Not IsDBNull(objReader("Address1").ToString) Then Address1 = objReader("Address1").ToString
            If Not IsDBNull(objReader("MaritalStatus").ToString) Then strMaritalStatus = objReader("MaritalStatus").ToString
            If IsNumeric(objReader("DirAmt").ToString) Then strDirectiveAmt = Format(CDbl(objReader("DirAmt").ToString), "##0.00")
            Dim strLine3 As String = "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>" _
                & "ADDRESS|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>" _
                & UCase(Address1) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>" _
                & "MARITAL STATUS|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>" _
                & UCase(strMaritalStatus) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>" _
                & "DIR. AMT|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>" _
                & UCase(strDirectiveAmt) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
            arrPrintDetails.Add(strLine3)

        End While
        objReader.Close()

        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        'Request for print properties
        Dim prnt As New PrintDialog
        prnt.ShowDialog()

        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = arrPrintDetails.Count
            .intNumberOfColumns = 7
            .strColumnHeaders = " | | | | | | "
            .strColumnWidths = "60|120|120|120|120|60|60"
            .strFooterCaption = "Employee Master File"
            .strMainCaption = UCase("MASTER FILE PRINT")
            .strMainHeader2 = "EMPLOYEE FULL MASTER FILE DETAILS PRINT"
            .strMainHeader3 = ""
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .HeaderFont = New Font("Verdana", 10, FontStyle.Bold)
            .FooterFont = New Font("Verdana", 6, FontStyle.Bold)
            .boolGenericReport = False
            .strPrintValues = strPrintDetails
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
        End With
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Master File Print Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Function MasterHeader(ByVal strEmployeeNo As String, ByVal strLastName As String, _
           ByVal strFirstName As String, ByVal strOtherNames As String) As String

        Dim strEmployeeNoData As String = UCase(strEmployeeNo) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        Dim strEmployeeSurnameData As String = UCase(strLastName) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        Dim strEmployeeNameData As String = UCase(strFirstName) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        Dim strEmployeeOtherNamesData As String = UCase(strOtherNames) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        Return strEmployeeNoData & strEmployeeSurnameData & strEmployeeNameData & strEmployeeOtherNamesData & strBlank & strBlank & Mid(strBlank, 1, (strBlank.Length - 4))
    End Function


End Module
