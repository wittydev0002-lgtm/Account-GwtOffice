Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module modCommonVariablesAndFunctions

    Public gwt_comm As CommonLibrary.Commons.CommonFunctions
    Public boolDbCreateMode As Boolean

    Public Sub OpenCurrentDatabaseConnection()
        'Get the database connection string
        boolAbort = False
        If String.IsNullOrEmpty(strConnection) Then
            If MessageBox.Show("The application could not locate the connection file. May be this " & vbCrLf &
            "is your first time to run the application on your machine." & vbCrLf &
            "If you want the configure the database click YES else click NO to end the application",
            "Application connection Failure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                'Dim f As New frmApplicationOptions
                'f.ShowDialog()
                'createDatabase()
                End
            Else
                boolAbort = True
            End If
        End If
        If boolAbort = True Then boolAbort = True
        boolConnectionStatus = True
        ConnectToDatabase()
        If boolConnectionStatus = False Then Exit Sub
        boolAbort = False
        gwt_comm.UpdateDatabase()

        AssignSystemDefaults()

        gwt_comm.getBackupPath()
        gwt_comm.GetPrinterSettings()
    End Sub

    Public Sub ConnectToDatabase()
        'strConnection = "Data Source=10.0.0.110,1433;Initial Catalog=nohs;User ID=sa;Password=nohs;provider=SQLOLEDB"
        Try
            cnn = New OleDb.OleDbConnection(strConnection)
            cnn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Database Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            boolConnectionStatus = False
        End Try
    End Sub

    Public Sub AssignSystemDefaults()

    End Sub
End Module
