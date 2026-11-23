Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMocCases

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtAccountNo.Text) Then
            MessageBox.Show("Please enter the case number", "Missing Case Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNo.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtPlaintif.Text) Then
            MessageBox.Show("Please enter the plaintif name", "Missing Plaintif Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPlaintif.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDefendant.Text) Then
            MessageBox.Show("Please enter the defendant name", "Missing Defendant Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDefendant.Focus()
            Exit Sub
        End If
        Dim strDebtorCode As String = "0-0"
        If chkType.Checked = True Then
            strDebtorCode = "0-0"
        Else
            If String.IsNullOrEmpty(lblCode.Text) Then
                MessageBox.Show("Please select the debtor code from the given list", "Missing Debtor Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboClients.Focus()
                Exit Sub
            Else
                strDebtorCode = lblCode.Text
            End If
        End If

        Dim strDateClosed As String = Nothing
        If chkClosure.Checked = True Then
            strDateClosed = Format(dpClosure.Value, "dd-MMM-yyyy")
        End If

        Dim strSql As String = Nothing
        If boolEditStatus = False Then
            If gwt_comm.CheckLegalRecordExistence(txtAccountNo.Text, "MOC") = True Then
                MessageBox.Show("This record already exist. Please enter a different case with different case number", _
                    "Duplicate Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                If Not String.IsNullOrEmpty(strDateClosed) Then
                    strSql = "INSERT INTO MocCases ([CaseNo], " _
                        & "[DateIn], [Plaintiff], [Defendant], [DebtorId], [Status], Remarks, DateClosed) VALUES " _
                        & "('" & txtAccountNo.Text & "', '" & Format(dpStart.Value, "dd-MMM-yyyy") & "', " _
                        & "'" & txtPlaintif.Text & "', " _
                        & "'" & txtDefendant.Text & "', '" & lblCode.Text & "', 'CLOSED', " _
                        & "'" & txtRemarks.Text & "', '" & Format(dpClosure.Value, "dd-MMM-yyyy") & "')"
                Else
                    strSql = "INSERT INTO MocCases ([CaseNo], " _
                        & "[DateIn], [Plaintiff], [Defendant], [DebtorId], [Status], Remarks) VALUES " _
                        & "('" & txtAccountNo.Text & "', '" & Format(dpStart.Value, "dd-MMM-yyyy") & "', " _
                        & "'" & txtPlaintif.Text & "', " _
                        & "'" & txtDefendant.Text & "', '" & lblCode.Text & "', 'OPEN', '" & txtRemarks.Text & "')"
                End If
            End If
        Else
            If Not String.IsNullOrEmpty(strDateClosed) Then
                strSql = "UPDATE MocCases SET [DateIn] = '" & Format(dpStart.Value, "dd-MMM-yyyy") & "', " _
                    & "[Plaintiff] = '" & txtPlaintif.Text & "', [Defendant] = '" & txtDefendant.Text & "', " _
                    & "[DebtorId] = '" & lblCode.Text & "', [Status] = 'CLOSED', Remarks = '" & txtRemarks.Text & "', " _
                    & "DateClosed = '" & strDateClosed & "' WHERE CaseNo = '" & txtAccountNo.Text & "'"
            Else
                strSql = "UPDATE MocCases SET [DateIn] = '" & Format(dpStart.Value, "dd-MMM-yyyy") & "', " _
                    & "[Plaintiff] = '" & txtPlaintif.Text & "', [Defendant] = '" & txtDefendant.Text & "', " _
                    & "[DebtorId] = '" & lblCode.Text & "', [Status] = 'OPEN', Remarks = '" & txtRemarks.Text & "' " _
                    & "WHERE CaseNo = '" & txtAccountNo.Text & "'"
            End If
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        boolAbort = False
        SaveAddresses()
        If boolAbort = True Then Exit Sub
        MessageBox.Show("Case has been updated successfully", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On MOC Cases Update"
        ShowErrorMessage()
    End Sub

    Private Sub chkClosure_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkClosure.CheckedChanged
        If chkClosure.Checked = True Then
            dpClosure.Enabled = True
        Else
            dpClosure.Enabled = False
        End If
    End Sub

    Private Sub LoadClients()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT GivenNames +'|'+ PlaintifID AS " _
            & "[Details] FROM Plaintifs ORDER BY GivenNames", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrData As New ArrayList

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboClients.Width - 80

        'Add the items to the drop down box
        With cboClients
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth1 & ";80"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = arrData.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboClients.Items.Clear()
        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboClients
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Client Names Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmMocCases_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadClients()
        If boolEditStatus = True Then
            LoadSelectedData()
            LoadData()
            LoadRemarks()
            ComputeTotals()
        Else
            txtAccountNo.Focus()
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT MocReturns.BookNumber, MocReturns.AdviceNumber, " _
            & "CONVERT(NVARCHAR, MocReturns.ActionDate, 105) AS [ActionDate], MocReturns.CaseNumber, MocCases.Plaintiff,  " _
            & "MocReturns.ProcedureName,  CAST((MocReturns.MileageCost + MocReturns.ServedOnRuleOneCosts + " _
            & "MocReturns.ServedOnRuleTwoCosts + MocReturns.ServedOnRuleThreeCosts + MocReturns.ServedOnCompanyOfficeCosts + " _
            & "MocReturns.ServedOnRegisteredMailCosts + MocReturns.ServedOnCourtOrderCosts + MocReturns.AttemptedServiceExecutionCosts + " _
            & "MocReturns.ExecutionCessionCosts + MocReturns.WarrantCosts + MocReturns.WarrantOfArrestCosts + " _
            & "MocReturns.WarrantOfAttachmentCosts + MocReturns.WarrantOfAttachmentPaidInFullCosts + " _
            & "MocReturns.WarrantOfAttachmentNullaBonaCosts + MocReturns.Cartage + MocReturns.Advertising + " _
            & "MocReturns.Locksmith + MocReturns.Notice + MocReturns.Inventories + MocReturns.WaitingTime + " _
            & "MocReturns.Security + MocReturns.Commission + MocReturns.Escort + MocReturns.Postage + " _
            & "MocReturns.OtherCostsAmount) AS DECIMAL (10,2)) AS TotalCosts, MocReturns.TransactionId " _
            & "FROM MocReturns LEFT OUTER JOIN MocCases ON MocReturns.CaseNumber = MocCases.CaseNo " _
            & "WHERE MocReturns.CaseNumber = '" & strSelectedAccount & "' ORDER BY AdviceNumber"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), _
                objReader(4), objReader(5), objReader(6), objReader(7))
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "MOC Returns Listing"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr
        Dim dblAmount As Double = 0
        For i As Integer = 0 To dGrid.RowCount - 1
            If Not Object.Equals(dGrid.Rows(i).Cells(dGrid.ColumnCount - 2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(dGrid.ColumnCount - 2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(dGrid.ColumnCount - 2).Value.ToString) Then
                        dblAmount = dblAmount + CDbl(dGrid.Rows(i).Cells(dGrid.ColumnCount - 2).Value.ToString)
                    End If
                End If
            End If
        Next
        lblCosts.Text = Format(dblAmount, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "on total costs computation"
        ShowErrorMessage()
    End Sub

    Private Sub LoadRemarks()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT MocReturns.BookNumber, MocReturns.AdviceNumber, " _
            & "MocReturns.Remarks FROM MocReturns WHERE MocReturns.CaseNumber = '" & strSelectedAccount & "' ORDER BY AdviceNumber"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridNotes.Rows.Clear()
        While objReader.Read
            dGridNotes.Rows.Add(objReader(0), objReader(1), objReader(2))
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "MOC Returns Remarks Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClients.SelectedIndexChanged
        On Error Resume Next
        If Not cboClients.SelectedItem Is Nothing Then
            lblCode.Text = cboClients.SelectedItem.Col2
        Else
            lblCode.Text = cboClients.SelectedItem.Col2
            lblCode.Text = "0"
        End If
    End Sub

    Private Sub chkType_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkType.CheckedChanged
        If chkType.Checked = True Then
            cboClients.Enabled = False
            cboClients.Text = Nothing
            lblCode.Text = ""
        Else
            cboClients.Enabled = True
        End If
    End Sub

    Private Sub LoadSelectedData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM MocCases WHERE CaseNo = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("CaseNo").ToString) Then txtAccountNo.Text = objReader("CaseNo").ToString
            If IsDate(objReader("DateIn").ToString) Then dpStart.Value = CDate(objReader("DateIn").ToString)
            If Not IsDBNull(objReader("Plaintiff").ToString) Then txtPlaintif.Text = objReader("Plaintiff").ToString
            If Not IsDBNull(objReader("Defendant").ToString) Then txtDefendant.Text = objReader("Defendant").ToString
            If Not IsDBNull(objReader("DebtorId").ToString) Then
                lblCode.Text = objReader("DebtorId").ToString
                If lblCode.Text = "0-0" Then
                    chkType.Checked = True
                Else
                    cboClients.Text = GetPlaintifName(lblCode.Text)
                End If
            End If
            If Not IsDBNull(objReader("DateClosed").ToString) Then
                If IsDate(objReader("DateClosed").ToString) Then
                    dpClosure.Value = CDate(objReader("DateClosed").ToString)
                End If
            End If
            If Not IsDBNull(objReader("Remarks").ToString) Then txtRemarks.Text = objReader("Remarks").ToString
            If Not IsDBNull(objReader("Status").ToString) Then
                If UCase(objReader("Status").ToString) = "CLOSED" Then
                    chkClosure.Checked = True
                Else
                    chkClosure.Checked = False
                End If
            End If
        End If

        boolAbort = False
        LoadAddresses()
        If boolAbort = True Then Exit Sub
        objReader.Close()
        txtAccountNo.Enabled = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Cases Load"
        ShowErrorMessage()
    End Sub

    Private Function GetPlaintifName(PlaintifId As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Plaintifs.GivenNames FROM Plaintifs WHERE PlaintifId = '" & PlaintifId & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Plaintif Name Fetch"
        ShowErrorMessage()
    End Function

    Private Sub SaveAddresses()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM MocCaseAddresses WHERE CaseNo = '" & txtAccountNo.Text & "'", cnn)
        objCommand.ExecuteNonQuery()
        Dim strSql As String = "INSERT INTO MocCaseAddresses ([PlaintifAddress1], [PlaintifAddress2], " _
            & "[PlaintifAddress3], [PlaintifAddress4], [DefendantAddress1], [DefendantAddress2], " _
            & "[DefendantAddress3], [DefendantAddress4], [CaseNo]) VALUES " _
            & "('" & txtPlaintifAddress1.Text & "', '" & txtPlaintifAddress2.Text & "', " _
            & "'" & txtPlaintifAddress3.Text & "', '" & txtPlaintifAddress4.Text & "', " _
            & "'" & txtDefendantAddress1.Text & "', '" & txtDefendantAddress2.Text & "', " _
            & "'" & txtDefendantAddress3.Text & "', '" & txtDefendantAddress4.Text & "', '" & txtAccountNo.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Addresses save"
        ShowErrorMessage()
    End Sub

    Private Sub LoadAddresses()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM MocCaseAddresses WHERE CaseNo = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("PlaintifAddress1").ToString) Then txtPlaintifAddress1.Text = objReader("PlaintifAddress1").ToString
            If Not IsDBNull(objReader("PlaintifAddress2").ToString) Then txtPlaintifAddress2.Text = objReader("PlaintifAddress2").ToString
            If Not IsDBNull(objReader("PlaintifAddress3").ToString) Then txtPlaintifAddress3.Text = objReader("PlaintifAddress3").ToString
            If Not IsDBNull(objReader("PlaintifAddress4").ToString) Then txtPlaintifAddress4.Text = objReader("PlaintifAddress4").ToString
            If Not IsDBNull(objReader("DefendantAddress1").ToString) Then txtDefendantAddress1.Text = objReader("DefendantAddress1").ToString
            If Not IsDBNull(objReader("DefendantAddress2").ToString) Then txtDefendantAddress2.Text = objReader("DefendantAddress2").ToString
            If Not IsDBNull(objReader("DefendantAddress3").ToString) Then txtDefendantAddress3.Text = objReader("DefendantAddress3").ToString
            If Not IsDBNull(objReader("DefendantAddress4").ToString) Then txtDefendantAddress4.Text = objReader("DefendantAddress4").ToString
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Addresses save"
        ShowErrorMessage()
    End Sub

    Private Sub txtAccountNo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            CheckCaseNumber(txtAccountNo.Text)
            dpStart.Focus()
        End If
    End Sub

    Private Sub txtAccountNo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAccountNo.Validating
        CheckCaseNumber(txtAccountNo.Text)
    End Sub

    Private Sub CheckCaseNumber(CaseNo As String)
        On Error GoTo RaiseErr
        If boolEditStatus = True Then Exit Sub
        If Not String.IsNullOrEmpty(CaseNo) Then
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CaseNo FROM MocCases WHERE CaseNo = '" & CaseNo & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                MessageBox.Show("This number has already been allocated. Please enter a new one", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                objReader.Close()
                Exit Sub
            End If
            objReader.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On case add"
        ShowErrorMessage()
    End Sub

    Private Sub txtPlaintif_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlaintif.KeyPress
        If Asc(e.KeyChar) = 13 Then txtDefendant.Focus()
    End Sub

    Private Sub txtDefendant_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDefendant.KeyPress
        If Asc(e.KeyChar) = 13 Then cboClients.Focus()
    End Sub

    Private Sub txtDefendantAddress1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDefendantAddress1.KeyPress
        If Asc(e.KeyChar) = 13 Then txtDefendantAddress2.Focus()
    End Sub

    Private Sub txtDefendantAddress2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDefendantAddress2.KeyPress
        If Asc(e.KeyChar) = 13 Then txtDefendantAddress3.Focus()
    End Sub

    Private Sub txtDefendantAddress3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDefendantAddress3.KeyPress
        If Asc(e.KeyChar) = 13 Then txtDefendantAddress4.Focus()
    End Sub

    Private Sub txtDefendantAddress4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDefendantAddress4.KeyPress
        If Asc(e.KeyChar) = 13 Then txtPlaintifAddress1.Focus()
    End Sub

    Private Sub txtPlaintifAddress1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlaintifAddress1.KeyPress
        If Asc(e.KeyChar) = 13 Then txtPlaintifAddress2.Focus()
    End Sub

    Private Sub txtPlaintifAddress2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlaintifAddress2.KeyPress
        If Asc(e.KeyChar) = 13 Then txtPlaintifAddress3.Focus()
    End Sub

    Private Sub txtPlaintifAddress3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlaintifAddress3.KeyPress
        If Asc(e.KeyChar) = 13 Then txtPlaintifAddress4.Focus()
    End Sub

    Private Sub txtPlaintifAddress4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlaintifAddress4.KeyPress
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
    End Sub

    Private Sub dpStart_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dpStart.KeyPress
        If Asc(e.KeyChar) = 13 Then txtPlaintif.Focus()
    End Sub

    Private Sub btnAddDebtor_Click(sender As System.Object, e As System.EventArgs) Handles btnAddDebtor.Click
        Dim boolPriorStatus As Boolean = boolEditStatus
        boolEditStatus = False
        Dim frm As New frmPlaintifDetails
        frm.ShowDialog()
        LoadClients()
        boolEditStatus = boolPriorStatus
    End Sub

End Class
