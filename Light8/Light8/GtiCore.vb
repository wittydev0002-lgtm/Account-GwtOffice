Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Imports CommonLibrary.Commons

''' <summary>
''' Shared code for the GTI Air Phase 1 upgrade: database additions, user access
''' levels, and protected database connection settings.
''' </summary>
Module GtiCore

#Region "Access levels"

    Public Const GtiLevelOffice As String = "Level 1 - Office"
    Public Const GtiLevelManager As String = "Level 2 - Office Manager"
    Public Const GtiLevelOwner As String = "Level 3 - Owner"
    Public Const GtiLevelTechnician As String = "Technician"

    ''' <summary>Access level of the logged-in user. Empty means an older user record that has no level yet.</summary>
    Public GtiCurrentAccessLevel As String = ""

    Public ReadOnly Property GtiAccessLevels As String()
        Get
            Return New String() {GtiLevelOffice, GtiLevelManager, GtiLevelOwner, GtiLevelTechnician}
        End Get
    End Property

    ''' <summary>
    ''' The older screens only know "Administrator", "Manager" and everything else.
    ''' Each access level is stored together with the matching older value so those screens keep working.
    ''' </summary>
    Public Function GtiLegacyUserLevel(ByVal accessLevel As String) As String
        Select Case accessLevel
            Case GtiLevelOwner : Return "Administrator"
            Case GtiLevelManager : Return "Manager"
            Case Else : Return "Operator"
        End Select
    End Function

    ''' <summary>Access level to show for a user record that was created before access levels existed.</summary>
    Public Function GtiAccessLevelFromLegacy(ByVal legacyUserLevel As String) As String
        Select Case UCase(Trim(legacyUserLevel & ""))
            Case "ADMINISTRATOR" : Return GtiLevelOwner
            Case "MANAGER" : Return GtiLevelManager
            Case Else : Return GtiLevelOffice
        End Select
    End Function

    ' Row order of the permission grid on the user setup screen.
    Private ReadOnly GtiPermissionNames As String() = {
        "Quotations", "Invoicing", "Customers", "Suppliers", "SalesAgents", "Inventory", "CashSales",
        "StoresManagement", "ReceiveGoods", "CashbookEntries", "StockTake", "LedgerEntries", "AssetManagement",
        "PrintStatements", "PrintLedgers", "PrintTrialBalance", "BankReconciliation", "CashbookSetup",
        "BranchSetup", "ControlNumbersSetup", "TransferStock", "DefaultSalesAccountSetup",
        "ReinitialiseInventoryQuantities", "DefineServerBackupPath", "CategoriesSetup", "StockDataUpload",
        "StockDataDownload", "SalesDataDownloads", "SalesDataUploads", "CashbookDataUpload",
        "CashbookDataDownload", "Expenses", "UserSetup", "Exchanges", "PrescribedDrugs", "ReturnsRejections"}

    ''' <summary>
    ''' Default permissions for an access level, in the row order of the user setup grid.
    ''' 2 = full access, 1 = read only, 0 = no access.
    ''' </summary>
    Public Function GtiPermissionPreset(ByVal accessLevel As String) As Integer()
        Dim preset(GtiPermissionNames.Length - 1) As Integer
        Dim full As String() = {}
        Dim readOnlyItems As String() = {}

        Select Case accessLevel
            Case GtiLevelOwner
                full = GtiPermissionNames
            Case GtiLevelManager
                ' Everything except the system setup items.
                Dim setupOnly As String() = {"UserSetup", "BranchSetup", "ControlNumbersSetup", "CashbookSetup",
                    "DefaultSalesAccountSetup", "ReinitialiseInventoryQuantities", "DefineServerBackupPath"}
                Dim items As New List(Of String)
                For Each name As String In GtiPermissionNames
                    If Array.IndexOf(setupOnly, name) < 0 Then items.Add(name)
                Next
                full = items.ToArray()
            Case GtiLevelOffice
                full = New String() {"Quotations", "Invoicing", "Customers", "Suppliers", "ReceiveGoods",
                    "PrintStatements", "ReturnsRejections"}
                readOnlyItems = New String() {"Inventory"}
            Case Else
                ' Technician: job sheet only, no office permissions.
        End Select

        For i As Integer = 0 To GtiPermissionNames.Length - 1
            If Array.IndexOf(full, GtiPermissionNames(i)) >= 0 Then
                preset(i) = 2
            ElseIf Array.IndexOf(readOnlyItems, GtiPermissionNames(i)) >= 0 Then
                preset(i) = 1
            Else
                preset(i) = 0
            End If
        Next
        Return preset
    End Function

    ''' <summary>Reads the access level of the user who has just logged in.</summary>
    Public Sub GtiLoadCurrentAccessLevel()
        GtiCurrentAccessLevel = ""
        Try
            Dim value As Object = GtiScalar("SELECT AccessLevel FROM Users WHERE UserName = ?", strUserName)
            If value IsNot Nothing AndAlso Not IsDBNull(value) Then GtiCurrentAccessLevel = Trim(value.ToString())
            If GtiCurrentAccessLevel = "" Then
                ' Older user record: Administrators and Managers map to the new levels,
                ' any other older level keeps exactly the behaviour it had before.
                Select Case UCase(Trim(strUserLevel & ""))
                    Case "ADMINISTRATOR" : GtiCurrentAccessLevel = GtiLevelOwner
                    Case "MANAGER" : GtiCurrentAccessLevel = GtiLevelManager
                End Select
            End If
        Catch ex As Exception
            GtiCurrentAccessLevel = ""
        End Try
    End Sub

    Public Function GtiIsOwner() As Boolean
        Return GtiCurrentAccessLevel = GtiLevelOwner
    End Function

    ''' <summary>Number of users who have full (Owner) access, optionally leaving one user out.</summary>
    Public Function GtiOwnerCount(Optional ByVal exceptUserName As String = "") As Integer
        Dim value As Object = GtiScalar("SELECT COUNT(*) FROM Users WHERE UserLevel = 'Administrator' AND UserName <> ?", exceptUserName & "")
        If value Is Nothing OrElse IsDBNull(value) Then Return 0
        Return CInt(value)
    End Function

