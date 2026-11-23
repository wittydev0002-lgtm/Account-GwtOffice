Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPatientDetails

    Dim boolPriorStatus As Boolean

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtLastName.Text) Then
            MessageBox.Show("Please enter the last name", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLastName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtFirstName.Text) Then
            MessageBox.Show("Please enter the first name", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirstName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the address", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If
        If Not String.IsNullOrEmpty(lblMedAidCode.Text) Then
            If String.IsNullOrEmpty(txtMedaidNumber.Text) Then
                MessageBox.Show("Please enter the medical aid number", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtMedaidNumber.Focus()
                Exit Sub
            End If
        End If

        Dim strSql As String = Nothing
        Dim intPatientId As Integer = gwt_comm.GetNextDocumentNumber("Patients")
        Dim objCommand As Data.OleDb.OleDbCommand

        If boolEditStatus = False Then
            strSql = "INSERT INTO OchmasPatients ([PatientId],[LastName],[FirstName],[BirthDate]," _
                & "[Gender],[MaritalStatus],[Telephone],[Cellphone],[EmailAddress],[Address1]," _
                & "[Address2],[Address3],[Address4],[Branch],[UserName],[ChangeDate]," _
                & "[DependentCode],[InceptionDate],[FileNumber], [Employer], [MedicalAid], " _
                & "[MedicalAidNumber], [IdNumber]) VALUES " _
                & "(" & intPatientId & ", '" & txtLastName.Text & "', '" & txtFirstName.Text & "', " _
                & "'" & Format(dpDob.Value, "dd-MMM-yyyy") & "', '" & cboGender.Text & "', '" & cboMaritalStatus.Text & "', " _
                & "'" & txtTelephone.Text & "', '" & txtCellphone.Text & "', '" & txtEmailAddress.Text & "', " _
                & "'" & txtAddress1.Text & "', '" & txtAddress2.Text & "', '" & txtAddress3.Text & "', " _
                & "'" & txtAddress4.Text & "', '" & strUserBranch & "', '" & strPublicActiveFullUserName & "', " _
                & "'" & Now & "', 0, '" & Format(Now, "dd-MMM-yyyy") & "', '" & txtFileNumber.Text & "', " _
                & "'" & txtEmployer.Text & "', '" & lblMedAidCode.Text & "', '" & txtMedaidNumber.Text & "', " _
                & "'" & txtIdNumber.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            'Insert the kin details
            strSql = "INSERT INTO [OchmasKins] ([PatientId],[KinName],[KinRelation],[KinAddress1],[KinAddress2],[KinAddress3]," _
                & "[KinAddress4],[Telephone],[Cellphone],[Branch],[UserName],[ChangeDate],[EmailAddress],[WhatsappNumber]) VALUES " _
                & "(" & intPatientId & ", '" & txtKinNames.Text & "', '" & txtRelationship.Text & "', '" & txtKinAddress1.Text & "', '" & txtAddress2.Text & "', " _
                & "'" & txtKinAddress3.Text & "', '" & txtKinAddress4.Text & "', '" & txtKinTelephone.Text & "', " _
                & "'" & txtKinMobile.Text & "', '" & strUserBranch & "', '" & strPublicActiveFullUserName & "', " _
                & "'" & Now & "', '" & txtKinEmailAddress.Text & "', '" & txtKinWhatsapp.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Else
            strSql = "UPDATE OchmasPatients SET [LastName] = '" & txtLastName.Text & "', [FirstName] = '" & txtFirstName.Text & "', " _
                & "[BirthDate] = '" & Format(dpDob.Value, "dd-MMM-yyyy") & "'," _
               & "[Gender] = '" & cboGender.Text & "', [MaritalStatus] = '" & cboMaritalStatus.Text & "', " _
               & "[Telephone] = '" & txtTelephone.Text & "', [Cellphone] = '" & txtCellphone.Text & "', " _
               & "[EmailAddress] = '" & txtEmailAddress.Text & "', [Address1] = '" & txtAddress1.Text & "', " _
               & "[Address2] = '" & txtAddress2.Text & "', [Address3] = '" & txtAddress3.Text & "', " _
               & "[Address4] = '" & txtAddress4.Text & "', [Branch] = '" & strUserBranch & "', " _
               & "[UserName] = '" & strPublicActiveFullUserName & "', [ChangeDate] = '" & Now & "', " _
               & "[DependentCode] = 0, [InceptionDate] = '" & Format(Now, "dd-MMM-yyyy") & "', " _
               & "[FileNumber] = '" & txtFileNumber.Text & "', [Employer] = '" & txtEmployer.Text & "', " _
               & "[MedicalAid] = '" & lblMedAidCode.Text & "', [MedicalAidNumber] = '" & txtMedaidNumber.Text & "', " _
               & "[IdNumber] = '" & txtIdNumber.Text & "' WHERE [PatientId] = " & intSelectedPatient & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            'Update the kin details
            strSql = "UPDATE [OchmasKins] SET [KinName] = '" & txtKinNames.Text & "', " _
                & "[KinRelation] = '" & txtRelationship.Text & "', " _
                & "[KinAddress1] = '" & txtKinAddress1.Text & "', [KinAddress2] = '" & txtKinAddress2.Text & "', " _
                & "[KinAddress3] = '" & txtKinAddress3.Text & "', " _
                & "[KinAddress4] = '" & txtKinAddress4.Text & "', [Telephone] = '" & txtKinTelephone.Text & "', " _
                & "[Cellphone] = '" & txtKinMobile.Text & "', [Branch] = '" & strUserBranch & "', " _
                & "[UserName] = '" & strPublicActiveFullUserName & "', [ChangeDate] = '" & Now & "', " _
                & "[EmailAddress] = '" & txtKinEmailAddress.Text & "', [WhatsappNumber] = '" & txtKinWhatsapp.Text & "' " _
                & "WHERE [PatientId] = " & intSelectedPatient & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

        End If


        MessageBox.Show("Patient details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Patient Details Save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT * FROM OchmasPatients WHERE PatientId = " & intSelectedPatient & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()

            If Not IsDBNull(objReader("LastName").ToString) Then txtLastName.Text = objReader("LastName").ToString
            If Not IsDBNull(objReader("FirstName").ToString) Then txtFirstName.Text = objReader("FirstName").ToString
            If IsDate(objReader("BirthDate").ToString) Then dpDob.Value = CDate(objReader("BirthDate").ToString)
            If Not IsDBNull(objReader("Gender").ToString) Then cboGender.Text = objReader("Gender").ToString
            If Not IsDBNull(objReader("MaritalStatus").ToString) Then cboMaritalStatus.Text = objReader("MaritalStatus").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("FileNumber").ToString) Then txtFileNumber.Text = objReader("FileNumber").ToString
            If Not IsDBNull(objReader("Employer").ToString) Then txtEmployer.Text = objReader("Employer").ToString
            If Not IsDBNull(objReader("IdNumber").ToString) Then txtIdNumber.Text = objReader("IdNumber").ToString
            If Not IsDBNull(objReader("MedicalAid").ToString) Then lblMedAidCode.Text = objReader("MedicalAid").ToString
            'Get the medical aid scheme name and populate here
            cboMedicalAid.Text = MedicalAidName(lblMedAidCode.Text)

            If Not IsDBNull(objReader("MedicalAidNumber").ToString) Then txtMedaidNumber.Text = objReader("MedicalAidNumber").ToString

        End If
        objReader.Close()

        'Get the kin details
        strSql = "SELECT * FROM OchmasKins WHERE PatientId = " & intSelectedPatient & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("KinName").ToString) Then txtKinNames.Text = objReader("KinName").ToString
            If Not IsDBNull(objReader("KinRelation").ToString) Then txtRelationship.Text = objReader("KinRelation").ToString
            If Not IsDBNull(objReader("KinAddress1").ToString) Then txtKinAddress1.Text = objReader("KinAddress1").ToString
            If Not IsDBNull(objReader("KinAddress2").ToString) Then txtKinAddress2.Text = objReader("KinAddress2").ToString
            If Not IsDBNull(objReader("KinAddress3").ToString) Then txtKinAddress3.Text = objReader("KinAddress3").ToString
            If Not IsDBNull(objReader("KinAddress4").ToString) Then txtKinAddress4.Text = objReader("KinAddress4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtKinTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtKinMobile.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtKinEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("WhatsappNumber").ToString) Then txtKinWhatsapp.Text = objReader("WhatsappNumber").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Patient Details Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmPatientDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadMedicalAids()
        If boolEditStatus = True Then
            LoadData()
            LoadDependants()
            btnAdd.Enabled = True
            btnEdit.Enabled = True
            btnDelete.Enabled = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        boolPriorStatus = boolEditStatus
        boolEditStatus = False
        Dim frm As New frmDependents
        frm.ShowDialog()
        boolEditStatus = boolPriorStatus
        LoadDependants()
    End Sub

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

    Private Sub LoadMedicalAids()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Name +'|'+ RegistrationNumber AS " _
            & "[Details] FROM OchmasSystemMedicalAids ORDER BY Name", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrData As New ArrayList

        arrData.Add("--- NONE ---|")

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboMedicalAid.Width - 80

        'Add the items to the drop down box
        With cboMedicalAid
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

        cboMedicalAid.Items.Clear()
        
        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboMedicalAid
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
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Medical Aids Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboMedicalAid_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMedicalAid.SelectedIndexChanged
        lblMedAidCode.Text = Nothing
        lblMedAidCode.Text = cboMedicalAid.SelectedItem.Col2
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

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click

    End Sub
End Class
