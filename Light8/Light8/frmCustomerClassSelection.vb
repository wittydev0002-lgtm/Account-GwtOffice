Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCustomerClassSelection
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmCustomerClassSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [TransactionId] AS [Tid], [Option] FROM [SystemDebtorClassOptions] " _
            & "WHERE [OrdinalNo] = " & intSelectedOrdinalNo & " ORDER BY [TransactionId]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        With dGrid
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(objReader(0), objReader(1))
            End While
            objReader.Close()
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.WaitCursor
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Selected Class Possible Options Value Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        AssignSelected
    End Sub

    Private Sub AssignSelected()
        On Error GoTo RaiseErr
        If Not Object.Equals(dGrid.CurrentRow.Cells(1).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                strSelectedOptionValue = dGrid.CurrentRow.Cells(1).Value
                boolAbort = False
                Me.Close()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.WaitCursor
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Debtor Class Select"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As EventArgs) Handles dGrid.DoubleClick
        AssignSelected()
    End Sub

End Class