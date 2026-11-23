Public Class frmLaschProvinceSetup

    Dim boolLoading As Boolean

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtProvince.Text) Then
            MessageBox.Show("Please enter the province name", "Invalid Province Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtProvince.Focus()
            Exit Sub
        End If
        'Save the data to the 
        Dim objCommand As Data.OleDb.OleDbCommand
        
        'Delete the sub categories as well
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Districts WHERE " _
            & "Province = '" & txtProvince.Text & "'", cnn)
        objCommand.ExecuteNonQuery()

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Provinces WHERE Province = '" & txtProvince.Text & "'", cnn)
        objCommand.ExecuteNonQuery()

        If boolEditStatus = False Then
            Dim strSql As String = "INSERT INTO Provinces (Province) VALUES " _
                    & "('" & txtProvince.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            'Add the sub categories under
            For i As Integer = 0 To dGrid.Rows.Count - 1
                Dim strDistrict As String = Nothing
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    strDistrict = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                    strSql = "INSERT INTO Districts (District, Province) VALUES " _
                        & "('" & strDistrict & "', '" & txtProvince.Text & "')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            Next
        Else
            Dim strSql As String = "INSERT INTO Provinces (Province) VALUES " _
                    & "('" & txtNewCategory.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            'Add the sub categories under
            For i As Integer = 0 To dGrid.Rows.Count - 1
                Dim strDistrict As String = Nothing
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    strDistrict = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                    strSql = "INSERT INTO Districts (District, Province) VALUES " _
                        & "('" & strDistrict & "', '" & txtNewCategory.Text & "')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            Next
        End If
        MessageBox.Show("Provinces have been saved successfully", "Provinces Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Provinces Setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmCategorySetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boolLoading = True
        dGrid.Rows.Add(100)
        If boolEditStatus = True Then
            LoadFormData()
            txtProvince.Enabled = False
        End If
        boolLoading = False
    End Sub

    Private Sub LoadFormData()
        On Error GoTo RaiseErr
        txtProvince.Text = strSelectedCategory
        txtNewCategory.Text = strSelectedCategory
        txtNewCategory.Enabled = True
        Dim objCmmand As New Data.OleDb.OleDbCommand("SELECT District FROM Districts WHERE Province = '" & txtProvince.Text & "'", cnn)
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Provinces Setup"
        ShowErrorMessage()
    End Sub


End Class
