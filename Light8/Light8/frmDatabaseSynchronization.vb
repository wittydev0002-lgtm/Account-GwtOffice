Imports System.Text
Imports System.IO
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDatabaseSynchronization

    Dim objFile As System.IO.StreamWriter

    Private Sub frmDatabaseSynchronization_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadMarkers()
    End Sub

    Private Sub frmDatabaseSynchronization_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '640; 350
        Me.Width = 640
        Me.Height = 350
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        If chkScriptToFile.Checked = True Then
            Dim sfd As New SaveFileDialog
            sfd.ShowDialog()
            If Not String.IsNullOrEmpty(sfd.FileName) Then
                objFile = New StreamWriter(sfd.FileName)
            Else
                MessageBox.Show("You have to specify the output file name. Process will be aborted", _
                    "Invalid File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim strCurrentRecord As String = Nothing
        If String.IsNullOrEmpty(txtLastDate.Text) Then
            MessageBox.Show("Process cannot be executed. Missing the last update date." & vbCrLf & _
                "Please consult your service provider", "Insufficient Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not IsNumeric(txtLastInvoice.Text) Then
            MessageBox.Show("Process cannot be executed. Missing the last invoice number." & vbCrLf & _
                "Please consult your service provider", "Insufficient Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not IsNumeric(txtLastQuotation.Text) Then
            MessageBox.Show("Process cannot be executed. Missing the last quotation number." & vbCrLf & _
                "Please consult your service provider", "Insufficient Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not IsNumeric(txtLastReceipt.Text) Then
            MessageBox.Show("Process cannot be executed. Missing the last receipt number." & vbCrLf & _
                "Please consult your service provider", "Insufficient Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'Get the external database connection string 
        Dim strExternalDatabaseConnectionString As String = Nothing
        Dim objFileReader As New StreamReader(Application.StartupPath & "\Data\" & strExternalDatabaseFilename)
        strExternalDatabaseConnectionString = objFileReader.ReadLine
        objFileReader.Close()

        If String.IsNullOrEmpty(strExternalDatabaseConnectionString) Then
            MessageBox.Show("The external database connection properties have not be set" & vbCrLf & _
                "Please contact your service provider for assistance", "Missing External Database Connection String", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim arrData As New ArrayList

        Cursor = Cursors.WaitCursor
        Dim ExternalConn As New Data.OleDb.OleDbConnection(strExternalDatabaseConnectionString)
        ExternalConn.Open()

        'Start processing the sales
        Dim intCounter As Integer = 0
        Dim strLastUpdateDate As String = CStr(shortMonthDateFormat(Now))
        Dim intLastInvoiceNumber As Integer = CLng(txtLastInvoice.Text)
        Dim intLastReceiptNumber As Integer = CLng(txtLastReceipt.Text)
        Dim intLastQuoteNumber As Integer = CLng(txtLastQuotation.Text)

        Dim strSql As String = "SELECT [InvoiceNumber],[CustomerId],[Status],[Amount],[Taxes],[Discount]," _
            & "[TransDate],[OriginalInvoice],[SalesRep],[UserName],[ContactNumber],[ContactName],[ServiceCategory]," _
            & "[ExpensesRate],[CommissionRate] FROM SalesMain WHERE TransDate >= " _
            & "'" & txtLastDate.Text & "' AND InvoiceNumber > " & CLng(txtLastReceipt.Text) & " ORDER BY TransDate, InvoiceNumber"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, ExternalConn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO SalesMain ([InvoiceNumber],[CustomerId],[Status]," _
                & "[Amount],[Taxes],[Discount],[TransDate],[OriginalInvoice],[SalesRep],[UserName]," _
                & "[ContactNumber],[ContactName],[ServiceCategory],[ExpensesRate],[CommissionRate]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
            strLastUpdateDate = shortMonthDateFormat(CDate(objReader("TransDate").ToString))
            intLastReceiptNumber = CLng(objReader("InvoiceNumber").ToString)
        End While
        objReader.Close()

        'Script the sales table
        strSql = "SELECT [InvoiceNumber],[CustomerId],[ItemCode],[Description],[QuantityOld],[DiscountAllowed]," _
            & "[Taxes],[TransType],[SalesPrice],[TransDate],[ProductType],[SerialNumbers],[OriginalInvoice]," _
            & "[SalesRep],[UserName],[Quantity],[CostPrice],[ExpensesRate],[ServiceCategory],[CommissionRate] " _
            & "FROM [Sales] WHERE TransDate >= '" & txtLastDate.Text & "' AND InvoiceNumber > " & CLng(txtLastReceipt.Text) & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, ExternalConn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO Sales ([InvoiceNumber],[CustomerId],[ItemCode],[Description]," _
                & "[QuantityOld],[DiscountAllowed],[Taxes],[TransType],[SalesPrice],[TransDate],[ProductType]," _
                & "[SerialNumbers],[OriginalInvoice],[SalesRep],[UserName],[Quantity],[CostPrice],[ExpensesRate]," _
                & "[ServiceCategory],[CommissionRate]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
        End While
        objReader.Close()

        With pb1
            .Value = 0
            .Maximum = arrData.Count + 1
            .Visible = True
            cpb1.Value = 0
            cpb1.Maximum = arrData.Count + 1
            'cpb1.Visible = True
        End With

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SalesMain WHERE TransDate >= '" & txtLastDate.Text & "' AND InvoiceNumber > " & CLng(txtLastReceipt.Text) & "", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Sales WHERE TransDate >= '" & txtLastDate.Text & "' AND InvoiceNumber > " & CLng(txtLastReceipt.Text) & "", cnn)
        objCommand.ExecuteNonQuery()

        'Update the database
        For i As Integer = 0 To arrData.Count - 1
            If chkScriptToFile.Checked = False Then
                objCommand = New Data.OleDb.OleDbCommand(arrData.Item(i), cnn)
                objCommand.ExecuteNonQuery()
            Else
                objFile.WriteLine(arrData.Item(i))
            End If
            pb1.Value = pb1.Value + 1
            cpb1.Value = cpb1.Value + 1
        Next

        'Update the Customer sales tables

        arrData = New ArrayList
        strSql = "SELECT [InvoiceNumber],[CustomerId],[Status],[Amount],[Taxes],[Discount]," _
           & "[TransDate],[OriginalInvoice],[SalesRep],[UserName] FROM CustomerSalesMain WHERE TransDate > " _
           & "'" & txtLastDate.Text & "' AND InvoiceNumber > " & CLng(txtLastInvoice.Text) & " ORDER BY TransDate, InvoiceNumber"
        objCommand = New Data.OleDb.OleDbCommand(strSql, ExternalConn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO CustomerSalesMain ([InvoiceNumber],[CustomerId],[Status]," _
                & "[Amount],[Taxes],[Discount],[TransDate],[OriginalInvoice],[SalesRep],[UserName]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
            intLastInvoiceNumber = CLng(objReader("InvoiceNumber").ToString)
        End While
        objReader.Close()

        'Script the CustomerSales table
        strSql = "SELECT [InvoiceNumber],[CustomerId],[ItemCode],[Description],[QuantityOld],[DiscountAllowed]," _
            & "[Taxes],[TransType],[SalesPrice],[TransDate],[ProductType],[SerialNumbers],[OriginalInvoice]," _
            & "[SalesRep],[UserName],[Quantity],[CostPrice] FROM [CustomerSales] WHERE TransDate > " _
            & "'" & txtLastDate.Text & "' AND InvoiceNumber > " & CLng(txtLastInvoice.Text) & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, ExternalConn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO CustomerSales ([InvoiceNumber],[CustomerId],[ItemCode],[Description]," _
                & "[QuantityOld],[DiscountAllowed],[Taxes],[TransType],[SalesPrice],[TransDate],[ProductType]," _
                & "[SerialNumbers],[OriginalInvoice],[SalesRep],[UserName],[Quantity],[CostPrice]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
        End While
        objReader.Close()

        With pb1
            .Value = 0
            .Maximum = arrData.Count + 1
            .Visible = True
            cpb1.Value = 0
            cpb1.Maximum = arrData.Count + 1
            'cpb1.Visible = True
        End With

        'Insert this data into the current database tables. First drop the information 
        'this may cause duplicate keys

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSalesMain WHERE TransDate > '" & txtLastDate.Text & "' AND InvoiceNumber > " & CLng(txtLastInvoice.Text) & "", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSales WHERE TransDate > '" & txtLastDate.Text & "' AND InvoiceNumber > " & CLng(txtLastInvoice.Text) & "", cnn)
        objCommand.ExecuteNonQuery()

        'Update the database
        For i As Integer = 0 To arrData.Count - 1
            If chkScriptToFile.Checked = False Then
                objCommand = New Data.OleDb.OleDbCommand(arrData.Item(i), cnn)
                objCommand.ExecuteNonQuery()
            Else
                objFile.WriteLine(arrData.Item(i))
            End If
            pb1.Value = pb1.Value + 1
            cpb1.Value = cpb1.Value + 1
        Next

        'Update the quotations main tables

        arrData = New ArrayList
        strSql = "SELECT [TransDate],[SalesAgent],[CustomerName],[Address1],[Address2],[Address3],[Address4],[ContactNumber]," _
            & "[EmailAddress],[UserName],[UserBranch],[ReferenceNumber],[Terms],[QuoteValue],[TotalDiscount],[TotalTaxes]," _
            & "[TaxNumber] FROM QuoteMain WHERE TransDate > " _
            & "'" & txtLastDate.Text & "' AND ReferenceNumber > " & CLng(txtLastQuotation.Text) & " ORDER BY TransDate, ReferenceNumber"
        objCommand = New Data.OleDb.OleDbCommand(strSql, ExternalConn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO QuoteMain ([TransDate],[SalesAgent],[CustomerName],[Address1],[Address2]," _
                & "[Address3],[Address4],[ContactNumber],[EmailAddress],[UserName],[UserBranch],[ReferenceNumber],[Terms]," _
                & "[QuoteValue],[TotalDiscount],[TotalTaxes],[TaxNumber]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
            intLastQuoteNumber = CLng(objReader("ReferenceNumber").ToString)
        End While
        objReader.Close()

        'Script the QuoteDetails table

        strSql = "SELECT [ReferenceNumber],[QuantityOld],[ItemCode],[Description],[UnitPrice],[Discount]," _
            & "[Tax],[Payable],[SubTotal],[Quantity] FROM QuoteDetails " _
            & "WHERE ReferenceNumber > " & CLng(txtLastQuotation.Text) & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, ExternalConn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO QuoteDetails ([ReferenceNumber],[QuantityOld],[ItemCode]," _
                & "[Description],[UnitPrice],[Discount],[Tax],[Payable],[SubTotal],[Quantity]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
        End While
        objReader.Close()

        With pb1
            .Value = 0
            .Maximum = arrData.Count + 1
            .Visible = True
            cpb1.Value = 0
            cpb1.Maximum = arrData.Count + 1
            'cpb1.Visible = True
        End With

        'Insert this data into the current database tables. First drop the information 
        'this may cause duplicate keys

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM QuoteMain WHERE TransDate > '" & txtLastDate.Text & "' AND ReferenceNumber > " & CLng(txtLastQuotation.Text) & "", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM QuoteDetails WHERE ReferenceNumber > " & CLng(txtLastQuotation.Text) & "", cnn)
        objCommand.ExecuteNonQuery()

        'Update the database
        For i As Integer = 0 To arrData.Count - 1
            If chkScriptToFile.Checked = False Then
                objCommand = New Data.OleDb.OleDbCommand(arrData.Item(i), cnn)
                objCommand.ExecuteNonQuery()
            Else
                objFile.WriteLine(arrData.Item(i))
            End If
            pb1.Value = pb1.Value + 1
            cpb1.Value = cpb1.Value + 1
        Next

        'Get the information from the ledger transactions and ledger accounts

        arrData = New ArrayList

        'Drop any values that are old
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerAccounts", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE TransactionDate >= '" & txtLastDate.Text & "'", cnn)
        objCommand.ExecuteNonQuery()

        If chkScriptToFile.Checked = True Then
            arrData.Add("DELETE FROM LedgerAccounts")
            arrData.Add("DELETE FROM LedgerTransactions WHERE TransactionDate >= '" & txtLastDate.Text & "'")
        End If

        strSql = "SELECT [AccountNumber],[AccountName],[AccountType],[Classification], " _
            & "[UserBranch],[TakeonDate],[SubAccountOf],[TopLevelAccount],[CashFlowCategory] " _
            & "FROM LedgerAccounts ORDER BY AccountNumber, AccountName"
        objCommand = New Data.OleDb.OleDbCommand(strSql, ExternalConn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO LedgerAccounts ([AccountNumber],[AccountName],[AccountType]," _
                & "[Classification],[UserBranch],[TakeonDate],[SubAccountOf]," _
                & "[TopLevelAccount],[CashFlowCategory]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
        End While
        objReader.Close()

        strSql = "SELECT [TransactionDate],[AccountNumber],[Amount],[TransactionType],[ContraAccount],[Description]," _
            & "[UserName],[UserBranch],[Reference],[FolioReference],[BranchCode],[DepartmentCode],[ReceiptNumber]," _
            & "[InvoiceNumber],[DebitNoteNumber],[CreditNoteNumber],[CostCode] FROM LedgerTransactions WHERE " _
            & "TransactionDate >= '" & txtLastDate.Text & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, ExternalConn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO LedgerTransactions ([TransactionDate],[AccountNumber],[Amount]," _
                & "[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch],[Reference],[FolioReference]," _
                & "[BranchCode],[DepartmentCode],[ReceiptNumber],[InvoiceNumber],[DebitNoteNumber],[CreditNoteNumber]," _
                & "[CostCode]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
        End While
        objReader.Close()

        'Update the ledger transactions then

        With pb1
            .Value = 0
            .Maximum = arrData.Count + 1
            .Visible = True
            cpb1.Value = 0
            cpb1.Maximum = arrData.Count + 1
        End With

        For i As Integer = 0 To arrData.Count - 1
            If chkScriptToFile.Checked = False Then
                objCommand = New Data.OleDb.OleDbCommand(arrData.Item(i), cnn)
                objCommand.ExecuteNonQuery()
            Else
                objFile.WriteLine(arrData.Item(i))
            End If
            pb1.Value = pb1.Value + 1
            cpb1.Value = cpb1.Value + 1
        Next

        '*** UPDATE THE CASHBOOK TRANSACTIONS AS WELL ***

        arrData = New ArrayList

        'Drop any values that are old
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Cashbooks", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CashbookTransactions WHERE TransactionDate >= '" & txtLastDate.Text & "'", cnn)
        objCommand.ExecuteNonQuery()

        If chkScriptToFile.Checked = True Then
            arrData.Add("DELETE FROM Cashbooks")
            arrData.Add("DELETE FROM CashbookTransactions WHERE TransactionDate >= '" & txtLastDate.Text & "'")
        End If

        strSql = "SELECT [AccountNumber],[AccountName] FROM Cashbooks"
        objCommand = New Data.OleDb.OleDbCommand(strSql, ExternalConn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO Cashbooks ([AccountNumber],[AccountName]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
        End While
        objReader.Close()

        strSql = "SELECT [TransactionDate],[Amount],[Description],[AccountNumber],[ContraAccount],[UserName]," _
            & "[UserBranch],[Reference],[TransactionType],[Status],[PaymentMethod],[FolioReference] FROM " _
            & "CashbookTransactions WHERE TransactionDate >= '" & txtLastDate.Text & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, ExternalConn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO CashbookTransactions ([TransactionDate],[Amount],[Description]," _
                & "[AccountNumber],[ContraAccount],[UserName],[UserBranch],[Reference],[TransactionType],[Status]," _
                & "[PaymentMethod],[FolioReference]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
        End While
        objReader.Close()

        'Update the ledger transactions then

        With pb1
            .Value = 0
            .Maximum = arrData.Count + 1
            .Visible = True
            cpb1.Value = 0
            cpb1.Maximum = arrData.Count + 1
        End With

        For i As Integer = 0 To arrData.Count - 1
            If chkScriptToFile.Checked = False Then
                objCommand = New Data.OleDb.OleDbCommand(arrData.Item(i), cnn)
                objCommand.ExecuteNonQuery()
            Else
                objFile.WriteLine(arrData.Item(i))
            End If
            pb1.Value = pb1.Value + 1
            cpb1.Value = cpb1.Value + 1
        Next

        '*** UPDATE THE INVENTORY TABLE ANEW

        arrData = New ArrayList
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM InventoryItems", cnn)
        objCommand.ExecuteNonQuery()

        If chkScriptToFile.Checked = True Then
            arrData.Add("DELETE FROM InventoryItems")
        End If

        strSql = "SELECT [ItemCode],[GroupName],[Description],[SellingPrice],[CostPrice],[Location]," _
            & "[Category],[SubCategory],[Quantity],[InventoryType],[MinimumLevel],[WarningLevel]," _
            & "[IdealLevel],[TaxStatus],[BarCodeNo],[ItemColor],[Size],[UnitOfMeasure]," _
            & "[FullBarcodeSerialStatus],[Offering],[Status],[Uom],[MasterPackQty]," _
            & "[InnerPackQty],[CaseLength],[CaseWidth],[CaseHeight],[CaseWeight],[ProductLength]," _
            & "[ProductWidth],[ProductHeight],[ProductWeight],[SoUomName],[SoUomRatioStd]," _
            & "[SoUomRatio],[PoUomName],[PoUomRatioStd],[PoUomRatio],[SupplyPackaging],[SalesPackaging]," _
            & "[SupplyPackagingQuantity],[SalesPackagingQuantity],[PackItemCostPrice],[PackItemSalePrice],[CostCode] FROM InventoryItems"
        objCommand = New Data.OleDb.OleDbCommand(strSql, ExternalConn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO InventoryItems ([ItemCode],[GroupName],[Description]," _
                & "[SellingPrice],[CostPrice],[Location],[Category],[SubCategory],[Quantity],[InventoryType]," _
                & "[MinimumLevel],[WarningLevel],[IdealLevel],[TaxStatus],[BarCodeNo]," _
                & "[ItemColor],[Size],[UnitOfMeasure],[FullBarcodeSerialStatus],[Offering],[Status]," _
                & "[Uom],[MasterPackQty],[InnerPackQty],[CaseLength],[CaseWidth],[CaseHeight]," _
                & "[CaseWeight],[ProductLength],[ProductWidth],[ProductHeight],[ProductWeight]," _
                & "[SoUomName],[SoUomRatioStd],[SoUomRatio],[PoUomName],[PoUomRatioStd],[PoUomRatio]," _
                & "[SupplyPackaging],[SalesPackaging],[SupplyPackagingQuantity],[SalesPackagingQuantity]," _
                & "[PackItemCostPrice],[PackItemSalePrice],[CostCode]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If Not IsDBNull(objReader(p).ToString) Then
                    If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                        If objReader.GetFieldType(p) Is GetType(Date) Then
                            If IsDate(objReader(p).ToString) Then
                                strLine = strLine & "'" & objReader(p).ToString & "', "
                            Else
                                strLine = strLine & "" & "NULL" & ", "
                            End If
                        Else
                            Dim strFieldData As String = ""
                            If Not IsDBNull(objReader(p).ToString) Then
                                strFieldData = Replace(objReader(p), "'", "", 1)
                                Replace(objReader(p), vbCrLf, " ", 1)
                            End If
                            strLine = strLine & "'" & strFieldData & "', "
                        End If
                    Else
                        If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                            strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                        Else
                            strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                        End If
                    End If
                Else
                    strLine = strLine & "'', "
                End If
                strCurrentRecord = strLine
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
        End While
        objReader.Close()

        'Update the ledger transactions then

        With pb1
            .Value = 0
            .Maximum = arrData.Count + 1
            .Visible = True
            cpb1.Value = 0
            cpb1.Maximum = arrData.Count + 1
        End With

        For i As Integer = 0 To arrData.Count - 1
            If chkScriptToFile.Checked = False Then
                objCommand = New Data.OleDb.OleDbCommand(arrData.Item(i), cnn)
                objCommand.ExecuteNonQuery()
            Else
                objFile.WriteLine(arrData.Item(i))
            End If
            pb1.Value = pb1.Value + 1
            cpb1.Value = cpb1.Value + 1
        Next

        '*** UPDATE THE SERIAL NUMBERS TABLE

        arrData = New ArrayList

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers", cnn)
        objCommand.ExecuteNonQuery()

        If chkScriptToFile.Checked = True Then
            arrData.Add("DELETE FROM SerialNumbers")
        End If

        strSql = "SELECT [ItemCode],[SerialNumber],[BarCodeNo],[SourceSerialNo],[Availability] FROM SerialNumbers"
        objCommand = New Data.OleDb.OleDbCommand(strSql, ExternalConn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO SerialNumbers ([ItemCode],[SerialNumber],[BarCodeNo],[SourceSerialNo],[Availability]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        If objReader.GetFieldType(p) Is GetType(DBNull) Then
                            strLine = strLine & "'', "
                        Else
                            strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                        End If
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
        End While
        objReader.Close()

        'Update the ledger transactions then

        With pb1
            .Value = 0
            .Maximum = arrData.Count + 1
            .Visible = True
            cpb1.Value = 0
            cpb1.Maximum = arrData.Count + 1
        End With

        For i As Integer = 0 To arrData.Count - 1
            If chkScriptToFile.Checked = False Then
                objCommand = New Data.OleDb.OleDbCommand(arrData.Item(i), cnn)
                objCommand.ExecuteNonQuery()
            Else
                objFile.WriteLine(arrData.Item(i))
            End If
            pb1.Value = pb1.Value + 1
            cpb1.Value = cpb1.Value + 1
        Next

        '*** UPDATE THE DEBTORS INFORMATION ***

        arrData = New ArrayList

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Customers", cnn)
        objCommand.ExecuteNonQuery()

        If chkScriptToFile.Checked = True Then
            arrData.Add("DELETE FROM Customers")
        End If

        strSql = "SELECT [AccountNumber],[AccountName],[TakeOnDate],[ContactPerson],[Address1],[Address2]," _
            & "[Address3],[Address4],[FaxNumber],[PhoneNumber],[Cellphone],[EmailAddress],[VatNumber] FROM Customers"
        objCommand = New Data.OleDb.OleDbCommand(strSql, ExternalConn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strLine As String = "INSERT INTO Customers ([AccountNumber],[AccountName],[TakeOnDate],[ContactPerson],[Address1],[Address2],[Address3],[Address4],[FaxNumber],[PhoneNumber],[Cellphone],[EmailAddress],[VatNumber]) VALUES ("
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
        End While
        objReader.Close()

        'Update the ledger transactions then

        With pb1
            .Value = 0
            .Maximum = arrData.Count + 1
            .Visible = True
            cpb1.Value = 0
            cpb1.Maximum = arrData.Count + 1
        End With

        For i As Integer = 0 To arrData.Count - 1
            If chkScriptToFile.Checked = False Then
                objCommand = New Data.OleDb.OleDbCommand(arrData.Item(i), cnn)
                objCommand.ExecuteNonQuery()
            Else
                objFile.WriteLine(arrData.Item(i))
            End If
            pb1.Value = pb1.Value + 1
            cpb1.Value = cpb1.Value + 1
        Next

        'Update the pointers table
        objCommand = New Data.OleDb.OleDbCommand("UPDATE RemoteDatabasePointers SET " _
            & "LastReceipt = " & intLastReceiptNumber & ", UpdateDate = '" & strLastUpdateDate & "', " _
            & "LastInvoice = " & intLastInvoiceNumber & ", LastQuotation = " & intLastQuoteNumber & "", cnn)
        objCommand.ExecuteNonQuery()

        '*** UPDATE THE INVENTORY TABLE AS WELL


        'GET THE WHOLE INVENTORY, SERIAL NUMBERS, GENERIC BARCODES, DEBTORS INFORMATION TABLE AS WELL
        'GET THE TRANSFERS TABLE


        'we are going to update SalesMain, Sales, CustomerSalesMain, CustomerSales, QuotationsMain, Quotations
        'Cashbook and Ledger Transactions

        'Close the external database
        ExternalConn.Close()
        If chkScriptToFile.Checked = True Then objFile.Close()
        Cursor = Cursors.Default

        MessageBox.Show("The database has been synchronised successfully", "Database Synchronisation Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        If chkScriptToFile.Checked = True Then objFile.Close()
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On database synchronisation" & vbCrLf & strCurrentRecord
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadMarkers()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT LastReceipt, LastInvoice, LastQuotation, UpdateDate FROM RemoteDatabasePointers", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsDate(objReader(3).ToString) Then txtLastDate.Text = shortMonthDateFormat(CDate(objReader(3).ToString))
            If IsNumeric(objReader(0).ToString) Then txtLastReceipt.Text = objReader(0).ToString Else txtLastReceipt.Text = "0"
            If IsNumeric(objReader(1).ToString) Then txtLastInvoice.Text = objReader(1).ToString Else txtLastInvoice.Text = "0"
            If IsNumeric(objReader(2).ToString) Then txtLastQuotation.Text = objReader(2).ToString Else txtLastQuotation.Text = "0"
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On database synchronisation details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSettings_Click(sender As System.Object, e As System.EventArgs) Handles btnSettings.Click
        Dim frm As New frmDatabaseSynchronizationPointers
        frm.ShowDialog()
        LoadMarkers()
    End Sub

End Class
