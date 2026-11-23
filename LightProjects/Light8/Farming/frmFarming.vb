Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmFarming

    '    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
    '        boolEditStatus = False
    '        Dim f As New frmLaschCustomer
    '        f.ShowDialog()
    '    End Sub

    '    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
    '        boolEditStatus = True
    '        Dim f As New frmLaschCustomer
    '        f.ShowDialog()
    '    End Sub

    '    Private Sub LoadData(ByVal OrderBy As String)
    '        On Error GoTo RaiseErr
    '        'dGrid.Rows.Clear()
    '        'AccountNo, LastName, FirstName, OtherNames, Farm Name, Province, District
    '        Cursor = Cursors.WaitCursor
    '        Dim strSql As String = "SELECT AccountNumber AS [Account No.], LastName as [Surname], " _
    '            & "FirstName as [Name], OtherNames as [Other Names], " _
    '            & "FarmName as [Farm Name], Province as [Province], District as [District] FROM " _
    '            & "LaschCustomers ORDER BY AccountNumber"

    '        If OrderBy = "Account Name" Then
    '            strSql = "SELECT AccountNumber AS [Account No.],  LastName as [Surname], " _
    '            & "FirstName as [Name], OtherNames as [Other Names], " _
    '            & "FarmName as [Farm Name], Province as [Province], District as [District] FROM " _
    '            & "LaschCustomers ORDER BY LastName, FirstName, OtherNames"
    '        End If

    '        dGrid.Columns.Clear()
    '        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
    '        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
    '        cmd.CommandType = CommandType.Text

    '        Dim da As New OleDb.OleDbDataAdapter(cmd)
    '        Dim dTable As New DataTable()
    '        da.Fill(dTable)
    '        dGrid.DataSource = dTable
    '        For p As Integer = 0 To dGrid.Columns.Count - 1
    '            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
    '        Next
    '        Cursor = Cursors.Default
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Summary Details Load"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    '    Private Sub DeleteRecord()

    '    End Sub

    '    Private Sub GetSelected()
    '        If dGrid.Rows.Count > 0 Then
    '            strSelectedAccount = dGrid.CurrentRow.Cells(0).Value.ToString
    '        End If
    '    End Sub

    '    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
    '        GetSelected()
    '        boolEditStatus = True
    '        Dim f As New frmLaschCustomer
    '        f.ShowDialog()
    '        If Not String.IsNullOrEmpty(txtSearchString.Text) Then SearchResults(txtSearchString.Text)
    '        'If MessageBox.Show("Do you want to refresh the view right now?", "Refresh View", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
    '        '    LoadData("Account Name")
    '        'End If
    '    End Sub

    '    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
    '        LoadData("Account Name")
    '    End Sub

    '    Private Sub cboSearchBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchBy.SelectedIndexChanged
    '        If cboSearchBy.SelectedItem.ToString = "Account Number" Then LoadData("Account Number") Else LoadData("Account Name")
    '    End Sub

    '    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
    '        Dim strText As String = Nothing
    '        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 18 Then
    '            strText = txtSearchString.Text
    '        Else
    '            strText = txtSearchString.Text & e.KeyChar
    '        End If
    '        SearchResults(strText)
    '    End Sub

    '    Private Sub SearchResults(SearchString As String)
    '        On Error GoTo RaiseErr
    '        'dGrid.Rows.Clear()
    '        Dim strSearchCriteria As String = Nothing

    '        If Object.Equals(cboSearchBy.SelectedItem, Nothing) Then
    '            strSearchCriteria = "Account Name"
    '        Else
    '            strSearchCriteria = cboSearchBy.SelectedItem.ToString
    '        End If

    '        Dim strSql As String = "SELECT AccountNumber AS [Account No.], LastName as [Surname], " _
    '            & "FirstName as [Name], OtherNames as [Other Names], " _
    '            & "FarmName as [Farm Name], Province as [Province], District as [District] FROM " _
    '            & "LaschCustomers WHERE AccountNumber LIKE '%" & SearchString & "%' ORDER BY AccountNumber"

    '        If UCase(strSearchCriteria) = UCase("Account Name") Then
    '            strSql = "SELECT AccountNumber AS [Account No.], LastName as [Surname], " _
    '            & "FirstName as [Name], OtherNames as [Other Names], " _
    '            & "FarmName as [Farm Name], Province as [Province], District as [District] FROM " _
    '            & "LaschCustomers WHERE LastName LIKE '%" & SearchString & "%' " _
    '            & "OR FirstName LIKE '%" & SearchString & "%' OR OtherNames LIKE '%" & SearchString & "%' ORDER BY LastName"
    '        End If

    '        dGrid.Columns.Clear()
    '        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
    '        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
    '        cmd.CommandType = CommandType.Text

    '        Dim da As New OleDb.OleDbDataAdapter(cmd)
    '        Dim dTable As New DataTable()
    '        da.Fill(dTable)
    '        dGrid.DataSource = dTable
    '        For p As Integer = 0 To dGrid.Columns.Count - 1
    '            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
    '        Next

    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Listing Search"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    '    Private Sub frmLaschCustomersListing_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    '        LoadData("Account Number")
    '    End Sub

    '    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
    '        On Error GoTo RaiseErr
    '        If dGrid.Rows.Count > 0 Then

    '            If MessageBox.Show("Are you sure you want to delete the selected records?",
    '                "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                For i As Integer = 0 To dGrid.SelectedRows.Count - 1
    '                    Dim strSelectedAccountToDelete As String = dGrid.SelectedRows.Item(i).Cells(0).Value.ToString
    '                    Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM LaschCustomers WHERE " _
    '                        & "AccountNumber = '" & strSelectedAccountToDelete & "'", cnn)
    '                    objCommand.ExecuteNonQuery()
    '                Next
    '            End If

    '            MessageBox.Show("Customer record has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            LoadData("Account Name")
    '        End If
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Deletion"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    '    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
    '        boolAbort = False
    '        Dim f As New frmLaschCustomerPrintOptions
    '        f.ShowDialog()
    '        If boolAbort = True Then Exit Sub
    '        Cursor = Cursors.WaitCursor
    '        gwt_comm.PrintLaschCustomers()
    '        Cursor = Cursors.Default
    '    End Sub

    '    Private Sub btnBalances_Click(sender As System.Object, e As System.EventArgs) Handles btnBalances.Click
    '        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
    '            PrintLaschCustomerBalances()
    '        Else
    '            MessageBox.Show("You do not have the right to access this part of the system", "Invoking Unauthorised Access", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '            Exit Sub
    '        End If
    '    End Sub

    '    Private Sub btnAccountDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnAccountDetails.Click
    '        Cursor = Cursors.WaitCursor
    '        CreateTempCropTable()
    '        Cursor = Cursors.Default
    '    End Sub

    '    Private Sub btnImportFarmers_Click(sender As System.Object, e As System.EventArgs) Handles btnImportFarmers.Click
    '        Dim f As New frmLaschCustomerDataImport
    '        f.ShowDialog()
    '        LoadData("Account Name")
    '    End Sub

    '    Private Sub btnImportPayments_Click(sender As System.Object, e As System.EventArgs) Handles btnImportPayments.Click
    '        ImportLaschPayments()
    '    End Sub

End Class