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

Public Class frmDrugSearch

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
            If UCase(strCallingForm) = "DISPENSING" Then
                strSql = "SELECT ProductCode AS [Code], ProductName AS [Name], Strength as [Strength], CONVERT(NVARCHAR, " _
                    & "CAST(SellPrice AS DECIMAL (10,2))) AS [Unit Price], [TaxStatus] AS [Tax] from OchmasSystemMedicines " _
                    & "WHERE MedpraxProductCode LIKE '%" & strFind & "%' ORDER BY ProductCode"
            Else
                strSql = "SELECT ProductCode AS [Code], ProductName AS [Name], Strength as [Strength], CONVERT(NVARCHAR, " _
                    & "CAST(SellPrice AS DECIMAL (10,2))) AS [Unit Price], [TaxStatus] AS [Tax] from OchmasSystemMedicines " _
                    & "WHERE ProductCode LIKE '%" & strFind & "%' ORDER BY ProductCode"
            End If
        Else
            If UCase(strCallingForm) = "DISPENSING" Then
                strSql = "SELECT ProductCode AS [Code], ProductName AS [Name], Strength as [Strength], CONVERT(NVARCHAR, " _
                    & "CAST(SellPrice AS DECIMAL (10,2))) AS [Unit Price], [TaxStatus] AS [Tax] from OchmasSystemMedicines " _
                    & "WHERE ProductName LIKE '%" & strFind & "%' ORDER BY ProductName"
            Else
                strSql = "SELECT ProductCode AS [Code], ProductName AS [Name], Strength as [Strength], CONVERT(NVARCHAR, " _
                    & "CAST(SellPrice AS DECIMAL (10,2))) AS [Unit Price], [TaxStatus] AS [Tax] from OchmasSystemMedicines " _
                    & "WHERE ProductName LIKE '%" & strFind & "%' ORDER BY ProductName"
            End If
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
            LoadGenericDrugs(dGridBrands.Rows(0).Cells(0).Value.ToString)
        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Medicines Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadGenericDrugs(BrandCode As String)
        On Error GoTo RaiseErr

        dGridGenerics.Columns.Clear()

        Dim strSql As String = "SELECT OchmasSystemBrandGenericLink.GenericCode AS [Code], OchmasSystemMedicines.ProductName AS [Name], " _
            & "OchmasSystemMedicines.Strength AS [Strength], CONVERT(NVARCHAR, " _
            & "CAST(OchmasSystemMedicines.SellPrice AS DECIMAL (10,2))) AS [Unit Price], OchmasSystemMedicines.TaxStatus AS [Tax] from OchmasSystemBrandGenericLink " _
            & "LEFT OUTER JOIN OchmasSystemMedicines ON OchmasSystemBrandGenericLink.GenericCode = OchmasSystemMedicines.ProductCode " _
            & "WHERE OchmasSystemBrandGenericLink.BrandCode = '" & BrandCode & "' ORDER BY OchmasSystemMedicines.ProductName"

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridGenerics.DataSource = dTable

        Me.dGridGenerics.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dGridGenerics.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dGridGenerics.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dGridGenerics.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        'dGridBrands.Focus()
        If dGridGenerics.Rows.Count > 0 Then
            dGridGenerics.FirstDisplayedScrollingRowIndex = 0
            dGridGenerics.Rows(0).Selected = True
        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Medicines Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub dGridBrands_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridBrands.DoubleClick
        If dGridBrands.Rows.Count > 0 Then
            strSelectedCodeDescription = dGridBrands.CurrentRow.Cells(1).Value.ToString
            strSelectedCode = dGridBrands.CurrentRow.Cells(0).Value.ToString
            strSelectedItemTaxStatus = dGridBrands.CurrentRow.Cells(4).Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub dGridBrands_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridBrands.KeyDown
        If e.KeyValue = Keys.Enter Then
            e.SuppressKeyPress = True
            If dGridGenerics.RowCount <= 0 Then
                If dGridBrands.Rows.Count > 0 Then
                    strSelectedCodeDescription = dGridBrands.CurrentRow.Cells(1).Value.ToString
                    strSelectedCode = dGridBrands.CurrentRow.Cells(0).Value.ToString
                    strSelectedItemTaxStatus = dGridBrands.CurrentRow.Cells(4).Value.ToString
                    Me.Close()
                End If
            Else
                dGridGenerics.Select()
                dGridGenerics.SelectedRows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub dGridBrands_SelectionChanged(sender As Object, e As System.EventArgs) Handles dGridBrands.SelectionChanged
        If dGridBrands.Rows.Count > 0 Then
            LoadGenericDrugs(dGridBrands.CurrentRow.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub frmDrugSearch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '724, 535
        Me.Width = 724
        Me.Height = 535
        txtSearchString.TabIndex = 0
        txtSearchString.Select()
    End Sub

    Private Sub dGridGenerics_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridGenerics.DoubleClick
        If dGridGenerics.Rows.Count > 0 Then
            strSelectedCodeDescription = dGridGenerics.CurrentRow.Cells(1).Value.ToString
            strSelectedCode = dGridGenerics.CurrentRow.Cells(0).Value.ToString
            strSelectedItemTaxStatus = dGridGenerics.CurrentRow.Cells(4).Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub dGridGenerics_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridGenerics.KeyDown
        If e.KeyValue = Keys.Enter Then
            If dGridGenerics.Rows.Count > 0 Then
                strSelectedCodeDescription = dGridGenerics.CurrentRow.Cells(1).Value.ToString
                strSelectedCode = dGridGenerics.CurrentRow.Cells(0).Value.ToString
                strSelectedItemTaxStatus = dGridGenerics.CurrentRow.Cells(4).Value.ToString
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
