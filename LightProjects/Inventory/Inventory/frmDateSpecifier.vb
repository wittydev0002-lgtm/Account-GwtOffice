Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDateSpecifier

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolabort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        StartDate = Format(dpStartDate.Value, "dd-MMM-yyyy")
        EndDate = Format(dpEndDate.Value, "dd-MMM-yyyy")
        Me.Close()
    End Sub

End Class