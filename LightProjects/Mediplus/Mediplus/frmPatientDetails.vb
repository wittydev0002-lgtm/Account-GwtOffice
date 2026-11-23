Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPatientDetails

    Dim dblNextNumber As Double = 1001000
    Dim strEmployer As String = ""
    Dim strEmployerPartnership As String = "NO"
    Dim boolPriorStatus As Boolean

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        boolAbort = False
        'Check that all the mandatory fields have been entered
        If String.IsNullOrEmpty(txtIdNumber.Text) Then
            MessageBox.Show("Id Number Is Required", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtIdNumber.Focus()
            Exit Sub
        End If
        If Me.txtLastName.Text.Length <= 0 Or Mid(Me.txtLastName.Text, 1, 1) = " " Then
            MessageBox.Show("Last Name Is Required", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLastName.Focus()
            Exit Sub
        End If
        If Me.txtFirstName.Text.Length <= 0 Or Mid(Me.txtFirstName.Text, 1, 1) = " " Then
            MessageBox.Show("First Name Is Required", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirstName.Focus()
            Exit Sub
        End If
        If Me.cboGender.Text.Length <= 0 Or Mid(Me.cboGender.Text, 1, 1) = " " Then
            MessageBox.Show("Gender Is Required", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboGender.Focus()
            Exit Sub
        End If
        If Me.cboMaritalStatus.Text.Length <= 0 Or Mid(Me.cboMaritalStatus.Text, 1, 1) = " " Then
            MessageBox.Show("Marital Status Is Required", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboMaritalStatus.Focus()
            Exit Sub
        End If

        'Validate the patient category status
        If String.IsNullOrEmpty(cboPatientType.Text) Then
            MessageBox.Show("You must specify the patient type", "Missing Patient Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            cboPatientType.Focus()
            Exit Sub
        End If
        If cboPatientType.Text = "Medical Aid" Then
            If Not IsDate(dpExpiryDate.Text) Then
                MessageBox.Show("Please enter a valid expiry date for the medical aid", "Invalid Expiry Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dpExpiryDate.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(cboMedicalAid.Text) Or String.IsNullOrEmpty(cboPackage.Text) _
                Or String.IsNullOrEmpty(txtMedNumber.Text) Or CDate(dpExpiryDate.Text) < Now Then
                MessageBox.Show("You have stated that the patient is on medical aid and one or more" & _
                    vbCrLf & "of the medical aid is incorrect. Please correct before proceeding", "Invalid Medical Aid Details", _
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboMedicalAid.Focus()
                TabControl1.SelectedIndex = 4
                Exit Sub
            End If
        End If

        If boolAbort = True Then Exit Sub
        strEmployerPartnership = "NO"
        If Not IsNumeric(txtSuffix.Text) Then txtSuffix.Text = "0"
        If boolEditStatus = True Then UpdatePatient(Me.txtIdNumber.Text) Else InsertPatient(Me.txtIdNumber.Text)

    End Sub

    Private Sub UpdatePatient(ByVal strIdNumber As String)
        Cursor = Cursors.WaitCursor

        Dim strUpdatePatient As String = "UPDATE OchmasPatients SET PatientId = '" & Me.txtIdNumber.Text & "', " _
            & "LastName = '" & Me.txtLastName.Text & "', FirstName = '" & Me.txtFirstName.Text & "', " _
            & "OtherNames = '" & Me.txtOtherNames.Text & "', BirthDate = '" & Me.dpBirthDate.Text & "', " _
            & "Gender = '" & Me.cboGender.Text & "', MaritalStatus = '" & Me.cboMaritalStatus.Text & "', " _
            & "BillingMethod = '" & cboBillingMethod.Text & "', PatientType = '" & cboPatientType.Text & "', " _
            & "Address = '" & Me.txtPatientAddress.Text & "', " _
            & "UserName = '" & strUserName & "', Branch = '" & strUserBranch & "', ChangeDate = '" & Now & "', " _
            & "NetworkEmployer = '" & strEmployerPartnership & "' WHERE ReferenceNumber = " & CDbl(lblReferenceNumber.Text) & ""

        Dim strUpdateNotes As String = "UPDATE OchmasPatientNotes SET Notes = '" & txtNotes.Text & "', " _
            & "UserName = '" & strUserName & "', Branch = '" & strUserBranch & "', ChangeDate = '" & Now & "' " _
            & "WHERE ReferenceNumber = " & CDbl(lblReferenceNumber.Text) & ""

        Dim strUpdateMedaid As String = "UPDATE OchmasMedaidMembership SET SchemeNumber = '" & lblCareNumber.Text & "', " _
            & "SchemeName = '" & cboMedicalAid.Text & "', MemberCategory = '" & cboPackage.Text & "', " _
            & "MemberNumber = '" & txtMedNumber.Text & "', ExpiryDate = '" & dpExpiryDate.Text & "', " _
            & "UserName = '" & strUserName & "', Branch = '" & strUserBranch & "', ChangeDate = '" & Now & "', " _
            & "MainMemberNames = '" & txtMainMemberNames.Text & "', Suffix = " & CInt(txtSuffix.Text) & " " _
            & "WHERE ReferenceNumber = " & CDbl(lblReferenceNumber.Text) & ""

        boolAbort = False

        Dim dbCommand As New OleDb.OleDbCommand(strUpdatePatient, cnn)

        Try
            dbCommand.ExecuteNonQuery()
            dbCommand = New OleDb.OleDbCommand(strUpdateMedaid, cnn)
            dbCommand.ExecuteNonQuery()
            dbCommand = New OleDb.OleDbCommand(strUpdateNotes, cnn)
            dbCommand.ExecuteNonQuery()
            MsgBox("Patient Details Have been updated successfully", MsgBoxStyle.Information, "Patient Details Update Success")
            Cursor = Cursors.Default
            Me.Close()
        Catch ex As Exception
            Cursor = Cursors.Default
            strErrorMessages = Err.Description & " " & Err.Number
            ShowErrorMessage()
        End Try
    End Sub

    Private Sub InsertPatient(ByVal strIdNumber As String)
        boolAbort = False
        If boolAbort = True Then Exit Sub
        'Get the next number at this point instead
        'GetNextNumber()
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "INSERT INTO OchmasPatients (PatientId, LastName, FirstName, " _
            & "OtherNames, BirthDate, Gender, MaritalStatus, " _
            & "EmailAddress, Address, ReferenceNumber, " _
            & "BillingMethod, PatientType,UserName, Branch, ChangeDate, OnpNumber, " _
            & "NetworkEmployer, cellphone, InceptionDate) VALUES " _
            & "('" & Me.txtIdNumber.Text & "', '" & Me.txtLastName.Text & "', " _
            & "'" & Me.txtFirstName.Text & "', '" & Me.txtOtherNames.Text & "', " _
            & "'" & Me.dpBirthDate.Text & "', '" & Me.cboGender.Text & "', " _
            & "'" & Me.cboMaritalStatus.Text & "', '" & txtPatientAddress.Text & "', " _
            & "'" & Me.txtPatientAddress.Text & "', " _
            & "" & dblNextNumber & ", " _
            & "'" & cboBillingMethod.Text & "', '" & cboPatientType.Text & "', " _
            & "'" & strUserName & "', '" & strUserBranch & "', '" & Now & "', " _
            & "'000', '" & strEmployerPartnership & "', '" & txtPatientTelephone.Text & "', '" & Now & "')"

        Dim strMedaid As String = "INSERT INTO OchmasMedaidMembership (ReferenceNumber, SchemeNumber, SchemeName, " _
            & "MemberCategory, MemberNumber, ExpiryDate, UserName, Branch, ChangeDate, MainMemberNames, Suffix) VALUES (" & dblNextNumber & ", " _
            & "'" & lblCareNumber.Text & "', '" & cboMedicalAid.Text & "', '" & cboPackage.Text & "', " _
            & "'" & txtMedNumber.Text & "', '" & dpExpiryDate.Text & "', '" & strUserName & "', " _
            & "'" & strUserBranch & "', '" & Now & "', '" & txtMainMemberNames.Text & "', " & txtSuffix.Text & ")"

        Dim strNotes As String = "INSERT INTO OchmasPatientNotes (ReferenceNumber, Notes, UserName, Branch, ChangeDate) " _
            & "VALUES (" & dblNextNumber & ", '" & txtNotes.Text & "', '" & strUserName & "', '" & strUserBranch & "', '" & Now & "')"


        Dim dbCommand As New OleDb.OleDbCommand(strSql, cnn)
        Try
            dbCommand.ExecuteNonQuery()
            If Not String.IsNullOrEmpty(cboMedicalAid.Text) Then
                dbCommand = New OleDb.OleDbCommand(strMedaid, cnn)
                dbCommand.ExecuteNonQuery()
            End If
            If Not String.IsNullOrEmpty(txtNotes.Text) Then
                dbCommand = New OleDb.OleDbCommand(strNotes, cnn)
                dbCommand.ExecuteNonQuery()
            End If
            Cursor = Cursors.Default

            'Update the control number

            dbCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET PatientReferenceNo = " & dblNextNumber + 1 & "", cnn)
            dbCommand.ExecuteNonQuery()

            If MsgBox("Patient details updated successfully. Do you want to add another patient?", MsgBoxStyle.YesNo, "Patient Details Update Success") = MsgBoxResult.Yes Then
                ClearControls()
                boolEditStatus = False
                GetNextNumber()
            Else
                Me.Close()
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            strErrorMessages = ex.Message
            gwt_comm.ShowErrorMessage()
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub GetNextNumber()
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim strSql As String = Nothing
        Dim iNextNumber As Double = 0
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        strSql = "Select PatientReferenceNo from ControlNumbers"

        Dim myCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows = True Then
            While dbReader.Read
                If Not IsDBNull(dbReader(0).ToString) Then
                    If IsNumeric(dbReader(0).ToString) Then
                        iNextNumber = CDbl(dbReader(0).ToString)
                        iNextNumber += 1
                    End If
                End If
            End While
            lblReferenceNumber.Text = CStr(iNextNumber)
            dblNextNumber = iNextNumber
        Else
            lblReferenceNumber.Text = "1"
        End If
        dbReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Document Number Fetch Failure"
        ShowErrorMessage()
    End Sub

    Private Sub ClearControls()
        txtFirstName.Clear()
        txtIdNumber.Clear()
        txtLastName.Clear()
        cboPackage.Items.Clear()
        cboMedicalAid.Text = ""
        txtMedNumber.Clear()
        txtNotes.Clear()
        txtOtherNames.Clear()
        txtPatientAddress.Clear()
        txtPatientEmailAddress.Clear()
        txtPatientTelephone.Clear()
        txtMainMemberNames.Clear()
        txtSuffix.Text = "00"
    End Sub

    Private Sub frmPatients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = False Then
            Me.GetNextNumber()
        Else
            LoadPatientDetails()
            LoadPrescriptionHistory()
        End If
        LoadMedicalAids()
    End Sub

    Private Sub LoadPrescriptionHistory()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), DispensingMain.TransactionDate, 106), ' ', '-')) as [Date], " _
            & "DispensingDetails.PrescriptionNumber, DispensingDetails.DrugCode, OchmasSystemMedicines.ProductName, " _
            & "DispensingDetails.Quantity, (((DispensingDetails.SellingPrice * DispensingDetails.Quantity) - " _
            & "DispensingDetails.Discount) + DispensingDetails.Taxes) AS [Payable] FROM DispensingDetails " _
            & "LEFT OUTER JOIN DispensingMain ON DispensingDetails.PrescriptionNumber = DispensingMain.PrescriptionNumber " _
            & "LEFT OUTER JOIN OchmasSystemMedicines ON DispensingDetails.DrugCode = OchmasSystemMedicines.ProductCode " _
            & "WHERE DispensingDetails.PatientReferenceNumber = " & intSelectedPatient & " " _
            & "ORDER BY DispensingMain.TransactionDate, DispensingDetails.PrescriptionNumber"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        Dim dblTotal As Double = 0
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
            If IsNumeric(objReader(5).ToString) Then
                dblTotal = dblTotal + CDbl(objReader(5).ToString)
            End If
        End While
        objReader.Close()
        lblTotals.Text = Format(dblTotal, "#,##0.00")
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On patient past prescriptions history load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadPatientDetails()
        'load the selected patient details
        Dim strSql As String = "SELECT * FROM OchmasPatients WHERE ReferenceNumber = " & intSelectedPatient & ""
        'Dim strEmployment As String = "SELECT * FROM OchmasEmployment WHERE ReferenceNumber = " & intSelectedPatient & ""
        'Dim strKins As String = "SELECT * FROM OchmasKins WHERE ReferenceNumber = " & intSelectedPatient & ""
        Dim strMedaid As String = "SELECT * FROM OchmasMedaidMembership WHERE ReferenceNumber = " & intSelectedPatient & ""
        Dim strNotes As String = "SELECT * FROM OchmasPatientNotes WHERE ReferenceNumber = " & intSelectedPatient & ""
        'Dim strDependents As String = "SELECT * FROM Dependents WHERE ReferenceNumber = " & intSelectedPatient & ""
        'Dim strAllergies As String = "SELECT * FROM Allergies WHERE ReferenceNumber = " & intSelectedPatient & ""
        Dim dbCommand As OleDb.OleDbCommand
        Dim dbReader As OleDb.OleDbDataReader
        lblReferenceNumber.Text = intSelectedPatient
        Try
            dbCommand = New OleDb.OleDbCommand(strSql, cnn)
            dbReader = dbCommand.ExecuteReader
            While dbReader.Read
                If Not IsDBNull(dbReader("PatientId").ToString) Then txtIdNumber.Text = dbReader("PatientId").ToString
                If Not IsDBNull(dbReader("LastName").ToString) Then txtLastName.Text = dbReader("LastName").ToString
                If Not IsDBNull(dbReader("FirstName").ToString) Then txtFirstName.Text = dbReader("FirstName").ToString
                If Not IsDBNull(dbReader("OtherNames").ToString) Then txtOtherNames.Text = dbReader("OtherNames").ToString
                If Not IsDBNull(dbReader("BirthDate").ToString) Then dpBirthDate.Text = dbReader("BirthDate").ToString
                If Not IsDBNull(dbReader("Gender").ToString) Then cboGender.Text = dbReader("Gender").ToString
                If Not IsDBNull(dbReader("MaritalStatus").ToString) Then cboMaritalStatus.Text = dbReader("MaritalStatus").ToString
                'If Not IsDBNull(dbReader("Minors").ToString) Then txtMinors.Text = dbReader("Minors").ToString
                'If Not IsDBNull(dbReader("Race").ToString) Then cboRace.Text = dbReader("Race").ToString
                'If Not IsDBNull(dbReader("Status").ToString) Then cboStatus.Text = dbReader("Status").ToString
                If Not IsDBNull(dbReader("Telephone").ToString) Then txtPatientTelephone.Text = dbReader("Telephone").ToString
                'If Not IsDBNull(dbReader("Cellphone").ToString) Then txtPatientMobile.Text = dbReader("Cellphone").ToString
                If Not IsDBNull(dbReader("EmailAddress").ToString) Then txtPatientEmailAddress.Text = dbReader("EmailAddress").ToString
                If Not IsDBNull(dbReader("Address").ToString) Then txtPatientAddress.Text = dbReader("Address").ToString
                'If Not IsDBNull(dbReader("City").ToString) Then txtPatientCity.Text = dbReader("City").ToString
                'If Not IsDBNull(dbReader("Province").ToString) Then cboPatientProvince.Text = dbReader("Province").ToString
                'If Not IsDBNull(dbReader("NetworkEmployer").ToString) Then
                '    If UCase(dbReader("NetworkEmployer").ToString) = "YES" Then
                '        chkEmployerStatus.Checked = True
                '    Else
                '        chkEmployerStatus.Checked = False
                '    End If
                'End If
                If Not IsDBNull(dbReader("BillingMethod").ToString) Then cboBillingMethod.Text = dbReader("BillingMethod").ToString
                If Not IsDBNull(dbReader("PatientType").ToString) Then cboPatientType.Text = dbReader("PatientType").ToString
                'If Not IsDBNull(dbReader("FileNumber").ToString) Then txtFileNumber.Text = dbReader("FileNumber").ToString
            End While
            'Populate Medical Aid details
            dbCommand = New OleDb.OleDbCommand(strMedaid, cnn)
            dbReader = dbCommand.ExecuteReader
            While dbReader.Read
                If Not IsDBNull(dbReader("SchemeName").ToString) Then cboMedicalAid.Text = dbReader("SchemeName").ToString
                If Not IsDBNull(dbReader("SchemeNumber").ToString) Then lblCareNumber.Text = dbReader("SchemeNumber").ToString
                If Not String.IsNullOrEmpty(lblCareNumber.Text) Then
                    'Load the medical aid package
                    LoadSelectedSchemePackages(lblCareNumber.Text)
                End If
                If Not IsDBNull(dbReader("MemberCategory").ToString) Then cboPackage.Text = dbReader("MemberCategory").ToString
                If Not IsDBNull(dbReader("MemberNumber").ToString) Then txtMedNumber.Text = dbReader("MemberNumber").ToString
                If IsNumeric(dbReader("Suffix").ToString) Then txtSuffix.Text = Format(CInt(dbReader("Suffix").ToString), "00")
                If IsDate(dbReader("ExpiryDate").ToString) Then dpExpiryDate.Value = CDate(dbReader("ExpiryDate").ToString)
                If Not IsDBNull(dbReader("MainMemberNames").ToString) Then txtMainMemberNames.Text = dbReader("MainMemberNames").ToString
            End While
            'Populate Notes
            dbCommand = New OleDb.OleDbCommand(strNotes, cnn)
            dbReader = dbCommand.ExecuteReader
            While dbReader.Read
                If Not IsDBNull(dbReader("Notes").ToString) Then txtNotes.Text = dbReader("Notes").ToString
            End While
        Catch ex As Exception
            strErrorMessages = Err.Description & " " & Err.Number
            ShowErrorMessage()
            boolAbort = True
        End Try
    End Sub

    Private Sub LoadMedicalAids()
        On Error GoTo RaiseErr
        With cboMedicalAid
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "300;60"
        End With
        Dim strSql As String = "SELECT OchmasSystemMedicalAids.Name, OchmasSystemMedicalAids.RegistrationNumber " _
            & "FROM OchmasSystemMedicalAids ORDER BY OchmasSystemMedicalAids.Name"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dtData As New DataTable()
        da.Fill(dtData)
        'Iterate the datatable and pass to the combobox
        cboMedicalAid.SelectedIndex = -1
        cboMedicalAid.Items.Clear()
        cboMedicalAid.LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
        cboMedicalAid.SourceDataString = New String(1) {"Name", "RegistrationNumber"}
        cboMedicalAid.SourceDataTable = dtData
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On medical aid details load"
        ShowErrorMessage()
    End Sub

    Private Sub txtMedicalAid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMedicalAid.SelectedIndexChanged
        If Not cboMedicalAid.SelectedItem Is Nothing Then
            lblCareNumber.Text = cboMedicalAid.SelectedItem.Col2
        Else
            lblCareNumber.Text = ""
        End If
        LoadSelectedSchemePackages(lblCareNumber.Text)
    End Sub

    Private Sub LoadSelectedSchemePackages(ByVal MedicalAidNumber As String)
        On Error GoTo RaiseErr
        'Load the packages
        Dim strSql As String = "SELECT Package FROM OchmasMedicalAidPackages WHERE RegistrationNumber = '" & MedicalAidNumber & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboPackage.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboPackage.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Medical Aid Packages Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        boolPriorStatus = boolEditStatus
        boolEditStatus = False
        Dim frm As New frmDependents
        frm.ShowDialog()
        boolEditStatus = boolPriorStatus
        LoadDependants()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        GetSelected()
    End Sub

    Private Sub GetSelected()
        If dGrid.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(5).Value.ToString)
        boolPriorStatus = boolEditStatus
        boolEditStatus = True
        Dim frm As New frmDependents
        frm.ShowDialog()
        boolEditStatus = boolPriorStatus
        LoadDependants()
    End Sub

    Private Sub dGrid_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellDoubleClick
        GetSelected()
    End Sub

    Private Function MedicalAidName(ByVal RegCode As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Name FROM OchmasSystemMedicalAids " _
            & "WHERE RegistrationNumber = '" & RegCode & "'", cnn)
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
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Medical Aids Name Fetch"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub LoadDependants()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT DependentCode, GivenNames, Gender, IdNumber, " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [DOB], TransactionId " _
            & "FROM OchmasDependents WHERE PatientId = " & intSelectedPatient & " ORDER BY DependentCode"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(Format(CInt(objReader(0).ToString), "00"), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Patient Dependants Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
