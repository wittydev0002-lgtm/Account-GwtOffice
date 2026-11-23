Module modPrintStatement

    Public Sub PrintCustomerDocument(DirectorId As Long, DocumentType As String, Optional ByVal ViewMode As Boolean = True, Optional ByVal StatementType As String = "CURRENT")
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As OleDb.OleDbDataReader

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
        Dim sAgent As String = Nothing
        Dim sPrintDate As String = Format(Now, "dd-MM-yyyy")
        Dim sComment As String = Nothing

        strSqlMain = "SELECT EmployeeMaster.TransactionId, " _
            & "EmployeeMaster.LastName +' '+ EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames AS [AccountName], " _
            & "EmployeeMaster.Address1, EmployeeMaster.Address2, EmployeeMaster.Address3, EmployeeMaster.Address4, " _
            & "EmployeeMaster.Telephone, EmployeeMaster.Cellphone, EmployeeMaster.IdNumber, BankCode, BankAccountNumber " _
            & "FROM EmployeeMaster WHERE EmployeeMaster.TransactionId = " & DirectorId & ""
        '0715373462
        'strSqlTransactions = "SELECT UPPER(REPLACE(CONVERT(NVARCHAR(11), RunFile.OriginalTransDate, 106), ' ', '-')) AS [TDate], " _
        '    & "RunFile.Description, CAST(GrossUp AS DECIMAL (10,2)) AS [Gross Pay], " _
        '    & "CAST(RunFile.Deductions AS DECIMAL (10,2)) AS [Board Tax], CAST(RunFile.PAYE AS DECIMAL (10,2)) AS [PAYE], " _
        '    & "CAST(RunFile.AidsLevy AS DECIMAL (10,2)) AS [Aids Levy], " _
        '    & "CAST((RunFile.GrossUp - (RunFile.BoardTax + RunFile.Paye + RunFile.AidsLevy)) AS DECIMAL (10,2)) AS Payable " _
        '    & "FROM RunFile WHERE DirectorId = " & DirectorId & " ORDER BY RunFile.OriginalTransDate"

        'strSqlTransactions = "SELECT Payments.TransId, RunFile.DirectorId, RunFile.CodeId, SUM(RunFile.Amount) AS Expr1, RunFile.GrossUp, " _
        '    & "Payments.TransDate, RunFile.Description, Payments.Purpose FROM RunFile LEFT OUTER JOIN Payments ON RunFile.DirectorId = Payments.DirectorId " _
        '    & "WHERE (RunFile.DirectorId = 3) AND (RunFile.Amount = Payments.Amount) AND (RunFile.OriginalTransDate = Payments.TransDate) AND (RunFile.CodeId = Payments.PayCode) GROUP BY Payments.TransId, RunFile.DirectorId, RunFile.CodeId, RunFile.Amount, RunFile.GrossUp, Payments.TransDate, RunFile.Description, Payments.Purpose"


        '***** LAST OUTDATED TRANSACTION SELECT STATEMENT ***************************

        '' ''strSqlTransactions = "SELECT UPPER(REPLACE(CONVERT(NVARCHAR(11), RunFile.OriginalTransDate, 106), ' ', '-')) AS TDate, " _
        '' ''    & "RunFile.Description + ': ' + Payments.Purpose AS Description, CAST(RunFile.GrossUp AS DECIMAL(10, 2)) AS [Gross Pay], " _
        '' ''    & "CAST(RunFile.Deductions AS DECIMAL(10, 2)) AS [Board Tax], CAST(RunFile.PAYE AS DECIMAL(10, 2)) AS PAYE, " _
        '' ''    & "CAST(RunFile.AidsLevy AS DECIMAL(10, 2)) AS [Aids Levy], " _
        '' ''    & "CAST(RunFile.GrossUp - (RunFile.BoardTax + RunFile.PAYE + RunFile.AidsLevy) AS DECIMAL(10, 2)) AS Payable " _
        '' ''    & "FROM RunFile LEFT OUTER JOIN Payments ON RunFile.DirectorId = Payments.DirectorId " _
        '' ''    & "WHERE (RunFile.DirectorId = " & DirectorId & ") AND (RunFile.Amount = Payments.Amount) " _
        '' ''    & "AND (RunFile.OriginalTransDate = Payments.TransDate) AND (RunFile.CodeId = Payments.PayCode) " _
        '' ''    & "GROUP BY RunFile.GrossUp, RunFile.OriginalTransDate, RunFile.Description, Payments.Purpose, RunFile.Deductions, " _
        '' ''    & "RunFile.PAYE, RunFile.AidsLevy, RunFile.BoardTax ORDER BY RunFile.OriginalTransDate"



        'strSqlTransactions = "SELECT UPPER(REPLACE(CONVERT(NVARCHAR(11), RunFile.TransDate, 106), ' ', '-')) AS [TDate], " _
        '    & "PaymentCodes.Description + '-' + Payments.Purpose AS Details, CAST(RunFile.GrossUp AS DECIMAL(10, 2)) AS [Gross Pay], " _
        '    & "CAST(RunFile.Deductions AS DECIMAL(10, 2)) AS [Board Tax], CAST(RunFile.PAYE AS DECIMAL(10, 2)) AS PAYE, " _
        '    & "CAST(RunFile.AidsLevy AS DECIMAL(10, 2)) AS [Aids Levy], CAST(RunFile.GrossUp - " _
        '    & "(RunFile.BoardTax + RunFile.PAYE + RunFile.AidsLevy) AS DECIMAL(10, 2)) AS Payable FROM " _
        '    & "RunFile LEFT OUTER JOIN  PaymentCodes ON RunFile.CodeId = PaymentCodes.CodeNo " _
        '    & "LEFT OUTER JOIN RunFile ON RunFile.CodeId = Payments.PayCode WHERE RunFile.DirectorId = " & DirectorId & " " _
        '    & "GROUP BY RunFile.TransDate, Payments.PayCode, PaymentCodes.Description, Payments.Purpose, " _
        '    & "RunFile.GrossUp, RunFile.Deductions, RunFile.PAYE, RunFile.AidsLevy, RunFile.BoardTax ORDER BY Payments.TransDate"




        '**** CORRECT STATEMENT FOR TRANSACTIONS *******************

        If UCase(StatementType) = "HISTORICAL" Then
            ' StartDate, EndDate
            strSqlTransactions = "SELECT PaymentsHistory.DirectorId, PaymentsHistory.CodeId, PaymentsHistory.Amount, " _
                & "CAST(PaymentsHistory.GrossUp AS DECIMAL (10,2)) AS [GrossedAmt], " _
                & "CAST(PaymentsHistory.PAYE AS DECIMAL (10,2)) AS [PAYE], " _
                & "CAST(PaymentsHistory.AidsLevy AS DECIMAL (10,2)) AS [AidsLevy], " _
                & "CAST(PaymentsHistory.Deductions AS DECIMAL (10,2)) AS [Deductions], " _
                & "UPPER(REPLACE(CONVERT(NVARCHAR(11), PaymentsHistory.OriginalTransDate, 106), ' ', '-')) AS TDate, " _
                & "PaymentsHistory.Description AS Description FROM PaymentsHistory " _
                & "WHERE (PaymentsHistory.DirectorId = " & DirectorId & ") " _
                & "AND PaymentsHistory.OriginalTransDate BETWEEN '" & StartDate & "' AND '" & EndDate & "' " _
                & "ORDER BY PaymentsHistory.OriginalTransDate"
        Else
            strSqlTransactions = "SELECT RunFile.DirectorId, RunFile.CodeId, RunFile.Amount, " _
                & "CAST(RunFile.GrossUp AS DECIMAL (10,2)) AS [GrossedAmt], " _
                & "CAST(RunFile.PAYE AS DECIMAL (10,2)) AS [PAYE], " _
                & "CAST(RunFile.AidsLevy AS DECIMAL (10,2)) AS [AidsLevy], " _
                & "CAST(RunFile.Deductions AS DECIMAL (10,2)) AS [Deductions], " _
                & "UPPER(REPLACE(CONVERT(NVARCHAR(11), RunFile.OriginalTransDate, 106), ' ', '-')) AS TDate, " _
                & "RunFile.Description AS Description FROM RunFile " _
                & "WHERE (RunFile.DirectorId = " & DirectorId & ") ORDER BY RunFile.OriginalTransDate"
        End If

        'Get the customer details
        sPrintDate = strStatementDate
        objCommand = New Data.OleDb.OleDbCommand(strSqlMain, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read()
            'If Not IsDBNull(objReader(0).ToString) Then sPrintDate = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then sCustomerName = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then sCustomerAddress1 = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then sCustomerAddress2 = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then sCustomerAddress3 = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then sCustomerAddress4 = objReader(5).ToString
            If Not IsDBNull(objReader("BankCode").ToString) Then sCustomerBankCode = objReader("BankCode").ToString
            If Not IsDBNull(objReader("BankAccountNumber").ToString) Then sCustomerBankAccount = objReader("BankAccountNumber").ToString
            If Not IsDBNull(objReader(8).ToString) Then sCustomerVatNumber = objReader(8).ToString
            Exit While
        End While
        objReader.Close()

        'Get the transactions
        objCommand = New Data.OleDb.OleDbCommand(strSqlTransactions, cnn)
        objReader = objCommand.ExecuteReader

        'Declare and initialize the print details
        Dim arrPrintDetails As New ArrayList
        Dim intFields As Integer = 7 'objReader.FieldCount

        Dim dblGrossTotal As Double = 0
        Dim dblTotalBoardTaxes As Double = 0
        Dim dblTotalPaye As Double = 0
        Dim dblTotalAidsLevy As Double = 0

        Dim dblTotalNet As Double = 0

        '************** NEW CODE ********************************

        While objReader.Read

            'Get the purpose
            Dim strPurpose As String = Nothing
            objCommand = New Data.OleDb.OleDbCommand("SELECT Payments.Purpose FROM Payments WHERE " _
                & "Payments.TransDate = '" & objReader("TDate").ToString & "' AND Payments.PayCode " _
                & "= " & objReader("CodeId").ToString & " AND Payments.Amount = " & objReader("Amount").ToString & " " _
                & "AND Payments.DirectorId = " & objReader("DirectorId").ToString & "", cnn)
            Dim objReadPurpose As OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReadPurpose.Read
                If Not IsDBNull(objReadPurpose(0).ToString) Then strPurpose = objReadPurpose(0).ToString
                Exit While
            End While
            objReadPurpose.Close()

            arrPrintDetails.Add(objReader("TDate").ToString & "|" & objReader("Description").ToString & ": " & strPurpose & "|" & _
                Format(CLng(objReader("GrossedAmt").ToString), "##0.00") & "|" & _
                Format(CLng(objReader("Deductions").ToString), "##0.00") & "|" & _
                Format(CLng(objReader("PAYE").ToString), "##0.00") & "|" & _
                Format(CLng(objReader("AidsLevy").ToString), "##0.00") & "|" & _
                Format((CLng(objReader("GrossedAmt").ToString) - _
                        (CLng(objReader("Deductions").ToString) + CLng(objReader("Paye").ToString) + CLng(objReader("AidsLevy").ToString))), "##0.00"))
            dblGrossTotal = dblGrossTotal + CLng(objReader("GrossedAmt").ToString)
            dblTotalBoardTaxes = dblTotalBoardTaxes + CLng(objReader("Deductions").ToString)
            dblTotalPaye = dblTotalPaye + CLng(objReader("Paye").ToString)
            dblTotalAidsLevy = dblTotalAidsLevy + CLng(objReader("AidsLevy").ToString)
            dblTotalNet = dblTotalNet + (CLng(objReader("GrossedAmt").ToString) - _
                (CLng(objReader("Deductions").ToString) + CLng(objReader("Paye").ToString) + CLng(objReader("AidsLevy").ToString)))

        End While
        objReader.Close()


        'If historical print, read the current run file data as well
        If UCase(StatementType) = "HISTORICAL" Then
            strSqlTransactions = "SELECT RunFile.DirectorId, RunFile.CodeId, RunFile.Amount, " _
                    & "CAST(RunFile.GrossUp AS DECIMAL (10,2)) AS [GrossedAmt], " _
                    & "CAST(RunFile.PAYE AS DECIMAL (10,2)) AS [PAYE], " _
                    & "CAST(RunFile.AidsLevy AS DECIMAL (10,2)) AS [AidsLevy], " _
                    & "CAST(RunFile.Deductions AS DECIMAL (10,2)) AS [Deductions], " _
                    & "UPPER(REPLACE(CONVERT(NVARCHAR(11), RunFile.OriginalTransDate, 106), ' ', '-')) AS TDate, " _
                    & "RunFile.Description AS Description FROM RunFile " _
                    & "WHERE (RunFile.DirectorId = " & DirectorId & ") AND RunFile.OriginalTransDate BETWEEN '" & StartDate & "' AND '" & EndDate & "' " _
                    & "ORDER BY RunFile.OriginalTransDate"
            objCommand = New Data.OleDb.OleDbCommand(strSqlTransactions, cnn)
            objReader = objCommand.ExecuteReader

            While objReader.Read

                'Get the purpose
                Dim strPurpose As String = Nothing
                objCommand = New Data.OleDb.OleDbCommand("SELECT Payments.Purpose FROM Payments WHERE " _
                    & "Payments.TransDate = '" & objReader("TDate").ToString & "' AND Payments.PayCode " _
                    & "= " & objReader("CodeId").ToString & " AND Payments.Amount = " & objReader("Amount").ToString & " " _
                    & "AND Payments.DirectorId = " & objReader("DirectorId").ToString & "", cnn)
                Dim objReadPurpose As OleDb.OleDbDataReader = objCommand.ExecuteReader
                While objReadPurpose.Read
                    If Not IsDBNull(objReadPurpose(0).ToString) Then strPurpose = objReadPurpose(0).ToString
                    Exit While
                End While
                objReadPurpose.Close()

                arrPrintDetails.Add(objReader("TDate").ToString & "|" & objReader("Description").ToString & ": " & strPurpose & "|" & _
                    Format(CLng(objReader("GrossedAmt").ToString), "##0.00") & "|" & _
                    Format(CLng(objReader("Deductions").ToString), "##0.00") & "|" & _
                    Format(CLng(objReader("PAYE").ToString), "##0.00") & "|" & _
                    Format(CLng(objReader("AidsLevy").ToString), "##0.00") & "|" & _
                    Format((CLng(objReader("GrossedAmt").ToString) - _
                            (CLng(objReader("Deductions").ToString) + CLng(objReader("Paye").ToString) + CLng(objReader("AidsLevy").ToString))), "##0.00"))
                dblGrossTotal = dblGrossTotal + CLng(objReader("GrossedAmt").ToString)
                dblTotalBoardTaxes = dblTotalBoardTaxes + CLng(objReader("Deductions").ToString)
                dblTotalPaye = dblTotalPaye + CLng(objReader("Paye").ToString)
                dblTotalAidsLevy = dblTotalAidsLevy + CLng(objReader("AidsLevy").ToString)
                dblTotalNet = dblTotalNet + (CLng(objReader("GrossedAmt").ToString) - _
                    (CLng(objReader("Deductions").ToString) + CLng(objReader("Paye").ToString) + CLng(objReader("AidsLevy").ToString)))
            End While
            objReader.Close()
            arrPrintDetails.Sort()
        End If


        ' ''While objReader.Read
        ' ''    Dim strItems As String = Nothing
        ' ''    For i As Integer = 0 To objReader.FieldCount - 1
        ' ''        strItems = strItems & objReader(i) & "|"
        ' ''        Select Case i
        ' ''            Case Is = 6
        ' ''                dblTotalNet = dblTotalNet + CDbl(objReader(i).ToString)
        ' ''            Case Is = 5
        ' ''                dblTotalAidsLevy = dblTotalAidsLevy + CDbl(objReader(i).ToString)
        ' ''            Case Is = 4
        ' ''                dblTotalPaye = dblTotalPaye + CDbl(objReader(i).ToString)
        ' ''            Case Is = 3
        ' ''                dblTotalBoardTaxes = dblTotalBoardTaxes + CDbl(objReader(i).ToString)
        ' ''            Case Is = 2
        ' ''                dblGrossTotal = dblGrossTotal + CDbl(objReader(i).ToString)
        ' ''        End Select

        ' ''    Next


        ' ''    strItems = Mid(strItems, 1, (strItems.Length - 1))
        ' ''    arrPrintDetails.Add(strItems)
        ' ''End While
        ' ''objReader.Close()

        '' ''Correct the array before sending to the printing
        ' ''dblTotalBoardTaxes = 0 : dblTotalNet = 0
        ' ''For i As Integer = 0 To arrPrintDetails.Count - 1
        ' ''    Dim strBuffer() As String = Split(arrPrintDetails.Item(i), "|")
        ' ''    Dim dblGrossT As Double = 0
        ' ''    Dim dblDedsT As Double = 0
        ' ''    Dim dblPayeT As Double = 0
        ' ''    Dim dblAidsT As Double = 0
        ' ''    Dim dblTot As Double = 0

        ' ''    If IsNumeric(strBuffer(2)) Then dblGrossT = CDbl(strBuffer(2))
        ' ''    If IsNumeric(strBuffer(3)) Then dblDedsT = CDbl(strBuffer(3))
        ' ''    If IsNumeric(strBuffer(4)) Then dblPayeT = CDbl(strBuffer(4))
        ' ''    If IsNumeric(strBuffer(5)) Then dblAidsT = CDbl(strBuffer(5))
        ' ''    If IsNumeric(strBuffer(6)) Then dblTot = CDbl(strBuffer(6))

        ' ''    If dblTot <> 0 Then dblDedsT = dblGrossT - (dblPayeT + dblAidsT + dblTot)
        ' ''    If dblDedsT < 1 Then dblDedsT = 0
        ' ''    If dblDedsT > 1 Then
        ' ''        dblTot = 0 - dblDedsT
        ' ''    End If
        ' ''    arrPrintDetails.Item(i) = strBuffer(0) & "|" & strBuffer(1) & "|" & Format(dblGrossT, "##0.00") & "|" & Format(dblDedsT, "##0.00") & "|" & Format(dblPayeT, "##0.00") & "|" & Format(dblAidsT, "##0.00") & "|" & Format(dblTot, "##0.00")
        ' ''    dblTotalBoardTaxes = dblTotalBoardTaxes + dblDedsT
        ' ''    dblTotalNet = dblTotalNet + dblTot
        ' ''Next


        'Send the details to the document printing class
        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        Dim docPrint As New DocumentWriter
        With docPrint
            .intNumberOfColumns = intFields
            .intPrintRecordsCount = strPrintDetails.Length
            .strMainCaption = UCase("STATEMENT OF EARNINGS")
            .PrintBankingDetails = True
            .CustomerName = sCustomerName
            .CustomerAddress1 = sCustomerAddress1
            .CustomerAddress2 = sCustomerAddress2
            .CustomerAddress3 = sCustomerAddress3
            .CustomerAddress4 = sCustomerAddress4
            .CustomerTelephone = sCustomerTelephone
            .CustomerEmailAddress = Nothing
            .CustomerVatNumber = sCustomerVatNumber
            .TaxesCharged = 0
            .DocumentTotal = 0
            .DiscountAllowed = 0
            .strColumnAlignments = "0|0|2|2|2|2|2"

            .PrintDate = sPrintDate

            .ReferenceNumber = DirectorId
            .SalesRep = sAgent
            .strPrintValues = strPrintDetails
            .strColumnHeaders = "DATE|DESCRIPTION|GROSS|DEDUCTION|PAYE|AIDS LVY|PAYABLE"
            .boolGenericReport = True
            '.PrintBankingDetails = False
            .PrintSummaryTotals = True
            .DetailColor = Color.FromName("Black")
            .GridColor = Color.LightGray
            .strColumnWidths = "90|205|70|70|70|70|70"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"

            'Remember to carter for the notes printing
            .strSummaryCaptions = "GROSS TOTAL|DEDUCTIONS|PAYE|AIDS LVY|NET PAYABLE"
            .strSummaryValues = Format(CLng(dblGrossTotal), "#0.00") & "|" & Format(CLng(dblTotalBoardTaxes), "#0.00") _
                & "|" & Format(CLng(dblTotalPaye), "#0.00") & "|" & Format(CLng(dblTotalAidsLevy), "#0.00") _
                & "|" & Format(CLng(dblTotalNet), "#0.00")
            .strSummaryAlignments = "2|2|2|2|2"

            .DocumentNotes = sComment
        End With

        If ViewMode = True Then
            If strRequestForReceiptPrinter = "YES" Then
                Dim f As New frmPrinterSetup
                f.ShowDialog()
                docPrint.PrinterSettings.PrinterName = strSessionPrinter
            End If
        End If

        Dim ppd As New PrintPreviewDialog
        ppd.Document = docPrint
        If ViewMode = True Then
            ppd.ShowDialog()
        Else
            docPrint.Print()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Director Statement Print"
        ShowErrorMessage()
    End Sub

    Public Function GrossUpFactor(DirectorId As Integer) As Double
        Dim dblReturn As Double = 0
        If DirectorId = 14 Then
            MsgBox("Here")
        End If
        Dim strSql As String = "SELECT SUM(Payments.Amount), Payments.PayCode, " _
            & "PaymentCodes.Description, PaymentCodes.PayType, PaymentCodes.TaxType, Payments.TransDate, PaymentCodes.GrossUpStatus FROM Payments " _
            & "LEFT OUTER JOIN PaymentCodes ON PaymentCodes.CodeNo = Payments.PayCode WHERE " _
            & "Payments.DirectorId = " & DirectorId & " AND Payments.Status = 'PENDING' " _
            & "GROUP BY Payments.Amount, Payments.PayCode, PaymentCodes.Description, PaymentCodes.PayType, " _
            & "PaymentCodes.TaxType, Payments.TransDate, PaymentCodes.GrossUpStatus"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim dblCurrentTaxableIncome As Double = 0

        While objReader.Read
            If IsNumeric(objReader(0).ToString) Then
                'Add taxable income
                If UCase(objReader("GrossUpStatus").ToString) = UCase("Y") Then
                    If UCase(objReader(4).ToString) = "YNM" Or UCase(objReader(4).ToString) = "Y20" Then
                        dblCurrentTaxableIncome = dblCurrentTaxableIncome + CDbl(objReader(0).ToString)
                    End If
                End If
            End If
        End While
        objReader.Close()

        'Compute the rate after the tax computation
        '' ********* Dim dblCurrentTax As Double = TaxTables(dblCurrentTaxableIncome)
        'dblReturn = (dblCurrentTax + dblBaseCredit) / dblEmployeeTaxRate
        dblReturn = dblCurrentTaxableIncome

        Return dblReturn
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On computing the gross up factor"
        ShowErrorMessage()
    End Function

End Module
