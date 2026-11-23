Imports CommonLibrary.Commons

Public Class frmLegalPaymentPlanTerms

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If Not IsNumeric(txtDay.Text) Then
            MessageBox.Show("Please enter the expected payment day for each month", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDay.Focus()
            Exit Sub
        End If
        If IsNumeric(txtDay.Text) Then
            If CInt(txtDay.Text) <= 0 Then
                MessageBox.Show("Please enter a valid day for each month", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtDay.Focus()
                Exit Sub
            End If
        End If
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter the expected payment amount", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
        If Not IsDate(dpDateOn.Value) Then
            MessageBox.Show("Please enter the effective date", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dpDateOn.Focus()
            Exit Sub
        End If
        If CInt(txtProcedureKey.Text) <= 0 Then
            MessageBox.Show("Please select the action", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnBrowse.Focus()
            Exit Sub
        End If

        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = True Then
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM DefendantPaymentTerms WHERE TransactionId = " & intSelectedTransaction & "", cnn)
            objCommand.ExecuteNonQuery()
        End If
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO DefendantPaymentTerms ([TransDate]," _
            & "[EffectiveDate],[DayOfMonth],[Amount],[DefendantId],[ProcedureName], [ActionKey]) " _
            & "VALUES ('" & Now & "', '" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', " _
            & "" & txtDay.Text & ", " & txtAmount.Text & ", '" & strSelectedAccount & "', " _
            & "'" & txtSelectedAction.Text & "', " & CInt(txtProcedureKey.Text) & ")", cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Terms updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On payment plan terms"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [EffectiveDate],[DayOfMonth], CAST([Amount] AS DECIMAL (10,2)) AS [Amt], " _
            & "[ProcedureName], [ActionKey] FROM DefendantPaymentTerms WHERE [TransactionId] = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then dpDateOn.Value = CDate(objReader(0).ToString)
            If Not IsDBNull(objReader(1).ToString) Then txtDay.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtAmount.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then txtSelectedAction.Text = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then txtProcedureKey.Text = objReader(4).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On payment plan terms"
        ShowErrorMessage()
    End Sub

    Private Sub frmLegalPaymentPlanTerms_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then LoadData()
    End Sub

    Private Sub frmLegalPaymentPlanTerms_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 613 : Me.Height = 241
    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        intSelectedStageId = 0
        strSelectedDescription = Nothing
        Dim frm As New frmBrowseStage
        frm.ShowDialog()
        txtProcedureKey.Text = intSelectedStageId
        txtSelectedAction.Text = strSelectedDescription
    End Sub

End Class