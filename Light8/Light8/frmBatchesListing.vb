Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBatchesListing

    Private Sub cboFilter_Click(sender As System.Object, e As System.EventArgs) Handles cboFilter.Click

    End Sub

    Private Sub cboFilter_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboFilter.SelectedIndexChanged
        If cboFilter.SelectedIndex = 0 Then
            'Date
            txtUsers.Visible = False
            lblLeft.Text = "Date from"
            pnlRight.Visible = True
            dpEnd.Visible = True
            dpStart.Visible = True
        Else
            'Processor
            lblLeft.Text = "Processor"
            txtUsers.Visible = True
            pnlRight.Visible = False
            dpEnd.Visible = False
            dpStart.Visible = False
        End If
    End Sub

    Private Sub frmTransactionBatchesListing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cboFilter.SelectedIndex = 0
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing
        If cboFilter.SelectedIndex = 0 Then
            strSql = "SELECT BatchNo AS [Batch #], UPPER(REPLACE(CONVERT(CHAR(11), " _
                & "CreationDate, 106), ' ', '-')) as [Date], Author AS [Processed By], " _
                & "CAST(BatchTotal AS DECIMAL (30,2)) AS [Amount] FROM SystemBatchesControl " _
                & "WHERE CreationDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStart.Value) & "' " _
                & "AND '" & gwt_comm.shortMonthDateFormat(dpEnd.Value) & "' ORDER BY BatchNo, CreationDate"
        Else
            strSql = "SELECT BatchNo AS [Batch #], UPPER(REPLACE(CONVERT(CHAR(11), " _
                & "CreationDate, 106), ' ', '-')) as [Date], Author AS [Processed By], " _
                & "CAST(BatchTotal AS DECIMAL (30,2)) AS [Amount] FROM SystemBatchesControl " _
                & "WHERE Author LIKE '%" & txtUsers.Text & "%' ORDER BY BatchNo, CreationDate"
        End If

        dGridTransactions.Columns.Clear()
        Me.dGridTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridTransactions.DataSource = dTable
        dGridTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        dGridTransactions.Columns(dGridTransactions.Columns.Count - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        ComputeTotals()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On payroll transaction batches listing load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals()
        Dim dblTotals As Double = 0
        For p As Integer = 0 To dGridTransactions.RowCount - 1
            If Not Object.Equals(dGridTransactions.Rows(p).Cells(dGridTransactions.Columns.Count - 1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridTransactions.Rows(p).Cells(dGridTransactions.Columns.Count - 1).Value.ToString) Then
                    If IsNumeric(dGridTransactions.Rows(p).Cells(dGridTransactions.Columns.Count - 1).Value.ToString) Then
                        dblTotals = dblTotals + CDbl(dGridTransactions.Rows(p).Cells(dGridTransactions.Columns.Count - 1).Value.ToString)
                    End If
                End If
            End If
        Next
        lblAmountTotals.Text = CStr(Format(dblTotals, "#,##0.00"))
        lblBatchesCount.Text = dGridTransactions.Rows.Count
    End Sub

    Private Sub btnFilter_Click(sender As System.Object, e As System.EventArgs) Handles btnFilter.Click
        LoadData()
    End Sub

    Private Sub btnDeleteBatch_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteBatch.Click
        On Error GoTo RaiseErr
        If dGridTransactions.Rows.Count > 0 Then
            If MessageBox.Show("Are you sure want to delete batch no " & dGridTransactions.CurrentRow.Cells(0).Value.ToString & "?", _
                "Confirm Batch Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim intBatchNumber As Integer = CInt(dGridTransactions.CurrentRow.Cells(0).Value.ToString)
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemBatchesControl WHERE BatchNo = " & intBatchNumber & "", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeBatches WHERE BatchNo = " & intBatchNumber & "", cnn)
                objCommand.ExecuteNonQuery()
                LoadData()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On payroll transaction batches delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEditBatch_Click(sender As System.Object, e As System.EventArgs) Handles btnEditBatch.Click
        If dGridTransactions.Rows.Count > 0 Then
            intSelectedBatchNumber = CInt(dGridTransactions.CurrentRow.Cells(0).Value.ToString)
            Me.Close()
        End If
    End Sub

    Private Sub dGridTransactions_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridTransactions.CellDoubleClick
        If dGridTransactions.Rows.Count > 0 Then
            intSelectedBatchNumber = CInt(dGridTransactions.CurrentRow.Cells(0).Value.ToString)
            Me.Close()
        End If
    End Sub

    Private Sub txtUsers_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUsers.KeyDown
        If e.KeyValue = Keys.Enter Then
            LoadData()
        End If
    End Sub

End Class