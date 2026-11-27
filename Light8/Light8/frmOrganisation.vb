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

    Private Sub LoadBranches()
        On Error GoTo RaiseErr
        Dim strPriorValue As String = cboStoresBranches.Text
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT BranchName FROM Branches ORDER BY BranchName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboLocation.Items.Clear()
        cboStoresBranches.Items.Clear()
        cboStoresBranches.Items.Add("NONE")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboLocation.Items.Add(objReader(0).ToString)
                cboStoresBranches.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        cboStoresBranches.Text = strPriorValue
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Branches Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadOrganizationValues()
        On Error GoTo RaiseErr

        If gwt_comm.CheckColumnExistence("Company", "SalesDescriptionUpdate") = False Then
            Dim objUpdate As New Data.OleDb.OleDbCommand("ALTER TABLE Company ADD [SalesDescriptionUpdate][NVARCHAR](3) NOT NULL DEFAULT 'NO'", cnn)
            objUpdate.ExecuteNonQuery()
        End If
        'Get the company details and fill them in

        Dim myCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Company", cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
        While dbReader.Read

            If Not IsDBNull(dbReader("FiscalBonType").ToString) Then
                cboBonType.SelectedIndex = CInt(dbReader("FiscalBonType").ToString)
            End If

            If Not IsDBNull(dbReader("CoyMode").ToString) Then cboRunMode.Text = dbReader("CoyMode").ToString Else cboRunMode.Text = Nothing
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
            If Not IsDBNull(dbReader("TillslipCopyPath").ToString) Then txtTillslipPath.Text = dbReader("TillslipCopyPath").ToString Else txtTillslipPath.Text = ""
            'If Not IsDBNull(dbReader("AccountName").ToString) Then txtAccountName.Text = dbReader("AccountName").ToString Else txtAccountName.Text = ""
            'If Not IsDBNull(dbReader("BranchName").ToString) Then txtBranchName.Text = dbReader("BranchName").ToString Else txtBranchName.Text = ""
            'If Not IsDBNull(dbReader("BranchCode").ToString) Then txtBranchCode.Text = dbReader("BranchCode").ToString Else txtBranchCode.Text = ""
            'If Not IsDBNull(dbReader("AccountNumber").ToString) Then txtAccountNumber.Text = dbReader("AccountNumber").ToString Else txtAccountNumber.Text = ""
            If Not IsDBNull(dbReader("RegistrationNumber").ToString) Then txtCompanyNumber.Text = dbReader("RegistrationNumber").ToString Else txtCompanyNumber.Text = ""
            If Not IsDBNull(dbReader("LogoPath").ToString) Then txtLogoPath.Text = dbReader("LogoPath").ToString Else txtCompanyNumber.Text = ""
            If Not IsDBNull(dbReader("DefaultCurrency").ToString) Then cboDefaultCurrency.Text = dbReader("DefaultCurrency").ToString
            If Not IsDBNull(dbReader("ServiceOffering").ToString) Then cboOffering.Text = dbReader("ServiceOffering").ToString
            If Not IsDBNull(dbReader("RoundDownBelow").ToString) Then txtRoundDownValue.Text = dbReader("RoundDownBelow").ToString
            If Not IsDBNull(dbReader("ProfessionalFees").ToString) Then txtProfessionalFees.Text = dbReader("ProfessionalFees").ToString
            If Not IsDBNull(dbReader("FreeLoyalityVisits").ToString) Then txtFreeVisits.Text = dbReader("FreeLoyalityVisits").ToString
            If Not IsDBNull(dbReader("Slogan").ToString) Then txtSlogan.Text = dbReader("Slogan").ToString
            If Not IsDBNull(dbReader("SalesProcessType").ToString) Then cboSalesProcessType.Text = dbReader("SalesProcessType").ToString
            If Not IsDBNull(dbReader("InvoiceDesignType").ToString) Then cboInvoiceType.Text = dbReader("InvoiceDesignType").ToString
            If Not IsDBNull(dbReader("Country").ToString) Then cboCountry.Text = dbReader("Country").ToString
            If Not IsDBNull(dbReader("DefaultSearchFilter").ToString) Then cboDefaultSearchFilter.Text = dbReader("DefaultSearchFilter").ToString
            'ClaimBalanceComputation
            If Not IsDBNull(dbReader("ClaimBalanceComputation").ToString) Then cboClaimsBalance.Text = dbReader("ClaimBalanceComputation").ToString Else cboClaimsBalance.Text = "Claim Value"
            'DocumentLines
            If IsNumeric(dbReader("DocumentLines").ToString) Then txtDocLines.Text = dbReader("DocumentLines").ToString
            'Get the default cashbook
            If Not IsDBNull(dbReader("DefaultSalesCashbook").ToString) Then cboAccount.Text = dbReader("DefaultSalesCashbook").ToString

            If IsNumeric(dbReader("BudgetYear").ToString) Then cboBudgetYear.Text = dbReader("BudgetYear").ToString


            'CashReceiptType
            If Not IsDBNull(dbReader("CashReceiptType").ToString) Then cboCashReceiptType.Text = dbReader("CashReceiptType").ToString
            'SmsSalesStatus, SmsSalesNumbers
            If Not IsDBNull(dbReader("SmsSalesNumbers").ToString) Then txtDestinationSalesNumbers.Text = dbReader("SmsSalesNumbers").ToString

            If Not IsDBNull(dbReader("PrinterSerialPortNo").ToString) Then cboComPort.Text = dbReader("PrinterSerialPortNo").ToString
            If Not IsDBNull(dbReader("PrinterBaudRate").ToString) Then cboBaudRate.Text = dbReader("PrinterBaudRate").ToString
            If Not IsDBNull(dbReader("PrinterSeriesNumber").ToString) Then txtPrinterType.Text = dbReader("PrinterSeriesNumber").ToString

            If Not IsDBNull(dbReader("StockManagementType").ToString) Then cboStoresManagementType.Text = dbReader("StockManagementType").ToString
            If Not IsDBNull(dbReader("StockMainBranch").ToString) Then cboStoresBranches.Text = dbReader("StockMainBranch").ToString
            'BrandsYposition, BrandsXposition
            If Not IsDBNull(dbReader("BrandsYposition").ToString) Then txtBrandsYposition.Text = dbReader("BrandsYposition").ToString
            If Not IsDBNull(dbReader("BrandsXposition").ToString) Then txtBrandsXposition.Text = dbReader("BrandsXposition").ToString

            'chkSellingPriceAutoUpdate
            If Not IsDBNull(dbReader("AutoSellingPriceUpdate").ToString) Then
                If UCase(dbReader("AutoSellingPriceUpdate").ToString) = "YES" Then chkSellingPriceAutoUpdate.Checked = True Else chkSellingPriceAutoUpdate.Checked = False
            End If

            'DirectCashbbookSalesPosting
            If Not IsDBNull(dbReader("DirectCashbbookSalesPosting").ToString) Then
                If UCase(dbReader("DirectCashbbookSalesPosting").ToString) = "YES" Then
                    chkDirectCashbookPosting.Checked = True
                Else
                    chkDirectCashbookPosting.Checked = False
                End If
            End If

            If Not IsDBNull(dbReader("SalesDescriptionUpdate").ToString) Then
                If UCase(dbReader("SalesDescriptionUpdate").ToString) = "YES" Then
                    chkDescriptionUpdate.Checked = True
                Else
                    chkDescriptionUpdate.Checked = False
                End If
            End If

            'PrintInvoiceToPos
            If Not IsDBNull(dbReader("PrintInvoiceToPos").ToString) Then
                If UCase(dbReader("PrintInvoiceToPos").ToString) = "YES" Then
                    chkInvoicePosPrinter.Checked = True
                Else
                    chkInvoicePosPrinter.Checked = False
                End If
            End If

            'OnlineInventoryTransfer
            If Not IsDBNull(dbReader("OnlineInventoryTransfer").ToString) Then
                If UCase(dbReader("OnlineInventoryTransfer").ToString) = "YES" Then
                    chkOnlineTransfers.Checked = True
                Else
                    chkOnlineTransfers.Checked = False
                End If
            End If

            'StockValuationMethod
            If Not IsDBNull(dbReader("StockValuationMethod").ToString) Then cboInventoryValuation.Text = dbReader("StockValuationMethod").ToString

            If Not IsDBNull(dbReader("JobConditions").ToString) Then txtJobCardConditions.Text = dbReader("JobConditions").ToString
            'BrandImage2
            If Not IsDBNull(dbReader("BrandImage1").ToString) Then txtBrandImage1.Text = dbReader("BrandImage1").ToString
            If Not IsDBNull(dbReader("BrandImage2").ToString) Then txtBrandImage2.Text = dbReader("BrandImage2").ToString
            If Not IsDBNull(dbReader("BrandImage3").ToString) Then txtBrandImage3.Text = dbReader("BrandImage3").ToString
            If Not IsDBNull(dbReader("BrandImage4").ToString) Then txtBrandImage4.Text = dbReader("BrandImage4").ToString
            If Not IsDBNull(dbReader("Tiling").ToString) Then cboTiling.Text = dbReader("Tiling").ToString

            If Not IsDBNull(dbReader("BPNumber").ToString) Then txtBpNumber.Text = dbReader("BPNumber").ToString
            If Not IsDBNull(dbReader("PayeeNumber").ToString) Then txtPayeNumber.Text = dbReader("PayeeNumber").ToString

            'PrintClaim
            If Not IsDBNull(dbReader("PrintClaim").ToString) Then
                If UCase(dbReader("PrintClaim").ToString) = "YES" Then chkPrintClaims.Checked = True Else chkPrintClaims.Checked = False
            End If

            'IgnoreReturnsDocNo
            If Not IsDBNull(dbReader("IgnoreReturnsDocNo").ToString) Then
                If UCase(dbReader("IgnoreReturnsDocNo").ToString) = "YES" Then chkIgnoreReturnsDocNumber.Checked = True Else chkIgnoreReturnsDocNumber.Checked = False
            End If

            'SmsSalesStatus, SmsSalesNumbers
            If Not IsDBNull(dbReader("SmsSalesStatus").ToString) Then
                If UCase(dbReader("SmsSalesStatus").ToString) = "YES" Then chkSmsSalesFigures.Checked = True Else chkSmsSalesFigures.Checked = False
            End If

            If Not IsDBNull(dbReader("IgnoreZeroQuantity").ToString) Then
                If UCase(dbReader("IgnoreZeroQuantity").ToString) = "YES" Then chkIgnoreZeroQuantity.Checked = True Else chkIgnoreZeroQuantity.Checked = False
            End If

            If Not IsDBNull(dbReader("IgnoreSerialNumbers").ToString) Then
                If UCase(dbReader("IgnoreSerialNumbers").ToString) = "YES" Then chkIgnoreSerialNumbers.Checked = True Else chkIgnoreSerialNumbers.Checked = False
            End If

            'AllowSpacesOnItemCodes
            If Not IsDBNull(dbReader("AllowSpacesOnItemCodes").ToString) Then
                If UCase(dbReader("AllowSpacesOnItemCodes").ToString) = "YES" Then chkAllowSpaces.Checked = True Else chkAllowSpaces.Checked = False
            End If

            'AllowItemQtyChange
            If Not IsDBNull(dbReader("AllowItemQtyChange").ToString) Then
                If UCase(dbReader("AllowItemQtyChange").ToString) = "YES" Then chkAllowInventoryQuantityChange.Checked = True Else chkAllowInventoryQuantityChange.Checked = False
            End If

            chkPasswordComplexity.Checked = False
            If Not IsDBNull(dbReader("PasswordComplexity").ToString) Then
                If UCase(dbReader("PasswordComplexity").ToString) = "YES" Then
                    chkPasswordComplexity.Checked = True
                End If
            End If

            chkMaintainDate.Checked = False
            If Not IsDBNull(dbReader("MaintainTransDate").ToString) Then
                If UCase(dbReader("MaintainTransDate").ToString) = "YES" Then
                    chkMaintainDate.Checked = True
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

            chkRoundAmounts.Checked = False
            'ExchangeRoundStatus
            If Not IsDBNull(dbReader("ExchangeRoundStatus").ToString) Then
                If UCase(dbReader("ExchangeRoundStatus").ToString) = "YES" Then
                    chkRoundAmounts.Checked = True
                End If
            End If

            chkClassicExpensesCapture.Checked = False
            'ExchangeRoundStatus
            If Not IsDBNull(dbReader("ClassicExpensesCaptureStatus").ToString) Then
                If UCase(dbReader("ClassicExpensesCaptureStatus").ToString) = "YES" Then
                    chkClassicExpensesCapture.Checked = True
                End If
            End If

            If Not IsDBNull(dbReader("PrintBankDetails")) Then
                cboPrintBankingDetails.Text = dbReader("PrintBankDetails").ToString
            End If

            'RequestForReceiptPrinter
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

            If Not IsDBNull(dbReader("CosMethod").ToString) Then cboCostOfGoodsValuationMethod.Text = dbReader("CosMethod").ToString

            'Load the salaries information
            'SalariesBankCode, SalariesBankAccount, SalariesSenderId, SalariesReceiverId, SalariesSenderName, SalariesReceiverName


            'If Not IsDBNull(dbReader("SalariesBankAccount").ToString) Then txtAccountNumber.Text = dbReader("SalariesBankAccount").ToString
            If Not IsDBNull(dbReader("SalariesSenderId").ToString) Then txtSenderId.Text = dbReader("SalariesSenderId").ToString
            If Not IsDBNull(dbReader("SalariesReceiverId").ToString) Then txtReceiverId.Text = dbReader("SalariesReceiverId").ToString
            If Not IsDBNull(dbReader("SalariesSenderName").ToString) Then txtSenderName.Text = dbReader("SalariesSenderName").ToString
            If Not IsDBNull(dbReader("SalariesReceiverName").ToString) Then txtReceiverName.Text = dbReader("SalariesReceiverName").ToString
            If Not IsDBNull(dbReader("SalesFormStyle").ToString) Then cboSalesFormType.Text = dbReader("SalesFormStyle").ToString

            'WatermarkPath
            If Not IsDBNull(dbReader("WatermarkPath").ToString) Then txtWatermarkPath.Text = dbReader("WatermarkPath").ToString

            'UseWatermark
            If Not IsDBNull(dbReader("UseWatermark").ToString) Then
                If UCase(dbReader("UseWatermark").ToString) = "YES" Then
                    chkUseWatermark.Checked = True
                End If
            End If

            If Not IsDBNull(dbReader("ImageXposition").ToString) Then txtXposition.Text = dbReader("ImageXposition").ToString
            If Not IsDBNull(dbReader("ImageYposition").ToString) Then txtYposition.Text = dbReader("ImageYposition").ToString

            If Not IsDBNull(dbReader("WatermarkX").ToString) Then txtXwatermark.Text = dbReader("WatermarkX").ToString
            If Not IsDBNull(dbReader("WatermarkY").ToString) Then txtYwatermark.Text = dbReader("WatermarkY").ToString

            'If Not IsDBNull(dbReader("DefaultCurrency").ToString) Then cboPayrollTaxMethod.Text = dbReader("WatermarkPath").ToString
            If Not IsDBNull(dbReader("DefaultCurrency").ToString) Then cboDefaultCurrency.Text = dbReader("DefaultCurrency").ToString
            'Dim strT As String = dbReader("DefaultCurrency").ToString

            If Not IsDBNull(dbReader("HeaderFontName").ToString) Then cboHeaderFontName.Text = dbReader("HeaderFontName").ToString
            If Not IsDBNull(dbReader("DetailFontName").ToString) Then cboDetailFontName.Text = dbReader("DetailFontName").ToString
            If Not IsDBNull(dbReader("FooterFontName").ToString) Then cboFooterFontName.Text = dbReader("FooterFontName").ToString
            If IsNumeric(dbReader("HeaderFontSize").ToString) Then cboHeaderFontSize.Text = CInt(dbReader("HeaderFontSize").ToString)
            If IsNumeric(dbReader("DetailFontSize").ToString) Then cboDetailFontSize.Text = CInt(dbReader("DetailFontSize").ToString)
            If IsNumeric(dbReader("FooterFontSize").ToString) Then cboFooterFontSize.Text = CInt(dbReader("FooterFontSize").ToString)

            'AlertNumbers
            If Not IsDBNull(dbReader("AlertNumbers").ToString) Then txtAlertMobileNo.Text = dbReader("AlertNumbers").ToString
            'txtFinancialBankAccount
            'If Not IsDBNull(dbReader("AccountNumber").ToString) Then txtFinancialBankAccount.Text = dbReader("AccountNumber").ToString

            chkVatAutoExpenses.Checked = False
            chkVatAutoReceipts.Checked = False

            If Not IsDBNull(dbReader("AutoComputeCashbookExpensesVat").ToString) Then
                If UCase(dbReader("AutoComputeCashbookExpensesVat").ToString) = "Y" Then
                    chkVatAutoExpenses.Checked = True
                End If
            End If

            If Not IsDBNull(dbReader("AutoComputeCashbookReceiptsVat").ToString) Then
                If UCase(dbReader("AutoComputeCashbookReceiptsVat").ToString) = "Y" Then
                    chkVatAutoReceipts.Checked = True
                End If
            End If

        End While
        dbReader.Close()

        LoadCommissions()

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

        'Get the document headers 
        myCommand = New Data.OleDb.OleDbCommand("SELECT * FROM DocumentHeaders", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            If Not IsDBNull(dbReader("Receipt").ToString) Then txtReceiptHeader.Text = dbReader("Receipt").ToString
            If Not IsDBNull(dbReader("Invoice").ToString) Then txtInvoiceHeader.Text = dbReader("Invoice").ToString
            If Not IsDBNull(dbReader("CreditNote").ToString) Then txtCreditNoteHeader.Text = dbReader("CreditNote").ToString
            If Not IsDBNull(dbReader("DebitNote").ToString) Then txtDebitNoteHeader.Text = dbReader("DebitNote").ToString
            If Not IsDBNull(dbReader("GatePass").ToString) Then txtGatePassHeader.Text = dbReader("GatePass").ToString
            If Not IsDBNull(dbReader("Quotation").ToString) Then txtQuotationHeader.Text = dbReader("Quotation").ToString
            If Not IsDBNull(dbReader("Orders").ToString) Then txtOrdersHeader.Text = dbReader("Orders").ToString
            If Not IsDBNull(dbReader("Proforma").ToString) Then txtProformaHeader.Text = dbReader("Proforma").ToString
            If Not IsDBNull(dbReader("DocumentPrefix").ToString) Then txtDocumentPrefix.Text = dbReader("DocumentPrefix").ToString
        End If
        dbReader.Close()

        'Load machine status values
        If System.IO.File.Exists(Application.StartupPath & "\Data\Macstatus") Then
            Dim objFileReader As New StreamReader(Application.StartupPath & "\Data\Macstatus")
            Dim strLine As String = UCase(objFileReader.ReadLine)
            objFileReader.Close()
            If Not String.IsNullOrEmpty(strLine) Then
                If strLine <> "CASHOUT" Then cboMachineStatus.Text = "OTHER" Else cboMachineStatus.Text = "CASHOUT"
            End If
        Else
            cboMachineStatus.Text = "OTHER"
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCritical & "On Company Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub SaveDocumentHeaders()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM DocumentHeaders", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO DocumentHeaders " _
            & "(Receipt, Quotation, Invoice, CreditNote, DebitNote, GatePass, Orders, Proforma, DocumentPrefix) VALUES " _
            & "('" & txtReceiptHeader.Text & "', '" & txtQuotationHeader.Text & "', " _
            & "'" & txtInvoiceHeader.Text & "', '" & txtCreditNoteHeader.Text & "', " _
            & "'" & txtDebitNoteHeader.Text & "', '" & txtGatePassHeader.Text & "', " _
            & "'" & txtOrdersHeader.Text & "', '" & txtProformaHeader.Text & "', '" & txtDocumentPrefix.Text & "')", cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCritical & "On Company Document Headers Save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCommissions()
        On Error GoTo RaiseErr
        Dim myCommand As New Data.OleDb.OleDbCommand("SELECT EmployeeClass, ExpensesRate, CommissionRate " _
            & "FROM HairDressingCommissions ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader()
        While objReader.Read
            dGridRates.Rows.Add()
            If Not IsDBNull(objReader(0).ToString) Then dGridRates.Rows(dGridRates.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridRates.Rows(dGridRates.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGridRates.Rows(dGridRates.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Commissions Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccount.SelectedIndexChanged
        lblAccountDescription.Text = ""
        If Not cboAccount.SelectedItem Is Nothing Then
            lblAccountDescription.Text = cboAccount.SelectedItem.Col2
        End If
    End Sub

    Private Sub LoadCashbooks()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountNumber +';'+AccountName AS " _
            & "[Accounts] FROM Cashbooks ORDER BY AccountNumber"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboAccount
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;180"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM Cashbooks", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboAccount.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()
        If intItemsCount > 0 Then
            cboAccount.SelectedIndex = -1
            cboAccount.Items.Clear()
            cboAccount.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboAccount.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Cashbooks Details Load"
        gwt_comm.ShowErrorMessage()
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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmOrganization_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboBudgetYear.Items.Clear()
        Dim intCurrentYr As Integer = DatePart(DateInterval.Year, Now)
        Dim intBaseYear As Integer = intCurrentYr + 1
        For p As Integer = 0 To 4
            intCurrentYr = intCurrentYr + p
            cboBudgetYear.Items.Add(Format(intCurrentYr, "0000"))
        Next
        cboBudgetYear.Text = intBaseYear

        boolAbort = False
        LoadFonts()
        If boolAbort = True Then Me.Close()
        LoadCashbooks()
        If boolAbort = True Then Exit Sub
        GetSerialPortNames()
        If boolAbort = True Then Exit Sub
        LoadEmployeeClasses()
        If boolAbort = True Then Exit Sub
        LoadBranches()
        If boolAbort = True Then Exit Sub
        LoadBankDetails()
        If boolAbort = True Then Exit Sub
        LoadCurrencies()
        If boolAbort = True Then Exit Sub
        LoadDetails()
        If boolAbort = True Then Exit Sub
        LoadOrganizationValues()
        If boolAbort = True Then Exit Sub
        LoadCurrencyData()
        If boolAbort = True Then Exit Sub
        LoadBarCodeParameters()
        If boolAbort = True Then Exit Sub
        LoadBranchesToGrid()
        If boolAbort = True Then Exit Sub
        LoadControlNumbers()
        If boolAbort = True Then Exit Sub
        LoadUsers()
        If boolAbort = True Then Exit Sub
        LoadTaxParameters()
        If boolAbort = True Then Exit Sub
        'LoadAlternateBank()
        'If boolAbort = True Then Exit Sub
        SalesTermsAndConditions()
        SuperTabControl1.SelectedTabIndex = 0
        Me.TabControl2.SelectedIndex = 0
        SuperTabControl3.SelectedTabIndex = 0
        'SuperTabControl2.SelectedTabIndex = 0
    End Sub

    Private Sub SalesTermsAndConditions()
        On Error GoTo RaiseErr
        dGridTerms.Rows.Add(25)
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Description FROM SalesGurantees", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        Dim i As Integer = 0
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then dGridTerms.Rows(i).Cells(0).Value = objReader(0).ToString
            i = i + 1
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sales Conditions Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub SaveTermsAndConditions()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SalesGurantees", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGridTerms.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGridTerms.Rows(i).Cells(0).Value), "")) Then
                Dim strDescription As String = dGridTerms.Rows(i).Cells(0).Value.ToString
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SalesGurantees (Description) VALUES ('" & strDescription & "')", cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next
        gwt_comm.AssignDefaults()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sales Conditions Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCurrencies()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CurrencyName FROM Currencies ORDER BY CurrencyName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboDefaultCurrency.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboDefaultCurrency.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Currencies Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub tsSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSave.Click
        On Error GoTo RaiseErr
        boolAbort = False
        Dim myCommand As Data.OleDb.OleDbCommand

        If Not IsNumeric(txtDocLines.Text) Then txtDocLines.Text = "23"

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
        If String.IsNullOrEmpty(cboOffering.Text) Then
            MessageBox.Show("Please select the main service offering", "Invalid Service Offering", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.SuperTabControl1.SelectedTabIndex = 7
            cboOffering.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboInventoryValuation.Text) Then
            cboInventoryValuation.SelectedText = "NONE"
            cboInventoryValuation.Text = "NONE"
        End If

        If String.IsNullOrEmpty(cboDefaultSearchFilter.Text) Then
            cboDefaultSearchFilter.SelectedText = "ITEM CODE"
            cboDefaultSearchFilter.Text = "ITEM CODE"
        End If

        If Not IsNumeric(txtFreeVisits.Text) Then txtFreeVisits.Text = "0"

        If String.IsNullOrEmpty(cboSalesProcessType.Text) Then
            cboSalesProcessType.Text = "NORMAL"
        End If

        Dim strCut As String = "NO"
        If chkCutPaper.Checked = True Then strCut = "YES"

        Dim strPrintType As String = "WINDOWS"
        If optDotMatrix.Checked = True Then strPrintType = "RAW"

        Dim strPrintClaim As String = "NO"
        Dim strIgnoreZeroStock As String = "NO"
        Dim strSmsSalesReports As String = "NO"

        If chkPrintClaims.Checked Then strPrintClaim = "YES"

        Dim strRoundExchangeAmounts As String = "YES"
        Dim strRequestForReceiptPrinter As String = "NO"
        If chkRoundAmounts.Checked Then
            strRoundExchangeAmounts = "YES"
        Else
            strRoundExchangeAmounts = "NO"
        End If

        Dim strSalesDescriptionUpdate As String = "NO"
        If chkDescriptionUpdate.Checked Then
            strSalesDescriptionUpdate = "YES"
        End If

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

        If chkIgnoreZeroQuantity.Checked Then
            strIgnoreZeroStock = "YES"
        Else
            strIgnoreZeroStock = "NO"
        End If

        'SmsSalesStatus, SmsSalesNumbers
        If chkSmsSalesFigures.Checked Then
            strSmsSalesReports = "YES"
        Else
            strSmsSalesReports = "NO"
        End If

        Dim strComplexity As String = "NO"
        Dim strPassExpiry As String = "NO"

        Dim strMaintainDate As String = "NO"
        If chkMaintainDate.Checked = True Then
            strMaintainDate = "YES"
        End If

        Dim strInvoicePrintToPOS As String = "NO"
        'chkInvoicePosPrinter
        If chkInvoicePosPrinter.Checked = True Then
            strInvoicePrintToPOS = "YES"
        End If

        Dim strPostSalesDirectlyToCashbook As String = "YES" 'This is the default setting
        If chkDirectCashbookPosting.Checked = False Then
            strPostSalesDirectlyToCashbook = "NO"
        End If

        Dim strMachineStatus As String = "OTHER"
        If Not String.IsNullOrEmpty(cboMachineStatus.Text) Then
            strMachineStatus = UCase(cboMachineStatus.Text)
        End If

        Dim strOnlineInventoryTransferFlag As String = "NO"
        If chkOnlineTransfers.Checked = True Then
            strOnlineInventoryTransferFlag = "YES"
        End If

        Dim strConfirmReceiptPrint As String = "NO"
        If chkConfirmReceiptPrint.Checked = True Then
            strConfirmReceiptPrint = "YES"
        End If

        Dim strIgnoreSerialNumbers As String = "NO"
        If chkIgnoreSerialNumbers.Checked = True Then
            strIgnoreSerialNumbers = "YES"
        End If

        If chkPasswordComplexity.Checked = True Then
            strComplexity = "YES"
        End If

        If chkPaswordExpiry.Checked = True Then
            strPassExpiry = "YES"
        End If

        If String.IsNullOrEmpty(cboCostOfGoodsValuationMethod.Text) Then
            cboCostOfGoodsValuationMethod.Text = "Sales Based"
        End If

        'IgnoreReturnsDocNo
        Dim strIgnoreReturnsDocNo As String = "NO"
        If chkIgnoreReturnsDocNumber.Checked = True Then
            strIgnoreReturnsDocNo = "YES"
        End If

        If Not IsNumeric(txtPassDays.Text) Then txtPassDays.Text = "0"

        Dim strAutoSellingPriceUpdate As String = "NO"
        If chkSellingPriceAutoUpdate.Checked = True Then
            strAutoSellingPriceUpdate = "YES"
        End If

        Dim strServiceOffering As String = "PRODUCTS"
        Select Case UCase(cboOffering.Text)
            Case Is = "PRODUCTS"
                strServiceOffering = "PRODUCTS"
            Case Is = "SERVICES"
                strServiceOffering = "SERVICES"
            Case Is = "HIRING ITEMS"
                strServiceOffering = "HIRING ITEMS"
            Case Else
                strServiceOffering = "ALL TRADES"
        End Select
        If Not IsNumeric(txtRoundDownValue.Text) Then txtRoundDownValue.Text = "0"
        If Not IsNumeric(txtProfessionalFees.Text) Then txtProfessionalFees.Text = "0"
        If String.IsNullOrEmpty(cboSalesFormType.Text) Then cboSalesFormType.Text = "PINNED STANDARD"
        If String.IsNullOrEmpty(cboCashReceiptType.Text) Then cboCashReceiptType.Text = "POS RECEIPT PRINTER"

        Dim strAllowSpacesOnItemCodes As String = "NO"
        If chkAllowSpaces.Checked = True Then strAllowSpacesOnItemCodes = "YES"

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

        If String.IsNullOrEmpty(cboStoresManagementType.Text) Then cboStoresManagementType.Text = "DE-CENTRALIZED"
        If String.IsNullOrEmpty(cboStoresBranches.Text) Then cboStoresBranches.Text = "NONE"

        Dim strAllowItemQtyChange As String = "NO"
        If chkAllowInventoryQuantityChange.Checked = True Then strAllowItemQtyChange = "YES"

        If Not IsNumeric(txtXposition.Text) Then txtXposition.Text = "100"
        If Not IsNumeric(txtYposition.Text) Then txtYposition.Text = "100"

        If Not IsNumeric(txtXwatermark.Text) Then txtXwatermark.Text = "250"
        If Not IsNumeric(txtYwatermark.Text) Then txtYwatermark.Text = "300"

        Dim strInvoiceDesignType As String = "GENERIC"
        If Not String.IsNullOrEmpty(cboInvoiceType.Text) Then strInvoiceDesignType = UCase(cboInvoiceType.Text)

        intFiscalBonType = 0
        If Not String.IsNullOrEmpty(cboBonType.Text) Then
            Dim strData() As String = Split(cboBonType.Text, "-")
            If IsNumeric(strData(0)) Then
                intFiscalBonType = CInt(Trim(strData(0)))
            End If
        End If

        If String.IsNullOrEmpty(cboComPort.Text) Then
            If UCase(strPublicTaxFiscalStatus) = "YES" Then
                MessageBox.Show("Please select the printer communication port", "Invalid Printer Port", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboComPort.Focus()
                Exit Sub
            End If
        End If

        If Not IsNumeric(cboBaudRate.Text) Then
            MessageBox.Show("Please a valid baud rate", "Invalid Baud Rate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboBaudRate.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtPrinterType.Text) Then
            txtPrinterType.Text = "2000"
        End If

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

        If String.IsNullOrEmpty(lblAccountDescription.Text) Then
            cboAccount.Text = ""
        End If

        If String.IsNullOrEmpty(cboClaimsBalance.Text) Then
            cboClaimsBalance.Text = "Claim Value"
        End If

        Dim strClassicExpensesCaptureStatus As String = "YES"
        If chkClassicExpensesCapture.Checked = False Then
            strClassicExpensesCaptureStatus = "NO"
        End If

        Dim strVatAutoExpenses As String = "N"
        Dim strVatAutoReceipts As String = "N"

        If chkVatAutoExpenses.Checked = True Then strVatAutoExpenses = "Y"
        If chkVatAutoReceipts.Checked = True Then strVatAutoReceipts = "Y"

        Dim strTillSlipfilePath As String = Nothing
        If Not String.IsNullOrEmpty(txtTillslipPath.Text) Then
            strTillSlipfilePath = txtTillslipPath.Text
        End If

        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        myCommand = New Data.OleDb.OleDbCommand("DELETE FROM Company", cnn)
        myCommand.ExecuteNonQuery()
        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO Company (CompanyName, Address1, " _
            & "Address2, Address3, Address4, Telephone, " _
            & "FaxNumber, EmailAddress, ContactPerson, VatNumber, " _
            & "RegistrationNumber, ContactCell, LogoPath, PasswordComplexity, " _
            & "PasswordExpiry, ExpiryDays, DefaultCurrency, ExchangeRoundStatus, RequestForReceiptPrinter, " _
            & "ServiceOffering, RoundDownBelow, ProfessionalFees, PrintClaim, IgnoreZeroQuantity, " _
            & "FreeLoyalityVisits, PrinterType, IgnoreSerialNumbers, CosMethod, PayeeNumber, BPNumber, " _
            & "SalariesSenderId, SalariesReceiverId, " _
            & "SalariesSenderName, SalariesReceiverName, SalesFormStyle, AllowSpacesOnItemCodes, " _
            & "WatermarkPath, UseWatermark, AllowItemQtyChange, SalesProcessType, ImageXposition, " _
            & "ImageYposition, Slogan, InvoiceDesignType, BrandImage1, BrandImage2, BrandImage3, " _
            & "BrandImage4, CutReceipt, JobConditions, MaintainTransDate, ConfirmReceiptPrint, " _
            & "StockValuationMethod, StockManagementType, StockMainBranch, AutoSellingPriceUpdate, " _
            & "IgnoreReturnsDocNo, PrinterSerialPortNo, PrinterBaudRate, PrinterSeriesNumber, " _
            & "HeaderFontName, DetailFontName, FooterFontName, HeaderFontSize, DetailFontSize, " _
            & "FooterFontSize, AlertNumbers, SmsSalesStatus, SmsSalesNumbers, DirectCashbbookSalesPosting, " _
            & "CashReceiptType, OnlineInventoryTransfer, Country, BrandsYposition, BrandsXposition, " _
            & "DefaultSearchFilter, PrintInvoiceToPos, Tiling, WatermarkX, WatermarkY, DefaultSalesCashbook, " _
            & "DocumentLines, ClaimBalanceComputation, CoyMode, " _
            & "SalesDescriptionUpdate, ClassicExpensesCaptureStatus, BudgetYear, " _
            & "AutoComputeCashbookReceiptsVat, AutoComputeCashbookExpensesVat, 
            FiscalBonType, [TillslipCopyPath]) VALUES " _
            & "('" & txtCoyName.Text & "', '" & txtAddress1.Text & "', '" & txtAddress2.Text & "', " _
            & "'" & txtAddress3.Text & "', '" & txtAddress4.Text & "', '" & txtTelephone.Text & "', " _
            & "'" & txtFaxNumber.Text & "', '" & txtEmailAddress.Text & "', '" & txtContactPerson.Text & "', " _
            & "'" & txtVatNumber.Text & "', " _
            & "'" & txtCompanyNumber.Text & "', '" & txtCellphone.Text & "', '" & txtLogoPath.Text & "', " _
            & "'" & strComplexity & "', '" & strPassExpiry & "', " & CInt(txtPassDays.Text) & ", " _
            & "'" & cboDefaultCurrency.Text & "', '" & strRoundExchangeAmounts & "', '" & strRequestForReceiptPrinter & "', " _
            & "'" & strServiceOffering & "', " & txtRoundDownValue.Text & ", " & txtProfessionalFees.Text & ", " _
            & "'" & strPrintClaim & "', '" & strIgnoreZeroStock & "', " & txtFreeVisits.Text & ", '" & strPrintType & "', " _
            & "'" & strIgnoreSerialNumbers & "', '" & cboCostOfGoodsValuationMethod.Text & "', " _
            & "'" & txtPayeNumber.Text & "', '" & txtBpNumber.Text & "', " _
            & "'" & txtSenderId.Text & "', '" & txtReceiverId.Text & "', " _
            & "'" & txtSenderName.Text & "', '" & txtReceiverName.Text & "', '" & cboSalesFormType.Text & "', " _
            & "'" & strAllowSpacesOnItemCodes & "', '" & strWatermarkPath & "', '" & strUseWatermark & "', " _
            & "'" & strAllowItemQtyChange & "', '" & cboSalesProcessType.Text & "', " & txtXposition.Text & ", " _
            & "" & txtYposition.Text & ", '" & txtSlogan.Text & "', '" & strInvoiceDesignType & "', '" & txtBrandImage1.Text & "', " _
            & "'" & txtBrandImage2.Text & "', '" & txtBrandImage3.Text & "', '" & txtBrandImage4.Text & "', " _
            & "'" & strCut & "', '" & txtJobCardConditions.Text & "', '" & strMaintainDate & "', " _
            & "'" & strConfirmReceiptPrint & "', '" & cboInventoryValuation.Text & "', '" & cboStoresManagementType.Text & "', " _
            & "'" & cboStoresBranches.Text & "', '" & strAutoSellingPriceUpdate & "', '" & strIgnoreReturnsDocNo & "', " _
            & "'" & cboComPort.Text & "', " & cboBaudRate.Text & ", " & txtPrinterType.Text & ", " _
            & "'" & cboHeaderFontName.Text & "', '" & cboDetailFontName.Text & "', '" & cboFooterFontName.Text & "', " _
            & "" & CInt(cboHeaderFontSize.Text) & ", " & CInt(cboDetailFontSize.Text) & ", " & CInt(cboFooterFontSize.Text) & ", " _
            & "'" & txtAlertMobileNo.Text & "', '" & strSmsSalesReports & "', '" & txtDestinationSalesNumbers.Text & "', " _
            & "'" & strPostSalesDirectlyToCashbook & "', '" & cboCashReceiptType.Text & "', '" & strOnlineInventoryTransferFlag & "', " _
            & "'" & cboCountry.Text & "', " & CInt(txtBrandsYposition.Text) & ", " & CInt(txtBrandsXposition.Text) & ", " _
            & "'" & cboDefaultSearchFilter.Text & "', '" & strInvoicePrintToPOS & "', '" & cboTiling.Text & "', " _
            & "" & CInt(txtXwatermark.Text) & ", " & CInt(txtYwatermark.Text) & ", '" & cboAccount.Text & "', " _
            & "" & txtDocLines.Text & ", '" & cboClaimsBalance.Text & "', '" & cboRunMode.Text & "', " _
            & "'" & strSalesDescriptionUpdate & "', '" & strClassicExpensesCaptureStatus & "', " _
            & "'" & cboBudgetYear.Text & "', '" & strVatAutoReceipts & "', 
            '" & strVatAutoExpenses & "', " & intFiscalBonType & ", '" & strTillSlipfilePath & "')", cnn)
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

        'Save the commision rates
        myCommand = New Data.OleDb.OleDbCommand("DELETE FROM HairDressingCommissions", cnn)
        myCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGridRates.Rows.Count - 1
            Dim strClass As String = Nothing
            Dim dblExpenses As Double = 0
            Dim dblCommissions As Double = 0
            If Not (Object.Equals(Convert.ToString(dGridRates.Rows(i).Cells(0).Value), "")) Then
                strClass = dGridRates.Rows(i).Cells(0).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGridRates.Rows(i).Cells(1).Value), "")) Then
                If IsNumeric(dGridRates.Rows(i).Cells(1).Value.ToString) Then
                    dblExpenses = CDbl(dGridRates.Rows(i).Cells(1).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridRates.Rows(i).Cells(2).Value), "")) Then
                If IsNumeric(dGridRates.Rows(i).Cells(2).Value) Then
                    dblCommissions = CDbl(dGridRates.Rows(i).Cells(2).Value.ToString)
                End If
            End If
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO HairDressingCommissions (EmployeeClass, " _
                & "ExpensesRate, CommissionRate) VALUES ('" & strClass & "', " _
                & "" & dblExpenses & ", " & dblCommissions & ")", cnn)
            myCommand.ExecuteNonQuery()
        Next

        If boolAbort = True Then Exit Sub
        SaveCurrencyData()
        If boolAbort = True Then Exit Sub
        SaveBarcodeParameters()
        If boolAbort = True Then Exit Sub
        SaveDocumentHeaders()
        If boolAbort = True Then Exit Sub
        SaveControlNumbers()
        If boolAbort = True Then Exit Sub
        SaveTaxParameters()
        If boolAbort = True Then Exit Sub
        'SaveAlternateBank()
        'If boolAbort = True Then Exit Sub
        SaveTermsAndConditions()
        MessageBox.Show("Company details have been saved successfully", "Company Details Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Company Details Maintenance"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadBarCodeParameters()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT MaximumLength, UserLength FROM BarcodeParameters", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtBarcodeLength.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtBarcodeUserLength.Text = objReader(1).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Company Details Maintenance"
        gwt_comm.ShowErrorMessage()
    End Sub

    '    Private Sub SaveAlternateBank()
    '        On Error GoTo RaiseErr

    '        'First delete any existing records
    '        Dim strSql As String = "DELETE FROM AlternateCoyBank"
    '        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
    '        objCommand.ExecuteNonQuery()

    '        strSql = "INSERT INTO [AlternateCoyBank] ([BankCode], [BankName], [AccountNumber], [BranchName], [AccountName]) " _
    '            & "VALUES ('" & txtAlternateBankCode.Text & "', '" & txtAlternateBankName.Text & "', " _
    '            & "'" & txtAlternateAccountNumber.Text & "', '" & txtAlternateBranchName.Text & "', " _
    '            & "'" & txtAlternateAccountName.Text & "')"
    '        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
    '        objCommand.ExecuteNonQuery()

    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " " & Err.Number & " on alternate bank details save"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    '    Private Sub LoadAlternateBank()
    '        On Error GoTo RaiseErr
    '        Dim strSql As String = "SELECT * FROM AlternateCoyBank"
    '        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
    '        If objReader.HasRows Then
    '            objReader.Read()
    '            If Not IsDBNull(objReader("BankCode").ToString) Then txtAlternateBankCode.Text = objReader("BankCode").ToString
    '            If Not IsDBNull(objReader("AccountNumber").ToString) Then txtAlternateAccountNumber.Text = objReader("AccountNumber").ToString
    '            If Not IsDBNull(objReader("BranchName").ToString) Then txtAlternateBranchName.Text = objReader("BranchName").ToString
    '            If Not IsDBNull(objReader("AccountName").ToString) Then txtAlternateAccountName.Text = objReader("AccountName").ToString
    '            If Not IsDBNull(objReader("BankName").ToString) Then txtAlternateBankName.Text = objReader("BankName").ToString
    '        End If
    '        objReader.Close()
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " " & Err.Number & " on alternate bank details load"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    Private Sub SaveBarcodeParameters()
        On Error GoTo RaiseErr
        If Not IsNumeric(txtBarcodeLength.Text) Then
            txtBarcodeLength.Text = "20"
        End If
        If Not IsNumeric(txtBarcodeUserLength.Text) Then
            txtBarcodeUserLength.Text = "6"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM BarcodeParameters", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO BarcodeParameters (MaximumLength, UserLength) VALUES (" & txtBarcodeLength.Text & ", " & txtBarcodeUserLength.Text & ")", cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Company Details Maintenance"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadDetails()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT OrdinalNo, " _
            & "CostCenterName FROM SystemCostCenters ORDER BY OrdinalNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        dGridCostCenters.Rows.Clear()
        dGridDepartments.Rows.Clear()
        dGridPaypoints.Rows.Clear()

        While objReader.Read
            dGridCostCenters.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridCostCenters.Rows(dGridCostCenters.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridCostCenters.Rows(dGridCostCenters.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
        End While
        objReader.Close()

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT OrdinalNo, " _
            & "PayPointName FROM SystemPayPoints ORDER BY OrdinalNo", cnn)
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            dGridPaypoints.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridPaypoints.Rows(dGridPaypoints.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridPaypoints.Rows(dGridPaypoints.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
        End While
        objReader.Close()

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT OrdinalNo, " _
            & "DepartmentName FROM SystemDepartments ORDER BY OrdinalNo", cnn)
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            dGridDepartments.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridDepartments.Rows(dGridDepartments.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridDepartments.Rows(dGridDepartments.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
        End While
        objReader.Close()

        AlternateColors(dGridBranches)
        AlternateColors(dGridCostCenters)
        AlternateColors(dGridDepartments)
        AlternateColors(dGridPaypoints)
        AlternateColors(dGridRates)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Work Structure Details Load"
        gwt_comm.ShowErrorMessage()
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

    Private Sub btnAddDepartments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDepartments.Click
        'strWorkStructureType = "Department"
        'Dim f As New frmWorkStructures
        boolEditStatusTwo = False
        gwt_comm.DepartmentSetup()
        LoadDetails()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(txtCurrencyName.Text) Then
            MessageBox.Show("Please enter the name or country or both for the currency.", "Missing Currency Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCurrency.Focus()
            txtCurrency.SelectAll()
            Exit Sub
        End If
        If Not IsNumeric(txtRate.Text) Then
            MessageBox.Show("Please enter a valid currency rate", "Invalid Currency Rate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRate.Focus()
            txtRate.SelectAll()
            Exit Sub
        End If
        With dGrid
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = txtCurrencyName.Text
            .Rows(.Rows.Count - 1).Cells(1).Value = Format(CDbl(txtRate.Text), "##0.000000")
        End With
        txtCurrency.Text = "" : txtRate.Text = "0.00" : txtCurrency.Focus()
    End Sub

    Private Sub txtRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate.KeyPress
        If Asc(e.KeyChar) = 13 Then btnAdd.Focus()
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtCurrency_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            txtRate.Focus()
            txtRate.SelectAll()
        End If
    End Sub

    Private Sub LoadCurrencyData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CurrencyName, CurrencyRate FROM Currencies ORDER BY CurrencyName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            With dGrid
                .Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                If IsNumeric(objReader(1).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = Format(CDbl(objReader(1).ToString), "##0.000000")
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & "error number " & Err.Number & vbCrLf & "Error encountered while loading multi currency rates"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub SaveCurrencyData()
        On Error GoTo RaiseErr
        Dim objDelete As New Data.OleDb.OleDbCommand("DELETE FROM Currencies", cnn)
        objDelete.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strCurrency As String = Nothing
            Dim dblRate As Double = 0
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strCurrency = dGrid.Rows(i).Cells(0).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(1).Value.ToString) Then
                    dblRate = CDbl(dGrid.Rows(i).Cells(1).Value.ToString)
                End If
            End If
            Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO Currencies (CurrencyName, CurrencyRate) VALUES ('" & strCurrency & "', " & dblRate & ")", cnn)
            objCommand.ExecuteNonQuery()
        Next
        txtCurrency.Text = "" : txtRate.Text = "0.00"
        LoadCurrencies()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & "error number " & Err.Number & vbCrLf & "Error encountered while updating multi currency rates"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAddNewBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewBranch.Click
        boolEditStatus = False
        Dim f As New frmBranchDetails
        f.ShowDialog()
        LoadBranchesToGrid()
        LoadBranches()
    End Sub

    Private Sub GetSelected()
        If dGridBranches.Rows.Count > 0 Then
            intSelectedTransaction = dGridBranches.CurrentRow.Cells(0).Value.ToString
        End If
    End Sub

    Private Sub DeleteBranch()
        On Error GoTo RaiseErr
        GetSelected()
        If MessageBox.Show("Are you sure you want to delete the selected branch from the system?", "Record Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM Branches WHERE TransactionId = " & intSelectedTransaction & "", cnn)
            sqlCommand.ExecuteNonQuery()
        End If
        LoadBranches()
        LoadBranchesToGrid()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Record Deletion Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadBranchesToGrid()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT TransactionId, BranchName FROM Branches ORDER BY BranchName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGridBranches.Rows.Clear()
        While objReader.Read
            dGridBranches.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridBranches.Rows(dGridBranches.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridBranches.Rows(dGridBranches.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Branch Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGridBranches_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridBranches.CellClick
        If dGridBranches.CurrentCell.ColumnIndex = 2 Then
            If dGridBranches.Rows.Count > 0 Then
                GetSelected()
                boolEditStatus = True
                Dim f As New frmBranchDetails
                f.ShowDialog()
                LoadBranches()
                LoadBranchesToGrid()
            End If
        End If
        If dGridBranches.CurrentCell.ColumnIndex = 3 Then
            If dGridBranches.Rows.Count > 0 Then DeleteBranch()
        End If
    End Sub

    Private Sub AlternateColors(ByVal myGrid As AdvancedDataGridViewControl.AdvancedDatagridview)
        With myGrid
            For i As Integer = 0 To .Rows.Count - 1 Step 2
                For j As Integer = 0 To .Columns.Count - 1
                    Dim foreColor As Color = Color.Black
                    Dim backColor As Color = Color.WhiteSmoke
                    .Rows(i).Cells(j).Style.BackColor = backColor
                    .Rows(i).Cells(j).Style.ForeColor = foreColor
                Next j
            Next i
        End With
    End Sub

    Private Sub LoadEmployeeClasses()
        'SystemEmployeeClasses
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT Description FROM " _
            & "SystemEmployeeClasses ORDER BY Description", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboEmployeeClasses.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboEmployeeClasses.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Master Data Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAddClasses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddClasses.Click
        If Not IsNumeric(txtExpensesRate.Text) Then
            MessageBox.Show("Please enter a numeric value for the Commission Expenses Rate", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtExpensesRate.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtCommissionRate.Text) Then
            MessageBox.Show("Please enter a numeric value for the Commission Expenses Rate", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCommissionRate.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboEmployeeClasses.Text) Then
            MessageBox.Show("Please select the employee class to which applicable", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboEmployeeClasses.Focus()
            Exit Sub
        End If
        With dGridRates
            .Rows.Add(cboEmployeeClasses.Text, txtExpensesRate.Text, txtCommissionRate.Text)
            txtExpensesRate.Clear() : txtCommissionRate.Clear()
            txtExpensesRate.Focus()
        End With
    End Sub

    Private Sub txtFreeVisits_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFreeVisits.KeyPress
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnEditDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDepartment.Click
        boolEditStatusTwo = True
        If dGridDepartments.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGridDepartments.CurrentRow.Cells(0).Value.ToString)
        strSelectedDescription = dGridDepartments.CurrentRow.Cells(1).Value.ToString
        gwt_comm.DepartmentSetup()
        LoadDetails()
    End Sub

    Private Sub btnDeleteDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDepartment.Click
        On Error GoTo RaiseErr
        If dGridDepartments.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGridDepartments.CurrentRow.Cells(0).Value.ToString)
        strSelectedDescription = dGridDepartments.CurrentRow.Cells(1).Value.ToString
        If MessageBox.Show("Are you sure you want to delete " & strSelectedDescription & "?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemDepartments WHERE OrdinalNo = " & intSelectedTransaction & "", cnn)
            objCommand.ExecuteNonQuery()
            gwt_comm.WriteToAuditFile(Now, "All", CStr(intSelectedTransaction), "", "SystemDepartments", "Department Delete", strPublicActiveFullUserName)
            MessageBox.Show("Record has been deleted successfully", "Record Deletion Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDetails()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Department deletion error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrintDepartments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDepartments.Click
        On Error GoTo RaiseErr
        If dGridDepartments.Rows.Count <= 0 Then Exit Sub
        Dim arrPrintDetails As New ArrayList
        With dGridDepartments
            For i As Integer = 0 To .Rows.Count - 1
                Dim strCode As String = Nothing
                Dim strDescription As String = Nothing
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then
                    strCode = .Rows(i).Cells(0).Value.ToString
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "")) Then
                    strDescription = .Rows(i).Cells(1).Value.ToString
                End If
                arrPrintDetails.Add(strCode & ";" & strDescription)
            Next
        End With
        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 2
            .strColumnHeaders = "CODE|DESCRIPTION"
            .strColumnWidths = "120|530"
            .strFooterCaption = "Departments Listing"
            .strMainCaption = UCase("Departments Listing")
            .strMainHeader2 = UCase(strCompanyName)
            .strMainHeader3 = ""
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
            .VerticalLines = False
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("WhiteSmoke")
            .HeaderFont = New Font("Verdana", 10, FontStyle.Bold)
            .FooterFont = New Font("Verdana", 6, FontStyle.Bold)
            .DetailFont = New Font("Verdana", 6, FontStyle.Regular)
            .strPrintValues = strPrintDetails
            .VisibleColumns = "YES|YES"
            .strColumnFormating = "NO|NO"
            .strColumnAlignments = "0|0"
            .strSummaryTotals = "NO|NO"
            .strColumnTotals = "NO|NO"
            .PrintSummary = False
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = True
            .boolPrintRecordCount = True
            .PrintSummary = True
            .intKeyFieldIndex = 0
            .DetailColor = Color.Black
        End With
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Department Listing Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGridDepartments_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridDepartments.DoubleClick
        boolEditStatusTwo = True
        If dGridDepartments.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGridDepartments.CurrentRow.Cells(0).Value.ToString)
        strSelectedDescription = dGridDepartments.CurrentRow.Cells(1).Value.ToString
        gwt_comm.DepartmentSetup()
        LoadDetails()
    End Sub

    Private Sub btnAddCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCostCenter.Click
        boolEditStatusTwo = False
        gwt_comm.CostCenterSetup()
        LoadDetails()
    End Sub

    Private Sub btnEditCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditCostCenter.Click
        boolEditStatusTwo = True
        If dGridCostCenters.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGridCostCenters.CurrentRow.Cells(0).Value.ToString)
        strSelectedDescription = dGridCostCenters.CurrentRow.Cells(1).Value.ToString
        gwt_comm.CostCenterSetup()
        LoadDetails()
    End Sub

    Private Sub btnDeleteCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteCostCenter.Click
        On Error GoTo RaiseErr
        If dGridCostCenters.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGridCostCenters.CurrentRow.Cells(0).Value.ToString)
        strSelectedDescription = dGridCostCenters.CurrentRow.Cells(1).Value.ToString
        If MessageBox.Show("Are you sure you want to delete " & strSelectedDescription & "?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemCostCenters WHERE OrdinalNo = " & intSelectedTransaction & "", cnn)
            objCommand.ExecuteNonQuery()
            gwt_comm.WriteToAuditFile(Now, "All", CStr(intSelectedTransaction), "", "SystemCostCenters", "Cost Center Deletion", strPublicActiveFullUserName)
            MessageBox.Show("Record has been deleted successfully", "Record Deletion Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDetails()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Cost Center deletion error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAddPaypoints_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPaypoints.Click
        boolEditStatusTwo = False
        gwt_comm.PayPointSetup()
        LoadDetails()
    End Sub

    Private Sub btnEditPaypoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditPaypoint.Click
        boolEditStatusTwo = True
        If dGridPaypoints.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGridPaypoints.CurrentRow.Cells(0).Value.ToString)
        strSelectedDescription = dGridPaypoints.CurrentRow.Cells(1).Value.ToString
        gwt_comm.PayPointSetup()
        LoadDetails()
    End Sub

    Private Sub btnDeletePaypoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeletePaypoint.Click
        On Error GoTo RaiseErr
        If dGridPaypoints.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGridPaypoints.CurrentRow.Cells(0).Value.ToString)
        strSelectedDescription = dGridPaypoints.CurrentRow.Cells(1).Value.ToString
        If MessageBox.Show("Are you sure you want to delete " & strSelectedDescription & "?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemPayPoints WHERE OrdinalNo = " & intSelectedTransaction & "", cnn)
            objCommand.ExecuteNonQuery()

            gwt_comm.WriteToAuditFile(Now, strSelectedDescription, CStr(intSelectedTransaction), "", "SystemPayPoints", "Pay point deletion", strPublicActiveFullUserName)
            MessageBox.Show("Record has been deleted successfully", "Record Deletion Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDetails()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Pay point deletion error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrintPaypoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPaypoint.Click

    End Sub

    Private Sub dGridPaypoints_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridPaypoints.DoubleClick
        boolEditStatusTwo = True
        If dGridPaypoints.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGridPaypoints.CurrentRow.Cells(0).Value.ToString)
        strSelectedDescription = dGridPaypoints.CurrentRow.Cells(1).Value.ToString
        gwt_comm.PayPointSetup()
        LoadDetails()
    End Sub

    Private Sub dGridCostCenters_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridCostCenters.DoubleClick
        boolEditStatusTwo = True
        If dGridCostCenters.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGridCostCenters.CurrentRow.Cells(0).Value.ToString)
        strSelectedDescription = dGridCostCenters.CurrentRow.Cells(1).Value.ToString
        gwt_comm.CostCenterSetup()
        LoadDetails()
    End Sub

    Private Sub txtCoyName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCoyName.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub btnSaveCurrencies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveCurrencies.Click
        boolAbort = False
        SaveCurrencyData()
        If boolAbort = True Then Exit Sub
        MessageBox.Show("Currency rates saved successfully", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub GetSerialPortNames()
        On Error GoTo RaiseErr
        cboComPort.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            cboComPort.Items.Add(sp)
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Computer Communication Details Load"
        gwt_comm.ShowErrorMessage()
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
        gwt_comm.ShowErrorMessage()
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

    Private Sub txtDocLines_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDocLines.KeyPress
        If Asc(e.KeyChar) = 13 Then Exit Sub
        If Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnPrintCostCenters_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintCostCenters.Click

    End Sub

    Private Sub SaveControlNumbers()
        On Error GoTo RaiseErr
        If Not IsNumeric(txtInvoices.Text) Then txtInvoices.Text = "1"
        If Not IsNumeric(txtQuotes.Text) Then txtQuotes.Text = "1"
        If Not IsNumeric(txtSuppliers.Text) Then txtSuppliers.Text = "1"
        If Not IsNumeric(txtCustomers.Text) Then txtCustomers.Text = "1"
        If Not IsNumeric(txtCreditNotes.Text) Then txtCreditNotes.Text = "1"
        If Not IsNumeric(txtDebitNotes.Text) Then txtDebitNotes.Text = "1"
        If Not IsNumeric(txtCashSales.Text) Then txtCashSales.Text = "1"
        If Not IsNumeric(txtPrescriptions.Text) Then txtPrescriptions.Text = "1"
        If Not IsNumeric(txtPharmacyReceipts.Text) Then txtPharmacyReceipts.Text = "1"
        If Not IsNumeric(txtOrders.Text) Then txtOrders.Text = "1"
        If Not IsNumeric(txtJobCards.Text) Then txtJobCards.Text = "1"
        If Not IsNumeric(txtJobInvoices.Text) Then txtJobInvoices.Text = "1"
        If Not IsNumeric(txtGatePasses.Text) Then txtGatePasses.Text = "1"
        If Not IsNumeric(txtLoyaltyNumbers.Text) Then txtLoyaltyNumbers.Text = "1"
        If Not IsNumeric(txtSupplierInvoices.Text) Then txtSupplierInvoices.Text = "1"
        If Not IsNumeric(txtBillBatchNumber.Text) Then txtBillBatchNumber.Text = "1"
        If Not IsNumeric(txtLayByeNumber.Text) Then txtLayByeNumber.Text = "1"
        If Not IsNumeric(txtSalesTickets.Text) Then txtSalesTickets.Text = "1"
        If Not IsNumeric(txtKeyNumber.Text) Then txtKeyNumber.Text = "1"
        If Not IsNumeric(txtProjects.Text) Then txtProjects.Text = "1"
        If Not IsNumeric(txtPatientReference.Text) Then txtPatientReference.Text = "1"
        If Not IsNumeric(txtRejections.Text) Then txtRejections.Text = "1"
        If Not IsNumeric(txtIod.Text) Then txtIod.Text = "1"
        If Not IsNumeric(txtProjectClaims.Text) Then txtProjectClaims.Text = "1"
        If Not IsNumeric(txtProformas.Text) Then txtProformas.Text = "1"

        If Not IsNumeric(txtPermitInvoices.Text) Then txtPermitInvoices.Text = "1"
        If Not IsNumeric(txtPurchaseOrders.Text) Then txtPurchaseOrders.Text = "1"

        If Not IsNumeric(txtTrustReceipts.Text) Then txtTrustReceipts.Text = "1"
        If Not IsNumeric(txtDebtorsReceipts.Text) Then txtDebtorsReceipts.Text = "1"

        If Not IsNumeric(txtStatements.Text) Then txtStatements.Text = "1"

        Dim strBaseDate As String = Format(CInt(DatePart(DateInterval.Year, Now)), "0000") & Format(CInt(DatePart(DateInterval.Month, Now)), "00")
        ''SupplierInvoices from ControlNumbers
        Dim strSql As String = "INSERT INTO ControlNumbers ([Invoices],[Quotations]," _
            & "[Customers],[Suppliers],[DebitNotes],[CreditNotes],[CashSales], " _
            & "[Prescriptions], [PharmacyReceipts], [Orders], [JobCards], [JobInvoices], " _
            & "[GatePass], [BaseNumber], [LoyaltyNumber], [SupplierInvoices], " _
            & "[BillBatchNumber], [LayByes], [SalesTickets], [KeyNumber], " _
            & "[ProjectsNumber], [PatientReferenceNo], [Returns], [IOD], [ProjectClaims], " _
            & "[Proforma], [PurchaseOrder], [TrustReceipts], [DebtorsReceipts], [PermitInvoices], [StatementNumber]) " _
            & "VALUES (" & txtInvoices.Text & ", " & txtQuotes.Text & ", " & txtCustomers.Text & ", " _
            & "" & txtSuppliers.Text & ", " & txtDebitNotes.Text & ", " & txtCreditNotes.Text & ", " _
            & "" & txtCashSales.Text & ", " & txtPrescriptions.Text & ", " & txtPharmacyReceipts.Text & ", " _
            & "" & txtOrders.Text & ", " & txtJobCards.Text & ", " & txtJobInvoices.Text & ", " _
            & "" & txtGatePasses.Text & ", '" & strBaseDate & "', " & txtLoyaltyNumbers.Text & ", " _
            & "" & txtSupplierInvoices.Text & ", " & txtBillBatchNumber.Text & ", " & txtLayByeNumber.Text & ", " _
            & "" & txtSalesTickets.Text & ", " & txtKeyNumber.Text & ", " & txtProjects.Text & ", " _
            & "" & txtPatientReference.Text & ", " & txtRejections.Text & ", " & txtIod.Text & ", " _
            & "" & txtProjectClaims.Text & ", " & txtProformas.Text & ", " _
            & "" & txtPurchaseOrders.Text & ", " & txtTrustReceipts.Text & ", " & txtDebtorsReceipts.Text & ", " _
            & "" & txtPermitInvoices.Text & ", " & txtStatements.Text & ")"
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM ControlNumbers", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        'Me.Close()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On control number initialization"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadControlNumbers()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM ControlNumbers", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("Invoices").ToString) Then txtInvoices.Text = objReader("Invoices").ToString
            If Not IsDBNull(objReader("Quotations").ToString) Then txtQuotes.Text = objReader("Quotations").ToString
            If Not IsDBNull(objReader("Customers").ToString) Then txtCustomers.Text = objReader("Customers").ToString
            If Not IsDBNull(objReader("Suppliers").ToString) Then txtSuppliers.Text = objReader("Suppliers").ToString
            If Not IsDBNull(objReader("DebitNotes").ToString) Then txtDebitNotes.Text = objReader("DebitNotes").ToString
            If Not IsDBNull(objReader("CreditNotes").ToString) Then txtCreditNotes.Text = objReader("CreditNotes").ToString
            If Not IsDBNull(objReader("CashSales").ToString) Then txtCashSales.Text = objReader("CashSales").ToString
            If Not IsDBNull(objReader("Prescriptions").ToString) Then txtPrescriptions.Text = objReader("Prescriptions").ToString
            If Not IsDBNull(objReader("PharmacyReceipts").ToString) Then txtPharmacyReceipts.Text = objReader("PharmacyReceipts").ToString
            If Not IsDBNull(objReader("Orders").ToString) Then txtOrders.Text = objReader("Orders").ToString
            If Not IsDBNull(objReader("JobCards").ToString) Then txtJobCards.Text = objReader("JobCards").ToString
            If Not IsDBNull(objReader("JobInvoices").ToString) Then txtJobInvoices.Text = objReader("JobInvoices").ToString
            If Not IsDBNull(objReader("GatePass").ToString) Then txtGatePasses.Text = objReader("GatePass").ToString
            If Not IsDBNull(objReader("LoyaltyNumber").ToString) Then txtLoyaltyNumbers.Text = objReader("LoyaltyNumber").ToString
            If Not IsDBNull(objReader("SupplierInvoices").ToString) Then txtSupplierInvoices.Text = objReader("SupplierInvoices").ToString
            If Not IsDBNull(objReader("BillBatchNumber").ToString) Then txtBillBatchNumber.Text = objReader("BillBatchNumber").ToString
            If Not IsDBNull(objReader("LayByes").ToString) Then txtLayByeNumber.Text = objReader("LayByes").ToString
            If Not IsDBNull(objReader("SalesTickets").ToString) Then txtSalesTickets.Text = objReader("SalesTickets").ToString
            If Not IsDBNull(objReader("KeyNumber").ToString) Then txtKeyNumber.Text = objReader("KeyNumber").ToString
            If Not IsDBNull(objReader("ProjectsNumber").ToString) Then txtProjects.Text = objReader("ProjectsNumber").ToString
            If Not IsDBNull(objReader("PatientReferenceNo").ToString) Then txtPatientReference.Text = objReader("PatientReferenceNo").ToString
            If Not IsDBNull(objReader("Returns").ToString) Then txtRejections.Text = objReader("Returns").ToString
            If Not IsDBNull(objReader("IOD").ToString) Then txtIod.Text = objReader("IOD").ToString
            If Not IsDBNull(objReader("ProjectClaims").ToString) Then txtProjectClaims.Text = objReader("ProjectClaims").ToString
            If Not IsDBNull(objReader("Proforma").ToString) Then txtProformas.Text = objReader("Proforma").ToString

            If Not IsDBNull(objReader("PermitInvoices").ToString) Then txtPermitInvoices.Text = objReader("PermitInvoices").ToString
            If Not IsDBNull(objReader("PurchaseOrder").ToString) Then txtPurchaseOrders.Text = objReader("PurchaseOrder").ToString

            If Not IsDBNull(objReader("TrustReceipts").ToString) Then txtTrustReceipts.Text = objReader("TrustReceipts").ToString
            If Not IsDBNull(objReader("DebtorsReceipts").ToString) Then txtDebtorsReceipts.Text = objReader("DebtorsReceipts").ToString
            If Not IsDBNull(objReader("StatementNumber").ToString) Then txtStatements.Text = objReader("StatementNumber").ToString

        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On control number initialization"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadUsers()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT UserName, UserLevel, AccessLevel FROM Users ORDER BY UserName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGridUsers.Rows.Clear()
        While objReader.Read
            dGridUsers.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridUsers.Rows(dGridUsers.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridUsers.Rows(dGridUsers.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            'Show the access level next to the user; the older level name stays in the row for the other buttons
            Dim strAccess As String = Trim(objReader(2).ToString)
            If strAccess = "" Then strAccess = GtiAccessLevelFromLegacy(objReader(1).ToString)
            dGridUsers.Rows(dGridUsers.Rows.Count - 1).Cells(1).Tag = objReader(1).ToString
            dGridUsers.Rows(dGridUsers.Rows.Count - 1).Cells(1).Value = strAccess
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on User Details Load"
        gwt_comm.ShowErrorMessage()
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
            strSelectedUserLevel = Convert.ToString(dGridUsers.CurrentRow.Cells(1).Tag)
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
        'There must always be at least one user with full access
        If UCase(strSelectedUserLevel & "") = "ADMINISTRATOR" Then
            If GtiOwnerCount(strSelectedUser) = 0 Then
                MessageBox.Show("This is the only user with full (Owner) access and cannot be deleted.",
                    "User Record Deletion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtTaxRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTaxRate.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        'If Asc(e.KeyChar) = 13 Then btnSaveAllData.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub SaveTaxParameters()
        If Not IsNumeric(txtTaxRate.Text) Then
            MessageBox.Show("Please enter a numeric value for the tax rate", "Invalid Tax Rate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTaxRate.Focus()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim strFiscalStatus As String = "NO"
        If chkFiscalStatus.Checked = True Then strFiscalStatus = "YES"

        Dim strTaxType As String = "INCLUSIVE"
        If optExclusive.Checked Then strTaxType = "EXCLUSIVE" Else strTaxType = "INCLUSIVE"
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM RegionalTaxes", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO RegionalTaxes (TaxRate, TaxType, FiscalStatus) " _
            & "VALUES (" & txtTaxRate.Text & ", '" & strTaxType & "', '" & strFiscalStatus & "')", cnn)
        objCommand.ExecuteNonQuery()
        'MessageBox.Show("Regional tax rates have been setup successfully", "Tax Rate Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
        dblSalesTaxRate = txtTaxRate.Text
        gwt_comm.AssignDefaults()
        'Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Tax Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadTaxParameters()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT TaxRate, TaxType, FiscalStatus FROM RegionalTaxes", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                txtTaxRate.Text = Format(CDbl(objReader(0).ToString), "##0.00")
            End If
            If Not IsDBNull(objReader(1).ToString) Then
                If UCase(objReader(1).ToString) = "INCLUSIVE" Then
                    optInclusive.Checked = True
                Else
                    optExclusive.Checked = True
                End If
            Else
                optInclusive.Checked = True
            End If
            If Not IsDBNull(objReader(2).ToString) Then
                If UCase(objReader(2).ToString) = "YES" Then
                    chkFiscalStatus.Checked = True
                Else
                    chkFiscalStatus.Checked = False
                End If
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Tax Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    'Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
    '    Me.Close()
    'End Sub

    'Private Sub btnQuotesInvoices_Click(sender As Object, e As System.EventArgs) Handles btnQuotesInvoices.Click
    '    Dim f As New frmInvoiceConditions
    '    f.ShowDialog()
    'End Sub

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

    Private Sub btnFinancials_Click(sender As System.Object, e As System.EventArgs) Handles btnFinancials.Click
        Dim frm As New frmFinancialPeriods
        frm.ShowDialog()
    End Sub

    Private Sub btnAdvancedVatSettings_Click(sender As System.Object, e As System.EventArgs) Handles btnAdvancedVatSettings.Click
        gwt_comm.VatSettings()
    End Sub

    Private Sub btnBroswseTillPath_Click(sender As Object, e As EventArgs) Handles btnBroswseTillPath.Click
        Dim sfd As New FolderBrowserDialog
        sfd.ShowDialog()
        txtTillslipPath.Text = sfd.SelectedPath.ToString
    End Sub

End Class
