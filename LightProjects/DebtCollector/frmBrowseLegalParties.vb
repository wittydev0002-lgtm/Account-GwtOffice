Imports CommonLibrary.Commons

Public Class frmBrowseLegalParties

    Private Sub LoadBrowserPanel(ByVal CallingForm As String)
        On Error GoTo RaiseErr

        'Update for the serial numbers table
        Dim strSql As String = Nothing
        Select Case UCase(CallingForm)
            Case Is = "PLAINTIFS"
                strSql = "SELECT PlaintifId as [Account Number], GivenNames as [Customer Name], " _
                    & "FileId as [File #], CaseNumber AS [Case #] FROM Plaintifs ORDER BY PlaintifId"
            Case Is = "LEGAL DEBTORS"
                strSql = "SELECT DefendantId as [Account Number], GivenNames as [Customer Name], " _
                    & "FileId as [File #], CaseNumber AS [Case #] FROM Defendants " & strWhereClause & "ORDER BY DefendantId"
            Case Is = "DEFENDANTS"

        End Select

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGrid.ColumnCount - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Plaintif Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        Cursor = Cursors.WaitCursor
        'grd.Rows.Clear()
        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim strSql As String = Nothing

        Select Case cboSearchType.Text
            Case Is = "Reference ID"
                Select Case UCase(strCalledBy)
                    Case Is = "PLAINTIFS"
                        strSql = "SELECT PlaintifId as [Account Number], GivenNames as [Customer Name], FileId AS [File #], CaseNumber AS [Case #] " _
                            & "FROM Plaintifs WHERE PlaintifId LIKE '%" & strFind & "%' ORDER BY PlaintifId"
                    Case Is = "LEGAL DEBTORS"
                        strSql = "SELECT DefendantId as [Account Number], GivenNames as [Customer Name], FileId AS [File #], CaseNumber AS [Case #] " _
                            & "FROM Defendants " & strWhereClause & "AND DefendantId LIKE '%" & strFind & "%' ORDER BY DefendantId"
                    Case Is = "DEFENDANTS"

                End Select


            Case Is = "Name" 'Use the grup name
                Select Case UCase(strCalledBy)
                    Case Is = "PLAINTIFS"
                        strSql = "SELECT PlaintifId as [Account Number], GivenNames as [Customer Name], FileId AS [File #], CaseNumber AS [Case #] " _
                            & "FROM Plaintifs WHERE GivenNames LIKE '%" & strFind & "%' ORDER BY GivenNames"
                    Case Is = "LEGAL DEBTORS"
                        strSql = "SELECT DefendantId as [Account Number], GivenNames as [Customer Name], FileId AS [File #], CaseNumber AS [Case #] " _
                            & "FROM Defendants " & strWhereClause & "AND GivenNames LIKE '%" & strFind & "%' ORDER BY GivenNames"
                    Case Is = "DEFENDANTS"

                End Select

            Case Is = "File No" 'Use the grup name
                Select Case UCase(strCalledBy)
                    Case Is = "PLAINTIFS"
                        strSql = "SELECT PlaintifId as [Account Number], GivenNames as [Customer Name], FileId AS [File #], CaseNumber AS [Case #] " _
                            & "FROM Plaintifs WHERE FileId LIKE '%" & strFind & "%' ORDER BY FileId"
                    Case Is = "LEGAL DEBTORS"
                        strSql = "SELECT DefendantId as [Account Number], GivenNames as [Customer Name], FileId AS [File #], CaseNumber AS [Case #] " _
                            & "FROM Defendants " & strWhereClause & "AND FileId LIKE '%" & strFind & "%' ORDER BY FileId"
                    Case Is = "DEFENDANTS"

                End Select

            Case Else
                Select Case UCase(strCalledBy)
                    Case Is = "PLAINTIFS"
                        strSql = "SELECT PlaintifId as [Account Number], GivenNames as [Customer Name], FileId AS [File #], CaseNumber AS [Case #] " _
                            & "FROM Plaintifs WHERE GivenNames LIKE '%" & strFind & "%' ORDER BY GivenNames"
                    Case Is = "LEGAL DEBTORS"
                        strSql = "SELECT DefendantId as [Account Number], GivenNames as [Customer Name], FileId AS [File #], CaseNumber AS [Case #] " _
                            & "FROM Defendants " & strWhereClause & "AND GivenNames LIKE '%" & strFind & "%' ORDER BY GivenNames"
                    Case Is = "DEFENDANTS"

                End Select
        End Select

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        dGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Details Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
        Exit Sub
    End Sub

    Private Sub frmFindInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBrowserPanel(strCalledBy)
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count > 0 Then GetSelectedValues()
    End Sub

    Private Sub GetSelectedValues()
        boolAbort = False
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                strSelectedCode = Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value)
            End If
        End If
        If Not Object.Equals(dGrid.CurrentRow.Cells(1).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                strSelectedDescription = Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(1).Value)
            End If
        End If
        If Not Object.Equals(dGrid.CurrentRow.Cells(2).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(2).Value.ToString) Then
                strSelectedFileNumber = Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(2).Value)
            End If
        End If
        If Not Object.Equals(dGrid.CurrentRow.Cells(3).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(3).Value.ToString) Then
                strSelectedCaseNumber = Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(3).Value)
            End If
        End If
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If dGrid.Rows.Count > 0 Then GetSelectedValues()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If Asc(e.KeyChar) = 13 Then GetSelectedValues()
        SearchForItem(e.KeyChar)
    End Sub

End Class