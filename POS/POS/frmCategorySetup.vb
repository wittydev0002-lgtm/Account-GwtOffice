Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCategorySetup

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    'boolEditStatus = False
    '    'Dim f As New frmSubCategorySetup
    '    'f.ShowDialog()
    '    'If Not String.IsNullOrEmpty(strSubCategoryName) Then
    '    '    dGrid.Rows.Add(strSubCategoryName)
    '    'End If
    'End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        boolEditStatus = True
        strSubCategoryName = dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value.ToString
        Dim f As New frmSubCategorySetup
        f.ShowDialog()
        If Not String.IsNullOrEmpty(strSubCategoryName) Then
            dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value = strSubCategoryName
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If dGrid.Rows.Count > 0 Then
            dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IntPublicCategoriesSetup <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtCategory.Text) Then
            MessageBox.Show("Please enter the category name", "Invalid Category Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCategory.Focus()
            Exit Sub
        End If
        'Save the data to the 
        Dim objCommand As Data.OleDb.OleDbCommand
        'If boolEditStatus = True Then
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Categories WHERE Category = '" & txtCategory.Text & "'", cnn)
        objCommand.ExecuteNonQuery()
        'Delete the sub categories as well
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SubCategories WHERE " _
            & "Category = '" & txtCategory.Text & "'", cnn)
        objCommand.ExecuteNonQuery()
        'End If

        If boolEditStatus = False Then
            Dim strSql As String = "INSERT INTO Categories (Category) VALUES " _
                    & "('" & txtCategory.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            'Add the sub categories under
            For i As Integer = 0 To dGrid.Rows.Count - 1
                Dim strSubCategory As String = Nothing
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    strSubCategory = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                    strSql = "INSERT INTO SubCategories (SubCategory, Category) VALUES " _
                        & "('" & strSubCategory & "', '" & txtCategory.Text & "')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            Next
        Else
            Dim strSql As String = "INSERT INTO Categories (Category) VALUES " _
                    & "('" & txtNewCategory.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            'Add the sub categories under
            For i As Integer = 0 To dGrid.Rows.Count - 1
                Dim strSubCategory As String = Nothing
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    strSubCategory = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                    strSql = "INSERT INTO SubCategories (SubCategory, Category) VALUES " _
                        & "('" & strSubCategory & "', '" & txtNewCategory.Text & "')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            Next
        End If
        MessageBox.Show("Categories have been saved successfully", "Categories Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Category Setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmCategorySetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dGrid.Rows.Add(100)
        If boolEditStatus = True Then
            LoadFormData()
            txtCategory.Enabled = False
        End If
    End Sub

    Private Sub LoadFormData()
        On Error GoTo RaiseErr
        txtCategory.Text = strSelectedCategory
        txtNewCategory.Text = strSelectedCategory
        txtNewCategory.Enabled = True
        Dim objCmmand As New Data.OleDb.OleDbCommand("SELECT SubCategory FROM SubCategories WHERE Category = '" & txtCategory.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmmand.ExecuteReader
        Dim i As Integer = 0
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                'dGrid.Rows.Add(1)
                dGrid.Rows(i).Cells(0).Value = objReader(0).ToString
                i = i + 1
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Category Setup"
        ShowErrorMessage()
    End Sub

End Class