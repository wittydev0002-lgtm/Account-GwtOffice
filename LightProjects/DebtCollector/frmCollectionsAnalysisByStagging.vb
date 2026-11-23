Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCollectionsAnalysisByStagging

    Private Sub frmCollectionsAnalysisByStagging_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
     
        LoadActions()
    End Sub

    Private Sub LoadActions()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT ProcessAction, ActionKey FROM LegalDebtCollectionStages ORDER BY TransactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim strRootKey As String = Nothing
        Dim arrItems As New ArrayList
        Dim arrOutput As New ArrayList

        While objReader.Read
            Dim strBuffer() As String = Split(objReader(0).ToString, "\")
            If strBuffer.Length = 2 Then
                Dim strKey() As String = Split(objReader(1).ToString, ".")
                dGridPortfolioAnalysis.Rows.Add(strKey(0), strBuffer(0))
                dGridPortfolioAnalysis.Rows.Add(objReader(1).ToString, "   " & strBuffer(1))

                Dim aNode As Ai.Control.TreeNode = New Ai.Control.TreeNode
                aNode.Text = strBuffer(0)
                aNode.SubItems.Add(strBuffer(0))
            Else
                Dim intSpace As Integer = strBuffer.Length - 1
                'dGrid.Rows.Add(objReader(1).ToString, StrDup((intSpace * 3), "."c) & strBuffer(strBuffer.Length - 1))
                dGridPortfolioAnalysis.Rows.Add(objReader(1).ToString, StrDup((intSpace * 3), " "c) & strBuffer(strBuffer.Length - 1))
            End If
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stagging setup"
        ShowErrorMessage()
    End Sub

    '    Private Sub LoadTreeViewUsingFullPath()
    '        On Error GoTo RaiseErr
    '        Dim strSql As String = "SELECT ProcessAction FROM LegalDebtCollectionStages ORDER BY TransactionId"
    '        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '        tvActions.Nodes.Clear()
    '        Dim nodes = tvActions.Nodes
    '        While objReader.Read
    '            If Not IsDBNull(objReader(0).ToString) Then
    '                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
    '                    AddNodeWithPath(nodes, objReader(0).ToString)
    '                End If
    '            End If
    '        End While
    '        objReader.Close()
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stagging setup"
    '        ShowErrorMessage()
    '    End Sub

    '    Private Function AddNodeWithPath(nodes As Ai.Control.TreeNodeCollection, path As String) As Ai.Control.TreeNode
    '        'Dim leaf As String = IO.Path.GetFileName(path)
    '        'If path <> leaf Then
    '        '    nodes = AddNodeWithPath(nodes, IO.Path.GetDirectoryName(path)).Nodes
    '        'End If
    '        'Dim matchingNodes As Ai.Control.TreeNode() = nodes.Find(leaf, False)
    '        'Dim node As Ai.Control.TreeNode

    '        'If matchingNodes.Length = 0 Then
    '        '    node = nodes.Add(leaf, leaf)
    '        'Else
    '        '    node = matchingNodes(0)
    '        'End If
    '        'Return node
    '    End Function

End Class
