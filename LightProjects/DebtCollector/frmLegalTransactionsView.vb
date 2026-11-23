Imports CommonLibrary.Commons

Public Class frmLegalTransactionsView

    Private Sub frmLegalTransactionsView_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadTransactions()
    End Sub

    Private Sub LoadTransactions()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransactionDate, 105) AS [Date], " _
            & "Description, ReferenceNumber, CAST(Debit AS DECIMAL (10,2)) AS [Debit], " _
            & "CAST(Credit AS DECIMAL(10,2)) AS [Credit], Comments, TransactionId FROM DefendantTransactions " _
            & "WHERE DefendantId = '" & strSelectedAccount & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5), objReader(6))
        End While
        objReader.Close()
        With dGrid
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        lblBalance.Text = Format(dblClientBalance, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Transactions Load"
        ShowErrorMessage()
    End Sub

End Class
