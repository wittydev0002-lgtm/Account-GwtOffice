Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventorySpecialsView

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        boolEditStatus = False
        Dim f As New frmInventorySpecials
        f.ShowDialog()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        Cursor = Cursors.WaitCursor
        dGrid.Rows.Clear()
        Dim strSql As String = Nothing

        Select Case cboSearchBy.Text
            Case Is = "Item Code"
                strSql = "SELECT [TransactionId],[AppliesTo],[Description]," _
                    & "CONVERT(NVARCHAR, [StartDate], 105) AS [DateFrom], CONVERT(NVARCHAR, [EndDate], 105) AS [DateTo], " _
                    & "[Condition], CAST(ConditionalMinimaPrice AS DECIMAL (30,2)) AS [Minima] " _
                    & ",CAST(ConditionalMaximaPrice AS DECIMAL (30,2)) AS [Maxima], CAST([Discount] AS DECIMAL (30,2)) " _
                    & "AS [Discount],[DiscountType] FROM ItemSpecials WHERE AppliesTo LIKE '%" & strFind & "%' ORDER BY AppliesTo"

            Case Is = "Description" 'Use the grup name
                strSql = "SELECT [TransactionId],[AppliesTo],[Description]," _
                    & "CONVERT(NVARCHAR, [StartDate], 105) AS [DateFrom], CONVERT(NVARCHAR, [EndDate], 105) AS [DateTo], " _
                    & "[Condition], CAST(ConditionalMinimaPrice AS DECIMAL (30,2)) AS [Minima] " _
                    & ",CAST(ConditionalMaximaPrice AS DECIMAL (30,2)) AS [Maxima], CAST([Discount] AS DECIMAL (30,2)) " _
                    & "AS [Discount],[DiscountType] FROM ItemSpecials WHERE Description LIKE '%" & strFind & "%' ORDER BY Description"

            Case Else
                strSql = "SELECT [TransactionId],[AppliesTo],[Description]," _
                    & "CONVERT(NVARCHAR, [StartDate], 105) AS [DateFrom], CONVERT(NVARCHAR, [EndDate], 105) AS [DateTo], " _
                    & "[Condition], CAST(ConditionalMinimaPrice AS DECIMAL (30,2)) AS [Minima] " _
                    & ",CAST(ConditionalMaximaPrice AS DECIMAL (30,2)) AS [Maxima], CAST([Discount] AS DECIMAL (30,2)) " _
                    & "AS [Discount],[DiscountType] FROM ItemSpecials WHERE AppliesTo LIKE '%" & strFind & "%' ORDER BY AppliesTo"
        End Select
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        With dGrid
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(1)
                If Not IsDBNull(objReader(1).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader(3).ToString
                If Not IsDBNull(objReader(4).ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = objReader(4).ToString
                If Not IsDBNull(objReader(5).ToString) Then .Rows(.Rows.Count - 1).Cells(4).Value = objReader(5).ToString
                If Not IsDBNull(objReader(6).ToString) Then .Rows(.Rows.Count - 1).Cells(5).Value = objReader(6).ToString
                If Not IsDBNull(objReader(7).ToString) Then .Rows(.Rows.Count - 1).Cells(6).Value = objReader(7).ToString
                If Not IsDBNull(objReader(8).ToString) Then .Rows(.Rows.Count - 1).Cells(7).Value = objReader(8).ToString
                If Not IsDBNull(objReader(9).ToString) Then .Rows(.Rows.Count - 1).Cells(8).Value = objReader(9).ToString
                If Not IsDBNull(objReader(0).ToString) Then .Rows(.Rows.Count - 1).Cells(9).Value = objReader(0).ToString
            End While
        End With
        Cursor = Cursors.Default
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Specials Search"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
        Exit Sub
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [TransactionId],[AppliesTo],[Description]," _
            & "CONVERT(NVARCHAR, [StartDate], 105) AS [DateFrom], CONVERT(NVARCHAR, [EndDate], 105) AS [DateTo], " _
            & "[Condition], CAST(ConditionalMinimaPrice AS DECIMAL (30,2)) AS [Minima] " _
            & ",CAST(ConditionalMaximaPrice AS DECIMAL (30,2)) AS [Maxima], CAST([Discount] AS DECIMAL (30,2)) " _
            & "AS [Discount],[DiscountType] FROM ItemSpecials ORDER BY StartDate", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        With dGrid
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(1)
                If Not IsDBNull(objReader(1).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader(3).ToString
                If Not IsDBNull(objReader(4).ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = objReader(4).ToString
                If Not IsDBNull(objReader(5).ToString) Then .Rows(.Rows.Count - 1).Cells(4).Value = objReader(5).ToString
                If Not IsDBNull(objReader(6).ToString) Then .Rows(.Rows.Count - 1).Cells(5).Value = objReader(6).ToString
                If Not IsDBNull(objReader(7).ToString) Then .Rows(.Rows.Count - 1).Cells(6).Value = objReader(7).ToString
                If Not IsDBNull(objReader(8).ToString) Then .Rows(.Rows.Count - 1).Cells(7).Value = objReader(8).ToString
                If Not IsDBNull(objReader(9).ToString) Then .Rows(.Rows.Count - 1).Cells(8).Value = objReader(9).ToString
                If Not IsDBNull(objReader(0).ToString) Then .Rows(.Rows.Count - 1).Cells(9).Value = objReader(0).ToString
            End While
        End With
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On sales special data load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmInventorySpecialsView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnRefreshItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshItems.Click
        LoadData()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If dGrid.Rows.Count > 0 Then DeleteSpecial() Else Exit Sub
    End Sub

    Private Sub DeleteSpecial()
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to delete this item from special?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM ItemSpecials WHERE TransactionId = " _
                & "" & CInt(dGrid.CurrentRow.Cells(9).Value.ToString) & "", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Special has been deleted successfully", "Sales Special Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On sales special delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellClick
        If dGrid.CurrentCell.ColumnIndex = 9 Then DeleteSpecial() Else Exit Sub
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(9).Value.ToString)
        boolEditStatus = True
        Dim f As New frmInventorySpecials
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(9).Value.ToString)
        boolEditStatus = True
        Dim f As New frmInventorySpecials
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnTodaySpecials_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTodaySpecials.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        'Get the items that are on special on that day
        Dim dtToday As Date = gwt_comm.shortMonthDateFormat(Now)
        Dim strSql As String = "SELECT [TransactionId],[AppliesTo],[Description],CONVERT(NVARCHAR, [StartDate], 105) " _
            & "AS [DateFrom], CONVERT(NVARCHAR, [EndDate], 105) AS [DateTo], [Condition], CAST(ConditionalMinimaPrice " _
            & "AS DECIMAL (30,2)) AS [Minima] ,CAST(ConditionalMaximaPrice AS DECIMAL (30,2)) AS [Maxima], " _
            & "CAST([Discount] AS DECIMAL (30,2)) AS [Discount],[DiscountType] FROM ItemSpecials WHERE " _
            & "StartDate <= '" & dtToday & "' AND EndDate >= '" & dtToday & "' ORDER BY StartDate"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        With dGrid
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(1)
                If Not IsDBNull(objReader(1).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader(3).ToString
                If Not IsDBNull(objReader(4).ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = objReader(4).ToString
                If Not IsDBNull(objReader(5).ToString) Then .Rows(.Rows.Count - 1).Cells(4).Value = objReader(5).ToString
                If Not IsDBNull(objReader(6).ToString) Then .Rows(.Rows.Count - 1).Cells(5).Value = objReader(6).ToString
                If Not IsDBNull(objReader(7).ToString) Then .Rows(.Rows.Count - 1).Cells(6).Value = objReader(7).ToString
                If Not IsDBNull(objReader(8).ToString) Then .Rows(.Rows.Count - 1).Cells(7).Value = objReader(8).ToString
                If Not IsDBNull(objReader(9).ToString) Then .Rows(.Rows.Count - 1).Cells(8).Value = objReader(9).ToString
                If Not IsDBNull(objReader(0).ToString) Then .Rows(.Rows.Count - 1).Cells(9).Value = objReader(0).ToString
            End While
        End With
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On sales special data load"
        gwt_comm.ShowErrorMessage()
    End Sub
End Class