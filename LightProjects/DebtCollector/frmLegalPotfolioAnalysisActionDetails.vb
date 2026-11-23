Imports CommonLibrary.Commons

Public Class frmLegalPotfolioAnalysisActionDetails

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing

        If strSelectedPortfolioAnalysisId = "0" Then
            strSql = "SELECT Defendants.DefendantId as [Defendant #], Defendants.GivenNames AS [Given Names], " _
                & "Defendants.FileId as [File #], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal] FROM Defendants WHERE DefendantId IN " _
                & "(SELECT DISTINCT(DefendantId) FROM LegalActions WHERE LegalActions.ActionKey = " & intSelectedKeyAnalysisIndex & ")"
        Else
            strSql = "SELECT Defendants.DefendantId as [Defendant #], Defendants.GivenNames AS [Given Names], " _
                & "Defendants.FileId as [File #], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal] FROM Defendants WHERE DefendantId IN " _
                & "(SELECT DISTINCT(DefendantId) FROM LegalActions WHERE LegalActions.PlaintifId = '" & strSelectedPortfolioAnalysisId & "' AND " _
                & "LegalActions.ActionKey = " & intSelectedKeyAnalysisIndex & ")"
        End If

        dGrid.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        AlternateColors(dGrid)
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            If p = dGrid.ColumnCount - 1 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGrid.Columns(p).DefaultCellStyle.Format = "N2"
            End If
        Next
        lblCount.Text = dGrid.Rows.Count

        'Get the sum total of principals
        Dim dblTotalAmount As Double = 0
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(dGrid.ColumnCount - 1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(dGrid.ColumnCount - 1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(dGrid.ColumnCount - 1).Value.ToString) Then
                        dblTotalAmount = dblTotalAmount + CDbl(dGrid.Rows(p).Cells(dGrid.ColumnCount - 1).Value.ToString)
                    End If
                End If
            End If
        Next
        lblTotalAmt.Text = Format(dblTotalAmount, "#,##0.00")
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Potfolio Reconciliation Analysis"
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        gwt_comm.PrintDataGrid(dGrid, "Details of Analysis of Persons on " & strSelectedPortfolioAnalysisStageName & " Stage")
    End Sub

    Private Sub dGrid_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellContentDoubleClick
        GetSelected()
        boolEditStatus = True
        Dim f As New frmDefendants
        f.ShowDialog()
    End Sub

    Private Sub GetSelected()
        If dGrid.Rows.Count > 0 Then
            strSelectedAccountName = Nothing
            strSelectedAccount = dGrid.CurrentRow.Cells(0).Value.ToString
            If Not Object.Equals(dGrid.CurrentRow.Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                    strSelectedAccountName = dGrid.CurrentRow.Cells(1).Value.ToString
                End If
            End If
        End If
    End Sub

    Private Sub AlternateColors(ByVal myGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView)
        With myGrid
            For i As Integer = 0 To .Rows.Count - 1 Step 2
                For j As Integer = 0 To .Columns.Count - 1
                    Dim foreColor As Color = Color.Black
                    Dim backColor As Color = Color.WhiteSmoke
                    .Rows(i).Cells(j).Style.BackColor = backColor
                    .Rows(i).Cells(j).Style.ForeColor = foreColor
                Next j
            Next i
        End With
    End Sub

    Private Sub frmLegalPotfolioAnalysisActionDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.TextExtra = strSelectedPortfolioAnalysisStageName.ToLowerInvariant
        LoadData()
    End Sub

End Class
