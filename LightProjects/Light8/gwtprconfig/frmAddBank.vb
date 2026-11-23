Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmAddBank

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtBankCode.Text) Then
            MessageBox.Show("Please enter the bank code", "Invalid Bank Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBankCode.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtBankName.Text) Then
            MessageBox.Show("Please enter the bank name", "Invalid Bank Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBankName.Focus()
            Exit Sub
        End If
        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = True Then
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemBanks WHERE BankCode = '" & txtBankCode.Text & "'", cnn)
            objCommand.ExecuteNonQuery()
        End If
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO [SystemBanks] ([BankName],[BankCode],[Address1] " _
           & ",[Address2],[Address3],[Address4]) VALUES " _
           & "('" & txtBankName.Text & "','" & txtBankCode.Text & "' " _
           & ",'" & txtAddress1.Text & "','" & txtAddress2.Text & "' " _
           & ",'" & txtAddress3.Text & "','" & txtAddress4.Text & "')", cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Bank Added Successfully", "Process Execution Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Bank Add Failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmAddBank_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        If boolEditStatus = True Then
            txtBankCode.Enabled = False
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM SystemBanks WHERE BankCode = '" & strSelectedCode & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader("BankName").ToString) Then txtBankName.Text = objReader("BankName").ToString
                If Not IsDBNull(objReader("BankCode").ToString) Then txtBankCode.Text = objReader("BankCode").ToString
                If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
                If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
                If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
                If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            End If
            objReader.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Bank Add Failure"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
