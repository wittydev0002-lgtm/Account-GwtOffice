Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class Purchasing

    Public Sub Activate(dbConnectionString As String)
        strConnection = dbConnectionString
        gwt_comm = New CommonLibrary.Commons.CommonFunctions
        gwt_comm.OpenDatabaseConnection()
        If boolAbort = True Then Exit Sub
        Dim frm As New frmPurchasingMain
        frm.ShowDialog()
    End Sub

End Class
