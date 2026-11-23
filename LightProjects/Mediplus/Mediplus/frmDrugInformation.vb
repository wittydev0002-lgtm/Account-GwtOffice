Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDrugInformation

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM OchmasSystemMedicinesInformation " _
            & "WHERE DrugCode = '" & strDrugCode & "'", cnn)
        objCommand.ExecuteNonQuery()

        Dim strSql As String = "INSERT INTO OchmasSystemMedicinesInformation ([DrugCode], [GeneralInfor], " _
            & "[Uses], [Intake], [SideEffects], [Precautions], [DrugInteraction], [MissedDosage], [Storage]) VALUES " _
            & "('" & strDrugCode & "', '" & txtAbout.Text & "', '" & txtUses.Text & "', '" & txtIntake.Text & "', " _
            & "'" & txtSideEffects.Text & "', '" & txtPrecaution.Text & "', '" & txtInteraction.Text & "', " _
            & "'" & txtMissedDosage.Text & "', '" & txtStorage.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Drug details saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On drug  information update"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [GeneralInfor], [Uses], [Intake], [SideEffects], [Precautions], " _
            & "[DrugInteraction], [MissedDosage], [Storage] FROM OchmasSystemMedicinesInformation WHERE DrugCode = '" & strDrugCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtAbout.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtUses.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtIntake.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then txtSideEffects.Text = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then txtPrecaution.Text = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then txtInteraction.Text = objReader(5).ToString
            If Not IsDBNull(objReader(6).ToString) Then txtMissedDosage.Text = objReader(6).ToString
            If Not IsDBNull(objReader(7).ToString) Then txtStorage.Text = objReader(7).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On drug  information update"
        ShowErrorMessage()
    End Sub

    Private Sub frmDrugInformation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        VOutlookNavPane1.SelectItem(VOutlookItem1)
        LoadData()
    End Sub

End Class