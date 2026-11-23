Public Class ComboItem
    Private _Column0 As String
    Private _Column1 As String

    Public Sub New(ByVal column0 As String, ByVal column1 As String)
        _Column0 = column0
        _Column1 = column1
    End Sub

    Public ReadOnly Property Column0() As String
        Get
            Return _Column0
        End Get
    End Property

    Public ReadOnly Property Column1() As String
        Get
            Return _Column1
        End Get
    End Property

End Class
