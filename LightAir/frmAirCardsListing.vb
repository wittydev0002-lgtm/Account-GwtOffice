Imports CommonLibrary.Commons

Public Class frmAirCardsListing

    Private Sub frmAirCardsListing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadAirCards(CDate(Format(dtFrom.Value, "dd-MMM-yyyy")), CDate(Format(dtTo.Value, "dd-MMM-yyyy")))
    End Sub

    Private Sub LoadAirCards(ByVal DateFrom As Date, ByVal DateTo As Date)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [JobNumber] AS [Job #], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date], " _
            & "[OperatorName] AS [Operator], [BillTo] AS [Billed To], [ReferenceNumber] AS [Ref. #], " _
            & "InvoiceNumber AS [Inv. #] FROM AirCardsMain " _
            & "WHERE TransDate BETWEEN '" & DateFrom & "' AND '" & DateTo & "' " _
            & "ORDER BY TransDate"

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGridAirCards.Columns.Clear()
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridAirCards.DataSource = dTable

        Me.dGridAirCards.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGridAirCards.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGridAirCards.Columns.Count - 1
            dGridAirCards.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Air Cards Listing Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnProcess_Click(sender As System.Object, e As System.EventArgs) Handles btnProcess.Click
        LoadAirCards(CDate(Format(dtFrom.Value, "dd-MMM-yyyy")), CDate(Format(dtTo.Value, "dd-MMM-yyyy")))
    End Sub

    Private Sub GetSelected()
        If dGridAirCards.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGridAirCards.CurrentRow.Cells(0).Value.ToString)
        boolEditStatus = True
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click
        GetSelected()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnInvoice.Click
        If dGridAirCards.Rows.Count <= 0 Then Exit Sub
        If CInt(dGridAirCards.CurrentRow.Cells(dGridAirCards.ColumnCount - 1).Value.ToString) <= 0 Then
            intSelectedTransaction = CInt(dGridAirCards.CurrentRow.Cells(0).Value.ToString)
            boolCalledFromListing = True
            'Dim frm As New frmInvoice
            'frm.ShowDialog()
        End If
    End Sub

End Class
