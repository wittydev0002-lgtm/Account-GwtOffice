Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmServerPath

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        FolderBrowserDialog1.ShowDialog()
        txtPath.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        boolAbort = False
        If String.IsNullOrEmpty(txtPath.Text) Then
            MessageBox.Show("Please enter a valid path for the backup", "Invalid Server Backup Path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnBrowse.Focus()
            Exit Sub
        End If
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = "IF OBJECT_ID(N'SystemServerPath', N'U') IS NULL " _
            & "CREATE TABLE SystemServerPath ([BackupPath] [nvarchar](MAX) NULL)"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemServerPath", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemServerPath " _
            & "(BackupPath) VALUES ('" & txtPath.Text & "')", cnn)
        objCommand.ExecuteNonQuery()

        gwt_comm.getBackupPath()

        MessageBox.Show("Server backup path updated successfully", "Backup Server Path Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Payroll SQL Server Path Specification Error"
        ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub frmServerPath_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 579 : Me.Height = 202
    End Sub

End Class
