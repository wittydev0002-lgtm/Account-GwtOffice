Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCodeSetup

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmCodeSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        If gwt_comm.CheckColumnExistence("SystemCodes", "BalanceCode") = False Then
            Dim objCommand As New Data.OleDb.OleDbCommand("ALTER TABLE SystemCodes ADD [BalanceCode][int] NOT NULL DEFAULT 0", cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("SystemCodes", "InterestCode") = False Then
            Dim objCommand As New Data.OleDb.OleDbCommand("ALTER TABLE SystemCodes ADD [InterestCode][int] NOT NULL DEFAULT 0", cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("SystemCodes", "InterestRateRegister") = False Then
            Dim objCommand As New Data.OleDb.OleDbCommand("ALTER TABLE SystemCodes ADD [InterestRateRegister][int] NOT NULL DEFAULT 0", cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("SystemCodes", "YtdCode") = False Then
            Dim objCommand As New Data.OleDb.OleDbCommand("ALTER TABLE SystemCodes ADD [YtdCode][int] NOT NULL DEFAULT 0", cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("SystemCodes", "UnitCode") = False Then
            Dim objCommand As New Data.OleDb.OleDbCommand("ALTER TABLE SystemCodes ADD [UnitCode][int] NOT NULL DEFAULT 0", cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("SystemCodes", "PayslipDisplay") = False Then
            Dim objCommand As New Data.OleDb.OleDbCommand("ALTER TABLE SystemCodes ADD [PayslipDisplay][nvarchar] (1) NOT NULL DEFAULT 'N'", cnn)
            objCommand.ExecuteNonQuery()
        End If
        'PayslipDisplay
        lblCodeNumber.Text = CStr(Format(intSelectedCode, "000"))
        txtCodeDescription.Text = strCodeDescription
        LoadBalanceCodes()
        LoadCodeDetails()
        LoadLedgerAccounts()
        GroupBox1.Enabled = False
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCodeDetails()
        On Error GoTo RaiseErr
        Dim objDataReader As Data.OleDb.OleDbDataReader
        Dim objDataCommand As New Data.OleDb.OleDbCommand("SELECT * FROM SystemCodes WHERE CodeNo = " & intSelectedCode & "", cnn)
        objDataReader = objDataCommand.ExecuteReader
        If objDataReader.HasRows Then
            objDataReader.Read()
            Dim strTaxType As String = "N"
            Dim strTaxAssign As String = "N"
            Dim strProrata As String = "N"
            Dim strDisplay As String = "Y"
            If Not IsDBNull(objDataReader("TaxType").ToString) Then strTaxType = UCase(objDataReader("TaxType").ToString)
            If Not IsDBNull(objDataReader("TaxTreatment").ToString) Then strTaxAssign = UCase(objDataReader("TaxTreatment").ToString)
            If Not IsDBNull(objDataReader("ProRataInd").ToString) Then strProrata = UCase(objDataReader("ProRataInd").ToString)
            If Not IsDBNull(objDataReader("DisplayStatus").ToString) Then strDisplay = UCase(objDataReader("DisplayStatus").ToString)

            'Set the code type
            If Not IsDBNull(objDataReader("CodeType").ToString) Then
                Select Case UCase(objDataReader("CodeType").ToString)
                    Case Is = "E"
                        'Earnings codes
                        cboCodeType.SelectedIndex = 0
                    Case Is = "D"
                        'General deduction codes
                        cboCodeType.SelectedIndex = 1
                    Case Is = "L"
                        'Loan deduction codes
                        cboCodeType.SelectedIndex = 2
                    Case Is = "S"
                        'Balance and storage codes
                        cboCodeType.SelectedIndex = 3
                End Select
            End If

            If Not IsDBNull(objDataReader("BalanceCode").ToString) Then cboBalanceCodes.Text = objDataReader("BalanceCode").ToString
            If Not IsDBNull(objDataReader("InterestCode").ToString) Then cboInterestCode.Text = objDataReader("InterestCode").ToString
            If Not IsDBNull(objDataReader("InterestRateRegister").ToString) Then cboInterestRatePcnt.Text = objDataReader("InterestRateRegister").ToString
            If Not IsDBNull(objDataReader("YtdCode").ToString) Then cboYtd.Text = objDataReader("YtdCode").ToString
            If Not IsDBNull(objDataReader("UnitCode").ToString) Then cboUnit.Text = objDataReader("UnitCode").ToString

            'set all the options to false

            If strTaxType = "B" Then cboTaxType.SelectedIndex = 1 Else cboTaxType.SelectedIndex = 0

            If strTaxAssign = "A" Then cboTaxTreatment.SelectedIndex = 0
            If strTaxAssign = "S" Then cboTaxTreatment.SelectedIndex = 1
            If strTaxAssign = "C" Then cboTaxTreatment.SelectedIndex = 2
            If strTaxAssign = "N" Then cboTaxTreatment.SelectedIndex = 3

            If strProrata = "Y" Then cboProrata.SelectedIndex = 0
            If strProrata = "N" Then cboProrata.SelectedIndex = 1

            If strDisplay = "Y" Then cboDisplay.SelectedIndex = 0
            If strDisplay = "N" Then cboDisplay.SelectedIndex = 1

            If Not IsDBNull(objDataReader("PayslipDisplay").ToString) Then
                If UCase(objDataReader("PayslipDisplay").ToString) = "Y" Then
                    chkPayslipDisplay.Checked = True
                Else
                    chkPayslipDisplay.Checked = False
                End If
            End If
            If IsNumeric(objDataReader("TaxCreditRate").ToString) Then
                txtTaxCreditRate.Text = Format(CDbl(objDataReader("TaxCreditRate").ToString), "##0.00")
            Else
                txtTaxCreditRate.Text = "0.00"
            End If
            If Not IsDBNull(objDataReader("LedgerAccount").ToString) Then
                lblName.Text = LedgerAccountName(objDataReader("LedgerAccount").ToString)
                txtLinkLedgerAccount.Text = objDataReader("LedgerAccount").ToString
            Else
                txtLinkLedgerAccount.Text = "0"
            End If

            'LedgerCostCode
            If Not IsDBNull(objDataReader("LedgerCostCode").ToString) Then
                txtCostCode.Text = objDataReader("LedgerCostCode").ToString
            Else
                txtCostCode.Text = Nothing
            End If

            If Not String.IsNullOrEmpty(txtCostCode.Text) Then
                chkFixedCostCode.Checked = True
            End If

        End If
        'lblCodeNumber.Text = intSelectedCode
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On payroll code setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadBalanceCodes()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT CONVERT(NVARCHAR, CodeNo) +';'+ Description AS [Banking] FROM SystemCodes ORDER BY CodeNo"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboBalanceCodes
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "60;250"
        End With
        With cboInterestCode
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "60;250"
        End With
        With cboYtd
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "60;250"
        End With
        With cboUnit
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
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(CodeNo) FROM SystemCodes", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboBalanceCodes.Items.Clear() : cboInterestCode.Items.Clear() : cboInterestRatePcnt.Items.Clear()
        cboYtd.Items.Clear() : cboUnit.Items.Clear()

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
            cboBalanceCodes.SelectedIndex = -1
            cboBalanceCodes.Items.Clear()
            cboBalanceCodes.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboBalanceCodes.Items.AddRange(DropDownItems)
            'Load the interest combo box
            cboInterestCode.SelectedIndex = -1
            cboInterestCode.Items.Clear()
            cboInterestCode.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboInterestCode.Items.AddRange(DropDownItems)
            'Load year to date codes
            cboYtd.SelectedIndex = -1
            cboYtd.Items.Clear()
            cboYtd.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboYtd.Items.AddRange(DropDownItems)
            'Load unit codes
            cboUnit.SelectedIndex = -1
            cboUnit.Items.Clear()
            cboUnit.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboUnit.Items.AddRange(DropDownItems)
        End If

        'Add the registers
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, ConstantNo) +';'+ Description FROM SystemConstants ORDER BY ConstantNo", cnn)
        objReader = sqlCommand.ExecuteReader
        With cboInterestRatePcnt
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
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ConstantNo) FROM SystemConstants", cnn)
        objCount = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()

        Dim DropDownItems1(intItemsCount - 1) As MTGCComboBoxItem
        i = 0
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems1(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            i = i + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboInterestRatePcnt.SelectedIndex = -1
            cboInterestRatePcnt.Items.Clear()
            cboInterestRatePcnt.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboInterestRatePcnt.Items.AddRange(DropDownItems1)
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On payroll code setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtCodeDescription.Text) Then
            MessageBox.Show("Please enter a valid description for the payroll code", "Invalid Payroll Code Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodeDescription.Focus()
            Exit Sub
        End If

        If chkFixedCostCode.Checked = True Then
            If String.IsNullOrEmpty(txtCostCode.Text) Then
                MessageBox.Show("Please enter the fixed cost code", "Invalid Fixed Cost Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCostCode.Focus()
                Exit Sub
            End If
        End If
        'Check the buttons and then save the details

        Dim strTaxType As String = "N"
        Dim strTaxAssign As String = "N"
        Dim strProrata As String = "N"
        Dim strDisplay As String = "Y"
        Dim strAddToTax As String = "Y"

        If cboTaxType.SelectedIndex = 1 Then strTaxType = "B"

        If cboTaxTreatment.SelectedIndex = 0 Then strTaxAssign = "A"
        If cboTaxTreatment.SelectedIndex = 1 Then strTaxAssign = "S"
        If cboTaxTreatment.SelectedIndex = 2 Then strTaxAssign = "C"
        If cboTaxTreatment.SelectedIndex = 3 Then strTaxAssign = "N"

        If strTaxAssign = "N" Then strAddToTax = "N" Else strAddToTax = "Y"

        If cboProrata.SelectedIndex = 0 Then strProrata = "Y"
        If cboProrata.SelectedIndex = 1 Then strProrata = "N"

        If cboDisplay.SelectedIndex = 0 Then strDisplay = "Y"
        If cboDisplay.SelectedIndex = 1 Then strDisplay = "N"

        'Note that in all cases we are updating as the details are preset on application
        'Installation and initialization
        Dim strPayslipDisplay As String = "N"

        Select Case cboCodeType.Text
            Case Is = "Earning"
                strCodeType = "E"
                strPayslipDisplay = "Y"
            Case Is = "General Deduction"
                strCodeType = "D"
                strPayslipDisplay = "Y"
            Case Is = "Loan Deduction"
                strCodeType = "L"
                strPayslipDisplay = "Y"
            Case Is = "Storage"
                strCodeType = "S"
                If chkPayslipDisplay.Checked = True Then
                    strPayslipDisplay = "Y"
                Else
                    strPayslipDisplay = "N"
                End If
        End Select

        Dim intInterestCode As Integer = 0
        Dim intBalanceCode As Integer = 0
        Dim intInterestRegister As Integer = 0
        Dim intYtdCode As Integer = 0
        Dim intUnitCode As Integer = 0

        If IsNumeric(cboBalanceCodes.Text) Then intBalanceCode = CInt(cboBalanceCodes.Text)
        If IsNumeric(cboInterestCode.Text) Then intInterestCode = CInt(cboInterestCode.Text)
        If IsNumeric(cboInterestRatePcnt.Text) Then intInterestRegister = CInt(cboInterestRatePcnt.Text)
        If IsNumeric(cboYtd.Text) Then intYtdCode = CInt(cboYtd.Text)
        If IsNumeric(cboUnit.Text) Then intUnitCode = CInt(cboUnit.Text)

        Dim objDataCommand As Data.OleDb.OleDbCommand

        'Check that the code has already been set or not
        boolEditStatus = False
        Dim intCnt As Integer = 0
        objDataCommand = New Data.OleDb.OleDbCommand("SELECT Count(CodeNo) FROM SystemCodes WHERE CodeNo = " & CInt(lblCodeNumber.Text) & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objDataCommand.ExecuteReader
        While objReader.Read
            intCnt = CInt(objReader(0).ToString)
        End While
        objReader.Close()
        If intCnt > 0 Then
            boolEditStatus = True
        End If

        If boolEditStatus = False Then
            objDataCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemCodes (CodeNo, Description, CodeType) " _
                & "VALUES (" & CInt(lblCodeNumber.Text) & ", '" & txtCodeDescription.Text & "', '" & strCodeType & "')", cnn)
            objDataCommand.ExecuteNonQuery()
        End If

        Dim strLedgerCostCode As String = Nothing
        If chkFixedCostCode.Checked = True Then
            strLedgerCostCode = txtCostCode.Text
        End If

        Dim strSql As String = "UPDATE SystemCodes SET Description = '" & txtCodeDescription.Text & "', " _
            & "TaxType = '" & strTaxType & "', TaxTreatment = '" & strTaxAssign & "', ProrataInd = '" & strProrata & "', " _
            & "DisplayStatus = '" & strDisplay & "', YtdStatus = 'N', AdjustFlag = 'N', ConsolCode = 0, Limit = 0, " _
            & "ManualDisplayInd = 'N', ConsolArnFlag = 'N', BalanceCode = " & intBalanceCode & ", " _
            & "InterestCode = " & intInterestCode & ", CodeType = '" & strCodeType & "', " _
            & "InterestRateRegister = " & intInterestRegister & ", YtdCode = " & intYtdCode & ", " _
            & "UnitCode = " & intUnitCode & ", PayslipDisplay = '" & strPayslipDisplay & "', " _
            & "LedgerAccount = '" & txtLinkLedgerAccount.Text & "', LedgerSide = '" & cboLinkLedgerSide.Text & "', " _
            & "LedgerCostCode = '" & strLedgerCostCode & "' " _
            & "WHERE CodeNo = " & CInt(lblCodeNumber.Text) & ""
        objDataCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objDataCommand.ExecuteNonQuery()
        MessageBox.Show("Code Updated Successfully", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        boolEditStatus = True
        boolChangesEffected = True
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On code setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboCodeType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCodeType.SelectedIndexChanged
        If cboCodeType.Text = "Storage" Then
            chkPayslipDisplay.Checked = False
            chkPayslipDisplay.Enabled = True
        Else
            chkPayslipDisplay.Checked = True
            chkPayslipDisplay.Enabled = False
        End If
        If cboCodeType.Text = "Loan Deduction" Then
            GroupBox1.Enabled = True
        Else
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub LoadLedgerAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountNumber +';'+AccountName AS " _
            & "[Accounts] FROM LedgerAccounts ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With txtLinkLedgerAccount
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;335"
        End With

        Dim arrData As New ArrayList
        arrData.Add("0;--NONE--")
        While objReader.Read
            arrData.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Get a count of the items
        Dim intItemsCount As Integer = arrData.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        txtLinkLedgerAccount.Items.Clear()
        For p As Integer = 0 To arrData.Count - 1
            Dim strRecordText() As String = Split(arrData.Item(p).ToString, ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        With txtLinkLedgerAccount
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
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Account Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtLinkLedgerAccount_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles txtLinkLedgerAccount.SelectedIndexChanged
        lblName.Text = Nothing
        lblName.Text = txtLinkLedgerAccount.SelectedItem.Col2.ToString
    End Sub

    Private Function LedgerAccountName(AccountNumber As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountName FROM LedgerAccounts " _
            & "WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            strReturn = objReader(0).ToString
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Account Details Fetch"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub frmCodeSetup_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 700 : Me.Height = 490
    End Sub

End Class