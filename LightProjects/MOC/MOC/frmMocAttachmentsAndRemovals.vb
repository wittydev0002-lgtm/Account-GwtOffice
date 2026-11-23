Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMocAttachmentsAndRemovals

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmMocRemovals
        frm.ShowDialog()
    End Sub

    Private Sub frmMocAttachmentsAndRemovals_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadDetails()
    End Sub

    Private Sub LoadDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Cursor = Cursors.WaitCursor
        'Select Case UCase(Type)
        '    Case Is = "ATTACHMENTS"
        'strSql = "SELECT MocAttachmentMains.CaseNo AS [Case #], " _
        '    & "UPPER(REPLACE(CONVERT(CHAR(11), MocAttachmentMains.TransactionDate, 106), ' ', '-')) AS [Action Date], " _
        '    & "MocCases.Defendant AS [Defendant], MocAttachmentMains.AssistantSheriff AS [Assitant MOC], " _
        '    & "UPPER(REPLACE(CONVERT(CHAR(11), MocAttachmentMains.RemovalDueDate, 106), ' ', '-')) " _
        '    & "AS [Removal Due Date], Sequence FROM MocAttachmentMains " _
        '    & "LEFT OUTER JOIN MocCases ON MocAttachmentMains.CaseNo = MocCases.CaseNo " _
        '    & "WHERE Stagging = 'PENDING REMOVAL' ORDER BY MocAttachmentMains.CaseNo"
        '    Case Is = "REMOVALS"
        strSql = "SELECT MocAttachmentMains.CaseNo AS [Case #], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), MocAttachmentMains.TransactionDate, 106), ' ', '-')) AS [Action Date], " _
            & "MocCases.Defendant AS [Defendant], MocAttachmentMains.AssistantSheriff as [Assistant MOC], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), MocAttachmentMains.RemovalDueDate, 106), ' ', '-')) " _
            & "AS [Removal Date], Stagging, Sequence FROM MocAttachmentMains " _
            & "LEFT OUTER JOIN MocCases ON MocAttachmentMains.CaseNo = MocCases.CaseNo " _
            & "ORDER BY MocAttachmentMains.CaseNo"
        'End Select
        dGrid.Columns.Clear()
        dGrid.ReadOnly = False

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        'Add check box for auction
        With dGrid
            Dim checkCol As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
            checkCol.HeaderText = "Auction"
            checkCol.Width = 25
            checkCol.ReadOnly = False
            .Columns.Add(checkCol)
            '.Columns(.Columns.Count - 1).ReadOnly = False
        End With

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next
        dGrid.Columns(dGrid.Columns.Count - 2).Visible = False
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on attachments details listing"
        ShowErrorMessage()
    End Sub

    'Private Sub cboLoadTypes_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
    '    LoadDetails(cboLoadTypes.Text)
    'End Sub

    Private Sub btnDueForRemoval_Click(sender As System.Object, e As System.EventArgs) Handles btnDueForRemoval.Click
        boolAbort = False
        Dim frm As New frmDateSpecification
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        Dim strSql As String = "SELECT MocAttachmentMains.CaseNo AS [Case #], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), MocAttachmentMains.TransactionDate, 106), ' ', '-')) AS [Action Date], " _
            & "MocCases.Defendant AS [Defendant], MocAttachmentMains.AssistantSheriff AS [Assitant MOC], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), MocAttachmentMains.RemovalDueDate, 106), ' ', '-')) " _
            & "AS [Removal Due Date], Sequence FROM MocAttachmentMains " _
            & "LEFT OUTER JOIN MocCases ON MocAttachmentMains.CaseNo = MocCases.CaseNo " _
            & "WHERE Stagging = 'PENDING REMOVAL' AND RemovalDueDate = '" & dtSetDate & "' " _
            & "ORDER BY MocAttachmentMains.CaseNo"

        dGrid.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next
        dGrid.Columns(dGrid.Columns.Count - 1).Visible = False
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on attachments due for removal listing"
        ShowErrorMessage()
    End Sub

    Private Sub GetSelected()
        strSelectedAccount = Nothing
        intSelectedBatchNumber = 0
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                strSelectedAccount = dGrid.CurrentRow.Cells(0).Value.ToString
            End If
        End If
        If Not Object.Equals(dGrid.CurrentRow.Cells(dGrid.Columns.Count - 2).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(dGrid.Columns.Count - 2).Value.ToString) Then
                If IsNumeric(dGrid.CurrentRow.Cells(dGrid.Columns.Count - 2).Value.ToString) Then
                    intSelectedBatchNumber = dGrid.CurrentRow.Cells(dGrid.Columns.Count - 2).Value.ToString
                End If
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If dGrid.RowCount <= 0 Then Exit Sub
        GetSelected()
        boolEditStatus = True
        Dim frm As New frmMocRemovals
        frm.ShowDialog()
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.RowCount <= 0 Then Exit Sub
        GetSelected()
        boolEditStatus = True
        Dim frm As New frmMocRemovals
        frm.ShowDialog()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If dGrid.RowCount <= 0 Then Exit Sub
        If MessageBox.Show("Are you sure you want to delete this record", "Confirm Deletion", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            GetSelected()
            Dim objCommand As Data.OleDb.OleDbCommand
            Dim strSql As String = "DELETE FROM MocAttachmentMains WHERE CaseNo = '" & strSelectedAccount & "' " _
                & "AND Sequence = " & intSelectedBatchNumber & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            LoadDetails()
            MessageBox.Show("Record deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error encounted while trying to remove an attachmnet"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadDetails()
    End Sub

    Private Sub btnUpdateForAuction_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdateForAuction.Click
        On Error GoTo RaiseErr
        If dGrid.RowCount <= 0 Then Exit Sub
        For i As Integer = 0 To dGrid.RowCount - 1
            If dGrid.Rows(i).Cells(dGrid.ColumnCount - 1).Value = True Then

                strSelectedAccount = Nothing
                intSelectedBatchNumber = 0
                If Not Object.Equals(dGrid.Rows(i).Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(0).Value.ToString) Then
                        strSelectedAccount = dGrid.Rows(i).Cells(0).Value.ToString
                    End If
                End If
                If Not Object.Equals(dGrid.Rows(i).Cells(dGrid.Columns.Count - 2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(dGrid.Columns.Count - 2).Value.ToString) Then
                        If IsNumeric(dGrid.Rows(i).Cells(dGrid.Columns.Count - 2).Value.ToString) Then
                            intSelectedBatchNumber = dGrid.Rows(i).Cells(dGrid.Columns.Count - 2).Value.ToString
                        End If
                    End If
                End If

                Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE MocAttachmentMains SET Stagging = 'AUCTION' " _
                    & "WHERE CaseNo = '" & strSelectedAccount & "' AND Sequence = " & intSelectedBatchNumber & "", cnn)
                objCommand.ExecuteNonQuery()

                objCommand = New Data.OleDb.OleDbCommand("UPDATE MocAttachmentDetails SET AuctionStatus = 'AUCTION' " _
                    & "WHERE CaseNo = '" & strSelectedAccount & "' AND Sequence = " & intSelectedBatchNumber & "", cnn)
                objCommand.ExecuteNonQuery()

            End If
        Next
        LoadDetails()
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Auction Update Error"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dGrid.MouseUp
        On Error GoTo RaiseErr
        If dGrid.CurrentCell.ColumnIndex = dGrid.ColumnCount - 1 Then
            Dim cell As DataGridViewCheckBoxCell = Me.dGrid.CurrentCell
        Else
            Exit Sub
        End If
        Me.dGrid.EndEdit()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Debtors Analysis Mass Change"
        ShowErrorMessage()
    End Sub

End Class
