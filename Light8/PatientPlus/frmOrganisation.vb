Imports System.IO
Imports System.Text
Imports System.Drawing.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmOrganisation

    Dim boolContinueToLoad As Boolean = True

    Public Declare Auto Function AnimateWindow Lib "user32" (ByVal hwnd As IntPtr, ByVal time As Integer, ByVal flags As Integer) As Boolean

    Public Enum AnimateStyles
        Slide = 262144
        Activate = 131072
        Blend = 524288
        Hide = 65536
        Center = 16
        HOR_Positive = 1
        HOR_Negative = 2
        VER_Positive = 4
        VER_Negative = 8
    End Enum

    Private Sub chkPaswordExpiry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPaswordExpiry.CheckedChanged
        If chkPaswordExpiry.Checked = True Then
            txtPassDays.Enabled = True
        Else
            txtPassDays.Enabled = True
        End If
    End Sub

    Sub FormFade(ByVal FType)
        Select Case FType
            Case ("in")
                Dim FadeCount As Integer
                For FadeCount = 10 To 90 Step 10
                    Me.Opacity = FadeCount / 100
                    Me.Refresh()
                    Threading.Thread.Sleep(50)
                Next
            Case ("out")
                Dim FadeCount As Integer
                For FadeCount = 90 To 10 Step -10
                    Me.Opacity = FadeCount / 100
                    Me.Refresh()
                    Threading.Thread.Sleep(50)
                Next
        End Select
        Me.Opacity = 99
    End Sub

    Private Sub LoadOrganizationValues()
        On Error GoTo RaiseErr

        'Get the company details and fill them in

        Dim myCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Company", cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader

        While dbReader.Read

            If Not IsDBNull(dbReader("CompanyName").ToString) Then txtCoyName.Text = dbReader("CompanyName").ToString Else txtCoyName.Text = ""
            If Not IsDBNull(dbReader("Address1").ToString) Then txtAddress1.Text = dbReader("Address1").ToString Else txtAddress1.Text = ""
            If Not IsDBNull(dbReader("Address2").ToString) Then txtAddress2.Text = dbReader("Address2").ToString Else txtAddress2.Text = ""
            If Not IsDBNull(dbReader("Address3").ToString) Then txtAddress3.Text = dbReader("Address3").ToString Else txtAddress3.Text = ""
            If Not IsDBNull(dbReader("Address4").ToString) Then txtAddress4.Text = dbReader("Address4").ToString Else txtAddress4.Text = ""
            If Not IsDBNull(dbReader("Telephone").ToString) Then txtTelephone.Text = dbReader("Telephone").ToString Else txtTelephone.Text = ""
            If Not IsDBNull(dbReader("ContactCell").ToString) Then txtCellphone.Text = dbReader("ContactCell").ToString Else txtCellphone.Text = ""
            If Not IsDBNull(dbReader("FaxNumber").ToString) Then txtFaxNumber.Text = dbReader("FaxNumber").ToString Else txtFaxNumber.Text = ""
            If Not IsDBNull(dbReader("ContactPerson").ToString) Then txtContactPerson.Text = dbReader("ContactPerson").ToString Else txtContactPerson.Text = ""
            If Not IsDBNull(dbReader("EmailAddress").ToString) Then txtEmailAddress.Text = dbReader("EmailAddress").ToString Else txtEmailAddress.Text = ""
            If Not IsDBNull(dbReader("VatNumber").ToString) Then txtVatNumber.Text = dbReader("VatNumber").ToString Else txtVatNumber.Text = ""
            If Not IsDBNull(dbReader("RegistrationNumber").ToString) Then txtCompanyNumber.Text = dbReader("RegistrationNumber").ToString Else txtCompanyNumber.Text = ""
            If Not IsDBNull(dbReader("LogoPath").ToString) Then txtLogoPath.Text = dbReader("LogoPath").ToString Else txtCompanyNumber.Text = ""
            If Not IsDBNull(dbReader("Slogan").ToString) Then txtSlogan.Text = dbReader("Slogan").ToString
            If Not IsDBNull(dbReader("Country").ToString) Then cboCountry.Text = dbReader("Country").ToString

            If Not IsDBNull(dbReader("BrandsYposition").ToString) Then txtBrandsYposition.Text = dbReader("BrandsYposition").ToString
            If Not IsDBNull(dbReader("BrandsXposition").ToString) Then txtBrandsXposition.Text = dbReader("BrandsXposition").ToString

            If Not IsDBNull(dbReader("BrandImage1").ToString) Then txtBrandImage1.Text = dbReader("BrandImage1").ToString
            If Not IsDBNull(dbReader("BrandImage2").ToString) Then txtBrandImage2.Text = dbReader("BrandImage2").ToString
            If Not IsDBNull(dbReader("BrandImage3").ToString) Then txtBrandImage3.Text = dbReader("BrandImage3").ToString
            If Not IsDBNull(dbReader("BrandImage4").ToString) Then txtBrandImage4.Text = dbReader("BrandImage4").ToString
            If Not IsDBNull(dbReader("Tiling").ToString) Then cboTiling.Text = dbReader("Tiling").ToString

            If Not IsDBNull(dbReader("BPNumber").ToString) Then txtBpNumber.Text = dbReader("BPNumber").ToString
            If Not IsDBNull(dbReader("PayeeNumber").ToString) Then txtPayeNumber.Text = dbReader("PayeeNumber").ToString

            If IsNumeric(dbReader("SearchFrom").ToString) Then txtActiveSearchCharacters.Text = CInt(dbReader("SearchFrom").ToString)
            If Not IsDBNull(dbReader("ConsultationsDefaultSearchKey").ToString) Then cboConsultationDefaultSearchMode.Text = dbReader("ConsultationsDefaultSearchKey").ToString
            If Not IsDBNull(dbReader("MedicinesDefaultSearchKey").ToString) Then cboMedicinesDefaultSearchMode.Text = dbReader("MedicinesDefaultSearchKey").ToString
            If Not IsDBNull(dbReader("ExtrasDefaultSearchKey").ToString) Then cboExtrasDefaultSearchMode.Text = dbReader("ExtrasDefaultSearchKey").ToString


            chkPasswordComplexity.Checked = False
            If Not IsDBNull(dbReader("PasswordComplexity").ToString) Then
                If UCase(dbReader("PasswordComplexity").ToString) = "YES" Then
                    chkPasswordComplexity.Checked = True
                End If
            End If

            'ConfirmReceiptPrint
            chkConfirmReceiptPrint.Checked = False
            If Not IsDBNull(dbReader("ConfirmReceiptPrint").ToString) Then
                If UCase(dbReader("ConfirmReceiptPrint").ToString) = "YES" Then
                    chkConfirmReceiptPrint.Checked = True
                End If
            End If

            'PrinterType
            optDotMatrix.Checked = False : optWindowsPrinter.Checked = False
            If Not IsDBNull(dbReader("PrinterType").ToString) Then
                If UCase(dbReader("PrinterType").ToString) = "RAW" Then optDotMatrix.Checked = True Else optWindowsPrinter.Checked = True
            End If

            chkRequestForReceiptPrinter.Checked = False
            'ExchangeRoundStatus
            If Not IsDBNull(dbReader("RequestForReceiptPrinter").ToString) Then
                If UCase(dbReader("RequestForReceiptPrinter").ToString) = "YES" Then
                    chkRequestForReceiptPrinter.Checked = True
                End If
            End If

            'CutReceipt
            chkCutPaper.Checked = False
            'ExchangeRoundStatus
            If Not IsDBNull(dbReader("CutReceipt").ToString) Then
                If UCase(dbReader("CutReceipt").ToString) = "YES" Then
                    chkRequestForReceiptPrinter.Checked = True
                End If
            End If

            chkPaswordExpiry.Checked = False
            txtPassDays.Text = "0"
            If Not IsDBNull(dbReader("PasswordExpiry").ToString) Then
                If UCase(dbReader("PasswordExpiry").ToString) = "YES" Then
                    chkPaswordExpiry.Checked = True
                    If IsNumeric(dbReader("ExpiryDays").ToString) Then
                        txtPassDays.Text = dbReader("ExpiryDays").ToString
                    End If
                End If
            End If

            If Not IsDBNull(dbReader("WatermarkPath").ToString) Then txtWatermarkPath.Text = dbReader("WatermarkPath").ToString

            If Not IsDBNull(dbReader("ImageXposition").ToString) Then txtXposition.Text = dbReader("ImageXposition").ToString
            If Not IsDBNull(dbReader("ImageYposition").ToString) Then txtYposition.Text = dbReader("ImageYposition").ToString

            If Not IsDBNull(dbReader("WatermarkX").ToString) Then txtXwatermark.Text = dbReader("WatermarkX").ToString
            If Not IsDBNull(dbReader("WatermarkY").ToString) Then txtYwatermark.Text = dbReader("WatermarkY").ToString

            If Not IsDBNull(dbReader("HeaderFontName").ToString) Then cboHeaderFontName.Text = dbReader("HeaderFontName").ToString
            If Not IsDBNull(dbReader("DetailFontName").ToString) Then cboDetailFontName.Text = dbReader("DetailFontName").ToString
            If Not IsDBNull(dbReader("FooterFontName").ToString) Then cboFooterFontName.Text = dbReader("FooterFontName").ToString
            If IsNumeric(dbReader("HeaderFontSize").ToString) Then cboHeaderFontSize.Text = CInt(dbReader("HeaderFontSize").ToString)
            If IsNumeric(dbReader("DetailFontSize").ToString) Then cboDetailFontSize.Text = CInt(dbReader("DetailFontSize").ToString)
            If IsNumeric(dbReader("FooterFontSize").ToString) Then cboFooterFontSize.Text = CInt(dbReader("FooterFontSize").ToString)

        End While
        dbReader.Close()

        'Get the web connections
        myCommand = New Data.OleDb.OleDbCommand("SELECT * FROM WebProfile", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            If Not IsDBNull(dbReader("ftpAddress").ToString) Then txtFtpAddress.Text = dbReader("ftpAddress").ToString
            If Not IsDBNull(dbReader("FtpLoginName").ToString) Then txtLoginName.Text = dbReader("FtpLoginName").ToString
            If Not IsDBNull(dbReader("FtpLoginPassword").ToString) Then txtLoginPassword.Text = dbReader("FtpLoginPassword").ToString
            If strWebConnectionType = "REALTIME" Then
                chkTransmissionMode.Checked = True
            Else
                chkTransmissionMode.Checked = False
            End If
            If Not IsDBNull(dbReader("MainBranch").ToString) Then cboLocation.Text = dbReader("MainBranch").ToString
        End If
        dbReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCritical & "On Company Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadBankDetails()
        On Error GoTo RaiseErr
        'ID, Code, Bank, AccountName, AccountNumber, AccountType, Status
        Dim strSql As String = "SELECT SystemCoyBanks.TransactionId, SystemCoyBanks.BankCode, " _
            & "SystemBanks.BankName, SystemCoyBanks.AccountName, " _
            & "SystemCoyBanks.AccountNumber, SystemCoyBanks.AccountType, SystemCoyBanks.Status FROM SystemCoyBanks " _
            & "LEFT OUTER JOIN SystemBanks ON SystemCoyBanks.BankCode = SystemBanks.BankCode"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridBanks.Rows.Clear()
        While objReader.Read
            dGridBanks.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5), objReader(6))
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Company Bank Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmOrganization_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        boolAbort = False
        LoadFonts()
        If boolAbort = True Then Me.Close()
        LoadBankDetails()
        If boolAbort = True Then Exit Sub
        LoadOrganizationValues()
        If boolAbort = True Then Exit Sub
        LoadControlNumbers()
        If boolAbort = True Then Exit Sub
        LoadUsers()
        If boolAbort = True Then Exit Sub
        SuperTabControl1.SelectedTabIndex = 0
        Me.TabControl2.SelectedIndex = 0

    End Sub

    Private Sub tsSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSave.Click
        On Error GoTo RaiseErr
        boolAbort = False
        Dim myCommand As Data.OleDb.OleDbCommand

        If Me.txtCoyName.Text = "" Or Mid(txtCoyName.Text, 1, 1) = " " Then
            MessageBox.Show("Please enter a valid name for company. No spaces or names begining with spaces",
                "Invalid Company Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCoyName.Focus()
            Exit Sub
        End If
        If txtAddress1.Text = "" Or Mid(txtAddress1.Text, 1, 1) = " " Then
            MessageBox.Show("Please enter a valid address for the company. No spaces or addresses begining with spaces",
                "Invalid Address Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtActiveSearchCharacters.Text) Then txtActiveSearchCharacters.Text = "3"
        If String.IsNullOrEmpty(cboConsultationDefaultSearchMode.Text) Then cboConsultationDefaultSearchMode.Text = "Code"
        If String.IsNullOrEmpty(cboMedicinesDefaultSearchMode.Text) Then cboMedicinesDefaultSearchMode.Text = "Description"
        If String.IsNullOrEmpty(cboExtrasDefaultSearchMode.Text) Then cboExtrasDefaultSearchMode.Text = "Description"

        Dim strCut As String = "NO"
        If chkCutPaper.Checked = True Then strCut = "YES"

        Dim strPrintType As String = "WINDOWS"
        If optDotMatrix.Checked = True Then strPrintType = "RAW"

        Dim strPrintClaim As String = "NO"
        Dim strIgnoreZeroStock As String = "NO"
        Dim strSmsSalesReports As String = "NO"

        strPrintClaim = "YES"

        Dim strRoundExchangeAmounts As String = "YES"
        Dim strRequestForReceiptPrinter As String = "NO"

        strRoundExchangeAmounts = "NO"

        Dim strSalesDescriptionUpdate As String = "NO"

        If chkTransmissionMode.Checked = True Then
            strWebConnectionType = "REALTIME"
        Else
            strWebConnectionType = "MANUAL"
        End If

        'RequestForReceiptPrinter
        If chkRequestForReceiptPrinter.Checked Then
            strRequestForReceiptPrinter = "YES"
        Else
            strRequestForReceiptPrinter = "NO"
        End If

        strIgnoreZeroStock = "NO"

        strSmsSalesReports = "NO"

        Dim strComplexity As String = "NO"
        Dim strPassExpiry As String = "NO"

        Dim strMaintainDate As String = "NO"

        Dim strInvoicePrintToPOS As String = "NO"

        Dim strPostSalesDirectlyToCashbook As String = "YES" 'This is the default setting

        Dim strMachineStatus As String = "OTHER"

        Dim strOnlineInventoryTransferFlag As String = "NO"

        Dim strConfirmReceiptPrint As String = "NO"
        If chkConfirmReceiptPrint.Checked = True Then
            strConfirmReceiptPrint = "YES"
        End If

        Dim strIgnoreSerialNumbers As String = "NO"

        If chkPasswordComplexity.Checked = True Then
            strComplexity = "YES"
        End If

        If chkPaswordExpiry.Checked = True Then
            strPassExpiry = "YES"
        End If

        'IgnoreReturnsDocNo
        Dim strIgnoreReturnsDocNo As String = "NO"

        If Not IsNumeric(txtPassDays.Text) Then txtPassDays.Text = "0"

        Dim strAutoSellingPriceUpdate As String = "NO"

        Dim strServiceOffering As String = "ALL TRADES"

        Dim strAllowSpacesOnItemCodes As String = "NO"

        Dim strWatermarkPath As String = Nothing
        Dim strUseWatermark As String = "NO"

        If chkUseWatermark.Checked = True Then
            If String.IsNullOrEmpty(txtWatermarkPath.Text) Then
                MessageBox.Show("Please specify the watermark path", "Invalid Watermark Path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                KryptonButton1.Focus()
                Exit Sub
            End If
            strWatermarkPath = txtWatermarkPath.Text
            strUseWatermark = "YES"
        Else
            txtWatermarkPath.Text = Nothing
        End If

        Dim strAllowItemQtyChange As String = "NO"

        If Not IsNumeric(txtXposition.Text) Then txtXposition.Text = "100"
        If Not IsNumeric(txtYposition.Text) Then txtYposition.Text = "100"

        If Not IsNumeric(txtXwatermark.Text) Then txtXwatermark.Text = "250"
        If Not IsNumeric(txtYwatermark.Text) Then txtYwatermark.Text = "300"

        Dim strInvoiceDesignType As String = "GENERIC"

        If Not IsNumeric(cboHeaderFontSize.Text) Then cboHeaderFontSize.Text = "10"
        If Not IsNumeric(cboDetailFontSize.Text) Then cboDetailFontSize.Text = "8"
        If Not IsNumeric(cboFooterFontSize.Text) Then cboFooterFontSize.Text = "6"

        If String.IsNullOrEmpty(cboHeaderFontName.Text) Then cboHeaderFontName.SelectedText = "Ariel"
        If String.IsNullOrEmpty(cboDetailFontName.Text) Then cboDetailFontName.SelectedText = "Ariel"
        If String.IsNullOrEmpty(cboFooterFontName.Text) Then cboFooterFontName.SelectedText = "Ariel"

        If Not IsNumeric(txtBrandsYposition.Text) Then txtBrandsYposition.Text = "0"
        If Not IsNumeric(txtBrandsXposition.Text) Then txtBrandsXposition.Text = "0"

        If String.IsNullOrEmpty(cboTiling.Text) Then
            cboTiling.Text = "Horizontal"
        End If

        Dim strClassicExpensesCaptureStatus As String = "YES"

        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        myCommand = New Data.OleDb.OleDbCommand("DELETE FROM Company", cnn)
        myCommand.ExecuteNonQuery()
        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO Company (CompanyName, Address1, " _
            & "Address2, Address3, Address4, Telephone, " _
            & "FaxNumber, EmailAddress, ContactPerson, VatNumber, " _
            & "RegistrationNumber, ContactCell, LogoPath, PasswordComplexity, " _
            & "PasswordExpiry, ExpiryDays, DefaultCurrency, ExchangeRoundStatus, RequestForReceiptPrinter, " _
            & "RoundDownBelow, ProfessionalFees, PrintClaim, IgnoreZeroQuantity, " _
            & "FreeLoyalityVisits, PrinterType, PayeeNumber, BPNumber, " _
            & "SalariesSenderId, SalariesReceiverId, " _
            & "SalariesSenderName, SalariesReceiverName, " _
            & "WatermarkPath, UseWatermark, ImageXposition, " _
            & "ImageYposition, Slogan, BrandImage1, BrandImage2, BrandImage3, " _
            & "BrandImage4, CutReceipt, ConfirmReceiptPrint, " _
            & "HeaderFontName, DetailFontName, FooterFontName, HeaderFontSize, DetailFontSize, " _
            & "FooterFontSize, AlertNumbers, SmsSalesStatus, SmsSalesNumbers, " _
            & "CashReceiptType, Country, BrandsYposition, BrandsXposition, " _
            & "DefaultSearchFilter, PrintInvoiceToPos, Tiling, WatermarkX, WatermarkY, " _
            & "DocumentLines, CoyMode, SalesDescriptionUpdate, SearchFrom, ConsultationsDefaultSearchKey, " _
            & "MedicinesDefaultSearchKey, ExtrasDefaultSearchKey) VALUES " _
            & "('" & txtCoyName.Text & "', '" & txtAddress1.Text & "', '" & txtAddress2.Text & "', " _
            & "'" & txtAddress3.Text & "', '" & txtAddress4.Text & "', '" & txtTelephone.Text & "', " _
            & "'" & txtFaxNumber.Text & "', '" & txtEmailAddress.Text & "', '" & txtContactPerson.Text & "', " _
            & "'" & txtVatNumber.Text & "', '" & txtCompanyNumber.Text & "', '" & txtCellphone.Text & "', '" & txtLogoPath.Text & "', " _
            & "'" & strComplexity & "', '" & strPassExpiry & "', " & CInt(txtPassDays.Text) & ", " _
            & "'USD', 'NO', 'YES', 0, 0, '" & strPrintClaim & "', '" & strIgnoreZeroStock & "', 0, '" & strPrintType & "', " _
            & "'" & txtPayeNumber.Text & "', '" & txtBpNumber.Text & "', '00000', '00000', 'NONE', 'NONE', " _
            & "'" & strWatermarkPath & "', '" & strUseWatermark & "', " & txtXposition.Text & ", " _
            & "" & txtYposition.Text & ", '" & txtSlogan.Text & "', '" & txtBrandImage1.Text & "', " _
            & "'" & txtBrandImage2.Text & "', '" & txtBrandImage3.Text & "', '" & txtBrandImage4.Text & "', " _
            & "'" & strCut & "', '" & strConfirmReceiptPrint & "', " _
            & "'" & cboHeaderFontName.Text & "', '" & cboDetailFontName.Text & "', '" & cboFooterFontName.Text & "', " _
            & "" & CInt(cboHeaderFontSize.Text) & ", " & CInt(cboDetailFontSize.Text) & ", " & CInt(cboFooterFontSize.Text) & ", " _
            & "'', '" & strSmsSalesReports & "', '', 'POS RECEIPT PRINTER', " _
            & "'" & cboCountry.Text & "', " & CInt(txtBrandsYposition.Text) & ", " & CInt(txtBrandsXposition.Text) & ", " _
            & "'ITEM CODE', '" & strInvoicePrintToPOS & "', '" & cboTiling.Text & "', " _
            & "" & CInt(txtXwatermark.Text) & ", " & CInt(txtYwatermark.Text) & ", 23, 'ULTIMATE', " _
            & "'" & strSalesDescriptionUpdate & "', " & txtActiveSearchCharacters.Text & ", " _
            & "'" & cboConsultationDefaultSearchMode.Text & "', '" & cboMedicinesDefaultSearchMode.Text & "', " _
            & "'" & cboExtrasDefaultSearchMode.Text & "')", cnn)
        myCommand.ExecuteNonQuery()

        'Write out the machine status
        Dim objFileWriter As New StreamWriter(Application.StartupPath & "\Data\Macstatus", False)
        objFileWriter.WriteLine(strMachineStatus)
        objFileWriter.Close()

        'Update the web profiles
        myCommand = New Data.OleDb.OleDbCommand("DELETE FROM WebProfile", cnn)
        myCommand.ExecuteNonQuery()
        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO WebProfile (ftpAddress, " _
            & "ftpLoginName, ftpLoginPassword, ConnectionType, MainBranch) VALUES ('" & txtFtpAddress.Text & "', " _
            & "'" & txtLoginName.Text & "', '" & txtLoginPassword.Text & "', '" & strWebConnectionType & "', '" & cboLocation.Text & "')", cnn)
        myCommand.ExecuteNonQuery()

        If boolAbort = True Then Exit Sub
        SaveControlNumbers()
        If boolAbort = True Then Exit Sub

        MessageBox.Show("Company details have been saved successfully", "Company Details Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)

        AssignSystemDefaults()

        Cursor = Cursors.Default
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Company Details Maintenance"
        ShowErrorMessage()
    End Sub

    Private Sub txtAccountNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtAddress1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress1.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtAddress2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress2.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtAddress4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress4.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtAddress3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress3.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtEmailAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailAddress.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtEmailAddress_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEmailAddress.Validating
        If Not String.IsNullOrEmpty(txtEmailAddress.Text) Then
            If gwt_comm.IsEmailAddress(txtEmailAddress.Text) = False Then
                MessageBox.Show("Invalid email address", "Invalid Email Adrress", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtEmailAddress.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtFaxNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFaxNumber.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtReceiverId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtSenderId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtTelephone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelephone.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofd.ShowDialog()
        txtLogoPath.Text = ofd.FileName
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtLogoPath.Clear()
    End Sub

    Private Sub txtCoyName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCoyName.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub KryptonButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton2.Click
        ofd.ShowDialog()
        txtWatermarkPath.Text = ofd.FileName
    End Sub

    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton1.Click
        txtWatermarkPath.Clear()
    End Sub

    Private Sub txtXposition_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtXposition.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            txtYposition.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtYposition_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtYposition.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnAddBrandImage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBrandImage1.Click
        ofd.ShowDialog()
        txtBrandImage1.Text = ofd.FileName
    End Sub

    Private Sub btnAddBrandImage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBrandImage2.Click
        ofd.ShowDialog()
        txtBrandImage2.Text = ofd.FileName
    End Sub

    Private Sub btnAddBrandImage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBrandImage3.Click
        ofd.ShowDialog()
        txtBrandImage3.Text = ofd.FileName
    End Sub

    Private Sub btnAddBrandImage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBrandImage4.Click
        ofd.ShowDialog()
        txtBrandImage4.Text = ofd.FileName
    End Sub

    Private Sub btnRemoveBrandImage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveBrandImage1.Click
        txtBrandImage1.Clear()
    End Sub

    Private Sub btnRemoveBrandImage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveBrandImage2.Click
        txtBrandImage2.Clear()
    End Sub

    Private Sub btnRemoveBrandImage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveBrandImage3.Click
        txtBrandImage3.Clear()
    End Sub

    Private Sub btnRemoveBrandImage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveBrandImage4.Click
        txtBrandImage4.Clear()
    End Sub

    Private Sub cboFooterFontSize_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFooterFontSize.KeyPress
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub cboHeaderFontSize_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboHeaderFontSize.KeyPress
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub cboDetailFontSize_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDetailFontSize.KeyPress
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub LoadFonts()
        On Error GoTo RaiseErr
        Dim installed_Fonts As New InstalledFontCollection
        cboHeaderFontName.Items.Clear()
        cboDetailFontName.Items.Clear()
        cboFooterFontName.Items.Clear()
        Cursor = Cursors.WaitCursor
        For Each font_family As FontFamily In installed_Fonts.Families
            cboHeaderFontName.Items.Add(font_family.Name)
            cboDetailFontName.Items.Add(font_family.Name)
            cboFooterFontName.Items.Add(font_family.Name)
        Next
        'cboHeaderFontName.SelectedIndex = 0 : cboDetailFontName.SelectedIndex = 0 : cboFooterFontName.SelectedIndex = 0
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error while loding the system fonts"
        ShowErrorMessage()
    End Sub

    Private Sub txtBrandsXposition_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBrandsXposition.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            txtBrandsXposition.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtBrandsYposition_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBrandsYposition.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            txtBrandsYposition.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtYwatermark_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtYwatermark.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtXwatermark_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtXwatermark.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub SaveControlNumbers()
        On Error GoTo RaiseErr
        If Not IsNumeric(txtCashSales.Text) Then txtCashSales.Text = "1"
        If Not IsNumeric(txtKeyNumber.Text) Then txtKeyNumber.Text = "1"
        If Not IsNumeric(txtPatientReference.Text) Then txtPatientReference.Text = "1"

        If Not IsNumeric(txtConsultations.Text) Then txtConsultations.Text = "1"
        If Not IsNumeric(txtPrescriptions.Text) Then txtPrescriptions.Text = "1"
        If Not IsNumeric(txtBillNumbers.Text) Then txtBillNumbers.Text = "1"

        Dim strBaseDate As String = Format(CInt(DatePart(DateInterval.Year, Now)), "0000") & Format(CInt(DatePart(DateInterval.Month, Now)), "00")
        ''SupplierInvoices from ControlNumbers
        Dim strSql As String = "INSERT INTO ControlNumbers ([CashSales], " _
            & "[BaseNumber], [KeyNumber], [PatientReferenceNo], [Consultations], [Prescriptions], [PatientBills]) " _
            & "VALUES (" & txtCashSales.Text & ", '" & strBaseDate & "', " & txtKeyNumber.Text & ", " _
            & "" & txtPatientReference.Text & ", " & txtConsultations.Text & ", " & txtPrescriptions.Text & ", " & txtBillNumbers.Text & ")"
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM ControlNumbers", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        'Me.Close()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On control number initialization"
        ShowErrorMessage()
        boolAbort = True
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadControlNumbers()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM ControlNumbers", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("CashSales").ToString) Then txtCashSales.Text = objReader("CashSales").ToString
            If Not IsDBNull(objReader("KeyNumber").ToString) Then txtKeyNumber.Text = objReader("KeyNumber").ToString
            If Not IsDBNull(objReader("PatientReferenceNo").ToString) Then txtPatientReference.Text = objReader("PatientReferenceNo").ToString
            If Not IsDBNull(objReader("Consultations").ToString) Then txtConsultations.Text = objReader("Consultations").ToString
            If Not IsDBNull(objReader("Prescriptions").ToString) Then txtPrescriptions.Text = objReader("Prescriptions").ToString
            If Not IsDBNull(objReader("PatientBills").ToString) Then txtBillNumbers.Text = objReader("PatientBills").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On control number initialization"
        ShowErrorMessage()
    End Sub

    Private Sub LoadUsers()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT UserName, UserLevel FROM Users ORDER BY UserName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGridUsers.Rows.Clear()
        While objReader.Read
            dGridUsers.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridUsers.Rows(dGridUsers.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridUsers.Rows(dGridUsers.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on User Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnNewUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNewUser.Click
        boolEditStatus = False
        Dim f As New frmUserSecurityProfile ' 'frmUserSetup
        f.ShowDialog()
        LoadUsers()
    End Sub

    Private Sub GetSelectedUser()
        If dGridUsers.Rows.Count > 0 Then
            strSelectedUser = dGridUsers.CurrentRow.Cells(0).Value.ToString
            strSelectedUserLevel = dGridUsers.CurrentRow.Cells(1).Value.ToString
        End If
    End Sub

    Private Sub dGridUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridUsers.DoubleClick
        GetSelectedUser()
        boolEditStatus = True
        Dim f As New frmUserSecurityProfile 'frmUserSetup
        f.ShowDialog()
        LoadUsers()
    End Sub

    Private Sub btnEditUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditUser.Click
        GetSelectedUser()
        boolEditStatus = True
        Dim f As New frmUserSecurityProfile 'frmUserSetup
        f.ShowDialog()
        LoadUsers()
    End Sub

    Private Sub btnDeleteUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteUser.Click
        On Error GoTo RaiseErr
        GetSelectedUser()
        If MessageBox.Show("Are you sure you want to delete user " & strSelectedUser & " from the system?",
                "User Record Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM Users WHERE UserName = '" & strSelectedUser & "' AND UserLevel = '" & strSelectedUserLevel & "'", cnn)
            sqlCommand.ExecuteNonQuery()
        End If
        LoadUsers()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "User Record Deletion Error"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAddBank_Click(sender As System.Object, e As System.EventArgs) Handles btnAddBank.Click
        boolEditStatus = False
        Dim frm As New frmBankAccountEntry
        frm.ShowDialog()
        LoadBankDetails()
    End Sub

    Private Sub btnEditBank_Click(sender As System.Object, e As System.EventArgs) Handles btnEditBank.Click
        EditCompanyBank()
    End Sub

    Private Sub EditCompanyBank()
        If dGridBanks.Rows.Count <= 0 Then Exit Sub
        boolEditStatus = True
        intSelectedTransaction = dGridBanks.CurrentRow.Cells(0).Value.ToString
        Dim frm As New frmBankAccountEntry
        frm.ShowDialog()
        LoadBankDetails()
    End Sub

    Private Sub btnDeleteBank_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteBank.Click
        If dGridBanks.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Dim intId As Integer = 0
        If Not Object.Equals(dGridBanks.CurrentRow.Cells(0).Value, Nothing) Then
            If IsNumeric(dGridBanks.CurrentRow.Cells(0).Value.ToString) Then
                intId = CInt(dGridBanks.CurrentRow.Cells(0).Value.ToString)
                If MessageBox.Show("Are you sure you want to delete the selected bank?", "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemCoyBanks WHERE TransactionId = " & intId & "", cnn)
                    objCommand.ExecuteNonQuery()
                    MessageBox.Show("Record has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadBankDetails()
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Company Banks Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGridBanks_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridBanks.DoubleClick
        EditCompanyBank()
    End Sub

    Private Sub frmOrganisation_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 665 : Me.Height = 451
    End Sub

End Class
