Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmOne

    Dim strReportHeader As String

    Dim arrAccountTransactions As ArrayList
    Dim _originalSplitterDistance As Integer
    Dim _originalSplitterDistanceSub As Integer
    Dim _widthLeftRight As Integer
    Dim _CurrentSplitterDistance As Integer
    Dim intPriorSplitterDistance As Integer

    Dim boolFormLoading As Boolean
    Dim boolIncludeZeroBalance As Boolean = False

    Dim strTaxStatus As String = Nothing
    Dim strCustomerDetails As String
    Dim strInvoiceDetails As ArrayList
    Dim rsInvoiceTotals As String

    Dim dblInvoiceTotal As Double
    Dim dblTaxes As Double
    Dim dblDiscounts As Double
    Dim dblUnitPriceTotals As Double

    Dim i As Integer = 0
    Dim strvalue As String
    Dim strDate As String
    Dim itm As Integer
    Dim boolPrintFromPreview As Boolean
    Dim intPaymentReceiptNumber As Integer
    Dim strCustomerAccountNumberPayments As String
    Dim strTermsAndConditions As String = Nothing

    Dim strCustomerName As String
    Dim strCustomerAddress1 As String
    Dim strCustomerAddress2 As String
    Dim strCustomerAddress3 As String
    Dim strCustomerAddress4 As String
    Dim strCustomerTelephone As String
    Dim strCustomerEmailAddress As String
    Dim strCustomerVatNumber As String
    Dim strSalesRep As String

    Dim boolExitingWhile As Boolean = False
    Dim intPage As Single = 1
    Dim intPageTotals As Integer = 1

    Dim strItemType As String = Nothing
    Dim strOrderNumber As String = Nothing


    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub expandablePanel1_ExpandedChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles expandablePanel1.ExpandedChanged
        AdjustPanes()
    End Sub

    Private Sub GetSelected()
        On Error GoTo RaiseErr
        lblAccountName.Text = ""
        If tvAccounts.Nodes.Count > 0 Then
            strSelectedAccount = tvAccounts.SelectedNode.Tag
            Dim strSplit() As String = Split(tvAccounts.SelectedNode.Text, ":")
            strSelectedAccountName = strSplit(1)
            lblAccountName.Text = tvAccounts.SelectedNode.Text
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger Account Details Fetch"
        ShowErrorMessage()
    End Sub

    Private Sub AdjustPanes()
        If expandablePanel1.Expanded Then
            If (splitMain.Width - splitMain.Panel1.Width) < 200 Then intPriorSplitterDistance = splitMain.Width - 250
            splitMain.SplitterDistance = intPriorSplitterDistance
            splitMain.IsSplitterFixed = False
        Else
            intPriorSplitterDistance = splitMain.SplitterDistance
            splitMain.SplitterDistance = splitMain.Width - 32
            splitMain.IsSplitterFixed = True
        End If
    End Sub

    Private Sub frmOne_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        StartDate = Now : EndDate = Now
        tvReports.ExpandAll()
        boolAbort = False
        gwt_comm = New CommonLibrary.Commons.CommonFunctions
        gwt_comm.UserAuthentication()
        If boolAbort = True Then Exit Sub
       'add the ledger accounts and the treeview
        AddTreeNodes()
        If boolAbort = True Then Exit Sub
    End Sub

    Private Sub AddTreeNodes()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AccountNumber, AccountName FROM LedgerAccounts " _
            & "WHERE SubAccountOf = 'NONE' ORDER BY AccountName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim node As New TreeNode
            node.Text = objReader(0).ToString & ":" & objReader(1).ToString
            node.Tag = objReader(0).ToString
            AddNodes(node)
            tvAccounts.Nodes.Add(node)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Ledger Accounts Population"
        ShowErrorMessage()
    End Sub

    Private Sub AddNodes(ByRef node As TreeNode)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AccountNumber, AccountName FROM LedgerAccounts " _
            & "WHERE SubAccountOf = '" & node.Tag & "' ORDER BY AccountName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim nNode As New TreeNode
            nNode.Text = objReader(0).ToString & ":" & objReader(1).ToString
            nNode.Tag = objReader(0).ToString
            AddNodes(nNode)
            node.Nodes.Add(nNode)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Ledger Accounts Population"
        ShowErrorMessage()
    End Sub

    Private Sub tvAccounts_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvAccounts.AfterSelect
        If boolFormLoading = True Then Exit Sub
        dGridLedgers.Rows.Clear()
        On Error Resume Next
        strSelectedAccount = tvAccounts.SelectedNode.Tag
        Dim strSplit() As String = Split(tvAccounts.SelectedNode.Text, ":")
        strSelectedAccountName = strSplit(1)
        lblAccountName.Text = tvAccounts.SelectedNode.Text
        LoadSelectedLedgerAccountDetails(tvAccounts.SelectedNode.Tag)
    End Sub

    Private Sub LoadSelectedLedgerAccountDetails(ByVal AccountNumber As String)
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim dblLedgerBalanceBroughtDown() As Double = gwt_comm.LedgerAccountBalances(dpStartDate.Value, _
            dpEndDate.Value, AccountNumber)

        lblLedgerPeriodStartBalance.Text = Format(dblLedgerBalanceBroughtDown(0), "#,##0.00")

        'lblLedgerBFbalanceType
        If dblLedgerBalanceBroughtDown(0) < 0 Then lblLedgerBFbalanceType.Text = "CR" Else lblLedgerBFbalanceType.Text = "DR"

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransactionDate, 105) as [Date], " _
            & "Description, FolioReference, ContraAccount, CAST(Amount as DECIMAL (10,2)) AS [Amt], TransactionType, TransactionId, SpecialKey " _
            & "FROM LedgerTransactions WHERE AccountNumber = '" & AccountNumber & "' AND TransactionDate BETWEEN " _
            & "'" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridLedgers.Rows.Clear()
        Dim dblTotalLedgerDebits As Double = 0
        Dim dblTotalLedgerCredits As Double = 0
        While objReader.Read
            With dGridLedgers
                .Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
                If Not IsDBNull(objReader(5).ToString) Then
                    Dim strValue As String = objReader(4).ToString
                    If UCase(objReader(5).ToString) = "CREDIT" Then
                        .Rows(.Rows.Count - 1).Cells(5).Value = strValue
                        If IsNumeric(strValue) Then
                            dblTotalLedgerCredits = dblTotalLedgerCredits + CDbl(strValue)
                        End If
                    Else
                        .Rows(.Rows.Count - 1).Cells(4).Value = strValue
                        If IsNumeric(strValue) Then
                            dblTotalLedgerDebits = dblTotalLedgerDebits + CDbl(strValue)
                        End If
                    End If
                End If
                If Not IsDBNull(objReader(7).ToString) Then .Rows(.Rows.Count - 1).Cells(6).Value = objReader(7).ToString
            End With
        End While
        objReader.Close()
        lblLedgerCount.Text = Format(dGridLedgers.Rows.Count, "#,##0")
        lblLedgerDebits.Text = Format(dblTotalLedgerDebits, "#,##0.00")
        lblLedgerCredits.Text = Format(dblTotalLedgerCredits, "#,##0.00")
        lblLedgerMovement.Text = Format((dblTotalLedgerDebits - dblTotalLedgerCredits), "#,##0.00")
        lblLedgerEndBalance.Text = Format(((dblLedgerBalanceBroughtDown(0) + (dblTotalLedgerDebits - dblTotalLedgerCredits))), "#,##0.00")
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Leadger Account Transactions Load"
        ShowErrorMessage()
    End Sub

    Private Sub AlternateColors(Grid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView)
        For i As Integer = 0 To Grid.Rows.Count - 1 Step 2
            For j As Integer = 0 To Grid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                Grid.Rows(i).Cells(j).Style.BackColor = backColor
                Grid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub PrintCustomerBalances()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim arrCustomers As New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName FROM Customers ORDER BY AccountName", cnn)
        Dim objReaderCustomers As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReaderCustomers.Read
            Dim dblBalance As Double = gwt_comm.GetBalance(objReaderCustomers(0).ToString)
            If boolIncludeZeroBalance = False Then
                If dblBalance <> 0 Then
                    arrCustomers.Add(UCase(objReaderCustomers(0).ToString) & ";" & UCase(objReaderCustomers(1).ToString) & ";" & dblBalance & ";")
                End If
            Else
                arrCustomers.Add(UCase(objReaderCustomers(0).ToString) & ";" & UCase(objReaderCustomers(1).ToString) & ";" & dblBalance & ";")
            End If
        End While

        'Send the information to the printer

        Dim strPrintDetails(0 To arrCustomers.Count - 1) As String
        For i As Integer = 0 To arrCustomers.Count - 1
            strPrintDetails(i) = arrCustomers.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 4
            .strColumnHeaders = "CUSTOMER NAME|ACCOUNT NO|AMOUNT|"
            .strColumnAlignments = "0|0|2|0"
            .strColumnWidths = "150|250|100|100"
            .strFooterCaption = "Customer balances report"
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = "CUSTOMER BALANCES"
            '.strMainHeader3 = "PERIOD COVERED " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " - " & UCase(Format(EndDate, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|YES|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|YES|NO"
            .strSummaryTotals = "NO|NO|YES|NO"
            '.intKeyFieldIndex = 7
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Balance printing"
        ShowErrorMessage()
    End Sub

    Private Sub btnFindData_Click(sender As System.Object, e As System.EventArgs) Handles btnFindData.Click
        strSelectedAccount = tvAccounts.SelectedNode.Tag
        Dim strSplit() As String = Split(tvAccounts.SelectedNode.Text, ":")
        strSelectedAccountName = strSplit(1)
        lblAccountName.Text = tvAccounts.SelectedNode.Text
        LoadSelectedLedgerAccountDetails(tvAccounts.SelectedNode.Tag)
    End Sub

    Private Sub btnLedgerAccounts_Click(sender As System.Object, e As System.EventArgs) Handles btnLedgerAccounts.Click
        Dim frm As New frmLedgerAccountsSetupListing
        frm.ShowDialog()
    End Sub

    Private Sub btnSpecialLedgers_Click(sender As System.Object, e As System.EventArgs) Handles btnSpecialLedgers.Click
        Dim frm As New frmSpecialLedgerAccounts
        frm.ShowDialog()
    End Sub

    Private Sub btnOrganisation_Click(sender As System.Object, e As System.EventArgs) Handles btnOrganisation.Click
        On Error GoTo RaiseErr
        Dim strFilename As String = Application.StartupPath & "\gwtOrganization.exe"
        Cursor = Cursors.WaitCursor
        Shell(strFilename, AppWinStyle.NormalFocus, False)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        MessageBox.Show("The called module is not licensed on your computer" & vbCrLf & _
            "Please contact your software provider for assistance", "Application Licensing Error",
            MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnNewJournal_Click(sender As System.Object, e As System.EventArgs) Handles btnNewJournal.Click
        boolEditStatus = False
        Dim frm As New frmJournalEntry
        frm.ShowDialog()
        LoadJournals()
    End Sub

    Private Sub LoadJournals()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, [TransDate], 105) AS [Date], [JournalNumber], " _
            & "CAST((SUM ([Amount]/2)) AS DECIMAL (10,2)) AS [Amount], [SpecialKey] from JournalEntries " _
            & "WHERE TransDate BETWEEN '" & Format(dpJvStartFrom.Value, "dd-MMM-yyyy") & "' AND " _
            & "'" & Format(dpJvEndTo.Value, "dd-MMM-yyyy") & "' GROUP BY TransDate, JournalNumber, SpecialKey"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Journal listing load"
        ShowErrorMessage()
    End Sub

    Private Sub btnFindJournals_Click(sender As System.Object, e As System.EventArgs) Handles btnFindJournals.Click
        LoadJournals()
    End Sub

    Private Sub btnEditJournal_Click(sender As System.Object, e As System.EventArgs) Handles btnEditJournal.Click
        ShowDetails()
    End Sub

    Private Sub ShowDetails()
        On Error GoTo RaiseErr
        If dGrid.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(1).Value.ToString)
        intSelectedSpecialKey = CInt(dGrid.CurrentRow.Cells(3).Value.ToString)
        boolEditStatus = True
        Dim f As New frmJournalEntry
        f.ShowDialog()
        LoadJournals()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Journal details listing load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        ShowDetails()
    End Sub

    Private Sub btnPrintSeletedRowQuote_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSeletedRowQuote.Click
        On Error GoTo RaiseErr
        If dGrid.Rows.Count <= 0 Then Exit Sub

        Dim intJvNumber As Integer = 0

        If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(1).Value), "") Then
            If IsNumeric(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                intJvNumber = CInt(dGrid.CurrentRow.Cells(1).Value.ToString)
            End If
        Else
            MessageBox.Show("Journal cannot be printed. Journal number is 0", "Invalid JV Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If intJvNumber = 0 Then
            MessageBox.Show("Journal cannot be printed. Journal number is 0", "Invalid JV Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim strSql As String = "SELECT [TransDate], [DebitAccount], " _
            & "[CreditAccount], [Narration], [Amount], " _
            & "[FolioReference],[CostCode] FROM JournalEntries WHERE " _
            & "JournalNumber = " & intJvNumber & ""

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrPrintData As New ArrayList

        Dim dblDebitTotals As Double = 0
        Dim dblCreditTotals As Double = 0

        While objReader.Read
            Dim strType As String = "DEBIT"
            Dim strAccount As String = Nothing
            Dim strCreditAccount As String = objReader("CreditAccount").ToString
            Dim strDebitAccount As String = objReader("DebitAccount").ToString
            Dim strDate As String = Nothing
            Dim strCostCode As String = Nothing
            If Not String.IsNullOrEmpty(strCreditAccount) Then
                strType = "CREDIT"
                strAccount = objReader("CreditAccount").ToString
                dblCreditTotals = dblCreditTotals + CDbl(objReader("Amount").ToString)
            Else
                strAccount = objReader("DebitAccount").ToString
                dblDebitTotals = dblDebitTotals + CDbl(objReader("Amount").ToString)
            End If
            If IsDate(objReader(0).ToString) Then
                strDate = UCase(Format(CDate(objReader(0).ToString), "dd-MMM-yyyy"))
            End If
            If Not IsDBNull(objReader("CostCode").ToString) Then strCostCode = objReader("CostCode").ToString
            If UCase(strType) = "DEBIT" Then
                arrPrintData.Add(objReader("Narration").ToString & ";" & strAccount & ";" & strCostCode & ";" & strType & ";" & Format(CDbl(objReader("Amount").ToString), "##0.00") & ";")
            Else
                arrPrintData.Add(objReader("Narration").ToString & ";" & strAccount & ";" & strCostCode & ";" & strType & "; ;" & Format(CDbl(objReader("Amount").ToString), "##0.00"))
            End If
        End While
        objReader.Close()
        If arrPrintData.Count < 0 Then
            MessageBox.Show("The journal entries have not been saved. " & vbCrLf & _
                "Save them first before attempting to printing", "No Detaild To Print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            'Add the final totals line and leave a line after
            arrPrintData.Add("TOTAL; ; ; ;" & Format(dblDebitTotals, "##0.00") & ";" & Format(dblCreditTotals, "##0.00"))
            arrPrintData.Add(" ; ; ; ; ; ")
        End If

        'send the details to the smart report printer
        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "NARRATION|ACCOUNT NO|COSTCODE|ACTION|DEBIT|CREDIT"
            .strColumnAlignments = "0|0|0|0|2|2"
            .strColumnWidths = "200|110|80|80|80|80"
            .strFooterCaption = "Journal Entry"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "JOURNAL ENTRY NUMBER: " & intJvNumber
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On journal print"
        ShowErrorMessage()
    End Sub
End Class
