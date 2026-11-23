Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPlaintifDetails

    Private Sub UpdateData(ByVal AccountType As String, ByVal SaveType As String)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        Dim strIdNumber As String = Nothing
        Dim strGivenNames As String = txtAccountName.Text
        Dim strBirthDate As String = Nothing
        Dim strGender As String = "NONE"
        Dim strHomeType As String = Nothing
        Dim strMaritalStatus As String = "NONE"
        Dim strTitle As String = Nothing

        If UCase(AccountType) = "INDIVIDUAL" Then strIdNumber = txtIdNumber.Text
        If UCase(AccountType) = "INDIVIDUAL" Then strBirthDate = CStr(Format(dpBirthDate.Value, "dd-MMM-yyyy"))
        If UCase(AccountType) = "INDIVIDUAL" Then strGender = cboGender.Text
        If UCase(AccountType) = "INDIVIDUAL" Then strHomeType = cboHomeType.Text
        If UCase(AccountType) = "INDIVIDUAL" Then strMaritalStatus = cboMaritalStatus.Text
        If UCase(AccountType) = "INDIVIDUAL" Then strTitle = cboSalutation.Text

        If boolEditStatus = False Then
            'Insert into the main table
            strSql = "INSERT INTO Plaintifs ([PlaintifId], [GivenNames], [Address1], [Address2], " _
                & "[Address3], [Address4], [Telephone], [EmailAddress], [TakeOnDate], [Status], " _
                & "[ClientType], [FaxNumber], [IdNumber], [MaritalStatus], [Gender], [Notes], " _
                & "[VatNumber], [Title], [LastName], [FirstName], [OtherNames], [DateOfBirth], " _
                & "[HomeType], [LegalName], [Jurisdiction], [Province], [FirmAddress1], [FirmAddress2], " _
                & "[FirmAddress3], [FirmAddress4], [DefaultTrustAccount], [DefaultCashbook]) VALUES ('" & txtAccountNo.Text & "', '" & strGivenNames & "', " _
                & "'" & txtAddress1.Text & "', '" & txtAddress2.Text & "', '" & txtAddress3.Text & "', " _
                & "'" & txtAddress4.Text & "', '" & txtTelephone.Text & "', '" & txtEmailAddress.Text & "', " _
                & "'" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', '" & lblStatus.Text & "', " _
                & "'" & cboCustomerType.Text & "', '" & txtFaxNumber.Text & "', '" & strIdNumber & "', " _
                & "'" & strMaritalStatus & "', '" & strGender & "', '" & txtNotes.Text & "', " _
                & "'" & txtVatNumber.Text & "', '" & strTitle & "', '" & txtLastName.Text & "', " _
                & "'" & txtFirstName.Text & "', '" & txtOtherNames.Text & "', '" & strBirthDate & "', " _
                & "'" & strHomeType & "', '" & txtLegalName.Text & "', '" & txtJurisdiction.Text & "', " _
                & "'" & txtProvince.Text & "', '" & txtFirmAddress1.Text & "', '" & txtFirmAddress2.Text & "', " _
                & "'" & txtFirmAddress3.Text & "', '" & txtAddress4.Text & "', '" & cboAccount.Text & "', " _
                & "'" & cboTrustCashbook.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            'Insert contac details
            strSql = "INSERT INTO PlaintifContacts ([PlaintifId], [GivenNames], [Telephone], " _
                & "[RelationTitle], [Address1], [Address2], [Address3], [Address4], [Cellphone], " _
                & "[EmailAddress]) VALUES ('" & txtAccountNo.Text & "', '" & txtContactPerson.Text & "', '" & txtContactTelephone.Text & "', " _
                & "'" & txtRelationship.Text & "', '" & txtConAddress1.Text & "', '" & txtConAddress2.Text & "', " _
                & "'" & txtConAddress3.Text & "', '" & txtConAddress4.Text & "', '" & txtContactCellphone.Text & "', " _
                & "'" & txtContactEmailAddress.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            'Insert employment details
            strSql = "INSERT INTO PlaintifEmployment ([PlaintifId], [Employer], [Address1], [Address2], " _
                & "[Address3], [Address4], [Telephone]) VALUES ('" & txtAccountNo.Text & "', '" & txtEmployer.Text & "', " _
                & "'" & txtEmployerAddress1.Text & "', '" & txtEmployerAddress2.Text & "', " _
                & "'" & txtEmployerAddress3.Text & "', '" & txtEmployerAddress4.Text & "', '" & txtEmployerTelephone.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            'Insert the banking details
            strSql = "INSERT INTO PlaintifBanking ([PlaintifId], [BankCode], [BankName], [AccountNumber]) " _
                & "VALUES ('" & txtAccountNo.Text & "', '" & lblBankCode.Text & "', '" & cboBankCodes.Text & "', " _
                & "'" & txtBankAccountNumber.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

        Else
            'update into the main table
            strSql = "UPDATE Plaintifs SET [GivenNames]='" & strGivenNames & "', [Address1]='" & txtAddress1.Text & "', " _
                & "[Address2]='" & txtAddress2.Text & "', [Notes]='" & txtNotes.Text & "', " _
                & "[Address3]='" & txtAddress3.Text & "', [Address4]='" & txtAddress4.Text & "', " _
                & "[Telephone]='" & txtTelephone.Text & "', [EmailAddress]='" & txtEmailAddress.Text & "', " _
                & "[TakeOnDate]='" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', [Status]='" & lblStatus.Text & "', " _
                & "[ClientType]='" & cboCustomerType.Text & "', [FaxNumber]='" & txtFaxNumber.Text & "', " _
                & "[IdNumber]='" & strIdNumber & "', [MaritalStatus]='" & strMaritalStatus & "', [Gender]='" & strGender & "', " _
                & "[VatNumber]='" & txtVatNumber.Text & "', [Title]='" & strTitle & "', [LastName]='" & txtLastName.Text & "', " _
                & "[FirstName]='" & txtFirstName.Text & "', [OtherNames]='" & txtOtherNames.Text & "', " _
                & "[DateOfBirth]='" & strBirthDate & "', " _
                & "[HomeType]='" & strHomeType & "', [LegalName] = '" & txtLegalName.Text & "', " _
                & "[Jurisdiction] = '" & txtJurisdiction.Text & "', [Province] = '" & txtProvince.Text & "', " _
                & "[FirmAddress1] = '" & txtFirmAddress1.Text & "', [FirmAddress2] = '" & txtFirmAddress2.Text & "', " _
                & "[FirmAddress3] = '" & txtFirmAddress3.Text & "', [FirmAddress4] = '" & txtFirmAddress4.Text & "', " _
                & "[DefaultTrustAccount] = '" & cboAccount.Text & "', [DefaultCashbook] = '" & cboTrustCashbook.Text & "' " _
                & "WHERE [PlaintifId] = '" & txtAccountNo.Text & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            'update contact details
            strSql = "UPDATE PlaintifContacts SET [GivenNames]='" & txtContactPerson.Text & "', [Telephone]='" & txtContactTelephone.Text & "', " _
                & "[RelationTitle]='" & txtRelationship.Text & "', [Address1]='" & txtConAddress1.Text & "', " _
                & "[Address2]='" & txtConAddress2.Text & "', [Address3]='" & txtConAddress3.Text & "', " _
                & "[Address4]='" & txtConAddress4.Text & "', [Cellphone]='" & txtContactCellphone.Text & "', " _
                & "[EmailAddress]='" & txtContactEmailAddress.Text & "' WHERE [PlaintifId]='" & txtAccountNo.Text & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            'Update employment details
            strSql = "UPDATE PlaintifEmployment SET [Employer]='" & txtEmployer.Text & "', " _
                & "[Address1]='" & txtEmployerAddress1.Text & "', " _
                & "[Address2]='" & txtEmployerAddress2.Text & "', " _
                & "[Address3]='" & txtEmployerAddress3.Text & "', " _
                & "[Address4]='" & txtEmployerAddress4.Text & "', " _
                & "[Telephone]='" & txtEmployerTelephone.Text & "' " _
                & "WHERE [PlaintifId]='" & txtAccountNo.Text & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            'Update the banking details
            strSql = "UPDATE PlaintifBanking SET [BankCode]='" & lblBankCode.Text & "', " _
                & "[BankName]='" & cboBankCodes.Text & "', [AccountNumber]='" & txtBankAccountNumber.Text & "' " _
                & "WHERE [PlaintifId]='" & txtAccountNo.Text & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()


        End If
        MessageBox.Show("Client details have been updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If UCase(SaveType) = UCase("SaveClose") Then Me.Close() Else ClearControls()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Plaintif Information Update"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        boolAbort = False
        ValidateData()
        If boolAbort = True Then Exit Sub
        UpdateData(cboCustomerType.Text, "SaveClose")
    End Sub

    Private Sub btnSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveNew.Click
        boolAbort = False
        ValidateData()
        If boolAbort = True Then Exit Sub
        UpdateData(cboCustomerType.Text, "SaveNew")
        If boolAbort = False Then
            boolEditStatus = False
            strSelectedAccount = Nothing
        End If
    End Sub

    Private Sub ClearControls()
        txtIdNumber.Clear()
        dpBirthDate.Value = Now
        txtMaidenName.Clear()
        txtOtherNames.Clear()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtTakeOnBalance.Clear()
        txtVatNumber.Clear()
        txtEmailAddress.Clear()
        txtCellphone.Clear()
        txtFaxNumber.Clear()
        txtTelephone.Clear()
        txtAddress4.Clear()
        txtAddress3.Clear()
        txtAddress2.Clear()
        txtAddress1.Clear()
        dpDateOn.Value = Now
        txtAccountName.Clear()
        txtAccountNo.Clear()
        txtContactEmailAddress.Clear()
        txtContactCellphone.Clear()
        txtContactTelephone.Clear()
        txtRelationship.Clear()
        txtContactPerson.Clear()
        txtConAddress1.Clear()
        txtConAddress4.Clear()
        txtConAddress2.Clear()
        txtConAddress3.Clear()
        txtBankAccountNumber.Clear()
        lblBankCode.Text = Nothing
        txtNotes.Clear()
        lblAmtPaid.Text = "0.00"
        lblPaymentDate.Text = "0.00"
        lblCurrentBalance.Text = "0.00"
        txtEmployerTelephone.Clear()
        txtEmployerAddress4.Clear()
        txtEmployerAddress3.Clear()
        txtEmployerAddress2.Clear()
        txtEmployerAddress1.Clear()
        txtEmployer.Clear()

        txtFirmAddress1.Clear()
        txtFirmAddress2.Clear()
        txtFirmAddress3.Clear()
        txtFirmAddress4.Clear()
        txtProvince.Clear()
        txtLegalName.Clear()
        txtJurisdiction.Clear()

    End Sub

    Private Sub ValidateData()
        If String.IsNullOrEmpty(txtAccountNo.Text) Then
            MessageBox.Show("Please enter the client account number", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNo.Focus()
            boolAbort = True
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountName.Text) Then
            MessageBox.Show("Please enter the client name", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountName.Focus()
            boolAbort = True
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the client address", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            boolAbort = True
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboCustomerType.Text) Then
            MessageBox.Show("Please select the client type", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCustomerType.Focus()
            boolAbort = True
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblAccountDescription.Text) Then
            cboAccount.Text = ""
        End If
    End Sub

    Private Sub AutoNumberIncreament()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber FROM Plaintifs ORDER BY AccountNumber DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    If IsNumeric(objReader(0).ToString) Then
                        txtAccountNo.Text = CDbl(objReader(0).ToString) + 1
                    Else
                        If objReader(0).ToString.Length >= 4 Then
                            Dim strLastNumber As String = Mid(objReader(0).ToString, (objReader(0).ToString.Length - 4), 4)
                            If IsNumeric(strLastNumber) Then
                                txtAccountNo.Text = Mid(objReader(0).ToString, 1, (objReader(0).ToString.Length - 4)) & Format((CLng(strLastNumber) + 1), "0000")
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Clients' Number Auto Increament Failure"
        ShowErrorMessage()
    End Sub

    Private Sub AlternateColors(ByVal myGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView)
        With myGrid
            For i As Integer = 0 To .Rows.Count - 1 Step 2
                For j As Integer = 0 To .Columns.Count - 1
                    Dim foreColor As Color = Color.Black
                    Dim backColor As Color = Color.WhiteSmoke
                    .Rows(i).Cells(j).Style.BackColor = backColor
                    .Rows(i).Cells(j).Style.ForeColor = foreColor
                Next j
            Next i
        End With
    End Sub

    Private Sub LoadIndividualData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT [Title], [LastName], [FirstName], [OtherNames], [MaidenName], " _
            & "[BirthDate], [MaritalStatus], [IDNumber], [Gender], [HomeType] " _
            & "FROM IndividualCustomers WHERE [AccountNumber] = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            pnlIndividuals.Enabled = True : cboCustomerType.Text = "Individual"
            If Not IsDBNull(objReader(0).ToString) Then cboSalutation.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtLastName.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtFirstName.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then txtOtherNames.Text = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then txtMaidenName.Text = objReader(4).ToString
            If IsDate(objReader(5).ToString) Then dpBirthDate.Value = CDate(objReader(5).ToString)
            If Not IsDBNull(objReader(6).ToString) Then cboMaritalStatus.Text = objReader(6).ToString
            If Not IsDBNull(objReader(7).ToString) Then txtIdNumber.Text = objReader(7).ToString
            If Not IsDBNull(objReader(8).ToString) Then cboGender.Text = objReader(8).ToString
            If Not IsDBNull(objReader(9).ToString) Then cboHomeType.Text = objReader(9).ToString
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Individual Customers Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboCustomerType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCustomerType.KeyPress
        If Asc(e.KeyChar) = 13 Then dpDateOn.Focus()
    End Sub

    Private Sub cboCustomerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerType.SelectedIndexChanged
        If UCase(cboCustomerType.Text) = "INDIVIDUAL" Then
            pnlIndividuals.Enabled = True
            txtAccountName.Clear()
            txtAccountName.Enabled = False
        Else
            pnlIndividuals.Enabled = False
            txtAccountName.Enabled = True
        End If
    End Sub

    Private Sub txtAccountNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountNo.KeyPress
        If Asc(e.KeyChar) = 13 Then cboCustomerType.Focus()
    End Sub

    Private Sub txtAccountName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountName.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAddress1.Focus()
    End Sub

    Private Sub txtAddress1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress1.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAddress2.Focus()
    End Sub

    Private Sub txtAddress2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress2.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAddress3.Focus()
    End Sub

    Private Sub txtAddress3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress3.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAddress4.Focus()
    End Sub

    Private Sub txtAddress4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress4.KeyPress
        If Asc(e.KeyChar) = 13 Then txtTelephone.Focus()
    End Sub

    Private Sub txtTelephone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelephone.KeyPress
        If Asc(e.KeyChar) = 13 Then txtFaxNumber.Focus()
    End Sub

    Private Sub txtFaxNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFaxNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then txtCellphone.Focus()
    End Sub

    Private Sub txtCellphone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCellphone.KeyPress
        If Asc(e.KeyChar) = 13 Then txtEmailAddress.Focus()
    End Sub

    Private Sub txtEmailAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailAddress.KeyPress
        If Asc(e.KeyChar) = 13 Then txtVatNumber.Focus()
    End Sub

    Private Sub txtVatNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVatNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then txtTakeOnBalance.Focus()
    End Sub

    Private Sub cboSalutation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSalutation.KeyPress
        If Asc(e.KeyChar) = 13 Then txtLastName.Focus()
    End Sub

    Private Sub txtLastName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLastName.KeyPress
        If Asc(e.KeyChar) = 13 Then txtFirstName.Focus()
    End Sub

    Private Sub txtFirstName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFirstName.KeyPress
        If Asc(e.KeyChar) = 13 Then txtOtherNames.Focus()
    End Sub

    Private Sub txtOtherNames_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherNames.KeyPress
        If Asc(e.KeyChar) = 13 Then txtMaidenName.Focus()
    End Sub

    Private Sub txtMaidenName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaidenName.KeyPress
        If Asc(e.KeyChar) = 13 Then dpBirthDate.Focus()
    End Sub

    Private Sub cboMaritalStatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMaritalStatus.KeyPress
        If Asc(e.KeyChar) = 13 Then txtIdNumber.Focus()
    End Sub

    Private Sub txtIdNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then cboHomeType.Focus()
    End Sub

    Private Sub cboHomeType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboHomeType.KeyPress
        If Asc(e.KeyChar) = 13 Then cboGender.Focus()
    End Sub

    Private Sub txtContactPerson_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactPerson.KeyPress
        If Asc(e.KeyChar) = 13 Then txtRelationship.Focus()
    End Sub

    Private Sub txtRelationship_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRelationship.KeyPress
        If Asc(e.KeyChar) = 13 Then txtConAddress1.Focus()
    End Sub

    Private Sub txtConAddress1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConAddress1.KeyPress
        If Asc(e.KeyChar) = 13 Then txtConAddress2.Focus()
    End Sub

    Private Sub txtConAddress2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConAddress2.KeyPress
        If Asc(e.KeyChar) = 13 Then txtConAddress3.Focus()
    End Sub

    Private Sub txtConAddress3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConAddress3.KeyPress
        If Asc(e.KeyChar) = 13 Then txtConAddress4.Focus()
    End Sub

    Private Sub txtConAddress4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConAddress4.KeyPress
        If Asc(e.KeyChar) = 13 Then txtContactTelephone.Focus()
    End Sub

    Private Sub txtContactTelephone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactTelephone.KeyPress
        If Asc(e.KeyChar) = 13 Then txtContactCellphone.Focus()
    End Sub

    Private Sub txtContactCellphone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactCellphone.KeyPress
        If Asc(e.KeyChar) = 13 Then txtContactEmailAddress.Focus()
    End Sub

    Private Sub txtEmployer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmployer.KeyPress
        If Asc(e.KeyChar) = 13 Then txtEmployerAddress1.Focus()
    End Sub

    Private Sub txtEmployerAddress1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmployerAddress1.KeyPress
        If Asc(e.KeyChar) = 13 Then txtEmployerAddress2.Focus()
    End Sub

    Private Sub txtEmployerAddress2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmployerAddress2.KeyPress
        If Asc(e.KeyChar) = 13 Then txtEmployerAddress3.Focus()
    End Sub

    Private Sub txtEmployerAddress3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmployerAddress3.KeyPress
        If Asc(e.KeyChar) = 13 Then txtEmployerAddress4.Focus()
    End Sub

    Private Sub txtEmployerAddress4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmployerAddress4.KeyPress
        If Asc(e.KeyChar) = 13 Then txtEmployerTelephone.Focus()
    End Sub

    Private Sub BuildNameFromIndividual()
        Dim strFullName As String = Nothing
        If Not String.IsNullOrEmpty(txtLastName.Text) Then
            strFullName = strFullName & txtLastName.Text
        End If
        If Not String.IsNullOrEmpty(txtFirstName.Text) Then
            If Not String.IsNullOrEmpty(strFullName) Then
                strFullName = strFullName & " " & txtFirstName.Text
            Else
                strFullName = strFullName & txtFirstName.Text
            End If
        End If
        If Not String.IsNullOrEmpty(txtOtherNames.Text) Then
            If Not String.IsNullOrEmpty(strFullName) Then
                strFullName = strFullName & " " & txtOtherNames.Text
            Else
                strFullName = strFullName & txtOtherNames.Text
            End If
        End If
        txtAccountName.Text = strFullName
    End Sub

    Private Sub txtLastName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLastName.Validated
        BuildNameFromIndividual()
    End Sub

    Private Sub txtFirstName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFirstName.Validated
        BuildNameFromIndividual()
    End Sub

    Private Sub txtOtherNames_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOtherNames.Validated
        BuildNameFromIndividual()
    End Sub

    Private Sub frmCustomerDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If strActiveClientTypes = "CORPORATE" Then
        '    cboCustomerType.Text = "Corporate"
        'Else
        '    cboCustomerType.Text = "Individual"
        'End If
        LoadTrustAccounts()
        LoadTrustCashbooks()
        'cboCustomerType.Enabled = False
        If boolEditStatus = True Then
            LoadClientData()
            btnActionCosts.Enabled = True
        End If

    End Sub

    Private Sub LoadTrustCashbooks()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountNumber +';'+AccountName AS " _
            & "[Accounts] FROM TrustCashbooks ORDER BY AccountNumber"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboTrustCashbook
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;280"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM TrustCashbooks", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboTrustCashbook.Items.Clear()
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
            cboTrustCashbook.SelectedIndex = -1
            cboTrustCashbook.Items.Clear()
            cboTrustCashbook.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboTrustCashbook.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Trust Cashbook Accounts Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadClientData()
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim strSql As String = Nothing

        strSql = "SELECT * FROM Plaintifs WHERE PlaintifId = '" & strSelectedAccount & "'"
        txtAccountNo.Text = strSelectedAccount

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader()
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("GivenNames").ToString) Then txtAccountName.Text = objReader("GivenNames").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If IsDate(objReader("TakeOnDate").ToString) Then dpDateOn.Value = CDate(objReader("TakeOnDate").ToString)
            If Not IsDBNull(objReader("Status").ToString) Then lblStatus.Text = objReader("Status").ToString
            If Not IsDBNull(objReader("ClientType").ToString) Then cboCustomerType.Text = objReader("ClientType").ToString
            If Not IsDBNull(objReader("FaxNumber").ToString) Then txtFaxNumber.Text = objReader("FaxNumber").ToString
            If Not IsDBNull(objReader("IdNumber").ToString) Then txtIdNumber.Text = objReader("IdNumber").ToString
            If Not IsDBNull(objReader("MaritalStatus").ToString) Then cboMaritalStatus.Text = objReader("MaritalStatus").ToString
            If Not IsDBNull(objReader("Gender").ToString) Then cboGender.Text = objReader("Gender").ToString
            If Not IsDBNull(objReader("VatNumber").ToString) Then txtVatNumber.Text = objReader("VatNumber").ToString
            If Not IsDBNull(objReader("Title").ToString) Then cboSalutation.Text = objReader("Title").ToString
            If Not IsDBNull(objReader("LastName").ToString) Then txtLastName.Text = objReader("LastName").ToString
            If Not IsDBNull(objReader("FirstName").ToString) Then txtFirstName.Text = objReader("FirstName").ToString
            If Not IsDBNull(objReader("OtherNames").ToString) Then txtOtherNames.Text = objReader("OtherNames").ToString
            If IsDate(objReader("DateOfBirth").ToString) Then dpBirthDate.Value = CDate(objReader("DateOfBirth").ToString)
            If Not IsDBNull(objReader("HomeType").ToString) Then cboHomeType.Text = objReader("HomeType").ToString

            If Not IsDBNull(objReader("LegalName").ToString) Then txtLegalName.Text = objReader("LegalName").ToString
            If Not IsDBNull(objReader("Province").ToString) Then txtProvince.Text = objReader("Province").ToString
            If Not IsDBNull(objReader("Jurisdiction").ToString) Then txtJurisdiction.Text = objReader("Jurisdiction").ToString
            If Not IsDBNull(objReader("FirmAddress1").ToString) Then txtFirmAddress1.Text = objReader("FirmAddress1").ToString
            If Not IsDBNull(objReader("FirmAddress2").ToString) Then txtFirmAddress2.Text = objReader("FirmAddress2").ToString
            If Not IsDBNull(objReader("FirmAddress3").ToString) Then txtFirmAddress3.Text = objReader("FirmAddress3").ToString
            If Not IsDBNull(objReader("FirmAddress4").ToString) Then txtFirmAddress4.Text = objReader("FirmAddress4").ToString
            'DefaultTrustAccount
            If Not IsDBNull(objReader("DefaultTrustAccount").ToString) Then cboAccount.Text = objReader("DefaultTrustAccount").ToString
            'DefaultTrustCashbookAccount
            If Not IsDBNull(objReader("DefaultCashbook").ToString) Then cboTrustCashbook.Text = objReader("DefaultCashbook").ToString
            If Not IsDBNull(objReader("NextReceiptNo").ToString) Then txtNextReceiptNumber.Text = objReader("NextReceiptNo").ToString
        End If
        objReader.Close()

        'Get contact details
        strSql = "SELECT * FROM PlaintifContacts WHERE PlaintifId = '" & strSelectedAccount & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader()
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("GivenNames").ToString) Then txtContactPerson.Text = objReader("GivenNames").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtConAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtConAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtConAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtConAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtContactCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtContactTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtContactEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("RelationTitle").ToString) Then txtRelationship.Text = objReader("RelationTitle").ToString
        End If
        objReader.Close()

        'Get employment details
        strSql = "SELECT * FROM PlaintifEmployment WHERE PlaintifId = '" & strSelectedAccount & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader()
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("Employer").ToString) Then txtEmployer.Text = objReader("Employer").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtEmployerAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtEmployerAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtEmployerAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtEmployerAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtEmployerTelephone.Text = objReader("Telephone").ToString
        End If
        objReader.Close()

        'Get the banking details
        strSql = "SELECT * FROM PlaintifBanking WHERE PlaintifId = '" & strSelectedAccount & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader()
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("BankCode").ToString) Then lblBankCode.Text = objReader("BankCode").ToString
            If Not IsDBNull(objReader("BankName").ToString) Then cboBankCodes.Text = objReader("BankName").ToString
            If Not IsDBNull(objReader("AccountNumber").ToString) Then txtBankAccountNumber.Text = objReader("AccountNumber").ToString
        End If
        objReader.Close()

        boolAbort = False
        LoadTransactions()
        If boolAbort = True Then Exit Sub

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Client Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadTransactions()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, TransactionDate, 105) AS [Date], " _
            & "Description, CaseNumber as [Case #], ReferenceNumber AS [Advice #],  CAST(Debit AS DECIMAL (10,2)) AS [Debit], " _
            & "CAST(Credit AS DECIMAL(10,2)) AS [Credit], Comments FROM PlaintifTransactions " _
            & "WHERE PlaintifId = '" & strSelectedAccount & "' ORDER BY TransactionDate"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGrid.Columns.Clear()

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        'AlternateColors(dGrid)
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            If p > 3 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGrid.Columns(p).DefaultCellStyle.Format = "N2"
            End If
        Next
        Cursor = Cursors.Default

        lblCurrentBalance.Text = "0.00"
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SUM(Debit - Credit) FROM PlaintifTransactions WHERE PlaintifId = '" & strSelectedAccount & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                lblCurrentBalance.Text = Format(CDbl(objReader(0).ToString), "#,##0.00")
            End If
        End If
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Plaintif Transactions Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccount.SelectedIndexChanged
        lblAccountDescription.Text = ""
        If Not cboAccount.SelectedItem Is Nothing Then
            lblAccountDescription.Text = cboAccount.SelectedItem.Col2
        End If
    End Sub

    Private Sub LoadTrustAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountNumber +';'+AccountName AS " _
            & "[Accounts] FROM TrustAccounts ORDER BY AccountNumber"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboAccount
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;280"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM TrustAccounts", cnn)
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
        strErrorMessages = Err.Description & " " & Err.Number & " on Trust Accounts Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboTrustCashbook_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTrustCashbook.SelectedIndexChanged
        lblTrustAccountDescription.Text = ""
        If Not cboTrustCashbook.SelectedItem Is Nothing Then
            lblTrustAccountDescription.Text = cboTrustCashbook.SelectedItem.Col2
        End If
    End Sub

    Private Sub btnActionCosts_Click(sender As System.Object, e As System.EventArgs) Handles btnActionCosts.Click
        boolCalledFromListing = True
        strSelectedPlaintifId = txtAccountNo.Text
        strSelectedPlaintifName = txtAccountName.Text
        Dim frm As New frmLegalPortfolioCostsSetup
        frm.ShowDialog()
    End Sub

End Class
