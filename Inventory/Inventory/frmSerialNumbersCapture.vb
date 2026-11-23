Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSerialNumbersCapture

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click
        On Error GoTo RaiseErr
        boolAbort = False

        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Inventory Serial Numbers Capture"
        ShowErrorMessage()
    End Sub

End Class
