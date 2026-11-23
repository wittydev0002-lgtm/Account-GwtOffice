Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCreditNoteOriginalNo

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtOriginalNumber.Text) Then
            MessageBox.Show("Please enter a valid numeric original receipt number!",
                    "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtOriginalNumber.Select()
            Exit Sub
        End If
        If IsNumeric(txtOriginalNumber.Text) Then
            If CInt(txtOriginalNumber.Text) <= 0 Then
                MessageBox.Show("Please enter a valid numeric original receipt number!",
                    "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtOriginalNumber.Select()
                Exit Sub
            End If
        End If
        intOriginalDocumentNumber = CInt(txtOriginalNumber.Text)
        boolAbort = False
        Me.Close()
        Exit Sub
    End Sub
End Class