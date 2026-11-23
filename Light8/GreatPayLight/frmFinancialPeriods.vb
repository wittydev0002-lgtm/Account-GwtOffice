Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmFinancialPeriods

    Private Sub frmFinancialPeriods_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dGrid.Rows.Add(24)
        LoadDetails()
        AlternateColors()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub SaveFinancialPeriods()
        On Error GoTo RaiseErr

        If Not IsNumeric(txtPeriods.Text) Then
            MessageBox.Show("Please enter the number of financial periods", "Invalid Financial Periods", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPeriods.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtYear.Text) Then
            MessageBox.Show("Please enter the active year", "Invalid Financial Year", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtYear.Focus()
            Exit Sub
        End If

        If ValidatePeriods() = False Then
            MessageBox.Show("Either the number of periods does not match the periods set in the " & vbCrLf & "calendar below or there " _
                & "is missing data in the tax calendar entries", "Periods Set/Count Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim strPriorYearPosting As String = "NO"
        Dim strPriorPeriodPosting As String = "NO"
        Dim strPriorDayPosting As String = "NO"

        If chkCurrentYear.Checked = True Then strPriorYearPosting = "YES"
        If chkCurrentPeriod.Checked = True Then strPriorPeriodPosting = "YES"
        If chkCurrentDate.Checked = True Then strPriorDayPosting = "YES"

        Dim strSql As String = "DELETE FROM FinancialYear"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "DELETE FROM FinancialCalendar"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Financial Calendar
        strSql = "INSERT INTO FinancialYear ([StartMonth], [EndMonth], [FinancialPeriods], " _
            & "[PriorYearPosting], [PriorPeriodPosting], [PriorDayPosting], [ActiveYear]) VALUES ('" & cboStartMonth.Text & "', " _
            & "'" & cboEndMonth.Text & "', " & CInt(txtPeriods.Text) & ", '" & strPriorYearPosting & "', " _
            & "'" & strPriorPeriodPosting & "', '" & strPriorDayPosting & "', " & CInt(txtYear.Text) & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strStartDate As String = Nothing
            Dim strEndDate As String = Nothing
            Dim intDays As Integer = 0
            Dim strCloseStatus As String = "NO"
            Dim strSmsStatus As String = "NO"
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                        strStartDate = dGrid.Rows(i).Cells(0).Value.ToString
                        strEndDate = dGrid.Rows(i).Cells(1).Value.ToString

                        Dim StartDateValues() As String = Split(strStartDate, "-")
                        Dim EndDateValues() As String = Split(strEndDate, "-")

                        strStartDate = StartDateValues(0) & "-" & MonthName(CInt(StartDateValues(1)), True) & "-" & StartDateValues(2)
                        strEndDate = EndDateValues(0) & "-" & MonthName(CInt(EndDateValues(1)), True) & "-" & EndDateValues(2)

                        intDays = DateDiff(DateInterval.Day, CDate(strStartDate), CDate(strEndDate)) + 1

                        If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                            strCloseStatus = dGrid.Rows(i).Cells(3).Value.ToString
                        End If
                        If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                            strSmsStatus = dGrid.Rows(i).Cells(4).Value.ToString
                        End If

                        strSql = "INSERT INTO FinancialCalendar ([StartDate], [EndDate], [DaysInPeriod], [PerodStatus], [PeriodNo], [SmsSalesStatus]) VALUES " _
                            & "('" & strStartDate & "', '" & strEndDate & "', " & intDays & ", '" & UCase(strCloseStatus) & "', " & (i + 1) & ", '" & UCase(strSmsStatus) & "')"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                End If
            End If
        Next
        MessageBox.Show("Financial Periods Saved Successfully", "Financial Periods Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Financial Periods Save Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function ValidatePeriods() As Boolean
        Dim boolValid As Boolean = False
        Dim intCounter As Integer = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                        intCounter = intCounter + 1
                    End If
                End If
            End If
        Next
        If intCounter = CInt(txtPeriods.Text) Then boolValid = True
        Return boolValid
    End Function

    Private Sub LoadDetails()
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand

        Dim intYear As Integer = DatePart(DateInterval.Year, Now)

        If gwt_comm.CheckColumnExistence("FinancialYear", "ActiveYear") = False Then
            objCommand = New Data.OleDb.OleDbCommand("ALTER TABLE FinancialYear ADD [ActiveYear][INT] NOT NULL DEFAULT " & intYear & "", cnn)
            objCommand.ExecuteNonQuery()
        End If

        objCommand = New Data.OleDb.OleDbCommand("SELECT * FROM FinancialYear", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("StartMonth").ToString) Then cboStartMonth.Text = objReader("StartMonth").ToString
            If Not IsDBNull(objReader("EndMonth").ToString) Then cboEndMonth.Text = objReader("EndMonth").ToString
            '[PriorYearPosting], [PriorPeriodPosting], [PriorDayPosting]
            If Not IsDBNull(objReader("PriorYearPosting").ToString) Then
                If UCase(objReader("PriorYearPosting").ToString) = "YES" Then chkCurrentYear.Checked = True
            End If
            If Not IsDBNull(objReader("PriorPeriodPosting").ToString) Then
                If UCase(objReader("PriorPeriodPosting").ToString) = "YES" Then chkCurrentPeriod.Checked = True
            End If
            If Not IsDBNull(objReader("PriorDayPosting").ToString) Then
                If UCase(objReader("PriorDayPosting").ToString) = "YES" Then chkCurrentDate.Checked = True
            End If
            If IsNumeric(objReader("FinancialPeriods").ToString) Then
                txtPeriods.Text = objReader("FinancialPeriods").ToString
                SetGridRows(CInt(txtPeriods.Text))
            End If

            If Not IsDBNull(objReader("ActiveYear").ToString) Then txtYear.Text = objReader("ActiveYear").ToString
            objReader.Close()
        Else
            txtPeriods.Text = "12"
            txtYear.Text = CStr(intYear)
            SetGridRows(12)
            objReader.Close()
            Exit Sub
        End If


        'Load the calendar details
        objCommand = New Data.OleDb.OleDbCommand("SELECT [StartDate], [EndDate], [DaysInPeriod], " _
            & "[PerodStatus], [SmsSalesStatus], [PeriodNo] FROM FinancialCalendar ORDER BY PeriodNo", cnn)
        objReader = objCommand.ExecuteReader
        Dim p As Integer = 0
        While objReader.Read
            If IsDate(objReader(0).ToString) Then dGrid.Rows(p).Cells(0).Value = Format(CDate(objReader(0).ToString), "dd-MM-yyyy")
            If IsDate(objReader(1).ToString) Then dGrid.Rows(p).Cells(1).Value = Format(CDate(objReader(1).ToString), "dd-MM-yyyy")
            If IsNumeric(objReader(2).ToString) Then dGrid.Rows(p).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dGrid.Rows(p).Cells(3).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then dGrid.Rows(p).Cells(4).Value = objReader(4).ToString
            If IsNumeric(objReader(5).ToString) Then dGrid.Rows(p).Cells(5).Value = objReader(5).ToString
            p = p + 1
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Financial Periods Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        SaveFinancialPeriods()
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 0 To dGrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
                dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub txtPeriods_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeriods.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then
            Exit Sub
        Else
            If Asc(e.KeyChar) = 13 Then
                txtYear.Select()
                Exit Sub
            Else
                If Not IsNumeric(e.KeyChar) Then e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPeriods_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPeriods.Validating
        If IsNumeric(txtPeriods.Text) Then
            If CInt(txtPeriods.Text) > 0 Then
                SetGridRows(CInt(txtPeriods.Text))
            End If
        End If
    End Sub

    Private Sub SetGridRows(ByVal NumberOfRows As Integer)
        Dim intCurrentRows As Integer = dGrid.RowCount
        Dim intRequiredRows As Integer = NumberOfRows - intCurrentRows
        If intRequiredRows > 0 Then
            dGrid.Rows.Add(intRequiredRows)
        End If
    End Sub

    Private Sub frmFinancialPeriods_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 708 : Me.Height = 494
    End Sub

End Class
