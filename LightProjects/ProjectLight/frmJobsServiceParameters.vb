Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmJobsServiceParameters

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If UCase(strUserLevel) <> "ADMINISTRATOR" Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM JobsServicesParameters WHERE ServiceName = '" & txtParameter.Text & "'", cnn)
        objCommand.ExecuteNonQuery()

        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO JobsServicesParameters (ServiceName) " _
                        & "VALUES ('" & dGrid.Rows(p).Cells(0).Value.ToString & "')", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        Next

        MessageBox.Show("Air Services have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Jobs/Services Parameters Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmAirCardParameters_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadFormData()
    End Sub

    Private Sub LoadFormData()
        On Error GoTo RaiseErr
        Dim objCmmand As New Data.OleDb.OleDbCommand("SELECT ServiceName FROM JobsServicesParameters ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmmand.ExecuteReader
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Jobs/Services Parameters Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtParameter_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtParameter.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then
            If Not String.IsNullOrEmpty(txtParameter.Text) Then
                dGrid.Rows.Add(txtParameter.Text)
                txtParameter.Clear()
                txtParameter.Focus()
            End If
        End If
    End Sub

End Class
