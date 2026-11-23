Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmExtrasAndServicesListing

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmExtraAndServicesSetup
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        GetSelected()
    End Sub

    Private Sub GetSelected()
        If dGrid.Rows.Count <= 0 Then Exit Sub
        boolEditStatus = True
        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
        Dim frm As New frmExtraAndServicesSetup
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT TransactionId, Description, CAST([UnitPriceMedaid] AS DECIMAL (10,2)) AS [MedPrice], " _
            & "CAST([UnitPriceCash] AS DECIMAL (10,2)) AS [CashPrice], CAST([UnitPriceOther] AS DECIMAL (10,2)) AS [OtherPrice], " _
            & "CAST(Quantity AS DECIMAL (10,2)) AS [Qty] FROM OchmasExtrasAndServices ORDER BY Description"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        dGrid.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        For i As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            If i > 1 Then
                dGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next


        dGrid.Columns(0).Visible = False
        lblTotalRecords.Text = dGrid.Rows.Count

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & " On Extras and Services Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to delete the selected entry?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
            Dim strSql As String = "DELETE FROM OchmasExtrasAndServices WHERE TransactionId = " & intSelectedTransaction & ""
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            Cursor = Cursors.Default
            MessageBox.Show("Record has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        End If

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & " On Extras and Services delete"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As EventArgs) Handles dGrid.DoubleClick
        GetSelected()
    End Sub

    Private Sub frmExtrasAndServicesListing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

End Class