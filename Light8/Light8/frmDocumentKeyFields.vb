Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDocumentKeyFields

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmDocumentKeyFields_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dGrid.Rows.Add(150)
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT DocumentKey, TableName, FieldName FROM DocumentKeyFields ORDER BY TransactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim intRow As Integer = 0
        While objReader.Read
            dGrid.Rows(intRow).Cells(0).Value = objReader(0)
            dGrid.Rows(intRow).Cells(1).Value = objReader(1)
            dGrid.Rows(intRow).Cells(2).Value = objReader(2)
            intRow += 1
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Document Keys Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If dGrid.Rows.Count <= 0 Then Exit Sub
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM DocumentKeyFields", cnn)
        objCommand.ExecuteNonQuery()
        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim strDocKey As String = Nothing
            Dim strTableName As String = Nothing
            Dim strFieldName As String = Nothing
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strDocKey = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    strTableName = dGrid.Rows(p).Cells(1).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    strFieldName = dGrid.Rows(p).Cells(2).Value.ToString
                End If
            End If
            If Not String.IsNullOrEmpty(strDocKey) Then
                If Not String.IsNullOrEmpty(strTableName) Then
                    If Not String.IsNullOrEmpty(strFieldName) Then
                        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO DocumentKeyFields " _
                            & "(DocumentKey, TableName, FieldName) VALUES ('" & strDocKey & "', " _
                            & "'" & strTableName & "', '" & strFieldName & "')", cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                End If
            End If
        Next
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Document Keys Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        On Error GoTo RaiseErr
        If e.ColumnIndex = 2 Then
            Dim strTableName As String = Nothing
            Dim strFieldName As String = Nothing
            If Not Object.Equals(dGrid.CurrentRow.Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                    strTableName = dGrid.CurrentRow.Cells(1).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.CurrentRow.Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(2).Value.ToString) Then
                    strFieldName = dGrid.CurrentRow.Cells(2).Value.ToString
                End If
            End If
            If Not String.IsNullOrEmpty(strTableName) Then
                If Not String.IsNullOrEmpty(strFieldName) Then
                    If gwt_comm.CheckColumnExistence(strTableName, strFieldName) = False Then
                        MessageBox.Show("This field does not exist in the specified table", "Invalid Field Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Document Keys Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmDocumentKeyFields_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 480 : Me.Height = 460
    End Sub

End Class
