Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing
Imports System.Drawing.Printing

Public Class frmDebtCollectorMain

    Dim boolActiveSearch As Boolean = False
    Dim intColumnIndex As Integer
    Dim intStartIndex As Integer
    Dim boolformLoading As Boolean

    Private data As List(Of Node)
    Dim strNodePath As String = Nothing

    Dim _originalSplitterDistance As Integer
    Dim _originalSplitterDistanceSub As Integer
    Dim _widthLeftRight As Integer
    Dim _CurrentSplitterDistance As Integer
    Dim intPriorSplitterDistance As Integer

    Dim intSelectedActionKey As Integer = 0

    Dim strRichData As String = Nothing
    Dim intXstart As Integer

    Dim arrRelativeNodesIds As ArrayList

    Private Sub frmDebtCollectorMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        boolformLoading = True
        LoadClients()
        If boolAbort = True Then Exit Sub
        LoadPortfolioData("Client Name")
        If boolAbort = True Then Exit Sub
        LoadReceiptClients()
        If boolAbort = True Then Exit Sub
        'cboSearchBy.Text = "Name"
        'If UCase(strUserLevel) <> "ADMINISTRATOR" Then AssignView()
        LoadPotfolio()
        If boolAbort = True Then Exit Sub
        InitializeData("0")
        If boolAbort = True Then Exit Sub
        AddStageTreeNodes()
        If boolAbort = True Then Exit Sub
        txtReceiptPortfolioId.Text = "0"
        boolformLoading = False
    End Sub

    Private Sub AssignView()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT PotfolionId FROM DebtorsPotfolios WHERE AssignedUserName = '" & strUserName & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then lblClientId.Text = objReader(0).ToString
            'Select the client name
            strSql = "SELECT GivenNames FROM Plaintifs WHERE PlaintifID = '" & lblClientId.Text & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReadName As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadName.HasRows Then
                objReadName.Read()
                If Not IsDBNull(objReadName(0).ToString) Then cboClients.SelectedText = objReadName(0).ToString
            End If
            objReadName.Close()
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On View Assignment"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        If dGrid.RowCount <= 0 Then Exit Sub
        GetSelected()
        boolEditStatus = True
        Dim f As New frmDefendants
        f.ShowDialog()
    End Sub

    Private Sub dGrid_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dGrid.CellMouseDown
        If e.Button = MouseButtons.Right Then
            ' Add this
            dGrid.CurrentCell = dGrid.Rows(e.RowIndex).Cells(e.ColumnIndex)
            ' Can leave these here - doesn't hurt
            dGrid.Rows(e.RowIndex).Selected = True
            dGrid.Focus()
        End If
    End Sub

    Private Sub LoadClients()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT GivenNames +'|'+ PlaintifID AS " _
            & "[Details] FROM Plaintifs ORDER BY GivenNames", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrData As New ArrayList

        If UCase(strUserLevel) = UCase("Administrator") Then
            arrData.Add("--ALL--|0")
        End If

        While objReader.Read
            If UCase(strUserLevel) <> UCase("Administrator") Then
                If Not IsDBNull(objReader(0).ToString) Then
                    Dim strSplitName() As String = Split(objReader(0).ToString, "|")
                    For z As Integer = 0 To arrPublicPotfolioClientName.Count - 1
                        If UCase(strSplitName(0)) = UCase(arrPublicPotfolioClientName.Item(z)) Then
                            arrData.Add(objReader(0).ToString)
                        End If
                    Next
                End If
            Else
                If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboClients.Width - 80

        'Add the items to the drop down box
        With cboClients
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth1 & ";80"
        End With

        With cboPortfolioAnalysis
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth1 & ";80"
        End With

        With cboUnservedClients
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth1 & ";80"
        End With

        With cboClientspp
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth1 & ";80"
        End With

        With cboReceiptsPortfolio
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth1 & ";80"
        End With

        'Get a count of the items
        Dim intItemsCount As Integer = arrData.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboClients.Items.Clear()
        cboPortfolioAnalysis.Items.Clear()
        cboUnservedClients.Items.Clear()
        cboClientspp.Items.Clear()
        cboReceiptsPortfolio.Items.Clear()

        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboClients
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
            With cboPortfolioAnalysis
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
            With cboUnservedClients
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
            With cboClientspp
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
            With cboReceiptsPortfolio
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Client Names Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClients.SelectedIndexChanged
        lblActiveAction.Text = Nothing
        If Not cboClients.SelectedItem Is Nothing Then
            lblClientId.Text = cboClients.SelectedItem.Col2
            LoadDefendantsListing(lblClientId.Text)
        Else
            lblClientId.Text = "0"
        End If
    End Sub

    Private Sub cboUnservedClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUnservedClients.SelectedIndexChanged
        If Not cboUnservedClients.SelectedItem Is Nothing Then
            lblUnservedClients.Text = cboUnservedClients.SelectedItem.Col2
            LoadUnservedDebtors(lblUnservedClients.Text)
        Else
            lblUnservedClients.Text = "0"
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmDefendants
        frm.ShowDialog()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If dGrid.RowCount <= 0 Then Exit Sub
        GetSelected()
        boolEditStatus = True
        Dim f As New frmDefendants
        f.ShowDialog()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        AddStageTreeNodes()
        LoadDefendantsListing(lblClientId.Text)
    End Sub

    Private Sub GetSelected()
        If dGrid.Rows.Count > 0 Then
            strSelectedAccountName = Nothing
            strSelectedAccount = dGrid.CurrentRow.Cells(1).Value.ToString
            If Not Object.Equals(dGrid.CurrentRow.Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(2).Value.ToString) Then
                    strSelectedAccountName = dGrid.CurrentRow.Cells(2).Value.ToString
                End If
            End If
            If IsNumeric(dGrid.CurrentRow.Cells(6).Value) Then
                dblClientBalance = CDbl(dGrid.CurrentRow.Cells(6).Value.ToString)
            End If
        End If
    End Sub

    Private Sub LoadDefendantsListing(ByVal PlaintifId As String)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Cursor = Cursors.WaitCursor
        If lblClientId.Text = "0" Then

            'strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames, Defendants.FileId AS [File #], " _
            '    & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
            '    & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
            '    & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
            '    & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
            '    & "Defendants.CaseNumber AS [Case #], " _
            '    & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
            '    & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
            '    & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
            '    & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
            '    & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
            '    & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone"

            strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                        & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                        & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                        & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                        & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                        & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                        & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                        & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                        & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                        & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b " _
                        & "WHERE a.DefendantId = b.DefendantId) " _
                        & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                        & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
                        & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone, a.ActionDate " _
                        & "ORDER BY a.defendantId"

        Else

            'strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames, Defendants.FileId AS [File #], " _
            '    & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
            '    & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
            '    & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
            '    & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
            '    & "Defendants.CaseNumber AS [Case #], " _
            '    & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
            '    & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
            '    & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
            '    & "WHERE Defendants.PlaintifId = '" & lblClientId.Text & "' " _
            '    & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
            '    & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
            '    & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone"

            strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                        & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                        & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                        & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                        & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                        & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                        & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                        & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                        & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                        & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b " _
                        & "WHERE a.DefendantId = b.DefendantId) " _
                        & "AND Defendants.PlaintifId = '" & lblClientId.Text & "' " _
                        & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                        & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
                        & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone, a.ActionDate " _
                        & "ORDER BY Defendants.GivenNames"

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

        Dim crm As New DataGridViewCheckBoxColumn
        With crm
            .Width = 25
            .HeaderText = ""
        End With
        dGrid.Columns.Insert(0, crm)
        dGrid.Columns(0).ReadOnly = False
        dGrid.Columns(2).Frozen = True

        For p As Integer = 1 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dGrid.Columns(p).ReadOnly = True
            If p > 4 And p <= 8 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGrid.Columns(p).DefaultCellStyle.Format = "N2"
            End If
        Next

        lblCount.Text = dGrid.RowCount

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Names Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnFindNext_Click(sender As System.Object, e As System.EventArgs) Handles btnFindNext.Click
        While intStartIndex <= dGrid.Rows.Count - 1
            If UCase(Mid(dGrid.Rows(intStartIndex).Cells(intColumnIndex).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                dGrid.FirstDisplayedCell = dGrid.Rows(intStartIndex).Cells(intColumnIndex)
                dGrid.FirstDisplayedCell.Selected = True
                dGrid.CurrentCell = dGrid.Rows(intStartIndex).Cells(intColumnIndex)
                intStartIndex = intStartIndex + 1
                Exit Sub
            End If
            intStartIndex = intStartIndex + 1
        End While
        MessageBox.Show("Search has reached end of records", "Data Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnFind_Click(sender As System.Object, e As System.EventArgs) Handles btnFind.Click
        StartFind()
    End Sub

    Private Sub StartFind()
        intStartIndex = 0
        While intStartIndex <= dGrid.Rows.Count - 1
            If UCase(Mid(dGrid.Rows(intStartIndex).Cells(intColumnIndex).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                dGrid.FirstDisplayedCell = dGrid.Rows(intStartIndex).Cells(intColumnIndex)
                dGrid.FirstDisplayedCell.Selected = True
                dGrid.CurrentCell = dGrid.Rows(intStartIndex).Cells(intColumnIndex)
                intStartIndex = intStartIndex + 1
                Exit Sub
            End If
            intStartIndex = intStartIndex + 1
        End While
        MessageBox.Show("Search has reached end of records", "Data Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub txtSearchString_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If chkDisable.Checked = True Then
            SearchForItem(e.KeyChar)
        End If
    End Sub

    Private Sub txtSearchString_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchString.TextChanged
        'Handles the search function. as the use types the string, the grid positions itself to the nearest match
        If chkDisable.Checked = True Then Exit Sub
        Dim i As Integer = 0
        With dGrid
            For i = 0 To dGrid.Rows.Count - 1
                Select Case cboSearchBy.Text
                    Case Is = "Number"
                        If UCase(Mid(.Rows(i).Cells(1).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(1)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                    Case Is = "Name"
                        If UCase(Mid(.Rows(i).Cells(2).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(2)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                    Case Is = "File Number"
                        If UCase(Mid(.Rows(i).Cells(3).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(3)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                    Case Else
                        'Use the last name
                        If UCase(Mid(.Rows(i).Cells(1).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(1)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                End Select
            Next
        End With
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        strActiveSearch = strFind
        Cursor = Cursors.WaitCursor

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim strSql As String = Nothing

        Select Case cboSearchBy.Text
            Case Is = "Number"
                If UCase(cboClients.Text) = "--ALL--" Then
                    strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                        & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                        & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                        & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                        & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                        & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                        & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                        & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                        & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                        & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b " _
                        & "WHERE a.DefendantId = b.DefendantId) AND Defendants.DefendantId LIKE '%" & strFind & "%' " _
                        & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                        & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
                        & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone, a.ActionDate " _
                        & "ORDER BY a.defendantId"

                Else

                    strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                        & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                        & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                        & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                        & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                        & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                        & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                        & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                        & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                        & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b " _
                        & "WHERE a.DefendantId = b.DefendantId) AND Defendants.DefendantId LIKE '%" & strFind & "%' " _
                        & "AND Defendants.PlaintifId = '" & lblClientId.Text & "' " _
                        & "AND Defendants.PlaintifId = '" & lblClientId.Text & "' " _
                        & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                        & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
                        & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone, a.ActionDate " _
                        & "ORDER BY a.defendantId"

                End If
            Case Is = "Name"

                If UCase(cboClients.Text) = "--ALL--" Then

                    strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                        & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                        & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                        & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                        & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                        & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                        & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                        & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                        & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                        & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b " _
                        & "WHERE a.DefendantId = b.DefendantId) AND Defendants.GivenNames LIKE '%" & strFind & "%' " _
                        & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                        & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
                        & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone, a.ActionDate " _
                        & "ORDER BY Defendants.GivenNames"

                Else
                    strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                        & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                        & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                        & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                        & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                        & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                        & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                        & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                        & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                        & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b " _
                        & "WHERE a.DefendantId = b.DefendantId) AND Defendants.GivenNames LIKE '%" & strFind & "%' " _
                        & "AND Defendants.PlaintifId = '" & lblClientId.Text & "' " _
                        & "AND Defendants.PlaintifId = '" & lblClientId.Text & "' " _
                        & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                        & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
                        & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone, a.ActionDate " _
                        & "ORDER BY Defendants.GivenNames"
                End If

            Case Is = "File Number"

                If UCase(cboClients.Text) = "--ALL--" Then

                    strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                        & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                        & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                        & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                        & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                        & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                        & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                        & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                        & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                        & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b " _
                        & "WHERE a.DefendantId = b.DefendantId) AND Defendants.FileId LIKE '%" & strFind & "%' " _
                        & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                        & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
                        & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone, a.ActionDate " _
                        & "ORDER BY Defendants.FileId"

                Else

                    strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                        & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                        & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                        & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                        & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                        & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                        & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                        & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                        & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                        & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b " _
                        & "WHERE a.DefendantId = b.DefendantId) AND Defendants.FileId LIKE '%" & strFind & "%' " _
                        & "AND Defendants.PlaintifId = '" & lblClientId.Text & "' " _
                        & "AND Defendants.PlaintifId = '" & lblClientId.Text & "' " _
                        & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                        & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
                        & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone, a.ActionDate " _
                        & "ORDER BY Defendants.FileId"

                End If

            Case Else

                If UCase(cboClients.Text) = "--ALL--" Then

                    strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                        & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                        & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                        & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                        & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                        & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                        & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                        & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                        & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                        & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b " _
                        & "WHERE a.DefendantId = b.DefendantId) AND Defendants.GivenNames LIKE '%" & strFind & "%' " _
                        & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                        & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
                        & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone, a.ActionDate " _
                        & "ORDER BY Defendants.GivenNames"

                Else
                    strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                        & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                        & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                        & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                        & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                        & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                        & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                        & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                        & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                        & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b " _
                        & "WHERE a.DefendantId = b.DefendantId) AND Defendants.GivenNames LIKE '%" & strFind & "%' " _
                        & "AND Defendants.PlaintifId = '" & lblClientId.Text & "' " _
                        & "AND Defendants.PlaintifId = '" & lblClientId.Text & "' " _
                        & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                        & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
                        & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone, a.ActionDate " _
                        & "ORDER BY Defendants.GivenNames"

                End If

        End Select

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        Dim crm As New DataGridViewCheckBoxColumn
        With crm
            .Width = 25
            .HeaderText = ""
        End With
        dGrid.Columns.Insert(0, crm)
        dGrid.Columns(0).ReadOnly = False
        dGrid.Columns(2).Frozen = True

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            If p > 3 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGrid.Columns(p).DefaultCellStyle.Format = "N2"
            End If
        Next

        lblCount.Text = dGrid.RowCount

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On client search"
        ShowErrorMessage()
        Exit Sub
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim f As New frmImportDefendants
        f.ShowDialog()
    End Sub

    Private Sub btnPlaceOnHold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlaceOnHold.Click
        If dGrid.Rows.Count > 0 Then
            strPublicFinancialClientType = "DEFENDANTS"
            GetAllSelectedRecords()
            Dim frm As New frmLegalFileHold
            frm.ShowDialog()
        End If
    End Sub

    Private Sub chkDisable_Click(sender As System.Object, e As System.EventArgs) Handles chkDisable.Click
        If chkDisable.Checked = True Then
            boolActiveSearch = True
        Else
            boolActiveSearch = False
        End If
    End Sub

    Private Sub LoadPotfolio()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing
        dGrid.Columns.Clear()
        strSql = "SELECT Defendants.DefendantId as [Defendant #], Defendants.GivenNames as [Given Names], " _
                & "Defendants.FileId AS [File #], Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ Defendants.PrimaryAddress4 AS [Address], " _
                & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance] " _
                & "FROM Defendants LEFT OUTER JOIN DefendantTransactions " _
                & "ON Defendants.DefendantId = DefendantTransactions.DefendantId WHERE Defendants.PlaintifId = '" & lblClientId.Text & "' " _
                & "GROUP BY Defendants.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4 ORDER BY Defendants.GivenNames"

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        'AlternateColors(dGrid)
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            If p > 3 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGrid.Columns(p).DefaultCellStyle.Format = "N2"
            End If
        Next
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On potfolio details load"
        ShowErrorMessage()
    End Sub

    Private Sub cboSearchBy_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSearchBy.SelectedIndexChanged
        If boolformLoading = True Then Exit Sub
        Dim strValue As String = cboSearchBy.Text

        If UCase(strValue) = UCase("Number") Then intColumnIndex = 1
        If UCase(strValue) = UCase("Name") Then intColumnIndex = 2
        If UCase(strValue) = UCase("File Number") Then intColumnIndex = 3

        Cursor = Cursors.WaitCursor
        dGrid.Sort(dGrid.Columns(intColumnIndex), System.ComponentModel.ListSortDirection.Ascending)
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuPayments_Click(sender As System.Object, e As System.EventArgs) Handles mnuPayments.Click
        GetSelected()
        Dim frm As New frmLegalPaymentsUpdate
        frm.ShowDialog()
    End Sub

    Private Sub mnuEditRecord_Click(sender As System.Object, e As System.EventArgs) Handles mnuEditRecord.Click
        GetSelected()
        boolEditStatus = True
        Dim f As New frmDefendants
        f.ShowDialog()
    End Sub

    Private Sub PaymentPlansToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PaymentPlansToolStripMenuItem.Click
        GetSelected()
        boolEditStatus = False
        Dim f As New frmLegalPaymentPlanTerms
        f.ShowDialog()
    End Sub

    Private Sub btnLegalStaggings_Click(sender As System.Object, e As System.EventArgs) Handles btnLegalStaggings.Click
        Dim frm As New frmLegalActionsSetup
        frm.ShowDialog()
    End Sub

    '******************************************************************************************************************
    ' PORTFOLIO MANAGEMENT CODE                                                                                       *
    '******************************************************************************************************************

    Private Sub LoadPortfolioData(ByVal SortOrder As String)
        On Error GoTo RaiseErr
        dGridPortfolio.Columns.Clear()
        Dim strSql As String = Nothing
        Select Case UCase(SortOrder)
            Case Is = UCase("Client Number")
                strSql = "SELECT Plaintifs.PlaintifId AS [Client #], Plaintifs.GivenNames AS [Client Name], " _
                    & "CONVERT(NVARCHAR, Plaintifs.TakeOnDate, 105) AS [Date Engaged], Plaintifs.Address1 +' '+ " _
                    & "Plaintifs.Address2 +' '+ Plaintifs.Address3 +' '+ Plaintifs.Address4 AS [Address], " _
                    & "PlaintifContacts.GivenNames AS [Contact Person], Plaintifs.Telephone AS [Telephone], " _
                    & "Plaintifs.EmailAddress AS [Email Address] FROM Plaintifs LEFT OUTER JOIN PlaintifContacts " _
                    & "ON Plaintifs.PlaintifId = PlaintifContacts.PlaintifID " _
                    & "ORDER BY Plaintifs.PlaintifId"
            Case Is = UCase("Client Name")
                strSql = "SELECT Plaintifs.PlaintifId AS [Client #], Plaintifs.GivenNames AS [Client Name], " _
                    & "CONVERT(NVARCHAR, Plaintifs.TakeOnDate, 105) AS [Date Engaged], Plaintifs.Address1 +' '+ " _
                    & "Plaintifs.Address2 +' '+ Plaintifs.Address3 +' '+ Plaintifs.Address4 AS [Address], " _
                    & "PlaintifContacts.GivenNames AS [Contact Person], Plaintifs.Telephone AS [Telephone], " _
                    & "Plaintifs.EmailAddress AS [Email Address] FROM Plaintifs LEFT OUTER JOIN PlaintifContacts " _
                    & "ON Plaintifs.PlaintifId = PlaintifContacts.PlaintifID " _
                    & "ORDER BY Plaintifs.GivenNames"
            Case Else
                strSql = "SELECT Plaintifs.PlaintifId AS [Client #], Plaintifs.GivenNames AS [Client Name], " _
                    & "CONVERT(NVARCHAR, Plaintifs.TakeOnDate, 105) AS [Date Engaged], Plaintifs.Address1 +' '+ " _
                    & "Plaintifs.Address2 +' '+ Plaintifs.Address3 +' '+ Plaintifs.Address4 AS [Address], " _
                    & "PlaintifContacts.GivenNames AS [Contact Person], Plaintifs.Telephone AS [Telephone], " _
                    & "Plaintifs.EmailAddress AS [Email Address] FROM Plaintifs LEFT OUTER JOIN PlaintifContacts " _
                    & "ON Plaintifs.PlaintifId = PlaintifContacts.PlaintifID " _
                    & "ORDER BY Plaintifs.GivenNames"
        End Select

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridPortfolio.DataSource = dTable

        Me.dGridPortfolio.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGridPortfolio.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGridPortfolio.Columns.Count - 1
            dGridPortfolio.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Portfolio Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnNewPortfolio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewPortfolio.Click
        boolEditStatus = False
        Dim f As New frmPlaintifDetails
        f.ShowDialog()
    End Sub

    Private Sub txtPortfolioSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPortfolioSearchString.KeyPress
        SearchForPortfolioItem(e.KeyChar)
    End Sub

    Private Sub SearchForPortfolioItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = txtPortfolioSearchString.Text & strCurrentKey
        strActiveSearch = strFind
        Cursor = Cursors.WaitCursor

        dGridPortfolio.Columns.Clear()
        Me.dGridPortfolio.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim strSql As String = Nothing

        Select Case cboPortfolioSearchBy.Text
            Case Is = "Client Number"
                If UCase(cboPortfolioStatus.Text) <> "ALL" Then
                    strSql = "SELECT Plaintifs.PlaintifId AS [Client #], Plaintifs.GivenNames AS [Client Name], " _
                        & "CONVERT(NVARCHAR, Plaintifs.TakeOnDate, 105) AS [Date Engaged], Plaintifs.Address1 +' '+ " _
                        & "Plaintifs.Address2 +' '+ Plaintifs.Address3 +' '+ Plaintifs.Address4 AS [Address], " _
                        & "PlaintifContacts.GivenNames AS [Contact Person], Plaintifs.Telephone AS [Telephone], " _
                        & "Plaintifs.EmailAddress AS [Email Address] FROM Plaintifs LEFT OUTER JOIN PlaintifContacts " _
                        & "ON Plaintifs.PlaintifId = PlaintifContacts.PlaintifID " _
                        & "WHERE Plaintifs.PlaintifId LIKE '%" & strFind & "%' " _
                        & "ORDER BY Plaintifs.PlaintifId"
                Else
                    strSql = "SELECT Plaintifs.PlaintifId AS [Client #], Plaintifs.GivenNames AS [Client Name], " _
                        & "CONVERT(NVARCHAR, Plaintifs.TakeOnDate, 105) AS [Date Engaged], Plaintifs.Address1 +' '+ " _
                        & "Plaintifs.Address2 +' '+ Plaintifs.Address3 +' '+ Plaintifs.Address4 AS [Address], " _
                        & "PlaintifContacts.GivenNames AS [Contact Person], Plaintifs.Telephone AS [Telephone], " _
                        & "Plaintifs.EmailAddress AS [Email Address] FROM Plaintifs LEFT OUTER JOIN PlaintifContacts " _
                        & "ON Plaintifs.PlaintifId = PlaintifContacts.PlaintifID " _
                        & "WHERE Plaintifs.PlaintifId LIKE '%" & strFind & "%' AND " _
                        & "AND Status = '" & cboPortfolioStatus.Text & "' " _
                        & "ORDER BY Plaintifs.PlaintifId"
                End If
            Case Is = "Client Name"

                If UCase(cboPortfolioStatus.Text) <> "ALL" Then
                    strSql = "SELECT Plaintifs.PlaintifId AS [Client #], Plaintifs.GivenNames AS [Client Name], " _
                        & "CONVERT(NVARCHAR, Plaintifs.TakeOnDate, 105) AS [Date Engaged], Plaintifs.Address1 +' '+ " _
                        & "Plaintifs.Address2 +' '+ Plaintifs.Address3 +' '+ Plaintifs.Address4 AS [Address], " _
                        & "PlaintifContacts.GivenNames AS [Contact Person], Plaintifs.Telephone AS [Telephone], " _
                        & "Plaintifs.EmailAddress AS [Email Address] FROM Plaintifs LEFT OUTER JOIN PlaintifContacts " _
                        & "ON Plaintifs.PlaintifId = PlaintifContacts.PlaintifID " _
                        & "WHERE Plaintifs.GivenNames LIKE '%" & strFind & "%' " _
                        & "ORDER BY Plaintifs.GivenNames"
                Else
                    strSql = "SELECT Plaintifs.PlaintifId AS [Client #], Plaintifs.GivenNames AS [Client Name], " _
                        & "CONVERT(NVARCHAR, Plaintifs.TakeOnDate, 105) AS [Date Engaged], Plaintifs.Address1 +' '+ " _
                        & "Plaintifs.Address2 +' '+ Plaintifs.Address3 +' '+ Plaintifs.Address4 AS [Address], " _
                        & "PlaintifContacts.GivenNames AS [Contact Person], Plaintifs.Telephone AS [Telephone], " _
                        & "Plaintifs.EmailAddress AS [Email Address] FROM Plaintifs LEFT OUTER JOIN PlaintifContacts " _
                        & "ON Plaintifs.PlaintifId = PlaintifContacts.PlaintifID " _
                        & "WHERE Plaintifs.GivenNames LIKE '%" & strFind & "%' AND " _
                        & "AND Status = '" & cboPortfolioStatus.Text & "' " _
                        & "ORDER BY Plaintifs.GivenNames"
                End If

        End Select

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridPortfolio.DataSource = dTable

        Me.dGridPortfolio.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGridPortfolio.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGridPortfolio.Columns.Count - 1
            dGridPortfolio.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On client search"
        ShowErrorMessage()
        Exit Sub
    End Sub

    Private Sub btnEditPortfolio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditPortfolio.Click
        GetSelectedPortfolio()
        boolEditStatus = True
        Dim f As New frmPlaintifDetails
        f.ShowDialog()
        If Not String.IsNullOrEmpty(txtPortfolioSearchString.Text) Then SearchForPortfolioItem(Nothing)
    End Sub

    Private Sub btnRefreshPortfolio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshPortfolio.Click
        LoadPortfolioData("Client Name")
    End Sub

    Private Sub GetSelectedPortfolio()
        If dGridPortfolio.Rows.Count > 0 Then
            strSelectedAccount = dGridPortfolio.CurrentRow.Cells(0).Value.ToString
        End If
    End Sub

    Private Sub dGridPortfolio_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridPortfolio.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        GetSelectedPortfolio()
        boolEditStatus = True
        Dim f As New frmPlaintifDetails
        f.ShowDialog()
        If Not String.IsNullOrEmpty(txtPortfolioSearchString.Text) Then SearchForPortfolioItem(Nothing)
    End Sub

    '    Private Sub LoadAnalysisActions()
    '        On Error GoTo RaiseErr

    '        Dim strSql As String = "SELECT ProcessAction, ActionKey FROM LegalDebtCollectionStages ORDER BY TransactionId"
    '        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

    '        Dim strRootKey As String = Nothing
    '        Dim arrItems As New ArrayList
    '        Dim arrOutput As New ArrayList

    '        While objReader.Read
    '            Dim strBuffer() As String = Split(objReader(0).ToString, "\")
    '            If strBuffer.Length = 2 Then
    '                Dim strKey() As String = Split(objReader(1).ToString, ".")
    '                dGridPortfolioAnalysis.Rows.Add(strKey(0), strBuffer(0))
    '                dGridPortfolioAnalysis.Rows.Add(objReader(1).ToString, "   " & strBuffer(1))

    '                Dim aNode As Ai.Control.TreeNode = New Ai.Control.TreeNode
    '                aNode.Text = strBuffer(0)
    '                aNode.SubItems.Add(strBuffer(0))
    '            Else
    '                Dim intSpace As Integer = strBuffer.Length - 1
    '                'dGrid.Rows.Add(objReader(1).ToString, StrDup((intSpace * 3), "."c) & strBuffer(strBuffer.Length - 1))
    '                dGridPortfolioAnalysis.Rows.Add(objReader(1).ToString, StrDup((intSpace * 3), " "c) & strBuffer(strBuffer.Length - 1))
    '            End If
    '        End While
    '        objReader.Close()

    '        'Take the count of all based on the keys

    '        For j As Integer = 0 To dGridPortfolioAnalysis.Rows.Count - 1
    '            strSql = "SELECT Count(ProcessAction) FROM LegalActions WHERE " _
    '                & "ProcessAction = '" & dGridPortfolioAnalysis.Rows(j).Cells(0).Value.ToString & "'"
    '            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
    '            objReader = objCommand.ExecuteReader

    '            If objReader.HasRows Then
    '                objReader.Read()
    '                If IsNumeric(objReader(0).ToString) Then
    '                    dGridPortfolioAnalysis.Rows(j).Cells(2).Value = objReader(0).ToString
    '                End If
    '            End If
    '            objReader.Close()
    '        Next

    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stagging setup"
    '        ShowErrorMessage()
    '    End Sub

    Private Sub btnRefreshAnalysis_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshAnalysis.Click
        TreeListView1.Columns.Clear()
        data = Nothing
        InitializeData("0")
    End Sub

    Private Function ActionCount(ByVal ActionKey As Integer, ByVal ClientId As String) As Double()
        On Error GoTo RaiseErr
        Dim dblReturn(0 To 3) As Double
        For p As Integer = 0 To dblReturn.Length - 1
            dblReturn(p) = 0
        Next
        Dim strSql As String = Nothing
        Dim strSqlCurrent As String = Nothing

        If UCase(ClientId) = "0" Then
            'strSql = "SELECT Count(DefendantId), SUM(ActionCost) FROM LegalActions " _
            '    & "WHERE ActionKey = " & ActionKey & " GROUP BY ActionCost"

            strSql = "SELECT Count(Defendants.DefendantId), SUM(Defendants.PrincipalDebt) FROM Defendants " _
                & "WHERE Defendants.DefendantId IN (SELECT DefendantId FROM LegalActions " _
                & "WHERE ActionKey = " & ActionKey & " )"

            'strSqlCurrent = "SELECT Count(a.DefendantId), SUM(a.ActionCost) FROM LegalActions a " _
            '    & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b " _
            '    & "WHERE a.DefendantId = b.DefendantId) AND a.ActionKey = " & ActionKey & " GROUP BY a.ActionCost"

            strSqlCurrent = "SELECT Count(LegalActions.DefendantId), SUM(Defendants.PrincipalDebt) FROM Defendants " _
                & "LEFT OUTER JOIN LegalActions ON Defendants.DefendantId = LegalActions.DefendantId " _
                & "WHERE LegalActions.ActionDate = (SELECT MAX(ActionDate) FROM LegalActions " _
                & "WHERE Defendants.DefendantId = LegalActions.DefendantId) AND " _
                & "LegalActions.ActionKey = " & ActionKey & ""

        Else
            'strSql = "SELECT Count(DefendantId), SUM(ActionCost) FROM LegalActions " _
            '    & "WHERE ActionKey = " & ActionKey & " AND PlaintifId = '" & ClientId & "' GROUP BY ActionCost"

            strSql = "SELECT Count(Defendants.DefendantId), SUM(Defendants.PrincipalDebt) FROM Defendants " _
                & "WHERE Defendants.DefendantId IN (SELECT DefendantId FROM LegalActions " _
                & "WHERE ActionKey = " & ActionKey & " AND PlaintifId = '" & ClientId & "')"

            'strSqlCurrent = "SELECT Count(a.DefendantId), SUM(a.ActionCost) FROM LegalActions a " _
            '    & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b " _
            '    & "WHERE a.DefendantId = b.DefendantId) AND a.ActionKey = " & ActionKey & " AND " _
            '    & "a.PlaintifId = '" & ClientId & "' GROUP BY a.ActionCost"

            strSqlCurrent = "SELECT Count(LegalActions.DefendantId), SUM(Defendants.PrincipalDebt) FROM Defendants " _
                & "LEFT OUTER JOIN LegalActions ON Defendants.DefendantId = LegalActions.DefendantId " _
                & "WHERE LegalActions.ActionDate = (SELECT MAX(ActionDate) FROM LegalActions " _
                & "WHERE Defendants.DefendantId = LegalActions.DefendantId) AND " _
                & "LegalActions.ActionKey = " & ActionKey & " AND Defendants.PlaintifId = '" & ClientId & "'"

        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblReturn(0) = CDbl(objReader(0).ToString)
            End If
            If IsNumeric(objReader(1).ToString) Then
                dblReturn(1) = CDbl(objReader(1).ToString)
            End If
        End If
        objReader.Close()

        'Get the current stage cost and count
        objCommand = New Data.OleDb.OleDbCommand(strSqlCurrent, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblReturn(2) = CDbl(objReader(0).ToString)
            End If
            If IsNumeric(objReader(1).ToString) Then
                dblReturn(3) = CDbl(objReader(1).ToString)
            End If
        End If
        objReader.Close()

        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Return dblReturn
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Key Count Fetch"
        ShowErrorMessage()
    End Function

    Private Sub InitializeData(ByVal SelectedPortfolio As String)
        On Error GoTo RaiseErr

        data = New List(Of Node)()
        TreeListView1.Columns.Clear()
        TreeListView1.Items.Clear()
        arrRelativeNodesIds = New ArrayList

        'My code cracking
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [ActionName], [ProcedureId] " _
            & "FROM ProdedureAndActions WHERE ParentStatus = 'YES' AND [SubActionOf] = 0", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            strNodePath = Nothing
            Dim intStageValues() As Double = ActionCount(CInt(objReader(1).ToString), SelectedPortfolio)
            Dim parent1 As New Node(objReader(0).ToString(), CStr(Format(intStageValues(0), "#,##0")), _
                CStr(Format(intStageValues(1), "#,##0.00")), CStr(Format(intStageValues(2), "#,##0")), _
                CStr(Format(intStageValues(3), "#,##0.00")))
            arrRelativeNodesIds.Add(objReader(1).ToString)
            AddNodes(parent1, objReader(1).ToString, SelectedPortfolio)
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
        ShowErrorMessage()
    End Sub

    Private Sub AddNodes(ByRef sNode As Node, intActionId As Integer, ByVal strPortfolio As String)
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(strNodePath) Then
            strNodePath = strNodePath & "\" & sNode.ActionName
        Else
            strNodePath = sNode.ActionName
        End If
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = " & intActionId & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim intStageValues() As Double = ActionCount(CInt(objReader(1).ToString), strPortfolio)
            Dim nNode As New Node(objReader(0).ToString(), CStr(Format(intStageValues(0), "#,##0")), _
                CStr(Format(intStageValues(1), "#,##0.00")), CStr(Format(intStageValues(2), "#,##0")), _
                CStr(Format(intStageValues(3), "#,##0.00")))
            sNode.Children.Add(nNode)
            arrRelativeNodesIds.Add(objReader(1).ToString)
            AddNodes(nNode, objReader(1).ToString, strPortfolio)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On portfolio anaylysis details populate"
        ShowErrorMessage()
    End Sub

    Private Sub FillTree()

        Me.TreeListView1.CanExpandGetter = Function(x As Object) DirectCast(x, Node).Children.Count > 0
        Me.TreeListView1.ChildrenGetter = Function(x As Object) DirectCast(x, Node).Children

        ' create the tree columns and set the delegates to print the desired object proerty
        Dim ActionNameCol As New BrightIdeasSoftware.OLVColumn("Action Taken", "ActionName")
        ActionNameCol.AspectGetter = Function(x As Object) DirectCast(x, Node).ActionName

        Dim Count1Col As New BrightIdeasSoftware.OLVColumn("Cummulative", "Count1")
        Count1Col.AspectGetter = Function(x As Object) DirectCast(x, Node).Count1
        Count1Col.TextAlign = HorizontalAlignment.Right

        Dim Value1Col As New BrightIdeasSoftware.OLVColumn("Amount", "Value1")
        Value1Col.AspectGetter = Function(x As Object) DirectCast(x, Node).Value1
        Value1Col.TextAlign = HorizontalAlignment.Right

        Dim Count2Col As New BrightIdeasSoftware.OLVColumn("Current", "Count2")
        Count2Col.AspectGetter = Function(x As Object) DirectCast(x, Node).Count2
        Count2Col.TextAlign = HorizontalAlignment.Right

        Dim Value2Col As New BrightIdeasSoftware.OLVColumn("Amount", "Value2")
        Value2Col.AspectGetter = Function(x As Object) DirectCast(x, Node).Value2
        Value2Col.TextAlign = HorizontalAlignment.Right

        ' add the columns to the tree
        Me.TreeListView1.Columns.Add(ActionNameCol)
        Me.TreeListView1.Columns.Add(Count1Col)
        Me.TreeListView1.Columns.Add(Value1Col)
        Me.TreeListView1.Columns.Add(Count2Col)
        Me.TreeListView1.Columns.Add(Value2Col)
        ' set the tree roots
        Me.TreeListView1.Roots = Data

        TreeListView1.Columns(0).Width = 250
        TreeListView1.Columns(1).Width = 100
        TreeListView1.Columns(2).Width = 100
        TreeListView1.Columns(3).Width = 100
        TreeListView1.Columns(4).Width = 100
        'TreeListView1.Columns(TreeListView1.Columns.Count - 1).Width = -2

        TreeListView1.ExpandAll()

    End Sub

    Private Sub AddStageTreeNodes()
        On Error GoTo RaiseErr
        tvStages.Nodes.Clear()
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = 0 ORDER BY [ProcedureId]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim node As New TreeNode
            node.Text = objReader(0).ToString
            node.Tag = objReader(1).ToString
            AddStageNodes(node)
            tvStages.Nodes.Add(node)
        End While
        objReader.Close()
        tvStages.ExpandAll()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
        ShowErrorMessage()
    End Sub

    Private Sub AddStageNodes(ByRef node As TreeNode)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = '" & node.Tag & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim nNode As New TreeNode
            nNode.Text = objReader(0).ToString
            nNode.Tag = objReader(1).ToString
            AddStageNodes(nNode)
            node.Nodes.Add(nNode)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
        ShowErrorMessage()
    End Sub

    'Private Sub btnMaintainActions_Click(sender As System.Object, e As System.EventArgs) Handles btnMaintainActions.Click
    '    If dGrid.Rows.Count > 0 Then
    '        strSelectedAccount = dGrid.CurrentRow.Cells(1).Value.ToString
    '        strSelectedAccountName = dGrid.CurrentRow.Cells(2).Value.ToString
    '        boolCalledFromListing = True
    '        Dim frm As New frmLegalActionsMaintenance
    '        frm.ShowDialog()
    '    End If
    'End Sub

    Private Sub chkSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles chkSelectAll.Click
        If chkSelectAll.Checked = True Then
            For i As Integer = 0 To dGrid.Rows.Count - 1
                dGrid.Rows(i).Cells(0).Value = True
            Next
            lblTotalSelected.Text = CStr(dGrid.RowCount)
        Else
            For i As Integer = 0 To dGrid.Rows.Count - 1
                If dGrid.Rows(i).Cells(0).Value = True Then
                    dGrid.Rows(i).Cells(0).Value = False
                End If
            Next
            lblTotalSelected.Text = "0"
        End If
    End Sub

    Private Function TotalSelected() As Integer
        Dim intReturn As Integer = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If dGrid.Rows(i).Cells(0).Value = True Then
                intReturn = intReturn + 1
            End If
        Next
        Return intReturn
    End Function

    Private Sub LoadDebtorsDetails()
        On Error GoTo RaiseErr

        boolAbort = False
        'UpdateLegalStatusTables()
        If boolAbort = True Then Exit Sub

        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing

        'First drop the temporary table if it exists
        strSql = "IF OBJECT_ID(N'CaseSummaries', N'U')  IS NOT NULL DROP TABLE CaseSummaries"
        Dim objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        strSql = "SELECT * INTO CaseSummaries FROM LegalActions a WHERE ActionDate = " _
            & "(SELECT MAX(ActionDate) FROM LegalActions b WHERE a.DefendantId = b.DefendantId)"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'If UCase(cboOptions.Text) = "--ALL--" Then
        '    If UCase(cboProcedures.Text) = "--ALL--" Then
        '        strSql = "SELECT Defendants.DefendantId as [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId as [File #], " _
        '            & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ Defendants.PrimaryAddress4 AS [Address], " _
        '            & "UPPER(REPLACE(CONVERT(CHAR(11), CaseSummaries.ActionDate, 106), ' ', '-')) AS [Date], " _
        '            & "CaseSummaries.ProcedureName AS [Stage], CaseSummaries.ActionTaken as [Action], SUM(DefendantTransactions.Debit) AS [Debits], SUM(DefendantTransactions.Credit) AS [Credits], " _
        '            & "Defendants.PrincipalDebt AS [Principal], Defendants.CaseNumber AS [Case #], Defendants.Cellphone, Defendants.Telephone FROM Defendants " _
        '            & "LEFT OUTER JOIN CaseSummaries ON Defendants.DefendantId = CaseSummaries.DefendantId " _
        '            & "LEFT OUTER JOIN DefendantTransactions ON DefendantTransactions.DefendantId = Defendants.DefendantId " _
        '            & "WHERE Defendants.PlaintifId = '" & lblClientId.Text & "' " _
        '            & "GROUP BY Defendants.DefendantId, Defendants.GivenNames, CaseSummaries.ActionDate, Defendants.FileId, " _
        '            & "Defendants.PrimaryAddress1, Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
        '            & "CaseSummaries.ProcedureName, CaseSummaries.ActionTaken, Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Cellphone, Defendants.Telephone " _
        '            & "ORDER BY Defendants.DefendantId, CaseSummaries.ActionDate"
        '    Else
        '        strSql = "SELECT Defendants.DefendantId as [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId as [File #], " _
        '            & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ Defendants.PrimaryAddress4 AS [Address], " _
        '            & "UPPER(REPLACE(CONVERT(CHAR(11), CaseSummaries.ActionDate, 106), ' ', '-')) AS [Date], " _
        '            & "CaseSummaries.ProcedureName AS [Stage], CaseSummaries.ActionTaken as [Action], SUM(DefendantTransactions.Debit) AS [Debits], SUM(DefendantTransactions.Credit) AS [Credits], " _
        '            & "Defendants.PrincipalDebt  AS [Principal], Defendants.CaseNumber AS [Case #], Defendants.Cellphone, Defendants.Telephone FROM Defendants " _
        '            & "LEFT OUTER JOIN CaseSummaries ON Defendants.DefendantId = CaseSummaries.DefendantId " _
        '            & "LEFT OUTER JOIN DefendantTransactions ON DefendantTransactions.DefendantId = Defendants.DefendantId " _
        '            & "WHERE Defendants.PlaintifId = '" & lblClientId.Text & "' " _
        '            & "AND CaseSummaries.ProcedureName = '" & cboProcedures.Text & "' " _
        '            & "GROUP BY Defendants.DefendantId, Defendants.GivenNames, CaseSummaries.ActionDate, Defendants.FileId, " _
        '            & "Defendants.PrimaryAddress1, Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
        '            & "CaseSummaries.ProcedureName, CaseSummaries.ActionTaken, Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Cellphone, Defendants.Telephone " _
        '            & "ORDER BY Defendants.DefendantId, CaseSummaries.ActionDate"
        '    End If
        'Else
        '    If UCase(cboProcedures.Text) = "--ALL--" Then
        '        strSql = "SELECT Defendants.DefendantId as [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId as [File #], " _
        '            & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ Defendants.PrimaryAddress4 AS [Address], " _
        '            & "UPPER(REPLACE(CONVERT(CHAR(11), CaseSummaries.ActionDate, 106), ' ', '-')) AS [Date], " _
        '            & "CaseSummaries.ProcedureName AS [Stage], CaseSummaries.ActionTaken as [Action], SUM(DefendantTransactions.Debit) AS [Debits], SUM(DefendantTransactions.Credit) AS [Credits], " _
        '            & "Defendants.PrincipalDebt AS [Principal], Defendants.CaseNumber AS [Case #], Defendants.Cellphone, Defendants.Telephone FROM Defendants " _
        '            & "LEFT OUTER JOIN CaseSummaries ON Defendants.DefendantId = CaseSummaries.DefendantId " _
        '            & "LEFT OUTER JOIN DefendantTransactions ON DefendantTransactions.DefendantId = Defendants.DefendantId " _
        '            & "WHERE Defendants.PlaintifId = '" & lblClientId.Text & "' " _
        '            & "AND CaseSummaries.ActionTaken = '" & cboOptions.Text & "' " _
        '            & "AND Defendants.ClassId = '" & lblClassId.Text & "' " _
        '            & "GROUP BY Defendants.DefendantId, Defendants.GivenNames, CaseSummaries.ActionDate, Defendants.FileId, " _
        '            & "Defendants.PrimaryAddress1, Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
        '            & "CaseSummaries.ProcedureName, CaseSummaries.ActionTaken, Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Cellphone, Defendants.Telephone " _
        '            & "ORDER BY Defendants.DefendantId, CaseSummaries.ProcedureName, CaseSummaries.ActionTaken, CaseSummaries.ActionDate"
        '    Else
        '        strSql = "SELECT Defendants.DefendantId as [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId as [File #], " _
        '            & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ Defendants.PrimaryAddress4 AS [Address], " _
        '            & "UPPER(REPLACE(CONVERT(CHAR(11), CaseSummaries.ActionDate, 106), ' ', '-')) AS [Date], " _
        '            & "CaseSummaries.ProcedureName AS [Stage], CaseSummaries.ActionTaken as [Action], SUM(DefendantTransactions.Debit) AS [Debits], SUM(DefendantTransactions.Credit) AS [Credits], " _
        '            & "Defendants.PrincipalDebt AS [Principal], Defendants.CaseNumber AS [Case #], Defendants.Cellphone, Defendants.Telephone FROM Defendants " _
        '            & "LEFT OUTER JOIN CaseSummaries ON Defendants.DefendantId = CaseSummaries.DefendantId " _
        '            & "LEFT OUTER JOIN DefendantTransactions ON DefendantTransactions.DefendantId = Defendants.DefendantId " _
        '            & "WHERE Defendants.PlaintifId = '" & lblClientId.Text & "' " _
        '            & "AND CaseSummaries.ProcedureName = '" & cboProcedures.Text & "' " _
        '            & "AND CaseSummaries.ActionTaken = '" & cboOptions.Text & "' " _
        '            & "AND Defendants.ClassId = '" & lblClassId.Text & "' " _
        '            & "GROUP BY Defendants.DefendantId, Defendants.GivenNames, CaseSummaries.ActionDate, Defendants.FileId, " _
        '            & "Defendants.PrimaryAddress1, Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
        '            & "CaseSummaries.ProcedureName, CaseSummaries.ActionTaken, Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Cellphone, Defendants.Telephone " _
        '            & "ORDER BY Defendants.DefendantId, CaseSummaries.ActionDate"
        '    End If
        'End If

        'dGrid.Columns.Clear()

        'Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        'cmd.CommandType = CommandType.Text

        'Dim da As New OleDb.OleDbDataAdapter(cmd)
        'Dim dTable As New DataTable()
        'da.Fill(dTable)
        'dGrid.DataSource = dTable

        'Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        ''AlternateColors(dGrid)
        'For p As Integer = 0 To dGrid.Columns.Count - 1
        '    dGrid.Columns(p).ReadOnly = True
        '    dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        '    If p > 6 Then
        '        dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '        dGrid.Columns(p).DefaultCellStyle.Format = "N2"
        '    End If
        'Next

        'lblTotals.Text = dGrid.Rows.Count

        ''Get the sum total
        'Dim dblTotal As Double = 0
        'For i As Integer = 0 To dGrid.Rows.Count - 1
        '    If Not Object.Equals(dGrid.Rows(i).Cells(9).Value, Nothing) Then
        '        If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(9).Value.ToString) Then
        '            If IsNumeric(dGrid.Rows(i).Cells(9).Value.ToString) Then
        '                dblTotal = dblTotal + CDbl(dGrid.Rows(i).Cells(9).Value.ToString)
        '            End If
        '        End If
        '    End If
        'Next
        'lblAmountTotal.Text = Format(dblTotal, "#,##0.00")

        ''Add check box
        'With dGrid
        '    Dim checkCol As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        '    checkCol.HeaderText = ""
        '    checkCol.Width = 25
        '    .Columns.Add(checkCol)
        '    .Columns(.Columns.Count - 1).ReadOnly = False
        'End With

        ''dGrid.Columns(3).Frozen = True

        'dGrid.AllowUserToResizeColumns = True

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defaulters analysis"
        ShowErrorMessage()
    End Sub

    Private Sub expandablePanel1_ExpandedChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles expandablePanel1.ExpandedChanged
        'AdjustSplitter()
        AdjustPanes()
    End Sub

    Private Sub AdjustPanes()
        If expandablePanel1.Expanded Then
            If (splitMain.Width - splitMain.Panel1.Width) < 150 Then intPriorSplitterDistance = splitMain.Width - 200
            splitMain.SplitterDistance = intPriorSplitterDistance
            splitMain.IsSplitterFixed = False
        Else
            intPriorSplitterDistance = splitMain.SplitterDistance
            splitMain.SplitterDistance = splitMain.Width - 32
            splitMain.IsSplitterFixed = True
        End If
    End Sub

    Private Sub GetAllSelectedRecords()
        arrSelectedItems = New ArrayList
        Cursor = Cursors.WaitCursor
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If dGrid.Rows(i).Cells(0).Value = True Then
                Dim strAccountId As String = Nothing
                Dim strFileId As String = Nothing
                If Not Object.Equals(dGrid.Rows(i).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(1).Value.ToString) Then
                        strAccountId = dGrid.Rows(i).Cells(1).Value.ToString
                    End If
                End If
                If Not Object.Equals(dGrid.Rows(i).Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(3).Value.ToString) Then
                        strFileId = dGrid.Rows(i).Cells(3).Value.ToString
                    End If
                End If
                arrSelectedItems.Add(strAccountId & "|" & strFileId)
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub btnUpgrades_Click(sender As System.Object, e As System.EventArgs) Handles btnUpgrades.Click
        Dim frm As New frmStageConversion
        frm.ShowDialog()
    End Sub

    Private Sub cboPortfolioAnalysis_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPortfolioAnalysis.SelectedIndexChanged
        If Not cboPortfolioAnalysis.SelectedItem Is Nothing Then
            Cursor = Cursors.WaitCursor
            lblClientIdAnalysis.Text = cboPortfolioAnalysis.SelectedItem.Col2
            InitializeData(lblClientIdAnalysis.Text)
            Cursor = Cursors.Default
        Else
            lblClientIdAnalysis.Text = "0"
        End If
    End Sub

    Private Sub LoadBasedOnAction(ByVal actKey As Integer, sClientId As String)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        dGrid.Columns.Clear()

        intSelectedActionKey = actKey

        If sClientId = "0" Then
            strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b WHERE a.DefendantId = b.DefendantId) " _
                & "AND a.ActionKey = " & actKey & " " _
                & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
                & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone, a.ActionDate"
        Else
            strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                & "Defendants.Telephone AS [Phone], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b WHERE a.DefendantId = b.DefendantId) " _
                & "AND a.PlaintifId = '" & lblClientId.Text & "' AND a.ActionKey = " & actKey & " " _
                & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4, " _
                & "Defendants.PrincipalDebt, Defendants.CaseNumber, Defendants.Telephone, Defendants.Cellphone, a.ActionDate"
        End If

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        Dim crm As New DataGridViewCheckBoxColumn
        With crm
            .Width = 25
            .HeaderText = ""
        End With
        dGrid.Columns.Insert(0, crm)
        dGrid.Columns(0).ReadOnly = False
        dGrid.Columns(2).Frozen = True

        For p As Integer = 1 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dGrid.Columns(p).ReadOnly = True
            If p > 4 And p <= 8 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGrid.Columns(p).DefaultCellStyle.Format = "N2"
            End If
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debtor details load by last action"
        ShowErrorMessage()
    End Sub

    Private Sub tvStages_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvStages.AfterSelect
        If boolformLoading = True Then Exit Sub
        lblActiveAction.Text = Replace(tvStages.SelectedNode.FullPath, "\", ">", 1)
        LoadBasedOnAction(CInt(tvStages.SelectedNode.Tag), lblClientId.Text)
        lblCount.Text = dGrid.RowCount
    End Sub

    Private Sub btnSelectHighlighted_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectHighlighted.Click
        If dGrid.SelectedRows.Count > 0 Then
            For p As Integer = 0 To dGrid.SelectedRows.Count - 1
                dGrid.SelectedRows.Item(p).Cells(0).Value = True
            Next
        End If
    End Sub

    Private Sub btnPrintPortfolioAnalysis_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintPortfolioAnalysis.Click
        'Dim m_print As New PrintControl.ControlPrint
        'm_print.SetControl(pnlTree)
        'Dim ppd As New EnhancedPrintPreviewDialog
        'ppd.Document = DirectCast(m_print, PrintDocument)
        'ppd.ShowDialog()
        ''Dim objFile As New System.IO.StreamWriter(Application.StartupPath & "\TestAnalysis.txt", False)
        ''For p As Integer = 0 To TreeListView1.Items.Count - 1
        ''    Dim strLine As String = TreeListView1.Items(p).Text.ToString & "|"
        ''    For y As Integer = 1 To TreeListView1.Items(p).SubItems.Count - 1
        ''        Dim strValue As String = TreeListView1.Items(p).SubItems(y).Text.ToString
        ''        strLine = strLine & strValue & "|"
        ''    Next
        ''    objFile.WriteLine(strLine)
        ''Next
        ''objFile.Close()
        ''MsgBox("Done")
        'PrintStageTreeNodes()
        'Dim rp As New SmartRichReportWriter.RichReportWriter
        'With rp
        '    .strMainHeader1 = "Header 1"
        '    .strMainHeader2 = "Header 2"
        '    .strMainHeader3 = "Header 3"
        '    .intTitleXposition = 250
        '    .TitleColor = Color.Black
        '    .Data = strRichData
        '    .boolDrawBorder = True
        '    .GridColor = Color.WhiteSmoke
        '    .FooterColor = Color.Black
        '    .strFooterCaption = "Embassy and Associates"
        '    .intFooterXposition = 100
        '    .intPageNumXposition = 700
        'End With
        'Dim ppd As New PrintPreviewDialog
        'ppd.Document = rp
        'ppd.ShowDialog()

        PrintNodes()

    End Sub

    Private Sub btnPortfolioCosts_Click(sender As System.Object, e As System.EventArgs) Handles btnPortfolioCosts.Click
        Dim frm As New frmLegalPortfolioCostsSetup
        frm.ShowDialog()
    End Sub

    Private Sub btnPaymentDescriptions_Click(sender As System.Object, e As System.EventArgs) Handles btnPaymentDescriptions.Click
        Dim frm As New frmDebtSettlementReasons
        frm.showdialog()
    End Sub

    Private Sub btnOrganisation_Click(sender As System.Object, e As System.EventArgs) Handles btnOrganisation.Click
        Cursor = Cursors.WaitCursor
        Shell(Application.StartupPath & "\gwtOrganization.exe", AppWinStyle.NormalFocus, False)
        With gwt_comm
            .AssignCompanyDetails()
            .AssignDefaults()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAllocations_Click(sender As System.Object, e As System.EventArgs) Handles btnAllocations.Click
        Dim frm As New frmLegalDebtorsPotfolioAssignment
        frm.ShowDialog()
    End Sub

    Private Sub btnPaymentInitiators_Click(sender As System.Object, e As System.EventArgs) Handles btnPaymentInitiators.Click
        Dim frm As New frmLegalPaymentInitiators
        frm.ShowDialog()
    End Sub

    Private Sub btnReceipt_Click(sender As System.Object, e As System.EventArgs) Handles btnReceipt.Click
        GetSelectedReceipt()
        Dim frm As New frmLegalTransactionPayments
        frm.ShowDialog()
    End Sub

    Private Sub GetSelectedReceipt()
        If dGridReceipts.Rows.Count > 0 Then
            strSelectedAccountName = Nothing
            strSelectedAccount = dGridReceipts.CurrentRow.Cells(0).Value.ToString
            If Not Object.Equals(dGridReceipts.CurrentRow.Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridReceipts.CurrentRow.Cells(1).Value.ToString) Then
                    strSelectedAccountName = dGridReceipts.CurrentRow.Cells(1).Value.ToString
                End If
            End If
            If IsNumeric(dGridReceipts.CurrentRow.Cells(5).Value) Then
                dblClientBalance = CDbl(dGridReceipts.CurrentRow.Cells(6).Value.ToString)
            End If
        End If
    End Sub

    Private Sub dGridReceipts_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridReceipts.CellContentDoubleClick
        GetSelectedReceipt()
        Dim frm As New frmLegalTransactionPayments
        frm.ShowDialog()
    End Sub

    Private Sub dGridReceipts_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dGridReceipts.CellMouseDown
        If e.Button = MouseButtons.Right Then
            ' Add this
            dGridReceipts.CurrentCell = dGridReceipts.Rows(e.RowIndex).Cells(e.ColumnIndex)
            ' Can leave these here - doesn't hurt
            dGridReceipts.Rows(e.RowIndex).Selected = True
            dGridReceipts.Focus()
        End If

    End Sub

    Private Sub LoadReceiptClients()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT GivenNames +'|'+ PlaintifID AS " _
            & "[Details] FROM Plaintifs ORDER BY GivenNames", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrData As New ArrayList

        If UCase(strUserLevel) = UCase("Administrator") Then
            arrData.Add("--ALL--|0")
        End If

        While objReader.Read
            If UCase(strUserLevel) <> UCase("Administrator") Then
                If Not IsDBNull(objReader(0).ToString) Then
                    Dim strSplitName() As String = Split(objReader(0).ToString, "|")
                    For z As Integer = 0 To arrPublicPotfolioClientName.Count - 1
                        If UCase(strSplitName(0)) = UCase(arrPublicPotfolioClientName.Item(z)) Then
                            arrData.Add(objReader(0).ToString)
                        End If
                    Next
                End If
            Else
                If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboReceiptClients.Width - 80

        'Add the items to the drop down box
        With cboReceiptClients
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth1 & ";80"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = arrData.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboReceiptClients.Items.Clear()
        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboReceiptClients
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Client Names Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboReceiptClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReceiptClients.SelectedIndexChanged
        strActivePlaintifNameOnPayments = Nothing
        If Not cboReceiptClients.SelectedItem Is Nothing Then
            lblReceiptClientId.Text = cboReceiptClients.SelectedItem.Col2
            strPublicActivePaymentsTrustAccountNumber = GetTrustAccount(lblReceiptClientId.Text)
            strSelectedPlaintifId = lblReceiptClientId.Text
            LoadReceiptDefendantsListing(lblReceiptClientId.Text)
            strActivePlaintifNameOnPayments = cboReceiptClients.SelectedItem.Col1
        Else
            lblReceiptClientId.Text = "0"
        End If
    End Sub

    Private Function GetTrustAccount(AccountNumber As String) As String
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DefaultTrustAccount FROM Plaintifs " _
            & "WHERE PlaintifId = '" & AccountNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                strReturn = objReader(0).ToString
            End If
        End If
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Trust Account Details Fetch"
        ShowErrorMessage()
    End Function

    Private Sub LoadReceiptDefendantsListing(ByVal PlaintifId As String)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Cursor = Cursors.WaitCursor
        If lblReceiptClientId.Text = "0" Then
            strSql = "SELECT Defendants.DefendantId as [Defendant #], Defendants.GivenNames as [Given Names], " _
                & "Defendants.FileId AS [File #], Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ Defendants.PrimaryAddress4 AS [Address], " _
                & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance] " _
                & "FROM Defendants LEFT OUTER JOIN DefendantTransactions " _
                & "ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                & "GROUP BY Defendants.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4"
        Else
            strSql = "SELECT Defendants.DefendantId as [Defendant #], Defendants.GivenNames as [Given Names], " _
                & "Defendants.FileId AS [File #], Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ Defendants.PrimaryAddress4 AS [Address], " _
                & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance] " _
                & "FROM Defendants LEFT OUTER JOIN DefendantTransactions " _
                & "ON Defendants.DefendantId = DefendantTransactions.DefendantId WHERE Defendants.PlaintifId = '" & lblReceiptClientId.Text & "' " _
                & "GROUP BY Defendants.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, Defendants.FileId, " _
                & "Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, Defendants.PrimaryAddress4"
        End If

        dGridReceipts.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridReceipts.DataSource = dTable

        Me.dGridReceipts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGridReceipts.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGridReceipts.Columns.Count - 1
            dGridReceipts.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            If p > 3 Then
                dGridReceipts.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGridReceipts.Columns(p).DefaultCellStyle.Format = "N2"
            End If
        Next
        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Names Load"
        ShowErrorMessage()
    End Sub

    Private Sub txtReceiptSearchString_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceiptSearchString.TextChanged
        'Handles the search function. as the use types the string, the grid positions itself to the nearest match
        Dim i As Integer = 0
        With dGridReceipts
            For i = 0 To dGridReceipts.Rows.Count - 1
                Select Case cboReceiptSearchBy.Text
                    Case Is = "Number"
                        If UCase(Mid(.Rows(i).Cells(0).Value, 1, Len(txtReceiptSearchString.Text))) = UCase(txtReceiptSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(0)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                    Case Is = "Name"
                        If UCase(Mid(.Rows(i).Cells(1).Value, 1, Len(txtReceiptSearchString.Text))) = UCase(txtReceiptSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(1)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                    Case Is = "File Number"
                        If UCase(Mid(.Rows(i).Cells(2).Value, 1, Len(txtReceiptSearchString.Text))) = UCase(txtReceiptSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(2)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                    Case Else
                        'Use the last name
                        If UCase(Mid(.Rows(i).Cells(0).Value, 1, Len(txtReceiptSearchString.Text))) = UCase(txtReceiptSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(0)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                End Select
            Next
        End With
    End Sub

    Private Sub cboReceiptSearchBy_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboReceiptSearchBy.SelectedIndexChanged
        If boolformLoading = True Then Exit Sub
        Dim strValue As String = cboReceiptSearchBy.Text

        If UCase(strValue) = UCase("Number") Then intColumnIndex = 0
        If UCase(strValue) = UCase("Name") Then intColumnIndex = 1
        If UCase(strValue) = UCase("File Number") Then intColumnIndex = 2

        Cursor = Cursors.WaitCursor
        dGridReceipts.Sort(dGridReceipts.Columns(intColumnIndex), System.ComponentModel.ListSortDirection.Ascending)
        Cursor = Cursors.Default
    End Sub

    Private Sub btnPaymentPlans_Click(sender As System.Object, e As System.EventArgs) Handles btnPaymentPlans.Click
        strSpecialKeysId = "PP"
        Dim frm As New frmSpecialKeys
        frm.ShowDialog()
    End Sub

    Private Sub btnUnserves_Click(sender As System.Object, e As System.EventArgs) Handles btnUnserves.Click
        strSpecialKeysId = "US"
        Dim frm As New frmSpecialKeys
        frm.ShowDialog()
    End Sub

    Private Sub btnRunUnserved_Click(sender As System.Object, e As System.EventArgs) Handles btnRunUnserved.Click
        LoadUnservedDebtors(lblUnservedClients.Text)
    End Sub

    Private Sub LoadUnservedDebtors(ByVal ClientId As String)
        If boolformLoading = True Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing

        'Get the unserved keys
        strSql = "SELECT DISTINCT(ActionKey) FROM SystemUnservedKeys"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim strCriteria As String = Nothing
        If objReader.HasRows Then
            While objReader.Read
                strCriteria = strCriteria & "ActionKey = " & objReader(0).ToString & " OR "
            End While
            objReader.Close()
            strCriteria = Mid(strCriteria, 1, strCriteria.Length - 4)
        Else
            Cursor = Cursors.Default
            MessageBox.Show("You have not yet defined the unserved action keys", "Special Keys Parameter Read Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        dGridUnserved.Columns.Clear()

        'Get the details by linking with current actions
        If ClientId = "0" Then
            strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                & "ProdedureAndActions.ActionName AS [Action], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                & "LEFT OUTER JOIN ProdedureAndActions ON a.ActionKey = ProdedureAndActions.ProcedureId " _
                & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b WHERE a.DefendantId = b.DefendantId) " _
                & "AND (" & strCriteria & ") " _
                & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, " _
                & "Defendants.FileId, Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, " _
                & "Defendants.PrimaryAddress4, Defendants.PrincipalDebt, Defendants.CaseNumber, " _
                & "ProdedureAndActions.ActionName, Defendants.Cellphone, a.ActionDate"
        Else
            strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                & "ProdedureAndActions.ActionName AS [Action], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                & "LEFT OUTER JOIN ProdedureAndActions ON a.ActionKey = ProdedureAndActions.ProcedureId " _
                & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b WHERE a.DefendantId = b.DefendantId) " _
                & "AND a.PlaintifId = '" & ClientId & "' AND (" & strCriteria & ") " _
                & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, " _
                & "Defendants.FileId, Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, " _
                & "Defendants.PrimaryAddress4, Defendants.PrincipalDebt, Defendants.CaseNumber, " _
                & "ProdedureAndActions.ActionName, Defendants.Cellphone, a.ActionDate"
        End If

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridUnserved.DataSource = dTable

        Me.dGridUnserved.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGridUnserved.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        dGridUnserved.Columns(2).Frozen = True

        Dim dblPrincipal As Double = 0
        Dim dblBalance As Double = 0

        For p As Integer = 1 To dGridUnserved.Columns.Count - 1
            dGridUnserved.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dGridUnserved.Columns(p).ReadOnly = True
            If p > 3 And p <= 7 Then
                dGridUnserved.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGridUnserved.Columns(p).DefaultCellStyle.Format = "N2"
            End If
        Next

        For p As Integer = 0 To dGridUnserved.RowCount - 1
            If Not Object.Equals(dGridUnserved.Rows(p).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridUnserved.Rows(p).Cells(4).Value.ToString) Then
                    If IsNumeric(dGridUnserved.Rows(p).Cells(4).Value.ToString) Then
                        dblPrincipal = dblPrincipal + CDbl(dGridUnserved.Rows(p).Cells(4).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGridUnserved.Rows(p).Cells(7).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridUnserved.Rows(p).Cells(7).Value.ToString) Then
                    If IsNumeric(dGridUnserved.Rows(p).Cells(7).Value.ToString) Then
                        dblBalance = dblBalance + CDbl(dGridUnserved.Rows(p).Cells(7).Value.ToString)
                    End If
                End If
            End If
        Next

        lblNumberUnserved.Text = dGridUnserved.RowCount
        lblUnservedBalance.Text = Format(dblBalance, "#,##0.00")
        lblUnservedPrincipal.Text = Format(dblPrincipal, "#,##0.00")

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On unserved debtors analysis"
        ShowErrorMessage()
    End Sub

    Private Sub LoadPaymentPlanDebtors(ByVal ClientId As String)
        If boolformLoading = True Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing

        'Get the unserved keys
        strSql = "SELECT DISTINCT(ActionKey) FROM SystemPaymentPlanKeys"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim strCriteria As String = Nothing
        If objReader.HasRows Then
            While objReader.Read
                strCriteria = strCriteria & "ActionKey = " & objReader(0).ToString & " OR "
            End While
            objReader.Close()
            strCriteria = Mid(strCriteria, 1, strCriteria.Length - 4)
        Else
            Cursor = Cursors.Default
            MessageBox.Show("You have not yet defined the payment plan action keys", "Special Keys Parameter Read Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        dGridpp.Columns.Clear()

        'Get the details by linking with current actions
        If ClientId = "0" Then
            strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                & "ProdedureAndActions.ActionName AS [Action], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                & "LEFT OUTER JOIN ProdedureAndActions ON a.ActionKey = ProdedureAndActions.ProcedureId " _
                & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b WHERE a.DefendantId = b.DefendantId) " _
                & "AND (" & strCriteria & ") " _
                & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, " _
                & "Defendants.FileId, Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, " _
                & "Defendants.PrimaryAddress4, Defendants.PrincipalDebt, Defendants.CaseNumber, " _
                & "ProdedureAndActions.ActionName, Defendants.Cellphone, a.ActionDate"
        Else
            strSql = "SELECT a.DefendantId AS [Defendant #], Defendants.GivenNames AS [Given Names], Defendants.FileId AS [File #], " _
                & "Defendants.PrimaryAddress1 +' '+ Defendants.PrimaryAddress2 +' '+ Defendants.PrimaryAddress3 +' '+ " _
                & "Defendants.PrimaryAddress4 AS [Address], CAST(Defendants.PrincipalDebt AS DECIMAL (10,2)) AS [Principal], " _
                & "SUM(DefendantTransactions.Debit) AS [Debit], SUM(DefendantTransactions.Credit) AS [Credit], " _
                & "(SUM(DefendantTransactions.Debit) - SUM(DefendantTransactions.Credit)) AS [Balance], " _
                & "CONVERT(NVARCHAR, a.ActionDate, 105) AS [Action Dt], Defendants.CaseNumber AS [Case #], " _
                & "ProdedureAndActions.ActionName AS [Action], Defendants.Cellphone AS [Mobile] FROM LegalActions a " _
                & "LEFT OUTER JOIN Defendants ON a.defendantId = Defendants.DefendantId " _
                & "LEFT OUTER JOIN DefendantTransactions ON Defendants.DefendantId = DefendantTransactions.DefendantId " _
                & "LEFT OUTER JOIN ProdedureAndActions ON a.ActionKey = ProdedureAndActions.ProcedureId " _
                & "WHERE ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b WHERE a.DefendantId = b.DefendantId) " _
                & "AND a.PlaintifId = '" & ClientId & "' AND (" & strCriteria & ") " _
                & "GROUP BY a.DefendantId, Defendants.GivenNames, Defendants.PrimaryAddress1, " _
                & "Defendants.FileId, Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, " _
                & "Defendants.PrimaryAddress4, Defendants.PrincipalDebt, Defendants.CaseNumber, " _
                & "ProdedureAndActions.ActionName, Defendants.Cellphone, a.ActionDate"
        End If

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridpp.DataSource = dTable

        Me.dGridpp.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGridpp.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        dGridpp.Columns(2).Frozen = True

        Dim dblPrincipal As Double = 0
        Dim dblBalance As Double = 0

        For p As Integer = 1 To dGridpp.Columns.Count - 1
            dGridpp.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dGridpp.Columns(p).ReadOnly = True
            If p > 3 And p <= 7 Then
                dGridpp.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGridpp.Columns(p).DefaultCellStyle.Format = "N2"
            End If
        Next

        For p As Integer = 0 To dGridpp.RowCount - 1
            If Not Object.Equals(dGridpp.Rows(p).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridpp.Rows(p).Cells(4).Value.ToString) Then
                    If IsNumeric(dGridpp.Rows(p).Cells(4).Value.ToString) Then
                        dblPrincipal = dblPrincipal + CDbl(dGridpp.Rows(p).Cells(4).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGridpp.Rows(p).Cells(7).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridpp.Rows(p).Cells(7).Value.ToString) Then
                    If IsNumeric(dGridpp.Rows(p).Cells(7).Value.ToString) Then
                        dblBalance = dblBalance + CDbl(dGridpp.Rows(p).Cells(7).Value.ToString)
                    End If
                End If
            End If
        Next

        Dim gTextBox As New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn
        gTextBox.HeaderText = "Paid On"
        gTextBox.Name = "mText"
        gTextBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dGridpp.Columns.Add(gTextBox)

        Dim ddTextBox As New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn
        gTextBox.HeaderText = "Days"
        gTextBox.Name = "ddText"
        gTextBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        dGridpp.Columns.Add(ddTextBox)

        For p As Integer = 0 To dGridpp.RowCount - 1

            Dim DefendantId As String = Nothing

            If Not Object.Equals(dGridpp.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridpp.Rows(p).Cells(0).Value.ToString) Then
                    DefendantId = dGridpp.Rows(p).Cells(0).Value.ToString
                End If
            End If

            'First get the date when the debtor went to this stage
            strSql = "SELECT ActionDate FROM LegalActions a WHERE DefendantId = '" & DefendantId & "' AND " _
                & "ActionDate = (SELECT MAX(ActionDate) FROM LegalActions b WHERE a.DefendantId = b.DefendantId) " _
                & "AND a.PlaintifId = '" & ClientId & "' AND (" & strCriteria & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader

            Dim strBaseDate As String = Nothing

            If objReader.HasRows Then
                objReader.Read()
                If IsDate(objReader(0).ToString) Then
                    strBaseDate = Format(CDate(objReader(0).ToString), "dd-MMM-yyyy")
                End If
            End If
            objReader.Close()

            strSql = "SELECT TransactionDate FROM DefendantTransactions WHERE DefendantId = '" & DefendantId & "' ORDER BY TransactionDate DESC"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsDate(objReader(0).ToString) Then
                    strBaseDate = Format(CDate(objReader(0).ToString), "dd-MMM-yyyy")
                End If
            End If
            objReader.Close()

            Dim intDaysAfterLastPayment As Integer = 0

            If Not String.IsNullOrEmpty(strBaseDate) Then
                If IsDate(strBaseDate) Then
                    intDaysAfterLastPayment = DateDiff(DateInterval.Day, CDate(strBaseDate), Now)
                End If
            End If

            dGridpp.Rows(p).Cells(dGridpp.ColumnCount - 1).Value = intDaysAfterLastPayment
            dGridpp.Rows(p).Cells(dGridpp.ColumnCount - 2).Value = strBaseDate

        Next

        lblPPcnt.Text = dGridpp.RowCount
        lblPPBalance.Text = Format(dblBalance, "#,##0.00")
        lblPPprincipal.Text = Format(dblPrincipal, "#,##0.00")

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debtors on payment plan analysis"
        ShowErrorMessage()
    End Sub

    Private Sub cboClientspp_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboClientspp.SelectedIndexChanged
        If Not cboClientspp.SelectedItem Is Nothing Then
            lblClientspp.Text = cboClientspp.SelectedItem.Col2
            LoadPaymentPlanDebtors(lblClientspp.Text)
        Else
            lblClientspp.Text = "0"
        End If
    End Sub

    Private Sub btnRunpp_Click(sender As System.Object, e As System.EventArgs) Handles btnRunpp.Click
        LoadPaymentPlanDebtors(lblClientspp.Text)
    End Sub

    Private Sub btnImportBranchTransactions_Click(sender As System.Object, e As System.EventArgs) Handles btnImportBranchTransactions.Click
        Dim frm As New frmLegalBranchTransactionsUpload
        frm.ShowDialog()
    End Sub

    Private Sub btnHistory_Click(sender As System.Object, e As System.EventArgs) Handles btnHistory.Click
        boolAbort = False
        Dim frm As New frmBrowseLegalActions
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        On Error GoTo RaiseErr

        arrRetriedData = New ArrayList
        'Dim strSql As String = "SELECT Defendants.DefendantId, LegalActions.ActionTaken, Defendants.GivenNames, " _
        '    & "Defendants.PrimaryAddress1, Defendants.PrimaryAddress2, Defendants.PrimaryAddress3, " _
        '    & "Defendants.PrimaryAddress4 FROM LegalActions LEFT OUTER JOIN Defendants ON " _
        '    & "LegalActions.DefendantId = Defendants.DefendantId WHERE Defendants.DefendantId IN " _
        '    & "(SELECT LegalActions.DefendantId FROM LegalActions WHERE LegalActions.ActionKey = " & intSelectedActionKey & ")"

        strGridHeaders = Nothing
        For p As Integer = 1 To dGrid.ColumnCount - 1
            strGridHeaders = strGridHeaders & dGrid.Columns(p).HeaderText & "|"
        Next

        For p As Integer = 0 To arrSelectedItems.Count - 1
            strGridHeaders = strGridHeaders & arrSelectedItems.Item(p) & "|"
        Next
        strGridHeaders = Mid(strGridHeaders, 1, (strGridHeaders.Length - 1))

        Cursor = Cursors.Default
        With pb1
            .Visible = True
            .Maximum = dGrid.RowCount + 10
            .Value = 0
        End With

        For p As Integer = 0 To dGrid.RowCount - 1
            Dim strLine As String = Nothing
            Dim strId As String = dGrid.Rows(p).Cells(1).Value.ToString
            For q As Integer = 1 To dGrid.ColumnCount - 1
                Dim strCellValue As String = Nothing
                If Not Object.Equals(dGrid.Rows(p).Cells(q).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(q).Value.ToString) Then
                        strCellValue = dGrid.Rows(p).Cells(q).Value.ToString
                    End If
                End If
                strLine = strLine & strCellValue & "|"
            Next

            For q As Integer = 0 To arrSelectedSerialNumbers.Count - 1

                Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), LegalActions.ActionDate, 106), ' ', '-')) AS [ActionDate] " _
                    & "FROM LegalActions WHERE LegalActions.DefendantId = '" & strId & "' AND ActionKey = " & CInt(arrSelectedSerialNumbers.Item(q)) & ""

                Dim strActionDate As String = Nothing
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then
                        If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                            strActionDate = objReader(0).ToString
                        End If
                    End If
                End If
                objReader.Close()
                strLine = strLine & strActionDate & "|"

            Next

            strLine = Mid(strLine, 1, strLine.Length - 1)
            arrRetriedData.Add(strLine)

            pb1.Value = pb1.Value + 1
        Next

        pb1.Value = pb1.Maximum

        Cursor = Cursors.Default

        Dim f As New frmLegalActionsHistory
        f.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On actions history load"
        ShowErrorMessage()
    End Sub


    '** PRINT TREE NODES ***

    Private Sub PrintStageTreeNodes()
        On Error GoTo RaiseErr
        strRichData = Nothing
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = 0 ORDER BY [ProcedureId]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strAction As String = Nothing
            Dim intKeyId As Integer = 0
            intXstart = 100
            strAction = objReader(0).ToString
            intKeyId = CInt(objReader(1).ToString)
            strRichData = strRichData & "<row><data>TEXT=" & strAction & ";X=" & intXstart & ";Y=15;FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=White;CH=20;AL=0;CW=400</data></row>"
            PrintStageNodes(intKeyId)
            'tvStages.Nodes.Add(node)
        End While
        objReader.Close()
        tvStages.ExpandAll()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
        ShowErrorMessage()
    End Sub

    Private Sub PrintStageNodes(ByRef Key As Integer)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = " & Key & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim strAction As String = objReader(0).ToString
            Dim intKeyId As Integer = CInt(objReader(1).ToString)
            strRichData = strRichData & "<row><data>TEXT=" & strAction & ";X=" & intXstart & ";Y=15;FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=White;CH=20;AL=0;CW=400</data></row>"
            PrintStageNodes(intKeyId)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
        ShowErrorMessage()
    End Sub

    Private Sub RecurseNodes(ByVal Col As TreeNodeCollection)
        For Each tn As TreeNode In Col
            arrSelectedItems.Add(tn.FullPath & "|" & tn.Tag)
            If tn.Nodes.Count > 0 Then
                RecurseNodes(tn.Nodes)
            End If
        Next
    End Sub

    Private Sub PrintNodes()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing
        Dim intTotalDefendant As Integer = 0

        If lblClientIdAnalysis.Text = "0" Then
            strSql = "SELECT COUNT(DefendantId) FROM Defendants"
        Else
            strSql = "SELECT COUNT(DefendantId) FROM Defendants WHERE PlaintifId = '" & lblClientIdAnalysis.Text & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intTotalDefendant = CInt(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        strRichData = "<row>" & _
            "<data>TEXT=NUMBER OF DEBTORS;X=110;Y=15;FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;CH=20;AL=0;CW=300</data>" & _
            "<data>TEXT=" & Format(intTotalDefendant, "#,##0") & ";X=310;Y=15;FN=Arial;FS=8;FC=Black;FB=True;FI=False;FU=False;BC=White;CH=20;AL=2;CW=300</data></row>"

        arrSelectedItems = New ArrayList
        RecurseNodes(tvStages.Nodes)
        For p As Integer = 0 To arrSelectedItems.Count - 1
            Dim strBuffer() As String = Split(arrSelectedItems.Item(p), "|")

            'Get the amounts and counts based on lblClientIdAnalysis here

            Dim intStageValues() As Double = ActionCount(CInt(strBuffer(1)), lblClientIdAnalysis.Text)

            Dim strDetails() As String = Split(strBuffer(0), "\")
            Dim strAction As String = strDetails(strDetails.Length - 1)
            Dim intIndent As Integer = strDetails.Length
            Dim intX As Integer = 100 + (15 * intIndent)
            If intIndent = 1 Then
                strRichData = strRichData & "<row>" & _
                    "<data>TEXT=" & strAction & ";X=" & intX & ";Y=15;FN=Arial;FS=8;FC=White;FB=True;FI=False;FU=False;BC=Black;CH=20;AL=0;CW=300</data>" & _
                    "<data>TEXT=" & CStr(Format(intStageValues(0), "#,##0")) & ";X=380;Y=15;FN=Arial;FS=8;FC=White;FB=True;FI=False;FU=False;BC=Black;CH=20;AL=2;CW=80</data>" & _
                    "<data>TEXT=" & CStr(Format(intStageValues(1), "#,##0.00")) & ";X=460;Y=15;FN=Arial;FS=8;FC=White;FB=True;FI=False;FU=False;BC=Black;CH=20;AL=2;CW=80</data>" & _
                    "<data>TEXT=" & CStr(Format(intStageValues(2), "#,##0")) & ";X=540;Y=15;FN=Arial;FS=8;FC=White;FB=True;FI=False;FU=False;BC=Black;CH=20;AL=2;CW=80</data>" & _
                    "<data>TEXT=" & CStr(Format(intStageValues(3), "#,##0.00")) & ";X=620;Y=15;FN=Arial;FS=8;FC=White;FB=True;FI=False;FU=False;BC=Black;CH=20;AL=2;CW=80</data>" & _
                    "</row>"
            Else
                strRichData = strRichData & "<row>" & _
                    "<data>TEXT=" & strAction & ";X=" & intX & ";Y=15;FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=White;CH=20;AL=0;CW=300</data>" & _
                    "<data>TEXT=" & CStr(Format(intStageValues(0), "#,##0")) & ";X=380;Y=15;FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=White;CH=20;AL=2;CW=80</data>" & _
                    "<data>TEXT=" & CStr(Format(intStageValues(1), "#,##0.00")) & ";X=460;Y=15;FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=White;CH=20;AL=2;CW=80</data>" & _
                    "<data>TEXT=" & CStr(Format(intStageValues(2), "#,##0")) & ";X=540;Y=15;FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=White;CH=20;AL=2;CW=80</data>" & _
                    "<data>TEXT=" & CStr(Format(intStageValues(3), "#,##0.00")) & ";X=620;Y=15;FN=Arial;FS=8;FC=Black;FB=False;FI=False;FU=False;BC=White;CH=20;AL=2;CW=80</data>" & _
                    "</row>"
            End If
        Next
        Dim rp As New SmartRichReportWriter.RichReportWriter
        With rp
            .strMainHeader1 = UCase(strCompanyName)
            .strMainHeader2 = "PORTFOLIO STAGGING ANALYSIS"
            If String.IsNullOrEmpty(cboPortfolioAnalysis.Text) Then
                .strMainHeader3 = "CONSOLIDATED STAGGING ANALYSIS"
            Else
                .strMainHeader3 = UCase(cboPortfolioAnalysis.Text)
            End If
            .intTitleXposition = 250
            .TitleColor = Color.Black
            .Data = strRichData
            .boolDrawBorder = True
            .HorizontalLines = True
            .GridColor = Color.WhiteSmoke
            .FooterColor = Color.Black
            .strFooterCaption = "Actions Analysis "
            .intFooterXposition = 100
            .intPageNumXposition = 700
            .HeaderRow = "<header>text=ACTION;X=110;Y=15;FN=Arial;FS=8;FC=White;FB=True;FI=false;FU=false;BC=Black;CH=20;AL=0;CW=300</header>" & _
                "<header>text=TOTAL;X=380;Y=15;FN=Arial;FS=8;FC=White;FB=True;FI=false;FU=false;BC=Black;CH=20;AL=1;CW=80</header>" & _
                "<header>text=AMOUNT;X=460;Y=15;FN=Arial;FS=8;FC=White;FB=True;FI=false;FU=false;BC=Black;CH=20;AL=1;CW=80</header>" & _
                "<header>text=CURRENT;X=540;Y=15;FN=Arial;FS=8;FC=White;FB=True;FI=false;FU=false;BC=Black;CH=20;AL=1;CW=80</header>" & _
                "<header>text=AMOUNT;X=620;Y=15;FN=Arial;FS=8;FC=White;FB=True;FI=false;FU=false;BC=Black;CH=20;AL=1;CW=80</header>"
        End With
        Cursor = Cursors.Default
        Dim ppd As New PrintPreviewDialog
        ppd.Document = rp
        ppd.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Actions Analysis Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnAnalysisDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnAnalysisDetails.Click
        AnalysisDetailsInformation()
    End Sub

    Private Sub AnalysisDetailsInformation()
        On Error GoTo RaiseErr
        strSelectedPortfolioAnalysisStageName = Nothing
        With TreeListView1
            If .Items.Count <= 0 Then Exit Sub
            Dim intDetailIndex As Integer = .SelectedItem.Index
            intSelectedKeyAnalysisIndex = arrRelativeNodesIds.Item(intDetailIndex)
            strSelectedPortfolioAnalysisId = lblClientIdAnalysis.Text
            strSelectedPortfolioAnalysisStageName = .SelectedItem.Text
            Dim frm As New frmLegalPotfolioAnalysisActionDetails
            frm.ShowDialog()
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "Make sure that you have selected at least a line from the analysis tree" & vbCr & "Error on analysis details"
        ShowErrorMessage()
    End Sub

    Private Sub TreeListView1_DoubleClick(sender As Object, e As System.EventArgs) Handles TreeListView1.DoubleClick
        AnalysisDetailsInformation()
    End Sub

    Private Sub btnExportActions_Click(sender As System.Object, e As System.EventArgs) Handles btnExportActions.Click
        Dim frm As New frmLegalExports
        frm.ShowDialog()
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strFileName As String = Nothing
        Dim sfd As New SaveFileDialog
        sfd.ShowDialog()

        If String.IsNullOrEmpty(strFileName) Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim strSqlCustomers As String = gwt_comm.ScriptCustomerData()
        Dim strDataInsertSql As String = Nothing
        'get the actions details
        Dim strSql As String = gwt_comm.ScriptTableFields("LegalActions", "SELECT")
        strDataInsertSql = strDataInsertSql & strSqlCustomers & vbCrLf
        strDataInsertSql = strDataInsertSql & gwt_comm.ScriptDataInsertStatement(strSql, "LegalActions")
        'Get the payment details
        strSql = Nothing
        strSql = gwt_comm.ScriptTableFields("DefendantTransactions", "SELECT")
        strDataInsertSql = strDataInsertSql & gwt_comm.ScriptDataInsertStatement(strSql, "DefendantTransactions")
        Dim FileWriter As New System.IO.StreamWriter(strFileName, False)
        FileWriter.WriteLine(strDataInsertSql)
        FileWriter.Close()

        Cursor = Cursors.Default
        MessageBox.Show("Export file created successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On debtor details export to text file"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrinters_Click(sender As System.Object, e As System.EventArgs) Handles btnPrinters.Click
        Dim frm As New frmPrinterSetup
        frm.ShowDialog()
    End Sub

    Private Sub btnGoReceipts_Click(sender As System.Object, e As System.EventArgs) Handles btnGoReceipts.Click
        DisplayPayments(dpStartFromReceipts.Value, dpEndToReceipts.Value)
    End Sub

    Private Sub btnPrintReceiptsList_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintReceiptsList.Click

    End Sub

    Private Sub btnReceiptDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnReceiptDetails.Click

    End Sub

    Private Sub cboReceiptsPortfolio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboReceiptsPortfolio.SelectedIndexChanged
        txtReceiptPortfolioId.Text = cboReceiptsPortfolio.SelectedItem.Col2
        DisplayPayments(dpStartFromReceipts.Value, dpEndToReceipts.Value)
    End Sub

    Private Sub DisplayPayments(StartingFrom As Date, EndingAt As Date)
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing

        If txtReceiptPortfolioId.Text = "0" Then
            strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
                & "DefendantTransactions.DefendantId AS [Debtor ID], Defendants.GivenNames AS [Name], " _
                & "Defendants.FileId AS [File #], DefendantTransactions.Description AS [Description], " _
                & "DefendantTransactions.ReceiptNumber AS [Receipt #], CAST(DefendantTransactions.Credit AS DECIMAL (10,2)) AS [Amount], " _
                & "DefendantTransactions.ReferenceNumber AS [Ref. #], DefendantTransactions.ReceivedBy AS [Cashier] " _
                & "FROM DefendantTransactions LEFT OUTER JOIN Defendants ON DefendantTransactions.DefendantId = Defendants.DefendantId " _
                & "WHERE DefendantTransactions.Credit <> 0 AND DefendantTransactions.TransactionDate BETWEEN " _
                & "'" & Format(StartingFrom, "dd-MMM-yyyy") & "' AND '" & Format(EndingAt, "dd-MMM-yyyy") & "'"
        Else
            strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
                & "DefendantTransactions.DefendantId AS [Debtor ID], Defendants.GivenNames AS [Name], " _
                & "Defendants.FileId AS [File #], DefendantTransactions.Description AS [Description], " _
                & "DefendantTransactions.ReceiptNumber AS [Receipt #], CAST(DefendantTransactions.Credit AS DECIMAL (10,2)) AS [Amount], " _
                & "DefendantTransactions.ReferenceNumber AS [Ref. #], DefendantTransactions.ReceivedBy AS [Cashier] " _
                & "FROM DefendantTransactions LEFT OUTER JOIN Defendants ON DefendantTransactions.DefendantId = Defendants.DefendantId " _
                & "WHERE DefendantTransactions.Credit <> 0 AND Defendants.PlaintifId = '" & txtReceiptPortfolioId.Text & "' " _
                & "AND DefendantTransactions.TransactionDate BETWEEN " _
                & "'" & Format(StartingFrom, "dd-MMM-yyyy") & "' AND '" & Format(EndingAt, "dd-MMM-yyyy") & "'"
        End If

        dGridAllData.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridAllData.DataSource = dTable

        Me.dGridAllData.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGridAllData.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        dGridAllData.Columns(2).Frozen = True

        For p As Integer = 0 To dGridAllData.Columns.Count - 1
            dGridAllData.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dGridAllData.Columns(p).ReadOnly = True
            If p = 6 Then
                dGridAllData.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGridAllData.Columns(p).DefaultCellStyle.Format = "N2"
            End If
        Next

        'Get the total paid
        Dim dblTotal As Double = 0
        For p As Integer = 0 To dGridAllData.RowCount - 1
            If Not Object.Equals(dGridAllData.Rows(p).Cells(6).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridAllData.Rows(p).Cells(6).Value.ToString) Then
                    If IsNumeric(dGridAllData.Rows(p).Cells(6).Value.ToString) Then
                        dblTotal = dblTotal + CDbl(dGridAllData.Rows(p).Cells(6).Value.ToString)
                    End If
                End If
            End If
        Next

        lblTotalPaymentReceipts.Text = Format(dblTotal, "#,##0.00")

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On Payment and Receipts View"
        ShowErrorMessage()
    End Sub

    Private Sub btnActions_Click(sender As System.Object, e As System.EventArgs) Handles btnActions.Click
        dGrid.EndEdit()
        GetAllSelectedRecords()
        If arrSelectedItems.Count > 0 Then
            boolAbort = False
            Dim frm As New frmLegalBulkActions
            frm.ShowDialog()
            If boolAbort = True Then Exit Sub
            LoadDebtorsDetails()
        End If
    End Sub

End Class
