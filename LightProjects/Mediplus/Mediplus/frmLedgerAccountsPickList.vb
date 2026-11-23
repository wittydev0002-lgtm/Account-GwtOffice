Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLedgerAccountsPickList

    Dim boolFormLoading As Boolean

    Private Sub frmLedgerAccountsPickList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        boolFormLoading = True
        LoadAccounts()
        boolFormLoading = False
    End Sub

    Private Sub LoadAccounts()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT AccountNumber, AccountName FROM " _
            & "LedgerAccounts WHERE SubAccountOf = 'None' ORDER BY AccountNumber"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridMain.Rows.Clear()
        While objReader.Read
            dGridMain.Rows.Add(objReader(0), objReader(1))
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Ledger Main Ledger Accounts Load"
        ShowErrorMessage()
    End Sub

    Private Sub ShowSubAccounts(ByVal MainAccount As String)
        If boolFormLoading = True Then Exit Sub
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName, SubAccountOf FROM LedgerAccounts " _
                & "WHERE SubAccountOf = '" & MainAccount & "' ORDER BY SubAccountOf, AccountNumber", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridSubs.Rows.Clear()
        While objReader.Read
            dGridSubs.Rows.Add(objReader(0).ToString, objReader(1).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Ledger Main Ledger Accounts Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGridMain_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGridMain.CellContentClick
        If boolFormLoading = True Then Exit Sub
        If dGridMain.RowCount <= 0 Then Exit Sub
        ShowSubAccounts(dGridMain.CurrentRow.Cells(0).Value.ToString)
    End Sub

    Private Sub dGridMain_SelectionChanged(sender As Object, e As EventArgs) Handles dGridMain.SelectionChanged
        If boolFormLoading = True Then Exit Sub
        If dGridMain.RowCount <= 0 Then Exit Sub
        ShowSubAccounts(dGridMain.CurrentRow.Cells(0).Value.ToString)
    End Sub

    Private Sub dGridMain_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dGridMain.RowEnter
        If boolFormLoading = True Then Exit Sub
        If dGridMain.RowCount <= 0 Then Exit Sub
        ShowSubAccounts(dGridMain.CurrentRow.Cells(0).Value.ToString)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        boolFormLoading = True
        LoadAccounts()
        boolFormLoading = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        GetSelected()
    End Sub

    Private Sub GetSelected()
        If dGridMain.RowCount <= 0 Then
            MessageBox.Show("There are no accounts to select from", "Missing Ledger Accounts", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If dGridSubs.RowCount > 0 Then
            strSelectedAccount = dGridSubs.CurrentRow.Cells(0).Value.ToString
            strSelectedAccountName = dGridSubs.CurrentRow.Cells(1).Value.ToString
        Else
            strSelectedAccount = dGridMain.CurrentRow.Cells(0).Value.ToString
            strSelectedAccountName = dGridMain.CurrentRow.Cells(1).Value.ToString
        End If
        Me.Close()
    End Sub

    Private Sub dGridMain_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGridMain.CellContentDoubleClick
        GetSelected()
    End Sub

    Private Sub dGridSubs_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGridSubs.CellContentDoubleClick
        GetSelected()
    End Sub
End Class