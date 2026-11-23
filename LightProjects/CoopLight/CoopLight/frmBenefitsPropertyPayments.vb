Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBenefitsPropertyPayments

    Dim boolFormLoading As Boolean

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmBenefitsPropertyPayments_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        dpPeriodDate.Value = Now
        'Get the interest arrears to date
        GetInterestValue()
        boolFormLoading = False
    End Sub

    Private Sub GetInterestValue()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT SUM(InterestsCharged - InterestsPaid) AS [Interest] FROM BM_Financials " _
            & "WHERE PolicyNumber = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim dblInterest As Double = 0
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblInterest = CDbl(objReader(0).ToString)
        End If
        objReader.Close()
        txtInterest.Text = Format(dblInterest, "##0.00")
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Interest Amount Computation"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim intMonth As Integer = DatePart(DateInterval.Month, dpPeriodDate.Value)
        Dim intYear As Integer = DatePart(DateInterval.Year, dpPeriodDate.Value)
        Dim strDescription As String = "RECEIPT-" & UCase(MonthName(DatePart(DateInterval.Month, dpPeriodDate.Value), False))

        Dim strReferenceNumber As String = "REC" & CStr(gwt_comm.GetNextDocumentNumber("CashSales"))

        strSql = "INSERT INTO BM_Financials (PolicyNumber, CapitalPayment, AdminFees, PeriodMonth, " _
            & "PeriodYear, Reference, TransactionDate, UserName, Description, InterestsPaid) VALUES " _
            & "('" & strSelectedAccount & "', " & CDbl(txtProperty.Text) & ", " & CDbl(txtAdministration.Text) & ", " _
            & "" & intMonth & ", " & intYear & ", '" & strReferenceNumber & "', " _
            & "'" & Format(dpPeriodDate.Value, "dd-MMM-yyyy") & "', " _
            & "'" & strUserName & "', '" & strDescription & "', " & CDbl(txtInterest.Text) & ")"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Payment saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Payments Update"
        ShowErrorMessage()
    End Sub

    Private Sub txtPremium_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPremium.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnOK.Focus()
        End If
    End Sub

    Private Sub txtPremium_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPremium.TextChanged
        On Error Resume Next
        If IsNumeric(txtPremium.Text) Then
            txtBalanceAfterInterest.Text = Format(CDbl(txtPremium.Text) - CDbl(txtInterest.Text), "##0.00")

            Dim dblCapitalRate As Double = (100 - dblCoopAdminFeesRate) / 100
            Dim dblAdminRate As Double = dblCoopAdminFeesRate / 100

            Dim dblCapitalPayment As Double = CDbl(txtBalanceAfterInterest.Text) * dblCapitalRate
            Dim dblAdminFees As Double = CDbl(txtBalanceAfterInterest.Text) * dblAdminRate

            txtAdministration.Text = Format(dblAdminFees, "##0.00")
            txtProperty.Text = Format(dblCapitalPayment, "##0.00")

        End If
    End Sub

End Class
