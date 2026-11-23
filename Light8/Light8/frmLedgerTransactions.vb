Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLedgerTransactions

    Dim arrAccountTransactions As ArrayList
    Dim _originalSplitterDistance As Integer
    Dim _originalSplitterDistanceSub As Integer
    Dim _widthLeftRight As Integer
    Dim _CurrentSplitterDistance As Integer
    Dim intPriorSplitterDistance As Integer
    Dim boolFormLoading As Boolean

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

    Private Sub frmLedgerTransactions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadLedgers()
    End Sub

    Private Sub LoadLedgers()
        tvAccounts.Nodes.Clear()
        StartDate = Now : EndDate = Now
        boolAbort = False
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

        Dim strStartDate As String = CStr(gwt_comm.shortMonthDateFormat(dpStartDate.Value))
        Dim strEndDate As String = CStr(gwt_comm.shortMonthDateFormat(dpEndDate.Value))

        Dim dblLedgerBalanceBroughtDown() As Double = gwt_comm.LedgerAccountBalances(CDate(strStartDate),
            CDate(strEndDate), AccountNumber)

        lblLedgerPeriodStartBalance.Text = Format(dblLedgerBalanceBroughtDown(0), "#,##0.00")

        'lblLedgerBFbalanceType
        If dblLedgerBalanceBroughtDown(0) < 0 Then lblLedgerBFbalanceType.Text = "CR" Else lblLedgerBFbalanceType.Text = "DR"

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransactionDate, 105) as [Date], " _
            & "Description, FolioReference, ContraAccount, CAST(Amount as DECIMAL (30,2)) AS [Amt], TransactionType, TransactionId, SpecialKey " _
            & "FROM LedgerTransactions WHERE AccountNumber = '" & AccountNumber & "' AND TransactionDate BETWEEN " _
            & "'" & strStartDate & "' AND '" & strEndDate & "'", cnn)
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

    Private Sub btnFindData_Click(sender As System.Object, e As System.EventArgs) Handles btnFindData.Click
        If Not Object.Equals(tvAccounts.SelectedNode, Nothing) Then
            strSelectedAccount = tvAccounts.SelectedNode.Tag
            Dim strSplit() As String = Split(tvAccounts.SelectedNode.Text, ":")
            strSelectedAccountName = strSplit(1)
            lblAccountName.Text = tvAccounts.SelectedNode.Text
            LoadSelectedLedgerAccountDetails(tvAccounts.SelectedNode.Tag)
        End If
    End Sub

    Private Sub btnOpenExpenses_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenExpenses.Click
        Dim frm As New frmOpenExpenses
        frm.ShowDialog()
    End Sub

    Private Sub dGridLedgers_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridLedgers.CellClick
        If dGridLedgers.Rows.Count <= 0 Then Exit Sub
        If dGridLedgers.CurrentCell.ColumnIndex = 7 Then
            ReverseTransaction()
        End If
    End Sub

    Private Sub ReverseTransaction()
        On Error GoTo RaiseErr
        Dim intTransaction As Integer = CInt(dGridLedgers.CurrentRow.Cells(6).Value.ToString)
        MessageBox.Show("This transaction " & CStr(intTransaction) & " cannot be deleted. Please pass a journal instead", "Process Intercepted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Ledger account transaction reversal"
        ShowErrorMessage()
    End Sub

    Private Sub btnRestartAccount_Click(sender As Object, e As EventArgs) Handles btnRestartAccount.Click
        If MessageBox.Show("Are you sure you want to clear down this account?",
            "Confirm Account Clear Down", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            boolAbort = False
            gwt_comm.DateSpecification()
            If boolAbort = True Then Exit Sub
            If Not Object.Equals(tvAccounts.SelectedNode, Nothing) Then
                strSelectedAccount = tvAccounts.SelectedNode.Tag
                Dim strSplit() As String = Split(tvAccounts.SelectedNode.Text, ":")
                strSelectedAccountName = strSplit(1)
                lblAccountName.Text = tvAccounts.SelectedNode.Text
                AccountClearDown(strSelectedAccount, dtSetDate)
            End If
        End If
    End Sub

    Private Sub AccountClearDown(ByVal AccountNumber As String, ByVal CutOffDate As Date)
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If gwt_comm.CheckTableExistence("LedgerTransactionsArchive") = False Then
            strSql = "CREATE TABLE LedgerTransactionsArchive (
            [TransactionDate] [smalldatetime] NOT NULL,
	            [AccountNumber] [nvarchar](35) NOT NULL,
	            [Amount] [float] NOT NULL DEFAULT ((0)),
	            [TransactionType] [nvarchar](10) NOT NULL,
	            [ContraAccount] [nvarchar](35) NOT NULL,
	            [Description] [nvarchar](150) NOT NULL,
	            [UserName] [nvarchar](35) NOT NULL,
	            [UserBranch] [nvarchar](150) NOT NULL,
	            [Reference] [nvarchar](150) NOT NULL  DEFAULT (''),
	            [FolioReference] [nvarchar](50) NOT NULL  DEFAULT (''),
	            [BranchCode] [int] NOT NULL DEFAULT ((0)),
	            [DepartmentCode] [float] NOT NULL DEFAULT ((0)),
	            [ReceiptNumber] [int] NOT NULL DEFAULT ((0)),
	            [InvoiceNumber] [int] NOT NULL DEFAULT ((0)),
	            [DebitNoteNumber] [int] NOT NULL DEFAULT ((0)),
	            [CreditNoteNumber] [int] NOT NULL DEFAULT ((0)),
	            [CostCode] [int] NOT NULL DEFAULT ((0)),
	            [JournalNumber] [int] NOT NULL DEFAULT ((0)),
	            [LinkedProject] [int] NOT NULL DEFAULT ((0)),
	            [TransactionId][INT] NOT NULL PRIMARY KEY IDENTITY (1,1)
	            )"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        strSql = "INSERT INTO [LedgerTransactionsArchive] ([TransactionDate], [AccountNumber], [Amount], [TransactionType], [ContraAccount], 
            [Description], [UserName], [UserBranch], [Reference], [FolioReference], [BranchCode], [DepartmentCode], 
            [ReceiptNumber], [InvoiceNumber], [DebitNoteNumber], [CreditNoteNumber], [CostCode], [JournalNumber], [LinkedProject]) 
            SELECT [TransactionDate], [AccountNumber], [Amount], [TransactionType], [ContraAccount], 
            [Description], [UserName], [UserBranch], [Reference], [FolioReference], [BranchCode], [DepartmentCode], 
            [ReceiptNumber], [InvoiceNumber], [DebitNoteNumber], [CreditNoteNumber], [CostCode], [JournalNumber], [LinkedProject] 
            FROM LedgerTransactions WHERE AccountNumber = '" & AccountNumber & "' AND 
            TransactionDate Between '01-JAN-1950' AND '" & gwt_comm.shortMonthDateFormat(CutOffDate) & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "DELETE FROM LedgerTransactions WHERE AccountNumber = '" & AccountNumber & "' AND 
            TransactionDate Between '01-JAN-1950' AND '" & gwt_comm.shortMonthDateFormat(CutOffDate) & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Cursor = DefaultCursor

        MessageBox.Show("Account has been cleared successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadSelectedLedgerAccountDetails(AccountNumber)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = DefaultCursor
        strErrorMessages = Err.Description & vbCrLf & " Error Number: " & Err.Number & vbCrLf & "On Account Clear Down"
        ShowErrorMessage()
    End Sub

End Class