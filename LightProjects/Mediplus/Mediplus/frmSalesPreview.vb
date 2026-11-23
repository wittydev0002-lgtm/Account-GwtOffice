Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSalesPreview

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        LoadSalesDetails()
    End Sub

    Private Sub LoadSalesDetails()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing

        Dim strSqlCash As String = Nothing
        Dim strSqlEcocash As String = Nothing
        Dim strSqlTransfers As String = Nothing
        Dim strSqlSwipes As String = Nothing

        Dim dblDivisionFactor As Double = (1 / (100 + dblSalesTaxRate)) * 100
        dblDivisionFactor = 1

        If UCase(cboUser.Text) = "--- ALL ---" Then

            If UCase(strTaxComputationType) = "INCLUSIVE" Then
                strSql = "Select InvoiceNumber AS [Trans. ID], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CAST((Amount * " & dblDivisionFactor & ") AS DECIMAL (10,2)) AS [Amt Received], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                    & "CAST(Taxes AS DECIMAL (10,2)) AS [Tax], SalesRep AS [Sales Rep], KeyNumber as [Doc. No], " _
                    & "SalesMain.Username as [Operator] from SalesMain WHERE TransDate BETWEEN " _
                    & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
                    & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' order by TransDate, InvoiceNumber"
            Else
                strSql = "Select InvoiceNumber AS [Trans. ID], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CAST(Amount AS DECIMAL (10,2)) AS [Amt Received], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                    & "CAST(Taxes AS DECIMAL (10,2)) AS [Tax], SalesRep AS [Sales Rep], KeyNumber as [Doc. No], " _
                    & "SalesMain.Username as [Operator] from SalesMain WHERE TransDate BETWEEN " _
                    & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
                    & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' order by TransDate, InvoiceNumber"
            End If
        Else
            If UCase(strTaxComputationType) = "INCLUSIVE" Then
                strSql = "Select InvoiceNumber as [Trans. ID], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                   & "CAST((Amount * " & dblDivisionFactor & ") AS DECIMAL (10,2)) AS [Amt Received], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                   & "CAST(Taxes AS DECIMAL (10,2)) AS [Tax], SalesRep AS [Sales Rep], KeyNumber as [Doc. No], SalesMain.Username as [Operator] " _
                   & "from SalesMain WHERE UserName = '" & UCase(cboUser.Text) & "' " _
                   & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
                   & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' order by TransDate, InvoiceNumber"
            Else
                strSql = "Select InvoiceNumber as [Trans. ID], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                   & "CAST(Amount AS DECIMAL (10,2)) AS [Amt Received], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                   & "CAST(Taxes AS DECIMAL (10,2)) AS [Tax], SalesRep AS [Sales Rep], KeyNumber as [Doc. No], SalesMain.Username as [Operator] " _
                   & "from SalesMain WHERE UserName = '" & UCase(cboUser.Text) & "' " _
                   & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
                   & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' order by TransDate, InvoiceNumber"
            End If
        End If

        'Populate the all sales grid
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable
        ComputeTotals(dGrid)

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals(ByVal Grid As KryptonDataGridView)
        Dim dblAmount As Double = 0
        Dim dblTaxes As Double = 0
        Dim dblDiscounts As Double = 0
        With Grid
            For n As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(2).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(2).Value.ToString) Then
                        dblAmount = dblAmount + CDbl(.Rows(n).Cells(2).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(3).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(3).Value.ToString) Then
                        dblDiscounts = dblDiscounts + CDbl(.Rows(n).Cells(3).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(4).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(4).Value.ToString) Then
                        dblTaxes = dblTaxes + CDbl(.Rows(n).Cells(4).Value.ToString)
                    End If
                End If
            Next
            lblAllSales.Text = Format((dblAmount + dblTaxes + dblDiscounts), "#,##0.00")
            lblAllAmt.Text = Format(dblAmount, "#,##0.00")
            lblAllDiscounts.Text = Format(dblDiscounts, "#,##0.00")
            lblAllVat.Text = Format(dblTaxes, "#,##0.00")
            lblAllTotals.Text = Format(((dblAmount + dblTaxes) - 0), "#,##0.00")
        End With
    End Sub

    Private Sub frmSalesPreview_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadUsers()
        LoadSalesDetails()
    End Sub


    Private Sub LoadUsers()
        On Error GoTo RaiseErr
        cboUser.Items.Clear()
        cboUser.Items.Add("--- ALL ---")
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT UserName FROM Users ORDER BY UserName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboUser.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Usernames Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                boolTransactionVoided = False
                intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
                strCalledBy = Nothing
                Dim f As New frmSalesDetails
                f.ShowDialog()
                If boolTransactionVoided = True Then LoadSalesDetails()
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        ShowErrorMessage()
    End Sub


End Class
