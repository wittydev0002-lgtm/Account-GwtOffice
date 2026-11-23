Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmClassOnImport
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(txtClass.Text) Then
            MessageBox.Show("Please enter a valid value", "Invalid Class", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtClass.Focus
            Exit Sub
        Else
            strSelectedAccount = txtclass.Text
            boolAbort = False
            Me.Close()
        End If
    End Sub

End Class