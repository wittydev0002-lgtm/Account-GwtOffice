Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoanCustomers

    Private Sub frmLoanCustomers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then
            LoadData()
            LoadTransactions()
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM LoanCustomers WHERE AccountNumber = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("AccountNumber").ToString) Then txtAccountNumber.Text = objReader("AccountNumber").ToString
            If Not IsDBNull(objReader("AccountName").ToString) Then txtAccountName.Text = objReader("AccountName").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("WhatsAppNo").ToString) Then txtWhatsappNo.Text = objReader("WhatsAppNo").ToString
            If IsDate(objReader("InceptionDate").ToString) Then dpTakeOn.Value = CDate(objReader("InceptionDate").ToString)
        End If
        objReader.Close()
        txtAccountNumber.Enabled = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Loan Customer Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmLoanCustomers_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 676 : Me.Height = 468
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        SaveData()
    End Sub

    Private Sub SaveData()
        If String.IsNullOrEmpty(txtAccountNumber.Text) Then
            MessageBox.Show("Please enter the account number", "Missing Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNumber.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountName.Text) Then
            MessageBox.Show("Please enter the name of the person/company", "Missing Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountName.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Address 1 should have a value", "Invalid Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Select()
            Exit Sub
        End If

        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing

        If boolEditStatus = False Then
            strSql = "INSERT INTO LoanCustomers (AccountName, Address1, Address2, Address3, Address4, " _
                            & "EmailAddress, Telephone, Cellphone, WhatsAppNo, InceptionDate, AccountNumber) VALUES " _
                            & "('" & txtAccountName.Text & "', '" & txtAddress1.Text & "', '" & txtAddress2.Text & "', " _
                            & "'" & txtAddress3.Text & "', '" & txtAddress4.Text & "', '" & txtEmailAddress.Text & "', " _
                            & "'" & txtTelephone.Text & "', '" & txtCellphone.Text & "', '" & txtWhatsappNo.Text & "', " _
                            & "'" & gwt_comm.shortMonthDateFormat(dpTakeOn.Value) & "', '" & txtAccountNumber.Text & "')"

        Else
            strSql = "UPDATE LoanCustomers SET AccountName = '" & txtAccountName.Text & "', " _
                           & "Address1 = '" & txtAddress1.Text & "', " _
                           & "Address2 = '" & txtAddress2.Text & "', " _
                           & "Address3 = '" & txtAddress3.Text & "', " _
                           & "Address4 = '" & txtAddress4.Text & "', " _
                           & "EmailAddress = '" & txtEmailAddress.Text & "', " _
                           & "Telephone = '" & txtTelephone.Text & "', " _
                           & "Cellphone = '" & txtCellphone.Text & "', " _
                           & "WhatsAppNo = '" & txtWhatsappNo.Text & "', " _
                           & "InceptionDate = '" & gwt_comm.shortMonthDateFormat(dpTakeOn.Value) & "' " _
                           & "WHERE AccountNumber = '" & txtAccountNumber.Text & "')"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Loan Customer Details Save"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadTransactions()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "CAST(DebitAmount AS DECIMAL(10,2)) AS [Debit], CAST(InterestCharges AS DECIMAL(10,2)) AS [Interest], " _
            & "CAST((CreditAmount + CapitalRepayment + InterestRepayment) AS DECIMAL(10,2)) AS [Paid], " _
            & "CAST((DebitAmount + InterestCharges - (CreditAmount + CapitalRepayment + InterestRepayment)) AS DECIMAL(10,2)) AS [Balance], " _
            & "Description FROM LoanTransactions WHERE AccountNumber = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridAccounts.Rows.Clear()

        Dim dblBalance As Double = 0

        While objReader.Read
            dGridAccounts.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
            If Not IsDBNull(objReader(4).ToString) Then
                If IsNumeric(objReader(4).ToString) Then
                    dblBalance = dblBalance + CDbl(objReader(4).ToString)
                End If
            End If
        End While
        objReader.Close()

        lblLoanBalance.Text = Format(dblBalance, "#,##0.00")

        'Get the total of all loans advanced
        Dim dblLoanTotal As Double = 0
        strSql = "SELECT SUM(Amount) FROM LoanAdvances WHERE AccountNumber = '" & strSelectedAccount & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblLoanTotal = CDbl(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        lblTotalAdvanced.Text = Format(dblLoanTotal, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Loan Customer Transactions Load"
        ShowErrorMessage()
    End Sub

End Class
