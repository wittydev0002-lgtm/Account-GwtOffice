Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSmsHttpSettings

    Private Sub frmSmsHttpSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM HttpSmsServerSettings", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("ServerName").ToString) Then txtServer.Text = objReader("ServerName").ToString
            If Not IsDBNull(objReader("PortNumber").ToString) Then txtPort.Text = objReader("PortNumber").ToString
            If Not IsDBNull(objReader("UserName").ToString) Then txtUserName.Text = objReader("UserName").ToString
            If Not IsDBNull(objReader("UserPassword").ToString) Then txtPassword.Text = objReader("UserPassword").ToString
            If Not IsDBNull(objReader("Originator").ToString) Then txtDescription.Text = objReader("Originator").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On SMS http settings setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmSmsHttpSettings_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Width = 549
        Me.Height = 267 '549; 267
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
        If String.IsNullOrEmpty(txtPort.Text) Then
            MessageBox.Show("Please enter the port number as supplied by your host", "Invalid Port Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPort.Focus()
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
        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter the originator your cell number or description", "Missing Originator", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        End If

        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM HttpSmsServerSettings", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO HttpSmsServerSettings (ServerName, " _
            & "PortNumber, UserName, UserPassword, Originator) VALUES ('" & txtServer.Text & "', " _
            & "'" & txtPort.Text & "', '" & txtUserName.Text & "', '" & txtPassword.Text & "', '" & txtDescription.Text & "')", cnn)
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
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM HttpSmsServerSettings", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Settings have been reset successfully", "Sms Settings reset", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On SMS Http settings reset"
        ShowErrorMessage()
    End Sub

End Class
