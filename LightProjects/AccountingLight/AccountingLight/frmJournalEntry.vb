Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmJournalEntry

    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrid.CellEnter
        On Error GoTo RaiseErr
        If cboAccounts.Visible = True Then cboAccounts.Visible = False
        If cboCostCenter.Visible = True Then cboCostCenter.Visible = False
        If e.ColumnIndex = 0 Then
            LoadAccounts()
            cboAccounts.Size = dgrid.CurrentCell.Size
            cboAccounts.Top = dgrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + 92
            cboAccounts.Left = dgrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left + 1
            If Not (Object.Equals(Convert.ToString(dgrid.CurrentCell.Value), "")) Then
                cboAccounts.Text = Convert.ToString(dgrid.CurrentCell.Value)
                'Get the ledger account description 
                Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountName FROM LedgerAccounts WHERE AccountNumber = '" & dgrid.CurrentCell.Value.ToString & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then lblDescription.Text = objReader(0).ToString
                End If
                objReader.Close()
            Else
                cboAccounts.Text = ""
            End If
            cboAccounts.Visible = True
            cboAccounts.Focus()
            cboAccounts.SelectAll()
        End If

        If e.ColumnIndex = 2 Then
            With cboCostCenter
                .Size = dgrid.CurrentCell.Size
                .Top = dgrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + 92
                .Left = dgrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left + 1
                .Visible = True
                .Focus()
                .SelectAll()
            End With
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item code search"
        ShowErrorMessage()
    End Sub

    Private Sub frmJournalEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgrid.Rows.Add(450)
        AlternateColors()
        NumberAllRows()
        LoadAccounts()
        If boolEditStatus = False Then
            Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
            txtJournalNumber.Text = CStr(gwt_comm.GetNextDocumentNumber("JournalEntries"))
        Else
            LoadData()
        End If 'otherwise load journal
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT [TransDate], [DebitAccount],[CreditAccount], [Narration], [Amount], " _
            & "[FolioReference], [CostCode] FROM JournalEntries WHERE [JournalNumber] = " & intSelectedTransaction & ""
        txtJournalNumber.Text = intSelectedTransaction : txtJournalNumber.Enabled = False
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        'AccountNumber,Narration,CostCenter,Folio,Type,Amount
        Dim i As Integer = 0
        Dim dblDebitTotals As Double = 0
        Dim dblCreditTotals As Double = 0

        While objReader.Read
            Dim strType As String = "DEBIT"
            Dim strAccount As String = Nothing
            Dim strCreditAccount As String = objReader("CreditAccount").ToString
            Dim strDebitAccount As String = objReader("DebitAccount").ToString

            If Not String.IsNullOrEmpty(strCreditAccount) Then
                strType = "CREDIT"
                strAccount = objReader("CreditAccount").ToString
                dblCreditTotals = dblCreditTotals + CDbl(objReader("Amount").ToString)
            Else
                strAccount = objReader("DebitAccount").ToString
                dblDebitTotals = dblDebitTotals + CDbl(objReader("Amount").ToString)
            End If

            dpDate.Value = CDate(objReader(0).ToString)
            'dgrid.Rows.Add(strAccount, objReader(3), "", objReader(5), strType, objReader(4))
            dgrid.Rows(i).Cells(0).Value = strAccount
            dgrid.Rows(i).Cells(1).Value = objReader(3)
            dgrid.Rows(i).Cells(2).Value = objReader("CostCode")
            dgrid.Rows(i).Cells(3).Value = objReader(5)
            dgrid.Rows(i).Cells(4).Value = strType
            dgrid.Rows(i).Cells(5).Value = objReader(4)
            i = i + 1
        End While
        objReader.Close()
        txtCredits.Text = Format(dblCreditTotals, "##0.00")
        txtDebits.Text = Format(dblDebitTotals, "##0.00")
        cboAccounts.Visible = False
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Journal Details load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgrid.RowsRemoved
        Dim iBal As Integer = 300 - dgrid.Rows.Count
        dgrid.Rows.Add(iBal)
        AlternateColors()
        NumberAllRows()
    End Sub

    Private Sub NumberAllRows()
        'For i As Integer = 0 To dGrid.Rows.Count - 1
        '    dGrid.Rows(i).HeaderCell.Value = (i + 1)
        'Next
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 0 To dgrid.Rows.Count - 1
            For j As Integer = 0 To dgrid.ColumnCount - 1
                Dim backColor As Color = Color.White
                dgrid.Rows(i).Cells(j).Style.BackColor = backColor
            Next
        Next
        For i As Integer = 0 To dgrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dgrid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                dgrid.Rows(i).Cells(j).Style.BackColor = backColor
                dgrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrid.CellEndEdit
        With dgrid
            If e.ColumnIndex = 5 Then
                dgrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dgrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString), "##0.00")
                ComputeTotals()
            End If
        End With
    End Sub

    Private Sub ComputeTotals()
        With dgrid
            Dim dblDebitTotal As Double = 0
            Dim dblCreditTotal As Double = 0
            Dim strEntryType As String = "DEBIT"
            For i As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "")) Then
                    strEntryType = UCase(Convert.ToString(.Rows(i).Cells(4).Value))
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "")) Then
                    If IsNumeric(Convert.ToString(.Rows(i).Cells(5).Value)) Then
                        If strEntryType = "DEBIT" Then
                            dblDebitTotal = dblDebitTotal + CDbl(Convert.ToString(.Rows(i).Cells(5).Value))
                        Else
                            dblCreditTotal = dblCreditTotal + CDbl(Convert.ToString(.Rows(i).Cells(5).Value))
                        End If
                    End If
                End If
            Next
            txtDebits.Text = Format(dblDebitTotal, "##0.00")
            txtCredits.Text = Format(dblCreditTotal, "##0.00")
        End With
    End Sub

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgrid.EditingControlShowing
        Try
            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                'In order to prevent optical problems, we had to call the removeHandler twice
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgrid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim numCols As Integer = dgrid.ColumnCount
            Dim numRows As Integer = dgrid.RowCount
            Dim currCell As DataGridViewCell = dgrid.CurrentCell
            If currCell.ColumnIndex = numCols - 1 Then
                If currCell.RowIndex < numRows - 1 Then
                    dgrid.CurrentCell = dgrid.Item(0, currCell.RowIndex + 1)
                End If
            Else
                dgrid.CurrentCell = dgrid.Item(currCell.ColumnIndex + 1, currCell.RowIndex)
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub cboAccounts_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAccounts.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dgrid.CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(1)
            dgrid.Focus()
        End If
    End Sub

    Private Sub cboAccounts_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccounts.LostFocus
        cboAccounts.Visible = False
    End Sub

    Private Sub cboAccounts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccounts.SelectedIndexChanged
        CommitAccounts()
    End Sub

    Private Sub CommitAccounts()
        On Error GoTo RaiseErr
        If cboAccounts.Focused = False Then Exit Sub
        If Not cboAccounts.SelectedItem Is Nothing Then
            dgrid.CurrentRow.Cells(0).Value = cboAccounts.SelectedItem.Col2
            dgrid.CurrentRow.Cells(1).Value = cboAccounts.SelectedItem.Col1
        Else
            dgrid.CurrentRow.Cells(0).Value = Nothing
            'dGrid.CurrentRow.Cells(1).Value = Nothing
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On accounts information load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM LedgerAccounts ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboAccounts
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "180;100"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM LedgerAccounts", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboAccounts.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()
        If intItemsCount > 0 Then
            cboAccounts.SelectedIndex = -1
            cboAccounts.Items.Clear()
            cboAccounts.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboAccounts.Items.AddRange(DropDownItems)
        End If

        'Load the cost centers
        strSql = "SELECT CostCenterName +';'+ CONVERT(NVARCHAR, OrdinalNo) AS " _
            & "[CostCenters] FROM SystemCostCenters ORDER BY CostCenterName"
        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboCostCenter
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "180;100"
        End With
        'Get a count of the items
        intItemsCount = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(OrdinalNo) FROM SystemCostCenters", cnn)
        objCount = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItemsCenters(intItemsCount - 1) As MTGCComboBoxItem

        cboCostCenter.Items.Clear()
        i = 0 : p = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItemsCenters(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()
        If intItemsCount > 0 Then
            cboCostCenter.SelectedIndex = -1
            cboCostCenter.Items.Clear()
            cboCostCenter.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCostCenter.Items.AddRange(DropDownItemsCenters)
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Account Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboCostCenter_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCostCenter.LostFocus
        cboCostCenter.Visible = False
    End Sub

    Private Sub cboCostCenter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCostCenter.SelectedIndexChanged
        If Not cboCostCenter.SelectedItem Is Nothing Then
            dgrid.CurrentRow.Cells(2).Value = cboCostCenter.SelectedItem.Col2
        Else
            dgrid.CurrentRow.Cells(2).Value = Nothing
        End If
    End Sub

    Private Sub cboCostCenter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCostCenter.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dgrid.CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(3)
            dgrid.Focus()
        End If
    End Sub

    Private Function SumOfEntries() As Double
        Dim dblReturn As Double = 0
        Dim dblDebits As Double = 0
        Dim dblCredits As Double = 0
        If Not IsNumeric(txtCredits.Text) Then txtCredits.Text = "0.00"
        If Not IsNumeric(txtDebits.Text) Then txtDebits.Text = "0.00"
        dblDebits = CDbl(txtDebits.Text) : dblCredits = CDbl(txtCredits.Text)
        dblReturn = dblDebits - dblCredits
        Return dblReturn
    End Function

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If dgrid.Rows.Count <= 0 Then
            MessageBox.Show("no entries to process", "Empty Transactions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        On Error GoTo RaiseErr

        'Check first that the sum of debits and credits is equal

        If SumOfEntries() <> 0 Then
            MessageBox.Show("The sum of debit entries against credit entries is not equal." & vbCrLf & _
                "Please verify your entries", "Entry Errors", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim objCommand As Data.OleDb.OleDbCommand

        'If the form was opened in edit mode then delete first the transactions based on the special key
        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions

        If boolEditStatus = True Then
            gwt_comm.DeleteSpecialKeyTransaction(intSelectedSpecialKey)
        End If

        Dim lngJvEntryNumber As Integer = CInt(txtJournalNumber.Text)
        Dim boolMadeEntries As Boolean = False
        Dim intSpecialKey As Integer = gwt_comm.SpecialKey()

        With dgrid
            For i As Integer = 0 To .Rows.Count - 1
                'Insert into the journal tables
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "") Then
                    Dim strDescription As String = Nothing
                    Dim strLedgerAccount As String = Nothing
                    Dim dblAmount As Double = 0
                    Dim strType As String = Nothing
                    Dim strAccountNumber As String = Nothing
                    Dim strFolio As String = Nothing
                    Dim strCostCenter As String = Nothing
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "") Then
                        strAccountNumber = .Rows(i).Cells(0).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "") Then
                        strDescription = .Rows(i).Cells(1).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "") Then
                        strCostCenter = .Rows(i).Cells(2).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "") Then
                        strFolio = .Rows(i).Cells(3).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "") Then
                        strType = .Rows(i).Cells(4).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "") Then
                        If IsNumeric(.Rows(i).Cells(5).Value.ToString) Then dblAmount = CDbl(.Rows(i).Cells(5).Value.ToString)
                    End If

                    If Not String.IsNullOrEmpty(strAccountNumber) Then
                        If dblAmount <> 0 Then
                            If Not String.IsNullOrEmpty(strType) Then
                                If UCase(strType) = "DEBIT" Then
                                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO JournalEntries([TransDate], [DebitAccount], " _
                                        & "[CreditAccount], [Narration], [Amount], [UserName], [BranchName], [ChangeDate], [JournalNumber], " _
                                        & "[FolioReference], [SpecialKey], [CostCode]) VALUES " _
                                        & "('" & Format(dpDate.Value, "dd-MMM-yyyy") & "', '" & strAccountNumber & "', " _
                                        & "'','" & strDescription & "', " & dblAmount & ", " _
                                        & "'" & strUserName & "', '" & strUserBranch & "', '" & Now & "', " & lngJvEntryNumber & ", " _
                                        & "'" & strFolio & "', " & intSpecialKey & ", '" & strCostCenter & "')", cnn)
                                Else
                                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO JournalEntries([TransDate], [DebitAccount], " _
                                        & "[CreditAccount], [Narration], [Amount], [UserName], [BranchName], [ChangeDate], [JournalNumber], " _
                                        & "[FolioReference], [SpecialKey], [CostCode]) VALUES " _
                                        & "('" & Format(dpDate.Value, "dd-MMM-yyyy") & "', '', " _
                                        & "'" & strAccountNumber & "','" & strDescription & "', " & dblAmount & ", " _
                                        & "'" & strUserName & "', '" & strUserBranch & "', '" & Now & "', " & lngJvEntryNumber & ", " _
                                        & "'" & strFolio & "', " & intSpecialKey & ", '" & strCostCenter & "')", cnn)
                                End If
                                objCommand.ExecuteNonQuery()

                                Dim strSql As String = Nothing
                                If UCase(strType) = "DEBIT" Then
                                    strSql = "INSERT INTO LedgerTransactions ([TransactionDate],[AccountNumber],[Amount]," _
                                        & "[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch],[Reference], " _
                                        & "[FolioReference], [JournalNumber], [SpecialKey], [CostCode]) VALUES " _
                                        & "('" & Format(dpDate.Value, "dd-MMM-yyyy") & "', '" & strAccountNumber & "', " & dblAmount & ", " _
                                        & "'DEBIT','','" & strDescription & "', '" & strUserName & "', '" & strUserBranch & "', " _
                                        & "" & lngJvEntryNumber & ", '" & strFolio & "', " & lngJvEntryNumber & ", " & intSpecialKey & ", '" & strCostCenter & "')"
                                Else
                                    strSql = "INSERT INTO LedgerTransactions ([TransactionDate],[AccountNumber],[Amount]," _
                                        & "[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch],[Reference], " _
                                        & "[FolioReference], [JournalNumber], [SpecialKey], [CostCode]) VALUES " _
                                        & "('" & Format(dpDate.Value, "dd-MMM-yyyy") & "', '" & strAccountNumber & "', " & dblAmount & ", " _
                                        & "'CREDIT','','" & strDescription & "', '" & strUserName & "', '" & strUserBranch & "', " _
                                        & "" & lngJvEntryNumber & ", '" & strFolio & "', " & lngJvEntryNumber & ", " & intSpecialKey & ", '" & strCostCenter & "')"
                                End If
                                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                objCommand.ExecuteNonQuery()
                                boolMadeEntries = True
                            End If
                        End If
                    End If
                End If
            Next
        End With

        'Update the control numbers table
        If boolMadeEntries = True Then
            objCommand = New Data.OleDb.OleDbCommand("UPDATE [ControlNumbers] SET JournalEntries = " & lngJvEntryNumber & "", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Journal transaction processed successfully", "Transaction Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Clear the controls
            dgrid.Rows.Clear()
            dgrid.Rows.Add(450)
            AlternateColors()
            NumberAllRows()
            gwt_comm = New CommonLibrary.Commons.CommonFunctions
            txtJournalNumber.Text = CStr(gwt_comm.GetNextDocumentNumber("JournalEntries"))
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On journal posting"
        ShowErrorMessage()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If dgrid.Rows.Count <= 0 Then Exit Sub
        With dgrid.CurrentRow
            For i As Integer = 0 To dgrid.Columns.Count - 1
                .Cells(i).Value = Nothing
            Next
            ComputeTotals()
        End With
    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT [TransDate], [DebitAccount], " _
            & "[CreditAccount], [Narration], [Amount], " _
            & "[FolioReference],[CostCode] FROM JournalEntries WHERE " _
            & "JournalNumber = " & CInt(txtJournalNumber.Text) & ""

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
            .strMainHeader2 = "JOURNAL ENTRY NUMBER: " & txtJournalNumber.Text
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