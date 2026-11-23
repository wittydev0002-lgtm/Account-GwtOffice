Imports CommonLibrary.Commons

Public Class frmCustomMsg

    Private Sub frmCustomMsg_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmCustomMsg_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 482 : Me.Height = 200
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If optContinue.Checked = True Then
            boolSkipRecord = False
        Else
            boolSkipRecord = True
        End If
        If chkRepeat.Checked = True Then
            boolRepeat = True
        Else
            boolRepeat = False
        End If
        boolAbort = False
        Me.Close()
    End Sub

End Class