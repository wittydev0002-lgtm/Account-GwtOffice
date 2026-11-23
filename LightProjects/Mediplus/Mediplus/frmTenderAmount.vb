Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmTenderAmount

    Dim dblCurrencyRate As Double = 1
    Dim boolFormIsLoading As Boolean = True

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Cursor = Cursors.Default
        Me.Close()
    End Sub

    Private Sub txtAmountTendered_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTendered.GotFocus
        txtAmountTendered.SelectAll()
    End Sub

    Private Sub txtAmountTendered_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmountTendered.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAmountTendered_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountTendered.LostFocus
        If IsNumeric(txtAmountTendered.Text) Then txtAmountTendered.Text = Format(CDbl(txtAmountTendered.Text), "##0.00")
    End Sub

    Private Sub txtAmountTendered_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmountTendered.Validating
        If String.IsNullOrEmpty(txtAmountTendered.Text) Then Exit Sub
        If Not IsNumeric(txtAmountTendered.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTendered.Focus()
            Exit Sub
        Else
            'Compute the values
            txtAmountTendered.Text = Format(CDbl(txtAmountTendered.Text), "##0.00")
            dblAmountTendered = CDbl(txtAmountTendered.Text)
            txtTenderExchange.Text = Format(((CDbl(txtAmountTendered.Text) / dblCurrencyRate)), "##0.00")
            dblAmountChange = CDbl(txtAmountTendered.Text) - CDbl(txtBillTotal.Text)
            txtChange.Text = Format(dblAmountChange, "##0.00")
            txtChangeExchange.Text = Format(((CDbl(txtChange.Text) / dblCurrencyRate)), "##0.00")
            If strRoundOnExchange = "YES" Then RoundValues()
            If strRoundOnExchange = "YES" Then
                dblAmountTendered = Math.Round(dblAmountTendered, 0)
                dblAmountChange = Math.Round(dblAmountChange, 0)
            End If
        End If
    End Sub

    Private Sub frmTenderAmount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        boolFormIsLoading = True
        txtBillTotal.Text = Format(dblSaleTotal, "##0.00")
        txtBillExchange.Text = Format(dblSaleTotal, "##0.00")
        txtAmountTendered.Focus()
        LoadData()
        cboCurrency.Text = UCase(strDefaultCurrency)
        boolFormIsLoading = False
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        FinishSale()
    End Sub

    Private Sub FinishSale()
        If String.IsNullOrEmpty(cboCurrency.Text) Then
            MessageBox.Show("Please select the currency tendered", "Missing Tender Currency", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCurrency.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtTenderExchange.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmountTendered.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboPaymentMethod.Text) Then
            MessageBox.Show("Please select the payment method", "Missing Payment Method", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPaymentMethod.Focus()
            Exit Sub
        End If
        dblAmountTendered = CDbl(txtTenderExchange.Text)
        dblAmountChange = CDbl(txtChangeExchange.Text)
        strSalesCurrency = cboCurrency.Text
        dblSaleExchangeRate = dblCurrencyRate
        strTillPaymentMethod = cboPaymentMethod.Text
        'If Not String.IsNullOrEmpty(txtPhoneNumber.Text) Then strCustomerTelephoneNumber = txtPhoneNumber.Text
        'If Not String.IsNullOrEmpty(txtName.Text) Then strTillCustomerName = txtName.Text
        If dblAmountChange < 0 Then
            boolAbort = True
            MessageBox.Show("The change cannot be negative. The amount enter is invalid", "Invalid Amount Tendered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dblAmountTendered = 0
            dblAmountChange = 0
            txtAmountTendered.Focus()
            Exit Sub
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

    Private Sub txtPhoneNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub cboCurrency_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCurrency.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtAmountTendered.Focus()
        End If
    End Sub

    Private Sub cboCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurrency.SelectedIndexChanged
        On Error GoTo RaiseErr
        If boolFormIsLoading = True Then Exit Sub
        'txtBillExchange.Clear() : txtChangeExchange.Clear() : txtTenderExchange.Clear()
        'txtBillExchange.Text = "0.00"
        'txtChangeExchange.Text = "0.00"
        'txtTenderExchange.Text = "0.00"

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CurrencyRate FROM Currencies WHERE CurrencyName = '" & cboCurrency.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblCurrencyRate = CDbl(objReader(0).ToString)
            txtBillTotal.Text = Format((dblCurrencyRate * CDbl(txtBillExchange.Text)), "##0.00")

            If IsNumeric(txtTenderExchange.Text) Then
                If CDbl(txtTenderExchange.Text) <> 0 Then
                    txtAmountTendered.Text = Format(((CDbl(txtTenderExchange.Text) * dblCurrencyRate)), "##0.00")
                End If
            End If

            If IsNumeric(txtChangeExchange.Text) Then
                If CDbl(txtChangeExchange.Text) <> 0 Then
                    txtChange.Text = Format(((CDbl(txtChangeExchange.Text) * dblCurrencyRate)), "##0.00")
                End If
            End If
        End If
        objReader.Close()
        If strRoundOnExchange = "YES" Then RoundValues()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On exchange computation"
        ShowErrorMessage()
    End Sub

    Private Sub frmScannedSales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F3 Then
            FinishSale()
        End If
        If e.KeyValue = Keys.F8 Then
            boolAbort = True
            Me.Close()
        End If
    End Sub

    Private Sub RoundValues()
        If IsNumeric(txtAmountTendered.Text) Then
            txtAmountTendered.Text = Format((Math.Round(CDbl(txtAmountTendered.Text), 0)), "##0.00")
        End If

        If IsNumeric(txtBillTotal.Text) Then
            txtBillTotal.Text = Format((Math.Round(CDbl(txtBillTotal.Text), 0)), "##0.00")
        End If

        If IsNumeric(txtChange.Text) Then
            txtChange.Text = Format((Math.Round(CDbl(txtChange.Text), 0)), "##0.00")
        End If

        If IsNumeric(txtTenderExchange.Text) Then
            txtTenderExchange.Text = Format((Math.Round(CDbl(txtTenderExchange.Text), 0)), "##0.00")
        End If

        If IsNumeric(txtBillExchange.Text) Then
            txtBillExchange.Text = Format((Math.Round(CDbl(txtBillExchange.Text), 0)), "##0.00")
        End If

        If IsNumeric(txtChangeExchange.Text) Then
            txtChangeExchange.Text = Format((Math.Round(CDbl(txtChangeExchange.Text), 0)), "##0.00")
        End If
    End Sub

    Private Sub txtAmountTendered_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmountTendered.KeyDown
        If e.KeyData = Keys.Enter Then
            cboPaymentMethod.Focus()
        End If
    End Sub

    Private Sub cboPaymentMethod_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboPaymentMethod.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnOK.Focus()
        End If
    End Sub
End Class