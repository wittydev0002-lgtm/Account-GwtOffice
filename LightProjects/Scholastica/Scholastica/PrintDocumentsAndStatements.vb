Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module PrintDocumentsAndStatements

    Public arrAuctionDetails As ArrayList
    Public boolPrinterAlreadySelected As Boolean
    Public dblBetween60and90 As Double
    Public dblSettlementInvoiceTotals As Double
    Public dblBetween30and60 As Double
    Public dblSettlementCreditNotesValue As Double
    Public dblPublicInvoiceTotals As Double
    Public boolPrintingSavedTaxInvoice As Boolean
    Public dblOver90 As Double
    Public dblPublicReceiptsTotals As Double
    Public dblPublicSubUnpaidTotals As Double
    Public dblSettlementCurrentBalance As Double
    Public dblPublicCreditNotesTotals As Double
    Public dblSettlementReceivedToDate As Double
    Public dblUnpaidsBalanceTotal As Double
    Public sDocumentCustomerAddress1 As String
    Public sDocumentCustomerAddress2 As String
    Public sDocumentCustomerAddress3 As String
    Public sDocumentCustomerAddress4 As String
    Public sDocumentCustomerName As String
    Public sDocumentCustomerTelephone As String
    Public sDocumentCustomerVatNumber As String
    Public sDocumentCustomerEmailAddress As String
    Public SettlementDate As Date
    Public strCreditNoteHeader As String
    Public strCurrentUserFullNames As String
    Public strDeliveryNoteFrom As String
    Public strGatePassHeader As String
    Public strInvoiceHeader As String
    Public strQuotationHeader As String
    Public strProformaHeader As String
    Public strSelectedDate As String
    Public dblSettlementReceivedCurrently As Double
    Public arrSettledInvoices As ArrayList

    Public Sub PrintCustomerDocument(DocumentNumber As Long, DocumentType As String)
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        Dim strSqlMain As String = Nothing
        Dim strSqlTransactions As String = Nothing

        'Get the customer details

        Dim sCustomerName As String = Nothing
        Dim sCustomerAddress1 As String = Nothing
        Dim sCustomerAddress2 As String = Nothing
        Dim sCustomerAddress3 As String = Nothing
        Dim sCustomerAddress4 As String = Nothing
        Dim sCustomerTelephone As String = Nothing
        Dim sCustomerEmailAddress As String = Nothing
        Dim sCustomerVatNumber As String = Nothing
        Dim sCustomerBpNumber As String = Nothing

        Dim sAgent As String = Nothing
        Dim sPrintDate As String = Format(Now, "dd-MM-yyyy")
        Dim sComment As String = Nothing

        Select Case UCase(DocumentType)
            Case Is = "INVOICE"
                strSqlMain = "SELECT CustomerSalesMain.CustomerId, Customers.AccountName, Customers.Address1, " _
                    & "Customers.Address2, Customers.Address3, Customers.Address4, Customers.PhoneNumber +' '+ Customers.Cellphone, " _
                    & "Customers.VatNumber, CustomerSalesMain.SalesRep, CONVERT(NVARCHAR, CustomerSalesMain.TransDate, 105), Notes, Customers.BPNumber " _
                    & "FROM CustomerSalesMain, Customers WHERE CustomerSalesMain.CustomerId = Customers.AccountNumber " _
                    & "AND CustomerSalesMain.InvoiceNumber = " & DocumentNumber & ""
                If UCase(strTaxComputationType) = "INCLUSIVE" Then
                    strSqlTransactions = "SELECT Quantity, Description, CAST(SalesPrice - (Taxes/Quantity) AS " _
                        & "DECIMAL (10,2)) AS [Unit Price], CAST(((SalesPrice - (Taxes/Quantity)) * Quantity) AS " _
                        & "DECIMAL (10,2)) AS Gross, CAST(DiscountAllowed AS DECIMAL (10,2)) AS [Discount], " _
                        & "CAST(Taxes AS DECIMAL (10,2)) AS [Taxes], CAST(((((SalesPrice - (Taxes/Quantity)) * Quantity) - " _
                        & "DiscountAllowed) + Taxes) AS DECIMAL (10,2)) AS Total FROM CustomerSales " _
                        & "WHERE InvoiceNumber = " & DocumentNumber & ""
                Else
                    strSqlTransactions = "SELECT Quantity, Description, CAST(SalesPrice AS DECIMAL (10,2)) AS " _
                        & "[Unit Price], CAST((SalesPrice * Quantity) AS DECIMAL (10,2)) AS Gross, " _
                        & "CAST(DiscountAllowed AS DECIMAL (10,2)) AS [Discount], CAST(Taxes AS DECIMAL (10,2)) AS [Taxes], " _
                        & "CAST((((SalesPrice * Quantity) - DiscountAllowed) + Taxes) AS DECIMAL (10,2)) AS Total " _
                        & "FROM CustomerSales WHERE InvoiceNumber = " & DocumentNumber & ""
                End If

            Case Is = "AUCTION STATEMENT"

                strSqlMain = "SELECT Bidders.CardNo, Bidders.GivenNames, Bidders.Address1, " _
                    & "Bidders.Address2, Bidders.Address3, Bidders.Address4, Bidders.Telephone +' '+ Bidders.Cellphone, " _
                    & "CONVERT(NVARCHAR, Bidders.AuctionDate, 105) " _
                    & "FROM Bidders WHERE Bidders.CardNo = " & DocumentNumber & " AND Bidders.AuctionDate = '" & strSelectedDate & "'"

                strSqlTransactions = "SELECT Description +'|'+ Model +'|'+ ItemColor +'|'+ Identification +'|'+ " _
                    & "CONVERT(NVARCHAR, CAST(BidAmount AS DECIMAL (10,2))) +'|'+ " _
                    & "CONVERT(NVARCHAR, CAST((BidAmount * .015) AS DECIMAL (10,2))) +'|'+ " _
                    & "CONVERT(NVARCHAR, CAST(((BidAmount * 0.15) + BidAmount) AS DECIMAL (10,2))) AS [Details] " _
                    & "FROM MocAttachmentDetails WHERE BidderId = " & DocumentNumber & " AND AuctionDate = '" & strSelectedDate & "'"

            Case Is = "SETTLEMENT"
                strSqlMain = "SELECT Customers.AccountNumber, Customers.AccountName, Customers.Address1, " _
                    & "Customers.Address2, Customers.Address3, Customers.Address4, Customers.PhoneNumber +' '+ Customers.Cellphone, " _
                    & "Customers.VatNumber, Customers.BPNumber FROM Customers WHERE Customers.AccountNumber = '" & strSelectedAccount & "'"

            Case Is = "STATEMENT"
                strSqlMain = "SELECT Customers.AccountNumber, Customers.AccountName, Customers.Address1, " _
                    & "Customers.Address2, Customers.Address3, Customers.Address4, Customers.PhoneNumber +' '+ Customers.Cellphone, " _
                    & "Customers.VatNumber, Customers.BPNumber FROM Customers WHERE Customers.AccountNumber = '" & strSelectedAccount & "'"

            Case Is = "STUDENT STATEMENT"
                strSqlMain = "SELECT SC_Students.StudentId, " _
                    & "SC_Students.LastName +' '+ SC_Students.FirstName +' '+ SC_Students.OtherNames AS [Given Names], SC_Students.Address1, " _
                    & "SC_Students.Address2, SC_Students.Address3, SC_Students.Address4, SC_Students.ContactTelephone, " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), SC_Students.EntryDate, 106), ' ', '-')) as [Entry Date], SC_Students.Grade " _
                    & "FROM SC_Students WHERE SC_Students.StudentId = '" & strSelectedAccount & "'"

            Case Is = "STATEMENT OF UNPAIDS"
                strSqlMain = "SELECT Customers.AccountNumber, Customers.AccountName, Customers.Address1, " _
                    & "Customers.Address2, Customers.Address3, Customers.Address4, Customers.PhoneNumber +' '+ Customers.Cellphone, " _
                    & "Customers.VatNumber, Customers.BPNumber FROM Customers WHERE Customers.AccountNumber = '" & strSelectedAccount & "'"

            Case Is = "LEGAL STATEMENT"
                strSqlMain = "SELECT Defendants.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, " _
                    & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
                    & "Defendants.Telephone +' '+ Defendants.Cellphone, " _
                    & "Defendants.FileId AS [VatNumber], Defendants.Status AS [BPNumber] FROM Defendants WHERE " _
                    & "Defendants.DefendantId = '" & strSelectedAccount & "'"

            Case Is = "CREDIT NOTE"
                strSqlMain = "SELECT CreditNotesMain.AccountId, Customers.AccountName, Customers.Address1, " _
                    & "Customers.Address2, Customers.Address3, Customers.Address4, Customers.PhoneNumber +' '+ Customers.Cellphone, " _
                    & "Customers.VatNumber, CreditNotesMain.UserName, CONVERT(NVARCHAR, CreditNotesMain.TransDate, 105), Notes, Customers.BPNumber " _
                    & "FROM CreditNotesMain, Customers WHERE CreditNotesMain.AccountId = Customers.AccountNumber " _
                    & "AND CreditNotesMain.NoteNumber = " & DocumentNumber & ""
                If UCase(strTaxComputationType) = "INCLUSIVE" Then
                    strSqlTransactions = "SELECT Quantity, Description, CAST(UnitPrice - (Taxes/Quantity) AS " _
                        & "DECIMAL (10,2)) AS [Unit Price], CAST(((UnitPrice - (Taxes/Quantity)) * Quantity) AS " _
                        & "DECIMAL (10,2)) AS Gross, CAST((UnitPrice * 0) AS DECIMAL (10,2)) AS [Discount], " _
                        & "CAST(Taxes AS DECIMAL (10,2)) AS [Taxes], CAST(((((UnitPrice - (Taxes/Quantity)) * Quantity) - " _
                        & "0) + Taxes) AS DECIMAL (10,2)) AS Total FROM CreditNoteEntries " _
                        & "WHERE NoteNumber = " & DocumentNumber & ""
                Else
                    strSqlTransactions = "SELECT Quantity, Description, CAST(UnitPrice AS DECIMAL (10,2)) AS " _
                        & "[Unit Price], CAST((UnitPrice * Quantity) AS DECIMAL (10,2)) AS Gross, " _
                        & "CAST((UnitPrice * 0) AS DECIMAL (10,2)) AS [Discount], CAST(Taxes AS DECIMAL (10,2)) AS [Taxes], " _
                        & "CAST((((UnitPrice * Quantity) - 0) + Taxes) AS DECIMAL (10,2)) AS Total " _
                        & "FROM CreditNoteEntries WHERE NoteNumber = " & DocumentNumber & ""
                End If

            Case Is = "DEBIT NOTE"

            Case Is = "QUOTATION"
                strSqlMain = "SELECT ReferenceNumber, CustomerName, Address1, Address2, Address3, Address4, " _
                    & "ContactNumber, TaxNumber, SalesAgent, CONVERT(NVARCHAR, TransDate, 105), Terms FROM QuoteMain " _
                    & "WHERE ReferenceNumber = " & DocumentNumber & ""
                If UCase(strTaxComputationType) = "INCLUSIVE" Then
                    strSqlTransactions = "SELECT Quantity, Description, CAST(UnitPrice - (Tax/Quantity) AS " _
                        & "DECIMAL (10,2)) AS [Unit Price], CAST(((UnitPrice - (Tax/Quantity)) * Quantity) AS " _
                        & "DECIMAL (10,2)) AS Gross, CAST(Discount AS DECIMAL (10,2)) AS [Discount], " _
                        & "CAST(Tax AS DECIMAL (10,2)) AS [Taxes], CAST(((((UnitPrice - (Tax/Quantity)) * Quantity) - " _
                        & "Discount) + Tax) AS DECIMAL (10,2)) AS Total FROM QuoteDetails " _
                        & "WHERE ReferenceNumber = " & DocumentNumber & ""
                Else
                    strSqlTransactions = "SELECT Quantity, Description, CAST(UnitPrice AS DECIMAL (10,2)) AS " _
                        & "[Unit Price], CAST((UnitPrice * Quantity) AS DECIMAL (10,2)) AS Gross, " _
                        & "CAST(Discount AS DECIMAL (10,2)) AS [Discount], CAST(Tax AS DECIMAL (10,2)) AS [Taxes], " _
                        & "CAST((((UnitPrice * Quantity) - Discount) + Tax) AS DECIMAL (10,2)) AS Total " _
                        & "FROM QuoteDetails WHERE ReferenceNumber = " & DocumentNumber & ""
                End If

            Case Is = "PROFORMA"
                strSqlMain = "SELECT ReferenceNumber, CustomerName, Address1, Address2, Address3, Address4, " _
                    & "ContactNumber, TaxNumber, SalesAgent, CONVERT(NVARCHAR, TransDate, 105), Terms FROM ProformaMain " _
                    & "WHERE ReferenceNumber = " & DocumentNumber & ""
                If UCase(strTaxComputationType) = "INCLUSIVE" Then
                    strSqlTransactions = "SELECT Quantity, Description, CAST(UnitPrice - (Tax/Quantity) AS " _
                        & "DECIMAL (10,2)) AS [Unit Price], CAST(((UnitPrice - (Tax/Quantity)) * Quantity) AS " _
                        & "DECIMAL (10,2)) AS Gross, CAST(Discount AS DECIMAL (10,2)) AS [Discount], " _
                        & "CAST(Tax AS DECIMAL (10,2)) AS [Taxes], CAST(((((UnitPrice - (Tax/Quantity)) * Quantity) - " _
                        & "Discount) + Tax) AS DECIMAL (10,2)) AS Total FROM ProformaDetails " _
                        & "WHERE ReferenceNumber = " & DocumentNumber & ""
                Else
                    strSqlTransactions = "SELECT Quantity, Description, CAST(UnitPrice AS DECIMAL (10,2)) AS " _
                        & "[Unit Price], CAST((UnitPrice * Quantity) AS DECIMAL (10,2)) AS Gross, " _
                        & "CAST(Discount AS DECIMAL (10,2)) AS [Discount], CAST(Tax AS DECIMAL (10,2)) AS [Taxes], " _
                        & "CAST((((UnitPrice * Quantity) - Discount) + Tax) AS DECIMAL (10,2)) AS Total " _
                        & "FROM ProformaDetails WHERE ReferenceNumber = " & DocumentNumber & ""
                End If
            Case Is = "DELIVERY NOTE"
                If strDeliveryNoteFrom = "INVOICES" Then
                    strSqlMain = "SELECT CustomerSalesMain.InvoiceNumber, Customers.AccountName, " _
                        & "Customers.Address1, Customers.Address2, Customers.Address3, Customers.Address4, " _
                        & "Customers.PhoneNumber, Customers.VatNumber, CustomerSalesMain.SalesRep, " _
                        & "CONVERT(NVARCHAR, CustomerSalesMain.TransDate, 105), CustomerSalesMain.Notes, Customers.BPNumber " _
                        & "FROM CustomerSalesMain LEFT OUTER JOIN Customers ON CustomerSalesMain.CustomerId = Customers.AccountNumber " _
                        & "WHERE CustomerSalesMain.InvoiceNumber = " & DocumentNumber & ""
                    strSqlTransactions = "SELECT CustomerSales.Quantity, CustomerSales.Description, " _
                        & "CustomerSales.BaseBarCode +''+ CustomerSales.SerialNumbers as [FullSerial], " _
                        & "CAST(CustomerSales.SalesPrice AS DECIMAL (10,2)) AS [Unit Price], " _
                        & "CAST((CustomerSales.SalesPrice * CustomerSales.Quantity) AS DECIMAL (10,2)) AS [Total] " _
                        & "FROM CustomerSales LEFT OUTER JOIN InventoryItems ON CustomerSales.ItemCode = InventoryItems.ItemCode " _
                        & "WHERE CustomerSales.InvoiceNumber = " & DocumentNumber & " " _
                        & "AND (CustomerSales.ItemCode <> '--- COMMENT ---' AND CustomerSales.ItemCode <> '--- SERVICE ---') " _
                        & "AND CustomerSales.Quantity > 0"
                Else
                    strSqlMain = "SELECT PassNumber, CustomerName, Address1, Address2, Address3, Address4, " _
                        & "ContactNumber, VatNumber, CollectingAgent, CONVERT(NVARCHAR, TransDate, 105), Comment " _
                        & "FROM GatePassesMain WHERE PassNumber = " & DocumentNumber & ""
                    strSqlTransactions = "SELECT GatePasses.Quantity, GatePasses.Description, " _
                        & "GatePasses.BarCodeNo +''+ GatePasses.SerialNumber as [FullSerial], " _
                        & "CAST(InventoryItems.SellingPrice AS DECIMAL (10,2)) AS [Unit Price], " _
                        & "CAST((InventoryItems.SellingPrice * GatePasses.Quantity) AS DECIMAL (10,2)) AS [Total] " _
                        & "FROM GatePasses LEFT OUTER JOIN InventoryItems ON GatePasses.ItemCode = InventoryItems.ItemCode " _
                        & "WHERE GatePasses.PassNumber = " & DocumentNumber & ""
                End If
            Case Is = "TAX INVOICE"

                If boolPrintingSavedTaxInvoice = False Then
                    boolAbort = False
                    Dim f As New frmTaxInvoiceCustomerDetails
                    f.ShowDialog()
                    If boolAbort = True Then Exit Sub

                    'Save the details for the printing to the table

                    sPrintDate = CStr(Format(Now, "dd-MM-yyyy"))
                    Dim objGetDate As New Data.OleDb.OleDbCommand("SELECT TransDate FROM SalesMain " _
                        & "WHERE InvoiceNumber = " & DocumentNumber & "", cnn)
                    Dim objReadDate As Data.OleDb.OleDbDataReader = objGetDate.ExecuteReader
                    If objReadDate.HasRows Then
                        objReadDate.Read()
                        If IsDate(objReadDate(0).ToString) Then
                            sPrintDate = Format(CDate(objReadDate(0).ToString), "dd-MMM-yyyy")
                        End If
                    End If
                    objReadDate.Close()

                    'Update the receipt status to fixed

                    Dim objCommandFixed As New Data.OleDb.OleDbCommand("UPDATE SalesMain SET TaxStatus = 'FIXED' " _
                        & "WHERE InvoiceNumber = " & DocumentNumber & "", cnn)
                    objCommandFixed.ExecuteNonQuery()

                    objCommandFixed = New Data.OleDb.OleDbCommand("UPDATE Sales SET TaxStatus = 'FIXED' " _
                        & "WHERE InvoiceNumber = " & DocumentNumber & "", cnn)
                    objCommandFixed.ExecuteNonQuery()

                    Dim objCommandInsert As New Data.OleDb.OleDbCommand("INSERT INTO CashTaxInvoices " _
                        & "(CustomerName, Address1, Address2, Address3, Address4, Telephone, VatNumber, EmailAddress, DocumentNumber) VALUES " _
                        & "('" & sDocumentCustomerName & "', '" & sDocumentCustomerAddress1 & "', '" & sDocumentCustomerAddress2 & "', " _
                        & "'" & sDocumentCustomerAddress3 & "', '" & sDocumentCustomerAddress4 & "', '" & sDocumentCustomerTelephone & "', " _
                        & "'" & sDocumentCustomerVatNumber & "', '" & sDocumentCustomerEmailAddress & "', " & DocumentNumber & ")", cnn)
                    objCommandInsert.ExecuteNonQuery()

                Else
                    'Get the document details
                    Dim objCommSaved As New Data.OleDb.OleDbCommand("SELECT CustomerName, Address1, Address2, Address3, Address4, " _
                        & "Telephone, VatNumber, EmailAddress, DocumentNumber FROM CashTaxInvoices WHERE DocumentNumber = " & DocumentNumber & "", cnn)
                    Dim objReadSaved As Data.OleDb.OleDbDataReader = objCommSaved.ExecuteReader
                    If objReadSaved.HasRows Then
                        objReadSaved.Read()
                        If Not IsDBNull(objReadSaved(0).ToString) Then sDocumentCustomerName = objReadSaved(0).ToString
                        If Not IsDBNull(objReadSaved(1).ToString) Then sDocumentCustomerAddress1 = objReadSaved(1).ToString
                        If Not IsDBNull(objReadSaved(2).ToString) Then sDocumentCustomerAddress2 = objReadSaved(2).ToString
                        If Not IsDBNull(objReadSaved(3).ToString) Then sDocumentCustomerAddress3 = objReadSaved(3).ToString
                        If Not IsDBNull(objReadSaved(4).ToString) Then sDocumentCustomerAddress4 = objReadSaved(4).ToString
                        If Not IsDBNull(objReadSaved(5).ToString) Then sDocumentCustomerTelephone = objReadSaved(5).ToString
                        If Not IsDBNull(objReadSaved(6).ToString) Then sDocumentCustomerVatNumber = objReadSaved(6).ToString
                        If Not IsDBNull(objReadSaved(7).ToString) Then sDocumentCustomerEmailAddress = objReadSaved(7).ToString
                    End If
                    objReadSaved.Close()
                End If


                If UCase(strTaxComputationType) = "INCLUSIVE" Then
                    strSqlTransactions = "SELECT Quantity, Description, CAST(SalesPrice - (Taxes/Quantity) AS " _
                        & "DECIMAL (10,2)) AS [Unit Price], CAST(((SalesPrice - (Taxes/Quantity)) * Quantity) AS " _
                        & "DECIMAL (10,2)) AS Gross, CAST(DiscountAllowed AS DECIMAL (10,2)) AS [Discount], " _
                        & "CAST(Taxes AS DECIMAL (10,2)) AS [Taxes], CAST(((((SalesPrice - (Taxes/Quantity)) * Quantity) - " _
                        & "DiscountAllowed) + Taxes) AS DECIMAL (10,2)) AS Total FROM Sales " _
                        & "WHERE InvoiceNumber = " & DocumentNumber & ""
                Else
                    strSqlTransactions = "SELECT Quantity, Description, CAST(SalesPrice AS DECIMAL (10,2)) AS " _
                        & "[Unit Price], CAST((SalesPrice * Quantity) AS DECIMAL (10,2)) AS Gross, " _
                        & "CAST(DiscountAllowed AS DECIMAL (10,2)) AS [Discount], CAST(Taxes AS DECIMAL (10,2)) AS [Taxes], " _
                        & "CAST((((SalesPrice * Quantity) - DiscountAllowed) + Taxes) AS DECIMAL (10,2)) AS Total " _
                        & "FROM Sales WHERE InvoiceNumber = " & DocumentNumber & ""
                End If


            Case Is = "GOODS RECEIVED NOTE"
                'The main sql statement gets the date only
                strSqlMain = "SELECT DISTINCT(CONVERT(NVARCHAR, OrdersReceipt.TransDate, 105)) FROM OrdersReceipt " _
                    & "WHERE BatchNo = " & DocumentNumber & ""
                strSqlTransactions = "SELECT OrdersReceipt.ItemCode, InventoryItems.GroupName, " _
                    & "OrdersReceipt.BaseBarcode +''+ OrdersReceipt.SerialNumbers AS [Serial No], " _
                    & "CAST(OrdersReceipt.CostPrice AS DECIMAL (10,2)) AS [Cost Price], " _
                    & "CAST(OrdersReceipt.Quantity AS DECIMAL (10,2)) AS [Qty], " _
                    & "CAST((OrdersReceipt.CostPrice * OrdersReceipt.Quantity) AS DECIMAL (10,2)) AS [Gross], " _
                    & "DestinationBranch FROM OrdersReceipt LEFT OUTER JOIN InventoryItems ON " _
                    & "OrdersReceipt.ItemCode = InventoryItems.ItemCode WHERE OrdersReceipt.BatchNo = " & DocumentNumber & ""
        End Select

        'Get the customer details
        If UCase(DocumentType) = "TAX INVOICE" Then
            sCustomerName = sDocumentCustomerName
            sCustomerAddress1 = sDocumentCustomerAddress1
            sCustomerAddress2 = sDocumentCustomerAddress2
            sCustomerAddress3 = sDocumentCustomerAddress3
            sCustomerAddress4 = sDocumentCustomerAddress4
            sCustomerTelephone = sDocumentCustomerTelephone
            sCustomerVatNumber = sDocumentCustomerVatNumber
            sAgent = strUserName
            'objCommand = New Data.OleDb.OleDbCommand(strSqlMain, cnn)
            'objReader = objCommand.ExecuteReader
            'If objReader.HasRows Then
            '    objReader.Read()
            '    If Not IsDBNull(objReader("BpNumber").ToString) Then sCustomerBpNumber = objReader("BpNumber").ToString
            'End If
            'objReader.Close()
        Else
            If UCase(DocumentType) <> "GOODS RECEIVED NOTE" Then
                objCommand = New Data.OleDb.OleDbCommand(strSqlMain, cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(1).ToString) Then sCustomerName = objReader(1).ToString
                    If Not IsDBNull(objReader(2).ToString) Then sCustomerAddress1 = objReader(2).ToString
                    If Not IsDBNull(objReader(3).ToString) Then sCustomerAddress2 = objReader(3).ToString
                    If Not IsDBNull(objReader(4).ToString) Then sCustomerAddress3 = objReader(4).ToString
                    If Not IsDBNull(objReader(5).ToString) Then sCustomerAddress4 = objReader(5).ToString
                    If Not IsDBNull(objReader(6).ToString) Then sCustomerTelephone = objReader(6).ToString

                    If UCase(DocumentType) <> "LEGAL STATEMENT" Then
                        If UCase(DocumentType) <> "AUCTION STATEMENT" Then
                            If Not IsDBNull(objReader(7).ToString) Then sCustomerVatNumber = objReader(7).ToString
                        End If
                    End If

                    If UCase(DocumentType) = "SETTLEMENT" Or UCase(DocumentType) = "STATEMENT OF UNPAIDS" Then
                        sPrintDate = UCase(Format(SettlementDate, "dd-MMM-yyyy"))
                        sAgent = UCase(strCurrentUserFullNames)
                        sCustomerName = sCustomerName & " ACC.# " & UCase(strSelectedAccount)
                    End If

                    If UCase(DocumentType) <> "SETTLEMENT" Then
                        If UCase(DocumentType) <> "STATEMENT" Then
                            If UCase(DocumentType) <> "STUDENT STATEMENT" Then
                                If UCase(DocumentType) <> "LEGAL STATEMENT" Then
                                    If UCase(DocumentType) <> "STATEMENT OF UNPAIDS" Then
                                        If UCase(DocumentType) <> "AUCTION STATEMENT" Then
                                            If Not IsDBNull(objReader(8).ToString) Then sAgent = objReader(8).ToString
                                            If Not IsDBNull(objReader(9).ToString) Then sPrintDate = objReader(9).ToString
                                            If Not IsDBNull(objReader(10).ToString) Then sComment = objReader(10).ToString
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If UCase(DocumentType) <> "QUOTATION" Then
                        If UCase(DocumentType) <> "SETTLEMENT" Then
                            If UCase(DocumentType) <> "STATEMENT" Then
                                If UCase(DocumentType) <> "STUDENT STATEMENT" Then
                                    If UCase(DocumentType) <> "LEGAL STATEMENT" Then
                                        If UCase(DocumentType) <> "STATEMENT OF UNPAIDS" Then
                                            If UCase(DocumentType) <> "AUCTION STATEMENT" Then
                                                If Not IsDBNull(objReader(11).ToString) Then sCustomerBpNumber = objReader(11).ToString
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                End If
                objReader.Close()
            Else
                objCommand = New Data.OleDb.OleDbCommand(strSqlMain, cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then sPrintDate = objReader(0).ToString
                End If
                objReader.Close()
            End If
        End If

        'Declare and initialize the print details
        Dim arrPrintDetails As New ArrayList
        Dim intFields As Integer
        Dim dblUnitTotals As Double = 0
        Dim dblDiscounts As Double = 0
        Dim dblSubTotal As Double = 0
        Dim dblTotalTaxes As Double = 0
        Dim dblGrossTotal As Double = 0
        Dim dblQuantityTotal As Double = 0

        'Get the transactions()
        If UCase(DocumentType) <> "SETTLEMENT" Then
            If UCase(DocumentType) <> "STATEMENT" Then
                If UCase(DocumentType) <> "STUDENT STATEMENT" Then
                    If UCase(DocumentType) <> "LEGAL STATEMENT" Then
                        If UCase(DocumentType) <> "STATEMENT OF UNPAIDS" Then
                            If UCase(DocumentType) <> "AUCTION STATEMENT" Then
                                objCommand = New Data.OleDb.OleDbCommand(strSqlTransactions, cnn)
                                objReader = objCommand.ExecuteReader

                                intFields = objReader.FieldCount


                                While objReader.Read

                                    Dim strItems As String = Nothing

                                    For i As Integer = 0 To objReader.FieldCount - 1
                                        strItems = strItems & objReader(i) & "|"
                                        If UCase(DocumentType) <> "DELIVERY NOTE" Then
                                            If UCase(DocumentType) <> "GOODS RECEIVED NOTE" Then
                                                Select Case i
                                                    Case Is = 3
                                                        dblUnitTotals = dblUnitTotals + CDbl(objReader(i).ToString)
                                                    Case Is = 4
                                                        dblDiscounts = dblDiscounts + CDbl(objReader(i).ToString)
                                                    Case Is = 5
                                                        dblTotalTaxes = dblTotalTaxes + CDbl(objReader(i).ToString)
                                                    Case Is = 6
                                                        dblGrossTotal = dblGrossTotal + CDbl(objReader(i).ToString)
                                                End Select
                                            Else
                                                Select Case i
                                                    Case Is = 4
                                                        dblQuantityTotal = dblQuantityTotal + CDbl(objReader(i).ToString)
                                                    Case Is = 5
                                                        dblGrossTotal = dblGrossTotal + CDbl(objReader(i).ToString)
                                                End Select
                                            End If
                                        Else
                                            'Its a delivery note
                                            Select Case i
                                                Case Is = 0
                                                    dblQuantityTotal = dblQuantityTotal + CDbl(objReader(i).ToString)
                                                Case Is = 4
                                                    dblGrossTotal = dblGrossTotal + CDbl(objReader(i).ToString)
                                            End Select
                                        End If
                                    Next
                                    strItems = Mid(strItems, 1, (strItems.Length - 1))
                                    arrPrintDetails.Add(strItems)
                                End While
                                objReader.Close()

                                dblSubTotal = dblSubTotal + (dblUnitTotals - dblDiscounts)
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If UCase(DocumentType) = "SETTLEMENT" Then
            arrPrintDetails = arrSettledInvoices
            intFields = 7
        End If

        Dim dblTotalActionsAndFees As Double = 0
        Dim dblAuctionDeposits As Double = 0
        Dim dblAuctionSubTotal As Double = 0
        Dim dblAuctionCardFees As Double = 0
        Dim dblAuctionPayableAmt As Double = 0

        If UCase(DocumentType) = "AUCTION STATEMENT" Then
            arrAuctionDetails = New ArrayList
            objCommand = New Data.OleDb.OleDbCommand(strSqlTransactions, cnn)
            objReader = objCommand.ExecuteReader
            While objReader.Read
                arrAuctionDetails.Add(objReader(0).ToString)
            End While
            objReader.Close()

            'If arrAuctionDetails.Count <= 0 Then
            '    MessageBox.Show("There are no transactions to print for this bidder", "Empty Transactions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If
            arrPrintDetails = arrAuctionDetails
            intFields = 7

            'Get the final totals
            objCommand = New Data.OleDb.OleDbCommand("SELECT SUM((MocAttachmentDetails.BidAmount * 0.15) + MocAttachmentDetails.BidAmount) AS Gross " _
                & "FROM MocAttachmentDetails WHERE BidderId = " & DocumentNumber & " AND AuctionDate = '" & strSelectedDate & "'", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader(0).ToString) Then
                    dblTotalActionsAndFees = CDbl(objReader(0).ToString)
                End If
            End If
            objReader.Close()

            'Get the deposit and card fees
            objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Bidders.DepositAmount), SUM(Bidders.CardAmount) FROM Bidders " _
                & "WHERE Bidders.CardNo = " & DocumentNumber & " AND Bidders.AuctionDate = '" & strSelectedDate & "'", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader(0).ToString) Then
                    dblAuctionDeposits = CDbl(objReader(0).ToString)
                End If
                If IsNumeric(objReader(1).ToString) Then
                    dblAuctionCardFees = CDbl(objReader(1).ToString)
                End If
            End If
            objReader.Close()

            dblAuctionSubTotal = dblTotalActionsAndFees - dblAuctionDeposits
            dblAuctionPayableAmt = dblAuctionSubTotal + dblAuctionCardFees

            sPrintDate = strSelectedDate

        End If

        If UCase(DocumentType) = "STATEMENT" Or UCase(DocumentType) = "LEGAL STATEMENT" Or _
            UCase(DocumentType) = "STATEMENT OF UNPAIDS" Or UCase(DocumentType) = "STUDENT STATEMENT" Then
            arrPrintDetails = arrStatementDetails
            intFields = 7
        End If

        'Send the details to the document printing class
        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        Dim docPrint As New DocumentWriter

        With docPrint
            .intNumberOfColumns = intFields
            .intPrintRecordsCount = strPrintDetails.Length
            Select Case UCase(DocumentType)
                Case Is = "INVOICE"
                    .strMainCaption = UCase(strInvoiceHeader)
                    .PrintBankingDetails = True
                Case Is = "AUTION STATEMENT"
                    .strMainCaption = UCase(DocumentType)
                    .PrintBankingDetails = False
                Case Is = "QUOTATION"
                    .strMainCaption = UCase(strQuotationHeader)
                    .PrintBankingDetails = True
                Case Is = "PROFORMA"
                    .strMainCaption = UCase(strProformaHeader)
                    .PrintBankingDetails = True
                Case Is = "TAX INVOICE"
                    .strMainCaption = "TAX INVOICE"
                    .PrintBankingDetails = True
                Case Is = "DELIVERY NOTE"
                    If strDeliveryNoteFrom = "INVOICES" Then
                        .strMainCaption = UCase("DELIVERY NOTE")
                    Else
                        .strMainCaption = UCase(strGatePassHeader)
                    End If
                    .PrintBankingDetails = False
                Case Is = "CREDIT NOTE"
                    .strMainCaption = UCase(strCreditNoteHeader)
                    .PrintBankingDetails = False
                Case Is = "DEBIT NOTE"
                    .PrintBankingDetails = False
                Case Is = "GOODS RECEIVED NOTE"
                    .strMainCaption = UCase(DocumentType)
                    .PrintBankingDetails = False
                Case Is = "SETTLEMENT"
                    .strMainCaption = UCase("ACCOUNT SETTLEMENT RECEIPT")
                    .PrintBankingDetails = False
                Case Is = "STATEMENT"
                    .strMainCaption = "CUSTOMER STATEMENT"
                    .PrintBankingDetails = True
                Case Is = "STUDENT STATEMENT"
                    .strMainCaption = "STUDENT STATEMENT"
                    .PrintBankingDetails = True
                Case Is = "STATEMENT OF UNPAIDS"
                    .strMainCaption = "CUSTOMER STATEMENT"
                    .PrintBankingDetails = True
                Case Is = "LEGAL STATEMENT"
                    .strMainCaption = "CUSTOMER STATEMENT"
                    .PrintBankingDetails = True
                Case Is = "AUCTION STATEMENT"
                    .strMainCaption = "AUCTION STATEMENT"
                    .PrintBankingDetails = True
                Case Else
                    .strMainCaption = Nothing
                    .PrintBankingDetails = False
            End Select
            .CustomerName = sCustomerName
            .CustomerAddress1 = sCustomerAddress1
            .CustomerAddress2 = sCustomerAddress2
            .CustomerAddress3 = sCustomerAddress3
            .CustomerAddress4 = sCustomerAddress4
            .CustomerTelephone = sCustomerTelephone
            .CustomerEmailAddress = Nothing
            .CustomerVatNumber = sCustomerVatNumber
            .CustomerBPNumber = sCustomerBpNumber
            .TaxesCharged = 0
            .DocumentTotal = 0
            .DiscountAllowed = 0
            If UCase(DocumentType) = "DELIVERY NOTE" Then
                .strColumnAlignments = "0|0|0|2|2"
            Else
                If UCase(DocumentType) = "GOODS RECEIVED NOTE" Then
                    .strColumnAlignments = "0|0|0|2|2|2|0"
                Else
                    If UCase(DocumentType) = "SETTLEMENT" Then
                        'Details, inv#=1, val=2, received to date=3, crd note=4, paid now=6, balance
                        .strColumnAlignments = "0|0|2|2|2|2|2"
                    Else
                        If UCase(DocumentType) = "STATEMENT" Or UCase(DocumentType) = "LEGAL STATEMENT" Or UCase(DocumentType) = "STUDENT STATEMENT" Then
                            .strColumnAlignments = "0|0|0|0|2|2|2"
                        Else
                            If UCase(DocumentType) = "STATEMENT OF UNPAIDS" Then
                                .strColumnAlignments = "0|0|0|2|2|2|2"
                            Else
                                If UCase(DocumentType) = "AUCTION STATEMENT" Then
                                    .strColumnAlignments = "0|0|0|0|2|2|2"
                                Else
                                    .strColumnAlignments = "2|0|2|2|2|2|2"
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            .PrintDate = sPrintDate
            .ReferenceNumber = DocumentNumber
            .SalesRep = sAgent
            .strPrintValues = strPrintDetails
            If UCase(DocumentType) = "DELIVERY NOTE" Then
                .strColumnHeaders = "QTY|DESCRIPTION|SERIAL NO.|UNIT COST|TOTAL COST"
            Else
                If UCase(DocumentType) = "GOODS RECEIVED NOTE" Then
                    .strColumnHeaders = "ITEM CODE|DESCRIPTION|SERIAL|UNIT $|QTY|GROSS|BRANCH"
                Else
                    If UCase(DocumentType) = "SETTLEMENT" Then
                        .strColumnHeaders = "DETAILS|INV. NO.|VALUE|PAID PRIOR|CR. NOTES|CURRENT|BALANCE"
                    Else
                        If UCase(DocumentType) = "STATEMENT" Or UCase(DocumentType) = "LEGAL STATEMENT" Or UCase(DocumentType) = "STUDENT STATEMENT" Then
                            .strColumnHeaders = "DATE|DESCRIPTION|REF.#|PROJ.#|DEBIT|CREDIT|BALANCE"
                        Else
                            If UCase(DocumentType) = "STATEMENT OF UNPAIDS" Then
                                .strColumnHeaders = "DATE|DESCRIPTION|REF.#|DEBIT|CREDIT|C.NOTE|BALANCE"
                            Else
                                If UCase(DocumentType) = "AUCTION STATEMENT" Then
                                    .strColumnHeaders = "DESCRIPTION|MODEL|COLOR|IDENTITY|COST|FEES|PAYABLE"
                                Else
                                    .strColumnHeaders = "QTY|DESCRIPTION|UNIT COST|GROSS|DISCOUNT|TAX|PAYABLE"
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            .boolGenericReport = True
            '.PrintBankingDetails = False
            .PrintSummaryTotals = True
            .DetailColor = Color.FromName("Black")
            .GridColor = Color.LightGray
            If UCase(DocumentType) = "DELIVERY NOTE" Then
                .strColumnWidths = "60|250|120|100|100"
                .strColumnFormating = "NO|NO|NO|NO|NO"
            Else
                If UCase(DocumentType) = "GOODS RECEIVED NOTE" Then
                    .strColumnWidths = "130|170|100|70|40|60|140"
                    .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                Else
                    If UCase(DocumentType) = "SETTLEMENT" Then
                        .strColumnWidths = "150|80|80|80|80|80|85"
                        .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                    Else
                        If UCase(DocumentType) = "STATEMENT" Or UCase(DocumentType) = "LEGAL STATEMENT" Or _
                            UCase(DocumentType) = "STUDENT STATEMENT" Then
                            .strColumnWidths = "80|190|60|78|78|78|85"
                            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                        Else
                            If UCase(DocumentType) = "STATEMENT OF UNPAIDS" Then
                                .strColumnWidths = "80|190|78|78|78|78|78"
                                .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                            Else
                                If UCase(DocumentType) = "AUCTION STATEMENT" Then
                                    .strColumnWidths = "180|80|80|80|80|70|90"
                                    .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                                Else
                                    .strColumnWidths = "50|200|78|80|78|78|85"
                                    .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            'Remember to carter for the notes printing
            If UCase(DocumentType) <> "DELIVERY NOTE" Then
                'If there are summary totals activate this code
                If UCase(DocumentType) = "GOODS RECEIVED NOTE" Then
                    .strSummaryCaptions = "QTY TOTAL|GROSS TOTAL"
                    .strSummaryValues = Format(dblQuantityTotal, "#0.00") & "|" & Format(dblGrossTotal, "#0.00")
                    .strSummaryAlignments = "2|2"
                Else
                    If UCase(DocumentType) = "SETTLEMENT" Then
                        .strSummaryCaptions = "INVOICE TOTALS|LESS PAID PRIOR|LESS CR. NOTES|RECEIVED NOW|CURR.BAL."
                        .strSummaryValues = Format(dblSettlementInvoiceTotals, "#0.00") & "|" & Format(dblSettlementReceivedToDate, "#0.00") _
                            & "|" & Format(dblSettlementCreditNotesValue, "#0.00") & "|" & Format(dblSettlementReceivedCurrently, "#0.00") _
                            & "|" & Format(dblSettlementCurrentBalance, "#0.00")
                        .strSummaryAlignments = "2|2|2|2|2"
                    Else
                        If UCase(DocumentType) = "STATEMENT" Or UCase(DocumentType) = "LEGAL STATEMENT" Or UCase(DocumentType) = "STUDENT STATEMENT" Then
                            .strSummaryCaptions = "0 TO 30 DYS|30 TO 60 DYS|60 TO 90 DYS|OVER 90 DYS|TOTAL DUE"
                            .strSummaryValues = Format(dblCurrentStatementBalance, "#0.00") & "|" & Format(dblBetween30and60, "#0.00") _
                                & "|" & Format(dblBetween60and90, "#0.00") & "|" & Format(dblOver90, "#0.00") _
                                & "|" & Format(dblCurrentStatementBalance, "#0.00")
                            .strSummaryAlignments = "2|2|2|2|2"
                        Else
                            If UCase(DocumentType) = "STATEMENT OF UNPAIDS" Then
                                .strSummaryCaptions = "INVOICE TOTAL|LESS RECEIPTS|SUB TOTAL|LESS C.NOTES|NET PAYABLE"
                                .strSummaryValues = Format(dblPublicInvoiceTotals, "#,##0.00") & "|" & Format(dblPublicReceiptsTotals, "#,##0.00") _
                                    & "|" & Format(dblPublicSubUnpaidTotals, "#,##0.00") & "|" & Format(dblPublicCreditNotesTotals, "#,##0.00") _
                                    & "|" & Format(dblUnpaidsBalanceTotal, "#,##0.00")
                                .strSummaryAlignments = "2|2|2|2|2"
                            Else
                                If UCase(DocumentType) = "AUCTION STATEMENT" Then
                                    .strSummaryCaptions = "GROSS TOTAL|LESS DEPOSIT|SUB TOTAL|CARD FEES|NET PAYABLE"
                                    .strSummaryValues = Format(dblTotalActionsAndFees, "#0.00") & "|" & Format(dblAuctionDeposits, "#0.00") _
                                        & "|" & Format(dblAuctionSubTotal, "#0.00") & "|" & Format(dblAuctionCardFees, "#0.00") _
                                        & "|" & Format(dblAuctionPayableAmt, "#0.00")
                                    .strSummaryAlignments = "2|2|2|2|2"
                                Else
                                    .strSummaryCaptions = "UNITS TOTAL|LESS DISCOUNT|SUB TOTAL|TAX/VAT|NET PAYABLE"
                                    .strSummaryValues = Format(dblUnitTotals, "#0.00") & "|" & Format(dblDiscounts, "#0.00") _
                                        & "|" & Format(dblSubTotal, "#0.00") & "|" & Format(dblTotalTaxes, "#0.00") _
                                        & "|" & Format(dblGrossTotal, "#0.00")
                                    .strSummaryAlignments = "2|2|2|2|2"
                                End If
                            End If
                        End If
                    End If
                End If
            Else
                .strSummaryCaptions = "QTY TOTAL|GROSS TOTAL"
                .strSummaryValues = Format(dblQuantityTotal, "#0.00") & "|" & Format(dblGrossTotal, "#0.00")
                .strSummaryAlignments = "2|2"
            End If
            .DocumentNotes = sComment
        End With


        If strRequestForReceiptPrinter = "YES" Then
            If boolPrinterAlreadySelected = False Then
                boolAbort = False
                Dim f As New frmPrinterSetup
                f.ShowDialog()
                If boolAbort = True Then Exit Sub
                docPrint.PrinterSettings.PrinterName = strSessionPrinter
                boolPrinterAlreadySelected = True
            End If
        End If

        Dim ppd As New PrintPreviewDialog

        If boolDirectPrinting = True Then
            docPrint.Print()
        Else
            ppd.Document = docPrint
            ppd.ShowDialog()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Document Generation"
        ShowErrorMessage()
    End Sub

End Module
