Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmProcessingDateDefinition

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        dtSetDate = Format(dpStartDate.Value, "dd-MMM-yyyy")
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub frmProcessingDateDefinition_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 380
        Me.Height = 151
    End Sub

End Class