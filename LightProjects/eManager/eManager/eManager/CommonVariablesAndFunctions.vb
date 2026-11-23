Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Net
Imports System.Management
Imports System.Management.Instrumentation
Imports System.Drawing.Printing
Imports ComponentFactory.Krypton.Toolkit
Imports Microsoft.Office.Interop
Imports System.Data.SqlServerCe

Module CommonVariablesAndFunctions

    Public boolPrintSelective As Boolean
    Public boolPrintZeroPayslips As Boolean
    Public intStartNumber As Integer
    Public intEndNumber As Integer
    Public strSortOrder As String
    Public strCompanyAddressInformation As String

    Public strFileName As String
    Public boolOutputToExcel As Boolean
    Public boolToExcelOnly As Boolean
    Public arrCodeKey As ArrayList

    Public intSelectedTransaction As Integer
    Public sCustomerBankAccount As String
    Public sCustomerBankCode As String
    Public boolAbort As Boolean
    Public strErrorMessages As String
    Public newFormColor As Color
    Public boolConnectionStatus As Boolean
    Public strConnection As String = Nothing
    Public cnn As Data.OleDb.OleDbConnection
    Public boolEditStatus As Boolean
    Public intSelectedTransactionId As Integer
    Public boolApplicationRunning As Boolean
    Public strUserName As String
    Public boolUserConnectionSuccess As Boolean
    Public boolApplicationStarting As Boolean
    Public boolCancelValidation As Boolean
    Public arrSelectedItems As ArrayList
    Public arrTaxBands As ArrayList
    Public strSelectedDirectorDetails As String
    Public strGrossupTax As String = "NO"
    Public boolEmployeeCall As Boolean
    Public strSelectedEmployee As String
    Public strStatementDate As String

    Public boolPrintSelection As Boolean

    Public boolErrorFlag As Boolean

    Public strCompanyName As String
    Public strCompanyAddress1 As String
    Public strCompanyAddress2 As String
    Public strCompanyAddress3 As String
    Public strCompanyAddress4 As String
    Public strCompanyTelephone As String
    Public strCompanyFaxNumber As String
    Public strCompanyEmailAddress As String
    Public strCompanyPayeNumber As String

    Public strLogoPath As String
    Public strCompanyVatNumber As String

    Public intLogoXposition As Integer = 100
    Public intLogoYposition As Integer = 25
    'intWatermarkXposition
    Public intWatermarkXposition As Integer = 250
    Public intWatermarkYposition As Integer = 350

    Public strWatermarkPath As String
    Public strUseWatermark As String

    Public intBrandsYposition As Integer
    Public intBrandsXposition As Integer

    Public strBrandImage1 As String
    Public strBrandImage2 As String
    Public strBrandImage3 As String
    Public strBrandImage4 As String
    Public strBrandsTiling As String
    Public strCompanyRegistrationNumber As String
    Public strCompanyContactCellNumber As String
    Public strDocumentPrefix As String
    Public strPublicInvoiceOrderNumber As String
    Public strCurrentUserFullNames As String
    Public strCompanyBranchCode As String
    Public strCompanyBankName As String
    Public strCompanyAccountNumber As String
    Public strCompanyCountry As String

    'Declare and set the default fonts
    Public fntHeaderFont As New System.Drawing.Font("Calibri", 7, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    Public fntDetailsFont As New System.Drawing.Font("Calibri", 7, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Public fntFooterFont As New System.Drawing.Font("Calibri", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Public fntFooterFontItalic As New System.Drawing.Font("Times New Roman", 6, Drawing.FontStyle.Italic, Drawing.GraphicsUnit.Point)
    Public fntDetailsFontBold As New System.Drawing.Font("Arial", 7, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Public strSessionPrinter As String

    'Bank Extract

    Public dblDebits As Double
    Public dblCredits As Double
    Public intDebits As Integer
    Public intCredits As Integer

    Public dblEmployeeTaxRate As Double = 0
    Public dblBaseCredit As Double = 0

    Public strRequestForReceiptPrinter As String = "YES"

    Public StartDate As Date
    Public EndDate As Date

    Public Sub OpenDatabaseConnection()

        'Get the database connection string
        boolAbort = False
        If Not File.Exists(Application.StartupPath & "\PayCatalogue.txt") Then
            MsgBox("The application could not locate the database. Please contact your service provider", _
                MsgBoxStyle.Critical, "Application connection Failure")
            boolAbort = True
            End
        Else
            boolConnectionStatus = True
            boolAbort = False
            StartUpDatabase()
            If boolAbort = True Then Exit Sub
            If boolConnectionStatus = False Then End
            UpdateDatabase()
            'AssignCompanyDetails()
        End If
    End Sub

    Public Sub StartUpDatabase()
        Try

            If File.Exists(Application.StartupPath & "\PayCatalogue.txt") Then
                Dim objReader As New StreamReader(Application.StartupPath & "\PayCatalogue.txt")
                Dim strLine As String = objReader.ReadLine
                objReader.Close()
                strConnection = strLine
            Else
                MessageBox.Show("Application could not locate the database configuration file", "Missing Database Configurations", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End
            End If

            'Dim engine As New SqlCeEngine("Data Source = |DataDirectory|\eManager_23112016B.sdf")
            'engine.Repair(Nothing, RepairOption.DeleteCorruptedRows)
            'engine.Repair("Data Source = |DataDirectory|\eManager_23112016B.sdf; LCID=1033; Case Sensitive=true;", RepairOption.RecoverAllPossibleRows)

            cnn = New OleDb.OleDbConnection(strConnection)
            cnn.Open()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Database Connection Failure")
            boolConnectionStatus = False
        End Try
    End Sub

    Public Sub UpdateDatabase()
        On Error GoTo RaiseErr

        If TableExists("RunFile") = False Then CreateRunTable()

        'Create the added columns for runfile
        If CheckColumnExistence("RunFile", "ColumnSide") = False Then
            Dim strSql = "ALTER TABLE RunFile ADD [ColumnSide][INT] NOT NULL DEFAULT 0"
            Dim dbCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            dbCommand.ExecuteNonQuery()
        End If
        If CheckColumnExistence("RunFile", "OriginalTransDate") = False Then
            Dim strSql = "ALTER TABLE RunFile ADD [OriginalTransDate][DateTime] NULL"
            Dim dbCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            dbCommand.ExecuteNonQuery()
        End If

        If CheckColumnExistence("RunFile", "GrossUp") = False Then
            Dim strSql = "ALTER TABLE RunFile ADD [GrossUp][FLOAT] NOT NULL DEFAULT 0"
            Dim dbCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            dbCommand.ExecuteNonQuery()
        End If
        If CheckColumnExistence("RunFile", "BoardTax") = False Then
            Dim strSql = "ALTER TABLE RunFile ADD [BoardTax][FLOAT] NOT NULL DEFAULT 0"
            Dim dbCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            dbCommand.ExecuteNonQuery()
        End If
        If CheckColumnExistence("RunFile", "PAYE") = False Then
            Dim strSql = "ALTER TABLE RunFile ADD [PAYE][FLOAT] NOT NULL DEFAULT 0"
            Dim dbCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            dbCommand.ExecuteNonQuery()
        End If
        If CheckColumnExistence("RunFile", "AidsLevy") = False Then
            Dim strSql = "ALTER TABLE RunFile ADD [AidsLevy][FLOAT] NOT NULL DEFAULT 0"
            Dim dbCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            dbCommand.ExecuteNonQuery()
        End If
        If CheckColumnExistence("RunFile", "Deductions") = False Then
            Dim strSql = "ALTER TABLE RunFile ADD [Deductions][FLOAT] NOT NULL DEFAULT 0"
            Dim dbCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            dbCommand.ExecuteNonQuery()
        End If
        If CheckColumnExistence("PaymentCodes", "GrossUpStatus") = False Then
            Dim strSql = "ALTER TABLE PaymentCodes ADD [GrossUpStatus][NVARCHAR] (1) NOT NULL DEFAULT 'Y'"
            Dim dbCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            dbCommand.ExecuteNonQuery()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Database Update"
        ShowErrorMessage()
    End Sub

    Public Function MediumDate(ByVal intDay As Integer, ByVal intMonth As Integer, ByVal intYear As Integer) As String
        Dim strReturn As String
        Dim strMonthInString As String = UCase(Mid(MonthName(intMonth), 1, 3))
        strReturn = intDay & "-" & strMonthInString & "-" & intYear
        Return strReturn
    End Function

    Public Function IsGroossUpCode(ByVal CodeNo As Integer) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT GrossUpStatus FROM PaymentCodes WHERE CodeNo = " & CodeNo & "", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(objReader(0).ToString) = "Y" Then
                    boolReturn = True
                End If
            End If
            Exit While
        End While
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On gross up status fetch"
        ShowErrorMessage()
    End Function

    Public Function getMonth(ByVal intMth As Integer) As String
        Dim strReturn As String = "JAN"
        Select Case intMth
            Case Is = 1
                strReturn = "JAN"
            Case Is = 2
                strReturn = "FEB"
            Case Is = 3
                strReturn = "MAR"
            Case Is = 4
                strReturn = "APR"
            Case Is = 5
                strReturn = "MAY"
            Case Is = 6
                strReturn = "JUN"
            Case Is = 7
                strReturn = "JUL"
            Case Is = 8
                strReturn = "AUG"
            Case Is = 9
                strReturn = "SEP"
            Case Is = 10
                strReturn = "OCT"
            Case Is = 11
                strReturn = "NOV"
            Case Is = 12
                strReturn = "DEC"
        End Select
        Return strReturn
    End Function

    Public Function TabControlColor() As DevComponents.DotNetBar.eTabItemColor
        Dim RandomNumber As New Random
        Dim p As Integer = RandomNumber.Next(1, 16)
        Dim tabColor As New DevComponents.DotNetBar.eTabItemColor
        Select Case p
            Case Is = 1
                tabColor = DevComponents.DotNetBar.eTabItemColor.Apple
                newFormColor = Color.BlanchedAlmond
            Case Is = 2
                tabColor = DevComponents.DotNetBar.eTabItemColor.Blue
                newFormColor = Color.MediumSlateBlue
            Case Is = 3
                tabColor = DevComponents.DotNetBar.eTabItemColor.BlueMist
                newFormColor = Color.MediumSlateBlue()
            Case Is = 4
                tabColor = DevComponents.DotNetBar.eTabItemColor.Cyan
                newFormColor = Color.Cyan
            Case Is = 4
                tabColor = DevComponents.DotNetBar.eTabItemColor.Default
                newFormColor = Color.MediumSlateBlue
            Case Is = 6
                tabColor = DevComponents.DotNetBar.eTabItemColor.Green
                newFormColor = Color.Green
            Case Is = 7
                tabColor = DevComponents.DotNetBar.eTabItemColor.Lemon
                newFormColor = Color.LemonChiffon
            Case Is = 8
                tabColor = DevComponents.DotNetBar.eTabItemColor.Magenta
                newFormColor = Color.Magenta
            Case Is = 9
                tabColor = DevComponents.DotNetBar.eTabItemColor.Orange
                newFormColor = Color.Orange
            Case Is = 10
                tabColor = DevComponents.DotNetBar.eTabItemColor.Purple
                newFormColor = Color.Purple
            Case Is = 11
                tabColor = DevComponents.DotNetBar.eTabItemColor.PurpleMist
                newFormColor = Color.MediumPurple
            Case Is = 12
                tabColor = DevComponents.DotNetBar.eTabItemColor.Red
                newFormColor = Color.Red
            Case Is = 13
                tabColor = DevComponents.DotNetBar.eTabItemColor.Silver
                newFormColor = Color.Silver
            Case Is = 14
                tabColor = DevComponents.DotNetBar.eTabItemColor.Tan
                newFormColor = Color.Tan
            Case Is = 15
                tabColor = DevComponents.DotNetBar.eTabItemColor.Teal
                newFormColor = Color.Teal
            Case Is = 16
                tabColor = DevComponents.DotNetBar.eTabItemColor.Yellow
                newFormColor = Color.Yellow
            Case Else
                tabColor = DevComponents.DotNetBar.eTabItemColor.Default
                newFormColor = Color.MediumSlateBlue
        End Select
        Return tabColor

    End Function

    Public Sub DrawStringInBoxRight(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
 ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal fnt As Font, ByVal BrushColor As System.Drawing.Brush)
        Dim sfCurrent As New StringFormat()
        Dim recCurrent As New RectangleF(x1, y1, x2, y2)
        sfCurrent.Alignment = StringAlignment.Far
        ev.Graphics.DrawString(s, fnt, BrushColor, recCurrent, sfCurrent)
    End Sub

    Public Sub DrawStringInBoxLeft(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
     ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal fnt As Font, ByVal BrushColor As System.Drawing.Brush)
        Dim sfCurrent As New StringFormat()
        Dim recCurrent As New RectangleF(x1, y1, x2, y2)
        sfCurrent.Alignment = StringAlignment.Near
        ev.Graphics.DrawString(s, fnt, BrushColor, recCurrent, sfCurrent)
    End Sub

    Public Sub DrawStringInBoxCenter(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
     ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal fnt As Font, ByVal BrushColor As System.Drawing.Brush)
        Dim sfCurrent As New StringFormat()
        Dim recCurrent As New RectangleF(x1, y1, x2, y2)
        sfCurrent.Alignment = StringAlignment.Center
        ev.Graphics.DrawString(s, fnt, BrushColor, recCurrent, sfCurrent)
    End Sub

    Public Function SimpleCrypt( _
       ByVal Text As String) As String
        ' Encrypts/decrypts the passed string using 
        ' a simple ASCII value-swapping algorithm
        Dim strTempChar As String, i As Integer
        For i = 1 To Len(Text)
            If Asc(Mid$(Text, i, 1)) < 128 Then
                strTempChar = _
          CType(Asc(Mid$(Text, i, 1)) + 128, String)
            ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                strTempChar = _
          CType(Asc(Mid$(Text, i, 1)) - 128, String)
            End If
            Mid$(Text, i, 1) = _
                Chr(CType(strTempChar, Integer))
        Next i
        Return Text
    End Function

    Public Sub WriteExcelFile(ByVal Headers As ArrayList, ByVal DataArray As ArrayList, ByVal FileName As String)

        Try
            If Not String.IsNullOrEmpty(FileName) Then
                'This section help you if your language is not English.
                System.Threading.Thread.CurrentThread.CurrentCulture = _
                System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
                Dim oExcel As Excel.Application
                Dim oBook As Excel.Workbook
                Dim oSheet As Excel.Worksheet
                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Add(Type.Missing)
                oSheet = oBook.Worksheets(1)

                Dim colIndex As Integer = 0
                Dim rowIndex As Integer = 0

                'Export the Columns to excel file
                For i As Integer = 0 To Headers.Count - 1
                    Dim strHeaders() As String = Split(Headers.Item(i), "|")
                    For n As Integer = 0 To strHeaders.Length - 1
                        colIndex = colIndex + 1
                        oSheet.Cells(rowIndex + 1, colIndex) = UCase(strHeaders(n))
                    Next
                    rowIndex = rowIndex + 1
                    colIndex = 0
                Next

                'Export the rows to excel file
                For p As Integer = 0 To DataArray.Count - 1
                    rowIndex = rowIndex + 1
                    colIndex = 0
                    Dim strBuffer() As String = Split(DataArray.Item(p), "|")
                    For z As Integer = 0 To strBuffer.Length - 1
                        colIndex = colIndex + 1
                        oSheet.Cells(rowIndex + 1, colIndex) = strBuffer(z)
                    Next
                Next

                'Set final path
                Dim finalPath = FileName
                oSheet.Columns.AutoFit()

                'Save file in final path
                oBook.SaveAs(finalPath, Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, _
                Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, _
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)

                'Release the objects
                ReleaseObject(oSheet)
                oBook.Close(False, Type.Missing, Type.Missing)
                ReleaseObject(oBook)
                oExcel.Quit()
                ReleaseObject(oExcel)
                'Some time Office application does not quit after automation: 
                'so i am calling GC.Collect method.
                GC.Collect()

                'MessageBox.Show("Export done successfully!")

            End If
        Catch ex As Exception
            boolAbort = True
            strErrorMessages = ex.Message
            ShowErrorMessage()
        End Try

    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Public Function UnEncryption(ByVal PlanText As String) As String
        Dim HashedBytes As Byte()
        Dim MD5 As String = String.Empty
        Dim encoder As New System.Text.UTF8Encoding()
        Dim md5Hasher As New MD5CryptoServiceProvider()

        HashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(PlanText))

        For A As Int32 = 0 To HashedBytes.Length - 1
            MD5 += HashedBytes(A).ToString("x2")
        Next A
        Return MD5
    End Function

    Public Sub ShowErrorMessage()
        Dim f As New frmErrorMessages
        f.ShowDialog()
    End Sub

    Public Sub PrintDataGrid(dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView, ReportHeader As String)
        On Error GoTo RaiseErr

        Dim arrPrintData As New ArrayList
        Dim strColumnWidths As String = Nothing
        Dim strColumnHeaders As String = Nothing
        Dim strColumnVisible As String = Nothing
        Dim strColumnFormatting As String = Nothing
        Dim strColumnAlignments As String = Nothing
        Dim strColumnTotals As String = Nothing

        With dGrid
            'Get the column headers
            For i As Integer = 0 To .ColumnCount - 1

                If .Columns(i).Visible = True Then
                    strColumnHeaders = strColumnHeaders & .Columns(i).HeaderText & "|"
                Else
                    strColumnHeaders = strColumnHeaders & " " & "|"
                End If
                strColumnFormatting = strColumnFormatting & "NO" & "|"
                strColumnAlignments = strColumnAlignments & "0" & "|"
                strColumnTotals = strColumnTotals & "NO" & "|"

            Next
            If strColumnHeaders.Length > 0 Then strColumnHeaders = Mid(strColumnHeaders, 1, strColumnHeaders.Length - 1)
            If strColumnFormatting.Length > 0 Then strColumnFormatting = Mid(strColumnFormatting, 1, strColumnFormatting.Length - 1)
            If strColumnAlignments.Length > 0 Then strColumnAlignments = Mid(strColumnAlignments, 1, strColumnAlignments.Length - 1)
            If strColumnTotals.Length > 0 Then strColumnTotals = Mid(strColumnTotals, 1, strColumnTotals.Length - 1)

            'Get the column widths
            For i As Integer = 0 To .ColumnCount - 1
                If .Columns(i).Visible = True Then
                    strColumnWidths = strColumnWidths & CStr(CInt((.Columns(i).Width * 0.8) * 1)) & "|"
                Else
                    strColumnWidths = strColumnWidths & CStr(CInt((0 * 0.8) * 1)) & "|"
                End If
            Next
            If strColumnWidths.Length > 0 Then strColumnWidths = Mid(strColumnWidths, 1, strColumnWidths.Length - 1)

            'Get the column visibility
            For i As Integer = 0 To .ColumnCount - 1
                If .Columns(i).Visible = True Then
                    strColumnVisible = strColumnVisible & "YES" & "|"
                Else
                    strColumnVisible = strColumnVisible & "NO" & "|"
                End If
            Next
            If strColumnVisible.Length > 0 Then strColumnVisible = Mid(strColumnVisible, 1, strColumnVisible.Length - 1)

            For r As Integer = 0 To .Rows.Count - 1
                Dim strDataLine As String = Nothing
                For i As Integer = 0 To .Columns.Count - 1
                    Dim strValue As String = .Rows(r).Cells(i).Value.ToString
                    If UCase(strValue) = UCase("System.Drawing.Bitmap") Then strValue = Nothing
                    strDataLine = strDataLine & strValue & ";"
                Next
                If strDataLine.Length > 0 Then strDataLine = Mid(strDataLine, 1, strDataLine.Length - 1)
                arrPrintData.Add(strDataLine)
            Next

        End With

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = dGrid.ColumnCount
            .strColumnHeaders = strColumnHeaders
            .strColumnAlignments = strColumnAlignments
            .strColumnWidths = strColumnWidths
            .strFooterCaption = "Executive Manager ©2014"
            .strMainCaption = UCase("")
            .strMainHeader2 = ReportHeader.ToUpper
            .strMainHeader3 = ""
            .strColumnTotals = strcolumnTotals
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFontItalic
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = True
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = strColumnVisible
            .strColumnFormating = strColumnFormatting
            .strSummaryTotals = strcolumnTotals
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With

        Dim f As New frmPrinterSetup
        f.ShowDialog()
        rpt.PrinterSettings.PrinterName = strSessionPrinter
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Grid Data Printing"
        ShowErrorMessage()
    End Sub

    Public Function IsEmailAddress(ByVal [String] As String) As Boolean
        If [String].IndexOf("@") > -1 Then
            For i As Integer = [String].Length - 1 To 0 Step -1
                If [String].Substring(i, 1) = "." Then
                    If [String].Length - i <= 4 Then
                        Return True
                    End If
                End If
            Next
        End If
        Return False
    End Function

    Public Sub AssignCompanyDetails()
        'Get the company Information
        On Error GoTo RaiseErr
        Dim MyCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Company", cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = MyCommand.ExecuteReader
        While dbReader.Read
            If Not IsDBNull(dbReader("CompanyName").ToString) Then strCompanyName = dbReader("CompanyName").ToString
            If Not IsDBNull(dbReader("Address1").ToString) Then strCompanyAddress1 = dbReader("Address1").ToString
            If Not IsDBNull(dbReader("Address2").ToString) Then strCompanyAddress2 = dbReader("Address2").ToString
            If Not IsDBNull(dbReader("Address3").ToString) Then strCompanyAddress3 = dbReader("Address3").ToString
            If Not IsDBNull(dbReader("Address4").ToString) Then strCompanyAddress4 = dbReader("Address4").ToString
            If Not IsDBNull(dbReader("Telephone").ToString) Then strCompanyTelephone = dbReader("Telephone").ToString
            If Not IsDBNull(dbReader("EmailAddress").ToString) Then strCompanyEmailAddress = dbReader("EmailAddress").ToString
            If Not IsDBNull(dbReader("PayeNumber").ToString) Then strCompanyPayeNumber = dbReader("PayeNumber").ToString
            If Not IsDBNull(dbReader("TaxGrossing").ToString) Then strGrossupTax = dbReader("TaxGrossing").ToString
        End While
        dbReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        dbReader.Close()
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Company Details Assignment Error"
        ShowErrorMessage()
    End Sub

    Public Sub PrintStatementOfEarnings(DateStart As Date, DateEnd As Date)
        On Error GoTo RaiseErr
        Dim strColumn(0 To 2) As String
        Dim arrDetails As New ArrayList

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As OleDb.OleDbDataReader
        Dim strSql As String = Nothing

        Dim dblReportHectarageTotal As Double = 0
        Dim dblReportLoanTotal As Double = 0

        For i As Integer = 0 To arrSelectedItems.Count - 1
            If Not IsDBNull(arrSelectedItems.Item(0).ToString) Then

                Dim strDirectorDetails As String = Nothing
                Dim strAddress1 As String = Nothing
                Dim strAddress2 As String = Nothing
                Dim strAddress3 As String = Nothing
                Dim strAddress4 As String = Nothing
                Dim strIdNumber As String = Nothing

                'Get the list of all director details
                objCommand = New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames AS [GivenNames], " _
                    & "Address1, Address2, Address3, Address4, IdNumber FROM " _
                    & "EmployeeMaster WHERE TransactionId = " & arrSelectedItems.Item(i).ToString & "", cnn)
                Dim objReadMaster As OleDb.OleDbDataReader = objCommand.ExecuteReader


                strColumn(0) = "STATEMENT OF EARNINGS |FN=Arial;FS=12;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                strColumn(0) = " |FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"

                For p As Integer = 0 To 3
                    arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))
                Next

                While objReadMaster.Read
                    If Not IsDBNull(objReadMaster(0).ToString) Then

                        strDirectorDetails = objReadMaster(0).ToString
                        strAddress1 = objReadMaster(1).ToString
                        strAddress2 = objReadMaster(2).ToString
                        strAddress3 = objReadMaster(3).ToString
                        strAddress4 = objReadMaster(4).ToString
                        strIdNumber = objReadMaster(5).ToString

                        'Print name
                        strColumn(0) = UCase(strDirectorDetails & " " & strIdNumber) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                        'Print address 1
                        strColumn(0) = UCase(strAddress1) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                        'Print Address 2
                        strColumn(0) = UCase(strAddress2) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                        'Print address 3
                        strColumn(0) = UCase(strAddress3) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                        'Print address 4
                        strColumn(0) = UCase(strAddress4) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                        'Print 2 blank lines after
                        strColumn(0) = " |FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"

                        For p As Integer = 0 To 2
                            arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))
                        Next

                        'Get and print the earnings

                        Dim dblTotalEarnings As Double = 0
                        Dim dblTotalDeductions As Double = 0

                        strSql = "SELECT Payments.PayCode, PaymentCodes.Description, Payments.Amount FROM Payments " _
                            & "LEFT OUTER JOIN PaymentCodes ON Payments.PayCode = PaymentCodes.CodeNo " _
                            & "WHERE Payments.DirectorId = " & arrSelectedItems.Item(i).ToString & " AND " _
                            & "PaymentCodes.PayType = 'Earning' AND " _
                            & "Payments.TransDate BETWEEN '" & DateStart & "' AND '" & DateEnd & "' ORDER BY Payments.PayCode"

                        'strSql = "SELECT Payments.TransId, RunFile.DirectorId, RunFile.CodeId, SUM(RunFile.Amount) AS [Amount], RunFile.GrossUp, Payments.TransDate, RunFile.Description, Payments.Purpose FROM RunFile LEFT OUTER JOIN Payments ON RunFile.DirectorId = Payments.DirectorId WHERE (RunFile.DirectorId = 3) AND (RunFile.Amount = Payments.Amount) AND (RunFile.OriginalTransDate = Payments.TransDate) AND (RunFile.CodeId = Payments.PayCode) GROUP BY Payments.TransId, RunFile.DirectorId, RunFile.CodeId, RunFile.Amount, RunFile.GrossUp, Payments.TransDate, RunFile.Description, Payments.Purpose"

                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        Dim objReadData As OleDb.OleDbDataReader = objCommand.ExecuteReader

                        While objReadData.Read
                            Dim strColData1 As String = Nothing
                            Dim strColData2 As String = Nothing
                            Dim strColData3 As String = Nothing

                            If Not IsDBNull(objReadData(0).ToString) Then strColData1 = UCase(objReadData(0).ToString)
                            If Not IsDBNull(objReadData(1).ToString) Then strColData2 = UCase(objReadData(1).ToString)
                            If Not IsDBNull(objReadData(2).ToString) Then strColData3 = UCase(objReadData(2).ToString)
                            If IsNumeric(strColData3) Then strColData3 = CStr(Format(CDbl(strColData3), "##0.00")) Else strColData3 = "0.00"

                            strColumn(0) = vbTab & UCase(strColData2) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                            strColumn(1) = UCase(strColData3) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                            strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"

                            arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                            'Add totals
                            If IsNumeric(objReadData(2).ToString) Then dblTotalEarnings = dblTotalEarnings + CDbl(objReadData(2).ToString)

                        End While
                        objReadData.Close()

                        'ADD BLANK LINE BEFORE
                        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                        'Write out the district total line
                        strColumn(0) = "TOTAL EARNINGS|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
                        strColumn(2) = UCase(Format(dblTotalEarnings, "#,##0.00")) & "|FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                        arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                        'ADD ANOTHER BLANK LINE AFTER
                        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                        'Get and print the deductions

                        strSql = "SELECT Payments.PayCode, PaymentCodes.Description, Payments.Amount FROM Payments " _
                            & "LEFT OUTER JOIN PaymentCodes ON Payments.PayCode = PaymentCodes.CodeNo " _
                            & "WHERE Payments.DirectorId = " & arrSelectedItems.Item(i).ToString & " AND " _
                            & "PaymentCodes.PayType = 'Deduction' AND Payments.TransDate BETWEEN '" & DateStart & "' " _
                            & "AND '" & DateEnd & "' ORDER BY Payments.PayCode"

                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objReadData = objCommand.ExecuteReader

                        While objReadData.Read
                            Dim strColData1 As String = Nothing
                            Dim strColData2 As String = Nothing
                            Dim strColData3 As String = Nothing

                            If Not IsDBNull(objReadData(0).ToString) Then strColData1 = UCase(objReadData(0).ToString)
                            If Not IsDBNull(objReadData(1).ToString) Then strColData2 = UCase(objReadData(1).ToString)
                            If Not IsDBNull(objReadData(2).ToString) Then strColData3 = UCase(objReadData(2).ToString)
                            If IsNumeric(strColData3) Then strColData3 = CStr(Format(CDbl(strColData3), "##0.00")) Else strColData3 = "0.00"

                            strColumn(0) = vbTab & UCase(strColData1) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                            strColumn(1) = UCase(strColData3) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                            strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"

                            arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                            'Add totals
                            If IsNumeric(objReadData(2).ToString) Then dblTotalDeductions = dblTotalDeductions + CDbl(objReadData(2).ToString)

                        End While
                        objReadData.Close()

                        'ADD BLANK LINE BEFORE
                        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                        'Write out the deductions total line
                        strColumn(0) = "TOTAL DEDUCTIONS|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
                        strColumn(2) = UCase(Format(dblTotalDeductions, "#,##0.00")) & "|FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                        arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                        'ADD ANOTHER BLANK LINE AFTER
                        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                        'Write out the net total line
                        strColumn(0) = "TOTAL DEDUCTIONS|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
                        strColumn(2) = UCase(Format((dblTotalEarnings - dblTotalDeductions), "#,##0.00")) & "|FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                        arrDetails.Add(strColumn(0) & strColumn(1) & strColumn(2))

                    End If

                End While

            End If
        Next

        Dim strPrintDetails(0 To (arrDetails.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrDetails.Item(i)
        Next

        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 3
            .strColumnHeaders = " |EARNINGS|DEDUCTIONS"
            '.strColumnAlignments = "0|0|2|2|2"
            .strColumnWidths = "450|100|100"
            .strFooterCaption = UCase("Statement of earnings PERIOD COVERED " & UCase(Format(DateStart, "dd-MMM-yyyy")) & " TO " & UCase(Format(DateEnd, "dd-MMM-yyyy")))
            .strMainCaption = ""
            .strMainHeader2 = ""
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES"
            .strColumnFormating = "NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim f As New frmPrinterSetup
        f.ShowDialog()
        rpt.PrinterSettings.PrinterName = strSessionPrinter
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Director Statement Print"
        ShowErrorMessage()
    End Sub

    Public Function TableExists(TableName As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim strSql As String = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" & TableName & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim intCount As Integer = 0
        While objReader.Read
            intCount = intCount + 1
        End While
        objReader.Close()
        If intCount > 0 Then
            boolReturn = True
        End If
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Table Check"
        ShowErrorMessage()
    End Function

    Public Function CheckColumnExistence(ByVal strTableName As String, ByVal strColumnName As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM " & strTableName & "", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim i As Integer = 0
        For i = 0 To objReader.FieldCount - 1
            If UCase(objReader.GetName(i).ToString) = UCase(strColumnName) Then
                boolReturn = True
                Exit For
            End If
        Next
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Column Existence Check"
        ShowErrorMessage()
    End Function

    Public Sub GetTaxTables()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Minima, Maxima, Rate, BaseDeduction " _
            & "FROM SystemTaxTables ORDER BY Band", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        arrTaxBands = New ArrayList
        While objReader.Read
            Dim dblBandMinima As Double = 0
            Dim dblBandMaxima As Double = 0
            Dim dblRate As Double = 0
            Dim dblBaseDeduction As Double = 0
            If IsNumeric(objReader(0).ToString) Then dblBandMinima = CDbl(objReader(0).ToString)
            If IsNumeric(objReader(1).ToString) Then dblBandMaxima = CDbl(objReader(1).ToString)
            If IsNumeric(objReader(2).ToString) Then dblRate = CDbl(objReader(2).ToString)
            If IsNumeric(objReader(3).ToString) Then dblBaseDeduction = CDbl(objReader(3).ToString)
            arrTaxBands.Add(dblBandMinima & "|" & dblBandMaxima & "|" & dblRate & "|" & dblBaseDeduction)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Tax Tables Load"
        ShowErrorMessage()
    End Sub

    Public Function TaxTables(ByVal dblTaxableIncome As Double) As Double
        Dim dblTaxAmount As Double = 0
        dblEmployeeTaxRate = 0
        dblBaseCredit = 0
        If arrTaxBands Is Nothing Then
            MsgBox("Tax bands have not yet been set", MsgBoxStyle.Exclamation, "Tax Bands Fetch Failure")
            Exit Function
        End If

        For n As Integer = 0 To arrTaxBands.Count - 1
            Dim strValues() As String = Split(arrTaxBands(n), "|")
            If dblTaxableIncome > CDbl(strValues(0)) And dblTaxableIncome <= CDbl(strValues(1)) Then
                dblTaxAmount = ((dblTaxableIncome * (CDbl(strValues(2)) / 100)) - CDbl(strValues(3)))
                dblEmployeeTaxRate = (CDbl(strValues(2)) / 100)
                dblBaseCredit = CDbl(strValues(3))
                Exit For
            End If
        Next
        Return dblTaxAmount
    End Function

    Public Sub CreateRunTable()
        On Error GoTo RaiseErr
        Dim strSql As String = "CREATE TABLE RunFile " _
            & "([DirectorId][INT] NOT NULL, [CodeId][INT] NOT NULL, [Description][NVARCHAR](250) NOT NULL, " _
            & "[Amount][Float] NOT NULL DEFAULT 0, [PaymentDate][DateTime] NOT NULL, [ColumnSide][INT] NOT NULL DEFAULT 0)"
        Dim objCoomand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCoomand.ExecuteNonQuery()

        'Add the columns

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on runfile table create"
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

    Public Sub PrintPayStatement()
        On Error GoTo RaiseErr
        Dim strColumn(0 To 2) As String
        Dim strColumnInit As String = Nothing

        Dim arrDetails As New ArrayList

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As OleDb.OleDbDataReader
        Dim strSql As String = Nothing

        Dim dblReportHectarageTotal As Double = 0
        Dim dblReportLoanTotal As Double = 0

        For i As Integer = 0 To arrSelectedItems.Count - 1
            If Not IsDBNull(arrSelectedItems.Item(0).ToString) Then

                Dim strDirectorDetails As String = Nothing
                Dim strAddress1 As String = Nothing
                Dim strAddress2 As String = Nothing
                Dim strAddress3 As String = Nothing
                Dim strAddress4 As String = Nothing
                Dim strIdNumber As String = Nothing

                'Get the list of all director details
                objCommand = New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames AS [GivenNames], " _
                    & "Address1, Address2, Address3, Address4, IdNumber FROM " _
                    & "EmployeeMaster WHERE TransactionId = " & arrSelectedItems.Item(i).ToString & "", cnn)
                Dim objReadMaster As OleDb.OleDbDataReader = objCommand.ExecuteReader

                strColumnInit = " |FN=Arial;FS=12;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(0) = "STATEMENT OF EARNINGS |FN=Arial;FS=12;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                strColumnInit = " |FN=Arial;FS=12;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(0) = " |FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"

                For p As Integer = 0 To 3
                    arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))
                Next

                While objReadMaster.Read
                    If Not IsDBNull(objReadMaster(0).ToString) Then

                        strDirectorDetails = objReadMaster(0).ToString
                        strAddress1 = objReadMaster(1).ToString
                        strAddress2 = objReadMaster(2).ToString
                        strAddress3 = objReadMaster(3).ToString
                        strAddress4 = objReadMaster(4).ToString
                        strIdNumber = objReadMaster(5).ToString

                        'Print name
                        strColumnInit = " |FN=Arial;FS=12;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(0) = UCase(strDirectorDetails & " " & strIdNumber) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                        'Print address 1
                        strColumnInit = " |FN=Arial;FS=12;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(0) = UCase(strAddress1) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                        'Print Address 2
                        strColumnInit = " |FN=Arial;FS=12;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(0) = UCase(strAddress2) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                        'Print address 3
                        strColumnInit = " |FN=Arial;FS=12;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(0) = UCase(strAddress3) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                        'Print address 4
                        strColumnInit = " |FN=Arial;FS=12;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(0) = UCase(strAddress4) & "|FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                        'Print 2 blank lines after
                        strColumnInit = " |FN=Arial;FS=12;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(0) = " |FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"

                        For p As Integer = 0 To 2
                            arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))
                        Next

                        'Get and print the earnings

                        Dim dblTotalEarnings As Double = 0
                        Dim dblTotalDeductions As Double = 0

                        strSql = "SELECT RunFile.CodeId, RunFile.Description, SUM(RunFile.Amount), " _
                            & "UPPER(REPLACE(CONVERT(NVARCHAR(11), RunFile.OriginalTransDate, 106), ' ', '-')) AS [TDate] FROM RunFile " _
                            & "WHERE RunFile.DirectorId = " & arrSelectedItems.Item(i).ToString & " AND " _
                            & "RunFile.ColumnSide = 2 GROUP BY RunFile.CodeId, Runfile.Description, RunFile.Amount, " _
                            & "RunFile.OriginalTransDate"

                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        Dim objReadData As OleDb.OleDbDataReader = objCommand.ExecuteReader

                        While objReadData.Read

                            If CInt(objReadData("CodeId").ToString) < 995 Then
                                Dim strColData1 As String = Nothing
                                Dim strColData2 As String = Nothing
                                Dim strColData3 As String = Nothing
                                Dim strColData0 As String = Nothing

                                If Not IsDBNull(objReadData(0).ToString) Then strColData1 = UCase(objReadData(0).ToString)
                                If Not IsDBNull(objReadData(1).ToString) Then strColData2 = UCase(objReadData(1).ToString)
                                If Not IsDBNull(objReadData(2).ToString) Then strColData3 = UCase(objReadData(2).ToString)
                                If Not IsDBNull(objReadData(3).ToString) Then strColData0 = UCase(objReadData(3).ToString)

                                If IsNumeric(strColData3) Then strColData3 = CStr(Format(CDbl(strColData3), "##0.00")) Else strColData3 = "0.00"

                                strColumnInit = UCase(strColData0) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                                strColumn(0) = vbTab & UCase(strColData2) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                                strColumn(1) = UCase(strColData3) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                                strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"

                                arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                                'Add totals
                                If IsNumeric(objReadData(2).ToString) Then dblTotalEarnings = dblTotalEarnings + CDbl(objReadData(2).ToString)
                            End If

                        End While
                        objReadData.Close()

                        'ADD BLANK LINE BEFORE
                        strColumnInit = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                        'Write out the district total line
                        strColumnInit = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(0) = "TOTAL EARNINGS|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
                        strColumn(2) = UCase(Format(dblTotalEarnings, "#,##0.00")) & "|FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                        arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                        'ADD ANOTHER BLANK LINE AFTER
                        strColumnInit = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                        'Get and print the deductions

                        strSql = "SELECT RunFile.CodeId, RunFile.Description, SUM(RunFile.Amount), " _
                            & "UPPER(REPLACE(CONVERT(NVARCHAR(11), RunFile.OriginalTransDate, 106), ' ', '-')) AS [TDate] FROM RunFile " _
                            & "WHERE RunFile.DirectorId = " & arrSelectedItems.Item(i).ToString & " AND " _
                            & "RunFile.ColumnSide = 1 group by RunFile.CodeId, RunFile.Description, RunFile.Amount, " _
                            & "RunFile.OriginalTransDate"

                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objReadData = objCommand.ExecuteReader

                        While objReadData.Read

                            Dim strColData1 As String = Nothing
                            Dim strColData2 As String = Nothing
                            Dim strColData3 As String = Nothing
                            Dim strColData0 As String = Nothing

                            If Not IsDBNull(objReadData(0).ToString) Then strColData1 = UCase(objReadData(0).ToString)
                            If Not IsDBNull(objReadData(1).ToString) Then strColData2 = UCase(objReadData(1).ToString)
                            If Not IsDBNull(objReadData(2).ToString) Then strColData3 = UCase(objReadData(2).ToString)
                            If Not IsDBNull(objReadData(3).ToString) Then strColData0 = UCase(objReadData(3).ToString)

                            If IsNumeric(strColData3) Then strColData3 = CStr(Format(CDbl(strColData3), "##0.00")) Else strColData3 = "0.00"

                            strColumnInit = UCase(strColData0) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                            strColumn(0) = vbTab & UCase(strColData2) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                            strColumn(1) = UCase(strColData3) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                            strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"

                            arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                            'Add totals
                            If IsNumeric(objReadData(2).ToString) Then dblTotalDeductions = dblTotalDeductions + CDbl(objReadData(2).ToString)

                        End While
                        objReadData.Close()

                        'ADD BLANK LINE BEFORE
                        strColumnInit = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                        'Write out the deductions total line
                        strColumnInit = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(0) = "TOTAL DEDUCTIONS|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
                        strColumn(2) = UCase(Format(dblTotalDeductions, "#,##0.00")) & "|FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                        arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                        'ADD ANOTHER BLANK LINE AFTER
                        strColumnInit = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                        'Write out the net total line
                        strColumnInit = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(0) = "NET EARNINGS|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        strColumn(1) = " |FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
                        strColumn(2) = UCase(Format((dblTotalEarnings - dblTotalDeductions), "#,##0.00")) & "|FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                        arrDetails.Add(strColumnInit & strColumn(0) & strColumn(1) & strColumn(2))

                    End If

                End While

            End If
        Next

        Dim strPrintDetails(0 To (arrDetails.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrDetails.Item(i)
        Next

        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 4
            .strColumnHeaders = " | |AMOUNT|AMOUNT"
            .strColumnWidths = "100|350|100|100"
            .strFooterCaption = UCase("Statement of earnings PERIOD COVERED " & UCase(strStatementDate))
            .strMainCaption = ""
            .strMainHeader2 = ""
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With

        Dim documentPreview As New PrintPreviewDialog

        If boolPrintSelection = True Then
            Dim f As New frmPrinterSetup
            f.ShowDialog()
            rpt.PrinterSettings.PrinterName = strSessionPrinter
            documentPreview.Document = rpt
            documentPreview.ShowDialog()
        Else
            documentPreview.Document = rpt
            rpt.Print()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Director Statement Print"
        ShowErrorMessage()
    End Sub

    Public Function PayrollSummaryPrint(ByVal DirectorId As Integer) As ArrayList
        Dim arrReturn As New ArrayList

        On Error GoTo RaiseErr

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, RunFile.OriginalTransDate, 105) as [Date], " _
         & "RunFile.Description +': '+ Payments.Purpose AS [Description], CAST(RunFile.GrossUp as DECIMAL (10,2)) AS [Amount], CAST(RunFile.PAYE as DECIMAL (10,2)) AS [PAYE], " _
         & "CAST(RunFile.AidsLevy as DECIMAL (10,2)) AS [Aids Levy], PaymentCodes.PayType " _
         & "FROM RunFile LEFT OUTER JOIN PaymentCodes ON RunFile.CodeId = PaymentCodes.CodeNo " _
         & "LEFT OUTER JOIN Payments ON RunFile.DirectorId = Payments.DirectorId " _
         & "WHERE Runfile.DirectorId = " & DirectorId & " AND (RunFile.OriginalTransDate = Payments.TransDate) " _
         & "AND (RunFile.Amount = Payments.Amount) AND (RunFile.CodeId = Payments.PayCode)", cnn)

        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader

        While objReader.Read
            Dim strValues(0 To 6) As String
            If Not IsDBNull(objReader(0).ToString) Then strValues(0) = objReader(0).ToString 'Transaction Date
            If Not IsDBNull(objReader(1).ToString) Then strValues(1) = objReader(1).ToString 'Given Names

            If Not IsDBNull(objReader(5).ToString) Then
                Dim strValue As String = objReader(4).ToString
                If UCase(objReader(5).ToString) = "EARNING" Then
                    strValues(2) = objReader(2).ToString
                    strValues(3) = "0"
                Else
                    strValues(3) = objReader(2).ToString
                    strValues(2) = "0"
                End If
            End If

            If Not IsDBNull(objReader(3).ToString) Then strValues(4) = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then strValues(5) = objReader(4).ToString

            strValues(6) = CStr(CDbl(strValues(2)) - (CDbl(strValues(3)) + CDbl(strValues(4)) + CDbl(strValues(5))))

            arrReturn.Add(strValues(0) & "|" & strValues(1) & "|" & strValues(2) & "|" _
             & strValues(3) & "|" & strValues(4) & "|" & strValues(5) & "|" & strValues(6))
        End While

        objReader.Close()
        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Payments summary details fetch"
        ShowErrorMessage()
    End Function

    Public Function PayrollSummaryPrintTotals() As ArrayList
        Dim arrReturn As New ArrayList

        On Error GoTo RaiseErr

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, RunFile.OriginalTransDate, 105) AS Date, " _
            & "RunFile.Description, SUM(RunFile.GrossUp) AS Amount, SUM(RunFile.PAYE) AS PAYE, " _
            & "SUM(RunFile.AidsLevy) AS [Aids Levy], PaymentCodes.PayType FROM RunFile " _
            & "LEFT OUTER JOIN PaymentCodes ON RunFile.CodeId = PaymentCodes.CodeNo " _
            & "GROUP BY RunFile.OriginalTransDate, RunFile.Description, PaymentCodes.PayType", cnn)

        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader

        While objReader.Read
            Dim strValues(0 To 6) As String
            If Not IsDBNull(objReader(0).ToString) Then strValues(0) = objReader(0).ToString 'Transaction Date
            If Not IsDBNull(objReader(1).ToString) Then strValues(1) = objReader(1).ToString 'Given Names

            If Not IsDBNull(objReader(5).ToString) Then
                Dim strValue As String = objReader(4).ToString
                If UCase(objReader(5).ToString) = "EARNING" Then
                    strValues(2) = objReader(2).ToString
                    strValues(3) = "0"
                Else
                    strValues(3) = objReader(2).ToString
                    strValues(2) = "0"
                End If
            End If

            If Not IsDBNull(objReader(3).ToString) Then strValues(4) = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then strValues(5) = objReader(4).ToString

            strValues(6) = CStr(CDbl(strValues(2)) - (CDbl(strValues(3)) + CDbl(strValues(4)) + CDbl(strValues(5))))

            arrReturn.Add(strValues(0) & "|" & strValues(1) & "|" & strValues(2) & "|" _
             & strValues(3) & "|" & strValues(4) & "|" & strValues(5) & "|" & strValues(6))
        End While

        objReader.Close()
        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Payments summary details fetch"
        ShowErrorMessage()
    End Function

    Public Sub DrawStringInBoxRight(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
        ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal fnt As Font)
        Dim sfCurrent As New StringFormat()
        Dim recCurrent As New RectangleF(x1, y1, x2, y2)
        sfCurrent.Alignment = StringAlignment.Far
        ev.Graphics.DrawString(s, fnt, Brushes.Black, recCurrent, sfCurrent)
    End Sub

    Public Sub DrawStringInBoxLeft(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
        ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal fnt As Font)
        Dim sfCurrent As New StringFormat()
        Dim recCurrent As New RectangleF(x1, y1, x2, y2)
        sfCurrent.Alignment = StringAlignment.Near
        ev.Graphics.DrawString(s, fnt, Brushes.Black, recCurrent, sfCurrent)
    End Sub

    Public Sub DrawStringInBoxCenter(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
        ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal fnt As Font)
        Dim sfCurrent As New StringFormat()
        Dim recCurrent As New RectangleF(x1, y1, x2, y2)
        sfCurrent.Alignment = StringAlignment.Center
        ev.Graphics.DrawString(s, fnt, Brushes.Black, recCurrent, sfCurrent)
    End Sub

    'Advanced text box formatting 
    Public Sub DrawFormattedTextBox(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
     ByVal x1 As Single, ByVal y1 As Single, ByVal Width As Single, ByVal Height As Single, ByVal Text As String, _
     ByVal fnt As Font, ByVal BrushColor As System.Drawing.Brush, ByVal HAlign As Integer, _
      ByVal VAlign As Integer, ByVal BoxColor As System.Drawing.SolidBrush)
        Dim sfCurrent As New StringFormat()


        Dim baselineOffset As Double = fnt.SizeInPoints / _
        fnt.FontFamily.GetEmHeight(fnt.Style) * fnt.FontFamily.GetCellAscent(fnt.Style)
        Dim baselineOffsetPixels As Double = ev.Graphics.DpiY / 72.0F * baselineOffset
        Dim recCurrent As New RectangleF(x1, y1 + (CInt(baselineOffset) / 2), Width, Height)

        Dim recFill As New Rectangle(x1, y1, Width, Height)
        ev.Graphics.FillRectangle(BoxColor, recFill)

        Select Case HAlign
            Case Is = 0
                sfCurrent.Alignment = StringAlignment.Near
            Case Is = 1
                sfCurrent.Alignment = StringAlignment.Center
            Case Is = 2
                sfCurrent.Alignment = StringAlignment.Far
            Case Else
                sfCurrent.Alignment = StringAlignment.Near
        End Select
        ev.Graphics.DrawString(Text, fnt, BrushColor, recCurrent, sfCurrent)

    End Sub

    Public Function EmployeeAidsLevy(ByVal EmployeeNumber As Long, StartDate As Date, EndDate As Date) As Double
        Dim dblReturn As Double = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CAST(SUM(PaymentsHistory.AidsLevy) AS DECIMAL(10, 2)) AS [Aids Levy] " _
            & "FROM PaymentsHistory WHERE PaymentsHistory.DirectorId = " & EmployeeNumber & " AND " _
            & "PaymentsHistory.PaymentDate BETWEEN '" & Format(StartDate, "dd-MMM-yyyy") & "' " _
            & "AND '" & Format(EndDate, "dd-MMM-yyyy") & "'", cnn)
        Dim objReadData As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReadData.Read()
            If IsNumeric(objReadData(0).ToString) Then dblReturn = CDbl(objReadData(0).ToString)
        End While
        objReadData.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
        boolAbort = True
    End Function

    Public Function EmployeePaye(ByVal EmployeeNumber As Long, StartDate As Date, EndDate As Date) As Double
        Dim dblReturn As Double = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CAST(SUM(PaymentsHistory.Paye) AS DECIMAL(10, 2)) AS [PAYE] " _
            & "FROM PaymentsHistory WHERE PaymentsHistory.DirectorId = " & EmployeeNumber & " AND " _
            & "PaymentsHistory.PaymentDate BETWEEN '" & Format(StartDate, "dd-MMM-yyyy") & "' " _
            & "AND '" & Format(EndDate, "dd-MMM-yyyy") & "'", cnn)
        Dim objReadData As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReadData.Read()
            If IsNumeric(objReadData(0).ToString) Then dblReturn = CDbl(objReadData(0).ToString)
        End While
        objReadData.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
        boolAbort = True
    End Function

    Public Function EmployeeEarnings(EmployeeNumber As Long, StartingDate As Date, EndingDate As Date) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList
        Dim i As Integer

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CodeNo FROM PaymentCodes " _
            & "WHERE PayType = 'EARNING' OR PayType = 'BENEFIT' ORDER BY CodeNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        While objReader.Read

            Dim intActiveCode As Integer = objReader(0).ToString
            Dim dblValue As Double = 0
            If intActiveCode <> 0 Then
                Dim strSelectCode As String = "SELECT SUM(GrossUp) FROM PaymentsHistory " _
                    & "WHERE DirectorId = " & EmployeeNumber & " AND CodeId = " & intActiveCode & " AND " _
                    & "PaymentsHistory.PaymentDate BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' " _
                    & "AND '" & Format(EndingDate, "dd-MMM-yyyy") & "'"
                Dim cmdGetCodeValue As New Data.OleDb.OleDbCommand(strSelectCode, cnn)
                Dim objReadCode As Data.OleDb.OleDbDataReader = cmdGetCodeValue.ExecuteReader
                While objReadCode.Read
                    If IsNumeric(objReadCode(0).ToString) Then
                        dblValue = dblValue + (CDbl(objReadCode(0).ToString) * 1)
                        Exit While
                    End If
                End While
                objReadCode.Close()
            End If

            arrReturn.Add(dblValue)

        End While

        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error no " & Err.Number & vbCrLf & " On Tax Certificate Print Failure"
        ShowErrorMessage()
    End Function

    Public Function EarningsAndBenefitsCodes() As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, CodeNo) +'|'+ Description AS [Data] FROM PaymentCodes " _
            & "WHERE PayType = 'BENEFIT' OR PayType = 'EARNING' ORDER BY CodeNo"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                arrReturn.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Return arrReturn
        strErrorMessages = Err.Description & " error no " & Err.Number & vbCrLf & " On Earnings and Benefits Fetch"
        ShowErrorMessage()
    End Function

    Public Function TaxEmployeeCodeValue(CodeNumber As Integer, StartingDate As Date, EndingDate As Date, EmployeeNumber As Integer) As Double
        Dim dblReturn As Double = 0
        Dim strSql As String = "SELECT SUM(PaymentsHistory.GrossUp) FROM PaymentsHistory " _
            & "WHERE DirectorId = " & EmployeeNumber & " AND CodeId = " & CodeNumber & " AND " _
            & "PaymentDate BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND " _
            & "'" & Format(EndingDate, "dd-MMM-yyyy") & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If IsNumeric(objReader(0).ToString) Then
                dblReturn = CDbl(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Return dblReturn
        strErrorMessages = Err.Description & " error no " & Err.Number & vbCrLf & " On Tax Earnings and Benefits Fetch"
        ShowErrorMessage()
    End Function

    Public Function TaxSummaryCodeValue(CodeNumber As Integer, StartingDate As Date, EndingDate As Date) As Double
        Dim dblReturn As Double = 0
        Dim strSql As String = "SELECT SUM(PaymentsHistory.GrossUp) FROM PaymentsHistory " _
            & "WHERE CodeId = " & CodeNumber & " AND " _
            & "PaymentDate BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND " _
            & "'" & Format(EndingDate, "dd-MMM-yyyy") & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If IsNumeric(objReader(0).ToString) Then
                dblReturn = CDbl(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Return dblReturn
        strErrorMessages = Err.Description & " error no " & Err.Number & vbCrLf & " On Summary Tax Earnings and Benefits Fetch"
        ShowErrorMessage()
    End Function
End Module
