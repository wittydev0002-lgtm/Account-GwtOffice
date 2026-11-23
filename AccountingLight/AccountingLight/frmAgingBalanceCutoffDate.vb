Imports CommonLibrary.Commons

Public Class frmAgingBalanceCutoffDate

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT DueDays FROM SystemAgingParameters ORDER BY TRansactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(Format(CInt(objReader(0).ToString), "000"))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Aging balances parameters load"
        ShowErrorMessage()
    End Sub

    Private Sub frmAgingBalanceCutoffDate_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
        UpdateDatesColumn()
    End Sub

    Private Sub UpdateDatesColumn()
        On Error GoTo RaiseErr
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(0).Value.ToString) Then
                        dGrid.Rows(p).Cells(1).Value = UCase(Format(DateAdd(DateInterval.Day, _
                            (0 - CInt(dGrid.Rows(p).Cells(0).Value.ToString)), _
                            dpDate.Value), "dd-MMM-yyyy"))
                    End If
                End If
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Aging balances parameters load"
        ShowErrorMessage()
    End Sub

    Private Sub dpDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dpDate.ValueChanged
        UpdateDatesColumn()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT "
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Aging balances parameters load"
        ShowErrorMessage()
    End Sub

    Private Function AgingBalances(CustomerId As String, CutOffDate As Date, PeriodDays() As Integer) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList

        Dim dblInvoicesTotal As Double = 0
        Dim dblTotalPayments As Double = 0

        Dim strSql As String = "SELECT SUM(((SalesPrice * Quantity) + (Taxes * Quantity)) - DiscountAllowed) " _
            & "FROM CustomerSales WHERE CustomerId = '" & CustomerId & "' AND TransDate <= '" & Format(CutOffDate, "dd-MMM-yyyy") & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblInvoicesTotal = CDbl(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        'Get the total of all payments made to cut-off date
        strSql = "SELECT SUM(Amount) FROM CustomerTransactions WHERE AccountNumber = '" & CustomerId & "' " _
            & "AND TransactionDate <= '" & Format(CutOffDate, "dd-MMM-yyyy") & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblTotalPayments = CDbl(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        'Sort the days
        Dim arrDays As New ArrayList
        For p As Integer = 0 To PeriodDays.Length - 1
            arrDays.Add(PeriodDays(p))
        Next
        arrDays.Sort()

        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Return arrReturn
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Aging balances parameters load"
        ShowErrorMessage()
    End Function

End Class
