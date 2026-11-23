Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLedgerAccountsSetupListing
    Private Sub frmLedgerAccountsSetupListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddTreeNodes()
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

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        GetSelected()
        boolEditStatus = True
        gwt_comm.LedgerAccountSetup()
        AddTreeNodes()
    End Sub

    Private Sub GetSelected()
        On Error GoTo RaiseErr
        If tvAccounts.Nodes.Count > 0 Then
            strSelectedAccount = tvAccounts.SelectedNode.Tag
            Dim strSplit() As String = Split(tvAccounts.SelectedNode.Text, ":")
            strSelectedAccountName = strSplit(1)
            'strSelectedAccount = tvAccounts.SelectedItems(0).Text
            'strSelectedAccountName = tvAccounts.SelectedItems(1).Text
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountName FROM LedgerAccounts WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then strSelectedAccountName = objReader(0).ToString
            End If
            objReader.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger Account Name Fetch"
        ShowErrorMessage()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        gwt_comm.LedgerAccountSetup()
        AddTreeNodes()
    End Sub

    Private Sub tvAccounts_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvAccounts.DoubleClick
        GetSelected()
        boolEditStatus = True
        gwt_comm.LedgerAccountSetup()
        AddTreeNodes()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        GetSelected()
        If MessageBox.Show("Are you sure you want to delete the selected ledger from the system?", "Record Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            'Check first that there are no ledger account transactions in the selected ledger
            Dim dblAccountBalance() As Double = gwt_comm.LedgerAccountBalances(CDate("01-JAN-1901"), CDate(Format(Now, "dd-MMM-yyyy")), _
                strSelectedAccount, 0, 99999999, 0, 99999999)
            If dblAccountBalance(1) <> 0 Then
                MessageBox.Show("This ledger account cannot be deleted without first clearing the transactions in it", "Process Stopped", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM LedgerAccounts WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
            sqlCommand.ExecuteNonQuery()
            sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
            sqlCommand.ExecuteNonQuery()
            MessageBox.Show("Ledger account deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        AddTreeNodes()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Record Deletion Error"
        ShowErrorMessage()
    End Sub

    Private Sub btnChangeCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeCode.Click
        Dim f As New frmLedgerAccountCodeChange
        f.ShowDialog()
        AddTreeNodes()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        AddTreeNodes()
    End Sub

    Private Sub optExpand_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optExpand.CheckedChanged
        If optExpand.Checked = True Then tvAccounts.ExpandAll()
    End Sub

    Private Sub optCollapse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCollapse.CheckedChanged
        If optCollapse.Checked = True Then tvAccounts.CollapseAll()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        'First Get a list of all the main accounts
        Dim strSql As String = "SELECT AccountNumber, AccountName " _
            & "FROM LedgerAccounts WHERE SubAccountOf = 'NONE'"
        Dim arrPrintData As New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            arrPrintData.Add(UCase(objReader(0).ToString) & ";" & UCase(objReader(1).ToString) & "; ; ")
            arrPrintData.Add(" ; ; ; ")
            strSql = "SELECT AccountNumber, AccountName, AccountType, Classification " _
                & "FROM LedgerAccounts WHERE SubAccountOf = '" & objReader(0).ToString & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReadSubAccounts As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            Dim intSubCount As Integer = 0
            While objReadSubAccounts.Read
                arrPrintData.Add(objReadSubAccounts(0).ToString & ";" & objReadSubAccounts(1).ToString & ";" & _
                    objReadSubAccounts(2).ToString & ";" & objReadSubAccounts(3).ToString)
                intSubCount = intSubCount + 1
            End While
            objReadSubAccounts.Close()
            If intSubCount > 0 Then arrPrintData.Add(" ; ; ; ")
        End While
        objReader.Close()

        'send the details to printing
        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 4
            .strColumnHeaders = "ACCOUNT NO.|DESCRIPTION|TYPE|CLASS"
            .strColumnAlignments = "0|0|0|0"
            .strColumnWidths = "120|250|100|140"
            .strFooterCaption = "Chart of Accounts"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "CHART OF ACCOUNTS"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Cursor = Cursors.Default
        If strRequestForReceiptPrinter = "YES" Then
            boolAbort = False
            gwt_comm.PrinterSelection()
            If boolAbort = True Then Exit Sub
            rpt.PrinterSettings.PrinterName = strSessionPrinter
        End If
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Chart Of Accounts Print"
        ShowErrorMessage()
    End Sub

End Class