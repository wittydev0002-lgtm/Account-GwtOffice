Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoanAdvancement

    Dim boolFormLoading As Boolean
    Dim dblTotalInterestPayable As Double

    Private Sub frmLoanAdvancement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        'If String.IsNullOrEmpty(strPublicLoansControlAccount) Then
        '    MessageBox.Show("You cannot advance any loan now because the loans control account has not been set. " _
        '                    & "To set it up, go to accounts menu and under setup, select Special Ledger Accounts",
        '                      "Missing Loan Control Account", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '    grpMain.Enabled = False
        '    btnOK.Enabled = False
        'Else
        grpMain.Enabled = True
        btnOK.Enabled = True
        LoadLoanAccounts()
        'LoadLoans()
        'LoadCashbooAccounts()
        'End If
        boolFormLoading = False
    End Sub

    Private Sub frmLoanAdvancement_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        '680; 480 710; 500
        Me.Width = 710
        Me.Height = 500
    End Sub

    Private Function GetCustomerName(ByVal AccountNumber As String) As String
        Dim strReturn As String = Nothing
        Dim strSql As String = "SELECT AccountName as [Customer Name] " _
            & "FROM Customers WHERE AccountNumber = '" & AccountNumber & "' AND " _
            & "CustomerType = 'LOAN' ORDER BY AccountNumber"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = UCase(objReader(0).ToString)
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "an aatempt to get the customer details has failed"
        ShowErrorMessage()
    End Function

    Private Sub cboAccountHolder_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboAccountHolder.KeyDown
        If e.KeyData = Keys.Enter Then
            txtCapital.Select()
        End If
    End Sub

    Private Sub cboAccountHolder_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAccountHolder.SelectedIndexChanged
        If boolFormLoading = True Then Exit Sub
        lblAccountLoanNumber.Text = ""
        If Not cboAccountHolder.SelectedItem Is Nothing Then
            lblAccountLoanNumber.Text = cboAccountHolder.SelectedItem.Col2
        End If
    End Sub

    Private Sub LoadLoanAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim intWidth As Integer = cboAccountHolder.Width - 105
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM LoanCustomers ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboAccountHolder
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intWidth) & ";80"
        End With

        Dim arrItems As New ArrayList

        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Get a count of the items
        Dim intItemsCount As Integer = arrItems.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboAccountHolder.Items.Clear()

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        If intItemsCount > 0 Then
            cboAccountHolder.SelectedIndex = -1
            cboAccountHolder.Items.Clear()
            cboAccountHolder.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboAccountHolder.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on loan account holders details"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(lblAccountLoanNumber.Text) Then
            MessageBox.Show("Please select the customer from the given list", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccountHolder.Select()
            Exit Sub
        End If

        'If String.IsNullOrEmpty(lblCashbookAccount.Text) Then
        '    MessageBox.Show("Please select the cashbook account", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cboCashbookAccount.Select()
        '    Exit Sub
        'End If

        'If String.IsNullOrEmpty(cboLoanType.Text) Then
        '    MessageBox.Show("Please select the loan type", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    cboLoanType.Select()
        '    Exit Sub
        'End If

        If Not IsNumeric(txtCapital.Text) Then
            MessageBox.Show("Please enter a valid value for amount advanced", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCapital.Select()
            Exit Sub
        Else
            If CInt(txtCapital.Text) <= 0 Then
                MessageBox.Show("Please enter a value greter then 0 for amount advanced", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCapital.Select()
                Exit Sub
            End If
        End If

        If Not IsNumeric(txtPeriod.Text) Then
            MessageBox.Show("Please enter a valid value for repayment period", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPeriod.Select()
            Exit Sub
        Else
            If CInt(txtPeriod.Text) <= 0 Then
                MessageBox.Show("Please enter a value greter then 0 for repayment period", "Invalid Period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtPeriod.Select()
                Exit Sub
            End If
        End If

        If Not IsNumeric(txtRate.Text) Then
            MessageBox.Show("Please enter a valid value for repayment amount", "Missing Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRate.Select()
            Exit Sub
        Else
            If CInt(txtRate.Text) <= 0 Then
                MessageBox.Show("Please enter a value greter then 0 for repayment amount", "Invalid Period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtRate.Select()
                Exit Sub
            End If
        End If

        On Error GoTo RaiseErr

        Dim intSpecialKey As Integer = gwt_comm.SpecialKey
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        Dim strDate As String = gwt_comm.shortMonthDateFormat(dpDate.Value)
        Dim strEntryType As String = "CREDIT"
        Dim dblAmount As Double = CDbl(txtCapital.Text)
        Dim strVatNumber As String = Nothing
        Dim dblVatAmount As Double = 0
        Dim intCostCenter As Integer = 0
        Dim intProjectNo As Integer = 0
        Dim strReference As String = Nothing
        Dim strDescription As String = cboAccountHolder.Text & "-" & lblAccountLoanNumber.Text

        ''Add to the cashbook as a credit
        'strSql = "INSERT INTO CashbookTransactions ([TransactionDate], [AccountNumber], [ContraAccount], " _
        '            & "[Description], [TransactionType], [CostCode], [UserReference], [VatNumber], [VatAmount], " _
        '            & "[Amount], [LinkedProject], [SpecialKey], [UserName], [UserBranch]) VALUES " _
        '            & "('" & strDate & "', '" & lblCashbookAccount.Text & "', '" & lblLoanControlAccount.Text & "', " _
        '            & "'" & strDescription & "', '" & strEntryType & "', " & intCostCenter & ", '" & strReference & "', " _
        '            & "'" & strVatNumber & "', " & dblVatAmount & ", " & dblAmount & ", " & intProjectNo & ", " _
        '            & "" & intSpecialKey & ", '" & strUserName & "', '" & strUserBranch & "')"
        'objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        'objCommand.ExecuteNonQuery()

        ''Add to the loans control account
        'strEntryType = "DEBIT"
        'strSql = "INSERT INTO LedgerTransactions ([TransactionDate], [AccountNumber], [Amount], [TransactionType], " _
        '    & "[ContraAccount], [Description], [UserName], [UserBranch], [Reference], [CostCode], [LinkedProject], " _
        '    & "[SpecialKey]) VALUES ('" & strDate & "', '" & strPublicVatControlAccount & "', " & dblAmount & ", '" & strEntryType & "', " _
        '    & "'" & lblLoanControlAccount.Text & "', '" & strDescription & "', '" & strUserName & "', '" & strUserBranch & "', " _
        '    & "'" & strReference & "', " & intCostCenter & ", " & intProjectNo & ", " & intSpecialKey & ")"
        'objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        'objCommand.ExecuteNonQuery()


        'Get the loan number 
        Dim intLoanNumber As Integer = gwt_comm.GetNextDocumentNumber("LoanNumber")

        'Add to the loans transaction account
        strSql = "INSERT LoanTransactions (AccountNumber, TransactionDate, DebitAmount, UserName, ChangeDate, SpecialKey, LoanNumber) VALUES " _
            & "('" & lblAccountLoanNumber.Text & "', '" & strDate & "', " & dblAmount & ", '" & strUserName & "', '" & Now & "', " _
            & "" & intSpecialKey & ", " & intLoanNumber & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Update load advances account
        Dim dblTotalDueValue As Double = dblTotalInterestPayable + dblAmount

        strSql = "INSERT INTO LoanAdvances ([AccountNumber], [TransactionDate], [Amount], [DueDate], [Frequency], [LoanNumber], [DueValue]) VALUES " _
            & "('" & lblAccountLoanNumber.Text & "', '" & strDate & "', " & dblAmount & ", " _
            & "'" & gwt_comm.shortMonthDateFormat(dpDueDate.Value) & "', '" & cboFrequency.Text & "', " & intLoanNumber & ", " & dblTotalDueValue & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Insert into the transactions table

        Dim dblBalanceBefore As Double = CDbl(txtCapital.Text)
        Dim dblBalanceAfter As Double = 0

        For p As Integer = 0 To dGrid.RowCount - 1
            Dim strPeriodStartDate As String = Nothing
            Dim strPeriodEndDate As String = Nothing

            Dim dblInterest As Double = 0
            Dim intPeriod As Integer = 0

            If p > 0 Then dblBalanceBefore = dblBalanceAfter

            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(0).Value.ToString) Then
                        intPeriod = CInt(dGrid.Rows(p).Cells(0).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(3).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(3).Value.ToString) Then
                        dblInterest = CDbl(dGrid.Rows(p).Cells(3).Value.ToString)
                    End If
                End If
            End If

            dblBalanceAfter = dblBalanceBefore + dblInterest

            Select Case UCase(cboFrequency.Text)
                Case Is = "WEEKLY"
                    strPeriodStartDate = gwt_comm.shortMonthDateFormat(DateAdd(DateInterval.Day, (7 * (p + 1)), dpDate.Value))
                    strPeriodEndDate = gwt_comm.shortMonthDateFormat(DateAdd(DateInterval.Day, 7, CDate(strPeriodStartDate)))
                Case Is = "MONTHLY"
                    strPeriodStartDate = gwt_comm.shortMonthDateFormat(DateAdd(DateInterval.Month, (1 * (p + 1)), dpDate.Value))
                    strPeriodEndDate = gwt_comm.shortMonthDateFormat(DateAdd(DateInterval.Month, 1, CDate(strPeriodStartDate)))
                Case Is = "ONCE-OFF"
                    strPeriodStartDate = CStr(gwt_comm.shortMonthDateFormat(dpDate.Value))
                    strPeriodEndDate = CStr(gwt_comm.shortMonthDateFormat(dpDueDate.Value))
            End Select

            strSql = "INSERT INTO LoanAmortizations ([PeriodEndDate], [Interest], [Period], [Repayment], [PaidStatus], [BalanceBefore], " _
                & "[BalanceAfter], [PrincipalPayment], [AccountNumber], [PeriodStartDate], [LoanNumber]) VALUES " _
                & "('" & strPeriodEndDate & "', " & dblInterest & ", " & intPeriod & ", 0, 'N', " & dblBalanceBefore & ", " _
                & "" & dblBalanceAfter & ", 0, '" & lblAccountLoanNumber.Text & "', '" & strPeriodStartDate & "', " & intLoanNumber & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

        Next

        'Update the loan number in the control numbers table

        strSql = "UPDATE ControlNumbers SET LoanNumber = (LoanNumber + 1)"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on loan advancement"
        ShowErrorMessage()
    End Sub

    Private Sub dpDate_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dpDate.KeyDown
        If e.KeyData = Keys.Enter Then
            cboAccountHolder.Select()
        End If
    End Sub

    Private Sub txtCapital_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCapital.KeyDown
        If e.KeyData = Keys.Enter Then
            txtPeriod.Select()
        End If
    End Sub

    Private Sub txtPeriod_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPeriod.KeyDown
        If e.KeyData = Keys.Enter Then
            txtRate.Select()
        End If
    End Sub

    Private Sub txtRepayment_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtRate.KeyDown
        If e.KeyData = Keys.Enter Then
            dGrid.Select()
        End If
    End Sub

    Private Sub Amortize()
        If IsNumeric(txtCapital.Text) And IsNumeric(txtRate.Text) And IsNumeric(txtPeriod.Text) Then
            If CDbl(txtCapital.Text) <> 0 And CDbl(txtPeriod.Text) Then
                'Evaluation leaves out interest in case there is no interest
                boolAbort = False
                ValidateControls()
                If boolAbort = True Then Exit Sub
                Dim principal As Double = CDbl(txtCapital.Text) 'amount of loan
                Dim yearlyRate As Double = CDbl(txtRate.Text) 'annual rate of interest
                Dim numMonths As Integer = CInt(txtPeriod.Text) 'number of months to repay loan
                Call InputData(principal, yearlyRate, numMonths)
                Call ShowAmortSched(principal, yearlyRate, numMonths)
            End If
        End If
    End Sub

    Private Sub ValidateControls()
        If Not IsNumeric(txtCapital.Text) Then
            MessageBox.Show("Please enter a valid numeric value for principal", "Invalid Principal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCapital.Select()
            boolAbort = True
            Exit Sub
        End If
        If Not IsNumeric(txtRate.Text) Then
            MessageBox.Show("Please enter a valid numeric value for percentage", "Invalid Interest Rate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRate.Select()
            boolAbort = True
            Exit Sub
        End If
        If Not IsNumeric(txtPeriod.Text) Then
            MessageBox.Show("Please enter a valid numeric value for period", "Invalid Period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPeriod.Select()
            boolAbort = True
            Exit Sub
        End If
    End Sub

    Private Sub InputData(ByVal prin As Double, ByVal yearlyRate As Double, ByVal numMs As Integer)
        Dim percentageRate As Double, numYears As Integer
        'input the loan amount, yearly rate of interest, and duration
        prin = CDbl(txtCapital.Text)
        percentageRate = CDbl(txtRate.Text)
        numYears = CInt(txtPeriod.Text)
        yearlyRate = percentageRate / 100
        numMs = numYears '* 12
    End Sub

    Private Function Payment(ByVal prin As Double, ByVal mRate As Double, ByVal numMs As Integer) As Double
        Dim payEst As Double
        If numMs = 0 Then
            payEst = prin
        ElseIf mRate = 0 Then
            payEst = prin / numMs
        Else
            payEst = prin * mRate / (1 - (1 + mRate) ^ (-numMs))
        End If
        If payEst <> Math.Round(payEst, 2) Then
            Payment = Math.Round(payEst + 0.005, 2) 'round up to the nearest cent
        End If
    End Function

    Private Sub ShowAmortSched(ByVal prin As Double, ByVal yearlyRate As Double, ByVal numMs As Integer)
        Dim msg As String, startmonth As Integer, mRate As Double
        Dim monthlyPayment As Double, totalInterest As Double
        Dim yearInterest As Double, oldBalance As Double
        Dim monthNum As Integer, newBalance As Double
        Dim principalPaid As Double, interestPaid As Double
        Dim reducPrin As Double, loanYears As Integer
        Dim TotalRepaymentAmt As Double
        'Display amortization schedule
        'msg = "Please enter year (1-" & Str(numMs / 12)
        'msg = msg & ") for which amortization is to be shown:"
        startmonth = 1 '12 * Val(InputBox(msg)) - 11
        With dGrid
            .Columns.Clear()
            .Rows.Clear()
            .Columns.Add("Column1", "Period")
            .Columns.Add("Column6", "Balance b/f")
            .Columns.Add("Column2", "Principal")
            .Columns.Add("Column3", "Interest")
            .Columns.Add("Column4", "Repayment")
            .Columns.Add("Column5", "Balance c/f")
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        If optAnnualInteres.Checked = True Then
            mRate = (yearlyRate / 12) / 100 'monthly rate
        Else
            mRate = (yearlyRate / 1) / 100 'once off rate
        End If

        If mRate <> 0 Then
            monthlyPayment = Payment(prin, mRate, numMs)
        Else
            monthlyPayment = prin / numMs
        End If

        txtRepaymentAmt.Text = Format(monthlyPayment, "##0.00")

        totalInterest = 0
        yearInterest = 0
        'set the number of rows
        dGrid.Rows.Add(numMs + 1)
        oldBalance = prin
        For monthNum = 1 To (dGrid.Rows.Count - 1) 'numMs
            newBalance = Balance(monthlyPayment, oldBalance, mRate)
            principalPaid = oldBalance - newBalance
            interestPaid = monthlyPayment - principalPaid
            totalInterest = totalInterest + interestPaid
            If (monthNum >= startmonth) And (monthNum <= startmonth + numMs) Then
                dGrid.Rows(monthNum - 1).Cells(0).Value = FormatNumber(monthNum, 0)
                dGrid.Rows(monthNum - 1).Cells(1).Value = FormatNumber(oldBalance, 2, , vbTrue)
                dGrid.Rows(monthNum - 1).Cells(2).Value = FormatNumber(principalPaid, 2, , , vbTrue)
                dGrid.Rows(monthNum - 1).Cells(3).Value = FormatNumber(interestPaid, 2, , , vbTrue)
                TotalRepaymentAmt = principalPaid + interestPaid
                dGrid.Rows(monthNum - 1).Cells(4).Value = FormatNumber(TotalRepaymentAmt, 2, , , vbTrue)
                dGrid.Rows(monthNum - 1).Cells(5).Value = FormatNumber(newBalance, 2, , , vbTrue)
                yearInterest = yearInterest + interestPaid
            End If
            oldBalance = newBalance
        Next monthNum
        reducPrin = numMs * monthlyPayment - yearInterest
        loanYears = numMs / 12
        lblPrincipal.Text = FormatNumber(reducPrin, 2, , , vbTrue)
        lblInterest.Text = FormatNumber(yearInterest, 2, , , vbTrue)
        dblTotalInterestPayable =yearInterest
        lblInstallment.Text = FormatNumber((numMs * monthlyPayment), 2, , , vbTrue)
        dGrid.Rows.RemoveAt(dGrid.Rows.Count - 1)
    End Sub

    Private Sub ShowInterestChanges(ByVal prin As Double, ByVal yearlyRate As Double, ByVal numMs As Integer)
        Dim newRate As Double, mRate As Double, py As Double
        Dim pymnt As String
        'grd.Cols = 2
        dGrid.Columns.Clear()
        dGrid.Rows.Clear()
        dGrid.Columns.Add("Column1", "Annual")
        dGrid.Columns.Add("Column2", "Interest")
        dGrid.Columns.Add("Column3", "Monthly")
        dGrid.Columns.Add("Column4", "Payment")
        newRate = yearlyRate - 0.01
        Do
            mRate = newRate / 12 'monthly rate
            py = Payment(prin, mRate, numMs)
            pymnt = FormatNumber(py, 2, , , vbTrue)
            dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = FormatPercent(newRate, 3)
            dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = FormatNumber(pymnt, 2, , , vbTrue)
            newRate = newRate + 0.00125
            'add 1 line to the grid
            dGrid.Rows.Add(1) ' = grd.Rows + 1
        Loop Until newRate > yearlyRate + 0.01
    End Sub

    Private Sub ShowPayment(ByVal prin As Double, ByVal yearlyRate As Double, ByVal numMs As Integer)
        Dim mRate As Double, prn As String, apr As String
        Dim yrs As String, pay As Double, pymnt As String
        'display monthly payment amount
        mRate = yearlyRate / 12 'monthly rate
        prn = FormatNumber(prin, 2, , , vbTrue)
        apr = FormatNumber((yearlyRate / 100), 4, , vbTrue)
        yrs = FormatNumber(numMs / 12, 0)
        pay = Payment(prin, (mRate / 100), numMs)
        pymnt = FormatNumber(pay, 2, , , vbTrue)
        MessageBox.Show("The monthly repayment for a " & prn & " loan at " & _
            vbCrLf & apr & "% annual rate of interest for " & vbCrLf & yrs & " years Is " & pymnt, _
            "Repayment Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub txtCapital_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCapital.GotFocus
        txtCapital.SelectAll()
    End Sub

    Private Sub txtCapital_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCapital.KeyPress
        If Asc(e.KeyChar) = 13 Then txtRate.Select()
    End Sub

    Private Sub txtCapital_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCapital.LostFocus
        txtCapital.Text = FormatNumber(Val(txtCapital.Text), 2, , , vbTrue)
    End Sub

    Private Sub txtRate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRate.GotFocus
        txtRate.SelectAll()
    End Sub

    Private Sub txtRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRate.LostFocus
        txtRate.Text = FormatNumber(Val(txtRate.Text), 2, , , vbTrue)
    End Sub

    Private Sub txtPeriod_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeriod.GotFocus
        txtPeriod.SelectAll()
    End Sub

    Private Sub txtPeriod_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeriod.LostFocus
        txtPeriod.Text = FormatNumber(Val(txtPeriod.Text), 2, , , vbTrue)
    End Sub

    Private Function Balance(ByVal mPayment As Double, ByVal prin As Double, ByVal mRate As Double) As Double
        Dim newBal As Double
        'compute balance at end of month
        newBal = (1 + mRate) * prin
        If newBal < mPayment Then
            mPayment = newBal
            Balance = 0
        Else
            Balance = newBal - mPayment
        End If
    End Function

    Private Sub txtPeriod_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPeriod.Validating
        Amortize()
    End Sub

    Private Sub txtCapital_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCapital.Validating
        Amortize()
    End Sub

    Private Sub txtRate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtRate.Validating
        Amortize()
    End Sub

    Private Sub optFullInterest_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optFullInterest.CheckedChanged
        If optFullInterest.Checked = True Then
            Amortize()
        End If
    End Sub

    Private Sub optAnnualInteres_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optAnnualInteres.CheckedChanged
        If optAnnualInteres.Checked = True Then
            Amortize()
        End If
    End Sub

    Private Sub cboFrequency_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboFrequency.KeyDown
        If e.KeyData = Keys.Enter Then
            cboAccountHolder.Select()
        End If
    End Sub

End Class
