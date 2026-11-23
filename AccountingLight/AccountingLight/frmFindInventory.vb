Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmFindInventory

    Private Sub LoadBrowserPanel()
        On Error GoTo RaiseErr

        'Update for the serial numbers table
        Dim strSql As String = Nothing
        strSql = "IF OBJECT_ID(N'SerialNumbers', N'U') IS NULL CREATE TABLE SerialNumbers ([TransactionId][int] " _
            & "NOT NULL PRIMARY KEY IDENTITY (1,1), [ItemCode][nvarchar](150) NOT NULL, [SerialNumber][nvarchar]" _
            & "(250) NOT NULL)"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                    & "FROM InventoryItems ORDER BY ItemCode"

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        AlternateColors()

        If UCase(strUserLevel) <> "MANAGER" Then
            If UCase(strUserLevel) <> "ADMINISTRATOR" Then
                dGrid.Columns(3).Visible = False
            End If
        End If

        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Items Load"
        ShowErrorMessage()
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        Cursor = Cursors.WaitCursor
        'grd.Rows.Clear()
        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim strSql As String = Nothing

        If chkWildCast.Checked = True Then
            Select Case cboSearchType.Text
                Case Is = "Item Code"
                    If UCase(cboInventoryStatus.Text) = "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '%" & strFind & "%' ORDER BY ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '%" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY ItemCode"
                    End If
                Case Is = "Description" 'Use the grup name
                    If UCase(cboInventoryStatus.Text) = "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE GroupName LIKE '%" & strFind & "%' ORDER BY GroupName, ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE GroupName LIKE '%" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY GroupName, ItemCode"
                    End If
                Case Is = "Category"
                    If UCase(cboInventoryStatus.Text) = "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE Category LIKE '%" & strFind & "%' ORDER BY Category, ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE Category LIKE '%" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY Category, ItemCode"
                    End If
                Case Is = "Sub Category"
                    If UCase(cboInventoryStatus.Text) = "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE SubCategory LIKE '%" & strFind & "%' ORDER BY SubCategory, ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE SubCategory LIKE '%" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY SubCategory, ItemCode"
                    End If
                Case Else
                    If UCase(cboInventoryStatus.Text) = "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '%" & strFind & "%' ORDER BY ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '%" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY ItemCode"
                    End If
            End Select
        Else
            Select Case cboSearchType.Text
                Case Is = "Item Code"
                    If UCase(cboInventoryStatus.Text) = "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '" & strFind & "%' ORDER BY ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY ItemCode"
                    End If
                Case Is = "Description" 'Use the group name
                    If UCase(cboInventoryStatus.Text) = "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE GroupName LIKE '" & strFind & "%' ORDER BY GroupName, ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE GroupName LIKE '" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY GroupName, ItemCode"
                    End If
                Case Is = "Category"
                    If UCase(cboInventoryStatus.Text) = "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE Category LIKE '" & strFind & "%' ORDER BY Category, ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE Category LIKE '" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY Category, ItemCode"
                    End If
                Case Is = "Sub Category"
                    If UCase(cboInventoryStatus.Text) = "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE SubCategory LIKE '" & strFind & "%' ORDER BY SubCategory, ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE SubCategory LIKE '" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY SubCategory, ItemCode"
                    End If
                Case Else
                    If UCase(cboInventoryStatus.Text) = "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '" & strFind & "%' ORDER BY ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax], ShortCode as [Short Code] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY ItemCode"
                    End If
            End Select
        End If
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        AlternateColors()
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

        If UCase(strUserLevel) <> "MANAGER" Then
            If UCase(strUserLevel) <> "ADMINISTRATOR" Then
                dGrid.Columns(3).Visible = False
            End If
        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
        Exit Sub
    End Sub

    Private Sub AlternateColors()
        'For i As Integer = 0 To dGrid.Rows.Count - 1 Step 2
        '    For j As Integer = 0 To dGrid.Columns.Count - 1
        '        Dim foreColor As Color = Color.Black
        '        Dim backColor As Color = Color.smokewhite
        '        dGrid.Rows(i).Cells(j).Style.BackColor = backColor
        '        dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
        '    Next j
        'Next i
    End Sub

    Private Sub frmFindInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBrowserPanel()
        txtSearchString.Focus()
        If UCase(CommonLibrary.Commons.strDefaultSearchFilter) = "DESCRIPTION" Then cboSearchType.SelectedIndex = 1 Else cboSearchType.SelectedIndex = 0
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        GetSelectedValues()
    End Sub

    Private Sub GetSelectedValues()
        boolAbort = False
        strPublicItemCode = Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value)
        strPublicItemDescription = Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(1).Value)
        strShortItemCode = Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(dGrid.ColumnCount - 1).Value)
        strFullItemDetails = Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value) & ";" _
            & Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(1).Value) & ";" _
            & Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(2).Value) & ";" _
            & Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(12).Value)
        Me.Close()
    End Sub

    Private Sub btnSelectSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSales.Click
        GetSelectedValues()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        SearchForItem(e.KeyChar)
    End Sub

End Class