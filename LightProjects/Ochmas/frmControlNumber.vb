Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmControlNumber

    Private Sub frmControlNumber_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Patients, Claims, Prescriptions FROM ControlNumbers", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then txtPatientNumbers.Text = CInt(objReader(0).ToString)
            If IsNumeric(objReader(1).ToString) Then txtClaims.Text = CInt(objReader(1).ToString)
            If IsNumeric(objReader(2).ToString) Then txtPrescriptions.Text = CInt(objReader(2).ToString)
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Control Numbers Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If Not IsNumeric(txtPatientNumbers.Text) Then
            MessageBox.Show("Please enter a numeric value for patient number", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPatientNumbers.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtClaims.Text) Then
            MessageBox.Show("Please enter a numeric value for claims number", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtClaims.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtPrescriptions.Text) Then
            MessageBox.Show("Please enter a numeric value for prescription number", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPrescriptions.Focus()
            Exit Sub
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET Patients = " & txtPatientNumbers.Text & ", " _
            & "Claims = " & txtClaims.Text & ", Prescriptions = " & txtPrescriptions.Text & "", cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Control Numbers have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Control Numbers Update"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
