Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons

Public Class frmLegalPaymentsUpdate
    Private Sub btnCAncel_Click(sender As Object, e As EventArgs) Handles btnCAncel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmLegalPaymentsUpdate_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        cboAccountHolder.Text = strSelectedAccountName
        txtAccountNumber.Text = strSelectedAccount
        cboAccountHolder.Enabled = False
        txtFileNumber.Enabled = False
        LoadFileNumber()
        AddDescriptions()
        LoadPaymentInitiators()
        dGrid.Rows.Add(10)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Payments Update"
        ShowErrorMessage()
    End Sub

    Private Sub LoadFileNumber()
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtAccountNumber.Text) Then Exit Sub
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT FileID FROM Defendants " _
            & "WHERE DefendantId = '" & txtAccountNumber.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtFileNumber.Text = objReader(0).ToString.ToUpper
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Payments Update"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim arrSaveData As New ArrayList
        If String.IsNullOrEmpty(dpDateOn.Text) Then
            MessageBox.Show("Please enter a date for the transaction", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dpDateOn.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtManualReceiptNumber.Text) Then
            MessageBox.Show("Please enter the manual receipt number", "Missing Manual Receipt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtManualReceiptNumber.Focus()
            Exit Sub
        End If

        If Not IsDate(dpDateOn.Value) Then
            MessageBox.Show("Please enter a date for the transaction", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dpDateOn.Focus()
            Exit Sub
        End If
        Dim strTransDate As String = Format(dpDateOn.Value, "dd-MMM-yyyy")

        For i As Integer = 0 To dGrid.RowCount - 1
            Dim dblAmount As Double = 0
            Dim strReason As String = Nothing
            Dim strReference As String = Nothing
            Dim strComment As String = Nothing
            If Not Object.Equals(dGrid.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(0).Value.ToString) Then
                    strReason = dGrid.Rows(i).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(1).Value.ToString) Then
                        dblAmount = CDbl(dGrid.Rows(i).Cells(1).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    strReference = dGrid.Rows(i).Cells(2).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    strComment = dGrid.Rows(i).Cells(3).Value.ToString
                End If
            End If
            If dblAmount <> 0 Then
                If String.IsNullOrEmpty(strReason) Then
                    MessageBox.Show("Row number " & i & " has a value greater or less than 0 but no description", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else
                    arrSaveData.Add(strReason & "|" & dblAmount & "|" & strReference & "|" & strComment)
                End If
            End If
        Next

        Dim arrDefaultAccounts As New ArrayList
        Dim objCommand As Data.OleDb.OleDbCommand

        objCommand = New Data.OleDb.OleDbCommand("SELECT PlaintifId FROM Defendants WHERE DefendantId = '" & txtAccountNumber.Text & "'", cnn)
        Dim objReadId As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReadId.HasRows Then
            objReadId.Read()
            If Not IsDBNull(objReadId(0).ToString) Then strSelectedPlaintifId = objReadId(0).ToString
        End If
        objReadId.Close()

        arrDefaultAccounts = gwt_comm.GetTrustAccount(strSelectedPlaintifId)
        If arrDefaultAccounts.Count < 2 Then
            MessageBox.Show("The default ledger and trust accounts have not been set. Process will not go ahead", "Missing Ledger Accounts", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        strPublicActivePaymentsTrustAccountNumber = arrDefaultAccounts.Item(0).ToString
        strPublicActivePaymentsTrustCashbookAccountNumber = arrDefaultAccounts.Item(1).ToString


        Dim intKey As Integer = gwt_comm.SpecialKey()

        For p As Integer = 0 To arrSaveData.Count - 1
            'Write to the defendant transactions table
            Dim strBuffer() As String = Split(arrSaveData.Item(p), "|")
            InitializeTransactions("DEFENDANTS", txtAccountNumber.Text, Format(CDate(strTransDate), "dd-MMM-yyyy"), 0, CDbl(strBuffer(1)),
                strBuffer(0), strBuffer(3) & " PAYMENT UPDATE BY " & UCase(strUserName), strBuffer(2))

            '**** CREDIT TRUST ACCOUNT ****

            ' ''objCommand = New Data.OleDb.OleDbCommand("INSERT INTO TrustTransactions (TrustAccountNumber, " _
            ' ''            & "TransactionDate, Credit, Description, UserName, UserBranch, Reference, SpecialKey, OwnerAccountNumber, AccountType, FileId) VALUES " _
            ' ''            & "('" & strPublicActivePaymentsTrustAccountNumber & "', '" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', " _
            ' ''            & "" & CDbl(strBuffer(1)) & ", '" & strBuffer(0) & "', '" & strPublicActiveFullUserName & "', " _
            ' ''            & "'" & strUserBranch & "', " & txtManualReceiptNumber.Text & ", " & intKey & ", " _
            ' ''            & "'" & strSelectedPlaintifId & "', 'DEBT COLLECTION', '" & txtFileNumber.Text & "')", cnn)
            ' ''objCommand.ExecuteNonQuery()
        Next

        '' ''**** DEBIT TRUST CASHBOOK ACCOUNT ****
        ' ''Dim strInitiator As String = "Self Initiated"
        ' ''If Not String.IsNullOrEmpty(cboPaymentAfter.Text) Then strInitiator = cboPaymentAfter.Text

        ' ''Dim strCashbookDescription As String = "CASH RECEIPT BY " & UCase(strPublicActiveFullUserName)
        ' ''objCommand = New Data.OleDb.OleDbCommand("INSERT INTO TrustCashbookTransactions (AccountNumber, " _
        ' ''    & "TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, TransactionType, Reference, SpecialKey, Initiator, FileId) VALUES " _
        ' ''    & "('" & strPublicActivePaymentsTrustCashbookAccountNumber & "', '" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', " _
        ' ''    & "" & lblReceivedAmt.Text & ", '" & strCashbookDescription & "', '" & strPublicActivePaymentsTrustAccountNumber & "', " _
        ' ''    & "'" & strPublicActiveFullUserName & "', '" & strUserBranch & "', 'DEBIT', " & Convert.ToDouble(txtManualReceiptNumber.Text) & ", " _
        ' ''    & "" & intKey & ", '" & strInitiator & "', '" & txtFileNumber.Text & "')", cnn)
        ' ''objCommand.ExecuteNonQuery()

        MessageBox.Show("Transaction Update successfully", "Transaction Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Payments Update"
        ShowErrorMessage()
    End Sub

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
        If dGrid.CurrentCell.ColumnIndex = 1 Then

            Dim dblColumn1 As Double = 0

            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(1).Value), "") Then
                If IsNumeric(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                    dblColumn1 = CDbl(dGrid.CurrentRow.Cells(1).Value.ToString)
                End If
            End If
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

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr
        Dim dblInternalTotal As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(i).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(1).Value.ToString) Then
                        dblInternalTotal = dblInternalTotal + CDbl(dGrid.Rows(i).Cells(1).Value.ToString)
                    End If
                End If
            End If
        Next
        lblReceivedAmt.Text = Format(dblInternalTotal, "##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on current total computation"
        ShowErrorMessage()
    End Sub

    '    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter
    '        On Error GoTo RaiseErr

    '        If e.RowIndex < 0 Then Exit Sub
    '        If cboItems.Visible = True Then cboItems.Visible = False
    '        If e.ColumnIndex = 0 Then
    '            cboItems.Size = dGrid.CurrentCell.Size
    '            cboItems.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top
    '            cboItems.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left
    '            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
    '                cboItems.Text = Convert.ToString(dGrid.CurrentCell.Value)
    '            Else
    '                cboItems.Text = ""
    '            End If
    '            cboItems.Visible = True '152
    '            cboItems.Focus()
    '            'cboItems.SelectAll()
    '        End If

    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " " & Err.Number & " on Item code search"
    '        ShowErrorMessage()
    '    End Sub

    Private Sub AddDescriptions()
        On Error GoTo RaiseErr

        dGrid.Columns.Clear()

        Dim cmb As New KryptonDataGridViewComboBoxColumn
        cmb.HeaderText = "Description"
        cmb.Name = "cmb"
        cmb.MaxDropDownItems = 4

        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ReceiptDescription FROM SystemReceiptDescriptions ORDER BY ReceiptDescription", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cmb.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()

        dGrid.Columns.Add(cmb)

        dGrid.Columns.Add("Amt", "Amount")
        dGrid.Columns.Add("Ref", "Reference")
        dGrid.Columns.Add("Cmt", "Comment")

        For i As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            If i = 1 Then
                dGrid.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGrid.Columns(i).DefaultCellStyle.Format = "N2"
            End If
        Next
        With dGrid
            .Columns(0).MinimumWidth = 200
            .Columns(3).MinimumWidth = 150
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Description & vbCrLf & "On receipt descriptions load"
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
        If Not cboItems.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(0).Value = cboItems.SelectedItem.Col1
        Else
            dGrid.CurrentRow.Cells(0).Value = Nothing
            dGrid.CurrentRow.Cells(1).Value = "0.00"
            dGrid.CurrentRow.Cells(2).Value = Nothing
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Text Population"
        ShowErrorMessage()
    End Sub

    Private Sub LoadPaymentInitiators()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT(Initiator) FROM LegalPaymentInitiators", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboPaymentAfter.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboPaymentAfter.Items.Add(objReader(0).ToString)
        End While
        cboPaymentAfter.Sorted = True
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Payment Initiators Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmLegalPaymentsUpdate_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 663 : Me.Height = 486
    End Sub

End Class