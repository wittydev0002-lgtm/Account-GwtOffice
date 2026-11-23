Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmAssetListing

    Private Sub btnNewAsset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewAsset.Click
        boolEditStatus = False
        Dim f As New frmAssetRegistry
        f.ShowDialog()
        LoadData("AssetName")
    End Sub

    Private Sub btnEditAsset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditAsset.Click
        boolEditStatus = True
        boolAbort = False
        GetSelected()
        If boolAbort = True Then Exit Sub
        Dim f As New frmAssetRegistry
        f.ShowDialog()
        LoadData("AssetName")
    End Sub

    Private Sub GetSelected()
        If dGridAssets.Rows.Count = 0 Then
            boolAbort = True
            Exit Sub
        End If
        strSelectedAccount = dGridAssets.CurrentRow.Cells(0).Value.ToString
    End Sub

    Private Sub LoadData(ByVal strOrderBy As String)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AssetCode, AssetName, Manufacturer, Model, Owner, Location, Category " _
            & "FROM Assets ORDER BY " & strOrderBy
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridAssets.Rows.Clear()
        While objReader.Read
            dGridAssets.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridAssets.Rows(dGridAssets.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridAssets.Rows(dGridAssets.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGridAssets.Rows(dGridAssets.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dGridAssets.Rows(dGridAssets.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then dGridAssets.Rows(dGridAssets.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then dGridAssets.Rows(dGridAssets.Rows.Count - 1).Cells(5).Value = objReader(5).ToString
            If Not IsDBNull(objReader(6).ToString) Then dGridAssets.Rows(dGridAssets.Rows.Count - 1).Cells(6).Value = objReader(6).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Assets Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmAssetsListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData("AssetName")
    End Sub

    Private Sub btnDeleteAsset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAsset.Click
        GetSelected()
        DeleteAsset()
    End Sub

    Private Sub DeleteAsset()
        If MessageBox.Show("Are you sure you want to delete the selected asset?", _
            "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM Assets WHERE AssetCode = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM DepreciationValues WHERE AssetCode = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Asset deleted from the system successfully", "Asset Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData("AssetName")
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Asset Deletion"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGridAssets_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridAssets.DoubleClick
        boolEditStatus = True
        boolAbort = False
        GetSelected()
        If boolAbort = True Then Exit Sub
        Dim f As New frmAssetRegistry
        f.ShowDialog()
        LoadData("AssetName")
    End Sub

    Private Sub btnDisposeAsset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisposeAsset.Click
        Dim f As New frmAssetDisposal
        f.ShowDialog()
        LoadData("AssetName")
    End Sub

    Private Sub btnRefreshAsset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshAsset.Click
        LoadData("AssetName")
    End Sub

    Private Sub cboFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFilter.SelectedIndexChanged
        Select Case UCase(cboFilter.Text)
            Case Is = UCase("CODE")
                LoadData("AssetCode")
            Case Is = UCase("Name")
                LoadData("AssetName")
            Case Is = UCase("MANUFACTURER")
                LoadData("Manufacturer")
            Case Is = UCase("Location")
                LoadData("Location")
            Case Is = UCase("CATEGORY")
                LoadData("Category")
            Case Is = UCase("Owner")
                LoadData("Owner")
            Case Else
                LoadData("AssetName")
        End Select
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        Dim intSearchColumn As Integer = 0
        Select Case UCase(cboFilter.Text)
            Case Is = UCase("CODE")
                intSearchColumn = 0
            Case Is = UCase("Name")
                intSearchColumn = 1
            Case Is = UCase("MANUFACTURER")
                intSearchColumn = 2
            Case Is = UCase("Location")
                intSearchColumn = 5
            Case Is = UCase("CATEGORY")
                intSearchColumn = 6
            Case Is = UCase("Owner")
                intSearchColumn = 4
            Case Else
                intSearchColumn = 1
        End Select
        If (Char.IsLetter(e.KeyChar)) Then
            Dim strSearchString As String = txtSearchString.Text & e.KeyChar
            For i As Integer = 0 To dGridAssets.Rows.Count - 1
                If dGridAssets.Rows(i).Cells(intSearchColumn).Value.ToString().StartsWith(strSearchString, True, System.Globalization.CultureInfo.InvariantCulture) Then
                    dGridAssets.CurrentCell = dGridAssets(0, i)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub btnCategories_Click(sender As System.Object, e As System.EventArgs) Handles btnCategories.Click
        Dim frm As New frmAssetCategoriesListing
        frm.ShowDialog()
    End Sub

End Class