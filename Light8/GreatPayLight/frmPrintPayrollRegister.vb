Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons

Public Class frmPrintPayrollRegister

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolabort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(txtEmployeeNumber.Text) Then
            MessageBox.Show("Please enter the employee number", "Invalid Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEmployeeNumber.Focus()
            Exit Sub
        Else
            frmMainController.EmployeePayrollRegister(txtEmployeeNumber.Text)
        End If
    End Sub

    Private Sub frmPrintPayrollRegister_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 356 : Me.Height = 167
    End Sub

End Class
