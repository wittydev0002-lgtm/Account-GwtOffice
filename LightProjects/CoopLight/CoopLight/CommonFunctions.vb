Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module CommonFunctions

    Public gwt_comm As CommonLibrary.Commons.CommonFunctions
    Public strBillingMethod As String
    Public sCustomerBankCode As String
    Public sCustomerBankAccount As String

    Public Sub ShowErrorMessage()
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Function StatementBalances(ByVal MemberNumber As String, ByVal StartingDate As Date) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList

        Dim arrDetailsToRead As New ArrayList

        'Get the property balance
        Dim dblPropertyValue As Double = 0
        Dim objPropValue As New Data.OleDb.OleDbCommand("SELECT Capital FROM BM_Master " _
            & "WHERE PolicyNumber = '" & MemberNumber & "'", cnn)
        Dim objReadValue As Data.OleDb.OleDbDataReader = objPropValue.ExecuteReader
        If objReadValue.HasRows Then
            objReadValue.Read()
            If IsNumeric(objReadValue(0).ToString) Then dblPropertyValue = CDbl(objReadValue(0).ToString)
        End If
        objReadValue.Close()

        'Get the balances before the starting date
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "Description, Reference, PeriodMonth AS [Month], PeriodYear AS [Year], " _
            & "CAST(Amount AS DECIMAL (10,2)) AS [Billed Amount], CAST(CapitalPayment AS DECIMAL (10,2)) as [Prop. Amt], " _
            & "CAST(AdminFees AS DECIMAL (10,2)) AS [Admin. Fee], CAST(InterestsCharged AS DECIMAL (10,2)) AS [Int.], " _
            & "CAST(InterestsPaid AS DECIMAL (10,2)) AS [Int. Pd], TransactionId FROM BM_Financials " _
            & "WHERE PolicyNumber = '" & MemberNumber & "' AND " _
            & "TransactionDate < '" & StartingDate & "' ORDER BY TransactionDate, TransactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim dblRunningBalance As Double = 0
        Dim dblRunningInterest As Double = 0
        While objReader.Read
            dblPropertyValue = dblPropertyValue - (CDbl(objReader(6).ToString))
            dblRunningInterest = dblRunningInterest + CDbl(objReader(8).ToString) - CDbl(objReader(9).ToString)

            dblRunningBalance = dblRunningBalance + (CDbl(objReader(5).ToString) - ((CDbl(objReader(6).ToString) + CDbl(objReader(7).ToString))))

            Dim dblInterestPlusBalance As Double = dblRunningBalance + dblRunningInterest

            arrDetailsToRead.Add(objReader(0) & "|" & objReader(1) & "|" & objReader(2) & "|" & _
                objReader(3) & "|" & objReader(4) & "|" & objReader(5) & "|" & _
                Format((CDbl(objReader(6).ToString) + CDbl(objReader(7).ToString) + CDbl(objReader(9).ToString)), "##0.00") & "|" & _
                objReader(9) & "|" & objReader(7) & "|" & objReader(6) & "|" & Format(dblRunningBalance, "##0.00") & "|" & _
                Format(CDbl(objReader(8).ToString), "##0.00") & "|" & Format(dblInterestPlusBalance, "##0.00") & "|" & _
                Format(dblPropertyValue, "##0.00") & "|" & objReader(10))
        End While
        objReader.Close()

        If arrDetailsToRead.Count > 0 Then
            Dim strLastLine As String = arrDetailsToRead.Item(arrDetailsToRead.Count - 1)
            Dim strBuffer() As String = Split(strLastLine, "|")
            arrReturn.Add(strBuffer(12))
            arrReturn.Add(strBuffer(13))
        Else
            arrReturn.Add("0.00")
            arrReturn.Add(Format(dblPropertyValue, "##0.00"))
        End If
        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On statement print balances fetch"
        ShowErrorMessage()
    End Function

    Public Function StatementPrintDetails(ByVal MemberNumber As String, ByVal StartingDate As Date, _
            ByVal EndingDate As Date, ByVal OpeningPropertyValue As Double) As ArrayList

        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList
        Dim arrDetailsToRead As New ArrayList

        Dim dblPropertyValue As Double = OpeningPropertyValue

        'Get the balances before the starting date
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "Description, Reference, PeriodMonth AS [Month], PeriodYear AS [Year], " _
            & "CAST(Amount AS DECIMAL (10,2)) AS [Billed Amount], CAST(CapitalPayment AS DECIMAL (10,2)) as [Prop. Amt], " _
            & "CAST(AdminFees AS DECIMAL (10,2)) AS [Admin. Fee], CAST(InterestsCharged AS DECIMAL (10,2)) AS [Int.], " _
            & "CAST(InterestsPaid AS DECIMAL (10,2)) AS [Int. Pd], TransactionId FROM BM_Financials " _
            & "WHERE PolicyNumber = '" & MemberNumber & "' ORDER BY TransactionDate, TransactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim dblRunningBalance As Double = 0
        Dim dblRunningInterest As Double = 0
        While objReader.Read
            dblPropertyValue = dblPropertyValue - (CDbl(objReader(6).ToString))
            dblRunningInterest = dblRunningInterest + CDbl(objReader(8).ToString) - CDbl(objReader(9).ToString)

            dblRunningBalance = dblRunningBalance + (CDbl(objReader(5).ToString) - ((CDbl(objReader(6).ToString) + CDbl(objReader(7).ToString))))

            Dim dblInterestPlusBalance As Double = dblRunningBalance + dblRunningInterest

            arrDetailsToRead.Add(objReader(0) & "|" & objReader(1) & "|" & objReader(2) & "|" & _
                objReader(3) & "|" & objReader(4) & "|" & objReader(5) & "|" & _
                Format((CDbl(objReader(6).ToString) + CDbl(objReader(7).ToString) + CDbl(objReader(9).ToString)), "##0.00") & "|" & _
                objReader(9) & "|" & objReader(7) & "|" & objReader(6) & "|" & Format(dblRunningBalance, "##0.00") & "|" & _
                Format(CDbl(objReader(8).ToString), "##0.00") & "|" & Format(dblInterestPlusBalance, "##0.00") & "|" & _
                Format(dblPropertyValue, "##0.00") & "|" & objReader(10))
        End While
        objReader.Close()

        For p As Integer = 0 To arrDetailsToRead.Count - 1
            Dim strBuffer() As String = Split(arrDetailsToRead.Item(p), "|")
            If IsDate(strBuffer(0)) Then
                If CDate(strBuffer(0)) >= CDate(Format(StartingDate, "dd-MMM-yyyy")) Then
                    If CDate(strBuffer(0)) <= CDate(Format(EndingDate, "dd-MMM-yyyy")) Then
                        arrReturn.Add(arrDetailsToRead.Item(p))
                    End If
                End If
            End If
        Next

        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On statement print details fetch"
        ShowErrorMessage()
    End Function
End Module