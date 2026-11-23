Imports System.Transactions

Public Class frmLaschCustomer

    Dim boolLoading As Boolean
    Dim dblFarmAcreage As Double = 0

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

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click

        If String.IsNullOrEmpty(txtLastName.Text) Then
            MessageBox.Show("Please enter the customer Last name", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLastName.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtFirstName.Text) Then
            MessageBox.Show("Please enter the customer first name", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirstName.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the customer address 1", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtCellphone.Text) Then
            MessageBox.Show("Please enter the customer cellphone number", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCellphone.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtKinName.Text) Then
            MessageBox.Show("Please enter the customer next of kin", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtKinCellphone.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtIdNumber.Text) Then
            MessageBox.Show("Please enter the customer ID number", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtIdNumber.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtFarmerOrganisation.Text) Then
            MessageBox.Show("Please enter the customer farmer organisation", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFarmerOrganisation.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAgritexOfficer.Text) Then
            MessageBox.Show("Please enter the customer Agritex Officer", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAgritexOfficer.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtLaschOfficer.Text) Then
            MessageBox.Show("Please enter the Lasch Official name", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLaschOfficer.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtFarmName.Text) Then
            MessageBox.Show("Please enter the farm name", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFarmName.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboProvince.Text) Then
            MessageBox.Show("Please enter the province where the farm is located", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboProvince.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboDistrict.Text) Then
            MessageBox.Show("Please enter the district where the farm is located", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboDistrict.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtWard.Text) Then
            MessageBox.Show("Please enter the ward where the farm is located", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtWard.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtChief.Text) Then
            MessageBox.Show("Please enter the chief name under whose jurisdiction the farm is", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtChief.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAccountNumber.Text) Then
            If boolEditStatus = False Then
                txtAccountNumber.Text = LaschNextCustomerNumber(cboProvince.Text, cboDistrict.Text)
            Else
                MessageBox.Show("Please enter the customer account number", "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtAccountNumber.Focus()
                Exit Sub
            End If
        End If

        boolAbort = False
        If boolEditStatus = True Then
            UpdateRecord()
        Else

            Dim strReturn As String = LaschMasterfileDuplicateEntryCheck(Trim(txtIdNumber.Text), Trim(txtLastName.Text), Trim(txtFirstName.Text))
            Dim ReturnStatus() As String = Split(strReturn, "|")

            If UCase(ReturnStatus(0)) = "TRUE" Then
                'This record will cause duplicates. Write it to error file
                Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\IMPORTERR.TXT", True)
                objFileWriter.WriteLine(txtLastName.Text & " " & txtFarmName.Text & "**** " & ReturnStatus(1) & " **** " & UCase(Now))
                objFileWriter.Close()
                MessageBox.Show("The record entered will case dublicates as there exist a farmer with same details. Process aborted", _
                    "Duplicate Farmer Record", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            CreateRecord()
            'Post the details to the relevant ledgers and transactions accounts
            'update the default sales account as well
            If String.IsNullOrEmpty(strPublicLaschPremiumsControlAccount) Then
                MessageBox.Show("The sales control account has not been setup. This will seriously affect the trial balance",
                     "Sales Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                UpdateLedgerTransactions()
            End If

        End If
        SavePremiumsData()
        If boolAbort = True Then Exit Sub

        MessageBox.Show("Record saved successfully. The updated farmer account number is " & txtAccountNumber.Text, "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Lasch Customer Record Creation"
        ShowErrorMessage()
    End Sub

    Private Sub UpdateLedgerTransactions()

        On Error GoTo RaiseErr

        'Make it a sql transaction
        Dim [option] = New TransactionOptions With {.IsolationLevel = IsolationLevel.ReadCommitted, .Timeout = TimeSpan.FromSeconds(60)}
        Using InputTransactions = New TransactionScope(TransactionScopeOption.Required, [option])

            Dim myCommand As Data.OleDb.OleDbCommand
            Dim strProcessType As String = "INIATILIZATION PREMIUMS "

            If boolEditStatus = True Then
                myCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE " _
                    & "Description = '" & strProcessType & txtLastName.Text & " " & txtFirstName.Text & "'", cnn)
                myCommand.ExecuteNonQuery()
                myCommand = New Data.OleDb.OleDbCommand("DELETE FROM LaschCustomerTransactions WHERE " _
                    & "[AccountNumber] = '" & txtAccountNumber.Text & "' AND [Description] = 'INIATILIZATION PREMIUMS'", cnn)
                myCommand.ExecuteNonQuery()
            End If


            Dim intSpecialKey As Integer = SpecialKey()
            Dim dblPremiums As Double = PremiumsDue()

            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                & "('" & strPublicLaschPremiumsControlAccount & "', '" & Format(Now, "dd-MMM-yyyy") & "', " & dblPremiums & ", 'CREDIT', " _
                & "'" & txtAccountNumber.Text & "', '" & strProcessType & txtLastName.Text & " " & txtFirstName.Text & "', '" & strUserName & "', " _
                & "'" & strUserBranch & "', " & intSpecialKey & ", " & intSpecialKey & ")", cnn)
            myCommand.ExecuteNonQuery()

            'Update the debtors control account
            If String.IsNullOrEmpty(strPublicDebtorsAccount) Then
                MessageBox.Show("The debtors control account has not been setup. This will seriously affect the trial balance",
                     "Debtors Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                    & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                    & "('" & strPublicDebtorsAccount & "', '" & Format(Now, "dd-MMM-yyyy") & "', " & dblPremiums & ", 'DEBIT', " _
                    & "'" & txtAccountNumber.Text & "', '" & strProcessType & txtLastName.Text & " " & txtFirstName.Text & "', '" & strUserName & "', " _
                    & "'" & strUserBranch & "', " & intSpecialKey & ", " & intSpecialKey & ")", cnn)
                myCommand.ExecuteNonQuery()
            End If

            'Update the lasch customer transactions
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LaschCustomerTransactions ([AccountNumber],[TransDate]," _
                    & "[Debit],[Description],[DocumentNumber],[UserName],[ChangeDate]) " _
                    & "VALUES('" & txtAccountNumber.Text & "', '" & Format(Now, "dd-MMM-yyyy") & "', " _
                    & "" & dblPremiums & ", 'INIATILIZATION PREMIUMS', '" & intSpecialKey & "', " _
                    & "'" & strUserName & "', '" & Now & "')", cnn)
            myCommand.ExecuteNonQuery()

            InputTransactions.Complete()

        End Using
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Lasch Customer Record Creation"
        ShowErrorMessage()
    End Sub

    Private Function PremiumsDue() As Double
        Dim dblReturn As Double = 0
        For i As Integer = 0 To dGridCrops.Rows.Count - 1
            If IsNumeric(dGridCrops.Rows(i).Cells(5).Value) Then dblReturn = dblReturn + CDbl(dGridCrops.Rows(i).Cells(5).Value.ToString)
        Next
        Return dblReturn
    End Function

    Private Sub UpdateRecord()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim dblHectare As Double = 0
        Dim dblFmlPremiums As Double = 0
        Dim strFmlPlan As String = "Life Cover"
        Dim dblFmlAssured As Double = 0
        Dim dblHamiltonPrems As Double = 0
        Dim strHamiltonPlan As String = "Harvest Cover"
        Dim dblHamiltonAssured As Double = 0
        Dim dblTotalPrems As Double = 0
        Dim dblSumAssured As Double = 0
        Dim strCrop As String = Nothing

        If chkOverLimit.Checked = True Then
            For i As Integer = 0 To dGridCropsOverLimit.Rows.Count - 1
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(1).Value) Then dblHectare = dblHectare + CDbl(dGridCropsOverLimit.Rows(i).Cells(1).Value.ToString)
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(2).Value) Then dblFmlPremiums = dblFmlPremiums + CDbl(dGridCropsOverLimit.Rows(i).Cells(2).Value.ToString)
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(3).Value) Then dblHamiltonPrems = dblHamiltonPrems + CDbl(dGridCropsOverLimit.Rows(i).Cells(3).Value.ToString)
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(4).Value) Then dblSumAssured = dblSumAssured + CDbl(dGridCropsOverLimit.Rows(i).Cells(4).Value.ToString)
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(5).Value) Then dblTotalPrems = CDbl(dGridCropsOverLimit.Rows(i).Cells(5).Value.ToString)
            Next
        Else
            For i As Integer = 0 To dGridCrops.Rows.Count - 1
                If IsNumeric(dGridCrops.Rows(i).Cells(1).Value) Then dblHectare = dblHectare + CDbl(dGridCrops.Rows(i).Cells(1).Value.ToString)
                If IsNumeric(dGridCrops.Rows(i).Cells(2).Value) Then dblFmlPremiums = dblFmlPremiums + CDbl(dGridCrops.Rows(i).Cells(2).Value.ToString)
                If IsNumeric(dGridCrops.Rows(i).Cells(3).Value) Then dblHamiltonPrems = dblHamiltonPrems + CDbl(dGridCrops.Rows(i).Cells(3).Value.ToString)
                If IsNumeric(dGridCrops.Rows(i).Cells(4).Value) Then dblSumAssured = dblSumAssured + CDbl(dGridCrops.Rows(i).Cells(4).Value.ToString)
                If IsNumeric(dGridCrops.Rows(i).Cells(5).Value) Then dblTotalPrems = CDbl(dGridCrops.Rows(i).Cells(5).Value.ToString)
            Next
        End If

        Dim strData As String = dpDob.Text
        Dim strValues() As String = Split(strData, "-")
        Dim strDate As String = strValues(0) & "-" & getMonth(CInt(strValues(1))) & "-" & strValues(2)

        Dim strSql As String = "UPDATE LaschCustomers SET [Title] = '" & cboTitle.Text & "', " _
            & "[LastName] = '" & txtLastName.Text & "', [FirstName] = '" & txtFirstName.Text & "', [OtherNames] = '" & txtOtherNames.Text & "', " _
            & "[DateOfBirth] = '" & strDate & "', [IdNumber] = '" & txtIdNumber.Text & "', " _
            & "[Address1] = '" & txtAddress1.Text & "', [Address2] = '" & txtAddress2.Text & "', [Address3] = '" & txtAddress3.Text & "', " _
            & "[Address4] = '" & txtAddress4.Text & "', [Telephone] = '" & txtTelephone.Text & "', [Cellphone] = '" & txtCellphone.Text & "', " _
            & "[EmailAddress] = '" & txtEmailAddress.Text & "', [KinName] = '" & txtKinName.Text & "', [KinContactNo] = '" & txtKinCellphone.Text & "', " _
            & "[FarmName] = '" & txtFarmName.Text & "', [Province] = '" & cboProvince.Text & "', [District] = '" & cboDistrict.Text & "', " _
            & "[Ward] = '" & txtWard.Text & "', [ChiefName] = '" & txtChief.Text & "', [Acreage] = " & dblHectare & ", " _
            & "[FarmerOrganisation] = '" & txtFarmerOrganisation.Text & "', [AgritexOfficer] = '" & txtAgritexOfficer.Text & "', " _
            & "[LaschOfficer] = '" & txtLaschOfficer.Text & "', [FmlPlan] = '" & strFmlPlan & "', [FmlSumAssured] = " & dblSumAssured & ", " _
            & "[FmlPremium] = " & dblFmlPremiums & ", [FmlOfficer] = '" & txtFmlOfficial.Text & "', [HamiltonPlan] = '" & strHamiltonPlan & "', " _
            & "[HamiltonSumAssured] = " & dblSumAssured & ", [HamiltonPremium] = " & dblHamiltonPrems & ", " _
            & "[HamiltonOfficer] = '" & txtHamiltonOfficial.Text & "', Gender = '" & cboGender.Text & "', FarmType = '" & cboFarmType.Text & "', " _
            & "Crop = '" & strCrop & "' WHERE [AccountNumber] =  '" & txtAccountNumber.Text & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Delete any previous crop matrix records and add new ones

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Lasch Customer Record Update"
        ShowErrorMessage()
    End Sub

    Private Sub CreateRecord()
        On Error GoTo RaiseErr
        txtAccountNumber.Text = LaschNextCustomerNumber(cboProvince.Text, cboDistrict.Text)

        Dim dblHectare As Double = 0
        Dim dblFmlPremiums As Double = 0
        Dim strFmlPlan As String = "Life Cover"
        Dim dblFmlAssured As Double = 0
        Dim dblHamiltonPrems As Double = 0
        Dim strHamiltonPlan As String = "Harvest Cover"
        Dim dblHamiltonAssured As Double = 0
        Dim dblTotalPrems As Double = 0
        Dim dblSumAssured As Double = 0
        Dim strCrop As String = Nothing

        If chkOverLimit.Checked = True Then
            For i As Integer = 0 To dGridCropsOverLimit.Rows.Count - 1
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(1).Value) Then dblHectare = dblHectare + CDbl(dGridCropsOverLimit.Rows(i).Cells(1).Value.ToString)
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(2).Value) Then dblFmlPremiums = dblFmlPremiums + CDbl(dGridCropsOverLimit.Rows(i).Cells(2).Value.ToString)
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(3).Value) Then dblHamiltonPrems = dblHamiltonPrems + CDbl(dGridCropsOverLimit.Rows(i).Cells(3).Value.ToString)
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(4).Value) Then dblSumAssured = dblSumAssured + CDbl(dGridCropsOverLimit.Rows(i).Cells(4).Value.ToString)
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(5).Value) Then dblTotalPrems = CDbl(dGridCropsOverLimit.Rows(i).Cells(5).Value.ToString)
            Next
        Else
            For i As Integer = 0 To dGridCrops.Rows.Count - 1
                If IsNumeric(dGridCrops.Rows(i).Cells(1).Value) Then dblHectare = dblHectare + CDbl(dGridCrops.Rows(i).Cells(1).Value.ToString)
                If IsNumeric(dGridCrops.Rows(i).Cells(2).Value) Then dblFmlPremiums = dblFmlPremiums + CDbl(dGridCrops.Rows(i).Cells(2).Value.ToString)
                If IsNumeric(dGridCrops.Rows(i).Cells(3).Value) Then dblHamiltonPrems = dblHamiltonPrems + CDbl(dGridCrops.Rows(i).Cells(3).Value.ToString)
                If IsNumeric(dGridCrops.Rows(i).Cells(4).Value) Then dblSumAssured = dblSumAssured + CDbl(dGridCrops.Rows(i).Cells(4).Value.ToString)
                If IsNumeric(dGridCrops.Rows(i).Cells(5).Value) Then dblTotalPrems = CDbl(dGridCrops.Rows(i).Cells(5).Value.ToString)
            Next
        End If

        Dim strData As String = dpDob.Text
        Dim strValues() As String = Split(strData, "-")
        Dim strDate As String = strValues(0) & "-" & getMonth(CInt(strValues(1))) & "-" & strValues(2)

        Dim strSql As String = "INSERT INTO LaschCustomers ([AccountNumber], [Title], [LastName], [FirstName], [OtherNames], " _
            & "[DateOfBirth], [IdNumber], [Address1], [Address2], [Address3], [Address4], [Telephone], [Cellphone], " _
            & "[EmailAddress], [KinName], [KinContactNo], [FarmName], [Province], [District], [Ward], [ChiefName], " _
            & "[Acreage], [FarmerOrganisation], [AgritexOfficer], [LaschOfficer], [FmlPlan], [FmlSumAssured], [FmlPremium], " _
            & "[FmlOfficer], [HamiltonPlan], [HamiltonSumAssured], [HamiltonPremium], [HamiltonOfficer], [FarmType], [Gender]) VALUES " _
            & "('" & txtAccountNumber.Text & "', '" & cboTitle.Text & "', '" & txtLastName.Text & "', '" & txtFirstName.Text & "', '" & txtOtherNames.Text & "', " _
            & "'" & strDate & "', '" & txtIdNumber.Text & "', '" & txtAddress1.Text & "', '" & txtAddress2.Text & "', '" & txtAddress3.Text & "', '" & txtAddress4.Text & "', '" & txtTelephone.Text & "', '" & txtCellphone.Text & "', " _
            & "'" & txtEmailAddress.Text & "', '" & txtKinName.Text & "', '" & txtKinCellphone.Text & "', '" & txtFarmName.Text & "', '" & cboProvince.Text & "', '" & cboDistrict.Text & "', '" & txtWard.Text & "', '" & txtChief.Text & "', " _
            & "" & dblHectare & ", '" & txtFarmerOrganisation.Text & "', '" & txtAgritexOfficer.Text & "', '" & txtLaschOfficer.Text & "', '" & strFmlPlan & "', " & dblSumAssured & ", " & dblFmlPremiums & ", " _
            & "'" & txtFmlOfficial.Text & "', '" & strHamiltonPlan & "', " & dblSumAssured & ", " & dblHamiltonPrems & ", " _
            & "'" & txtHamiltonOfficial.Text & "', '" & cboFarmType.Text & "', '" & cboGender.Text & "')"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Lasch Customer Record Creation"
        ShowErrorMessage()
    End Sub

    Private Sub frmLaschCustomer_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        boolLoading = True
        txtAccountNumber.Enabled = False
        TabControl1.SelectedTabIndex = 0
        LoadProvinces()
        LoadCrops()
        If boolEditStatus = True Then
            LoadSelectedData()
            LoadPremiumsData()
            LoadTransactions()
        End If
        boolLoading = False
    End Sub

    Private Sub LoadSelectedData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM LaschCustomers WHERE AccountNumber = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()

            If Not IsDBNull(objReader("AccountNumber").ToString) Then txtAccountNumber.Text = objReader("AccountNumber").ToString
            If Not IsDBNull(objReader("Title").ToString) Then cboTitle.Text = objReader("Title").ToString
            If Not IsDBNull(objReader("LastName").ToString) Then txtLastName.Text = objReader("LastName").ToString
            If Not IsDBNull(objReader("FirstName").ToString) Then txtFirstName.Text = objReader("FirstName").ToString
            If Not IsDBNull(objReader("OtherNames").ToString) Then txtOtherNames.Text = objReader("OtherNames").ToString
            If Not IsDBNull(objReader("DateOfBirth").ToString) Then dpDob.Text = Format(CDate(objReader("DateOfBirth").ToString), "dd-MM-yyyy")
            If Not IsDBNull(objReader("IdNumber").ToString) Then txtIdNumber.Text = objReader("IdNumber").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("KinName").ToString) Then txtKinName.Text = objReader("KinName").ToString
            If Not IsDBNull(objReader("KinContactNo").ToString) Then txtKinCellphone.Text = objReader("KinContactNo").ToString
            If Not IsDBNull(objReader("FarmName").ToString) Then txtFarmName.Text = objReader("FarmName").ToString
            If Not IsDBNull(objReader("Province").ToString) Then cboProvince.Text = objReader("Province").ToString
            If Not IsDBNull(objReader("District").ToString) Then cboDistrict.Text = objReader("District").ToString
            If Not IsDBNull(objReader("Ward").ToString) Then txtWard.Text = objReader("Ward").ToString
            If Not IsDBNull(objReader("ChiefName").ToString) Then txtChief.Text = objReader("ChiefName").ToString
            If IsNumeric(objReader("Acreage").ToString) Then dblFarmAcreage = Format(CDbl(objReader("Acreage").ToString), "##0.00") Else dblFarmAcreage = 0
            If dblFarmAcreage > 6 Then
                chkOverLimit.Checked = True
            Else
                chkOverLimit.Checked = False
            End If
            If Not IsDBNull(objReader("FarmerOrganisation").ToString) Then txtFarmerOrganisation.Text = objReader("FarmerOrganisation").ToString
            If Not IsDBNull(objReader("AgritexOfficer").ToString) Then txtAgritexOfficer.Text = objReader("AgritexOfficer").ToString
            If Not IsDBNull(objReader("LaschOfficer").ToString) Then txtLaschOfficer.Text = objReader("LaschOfficer").ToString
            'If Not IsDBNull(objReader("FmlPlan").ToString) Then txtFmlPlan.Text = objReader("FmlPlan").ToString
            'If IsNumeric(objReader("FmlSumAssured").ToString) Then txtFmlSumAssured.Text = Format(CDbl(objReader("FmlSumAssured").ToString), "##0.00") Else txtFmlSumAssured.Text = "0.00"
            'If IsNumeric(objReader("FmlPremium").ToString) Then txtFmlPremium.Text = Format(CDbl(objReader("FmlPremium").ToString), "##0.00") Else txtFmlPremium.Text = "0.00"
            If Not IsDBNull(objReader("FmlOfficer").ToString) Then txtFmlOfficial.Text = objReader("FmlOfficer").ToString
            'If Not IsDBNull(objReader("HamiltonPlan").ToString) Then txtHamiltonPlan.Text = objReader("HamiltonPlan").ToString
            'If IsNumeric(objReader("HamiltonSumAssured").ToString) Then txtHamiltonSumAssured.Text = Format(CDbl(objReader("HamiltonSumAssured").ToString), "##0.00") Else txtHamiltonSumAssured.Text = "0.00"
            'If IsNumeric(objReader("HamiltonPremium").ToString) Then txtHamiltonPremium.Text = Format(CDbl(objReader("HamiltonPremium").ToString), "##0.00") Else txtHamiltonPremium.Text = "0.00"
            If Not IsDBNull(objReader("HamiltonOfficer").ToString) Then txtHamiltonOfficial.Text = objReader("HamiltonOfficer").ToString

            If Not IsDBNull(objReader("FarmType").ToString) Then cboFarmType.Text = objReader("FarmType").ToString
            If Not IsDBNull(objReader("Gender").ToString) Then cboGender.Text = objReader("Gender").ToString
            'If Not IsDBNull(objReader("Crop").ToString) Then .Text = objReader("Crop").ToString

        End If
        objReader.Close()
        txtAccountNumber.Enabled = False
        'ComputePremium(CDbl(txtFmlSumAssured.Text))
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Lasch Customer Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadTransactions()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, TransDate, 105) AS [DATE], DocumentNumber AS [Doc.#], " _
            & "Description, CAST(Debit AS DECIMAL (10,2)) AS [Debit], CAST(Credit AS DECIMAL (10,2)) AS [Credit] " _
            & "FROM LaschCustomerTransactions WHERE AccountNumber = '" & strSelectedAccount & "' ORDER BY TransDate"
        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable
        For p As Integer = 0 To dGrid.Columns.Count - 1
            If p = 3 Or p = 4 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next

        'Compute the balance
        Dim dblDebits As Double = 0
        Dim dblCredits As Double = 0

        For i As Integer = 0 To dGrid.Rows.Count - 1
            If IsNumeric(dGrid.Rows(i).Cells(3).Value) Then dblDebits = dblDebits + CDbl(dGrid.Rows(i).Cells(3).Value.ToString)
            If IsNumeric(dGrid.Rows(i).Cells(4).Value) Then dblCredits = dblCredits + CDbl(dGrid.Rows(i).Cells(4).Value.ToString)
        Next
        lblBalance.Text = Format((dblDebits - dblCredits), "##0.00")

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Lasch Customer Transactions Load"
        ShowErrorMessage()
    End Sub

    Private Sub ComputePremium(ByRef Amount As Double)
        Dim dblAge As Double = DateDiff(DateInterval.Year, CDate(Format(CDate(dpDob.Text), "dd-MMM-yyyy")), Now)
    End Sub

    Private Sub btnAddProvince_Click(sender As System.Object, e As System.EventArgs) Handles btnAddProvince.Click
        Dim boolStatusBefore As Boolean = boolEditStatus
        boolEditStatus = False
        Dim f As New frmLaschProvinceSetup
        f.ShowDialog()
        boolEditStatus = boolStatusBefore
        LoadProvinces()
    End Sub

    Private Sub btnAddDistrict_Click(sender As System.Object, e As System.EventArgs) Handles btnAddDistrict.Click
        Dim boolStatusBefore As Boolean = boolEditStatus
        If String.IsNullOrEmpty(cboProvince.Text) Then
            MessageBox.Show("You have to select the province first before adding a district", "Missing Province", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboProvince.Focus()
            Exit Sub
        Else
            boolEditStatus = True
            strSelectedCategory = cboProvince.Text
            boolEditStatus = True
            Dim f As New frmLaschProvinceSetup
            f.ShowDialog()
            boolEditStatus = boolStatusBefore
            LoadProvinces()
            cboProvince.Text = strSelectedCategory
        End If
    End Sub

    Private Sub LoadProvinces()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Province FROM Provinces ORDER BY Province", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        cboProvince.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboProvince.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Provinces Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadDistricts(ByVal strProvince As String)
        On Error GoTo RaiseErr
        If boolLoading = True Then Exit Sub
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT distinct District FROM Districts " _
                & "WHERE Province = '" & strProvince & "' ORDER BY District", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        cboDistrict.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboDistrict.Items.Add(objReader(0).ToString)
        End While
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On District Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboProvince_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProvince.SelectedIndexChanged
        boolLoading = False
        LoadDistricts(cboProvince.Text)
    End Sub

    Private Sub dGridCrops_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridCrops.CellEndEdit
        If boolLoading = True Then Exit Sub
        With dGridCrops
            If e.ColumnIndex = 1 Then
                If String.IsNullOrEmpty(cboFarmType.Text) Then
                    MessageBox.Show("Please select the farm type", "Missing Farm Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    .CurrentCell.Value = "0.00"
                    cboFarmType.Focus()
                    Exit Sub
                End If
                If IsNumeric(.CurrentCell.Value) Then
                    Dim arrValues As New ArrayList
                    arrValues = HamiltonPremiums(cboFarmType.Text, .CurrentRow.Cells(0).Value.ToString, .CurrentCell.Value)
                    Dim dblPartPremium As Double = 0
                    If IsNumeric(arrValues.Item(1)) Then
                        dblPartPremium = (CDbl(arrValues.Item(1)) * CDbl(.CurrentCell.Value.ToString)) * 0.04
                    End If
                    .CurrentRow.Cells(3).Value = Format((CDbl(arrValues.Item(0).ToString) + dblPartPremium), "##0.00")
                    .CurrentRow.Cells(4).Value = Format(CDbl(arrValues.Item(1).ToString) * CDbl(.CurrentCell.Value.ToString), "##0.00")
                    Dim dblFmlPremium As Double = FmlPremium(txtAge2.Text, (CDbl(arrValues.Item(1).ToString) * CDbl(.CurrentCell.Value.ToString)))
                    .CurrentRow.Cells(2).Value = Format(dblFmlPremium, "##0.00")
                    .CurrentRow.Cells(5).Value = Format((CDbl(.CurrentRow.Cells(2).Value.ToString) + CDbl(.CurrentRow.Cells(3).Value.ToString)), "##0.00")
                    .CurrentCell.Value = Format(CDbl(.CurrentCell.Value.ToString), "##0.00")
                End If
            End If
        End With
    End Sub

    Private Sub LoadCrops()
        On Error GoTo RaiseErr
        boolAbort = False
        'Reload the details to the grid
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Crop FROM LaschApprovedCrops ORDER BY Crop", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        dGridCrops.Rows.Clear()
        dGridCropsOverLimit.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then dGridCrops.Rows.Add(objReader(0).ToString)
            If Not IsDBNull(objReader(0).ToString) Then dGridCropsOverLimit.Rows.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Crop Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadPremiumsData()
        On Error GoTo RaiseErr

        Dim dblSize As Double = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Acreage FROM LaschCustomers WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblSize = CDbl(objReader(0).ToString)
        End If
        objReader.Close()

        If dblSize <= 6 Then
            For i As Integer = 0 To dGridCrops.Rows.Count - 1
                If Not Object.Equals(Convert.ToString(dGridCrops.Rows(i).Cells(0).Value), "") Then
                    Dim strCrop As String = dGridCrops.Rows(i).Cells(0).Value.ToString
                    objCommand = New Data.OleDb.OleDbCommand("SELECT CAST(Hectarage AS DECIMAL (10,2)) AS [Ha], " _
                        & "CAST(FmlPremium AS DECIMAL (10,2)) AS [Fml], CAST(HamiltonPremium AS DECIMAL (10,2)) AS [Hamil], " _
                        & "CAST(Assurance AS DECIMAL (10,2)) AS [Assured], CAST(TotalPremiums AS DECIMAL (10,2)) AS [Total] " _
                        & "FROM LaschCustomersPremiumMatrix WHERE AccountNumber = '" & strSelectedAccount & "' AND Crop = '" & strCrop & "'", cnn)
                    objReader = objCommand.ExecuteReader
                    'LaschCustomersPremiumMatrix
                    If objReader.HasRows Then
                        objReader.Read()
                        If IsNumeric(objReader(0).ToString) Then dGridCrops.Rows(i).Cells(1).Value = Format(CDbl(objReader(0).ToString), "##0.00")
                        If IsNumeric(objReader(1).ToString) Then dGridCrops.Rows(i).Cells(2).Value = Format(CDbl(objReader(1).ToString), "##0.00")
                        If IsNumeric(objReader(2).ToString) Then dGridCrops.Rows(i).Cells(3).Value = Format(CDbl(objReader(2).ToString), "##0.00")
                        If IsNumeric(objReader(3).ToString) Then dGridCrops.Rows(i).Cells(4).Value = Format(CDbl(objReader(3).ToString), "##0.00")
                        If IsNumeric(objReader(4).ToString) Then dGridCrops.Rows(i).Cells(5).Value = Format(CDbl(objReader(4).ToString), "##0.00")
                    End If
                    objReader.Close()
                End If
            Next

        Else
            'Load the data to the over limit grid

            For i As Integer = 0 To dGridCropsOverLimit.Rows.Count - 1
                If Not Object.Equals(Convert.ToString(dGridCropsOverLimit.Rows(i).Cells(0).Value), "") Then
                    Dim strCrop As String = dGridCropsOverLimit.Rows(i).Cells(0).Value.ToString
                    objCommand = New Data.OleDb.OleDbCommand("SELECT CAST(Hectarage AS DECIMAL (10,2)) AS [Ha], " _
                        & "CAST(FmlPremium AS DECIMAL (10,2)) AS [Fml], CAST(HamiltonPremium AS DECIMAL (10,2)) AS [Hamil], " _
                        & "CAST(Assurance AS DECIMAL (10,2)) AS [Assured], CAST(TotalPremiums AS DECIMAL (10,2)) AS [Total] " _
                        & "FROM LaschCustomersPremiumMatrix WHERE AccountNumber = '" & strSelectedAccount & "' AND Crop = '" & strCrop & "'", cnn)
                    objReader = objCommand.ExecuteReader
                    'LaschCustomersPremiumMatrix
                    If objReader.HasRows Then
                        objReader.Read()
                        If IsNumeric(objReader(0).ToString) Then dGridCropsOverLimit.Rows(i).Cells(1).Value = Format(CDbl(objReader(0).ToString), "##0.00")
                        If IsNumeric(objReader(1).ToString) Then dGridCropsOverLimit.Rows(i).Cells(2).Value = Format(CDbl(objReader(1).ToString), "##0.00")
                        If IsNumeric(objReader(2).ToString) Then dGridCropsOverLimit.Rows(i).Cells(3).Value = Format(CDbl(objReader(2).ToString), "##0.00")
                        If IsNumeric(objReader(3).ToString) Then dGridCropsOverLimit.Rows(i).Cells(4).Value = Format(CDbl(objReader(3).ToString), "##0.00")
                        If IsNumeric(objReader(4).ToString) Then dGridCropsOverLimit.Rows(i).Cells(5).Value = Format(CDbl(objReader(4).ToString), "##0.00")
                    End If
                    objReader.Close()
                End If
            Next

        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Crop Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub SavePremiumsData()
        On Error GoTo RaiseErr

        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM LaschCustomersPremiumMatrix " _
            & "WHERE AccountNumber = '" & txtAccountNumber.Text & "'", cnn)
        objCommand.ExecuteNonQuery()

        If chkOverLimit.Checked = True Then

            For i As Integer = 0 To dGridCropsOverLimit.Rows.Count - 1
                If Not Object.Equals(Convert.ToString(dGridCropsOverLimit.Rows(i).Cells(0).Value), "") Then
                    Dim strCrop As String = dGridCropsOverLimit.Rows(i).Cells(0).Value.ToString
                    If Not Object.Equals(Convert.ToString(dGridCropsOverLimit.Rows(i).Cells(1).Value), "") Then
                        If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(1).Value.ToString) Then
                            If CDbl(dGridCropsOverLimit.Rows(i).Cells(1).Value.ToString) <> 0 Then
                                Dim dblHectare As Double = 0
                                Dim dblFml As Double = 0
                                Dim dblHamilton As Double = 0
                                Dim dblAssurance As Double = 0
                                Dim dblTotalPrems As Double = 0
                                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(1).Value) Then dblHectare = CDbl(dGridCropsOverLimit.Rows(i).Cells(1).Value.ToString)
                                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(2).Value) Then dblFml = CDbl(dGridCropsOverLimit.Rows(i).Cells(2).Value.ToString)
                                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(3).Value) Then dblHamilton = CDbl(dGridCropsOverLimit.Rows(i).Cells(3).Value.ToString)
                                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(4).Value) Then dblAssurance = CDbl(dGridCropsOverLimit.Rows(i).Cells(4).Value.ToString)
                                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(5).Value) Then dblTotalPrems = CDbl(dGridCropsOverLimit.Rows(i).Cells(5).Value.ToString)

                                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LaschCustomersPremiumMatrix " _
                                    & "(Hectarage, FmlPremium, HamiltonPremium, Assurance, TotalPremiums, AccountNumber, Crop) VALUES " _
                                    & "(" & dblHectare & ", " & dblFml & ", " & dblHamilton & ", " & dblAssurance & ", " _
                                    & "" & dblTotalPrems & ", '" & txtAccountNumber.Text & "', '" & strCrop & "')", cnn)
                                objCommand.ExecuteNonQuery()
                            End If
                        End If
                    End If
                End If
            Next

        Else

            For i As Integer = 0 To dGridCrops.Rows.Count - 1
                If Not Object.Equals(Convert.ToString(dGridCrops.Rows(i).Cells(0).Value), "") Then
                    Dim strCrop As String = dGridCrops.Rows(i).Cells(0).Value.ToString
                    If Not Object.Equals(Convert.ToString(dGridCrops.Rows(i).Cells(1).Value), "") Then
                        If IsNumeric(dGridCrops.Rows(i).Cells(1).Value.ToString) Then
                            If CDbl(dGridCrops.Rows(i).Cells(1).Value.ToString) <> 0 Then
                                Dim dblHectare As Double = 0
                                Dim dblFml As Double = 0
                                Dim dblHamilton As Double = 0
                                Dim dblAssurance As Double = 0
                                Dim dblTotalPrems As Double = 0
                                If IsNumeric(dGridCrops.Rows(i).Cells(1).Value) Then dblHectare = CDbl(dGridCrops.Rows(i).Cells(1).Value.ToString)
                                If IsNumeric(dGridCrops.Rows(i).Cells(2).Value) Then dblFml = CDbl(dGridCrops.Rows(i).Cells(2).Value.ToString)
                                If IsNumeric(dGridCrops.Rows(i).Cells(3).Value) Then dblHamilton = CDbl(dGridCrops.Rows(i).Cells(3).Value.ToString)
                                If IsNumeric(dGridCrops.Rows(i).Cells(4).Value) Then dblAssurance = CDbl(dGridCrops.Rows(i).Cells(4).Value.ToString)
                                If IsNumeric(dGridCrops.Rows(i).Cells(5).Value) Then dblTotalPrems = CDbl(dGridCrops.Rows(i).Cells(5).Value.ToString)

                                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LaschCustomersPremiumMatrix " _
                                    & "(Hectarage, FmlPremium, HamiltonPremium, Assurance, TotalPremiums, AccountNumber, Crop) VALUES " _
                                    & "(" & dblHectare & ", " & dblFml & ", " & dblHamilton & ", " & dblAssurance & ", " _
                                    & "" & dblTotalPrems & ", '" & txtAccountNumber.Text & "', '" & strCrop & "')", cnn)
                                objCommand.ExecuteNonQuery()
                            End If
                        End If
                    End If
                End If
            Next

        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Premiums save"
        ShowErrorMessage()
    End Sub

    Private Sub dpDob_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dpDob.Validating
        If Not String.IsNullOrEmpty(dpDob.Text) Then
            Dim strData As String = dpDob.Text
            Dim strValues() As String = Split(strData, "-")
            If strValues.Length < 3 Then
                GoTo RaiseErrorMessage
                Exit Sub
            End If
            If Not IsNumeric(strValues(0)) Then
                GoTo RaiseErrorMessage
                Exit Sub
            End If
            If Not IsNumeric(strValues(1)) Then
                GoTo RaiseErrorMessage
                Exit Sub
            Else
                If CInt(strValues(1)) > 12 Then
                    GoTo RaiseErrorMessage
                    Exit Sub
                End If
            End If

            If Not IsNumeric(strValues(2)) Then
                GoTo RaiseErrorMessage
                Exit Sub
            End If

            Dim strDate As String = strValues(0) & "-" & getMonth(CInt(strValues(1))) & "-" & strValues(2)
            If Not IsDate(strDate) Then
                GoTo RaiseErrorMessage
                Exit Sub
            End If
        Else
            GoTo RaiseErrorMessage
            Exit Sub
        End If
        Exit Sub
