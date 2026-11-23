Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing
Imports System.Drawing.Printing
Imports DebtCollector

Public Class frmLedgerAccountsSetupListing

    Private data As List(Of Node)
    Dim strNodePath As String = Nothing
    Dim arrRelativeNodesIds As ArrayList

    Dim intSelectedAccountIndex As Integer
    Dim intDetailIndex As Integer

    Private Sub LoadLedgerAccountsListing()
        TreeListView1.Columns.Clear()
        data = Nothing
        InitializeData()
    End Sub

    Private Sub InitializeData()
        On Error GoTo RaiseErr

        data = New List(Of Node)()
        TreeListView1.Columns.Clear()
        TreeListView1.Items.Clear()
        arrRelativeNodesIds = New ArrayList

        'My code cracking
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [AccountName], [AccountNumber] " _
            & "FROM LedgerAccounts WHERE SubAccountOf = 'NONE'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            strNodePath = Nothing
            'Dim intStageValues() As Double = ActionCount(CInt(objReader(1).ToString), SelectedPortfolio)
            Dim parent1 As New Node(objReader(0).ToString(), objReader(1).ToString())
            arrRelativeNodesIds.Add(objReader(1).ToString)
            AddNodes(parent1, objReader(1).ToString)
            data.Add(parent1)
        End While
        objReader.Close()
        With TreeListView1
            .FullRowSelect = True
            .GridLines = True
        End With
        FillTree()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On portfolio anaylysis details populate"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub AddNodes(ByRef sNode As Node, ByVal Account As String)
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(strNodePath) Then
            strNodePath = strNodePath & "\" & sNode.ActionName
        Else
            strNodePath = sNode.ActionName
        End If
        Dim strSql As String = "SELECT [AccountName], [AccountNumber] FROM LedgerAccounts " _
            & "WHERE [SubAccountOf] = '" & Account & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            'Dim intStageValues() As Double = ActionCount(CInt(objReader(1).ToString), strPortfolio)
            Dim nNode As New Node(objReader(0).ToString(), objReader(1).ToString)
            sNode.Children.Add(nNode)
            arrRelativeNodesIds.Add(objReader(1).ToString)
            AddNodes(nNode, objReader(1).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On portfolio anaylysis details populate"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub FillTree()

        Me.TreeListView1.CanExpandGetter = Function(x As Object) DirectCast(x, Node).Children.Count > 0
        Me.TreeListView1.ChildrenGetter = Function(x As Object) DirectCast(x, Node).Children

        ' create the tree columns and set the delegates to print the desired object proerty
        Dim ActionNameCol As New BrightIdeasSoftware.OLVColumn("Description", "ActionName")
        ActionNameCol.AspectGetter = Function(x As Object) DirectCast(x, Node).ActionName

        Dim Count1Col As New BrightIdeasSoftware.OLVColumn("Account Number", "Count1")
        Count1Col.AspectGetter = Function(x As Object) DirectCast(x, Node).Count1
        Count1Col.TextAlign = HorizontalAlignment.Right

        ' add the columns to the tree
        Me.TreeListView1.Columns.Add(ActionNameCol)
        Me.TreeListView1.Columns.Add(Count1Col)

        ' set the tree roots
        Me.TreeListView1.Roots = Data

        TreeListView1.Columns(0).Width = 510
        TreeListView1.Columns(1).Width = 130
        
        TreeListView1.ExpandAll()

    End Sub

    Private Sub GetSelected()
        On Error GoTo RaiseErr
        With TreeListView1
            If .Items.Count <= 0 Then Exit Sub
            intDetailIndex = .SelectedItem.Index
            strSelectedAccount = arrRelativeNodesIds.Item(intDetailIndex)
            strSelectedAccountName = .SelectedItem.Text
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger Account Name Fetch"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub TreeListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeListView1.DoubleClick
        GetSelected()
        boolEditStatus = True
        gwt_comm.LedgerAccountSetup()
        LoadLedgerAccountsListing()
        TreeListView1.SelectedIndex = intDetailIndex
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
        LoadLedgerAccountsListing()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Record Deletion Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnChangeCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeCode.Click
        Dim f As New frmLedgerAccountCodeChange
        f.ShowDialog()
        LoadLedgerAccountsListing()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadLedgerAccountsListing()
    End Sub

    Private Sub optExpand_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optExpand.CheckedChanged
        If optExpand.Checked = True Then TreeListView1.ExpandAll()
    End Sub

    Private Sub optCollapse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCollapse.CheckedChanged
        If optCollapse.Checked = True Then TreeListView1.CollapseAll()
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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmLedgerAccountsSetupListing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadLedgerAccountsListing()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        GetSelected()
        boolEditStatus = True
        gwt_comm.LedgerAccountSetup()
        LoadLedgerAccountsListing()
        TreeListView1.SelectedIndex = intDetailIndex
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        gwt_comm.LedgerAccountSetup()
        LoadLedgerAccountsListing()
    End Sub

    Private Sub btnSpecialLedgers_Click(sender As System.Object, e As System.EventArgs) Handles btnSpecialLedgers.Click
        gwt_comm.SpecialLedgerAccounts()
    End Sub

End Class