Public Class frmLaschInputDisbursementsListing

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim f As New frmLaschInputDisbursements
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT LaschCustomerTransactions.DocumentNumber AS [Doc. #], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), LaschCustomerTransactions.TransDate, 106), ' ', '-')) as [Date], " _
            & "LaschCustomers.LastName +' '+ LaschCustomers.FirstName +' '+ LaschCustomers.OtherNames AS [Farmer], " _
            & "LaschCustomers.FarmName as [Farm Name], SUM(LaschCustomerTransactions.Debit) AS [Value] FROM LaschCustomerTransactions " _
            & "LEFT OUTER JOIN LaschCustomers ON LaschCustomerTransactions.AccountNumber = LaschCustomers.AccountNumber " _
            & "WHERE TransDate Between '" & Format(dpStartFrom.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndTo.Value, "dd-MMM-yyyy") & "' " _
            & "GROUP BY LaschCustomerTransactions.DocumentNumber, LaschCustomerTransactions.TransDate, " _
            & "LaschCustomers.LastName, LaschCustomers.FirstName, LaschCustomers.OtherNames, LaschCustomers.FarmName"

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            If p = dGrid.Columns.Count - 1 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " On transaction details load"
        ShowErrorMessage()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        GetSelected()
    End Sub

    Private Sub GetSelected()
        If dGrid.Rows.Count > 0 Then
            intSelectedTransaction = dGrid.CurrentRow.Cells(0).Value.ToString
            boolEditStatus = True
            Dim f As New frmLaschInputDisbursements
            f.ShowDialog()
            LoadData()
        End If
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        GetSelected()
    End Sub

    Private Sub frmLaschInputDisbursementsListing_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadUsers()
        LoadData()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As System.EventArgs) Handles btnGo.Click
        LoadData()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub LoadUsers()
        On Error GoTo RaiseErr
        cboUser.Items.Clear()
        cboUser.Items.Add("-- ALL --")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " On user details load"
        ShowErrorMessage()
    End Sub

End Class
