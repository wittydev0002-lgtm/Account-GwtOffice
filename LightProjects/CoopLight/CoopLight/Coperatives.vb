Imports CommonLibrary.Commons

Public Class Coperatives

    Public Sub Activate(dbConnectionString As String)
        strConnection = dbConnectionString
        gwt_comm = New CommonLibrary.Commons.CommonFunctions
        gwt_comm.OpenDatabaseConnection()
        Dim frm As New frmMainOne
        frm.ShowDialog()
    End Sub

End Class
