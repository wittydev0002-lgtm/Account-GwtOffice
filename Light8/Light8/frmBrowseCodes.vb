Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBrowseCodes

    Private Sub frmBrowseCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
        txtSearchFor.Select()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        txtSearchFor.Clear()
        Dim strSql As String = "SELECT CodeNo AS [Code], Description FROM SystemCodes " _
            & "WHERE Description IS NOT NULL ORDER BY CodeNo"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGrid.Columns.Clear()
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        dGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.allcells
        dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & "on Payroll Codes Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetSelectedItem()
        If dGrid.Rows.Count > 0 Then
            strSelectedCode = dGrid.CurrentRow.Cells(0).Value.ToString
            strSelectedCodeDescription = dGrid.CurrentRow.Cells(1).Value.ToString
        End If
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        GetSelectedItem()
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        GetSelectedItem()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        On Error GoTo RaiseErr
        Dim strFind As String = txtSearchFor.Text & strCurrentKey
        Cursor = Cursors.WaitCursor
        dGrid.Columns.Clear()

        Dim strSql As String = "SELECT CodeNo AS [Code], Description FROM SystemCodes " _
            & "WHERE Description LIKE '%" & strFind & "%' ORDER BY CodeNo"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGrid.Columns.Clear()
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        dGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.allcells
        dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Payroll Codes Search"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtSearchFor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchFor.KeyPress
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub frmBrowseCodes_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 431 : Me.Height = 484
    End Sub
End Class