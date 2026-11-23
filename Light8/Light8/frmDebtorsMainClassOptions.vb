Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDebtorsMainClassOptions
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(txtOption.Text) Then
            MessageBox.Show("Please enter the main class option parameter description",
                "Missing Key Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtOption.Select()
            Exit Sub
        End If

        ' Check that the entry has not been made earlier
        '
        Dim boolExits As Boolean = False
        With dGrid
            For p As Integer = 0 To .RowCount - 1
                If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(1).Value.ToString) Then
                        If UCase(Trim(.Rows(p).Cells(1).Value.ToString)) = UCase(Trim(txtOption.Text)) Then
                            boolExits = True
                            Exit For
                        End If
                    End If
                End If
            Next
        End With

        If boolExits = True Then
            MessageBox.Show("A similar class option parameter already exists", "Duplicate Record Entry",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtOption.Select()
            txtOption.SelectAll()
            Exit Sub
        End If

        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = "INSERT INTO SystemDebtorClassOptions ([Option], [OrdinalNo]) " _
            & "VALUES ('" & txtOption.Text & "', " & intSelectedTransactionId & ")"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        LoadData()

        Cursor = Cursors.Default

        txtOption.Clear()
        txtOption.Select()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debtor class option parameter setup"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()

        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = "SELECT [TransactionId] as [TID], [Option] FROM SystemDebtorClassOptions " _
            & "WHERE OrdinalNo = " & intSelectedTransactionId & " ORDER BY TransactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        With dGrid
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(objReader(0), objReader(1))
            End While
            objReader.Close()
        End With

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debtor class options parameters load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        On Error GoTo RaiseErr
        If e.ColumnIndex = 1 Then
            Dim strDescription As String = Nothing
            If Not Object.Equals(dGrid.CurrentCell.Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentCell.Value.ToString) Then
                    strDescription = dGrid.CurrentCell.Value.ToString
                End If
            End If
            If String.IsNullOrEmpty(strDescription) Then
                MessageBox.Show("The debtor class option cannot be blank", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim intTransactionId As Integer = 0
            If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                    If IsNumeric(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                        intTransactionId = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
                    End If
                End If
            End If

            If intTransactionId > 0 Then
                Cursor = Cursors.WaitCursor
                Dim strSql As String = "UPDATE [SystemDebtorClassOptions] SET Option = '" & strDescription & "' " _
                    & "WHERE TransactionId = " & intTransactionId & ""
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                LoadData()
                Cursor = Cursors.Default
                MessageBox.Show("Debtor class options parameter descriptions has been updated successfully",
                    "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debtor class option parameters modify update"
        ShowErrorMessage()
    End Sub

    Private Sub frmParmMainObservations_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadData()
        txtOption.Select()
    End Sub

    Private Sub txtObservation_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOption.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnAdd.Select()
        End If
    End Sub

    Private Sub dGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGrid.CellContentClick
        If e.ColumnIndex = dGrid.ColumnCount - 1 Then
            DeleteRecord(e.RowIndex)
        End If
    End Sub

    Private Sub DeleteRecord(ByVal RowId As Integer)
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        If MessageBox.Show("Are you sure you want to delete the selected record?", "Confirm Delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim intTransactionId As Integer = 0
            If Not Object.Equals(dGrid.Rows(RowId).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(RowId).Cells(0).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(RowId).Cells(0).Value.ToString) Then
                        intTransactionId = CInt(dGrid.Rows(RowId).Cells(0).Value.ToString)
                    End If
                End If
            End If
            If intTransactionId > 0 Then
                Dim strSql As String = "DELETE FROM [SystemDebtorClassOptions] WHERE TransactionId = " & intTransactionId & ""
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                LoadData()
                Cursor = Cursors.Default
                MessageBox.Show("Debtor class option has been deleted successfully", "Process Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debtor class option parameter delete"
        ShowErrorMessage()
    End Sub

    Private Sub ddGrid_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dGrid.CellMouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub dGrid_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dGrid.CellMouseEnter
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = dGrid.ColumnCount - 1 Then
            Cursor = Cursors.Hand
        End If
    End Sub

End Class