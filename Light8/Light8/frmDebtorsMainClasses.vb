Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDebtorsMainClasses

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(txtMainClass.Text) Then
            MessageBox.Show("Please enter the debtor class parameter description",
                "Missing Key Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMainClass.Select()
            Exit Sub
        End If

        ' Check that the entry has not been made earlier
        '
        Dim boolExits As Boolean = False
        With dGrid
            For p As Integer = 0 To .RowCount - 1
                If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(1).Value.ToString) Then
                        If UCase(Trim(.Rows(p).Cells(1).Value.ToString)) = UCase(Trim(txtMainClass.Text)) Then
                            boolExits = True
                            Exit For
                        End If
                    End If
                End If
            Next
        End With

        If boolExits = True Then
            MessageBox.Show("A similar debtor class parameter already exists", "Duplicate Record Entry",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMainClass.Select()
            txtMainClass.SelectAll()
            Exit Sub
        End If

        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = "INSERT INTO SystemDebtorsMainClasses ([Description]) VALUES ('" & txtMainClass.Text & "')"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        LoadData()

        Cursor = Cursors.Default

        txtMainClass.Clear()
        txtMainClass.Select()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debtors main classes parameters setup"
        ShowErrorMessage()
    End Sub

    Private Sub UpdateFormTables()
        On Error GoTo RaiseErr
        If gwt_comm.CheckTableExistence("SystemDebtorsMainClasses") = False Then
            Dim strSql As String = "CREATE TABLE [SystemDebtorsMainClasses]([TransactionId][INT] NOT NULL PRIMARY KEY IDENTITY (1,1), " _
                & "[Description][NVARCHAR](250) NOT NULL DEFAULT '')"
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            strSql = "CREATE TABLE [SystemDebtorClassOptions] ([TransactionId][INT] NOT NULL PRIMARY KEY IDENTITY (1,1), " _
                & "[Option][NVARCHAR](35) Not NULL DEFAULT '', [OrdinalNo][INT] NOT NULL REFERENCES [SystemDebtorsMainClasses] (TransactionId))"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = DefaultCursor
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On System Debtors Main Classes Table Create"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()

        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = "SELECT [TransactionId] as [TID], [Description] FROM SystemDebtorsMainClasses ORDER BY Description"
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
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debtors main classes parameters load"
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
                MessageBox.Show("The observation cannot be blank", "Invalid Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                Dim strSql As String = "UPDATE SystemOchmasObservations SET Description = '" & strDescription & "' " _
                    & "WHERE TransactionId = " & intTransactionId & ""
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                LoadData()
                Cursor = Cursors.Default
                MessageBox.Show("Observation parameter description has been updated successfully",
                    "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On observation parameters modify update"
        ShowErrorMessage()
    End Sub

    Private Sub frmParmMainObservations_Load(sender As Object, e As EventArgs) Handles Me.Load
        UpdateFormTables()
        LoadData()
        txtMainClass.Select()
    End Sub

    Private Sub txtObservation_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMainClass.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnAdd.Select()
        End If
    End Sub

    Private Sub dGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGrid.CellContentClick
        intSelectedTransactionId = 0
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                If IsNumeric(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                    intSelectedTransactionId = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
                End If
            End If
        End If
        If e.ColumnIndex = dGrid.ColumnCount - 2 Then
            If intSelectedTransactionId > 0 Then
                Dim frm As New frmDebtorsMainClassOptions
                frm.ShowDialog()
                intSelectedTransactionId = 0
            End If
        End If
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
                Dim strSql As String = "DELETE FROM SystemDebtorsMainClasses WHERE TransactionId = " & intTransactionId & ""
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                LoadData()
                Cursor = Cursors.Default
                MessageBox.Show("Debtor main class has been deleted successfully", "Process Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debtor main class parameters delete"
        ShowErrorMessage()
    End Sub

    Private Sub ddGrid_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dGrid.CellMouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub dGrid_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dGrid.CellMouseEnter
        If e.RowIndex < 0 Then Exit Sub
        If e.ColumnIndex = dGrid.ColumnCount - 1 Or e.ColumnIndex = dGrid.ColumnCount - 2 Then
            Cursor = Cursors.Hand
        End If
    End Sub

End Class