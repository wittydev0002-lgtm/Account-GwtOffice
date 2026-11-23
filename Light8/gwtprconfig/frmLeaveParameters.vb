Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmLeaveParameters

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Me.txtDescription.Text = "" Or Mid(Me.txtDescription.Text, 1, 1) = " " Then
            MessageBox.Show("Either the date description is empty or begins with spaces. Please re-enter", _
                "Invalid Date Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtDescription.Focus()
            Exit Sub
        End If
        With Me.dGrid
            .Rows.Add(1)
            .Rows(.RowCount - 1).Cells(0).Value = Me.dtpDate.Text
            .Rows(.RowCount - 1).Cells(1).Value = Me.txtDescription.Text
            Me.txtDescription.Clear()
        End With
        If dGrid.Rows.Count <= 0 Then btnSaveAll.Enabled = False Else btnSaveAll.Enabled = True
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dGrid.Rows.Count = 0 Then Exit Sub
        Dim i As Integer = Me.dGrid.CurrentRow.Index
        If i >= 0 Then Me.dGrid.Rows.RemoveAt(Me.dGrid.CurrentRow.Index)
        If dGrid.Rows.Count <= 0 Then btnSaveAll.Enabled = False Else btnSaveAll.Enabled = True
    End Sub

    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click
        'Write the information read off the datagrid
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim i As Integer
        Dim strDate As String = Nothing
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemHolidays", cnn)
        objCommand.ExecuteNonQuery()
        For i = 0 To Me.dGrid.RowCount - 1
            strDate = CStr(Now.ToShortDateString)
            Dim strDescription As String = "Not Defined"
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                strDescription = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
            End If
            If Not (Object.Equals(Convert.ToDateTime(dGrid.Rows(i).Cells(0).Value), "")) Then
                strDate = Convert.ToDateTime(dGrid.Rows(i).Cells(0).Value)
                If UCase(strSystemDateFormat) = UCase("English") Then
                    strDate = CStr(gwt_comm.shortMonthDateFormat(CDate(strDate)))
                End If
            End If
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemHolidays (NoWorkDate, Description) VALUES " _
                & "('" & strDate & "', '" & strDescription & "')", cnn)
            objCommand.ExecuteNonQuery()
        Next
        'Write the standard working days per week flag
        Dim strFlag As String = Nothing
        If Me.chkExcludeBoth.Checked = True Then strFlag = "ExcludeBoth"
        If Me.chkIncludeSaturday.Checked = True Then strFlag = "IncludeSaturday"
        If Me.chkIncludeSunday.Checked = True Then strFlag = "IncludeSunday"
        If Me.chkIncludeBoth.Checked = True Then strFlag = "IncludeBoth"
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemNonWorkDays", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemNonWorkDays (NoWorkDays) VALUES ('" & strFlag & "')", cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("The leave parameter files have been successfully updated", _
            "Payroll Leave Parameters Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = False
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on Non Working Days Save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function MonthString(ByVal strMonth As String) As String
        Dim intMonth As Integer = 1
        Select Case UCase(strMonth)
            Case Is = "JAN"
                intMonth = 1
            Case Is = "FEB"
                intMonth = 2
            Case Is = "MAR"
                intMonth = 3
            Case Is = "APR"
                intMonth = 4
            Case Is = "MAY"
                intMonth = 5
            Case Is = "JUN"
                intMonth = 6
            Case Is = "JUL"
                intMonth = 7
            Case Is = "AUG"
                intMonth = 8
            Case Is = "SEP"
                intMonth = 9
            Case Is = "OCT"
                intMonth = 10
            Case Is = "NOV"
                intMonth = 11
            Case Is = "DEC"
                intMonth = 12
        End Select
        Return intMonth
    End Function

    Private Sub frmLeaveParameters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'The default is a 5 working days
        Me.chkExcludeBoth.Checked = True
        'Open the holiday and workdays file and get the values and then populate accordingly
        On Error GoTo RaiseErr
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strLine As String
        Dim strBuffer() As String
        Dim strDateBuffer() As String
        Dim i As Integer
        Dim CurrentCell As DataGridViewCell
        'Dim bolDiscontinued As Boolean
        Dim strFlag As String = Nothing
        Dim strDate As String = Nothing
        'bolDiscontinued = False

        objCommand = New Data.OleDb.OleDbCommand("SELECT * FROM SystemHolidays ORDER BY TransactionId", cnn)
        objReader = objCommand.ExecuteReader

        'If bolDiscontinued = False Then
        i = 0
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(1)
            If IsDate(objReader("NoWorkDate").ToString) Then
                CurrentCell = dGrid.Rows(i).Cells(0)
                CurrentCell.Value = CDate(objReader("NoWorkDate").ToString).ToShortDateString
            End If
            If Not IsDBNull(objReader("Description").ToString) Then
                CurrentCell = dGrid.Rows(i).Cells(1)
                CurrentCell.Value = objReader("Description").ToString
            End If
            i += 1
        End While
        objReader.Close()

        'Get the weekend workidays style from the file
        objCommand = New Data.OleDb.OleDbCommand("SELECT NoWorkDays FROM SystemNonWorkDays", cnn)
        objReader = objCommand.ExecuteReader

        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strFlag = objReader(0).ToString
        End If
        objReader.Close()

        If strFlag = "ExcludeBoth" Then Me.chkExcludeBoth.Checked = True
        If strFlag = "IncludeSaturday" Then Me.chkIncludeSaturday.Checked = True
        If strFlag = "IncludeSunday" Then Me.chkIncludeSunday.Checked = True
        If strFlag = "IncludeBoth" Then Me.chkIncludeBoth.Checked = True

        If dGrid.Rows.Count <= 0 Then btnSaveAll.Enabled = False Else btnSaveAll.Enabled = True
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error No " & Err.Number & vbCr & "on Non Working Days Setup Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function MonthName(ByVal intMonth As Integer) As String
        Dim strMonth As String = "JAN"
        Select Case intMonth
            Case Is = 1
                strMonth = "JAN"
            Case Is = 2
                strMonth = "FEB"
            Case Is = 3
                strMonth = "MAR"
            Case Is = 4
                strMonth = "APR"
            Case Is = 5
                strMonth = "MAY"
            Case Is = 6
                strMonth = "JUN"
            Case Is = 7
                strMonth = "JUL"
            Case Is = 8
                strMonth = "AUG"
            Case Is = 9
                strMonth = "SEP"
            Case Is = 10
                intMonth = "OCT"
            Case Is = 11
                strMonth = "NOV"
            Case Is = 12
                strMonth = "DEC"
        End Select
        Return strMonth
    End Function

    Private Sub txtDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

End Class
