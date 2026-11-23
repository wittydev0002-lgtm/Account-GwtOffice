Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlMain.Height = txtSearchString.Height
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)

        Dim strFind As String = txtSearchString.Text & strCurrentKey
        Dim strActiveSearch As String = strFind
        Cursor = Cursors.WaitCursor

        With dGrid
            dGrid.Columns.Clear()

            Dim cmd As New OleDb.OleDbCommand("SELECT LastName AS [Last Name], FirstName AS [First Name], " _
                & "OtherNames AS [Other Names] FROM OchmasPatients WHERE (LastName LIKE '%" & strActiveSearch & "%' OR " _
                & "FirstName LIKE '%" & strActiveSearch & "%' OR OtherNames LIKE '%" & strActiveSearch & "%') " _
                & "ORDER BY LastName, FirstName, OtherNames", cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New OleDb.OleDbDataAdapter(cmd)
            Dim dTable As New DataTable()
            da.Fill(dTable)
            dGrid.DataSource = dTable

            For p As Integer = 0 To dGrid.Columns.Count - 1
                .Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

            If .RowCount > 0 Then
                Dim intHeight As Integer = 260
                If (.RowCount + 2) * 25 < 260 Then intHeight = (.RowCount + 2) * 25
                pnlMain.Height = intHeight
            Else
                pnlMain.Height = txtSearchString.Height
            End If
        End With

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Data Filter Search"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub txtSearchString_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearchString.KeyDown
        If e.KeyValue = Keys.Down Then
            If Not String.IsNullOrEmpty(txtSearchString.Text) Then
                dGrid.Focus()
                dGrid.SelectedRows(0).Selected = True
            Else
                SearchForItem("")
                dGrid.Focus()
                If dGrid.RowCount > 0 Then dGrid.SelectedRows(0).Selected = True
            End If
        End If
        If e.KeyValue = Keys.Enter Then
            If dGrid.Rows.Count > 0 Then
                dGrid.Rows(0).Selected = True
                AssignSelected()
                txtSearchString.Clear()
                pnlMain.Height = txtSearchString.Height
                txtSearchString.Select()
            End If
        End If
    End Sub

    Private Sub dGrid_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGrid.KeyDown
        If e.KeyValue = Keys.Enter Or e.KeyValue = 9 Then
            e.SuppressKeyPress = True
            If dGrid.Rows.Count > 0 Then
                AssignSelected()
                txtSearchString.Clear()
                pnlMain.Height = txtSearchString.Height
                txtSearchString.Select()
            End If
        End If
    End Sub

    Private Sub txtSearchString_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchString.TextChanged
        SearchForItem("")
    End Sub

    Private Sub AssignSelected()

    End Sub

End Class