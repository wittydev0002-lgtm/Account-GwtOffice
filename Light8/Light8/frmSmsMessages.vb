Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSmsMessages

    Private Sub btnMessageBalance_Click(sender As System.Object, e As System.EventArgs) Handles btnMessageBalance.Click
        On Error GoTo RaiseErr

        Dim arrCellnumbers As New ArrayList

        For i As Integer = 0 To dGridSms.Rows.Count - 1
            If dGridSms.Rows(i).Cells(0).Value = True Then
                If Not Object.Equals(Convert.ToString(dGridSms.Rows(i).Cells(dGridSms.Columns.Count - 1).Value), Nothing) Then

                    'Get the member balance here
                    If Not Object.Equals(dGridSms.Rows(i).Cells(1).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(dGridSms.Rows(i).Cells(1).Value.ToString) Then
                            Dim strMemberId As String = dGridSms.Rows(i).Cells(1).Value.ToString
                            Dim strValues() As String = CurrentBalance(strMemberId)
                            Dim dblBalance As Double = CDbl(strValues(0))

                            Dim strName As String = Nothing
                            If Not Object.Equals(dGridSms.Rows(i).Cells(2).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(dGridSms.Rows(i).Cells(2).Value.ToString) Then
                                    strName = strName & " " & dGridSms.Rows(i).Cells(2).Value.ToString
                                End If
                            End If
                            If Not Object.Equals(dGridSms.Rows(i).Cells(3).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(dGridSms.Rows(i).Cells(3).Value.ToString) Then
                                    strName = strName & " " & dGridSms.Rows(i).Cells(3).Value.ToString
                                End If
                            End If

                            strName = Trim(strName)

                            arrCellnumbers.Add(dGridSms.Rows(i).Cells(dGridSms.Columns.Count - 1).Value.ToString & "|" & CStr(Format(dblBalance, "#,##0.00")) & "|" & strValues(1) & "|" & strName)
                        End If
                    End If

                End If
            End If
        Next

        With frmLight8.pb1
            .Value = 0
            .Visible = True
            .Maximum = arrCellnumbers.Count
        End With

        For i As Integer = 0 To arrCellnumbers.Count - 1
            Dim strBuffer() As String = Split(arrCellnumbers.Item(i), "|")
            Dim strCellNumber As String = Replace(Trim(strBuffer(0)), " ", "", 1)
            If Not String.IsNullOrEmpty(strCellNumber) Then
                If Mid(strCellNumber, 1, 1) = "0" Then
                    'Replace number with correct format
                    strCellNumber = "+263" & Mid(strCellNumber, 2, strCellNumber.Length - 1)
                End If
                Cursor = Cursors.WaitCursor

                Dim strActiveSmsMessage As String = "Dear " & UCase(strBuffer(3)) & ". Your property balance with Nehanda Housing Coop is " & strBuffer(1) & _
                    " as of " & strBuffer(2) & ". Visit our offices for info"

                Dim objSend As New SendHttpSms
                Dim strStatus As String = objSend.InitializeHttpMessageSend(strCellNumber, strActiveSmsMessage)

                Dim objSmsMessages As New System.IO.StreamWriter(Application.StartupPath & "\Smsmsg.txt", True)
                objSmsMessages.WriteLine(strActiveSmsMessage)
                objSmsMessages.Close()

                'If String.IsNullOrEmpty(strStatus) Then
                '    gwt_comm.SmsStatusUpdate(arrCellnumbers.Item(i).ToString, "Success", "Message sent successfully", strActiveSmsMessage)
                'Else
                '    gwt_comm.SmsStatusUpdate(arrCellnumbers.Item(i).ToString, "Failure", "Message send unsuccessful", strActiveSmsMessage)
                'End If
            End If
            frmLight8.pb1.Value = frmLight8.pb1.Value + 1
        Next
        frmLight8.pb1.Value = frmLight8.pb1.Maximum

        MessageBox.Show("Process completed", "SMS Send Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On member balance message sending"
        ShowErrorMessage()
    End Sub

    Private Function CurrentBalance(ByVal MemberId As String) As String()

        On Error GoTo RaiseErr

        Dim strReturn(0 To 1) As String

        Dim dblPropertyValue As Double = 0
        Dim objPropValue As New Data.OleDb.OleDbCommand("SELECT Capital FROM BM_Master WHERE PolicyNumber = '" & MemberId & "'", cnn)
        Dim objReadValue As Data.OleDb.OleDbDataReader = objPropValue.ExecuteReader
        If objReadValue.HasRows Then
            objReadValue.Read()
            If IsNumeric(objReadValue(0).ToString) Then dblPropertyValue = CDbl(objReadValue(0).ToString)
        End If
        objReadValue.Close()

        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "Description, Reference, PeriodMonth AS [Month], PeriodYear AS [Year], " _
            & "CAST(Amount AS DECIMAL (30,2)) AS [Billed Amount], CAST(CapitalPayment AS DECIMAL (30,2)) as [Prop. Amt], " _
            & "CAST(AdminFees AS DECIMAL (30,2)) AS [Admin. Fee], CAST(InterestsCharged AS DECIMAL (30,2)) AS [Int.], " _
            & "CAST(InterestsPaid AS DECIMAL (30,2)) AS [Int. Pd], TransactionId FROM BM_Financials " _
            & "WHERE PolicyNumber = '" & MemberId & "' ORDER BY TransactionDate, TransactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim dblRunningBalance As Double = 0
        Dim dblRunningInterest As Double = 0

        Dim dblInterestPlusBalance As Double = 0

        Dim strMonth As String = Nothing
        Dim strYear As String = Nothing

        While objReader.Read
            dblPropertyValue = dblPropertyValue - (CDbl(objReader(6).ToString))
            dblRunningInterest = dblRunningInterest + CDbl(objReader(8).ToString) - CDbl(objReader(9).ToString)

            dblRunningBalance = dblRunningBalance + (CDbl(objReader(5).ToString) - ((CDbl(objReader(6).ToString) + CDbl(objReader(7).ToString))))

            'Dim dblInterest As Double = dblRunningBalance * (dblCoopOverdueSubsInterest / 100)
            dblInterestPlusBalance = dblRunningBalance + dblRunningInterest 'CDbl(objReader(8).ToString)

            Dim strDt() As String = Split(objReader(0).ToString, "-")
            If strDt.Length > 2 Then
                strMonth = UCase(strDt(1))
                strYear = UCase(strDt(2))
            End If
        End While
        objReader.Close()

        strReturn(0) = Format(dblPropertyValue, "##0.00") ' dblInterestPlusBalance
        strReturn(1) = strMonth & "-" & strYear

        Return strReturn

        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On member balance fetch"
        ShowErrorMessage()
    End Function

    Private Sub btnRefreshMessages_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshMessages.Click
        LoadForSms()
    End Sub

    Private Sub btnSmsSettings_Click(sender As System.Object, e As System.EventArgs) Handles btnSmsSettings.Click
        Dim frm As New frmSmsHttpSettings
        frm.ShowDialog()
    End Sub

    Private Sub btnTestMessage_Click(sender As System.Object, e As System.EventArgs) Handles btnTestMessage.Click
        gwt_comm.SmsTest()
    End Sub

    Private Sub dGridSms_CellMouseUp(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dGridSms.CellMouseUp
        If e.ColumnIndex = 0 Then
            dGridSms.CurrentCell = dGridSms.Rows(e.RowIndex + 1).Cells(e.ColumnIndex)
            ' Can leave these here - doesn't hurt
            dGridSms.Rows(e.RowIndex + 1).Selected = True
            dGridSms.Focus()
        End If
    End Sub

    Private Sub LoadForSms()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [PolicyNumber] AS [Stand #], LastName AS [Surname], FirstName AS [Name], Cellphone FROM BM_Master ORDER BY LastName, FirstName"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGridSms.Columns.Clear()

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridSms.DataSource = dTable

        'Add check box column

        dGridSms.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        Dim crm As New DataGridViewCheckBoxColumn
        With crm
            .Width = 25
            .HeaderText = ""
        End With
        dGridSms.Columns.Insert(0, crm)
        dGridSms.Columns(0).ReadOnly = False

        For p As Integer = 1 To dGridSms.Columns.Count - 1
            dGridSms.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Policy Holders Load for SMS"
        ShowErrorMessage()
    End Sub

    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles chkSelectAll.CheckedChanged
        If chkSelectAll.Checked = True Then
            For p As Integer = 0 To dGridSms.RowCount - 1
                dGridSms.Rows(p).Cells(0).Value = True
            Next
        Else
            For p As Integer = 0 To dGridSms.RowCount - 1
                dGridSms.Rows(p).Cells(0).Value = False
            Next
        End If
    End Sub

    Private Sub btnOtherMessage_Click(sender As System.Object, e As System.EventArgs) Handles btnOtherMessage.Click
        On Error GoTo RaiseErr

        boolAbort = False
        strBulkMessage = Nothing
        Dim frm As New frmBulkSmsMessage
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        Dim arrCellnumbers As New ArrayList

        For i As Integer = 0 To dGridSms.Rows.Count - 1
            If dGridSms.Rows(i).Cells(0).Value = True Then
                If Not Object.Equals(Convert.ToString(dGridSms.Rows(i).Cells(dGridSms.Columns.Count - 1).Value), Nothing) Then
                    arrCellnumbers.Add(dGridSms.Rows(i).Cells(dGridSms.Columns.Count - 1).Value.ToString)
                End If
            End If
        Next

        With frmLight8.pb1
            .Value = 0
            .Visible = True
            .Maximum = arrCellnumbers.Count
        End With

        For i As Integer = 0 To arrCellnumbers.Count - 1
            Dim strCellNumber As String = Replace(Trim(arrCellnumbers.Item(i)), " ", "", 1)
            If Not String.IsNullOrEmpty(strCellNumber) Then
                If Mid(strCellNumber, 1, 1) = "0" Then
                    'Replace number with correct format
                    strCellNumber = "+263" & Mid(strCellNumber, 2, strCellNumber.Length - 1)
                End If
                Cursor = Cursors.WaitCursor
                Dim objSend As New SendHttpSms
                Dim strStatus As String = objSend.InitializeHttpMessageSend(strCellNumber, strBulkMessage)

                If String.IsNullOrEmpty(strStatus) Then
                    'SmsStatusUpdate(arrCellnumbers.Item(i).ToString, "Success", "Message sent successfully", strBulkMessage)
                Else
                    'SmsStatusUpdate(arrCellnumbers.Item(i).ToString, "Failure", "Message send unsuccessful", strBulkMessage)
                End If
            End If
            frmLight8.pb1.Value = frmLight8.pb1.Value + 1
        Next
        frmLight8.pb1.Value = frmLight8.pb1.Maximum

        MessageBox.Show("Process completed", "SMS Send Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On bulk message sending"
        ShowErrorMessage()
    End Sub
End Class