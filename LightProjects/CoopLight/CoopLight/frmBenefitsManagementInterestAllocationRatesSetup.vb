Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBenefitsManagementInterestAllocationRatesSetup

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtAdminFeesRate.Text) Then
            MessageBox.Show("Please enter a valid admin fee rate", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAdminFeesRate.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtSubRate.Text) Then
            MessageBox.Show("Please enter a valid late subscriptions interest rate", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSubRate.Focus()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM BM_Interest_Parms", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO BM_Interest_Parms (AdminFeeRate, LateSubsInterestRate, InterestEffectiveDate) VALUES " _
            & "(" & txtAdminFeesRate.Text & ", " & txtSubRate.Text & ", '" & Format(dpEffectiveDate.Value, "dd-MMM-yyyy") & "')", cnn)
        objCommand.ExecuteNonQuery()
        gwt_comm.AssignDefaults()
        MessageBox.Show("Details saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Interest Rate Setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmBenefitsManagementInterestAllocationRatesSetup_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CAST(AdminFeeRate AS DECIMAL (10,2)), " _
            & "CAST(LateSubsInterestRate AS DECIMAL (10,2)), BM_Interest_Parms.InterestEffectiveDate FROM BM_Interest_Parms"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then txtAdminFeesRate.Text = Format(CDbl(objReader(0).ToString))
            If IsNumeric(objReader(1).ToString) Then txtSubRate.Text = Format(CDbl(objReader(1).ToString))
            If IsDate(objReader(2).ToString) Then dpEffectiveDate.Value = Format(CDate(objReader(2).ToString))
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Interest Rate Setup"
        ShowErrorMessage()
    End Sub

End Class
