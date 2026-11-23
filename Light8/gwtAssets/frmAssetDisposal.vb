Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmAssetDisposal

    Dim boolIsSelected As Boolean

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmAssetDisposal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadAssets()
    End Sub

    Private Sub LoadAssets()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AssetName +';'+ AssetCode AS [Data] " _
            & "FROM Assets ORDER BY AssetName"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Set up the drop down combo box
        Dim intX As Integer = mCboAsset.Width - 85
        With mCboAsset
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intX) & ";80"
            .DropDownHeight = 100
        End With

        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AssetCode) FROM Assets", cnn)

        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = intItemsCount + CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        mCboAsset.Items.Clear()

        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()

        With mCboAsset
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Asset Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub mCboAsset_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCboAsset.SelectedIndexChanged
        lblAssetId.Text = Nothing
        lblAssetId.Text = mCboAsset.SelectedItem.Col2
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(txtCashbook.Text) Then
            MessageBox.Show("Please select the cash book against which to post this transaction", _
                "Invalid Cashbook Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCashbook.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtCostCenter.Text) Then
            MessageBox.Show("Please select the cost center to where this transaction will be posted", _
                "Invalid Cost Center", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCostCenter.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAssetControl.Text) Then
            MessageBox.Show("Please select the ledger account against which to post this transaction", _
                "Invalid Ledger Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAssetControl.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(mCboAsset.Text) Then
            MessageBox.Show("Please select the asset affected", _
                "Invalid Asset Details", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            mCboAsset.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a valid amount for the transaction", _
                "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmount.Focus()
            Exit Sub
        End If
        If CDbl(txtAmount.Text) <= 0 Then
            MessageBox.Show("Please enter an amount greater than zero", _
                "Amount is Zero", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAmount.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtNarration.Text) Then
            MessageBox.Show("Please type in the narration", _
                "Missing Narration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNarration.Focus()
            Exit Sub
        End If

        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        gwt_comm.LedgerEntry("INSERT", dpTransDate.Text, lblLedgerAccount.Text, strPublicActiveCashbook, txtNarration.Text & " - " & mCboAsset.Text, _
                    CDbl(txtAmount.Text), "DEBIT", lblAssetId.Text, , CInt(lblCostCode.Text), 0, 0, 0, 0, 0)
        'LedgerEntry("INSERT", dpTransDate.Text, strPublicCashControlAccount, lblLedgerAccount.Text, txtNarration.Text & " - " & mCboAsset.Text, _
        '    CDbl(txtAmount.Text), "CREDIT", , , CInt(lblCostCode.Text), 0, 0, 0, 0, 0)
        ''Credit the cash account
        Dim strSql As String = "INSERT INTO CashbookTransactions ([TransactionDate],[Amount],[Description],[AccountNumber]," _
            & "[ContraAccount],[UserName],[UserBranch],[Reference],[TransactionType],[FolioReference],[Status],[PaymentMethod]) VALUES " _
            & "('" & dpTransDate.Text & "', " & CDbl(txtAmount.Text) & ", '" & txtNarration.Text & " - " & mCboAsset.Text & "', " _
            & "'" & lblCashbook.Text & "', '" & lblLedgerAccount.Text & "', '" & strUserName & "', " _
            & "'" & strUserBranch & "', 0, 'CREDIT', '" & lblAssetId.Text & "', 'N', 'CASH')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Update the asset table with the values of disposal, disposal date
        strSql = "UPDATE Assets SET DisposalValue " & CDbl(txtAmount.Text) & ", " _
            & "DisposalDate = '" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "' WHERE AssetCode = '" & lblAssetId.Text & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On asset disposal transaction posting"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtCashbook_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCashbook.KeyPress
        boolIsSelected = False
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            lblCashbook.Text = Nothing
            boolAbort = False
            gwt_comm.CashbookSelection()
            If boolAbort = True Then Exit Sub
            boolIsSelected = True
            txtCashbook.Text = strPublicActiveCashbook
            lblCashbook.Text = strPublicActiveCashbookName
            txtAssetControl.Focus()
            txtAssetControl.Select()
        End If
    End Sub

    Private Sub txtCashbook_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCashbook.Validating
        If boolIsSelected = True Then Exit Sub
        If String.IsNullOrEmpty(txtCashbook.Text) Then Exit Sub
        If IsValidCashbook(txtCashbook.Text) = False Then
            MessageBox.Show("The entered cashbook account is not valid", "Invalid Cashbook Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            lblCashbook.Text = Nothing
            txtCashbook.Text = Nothing
            txtCashbook.Focus()
            txtCashbook.SelectAll()
            Exit Sub
        End If
    End Sub

    Private Function IsValidCashbook(ByVal AccountNumber As String) As Boolean
        boolAbort = False
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountName FROM Cashbooks " _
            & "WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            lblCashbook.Text = objReader(0).ToString
            boolReturn = True
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Cashbook Account Validation"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub txtAssetControl_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssetControl.KeyPress
        boolIsSelected = False
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            lblLedgerAccount.Text = Nothing
            boolAbort = False
            gwt_comm.SearchForLedgerAccount()
            If boolAbort = True Then Exit Sub
            boolIsSelected = True
            txtAssetControl.Text = strSelectedAccount
            lblLedgerAccount.Text = strSelectedAccountName
            txtCostCenter.Focus()
            txtCostCenter.Select()
        End If
    End Sub

    Private Function IsValidLedge(ByVal AccountNumber As String) As Boolean
        boolAbort = False
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountName FROM LedgerAccounts " _
            & "WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            lblLedgerAccount.Text = objReader(0).ToString
            boolReturn = True
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Ledger Account Validation"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub txtAssetControl_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAssetControl.Validating
        If boolIsSelected = True Then Exit Sub
        If String.IsNullOrEmpty(txtCostCenter.Text) Then Exit Sub
        If IsValidLedge(txtCostCenter.Text) = False Then
            MessageBox.Show("The entered ledger account is not valid", "Invalid Ledger Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            lblLedgerAccount.Text = Nothing
            txtAssetControl.Text = Nothing
            txtAssetControl.Focus()
            txtAssetControl.SelectAll()
            Exit Sub
        End If
    End Sub

    Private Sub txtCostCenter_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCostCenter.KeyDown
        boolIsSelected = False
        If e.KeyCode = 18 Or e.KeyCode = 8 Then Exit Sub
        If e.KeyCode = 13 Then
            lblCostCode.Text = Nothing
            boolAbort = False
            gwt_comm.CostCenterSearch()
            If boolAbort = True Then Exit Sub
            boolIsSelected = True
            txtCostCenter.Text = strSelectedCode
            lblCostCode.Text = strSelectedCodeDescription
            mCboAsset.Focus()
        End If
    End Sub

    Private Sub txtCostCenter_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCostCenter.Validating
        If boolIsSelected = True Then Exit Sub
        If String.IsNullOrEmpty(txtCostCenter.Text) Then Exit Sub
        If IsValidCostCode(txtCostCenter.Text) = False Then
            MessageBox.Show("The entered ledger account is not valid", "Invalid Ledger Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            lblCostCode.Text = Nothing
            txtCostCenter.Text = Nothing
            txtCostCenter.Focus()
            txtCostCenter.SelectAll()
            Exit Sub
        End If
    End Sub

    Private Function IsValidCostCode(ByVal AccountNumber As Integer) As Boolean
        boolAbort = False
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False

        Dim strSql As String = "SELECT SystemCostCenters.CostCenterName " _
            & "FROM SystemCostCenters WHERE SystemCostCenters.OrdinalNo = " & AccountNumber & ""

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            lblCostCode.Text = objReader(0).ToString
            boolReturn = True
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Cost Center Validation"
        gwt_comm.ShowErrorMessage()
    End Function

End Class
