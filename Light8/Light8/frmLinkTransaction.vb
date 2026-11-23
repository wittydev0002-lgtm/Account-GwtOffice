Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLinkTransaction

    Private Sub frmLinkTransaction_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmLinkTransaction_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 550 : Me.Height = 355
    End Sub

    
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadTransactions(ByVal AccountNumber As String)
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        If UCase(strCalledBy) = UCase("Customers") Then
            strSql = "SELECT CustomerSalesMain.InvoiceNumber AS [Doc #], UPPER(REPLACE(CONVERT(CHAR(11), CustomerSalesMain.TransDate, 106), ' ', '-')) as [Date], " _
                & "CAST(CustomerSalesMain.Discount AS DECIMAL (30,2)) AS [Discount], CAST(CustomerSalesMain.Taxes AS DECIMAL (30,2)) AS [Taxes], " _
                & "CAST(CustomerSalesMain.Amount AS DECIMAL (30,2)) AS [Amount] FROM CustomerSalesMain LEFT OUTER JOIN Customers ON " _
                & "CustomerSalesMain.CustomerId = Customers.AccountNumber WHERE CustomerSalesMain.CustomerId '" & AccountNumber & "' " _
                & "ORDER BY CustomerSalesMain.InvoiceNumber, CustomerSalesMain.TransDate"
        Else

        End If

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p > 1 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " On client transactions load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click
        If String.IsNullOrEmpty(lblAccountNumber.Text) Then
            MessageBox.Show("Please select the client from the list provided", "Invalid Client", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClientDetails.Select()
            Exit Sub
        End If
        strSelectedAccount = lblAccountNumber.Text

    End Sub
End Class