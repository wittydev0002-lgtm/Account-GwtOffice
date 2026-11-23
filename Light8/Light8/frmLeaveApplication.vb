Imports System.IO
Imports System.Text
Imports System.Web
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons

Public Class frmLeaveApplication

    Dim prFont As New Font("Verdana", 8, FontStyle.Bold)
    Dim tlFont As New Font("Verdana", 8, FontStyle.Regular)
    Dim HeaderFont As New Font("Verdana", 12, FontStyle.Bold)

    Sub GetExcludedDays()
        Dim ex As New List(Of Date)
        'Get the file that contains the details of the holidays
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strLine As String
        Dim strBuffer() As String
        Dim lngDates(0 To 2) As String
        Dim i As Integer = 0
        Dim strflag As String = Nothing
        objCommand = New Data.OleDb.OleDbCommand("SELECT NoWorkDate FROM SystemHolidays ORDER BY NoWorkDate", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        i = 0
        While objReader.Read
            If IsDate(objReader("NoWorkDate").ToString) Then
                lngDates(0) = DatePart(DateInterval.Year, dtpStartDate.Value)
                lngDates(1) = DatePart(DateInterval.Month, dtpStartDate.Value)
                lngDates(2) = DatePart(DateInterval.Day, dtpStartDate.Value)
                'Year, Month, Day
                ex.Add(New Date(CLng(lngDates(0)), CLng(lngDates(1)), CLng(lngDates(2))))
            End If
        End While
        objReader.Close()

        'Get the weekend workidays style from the file
        objCommand = New Data.OleDb.OleDbCommand("SELECT * FROM SystemNonWorkDays", cnn)
        objReader = objCommand.ExecuteReader

        i = 0
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("NoWorkDays").ToString) Then strflag = objReader("NoWorkDays").ToString
        End If
        objReader.Close()

        'Get the values of end date supplied by user
        Dim intMth As Integer = gwt_comm.MonthString(DatePart(DateInterval.Month, dtpStartDate.Value))
        Dim intDay As Integer = CInt(DatePart(DateInterval.Day, dtpStartDate.Value))
        Dim intYear As Integer = CInt(DatePart(DateInterval.Year, dtpStartDate.Value))

        Dim intMthEnd As Integer = gwt_comm.MonthString(DatePart(DateInterval.Month, dtpEndDate.Value))
        Dim intDayEnd As Integer = CInt(DatePart(DateInterval.Day, dtpEndDate.Value))
        Dim intYearEnd As Integer = CInt(DatePart(DateInterval.Year, dtpEndDate.Value))

        Select Case UCase(strflag)
            Case Is = "EXCLUDEBOTH"
                Me.txtDaysAppliedFor.Text = CountWorkDays(New Date(intYear, intMth, intDay), New Date(intYearEnd, intMthEnd, intDayEnd), ex, False, False).ToString
            Case Is = "INCLUDESATURDAY"
                'Actual facts it excludes Sundays
                Me.txtDaysAppliedFor.Text = CountWorkDays(New Date(intYear, intMth, intDay), New Date(intYearEnd, intMthEnd, intDayEnd), ex, False, True).ToString
            Case Is = "INCLUDESUNDAY"
                'In actual facts it excludes Saturdays
                Me.txtDaysAppliedFor.Text = CountWorkDays(New Date(intYear, intMth, intDay), New Date(intYearEnd, intMthEnd, intDayEnd), ex, True, False).ToString
            Case Is = "INCLUDEBOTH"
                Me.txtDaysAppliedFor.Text = CountWorkDays(New Date(intYear, intMth, intDay), New Date(intYearEnd, intMthEnd, intDayEnd), ex, True, True).ToString
        End Select
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Leave Application Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Function CountWorkDays( _
          ByRef StartDate As Date, _
          ByRef EndDate As Date, _
          Optional ByRef excluded As List(Of Date) = Nothing, _
          Optional ByRef wd_sat As Boolean = True, _
          Optional ByRef wd_sun As Boolean = True, _
          Optional ByRef wd_mon As Boolean = True, _
          Optional ByRef wd_tue As Boolean = True, _
          Optional ByRef wd_wed As Boolean = True, _
          Optional ByRef wd_thu As Boolean = True, _
          Optional ByRef wd_fri As Boolean = True _
            ) As Long

        Dim DayCount As Long = 0
        Dim Inc As Long = 1
        Dim EndDateIsInPast As Boolean = StartDate > EndDate
        Dim tmpDate As New Date(StartDate.Year, StartDate.Month, StartDate.Day)
        Dim finiDate As New Date(EndDate.Year, EndDate.Month, EndDate.Day)
        If EndDateIsInPast Then
            'Swap dates around
            tmpDate = New Date(EndDate.Year, EndDate.Month, EndDate.Day)
            finiDate = New Date(StartDate.Year, StartDate.Month, StartDate.Day)
            ' Set increment value to -1, so it DayCount Decrements rather then Increments
            Inc = -1
        End If
        ' If no exluded dates are supplied, make an empty list of dates.
        If excluded Is Nothing Then excluded = New List(Of Date)
        While tmpDate <= finiDate
            If excluded.Contains(tmpDate) = False Then
                ' What day of week is tmpDate? If day is is allowed Increment DayCount by one.
                Select Case tmpDate.DayOfWeek
                    Case DayOfWeek.Sunday : If wd_sun Then DayCount += Inc
                    Case DayOfWeek.Monday : If wd_mon Then DayCount += Inc
                    Case DayOfWeek.Tuesday : If wd_tue Then DayCount += Inc
                    Case DayOfWeek.Wednesday : If wd_wed Then DayCount += Inc
                    Case DayOfWeek.Thursday : If wd_thu Then DayCount += Inc
                    Case DayOfWeek.Friday : If wd_fri Then DayCount += Inc
                    Case DayOfWeek.Saturday : If wd_sat Then DayCount += Inc
                End Select
            End If
            ' Move onto next day
            tmpDate = tmpDate.AddDays(1)
        End While
        Return DayCount
    End Function

    Private Sub dtpEndDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpEndDate.LostFocus
        GetExcludedDays()
    End Sub

    Private Sub dtpEndDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpEndDate.Validating
        GetExcludedDays()
    End Sub

    Private Sub dtpStartDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpStartDate.LostFocus
        GetExcludedDays()
    End Sub

    Private Sub dtpStartDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpStartDate.Validating
        GetExcludedDays()
    End Sub

    Private Sub chkOveride_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOveride.CheckedChanged
        If Me.chkOveride.Checked = True Then Me.txtDaysAppliedFor.Enabled = True Else Me.txtDaysAppliedFor.Enabled = False
    End Sub

    Private Sub frmLeaveApplication_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadLeaveTypes()
        If boolEditStatus = True Then
            Me.txtEmployeeNumber.Text = strPublicEmployeeId
            Me.lblEmpDetails.Text = strEmployeeGivenNames
            LoadSelectedLeave()
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearControls()
    End Sub

    Private Sub ClearControls()
        Me.txtAddress.Clear()
        Me.txtCopyTo.Clear()
        Me.txtDaysAppliedFor.Text = 0
        Me.txtRemarks.Clear()
        Me.dtpEndDate.Value = Now
        Me.dtpStartDate.Value = Now
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        '!!! This is the only file that will use the | seperator because of the concatination
        '!!! used in the copy to email addresses

        On Error GoTo RaiseErr
        'Save the details to file
        If String.IsNullOrEmpty(Me.lblBankCode.Text) Then
            MessageBox.Show("Please enter the leave type", "Invalid Leave Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cboLeaveType.Focus()
            Exit Sub
        End If
        If Me.txtAddress.Text = "" Then
            MessageBox.Show("Please enter the contact address while on leave", "Invalid Address Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtAddress.Focus()
            Exit Sub
        End If
        If Not IsNumeric(Me.txtDaysAppliedFor.Text) Then
            MessageBox.Show("Please enter a valid numeric value for the days taken", "Invalid Number of Leave Days", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtDaysAppliedFor.Focus()
            Exit Sub
        End If

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        'If the record is in edit mode, delete it first

        'Get the last entry of the leave type based on transaction id
        Dim dblBalanceBefore As Double = 0
        Dim dblBalanceAfter As Double = 0
        If boolEditStatus = True Then
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeLeaveDetails WHERE TransactionId = " & intSelectedTransaction & "", cnn)
            objCommand.ExecuteNonQuery()
        End If
        objCommand = New Data.OleDb.OleDbCommand("SELECT BalanceAfter, TransactionId FROM EmployeeLeaveDetails WHERE EmployeeNo = " _
            & "'" & txtEmployeeNumber.Text & "' AND LeaveType = " & CInt(lblBankCode.Text) & " ORDER BY TransactionId DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblBalanceBefore = CDbl(objReader(0).ToString)
            End If
        End If
        dblBalanceAfter = dblBalanceBefore - CInt(txtDaysAppliedFor.Text)
        Dim sStartDate As String = dtpStartDate.Text
        Dim sEndDate As String = dtpEndDate.Text
        If UCase(strSystemDateFormat) = UCase("English") Then
            sStartDate = gwt_comm.shortMonthDateFormat(dtpStartDate.Value)
            sEndDate = gwt_comm.shortMonthDateFormat(dtpEndDate.Value)
        End If
        If boolEditStatus = False Then
            strSql = "INSERT INTO EmployeeLeaveDetails (EmployeeNo, LeaveType, StartDate, " _
                & "EndDate, DaysTaken, BalanceBefore, BalanceAfter, CopyTo, Address, Remarks) VALUES " _
                & "('" & txtEmployeeNumber.Text & "', " & lblBankCode.Text & ", '" & dtpStartDate.Value & "', " _
                & "'" & dtpEndDate.Value & "', " & txtDaysAppliedFor.Text & ", " & dblBalanceBefore & ", " _
                & "" & dblBalanceAfter & ", '" & txtCopyTo.Text & "', '" & txtAddress.Text & "', '" & txtRemarks.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Else
            strSql = "UPDATE EmployeeLeaveDetails LeaveType = " & lblBankCode.Text & ", StartDate = '" & dtpStartDate.Value & "', " _
                & "EndDate = '" & dtpEndDate.Value & "', DaysTaken = " & txtDaysAppliedFor.Text & ", BalanceBefore = " & dblBalanceBefore & ", " _
                & "BalanceAfter = " & dblBalanceAfter & ", CopyTo = '" & txtCopyTo.Text & "', Address = '" & txtAddress.Text & "', " _
                & "Remarks = '" & txtRemarks.Text & "' WHERE EmployeeNo = '" & txtEmployeeNumber.Text & "' AND " _
                & "TransactionId = " & intSelectedTransaction & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        End If
        objCommand.ExecuteNonQuery()
        If MessageBox.Show("Leave details have been successfully updated. Do you want to print the leave form?", _
                "Leave Update Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            PrintLeaveForm()
        End If
        Me.ClearControls()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Leave Details Save Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub PrintLeaveForm()
        Me.ppd.Document = Me.printDoc
        Me.ppd.ShowDialog()
    End Sub

    Private Sub printDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles printDoc.PrintPage

    End Sub

    Private Sub SendEmail(ByVal sEmailAddress As String)
        Dim objMail As New Net.Mail.MailMessage()
        Dim svr As New Net.Mail.SmtpClient("HTTP")
        objMail.From = New Net.Mail.MailAddress("embassyph@yahoo.com")
        ' The email address of the recipient 
        objMail.To.Add(sEmailAddress)

        ' The email address of the Cc recipient 
        objMail.CC.Add("name1@anotherdomain.com")

        ' The email address of the Bcc recipient 
        objMail.Bcc.Add("name2@anotherdomain.com")

        ' The priority of the message  - it can be MailPriority.High,MailPriority, Normal Or MailPriority.Low
        objMail.Priority = Net.Mail.MailPriority.High

        'The subject of the message 
        objMail.Subject = "My first ASP.NET email"

        'The message text 
        objMail.Body = "This is my first email sent via "
        svr.Send(objMail)

        '======================
        'MailMessage(Message = New MailMessage())
        'Message.From = New MailAddress("sender@foo.bar.com")
        'Message.To.Add(New MailAddress("recipient1@foo.bar.com"))
        'Message.To.Add(New MailAddress("recipient2@foo.bar.com"))
        'Message.To.Add(New MailAddress("recipient3@foo.bar.com"))
        'Message.CC.Add(New MailAddress("carboncopy@foo.bar.com"))
        'Message.Subject = "This is my subject"
        'Message.Body = "This is the content"
        'SmtpClient(client = New SmtpClient())
        'client.Send(Message)
        '========================
    End Sub

    Private Sub txtAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtCopyTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCopyTo.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtDaysAppliedFor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDaysAppliedFor.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtEmployeeNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmployeeNumber.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub txtRemarks_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemarks.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

    Private Sub LoadLeaveTypes()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Description +';'+ " _
            & "CONVERT(NVARCHAR, TransactionId) AS [Details] FROM SystemLeaveParameters ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        'Set up the drop down combo box
        With cboLeaveType
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "280;30"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        objCommand = New Data.OleDb.OleDbCommand("SELECT Count(TransactionId) FROM SystemLeaveParameters", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboLeaveType.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboLeaveType.SelectedIndex = -1
            cboLeaveType.Items.Clear()
            cboLeaveType.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboLeaveType.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error no " & Err.Number & vbCrLf & "On Leave Types Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cboLeaveType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeaveType.SelectedIndexChanged
        If cboLeaveType.Focused = False Then Exit Sub
        If Not cboLeaveType.SelectedItem Is Nothing Then
            lblBankCode.Text = cboLeaveType.SelectedItem.Col2
        Else
            lblBankCode.Text = ""
        End If
    End Sub

    Private Sub LoadSelectedLeave()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeLeaveDetails " _
            & "WHERE TransactionId = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsDate(objReader("StartDate").ToString) Then dtpStartDate.Value = CDate(objReader("StartDate").ToString)
            If IsDate(objReader("EndDate").ToString) Then dtpEndDate.Value = CDate(objReader("EndDate").ToString)
            If Not IsDBNull(objReader("EmployeeNo").ToString) Then txtEmployeeNumber.Text = objReader("EmployeeNo").ToString
            If Not IsDBNull(objReader("CopyTo").ToString) Then txtCopyTo.Text = objReader("CopyTo").ToString
            If Not IsDBNull(objReader("Address").ToString) Then txtAddress.Text = objReader("Address").ToString
            If Not IsDBNull(objReader("Remarks").ToString) Then txtRemarks.Text = objReader("Remarks").ToString
            If IsNumeric(objReader("LeaveType").ToString) Then
                Dim objGetLeaveDescription As New Data.OleDb.OleDbCommand("SELECT Description FROM SystemLeaveParameters " _
                    & "WHERE TransactionId = " & CInt(objReader("LeaveType").ToString) & "", cnn)
                Dim objReadDescription As Data.OleDb.OleDbDataReader = objGetLeaveDescription.ExecuteReader
                If objReadDescription.HasRows Then
                    objReadDescription.Read()
                    If Not IsDBNull(objReadDescription(0).ToString) Then
                        cboLeaveType.Text = objReadDescription(0).ToString
                    End If
                End If
                objReadDescription.Close()
                lblBankCode.Text = objReader("LeaveType").ToString
            End If
            If IsNumeric(objReader("DaysTaken").ToString) Then txtDaysAppliedFor.Text = objReader("DaysTaken").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error no " & Err.Number & vbCrLf & "On Leave Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class