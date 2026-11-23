Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmAssetRegistry


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If Not IsNumeric(txtCostPrice.Text) Then
            MessageBox.Show("Please enter a numeric value for cost price", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCostPrice.Focus()
            txtCostPrice.SelectAll()
            Exit Sub
        End If
        If Not IsNumeric(txtCurrentValue.Text) Then
            MessageBox.Show("Please enter a numeric value for current value", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCurrentValue.Focus()
            txtCurrentValue.SelectAll()
            Exit Sub
        End If
        If Not IsNumeric(txtScrapValue.Text) Then
            MessageBox.Show("Please enter a numeric value for scrap value", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtScrapValue.Focus()
            txtScrapValue.SelectAll()
            Exit Sub
        End If
        If Not IsNumeric(txtLifeSpan.Text) Then
            MessageBox.Show("Please enter a numeric value for life span", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLifeSpan.Focus()
            txtLifeSpan.SelectAll()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAssetCode.Text) Then
            MessageBox.Show("Asset code is mandatory and is missing", "Missing Mandatory Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAssetCode.Focus()
            txtAssetCode.SelectAll()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAssetName.Text) Then
            MessageBox.Show("Asset name is mandatory and is missing", "Missing Mandatory Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAssetName.Focus()
            txtAssetName.SelectAll()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboDepreciationMethod.Text) Then
            MessageBox.Show("Asset depreciation method is mandatory and is missing", "Missing Mandatory Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboDepreciationMethod.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboLocation.Text) Then
            MessageBox.Show("Asset location is mandatory and is missing", "Missing Mandatory Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboLocation.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtManufacturer.Text) Then
            MessageBox.Show("Asset name is mandatory and is missing", "Missing Mandatory Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtManufacturer.Focus()
            txtManufacturer.SelectAll()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboCondition.Text) Then
            MessageBox.Show("Asset condition is mandatory and is missing", "Missing Mandatory Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCondition.Focus()
            Exit Sub
        End If

        If boolEditStatus = False Then
            If optCapitalAccount.Checked = False And optCashbook.Checked = False Then
                MessageBox.Show("Please choose the posting method to be effected", "Ledger Post Option Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                optCashbook.Focus()
                Exit Sub
            End If

            If optCashbook.Checked = True Then
                If String.IsNullOrEmpty(cboAccount.Text) Or String.IsNullOrEmpty(lblAccountDescription.Text) Then
                    MessageBox.Show("Please enter a valid cash book account which has been set up in the cashbook", "Invalid Cashbook Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    cboAccount.Focus()
                    Exit Sub
                End If
            End If

            If String.IsNullOrEmpty(mCboCostCenter.Text) Or String.IsNullOrEmpty(lblCostCenter.Text) Then
                MessageBox.Show("Please enter a valid account which has been set up in the ledger", "Invalid Cost Center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboAccount.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(mCboLedger.Text) Or String.IsNullOrEmpty(lblLedgerAccount.Text) Then
                MessageBox.Show("Please enter a valid account which has been set up in the ledger", "Invalid Ledger Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboAccount.Focus()
                Exit Sub
            End If

            If optCapitalAccount.Checked = True Then
                If String.IsNullOrEmpty(mCboCapitalAccount.Text) Or String.IsNullOrEmpty(lblCapitalAccount.Text) Then
                    MessageBox.Show("Please enter a valid capital account which has been set up in the ledger", "Invalid Capital Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    mCboCapitalAccount.Focus()
                    Exit Sub
                End If
            End If
        End If

        boolAbort = False
        ComputeDepreciation()
        If boolAbort = True Then Exit Sub

        Dim strSql As String = Nothing
        If boolEditStatus = False Then
            '[RetiredDate],[DisposalValue],[DisposalDate], '" & Format(dpRetiredDate.Value, "dd-MMM-yyyy") & "', " & CDbl(txtDisposalValue.Text) & ",
            ''" & Format(dpDisposalDate.Value, "dd-MMM-yyyy") & "',
            strSql = "INSERT INTO Assets ([AssetCode],[AssetName],[Description],[Category],[Condition],[DateAcquired],[CostPrice]," _
                  & "[CurrentValue],[Location],[Manufacturer],[Supplier],[Model],[Comments],[Owner],[ScrapValue],[LifeSpan]," _
                  & "[DepreciationMethod],[ImagePath], [LedgerAccount], [CostCode])VALUES " _
                  & "('" & txtAssetCode.Text & "', '" & txtAssetName.Text & "', '" & txtDescription.Text & "', '" & cboCategory.Text & "', " _
                  & "'" & cboCondition.Text & "', '" & gwt_comm.shortMonthDateFormat(dpDateAcquired.Value) & "', " _
                  & "" & CDbl(txtCostPrice.Text) & ", " & CDbl(txtCurrentValue.Text) & ", '" & cboLocation.Text & "', " _
                  & "'" & txtManufacturer.Text & "', '" & txtSupplier.Text & "', '" & txtModel.Text & "', '" & txtComments.Text & "', " _
                  & "'" & txtOwner.Text & "', " & CDbl(txtScrapValue.Text) & ", " & CDbl(txtLifeSpan.Text) & ", '" & cboDepreciationMethod.Text & "', " _
                  & "'" & txtImagePath.Text & "', '" & lblLedgerAccount.Text & "', " & CDbl(lblCostCenter.Text) & ")"
        Else
            '[RetiredDate] = '" & Format(dpRetiredDate.Value, "dd-MMM-yyyy") & "', " _
            '& "[DisposalValue] = " & CDbl(txtDisposalValue.Text) & ", [DisposalDate] = '" & Format(dpDisposalDate.Value, "dd-MMM-yyyy") & "'
            strSql = "UPDATE Assets SET [AssetName] = '" & txtAssetName.Text & "', " _
                & "[Description] = '" & txtDescription.Text & "', [Category] = '" & cboCategory.Text & "', " _
                & "[Condition] = '" & cboCondition.Text & "',[DateAcquired] = '" & gwt_comm.shortMonthDateFormat(dpDateAcquired.Value) & "', " _
                & "[CostPrice] = " & CDbl(txtCostPrice.Text) & ", [CurrentValue] = " & CDbl(txtCurrentValue.Text) & ", " _
                & "[Location] = '" & cboLocation.Text & "', [Manufacturer] = '" & txtManufacturer.Text & "', " _
                & "[Supplier] = '" & txtSupplier.Text & "', [Model] = '" & txtModel.Text & "', [Comments] = '" & txtComments.Text & "', " _
                & "[Owner] = '" & txtOwner.Text & "', [ScrapValue] = " & CDbl(txtScrapValue.Text) & ", " _
                & "[LifeSpan] = " & CDbl(txtLifeSpan.Text) & ", [DepreciationMethod] = '" & cboDepreciationMethod.Text & "', " _
                & "[ImagePath] = '" & txtImagePath.Text & "' WHERE AssetCode = '" & txtAssetCode.Text & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Add the record to the ledger accounts asset
        If boolEditStatus = False Then
            If optCapitalAccount.Checked = True Then
                gwt_comm.LedgerEntry("INSERT", dpDateAcquired.Text, lblCapitalAccount.Text, lblLedgerAccount.Text, txtAssetName.Text & " " & txtDescription.Text, _
                    CDbl(txtCostPrice.Text), "CREDIT", txtAssetCode.Text, txtAssetCode.Text, CInt(lblCostCenter.Text), 0, 0, 0, 0, 0)
                gwt_comm.LedgerEntry("INSERT", dpDateAcquired.Text, lblLedgerAccount.Text, lblCapitalAccount.Text, txtAssetName.Text & " " & txtDescription.Text, _
                    CDbl(txtCostPrice.Text), "DEBIT", txtAssetCode.Text, txtAssetCode.Text, CInt(lblCostCenter.Text), 0, 0, 0, 0, 0)
            End If
            If optCashbook.Checked = True Then
                gwt_comm.LedgerEntry("INSERT", dpDateAcquired.Text, lblLedgerAccount.Text, strPublicActiveCashbook, txtAssetName.Text & " " & txtDescription.Text, _
                    CDbl(txtCostPrice.Text), "DEBIT", txtAssetCode.Text, txtAssetCode.Text, CInt(lblCostCenter.Text), 0, 0, 0, 0, 0)
                'LedgerEntry("INSERT", dpDateAcquired.Text, strPublicCashControlAccount, lblLedgerAccount.Text, txtAssetName.Text & " " & txtDescription.Text, _
                '    CDbl(txtCostPrice.Text), "CREDIT", txtAssetCode.Text, txtAssetCode.Text, CInt(lblCostCenter.Text), 0, 0, 0, 0, 0)
                'Credit the cash account
                strSql = "INSERT INTO CashbookTransactions ([TransactionDate],[Amount],[Description],[AccountNumber]," _
                    & "[ContraAccount],[UserName],[UserBranch],[Reference],[TransactionType],[FolioReference],[Status],[PaymentMethod]) VALUES " _
                    & "('" & dpDateAcquired.Text & "', " & CDbl(txtCostPrice.Text) & ", '" & txtAssetName.Text & "', " _
                    & "'" & lblAccountDescription.Text & "', '" & lblLedgerAccount.Text & "', '" & strUserName & "', " _
                    & "'" & strUserBranch & "', 0, 'CREDIT', '" & txtAssetCode.Text & "', 'N', 'CASH')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If
        End If

        'Add the depreciation values into the database as well
        If boolEditStatus = True Then
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM DepreciationValues WHERE AssetCode = '" & txtAssetCode.Text & "'", cnn)
            objCommand.ExecuteNonQuery()
        End If
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim intYear As Integer = DatePart(DateInterval.Year, Now)
            Dim intPeriod As Integer = 0
            Dim dblDepreciation As Double = 0
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(0).Value) Then
                    intYear = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(1).Value) Then
                    intPeriod = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value) Then
                    dblDepreciation = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
                End If
            End If
            strSql = "INSERT INTO DepreciationValues ([AssetCode],[DepYear],[DepPeriod],[Depreciation]) VALUES " _
                & "('" & txtAssetCode.Text & "', " & intYear & ", " & intPeriod & ", " & dblDepreciation & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Next
        MessageBox.Show("Asset details have been saved successfully", "Asset Details Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Asset Details Registration"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCategories()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Category FROM AssetCategories ORDER BY Category", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboCategory.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Asset Categories Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadBranches()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT BranchName FROM Branches ORDER BY BranchName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboLocation.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Asset Registration"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmAssetRegistry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBranches()
        LoadCategories()
        LoadLedgerAccounts()
        LoadCostCenters()
        LoadCashbooks()
        If boolEditStatus = True Then
            grpAccounting.Enabled = False
            LoadData()
        Else
            grpAccounting.Enabled = True
        End If
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        txtAssetCode.Enabled = False
        Dim strSql As String = "SELECT [AssetCode],[AssetName],[Description],[Category],[Condition],[DateAcquired],[CostPrice]," _
              & "[CurrentValue],[Location],[Manufacturer],[Supplier],[Model],[Comments],[Owner],[ScrapValue],[LifeSpan]," _
              & "[DepreciationMethod],[ImagePath],[RetiredDate],[DisposalValue],[DisposalDate], [LedgerAccount], [CostCode] " _
              & "FROM Assets WHERE AssetCode = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtAssetCode.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtAssetName.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtDescription.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then cboCategory.Text = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then cboCondition.Text = objReader(4).ToString
            If IsDate(objReader(5).ToString) Then dpDateAcquired.Value = CDate(objReader(5).ToString)
            If Not IsDBNull(objReader(6).ToString) Then txtCostPrice.Text = Format(CDbl(objReader(6).ToString), "##0.00")
            If Not IsDBNull(objReader(7).ToString) Then txtCurrentValue.Text = Format(CDbl(objReader(7).ToString), "##0.00")
            If Not IsDBNull(objReader(8).ToString) Then cboLocation.Text = objReader(8).ToString
            If Not IsDBNull(objReader(9).ToString) Then txtManufacturer.Text = objReader(9).ToString
            If Not IsDBNull(objReader(10).ToString) Then txtSupplier.Text = objReader(10).ToString
            If Not IsDBNull(objReader(11).ToString) Then txtModel.Text = objReader(11).ToString
            If Not IsDBNull(objReader(12).ToString) Then txtComments.Text = objReader(12).ToString
            If Not IsDBNull(objReader(13).ToString) Then txtOwner.Text = objReader(13).ToString
            If Not IsDBNull(objReader(14).ToString) Then txtScrapValue.Text = Format(CDbl(objReader(14).ToString), "##0.00")
            If Not IsDBNull(objReader(15).ToString) Then txtLifeSpan.Text = Format(CDbl(objReader(15).ToString), "##0.00")
            If Not IsDBNull(objReader(16).ToString) Then cboDepreciationMethod.Text = objReader(16).ToString
            If Not IsDBNull(objReader(17).ToString) Then txtImagePath.Text = objReader(17).ToString
            If IsDate(objReader(18).ToString) Then dpRetiredDate.Value = CDate(objReader(18).ToString)
            If Not IsDBNull(objReader(19).ToString) Then txtDisposalValue.Text = Format(CDbl(objReader(19).ToString), "##0.00")
            If IsDate(objReader(20).ToString) Then dpDisposalDate.Value = CDate(objReader(20).ToString)

            lblCostCenter.Text = "0" : lblLedgerAccount.Text = Nothing
            Dim objReadDescriptions As Data.OleDb.OleDbDataReader
            If Not IsDBNull(objReader("CostCode").ToString) Then
                If IsNumeric(objReader("CostCode").ToString) Then lblCostCenter.Text = CInt(objReader("CostCode").ToString)
                objCommand = New Data.OleDb.OleDbCommand("SELECT CostCenterName FROM SystemCostCenters WHERE OrdinalNo = " & CInt(lblCostCenter.Text) & "", cnn)
                objReadDescriptions = objCommand.ExecuteReader
                If objReadDescriptions.HasRows Then
                    objReadDescriptions.Read()
                    If Not IsDBNull(objReadDescriptions(0).ToString) Then mCboCostCenter.Text = UCase(objReadDescriptions(0).ToString)
                End If
                objReadDescriptions.Close()
            End If

            If Not IsDBNull(objReader("LedgerAccount").ToString) Then
                If IsNumeric(objReader("LedgerAccount").ToString) Then lblLedgerAccount.Text = CInt(objReader("LedgerAccount").ToString)
                objCommand = New Data.OleDb.OleDbCommand("SELECT AccountName FROM LedgerAccounts WHERE AccountNumber = '" & CInt(lblCostCenter.Text) & "'", cnn)
                objReadDescriptions = objCommand.ExecuteReader
                If objReadDescriptions.HasRows Then
                    objReadDescriptions.Read()
                    If Not IsDBNull(objReadDescriptions(0).ToString) Then mCboLedger.Text = UCase(objReadDescriptions(0).ToString)
                End If
                objReadDescriptions.Close()
            End If

        End If
        objReader.Close()
        LoadImage()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Asset Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadImage()
        If Not String.IsNullOrEmpty(txtImagePath.Text) Then
            If System.IO.File.Exists(txtImagePath.Text) Then
                picImage.Load(txtImagePath.Text)
            End If
        End If
    End Sub

    Private Sub ComputeDepreciation()
        On Error GoTo RaiseErr
        If Not IsNumeric(txtCostPrice.Text) Then
            Exit Sub
        End If
        If Not IsNumeric(txtScrapValue.Text) Then
            Exit Sub
        End If
        If Not IsNumeric(txtLifeSpan.Text) Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboDepreciationMethod.Text) Then
            Exit Sub
        End If

        Dim InitCost, SalvageVal, LifeTime, DepYear As Double
        Dim Fmt As String = "###,##0.00"

        InitCost = CDbl(txtCostPrice.Text)
        SalvageVal = CDbl(txtScrapValue.Text)
        LifeTime = CDbl(txtLifeSpan.Text)
        Dim n As Integer = 0

        dGrid.Rows.Clear()
        Dim intYear As Integer = DatePart(DateInterval.Year, dpDateAcquired.Value)
        Select Case cboDepreciationMethod.Text
            Case Is = "Straight-Line"
                ' Use the Straight-Line- (SLN) function to calculate the deprecation per year.
                Dim SlnDepr As Double = SLN(InitCost, SalvageVal, LifeTime)
                For n = 0 To CInt(txtLifeSpan.Text) - 1
                    dGrid.Rows.Add()
                    dGrid.Rows(n).Cells(0).Value = Format((intYear + n), "0000")
                    dGrid.Rows(n).Cells(1).Value = Format((n + 1), "000")
                    dGrid.Rows(n).Cells(2).Value = Format(SlnDepr, Fmt)
                Next
            Case Is = "Sum-Of-Years"
                For DepYear = 1 To LifeTime
                    dGrid.Rows.Add()
                    dGrid.Rows(DepYear - 1).Cells(0).Value = Format((intYear + (DepYear - 1)), "0000")
                    dGrid.Rows(DepYear - 1).Cells(1).Value = DepYear
                    dGrid.Rows(DepYear - 1).Cells(2).Value = Format(SYD(InitCost, SalvageVal, LifeTime, DepYear), Fmt)
                Next
            Case Is = "Double-Declining-Balance"
                For DepYear = 1 To LifeTime
                    dGrid.Rows.Add()
                    dGrid.Rows(DepYear - 1).Cells(0).Value = Format((intYear + (DepYear - 1)), "0000")
                    dGrid.Rows(DepYear - 1).Cells(1).Value = DepYear
                    dGrid.Rows(DepYear - 1).Cells(2).Value = Format(DDB(InitCost, SalvageVal, LifeTime, DepYear), Fmt)
                Next
        End Select
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Depreciation computation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboDepreciationMethod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDepreciationMethod.KeyPress
        If Asc(e.KeyChar) = 13 Then cboLocation.Focus()
    End Sub

    Private Sub cboDepreciationMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepreciationMethod.SelectedIndexChanged
        ComputeDepreciation()
    End Sub

    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton1.Click
        ComputeDepreciation()
    End Sub

    Private Sub txtCurrentValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCurrentValue.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtCostPrice.Focus()
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtCostPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostPrice.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtScrapValue.Focus()
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtScrapValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScrapValue.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtLifeSpan.Focus()
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtAssetCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssetCode.KeyPress
        If Asc(e.KeyChar) = 13 Then txtModel.Focus()
    End Sub

    Private Sub txtModel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtModel.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAssetName.Focus()
    End Sub

    Private Sub txtAssetName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssetName.KeyPress
        If Asc(e.KeyChar) = 13 Then cboCategory.Focus()
    End Sub

    Private Sub cboCategory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCategory.KeyPress
        If Asc(e.KeyChar) = 13 Then cboCondition.Focus()
    End Sub

    Private Sub cboCondition_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCondition.KeyPress
        If Asc(e.KeyChar) = 13 Then dpDateAcquired.Focus()
    End Sub

    Private Sub txtLifeSpan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLifeSpan.KeyPress
        If Asc(e.KeyChar) = 13 Then cboDepreciationMethod.Focus()
    End Sub

    Private Sub cboLocation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLocation.KeyPress
        If Asc(e.KeyChar) = 13 Then txtManufacturer.Focus()
    End Sub

    Private Sub txtManufacturer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtManufacturer.KeyPress
        If Asc(e.KeyChar) = 13 Then txtSupplier.Focus()
    End Sub

    Private Sub txtSupplier_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSupplier.KeyPress
        If Asc(e.KeyChar) = 13 Then txtOwner.Focus()
    End Sub

    Private Sub txtOwner_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOwner.KeyPress
        If Asc(e.KeyChar) = 13 Then dpRetiredDate.Focus()
    End Sub

    Private Sub LoadLedgerAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AccountName +';'+ AccountNumber AS [Data] " _
            & "FROM LedgerAccounts ORDER BY AccountName"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Set up the drop down combo box
        Dim intX As Integer = mCboLedger.Width - 55
        With mCboLedger
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intX) & ";150"
            .DropDownHeight = 100
        End With

        With mCboCapitalAccount
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intX) & ";150"
            .DropDownHeight = 100
        End With

        'Get a count of the items
        Dim intItemsCount As Integer = 1
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM LedgerAccounts", cnn)

        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = intItemsCount + CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        mCboLedger.Items.Clear()
        mCboCapitalAccount.Items.Clear()

        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            If p = 0 Then
                DropDownItems(p) = New MTGCComboBoxItem("---NONE---", "0")
                p = p + 1
            End If
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()

        With mCboLedger
            If intItemsCount > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With
        With mCboCapitalAccount
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger Accounts Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCostCenters()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT CostCenterName +';'+ CONVERT(NVARCHAR, OrdinalNo) AS " _
            & "[CostCenters] FROM SystemCostCenters ORDER BY CostCenterName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        Dim intX As Integer = mCboCostCenter.Width - 55
        With mCboCostCenter
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intX) & ";50"
            .DropDownHeight = 100
        End With
        'Get a count of the items
        Dim intItemsCount As Double = 1

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(OrdinalNo) FROM SystemCostCenters", cnn)

        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = intItemsCount + CDbl(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        mCboCostCenter.Items.Clear()

        Dim p As Double = 0

        'Continue to read until you reach the end of the file.
        DropDownItems(p) = New MTGCComboBoxItem(UCase("--- NONE ---"), UCase("0"))
        p = p + 1

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        With mCboCostCenter
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Cost Center Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub mCboLedger_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCboLedger.SelectedIndexChanged
        lblLedgerAccount.Text = Nothing
        lblLedgerAccount.Text = mCboLedger.SelectedItem.Col2
    End Sub

    Private Sub mCboCostCenter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mCboCostCenter.SelectedIndexChanged
        lblCostCenter.Text = Nothing
        lblCostCenter.Text = mCboCostCenter.SelectedItem.Col2
    End Sub

    Private Sub cboAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccount.SelectedIndexChanged
        lblAccountDescription.Text = ""
        If Not cboAccount.SelectedItem Is Nothing Then
            lblAccountDescription.Text = cboAccount.SelectedItem.Col2
        End If
    End Sub

    Private Sub mCboCapitalAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mCboCapitalAccount.SelectedIndexChanged
        lblCapitalAccount.Text = ""
        If Not mCboCapitalAccount.SelectedItem Is Nothing Then
            lblCapitalAccount.Text = mCboCapitalAccount.SelectedItem.Col2
        End If
    End Sub

    Private Sub LoadCashbooks()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM Cashbooks ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        Dim intX As Integer = cboAccount.Width - 55
        With cboAccount
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intX) & ";50"
            .DropDownHeight = 90
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM Cashbooks", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboAccount.Items.Clear()
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
            cboAccount.SelectedIndex = -1
            cboAccount.Items.Clear()
            cboAccount.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboAccount.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Cashbooks Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub optCashbook_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCashbook.CheckedChanged
        cboAccount.Enabled = True : mCboCapitalAccount.Enabled = False
    End Sub

    Private Sub optCapitalAccount_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCapitalAccount.CheckedChanged
        cboAccount.Enabled = False : mCboCapitalAccount.Enabled = True
    End Sub

    Private Sub txtLifeSpan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLifeSpan.TextChanged
        ComputeDepreciation()
    End Sub

    Private Sub txtScrapValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScrapValue.TextChanged
        ComputeDepreciation()
    End Sub

End Class
