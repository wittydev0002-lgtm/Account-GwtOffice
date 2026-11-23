Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCashbookSetup

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtAccountNo.Text) Then
            MessageBox.Show("Please enter the account number for the cashbook", "Invalid Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNo.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountName.Text) Then
            MessageBox.Show("Please enter the account name for the cashbook", "Invalid Account Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtStartBalance.Text) Then
            txtStartBalance.Text = "0.00"
        End If
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = True Then
            strSql = "UPDATE Cashbooks SET AccountName = '" & txtAccountName.Text & "' WHERE AccountNumber = '" & txtAccountNo.Text & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Cashbook account has been set successfully", "Cash book Setup Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            strSql = "INSERT INTO Cashbooks (AccountName, AccountNumber) VALUES ('" & txtAccountName.Text & "', '" & txtAccountNo.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            'Update the cashbook balance as well
            Dim dblAmount As Double = CDbl(txtStartBalance.Text)
            Dim strEntryType As String = "DEBIT"
            If optCredit.Checked = True Then
                strEntryType = "CREDIT"
            End If
            strSql = "INSERT INTO CashbookTransactions (TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, TransactionType, AccountNumber) VALUES " _
                & "('" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "', " & dblAmount & ", 'START ON BALANCE', '00000', '" & strUserName & "', '" & strUserBranch & "', '" & strEntryType & "', '" & txtAccountNo.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            If MessageBox.Show("Cashbook created successfully. Do you want to add more cashbooks?", _
                    "Create More Cashbooks", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                txtAccountNo.Clear() : txtAccountName.Clear() : txtStartBalance.Text = "0.00" : txtAccountNo.Focus()
                Exit Sub
            Else
                Me.Close()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Cashbook Setup Error"
        ShowErrorMessage()
    End Sub

    Private Sub txtStartBalance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStartBalance.KeyPress
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAccountNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtAccountName.Focus()
            txtAccountName.SelectAll()
        End If
    End Sub

    Private Sub txtAccountName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtStartBalance.Focus()
            txtStartBalance.SelectAll()
        End If
    End Sub

    Private Sub frmCashbookSetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo RaiseErr
        If boolEditStatus = True Then
            txtAccountNo.Enabled = False
            txtStartBalance.Enabled = False
            dpStartDate.Enabled = False
            optCredit.Enabled = False : optDebit.Enabled = False
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Cashbooks WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader("AccountNumber").ToString) Then txtAccountNo.Text = objReader("AccountNumber").ToString
                If Not IsDBNull(objReader("AccountName").ToString) Then txtAccountName.Text = objReader("AccountName").ToString
            End If
            objReader.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Cashbook details Load"
        ShowErrorMessage()
    End Sub

End Class