Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSponsorsListing
    Private Sub btnNewStudent_Click(sender As Object, e As EventArgs) Handles btnNewStudent.Click
        boolEditStatus = False
        Dim frm As New frmSponsors
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Sponsor, Address1 +', '+ Address2 +', '+ Address3 +', '+ Address4 As [Address], " _
            & "Telephone, EmailAddress FROM SC_Sponsors ORDER BY Sponsor"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(1)
            Dim strAddress As String = Nothing
            If Not String.IsNullOrEmpty(objReader(0).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not String.IsNullOrEmpty(objReader(1).ToString) Then
                Dim strBuffer() As String = Split(objReader(1).ToString, ", ")
                For n As Integer = 0 To strBuffer.Length - 1
                    strAddress = strAddress & strBuffer(n) & ", "
                Next
                If strAddress = ", , , , " Then
                    strAddress = Nothing
                Else
                    strAddress = Mid(strAddress, 1, strAddress.Length - 2)
                End If
            End If
            dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = strAddress
            If Not String.IsNullOrEmpty(objReader(2).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
            If Not String.IsNullOrEmpty(objReader(3).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On sponsors details setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmSponsorsListing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnRefreshStudents_Click(sender As Object, e As EventArgs) Handles btnRefreshStudents.Click
        LoadData()
    End Sub

    Private Sub btnDeleteStudent_Click(sender As Object, e As EventArgs) Handles btnDeleteStudent.Click
        On Error GoTo RaiseErr
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                Dim strSponsor As String = dGrid.CurrentRow.Cells(0).Value.ToString
                Dim objcommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_Sponsors WHERE Sponsor = '" & strSponsor & "'", cnn)
                objcommand.ExecuteNonQuery()
                LoadData()
                MessageBox.Show("Sponsor record has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On sponsors details setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnEditStudent_Click(sender As Object, e As EventArgs) Handles btnEditStudent.Click
        GetSelected()
        If boolAbort = True Then Exit Sub
        LoadData()
    End Sub

    Private Sub GetSelected()
        On Error Resume Next
        If dGrid.Rows.Count <= 0 Then Exit Sub
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                strSelectedDescription = dGrid.CurrentRow.Cells(0).Value.ToString
                boolEditStatus = True
                Dim frm As New frmSponsors
                frm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As EventArgs) Handles dGrid.DoubleClick
        GetSelected()
        If boolAbort = True Then Exit Sub
        LoadData()
    End Sub

End Class