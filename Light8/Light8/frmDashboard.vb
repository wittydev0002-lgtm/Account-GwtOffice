Public Class frmDashboard
    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmDashboard_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim intTop As Integer = (Me.Height - pnlMain.Height) / 2
        Dim intLeft As Integer = (Me.Width - pnlMain.Width) / 2
        With pnlMain
            .Top = intTop + 20
            .Left = intLeft
            .Visible = True
        End With
    End Sub


End Class