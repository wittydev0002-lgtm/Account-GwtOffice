Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInvoiceDeliveryNote

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmInvoiceDeliveryNote_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CustomerSales.ItemCode AS [Item Code], CustomerSales.Description AS [Description], " _
            & "SUM(CustomerSales.Quantity) AS [Sold], SUM(CustomerInvoiceDeliveries.QuantityDelivered) AS [Delivered], " _
            & "SUM((CustomerSales.Quantity - CustomerInvoiceDeliveries.QuantityDelivered)) AS [Balance] " _
            & "FROM CustomerSales LEFT OUTER JOIN " _
            & "CustomerInvoiceDeliveries ON CustomerSales.ItemCode = CustomerInvoiceDeliveries.ItemCode " _
            & "WHERE CustomerSales.InvoiceNumber = " & intSelectedTransaction & " " _
            & "GROUP BY CustomerSales.ItemCode, CustomerSales.Description"

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGrid.Columns.Clear()
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p > 1 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            If p <> 3 Then
                dGrid.Columns(p).ReadOnly = True
            End If
        Next

        txtInvoiceNumber.Text = CStr(intSelectedTransaction)

        'Get the customer Details
        strSql = "SELECT CustomerSalesMain.InvoiceNumber, Customers.AccountNumber, " _
            & "Customers.AccountName, Customers.Address1, Customers.Address2, Customers.Address3, " _
            & "Customers.Address4 FROM CustomerSalesMain LEFT OUTER JOIN Customers ON " _
            & "CustomerSalesMain.CustomerId = Customers.AccountNumber " _
            & "WHERE CustomerSalesMain.InvoiceNumber = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(2).ToString) Then txtCustomerName.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then txtAddress1.Text = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then txtAddress2.Text = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then txtAddress3.Text = objReader(5).ToString
            If Not IsDBNull(objReader(6).ToString) Then txtAddress4.Text = objReader(6).ToString
        End If
        objReader.Close()
        txtInvoiceNumber.Enabled = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Invoice Items Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex = 3 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                If Not IsNumeric(dGrid.CurrentRow.Cells(2).Value) Then
                    dGrid.CurrentRow.Cells(2).Value = "0.00"
                End If
                dGrid.CurrentRow.Cells(4).Value = CDbl(dGrid.CurrentRow.Cells(2).Value.ToString) - CDbl(dGrid.CurrentCell.Value.ToString)
            End If
        End If
    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGrid.EditingControlShowing
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

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        boolPrinterAlreadySelected = False
        strDeliveryNoteFrom = "INVOICES"
        gwt_comm.PrintCustomerDocument(intSelectedTransaction, "DELIVERY NOTE")
        strDeliveryNoteFrom = Nothing
    End Sub

End Class
