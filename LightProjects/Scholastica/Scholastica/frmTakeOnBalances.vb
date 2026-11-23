Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmTakeOnBalances

    Private Sub btnAccept_Click(sender As System.Object, e As System.EventArgs) Handles btnAccept.Click
        If lblStudentId.Text = "0" Or lblStudentId.Text = Nothing Then
            MessageBox.Show("Please select valid student details", "Invalid Data Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDescription.Text) Then
            txtDescription.Text = "TAKE ON BALANCE"
        End If

        If Not String.IsNullOrEmpty(lblGivenName.Text) Then
            If Not String.IsNullOrEmpty(txtStudent.Text) Then
                dGrid.Rows.Add(txtStudent.Text, lblGivenName.Text, txtAmount.Text, txtDescription.Text)
                txtAmount.Text = "0.00"
                txtStudent.Text = "0"
                lblGivenName.Text = Nothing
                txtDescription.Text = Nothing
                ComputeTotals()
                txtStudent.Focus()
                txtStudent.Select()
                Exit Sub
            End If
        End If
        MessageBox.Show("Please enter valid amounts and student number", "Invalid Data Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub txtStudent_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStudent.KeyDown
        If e.KeyData = Keys.Enter Then
            strSearchText = txtStudent.Text
            boolAbort = False
            Dim frm As New frmStudentSearch
            frm.ShowDialog()
            If boolAbort = True Then Exit Sub
            lblGivenName.Text = strSelectedAccountName
            lblStudentId.Text = strSelectedAccount
            lblClass.Text = GetStudentClass(CInt(lblStudentId.Text))
            txtStudent.Text = strSelectedAccount
            If IsNumeric(strSelectedAccount) Then
                lblBalance.Text = Format(GetStudentBalance(CInt(strSelectedAccount)), "##0.00")
            Else
                lblBalance.Text = "0.00"
            End If
            txtAmount.Select()
        End If
    End Sub

    Private Function GetStudentClass(StudentNumber As Integer) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ClassName FROM SC_Students WHERE StudentId = " & StudentNumber & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Student class get"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Function GetStudentBalance(StudentId As Long) As Double
        On Error GoTo RaiseErr
        Dim dblReturn As Double = 0
        Dim strSql As String = "SELECT SUM(Debit - Credit) FROM SC_StudentTransactions WHERE StudentId = " & StudentId & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblReturn = CDbl(objReader(0).ToString)
            End If
        End If
        objReader.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On students payments receipting"
        ShowErrorMessage()
    End Function

    Private Sub ComputeTotals()
        Dim dblTotals As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(i).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                        dblTotals = dblTotals + CDbl(dGrid.Rows(i).Cells(2).Value.ToString)
                    End If
                End If
            End If
        Next
        lblTotals.Text = Format(dblTotals, "#,##0.00")
    End Sub

    Private Sub dGrid_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex = 2 Then
            ComputeTotals()
        End If
    End Sub

    Private Sub dGrid_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dGrid.RowsRemoved
        ComputeTotals()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblValue As Double = 0
            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(2).Value.ToString) Then
                        dblValue = CDbl(dGrid.Rows(p).Cells(2).Value.ToString)
                        Dim strRemarks As String = Nothing
                        Dim strDescription As String = "TAKE ON BALANCE"
                        If Not Object.Equals(dGrid.Rows(p).Cells(dGrid.Columns.Count - 1).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(dGrid.Columns.Count - 1).Value.ToString) Then
                                strDescription = dGrid.Rows(p).Cells(dGrid.Columns.Count - 1).Value.ToString
                            End If
                        End If
                        Dim strSql As String = "INSERT INTO [SC_StudentTransactions] ([StudentId],[Description],[Reference]," _
                            & "[Debit],[Credit],[UserName],[TransactionDate],[Remarks]) VALUES " _
                            & "('" & dGrid.Rows(p).Cells(0).Value.ToString & "', '" & strDescription & "', " _
                            & "'', " & dblValue & ", 0, " _
                            & "'" & strPublicActiveFullUserName & "', '" & Format(dpTransDate.Value, "dd-MMM-yyyy") & "', " _
                            & "'" & strRemarks & "')"
                        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                End If
            End If
        Next
        MessageBox.Show("Details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        dGrid.Rows.Clear()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On take on balances save"
        ShowErrorMessage()
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtDescription.Focus()
        End If
    End Sub

    Private Sub txtDescription_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescription.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnAccept.Focus()
        End If
    End Sub

    Private Sub frmTakeOnBalances_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 600 : Me.Height = 550
    End Sub

    Private Sub btnHistory_Click(sender As System.Object, e As System.EventArgs) Handles btnHistory.Click
        Dim frm As New frmTakeOnBalancesHistory
        frm.ShowDialog()
    End Sub

End Class