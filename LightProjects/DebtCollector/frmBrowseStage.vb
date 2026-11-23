Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBrowseStage

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        intSelectedStageId = 0
        Me.Close()
    End Sub

    Private Sub AddStageTreeNodes()
        On Error GoTo RaiseErr
        tvAccounts.Nodes.Clear()
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = 0 ORDER BY [ProcedureId]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim node As New TreeNode
            node.Text = objReader(0).ToString
            node.Tag = objReader(1).ToString
            AddStageNodes(node)
            tvAccounts.Nodes.Add(node)
        End While
        objReader.Close()
        tvAccounts.ExpandAll()
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

    Private Sub frmBrowseStage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddStageTreeNodes()
    End Sub

    Private Sub tvAccounts_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvAccounts.AfterSelect
        On Error Resume Next
        intSelectedStageId = 0
        intSelectedStageId = CInt(tvAccounts.SelectedNode.Tag)
        strSelectedDescription = tvAccounts.SelectedNode.FullPath.ToString
    End Sub

    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click
        boolAbort = False
        Me.Close()
    End Sub

End Class