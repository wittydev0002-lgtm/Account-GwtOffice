Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmAgingAnalysisParameters

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        boolAbort = False

        If Not IsNumeric(txtDaysPerPeriod.Text) Then
            MessageBox.Show("Please enter the number of days per analysis period", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDaysPerPeriod.Select()
            Exit Sub
        End If
        If Not IsNumeric(txtIntervals.Text) Then
            MessageBox.Show("Please enter the number of intervals", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtIntervals.Select()
            Exit Sub
        End If

        dtSetDate = CDate(Format(dpEndDate.Value, "dd-MMM-yyyy"))

        intAgingDaysPerPeriod = CInt(txtDaysPerPeriod.Text)
        intAgingIntervals = CInt(txtIntervals.Text)

        Me.Close()

    End Sub

    Private Sub frmAgingAnalysisParameters_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ActivateDefaultDate()
    End Sub

    Private Sub ActivateDefaultDate()
        dpEndDate.Value = CDate(Format(Now, "dd-MMM-yyyy"))
        Dim intCurrentMonth As Integer = DatePart(DateInterval.Month, dpEndDate.Value)
        Dim intCurrentYear As Integer = DatePart(DateInterval.Year, dpEndDate.Value)

        Dim intPreviousMonth As Integer = intCurrentMonth - 1
        Dim intPreviousYear As Integer = intCurrentYear

        If intPreviousMonth < 0 Then
            intPreviousMonth = 12
            intPreviousYear = intCurrentYear - 1
        End If

        Dim dtLastDay As Date = gwt_comm.GetLastDayOfMonth(intPreviousMonth, intPreviousYear)
        dpEndDate.Value = dtLastDay
        dpEndDate.Enabled = False
    End Sub

    Private Sub chkOveride_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOveride.CheckedChanged
        If chkOveride.Checked = True Then
            MessageBox.Show("Note that change of date may affect the aging analysis" & vbCrLf & _
                            "If cut-off date goes far back into the past, the total" & vbCrLf & _
                            "and current balance may not tally due to time variance", "Action Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dpEndDate.Enabled = True
        Else
            ActivateDefaultDate()
            dpEndDate.Enabled = False
        End If
    End Sub

End Class
