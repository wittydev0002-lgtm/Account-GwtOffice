Imports CommonLibrary.Commons

Public Class frmDebtSettlementReasons

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmDebtSettlementReasons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Reason FROM DebtSettlementReasons ORDER BY Reason", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On debt repayment descriptions"
        ShowErrorMessage()
    End Sub

    Private Sub SaveDetails()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM DebtSettlementReasons", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(0).Value.ToString) Then
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO DebtSettlementReasons " _
                        & "(Reason) VALUES ('" & dGrid.Rows(i).Cells(0).Value.ToString & "')", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        Next
        MessageBox.Show("Process executed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On debt repayment descriptions"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If dGrid.Rows.Count > 0 Then
            SaveDetails()
        End If
    End Sub

    Private Sub frmDebtSettlementReasons_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 486 : Me.Height = 402
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter a valid description", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        End If
        dGrid.Rows.Add(txtDescription.Text)
        txtDescription.Clear()
        txtDescription.Focus()
    End Sub

    Private Sub txtDescription_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If String.IsNullOrEmpty(txtDescription.Text) Then
                MessageBox.Show("Please enter a valid description", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtDescription.Focus()
                Exit Sub
            End If
            dGrid.Rows.Add(txtDescription.Text)
            txtDescription.Clear()
            txtDescription.Focus()
        End If
    End Sub

End Class