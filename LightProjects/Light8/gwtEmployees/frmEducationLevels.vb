Imports System.Windows.Forms
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmEducationLevels

    Private Sub txtNewLevel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNewLevel.KeyPress
        If Asc(e.KeyChar) = 13 Then btnAdd.Focus()
    End Sub

    Private Sub txtNewLevel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewLevel.TextChanged
        If Not String.IsNullOrEmpty(txtNewLevel.Text) Then btnAdd.Enabled = True Else btnAdd.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmEducationLevels_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadTrainingLevelDetails()
    End Sub

    Private Sub LoadTrainingLevelDetails()
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        objCommand = New Data.OleDb.OleDbCommand("SELECT * FROM SystemTrainLevels", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        dGrid.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader("TrainingLevel").ToString) Then
                dGrid.Rows.Add(1)
                dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader("TrainingLevel").ToString
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Training levels load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Not String.IsNullOrEmpty(txtNewLevel.Text) Then
            dGrid.Rows.Add(1)
            dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = txtNewLevel.Text
            txtNewLevel.Clear()
            txtNewLevel.Focus()
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemTrainLevels", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemTrainLevels (TrainingLevel) VALUES ('" & dGrid.Rows(i).Cells(0).Value.ToString & "')", cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next
        MessageBox.Show("Training Levels Updated Successfully", "Training Levels Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Training levels save"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
