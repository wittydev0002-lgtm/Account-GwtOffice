Imports System.Drawing
Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMocReturns

    Dim boolPriorStatus As Boolean

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Dim m_print As New PrintControl.ControlPrint
        m_print.SetControl(printPanel)
        Dim ppd As New EnhancedPrintPreviewDialog
        ppd.Document = DirectCast(m_print, PrintDocument)
        ppd.ShowDialog()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        IntitializeSave()
    End Sub

    Private Sub IntitializeSave()
        If String.IsNullOrEmpty(txtBookNo.Text) Then
            MessageBox.Show("Please enter the book number", "Missing Book Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtBookNo.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAdviceNo.Text) Then
            MessageBox.Show("Please enter the advice number", "Missing Advice Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAdviceNo.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtCaseNo.Text) Then
            MessageBox.Show("Please enter the case number", "Missing Case Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCaseNo.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtPlaintif.Text) Then
            MessageBox.Show("Please enter the correct case number", "Missing Plaintiff", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCaseNo.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDefendant.Text) Then
            MessageBox.Show("Please enter the correct case number", "Missing Defendant", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCaseNo.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAddress.Text) Then
            MessageBox.Show("Please enter the correct address", "Missing Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCaseNo.Focus()
            Exit Sub
        End If

        If chkAutoCreateCase.Checked = True Then
            If IsValidCase(txtCaseNo.Text) = False Then
                boolAbort = False
                Dim frm As New frmMocBilling
                frm.ShowDialog()
                If boolAbort = True Then Exit Sub
                Dim strSql As String = "INSERT INTO MocCases ([CaseNo], " _
                    & "[DateIn], [Plaintiff], [Defendant], [DebtorId], [Status], Remarks) VALUES " _
                    & "('" & txtCaseNo.Text & "', '" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', " _
                    & "'" & txtPlaintif.Text & "', " _
                    & "'" & txtDefendant.Text & "', '" & strSelectedCode & "', 'OPEN', 'RECORD CREATED THROUGH RETURN UPDATE')"
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If
        End If

        SaveDetails()

        If boolEditStatus = True Then
            Me.Close()
        Else
            ClearControls()
            txtCaseNo.Focus()
            NextAdviceNumber()
        End If
    End Sub

    Private Sub ClearControls()
        txtCaseNo.Text = Nothing
        txtPlaintif.Text = Nothing
        txtDefendant.Text = Nothing
        chkOffice.Checked = False
        chkOpt1a.Checked = False
        chkOpt1b.Checked = False
        chkOpt2a.Checked = False
        chkOpt2b.Checked = False
        chkOpt3a.Checked = False
        chkOpt3b.Checked = False
        chkOpt3c.Checked = False
        chkPost.Checked = False
        chkSum.Checked = False
        chkSumCI.Checked = False
        chkWarArr.Checked = False
        chkWarArrestOpt1.Checked = False
        chkWarArrestOpt2.Checked = False
        chkWarExec.Checked = False
        chkWarrantInFull.Checked = False
        chkWarrentAttachment.Checked = False
        txtRemarks.Text = Nothing

        txtAdvertsingAmt.Text = "0.00"
        txtAttemptServeAmt.Text = "0.00"
        txtCartageAmt.Text = "0.00"
        txtCommissionAmt.Text = "0.00"
        txtCourtAmt.Text = "0.00"
        txtEscortAmt.Text = "0.00"
        txtInventoriesAmt.Text = "0.00"

        txtLocksmithAmt.Text = "0.00"
        txtNoticeAmt.Text = "0.00"
        txtOfficeAmt.Text = "0.00"
        txtOpt1AmtA.Text = "0.00"
        txtOpt1AmtB.Text = "0.00"
        txtOpt2AmtA.Text = "0.00"
        txtOpt2AmtB.Text = "0.00"
        txtOpt3AmtA.Text = "0.00"
        txtOpt3AmtB.Text = "0.00"
        txtOpt3AmtC.Text = "0.00"
        txtOther.Text = Nothing

        txtPostAmt.Text = "0.00"
        txtSecurityAmt.Text = "0.00"
        txtWaitingAmt.Text = "0.00"
        txtWarrantAttachAmt.Text = "0.00"
        txtWarrantFullAmt.Text = "0.00"
        txtWarrentDeliveryAmt.Text = "0.00"
        txtTotalCosts.Text = "0.00" 'This is the totals box
        txtPlaintifAgent.Text = Nothing

        If MessageBox.Show("Do you want to retain basic data to next return", "Confirm Data Retention", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            txtAddress.Text = Nothing
            txtIssuingCourt.Text = Nothing
            txtKmAt1.Text = "0.00"
            txtKmAt2.Text = "0.00"
            txtOtherAmt.Text = "0.00"
            txtPostageAmt.Text = "0.00"
        End If

        chkSum.Checked = True

    End Sub

    Private Sub ComputeTotal()

        txtTotalCosts.Text = "0.00"

        Dim dblTotal As Double = 0

        If IsNumeric(txtAdvertsingAmt.Text) Then dblTotal = dblTotal + CDbl(txtAdvertsingAmt.Text)
        If IsNumeric(txtAttemptServeAmt.Text) Then dblTotal = dblTotal + CDbl(txtAttemptServeAmt.Text)
        If IsNumeric(txtCartageAmt.Text) Then dblTotal = dblTotal + CDbl(txtCartageAmt.Text)
        If IsNumeric(txtCommissionAmt.Text) Then dblTotal = dblTotal + CDbl(txtCommissionAmt.Text)
        If IsNumeric(txtCourtAmt.Text) Then dblTotal = dblTotal + CDbl(txtCourtAmt.Text)
        If IsNumeric(txtEscortAmt.Text) Then dblTotal = dblTotal + CDbl(txtEscortAmt.Text)
        If IsNumeric(txtInventoriesAmt.Text) Then dblTotal = dblTotal + CDbl(txtInventoriesAmt.Text)
        'If IsNumeric(txtKmAt1.Text) Then dblTotal = dblTotal + CDbl(txtKmAt1.Text)
        If IsNumeric(txtKmAt2.Text) Then dblTotal = dblTotal + CDbl(txtKmAt2.Text)
        If IsNumeric(txtLocksmithAmt.Text) Then dblTotal = dblTotal + CDbl(txtLocksmithAmt.Text)
        If IsNumeric(txtNoticeAmt.Text) Then dblTotal = dblTotal + CDbl(txtNoticeAmt.Text)
        If IsNumeric(txtOfficeAmt.Text) Then dblTotal = dblTotal + CDbl(txtOfficeAmt.Text)
        If IsNumeric(txtOpt1AmtA.Text) Then dblTotal = dblTotal + CDbl(txtOpt1AmtA.Text)
        If IsNumeric(txtOpt1AmtB.Text) Then dblTotal = dblTotal + CDbl(txtOpt1AmtB.Text)
        If IsNumeric(txtOpt2AmtA.Text) Then dblTotal = dblTotal + CDbl(txtOpt2AmtA.Text)
        If IsNumeric(txtOpt2AmtB.Text) Then dblTotal = dblTotal + CDbl(txtOpt2AmtB.Text)
        If IsNumeric(txtOpt3AmtA.Text) Then dblTotal = dblTotal + CDbl(txtOpt3AmtA.Text)
        If IsNumeric(txtOpt3AmtB.Text) Then dblTotal = dblTotal + CDbl(txtOpt3AmtB.Text)
        If IsNumeric(txtOpt3AmtC.Text) Then dblTotal = dblTotal + CDbl(txtOpt3AmtC.Text)
        If IsNumeric(txtOtherAmt.Text) Then dblTotal = dblTotal + CDbl(txtOtherAmt.Text)
        If IsNumeric(txtPostageAmt.Text) Then dblTotal = dblTotal + CDbl(txtPostageAmt.Text)
        If IsNumeric(txtPostAmt.Text) Then dblTotal = dblTotal + CDbl(txtPostAmt.Text)
        If IsNumeric(txtSecurityAmt.Text) Then dblTotal = dblTotal + CDbl(txtSecurityAmt.Text)
        If IsNumeric(txtWaitingAmt.Text) Then dblTotal = dblTotal + CDbl(txtWaitingAmt.Text)
        If IsNumeric(txtWarrantAttachAmt.Text) Then dblTotal = dblTotal + CDbl(txtWarrantAttachAmt.Text)
        If IsNumeric(txtWarrantFullAmt.Text) Then dblTotal = dblTotal + CDbl(txtWarrantFullAmt.Text)
        If IsNumeric(txtWarrentDeliveryAmt.Text) Then dblTotal = dblTotal + CDbl(txtWarrentDeliveryAmt.Text)

        If IsNumeric(txtWarArrestAmtOpt2Amt.Text) Then dblTotal = dblTotal + CDbl(txtWarArrestAmtOpt2Amt.Text)
        If IsNumeric(txtWarArrestAmtOpt1Amt.Text) Then dblTotal = dblTotal + CDbl(txtWarArrestAmtOpt1Amt.Text)
        If IsNumeric(txtNullaBonaAmt.Text) Then dblTotal = dblTotal + CDbl(txtNullaBonaAmt.Text)

        txtTotalCosts.Text = Format(dblTotal, "##0.00") 'This is the totals box

    End Sub

    Private Sub SaveDetails()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If boolEditStatus = True Then
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM MocReturns WHERE TransactionId = " & intSelectedTransaction & "", cnn)
            objCommand.ExecuteNonQuery()
        End If

        Dim strTime As String = "00:00"
        Dim strIssuingCourt As String = Nothing
        If Not String.IsNullOrEmpty(txtIssuingCourt.Text) Then strIssuingCourt = txtIssuingCourt.Text

        Dim strCaseNo As String = Nothing
        If Not String.IsNullOrEmpty(txtCaseNo.Text) Then strCaseNo = txtCaseNo.Text

        Dim strProcedureName As String = Nothing

        If chkSum.Checked = True Then strProcedureName = "SUMMONS"
        If chkSumCI.Checked = True Then strProcedureName = "SUMMONS CI"
        If chkWarArr.Checked = True Then strProcedureName = "WARRENT OF ARREST"
        If chkWarExec.Checked = True Then strProcedureName = "WARRENT OF EXECUTION"

        Dim strServiceAddress As String = Nothing
        If Not String.IsNullOrEmpty(txtAddress.Text) Then strServiceAddress = txtAddress.Text

        Dim dblMileage As Double = 0
        If IsNumeric(txtKmAt1.Text) Then dblMileage = txtKmAt1.Text

        Dim dblMileageCost As Double = 0
        If IsNumeric(txtKmAt2.Text) Then dblMileageCost = txtKmAt2.Text

        Dim strServedOnRuleOneOption As String = Nothing
        Dim dblServedOnRuleOneCost As Double = 0

        If chkOpt1a.Checked = True Then
            strServedOnRuleOneOption = "1"
            If IsNumeric(txtOpt1AmtA.Text) Then dblServedOnRuleOneCost = CDbl(txtOpt1AmtA.Text)
        End If
        If chkOpt1b.Checked = True Then
            strServedOnRuleOneOption = "2"
            If IsNumeric(txtOpt1AmtB.Text) Then dblServedOnRuleOneCost = CDbl(txtOpt1AmtB.Text)
        End If

        Dim strServedOnRuleTwoOption As String = Nothing
        Dim dblServedOnRuleTwoCost As Double = 0
        If chkOpt2a.Checked = True Then
            strServedOnRuleTwoOption = "1"
            If IsNumeric(txtOpt2AmtA.Text) Then dblServedOnRuleTwoCost = CDbl(txtOpt2AmtA.Text)
        End If
        If chkOpt2b.Checked = True Then
            strServedOnRuleTwoOption = "2"
            If IsNumeric(txtOpt2AmtB.Text) Then dblServedOnRuleTwoCost = CDbl(txtOpt2AmtB.Text)
        End If


        Dim strServedOnRulethreeOption As String = Nothing
        Dim dblServedOnRuleThreeCost As Double = 0
        If chkOpt3a.Checked = True Then
            strServedOnRulethreeOption = "1"
            If IsNumeric(txtOpt3AmtA.Text) Then dblServedOnRuleThreeCost = CDbl(txtOpt3AmtA.Text)
        End If
        If chkOpt3b.Checked = True Then
            strServedOnRulethreeOption = "2"
            If IsNumeric(txtOpt3AmtB.Text) Then dblServedOnRuleThreeCost = CDbl(txtOpt3AmtB.Text)
        End If
        If chkOpt3c.Checked = True Then
            strServedOnRulethreeOption = "3"
            If IsNumeric(txtOpt3AmtC.Text) Then dblServedOnRuleThreeCost = CDbl(txtOpt3AmtC.Text)
        End If

        Dim strServedOnCompanyOfficeName As String = Nothing
        Dim dblServedOnCompanyOfficeCosts As Double = 0
        If chkOffice.Checked = True Then strServedOnCompanyOfficeName = "Y"
        If IsNumeric(txtOfficeAmt.Text) Then dblServedOnCompanyOfficeCosts = CDbl(txtOfficeAmt.Text)

        Dim strServedOnRegisteredMail As String = Nothing
        Dim dblServedOnRegisteredMailCosts As Double = 0
        If chkPost.Checked Then
            strServedOnRegisteredMail = "Y"
            If IsNumeric(txtPostAmt.Text) Then dblServedOnRegisteredMailCosts = CDbl(txtPostAmt.Text)
        End If

        Dim strServedOnCourtOrder As String = Nothing
        Dim dblServedOnCourtOrderCosts As Double = 0
        If chkCourt.Checked Then
            strServedOnCourtOrder = "Y"
            If IsNumeric(txtCourtAmt.Text) Then dblServedOnCourtOrderCosts = CDbl(txtCourtAmt.Text)
        End If

        Dim strAttemptedServiceExecution As String = Nothing
        Dim dblAttemptedServiceExecutionCosts As Double = 0
        If chkAttemptService.Checked Then
            strAttemptedServiceExecution = "Y"
            If IsNumeric(txtAttemptServeAmt.Text) Then dblAttemptedServiceExecutionCosts = CDbl(txtAttemptServeAmt.Text)
        End If

        Dim strExecutionCessionOptions As String = Nothing
        Dim dblExecutionCessionCosts As Double = 0
        If chkExecutionStop.Checked Then
            strExecutionCessionOptions = "Y"
            If IsNumeric(txtExecutionWithdrawAmt.Text) Then dblExecutionCessionCosts = CDbl(txtExecutionWithdrawAmt.Text)
        End If

        Dim strExecutionCessionReasons As String = Nothing
        Dim strWarrantOptions As String = Nothing


        Dim dblWarrantCosts As Double = 0
        Dim strWarrantReasons As String = Nothing

        Dim strWarrantOfArrestOptions As String = Nothing
        Dim dblWarrantOfArrestCosts As Double = 0
        If chkWarArrestOpt1.Checked = True Then
            strWarrantOfArrestOptions = "1"
            If IsNumeric(txtWarArrestAmtOpt1Amt.Text) Then dblWarrantOfArrestCosts = CDbl(txtWarArrestAmtOpt1Amt.Text)
        End If
        If chkWarArrestOpt2.Checked = True Then
            strWarrantOfArrestOptions = "2"
            If IsNumeric(txtWarArrestAmtOpt2Amt.Text) Then dblWarrantOfArrestCosts = CDbl(txtWarArrestAmtOpt2Amt.Text)
        End If

        Dim strWarrantOfAttachmentOptions As String = Nothing
        Dim dblWarrantOfAttachmentCosts As Double = 0
        If chkWarrentAttachment.Checked Then
            strWarrantOfAttachmentOptions = "Y"
            If IsNumeric(txtWarrantAttachAmt.Text) Then dblWarrantOfAttachmentCosts = CDbl(txtWarrantAttachAmt.Text)
        End If

        Dim StrWarrantOfAttachmentPaidInFull As String = Nothing
        Dim dblWarrantOfAttachmentPaidInFullCosts As Double = 0
        If chkWarrantInFull.Checked Then
            StrWarrantOfAttachmentPaidInFull = "Y"
            If IsNumeric(txtWarrantFullAmt.Text) Then dblWarrantOfAttachmentPaidInFullCosts = CDbl(txtWarrantFullAmt.Text)
        End If

        Dim StrWarrantOfAttachmentNullaBona As String = Nothing
        Dim dblWarrantOfAttachmentNullaBonaCosts As Double = 0
        If chkNullaBona.Checked = True Then
            StrWarrantOfAttachmentNullaBona = "Y"
            If IsNumeric(txtNullaBonaAmt.Text) Then dblWarrantOfAttachmentNullaBonaCosts = CDbl(txtNullaBonaAmt.Text)
        End If

        Dim strRemarks As String = Nothing
        If Not String.IsNullOrEmpty(txtRemarks.Text) Then strRemarks = txtRemarks.Text

        Dim dblCartage As Double = 0
        If IsNumeric(txtCartageAmt.Text) Then dblCartage = CDbl(txtCartageAmt.Text)

        Dim dblAdvertising As Double = 0
        If IsNumeric(txtAdvertsingAmt.Text) Then dblAdvertising = CDbl(txtAdvertsingAmt.Text)

        Dim dblLocksmith As Double = 0
        If IsNumeric(txtLocksmithAmt.Text) Then dblLocksmith = CDbl(txtLocksmithAmt.Text)

        Dim dblNotice As Double = 0
        If IsNumeric(txtNoticeAmt.Text) Then dblNotice = CDbl(txtNoticeAmt.Text)

        Dim dblInventories As Double = 0
        If IsNumeric(txtInventoriesAmt.Text) Then dblInventories = CDbl(txtInventoriesAmt.Text)

        Dim dblWaitingTime As Double = 0
        If IsNumeric(txtWaitingAmt.Text) Then dblWaitingTime = CDbl(txtWaitingAmt.Text)

        Dim dblSecurity As Double = 0
        If IsNumeric(txtSecurityAmt.Text) Then dblSecurity = CDbl(txtSecurityAmt.Text)

        Dim dblCommission As Double = 0
        If IsNumeric(txtCommissionAmt.Text) Then dblCommission = CDbl(txtCommissionAmt.Text)

        Dim dblEscort As Double = 0
        If IsNumeric(txtEscortAmt.Text) Then dblEscort = CDbl(txtEscortAmt.Text)

        Dim dblPostage As Double = 0
        If IsNumeric(txtPostageAmt.Text) Then dblPostage = CDbl(txtPostageAmt.Text)

        Dim strOtherCostsDetails As String = Nothing
        If Not String.IsNullOrEmpty(txtOther.Text) Then strOtherCostsDetails = txtOther.Text

        Dim dblOtherCostsAmount As Double = 0
        If IsNumeric(txtOtherAmt.Text) Then dblOtherCostsAmount = CDbl(txtOtherAmt.Text)

        Dim strBookNumber As String = txtBookNo.Text
        Dim strAdviceNumber As String = txtAdviceNo.Text

        strSql = "INSERT INTO MocReturns ([TransctionDate]," _
            & "[ActionDate], [ActionTime],[IssuingCourt]," _
            & "[CaseNumber],[ProcedureName],[AddressOfService],[Mileage],[MileageCost]," _
            & "[ServedOnRuleOneOption],[ServedOnRuleOneCosts]," _
            & "[ServedOnRuleTwoOption],[ServedOnRuleTwoCosts]," _
            & "[ServedOnRuleThreeOption],[ServedOnRuleThreeCosts]," _
            & "[ServedOnCompanyOfficeName],[ServedOnCompanyOfficeCosts]," _
            & "[ServedOnRegisteredMail],[ServedOnRegisteredMailCosts]," _
            & "[ServedOnCourtOrder],[ServedOnCourtOrderCosts]," _
            & "[AttemptedServiceExecution],[AttemptedServiceExecutionCosts]," _
            & "[ExecutionCessionOptions],[ExecutionCessionCosts]," _
            & "[ExecutionCessionReasons],[WarrantOptions]," _
            & "[WarrantCosts],[WarrantReasons]," _
            & "[WarrantOfArrestOptions],[WarrantOfArrestCosts]," _
            & "[WarrantOfAttachmentOptions],[WarrantOfAttachmentCosts]," _
            & "[WarrantOfAttachmentPaidInFull],[WarrantOfAttachmentPaidInFullCosts]," _
            & "[WarrantOfAttachmentNullaBona],[WarrantOfAttachmentNullaBonaCosts]," _
            & "[Remarks],[Cartage],[Advertising]," _
            & "[Locksmith],[Notice],[Inventories]," _
            & "[WaitingTime],[Security],[Commission]," _
            & "[Escort],[Postage]," _
            & "[OtherCostsDetails],[OtherCostsAmount], " _
            & "[BookNumber],[AdviceNumber], [PlaintifAgent]) VALUES ('" & Now & "', '" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', " _
            & "'" & strTime & "', '" & strIssuingCourt & "', '" & strCaseNo & "', '" & strProcedureName & "', " _
            & "'" & strServiceAddress & "', " & dblMileage & ", " & dblMileageCost & ", '" & strServedOnRuleOneOption & "', " _
            & "" & dblServedOnRuleOneCost & ", '" & strServedOnRuleTwoOption & "', " & dblServedOnRuleTwoCost & ", " _
            & "'" & strServedOnRulethreeOption & "', " & dblServedOnRuleThreeCost & ", " _
            & "'" & strServedOnCompanyOfficeName & "', " & dblServedOnCompanyOfficeCosts & ", " _
            & "'" & strServedOnRegisteredMail & "', " & dblServedOnRegisteredMailCosts & ", " _
            & "'" & strServedOnCourtOrder & "', " & dblServedOnCourtOrderCosts & ", " _
            & "'" & strAttemptedServiceExecution & "', " & dblAttemptedServiceExecutionCosts & ", " _
            & "'" & strExecutionCessionOptions & "', " & dblExecutionCessionCosts & ", " _
            & "'" & strExecutionCessionReasons & "', '" & strWarrantOptions & "', " _
            & "" & dblWarrantCosts & ", '" & strWarrantReasons & "', " _
            & "'" & strWarrantOfArrestOptions & "', " & dblWarrantOfArrestCosts & ", " _
            & "'" & strWarrantOfAttachmentOptions & "', " & dblWarrantOfAttachmentCosts & ", " _
            & "'" & StrWarrantOfAttachmentPaidInFull & "', " & dblWarrantOfAttachmentPaidInFullCosts & ", " _
            & "'" & StrWarrantOfAttachmentNullaBona & "', " & dblWarrantOfAttachmentNullaBonaCosts & ", " _
            & "'" & strRemarks & "', " & dblCartage & ", " & dblAdvertising & ", " _
            & "" & dblLocksmith & ", " & dblNotice & ", " & dblInventories & ", " _
            & "" & dblWaitingTime & ", " & dblSecurity & ", " & dblCommission & ", " _
            & "" & dblEscort & ", " & dblPostage & ", '" & strOtherCostsDetails & "', " & dblOtherCostsAmount & ", " _
            & "'" & strBookNumber & "', '" & strAdviceNumber & "', '" & txtPlaintifAgent.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default
        MessageBox.Show("Return saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On MOC Returns Update"
        ShowErrorMessage()
    End Sub

    Private Sub chkSum_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkSum.CheckedChanged
        SwitchOffProcedureChecks(0)
    End Sub

    Private Sub chkSumCI_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSumCI.CheckedChanged
        SwitchOffProcedureChecks(1)
    End Sub

    Private Sub chkWarExec_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkWarExec.CheckedChanged
        SwitchOffProcedureChecks(2)
    End Sub

    Private Sub chkWarArr_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkWarArr.CheckedChanged
        SwitchOffProcedureChecks(3)
    End Sub

    Private Sub SwitchOffProcedureChecks(ByVal Index As Integer)
        Select Case Index
            Case Is = 0
                chkSumCI.Checked = False
                chkWarExec.Checked = False
                chkWarArr.Checked = False
            Case Is = 1
                chkSum.Checked = False
                chkWarExec.Checked = False
                chkWarArr.Checked = False
            Case Is = 2
                chkSum.Checked = False
                chkSumCI.Checked = False
                chkWarArr.Checked = False
            Case Is = 3
                chkSum.Checked = False
                chkSumCI.Checked = False
                chkWarExec.Checked = False
        End Select
    End Sub

    Private Sub chkOpt1a_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkOpt1a.CheckedChanged
        If chkOpt1a.Checked = True Then
            chkOpt1b.Checked = False
        End If
    End Sub

    Private Sub chkOpt1b_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkOpt1b.CheckedChanged
        If chkOpt1b.Checked = True Then
            chkOpt1a.Checked = False
        End If
    End Sub

    Private Sub chkOpt2a_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkOpt2a.CheckedChanged
        If chkOpt2b.Checked = True Then
            chkOpt2a.Checked = False
        End If
    End Sub

    Private Sub chkOpt2b_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkOpt2b.CheckedChanged
        If chkOpt2b.Checked = True Then
            chkOpt2a.Checked = False
        End If
    End Sub

    Private Sub chkOpt3b_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkOpt3b.CheckedChanged
        If chkOpt3b.Checked = True Then
            chkOpt3a.Checked = False
            chkOpt3c.Checked = False
        End If
    End Sub

    Private Sub chkOpt3a_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkOpt3a.CheckedChanged
        If chkOpt3a.Checked = True Then
            chkOpt3b.Checked = False
            chkOpt3c.Checked = False
        End If
    End Sub

    Private Sub chkOpt3c_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkOpt3c.CheckedChanged
        If chkOpt3c.Checked = True Then
            chkOpt3a.Checked = False
            chkOpt3b.Checked = False
        End If
    End Sub

    Private Sub chkWarArrestOpt1_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkWarArrestOpt1.CheckedChanged
        If chkWarArrestOpt1.Checked = True Then
            chkWarArrestOpt2.Checked = False
        End If
    End Sub

    Private Sub chkWarArrestOpt2_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkWarArrestOpt2.CheckedChanged
        If chkWarArrestOpt2.Checked = True Then
            chkWarArrestOpt1.Checked = False
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [TransctionDate]," _
            & "[ActionDate], [ActionTime],[IssuingCourt]," _
            & "[CaseNumber],[ProcedureName],[AddressOfService],[Mileage],[MileageCost]," _
            & "[ServedOnRuleOneOption],[ServedOnRuleOneCosts]," _
            & "[ServedOnRuleTwoOption],[ServedOnRuleTwoCosts]," _
            & "[ServedOnRuleThreeOption],[ServedOnRuleThreeCosts]," _
            & "[ServedOnCompanyOfficeName],[ServedOnCompanyOfficeCosts]," _
            & "[ServedOnRegisteredMail],[ServedOnRegisteredMailCosts]," _
            & "[ServedOnCourtOrder],[ServedOnCourtOrderCosts]," _
            & "[AttemptedServiceExecution],[AttemptedServiceExecutionCosts]," _
            & "[ExecutionCessionOptions],[ExecutionCessionCosts]," _
            & "[ExecutionCessionReasons],[WarrantOptions]," _
            & "[WarrantCosts],[WarrantReasons]," _
            & "[WarrantOfArrestOptions],[WarrantOfArrestCosts]," _
            & "[WarrantOfAttachmentOptions],[WarrantOfAttachmentCosts]," _
            & "[WarrantOfAttachmentPaidInFull],[WarrantOfAttachmentPaidInFullCosts]," _
            & "[WarrantOfAttachmentNullaBona],[WarrantOfAttachmentNullaBonaCosts]," _
            & "[Remarks],[Cartage],[Advertising]," _
            & "[Locksmith],[Notice],[Inventories]," _
            & "[WaitingTime],[Security],[Commission]," _
            & "[Escort],[Postage]," _
            & "[OtherCostsDetails],[OtherCostsAmount], " _
            & "[BookNumber],[AdviceNumber], [PlaintifAgent] FROM MocReturns WHERE TransactionId = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsDate(objReader("ActionDate").ToString) Then dpDateOn.Value = CDate(objReader("ActionDate").ToString)

            If Not IsDBNull(objReader("ActionTime").ToString) Then txtTime.Text = objReader("ActionTime").ToString
            If Not IsDBNull(objReader("IssuingCourt").ToString) Then txtIssuingCourt.Text = objReader("IssuingCourt").ToString
            If Not IsDBNull(objReader("CaseNumber").ToString) Then txtCaseNo.Text = objReader("CaseNumber").ToString
            If Not IsDBNull(objReader("ProcedureName").ToString) Then
                Select Case UCase(objReader("ProcedureName").ToString)
                    Case Is = UCase("Summons")
                        chkSum.Checked = True
                    Case Is = UCase("Summons C.I")
                        chkSumCI.Checked = True
                    Case Is = UCase("WARRENT OF ARREST")
                        chkWarArr.Checked = True
                    Case Is = UCase("WARRENT OF EXECUTION")
                        chkWarExec.Checked = True
                End Select
            End If

            If Not IsDBNull(objReader("AddressOfService").ToString) Then txtAddress.Text = objReader("AddressOfService").ToString
            If IsNumeric(objReader("Mileage").ToString) Then txtKmAt1.Text = Format(CDbl(objReader("Mileage").ToString), "##0.00")
            If IsNumeric(objReader("MileageCost").ToString) Then txtKmAt2.Text = Format(CDbl(objReader("MileageCost").ToString), "##0.00")

            If Not IsDBNull(objReader("ServedOnRuleOneOption").ToString) Then
                Select Case objReader("ServedOnRuleOneOption").ToString
                    Case Is = "1"
                        chkOpt1a.Checked = True
                        If IsNumeric(objReader("ServedOnRuleOneCosts").ToString) Then txtOpt1AmtA.Text = Format(CDbl(objReader("ServedOnRuleOneCosts").ToString), "##0.00")
                    Case Is = "2"
                        If IsNumeric(objReader("ServedOnRuleOneCosts").ToString) Then txtOpt1AmtB.Text = Format(CDbl(objReader("ServedOnRuleOneCosts").ToString), "##0.00")
                        chkOpt1b.Checked = True
                End Select
            End If

            If Not IsDBNull(objReader("ServedOnRuleTwoOption").ToString) Then
                Select Case objReader("ServedOnRuleTwoOption").ToString
                    Case Is = "1"
                        If IsNumeric(objReader("ServedOnRuleTwoCosts").ToString) Then txtOpt2AmtA.Text = Format(CDbl(objReader("ServedOnRuleTwoCosts").ToString), "##0.00")
                        chkOpt2a.Checked = True
                    Case Is = "2"
                        If IsNumeric(objReader("ServedOnRuleTwoCosts").ToString) Then txtOpt2AmtB.Text = Format(CDbl(objReader("ServedOnRuleTwoCosts").ToString), "##0.00")
                        chkOpt2b.Checked = True
                End Select
            End If

            If Not IsDBNull(objReader("ServedOnRuleThreeOption").ToString) Then
                Select Case objReader("ServedOnRuleThreeOption").ToString
                    Case Is = "1"
                        If IsNumeric(objReader("ServedOnRuleThreeCosts").ToString) Then txtOpt3AmtA.Text = Format(CDbl(objReader("ServedOnRuleThreeCosts").ToString), "##0.00")
                        chkOpt3a.Checked = True
                    Case Is = "2"
                        If IsNumeric(objReader("ServedOnRuleThreeCosts").ToString) Then txtOpt3AmtB.Text = Format(CDbl(objReader("ServedOnRuleThreeCosts").ToString), "##0.00")
                        chkOpt3b.Checked = True
                    Case Is = "3"
                        If IsNumeric(objReader("ServedOnRuleThreeCosts").ToString) Then txtOpt3AmtC.Text = Format(CDbl(objReader("ServedOnRuleThreeCosts").ToString), "##0.00")
                        chkOpt3c.Checked = True
                End Select
            End If

            If Not IsDBNull(objReader("ServedOnCompanyOfficeName").ToString) Then
                If UCase(objReader("ServedOnCompanyOfficeName").ToString) = "Y" Then chkOffice.Checked = True
            End If
            If IsNumeric(objReader("ServedOnCompanyOfficeCosts").ToString) Then txtOfficeAmt.Text = Format(CDbl(objReader("ServedOnCompanyOfficeCosts").ToString), "##0.00")

            If Not IsDBNull(objReader("ServedOnRegisteredMail").ToString) Then
                If UCase(objReader("ServedOnRegisteredMail").ToString) = "Y" Then chkPost.Checked = True
            End If
            If IsNumeric(objReader("ServedOnRegisteredMailCosts").ToString) Then txtPostAmt.Text = Format(CDbl(objReader("ServedOnRegisteredMailCosts").ToString), "##0.00")

            If Not IsDBNull(objReader("ServedOnCourtOrder").ToString) Then
                If UCase(objReader("ServedOnCourtOrder").ToString) = "Y" Then chkCourt.Checked = True
            End If
            If IsNumeric(objReader("ServedOnCourtOrderCosts").ToString) Then txtCourtAmt.Text = Format(CDbl(objReader("ServedOnCourtOrderCosts").ToString), "##0.00")

            If Not IsDBNull(objReader("AttemptedServiceExecution").ToString) Then
                If UCase(objReader("AttemptedServiceExecution").ToString) = "Y" Then chkAttemptService.Checked = True
            End If
            If IsNumeric(objReader("AttemptedServiceExecutionCosts").ToString) Then txtAttemptServeAmt.Text = Format(CDbl(objReader("AttemptedServiceExecutionCosts").ToString), "##0.00")

            If Not IsDBNull(objReader("ExecutionCessionOptions").ToString) Then
                If UCase(objReader("ExecutionCessionOptions").ToString) = "Y" Then chkExecutionStop.Checked = True
            End If
            If IsNumeric(objReader("ExecutionCessionCosts").ToString) Then txtExecutionWithdrawAmt.Text = Format(CDbl(objReader("ExecutionCessionCosts").ToString), "##0.00")

            'If Not IsDBNull(objReader("ExecutionCessionReasons").ToString) Then dpDateOn.Value = objReader("ExecutionCessionReasons").ToString
            'If Not IsDBNull(objReader("WarrantOptions").ToString) Then dpDateOn.Value = objReader("WarrantOptions").ToString
            'If IsNumeric(objReader("WarrantCosts").ToString) Then dpDateOn.Value = Format(CDbl(objReader("WarrantCosts").ToString), "##0.00")
            'If Not IsDBNull(objReader("WarrantReasons").ToString) Then dpDateOn.Value = objReader("WarrantReasons").ToString

            If Not IsDBNull(objReader("WarrantOfArrestOptions").ToString) Then
                If objReader("WarrantOfArrestOptions").ToString = "1" Then
                    chkWarArrestOpt1.Checked = True
                    If IsNumeric(objReader("WarrantOfArrestCosts").ToString) Then txtWarArrestAmtOpt1Amt.Text = Format(CDbl(objReader("WarrantOfArrestCosts").ToString), "##0.00")
                End If
                If objReader("WarrantOfArrestOptions").ToString = "2" Then
                    chkWarArrestOpt2.Checked = True
                    If IsNumeric(objReader("WarrantOfArrestCosts").ToString) Then txtWarArrestAmtOpt2Amt.Text = Format(CDbl(objReader("WarrantOfArrestCosts").ToString), "##0.00")
                End If
            End If

            If Not IsDBNull(objReader("WarrantOfAttachmentOptions").ToString) Then
                If UCase(objReader("WarrantOfAttachmentOptions").ToString) = "Y" Then chkWarrentAttachment.Checked = True
            End If
            If IsNumeric(objReader("WarrantOfAttachmentCosts").ToString) Then txtWarrantAttachAmt.Text = Format(CDbl(objReader("WarrantOfAttachmentCosts").ToString), "##0.00")

            If Not IsDBNull(objReader("WarrantOfAttachmentPaidInFull").ToString) Then
                If UCase(objReader("WarrantOfAttachmentPaidInFull").ToString) = "Y" Then chkWarrantInFull.Checked = True
            End If
            If IsNumeric(objReader("WarrantOfAttachmentPaidInFullCosts").ToString) Then txtWarrantFullAmt.Text = Format(CDbl(objReader("WarrantOfAttachmentPaidInFullCosts").ToString), "##0.00")

            If Not IsDBNull(objReader("WarrantOfAttachmentNullaBona").ToString) Then
                If UCase(objReader("WarrantOfAttachmentNullaBona").ToString) = "Y" Then chkNullaBona.Checked = True
            End If
            If IsNumeric(objReader("WarrantOfAttachmentNullaBonaCosts").ToString) Then txtNullaBonaAmt.Text = Format(CDbl(objReader("WarrantOfAttachmentNullaBonaCosts").ToString), "##0.00")

            If Not IsDBNull(objReader("Remarks").ToString) Then txtRemarks.Text = objReader("Remarks").ToString

            If Not IsDBNull(objReader("PlaintifAgent").ToString) Then txtPlaintifAgent.Text = objReader("PlaintifAgent").ToString

            If IsNumeric(objReader("Cartage").ToString) Then txtCartageAmt.Text = Format(CDbl(objReader("Cartage").ToString), "##0.00")
            If IsNumeric(objReader("Advertising").ToString) Then txtAdvertsingAmt.Text = Format(CDbl(objReader("Advertising").ToString), "##0.00")
            If IsNumeric(objReader("Locksmith").ToString) Then txtLocksmithAmt.Text = Format(CDbl(objReader("Locksmith").ToString), "##0.00")
            If IsNumeric(objReader("Notice").ToString) Then txtNoticeAmt.Text = Format(CDbl(objReader("Notice").ToString), "##0.00")
            If IsNumeric(objReader("Inventories").ToString) Then txtInventoriesAmt.Text = Format(CDbl(objReader("Inventories").ToString), "##0.00")
            If IsNumeric(objReader("WaitingTime").ToString) Then txtWaitingAmt.Text = Format(CDbl(objReader("WaitingTime").ToString), "##0.00")
            If IsNumeric(objReader("Security").ToString) Then txtSecurityAmt.Text = Format(CDbl(objReader("Security").ToString), "##0.00")
            If IsNumeric(objReader("Commission").ToString) Then txtCommissionAmt.Text = Format(CDbl(objReader("Commission").ToString), "##0.00")
            If IsNumeric(objReader("Escort").ToString) Then txtEscortAmt.Text = Format(CDbl(objReader("Escort").ToString), "##0.00")
            If IsNumeric(objReader("Postage").ToString) Then txtPostageAmt.Text = Format(CDbl(objReader("Postage").ToString), "##0.00")
            If Not IsDBNull(objReader("OtherCostsDetails").ToString) Then txtOther.Text = objReader("OtherCostsDetails").ToString
            If IsNumeric(objReader("OtherCostsAmount").ToString) Then txtOtherAmt.Text = Format(CDbl(objReader("OtherCostsAmount").ToString), "##0.00")
            If Not IsDBNull(objReader("BookNumber").ToString) Then txtBookNo.Text = objReader("BookNumber").ToString
            If Not IsDBNull(objReader("AdviceNumber").ToString) Then txtAdviceNo.Text = objReader("AdviceNumber").ToString

        End If
        objReader.Close()

        'Get and populate the plaintiff and defendant details
        boolAbort = False
        Dim arrData As New ArrayList
        arrData = PlantifDefendantDetails(txtCaseNo.Text)
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        If arrData.Count > 0 Then
            txtPlaintif.Text = arrData.Item(0)
            If arrData.Count > 1 Then
                txtDefendant.Text = arrData.Item(1)
            End If
        End If

        ComputeTotal()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On MOC Returns Update"
        ShowErrorMessage()
    End Sub

    Private Sub frmMocReturns_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F4 Then
            boolAbort = False
            strSelectedDescription = Nothing
            Dim frm As New frmMocReturnsListings
            frm.ShowDialog()
            If boolAbort = False Then
                txtRemarks.Text = strSelectedDescription
                txtPlaintifAgent.Focus()
            End If
        End If
        If e.KeyCode = Keys.F5 Then
            IntitializeSave()
        End If
    End Sub

    Private Sub frmMocReturns_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If boolEditStatus = True Then LoadData()
    End Sub

    Private Function PlantifDefendantDetails(ByVal CaseNo As String) As ArrayList
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrReturn As New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Plaintiff, Defendant FROM MocCases WHERE CaseNo = '" & CaseNo & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then arrReturn.Add(objReader(0).ToString)
            If Not IsDBNull(objReader(1).ToString) Then arrReturn.Add(objReader(1).ToString)
        End If
        objReader.Close()
        Return arrReturn
        Cursor = Cursors.Default
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On MOC Returns Update"
        ShowErrorMessage()
    End Function

    Private Sub txtCaseNo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCaseNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not String.IsNullOrEmpty(txtCaseNo.Text) Then
                txtPlaintif.Text = Nothing : txtDefendant.Text = Nothing
                If IsValidCase(txtCaseNo.Text) = False Then
                    If chkAutoCreateCase.Checked = False Then
                        If MessageBox.Show("The case number that you have entered does not exist." & vbCrLf & _
                            "Do you want to create it now?", "Invalid Case Number", MessageBoxButtons.YesNo, _
                            MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            boolPriorStatus = boolEditStatus
                            boolEditStatus = False
                            Dim frm As New frmMocCases
                            frm.ShowDialog()
                            boolEditStatus = boolPriorStatus
                            txtCaseNo.Focus()
                            txtCaseNo.SelectAll()
                        End If
                    End If
                Else
                    txtKmAt1.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtCaseNo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCaseNo.Validating
        If Not String.IsNullOrEmpty(txtCaseNo.Text) Then
            If Not String.IsNullOrEmpty(txtCaseNo.Text) Then
                txtPlaintif.Text = Nothing : txtDefendant.Text = Nothing
                If IsValidCase(txtCaseNo.Text) = False Then
                    If chkAutoCreateCase.Checked = False Then
                        If MessageBox.Show("The case number that you have entered does not exist." & vbCrLf & _
                            "Do you want to create it now?", "Invalid Case Number", MessageBoxButtons.YesNo, _
                            MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            boolPriorStatus = boolEditStatus
                            boolEditStatus = False
                            Dim frm As New frmMocCases
                            frm.ShowDialog()
                            boolEditStatus = boolPriorStatus
                            txtCaseNo.Focus()
                            txtCaseNo.SelectAll()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Function IsValidCase(CaseNumber As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim strSql As String = "SELECT MocCases.Plaintiff, MocCases.Defendant, MocCases.CaseNo, MocCaseAddresses.DefendantAddress1, " _
            & "MocCaseAddresses.DefendantAddress2, MocCaseAddresses.DefendantAddress3, MocCaseAddresses.DefendantAddress4 " _
            & "FROM MocCases LEFT OUTER JOIN MocCaseAddresses ON MocCases.CaseNo = MocCaseAddresses.CaseNo " _
            & "WHERE MocCases.CaseNo = '" & CaseNumber & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(2).ToString) Then
                If Not IsDBNull(objReader(0).ToString) Then txtPlaintif.Text = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then txtDefendant.Text = objReader(1).ToString

                If Not IsDBNull(objReader(3).ToString) Or Not String.IsNullOrEmpty(objReader(3).ToString) Then txtAddress.Text = objReader(3).ToString
                If Not IsDBNull(objReader(4).ToString) Or Not String.IsNullOrEmpty(objReader(4).ToString) Then txtAddress.Text = txtAddress.Text & vbCrLf & objReader(4).ToString
                If Not IsDBNull(objReader(5).ToString) Or Not String.IsNullOrEmpty(objReader(5).ToString) Then txtAddress.Text = txtAddress.Text & vbCrLf & objReader(5).ToString
                If Not IsDBNull(objReader(6).ToString) Or Not String.IsNullOrEmpty(objReader(6).ToString) Then txtAddress.Text = txtAddress.Text & vbCrLf & objReader(6).ToString

                boolReturn = True
            End If
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On MOC Returns Update"
        ShowErrorMessage()
    End Function

    Private Sub txtAdvertsingAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdvertsingAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtAdvertsingAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAdvertsingAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtAttemptServeAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAttemptServeAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtAttemptServeAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAttemptServeAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtCartageAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCartageAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtCartageAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCartageAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtCommissionAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCommissionAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtCommissionAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCommissionAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtCourtAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCourtAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtCourtAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCourtAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtEscortAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEscortAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtEscortAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtEscortAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtInventoriesAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtInventoriesAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtInventoriesAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtInventoriesAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtKmAt1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtKmAt1.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtKmAt1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtKmAt1.Validating
        ComputeTotal()
    End Sub

    Private Sub txtKmAt2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtKmAt2.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtKmAt2_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtKmAt2.Validating
        ComputeTotal()
    End Sub

    Private Sub txtLocksmithAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocksmithAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtLocksmithAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtLocksmithAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtNoticeAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoticeAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtNoticeAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNoticeAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtOfficeAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOfficeAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtOfficeAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtOfficeAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtOpt1AmtA_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpt1AmtA.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtOpt1AmtA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtOpt1AmtA.Validating
        ComputeTotal()
    End Sub

    Private Sub txtOpt1AmtB_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpt1AmtB.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtOpt1AmtB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtOpt1AmtB.Validating
        ComputeTotal()
    End Sub

    Private Sub txtOpt2AmtA_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpt2AmtA.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtOpt2AmtA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtOpt2AmtA.Validating
        ComputeTotal()
    End Sub

    Private Sub txtOpt2AmtB_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpt2AmtB.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtOpt2AmtB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtOpt2AmtB.Validating
        ComputeTotal()
    End Sub

    Private Sub txtOpt3AmtA_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpt3AmtA.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtOpt3AmtA_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtOpt3AmtA.Validating
        ComputeTotal()
    End Sub

    Private Sub txtOpt3AmtB_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpt3AmtB.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtOpt3AmtB_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtOpt3AmtB.Validating
        ComputeTotal()
    End Sub

    Private Sub txtOpt3AmtC_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpt3AmtC.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtOpt3AmtC_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtOpt3AmtC.Validating
        ComputeTotal()
    End Sub

    Private Sub txtOtherAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtOtherAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtOtherAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtPostageAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPostageAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtPostageAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPostageAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtPostAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPostAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtPostAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPostAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtSecurityAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSecurityAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtSecurityAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSecurityAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtWaitingAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtWaitingAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtWaitingAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtWaitingAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtWarrantAttachAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtWarrantAttachAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtWarrantAttachAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtWarrantAttachAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtWarrantFullAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtWarrantFullAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtWarrantFullAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtWarrantFullAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtWarrentDeliveryAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtWarrentDeliveryAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtWarrentDeliveryAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtWarrentDeliveryAmt.Validating
        ComputeTotal()
    End Sub


    Private Sub txtWarArrestAmtOpt1Amt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtWarArrestAmtOpt1Amt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtWarArrestAmtOpt1Amt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtWarArrestAmtOpt1Amt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtWarArrestAmtOpt2Amt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtWarArrestAmtOpt2Amt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtWarArrestAmtOpt2Amt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtWarArrestAmtOpt2Amt.Validating
        ComputeTotal()
    End Sub

    Private Sub txtNullaBonaAmt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNullaBonaAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then ComputeTotal()
    End Sub

    Private Sub txtNullaBonaAmt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNullaBonaAmt.Validating
        ComputeTotal()
    End Sub

    Private Sub NextAdviceNumber()
        If IsNumeric(txtAdviceNo.Text) Then
            txtAdviceNo.Text = CDbl(txtAdviceNo.Text) + 1
        End If
    End Sub

    Private Sub btnAddRemark_Click(sender As System.Object, e As System.EventArgs) Handles btnAddRemark.Click
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(txtRemarks.Text) Then
            Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO MocReturnRemarks (Remarks) VALUES ('" & txtRemarks.Text & "')", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Remark added successfully to options", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.WaitCursor
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Remarks Save"
        ShowErrorMessage()
    End Sub

    Private Sub txtRemarks_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPlaintifAgent.Focus()
        End If
    End Sub

    Private Sub txtBookNo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtBookNo.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAdviceNo.Focus()
    End Sub

    Private Sub txtAdviceNo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdviceNo.KeyPress
        If Asc(e.KeyChar) = 13 Then dpDateOn.Focus()
    End Sub

    Private Sub txtIssuingCourt_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIssuingCourt.KeyPress
        If Asc(e.KeyChar) = 13 Then txtCaseNo.Focus()
    End Sub

End Class