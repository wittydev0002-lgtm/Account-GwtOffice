Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module CommonDocumentsPrints

    Public Sub DebitCreditNotePrint(ByVal StatementHeader As String,
                                    ByVal DocumentNo As Integer,
                                    ByVal AccountNumber As String)

        On Error GoTo RaiseErr

        Dim strSqlClientData As String = Nothing
        Dim strMainTransactionData As String = Nothing
        Dim strDetailsData As String = Nothing

        Dim arrTransactionsData As New ArrayList

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        Dim dblTaxFactor As Double = 1

        Dim FiscalDay As String = Nothing
        Dim FiscalInvoiceNumber As String = Nothing
        Dim strInvoiceCurrencyUsed As String = Nothing

        If strTaxComputationType = "INCLUSIVE" Then
            dblTaxFactor = 100 / (dblSalesTaxRate + 100)
        End If

        If UCase(StatementHeader) = "CREDIT NOTE" Then 'It means that is a debtor
            strSqlClientData = "SELECT Customers.AccountName, Customers.Address1, Customers.Address2, Customers.Address3, Customers.Address4, " _
                & "Customers.PhoneNumber, Customers.EmailAddress, Customers.VatNumber FROM Customers WHERE AccountNumber = '" & AccountNumber & "'"
            strMainTransactionData = "SELECT CreditNotesMain.TransDate, CAST((CreditNotesMain.TransTotal - CreditNotesMain.Taxes + CreditNotesMain.Discount) AS DECIMAL (30,2)) AS [SubTotal], " _
                & "CAST(CreditNotesMain.Discount AS DECIMAL (30,2)) AS [Discount], " _
                & "CAST(CreditNotesMain.Taxes AS DECIMAL (30,2)) AS [Taxes], " _
                & "CAST(CreditNotesMain.TransTotal AS DECIMAL (30,2)) AS [Value], 
                [FiscalDay], [FiscalInvoiceNo], [CurrencyUsed] FROM CreditNotesMain " _
                & "WHERE CreditNotesMain.NoteNumber = " & DocumentNo & " AND CreditNotesMain.AccountId = '" & AccountNumber & "'"

            strDetailsData = "SELECT CreditNoteEntries.Description, CreditNoteEntries.Quantity, CreditNoteEntries.UnitPrice, " _
                & "(CreditNoteEntries.Quantity * CreditNoteEntries.UnitPrice * " & dblTaxFactor & ") AS [Value1], " _
                & "CreditNoteEntries.Discount AS [Discount], CreditNoteEntries.Taxes AS [Taxes], " _
                & "(CreditNoteEntries.Quantity * CreditNoteEntries.UnitPrice * " & dblTaxFactor & ") - CreditNoteEntries.Discount + CreditNoteEntries.Taxes AS [Total] " _
                & "FROM CreditNoteEntries WHERE NoteNumber = " & DocumentNo & ""
        Else
            strSqlClientData = "SELECT Suppliers.AccountName, Suppliers.Address1, Suppliers.Address2, Suppliers.Address3, Suppliers.Address4, " _
                & "Suppliers.PhoneNumber, Suppliers.EmailAddress, Suppliers.VatNumber FROM Suppliers WHERE AccountNumber = '" & AccountNumber & "'"
            strMainTransactionData = "SELECT DebitNotesMain.TransDate, CAST((DebitNotesMain.TransTotal - DebitNotesMain.Taxes + DebitNotesMain.Discount) AS DECIMAL (30,2)) AS [SubTotal], " _
                & "CAST(DebitNotesMain.Discount AS DECIMAL (30,2)) AS [Discount], " _
                & "CAST(DebitNotesMain.Taxes AS DECIMAL (30,2)) AS [Taxes], " _
                & "CAST(DebitNotesMain.TransTotal AS DECIMAL (30,2)) AS [Value], 
                [FiscalDay], [FiscalInvoiceNo], [CurrencyUsed] FROM DebitNotesMain " _
                & "WHERE DebitNotesMain.NoteNumber = " & DocumentNo & " AND DebitNotesMain.AccountId = '" & AccountNumber & "'"

            strDetailsData = "SELECT DebitNoteEntries.Description, DebitNoteEntries.Quantity, DebitNoteEntries.UnitPrice, " _
                & "(DebitNoteEntries.Quantity * DebitNoteEntries.UnitPrice * " & dblTaxFactor & ") AS [Value1], " _
                & "DebitNoteEntries.Discount AS [Discount], DebitNoteEntries.Taxes AS [Taxes], " _
                & "(DebitNoteEntries.Quantity * DebitNoteEntries.UnitPrice) - DebitNoteEntries.Discount + DebitNoteEntries.Taxes AS [Total] " _
                & "FROM DebitNoteEntries WHERE NoteNumber = " & DocumentNo & ""
        End If

        objCommand = New Data.OleDb.OleDbCommand(strSqlClientData, cnn)
        objReader = objCommand.ExecuteReader

        Dim strClientName As String = Nothing
        Dim strClientAddress1 As String = Nothing
        Dim strClientAddress2 As String = Nothing
        Dim strClientAddress3 As String = Nothing
        Dim strClientAddress4 As String = Nothing
        Dim strClientTelephone As String = Nothing
        Dim strClientEmailAddress As String = Nothing
        Dim strClientVatNumber As String = Nothing

        Dim strFiscalDay As String = Nothing
        Dim strFiscalInvoiceNo As String = Nothing

        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strClientName = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strClientAddress1 = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strClientAddress2 = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then strClientAddress3 = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then strClientAddress4 = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then strClientTelephone = objReader(5).ToString
            If Not IsDBNull(objReader(6).ToString) Then strClientEmailAddress = objReader(6).ToString
            If Not IsDBNull(objReader(7).ToString) Then strClientVatNumber = objReader(7).ToString

        End If
        objReader.Close()

        Dim doc As New SmartDocumentWriter.DocumentPrint

        With doc

            .CompanyName = UCase(strCompanyName)
            .CompanyAddress1 = UCase(strCompanyAddress1)
            .CompanyAddress2 = UCase(strCompanyAddress2)
            .CompanyAddress3 = UCase(strCompanyAddress3)
            .CompanyAddress4 = UCase(strCompanyAddress4)
            .CompanyTelephone = UCase(strCompanyTelephone)
            .CompanyEmail = strCompanyEmailAddress
            .CompanyVatNumber = UCase(strCompanyVatNumber)
            .CompanyBpNumber = UCase(strCompanyBPNumber)
            .PrintPageBorder = True
            .DrawVerticals = True
            .DocumentHeader = UCase(StatementHeader)
            .BorderColor = Color.LightGray
            .LogoPath = strLogoPath
            .LogoXposition = 100
            .CompanyRegistrationNumber = UCase(strCompanyRegistrationNumber)
            If UCase(strCompanyCountry) = "SOUTH AFRICA" Then
                .CompanyRegCaption = "CK NO."
            Else
                If UCase(.DocumentHeader) = "COOP MEMBER STATEMENT" Then
                    .CompanyRegCaption = "CERTIFICATE NO."
                Else
                    If UCase(.DocumentHeader) = "PLAINTIFF STATEMENT" Or UCase(.DocumentHeader) = "DEFENDANT STATEMENT" Then
                        .CompanyRegCaption = "CASE NO."
                    Else
                        .CompanyRegCaption = "COY NO."
                    End If
                End If
            End If

            .MainCustomerName = UCase(strClientName)
            .MainCustomerAddress1 = strClientAddress1
            .MainCustomerAddress2 = strClientAddress2
            .MainCustomerAddress3 = strClientAddress3
            .MainCustomerAddress4 = strClientAddress4
            .MainCustomerTelephone = strClientTelephone
            .MainCustomerVat = strClientVatNumber
            .MainCustomerTelephone = strClientTelephone
            .MainCustomerEmailAddress = strClientEmailAddress

            .strColumnHeaders = "Description|Qty|Unit|Value|Disc.|Taxes  |Net"
            .strColumnWidths = "200|40|75|75|75|75|75"
            .strColumnAlignments = "0|0|2|2|2|2|2"
            .intNumberOfColumns = 7

            .RightHeader = "CLIENT DETAILS"
            .LeftHeader = "DOCUMENT INFO."

            Dim arrPrintData As New ArrayList

            objCommand = New Data.OleDb.OleDbCommand(strDetailsData, cnn)
            objReader = objCommand.ExecuteReader
            While objReader.Read
                arrPrintData.Add(objReader(0).ToString & "|" & Format(CDbl(objReader(1).ToString), "##0.00") & "|" &
                    Format(CDbl(objReader(2).ToString), "##0.00") & "|" &
                    Format(CDbl(objReader(3).ToString), "##0.00") & "|" &
                    Format(CDbl(objReader(4).ToString), "##0.00") & "|" &
                    Format(CDbl(objReader(5).ToString), "##0.00") & "|" &
                    Format(CDbl(objReader(6).ToString), "##0.00"))
            End While
            objReader.Close()

            Dim strPrintData(0 To (arrPrintData.Count - 1)) As String
            For q As Integer = 0 To arrPrintData.Count - 1
                strPrintData(q) = arrPrintData.Item(q)
            Next

            .PrintData = strPrintData

            Dim dblGross As Double = 0
            Dim dblDiscounted As Double = 0
            Dim dblTaxed As Double = 0
            Dim dblPayable As Double = 0
            Dim strDate As String = Nothing

            objCommand = New Data.OleDb.OleDbCommand(strMainTransactionData, cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsDate(objReader("TransDate").ToString) Then strDate = gwt_comm.shortMonthDateFormat(CDate(objReader("TransDate").ToString))
                If IsNumeric(objReader("Discount").ToString) Then dblDiscounted = CDbl(objReader("Discount").ToString)
                If IsNumeric(objReader("Taxes").ToString) Then dblTaxed = CDbl(objReader("Taxes").ToString)
                If IsNumeric(objReader("Value").ToString) Then dblPayable = CDbl(objReader("Value").ToString)

                If Not IsDBNull(objReader("FiscalDay").ToString) Then strFiscalDay = objReader("FiscalDay").ToString
                If Not IsDBNull(objReader("FiscalInvoiceNo").ToString) Then strFiscalInvoiceNo = objReader("FiscalInvoiceNo").ToString
                If Not IsDBNull(objReader("CurrencyUsed").ToString) Then strInvoiceCurrencyUsed = objReader("CurrencyUsed").ToString

            End If
            objReader.Close()
            dblGross = dblPayable - dblTaxed + dblDiscounted

            .SummaryCaptions = "Gross Value|Less Discounts|Sub Total|Tax Amount|Invoice Total"
            .SummaryValues = Format(dblGross, "##0.00") & "|" & Format(dblDiscounted, "##0.00") & "|" &
                Format((dblGross - dblDiscounted), "##0.00") & "|" & Format(dblTaxed, "##0.00") & "|" & Format(dblPayable, "##0.00")

            Dim arrDocInfo As New ArrayList
            With arrDocInfo
                .Add("DATE|" & strDate)
                .Add("DOC NO.|" & CStr(DocumentNo))
                .Add("FISCAL DAY NO.|" & FiscalDay)
                .Add("ZIMRA INVOICE NO.|" & FiscalInvoiceNumber)
                .Add("CURRENCY|" & strInvoiceCurrencyUsed)
                '.Add("PERIOD|25-JAN-2015 TO 31-JAN-2015")
            End With
            .arrDocumentInformation = arrDocInfo

            .arrCompanyBankDetails = arrCompanyBankDetails
            .PrintBankDetails = True

        End With
        Dim ppd As New PrintPreviewDialog
        ppd.Document = doc
        ppd.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On document printing"
        ShowErrorMessage()
    End Sub

End Module
