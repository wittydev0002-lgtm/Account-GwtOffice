Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMedicalAidSchemes

    Private Sub btnNewScheme_Click(sender As Object, e As EventArgs) Handles btnNewScheme.Click
        boolEditStatus = False
        Dim frm As New frmMedicalSchemeSetup
        frm.ShowDialog()
        LoadSchemes()
    End Sub


    Private Sub LoadSchemes()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT SchemeCode AS [Scheme Code], Name AS [Scheme Name], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), RegistrationDate, 106), ' ', '-')) as [Reg. Date], SchemeType as [Type], " _
            & "UPPER(ISNULL(PostalAddress1, '')) +' '+ UPPER(ISNULL(PostalAddress2, '')) +' '+ UPPER(ISNULL (PostalAddress3, '')) " _
            & "+' '+ UPPER(ISNULL (PostalAddress4, '')) AS [Address], Telephone AS [Phone] FROM OchmasSystemMedicalAids ORDER BY Name"

        dGridSchemes.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridSchemes.DataSource = dTable

        Me.dGridSchemes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGridSchemes.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGridSchemes.Columns.Count - 1
            dGridSchemes.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Medical Aid Schemes Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEditSchem_Click(sender As Object, e As EventArgs) Handles btnEditSchem.Click
        OpenDataForEdit()
    End Sub

    Private Sub OpenDataForEdit()
        If dGridSchemes.Rows.Count <= 0 Then Exit Sub
        If Not Object.Equals(dGridSchemes.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridSchemes.CurrentRow.Cells(0).Value.ToString) Then
                strSelectedMedicalScheme = dGridSchemes.CurrentRow.Cells(0).Value.ToString
                boolEditStatus = True
                Dim frm As New frmMedicalSchemeSetup
                frm.ShowDialog()
                LoadSchemes()
            End If
        End If
    End Sub

    Private Sub dGridSchemes_DoubleClick(sender As Object, e As EventArgs) Handles dGridSchemes.DoubleClick
        OpenDataForEdit()
    End Sub

    Private Sub txtSearchString_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            SearchForItem(txtSearchString.Text)
        End If
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0

        Dim strFind As String = strCurrentKey
        strActiveSearch = strFind

        Cursor = Cursors.WaitCursor

        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        'Scheme Name
        'Scheme Code

        Select Case UCase(cboSearchBy.Text)
            Case Is = UCase("Scheme Name")
                strSql = "SELECT SchemeCode AS [Scheme Code], Name AS [Scheme Name], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), RegistrationDate, 106), ' ', '-')) as [Reg. Date], SchemeType as [Type], " _
                    & "UPPER(ISNULL(PostalAddress1, '')) +' '+ UPPER(ISNULL(PostalAddress2, '')) +' '+ UPPER(ISNULL (PostalAddress3, '')) " _
                    & "+' '+ UPPER(ISNULL (PostalAddress4, '')) AS [Address], Telephone AS [Phone] FROM OchmasSystemMedicalAids " _
                    & "WHERE Name LIKE '%" & strFind & "%' ORDER BY Name"

            Case Is = UCase("Scheme Code")
                strSql = "SELECT SchemeCode AS [Scheme Code], Name AS [Scheme Name], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), RegistrationDate, 106), ' ', '-')) as [Reg. Date], SchemeType as [Type], " _
                    & "UPPER(ISNULL(PostalAddress1, '')) +' '+ UPPER(ISNULL(PostalAddress2, '')) +' '+ UPPER(ISNULL (PostalAddress3, '')) " _
                    & "+' '+ UPPER(ISNULL (PostalAddress4, '')) AS [Address], Telephone AS [Phone] FROM OchmasSystemMedicalAids " _
                    & "WHERE SchemeCode LIKE '%" & strFind & "%' ORDER BY SchemeCode"
            Case Else
                strSql = "SELECT SchemeCode AS [Scheme Code], Name AS [Scheme Name], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), RegistrationDate, 106), ' ', '-')) as [Reg. Date], SchemeType as [Type], " _
                    & "UPPER(ISNULL(PostalAddress1, '')) +' '+ UPPER(ISNULL(PostalAddress2, '')) +' '+ UPPER(ISNULL (PostalAddress3, '')) " _
                    & "+' '+ UPPER(ISNULL (PostalAddress4, '')) AS [Address], Telephone AS [Phone] FROM OchmasSystemMedicalAids " _
                    & "WHERE Name LIKE '%" & strFind & "%' ORDER BY Name"
        End Select

        dGridSchemes.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridSchemes.DataSource = dTable

        Me.dGridSchemes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGridSchemes.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGridSchemes.Columns.Count - 1
            dGridSchemes.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On medical aid schemes search"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefreshScheme_Click(sender As Object, e As EventArgs) Handles btnRefreshScheme.Click
        LoadSchemes()
    End Sub

    Private Sub btnDeleteScheme_Click(sender As Object, e As EventArgs) Handles btnDeleteScheme.Click
        On Error GoTo RaiseErr
        If dGridSchemes.Rows.Count <= 0 Then Exit Sub

        If MessageBox.Show("Are you sure you want to delete the selected scheme?", "Comfirm Scheme Delete",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Not Object.Equals(dGridSchemes.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridSchemes.CurrentRow.Cells(0).Value.ToString) Then
                    strSelectedMedicalScheme = dGridSchemes.CurrentRow.Cells(0).Value.ToString
                    Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM OchmasSystemMedicalAids " _
                    & "WHERE SchemeCode = '" & strSelectedMedicalScheme & "'", cnn)
                    objCommand.ExecuteNonQuery()

                    MessageBox.Show("Scheme has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadSchemes()
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On medical aid schemes delete"
        ShowErrorMessage()
    End Sub

    Private Sub frmMedicalAidSchemes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadSchemes()
    End Sub

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        On Error GoTo RaiseErr

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On medical aid and medical services providers"
        ShowErrorMessage()
    End Sub

End Class