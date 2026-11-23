Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmBooking
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtCustomerName.Text) Then
            MessageBox.Show("Please enter the guest name", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtCustomerName.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the guest address", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtAddress1.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboClassification.Text) Then
            MessageBox.Show("Please enter the guest tourism classification", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            cboClassification.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboRoom.Text) Then
            MessageBox.Show("Please select the room from the list", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            cboRoom.Select()
            Exit Sub
        End If

        If optOther.Checked = True Or optAccount.Checked = True Then
            If String.IsNullOrEmpty(txtBillToName.Text) Then
                MessageBox.Show("Please the person/corporate to whom bills are to be sents", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedIndex = 1
                txtBillToName.Select()
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtBillToAddress.Text) Then
                MessageBox.Show("Please the address to where bills are to be sents", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedIndex = 1
                txtBillToAddress.Select()
                Exit Sub
            End If
            If optAccount.Checked = True Then
                If String.IsNullOrEmpty(txtAccountNumber.Text) Then
                    MessageBox.Show("Please select customer from the given list", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TabControl1.SelectedIndex = 1
                    btnBrowse.Select()
                    Exit Sub
                End If
            End If
        End If

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If boolEditStatus = False Then

            'Insert Master Record

            strSql = "INSERT INTO HotelMaster ([GuestName], [Address1], [Address2], [Address3], [Address4], [Telephone], " _
                & "[ContactTelephone], [EmailAddress], [TourClassification], [CarRegNumber], [DateFrom], [DateTo], " _
                & "UserName, Branch) VALUES " _
                & "('" & txtCustomerName.Text & "', '" & txtAddress1.Text & "', '" & txtAddress2.Text & "', '" & txtAddress3.Text & "', " _
                & "'" & txtAddress4.Text & "', '" & txtTelephone.Text & ", '" & txtCellphone.Text & "', '" & txtEmailAddress.Text & "', " _
                & "'" & cboClassification.Text & "', '" & txtRegNumber.Text & "', '" & dpFrom.Value & "', '" & dpTo.Value & "', " _
                & "'" & strUserName & "', '" & strUserBranch & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            Dim intGuestNumber As Integer = 1
            strSql = "SELECT GuestNumber FROM HotelMaster WHERE UserName = '" & strUserName & "' AND " _
                & "Branch = '" & strUserBranch & "' ORDER BY GuestNumber DESC"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader(0).ToString) Then intGuestNumber = CInt(objReader(0).ToString)
            End If
            objReader.Close()

            'Insert Billing Record

            strSql = "INSERT INTO HotelGuestBilling ([GuestNumber], [AccountNumber], [BillToName], [Address], [Telephone]) VALUES " _
                & "(" & intGuestNumber & ", '" & txtAccountNumber.Text & "', '" & txtBillToName.Text & "', " _
                & "'" & txtBillToAddress.Text & "', '" & txtBillToPhone.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

        Else

            strSql = "UPDATE HotelMaster SET [GuestName] = '" & txtCustomerName.Text & "', " _
                & "[Address1] = '" & txtAddress1.Text & "', [Address2] = '" & txtAddress2.Text & "', " _
                & "[Address3] = '" & txtAddress3.Text & "', [Address4] = '" & txtAddress4.Text & "', " _
                & "[Telephone] = '" & txtTelephone.Text & "', [ContactTelephone] = '" & txtCellphone.Text & "', " _
                & "[EmailAddress] = '" & txtEmailAddress.Text & "', [TourClassification] = '" & cboClassification.Text & "', " _
                & "[CarRegNumber] = '" & txtRegNumber.Text & "', [DateFrom] = '" & dpFrom.Value & "', " _
                & "[DateTo] = '" & dpTo.Value & "', UserName = '" & strUserName & "', Branch = '" & strUserBranch & "' " _
                & "WHERE GuestNumber = " & txtGuestId.Text & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            'Insert Billing Record

            strSql = "UPDATE HotelGuestBilling ([AccountNumber] = '" & txtAccountNumber.Text & "', " _
                & "[BillToName] = '" & txtBillToName.Text & "', [Address] = '" & txtBillToAddress.Text & "', " _
                & "[Telephone] = '" & txtBillToPhone.Text & "' WHERE [GuestNumber] = " & txtGuestId.Text & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

        End If


        MessageBox.Show("Details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On hotel booking processing"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub optAccount_CheckedChanged(sender As Object, e As EventArgs) Handles optAccount.CheckedChanged
        If optAccount.Checked = True Then
            btnBrowse.Enabled = True
        Else
            btnBrowse.Enabled = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

End Class