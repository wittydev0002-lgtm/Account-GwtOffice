Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmHighestGrade

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtHighestGrade.Text) Then
            MessageBox.Show("Please enter the highest grade in the school", "Highest Grade Definition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtHighestGrade.Select()
            Exit Sub
        End If
        intHighestSchoolGrade = CInt(txtHighestGrade.Text)
        boolabort = False
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

End Class
