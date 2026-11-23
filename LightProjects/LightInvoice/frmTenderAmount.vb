Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmTenderAmount

    Dim dblCurrencyRate As Double = 1
    Dim boolFormIsLoading As Boolean = True

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub txtAmountTenderedCash_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmountTenderedCash.KeyDown
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

    Private Sub frmTenderAmount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boolFormIsLoading = True
        lblTotalPaid.Text = "0.00"
        txtBillTotal.Text = Format(dblSaleTotal, "##0.00")
        txtBillExchange.Text = Format(dblSaleTotal, "##0.00")
        txtAmountTenderedCash.Focus()
        LoadData()
        cboCurrency.SelectedText = UCase(strDefaultCurrency)
        'cboCurrency.SelectedIndex = 0
        txtAmountTenderedCash.Focus()
        boolFormIsLoading = False
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        FinishSale()
    End Sub

    Private Sub FinishSale()

        If IsNumeric(txtTenderExchangeCash.Text) Then dblAmountTendered = CDbl(txtTenderExchangeCash.Text)
        dblAmountChange = CDbl(txtChangeExchange.Text)
        strSalesCurrency = cboCurrency.Text
        dblSaleExchangeRate = dblCurrencyRate

        'Assign to the various amounts of split
        If IsNumeric(txtTenderExchangeCash.Text) Then dblAmountTenderedCash = CDbl(txtTenderExchangeCash.Text) Else dblAmountTenderedCash = 0
        If IsNumeric(txtTenderExchangeEcocash.Text) Then dblAmountTenderedEcoCash = CDbl(txtTenderExchangeEcocash.Text) Else dblAmountTenderedEcoCash = 0
        If IsNumeric(txtTenderExchangeSwipe.Text) Then dblAmountTenderedSwipe = CDbl(txtTenderExchangeSwipe.Text) Else dblAmountTenderedSwipe = 0
        If IsNumeric(txtTenderExchangeTransfer.Text) Then dblAmountTenderedTransfer = CDbl(txtTenderExchangeTransfer.Text) Else dblAmountTenderedTransfer = 0
        If IsNumeric(txtTenderExchangeOther.Text) Then dblAmountTenderedOther = CDbl(txtTenderExchangeOther.Text) Else dblAmountTenderedOther = 0

        If dblAmountChange < 0 Then
            boolAbort = True
            MessageBox.Show("The change cannot be negative. The amount enter is invalid", "Invalid Amount Tendered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dblAmountTendered = 0
            dblAmountChange = 0
            txtAmountTenderedCash.Focus()
            Exit Sub
        End If

        If dblAmountTenderedEcoCash <= 0 Then
            If dblAmountTenderedSwipe <= 0 Then
                If dblAmountTenderedTransfer <= 0 Then
                    If dblAmountTenderedOther <= 0 Then
                        dblAmountTenderedCash = CDbl(txtBillTotal.Text)
                    End If
                End If
            End If
        End If

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
        ShowErrorMessage()
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

            If IsNumeric(txtTenderExchangeCash.Text) Then
                If CDbl(txtTenderExchangeCash.Text) <> 0 Then
                    txtAmountTenderedCash.Text = Format(((CDbl(txtTenderExchangeCash.Text) * dblCurrencyRate)), "##0.00")
                End If
            End If

            If IsNumeric(txtTenderExchangeEcocash.Text) Then
                If CDbl(txtTenderExchangeEcocash.Text) <> 0 Then
                    txtAmountTenderedEcocash.Text = Format(((CDbl(txtTenderExchangeEcocash.Text) * dblCurrencyRate)), "##0.00")
                End If
            End If

            If IsNumeric(txtTenderExchangeSwipe.Text) Then
                If CDbl(txtTenderExchangeSwipe.Text) <> 0 Then
                    txtAmountTenderedSwipe.Text = Format(((CDbl(txtTenderExchangeSwipe.Text) * dblCurrencyRate)), "##0.00")
                End If
            End If

            If IsNumeric(txtTenderExchangeTransfer.Text) Then
                If CDbl(txtTenderExchangeTransfer.Text) <> 0 Then
                    txtAmountTenderedTransfer.Text = Format(((CDbl(txtTenderExchangeTransfer.Text) * dblCurrencyRate)), "##0.00")
                End If
            End If

            If IsNumeric(txtTenderExchangeOther.Text) Then
                If CDbl(txtTenderExchangeOther.Text) <> 0 Then
                    txtAmountTenderedOther.Text = Format(((CDbl(txtTenderExchangeOther.Text) * dblCurrencyRate)), "##0.00")
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
        ShowErrorMessage()
    End Sub

    Private Sub ComputeChange()
        Dim dblTotalPaid As Double = 0
        If IsNumeric(txtTenderExchangeCash.Text) Then
            If CDbl(txtTenderExchangeCash.Text) <> 0 Then
                dblTotalPaid = dblTotalPaid + CDbl(txtTenderExchangeCash.Text)
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

        Dim dblChange As Double = 0

        If IsNumeric(txtBillExchange.Text) Then
            dblChange = dblTotalPaid - CDbl(txtBillExchange.Text)
        Else
            dblChange = dblTotalPaid
        End If

        txtChange.Text = Format(dblChange, "##0.00")
        txtChangeExchange.Text = Format((dblChange / dblCurrencyRate), "##0.00")

    End Sub

    Private Sub txtAmountTenderedCash_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedCash.GotFocus
        txtAmountTenderedCash.SelectAll()
    End Sub

    Private Sub txtAmountTenderedCash_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTenderedCash.LostFocus
        If IsNumeric(txtAmountTenderedCash.Text) Then txtAmountTenderedCash.Text = Format(CDbl(txtAmountTenderedCash.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtAmountTenderedCash_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmountTenderedCash.Validating
        If String.IsNullOrEmpty(txtAmountTenderedCash.Text) Then Exit Sub
        If Not IsNumeric(txtAmountTenderedCash.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTenderedCash.Focus()
            Exit Sub
        End If
        'Compute the values
        txtAmountTenderedCash.Text = Format(CDbl(txtAmountTenderedCash.Text), "##0.00")
        dblAmountTendered = CDbl(txtAmountTenderedCash.Text)
        txtTenderExchangeCash.Text = Format(((CDbl(txtAmountTenderedCash.Text) / dblCurrencyRate)), "##0.00")
        ComputeChange()
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
        dblAmountTenderedEcoCash = CDbl(txtAmountTenderedEcocash.Text)
        txtTenderExchangeEcocash.Text = Format(((CDbl(txtAmountTenderedEcocash.Text) / dblCurrencyRate)), "##0.00")
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
        txtTenderExchangeSwipe.Text = Format(((CDbl(txtAmountTenderedSwipe.Text) / dblCurrencyRate)), "##0.00")
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
        txtTenderExchangeTransfer.Text = Format(((CDbl(txtAmountTenderedTransfer.Text) / dblCurrencyRate)), "##0.00")
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
        txtTenderExchangeOther.Text = Format(((CDbl(txtAmountTenderedOther.Text) / dblCurrencyRate)), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtAmountTenderedCash_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountTenderedCash.KeyPress
        If UCase(strUserLevel) = "ADMINISTRATOR" Or UCase(strUserLevel) = "MANAGER" Then
            If e.KeyChar = "-" Then Exit Sub
        End If
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAmountTenderedEcocash_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountTenderedEcocash.KeyPress
        If UCase(strUserLevel) = "ADMINISTRATOR" Or UCase(strUserLevel) = "MANAGER" Then
            If e.KeyChar = "-" Then Exit Sub
        End If
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAmountTenderedSwipe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountTenderedSwipe.KeyPress
        If UCase(strUserLevel) = "ADMINISTRATOR" Or UCase(strUserLevel) = "MANAGER" Then
            If e.KeyChar = "-" Then Exit Sub
        End If
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAmountTenderedTransfer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountTenderedTransfer.KeyPress
        If UCase(strUserLevel) = "ADMINISTRATOR" Or UCase(strUserLevel) = "MANAGER" Then
            If e.KeyChar = "-" Then Exit Sub
        End If
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAmountTenderedOther_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmountTenderedOther.KeyPress
        If UCase(strUserLevel) = "ADMINISTRATOR" Or UCase(strUserLevel) = "MANAGER" Then
            If e.KeyChar = "-" Then Exit Sub
        End If
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

End Class