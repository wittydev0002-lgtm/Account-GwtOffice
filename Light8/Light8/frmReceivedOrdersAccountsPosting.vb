Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary
Imports CommonLibrary.Commons

Public Class frmReceivedOrdersAccountsPosting

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmReveivedOrdersAccountsPosting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If String.IsNullOrEmpty(strPublicCreditorsAccount) Or
            String.IsNullOrEmpty(strPublicPurchasesAccount) Then
            MessageBox.Show("Either the Creditors or the Purchases Control Account " _
                & "has not been set or defined in the special ledger accounts. " _
                & "No process can take place until this issue is resolved", "Control Accounts Not Defined",
                MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        lblBatchNo.Text = intSelectedBatchNumber
        lblValue.Text = Format(dblSelectedBatchTotal, "##0.00")
        lblCreditorsControl.Text = strPublicCreditorsAccount
        lblPurchasesControl.Text = strPublicPurchasesAccount
        lblSupplierId.Text = strSelectedAccount
        lblSupplierName.Text = strSelectedAccountName
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click

        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(lblCreditorsControl.Text) Then
            MessageBox.Show("Purchases control account not set. Process aborted", "Missing Key Data", _
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("You should type in something on description", "Missing Key Data", _
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDescription.Focus()
            Exit Sub
        End If

        'Post the amount to the purchases control, supplier account/cashbook, creditors control account
        'Set the batch number status to processed

        Dim intSpecialKey As Integer = gwt_comm.SpecialKey()
        Dim objCommand As Data.OleDb.OleDbCommand

        'Post to the creditors control as well
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SupplierTransactions " _
            & "([AccountNumber],[TransactionDate],[Amount],[TransactionType],[Description]," _
            & "[ReferenceNumber],[UserName],[BranchName],[Taxes]) VALUES ('" & lblSupplierId.Text & "', " _
            & "'" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', " & CDbl(lblValue.Text) & ", 'PURCHASE', " _
            & "'" & txtDescription.Text & "', '" & lblBatchNo.Text & "', '" & strUserName & "', " _
            & "'" & strUserBranch & "', 0)", cnn)
        objCommand.ExecuteNonQuery()

        'Post to the creditors control
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
            & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
            & "('" & strPublicCreditorsAccount & "', '" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', " & CDbl(lblValue.Text) & ", " _
            & "'DEBIT', '" & lblPurchasesControl.Text & "', '" & txtDescription.Text & "', " _
            & "'" & strUserName & "', '" & strUserBranch & "', " & Convert.ToDouble(lblBatchNo.Text) & ", " & intSpecialKey & ")", cnn)
        objCommand.ExecuteNonQuery()

        'Credit the cashbook account
        Dim strEntryType As String = "CREDIT"
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
            & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
            & "('" & strPublicCreditorsAccount & "', '" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', " & CDbl(lblValue.Text) & ", " _
            & "'CREDIT', '" & lblCreditorsControl.Text & "', '" & txtDescription.Text & "', " _
            & "'" & strUserName & "', '" & strUserBranch & "', " & Convert.ToDouble(lblBatchNo.Text) & ", " & intSpecialKey & ")", cnn)
        objCommand.ExecuteNonQuery()

        'Update batch set it to processed
        objCommand = New Data.OleDb.OleDbCommand("UPDATE OrdersReceipt SET Status = 'PROCESSED' " _
            & "WHERE BatchNo = " & lblBatchNo.Text & " AND SupplierId = '" & lblPurchasesControl.Text & "'", cnn)
        objCommand.ExecuteNonQuery()
        Cursor = Cursors.Default

        MessageBox.Show("Batch transactions posted to the ledgers successfully", "Process Success", _
            MessageBoxButtons.OK, MessageBoxIcon.Information)
        boolAbort = False
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Orders accounts posting"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmReceivedOrdersAccountsPosting_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 611 : Me.Height = 375
    End Sub

End Class
