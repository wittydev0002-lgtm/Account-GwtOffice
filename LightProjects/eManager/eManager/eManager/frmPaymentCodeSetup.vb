Public Class frmPaymentCodeSetup

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter the description for the payment code", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboType.Text) Then
            MessageBox.Show("Please enter the type for the payment code", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboType.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboTaxType.Text) Then
            MessageBox.Show("Please enter the tax treatment for the payment code", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboTaxType.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboGrossUp.Text) Then
            MessageBox.Show("Please enter the gross up status", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboGrossUp.Focus()
            Exit Sub
        End If

        Dim objCommand As Data.OleDb.OleDbCommand

        If boolEditStatus = False Then
            'Check that the record exists or not
            Dim boolRecordExist As Boolean = False
            objCommand = New Data.OleDb.OleDbCommand("SELECT Description FROM PaymentCodes WHERE Description = '" & txtDescription.Text & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReader.Read
                boolRecordExist = True
            End While
            objReader.Close()
            If boolRecordExist = True Then
                MessageBox.Show("The description for this payment code will cause a duplicate entry. Record entry will not be accepted.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtDescription.Focus()
                Exit Sub
            End If
        End If

        If boolEditStatus = False Then
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO PaymentCodes (Description, PayType, TaxType, GrossUpStatus) VALUES " _
                & "('" & txtDescription.Text & "', '" & cboType.Text & "', '" & cboTaxType.Text & "', '" & cboGrossUp.Text & "')", cnn)
        Else
            objCommand = New Data.OleDb.OleDbCommand("UPDATE PaymentCodes SET Description = '" & txtDescription.Text & "', " _
                & "PayType = '" & cboType.Text & "', TaxType = '" & cboTaxType.Text & "', GrossUpStatus = '" & cboGrossUp.Text & "' WHERE " _
                & "CodeNo = " & intSelectedTransactionId & "", cnn)
        End If

        objCommand.ExecuteNonQuery()

        MessageBox.Show("Transaction has been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If boolEditStatus = False Then
            txtDescription.Clear()
            cboTaxType.Text = ""
            cboType.Text = ""
            txtDescription.Focus()
        Else
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On payment codes setup"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSelected()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM PaymentCodes WHERE " _
            & "CodeNo = " & intSelectedTransactionId & "", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader("Description").ToString) Then txtDescription.Text = objReader("Description").ToString
            If Not IsDBNull(objReader("PayType").ToString) Then cboType.Text = objReader("PayType").ToString
            If Not IsDBNull(objReader("TaxType").ToString) Then cboTaxType.Text = objReader("TaxType").ToString
            If Not IsDBNull(objReader("GrossUpStatus").ToString) Then cboGrossUp.Text = objReader("GrossUpStatus").ToString
            Exit While
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On payment codes setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmPaymentCodeSetup_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If boolEditStatus = True Then LoadSelected()
    End Sub

    Private Sub frmPaymentCodeSetup_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 510
        Me.Height = 200
    End Sub

End Class
