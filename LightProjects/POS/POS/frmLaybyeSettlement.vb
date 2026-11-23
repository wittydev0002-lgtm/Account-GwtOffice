Imports System.Drawing.Printing
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLaybyeSettlement

    Dim arrPrintDetails As ArrayList
    Dim strSelectedReport As String
    Dim boolFormIsLoading As Boolean = True
    Dim dblCurrencyRate As Double = 1

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub chkOverideDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverideDate.CheckedChanged
        If chkOverideDate.Checked = True Then
            If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
                dpTransDate.Enabled = True
            Else
                boolAbort = False
                boolAuthorized = False
                gwt_comm.SuperUserAuthentication()
                If boolAbort = True Then
                    chkOverideDate.Checked = False
                    Exit Sub
                End If
                If boolAuthorized = True Then
                    dpTransDate.Enabled = True
                    boolAuthorized = False
                End If
            End If
        Else
            dpTransDate.Enabled = False
            boolAuthorized = False
        End If
    End Sub

    Private Sub PrintInvoice(ByVal dtReceiptDate As Date)
        On Error GoTo RaiseErr
        Dim strType As String = UCase(strReceiptHeader)
        strSelectedReport = Me.txtReference.Text

        arrPrintDetails = New ArrayList
        '
        'ADD THE BRANCH INFORMATION
        '
        arrPrintDetails.Add(Space(2) & UCase(strCompanyName))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchName))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress1))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress2))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress3))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress4))
        arrPrintDetails.Add(Space(2) & "PHONE: " & strPublicBranchTelephone)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))

        arrPrintDetails.Add(Space(2) & "ACC. NO.: " & UCase(txtAccountNumber.Text))
        arrPrintDetails.Add(Space(2) & "CUSTOMER: " & UCase(txtAccountName.Text))
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))

        Dim dblVatTax As Double = 0

        Dim strDescription As String = "ACCOUNT SETTLEMENT"
        Dim strQuantity As String = "1"
        Dim strUnitPrice As String = "  "
        Dim strLineTotal As String = Format(CDbl(txtAmountExchange.Text), "##0.00")
        If strDescription.Length > 30 Then strDescription = Mid(strDescription, 1, 32)

        'Add the balance after payment line
        arrPrintDetails.Add(Space(2) & strDescription)


        'Add the dash line
        Dim strTaxCharged As String = Format(dblVatTax, "##0.00")

        Dim strTender As String = Format(dblAmountTendered, "##0.00")
        Dim strChange As String = Format(dblAmountChange, "##0.00")

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "TOTAL INCL. VAT " & Space(14 - txtAmountExchange.Text.Length) & txtAmountExchange.Text)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "VAT CHARGED     " & Space(14 - strTaxCharged.Length) & strTaxCharged)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "AMOUNT TENDERED " & Space(14 - strTender.Length) & strTender)
        arrPrintDetails.Add(Space(2) & "CHANGE          " & Space(14 - strChange.Length) & strChange)

        Dim strZimDate As String = Format(Now, "dd-MMM-yyyy")

        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(2) & "TILL OPER :" & UCase(strUserName) & Space(3))

        arrPrintDetails.Add(Space(1) & "DATE AND TIME " & strZimDate & " " & DatePart(DateInterval.Hour, Now) & ":" & DatePart(DateInterval.Minute, Now))
        arrPrintDetails.Add(Space(2) & UCase(strReceiptHeader) & " DATE  " & Format(dtReceiptDate, "dd-MMM-yyyy"))
        arrPrintDetails.Add(Space(2) & " DOC NO " & txtReference.Text)
        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(1) & "CURRENCY : " & UCase(cboCurrency.Text))
        arrPrintDetails.Add(Space(1) & "RATE USED: " & dblSaleExchangeRate)
        If boolProcessingAccountPayment = False Then
            If arrConditionsOfSale.Count > 0 Then
                For j As Double = 0 To arrConditionsOfSale.Count - 1
                    arrPrintDetails.Add(UCase(arrConditionsOfSale.Item(j)))
                Next j
            End If
        End If
        For i As Double = 0 To 5
            arrPrintDetails.Add(Space(32))
        Next

        'WRITE EVERY THING TO THE AUDIT FILE

        Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\TILLSLIP", True)
        For x As Double = 0 To arrPrintDetails.Count - 1
            objFileWriter.WriteLine(arrPrintDetails.Item(x))
        Next
        objFileWriter.Close()

        '
        'PRINTS FROM A FILE DIRECTLY TO THE PRINTER
        '

        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()

        If MessageBox.Show("Do you want to print the receipt right now?", "Confirm Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            If strRequestForReceiptPrinter = "YES" Then
                boolAbort = False
                Dim f As New frmPrinterSetup
                f.ShowDialog()
                If boolAbort = True Then Exit Sub
                pd.PrinterSettings.PrinterName = strSessionPrinter
            End If
            For n = 0 To arrPrintDetails.Count - 1
                Dim strPrintLineDetails As String = arrPrintDetails.Item(n) & vbCrLf
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintLineDetails)
            Next
            'Cut the paper on thermal printers
            Dim output As String = Chr(&H1D) & "V" & Chr(66) & Chr(0) 'Feeds paper & cut
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, output)
        End If

        'Update the document number

        Dim myCommand As New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET CashSales = " & CDbl(txtReference.Text) & "", cnn)
        myCommand.ExecuteNonQuery()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Lay-bye Transaction Processing"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim dblSumPayable As Double = 0

        If IsNumeric(txtAmountExchange.Text) Then dblSumPayable = CDbl(txtAmountExchange.Text)

        If dblSumPayable = 0 Then
            MessageBox.Show("Transaction will not be processed as the amount is zero", "Amount Is Zero", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))

        'Update the cashbook with the values
        Dim myCommand As Data.OleDb.OleDbCommand
        If strPublicDirectCashbbookSalesPosting = "YES" Then
            Dim strCashbookDescription As String = "LAYBYE PAYMENT-" & UCase(txtAccountNumber.Text & ":" & txtAccountName.Text)
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, " _
                & "TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, " _
                & "TransactionType, Reference) VALUES " _
                & "('" & strPublicActiveCashbook & "', '" & Format(dpTransDate.Value, "dd-MMM-yyyy") & "', " _
                & "" & dblSumPayable & ", '" & strCashbookDescription & "-" & strPublicItemCode & "', " _
                & "'" & strPublicSalesAccount & "', '" & strUserName & "', '" & strUserBranch & "', " _
                & "'DEBIT', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
            myCommand.ExecuteNonQuery()
        End If

        'Update the customer account
        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LaybyTransactions ([AccountNumber],[TransDate]," _
            & "[Amount],[TransType],[Description],[DocumentNumber],[UserName],[UserBranch]) " _
            & "VALUES('" & txtAccountNumber.Text & "', '" & Format(dpTransDate.Value, "dd-MMM-yyyy") & "', " _
            & "" & dblSumPayable & ", 'PAYMENT', 'CASH PAYMENT', '" & txtReference.Text & "', " _
            & "'" & strUserName & "', '" & strUserBranch & "')", cnn)
        myCommand.ExecuteNonQuery()

        PrintInvoice(dpTransDate.Value)
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Lay-bye Account Payment"
        ShowErrorMessage()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub cboCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurrency.SelectedIndexChanged
        On Error GoTo RaiseErr
        If boolFormIsLoading = True Then Exit Sub

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CurrencyRate FROM Currencies WHERE CurrencyName = '" & cboCurrency.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblCurrencyRate = CDbl(objReader(0).ToString)
            If IsNumeric(txtAmount.Text) Then
                If CDbl(txtAmount.Text) <> 0 Then
                    txtAmountExchange.Text = Format(((CDbl(txtAmount.Text) / dblCurrencyRate)), "##0.00")
                End If
            End If
        End If
        objReader.Close()
        If strRoundOnExchange = "YES" Then RoundValues()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On exchange computation"
        ShowErrorMessage()
    End Sub

    Private Sub RoundValues()
        If IsNumeric(txtAmount.Text) Then
            txtAmount.Text = Format((Math.Round(CDbl(txtAmount.Text), 0)), "##0.00")
        End If

        If IsNumeric(txtAmountExchange.Text) Then
            txtAmountExchange.Text = Format((Math.Round(CDbl(txtAmountExchange.Text), 0)), "##0.00")
        End If
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

    Private Sub frmLayByeSettlement_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        boolFormIsLoading = True
        LoadData()
        boolFormIsLoading = False
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        strPublicItemCode = Nothing
        strPublicItemDescription = Nothing
        Dim f As New frmBrowseLaybyeCustomer
        f.ShowDialog()
        If Not String.IsNullOrEmpty(strPublicItemCode) Then
            txtAccountNumber.Text = strPublicItemCode
            txtAccountName.Text = strPublicItemDescription
        End If
    End Sub

    Private Sub txtAccountNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountNumber.TextChanged
        txtAccountName.Clear()
    End Sub

    Private Sub txtAccountNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAccountNumber.Validating
        On Error GoTo RaiseErr
        txtAccountName.Clear()
        If String.IsNullOrEmpty(txtAccountNumber.Text) Then Exit Sub
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountName FROM LayByCustomers WHERE AccountNumber = '" & txtAccountNumber.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtAccountName.Text = objReader(0).ToString
        Else
            MessageBox.Show("The account number is invalid. Please re-enter", "Invalid Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNumber.Focus()
            Exit Sub
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Account Number Validation"
        ShowErrorMessage()
    End Sub

    Private Sub txtAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.LostFocus
        If IsNumeric(txtAmount.Text) Then txtAmount.Text = Format(CDbl(txtAmount.Text), "##0.00")
    End Sub

    Private Sub txtAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.GotFocus
        txtAmount.SelectAll()
    End Sub

    Private Sub txtAmount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmount.Validating
        If String.IsNullOrEmpty(txtAmount.Text) Then Exit Sub
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        Else
            'Compute the values
            txtAmount.Text = Format(CDbl(txtAmount.Text), "##0.00")
            txtAmountExchange.Text = Format(((CDbl(txtAmount.Text) / dblCurrencyRate)), "##0.00")
            If strRoundOnExchange = "YES" Then RoundValues()
            If strRoundOnExchange = "YES" Then
                dblAmountTendered = Math.Round(dblAmountTendered, 0)
                dblAmountChange = Math.Round(dblAmountChange, 0)
            End If
        End If
    End Sub

End Class
