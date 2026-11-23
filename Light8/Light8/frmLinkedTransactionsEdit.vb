Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLinkedTransactionsEdit

    Private Sub frmLinkedTransactionsEdit_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr

        dGrid.Rows.Clear()

        Dim strSql As String = Nothing

        If IsDate(strSelectedDate) Then dpDate.Value = CDate(strSelectedDate)

        'Get the related record from the Cashbook, Ledgers, journal, customer records and supplier record

        'Cash book transactions
        '

        strSql = "SELECT 'Cashbook' AS [Source], UPPER(REPLACE(CONVERT(CHAR(11), cashbooktransactions.TransactionDate, 106), ' ', '-')) as [Date], " _
            & "Cashbooktransactions.[Description], ContraAccount AS [Contra Acc.], " _
            & "SUM(CASE WHEN cashbooktransactions.TransactionType = 'DEBIT' THEN ISNULL(cashbooktransactions.Amount, 0) END) AS [Debit], " _
            & "SUM(CASE WHEN cashbooktransactions.TransactionType = 'CREDIT' THEN ISNULL(cashbooktransactions.Amount, 0) END) AS [Credit] " _
            & "FROM cashbooktransactions WHERE SpecialKey = " & intSelectedSpecialKey & " " _
            & "GROUP BY cashbooktransactions.TransactionDate, cashbooktransactions.Description, cashbooktransactions.ContraAccount"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()

        'Ledger Transactions
        '
        strSql = "SELECT 'Ledger' AS [Source], UPPER(REPLACE(CONVERT(CHAR(11), LedgerTransactions.TransactionDate, 106), ' ', '-')) as [Date], " _
            & "LedgerTransactions.[Description], LedgerTransactions.AccountNumber AS [Contra Acc.], " _
            & "SUM(CASE WHEN LedgerTransactions.TransactionType = 'DEBIT' THEN ISNULL(LedgerTransactions.Amount, 0) END) AS [Debit], " _
            & "SUM(CASE WHEN LedgerTransactions.TransactionType = 'CREDIT' THEN ISNULL(LedgerTransactions.Amount, 0) END) AS [Credit] " _
            & "FROM LedgerTransactions WHERE SpecialKey = " & intSelectedSpecialKey & " " _
            & "GROUP BY LedgerTransactions.TransactionDate, LedgerTransactions.Description, LedgerTransactions.AccountNumber"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()

        ' Customer Transactions
        '

        strSql = "SELECT 'Customer Transaction' AS [Source], UPPER(REPLACE(CONVERT(CHAR(11), CustomerTransactions.TransactionDate, 106), ' ', '-')) as [Date], " _
            & "CustomerTransactions.[Description] AS [Description], CustomerTransactions.AccountNumber AS [Contra Acc.], " _
            & "SUM(CASE WHEN CustomerTransactions.Amount < 0 THEN ISNULL(CustomerTransactions.Amount, 0) END) AS [Debit], " _
            & "SUM(CASE WHEN CustomerTransactions.Amount > 0 THEN ISNULL(CustomerTransactions.Amount, 0) END) AS [Credit] " _
            & "FROM CustomerTransactions WHERE SpecialKey = " & intSelectedSpecialKey & " " _
            & "GROUP BY CustomerTransactions.TransactionDate, CustomerTransactions.Description, CustomerTransactions.AccountNumber"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()

        ' Supplier Transactions
        '
        strSql = "SELECT 'Supplier Transaction' AS [Source], UPPER(REPLACE(CONVERT(CHAR(11), SupplierTransactions.TransactionDate, 106), ' ', '-')) as [Date], " _
            & "SupplierTransactions.[Description] AS [Description], SupplierTransactions.AccountNumber AS [Contra Acc.], " _
            & "SUM(CASE WHEN SupplierTransactions.Amount < 0 THEN ISNULL(SupplierTransactions.Amount, 0) END) AS [Debit], " _
            & "SUM(CASE WHEN SupplierTransactions.Amount > 0 THEN ISNULL(SupplierTransactions.Amount, 0) END) AS [Credit] " _
            & "FROM SupplierTransactions WHERE SpecialKey = " & intSelectedSpecialKey & " " _
            & "GROUP BY SupplierTransactions.TransactionDate, SupplierTransactions.Description, SupplierTransactions.AccountNumber"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()

        'Get the journal transactions
        '
        strSql = "SELECT 'Journals' AS [Source], UPPER(REPLACE(CONVERT(CHAR(11), JournalEntries.TransDate, 106), ' ', '-')) as [Date], " _
            & "JournalEntries.[Narration] AS [Description], JournalEntries.AccountNumber AS [Contra Acc.], " _
            & "SUM(CASE WHEN JournalEntries.Amount = 'DEBIT' THEN ISNULL(JournalEntries.Amount, 0) END) AS [Debit], " _
            & "SUM(CASE WHEN JournalEntries.TransactionType = 'CREDIT' THEN ISNULL(JournalEntries.Amount, 0) END) AS [Credit] " _
            & "FROM JournalEntries WHERE SpecialKey = " & intSelectedSpecialKey & " " _
            & "GROUP BY JournalEntries.TransDate, JournalEntries.Narration, JournalEntries.AccountNumber"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()

        'Get invoices
        '
        strSql = "SELECT 'Invoices' AS [Source], UPPER(REPLACE(CONVERT(CHAR(11), CustomerSalesMain.TransDate, 106), ' ', '-')) as [Date], " _
            & "Customers.AccountName AS [Description], CustomerSalesMain.CustomerId AS [Contra Acc.], " _
            & "CAST(CustomerSalesMain.Amount AS DECIMAL (30,2)) AS [Debit], '0' AS [Credit] FROM CustomerSalesMain " _
            & "LEFT OUTER JOIN Customers ON CustomerSalesMain.CustomerId = Customers.AccountNumber " _
            & "WHERE CustomerSalesMain.SpecialKey = " & intSelectedSpecialKey & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()

        'Get suppliers
        '
        strSql = "SELECT 'Supplier Invoices' AS [Source], UPPER(REPLACE(CONVERT(CHAR(11), SupplierInvoicesMain.TransDate, 106), ' ', '-')) as [Date], " _
            & "Suppliers.AccountName AS [Description], SupplierInvoicesMain.AccountNumber AS [Contra Acc.], '0' AS [Debit], " _
            & "CAST(SupplierInvoicesMain.Value AS DECIMAL (30,2)) AS [Credit] FROM SupplierInvoicesMain " _
            & "LEFT OUTER JOIN Suppliers ON SupplierInvoicesMain.AccountNumber = Suppliers.AccountNumber " _
            & "WHERE SupplierInvoicesMain.SpecialKey = " & intSelectedSpecialKey & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()

        'Get the debit notes
        '
        strSql = "SELECT 'Debit Notes' AS [Source], UPPER(REPLACE(CONVERT(CHAR(11), DebitNotesMain.TransDate, 106), ' ', '-')) as [Date], " _
            & "Suppliers.AccountName AS [Description], DebitNotesMain.AccountId AS [Contra Acc.], " _
            & "CAST(DebitNotesMain.TransTotal AS DECIMAL (30,2)) AS [Debit], '0' AS [Credit] FROM DebitNotesMain " _
            & "LEFT OUTER JOIN Suppliers ON DebitNotesMain.AccountId = Suppliers.AccountNumber " _
            & "WHERE DebitNotesMain.SpecialKey = " & intSelectedSpecialKey & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()

        'Get the credit notes
        '
        strSql = "SELECT 'Credit Notes' AS [Source], UPPER(REPLACE(CONVERT(CHAR(11), CreditNotesMain.TransDate, 106), ' ', '-')) as [Date], " _
            & "Customers.AccountName AS [Description], CreditNotesMain.AccountId AS [Contra Acc.], '0' AS [Debit], " _
            & "CAST(CreditNotesMain.TransTotal AS DECIMAL (30,2)) AS [Credit] FROM CreditNotesMain " _
            & "LEFT OUTER JOIN Customers ON CreditNotesMain.AccountId = Customers.AccountNumber " _
            & "WHERE CreditNotesMain.SpecialKey = " & intSelectedSpecialKey & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On linked transactions load"
        ShowErrorMessage()
    End Sub

    Private Sub frmLinkedTransactionsEdit_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 654 : Me.Height = 460
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If MessageBox.Show("Are you sure you want to update this record and all related record?",
            "Confirm Special Date Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            boolAbort = False
            gwt_comm.UpdateSpecialKeyTransactionDate(intSelectedSpecialKey, dpDate.Value)
            If boolAbort = True Then Exit Sub
            MessageBox.Show("Record and all related records have been updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

End Class