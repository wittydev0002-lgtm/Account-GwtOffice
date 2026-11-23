Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoyalityCustomers

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtAccountNumber.Text) Then
            MessageBox.Show("Please enter the account number", "Invalid Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNumber.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtLastName.Text) Then
            MessageBox.Show("Please enter the last name", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLastName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtFirstName.Text) Then
            MessageBox.Show("Please enter the first name", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirstName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboGender.Text) Then
            MessageBox.Show("Please enter the client gender", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboGender.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboCategory.Text) Then
            MessageBox.Show("Please enter the client category", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCategory.Focus()
            Exit Sub
        End If


        'Check that the date is inputed correctly
        Dim myString As String = mDateOfBirth.Text
        Dim strDateBuffer() As String = Split(myString, "/")
        Dim strDay As String = strDateBuffer(0)
        Dim strMonth As String = strDateBuffer(1)
        Dim strYear As String = strDateBuffer(2)

        If Not IsNumeric(strDay) Then
            MessageBox.Show("Invalid date entry", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            mDateOfBirth.Focus()
            Exit Sub
        End If
        If Not IsNumeric(strMonth) Then
            MessageBox.Show("Invalid date entry", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            mDateOfBirth.Focus()
            Exit Sub
        End If
        If Not IsNumeric(strYear) Then
            MessageBox.Show("Invalid date entry", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            mDateOfBirth.Focus()
            Exit Sub
        End If

        If CInt(strMonth) > 12 Or CInt(strMonth) < 1 Then
            MessageBox.Show("Invalid date entry", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            mDateOfBirth.Focus()
            Exit Sub
        End If

        Dim strDateOfBirth As String = Format(CInt(strDay), "00") & "-" & gwt_comm.getMonth(CInt(strMonth)) & "-" & CInt(strYear)

        If Not IsDate(strDateOfBirth) Then
            MessageBox.Show("Invalid date entry", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            mDateOfBirth.Focus()
            Exit Sub
        End If

        Dim strSql As String = Nothing
        If boolEditStatus = False Then
            strSql = "INSERT INTO LoyalityCustomers (AccountNumber, LastName, FirstName, OtherNames, " _
                & "MaidenName, IdNumber, Gender, ContactNumber, Category, CurrentDate, Address1, Address2, " _
                & "Address3, Address4, EmailAddress, DateOfBirth) VALUES " _
                & "('" & txtAccountNumber.Text & "', '" & txtLastName.Text & "', '" & txtFirstName.Text & "', " _
                & "'" & txtOtherNames.Text & "', '" & txtMaidenName.Text & "', '" & txtIdNumber.Text & "', " _
                & "'" & cboGender.Text & "', '" & txtContactNumber.Text & "', '" & cboCategory.Text & "', " _
                & "'" & txtAccountPrefix.Text & "', '" & txtAddress1.Text & "', '" & txtAddress2.Text & "', " _
                & "'" & txtAddress3.Text & "', '" & txtAddress4.Text & "', '" & txtEmailAddress.Text & "', " _
                & "'" & strDateOfBirth & "')"
        Else
            strSql = "UPDATE LoyalityCustomers SET LastName = '" & txtLastName.Text & "', " _
                & "FirstName = '" & txtFirstName.Text & "', OtherNames = '" & txtOtherNames.Text & "', " _
                & "MaidenName = '" & txtMaidenName.Text & "', IdNumber = '" & txtIdNumber.Text & "', " _
                & "Gender = '" & cboGender.Text & "', ContactNumber = '" & txtContactNumber.Text & "', " _
                & "Category = '" & cboCategory.Text & "', Address1 = '" & txtAddress1.Text & "', " _
                & "Address2 = '" & txtAddress2.Text & "', Address3 = '" & txtAddress3.Text & "', " _
                & "EmailAddress = '" & txtEmailAddress.Text & "', DateOfBirth = '" & strDateOfBirth & "' " _
                & "WHERE AccountNumber = '" & txtAccountNumber.Text & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        If boolEditStatus = False Then UpdateControlNumber()
        MessageBox.Show("Client details save success", "Loyality Customer Details Save", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If boolEditStatus = False Then
            txtAccountNumber.Clear()
            txtLastName.Clear()
            txtFirstName.Clear()
            txtOtherNames.Clear()
            txtMaidenName.Clear()
            txtIdNumber.Clear()
            txtContactNumber.Clear()
            txtLastName.Focus()
            txtAccountPrefix.Clear()
            txtAddress1.Clear()
            txtAddress2.Clear()
            txtAddress3.Clear()
            txtAddress4.Clear()
            txtEmailAddress.Clear()
            If chkAuto.Checked Then
                If chkAuto.Checked = True Then txtAccountPrefix.Text = CStr(Format(CInt(DatePart(DateInterval.Year, Now)), "0000")) & CStr(Format(CInt(DatePart(DateInterval.Month, Now)), "00"))
            Else
                txtAccountPrefix.Text = "201201"
            End If
            Exit Sub
        End If
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " errror number " & Err.Number & vbCrLf & "On loyality customer details setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    'Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    Dim f As New frmLoyalityCategories
    '    f.ShowDialog()
    '    LoadCategories()
    'End Sub

    Private Sub LoadCategories()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT ProgramName FROM LoyaltyPromotions ORDER BY ProgramName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboCategory.Items.Clear()
        '
        'Add the first default
        '
        cboCategory.Items.Add("---NONE---")
        While objReader.Read
            cboCategory.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " errror number " & Err.Number & vbCrLf & "On loyality customer programs load failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmLoyalityCustomers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCategories()
        If boolEditStatus = True Then
            LoadData()
            LoadTransactions()
            txtAccountNumber.Enabled = False
        Else
            NewAccount()
        End If
    End Sub

    Private Sub NewAccount()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT BaseNumber, LoyaltyNumber FROM ControlNumbers", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim intNext As Integer = 1
        Dim strBaseDate As String = Format(CInt(DatePart(DateInterval.Year, Now)), "0000") & Format(CInt(DatePart(DateInterval.Month, Now)), "00")
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(1).ToString) Then
                intNext = CInt(objReader(1).ToString) + 1
            End If
            If Not IsDBNull(objReader(0).ToString) Then strBaseDate = objReader(0).ToString
        End If
        objReader.Close()
        txtAccountNumber.Text = strBaseDate & Format(intNext, "0000")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " errror number " & Err.Number & vbCrLf & "On loyality customer account number entry"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub UpdateControlNumber()
        On Error GoTo RaiseErr
        Dim strBase As String = Mid(txtAccountNumber.Text, 1, 6)
        Dim intNumber As Integer = CInt(Mid(txtAccountNumber.Text, 7, (txtAccountNumber.Text.Length - 6)))
        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET BaseNumber = '" & strBase & "', LoyaltyNumber = " & intNumber & "", cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " errror number " & Err.Number & vbCrLf & "On loyality customer account number update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtAccountNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountNumber.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtLastName.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AccountNumber, LastName, FirstName, OtherNames, MaidenName, " _
            & "Gender, IdNumber, ContactNumber, Category, Address1, Address2, Address3, " _
            & "Address4, EmailAddress, DateOfBirth " _
            & "FROM LoyalityCustomers WHERE AccountNumber = " & strSelectedAccount
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtAccountNumber.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtLastName.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtFirstName.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then txtOtherNames.Text = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then txtMaidenName.Text = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then cboGender.Text = objReader(5).ToString
            If Not IsDBNull(objReader(6).ToString) Then txtIdNumber.Text = objReader(6).ToString
            If Not IsDBNull(objReader(7).ToString) Then txtContactNumber.Text = objReader(7).ToString
            If Not IsDBNull(objReader(8).ToString) Then cboCategory.Text = objReader(8).ToString
            If Not IsDBNull(objReader(9).ToString) Then txtAddress1.Text = objReader(9).ToString
            If Not IsDBNull(objReader(10).ToString) Then txtAddress2.Text = objReader(10).ToString
            If Not IsDBNull(objReader(11).ToString) Then txtAddress3.Text = objReader(11).ToString
            If Not IsDBNull(objReader(12).ToString) Then txtAddress4.Text = objReader(12).ToString
            If Not IsDBNull(objReader(13).ToString) Then txtEmailAddress.Text = objReader(13).ToString
            If IsDate(objReader("DateOfBirth").ToString) Then
                mDateOfBirth.Text = Format(CDate(objReader("DateOfBirth").ToString), "dd/MM/yyyy")
            End If

        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " errror number " & Err.Number & vbCrLf & "On loyality customer data load failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub DeleteTransaction(ByVal TransactionId As Integer)
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim strSql As String = "DELETE  FROM LoyalityEntries " _
                & "WHERE TransactionId = " & TransactionId & ""
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            LoadTransactions()
            MessageBox.Show("Transaction Deleted Successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " errror number " & Err.Number & vbCrLf & "On loyality customer transactions load failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadTransactions()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, TransDate, 106) AS [Date], " _
            & "Description, SalesRep, CAST(Amount AS DECIMAL (30,2)) AS [Amount], Category, ItemShortCode, TransactionId FROM LoyalityEntries " _
            & "WHERE AccountNumber = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridAccounts.Rows.Clear()
        While objReader.Read
            dGridAccounts.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5), objReader(6))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " errror number " & Err.Number & vbCrLf & "On loyality customer transactions load failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAddTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTransaction.Click
        Dim f As New frmLoyalityCustmerTransactionEntries
        f.ShowDialog()
        LoadTransactions()
    End Sub

    Private Sub chkAuto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAuto.CheckedChanged
        If boolEditStatus = False Then
            If chkAuto.Checked = True Then
                txtAccountPrefix.Text = CStr(Format(CInt(DatePart(DateInterval.Year, Now)), "0000")) & CStr(Format(CInt(DatePart(DateInterval.Month, Now)), "00"))
            Else
                txtAccountPrefix.Text = "201201"
                'txtAccountNumber.Text = Nothing
            End If
        End If
    End Sub

    Private Sub txtAccountPrefix_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountPrefix.TextChanged
        If boolEditStatus = False Then
            If Not String.IsNullOrEmpty(txtAccountPrefix.Text) Then
                NewAccount()
            End If
        End If
    End Sub

    Private Sub txtLastName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLastName.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtFirstName.Focus()
    End Sub

    Private Sub txtFirstName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFirstName.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtOtherNames.Focus()
    End Sub

    Private Sub txtOtherNames_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherNames.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtMaidenName.Focus()
    End Sub

    Private Sub txtMaidenName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaidenName.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtIdNumber.Focus()
    End Sub

    Private Sub txtIdNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIdNumber.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then cboGender.Focus()
    End Sub

    Private Sub cboGender_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboGender.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtAddress1.Focus()
    End Sub

    Private Sub txtAddress1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress1.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtAddress2.Focus()
    End Sub

    Private Sub txtAddress2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress2.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtAddress3.Focus()
    End Sub

    Private Sub txtAddress3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress3.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtAddress4.Focus()
    End Sub

    Private Sub txtAddress4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress4.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtEmailAddress.Focus()
    End Sub

    Private Sub txtEmailAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailAddress.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtContactNumber.Focus()
    End Sub

    Private Sub txtContactNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactNumber.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then cboCategory.Focus()
    End Sub

    Private Sub cboCategory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCategory.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
    End Sub

    Private Sub dGridAccounts_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridAccounts.CellClick
        If e.ColumnIndex = 7 Then
            With dGridAccounts
                If Not (Object.Equals(Convert.ToString(.CurrentRow.Cells(6).Value), "")) Then
                    If IsNumeric(.CurrentRow.Cells(6).Value.ToString) Then
                        DeleteTransaction(CInt(.CurrentRow.Cells(6).Value.ToString))
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub frmLoyalityCustomers_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 700 : Me.Height = 490 '700; 490
    End Sub

End Class
