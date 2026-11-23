Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module CommonFunctions

    Public gwt_comm As CommonLibrary.Commons.CommonFunctions

    Public Sub ShowErrorMessage()
        Dim frm As New frmErrorMessages
        frm.ShowDialog()
    End Sub

    Public Function Remission(ByVal SentenceInMonths As Integer) As Integer
        Dim intReturn As Integer = 0
        If SentenceInMonths > 0 Then
            intReturn = SentenceInMonths - (SentenceInMonths / 3)
        End If
        Return intReturn
    End Function

End Module
