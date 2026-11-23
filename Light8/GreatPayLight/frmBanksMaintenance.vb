Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBanksMaintenance

    Private Sub btnAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbort.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If txtCode.Text = "" Or Mid(txtCode.Text, 1, 1) = " " Then
            MessageBox.Show("Please enter the bank sort code", _
                "Invalid Bank Sort Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCode.Focus()
            Exit Sub
        End If

        If txtBankName.text = "" Or Mid(txtbankname.text, 1, 1) = " " Then
            MessageBox.Show("Please enter a valid name for the bank", _
                "Invalid Bank Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtbankname.focus()
            Exit Sub
        End If

        If txtAddress1.Text = "" Or Mid(txtAddress1.Text, 1, 1) = " " Then
            MessageBox.Show("Please enter the branch name or address of the bank", _
                "Invalid Bank Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If

        On Error GoTo RaiseErr

        If boolEditStatus = True Then
            Dim sqlDeleteCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemBanks WHERE BankCode = '" & txtCode.Text & "'", cnn)
            sqlDeleteCommand.ExecuteNonQuery()
        End If
        Dim sqlCommand As New Data.OleDb.OleDbCommand("INSERT INTO SystemBanks " _
            & "(BankCode, BankName, Address1, Address2, Address3, Address4) VALUES " _
            & "('" & txtCode.Text & "', '" & txtBankname.Text & "', '" & txtAddress1.Text & "', " _
            & "'" & txtAddress2.Text & "', '" & txtAddress3.Text & "', '" & txtAddress4.Text & "')", cnn)
        sqlCommand.ExecuteNonQuery()
        MessageBox.Show("The bank has been saved successfuly", _
            "Bank Details Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
        boolEditStatus = True
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Bank Details Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmBanksMaintenance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtCode.Clear()
        txtBankname.Clear()
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtAddress3.Clear()
        txtAddress4.Clear()
        If boolEditStatus = True Then
            PopulateBankValues()
            txtCode.Enabled = False
        Else
            txtCode.Enabled = True
        End If
    End Sub

    Private Sub PopulateBankValues()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT " _
            & "BankCode, BankName, Address1, Address2, Address3, " _
            & "Address4 FROM SystemBanks WHERE BankCode = '" & lngPublicBankSortCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then txtCode.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtBankname.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtAddress1.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then txtAddress2.Text = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then txtAddress3.Text = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then txtAddress4.Text = objReader(5).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Bank Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAddress1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress1.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtAddress2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress2.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtAddress3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress3.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtAddress4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress4.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtBankname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBankname.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub frmBanksMaintenance_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 438 : Me.Height = 254
    End Sub

End Class