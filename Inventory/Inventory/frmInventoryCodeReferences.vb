Imports CommonLibrary.Commons

Public Class frmInventoryCodeReferences

    Dim boolFormLoading As Boolean

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolCalledFromListing = True
        boolEditStatus = False
        Dim frm As New frmShortCodeDescriptionSetup
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT ShortCode AS [Short Code], Description " _
            & "AS [Applicable To] FROM InventoryShortCodeDescriptions ORDER BY ShortCode"
        grd.Columns.Clear()
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        grd.DataSource = dTable

        Me.grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To grd.Columns.Count - 1
            grd.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

        lblTotalSelected.Text = grd.RowCount

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Short Code Descriptions Setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmInventoryCodeReferences_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        boolFormLoading = True
        LoadData()
        boolFormLoading = False
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        EditSelectedRecord()
    End Sub

    Private Sub EditSelectedRecord()
        If grd.RowCount <= 0 Then Exit Sub
        If Not Object.Equals(grd.CurrentRow.Cells(0).Value, Nothing) Then
            strselectedShortCode = grd.CurrentRow.Cells(0).Value.ToString
            boolEditStatus = True
            boolCalledFromListing = True
            Dim frm As New frmShortCodeDescriptionSetup
            frm.ShowDialog()
            LoadData()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If grd.RowCount <= 0 Then Exit Sub
        If MessageBox.Show("Are you sure you want to delete the selected short code?", "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Not Object.Equals(grd.CurrentRow.Cells(0).Value, Nothing) Then
                Dim strShortCode As String = grd.CurrentRow.Cells(0).Value.ToString
                Dim strDescription As String = Nothing
                If Not Object.Equals(grd.CurrentRow.Cells(1).Value, Nothing) Then
                    strDescription = grd.CurrentRow.Cells(1).Value.ToString
                End If
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM InventoryShortCodeDescriptions " _
                    & "WHERE ShortCode = '" & strShortCode & "' AND Description = '" & strDescription & "'", cnn)
                objCommand.ExecuteNonQuery()
                MessageBox.Show("Transaction has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Short Code Descriptions Setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub grd_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grd.CellContentDoubleClick
        EditSelectedRecord()
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        On Error GoTo RaiseErr
        If boolFormLoading = True Then Exit Sub
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        strActiveSearch = strFind
        Cursor = Cursors.WaitCursor

        grd.Columns.Clear()
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim strSql As String = Nothing
        If UCase(cboSearchBy.Text) = "SHORT CODE" Then
            strSql = "SELECT ShortCode AS [Short Code], Description " _
            & "AS [Applicable To] FROM InventoryShortCodeDescriptions " _
            & "WHERE ShortCode LIKE '%" & strFind & "%' ORDER BY ShortCode"
        Else
            strSql = "SELECT ShortCode AS [Short Code], Description " _
            & "AS [Applicable To] FROM InventoryShortCodeDescriptions " _
            & "WHERE Description LIKE '%" & strFind & "%' ORDER BY Description"
        End If

        grd.Columns.Clear()
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        grd.DataSource = dTable

        Me.grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To grd.Columns.Count - 1
            grd.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

        lblTotalSelected.Text = grd.RowCount

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Short Code Descriptions Setup"
        ShowErrorMessage()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If e.KeyChar = " " Then
            If strCompanyAllowsSpacesOnItemCodes = "NO" Then
                e.KeyChar = "-"
            End If
        End If
        SearchForItem(e.KeyChar)
    End Sub

End Class