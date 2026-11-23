Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDispensingCiphersListing

    Dim boolFormLoading As Boolean

    Private Sub frmDispensingCiphersListing_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 610 : Me.Height = 450
    End Sub

    Private Sub frmDispensingCiphersListing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        LoadData()
        cboSearchBy.SelectedIndex = 0
        boolFormLoading = False
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmDispensingCipherSetup
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Code as [Cipher], Instruction as [Instruction] FROM OchmasDispensingCiphers ORDER BY Code"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        dGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        lblTotalRecords.Text = dGrid.Rows.Count

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On dispensing ciphers listing load"
        ShowErrorMessage()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If dGrid.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedCipher()
            Dim frm As New frmDispensingCipherSetup
            frm.ShowDialog()
            LoadData()
        End If
    End Sub

    Private Sub GetSelectedCipher()
        If dGrid.RowCount > 0 Then
            strSelectedCode = dGrid.CurrentRow.Cells(0).Value.ToString
        End If
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedCipher()
            Dim frm As New frmDispensingCipherSetup
            frm.ShowDialog()
            LoadData()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If dGrid.Rows.Count > 0 Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM OchmasDispensingCiphers WHERE " _
                & "Code = '" & dGrid.CurrentRow.Cells(0).Value.ToString & "'", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Cipher record has been deleted", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On dispensing ciphers delete"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub txtSearchString_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearchString.KeyDown
        If e.KeyValue = Keys.Down Then
            If Not String.IsNullOrEmpty(txtSearchString.Text) Then
                dGrid.Focus()
            Else
                SearchForItem("")
            End If
        End If
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        If boolFormLoading = True Then Exit Sub
        On Error GoTo RaiseErr
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        Cursor = Cursors.WaitCursor

        dGrid.Columns.Clear()

        Dim strSql As String = Nothing
        dGrid.DataSource = Nothing

        Select Case cboSearchBy.SelectedIndex
            Case Is = 0
                strSql = "SELECT Code as [Cipher], Instruction as [Instruction] FROM OchmasDispensingCiphers " _
                    & "WHERE Code LIKE '%" & strFind & "%' ORDER BY Code"
            Case Is = 1
                strSql = "SELECT Code as [Cipher], Instruction as [Instruction] FROM OchmasDispensingCiphers " _
                    & "WHERE Instruction LIKE '%" & strFind & "%' ORDER BY Instruction, Code"
            Case Else
                strSql = "SELECT Code as [Cipher], Instruction as [Instruction] FROM OchmasDispensingCiphers " _
                    & "WHERE Code LIKE '%" & strFind & "%' ORDER BY Code"
        End Select

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        dGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        lblTotalRecords.Text = dGrid.Rows.Count

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Dispensing Ciphers Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnPrintAll_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintAll.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT Code as [Cipher], Instruction as [Instruction] FROM OchmasDispensingCiphers ORDER BY Code"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read

        End While
        objReader.Close()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Dispensing Ciphers Print"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

End Class
