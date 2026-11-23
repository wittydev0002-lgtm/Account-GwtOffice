Imports ComponentFactory.Krypton.Toolkit

Public Class frmRunBackup

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtFilename.Text) Then
            MessageBox.Show("Please enter the name of the backup", "Invalid Backup Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFilename.Focus()
            Exit Sub
        End If
        If InStr(txtBackupPath.Text, "desktop", CompareMethod.Text) Then
            MessageBox.Show("Application does not allow backups to desk top. Choose another folder", _
                "Invalid Backup Folder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBackupPath.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtBackupPath.Text) Then
            MessageBox.Show("Please specify the folder where to backup your files", "Backup Path Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            BackupDatabase()
        End If
        Me.Hide()
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Payroll Files Backup Error"
        ShowErrorMessage()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        fbd.ShowDialog()
        txtBackupPath.Text = fbd.SelectedPath
    End Sub

    Private Sub BackupDatabase()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        boolAbort = False
        'If the backup folder does not exist within the application run path
        'create it. All databases will first be saved here before moving them
        'to any internal or external store        
        'If System.IO.Directory.Exists(Application.StartupPath & "\Backup") = False Then
        '    System.IO.Directory.CreateDirectory(Application.StartupPath & "\Backup")
        'End If

        Dim strFilename As String = txtFilename.Text
        ''Get the name of the backup filename from the typed in name
        'If String.IsNullOrEmpty(strServerBackkupPath) Then
        '    MessageBox.Show("Please set up the SQL Server Backup Path before proceeding", _
        '        "Missing Server Backup Path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Dim f As New frmServerPath
        '    f.ShowDialog()
        'End If
        'If boolAbort = True Then Exit Sub
        'getBackupPath()
        Dim strSql As String = Nothing
        'Close the current connection and then connect to the master database
        Dim strMasterConnection As String = strConnection
        Dim strPriorConnection As String = strConnection
        Dim splitConnectionString() As String = Split(strMasterConnection, ";")
        Dim strToReplace As String = Nothing
        Dim strOldDatabase As String = Nothing

        Dim i As Integer = 0
        For i = 0 To splitConnectionString.Length - 1
            If UCase(Mid(splitConnectionString(i), 1, 15)) = "INITIAL CATALOG" Then
                strToReplace = "Initial catalog=Master"
                strOldDatabase = splitConnectionString(i)
                Exit For
            End If
        Next
        strMasterConnection = Replace(strMasterConnection, strOldDatabase, strToReplace, 1)
        cnn.Close()

        Dim masterConn As New Data.OleDb.OleDbConnection(strMasterConnection)
        masterConn.Open()
        If Mid(txtBackupPath.Text, txtBackupPath.Text.Length, 1) = "\" Or _
            Mid(txtBackupPath.Text, txtBackupPath.Text.Length, 1) = "/" Then
            txtBackupPath.Text = Mid(txtBackupPath.Text, 1, (txtBackupPath.Text.Length - 1))
        End If

        strSql = "BACKUP DATABASE " & cnn.Database.ToString() & " TO " _
            & "DISK = '" & txtBackupPath.Text & "\" & txtFilename.Text & "' WITH INIT" '& Application.StartupPath & "\Backup\" & strFilename & ".BAK'"
        Dim myCommand As New OleDb.OleDbCommand(strSql, masterConn)
        myCommand.ExecuteNonQuery()
        'close the master connection
        masterConn.Close()
        'Open the previous connection
        cnn.Dispose()
        ReconnectDatabase(strConnection)
        ''Add the database backup name to the catalogue
        'strSql = "INSERT INTO SystemBackupCatalogue (BackupName, BackupDate, UserName) " _
        '    & "VALUES ('" & txtFilename.Text & "', '" & Format(Now, "dd-MMM-yyyy") & "', '" & strUserName & "')"
        'myCommand = New OleDb.OleDbCommand(strSql, cnn)
        'myCommand.ExecuteNonQuery()

        ''Copy of the backup database to the user specified folder
        'System.IO.File.Copy(strServerBackkupPath & "\" & txtFilename.Text, txtBackupPath.Text & "\" & txtFilename.Text & ".BAK", True)
        MessageBox.Show("Database has been backed up successfully", "Database Backup Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
        ReconnectDatabase(strPriorConnection)
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

End Class