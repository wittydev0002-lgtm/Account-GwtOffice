Imports System.Drawing.Printing
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCreditNoteEntry

    Dim arrPrintDetails As ArrayList
    Dim strType As String = "CREDIT NOTE"

    Dim mybitMap As Bitmap

    Dim strSelectedReport As String
    Dim strFileName As String = Nothing

    Dim strCustomerDetails As String
    Dim strNoteDetails As ArrayList
    Dim rsInvoiceTotals As String

    Dim dblInvoiceTotal As Double
    Dim dblTaxes As Double
    Dim dblDiscounts As Double
    Dim i As Double = 0
    Dim strvalue As String
    Dim strDate As Date
    Dim itm As Double
    Dim boolPrintFromPreview As Boolean
    Dim intPaymentReceiptNumber As Double
    Dim strCustomerAccountNumberPayments As String

    Dim boolExitingWhile As Boolean = False
    Dim intPage As Single = 1
    Dim intPageTotals As Double = 1

    Dim strItemType As String = Nothing

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If IsNumeric(dGrid.CurrentCell.Value) Then
            dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")
        End If
        If dGrid.CurrentCell.ColumnIndex = 3 Or dGrid.CurrentCell.ColumnIndex = 4 _
            Or dGrid.CurrentCell.ColumnIndex = 6 Or dGrid.CurrentCell.ColumnIndex = 7 Then

            Dim dblColumn3 As Double = 0
            Dim dblColumn4 As Double = 0
            Dim dblColumn6 As Double = 0
            Dim dblColumn7 As Double = 0

            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(3).Value), "") Then
                If IsNumeric(dGrid.CurrentRow.Cells(3).Value.ToString) Then
                    dblColumn3 = CDbl(dGrid.CurrentRow.Cells(3).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(4).Value), "") Then
                If IsNumeric(dGrid.CurrentRow.Cells(4).Value.ToString) Then
                    dblColumn4 = CDbl(dGrid.CurrentRow.Cells(4).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(6).Value), "") Then
                If IsNumeric(dGrid.CurrentRow.Cells(6).Value.ToString) Then
                    dblColumn6 = CDbl(dGrid.CurrentRow.Cells(6).Value.ToString)
                End If
            End If

            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(7).Value), "") Then
                If IsNumeric(dGrid.CurrentRow.Cells(7).Value.ToString) Then
                    dblColumn7 = CDbl(dGrid.CurrentRow.Cells(7).Value.ToString)
                End If
            End If

            If dGrid.CurrentCell.ColumnIndex = 7 Then
                If dblColumn7 = 0 Then
                    ComputeValues(dblColumn3, dblColumn4, dGrid.CurrentRow.Index, dblColumn6, 0)
                End If
            Else
                ComputeValues(dblColumn3, dblColumn4, dGrid.CurrentRow.Index, dblColumn6, CommonLibrary.Commons.dblSalesTaxRate)
            End If

            dGrid.CurrentRow.Cells(4).Value = Format(dblColumn4, "##0.00")
        End If
        ComputeTotals()
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

    Private Sub AlternateColors()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim backColor As Color = Color.White
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
            Next
        Next
        For i As Integer = 0 To dGrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
                dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub frmCreditNoteEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim gwt_comm As CommonLibrary.Commons.CommonFunctions
        LoadData()
        LoadAccountHolders()
        If boolLoadedFromCustomerForm = True Then
            cboAccountDetails.Text = strSelectedAccountName
            lblAccountNumber.Text = strSelectedAccount
            cboAccountDetails.Enabled = False
            btnSearchAccountHolder.Enabled = False
        End If
        If boolEditStatusTwo = True Then
            LoadPriorData()
            dGrid.Rows.Add(100 - dGrid.Rows.Count)
        Else
            dGrid.Rows.Add(100)
            gwt_comm = New CommonLibrary.Commons.CommonFunctions
            lblDocumentNumber.Text = gwt_comm.GetNextDocumentNumber("CreditNotes")
            CurrentActiveCreditNote = CDbl(lblDocumentNumber.Text)
        End If
        AlternateColors()

        If boolCreditNoteCalledFromProjectClaims = True Then
            cboAccountDetails.Text = strPublicItemDescription
            lblAccountNumber.Text = strPublicItemCode
            btnSearchAccountHolder.Enabled = False
            cboAccountDetails.Enabled = False
            lblAccountNumber.Enabled = False
        End If

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

        If e.ColumnIndex = 2 Then

            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(0).Value), "") Then

                Dim objCommand As Data.OleDb.OleDbCommand
                Dim objReader As Data.OleDb.OleDbDataReader
                Dim strActiveTableName As String = "SerialNumbers"

                If boolDeliverySale = True Then
                    strActiveTableName = "CustomerDeliveries"
                End If

                objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumber FROM " & strActiveTableName & " " _
                    & "WHERE ItemCode = '" & dGrid.CurrentRow.Cells(0).Value.ToString & "' ORDER BY SerialNumber", cnn)
                objReader = objCommand.ExecuteReader

                With cboSerials
                    .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
                    .ColumnNum = 1
                    .HighlightBorderOnMouseEvents = True
                    .ManagingFastMouseMoving = True
                    .Enabled = True
                    .DropDownHeight = 110
                    .GridLineHorizontal = True
                    .GridLineVertical = True
                    .ColumnWidth = "180"

                    'Get a count of the items
                    Dim intItemsCount As Integer = 0
                    Dim sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(SerialNumber) FROM " & strActiveTableName & " " _
                        & "WHERE ItemCode = '" & dGrid.CurrentRow.Cells(0).Value.ToString & "'", cnn)
                    Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
                    If objCount.HasRows Then
                        objCount.Read()
                        If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
                    End If
                    objCount.Close()

                    Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

                    .Items.Clear()
                    Dim i As Integer = 0
                    Dim p As Integer = 0

                    'Continue to read until you reach the end of the file.
                    While objReader.Read
                        DropDownItems(p) = New MTGCComboBoxItem(objReader(0))
                        p = p + 1
                    End While
                    objReader.Close()

                    'Check and remove any serial numbers that may have been selected currents

                    If intItemsCount > 0 Then
                        .SelectedIndex = -1
                        .Items.Clear()
                        .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                        .Items.AddRange(DropDownItems)
                    End If

                    .Size = dGrid.CurrentCell.Size
                    .Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top
                    .Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left
                    If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                        .Text = Convert.ToString(dGrid.CurrentCell.Value)
                    Else
                        .Text = ""
                    End If
                    .Visible = True '152
                    .Focus()
                    .SelectAll()

                End With
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item code search"
        ShowErrorMessage()
    End Sub

    Private Sub cboSerials_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSerials.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(3)
            dGrid.Focus()
        End If
    End Sub

    Private Sub cboSerials_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSerials.SelectedIndexChanged
        If cboSerials.Focused = False Then Exit Sub
        If Not cboSerials.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(2).Value = cboSerials.SelectedItem.Col1
        Else
            dGrid.CurrentRow.Cells(2).Value = Nothing
        End If
    End Sub

    Private Sub cboSerials_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSerials.LostFocus
        cboSerials.Visible = False
    End Sub

    Private Sub LoadPriorData()
        On Error GoTo RaiseErr
        'Entry Type, Ref, Item Code, Description, Item Type, Qty, Unit Price, Tax, Line Total
        lblDocumentNumber.Text = intSelectedTransaction
        Dim strSql As String = Nothing
        If UCase(CommonLibrary.Commons.strTaxComputationType) = "INCLUSIVE" Then
            strSql = "SELECT CreditNoteEntries.ItemCode, " _
                & "CreditNoteEntries.Description, '', (CreditNoteEntries.UnitPrice - (CreditNoteEntries.Taxes / CreditNoteEntries.Quantity)), CreditNoteEntries.Quantity, " _
                & "((CreditNoteEntries.UnitPrice - (CreditNoteEntries.Taxes / CreditNoteEntries.Quantity)) * CreditNoteEntries.Quantity) AS [SubTotal], " _
                & "(CreditNoteEntries.Quantity * 0) AS [Discount], CreditNoteEntries.Taxes, " _
                & "(((CreditNoteEntries.UnitPrice - (CreditNoteEntries.Taxes / CreditNoteEntries.Quantity)) * CreditNoteEntries.Quantity ) + CreditNoteEntries.Taxes ) AS [LineTotal], " _
                & "CreditNoteEntries.LineType, (CreditNoteEntries.Quantity * 0) as [SerialTid] FROM " _
                & "CreditNoteEntries WHERE NoteNumber = " & intSelectedTransaction & ""
        Else
            strSql = "SELECT CreditNoteEntries.ItemCode, " _
                & "CreditNoteEntries.Description, '', CreditNoteEntries.UnitPrice, CreditNoteEntries.Quantity, " _
                & "(CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity) AS [SubTotal], " _
                & "(CreditNoteEntries.Quantity * 0) AS [Discount], CreditNoteEntries.Taxes, " _
                & "((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity ) + CreditNoteEntries.Taxes ) AS [LineTotal], " _
                & "CreditNoteEntries.LineType, (CreditNoteEntries.Quantity * 0) as [SerialTid] FROM " _
                & "CreditNoteEntries WHERE NoteNumber = " & intSelectedTransaction & ""
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            With dGrid
                .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), _
                    objReader(5), objReader(6), objReader(7), objReader(8), objReader(9), objReader(10))
            End With
        End While
        objReader.Close()

        'Get the customer name and account number
        objCommand = New Data.OleDb.OleDbCommand("SELECT CreditNotesMain.AccountId, Customers.AccountName, TransDate " _
            & "FROM CreditNotesMain, Customers WHERE CreditNotesMain.AccountId = Customers.AccountNumber " _
            & "AND NoteNumber = " & intSelectedTransaction & "", cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(1).ToString) Then cboAccountDetails.Text = objReader(1).ToString
            If Not IsDBNull(objReader(0).ToString) Then lblAccountNumber.Text = objReader(0).ToString
            If IsDate(objReader(2).ToString) Then dpDate.Value = CDate(objReader(2).ToString)
        End If
        objReader.Close()
        cboAccountDetails.Enabled = False
        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Credit Note Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals()
        If dGrid.Rows.Count = 0 Then Exit Sub
        Dim dblSubTotal As Double = 0
        Dim dblTaxesTotal As Double = 0
        Dim dblDiscountTotals As Double = 0
        Dim dblTotalPayable As Double = 0
        For n As Double = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(5).Value), "")) Then
                dblSubTotal = dblSubTotal + CDbl(dGrid.Rows(n).Cells(5).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(7).Value), "")) Then
                dblTaxesTotal = dblTaxesTotal + CDbl(dGrid.Rows(n).Cells(7).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(6).Value), "")) Then
                dblDiscountTotals = dblDiscountTotals + CDbl(dGrid.Rows(n).Cells(6).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(8).Value), "")) Then
                dblTotalPayable = dblTotalPayable + CDbl(dGrid.Rows(n).Cells(8).Value.ToString)
            End If
        Next
        lblSubTotal.Text = Format(dblSubTotal, "#,##0.00")

        If UCase(CommonLibrary.Commons.strTaxComputationType) = "INCLUSIVE" Then
            lblTaxable.Text = Format(((dblSubTotal - dblDiscountTotals) - dblTaxesTotal), "#,##0.00")
        Else
            lblTaxable.Text = Format(((dblSubTotal - dblDiscountTotals) + 0), "#,##0.00")
        End If
        lblTaxes.Text = Format(dblTaxesTotal, "#,##0.00")
        lblDiscounts.Text = Format(dblDiscountTotals, "#,##0.00")
        lblPayable.Text = Format(dblTotalPayable, "#,##0.00")
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
        Dim objCommand As Data.OleDb.OleDbCommand
        If String.IsNullOrEmpty(lblAccountNumber.Text) Then
            MessageBox.Show("Please select a valid account number", "Invalid Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccountDetails.Focus()
            Exit Sub
        End If
        If Not IsNumeric(lblPayable.Text) Then
            MessageBox.Show("Invalid transaction totals", "Invalid Total", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If Not IsNumeric(txtReference.Text) Then
            MessageBox.Show("Invalid source invoice number", "Invalid Source Invoice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtReference.Focus()
            Exit Sub
        End If
        If Not IsNumeric(lblInvoiceNumber.Text) Then
            MessageBox.Show("Invalid source invoice number", "Invalid Source Invoice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtReference.Focus()
            Exit Sub
        End If
        'Check that there are entries in the grid
        Dim intNumberOfEntries As Integer = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                intNumberOfEntries = intNumberOfEntries + 1
            End If
        Next

        If intNumberOfEntries = 0 Then
            MessageBox.Show("No entries have been made. Process will be aborted", "No Entries", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim strTransactionDate As String = CStr(Format(dpDate.Value, "dd-MMM-yyyy"))

        Dim intSpecialKey As Integer = gwt_comm.SpecialKey()

        If boolEditStatusTwo = True Then
            'Delete the records in the main and detailed entries
            strSql = "DELETE FROM CreditNoteEntries WHERE NoteNumber = " & CInt(lblDocumentNumber.Text)
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            strSql = "DELETE FROM CreditNotesMain WHERE NoteNumber = " & CInt(lblDocumentNumber.Text)
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        'If boolEditStatusTwo = False Then
        Dim intDocNumber As Long = gwt_comm.GetNextDocumentNumber("CreditNotes")
        lblDocumentNumber.Text = CStr(intDocNumber)
        strSql = "INSERT INTO CreditNotesMain ([NoteNumber], [AccountId], [TransTotal], [UserName], " _
            & "[Notes], [TransDate], [SpecialKey]) VALUES " _
            & "(" & CInt(lblDocumentNumber.Text) & ", '" & lblAccountNumber.Text & "', " & CDbl(lblPayable.Text) & ", " _
            & "'" & strUserName & "', '" & txtNotes.Text & "', '" & strTransactionDate & "', " & intSpecialKey & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Immediately update the credit note numbers
        objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET CreditNotes = " & lblDocumentNumber.Text & "", cnn)
        objCommand.ExecuteNonQuery()

        'Enter the individual line entries
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                'NoteNumber, LineType, Reference, ItemCode, Description, Quantity, UnitPrice, TransactionDate
                Dim strLineType As String = dGrid.Rows(i).Cells(0).Value.ToString
                Dim strReference As String = "0"
                Dim strItemCode As String = Nothing
                Dim strDescription As String = Nothing
                Dim intQuantity As Integer = 0
                Dim dblUnitPrice As Double = 0
                dblTaxes = 0

                'If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                '    strReference = dGrid.Rows(i).Cells(1).Value.ToString
                'End If
                strReference = txtReference.Text
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    strItemCode = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                    If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                        intQuantity = Convert.ToDouble(dGrid.Rows(i).Cells(4).Value)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                    If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                        dblUnitPrice = Convert.ToDouble(dGrid.Rows(i).Cells(3).Value)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "")) Then
                    If IsNumeric(dGrid.Rows(i).Cells(7).Value.ToString) Then
                        dblTaxes = Convert.ToDouble(dGrid.Rows(i).Cells(7).Value)
                    End If
                End If

                'dGrid.Rows(i).Cells(5).Value = Format((intQuantity * dblUnitPrice), "##0.00")

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                    strDescription = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
                End If

                strSql = "INSERT INTO CreditNoteEntries (NoteNumber, LineType, Reference, ItemCode, " _
                    & "Description, Quantity, UnitPrice, Taxes, SpecialKey) VALUES (" & CInt(lblDocumentNumber.Text) & ", " _
                    & "'" & strLineType & "', " & strReference & ", '" & strItemCode & "', '" & strDescription & "', " _
                    & "" & intQuantity & ", " & dblUnitPrice & ", " & dblTaxes & ", " & intSpecialKey & ")"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next

        'Adjust the sales ledger control and the debtors control account balances

        Dim strProcessStatus As String = "SUCCESS"

        If boolEditStatusTwo = False Then
            strProcessStatus = gwt_comm.LedgerEntry("INSERT", CStr(Format(dpDate.Value, "dd-MMM-yyyy")), CommonLibrary.Commons.strPublicSalesAccount, _
                CommonLibrary.Commons.strPublicDebtorsAccount, "CREDIT NOTE " & txtNotes.Text, CDbl(lblPayable.Text), "DEBIT", lblAccountNumber.Text, _
                , , , , CLng(lblDocumentNumber.Text), 0)
            If strProcessStatus <> "SUCCESS" Then
                MessageBox.Show(strProcessStatus, "Ledger Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'Credit the debtors control account with the adjustment
            strProcessStatus = gwt_comm.LedgerEntry("INSERT", CStr(Format(dpDate.Value, "dd-MMM-yyyy")), CommonLibrary.Commons.strPublicDebtorsAccount, _
                CommonLibrary.Commons.strPublicSalesAccount, "CREDIT NOTE " & txtNotes.Text, CDbl(lblTaxable.Text), "CREDIT", lblAccountNumber.Text, _
                , , , , CLng(lblDocumentNumber.Text), 0)
            If strProcessStatus <> "SUCCESS" Then
                MessageBox.Show(strProcessStatus, "Ledger Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'If there is a tax amount, then post the tax element against the taxes account
            If IsNumeric(lblTaxes.Text) Then
                If CDbl(lblTaxes.Text) > 0 Then
                    If String.IsNullOrEmpty(CommonLibrary.Commons.strPublicTaxesAccount) Then
                        MessageBox.Show("The taxes control account has not been setup. This will seriously affect the trial balance", _
                            "Taxes Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        strProcessStatus = gwt_comm.LedgerEntry("INSERT", CStr(Format(dpDate.Value, "dd-MMM-yyyy")), CommonLibrary.Commons.strPublicTaxesAccount, _
                            lblAccountNumber.Text, "CREDIT NOTE-" & UCase(cboAccountDetails.Text), CDbl(lblTaxes.Text), "DEBIT", _
                            txtReference.Text, , , , 0, 0, lblDocumentNumber.Text, 0)
                        If strProcessStatus <> "SUCCESS" Then GoTo RaiseErr
                    End If
                End If
            End If

        Else

        End If

        'SalesLedgerControl(-DateAndTime - DebtorsControl - Adjustment)

        If MessageBox.Show("Credit note saved successfully. Do you want to print the credit note right now?", _
            "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information) = MsgBoxResult.Yes Then
            PrintCreditNote()
        End If

        If boolEditStatusTwo = True Then
            Me.Close()
        Else
            dGrid.Rows.Clear()
            dGrid.Rows.Add(100)
            lblAccountNumber.Text = ""
            lblDocumentNumber.Text = ""
            lblPayable.Text = "0.00"
            lblSubTotal.Text = "0.00"
            lblDiscounts.Text = "0.00"
            lblSubTotal.Text = "0.00"
            lblTaxes.Text = "0.00"
            Me.Close()
        End If
        If boolLoadedFromCustomerForm = True Then
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On credit not save"
        ShowErrorMessage()
    End Sub

    Private Sub PrintCreditNote()
        On Error GoTo RaiseErr
        boolPrinterAlreadySelected = False
        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
        gwt_comm.PrintCustomerDocument(CDbl(lblDocumentNumber.Text), "CREDIT NOTE")
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Credit Note Transaction Processing"
        ShowErrorMessage()
    End Sub

    '' '' '' '' '' '' '' *****************************************************************************************

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
        RecalculateAmount()
        If Not cboItems.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(0).Value = cboItems.SelectedItem.Col1
            dGrid.CurrentRow.Cells(1).Value = cboItems.SelectedItem.Col2
            dGrid.CurrentRow.Cells(3).Value = cboItems.SelectedItem.Col3
            dGrid.CurrentRow.Cells(4).Value = "1"
            dGrid.CurrentRow.Cells(6).Value = "0"

            'Get the item type
            dGrid.CurrentRow.Cells(5).ReadOnly = False
            Dim strCodeSelected As String = dGrid.CurrentRow.Cells(0).Value.ToString
            Dim dblSalePrice As Double = 0
            objCommand = New Data.OleDb.OleDbCommand("SELECT InventoryType, SellingPrice FROM InventoryItems " _
                & "WHERE ItemCode = '" & strCodeSelected & "'", cnn)
            Dim objReadType As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadType.HasRows Then
                objReadType.Read()
                If Not IsDBNull(objReadType(0).ToString) Then
                    If UCase(objReadType(0).ToString) = "SPECIFIC" Then
                        dGrid.CurrentRow.Cells(5).ReadOnly = True
                    End If
                End If
                If IsNumeric(objReadType(1).ToString) Then dblSalePrice = CDbl(objReadType(1).ToString)
            End If
            objReadType.Close()

            'Apply the discount
            Dim dblDiscounts() As Double = gwt_comm.ItemOnSpecials(strCodeSelected, dblSalePrice)
            dGrid.CurrentRow.Cells(6).Value = CStr(Format((dblDiscounts(1) * CDbl(dGrid.CurrentRow.Cells(4).Value.ToString)), "##0.00"))

            ComputeValues(CDbl(dGrid.CurrentRow.Cells(3).Value.ToString), CDbl(dGrid.CurrentRow.Cells(4).Value.ToString), _
                dGrid.CurrentRow.Index, CDbl(dGrid.CurrentRow.Cells(6).Value.ToString), CommonLibrary.Commons.dblSalesTaxRate)
        Else
            dGrid.CurrentRow.Cells(0).Value = Nothing
            dGrid.CurrentRow.Cells(1).Value = Nothing
            dGrid.CurrentRow.Cells(3).Value = Nothing
            dGrid.CurrentRow.Cells(4).Value = Nothing
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On discount computation"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeValues(ByVal dblUnitPrice As Double, ByVal intQuantity As Double, _
        ByVal intRowIndex As Double, _
        Optional ByVal dblDiscount As Double = 0, Optional ByVal dblTaxRate As Double = 0)
        Dim dblTaxes As Double = 0
        Dim dblSubTotal As Double = 0
        Dim dblPayable As Double = 0

        'Compute the sub total
        dblSubTotal = dblUnitPrice * intQuantity
        dGrid.Rows(intRowIndex).Cells(5).Value = Format(dblSubTotal, "##0.00")

        'Compute the tax payable
        If UCase(CommonLibrary.Commons.strTaxComputationType) = "INCLUSIVE" Then
            dblTaxes = ((dblUnitPrice * intQuantity) - dblDiscount) - (((dblUnitPrice * intQuantity) - dblDiscount) * (100 / (100 + dblTaxRate)))
        Else
            dblTaxes = (dblSubTotal - dblDiscount) * (dblTaxRate / 100) 'dblTaxRate
        End If


        If UCase(CommonLibrary.Commons.strTaxComputationType) = "EXCLUSIVE" Then
            dblPayable = (dblSubTotal - dblDiscount) + dblTaxes
        Else
            dblPayable = (dblSubTotal - dblDiscount)
        End If

        dGrid.Rows(intRowIndex).Cells(7).Value = Format(dblTaxes, "##0.00")
        dGrid.Rows(intRowIndex).Cells(8).Value = Format(dblPayable, "##0.00")

        RecalculateAmount()
        ComputeTotals()

    End Sub

    Private Sub RecalculateAmount()
        Dim dblMovingTotal As Double = 0
        Dim dblSubs As Double = 0
        Dim dblTxs As Double = 0
        Dim dblDis As Double = 0
        For i As Double = 0 To dGrid.Rows.Count - 1
            Dim strValue As String = "0"
            Dim strValTx As String = "0"
            Dim strValDis As String = "0"
            Dim strValSubs As String = "0"
            Dim dblQuantity As Double = 0
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    dblQuantity = CDbl(dGrid.Rows(i).Cells(3).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(8).Value), "")) Then
                strValue = Convert.ToString(dGrid.Rows(i).Cells(8).Value)
                If IsNumeric(strValue) Then
                    dblMovingTotal = dblMovingTotal + CDbl(strValue)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "")) Then
                strValTx = Convert.ToString(dGrid.Rows(i).Cells(7).Value)
                If IsNumeric(strValTx) Then
                    dblTxs = dblTxs + CDbl(strValTx)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(6).Value), "")) Then
                strValDis = Convert.ToString(dGrid.Rows(i).Cells(6).Value)
                If IsNumeric(strValDis) Then
                    dblDis = dblDis + CDbl(strValDis)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                strValSubs = Convert.ToString(dGrid.Rows(i).Cells(5).Value)
                If IsNumeric(strValSubs) Then
                    dblSubs = dblSubs + CDbl(strValSubs)
                End If
            End If

        Next
        lblPayable.Text = Format(dblMovingTotal, "#,##0.00")
        lblSubTotal.Text = Format(dblSubs, "#,##0.00")
        lblDiscounts.Text = Format(dblDis, "#,##0.00")
        lblTaxes.Text = Format(dblTxs, "#,##0.00")
    End Sub

    Private Sub cboItems_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.Validated
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(cboItems.Text) Then Exit Sub
        If UCase(cboItems.Text) = "--- COMMENT ---" Or UCase(cboItems.Text) = "--- SERVICE ---" Then
            Exit Sub
        End If
        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM InventoryItems WHERE ItemCode = '" & cboItems.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows = False Then
            dGrid.CurrentRow.Cells(0).Value = Nothing
            dGrid.CurrentRow.Cells(1).Value = Nothing
            dGrid.CurrentRow.Cells(3).Value = Nothing
            dGrid.CurrentRow.Cells(4).Value = Nothing
            dGrid.CurrentRow.Cells(5).Value = Nothing
            dGrid.CurrentRow.Cells(6).Value = Nothing
            dGrid.CurrentRow.Cells(7).Value = Nothing
            dGrid.CurrentRow.Cells(8).Value = Nothing
        Else
            'Get the item type
            objReader.Read()
            If Not IsDBNull(objReader("InventoryType").ToString) Then dGrid.CurrentRow.Cells(9).Value = objReader("InventoryType").ToString
            'Load the serial numbers
            objCommand = New Data.OleDb.OleDbCommand("SELECT SerialNumber FROM SerialNumbers WHERE ItemCode = '" & cboItems.Text & "'", cnn)
            Dim objReadSerial As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            objCommand = New Data.OleDb.OleDbCommand("SELECT Category, SellingPrice FROM InventoryItems WHERE ItemCode = '" & cboItems.Text & "'", cnn)
            Dim objReadCategory As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadCategory.HasRows Then
                objReadCategory.Read()
                If Not IsDBNull(objReadCategory(0).ToString) Then
                    If UCase(objReadCategory(0).ToString) = "CELLPHONES" Then
                        If CDbl(objReadCategory(1).ToString) >= 100 And CDbl(objReadCategory(1).ToString) < 600 Then
                            dGrid.CurrentRow.Cells(6).Value = gwt_comm.RoundDown(objReadCategory(1) * 0.05)
                        End If
                        If CDbl(objReadCategory(1).ToString) >= 600 Then
                            dGrid.CurrentRow.Cells(6).Value = gwt_comm.RoundDown(objReadCategory(1) * 0.1)
                        End If
                    End If
                End If
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Sales Entry"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
        Dim strSalesData() As String = gwt_comm.SalesInventoryItems(CommonLibrary.Commons.strMainCompanyServiceOffering, CommonLibrary.Commons.strDefaultSearchFilter)
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSalesData(0), cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 4
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "160;180;60;60"
        End With
        'Get a count of the items
        Dim intItemsCount As Double = CDbl(strSalesData(1))

        Dim DropDownItems(intItemsCount + 1) As MTGCComboBoxItem

        cboItems.Items.Clear()
        Dim i As Double = 0
        Dim p As Double = 0

        'Add extra 1st lines for comment
        DropDownItems(p) = New MTGCComboBoxItem("--- COMMENT ---", "", "0.00", "NO")
        p += 1
        DropDownItems(p) = New MTGCComboBoxItem("--- SERVICE ---", "", "0.00", "NO")
        p += 1
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2), strRecordText(3))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboItems.SelectedIndex = -1
            cboItems.Items.Clear()
            cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboItems.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadAccountHolders()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber FROM Customers ORDER BY AccountName"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboAccountDetails
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "220;" & CStr(.Width - 220)
        End With
        'Get a count of the items
        Dim intItemsCount As Double = 0

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM Customers", cnn)

        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboAccountDetails.Items.Clear()
        Dim i As Double = 0
        Dim p As Double = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        With cboAccountDetails
            If intItemsCount > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Account Holder Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboAccountDetails_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountDetails.SelectedIndexChanged
        On Error Resume Next
        lblAccountNumber.Text = Nothing
        lblAccountNumber.Text = cboAccountDetails.SelectedItem.Col2
        LoadSelectedClientInvoices(lblAccountNumber.Text)
    End Sub

    Private Sub btnSearchAccountHolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAccountHolder.Click
        strPublicItemCode = Nothing
        strPublicItemDescription = Nothing
        boolAbort = False
        Dim f As New frmBrowseDebtors
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        lblAccountNumber.Text = strPublicItemCode
        cboAccountDetails.Text = strPublicItemDescription
    End Sub

    Private Sub LoadSelectedClientInvoices(ByVal AccountNumber As String)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        If UCase(CommonLibrary.Commons.strTaxComputationType) = "INCLUSIVE" Then
            strSql = "SELECT InvoiceNumber, UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date], " _
                & "CAST(SUM((SalesPrice * Quantity) - DiscountAllowed) AS DECIMAL (10,2)) as [Paid] " _
                & "FROM CustomerSales WHERE CustomerId = '" & AccountNumber & "' " _
                & "GROUP BY TransDate, InvoiceNumber ORDER BY InvoiceNumber, TransDate"
        Else
            strSql = "SELECT  InvoiceNumber, UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date], " _
                & "CAST(SUM((SalesPrice * Quantity) - DiscountAllowed + Taxes) AS DECIMAL (10,2)) as [Paid] " _
                & "FROM CustomerSales WHERE CustomerId = '" & AccountNumber & "' " _
                & "GROUP BY TransDate, InvoiceNumber ORDER BY InvoiceNumber, Transdate"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        'Set up the drop down combo box
        With txtReference
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 3
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "120;100;100"
        End With

        Dim arrDetails As New ArrayList
        While objReader.Read
            arrDetails.Add(objReader(0) & ";" & objReader(1) & ";" & objReader(2))
        End While
        objReader.Close()

        'Get a count of the items
        Dim intItemsCount As Double = arrDetails.Count

        Dim DropDownItems(0 To (intItemsCount - 1)) As MTGCComboBoxItem

        txtReference.Items.Clear()

        'Continue to read until you reach the end of the file.
        For i As Integer = 0 To arrDetails.Count - 1
            Dim strRecordText() As String = Split(arrDetails.Item(i), ";")
            DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2))
        Next

        With txtReference
            If intItemsCount > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On selected client invoices load"
        ShowErrorMessage()
    End Sub

    Private Sub txtReference_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReference.SelectedIndexChanged
        lblInvoiceNumber.Text = Nothing
        lblInvoiceNumber.Text = txtReference.SelectedItem.Col1
    End Sub

End Class
