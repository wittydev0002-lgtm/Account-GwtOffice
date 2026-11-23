Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmStudentSubjects

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        AddSubject()
    End Sub

    Private Sub AddSubject()
        If Not String.IsNullOrEmpty(txtSubjects.Text) Then
            dGrid.Rows.Add(txtSubjects.Text)
            txtSubjects.Clear()
            txtSubjects.Focus()
        Else
            MessageBox.Show("Please enter the subject name", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSubjects.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_Subjects", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strSubject As String = Nothing
            If Not Object.Equals(dGrid.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(0).Value.ToString) Then
                    strSubject = dGrid.Rows(i).Cells(0).Value.ToString
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SC_Subjects(Subject) VALUES ('" & strSubject & "')", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        Next
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Subjects MAnagement"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Subject FROM SC_Subjects ORDER BY Subject"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Subjects MAnagement"
        ShowErrorMessage()
    End Sub

    Private Sub frmStudentSubjects_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub txtSubjects_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSubjects.KeyPress
        If Asc(e.KeyChar) = 13 Then
            AddSubject()
        End If
    End Sub

End Class
