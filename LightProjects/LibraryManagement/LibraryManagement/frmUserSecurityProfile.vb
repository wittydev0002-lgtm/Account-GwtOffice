Public Class frmUserSecurityProfile

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        'Check that the user given names have been entered as well
        If String.IsNullOrEmpty(txtGivenNames.Text) Then
            MessageBox.Show("Please enter the user's given names", "Missing Given Names", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGivenNames.Focus()
            Exit Sub
        End If
        
        If txtConfirmPassword.Text <> txtUserPassword.Text Then
            MessageBox.Show("The confirmed password differs from the password", "Password Inconsistence", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUserPassword.Focus()
            txtUserPassword.SelectAll()
            Exit Sub
        End If
        'check that the other fields have been entered
        If txtUserName.Text = "" Or Mid(txtUserName.Text, 1, 1) = " " _
        Or txtUserPassword.Text = "" Or Mid(txtUserPassword.Text, 1, 1) = " " _
        Or txtConfirmPassword.Text = "" Or Mid(txtConfirmPassword.Text, 1, 1) = " " Then
            MessageBox.Show("One or more of the mandatory fields is missing. Please re-enter", "Missing Mandatory Data Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUserName.Focus()
            Exit Sub
        End If

        On Error GoTo RaiseErr

        Dim strInUserName As String = Nothing
        Dim strInUserPassword As String = Nothing
        Dim strInUserLevel As String = Nothing
        Dim strInBranchName As String = Nothing
        Dim strInChangeDate As String = Nothing
        Dim strInEmailAddress As String = Nothing

        'Assign values to the relevent variables
        strInUserName = txtUserName.Text
        strInChangeDate = CStr(Format(Now, "dd-MMM-yyyy"))
        strInEmailAddress = txtEmailAddress.Text
        strInUserLevel = cboUserLevel.Text

        'Whether you are in edit mode or new entry mode, delete any previous similar record
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM Users WHERE UserName = '" & txtUserName.Text & "'", cnn)
        objCommand.ExecuteNonQuery()

        If boolEditStatus = False Then strInUserPassword = UnEncryption(txtUserPassword.Text) Else strInUserPassword = txtUserPassword.Text

        Dim strSql As String = "INSERT INTO [Users] ([UserName],[UserPassword],[UserLevel]," _
            & "[ChangeDate],[EmailAddress], [GivenNames]) " _
            & " VALUES ('" & strInUserName & "', '" & strInUserPassword & "', '" & strInUserLevel & "', " _
            & "'" & strInChangeDate & "', '" & strInEmailAddress & "', '" & txtGivenNames.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        If MessageBox.Show("User has been set successfully. Do you want to add more users?", "User Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            txtConfirmPassword.Clear()
            txtUserName.Clear()
            txtUserPassword.Clear()
            txtEmailAddress.Clear()
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On User Setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmUserSecurityProfile_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then
            LoadData()
            txtUserPassword.Enabled = False
            txtConfirmPassword.Enabled = False
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        txtUserName.Enabled = False
        Dim strSql As String = "SELECT[UserName],[UserPassword],[UserLevel]," _
            & "[ChangeDate],[EmailAddress],[GivenNames] FROM USERS WHERE UserName = '" & strSelectedUser & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("UserName").ToString) Then txtUserName.Text = objReader("UserName").ToString
            If Not IsDBNull(objReader("UserPassword").ToString) Then
                txtUserPassword.Text = objReader("UserPassword").ToString
                txtConfirmPassword.Text = objReader("UserPassword").ToString
            End If
            If Not IsDBNull(objReader("UserLevel").ToString) Then cboUserLevel.Text = objReader("UserLevel").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("GivenNames").ToString) Then txtGivenNames.Text = objReader("GivenNames").ToString
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On User Setup"
        ShowErrorMessage()
    End Sub

End Class
