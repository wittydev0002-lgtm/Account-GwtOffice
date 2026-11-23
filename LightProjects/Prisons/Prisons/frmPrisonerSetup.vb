Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPrisonerSetup

    Private Sub frmPrisonerSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then
            LoadData()
        End If
        txtPrisonNumber.Enabled = False
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM Prisoners WHERE PrisonNumber = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("PrisonNumber").ToString) Then txtPrisonNumber.Text = objReader("PrisonNumber").ToString
            If Not IsDBNull(objReader("LastName").ToString) Then txtLastName.Text = objReader("LastName").ToString
            If Not IsDBNull(objReader("FirstName").ToString) Then txtFirstName.Text = objReader("FirstName").ToString
            If Not IsDBNull(objReader("OtherNames").ToString) Then txtOtherNames.Text = objReader("OtherNames").ToString
            If Not IsDBNull(objReader("IdNumber").ToString) Then txtIdNumber.Text = objReader("IdNumber").ToString
            If IsDate(objReader("BirthDate").ToString) Then dpBirthDate.Value = CDate(objReader("BirthDate").ToString)
            If Not IsDBNull(objReader("MaritalStatus").ToString) Then cboMaritalStatus.Text = objReader("MaritalStatus").ToString
            If Not IsDBNull(objReader("Gender").ToString) Then cboGender.Text = objReader("Gender").ToString
            If Not IsDBNull(objReader("Address").ToString) Then txtAddress.Text = objReader("Address").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtPatientTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtPatientEmailAddress.Text = objReader("EmailAddress").ToString
            If IsDate(objReader("DateIn").ToString) Then dtIn.Value = CDate(objReader("DateIn").ToString)
            If IsDate(objReader("DateOut").ToString) Then dtOut.Value = CDate(objReader("DateOut").ToString)
            If Not IsDBNull(objReader("Offence").ToString) Then txtOffence.Text = objReader("Offence").ToString
            If Not IsDBNull(objReader("Sentence").ToString) Then txtSentence.Text = objReader("Sentence").ToString
            If Not IsDBNull(objReader("Remarks").ToString) Then txtNotes.Text = objReader("Remarks").ToString

        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Prisoner Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String
        If boolEditStatus = False Then
            strSql = "INSERT INTO Prisoners (LastName, FirstName, OtherNames, BirthDate, " _
                & "MaritalStatus, Gender, Address, Telephone, EmailAddress, DateIn, DateOut, " _
                & "Offence, Sentence, Remarks, IdNumber) VALUES ('" & txtLastName.Text & "', '" & txtFirstName.Text & "', " _
                & "'" & txtOtherNames.Text & "', '" & Format(CDate(dpBirthDate.Value), "dd-MMM-yyyy") & "', " _
                & "'" & cboMaritalStatus.Text & "', '" & cboGender.Text & "', '" & txtAddress.Text & "', " _
                & "'" & txtPatientTelephone.Text & "', '" & txtPatientEmailAddress.Text & "', '" & Format(CDate(dtIn.Value), "dd-MMM-yyyy") & "', " _
                & "'" & Format(CDate(dtOut.Value), "dd-MMM-yyyy") & "', '" & txtOffence.Text & "', " & txtSentence.Text & ", " _
                & "'" & txtNotes.Text & "', '" & txtIdNumber.Text & "')"
        Else
            strSql = "UPDATE Prisoners SET LastName = '" & txtLastName.Text & "', " _
                & "FirstName = '" & txtFirstName.Text & "', OtherNames = '" & txtOtherNames.Text & "', " _
                & "BirthDate = '" & Format(CDate(dpBirthDate.Value), "dd-MMM-yyyy") & "', " _
                & "MaritalStatus = '" & cboMaritalStatus.Text & "', Gender = '" & cboGender.Text & "', " _
                & "Address = '" & txtAddress.Text & "', Telephone = '" & txtPatientTelephone.Text & "', " _
                & "EmailAddress = '" & txtPatientEmailAddress.Text & "', " _
                & "DateIn = '" & Format(CDate(dtIn.Value), "dd-MMM-yyyy") & "', " _
                & "DateOut = '" & Format(CDate(dtOut.Value), "dd-MMM-yyyy") & "', Offence = '" & txtOffence.Text & "', " _
                & "Sentence = " & txtSentence.Text & ", Remarks = '" & txtNotes.Text & "', " _
                & "IdNumber = '" & txtIdNumber.Text & "' WHERE PrisonNumber = " & txtPrisonNumber.Text & ""
        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Prisoner details have been updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Prisoner Details save"
        ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtLastName.Text) Then
            MessageBox.Show("Please type in the name", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLastName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtFirstName.Text) Then
            MessageBox.Show("Please type in the name", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirstName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtIdNumber.Text) Then
            MessageBox.Show("Please type in the ID Number", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtIdNumber.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtSentence.Text) Then
            MessageBox.Show("Sentence must be numeric", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSentence.Focus()
            Exit Sub
        End If
        SaveData()
    End Sub

    Private Sub txtSentence_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSentence.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            CalculateRealeseDate()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub CalculateRealeseDate()
        If IsNumeric(txtSentence.Text) Then
            Dim intReleaseMonths As Integer = Remission(CInt(txtSentence.Text))
            If intReleaseMonths > 0 Then
                dtOut.Value = DateAdd(DateInterval.Month, intReleaseMonths, dtIn.Value)
            Else
                dtOut.Value = dtIn.Value
            End If
        End If
    End Sub

    Private Sub txtSentence_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSentence.Validating
        CalculateRealeseDate()
    End Sub

    Private Sub dtIn_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtIn.ValueChanged

    End Sub
End Class