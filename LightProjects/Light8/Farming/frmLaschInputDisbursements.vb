Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Transactions

Public Class frmLaschInputDisbursements

    Dim boolFormLoading As Boolean

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGrid.EditingControlShowing
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

    Private Sub frmLaschInputDisbursements_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        dGrid.Rows.Add(100)
        LoadData()
        LoadInventoryData()
        If boolEditStatus = True Then LoadSelectedData()
        boolFormLoading = False
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT LastName +' '+FirstName +' '+ OtherNames +';'+ AccountNumber AS [Customer] " _
            & "FROM LaschCustomers ORDER BY LastName, FirstName, OtherNames"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Set up the drop down combo box
        Dim intWidth As Integer = cboName.Width - 50
        With cboName
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "250;80"
        End With

        'Get a count of the items
        Dim intItemsCount As Double = 0

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(AccountNumber) FROM LaschCustomers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()

        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboName.Items.Clear()
        Dim p As Double = 0

        'Continue to read until you reach the end of the file.
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            End If
            p = p + 1
        End While
        objReader.Close()

        If intItemsCount > 0 Then
            cboName.SelectedIndex = -1
            cboName.Items.Clear()
            cboName.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboName.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " On customers details load"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ComputeTotal()
        On Error GoTo RaiseErr
        Dim dblRunningTotal As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblAmount As Double = 0
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                    dblAmount = CDbl(dGrid.Rows(i).Cells(4).Value.ToString)
                    dblRunningTotal = dblRunningTotal + dblAmount
                End If
            End If
        Next
        lblTotal.Text = Format(dblRunningTotal, "##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Lasch Disbursements Total Computation"
        ShowErrorMessage()
    End Sub

    Private Sub FinishProcess()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim objCommand As Data.OleDb.OleDbCommand

        'Create a transaction
        Dim intNextDocumentNumber As Integer = 0
        If boolEditStatus = False Then
            intNextDocumentNumber = GetDocumentNumber()
        Else
            intNextDocumentNumber = intSelectedTransaction
        End If

        Dim [option] = New TransactionOptions With {.IsolationLevel = IsolationLevel.ReadCommitted, .Timeout = TimeSpan.FromSeconds(60)}
        Using InputTransactions = New TransactionScope(TransactionScopeOption.Required, [option])

            'Delete the record if it is in edit mode
            If boolEditStatus = True Then
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LaschCustomerTransactions " _
                    & "WHERE DocumentNumber = " & intNextDocumentNumber & "", cnn)
                objCommand.ExecuteNonQuery()
            End If

            For i As Integer = 0 To dGrid.Rows.Count - 1
                Dim strDescription As String = Nothing
                Dim dblValue As Double = 0
                Dim strItemCode As String = Nothing
                Dim dblQuantity As Double = 0
                Dim dblUnitPrice As Double = 0

                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "") Then
                    strItemCode = dGrid.Rows(i).Cells(0).Value.ToString
                End If
                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                    strDescription = dGrid.Rows(i).Cells(1).Value.ToString
                End If
                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "") Then
                    If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                        dblUnitPrice = dGrid.Rows(i).Cells(2).Value.ToString
                    End If
                End If
                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "") Then
                    If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                        dblQuantity = dGrid.Rows(i).Cells(3).Value.ToString
                    End If
                End If
                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "") Then
                    If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                        dblValue = dGrid.Rows(i).Cells(4).Value.ToString
                    End If
                End If
                If Not String.IsNullOrEmpty(strDescription) Then
                    If dblValue <> 0 Then
                        Dim strSql As String = "INSERT INTO LaschCustomerTransactions ([DocumentNumber],[TransDate],[AccountNumber]," _
                            & "[Description],[Debit],[Credit],[UserName],[ChangeDate], [ItemCode], [Quantity], [UnitPrice]) VALUES (" & intNextDocumentNumber & ", " _
                            & "'" & Format(dpTransDate.Value, "dd-MMM-yyyy") & "', '" & lblAccountNumber.Text & "', " _
                            & "'" & strDescription & "', " & dblValue & ", 0, '" & strUserName & "', '" & Now & "', " _
                            & "'" & strItemCode & "', " & dblQuantity & ", " & dblUnitPrice & ")"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()

                        Dim intKey As Integer = SpecialKey()

                        'strPublicCostOfSales
                        If Not String.IsNullOrEmpty(strPublicCostOfSales) And Not String.IsNullOrEmpty(strPublicPurchasesAccount) Then
                            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                                & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                                & "('" & strPublicCostOfSales & "', '" & Format(dpTransDate.Value, "dd-MMM-yyyy") & "', " & dblUnitPrice & ", " _
                                & "'DEBIT', '" & strPublicPurchasesAccount & "', '" & strDescription & "', " _
                                & "'" & strUserName & "', '" & strUserBranch & "', " & CDbl(intNextDocumentNumber) & ", " & Convert.ToDouble(intKey) & ")", cnn)
                            objCommand.ExecuteNonQuery()
                            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                                & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                                & "('" & strPublicPurchasesAccount & "', '" & Format(dpTransDate.Value, "dd-MMM-yyyy") & "', " & dblUnitPrice & ", " _
                                & "'CREDIT', '" & strPublicCostOfSales & "', '" & strDescription & "', " _
                                & "'" & strUserName & "', '" & strUserBranch & "', " & CDbl(intNextDocumentNumber) & ", " & Convert.ToDouble(intKey) & ")", cnn)
                            objCommand.ExecuteNonQuery()
                        Else
                            MessageBox.Show("The system has detected that you have not set the cost of sales account" & vbCrLf & _
                                "This will seriously affect the ledger account and trial balance", "Missing Cost of Sales Account", _
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                        'Update the inventory table and accounts
                        Dim intStockBalance As Double = 0
                        objCommand = New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & strItemCode & "'", cnn)
                        Dim dbReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                        If dbReader.HasRows Then
                            dbReader.Read()
                            If IsNumeric(dbReader(0).ToString) Then intStockBalance = CDbl(dbReader(0).ToString) Else intStockBalance = 0
                        Else
                            intStockBalance = 0
                        End If
                        dbReader.Close()
                        intStockBalance = intStockBalance - CDbl(dGrid.Rows(i).Cells(4).Value)
                        objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = " & intStockBalance & " WHERE ItemCode = '" & strItemCode & "'", cnn)
                        objCommand.ExecuteNonQuery()

                    End If
                End If
            Next
            InputTransactions.Complete()
        End Using

        Cursor = Cursors.Default
        MessageBox.Show("Transaction has been processed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        dGrid.Rows.Clear()
        dGrid.Rows.Add(100)
        lblFarmName.Text = Nothing
        lblLocation.Text = Nothing
        lblAccountNumber.Text = Nothing
        lblCover.Text = "0.00"
        lblDrawn.Text = "0.00"
        lblBalance.Text = "0.00"
        cboName.Text = ""
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Lasch Disbursements Total Computation"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If IsNumeric(dGrid.CurrentCell.Value) Then
            dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")
        End If

        If dGrid.CurrentCell.ColumnIndex = 2 Or dGrid.CurrentCell.ColumnIndex = 3  Then
            ComputeLineTotals()
        End If
        ComputeTotal()
        If CDbl(lblTotal.Text) > CDbl(lblBalance.Text) Then
            MessageBox.Show("The amount is now in excess of the cover. Transaction will not be accepted", "Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            dGrid.CurrentCell.Value = Format(0, "##0.00")
            ComputeLineTotals()
            ComputeTotal()
        End If
    End Sub

    Private Sub ComputeLineTotals()
        Dim dblColumn3 As Double = 0
        Dim dblColumn4 As Double = 0

        If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(2).Value), "") Then
            If IsNumeric(dGrid.CurrentRow.Cells(2).Value.ToString) Then
                dblColumn3 = CDbl(dGrid.CurrentRow.Cells(2).Value.ToString)
            End If
        End If
        If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(3).Value), "") Then
            If IsNumeric(dGrid.CurrentRow.Cells(3).Value.ToString) Then
                dblColumn4 = CDbl(dGrid.CurrentRow.Cells(3).Value.ToString)
            End If
        End If

        Dim dblLineTotal As Double = dblColumn3 * dblColumn4

        dGrid.CurrentRow.Cells(4).Value = Format(dblLineTotal, "##0.00")
    End Sub

    Private Function CustomerDetails(AccountNumber As String) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList

        Dim strFarmName As String = Nothing
        Dim strLocation As String = Nothing
        Dim dblCover As Double = 0
        Dim dblDrawnToDate As Double = 0

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT FarmName, Province +', '+ District +', '+ Ward AS [Location], " _
            & "[FmlSumAssured] FROM LaschCustomers WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strFarmName = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strLocation = objReader(1).ToString
            If IsNumeric(objReader(2).ToString) Then dblCover = CDbl(objReader(2).ToString)
        End If
        objReader.Close()

        'Get the transactions to date
        Dim dblDebits As Double = 0
        Dim dblCredits As Double = 0

        objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Debit), SUM(Credit) FROM LaschCustomerTransactions WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblDebits = CDbl(objReader(0).ToString)
            If IsNumeric(objReader(1).ToString) Then dblCredits = CDbl(objReader(1).ToString)
        End If
        objReader.Close()

        dblDrawnToDate = dblDebits

        arrReturn.Add(strFarmName)
        arrReturn.Add(strLocation)
        arrReturn.Add(dblCover)
        arrReturn.Add(dblDrawnToDate)
        arrReturn.Add(dblCredits)

        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Details Fetch"
        ShowErrorMessage()
    End Function

    Private Sub cboName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboName.SelectedIndexChanged

        If String.IsNullOrEmpty(cboName.Text) Then Exit Sub
        If boolFormLoading = True Then Exit Sub
        lblFarmName.Text = Nothing
        lblLocation.Text = Nothing
        lblAccountNumber.Text = Nothing
        lblCover.Text = "0.00"
        lblDrawn.Text = "0.00"
        lblBalance.Text = "0.00"

        Dim arrValues As New ArrayList
        arrValues = CustomerDetails(cboName.SelectedItem.Col2)
        With arrValues
            lblFarmName.Text = .Item(0).ToString
            lblLocation.Text = .Item(1).ToString
            lblAccountNumber.Text = cboName.SelectedItem.Col2
            lblCover.Text = Format(CDbl(.Item(2)), "##0.00")
            lblDrawn.Text = Format(CDbl(.Item(3)), "##0.00")
            lblBalance.Text = Format((CDbl(lblCover.Text) - CDbl(.Item(3))), "##0.00")
        End With

    End Sub

    Private Sub LoadSelectedData()
        On Error GoTo RaiseErr
        Dim strAccountNumber As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ItemCode, Quantity, UnitPrice, Description, CAST(Debit AS DECIMAL (10,2)) AS [Debit], AccountNumber FROM " _
            & "LaschCustomerTransactions WHERE DocumentNumber = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim n As Integer = 0
        While objReader.Read
            If Not IsDBNull(objReader("ItemCode").ToString) Then dGrid.Rows(n).Cells(0).Value = objReader("ItemCode").ToString
            If Not IsDBNull(objReader("Description").ToString) Then dGrid.Rows(n).Cells(1).Value = objReader("Description").ToString
            If IsNumeric(objReader("UnitPrice").ToString) Then dGrid.Rows(n).Cells(2).Value = Format(CDbl(objReader("UnitPrice").ToString), "##0.00")
            If IsNumeric(objReader("Quantity").ToString) Then dGrid.Rows(n).Cells(3).Value = Format(CDbl(objReader("Quantity").ToString), "##0.00")
            If IsNumeric(objReader("Debit").ToString) Then dGrid.Rows(n).Cells(4).Value = Format(CDbl(objReader("Debit").ToString), "##0.00")
            If Not IsDBNull(objReader("AccountNumber").ToString) Then strAccountNumber = objReader("AccountNumber").ToString
            n = n + 1
        End While
        objReader.Close()
        ComputeTotal()

        'Get the details of farmer
        Dim strSql As String = "SELECT LastName +' '+FirstName +' '+ OtherNames FROM LaschCustomers WHERE AccountNumber = '" & strAccountNumber & "'"
        objCommand = New Data.OleDb.OleDbCommand(strsql, cnn)
        objReader = objCommand.ExecuteReader
        Dim strFarmerNames As String = Nothing
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strFarmerNames = UCase(objReader(0).ToString)
        End If
        objReader.Close()

        If Not String.IsNullOrEmpty(strFarmerNames) Then
            cboName.SelectedText = strFarmerNames
        End If

        Dim arrValues As New ArrayList
        arrValues = CustomerDetails(strAccountNumber)
        With arrValues
            lblFarmName.Text = .Item(0).ToString
            lblLocation.Text = .Item(1).ToString
            lblAccountNumber.Text = strAccountNumber
            lblCover.Text = Format(CDbl(.Item(2)), "##0.00")
            lblDrawn.Text = Format(CDbl(.Item(3)), "##0.00")
            lblBalance.Text = Format((CDbl(lblCover.Text) - CDbl(.Item(3))), "##0.00")
        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Transaction Details Load"
        ShowErrorMessage()
    End Sub

    Private Function GetDocumentNumber() As Integer
        On Error GoTo RaiseErr
        Dim intReturn As Integer = 1
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT(DocumentNumber) FROM LaschCustomerTransactions ORDER BY DocumentNumber DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intReturn = CInt(objReader(0).ToString) + 1
        End If
        objReader.Close()
        Return intReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Document Number Allocation Failure"
        ShowErrorMessage()
    End Function

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(cboName.Text) Then
            MessageBox.Show("Please enter valid customer information", "Invalid Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblAccountNumber.Text) Then
            MessageBox.Show("Please enter valid customer information", "Invalid Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboName.Focus()
            Exit Sub
        End If
        FinishProcess()
    End Sub

    Private Sub LoadInventoryData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim arrItems As New ArrayList

        strSql = "SELECT ItemCode +';'+GroupName +';'+ CONVERT(NVARCHAR, " _
            & "CAST(SellingPrice AS DECIMAL (10,2))) AS " _
            & "[Items] FROM InventoryItems WHERE Status = 'ACTIVE' ORDER BY ItemCode"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 3
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "160;180;60"
        End With

        arrItems.Add("--- COMMENT ---;;0.00")
        arrItems.Add("--- SERVICE ---;;0.00")

        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                arrItems.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        'Get a count of the items
        Dim DropDownItems(arrItems.Count - 1) As MTGCComboBoxItem

        cboItems.Items.Clear()

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrItems.Count - 1
            'File the listview with details.
            If Not IsDBNull(arrItems.Item(p)) Then
                Dim strRecordText() As String = Split(arrItems.Item(p), ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2))
            End If
        Next
        objReader.Close()
        'Load the banks to the combo box
        If arrItems.Count > 0 Then
            cboItems.SelectedIndex = -1
            cboItems.Items.Clear()
            cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboItems.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboItems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboItems.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(1)
            dGrid.Focus()
        End If
    End Sub

    Private Sub cboItems_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.LostFocus
        cboItems.Visible = False
    End Sub

    Private Sub cboItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.SelectedIndexChanged
        CommitValueChanged()
    End Sub

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr
        If cboItems.Focused = False Then Exit Sub
        Dim objCommand As Data.OleDb.OleDbCommand
        For z As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.CurrentRow.Cells(z).Value = Nothing
        Next
        Dim boolItemTaxable As Boolean = True
        ComputeTotal()
        If Not cboItems.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(0).Value = cboItems.SelectedItem.Col1
            dGrid.CurrentRow.Cells(1).Value = cboItems.SelectedItem.Col2
            dGrid.CurrentRow.Cells(2).Value = cboItems.SelectedItem.Col3
            dGrid.CurrentRow.Cells(3).Value = "1"
            If IsNumeric(cboItems.SelectedItem.Col3) Then
                dGrid.CurrentRow.Cells(4).Value = Format(CDbl(cboItems.SelectedItem.Col3), "##0.00")
            Else
                dGrid.CurrentRow.Cells(4).Value = "0.00"
            End If
        Else
            dGrid.CurrentRow.Cells(0).Value = Nothing
            dGrid.CurrentRow.Cells(1).Value = Nothing
            dGrid.CurrentRow.Cells(2).Value = Nothing
            dGrid.CurrentRow.Cells(3).Value = "0"
            dGrid.CurrentRow.Cells(4).Value = "0.00"
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Item Entry"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter
        On Error GoTo RaiseErr
        'cboSerials.Visible = False
        If e.RowIndex < 0 Then Exit Sub
        If cboItems.Visible = True Then cboItems.Visible = False
        If e.ColumnIndex = 0 Then
            LoadData()
            cboItems.Size = dGrid.CurrentCell.Size
            cboItems.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top
            cboItems.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                cboItems.Text = Convert.ToString(dGrid.CurrentCell.Value)
            Else
                cboItems.Text = ""
            End If
            cboItems.Visible = True '152
            cboItems.Focus()
            cboItems.SelectAll()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item code search"
        ShowErrorMessage()
    End Sub

End Class
