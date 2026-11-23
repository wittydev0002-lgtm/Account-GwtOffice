Imports CommonLibrary.Commons
'Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBatchTransactions


    Private Sub dGridTransactions_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridTransactions.KeyDown
        If e.KeyValue = Keys.F3 Then
            If dGridTransactions.CurrentCell.ColumnIndex = 0 Then
                strPublicItemCode = Nothing
                strFullItemDetails = Nothing
                boolAbort = False
                gwt_comm.EmployeeSearch()
                If boolAbort = True Then Exit Sub
                dGridTransactions.CurrentRow.Cells(3).Value = strSelectedAccountName
                dGridTransactions.CurrentRow.Cells(0).Value = strSelectedAccount
                dGridTransactions.CurrentCell = dGridTransactions.Rows(dGridTransactions.CurrentRow.Index).Cells(1)
            End If
        End If
    End Sub

    Private Sub btnSaveBatch_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveBatch.Click
        'Write the information read off the listview
        On Error GoTo RaiseErr
        'Allocate the batch number at this point
        If lblBatchNumber.Text = 0 Then
            GetNextBatchNumber()
            MessageBox.Show("You batch number is " & intCurrentBatchNumber, "Batch Number Control", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Not IsNumeric(lblBatchNumber.Text) Then
                MessageBox.Show("The batch you are trying to update does not exist", "Invalid Batch Number",
                                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                intCurrentBatchNumber = CInt(lblBatchNumber.Text)
            End If
        End If

        Dim intNumberOfEntries As Integer = 0

        'Delete any transactions for this batch if they exist at all
        Dim strSql As String = "DELETE FROM EmployeeBatches WHERE BatchNo = " & intCurrentBatchNumber & " AND " _
            & "PayrollNo = " & intPayrollNumber & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "DELETE FROM SystemBatchesControl WHERE BatchNo = " & intCurrentBatchNumber & " AND " _
            & "PayrollNo = " & intPayrollNumber & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Dim dblTotals As Double = 0
        For i = 0 To dGridTransactions.Rows.Count - 1
            Dim strEc As String = Nothing
            Dim dblValue As String = 0
            Dim intCode As Integer = 0
            If Not Object.Equals(dGridTransactions.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridTransactions.Rows(i).Cells(0).Value.ToString) Then
                    strEc = dGridTransactions.Rows(i).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGridTransactions.Rows(i).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridTransactions.Rows(i).Cells(2).Value.ToString) Then
                    If IsNumeric(dGridTransactions.Rows(i).Cells(2).Value.ToString) Then
                        dblValue = CDbl(dGridTransactions.Rows(i).Cells(2).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGridTransactions.Rows(i).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridTransactions.Rows(i).Cells(1).Value.ToString) Then
                    If IsNumeric(dGridTransactions.Rows(i).Cells(1).Value.ToString) Then
                        intCode = CDbl(dGridTransactions.Rows(i).Cells(1).Value.ToString)
                    End If
                End If
            End If
            If Not String.IsNullOrEmpty(strEc) Then
                If intCode <> 0 Then
                    strSql = "INSERT INTO EmployeeBatches (EntryLineNo, BatchNo, " _
                        & "EmployeeNo, Amount, TransDate, CodeNo, CostCode, " _
                        & "UserName, EffectivePeriod, Class, PayrollNo) VALUES (" & (i + 1) & ", " _
                        & "" & intCurrentBatchNumber & ", '" & strEc & "', " _
                        & "" & dblValue & ", '" & gwt_comm.shortMonthDateFormat(Now) & "', " _
                        & "" & intCode & ", " _
                        & "'', '" & strUserName & "', 0, 1, " & intPayrollNumber & ")"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                    dblTotals = dblTotals + dblValue 'CDbl(dGridTransactions.Rows(i).Cells(2).Value.ToString)
                    intNumberOfEntries = intNumberOfEntries + 1
                End If
            End If
        Next

        'Write the batch control values
        Dim sqlBatchesCommand As New Data.OleDb.OleDbCommand("INSERT INTO SystemBatchesControl " _
            & "(BatchNo, CreationDate, Author, Status, BatchTotal, NumberOfEntries) VALUES (" _
            & "" & intCurrentBatchNumber & ", '" & gwt_comm.shortMonthDateFormat(Now) & "', '" & strPublicActiveFullUserName & "', 'NOT PROCESSED', " _
            & "" & dblTotals & ", " & intNumberOfEntries & ")", cnn)
        sqlBatchesCommand.ExecuteNonQuery()
        MessageBox.Show("The batch has been successfully written to file", "Payroll Batches Save", MessageBoxButtons.OK, MessageBoxIcon.Information)

        dGridTransactions.Rows.Clear()
        dGridTransactions.Rows.Add(100)

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Batch Transactions Save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnNewBatch_Click(sender As System.Object, e As System.EventArgs) Handles btnNewBatch.Click
        dGridTransactions.Rows.Clear()
        dGridTransactions.Rows.Add(100)
    End Sub

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGridTransactions_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridTransactions.CellEndEdit

        If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Then
            If Not Object.Equals(dGridTransactions.CurrentCell.Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridTransactions.CurrentCell.Value.ToString) Then
                    If e.ColumnIndex = 1 Then
                        If IsNumeric(dGridTransactions.CurrentCell.Value) Then
                            dGridTransactions.CurrentCell.Value = Format(CDbl(dGridTransactions.CurrentCell.Value.ToString), "##0")
                        End If
                    Else
                        If IsNumeric(dGridTransactions.CurrentCell.Value) Then
                            dGridTransactions.CurrentCell.Value = Format(CDbl(dGridTransactions.CurrentCell.Value.ToString), "000")
                        End If
                    End If
                    DisplayDescriptions(e.ColumnIndex, dGridTransactions.CurrentCell.Value.ToString)
                End If
            End If
        Else
            If e.ColumnIndex = 2 Then
                If Not Object.Equals(dGridTransactions.CurrentCell.Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridTransactions.CurrentCell.Value.ToString) Then
                        If IsNumeric(dGridTransactions.CurrentCell.Value) Then
                            dGridTransactions.CurrentCell.Value = Format(CDbl(dGridTransactions.CurrentCell.Value.ToString), "##0.00")
                            ComputeBatchTotals()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dGridTransactions_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridTransactions.EditingControlShowing
        Try
            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                'In order to prevent optical problems, we had to call the removeHandler twice
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DisplayDescriptions(ByVal ColumnNumber As Integer, ByVal strColumnValue As String)

        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        If ColumnNumber = 1 Then
            If Not IsNumeric(strColumnValue) Then strColumnValue = "0"
            objCommand = New Data.OleDb.OleDbCommand("SELECT Description FROM SystemCodes WHERE CodeNo = " & strColumnValue & "", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then dGridTransactions.CurrentRow.Cells(4).Value = objReader(0).ToString
            Else
                MessageBox.Show("Code entered does not exist in the system", "Invalid Code Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dGridTransactions.CurrentCell.Value = "0"
            End If
            objReader.Close()
        End If
        If ColumnNumber = 0 Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName FROM EmployeeMaster WHERE EmployeeNo = '" & strColumnValue & "'", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then dGridTransactions.CurrentRow.Cells(3).Value = objReader(0).ToString
            Else
                MessageBox.Show("Employee number entered does not exist in the system", "Invalid Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dGridTransactions.CurrentCell.Value = Nothing
            End If
            objReader.Close()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to get description for the entered field"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeBatchTotals()
        On Error GoTo RaiseErr
        Dim dblTotalAmount As Double = 0
        For p As Integer = 0 To dGridTransactions.Rows.Count - 1
            If Not Object.Equals(dGridTransactions.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridTransactions.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGridTransactions.Rows(p).Cells(2).Value.ToString) Then
                        dblTotalAmount = dblTotalAmount + CDbl(dGridTransactions.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
            End If
        Next
        lblBatchTotal.Text = Format(dblTotalAmount, "##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Batch amounts total computation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnViewBatch_Click(sender As System.Object, e As System.EventArgs) Handles btnViewBatch.Click
        intSelectedBatchNumber = 0
        Dim frm As New frmBatchesListing
        frm.ShowDialog()
        If intSelectedBatchNumber <> 0 Then
            lblBatchNumber.Text = intSelectedBatchNumber
            LoadSelectedBatchTransactions(intSelectedBatchNumber)
        End If
    End Sub

    Private Sub LoadSelectedBatchTransactions(BatchNumber As Integer)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT EmployeeNo, CodeNo, Amount FROM EmployeeBatches " _
            & "WHERE BatchNo = " & BatchNumber & " AND PayrollNo = " & intPayrollNumber & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim p As Integer = 0
        While objReader.Read
            Dim strEcnum As String = Nothing
            Dim intCode As Integer = 0
            Dim dblValue As Double = 0
            If Not IsDBNull(objReader(0).ToString) Then
                strEcnum = objReader(0).ToString
            End If
            If Not IsDBNull(objReader(1).ToString) Then
                If IsNumeric(objReader(1).ToString) Then
                    intCode = CInt(objReader(1).ToString)
                End If
            End If
            If Not IsDBNull(objReader(2).ToString) Then
                If IsNumeric(objReader(2).ToString) Then
                    dblValue = CDbl(objReader(2).ToString)
                End If
            End If
            With dGridTransactions
                .Rows(p).Cells(0).Value = strEcnum
                .Rows(p).Cells(1).Value = intCode
                .Rows(p).Cells(2).Value = dblValue
            End With
            p = p + 1
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Batch details load"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class