Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBrowseLoanCustomer

    Private Sub LoadBrowserPanel()
        On Error GoTo RaiseErr

        'Update for the serial numbers table
        Dim strSql As String = Nothing
        strSql = "SELECT AccountNumber as [Account Number], AccountName as [Customer Name] " _
                    & "FROM Customers WHERE CustomerType = 'LOAN' ORDER BY AccountNumber"

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

        dGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        Cursor = Cursors.WaitCursor
        'grd.Rows.Clear()
        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim strSql As String = Nothing

        If chkWildCast.Checked = True Then
            Select Case cboSearchType.Text
                Case Is = "Account Number"
                    strSql = "SELECT AccountNumber as [Account Number], AccountName as [Customer Name] " _
                    & "FROM Customers WHERE AccountNumber LIKE '%" & strFind & "%' AND CustomerType = 'LOAN' ORDER BY AccountNumber"

                Case Is = "Account Name" 'Use the grup name
                    strSql = "SELECT AccountNumber as [Account Number], AccountName as [Customer Name] " _
                    & "FROM Customers WHERE LastName LIKE '%" & strFind & "%' AND CustomerType = 'LOAN' ORDER BY LastName"
                Case Else
                    strSql = "SELECT AccountNumber as [Account Number], AccountName as [Customer Name] " _
                    & "FROM Customers WHERE LastName LIKE '%" & strFind & "%' AND CustomerType = 'LOAN' ORDER BY LastName"
            End Select
        Else
            Select Case cboSearchType.Text
                Case Is = "Account Number"
                    strSql = "SELECT AccountNumber as [Account Number], AccountName as [Customer Name] " _
                    & "FROM Customers WHERE AccountNumber LIKE '" & strFind & "%' AND CustomerType = 'LOAN' ORDER BY AccountNumber"

                Case Is = "Account Name" 'Use the grup name
                    strSql = "SELECT AccountNumber as [Account Number], AccountName as [Customer Name] " _
                    & "FROM Customers WHERE LastName LIKE '" & strFind & "%' AND CustomerType = 'LOAN' ORDER BY LastName"
                Case Else
                    strSql = "SELECT AccountNumber as [Account Number], AccountName as [Customer Name] " _
                    & "FROM Customers WHERE LastName LIKE '" & strFind & "%' AND CustomerType = 'LOAN' ORDER BY LastName"
            End Select
        End If
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        dGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Search"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
        Exit Sub
    End Sub

    Private Sub frmFindInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBrowserPanel()
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count > 0 Then GetSelectedValues()
    End Sub

    Private Sub GetSelectedValues()
        boolAbort = False
        strPublicItemCode = Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value)
        strPublicItemDescription = Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(1).Value)
        Me.Close()
    End Sub

    Private Sub btnSelectSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSales.Click
        If dGrid.Rows.Count > 0 Then GetSelectedValues()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If Asc(e.KeyChar) = 13 Then GetSelectedValues()
        SearchForItem(e.KeyChar)
    End Sub

End Class
