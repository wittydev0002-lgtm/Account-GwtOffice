Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit

Public Class frmEmployeeDetails

    Dim strInitialDateValue As String = Nothing
    Dim strActivityStatus As String = Nothing
    Dim _originalSplitterDistance As Integer
    Dim strBirthDate As String = Nothing
    Dim strHireDate As String = Nothing
    Dim strDischargeDate As String = Nothing
    Dim strMedaidDate As String = Nothing
    Dim strPensionDate As String = Nothing

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dgvEarnings_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEarnings.CellEndEdit
        If IsNumeric(dgvEarnings.CurrentCell.Value) Then dgvEarnings.CurrentCell.Value = Format(CDbl(dgvEarnings.CurrentCell.Value.ToString), "##0.00")
    End Sub

    Private Sub dgvDeductions_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDeductions.CellEndEdit
        If IsNumeric(dgvDeductions.CurrentCell.Value) Then dgvDeductions.CurrentCell.Value = Format(CDbl(dgvDeductions.CurrentCell.Value.ToString), "##0.00")
    End Sub

    Private Sub dgvOther_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOther.CellEndEdit
        If IsNumeric(dgvOther.CurrentCell.Value) Then dgvOther.CurrentCell.Value = Format(CDbl(dgvOther.CurrentCell.Value.ToString), "##0.00")
    End Sub

    Private Sub dgvMaster_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMaster.CellEndEdit
        If IsNumeric(dgvMaster.CurrentCell.Value) Then dgvMaster.CurrentCell.Value = Format(CDbl(dgvMaster.CurrentCell.Value.ToString), "##0.00")
    End Sub

    Private Sub dgvEarnings_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvEarnings.EditingControlShowing
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

    Private Sub dgvDeductions_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvDeductions.EditingControlShowing
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

    Private Sub dgvOther_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvOther.EditingControlShowing
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

    Private Sub dgvMaster_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvMaster.EditingControlShowing
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

    Private Sub frmEmployeeDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'load the banks
        LoadEmployeeClasses()
        GetBankFileDetails()
        LoadWorkStructures()
        If boolEditStatus = True Then
            Me.TextExtra = UCase(Mid(strEmployeeLastName, 1, 1)) & LCase(Mid(strEmployeeLastName, 2, (strEmployeeLastName.Length - 1))) & " " _
                & UCase(Mid(strEmployeeFirstName, 1, 1)) & LCase(Mid(strEmployeeFirstName, 2, (strEmployeeFirstName.Length - 1))) & " " & _
                strPublicEmployeeId
            txtEmployeeNo.Enabled = False
            LoadSelectedEmployee()
        Else
            If boolAutoNextNumber = True Then
                boolAbort = False
                NextEmployeeNumber()
                If boolAbort = False Then
                    txtEmployeeNo.Text = strNextEmployeeNumber
                    txtEmployeeNo.Enabled = False
                End If
            Else
                txtEmployeeNo.Enabled = True
            End If
            Dim strSelect As String = "SELECT SystemCodes.CodeNo, SystemCodes.Description, EmployeeCodes.Amount, " _
            & "SystemCodes.CodeType FROM SystemCodes LEFT OUTER JOIN EmployeeCodes ON " _
            & "SystemCodes.CodeNo = EmployeeCodes.CodeNo WHERE SystemCodes.DisplayStatus = 'Y'"
            PopulateCodes(strSelect)
            Dim strSelectMasterFields As String = "SELECT SystemMasterFields.OrdinalNo, SystemMasterCodes.Description, EmployeeMasterFields.Amount " _
            & "FROM SystemMasterFields LEFT OUTER JOIN EmployeeMasterFields ON " _
            & "SystemMasterFields.CodeNo = EmployeeMasterFields.OrdinalNo WHERE EmployeeMasterFields.EmployeeNo = '" & strPublicEmployeeId & "'"
            PopulateMasterCodes(strSelectMasterFields)
            LoadFlags()
            LoadDates()
            LoadReferenceNumbers()
        End If
        'Get the values prior to any changes
        MasterDetailsPriorValues(txtEmployeeNo.Text, txtSurname.Text, txtFirstName.Text, _
            txtOtherNames.Text, txtIdNumber.Text, dpBirthDate.Text, txtAddress1.Text, _
            txtAddress2.Text, txtAddress3.Text, txtAddress4.Text, mtxtTelephone.Text, _
            mtxtCellphone.Text, txtEmailAddress.Text, txtContactPerson.Text, txtRelationship.Text, _
            txtConAddress1.Text, txtConAddress2.Text, txtAddress3.Text, txtConAddress4.Text, _
            txtContactTelephone.Text, txtContactCellphone.Text, "", _
            cboMaritalStatus.Text, "", cboGender.Text, cboEmploymentStatus.Text, _
            txtPosition.Text, txtDepartment.Text, txtCostCenter.Text, txtPaypoint.Text, _
            dpHireDate.Text, dpTermDate.Text, dpPensionDate.Text, dpMedaidDate.Text, _
            txtPensionNumber.Text, txtMedaidNumber.Text, cboBankCodes.Text, cboPaymentMethod.Text, _
            txtAccountNumber.Text, txtAccountOwner.Text, cboAccountType.Text)
        'Get the prior values for the codes
        Dim i As Integer = 0
        For i = 0 To dgvEarnings.Rows.Count - 1
            PriorCodeValues(CInt(dgvEarnings.Rows(i).Cells(0).Value.ToString), CDbl(dgvEarnings.Rows(i).Cells(2).Value.ToString))
        Next
        For i = 0 To dgvDeductions.Rows.Count - 1
            PriorCodeValues(CInt(dgvDeductions.Rows(i).Cells(0).Value.ToString), CDbl(dgvDeductions.Rows(i).Cells(2).Value.ToString))
        Next
        For i = 0 To dgvOther.Rows.Count - 1
            PriorCodeValues(CInt(dgvOther.Rows(i).Cells(0).Value.ToString), CDbl(dgvOther.Rows(i).Cells(2).Value.ToString))
        Next
        '824, 588
        Me.Width = 824 : Me.Height = 588
        AlternateColors(dGridFlags)
        AlternateColors(dGridDates)
        'AlternateColors(dgvDeductions)
        'AlternateColors(dgvEarnings)
        'AlternateColors(dgvMaster)
        'AlternateColors(dgvOther)
        AlternateColors(dGridSubjects)
        AlternateColors(dGridReferences)
    End Sub

    Private Sub LoadIR()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, IncidentDate, 105) AS [IncidentDate], " _
            & "CONVERT(NVARCHAR, HearingDate, 105) AS [HearingDate], ChargeDescription, Status, " _
            & "Verdict FROM EmployeeIR WHERE EmployeeNumber = '" & strPublicEmployeeId & "' ORDER BY IncidentDate DESC"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridIR.Rows.Clear()
        While objReader.Read
            dGridIR.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4))
        End While
        objReader.Close()

        'Load the grievance information
        strSql = "SELECT CONVERT(NVARCHAR, DateLodged, 105) AS [DateLodged], [Grievance],[Verdict],[Notes],[CaseNumber] FROM " _
            & "EmployeeIRGrievances WHERE EmployeeNumber = '" & strPublicEmployeeId & "' ORDER BY DateLodged DESC"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        dGridGrievances.Rows.Clear()
        While objReader.Read
            dGridGrievances.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4))
        End While
        objReader.Close()

        'Load the counselling information
        strSql = "SELECT CONVERT(NVARCHAR, CounsellingDate, 105) AS [CounsellingDate], [Reason],[Verdict],[Notes],[CaseNumber] FROM " _
            & "EmployeeIRCounselling WHERE EmployeeNumber = '" & strPublicEmployeeId & "' ORDER BY CounsellingDate DESC"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        dGridCounselling.Rows.Clear()
        While objReader.Read
            dGridCounselling.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4))
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee industrial relation information load failure"
        ShowErrorMessage()
    End Sub

    Private Sub cboBankCodes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBankCodes.SelectedIndexChanged
        If cboBankCodes.Focused = False Then Exit Sub
        If Not cboBankCodes.SelectedItem Is Nothing Then
            lblBankCode.Text = cboBankCodes.SelectedItem.Col2
        Else
            lblBankCode.Text = ""
        End If
    End Sub

    Private Sub InsertMasterRecord()
        On Error GoTo RaiseErr
        'Get the initials from the given names and other names
        Dim strInits As String = Nothing
        If Not String.IsNullOrEmpty(txtFirstName.Text) Then
            strInits = UCase(Mid(txtFirstName.Text, 1, 1))
        End If
        If Not String.IsNullOrEmpty(txtOtherNames.Text) Then
            Dim strSplit() As String = Split(txtOtherNames.Text, " ")
            Dim i As Integer = 0
            For i = 0 To strSplit.Length - 1
                If Not String.IsNullOrEmpty(strSplit(i)) Then
                    strInits = strInits & " " & UCase(Mid(strSplit(i), 1, 1))
                End If
            Next
        End If
        If Not IsNumeric(txtClockNo.Text) Then txtClockNo.Text = "0"
        Dim strSql As String = "INSERT INTO EmployeeMaster (EmployeeNo, LastName, " _
            & "FirstName, OtherNames, IdNumber, Gender, BirthDate, MaritalStatus, " _
            & "Address1, Address2, Address3, Address4,Telephone,Cellphone,EmailAddress, " _
            & "ClockNo, DirAmt, DirPercent, StopFrom, StopTo, TaxCode, TaxDependents, TaxRef, Title, Inits, Status, EmployeeClass) " _
            & "VALUES ('" & txtEmployeeNo.Text & "', '" & txtSurname.Text & "', " _
            & "'" & txtFirstName.Text & "','" & txtOtherNames.Text & "', " _
            & "'" & txtIdNumber.Text & "','" & cboGender.Text & "', " _
            & "'" & strBirthDate & "','" & cboMaritalStatus.Text & "', " _
            & "'" & txtAddress1.Text & "','" & txtAddress2.Text & "', " _
            & "'" & txtAddress3.Text & "','" & txtAddress4.Text & "', " _
            & "'" & mtxtTelephone.Text & "','" & mtxtCellphone.Text & "', " _
            & "'" & txtEmailAddress.Text & "', " & txtClockNo.Text & ", " _
            & "'" & txtTaxDiirectiveAmt.Text & "', '" & txtTaxDirectivePercent.Text & "', " _
            & "" & txtStopFrom.Text & ", " & txtStopTo.Text & ", " _
            & "'" & txtTaxCode.Text & "', " & txtTaxDependents.Text & ", " _
            & "'" & txtTaxReference.Text & "', '" & cboTitle.Text & "', '" & strInits & "', '" & strActivityStatus & "', '" & cboEmployeeClasses.Text & "')"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Details Maintenance Error"
        ShowErrorMessage()
    End Sub

    Private Sub InsertContactsRecord()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "INSERT INTO EmployeeContacts (EmployeeNo, ContactPerson, " _
            & "Relationship, Address1, Address2, Address3, Address4, " _
            & "Telephone, Cellphone, EmailAddress) VALUES ('" & txtEmployeeNo.Text & "', " _
            & "'" & txtContactPerson.Text & "', '" & txtRelationship.Text & "', " _
            & "'" & txtConAddress1.Text & "','" & txtConAddress2.Text & "', " _
            & "'" & txtConAddress3.Text & "','" & txtConAddress4.Text & "', " _
            & "'" & txtContactTelephone.Text & "','" & txtContactCellphone.Text & "', " _
            & "'" & txtContactEmailAddress.Text & "')"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Contacts Insert"
        ShowErrorMessage()
    End Sub

    Private Sub InsertBankingRecord()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "INSERT INTO EmployeeBanks (EmployeeNo, BankCode, AccountType, " _
            & "AccountHolder, AccountNumber) VALUES ('" & txtEmployeeNo.Text & "', " _
            & "'" & lblBankCode.Text & "', '" & cboAccountType.Text & "', " _
            & "'" & txtAccountOwner.Text & "', '" & txtAccountNumber.Text & "')"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Banking Details Insert"
        ShowErrorMessage()
    End Sub

    Private Sub InsertEmploymentRecord()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "INSERT INTO Employment (EmployeeNo, HireDate, JobTitle, " _
            & "EmploymentStatus, Department, CostCenter, PayPoint, PensionDate, MedaidDate, PensionNo, MedaidNo) " _
            & "VALUES ('" & txtEmployeeNo.Text & "', '" & strHireDate & "', " _
            & "'" & txtPosition.Text & "', '" & cboEmploymentStatus.Text & "', " _
            & "'" & txtDepartment.Text & "', '" & txtCostCenter.Text & "', " _
            & "'" & txtPaypoint.Text & "', '" & strPensionDate & "', " _
            & "'" & strMedaidDate & "', '" & txtPensionNumber.Text & "', '" & txtMedaidNumber.Text & "')"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Employment Details Insert"
        ShowErrorMessage()
    End Sub

    Private Sub InsertDates()
        On Error GoTo RaiseErr
        'First delete everything that relates to the current employee
        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeDates WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim i As Integer = 0
        For i = 0 To dGridDates.Rows.Count - 1
            Dim strDateValue As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGridDates.Rows(i).Cells(2).Value), "")) Then
                strDateValue = Convert.ToString(dGridDates.Rows(i).Cells(2).Value)
                If IsDate(strDateValue) Then
                    If strSystemDateFormat = "English" Then strDateValue = CStr(Format(CDate(strDateValue), "dd-MMM-yyyy"))
                    sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeDates " _
                        & "(EmployeeNo, OrdinalNo, DateValue) VALUES ('" & txtEmployeeNo.Text & "', " _
                        & "" & CInt(dGridDates.Rows(i).Cells(0).Value.ToString) & ", " _
                        & "'" & CDate(strDateValue) & "')", cnn)
                    sqlCommand.ExecuteNonQuery()
                End If
            End If
        Next
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Date Details Insert"
        ShowErrorMessage()
    End Sub

    Private Sub InsertReferences()
        On Error GoTo RaiseErr
        'First delete everything that relates to the current employee
        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeReferences WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim i As Integer = 0
        For i = 0 To dGridReferences.Rows.Count - 1
            Dim strReference As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGridReferences.Rows(i).Cells(2).Value), "")) Then
                strReference = Convert.ToString(dGridReferences.Rows(i).Cells(2).Value)
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeReferences " _
                    & "(EmployeeNo, OrdinalNo, Reference) VALUES ('" & txtEmployeeNo.Text & "', " _
                    & "" & CInt(dGridReferences.Rows(i).Cells(0).Value.ToString) & ", " _
                    & "'" & strReference & "')", cnn)
                sqlCommand.ExecuteNonQuery()
            End If
        Next
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Reference Details Insert"
        ShowErrorMessage()
    End Sub

    Private Sub InsertFlags()
        On Error GoTo RaiseErr
        'First delete everything that relates to the current employee
        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeFlags WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim i As Integer = 0
        For i = 0 To dGridFlags.Rows.Count - 1
            Dim strFlag As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGridFlags.Rows(i).Cells(2).Value), "")) Then
                strFlag = Convert.ToString(dGridFlags.Rows(i).Cells(2).Value)
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeFlags " _
                    & "(EmployeeNo, OrdinalNo, Flag) VALUES ('" & txtEmployeeNo.Text & "', " _
                    & "" & CInt(dGridFlags.Rows(i).Cells(0).Value.ToString) & ", " _
                    & "'" & strFlag & "')", cnn)
                sqlCommand.ExecuteNonQuery()
            End If
        Next
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Flags Details Insert"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSelectedEmployee()
        On Error GoTo RaiseErr
        If boolEditStatus = False Then txtEmployeeNo.Enabled = True Else txtEmployeeNo.Enabled = False
        If boolDisallowSave = True Then btnOk.Enabled = False
        'Load the bank codes
        'GetBankFileDetails()

        'If the form load status is edit then open populate the employee codes and other values
        If boolEditStatus = True Then
            Dim strSelect As String = "SELECT SystemCodes.CodeNo, SystemCodes.Description, EmployeeCodes.Amount, " _
            & "SystemCodes.CodeType FROM SystemCodes LEFT OUTER JOIN EmployeeCodes ON " _
            & "SystemCodes.CodeNo = EmployeeCodes.CodeNo WHERE SystemCodes.DisplayStatus = 'Y' " _
            & "AND EmployeeCodes.EmployeeNo = '" & strPublicEmployeeId & "'"
            Dim strSelectMasterFields As String = "SELECT SystemMasterFields.OrdinalNo, SystemMasterFields.Description, EmployeeMasterFields.Amount " _
            & "FROM SystemMasterFields LEFT OUTER JOIN EmployeeMasterFields ON " _
            & "SystemMasterFields.OrdinalNo = EmployeeMasterFields.OrdinalNo WHERE EmployeeMasterFields.EmployeeNo = '" & strPublicEmployeeId & "'"
            PopulateCodes(strSelect)
            PopulateMasterCodes(strSelectMasterFields)
            PopulateMaster()
            PopulateContacts()
            PopulateEmployment()
            PopulateEmployeeBankDetails()
            LoadFlags()
            LoadDates()
            LoadReferenceNumbers()
            LoadQualifications()
            LoadLeaveData()
            LoadDependents()
            LoadIR()
            LoadEmploymentData()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Employee Master Details Load Failure"
        ShowErrorMessage()
    End Sub

    Private Sub GetBankFileDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT BankName +';'+BankCode AS [Banking] FROM SystemBanks ORDER BY BankName"
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
            .ColumnWidth = "250;60"
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

    Private Sub PopulateMaster()
        On Error GoTo RaiseErr
        'open the masterfile and assign values relating to the selected employee
        Dim strSql As String = "SELECT EmployeeNo, LastName, FirstName, IdNumber, OtherNames, CONVERT(NVARCHAR, BirthDate, 105) AS [BirthDate], " _
            & "Gender, MaritalStatus, Address1, Address2, Address3, Address4, Telephone, Cellphone, EmailAddress, Status, " _
            & "ClockNo, DirAmt, DirPercent, CONVERT(NVARCHAR, DischDate, 105) AS [DischDate], DischRsn, StopFrom, StopTo, TaxCode, TaxDependents, " _
            & "TaxRef, Title, MaidenName, EmployeeNotes, PicturePath, FingerPrintPath, EmployeeClass FROM EmployeeMaster " _
            & "WHERE EmployeeNo = '" & strPublicEmployeeId & "'"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim strBuffer() As String

        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("EmployeeNo").ToString) Then txtEmployeeNo.Text = objReader("EmployeeNo").ToString
            If Not IsDBNull(objReader("LastName").ToString) Then txtSurname.Text = objReader("LastName").ToString
            If Not IsDBNull(objReader("FirstName").ToString) Then txtFirstName.Text = objReader("FirstName").ToString
            If Not IsDBNull(objReader("IdNumber").ToString) Then txtIdNumber.Text = objReader("IdNumber").ToString
            If Not IsDBNull(objReader("OtherNames").ToString) Then txtOtherNames.Text = objReader("OtherNames").ToString
            If Not IsDBNull(objReader("BirthDate").ToString) Then
                If objReader("BirthDate").ToString.Length > 0 Then
                    strBuffer = Split(objReader("BirthDate").ToString, "-")
                    dpBirthDate.Value = CDate(Format(CInt(strBuffer(0)), "00") & "-" & getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
                End If
            End If
            If Not IsDBNull(objReader("EmployeeClass").ToString) Then cboEmployeeClasses.Text = objReader("EmployeeClass").ToString
            If Not IsDBNull(objReader("Gender").ToString) Then cboGender.Text = objReader("Gender").ToString
            If Not IsDBNull(objReader("MaritalStatus").ToString) Then cboMaritalStatus.Text = objReader("MaritalStatus").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then mtxtTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then mtxtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("ClockNo").ToString) Then txtClockNo.Text = objReader("ClockNo").ToString
            If Not IsDBNull(objReader("DirAmt").ToString) Then txtTaxDiirectiveAmt.Text = objReader("DirAmt").ToString
            If Not IsDBNull(objReader("DirPercent").ToString) Then txtTaxDirectivePercent.Text = objReader("DirPercent").ToString
            If Not IsDBNull(objReader("DischDate").ToString) Then
                If objReader("DischDate").ToString.Length > 0 Then
                    strBuffer = Split(objReader("DischDate").ToString, "-")
                    dpTermDate.Value = CDate(Format(CInt(strBuffer(0)), "00") & "-" & getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
                End If
            End If

            If Not IsDBNull(objReader("DischRsn").ToString) Then lblDischReason.Text = objReader("DischRsn").ToString
            If Not IsDBNull(objReader("StopFrom").ToString) Then txtStopFrom.Text = objReader("StopFrom").ToString
            If Not IsDBNull(objReader("StopTo").ToString) Then txtStopTo.Text = objReader("StopTo").ToString
            If Not IsDBNull(objReader("TaxCode").ToString) Then txtTaxCode.Text = objReader("TaxCode").ToString
            If Not IsDBNull(objReader("TaxDependents").ToString) Then txtTaxDependents.Text = objReader("TaxDependents").ToString
            If Not IsDBNull(objReader("TaxRef").ToString) Then txtTaxReference.Text = objReader("TaxRef").ToString
            If Not IsDBNull(objReader("Title").ToString) Then cboTitle.Text = objReader("Title").ToString
            If Not IsDBNull(objReader("Status").ToString) Then cboStatus.Text = objReader("Status").ToString
            If Not IsDBNull(objReader("MaidenName").ToString) Then txtMaidenName.Text = objReader("MaidenName").ToString
            If Not IsDBNull(objReader("EmployeeNotes").ToString) Then txtNotes.Text = objReader("EmployeeNotes").ToString
            If Not IsDBNull(objReader("PicturePath").ToString) Then lblFacePicPath.Text = objReader("PicturePath").ToString
            If Not IsDBNull(objReader("FingerPrintPath").ToString) Then lblFinPicPath.Text = objReader("FingerPrintPath").ToString
        End If
        objReader.Close()
        'Load the images
        If Not String.IsNullOrEmpty(lblFacePicPath.Text) Then
            If System.IO.File.Exists(lblFacePicPath.Text) Then
                picFace.Load(lblFacePicPath.Text)
            End If
        End If
        If Not String.IsNullOrEmpty(lblFinPicPath.Text) Then
            If System.IO.File.Exists(lblFinPicPath.Text) Then
                picFinger.Load(lblFinPicPath.Text)
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Master Data Load Error"
        ShowErrorMessage()
    End Sub

    Private Sub LoadEmployeeClasses()
        'SystemEmployeeClasses
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT Description FROM " _
            & "SystemEmployeeClasses ORDER BY Description", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboEmployeeClasses.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboEmployeeClasses.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Master Data Load Error"
        ShowErrorMessage()
    End Sub

    Private Sub PopulateContacts()
        'open the contacts file and assign values relating to the selected employee
        On Error GoTo RaiseErr
        'open the masterfile and assign values relating to the selected employee
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeContacts " _
            & "WHERE EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Continue to read until you reach the end of the file.
        While objReader.Read
            If Not IsDBNull(objReader("ContactPerson").ToString) Then txtContactPerson.Text = objReader("ContactPerson").ToString
            If Not IsDBNull(objReader("RelationShip").ToString) Then txtRelationship.Text = objReader("RelationShip").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtConAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtConAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtConAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtConAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtContactTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtContactCellphone.Text = objReader("Cellphone").ToString
        End While
        'Close the file.
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Contact Data Load Error"
        ShowErrorMessage()
    End Sub

    Private Sub PopulateEmployment()
        'open the employment record and assign values relating the selected employee
        On Error GoTo RaiseErr
        'open the masterfile and assign values relating to the selected employee
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, HireDate, 105) AS [HireDate], " _
            & "EmploymentStatus, JobTitle, Department, PayPoint, CostCenter, CONVERT(NVARCHAR, PensionDate, 105) " _
            & "AS [PensionDate], CONVERT(NVARCHAR, MedaidDate, 105) AS [MedaidDate], PensionNo, MedaidNo FROM " _
            & "Employment WHERE EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        Dim strBuffer() As String
        'Continue to read until you reach the end of the file.
        While objReader.Read
            If Not IsDBNull(objReader("HireDate").ToString) Then
                If objReader("HireDate").ToString.Length > 0 Then
                    strBuffer = Split(objReader("HireDate").ToString, "-")
                    dpHireDate.Value = CDate(strBuffer(0) & "-" & getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
                End If
            End If

            If Not IsDBNull(objReader("EmploymentStatus").ToString) Then cboEmploymentStatus.SelectedItem = objReader("EmploymentStatus").ToString
            If Not IsDBNull(objReader("JobTitle").ToString) Then txtPosition.SelectedItem = objReader("JobTitle").ToString
            If Not IsDBNull(objReader("Department").ToString) Then txtDepartment.SelectedItem = objReader("Department").ToString
            If Not IsDBNull(objReader("PayPoint").ToString) Then txtPaypoint.SelectedItem = objReader("PayPoint").ToString
            If Not IsDBNull(objReader("CostCenter").ToString) Then txtCostCenter.SelectedItem = objReader("CostCenter").ToString
            'PensionDate, MedaidDate, PensionNo, MedaidNo
            If Not IsDBNull(objReader("PensionDate").ToString) Then
                If objReader("PensionDate").ToString.Length > 0 Then
                    strBuffer = Split(objReader("PensionDate").ToString, "-")
                    dpPensionDate.Value = CDate(strBuffer(0) & "-" & getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
                End If
            End If
            If Not IsDBNull(objReader("MedaidDate").ToString) Then
                If objReader("MedaidDate").ToString.Length > 0 Then
                    strBuffer = Split(objReader("MedaidDate").ToString, "-")
                    dpMedaidDate.Value = CDate(strBuffer(0) & "-" & getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
                End If
            End If

            If Not IsDBNull(objReader("PensionNo").ToString) Then txtPensionNumber.Text = objReader("PensionNo").ToString
            If Not IsDBNull(objReader("MedaidNo").ToString) Then txtMedaidNumber.Text = objReader("MedaidNo").ToString
        End While
        'Close the file.
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Contact Data Load Error"
        ShowErrorMessage()
    End Sub

    Private Sub PopulateEmployeeBankDetails()
        'open the employee bank details and assign the selected employee records
        On Error GoTo RaiseErr
        'open the masterfile and assign values relating to the selected employee
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT *, SystemBanks.BankName FROM " _
            & "EmployeeBanks LEFT OUTER JOIN SystemBanks ON EmployeeBanks.BankCode = SystemBanks.BankCode " _
            & "WHERE EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Continue to read until you reach the end of the file.
        While objReader.Read
            cboPaymentMethod.Text = objReader("PayMethod").ToString
            lblBankCode.Text = objReader("BankName").ToString
            txtAccountNumber.Text = objReader("AccountNumber").ToString
            cboAccountType.Text = objReader("AccountType").ToString
            txtAccountOwner.Text = objReader("AccountHolder").ToString
            cboBankCodes.Text = objReader("BankCode").ToString
            lblBankCode.Text = objReader("BankCode").ToString
        End While
        'Close the file.
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Contact Data Load Error"
        ShowErrorMessage()
    End Sub

    Private Sub PopulateMasterCodes(ByVal strSql As String)
        'Set the default row number for earnings, deductions and other codes grids
        dgvMaster.Rows.Clear()
        'open the codes file and read the code number and the description
        'open the codes file and load the payroll codes
        'On initial installation the codes file contain only code numbers

        On Error GoTo RaiseErr
        Dim sqlCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        'First populate the blank codes from the system codes
        Dim strCodes As String = "SELECT SystemMasterFields.OrdinalNo, SystemMasterFields.Description " _
            & "FROM SystemMasterFields ORDER BY OrdinalNo"
        sqlCommand = New Data.OleDb.OleDbCommand(strCodes, cnn)
        objReader = sqlCommand.ExecuteReader
        'Continue to read until you reach the end of the file.
        While objReader.Read
            If Not IsDBNull(objReader("Description").ToString) Then
                If Not String.IsNullOrEmpty(objReader("Description").ToString) Then
                    dgvMaster.Rows.Add(1)
                    dgvMaster.Rows(dgvMaster.Rows.Count - 1).Cells(0).Value = Format(CInt(objReader("OrdinalNo").ToString), "000")
                    dgvMaster.Rows(dgvMaster.Rows.Count - 1).Cells(1).Value = objReader("Description").ToString
                    dgvMaster.Rows(dgvMaster.Rows.Count - 1).Cells(2).Value = "0.00"
                End If
            End If
        End While
        objReader.Close()
        'Now get the actual records and fill the actual values
        If boolEditStatus = False Then Exit Sub
        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader("Description").ToString) Then
                For i As Integer = 0 To dgvMaster.Rows.Count - 1
                    If CInt(dgvMaster.Rows(i).Cells(0).Value.ToString) = CInt(objReader("OrdinalNo").ToString) Then
                        If IsNumeric(objReader("Amount").ToString) Then dgvMaster.Rows(i).Cells(2).Value = Format(CDbl(objReader("Amount").ToString), "##0.00")
                        Exit For
                    End If
                Next
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Employee Master Fields Load"
        ShowErrorMessage()
    End Sub

    Private Sub PopulateCodes(ByVal strSql As String)
        'Set the default row number for earnings, deductions and other codes grids
        dgvEarnings.Rows.Clear()
        dgvDeductions.Rows.Clear()
        dgvOther.Rows.Clear()
        'open the codes file and read the code number and the description
        'open the codes file and load the payroll codes
        'On initial installation the codes file contain only code numbers
        On Error GoTo RaiseErr
        Dim sqlCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim objStreamReaderEmployeeValues As StreamReader
        Dim strLine As String
        Dim strEmployeeId As String
        Dim strLineEmployeeCodes As String
        Dim dblValue As Double 'Holds the value of the employee code
        Dim strRecordText() As String 'creates the record fields array
        Dim strCodeText() As String
        Dim ie As Integer 'datagrid row identifier for earnings
        Dim id As Integer 'datagrid row identifier for deductions
        Dim io As Integer 'datagrid row identifier for other

        Dim CurrentCell As DataGridViewCell
        ie = 0 : id = 0 : io = 0
        'First populate the blank codes from the system codes
        Dim strCodes As String = "SELECT SystemCodes.CodeNo, SystemCodes.Description, " _
            & "SystemCodes.CodeType FROM SystemCodes WHERE SystemCodes.DisplayStatus = 'Y' ORDER BY CodeNo"
        sqlCommand = New Data.OleDb.OleDbCommand(strCodes, cnn)
        objReader = sqlCommand.ExecuteReader
        'Continue to read until you reach the end of the file.
        While objReader.Read
            If Not IsDBNull(objReader("Description").ToString) Then
                If Not IsDBNull(objReader("CodeType").ToString) Then
                    Select Case UCase(objReader("CodeType").ToString)
                        Case Is = "E"
                            dgvEarnings.Rows.Add(1)
                            CurrentCell = dgvEarnings.Rows(ie).Cells(0)
                            CurrentCell.Value = Format(CInt(objReader("CodeNo").ToString), "0000")
                            CurrentCell = dgvEarnings.Rows(ie).Cells(1)
                            CurrentCell.Value = objReader("Description").ToString
                            CurrentCell = dgvEarnings.Rows(ie).Cells(2)
                            CurrentCell.Value = "0.00"
                            ie = ie + 1
                        Case Is = "D"
                            dgvDeductions.Rows.Add(1)
                            CurrentCell = dgvDeductions.Rows(id).Cells(0)
                            CurrentCell.Value = Format(CInt(objReader("CodeNo").ToString), "0000")
                            CurrentCell = dgvDeductions.Rows(id).Cells(1)
                            CurrentCell.Value = objReader("Description").ToString
                            CurrentCell = dgvDeductions.Rows(id).Cells(2)
                            CurrentCell.Value = "0.00"
                            id = id + 1
                        Case Else
                            dgvOther.Rows.Add(1)
                            CurrentCell = dgvOther.Rows(io).Cells(0)
                            CurrentCell.Value = Format(CInt(objReader("CodeNo").ToString), "0000")
                            CurrentCell = dgvOther.Rows(io).Cells(1)
                            CurrentCell.Value = objReader("Description").ToString
                            CurrentCell = dgvOther.Rows(io).Cells(2)
                            CurrentCell.Value = "0.00"
                            io = io + 1
                    End Select
                End If
            End If
        End While
        objReader.Close()
        'Now get the actual records and fill the actual values
        If boolEditStatus = False Then Exit Sub
        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = sqlCommand.ExecuteReader
        Dim i As Integer = 0
        While objReader.Read
            If Not IsDBNull(objReader("Description").ToString) Then
                If Not IsDBNull(objReader("CodeType").ToString) Then
                    Select Case UCase(objReader("CodeType").ToString)
                        Case Is = "E"
                            For i = 0 To dgvEarnings.Rows.Count - 1
                                If CInt(dgvEarnings.Rows(i).Cells(0).Value.ToString) = CInt(objReader("CodeNo").ToString) Then
                                    If IsNumeric(objReader("Amount").ToString) Then dgvEarnings.Rows(i).Cells(2).Value = Format(CDbl(objReader("Amount").ToString), "##0.00")
                                    Exit For
                                End If
                            Next
                        Case Is = "D"
                            For i = 0 To dgvDeductions.Rows.Count - 1
                                If CInt(dgvDeductions.Rows(i).Cells(0).Value.ToString) = CInt(objReader("CodeNo").ToString) Then
                                    If IsNumeric(objReader("Amount").ToString) Then dgvDeductions.Rows(i).Cells(2).Value = Format(CDbl(objReader("Amount").ToString), "##0.00")
                                    Exit For
                                End If
                            Next
                        Case Else
                            For i = 0 To dgvOther.Rows.Count - 1
                                If CInt(dgvOther.Rows(i).Cells(0).Value.ToString) = CInt(objReader("CodeNo").ToString) Then
                                    If IsNumeric(objReader("Amount").ToString) Then dgvOther.Rows(i).Cells(2).Value = Format(CDbl(objReader("Amount").ToString), "##0.00")
                                    Exit For
                                End If
                            Next
                    End Select
                End If
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
    End Sub

    Private Sub CreateNewEmployeeCodes()
        'First add the default code values
        On Error GoTo RaiseErr
        'Write a line of text.
        For i = 1 To 1000
            Dim sqlCommand As New Data.OleDb.OleDbCommand("INSERT INTO EmployeeCodes " _
                & "(EmployeeNo, CodeNo, Amount) VALUES ('" & txtEmployeeNo.Text & "', " _
                & "'" & CStr(Format(i, "0000")) & "', 0.00)", cnn)
            sqlCommand.ExecuteNonQuery()
        Next i
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Codes Initialisation Error"
        ShowErrorMessage()
    End Sub

    Private Sub UpdateEmployeeMasterFields()
        On Error GoTo RaiseErr
        Dim strCodeText() As String
        Dim dblNewValue As Double
        Dim i As Integer
        Dim CurrentCell As DataGridViewCell
        Dim currentCode As Integer
        Dim currentCodeValue As Double
        Dim boolPassed As Boolean = False
        Dim sqlCommand As Data.OleDb.OleDbCommand
        'If the record is new, create the codes record for that particular employee first
        If boolEditStatus = False Then
            sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeMasterFields " _
                & "WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
            sqlCommand.ExecuteNonQuery()
            For i = 0 To dgvMaster.Rows.Count - 1
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO " _
                    & "EmployeeMasterFields (EmployeeNo, OrdinalNo, Amount) VALUES " _
                    & "('" & txtEmployeeNo.Text & "', " & CInt(dgvMaster.Rows(i).Cells(0).Value.ToString) & ", 0)", cnn)
                sqlCommand.ExecuteNonQuery()
            Next
        End If

        boolPassed = False
        With dgvMaster
            For i = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(dgvMaster.Rows(i).Cells(0).Value), "")) Then
                    If IsNumeric(dgvMaster.Rows(i).Cells(0).Value.ToString) Then
                        currentCode = Convert.ToString(dgvMaster.Rows(i).Cells(0).Value)
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(dgvMaster.Rows(i).Cells(2).Value), "")) Then
                    If IsNumeric(dgvMaster.Rows(i).Cells(2).Value.ToString) Then
                        currentCodeValue = Convert.ToString(dgvMaster.Rows(i).Cells(2).Value)
                    End If
                End If

                'Check that the code exists in anywhere
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeMasterFields " _
                    & "WHERE OrdinalNo = " & currentCode & " AND EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
                Dim objCheck As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
                If objCheck.HasRows Then
                    dblNewValue = currentCodeValue
                    sqlCommand = New Data.OleDb.OleDbCommand("UPDATE EmployeeMasterFields SET " _
                        & "Amount = " & dblNewValue & " WHERE EmployeeNo " _
                        & "= '" & txtEmployeeNo.Text & "' AND OrdinalNo = " & currentCode & "", cnn)
                    sqlCommand.ExecuteNonQuery()
                Else
                    If CDbl(currentCodeValue) > 0 Then
                        sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeMasterFields (EmployeeNo, " _
                                    & "OrdinalNo, Amount) VALUES ('" & txtEmployeeNo.Text & "', " & currentCode & ", " _
                                    & "" & currentCodeValue & ")", cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If
                objCheck.Close()
            Next i
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Employee Master Fields Update"
        ShowErrorMessage()
    End Sub

    Private Sub UpdateEmployeeCodes()
        On Error GoTo RaiseErr
        Dim objStreamWriter As StreamWriter
        Dim strLine As String
        Dim strCodeText() As String
        Dim dblNewValue As Double
        Dim i As Integer
        Dim CurrentCell As DataGridViewCell
        Dim currentCode As Integer
        Dim currentCodeValue As Double
        Dim boolPassed As Boolean = False
        Dim sqlCommand As Data.OleDb.OleDbCommand
        'If the record is new, create the codes record for that particular employee first
        If boolEditStatus = False Then
            sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeCodes " _
                & "WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
            sqlCommand.ExecuteNonQuery()
            For i = 0 To dgvEarnings.Rows.Count - 1
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO " _
                    & "EmployeeCodes (EmployeeNo, CodeNo, Amount) VALUES " _
                    & "('" & txtEmployeeNo.Text & "', " & CInt(dgvEarnings.Rows(i).Cells(0).Value.ToString) & ", 0)", cnn)
                sqlCommand.ExecuteNonQuery()
            Next
            For i = 0 To dgvDeductions.Rows.Count - 1
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO " _
                    & "EmployeeCodes (EmployeeNo, CodeNo, Amount) VALUES " _
                    & "('" & txtEmployeeNo.Text & "', " & CInt(dgvDeductions.Rows(i).Cells(0).Value.ToString) & ", 0)", cnn)
                sqlCommand.ExecuteNonQuery()
            Next
            For i = 0 To dgvOther.Rows.Count - 1
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO " _
                    & "EmployeeCodes (EmployeeNo, CodeNo, Amount) VALUES " _
                    & "('" & txtEmployeeNo.Text & "', " & CInt(dgvOther.Rows(i).Cells(0).Value.ToString) & ", 0)", cnn)
                sqlCommand.ExecuteNonQuery()
            Next
        End If

        boolPassed = False
        With dgvEarnings
            For i = 0 To .Rows.Count - 1
                CurrentCell = .Rows(i).Cells(0)
                currentCode = CInt(CurrentCell.Value)
                CurrentCell = .Rows(i).Cells(2)
                currentCodeValue = CDbl(CurrentCell.Value)
                'Check that the code exists in anywhere
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeCodes " _
                    & "WHERE CodeNo = " & currentCode & " AND EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
                Dim objCheck As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
                If objCheck.HasRows Then
                    dblNewValue = currentCodeValue
                    sqlCommand = New Data.OleDb.OleDbCommand("UPDATE EmployeeCodes SET " _
                        & "Amount = " & dblNewValue & " WHERE EmployeeNo " _
                        & "= '" & txtEmployeeNo.Text & "' AND CodeNo = " & currentCode & "", cnn)
                    sqlCommand.ExecuteNonQuery()
                Else
                    If CDbl(currentCodeValue) > 0 Then
                        sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeCodes (EmployeeNo, " _
                                    & "CodeNo, Amount) VALUES ('" & txtEmployeeNo.Text & "', " & currentCode & ", " _
                                    & "" & currentCodeValue & ")", cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If
                objCheck.Close()
            Next i
        End With
        'If boolPassed = False Then
        With dgvDeductions
            For i = 0 To .Rows.Count - 1
                CurrentCell = .Rows(i).Cells(0)
                currentCode = CInt(CurrentCell.Value)
                CurrentCell = .Rows(i).Cells(2)
                currentCodeValue = CDbl(CurrentCell.Value)
                'Check that the code exists in anywhere
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeCodes " _
                    & "WHERE CodeNo = " & currentCode & " AND EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
                Dim objCheck As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
                If objCheck.HasRows Then
                    dblNewValue = currentCodeValue
                    sqlCommand = New Data.OleDb.OleDbCommand("UPDATE EmployeeCodes SET " _
                        & "Amount = " & dblNewValue & " WHERE EmployeeNo " _
                        & "= '" & txtEmployeeNo.Text & "' AND CodeNo = " & currentCode & "", cnn)
                    sqlCommand.ExecuteNonQuery()
                Else
                    If CDbl(currentCodeValue) > 0 Then
                        sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeCodes (EmployeeNo, " _
                                    & "CodeNo, Amount) VALUES ('" & txtEmployeeNo.Text & "', " & currentCode & ", " _
                                    & "" & currentCodeValue & ")", cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If
                objCheck.Close()
            Next i
        End With
        'End If
        'If boolPassed = False Then
        With dgvOther
            For i = 0 To .Rows.Count - 1
                CurrentCell = .Rows(i).Cells(0)
                currentCode = CInt(CurrentCell.Value)
                CurrentCell = .Rows(i).Cells(2)
                currentCodeValue = CDbl(CurrentCell.Value)
                'Check that the code exists in anywhere
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeCodes " _
                    & "WHERE CodeNo = " & currentCode & " AND EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
                Dim objCheck As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
                If objCheck.HasRows Then
                    dblNewValue = currentCodeValue
                    sqlCommand = New Data.OleDb.OleDbCommand("UPDATE EmployeeCodes SET " _
                        & "Amount = " & dblNewValue & " WHERE EmployeeNo " _
                        & "= '" & txtEmployeeNo.Text & "' AND CodeNo = " & currentCode & "", cnn)
                    sqlCommand.ExecuteNonQuery()
                Else
                    If CDbl(currentCodeValue) > 0 Then
                        sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeCodes (EmployeeNo, " _
                                    & "CodeNo, Amount) VALUES ('" & txtEmployeeNo.Text & "', " & currentCode & ", " _
                                    & "" & currentCodeValue & ")", cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If
                objCheck.Close()
            Next i
        End With
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeCodes WHERE " _
            & "Amount = 0 AND EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Employee Codes Update Error"
        ShowErrorMessage()
    End Sub

    Private Sub cboPaymentMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentMethod.SelectedIndexChanged
        If cboPaymentMethod.Text = "Cash" Or cboPaymentMethod.Text = "Cheque" Then
            cboBankCodes.Enabled = False
            txtAccountNumber.Enabled = False
            cboAccountType.Enabled = False
            txtAccountOwner.Enabled = False
        Else
            cboBankCodes.Enabled = True
            txtAccountNumber.Enabled = True
            cboAccountType.Enabled = True
            txtAccountOwner.Enabled = True
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Not IsNumeric(txtClockNo.Text) Then txtClockNo.Text = "0"
        boolAbort = False
        SaveEmployeeData()
    End Sub

    Private Sub SaveEmployeeData()
        Dim strDetails As String
        Dim strContacts As String
        Dim strBankDetails As String
        Dim strEmployment As String

        If UCase(cboStatus.Text) = "INACTIVE" Then
            strActivityStatus = "INACTIVE"
        Else
            strActivityStatus = "ACTIVE"
        End If
        On Error GoTo RaiseErr
        'Make sure that all the mandatory details have been entered
        If txtEmployeeNo.Text = "" Or String.IsNullOrEmpty(txtEmployeeNo.Text) Then
            MessageBox.Show("Please Enter a Valid Value for the Employee Number", "Invalid Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEmployeeNo.Focus()
            Exit Sub
        End If

        'Verify if the record alredy exist
        boolAbort = False
        If boolEditStatus = False Then
            If CheckRecordExistence(txtEmployeeNo.Text) = True Then
                MessageBox.Show("A record with a similar number already exists. Please enter a different employee number", "Duplicate Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtEmployeeNo.Focus()
                Exit Sub
            End If
        End If

        If boolAbort = True Then Exit Sub

        If txtSurname.Text = "" Or Mid(txtSurname.Text, 1, 1) = " " Then
            MessageBox.Show("Please Enter a Valid Value for the Employee Surname (or Last Name)", "Invalid Surname", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSurname.Focus()
            Exit Sub
        End If
        If txtFirstName.Text = "" Or Mid(txtFirstName.Text, 1, 1) = " " Then
            MessageBox.Show("Please Enter a Valid Value for the Employee First Name", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirstName.Focus()
            Exit Sub
        End If
        'Also do an id number validation
        'If ZimIdNumberValidation(txtIdNumber.Text) = False Then
        '    If MessageBox.Show("The ID Number entered is not valid for Zimbabwe" & vbCrLf & "Do you want to continue and save anyway?", MsgBoxStyle.YesNo, "Invalid Id Number Detected") = MsgBoxResult.No Then
        '        txtIdNumber.Focus()
        '        Exit Sub
        '    End If
        'End If
        Cursor = Cursors.WaitCursor

        strBirthDate = dpBirthDate.Value
        strHireDate = dpHireDate.Value
        strDischargeDate = dpTermDate.Value
        strMedaidDate = dpMedaidDate.Value
        strPensionDate = dpPensionDate.Value

        'Get the correct date format to the database
        If UCase(strSystemDateFormat) = UCase("English") Then
            strBirthDate = MediumDate(DatePart(DateInterval.Day, dpBirthDate.Value), DatePart(DateInterval.Month, dpBirthDate.Value), DatePart(DateInterval.Year, dpBirthDate.Value))
            strHireDate = MediumDate(DatePart(DateInterval.Day, dpHireDate.Value), DatePart(DateInterval.Month, dpHireDate.Value), DatePart(DateInterval.Year, dpHireDate.Value))
            strDischargeDate = MediumDate(DatePart(DateInterval.Day, dpTermDate.Value), DatePart(DateInterval.Month, dpTermDate.Value), DatePart(DateInterval.Year, dpTermDate.Value))
            strMedaidDate = MediumDate(DatePart(DateInterval.Day, dpMedaidDate.Value), DatePart(DateInterval.Month, dpMedaidDate.Value), DatePart(DateInterval.Year, dpMedaidDate.Value))
            strPensionDate = MediumDate(DatePart(DateInterval.Day, dpPensionDate.Value), DatePart(DateInterval.Month, dpPensionDate.Value), DatePart(DateInterval.Year, dpPensionDate.Value))
        End If

        If boolEditStatus = True Then 'the form was opened for edit
            Dim strUpdate As String = "UPDATE EmployeeContacts SET ContactPerson " _
                & "= '" & txtContactPerson.Text & "', Relationship = '" & txtRelationship.Text & "', " _
                & "Address1 = '" & txtConAddress1.Text & "', Address2 = '" & txtConAddress2.Text & "', " _
                & "Address3 = '" & txtConAddress3.Text & "', Address4 = '" & txtConAddress4.Text & "', " _
                & "Telephone = '" & txtContactTelephone.Text & "', " _
                & "Cellphone = '" & txtContactCellphone.Text & "', " _
                & "EmailAddress = '" & txtContactEmailAddress.Text & "' " _
                & "WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'"
            Dim sqlCommand As New Data.OleDb.OleDbCommand(strUpdate, cnn)
            sqlCommand.ExecuteNonQuery()
            'Get the initials from the given names and other names
            Dim strInits As String = Nothing
            If Not String.IsNullOrEmpty(txtFirstName.Text) Then
                strInits = UCase(Mid(txtFirstName.Text, 1, 1))
            End If
            If Not String.IsNullOrEmpty(txtOtherNames.Text) Then
                Dim strSplit() As String = Split(txtOtherNames.Text, " ")
                Dim j As Integer = 0
                For j = 0 To strSplit.Length - 1
                    If Not String.IsNullOrEmpty(strSplit(j)) Then
                        strInits = strInits & " " & UCase(Mid(strSplit(j), 1, 1))
                    End If
                Next
            End If

            strUpdate = "UPDATE EmployeeMaster SET LastName = '" & txtSurname.Text & "'" _
                & ",FirstName = '" & txtFirstName.Text & "'" _
                & ",OtherNames = '" & txtOtherNames.Text & "'" _
                & ",IdNumber = '" & txtIdNumber.Text & "'" _
                & ",Gender = '" & cboGender.Text & "'" _
                & ",BirthDate = '" & strBirthDate & "'" _
                & ",MaritalStatus = '" & cboMaritalStatus.Text & "'" _
                & ",Address1 = '" & txtAddress1.Text & "'" _
                & ",Address2 = '" & txtAddress2.Text & "'" _
                & ",Address3 = '" & txtAddress3.Text & "'" _
                & ",Address4 = '" & txtAddress4.Text & "'" _
                & ",Telephone = '" & mtxtTelephone.Text & "'" _
                & ",Cellphone = '" & mtxtCellphone.Text & "'" _
                & ",EmailAddress = '" & txtEmailAddress.Text & "'" _
                & ",ClockNo = " & txtClockNo.Text & "" _
                & ",DirAmt = " & txtTaxDiirectiveAmt.Text & "" _
                & ",DirPercent = " & txtTaxDirectivePercent.Text & "" _
                & ",DischDate = '" & strDischargeDate & "'" _
                & ",StopFrom = '" & txtStopFrom.Text & "'" _
                & ",MaidenName = '" & txtMaidenName.Text & "'" _
                & ",StopTo = '" & txtStopTo.Text & "'" _
                & ",TaxCode = '" & txtTaxCode.Text & "'" _
                & ",TaxDependents = '" & txtTaxDependents.Text & "'" _
                & ",TaxRef = '" & txtTaxReference.Text & "'" _
                & ",EmployeeNotes = '" & txtNotes.Text & "'" _
                & ",PicturePath = '" & lblFacePicPath.Text & "'" _
                & ",FingerPrintPath = '" & lblFinPicPath.Text & "'" _
                & ",Inits = '" & strInits & "', Status = '" & strActivityStatus & "'" _
                & ",EmployeeClass = '" & cboEmployeeClasses.Text & "'" _
                & ",Title = '" & cboTitle.Text & "' " _
                & "WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'"

            sqlCommand = New Data.OleDb.OleDbCommand(strUpdate, cnn)
            sqlCommand.ExecuteNonQuery()
            strUpdate = "UPDATE EmployeeBanks SET BankCode = '" & lblBankCode.Text & "'" _
                  & ",AccountType = '" & cboAccountType.Text & "'" _
                  & ",AccountHolder = '" & txtAccountOwner.Text & "'" _
                  & ",AccountNumber = '" & txtAccountNumber.Text & "'" _
                  & ",PayMethod = '" & cboPaymentMethod.Text & "' " _
                  & "WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'"
            sqlCommand = New Data.OleDb.OleDbCommand(strUpdate, cnn)
            sqlCommand.ExecuteNonQuery()
            sqlCommand = New Data.OleDb.OleDbCommand("SELECT EmployeeNo FROM Employment WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
            Dim objTestExistence As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
            If objTestExistence.HasRows = False Then
                InsertEmploymentRecord()
            Else
                strUpdate = "UPDATE Employment SET HireDate = '" & strHireDate & "'" _
                    & ",JobTitle = '" & txtPosition.Text & "'" _
                    & ",EmploymentStatus = '" & cboEmploymentStatus.Text & "'" _
                    & ",Department = '" & txtDepartment.Text & "'" _
                    & ",CostCenter = '" & txtCostCenter.Text & "'" _
                    & ",PayPoint = '" & txtPaypoint.Text & "', PensionDate = '" & strPensionDate & "', " _
                    & "MedaidDate = '" & strMedaidDate & "', " _
                    & "PensionNo = '" & txtPensionNumber.Text & "', MedaidNo = '" & txtMedaidNumber.Text & "' " _
                    & "WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'"
                sqlCommand = New Data.OleDb.OleDbCommand(strUpdate, cnn)
                sqlCommand.ExecuteNonQuery()
            End If
            objTestExistence.Close()
        Else
            boolAbort = False
            InsertMasterRecord()
            If boolAbort = True Then Exit Sub
            InsertContactsRecord()
            If boolAbort = True Then Exit Sub
            InsertBankingRecord()
            If boolAbort = True Then Exit Sub
            InsertEmploymentRecord()
            If boolAbort = True Then Exit Sub
        End If
        'If boolEditStatus = True Then SaveDates()
        boolAbort = False
        UpdateEmployeeCodes()
        If boolAbort = True Then Exit Sub
        UpdateEmployeeMasterFields()
        If boolAbort = True Then Exit Sub
        InsertDates()
        If boolAbort = True Then Exit Sub
        InsertFlags()
        If boolAbort = True Then Exit Sub
        InsertReferences()
        If boolAbort = True Then Exit Sub
        'default to the edit status
        boolEditStatus = True
        'Update the employee temporary view file
        'UpdateOnelineEmployeeCodes()
        'Update the audit file with the changes
        MasterChanges(txtEmployeeNo.Text, txtSurname.Text, txtFirstName.Text, _
            txtOtherNames.Text, txtIdNumber.Text, strBirthDate, txtAddress1.Text, _
            txtAddress2.Text, txtAddress3.Text, txtAddress4.Text, mtxtTelephone.Text, _
            mtxtCellphone.Text, txtEmailAddress.Text, txtContactPerson.Text, _
            txtRelationship.Text, txtConAddress1.Text, txtConAddress2.Text, _
            txtConAddress3.Text, txtAddress4.Text, txtContactCellphone.Text, _
            txtContactCellphone.Text, "", cboMaritalStatus.Text, "", cboGender.Text, _
            cboEmploymentStatus.Text, txtPosition.Text, txtDepartment.Text, _
            txtCostCenter.Text, txtPaypoint.Text, strHireDate, strDischargeDate, _
            strPensionDate, dpMedaidDate.Text, txtPensionNumber.Text, _
            txtMedaidNumber.Text, cboBankCodes.Text, cboPaymentMethod.Text, _
            txtAccountNumber.Text, txtAccountOwner.Text, cboAccountType.Text)
        'Check and write out code changes as well
        Dim i As Integer = 0
        For i = 0 To dgvEarnings.Rows.Count - 1
            CodeValueChanges(CInt(dgvEarnings.Rows(i).Cells(0).Value.ToString), _
                dgvEarnings.Rows(i).Cells(1).Value.ToString, CDbl(dgvEarnings.Rows(i).Cells(2).Value.ToString))
        Next
        For i = 0 To dgvDeductions.Rows.Count - 1
            CodeValueChanges(CInt(dgvDeductions.Rows(i).Cells(0).Value.ToString), _
                dgvDeductions.Rows(i).Cells(1).Value.ToString, CDbl(dgvDeductions.Rows(i).Cells(2).Value.ToString))
        Next
        For i = 0 To dgvOther.Rows.Count - 1
            CodeValueChanges(CInt(dgvOther.Rows(i).Cells(0).Value.ToString), _
                dgvOther.Rows(i).Cells(1).Value.ToString, CDbl(dgvOther.Rows(i).Cells(2).Value.ToString))
        Next
        Cursor = Cursors.Default
        If boolAbort = False Then
            MessageBox.Show("Employee details saved successfully ", "Employee Details Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            boolEditStatus = True
            strPublicEmployeeId = txtEmployeeNo.Text
            'Reload the employee data in edit mode
            txtEmployeeNo.Enabled = False
            LoadSelectedEmployee()
            LoadIR()
        End If
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & "on Employee Record Save"
        ShowErrorMessage()
    End Sub

    Private Sub txtEmployeeNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmployeeNo.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtSurname.Focus()
        If Asc(e.KeyChar) = 34 Then e.Handled = True
        If e.KeyChar = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAddress1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress1.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtAddress2.Focus()
    End Sub

    Private Sub txtAddress2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress2.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtAddress3.Focus()
    End Sub

    Private Sub txtAddress3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress3.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtAddress4.Focus()
    End Sub

    Private Sub txtAddress4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress4.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then mtxtTelephone.Focus()
    End Sub

    Private Sub mtxtTelephone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mtxtTelephone.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then mtxtCellphone.Focus()
    End Sub

    Private Sub txtSurname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSurname.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtFirstName.Focus()
    End Sub

    Private Sub txtFirstName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFirstName.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtIdNumber.Focus()
    End Sub

    Private Sub txtIdNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdNumber.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtOtherNames.Focus()
    End Sub

    Private Sub txtOtherNames_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherNames.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then dpBirthDate.Focus()
    End Sub

    Private Sub dpBirthDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dpBirthDate.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then cboGender.Focus()
    End Sub

    Private Sub cboGender_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboGender.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then cboMaritalStatus.Focus()
    End Sub

    Private Sub cboMaritalStatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMaritalStatus.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtAddress1.Focus()
    End Sub

    Private Sub txtContactPerson_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactPerson.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtRelationship.Focus()
    End Sub

    Private Sub txtRelationship_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRelationship.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtConAddress1.Focus()
    End Sub

    Private Sub txtConAddress1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConAddress1.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtConAddress2.Focus()
    End Sub

    Private Sub txtConAddress2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConAddress2.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtConAddress3.Focus()
    End Sub

    Private Sub txtConAddress3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConAddress3.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtConAddress4.Focus()
    End Sub

    Private Sub txtConAddress4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConAddress4.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtContactTelephone.Focus()
    End Sub

    Private Sub txtContactCellphone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactCellphone.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then
            TabControl1.SelectedTab = TabPage7
            txtContactPerson.Focus()
        End If
    End Sub

    Private Sub mtxtCellphone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mtxtCellphone.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtEmailAddress.Focus()
    End Sub

    Private Sub txtEmailAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailAddress.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub txtContactTelephone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactTelephone.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtContactCellphone.Focus()
    End Sub

    Private Sub cboPaymentMethod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPaymentMethod.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then cboBankCodes.Focus()
    End Sub

    Private Sub cboBankCodes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboBankCodes.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtAccountNumber.Focus()
    End Sub

    Private Sub txtAccountNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountNumber.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then cboAccountType.Focus()
    End Sub

    Private Sub cboAccountType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAccountType.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtAccountOwner.Focus()
    End Sub

    Private Sub txtAccountOwner_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountOwner.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then TabControl1.SelectedTab = TabPage2
    End Sub

    Private Sub dpHireDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dpHireDate.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then cboEmploymentStatus.Focus()
    End Sub

    Private Sub cboEmploymentStatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboEmploymentStatus.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtPosition.Focus()
    End Sub

    Private Sub txtPosition_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPosition.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtDepartment.Focus()
    End Sub

    Private Sub txtDepartment_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDepartment.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtPaypoint.Focus()
    End Sub

    Private Sub txtPaypoint_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaypoint.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtCostCenter.Focus()
    End Sub

    Private Sub txtCostCenter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostCenter.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then dpPensionDate.Focus()
    End Sub

    Private Sub dpPensionDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dpPensionDate.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtPensionNumber.Focus()
    End Sub

    Private Sub txtPensionNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPensionNumber.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then dpMedaidDate.Focus()
    End Sub

    Private Sub dpMedaidDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dpMedaidDate.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtMedaidNumber.Focus()
    End Sub

    Private Sub txtMedaidNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMedaidNumber.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then TabControl1.SelectedIndex = 4
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        strEmployeeGivenNames = Me.txtSurname.Text & " " & Me.txtFirstName.Text
        boolEditStatus = False
        Dim f As New frmLeaveApplication
        f.ShowDialog()
        LoadLeaveData()
    End Sub

    Private Sub ClearControls()
        If boolEditStatus = False Then txtEmployeeNo.Clear()
        txtSurname.Clear()
        txtFirstName.Clear()
        txtIdNumber.Clear()
        txtOtherNames.Clear()
        cboGender.Text = ""
        cboMaritalStatus.Text = ""
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtAddress3.Clear()
        txtAddress4.Clear()
        mtxtTelephone.Clear()
        mtxtCellphone.Clear()
        txtEmailAddress.Clear()
        txtContactPerson.Clear()
        txtRelationship.Clear()
        txtConAddress1.Clear()
        txtConAddress2.Clear()
        txtConAddress3.Clear()
        txtConAddress4.Clear()
        txtContactTelephone.Clear()
        txtContactCellphone.Clear()
        cboPaymentMethod.Text = ""
        cboBankCodes.Text = ""
        txtAccountNumber.Clear()
        cboAccountType.Text = ""
        txtAccountOwner.Clear()
        txtMaidenName.Clear()
        cboEmploymentStatus.Text = ""
        txtPosition.Text = ""
        txtDepartment.Text = ""
        txtPaypoint.Text = ""
        txtCostCenter.Text = ""
        txtPensionNumber.Clear()
        txtMedaidNumber.Clear()
    End Sub

    'Private Sub btnNewEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewEmployee.Click
    '    boolEditStatus = False
    '    strPublicEmployeeId = ""
    '    LoadSelectedEmployee()
    '    ClearControls()
    '    CustomTabControl1.SelectedTab = TabPage1
    'End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearControls()
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub LoadPayrollDetails()
        If TabControl1.SelectedTab.Text = "Current Payroll Information" Then
            If boolEditStatus = True Then
                With grdEarnings
                    .Rows.Clear()
                End With
                With grdDeductions
                    .Rows.Clear()
                End With
                Dim i As Integer = 0
                Dim dblGrossPay As Double = 0 : Dim dblTotalDeductions As Double = 0 : Dim dblNetSalary As Double = 0
                GetKeyDataFields()
                Dim objCommand As New Data.OleDb.OleDbCommand("SELECT EmployeeNo, " _
                    & "RunAmounts FROM EmployeeRunFile WHERE EmployeeNo = " _
                    & "'" & strPublicEmployeeId & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                ArrDisplayEarnings = New ArrayList : arrDisplayDeductions = New ArrayList
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(1).ToString) Then
                        Dim strBuffer() As String = Split(objReader(1).ToString, "|")
                        Dim n As Integer = 0
                        For n = 0 To strBuffer.Length - 1
                            objCommand = New Data.OleDb.OleDbCommand("SELECT Description, CodeType FROM SystemCodes WHERE CodeNo = " & (n + 1) & "", cnn)
                            Dim objCodeReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                            If objCodeReader.HasRows Then
                                objCodeReader.Read()
                                If Not IsDBNull(objCodeReader(1).ToString) Then
                                    If UCase(objCodeReader(1).ToString) = "E" Then
                                        ArrDisplayEarnings.Add(Format((n + 1), "000") & ";" & UCase(objCodeReader(0).ToString) & ";" & strBuffer(n))
                                    End If
                                    If UCase(objCodeReader(1).ToString) = ("D") Then
                                        arrDisplayDeductions.Add(Format((n + 1), "000") & ";" & UCase(objCodeReader(0).ToString) & ";" & strBuffer(n))
                                    End If
                                End If
                            End If
                        Next
                        dblGrossPay = strBuffer(intPayrollGrossIncomeCode - 1)
                        dblTotalDeductions = strBuffer(intPayrollTotalDeductions - 1)
                        dblNetSalary = strBuffer(intPayrollNetIncomeCode - 1)
                    End If
                End If

                For i = 0 To (ArrDisplayEarnings.Count - 1)
                    Dim strbuffer() As String = Split(ArrDisplayEarnings(i), ";")
                    If IsNumeric(strbuffer(2)) Then
                        If CDbl(strbuffer(2)) <> 0 Then
                            grdEarnings.Rows.Add(1)
                            grdEarnings.Rows(grdEarnings.Rows.Count - 1).Cells(0).Value = CStr(Format(CInt(strbuffer(0)), "000"))
                            grdEarnings.Rows(grdEarnings.Rows.Count - 1).Cells(1).Value = strbuffer(1)
                            grdEarnings.Rows(grdEarnings.Rows.Count - 1).Cells(2).Value = Format(CDbl(strbuffer(2)), "##0.00")
                        End If
                    End If
                Next i
                For i = 0 To (arrDisplayDeductions.Count - 1)
                    Dim strbuffer() As String = Split(arrDisplayDeductions(i), ";")
                    If IsNumeric(strbuffer(2)) Then
                        If CDbl(strbuffer(2)) <> 0 Then
                            grdDeductions.Rows.Add(1)
                            grdDeductions.Rows(grdDeductions.Rows.Count - 1).Cells(0).Value = CStr(Format(CInt(strbuffer(0)), "000"))
                            grdDeductions.Rows(grdDeductions.Rows.Count - 1).Cells(1).Value = strbuffer(1)
                            grdDeductions.Rows(grdDeductions.Rows.Count - 1).Cells(2).Value = Format(CDbl(strbuffer(2)), "##0.00")
                        End If
                    End If
                Next i

                lblGrossPay.Text = CStr(Format(dblGrossPay, "#,##0.00"))
                lblTotalDeductions.Text = CStr(Format(dblTotalDeductions, "#,##0.00"))
                lblNetPay.Text = CStr(Format((dblGrossPay - dblTotalDeductions), "#,##0.00"))

            End If
        End If
    End Sub

    'Private Sub TabControl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.Click
    '    If String.IsNullOrEmpty(txtEmployeeNo.Text) Then Exit Sub Else LoadPayrollDetails()
    'End Sub

    Private Sub LoadWorkStructures()
        On Error GoTo RaiseErr

        Dim sqlCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        txtCostCenter.Items.Clear()
        txtDepartment.Items.Clear()
        txtPaypoint.Items.Clear()
        txtPosition.Items.Clear()

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT CostCenterName " _
            & "FROM SystemCostCenters ORDER BY CostCenterName", cnn)
        objReader = sqlCommand.ExecuteReader

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then txtCostCenter.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT PayPointName " _
            & "FROM SystemPayPoints ORDER BY PayPointName", cnn)
        objReader = sqlCommand.ExecuteReader

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then txtPaypoint.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT DepartmentName " _
            & "FROM SystemDepartments ORDER BY DepartmentName", cnn)
        objReader = sqlCommand.ExecuteReader

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then txtDepartment.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT JobTitle " _
            & "FROM JobProfiles ORDER BY JobTitle", cnn)
        objReader = sqlCommand.ExecuteReader

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then txtPosition.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Work Structure Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub txtEmailAddress_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEmailAddress.Validating
        If Not String.IsNullOrEmpty(txtEmailAddress.Text) Then
            If IsEmailAddress(txtEmailAddress.Text) = False Then
                MessageBox.Show("Please enter a valid email address", "invalid Email Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtEmailAddress.Focus()
                Exit Sub
            End If
        End If
    End Sub

    'Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click
    '    If TabControl1.SelectedTab.Text = "Leave History" Then
    '        btnApply.Visible = True
    '    Else
    '        btnApply.Visible = False
    '    End If
    'End Sub

    Private Sub LoadFlags()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT " _
            & "SystemFlagNames.FlagNo, SystemFlagNames.FlagName FROM " _
            & "SystemFlagNames ORDER BY FlagNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGridFlags.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(1).ToString) Then
                If Not String.IsNullOrEmpty(objReader(1).ToString) Then
                    dGridFlags.Rows.Add(1)
                    If Not IsDBNull(objReader(0).ToString) Then dGridFlags.Rows(dGridFlags.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                    If Not IsDBNull(objReader(1).ToString) Then dGridFlags.Rows(dGridFlags.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                End If
            End If
        End While
        objReader.Close()
        If boolEditStatus = False Then Exit Sub
        'Assign the values for the flags
        Dim i As Integer = 0
        For i = 0 To dGridFlags.Rows.Count - 1
            Dim intFlag As Integer = 0
            If Not (Object.Equals(Convert.ToString(dGridFlags.Rows(i).Cells(0).Value), "")) Then
                intFlag = Convert.ToString(dGridFlags.Rows(i).Cells(0).Value)
            End If
            Dim strSql As String = "SELECT Flag from EmployeeFlags WHERE " _
                & "EmployeeFlags.EmployeeNo = '" & strPublicEmployeeId & "' AND " _
                & "EmployeeFlags.OrdinalNo = " & intFlag & ""
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = sqlCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then dGridFlags.Rows(i).Cells(2).Value = objReader(0).ToString
            End If
        Next
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Work Structure Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadReferenceNumbers()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT OrdinalNo, ReferenceName FROM SystemReferences ORDER BY OrdinalNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGridReferences.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(1).ToString) Then
                Dim strReferenceName As String = objReader(1).ToString
                If Not String.IsNullOrEmpty(strReferenceName) Then
                    dGridReferences.Rows.Add(1)
                    If Not IsDBNull(objReader(0).ToString) Then dGridReferences.Rows(dGridReferences.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                    If Not IsDBNull(objReader(1).ToString) Then dGridReferences.Rows(dGridReferences.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                End If
            End If
        End While
        objReader.Close()
        'Get the employee values
        If boolEditStatus = False Then Exit Sub
        Dim i As Integer = 0
        For i = 0 To dGridReferences.Rows.Count - 1
            Dim intNum As Integer = 0
            If Not (Object.Equals(Convert.ToString(dGridReferences.Rows(i).Cells(0).Value), "")) Then
                If IsNumeric(Convert.ToString(dGridReferences.Rows(i).Cells(0).Value)) Then
                    intNum = CInt(Convert.ToString(dGridReferences.Rows(i).Cells(0).Value))
                End If
            End If
            sqlCommand = New Data.OleDb.OleDbCommand("SELECT Reference FROM EmployeeReferences WHERE EmployeeNo = '" & strPublicEmployeeId & "' AND OrdinalNo = " & intNum & "", cnn)
            objReader = sqlCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then
                    dGridReferences.Rows(i).Cells(2).Value = objReader(0).ToString
                End If
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Reference Numbers Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadDates()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT OrdinalNo, DateName FROM SystemDates ORDER BY OrdinalNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGridDates.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(1).ToString) Then
                Dim strDateName As String = objReader(1).ToString
                If Not String.IsNullOrEmpty(strDateName) Then
                    dGridDates.Rows.Add(1)
                    If Not IsDBNull(objReader(0).ToString) Then dGridDates.Rows(dGridDates.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                    If Not IsDBNull(objReader(1).ToString) Then dGridDates.Rows(dGridDates.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                End If
            End If
        End While
        objReader.Close()
        If boolEditStatus = False Then Exit Sub
        'Get the employee values
        Dim i As Integer = 0
        For i = 0 To dGridDates.Rows.Count - 1
            Dim intNum As Integer = 0
            If Not (Object.Equals(Convert.ToString(dGridDates.Rows(i).Cells(0).Value), "")) Then
                If IsNumeric(Convert.ToString(dGridDates.Rows(i).Cells(0).Value)) Then
                    intNum = CInt(Convert.ToString(dGridDates.Rows(i).Cells(0).Value))
                End If
            End If
            sqlCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, DateValue, 105) AS [DateValue] " _
                & "FROM EmployeeDates WHERE EmployeeNo = '" & strPublicEmployeeId & "' AND OrdinalNo = " & intNum & "", cnn)
            objReader = sqlCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then
                    Dim strBuffer() As String = Split(objReader(0).ToString, "-")
                    If UCase(CStr(Format(CDate(strBuffer(0) & "-" & getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2))), "dd-MMM-yyyy"))) <> "01-JAN-1900" Then
                        dGridDates.Rows(i).Cells(2).Value = CStr(Format(CDate(strBuffer(0) & "-" & getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))))
                    End If
                End If
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Dates Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGridFlags_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridFlags.CellClick
        If dGridFlags.CurrentCell.ColumnIndex = 3 Then
            Dim intRow As Integer = dGridFlags.CurrentCell.RowIndex
            If Not dGridFlags.CurrentRow.Cells(2).Value = Nothing Then
                strSelectedValue = dGridFlags.Rows(intRow).Cells(2).Value.ToString
            Else
                strSelectedValue = ""
            End If
            If Not (Object.Equals(Convert.ToString(dGridFlags.CurrentRow.Cells(0).Value), "")) Then
                intSelectedTransaction = Convert.ToString(dGridFlags.CurrentRow.Cells(0).Value)
                Dim f As New frmEmployeeFlagOptions
                f.ShowDialog()
                dGridFlags.CurrentRow.Cells(2).Value = strSelectedValue
            End If
        End If
    End Sub

    Private Sub dGridDates_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridDates.CellClick
        If dGridDates.CurrentCell.ColumnIndex = 3 Then
            Dim intRow As Integer = dGridDates.CurrentCell.RowIndex
            If Not dGridDates.CurrentRow.Cells(2).Value = Nothing Then
                strSelectedDate = dGridDates.Rows(intRow).Cells(2).Value.ToString
            Else
                strSelectedDate = ""
            End If
            If Not (Object.Equals(Convert.ToString(dGridDates.CurrentRow.Cells(0).Value), "")) Then
                intSelectedTransaction = Convert.ToString(dGridDates.CurrentRow.Cells(0).Value)
                Dim f As New frmDatePick
                f.ShowDialog()
                dGridDates.CurrentRow.Cells(2).Value = strSelectedDate
            End If
        End If
    End Sub

    Private Sub SaveDates()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeDates WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim i As Integer = 0
        For i = 0 To dGridDates.Rows.Count - 1
            Dim intOrdinal As Integer = 0
            Dim strDateValue As String = "01-JAN-1900"
            If Not (Object.Equals(Convert.ToString(dGridDates.Rows(i).Cells(0).Value), "")) Then
                If IsNumeric(Convert.ToString(dGridDates.Rows(i).Cells(0).Value)) Then
                    intOrdinal = CInt(Convert.ToString(dGridDates.Rows(i).Cells(0).Value))
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridDates.Rows(i).Cells(2).Value), "")) Then
                If IsDate(Convert.ToString(dGridDates.Rows(i).Cells(2).Value)) Then
                    strDateValue = Format(Convert.ToDateTime(dGridDates.Rows(i).Cells(2).Value), "dd-MMM-yyyy")
                End If
            End If
            sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeDates (OrdinalNo, DateValue, " _
                & "EmployeeNo) VALUES (" & intOrdinal & ", '" & strDateValue & "', " _
                & "'" & txtEmployeeNo.Text & "')", cnn)
            sqlCommand.ExecuteNonQuery()
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Work Structure Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGridDates_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridDates.CellEnter
        'set Date Picker to false when initially click on cell
        ''If dpDates.Visible = True Then dpDates.Visible = False
        ''If e.ColumnIndex = 2 Then
        ''    'set date picker for category datagrid
        ''    dpDates.Size = dGridDates.CurrentCell.Size
        ''    dpDates.Top = dGridDates.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + 3
        ''    dpDates.Left = dGridDates.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left + 3
        ''    If Not (Object.Equals(Convert.ToString(dGridDates.CurrentCell.Value), "")) Then
        ''        dpDates.Value = Convert.ToDateTime(dGridDates.CurrentCell.Value)
        ''    End If
        ''    dpDates.Visible = True
        ''End If
    End Sub

    Private Sub dpDates_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpDates.ValueChanged
        dGridDates.CurrentCell.Value = dpDates.Text
        strInitialDateValue = dpDates.Text
        dpDates.Visible = False
    End Sub

    Private Sub dGridDates_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dGridDates.CellValidating
        ''If e.ColumnIndex = 2 Then
        ''    dGridDates.CurrentCell.Value = dpDates.Text
        ''End If
    End Sub

    Private Sub cboTitle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTitle.SelectedIndexChanged
        If UCase(cboTitle.Text) = "MR" Then
            cboGender.Text = "Male"
        Else
            cboGender.Text = "Female"
        End If
    End Sub

    Private Sub btnAddBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBank.Click
        boolEditStatus = False
        Dim f As New frmBanksMaintenance
        f.ShowDialog()
        GetBankFileDetails()
    End Sub

    Private Sub btnLoadFace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadFace.Click
        ofd.ShowDialog()
        lblFacePicPath.Text = ofd.FileName
        If Not String.IsNullOrEmpty(lblFacePicPath.Text) Then
            If System.IO.File.Exists(lblFacePicPath.Text) Then
                picFace.Load(lblFacePicPath.Text)
            End If
        End If
    End Sub

    Private Sub btnFingerPrints_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFingerPrints.Click
        ofd.ShowDialog()
        lblFinPicPath.Text = ofd.FileName
        If Not String.IsNullOrEmpty(lblFinPicPath.Text) Then
            If System.IO.File.Exists(lblFinPicPath.Text) Then
                picFinger.Load(lblFinPicPath.Text)
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAddCourse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCourse.Click
        'Check first that the employee record has been created in the masterfile
        On Error GoTo RaiseErr
        Dim objCmd As New Data.OleDb.OleDbCommand("SELECT EmployeeNo FROM EmployeeMaster WHERE " _
            & "EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmd.ExecuteReader
        If objReader.HasRows Then
            objReader.Close()
            boolEditStatus = False
            strPublicEmployeeId = txtEmployeeNo.Text
            Dim f As New frmEmployeeQualifications
            f.ShowDialog()
            boolEditStatus = True
            LoadQualifications()
        Else
            If MessageBox.Show("You must save the master details before proceeding to create qualifications." & vbCrLf & _
                    "Do you want to save master details before proceeding?", "Qualifications Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                SaveEmployeeData()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Qualifications Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadQualifications()
        On Error GoTo RaiseErr
        Dim objCmd As New Data.OleDb.OleDbCommand("SELECT TransactionId, CourseName, CourseLevel, " _
            & "CONVERT(NVARCHAR, StartDate, 105) AS [StartDate], CONVERT(NVARCHAR, EndDate, 105) AS [EndDate], " _
            & "Institute, Outcome, SubjectsTaken FROM EmployeeQualifications WHERE " _
            & "EmployeeNo = '" & strPublicEmployeeId & "' ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmd.ExecuteReader
        dgrdEducation.Rows.Clear()
        While objReader.Read
            With dgrdEducation
                .Rows.Add(1)
                Dim strBuffer() As String
                'TransactionId, CourseName, CourseLevel, StartDate, EndDate, Institute, Outcome, SubjectsTaken
                .Rows(.Rows.Count - 1).Cells(0).Value = objReader("TransactionId").ToString
                .Rows(.Rows.Count - 1).Cells(1).Value = objReader("CourseName").ToString
                .Rows(.Rows.Count - 1).Cells(2).Value = objReader("CourseLevel").ToString
                If Not IsDBNull(objReader("StartDate").ToString) Then
                    strBuffer = Split(objReader("StartDate").ToString, "-")
                    .Rows(.Rows.Count - 1).Cells(3).Value = UCase(strBuffer(0) & "-" & getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
                End If
                If Not IsDBNull(objReader("EndDate").ToString) Then
                    strBuffer = Split(objReader("EndDate").ToString, "-")
                    .Rows(.Rows.Count - 1).Cells(4).Value = UCase(strBuffer(0) & "-" & getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
                End If

                .Rows(.Rows.Count - 1).Cells(5).Value = objReader("Institute").ToString
                .Rows(.Rows.Count - 1).Cells(6).Value = objReader("Outcome").ToString
                .Rows(.Rows.Count - 1).Cells(7).Value = objReader("SubjectsTaken").ToString
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Qualifications Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If dgrdEducation.Rows.Count > 0 Then
            If dgrdEducation.SelectedRows.Count > 0 Then
                intSelectedTransaction = CInt(dgrdEducation.CurrentRow.Cells(0).Value.ToString)
                boolEditStatus = True
                Dim f As New frmEmployeeQualifications
                f.ShowDialog()
                boolEditStatus = True
                LoadQualifications()
            End If
        End If
    End Sub

    Private Sub dgrdEducation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrdEducation.Click
        On Error GoTo RaiseErr
        If dgrdEducation.Rows.Count > 0 Then
            With dGridSubjects
                .Rows.Clear()
                Dim strx As String = dgrdEducation.CurrentRow.Cells(7).Value.ToString
                Dim strValues() As String = Split(strx, "|")
                For i As Integer = 0 To strValues.Length - 1
                    Dim strIndividualSubject() As String = Split(strValues(i), "~")
                    If strIndividualSubject.Length >= 2 Then
                        .Rows.Add(1)
                        .Rows(.Rows.Count - 1).Cells(0).Value = strIndividualSubject(0)
                        .Rows(.Rows.Count - 1).Cells(1).Value = strIndividualSubject(1)
                    End If
                Next
            End With
        End If
        Exit Sub
RaiseErr:
        Exit Sub
    End Sub

    Private Sub dgrdEducation_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrdEducation.SelectionChanged
        On Error GoTo RaiseErr
        If dgrdEducation.Rows.Count > 0 Then
            With dGridSubjects
                .Rows.Clear()
                Dim strValues() As String = Split(dgrdEducation.CurrentRow.Cells(7).Value.ToString, "|")
                For i As Integer = 0 To strValues.Length - 1
                    Dim strIndividualSubject() As String = Split(strValues(i), "~")
                    If strIndividualSubject.Length >= 2 Then
                        .Rows.Add(1)
                        .Rows(.Rows.Count - 1).Cells(0).Value = strIndividualSubject(0)
                        .Rows(.Rows.Count - 1).Cells(1).Value = strIndividualSubject(1)
                    End If
                Next
            End With
        End If
        Exit Sub
RaiseErr:
        Exit Sub
    End Sub

    Private Sub dGridLeave_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridLeave.DoubleClick
        If dGridLeave.Rows.Count > 0 Then
            If Not (Object.Equals(Convert.ToString(dGridLeave.CurrentRow.Cells(7).Value), "")) Then
                intSelectedTransaction = Convert.ToString(dGridLeave.CurrentRow.Cells(7).Value)
                boolEditStatus = True
                Dim f As New frmLeaveApplication
                f.ShowDialog()
                LoadLeaveData()
            End If
        End If
    End Sub

    Private Sub LoadLeaveData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, StartDate, 105) AS [StartDate], " _
            & "CONVERT(NVARCHAR, EndDate, 105) AS [EndDate], " _
            & "SystemLeaveParameters.Description, BalanceBefore, DaysTaken, BalanceAfter, " _
            & "Remarks, EmployeeLeaveDetails.TransactionId FROM EmployeeLeaveDetails LEFT " _
            & "OUTER JOIN SystemLeaveParameters ON EmployeeLeaveDetails.LeaveType = " _
            & "SystemLeaveParameters.TransactionId  WHERE EmployeeNo = '" & strPublicEmployeeId & "' ORDER BY StartDate", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridLeave.Rows.Clear()
        While objReader.Read
            dGridLeave.Rows.Add(1)
            With dGridLeave
                Dim strBuffer() As String
                If Not IsDBNull(objReader(0).ToString) Then
                    strBuffer = Split(objReader(0).ToString, "-")
                    .Rows(.Rows.Count - 1).Cells(0).Value = CInt(strBuffer(0)) & "-" & getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2))
                End If

                If Not IsDBNull(objReader(1).ToString) Then
                    strBuffer = Split(objReader(1).ToString, "-")
                    .Rows(.Rows.Count - 1).Cells(1).Value = CInt(strBuffer(0)) & "-" & getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2))
                End If

                If Not IsDBNull(objReader(2).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
                If Not IsDBNull(objReader(4).ToString) Then .Rows(.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
                If Not IsDBNull(objReader(5).ToString) Then .Rows(.Rows.Count - 1).Cells(5).Value = objReader(5).ToString
                If Not IsDBNull(objReader(6).ToString) Then .Rows(.Rows.Count - 1).Cells(6).Value = objReader(6).ToString
                If Not IsDBNull(objReader(7).ToString) Then .Rows(.Rows.Count - 1).Cells(7).Value = objReader(7).ToString
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Leave Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnAddDependent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDependent.Click
        If String.IsNullOrEmpty(txtEmployeeNo.Text) Then
            MessageBox.Show("This process cannot be executed as there is no employee number", "Missing Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEmployeeNo.Focus()
            Exit Sub
        End If
        strSelectedEmployeeFullDetails = Me.txtEmployeeNo.Text & ", " & Me.txtSurname.Text & " " & Me.txtFirstName.Text
        If boolEditStatus = False Then
            If MessageBox.Show("The main employee details need to be saved first before adding dependents" & vbCrLf & _
                    "Do you want to proceed and save the details first?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                SaveEmployeeData()
            Else
                Exit Sub
            End If
        End If
        boolNewDependent = True
        strPublicEmployeeId = Me.txtEmployeeNo.Text
        Dim f As New frmDependentSetup
        f.ShowDialog()
        LoadDependents()
    End Sub

    Private Sub LoadDependents()
        On Error GoTo RaiseErr
        Dim i As Integer = 0
        Dim dbReader As OleDb.OleDbDataReader
        Dim strSql As String = "SELECT TransactionId, IdNumber, GivenNames, CONVERT(NVARCHAR, DateOfBirth, 105) AS [DateOfBirth], " _
            & "DependentCode FROM EmployeeDependents WHERE EmployeeNo = '" & strPublicEmployeeId & "'"
        Dim dbCommand As New OleDb.OleDbCommand(strSql, cnn)
        dbReader = dbCommand.ExecuteReader
        Me.dGridDependents.Rows.Clear()
        While dbReader.Read
            Me.dGridDependents.Rows.Add(1)
            If Not IsDBNull(dbReader("TransactionId").ToString) Then Me.dGridDependents.Rows(i).Cells(0).Value = dbReader("TransactionId").ToString
            If Not IsDBNull(dbReader("IdNumber").ToString) Then Me.dGridDependents.Rows(i).Cells(1).Value = dbReader("IdNumber").ToString
            If Not IsDBNull(dbReader("GivenNames").ToString) Then Me.dGridDependents.Rows(i).Cells(2).Value = dbReader("GivenNames").ToString
            If Not IsDBNull(dbReader("DateOfBirth").ToString) Then
                Dim strBuffer() As String = Split(dbReader("DateOfBirth").ToString, "-")
                Me.dGridDependents.Rows(i).Cells(3).Value = Format(CInt(strBuffer(0)), "00") & "-" & getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2))
            End If

            If Not IsDBNull(dbReader("DependentCode").ToString) Then Me.dGridDependents.Rows(i).Cells(4).Value = dbReader("DependentCode").ToString
            i += 1
        End While
        Me.dGridDependents.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Dependents Data Load "
        ShowErrorMessage()
    End Sub

    Private Sub btnEditDependent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditDependent.Click
        If boolEditStatus = False Then Exit Sub
        boolNewDependent = False
        strPublicEmployeeId = Me.txtEmployeeNo.Text
        ShowDependents()
    End Sub

    Private Sub ShowDependents()
        strSelectedEmployeeFullDetails = Me.txtEmployeeNo.Text & ", " & Me.txtSurname.Text & " " & Me.txtFirstName.Text
        If Me.dGridDependents.Rows.Count > 0 Then
            strDependentIdNumber = Me.dGridDependents.CurrentRow.Cells(1).Value
            strDependentGivenNames = Me.dGridDependents.CurrentRow.Cells(2).Value
            strBirthDate = Me.dGridDependents.CurrentRow.Cells(3).Value
            strDependentCode = Me.dGridDependents.CurrentRow.Cells(4).Value
            'Post also the entry number
            intEntryNumber = CInt(Me.dGridDependents.CurrentRow.Cells(0).Value)
            Dim f As New frmDependentSetup
            f.ShowDialog()
            LoadDependents()
        End If
    End Sub

    Private Sub dGridDependents_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridDependents.DoubleClick
        If boolEditStatus = False Then Exit Sub
        boolNewDependent = False
        strPublicEmployeeId = Me.txtEmployeeNo.Text
        ShowDependents()
    End Sub

    Private Sub btnDeleteDependent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDependent.Click
        On Error GoTo RaiseErr
        Dim strSql As String = "DELETE FROM EmployeeDependents WHERE EntryNumber = " & CInt(Me.dGridDependents.CurrentRow.Cells(0).Value) & ""
        Dim dbCommand As New OleDb.OleDbCommand(strSql, cnn)
        If Me.dGridDependents.Rows.Count > 0 Then
            If MessageBox.Show("Are you sure you want to delete " & Me.dGridDependents.CurrentRow.Cells(2).Value & " from the system?", _
                    "Dependent Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                dbCommand.ExecuteNonQuery()
                MessageBox.Show("The record has been successfully deleted", "Dependent Deletion Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.LoadDependents()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = False
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Dependent Record Deletion"
        ShowErrorMessage()
    End Sub

    Public Sub NextEmployeeNumber()
        On Error GoTo RaiseErr
        strNextEmployeeNumber = "0"
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT EmployeeNo FROM EmployeeMaster ORDER BY EmployeeNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrNumbers As New ArrayList
        While objReader.Read
            If IsNumeric(objReader(0).ToString) Then arrNumbers.Add(objReader(0).ToString)
        End While
        objReader.Close()
        arrNumbers.Sort()
        If arrNumbers.Count > 0 Then
            strNextEmployeeNumber = Str(arrNumbers.Item(arrNumbers.Count - 1))
        Else
            strNextEmployeeNumber = "0"
        End If
        strNextEmployeeNumber = CStr(CLng(strNextEmployeeNumber) + 1)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On next employee number fetch"
        ShowErrorMessage()
    End Sub

    Private Sub btnAddClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddClass.Click
        Dim f As New frmEmployeeClassesSetup
        f.ShowDialog()
        LoadEmployeeClasses()
    End Sub

    Private Sub expandablePanel1_ExpandedChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles expandablePanel1.ExpandedChanged
        AdjustSplitter()
    End Sub

    Private Sub AdjustSplitter()
        ' Suspend layout changes until all splitter properties have been updated
        splitMain.SuspendLayout()
        expandablePanel1.Dock = DockStyle.None
        'Is the left header group currently expanded?
        If (splitMain.FixedPanel = FixedPanel.None) Then

            'Make the right panel of the splitter fixed in size
            splitMain.FixedPanel = FixedPanel.Panel1
            splitMain.IsSplitterFixed = True

            ' Remember the current height of the header group

            ' We have not changed the orientation of the header yet, so the width of 
            ' the splitter panel is going to be the height of the collapsed header group
            Dim newWidth As Integer = expandablePanel1.Width + 1 'kryptonHeaderGroupLeft.PreferredSize.Width

            ' Make the header group fixed just as the new height
            _originalSplitterDistance = splitMain.SplitterDistance
            splitMain.SplitterDistance = _originalSplitterDistance + (splitMain.Panel2.Width - newWidth) 'splitMain.SplitterDistance + (_widthLeftRight - 32) 'newWidth)
            splitMain.Panel1MinSize = newWidth
        Else

            ' Make the bottom panel not-fixed in size anymore
            splitMain.FixedPanel = FixedPanel.None
            splitMain.IsSplitterFixed = False

            ' Put back the minimise size to the original

            ' Calculate the correct splitter we want to put back
            splitMain.SplitterDistance = _originalSplitterDistance
            expandablePanel1.Dock = DockStyle.Fill

        End If

        splitMain.ResumeLayout()
    End Sub

    Private Sub dGridIR_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridIR.RowEnter
        On Error Resume Next
        dgrdDetails.Rows.Clear()
        With dgrdDetails
            If Not (Object.Equals(Convert.ToString(.CurrentRow.Cells(3).Value), "")) Then
                .Rows.Add(dGridIR.CurrentRow.Cells(3).Value.ToString)
            End If
        End With
    End Sub

    Private Sub dGridCounselling_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridCounselling.RowEnter
        On Error Resume Next
        dgrdDetails.Rows.Clear()
        With dgrdDetails
            If Not (Object.Equals(Convert.ToString(.CurrentRow.Cells(3).Value), "")) Then
                .Rows.Add(dGridCounselling.CurrentRow.Cells(3).Value.ToString)
            End If
        End With
    End Sub

    Private Sub dGridGrievances_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridGrievances.RowEnter
        On Error Resume Next
        dgrdDetails.Rows.Clear()
        With dgrdDetails
            If Not (Object.Equals(Convert.ToString(.CurrentRow.Cells(3).Value), "")) Then
                .Rows.Add(dGridGrievances.CurrentRow.Cells(3).Value.ToString)
            End If
        End With
    End Sub

    Private Sub kryptonContextMenuItem1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles kryptonContextMenuItem1.Click
        'Personal information
        Dim arrPrintDetails As New ArrayList
        Dim strLineValues(0 To 3) As String
        strLineValues(0) = UCase(txtEmployeeNo.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtSurname.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(2) = UCase(txtFirstName.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(txtOtherNames.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print title and maiden name
        strLineValues(0) = "TITLE |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(cboTitle.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "MAIDEN NAME|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(txtMaidenName.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print id number and gender
        strLineValues(0) = "ID NO. |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtIdNumber.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "GENDER|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(cboGender.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print address
        strLineValues(0) = "ADDRESS |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAddress1.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAddress2.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAddress3.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAddress4.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print telephone number
        strLineValues(0) = "TELEPHONE |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(mtxtTelephone.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print cellphone number
        strLineValues(0) = "CELLPHONE |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(mtxtCellphone.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print email address
        strLineValues(0) = "EMAIL |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtEmailAddress.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print clock number
        strLineValues(0) = "CLOCK NO. |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtClockNo.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Assign the print data to the print array
        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        GeneralPrint(strPrintDetails, 4, "EC. NO|LAST NAME|FIRST NAME|OTHER NAMES", "100|120|120|310", "YES|YES|YES|YES", "Employee Main Details", strCompanyName, "EMPLOYEE PERSONAL DETAILS", "")

    End Sub

    Private Sub kryptonContextMenuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles kryptonContextMenuItem2.Click
        'Contact information
        Dim arrPrintDetails As New ArrayList
        Dim strLineValues(0 To 3) As String
        strLineValues(0) = UCase(txtEmployeeNo.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtSurname.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(2) = UCase(txtFirstName.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(txtOtherNames.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print the detail header and draw a line after
        strLineValues(0) = "CONTACT DETAILS|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))


        strLineValues(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print contact name and relationship
        strLineValues(0) = "CONTACT NAME |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtContactPerson.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "RELATIONSHIP|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(txtRelationship.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print address
        strLineValues(0) = "ADDRESS |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtConAddress1.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtConAddress2.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtConAddress3.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtConAddress4.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print contact telephone number
        strLineValues(0) = "TELEPHONE |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtContactTelephone.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print contact cellphone number
        strLineValues(0) = "CELLPHONE |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtContactCellphone.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print contact email address
        strLineValues(0) = "EMAIL |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtContactEmailAddress.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))


        '
        'GET THE DEPENDENTS INFORMATION
        '

        If Me.dGridDependents.Rows.Count > 0 Then

            strLineValues(0) = "DEPENDENTS|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
            arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

            strLineValues(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
            arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

            For i As Integer = 0 To dGridDependents.Rows.Count - 1
                strDependentIdNumber = Me.dGridDependents.Rows(i).Cells(1).Value
                strDependentGivenNames = Me.dGridDependents.Rows(i).Cells(2).Value
                strBirthDate = Me.dGridDependents.Rows(i).Cells(3).Value
                strDependentCode = Me.dGridDependents.Rows(i).Cells(4).Value

                strLineValues(0) = Format(CInt(strDependentCode), "000") & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
                strLineValues(1) = strDependentGivenNames & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
                strLineValues(2) = strBirthDate & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
                strLineValues(3) = strDependentIdNumber & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
                arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))
            Next

            'Leave a blank line before moving to next data range

            strLineValues(0) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(1) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(2) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(3) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
            arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        End If

        'Assign the print data to the print array
        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        GeneralPrint(strPrintDetails, 4, "EC. NO|LAST NAME|FIRST NAME|OTHER NAMES", "100|120|120|310", "YES|YES|YES|YES", "Employee Contact Details", strCompanyName, "EMPLOYEE CONTACT DETAILS", "")

        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee contacts and dependents data fetch failure"
        ShowErrorMessage()
    End Sub

    Private Sub kryptonContextMenuItem3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles kryptonContextMenuItem3.Click
        'Banking information
        Dim arrPrintDetails As New ArrayList
        Dim strLineValues(0 To 3) As String
        strLineValues(0) = UCase(txtEmployeeNo.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtSurname.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(2) = UCase(txtFirstName.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(txtOtherNames.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print the detail header and draw a line after
        strLineValues(0) = "BANK/TAX DETAILS|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))


        strLineValues(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print payment method and bank name
        strLineValues(0) = "PAY METHOD |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(cboPaymentMethod.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "BANK|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(lblBankCode.Text & "-" & cboBankCodes.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print Account number
        strLineValues(0) = "ACCOUNT NO. |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAccountNumber.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "ACCOUNT TYPE|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(cboAccountType.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print account owner
        strLineValues(0) = "ACCOUNT HOLDER|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAccountOwner.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print tax code, dependents, reference number
        strLineValues(0) = "TAX CODE|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtTaxCode.Text & "-" & txtTaxDependents.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "TAX NUMBER|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(txtTaxReference.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print Directives
        strLineValues(0) = "DIRECTIVE $|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(Format(CDbl(txtTaxDiirectiveAmt.Text), "##0.00")) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "DIRECTIVE %|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(Format(CDbl(txtTaxDirectivePercent.Text), "##0.00")) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Assign the print data to the print array
        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        GeneralPrint(strPrintDetails, 4, "EC. NO|LAST NAME|FIRST NAME|OTHER NAMES", "100|120|120|310", "YES|YES|YES|YES", "Employee Contact Details", strCompanyName, "EMPLOYEE CONTACT DETAILS", "")

    End Sub

    Private Sub KryptonContextMenuItem4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonContextMenuItem4.Click
        'Employment Information

    End Sub

    Private Sub KryptonContextMenuItem5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonContextMenuItem5.Click
        'Flags, dates and Reference Info

    End Sub

    Private Sub KryptonContextMenuItem6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonContextMenuItem6.Click
        'Salary Info

    End Sub

    Private Sub KryptonContextMenuItem10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonContextMenuItem10.Click
        'Leave Info

    End Sub

    Private Sub KryptonContextMenuItem7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonContextMenuItem7.Click
        'Current Payslip

    End Sub

    Private Sub KryptonContextMenuItem8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonContextMenuItem8.Click
        'Notes 

    End Sub

    Private Sub KryptonContextMenuItem11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonContextMenuItem11.Click
        'Training and Development

    End Sub

    Private Sub KryptonContextMenuItem12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonContextMenuItem12.Click
        'Industrial Relations

    End Sub

    Private Sub GeneralPrint(ByVal strPrintDetails() As String, ByVal ColumnCount As Int16, ByVal strColumnHeaders As String,
            ByVal strColumnWidths As String, ByVal strColumnVisible As String, ByVal Footer As String, ByVal MainHeader As String,
            ByVal Header2 As String, ByVal Header3 As String)
        On Error GoTo RaiseErr
        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = ColumnCount
            .strColumnHeaders = UCase(strColumnHeaders)
            .strColumnWidths = strColumnWidths
            .strFooterCaption = Footer
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = Header2
            .strMainHeader3 = Header3
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
            .VerticalLines = False
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .HeaderFont = New Font("Verdana", 10, FontStyle.Bold)
            .FooterFont = New Font("Verdana", 6, FontStyle.Bold)
            .boolGenericReport = False
            .strPrintValues = strPrintDetails
            .VisibleColumns = strColumnVisible
            .DetailColor = Color.Black
            .DetailFont = fntDetailsFont
        End With
        Cursor = Cursors.Default
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On employee data print"
    End Sub

    Private Sub KryptonContextMenuItem9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonContextMenuItem9.Click
        'If Not String.IsNullOrEmpty(txtEmployeeNo.Text) Then
        '    boolAbort = False
        '    PrintFullMasterFileDetails(txtEmployeeNo.Text)
        '    If boolAbort = True Then
        '        Cursor = Cursors.Default
        '        Exit Sub
        '    End If
        '    GenerateMasterFileReport()
        '    Cursor = Cursors.Default
        'End If

        'Personal information
        Dim arrPrintDetails As New ArrayList
        Dim strLineValues(0 To 3) As String
        strLineValues(0) = UCase(txtEmployeeNo.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtSurname.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(2) = UCase(txtFirstName.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(txtOtherNames.Text) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print title and maiden name
        strLineValues(0) = "TITLE |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(cboTitle.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "MAIDEN NAME|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(txtMaidenName.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print id number and gender
        strLineValues(0) = "ID NO. |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtIdNumber.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "GENDER|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(cboGender.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print address
        strLineValues(0) = "ADDRESS |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAddress1.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAddress2.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAddress3.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAddress4.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print telephone number
        strLineValues(0) = "TELEPHONE |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(mtxtTelephone.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print cellphone number
        strLineValues(0) = "CELLPHONE |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(mtxtCellphone.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print email address
        strLineValues(0) = "EMAIL |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtEmailAddress.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print clock number
        strLineValues(0) = "CLOCK NO. |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtClockNo.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Leave a blank line before moving to next data range

        strLineValues(0) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        '********************************** CONTACTS INFORMATION ********************************************************************

        'Leave a blank line after range header

        strLineValues(0) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print the detail header and draw a line after
        strLineValues(0) = "CONTACT DETAILS|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))


        strLineValues(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print contact name and relationship
        strLineValues(0) = "CONTACT NAME |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtContactPerson.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "RELATIONSHIP|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(txtRelationship.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print address
        strLineValues(0) = "ADDRESS |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtConAddress1.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtConAddress2.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtConAddress3.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtConAddress4.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print contact telephone number
        strLineValues(0) = "TELEPHONE |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtContactTelephone.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print contact cellphone number
        strLineValues(0) = "CELLPHONE |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtContactCellphone.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print contact email address
        strLineValues(0) = "EMAIL |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtContactEmailAddress.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Leave blank line before proceeding to next section
        strLineValues(0) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        '
        'GET THE DEPENDENTS INFORMATION
        '

        If Me.dGridDependents.Rows.Count > 0 Then

            strLineValues(0) = "DEPENDENTS|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
            arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

            strLineValues(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
            arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

            For i As Integer = 0 To dGridDependents.Rows.Count - 1
                strDependentIdNumber = Me.dGridDependents.Rows(i).Cells(1).Value
                strDependentGivenNames = Me.dGridDependents.Rows(i).Cells(2).Value
                strBirthDate = Me.dGridDependents.Rows(i).Cells(3).Value
                strDependentCode = Me.dGridDependents.Rows(i).Cells(4).Value

                strLineValues(0) = Format(CInt(strDependentCode), "000") & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
                strLineValues(1) = strDependentGivenNames & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
                strLineValues(2) = strBirthDate & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
                strLineValues(3) = strDependentIdNumber & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
                arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))
            Next

            'Leave a blank line before moving to next data range

            strLineValues(0) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(1) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(2) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
            strLineValues(3) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
            arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        End If

        '
        'PRINT BANKING AND TAX INFORMATION
        '

        'Print the detail header and draw a line after
        strLineValues(0) = "BANK/TAX DETAILS|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))


        strLineValues(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print payment method and bank name
        strLineValues(0) = "PAY METHOD |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(cboPaymentMethod.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "BANK|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(lblBankCode.Text & "-" & cboBankCodes.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print Account number
        strLineValues(0) = "ACCOUNT NO. |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAccountNumber.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "ACCOUNT TYPE|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(cboAccountType.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print account owner
        strLineValues(0) = "ACCOUNT HOLDER|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAccountOwner.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print tax code, dependents, reference number
        strLineValues(0) = "TAX CODE|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtTaxCode.Text & "-" & txtTaxDependents.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "TAX NUMBER|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(txtTaxReference.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print Directives
        strLineValues(0) = "DIRECTIVE $|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(Format(CDbl(txtTaxDiirectiveAmt.Text), "##0.00")) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "DIRECTIVE %|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(Format(CDbl(txtTaxDirectivePercent.Text), "##0.00")) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))


        'Assign the print data to the print array
        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        GeneralPrint(strPrintDetails, 4, "EC. NO|LAST NAME|FIRST NAME|OTHER NAMES", "100|120|120|310", "YES|YES|YES|YES", "Employee Full Details", strCompanyName, "EMPLOYEE FULL DETAILS", "")

    End Sub

    Private Sub btnNewEmployment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewEmployment.Click
        If String.IsNullOrEmpty(txtEmployeeNo.Text) Then
            MessageBox.Show("Please enter the employee no details first", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtEmployeeNo.Focus()
            Exit Sub
        End If
        'boolInProcessMode = True
        SaveEmployeeData()
        If boolAbort = True Then Exit Sub
        boolEditStatusTwo = False
        Dim f As New frmPersonnelPastEmployers
        f.ShowDialog()
        'boolInProcessMode = False
        LoadEmploymentData()
    End Sub

    Private Sub btnEditEmployment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditEmployment.Click
        If String.IsNullOrEmpty(txtEmployeeNo.Text) Then
            MessageBox.Show("Please enter the employee details first", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtEmployeeNo.Focus()
            Exit Sub
        End If
        'boolInProcessMode = True
        SaveEmployeeData()
        If boolAbort = True Then Exit Sub
        boolEditStatusTwo = True
        intSelectedTransaction = CInt(dGridEmployment.CurrentRow.Cells(0).Value.ToString)
        Dim f As New frmPersonnelPastEmployers
        f.ShowDialog()
        'boolInProcessMode = False
        LoadEmploymentData()
    End Sub

    Private Sub LoadEmploymentData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM EmployeeEmploymentHistory WHERE EmployeeNo = '" & strPublicEmployeeId & "' ORDER BY Status DESC"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim n As Double = 0
        dGridEmployment.Rows.Clear()
        While objReader.Read
            With dGridEmployment
                .Rows.Add(1)
                If Not IsDBNull(objReader("TransactionId").ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader("TransactionId").ToString
                If Not IsDBNull(objReader("Employer").ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader("Employer").ToString
                If Not IsDBNull(objReader("JobTitle").ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader("JobTitle").ToString
                If IsDate(objReader("DateFrom").ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = Format(CDate(objReader("DateFrom").ToString), "dd-MM-yyyy")
                If IsDate(objReader("DateTo").ToString) Then .Rows(.Rows.Count - 1).Cells(4).Value = Format(CDate(objReader("DateTo").ToString), "dd-MM-yyyy")
                If IsNumeric(objReader("AverageSalary").ToString) Then .Rows(.Rows.Count - 1).Cells(5).Value = Format(CDbl(objReader("AverageSalary").ToString), "#,##0.00")
            End With
        End While
        AlternateColors(dGridEmployment)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employment history details Load"
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

    Private Sub btnAddJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddJob.Click
        boolEditStatusTwo = False
        Dim f As New frmJobProfiles
        f.ShowDialog()
        LoadWorkStructures()
    End Sub

    Private Sub btnAddDepartment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDepartment.Click
        boolEditStatusTwo = False
        Dim f As New frmDepartmentsSetup
        f.ShowDialog()
        LoadWorkStructures()
    End Sub

    Private Sub btnAddPaypoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPaypoint.Click
        boolEditStatusTwo = False
        Dim f As New frmPaypointSetup
        f.ShowDialog()
        LoadWorkStructures()
    End Sub

    Private Sub btnAddCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCostCenter.Click
        boolEditStatusTwo = False
        Dim f As New frmCostCenterSetup
        f.ShowDialog()
        LoadWorkStructures()
    End Sub

    Private Sub frmEmployeeDetails_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Width = 824 : Me.Height = 588
    End Sub

    Private Function CheckRecordExistence(ByVal EmployeeNumber As String) As Boolean
        Dim boolReturn As Boolean = False
        'Check that the employee actually exists and that the employee has not been terminated
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT EmployeeNo FROM EmployeeMaster " _
            & "WHERE EmployeeNo = '" & EmployeeNumber & "'", cnn)
        Dim objReadData As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objReadData.HasRows Then
            boolReturn = True
        End If
        objReadData.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "New employee number existence check"
        ShowErrorMessage()
    End Function

    Private Sub dgrdEducation_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrdEducation.CellContentClick

    End Sub
End Class
