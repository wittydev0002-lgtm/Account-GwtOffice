Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmRunRestore

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtFilename.Text) Then
            MessageBox.Show("Please enter the name of the backup", "Invalid Backup Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFilename.Focus()
            Exit Sub
        End If
        If InStr(txtFilename.Text, "desktop", CompareMethod.Text) Then
            MessageBox.Show("Application does not allow restores from desk top. Choose another folder", "Invalid Backup Folder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFilename.Focus()
            Exit Sub
        End If
        RestoreDatabase()
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Application Data Restore Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofd.ShowDialog()
        txtFilename.Text = ofd.FileName
    End Sub

    Private Sub RestoreDatabase()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strCurrDb As String = cnn.Database
        cnn.Dispose()
        ReconnectDatabase(strConnection)
        Dim objCommand As New Data.OleDb.OleDbCommand("USE Master", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("RESTORE DATABASE " & strCurrDb & " FROM DISK = '" & txtFilename.Text & "' WITH REPLACE", cnn)
        objCommand.ExecuteNonQuery()
        cnn = Nothing
        ReconnectDatabase(strConnection)
        MessageBox.Show("Database has been restored successfully", "Database Restore Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Application Data Restore Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ReconnectDatabase(ByVal strReconnection As String)
        On Error GoTo RaiseErr
        cnn = New Data.OleDb.OleDbConnection(strReconnection)
        cnn.Open()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
    End Sub

    Private Sub txtFilename_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilename.KeyPress
        If Asc(e.KeyChar) = 32 Then e.Handled = True
    End Sub

    Private Sub frmRunRestore_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 550 : Me.Height = 190
    End Sub

End Class
