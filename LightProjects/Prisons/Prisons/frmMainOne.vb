Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMainOne

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmPrisonerSetup
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [PrisonNumber] AS [Policy #], LastName +' '+ FirstName +' '+ OtherNames AS [Member Names], " _
            & "IdNumber as [ID Number], UPPER(REPLACE(CONVERT(CHAR(11), DateIn, 106), ' ', '-')) as [Entry Date], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), DateOut, 106), ' ', '-')) as [Release Date] FROM Prisoners ORDER BY FirstName, LastName"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGrid.Columns.Clear()

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        dGrid.Columns(0).Visible = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Prisoner Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub GetSelected()
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                intSelectedTransaction = dGrid.CurrentRow.Cells(0).Value.ToString
            End If
        End If
    End Sub

    Private Sub frmBenefitsMembers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        Dim frm As New frmLogin
        frm.ShowDialog()
        If boolAbort = True Then End
        LoadData()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        GetSelected()
        boolEditStatus = True
        Dim frm As New frmPrisonerSetup
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count <= 0 Then Exit Sub
        GetSelected()
        boolEditStatus = True
        Dim frm As New frmPrisonerSetup
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to delete this record", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'Get the selected record
            Dim intRecordToDelete As Integer = 0
            If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                    intRecordToDelete = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
                End If
            End If
            If Not String.IsNullOrEmpty(intRecordToDelete) Then
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM Prisoners WHERE PrisonNumber = " & intRecordToDelete & "", cnn)
                objCommand.ExecuteNonQuery()
            End If
            LoadData()
            MessageBox.Show("Prisoner record deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Prisoner Details Management"
        ShowErrorMessage()
    End Sub

    Private Sub txtSearchString_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            SearchForItem(txtSearchString.Text & e.KeyChar)
        Else
            SearchForItem(txtSearchString.Text)
        End If
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = strCurrentKey
        strActiveSearch = strFind

        Cursor = Cursors.WaitCursor

        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        'First Name, Last Name, Student Number

        Select Case cboSearchBy.Text
            Case Is = "First Name"
                strSql = "SELECT [PrisonNumber] AS [Policy #], LastName +' '+ FirstName +' '+ OtherNames AS [Member Names], " _
                    & "IdNumber as [ID Number], UPPER(REPLACE(CONVERT(CHAR(11), DateIn, 106), ' ', '-')) as [Entry Date], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOut, 106), ' ', '-')) as [Release Date] FROM Prisoners " _
                    & "WHERE FirstName LIKE '%" & strFind & "%' ORDER BY FirstName, LastName"
            Case Is = "Last Name"
                strSql = "SELECT [PrisonNumber] AS [Policy #], LastName +' '+ FirstName +' '+ OtherNames AS [Member Names], " _
                    & "IdNumber as [ID Number], UPPER(REPLACE(CONVERT(CHAR(11), DateIn, 106), ' ', '-')) as [Entry Date], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOut, 106), ' ', '-')) as [Release Date] FROM Prisoners " _
                    & "WHERE LastName LIKE '%" & strFind & "%' ORDER BY LastName, FirstName"
            Case Is = "Prison Number"
                strSql = "SELECT [PolicyNumber] AS [Policy #], LastName +' '+ FirstName +' '+ OtherNames AS [Member Names], " _
                    & "IdNumber as [ID Number], UPPER(REPLACE(CONVERT(CHAR(11), DateIn, 106), ' ', '-')) as [Entry Date], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOut, 106), ' ', '-')) as [Release Date] FROM Prisoners " _
                    & "WHERE PrisonNumber LIKE '%" & strFind & "%' ORDER BY PrisonNumber, FirstName, LastName"
            Case Else
                strSql = "SELECT [PrisonNumber] AS [Policy #], LastName +' '+ FirstName +' '+ OtherNames AS [Member Names], " _
                    & "IdNumber as [ID Number], UPPER(REPLACE(CONVERT(CHAR(11), DateIn, 106), ' ', '-')) as [Entry Date], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOut, 106), ' ', '-')) as [Release Date] FROM Prisoners " _
                    & "WHERE FirstName LIKE '%" & strFind & "%' ORDER BY FirstName, LastName"
        End Select

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

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Prisoners Management"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        gwt_comm.PrintDataGrid(dGrid, "Prisoners Listing")
    End Sub

End Class