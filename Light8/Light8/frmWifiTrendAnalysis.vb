Public Class frmWifiTrendAnalysis

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Dim strStartTime As String = "00:00:00"
        Dim strEndTime As String = "00:00:00"

        Dim dStart As Date
        Dim dEnd As Date

        strStartTime = tmeStart.Value.Hour.ToString().PadLeft(2, "0") & ":" & _
            tmeStart.Value.Minute.ToString().PadLeft(2, "0") & ":" & tmeStart.Value.Second.ToString().PadLeft(2, "0")

        strEndTime = tmeEnd.Value.Hour.ToString().PadLeft(2, "0") & ":" & _
            tmeEnd.Value.Minute.ToString().PadLeft(2, "0") & ":" & tmeEnd.Value.Second.ToString().PadLeft(2, "0")

        If optDaily.Checked Then
            Dim arrValues As New ArrayList
            dStart = CDate(gwt_comm.shortMonthDateFormat(dpStartFrom.Value))
            dEnd = CDate(gwt_comm.shortMonthDateFormat(dpEndTo.Value))
            arrValues = gwt_comm.WifiGraphingPoints(dStart, dEnd, "DAILY")
        End If
        If optHourly.Checked Then
            Dim arrValues As New ArrayList
            dStart = CDate(gwt_comm.shortMonthDateFormat(dpStartFrom.Value) & " " & strStartTime)
            dEnd = CDate(gwt_comm.shortMonthDateFormat(dpEndTo.Value) & " " & strEndTime)
            arrValues = gwt_comm.WifiGraphingPoints(dStart, dEnd, "HOURLY")
        End If
        If optWeekly.Checked Then
            Dim arrValues As New ArrayList
            arrValues = gwt_comm.WifiGraphingPoints(gwt_comm.shortMonthDateFormat(dpStartFrom.Value), gwt_comm.shortMonthDateFormat(dpEndTo.Value), "WEEKLY")
        End If
        If opyMonthly.Checked Then
            Dim arrValues As New ArrayList
            arrValues = gwt_comm.WifiGraphingPoints(gwt_comm.shortMonthDateFormat(dpStartFrom.Value), gwt_comm.shortMonthDateFormat(dpEndTo.Value), "MONTHLY")
        End If
    End Sub

    Private Sub frmWifiTrendAnalysis_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 520 : Me.Height = 255
    End Sub

End Class
