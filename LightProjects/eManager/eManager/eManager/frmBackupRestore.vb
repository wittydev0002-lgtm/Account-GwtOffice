Imports ComponentFactory.Krypton.Toolkit
Imports System.IO

Public Class frmBackupRestore

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnBackup_Click(sender As System.Object, e As System.EventArgs) Handles btnBackup.Click
        'Backup the database
        On Error GoTo RaiseErr
        boolAbort = False
        'Close the database first
        cnn.Close()
        Dim strFileName As String = Nothing
        sfd.ShowDialog()
        strFileName = sfd.FileName
        If String.IsNullOrEmpty(strFileName) Then
            KryptonMessageBox.Show("No file name defined for this process", _
            "Data Backup", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        'Copy of the backup database to the user specified folder
        System.IO.File.Copy(Application.StartupPath & "\eManager.sdf", strFileName, True)
        OpenDatabaseConnection()
        Cursor = Cursors.Default
        KryptonMessageBox.Show("Data backed up successfully", _
            "Data Backup", MessageBoxButtons.OK, MessageBoxIcon.Information)
        boolAbort = False
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On data backup"
        ShowErrorMessage()
    End Sub

    Private Sub btnRestore_Click(sender As System.Object, e As System.EventArgs) Handles btnRestore.Click
        'restore the database
        On Error GoTo RaiseErr
        boolAbort = False
        'Close the database first
        cnn.Close()
        Dim strFileName As String = Nothing
        ofd.ShowDialog()
        strFileName = ofd.FileName
        If String.IsNullOrEmpty(strFileName) Then
            KryptonMessageBox.Show("No file name defined for this process", _
            "Data Restore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        'Copy of the backup database to the user specified folder
        System.IO.File.Copy(strFileName, Application.StartupPath & "\eManager.sdf", True)
        OpenDatabaseConnection()
        Cursor = Cursors.Default
        KryptonMessageBox.Show("Data restored successfully", _
            "Data Restore", MessageBoxButtons.OK, MessageBoxIcon.Information)
        boolAbort = False
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On data restore"
        ShowErrorMessage()
    End Sub

End Class
