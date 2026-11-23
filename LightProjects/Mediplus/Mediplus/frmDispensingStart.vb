Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDispensingStart

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        'Carry forward the patient details
        'and the script number
        boolAbort = False
        Dim frm As New frmMedication
        frm.ShowDialog()
        If boolAbort = True Then
            'Rervese the claim from the temporary table
        Else
            'Save the claim to completed and delete it from the temporary table
        End If
        Me.Close()

    End Sub

    Private Sub btnAddMember_Click(sender As System.Object, e As System.EventArgs) Handles btnAddMember.Click
        boolEditStatus = False
        Dim frm As New frmPatientDetails
        frm.ShowDialog()
    End Sub

End Class
