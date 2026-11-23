Imports ComponentFactory.Krypton.Toolkit

Public Class frmCategorySetup

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objCommand As Data.OleDb.OleDbCommand

        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(0).Value.ToString) Then
                    Dim strCategory As String = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Categories WHERE Category = '" & strCategory & "'", cnn)
                    objCommand.ExecuteNonQuery()
                    Dim strSql As String = "INSERT INTO Categories (Category) VALUES ('" & strCategory & "')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        Next

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
        LoadFormData()
    End Sub

    Private Sub LoadFormData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objCmmand As New Data.OleDb.OleDbCommand("SELECT Category FROM Categories ORDER BY Category", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmmand.ExecuteReader
        Dim i As Integer = 0
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows(i).Cells(0).Value = objReader(0).ToString
                i = i + 1
            End If
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Category Setup"
        ShowErrorMessage()
    End Sub

End Class