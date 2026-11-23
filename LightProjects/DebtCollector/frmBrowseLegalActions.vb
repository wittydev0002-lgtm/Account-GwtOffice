Imports CommonLibrary.Commons

Public Class frmBrowseLegalActions

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub AddStageTreeNodes()
        On Error GoTo RaiseErr
        tvStages.Nodes.Clear()
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = 0 ORDER BY [ProcedureId]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim node As New TreeNode
            node.Text = objReader(0).ToString
            node.Tag = objReader(1).ToString
            AddStageNodes(node)
            tvStages.Nodes.Add(node)
        End While
        objReader.Close()
        tvStages.ExpandAll()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
        ShowErrorMessage()
    End Sub

    Private Sub AddStageNodes(ByRef node As TreeNode)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = '" & node.Tag & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim nNode As New TreeNode
            nNode.Text = objReader(0).ToString
            nNode.Tag = objReader(1).ToString
            AddStageNodes(nNode)
            node.Nodes.Add(nNode)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmBrowseLegalActions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddStageTreeNodes()
    End Sub

    Private Sub tvStages_DoubleClick(sender As Object, e As System.EventArgs) Handles tvStages.DoubleClick
        On Error Resume Next
        Dim intK As Integer = 0
        intK = CInt(tvStages.SelectedNode.Tag)
        Dim strKeyValue As String = Nothing
        strKeyValue = tvStages.SelectedNode.Text
        dGrid.Rows.Add(intK, strKeyValue)
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        arrSelectedItems = New ArrayList
        arrSelectedSerialNumbers = New ArrayList
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(0).Value.ToString) Then
                        arrSelectedSerialNumbers.Add(dGrid.Rows(p).Cells(0).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    arrSelectedItems.Add(dGrid.Rows(p).Cells(1).Value.ToString)
                End If
            End If
        Next
        boolAbort = False
        Me.Close()
    End Sub

End Class
