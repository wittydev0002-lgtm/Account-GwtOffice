Imports System.Data.OleDb
Imports System.IO

''' <summary>
''' Enter, test and save the connection to the company database (cloud server or local server).
''' The saved connection is protected so the database password is not stored as readable text.
''' </summary>
Public Class frmGtiDatabaseConnection
    Inherits Form

    Private txtCompany As New TextBox()
    Private txtServer As New TextBox()
    Private txtPort As New TextBox()
    Private txtDatabase As New TextBox()
    Private txtLogin As New TextBox()
    Private txtPassword As New TextBox()
    Private WithEvents chkWindows As New CheckBox()
    Private WithEvents btnTest As New Button()
    Private WithEvents btnSave As New Button()
    Private WithEvents btnClose As New Button()
    Private lblStatus As New Label()

    ''' <summary>True when a connection was saved, so the caller can reload its list.</summary>
    Public Property ConnectionSaved As Boolean = False

    Public Sub New()
        Me.Text = "Database Connection"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False : Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.Font = New Font("Segoe UI", 9.0F)
        Me.ClientSize = New Size(470, 372)
        Me.BackColor = Color.White

        Dim info As New Label()
        info.SetBounds(14, 10, 442, 36)
        info.Text = "Enter the details of the database server. Use 'Test connection' first, then 'Save and use'."
        Me.Controls.Add(info)

        AddRow("Company name", txtCompany, 54, 290)
        AddRow("Server address", txtServer, 86, 290)
        AddRow("Port", txtPort, 118, 80)
        AddRow("Database name", txtDatabase, 150, 290)

        chkWindows.SetBounds(150, 180, 300, 22)
        chkWindows.Text = "Use Windows login (server on this computer)"
        Me.Controls.Add(chkWindows)

        AddRow("Login name", txtLogin, 208, 200)
        AddRow("Password", txtPassword, 240, 200)
        txtPassword.UseSystemPasswordChar = True
        txtPort.Text = "1433"
        txtPort.MaxLength = 5

        Dim portHint As New Label() With {.Text = "Leave empty for a local server.", .AutoSize = True, .ForeColor = Color.DimGray}
        portHint.Location = New Point(236, 121)
        Me.Controls.Add(portHint)

        lblStatus.SetBounds(14, 272, 442, 50)
        lblStatus.ForeColor = Color.DimGray
        Me.Controls.Add(lblStatus)

        btnTest.SetBounds(14, 332, 120, 28) : btnTest.Text = "Test connection"
        btnSave.SetBounds(256, 332, 104, 28) : btnSave.Text = "Save and use"
        btnClose.SetBounds(366, 332, 90, 28) : btnClose.Text = "Close"
        Me.Controls.AddRange(New Control() {btnTest, btnSave, btnClose})
        Me.CancelButton = btnClose
    End Sub

    Private Sub AddRow(ByVal caption As String, ByVal box As TextBox, ByVal y As Integer, ByVal width As Integer)
        Dim label As New Label() With {.Text = caption, .AutoSize = True}
        label.Location = New Point(14, y + 3)
        box.SetBounds(150, y, width, 23)
        Me.Controls.Add(label)
        Me.Controls.Add(box)
    End Sub

    Private Sub chkWindows_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkWindows.CheckedChanged
        txtLogin.Enabled = Not chkWindows.Checked
        txtPassword.Enabled = Not chkWindows.Checked
    End Sub

    ''' <summary>Checks the entries and builds the connection string. Returns Nothing when something is missing.</summary>
    Private Function BuildConnectionString() As String
        Dim server As String = Trim(txtServer.Text)
        Dim database As String = Trim(txtDatabase.Text)
        Dim port As String = Trim(txtPort.Text)

        If server = "" Then Return Missing("Please enter the server address.", txtServer)
        If database = "" Then Return Missing("Please enter the database name.", txtDatabase)
        If port <> "" Then
            Dim portNumber As Integer
            If Not Integer.TryParse(port, portNumber) OrElse portNumber < 1 OrElse portNumber > 65535 Then Return Missing("The port must be a number between 1 and 65535.", txtPort)
        End If
        If Not chkWindows.Checked Then
            If Trim(txtLogin.Text) = "" Then Return Missing("Please enter the login name.", txtLogin)
            If txtPassword.Text = "" Then Return Missing("Please enter the password.", txtPassword)
        End If
        For Each box As TextBox In New TextBox() {txtServer, txtDatabase, txtLogin, txtPassword}
            If box.Text.IndexOfAny(New Char() {";"c, "|"c, ChrW(13), ChrW(10)}) >= 0 Then Return Missing("The characters ; and | cannot be used here.", box)
        Next

        ' A named local instance (for example .\SQLEXPRESS) is addressed by name, not by port.
        Dim dataSource As String = server
        If port <> "" AndAlso server.IndexOf("\"c) < 0 AndAlso server.IndexOf(","c) < 0 Then dataSource = server & "," & port

        Dim builder As New OleDbConnectionStringBuilder()
        builder.Provider = "SQLOLEDB"
        builder.DataSource = dataSource
        builder("Initial Catalog") = database
        If chkWindows.Checked Then
            builder("Integrated Security") = "SSPI"
        Else
            builder("User ID") = Trim(txtLogin.Text)
            builder("Password") = txtPassword.Text
        End If
        Return builder.ConnectionString
    End Function

    Private Function Missing(ByVal message As String, ByVal box As Control) As String
        MessageBox.Show(message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        box.Focus()
        Return Nothing
    End Function

    ''' <summary>Opens the connection and checks that it is a database of this program.</summary>
    Private Function TestConnection(ByVal connectionString As String, ByRef message As String) As Boolean
        Try
            Using connection As New OleDbConnection(connectionString & ";Connect Timeout=15")
                connection.Open()
                Using cmd As New OleDbCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME IN ('Users', 'ControlNumbers', 'Customers')", connection)
                    If CInt(cmd.ExecuteScalar()) < 3 Then
                        message = "Connected to the server, but this database does not contain the program's tables. Please check the database name."
                        Return False
                    End If
                End Using
            End Using
            message = "Connection successful. The company database was found."
            Return True
        Catch ex As Exception
            message = "Connection failed: " & ex.Message
            Return False
        End Try
    End Function

    Private Sub btnTest_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTest.Click
        Dim connectionString As String = BuildConnectionString()
        If connectionString Is Nothing Then Exit Sub
        RunTest(connectionString)
    End Sub

    Private Function RunTest(ByVal connectionString As String) As Boolean
        Dim message As String = Nothing
        Cursor = Cursors.WaitCursor
        lblStatus.ForeColor = Color.DimGray
        lblStatus.Text = "Connecting..."
        lblStatus.Refresh()
        Dim ok As Boolean = TestConnection(connectionString, message)
        Cursor = Cursors.Default
        lblStatus.ForeColor = If(ok, Color.Green, Color.Firebrick)
        lblStatus.Text = message
        Return ok
    End Function

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Dim company As String = Trim(txtCompany.Text)
        If company = "" Then
            Missing("Please enter the company name. It is shown in the company list on the login screen.", txtCompany)
            Exit Sub
        End If
        If company.IndexOfAny(New Char() {"|"c, ChrW(13), ChrW(10)}) >= 0 Then
            Missing("The character | cannot be used in the company name.", txtCompany)
            Exit Sub
        End If
        Dim connectionString As String = BuildConnectionString()
        If connectionString Is Nothing Then Exit Sub

        If Not RunTest(connectionString) Then
            If MessageBox.Show("The connection test failed, so the program will not be able to log in with these details." & vbCrLf & vbCrLf _
                & "Do you want to save them anyway?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then Exit Sub
        End If

        Try
            Dim dataFolder As String = Path.Combine(Application.StartupPath, "Data")
            Directory.CreateDirectory(dataFolder)
            Dim stored As String = GtiProtectConnection(connectionString)

            ' Company list: replace the entry with the same name, otherwise add it.
            Dim cataloguePath As String = Path.Combine(dataFolder, "PayCatalogue.txt")
            Dim lines As New List(Of String)
            If File.Exists(cataloguePath) Then
                For Each line As String In File.ReadAllLines(cataloguePath)
                    If line.Trim() = "" Then Continue For
                    Dim name As String = line.Split("|"c)(0)
                    If Not String.Equals(name.Trim(), company, StringComparison.OrdinalIgnoreCase) Then lines.Add(line)
                Next
            End If
            lines.Add(company & "|" & stored)
            File.WriteAllLines(cataloguePath, lines.ToArray())

            ' The connection used at the next login.
            File.WriteAllText(Path.Combine(dataFolder, "ActiveConnection.txt"), stored & Environment.NewLine)

            ConnectionSaved = True
            MessageBox.Show("The connection has been saved. It will be used the next time you log in.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("The connection could not be saved." & vbCrLf & vbCrLf & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
