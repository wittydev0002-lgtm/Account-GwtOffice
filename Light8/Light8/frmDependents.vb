Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmDependents

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmDependents_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If boolEditStatus = True Then LoadData()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        boolAbort = False

        If String.IsNullOrEmpty(txtGivenNames.Text) Then
            MessageBox.Show("Please enter the dependant name", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGivenNames.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtSuffix.Text) Then
            MessageBox.Show("Please enter a valid dependant suffix", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSuffix.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboGender.Text) Then
            MessageBox.Show("Please enter the dependant gender", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboGender.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboRelationship.Text) Then
            MessageBox.Show("Please enter the dependant relationship to member", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboRelationship.Focus()
            Exit Sub
        End If

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If boolEditStatus = True Then
            strSql = "DELETE FROM EmployeeDependents WHERE TransactionId = " & intSelectedTransaction & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        strSql = "INSERT INTO EmployeeDependents (EmployeeNo, DependentCode, GivenNames, IdNumber, " _
            & "DateOfBirth, UserName, ChangeDate, Gender, Relationship) VALUES ('" & strPublicEmployeeId & "',  " _
            & "" & txtSuffix.Text & ", '" & txtGivenNames.Text & "', " _
            & "'" & txtIdNumber.Text & "', '" & shortMonthDateFormat(dpBirthDate.Value) & "', " _
            & "'" & strPublicActiveFullUserName & "', " _
            & "'" & Now & "', '" & cboGender.Text & "', '" & cboRelationship.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On dependants details setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeMaster WHERE TransactionId = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("GivenNames").ToString) Then txtGivenNames.Text = objReader("GivenNames").ToString
            If Not IsDBNull(objReader("IdNumber").ToString) Then txtIdNumber.Text = objReader("IdNumber").ToString
            If IsNumeric(objReader("DependentCode").ToString) Then txtSuffix.Text = objReader("DependentCode").ToString
            If IsDate(objReader("DateOfBirth").ToString) Then dpBirthDate.Value = objReader("DateOfBirth").ToString
            If Not IsDBNull(objReader("Gender").ToString) Then cboGender.Text = objReader("Gender").ToString
            If Not IsDBNull(objReader("Relationship").ToString) Then cboRelationship.Text = objReader("Relationship").ToString
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On dependants details setup"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class