#End Region

#Region "Projects"

    ''' <summary>Client to pre-select when a new project is started from the client's project list.</summary>
    Public GtiPresetProjectCustomerNumber As String = Nothing
    Public GtiPresetProjectCustomerName As String = Nothing

#End Region

#Region "Database helpers"

    Private Function GtiCommand(ByVal sql As String, ByVal args As Object()) As OleDbCommand
        Dim cmd As New OleDbCommand(sql, cnn)
        If args IsNot Nothing Then
            For Each arg As Object In args
                cmd.Parameters.AddWithValue("?", If(arg, DBNull.Value))
            Next
        End If
        Return cmd
    End Function

    Public Function GtiScalar(ByVal sql As String, ByVal ParamArray args As Object()) As Object
        Using cmd As OleDbCommand = GtiCommand(sql, args)
            Return cmd.ExecuteScalar()
        End Using
    End Function

    Public Function GtiExecute(ByVal sql As String, ByVal ParamArray args As Object()) As Integer
        Using cmd As OleDbCommand = GtiCommand(sql, args)
            Return cmd.ExecuteNonQuery()
        End Using
    End Function

    Public Function GtiTable(ByVal sql As String, ByVal ParamArray args As Object()) As DataTable
        Dim table As New DataTable()
        Using cmd As OleDbCommand = GtiCommand(sql, args)
            Using adapter As New OleDbDataAdapter(cmd)
                adapter.Fill(table)
            End Using
        End Using
        Return table
    End Function

    Public Function GtiColumnExists(ByVal tableName As String, ByVal columnName As String) As Boolean
        Dim value As Object = GtiScalar("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = ? AND COLUMN_NAME = ?", tableName, columnName)
        Return value IsNot Nothing AndAlso Not IsDBNull(value) AndAlso CInt(value) > 0
    End Function

    Public Function GtiTableExists(ByVal tableName As String) As Boolean
        Dim value As Object = GtiScalar("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = ?", tableName)
        Return value IsNot Nothing AndAlso Not IsDBNull(value) AndAlso CInt(value) > 0
    End Function

    Private Sub GtiAddColumn(ByVal tableName As String, ByVal columnName As String, ByVal definition As String)
        If Not GtiTableExists(tableName) Then Exit Sub
        If GtiColumnExists(tableName, columnName) Then Exit Sub
        GtiExecute("ALTER TABLE [" & tableName & "] ADD [" & columnName & "] " & definition)
    End Sub

    ''' <summary>
    ''' Adds the columns the Phase 1 upgrade needs. Only ever adds; existing columns and data are not touched,
    ''' so the previous version of the program keeps working on the same database.
    ''' </summary>
    Public Sub GtiEnsureSchema()
        Try
            GtiAddColumn("Users", "AccessLevel", "NVARCHAR(40) NOT NULL DEFAULT ''")
            GtiAddColumn("ProjectsMain", "SiteName", "NVARCHAR(200) NOT NULL DEFAULT ''")
            GtiAddColumn("ProjectsMain", "SiteAddress", "NVARCHAR(500) NOT NULL DEFAULT ''")
            GtiAddColumn("ProjectsMain", "SiteContact", "NVARCHAR(150) NOT NULL DEFAULT ''")
            GtiAddColumn("ProjectsMain", "SitePhone", "NVARCHAR(70) NOT NULL DEFAULT ''")
            GtiAddColumn("ProjectsMain", "ProjectStatus", "NVARCHAR(30) NOT NULL DEFAULT 'Active'")
        Catch ex As Exception
            MessageBox.Show("The database could not be prepared for this version of the program." & vbCrLf & vbCrLf & ex.Message,
                "Database Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    ''' <summary>Writes a line to the existing activity log (who changed what, and when).</summary>
    Public Sub GtiLogActivity(ByVal tableName As String, ByVal activity As String)
        Try
            If Not GtiTableExists("ActivityTrek") Then Exit Sub
            If activity.Length > 450 Then activity = activity.Substring(0, 450)
            GtiExecute("INSERT INTO ActivityTrek ([TransDate],[UserName],[Branch],[TableName],[Activity]) VALUES (GETDATE(), ?, ?, ?, ?)",
                strUserName & "", strUserBranch & "", tableName, activity)
        Catch ex As Exception
            ' The log must never stop the user's work.
        End Try
    End Sub

