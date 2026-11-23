Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDateSpecifier

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        StartDate = Format(dpStartDate.Value, "dd-MMM-yyyy")
        EndDate = Format(dpEndDate.Value, "dd-MMM-yyyy")
        Me.Close()
    End Sub

    Private Sub frmDateSpecifier_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 439 : Me.Height = 175
    End Sub

End Class