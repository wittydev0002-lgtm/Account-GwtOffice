Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmStudentSearch

    Dim boolFormLoading As Boolean

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
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
        If optCode.Checked = True Then
            strSql = "SELECT UPPER(StudentId) AS [Account Number], UPPER(LastName +' '+ FirstName +' '+ OtherNames) AS [Account Name] FROM SC_Students " _
                & "WHERE StudentId LIKE '%" & strFind & "%' ORDER BY StudentId"
        Else
            strSql = "SELECT UPPER(StudentId) AS [Account Number], UPPER(LastName +' '+ FirstName +' '+ OtherNames) AS [Account Name] FROM SC_Students " _
                & "WHERE LastName LIKE '%" & strFind & "%' ORDER BY LastName"
        End If

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        'dGridBrands.Focus()
        If dGrid.Rows.Count > 0 Then
            dGrid.FirstDisplayedScrollingRowIndex = 0
            dGrid.Rows(0).Selected = True
        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Students Search"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count > 0 Then
            AssignSelected()
        End If
    End Sub

    Private Sub dGrid_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGrid.KeyDown
        If e.KeyValue = Keys.Enter Or e.KeyValue = 9 Then
            e.SuppressKeyPress = True
            If dGrid.Rows.Count > 0 Then
                AssignSelected()
            End If
        End If
    End Sub

    Private Sub AssignSelected()
        strSelectedAccountName = dGrid.CurrentRow.Cells(1).Value.ToString
        strSelectedAccount = dGrid.CurrentRow.Cells(0).Value.ToString
        Me.Close()
    End Sub

    Private Sub frmCustomerSearch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtSearchString.Text = strSearchText
        txtSearchString.TabIndex = 0
        txtSearchString.Select()
    End Sub

    Private Sub frmCustomerSearch_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 656 : Me.Height = 454
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        AssignSelected()
    End Sub

End Class