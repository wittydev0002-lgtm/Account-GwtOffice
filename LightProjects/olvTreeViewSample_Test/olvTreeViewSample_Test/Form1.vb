Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Class Form1

    Private data As List(Of Node)

    Dim strNodePath As String = Nothing

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InitializeData()
        FillTree()
    End Sub

    Private Sub InitializeData()
       
        Data = New List(Of Node)()
        TreeListView1.Columns.Clear()
        'My code cracking
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [ActionName], [ProcedureId] " _
            & "FROM ProdedureAndActions WHERE ParentStatus = 'YES' AND [SubActionOf] = 0", conn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            strNodePath = Nothing
            Dim parent1 As New Node(objReader(0).ToString(), "", "", "", "")
            AddNodes(parent1, objReader(1).ToString)
            data.Add(parent1)
        End While
        objReader.Close()
        With TreeListView1
            .FullRowSelect = True
            .GridLines = True
        End With

    End Sub

    Private Sub AddNodes(ByRef sNode As Node, intActionId As Integer)
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(strNodePath) Then
            strNodePath = strNodePath & "\" & sNode.ActionName
        Else
            strNodePath = sNode.ActionName
        End If
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = " & intActionId & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, conn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim nNode As New Node(objReader(0).ToString(), "", "", "", "")
            sNode.Children.Add(nNode)
            AddNodes(nNode, objReader(1).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        MsgBox(Err.Description)
    End Sub

    Private Function ActionValues(Action As String) As Double()
        On Error GoTo RaiseErr
        Dim dblReturn(0 To 3) As Double
        For p As Integer = 0 To dblReturn.Length - 1
            dblReturn(p) = 0
        Next
        Dim strSql As String = "SELECT Count(ProcessAction) FROM LegalActions WHERE ProcessAction = '" & Action & "'"

        Return dblReturn
        Exit Function
RaiseErr:
        MsgBox(Err.Description)
        Return dblReturn
    End Function

    Private Sub FillTree()

        Me.TreeListView1.CanExpandGetter = Function(x As Object) DirectCast(x, Node).Children.Count > 0
        Me.TreeListView1.ChildrenGetter = Function(x As Object) DirectCast(x, Node).Children

        ' create the tree columns and set the delegates to print the desired object proerty
        Dim ActionNameCol As New BrightIdeasSoftware.OLVColumn("Action Taken", "ActionName")
        ActionNameCol.AspectGetter = Function(x As Object) DirectCast(x, Node).ActionName

        Dim Count1Col As New BrightIdeasSoftware.OLVColumn("Cummulative", "Count1")
        Count1Col.AspectGetter = Function(x As Object) DirectCast(x, Node).Count1

        Dim Value1Col As New BrightIdeasSoftware.OLVColumn("Amount", "Value1")
        Value1Col.AspectGetter = Function(x As Object) DirectCast(x, Node).Value1

        Dim Count2Col As New BrightIdeasSoftware.OLVColumn("Current", "Count2")
        Count2Col.AspectGetter = Function(x As Object) DirectCast(x, Node).Count2

        Dim Value2Col As New BrightIdeasSoftware.OLVColumn("Amount", "Value2")
        Value2Col.AspectGetter = Function(x As Object) DirectCast(x, Node).Value2

        ' add the columns to the tree
        Me.TreeListView1.Columns.Add(ActionNameCol)
        Me.TreeListView1.Columns.Add(Count1Col)
        Me.TreeListView1.Columns.Add(Value1Col)
        Me.TreeListView1.Columns.Add(Count2Col)
        Me.TreeListView1.Columns.Add(Value2Col)
        ' set the tree roots
        Me.TreeListView1.Roots = Data

        TreeListView1.Columns(0).Width = 250
        TreeListView1.Columns(1).Width = 100
        TreeListView1.Columns(2).Width = 100
        TreeListView1.Columns(3).Width = 100
        TreeListView1.Columns(TreeListView1.Columns.Count - 1).Width = -2

        TreeListView1.ExpandAll()

    End Sub

    Private Sub ButtonItem1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem1.Click
        Dim frm As New frmLegalActionsSetup
        frm.ShowDialog()
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        OpenDatabase()
    End Sub

End Class
