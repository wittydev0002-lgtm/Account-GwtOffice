Imports System.ComponentModel
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPosCashout

    Dim dblCurrencyRate As Double = 1
    Dim strCurrencyUsed As String = Nothing

    Private Sub frmPosCashout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        On Error GoTo RaiseErr

        lblTotalDue.Text = Format(dblSaleTotal, "##0.00")
        'btnLocalCash.Text = "ZWL" + Environment.NewLine + "Cash"
        'btnUsdCash.Text = "USD" + Environment.NewLine + "Cash"
        'btnEcocash.Text = "ECO" + Environment.NewLine + "Cash"
        'btnSwipeLocal.Text = "ZWL" + Environment.NewLine + "Swipe"
        'btnRand.Text = "RSA" + Environment.NewLine + "Rand"
        'btnPola.Text = "BW" + Environment.NewLine + "Pula"
        'btnSwipeNostro.Text = "USD" + Environment.NewLine + "Nostro"
        'btnTransfer.Text = "BANK" + Environment.NewLine + "Transfer"
        'AssignRates()
        txtTendered.Enabled = True
        'lblExchangeValue.Text = "0.00"
        txtTendered.Text = "0.00"

        chkPrintFiscal.Checked = False
        Dim strSql As String = "SELECT [FiscalStatus] FROM [RegionalTaxes] (NOLOCK)"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0)) Then
                If Not String.IsNullOrEmpty(Trim(objReader(0).ToString)) Then
                    If UCase(Trim(objReader(0).ToString)) = UCase("YES") Then
                        chkPrintFiscal.Checked = True
                    End If
                End If
            End If
        End If
        objReader.Close()

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & vbCrLf & "Error Number: " & Err.Number &
            vbCrLf & "On Company Fiscal Status Get"
        ShowErrorMessage()
    End Sub

    '    Private Sub AssignRates()
    '        On Error GoTo RaiseErr

    '        Dim strSql As String = Nothing
    '        Dim objCommand As Data.OleDb.OleDbCommand

    '        If gwt_comm.CheckColumnExistence("SystemKeyCurrencyRates", "PulaRate") = False Then
    '            strSql = "ALTER TABLE [SystemKeyCurrencyRates] ADD [PulaRate][FLOAT] NOT NULL DEFAULT 0"
    '            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
    '            objCommand.ExecuteNonQuery()
    '        End If

    '        strSql = "SELECT RandRate, BondRate, TransaferRate, SwipeRate, EcocashRate, UsdRate, PulaRate FROM SystemKeyCurrencyRates"
    '        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '        If objReader.HasRows Then
    '            objReader.Read()
    '            If IsNumeric(objReader("RandRate").ToString) Then dblRand_Rate = CDbl(objReader("RandRate").ToString)
    '            If IsNumeric(objReader("BondRate").ToString) Then dblBond_Rate = CDbl(objReader("BondRate").ToString)
    '            If IsNumeric(objReader("TransaferRate").ToString) Then dblTransfer_Rate = CDbl(objReader("TransaferRate").ToString)
    '            If IsNumeric(objReader("SwipeRate").ToString) Then dblSwipe_Rate = CDbl(objReader("SwipeRate").ToString)
    '            If IsNumeric(objReader("EcocashRate").ToString) Then dblEcocash_Rate = CDbl(objReader("EcocashRate").ToString)
    '            If IsNumeric(objReader("UsdRate").ToString) Then dblUS_Rate = CDbl(objReader("UsdRate").ToString)
    '            If IsNumeric(objReader("PulaRate").ToString) Then dblPula_Rate = CDbl(objReader("PulaRate").ToString)
    '        End If
    '        objReader.Close()
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Key Rates Load"
    '        ShowErrorMessage()
    '    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    'Private Function GetExchangeRate(ByVal CurrencyName As String) As Double
    '    Dim dblReturn As Double = 0

    '    Return dblReturn
    'End Function

    'Private Sub DefaultColors()
    '    txtTendered.Enabled = False
    '    btnTransfer.BackColor = Color.FromArgb(108, 123, 144)
    '    btnLocalCash.BackColor = Color.FromArgb(108, 123, 144)
    '    btnUsdCash.BackColor = Color.FromArgb(108, 123, 144)
    '    btnEcocash.BackColor = Color.FromArgb(108, 123, 144)
    '    btnSwipeLocal.BackColor = Color.FromArgb(108, 123, 144)
    '    btnRand.BackColor = Color.FromArgb(108, 123, 144)
    '    btnPola.BackColor = Color.FromArgb(108, 123, 144)
    '    btnSwipeNostro.BackColor = Color.FromArgb(108, 123, 144)
    'End Sub

    'Private Sub btnLocalCash_Click(sender As Object, e As EventArgs) Handles btnLocalCash.Click
    '    DefaultColors()
    '    btnLocalCash.BackColor = System.Drawing.Color.DarkGreen
    '    lblExchangeRate.Text = Format(dblBond_Rate, "#,##0.00")
    '    txtTendered.Enabled = True
    '    txtTendered.Select()
    '    lblExchangeValue.Text = Format((dblSaleTotal * dblBond_Rate), "##0.00")
    '    intPublicFiscalCurrency = 1
    '    strCurrencyUsed = "ZWL"
    'End Sub

    'Private Sub btnUsdCash_Click(sender As Object, e As EventArgs) Handles btnUsdCash.Click
    '    DefaultColors()
    '    btnUsdCash.BackColor = System.Drawing.Color.DarkGreen
    '    lblExchangeRate.Text = Format(dblUS_Rate, "#,##0.00")
    '    txtTendered.Enabled = True
    '    txtTendered.Select()
    '    lblExchangeValue.Text = Format((dblSaleTotal * dblUS_Rate), "##0.00")
    '    intPublicFiscalCurrency = 2
    '    strCurrencyUsed = "USD"
    'End Sub

    'Private Sub btnEcocash_Click(sender As Object, e As EventArgs) Handles btnEcocash.Click
    '    DefaultColors()
    '    btnEcocash.BackColor = System.Drawing.Color.DarkGreen
    '    lblExchangeRate.Text = Format(dblEcocash_Rate, "#,##0.00")
    '    txtTendered.Enabled = True
    '    txtTendered.Select()
    '    lblExchangeValue.Text = Format((dblSaleTotal * dblEcocash_Rate), "##0.00")
    '    intPublicFiscalCurrency = 1
    '    strCurrencyUsed = "ZWL-ECOCASH"
    'End Sub

    'Private Sub btnSwipeLocal_Click(sender As Object, e As EventArgs) Handles btnSwipeLocal.Click
    '    DefaultColors()
    '    btnSwipeLocal.BackColor = System.Drawing.Color.DarkGreen
    '    lblExchangeRate.Text = Format(dblSwipe_Rate, "#,##0.00")
    '    txtTendered.Enabled = True
    '    txtTendered.Select()
    '    lblExchangeValue.Text = Format((dblSaleTotal * dblSwipe_Rate), "##0.00")
    '    intPublicFiscalCurrency = 1
    '    strCurrencyUsed = "ZWL-SWIPE"
    'End Sub

    'Private Sub btnRand_Click(sender As Object, e As EventArgs) Handles btnRand.Click
    '    DefaultColors()
    '    btnRand.BackColor = System.Drawing.Color.DarkGreen
    '    lblExchangeRate.Text = Format(dblRand_Rate, "#,##0.00")
    '    txtTendered.Enabled = True
    '    txtTendered.Select()
    '    lblExchangeValue.Text = Format((dblSaleTotal * dblRand_Rate), "##0.00")
    '    intPublicFiscalCurrency = 3
    '    strCurrencyUsed = "RAND"
    'End Sub

    'Private Sub btnPola_Click(sender As Object, e As EventArgs) Handles btnPola.Click
    '    DefaultColors()
    '    btnPola.BackColor = System.Drawing.Color.DarkGreen
    '    lblExchangeRate.Text = Format(dblPula_Rate, "#,##0.00")
    '    txtTendered.Enabled = True
    '    lblExchangeValue.Text = Format((dblSaleTotal * dblPula_Rate), "##0.00")
    '    intPublicFiscalCurrency = 4
    '    strCurrencyUsed = "PULA"
    'End Sub

    'Private Sub btnSwipeNostro_Click(sender As Object, e As EventArgs) Handles btnSwipeNostro.Click
    '    DefaultColors()
    '    btnSwipeNostro.BackColor = System.Drawing.Color.DarkGreen
    '    lblExchangeRate.Text = Format(dblUS_Rate, "#,##0.00")
    '    txtTendered.Enabled = True
    '    lblExchangeValue.Text = Format((dblSaleTotal * dblUS_Rate), "##0.00")
    '    intPublicFiscalCurrency = 2
    '    strCurrencyUsed = "USD-SWIPE"
    'End Sub

    'Private Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click
    '    DefaultColors()
    '    btnTransfer.BackColor = System.Drawing.Color.DarkGreen
    '    lblExchangeRate.Text = Format(dblTransfer_Rate, "#,##0.00")
    '    txtTendered.Enabled = True
    '    lblExchangeValue.Text = Format((dblSaleTotal * dblTransfer_Rate), "##0.00")
    '    intPublicFiscalCurrency = 1
    '    strCurrencyUsed = "ZWL-TRANSFER"
    'End Sub

    Private Sub btnCashout_Click(sender As Object, e As EventArgs) Handles btnCashout.Click
        'If Not IsNumeric(lblExchangeValue.Text) Then
        '    MessageBox.Show("Application failed to make the desired currency conversions",
        '            "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'If IsNumeric(lblExchangeValue.Text) Then
        '    If CDbl(lblExchangeValue.Text) <= 0 Then
        '        MessageBox.Show("The converted receipt value must be greater than zero",
        '            "Conversion Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Exit Sub
        '    End If
        'End If

        printToFiscalPrinter = False
        If chkPrintFiscal.Checked = True Then
            printToFiscalPrinter = True
        End If

        If Not IsNumeric(txtTendered.Text) Then
            MessageBox.Show("Please enter the payment amount",
                    "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If IsNumeric(txtTendered.Text) Then
            If CDbl(txtTendered.Text) <= 0 Then
                MessageBox.Show("Tender amount cannot be zero or less",
                    "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        dblAmountChange = CDbl(txtChange.Text)
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
            txtTendered.Select()
            txtTendered.SelectAll()
            Exit Sub
        End If

        strSalesCurrency = strCurrencyUsed
        'dblSaleExchangeRate = CDbl(lblExchangeRate.Text)

        'If Not IsNumeric(lblExchangeValue.Text) Then lblExchangeValue.Text = "0.00"

        '
        ' Assign to the various amounts of split
        '
        dblAmountTenderedCash = 0
        dblAmountTenderedEcoCash = 0
        dblAmountTenderedSwipe = 0
        dblAmountTenderedTransfer = 0
        dblAmountTenderedOther = 0
        dblAmountTenderedUsd = 0
        dblAmountTenderedRand = 0
        dblAmountTenderedUsd = 0

        Select Case UCase(strCurrencyUsed)
            Case = UCase("ZWL")
                dblAmountTenderedCash = CDbl(txtTendered.Text)
            Case = UCase("ZWL-ECOCASH")
                dblAmountTenderedEcoCash = CDbl(txtTendered.Text)
            Case = UCase("ZWL-SWIPE")
                dblAmountTenderedSwipe = CDbl(txtTendered.Text)
            Case = UCase("ZWL-TRANSFER")
                dblAmountTenderedTransfer = CDbl(txtTendered.Text)
            Case = UCase("PULA")
                dblAmountTenderedOther = CDbl(txtTendered.Text)
            Case = UCase("USD")
                dblAmountTenderedUsd = CDbl(txtTendered.Text)
            Case = UCase("RAND")
                dblAmountTenderedRand = CDbl(txtTendered.Text)
            Case = UCase("USD-SWIPE")
                dblAmountTenderedUsd = CDbl(txtTendered.Text)
        End Select

        'dblReceiptValue = CDbl(lblExchangeValue.Text)
        'dblActiveExchangeRate = CDbl(lblExchangeRate.Text)

        boolAbort = False
        Me.Close()
    End Sub

    Private Sub txtTendered_Validating(sender As Object, e As CancelEventArgs) Handles txtTendered.Validating
        txtChange.Text = "0.00"
        If IsNumeric(txtTendered.Text) Then
            txtTendered.Text = Format(CDbl(txtTendered.Text), "##0.00")
            'If IsNumeric(lblExchangeValue.Text) Then
            txtChange.Text = Format((CDbl(txtTendered.Text) - CDbl(lblTotalDue.Text)), "##0.00")
            btnCashout.Select()
            'End If
        End If
    End Sub

    Private Sub txtTendered_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTendered.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnCashout.Focus()
        End If
    End Sub

End Class