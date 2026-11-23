Public Class frmMembers

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtFirstName.Text) Then
            MessageBox.Show("Please enter the first name", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirstName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtLastName.Text) Then
            MessageBox.Show("Please enter the last name", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLastName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtMemberAddress.Text) Then
            MessageBox.Show("Please enter the member address", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMemberAddress.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboGender.Text) Then
            MessageBox.Show("Please enter the gender", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboGender.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboStatus.Text) Then
            MessageBox.Show("Please enter the member status", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboStatus.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtParentNames.Text) Then
            MessageBox.Show("Please enter the parent/guardian name", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtParentNames.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboRelationship.Text) Then
            MessageBox.Show("Please enter the member parent/guardin relationship", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboRelationship.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtParentAddress.Text) Then
            MessageBox.Show("Please enter the parent/guardian address", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtParentAddress.Focus()
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing
        If boolEditStatus = False Then
            strSql = "INSERT INTO [Members] ([LastName],[FirstName],[OtherNames],[DateOfBirth]," _
                & "[Gender],[Address],[Telephone],[EmailAddress],[Status],[School]," _
                & "[ParentName],[ParentAddress],[ParentTelephone],[Relationships],[Remarks]) VALUES " _
                & "('" & txtLastName.Text & "', '" & txtFirstName.Text & "', '" & txtOtherNames.Text & "', " _
                & "'" & Format(dpBirthDate.Value, "dd-MMM-yyyy") & "', '" & cboGender.Text & "', " _
                & "'" & txtMemberAddress.Text & "', '" & txtMemberTelephone.Text & "', " _
                & "'" & txtMemberEmailAddress.Text & "', '" & cboStatus.Text & "', " _
                & "'" & txtSchool.Text & "', '" & txtParentNames.Text & "', " _
                & "'" & txtParentAddress.Text & "', '" & txtParentTelephone.Text & "', " _
                & "'" & cboRelationship.Text & "', '" & txtNotes.Text & "')"
        Else
            strSql = "UPDATE [Members] SET [LastName] = '" & txtLastName.Text & "', " _
                & "[FirstName] = '" & txtFirstName.Text & "', [OtherNames] = '" & txtOtherNames.Text & "', " _
                & "[DateOfBirth] = '" & Format(dpBirthDate.Value, "dd-MMM-yyyy") & "', " _
                & "[Gender] = '" & cboGender.Text & "', [Address] = '" & txtMemberAddress.Text & "', " _
                & "[Telephone] = '" & txtMemberTelephone.Text & "', [EmailAddress] = '" & txtMemberEmailAddress.Text & "', " _
                & "[Status] = '" & cboStatus.Text & "', [School] = '" & txtSchool.Text & "', " _
                & "[ParentName] = '" & txtParentNames.Text & "', [ParentAddress] = '" & txtParentAddress.Text & "', " _
                & "[ParentTelephone] = '" & txtParentTelephone.Text & "', [Relationships] = '" & cboRelationship.Text & "', " _
                & "[Remarks] = '" & txtNotes.Text & "' WHERE MembershipId = '" & txtMemberId.Text & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Member record has been updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Errors encounted while trying to update member information"
        ShowErrorMessage()
    End Sub

    Private Sub frmMembers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtMemberId.Enabled = False
        cboStatus.Enabled = False
        cboStatus.Text = "ACTIVE"
        If boolEditStatus = True Then
            LoadData()
            LoadTransactionHistory()
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT * FROM Members WHERE MembershipId = " & intSelectedRecord & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("MembershipId").ToString) Then txtMemberId.Text = objReader("MembershipId").ToString
            If Not IsDBNull(objReader("LastName").ToString) Then txtLastName.Text = objReader("LastName").ToString
            If Not IsDBNull(objReader("FirstName").ToString) Then txtFirstName.Text = objReader("FirstName").ToString
            If Not IsDBNull(objReader("OtherNames").ToString) Then txtOtherNames.Text = objReader("OtherNames").ToString
            If IsDate(objReader("DateOfBirth").ToString) Then dpBirthDate.Value = CDate(objReader("DateOfBirth").ToString)
            If Not IsDBNull(objReader("Address").ToString) Then txtMemberAddress.Text = objReader("Address").ToString
            If Not IsDBNull(objReader("Gender").ToString) Then cboGender.Text = objReader("Gender").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtMemberEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("Status").ToString) Then cboStatus.Text = objReader("Status").ToString
            If Not IsDBNull(objReader("School").ToString) Then txtSchool.Text = objReader("School").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtMemberTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("ParentName").ToString) Then txtParentNames.Text = objReader("ParentName").ToString
            If Not IsDBNull(objReader("ParentAddress").ToString) Then txtParentAddress.Text = objReader("ParentAddress").ToString
            If Not IsDBNull(objReader("ParentTelephone").ToString) Then txtParentTelephone.Text = objReader("ParentTelephone").ToString
            If Not IsDBNull(objReader("Relationships").ToString) Then cboRelationship.Text = objReader("Relationships").ToString
            If Not IsDBNull(objReader("Remarks").ToString) Then txtNotes.Text = objReader("Remarks").ToString
        End If
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Errors encounted while trying to update load information"
        ShowErrorMessage()
    End Sub

    Private Sub LoadTransactionHistory()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), BorrowingsOut.DateOut, 106), ' ', '-')) AS [DateOut], " _
            & "Books.Title, Books.Author, Books.YearPublished, UPPER(REPLACE(CONVERT(CHAR(11), " _
            & "BorrowingsOut.DateDue, 106), ' ', '-')) AS [DateDue], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), BorrowingsIn.DateIn, 106), ' ', '-')) AS [DateIn], " _
            & "Datediff(d, BorrowingsOut.DateDue, GetDate()) AS [Dys], BorrowingsOut.TransactionId FROM BorrowingsOut " _
            & "LEFT OUTER JOIN Books ON BorrowingsOut.Isbn = Books.ISBN " _
            & "LEFT OUTER JOIN BorrowingsIn ON BorrowingsOut.Isbn = BorrowingsIn.Isbn " _
            & "WHERE BorrowingsOut.MembershipId = " & intSelectedRecord & " ORDER BY BorrowingsOut.DateOut DESC"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader("DateOut"), objReader("Title"), _
                objReader("Author"), objReader("YearPublished"), objReader("DateDue"), _
                objReader("DateIn"), objReader("TransactionId"))
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Errors encounted while trying to update load information"
        ShowErrorMessage()
    End Sub

End Class
