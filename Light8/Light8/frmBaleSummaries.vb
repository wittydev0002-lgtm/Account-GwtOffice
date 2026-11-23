Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBaleSummaries

    Private Sub frmBaleSummaries_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        With arrSelectedItems
            For p As Integer = 0 To .Count - 1
                Dim strBuffer() As String = Split(.Item(p), "|")
                dGrid.Rows.Add(strBuffer(0), Format(CDbl(strBuffer(1)), "##0.00"),
                    Format(CDbl(strBuffer(2)), "##0.00"), Format(CDbl(strBuffer(3)), "##0.00"),
                    Format(CDbl(strBuffer(4)), "##0.00"), Format(CDbl(strBuffer(5)), "##0.00"))
            Next
        End With
        dGrid.Rows.Add("TOTALS", "", "", "", "", "")
        Dim dblColTotals(0 To 5) As Double

        With dGrid
            For p As Integer = 1 To .ColumnCount - 1
                If p = 1 Or p = 2 Or p = 4 Then
                    For j As Integer = 0 To .Rows.Count - 2
                        If Not Object.Equals(.Rows(j).Cells(p).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.Rows(j).Cells(p).Value.ToString) Then
                                If IsNumeric(.Rows(j).Cells(p).Value.ToString) Then
                                    dblColTotals(p - 1) = dblColTotals(p - 1) + CDbl(.Rows(j).Cells(p).Value.ToString)
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        End With

        dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = Format(dblColTotals(0), "#,##0.00")
        dGrid.Rows(dGrid.Rows.Count - 1).Cells(2).Value = Format(dblColTotals(1), "#,##0.00")
        dGrid.Rows(dGrid.Rows.Count - 1).Cells(3).Value = Format((dblColTotals(1) / dblColTotals(0)), "#,##0.00")
        dGrid.Rows(dGrid.Rows.Count - 1).Cells(4).Value = Format(dblColTotals(3), "#,##0.00")
        dGrid.Rows(dGrid.Rows.Count - 1).Cells(5).Value = Format((dblColTotals(3) / dblColTotals(0)), "#,##0.00")

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On form data load"
        ShowErrorMessage()
    End Sub

End Class