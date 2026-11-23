Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventoryMaster

    Dim boolHeaderClicked As Boolean = False
    Dim boolFormLoading As Boolean

    Private Sub frmInventoryMaster_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        boolAbort = False
        cboInventoryStatus.Text = "ALL"
        LoadData()
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
            btnEdit.Enabled = True
            btnNew.Enabled = True
            btnRefresh.Enabled = True
            btnPrint.Enabled = True
            btnChangeCodes.Enabled = True
        Else
            Select Case IntPublicInventory
                Case Is = 2
                    btnEdit.Enabled = True
                    btnNew.Enabled = True
                    btnRefresh.Enabled = True
                    btnPrint.Enabled = True
                    btnChangeCodes.Enabled = True
                Case Is = 1
                    btnEdit.Enabled = True
                    btnNew.Enabled = False
                    btnRefresh.Enabled = True
                    btnPrint.Enabled = True
                    btnChangeCodes.Enabled = False
                Case Else
                    btnEdit.Enabled = False
                    btnNew.Enabled = False
                    btnRefresh.Enabled = False
                    btnPrint.Enabled = False
                    btnChangeCodes.Enabled = False
            End Select
        End If

        If UCase(strDefaultSearchFilter) = "DESCRIPTION" Then cboSearchBy.SelectedIndex = 1 Else cboSearchBy.SelectedIndex = 0
        boolFormLoading = False

    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim strViewStatus As String = "ALL"
        Select Case UCase(cboInventoryStatus.Text)
            Case Is = "ACTIVE"
                strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                    & "FROM InventoryItems WHERE Status = 'ACTIVE' ORDER BY ItemCode"
            Case Is = "INACTIVE"
                strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                    & "FROM InventoryItems WHERE Status = 'INACTIVE' ORDER BY ItemCode"
            Case Else
                strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                    & "FROM InventoryItems ORDER BY ItemCode"
        End Select

        grd.Columns.Clear()
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        grd.DataSource = dTable

        Me.grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        
        If UCase(strUserLevel) <> "MANAGER" Then
            If UCase(strUserLevel) <> "ADMINISTRATOR" Then
                grd.Columns(4).Visible = False
            End If
        End If

        For p As Integer = 0 To grd.Columns.Count - 1
            grd.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p = 2 Then grd.Columns(p).Visible = False
            If p = 3 Or p = 4 Then
                grd.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        lblTotalSelected.Text = grd.RowCount
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Items Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmMainOne_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyValue
            Case Is = Keys.F3
                CloneItem()
            Case Is = Keys.F4
                ChangeItemCode()
            Case Is = Keys.F6
                UpdateItemQuantity()
            Case Is = Keys.F10
                DeleteSelectedItems()
        End Select

    End Sub

    Private Sub mnuCloneItem_Click(sender As System.Object, e As System.EventArgs) Handles mnuCloneItem.Click
        CloneItem()
    End Sub

    Private Sub CloneItem()
        If grd.RowCount <= 0 Then Exit Sub
        GetSelectedDetails()
        Dim frm As New frmInventoryClone
        frm.ShowDialog()
        SearchForItem("")
    End Sub

    Private Sub mnuChangeItemCode_Click(sender As System.Object, e As System.EventArgs) Handles mnuChangeItemCode.Click
        ChangeItemCode()
    End Sub

    Private Sub ChangeItemCode()
        If grd.RowCount <= 0 Then Exit Sub
        boolCalledFromListing = True
        GetSelectedDetails()
        Dim f As New frmInventoryCodeChange
        f.ShowDialog()
        SearchForItem("")
    End Sub

    Private Sub mnuUpdateQuantityBy_Click(sender As System.Object, e As System.EventArgs) Handles mnuUpdateQuantityBy.Click
        UpdateItemQuantity()
    End Sub

    Private Sub ZeroQuantity()
        On Error GoTo RaiseErr
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Or IntPublicInventory > 0 Then
            boolAbort = False
            Dim CurrentCellValue As String
            CurrentCellValue = grd.CurrentRow.Cells(0).Value
            strSelectedCodeDescription = grd.CurrentRow.Cells(1).Value
            strActiviteStatus = grd.CurrentRow.Cells(6).Value
            strInventoryItemCode = CurrentCellValue
            Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = 0 WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SearchForItem("")
        Else
            MessageBox.Show("You do not have the right to access this part of the system", _
                "Invoking Unauthorised Access", MessageBoxButtons.OK, MessageBoxIcon.Stop)

        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On item quantity reset to 0"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub UpdateItemQuantity()
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Or IntPublicInventory > 0 Then
            boolAbort = False
            Dim CurrentCellValue As String
            CurrentCellValue = grd.CurrentRow.Cells(0).Value
            strSelectedCodeDescription = grd.CurrentRow.Cells(1).Value
            strActiviteStatus = grd.CurrentRow.Cells(6).Value
            strInventoryItemCode = CurrentCellValue
            Dim frm As New frmQuantityUpdate
            frm.ShowDialog()
            If boolAbort = True Then Exit Sub
            SearchForItem("")
        Else
            MessageBox.Show("You do not have the right to access this part of the system", _
                "Invoking Unauthorised Access", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
    End Sub

    Private Sub grd_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grd.CellMouseDown
        If e.Button = MouseButtons.Right Then
            ' Add this
            grd.CurrentCell = grd.Rows(e.RowIndex).Cells(e.ColumnIndex)
            ' Can leave these here - doesn't hurt
            grd.Rows(e.RowIndex).Selected = True
            grd.Focus()
        End If
    End Sub

    Private Sub btnShortCodes_Click(sender As System.Object, e As System.EventArgs) Handles btnShortCodes.Click
        Dim frm As New frmInventoryCodeReferences
        frm.ShowDialog()
    End Sub

    Private Sub grd_ColumnDividerDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnDividerDoubleClickEventArgs) Handles grd.ColumnDividerDoubleClick
        boolHeaderClicked = True
    End Sub

    Private Sub grd_ColumnHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd.ColumnHeaderMouseDoubleClick
        boolHeaderClicked = True
    End Sub

    Private Sub grd_dblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.DoubleClick
        EditSelectedInventory()
    End Sub

    Private Sub EditSelectedInventory()
        On Error Resume Next
        If btnChangeCodes.Enabled = False Then Exit Sub
        If boolHeaderClicked = True Then
            'boolHeaderClicked = False
            Exit Sub
        End If
        If grd.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedDetails()
            Dim iRowIndex As Integer = grd.CurrentRow.Index
            Dim f As New frmInventorySetup
            f.ShowDialog()
            If UCase(strActiveSearch) = "SEARCH ITEM" Then
                txtSearchString.Text = strInventoryItemCode
            Else
                If String.IsNullOrEmpty(txtSearchString.Text) Then
                    'LoadData()
                    'Set the current row data to updated view
                    With grd
                        For p As Integer = 0 To arrInventoryEditData.Count - 1
                            .Rows(iRowIndex).Cells(p).Value = UCase(arrInventoryEditData.Item(p))
                        Next
                        .FirstDisplayedScrollingRowIndex = iRowIndex
                    End With
                Else
                    txtSearchString.Text = strActiveSearch
                    With grd
                        If Not arrInventoryEditData Is Nothing Then
                            For p As Integer = 0 To arrInventoryEditData.Count - 1
                                .Rows(iRowIndex).Cells(p).Value = UCase(arrInventoryEditData.Item(p))
                            Next
                            .FirstDisplayedScrollingRowIndex = iRowIndex
                        End If
                    End With
                End If
            End If
            SearchForItem("")
        End If
    End Sub

    Private Sub GetSelectedDetails()
        Dim CurrentCellValue As String
        CurrentCellValue = grd.CurrentRow.Cells(0).Value
        strSelectedCodeDescription = grd.CurrentRow.Cells(1).Value
        strActiviteStatus = grd.CurrentRow.Cells(6).Value
        strInventoryItemCode = CurrentCellValue
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        EditSelectedInventory()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If e.KeyChar = " " Then
            If strCompanyAllowsSpacesOnItemCodes = "NO" Then
                e.KeyChar = "-"
            End If
        End If
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        If boolFormLoading = True Then Exit Sub
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        strActiveSearch = strFind
        Cursor = Cursors.WaitCursor

        grd.Columns.Clear()
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim strSql As String = Nothing
        If chkWildCast.Checked = True Then
            Select Case cboSearchBy.Text
                Case Is = "Item Code"
                    If UCase(cboInventoryStatus.Text) <> "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '%" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '%" & strFind & "%' ORDER BY ItemCode"
                    End If
                Case Is = "Description" 'Use the group name

                    If UCase(cboInventoryStatus.Text) <> "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE GroupName LIKE '%" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY GroupName, ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE GroupName LIKE '%" & strFind & "%' ORDER BY GroupName, ItemCode"
                    End If

                Case Is = "Category"

                    If UCase(cboInventoryStatus.Text) <> "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE Category LIKE '%" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY Category, ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE Category LIKE '%" & strFind & "%' ORDER BY Category, ItemCode"
                    End If

                Case Is = "Sub Category"

                    If UCase(cboInventoryStatus.Text) <> "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE SubCategory LIKE '%" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY SubCategory, ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE SubCategory LIKE '%" & strFind & "%' ORDER BY SubCategory, ItemCode"
                    End If

                Case Else

                    If UCase(cboInventoryStatus.Text) <> "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '%" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '%" & strFind & "%' ORDER BY ItemCode"
                    End If

            End Select
        Else
            Select Case cboSearchBy.Text
                Case Is = "Item Code"

                    If UCase(cboInventoryStatus.Text) <> "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '" & strFind & "%' ORDER BY ItemCode"
                    End If

                Case Is = "Description" 'Use the group name

                    If UCase(cboInventoryStatus.Text) <> "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE GroupName LIKE '" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY GroupName, ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE GroupName LIKE '" & strFind & "%' ORDER BY GroupName, ItemCode"
                    End If

                Case Is = "Category"

                    If UCase(cboInventoryStatus.Text) <> "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE Category LIKE '" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY Category, ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE Category LIKE '" & strFind & "%' ORDER BY Category, ItemCode"
                    End If

                Case Is = "Sub Category"

                    If UCase(cboInventoryStatus.Text) <> "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE SubCategory LIKE '" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY SubCategory, ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE SubCategory LIKE '" & strFind & "%' ORDER BY SubCategory, ItemCode"
                    End If

                Case Else

                    If UCase(cboInventoryStatus.Text) <> "ALL" Then
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '" & strFind & "%' AND Status = '" & cboInventoryStatus.Text & "' ORDER BY ItemCode"
                    Else
                        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                            & "FROM InventoryItems WHERE ItemCode LIKE '" & strFind & "%' ORDER BY ItemCode"
                    End If

            End Select
        End If

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        On Error Resume Next

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        grd.DataSource = dTable

        Me.grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        AlternateColors()
        For p As Integer = 0 To grd.Columns.Count - 1
            grd.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p = 2 Then grd.Columns(p).Visible = False
            If p = 3 Or p = 4 Then
                grd.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        'grd.Columns(2).Visible = False

        lblTotalSelected.Text = grd.RowCount
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Search"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
        Exit Sub
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("select ItemCode, GroupName as [Description], " _
            & "Category, SubCategory, CAST(SellingPrice AS DECIMAL (10,2)) AS [Sale Price], " _
            & "CAST(CostPrice AS DECIMAL (10,2)) AS [Cost Price], Quantity from inventoryitems " _
            & "ORDER BY Category, SubCategory, GroupName, ItemCode", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        'Assign the values to the print array
        Dim arrPrintData As New ArrayList
        While objReader.Read
            Dim strDataRow As String = Nothing
            For i As Integer = 0 To objReader.FieldCount - 1
                If i = 0 Then
                    If Not IsDBNull(objReader(i).ToString) Then strDataRow = objReader(i).ToString & ";" Else strDataRow = ";"
                Else
                    strDataRow = strDataRow & objReader(i).ToString & ";"
                End If
            Next
            strDataRow = Mid(strDataRow, 1, (strDataRow.Length - 1))
            arrPrintData.Add(strDataRow)
        End While
        objReader.Close()

        If arrPrintData.Count <= 0 Then
            MessageBox.Show("No details to print", "No Print Details", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        'Add the details to the print class print array

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 7
            .strColumnHeaders = "CODE|DESCRIPTION|CATEGORY|SUB CAT.|SALE $|COST $|"
            .strColumnAlignments = "0|0|0|0|2|2|2"
            .strColumnWidths = "175|175|90|80|65|65|0"
            .strFooterCaption = "Inventory Analysis Report "
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "INVENTORY REPORT"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|YES|YES|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = True
            .boolPrintTotals = True
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|YES|YES|NO"
            .intKeyFieldIndex = 3
            .strPrintValues = strPrintDetails
        End With
        If strRequestForReceiptPrinter = "YES" Then
            boolAbort = False
            gwt_comm.PrinterSelection()
            If boolAbort = True Then Exit Sub
            rpt.PrinterSettings.PrinterName = strSessionPrinter
        End If
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Report Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtSearchString_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchString.TextChanged
        SearchForItem("")
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 0 To grd.Rows.Count - 1
            For j As Integer = 0 To grd.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.White
                grd.Rows(i).Cells(j).Style.BackColor = backColor
                grd.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
        For i As Integer = 0 To grd.Rows.Count - 1 Step 2
            For j As Integer = 0 To grd.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                grd.Rows(i).Cells(j).Style.BackColor = backColor
                grd.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    'Private Sub btnUpdateCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim f As New frmCategoryUpdates
    '    f.ShowDialog()
    'End Sub

    Private Sub grd_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.Sorted
        AlternateColors()
    End Sub

    Private Sub btnExportCostPrices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportCostPrices.Click
        On Error GoTo RaiseErr
        Dim fd As New SaveFileDialog
        fd.ShowDialog()
        Dim strFileName As String = fd.FileName
        If String.IsNullOrEmpty(strFileName) Then
            MessageBox.Show("Please enter a valid file name", "Invalid File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        Dim objWriter As New System.IO.StreamWriter(strFileName, False)
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ItemCode +'|'+ CONVERT(NVARCHAR, CostPrice) +'|'+ CONVERT(NVARCHAR, SellingPrice) AS [Data] FROM InventoryItems", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            objWriter.WriteLine(Replace(objReader(0).ToString, Chr(34), "", 1))
        End While
        objReader.Close()
        objWriter.Close()
        Cursor = Cursors.Default
        MessageBox.Show("Details exported successfully", "Data Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On inventory prices export to file"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub DeleteSelectedItems()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrRemoveRows As New ArrayList
        If grd.Rows.Count > 0 Then
            'GetSelectedDetails()
            If MessageBox.Show("Are you sure you want to delete the selected items?", _
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                For i As Integer = 0 To grd.SelectedRows.Count - 1
                    strInventoryItemCode = grd.SelectedRows.Item(i).Cells(0).Value.ToString
                    Dim strSql As String = "SELECT [ItemCode],[GroupName],[Description],[SellingPrice]," _
                        & "[CostPrice],[Location],[Category],[SubCategory],[Quantity],[InventoryType]," _
                        & "[MinimumLevel],[WarningLevel],[IdealLevel],[TaxStatus],[SerialNumbers],[BarCodeNo]," _
                        & "[ItemColor],[Size],[UnitOfMeasure],[FullBarcodeSerialStatus],[Offering],[Status]," _
                        & "[ShortCode],[Uom],[MasterPackQty],[InnerPackQty],[CaseLength],[CaseWidth]," _
                        & "[CaseHeight],[CaseWeight],[ProductLength],[ProductWidth],[ProductHeight]," _
                        & "[ProductWeight],[DateIntroduced],[SoUomName],[SoUomRatioStd],[SoUomRatio]," _
                        & "[PoUomName],[PoUomRatioStd],[PoUomRatio],[SupplyPackaging],[SalesPackaging]," _
                        & "[SupplyPackagingQuantity],[SalesPackagingQuantity],[PackItemCostPrice]," _
                        & "[PackItemSalePrice],[CostCode],[TaxCode],[ItemShortCode] FROM InventoryItems WHERE ItemCode = '" & strInventoryItemCode & "'"
                    Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                    Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        strSql = "INSERT INTO InventoryItemsDeleted ([ItemCode],[GroupName],[Description],[SellingPrice]," _
                        & "[CostPrice],[Location],[Category],[SubCategory],[Quantity],[InventoryType]," _
                        & "[MinimumLevel],[WarningLevel],[IdealLevel],[TaxStatus],[SerialNumbers],[BarCodeNo]," _
                        & "[ItemColor],[Size],[UnitOfMeasure],[FullBarcodeSerialStatus],[Offering],[Status]," _
                        & "[ShortCode],[Uom],[MasterPackQty],[InnerPackQty],[CaseLength],[CaseWidth]," _
                        & "[CaseHeight],[CaseWeight],[ProductLength],[ProductWidth],[ProductHeight]," _
                        & "[ProductWeight],[DateIntroduced],[SoUomName],[SoUomRatioStd],[SoUomRatio]," _
                        & "[PoUomName],[PoUomRatioStd],[PoUomRatio],[SupplyPackaging],[SalesPackaging]," _
                        & "[SupplyPackagingQuantity],[SalesPackagingQuantity],[PackItemCostPrice]," _
                        & "[PackItemSalePrice],[CostCode],[TaxCode],[ItemShortCode], [UserName], [TransDate]) VALUES " _
                        & "('" & objReader("ItemCode") & "', '" & objReader("GroupName") & "', '" & objReader("Description") & "', " _
                        & "" & objReader("SellingPrice") & ", " & objReader("CostPrice") & ", " _
                        & "'" & objReader("Location") & "', '" & objReader("Category") & "', '" & objReader("SubCategory") & "', " & objReader("Quantity") & ", " _
                        & "'" & objReader("InventoryType") & "', " & objReader("MinimumLevel") & ", " & objReader("WarningLevel") & ", " & objReader("IdealLevel") & ", " _
                        & "'" & objReader("TaxStatus") & "', '" & objReader("SerialNumbers") & "', '" & objReader("BarCodeNo") & "', '" & objReader("ItemColor") & "', " _
                        & "'" & objReader("Size") & "', '" & objReader("UnitOfMeasure") & "', '" & objReader("FullBarcodeSerialStatus") & "', '" & objReader("Offering") & "', " _
                        & "'" & objReader("Status") & "', '" & objReader("ShortCode") & "', '" & objReader("Uom") & "', " & objReader("MasterPackQty") & ", " _
                        & "" & objReader("InnerPackQty") & ", " & objReader("CaseLength") & ", " & objReader("CaseWidth") & ", " & objReader("CaseHeight") & ", " _
                        & "" & objReader("CaseWeight") & ", " & objReader("ProductLength") & ", " & objReader("ProductWidth") & ", " & objReader("ProductHeight") & ", " _
                        & "" & objReader("ProductWeight") & ", '" & objReader("DateIntroduced") & "', '" & objReader("SoUomName") & "', '" & objReader("SoUomRatioStd") & "', " _
                        & "'" & objReader("SoUomRatio") & "', '" & objReader("PoUomName") & "', '" & objReader("PoUomRatioStd") & "', '" & objReader("PoUomRatio") & "', " _
                        & "'" & objReader("SupplyPackaging") & "', '" & objReader("SalesPackaging") & "', " & objReader("SupplyPackagingQuantity") & ", '" & objReader("SalesPackagingQuantity") & "', " _
                        & "" & objReader("PackItemCostPrice") & ", " & objReader("PackItemSalePrice") & ", " & objReader("CostCode") & ", '" & objReader("TaxCode") & "', " _
                        & "'" & objReader("ItemShortCode") & "', '" & strUserName & "', '" & Now & "')"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                    objReader.Close()

                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM InventoryItems WHERE Itemcode = '" & strInventoryItemCode & "'", cnn)
                    objCommand.ExecuteNonQuery()

                    'Store the deleted serial numbers as well
                    'SerialNumbersDeleted
                    strSql = "SELECT [ItemCode],[SerialNumber],[BarCodeNo],[SourceSerialNo],[Availability],[CostPrice] " _
                        & "FROM SerialNumbers WHERE ItemCode = '" & strInventoryItemCode & "'"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objReader = objCommand.ExecuteReader
                    While objReader.Read
                        strSql = "INSERT INTO SerialNumbersDeleted ([ItemCode],[SerialNumber],[BarCodeNo],[SourceSerialNo]," _
                            & "[Availability],[CostPrice], [UserName], [TransDate]) VALUES ('" & objReader(0) & "', " _
                            & "'" & objReader(1) & "', '" & objReader(2) & "', '" & objReader(3) & "', " _
                            & "'" & objReader(4) & "', " & objReader(5) & ", '" & strUserName & "', '" & Now & "')"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End While
                    objReader.Close()
                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers WHERE Itemcode = '" & strInventoryItemCode & "'", cnn)
                    objCommand.ExecuteNonQuery()
                    arrRemoveRows.Add(grd.SelectedRows.Item(i).Index)
                Next

                'Delete all the selected items from the grid
                'LoadData()
                For i As Integer = 0 To arrRemoveRows.Count - 1
                    grd.Rows.RemoveAt(CInt(arrRemoveRows.Item(i)))
                Next
                MessageBox.Show("Inventory Item Deleted successfully", "Inventory Item Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On inventory item delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        DeleteSelectedItems()
    End Sub

    Private Sub btnChangeCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeCodes.Click
        boolCalledFromListing = False
        Dim f As New frmInventoryCodeChange
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnMergeItemCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMergeItemCodes.Click
        Dim f As New frmInventoryCodesMerge
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub DeactivateInventoryItems()
        On Error GoTo RaiseErr
        If grd.Rows.Count <= 0 Then
            MessageBox.Show("Process cannot be executed as there are no inventory items", "No Inventory Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim arrRemoveRows As New ArrayList
        Cursor = Cursors.WaitCursor
        If MessageBox.Show("Are you sure you want to de-activate the selected inventory items?", "Confirm De-activation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            'GetSelectedDetails()

            For i As Integer = 0 To grd.SelectedRows.Count - 1
                strInventoryItemCode = grd.SelectedRows.Item(i).Cells(0).Value.ToString
                'Check that the quantity is zero and that there are no serial numbers attached
                Dim dblQty As Double = 0
                Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then dblQty = CDbl(objReader(0).ToString)
                End If
                objReader.Close()
                If dblQty <> 0 Then
                    MessageBox.Show("Item cannot be de-activated until you have resolved the quantity issue." & vbCrLf & _
                        "Currently there are " & dblQty & " units of this item in stock", _
                        "Process Cannot Proceed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                'Check the serial numbers as well
                Dim dblSerialCnt As Double = 0
                objCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(ItemCode) FROM SerialNumbers WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then dblSerialCnt = CDbl(objReader(0).ToString)
                End If
                objReader.Close()
                If dblSerialCnt <> 0 Then
                    MessageBox.Show("Item cannot be de-activated until you have resolved the serial numbers issue." & vbCrLf & _
                        "Currently there are " & dblSerialCnt & " units of this item in serial numbers", _
                        "Process Cannot Proceed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                objCommand = New Data.OleDb.OleDbCommand("Update InventoryItems SET Status = 'INACTIVE' " _
                    & "WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
                objCommand.ExecuteNonQuery()

                arrRemoveRows.Add(grd.SelectedRows.Item(i).Index)

            Next

            'Delete all the selected items from the grid
            'LoadData()
            For i As Integer = 0 To arrRemoveRows.Count - 1
                grd.Rows.RemoveAt(CInt(arrRemoveRows.Item(i)))
            Next
            MessageBox.Show("Inventory item de-activated from active inventory items", "Inventory De-activation", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Inventory De-activation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDeactivateOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeactivateOne.Click
        '        On Error GoTo RaiseErr
        '        If grd.Rows.Count <= 0 Then
        '            MessageBox.Show("Process cannot be executed as there are no inventory items", MsgBoxStyle.Exclamation, "No Inventory Items")
        '            Exit Sub
        '        End If
        '        If MessageBox.Show("Are you sure you want to de-activate this inventory item?", vbYesNo, "Confirm De-activation") = vbYes Then
        '            GetSelectedDetails()
        '            'Check that the quantity is zero and that there are no serial numbers attached
        '            Dim dblQty As Double = 0
        '            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
        '            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        '            If objReader.HasRows Then
        '                objReader.Read()
        '                If IsNumeric(objReader(0).ToString) Then dblQty = CDbl(objReader(0).ToString)
        '            End If
        '            objReader.Close()
        '            If dblQty <> 0 Then
        '                MessageBox.Show("Item cannot be de-activated until you have resolved the quantity issue." & vbCrLf & "Currently there are " & dblQty & " units of this item in stock", MsgBoxStyle.Exclamation, "Process Cannot Proceed")
        '                Exit Sub
        '            End If

        '            'Check the serial numbers as well
        '            Dim dblSerialCnt As Double = 0
        '            objCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(ItemCode) FROM SerialNumbers WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
        '            objReader = objCommand.ExecuteReader
        '            If objReader.HasRows Then
        '                objReader.Read()
        '                If IsNumeric(objReader(0).ToString) Then dblSerialCnt = CDbl(objReader(0).ToString)
        '            End If
        '            objReader.Close()
        '            If dblSerialCnt <> 0 Then
        '                MessageBox.Show("Item cannot be de-activated until you have resolved the serial numbers issue." & vbCrLf & "Currently there are " & dblSerialCnt & " units of this item in serial numbers", MsgBoxStyle.Exclamation, "Process Cannot Proceed")
        '                Exit Sub
        '            End If

        '            objCommand = New Data.OleDb.OleDbCommand("Update InventoryItems SET Status = 'INACTIVE' " _
        '                & "WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
        '            objCommand.ExecuteNonQuery()
        '            LoadData()
        '            MessageBox.Show("Inventory item de-activated from active inventory items", MsgBoxStyle.Information, "Inventory De-activation")
        '        End If
        '        Exit Sub
        'RaiseErr:
        '        boolAbort = True
        '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Inventory De-activation"
        '        ShowErrorMessage()
        DeactivateInventoryItems()
    End Sub

    Private Sub btnManageCosts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManageCosts.Click
        Dim f As New frmInventoryCostsMassUpdate
        f.ShowDialog()
    End Sub

    Private Sub btnChangeSerial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeSerial.Click
        Dim f As New frmSerialCodeChange
        f.ShowDialog()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrData As New ArrayList
        Dim strCurrentRecord As String = Nothing
        Dim strSql As String = "SELECT [ItemCode],[GroupName],[Description],[SellingPrice],[CostPrice],[Location]," _
            & "[Category],[SubCategory],[Quantity],[InventoryType],[MinimumLevel],[WarningLevel]," _
            & "[IdealLevel],[TaxStatus],[BarCodeNo],[ItemColor],[Size],[UnitOfMeasure]," _
            & "[FullBarcodeSerialStatus],[Offering],[Status],[Uom],[MasterPackQty]," _
            & "[InnerPackQty],[CaseLength],[CaseWidth],[CaseHeight],[CaseWeight],[ProductLength]," _
            & "[ProductWidth],[ProductHeight],[ProductWeight],[SoUomName],[SoUomRatioStd]," _
            & "[SoUomRatio],[PoUomName],[PoUomRatioStd],[PoUomRatio],[SupplyPackaging],[SalesPackaging]," _
            & "[SupplyPackagingQuantity],[SalesPackagingQuantity],[PackItemCostPrice],[PackItemSalePrice],[CostCode] FROM InventoryItems"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO InventoryItems ([ItemCode],[GroupName],[Description]," _
                & "[SellingPrice],[CostPrice],[Location],[Category],[SubCategory],[Quantity],[InventoryType]," _
                & "[MinimumLevel],[WarningLevel],[IdealLevel],[TaxStatus],[BarCodeNo]," _
                & "[ItemColor],[Size],[UnitOfMeasure],[FullBarcodeSerialStatus],[Offering],[Status]," _
                & "[Uom],[MasterPackQty],[InnerPackQty],[CaseLength],[CaseWidth],[CaseHeight]," _
                & "[CaseWeight],[ProductLength],[ProductWidth],[ProductHeight],[ProductWeight]," _
                & "[SoUomName],[SoUomRatioStd],[SoUomRatio],[PoUomName],[PoUomRatioStd],[PoUomRatio]," _
                & "[SupplyPackaging],[SalesPackaging],[SupplyPackagingQuantity],[SalesPackagingQuantity]," _
                & "[PackItemCostPrice],[PackItemSalePrice],[CostCode]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If Not IsDBNull(objReader(p).ToString) Then
                    If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                        If objReader.GetFieldType(p) Is GetType(Date) Then
                            If IsDate(objReader(p).ToString) Then
                                strLine = strLine & "'" & objReader(p).ToString & "', "
                            Else
                                strLine = strLine & "" & "NULL" & ", "
                            End If
                        Else
                            Dim strFieldData As String = ""
                            If Not IsDBNull(objReader(p).ToString) Then
                                strFieldData = Replace(objReader(p), "'", "", 1)
                                Replace(objReader(p), vbCrLf, " ", 1)
                            End If
                            strLine = strLine & "'" & strFieldData & "', "
                        End If
                    Else
                        If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                            strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                        Else
                            strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                        End If
                    End If
                Else
                    strLine = strLine & "'', "
                End If
                strCurrentRecord = strLine
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
        End While
        objReader.Close()

        Dim ofd As New SaveFileDialog
        Dim strFilename As String = Nothing
        ofd.ShowDialog()
        strFilename = ofd.FileName

        With frmLight8.pb1
            .Value = 0
            .Maximum = arrData.Count + 5
            .Visible = True
        End With

        If Not String.IsNullOrEmpty(strFilename) Then
            Dim objWriter As New System.IO.StreamWriter(strFilename, False)
            For i As Integer = 0 To arrData.Count - 1
                objWriter.WriteLine(arrData.Item(i))
                frmLight8.pb1.Value = frmLight8.pb1.Value + 1
            Next
            objWriter.Close()
        End If

        MessageBox.Show("Inventory data has been successfully written to file", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Inventory De-activation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub mnuDeleteSelection_Click(sender As Object, e As EventArgs) Handles mnuDeleteSelection.Click
        DeleteSelectedItems()
    End Sub

    Private Sub btnViewDeletedInventory_Click(sender As System.Object, e As System.EventArgs) Handles btnViewDeletedInventory.Click
        Dim f As New frmInventoryItemsDeletedListing
        f.ShowDialog()
    End Sub

    Private Sub btnQuantityFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuantityFilter.Click
        boolAbort = False
        Dim f As New frmInventoryQuantityFilter
        f.ShowDialog()
        If boolAbort = True Then Exit Sub

        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
            & "AS [Cost Price], Location, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
            & "FROM InventoryItems WHERE Quantity BETWEEN " & dblPublicQuantityFilterMinimum & " AND " _
            & "" & dblPublicQuantityFilterMaximum & " ORDER BY Quantity, ItemCode"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        grd.DataSource = dTable

        Me.grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        AlternateColors()
        For p As Integer = 0 To grd.Columns.Count - 1
            grd.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p = 2 Then grd.Columns(p).Visible = False
            If p = 3 Or p = 4 Then
                grd.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        AlternateColors()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Load By Quantity"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub cboInventoryStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboInventoryStatus.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub mnuCopySelected_Click(sender As System.Object, e As System.EventArgs) Handles mnuCopySelected.Click
        If Me.grd.GetCellCount( _
            DataGridViewElementStates.Selected) > 0 Then
            Try
                ' Add the selection to the clipboard.
                Clipboard.SetDataObject( _
                    Me.grd.GetClipboardContent())
            Catch ex As System.Runtime.InteropServices.ExternalException
                strErrorMessages = ex.Message & vbCrLf & "Failed to copy to clip board"
                gwt_comm.ShowErrorMessage()
            End Try
        End If
    End Sub

    Private Sub UpdatePackQuantity()
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Or IntPublicInventory > 0 Then
            boolAbort = False
            Dim CurrentCellValue As String
            CurrentCellValue = grd.CurrentRow.Cells(0).Value
            strSelectedCodeDescription = grd.CurrentRow.Cells(1).Value
            strActiviteStatus = grd.CurrentRow.Cells(6).Value
            strInventoryItemCode = CurrentCellValue
            Dim frm As New frmPackSize
            frm.ShowDialog()
            If boolAbort = True Then Exit Sub
            SearchForItem("")
        Else
            MessageBox.Show("You do not have the right to access this part of the system", _
                "Invoking Unauthorised Access", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
    End Sub

    Private Sub mnuConvertPackToSingle_Click(sender As System.Object, e As System.EventArgs) Handles mnuConvertPackToSingle.Click
        If grd.RowCount <= 0 Then Exit Sub
        UpdatePackQuantity()
    End Sub

    Private Sub mnuSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuSelectAll.Click
        grd.SelectAll()
    End Sub

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        Dim frm As New frmInventoryImportFromFile
        frm.ShowDialog()
    End Sub

End Class
