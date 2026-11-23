Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
'Imports System.Threading.Tasks
'Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDrugSearchShort

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
        If e.KeyValue = Keys.Enter Then
            e.SuppressKeyPress = True
            If dGridBrands.Rows.Count > 0 Then
                strSelectedCodeDescription = dGridBrands.CurrentRow.Cells(1).Value.ToString
                strSelectedCode = dGridBrands.CurrentRow.Cells(0).Value.ToString
                strSelectedPackSize = dGridBrands.CurrentRow.Cells(2).Value.ToString
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtSearchString_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchString.TextChanged
        SearchForItem("")
        'txtSearchString.Select()
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
            strSql = "SELECT ProductCode AS [Code], ProductName AS [Name], StandardPackSize as [Presentation], CONVERT(NVARCHAR, " _
                & "CAST(CostPrice AS DECIMAL (10,2))) AS [Unit Price] FROM OchmasSystemMedicines " _
                & "WHERE ProductCode LIKE '%" & strFind & "%' ORDER BY ProductCode"
        Else
            strSql = "SELECT ProductCode AS [Code], ProductName AS [Name], StandardPackSize as [Presentation], CONVERT(NVARCHAR, " _
                & "CAST(CostPrice AS DECIMAL (10,2))) AS [Unit Price] FROM OchmasSystemMedicines " _
                & "WHERE ProductName LIKE '%" & strFind & "%' ORDER BY ProductName"
        End If

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridBrands.DataSource = dTable

        Me.dGridBrands.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dGridBrands.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dGridBrands.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dGridBrands.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        'dGridBrands.Focus()
        If dGridBrands.Rows.Count > 0 Then
            dGridBrands.FirstDisplayedScrollingRowIndex = 0
            dGridBrands.Rows(0).Selected = True
        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Medicines Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub frmDrugSearch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Width = 680
        Me.Height = 455
        txtSearchString.TabIndex = 0
        txtSearchString.Select()
    End Sub

    Private Sub dGridBrands_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridBrands.DoubleClick
        If dGridBrands.Rows.Count > 0 Then
            strSelectedCodeDescription = dGridBrands.CurrentRow.Cells(1).Value.ToString
            strSelectedCode = dGridBrands.CurrentRow.Cells(0).Value.ToString
            strSelectedPackSize = dGridBrands.CurrentRow.Cells(2).Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub dGridBrands_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridBrands.KeyDown
        If e.KeyValue = Keys.Enter Then
            e.SuppressKeyPress = True
            If dGridBrands.Rows.Count > 0 Then
                strSelectedCodeDescription = dGridBrands.CurrentRow.Cells(1).Value.ToString
                strSelectedCode = dGridBrands.CurrentRow.Cells(0).Value.ToString
                strSelectedPackSize = dGridBrands.CurrentRow.Cells(2).Value.ToString
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        boolEditStatus = False
        Dim frm As New frmDrugSetup
        frm.ShowDialog()
        SearchForItem("")
    End Sub

End Class
