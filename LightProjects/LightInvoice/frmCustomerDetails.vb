Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons

Public Class frmCustomerDetails


    Dim intNextInvoiceNumber As Double
    Dim arrData As ArrayList
    Dim boolLastRecord As Boolean
    Dim boolPrintFromPreview As Boolean
    Dim boolNoDetails As Boolean

    Dim boolEndPrint As Boolean
    Dim boolExitingWhile As Boolean = False
    Dim boolStartingPrint As Boolean

    Dim cmdStatements As Data.OleDb.OleDbCommand
    Dim dblCummulativeStatementBalance As Double
    Dim drCustomerDetails As Data.OleDb.OleDbDataReader
    Dim drStatements As Data.OleDb.OleDbDataReader
    Dim strStatementArray As ArrayList

    Dim strCustomerAddress As String
    Dim strCustomerName As String
    Dim strCustomerFaxNumber As String
    Dim strCustomerTelephone As String
    Dim intPage As Single = 1
    Dim intPageTotals As Double = 1
    Dim dblBalance As Double

    Dim strvalue As String
    Dim itm As Double
    Dim arrCount As Double = 0
    Dim intLineCount As Double = 0

    Dim prFont As New Font("Arial", 6, FontStyle.Bold)
    Dim tlFont As New Font("Arial", 6, FontStyle.Regular)
    Dim HeaderFont As New Font("Arial", 10, FontStyle.Bold)
    Dim Count As Double = 0

    Private PrintFont As Font 'Class level variable
    Private VariableToPrint As String 'Class level variable representing the data to print
    Dim boolInProcessMode As Boolean

    Private Sub frmCustomerDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadAgingParameters()
        If boolEditStatus = True Then
            CommonLibrary.Commons.strSelectedAccount = strSelectedAccount
            LoadIdentityData()
            LoadData()
            LoadTerms()
            GetBalance()
            GetLastPayment()
            LoadEmploymentData()
            LoadTransactions()
            LoadInvoices(strSelectedAccount)
            LoadReferenceData()
            LoadIndividualData()
            btnManageTransactions.Enabled = True
            btnPrint.Enabled = True
            btnSaveNew.Enabled = False 'ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
            If cboPurpose.Text <> "LOAN" Then
                btnNewItems.Enabled = True 'ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
            Else
                btnNewItems.Enabled = False
            End If
            Me.Text = Me.Text & " : " & txtAccountName.Text
        Else

            txtAccountName.Text = strSelectedAccountName
            txtAccountNumber.Text = strSelectedAccount
            txtAddress1.Text = strPublicDeliverAddress1
            txtAddress2.Text = strPublicDeliverAddress2
            txtAddress3.Text = strPublicDeliverAddress3
            txtAddress4.Text = strPublicDeliverAddress4

            btnManageTransactions.Enabled = False
            btnPrint.Enabled = False
            btnSaveNew.Enabled = True 'ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
            btnNewItems.Enabled = False 'ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
            AutoNumberIncreament()
        End If
    End Sub

    Private Sub LoadTerms()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Terms FROM CustomerTerms WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtNotes.Text = objReader(0).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Terms and Condictions Save"
        ShowErrorMessage()
    End Sub

    Private Sub frmCustomerDetails_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState <> FormWindowState.Minimized Then
            '766, 534
            Me.Height = 534
            Me.Width = 766
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        boolInProcessMode = False
        SaveCustomerRecord()
        MessageBox.Show("Customer details saved successfully", "Saved Details Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub SaveCustomerRecord()

        boolAbort = False

        If String.IsNullOrEmpty(txtAccountNo.Text) Then
            MessageBox.Show("Please enter the account details first", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtAccountNo.Focus()
            boolAbort = True
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAccountName.Text) Then
            MessageBox.Show("Please enter the account details first", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtAccountName.Focus()
            boolAbort = True
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the account details first", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtAddress1.Focus()
            boolAbort = True
            Exit Sub
        End If

        If Not IsNumeric(txtTakeOnBalance.Text) Then txtTakeOnBalance.Text = "0.00"

        If String.IsNullOrEmpty(cboPurpose.Text) Then
            cboPurpose.Text = "TRADING"
        End If

        boolAbort = False
        SaveAccountDetails()
        If boolAbort = True Then Exit Sub
        SaveTerms()
        If boolAbort = True Then Exit Sub
        If UCase(cboCustomerType.Text) = "INDIVIDUAL" Then
            SaveIndividualData()
        End If
        If boolAbort = True Then Exit Sub
        'If still in the process of saving other details then exit here
        If boolInProcessMode = True Then
            txtAccountNo.Enabled = False
            boolEditStatus = True
            strSelectedAccount = txtAccountNo.Text
            Exit Sub
        End If

    End Sub

    Private Sub LoadIdentityData()
        On Error GoTo RaiseErr
        txtAccountNo.Enabled = False
        Me.Text = Me.Text & ": " & UCase(strSelectedAccount)
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName, " _
            & "TakeOnDate, Address1, Address2, Address3, Address4, ContactPerson, PhoneNumber, " _
            & "FaxNumber, Cellphone, EmailAddress, VatNumber, CustomerType, BPNumber, PaymentType, " _
            & "PaymentDueIn FROM Customers WHERE " _
            & "AccountNumber = '" & strSelectedAccount & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("AccountNumber").ToString) Then txtAccountNo.Text = objReader("AccountNumber").ToString
            If Not IsDBNull(objReader("AccountName").ToString) Then txtAccountName.Text = objReader("AccountName").ToString
            If IsDate(objReader("TakeOnDate").ToString) Then dpDateOn.Value = CDate(objReader("TakeOnDate").ToString)
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("ContactPerson").ToString) Then txtContactPerson.Text = objReader("ContactPerson").ToString
            If Not IsDBNull(objReader("PhoneNumber").ToString) Then txtTelephone.Text = objReader("PhoneNumber").ToString
            If Not IsDBNull(objReader("FaxNumber").ToString) Then txtFaxNumber.Text = objReader("FaxNumber").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("VatNumber").ToString) Then txtVatNumber.Text = objReader("VatNumber").ToString
            If Not IsDBNull(objReader("CustomerType").ToString) Then cboPurpose.Text = objReader("CustomerType").ToString
            If Not IsDBNull(objReader("BPNumber").ToString) Then txtBpNumber.Text = objReader("BPNumber").ToString

            If Not IsDBNull(objReader("PaymentType").ToString) Then cboPaymentType.Text = objReader("PaymentType").ToString
            If Not IsDBNull(objReader("PaymentDueIn").ToString) Then txtPaymentDueDays.Text = objReader("PaymentDueIn").ToString
        End If
        objReader.Close()
        'Get the opening balance
        objCommand = New Data.OleDb.OleDbCommand("SELECT SalesPrice FROM CustomerSales WHERE Description = 'TAKE-ON BALANCE' " _
            & "AND CustomerId = '" & txtAccountNo.Text & "'", cnn)
        Dim objReadTakeon As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        If objReadTakeon.HasRows Then
            objReadTakeon.Read()
            If IsNumeric(objReadTakeon(0).ToString) Then
                txtTakeOnBalance.Text = CStr(Format(CDbl(objReadTakeon(0).ToString), "##0.00"))
            End If
        End If
        objReadTakeon.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub SaveAccountDetails()
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        If Not IsNumeric(txtPaymentDueDays.Text) Then
            txtPaymentDueDays.Text = "0"
        End If
        If boolEditStatus = False Then
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO Customers (AccountNumber, AccountName, " _
                & "TakeOnDate, Address1, Address2, Address3, Address4, ContactPerson, PhoneNumber, " _
                & "FaxNumber, Cellphone, EmailAddress, VatNumber, CustomerType, BPNumber, " _
                & "PaymentType, PaymentDueIn) VALUES ('" & txtAccountNo.Text & "', " _
                & "'" & txtAccountName.Text & "', '" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', " _
                & "'" & txtAddress1.Text & "', '" & txtAddress2.Text & "', '" & txtAddress3.Text & "', " _
                & "'" & txtAddress4.Text & "', '" & txtContactPerson.Text & "', '" & txtTelephone.Text & "', " _
                & "'" & txtFaxNumber.Text & "', '" & txtCellphone.Text & "', '" & txtEmailAddress.Text & "', " _
                & "'" & txtVatNumber.Text & "', '" & cboPurpose.Text & "', '" & txtBpNumber.Text & "', " _
                & "'" & cboPaymentType.Text & "', " & CInt(txtPaymentDueDays.Text) & ")", cnn)
        Else
            objCommand = New Data.OleDb.OleDbCommand("UPDATE Customers SET AccountName = '" & txtAccountName.Text & "', " _
                & "TakeOnDate = '" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', Address1 = '" & txtAddress1.Text & "', " _
                & "Address2 = '" & txtAddress2.Text & "', Address3 = '" & txtAddress3.Text & "', " _
                & "Address4 = '" & txtAddress4.Text & "', ContactPerson = '" & txtContactPerson.Text & "', " _
                & "PhoneNumber = '" & txtTelephone.Text & "', FaxNumber = '" & txtFaxNumber.Text & "', " _
                & "Cellphone = '" & txtCellphone.Text & "', EmailAddress = '" & txtEmailAddress.Text & "', " _
                & "VatNumber = '" & txtVatNumber.Text & "', BPNumber = '" & txtBpNumber.Text & "', " _
                & "CustomerType = '" & cboPurpose.Text & "', PaymentType = '" & cboPaymentType.Text & "', " _
                & "PaymentDueIn = " & CInt(txtPaymentDueDays.Text) & " " _
                & "WHERE AccountNumber = '" & txtAccountNo.Text & "'", cnn)
        End If
        objCommand.ExecuteNonQuery()

        If IsNumeric(txtTakeOnBalance.Text) Then
            If CDbl(txtTakeOnBalance.Text) <> 0 Then

                'INSERT THE TAKE ON BALANCE
                objCommand = New Data.OleDb.OleDbCommand("SELECT InvoiceNumber FROM CustomerSales WHERE Description = 'TAKE-ON BALANCE' " _
                    & "AND CustomerId = '" & txtAccountNo.Text & "'", cnn)
                Dim objReadTakeon As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
                If objReadTakeon.HasRows Then
                    objReadTakeon.Read()
                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSales WHERE InvoiceNumber = " & CDbl(objReadTakeon(0).ToString) & " " _
                        & "AND CustomerId = '" & txtAccountNo.Text & "'", cnn)
                    objCommand.ExecuteNonQuery()
                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSalesMain WHERE InvoiceNumber = " & CDbl(objReadTakeon(0).ToString) & " " _
                        & "AND CustomerId = '" & txtAccountNo.Text & "'", cnn)
                    objCommand.ExecuteNonQuery()
                End If

                intNextInvoiceNumber = CDbl(gwt_comm.GetNextDocumentNumber("Invoices"))

                'intNextInvoiceNumber = 1050
                Dim strSql As String = "INSERT INTO CustomerSales ([InvoiceNumber],[CustomerId],[ItemCode],[Description],[Quantity],[DiscountAllowed]" _
                   & ", [Taxes], [TransType], [SalesPrice], [TransDate], [ProductType], [SerialNumbers]" _
                   & ",[OriginalInvoice],[SalesRep],[UserName],[OrderNumber]) VALUES (" & intNextInvoiceNumber & ", '" & txtAccountNo.Text & "', " _
                   & "'00000', 'TAKE-ON BALANCE', 1, 0, 0, 'INVOICE', " & CDbl(txtTakeOnBalance.Text) & ", '" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', " _
                   & "'GENERIC', '', 0,'NONE', '" & strUserName & "', '')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                strSql = "INSERT INTO CustomerSalesMain ([InvoiceNumber],[CustomerId],[Status],[Amount],[Taxes],[Discount],[TransDate]," _
                    & "[OriginalInvoice],[SalesRep],[UserName],[OrderNumber]) VALUES (" & intNextInvoiceNumber & ", '" & txtAccountNo.Text & "', " _
                    & "'', " & CDbl(txtTakeOnBalance.Text) & ", 0,0, '" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', 0, '', '" & strUserName & "', " _
                    & "'')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                'Update the invoice numbers
                objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET Invoices = " & intNextInvoiceNumber & "", cnn)
                objCommand.ExecuteNonQuery()
            End If
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Details Save"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, TransactionDate, 105) AS [Date], ReferenceNumber, " _
            & "Description, CAST(Amount AS DECIMAL (10,2)) AS [Amt], TransactionType FROM " _
            & "CustomerTransactions WHERE AccountNumber = '" & strSelectedAccount & "' ORDER BY TransactionDate, ReferenceNumber"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim dblMovingBalance As Double = 0
        While objReader.Read
            With dGrid
                .Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then
                    If UCase(objReader(4).ToString) = "INVOICE" Then
                        .Rows(.Rows.Count - 1).Cells(3).Value = Format(CDbl(objReader(3).ToString), "##0.00")
                        dblMovingBalance = dblMovingBalance + CDbl(objReader(3).ToString)
                    Else
                        dblMovingBalance = dblMovingBalance - CDbl(objReader(3).ToString)
                        .Rows(.Rows.Count - 1).Cells(3).Value = Format(CDbl(objReader(3).ToString), "##0.00")
                    End If
                End If
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Transactions Load"
        ShowErrorMessage()
    End Sub

    Private Sub GetBalance()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CAST(Amount AS DECIMAL (10,2)) AS [Amt], TransactionType FROM " _
            & "CustomerTransactions WHERE AccountNumber = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim dblMovingBalance As Double = 0
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(objReader(1).ToString) = "INVOICE" Then
                    dblMovingBalance = dblMovingBalance + CDbl(objReader(0).ToString)
                Else
                    dblMovingBalance = dblMovingBalance - CDbl(objReader(0).ToString)
                End If
            End If
        End While
        objReader.Close()
        lblCurrentBalance.Text = Format(dblMovingBalance, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Balance Computation"
        ShowErrorMessage()
    End Sub

    Private Sub GetLastPayment()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CAST(Amount AS DECIMAL (10,2)) AS [Amt], TransactionDate FROM " _
            & "CustomerTransactions WHERE AccountNumber = '" & strSelectedAccount & "' AND " _
            & "TransactionType = 'PAYMENT' ORDER BY TransactionDate DESC"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If IsNumeric(objReader(0).ToString) Then
                    lblAmtPaid.Text = Format(CDbl(objReader(0).ToString), "#,##0.00")
                End If
            End If
            If Not IsDBNull(objReader(1).ToString) Then
                If IsDate(objReader(1).ToString) Then
                    lblPaymentDate.Text = UCase(Format(CDate(objReader(1).ToString), "dd-MMM-yyyy"))
                End If
            End If
        End If
        objReader.Close()
        'Get the Year to date sales
        strSql = "SELECT SUM(Amount) FROM CustomerTransactions WHERE AccountNumber = '" & strSelectedAccount & "' " _
            & "AND TransactionType = 'INVOICE'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                lblYearToDate.Text = Format(CDbl(objReader(0).ToString), "#,##0.00")
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Last Payment Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadTransactions()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        'rescue 
        strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "ReferenceNumber AS [Ref. #], Description, CAST(Amount AS DECIMAL (10,2)) AS [Amount], " _
            & "TransactionType AS [TYPE] FROM CustomerTransactions " _
            & "WHERE AccountNumber = '" & strSelectedAccount & "' ORDER BY TransactionDate "

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim strLastPaymentAmount As String = "0.00"
        Dim strLastPaymentDate As String = Nothing

        Dim dblDebitTotal As Double = 0
        Dim dblCreditTotal As Double = 0
        Dim dblBalance As Double = 0
        dGrid.Rows.Clear()

        While objReader.Read

            Dim strEntryDate As String = Nothing
            Dim strEntryReference As String = Nothing
            Dim strEntryDescription As String = Nothing
            Dim strDebitEntry As String = "0.00"
            Dim strCreditEntry As String = "0.00"
            Dim strEntryType As String = Nothing

            If Not IsDBNull(objReader(0).ToString) Then strEntryDate = UCase(objReader(0).ToString)
            If Not IsDBNull(objReader(1).ToString) Then strEntryReference = UCase(objReader(1).ToString)
            If Not IsDBNull(objReader(2).ToString) Then strEntryDescription = UCase(objReader(2).ToString)
            If IsNumeric(objReader(3).ToString) Then
                If CDbl(objReader(3).ToString) >= 0 Then
                    dblDebitTotal = dblDebitTotal + CDbl(objReader(3).ToString)
                    strDebitEntry = Format(CDbl(objReader(3).ToString), "#,##0.00")
                Else
                    dblCreditTotal = dblCreditTotal + (0 - CDbl(objReader(3).ToString))
                    strCreditEntry = Format((0 - CDbl(objReader(3).ToString)), "#,##0.00")
                End If
            End If
            If Not IsDBNull(objReader(4).ToString) Then strEntryType = UCase(objReader(4).ToString)

            'Get the last payment details here. Never mind the constant override
            If UCase(strEntryType) = "PAYMENT" Then
                strLastPaymentDate = strEntryDate
                strLastPaymentAmount = CStr(Format((0 - CDbl(objReader(3).ToString)), "#,##0.00"))
            End If

            'Add the details to the grid
            dGrid.Rows.Add(strEntryDate, strEntryReference, strEntryDescription, strDebitEntry, strCreditEntry, strEntryType)

        End While
        objReader.Close()

        'Update summary values

        dblBalance = dblDebitTotal - dblCreditTotal
        lblCurrentBalance.Text = CStr(Format(dblBalance, "#,##0.00"))
        lblYearToDate.Text = Format(dblDebitTotal, "#,##0.00")
        lblPaymentDate.Text = strLastPaymentDate
        lblAmtPaid.Text = strLastPaymentAmount

        'Add the totals and balance line

        dGrid.Rows.Add("", "", "TOTALS", CStr(Format(dblDebitTotal, "#,##0.00")), CStr(Format(dblCreditTotal, "#,##0.00")), "")
        dGrid.Rows.Add("", "", "BALANCE", CStr(Format(dblBalance, "#,##0.00")), "", "")

        'Adjust the grid
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Transactions Load"
        ShowErrorMessage()
    End Sub

    Private Sub SaveTerms()
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(txtNotes.Text) Then
            Dim objcommand As New Data.OleDb.OleDbCommand("DELETE FROM CustomerTerms WHERE AccountNumber = '" & txtAccountNo.Text & "'", cnn)
            objcommand.ExecuteNonQuery()
            objcommand = New Data.OleDb.OleDbCommand("INSERT INTO CustomerTerms (AccountNumber, Terms) VALUES " _
                & "('" & txtAccountNo.Text & "', '" & txtNotes.Text & "')", cnn)
            objcommand.ExecuteNonQuery()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Terms and Condictions Save"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub txtTakeOnBalance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTakeOnBalance.KeyPress
        If Asc(e.KeyChar) = 13 Then Exit Sub
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub PrintActiveCustomerStatement()
        boolExitingWhile = False
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim dbReader As Data.OleDb.OleDbDataReader
        intPage = 1
        On Error GoTo RaiseErr

        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
        If boolStartingPrint = True Then
            'Create temp table and get the balance at end
            dblCummulativeStatementBalance = gwt_comm.CustomerTempTable(strSelectedAccount, CDate(Format(StartDate, "dd-MMM-yyyy")))
            boolStartingPrint = False
        End If

        'Now select the record from the temp table
        cmdStatements = New Data.OleDb.OleDbCommand("SELECT * FROM TempStatements WHERE CustomerId = '" & strSelectedAccount & "' " _
            & "AND tDate Between '" & Format(StartDate, "dd-MMM-yyyy") & "' AND '" & Format(EndDate, "dd-MMM-yyyy") & "' ORDER BY tDate, Reference", cnn)
        drStatements = cmdStatements.ExecuteReader()
        strStatementArray = New ArrayList
        Dim i As Integer = 0
        While drStatements.Read
            Dim strLine As String = Nothing
            For i = 0 To drStatements.FieldCount - 1
                If i = 0 Then strLine = drStatements(i).ToString Else strLine = strLine & "|" & drStatements(i).ToString
            Next
            strStatementArray.Add(strLine)
        End While
        'Get the number of pages to be printed by dividing by the maximum
        intPageTotals = Math.Round((strStatementArray.Count / 23), 0)
        If intPageTotals = 0 Then intPageTotals = 1
        'Print the details
        If strStatementArray.Count <= 0 Then
            boolNoDetails = True
            Exit Sub
        Else
            boolNoDetails = False
            myCommand = New Data.OleDb.OleDbCommand("Select * FROM Customers Where AccountNumber = '" & strSelectedAccount & "'", cnn)
            drCustomerDetails = myCommand.ExecuteReader
            'Assign the details to common variables
            While drCustomerDetails.Read
                If Not IsDBNull(drCustomerDetails("AccountName").ToString) Then strCustomerName = drCustomerDetails("AccountName").ToString Else strCustomerName = ""
                If Not IsDBNull(drCustomerDetails("FaxNumber").ToString) Then strCustomerFaxNumber = drCustomerDetails("FaxNumber").ToString Else strCustomerFaxNumber = ""

                If Not IsDBNull(drCustomerDetails("Address1").ToString) Then
                    strCustomerAddress = drCustomerDetails("Address1").ToString & vbCrLf
                Else
                    strCustomerAddress = "" & vbCrLf
                End If
                If Not IsDBNull(drCustomerDetails("Address2").ToString) Then
                    strCustomerAddress = strCustomerAddress & drCustomerDetails("Address2").ToString & vbCrLf
                Else
                    strCustomerAddress = strCustomerAddress & "" & vbCrLf
                End If
                If Not IsDBNull(drCustomerDetails("Address3").ToString) Then
                    strCustomerAddress = strCustomerAddress & drCustomerDetails("Address3").ToString & vbCrLf
                Else
                    strCustomerAddress = strCustomerAddress & "" & vbCrLf
                End If
                If Not IsDBNull(drCustomerDetails("Address4").ToString) Then
                    strCustomerAddress = strCustomerAddress & drCustomerDetails("Address4").ToString & vbCrLf
                Else
                    strCustomerAddress = strCustomerAddress & "" & vbCrLf
                End If

                If Not IsDBNull(drCustomerDetails("PhoneNumber").ToString) Then strCustomerTelephone = drCustomerDetails("PhoneNumber").ToString Else strCustomerTelephone = ""
            End While
            drCustomerDetails.Close()

        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Statement Generation Failure"
        ShowErrorMessage()
    End Sub

    Private Sub FillArrayData()
        On Error GoTo RaiseErr
        Dim myCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT AccountNumber FROM Customers " _
            & "WHERE AccountNumber = '" & strSelectedAccount & "' ORDER BY AccountNumber", cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
        arrData = New ArrayList
        While dbReader.Read
            If Not IsDBNull(dbReader(0).ToString) Then arrData.Add(dbReader(0).ToString)
        End While
        dbReader.Close()
        'Get only statements with transactions
        Dim arrNewList As New ArrayList
        Dim n As Double = 0
        For n = 0 To arrData.Count - 1
            strPublicCustomerId = arrData(n)
            PrintActiveCustomerStatement()
            If boolNoDetails = False Then arrNewList.Add(arrData(n))
        Next
        arrData = New ArrayList
        For n = 0 To arrNewList.Count - 1
            arrData.Add(arrNewList(n))
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Statement Print Error"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        boolAbort = False
        boolExitingWhile = False
        'Get the date to print from
        gwt_comm.DateRangeSpecification()
        If boolAbort = True Then Exit Sub
        'Loop through the customers and print their statements
        boolLastRecord = False
        boolStartingPrint = True
        If boolAbort = True Then Exit Sub
        FillArrayData()
        If boolAbort = True Then Exit Sub
        'Drop the statements table and assign the values to an array list
        'RefreshDbConnection()

        Dim p As New PrintPreviewDialog
        p.Document = Me.pdStatement
        p.ShowDialog()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Customer Statements Print Failure"
        ShowErrorMessage()
    End Sub

    Private Sub pdStatement_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdStatement.PrintPage
        If boolPrintFromPreview = True Then
            'requery records
            Me.PrintActiveCustomerStatement()
            boolPrintFromPreview = False
        End If
        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer
        'Dim xx1 AS DOUBLE, xx2 AS DOUBLE, yy1 AS DOUBLE, yy2 AS DOUBLE
        x1 = e.PageBounds.Left + 100
        y1 = e.PageBounds.Top + 100
        p1 = e.PageBounds.Width - 200
        y2 = e.PageBounds.Height - 170

        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        Dim strS As String = Nothing
        Dim Yc As Double
        Dim cols, lines As Double
        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions

        boolExitingWhile = False

        'print the company logo
        'R = New Rectangle(x1, (y1 - 100), 200, 100)
        'e.Graphics.DrawImage(picPrint.Image, R)
        'y1 = y1 + 20

        '************************************************************************
        'Begin the stringing of the statements here
        While arrCount < arrData.Count
            itm = 0
            'Get the current customer data
            CommonLibrary.Commons.strPublicCustomerId = arrData(arrCount)
            PrintActiveCustomerStatement()
            intPage = 1
            'If there are no record to print skip this process

            If boolNoDetails = False Then
                'print logo
                'print the company logo
                If Not String.IsNullOrEmpty(CommonLibrary.Commons.strLogoPath) Then
                    If System.IO.File.Exists(CommonLibrary.Commons.strLogoPath) Then
                        'Dont print the company name in that case as it is taken up by the logo
                        strCompanyName = ""
                        Dim R As Drawing.Rectangle
                        Dim objPicture As New Windows.Forms.PictureBox
                        objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                        objPicture.Load(CommonLibrary.Commons.strLogoPath)
                        Dim intImageYLocation As Double = objPicture.Height
                        intImageYLocation = (100 - intImageYLocation) / 2
                        R = New Rectangle(CommonLibrary.Commons.intLogoXposition, CommonLibrary.Commons.intLogoYposition, objPicture.Width, objPicture.Height)
                        e.Graphics.DrawImage(objPicture.Image, R)
                    End If
                End If
                'Draw the document rectangle
                reccurrent = New Rectangle(x1, y1, p1, y2)
                e.Graphics.DrawRectangle(Pens.Black, reccurrent)
                y1 = e.PageBounds.Top + 120
                'Print the company details at the extreme left of document
                Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, HeaderFont, Brushes.Black)
                e.Graphics.DrawString("CUSTOMER STATEMENT", HeaderFont, Brushes.Black, 500, e.PageBounds.Top + 120)
                y1 = y1 + 20
                Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, CommonLibrary.Commons.strCompanyAddressFull, tlFont, Brushes.Black)
                'Get the size of the address box
                e.Graphics.MeasureString(CommonLibrary.Commons.strCompanyAddressFull, tlFont, New SizeF(200, 80), New StringFormat(), cols, lines)
                Yc = y1
                y1 = y1 + lines * tlFont.Height + 5
                y1 = Math.Max(y1, Yc)
                'Call gwtCom.DrawStringInBoxLeft(e, 110, y1, 500, 80, "Tel : " & strCompanyTelephone & " Fax : " & strCompanyFaxNumber & " Email : " & strCompanyEmailAddress, tlFont, Brushes.Black)
                'Get the size of the address box
                e.Graphics.MeasureString(CommonLibrary.Commons.strCompanyTelephone, tlFont, New SizeF(500, 80), New StringFormat(), cols, lines)
                Yc = y1
                y1 = y1 + lines * tlFont.Height + 5
                y1 = Math.Max(y1, Yc)
                Call gwt_comm.DrawStringInBoxLeft(e, 550, y1 - 18, 250, 80, "Vat Number : " & CommonLibrary.Commons.strCompanyVatNumber, tlFont, Brushes.Black)
                'Print the bank details
                If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyBankName) Then
                    Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 600, 80, "BANK = " & UCase(CommonLibrary.Commons.strCompanyBankName) &
                        ": BRANCH CODE = " & UCase(CommonLibrary.Commons.strCompanyBranchCode) & ": ACC. NO = " &
                        CommonLibrary.Commons.strCompanyAccountNumber, tlFont, Brushes.Black)
                    y1 += 20
                End If
                'print captions
                x1 = x1 + 10
                x2 = x1 + 110
                X3 = x2 + 100
                X4 = X3 + 100
                X5 = X4 + 100
                X6 = X5 + 80

                e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
                y1 = y1 + 20
                e.Graphics.DrawString("CUSTOMER DETAILS", prFont, Brushes.Black, x1, y1)
                e.Graphics.DrawString("STATEMENT DETAILS", prFont, Brushes.Black, 500, y1)
                y1 = y1 + 20
                e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
                y1 = y1 + 30
                'Read the customer details
                'drCustomerDetails.Read()
                'Continue and print the customer details
                e.Graphics.DrawString(strCustomerName, tlFont, Brushes.Black, x1, y1)
                e.Graphics.DrawString("STATEMENT DATE : " & Format(Now, "dd-MMM-yyyy"), tlFont, Brushes.Black, 450, y1)
                y1 = y1 + 25
                'e.Graphics.DrawString(strCustomerAddress, tlFont, Brushes.Black, x1, y1)
                Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress, tlFont, Brushes.Black)
                'Get the size of the address box
                e.Graphics.MeasureString(strCustomerAddress, tlFont, New SizeF(200, 80), New StringFormat(), cols, lines)
                Yc = y1
                y1 = y1 + lines * tlFont.Height + 5
                y1 = Math.Max(y1, Yc)
                'y1 = y1 + 50
                e.Graphics.DrawString("PHONE :" & strCustomerTelephone, tlFont, Brushes.Black, x1, y1) ' & " FAX : " & strCustomerFaxNumber, tlFont, Brushes.Black, x1, y1)
                'y1 = y1 + 25
                e.Graphics.DrawString("PERIOD COVERED : " & Format(StartDate, "dd-MMM-yyyy") & " TO " & Format(EndDate, "dd-MMM-yyyy"), tlFont, Brushes.Black, 450, y1)
                y1 = y1 + 75
                e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
                y1 = y1 + 20
                'print captions
                Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 100, 80, "DATE", prFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 120, 80, "REFERENCE", prFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, X3, y1, 180, 80, "DESCRIPTION", prFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 120, 80, "DEBIT", prFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, "CREDIT", prFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, "BALANCE", prFont, Brushes.Black)
                'draw a line after
                y1 = y1 + 30
                e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
                y1 = y1 + 30
                'itm = 0
                reccurrent = New Rectangle()
                If boolExitingWhile = False Then dblBalance = 0
                'Print the cummulative balance first
                Call gwt_comm.DrawStringInBoxLeft(e, X3, y1, 180, 80, "Balance b/d", prFont, Brushes.Black)
                'If printing to the next page then you take the balance from the previous page
                If boolExitingWhile = False Then
                    Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, Format(dblCummulativeStatementBalance, "#,##0.00"), prFont, Brushes.Black)
                Else
                    Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, Format(dblBalance, "#,##0.00"), prFont, Brushes.Black)
                End If
                y1 = y1 + 30
                If boolExitingWhile = False Then dblBalance = dblCummulativeStatementBalance
                boolExitingWhile = False
                While itm < strStatementArray.Count
                    Dim strbuffer() As String
                    strbuffer = Split(strStatementArray(itm), "|")
                    If Not strbuffer(0) Is Nothing Then strvalue = CStr(Format(CDate(strbuffer(0)), "dd-MMM-yyyy")) Else strvalue = ""
                    Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 120, 80, strvalue, tlFont, Brushes.Black)
                    If Not strbuffer(1) Is Nothing Then strvalue = strbuffer(1) Else strvalue = ""
                    Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 120, 80, strvalue, tlFont, Brushes.Black)
                    If Not strbuffer(5) Is Nothing Then strvalue = strbuffer(5) Else strvalue = ""
                    Call gwt_comm.DrawStringInBoxLeft(e, X3, y1, 180, 80, strvalue, tlFont, Brushes.Black)
                    If Not strbuffer(3) Is Nothing Then strvalue = CStr(Format(CDbl(strbuffer(3)), "#,##0.00")) Else strvalue = "0.00"
                    Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 120, 80, strvalue, tlFont, Brushes.Black)
                    If Not strbuffer(4) Is Nothing Then strvalue = CStr(Format(CDbl(strbuffer(4)), "#,##0.00")) Else strvalue = "0.00"
                    Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, strvalue, tlFont, Brushes.Black)
                    dblBalance = dblBalance + CDbl(strbuffer(3)) - CDbl(strbuffer(4))
                    strvalue = CStr(Format(dblBalance, "#,##0.00"))
                    Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, strvalue, tlFont, Brushes.Black)
                    'print invoice total
                    y1 = y1 + 20
                    itm = itm + 1 'i = 0
                    intLineCount = intLineCount + 1
                    If intLineCount = 20 Then
                        'Print the page number of the statement
                        Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage & " of " & intPageTotals, tlFont, Brushes.Black)
                        Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", prFont, Brushes.Black)
                        intLineCount = 0
                        e.HasMorePages = True
                        boolExitingWhile = True
                        intPage += 1
                        Exit While
                    End If
                End While
            End If
            arrCount += 1
            e.HasMorePages = True
            boolExitingWhile = True
            Exit While
        End While
        If boolExitingWhile = False Then
            'Print the last page number of the statement
            'Call gwtCom.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage & " of " & intPageTotals, tlFont)
            'Call gwtCom.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", prFont)
            e.HasMorePages = False
            boolPrintFromPreview = True
            arrCount = 0
        End If
    End Sub

    Private Sub AutoNumberIncreament()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber FROM Customers ORDER BY AccountNumber DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    If IsNumeric(objReader(0).ToString) Then
                        txtAccountNo.Text = CDbl(objReader(0).ToString) + 1
                    Else
                        If objReader(0).ToString.Length >= 4 Then
                            Dim strLastNumber As String = Mid(objReader(0).ToString, (objReader(0).ToString.Length - 4), 4)
                            If IsNumeric(strLastNumber) Then
                                txtAccountNo.Text = Mid(objReader(0).ToString, 1, (objReader(0).ToString.Length - 4)) & Format((CLng(strLastNumber) + 1), "0000")
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Customers Auto Increament Failure"
        ShowErrorMessage()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If String.IsNullOrEmpty(txtAccountNo.Text) Then
            MessageBox.Show("Please enter the account details first", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtAccountNo.Focus()
            Exit Sub
        End If
        boolInProcessMode = True
        SaveCustomerRecord()
        If boolAbort = True Then Exit Sub
        boolEditStatusTwo = False
        Dim f As New frmPastEmployers
        f.ShowDialog()
        boolInProcessMode = False
        LoadEmploymentData()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If String.IsNullOrEmpty(txtAccountNo.Text) Then
            MessageBox.Show("Please enter the account details first", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtAccountNo.Focus()
            Exit Sub
        End If
        boolInProcessMode = True
        SaveCustomerRecord()
        If boolAbort = True Then Exit Sub
        boolEditStatusTwo = True
        intSelectedTransaction = CInt(dGridEmployment.CurrentRow.Cells(0).Value.ToString)
        Dim f As New frmPastEmployers
        f.ShowDialog()
        boolInProcessMode = False
        LoadEmploymentData()
    End Sub

    Private Sub LoadEmploymentData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM EmployeeEmploymentHistory WHERE EmployeeNo = '" & strPublicEmployeeId & "' ORDER BY Status DESC"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim n As Double = 0
        dGridEmployment.Rows.Clear()
        While objReader.Read
            With dGridEmployment
                .Rows.Add(1)
                If Not IsDBNull(objReader("TransactionId").ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader("TransactionId").ToString
                If Not IsDBNull(objReader("Employer").ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader("Employer").ToString
                If Not IsDBNull(objReader("JobTitle").ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader("JobTitle").ToString
                If IsDate(objReader("DateFrom").ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = Format(CDate(objReader("DateFrom").ToString), "dd-MM-yyyy")
                If IsDate(objReader("DateTo").ToString) Then .Rows(.Rows.Count - 1).Cells(4).Value = Format(CDate(objReader("DateTo").ToString), "dd-MM-yyyy")
                If IsNumeric(objReader("AverageSalary").ToString) Then .Rows(.Rows.Count - 1).Cells(5).Value = Format(CDbl(objReader("AverageSalary").ToString), "#,##0.00")
            End With
        End While
        AlternateColors(dGridEmployment)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employment history details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadReferenceData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM EmploymentHistory WHERE AccountNumber = '" & strSelectedAccount & "' ORDER BY Status DESC"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim n As Double = 0
        While objReader.Read
            With dGridReferences
                .Rows.Add(1)
                If Not IsDBNull(objReader("TransactionId").ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader("TransactionId").ToString
                If Not IsDBNull(objReader("JobTitle").ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader("JobTitle").ToString
                If Not IsDBNull(objReader("DateFrom").ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader("DateFrom").ToString
                If Not IsDBNull(objReader("DateTo").ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader("DateTo").ToString
                If Not IsDBNull(objReader("AverageSalary").ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader("AverageSalary").ToString
            End With
        End While
        AlternateColors(dGridReferences)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Customers Employment Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub AlternateColors(ByVal myGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView)
        With myGrid
            For i As Integer = 0 To .Rows.Count - 1 Step 2
                For j As Integer = 0 To .Columns.Count - 1
                    Dim foreColor As Color = Color.Black
                    Dim backColor As Color = Color.WhiteSmoke
                    .Rows(i).Cells(j).Style.BackColor = backColor
                    .Rows(i).Cells(j).Style.ForeColor = foreColor
                Next j
            Next i
        End With
        'With dGridEmployment
        '    For i As Integer = 0 To .Rows.Count - 1 Step 2
        '        For j As Integer = 0 To .Columns.Count - 1
        '            Dim foreColor As Color = Color.Black
        '            Dim backColor As Color = Color.WhiteSmoke
        '            .Rows(i).Cells(j).Style.BackColor = backColor
        '            .Rows(i).Cells(j).Style.ForeColor = foreColor
        '        Next j
        '    Next i
        'End With
        'With dGridReferences
        '    For i As Integer = 0 To .Rows.Count - 1 Step 2
        '        For j As Integer = 0 To .Columns.Count - 1
        '            Dim foreColor As Color = Color.Black
        '            Dim backColor As Color = Color.WhiteSmoke
        '            .Rows(i).Cells(j).Style.BackColor = backColor
        '            .Rows(i).Cells(j).Style.ForeColor = foreColor
        '        Next j
        '    Next i
        'End With
    End Sub

    Private Sub btnAddReference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddReference.Click
        If String.IsNullOrEmpty(txtAccountNo.Text) Then
            MessageBox.Show("Please enter the account details first", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtAccountNo.Focus()
            Exit Sub
        End If
        boolEditStatus = False
        Dim f As New frmCustomerTradingHistory
        f.ShowDialog()
        LoadReferenceData()
    End Sub

    Private Sub btnEditReference_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditReference.Click
        boolInProcessMode = True
        SaveCustomerRecord()
        If boolAbort = True Then Exit Sub
        boolEditStatusTwo = True
        intSelectedTransaction = CInt(dGridReferences.CurrentRow.Cells(0).Value.ToString)
        Dim f As New frmCustomerTradingHistory
        f.ShowDialog()
        boolInProcessMode = False
        LoadReferenceData()
    End Sub

    Private Sub cboCustomerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerType.SelectedIndexChanged
        If UCase(cboCustomerType.Text) = "INDIVIDUAL" Then
            pnlIndividuals.Enabled = True
        Else
            pnlIndividuals.Enabled = False
        End If
    End Sub

    Private Sub ValidateData()

    End Sub

    Private Sub SaveIndividualData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        If boolEditStatus = False Then
            strSql = "INSERT INTO IndividualCustomers " _
                & "([AccountNumber], [Title], [LastName], [FirstName], [OtherNames], [MaidenName], [BirthDate], " _
                & "[MaritalStatus], [IDNumber], [Gender], [HomeType]) VALUES ('" & txtAccountNo.Text & "', " _
                & "'" & cboSalutation.Text & "', '" & txtLastName.Text & "', '" & txtFirstName.Text & "', " _
                & "'" & txtOtherNames.Text & "', '" & txtMaidenName.Text & "', '" & Format(dpBirthDate.Value, "dd-MMM-yyyy") & "', " _
                & "'" & cboMaritalStatus.Text & "', '" & txtIdNumber.Text & "', '" & cboGender.Text & "', " _
                & "'" & cboHomeType.Text & "')"
        Else
            strSql = "UPDATE IndividualCustomers SET " _
                & "[Title] = '" & cboSalutation.Text & "', [LastName] = '" & txtLastName.Text & "', " _
                & "[FirstName] = '" & txtFirstName.Text & "', [OtherNames] = '" & txtOtherNames.Text & "', " _
                & "[MaidenName] = '" & txtMaidenName.Text & "', [BirthDate] = '" & Format(dpBirthDate.Value, "dd-MMM-yyyy") & "', " _
                & "[MaritalStatus] = '" & cboMaritalStatus.Text & "', [IDNumber] = '" & txtIdNumber.Text & "', " _
                & "[Gender] = '" & cboGender.Text & "', [HomeType] = '" & cboHomeType.Text & "' " _
                & "WHERE AccountNumber = '" & txtAccountNo.Text & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Individual Customers Details Save"
        ShowErrorMessage()
    End Sub

    Private Sub LoadIndividualData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT [Title], [LastName], [FirstName], [OtherNames], [MaidenName], " _
            & "[BirthDate], [MaritalStatus], [IDNumber], [Gender], [HomeType] " _
            & "FROM IndividualCustomers WHERE [AccountNumber] = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            pnlIndividuals.Enabled = True : cboCustomerType.Text = "Individual"
            If Not IsDBNull(objReader(0).ToString) Then cboSalutation.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtLastName.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtFirstName.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then txtOtherNames.Text = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then txtMaidenName.Text = objReader(4).ToString
            If IsDate(objReader(5).ToString) Then dpBirthDate.Value = CDate(objReader(5).ToString)
            If Not IsDBNull(objReader(6).ToString) Then cboMaritalStatus.Text = objReader(6).ToString
            If Not IsDBNull(objReader(7).ToString) Then txtIdNumber.Text = objReader(7).ToString
            If Not IsDBNull(objReader(8).ToString) Then cboGender.Text = objReader(8).ToString
            If Not IsDBNull(objReader(9).ToString) Then cboHomeType.Text = objReader(9).ToString
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Individual Customers Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub btnNewCreditNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCreditNote.Click
        boolEditStatusTwo = False
        boolLoadedFromCustomerForm = True
        strSelectedAccountName = txtAccountName.Text
        Dim f As New frmCreditNoteEntry
        f.ShowDialog()
        LoadTransactions()
        strSelectedAccountName = Nothing
    End Sub

    Private Sub btnSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveNew.Click
        boolInProcessMode = False
        SaveCustomerRecord()
        MessageBox.Show("Customer record saved successfully", "Saved Details Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtAccountNo.Clear()
        txtAccountName.Clear()
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtAddress3.Clear()
        txtAddress4.Clear()
        txtCellphone.Clear()
        txtContactPerson.Clear()
        txtEmailAddress.Clear()
        txtFaxNumber.Clear()
        txtTelephone.Clear()
        txtVatNumber.Clear()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtOtherNames.Clear()
        txtIdNumber.Clear()
        txtConAddress1.Clear()
        txtConAddress2.Clear()
        txtConAddress3.Clear()
        txtConAddress4.Clear()
        txtRelationship.Clear()
        txtContactCellphone.Clear()
        txtContactEmailAddress.Clear()
        txtContactPerson.Clear()
        txtContactTelephone.Clear()
        txtMaidenName.Clear()
        AutoNumberIncreament()

    End Sub

    Private Sub btnNewInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewInvoice.Click
        boolEditStatusTwo = False
        boolLoadedFromCustomerForm = True
        Dim f As New frmInvoice
        f.ShowDialog()
        LoadTransactions()
    End Sub

    Private Sub btnQuotation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuotation.Click
        boolEditStatusTwo = False
        boolLoadedFromCustomerForm = True
        Dim f As New frmQuotation
        f.ShowDialog()
        LoadTransactions()
    End Sub

    Private Sub btnPrintFullDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintFullDetails.Click

    End Sub

    Private Sub btnPrintTransactionStatement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintTransactionStatement.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrPrintDetails As New ArrayList
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strLineData As String = Nothing
            For p As Integer = 0 To dGrid.ColumnCount - 1
                'FN=Arial;FS=8;FC=White;FB=False;FI=False;FU=False;BC=Navy;RH=25
                Dim strFontName As String = "Arial"
                Dim intFontSize As Integer = 6
                Dim strFontColor As String = "Black"
                Dim strFontBold As String = "False"
                Dim strFontItalic As String = "False"
                Dim strFontUnderline As String = "False"
                Dim strBackColor As String = "White"
                Dim intRectangleHeight As Integer = 25
                Dim strPrintData As String = Nothing
                ';AL=0
                Dim strTextAlignment As String = "0"
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(p).Value), "")) Then
                    strPrintData = dGrid.Rows(i).Cells(p).Value.ToString
                    'Get the actual font and style used in the grid
                    Dim fnt As Font = dGrid.Rows(i).Cells(p).Style.Font
                    If fnt Is Nothing Then intFontSize = 6 Else intFontSize = fnt.Size
                    If fnt Is Nothing Then strFontName = "Ariel" Else strFontName = fnt.Name
                    Dim strFontStyle As String = "False"
                    If Not fnt Is Nothing Then strFontStyle = fnt.Style
                    If strFontStyle = "1" Then strFontBold = "True"
                    If strFontStyle = "2" Then strFontItalic = "True"
                    If strFontStyle = "3" Then ' Bold and italic
                        strFontBold = "True"
                        strFontItalic = "True"
                    End If
                    If strFontStyle = "4" Then strFontUnderline = "True"
                    If strFontStyle = "5" Then ' Bold and underline
                        strFontBold = "True"
                        strFontUnderline = "True"
                    End If
                    If strFontStyle = "6" Then ' italic and underline
                        strFontItalic = "True"
                        strFontUnderline = "True"
                    End If
                    If strFontStyle = "7" Then ' italic and underline
                        strFontItalic = "True"
                        strFontUnderline = "True"
                        strFontBold = "True"
                    End If
                    If p = 4 Or p = 5 Then strTextAlignment = "2"
                End If
                strLineData = strLineData & strPrintData & "|FN=" & strFontName & ";FS=" & intFontSize _
                    & ";FC=" & strFontColor & ";FB=" & strFontBold & ";FI=" & strFontItalic & ";FU=" & strFontUnderline _
                    & ";BC=" & strBackColor & ";RH=" & intRectangleHeight & ";AL=" & strTextAlignment & "</d>"
            Next
            strLineData = Mid(strLineData, 1, strLineData.Length - 4)
            arrPrintDetails.Add(strLineData)
        Next

        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        Dim strColumnHeaders As String = Nothing
        For i As Integer = 0 To dGrid.ColumnCount - 1
            strColumnHeaders = strColumnHeaders & dGrid.Columns(i).HeaderText & "|"
        Next
        strColumnHeaders = Mid(strColumnHeaders, 1, (strColumnHeaders.Length - 1))

        'Request for print properties
        Dim prnt As New PrintDialog
        prnt.ShowDialog()

        Dim intPrintPageAreaWidth As Integer = prnt.PrinterSettings.DefaultPageSettings.PaperSize.Width _
                - (prnt.PrinterSettings.DefaultPageSettings.Margins.Left + prnt.PrinterSettings.DefaultPageSettings.Margins.Right)

        'Widths are based on the percentage point of the paper size and the grid
        Dim strColumnWidths As String = Nothing
        Dim strColumsVisible As String = Nothing

        Dim intTotalGridWidth As Integer = 0
        'calculate the total column widths
        For y As Integer = 0 To dGrid.ColumnCount - 1
            intTotalGridWidth = intTotalGridWidth + dGrid.Columns(y).Width
        Next

        Dim intValidateWidth As Integer = 0
        For i As Integer = 0 To dGrid.ColumnCount - 1
            Dim intCurrentWidth As Integer = 0

            'Calculate the width based on the percentage in the grid
            Dim intEqualWidth As Integer = intPrintPageAreaWidth / dGrid.Columns.Count
            Dim intPercentagePrintArea As Integer = (dGrid.Columns(i).Width / intTotalGridWidth) * 100
            intCurrentWidth = intPrintPageAreaWidth * (intPercentagePrintArea / 100)

            strColumnWidths = strColumnWidths & intCurrentWidth & "|"

            If intCurrentWidth = 0 Then
                strColumsVisible = strColumsVisible & "NO" & "|"
            Else
                strColumsVisible = strColumsVisible & "YES" & "|"
            End If
            intValidateWidth = intValidateWidth + intCurrentWidth
        Next
        strColumnWidths = Mid(strColumnWidths, 1, (strColumnWidths.Length - 1))
        strColumsVisible = Mid(strColumsVisible, 1, (strColumsVisible.Length - 1))

        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = dGrid.ColumnCount
            .strColumnHeaders = UCase(strColumnHeaders)
            .strColumnWidths = strColumnWidths
            .strFooterCaption = "Customer Transactions Report"
            .strMainCaption = UCase("Customer Transactions")
            .strMainHeader2 = UCase(txtAccountName.Text) & " ACCOUNT NUMBER : " & UCase(txtAccountNo.Text)
            .strMainHeader3 = ""
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("WhiteSmoke")
            .HeaderFont = New Font("Verdana", 10, FontStyle.Bold)
            .FooterFont = New Font("Verdana", 6, FontStyle.Bold)
            .boolGenericReport = False
            .strPrintValues = strPrintDetails
            .VisibleColumns = strColumsVisible
            .DetailColor = Color.Black
            .DetailFont = fntDetailsFont
        End With
        Cursor = Cursors.Default
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Transactions Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransaction.Click
        If dGrid.Rows.Count > 0 Then
            Dim intDocumentNumber As Integer = 0
            Dim strDocumentType As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(1).Value), "")) Then
                If IsNumeric(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                    intDocumentNumber = CInt(dGrid.CurrentRow.Cells(1).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(dGrid.Columns.Count - 1).Value), "")) Then
                strDocumentType = dGrid.CurrentRow.Cells(dGrid.Columns.Count - 1).Value.ToString
            End If

            If UCase(strDocumentType) = "INVOICE" Then
                boolEditStatusTwo = True
                boolLoadedFromCustomerForm = True
                intSelectedTransaction = intDocumentNumber
                Dim f As New frmInvoice
                f.ShowDialog()
            End If
            If UCase(strDocumentType) = "CREDIT NOTE" Then
                intSelectedTransaction = intDocumentNumber
                boolEditStatusTwo = True
                Dim f As New frmCreditNoteEntry
                f.ShowDialog()
            End If
        End If
    End Sub

    Private Sub cboPurpose_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPurpose.SelectedIndexChanged
        On Error GoTo RaiseErr
        If cboPurpose.Text = "TRADING" Then
            btnNewItems.Enabled = True
        Else
            btnNewItems.Enabled = False
            boolAbort = False
            Dim myComm As New CommonLibrary.Commons.CommonFunctions
            myComm.DateRangeSpecification()
            If boolAbort = True Then Exit Sub

            strStatementArray = New ArrayList

            dblCummulativeStatementBalance = 0

            'Get the aging balances
            Dim arrAgeBalances As New ArrayList

            Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
            arrAgeBalances = gwt_comm.ComputeAgingBalances(dGrid)

            'Assign the age balances to common variables
            dblBetween00and30 = CDbl(arrAgeBalances.Item(0))
            dblBetween30and60 = CDbl(arrAgeBalances.Item(1))
            dblBetween60and90 = CDbl(arrAgeBalances.Item(2))
            dblOver90 = CDbl(arrAgeBalances.Item(3))

            'Get the balance brought forwd
            For i As Integer = 0 To dGrid.Rows.Count - 3

                Dim dblDr As Double = 0
                Dim dblCr As Double = 0
                Dim strDt As String = Nothing

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    strDt = dGrid.Rows(i).Cells(0).Value.ToString
                End If
                strDt = Mid(strDt, 1, 2) & "-" & MonthName(CInt(Mid(strDt, 4, 2)), True) & "-" & Mid(strDt, 7, 4)

                If CDate(strDt) < StartDate Then
                    'If CDate(strDt) <= EndDate Then
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                        If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                            dblDr = CDbl(dGrid.Rows(i).Cells(4).Value.ToString)
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                        If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                            dblCr = CDbl(dGrid.Rows(i).Cells(5).Value.ToString)
                        End If
                    End If
                    dblCummulativeStatementBalance = dblCummulativeStatementBalance + (dblDr - dblCr)
                    'End If
                End If

            Next

            strStatementArray.Add(UCase(Format(StartDate, "dd-MMM-yyyy")) & "|" & UCase("Balance brought forward") & "| | | | |" & Format(dblCummulativeStatementBalance, "#,##0.00"))
            Dim dblBalance As Double = dblCummulativeStatementBalance

            For i As Integer = 0 To dGrid.Rows.Count - 3
                Dim strDate As String = Nothing
                Dim strReference As String = Nothing
                Dim strDescription As String = Nothing
                Dim dblDebit As Double = 0
                Dim dblCredit As Double = 0
                Dim strProjectName As String = Nothing

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    strDate = dGrid.Rows(i).Cells(0).Value.ToString
                End If
                strDate = Mid(strDate, 1, 2) & "-" & MonthName(CInt(Mid(strDate, 4, 2)), True) & "-" & Mid(strDate, 7, 4)

                If CDate(strDate) >= StartDate Then
                    If CDate(strDate) <= EndDate Then
                        If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                            strReference = dGrid.Rows(i).Cells(1).Value.ToString
                        End If
                        If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                            strDescription = dGrid.Rows(i).Cells(2).Value.ToString
                        End If
                        If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                            If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                                dblDebit = CDbl(dGrid.Rows(i).Cells(4).Value.ToString)
                            End If
                        End If
                        If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                            If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                                dblCredit = CDbl(dGrid.Rows(i).Cells(5).Value.ToString)
                            End If
                        End If
                        dblBalance = dblBalance + (dblDebit - dblCredit)
                        'DATE, DESCRIPTION, REF, PROJECT, DEBIT, CREDIT, BALANCE
                        strStatementArray.Add(strDate & "|" & strDescription & "|" & strReference & "|" & strProjectName & "|" &
                            Format(dblDebit, "#,##0.00") & "|" & Format(dblCredit, "#,##0.00") & "|" &
                            Format(dblBalance, "#,##0.00"))
                    End If
                End If
            Next
            itm = 0

            dblCurrentStatementBalance = dblBalance
            'Adjustment of the moving balance ***

            CommonLibrary.Commons.arrStatementDetails = New ArrayList
            CommonLibrary.Commons.arrStatementDetails = strStatementArray

            boolPrinterAlreadySelected = False
            gwt_comm.PrintCustomerDocument(intSelectedTransaction, "STATEMENT")

            'Dim documentPreview As New PrintPreviewDialog
            'documentPreview.Document = pdSelectiveStatement
            'documentPreview.ShowDialog()
            Exit Sub
RaiseErr:
            boolAbort = True
            Cursor = Cursors.Default
            strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Statement Print Error"
            ShowErrorMessage()
        End If
    End Sub

    Private Sub btnPeriodStatement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodStatement.Click
        Dim prntCom As New CommonLibrary.Commons.CommonFunctions
        prntCom.PrintCustomerStatement(txtAccountNo.Text)
    End Sub

    Private Sub pdSelectiveStatement_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdSelectiveStatement.PrintPage
        If boolPrintFromPreview = True Then
            'requery records
            'Me.PrintCustomerStatement()
            boolPrintFromPreview = False
            arrCount = 0
            itm = 0
        End If

        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions

        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer
        'Dim xx1 As Integer, xx2 As Integer, yy1 As Integer, yy2 As Integer
        x1 = e.PageBounds.Left + 100
        y1 = e.PageBounds.Top + 100
        p1 = e.PageBounds.Width - 200
        y2 = e.PageBounds.Height - 170

        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        Dim strS As String = Nothing
        Dim Yc As Integer
        Dim cols, lines As Integer

        boolExitingWhile = False

        'print the company logo
        'R = New Rectangle(x1, (y1 - 100), 200, 100)
        'e.Graphics.DrawImage(picPrint.Image, R)
        'y1 = y1 + 20

        '************************************************************************
        'Begin the stringing of the statements here
        intPage = 1
        'If there are no record to print skip this process


        'Draw the document rectangle
        reccurrent = New Rectangle(x1, y1, p1, y2)
        e.Graphics.DrawRectangle(Pens.Black, reccurrent)
        y1 = e.PageBounds.Top + 120
        'Print the company details at the extreme left of document
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, HeaderFont, Brushes.Black)
        e.Graphics.DrawString("CUSTOMER STATEMENT", HeaderFont, Brushes.Black, 500, e.PageBounds.Top + 120)
        y1 = y1 + 20

        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyAddress1) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, CommonLibrary.Commons.strCompanyAddress1, tlFont, Brushes.Black)
            'Print the company number
            If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.  : " & UCase(CommonLibrary.Commons.strCompanyBPNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the company number
            If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.  : " & UCase(CommonLibrary.Commons.strCompanyBPNumber), tlFont, Brushes.Black)
                y1 = y1 + 15
            End If
        End If

        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyAddress2) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, CommonLibrary.Commons.strCompanyAddress2, tlFont, Brushes.Black)
            'Print the vat number
            If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO. : " & UCase(CommonLibrary.Commons.strCompanyVatNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the vat number
            If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO. : " & UCase(CommonLibrary.Commons.strCompanyVatNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        End If

        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyAddress3) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, CommonLibrary.Commons.strCompanyAddress3, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyAddress4) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, CommonLibrary.Commons.strCompanyAddress4, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyTelephone) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "PHONE  : " & UCase(CommonLibrary.Commons.strCompanyTelephone), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        'strCompanyContactCellNumber
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyContactCellNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 550, 80, "CELL NO: " & UCase(CommonLibrary.Commons.strCompanyContactCellNumber), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyFaxNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "FAX NO.: " & UCase(CommonLibrary.Commons.strCompanyFaxNumber), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyEmailAddress) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "E-MAIL : " & CommonLibrary.Commons.strCompanyEmailAddress, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        y1 = y1 + 5

        'Print the bank details
        If Not String.IsNullOrEmpty(CommonLibrary.Commons.strCompanyBankName) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 600, 80, "BANKING DETAILS " & UCase(CommonLibrary.Commons.strCompanyBankName) &
                ": BRANCH CODE = " & UCase(CommonLibrary.Commons.strCompanyBranchCode) & ": ACC. NO = " &
                CommonLibrary.Commons.strCompanyAccountNumber, tlFont, Brushes.Black)
            y1 += 20
        End If

        'print captions
        x1 = x1 + 10
        x2 = x1 + 110
        X3 = x2 + 100
        X4 = X3 + 100
        X5 = X4 + 100
        X6 = X5 + 80

        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        e.Graphics.DrawString("CUSTOMER DETAILS", prFont, Brushes.Black, x1, y1)
        e.Graphics.DrawString("STATEMENT DETAILS", prFont, Brushes.Black, 500, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 30
        'Read the customer details
        'drCustomerDetails.Read()
        'Continue and print the customer details
        strCustomerName = UCase(txtAccountName.Text)
        e.Graphics.DrawString(strCustomerName, tlFont, Brushes.Black, x1, y1)
        e.Graphics.DrawString("STATEMENT DATE : " & Format(Now, "dd-MMM-yyyy"), tlFont, Brushes.Black, 450, y1)
        y1 = y1 + 25
        strCustomerAddress = txtAddress1.Text & vbCrLf & txtAddress2.Text & vbCrLf & txtAddress3.Text & vbCrLf & txtAddress4.Text
        'e.Graphics.DrawString(strCustomerAddress, tlFont, Brushes.Black, x1, y1)
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress, tlFont, Brushes.Black)
        'Get the size of the address box
        e.Graphics.MeasureString(strCustomerAddress, tlFont, New SizeF(200, 80), New StringFormat(), cols, lines)
        Yc = y1
        y1 = y1 + lines * tlFont.Height + 5
        y1 = Math.Max(y1, Yc)
        'y1 = y1 + 50
        e.Graphics.DrawString("PHONE :" & txtTelephone.Text & " FAX : " & txtFaxNumber.Text, tlFont, Brushes.Black, x1, y1)
        'y1 = y1 + 25
        e.Graphics.DrawString("PERIOD COVERED : " & Format(StartDate, "dd-MMM-yyyy") & " TO " & Format(EndDate, "dd-MMM-yyyy"), tlFont, Brushes.Black, 450, y1)
        y1 = y1 + 75
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        'print captions
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 100, 80, "DATE", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 120, 80, "REF.", prFont, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, x2 + 60, y1, 60, 80, "PROJ.", prFont, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, X3 + 25, y1, 180, 80, "DESCRIPTION", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 120, 80, "DEBIT", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, "CREDIT", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, "BALANCE", prFont, Brushes.Black)
        'draw a line after
        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 30
        'itm = 0
        reccurrent = New Rectangle()
        If boolExitingWhile = False Then dblBalance = 0
        'Print the cummulative balance first
        Call gwt_comm.DrawStringInBoxLeft(e, X3 + 25, y1, 180, 80, "Balance b/d", prFont, Brushes.Black)
        'If printing to the next page then you take the balance from the previous page
        If boolExitingWhile = False Then
            Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, Format(dblCummulativeStatementBalance, "#,##0.00"), prFont, Brushes.Black)
        Else
            Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, Format(dblBalance, "#,##0.00"), prFont, Brushes.Black)
        End If
        y1 = y1 + 30

        If boolExitingWhile = False Then dblBalance = dblCummulativeStatementBalance
        boolExitingWhile = False

        While itm < strStatementArray.Count
            Dim strbuffer() As String
            strbuffer = Split(strStatementArray(itm), "|")
            If Not strbuffer(0) Is Nothing Then strvalue = CStr(Format(CDate(strbuffer(0)), "dd-MMM-yyyy")) Else strvalue = ""
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 120, 80, strvalue, tlFont, Brushes.Black)
            If Not strbuffer(1) Is Nothing Then strvalue = strbuffer(1) Else strvalue = ""
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 120, 80, strvalue, tlFont, Brushes.Black)
            Dim strProjectName As String = Nothing
            strvalue = getProjectNumber(strvalue)
            If IsNumeric(strvalue) Then
                If CInt(strvalue) = 0 Then
                    strvalue = ""
                Else
                    strProjectName = getProjectName(CInt(strvalue))
                End If
            Else
                strvalue = ""
            End If
            Call gwt_comm.DrawStringInBoxLeft(e, x2 + 60, y1, 120, 80, strvalue, tlFont, Brushes.Black)

            If Not String.IsNullOrEmpty(strProjectName) Then
                If Not strbuffer(2) Is Nothing Then
                    Dim strPrefix() As String = Split(strbuffer(2), " ")
                    strvalue = strProjectName & "-" & strPrefix(1)
                End If
            Else
                If Not strbuffer(2) Is Nothing Then strvalue = strbuffer(2) Else strvalue = ""
            End If

            Call gwt_comm.DrawStringInBoxLeft(e, X3 + 25, y1, 180, 80, strvalue, tlFont, Brushes.Black)
            If UCase(CommonLibrary.Commons.strCompanyCountry) = "SOUTH AFRICA" Then
                If Not strbuffer(3) Is Nothing Then strvalue = CStr(Format(CDbl(strbuffer(3)), "R#,##0.00")) Else strvalue = "0.00"
            Else
                If Not strbuffer(3) Is Nothing Then strvalue = CStr(Format(CDbl(strbuffer(3)), "#,##0.00")) Else strvalue = "0.00"
            End If

            Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 120, 80, strvalue, tlFont, Brushes.Black)
            If UCase(CommonLibrary.Commons.strCompanyCountry) = "SOUTH AFRICA" Then
                If Not strbuffer(4) Is Nothing Then strvalue = CStr(Format(CDbl(strbuffer(4)), "R#,##0.00")) Else strvalue = "0.00"
            Else
                If Not strbuffer(4) Is Nothing Then strvalue = CStr(Format(CDbl(strbuffer(4)), "#,##0.00")) Else strvalue = "0.00"
            End If
            Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, strvalue, tlFont, Brushes.Black)
            dblBalance = dblBalance + CDbl(strbuffer(3)) - CDbl(strbuffer(4))
            strvalue = CStr(Format(dblBalance, "#,##0.00"))
            Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, strvalue, tlFont, Brushes.Black)
            'print invoice total
            y1 = y1 + 15
            itm = itm + 1 'i = 0
            intLineCount = intLineCount + 1
            If intLineCount = 20 Then
                'Print the page number of the statement
                Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage & " of " & intPageTotals, tlFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", prFont, Brushes.Black)
                intLineCount = 0
                e.HasMorePages = True
                boolExitingWhile = True
                intPage += 1
                Exit While
            End If
        End While

        If boolExitingWhile = False Then
            e.HasMorePages = False
            boolPrintFromPreview = True
        Else
            e.HasMorePages = False
        End If

    End Sub

    Private Function getProjectName(ByVal ProjectNumber As Integer) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ContractName FROM ProjectsMain WHERE ContractNumber = " & ProjectNumber & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                strReturn = CStr(objReader(0).ToString)
            End If
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to get the project name"
        ShowErrorMessage()
    End Function

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(1).Value), "")) Then
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(dGrid.Columns.Count - 1).Value), "")) Then
                If UCase(dGrid.CurrentRow.Cells(dGrid.Columns.Count - 1).Value.ToString) = "INVOICE" Then
                    If IsNumeric(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                        boolEditStatusTwo = True
                        boolLoadedFromCustomerForm = True
                        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(1).Value.ToString)
                        Dim f As New frmInvoice
                        f.ShowDialog()
                        LoadTransactions()
                    End If
                Else
                    If UCase(dGrid.CurrentRow.Cells(dGrid.Columns.Count - 1).Value.ToString) = "PAYMENT" Then
                        CommonLibrary.Commons.strNewReferenceNumber = Nothing
                        boolAbort = False
                        Dim strOldNumber As String = dGrid.CurrentRow.Cells(1).Value.ToString
                        Dim f As New frmCustomerReferenceChange
                        f.ShowDialog()
                        If boolAbort = True Then Exit Sub
                        Dim objSave As New Data.OleDb.OleDbCommand("UPDATE CustomerTransactions SET " _
                            & "ReferenceNumber = '" & CommonLibrary.Commons.strNewReferenceNumber & "' WHERE " _
                            & "ReferenceNumber = '" & strOldNumber & "' AND AccountNumber = '" & strSelectedAccount & "'", cnn)
                        objSave.ExecuteNonQuery()
                        LoadTransactions()
                    Else
                        If UCase(dGrid.CurrentRow.Cells(dGrid.Columns.Count - 1).Value.ToString) = "CR NOTE" Then
                            intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(1).Value.ToString)
                            boolEditStatusTwo = True
                            Dim f As New frmCreditNoteEntry
                            f.ShowDialog()
                            LoadTransactions()
                        End If
                    End If
                End If
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On customer invoice preview load error"
        ShowErrorMessage()
    End Sub

    Private Sub btnManageTransactions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManageTransactions.Click
        If boolEditStatus = False Then Exit Sub
        Dim f As New frmCustomerAccountsAdjustment
        f.ShowDialog()
        LoadTransactions()
    End Sub

    Private Function getProjectNumber(ByVal InvoiceNumber As Long) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ProjectNumber FROM CustomerSalesMain WHERE InvoiceNumber = " & InvoiceNumber & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                strReturn = CStr(objReader(0).ToString)
            End If
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to get the project number"
        ShowErrorMessage()
    End Function

    Private Sub LoadInvoices(ByVal AccountNumber As String)
        On Error GoTo RaiseErr


        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        dGridMatching.Rows.Clear()


        strSql = "IF OBJECT_ID(N'Temp_Data', N'U') IS NOT NULL DROP TABLE Temp_Data"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), customersalesmain.TransDate, 106), ' ', '-')) as [TransDate], " _
            & "customersalesmain.InvoiceNumber AS [Reference], CAST(CustomerSalesMain.Amount AS DECIMAL (10,2)) AS [Debit] " _
            & "INTO Temp_Data FROM CustomerSalesMain WHERE customersalesmain.CustomerId = '" & AccountNumber & "' " _
            & "ORDER BY CustomerSalesMain.TransDate, CustomerSalesMain.InvoiceNumber"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "ALTER TABLE Temp_Data ADD [Credit][FLOAT] NOT NULL DEFAULT 0, [TransactionType][NVARCHAR](35) NOT NULL DEFAULT ''"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "UPDATE Temp_Data SET TransactionType = 'INVOICE' WHERE Debit > 0"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "INSERT INTO Temp_Data (TransDate, Reference, Credit) SELECT " _
         & "UPPER(REPLACE(CONVERT(CHAR(11), CreditNotesMain.TransDate, 106), ' ', '-')) as [TransDate], CreditNoteEntries.Reference, " _
            & "SUM((CreditNoteEntries.Quantity * CreditNoteEntries.UnitPrice) + Taxes) AS [Credit] FROM " _
            & "CreditNotesMain, CreditNoteEntries WHERE CreditNoteEntries.NoteNumber = CreditNotesMain.NoteNumber " _
            & "AND CreditNotesMain.AccountId = '1000015' GROUP BY CreditNotesMain.TransDate, CreditNoteEntries.Reference"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "UPDATE Temp_Data SET TransactionType = 'CREDIT NOTES' WHERE Credit > 0"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "INSERT INTO Temp_Data (TransDate, Reference, Credit) " _
         & "SELECT UPPER(REPLACE(CONVERT(CHAR(11), CustomerTransactions.TransactionDate, 106), ' ', '-')) as [TransDate], " _
         & "CustomerTransactions.ReferenceNumber AS [Reference], CAST((Amount * -1) AS DECIMAL (10,2)) AS [Credit] " _
         & "FROM CustomerTransactions WHERE AccountNumber = '1000015' AND TransactionType = 'PAYMENT'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "UPDATE Temp_Data SET TransactionType = 'RECEIPTS' WHERE TransactionType = ''"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "SELECT TransDate, Reference, TransactionType AS [Description], ISNULL(Debit, 0) AS [Debit], " _
            & "ISNULL(Credit, 0) AS [Credit] FROM Temp_Data " _
            & "ORDER BY Reference, Credit, Debit, TransDate"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        While objReader.Read
            dGridMatching.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4))
        End While
        objReader.Close()

        Dim dblDebits As Double = 0
        Dim dblCredits As Double = 0
        Dim dblBalance As Double = 0

        With dGridMatching
            For i As Integer = 0 To dGridMatching.Rows.Count - 1
                If Not Object.Equals(.Rows(i).Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(i).Cells(3).Value.ToString) Then
                        If IsNumeric(.Rows(i).Cells(3).Value.ToString) Then
                            dblDebits = dblDebits + CDbl(.Rows(i).Cells(3).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(i).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(i).Cells(4).Value.ToString) Then
                        If IsNumeric(.Rows(i).Cells(4).Value.ToString) Then
                            dblCredits = dblCredits + CDbl(.Rows(i).Cells(4).Value.ToString)
                        End If
                    End If
                End If
            Next
        End With

        lblTotalDebits.Text = Format(dblDebits, "#,##0.00")
        lblTotalCredits.Text = Format(dblCredits, "#,##0.00")
        lblGrandBalance.Text = Format(dblDebits - dblCredits, "#,##0.00")

        lblTotalDebits.Visible = False : lblTotalCredits.Visible = False : lblGrandBalance.Visible = False

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On customer invoices matching"
        ShowErrorMessage()
    End Sub

    Private Sub btnUnpaidInvoices_Click(sender As System.Object, e As System.EventArgs) Handles btnUnpaidInvoices.Click
        On Error GoTo RaiseErr
        boolAbort = False
        Dim myComm As New CommonLibrary.Commons.CommonFunctions
        myComm.DateRangeSpecification()
        If boolAbort = True Then Exit Sub

        strStatementArray = New ArrayList

        dblCummulativeStatementBalance = 0

        'Get the aging balances
        Dim arrAgeBalances As New ArrayList

        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
        arrAgeBalances = gwt_comm.ComputeAgingBalances(dGrid)

        'Assign the age balances to common variables
        dblBetween00and30 = CDbl(arrAgeBalances.Item(0))
        dblBetween30and60 = CDbl(arrAgeBalances.Item(1))
        dblBetween60and90 = CDbl(arrAgeBalances.Item(2))
        dblOver90 = CDbl(arrAgeBalances.Item(3))

        'Get the balance brought forwd
        For i As Integer = 0 To dGridMatching.Rows.Count - 3

            Dim dblDr As Double = 0
            Dim dblCr As Double = 0
            Dim strDt As String = Nothing

            If Not (Object.Equals(Convert.ToString(dGridMatching.Rows(i).Cells(0).Value), "")) Then
                strDt = dGridMatching.Rows(i).Cells(0).Value.ToString
            End If
            'strDt = Mid(strDt, 1, 2) & "-" & MonthName(CInt(Mid(strDt, 4, 2)), True) & "-" & Mid(strDt, 7, 4)

            If CDate(strDt) < StartDate Then
                'If CDate(strDt) <= EndDate Then
                If Not (Object.Equals(Convert.ToString(dGridMatching.Rows(i).Cells(3).Value), "")) Then
                    If IsNumeric(dGridMatching.Rows(i).Cells(3).Value.ToString) Then
                        dblDr = CDbl(dGridMatching.Rows(i).Cells(3).Value.ToString)
                    End If
                End If
                'If Not (Object.Equals(Convert.ToString(dGridMatching.Rows(i).Cells(4).Value), "")) Then
                '    If IsNumeric(dGridMatching.Rows(i).Cells(4).Value.ToString) Then
                '        dblCr = CDbl(dGridMatching.Rows(i).Cells(4).Value.ToString)
                '    End If
                'End If
                dblCummulativeStatementBalance = dblCummulativeStatementBalance + (dblDr - dblCr)
                'End If
            End If

        Next

        strStatementArray.Add(UCase(Format(StartDate, "dd-MMM-yyyy")) & "|" & UCase("OPENING BALANCE") & "| | | | |" & Format(0, "#,##0.00"))
        Dim dblBalance As Double = dblCummulativeStatementBalance

        Dim dblDebitTotal As Double = 0
        Dim dblCreditTotal As Double = 0
        Dim dblCnoteTotal As Double = 0
        Dim dblBalanceTotal As Double = 0

        For i As Integer = 0 To dGridMatching.Rows.Count - 1
            Dim strDate As String = Nothing
            Dim strReference As String = Nothing
            Dim strDescription As String = Nothing
            Dim dblDebit As Double = 0
            Dim dblCredit As Double = 0
            Dim dblCreditNote As Double = 0
            Dim strProjectName As String = Nothing

            If Not (Object.Equals(Convert.ToString(dGridMatching.Rows(i).Cells(0).Value), "")) Then
                strDate = dGridMatching.Rows(i).Cells(0).Value.ToString
            End If
            'strDate = Mid(strDate, 1, 2) & "-" & MonthName(CInt(Mid(strDate, 4, 2)), True) & "-" & Mid(strDate, 7, 4)

            If CDate(strDate) >= StartDate Then
                If CDate(strDate) <= EndDate Then
                    If Not (Object.Equals(Convert.ToString(dGridMatching.Rows(i).Cells(1).Value), "")) Then
                        strReference = dGridMatching.Rows(i).Cells(1).Value.ToString
                    End If
                    'If Not (Object.Equals(Convert.ToString(dGridMatching.Rows(i).Cells(2).Value), "")) Then
                    '    strDescription = dGridMatching.Rows(i).Cells(2).Value.ToString
                    'End If
                    If Not (Object.Equals(Convert.ToString(dGridMatching.Rows(i).Cells(3).Value), "")) Then
                        If IsNumeric(dGridMatching.Rows(i).Cells(3).Value.ToString) Then
                            dblDebit = CDbl(dGridMatching.Rows(i).Cells(3).Value.ToString)
                            dblDebitTotal = dblDebitTotal + dblDebit
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGridMatching.Rows(i).Cells(4).Value), "")) Then
                        If IsNumeric(dGridMatching.Rows(i).Cells(4).Value.ToString) Then
                            dblCredit = CDbl(dGridMatching.Rows(i).Cells(4).Value.ToString)
                            dblCreditTotal = dblCreditTotal + dblCredit
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGridMatching.Rows(i).Cells(4).Value), "")) Then
                        If IsNumeric(dGridMatching.Rows(i).Cells(4).Value.ToString) Then
                            dblCreditNote = CDbl(dGridMatching.Rows(i).Cells(4).Value.ToString)
                            dblCnoteTotal = dblCnoteTotal + dblCreditNote
                        End If
                    End If
                    'If Not (Object.Equals(Convert.ToString(dGridMatching.Rows(i).Cells(5).Value), "")) Then
                    '    If IsNumeric(dGridMatching.Rows(i).Cells(5).Value.ToString) Then
                    '        dblBalance = CDbl(dGridMatching.Rows(i).Cells(5).Value.ToString)
                    '        dblBalanceTotal = dblBalanceTotal + dblBalance
                    '    End If
                    'End If

                    If dblDebit <> 0 And dblCredit <> 0 Then
                        strDescription = "CREDIT INVOICE/PAYMENT"
                    Else
                        If dblDebit <> 0 Then
                            strDescription = "CREDIT INVOICE"
                        Else
                            If dblCredit <> 0 Then
                                strDescription = "PAYMENTS"
                            Else
                                If dblCreditNote <> 0 Then
                                    strDescription = "CREDIT NOTE"
                                End If
                            End If
                        End If
                    End If
                    'DATE, DESCRIPTION, REF, DEBIT, CREDIT, C.NOTE, BALANCE
                    If dblBalance <> 0 Then
                        strStatementArray.Add(strDate & "|" & strDescription & "|" & strReference & "|" & Format(dblDebit, "#,##0.00") & "|" &
                            Format(dblCredit, "#,##0.00") & "|" & Format(dblCreditNote, "#,##0.00") & "|" &
                            Format(dblBalance, "#,##0.00"))
                    End If
                End If
            End If
        Next
        itm = 0

        dblCurrentStatementBalance = dblBalance
        'Adjustment of the moving balance ***

        dblPublicInvoiceTotals = dblDebitTotal
        dblPublicReceiptsTotals = dblCreditTotal
        dblPublicSubUnpaidTotals = dblDebitTotal - dblCreditTotal
        dblPublicCreditNotesTotals = dblCnoteTotal
        dblUnpaidsBalanceTotal = dblBalanceTotal

        CommonLibrary.Commons.arrStatementDetails = New ArrayList
        CommonLibrary.Commons.arrStatementDetails = strStatementArray

        boolPrinterAlreadySelected = False
        gwt_comm.PrintCustomerDocument(intSelectedTransaction, "STATEMENT OF UNPAIDS")

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Statement Print Error"
        ShowErrorMessage()
    End Sub

    Private Sub LoadAgingParameters()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [DueDays] FROM SystemAgingParameters ORDER BY TransactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        txtPaymentDueDays.Items.Clear()
        txtPaymentDueDays.Items.Add("0")
        While objReader.Read()
            txtPaymentDueDays.Items.Add(objReader(0))
        End While
        objReader.Read()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On aging analysis parameters setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If boolEditStatus = True Then
            'CommonLibrary.Commons.strSelectedAccount = strSelectedAccount
            'LoadIdentityData()
            'LoadData()
            'LoadTerms()
            'GetBalance()
            'GetLastPayment()
            'LoadEmploymentData()
            LoadTransactions()
            LoadInvoices(strSelectedAccount)
            'LoadReferenceData()
            'LoadIndividualData()
            'btnManageTransactions.Enabled = True
            'btnPrint.Enabled = True
            'btnSaveNew.Enabled = False 'ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
            'If cboPurpose.Text <> "LOAN" Then
            '    btnNewItems.Enabled = True 'ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
            'Else
            '    btnNewItems.Enabled = False
            'End If
            'Me.Text = Me.Text & " : " & txtAccountName.Text
        End If
    End Sub

End Class