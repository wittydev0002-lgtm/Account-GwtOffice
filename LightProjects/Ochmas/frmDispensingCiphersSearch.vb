Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDispensingCiphersSearch

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
        If optCode.Checked = True Then
            strSql = "SELECT [Code], [Instruction] from OchmasDispensingCiphers " _
                & "WHERE Code LIKE '%" & strFind & "%' ORDER BY Code"
        Else
            strSql = "SELECT [Code], [Instruction] from OchmasDispensingCiphers " _
                & "WHERE Instruction LIKE '%" & strFind & "%' ORDER BY Instruction"
        End If

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'dGridBrands.Focus()
        If dGrid.Rows.Count > 0 Then
            dGrid.FirstDisplayedScrollingRowIndex = 0
            dGrid.Rows(0).Selected = True
        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Dispensing Ciphers Search"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub frmDispensingCiphersSearch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        Me.Width = 510
        Me.Height = 350
        LoadData()
        boolFormLoading = False
    End Sub

    Private Sub dGrid_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellContentDoubleClick
        If dGrid.Rows.Count > 0 Then
            strSelectedCodeDescription = dGrid.CurrentRow.Cells(1).Value.ToString
            strSelectedCode = dGrid.CurrentRow.Cells(0).Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub dGrid_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGrid.KeyDown
        If e.KeyValue = Keys.Enter Then
            e.SuppressKeyPress = True
            If dGrid.Rows.Count > 0 Then
                strSelectedCodeDescription = dGrid.CurrentRow.Cells(1).Value.ToString
                strSelectedCode = dGrid.CurrentRow.Cells(0).Value.ToString
                Me.Close()
            End If
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        dGrid.Columns.Clear()

        Dim strSql As String = Nothing

        strSql = "SELECT [Code], [Instruction] from OchmasDispensingCiphers ORDER BY Code"
        
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'dGridBrands.Focus()
        If dGrid.Rows.Count > 0 Then
            dGrid.FirstDisplayedScrollingRowIndex = 0
            dGrid.Rows(0).Selected = True
        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Dispensing Ciphers Search"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

End Class
