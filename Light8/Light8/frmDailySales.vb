Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDailySales

    Private Sub frmDailySales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        grd.Columns.Clear()
        Dim strSql As String = Nothing
        strSql = "Select InvoiceNumber AS [Trans. ID], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "CAST(Amount AS DECIMAL (30,2)) AS [Amt Received], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
            & "CAST(Taxes AS DECIMAL (30,2)) AS [Tax], SalesRep AS [Sales Rep], KeyNumber as [Doc. No] from SalesMain WHERE TransDate BETWEEN " _
            & "'" & shortMonthDateFormat(Now) & "' AND " _
            & "'" & shortMonthDateFormat(Now) & "' order by TransDate, InvoiceNumber"

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        grd.DataSource = dTable

        'Add the image column at the end

        Me.grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        For p As Integer = 0 To grd.Columns.Count - 1
            grd.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If grd.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(grd.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(grd.CurrentRow.Cells(0).Value.ToString) Then
                boolTransactionVoided = False
                intSelectedTransaction = CInt(grd.CurrentRow.Cells(0).Value.ToString)
                strCalledBy = "Till"
                Dim f As New frmSalesDetails
                f.ShowDialog()
                strCalledBy = Nothing
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub grd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.DoubleClick
        If grd.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(grd.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(grd.CurrentRow.Cells(0).Value.ToString) Then
                boolTransactionVoided = False
                intSelectedTransaction = CInt(grd.CurrentRow.Cells(0).Value.ToString)
                strCalledBy = "Till"
                Dim f As New frmSalesDetails
                f.ShowDialog()
                strCalledBy = Nothing
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
