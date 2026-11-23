Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMocCasesListings

    Dim boolFormLoading As Boolean
    Dim intStartIndex As Integer
    Dim intColumnIndex As Integer

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmMocCases
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub LoadClients()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT GivenNames +'|'+ PlaintifID AS " _
            & "[Details] FROM Plaintifs ORDER BY GivenNames", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrData As New ArrayList

        If UCase(strUserLevel) = UCase("Administrator") Then
            arrData.Add("--ALL--|0")
            arrData.Add("SELF ACTOR|0-0")
        End If

        While objReader.Read
            If UCase(strUserLevel) <> UCase("Administrator") Then
                If Not IsDBNull(objReader(0).ToString) Then
                    Dim strSplitName() As String = Split(objReader(0).ToString, "|")
                    For z As Integer = 0 To arrPublicPotfolioClientName.Count - 1
                        If UCase(strSplitName(0)) = UCase(arrPublicPotfolioClientName.Item(z)) Then
                            arrData.Add(objReader(0).ToString)
                        End If
                    Next
                End If
            Else
                If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboLoadTypes.Width - 80

        'Add the items to the drop down box
        With cboLoadTypes
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth1 & ";80"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = arrData.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboLoadTypes.Items.Clear()
        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboLoadTypes
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Client Names Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dGrid.CellMouseDown
        If e.Button = MouseButtons.Right Then
            ' Add this
            dGrid.CurrentCell = dGrid.Rows(e.RowIndex).Cells(e.ColumnIndex)
            ' Can leave these here - doesn't hurt
            dGrid.Rows(e.RowIndex).Selected = True
            dGrid.Focus()
        End If

    End Sub

    Private Sub cboClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLoadTypes.SelectedIndexChanged
        If Not cboLoadTypes.SelectedItem Is Nothing Then
            lblClientId.Text = cboLoadTypes.SelectedItem.Col2
            LoadDefendantsListing(lblClientId.Text)
        Else
            lblClientId.Text = "0"
        End If
    End Sub

    Private Sub LoadDefendantsListing(ByVal PlaintifId As String)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Cursor = Cursors.WaitCursor
        If lblClientId.Text = "0" Then
            strSql = "SELECT MocCases.CaseNo as [Case #], " _
                & "UPPER(REPLACE(CONVERT(CHAR(11), MocCases.DateIn, 106), ' ', '-')) as [Date In], " _
                & "MocCases.Defendant AS [Defendant], MocCases.DebtorId AS [Debtor ID], " _
                & "Plaintifs.GivenNames AS [Debtor Name] " _
                & "FROM MocCases LEFT OUTER JOIN Plaintifs " _
                & "ON MocCases.DebtorId = Plaintifs.PlaintifId " _
                & "GROUP BY MocCases.CaseNo, MocCases.DateIn, MocCases.Defendant, " _
                & "MocCases.DebtorId, Plaintifs.GivenNames"
        Else
            If lblClientId.Text = "0-0" Then
                strSql = "SELECT MocCases.CaseNo as [Case #], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), MocCases.DateIn, 106), ' ', '-')) as [Date In], " _
                    & "MocCases.Defendant AS [Defendant], MocCases.DebtorId AS [Debtor ID], " _
                    & "Plaintifs.GivenNames AS [Debtor Name] " _
                    & "FROM MocCases LEFT OUTER JOIN Plaintifs " _
                    & "ON MocCases.DebtorId = Plaintifs.PlaintifId WHERE MocCases.DebtorId = '0-0' " _
                    & "GROUP BY MocCases.CaseNo, MocCases.DateIn, MocCases.Defendant, " _
                    & "MocCases.DebtorId, Plaintifs.GivenNames"
            Else
                strSql = "SELECT MocCases.CaseNo as [Case #], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), MocCases.DateIn, 106), ' ', '-')) as [Date In], " _
                    & "MocCases.Defendant AS [Defendant], MocCases.DebtorId AS [Debtor ID], " _
                    & "Plaintifs.GivenNames AS [Debtor Name] " _
                    & "FROM MocCases LEFT OUTER JOIN Plaintifs " _
                    & "ON MocCases.DebtorId = Plaintifs.PlaintifId WHERE MocCases.DebtorId = '" & lblClientId.Text & "' " _
                    & "GROUP BY MocCases.CaseNo, MocCases.DateIn, MocCases.Defendant, " _
                    & "MocCases.DebtorId, Plaintifs.GivenNames"
            End If
        End If

        dGrid.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        'AlternateColors(dGrid)
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next
        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On case details load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Data Load Error"
        ShowErrorMessage()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        boolEditStatus = True
        If dGrid.RowCount <= 0 Then Exit Sub
        GetSelected()
        Dim frm As New frmMocCases
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadDefendantsListing(lblClientId.Text)
    End Sub

    Private Sub GetSelected()
        If dGrid.Rows.Count > 0 Then
            strSelectedAccountName = Nothing
            strSelectedAccount = dGrid.CurrentRow.Cells(0).Value.ToString
        End If
    End Sub

    Private Sub frmMocCasesListings_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        boolFormLoading = True
        LoadClients()
        boolFormLoading = False
    End Sub

    Private Sub btnFindNext_Click(sender As System.Object, e As System.EventArgs) Handles btnFindNext.Click
        While intStartIndex <= dGrid.Rows.Count - 1
            If UCase(Mid(dGrid.Rows(intStartIndex).Cells(intColumnIndex).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                dGrid.FirstDisplayedCell = dGrid.Rows(intStartIndex).Cells(intColumnIndex)
                dGrid.FirstDisplayedCell.Selected = True
                dGrid.CurrentCell = dGrid.Rows(intStartIndex).Cells(intColumnIndex)
                intStartIndex = intStartIndex + 1
                Exit Sub
            End If
            intStartIndex = intStartIndex + 1
        End While
        MessageBox.Show("Search has reached end of records", "Data Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnFind_Click(sender As System.Object, e As System.EventArgs) Handles btnFind.Click
        StartFind()
    End Sub

    Private Sub StartFind()
        intStartIndex = 0
        While intStartIndex <= dGrid.Rows.Count - 1
            If UCase(Mid(dGrid.Rows(intStartIndex).Cells(intColumnIndex).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                dGrid.FirstDisplayedCell = dGrid.Rows(intStartIndex).Cells(intColumnIndex)
                dGrid.FirstDisplayedCell.Selected = True
                dGrid.CurrentCell = dGrid.Rows(intStartIndex).Cells(intColumnIndex)
                intStartIndex = intStartIndex + 1
                Exit Sub
            End If
            intStartIndex = intStartIndex + 1
        End While
        MessageBox.Show("Search has reached end of records", "Data Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub txtSearchString_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchString.TextChanged
        'Handles the search function. as the use types the string, the grid positions itself to the nearest match
        Dim i As Integer = 0
        With dGrid
            For i = 0 To dGrid.Rows.Count - 1
                Select Case UCase(cboSearchBy.Text)
                    Case Is = UCase("Case Number")
                        If UCase(Mid(.Rows(i).Cells(0).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(0)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                    Case Is = UCase("Plaintif Name")
                        If UCase(Mid(.Rows(i).Cells(3).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(3)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                    Case Is = UCase("Defendant Name")
                        If UCase(Mid(.Rows(i).Cells(2).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(2)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                    Case Else
                        'Use the last name
                        If UCase(Mid(.Rows(i).Cells(0).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(0)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                End Select
            Next
        End With
    End Sub

    Private Sub cboSearchBy_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSearchBy.SelectedIndexChanged
        If boolFormLoading = True Then Exit Sub
        Dim strValue As String = cboSearchBy.Text

        If UCase(strValue) = UCase("Case Number") Then intColumnIndex = 0
        If UCase(strValue) = UCase("Plaintif Name") Then intColumnIndex = 3
        If UCase(strValue) = UCase("Defendant name") Then intColumnIndex = 2

        Cursor = Cursors.WaitCursor
        dGrid.Sort(dGrid.Columns(intColumnIndex), System.ComponentModel.ListSortDirection.Ascending)
        Cursor = Cursors.Default
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        boolEditStatus = True
        If dGrid.RowCount <= 0 Then Exit Sub
        GetSelected()
        Dim frm As New frmMocCases
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnMaintainAction_Click(sender As System.Object, e As System.EventArgs) Handles btnMaintainAction.Click
        Dim frm As New frmMocReturns
        frm.ShowDialog()
    End Sub

    Private Sub mnuPayments_Click(sender As System.Object, e As System.EventArgs) Handles mnuPayments.Click
        GetSelected()
        Dim frm As New frmMocPayments
        frm.ShowDialog()
    End Sub

    Private Sub btnChangeCaseNumber_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeCaseNumber.Click
        boolEditStatus = True
        If dGrid.RowCount <= 0 Then Exit Sub
        GetSelected()
        Dim frm As New frmLegalChangeCaseNumber
        frm.ShowDialog()
        LoadDefendantsListing(lblClientId.Text)
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        boolEditStatus = True
        If dGrid.RowCount <= 0 Then Exit Sub
        If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            GetSelected()
            Dim objCommand As Data.OleDb.OleDbCommand

            'Delete the address from the table first 
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM MocCaseAddresses WHERE CaseNo = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()

            'MocAttachmentMains
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM MocAttachmentMains WHERE CaseNo = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()

            'MocAttachmentDetails
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM MocAttachmentDetails WHERE CaseNo = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()

            'MocPlaintifTransactions
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM MocPlaintifTransactions WHERE CaseNo = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()

            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM MocCases WHERE CaseNo = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()

            LoadDefendantsListing(lblClientId.Text)

            MessageBox.Show("Case deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On case delete"
        ShowErrorMessage()
    End Sub

End Class
