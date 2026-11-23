Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmTakeOnBalancesHistory

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        LoadDetails(CDate(Format(dpStartFrom.Value, "dd-MMM-yyyy")), CDate(Format(dpEndTo.Value, "dd-MMM-yyyy")))
    End Sub

    Private Sub LoadDetails(StartingDate As Date, EndingDate As Date)

        On Error GoTo RaiseErr

        Cursor = Cursors.Default

        Dim strSql As String = "SELECT UPPER(SC_StudentTransactions.StudentId) AS [Student #], " _
            & "UPPER(SC_Students.LastName +' '+ SC_Students.FirstName +' '+ SC_Students.OtherNames) AS [Student Names], " _
            & "UPPER(SC_StudentTransactions.Description) AS [Description], " _
            & "UPPER(SC_StudentTransactions.Reference) AS [Ref. #], CAST([Debit] AS DECIMAL (10,2)) AS [Debit], " _
            & "CAST([Credit] AS DECIMAL (10,2)) AS [Credit], [UserName] AS [Entered By]," _
            & "UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "UPPER(SC_StudentTransactions.Remarks) AS [Remarks], SC_StudentTransactions.TransactionId AS [TID] FROM [SC_StudentTransactions] " _
            & "LEFT OUTER JOIN SC_Students ON SC_StudentTransactions.StudentId = SC_Students.StudentId " _
            & "WHERE SC_StudentTransactions.Description = 'TAKE ON BALANCE' AND SC_StudentTransactions.TransactionDate BETWEEN " _
            & "'" & StartingDate & "' AND '" & EndingDate & "' ORDER BY SC_StudentTransactions.TransactionDate, SC_StudentTransactions.TransactionId"

        dGridTakeOns.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridTakeOns.DataSource = dTable

        Me.dGridTakeOns.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Me.dGridTakeOns.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        For p As Integer = 0 To dGridTakeOns.Columns.Count - 1
            dGridTakeOns.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p = 4 Or p = 5 Then
                dGridTakeOns.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        dGridTakeOns.Columns(dGridTakeOns.Columns.Count - 1).Visible = False

        ComputeTotals(StartingDate, EndingDate)

        lblTotalSelected.Text = dGridTakeOns.Rows.Count

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On take-on balances history load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals(StartingDate As Date, EndingDate As Date)
        On Error GoTo RaiseErr
        lblTotalCredits.Text = "0.00"
        lblTotalDebits.Text = "0.00"
        Dim strSql As String = "SELECT SUM(Debit), SUM(Credit) FROM SC_StudentTransactions " _
            & "WHERE TransactionDate BETWEEN '" & StartingDate & "' AND '" & EndingDate & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                lblTotalDebits.Text = Format(CDbl(objReader(0).ToString), "#,##0.00")
            End If
            If IsNumeric(objReader(0).ToString) Then
                lblTotalCredits.Text = Format(CDbl(objReader(0).ToString), "#,##0.00")
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On take-on balances history load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If dGridTakeOns.RowCount <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm Delete", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_StudentTransactions " _
                & "WHERE TransactionId = " & dGridTakeOns.CurrentRow.Cells(dGridTakeOns.Columns.Count - 1).Value.ToString & "", cnn)
            objCommand.ExecuteNonQuery()
            LoadDetails(CDate(Format(dpStartFrom.Value, "dd-MMM-yyyy")), CDate(Format(dpEndTo.Value, "dd-MMM-yyyy")))
            MessageBox.Show("Transaction has been deleted successfully", "Process Success", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On take-on balances transaction delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        If dGridTakeOns.RowCount <= 0 Then Exit Sub
        gwt_comm.PrintDataGrid(dGridTakeOns, "TAKE ON BALANCE ENTRIES FROM " & UCase(Format(dpStartFrom.Value, "dd-MMM-yyyy")) & _
            " TO " & UCase(Format(dpEndTo.Value, "dd-MMM-yyyy")))
    End Sub

End Class
