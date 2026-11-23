Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions


Public Class frmLedgerAccountsListing

    Dim arrAccountTransactions As ArrayList
    Dim _originalSplitterDistance As Integer
    Dim _originalSplitterDistanceSub As Integer
    Dim _widthLeftRight As Integer
    Dim _CurrentSplitterDistance As Integer
    Dim intPriorSplitterDistance As Integer

    Dim boolFormLoading As Boolean



    Private Sub frmLedgerListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Update first the cashbook control
        intPriorSplitterDistance = Me.Width - 200
        boolAbort = False
        gwt_comm.UpdateCashbookControlAccount(Format(Now, "dd-MMM-yyyy"))
        If boolAbort = True Then Exit Sub
        boolFormLoading = True
        'LoadAccounts()
        LoadDepartmentsAndBranchCodes()
        boolFormLoading = False
    End Sub

    Private Sub btnPrintAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintAll.Click
        On Error GoTo RaiseErr
        boolAbort = False
        Dim f As New frmDateSpecifier
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        Dim arrPrintData As New ArrayList

        'Update the cashbook control accounts
        gwt_comm.UpdateCashbookControlAccount(EndDate)

        'Get a count of the ledger accounts based on the number of item rows
        Dim objGetCount As New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM LedgerAccounts", cnn)
        Dim objReadCount As Data.OleDb.OleDbDataReader = objGetCount.ExecuteReader
        Dim intTotalCount As Integer = 0
        If objReadCount.HasRows Then
            objReadCount.Read()
            If IsNumeric(objReadCount(0).ToString) Then intTotalCount = CInt(objReadCount(0))
        End If
        objReadCount.Close()

        With frmMedlightMain
            .ProgressBar1.Maximum = intTotalCount
            .ProgressBar1.Value = 0
            .ProgressBar1.Visible = True
        End With

        Cursor = Cursors.WaitCursor

        'loop through the ledger accounts and get data
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM LedgerAccounts ORDER BY AccountNumber", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            '' ''Dim strAccountName As String = Nothing
            '' ''If Not IsDBNull(objReader(0).ToString) Then strSelectedAccount = objReader(0).ToString
            '' ''If Not IsDBNull(objReader(1).ToString) Then strAccountName = objReader(1).ToString

            ' '' ''We only print transactions with values
            '' ''Dim dblSumEntries As Double = 0
            '' ''Dim objCount As New Data.OleDb.OleDbCommand("SELECT sum(Amount) FROM LedgerTransactions WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
            '' ''Dim objReadCnt As Data.OleDb.OleDbDataReader = objCount.ExecuteReader
            '' ''If objReadCnt.HasRows Then
            '' ''    objReadCnt.Read()
            '' ''    dblSumEntries = CDbl(objReadCnt(0).ToString)
            '' ''End If
            '' ''objReadCnt.Close()

            '' ''If UCase(strSelectedAccount) <> UCase(strPublicSalesAccount) Then
            '' ''    If dblSumEntries <> 0 Then
            '' ''        arrAccountTransactions.Add(" ;" & UCase(strSelectedAccount) & "  " & UCase(strAccountName) & ";;;;;" & strSelectedAccount)
            '' ''        arrAccountTransactions.Add(" ;;;;;;" & strSelectedAccount)
            '' ''        LoadByDate(StartDate, EndDate)
            '' ''        arrAccountTransactions.Add(" ;;;;;;" & strSelectedAccount)
            '' ''    End If
            '' ''End If

            Dim arrSourceData As New ArrayList
            arrSourceData = gwt_comm.LedgerAccountDetailsPrint(objReader(0).ToString, StartDate, EndDate, 0, 99999999, 0, 99999999)

            Dim dblDebitTotals As Double = 0
            Dim dblCreditTotals As Double = 0
            Dim dblMovingBalance As Double = 0
            Dim dblBalanceBefore As Double = 0
            Dim strBalanceBefore As String = ""
            Dim strColumn(0 To 8) As String

            For i As Integer = 0 To arrSourceData.Count - 1

                Dim strSplit() As String = Split(arrSourceData.Item(i), "|")
                Dim strDate As String = strSplit(0)
                Dim strDescription As String = strSplit(1)
                Dim strFolio As String = strSplit(2)
                Dim strContraAccount As String = strSplit(3)
                Dim dblDebit As Double = CDbl(strSplit(4))
                Dim dblCredit As Double = CDbl(strSplit(5))

                dblDebitTotals = dblDebitTotals + dblDebit
                dblCreditTotals = dblCreditTotals + dblCredit

                Dim strDebit As String = ""
                Dim strCredit As String = ""
                Dim strMovingBalance As String = ""

                If i = 0 Then
                    dblMovingBalance = CDbl(dblDebit - dblCredit)
                    dblBalanceBefore = dblMovingBalance
                    If dblMovingBalance <> 0 Then strMovingBalance = Format(dblMovingBalance, "#,##0.00")
                    strColumn(0) = objReader(0).ToString & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(1) = objReader(1).ToString & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(2) = "Balance Forward|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(8) = strMovingBalance & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                    arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) &
                        strColumn(6) & strColumn(7) & strColumn(8))

                    strColumn(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(8) = strMovingBalance & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                    arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) &
                            strColumn(6) & strColumn(7) & strColumn(8))

                Else
                    dblMovingBalance = CDbl(dblDebit - dblCredit) + dblMovingBalance
                    If dblMovingBalance <> 0 Then strMovingBalance = Format(dblMovingBalance, "#,##0.00")

                    If dblDebit <> 0 Then strDebit = Format(dblDebit, "#,##0.00")
                    If dblCredit <> 0 Then strCredit = Format(dblCredit, "#,##0.00")

                    strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                    strColumn(1) = StrConv(strDescription, VbStrConv.ProperCase) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                    strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                    strColumn(3) = strFolio & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                    strColumn(4) = strDate & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                    strColumn(5) = strContraAccount & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                    strColumn(6) = strDebit & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                    strColumn(7) = strCredit & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                    strColumn(8) = strMovingBalance & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"

                    arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) &
                        strColumn(6) & strColumn(7) & strColumn(8))

                End If

            Next

            'Compute the ledger account balance

            Dim dblBalanceCredit As Double = 0
            Dim dblBalanceDebit As Double = 0
            Dim dblBaseTotal As Double = 0

            If dblDebitTotals > dblCreditTotals Then
                dblBalanceCredit = dblDebitTotals - dblCreditTotals
                dblBaseTotal = dblDebitTotals
            Else
                dblBalanceDebit = dblCreditTotals - dblDebitTotals
                dblBaseTotal = dblCreditTotals
            End If

            'Add the balance line and the totals line
            Dim strNetMovement As String = ""
            Dim dblNetMovement As Double = dblMovingBalance - dblBalanceBefore
            If dblNetMovement <> 0 Then strNetMovement = Format(dblNetMovement, "#,##0.00")

            strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(2) = "Period Totals|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(6) = Format(dblDebitTotals, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(7) = Format(dblCreditTotals, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(8) = Format(dblBaseTotal, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"

            arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) &
                                 strColumn(6) & strColumn(7) & strColumn(8))

            'Add the net movement line
            strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(2) = "Period Movement|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(8) = strNetMovement & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"

            arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) &
                                 strColumn(6) & strColumn(7) & strColumn(8))

            'At end draw a line
            strColumn(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(8) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
            arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) &
                    strColumn(6) & strColumn(7) & strColumn(8))

            frmMedlightMain.ProgressBar1.Value = frmMedlightMain.ProgressBar1.Value + 1

        End While

        objReader.Close()

        On Error GoTo RaiseErr

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        If arrPrintData.Count = 0 Then
            MessageBox.Show("No details to print were obtained from the system", "Printing Aborted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 9
            .strColumnHeaders = "ACCOUNT #|DESCRIPTION| |FOLIO|DATE|CONTRA TO|DEBIT|CREDIT|BALANCE"
            .strColumnWidths = "60|150|80|30|60|60|60|60|60"
            .strFooterCaption = "General Ledger Report"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "FULL LEDGER ACCOUNTS"
            .strMainHeader2 = "PERIOD COVERED: " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " TO " & UCase(Format(EndDate, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
            .VerticalLines = False
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("Black")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .DetailColor = Color.Black
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
            .DetailFont = New Font("Ariel", 6, FontStyle.Bold)
        End With

        Cursor = Cursors.Default

        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        rpt.PrinterSettings.PrinterName = prnt.PrinterSettings.PrinterName
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On ledger accounts full details print"
        ShowErrorMessage()
    End Sub

    '    Private Sub LoadByDate(ByVal startFrom As Date, ByVal endAt As Date)
    '        On Error GoTo RaiseErr

    '        'Get the previous balances
    '        Dim dblInitialBalance() = LedgerAccountBalances(startFrom, endAt, strSelectedAccount)

    '        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransactionDate, 105) as [Date], " _
    '            & "Description, FolioReference, ContraAccount, CAST(Amount as DECIMAL (10,2)) AS [Amt], TransactionType, TransactionId " _
    '            & "FROM LedgerTransactions WHERE AccountNumber = '" & strSelectedAccount & "' " _
    '            & "AND TransactionDate BETWEEN '" & startFrom & "' AND '" & endAt & "'", cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

    '        Dim strDate As String = Nothing
    '        Dim strDescription As String = Nothing
    '        Dim strFolio As String = Nothing
    '        Dim strContraAccount As String = Nothing
    '        Dim strDebitValue As String = "0.00"
    '        Dim strCreditValue As String = "0.00"

    '        Dim dblMovingDebitTotal As Double = 0
    '        Dim dblMovingCreditTotal As Double = 0

    '        Dim strData As String = Nothing
    '        If dblInitialBalance(0) <= 0 Then
    '            strCreditValue = CStr(Format((dblInitialBalance(0) * -1), "##0.00"))
    '        Else
    '            strDebitValue = CStr(Format((dblInitialBalance(0) * 1), "##0.00"))
    '        End If

    '        strData = CStr(Format(startFrom, "dd-MM-yyyy")) & ";" & "Balance b/f" & ";;" & ";" & strDebitValue & ";" & strCreditValue & ";" & strSelectedAccount
    '        arrAccountTransactions.Add(UCase(strData))

    '        dblMovingDebitTotal = dblMovingDebitTotal + CDbl(strDebitValue)
    '        dblMovingCreditTotal = dblMovingCreditTotal + CDbl(strCreditValue)

    '        While objReader.Read
    '            strDate = Nothing
    '            strDescription = Nothing
    '            strFolio = Nothing
    '            strContraAccount = Nothing
    '            strDebitValue = "0.00"
    '            strCreditValue = "0.00"

    '            If Not IsDBNull(objReader(0).ToString) Then strDate = objReader(0).ToString
    '            If Not IsDBNull(objReader(1).ToString) Then strDescription = objReader(1).ToString
    '            If Not IsDBNull(objReader(2).ToString) Then strFolio = objReader(2).ToString
    '            If Not IsDBNull(objReader(3).ToString) Then strContraAccount = objReader(3).ToString
    '            If Not IsDBNull(objReader(5).ToString) Then
    '                Dim strValue As String = objReader(4).ToString
    '                If UCase(objReader(5).ToString) = "CREDIT" Then
    '                    strCreditValue = strValue
    '                Else
    '                    strDebitValue = strValue
    '                End If
    '            End If
    '            strData = strDate & ";" & strDescription & ";" & strFolio & ";" & strContraAccount & ";" & strDebitValue & ";" & strCreditValue & ";" & strSelectedAccount
    '            arrAccountTransactions.Add(UCase(strData))

    '            'Accoumulate totals
    '            dblMovingDebitTotal = dblMovingDebitTotal + CDbl(strDebitValue)
    '            dblMovingCreditTotal = dblMovingCreditTotal + CDbl(strCreditValue)

    '        End While

    '        'Get the end balances
    '        strDebitValue = "0.00"
    '        strCreditValue = "0.00"
    '        If dblInitialBalance(1) <= 0 Then
    '            strDebitValue = CStr(Format((dblInitialBalance(1) * -1), "##0.00"))
    '        Else
    '            strCreditValue = CStr(Format((dblInitialBalance(1) * 1), "##0.00"))
    '        End If

    '        strData = CStr(Format(endAt, "dd-MM-yyyy")) & ";" & "Balance c/f" & ";;" & ";" & strDebitValue & ";" & strCreditValue & ";" & strSelectedAccount
    '        arrAccountTransactions.Add(UCase(strData))

    '        'Accumulate totals
    '        dblMovingDebitTotal = dblMovingDebitTotal + CDbl(strDebitValue)
    '        dblMovingCreditTotal = dblMovingCreditTotal + CDbl(strCreditValue)

    '        'Write the final line totals
    '        strData = " ;" & "ACCOUNT TOTALS" & ";;" & ";" & CStr(Format(dblMovingDebitTotal, "##0.00")) & ";" & CStr(Format(dblMovingCreditTotal, "##0.00")) & ";" & strSelectedAccount
    '        arrAccountTransactions.Add(UCase(strData))

    '        objReader.Close()
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Leadger Account Transactions Load"
    '        ShowErrorMessage()
    '    End Sub

    '    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
    '        LoadData()
    '    End Sub

    '    Private Sub LoadAccounts()

    '        On Error GoTo RaiseErr

    '        tvAccounts.Items.Clear()

    '        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM " _
    '            & "LedgerAccounts WHERE SubAccountOf = 'None' ORDER BY AccountNumber", cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

    '        While objReader.Read
    '            Dim itemA As New TreeListViewItem(objReader("AccountNumber").ToString, 0)
    '            tvAccounts.Items.Add(itemA)
    '            itemA.SubItems.Add(objReader(1).ToString)
    '            AddMoreTreeItems(itemA)
    '        End While
    '        objReader.Close()

    '        tvAccounts.ExpandAll()

    '        With tvAccounts
    '            .AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    '        End With

    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Leadger Accounts Load"
    '        ShowErrorMessage()
    '    End Sub

    '    Public Sub AddMoreTreeItems(ByVal parent As TreeListViewItem)
    '        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName, SubAccountOf FROM LedgerAccounts " _
    '                & "WHERE SubAccountOf = '" & parent.Text & "' ORDER BY SubAccountOf, AccountNumber", cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '        While objReader.Read
    '            Dim item As New TreeListViewItem(objReader(0).ToString, 1)
    '            parent.Items.Add(item)
    '            item.SubItems.Add(objReader(1).ToString)
    '            AddMoreTreeItems(item)
    '        End While
    '    End Sub

    Private Sub LoadByDate(ByVal startFrom As Date, ByVal endAt As Date)

        On Error GoTo RaiseErr
        'Get the previous balances
        Dim dblInitialBalance() = gwt_comm.LedgerAccountBalances(startFrom, endAt, strSelectedAccount)

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransactionDate, 105) as [Date], " _
            & "Description, FolioReference, ContraAccount, CAST(Amount as DECIMAL (10,2)) AS [Amt], TransactionType, TransactionId, SpecialKey " _
            & "FROM LedgerTransactions WHERE AccountNumber = '" & strSelectedAccount & "' " _
            & "AND TransactionDate BETWEEN '" & startFrom & "' AND '" & endAt & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        dGrid.Rows.Add(1)
        dGrid.Rows(0).Cells(0).Value = CStr(Format(startFrom, "dd-MM-yyyy"))
        dGrid.Rows(0).Cells(1).Value = "Balance b/f"
        If dblInitialBalance(0) <= 0 Then
            dGrid.Rows(0).Cells(5).Value = Format((dblInitialBalance(0) * -1), "##0.00")
        Else
            dGrid.Rows(0).Cells(4).Value = Format((dblInitialBalance(0) * 1), "##0.00")
        End If

        While objReader.Read
            With dGrid
                .Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(0).ToString

                If Not IsDBNull(objReader(1).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
                If Not IsDBNull(objReader(5).ToString) Then
                    Dim strValue As String = objReader(4).ToString
                    If UCase(objReader(5).ToString) = "CREDIT" Then
                        .Rows(.Rows.Count - 1).Cells(5).Value = strValue
                    Else
                        .Rows(.Rows.Count - 1).Cells(4).Value = strValue
                    End If
                End If
                If Not IsDBNull(objReader(7).ToString) Then .Rows(.Rows.Count - 1).Cells(6).Value = objReader(7).ToString
            End With
        End While
        ComputeTotals()
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Leadger Account Transactions Load"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr
        Dim dblDebitTotals As Double = 0
        Dim dblCreditTotals As Double = 0
        For i As Integer = 0 To dGrid.RowCount - 1
            Dim dblDebit As Double = 0
            Dim dblCredit As Double = 0
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                    dblDebit = dGrid.Rows(i).Cells(4).Value.ToString
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                    dblCredit = dGrid.Rows(i).Cells(5).Value.ToString
                End If
            End If
            dblDebitTotals = dblDebitTotals + dblDebit
            dblCreditTotals = dblCreditTotals + dblCredit
        Next

        'Compute the ledger account balance

        Dim dblBalanceCredit As Double = 0
        Dim dblBalanceDebit As Double = 0
        Dim dblBaseTotal As Double = 0
        Dim dblBalance As Double = 0

        dblBalance = dblDebitTotals - dblCreditTotals

        'If dblDebitTotals < dblCreditTotals Then
        '    dblBalanceCredit = dblDebitTotals - dblCreditTotals
        '    dblBaseTotal = dblDebitTotals
        '    dblBalance = dblBalanceCredit
        'Else
        '    dblBalanceDebit = dblCreditTotals - dblDebitTotals
        '    dblBaseTotal = dblCreditTotals
        '    dblBalance = dblBalanceDebit
        'End If

        lblTotalDebits.Text = Format(dblDebitTotals, "##0.00")
        lblTotalCredits.Text = Format(dblCreditTotals, "##0.00")
        lblBalance.Text = Format(dblBalance, "##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Ledger Account Totals Computation Failure"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellClick
        'If dGrid.Rows.Count <= 0 Then Exit Sub
        'If dGrid.CurrentCell.ColumnIndex = 7 Then
        '    ReverseTransaction()
        'End If
        On Error GoTo RaiseErr
        If dGrid.CurrentCell.ColumnIndex = 7 Then
            If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.Yes Then
                If UCase(strUserLevel) = "ADMINISTRATOR" Or UCase(strUserLevel) = "MANAGER" Then
                    If Not IsNumeric(dGrid.CurrentRow.Cells(6).Value) Then
                        MessageBox.Show("Transaction cannot be deleted", "Process Terminated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                    Dim intKey As Integer = CInt(dGrid.CurrentRow.Cells(6).Value.ToString)
                    If gwt_comm.DeleteSpecialKeyTransaction(intKey) = True Then
                        MessageBox.Show("Transaction deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Process failed", "Process Failure", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("You do not have the right to process this transaction", "Unauthorised Process", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Transaction delete failure"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintSelected.Click
        If dGrid.RowCount <= 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        Dim arrPrintData As New ArrayList
        Dim dblDebitTotals As Double = 0
        Dim dblCreditTotals As Double = 0
        Dim dblMovingBalance As Double = 0
        Dim dblBalanceBefore As Double = 0
        Dim strBalanceBefore As String = ""
        Dim strColumn(0 To 8) As String
        For i As Integer = 0 To dGrid.RowCount - 1
            Dim strDate As String = Nothing
            Dim strDescription As String = Nothing
            Dim strFolio As String = Nothing
            Dim strContraAccount As String = Nothing
            Dim dblDebit As Double = 0
            Dim dblCredit As Double = 0
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strDate = dGrid.Rows(i).Cells(0).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                strDescription = dGrid.Rows(i).Cells(1).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                strFolio = dGrid.Rows(i).Cells(2).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                strContraAccount = dGrid.Rows(i).Cells(3).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                    dblDebit = dGrid.Rows(i).Cells(4).Value.ToString
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                    dblCredit = dGrid.Rows(i).Cells(5).Value.ToString
                End If
            End If
            dblDebitTotals = dblDebitTotals + dblDebit
            dblCreditTotals = dblCreditTotals + dblCredit

            'strLineData = strLineData & strPrintData & "|FN=" & strFontName & ";FS=" & intFontSize _
            '        & ";FC=" & strFontColor & ";FB=" & strFontBold & ";FI=" & strFontItalic & ";FU=" & strFontUnderline _
            '        & ";BC=" & strBackColor & ";RH=" & intRectangleHeight & "</d>"

            Dim strDebit As String = ""
            Dim strCredit As String = ""
            Dim strMovingBalance As String = ""

            If i = 0 Then
                dblMovingBalance = CDbl(dblDebit - dblCredit)
                dblBalanceBefore = dblMovingBalance
                If dblMovingBalance <> 0 Then strMovingBalance = Format(dblMovingBalance, "#,##0.00")
                strColumn(0) = strSelectedAccount & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(1) = strSelectedAccountName & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(2) = "Balance Forward|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(8) = strMovingBalance & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) &
                    strColumn(6) & strColumn(7) & strColumn(8))

                strColumn(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(8) = strMovingBalance & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) &
                        strColumn(6) & strColumn(7) & strColumn(8))

            Else
                dblMovingBalance = CDbl(dblDebit - dblCredit) + dblMovingBalance
                If dblMovingBalance <> 0 Then strMovingBalance = Format(dblMovingBalance, "#,##0.00")

                If dblDebit <> 0 Then strDebit = Format(dblDebit, "#,##0.00")
                If dblCredit <> 0 Then strCredit = Format(dblCredit, "#,##0.00")

                strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(1) = StrConv(strDescription, VbStrConv.ProperCase) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(3) = strFolio & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(4) = strDate & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(5) = strContraAccount & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(6) = strDebit & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                strColumn(7) = strCredit & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                strColumn(8) = strMovingBalance & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"

                arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) &
                    strColumn(6) & strColumn(7) & strColumn(8))

            End If

        Next

        'Compute the ledger account balance

        Dim dblBalanceCredit As Double = 0
        Dim dblBalanceDebit As Double = 0
        Dim dblBaseTotal As Double = 0

        If dblDebitTotals > dblCreditTotals Then
            dblBalanceCredit = dblDebitTotals - dblCreditTotals
            dblBaseTotal = dblDebitTotals
        Else
            dblBalanceDebit = dblCreditTotals - dblDebitTotals
            dblBaseTotal = dblCreditTotals
        End If

        'Add the balance line and the totals line
        Dim strNetMovement As String = ""
        Dim dblNetMovement As Double = dblMovingBalance - dblBalanceBefore
        If dblNetMovement <> 0 Then strNetMovement = Format(dblNetMovement, "#,##0.00")

        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(2) = "Period Totals|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(6) = Format(dblDebitTotals, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(7) = Format(dblCreditTotals, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(8) = Format(dblBaseTotal, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"

        arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) &
                             strColumn(6) & strColumn(7) & strColumn(8))

        'Add the net movement line
        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(2) = "Period Movement|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(8) = strNetMovement & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"

        arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) &
                             strColumn(6) & strColumn(7) & strColumn(8))

        'At end draw a line
        strColumn(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(8) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
        arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) &
                strColumn(6) & strColumn(7) & strColumn(8))

        On Error GoTo RaiseErr

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        If arrPrintData.Count = 0 Then
            MessageBox.Show("No details to print were obtained from the system", "Printing Aborted", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 9
            .strColumnHeaders = "ACCOUNT #|DESCRIPTION| |FOLIO|DATE|CONTRA ACCOUNT|DEBIT|CREDIT|BALANCE"
            .strColumnWidths = "60|150|80|30|60|60|60|60|60"
            .strFooterCaption = "General Ledger Report"
            .strMainCaption = UCase(strCompanyName)
            '.strMainHeader2 = "LEDGER ACCOUNT DETAILS : " & UCase(strSelectedAccount) & "-" & UCase(strSelectedAccountName)
            .strMainHeader2 = "Period Covered: " & UCase(Format(dpStartDate.Value, "dd-MMM-yyyy")) & " TO " & UCase(Format(dpEndDate.Value, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
            .VerticalLines = False
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("Black")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .DetailColor = Color.Black
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
            .DetailFont = New Font("Ariel", 6, FontStyle.Bold)
        End With
        Cursor = Cursors.Default
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        rpt.PrinterSettings.PrinterName = prnt.PrinterSettings.PrinterName
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Ledger Account Details Print Failure"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSelectedLedgerAccountDetails(ByVal AccountNumber As String)
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransactionDate, 105) as [Date], " _
            & "Description, FolioReference, ContraAccount, CAST(Amount as DECIMAL (10,2)) AS [Amt], TransactionType, TransactionId, SpecialKey " _
            & "FROM LedgerTransactions WHERE AccountNumber = '" & AccountNumber & "' AND TransactionDate BETWEEN " _
            & "'" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            With dGrid
                .Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
                If Not IsDBNull(objReader(5).ToString) Then
                    Dim strValue As String = objReader(4).ToString
                    If UCase(objReader(5).ToString) = "CREDIT" Then
                        .Rows(.Rows.Count - 1).Cells(5).Value = strValue
                    Else
                        .Rows(.Rows.Count - 1).Cells(4).Value = strValue
                    End If
                End If
                If Not IsDBNull(objReader(7).ToString) Then .Rows(.Rows.Count - 1).Cells(6).Value = objReader(7).ToString
            End With
        End While
        objReader.Close()
        ComputeTotals()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Leadger Account Transactions Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnViewEntries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadByDate(Format(dpStartDate.Value, "dd-MMM-yyyy"), Format(dpEndDate.Value, "dd-MMM-yyyy"))
    End Sub

    Private Sub LoadDepartmentsAndBranchCodes()
        '        On Error GoTo RaiseErr
        '        Dim strSql As String = Nothing
        '        strSql = "SELECT CONVERT(NVARCHAR, BranchCode) +';'+ BranchName AS [Branches] FROM Branches ORDER BY BranchName"
        '        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        '        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        '        'Set up the drop down combo box
        '        With cboBranchFrom
        '            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        '            .ColumnNum = 2
        '            .HighlightBorderOnMouseEvents = True
        '            .ManagingFastMouseMoving = True
        '            .Enabled = True
        '            .GridLineHorizontal = True
        '            .GridLineVertical = True
        '            .ColumnWidth = "60;" & cboBranchFrom.Width - 80
        '        End With
        '        With cboBranchTo
        '            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        '            .ColumnNum = 2
        '            .HighlightBorderOnMouseEvents = True
        '            .ManagingFastMouseMoving = True
        '            .Enabled = True
        '            .GridLineHorizontal = True
        '            .GridLineVertical = True
        '            .ColumnWidth = "60;" & cboBranchTo.Width - 80
        '        End With
        '        'Get a count of the items
        '        Dim intItemsCount As Integer = 0
        '        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(BranchCode) FROM Branches", cnn)
        '        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        '        If objCount.HasRows Then
        '            objCount.Read()
        '            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        '        End If
        '        objCount.Close()
        '        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        '        cboBranchFrom.Items.Clear() : cboBranchTo.Items.Clear()

        '        Dim i As Integer = 0
        '        'Continue to read until you reach the end of the file.
        '        While objReader.Read
        '            'File the listview with details.
        '            If Not IsDBNull(objReader(0).ToString) Then
        '                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
        '                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        '            End If
        '            i = i + 1
        '        End While
        '        objReader.Close()
        '        'Load the banks to the combo box
        '        If intItemsCount > 0 Then
        '            cboBranchFrom.SelectedIndex = -1
        '            cboBranchFrom.Items.Clear()
        '            cboBranchFrom.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        '            cboBranchFrom.Items.AddRange(DropDownItems)

        '            cboBranchTo.SelectedIndex = -1
        '            cboBranchTo.Items.Clear()
        '            cboBranchTo.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        '            cboBranchTo.Items.AddRange(DropDownItems)
        '        End If

        '        strSql = "SELECT CONVERT(NVARCHAR, OrdinalNo) +';'+ DepartmentName AS [Departments] FROM SystemDepartments ORDER BY DepartmentName"
        '        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        '        objReader = sqlCommand.ExecuteReader
        '        'Set up the drop down combo box
        '        With cboDeptFrom
        '            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        '            .ColumnNum = 2
        '            .HighlightBorderOnMouseEvents = True
        '            .ManagingFastMouseMoving = True
        '            .Enabled = True
        '            .GridLineHorizontal = True
        '            .GridLineVertical = True
        '            .ColumnWidth = "60;" & cboDeptFrom.Width - 80
        '        End With
        '        With cboDeptTo
        '            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        '            .ColumnNum = 2
        '            .HighlightBorderOnMouseEvents = True
        '            .ManagingFastMouseMoving = True
        '            .Enabled = True
        '            .GridLineHorizontal = True
        '            .GridLineVertical = True
        '            .ColumnWidth = "60;" & cboDeptTo.Width - 80
        '        End With
        '        'Get a count of the items
        '        intItemsCount = 0
        '        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(OrdinalNo) FROM SystemDepartments", cnn)
        '        objCount = sqlCommand.ExecuteReader
        '        If objCount.HasRows Then
        '            objCount.Read()
        '            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        '        End If
        '        objCount.Close()
        '        Dim DropDownItemsDepartments(intItemsCount - 1) As MTGCComboBoxItem

        '        cboDeptFrom.Items.Clear() : cboDeptTo.Items.Clear()

        '        i = 0
        '        'Continue to read until you reach the end of the file.
        '        While objReader.Read
        '            'File the listview with details.
        '            If Not IsDBNull(objReader(0).ToString) Then
        '                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
        '                DropDownItemsDepartments(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        '            End If
        '            i = i + 1
        '        End While
        '        objReader.Close()
        '        'Load the banks to the combo box
        '        If intItemsCount > 0 Then
        '            cboDeptFrom.SelectedIndex = -1
        '            cboDeptFrom.Items.Clear()
        '            cboDeptFrom.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        '            cboDeptFrom.Items.AddRange(DropDownItemsDepartments)

        '            cboDeptTo.SelectedIndex = -1
        '            cboDeptTo.Items.Clear()
        '            cboDeptTo.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        '            cboDeptTo.Items.AddRange(DropDownItemsDepartments)
        '        End If

        '        Exit Sub
        'RaiseErr:
        '        boolAbort = True
        '        strErrorMessages = Err.Description & " " & Err.Number & " on Branches and Departments Information Load"
        '        ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        boolFormLoading = True
        'LoadAccounts()
        LoadDepartmentsAndBranchCodes()
        boolFormLoading = False
    End Sub

    Private Sub btnLedgerAccount_Click(sender As Object, e As EventArgs) Handles btnLedgerAccount.Click
        boolAbort = False
        Dim frm As New frmLedgerAccountsPickList
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        lblAccountName.Text = UCase(strSelectedAccount) & ":" & UCase(strSelectedAccountName)
        LoadByDate(Format(dpStartDate.Value, "dd-MMM-yyyy"), Format(dpEndDate.Value, "dd-MMM-yyyy"))
    End Sub

End Class