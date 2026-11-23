Public Class Node
    Public _Value2 As String = ""
    Public Property Value2() As String
        Get
            Return _Value2
        End Get
        Set(value As String)
            _Value2 = value
        End Set
    End Property

    Public _Count1 As String
    Public Property Count1() As String
        Get
            Return _Count1
        End Get
        Set(value As String)
            _Count1 = value
        End Set
    End Property


    Public _Value1 As String
    Public Property Value1() As String
        Get
            Return _Value1
        End Get
        Set(value As String)
            _Value1 = value
        End Set
    End Property

    Public _ActionName As String = ""
    Public Property ActionName() As String
        Get
            Return _ActionName
        End Get
        Set(value As String)
            _ActionName = value
        End Set
    End Property

    Public _Count2 As String = ""
    Public Property Count2() As String
        Get
            Return _Count2
        End Get
        Set(value As String)
            _Count2 = value
        End Set
    End Property

    Public _Children As List(Of Node) = Nothing
    Public Property Children() As List(Of Node)
        Get
            Return _Children
        End Get
        Set(value As List(Of Node))
            _Children = value
        End Set
    End Property

    Public Sub New(ActionName As String, Account As String)
        Me.ActionName = ActionName
        'this.CID = CID;
        Me.Count1 = Account
        'Me.Value1 = Value1
        'Me.Count2 = Count2
        'Me.Value2 = Value2
        Me.Children = New List(Of Node)()
    End Sub

End Class
