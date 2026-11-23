Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMembershipBilling

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to update these period bills", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim intMonth As Integer = DatePart(DateInterval.Month, dpPeriodDate.Value)
            Dim intYear As Integer = DatePart(DateInterval.Year, dpPeriodDate.Value)
            Dim strDescription As String = "INVOICE-" & UCase(MonthName(DatePart(DateInterval.Month, dpPeriodDate.Value), False))

            Dim strSql As String = Nothing
            If UCase(strBillingMethod) = "ALL" Then
                strSql = "SELECT BM_Master.PolicyNumber, BM_Master.PeriodPremiums, BM_Master.InterestRate FROM BM_Master " _
                    & "ORDER BY BM_Master.PolicyNumber"
            Else
                strSql = "SELECT BM_Master.PolicyNumber, BM_Master.PeriodPremiums, BM_Master.InterestRate FROM BM_Master " _
                    & "WHERE BM_Master.PolicyNumber = '" & strSelectedAccount & "' ORDER BY BM_Master.PolicyNumber"
            End If

            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            Dim intStartingNumber As Integer = 1
            While objReader.Read
                ' ''Check last period payments and see whether paid and if not charge interest
                ''strSql = "SELECT TransactionDate, PeriodYear, PeriodMonth, Amount FROM BM_Financials " _
                ''    & "WHERE Amount <> 0 AND PolicyNumber = '" & objReader(0).ToString & "' " _
                ''    & "ORDER BY PeriodYear , PeriodMonth DESC"

                ''Dim intPastMonth As Integer = 0
                ''Dim intPastYear As Integer = 0
                ''Dim dblPastBilling As Double = 0
                ''Dim dblPastPayment As Double = 0
                ''objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                ''Dim objReadInterest As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                ''If objReadInterest.HasRows Then
                ''    objReadInterest.Read()
                ''    If IsNumeric(objReadInterest(2).ToString) Then intPastMonth = CInt(objReadInterest(2).ToString)
                ''    If IsNumeric(objReadInterest(1).ToString) Then intPastYear = CInt(objReadInterest(1).ToString)
                ''    If IsNumeric(objReadInterest(3).ToString) Then dblPastBilling = CDbl(objReadInterest(3).ToString)
                ''End If
                ''objReadInterest.Close()
                ''If intPastMonth > 0 And intPastYear > 0 Then
                ''    strSql = "SELECT SUM(CapitalPayment + AdminFees) AS [Paid] FROM BM_Financials " _
                ''        & "WHERE (CapitalPayment + AdminFees) > 0 AND PolicyNumber = '" & objReader(0).ToString & "' " _
                ''        & "AND PeriodMonth = " & intPastMonth & " AND PeriodYear = " & intPastYear & ""
                ''    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                ''    Dim objReadPayment As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                ''    If objReadPayment.HasRows Then
                ''        objReadPayment.Read()
                ''        If IsNumeric(objReadPayment(0).ToString) Then dblPastPayment = CDbl(objReadPayment(0).ToString)
                ''    End If
                ''    objReadInterest.Close()
                ''End If

                strSql = "SELECT SUM(Amount - (CapitalPayment + AdminFees)) AS Balance FROM BM_Financials " _
                    & "WHERE PolicyNumber = '" & objReader(0).ToString & "'"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                Dim objReadBalance As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                Dim dblAmountToChargeInterest As Double = 0
                If objReadBalance.HasRows Then
                    objReadBalance.Read()
                    If IsNumeric(objReadBalance(0).ToString) Then dblAmountToChargeInterest = CDbl(objReadBalance(0).ToString)
                End If
                objReadBalance.Close()

                'Charge interest per individual
                Dim dblCurrentMemberInterestRate As Double = dblCoopOverdueSubsInterest
                If IsNumeric(objReader("InterestRate").ToString) Then
                    If CDbl(objReader("InterestRate").ToString) <> 0 Then
                        dblCurrentMemberInterestRate = CDbl(objReader("InterestRate").ToString)
                    End If
                End If

                Dim dblInterestCharge As Double = 0
                If dblAmountToChargeInterest > 0 Then
                    dblInterestCharge = dblAmountToChargeInterest * (dblCurrentMemberInterestRate / 100)
                End If
                '
                'Check that the interest effective date is within date range
                '
                Dim dtEffectiveDate As Date = "01-JAN-2001"
                objCommand = New Data.OleDb.OleDbCommand("SELECT BM_Interest_Parms.InterestEffectiveDate FROM BM_Interest_Parms", cnn)
                Dim objReadDate As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReadDate.HasRows Then
                    objReadDate.Read()
                    If IsDate(objReadDate(0).ToString) Then
                        dtEffectiveDate = CDate(objReadDate(0).ToString)
                    End If
                End If
                objReadDate.Close()

                'Zero interest charged if the date is before
                If CDate(Format(dpPeriodDate.Value, "dd-MMM-yyyy")) < dtEffectiveDate Then
                    dblInterestCharge = 0
                End If

                Dim strReferenceNumber As String = "INV" & Format(intStartingNumber, "000000")
                strSql = "INSERT INTO BM_Financials (PolicyNumber, Amount, PeriodMonth, " _
                    & "PeriodYear, Reference, TransactionDate, UserName, Description, InterestsCharged) VALUES " _
                    & "('" & objReader(0).ToString & "', " & objReader(1).ToString & ", " _
                    & "" & intMonth & ", " & intYear & ", '" & strReferenceNumber & "', " _
                    & "'" & Format(dpPeriodDate.Value, "dd-MMM-yyyy") & "', " _
                    & "'" & strUserName & "', '" & strDescription & "', " & dblInterestCharge & ")"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                intStartingNumber = intStartingNumber + 1
            End While
            objReader.Close()
            MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Benefits Management Member Billings"
        ShowErrorMessage()
    End Sub

    Private Sub frmMembershipBilling_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dpPeriodDate.Value = Now
    End Sub

End Class
