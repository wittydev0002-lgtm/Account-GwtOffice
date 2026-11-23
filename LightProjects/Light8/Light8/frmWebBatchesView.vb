Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmWebBatchesView

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmWebBatchesView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT BatchNo, CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "ReceivingBranch FROM InventoryTransfers GROUP BY BatchNo, TransDate, ReceivingBranch ORDER BY BatchNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        While objReader.Read
            With dGrid
                .Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                    If Not IsDBNull(objReader(1).ToString) Then
                        .Rows(.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                    End If
                    If Not IsDBNull(objReader(2).ToString) Then
                        .Rows(.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
                    End If
                End If
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Transfer Batch Details Load Failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetSelected()
        If dGrid.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        GetSelected()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        GetSelected()
    End Sub

End Class