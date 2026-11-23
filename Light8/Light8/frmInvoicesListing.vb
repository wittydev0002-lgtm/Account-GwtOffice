Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports AdvancedDataGridView
Imports ProjectLight

Public Class frmInvoicesListing

    Dim boolPrintFromPreview As Boolean
    Dim FilterDate As Date
    Dim boolFormLoading As Boolean

    Private data As List(Of Node)

    Dim dblRunTotal_1 As Double
    Dim dblRunTotal_2 As Double
    Dim dblRunTotal_3 As Double

    Private Sub btnNewInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnNewInvoice.Click
        boolEditStatusTwo = False
        boolLoadedFromCustomerForm = False
        Dim frm As New frmInvoice
        frm.ShowDialog()
        RunSelection()
        'LoadInvoice(CDate(Format(Now, "dd-MMM-yyyy")), CDate(Format(Now, "dd-MMM-yyyy")))
    End Sub

    '    Private Sub LoadInvoice(StartingDate As Date, EndingDate As Date)
    '        On Error GoTo RaiseErr
    '        Dim strSql As String = Nothing

    '        strSql = "SELECT CustomerSalesMain.InvoiceNumber, CONVERT(NVARCHAR, CustomerSalesMain.TransDate, 105) AS [Date], Customers.AccountName, " _
    '                & "CAST(CustomerSalesMain.Amount AS DECIMAL (30,2)) AS [Value], CAST(CustomerSalesMain.Discount AS DECIMAL (30,2)) AS [Discounts], " _
    '                & "CAST(CustomerSalesMain.Taxes AS DECIMAL (30,2)) AS [Taxes] FROM CustomerSalesMain LEFT OUTER JOIN Customers ON " _
    '                & "CustomerSalesMain.CustomerId = Customers.AccountNumber WHERE TransDate BETWEEN " _
    '                & "'" & Format(dpStartInvoice.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndInvoice.Value, "dd-MMM-yyyy") & "' "

    '        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

    '        Dim i As Integer = 0
    '        grd.Rows.Clear()
    '        While objReader.Read
    '            grd.Rows.Add(1)
    '            If Not IsDBNull(objReader(0).ToString) Then grd.Rows(i).Cells(0).Value = objReader(0).ToString
    '            If Not IsDBNull(objReader(1).ToString) Then grd.Rows(i).Cells(1).Value = objReader(1).ToString
    '            If Not IsDBNull(objReader(2).ToString) Then grd.Rows(i).Cells(2).Value = objReader(2).ToString
    '            If Not IsDBNull(objReader(3).ToString) Then grd.Rows(i).Cells(3).Value = objReader(3).ToString
    '            If Not IsDBNull(objReader(4).ToString) Then grd.Rows(i).Cells(4).Value = objReader(4).ToString
    '            If Not IsDBNull(objReader(5).ToString) Then grd.Rows(i).Cells(5).Value = objReader(5).ToString
    '            i = i + 1
    '        End While
    '        objReader.Read()

    '        'Calculate totals
    '        Dim dblMovingT As Double = 0
    '        Dim dblMovingTx As Double = 0
    '        Dim dblMovingDs As Double = 0
    '        Dim strValue As String
    '        For i = 0 To grd.Rows.Count - 1
    '            If Not (Object.Equals(Convert.ToString(grd.Rows(i).Cells(3).Value), "")) Then
    '                strValue = Convert.ToString(grd.Rows(i).Cells(3).Value)
    '                If IsNumeric(strValue) Then
    '                    dblMovingT = dblMovingT + CDbl(strValue)
    '                End If
    '            End If
    '            If Not (Object.Equals(Convert.ToString(grd.Rows(i).Cells(4).Value), "")) Then
    '                strValue = Convert.ToString(grd.Rows(i).Cells(4).Value)
    '                If IsNumeric(strValue) Then
    '                    dblMovingTx = dblMovingTx + CDbl(strValue)
    '                End If
    '            End If
    '            If Not (Object.Equals(Convert.ToString(grd.Rows(i).Cells(5).Value), "")) Then
    '                strValue = Convert.ToString(grd.Rows(i).Cells(5).Value)
    '                If IsNumeric(strValue) Then
    '                    dblMovingDs = dblMovingDs + CDbl(strValue)
    '                End If
    '            End If
    '        Next
    '        lblTotal.Text = Format(dblMovingT, "#,##0.00")
    '        lblTaxes.Text = Format(dblMovingTx, "#,##0.00")
    '        lblDiscounts.Text = Format(dblMovingDs, "#,##0.00")
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
    '        gwt_comm.ShowErrorMessage
    '    End Sub

    Private Sub btnEditInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnEditInvoice.Click
        EditData()
    End Sub

    Private Sub EditData()
        If grd.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(grd.CurrentRow.Cells(2).Value), Nothing)) Then
            If IsNumeric(grd.CurrentRow.Cells(2).Value.ToString) Then
                boolEditStatusTwo = True
                boolLoadedFromCustomerForm = False
                intSelectedTransaction = CInt(grd.CurrentRow.Cells(2).Value.ToString)
                boolAbort = False
                Dim f As New frmInvoice
                f.ShowDialog()
                If boolAbort = True Then
                    Cursor = Cursors.Default
                    Exit Sub
                Else
                    RunSelection()
                End If
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoices Edit"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDeleteInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteInvoice.Click
        If grd.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        If Not (Object.Equals(Convert.ToString(grd.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(grd.CurrentRow.Cells(0).Value.ToString) Then
                'boolEditStatusTwo = True
                intSelectedTransaction = CInt(grd.CurrentRow.Cells(0).Value.ToString)
                If MessageBox.Show("Are you sure you want to delete this document?", "Confirm Proforma Invoice Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then

                    Cursor = Cursors.WaitCursor

                    Dim intKey As Integer = 0
                    Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SpecialKey FROM CustomerSalesMain WHERE InvoiceNumber = " & intSelectedTransaction, cnn)
                    Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        If IsNumeric(objReader(0).ToString) Then intKey = CInt(objReader(0).ToString)
                    End If
                    objReader.Close()

                    If intKey <> 0 Then
                        gwt_comm.DeleteSpecialKeyTransaction(intKey)
                    Else

                        Dim objDelete As New Data.OleDb.OleDbCommand("DELETE FROM CustomerSalesMain WHERE InvoiceNumber = " & intSelectedTransaction, cnn)
                        objDelete.ExecuteNonQuery()
                        objDelete = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSales WHERE InvoiceNumber = " & intSelectedTransaction, cnn)
                        objDelete.ExecuteNonQuery()

                        'Get the customer number for the invoice
                        Dim strCustomerNumber As String = Nothing
                        objDelete = New Data.OleDb.OleDbCommand("SELECT CustomerSalesMain.CustomerId FROM CustomerSalesMain " _
                            & "WHERE CustomerSalesMain.InvoiceNumber = " & intSelectedTransaction & "", cnn)
                        objReader = objDelete.ExecuteReader
                        If objReader.HasRows Then
                            objReader.Read()
                            If Not IsDBNull(objReader(0).ToString) Then
                                strCustomerNumber = objReader(0).ToString
                            End If
                        End If
                        objReader.Close()

                        'Remove the invoice from the customer transaction table as well
                        Dim strSql As String = "DELETE FROM CustomerTransactions WHERE ReferenceNumber = '" & intSelectedTransaction & "' " _
                            & "AND AccountNumber = '" & strCustomerNumber & "' AND TransactionType = 'INVOICE'"
                        objDelete = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objDelete.ExecuteNonQuery()

                    End If

                    'LoadInvoice(CDate(Format(StartDate, "dd-MMM-yyyy")), CDate(Format(EndDate, "dd-MMM-yyyy")))
                    RunSelection()

                    MessageBox.Show("Invoice deleted successfully", "Proforma Invoice Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Cursor = Cursors.Default
                End If
            End If
        End If

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Proforma Invoice Analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrintSelected_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSelected.Click
        If grd.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        boolPrinterAlreadySelected = False
        boolAbort = False

        Dim DocumentType As String = "Invoice"

        If Not (Object.Equals(Convert.ToString(grd.CurrentRow.Cells(2).Value), "")) Then
            If IsNumeric(grd.CurrentRow.Cells(2).Value.ToString) Then
                If UCase(CommonLibrary.Commons.strInvoiceDesignType) = "CUSTOM" Then
                    Dim f As New PrintDialog
                    f.ShowDialog()
                    boolEditStatusTwo = True
                    boolPrintFromPreview = True
                    PrintDocument2.PrinterSettings.PrinterName = f.PrinterSettings.PrinterName
                    PrintPreviewDialog1.Document = PrintDocument2
                    PrintPreviewDialog1.ShowDialog()
                Else
                    'Print generic invoice
                    intSelectedTransaction = CInt(grd.CurrentRow.Cells(2).Value.ToString)
                    Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
                    If UCase(strPrintDocumentsTo) = UCase("pdf") Then
                        PrintCustomerPdfDocument(intSelectedTransaction, DocumentType)
                    Else
                        gwt_comm.PrintCustomerDocument(intSelectedTransaction, "INVOICE")
                    End If
                End If
            End If
        End If

        Cursor = Cursors.Default

        If boolAbort = False Then
            MessageBox.Show(StrConv(DocumentType, VbStrConv.ProperCase) & " has been generated successfully.",
                "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrintSummary_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSummary.Click
        If grd.RowCount <= 0 Then Exit Sub
        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
        'gwt_comm.PrintDataGrid(grd, "INVOICES SUMMARY FOR PERIOD " & UCase(Format(StartDate, "dd-MMM-yyyy")) &
        '    " TO " & UCase(Format(EndDate, "dd-MMM-yyyy")))
    End Sub

    Private Sub btnAccountSettlement_Click(sender As System.Object, e As System.EventArgs) Handles btnAccountSettlement.Click
        boolAbort = False
        gwt_comm.CashbookSelection()
        If boolAbort = True Then Exit Sub
        Dim frm2 As New frmAdvanceInvoiceSettlement
        frm2.ShowDialog()
    End Sub

    Private Sub btnDeliveryNote_Click(sender As System.Object, e As System.EventArgs) Handles btnDeliveryNote.Click
        If grd.Rows.Count <= 0 Then Exit Sub
        boolPrinterAlreadySelected = False
        intSelectedTransaction = CInt(grd.CurrentRow.Cells(2).Value.ToString)
        strDeliveryNoteFrom = "INVOICES"
        Dim f As New frmInvoiceDeliveryNote
        f.ShowDialog()
        strDeliveryNoteFrom = Nothing
    End Sub

    Private Sub btnRefreshInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshInvoice.Click
        'If String.IsNullOrEmpty(cboGroup.Text) Then cboGroup.Text = "None"
        'LoadInvoice(CDate(Format(Now, "dd-MMM-yyyy")), CDate(Format(Now, "dd-MMM-yyyy")))
        RunSelection()
    End Sub

    Private Sub btnRunInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnRunInvoice.Click
        RunSelection()
    End Sub

    Private Sub RunSelection()
        If String.IsNullOrEmpty(cboGroup.Text) Then cboGroup.Text = "None"
        Cursor = Cursors.WaitCursor

        dblRunTotal_1 = 0 : dblRunTotal_2 = 0 : dblRunTotal_3 = 0

        If UCase(cboGroup.Text) <> UCase("NONE") Then
            LoadGroupMainData(CDate(gwt_comm.shortMonthDateFormat(dpStartInvoice.Value)), CDate(shortMonthDateFormat(CDate(dpEndInvoice.Value))))
        Else
            LoadDefault()
            'LoadInvoice(CDate(Format(dpStartInvoice.Value, "dd-MMM-yyyy")), CDate(Format(dpEndInvoice.Value, "dd-MMM-yyyy")))
        End If

        lblDiscounts.Text = dblRunTotal_1
        lblTaxes.Text = dblRunTotal_2
        lblTotal.Text = dblRunTotal_3

        Cursor = Cursors.Default
    End Sub

    Private Sub LoadGroupMainData(ByVal StartingDate As Date, ByVal EndingDate As Date)
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        ' Clear the grid of all rows
        grd.Rows.Clear()

        Dim boldFont As Font = New Font(grd.DefaultCellStyle.Font, FontStyle.Bold)

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        Select Case UCase(cboGroup.Text)

            Case Is = UCase("Date")

                With grd
                    .Columns(0).HeaderText = "Date"
                    .Columns(1).HeaderText = "Customer Name"
                End With

                While StartingDate <= EndingDate

                    strSql = "SELECT COUNT(CustomerSalesMain.InvoiceNumber) FROM CustomerSalesMain WHERE TransDate = '" & gwt_comm.shortMonthDateFormat(StartingDate) & "'"

                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objReader = objCommand.ExecuteReader
                    Dim intCounter As Integer = 0
                    If objReader.HasRows Then
                        objReader.Read()
                        intCounter = CInt(objReader(0).ToString)
                    End If
                    objReader.Close()

                    If intCounter > 0 Then
                        Dim node As TreeGridNode = grd.Nodes.Add(gwt_comm.shortMonthDateFormat(StartingDate), Nothing, Nothing, Nothing, Nothing, Nothing)
                        'node.ImageIndex = 4
                        FilterDate = CDate(gwt_comm.shortMonthDateFormat(StartingDate))
                        node.DefaultCellStyle.Font = boldFont
                        AddNodes(node, Nothing, cboGroup.Text)
                        node.Expand()
                    End If

                    StartingDate = DateAdd(DateInterval.Day, 1, StartingDate)

                End While

            Case Is = UCase("Customer")

                With grd
                    .Columns(0).HeaderText = "Customer Name"
                    .Columns(1).HeaderText = "Date"
                End With

                strSql = "SELECT DISTINCT(CustomerSalesMain.CustomerId), Customers.AccountName FROM CustomerSalesMain " _
                    & "LEFT OUTER JOIN Customers ON CustomerSalesMain.CustomerId = Customers.AccountNumber " _
                    & "WHERE CustomerSalesMain.TransDate BETWEEN " _
                    & "'" & gwt_comm.shortMonthDateFormat(dpStartInvoice.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpEndInvoice.Value) & "' " _
                    & "GROUP BY Customers.AccountName, CustomerSalesMain.CustomerId ORDER BY Customers.AccountName"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objReader = objCommand.ExecuteReader
                While objReader.Read
                    Dim node As TreeGridNode = grd.Nodes.Add(objReader(1).ToString(), Nothing, Nothing, Nothing, Nothing, Nothing)
                    'node.ImageIndex = 5
                    node.DefaultCellStyle.Font = boldFont
                    AddNodes(node, objReader(0).ToString, cboGroup.Text)
                    node.Expand()
                End While
                objReader.Close()

        End Select

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On patient listing load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub AddNodes(ByRef sNode As TreeGridNode, Optional CustomerId As String = Nothing, Optional GroupMethod As String = "none")
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        Select Case UCase(GroupMethod)
            Case Is = UCase("none")
                Exit Sub
            Case Is = UCase("Date")
                strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), CustomerSalesMain.TransDate, 106), ' ', '-')) AS [Date], Customers.AccountName, CustomerSalesMain.InvoiceNumber, " _
                            & "CAST(CustomerSalesMain.Discount AS DECIMAL (30,2)) AS [Taxes], CAST(CustomerSalesMain.Taxes AS DECIMAL (30,2)) AS [Discounts], " _
                            & "CAST(CustomerSalesMain.Amount AS DECIMAL (30,2)) AS [Value] FROM CustomerSalesMain LEFT OUTER JOIN Customers ON " _
                            & "CustomerSalesMain.CustomerId = Customers.AccountNumber WHERE TransDate = '" & gwt_comm.shortMonthDateFormat(FilterDate) & "' " _
                            & "ORDER BY Customers.AccountName, CustomerSalesMain.TransDate, CustomerSalesMain.InvoiceNumber"
            Case Is = UCase("Customer")
                strSql = "SELECT Customers.AccountName, UPPER(REPLACE(CONVERT(CHAR(11), CustomerSalesMain.TransDate, 106), ' ', '-')) AS [Date], CustomerSalesMain.InvoiceNumber, " _
                            & "CAST(CustomerSalesMain.Discount AS DECIMAL (30,2)) AS [Taxes], CAST(CustomerSalesMain.Taxes AS DECIMAL (30,2)) AS [Discounts], " _
                            & "CAST(CustomerSalesMain.Amount AS DECIMAL (30,2)) AS [Value] FROM CustomerSalesMain LEFT OUTER JOIN Customers ON " _
                            & "CustomerSalesMain.CustomerId = Customers.AccountNumber WHERE CustomerSalesMain.CustomerId = '" & CustomerId & "' " _
                            & "AND CustomerSalesMain.TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartInvoice.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpEndInvoice.Value) & "' " _
                            & "ORDER BY CustomerSalesMain.TransDate, CustomerSalesMain.InvoiceNumber"
            Case Else
                Exit Sub
        End Select

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim dblTotal_1 As Double = 0
        Dim dblTotal_2 As Double = 0
        Dim dblTotal_3 As Double = 0
        Dim intCounter As Integer = 0
        While objReader.Read
            sNode.Nodes.Add(objReader(0).ToString(), objReader(1).ToString, objReader(2).ToString,
                            objReader(3).ToString, objReader(4).ToString, objReader(5).ToString)
            If IsNumeric(objReader(3).ToString) Then
                dblTotal_1 = dblTotal_1 + CDbl(objReader(3).ToString)
                dblRunTotal_1 = dblRunTotal_1 + CDbl(objReader(3).ToString)
            End If

            If IsNumeric(objReader(4).ToString) Then
                dblTotal_2 = dblTotal_2 + CDbl(objReader(4).ToString)
                dblRunTotal_2 = dblRunTotal_2 + CDbl(objReader(4).ToString)
            End If

            If IsNumeric(objReader(5).ToString) Then
                dblTotal_3 = dblTotal_3 + CDbl(objReader(5).ToString)
                dblRunTotal_3 = dblRunTotal_3 + CDbl(objReader(5).ToString)
            End If
            'sNode.ImageIndex = 5
            intCounter = intCounter + 1
        End While
        objReader.Close()

        'Add the last node for total and be blue color
        If intCounter > 0 Then
            Dim ItalicFont As Font = New Font(grd.DefaultCellStyle.Font, FontStyle.Italic)
            sNode.Nodes.Add(Nothing, UCase("Summary Totals"), Nothing, dblTotal_1, dblTotal_2, dblTotal_3)
            'sNode.DefaultCellStyle.Font = ItalicFont
        End If

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Invoice Listing Load"
        gwt_comm.ShowErrorMessage()
    End Sub


    Private Sub frmInvoicesListing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True

        '******* FORMAT THE TREEGRIDVIEW********************************
        Me.imageStrip.ImageSize = New System.Drawing.Size(16, 16)
        Me.imageStrip.TransparentColor = System.Drawing.Color.Magenta
        Me.imageStrip.ImageSize = New Size(16, 16)

        grd.ImageList = imageStrip
        '***************************************************************
        cboGroup.Text = "None"
        boolFormLoading = False
    End Sub

    Private Sub grd_DoubleClick(sender As Object, e As System.EventArgs) Handles grd.DoubleClick
        EditData()
    End Sub

    Private Sub LoadDefault()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        With grd
            .Rows.Clear()
            '.Columns.Add("Column1", "Date")
            '.Columns.Add("Column2", "Customer Name")
            '.Columns.Add("Column3", "Doc.#")
            '.Columns.Add("Column4", "Discount")
            '.Columns.Add("Column5", "Taxes")
            '.Columns.Add("Column6", "Value")
            'For p As Integer = 0 To .Columns.Count - 1
            '    .Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            'Next

            Dim dblTotal_1 As Double = 0
            Dim dblTotal_2 As Double = 0
            Dim dblTotal_3 As Double = 0

            Dim strSql As String = "SELECT Customers.AccountName, UPPER(REPLACE(CONVERT(CHAR(11), CustomerSalesMain.TransDate, 106), ' ', '-')) AS [Date], CustomerSalesMain.InvoiceNumber, " _
                & "CAST(CustomerSalesMain.Discount AS DECIMAL (30,2)) AS [Taxes], CAST(CustomerSalesMain.Taxes AS DECIMAL (30,2)) AS [Discounts], " _
                & "CAST(CustomerSalesMain.Amount AS DECIMAL (30,2)) AS [Value] FROM CustomerSalesMain LEFT OUTER JOIN Customers ON " _
                & "CustomerSalesMain.CustomerId = Customers.AccountNumber WHERE CustomerSalesMain.TransDate " _
                & "BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartInvoice.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpEndInvoice.Value) & "' " _
                & "ORDER BY CustomerSalesMain.TransDate, CustomerSalesMain.InvoiceNumber"
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

            While objReader.Read
                Dim node As TreeGridNode = grd.Nodes.Add(objReader(1).ToString(), objReader(0).ToString(),
                    objReader(2).ToString(), Format(CDbl(objReader(3).ToString()), "##0.00"),
                    Format(CDbl(objReader(4).ToString()), "##0.00"), Format(CDbl(objReader(5).ToString()), "##0.00"))
                If IsNumeric(objReader(3).ToString) Then
                    dblTotal_1 = dblTotal_1 + CDbl(objReader(3).ToString)
                    dblRunTotal_1 = dblRunTotal_1 + CDbl(objReader(3).ToString)
                End If

                If IsNumeric(objReader(4).ToString) Then
                    dblTotal_2 = dblTotal_2 + CDbl(objReader(4).ToString)
                    dblRunTotal_2 = dblRunTotal_2 + CDbl(objReader(4).ToString)
                End If

                If IsNumeric(objReader(5).ToString) Then
                    dblTotal_3 = dblTotal_3 + CDbl(objReader(5).ToString)
                    dblRunTotal_3 = dblRunTotal_3 + CDbl(objReader(5).ToString)
                End If
            End While
            objReader.Close()
        End With
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Invoice Listing Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ButtonItem1_Click(sender As System.Object, e As System.EventArgs) Handles btnUnpaidInvoices.Click
        strCalledBy = "customers"
        Dim frm As New frmUnpaidDocuments
        frm.ShowDialog()
    End Sub

    Private Sub btnBalances_Click(sender As System.Object, e As System.EventArgs) Handles btnBalances.Click
        strCalledBy = "customers"
        Dim frm As New frmClientBalances
        frm.ShowDialog()
    End Sub

End Class