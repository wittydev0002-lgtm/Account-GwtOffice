Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmReceivedDrugOrdersListing

    Private Sub LoadSuppliers()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM Suppliers ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboSuppliers
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "200;60"
        End With

        Dim arrItems As New ArrayList
        arrItems.Add("--ALL--;0")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Get a count of the items
        Dim intItemsCount As Integer = arrItems.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboSuppliers.Items.Clear()
        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        objReader.Close()
        If intItemsCount > 0 Then
            cboSuppliers.SelectedIndex = -1
            cboSuppliers.Items.Clear()
            cboSuppliers.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboSuppliers.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Supplier Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmReceivedDrugOrdersListing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadSuppliers()
    End Sub

    Private Sub LoadData(ByVal DateFrom As Date, ByVal DateTo As Date, ByVal SupplierId As String)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        If UCase(SupplierId) = "0" Then
            strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), " _
                & "OchmasReceivedDrugs.TransactionDate, 105), ' ', '-')) as [Date], Suppliers.AccountName AS [Supplier], " _
                & "OchmasReceivedDrugs.ReferenceNumber AS [Ref.#], OchmasReceivedDrugs.OrderNumber AS [Order #], " _
                & "CAST(SUM(OchmasReceivedDrugs.OrderPrice) AS DECIMAL (10,2)) AS [Cost], " _
                & "CAST(SUM(OchmasReceivedDrugs.Taxes) AS DECIMAL (10,2)) AS [Taxes], " _
                & "CAST(SUM(OchmasReceivedDrugs.Payable) AS DECIMAL (10,2)) AS [Payable], " _
                & "OchmasReceivedDrugs.SupplierId FROM OchmasReceivedDrugs LEFT OUTER JOIN Suppliers ON " _
                & "OchmasReceivedDrugs.SupplierId = Suppliers.AccountNumber WHERE OchmasReceivedDrugs.TransactionDate " _
                & "BETWEEN '" & Format(DateFrom, "dd-MMM-yyyy") & "' AND '" & Format(DateTo, "dd-MMM-yyyy") & "' " _
                & "GROUP BY OchmasReceivedDrugs.TransactionDate, " _
                & "Suppliers.AccountName, OchmasReceivedDrugs.ReferenceNumber, OchmasReceivedDrugs.OrderNumber, " _
                & "OchmasReceivedDrugs.SupplierId"
        Else
            strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), " _
                & "OchmasReceivedDrugs.TransactionDate, 105), ' ', '-')) as [Date], Suppliers.AccountName AS [Supplier], " _
                & "OchmasReceivedDrugs.ReferenceNumber AS [Ref.#], OchmasReceivedDrugs.OrderNumber AS [Order #], " _
                & "CAST(SUM(OchmasReceivedDrugs.OrderPrice) AS DECIMAL (10,2)) AS [Cost], " _
                & "CAST(SUM(OchmasReceivedDrugs.Taxes) AS DECIMAL (10,2)) AS [Taxes], " _
                & "CAST(SUM(OchmasReceivedDrugs.Payable) AS DECIMAL (10,2)) AS [Payable], " _
                & "OchmasReceivedDrugs.SupplierId FROM OchmasReceivedDrugs LEFT OUTER JOIN Suppliers ON " _
                & "OchmasReceivedDrugs.SupplierId = Suppliers.AccountNumber WHERE OchmasReceivedDrugs.TransactionDate " _
                & "BETWEEN '" & Format(DateFrom, "dd-MMM-yyyy") & "' AND '" & Format(DateTo, "dd-MMM-yyyy") & "' AND " _
                & "OchmasReceivedDrugs.SupplierId = '" & SupplierId & "' GROUP BY OchmasReceivedDrugs.TransactionDate, " _
                & "Suppliers.AccountName, OchmasReceivedDrugs.ReferenceNumber, OchmasReceivedDrugs.OrderNumber, " _
                & "OchmasReceivedDrugs.SupplierId"
        End If

        'Populate the all sales grid
        dGrid.Columns.Clear()
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        For p As Integer = 0 To dGrid.ColumnCount - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p > 3 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            If p = dGrid.Columns.Count - 1 Then dGrid.Columns(p).Visible = False
        Next

        'Compute the grid totals
        Dim dblCost As Double = 0
        Dim dblTaxes As Double = 0
        Dim dblPayable As Double = 0

        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(4).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(4).Value.ToString) Then
                        dblCost = dblCost + CDbl(dGrid.Rows(p).Cells(4).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(5).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(5).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(5).Value.ToString) Then
                        dblTaxes = dblTaxes + CDbl(dGrid.Rows(p).Cells(5).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(6).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(6).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(6).Value.ToString) Then
                        dblPayable = dblPayable + CDbl(dGrid.Rows(p).Cells(6).Value.ToString)
                    End If
                End If
            End If
        Next

        lblCost.Text = Format(dblCost, "##0.00")
        lblTaxes.Text = Format(dblTaxes, "##0.00")
        lblPayable.Text = Format(dblPayable, "##0.00")

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Supplier Orders Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnAnalyse_Click(sender As System.Object, e As System.EventArgs) Handles btnAnalyse.Click
        LoadData(dpStartFrom.Value, dpEndTo.Value, txtSupplierId.Text)
    End Sub

    Private Sub cboSuppliers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSuppliers.SelectedIndexChanged
        txtSupplierId.Text = Nothing
        txtSupplierId.Text = cboSuppliers.SelectedItem.Col2
    End Sub

    Private Sub GetSelected()
        If dGrid.Rows.Count <= 0 Then Exit Sub
        If Not Object.Equals(dGrid.CurrentRow.Cells(2).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(2).Value.ToString) Then
                If IsNumeric(dGrid.CurrentRow.Cells(2).Value.ToString) Then
                    intSelectedOrderEntryId = CInt(dGrid.CurrentRow.Cells(2).Value.ToString)
                End If
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As System.EventArgs) Handles btnEdit.Click
        boolEditStatus = True
        GetSelected()
        'boolAbort = False
        Me.Close()
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        boolEditStatus = True
        GetSelected()
        'boolAbort = False
        Me.Close()
    End Sub

    Private Sub KryptonPanel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles KryptonPanel.Paint

    End Sub
End Class
