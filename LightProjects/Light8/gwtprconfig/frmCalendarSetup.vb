Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmCalendarSetup

    Private Sub LoadDetails()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT TOP " & CInt(txtNumberOfRuns.Text) & " TaxPeriod, " _
            & "RunInPeriod, RunsInPeriod, CONVERT(NVARCHAR, StartDate, 105) " _
            & "AS [sDate], CONVERT(NVARCHAR, EndDate, 105) AS [eDate], RunStatus " _
            & "FROM SystemCalendar ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim i As Integer = 0

        'If the calendar has been saved before then populate the records
        Dim p As Integer = 0
        While objReader.Read
            With dGrid
                'dGrid.Rows.Add(1)
                Dim strBuffer() As String
                If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(p).Cells(0).Value = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(p).Cells(1).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then dGrid.Rows(p).Cells(2).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then
                    If IsDate(objReader(3).ToString) Then
                        dGrid.Rows(p).Cells(3).Value = CDate(objReader(3).ToString)
                    End If
                End If
                If Not IsDBNull(objReader(4).ToString) Then
                    If IsDate(objReader(4).ToString) Then
                        dGrid.Rows(p).Cells(4).Value = CDate(objReader(4).ToString)
                    End If
                End If
                If Not IsDBNull(objReader(5).ToString) Then dGrid.Rows(p).Cells(5).Value = objReader(5).ToString
            End With
            p += 1
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Calendar Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmCalendarSetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        boolFormInitializing = True
        If intPayrollNoOfRuns <= 0 Then
            txtNumberOfRuns.Text = "12"
        Else
            txtNumberOfRuns.Text = intPayrollNoOfRuns
        End If
        LoadDetails()
        boolFormInitializing = False
    End Sub

    Private Sub tsSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSave.Click
        On Error GoTo RaiseErr

        If Not IsNumeric(txtNumberOfRuns.Text) Then
            MessageBox.Show("Please enter a valid value for the number of runs", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNumberOfRuns.Focus()
            Exit Sub
        End If

        Dim CurrentCell As DataGridViewCell
        Dim i As Integer
        Dim strTaxPeriod As String
        Dim strRunInMonth As String
        Dim strRunsInMonth As String
        Dim strStartDate As String
        Dim strEndDate As String
        Dim strStatus As String = "N"
        Dim strCalendarLine As String

        'On save always delete first everything that is in the calendar table

        For i = 0 To intNumberOfPayrollRuns - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                CurrentCell = dGrid.Rows(i).Cells(0)
                strTaxPeriod = CurrentCell.Value
                CurrentCell = dGrid.Rows(i).Cells(1)
                strRunInMonth = CurrentCell.Value.ToString
                CurrentCell = dGrid.Rows(i).Cells(2)
                strRunsInMonth = CurrentCell.Value
                CurrentCell = dGrid.Rows(i).Cells(3)
                strStartDate = CurrentCell.Value
                CurrentCell = dGrid.Rows(i).Cells(4)
                strEndDate = CurrentCell.Value
                CurrentCell = dGrid.Rows(i).Cells(5)
                strStatus = CurrentCell.Value
                'Validate the input before entry
                If Not IsNumeric(strTaxPeriod) Or Not IsNumeric(strRunInMonth) _
                    Or Not IsNumeric(strRunsInMonth) Or Not IsDate(strStartDate) _
                    Or Not IsDate(strEndDate) Then
                    MessageBox.Show("One of the input data in row " & (i + 1) & _
                        " is incorrect. Please correct it before proceeding", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
        Next i

        'Once the data is correct, you can now save it

        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemCalendar", cnn)
        sqlCommand.ExecuteNonQuery()
        For i = 0 To dGrid.Rows.Count - 1
            strTaxPeriod = 1
            strRunInMonth = 1
            strRunsInMonth = 1
            strStartDate = Nothing
            strEndDate = Nothing
            strStatus = "N"
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                CurrentCell = dGrid.Rows(i).Cells(0)
                strTaxPeriod = CurrentCell.Value
                CurrentCell = dGrid.Rows(i).Cells(1)
                strRunInMonth = CurrentCell.Value.ToString
                CurrentCell = dGrid.Rows(i).Cells(2)
                strRunsInMonth = CurrentCell.Value
                CurrentCell = dGrid.Rows(i).Cells(3)
                strStartDate = CurrentCell.Value
                CurrentCell = dGrid.Rows(i).Cells(4)
                strEndDate = CurrentCell.Value
                CurrentCell = dGrid.Rows(i).Cells(5)
                strStatus = CurrentCell.Value
                'validate the run status
                If UCase(strStatus) <> "Y" Then
                    strStatus = "N"
                End If
            End If
            If IsDate(strStartDate) Then
                If UCase(strSystemDateFormat) = UCase("English") Then strStartDate = CStr(Format(CDate(strStartDate), "dd-MMM-yyyy"))
            End If
            If IsDate(strEndDate) Then
                If UCase(strSystemDateFormat) = UCase("English") Then strEndDate = CStr(Format(CDate(strEndDate), "dd-MMM-yyyy"))
            End If
            sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemCalendar " _
                & "(TaxPeriod, RunInPeriod, RunsInPeriod, StartDate, EndDate, RunStatus) " _
                & "VALUES (" & CInt(strTaxPeriod) & ", " & CInt(strRunInMonth) & ", " _
                & "" & CInt(strRunsInMonth) & ", '" & strStartDate & "', '" & strEndDate & "', " _
                & "'" & strStatus & "')", cnn)
            sqlCommand.ExecuteNonQuery()
        Next i

        MessageBox.Show("Payroll calendar updated successfully", "Payroll Calendar Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Calendar Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtNumberOfRuns_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumberOfRuns.TextChanged
        If Not IsNumeric(txtNumberOfRuns.Text) Then
            Exit Sub
        End If
        If CInt(txtNumberOfRuns.Text) <= dGrid.Rows.Count Then Exit Sub
        dGrid.Rows.Add(CInt(txtNumberOfRuns.Text) - dGrid.Rows.Count)
    End Sub

End Class
