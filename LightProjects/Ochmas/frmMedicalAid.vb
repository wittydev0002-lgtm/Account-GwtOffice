Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMedicalAid

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtRegNumber.Text.Length) Then
            MsgBox("Please enter the registration number and should not begin with spaces", MsgBoxStyle.Exclamation, "Invalid Registration Number")
            txtRegNumber.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtName.Text.Length) Then
            MsgBox("Please enter the scheme name and should not begin with spaces", MsgBoxStyle.Exclamation, "Invalid Scheme Name")
            txtName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboSchemeType.Text) Then
            MsgBox("Please select the scheme type from a list of given values", MsgBoxStyle.Exclamation, "Invalid Scheme Type")
            cboSchemeType.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MsgBox("Please enter the scheme address and should not begin with spaces", MsgBoxStyle.Exclamation, "Invalid Scheme Address")
            txtAddress1.Focus()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim dbCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = True Then
            strSql = "UPDATE OchmasSystemMedicalAids SET Name = '" & txtName.Text & "', RegistrationDate = '" & dpRegDate.Text & "', " _
                & "SchemeType = '" & cboSchemeType.Text & "', PostalAddress1 = '" & txtAddress1.Text & "', Telephone = '" & txtTelephone.Text & "', " _
                & "SwitchCode = '" & txtSwitchCode.Text & "', Administrator = '" & txtAdministrator.Text & "', " _
                & "AdministratorTelephone = '" & txtAdminTelephone.Text & "', PostalAddress2 = '" & txtAddress2.Text & "', " _
                & "PostalAddress3 = '" & txtAddress3.Text & "', PostalAddress4 = '" & txtAddress4.Text & "', " _
                & "EmailAddress = '" & txtEmailAddress.Text & "' WHERE RegistrationNumber = '" & txtRegNumber.Text & "'"
        Else
            strSql = "INSERT INTO OchmasSystemMedicalAids (SwitchCode, Name, RegistrationDate, SchemeType, " _
                & "PostalAddress1, PostalAddress2, PostalAddress3, PostalAddress4, Telephone, Administrator, " _
                & "AdministratorTelephone, RegistrationNumber, EmailAddress) VALUES " _
                & "('" & txtSwitchCode.Text & "', '" & txtName.Text & "', '" & dpRegDate.Text & "', '" & cboSchemeType.Text & "', " _
                & "'" & txtAddress1.Text & "', '" & txtAddress2.Text & "', '" & txtAddress3.Text & "', '" & txtAddress4.Text & "', " _
                & "'" & txtTelephone.Text & "', '" & txtAdministrator.Text & "', '" & txtAdminTelephone.Text & "', " _
                & "'" & txtRegNumber.Text & "', '" & txtEmailAddress.Text & "')"
        End If
        dbCommand = New OleDb.OleDbCommand(strSql, cnn)
        dbCommand.ExecuteNonQuery()
        MsgBox("Medical Aid Details Updated Successfully", MsgBoxStyle.Information, "Medical Aid Details Update Success")
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM OchmasSystemMedicalAids WHERE RegistrationNumber = '" & strSelectedMedicalScheme & "'"
        Dim dbCommand As New OleDb.OleDbCommand(strSql, cnn)
        Dim dbReader As OleDb.OleDbDataReader = dbCommand.ExecuteReader
        While dbReader.Read
            If Not IsDBNull(dbReader("RegistrationNumber").ToString) Then txtRegNumber.Text = dbReader("RegistrationNumber").ToString
            If Not IsDBNull(dbReader("Name").ToString) Then txtName.Text = dbReader("Name").ToString
            If Not IsDBNull(dbReader("RegistrationDate").ToString) Then dpRegDate.Value = CDate(dbReader("RegistrationDate").ToString)
            If Not IsDBNull(dbReader("SchemeType").ToString) Then cboSchemeType.Text = dbReader("SchemeType").ToString
            If Not IsDBNull(dbReader("PostalAddress1").ToString) Then txtAddress1.Text = dbReader("PostalAddress1").ToString
            If Not IsDBNull(dbReader("PostalAddress2").ToString) Then txtAddress2.Text = dbReader("PostalAddress2").ToString
            If Not IsDBNull(dbReader("PostalAddress3").ToString) Then txtAddress3.Text = dbReader("PostalAddress3").ToString
            If Not IsDBNull(dbReader("PostalAddress4").ToString) Then txtAddress4.Text = dbReader("PostalAddress4").ToString
            If Not IsDBNull(dbReader("Telephone").ToString) Then txtTelephone.Text = dbReader("Telephone").ToString
            If Not IsDBNull(dbReader("AdministratorTelephone").ToString) Then txtAdminTelephone.Text = dbReader("AdministratorTelephone").ToString
            If Not IsDBNull(dbReader("EmailAddress").ToString) Then txtEmailAddress.Text = dbReader("EmailAddress").ToString
            If Not IsDBNull(dbReader("Administrator").ToString) Then txtAdministrator.Text = dbReader("Administrator").ToString
            If Not IsDBNull(dbReader("AdministratorTelephone").ToString) Then txtAdminTelephone.Text = dbReader("AdministratorTelephone").ToString
            If Not IsDBNull(dbReader("SwitchCode").ToString) Then txtSwitchCode.Text = dbReader("SwitchCode").ToString
        End While
        dbReader.Close()
        txtRegNumber.Enabled = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmMedicalAid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then
            LoadDetails()
        End If
    End Sub

End Class
