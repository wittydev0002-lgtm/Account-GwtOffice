Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSpecialNotes


    Private Sub frmSpecialNotes_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 415 : Me.Height = 230
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(txtSpecialNotes.Text) Then
            MessageBox.Show("Please enter the notes to be printed on the receipt", "Missing Notes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSpecialNotes.Select()
            Exit Sub
        Else
            strReceiptSpecialNotes = txtSpecialNotes.Text
            boolAbort = False
            Me.Close()
        End If
    End Sub

End Class