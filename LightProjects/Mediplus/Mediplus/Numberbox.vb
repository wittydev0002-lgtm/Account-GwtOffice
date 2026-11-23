Imports System.Globalization

Public Class Numberbox

    Inherits System.Windows.Forms.TextBox


    Private _ZeroOnLostFocus As Boolean
    Private _AllowDecimal As Boolean = True

    Private _ThousandsSeperator As Boolean = True

    Public Sub New()
        MyBase.New()
    End Sub

    Public Property ThousandsSeperator() As Boolean
        Get
            Return _ThousandsSeperator
        End Get
        Set(ByVal Value As Boolean)
            _ThousandsSeperator = Value
        End Set
    End Property

    Private ReadOnly Property GetFormat() As System.Globalization.NumberFormatInfo
        Get
            Dim MyNumberFormat As NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat
            With MyNumberFormat
                If _AllowDecimal Then
                    .NumberDecimalDigits = 2
                Else
                    .NumberDecimalDigits = 0
                End If
                If _ThousandsSeperator Then
                    .NumberGroupSeparator = ","
                    .CurrencyGroupSeparator = .NumberGroupSeparator
                    .PercentGroupSeparator = .NumberGroupSeparator
                Else
                    .NumberGroupSeparator = String.Empty
                    .CurrencyGroupSeparator = String.Empty
                    .PercentGroupSeparator = String.Empty
                End If
            End With
            Return MyNumberFormat
        End Get
    End Property

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Select Case Char.GetUnicodeCategory(e.KeyChar)
            Case Globalization.UnicodeCategory.OtherPunctuation
                If e.KeyChar = "."c AndAlso _AllowDecimal Then
                    'DON'T ALLOW IF NO NUMBERS ARE ENTERED YET
                    If Me.Text = String.Empty Then
                        e.Handled = True
                        Return
                    End If
                    'DON'T ALLOW IF . EXISTS ALREADY
                    If Me.Text.IndexOf("."c) <> -1 Then
                        e.Handled = True
                        Return
                    End If
                Else
                    e.Handled = True
                End If
            Case Globalization.UnicodeCategory.DecimalDigitNumber
                'ALWAYS ALLOW UNLESS IT WILL BE ENTERING MORE THAN SECOND DECIMAL PLACE
                Dim DecIndex As Integer = Me.Text.IndexOf("."c)
                If DecIndex <> -1 AndAlso DecIndex < Me.Text.Length - 2 Then
                    If Me.SelectionStart = Me.Text.Length Then
                        e.Handled = True
                    End If
                End If
            Case Globalization.UnicodeCategory.Control
                'ALLOW
            Case Else
                e.Handled = True
        End Select
    End Sub

    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        If Me.Text <> String.Empty Then
            If Me.Text.IndexOf("."c) = -1 And _AllowDecimal Then
                Me.Text &= ".00"
            End If
            Do Until Char.IsNumber(Me.Text.Chars(0))
                Me.Text = Me.Text.Substring(1)
            Loop
            Me.Text = Decimal.Parse(Me.Text).ToString("N", GetFormat)
        ElseIf _ZeroOnLostFocus Then
            Me.Text = 0D.ToString("N", GetFormat)
        End If

    End Sub

    Public Property ZeroOutEmptyStringOnLostFocus() As Boolean
        Get
            Return _ZeroOnLostFocus
        End Get
        Set(ByVal Value As Boolean)
            _ZeroOnLostFocus = Value
        End Set
    End Property

    Public Property AllowDecimal() As Boolean
        Get
            Return _AllowDecimal
        End Get
        Set(ByVal Value As Boolean)
            _AllowDecimal = Value
        End Set
    End Property

    Public Function ToIn32() As Integer
        Try
            If Me.Text = String.Empty Then Return 0
            Return Integer.Parse(Me.Text)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ToDouble() As Double
        Try
            If Me.Text = String.Empty Then Return 0
            Return Double.Parse(Me.Text)
        Catch ex As Exception
            Return 0.0R
        End Try
    End Function

    Public Function ToDecimal() As Decimal
        Try
            If Me.Text = String.Empty Then Return 0
            Return Decimal.Parse(Me.Text)
        Catch ex As Exception
            Return 0D
        End Try
    End Function

End Class
