Imports CommonLibrary .Commons 
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMicroFinanceLight

    Private Sub btnNewEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewEmployee.Click
        boolEditStatus = False
        Dim frm As New frmLoanCustomers
        frm.ShowDialog()
        LoadData("Account Number")
    End Sub

    Private Sub LoadData(ByVal OrderBy As String)
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()

        Dim strSql As String = "SELECT AccountNumber, AccountName, " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), InceptionDate, 106), ' ', '-')) as [Date In], " _
            & "Telephone, Cellphone, EmailAddress FROM LoanCustomers ORDER BY AccountName"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            With dGrid
                Dim dblAccountBalance As Double = gwt_comm.LoanBalance(objReader(0).ToString)
                .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5), Format(dblAccountBalance, "##0.00"))
            End With
        End While
        objReader.Close()
        AlternateColors()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Loan Customer Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmMicroFinanceLight_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        boolAbort = False
        Dim frm As New frmLogin
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        LoadData("Account Name")
    End Sub

    Private Sub GetSelected()
        boolEditStatus = True
        If dGrid.Rows.Count > 0 Then
            strSelectedAccount = dGrid.CurrentRow.Cells(0).Value.ToString
            Dim f As New frmLoanCustomers
            f.ShowDialog()
        End If
    End Sub

    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        GetSelected()
        LoadData("Account Name")
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        GetSelected()
        LoadData("Account Name")
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadData("Account Name")
    End Sub

    Private Sub cboSearchBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchBy.SelectedIndexChanged
        If cboSearchBy.Text = "Account Number" Then LoadData("Account Number") Else LoadData("Account Name")
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        Dim intSearchColumn As Integer = 0

        Select Case cboSearchBy.Text
            Case Is = "Account Number"
                intSearchColumn = 0
            Case Is = "Account Name"
                intSearchColumn = 1
            Case Else
                intSearchColumn = 1
        End Select
        If (Char.IsLetter(e.KeyChar)) Then
            Dim strSearchString As String = txtSearchString.Text & e.KeyChar
            For i As Integer = 0 To dGrid.Rows.Count - 1
                If dGrid.Rows(i).Cells(intSearchColumn).Value.ToString().StartsWith(strSearchString, True, System.Globalization.CultureInfo.InvariantCulture) Then
                    dGrid.CurrentCell = dGrid(0, i)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    'at period end run updates similar to the payroll to update the accounts
    '    what it means is that during the month we post the transactions to a transction after that we update the accounts file
    '    which is similar to the transaction file but differs in that it also contains zeros.
    '        - create a report link for month transactions from the menus
    '    - for the loans there  are periods that are a must to update. revie the financial calendar
    '    - create a link for setting up the interest accounts and capital accounts that are mandatory
    '    - Loan advancements affect the debtor account and the cashbook
    '    - loan repayments affect the cashbook, debtor account and the iterest account as follows:
    '        Debit Cash account
    '        Credit debtor account
    '        Credit interest account
    '    - period runs affect the following accounts
    '        debit debtor account
    '        credit interest account

    Private Sub AlternateColors()
        For i As Integer = 0 To dgrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dgrid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                dgrid.Rows(i).Cells(j).Style.BackColor = backColor
                dgrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub btnAdvance_Click(sender As System.Object, e As System.EventArgs) Handles btnAdvance.Click
        Dim frm As New frmLoanAdvancement
        frm.ShowDialog()
    End Sub

    Private Sub btnRepayment_Click(sender As System.Object, e As System.EventArgs) Handles btnRepayment.Click
        Dim frm As New frmLoanRepayment
        frm.ShowDialog()
    End Sub

    Private Sub btnOrganisation_Click(sender As System.Object, e As System.EventArgs) Handles btnOrganisation.Click
        Dim frm As New frmOrganisation
        frm.ShowDialog()
    End Sub

    Private Sub btnPrinters_Click(sender As System.Object, e As System.EventArgs) Handles btnPrinters.Click
        gwt_comm.GetPrinterSettings()
    End Sub

    Private Sub btnBackup_Click(sender As System.Object, e As System.EventArgs) Handles btnBackup.Click
        Dim frm As New frmRunBackup
        frm.ShowDialog()
    End Sub

    Private Sub btnRestore_Click(sender As System.Object, e As System.EventArgs) Handles btnRestore.Click
        Dim frm As New frmRunRestore
        frm.ShowDialog()
    End Sub

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click

        If cboViewFor.Text = Nothing Then
            MessageBox.Show("Please select the report view from the list provided", "Missing View Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboViewFor.Select()
            Exit Sub
        End If

        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Select Case UCase(cboViewFor.Text)
            Case Is = UCase("-- ALL --")
                strSql = "SELECT LoanCustomers.AccountNumber AS [Account #], LoanAdvances.LoanNumber as [Loan #], LoanCustomers.AccountName AS [Name], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), LoanAdvances.TransactionDate, 106), ' ', '-')) as [Issue Date], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), LoanAdvances.[DueDate], 106), ' ', '-')) AS [Due Date], " _
                    & "LoanAdvances.[Amount] AS [Capital], LoanAdvances.[DueValue], LoanAdvances.[DueValue] - LoanAdvances.[Amount] AS [Profit] " _
                    & "FROM LoanAdvances LEFT OUTER JOIN LoanCustomers ON LoanAdvances.AccountNumber = LoanCustomers.AccountNumber " _
                    & "WHERE LoanAdvances.TransactionDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpFrom.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpTo.Value) & "' " _
                    & "ORDER BY LoanAdvances.TransactionDate"
            Case Is = UCase("Loans Due")
                strSql = "SELECT LoanCustomers.AccountNumber AS [Account #], LoanAdvances.LoanNumber as [Loan #], LoanCustomers.AccountName AS [Name], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), LoanAdvances.TransactionDate, 106), ' ', '-')) as [Issue Date], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), LoanAdvances.[DueDate], 106), ' ', '-')) AS [Due Date], " _
                    & "LoanAdvances.[Amount] AS [Capital], LoanAdvances.[DueValue], LoanAdvances.[DueValue] - LoanAdvances.[Amount] AS [Profit] " _
                    & "FROM LoanAdvances LEFT OUTER JOIN LoanCustomers ON LoanAdvances.AccountNumber = LoanCustomers.AccountNumber " _
                    & "WHERE LoanAdvances.[DueDate] BETWEEN '" & gwt_comm.shortMonthDateFormat(dpFrom.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpTo.Value) & "' " _
                    & "ORDER BY LoanAdvances.TransactionDate"
            Case Is = UCase("Issued Loans")
                strSql = "SELECT LoanCustomers.AccountNumber AS [Account #], LoanAdvances.LoanNumber as [Loan #], LoanCustomers.AccountName AS [Name], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), LoanAdvances.TransactionDate, 106), ' ', '-')) as [Issue Date], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), LoanAdvances.[DueDate], 106), ' ', '-')) AS [Due Date], " _
                    & "LoanAdvances.[Amount] AS [Capital], LoanAdvances.[DueValue], LoanAdvances.[DueValue] - LoanAdvances.[Amount] AS [Profit] " _
                    & "FROM LoanAdvances LEFT OUTER JOIN LoanCustomers ON LoanAdvances.AccountNumber = LoanCustomers.AccountNumber " _
                    & "WHERE LoanAdvances.TransactionDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpFrom.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpTo.Value) & "' " _
                    & "ORDER BY LoanAdvances.TransactionDate"
        End Select
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        With dGridLoanList
            .Rows.Clear()
            While objReader.Read
                Dim intLoanNumber As Integer = 0
                If IsNumeric(objReader(1).ToString) Then intLoanNumber = CInt(objReader(1).ToString)

                If UCase(cboViewFor.Text) = UCase("Loans Due") Then
                    If GetInstalmentBalance(intLoanNumber) <> 0 Or GetBalanceDue(intLoanNumber) <> 0 Then
                        .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3),
                        objReader(4), objReader(5), objReader(6), objReader(7),
                        GetInstalmentBalance(intLoanNumber), GetBalanceDue(intLoanNumber))
                    End If
                Else
                    If UCase(cboViewFor.Text) = UCase("Cleared Loans") Then
                        If GetInstalmentBalance(intLoanNumber) = 0 Then
                            .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3),
                                objReader(4), objReader(5), objReader(6), objReader(7),
                                GetInstalmentBalance(intLoanNumber), GetBalanceDue(intLoanNumber))
                        End If
                    Else
                        If UCase(cboViewFor.Text) = UCase("Issued Loans") Then
                            .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3),
                                objReader(4), objReader(5), objReader(6), objReader(7),
                                GetInstalmentBalance(intLoanNumber), GetBalanceDue(intLoanNumber))
                        Else
                            .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3),
                                objReader(4), objReader(5), objReader(6), objReader(7),
                                GetInstalmentBalance(intLoanNumber), GetBalanceDue(intLoanNumber))
                        End If
                    End If
                End If
            End While
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On loan advances reporting"
        ShowErrorMessage()
    End Sub

    Private Function GetInstalmentBalance(ByVal LoanNumber As Integer) As Double
        Dim dblReturn As Double = 0
        Return dblReturn
    End Function

    Private Function GetBalanceDue(ByVal LoanNumber As Integer) As Double
        Dim dblReturn As Double = 0
        Return dblReturn
    End Function

End Class
