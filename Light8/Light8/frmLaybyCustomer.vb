Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLaybyCustomer

    Private Sub frmLaybyCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then LoadData() Else GetNextCustomerNumber()
    End Sub

    Private Sub GetNextCustomerNumber()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber FROM LaybyCustomers ORDER BY AccountNumber DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                txtAccountNumber.Text = CDbl(objReader(0).ToString) + 1
            End If
        Else
            txtAccountNumber.Text = "10001"
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On lay-bye customer details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM LaybyCustomers WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("AccountNumber").ToString) Then txtAccountNumber.Text = objReader("AccountNumber").ToString
            If Not IsDBNull(objReader("AccountName").ToString) Then txtAccountHolder.Text = objReader("AccountName").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("Notes").ToString) Then txtNotes.Text = objReader("Notes").ToString
        End If
        txtAccountNumber.Enabled = False

        'Load the transactions to the grid
        objCommand = New Data.OleDb.OleDbCommand("Select CONVERT(NVARCHAR, TransDate, 105) AS [Date], Description, " _
            & "DocumentNumber, TransType, CAST(Amount AS DECIMAL (30,2)) AS [Amount] FROM LaybyTransactions " _
            & "WHERE AccountNumber = '" & strSelectedAccount & "' ORDER BY TransDate", cnn)
        objReader = objCommand.ExecuteReader

        dgrid.Rows.Clear()
        Dim dblBalance As Double = 0
        While objReader.Read
            If Not IsDBNull(objReader(3).ToString) Then
                Dim dblLineAmount As Double = 0
                If IsNumeric(objReader(4).ToString) Then dblLineAmount = CDbl(objReader(4).ToString)
                If UCase(objReader(3).ToString) = "PAYMENT" Then
                    dblBalance = dblBalance - dblLineAmount
                Else
                    dblBalance = dblBalance + dblLineAmount
                End If
            End If
            dgrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4))
        End While
        objReader.Close()

        'Compute the account balance
        lblBalance.Text = Format(dblBalance, "#,##0.00")
        If dblBalance < 0 Then lblBalance.StateCommon.ShortText.Color1 = Color.Red Else lblBalance.StateCommon.ShortText.Color1 = Color.SteelBlue
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On lay-bye customer details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(txtAccountNumber.Text) Then
            MessageBox.Show("Please enter the account number", "Invalid Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNumber.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountHolder.Text) Then
            MessageBox.Show("Please enter the account holder name", "Invalid Account Holder Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountHolder.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the account holder address", "Invalid Account Holder Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = True Then
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LaybyCustomers WHERE AccountNumber = '" & txtAccountNumber.Text & "'", cnn)
            objCommand.ExecuteNonQuery()
        End If

        Dim strSql As String = "INSERT INTO LaybyCustomers ([AccountNumber], [AccountName], " _
            & "[Address1], [Address2], [Address3], [Address4], [Telephone], [Cellphone], [EmailAddress], [Notes]) VALUES " _
            & "('" & txtAccountNumber.Text & "', '" & txtAccountHolder.Text & "', '" & txtAddress1.Text & "', " _
            & "'" & txtAddress2.Text & "', '" & txtAddress3.Text & "', '" & txtAddress4.Text & "', " _
            & "'" & txtTelephone.Text & "', '" & txtCellphone.Text & "', '" & txtEmailAddress.Text & "', '" & txtNotes.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Lay-bye customer details saved successfully", "Lay-bye Customer Details Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If boolEditStatus = True Then
            Me.Close()
        Else
            txtAccountHolder.Clear()
            txtAccountNumber.Clear()
            txtAddress1.Clear()
            txtAddress2.Clear()
            txtAddress3.Clear()
            txtAddress4.Clear()
            txtTelephone.Clear()
            txtCellphone.Clear()
            txtEmailAddress.Clear()
            txtNotes.Clear()
            txtAccountNumber.Focus()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On lay-bye customer details save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtAccountNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountNumber.KeyPress
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Or e.KeyChar = "%" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtAccountHolder.Focus()
    End Sub

    Private Sub txtAccountHolder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountHolder.KeyPress
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Or e.KeyChar = "%" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtAddress1.Focus()
    End Sub

    Private Sub txtAddress1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress1.KeyPress
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Or e.KeyChar = "%" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtAddress2.Focus()
    End Sub

    Private Sub txtAddress2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress2.KeyPress
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Or e.KeyChar = "%" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtAddress3.Focus()
    End Sub

    Private Sub txtAddress3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress3.KeyPress
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Or e.KeyChar = "%" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtAddress4.Focus()
    End Sub

    Private Sub txtAddress4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress4.KeyPress
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Or e.KeyChar = "%" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtTelephone.Focus()
    End Sub

    Private Sub txtTelephone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelephone.KeyPress
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Or e.KeyChar = "%" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtCellphone.Focus()
    End Sub

    Private Sub txtCellphone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCellphone.KeyPress
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Or e.KeyChar = "%" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtEmailAddress.Focus()
    End Sub

    Private Sub txtEmailAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailAddress.KeyPress
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Or e.KeyChar = "%" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then btnOk.Focus()
    End Sub

    Private Sub frmLaybyCustomer_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 651 : Me.Height = 442
    End Sub

End Class
