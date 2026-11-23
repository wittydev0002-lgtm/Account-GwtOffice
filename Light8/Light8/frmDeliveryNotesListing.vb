Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDeliveryNotesListing

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        dGrid.Rows.Clear()
    End Sub

    Private Sub btnRunInvoice_Click(sender As Object, e As EventArgs) Handles btnRunInvoice.Click
        lblDiscounts.Text = "0.00"
        lblTaxes.Text = "0.00"
        lblTotal.Text = "0.00"
        Select Case UCase(cboFrom.Text)
            Case = "INVOICES"
                LoadInvoice(CDate(shortMonthDateFormat(StartDate)), CDate(shortMonthDateFormat(EndDate)))
            Case Else
                LoadExitPasses()
        End Select
    End Sub

    Private Sub LoadExitPasses()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        strSql = "Select PassNumber AS [Pass #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                & "CollectingAgent AS [Collected By], PassType AS [Type] from GatePassesMain WHERE TransDate BETWEEN " _
                & "'" & shortMonthDateFormat(CDate(dpStartInvoice.Value)) & "' AND " _
                & "'" & shortMonthDateFormat(CDate(dpEndInvoice.Value)) & "' order by TransDate, PassNumber"

        dGrid.Columns.Clear()
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On exit passes load from the delivery notes printing"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadInvoice(StartingDate As Date, EndingDate As Date)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing

        strSql = "SELECT CustomerSalesMain.InvoiceNumber AS [Invoice #], " _
                & "CONVERT(NVARCHAR, CustomerSalesMain.TransDate, 105) AS [Date], Customers.AccountName AS [Customer], " _
                & "CAST(CustomerSalesMain.Amount AS DECIMAL (30,2)) AS [Value], CAST(CustomerSalesMain.Discount AS DECIMAL (30,2)) AS [Discounts], " _
                & "CAST(CustomerSalesMain.Taxes AS DECIMAL (30,2)) AS [Taxes] FROM CustomerSalesMain LEFT OUTER JOIN Customers ON " _
                & "CustomerSalesMain.CustomerId = Customers.AccountNumber WHERE TransDate BETWEEN " _
                & "'" & shortMonthDateFormat(dpStartInvoice.Value) & "' AND '" & shortMonthDateFormat(dpEndInvoice.Value) & "' "


        dGrid.Columns.Clear()
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            If p >= 3 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        'Calculate totals
        Dim dblMovingT As Double = 0
        Dim dblMovingTx As Double = 0
        Dim dblMovingDs As Double = 0
        Dim strValue As String
        For i = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                strValue = Convert.ToString(dGrid.Rows(i).Cells(3).Value)
                If IsNumeric(strValue) Then
                    dblMovingT = dblMovingT + CDbl(strValue)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                strValue = Convert.ToString(dGrid.Rows(i).Cells(4).Value)
                If IsNumeric(strValue) Then
                    dblMovingTx = dblMovingTx + CDbl(strValue)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                strValue = Convert.ToString(dGrid.Rows(i).Cells(5).Value)
                If IsNumeric(strValue) Then
                    dblMovingDs = dblMovingDs + CDbl(strValue)
                End If
            End If
        Next
        lblTotal.Text = Format(dblMovingT, "#,##0.00")
        lblTaxes.Text = Format(dblMovingTx, "#,##0.00")
        lblDiscounts.Text = Format(dblMovingDs, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintSelectedDocument()
    End Sub

    Private Sub PrintSelectedDocument()
        If dGrid.Rows.Count <= 0 Then Exit Sub
        boolPrinterAlreadySelected = False
        Dim f As Form
        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
        If UCase(cboFrom.Text) = "INVOICES" Then
            strDeliveryNoteFrom = "INVOICES"
        Else
            strDeliveryNoteFrom = "EXIT PASSES"
        End If
        f = frmInvoiceDeliveryNote
        f.ShowDialog()
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As EventArgs) Handles dGrid.DoubleClick
        PrintSelectedDocument()
    End Sub

End Class