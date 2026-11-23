Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmStageConversion

    Private Sub frmStageConversion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        If gwt_comm.CheckTableExistence("ConversionKeys") = False Then
            objCommand = New Data.OleDb.OleDbCommand("CREATE TABLE ConversionKeys ([ProcedureName][NVARCHAR](MAX) NOT NULL DEFAULT '', " _
                & "[ActionName][NVARCHAR](MAX) NOT NULL DEFAULT '', [ActionKey][INT] NOT NULL DEFAULT 0)", cnn)
            objCommand.ExecuteNonQuery()
        End If
        LoadData()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Legacy Procedures and Actions Load"
        ShowErrorMessage()
    End Sub

    Private Function SavedKey(ProcedureName As String, Action As String) As Integer
        On Error GoTo RaiseErr
        Dim intReturn As Integer = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [ActionKey] FROM ConversionKeys " _
            & "WHERE ProcedureName = '" & ProcedureName & "' AND ActionName = '" & Action & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intReturn = CInt(objReader(0).ToString)
            End If
        End If
        objReader.Close()
        Return intReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Legacy Procedures and Actions Load"
        ShowErrorMessage()
    End Function

    Private Sub frmStageConversion_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 820 : Me.Height = 560
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT(ProcedureName), ActionTaken " _
            & "FROM LegalActions GROUP BY ProcedureName, ActionTaken", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        With dGrid
            .Rows.Clear()
            While objReader.Read
                dGrid.Rows.Add(objReader(0), objReader(1), SavedKey(objReader(0).ToString, objReader(1).ToString))
            End While
        End With
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Legacy Procedures and Actions Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellClick
        If e.ColumnIndex = 3 Then
            intSelectedStageId = 0
            boolAbort = False
            Dim frm As New frmBrowseStage
            frm.ShowDialog()
            If boolAbort = True Then Exit Sub
            dGrid.CurrentRow.Cells(2).Value = intSelectedStageId
        End If
        If e.ColumnIndex = 4 Then
            dGrid.CurrentRow.Cells(2).Value = 0
        End If
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM ConversionKeys", cnn)
        objCommand.ExecuteNonQuery()

        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim strProcedure As String = Nothing
            Dim strAction As String = Nothing
            Dim intKey As Integer = 0
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strProcedure = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    strAction = dGrid.Rows(p).Cells(1).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(2).Value.ToString) Then
                        intKey = CInt(dGrid.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
            End If
            If intKey > 0 Then
                Dim strSql As String = "UPDATE LegalActions SET ActionKey = " & intKey & " WHERE " _
                    & "ProcedureName = '" & strProcedure & "' AND ActionTaken = '" & strAction & "'"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO ConversionKeys (ProcedureName, ActionName, ActionKey) " _
                    & "VALUES ('" & strProcedure & "', '" & strAction & "', " & intKey & ")", cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next

        MessageBox.Show("Legacy procedures and actions have been updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Legacy Procedures and Actions Re-alignment"
        ShowErrorMessage()
    End Sub

End Class