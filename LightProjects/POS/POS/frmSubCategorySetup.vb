Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSubCategorySetup

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmSubCategorySetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If boolEditStatus = True Then txtSubCategory.Text = strSubCategoryName
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Not String.IsNullOrEmpty(txtSubCategory.Text) Then
            strSubCategoryName = txtSubCategory.Text
            Me.Close()
        Else
            MessageBox.Show("Please enter the sub category name", "Invalid Category Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSubCategory.Focus()
            Exit Sub
        End If
    End Sub

End Class