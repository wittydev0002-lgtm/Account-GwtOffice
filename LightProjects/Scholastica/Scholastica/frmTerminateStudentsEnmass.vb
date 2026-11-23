Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmTerminateStudentsEnmass

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadClasses()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT ClassName FROM SC_Classes ORDER BY ClassName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        chkLstClasses.Items.Clear()

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                chkLstClasses.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Classes Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmTerminateStudentsEnmass_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadClasses()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(cboReason.Text) Then
            MessageBox.Show("Please select the termination reason", "Missing Termination Reason", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboReason.Focus()
            Exit Sub
        End If
        If chkLstClasses.CheckedItems.Count <> 0 Then
            For p As Integer = 0 To chkLstClasses.CheckedItems.Count - 1
                Dim strClass As String = chkLstClasses.CheckedItems(p).ToString()
                Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE SC_Students SET " _
                    & "CessionDate = '" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "', " _
                    & "TerminationReason = '" & cboReason.Text & "', " _
                    & "Status = 'INACTIVE' WHERE SC_Students.ClassName = '" & strClass & "'", cnn)
                objCommand.ExecuteNonQuery()
            Next
        End If
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
