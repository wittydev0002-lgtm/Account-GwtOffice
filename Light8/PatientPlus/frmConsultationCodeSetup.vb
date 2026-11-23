Imports System.ComponentModel
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmConsultationCodeSetup

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmConsultationCodeSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT Code, Description, CAST(ConversionFactor AS DECIMAL(10,2)), CAST(Units AS DECIMAL(10,2)), " _
            & "CAST(BaseFactor AS DECIMAL(10,2)), Flag, CAST(Value AS DECIMAL(10,2)), " _
            & "CAST(MedicalAidValue AS DECIMAL (10,2)) AS [Medical Value], " _
            & "CAST(OthersValue AS DECIMAL (10,2)) AS [Others Value] FROM OchmasSystemConsultations WHERE Code = '" & strSelectedCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtCode.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtDescription.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtConversionFactor.Text = Format(CDbl(objReader(2).ToString), "##0.00")
            If IsNumeric(objReader(3).ToString) Then txtUnits.Text = Format(CDbl(objReader(3).ToString), "##0.00")
            If IsNumeric(objReader(4).ToString) Then txtBaseFactor.Text = Format(CDbl(objReader(4).ToString), "##0.00")
            If Not IsDBNull(objReader(5).ToString) Then txtFlag.Text = objReader(5).ToString
            If IsNumeric(objReader(6).ToString) Then txtCashValue.Text = Format(CDbl(objReader(6).ToString), "##0.00")
            If IsNumeric(objReader(7).ToString) Then txtMedicalAidValue.Text = Format(CDbl(objReader(7).ToString), "##0.00")
            If IsNumeric(objReader(8).ToString) Then txtOtherValue.Text = Format(CDbl(objReader(8).ToString), "##0.00")
        End If
        objReader.Close()
        txtCode.Enabled = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On consultation codes setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmConsultationCodeSetup_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 600 : Me.Height = 415
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtCode.Text) Then
            MessageBox.Show("Please enter the consultation code", "Missing Consultation Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCode.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter the description", "Missing Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Select()
            Exit Sub
        End If

        If Not IsNumeric(txtCashValue.Text) Then
            MessageBox.Show("Please enter valid figure for value", "Missing Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCashValue.Select()
            Exit Sub
        End If

        If Not IsNumeric(txtConversionFactor.Text) Then txtConversionFactor.Text = "0.00"
        If Not IsNumeric(txtUnits.Text) Then txtUnits.Text = "0.00"
        If Not IsNumeric(txtBaseFactor.Text) Then txtBaseFactor.Text = "0.00"

        If String.IsNullOrEmpty(txtFlag.Text) Then txtFlag.Text = "NONE"

        If Not IsNumeric(txtMedicalAidValue.Text) Then txtMedicalAidValue.Text = "0.00"
        If Not IsNumeric(txtOtherValue.Text) Then txtOtherValue.Text = "0.00"

        Dim strSql As String = Nothing
        If boolEditStatus = False Then
            strSql = "INSERT INTO OchmasSystemConsultations (Code, Description, ConversionFactor, Units, BaseFactor, Flag, Value, MedicalAidValue, OthersValue) " _
                & "VALUES ('" & txtCode.Text & "', '" & txtDescription.Text & "', " & CDbl(txtConversionFactor.Text) & ", " _
                & "" & CDbl(txtUnits.Text) & ", " & CDbl(txtBaseFactor.Text) & ", '" & txtFlag.Text & "', " & CDbl(txtCashValue.Text) & ", " _
                & "" & CDbl(txtMedicalAidValue.Text) & ", " & CDbl(txtOtherValue.Text) & ")"
        Else
            strSql = "UPDATE OchmasSystemConsultations SET Description = '" & txtDescription.Text & "', " _
                & "ConversionFactor = " & CDbl(txtConversionFactor.Text) & ", Units = " & CDbl(txtUnits.Text) & ", " _
                & "BaseFactor = " & CDbl(txtBaseFactor.Text) & ", Flag = '" & txtFlag.Text & "', Value = " & CDbl(txtCashValue.Text) & ", " _
                & "MedicalAidValue = " & CDbl(txtMedicalAidValue.Text) & ", OthersValue = " & CDbl(txtOtherValue.Text) & " WHERE Code = '" & txtCode.Text & "'"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Process has been completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On consultation codes setup"
        ShowErrorMessage()
    End Sub

    Private Sub txtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtDescription.Select()
            txtDescription.SelectAll()
        End If
    End Sub

    Private Sub txtDescription_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescription.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtConversionFactor.Select()
            txtConversionFactor.SelectAll()
        End If
    End Sub

    Private Sub txtConversionFactor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConversionFactor.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtUnits.Select()
            txtUnits.SelectAll()
        End If
    End Sub

    Private Sub txtUnits_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUnits.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtBaseFactor.Select()
            txtBaseFactor.SelectAll()
        End If
    End Sub

    Private Sub txtBaseFactor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBaseFactor.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtFlag.Select()
            txtFlag.SelectAll()
        End If
    End Sub

    Private Sub txtFlag_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFlag.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtCashValue.Select()
            txtCashValue.SelectAll()
        End If
    End Sub

    Private Sub txtCashValue_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCashValue.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtMedicalAidValue.Select()
            txtMedicalAidValue.SelectAll()
        End If
    End Sub

    Private Sub txtMedicalAidValue_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMedicalAidValue.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtOtherValue.Select()
            txtOtherValue.SelectAll()
        End If
    End Sub

    Private Sub txtOtherValue_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtherValue.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnOK.Select()
        End If
    End Sub

    Private Sub txtOtherValue_Validating(sender As Object, e As CancelEventArgs) Handles txtOtherValue.Validating
        If IsNumeric(txtOtherValue.Text) Then txtOtherValue.Text = Format(CDbl(txtOtherValue.Text), "##0.00") Else txtOtherValue.Text = "0.00"
    End Sub

    Private Sub txtMedicalAidValue_Validating(sender As Object, e As CancelEventArgs) Handles txtMedicalAidValue.Validating
        If IsNumeric(txtMedicalAidValue.Text) Then txtMedicalAidValue.Text = Format(CDbl(txtMedicalAidValue.Text), "##0.00") Else txtMedicalAidValue.Text = "0.00"
    End Sub

    Private Sub txtConversionFactor_Validating(sender As Object, e As CancelEventArgs) Handles txtConversionFactor.Validating
        If IsNumeric(txtConversionFactor.Text) Then txtConversionFactor.Text = Format(CDbl(txtConversionFactor.Text), "##0.00") Else txtConversionFactor.Text = "0.00"
    End Sub

    Private Sub txtUnits_Validating(sender As Object, e As CancelEventArgs) Handles txtUnits.Validating
        If IsNumeric(txtUnits.Text) Then txtUnits.Text = Format(CDbl(txtUnits.Text), "##0.00") Else txtUnits.Text = "0.00"
    End Sub

    Private Sub txtBaseFactor_Validating(sender As Object, e As CancelEventArgs) Handles txtBaseFactor.Validating
        If IsNumeric(txtBaseFactor.Text) Then txtBaseFactor.Text = Format(CDbl(txtBaseFactor.Text), "##0.00") Else txtBaseFactor.Text = "0.00"
    End Sub
End Class