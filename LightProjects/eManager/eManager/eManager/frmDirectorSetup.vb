Public Class frmDirectorSetup

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtFirstName.Text) Then
            MessageBox.Show("Please enter the first name", "Missing First Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirstName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtLastName.Text) Then
            MessageBox.Show("Please enter the surname", "Missing Surname", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLastName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtIdNumber.Text) Then
            MessageBox.Show("Please enter the ID Number", "Missing ID Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtIdNumber.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the address", "Missing Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If

        Dim strSql As String = Nothing
        Dim strDate As String = Nothing

        If Format(CDate(dpStartDate.Value), "dd-MMM-yyyy") <> Format(Now, "dd-MMM-yyyy") Then
            strDate = Format(CDate(dpStartDate.Value), "dd-MMM-yyyy")
        End If

        If boolEditStatus = False Then
            strSql = "INSERT INTO EmployeeMaster (LastName, FirstName, OtherNames, IdNumber, Address1, Address2, " _
                & "Address3, Address4,Telephone,Cellphone,EmailAddress,Title,HireDate, BankCode, BankAccountNumber) VALUES ('" & txtLastName.Text & "', " _
                & "'" & txtFirstName.Text & "','" & txtOtherNames.Text & "', '" & txtIdNumber.Text & "', " _
                & "'" & txtAddress1.Text & "','" & txtAddress2.Text & "', " _
                & "'" & txtAddress3.Text & "','" & txtAddress4.Text & "', " _
                & "'" & txtTelephone.Text & "','" & txtCellphone.Text & "', " _
                & "'" & txtEmailAddress.Text & "', '" & cboTitle.Text & "', '" & strDate & "', " _
                & "'" & txtBankCode.Text & "', '" & txtAccountNumber.Text & "')"
        Else
            strSql = "UPDATE EmployeeMaster SET LastName = '" & txtLastName.Text & "'" _
                & ",FirstName = '" & txtFirstName.Text & "'" _
                & ",OtherNames = '" & txtOtherNames.Text & "'" _
                & ",IdNumber = '" & txtIdNumber.Text & "'" _
                & ",Address1 = '" & txtAddress1.Text & "'" _
                & ",Address2 = '" & txtAddress2.Text & "'" _
                & ",Address3 = '" & txtAddress3.Text & "'" _
                & ",Address4 = '" & txtAddress4.Text & "'" _
                & ",Telephone = '" & txtTelephone.Text & "'" _
                & ",Cellphone = '" & txtCellphone.Text & "'" _
                & ",EmailAddress = '" & txtEmailAddress.Text & "', " _
                & "Title = '" & cboTitle.Text & "', HireDate = '" & strDate & "', " _
                & "BankCode = '" & txtBankCode.Text & "', BankAccountNumber = '" & txtAccountNumber.Text & "' " _
                & "WHERE TransactionId = " & intSelectedTransactionId & ""
        End If

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        sqlCommand.ExecuteNonQuery()

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On director details save"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSelectedData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeMaster WHERE TransactionId = " & intSelectedTransactionId & "", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader("Title").ToString) Then cboTitle.Text = objReader("Title").ToString
            If Not IsDBNull(objReader("LastName").ToString) Then txtLastName.Text = objReader("LastName").ToString
            If Not IsDBNull(objReader("FirstName").ToString) Then txtFirstName.Text = objReader("FirstName").ToString
            If Not IsDBNull(objReader("OtherNames").ToString) Then txtOtherNames.Text = objReader("OtherNames").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("IdNumber").ToString) Then txtIdNumber.Text = objReader("IdNumber").ToString
            If IsDate(objReader("HireDate").ToString) Then dpStartDate.Value = CDate(objReader("HireDate").ToString)
            If Not IsDBNull(objReader("BankCode").ToString) Then txtBankCode.Text = objReader("BankCode").ToString
            If Not IsDBNull(objReader("BankAccountNumber").ToString) Then txtAccountNumber.Text = objReader("BankAccountNumber").ToString
            Exit While
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On director details load"
        ShowErrorMessage()
    End Sub

    Private Sub frmDirectorSetup_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ManageTable()
        If boolEditStatus = True Then
            LoadSelectedData()
            LoadCodes()
        End If
    End Sub

    Private Sub ManageTable()
        If CheckColumnExistence("EmployeeMaster", "HireDate") = False Then
            Dim strSql = "ALTER TABLE EmployeeMaster ADD [HireDate][DateTime] NULL"
            Dim dbCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            dbCommand.ExecuteNonQuery()
        End If
    End Sub

    Private Sub LoadCodes()
        On Error GoTo RaiseErr
        Dim myCommand As New Data.OleDb.OleDbCommand("SELECT Description, CodeNo " _
            & "FROM PaymentCodes ORDER BY Description", cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
        dGridCurrent.Rows.Clear()
        dGridPast.Rows.Clear()
        While dbReader.Read
            dGridCurrent.Rows.Add(dbReader(0), "0.00", dbReader(1))
            dGridPast.Rows.Add(dbReader(0), "0.00", dbReader(1))
        End While
        dbReader.Close()

        'Get the currently unpaid amounts
        For i As Integer = 0 To dGridCurrent.Rows.Count - 1
            Dim intCode As Integer = 0
            Dim dblAmount As Double = 0
            If Not Object.Equals(Convert.ToString(dGridCurrent.Rows(i).Cells(2).Value), "") Then
                If IsNumeric(dGridCurrent.Rows(i).Cells(2).Value.ToString) Then
                    intCode = CInt(dGridCurrent.Rows(i).Cells(2).Value.ToString)
                    myCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Amount) FROM Payments " _
                        & "WHERE PayCode = " & intCode & " AND DirectorId = " & intSelectedTransactionId & " " _
                        & "AND Status = 'PENDING'", cnn)
                    Dim objReader As OleDb.OleDbDataReader = myCommand.ExecuteReader
                    While objReader.Read
                        If IsNumeric(objReader(0).ToString) Then dblAmount = CDbl(objReader(0).ToString)
                        Exit While
                    End While
                    objReader.Close()
                    dGridCurrent.Rows(i).Cells(1).Value = Format(dblAmount, "##0.00")
                End If
            End If
        Next

        'Get the past paid amounts
        For i As Integer = 0 To dGridPast.Rows.Count - 1
            Dim intCode As Integer = 0
            Dim dblAmount As Double = 0
            If Not Object.Equals(Convert.ToString(dGridPast.Rows(i).Cells(2).Value), "") Then
                If IsNumeric(dGridPast.Rows(i).Cells(2).Value.ToString) Then
                    intCode = CInt(dGridPast.Rows(i).Cells(2).Value.ToString)
                    myCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Amount) FROM Payments " _
                        & "WHERE PayCode = " & intCode & " AND DirectorId = " & intSelectedTransactionId & " " _
                        & "AND Status <> 'PENDING'", cnn)
                    Dim objReader As OleDb.OleDbDataReader = myCommand.ExecuteReader
                    While objReader.Read
                        If IsNumeric(objReader(0).ToString) Then dblAmount = CDbl(objReader(0).ToString)
                        Exit While
                    End While
                    objReader.Close()
                    dGridPast.Rows(i).Cells(1).Value = Format(dblAmount, "##0.00")
                End If
            End If
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on payment codes load"
        ShowErrorMessage()
    End Sub

    Private Sub btnEntries_Click(sender As System.Object, e As System.EventArgs) Handles btnEntries.Click
        boolEmployeeCall = True
        strSelectedDirectorDetails = txtLastName.Text & " " & txtFirstName.Text & " " & txtOtherNames.Text
        Dim f As New frmTransactionEntry
        f.ShowDialog()
        boolEmployeeCall = False
    End Sub

End Class