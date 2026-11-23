Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmPayrollUserReports

    Private Sub frmPayrollUserReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT ReportNo, ReportName " _
            & "FROM SystemColumnReportHeaders ORDER BY ReportNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        dgrid.Rows.Clear()
        While objReader.Read
            dgrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(2).Value = objReader(1).ToString
        End While
        objReader.Close()
        If dgrid.Rows.Count <= 0 Then
            dgrid.Enabled = False
            btnPrint.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
        Else
            dgrid.Enabled = True
            btnPrint.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Column Reports Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If dgrid.Enabled = True Then
            If dgrid.Rows.Count > 0 Then
                intSelectedReport = CInt(dgrid.CurrentRow.Cells(0).Value.ToString)
                gwt_comm.PrintColumnReport(intSelectedReport)
            End If
        End If
    End Sub

    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrid.DoubleClick
        'Get the selected report number
        If dgrid.Enabled = True Then
            If dgrid.Rows.Count > 0 Then
                intSelectedReport = CInt(dgrid.CurrentRow.Cells(0).Value.ToString)
                gwt_comm.PrintColumnReport(intSelectedReport)
            End If
        End If
    End Sub

End Class
