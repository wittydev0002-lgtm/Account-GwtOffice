Imports CommonLibrary.Commons

Public Class frmLegalExports

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        SaveFileDialog1.ShowDialog()
        txtFileName.Text = SaveFileDialog1.FileName
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtFileName.Text) Then
            MessageBox.Show("Please enter a valid file name", "Invalid File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFileName.Focus()
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        Dim arrData As New ArrayList
        Dim strDataInsertSql As String = Nothing

        Dim strSql As String = Nothing

        Dim strSqlCustomers As String = gwt_comm.ScriptCustomerData()
        'get the actions details
        strSql = gwt_comm.ScriptTableFields("LegalActions", "SELECT")
        strSql = strSql & " WHERE TransactionDate BETWEEN '" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(DateAdd(DateInterval.Day, 1, dpEndDate.Value), "dd-MMM-yyyy") & "'"
        strDataInsertSql = strDataInsertSql & strSqlCustomers & vbCrLf
        strDataInsertSql = strDataInsertSql & gwt_comm.ScriptDataInsertStatement(strSql, "LegalActions")
        'Get the payment details
        strSql = Nothing
        strSql = gwt_comm.ScriptTableFields("DefendantTransactions", "SELECT")
        strSql = strSql & " WHERE TransactionDate BETWEEN '" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "' AND (Debit <> 0 OR Credit <> 0)"
        strDataInsertSql = strDataInsertSql & gwt_comm.ScriptDataInsertStatement(strSql, "DefendantTransactions")

        'Get the cashbook details
        strSql = Nothing
        strSql = gwt_comm.ScriptTableFields("TrustTransactions", "SELECT")
        strSql = strSql & " WHERE TransactionDate BETWEEN '" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "'"
        strDataInsertSql = strDataInsertSql & gwt_comm.ScriptDataInsertStatement(strSql, "TrustTransactions")

        'Get the cashbook details
        strSql = Nothing
        strSql = gwt_comm.ScriptTableFields("TrustCashbookTransactions", "SELECT")
        strSql = strSql & " WHERE TransactionDate BETWEEN '" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "'"
        strDataInsertSql = strDataInsertSql & gwt_comm.ScriptDataInsertStatement(strSql, "TrustCashbookTransactions")

        Dim strId As String = Format(CInt(Now.Day), "00") & Format(CInt(Now.Month), "00") & Format(CInt(Now.Year), "0000") & Now.Hour & Now.Minute & ".dat"
        Dim FileWriter As New System.IO.StreamWriter(txtFileName.Text & strId, False)
        FileWriter.WriteLine(strDataInsertSql)
        FileWriter.Close()

        Cursor = Cursors.Default
        MessageBox.Show("Export file created successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Data Export Error"
        ShowErrorMessage()
    End Sub

End Class
