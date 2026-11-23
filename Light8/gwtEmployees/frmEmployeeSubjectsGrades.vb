Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmEmployeeSubjectsGrades

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtGrade.Text) Then
            MessageBox.Show("Please enter a value for the subject grade", "Invalid Subject Grade", _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGrade.Focus()
            Exit Sub
        Else
            strSubjectName = txtSubject.Text
            strSubjectGrade = txtGrade.Text
            Me.Close()
        End If
    End Sub

    Private Sub frmEmployeeSubjectsGrades_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtSubject.Text = strSubjectName
        txtGrade.Text = strSubjectGrade
    End Sub

End Class
