Public Class frmBrowseBooks

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Dim boolFormLoading As Boolean

    Private Sub txtSearchString_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearchString.KeyDown
        If e.KeyValue = Keys.Down Then
            If Not String.IsNullOrEmpty(txtSearchString.Text) Then
                dGrid.Focus()
                dGrid.SelectedRows(0).Selected = True
            Else
                SearchForItem("")
                dGrid.Focus()
                dGrid.SelectedRows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub txtSearchString_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchString.TextChanged
        SearchForItem("")
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        If boolFormLoading = True Then Exit Sub
        On Error GoTo RaiseErr
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        Cursor = Cursors.WaitCursor
        dGrid.Columns.Clear()

        Dim strSql As String = Nothing
        strSql = "SELECT Isbn AS [ISBN], Title, Author from Books " _
            & "WHERE Title LIKE '%" & strFind & "%' ORDER BY Title"

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dGrid.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        'dGridBrands.Focus()
        If dGrid.Rows.Count > 0 Then
            dGrid.FirstDisplayedScrollingRowIndex = 0
            dGrid.Rows(0).Selected = True
        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Book Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub frmBrowseBooks_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtSearchString.Select()
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count > 0 Then
            strSelectedBookNumber = dGrid.CurrentRow.Cells(0).Value.ToString
            boolAbort = False
            Me.Close()
        End If
    End Sub

    Private Sub dGrid_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGrid.KeyDown
        If e.KeyValue = Keys.Enter Then
            e.SuppressKeyPress = True
            If dGrid.RowCount <= 0 Then
                If dGrid.Rows.Count > 0 Then
                    strSelectedBookNumber = dGrid.CurrentRow.Cells(0).Value.ToString
                    boolAbort = False
                    Me.Close()
                End If
            Else
                dGrid.Select()
                dGrid.SelectedRows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub frmBrowseBooks_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 618 : Me.Height = 399
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If dGrid.Rows.Count > 0 Then
            strSelectedBookNumber = dGrid.CurrentRow.Cells(0).Value.ToString
            boolAbort = False
            Me.Close()
        End If
    End Sub

End Class
