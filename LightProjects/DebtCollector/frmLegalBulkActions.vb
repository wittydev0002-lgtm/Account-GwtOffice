Imports CommonLibrary.Commons

Public Class frmLegalBulkActions

    Private Sub frmLegalBulkActions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label1.BackColor = Color.Orange
        lblTotals.BackColor = Color.BlueViolet
    End Sub

    Private Sub frmLegalBulkActions_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 656 : Me.Height = 373
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtSelectedAction.Text) Then
            MessageBox.Show("Please select an action to update", "Missing Action", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnBrowse.Focus()
            Exit Sub
        End If
        SaveData()
    End Sub

    Private Sub chkOverride_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverride.CheckedChanged
        If chkOverride.Checked = True Then
            txtOverideAmt.Enabled = True
        Else
            txtOverideAmt.Enabled = False
        End If
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseErr

        If Not IsNumeric(lblTotals.Text) Then lblTotals.Text = "0.00"
        If Not IsNumeric(txtOverideAmt.Text) Then txtOverideAmt.Text = "0.00"

        Dim strSql As String = Nothing
        Dim strSqlAmount As String = Nothing

        With pb1
            .Visible = True
            .Maximum = arrSelectedItems.Count + 5
            .Value = 0
        End With

        boolRepeat = False

        boolSkipRecord = False

        For p As Integer = 0 To arrSelectedItems.Count - 1

            Dim strBuffer() As String = Split(arrSelectedItems.Item(p), "|")
            boolAbort = False

            Dim strPlaintifId As String = GetPlaintifId(strBuffer(0))
            Dim dblCosts As Double = GetActionCost(txtProcedureKey.Text, strPlaintifId)

            If chkOverride.Enabled = True Then
                dblCosts = CDbl(txtOverideAmt.Text)
            End If


            If CheckActionStatus(txtProcedureKey.Text, strBuffer(0)) = True Then
                If boolRepeat = False Then
                    Dim frm As New frmCustomMsg
                    frm.ShowDialog()
                End If
            End If

            If boolAbort = True Then Exit Sub

            If boolSkipRecord = False Then
                Dim intSpecialKey As Integer = gwt_comm.SpecialKey()
                strSql = "INSERT INTO LegalActions (DefendantId, ActionDate, TransactionDate, " _
                    & "ProcedureName, ActionKey, Comments, UserName, SpecialKey, PlaintifId) " _
                    & "VALUES ('" & strBuffer(0) & "', '" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', '" & Now & "', " _
                    & "'" & txtSelectedAction.Text & "', " & CInt(txtProcedureKey.Text) & ", " _
                    & "'" & txtComment.Text & "', '" & strUserName & "', " & intSpecialKey & ", '" & strPlaintifId & "')"

                strSqlAmount = "INSERT INTO DefendantTransactions ([DefendantId],[TransactionDate]," _
                    & "[ReferenceNumber],[FileId],[Description],[Debit],[Credit],[Comments]," _
                    & "[ReceiptNumber],[ReceivedBy]) VALUES ('" & strBuffer(0) & "', " _
                    & "'" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', '', '" & strBuffer(1) & "', " _
                    & "'" & txtSelectedAction.Text & "-" & txtProcedureKey.Text & "', " & dblCosts & ", " _
                    & "0, '" & txtComment.Text & "', '', '" & strUserName & "')"

                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                'Execute the amount update
                objCommand = New Data.OleDb.OleDbCommand(strSqlAmount, cnn)
                objCommand.ExecuteNonQuery()

                UpdateActionsTable(strBuffer(0), GetDefendantPlaintif(strBuffer(0)))

            End If

            pb1.Value = pb1.Value + 1

        Next

        pb1.Value = pb1.Maximum

        MessageBox.Show("Transaction has been updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Legal Procedures Options Load Failure"
        ShowErrorMessage()
    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        intSelectedStageId = 0
        strSelectedDescription = Nothing
        Dim frm As New frmBrowseStage
        frm.ShowDialog()
        txtProcedureKey.Text = intSelectedStageId
        txtSelectedAction.Text = strSelectedDescription
        txtOverideAmt.Text = "0.00"
    End Sub

End Class