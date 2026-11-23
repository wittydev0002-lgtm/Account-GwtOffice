Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module CommonFunctions

    Public gwt_comm As CommonLibrary.Commons.CommonFunctions

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

End Module
