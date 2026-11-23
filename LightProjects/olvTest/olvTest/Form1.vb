Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.olvSongs.SetObjects(Song.GetSongs())
    End Sub

End Class
