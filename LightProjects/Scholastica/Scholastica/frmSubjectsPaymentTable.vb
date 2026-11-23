Imports CommonLibrary.Commons

Public Class frmSubjectsPaymentTable

    Private Sub frmSubjectsPaymentTable_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtLevel.Select()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [Level], [Subjects], [Fees] FROM SC_SubjectsPaymentsTable ORDER BY [Level]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On Subjects Payments Table Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(txtLevel.Text) Then
            MessageBox.Show("Please enter the subject level", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLevel.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtSubjectsNumber.Text) Then
            MessageBox.Show("Please enter the correct number of subjects", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSubjectsNumber.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtCost.Text) Then
            MessageBox.Show("Please enter the correct fees to be charged", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCost.Focus()
            Exit Sub
        End If
        If CInt(txtSubjectsNumber.Text) = 0 Then
            MessageBox.Show("The number of subjects must be greater than 0", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSubjectsNumber.Focus()
            Exit Sub
        End If
        If CInt(txtCost.Text) = 0 Then
            MessageBox.Show("The cost of study must be greater than 0", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCost.Focus()
            Exit Sub
        End If
        dGrid.Rows.Add(txtLevel.Text, txtSubjectsNumber.Text, txtCost.Text)
        txtCost.Text = "0.00" : txtLevel.Clear() : txtSubjectsNumber.Text = "0"
        txtLevel.Select()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_SubjectsPaymentsTable", cnn)
        objCommand.ExecuteNonQuery()
        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim strLevel As String = Nothing
            Dim intSubjects As Integer = 1
            Dim dblCost As Double = 0
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strLevel = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        intSubjects = CInt(dGrid.Rows(p).Cells(1).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(2).Value.ToString) Then
                        dblCost = CDbl(dGrid.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
            End If
            Dim strSql As String = "INSERT INTO SC_SubjectsPaymentsTable ([Level], [Subjects], [Fees]) " _
                & "VALUES ('" & strLevel & "', " & intSubjects & ", " & dblCost & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Next
        MessageBox.Show("Subjects payment table has been successfully updated", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On Subjects Payments Table Save"
        ShowErrorMessage()
    End Sub

    Private Sub txtLevel_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLevel.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtSubjectsNumber.Focus()
            txtSubjectsNumber.SelectionStart = 0
            txtSubjectsNumber.SelectionLength = txtSubjectsNumber.TextLength
        End If
    End Sub

    Private Sub txtSubjectsNumber_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSubjectsNumber.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtCost.Focus()
            txtCost.SelectionStart = 0
            txtCost.SelectionLength = txtCost.TextLength
        End If
    End Sub

    Private Sub txtCost_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCost.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnAdd.Focus()
        End If
    End Sub

    Private Sub frmSubjectsPaymentTable_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 602
        Me.Height = 395
    End Sub
End Class