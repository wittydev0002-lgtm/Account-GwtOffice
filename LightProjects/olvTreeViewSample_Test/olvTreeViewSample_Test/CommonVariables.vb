Module CommonVariables

    Public connString As String
    Public conn As Data.OleDb.OleDbConnection

    Public Sub OpenDatabase()
        Try
            connString = "Data Source=.\;Initial Catalog=Test;User id=sa;Password=ochmas;Provider=SQLOLEDB"
            conn = New Data.OleDb.OleDbConnection(connString)
            conn.Open()
        Catch e As Exception
            MsgBox(e.Message)
        End Try
    End Sub

End Module
