Public Class frmOrganisation

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If Me.txtCoyName.Text = "" Or Mid(txtCoyName.Text, 1, 1) = " " Then
            MessageBox.Show("Please enter a valid name for company. No spaces or names begining with spaces", _
                "Invalid Company Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCoyName.Focus()
            Exit Sub
        End If
        If txtAddress1.Text = "" Or Mid(txtAddress1.Text, 1, 1) = " " Then
            MessageBox.Show("Please enter a valid address for the company. No spaces or addresses begining with spaces", _
                "Invalid Address Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If

        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim myCommand As New Data.OleDb.OleDbCommand("DELETE FROM Company", cnn)
        myCommand.ExecuteNonQuery()
        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO Company (CompanyName, Address1, " _
            & "Address2, Address3, Address4, Telephone, " _
            & "FaxNumber, EmailAddress, ContactPerson, ContactCell, ExpiryDays) VALUES " _
            & "('" & txtCoyName.Text & "', '" & txtAddress1.Text & "', '" & txtAddress2.Text & "', " _
            & "'" & txtAddress3.Text & "', '" & txtAddress4.Text & "', '" & txtTelephone.Text & "', " _
            & "'" & txtFaxNumber.Text & "', '" & txtEmailAddress.Text & "', '" & txtContactPerson.Text & "', " _
            & "'" & txtCellphone.Text & "', " & CInt(txtPassDays.Text) & ")", cnn)
        myCommand.ExecuteNonQuery()
        AssignCompanyDetails()
        Cursor = Cursors.Default
        MessageBox.Show("Organisation Details Saved Successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Company Details Maintenance"
        ShowErrorMessage()
    End Sub

    Private Sub frmOrganisation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim myCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Company", cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
        While dbReader.Read
            If Not IsDBNull(dbReader("CompanyName").ToString) Then txtCoyName.Text = dbReader("CompanyName").ToString Else txtCoyName.Text = ""
            If Not IsDBNull(dbReader("Address1").ToString) Then txtAddress1.Text = dbReader("Address1").ToString Else txtAddress1.Text = ""
            If Not IsDBNull(dbReader("Address2").ToString) Then txtAddress2.Text = dbReader("Address2").ToString Else txtAddress2.Text = ""
            If Not IsDBNull(dbReader("Address3").ToString) Then txtAddress3.Text = dbReader("Address3").ToString Else txtAddress3.Text = ""
            If Not IsDBNull(dbReader("Address4").ToString) Then txtAddress4.Text = dbReader("Address4").ToString Else txtAddress4.Text = ""
            If Not IsDBNull(dbReader("Telephone").ToString) Then txtTelephone.Text = dbReader("Telephone").ToString Else txtTelephone.Text = ""
            If Not IsDBNull(dbReader("ContactCell").ToString) Then txtCellphone.Text = dbReader("ContactCell").ToString Else txtCellphone.Text = ""
            If Not IsDBNull(dbReader("FaxNumber").ToString) Then txtFaxNumber.Text = dbReader("FaxNumber").ToString Else txtFaxNumber.Text = ""
            If Not IsDBNull(dbReader("ContactPerson").ToString) Then txtContactPerson.Text = dbReader("ContactPerson").ToString Else txtContactPerson.Text = ""
            If Not IsDBNull(dbReader("EmailAddress").ToString) Then txtEmailAddress.Text = dbReader("EmailAddress").ToString Else txtEmailAddress.Text = ""
            If IsNumeric(dbReader("ExpiryDays").ToString) Then txtPassDays.Text = dbReader("ExpiryDays").ToString Else txtPassDays.Text = ""
        End While
        dbReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Company Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub txtPassDays_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassDays.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            btnOk.Select()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

End Class
