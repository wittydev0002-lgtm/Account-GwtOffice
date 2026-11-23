Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoyalityCategories

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        boolAbort = False
        Dim strDescription As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM LoyalityCategories", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strDescription = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LoyalityCategories (Category) VALUES ('" & strDescription & "')", cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next
        MessageBox.Show("Loyal customer categories set successfully", "Loyality Categories", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On loyal customers categories"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Category FROM LoyalityCategories ORDER BY Category", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim i As Integer = 0
        dGrid.Rows.Add(100)
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows(i).Cells(0).Value = objReader(0).ToString
            End If
            i = i + 1
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On loyal customers categories load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmLoyalityCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub frmLoyalityCategories_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 390 : Me.Height = 400
    End Sub

End Class