Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSearchSponsor
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        GetSelected
    End Sub

    Private Sub GetSelected()
        On Error Resume Next
        If dGrid.Rows.Count <= 0 Then Exit Sub
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                strSelectedDescription = dGrid.CurrentRow.Cells(0).Value.ToString
                boolAbort = False
                Me.Close()
            End If
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT(Sponsor) FROM SC_Sponsors ORDER BY Sponsor", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        dGrid.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Sponsors Selection Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmSearchSponsor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As EventArgs) Handles dGrid.DoubleClick
        GetSelected()
    End Sub

End Class