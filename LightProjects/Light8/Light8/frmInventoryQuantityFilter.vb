Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmInventoryQuantityFilter

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub txtMaximum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaximum.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Or e.KeyChar = "-" Then
            Exit Sub
        End If
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtMinimum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMinimum.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Or e.KeyChar = "-" Then
            Exit Sub
        End If
        If Asc(e.KeyChar) = 13 Then txtMaximum.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtMinimum.Text) Then
            MessageBox.Show("Please enter a numeric value for minimum quantity", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMinimum.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtMaximum.Text) Then
            MessageBox.Show("Please enter a numeric value for maximum quantity", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMaximum.Focus()
            Exit Sub
        End If

        dblPublicQuantityFilterMinimum = CDbl(txtMinimum.Text)
        dblPublicQuantityFilterMaximum = CDbl(txtMaximum.Text)

        boolAbort = False
        Me.Close()
    End Sub
End Class
