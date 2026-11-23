Imports CommonLibrary.Commons
Public Class Organisation

    Public Sub Activate(dbConnectionString As String)
        strConnection = dbConnectionString
        gwt_comm = New CommonLibrary.Commons.CommonFunctions
        gwt_comm.OpenDatabaseConnection()
        Dim frm As New frmOrganisation
        frm.ShowDialog()
    End Sub

End Class
