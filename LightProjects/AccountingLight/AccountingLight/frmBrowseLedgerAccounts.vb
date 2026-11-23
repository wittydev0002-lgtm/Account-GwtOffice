Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBrowseLedgerAccounts

    Dim boolFormLoading As Boolean

    Private Sub txtSearchString_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearchString.KeyDown
        If e.KeyValue = Keys.Down Then
            If Not String.IsNullOrEmpty(txtSearchString.Text) Then
                dGridBrands.Focus()
                dGridBrands.SelectedRows(0).Selected = True
            Else
                SearchForItem("")
                dGridBrands.Focus()
                dGridBrands.SelectedRows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub txtSearchString_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchString.TextChanged
        SearchForItem("")
    End Sub

    Private Sub frmBrowseLedgerAccounts_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtSearchString.TabIndex = 0
        txtSearchString.Select()
    End Sub

    Private Sub frmBrowseLedgerAccounts_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 650
        Me.Height = 420
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        If boolFormLoading = True Then Exit Sub
        On Error GoTo RaiseErr
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        Cursor = Cursors.WaitCursor
        dGridBrands.Columns.Clear()

        Dim strSql As String = Nothing
        If optCode.Checked = True Then
            strSql = "SELECT LedgerAccounts.AccountNumber AS [Account Number], LedgerAccounts.AccountName AS [Account Name] " _
                & "FROM LedgerAccounts WHERE AccountNumber LIKE '%" & strFind & "%' ORDER BY AccountNumber"
        Else
            strSql = "SELECT LedgerAccounts.AccountNumber AS [Account Number], LedgerAccounts.AccountName AS [Account Name] " _
                & "FROM LedgerAccounts WHERE AccountName LIKE '%" & strFind & "%' ORDER BY AccountName"
        End If

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridBrands.DataSource = dTable

        Me.dGridBrands.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dGridBrands.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'dGridBrands.Focus()
        If dGridBrands.Rows.Count > 0 Then
            dGridBrands.FirstDisplayedScrollingRowIndex = 0
            dGridBrands.Rows(0).Selected = True
        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger Accounts Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub dGridBrands_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridBrands.DoubleClick
        If dGridBrands.Rows.Count > 0 Then
            strSelectedAccountName = dGridBrands.CurrentRow.Cells(1).Value.ToString
            strSelectedAccountNumber = dGridBrands.CurrentRow.Cells(0).Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub dGridBrands_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridBrands.KeyDown
        If e.KeyValue = Keys.Enter Then
            e.SuppressKeyPress = True
            If dGridBrands.Rows.Count > 0 Then
                strSelectedAccountName = dGridBrands.CurrentRow.Cells(1).Value.ToString
                strSelectedAccountNumber = dGridBrands.CurrentRow.Cells(0).Value.ToString
                Me.Close()
            End If
        End If
    End Sub

End Class