#End Region

#Region "Database connection settings"

    Private Const GtiProtectedPrefix As String = "gti1:"
    Private ReadOnly GtiEntropy As Byte() = Encoding.UTF8.GetBytes("GTI.Light8.Connection")

    ''' <summary>
    ''' Protects a connection string for storage in the Data folder, so the database password is not kept as readable text.
    ''' It can only be read back on the same computer.
    ''' </summary>
    Public Function GtiProtectConnection(ByVal connectionString As String) As String
        Dim data As Byte() = ProtectedData.Protect(Encoding.UTF8.GetBytes(connectionString), GtiEntropy, DataProtectionScope.LocalMachine)
        Return GtiProtectedPrefix & Convert.ToBase64String(data)
    End Function

    ''' <summary>Returns the usable connection string for a stored line (older, unprotected lines are returned as they are).</summary>
    Public Function GtiResolveConnection(ByVal stored As String) As String
        If String.IsNullOrEmpty(stored) Then Return stored
        Dim text As String = stored.Trim()
        If Not text.StartsWith(GtiProtectedPrefix, StringComparison.OrdinalIgnoreCase) Then Return stored
        Try
            Dim data As Byte() = Convert.FromBase64String(text.Substring(GtiProtectedPrefix.Length))
            Return Encoding.UTF8.GetString(ProtectedData.Unprotect(data, GtiEntropy, DataProtectionScope.LocalMachine))
        Catch ex As Exception
            Throw New InvalidOperationException("The saved database connection cannot be read on this computer. " _
                & "Please enter the connection details again under 'Database connection'.", ex)
        End Try
    End Function

#End Region

End Module
