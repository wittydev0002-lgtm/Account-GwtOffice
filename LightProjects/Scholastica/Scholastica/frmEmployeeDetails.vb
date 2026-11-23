Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmEmployeeDetails

    Dim strInitialDateValue As String = Nothing
    Dim strActivityStatus As String = Nothing
    Dim _originalSplitterDistance As Integer
    Dim strBirthDate As String = Nothing
    Dim strHireDate As String = Nothing
    Dim strDischargeDate As String = Nothing
    Dim strMedaidDate As String = Nothing
    Dim strPensionDate As String = Nothing

    Private Sub LoadClasses()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT (ClassName) FROM SC_Classes " _
            & "ORDER BY (ClassName)", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboClass.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Class Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmEmployeeDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'load the banks
        LoadClasses()
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
        Dim strSql As String = "INSERT INTO EmployeeMaster (EmployeeNo, LastName, " _
            & "FirstName, OtherNames, IdNumber, Gender, BirthDate, MaritalStatus, " _
            & "Address1, Address2, Address3, Address4,Telephone,Cellphone,EmailAddress, " _
            & "ClockNo, DirAmt, DirPercent, StopFrom, StopTo, TaxCode, TaxDependents, " _
            & "TaxRef, Title, Inits, Status, EmployeeClass) " _
            & "VALUES ('" & txtEmployeeNo.Text & "', '" & txtSurname.Text & "', " _
            & "'" & txtFirstName.Text & "','" & txtOtherNames.Text & "', " _
            & "'" & txtIdNumber.Text & "','" & cboGender.Text & "', " _
            & "'" & strBirthDate & "','" & cboMaritalStatus.Text & "', " _
            & "'" & txtAddress1.Text & "','" & txtAddress2.Text & "', " _
            & "'" & txtAddress3.Text & "','" & txtAddress4.Text & "', " _
            & "'" & mtxtTelephone.Text & "','" & mtxtCellphone.Text & "', " _
            & "'" & txtEmailAddress.Text & "', 0, " _
            & "'0', '0', 0, 0, 'Z', 0, 'NONE', '" & cboTitle.Text & "', " _
            & "'" & strInits & "', '" & strActivityStatus & "', '" & cboClass.Text & "')"
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

    Private Sub LoadSelectedEmployee()
        On Error GoTo RaiseErr
        If boolEditStatus = False Then txtEmployeeNo.Enabled = True Else txtEmployeeNo.Enabled = False
        If boolDisallowSave = True Then btnOK.Enabled = False
        'If the form load status is edit then open populate the employee codes and other values
        If boolEditStatus = True Then
            PopulateMaster()
            PopulateContacts()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Employee Master Details Load Failure"
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
                    dpBirthDate.Value = CDate(Format(CInt(strBuffer(0)), "00") & "-" & MonthName(CInt(strBuffer(1)), True) & "-" & CInt(strBuffer(2)))
                End If
            End If
            If Not IsDBNull(objReader("Gender").ToString) Then cboGender.Text = objReader("Gender").ToString

            cboMaritalStatus.Text = "Undisclosed"
            If Not IsDBNull(objReader("MaritalStatus").ToString) Then
                If Not String.IsNullOrEmpty(objReader("MaritalStatus").ToString) Then
                    cboMaritalStatus.Text = objReader("MaritalStatus").ToString
                End If
            End If

            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then mtxtTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then mtxtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("DischDate").ToString) Then
                If objReader("DischDate").ToString.Length > 0 Then
                    strBuffer = Split(objReader("DischDate").ToString, "-")
                    dpTermDate.Value = CDate(Format(CInt(strBuffer(0)), "00") & "-" & MonthName(CInt(strBuffer(1)), True) & "-" & CInt(strBuffer(2)))
                End If
            End If
            If Not IsDBNull(objReader("MaidenName").ToString) Then txtMaidenName.Text = objReader("MaidenName").ToString
            If Not IsDBNull(objReader("EmployeeClass").ToString) Then cboClass.Text = objReader("EmployeeClass").ToString
            If Not IsDBNull(objReader("Status").ToString) Then cboStatus.Text = objReader("Status").ToString

        End If
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

        If cboClass.Text = "" Or Mid(cboClass.Text, 1, 1) = " " Then
            MessageBox.Show("Please enter a class", "Invalid Class Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClass.Focus()
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
                & ",DischDate = '" & strDischargeDate & "'" _
                & ",MaidenName = '" & txtMaidenName.Text & "'" _
                & ",EmployeeClass = '" & cboClass.Text & "'" _
                & ",Inits = '" & strInits & "', Status = '" & strActivityStatus & "'" _
                & ",Title = '" & cboTitle.Text & "' " _
                & "WHERE EmployeeNo = '" & txtEmployeeNo.Text & "'"

            sqlCommand = New Data.OleDb.OleDbCommand(strUpdate, cnn)
            sqlCommand.ExecuteNonQuery()
        Else
            boolAbort = False
            InsertMasterRecord()
            If boolAbort = True Then Exit Sub
            InsertContactsRecord()
        End If
        'If boolEditStatus = True Then SaveDates()
        boolAbort = False
        'default to the edit status
        boolEditStatus = True
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
            TabControl1.SelectedTab = TabPage2
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
        txtMaidenName.Clear()
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
        ShowErrorMessage()
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
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On employee data print"
        ShowErrorMessage()
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

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        boolAbort = False
        SaveEmployeeData()
    End Sub

End Class
