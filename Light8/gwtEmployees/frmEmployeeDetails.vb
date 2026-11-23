Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmEmployeeDetails

    Dim strInitialDateValue As String = Nothing
    Dim strActivityStatus As String = Nothing
    Dim _originalSplitterDistance As Integer
    Dim strBirthDate As String = Nothing
    Dim strHireDate As String = Nothing
    Dim strDischargeDate As String = Nothing
    Dim strMedaidDate As String = Nothing
    Dim strPensionDate As String = Nothing
    Dim boolPriorStatus As Boolean

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
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
            & "FROM EmployeeDependents WHERE EmployeeNo = '" & strPublicEmployeeId & "' ORDER BY DependentCode"
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

    Private Sub frmEmployeeDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        LoadEmployeeClasses()
        If boolAbort = True Then Exit Sub
        LoadWorkStructures()
        If boolEditStatus = True Then
            Me.TextExtra = UCase(Mid(strEmployeeLastName, 1, 1)) & LCase(Mid(strEmployeeLastName, 2, (strEmployeeLastName.Length - 1))) & " " _
                & UCase(Mid(strEmployeeFirstName, 1, 1)) & LCase(Mid(strEmployeeFirstName, 2, (strEmployeeFirstName.Length - 1))) & " " &
                strPublicEmployeeId
            txtEmployeeNo.Enabled = False
            LoadSelectedEmployee()
            LoadDependants()
            btnAdd.Enabled = True
            btnEdit.Enabled = True
            btnDelete.Enabled = True

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

            Dim strSelectMasterFields As String = "SELECT SystemMasterFields.OrdinalNo, SystemMasterCodes.Description, EmployeeMasterFields.Amount " _
                & "FROM SystemMasterFields LEFT OUTER JOIN EmployeeMasterFields ON " _
                & "SystemMasterFields.CodeNo = EmployeeMasterFields.OrdinalNo WHERE EmployeeMasterFields.EmployeeNo = '" & strPublicEmployeeId & "'"
            LoadReferenceNumbers()
        End If
        'Get the values prior to any changes
        gwt_comm.MasterDetailsPriorValues(txtEmployeeNo.Text, txtSurname.Text, txtFirstName.Text,
                txtOtherNames.Text, txtIdNumber.Text, dpBirthDate.Text, txtAddress1.Text,
                txtAddress2.Text, txtAddress3.Text, txtAddress4.Text, mtxtTelephone.Text,
                mtxtCellphone.Text, txtEmailAddress.Text, , , , , txtAddress3.Text, , , , "",
                cboMaritalStatus.Text, "", cboGender.Text, cboEmploymentStatus.Text,
                cboPosition.Text, cboDepartment.Text, cboCostCode.Text, cboPaypoint.Text,
                dpHireDate.Text, dpTermDate.Text, , , , , Nothing, Nothing, Nothing, Nothing, Nothing)
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
            & "ClockNo, StopFrom, StopTo, Title, Inits, Status, EmployeeClass) " _
            & "VALUES ('" & txtEmployeeNo.Text & "', '" & txtSurname.Text & "', " _
            & "'" & txtFirstName.Text & "','" & txtOtherNames.Text & "', " _
            & "'" & txtIdNumber.Text & "','" & cboGender.Text & "', " _
            & "'" & strBirthDate & "','" & cboMaritalStatus.Text & "', " _
            & "'" & txtAddress1.Text & "','" & txtAddress2.Text & "', " _
            & "'" & txtAddress3.Text & "','" & txtAddress4.Text & "', " _
            & "'" & mtxtTelephone.Text & "','" & mtxtCellphone.Text & "', " _
            & "'" & txtEmailAddress.Text & "', " & txtClockNo.Text & ", " _
            & "" & txtStopFrom.Text & ", " & txtStopTo.Text & ", " _
            & "'" & cboTitle.Text & "', '" & strInits & "', '" & strActivityStatus & "', '" & cboEmployeeClasses.Text & "')"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Windows.Forms.Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Details Maintenance Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub InsertEmploymentRecord()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        If String.IsNullOrEmpty(lblDepartmentCode.Text) Then lblDepartmentCode.Text = "0"
        If String.IsNullOrEmpty(lblPaypointCode.Text) Then lblPaypointCode.Text = "0"
        'If String.IsNullOrEmpty(lblJobCode.Text) Then lblJobCode.Text = "0"
        If String.IsNullOrEmpty(lblCostCode.Text) Then lblCostCode.Text = "0"
        strSql = "INSERT INTO Employment (EmployeeNo, HireDate, JobTitle, " _
            & "EmploymentStatus, Department, CostCenter, PayPoint, PensionDate, MedaidDate, PensionNo, MedaidNo, " _
            & "DepartmentId, PaypointId, JobCode, CostCodeId) " _
            & "VALUES ('" & txtEmployeeNo.Text & "', '" & strHireDate & "', " _
            & "'" & cboPosition.Text & "', '" & cboEmploymentStatus.Text & "', " _
            & "'" & cboDepartment.Text & "', '" & cboCostCode.Text & "', " _
            & "'" & cboPaypoint.Text & "', '" & strPensionDate & "', " _
            & "'" & strMedaidDate & "', '', '', " & lblDepartmentCode.Text & ", " _
            & "" & lblPaypointCode.Text & ", '" & lblJobCode.Text & "', " & lblCostCode.Text & ")"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Employment Details Insert"
        gwt_comm.ShowErrorMessage()
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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadSelectedEmployee()
        On Error GoTo RaiseErr
        If boolEditStatus = False Then txtEmployeeNo.Enabled = True Else txtEmployeeNo.Enabled = False
        If boolDisallowSave = True Then btnOK.Enabled = False
        'Load the bank codes
        'GetBankFileDetails()

        'If the form load status is edit then open populate the employee codes and other values
        If boolEditStatus = True Then
            boolAbort = False
            PopulateMaster()
            If boolAbort = True Then Exit Sub
            PopulateEmployment()
            If boolAbort = True Then Exit Sub
            LoadReferenceNumbers()
            If boolAbort = True Then Exit Sub
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Employee Master Details Load Failure"
        gwt_comm.ShowErrorMessage()
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
                    dpBirthDate.Value = CDate(Format(CInt(strBuffer(0)), "00") & "-" & gwt_comm.getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
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
            If Not IsDBNull(objReader("DischDate").ToString) Then
                If objReader("DischDate").ToString.Length > 0 Then
                    strBuffer = Split(objReader("DischDate").ToString, "-")
                    dpTermDate.Value = CDate(Format(CInt(strBuffer(0)), "00") & "-" & gwt_comm.getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
                End If
            End If

            If Not IsDBNull(objReader("DischRsn").ToString) Then lblDischReason.Text = objReader("DischRsn").ToString
            If Not IsDBNull(objReader("StopFrom").ToString) Then txtStopFrom.Text = objReader("StopFrom").ToString
            If Not IsDBNull(objReader("StopTo").ToString) Then txtStopTo.Text = objReader("StopTo").ToString
            If Not IsDBNull(objReader("Title").ToString) Then cboTitle.Text = objReader("Title").ToString
            If Not IsDBNull(objReader("Status").ToString) Then cboStatus.Text = objReader("Status").ToString
            If Not IsDBNull(objReader("MaidenName").ToString) Then txtMaidenName.Text = objReader("MaidenName").ToString
            If Not IsDBNull(objReader("EmployeeNotes").ToString) Then txtNotes.Text = objReader("EmployeeNotes").ToString

        End If
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Master Data Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadEmployeeClasses()
        'SystemEmployeeClasses
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT Description FROM " _
            & "SystemEmployeeClasses ORDER BY Description", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboEmployeeClasses.Items.Clear()
        cboEmployeeClasses.Items.Add("-- NONE --")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboEmployeeClasses.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Master Data Load Error"
        gwt_comm.ShowErrorMessage()
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
                    dpHireDate.Value = CDate(strBuffer(0) & "-" & gwt_comm.getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
                End If
            End If

            If Not IsDBNull(objReader("EmploymentStatus").ToString) Then cboEmploymentStatus.SelectedItem = objReader("EmploymentStatus").ToString
            If Not IsDBNull(objReader("JobTitle").ToString) Then cboPosition.Text = objReader("JobTitle").ToString
            If Not IsDBNull(objReader("Department").ToString) Then cboDepartment.Text = objReader("Department").ToString
            If Not IsDBNull(objReader("PayPoint").ToString) Then cboPaypoint.Text = objReader("PayPoint").ToString
            If Not IsDBNull(objReader("CostCenter").ToString) Then cboCostCode.Text = objReader("CostCenter").ToString

        End While
        'Close the file.
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Contact Data Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
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

        If String.IsNullOrEmpty(lblJobCode.Text) Then
            MessageBox.Show("Please select the position title or else create the jobs first", "Invalid Job Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPosition.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(lblCostCode.Text) Then
            MessageBox.Show("Please select the cost center or else create the cost center first", "Invalid Cost Center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCostCode.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(lblDepartmentCode.Text) Then
            MessageBox.Show("Please select the department or else create the departments first", "Invalid Department Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboDepartment.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(lblPaypointCode.Text) Then
            MessageBox.Show("Please select the pay point or else create the pay point first", "Invalid Pay Point Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPaypoint.Select()
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

        'Get the correct date format to the database
        If UCase(strSystemDateFormat) = UCase("English") Then
            strBirthDate = gwt_comm.MediumDate(DatePart(DateInterval.Day, dpBirthDate.Value), DatePart(DateInterval.Month, dpBirthDate.Value), DatePart(DateInterval.Year, dpBirthDate.Value))
            strHireDate = gwt_comm.MediumDate(DatePart(DateInterval.Day, dpHireDate.Value), DatePart(DateInterval.Month, dpHireDate.Value), DatePart(DateInterval.Year, dpHireDate.Value))
            strDischargeDate = gwt_comm.MediumDate(DatePart(DateInterval.Day, dpTermDate.Value), DatePart(DateInterval.Month, dpTermDate.Value), DatePart(DateInterval.Year, dpTermDate.Value))
            'strMedaidDate = MediumDate(DatePart(DateInterval.Day, dpMedaidDate.Value), DatePart(DateInterval.Month, dpMedaidDate.Value), DatePart(DateInterval.Year, dpMedaidDate.Value))
            'strPensionDate = MediumDate(DatePart(DateInterval.Day, dpPensionDate.Value), DatePart(DateInterval.Month, dpPensionDate.Value), DatePart(DateInterval.Year, dpPensionDate.Value))
        End If

        If boolEditStatus = True Then 'the form was opened for edit
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

            Dim strUpdate As String = "UPDATE EmployeeMaster SET LastName = '" & txtSurname.Text & "'" _
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
                & ",DischDate = '" & strDischargeDate & "'" _
                & ",StopFrom = '" & txtStopFrom.Text & "'" _
                & ",MaidenName = '" & txtMaidenName.Text & "'" _
                & ",StopTo = '" & txtStopTo.Text & "'" _
                & ",EmployeeNotes = '" & txtNotes.Text & "'" _
                & ",Inits = '" & strInits & "', Status = '" & strActivityStatus & "'" _
                & ",EmployeeClass = '" & cboEmployeeClasses.Text & "'" _
                & ",Title = '" & cboTitle.Text & "' " _
                & "WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'"

            Dim sqlCommand As New Data.OleDb.OleDbCommand(strUpdate, cnn)
            sqlCommand.ExecuteNonQuery()

            sqlCommand = New Data.OleDb.OleDbCommand("SELECT EmployeeNo FROM Employment WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'", cnn)
            Dim objTestExistence As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
            If objTestExistence.HasRows = False Then
                InsertEmploymentRecord()
            Else
                strUpdate = "UPDATE Employment SET HireDate = '" & strHireDate & "'" _
                    & ",JobTitle = '" & cboPosition.Text & "'" _
                    & ",EmploymentStatus = '" & cboEmploymentStatus.Text & "'" _
                    & ",Department = '" & cboDepartment.Text & "'" _
                    & ",CostCenter = '" & cboCostCode.Text & "'" _
                    & ",PayPoint = '" & cboPaypoint.Text & "', PensionDate = '" & strPensionDate & "', " _
                    & "MedaidDate = '" & strMedaidDate & "', DepartmentId = " & lblDepartmentCode.Text & ", " _
                    & "PaypointId = " & lblPaypointCode.Text & ", JobCode = '" & lblJobCode.Text & "', CostCodeId = " & lblCostCode.Text & ", " _
                    & "PensionNo = '', MedaidNo = ''  " _
                    & "WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'"
                sqlCommand = New Data.OleDb.OleDbCommand(strUpdate, cnn)
                sqlCommand.ExecuteNonQuery()
            End If
            objTestExistence.Close()
        Else
            boolAbort = False
            InsertMasterRecord()
            If boolAbort = True Then Exit Sub
            InsertEmploymentRecord()
            If boolAbort = True Then Exit Sub
        End If
        'If boolEditStatus = True Then SaveDates()
        boolAbort = False
        InsertReferences()
        If boolAbort = True Then Exit Sub
        'default to the edit status
        boolEditStatus = True
        'Update the employee temporary view file
        'UpdateOnelineEmployeeCodes()
        'Update the audit file with the changes
        gwt_comm.MasterChanges(txtEmployeeNo.Text, txtSurname.Text, txtFirstName.Text,
            txtOtherNames.Text, txtIdNumber.Text, strBirthDate, txtAddress1.Text,
            txtAddress2.Text, txtAddress3.Text, txtAddress4.Text, mtxtTelephone.Text,
            mtxtCellphone.Text, txtEmailAddress.Text, , , , , , txtAddress4.Text, , , "", cboMaritalStatus.Text, "", cboGender.Text,
            cboEmploymentStatus.Text, cboPosition.Text, cboDepartment.Text,
            cboCostCode.Text, cboPaypoint.Text, strHireDate, strDischargeDate,
            strPensionDate, , , , Nothing, Nothing,
            Nothing, Nothing, Nothing)
        Cursor = Cursors.Default
        If boolAbort = False Then
            MessageBox.Show("Employee details saved successfully ", "Employee Details Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            boolEditStatus = True
            strPublicEmployeeId = txtEmployeeNo.Text
            'Reload the employee data in edit mode
            txtEmployeeNo.Enabled = False
            LoadSelectedEmployee()
        End If
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & "on Employee Record Save"
        gwt_comm.ShowErrorMessage()
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

    Private Sub mtxtCellphone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mtxtCellphone.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtEmailAddress.Focus()
    End Sub

    Private Sub txtEmailAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailAddress.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then TabControl1.SelectedIndex = 1
    End Sub

    Private Sub dpHireDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dpHireDate.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then cboEmploymentStatus.Focus()
    End Sub

    Private Sub cboEmploymentStatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboEmploymentStatus.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then cboPosition.Focus()
    End Sub

    Private Sub txtPosition_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPosition.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then cboDepartment.Focus()
    End Sub

    Private Sub cboDepartment_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDepartment.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then cboPaypoint.Focus()
    End Sub

    Private Sub cboPaypoint_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPaypoint.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then cboCostCode.Focus()
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
        txtMaidenName.Clear()
        cboEmploymentStatus.Text = ""
        cboPosition.Text = ""
        cboDepartment.Text = ""
        cboPaypoint.Text = ""
        cboCostCode.Text = ""
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManageTransactions.Click
        ClearControls()
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub LoadWorkStructures()
        On Error GoTo RaiseErr

        Dim sqlCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        cboCostCode.Items.Clear()
        cboDepartment.Items.Clear()
        cboPaypoint.Items.Clear()
        cboPosition.Items.Clear()

        Dim intWidth As Integer = cboCostCode.Width - 85

        With cboCostCode
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intWidth) & ";60"
        End With

        With cboDepartment
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intWidth) & ";60"
        End With

        With cboPaypoint
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intWidth) & ";60"
        End With

        With cboPosition
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intWidth) & ";60"
        End With

        Dim arrItems As New ArrayList

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT CostCenterName +'|'+ Convert(NVARCHAR, OrdinalNo) " _
            & "FROM SystemCostCenters ORDER BY CostCenterName", cnn)
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim DropDownItems(arrItems.Count - 1) As MTGCComboBoxItem

        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), "|")
            DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
        Next
        With cboCostCode
            If arrItems.Count > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With

        arrItems = New ArrayList

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT PayPointName +'|'+ " _
            & "Convert(NVARCHAR, OrdinalNo) FROM SystemPayPoints ORDER BY PayPointName", cnn)
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        ReDim DropDownItems(arrItems.Count - 1)

        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), "|")
            DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
        Next
        With cboPaypoint
            If arrItems.Count > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With

        arrItems = New ArrayList

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT DepartmentName +'|'+ " _
            & "Convert(NVARCHAR, OrdinalNo) FROM SystemDepartments ORDER BY DepartmentName", cnn)
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        ReDim DropDownItems(arrItems.Count - 1)

        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), "|")
            DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
        Next
        With cboDepartment
            If arrItems.Count > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With

        arrItems = New ArrayList

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT JobTitle +'|'+ " _
            & "CONVERT(NVARCHAR, JobCode) FROM JobProfiles ORDER BY JobTitle", cnn)
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        ReDim DropDownItems(arrItems.Count - 1)

        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), "|")
            DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
        Next
        With cboPosition
            If arrItems.Count > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Work Structure Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtEmailAddress_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEmailAddress.Validating
        If Not String.IsNullOrEmpty(txtEmailAddress.Text) Then
            If gwt_comm.IsEmailAddress(txtEmailAddress.Text) = False Then
                MessageBox.Show("Please enter a valid email address", "invalid Email Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtEmailAddress.Focus()
                Exit Sub
            End If
        End If
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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboTitle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTitle.SelectedIndexChanged
        If UCase(cboTitle.Text) = "MR" Then
            cboGender.Text = "Male"
        Else
            cboGender.Text = "Female"
        End If
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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPersonalInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
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

    Private Sub PrintFullDetails()

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
        strLineValues(1) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "RELATIONSHIP|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print address
        strLineValues(0) = "ADDRESS |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        strLineValues(0) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print contact telephone number
        strLineValues(0) = "TELEPHONE |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print contact cellphone number
        strLineValues(0) = "CELLPHONE |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print contact email address
        strLineValues(0) = "EMAIL |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = " |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
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

        'Assign the print data to the print array
        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        GeneralPrint(strPrintDetails, 4, "EC. NO|LAST NAME|FIRST NAME|OTHER NAMES", "100|120|120|310", "YES|YES|YES|YES", "Employee Full Details", strCompanyName, "EMPLOYEE FULL DETAILS", "")

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
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartment.SelectedIndexChanged
        lblDepartmentCode.Text = Nothing
        If Not Object.Equals(cboDepartment.SelectedItem, Nothing) Then
            lblDepartmentCode.Text = cboDepartment.SelectedItem.Col2.ToString
        End If
    End Sub

    Private Sub cboPaypoint_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPaypoint.SelectedIndexChanged
        lblPaypointCode.Text = Nothing
        If Not Object.Equals(cboPaypoint.SelectedItem, Nothing) Then
            lblPaypointCode.Text = cboPaypoint.SelectedItem.Col2.ToString
        End If
    End Sub

    Private Sub cboPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPosition.SelectedIndexChanged
        lblJobCode.Text = Nothing
        If Not Object.Equals(cboPosition.SelectedItem, Nothing) Then
            lblJobCode.Text = cboPosition.SelectedItem.Col2.ToString
        End If
    End Sub

    Private Sub cboCostCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCostCode.SelectedIndexChanged
        lblCostCode.Text = Nothing
        If Not Object.Equals(cboCostCode.SelectedItem, Nothing) Then
            lblCostCode.Text = cboCostCode.SelectedItem.Col2.ToString
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub
End Class
