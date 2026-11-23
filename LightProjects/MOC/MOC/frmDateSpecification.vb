Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDateSpecification
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        dtSetDate = Format(dpDate.Value, "dd-MMM-yyyy")
        boolAbort = False
        Me.Close()
    End Sub

End Class
