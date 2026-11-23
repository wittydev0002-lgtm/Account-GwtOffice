Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPaypointSetup

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtPaypointCode.Text) Then
            MessageBox.Show("Please enter the Pay Point code", "Missing Pay Point Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPaypointCode.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtPaypointName.Text) Then
            MessageBox.Show("Please enter the Pay Point name", "Missing Pay Point Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPaypointName.Focus()
            Exit Sub
        End If

        Dim objCommand As Data.OleDb.OleDbCommand
        'Check that the department code is in existence
        If boolEditStatusTwo = False Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT OrdinalNo FROM SystemPayPoints WHERE " _
                & "OrdinalNo = " & txtPaypointCode.Text & "", Cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                MessageBox.Show("The Pay Point code is already in use, please enter a different code", "Duplicate Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtPaypointCode.Clear()
                txtPaypointCode.Focus()
                Exit Sub
                objReader.Close()
            End If
            objReader.Close()
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemPayPoints (OrdinalNo, PaypointName) " _
                        & "VALUES (" & txtPaypointCode.Text & ", '" & txtPaypointName.Text & "')", Cnn)
            objCommand.ExecuteNonQuery()
        Else
            objCommand = New Data.OleDb.OleDbCommand("UPDATE SystemPayPoints SET " _
                & "PaypointName = '" & txtPaypointName.Text & "' " _
                & "WHERE OrdinalNo = " & txtPaypointCode.Text & "", Cnn)
            objCommand.ExecuteNonQuery()
        End If
        MessageBox.Show("Details Saved Successfully", "Pay Point Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Pay Point Setup Failure"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub txtPayPointCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPaypointCode.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub frmPaypointSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If boolEditStatusTwo = True Then
            txtPaypointCode.Enabled = False
            txtPaypointCode.Text = intSelectedTransaction
            txtPaypointName.Text = strSelectedDescription
            txtPaypointName.SelectAll()
        End If
    End Sub

End Class
