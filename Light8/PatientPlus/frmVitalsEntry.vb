Imports System.ComponentModel
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmVitalsEntry

    Private Sub frmVitalsEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPatientNames.Text = UCase(strSelectedAccountName)
        lblPatientId.Text = intSelectedPatient
        If boolEditStatus = True Then
            LoadData()
        End If
    End Sub

    Private Sub frmVitalsEntry_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 670 : Me.Height = 475
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing
        If boolEditStatus = False Then
            strSql = "INSERT INTO OchmasKeyVitals (Pid, Temperature, Weight, Height, " _
                & "Systolic, Diastolic, Pulse, Breathing, Comments, TransDate) VALUES " _
                & "(" & lblPatientId.Text & ", " & txtTemperature.Text & ", " & txtWeight.Text & ", " _
                & "" & txtHeight.Text & ", " & txtSystolic.Text & ", " & txtDiastolic.Text & ", " _
                & "" & txtPulse.Text & ", " & txtBreathingRate.Text & ", '" & txtComments.Text & "', " _
                & "'" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "')"
        Else
            strSql = "UPDATE OchmasKeyVitals Set Temperature = " & txtTemperature.Text & ", " _
                & "Weight = " & txtWeight.Text & ", Height = " & txtHeight.Text & ", Systolic = " & txtSystolic.Text & ", " _
                & "Diastolic = " & txtDiastolic.Text & ", Pulse = " & txtPulse.Text & ", Breathing = " & txtBreathingRate.Text & ", " _
                & "Comments = '" & txtComments.Text & "' WHERE TransactionId = " & lblTransId.Text & ""
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default

        MessageBox.Show("Process has been completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On primary examination details save"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtTemperature.Text) Then txtTemperature.Text = 0
        If Not IsNumeric(txtWeight.Text) Then txtWeight.Text = 0
        If Not IsNumeric(txtSystolic.Text) Then txtSystolic.Text = 0
        If Not IsNumeric(txtDiastolic.Text) Then txtDiastolic.Text = 0
        If Not IsNumeric(txtPulse.Text) Then txtPulse.Text = 0
        If Not IsNumeric(txtBreathingRate.Text) Then txtBreathingRate.Text = 0
        If Not IsNumeric(txtHeight.Text) Then txtHeight.Text = 0

        If CInt(txtTemperature.Text) = 0 And CInt(txtWeight.Text) = 0 And CInt(txtSystolic.Text) = 0 _
            And CInt(txtDiastolic.Text) = 0 And CInt(txtPulse.Text) = 0 And CInt(txtBreathingRate.Text) = 0 And CInt(txtHeight.Text) = 0 Then
            MessageBox.Show("You have not entered any valid values. Please re-enter or cancel process altogether", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTemperature.Select()
            Exit Sub
        End If

        If CInt(txtSystolic.Text) = 0 And CInt(txtDiastolic.Text) <> 0 Then
            MessageBox.Show("Both values for systolic and diastolic must be greater than 0", "Invalid BP Values", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSystolic.Select()
            Exit Sub
        End If

        If CInt(txtSystolic.Text) <> 0 And CInt(txtDiastolic.Text) = 0 Then
            MessageBox.Show("Both values for systolic and diastolic must be greater than 0", "Invalid BP Values", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDiastolic.Select()
            Exit Sub
        End If

        SaveData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        lblTransId.Text = intSelectedTransaction
        Dim strSql As String = "SELECT * FROM OchmasKeyVitals WHERE TransactionId = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader("Temperature").ToString) Then txtTemperature.Text = Format(CDbl(objReader("Temperature").ToString), "##0.00")
            If IsNumeric(objReader("Weight").ToString) Then txtWeight.Text = Format(CDbl(objReader("Weight").ToString), "##0.00")
            If IsNumeric(objReader("Height").ToString) Then txtHeight.Text = Format(CDbl(objReader("Height").ToString), "##0.00")
            If IsNumeric(objReader("Systolic").ToString) Then txtSystolic.Text = Format(CDbl(objReader("Systolic").ToString), "##0.00")
            If IsNumeric(objReader("Diastolic").ToString) Then txtDiastolic.Text = Format(CDbl(objReader("Diastolic").ToString), "##0.00")
            If IsNumeric(objReader("Pulse").ToString) Then txtPulse.Text = Format(CDbl(objReader("Pulse").ToString), "##0.00")
            If IsNumeric(objReader("Breathing").ToString) Then txtBreathingRate.Text = Format(CDbl(objReader("Breathing").ToString), "##0.00")
            If IsDBNull(objReader("Comments").ToString) Then txtComments.Text = objReader("Comments").ToString
            If IsNumeric(objReader("Pid").ToString) Then lblPatientId.Text = objReader("Pid").ToString
        End If
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On primary examination details load"
        ShowErrorMessage()
    End Sub

    Private Sub txtTemperature_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTemperature.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtWeight.Select()
            txtWeight.SelectAll()
        End If
    End Sub

    Private Sub txtWeight_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWeight.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtSystolic.Select()
            txtSystolic.SelectAll()
        End If
    End Sub

    Private Sub txtSystolic_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSystolic.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtDiastolic.Select()
            txtDiastolic.SelectAll()
        End If
    End Sub

    Private Sub txtDiastolic_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDiastolic.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtPulse.Select()
            txtPulse.SelectAll()
        End If
    End Sub

    Private Sub txtPulse_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPulse.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtHeight.Select()
            txtHeight.SelectAll()
        End If
    End Sub

    Private Sub txtHeight_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHeight.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtBreathingRate.Select()
            txtBreathingRate.SelectAll()
        End If
    End Sub

    Private Sub txtBreathingRate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBreathingRate.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtComments.Select()
            txtComments.SelectAll()
        End If
    End Sub

    Private Sub txtComments_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComments.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnOK.Select()
        End If
    End Sub

    Private Sub txtTemperature_Validating(sender As Object, e As CancelEventArgs) Handles txtTemperature.Validating
        If Not IsNumeric(txtTemperature.Text) Then txtTemperature.Text = "0.00"
    End Sub

    Private Sub txtWeight_Validating(sender As Object, e As CancelEventArgs) Handles txtWeight.Validating
        If Not IsNumeric(txtWeight.Text) Then txtWeight.Text = "0.00"
    End Sub

    Private Sub txtSystolic_Validating(sender As Object, e As CancelEventArgs) Handles txtSystolic.Validating
        If Not IsNumeric(txtSystolic.Text) Then txtSystolic.Text = "0.00"
    End Sub

    Private Sub txtDiastolic_Validating(sender As Object, e As CancelEventArgs) Handles txtDiastolic.Validating
        If Not IsNumeric(txtDiastolic.Text) Then txtDiastolic.Text = "0.00"
    End Sub

    Private Sub txtPulse_Validating(sender As Object, e As CancelEventArgs) Handles txtPulse.Validating
        If Not IsNumeric(txtPulse.Text) Then txtPulse.Text = "0.00"
    End Sub

    Private Sub txtHeight_Validating(sender As Object, e As CancelEventArgs) Handles txtHeight.Validating
        If Not IsNumeric(txtHeight.Text) Then txtHeight.Text = "0.00"
    End Sub

    Private Sub txtBreathingRate_Validating(sender As Object, e As CancelEventArgs) Handles txtBreathingRate.Validating
        If Not IsNumeric(txtBreathingRate.Text) Then txtBreathingRate.Text = "0.00"
    End Sub

End Class