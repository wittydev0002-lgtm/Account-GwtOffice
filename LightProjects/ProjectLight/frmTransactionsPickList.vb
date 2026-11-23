Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmTransactionsPickList

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadBrowserPanel()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        Select Case UCase(strCalledBy)
            Case Is = UCase("Invoices")
                strSql = "Select InvoiceNumber AS [Trans. ID], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CAST(Amount AS DECIMAL (10,2)) AS [Amt Received], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                    & "CAST(Taxes AS DECIMAL (10,2)) AS [Tax], SalesRep AS [Sales Rep] FROM CustomerSalesMain WHERE TransDate BETWEEN " _
                    & "'" & Format(CDate(dpStartDate.Value), "dd-MMM-yyyy") & "' AND " _
                    & "'" & Format(CDate(dpEndDate.Value), "dd-MMM-yyyy") & "' order by TransDate, InvoiceNumber"
            Case Is = UCase("Credit Notes")
                strSql = "Select NoteNumber AS [Trans. ID], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CAST(TransTotal AS DECIMAL (10,2)) AS [Amount], [AccountId] AS [Account] FROM CreditNotesMain WHERE TransDate BETWEEN " _
                    & "'" & Format(CDate(dpStartDate.Value), "dd-MMM-yyyy") & "' AND " _
                    & "'" & Format(CDate(dpEndDate.Value), "dd-MMM-yyyy") & "' AND AccountId = '" & strSelectedAccount & "' " _
                    & "ORDER by TransDate, NoteNumber"
            Case Is = UCase("Payments")
                strSql = "Select TransactionId AS [Trans. ID], CONVERT(NVARCHAR, TransactionDate, 105) AS [Date], " _
                    & "CAST(Amount AS DECIMAL (10,2)) AS [Amount], [TransactionType], [AccountNumber] AS [Account] " _
                    & "FROM CustomerTransactions WHERE TransactionDate BETWEEN " _
                    & "'" & Format(CDate(dpStartDate.Value), "dd-MMM-yyyy") & "' AND " _
                    & "'" & Format(CDate(dpEndDate.Value), "dd-MMM-yyyy") & "' AND AccountNumber = '" & strSelectedAccount & "' " _
                    & "ORDER by TransactionDate, TransactionId"
            Case Else
                Exit Sub
        End Select

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

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Transactions Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetSelectedValues()
        boolAbort = False
        intSelectedTransaction = Convert.ToDouble(dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value)
        strSelectedDate = Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(1).Value)
        If UCase(strCalledBy) = "INVOICES" Then
            If strTaxComputationType = "EXCLUSIVE" Then
                dblAccountSettlementAmount = Convert.ToDouble(dGrid.Rows(dGrid.CurrentRow.Index).Cells(2).Value) -
                    Convert.ToDouble(dGrid.Rows(dGrid.CurrentRow.Index).Cells(4).Value)
            Else
                dblAccountSettlementAmount = Convert.ToDouble(dGrid.Rows(dGrid.CurrentRow.Index).Cells(2).Value)
            End If
        Else
            dblAccountSettlementAmount = Convert.ToDouble(dGrid.Rows(dGrid.CurrentRow.Index).Cells(2).Value)
        End If
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        GetSelectedValues()
    End Sub

    Private Sub frmTransactionsPickList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBrowserPanel()
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        GetSelectedValues()
    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        LoadBrowserPanel()
    End Sub

End Class
