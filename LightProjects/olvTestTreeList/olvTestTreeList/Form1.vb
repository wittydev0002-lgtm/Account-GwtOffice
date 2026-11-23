
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports BrightIdeasSoftware

Public Class Form1

    '' Define the delegate function for the comparisons.
    ''Delegate Function CompareNumbers(ByVal num1 As Integer, ByVal num2 As Integer) As Boolean

    'Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    '    Me.treeListView1.CanExpandGetter = Function(x As [Object]) (TypeOf x Is ArtistExample) OrElse (TypeOf x Is AlbumExample)
    '    Me.treeListView1.ChildrenGetter = ChildGetter(treeListView1.CanExpandGetter)
    '    Me.olvColumn1.ImageGetter = ImageGet(treeListView1.CanExpandGetter)
    'End Sub

    'Function ChildGetter(x As Object)
    '    If TypeOf x Is ArtistExample Then
    '        Return DirectCast(x, ArtistExample).Albums
    '    End If
    '    If TypeOf x Is AlbumExample Then
    '        Return DirectCast(x, AlbumExample).Songs
    '    End If
    '    'Throw New ArgumentException("Should be Artist or Album")
    'End Function

    'Function ImageGet(x As Object)
    '    If TypeOf x Is ArtistExample Then
    '        Return "user"
    '    Else
    '        If TypeOf x Is AlbumExample Then
    '            Return "folder"
    '        Else
    '            Return "song"
    '        End If
    '    End If
    'End Function



    'Sub ShowInOrder(ByVal compare As CompareNumbers)
    '    If compare(_num1, _num2) Then
    '        Console.WriteLine(_num1 & "  " & _num2)
    '    Else
    '        Console.WriteLine(_num2 & "  " & _num1)
    '    End If
    'End Sub

    'Private _num1 As Integer
    'Property Num1() As Integer
    '    Get
    '        Return _num1
    '    End Get
    '    Set(ByVal value As Integer)
    '        _num1 = value
    '    End Set
    'End Property

    'Private _num2 As Integer
    'Property Num2() As Integer
    '    Get
    '        Return _num2
    '    End Get
    '    Set(ByVal value As Integer)
    '        _num2 = value
    '    End Set
    'End Property

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.treeListView1.CanExpandGetter = Function(x As Object) DirectCast(x, Song).Artist.Count > 0
        Me.treeListView1.ChildrenGetter = Function(x As Object) DirectCast(x, Song).Album

    End Sub
End Class

