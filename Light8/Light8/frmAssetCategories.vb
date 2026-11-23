Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmAssetCategories

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtCategory.Text) Then
            MessageBox.Show("Please enter the category name", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCategory.Focus()
            txtCategory.SelectAll()
            Exit Sub
        End If
        Dim objDeletePrior As New Data.OleDb.OleDbCommand("DELETE FROM AssetCategories WHERE Category = '" & txtCategory.Text & "'", cnn)
        objDeletePrior.ExecuteNonQuery()
        Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO AssetCategories (Category) VALUES ('" & txtCategory.Text & "')", cnn)
        objCommand.ExecuteNonQuery()
        If boolEditStatus = False Then
            If MessageBox.Show("Asset category set successfully. Do you want to add more?", "Data Save Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                txtCategory.Clear()
                txtCategory.Focus()
                txtCategory.SelectAll()
            Else
                Me.Close()
            End If
        Else
            MessageBox.Show("Category set successfully", "Data Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Asset Categories Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmAssetCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If boolEditStatus = True Then txtCategory.Text = strSelectedAccount
    End Sub

    Private Sub frmAssetCategories_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 495 : Me.Height = 150
    End Sub

End Class
