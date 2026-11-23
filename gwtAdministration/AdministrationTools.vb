Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class AdministrationTools

    Public Sub Activate(dbConnectionString As String)
        strConnection = dbConnectionString
        gwt_comm = New CommonLibrary.Commons.CommonFunctions
        gwt_comm.OpenDatabaseConnection()
        Dim frm As New frmAdministrationMain
        frm.ShowDialog()
    End Sub

End Class
