Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class PatientOne
    Private Sub PatientOne_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblDependents.ForeColor = Color.White
        lblMedaids.ForeColor = Color.White
        lblPersonal.ForeColor = Color.White
        SuperTabControl1.SelectedTabIndex = 0

        LoadSchemes()
        LoadMedicalAids()

        chkMainMember.Checked = True

    End Sub

    Private Sub LoadMedicalAids()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Name +'|'+ RegistrationNumber AS " _
            & "[Details] FROM [OchmasSystemMedicalAids] ORDER BY Name", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrData As New ArrayList


        arrData.Add("--Cash--|0")


        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                arrData.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboMedicalAids.Width - 80

        'Add the items to the drop down box

        With cboMedicalAids
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth1 & ";80"
        End With

        'Get a count of the items
        Dim intItemsCount As Integer = arrData.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboMedicalAids.Items.Clear()

        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboMedicalAids
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Medical Aid Schemes Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboMedicalAids_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMedicalAids.SelectedIndexChanged
        If Not cboMedicalAids.SelectedItem Is Nothing Then
            Cursor = Cursors.WaitCursor
            lblSchemeCode.Text = cboMedicalAids.SelectedItem.Col2
            LoadPackages(lblSchemeCode.Text)
            Cursor = Cursors.Default
        Else
            lblSchemeCode.Text = "0"
        End If
    End Sub

    Private Sub LoadPackages(ByVal SchemeCode As String)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Package FROM OchmasSystemMedicalAidPackages WHERE RegistrationNumber = '" & SchemeCode & "' ORDER BY Package"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboPackage.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboPackage.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        If cboPackage.Items.Count <= 0 Then cboPackage.Enabled = False Else cboPackage.Enabled = True
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Medical Aid Scheme Packages Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        boolabort = False
        Dim frm As New frmPatientsListing
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        ClearControls()
        LoadSelectedPatientDetails(intSelectedPatient)
    End Sub

    Private Sub LoadSelectedPatientDetails(PatientNumber As Integer)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        lblPatientId.Text = intSelectedPatient

        strSql = "SELECT * FROM OchmasPatients WHERE PatientId = " & intSelectedPatient & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("LastName").ToString) Then txtLastName.Text = objReader("LastName").ToString
            If Not IsDBNull(objReader("FirstName").ToString) Then txtFirstName.Text = objReader("FirstName").ToString
            If Not IsDBNull(objReader("OtherNames").ToString) Then txtOtherNames.Text = objReader("OtherNames").ToString
            If Not IsDBNull(objReader("IdNumber").ToString) Then txtIdNumber.Text = objReader("IdNumber").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("Address").ToString) Then txtAddress.Text = objReader("Address").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmail.Text = objReader("EmailAddress").ToString
            Dim dblAge As Double = 0
            If IsDate(objReader("BirthDate").ToString) Then
                lblDob.Text = UCase(Format(CDate(objReader("BirthDate".ToString)), "dd-MMM-yyyy"))
                dpDob.Value = CDate(objReader("BirthDate").ToString)
                dblAge = DateDiff(DateInterval.Day, CDate(objReader("BirthDate").ToString), Now)
                dblAge = Math.Round((dblAge / 365.25), 2)
            End If

            Dim strGender As String = "FEMALE"
            If Not IsDBNull(objReader("Gender").ToString) Then
                strGender = objReader("gender").ToString
                cboGender.Text = objReader("gender").ToString
            End If
            lblAgeGender.Text = UCase(CStr(dblAge) & " YRS " & UCase(strGender))

        End If
        objReader.Close()

        Dim strLname As String = Nothing
        If Not String.IsNullOrEmpty(txtLastName.Text) Then
            strLname = UCase(Mid(txtLastName.Text, 1, 1)) & LCase(Mid(txtLastName.Text, 2, txtLastName.Text.Length - 1))
        End If

        Dim strFname As String = Nothing
        If Not String.IsNullOrEmpty(txtFirstName.Text) Then
            strFname = UCase(Mid(txtFirstName.Text, 1, 1)) & LCase(Mid(txtFirstName.Text, 2, txtFirstName.Text.Length - 1))
        End If

        Dim strOname As String = Nothing
        If Not String.IsNullOrEmpty(txtOtherNames.Text) Then
            strOname = UCase(Mid(txtOtherNames.Text, 1, 1)) & LCase(Mid(txtOtherNames.Text, 2, txtOtherNames.Text.Length - 1))
        End If

        lblPatientNames.Text = strLname & " " & strFname & " " & strOname

        'Get the medical aid data here


        'Get the dependents here

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Patient Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ClearControls()
        txtAddress.Text = Nothing
        txtCellphone.Text = Nothing
        txtEmail.Text = Nothing
        txtFirstName.Text = Nothing
        txtIdNumber.Text = Nothing
        txtLastName.Text = Nothing
        txtMainMember.Text = Nothing
        txtMedNo.Text = Nothing
        txtOtherNames.Text = Nothing
        txtTelephone.Text = Nothing
        cboPackage.Text = Nothing
        cboMedicalAids.SelectedIndex = 0
        dGridDependants.Rows.Clear()
        chkMainMember.Checked = True
    End Sub

    Private Sub btnNewPatient_Click(sender As Object, e As EventArgs) Handles btnNewPatient.Click
        ClearControls()
    End Sub

    Private Sub btnNewDispense_Click(sender As Object, e As EventArgs) Handles btnNewScheme.Click
        boolEditStatus = False
        Dim frm As New frmMedicalSchemeSetup
        frm.ShowDialog()
        LoadSchemes()
    End Sub

    Private Sub LoadSchemes()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT RegistrationNumber AS [Scheme Code], Name AS [Scheme Name], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), RegistrationDate, 106), ' ', '-')) as [Reg. Date], SchemeType as [Type], " _
            & "UPPER(ISNULL(PostalAddress1, '')) +' '+ UPPER(ISNULL(PostalAddress2, '')) +' '+ UPPER(ISNULL (PostalAddress3, '')) " _
            & "+' '+ UPPER(ISNULL (PostalAddress4, '')) AS [Address], Telephone AS [Phone] FROM OchmasSystemMedicalAids ORDER BY Name"

        dGridSchemes.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridSchemes.DataSource = dTable

        Me.dGridSchemes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGridSchemes.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGridSchemes.Columns.Count - 1
            dGridSchemes.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Medical Aid Schemes Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEditSchem_Click(sender As Object, e As EventArgs) Handles btnEditSchem.Click
        OpenDataForEdit()
    End Sub

    Private Sub OpenDataForEdit()
        If dGridSchemes.Rows.Count <= 0 Then Exit Sub
        If Not Object.Equals(dGridSchemes.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridSchemes.CurrentRow.Cells(0).Value.ToString) Then
                strSelectedMedicalScheme = dGridSchemes.CurrentRow.Cells(0).Value.ToString
                boolEditStatus = True
                Dim frm As New frmMedicalSchemeSetup
                frm.ShowDialog()
                LoadSchemes()
            End If
        End If
    End Sub

    Private Sub dGridSchemes_DoubleClick(sender As Object, e As EventArgs) Handles dGridSchemes.DoubleClick
        OpenDataForEdit()
    End Sub

    Private Sub txtSearchString_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            SearchForItem(txtSearchString.Text)
        End If
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0

        Dim strFind As String = strCurrentKey
        strActiveSearch = strFind

        Cursor = Cursors.WaitCursor

        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        'Scheme Name
        'Scheme Code

        Select Case UCase(cboSearchBy.Text)
            Case Is = UCase("Scheme Name")
                strSql = "SELECT RegistrationNumber AS [Scheme Code], Name AS [Scheme Name], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), RegistrationDate, 106), ' ', '-')) as [Reg. Date], SchemeType as [Type], " _
                    & "UPPER(ISNULL(PostalAddress1, '')) +' '+ UPPER(ISNULL(PostalAddress2, '')) +' '+ UPPER(ISNULL (PostalAddress3, '')) " _
                    & "+' '+ UPPER(ISNULL (PostalAddress4, '')) AS [Address], Telephone AS [Phone] FROM OchmasSystemMedicalAids " _
                    & "WHERE Name LIKE '%" & strFind & "%' ORDER BY Name"

            Case Is = UCase("Scheme Code")
                strSql = "SELECT RegistrationNumber AS [Scheme Code], Name AS [Scheme Name], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), RegistrationDate, 106), ' ', '-')) as [Reg. Date], SchemeType as [Type], " _
                    & "UPPER(ISNULL(PostalAddress1, '')) +' '+ UPPER(ISNULL(PostalAddress2, '')) +' '+ UPPER(ISNULL (PostalAddress3, '')) " _
                    & "+' '+ UPPER(ISNULL (PostalAddress4, '')) AS [Address], Telephone AS [Phone] FROM OchmasSystemMedicalAids " _
                    & "WHERE RegistrationNumber LIKE '%" & strFind & "%' ORDER BY RegistrationNumber"
            Case Else
                strSql = "SELECT RegistrationNumber AS [Scheme Code], Name AS [Scheme Name], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), RegistrationDate, 106), ' ', '-')) as [Reg. Date], SchemeType as [Type], " _
                    & "UPPER(ISNULL(PostalAddress1, '')) +' '+ UPPER(ISNULL(PostalAddress2, '')) +' '+ UPPER(ISNULL (PostalAddress3, '')) " _
                    & "+' '+ UPPER(ISNULL (PostalAddress4, '')) AS [Address], Telephone AS [Phone] FROM OchmasSystemMedicalAids " _
                    & "WHERE Name LIKE '%" & strFind & "%' ORDER BY Name"
        End Select

        dGridSchemes.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridSchemes.DataSource = dTable

        Me.dGridSchemes.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGridSchemes.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGridSchemes.Columns.Count - 1
            dGridSchemes.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On medical aid schemes search"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnRefreshScheme_Click(sender As Object, e As EventArgs) Handles btnRefreshScheme.Click
        LoadSchemes()
    End Sub

    Private Sub btnDeleteScheme_Click(sender As Object, e As EventArgs) Handles btnDeleteScheme.Click
        On Error GoTo RaiseErr
        If dGridSchemes.Rows.Count <= 0 Then Exit Sub

        If MessageBox.Show("Are you sure you want to delete the selected scheme?", "Comfirm Scheme Delete",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If Not Object.Equals(dGridSchemes.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridSchemes.CurrentRow.Cells(0).Value.ToString) Then
                    strSelectedMedicalScheme = dGridSchemes.CurrentRow.Cells(0).Value.ToString
                    Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM OchmasSystemMedicalAids " _
                    & "WHERE RegistrationNumber = '" & strSelectedMedicalScheme & "'", cnn)
                    objCommand.ExecuteNonQuery()

                    MessageBox.Show("Scheme has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadSchemes()
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On medical aid schemes delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub chkMainMember_CheckedChanged(sender As Object, e As EventArgs) Handles chkMainMember.CheckedChanged
        If chkMainMember.Checked Then
            txtMainMember.Enabled = False
            txtSuffix.Text = "00"
            txtSuffix.Enabled = False
        Else
            txtMainMember.Enabled = True
            txtSuffix.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtLastName.Text) Then
            MessageBox.Show("Please enter the last name", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLastName.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtFirstName.Text) Then
            MessageBox.Show("Please enter the first name", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirstName.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress.Text) Then
            MessageBox.Show("Please enter the address", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress.Select()
            Exit Sub
        End If

        If chkMainMember.Checked = False Then
            If lblMaimMemberPid.Text = "0" Or lblMaimMemberPid.Text = Nothing Then
                MessageBox.Show("Please enter the details of the main member", "Missing Main Member Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtMainMember.Select()
                Exit Sub
            End If
        End If

        Dim strBillingMethod As String = "CASH"
        If cboMedicalAids.Text <> "--CASH--" Then strBillingMethod = "MEDICAL AID"

        Dim intDependentCode As Integer = 0
        If IsNumeric(txtSuffix.Text) Then intDependentCode = CInt(txtSuffix.Text)

        Dim strSql As String = Nothing

        If lblPatientId.Text = "0" Then
            strSql = "INSERT INTO OchmasPatients (LastName, FirstName, OtherNames, BirthDate, Gender, Telephone, Cellphone, " _
                & "EmailAddress, Address, Branch, UserName, ChangeDate, billingmethod, DependentCode, InceptionDate, " _
                & "MedicalAid, MedicalAidNumber, IdNumber, MainMemberId) VALUES " _
                & "('" & txtLastName.Text & "', '" & txtFirstName.Text & "', '" & txtOtherNames.Text & "', " _
                & "'" & Format(dpDob.Value, "dd-MMM-yyyy") & "', '" & cboGender.Text & "', '" & txtTelephone.Text & "', " _
                & "'" & txtCellphone.Text & "', '" & txtEmail.Text & "', '" & txtAddress.Text & "', '" & strUserBranch & "', " _
                & "'" & strUserName & "', '" & Now & "', '" & strBillingMethod & "', " & intDependentCode & ", " _
                & "'" & Now & "', '" & lblSchemeCode.Text & "', '" & txtMedNo.Text & "', '" & txtIdNumber.Text & "', " _
                & " " & CInt(lblMaimMemberPid.Text) & ")"
        Else
            strSql = "UPDATE OchmasPatients SET LastName = '" & txtLastName.Text & "', FirstName = '" & txtFirstName.Text & "', " _
                & "OtherNames = '" & txtOtherNames.Text & "', BirthDate = '" & Format(dpDob.Value, "dd-MMM-yyyy") & "', " _
                & "Gender = '" & cboGender.Text & "', Telephone = '" & txtTelephone.Text & "', Cellphone = '" & txtCellphone.Text & "', " _
                & "EmailAddress = '" & txtEmail.Text & "', Address = '" & txtAddress.Text & "', Branch = '" & strUserBranch & "', " _
                & "UserName = '" & strUserName & "', ChangeDate = '" & Now & "', billingmethod = '" & strBillingMethod & "', " _
                & "DependentCode = " & intDependentCode & ", InceptionDate = '" & Now & "', MedicalAid = '" & lblSchemeCode.Text & "', " _
                & "MedicalAidNumber = '" & txtMedNo.Text & "', IdNumber = '" & txtIdNumber.Text & "', MainMemberId = " & CInt(lblMaimMemberPid.Text) & " " _
                & "WHERE PatientId = " & CInt(lblPatientId.Text) & ""
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        If lblPatientId.Text = "0" Then
            intSelectedPatient = 0
            objCommand = New Data.OleDb.OleDbCommand("SELECT PatientId FROM OchmasPatients ORDER BY PatientId DESC", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader(0).ToString) Then intSelectedPatient = CInt(objReader(0).ToString)
            End If
            objReader.Close()
            LoadSelectedPatientDetails(intSelectedPatient)
        End If

        MessageBox.Show("Patient details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On medical aid schemes delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnFindMember_Click(sender As Object, e As EventArgs) Handles btnFindMember.Click
        intSelectedPatient = 0
        strSelectedPatientFullDetails = Nothing
        Dim frm As New frmPatientsListing
        frm.ShowDialog()
        txtMainMember.Text = strSelectedPatientFullDetails
        lblMaimMemberPid.Text = intSelectedPatient
    End Sub

End Class
