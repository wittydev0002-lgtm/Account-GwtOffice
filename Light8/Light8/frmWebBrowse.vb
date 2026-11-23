Imports System.Windows.Forms
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmWebBrowse

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        MyBrowser.Navigate(txtUrl.Text)
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        MyBrowser.GoBack()
    End Sub

    Private Sub btnForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForward.Click
        MyBrowser.GoForward()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        MyBrowser.Refresh()
    End Sub

    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        MyBrowser.GoHome()
    End Sub

    Private Sub txtUrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUrl.KeyDown
        If e.KeyCode = Keys.Control And e.KeyCode = Keys.Enter Then
            txtUrl.Text = "www." & txtUrl.Text & ".com"
        End If
    End Sub

    Private Sub txtUrl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUrl.KeyPress
        If Asc(e.KeyChar) = 13 Then MyBrowser.Navigate(txtUrl.Text)
    End Sub

    Private Sub frmWebBrowse_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Not String.IsNullOrEmpty(strSelectedFileName) Then
            MyBrowser.Navigate(strSelectedFileName)
        End If
    End Sub

End Class
