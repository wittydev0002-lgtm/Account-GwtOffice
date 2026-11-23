Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmExpensesView

    Private Sub frmExpensesView_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadInformation()
    End Sub

    Private Sub LoadInformation()
        On Error GoTo RaiseErr

        boolAbort = False
        Dim arrDetailsToShow As New ArrayList
        arrDetailsToShow = CellDetails()
        If boolAbort = True Then Exit Sub
        Dim dblTotal As Double = 0
        dGridDetails.Rows.Clear()
        For i As Integer = 0 To arrDetailsToShow.Count - 1
            Dim strBuffer() As String = Split(arrDetailsToShow.Item(i), "|")
            If IsNumeric(strBuffer(2)) Then dblTotal = dblTotal + CDbl(strBuffer(2))
            dGridDetails.Rows.Add(strBuffer(0), strBuffer(1), strBuffer(2))
        Next
        'Add the totals row at end
        'dGridDetails.Rows.Add("TOTAL", " ", Format(dblTotal, "##0.00"))
        lblTotal.Text = Format(dblTotal, "##0.00")
        pnlDetails.Visible = True
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Expenses Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function CellDetails() As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList
        Dim strSql As String = "SELECT Description, TransactionType, " _
            & "CAST(Amount AS DECIMAL (10,2)) AS [Amt] FROM LedgerTransactions WHERE " _
            & "TransactionDate BETWEEN '" & Format(StartDate, "dd-MMM-yyyy") & "' AND " _
            & "'" & Format(EndDate, "dd-MMM-yyyy") & "' AND TransactionType = 'DEBIT' AND CostCode <> '0'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strDescription As String = Nothing
            Dim strType As String = Nothing
            Dim strAmount As String = "0.00"
            If Not IsDBNull(objReader(0).ToString) Then strDescription = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strType = objReader(1).ToString
            If IsNumeric(objReader(2).ToString) Then strAmount = Format(CDbl(objReader(2).ToString), "##0.00")
            arrReturn.Add(strDescription & "|" & strType & "|" & strAmount)
        End While
        objReader.Close()
        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Encountered error while trying to display cell details"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub btnCloseTip_Click(sender As System.Object, e As System.EventArgs) Handles btnCloseTip.Click
        Me.Close()
    End Sub

End Class
