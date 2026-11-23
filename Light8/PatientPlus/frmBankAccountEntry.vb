Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBankAccountEntry

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(cboBankCodes.Text) Then
            MessageBox.Show("Invalid Bank Code", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboBankCodes.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblId.Text) Then
            MessageBox.Show("Invalid Bank Code", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboBankCodes.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtBankName.Text) Then
            MessageBox.Show("Invalid Bank Name", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBankName.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountName.Text) Then
            MessageBox.Show("Invalid Account Name", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountName.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountNumber.Text) Then
            MessageBox.Show("Invalid Account Number", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNumber.Select()
            Exit Sub
        End If

        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = True Then
            strSql = "DELETE FROM SystemCoyBanks WHERE SystemCoyBanks.TransactionId = " & lblId.Text & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        strSql = "INSERT INTO SystemCoyBanks (BankCode, AccountName, AccountNumber, AccountType) VALUES " _
            & "('" & cboBankCodes.Text & "', '" & txtAccountName.Text & "', '" & txtAccountNumber.Text & "', " _
            & "'" & cboAccountType.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        gwt_comm.AssignDefaults()
        gwt_comm.AssignCompanyDetails()

        MessageBox.Show("Company bank details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        boolAbort = False
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Company Bank Details Setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmBankAccountEntry_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetBankFileDetails()
        If boolEditStatus = True Then
            LoadSelectedBank()
        End If
    End Sub

    Private Sub LoadSelectedBank()
        On Error GoTo RaiseErr
        lblId.Text = intSelectedTransaction
        Dim strSql As String = "SELECT * FROM SystemCoyBanks WHERE TransactionId = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("BankCode").ToString) Then cboBankCodes.Text = objReader("BankCode").ToString
            txtBankName.Text = BankName(cboBankCodes.Text)
            If Not IsDBNull(objReader("AccountName").ToString) Then txtAccountName.Text = objReader("AccountName").ToString
            If Not IsDBNull(objReader("AccountNumber").ToString) Then txtAccountNumber.Text = objReader("AccountNumber").ToString
            If Not IsDBNull(objReader("AccountType").ToString) Then cboAccountType.Text = objReader("AccountType").ToString
            If Not IsDBNull(objReader("Status").ToString) Then cboStatus.Text = objReader("Status").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Company Bank Details Setup"
        ShowErrorMessage()
    End Sub

    Private Function BankName(ByVal BankCode As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT BankName FROM SystemBanks WHERE BankCode = '" & BankCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                strReturn = objReader(0).ToString
            End If
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Company Bank Details Setup"
        ShowErrorMessage()
    End Function

    Private Sub GetBankFileDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT BankCode +';'+BankName AS [Banking] FROM SystemBanks ORDER BY BankName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboBankCodes
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "60;250"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(BankCode) FROM SystemBanks", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboBankCodes.Items.Clear()
        Dim i As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            i = i + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboBankCodes.SelectedIndex = -1
            cboBankCodes.Items.Clear()
            cboBankCodes.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboBankCodes.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Bank Information Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboBankCodes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBankCodes.SelectedIndexChanged
        If cboBankCodes.Focused = False Then Exit Sub
        If Not cboBankCodes.SelectedItem Is Nothing Then
            txtBankName.Text = cboBankCodes.SelectedItem.Col2
            lblId.Text = cboBankCodes.SelectedItem.Col1
        Else
            txtBankName.Text = Nothing
            lblId.Text = "0"
        End If
    End Sub

    Private Sub btnAddBank_Click(sender As System.Object, e As System.EventArgs) Handles btnAddBank.Click
        Dim frm As New frmAddBank
        frm.ShowDialog()
        GetBankFileDetails()
    End Sub

End Class
