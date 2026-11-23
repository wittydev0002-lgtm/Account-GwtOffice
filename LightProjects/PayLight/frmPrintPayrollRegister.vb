Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPrintPayrollRegister

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(txtEmployeeNumber.Text) Then
            MessageBox.Show("Please enter the employee number", "Invalid Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEmployeeNumber.Focus()
            Exit Sub
        Else
            strSelectedEmployee = txtEmployeeNumber.Text
            boolAbort = False
            Me.Close()
        End If
    End Sub

End Class