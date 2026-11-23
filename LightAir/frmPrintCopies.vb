Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPrintCopies

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtCopies.Text) Then
            MessageBox.Show("Please enter a numeric value for number of copies", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCopies.Focus()
            Exit Sub
        Else
            boolAbort = False
            intNumberOfPrintCopies = CInt(txtCopies.Text)
            Me.Close()
        End If
    End Sub

    Private Sub txtCopies_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCopies.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

End Class
