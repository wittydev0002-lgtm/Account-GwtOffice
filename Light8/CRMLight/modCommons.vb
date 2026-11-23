Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module modCommons

    Public gwt_comm As CommonLibrary.Commons.CommonFunctions


    Public Function LastProspectId() As Integer
        On Error GoTo RaiseErr
        Dim intReturn As Integer = 0
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT ProspectId FROM Prospects ORDER BY ProspectId DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intReturn = CInt(UCase(objReader(0).ToString))
        End If
        objReader.Close()
        Return intReturn

        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on last prospect ID allocated fetch"
        gwt_comm.ShowErrorMessage()
    End Function

End Module
