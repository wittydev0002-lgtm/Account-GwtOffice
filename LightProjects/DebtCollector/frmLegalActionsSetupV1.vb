Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLegalActionsSetupV1

    Dim arrItems As ArrayList
    Dim initialParentName As String = Nothing
    Dim arrOutput As New ArrayList

    Private Sub frmLegalActionsSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Dim nodes = tvActions.Nodes
        'AddNodeWithPath(nodes, "Grandparent1\Parent1\Child1")
        'AddNodeWithPath(nodes, "Grandparent1\Parent1\Child2")
        'AddNodeWithPath(nodes, "Grandparent2\Parent1\Child1")
        'AddNodeWithPath(nodes, "Grandparent2")
        'AddNodeWithPath(nodes, "Grandparent3")
        LoadTreeViewUsingFullPath()
    End Sub

    Private Sub LoadTreeViewUsingFullPath()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT ProcessAction FROM LegalDebtCollectionStages ORDER BY TransactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        tvActions.Nodes.Clear()
        Dim nodes = tvActions.Nodes
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    AddNodeWithPath(nodes, objReader(0).ToString)
                End If
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

    Private Sub tvActions_AfterSelect(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvActions.AfterSelect
        On Error Resume Next
        With lblInformation
            .Text = Nothing
            .Text = tvActions.SelectedNode.FullPath
        End With
    End Sub

    'Display context menu when right click on the tree view node
    Private Sub TreeView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvActions.MouseDown

        Dim NodeClicked As TreeNode

        ' Get the node clicked on
        NodeClicked = Me.tvActions.GetNodeAt(e.X, e.Y)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            '  By default, right-clicking on a node does not set 
            ' focus to that node. This is especially important when
            ' you want to use a ContextMenu control and associate
            ' it with a TreeView.  This code shows how to do it.

            Me.tvActions.SelectedNode = NodeClicked

            'Display the context menu
            MyContextMenu.Show(tvActions, New Point(e.X, e.Y))


        End If
    End Sub

    Private Sub Menu1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddRoot.Click

        'Dim strMenuText As String = TreeView1.SelectedNode.Text
        strAddedActionName = Nothing
        boolAbort = False
        Dim frm As New frmLegalActionName
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        If String.IsNullOrEmpty(strAddedActionName) Then Exit Sub
        AddRootNode(strAddedActionName)

    End Sub

    Private Sub AddSubNode(ByRef node As TreeNode)

        On Error Resume Next

        strAddedActionName = Nothing
        boolAbort = False
        Dim frm As New frmLegalActionName
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        Dim nNode As New TreeNode
        nNode.Text = strAddedActionName
        nNode.Tag = node.Tag & "_" & strAddedActionName
        node.Nodes.Add(nNode)

    End Sub

    Private Sub AddRootNode(ByVal NodeText As String)
        Dim node As New TreeNode
        node.Text = NodeText
        node.Tag = NodeText & "_" & CStr(tvActions.Nodes.Count + 1)
        tvActions.Nodes.Add(node)
    End Sub

    Private Sub mnuAddSubRoot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAddSubRoot.Click
        Dim node As New TreeNode
        node = tvActions.SelectedNode
        AddSubNode(node)
    End Sub

    Private Sub mnuRemoveNode_Click(sender As System.Object, e As System.EventArgs) Handles mnuRemoveNode.Click
        RemoveNodes()
    End Sub

    Private Sub RemoveNodes()
        If tvActions.Nodes.Count <= 0 Then Exit Sub
        tvActions.SelectedNode.Nodes.Clear()
        tvActions.SelectedNode.Remove()
    End Sub

    Public Sub MoveNodeUp(ByVal Nod As TreeNode)
        If tvActions.Nodes.Count <= 0 Then Exit Sub
        Try
            If Not (Nod.PrevNode Is Nothing) Then
                Nod.Parent.Nodes.Insert(Nod.Index - 1, CType(Nod.Clone, TreeNode))
                Nod.Remove()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub MoveNodeDown(ByVal Nod As TreeNode)
        If tvActions.Nodes.Count <= 0 Then Exit Sub
        Try
            If Not (Nod.NextNode Is Nothing) Then
                Nod.Parent.Nodes.Insert(Nod.Index + 2, CType(Nod.Clone, TreeNode))
                Nod.Remove()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub MoveNodeRight(ByVal Nod As TreeNode)
        If tvActions.Nodes.Count <= 0 Then Exit Sub
        Try
            If Not (Nod.PrevNode Is Nothing) Then
                Nod.PrevNode.Nodes.Add(CType(Nod.Clone, TreeNode))
                Nod.Remove()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub MoveNodeLeft(ByVal Nod As TreeNode)
        If tvActions.Nodes.Count <= 0 Then Exit Sub
        Try
            If Not (Nod.Parent.Parent Is Nothing) Then
                Nod.Parent.Parent.Nodes.Insert(Nod.Parent.Parent.Index + 2, CType(Nod.Clone, TreeNode))
                Nod.Remove()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnUp_Click(sender As System.Object, e As System.EventArgs) Handles btnUp.Click
        MoveNodeUp(tvActions.SelectedNode)
    End Sub

    Private Sub btnDown_Click(sender As System.Object, e As System.EventArgs) Handles btnDown.Click
        MoveNodeDown(tvActions.SelectedNode)
    End Sub

    Private Sub btnRight_Click(sender As System.Object, e As System.EventArgs) Handles btnRight.Click
        MoveNodeRight(tvActions.SelectedNode)
    End Sub

    Private Sub btnLeft_Click(sender As System.Object, e As System.EventArgs) Handles btnLeft.Click
        MoveNodeLeft(tvActions.SelectedNode)
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        RemoveNodes()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If tvActions.Nodes.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        boolAbort = False
        GetTreeViewItems()
        Dim objfile As New System.IO.StreamWriter(Application.StartupPath & "\Actions.txt", False)
        For p As Integer = 0 To arrItems.Count - 1
            objfile.WriteLine(arrItems.Item(p))
        Next
        objfile.Close()
        boolAbort = False
        CreateStageKeys(arrItems)
        If boolAbort = True Then Exit Sub
        SaveActions()
        If boolAbort = True Then Exit Sub
        MessageBox.Show("Debt recovery actions saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stagging setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnScriptStructure_Click(sender As System.Object, e As System.EventArgs) Handles btnScriptStructure.Click
        If tvActions.Nodes.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        GetTreeViewItems()
        Dim objfile As New System.IO.StreamWriter(Application.StartupPath & "\Actions.txt", False)
        For p As Integer = 0 To arrItems.Count - 1
            objfile.WriteLine(arrItems.Item(p))
        Next
        objfile.Close()
        CreateStageKeys(arrItems)
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stagging data scripting"
        ShowErrorMessage()
    End Sub

    Private Sub GetTreeViewItems()
        arrItems = New ArrayList
        For Each parentNode As TreeNode In tvActions.Nodes
            Dim pNode As TreeNode = GetParentNode(parentNode)
            If Not Object.Equals(pNode.Parent, Nothing) Then
                initialParentName = pNode.Parent.Text
            Else
                initialParentName = Nothing
            End If
            AllChildrenNode(pNode, initialParentName)
        Next
    End Sub

    Private Function GetParentNode(ByVal node As TreeNode) As TreeNode
        If Not Object.Equals(node.Parent, Nothing) Then
            Return GetParentNode(node.Parent)
        Else
            Return node
        End If
    End Function

    Private Sub AllChildrenNode(ParentNode As TreeNode, strParentNode As String)
        For Each childNode As TreeNode In ParentNode.Nodes
            arrItems.Add(childNode.FullPath.ToString)
            AllChildrenNode(childNode, childNode.Parent.Text)
        Next
    End Sub

    Private Sub CreateStageKeys(arrStages As ArrayList)

        On Error GoTo RaiseErr

        Dim strRootKey As String = Nothing

        'Get the highest level 
        Dim intMaxLevel As Integer = 0
        For p As Integer = 0 To arrStages.Count - 1
            Dim strBuffer() As String = Split(arrStages.Item(p), "\")
            If strBuffer.Length > intMaxLevel Then
                intMaxLevel = strBuffer.Length
            End If
        Next

        arrOutput = New ArrayList

        Dim intKeys(0 To intMaxLevel) As Integer
        Dim strKeys(0 To intMaxLevel) As String

        For i As Integer = 0 To strKeys.Length - 1
            strKeys(i) = Nothing
            intKeys(i) = 0
        Next

        For p As Integer = 0 To arrItems.Count - 1
            Dim strBuffer() As String = Split(arrItems.Item(p), "\")
            Dim strActionKey As String = Nothing
            For q As Integer = 0 To strBuffer.Length - 1
                If UCase(strBuffer(q)) <> UCase(strKeys(q)) Then
                    intKeys(q) = intKeys(q) + 1
                    strKeys(q) = strBuffer(q)
                    're initialiase all the keys thereafter
                    For z As Integer = (q + 1) To strKeys.Length - 1
                        intKeys(z) = 0
                        strKeys(z) = Nothing
                    Next
                End If
                strActionKey = strActionKey & CStr(intKeys(q)) & "."
            Next
            strActionKey = Mid(strActionKey, 1, (strActionKey.Length - 1))
            arrOutput.Add(arrItems.Item(p) & "|" & strActionKey)
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Stages Key Allocation"
        ShowErrorMessage()
    End Sub

    Private Sub SaveActions()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM LegalDebtCollectionStages", cnn)
        objCommand.ExecuteNonQuery()
        For p As Integer = 0 To arrOutput.Count - 1
            Dim strBuffer() As String = Split(arrOutput.Item(p), "|")
            Dim strSql As String = "INSERT INTO LegalDebtCollectionStages ([ProcessAction], [ActionKey], [UserName]) VALUES " _
                & "('" & strBuffer(0) & "', '" & strBuffer(1) & "', '" & strPublicActiveFullUserName & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stagging data save"
        ShowErrorMessage()
    End Sub

    Private Function AddNodeWithPath(nodes As TreeNodeCollection, path As String) As TreeNode
        Dim leaf As String = IO.Path.GetFileName(path)
        If path <> leaf Then
            nodes = AddNodeWithPath(nodes, IO.Path.GetDirectoryName(path)).Nodes
        End If
        Dim matchingNodes As TreeNode() = nodes.Find(leaf, False)
        Dim node As TreeNode

        If matchingNodes.Length = 0 Then
            node = nodes.Add(leaf, leaf)
        Else
            node = matchingNodes(0)
        End If
        Return node
    End Function


    Private Sub ButtonItem2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem2.Click
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT DISTINCT(ProcedureName), ActionTaken FROM LegalActions GROUP BY ActionTaken, ProcedureName"
        Dim strSelect As String = "SELECT  [ProcessAction], [ActionKey] FROM LegalDebtCollectionStages"

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim arrOldProcedures As New ArrayList

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            arrOldProcedures.Add(objReader(0).ToString & "|" & objReader(1).ToString)
        End While
        objReader.Close()

        objCommand = New Data.OleDb.OleDbCommand(strSelect, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strBuffer() As String = Split(objReader(0).ToString, "\")
                Dim strFoundKey As String = Nothing
                Dim strProcedure As String = Nothing
                Dim strAction As String = Nothing
                Dim strNewKey As String = Nothing
                Dim boolFound As Boolean = False

                If strBuffer.Length >= 2 Then
                    If strBuffer.Length = 2 Then
                        objCommand = New Data.OleDb.OleDbCommand("UPDATE LegalActions SET " _
                                & "ProcessAction = '" & objReader(1).ToString & "' " _
                                & "WHERE ProcedureName = '" & strBuffer(0) & "' AND ActionTaken = '" & strBuffer(1) & "'", cnn)
                        objCommand.ExecuteNonQuery()
                    Else
                        strProcedure = strBuffer(0)
                        boolFound = False

                        For q As Integer = 0 To arrOldProcedures.Count - 1
                            Dim strSplitOld() As String = Split(arrOldProcedures.Item(q), "|")
                            If UCase(strSplitOld(0)) = UCase(strProcedure) Then
                                If UCase(strBuffer(strBuffer.Length - 1)) = UCase(strSplitOld(1)) Then
                                    boolFound = True
                                    strAction = strSplitOld(1)
                                    Exit For
                                End If
                            End If
                        Next

                        objCommand = New Data.OleDb.OleDbCommand("UPDATE LegalActions SET " _
                                & "ProcessAction = '" & objReader(1).ToString & "' " _
                                & "WHERE ProcedureName = '" & strProcedure & "' AND ActionTaken = '" & strAction & "'", cnn)
                        objCommand.ExecuteNonQuery()

                    End If
                End If

            End If
        End While
        MsgBox("Done")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Legal Actions Stage Conversion"
        ShowErrorMessage()
    End Sub
End Class
