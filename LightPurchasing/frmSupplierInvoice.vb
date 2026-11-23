Imports System.ComponentModel
Imports CommonLibrary.Commons

Public Class frmSupplierInvoice

    '    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
    '        If e.KeyChar = "." Then Exit Sub
    '        If e.KeyChar = "-" Then Exit Sub
    '        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    '    End Sub

    '    Private Sub frmSupplierInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '        dGrid.Columns.Clear()
    '        LoadSuppliers()
    '        If UCase(strTaxComputationType) = "INCLUSIVE" Then
    '            optInclusive.Checked = True
    '            optExclusive.Checked = False
    '        Else
    '            optExclusive.Checked = True
    '            optInclusive.Checked = False
    '        End If
    '    End Sub

    '    Private Function RowTotal(ByVal dblUnitPrice As Double, ByVal dblQuantity As Double, ByVal dblTax As Double) As Double
    '        Dim dblReturn As Double = 0
    '        dblReturn = (dblUnitPrice * dblQuantity) + dblTax
    '        If optInclusive.Checked = True Then
    '            dblReturn = dblUnitPrice * dblQuantity

    '        End If
    '        Return dblReturn
    '    End Function

    '    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
    '        If dGrid.CurrentCell.ColumnIndex = 3 Or dGrid.CurrentCell.ColumnIndex = 5 Then
    '            If IsNumeric(dGrid.CurrentCell.Value) Then

    '                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")

    '                Dim dblTax As Double = 0
    '                Dim dblUnitPrice As Double = 0
    '                Dim dblQuantity As Double = 0


    '                If Not Object.Equals(dGrid.CurrentRow.Cells(3).Value, Nothing) Then
    '                    If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(3).Value.ToString) Then
    '                        If IsNumeric(dGrid.CurrentRow.Cells(3).Value.ToString) Then
    '                            dblUnitPrice = CDbl(dGrid.CurrentRow.Cells(3).Value.ToString)
    '                        End If
    '                    End If
    '                End If
    '                If Not Object.Equals(dGrid.CurrentRow.Cells(4).Value, Nothing) Then
    '                    If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(4).Value.ToString) Then
    '                        If IsNumeric(dGrid.CurrentRow.Cells(4).Value.ToString) Then
    '                            dblQuantity = CDbl(dGrid.CurrentRow.Cells(4).Value.ToString)
    '                        End If
    '                    End If
    '                End If
    '                If Not Object.Equals(dGrid.CurrentRow.Cells(5).Value, Nothing) Then
    '                    If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(5).Value.ToString) Then
    '                        If IsNumeric(dGrid.CurrentRow.Cells(5).Value.ToString) Then
    '                            dblTax = CDbl(dGrid.CurrentRow.Cells(5).Value.ToString)
    '                        End If
    '                    End If
    '                End If

    '                Dim dblTotal As Double = RowTotal(dblUnitPrice, dblQuantity, dblTax)
    '                dGrid.Rows(dGrid.CurrentRow.Index).Cells(6).Value = Format(dblTotal, "##0.00")

    '                ComputeTotal()

    '            Else
    '                dGrid.CurrentCell.Value = "0.00"
    '            End If
    '        End If
    '    End Sub

    '    Private Sub ComputeTotal()
    '        On Error GoTo RaiseErr

    '        Dim dblAmount As Double = 0
    '        Dim dblTax As Double = 0

    '        For p As Integer = 0 To dGrid.RowCount - 1
    '            If Not Object.Equals(dGrid.Rows(p).Cells(6).Value, Nothing) Then
    '                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(6).Value.ToString) Then
    '                    If IsNumeric(dGrid.Rows(p).Cells(6).Value.ToString) Then
    '                        dblAmount = dblAmount + CDbl(dGrid.Rows(p).Cells(6).Value.ToString)
    '                    End If
    '                End If
    '            End If
    '            If Not Object.Equals(dGrid.Rows(p).Cells(5).Value, Nothing) Then
    '                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(5).Value.ToString) Then
    '                    If IsNumeric(dGrid.Rows(p).Cells(5).Value.ToString) Then
    '                        dblTax = dblTax + CDbl(dGrid.Rows(p).Cells(5).Value.ToString)
    '                    End If
    '                End If
    '            End If
    '        Next

    '        lblSubTotal.Text = Format((dblAmount - dblTax), "##0.00")

    '        lblTaxes.Text = Format(dblTax, "##0.00")

    '        lblTaxable.Text = Format(CDbl(lblSubTotal.Text) - CDbl(lblDiscounts.Text), "##0.00")
    '        lblPayable.Text = Format(CDbl(lblTaxable.Text) + CDbl(lblTaxes.Text), "##0.00")
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Total Computation"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    '    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGrid.EditingControlShowing
    '        If String.IsNullOrEmpty(strPublicActiveCashbook) Then Exit Sub
    '        Try
    '            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
    '                AddHandler e.Control.KeyPress, AddressOf CheckCell
    '            Else
    '                'In order to prevent optical problems, we had to call the removeHandler twice
    '                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
    '                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
    '            End If
    '        Catch ex As Exception

    '        End Try
    '    End Sub

    '    Private Sub LoadSuppliers()
    '        On Error GoTo RaiseErr
    '        Dim strSql As String = Nothing
    '        strSql = "SELECT AccountName +';'+AccountNumber AS " _
    '            & "[Accounts] FROM Suppliers ORDER BY AccountName"
    '        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
    '        'Set up the drop down combo box
    '        With cboSuppliers
    '            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
    '            .ColumnNum = 2
    '            .HighlightBorderOnMouseEvents = True
    '            .ManagingFastMouseMoving = True
    '            .Enabled = True
    '            .DropDownHeight = 110
    '            .GridLineHorizontal = True
    '            .GridLineVertical = True
    '            .ColumnWidth = "250;100"
    '        End With
    '        'Get a count of the items
    '        Dim intItemsCount As Integer = 0
    '        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM Suppliers", cnn)
    '        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
    '        If objCount.HasRows Then
    '            objCount.Read()
    '            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
    '        End If
    '        objCount.Close()
    '        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

    '        cboSuppliers.Items.Clear()
    '        Dim i As Integer = 0
    '        Dim p As Integer = 0
    '        'Continue to read until you reach the end of the file.
    '        While objReader.Read
    '            'File the listview with details.
    '            If Not IsDBNull(objReader(0).ToString) Then
    '                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
    '                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
    '            End If
    '            p = p + 1
    '        End While
    '        objReader.Close()
    '        With cboSuppliers
    '            If intItemsCount > 0 Then
    '                .SelectedIndex = -1
    '                .Items.Clear()
    '                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
    '                .Items.AddRange(DropDownItems)
    '            End If
    '        End With
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On supplier details load"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    '    Private Sub cboSuppliers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSuppliers.SelectedIndexChanged
    '        lblSupplierId.Text = Nothing
    '        btnLoad.Enabled = False
    '        If Not Object.Equals(cboSuppliers.SelectedItem, Nothing) Then
    '            lblSupplierId.Text = cboSuppliers.SelectedItem.Col2.ToString
    '            btnLoad.Enabled = True
    '        End If
    '    End Sub

    '    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click
    '        If dGrid.RowCount <= 0 Then
    '            MessageBox.Show("There are no transactions to post. Process will be terminated", "Missing Transactions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            Exit Sub
    '        End If
    '        On Error GoTo RaiseErr

    '        dblSelectedBatchTotal = CDbl(lblPayable.Text)
    '        strSelectedAccount = lblSupplierId.Text
    '        strSelectedAccountName = cboSuppliers.Text
    '        Dim frm As New frmReceivedOrdersAccountsPosting
    '        frm.ShowDialog()

    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On supplier invoice save"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    '    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
    '        If String.IsNullOrEmpty(lblSupplierId.Text) Then
    '            MessageBox.Show("Please select the supplier", "Missing Supplier Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '            cboSuppliers.Focus()
    '            Exit Sub
    '        End If
    '        strSelectedAccount = lblSupplierId.Text
    '        boolAbort = False
    '        Dim frm As New frmSupplierOrdersListing
    '        frm.ShowDialog()
    '        If boolAbort = True Then Exit Sub
    '        LoadSelectedBatchData()
    '    End Sub

    '    Private Sub LoadSelectedBatchData()

    '        On Error GoTo RaiseErr

    '        Dim strSql As String = "SELECT OrdersReceipt.ItemCode AS [Item Code], InventoryItems.GroupName AS [Description], " _
    '            & "OrdersReceipt.BaseBarcode + ''+ OrdersReceipt.SerialNumbers AS [Serial No.], CAST(OrdersReceipt.CostPrice " _
    '            & "AS DECIMAL (10,2)) AS [Unit Price], OrdersReceipt.Quantity AS [Qty], OrdersReceipt.VatAmount AS [VAT], " _
    '            & "CAST(((OrdersReceipt.CostPrice * OrdersReceipt.Quantity) + OrdersReceipt.VatAmount) AS DECIMAL (10,2)) AS [Total], OrdersReceipt.TransactionId " _
    '            & "FROM OrdersReceipt LEFT OUTER JOIN InventoryItems ON " _
    '            & "OrdersReceipt.ItemCode = InventoryItems.ItemCode WHERE OrdersReceipt.BatchNo = " & intSelectedBatchNumber & " " _
    '            & "ORDER BY OrdersReceipt.TransactionId"

    '        With dGrid
    '            .Columns.Clear()
    '            Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
    '            cmd.CommandType = CommandType.Text

    '            Dim da As New OleDb.OleDbDataAdapter(cmd)
    '            Dim dTable As New DataTable()
    '            da.Fill(dTable)
    '            .DataSource = dTable

    '            '.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '            .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

    '            For p As Integer = 0 To .Columns.Count - 1
    '                .Columns(p).ReadOnly = True
    '                .Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    '                If p >= 3 Then
    '                    .Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                End If
    '            Next
    '            .Columns(.ColumnCount - 1).Visible = False
    '            .Columns(3).ReadOnly = False
    '            .Columns(5).ReadOnly = False
    '        End With
    '        ComputeTotal()
    '        Cursor = Cursors.Default
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Received Orders Ledger Posting"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    '    Private Sub optInclusive_CheckedChanged(sender As Object, e As EventArgs)
    '        RecalculateValues()
    '    End Sub

    '    Private Sub optExclusive_CheckedChanged(sender As Object, e As EventArgs)
    '        RecalculateValues()
    '    End Sub

    '    Private Sub RecalculateValues()
    '        On Error GoTo RaiseErr
    '        For p As Integer = 0 To dGrid.Rows.Count - 1

    '            Dim dblTax As Double = 0
    '            Dim dblUnitPrice As Double = 0
    '            Dim dblQuantity As Double = 0

    '            If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
    '                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(3).Value.ToString) Then
    '                    If IsNumeric(dGrid.Rows(p).Cells(3).Value.ToString) Then
    '                        dblUnitPrice = CDbl(dGrid.Rows(p).Cells(3).Value.ToString)
    '                    End If
    '                End If
    '            End If
    '            If Not Object.Equals(dGrid.Rows(p).Cells(4).Value, Nothing) Then
    '                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(4).Value.ToString) Then
    '                    If IsNumeric(dGrid.Rows(p).Cells(4).Value.ToString) Then
    '                        dblQuantity = CDbl(dGrid.Rows(p).Cells(4).Value.ToString)
    '                    End If
    '                End If
    '            End If
    '            If Not Object.Equals(dGrid.Rows(p).Cells(5).Value, Nothing) Then
    '                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(5).Value.ToString) Then
    '                    If IsNumeric(dGrid.Rows(p).Cells(5).Value.ToString) Then
    '                        dblTax = CDbl(dGrid.Rows(p).Cells(5).Value.ToString)
    '                    End If
    '                End If
    '            End If

    '            Dim dblTotal As Double = RowTotal(dblUnitPrice, dblQuantity, dblTax)
    '            dGrid.Rows(dGrid.Rows(p).Index).Cells(6).Value = Format(dblTotal, "##0.00")

    '        Next

    '        ComputeTotal()

    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On values recalculation"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

End Class