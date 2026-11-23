Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmAmortizer

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

    'Private Sub btnAmort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAmort.Click
    Private Sub Amortize()
        boolAbort = False
        ValidateControls()
        If boolAbort = True Then Exit Sub
        Dim principal As Double = CDbl(txtAmt.Text) 'amount of loan
        Dim yearlyRate As Double = CDbl(txtApr.Text) 'annual rate of interest
        Dim numMonths As Integer = CInt(txtYrs.Text) 'number of months to repay loan
        Call InputData(principal, yearlyRate, numMonths)
        Call ShowAmortSched(principal, yearlyRate, numMonths)
    End Sub

    'Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
    Private Sub Repayment()
        boolAbort = False
        ValidateControls()
        If boolAbort = True Then Exit Sub
        Dim principal As Double = CDbl(txtAmt.Text) 'amount of loan
        Dim yearlyRate As Double = CDbl(txtApr.Text) 'annual rate of interest
        Dim numMonths As Integer = CInt(txtYrs.Text) 'number of months to repay loan
        Call InputData(principal, yearlyRate, numMonths)
        Call ShowPayment(principal, yearlyRate, numMonths)
    End Sub

    'Private Sub btnRateTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRateTable.Click

    Private Sub ComputeData()
        boolAbort = False
        ValidateControls()
        If boolAbort = True Then Exit Sub
        Dim principal As Double = CDbl(txtAmt.Text) 'amount of loan
        Dim yearlyRate As Double = CDbl(txtApr.Text) 'annual rate of interest
        Dim numMonths As Integer = CInt(txtYrs.Text) 'number of months to repay loan
        Call InputData(principal, yearlyRate, numMonths)
        Call ShowAmortSched(principal, yearlyRate, numMonths)
    End Sub

    Private Sub InputData(ByVal prin As Double, ByVal yearlyRate As Double, ByVal numMs As Integer)
        Dim percentageRate As Double, numYears As Integer
        'input the loan amount, yearly rate of interest, and duration
        prin = CDbl(txtAmt.Text)
        percentageRate = CDbl(txtApr.Text)
        numYears = CInt(txtYrs.Text)
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
        With grd
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
        mRate = (yearlyRate / 12) / 100 'monthly rate
        monthlyPayment = Payment(prin, mRate, numMs)
        totalInterest = 0
        yearInterest = 0
        'set the number of rows
        grd.Rows.Add(numMs + 1)
        oldBalance = prin
        For monthNum = 1 To (grd.Rows.Count - 1) 'numMs
            newBalance = Balance(monthlyPayment, oldBalance, mRate)
            principalPaid = oldBalance - newBalance
            interestPaid = monthlyPayment - principalPaid
            totalInterest = totalInterest + interestPaid
            If (monthNum >= startmonth) And (monthNum <= startmonth + numMs) Then
                grd.Rows(monthNum - 1).Cells(0).Value = FormatNumber(monthNum, 0)
                grd.Rows(monthNum - 1).Cells(1).Value = FormatNumber(oldBalance, 2, , vbTrue)
                grd.Rows(monthNum - 1).Cells(2).Value = FormatNumber(principalPaid, 2, , , vbTrue)
                grd.Rows(monthNum - 1).Cells(3).Value = FormatNumber(interestPaid, 2, , , vbTrue)
                TotalRepaymentAmt = principalPaid + interestPaid
                grd.Rows(monthNum - 1).Cells(4).Value = FormatNumber(TotalRepaymentAmt, 2, , , vbTrue)
                grd.Rows(monthNum - 1).Cells(5).Value = FormatNumber(newBalance, 2, , , vbTrue)
                yearInterest = yearInterest + interestPaid
            End If
            oldBalance = newBalance
        Next monthNum
        reducPrin = numMs * monthlyPayment - yearInterest
        loanYears = numMs / 12
        lblPrincipal.Text = FormatNumber(reducPrin, 2, , , vbTrue)
        lblInterest.Text = FormatNumber(yearInterest, 2, , , vbTrue)
        lblInstallment.Text = FormatNumber((numMs * monthlyPayment), 2, , , vbTrue)
        grd.Rows.RemoveAt(grd.Rows.Count - 1)
    End Sub

    Private Sub ShowInterestChanges(ByVal prin As Double, ByVal yearlyRate As Double, ByVal numMs As Integer)
        Dim newRate As Double, mRate As Double, py As Double
        Dim pymnt As String
        'grd.Cols = 2
        grd.Columns.Clear()
        grd.Rows.Clear()
        grd.Columns.Add("Column1", "Annual")
        grd.Columns.Add("Column2", "Interest")
        grd.Columns.Add("Column3", "Monthly")
        grd.Columns.Add("Column4", "Payment")
        newRate = yearlyRate - 0.01
        Do
            mRate = newRate / 12 'monthly rate
            py = Payment(prin, mRate, numMs)
            pymnt = FormatNumber(py, 2, , , vbTrue)
            grd.Rows(grd.Rows.Count - 1).Cells(0).Value = FormatPercent(newRate, 3)
            grd.Rows(grd.Rows.Count - 1).Cells(1).Value = FormatNumber(pymnt, 2, , , vbTrue)
            newRate = newRate + 0.00125
            'add 1 line to the grid
            grd.Rows.Add(1) ' = grd.Rows + 1
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

    Private Sub txtAmt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmt.GotFocus
        txtAmt.SelectAll()
    End Sub

    Private Sub txtAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then txtApr.Focus()
    End Sub

    Private Sub txtAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmt.LostFocus
        txtAmt.Text = FormatNumber(Val(txtAmt.Text), 2, , , vbTrue)
    End Sub

    Private Sub txtApr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApr.GotFocus
        txtApr.SelectAll()
    End Sub

    Private Sub txtApr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApr.KeyPress
        If Asc(e.KeyChar) = 13 Then txtYrs.Focus()
    End Sub

    Private Sub txtApr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApr.LostFocus
        txtApr.Text = FormatNumber(Val(txtApr.Text), 2, , , vbTrue)
    End Sub

    Private Sub txtYrs_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYrs.GotFocus
        txtYrs.SelectAll()
    End Sub

    Private Sub txtYrs_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYrs.LostFocus
        txtYrs.Text = FormatNumber(Val(txtYrs.Text), 2, , , vbTrue)
    End Sub

    Private Sub ValidateControls()
        If Not IsNumeric(txtAmt.Text) Then
            MessageBox.Show("Please enter a valid numeric value for amount", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmt.Focus()
            boolAbort = True
            Exit Sub
        End If
        If Not IsNumeric(txtApr.Text) Then
            MessageBox.Show("Please enter a valid numeric value for percentage", "Invalid Percentage", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtApr.Focus()
            boolAbort = True
            Exit Sub
        End If
        If Not IsNumeric(txtYrs.Text) Then
            MessageBox.Show("Please enter a valid numeric value for period", "Invalid Period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtYrs.Focus()
            boolAbort = True
            Exit Sub
        End If
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        If grd.Rows.Count <= 0 Then Exit Sub
        'gwt_comm.PrintDataGrid(grd, "LOAN AMORTIZATION SCHEDULE")
    End Sub

    Private Sub frmAmortizer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtAmt.Text = dblLoanCapitalAmt
        txtYrs.Text = dblLoanYears
        txtApr.Text = dblLoanInterestRate
        ComputeData()
    End Sub

End Class