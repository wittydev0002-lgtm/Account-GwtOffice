Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBranchDetails

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtName.Text) Then
            MessageBox.Show("Please enter the name of the branch", "Invalid Branch Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the branch address", "Invalid Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtContactPerson.Text) Then
            MessageBox.Show("Please enter the name of the contact person", "Missing Contact Person Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtContactPerson.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboConnectionType.Text) Then
            MessageBox.Show("Please enter the connection type", "Invalid Connection Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboConnectionType.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtBranchCode.Text) Then
            MessageBox.Show("Please enter the branch account code for accounting purposes", "Missing Branch Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBranchCode.Focus()
            Exit Sub
        End If
        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = False Then
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO Branches ([BranchName]," _
                & "[Location],[Manager],[ContactNumbers],[Address1],[Address2],[Address3]," _
                & "[Address4],[FaxNumber],[ConnectionType],[BranchCode]) VALUES ('" & txtName.Text & "', " _
                & "'" & txtLocation.Text & "', '" & txtContactPerson.Text & "', '" & txtTelephone.Text & "', " _
                & "'" & txtAddress1.Text & "', '" & txtAddress2.Text & "', '" & txtAddress3.Text & "', " _
                & "'" & txtAddress4.Text & "', '" & txtFaxNumber.Text & "', '" & cboConnectionType.Text & "', " & txtBranchCode.Text & ")", Cnn)
        Else
            objCommand = New Data.OleDb.OleDbCommand("UPDATE Branches SET [BranchName] = '" & txtName.Text & "'," _
                & "[Location] = '" & txtLocation.Text & "', [Manager] = '" & txtContactPerson.Text & "', " _
                & "[ContactNumbers] = '" & txtTelephone.Text & "', [Address1] = '" & txtAddress1.Text & "', " _
                & "[Address2] = '" & txtAddress2.Text & "', [Address3] = '" & txtAddress3.Text & "'," _
                & "[Address4] = '" & txtAddress4.Text & "', [FaxNumber] = '" & txtFaxNumber.Text & "', " _
                & "[ConnectionType] = '" & cboConnectionType.Text & "', BranchCode = " & txtBranchCode.Text & " WHERE " _
                & "TransactionId = " & intSelectedTransaction & "", Cnn)
        End If
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Branch Details Saved Successfully", "Branch Details Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        strSelectedUser = Nothing
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Branch Details Save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Branches WHERE TransactionId = " & intSelectedTransaction & "", Cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("BranchName").ToString) Then txtName.Text = objReader("BranchName").ToString
            If Not IsDBNull(objReader("Location").ToString) Then txtLocation.Text = objReader("Location").ToString
            If Not IsDBNull(objReader("Manager").ToString) Then txtContactPerson.Text = objReader("Manager").ToString
            If Not IsDBNull(objReader("ContactNumbers").ToString) Then txtTelephone.Text = objReader("ContactNumbers").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("FaxNumber").ToString) Then txtFaxNumber.Text = objReader("FaxNumber").ToString
            If Not IsDBNull(objReader("ConnectionType").ToString) Then cboConnectionType.Text = objReader("ConnectionType").ToString
            If Not IsDBNull(objReader("BranchCode").ToString) Then txtBranchCode.Text = objReader("BranchCode").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Branch Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        strSelectedUser = Nothing
        Me.Close()
    End Sub

    Private Sub frmBranchDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If boolEditStatus = True Then
            LoadData()
            txtName.Enabled = False
        End If

    End Sub

    Private Sub txtBranchCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBranchCode.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

End Class