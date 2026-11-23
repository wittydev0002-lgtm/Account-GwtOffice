Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module CommonFunctions

    Public gwt_comm As CommonLibrary.Commons.CommonFunctions
    Public strAddedActionName As String
    Public intSelectedStageId As Integer
    Public strSpecialKeysId As String

    Dim strRootAction As String = Nothing

    Public strGridHeaders As String
    Public arrRetriedData As ArrayList

    Public intSelectedKeyAnalysisIndex As Integer
    Public strSelectedPortfolioAnalysisId As Integer
    Public strSelectedPortfolioAnalysisStageName As String

    Public Sub ShowErrorMessage()
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Sub InitializeTransactions(ByVal AccountType As String, ByVal RecordId As String, _
        ByVal TransactionDate As Date, ByVal Debit As Double, ByVal Credit As Double, _
        Optional ByVal Description As String = Nothing, Optional ByVal Comment As String = Nothing, _
        Optional Reference As String = Nothing, Optional FileId As String = Nothing, Optional ReceiptNumber As Integer = 0)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        If UCase(AccountType) = "DEFENDANTS" Then
            strSql = "INSERT INTO DefendantTransactions " _
                & "(TransactionDate, Description, ReferenceNumber, Debit, Credit, Comments, DefendantId, FileId, ReceiptNumber) VALUES " _
                & "('" & TransactionDate & "', '" & Description & "', '" & Reference & "', " & Debit & ", " & Credit & ", " _
                & "'" & Comment & "', '" & RecordId & "', '" & FileId & "', " & ReceiptNumber & ")"
        Else
            strSql = "INSERT INTO PlaintifTransactions " _
                & "(TransactionDate, Description, ReferenceNumber, Debit, Credit, Comments, Plaintif, FileId) VALUES " _
                & "('" & TransactionDate & "', '" & Description & "', '" & Reference & "', " & Debit & ", " & Credit & ", " _
                & "'" & Comment & "', '" & RecordId & "', '" & FileId & "')"
        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Account Initialization"
        ShowErrorMessage()
    End Sub

    Public Sub PostTransactions(ByVal AccountType As String, ByVal RecordId As String,
            ByVal TransactionDate As Date, ByVal Amount As Double, ByVal TransactionType As String,
            ByVal Description As String, Optional ByVal Reference As String = Nothing, _
            Optional ByVal Comments As String = Nothing, Optional ByVal DocumentNumber As Integer = 0, Optional ByVal ReceivedBy As String = "OUR COMPANY")
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        If UCase(TransactionType) = "EXPENSES" Then
            If UCase(AccountType) = "DEFENDANTS" Then
                strSql = "INSERT INTO DefendantTransactions " _
                    & "(TransactionDate, Description, ReferenceNumber, Debit, Credit, Comments, DefendantId, ReceiptNumber, ReceivedBy) VALUES " _
                    & "('" & TransactionDate & "', '" & Description & "', '" & Reference & "', " & Amount & ", 0, " _
                    & "'" & Comments & "', '" & RecordId & "', " & DocumentNumber & ", '" & ReceivedBy & "')"
            Else
                strSql = "INSERT INTO PlaintifTransactions " _
                    & "(TransactionDate, Description, ReferenceNumber, Debit, Credit, Comments, Plaintif, ReceiptNumber, ReceivedBy) VALUES " _
                    & "('" & TransactionDate & "', '" & Description & "', '" & Reference & "', " & Amount & ", 0, " _
                    & "'" & Comments & "', '" & RecordId & "', " & DocumentNumber & ", '" & ReceivedBy & "')"
            End If
        Else
            If UCase(AccountType) = "DEFENDANTS" Then
                strSql = "INSERT INTO DefendantTransactions " _
                    & "(TransactionDate, Description, ReferenceNumber, Debit, Credit, Comments, DefendantId, ReceiptNumber, ReceivedBy) VALUES " _
                    & "('" & TransactionDate & "', '" & Description & "', '" & Reference & "', 0, " & Amount & ", " _
                    & "'" & Comments & "', '" & RecordId & "', " & DocumentNumber & ", '" & ReceivedBy & "')"
            Else
                strSql = "INSERT INTO PlaintifTransactions " _
                    & "(TransactionDate, Description, ReferenceNumber, Debit, Credit, Comments, Plaintif, ReceiptNumber, ReceivedBy) VALUES " _
                    & "('" & TransactionDate & "', '" & Description & "', '" & Reference & "', 0, " & Amount & ", " _
                    & "'" & Comments & "', '" & RecordId & "', " & DocumentNumber & ", '" & ReceivedBy & "')"
            End If
        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Transaction Posting"
        ShowErrorMessage()
    End Sub

    Public Function GetPlaintifBalance(ByVal DefendantId As String, ByVal CutOffDate As Date, ByVal BalanceType As String) As Double
        On Error GoTo RaiseErr
        Dim dblReturn As Double = 0

        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Legal Transactions Balance Computation"
        ShowErrorMessage()
    End Function

    Public Function GetDefendantBalance(ByVal DefendantId As String, ByVal CutOffDate As Date, ByVal BalanceType As String) As Double
        On Error GoTo RaiseErr
        Dim dblReturn As Double = 0
        Dim strSql As String = Nothing

        If UCase(BalanceType) = "ALL" Then
            strSql = "SELECT (SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance] " _
                & "FROM DefendantTransactions WHERE DefendantTransactions.DefendantId = '" & DefendantId & "' " _
                & "AND DefendantTransactions.TransactionDate < '" & CutOffDate & "'"
        Else
            strSql = "SELECT (SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance] " _
                & "FROM DefendantTransactions WHERE DefendantTransactions.DefendantId = '" & DefendantId & "' " _
                & "AND DefendantTransactions.TransactionDate < '" & CutOffDate & "'" '_
            '& "AND (" & strPublicLegalCostDescriptions & ")"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblReturn = CDbl(objReader(0).ToString)
        End If
        objReader.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Legal Transactions Balance Computation"
        ShowErrorMessage()
    End Function

    Public Function TransactionTotals(ByVal DefendantId As String, ByVal CutOffDate As Date, ByVal BalanceType As String) As Double
        On Error GoTo RaiseErr
        Dim dblReturn As Double = 0
        Dim strSql As String = Nothing

        If UCase(BalanceType) = "ALL" Then
            strSql = "SELECT SUM(DefendantTransactions.Debit), SUM(DefendantTransactions.Credit) " _
                & "FROM DefendantTransactions WHERE DefendantTransactions.DefendantId = '" & DefendantId & "' " _
                & "AND DefendantTransactions.TransactionDate < '" & CutOffDate & "'"
        Else
            strSql = "SELECT SUM(DefendantTransactions.Debit), SUM(DefendantTransactions.Credit) " _
                & "FROM DefendantTransactions WHERE DefendantTransactions.DefendantId = '" & DefendantId & "' " _
                & "AND DefendantTransactions.TransactionDate < '" & CutOffDate & "' " _
                & "AND (" & strPublicLegalCostDescriptions & ")"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If CDbl(objReader(0).ToString) > CDbl(objReader(1).ToString) Then
                dblReturn = CDbl(objReader(0).ToString)
            Else
                dblReturn = CDbl(objReader(1).ToString)
            End If
        End If
        objReader.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Legal Transactions Totals Computation"
        ShowErrorMessage()
    End Function

    Public Function checkBold(ByVal varString As String, ByVal startFont As Font) As String(,)
        Dim aryString As String(,)
        ReDim aryString(3, 1)
        Dim printStyle As FontStyle = FontStyle.Regular
        Dim varStartPlace As Integer = -1
        aryString(0, 0) = "" 'initialize the array to avoid errors
        aryString(1, 0) = printStyle
        aryString(2, 0) = varStartPlace
        Dim varPlace As Integer = 0
        For varPlace = 1 To varString.Length
            If Mid(varString, varPlace, 3) = "<B>" Then
                printStyle = FontStyle.Bold
                varPlace += 2
            ElseIf Mid(varString, varPlace, 4) = "</B>" Then
                printStyle = FontStyle.Regular
                varPlace += 3
            ElseIf Mid(varString, varPlace, 4) = "<ST=" Then
                varStartPlace = CInt(Mid(varString, varPlace + 4, _
                     InStr(varPlace + 4, varString, ">") - (varPlace + 4)))
                varPlace += 4 + varStartPlace.ToString.Length
            Else
                ReDim Preserve aryString(3, aryString.GetUpperBound(1) + 1)
                aryString(0, aryString.GetUpperBound(1) - 1) = Mid(varString, varPlace, 1)
                aryString(1, aryString.GetUpperBound(1) - 1) = printStyle
                aryString(2, aryString.GetUpperBound(1) - 1) = varStartPlace
                varStartPlace = -1
            End If
        Next
        checkBold = aryString
    End Function

    Public Sub UpdateActionsTable(ByVal DefendantId As String, PlaintifId As String)
        On Error GoTo RaiseErr
        'SET EVERY ONE OF THE RECORDS TO PAST FIRST
        Dim objCommand = New Data.OleDb.OleDbCommand("UPDATE LegalActions SET Status = 'PAST' " _
                & "WHERE DefendantId = '" & DefendantId & "'", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("SELECT ActionDate, TransactionId " _
            & "FROM LegalActions WHERE DefendantId = '" & DefendantId & "' ORDER BY TransactionDate DESC", cnn)
        Dim objReadDates As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReadDates.HasRows Then
            objReadDates.Read()
            objCommand = New Data.OleDb.OleDbCommand("UPDATE LegalActions SET Status = 'CURRENT' " _
                & "WHERE TransactionId = " & objReadDates(1).ToString & "", cnn)
            objCommand.ExecuteNonQuery()
            'Update plaintifid
            objCommand = New Data.OleDb.OleDbCommand("UPDATE LegalActions SET PlaintifId = '" & PlaintifId & "' " _
                & "WHERE DefendantId = '" & DefendantId & "'", cnn)
            objCommand.ExecuteNonQuery()
        End If
        objReadDates.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On case status tables update"
        ShowErrorMessage()
    End Sub

    Public Function GetDefendantPlaintif(ByVal DefendantId As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT PlaintifId FROM Defendants WHERE DefendantId = '" & DefendantId & "'", cnn)
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
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Legal Defendant Plaintif ID Fetch"
        ShowErrorMessage()
    End Function

    Public Function MatterSummaryStatus(FileId As String) As ArrayList
        Dim arrRetun As New ArrayList From {"", "", "0", "0", "0", "0"}
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), " _
            & "LegalTimeEntries.TransactionDate, 106), ' ', '-')) as [Date], LegalTimeEntries.WorkDone FROM LegalTimeEntries " _
            & "WHERE FileId = '" & FileId & "' AND LegalTimeEntries.TransactionDate IN " _
            & "(SELECT MAX(LegalTimeEntries.TransactionDate) FROM LegalTimeEntries WHERE FileId = '" & FileId & "')"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsDate(objReader(0).ToString) Then arrRetun.Item(0) = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then arrRetun.Item(1) = objReader(1).ToString
        End If
        objReader.Close()

        'Assign the balances
        strSql = "SELECT SUM(Costing), SUM(Paid), SUM(Costing - Paid) FROM LegalTimeEntries WHERE FileId = '" & FileId & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then arrRetun.Item(2) = objReader(0).ToString
            If IsNumeric(objReader(1).ToString) Then arrRetun.Item(3) = objReader(1).ToString
            If IsNumeric(objReader(2).ToString) Then arrRetun.Item(4) = objReader(2).ToString
        End If
        objReader.Close()

        'Get the date when last Paid
        strSql = "SELECT MAX(LegalTimeEntries.TransactionDate) FROM LegalTimeEntries " _
            & "WHERE FileId = '" & FileId & "' AND Paid <> 0"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        Dim intDaysLastPaid As Integer = 0
        If objReader.HasRows Then
            objReader.Read()
            If IsDate(objReader(0).ToString) Then
                intDaysLastPaid = DateDiff(DateInterval.Day, CDate(objReader(0).ToString), Now)
            End If
        End If
        objReader.Close()
        arrRetun.Item(5) = intDaysLastPaid
        Return arrRetun
        Exit Function
RaiseErr:
        boolAbort = True
        Return arrRetun
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Matters Status Details Fetch"
        ShowErrorMessage()
    End Function

    Public Function CurrentStagging(ByVal DefendantId As String) As String
        On Error GoTo RaiseErr

        strRootAction = Nothing
        Dim strReturn As String = Nothing

        Dim strSql As String = "SELECT ActionKey FROM LegalActions a " _
            & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b WHERE a.DefendantId = b.DefendantId) " _
            & "AND a.DefendantId = '" & DefendantId & "'"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        If objReader.HasRows Then
            objReader.Read()
            Dim strProcess As String = Nothing
            Dim strAction As String = Nothing
            Dim objComAction As New Data.OleDb.OleDbCommand("SELECT ActionName FROM ProdedureAndActions " _
                & "WHERE ProcedureId = " & objReader("ActionKey").ToString & "", cnn)
            Dim objReadAction As Data.OleDb.OleDbDataReader = objComAction.ExecuteReader
            If objReadAction.HasRows Then
                objReadAction.Read()
                If Not IsDBNull(objReadAction(0).ToString) Then
                    If Not String.IsNullOrEmpty(objReadAction(0).ToString) Then
                        strAction = objReadAction(0).ToString
                    End If
                End If
            End If
            objReadAction.Close()
            MainAction(CInt(objReader("ActionKey").ToString))
            If Not String.IsNullOrEmpty(strRootAction) Then
                strProcess = strRootAction
            Else
                strProcess = strAction
            End If
            strReturn = UCase(strProcess) & "-->" & UCase(strAction)
        End If

        objReader.Close()

        Return strReturn

        Exit Function
