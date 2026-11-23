Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDocumentFieldsView

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadUserFields()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT DocumentKey, TableName, FieldName FROM DocumentKeyFields ORDER BY TransactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(1)
            dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader(0)
            dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader(1)
            dGrid.Rows(dGrid.Rows.Count - 1).Cells(2).Value = objReader(2)
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

    Private Sub frmDocumentFieldsView_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadUserFields()
    End Sub

    Private Sub frmDocumentFieldsView_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 585 : Me.Height = 380
    End Sub

End Class
