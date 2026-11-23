Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmTerminateStudent

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(cboReason.Text) Then
            MessageBox.Show("Please select the termination reason", "Missing Termination Reason", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboReason.Focus()
            Exit Sub
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE SC_Students SET " _
            & "CessionDate = '" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "', " _
            & "TerminationReason = '" & cboReason.Text & "', " _
            & "Status = 'INACTIVE' WHERE SC_Students.StudentId = '" & strSelectedAccount & "'", cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Student has been terminated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On student termination"
        ShowErrorMessage()
    End Sub
End Class
