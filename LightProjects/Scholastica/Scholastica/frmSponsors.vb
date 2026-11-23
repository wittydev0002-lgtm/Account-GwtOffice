Imports System.ComponentModel
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSponsors
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtSponsorName.Text) Then
            MessageBox.Show("Please enter the sponsor name", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSponsorName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the sponsor address", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = Nothing
        If boolEditStatus = False Then
            strSql = "INSERT INTO SC_Sponsors ([Sponsor],[Address1],[Address2]," _
                & "[Address3],[Address4],[Telephone],[EmailAddress]) VALUES " _
                & "('" & txtSponsorName.Text & "', '" & txtAddress1.Text & "', " _
                & "'" & txtAddress2.Text & "', '" & txtAddress3.Text & "', " _
                & "'" & txtAddress4.Text & "', '" & txtTelephone.Text & "', " _
                & "'" & txtEmailAddress.Text & "')"
        Else
            strSql = "UPDATE SC_Sponsors SET Address1 = '" & txtAddress1.Text & "', " _
                & "Address2 = '" & txtAddress2.Text & "', Address3 = '" & txtAddress3.Text & "', " _
                & "Address4 = '" & txtAddress4.Text & "', Telephone = '" & txtTelephone.Text & "', " _
                & "EmailAddress = '" & txtEmailAddress.Text & "' WHERE Sponsor = '" & txtSponsorName.Text & "'"
        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Process has been completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Sponsors setup"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        If boolEditStatus = True Then txtSponsorName.Enabled = False
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM SC_Sponsors WHERE Sponsor = '" & strSelectedDescription & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        While objReader.Read
            If Not IsDBNull(objReader("Sponsor").ToString) Then txtSponsorName.Text = objReader("Sponsor").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Sponsors setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmSponsors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub txtSponsorName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSponsorName.KeyDown
        If e.KeyData = Keys.Enter Then txtAddress1.Focus()
    End Sub

    Private Sub txtAddress1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress1.KeyDown
        If e.KeyData = Keys.Enter Then txtAddress2.Focus()
    End Sub

    Private Sub txtAddress2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress2.KeyDown
        If e.KeyData = Keys.Enter Then txtAddress3.Focus()
    End Sub

    Private Sub txtAddress3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress3.KeyDown
        If e.KeyData = Keys.Enter Then txtAddress4.Focus()
    End Sub

    Private Sub txtAddress4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress4.KeyDown
        If e.KeyData = Keys.Enter Then txtTelephone.Focus()
    End Sub

    Private Sub txtTelephone_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelephone.KeyDown
        If e.KeyData = Keys.Enter Then txtEmailAddress.Focus()
    End Sub

    Private Sub txtEmailAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmailAddress.KeyDown
        If e.KeyData = Keys.Enter Then btnOK.Focus()
    End Sub

    Private Sub txtEmailAddress_Validating(sender As Object, e As CancelEventArgs) Handles txtEmailAddress.Validating
        If Not String.IsNullOrEmpty(txtEmailAddress.Text) Then
            If Not gwt_comm.IsEmailAddress(txtEmailAddress.Text) Then
                MessageBox.Show("This is not a valid email address", "Invalid Email Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub
End Class