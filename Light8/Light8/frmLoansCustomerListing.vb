Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoansCustomerListing

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
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Loan Customer Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmCustomersListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub btnAmortize_Click(sender As System.Object, e As System.EventArgs) Handles btnAmortize.Click
        On Error GoTo RaiseErr
        If dGrid.Rows.Count > 0 Then
            dblLoanCapitalAmt = 0
            dblLoanYears = 0
            dblLoanInterestRate = 0
            strSelectedAccount = dGrid.CurrentRow.Cells(0).Value.ToString
            Dim strSql As String = "SELECT Amount, Period, InterestRate FROM LoanAdvances WHERE AccountNumber = '" & strSelectedAccount & "'"
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                dblLoanCapitalAmt = CDbl(objReader(0).ToString)
                dblLoanYears = CDbl(objReader(1).ToString)
                dblLoanInterestRate = CDbl(objReader(2).ToString)
            End If
            objReader.Close()
            Dim frm As New frmAmortizer
            frm.ShowDialog()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Loan Amortization Schedule Show"
        ShowErrorMessage()
    End Sub

End Class
