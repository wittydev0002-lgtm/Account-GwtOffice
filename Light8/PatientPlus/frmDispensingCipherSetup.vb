Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDispensingCipherSetup

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtCipher.Text) Then
            MessageBox.Show("Please enter the cipher", "Missing Cipher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCipher.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter the cipher description", "Missing Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = True Then
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM OchmasDispensingCiphers WHERE Code = '" & strSelectedCode & "'", cnn)
            objCommand.ExecuteNonQuery()
        End If
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO OchmasDispensingCiphers ([Code], [Instruction]) " _
            & "VALUES ('" & txtCipher.Text & "', '" & txtDescription.Text & "')", cnn)
        objCommand.ExecuteNonQuery()

        If boolEditStatus = True Then
            MessageBox.Show("Dispensing Cipher has been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            If MessageBox.Show("Dispensing Cipher has been saved successfully." & vbCrLf & "Do you want to add another cipher?", "Process Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                txtCipher.Text = Nothing
                txtDescription.Text = Nothing
                txtCipher.Focus()
            Else
                Me.Close()
            End If
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Error while saving dispensing ciphers"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Code, Instruction FROM OchmasDispensingCiphers " _
            & "WHERE Code = '" & strSelectedCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtCipher.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtDescription.Text = objReader(1).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Error while loading dispensing ciphers"
        ShowErrorMessage()
    End Sub

    Private Sub frmDispensingCipherSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then
            LoadData()
            txtCipher.Enabled = False
        End If
    End Sub

    Private Sub frmDispensingCipherSetup_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 500 : Me.Height = 260
    End Sub

End Class
