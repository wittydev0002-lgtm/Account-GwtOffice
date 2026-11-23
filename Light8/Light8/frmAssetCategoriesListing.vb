Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmAssetCategoriesListing

    Private Sub btnAddCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCategory.Click
        boolAbort = False
        Dim f As New frmAssetCategories
        f.ShowDialog()
        LoadCategoryData()
    End Sub

    Private Sub GetSelectedCategory()
        If dGridCategories.Rows.Count = 0 Then Exit Sub
        strSelectedAccount = dGridCategories.CurrentRow.Cells(0).Value.ToString
        boolEditStatus = True
        Dim f As New frmAssetCategories
        f.ShowDialog()
        LoadCategoryData()
    End Sub

    Private Sub btnEditCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditCategory.Click
        GetSelectedCategory()
    End Sub

    Private Sub dGridCategories_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridCategories.CellClick
        If dGridCategories.CurrentCell.ColumnIndex = 1 Then
            DeleteCategory()
            LoadCategoryData()
        End If
    End Sub

    Private Sub dGridCategories_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridCategories.DoubleClick
        GetSelectedCategory()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteCategory.Click
        DeleteCategory()
        LoadCategoryData()
    End Sub

    Private Sub DeleteCategory()
        If dGridCategories.Rows.Count = 0 Then Exit Sub
        strSelectedAccount = dGridCategories.CurrentRow.Cells(0).Value.ToString
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to delete " & strSelectedAccount & " category from the system?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM AssetCategories WHERE Category = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Asset category deleted successfully", _
                "Asset Category Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Asset Category Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCategoryData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Category FROM AssetCategories ORDER BY Category", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        dGridCategories.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGridCategories.Rows.Add(1)
                dGridCategories.Rows(dGridCategories.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Asset Categories Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmAssetCategoriesListing_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadCategoryData()
    End Sub

    Private Sub frmAssetCategoriesListing_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 560 : Me.Height = 420
    End Sub

End Class
