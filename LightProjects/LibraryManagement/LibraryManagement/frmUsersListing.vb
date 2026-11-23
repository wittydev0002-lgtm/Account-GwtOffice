Imports ComponentFactory.Krypton.Toolkit

Public Class frmUsersListing
    Private Sub LoadUsers()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT UserName, UserLevel FROM Users ORDER BY UserName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on User Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmSystemUsersListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadUsers()
    End Sub

    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim f As New frmUserSecurityProfile ' 'frmUserSetup
        f.ShowDialog()
        LoadUsers()
    End Sub

    Private Sub GetSelectedUser()
        If dGrid.Rows.Count > 0 Then
            strSelectedUser = dGrid.CurrentRow.Cells(0).Value.ToString
            strSelectedUserLevel = dGrid.CurrentRow.Cells(1).Value.ToString
        End If
    End Sub

    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        GetSelectedUser()
        boolEditStatus = True
        Dim f As New frmUserSecurityProfile 'frmUserSetup
        f.ShowDialog()
        LoadUsers()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        GetSelectedUser()
        boolEditStatus = True
        Dim f As New frmUserSecurityProfile 'frmUserSetup
        f.ShowDialog()
        LoadUsers()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        GetSelectedUser()
        If MessageBox.Show("Are you sure you want to delete user " & strSelectedUser & " from the system?", _
                "User Record Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM Users WHERE UserName = '" & strSelectedUser & "' AND UserLevel = '" & strSelectedUserLevel & "'", cnn)
            sqlCommand.ExecuteNonQuery()
        End If
        LoadUsers()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "User Record Deletion Error"
        ShowErrorMessage()
    End Sub

End Class
