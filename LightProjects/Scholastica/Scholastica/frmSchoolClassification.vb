Imports CommonLibrary.Commons

Public Class frmSchoolClassification

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If optConvemtional.Checked = False And optNonConventional.Checked = False Then
            MessageBox.Show("Please select school type", "Invalid Option", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            optConvemtional.Focus()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim strSql As String = "DELETE FROM SC_OperationsType"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Dim strOption As String = "CONVENTIONAL"
        If optNonConventional.Checked = True Then strOption = "NON-CONVENTIONAL"
        strSql = "INSERT INTO SC_OperationsType (OperationType) VALUES ('" & strOption & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        strSchoolOperationType = strOption
        MessageBox.Show("Operation type has been set successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On School Type Setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmSchoolClassification_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        optNonConventional.Checked = False : optConvemtional.Checked = False
        Dim strSql As String = "SELECT OperationType FROM SC_OperationsType"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(objReader(0).ToString) = "NON-CONVENTIONAL" Then
                    optNonConventional.Checked = True
                    optConvemtional.Checked = False
                Else
                    optConvemtional.Checked = True
                    optNonConventional.Checked = False
                End If
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On School Type Setup"
        ShowErrorMessage()
    End Sub

End Class