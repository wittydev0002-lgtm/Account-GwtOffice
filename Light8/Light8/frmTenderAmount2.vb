'Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmTenderAmount2

    Dim dblCurrencyRate As Double = 1
    Dim boolFormIsLoading As Boolean = True

    Private Sub AssignRates()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT RandRate, BondRate, TransaferRate, SwipeRate, EcocashRate, UsdRate FROM SystemKeyCurrencyRates"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblRand_Rate = CDbl(objReader(0).ToString)
            If IsNumeric(objReader(1).ToString) Then dblBond_Rate = CDbl(objReader(1).ToString)
            If IsNumeric(objReader(2).ToString) Then dblTransfer_Rate = CDbl(objReader(2).ToString)
            If IsNumeric(objReader(3).ToString) Then dblSwipe_Rate = CDbl(objReader(3).ToString)
            If IsNumeric(objReader(4).ToString) Then dblEcocash_Rate = CDbl(objReader(4).ToString)
            If IsNumeric(objReader(5).ToString) Then dblUS_Rate = CDbl(objReader(5).ToString)
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Key Rates Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub txtAmountTenderedCashUsd_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmountTenderedCashUsd.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtAmountTenderedCashRand.Focus()
        End If
    End Sub

    Private Sub txtAmountTenderedCashRand_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmountTenderedCashRand.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtAmountTenderedCashBond.Focus()
        End If
    End Sub

    Private Sub txtAmountTenderedCash_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmountTenderedCashBond.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtAmountTenderedEcocash.Focus()
        End If
    End Sub

    Private Sub txtAmountTenderedEcoCash_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmountTenderedEcocash.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtAmountTenderedSwipe.Focus()
        End If
    End Sub

    Private Sub txtAmountTenderedSwipe_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmountTenderedSwipe.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtAmountTenderedTransfer.Focus()
        End If
    End Sub

    Private Sub txtAmountTenderedTransfer_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmountTenderedTransfer.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtAmountTenderedOther.Focus()
        End If
    End Sub

    Private Sub txtAmountTenderedOther_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmountTenderedOther.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnOK.Focus()
        End If
    End Sub

    Private Sub RatedValues(ByVal SalesTotal As Double)
        txtRatedUsd.Text = Format(Math.Ceiling(SalesTotal * dblUS_Rate), "##0.00")
        txtRatedRand.Text = Format(Math.Ceiling(dblRand_Rate * SalesTotal), "##0.00")
        txtRatedBond.Text = Format(Math.Ceiling(dblBond_Rate * SalesTotal), "##0.00")
        txtRatedSwipe.Text = Format(Math.Ceiling(dblSwipe_Rate * SalesTotal), "##0.00")
        txtRatedTransfer.Text = Format(Math.Ceiling(dblTransfer_Rate * SalesTotal), "##0.00")
        txtRatedOther.Text = Format(Math.Ceiling(dblTransfer_Rate * SalesTotal), "##0.00")
        txtRatedEcocash.Text = Format(Math.Ceiling(dblEcocash_Rate * SalesTotal), "##0.00")
    End Sub

    Private Sub frmTenderAmount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boolFormIsLoading = True
        ResetValues()
        lblTotalPaid.Text = "0.00"
        txtBillTotal.Text = Format(dblSaleTotal, "##0.00")
        txtBillExchange.Text = Format(dblSaleTotal, "##0.00")
        txtAmountTenderedCashBond.Focus()
        LoadData()
        AssignRates()
        RatedValues(dblSaleTotal)
        cboCurrency.SelectedText = UCase(strDefaultCurrency)
        'cboCurrency.SelectedIndex = 0
        txtAmountTenderedCashBond.Focus()
        boolFormIsLoading = False
    End Sub

    Private Sub ResetValues()
        dblAmountTenderedCash = 0 ' Bond
        dblAmountTenderedEcoCash = 0
        dblAmountTenderedSwipe = 0
        dblAmountTenderedTransfer = 0
        dblAmountTenderedOther = 0
        dblAmountTenderedUsd = 0
        dblAmountTenderedRand = 0
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        dblAmountChange = CDbl(txtChange.Text) ' CDbl(txtChangeExchange.Text)
        dblAmountChangeBond = CDbl(txtChangeBond.Text)
        If dblAmountChange < 0 Then
            boolAbort = True
            MessageBox.Show("The change cannot be negative. The amount enter is invalid", "Invalid Amount Tendered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dblAmountTenderedCash = 0
            dblAmountTenderedEcoCash = 0
            dblAmountTenderedSwipe = 0
            dblAmountTenderedTransfer = 0
            dblAmountTenderedOther = 0
            dblAmountTenderedUsd = 0
            dblAmountTenderedRand = 0
            txtAmountTenderedCashBond.Focus()
            Exit Sub
        End If

        If dblAmountChange <> 0 Then
            boolAbort = True
            Dim frm As New frmChangeCurrency
            frm.ShowDialog()
            If boolAbort = True Then Exit Sub
        End If
        FinishSale()
    End Sub

    Private Sub FinishSale()

        If IsNumeric(txtTenderExchangeCashBond.Text) Then dblAmountTendered = CDbl(txtTenderExchangeCashBond.Text)

        strSalesCurrency = cboCurrency.Text
        dblSaleExchangeRate = dblCurrencyRate

        'Assign to the various amounts of split
        If IsNumeric(txtTenderExchangeCashBond.Text) Then dblAmountTenderedCash = CDbl(txtTenderExchangeCashBond.Text) Else dblAmountTenderedCash = 0
        If IsNumeric(txtTenderExchangeEcocash.Text) Then dblAmountTenderedEcoCash = CDbl(txtTenderExchangeEcocash.Text) Else dblAmountTenderedEcoCash = 0
        If IsNumeric(txtTenderExchangeSwipe.Text) Then dblAmountTenderedSwipe = CDbl(txtTenderExchangeSwipe.Text) Else dblAmountTenderedSwipe = 0
        If IsNumeric(txtTenderExchangeTransfer.Text) Then dblAmountTenderedTransfer = CDbl(txtTenderExchangeTransfer.Text) Else dblAmountTenderedTransfer = 0
        If IsNumeric(txtTenderExchangeOther.Text) Then dblAmountTenderedOther = CDbl(txtTenderExchangeOther.Text) Else dblAmountTenderedOther = 0
        If IsNumeric(txtTenderExchangeCashUsd.Text) Then dblAmountTenderedUsd = CDbl(txtTenderExchangeCashUsd.Text) Else dblAmountTenderedUsd = 0
        If IsNumeric(txtTenderExchangeCashRand.Text) Then dblAmountTenderedRand = CDbl(txtTenderExchangeCashRand.Text) Else dblAmountTenderedRand = 0
        '336690
        If UCase(changeCurrency) = "USD" Then
            dblAmountTenderedUsd = dblAmountTenderedUsd - dblAmountChange
        Else
            If UCase(changeCurrency) = "BOND" Then
                dblAmountTenderedCash = dblAmountTenderedCash - dblAmountChange  ' dblAmountChangeBond
            Else
                If UCase(changeCurrency) = "BOND" Then
                    dblAmountTenderedRand = dblAmountTenderedRand - dblAmountChange  ' (dblAmountTenderedUsd * dblRand_Rate)
                Else
                    'Do nothing
                End If
            End If
        End If

        'If dblAmountTenderedEcoCash <= 0 Then
        '    If dblAmountTenderedSwipe <= 0 Then
        '        If dblAmountTenderedTransfer <= 0 Then
        '            If dblAmountTenderedOther <= 0 Then
        '                dblAmountTenderedCash = CDbl(txtBillTotal.Text)
        '            End If
        '        End If
        '    End If
        'End If

        boolAbort = False
        Me.Close()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CurrencyName FROM Currencies ORDER BY CurrencyName", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboCurrency.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        cboCurrency.Text = UCase(strDefaultCurrency)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On currencies load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurrency.SelectedIndexChanged
        On Error GoTo RaiseErr
        If boolFormIsLoading = True Then Exit Sub

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CurrencyRate FROM Currencies WHERE CurrencyName = '" & cboCurrency.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblCurrencyRate = CDbl(objReader(0).ToString)
            txtBillTotal.Text = Format((dblCurrencyRate * CDbl(txtBillExchange.Text)), "##0.00")

            If IsNumeric(txtTenderExchangeCashBond.Text) Then
                If CDbl(txtTenderExchangeCashBond.Text) <> 0 Then
                    txtAmountTenderedCashBond.Text = Format(((CDbl(txtTenderExchangeCashBond.Text) * dblCurrencyRate)), "##0.00")
                    If Not IsNumeric(txtAmountTenderedCashBond.Text) Then txtAmountTenderedCashBond.Text = "0.00"
                End If
            End If

            If IsNumeric(txtTenderExchangeEcocash.Text) Then
                If CDbl(txtTenderExchangeEcocash.Text) <> 0 Then
                    txtAmountTenderedEcocash.Text = Format(((CDbl(txtTenderExchangeEcocash.Text) * dblCurrencyRate)), "##0.00")
                    If Not IsNumeric(txtAmountTenderedEcocash.Text) Then txtAmountTenderedEcocash.Text = "0.00"
                End If
            End If

            If IsNumeric(txtTenderExchangeSwipe.Text) Then
                If CDbl(txtTenderExchangeSwipe.Text) <> 0 Then
                    txtAmountTenderedSwipe.Text = Format(((CDbl(txtTenderExchangeSwipe.Text) * dblCurrencyRate)), "##0.00")
                    If Not IsNumeric(txtAmountTenderedSwipe.Text) Then txtAmountTenderedSwipe.Text = "0.00"
                End If
            End If

            If IsNumeric(txtTenderExchangeTransfer.Text) Then
                If CDbl(txtTenderExchangeTransfer.Text) <> 0 Then
                    txtAmountTenderedTransfer.Text = Format(((CDbl(txtTenderExchangeTransfer.Text) * dblCurrencyRate)), "##0.00")
                    If Not IsNumeric(txtAmountTenderedTransfer.Text) Then txtAmountTenderedTransfer.Text = "0.00"
                End If
            End If

            If IsNumeric(txtTenderExchangeOther.Text) Then
                If CDbl(txtTenderExchangeOther.Text) <> 0 Then
                    txtAmountTenderedOther.Text = Format(((CDbl(txtTenderExchangeOther.Text) * dblCurrencyRate)), "##0.00")
                    If Not IsNumeric(txtAmountTenderedOther.Text) Then txtAmountTenderedOther.Text = "0.00"
                End If
            End If

        End If
        objReader.Close()
        'If strRoundOnExchange = "YES" Then RoundValues()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On exchange computation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeChange()

        Dim dblTotalPaid As Double = 0
        If IsNumeric(txtTenderExchangeCashBond.Text) Then
            If CDbl(txtTenderExchangeCashBond.Text) <> 0 Then
                dblTotalPaid = dblTotalPaid + CDbl(txtTenderExchangeCashBond.Text)
            End If
        End If
        If IsNumeric(txtTenderExchangeEcocash.Text) Then
            If CDbl(txtTenderExchangeEcocash.Text) <> 0 Then
                dblTotalPaid = dblTotalPaid + CDbl(txtTenderExchangeEcocash.Text)
            End If
        End If
        If IsNumeric(txtTenderExchangeSwipe.Text) Then
            If CDbl(txtTenderExchangeSwipe.Text) <> 0 Then
                dblTotalPaid = dblTotalPaid + CDbl(txtTenderExchangeSwipe.Text)
            End If
        End If
        If IsNumeric(txtTenderExchangeTransfer.Text) Then
            If CDbl(txtTenderExchangeTransfer.Text) <> 0 Then
                dblTotalPaid = dblTotalPaid + CDbl(txtTenderExchangeTransfer.Text)
            End If
        End If
        If IsNumeric(txtTenderExchangeOther.Text) Then
            If CDbl(txtTenderExchangeOther.Text) <> 0 Then
                dblTotalPaid = dblTotalPaid + CDbl(txtTenderExchangeOther.Text)
            End If
        End If

        If IsNumeric(txtTenderExchangeCashUsd.Text) Then
            If CDbl(txtTenderExchangeCashUsd.Text) <> 0 Then
                dblTotalPaid = dblTotalPaid + CDbl(txtTenderExchangeCashUsd.Text)
            End If
        End If
        If IsNumeric(txtTenderExchangeCashRand.Text) Then
            If CDbl(txtTenderExchangeCashRand.Text) <> 0 Then
                dblTotalPaid = dblTotalPaid + CDbl(txtTenderExchangeCashRand.Text)
            End If
        End If

        Dim dblChange As Double = 0

        If IsNumeric(txtBillExchange.Text) Then
            dblChange = dblTotalPaid - CDbl(txtBillExchange.Text)
        Else
            dblChange = dblTotalPaid
        End If

        lblTotalPaid.Text = Format(dblTotalPaid, "#,##0.00")
        txtChange.Text = Format(dblChange, "##0.00")
        'txtChangeExchange.Text = Format((dblChange / dblBond_Rate), "##0.00")
        txtChangeBond.Text = Format((dblChange * dblBond_Rate), "##0.00")

        'ValidateExchangeValues()
        ComputeBalanceEquivalence(dblChange)

    End Sub


    '******************** Ecocash ************************************************

    Private Sub txtAmountTenderedEcoCash_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedEcocash.GotFocus
        txtAmountTenderedEcocash.SelectAll()
    End Sub

    Private Sub txtAmountTenderedEcoCash_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedEcocash.LostFocus
        If IsNumeric(txtAmountTenderedEcocash.Text) Then txtAmountTenderedEcocash.Text = Format(CDbl(txtAmountTenderedEcocash.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtAmountTenderedEcoCash_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmountTenderedEcocash.Validating
        If String.IsNullOrEmpty(txtAmountTenderedEcocash.Text) Then Exit Sub
        If Not IsNumeric(txtAmountTenderedEcocash.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTenderedEcocash.Focus()
            Exit Sub
        End If
        'Compute the values
        txtAmountTenderedEcocash.Text = Format(CDbl(txtAmountTenderedEcocash.Text), "##0.00")
        'dblAmountTenderedEcoCash = CDbl(txtAmountTenderedEcocash.Text)
        If dblEcocash_Rate <= 0 Then
            MessageBox.Show("The rate for ecocash exchange is 0", "Zero Rating", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTenderedEcocash.Text = "0.00"
            Exit Sub
        Else
            If IsNumeric(txtAmountTenderedEcocash.Text) Then
                If CDbl(txtAmountTenderedEcocash.Text) = 0 Then
                    txtTenderExchangeEcocash.Text = "0.00"
                Else
                    txtTenderExchangeEcocash.Text = Format(((CDbl(txtAmountTenderedEcocash.Text) / dblEcocash_Rate)), "##0.00")
                End If
            End If
        End If
        If dblEcocash_Rate = 0 Then txtTenderExchangeEcocash.Text = "0.00"
        ComputeChange()
    End Sub

    '******************** Swipe ************************************************

    Private Sub txtAmountTenderedSwipe_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedSwipe.GotFocus
        txtAmountTenderedSwipe.SelectAll()
    End Sub

    Private Sub txtAmountTenderedSwipe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedSwipe.LostFocus
        If IsNumeric(txtAmountTenderedSwipe.Text) Then txtAmountTenderedSwipe.Text = Format(CDbl(txtAmountTenderedSwipe.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtAmountTenderedSwipe_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmountTenderedSwipe.Validating
        If String.IsNullOrEmpty(txtAmountTenderedSwipe.Text) Then Exit Sub
        If Not IsNumeric(txtAmountTenderedSwipe.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTenderedSwipe.Focus()
            Exit Sub
        End If
        'Compute the values
        txtAmountTenderedSwipe.Text = Format(CDbl(txtAmountTenderedSwipe.Text), "##0.00")
        dblAmountTenderedSwipe = CDbl(txtAmountTenderedSwipe.Text)
        If dblSwipe_Rate <= 0 Then
            MessageBox.Show("The rate for swipe exchange is 0", "Zero Rating", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTenderExchangeSwipe.Text = "0.00"
            Exit Sub
        Else
            If IsNumeric(txtAmountTenderedSwipe.Text) Then
                If CDbl(txtAmountTenderedSwipe.Text) = 0 Then
                    txtTenderExchangeSwipe.Text = "0.00"
                Else
                    txtTenderExchangeSwipe.Text = Format(((CDbl(txtAmountTenderedSwipe.Text) / dblSwipe_Rate)), "##0.00")
                End If
            End If
        End If
        If dblSwipe_Rate = 0 Then txtTenderExchangeSwipe.Text = "0.00"
        ComputeChange()
    End Sub

    '******************** Transfer ************************************************

    Private Sub txtAmountTenderedTransfer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedTransfer.GotFocus
        txtAmountTenderedTransfer.SelectAll()
    End Sub

    Private Sub txtAmountTenderedTransfer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedTransfer.LostFocus
        If IsNumeric(txtAmountTenderedTransfer.Text) Then txtAmountTenderedTransfer.Text = Format(CDbl(txtAmountTenderedTransfer.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtAmountTenderedTransfer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmountTenderedTransfer.Validating
        If String.IsNullOrEmpty(txtAmountTenderedTransfer.Text) Then Exit Sub
        If Not IsNumeric(txtAmountTenderedTransfer.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTenderedTransfer.Focus()
            Exit Sub
        End If
        'Compute the values
        txtAmountTenderedTransfer.Text = Format(CDbl(txtAmountTenderedTransfer.Text), "##0.00")
        dblAmountTenderedTransfer = CDbl(txtAmountTenderedTransfer.Text)
        If dblTransfer_Rate <= 0 Then
            MessageBox.Show("The rate for transfer exchange is 0", "Zero Rating", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTenderedTransfer.Text = "0.00"
            Exit Sub
        Else
            If IsNumeric(txtAmountTenderedTransfer.Text) Then
                If CDbl(txtAmountTenderedTransfer.Text) = 0 Then
                    txtTenderExchangeTransfer.Text = "0.00"
                Else
                    txtTenderExchangeTransfer.Text = Format(((CDbl(txtAmountTenderedTransfer.Text) / dblTransfer_Rate)), "##0.00")
                End If
            End If
        End If
        If dblTransfer_Rate = 0 Then txtTenderExchangeTransfer.Text = "0.00"
        ComputeChange()
    End Sub

    '******************** Other ************************************************

    Private Sub txtAmountTenderedOther_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedOther.GotFocus
        txtAmountTenderedOther.SelectAll()
    End Sub

    Private Sub txtAmountTenderedOther_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedOther.LostFocus
        If IsNumeric(txtAmountTenderedOther.Text) Then txtAmountTenderedOther.Text = Format(CDbl(txtAmountTenderedOther.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtAmountTenderedOther_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmountTenderedOther.Validating
        If String.IsNullOrEmpty(txtAmountTenderedOther.Text) Then Exit Sub
        If Not IsNumeric(txtAmountTenderedOther.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTenderedOther.Focus()
            Exit Sub
        End If
        'Compute the values
        txtAmountTenderedOther.Text = Format(CDbl(txtAmountTenderedOther.Text), "##0.00")
        dblAmountTenderedOther = CDbl(txtAmountTenderedOther.Text)
        If dblTransfer_Rate <= 0 Then
            MessageBox.Show("The rate for transfer exchange is 0", "Zero Rating", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTenderExchangeOther.Text = "0.00"
            Exit Sub
        Else
            If IsNumeric(txtAmountTenderedOther.Text) Then
                If CDbl(txtAmountTenderedOther.Text) = 0 Then
                    txtTenderExchangeOther.Text = "0.00"
                Else
                    txtTenderExchangeOther.Text = Format(((CDbl(txtAmountTenderedOther.Text) / dblTransfer_Rate)), "##0.00")
                End If
            End If
        End If
        If dblTransfer_Rate = 0 Then txtTenderExchangeOther.Text = "0.00"
        ComputeChange()
    End Sub


    '******************** Bond ************************************************

    Private Sub txtAmountTenderedCashBond_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedCashBond.GotFocus
        txtAmountTenderedCashBond.SelectAll()
    End Sub

    Private Sub txtAmountTenderedCashBond_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedCashBond.LostFocus
        If IsNumeric(txtAmountTenderedCashBond.Text) Then txtAmountTenderedCashBond.Text = Format(CDbl(txtAmountTenderedCashBond.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtAmountTenderedCashBond_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmountTenderedCashBond.Validating
        If String.IsNullOrEmpty(txtAmountTenderedCashBond.Text) Then Exit Sub
        If Not IsNumeric(txtAmountTenderedCashBond.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTenderedCashBond.Focus()
            Exit Sub
        End If
        'Compute the values
        txtAmountTenderedCashBond.Text = Format(CDbl(txtAmountTenderedCashBond.Text), "##0.00")
        dblAmountTenderedOther = CDbl(txtAmountTenderedCashBond.Text)
        If dblBond_Rate <= 0 Then
            MessageBox.Show("The rate for ecocash exchange is 0", "Zero Rating", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTenderedCashBond.Text = "0.00"
            Exit Sub
        Else
            If IsNumeric(txtAmountTenderedCashBond.Text) Then
                If CDbl(txtAmountTenderedCashBond.Text) = 0 Then
                    txtTenderExchangeCashBond.Text = "0.00"
                Else
                    txtTenderExchangeCashBond.Text = Format(((CDbl(txtAmountTenderedCashBond.Text) / dblBond_Rate)), "##0.00")
                End If
            End If
        End If
        If dblBond_Rate = 0 Then txtTenderExchangeCashBond.Text = "0.00"

        ComputeChange()
    End Sub

    '******************** USD ************************************************

    Private Sub txtAmountTenderedCashUsd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedCashUsd.GotFocus
        txtAmountTenderedCashUsd.SelectAll()
    End Sub

    Private Sub txtAmountTenderedCashUsd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedCashUsd.LostFocus
        If IsNumeric(txtAmountTenderedCashUsd.Text) Then txtAmountTenderedCashUsd.Text = Format(CDbl(txtAmountTenderedCashUsd.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtAmountTenderedCashUsd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmountTenderedCashUsd.Validating
        If String.IsNullOrEmpty(txtAmountTenderedCashUsd.Text) Then Exit Sub
        If Not IsNumeric(txtAmountTenderedCashUsd.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTenderedCashUsd.Focus()
            Exit Sub
        End If
        'Compute the values
        txtAmountTenderedCashUsd.Text = Format(CDbl(txtAmountTenderedCashUsd.Text), "##0.00")
        dblAmountTenderedOther = CDbl(txtAmountTenderedCashUsd.Text)
        txtTenderExchangeCashUsd.Text = Format(((CDbl(txtAmountTenderedCashUsd.Text) / dblRand_Rate)), "##0.00")
        'ValidateExchangeValues()
        ComputeChange()
    End Sub

    '******************** USD ************************************************

    Private Sub txtAmountTenderedCashRand_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedCashRand.GotFocus
        txtAmountTenderedCashRand.SelectAll()
    End Sub

    Private Sub txtAmountTenderedCashRand_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedCashRand.LostFocus
        If IsNumeric(txtAmountTenderedCashRand.Text) Then txtAmountTenderedCashRand.Text = Format(CDbl(txtAmountTenderedCashRand.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtAmountTenderedCashRand_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmountTenderedCashRand.Validating
        If String.IsNullOrEmpty(txtAmountTenderedCashRand.Text) Then Exit Sub
        If Not IsNumeric(txtAmountTenderedCashRand.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTenderedCashRand.Focus()
            Exit Sub
        End If
        'Compute the values
        txtTenderExchangeCashRand.Text = "0.00"
        txtAmountTenderedCashRand.Text = Format(CDbl(txtAmountTenderedCashRand.Text), "##0.00")
        dblAmountTenderedOther = CDbl(txtAmountTenderedCashRand.Text)
        If dblRand_Rate <= 0 Then
            MessageBox.Show("The rate for rand exchange is 0", "Zero Rating", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTenderExchangeCashRand.Text = "0.00"
            Exit Sub
        Else
            If IsNumeric(txtAmountTenderedCashRand.Text) Then
                If CDbl(txtAmountTenderedCashRand.Text) = 0 Then
                    txtTenderExchangeCashRand.Text = "0.00"
                Else
                    txtTenderExchangeCashRand.Text = Format(((CDbl(txtAmountTenderedCashRand.Text) / dblRand_Rate)), "##0.00")
                End If
            End If
        End If
        If dblRand_Rate = 0 Then txtAmountTenderedCashRand.Text = "0.00"

        'ValidateExchangeValues()
        ComputeChange()
    End Sub


    '
    ' *************************************************
    '
    'txtAmountTenderedCashUsd, txtAmountTenderedCashRand

    Private Sub txtAmountTenderedCashUsd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountTenderedCashUsd.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAmountTenderedCashRand_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountTenderedCashRand.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAmountTenderedCash_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountTenderedCashBond.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAmountTenderedEcocash_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountTenderedEcocash.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAmountTenderedSwipe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountTenderedSwipe.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAmountTenderedTransfer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountTenderedTransfer.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAmountTenderedOther_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountTenderedOther.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub


    'Private Sub txtAmountTenderedCashBond_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedCashBond.LostFocus
    '    If IsNumeric(txtAmountTenderedCashBond.Text) Then txtAmountTenderedCashBond.Text = Format(CDbl(txtAmountTenderedCashBond.Text), "##0.00")
    '    ComputeChange()
    'End Sub

    'Private Sub txtAmountTenderedCashBond_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmountTenderedCashBond.Validating
    '    If String.IsNullOrEmpty(txtAmountTenderedCashBond.Text) Then Exit Sub
    '    If Not IsNumeric(txtAmountTenderedCashBond.Text) Then
    '        MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '        txtAmountTenderedCashBond.Focus()
    '        Exit Sub
    '    End If
    '    'Compute the values
    '    txtAmountTenderedCashBond.Text = Format(CDbl(txtAmountTenderedCashBond.Text), "##0.00")
    '    dblAmountTendered = CDbl(txtAmountTenderedCashBond.Text)
    '    txtTenderExchangeCashBond.Text = Format(((CDbl(txtAmountTenderedCashBond.Text) / dblCurrencyRate)), "##0.00")
    '    ComputeChange()
    'End Sub

    Private Sub ValidateExchangeValues()
        If Not IsNumeric(txtTenderExchangeCashUsd.Text) Then txtTenderExchangeCashUsd.Text = "0.00"
        If Not IsNumeric(txtTenderExchangeCashRand.Text) Then txtTenderExchangeCashRand.Text = "0.00"
        If Not IsNumeric(txtTenderExchangeCashBond.Text) Then txtTenderExchangeCashBond.Text = "0.00"
        If Not IsNumeric(txtTenderExchangeEcocash.Text) Then txtTenderExchangeEcocash.Text = "0.00"
        If Not IsNumeric(txtTenderExchangeSwipe.Text) Then txtTenderExchangeSwipe.Text = "0.00"
        If Not IsNumeric(txtTenderExchangeTransfer.Text) Then txtTenderExchangeTransfer.Text = "0.00"
        If Not IsNumeric(txtTenderExchangeOther.Text) Then txtTenderExchangeOther.Text = "0.00"

        If Not IsNumeric(lblTotalPaid.Text) Then lblTotalPaid.Text = "0.00"
        If Not IsNumeric(txtChange.Text) Then txtChange.Text = "0.00"
        If Not IsNumeric(txtChangeExchange.Text) Then txtChangeExchange.Text = "0.00"
        If Not IsNumeric(txtChangeBond.Text) Then txtChangeBond.Text = "0.00"
    End Sub

    Private Sub ComputeBalanceEquivalence(ByVal Balance As Double)
        txtBalUsd.Text = Format((Balance * dblCurrencyRate * -1), "##0.00")
        txtBalRand.Text = Format((Balance * dblRand_Rate * -1), "##0.00")
        txtBalBond.Text = Format((Balance * dblBond_Rate * -1), "##0.00")
        txtBalTransfer.Text = Format((Balance * dblTransfer_Rate * -1), "##0.00")
        txtBalSwipe.Text = Format((Balance * dblSwipe_Rate * -1), "##0.00")
        txtBalEcocash.Text = Format((Balance * dblEcocash_Rate * -1), "##0.00")
        txtBalOther.Text = Format((Balance * dblTransfer_Rate * -1), "##0.00")

        If IsNumeric(txtAmountTenderedCashUsd.Text) Then
            If CDbl(txtAmountTenderedCashUsd.Text) = 0 Then
                If CDbl(txtTenderExchangeCashUsd.Text) = 0 Then
                    If IsNumeric(txtBalUsd.Text) Then
                        If CDbl(txtBalUsd.Text) < 0 Then
                            txtBalUsd.Text = "0.00"
                        End If
                    End If
                End If
            End If
        End If

        If IsNumeric(txtAmountTenderedCashRand.Text) Then
            If CDbl(txtAmountTenderedCashRand.Text) = 0 Then
                If CDbl(txtTenderExchangeCashRand.Text) = 0 Then
                    If IsNumeric(txtBalRand.Text) Then
                        If CDbl(txtBalRand.Text) < 0 Then
                            txtBalRand.Text = "0.00"
                        End If
                    End If
                End If
            End If
        End If

        If IsNumeric(txtAmountTenderedCashBond.Text) Then
            If CDbl(txtAmountTenderedCashBond.Text) = 0 Then
                If CDbl(txtTenderExchangeCashBond.Text) = 0 Then
                    If IsNumeric(txtBalBond.Text) Then
                        If CDbl(txtBalBond.Text) < 0 Then
                            txtBalBond.Text = "0.00"
                        End If
                    End If
                End If
            End If
        End If

        If IsNumeric(txtAmountTenderedEcocash.Text) Then
            If CDbl(txtAmountTenderedEcocash.Text) = 0 Then
                If CDbl(txtTenderExchangeEcocash.Text) = 0 Then
                    If IsNumeric(txtBalEcocash.Text) Then
                        If CDbl(txtBalEcocash.Text) < 0 Then
                            txtBalEcocash.Text = "0.00"
                        End If
                    End If
                End If
            End If
        End If

        If IsNumeric(txtAmountTenderedSwipe.Text) Then
            If CDbl(txtAmountTenderedSwipe.Text) = 0 Then
                If CDbl(txtTenderExchangeSwipe.Text) = 0 Then
                    If IsNumeric(txtBalSwipe.Text) Then
                        If CDbl(txtBalSwipe.Text) < 0 Then
                            txtBalSwipe.Text = "0.00"
                        End If
                    End If
                End If
            End If
        End If

        If IsNumeric(txtAmountTenderedTransfer.Text) Then
            If CDbl(txtAmountTenderedTransfer.Text) = 0 Then
                If CDbl(txtTenderExchangeTransfer.Text) = 0 Then
                    If IsNumeric(txtBalTransfer.Text) Then
                        If CDbl(txtBalTransfer.Text) < 0 Then
                            txtBalTransfer.Text = "0.00"
                        End If
                    End If
                End If
            End If
        End If

        If IsNumeric(txtAmountTenderedOther.Text) Then
            If CDbl(txtAmountTenderedOther.Text) = 0 Then
                If CDbl(txtTenderExchangeOther.Text) = 0 Then
                    If IsNumeric(txtBalOther.Text) Then
                        If CDbl(txtBalOther.Text) < 0 Then
                            txtBalOther.Text = "0.00"
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub txtAmountTenderedSwipe_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAmountTenderedSwipe.TextChanged

    End Sub
End Class