Imports System.Windows.Forms
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmEducationSubjects

    Private Sub txtNewSubject_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNewSubject.KeyPress
        If Asc(e.KeyChar) = 13 Then btnAdd.Focus()
    End Sub

    Private Sub txtNewSubject_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewSubject.TextChanged
        If Not String.IsNullOrEmpty(txtNewSubject.Text) Then btnAdd.Enabled = True Else btnAdd.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadTrainingLevelDetails()
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        objCommand = New Data.OleDb.OleDbCommand("SELECT * FROM SystemTrainSubjects", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        dGrid.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader("SubjectName").ToString) Then
                dGrid.Rows.Add(1)
                dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader("SubjectName").ToString
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Training subjects load"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Not String.IsNullOrEmpty(txtNewSubject.Text) Then
            dGrid.Rows.Add(1)
            dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = txtNewSubject.Text
            txtNewSubject.Clear()
            txtNewSubject.Focus()
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemTrainSubjects", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemTrainSubjects (SubjectName) VALUES ('" & dGrid.Rows(i).Cells(0).Value.ToString & "')", cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next
        MessageBox.Show("Training Subjects Updated Successfully", "Training Subjects Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Training subjects save"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub frmEducationSubjects_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadTrainingLevelDetails()
    End Sub

End Class
