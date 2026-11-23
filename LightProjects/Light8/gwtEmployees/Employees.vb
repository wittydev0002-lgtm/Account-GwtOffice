Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class Employees

    Public Sub Activate(dbConnectionString As String)
        strConnection = dbConnectionString
        gwt_comm = New CommonLibrary.Commons.CommonFunctions
        gwt_comm.OpenDatabaseConnection()
        If boolAbort = True Then Exit Sub
        Dim frm As New frmEmployeesMain
        frm.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Employee Records Management"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
