Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventoryStockTakeCount

    Private Sub frmInventoryStockTakeCount_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If UCase(strDefaultSearchFilter) = "DESCRIPTION" Then cboSearchBy.SelectedIndex = 1 Else cboSearchBy.SelectedIndex = 0
        InitializeStockTable()
        LoadData()
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If e.ColumnIndex = 3 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                'dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
                'update the table values and compute the variance
                UpdateValues(dGrid.CurrentCell.Value, dGrid.CurrentRow.Cells(0).Value.ToString)
                dGrid.CurrentRow.Cells(4).Value = CInt(dGrid.CurrentRow.Cells(2).Value.ToString) - CInt(dGrid.CurrentCell.Value)
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
        End If
    End Sub

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub UpdateValues(StockQuantity, ItemCode)
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE InventoryStockTake SET Quantity = " & StockQuantity & " " _
            & "WHERE ItemCode = '" & ItemCode & "'", cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Stock Take Count Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        Try
            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                'In order to prevent optical problems, we had to call the removeHandler twice
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim strViewStatus As String = "ALL"
        strSql = "SELECT InventoryItems.ItemCode as [Item Code], InventoryItems.GroupName as [General Description], " _
            & "InventoryItems.Quantity AS [System], InventoryStockTake.Quantity AS [Actual], " _
            & "(InventoryItems.Quantity - InventoryStockTake.Quantity) AS [Variance] " _
            & "FROM InventoryItems LEFT OUTER JOIN InventoryStockTake ON InventoryItems.ItemCode = InventoryStockTake.ItemCode " _
            & "ORDER BY InventoryItems.ItemCode"

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        If UCase(strUserLevel) <> "MANAGER" Then
            If UCase(strUserLevel) <> "ADMINISTRATOR" Then
                dGrid.Columns(4).Visible = False
            End If
        End If

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            If p = 2 Or p = 3 Or p = 4 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            If p = 2 Then
                dGrid.Columns(p).ReadOnly = True
            Else
                dGrid.Columns(p).ReadOnly = False
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Items Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        strActiveSearch = strFind
        Cursor = Cursors.WaitCursor

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim strSql As String = Nothing

        On Error GoTo RaiseErr

        Select Case cboSearchBy.Text
            Case Is = "Item Code"
                strSql = "SELECT InventoryItems.ItemCode as [Item Code], InventoryItems.GroupName as [Description], " _
                    & "InventoryItems.Quantity AS [System], InventoryStockTake.Quantity AS [Actual], " _
                    & "(InventoryItems.Quantity - InventoryStockTake.Quantity) AS [Variance] " _
                    & "FROM InventoryItems LEFT OUTER JOIN InventoryStockTake ON InventoryItems.ItemCode = InventoryStockTake.ItemCode " _
                    & "WHERE InventoryItems.ItemCode LIKE '%" & strFind & "%' ORDER BY InventoryItems.ItemCode"
            Case Is = "Description" 'Use the group name
                strSql = "SELECT InventoryItems.ItemCode as [Item Code], InventoryItems.GroupName as [General Description], " _
                    & "InventoryItems.Quantity AS [System], InventoryStockTake.Quantity AS [Actual], " _
                    & "(InventoryItems.Quantity - InventoryStockTake.Quantity) AS [Variance] " _
                    & "FROM InventoryItems LEFT OUTER JOIN InventoryStockTake ON InventoryItems.ItemCode = InventoryStockTake.ItemCode " _
                    & "WHERE GroupName LIKE '%" & strFind & "%' ORDER BY GroupName, InventoryItems.ItemCode"
            Case Else
                strSql = "SELECT InventoryItems.ItemCode as [Item Code], InventoryItems.GroupName as [General Description], " _
                    & "InventoryItems.Quantity AS [System], InventoryStockTake.Quantity AS [Actual], " _
                    & "(InventoryItems.Quantity - InventoryStockTake.Quantity) AS [Variance] " _
                    & "FROM InventoryItems LEFT OUTER JOIN InventoryStockTake ON InventoryItems.ItemCode = InventoryStockTake.ItemCode " _
                    & "WHERE InventoryItems.ItemCode LIKE '%" & strFind & "%' ORDER BY InventoryItems.ItemCode"
        End Select

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            If p = 2 Or p = 3 Or p = 4 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            If p = 2 Then
                dGrid.Columns(p).ReadOnly = True
            Else
                dGrid.Columns(p).ReadOnly = False
            End If
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Search"
        gwt_comm.ShowErrorMessage()
        Exit Sub
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("select ItemCode, GroupName as [Description], " _
            & "Category, SubCategory, CAST(SellingPrice AS DECIMAL (30,2)) AS [Sale Price], " _
            & "CAST(CostPrice AS DECIMAL (30,2)) AS [Cost Price], Quantity from inventoryitems " _
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
            .strColumnHeaders = "CODE|DESCRIPTION|CATEGORY|SUB CATEGORY|SALE $|COST $|QTY"
            .strColumnAlignments = "0|0|0|0|2|2|2"
            .strColumnWidths = "120|140|140|80|50|50|50"
            .strFooterCaption = "Inventory Analysis Report "
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "INVENTORY REPORT"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|YES|YES|YES"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("LightGray")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = True
            .boolPrintTotals = True
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|YES|YES|YES"
            .intKeyFieldIndex = 3
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Report Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtSearchString_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchString.TextChanged
        SearchForItem("")
    End Sub

    Private Sub InitializeStockTable()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT COUNT(ItemCode) FROM InventoryStockTake"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim intCount As Integer = 0
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intCount = CInt(objReader(0).ToString)
        End If
        objReader.Close()
        If intCount <= 0 Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT ItemCode FROM InventoryItems ORDER BY ItemCode", cnn)
            objReader = objCommand.ExecuteReader
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO InventoryStockTake ([ItemCode], [TransDate], [UserName]) VALUES " _
                        & "('" & objReader(0).ToString & "', '" & gwt_comm.shortMonthDateFormat(Now) & "', '" & strUserName & "')", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End While
            objReader.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Stock Code Details Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        With pb1
            .Value = 0
            .Maximum = dGrid.Rows.Count
            .Visible = True
        End With

        For p As Integer = 0 To dGrid.RowCount - 1

            Dim strCode As String = Nothing
            Dim dblQty As Double = 0

            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strCode = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(3).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(3).Value.ToString) Then
                        dblQty = CDbl(dGrid.Rows(p).Cells(3).Value.ToString)
                    End If
                End If
            End If

            Dim objCommand As Data.OleDb.OleDbCommand
            'Update the variance table with old values
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO InventoryCounts(ItemCode, TransDate, Quantity, UserName, BranchName) " _
                & "VALUES ('" & strCode & "', '" & gwt_comm.shortMonthDateFormat(Now) & "', " & dblQty & ", '" & strUserName & "', '" & strUserBranch & "')", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers WHERE ItemCode = '" & strCode & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = " & dblQty & " WHERE ItemCode = '" & strCode & "'", cnn)
            objCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1

        Next

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Stock Code Details Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmInventoryStockTakeCount_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 640 : Me.Height = 490
    End Sub

End Class
