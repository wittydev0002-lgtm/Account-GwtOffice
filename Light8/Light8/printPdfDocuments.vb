Imports System.IO
Imports System.Security.AccessControl
Imports System.Text
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports DevComponents.AdvTree
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.draw

Module printPdfDocuments

    Dim pnlPrintControl As Panel
    Dim doc As Document

    Public Sub AddFileSecurity(ByVal fileName As String, ByVal account As String, ByVal rights As FileSystemRights, ByVal controlType As AccessControlType)
        Dim fSecurity As FileSecurity = File.GetAccessControl(fileName)
        fSecurity.AddAccessRule(New FileSystemAccessRule(account, rights, controlType))
        File.SetAccessControl(fileName, fSecurity)
    End Sub

    Private Function AppendComma(ByVal value As String) As String
        Return String.Format("{0:#,0.00}", Convert.ToDecimal(value))
    End Function

    Public Sub PrintCustomerPdfDocument(ByVal DocumentNumber As Long,
                                        ByVal DocumentType As String,
                                        Optional ByVal Total1 As Double = 0,
                                        Optional ByVal Total2 As Double = 0,
                                        Optional ByVal Total3 As Double = 0,
                                        Optional ByVal Total4 As Double = 0,
                                        Optional ByVal Total5 As Double = 0)


        Dim strFileName As String = Nothing
        Dim sfd As New System.Windows.Forms.SaveFileDialog
        sfd.ShowDialog()
        strFileName = sfd.FileName

        If String.IsNullOrEmpty(Trim(strFileName)) Then
            System.Windows.Forms.MessageBox.Show("Please enter a valid filename!",
                "Missing Filename", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            boolAbort = True
            Exit Sub
        End If


        On Error GoTo RaiseErr

        Dim customerPassword As String = Nothing

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
                        & "Customers.VatNumber, CustomerSalesMain.SalesRep, CONVERT(NVARCHAR, CustomerSalesMain.TransDate, 105), 
                        Notes, Customers.BPNumber, CustomerSalesMain.CurrencyUsed AS [CurrencyUsed], [CustomerSalesMain].[OrderNumber] " _
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

            Case = "FEES"
                strSqlMain = "SELECT SC_Guardians.Telephone, SC_Guardians.GivenNames, SC_Guardians.Address1, " _
                        & "SC_Guardians.Address2, SC_Guardians.Address3, SC_Guardians.Address4, SC_Guardians.Cellphone, " _
                        & "SC_Guardians.Email, SC_StudentTransactions.StudentId FROM SC_Guardians " _
                        & "LEFT JOIN SC_StudentTransactions ON SC_Guardians.StudentId = SC_StudentTransactions.StudentId " _
                        & "WHERE SC_StudentTransactions.ReceiptNo = " & DocumentNumber & ""

                strSqlTransactions = "SELECT SC_StudentTransactions.Description +'|'+ SC_StudentTransactions.Reference +'||||'+ " _
                        & "CONVERT(NVARCHAR, CAST(SC_StudentTransactions.Credit AS DECIMAL (10,2))) +'|'  FROM SC_StudentTransactions " _
                        & "WHERE SC_StudentTransactions.ReceiptNo = " & DocumentNumber & ""

                Dim sqlDate As String = "SELECT DISTINCT(TransactionDate), StudentId FROM SC_StudentTransactions WHERE ReceiptNo = " & DocumentNumber & ""
                objCommand = New Data.OleDb.OleDbCommand(sqlDate, cnn)
                Dim objReadDte As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                Dim intStudentId As Long = 0
                If objReadDte.HasRows Then
                    objReadDte.Read()
                    If IsDate(objReadDte(0).ToString) Then
                        SettlementDate = CDate(shortMonthDateFormat(CDate(objReadDte(0).ToString)))
                    End If
                    If IsNumeric(objReadDte(1).ToString) Then
                        intStudentId = CLng(objReadDte(1).ToString)
                    End If
                Else
                    SettlementDate = CDate(shortMonthDateFormat(Now))
                End If
                objReadDte.Close()

                'Get the student details

                sqlDate = "SELECT LastName +' '+ FirstName +' '+ OtherNames +' CLASS : '+ Classname FROM SC_Students WHERE StudentId = " & intStudentId & ""
                objCommand = New Data.OleDb.OleDbCommand(sqlDate, cnn)
                objReadDte = objCommand.ExecuteReader
                If objReadDte.HasRows Then
                    objReadDte.Read()
                    If Not IsDBNull(objReadDte(0).ToString) Then
                        StudentDetails = objReadDte(0).ToString
                    End If
                End If
                objReadDte.Close()


            Case Is = "STATEMENT"
                strSqlMain = "SELECT Customers.AccountNumber, Customers.AccountName, Customers.Address1, " _
                    & "Customers.Address2, Customers.Address3, Customers.Address4, Customers.PhoneNumber +' '+ Customers.Cellphone, " _
                    & "Customers.VatNumber, Customers.BPNumber FROM Customers WHERE Customers.AccountNumber = '" & strSelectedAccount & "'"

            Case Is = "MEMBER STATEMENT"

                strSqlMain = "SELECT BM_Master.PolicyNumber, BM_Master.LastName +' '+ BM_Master.FirstName +' '+ BM_Master.OtherNames AS [AccountName], " _
                        & "BM_Master.Address1, " _
                        & "BM_Master.Address2, BM_Master.Address3, BM_Master.Address4, BM_Master.Telephone +' '+ BM_Master.Cellphone, " _
                        & "BM_Master.AlternateNumber, CONVERT(NVARCHAR, BM_Master.StandSize), CAST(Capital AS DECIMAL(10,2)) AS [PropValue] " _
                        & "FROM BM_Master WHERE BM_Master.PolicyNumber = '" & strSelectedAccount & "'"

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

                    'Save the details for the printing to the table

                    sPrintDate = CStr(Format(Now, "dd-MM-yyyy"))
                    Dim objGetDate As New Data.OleDb.OleDbCommand("SELECT TransDate FROM SalesMain " _
                        & "WHERE InvoiceNumber = " & DocumentNumber & "", cnn)
                    Dim objReadDate As Data.OleDb.OleDbDataReader = objGetDate.ExecuteReader
                    If objReadDate.HasRows Then
                        objReadDate.Read()
                        If IsDate(objReadDate(0).ToString) Then
                            sPrintDate = shortMonthDateFormat(CDate(objReadDate(0).ToString))
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

        boolPrintSummaryOnNewPage = False

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

                If UCase(DocumentType) = "PLAINTIFF STATEMENT" Or UCase(DocumentType) = "DEFENDANT STATEMENT" Then
                    'Do nothing
                    sCustomerName = sPlantiffName
                    sCustomerAddress1 = strPlaintiffAddress1
                    sCustomerAddress2 = strPlaintiffAddress2
                    sCustomerAddress3 = strPlaintiffAddress3
                    sCustomerAddress4 = strPlaintiffAddress4
                    sCustomerTelephone = sPlaintiffTelephone
                Else

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

                        If UCase(DocumentType) = "INVOICE" Then
                            If Not IsDBNull(objReader("CurrencyUsed")) Then
                                strSalesCurrencyUsed = UCase(Trim(objReader("CurrencyUsed").ToString))
                            End If
                            If Not IsDBNull(objReader("OrderNumber")) Then
                                strPublicInvoiceOrderNumber = objReader("OrderNumber").ToString
                            End If
                            If Not IsDBNull(objReader(10).ToString) Then sComment = objReader(10).ToString
                        End If

                        If UCase(DocumentType) = "MEMBER STATEMENT" Then
                            If IsNumeric(objReader("PropValue").ToString) Then
                                dblSaleTotal = CDbl(objReader("PropValue").ToString)
                            End If
                        End If

                        If UCase(DocumentType) <> "LEGAL STATEMENT" Then
                            If UCase(DocumentType) <> "AUCTION STATEMENT" Then
                                If UCase(DocumentType) <> "FEES" Then
                                    If Not IsDBNull(objReader(7).ToString) Then sCustomerVatNumber = objReader(7).ToString
                                End If
                            End If
                        End If

                        If UCase(DocumentType) = "SETTLEMENT" Or UCase(DocumentType) = "STATEMENT OF UNPAIDS" Or UCase(DocumentType) = "FEES" Then
                            sPrintDate = UCase(shortMonthDateFormat(SettlementDate))
                            sAgent = UCase(strCurrentUserFullNames)
                            If UCase(DocumentType) <> "FEES" Then
                                sCustomerName = sCustomerName & " ACC.# " & UCase(strSelectedAccount)
                            End If
                        End If

                        If UCase(DocumentType) <> "SETTLEMENT" Then
                            If UCase(DocumentType) <> "FEES" Then
                                If UCase(DocumentType) <> "STATEMENT" Then
                                    If UCase(DocumentType) <> "MEMBER STATEMENT" Then
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
                            End If
                        End If

                        If UCase(DocumentType) <> "QUOTATION" Then
                            If UCase(DocumentType) <> "SETTLEMENT" Then
                                If UCase(DocumentType) <> "FEES" Then
                                    If UCase(DocumentType) <> "STATEMENT" Then
                                        If UCase(DocumentType) <> "MEMBER STATEMENT" Then
                                            If UCase(DocumentType) <> "STUDENT STATEMENT" Then
                                                If UCase(DocumentType) <> "LEGAL STATEMENT" Then
                                                    If UCase(DocumentType) <> "STATEMENT OF UNPAIDS" Then
                                                        If UCase(DocumentType) <> "AUCTION STATEMENT" Then
                                                            If UCase(DocumentType) <> "PROFORMA" Then
                                                                If UCase(DocumentType) <> "DELIVERY NOTE" Then
                                                                    If Not IsDBNull(objReader(11).ToString) Then sCustomerBpNumber = objReader(11).ToString
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    End If

                    objReader.Close()

                End If
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

        ' CREATE THE OUTPUT WORKING FOLDER IF IT DOES NOT EXIST
        '
        If System.IO.Directory.Exists(Application.StartupPath & "/payData") = False Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "/payData")
        End If

        ' Get the transactions()

        If UCase(DocumentType) <> "SETTLEMENT" Then
            If UCase(DocumentType) <> "FEES" Then
                If UCase(DocumentType) <> "STATEMENT" Then
                    If UCase(DocumentType) <> "MEMBER STATEMENT" Then
                        If UCase(DocumentType) <> "STUDENT STATEMENT" Then
                            If UCase(DocumentType) <> "LEGAL STATEMENT" Then
                                If UCase(DocumentType) <> "STATEMENT OF UNPAIDS" Then
                                    If UCase(DocumentType) <> "AUCTION STATEMENT" Then

                                        If UCase(DocumentType) <> "PLAINTIFF STATEMENT" Then

                                            If UCase(DocumentType) <> "DEFENDANT STATEMENT " Then

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

        If UCase(DocumentType) = "STATEMENT" Or UCase(DocumentType) = "LEGAL STATEMENT" Or
                    UCase(DocumentType) = "STATEMENT OF UNPAIDS" Or UCase(DocumentType) = "STUDENT STATEMENT" Or
                    UCase(DocumentType) = "MEMBER STATEMENT" Then
            arrPrintDetails = arrStatementDetails
            intFields = 7
        End If

        If UCase(DocumentType) = "PLAINTIFF STATEMENT" Or UCase(DocumentType) = "DEFENDANT STATEMENT" Then
            If IsAuctionStatementType = True Then
                arrPrintDetails = arrAuctioneerTransactions
                intFields = 6
            Else
                arrPrintDetails = arrCaseStatementTransactions
                intFields = 7
            End If
        End If

        If UCase(DocumentType) = "FEES" Then
            objCommand = New Data.OleDb.OleDbCommand(strSqlTransactions, cnn)
            objReader = objCommand.ExecuteReader
            While objReader.Read
                arrPrintDetails.Add(UCase(objReader(0).ToString))
            End While
            objReader.Close()
            intFields = 7
        End If


        ' Send the details to the document printing class
        '
        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            If Not String.IsNullOrEmpty(Trim(arrPrintDetails.Item(i))) Then
                Dim strFormattedLine As String = Nothing
                Dim strColumns() As String = Split(arrPrintDetails.Item(i), "|")
                For k As Integer = 0 To strColumns.Length - 1
                    If IsNumeric(strColumns(k)) Then
                        Dim strNumFormatted As String = Nothing
                        If UCase(DocumentType) = UCase("STATEMENT OF UNPAIDS") Or
                                UCase(DocumentType) = UCase("STATEMENT") Then
                            If k = 2 Then
                                strNumFormatted = strColumns(k)
                            Else
                                strNumFormatted = ThousandSeperatedNumber(CDbl(strColumns(k)))
                            End If
                        Else
                            strNumFormatted = ThousandSeperatedNumber(CDbl(strColumns(k)))
                        End If
                        strFormattedLine = strFormattedLine & strNumFormatted & "|"
                    Else
                        strFormattedLine = strFormattedLine & strColumns(k) & "|"
                    End If
                Next
                If Not String.IsNullOrEmpty(Trim(strFormattedLine)) Then
                    strFormattedLine = Trim(Mid(strFormattedLine, 1, strFormattedLine.Length - 1))
                End If
                strPrintDetails(i) = strFormattedLine
            Else
                strPrintDetails(i) = arrPrintDetails.Item(i)
            End If
        Next

        ' *****************************************************************
        ' PRINTING BEGINS HERE !!
        ' *****************************************************************

        ' GET THE BANKING DETAILS PRINT FLAG
        '

        PrintBankingInformation = False

        Dim objBankData As New Data.OleDb.OleDbCommand("SELECT PrintBankDetails FROM [Company]", cnn)
        Dim objReadData As Data.OleDb.OleDbDataReader = objBankData.ExecuteReader
        If objReadData.HasRows Then
            objReadData.Read()
            If Not IsDBNull(objReadData(0)) Then
                If Not String.IsNullOrEmpty(Trim(objReadData(0).ToString)) Then
                    If UCase(Trim(objReadData(0).ToString)) = UCase("Y") Then
                        PrintBankingInformation = True
                    End If
                End If
            End If
        End If
        objReadData.Close()

        Dim us As New System.Globalization.CultureInfo("en-US")
        Dim fileName As String = Nothing
        Dim downloadFile As String = Nothing

        pnlPrintControl = New Panel()
        doc = New Document(PageSize.A4, 36.0F, 36.0F, 36.0F, 36.0F)

        ' IMAGE, EMPLOYEE DETAILS
        '
        Dim strDateTime As String = Now.ToString("yyyy-MM-dd HH:mm:ss")
        strDateTime = Replace(strDateTime, "-", "", 1)
        strDateTime = Replace(strDateTime, " ", "", 1)
        strDateTime = Replace(strDateTime, ":", "", 1)

        'Dim invoiceName As String = Trim(sCustomerName)
        'invoiceName = UCase(Replace(invoiceName, " ", "_"))
        'invoiceName = UCase(Replace(invoiceName, "/", ""))
        'invoiceName = UCase(Replace(invoiceName, "\", ""))

        'fileName = invoiceName & "_" & UCase(Trim(DocumentType)) &
        '        "_" & CStr(DocumentNumber
        '        

        strFileName = Replace(strFileName, ".pdf", "")
        fileName = strFileName & ".pdf"
        downloadFile = fileName & "_lock.pdf"
        fileName = fileName & ".pdf"

        'PdfWriter.GetInstance(doc, New FileStream(Application.StartupPath & "/payData/" & fileName, FileMode.Create))

        PdfWriter.GetInstance(doc, New FileStream(fileName, FileMode.Create))
        doc.Open()

        Dim columnwidthCur As Integer()
        Dim cellData As PdfPCell

        ' CREATE LINE SEPERATOR

        Dim line As New LineSeparator()
        line = New LineSeparator()
        line.LineWidth = 1
        line.LineColor = BaseColor.GRAY
        line.Percentage = 100  ' Full width
        line.Alignment = Element.ALIGN_CENTER

        Dim table1 = New PdfPTable(1)
        columnwidthCur = {50}
        table1.SetWidths(columnwidthCur)
        table1.WidthPercentage = 50
        table1.HorizontalAlignment = 0

        ' PRINT THE COMPANY ADDRESS 
        '

        Dim arrCompanyAddressLines As New ArrayList

        Dim strCompanyContactDetails As String = Nothing
        If Not String.IsNullOrEmpty(strCompanyTelephone) Then
            strCompanyContactDetails = strCompanyContactDetails & strCompanyTelephone & ", "
        End If
        If Not String.IsNullOrEmpty(strCompanyContactCellNumber) Then
            strCompanyContactDetails = strCompanyContactDetails & strCompanyContactCellNumber & ", "
        End If
        If Not String.IsNullOrEmpty(strCompanyEmailAddress) Then
            strCompanyContactDetails = strCompanyContactDetails & strCompanyEmailAddress & ", "
        End If

        If Not String.IsNullOrEmpty(Trim(strCompanyContactDetails)) Then
            strCompanyContactDetails = Mid(strCompanyContactDetails, 1, strCompanyContactDetails.Length - 2)
        End If
        If Not String.IsNullOrEmpty(strCompanyName) Then arrCompanyAddressLines.Add(strCompanyName)
        If Not String.IsNullOrEmpty(strCompanyAddress1) Then arrCompanyAddressLines.Add(strCompanyAddress1)
        If Not String.IsNullOrEmpty(strCompanyAddress2) Then arrCompanyAddressLines.Add(strCompanyAddress2)
        If Not String.IsNullOrEmpty(strCompanyAddress3) Then arrCompanyAddressLines.Add(strCompanyAddress3)
        If Not String.IsNullOrEmpty(strCompanyAddress4) Then arrCompanyAddressLines.Add(strCompanyAddress4)
        If Not String.IsNullOrEmpty(strCompanyContactDetails) Then arrCompanyAddressLines.Add(strCompanyContactDetails)

        For p As Integer = 0 To arrCompanyAddressLines.Count - 1
            cellData = New PdfPCell(New Phrase(arrCompanyAddressLines.Item(p).ToString, New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111))))
            cellData.BorderWidth = 0
            cellData.HorizontalAlignment = 0
            table1.AddCell(cellData)
        Next

        Dim table2 = New PdfPTable(1)
        columnwidthCur = {50}
        table2.SetWidths(columnwidthCur)
        table2.WidthPercentage = 50
        table2.HorizontalAlignment = 0

        If Not String.IsNullOrEmpty(Trim(strLogoPath)) Then
            If System.IO.File.Exists(strLogoPath) Then
                Dim image As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(strLogoPath)
                image.Alignment = Element.ALIGN_RIGHT
                image.ScaleToFit(180.0F, 250.0F)
                cellData = New PdfPCell
                cellData.AddElement(image)
                cellData.HorizontalAlignment = 0
                cellData.BorderWidth = 0
                table2.AddCell(cellData)
            End If
        End If

        Dim HeaderTable As PdfPTable = New PdfPTable(2)
        Dim columnwidthHeader As Integer() = {50, 50}
        HeaderTable.SetWidths(columnwidthHeader)
        HeaderTable.WidthPercentage = 100
        HeaderTable.SpacingAfter = 3
        HeaderTable.HorizontalAlignment = 0
        HeaderTable.DefaultCell.Border = PdfPCell.NO_BORDER
        HeaderTable.AddCell(table1)
        HeaderTable.AddCell(table2)
        doc.Add(HeaderTable)

        doc.Add(line)
        doc.Add(New Paragraph(" "))

        Dim documentTitle As String = UCase(DocumentType)

        Select Case UCase(DocumentType)
            Case Is = "INVOICE"
                documentTitle = UCase(strInvoiceHeader)
            Case Is = "AUCTION STATEMENT"
                documentTitle = UCase(DocumentType)
            Case Is = "QUOTATION"
                documentTitle = UCase(strQuotationHeader)
            Case Is = "PROFORMA"
                documentTitle = UCase(strProformaHeader)
            Case Is = "TAX INVOICE"
                documentTitle = "TAX INVOICE"
            Case Is = "DELIVERY NOTE"
                If strDeliveryNoteFrom = "INVOICES" Then
                    documentTitle = UCase("DELIVERY NOTE")
                Else
                    documentTitle = UCase(strGatePassHeader)
                End If
            Case Is = "CREDIT NOTE"
                documentTitle = UCase(strCreditNoteHeader)
            Case Is = "DEBIT NOTE"
                PrintBankingInformation = False
            Case Is = "GOODS RECEIVED NOTE"
                documentTitle = UCase(DocumentType)
            Case Is = "SETTLEMENT"
                documentTitle = UCase("RECEIPT")
            Case Is = "FEES"
                documentTitle = UCase("SCHOOL RECEIPT")
            Case Is = "STATEMENT"
                documentTitle = "CUSTOMER STATEMENT"
            Case Is = "MEMBER STATEMENT"
                documentTitle = "COOP MEMBER STATEMENT"
            Case Is = "STUDENT STATEMENT"
                documentTitle = "STUDENT STATEMENT"
            Case Is = "STATEMENT OF UNPAIDS"
                documentTitle = "STATEMENT OF UNPAIDS"
            Case Is = "LEGAL STATEMENT"
                documentTitle = "CUSTOMER STATEMENT"
            Case Is = "AUCTION STATEMENT"
                documentTitle = "AUCTION STATEMENT"
            Case Is = "PLAINTIFF STATEMENT"
                documentTitle = "PLAINTIFF STATEMENT"
            Case Is = "DEFENDANT STATEMENT"
                documentTitle = "DEFENDANT STATEMENT"
            Case Else
                documentTitle = UCase(DocumentType)
        End Select

        Dim title As Paragraph = New Paragraph()
        title.Add(New Chunk(UCase(documentTitle), New Font(Font.FontFamily.HELVETICA, 20, 1, New BaseColor(50, 50, 111))))
        title.Alignment = 1
        doc.Add(title)

        ' PRINT CUSTOMER AND DOCUMENT DETAILS
        '
        doc.Add(New Paragraph(" "))

        Dim table3 = New PdfPTable(2)
        Dim columnwidthAddr As Integer() = {50, 50}
        table3.SetWidths(columnwidthAddr)
        table3.WidthPercentage = 100
        table3.HorizontalAlignment = 0

        Dim columnOne As String = "CUSTOMER DETAILS"
        Dim columnTwo As String = "DOCUMENT DETAILS"
        cellData = New PdfPCell(New Phrase(columnOne, New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111)))) With {
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .BackgroundColor = New BaseColor(244, 244, 244),
                    .Padding = 5
                }
        cellData.HorizontalAlignment = 0
        table3.AddCell(cellData)
        cellData = New PdfPCell(New Phrase(columnTwo, New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111)))) With {
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .BackgroundColor = New BaseColor(244, 244, 244),
            .Padding = 5}
        cellData.HorizontalAlignment = 0
        table3.AddCell(cellData)
        doc.Add(table3)

        Dim arrCustomerAddress As New ArrayList
        Dim arrDocumentDetails As New ArrayList

        With arrCustomerAddress
            If UCase(DocumentType) = "PLAINTIFF STATEMENT" Or UCase(DocumentType) = "DEFENDANT STATEMENT" Then
                .Add(strPlaintiffName)
                .Add(strPlaintiffAddress1)
                .Add(strPlaintiffAddress2)
                .Add(strPlaintiffAddress3)
                .Add(strPlaintiffAddress4)
                .Add(sCustomerTelephone)
                .Add(sCustomerBpNumber)
            Else
                .Add(sCustomerName)
                .Add(sCustomerAddress1)
                .Add(sCustomerAddress2)
                .Add(sCustomerAddress3)
                .Add(sCustomerAddress4)
                .Add(sCustomerTelephone)
            End If

            If Not String.IsNullOrEmpty(sCustomerVatNumber) Then
                .Add("VAT NO:" & sCustomerVatNumber)
            End If
            If Not String.IsNullOrEmpty(sCustomerBpNumber) Then
                .Add("BP/TIN:" & sCustomerBpNumber)
            End If

        End With

        Dim tableCustomerDetails = New PdfPTable(1)
        Dim columnWidths As Integer() = {50}
        tableCustomerDetails.SetWidths(columnWidths)
        tableCustomerDetails.WidthPercentage = 50
        tableCustomerDetails.HorizontalAlignment = 0
        tableCustomerDetails.DefaultCell.Border = PdfPCell.NO_BORDER

        With arrCustomerAddress
            For p As Integer = 0 To .Count - 1
                If Not String.IsNullOrEmpty(Trim(.Item(p).ToString)) Then
                    columnOne = .Item(p).ToString
                    cellData = New PdfPCell(New Phrase(columnOne, New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111))))
                    cellData.Border = PdfPCell.NO_BORDER
                    cellData.HorizontalAlignment = 0
                    cellData.Padding = 5
                    tableCustomerDetails.AddCell(cellData)
                End If
            Next
        End With

        Dim tableDocumentDetails = New PdfPTable(2)
        Dim columnWidths2 As Integer() = {20, 30}
        tableDocumentDetails.SetWidths(columnWidths2)
        tableDocumentDetails.WidthPercentage = 50
        tableDocumentDetails.HorizontalAlignment = 0
        tableDocumentDetails.DefaultCell.Border = PdfPCell.NO_BORDER

        arrDocumentDetails.Add("DATE|" & sPrintDate)
        arrDocumentDetails.Add("DOC. NO.|" & DocumentNumber)
        arrDocumentDetails.Add("ORDER NO.|")
        arrDocumentDetails.Add("REFER TO|" & sAgent)
        arrDocumentDetails.Add("CURRENCY|" & strSalesCurrencyUsed)

        With arrDocumentDetails
            For p As Integer = 0 To .count - 1
                Dim strBuffer() As String = Split(.Item(p).ToString, "|")
                Dim columnName As String = strBuffer(0)
                Dim columnValue As String = strBuffer(1)
                Dim cellColumnName As PdfPCell = New PdfPCell(New Phrase(columnName, New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111))))
                cellColumnName.HorizontalAlignment = 0
                'cellColumnName.Border = PdfPCell.NO_BORDER
                cellColumnName.BackgroundColor = New BaseColor(244, 244, 244)
                cellColumnName.Padding = 5
                tableDocumentDetails.AddCell(cellColumnName)
                Dim cellColumnValue As PdfPCell = New PdfPCell(New Phrase(columnValue, New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111))))
                cellColumnValue.HorizontalAlignment = 0
                cellColumnValue.Padding = 5
                tableDocumentDetails.AddCell(cellColumnValue)
            Next
        End With

        Dim HeaderTableTwo As PdfPTable = New PdfPTable(2)
        columnwidthHeader = {50, 50}
        HeaderTableTwo.SetWidths(columnwidthHeader)
        HeaderTableTwo.WidthPercentage = 100
        HeaderTableTwo.SpacingAfter = 3
        HeaderTableTwo.HorizontalAlignment = 0
        HeaderTableTwo.AddCell(tableCustomerDetails)
        HeaderTableTwo.AddCell(tableDocumentDetails)
        doc.Add(HeaderTableTwo)

        doc.Add(New Paragraph(" "))

        Dim strColumnAlignments As String = "0|0|0|0|0|0"
        Dim strColumnHeaders As String = "|||||"
        Dim strColumnWidths As String = "100|100|100|100|100|100"
        Dim strColumnFormating As String = "NO|NO|NO|NO|NO|NO"

        Dim strSummaryCaptions As String = Nothing
        Dim strSummaryValues As String = Nothing
        Dim strSummaryAlignments As String = "2|2|2|2|2"

        If UCase(DocumentType) = "DELIVERY NOTE" Then
            strColumnAlignments = "0|0|0|2|2"
        Else
            If UCase(DocumentType) = "GOODS RECEIVED NOTE" Then
                strColumnAlignments = "0|0|0|2|2|2|0"
            Else
                If UCase(DocumentType) = "SETTLEMENT" Then
                    strColumnAlignments = "0|0|2|2|2|2|2"
                Else
                    If UCase(DocumentType) = "STATEMENT" Or UCase(DocumentType) = "LEGAL STATEMENT" Or UCase(DocumentType) = "STUDENT STATEMENT" Then
                        strColumnAlignments = "0|0|0|0|2|2|2"
                    Else
                        If UCase(DocumentType) = "STATEMENT OF UNPAIDS" Then
                            strColumnAlignments = "0|0|0|2|2|2|2"
                        Else
                            If UCase(DocumentType) = "AUCTION STATEMENT" Then
                                strColumnAlignments = "0|0|0|0|2|2|2"
                            Else
                                If UCase(DocumentType) = "MEMBER STATEMENT" Then
                                    strColumnAlignments = "0|0|2|2|2|2|2"
                                Else
                                    If UCase(DocumentType) = "FEES" Then
                                        strColumnAlignments = "0|0|2|2|2|2|2"
                                    Else
                                        If UCase(DocumentType) = "PLAINTIFF STATEMENT" Then
                                            strColumnAlignments = "0|0|0|0|2|2|0"
                                        Else
                                            strColumnAlignments = "2|0|2|2|2|2|2"
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If UCase(DocumentType) = "DELIVERY NOTE" Then
            strColumnHeaders = "QTY|DESCRIPTION|SERIAL NO.|UNIT COST|TOTAL COST"
        Else
            If UCase(DocumentType) = "GOODS RECEIVED NOTE" Then
                strColumnHeaders = "ITEM CODE|DESCRIPTION|SERIAL|UNIT $|QTY|GROSS|BRANCH"
            Else
                If UCase(DocumentType) = "SETTLEMENT" Then
                    strColumnHeaders = "DETAILS|INV. NO.|VALUE|PAID PRIOR|CR. NOTES|CURRENT|BALANCE"
                Else
                    If UCase(DocumentType) = "STATEMENT" Or UCase(DocumentType) = "LEGAL STATEMENT" Or UCase(DocumentType) = "STUDENT STATEMENT" Then
                        strColumnHeaders = "DATE|DESCRIPTION|REF.#|PROJ.#|DEBIT|CREDIT|BALANCE"
                    Else
                        If UCase(DocumentType) = "STATEMENT OF UNPAIDS" Then
                            strColumnHeaders = "DATE|DESCRIPTION|REF.#|DEBIT|CREDIT|C.NOTE|BALANCE"
                        Else
                            If UCase(DocumentType) = "AUCTION STATEMENT" Then
                                strColumnHeaders = "DESCRIPTION|MODEL|COLOR|IDENTITY|COST|FEES|PAYABLE"
                            Else
                                If UCase(DocumentType) = "MEMBER STATEMENT" Then
                                    strColumnHeaders = "DATE|DESCRIPTION|MNTHLY BILLING|PAYMENTS|INTEREST|MNTHLY BILL DUE BAL.|PROPERTY BAL. DUE"
                                Else
                                    If UCase(DocumentType) = "FEES" Then
                                        strColumnHeaders = "DETAILS|REF. NO.|BILLED|PAID PRIOR|CR. NOTES|CURRENT|BALANCE"
                                    Else
                                        If UCase(DocumentType) = "PLAINTIFF STATEMENT" Then
                                            strColumnHeaders = "DATE|BOOK #|ADVICE #|DESCRIPTION|CHARGE|PAYMENT|"
                                        Else
                                            strColumnHeaders = "QTY|DESCRIPTION|UNIT COST|GROSS|DISCOUNT|TAX|PAYABLE"
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If UCase(DocumentType) = "DELIVERY NOTE" Then
            strColumnWidths = "60|250|120|100|100"
            strColumnFormating = "NO|NO|NO|NO|NO"
        Else
            If UCase(DocumentType) = "GOODS RECEIVED NOTE" Then
                strColumnWidths = "130|170|100|70|40|60|140"
                strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            Else
                If UCase(DocumentType) = "SETTLEMENT" Then
                    strColumnWidths = "150|80|80|80|80|80|85"
                    strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                Else
                    If UCase(DocumentType) = "STATEMENT" Or UCase(DocumentType) = "LEGAL STATEMENT" Or
                                UCase(DocumentType) = "STUDENT STATEMENT" Then
                        strColumnWidths = "80|190|60|78|78|78|85"
                        strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                    Else
                        If UCase(DocumentType) = "STATEMENT OF UNPAIDS" Then
                            strColumnWidths = "80|190|78|78|78|78|78"
                            strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                        Else
                            If UCase(DocumentType) = "AUCTION STATEMENT" Then
                                strColumnWidths = "180|80|80|80|80|70|90"
                                strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                            Else
                                If UCase(DocumentType) = "MEMBER STATEMENT" Then
                                    strColumnWidths = "80|155|80|80|80|80|80"
                                    strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                                Else
                                    If UCase(DocumentType) = "FEES" Then
                                        strColumnWidths = "150|80|80|80|80|80|85"
                                        strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                                    Else
                                        If UCase(DocumentType) = "PLAINTIFF STATEMENT" Then
                                            strColumnWidths = "100|80|80|160|80|80|0"
                                            strColumnFormating = "NO|NO|NO|NO|YES|YES|NO"
                                        Else
                                            strColumnWidths = "50|200|78|80|78|78|85"
                                            strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If UCase(DocumentType) <> "DELIVERY NOTE" Then
            'If there are summary totals activate this code
            If UCase(DocumentType) = "GOODS RECEIVED NOTE" Then
                strSummaryCaptions = "QTY TOTAL|GROSS TOTAL"
                strSummaryValues = ThousandSeperatedNumber(dblQuantityTotal) & "|" & ThousandSeperatedNumber(dblGrossTotal)
                strSummaryAlignments = "2|2"
            Else
                If UCase(DocumentType) = "SETTLEMENT" Then
                    strSummaryCaptions = "INVOICE TOTALS|LESS PAID PRIOR|LESS CR. NOTES|RECEIVED NOW|CURR.BAL."
                    strSummaryValues = ThousandSeperatedNumber(dblSettlementInvoiceTotals) & "|" & ThousandSeperatedNumber(dblSettlementReceivedToDate) _
                                & "|" & ThousandSeperatedNumber(dblSettlementCreditNotesValue) & "|" & ThousandSeperatedNumber(dblSettlementReceivedCurrently) _
                                & "|" & ThousandSeperatedNumber(dblSettlementCurrentBalance)
                    strSummaryAlignments = "2|2|2|2|2"
                Else
                    If UCase(DocumentType) = "STATEMENT" Or UCase(DocumentType) = "LEGAL STATEMENT" Or UCase(DocumentType) = "STUDENT STATEMENT" Then
                        strSummaryCaptions = "0 TO 30 DYS|30 TO 60 DYS|60 TO 90 DYS|OVER 90 DYS|TOTAL DUE"
                        strSummaryValues = ThousandSeperatedNumber(dblCurrentStatementBalance) & "|" & ThousandSeperatedNumber(dblBetween30and60) _
                                    & "|" & ThousandSeperatedNumber(dblBetween60and90) & "|" & ThousandSeperatedNumber(dblOver90) _
                                    & "|" & ThousandSeperatedNumber(dblCurrentStatementBalance)
                        strSummaryAlignments = "2|2|2|2|2"
                    Else
                        If UCase(DocumentType) = "STATEMENT OF UNPAIDS" Then
                            strSummaryCaptions = "INVOICE TOTAL|LESS RECEIPTS|SUB TOTAL|LESS C.NOTES|DUE (" & UCase(strSalesCurrencyUsed) & " )"
                            strSummaryValues = ThousandSeperatedNumber(dblPublicInvoiceTotals) & "|" & ThousandSeperatedNumber(dblPublicReceiptsTotals) _
                                        & "|" & ThousandSeperatedNumber(dblPublicSubUnpaidTotals) & "|" & ThousandSeperatedNumber(dblPublicCreditNotesTotals) _
                                        & "|" & ThousandSeperatedNumber(dblUnpaidsBalanceTotal)
                            strSummaryAlignments = "2|2|2|2|2"
                        Else
                            If UCase(DocumentType) = "AUCTION STATEMENT" Then
                                strSummaryCaptions = "GROSS TOTAL|LESS DEPOSIT|SUB TOTAL|CARD FEES|DUE (" & UCase(strSalesCurrencyUsed) & " )"
                                strSummaryValues = ThousandSeperatedNumber(dblTotalActionsAndFees) & "|" & ThousandSeperatedNumber(dblAuctionDeposits) _
                                            & "|" & ThousandSeperatedNumber(dblAuctionSubTotal) & "|" & ThousandSeperatedNumber(dblAuctionCardFees) _
                                            & "|" & ThousandSeperatedNumber(dblAuctionPayableAmt)
                                strSummaryAlignments = "2|2|2|2|2"
                            Else
                                If UCase(DocumentType) = "MEMBER STATEMENT" Then
                                    strSummaryCaptions = "BALANCE B/F|BILLING TOTAL|INTERESTS|SUB TOTAL|LESS PAYMENTS|MONTH BILLS DUE| |PROPERTY AMT|PAID TO DATE|DUE (" & UCase(strSalesCurrencyUsed) & " )"
                                    strSummaryValues = ThousandSeperatedNumber(dblPriorPeriodStatementBalance) & "|" _
                                                & ThousandSeperatedNumber(dblBillingTotals) & "|" & ThousandSeperatedNumber(dblInterestCharges) _
                                                & "|" & ThousandSeperatedNumber((dblBillingTotals + dblInterestCharges + dblPriorPeriodStatementBalance)) _
                                                & "|" & ThousandSeperatedNumber(dblPaymentTotals) _
                                                & "|" & ThousandSeperatedNumber((dblBillingTotals + dblInterestCharges + dblPriorPeriodStatementBalance) - dblPaymentTotals) _
                                                & "|" & Space(10) & "|" & ThousandSeperatedNumber(dblPrintPropertyValue) & "|" & ThousandSeperatedNumber(dblPrintPropertyRepaymentSum) _
                                                & "|" & ThousandSeperatedNumber((dblPrintPropertyValue - dblPrintPropertyRepaymentSum))
                                    strSummaryAlignments = "2|2|2|2|2|2|0|2|2|2"
                                Else
                                    If UCase(DocumentType) = "FEES" Then
                                        strSummaryCaptions = "OPENING BALANCE|LESS PAID PRIOR|LESS CR. NOTES|RECEIVED NOW|CURR.BAL."
                                        strSummaryValues = ThousandSeperatedNumber(Total1) & "|" & ThousandSeperatedNumber(dblSettlementReceivedToDate) _
                                                    & "|" & ThousandSeperatedNumber(dblSettlementCreditNotesValue) & "|" & ThousandSeperatedNumber(Total4) _
                                                    & "|" & ThousandSeperatedNumber(Total5)
                                        strSummaryAlignments = "2|2|2|2|2"
                                    Else
                                        If UCase(DocumentType) = "PLAINTIFF STATEMENT" Then
                                            strSummaryCaptions = "INITIAL DEBT|LESS DEPOSIT|SUB TOTAL|LESS PAYMENTS|DEBT DUE"
                                            strSummaryValues = ThousandSeperatedNumber(dblUnitTotals) & "|" & ThousandSeperatedNumber(dblDiscounts) _
                                                        & "|" & ThousandSeperatedNumber(dblSubTotal) & "|" & ThousandSeperatedNumber(dblTotalTaxes) _
                                                        & "|" & ThousandSeperatedNumber(dblGrossTotal)
                                            strSummaryAlignments = "2|2|2|2|2"
                                        Else
                                            strSummaryCaptions = "UNITS TOTAL|LESS DISCOUNT|SUB TOTAL|TAX AMOUNT|INVOICE TOTAL"
                                            strSummaryValues = ThousandSeperatedNumber(dblUnitTotals) & "|" & ThousandSeperatedNumber(dblDiscounts) _
                                                        & "|" & ThousandSeperatedNumber(dblSubTotal) & "|" & ThousandSeperatedNumber(dblTotalTaxes) _
                                                        & "|" & ThousandSeperatedNumber(dblGrossTotal)
                                            strSummaryAlignments = "2|2|2|2|2"
                                        End If
                                    End If
                                End If '279821673 gtiair@1
                            End If
                        End If
                    End If
                End If
            End If
        Else
            strSummaryCaptions = "QTY TOTAL|GROSS TOTAL"
            strSummaryValues = ThousandSeperatedNumber(dblQuantityTotal) & "|" & ThousandSeperatedNumber(dblGrossTotal)
            strSummaryAlignments = "2|2"
        End If

        ' 1.0 PRINT THE DETAILS HEADER
        '

        Dim strHeaders() As String = Split(strColumnHeaders, "|")
        Dim intColsCount As Integer = strHeaders.Length

        ' Calculate the column sizes as ratios from the set width
        '
        Dim setWidths() As String = Split(strColumnWidths, "|")
        Dim cellWidth(0 To setWidths.Length - 1)
        Dim widthTotal As Integer = 0

        For p As Integer = 0 To setWidths.Length - 1
            widthTotal = widthTotal + CInt(setWidths(p))
        Next

        For p As Integer = 0 To setWidths.Length - 1
            Dim curColWidth As Integer = CInt(setWidths(p).ToString)
            If curColWidth > 0 Then
                cellWidth(p) = Math.Round((curColWidth / widthTotal) * 100, 0)
            Else
                cellWidth(p) = 0
            End If
        Next

        ' Verify that the cell widths add up to 100

        Dim intCellTotalWidth As Integer = 0
        For p As Integer = 0 To cellWidth.Length - 1
            intCellTotalWidth = intCellTotalWidth + cellWidth(p)
        Next

        Dim intWidthVariance As Integer = 100 - intCellTotalWidth
        If intWidthVariance < 0 Then
            cellWidth(cellWidth.Length - 1) = cellWidth(cellWidth.Length - 1) + intWidthVariance
        Else
            cellWidth(cellWidth.Length - 1) = cellWidth(cellWidth.Length - 1) - intWidthVariance
        End If

        Dim detailsHeader As PdfPTable = New PdfPTable(intColsCount)
        Dim objHeaderWidths(0 To setWidths.Length - 1) As Single

        For p As Integer = 0 To setWidths.Length - 1
            objHeaderWidths(p) = Convert.ToSingle(setWidths(p))
        Next

        detailsHeader.SetWidths(objHeaderWidths)
        detailsHeader.WidthPercentage = 100
        detailsHeader.SpacingAfter = 3
        detailsHeader.HorizontalAlignment = 0

        ' Now add the headers
        '

        For p As Integer = 0 To strHeaders.Length - 1
            cellData = New PdfPCell(New Phrase(strHeaders(p).ToString, New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111)))) With {
                        .HorizontalAlignment = Element.ALIGN_CENTER,
                        .BackgroundColor = New BaseColor(244, 244, 244),
                        .Padding = 5
                    }
            cellData.HorizontalAlignment = 0
            detailsHeader.AddCell(cellData)
        Next
        doc.Add(detailsHeader)

        ' 2.0 PRINT THE DETAIL LINES 
        '

        Dim detailsTable As PdfPTable = New PdfPTable(intColsCount)
        detailsTable.SetWidths(objHeaderWidths)
        detailsTable.WidthPercentage = 100
        detailsTable.SpacingAfter = 3
        detailsTable.HorizontalAlignment = 0

        Dim colAlignment() As String = Split(strColumnAlignments, "|")
        Dim colFormat() As String = Split(strColumnFormating, "|")

        Dim intPrnCount As Integer = 0
        For p As Integer = 0 To strPrintDetails.Length - 1
            Dim boolIsFirstRow As Boolean = False
            Dim boolIsLastRow As Boolean = False
            If Not String.IsNullOrEmpty(Trim(strPrintDetails(p).ToString)) Then
                Dim strlineCellValues() As String = Split(strPrintDetails(p), "|")
                If intPrnCount = 0 Then boolIsFirstRow = True
                If intPrnCount = strPrintDetails.Length - 1 Then
                    boolIsLastRow = True
                End If
                For j As Integer = 0 To strlineCellValues.Length - 1
                    If colFormat(j).ToString.ToUpper = "YES" Then
                        If IsNumeric(Trim(strlineCellValues(j).ToString)) Then
                            strlineCellValues(j) = ThousandSeperatedNumber(CDbl(strlineCellValues(j).ToString))
                        End If
                    End If
                    cellData = New PdfPCell(New Phrase(strlineCellValues(j).ToString, New Font(Font.FontFamily.HELVETICA, 8, 0, New BaseColor(50, 50, 111))))
                    cellData.HorizontalAlignment = Convert.ToSingle(colAlignment(j))
                    cellData.Padding = 3
                    If boolIsFirstRow = True AndAlso boolIsLastRow = True Then
                        cellData.Padding = 5
                        cellData.Border = Rectangle.LEFT_BORDER Or Rectangle.RIGHT_BORDER Or Rectangle.TOP_BORDER Or Rectangle.BOTTOM_BORDER
                    Else
                        If boolIsLastRow = True Then
                            cellData.Padding = 5
                            cellData.Border = Rectangle.LEFT_BORDER Or Rectangle.RIGHT_BORDER Or Rectangle.BOTTOM_BORDER
                        Else
                            If boolIsFirstRow = True Then
                                cellData.Border = Rectangle.LEFT_BORDER Or Rectangle.RIGHT_BORDER Or Rectangle.TOP_BORDER
                            Else
                                cellData.Border = Rectangle.LEFT_BORDER Or Rectangle.RIGHT_BORDER
                            End If
                        End If
                    End If
                    detailsTable.AddCell(cellData)
                Next
                intPrnCount += 1
            End If
        Next
        doc.Add(detailsTable)

        ' 3.0 CREATE TABLES FOR NOTES AND TOTALS PRINTING
        '

        Dim tableNotes = New PdfPTable(1)
        Dim columnWidthNotes As Integer() = {50}
        tableNotes.SetWidths(columnWidthNotes)
        tableNotes.WidthPercentage = 50
        tableNotes.HorizontalAlignment = 0
        tableNotes.DefaultCell.Border = PdfPCell.NO_BORDER
        tableNotes.DefaultCell.SetLeading(0, 2.5F)

        cellData = New PdfPCell(New Phrase("NOTES", New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111)))) With {
            .HorizontalAlignment = Element.ALIGN_CENTER}
        cellData.HorizontalAlignment = 0
        cellData.Border = Rectangle.NO_BORDER
        tableNotes.AddCell(cellData)

        cellData = New PdfPCell(New Phrase(sComment, New Font(Font.FontFamily.HELVETICA, 8, 0, New BaseColor(50, 50, 111)))) With {
            .HorizontalAlignment = Element.ALIGN_CENTER,
            .Padding = 8}
        cellData.HorizontalAlignment = 0
        cellData.Border = Rectangle.NO_BORDER
        cellData.NoWrap = False
        'cellData.DefaultCell.SetLeading(0, 1.5F)
        tableNotes.AddCell(cellData)

        Dim tableTotals = New PdfPTable(2)
        Dim columnTotalWidths As Integer() = {30, 20}
        tableTotals.SetWidths(columnTotalWidths)
        tableTotals.WidthPercentage = 50
        tableTotals.HorizontalAlignment = 0
        'tableTotals.DefaultCell.Border = PdfPCell.NO_BORDER

        Dim arrDocumentTotalLines As New ArrayList

        Dim summaryCaptions() As String = Split(strSummaryCaptions, "|")
        Dim summaryValues() As String = Split(strSummaryValues, "|")

        For p As Integer = 0 To summaryCaptions.Length - 1
            arrDocumentTotalLines.Add(UCase(Trim(summaryCaptions(p).ToString)) & "|" & Trim(summaryValues(p).ToString))
        Next

        With arrDocumentTotalLines
            For p As Integer = 0 To .Count - 1
                Dim strBuffer() As String = Split(.Item(p).ToString, "|")
                Dim cellColumnName As PdfPCell = New PdfPCell(New Phrase(strBuffer(0), New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111))))
                cellColumnName.HorizontalAlignment = 0
                cellColumnName.Border = Rectangle.LEFT_BORDER Or Rectangle.RIGHT_BORDER Or Rectangle.TOP_BORDER Or Rectangle.BOTTOM_BORDER
                cellColumnName.BackgroundColor = New BaseColor(244, 244, 244)
                cellColumnName.Padding = 5
                tableTotals.AddCell(cellColumnName)
                Dim cellColumnValue As PdfPCell = New PdfPCell(New Phrase(strBuffer(1), New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111))))
                cellColumnValue.HorizontalAlignment = 2
                'cellColumnValue.Border = PdfPCell.NO_BORDER
                cellColumnValue.Padding = 5
                tableTotals.AddCell(cellColumnValue)
            Next
        End With

        Dim summaryContainerTable As PdfPTable = New PdfPTable(2)
        columnwidthHeader = {50, 50}
        summaryContainerTable.SetWidths(columnwidthHeader)
        summaryContainerTable.WidthPercentage = 100
        summaryContainerTable.SpacingAfter = 3
        summaryContainerTable.HorizontalAlignment = 0
        summaryContainerTable.DefaultCell.Border = PdfPCell.NO_BORDER
        summaryContainerTable.AddCell(tableNotes)
        summaryContainerTable.AddCell(tableTotals)
        doc.Add(summaryContainerTable)

        ' 4.0 PRINT BANKING DETAILS
        '
        Dim tableBanking = New PdfPTable(1)
        Dim bankWidth As Integer() = {85}
        tableBanking.SetWidths(bankWidth)
        tableBanking.WidthPercentage = 85
        tableBanking.HorizontalAlignment = 0
        tableBanking.SpacingAfter = 3

        cellData = New PdfPCell(New Phrase("OUR BANKING DETAILS", New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111)))) With {
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .BackgroundColor = New BaseColor(244, 244, 244),
                    .Padding = 5
                }
        cellData.HorizontalAlignment = 0
        tableBanking.AddCell(cellData)
        doc.Add(tableBanking)

        Dim tableBankingDetails = New PdfPTable(5)
        Dim bankDetailsWidth As Integer() = {10, 10, 30, 20, 15}
        tableBankingDetails.SetWidths(bankDetailsWidth)
        tableBankingDetails.WidthPercentage = 85
        tableBankingDetails.HorizontalAlignment = 0
        tableBankingDetails.SpacingAfter = 3

        cellData = New PdfPCell(New Phrase("Sort Code", New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111)))) With {
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .BackgroundColor = New BaseColor(244, 244, 244),
                    .Padding = 5
                }
        cellData.HorizontalAlignment = 0
        tableBankingDetails.AddCell(cellData)

        cellData = New PdfPCell(New Phrase("Swift Code", New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111)))) With {
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .BackgroundColor = New BaseColor(244, 244, 244),
                    .Padding = 5
                }
        cellData.HorizontalAlignment = 0
        tableBankingDetails.AddCell(cellData)

        cellData = New PdfPCell(New Phrase("Name", New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111)))) With {
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .BackgroundColor = New BaseColor(244, 244, 244),
                    .Padding = 5
                }
        cellData.HorizontalAlignment = 0
        tableBankingDetails.AddCell(cellData)

        cellData = New PdfPCell(New Phrase("Type", New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111)))) With {
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .BackgroundColor = New BaseColor(244, 244, 244),
                    .Padding = 5
                }
        cellData.HorizontalAlignment = 0
        tableBankingDetails.AddCell(cellData)

        cellData = New PdfPCell(New Phrase("Account No.", New Font(Font.FontFamily.HELVETICA, 8, 1, New BaseColor(50, 50, 111)))) With {
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .BackgroundColor = New BaseColor(244, 244, 244),
                    .Padding = 5
                }
        cellData.HorizontalAlignment = 0
        tableBankingDetails.AddCell(cellData)

        Dim strBankSql As String = Nothing
        If gwt_comm.CheckColumnExistence("SystemCoyBanks", "SwiftCode") = False Then
            strBankSql = "ALTER TABLE [SystemCoyBanks] ADD [SwiftCode][NVARCHAR](35) NOT NULL DEFAULT ''"
            objCommand = New Data.OleDb.OleDbCommand(strBankSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        strBankSql = "SELECT SystemCoyBanks.BankCode, SystemCoyBanks.SwiftCode," _
                & "SystemBanks.BankName, SystemCoyBanks.AccountName, " _
                & "SystemCoyBanks.AccountNumber FROM SystemCoyBanks " _
                & "LEFT OUTER JOIN SystemBanks ON " _
                & "SystemCoyBanks.BankCode = SystemBanks.BankCode " _
                & "WHERE SystemCoyBanks.Status = 'ACTIVE'"
        objCommand = New Data.OleDb.OleDbCommand(strBankSql, cnn)
        objReader = objCommand.ExecuteReader

        arrCompanyBankDetails = New ArrayList
        While objReader.Read
            Dim strBcode As String = Nothing
            Dim strSwiftCode As String = Nothing
            Dim strBname As String = Nothing
            Dim strBaccName As String = Nothing
            Dim strBaccNum As String = Nothing
            If Not IsDBNull(objReader(0).ToString) Then strBcode = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strSwiftCode = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strBname = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then strBaccName = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then strBaccNum = objReader(4).ToString
            arrCompanyBankDetails.Add(strBcode & "|" & strSwiftCode & "|" & strBname & "|" & strBaccName & "|" & strBaccNum)
        End While
        objReader.Close()

        For p As Integer = 0 To arrCompanyBankDetails.Count - 1
            Dim strBuffer() As String = Split(arrCompanyBankDetails.Item(p), "|")
            For j As Integer = 0 To strBuffer.Length - 1
                cellData = New PdfPCell(New Phrase(UCase(strBuffer(j).ToString), New Font(Font.FontFamily.HELVETICA, 8, 0, New BaseColor(50, 50, 111))))
                cellData.HorizontalAlignment = 0
                tableBankingDetails.AddCell(cellData)
            Next
        Next

        doc.Add(tableBankingDetails)

        ' 5.0 CLOSE THE FILE
        '
        doc.Close()

        Dim WorkingFolder As String = Application.StartupPath & "/payData/" & fileName 'Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim InputFile As String = Path.Combine(WorkingFolder)
        'Dim OutputFile As String = Path.Combine(Application.StartupPath & "/payData/" & downloadFile)

        'Using input As Stream = New FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read)
        '    Using output As Stream = New FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None)
        '        Dim reader As PdfReader = New PdfReader(input)
        '        PdfEncryptor.Encrypt(reader, output, True, customerPassword, "elpoeptaerg", PdfWriter.AllowPrinting) 'ALLOW_SCREENREADERS
        '    End Using
        'End Using

        boolAbort = False

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & vbCrLf &
            "Error number " & Err.Number & vbCrLf &
            "On Customer Document to PDF Generation"
        ShowErrorMessage()
    End Sub

End Module
