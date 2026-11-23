Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoanTypes

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtName.Text) Then
            MessageBox.Show("Please enter the loan name", "Missing Loan Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtName.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtInterestRate.Text) Then
            MessageBox.Show("Please enter a valid value for the iterest rate", "Invalid Interest Rate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtInterestRate.Focus()
            Exit Sub
        Else
            If CDbl(txtInterestRate.Text) < 0 Then
                MessageBox.Show("Interest rate cannot be less than zero. Please re-enter", "Invalid Interest Rate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtInterestRate.Focus()
                Exit Sub
            End If
        End If

        If Not IsNumeric(txtMinimumRepaymentAmount.Text) Then
            MessageBox.Show("Please enter a valid value for minimum repayment period", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMinimumRepaymentAmount.Focus()
            Exit Sub
        Else
            If CDbl(txtMinimumRepaymentAmount.Text) <= 0 Then
                MessageBox.Show("The repayment amount cannot be less or equal to zero. Please re-enter", "Invalid Repayment Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtMinimumRepaymentAmount.Focus()
                Exit Sub
            End If
        End If

        If Not IsNumeric(txtMaximumCapital.Text) Then
            MessageBox.Show("Please enter a valid amount for maximum capital", "Invalid Capital Maximum", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMaximumCapital.Focus()
            Exit Sub
        Else
            If CDbl(txtMaximumCapital.Text) <= 0 Then
                MessageBox.Show("Maximum capital cannot be less then or equal zero. Please re-enter", "Invalid Maximum Capital", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtMaximumCapital.Focus()
                Exit Sub
            End If
        End If

        'Save the details to the database

        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = True Then
            'First delete the record
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LoanTypes WHERE LoanName = '" & txtName.Text & "'", cnn)
            objCommand.ExecuteNonQuery()
        End If

        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LoanTypes (LoanName, InterestRate, MaximumCapital, " _
            & "MinimumRepaymentAmount, MinimumRepaymentPeriod, UserName, ChangeDate) VALUES ('" & txtName.Text & "', " _
            & "" & txtInterestRate.Text & ", " & txtMaximumCapital.Text & ", " & txtMinimumRepaymentAmount.Text & ", " _
            & "" & txtMinimumPeriod.Text & ", '" & strUserName & "', '" & Now & "')", cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Loan type has been saved successfully", "Loan Setup Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On loan types setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmLoanTypes_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 560 : Me.Height = 300
    End Sub

    Private Sub txtInterestRate_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtInterestRate.KeyDown
        If e.KeyData = Keys.Enter Then
            txtMaximumCapital.Select()
        End If
    End Sub

    Private Sub txtMaximumCapital_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMaximumCapital.KeyDown
        If e.KeyData = Keys.Enter Then
            txtMinimumRepaymentAmount.Select()
        End If
    End Sub

    Private Sub txtMinimumRepaymentAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMinimumRepaymentAmount.KeyDown
        If e.KeyData = Keys.Enter Then
            txtMinimumPeriod.Select()
        End If
    End Sub

    Private Sub txtMinimumPeriod_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMinimumPeriod.KeyDown
        If e.KeyData = Keys.Enter Then
            txtMaximumPeriod.Select()
        End If
    End Sub

    Private Sub txtMaximumPeriod_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMaximumPeriod.KeyDown
        If e.KeyData = Keys.Enter Then
            btnOK.Select()
        End If
    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyDown
        If e.KeyData = Keys.Enter Then
            txtInterestRate.Select()
        End If
    End Sub

End Class
