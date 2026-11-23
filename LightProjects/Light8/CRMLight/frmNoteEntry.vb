Imports CommonLibrary.Commons

Public Class frmNoteEntry

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        strNoteEntry = gwt_comm.HandleApostrophy(txtNote.Text)
        If String.IsNullOrEmpty(cboPriority.Text) Then
            strPublicNotePriority = "LOW"
        Else
            strPublicNotePriority = cboPriority.Text
        End If
        Me.Close()
    End Sub

    Private Sub frmNoteEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtNote.Text = strEditNote
    End Sub

End Class