RaiseErrorMessage:
        MessageBox.Show("The date of birth does not seem to be valid. Please check", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub cboTitle_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTitle.KeyPress
        If Asc(e.KeyChar) = 13 Then cboGender.Focus()
    End Sub

    Private Sub cboTitle_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTitle.SelectedIndexChanged
        Select Case UCase(cboTitle.Text)
            Case Is = "MS"
                cboGender.Text = "FEMALE"
            Case Is = "MISS"
                cboGender.Text = "FEMALE"
            Case Is = "MRS"
                cboGender.Text = "FEMALE"
            Case Else
                cboGender.Text = "MALE"
        End Select
    End Sub

    Private Sub cboGender_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboGender.KeyPress
        If Asc(e.KeyChar) = 13 Then txtFirstName.Focus()
    End Sub

    Private Sub txtFirstName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFirstName.KeyPress
        If Asc(e.KeyChar) = 13 Then txtLastName.Focus()
    End Sub
    Private Sub txtLastName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLastName.KeyPress
        If Asc(e.KeyChar) = 13 Then txtOtherNames.Focus()
    End Sub
    Private Sub txtOtherNames_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherNames.KeyPress
        If Asc(e.KeyChar) = 13 Then dpDob.Focus()
    End Sub
    Private Sub dpDob_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dpDob.KeyPress
        If Asc(e.KeyChar) = 13 Then txtIdNumber.Focus()
    End Sub
    Private Sub txtIdNumber_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAddress1.Focus()
    End Sub
    Private Sub txtAddress1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress1.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAddress2.Focus()
    End Sub
    Private Sub txtAddress2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress2.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAddress3.Focus()
    End Sub
    Private Sub txtAddress3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress3.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAddress4.Focus()
    End Sub
    Private Sub txtAddress4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress4.KeyPress
        If Asc(e.KeyChar) = 13 Then txtTelephone.Focus()
    End Sub
    Private Sub txtTelephone_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelephone.KeyPress
        If Asc(e.KeyChar) = 13 Then txtCellphone.Focus()
    End Sub
    Private Sub txtCellphone_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCellphone.KeyPress
        If Asc(e.KeyChar) = 13 Then txtEmailAddress.Focus()
    End Sub
    Private Sub txtEmailAddress_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailAddress.KeyPress
        If Asc(e.KeyChar) = 13 Then txtKinName.Focus()
    End Sub
    Private Sub txtKinName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtKinName.KeyPress
        If Asc(e.KeyChar) = 13 Then txtKinCellphone.Focus()
    End Sub
    Private Sub txtKinCellphone_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtKinCellphone.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TabControl1.SelectedTabIndex = 1
            txtFarmName.Focus()
        End If
    End Sub


    Private Sub txtFarmName_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFarmName.KeyPress
        If Asc(e.KeyChar) = 13 Then cboProvince.Focus()
    End Sub
    Private Sub cboProvince_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboProvince.KeyPress
        If Asc(e.KeyChar) = 13 Then cboDistrict.Focus()
    End Sub
    Private Sub cboDistrict_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboDistrict.KeyPress
        If Asc(e.KeyChar) = 13 Then txtWard.Focus()
    End Sub
    Private Sub txtWard_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtWard.KeyPress
        If Asc(e.KeyChar) = 13 Then txtChief.Focus()
    End Sub
    Private Sub txtChief_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtChief.KeyPress
        If Asc(e.KeyChar) = 13 Then cboFarmType.Focus()
    End Sub
    Private Sub cboFarmType_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboFarmType.KeyPress
        If Asc(e.KeyChar) = 13 Then dGridCrops.Focus()
    End Sub


    Private Sub txtFmlOfficial_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFmlOfficial.KeyPress
        If Asc(e.KeyChar) = 13 Then txtHamiltonOfficial.Focus()
    End Sub
    Private Sub txtHamiltonOfficial_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtHamiltonOfficial.KeyPress
        If Asc(e.KeyChar) = 13 Then txtFarmerOrganisation.Focus()
    End Sub
    Private Sub txtFarmerOrganisation_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFarmerOrganisation.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAgritexOfficer.Focus()
    End Sub
    Private Sub txtAgritexOfficer_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAgritexOfficer.KeyPress
        If Asc(e.KeyChar) = 13 Then txtLaschOfficer.Focus()
    End Sub
    Private Sub txtLaschOfficer_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLaschOfficer.KeyPress
        If Asc(e.KeyChar) = 13 Then btnOk.Focus()
    End Sub
    
    Private Sub dGridCrops_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridCrops.EditingControlShowing
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

    Private Sub chkOverLimit_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOverLimit.CheckedChanged
        If chkOverLimit.Checked = True Then
            TabControl2.SelectedIndex = 1
            dGridCropsOverLimit.Enabled = True
            dGridCrops.Enabled = False
        Else
            TabControl2.SelectedIndex = 0
            dGridCropsOverLimit.Enabled = False
            dGridCrops.Enabled = True
        End If
    End Sub

    Private Sub dGridCropsOverLimit_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridCropsOverLimit.CellEndEdit
        If e.ColumnIndex >= 1 And e.ColumnIndex <= 4 Then
            If Not IsNumeric(dGridCropsOverLimit.CurrentCell.Value) Then
                dGridCropsOverLimit.CurrentCell.Value = "0.00"
            Else
                dGridCropsOverLimit.CurrentCell.Value = Format(CDbl(dGridCropsOverLimit.CurrentCell.Value.ToString), "##0.00")
            End If
            ComputeCropsOverLimitPremiumsTotals()
        End If
    End Sub

    Private Sub ComputeCropsOverLimitPremiumsTotals()
        
        For i As Integer = 0 To dGridCropsOverLimit.Rows.Count - 1

            Dim Hectare As Double = 0
            Dim FmlPrem As Double = 0
            Dim HamPrem As Double = 0
            Dim Assured As Double = 0
            Dim TotalPrem As Double = 0

            If Not Object.Equals(dGridCropsOverLimit.Rows(i).Cells(1).Value, Nothing) Then
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(1).Value) Then
                    Hectare = CDbl(dGridCropsOverLimit.Rows(i).Cells(1).Value.ToString)
                End If
            End If
            If Not Object.Equals(dGridCropsOverLimit.Rows(i).Cells(2).Value, Nothing) Then
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(2).Value) Then
                    FmlPrem = CDbl(dGridCropsOverLimit.Rows(i).Cells(2).Value.ToString)
                End If
            End If
            If Not Object.Equals(dGridCropsOverLimit.Rows(i).Cells(3).Value, Nothing) Then
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(3).Value) Then
                    HamPrem = CDbl(dGridCropsOverLimit.Rows(i).Cells(3).Value.ToString)
                End If
            End If
            If Not Object.Equals(dGridCropsOverLimit.Rows(i).Cells(4).Value, Nothing) Then
                If IsNumeric(dGridCropsOverLimit.Rows(i).Cells(4).Value) Then
                    Assured = CDbl(dGridCropsOverLimit.Rows(i).Cells(4).Value.ToString)
                End If
            End If
            dGridCropsOverLimit.Rows(i).Cells(5).Value = Format((FmlPrem + HamPrem), "##0.0")

        Next

    End Sub

End Class
