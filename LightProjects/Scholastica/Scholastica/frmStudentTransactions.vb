Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.IO
Imports System.Text

Public Class frmStudentTransactions

    Dim itm As Double
    Dim strStatementArray As ArrayList
    Dim dblCummulativeStatementBalance As Double

    Private Sub btnExpenses_Click(sender As System.Object, e As System.EventArgs) Handles btnExpenses.Click
        boolEditStatus = False
        strTransferType = "Credit"
        Dim frm As New frmStudentTransactionsEntry
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub frmStudentTransactions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT SC_Students.StudentId AS [Student #], " _
            & "SC_Students.LastName +' '+ SC_Students.FirstName +' '+ SC_Students.OtherNames as [Student Details], " _
            & "CAST(SUM(SC_StudentTransactions.Debit - SC_StudentTransactions.Credit) AS DECIMAL (10,2)) AS [Balance] " _
            & "FROM SC_StudentTransactions LEFT OUTER JOIN SC_Students ON SC_StudentTransactions.StudentId = SC_Students.StudentID " _
            & "GROUP BY SC_Students.LastName, SC_Students.FirstName, SC_Students.OtherNames, SC_Students.StudentId " _
            & "ORDER BY SC_Students.LastName, SC_Students.FirstName, SC_Students.OtherNames"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGrid.Columns.Clear()

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGrid.Columns.Count - 1
            If p = 1 Then
                dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Else
                dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            End If
        Next
        dGrid.Columns(dGrid.Columns.Count - 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        'Compute total
        Dim dblTotal As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(i).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                        dblTotal = dblTotal + CDbl(dGrid.Rows(i).Cells(2).Value.ToString)
                    End If
                End If
            End If
        Next
        lblTotal.Text = Format(dblTotal, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Transactions Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count <= 0 Then Exit Sub
        GetSelected()
        boolEditStatus = True
        Dim frm As New frmStudentTransactionsPrint
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub GetSelected()
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                strSelectedAccount = dGrid.CurrentRow.Cells(0).Value.ToString
            End If
        End If
    End Sub

    Private Sub btnRefreshItems_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshItems.Click
        LoadData()
    End Sub

    Private Sub btnBalance_Click(sender As System.Object, e As System.EventArgs) Handles btnBalance.Click
        gwt_comm.PrintDataGrid(dGrid, "Students Balances")
    End Sub

    Private Sub btnSelectedStatement_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectedStatement.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        boolAbort = False
        Dim f As New frmDateSpecifier
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        strSelectedAccount = dGrid.CurrentRow.Cells(0).Value.ToString
        LoadStatementFinancials()
        PrintStudentStatement()
    End Sub

    Private Sub PrintStudentStatement()

        On Error GoTo RaiseErr

        strStatementArray = New ArrayList

        dblCummulativeStatementBalance = 0

        ''Get the aging balances
        'Dim arrAgeBalances As New ArrayList
        'arrAgeBalances = ComputeAgingBalances(dGrid)

        ''Assign the age balances to common variables
        'dblBetween00and30 = CDbl(arrAgeBalances.Item(0))
        'dblBetween30and60 = CDbl(arrAgeBalances.Item(1))
        'dblBetween60and90 = CDbl(arrAgeBalances.Item(2))
        'dblOver90 = CDbl(arrAgeBalances.Item(3))

        'Get the balance brought forwd
        For i As Integer = 0 To dGridStatements.Rows.Count - 1

            Dim dblDr As Double = 0
            Dim dblCr As Double = 0
            Dim strDt As String = Nothing

            If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(0).Value), "")) Then
                strDt = dGridStatements.Rows(i).Cells(0).Value.ToString
            End If

            If CDate(strDt) < StartDate Then
                'If CDate(strDt) <= EndDate Then
                If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(3).Value), "")) Then
                    If IsNumeric(dGridStatements.Rows(i).Cells(3).Value.ToString) Then
                        dblDr = CDbl(dGridStatements.Rows(i).Cells(3).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(4).Value), "")) Then
                    If IsNumeric(dGridStatements.Rows(i).Cells(4).Value.ToString) Then
                        dblCr = CDbl(dGridStatements.Rows(i).Cells(4).Value.ToString)
                    End If
                End If
                dblCummulativeStatementBalance = dblCummulativeStatementBalance + (dblDr - dblCr)
                'End If
            End If

        Next

        strStatementArray.Add(UCase(Format(StartDate, "dd-MMM-yyyy")) & "|" & UCase("Balance brought forward") & "| | | | |" & Format(dblCummulativeStatementBalance, "#,##0.00"))
        Dim dblBalance As Double = dblCummulativeStatementBalance

        For i As Integer = 0 To dGridStatements.Rows.Count - 1
            Dim strDate As String = Nothing
            Dim strReference As String = Nothing
            Dim strDescription As String = Nothing
            Dim dblDebit As Double = 0
            Dim dblCredit As Double = 0
            Dim strProjectName As String = Nothing

            If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(0).Value), "")) Then
                strDate = dGridStatements.Rows(i).Cells(0).Value.ToString
            End If

            If CDate(strDate) >= StartDate Then
                If CDate(strDate) <= EndDate Then
                    If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(2).Value), "")) Then
                        strReference = dGridStatements.Rows(i).Cells(2).Value.ToString
                    End If
                    If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(1).Value), "")) Then
                        strDescription = dGridStatements.Rows(i).Cells(1).Value.ToString
                    End If
                    If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(3).Value), "")) Then
                        If IsNumeric(dGridStatements.Rows(i).Cells(3).Value.ToString) Then
                            dblDebit = CDbl(dGridStatements.Rows(i).Cells(3).Value.ToString)
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(4).Value), "")) Then
                        If IsNumeric(dGridStatements.Rows(i).Cells(4).Value.ToString) Then
                            dblCredit = CDbl(dGridStatements.Rows(i).Cells(4).Value.ToString)
                        End If
                    End If
                    dblBalance = dblBalance + (dblDebit - dblCredit)
                    'DATE, DESCRIPTION, REF, PROJECT, DEBIT, CREDIT, BALANCE
                    strStatementArray.Add(strDate & "|" & strDescription & "|" & strReference & "|" & strProjectName & "|" & _
                        Format(dblDebit, "#,##0.00") & "|" & Format(dblCredit, "#,##0.00") & "|" & _
                        Format(dblBalance, "#,##0.00"))
                End If
            End If
        Next
        itm = 0

        dblCurrentStatementBalance = dblBalance
        'Adjustment of the moving balance ***

        arrStatementDetails = New ArrayList
        arrStatementDetails = strStatementArray

        'boolPrinterAlreadySelected = False
        PrintCustomerDocument(intSelectedTransaction, "STUDENT STATEMENT")

        'Dim documentPreview As New PrintPreviewDialog
        'documentPreview.Document = pdSelectiveStatement
        'documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Statement Print Error"
        ShowErrorMessage()
    End Sub

    Private Sub LoadStatementFinancials()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "Description, Reference, CAST(Debit AS DECIMAL (10,2)) AS [Debit], CAST(Credit AS DECIMAL (10,2)) AS [Credit], " _
            & "Remarks, TransactionId FROM SC_StudentTransactions WHERE StudentId = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridStatements.Rows.Clear()
        While objReader.Read
            dGridStatements.Rows.Add(objReader(0), objReader(1), _
                objReader(2), objReader(3), _
                objReader(4), objReader(5), objReader(6))
        End While
        objReader.Close()
        ''ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Financials Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnAllStatements_Click(sender As System.Object, e As System.EventArgs) Handles btnAllStatements.Click
        On Error GoTo RaiseErr
        If dGrid.Rows.Count <= 0 Then Exit Sub
        boolAbort = False
        Dim f As New frmDateSpecifier
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        boolDirectPrinting = True
        Cursor = Cursors.WaitCursor
        With Me.ProgressBar1
            .Value = 0
            .Maximum = dGrid.Rows.Count + 5
            .Visible = True
        End With
        For i As Integer = 0 To dGrid.Rows.Count - 1
            strSelectedAccount = dGrid.Rows(i).Cells(0).Value.ToString
            LoadStatementFinancials()
            PrintStudentStatement()
            Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
        Next
        Me.ProgressBar1.Value = Me.ProgressBar1.Maximum
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Statement Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnMain_Click(sender As System.Object, e As System.EventArgs) Handles btnMain.Click
        boolEditStatus = False
        strTransferType = "Debit"
        Dim frm As New frmStudentTransactionsEntry
        frm.ShowDialog()
        LoadData()
    End Sub

End Class
