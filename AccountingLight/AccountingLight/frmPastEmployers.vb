Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPastEmployers

    Private Sub frmPastEmployers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAccountNo.Text = strSelectedAccount : txtAccountNo.Enabled = False
        If boolEditStatusTwo = True Then LoadEmploymentData()
    End Sub

    Private Sub frmPastEmployers_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Width = 633 : Me.Height = 430
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SaveEmploymentData()
    End Sub

    Private Sub SaveEmploymentData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        If String.IsNullOrEmpty(txtEmployer.Text) Then
            MessageBox.Show("Please enter the employer name", "Invalid Employer Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEmployer.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the employer address", "Invalid Employer Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtPosTitle.Text) Then
            MessageBox.Show("Please enter the position title", "Invalid Position Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPosTitle.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtSalary.Text) Then
            MessageBox.Show("Please enter a numeric value for salary", "Invalid Salary Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSalary.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboStatus.Text) Then
            MessageBox.Show("Please enter the employment status", "Invalid Employment Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboStatus.Focus()
            Exit Sub
        End If
        If boolEditStatusTwo = False Then
            strSql = "INSERT INTO CustomerEmploymentHistory ([Employer],[Address1],[Address2],[Address3],[Address4] " _
                & ",[JobTitle],[DateFrom],[DateTo],[AverageSalary],[TerminationReason],[AccountNumber]) " _
                & "VALUES('" & txtEmployer.Text & "', '" & txtAddress1.Text & "', '" & txtAddress2.Text & "', " _
                & "'" & txtAddress3.Text & "', '" & txtAddress4.Text & "', '" & txtPosTitle.Text & "', " _
                & "'" & Format(dpStart.Value, "dd-MMM-yyyy") & "', " _
                & "'" & Format(dpEnd.Value, "dd-MMM-yyyy") & "', " & CDbl(txtSalary.Text) & ", 'NOT APPLICABLE', " _
                & "'" & txtAccountNo.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Else
            strSql = "DELETE FROM CustomerEmploymentHistory WHERE AcountNumber = '" & txtAccountNo.Text & "' " _
                & "AND TransactionId = " & intSelectedTransaction & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            strSql = "UPDATE CustomerEmploymentHistory SET [Employer] = '" & txtEmployer.Text & "', [Address1] = '" & txtAddress1.Text & "', " _
                & "[Address2] = '" & txtAddress2.Text & "', [Address3] = '" & txtAddress3.Text & "', [Address4] = '" & txtAddress4.Text & "', " _
                & "[JobTitle] = '" & txtPosTitle.Text & "', [DateFrom] = '" & Format(dpStart.Value, "dd-MMM-yyyy") & "', " _
                & "[DateTo] = '" & Format(dpEnd.Value, "dd-MMM-yyyy") & "', [AverageSalary] = " & CDbl(txtSalary.Text) & ", " _
                & "[TerminationReason] = 'NOT APPLICABLE' WHERE AccountNumber = '" & txtAccountNo.Text & "' AND " _
                & "TransactionId = " & intSelectedTransaction & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        MessageBox.Show("Employment Details saved successfully", "Employment Details Save Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Employment Data Save"
        ShowErrorMessage()
    End Sub

    Private Sub LoadEmploymentData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM EmploymentHistory WHERE AccountNumber = '" & strSelectedAccount & "' AND " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim n As Double = 0
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("Employer").ToString) Then txtEmployer.Text = objReader("Employer").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("JobTitle").ToString) Then txtPosTitle.Text = objReader("JobTitle").ToString
            If IsDate(objReader("DateFrom").ToString) Then dpStart.Value = CDate(objReader("DateFrom").ToString)
            If IsDate(objReader("DateTo").ToString) Then dpEnd.Value = CDate(objReader("DateTo").ToString)
            If IsNumeric(objReader("AverageSalary").ToString) Then txtSalary.Text = Format(CDbl(objReader("AverageSalary").ToString), "##0.00")
            If Not IsDBNull(objReader("Branch").ToString) Then txtEmployer.Text = objReader("Branch").ToString
            If Not IsDBNull(objReader("Department").ToString) Then txtAddress1.Text = objReader("Department").ToString
            If Not IsDBNull(objReader("PayPoint").ToString) Then txtAddress2.Text = objReader("PayPoint").ToString
            If Not IsDBNull(objReader("Status").ToString) Then txtEmployer.Text = objReader("Status").ToString
            If Not IsDBNull(objReader("AccountNumber").ToString) Then txtEmployer.Text = objReader("AccountNumber").ToString
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Employment Data Save"
        ShowErrorMessage()
    End Sub

End Class