RaiseErr:
        boolAbort = True
        Return strReturn
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Current Action Get"
        ShowErrorMessage()
    End Function

    Private Sub MainAction(ProcedureId As Integer)
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SubActionOf, ActionName FROM ProdedureAndActions " _
            & "WHERE ProcedureId = " & ProcedureId & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(1).ToString) Then
                If Not String.IsNullOrEmpty(objReader(1).ToString) Then
                    strRootAction = objReader(1).ToString
                End If
            End If
            MainAction(objReader(0).ToString)
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Current Action Parent Get"
        ShowErrorMessage()
    End Sub

    Public Function CheckActionStatus(ActionKey As Integer, DefendantId As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim strSql As String = "SELECT [ActionKey] FROM LegalActions WHERE " _
            & "DefendantId = '" & DefendantId & "' AND ActionKey = '" & ActionKey & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            boolReturn = True
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Status Update"
        ShowErrorMessage()
    End Function

    Public Function GetActionCost(ByVal ProcedureId As Integer, ByVal PortfolioId As String) As Double
        Dim dblReturn As Double = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Cost FROM LegalPortfolioCosts " _
            & "WHERE ActionKey = " & ProcedureId & " AND PlaintifId = '" & PortfolioId & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If IsNumeric(objReader(0).ToString) Then
                    dblReturn = CDbl(objReader(0).ToString)
                End If
            End If
        End If
        objReader.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Return dblReturn
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Action Cost Fetch"
        ShowErrorMessage()
    End Function

    Public Function GetPlaintifId(ByVal DebtorNumber As String) As String
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT PlaintifId FROM Defendants " _
            & "WHERE DefendantId = '" & DebtorNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    strReturn = CDbl(objReader(0).ToString)
                End If
            End If
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Return strReturn
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Plaintif ID Fetch"
        ShowErrorMessage()
    End Function
End Module
