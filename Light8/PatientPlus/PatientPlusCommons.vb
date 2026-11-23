Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module PatientPlusCommons

    Public gwt_comm As CommonLibrary.Commons.CommonFunctions

    Public boolParentRecordSearch As Boolean
    Public boolDbCreateMode As Boolean
    Public strSelectedMedicalScheme As String

    Public boolCalledFromConsultation As Boolean
    Public strBillingType As String

    Public strReceiptSpecialNotes As String

    Public dblCash As Double
    Public dblEcocash As Double
    Public dblSwipe As Double
    Public dblTransfer As Double
    Public dblOtherPaymentMethods As Double
    Public dblBilledAmount As Double

    Public strAttendingDoctor As String

    Public GreatwitsSmallLogo As String = Application.StartupPath & "\Greatwits_small_new.png"

    Public arrReceiptItems As ArrayList
    Public itm As Integer = 0

    Public HeaderFont As New System.Drawing.Font("Arial", 14, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    Public DetailsFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Public FooterFont As New System.Drawing.Font("Tahoma", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Public MainHeaderFont As New Font("Arial", 12, FontStyle.Bold)
    Public DetailFont As New Font("Arial", 7, FontStyle.Regular)
    Public SubHeaderFont As New Font("Arial", 7, FontStyle.Bold)
    Public FooterDetailsFont As New Font("Arial", 6, FontStyle.Bold)

    Public strSponsorNames As String
    Public strSponsorAddress1 As String
    Public strSponsorAddress2 As String
    Public strSponsorAddress3 As String
    Public strSponsorAddress4 As String
    Public strSponsorTelephone As String

    Public intSelectedConsultation As Integer

    Public strExtrasDefaultSearchKey As String
    Public strMedicinesDefaultSearchKey As String
    Public strConsultationsDefaultSearchKey As String
    Public intSearchCharactersFrom As Integer

    Public Sub OpenCurrentDatabaseConnection()
        'Get the database connection string
        boolAbort = False
        If String.IsNullOrEmpty(strConnection) Then
            If MessageBox.Show("The application could not locate the connection file. May be this " & vbCrLf &
            "is your first time to run the application on your machine." & vbCrLf &
            "If you want the configure the database click YES else click NO to end the application",
            "Application connection Failure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                'Dim f As New frmApplicationOptions
                'f.ShowDialog()
                'createDatabase()
                End
            Else
                boolAbort = True
            End If
        End If
        If boolAbort = True Then boolAbort = True
        boolConnectionStatus = True
        ConnectToDatabase()
        If boolConnectionStatus = False Then Exit Sub
        boolAbort = False
        UpdateDatabase()

        AssignSystemDefaults()

        getBackupPath()
        GetPrinterSettings()
    End Sub

    Public Sub getBackupPath()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT BackupPath FROM SystemServerPath", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strServerBackkupPath = objReader(0).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
    End Sub

    Public Sub GetPrinterSettings()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM PRINTERSETTINGS", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("ConnectionType").ToString) Then PrinterConnectionType = objReader("ConnectionType").ToString()
            If IsNumeric(objReader("ComPort").ToString) Then intComPortNumber = CInt(objReader("ComPort").ToString())
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Printer Settings Fetch"
        ShowErrorMessage()
    End Sub

    Public Sub AssignSystemDefaults()

        On Error GoTo RaiseErr

        'Get the logo path
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Company", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("LogoPath").ToString) Then strLogoPath = objReader("LogoPath").ToString
            If Not IsDBNull(objReader("DefaultCurrency").ToString) Then strDefaultCurrency = objReader("DefaultCurrency").ToString
            If Not IsDBNull(objReader("ExchangeRoundStatus").ToString) Then strRoundOnExchange = UCase(objReader("ExchangeRoundStatus").ToString) Else strRoundOnExchange = "NO"
            If Not IsDBNull(objReader("RequestForReceiptPrinter").ToString) Then
                strRequestForReceiptPrinter = UCase(objReader("RequestForReceiptPrinter").ToString)
            Else
                strRequestForReceiptPrinter = "NO"
            End If

            If Not IsDBNull(objReader("CoyMode").ToString) Then strCompanyMenuVersion = objReader("CoyMode").ToString
            If Not IsDBNull(objReader("CompanyName").ToString) Then strCompanyName = objReader("CompanyName").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then strCompanyAddress1 = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then strCompanyAddress2 = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then strCompanyAddress3 = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then strCompanyAddress4 = objReader("Address4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then strCompanyTelephone = objReader("Telephone").ToString
            If Not IsDBNull(objReader("FaxNumber").ToString) Then strCompanyFaxNumber = objReader("FaxNumber").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then strCompanyEmailAddress = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("VatNumber").ToString) Then strCompanyVatNumber = objReader("VatNumber").ToString
            If Not IsDBNull(objReader("BankName").ToString) Then strCompanyBankName = objReader("BankName").ToString


            If IsNumeric(objReader("SearchFrom").ToString) Then intSearchCharactersFrom = CInt(objReader("SearchFrom").ToString)
            If Not IsDBNull(objReader("ConsultationsDefaultSearchKey").ToString) Then strConsultationsDefaultSearchKey = objReader("ConsultationsDefaultSearchKey").ToString
            If Not IsDBNull(objReader("MedicinesDefaultSearchKey").ToString) Then strMedicinesDefaultSearchKey = objReader("MedicinesDefaultSearchKey").ToString
            If Not IsDBNull(objReader("ExtrasDefaultSearchKey").ToString) Then strExtrasDefaultSearchKey = objReader("ExtrasDefaultSearchKey").ToString


            If Not IsDBNull(objReader("RegistrationNumber").ToString) Then strCompanyRegistrationNumber = objReader("RegistrationNumber").ToString
            'If Not IsDBNull(objReader("ServiceOffering").ToString) Then strMainCompanyServiceOffering = UCase(objReader("ServiceOffering").ToString)
            If Not IsDBNull(objReader("Country").ToString) Then strCompanyCountry = UCase(objReader("Country").ToString)
            If Not IsDBNull(objReader("DefaultSearchFilter").ToString) Then strDefaultSearchFilter = objReader("DefaultSearchFilter").ToString

            If Not IsDBNull(objReader("PrintInvoiceToPos").ToString) Then strPrintInvoiceToPOS = UCase(objReader("PrintInvoiceToPos").ToString)

            'Brand images tiling
            If Not IsDBNull(objReader("Tiling").ToString) Then strBrandsTiling = UCase(objReader("Tiling").ToString)

            If Not IsDBNull(objReader("AlertNumbers").ToString) Then strMobileAlertNumbers = objReader("AlertNumbers").ToString

            ' SmsSalesStatus, SmsSalesNumbers
            If Not IsDBNull(objReader("SmsSalesNumbers").ToString) Then strMobileSalesAlertNumbers = objReader("SmsSalesNumbers").ToString

            If Not IsDBNull(objReader("SmsSalesStatus").ToString) Then
                strPublicSmsSalesFigures = UCase(objReader("SmsSalesStatus").ToString)
            Else
                strPublicSmsSalesFigures = "NO"
            End If

            ''assign security settings
            If Not IsDBNull(objReader("IgnoreZeroQuantity").ToString) Then strIgnoreZeroQuantity = objReader("IgnoreZeroQuantity").ToString
            If Not IsDBNull(objReader("PasswordComplexity").ToString) Then strPasswordComplexity = objReader("PasswordComplexity").ToString Else strPasswordComplexity = "NO"
            If Not IsDBNull(objReader("PasswordExpiry").ToString) Then strPasswordExpiry = objReader("PasswordExpiry").ToString Else strPasswordExpiry = "NO"
            If IsNumeric(objReader("ExpiryDays").ToString) Then intPasswordDuration = objReader("ExpiryDays").ToString Else intPasswordDuration = 0
            'Assign medical usage data

            If IsNumeric(objReader("ProfessionalFees").ToString) Then dblProfessionalFees = CDbl(objReader("ProfessionalFees").ToString) Else dblProfessionalFees = 0
            If Not IsDBNull(objReader("PrinterType").ToString) Then strPublicPrinterType = objReader("PrinterType").ToString Else strPublicPrinterType = "WINDOWS"
            If Not IsDBNull(objReader("BPNumber").ToString) Then strCompanyBPNumber = objReader("BPNumber").ToString
            If Not IsDBNull(objReader("ContactCell").ToString) Then strCompanyContactCellNumber = objReader("ContactCell").ToString

            'BrandImage2
            If Not IsDBNull(objReader("BrandImage1").ToString) Then strBrandImage1 = objReader("BrandImage1").ToString
            If Not IsDBNull(objReader("BrandImage2").ToString) Then strBrandImage2 = objReader("BrandImage2").ToString
            If Not IsDBNull(objReader("BrandImage3").ToString) Then strBrandImage3 = objReader("BrandImage3").ToString
            If Not IsDBNull(objReader("BrandImage4").ToString) Then strBrandImage4 = objReader("BrandImage4").ToString

            ''WatermarkPath, UseWatermark
            If Not IsDBNull(objReader("WatermarkPath").ToString) Then strWatermarkPath = objReader("WatermarkPath").ToString
            If Not IsDBNull(objReader("UseWatermark").ToString) Then strUseWatermark = objReader("UseWatermark").ToString

            'LogoPath
            If Not IsDBNull(objReader("LogoPath").ToString) Then strCompanyLogoPath = objReader("LogoPath").ToString

            If IsNumeric(objReader("ImageYposition").ToString) Then intLogoYposition = CInt(objReader("ImageYposition").ToString)
            If IsNumeric(objReader("ImageXposition").ToString) Then intLogoXposition = CInt(objReader("ImageXposition").ToString)

            If IsNumeric(objReader("WatermarkX").ToString) Then intWatermarkXposition = CInt(objReader("WatermarkX").ToString)
            If IsNumeric(objReader("WatermarkY").ToString) Then intWatermarkYposition = CInt(objReader("WatermarkY").ToString)

            ''BrandsYposition, BrandsXposition
            If IsNumeric(objReader("BrandsYposition").ToString) Then intBrandsYposition = CInt(objReader("BrandsYposition").ToString)
            If IsNumeric(objReader("BrandsXposition").ToString) Then intBrandsXposition = CInt(objReader("BrandsXposition").ToString)

            If Not IsDBNull(objReader("Slogan").ToString) Then strCompanySlogan = objReader("Slogan").ToString

            If Not IsDBNull(objReader("CutReceipt").ToString) Then strPublicCutReceipt = objReader("CutReceipt").ToString

            'ConfirmReceiptPrint
            If Not IsDBNull(objReader("ConfirmReceiptPrint").ToString) Then strPublicConfirmReceiptPrint = objReader("ConfirmReceiptPrint").ToString

            'If IsNumeric(objReader("BudgetYear").ToString) Then intCurrentBudgetYear = CInt(objReader("BudgetYear").ToString)

            'Assign the default font based on the user settings

            Dim strHeaderFontName As String = "Ariel"
            Dim strDetailFontName As String = "Ariel"
            Dim strFooterFontName As String = "Ariel"
            Dim intHeaderFontSize As Integer = 10
            Dim intDetailFontSize As Integer = 8
            Dim intFooterFontSize As Integer = 6

            If IsNumeric(objReader("HeaderFontName").ToString) Then strHeaderFontName = objReader("HeaderFontName").ToString
            If IsNumeric(objReader("DetailFontName").ToString) Then strDetailFontName = objReader("DetailFontName").ToString
            If IsNumeric(objReader("FooterFontName").ToString) Then strFooterFontName = objReader("FooterFontName").ToString
            If Not IsDBNull(objReader("HeaderFontSize").ToString) Then intHeaderFontSize = CInt(objReader("HeaderFontSize").ToString)
            If Not IsDBNull(objReader("DetailFontSize").ToString) Then intDetailFontSize = CInt(objReader("DetailFontSize").ToString)
            If Not IsDBNull(objReader("FooterFontSize").ToString) Then intFooterFontSize = CInt(objReader("FooterFontSize").ToString)

            fntHeaderFont = New System.Drawing.Font(strHeaderFontName, intHeaderFontSize, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
            fntDetailsFont = New System.Drawing.Font(strDetailFontName, intDetailFontSize, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            fntDetailsFontBold = New System.Drawing.Font(strDetailFontName, intDetailFontSize, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
            fntFooterFont = New System.Drawing.Font(strFooterFontName, intFooterFontSize, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            fntFooterFontItalic = New System.Drawing.Font(strFooterFontName, intFooterFontSize, Drawing.FontStyle.Italic, Drawing.GraphicsUnit.Point)

        End If
        objReader.Close()


        'Get the banking details and assign to array

        Dim strSql As String = "SELECT SystemCoyBanks.BankCode, " _
                & "SystemBanks.BankName, SystemCoyBanks.AccountName, " _
                & "SystemCoyBanks.AccountNumber FROM SystemCoyBanks " _
                & "LEFT OUTER JOIN SystemBanks ON " _
                & "SystemCoyBanks.BankCode = SystemBanks.BankCode " _
                & "WHERE SystemCoyBanks.Status = 'ACTIVE'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        arrCompanyBankDetails = New ArrayList
        While objReader.Read
            Dim strBcode As String = Nothing
            Dim strBname As String = Nothing
            Dim strBaccName As String = Nothing
            Dim strBaccNum As String = Nothing
            If Not IsDBNull(objReader(0).ToString) Then strBcode = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strBname = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strBaccName = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then strBaccNum = objReader(3).ToString
            arrCompanyBankDetails.Add(strBcode & "|" & strBname & "|" & strBaccName & "|" & strBaccNum)
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Branch Details Load"
        ShowErrorMessage()
    End Sub

    Public Sub ConnectToDatabase()
        'strConnection = "Data Source=10.0.0.110,1433;Initial Catalog=nohs;User ID=sa;Password=nohs;provider=SQLOLEDB"
        Try
            cnn = New OleDb.OleDbConnection(strConnection)
            cnn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Database Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            boolConnectionStatus = False
        End Try
    End Sub

    Public Sub UpdateDatabase()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If gwt_comm.CheckColumnExistence("OchmasSystemConsultations", "MedicalAidValue") = False Then
            strSql = "ALTER TABLE OchmasSystemConsultations ADD [MedicalAidValue][FLOAT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("OchmasSystemConsultations", "OthersValue") = False Then
            strSql = "ALTER TABLE OchmasSystemConsultations ADD [OthersValue][FLOAT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckTableExistence("OchmasPatientsDiagnosis") = False Then
            strSql = "CREATE TABLE OchmasPatientsDiagnosis ([PatientId][INT] NOT NULL REFERENCES OchmasPatients (PatientId) " _
                & "ON DELETE CASCADE ON UPDATE CASCADE, [TransactionId][INT] Not NULL PRIMARY KEY IDENTITY (1,1), " _
                & "[TransDate][SmallDateTime] Not NULL DEFAULT GetDate(), [DiagnosisCode][NVARCHAR](35) Not NULL DEFAULT '', " _
                & "[Diagnosis][NVARCHAR](MAX) Not NULL DEFAULT '', [UserName][NVARCHAR](150) NOT NULL DEFAULT '', " _
                & "[ChangeDate][SmallDateTime] NOT NULL DEFAULT GetDate())"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckTableExistence("OchmasPatientsTreatmentPlans") = False Then
            strSql = "CREATE TABLE OchmasPatientsTreatmentPlans ([PatientId][INT] NOT NULL REFERENCES OchmasPatients (PatientId) " _
                & "ON DELETE CASCADE ON UPDATE CASCADE, [TransactionId][INT] Not NULL PRIMARY KEY IDENTITY (1,1), " _
                & "[TransDate][SmallDateTime] Not NULL DEFAULT GetDate(), [Plan][NVARCHAR](MAX) Not NULL DEFAULT '', " _
                & "[UserName][NVARCHAR](150) Not NULL DEFAULT '', [ChangeDate][SmallDateTime] NOT NULL DEFAULT GetDate())"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckTableExistence("OchmasPatientsPrescriptions") = False Then
            strSql = "CREATE TABLE OchmasPatientsPrescriptions ([PatientId][INT] NOT NULL REFERENCES OchmasPatients (PatientId) " _
                & "ON DELETE CASCADE ON UPDATE CASCADE, [TransactionId][INT] Not NULL PRIMARY KEY IDENTITY (1,1), " _
                & "[TransDate][SmallDateTime] Not NULL DEFAULT GetDate(), [DrugCode][NVARCHAR](15) NOT NULL " _
                & "REFERENCES OchmasSystemMedicines (ProductCode) ON UPDATE CASCADE, [Frequency][NVARCHAR](250) Not NULL DEFAULT '', " _
                & "[Dosage][FLOAT] Not NULL DEFAULT 0, [Administration][NVARCHAR](35) Not NULL DEFAULT '', " _
                & "[Duration][FLOAT] Not NULL DEFAULT 7, [RepeatStatus][NVARCHAR](1) Not NULL DEFAULT 'N', " _
                & "[UserName][NVARCHAR](150) Not NULL DEFAULT '', [ChangeDate][SmallDateTime] NOT NULL DEFAULT GetDate())"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("OchmasSystemMedicines", "Presentation") = False Then
            strSql = "ALTER TABLE OchmasSystemMedicines ADD [Presentation][NVARCHAR](35) NOT NULL DEFAULT ''"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If


        If gwt_comm.CheckColumnExistence("OchmasPatientsDiagnosis", "ConsultationId") = False Then
            strSql = "ALTER TABLE OchmasPatientsDiagnosis ADD [ConsultationId][INT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("OchmasPatientsTreatmentPlans", "ConsultationId") = False Then
            strSql = "ALTER TABLE OchmasPatientsTreatmentPlans ADD [ConsultationId][INT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("OchmasPatientsPrescriptions", "ConsultationId") = False Then
            strSql = "ALTER TABLE OchmasPatientsPrescriptions ADD [ConsultationId][INT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("ControlNumbers", "Consultations") = False Then
            strSql = "ALTER TABLE ControlNumbers ADD [Consultations][INT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("ControlNumbers", "PatientBills") = False Then
            strSql = "ALTER TABLE ControlNumbers ADD [PatientBills][INT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckTableExistence("OchmasSystemMedicinesAdminMethods") = False Then
            strSql = "CREATE TABLE OchmasSystemMedicinesAdminMethods " _
                & "([TransactionId][INT] Not NULL PRIMARY KEY IDENTITY (1,1), " _
                & "[Method][NVARCHAR] (250) Not NULL DEFAULT '')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckTableExistence("OchmasExtrasAndServices") = False Then
            strSql = "CREATE TABLE OchmasExtrasAndServices ([TransactionId][INT] NOT NULL PRIMARY KEY IDENTITY (1,1), " _
                & "[Description][NVARCHAR](350) Not NULL DEFAULT '', [Quantity][FLOAT] NOT NULL DEFAULT 0, " _
                & "[UnitPriceMedaid][FLOAT] Not NULL DEFAULT 0, [UnitPriceCash][FLOAT] Not NULL DEFAULT 0, " _
                & "[UnitPriceOther][FLOAT] Not NULL DEFAULT 0, [Classification][NVARCHAR](35) NOT NULL DEFAULT 'PRODUCT')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("OchmasExtrasAndServices", "Classification") = False Then
            strSql = "ALTER TABLE OchmasExtrasAndServices ADD [Classification][NVARCHAR](35) NOT NULL DEFAULT 'PRODUCT'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        'Company

        If gwt_comm.CheckColumnExistence("Company", "SearchFrom") = False Then
            strSql = " ALTER TABLE Company ADD [SearchFrom][INT] Not NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("Company", "ConsultationsDefaultSearchKey") = False Then
            strSql = "ALTER TABLE Company ADD [ConsultationsDefaultSearchKey][NVARCHAR](35) Not NULL DEFAULT 'Code'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("Company", "MedicinesDefaultSearchKey") = False Then
            strSql = "ALTER TABLE Company ADD [MedicinesDefaultSearchKey][NVARCHAR](35) Not NULL DEFAULT 'Description'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("Company", "ExtrasDefaultSearchKey") = False Then
            strSql = "ALTER TABLE Company ADD [ExtrasDefaultSearchKey][NVARCHAR](35) Not NULL Default 'Description'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        'OchmasPatientsPrescriptions
        If gwt_comm.CheckColumnExistence("OchmasPatientsPrescriptions", "ScriptNumber") = False Then
            strSql = "ALTER TABLE OchmasPatientsPrescriptions ADD [ScriptNumber][INT] NOT NULL Default 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Database Update"
        ShowErrorMessage()
    End Sub

    Public Function CreatePrintArray(ByVal DocumentNumber As Integer) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList
        Dim strSql As String = "Select [ItemCode], [Description], CAST([Quantity] As Decimal (10,2)) As [Qty], " _
            & "CAST([UnitPrice] As Decimal (10,2)) As [UnitPrice] FROM OchmasBillingDetails " _
            & "WHERE DocumentNumber = " & DocumentNumber & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strCode As String = Nothing
            Dim strDesc As String = Nothing
            Dim dblQty As Double = 0
            Dim dblUnitPrice As Double = 0
            Dim dblLineTotal As Double = 0
            If Not IsDBNull(objReader(0).ToString) Then strCode = UCase(objReader(0).ToString)
            If Not IsDBNull(objReader(1).ToString) Then strDesc = UCase(objReader(1).ToString)
            If IsNumeric(objReader(2).ToString) Then dblQty = CDbl(objReader(2).ToString)
            If IsNumeric(objReader(3).ToString) Then dblUnitPrice = CDbl(objReader(3).ToString)
            dblLineTotal = dblUnitPrice * dblQty
            arrReturn.Add(strCode & "|" & strDesc & "|" & CStr(Format(dblQty, "##0.00")) & "|" &
                CStr(Format(dblUnitPrice, "##0.00")) & "|" & Format(Format(dblLineTotal, "##0.00")))
        End While
        objReader.Close()
        Return arrReturn

        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On receipt items compilation"
        ShowErrorMessage()
    End Function

    Public Function CreatePrescriptionArray(ByVal DocumentNumber As Integer) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList
        Dim strSql As String = "Select OchmasSystemMedicines.ProductName, OchmasPatientsPrescriptions.Frequency, " _
            & "CAST(OchmasPatientsPrescriptions.Dosage As Decimal (10,2)) As [Dose], " _
            & "OchmasPatientsPrescriptions.Administration, OchmasPatientsPrescriptions.Duration, " _
            & "OchmasPatientsPrescriptions.RepeatStatus FROM OchmasPatientsPrescriptions " _
            & "LEFT OUTER JOIN OchmasSystemMedicines ON OchmasPatientsPrescriptions.DrugCode = OchmasSystemMedicines.ProductCode " _
            & "WHERE ScriptNumber = " & DocumentNumber & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strDesc As String = Nothing
            Dim strCipher As String = Nothing
            Dim dblDose As Double = 0
            Dim strAdmin As String = Nothing
            Dim dblDuration As Double = 0
            Dim strRepeat As String = "N"

            If Not IsDBNull(objReader(0).ToString) Then strDesc = UCase(objReader(0).ToString)
            If Not IsDBNull(objReader(1).ToString) Then strCipher = UCase(objReader(1).ToString)
            If IsNumeric(objReader(2).ToString) Then dblDose = CDbl(objReader(2).ToString)
            If Not IsDBNull(objReader(3).ToString) Then strAdmin = UCase(objReader(3).ToString)
            If IsNumeric(objReader(4).ToString) Then dblDuration = CDbl(objReader(4).ToString)
            If Not IsDBNull(objReader(5).ToString) Then strRepeat = UCase(objReader(5).ToString)
            arrReturn.Add(strDesc & "|" & strCipher & "|" & CStr(Format(dblDose, "##0.00")) & "|" &
                UCase(strAdmin) & "|" & CStr(Format(Format(dblDuration, "##0.00"))) & "|" &
                UCase(strRepeat))

        End While
        objReader.Close()
        Return arrReturn

        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On prescription items compilation"
        ShowErrorMessage()
    End Function

    Public Function FullPatientNames(ByVal PatientId As Integer) As String
        Dim strReturn As String = Nothing
        Dim strSql As String = "Select LastName +' '+ FirstName +' '+ OtherNames FROM OchmasPatients WHERE PatientId = " & PatientId & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                strReturn = objReader(0).ToString
            End If
        End If
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On patient full details fetch"
        ShowErrorMessage()
    End Function

End Module
