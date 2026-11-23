Public Class clTreeUtil
    ''' <summary>
    ''' This static utiltiy method flattens all the nodes in a tree view using
    ''' a queue based breath first search rather than the overhead
    ''' of recursive method calls.
    ''' </summary>
    ''' <param name="tree"></param>
    ''' <returns></returns>

    Public Shared Function FlattenBreath(Tree As TreeView) As List(Of TreeNode)
        Dim nodes As List(Of TreeNode) = New List(Of TreeNode)
        Dim queue As Queue(Of TreeNode) = New Queue(Of TreeNode)

        ''
        '' Bang all the top nodes into the queue.
        ''
        For Each top As TreeNode In Tree.Nodes
            queue.Enqueue(top)
        Next

        While (queue.Count > 0)
            Dim node As TreeNode = queue.Dequeue()
            If node IsNot Nothing Then
                ''
                '' Add the node to the list of nodes.
                ''
                nodes.Add(node)

                If node.Nodes IsNot Nothing And node.Nodes.Count > 0 Then
                    ''
                    '' Enqueue the child nodes.
                    ''
                    For Each child As TreeNode In node.Nodes
                        queue.Enqueue(child)
                    Next
                End If
            End If
        End While

        Return nodes
    End Function

    ''' <summary>
    ''' This static utiltiy method flattens all the nodes in a tree view using
    ''' a stack based depth first search rather than the overhead
    ''' of recursive method calls.
    ''' </summary>
    ''' <param name="tree"></param>
    ''' <returns></returns>

    Public Shared Function FlattenDepth(tree As TreeView) As List(Of TreeNode)
        Dim nodes As List(Of TreeNode) = New List(Of TreeNode)

        Dim stack As Stack(Of TreeNode) = New Stack(Of TreeNode)

        ''
        '' Bang all the top nodes into the queue.
        ''
        For Each top As TreeNode In tree.Nodes
            stack.Push(top)
        Next

        While (stack.Count > 0)
            Dim node As TreeNode = stack.Pop()

            If node IsNot Nothing Then

                ''
                '' Add the node to the list of nodes.
                ''
                nodes.Add(node)

                If node.Nodes IsNot Nothing And node.Nodes.Count > 0 Then
                    ''
                    '' Enqueue the child nodes.
                    ''
                    For Each child As TreeNode In node.Nodes
                        stack.Push(child)
                    Next
                End If
            End If

        End While

        Return nodes
    End Function
End Class
