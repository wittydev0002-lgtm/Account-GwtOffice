Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports AdvancedDataGridView

Public Class frmPatientSetup

    Dim boolFormLoading As Boolean
    Dim dblTotalConsultationBills As Double

    Private Sub frmPatientSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        boolFormLoading = True

        '******* FORMAT THE TREEGRIDVIEW********************************
        Me.imageStrip.ImageSize = New System.Drawing.Size(16, 16)
        Me.imageStrip.TransparentColor = System.Drawing.Color.Magenta
        Me.imageStrip.ImageSize = New Size(16, 16)

        dGridConsultations.ImageList = imageStrip

        LoadMedicalAids()
        If boolEditStatus = True Then
            lblPatientId.Text = intSelectedPatient
            LoadData()
            LoadObservations()
            LoadMainConsultations()
        End If
        txtLastName.Select()
        txtLastName.SelectAll()
        boolFormLoading = False
    End Sub

    Private Sub LoadObservations()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date], " _
            & "CAST(Temperature AS DECIMAL (10,2)), CAST(Weight AS DECIMAL (10,2)), " _
            & "CONVERT(NVARCHAR, Systolic) +'/'+ CONVERT(NVARCHAR, Diastolic) AS [BP], " _
            & "Pulse, CAST(Height AS DECIMAL (10,2)), Breathing, TransactionId " _
            & "FROM OchmasKeyVitals WHERE Pid = " & intSelectedPatient & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        dGridObs.Rows.Clear()
        While objReader.Read()
            dGridObs.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3),
                objReader(4), objReader(5), objReader(6), objReader(7))
        End While
        objReader.Close()


        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.WaitCursor
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Observations load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadMedicalAids()
        On Error GoTo RaiseErr

        Dim arrData As New ArrayList
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Name, SchemeCode " _
            & "From OchmasSystemMedicalAids ORDER BY Name", cnn)
        objReader = objCommand.ExecuteReader

        With cboMedicalAidScheme
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "250;80"
        End With

        While objReader.Read
            If Not IsDBNull(objReader("Name").ToString) Or
                 Not String.IsNullOrEmpty(objReader("SchemeCode").ToString) Then
                arrData.Add(UCase(objReader("Name").ToString & ";" & objReader("SchemeCode").ToString))
            End If
        End While
        objReader.Close()

        Dim DropDownItems(arrData.Count - 1) As MTGCComboBoxItem

        For p As Integer = 0 To arrData.Count - 1
            Dim strRecordText() As String = Split(arrData.Item(p).ToString, ";")
            DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
        Next

        With cboMedicalAidScheme
            .SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            .Items.AddRange(DropDownItems)
        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.WaitCursor
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On medical aids load"
        ShowErrorMessage()
    End Sub

    Private Function ParentNames(ByVal ParentId As Integer) As String
        Dim strReturn As String = Nothing
        Dim strSql As String = "SELECT LastName +' '+ FirstName +' '+ OtherNames AS [Given Names] FROM OchmasPatients " _
            & "WHERE PatientId = " & ParentId & " And MainMemberId = 0"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
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
        Cursor = Cursors.WaitCursor
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Parent Names Fetch"
        ShowErrorMessage()
    End Function

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM OchmasPatients WHERE PatientId = " & intSelectedPatient & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("LastName").ToString) Then txtLastName.Text = objReader("LastName").ToString
            If Not IsDBNull(objReader("FirstName").ToString) Then txtFirstName.Text = objReader("FirstName").ToString
            If Not IsDBNull(objReader("OtherNames").ToString) Then txtOtherNames.Text = objReader("OtherNames").ToString
            If Not IsDBNull(objReader("IdNumber").ToString) Then txtIdNumber.Text = objReader("IdNumber").ToString
            If Not IsDBNull(objReader("Gender").ToString) Then cboGender.Text = objReader("Gender").ToString
            If Not IsDBNull(objReader("BillingMethod").ToString) Then cboPayMethod.Text = objReader("BillingMethod").ToString
            If Not IsDBNull(objReader("MaritalStatus").ToString) Then cboMaritalStatus.Text = objReader("MaritalStatus").ToString
            If Not IsDBNull(objReader("FileNumber").ToString) Then txtFileNumber.Text = objReader("FileNumber").ToString
            If IsDate(objReader("BirthDate").ToString) Then dpDob.Text = CDate(objReader("BirthDate").ToString)
            If Not IsDBNull(objReader("MainMemberId").ToString) Then
                lblParentId.Text = objReader("MainMemberId").ToString
                If IsNumeric(lblPatientId.Text) Then
                    If CInt(lblPatientId.Text) > 0 Then
                        lblParentNames.Text = ParentNames(CInt(lblPatientId.Text))
                        cboMainMemberStatus.Text = "Yes"
                    End If
                Else
                    cboMainMemberStatus.Text = "No"
                End If
            End If
            If Not IsDBNull(objReader("Telephone").ToString) Then txtContactNumber.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("ReferredBy").ToString) Then txtReferral.Text = objReader("ReferredBy").ToString
            If IsNumeric(objReader("DependentCode").ToString) Then txtMedaidSuffix.Text = Format(CInt(objReader("DependentCode").ToString), "00")
        End If
        objReader.Close()

        'Load Medical Aid Information
        strSql = "SELECT  SchemeNumber, SchemeName, MemberCategory, MemberNumber, ExpiryDate " _
            & "FROM OchmasMedaidMembership WHERE PatientId = " & intSelectedPatient & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("SchemeNumber").ToString) Then lblSchemeCode.Text = objReader("SchemeNumber").ToString
            If Not IsDBNull(objReader("SchemeName").ToString) Then cboMedicalAidScheme.Text = objReader("SchemeName").ToString
            If Not IsDBNull(objReader("MemberCategory").ToString) Then cboPackage.Text = objReader("MemberCategory").ToString
            If Not IsDBNull(objReader("MemberNumber").ToString) Then txtMedaidNumber.Text = objReader("MemberNumber").ToString
            If Not IsDBNull(objReader("ExpiryDate").ToString) Then dpMedaidExpireDate.Value = objReader("ExpiryDate").ToString
        End If
        objReader.Close()

        'Load the Address details
        strSql = "SELECT  Address1, Address2, Address3, Address4 " _
            & "FROM OchmasAddresses WHERE PatientId = " & intSelectedPatient & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
        End If
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On patient data load"
        ShowErrorMessage()
    End Sub

    Private Sub frmPatientSetup_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 660 : Me.Height = 480 '660; 480
    End Sub

    Private Sub InheritParentData(ByVal ParentId As Integer)
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT Address1, Address2, Address3, Address4 FROM OchmasAddresses " _
            & "WHERE PatientId = " & ParentId & " And PatientId IN (SELECT PatientID FROM OchmasPatients WHERE MainMemberId = 0)"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtAddress1.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtAddress2.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtAddress3.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then txtAddress4.Text = objReader(3).ToString
        End If
        objReader.Close()

        'Get the medical aid data
        Dim strBillingMethod As String = Nothing
        strSql = "SELECT billingmethod FROM OchmasPatients WHERE PatientId = " & ParentId & " And MainMemberId = 0"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            strBillingMethod = UCase(objReader(0).ToString)
        End If
        objReader.Close()

        If UCase(strBillingMethod) = UCase("Medical Aid") Then
            strSql = "SELECT OchmasMedaidMembership.SchemeNumber, OchmasMedaidMembership.SchemeName, " _
                & "OchmasMedaidMembership.MemberCategory, OchmasMedaidMembership.MemberNumber, " _
                & "OchmasMedaidMembership.ExpiryDate, OchmasPatients.DependentCode FROM OchmasMedaidMembership " _
                & "LEFT OUTER JOIN OchmasPatients ON OchmasPatients.PatientId = OchmasMedaidMembership.PatientId " _
                & "WHERE OchmasPatients.PatientId = " & ParentId & " And MainMemberId = 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then lblSchemeCode.Text = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then cboMedicalAidScheme.Text = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then cboPackage.Text = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then txtMedaidNumber.Text = objReader(3).ToString
                If IsDate(objReader(4).ToString) Then dpMedaidExpireDate.Value = CDate(objReader(4).ToString)
                If Not IsDBNull(objReader(5).ToString) Then txtMedaidSuffix.Text = objReader(5).ToString
            End If
            objReader.Close()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On parent data inherit"
        ShowErrorMessage()
    End Sub

    Private Sub cboMainMemberStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMainMemberStatus.SelectedIndexChanged
        If boolFormLoading = True Then Exit Sub
        If UCase(cboMainMemberStatus.Text) = "NO" Then
            boolAbort = False
            boolParentRecordSearch = True
            Dim frm As New frmPatientSearch
            frm.ShowDialog()
            boolParentRecordSearch = False
            If boolAbort = True Then
                cboMainMemberStatus.Text = "Yes"
                Exit Sub
            End If
            lblParentId.Text = strSelectedAccount
            lblParentNames.Text = strSelectedAccountName
            'Assign the other details automatically. Inherit from the parent record
            InheritParentData(CInt(lblParentId.Text))
        Else
            lblParentId.Text = Nothing
            lblParentNames.Text = Nothing
        End If
    End Sub

    Private Sub cboPayMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayMethod.SelectedIndexChanged
        If boolFormLoading = True Then Exit Sub
        If UCase(cboPayMethod.Text) = "" Or UCase(cboPayMethod.Text) = "" Then
            boolAbort = False
            ResetValues()
            Dim frm As New frmPatientMedicalAidDataEntry
            frm.ShowDialog()
            If boolAbort = True Then Exit Sub
            cboMedicalAidScheme.Text = strSelectedMedicalSchemeName
            cboPackage.Text = strSelectedMedicalSchemePackage
            txtMedaidNumber.Text = strSelectedPatientMedaidNumber
            txtMedaidSuffix.Text = strSelectedPatientMedaidSuffix
            lblSchemeCode.Text = strSelectedMedicalSchemeCode
            If IsDate(strSelectedDate) Then dpMedaidExpireDate.Value = CDate(strSelectedDate)
            ResetValues()
        End If
    End Sub

    Private Sub ResetValues()
        strSelectedDate = Nothing
        strSelectedMedicalSchemeName = Nothing
        strSelectedMedicalSchemePackage = Nothing
        strSelectedPatientMedaidNumber = Nothing
        strSelectedPatientMedaidSuffix = "0"
        strSelectedMedicalSchemeCode = Nothing
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtLastName.Text) Then
            MessageBox.Show("Please enter the last name (surname)", "Missing Last Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLastName.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtFirstName.Text) Then
            MessageBox.Show("Please enter the first name", "Missing First Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirstName.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboGender.Text) Then
            MessageBox.Show("Please select patient gender", "Missing Gender", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboGender.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboPayMethod.Text) Then
            MessageBox.Show("Please select patient payment method", "Missing Payment Method", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPayMethod.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboMainMemberStatus.Text) Then
            MessageBox.Show("Please define if this patient Is the main member Or Not", "Missing Membership Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboMainMemberStatus.Select()
            Exit Sub
        End If

        If Not IsNumeric(txtMedaidSuffix.Text) Then txtMedaidSuffix.Text = "0"

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        Dim strSql As String = Nothing

        Cursor = Cursors.WaitCursor

        If boolEditStatus = False Then

            Dim boolInsertRecord As Boolean = True

            If PatientExists(txtLastName.Text, txtFirstName.Text, txtOtherNames.Text) = True Then
                If MessageBox.Show("It looks like the record already exists. Do you want to go ahead and add this one?", "Possible Duplicate Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    boolInsertRecord = True
                Else
                    boolInsertRecord = False
                    Cursor = Cursors.Default
                    txtLastName.SelectAll()
                    txtLastName.Focus()
                    Exit Sub
                End If
            End If

            If boolInsertRecord = True Then

                strSql = "INSERT INTO OchmasPatients (LastName, FirstName, OtherNames, Gender, BillingMethod, " _
                    & "BirthDate, InceptionDate, FileNumber, MaritalStatus, DependentCode, IdNumber, " _
                    & "MainMemberId, Branch, UserName, ChangeDate, Telephone, ReferredBy) VALUES ('" & txtLastName.Text & "', " _
                    & "'" & txtFirstName.Text & "', '" & txtOtherNames.Text & "', '" & cboGender.Text & "', " _
                    & "'" & cboPayMethod.Text & "', '" & gwt_comm.shortMonthDateFormat(dpDob.Value) & "', " _
                    & "'" & gwt_comm.shortMonthDateFormat(Now) & "', '" & txtFileNumber.Text & "', '" & cboMaritalStatus.Text & "', " _
                    & "" & txtMedaidSuffix.Text & ", '" & txtIdNumber.Text & "', '" & lblParentId.Text & "', " _
                    & "'" & strUserBranch & "', '" & strUserName & "', '" & Now & "', '" & txtContactNumber.Text & "', '" & txtReferral.Text & "')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                'Get the key of the last record used
                Dim intLastRecordId As Integer = 1
                strSql = "SELECT IDENT_CURRENT('OchmasPatients')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then
                        intLastRecordId = CInt(objReader(0).ToString)
                    End If
                End If
                objReader.Close()

                UpdateSupplimentaryData(intLastRecordId)

            End If

        Else

            strSql = "UPDATE OchmasPatients SET LastName = '" & txtLastName.Text & "', " _
                & "FirstName = '" & txtFirstName.Text & "', OtherNames = '" & txtOtherNames.Text & "', " _
                & "Gender = '" & cboGender.Text & "', BillingMethod = '" & cboPayMethod.Text & "', " _
                & "BirthDate = '" & gwt_comm.shortMonthDateFormat(dpDob.Value) & "', FileNumber = '" & txtFileNumber.Text & "', " _
                & "MaritalStatus = '" & cboMaritalStatus.Text & "', DependentCode = " & txtMedaidSuffix.Text & ", " _
                & "IdNumber = '" & txtIdNumber.Text & "', MainMemberId = '" & lblParentId.Text & "', " _
                & "Branch = '" & strUserBranch & "', UserName = '" & strUserName & "', " _
                & "Telephone = '" & txtContactNumber.Text & "', [ReferredBy] = '" & txtReferral.Text & "', ChangeDate = '" & Now & "' " _
                & "WHERE PatientId = " & CInt(lblPatientId.Text) & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            UpdateSupplimentaryData(CInt(lblPatientId.Text))

        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()


        If UCase(cboMainMemberStatus.Text) = "YES" Then
            If MessageBox.Show("Do you want to cascade medical aid and address to dependents as well?", "Cascade Changes Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                strSql = "SELECT PatientId FROM OchmasPatients WHERE MainMemberId = " & intSelectedPatient & ""
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objReader = objCommand.ExecuteReader
                While objReader.Read
                    strSql = "DELETE FROM OchmasAddresses WHERE PatientId = " & objReader(0).ToString & ""
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                    strSql = "INSERT INTO OchmasAddresses (Address1, Address2, Address3, Address4, PatientId) VALUES " _
                        & "('" & txtAddress1.Text & "', '" & txtAddress2.Text & "', '" & txtAddress3.Text & "', " _
                        & "'" & txtAddress4.Text & "', " & objReader(0).ToString & ")"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                    'Do the same for medical aid membership except for suffix
                    strSql = "DELETE FROM OchmasMedaidMembership WHERE PatientId = " & objReader(0).ToString & ""
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                    strSql = "INSERT INTO OchmasMedaidMembership (SchemeNumber, SchemeName, MemberCategory, " _
                        & "MemberNumber, ExpiryDate, Branch, UserName, ChangeDate, PatientId) VALUES " _
                        & "('" & lblSchemeCode.Text & "', '" & cboMedicalAidScheme.Text & "', '" & cboPackage.Text & "', " _
                        & "'" & txtMedaidNumber.Text & "', '" & gwt_comm.shortMonthDateFormat(dpMedaidExpireDate.Value) & "', " _
                        & "'" & strUserBranch & "', '" & strUserName & "', '" & gwt_comm.shortMonthDateFormat(Now) & "', " & objReader(0).ToString & ")"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                End While
            End If
        End If

        Cursor = Cursors.Default

        MessageBox.Show("Patient details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Patient Details Save"
        ShowErrorMessage()
    End Sub

    Private Function PatientExists(LastName As String, FirstName As String, OtherNames As String) As Boolean
        Dim boolReturn As Boolean = False
        Dim strSql As String = "SELECT PatientId FROM OchmasPatients WHERE " _
            & "(LastName LIKE '%" & LastName & "%' AND FirstName LIKE '%" & FirstName & "%')"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            boolReturn = True
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Patient Existence Validation"
        ShowErrorMessage()
    End Function

    Private Sub UpdateSupplimentaryData(ByVal PatientId As Integer)
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        'Save the Address but you need to delete the record first
        strSql = "DELETE FROM OchmasAddresses WHERE PatientId = " & PatientId & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "INSERT INTO OchmasAddresses (PatientId, Address1, Address2, Address3, Address4) VALUES " _
                & "(" & PatientId & ", '" & txtAddress1.Text & "', '" & txtAddress2.Text & "', " _
                & "'" & txtAddress3.Text & "', '" & txtAddress4.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Save the medical aid information
        strSql = "DELETE FROM OchmasMedaidMembership WHERE PatientId = " & PatientId & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "INSERT INTO OchmasMedaidMembership (SchemeNumber, SchemeName, MemberCategory, " _
            & "MemberNumber, ExpiryDate, Branch, UserName, ChangeDate, PatientId) VALUES " _
            & "('" & lblSchemeCode.Text & "', '" & cboMedicalAidScheme.Text & "', '" & cboPackage.Text & "', " _
            & "'" & txtMedaidNumber.Text & "', '" & gwt_comm.shortMonthDateFormat(dpMedaidExpireDate.Value) & "', " _
            & "'" & strUserBranch & "', '" & strUserName & "', '" & gwt_comm.shortMonthDateFormat(Now) & "', " & PatientId & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        If UCase(cboMainMemberStatus.Text) = "YES" Then
            'Cascade changes all the way down
            strSql = "SELECT PatientId FROM OchmasPatients WHERE MainMemberId = " & PatientId & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader
            While objReader.Read

                strSql = "DELETE FROM OchmasMedaidMembership WHERE PatientId = " & objReader(0).ToString & ""
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                strSql = "INSERT INTO OchmasMedaidMembership (SchemeNumber, SchemeName, MemberCategory, " _
                    & "MemberNumber, ExpiryDate, Branch, UserName, ChangeDate, PatientId) VALUES " _
                    & "('" & lblSchemeCode.Text & "', '" & cboMedicalAidScheme.Text & "', '" & cboPackage.Text & "', " _
                    & "'" & txtMedaidNumber.Text & "', '" & gwt_comm.shortMonthDateFormat(dpMedaidExpireDate.Value) & "', " _
                    & "'" & strUserBranch & "', '" & strUserName & "', '" & gwt_comm.shortMonthDateFormat(Now) & "', " & objReader(0).ToString & ")"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

            End While
            objReader.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Patient Details Save"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub cboMedicalAidScheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMedicalAidScheme.SelectedIndexChanged
        lblSchemeCode.Text = Nothing
        lblSchemeCode.Text = cboMedicalAidScheme.SelectedItem.Col2.ToString
        LoadPackages(lblSchemeCode.Text)
    End Sub

    Private Sub LoadPackages(ByVal SchemeCode As String)
        On Error GoTo RaiseErr
        cboPackage.Items.Clear()
        cboPackage.Items.Add("--NONE--")
        Dim strSql As String = "SELECT DISTINCT(Package) FROM OchmasSystemMedicalAidPackages WHERE SchemeCode = '" & SchemeCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            cboPackage.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Medical Aid Scheme Packages Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGridObs_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGridObs.CellContentClick
        If e.ColumnIndex = dGridObs.ColumnCount - 1 Then
            boolEditStatus = True
            intSelectedTransaction = CInt(dGridObs.CurrentRow.Cells(dGridObs.ColumnCount - 2).Value.ToString)
            Dim frm As New frmVitalsEntry
            frm.ShowDialog()
            LoadObservations()
        End If
    End Sub

    Private Sub txtLastName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLastName.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtFirstName.Select()
            txtFirstName.SelectAll()
        End If
    End Sub

    Private Sub txtFirstName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFirstName.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtOtherNames.Select()
            txtOtherNames.SelectAll()
        End If
    End Sub

    Private Sub txtOtherNames_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtherNames.KeyDown
        If e.KeyValue = Keys.Enter Then
            dpDob.Select()
        End If
    End Sub

    Private Sub dpDob_KeyDown(sender As Object, e As KeyEventArgs) Handles dpDob.KeyDown
        If e.KeyValue = Keys.Enter Then
            cboGender.Select()
        End If
    End Sub

    Private Sub cboGender_KeyDown(sender As Object, e As KeyEventArgs) Handles cboGender.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtIdNumber.Select()
            txtIdNumber.SelectAll()
        End If
    End Sub

    Private Sub txtIdNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdNumber.KeyDown
        If e.KeyValue = Keys.Enter Then
            cboPayMethod.Select()
        End If
    End Sub

    Private Sub cboPayMethod_KeyDown(sender As Object, e As KeyEventArgs) Handles cboPayMethod.KeyDown
        If e.KeyValue = Keys.Enter Then
            cboMainMemberStatus.Select()
        End If
    End Sub

    Private Sub cboMainMemberStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles cboMainMemberStatus.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtContactNumber.Select()
            txtContactNumber.SelectAll()
        End If
    End Sub

    Private Sub txtContactNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContactNumber.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtReferral.Select()
            txtReferral.SelectAll()
        End If
    End Sub

    Private Sub txtReferral_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferral.KeyDown
        If e.KeyValue = Keys.Enter Then
            cboMaritalStatus.Select()
            cboMaritalStatus.SelectAll()
        End If
    End Sub

    Private Sub cboMaritalStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles cboMaritalStatus.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtFileNumber.Select()
            txtFileNumber.SelectAll()
        End If
    End Sub

    Private Sub txtFileNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFileNumber.KeyDown
        If e.KeyValue = Keys.Enter Then
            TabControl1.SelectedIndex = 1
            txtAddress1.Select()
            txtAddress1.SelectAll()
        End If
    End Sub

    Private Sub txtAddress1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress1.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtAddress2.Select()
            txtAddress2.SelectAll()
        End If
    End Sub

    Private Sub txtAddress2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress2.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtAddress3.Select()
            txtAddress3.SelectAll()
        End If
    End Sub

    Private Sub txtAddress3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress3.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtAddress4.Select()
            txtAddress4.SelectAll()
        End If
    End Sub

    Private Sub txtAddress4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress4.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtEmailAddress.Select()
            txtEmailAddress.SelectAll()
        End If
    End Sub

    Private Sub txtEmailAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmailAddress.KeyDown
        If e.KeyValue = Keys.Enter Then
            TabControl1.SelectedIndex = 2
            cboMedicalAidScheme.Select()
        End If
    End Sub

    Private Sub cboMedicalAidScheme_KeyDown(sender As Object, e As KeyEventArgs) Handles cboMedicalAidScheme.KeyDown
        If e.KeyValue = Keys.Enter Then
            cboPackage.Select()
        End If
    End Sub

    Private Sub cboPackage_KeyDown(sender As Object, e As KeyEventArgs) Handles cboPackage.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtMedaidNumber.Select()
            txtMedaidNumber.SelectAll()
        End If
    End Sub

    Private Sub txtMedaidNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMedaidNumber.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtMedaidSuffix.Select()
            txtMedaidSuffix.SelectAll()
        End If
    End Sub

    Private Sub txtMedaidSuffix_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMedaidSuffix.KeyDown
        If e.KeyValue = Keys.Enter Then
            dpMedaidExpireDate.Select()
        End If
    End Sub

    Private Sub dpMedaidExpireDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dpMedaidExpireDate.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnOk.Select()
        End If
    End Sub

    Private Sub btnDiagnosisTreatment_Click(sender As Object, e As EventArgs) Handles btnDiagnosisTreatment.Click
        boolEditStatus = False
        Dim frm As New frmDiagnosisAndTreatment
        frm.ShowDialog()
    End Sub

    Private Sub LoadMainConsultations()
        On Error GoTo RaiseErr

        dGridConsultations.Rows.Clear()
        dblTotalConsultationBills = 0

        Dim boldFont As Font = New Font(dGridConsultations.DefaultCellStyle.Font, FontStyle.Bold)

        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), OchmasBillingMain.TransDate, 106), ' ', '-')) as [Date], " _
            & "OchmasBillingMain.DocumentNumber AS [Ref. #], " _
            & "OchmasBillingMain.SchemeCode AS [Code], OchmasSystemMedicalAids.Name AS [Description], " _
            & "OchmasBillingMain.PayMode AS [Type], CAST(OchmasBillingMain.Amount AS DECIMAL (10,2)) AS [Amount] " _
            & "FROM OchmasBillingMain " _
            & "LEFT OUTER JOIN OchmasSystemMedicalAids ON OchmasBillingMain.SchemeCode = OchmasSystemMedicalAids.SchemeCode " _
            & "WHERE OchmasBillingMain.PatientId = " & intSelectedPatient & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read

            If IsNumeric(objReader(5).ToString) Then
                dblTotalConsultationBills = dblTotalConsultationBills + CDbl(objReader(5).ToString)
            End If

            Dim node As TreeGridNode = dGridConsultations.Nodes.Add(objReader(0).ToString(), objReader(1).ToString,
                objReader(2).ToString, objReader(3).ToString, objReader(4).ToString, CStr(Format(CDbl(objReader(5).ToString), "##0.00")))
            node.ImageIndex = 4
            node.DefaultCellStyle.Font = boldFont

            LoadSubConsultations(node, CInt(objReader(1).ToString))

        End While

        objReader.Close()

        lblConbills.Text = Format(dblTotalConsultationBills, "##0.00")

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Main Consultations Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSubConsultations(ByRef sNode As TreeGridNode, DocumentId As Integer)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT ROW_NUMBER() OVER (ORDER BY TransactionID) AS [Row], " _
            & "OchmasBillingDetails.ItemCode AS [Code], OchmasBillingDetails.Description AS [Description], " _
            & "OchmasBillingDetails.ItemType AS [Type], " _
            & "CAST((OchmasBillingDetails.UnitPrice * OchmasBillingDetails.Quantity) AS DECIMAL (10,2)) AS [Amount] " _
            & "FROM OchmasBillingDetails WHERE DocumentNumber = " & DocumentId & ""

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            sNode.Nodes.Add(Nothing, objReader(0).ToString(), objReader(1).ToString,
                objReader(2).ToString, objReader(3).ToString, CStr(Format(CDbl(objReader(4).ToString), "##0.00")))
            sNode.ImageIndex = 3
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Sub Consultations Load"
        ShowErrorMessage()
    End Sub

End Class