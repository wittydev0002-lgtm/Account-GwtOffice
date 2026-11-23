Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMedicalAidsListing

    Private Sub frmMedicalAidsListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMedicalSchemes()
    End Sub

    Private Sub LoadMedicalSchemes()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT RegistrationNumber, Name FROM OchmasSystemMedicalAids ORDER BY Name"
        Dim dbCommand As New Data.OleDb.OleDbCommand(strsql, cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = dbCommand.ExecuteReader
        Dim i As Integer = 0
        dgrid.Rows.Clear()
        While dbReader.Read
            dGrid.Rows.Add(dbReader(0), dbReader(1))
        End While
        dbReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Medical Aid Listing Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        boolEditStatus = False
        Dim f As New frmMedicalAid
        f.ShowDialog()
        LoadMedicalSchemes()
    End Sub

    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        If dgrid.Rows.Count > 0 Then
            strSelectedMedicalScheme = dgrid.CurrentRow.Cells(0).Value
            boolEditStatus = True
            Dim f As New frmMedicalAid
            f.ShowDialog()
            LoadMedicalSchemes()
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If dGrid.Rows.Count > 0 Then
            'Make sure that the scheme doe not owe us an monies before deleting

            If MsgBox("Are you sure you want to delete " & dGrid.CurrentRow.Cells(1).Value & " from the system?", MsgBoxStyle.YesNo, "Medical Aid Delete Confirmation") = MsgBoxResult.Yes Then
                Dim dbCommand As New Data.OleDb.OleDbCommand("DELETE FROM OchmasSystemMedicalAids WHERE RegistrationNumber = '" & dGrid.CurrentRow.Cells(0).Value & "'", cnn)
                dbCommand.ExecuteNonQuery()
                Me.LoadMedicalSchemes()
                MsgBox("Medical Aid Scheme has been deleted from the system", MsgBoxStyle.Information, "Medical Aid Scheme Deletion")
            End If
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Medical aid details setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If dGrid.Rows.Count > 0 Then
            strSelectedMedicalScheme = dGrid.CurrentRow.Cells(0).Value
            boolEditStatus = True
            Dim f As New frmMedicalAid
            f.ShowDialog()
            LoadMedicalSchemes()
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadMedicalSchemes()
    End Sub

End Class
