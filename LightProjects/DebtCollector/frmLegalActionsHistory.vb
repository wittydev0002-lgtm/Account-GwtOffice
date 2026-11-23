Imports CommonLibrary.Commons

Public Class frmLegalActionsHistory

    Private Sub frmLegalActionsHistory_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        dGrid.Columns.Clear()
        Dim strBuffer() As String = Split(strGridHeaders, "|")
        For p As Integer = 0 To strBuffer.Length - 1
            dGrid.Columns.Add("Column" & CStr(p + 1), strBuffer(p))
        Next

        For p As Integer = 0 To arrRetriedData.Count - 1
            strBuffer = Split(arrRetriedData.Item(p), "|")
            dGrid.Rows.Add(1)
            For q As Integer = 0 To strBuffer.Length - 1
                dGrid.Rows(dGrid.Rows.Count - 1).Cells(q).Value = strBuffer(q)
            Next
        Next
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Actions History Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

End Class
