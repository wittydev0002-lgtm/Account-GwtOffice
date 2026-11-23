Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmAdvancedSearch
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtMinima.Text) Then
            MessageBox.Show("Please enter a valid value for days to start from", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMinima.Select()
            Exit Sub
        End If
        If Not IsNumeric(txtMaxima.Text) Then
            MessageBox.Show("Please enter a valid value for days to end at", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMaxima.Select()
            Exit Sub
        End If

        If CInt(txtMaxima.Text) < CInt(txtMinima.Text) Then
            MessageBox.Show("The days range is not valid. The days from must be less than days to", "Invalid Days Range", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMinima.Select()
            Exit Sub
        End If

        intMinima = CInt(txtMinima.Text)
        intMaxima = CInt(txtMaxima.Text)
        boolAbort = False
        Me.Close()

    End Sub
End Class