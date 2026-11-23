Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmWifiSettings

    Private Sub frmWifiSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM CloudSettings", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("ServerName").ToString) Then txtServer.Text = objReader("ServerName").ToString
            If Not IsDBNull(objReader("UserName").ToString) Then txtUserName.Text = objReader("UserName").ToString
            If Not IsDBNull(objReader("UserPassword").ToString) Then txtPassword.Text = objReader("UserPassword").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On cloud settings setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtServer.Text) Then
            MessageBox.Show("Please enter the server name or address", "Invalid Server Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtServer.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtUserName.Text) Then
            MessageBox.Show("Please enter the user name", "Missing User Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUserName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtPassword.Text) Then
            MessageBox.Show("Please enter the password", "Missing Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPassword.Focus()
            Exit Sub
        End If

        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM CloudSettings", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO CloudSettings (ServerName, UserName, UserPassword)" _
            & "VALUES ('" & txtServer.Text & "', '" & txtUserName.Text & "', '" & txtPassword.Text & "')", cnn)
        objCommand.ExecuteNonQuery()
        boolAbort = False
        gwt_comm.AssignSmsHttpSettings()
        If boolAbort = True Then Exit Sub
        MessageBox.Show("Details saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = False
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On SMS HTTP Settings"
        ShowErrorMessage()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to delete the settings?", "Delete Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM CloudSettings", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Settings have been reset successfully", "Cloud Settings reset", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On cloud settings reset"
        ShowErrorMessage()
    End Sub

    Private Sub frmWifiSettings_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 520 : Me.Height = 210
    End Sub

End Class
