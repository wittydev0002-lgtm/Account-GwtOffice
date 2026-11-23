Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmFarmersData

    Dim boolLoading As Boolean

    Private Sub frmFarmersData_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadProvinces()
        LoadEmployees()
        If boolEditStatus = True Then
            LoadData()
            LoadInvoiceTransactions()
            LoadLoanTransactions()
            GetBalance()
            GetLastPayment()
            txtGrowerNumber.Enabled = False
        End If
    End Sub

    Private Sub frmFarmersData_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 663 : Me.Height = 468
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(txtGrowerNumber.Text) Then
            MessageBox.Show("Please enter a valid grower number", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGrowerNumber.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtLastName.Text) Then
            MessageBox.Show("Please enter the last name", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLastName.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtFirstName.Text) Then
            MessageBox.Show("Please enter the first name", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirstName.Select()
            Exit Sub
        End If

        If Not IsNumeric(txtExpectedYield.Text) Then txtExpectedYield.Text = "0.00"
        If Not IsNumeric(txtYieldLastSeason.Text) Then txtYieldLastSeason.Text = "0.00"
        If Not IsNumeric(txtAreaPlanted.Text) Then txtAreaPlanted.Text = "0.00"
        If Not IsNumeric(txtDebtValue.Text) Then txtDebtValue.Text = "0.00"

        boolAbort = False
        If boolEditStatus = False Then
            InsertNewRecord()
        Else
            UpdateRecord()
        End If
        If boolAbort = False Then Me.Close()
    End Sub

    Private Sub InsertNewRecord()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "INSERT INTO FarmersData ([GrowerNumber], " _
            & "[Gender], [FirstName], [LastName], [OtherNames], [IdNumber], " _
            & "[FarmName], [Province], [District], [Ward], [Chairman], [FarmClass]," _
            & "[PostalAddress], [SeedVariety], [AreaPlanted], [ExpectedYield]," _
            & "[YieldLastSeason], [ReceiptNo], [TmbReceiptNo], [BankName]," _
            & "[AccountName], [AccountNumber], [FieldOfficer], [DebtValue], [CompanyOwed], [Cellphone]) VALUES ('" & txtGrowerNumber.Text & "', " _
            & "'" & cboGender.Text & "', '" & txtFirstName.Text & "', '" & txtLastName.Text & "', " _
            & "'" & txtOtherNames.Text & "', '" & txtIdNumber.Text & "', '" & txtFarmName.Text & "', " _
            & "'" & cboProvince.Text & "', '" & cboDistrict.Text & "', '" & txtWard.Text & "', " _
            & "'" & txtChief.Text & "', '" & cboFarmType.Text & "', '" & txtPostalAddress.Text & "', " _
            & "'" & txtSeedVariety.Text & "', " & CDbl(txtAreaPlanted.Text) & ", " & CDbl(txtExpectedYield.Text) & ", " _
            & "" & CDbl(txtYieldLastSeason.Text) & ", '" & txtReceiptNo.Text & "', '" & txtTmbReceipt.Text & "', " _
            & "'" & txtBankName.Text & "', '" & txtAccountName.Text & "', '" & txtBankAccountNum.Text & "', " _
            & "'" & cboFieldOfficer.Text & "', " & CDbl(txtDebtValue.Text) & ", '" & txtCompanyOwed.Text & "', " _
            & "'" & txtCellphone.Text & "')"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Cursor = Cursors.Default
        MessageBox.Show("Details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On farmer details update"
        ShowErrorMessage()
    End Sub

    Private Sub UpdateRecord()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = "UPDATE FarmersData SET" _
            & "[Gender] = '" & cboGender.Text & "', [FirstName] = '" & txtFirstName.Text & "', " _
            & "[LastName] = '" & txtLastName.Text & "', [OtherNames] = '" & txtOtherNames.Text & "', " _
            & "[IdNumber] = '" & txtIdNumber.Text & "', " _
            & "[FarmName] = '" & txtFarmName.Text & "', [Province] = '" & cboProvince.Text & "', " _
            & "[District] = '" & cboDistrict.Text & "', [Ward] = '" & txtWard.Text & "', " _
            & "[Chairman] = '" & txtChief.Text & "', [FarmClass] = '" & cboFarmType.Text & "'," _
            & "[PostalAddress] = '" & txtPostalAddress.Text & "', [SeedVariety] = '" & txtSeedVariety.Text & "', " _
            & "[AreaPlanted] = " & CDbl(txtAreaPlanted.Text) & ", [ExpectedYield] = " & CDbl(txtExpectedYield.Text) & "," _
            & "[YieldLastSeason] = " & CDbl(txtYieldLastSeason.Text) & ", [ReceiptNo] = '" & txtReceiptNo.Text & "', " _
            & "[TmbReceiptNo] = '" & txtTmbReceipt.Text & "', [BankName] = '" & txtBankName.Text & "'," _
            & "[AccountName] = '" & txtAccountName.Text & "', [AccountNumber] = '" & txtBankAccountNum.Text & "', " _
            & "[FieldOfficer] = '" & cboFieldOfficer.Text & "', CompanyOwed = '" & txtCompanyOwed.Text & "', " _
            & "DebtValue = " & CDbl(txtDebtValue.Text) & ", Cellphone = '" & txtCellphone.Text & "' " _
            & "WHERE [GrowerNumber] = '" & txtGrowerNumber.Text & "'"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default

        MessageBox.Show("Details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On farmer details update"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT * FROM FarmersData WHERE GrowerNumber = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()

            If Not IsDBNull(objReader("GrowerNumber").ToString) Then txtGrowerNumber.Text = objReader("GrowerNumber").ToString
            If Not IsDBNull(objReader("Gender").ToString) Then cboGender.Text = objReader("Gender").ToString
            If Not IsDBNull(objReader("FirstName").ToString) Then txtFirstName.Text = objReader("FirstName").ToString
            If Not IsDBNull(objReader("LastName").ToString) Then txtLastName.Text = objReader("LastName").ToString
            If Not IsDBNull(objReader("OtherNames").ToString) Then txtOtherNames.Text = objReader("OtherNames").ToString
            If Not IsDBNull(objReader("IdNumber").ToString) Then txtIdNumber.Text = objReader("IdNumber").ToString
            If Not IsDBNull(objReader("FarmName").ToString) Then txtFarmName.Text = objReader("FarmName").ToString
            If Not IsDBNull(objReader("Province").ToString) Then cboProvince.Text = objReader("Province").ToString
            If Not IsDBNull(objReader("District").ToString) Then cboDistrict.Text = objReader("District").ToString
            If Not IsDBNull(objReader("Ward").ToString) Then txtWard.Text = objReader("Ward").ToString
            If Not IsDBNull(objReader("Chairman").ToString) Then txtChief.Text = objReader("Chairman").ToString
            If Not IsDBNull(objReader("FarmClass").ToString) Then cboFarmType.Text = objReader("FarmClass").ToString
            If Not IsDBNull(objReader("PostalAddress").ToString) Then txtPostalAddress.Text = objReader("PostalAddress").ToString
            If Not IsDBNull(objReader("SeedVariety").ToString) Then txtSeedVariety.Text = objReader("SeedVariety").ToString
            If Not IsDBNull(objReader("AreaPlanted").ToString) Then txtAreaPlanted.Text = objReader("AreaPlanted").ToString
            If Not IsDBNull(objReader("ExpectedYield").ToString) Then txtExpectedYield.Text = objReader("ExpectedYield").ToString
            If Not IsDBNull(objReader("YieldLastSeason").ToString) Then txtYieldLastSeason.Text = objReader("YieldLastSeason").ToString
            If Not IsDBNull(objReader("ReceiptNo").ToString) Then txtReceiptNo.Text = objReader("ReceiptNo").ToString
            If Not IsDBNull(objReader("TmbReceiptNo").ToString) Then txtTmbReceipt.Text = objReader("TmbReceiptNo").ToString
            If Not IsDBNull(objReader("BankName").ToString) Then txtBankName.Text = objReader("BankName").ToString
            If Not IsDBNull(objReader("AccountName").ToString) Then txtAccountName.Text = objReader("AccountName").ToString
            If Not IsDBNull(objReader("AccountNumber").ToString) Then txtBankAccountNum.Text = objReader("AccountNumber").ToString

            If Not IsDBNull(objReader("DebtValue").ToString) Then txtDebtValue.Text = objReader("DebtValue").ToString
            If Not IsDBNull(objReader("CompanyOwed").ToString) Then txtCompanyOwed.Text = objReader("CompanyOwed").ToString
            If Not IsDBNull(objReader("FieldOfficer").ToString) Then cboFieldOfficer.Text = objReader("FieldOfficer").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtCellphone.Text = objReader("Cellphone").ToString

        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On farmer data load"
        ShowErrorMessage()
    End Sub

    Private Sub btnAddProvince_Click(sender As System.Object, e As System.EventArgs) Handles btnAddProvince.Click
        Dim boolStatusBefore As Boolean = boolEditStatus
        boolEditStatus = False
        Dim f As New frmProvinceSetup
        f.ShowDialog()
        boolEditStatus = boolStatusBefore
        LoadProvinces()
    End Sub

    Private Sub LoadProvinces()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Province FROM Provinces ORDER BY Province", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        cboProvince.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboProvince.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Provinces Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadDistricts(ByVal strProvince As String)
        On Error GoTo RaiseErr
        If boolLoading = True Then Exit Sub
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT distinct District FROM Districts " _
                & "WHERE Province = '" & strProvince & "' ORDER BY District", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        cboDistrict.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboDistrict.Items.Add(objReader(0).ToString)
        End While
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On District Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboProvince_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvince.SelectedIndexChanged
        boolLoading = False
        LoadDistricts(cboProvince.Text)
    End Sub

    Private Sub btnAddDistrict_Click(sender As System.Object, e As System.EventArgs) Handles btnAddDistrict.Click
        Dim boolStatusBefore As Boolean = boolEditStatus
        If String.IsNullOrEmpty(cboProvince.Text) Then
            MessageBox.Show("You have to select the province first before adding a district", "Missing Province", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboProvince.Focus()
            Exit Sub
        Else
            boolEditStatus = True
            strSelectedCategory = cboProvince.Text
            boolEditStatus = True
            Dim f As New frmProvinceSetup
            f.ShowDialog()
            boolEditStatus = boolStatusBefore
            LoadProvinces()
            cboProvince.Text = strSelectedCategory
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadEmployees()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT LastName +' '+ FirstName +' '+ OtherNames AS " _
            & "[Personnel] FROM EmployeeMaster ORDER BY LastName, FirstName, OtherNames"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        cboFieldOfficer.Items.Clear()

        cboFieldOfficer.Items.Add("-- NONE --")

        Dim i As Double = 0
        Dim p As Double = 0
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboFieldOfficer.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Personnel Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadLoanTransactions()
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


    '************************************************************************************************************

    Private Sub LoadInvoiceData()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, TransactionDate, 105) AS [Date], ReferenceNumber, " _
            & "Description, CAST(Amount AS DECIMAL (30,2)) AS [Amt], TransactionType FROM " _
            & "FarmerInvoiceTransactions WHERE AccountNumber = '" & strSelectedAccount & "' ORDER BY TransactionDate, ReferenceNumber"
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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetBalance()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CAST(Amount AS DECIMAL (30,2)) AS [Amt], TransactionType FROM " _
            & "FarmerInvoiceTransactions  WHERE AccountNumber = '" & strSelectedAccount & "'"
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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetLastPayment()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CAST(Amount AS DECIMAL (30,2)) AS [Amt], TransactionDate FROM " _
            & "FarmerInvoiceTransactions  WHERE AccountNumber = '" & strSelectedAccount & "' AND " _
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
                    lblPaymentDate.Text = UCase(shortMonthDateFormat(CDate(objReader(1).ToString)))
                End If
            End If
        End If
        objReader.Close()
        'Get the Year to date sales
        strSql = "SELECT SUM(Amount) FROM FarmerInvoiceTransactions  WHERE AccountNumber = '" & strSelectedAccount & "' " _
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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadInvoiceTransactions()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        'Get the customer transactions
        '
        strSql = "SELECT 'INVOICES', MIN(FarmerInvoiceTransactions.TransactionId) AS [ID], UPPER(REPLACE(CONVERT(CHAR(11), " _
            & "FarmerInvoiceTransactions.TransactionDate, 106), ' ', '-')) AS [TransactionDate], FarmerInvoiceTransactions.Description, " _
            & "FarmerInvoiceTransactions.ReferenceNumber AS [Reference], FarmerInvoiceTransactions.SpecialKey, FarmerInvoiceTransactions.AccountNumber, " _
            & "FarmersData.AccountName AS [AccountName], '0' AS [Center], '' AS [CenterName], MAX(CASE WHEN FarmerInvoiceTransactions.Amount > 0 " _
            & "THEN FarmerInvoiceTransactions.Amount END) AS [Debit], MAX(CASE WHEN FarmerInvoiceTransactions.Amount < 0 " _
            & "THEN (0 - FarmerInvoiceTransactions.Amount) END) AS [Credit] FROM FarmerInvoiceTransactions " _
            & "LEFT OUTER JOIN FarmersData ON FarmerInvoiceTransactions.AccountNumber = FarmersData.AccountNumber " _
            & "WHERE FarmerInvoiceTransactions.SpecialKey = " & intSelectedSpecialKey & " " _
            & "GROUP BY FarmerInvoiceTransactions.TransactionDate, FarmerInvoiceTransactions.Description, " _
            & "FarmerInvoiceTransactions.TransactionId, FarmerInvoiceTransactions.ReferenceNumber, FarmerInvoiceTransactions.SpecialKey, " _
            & "FarmerInvoiceTransactions.AccountNumber, FarmersData.AccountName ORDER BY FarmerInvoiceTransactions.TransactionDate, " _
            & "FarmerInvoiceTransactions.TransactionId"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5), _
                           objReader(6), objReader(7), objReader(8), objReader(9), objReader(10), objReader(11))
        End While
        objReader.Close()

        strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "ReferenceNumber AS [Ref. #], Description, CAST(Amount AS DECIMAL (30,2)) AS [Amount], " _
            & "TransactionType AS [TYPE] FROM FarmerInvoiceTransactions " _
            & "WHERE AccountNumber = '" & strSelectedAccount & "' ORDER BY TransactionDate "

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

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
        gwt_comm.ShowErrorMessage()
    End Sub

End Class