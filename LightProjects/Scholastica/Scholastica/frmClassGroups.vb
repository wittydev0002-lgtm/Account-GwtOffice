Imports CommonLibrary.Commons

Public Class frmClassGroups

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If Not String.IsNullOrEmpty(txtGroup.Text) Then
            If GroupExist(txtGroup.Text) = True Then
                MessageBox.Show("A group with a similar name already exist", "Duplicate Group Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtGroup.SelectAll()
                txtGroup.Focus()
                Exit Sub
            Else
                dGrid.Rows.Add(txtGroup.Text)
                txtGroup.Clear()
                txtGroup.Focus()
            End If
        Else
            MessageBox.Show("Please type in a valid group name e.g. Grade 1s", "Invalid Class Grouping", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGroup.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub frmClassGroups_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT GroupName FROM SC_ClassGroups ORDER BY GroupName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    dGrid.Rows.Add(objReader(0).ToString)
                End If
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolabort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On class group details load"
        ShowErrorMessage()
    End Sub

    Private Function GroupExist(ByVal GroupName As String) As Boolean
        Dim boolReturn As Boolean = False
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    If UCase(dGrid.Rows(p).Cells(0).Value.ToString) = UCase(GroupName) Then
                        boolReturn = True
                        Exit For
                    End If
                End If
            End If
        Next
        Return boolReturn
    End Function

    Private Sub btnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAll.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_ClassGroups", cnn)
        objCommand.ExecuteNonQuery()
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    Dim strGroupName As String = dGrid.Rows(p).Cells(0).Value.ToString
                    Dim strSql As String = "INSERT INTO SC_ClassGroups (GroupName) VALUES ('" & strGroupName & "')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        Next
        MessageBox.Show("Class groups have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On class group details save"
        ShowErrorMessage()
    End Sub

End Class