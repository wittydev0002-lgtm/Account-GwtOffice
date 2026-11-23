Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLedgerAccountCodeChange

    Private Sub frmLedgerAccountCodeChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AccountNumber +';'+AccountName AS [Items] FROM LedgerAccounts"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "120;240"
        End With
        'Get a count of the items
        Dim intItemsCount As Double = 0

        strSql = "SELECT Count(AccountNumber) FROM LedgerAccounts"

        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboItems.Items.Clear()
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
        If intItemsCount > 0 Then
            cboItems.SelectedIndex = -1
            cboItems.Items.Clear()
            cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboItems.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtNewCode.Text) Then
            MessageBox.Show("Please enter the new ledger account code", "Missing New Ledger Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNewCode.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboItems.Text) Or String.IsNullOrEmpty(lblDescription.Text) Then
            MessageBox.Show("Please enter the old ledger account code", "Missing Old Ledger Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboItems.Focus()
            Exit Sub
        End If

        ProgressBar1.Value = 0 : ProgressBar1.Maximum = 10
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        'Check that the code does not exist before changing
        objCommand = New Data.OleDb.OleDbCommand("SELECT AccountNumber FROM LedgerAccounts WHERE AccountNumber = '" & txtNewCode.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            MessageBox.Show("The new account number already exists. This process will be aborted", "Duplicate Account Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
            objReader.Close()
            Exit Sub
        Else
            objReader.Close()
        End If

        strSql = "UPDATE LedgerAccounts SET AccountNumber = '" & txtNewCode.Text & "' WHERE AccountNumber = '" & cboItems.Text & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        ProgressBar1.Value = ProgressBar1.Value + 1

        strSql = "UPDATE CashbookTransactions SET ContraAccount = '" & txtNewCode.Text & "' WHERE ContraAccount = '" & cboItems.Text & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        ProgressBar1.Value = ProgressBar1.Value + 1

        strSql = "UPDATE JournalEntries SET DebitAccount = '" & txtNewCode.Text & "' WHERE DebitAccount = '" & cboItems.Text & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        ProgressBar1.Value = ProgressBar1.Value + 1
        strSql = "UPDATE JournalEntries SET CreditAccount = '" & txtNewCode.Text & "' WHERE CreditAccount = '" & cboItems.Text & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        ProgressBar1.Value = ProgressBar1.Value + 1

        strSql = "UPDATE LedgerTransactions SET ContraAccount = '" & txtNewCode.Text & "' WHERE ContraAccount = '" & cboItems.Text & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        ProgressBar1.Value = ProgressBar1.Value + 1
        strSql = "UPDATE LedgerTransactions SET AccountNumber = '" & txtNewCode.Text & "' WHERE AccountNumber = '" & cboItems.Text & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        ProgressBar1.Value = ProgressBar1.Value + 1

        ProgressBar1.Value = ProgressBar1.Maximum

        MessageBox.Show("Ledger code successfully changed in the entire system", "Ledger Code Change Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtNewCode.Clear()
        cboItems.Text = ""
        cboItems.Focus()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Details Change"
        ShowErrorMessage()
    End Sub

    Private Sub cboItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItems.SelectedIndexChanged
        On Error Resume Next
        lblDescription.Text = ""
        lblDescription.Text = cboItems.SelectedItem.Col2
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtNewCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNewCode.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
    End Sub

    Private Sub btnAdvanced_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdvanced.Click
        Dim f As New frmAdvancedLedgerAccountChanges
        f.ShowDialog()
    End Sub

End Class
