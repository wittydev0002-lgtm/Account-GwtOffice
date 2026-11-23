Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmBudgets

    '    Private data As List(Of BudgetNode)
    '    Dim strNodePath As String = Nothing
    '    Dim arrRelativeNodesIds As ArrayList

    '    Dim intSelectedAccountIndex As Integer
    '    Dim intDetailIndex As Integer

    '    Private Sub frmBudgets_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    '        LoadLedgerAccountsListing()
    '    End Sub

    '    Private Sub LoadLedgerAccountsListing()
    '        TreeListView1.Columns.Clear()
    '        data = Nothing
    '        InitializeData()
    '    End Sub

    '    Private Sub InitializeData()
    '        On Error GoTo RaiseErr

    '        data = New List(Of BudgetNode)()
    '        TreeListView1.Columns.Clear()
    '        TreeListView1.Items.Clear()
    '        arrRelativeNodesIds = New ArrayList

    '        'My code cracking
    '        'Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [AccountName], [AccountNumber] " _
    '        '    & "FROM LedgerAccounts WHERE SubAccountOf = 'NONE'", cnn)
    '        'Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

    '        While objReader.Read
    '            strNodePath = Nothing
    '            'Dim intStageValues() As Double = ActionCount(CInt(objReader(1).ToString), SelectedPortfolio)
    '            Dim parent1 As New Node(objReader(0).ToString(), objReader(1).ToString())
    '            arrRelativeNodesIds.Add(objReader(1).ToString)
    '            AddNodes(parent1, objReader(1).ToString)
    '            data.Add(parent1)
    '        End While
    '        objReader.Close()
    '        With TreeListView1
    '            .FullRowSelect = True
    '            .GridLines = True
    '        End With
    '        FillTree()



    '        data = New List(Of BudgetNode)()
    '        TreeListView1.Columns.Clear()
    '        TreeListView1.Items.Clear()
    '        arrRelativeNodesIds = New ArrayList

    '        'My code cracking
    '        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [AccountName], [AccountNumber] " _
    '            & "FROM LedgerAccounts WHERE SubAccountOf = 'NONE'", cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '        While objReader.Read
    '            strNodePath = Nothing
    '            Dim intStageValues() As Double = BudgetValues(CInt(objReader(1).ToString))
    '            Dim parent1 As New BudgetNode(objReader(0).ToString(), objReader(1).ToString(), _
    '                CStr(Format(intStageValues(0), "#,##0.00")), CStr(Format(intStageValues(1), "#,##0")), _
    '                CStr(Format(intStageValues(2), "#,##0.00")))
    '            arrRelativeNodesIds.Add(objReader(1).ToString)
    '            AddNodes(parent1, objReader(1).ToString)
    '            data.Add(parent1)
    '        End While
    '        objReader.Close()
    '        With TreeListView1
    '            .FullRowSelect = True
    '            .GridLines = True
    '        End With
    '        FillTree()

    '        '0 = Budgeted, 1=Actual and 2=Variance

    '        Exit Sub
    'RaiseErr:
    '        Cursor = Cursors.Default
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On portfolio anaylysis details populate"
    '        gwt_comm.ShowErrorMessage
    '    End Sub


    '    Private Function BudgetValues(ByVal AccountNumber As String) As Double()
    '        On Error GoTo RaiseErr

    '        Dim dblReturn(0 To 2) As Double
    '        For p As Integer = 0 To dblReturn.Length - 1
    '            dblReturn(p) = 0
    '        Next

    '        'Get the financial year start
    '        Dim YearStart As Date = CDate("01-JAN-" & CStr(DatePart(DateInterval.Year, Now)))

    '        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM financialcalendar order by PeriodNo", cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '        If objReader.HasRows Then
    '            objReader.Read()
    '            If IsDate(objReader("StartDate").ToString) Then
    '                YearStart = CDate(Format(CDate(objReader("StartDate").ToString), "dd-MMM-yyyy"))
    '            End If
    '        End If
    '        objReader.Close()

    '        Dim dblActuals() As Double = gwt_comm.LedgerAccountBalances(YearStart, CDate(Format(Now, "dd-MMM-yyyy")),
    '                                                                    AccountNumber, 0, 9999999, 0, 999999)
    '        Dim dblCurrentMovement As Double = dblActuals(2) - dblActuals(3)

    '        Dim strSqlBudget As String = Nothing
    '        strSqlBudget = "SELECT SUM(Amount) from FinancialBudgets WHERE AccountNumber = '" & AccountNumber & "')"

    '        Dim dblBudgeted As Double = 0

    '        objCommand = New Data.OleDb.OleDbCommand(strSqlBudget, cnn)
    '        objReader = objCommand.ExecuteReader
    '        If objReader.HasRows Then
    '            objReader.Read()
    '            If IsNumeric(objReader(0).ToString) Then
    '                dblBudgeted = CDbl(objReader(0).ToString)
    '            End If
    '        End If
    '        objReader.Close()

    '        Dim dblVariance As Double = dblCurrentMovement - dblBudgeted

    '        dblReturn(0) = dblCurrentMovement
    '        dblReturn(1) = dblBudgeted
    '        dblReturn(2) = dblVariance

    '        Return dblReturn
    '        Exit Function
    'RaiseErr:
    '        boolAbort = True
    '        Return dblReturn
    '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Budget Values Fetch"
    '        gwt_comm.ShowErrorMessage
    '    End Function




    '    Private Sub AddNodes(ByRef sNode As BudgetNode, ByVal Account As String)
    '        On Error GoTo RaiseErr
    '        If Not String.IsNullOrEmpty(strNodePath) Then
    '            strNodePath = strNodePath & "\" & sNode.ActionName
    '        Else
    '            strNodePath = sNode.ActionName
    '        End If
    '        Dim strSql As String = "SELECT [AccountName], [AccountNumber] FROM LedgerAccounts " _
    '            & "WHERE [SubAccountOf] = '" & Account & "'"
    '        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '        While objReader.Read
    '            Dim nNode As New BudgetNode(objReader(0).ToString(), objReader(1).ToString)
    '            sNode.Children.Add(nNode)
    '            arrRelativeNodesIds.Add(objReader(1).ToString)
    '            AddNodes(nNode, objReader(1).ToString)
    '        End While
    '        objReader.Close()
    '        Exit Sub
    'RaiseErr:
    '        Cursor = Cursors.Default
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On portfolio anaylysis details populate"
    '        gwt_comm.ShowErrorMessage
    '    End Sub

    '    Private Sub FillTree()

    '        Me.TreeListView1.CanExpandGetter = Function(x As Object) DirectCast(x, Node).Children.Count > 0
    '        Me.TreeListView1.ChildrenGetter = Function(x As Object) DirectCast(x, Node).Children

    '        ' create the tree columns and set the delegates to print the desired object proerty
    '        Dim ActionNameCol As New BrightIdeasSoftware.OLVColumn("Description", "ActionName")
    '        ActionNameCol.AspectGetter = Function(x As Object) DirectCast(x, Node).ActionName

    '        Dim Count1Col As New BrightIdeasSoftware.OLVColumn("Account Number", "Count1")
    '        Count1Col.AspectGetter = Function(x As Object) DirectCast(x, Node).Count1
    '        Count1Col.TextAlign = HorizontalAlignment.Right

    '        ' add the columns to the tree
    '        Me.TreeListView1.Columns.Add(ActionNameCol)
    '        Me.TreeListView1.Columns.Add(Count1Col)

    '        ' set the tree roots
    '        Me.TreeListView1.Roots = Data

    '        TreeListView1.Columns(0).Width = 290
    '        TreeListView1.Columns(1).Width = 120

    '        TreeListView1.ExpandAll()

    '    End Sub

    '    Private Sub GetSelected()
    '        On Error GoTo RaiseErr
    '        With TreeListView1
    '            If .Items.Count <= 0 Then Exit Sub
    '            intDetailIndex = .SelectedItem.Index
    '            strSelectedAccount = arrRelativeNodesIds.Item(intDetailIndex)
    '            strSelectedAccountName = .SelectedItem.Text
    '        End With
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger Account Name Fetch"
    '        gwt_comm.ShowErrorMessage
    '    End Sub

    '    Private Sub TreeListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeListView1.DoubleClick
    '        GetSelected()
    '        boolEditStatus = True
    '        GetSelected()
    '        If String.IsNullOrEmpty(strSelectedAccount) Or String.IsNullOrEmpty(strSelectedAccountName) Then Exit Sub
    '        On Error Resume Next
    '        Dim frm As New frmAccountBudgeting
    '        frm.ShowDialog()
    '        TreeListView1.SelectedIndex = intDetailIndex
    '    End Sub

    '    Private Sub btnBudget_Click(sender As System.Object, e As System.EventArgs) Handles btnBudget.Click
    '        GetSelected()
    '        If String.IsNullOrEmpty(strSelectedAccount) Or String.IsNullOrEmpty(strSelectedAccountName) Then Exit Sub
    '        On Error Resume Next
    '        Dim frm As New frmAccountBudgeting
    '        frm.ShowDialog()
    '    End Sub

End Class
