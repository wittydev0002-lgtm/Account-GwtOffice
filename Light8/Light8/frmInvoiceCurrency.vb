Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInvoiceCurrency

    Dim dblCurrencyRate As Double = 1
    Dim strCurrencyUsed As String = Nothing

    Private Sub frmInvoiceCurrency_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnLocalCash.Text = "ZIG" + Environment.NewLine + "Cash"
        btnUsdCash.Text = "USD" + Environment.NewLine + "Cash"
        btnEcocash.Text = "ECO" + Environment.NewLine + "Cash"
        btnSwipeLocal.Text = "ZIG" + Environment.NewLine + "Swipe"
        btnRand.Text = "RSA" + Environment.NewLine + "Rand"
        btnPola.Text = "BW" + Environment.NewLine + "Pula"
        btnSwipeNostro.Text = "USD" + Environment.NewLine + "Nostro"
        btnTransfer.Text = "BANK" + Environment.NewLine + "Transfer"
        AssignRates()
    End Sub

    Private Sub AssignRates()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If gwt_comm.CheckColumnExistence("SystemKeyCurrencyRates", "PulaRate") = False Then
            strSql = "ALTER TABLE [SystemKeyCurrencyRates] ADD [PulaRate][FLOAT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        strSql = "SELECT RandRate, BondRate, TransaferRate, SwipeRate, EcocashRate, UsdRate, PulaRate FROM SystemKeyCurrencyRates"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader("RandRate").ToString) Then dblRand_Rate = CDbl(objReader("RandRate").ToString)
            If IsNumeric(objReader("BondRate").ToString) Then dblBond_Rate = CDbl(objReader("BondRate").ToString)
            If IsNumeric(objReader("TransaferRate").ToString) Then dblTransfer_Rate = CDbl(objReader("TransaferRate").ToString)
            If IsNumeric(objReader("SwipeRate").ToString) Then dblSwipe_Rate = CDbl(objReader("SwipeRate").ToString)
            If IsNumeric(objReader("EcocashRate").ToString) Then dblEcocash_Rate = CDbl(objReader("EcocashRate").ToString)
            If IsNumeric(objReader("UsdRate").ToString) Then dblUS_Rate = CDbl(objReader("UsdRate").ToString)
            If IsNumeric(objReader("PulaRate").ToString) Then dblPula_Rate = CDbl(objReader("PulaRate").ToString)
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Key Rates Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub DefaultColors()
        btnTransfer.BackColor = Color.FromArgb(108, 123, 144)
        btnLocalCash.BackColor = Color.FromArgb(108, 123, 144)
        btnUsdCash.BackColor = Color.FromArgb(108, 123, 144)
        btnEcocash.BackColor = Color.FromArgb(108, 123, 144)
        btnSwipeLocal.BackColor = Color.FromArgb(108, 123, 144)
        btnRand.BackColor = Color.FromArgb(108, 123, 144)
        btnPola.BackColor = Color.FromArgb(108, 123, 144)
        btnSwipeNostro.BackColor = Color.FromArgb(108, 123, 144)
    End Sub

    Private Sub btnLocalCash_Click(sender As Object, e As EventArgs) Handles btnLocalCash.Click
        DefaultColors()
        btnLocalCash.BackColor = System.Drawing.Color.DarkGreen
        lblExchangeRate.Text = Format(dblBond_Rate, "#,##0.00")
        intPublicFiscalCurrency = 1
        strCurrencyUsed = "ZIG"
        strFiscalInvoicingCurrency = "ZIG"
        strSalesCurrencyUsed = strFiscalInvoicingCurrency
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub btnUsdCash_Click(sender As Object, e As EventArgs) Handles btnUsdCash.Click
        DefaultColors()
        btnUsdCash.BackColor = System.Drawing.Color.DarkGreen
        lblExchangeRate.Text = Format(dblUS_Rate, "#,##0.00")
        intPublicFiscalCurrency = 2
        strCurrencyUsed = "USD"
        strFiscalInvoicingCurrency = "USD"
        strSalesCurrencyUsed = strFiscalInvoicingCurrency
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub btnEcocash_Click(sender As Object, e As EventArgs) Handles btnEcocash.Click
        DefaultColors()
        btnEcocash.BackColor = System.Drawing.Color.DarkGreen
        lblExchangeRate.Text = Format(dblEcocash_Rate, "#,##0.00")
        intPublicFiscalCurrency = 1
        strCurrencyUsed = "ZIG-ECOCASH"
        strFiscalInvoicingCurrency = "ZIG"
        strSalesCurrencyUsed = strFiscalInvoicingCurrency
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub btnSwipeLocal_Click(sender As Object, e As EventArgs) Handles btnSwipeLocal.Click
        DefaultColors()
        btnSwipeLocal.BackColor = System.Drawing.Color.DarkGreen
        lblExchangeRate.Text = Format(dblSwipe_Rate, "#,##0.00")
        intPublicFiscalCurrency = 1
        strCurrencyUsed = "ZIG-SWIPE"
        strFiscalInvoicingCurrency = "ZIG"
        strSalesCurrencyUsed = strFiscalInvoicingCurrency
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub btnRand_Click(sender As Object, e As EventArgs) Handles btnRand.Click
        DefaultColors()
        btnRand.BackColor = System.Drawing.Color.DarkGreen
        lblExchangeRate.Text = Format(dblRand_Rate, "#,##0.00")
        intPublicFiscalCurrency = 3
        strCurrencyUsed = "RAND"
        strFiscalInvoicingCurrency = "RAND"
        strSalesCurrencyUsed = strFiscalInvoicingCurrency
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub btnPola_Click(sender As Object, e As EventArgs) Handles btnPola.Click
        DefaultColors()
        btnPola.BackColor = System.Drawing.Color.DarkGreen
        lblExchangeRate.Text = Format(dblPula_Rate, "#,##0.00")
        intPublicFiscalCurrency = 4
        strCurrencyUsed = "PULA"
        strFiscalInvoicingCurrency = "PULA"
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub btnSwipeNostro_Click(sender As Object, e As EventArgs) Handles btnSwipeNostro.Click
        DefaultColors()
        btnSwipeNostro.BackColor = System.Drawing.Color.DarkGreen
        lblExchangeRate.Text = Format(dblUS_Rate, "#,##0.00")
        intPublicFiscalCurrency = 2
        strCurrencyUsed = "USD-SWIPE"
        strFiscalInvoicingCurrency = "USD"
        strSalesCurrencyUsed = strFiscalInvoicingCurrency
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click
        DefaultColors()
        btnTransfer.BackColor = System.Drawing.Color.DarkGreen
        lblExchangeRate.Text = Format(dblTransfer_Rate, "#,##0.00")
        intPublicFiscalCurrency = 1
        strCurrencyUsed = "ZIG-TRANSFER"
        strFiscalInvoicingCurrency = "ZIG"
        strSalesCurrencyUsed = strFiscalInvoicingCurrency
        boolAbort = False
        Me.Close()
    End Sub

End Class