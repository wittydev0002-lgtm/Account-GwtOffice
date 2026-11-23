Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBenefitsHistory
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmBenefitsHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT TransYear, Amount, CoopFee, AdminFee FROM  BM_TransactionHistory " _
            & "WHERE PolicyNumber = '" & strSelectedAccount & "' ORDER BY TransYear"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On co-op member history load"
        gwt_comm.ShowErrorMessage()
    End Sub
    Private Sub AcceptEntry()
        If Not IsNumeric(cboYear.Text) Then
            MessageBox.Show("Please select year from the given list", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboYear.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please a valid value for amount", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
        If CDbl(txtAmount.Text) = 0 Then
            MessageBox.Show("The amount should be greater than 0", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If

        On Error GoTo RaiseErr

        Dim dblRate As Double = 0
        Dim dblCopRate As Double = 0

        If CInt(cboYear.Text) <= 2008 Then
            dblRate = 0.6
            dblCopRate = 0.4
        Else
            dblRate = 0.8
            dblCopRate = 0.2
        End If

        dGrid.Rows.Add(cboYear.Text, txtAmount.Text, Format(CDbl(txtAmount.Text) * dblRate, "##0.00"), Format(CDbl(txtAmount.Text) * dblCopRate, "##0.00"))
        txtAmount.Text = 0
        If cboYear.SelectedIndex <> cboYear.Items.Count - 1 Then
            cboYear.Text = CInt((cboYear.Text) + 1)
        Else
            cboYear.SelectedIndex = 0
        End If
        cboYear.Focus()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On co-op member history capture"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        AcceptEntry()
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyData = Keys.Enter Then AcceptEntry()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "DELETE FROM BM_TransactionHistory WHERE PolicyNumber = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblAmount As Double = 0
            Dim intYear As Integer
            Dim dblCoopAmt As Double = 0
            Dim dblAdminAmt As Double = 0
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(0).Value.ToString) Then
                        intYear = CInt(dGrid.Rows(p).Cells(0).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        dblAmount = CDbl(dGrid.Rows(p).Cells(1).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(2).Value.ToString) Then
                        dblCoopAmt = CDbl(dGrid.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(3).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(3).Value.ToString) Then
                        dblAdminAmt = CDbl(dGrid.Rows(p).Cells(3).Value.ToString)
                    End If
                End If
            End If
            strSql = "INSERT INTO BM_TransactionHistory " _
                & "(PolicyNumber, TransYear, Amount, AdminFee, CoopFee) VALUES " _
                & "('" & strSelectedAccount & "', " & intYear & ", " & dblAmount & ", " & dblAdminAmt & ", " & dblCoopAmt & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Next
        Cursor = Cursors.Default
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On co-op member history capture"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboYear_KeyDown(sender As Object, e As KeyEventArgs) Handles cboYear.KeyDown
        If e.KeyData = Keys.Enter Then
            txtAmount.Select()
            txtAmount.SelectAll()
        End If
    End Sub
End Class