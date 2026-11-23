Imports CommonLibrary.Commons

Public Class frmOwingStudents

    Private Sub frmOwingStudents_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadOwingsData()
    End Sub

    Private Sub LoadOwingsData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT SC_StudentTransactions.StudentId, " _
            & "SC_Students.LastName +' '+ SC_Students.FirstName AS [Student Names], " _
            & "SC_Students.ClassName AS [Class], SC_Students.ContactTelephone AS [Phone], " _
            & "SUM(SC_StudentTransactions.Debit) AS [Invoiced], SUM(SC_StudentTransactions.Credit) AS [Paid], " _
            & "SUM(SC_StudentTransactions.Debit - SC_StudentTransactions.Credit) AS [Balance] " _
            & "FROM SC_StudentTransactions LEFT OUTER JOIN SC_Students ON " _
            & "SC_StudentTransactions.StudentId = SC_Students.StudentId " _
            & "WHERE (SC_StudentTransactions.Debit - SC_StudentTransactions.Credit) <> 0 " _
            & "GROUP BY SC_StudentTransactions.StudentId, SC_Students.LastName, " _
            & "SC_Students.FirstName, SC_Students.ClassName, SC_Students.ContactTelephone " _
            & "ORDER BY SC_Students.ClassName, SC_Students.LastName, SC_Students.FirstName"

        dGridOwings.SuspendLayout()
        dGridOwings.Columns.Clear()
        Me.dGridOwings.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridOwings.DataSource = dTable
        'dGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dGridOwings.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dGridOwings.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dGridOwings.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dGridOwings.Columns(4).DefaultCellStyle.Format = "N2"
        dGridOwings.Columns(5).DefaultCellStyle.Format = "N2"
        dGridOwings.Columns(6).DefaultCellStyle.Format = "N2"

        lblTotalRecords.Text = dGridOwings.RowCount
        dGridOwings.ResumeLayout()
        ComputeTotals()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.WaitCursor
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On students with balances load"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintList_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintListOwings.Click

    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT SUM(SC_StudentTransactions.Debit - SC_StudentTransactions.Credit) AS [Balance] " _
            & "FROM SC_StudentTransactions WHERE (SC_StudentTransactions.Debit - SC_StudentTransactions.Credit) <> 0 "
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                lblTotalOwings.Text = Format(CDbl(objReader(0).ToString), "#,##0.00")
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.WaitCursor
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On students with balances load"
        ShowErrorMessage()
    End Sub

End Class