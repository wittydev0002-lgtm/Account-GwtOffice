Imports System.IO
Imports System.Net
Imports System.Data
Imports System.Web
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
'Imports CommonLibrary.Commons.SendHttpSms

Public Class SendHttpSms
    '0772839866 Antony Telone

    ''Dim URL As String = "http://sms1.cardboardfish.com:" & strPublicSmsPort & "/HTTPSMS?S=H&UN=" & strPublicSmsUserName & _
    ''    "&P=" & strPublicSmsPassword & "&DA=" & DestinationNumber & "&SA=" & strPublicSmsOriginator & "&M=" & _
    ''    Message & "&DR=1"
    'MessageBox.Show(URL)
    'embassy old settings: http://smsapi.bis.co.zw/api/sendsms/plain?user=xxx&password=xxxx&sender=Friend&SMSText=messagetext&GSM=38598514674

    Public Function InitializeHttpMessageSend(ByVal DestinationNumber As String, ByVal Message As String) As String

        Dim strReturn As String = Nothing
        Dim WebRequest As Net.WebRequest ' object for the web request
        Dim WebResponse As Net.WebResponse ' object for the web response

        Message = HttpUtility.UrlEncode(Message)

        Dim WebResponseString As String = ""

        'Dim URL As String = "http://smsapi.bis.co.zw/api/sendsms/plain?user=" & strPublicSmsUserName & "&password=" & strPublicSmsPassword & "&sender=" & strPublicSmsOriginator & "&SMSText=" & Message & "&GSM=" & DestinationNumber & ""

        DestinationNumber = Mid(DestinationNumber, 2, DestinationNumber.Length - 1)
        Dim URL As String = "http://cytnet.net/smsapi/?user=" & strPublicSmsUserName & "&password=" & strPublicSmsPassword & "&sender=" & strPublicSmsOriginator & "&SMSText=" & Message & "&GSM=" & DestinationNumber & ""

        WebRequest = Net.HttpWebRequest.Create(URL) 'Hit URL Link
        WebRequest.Timeout = 25000
        Try
            WebResponse = WebRequest.GetResponse
            Dim Reader As IO.StreamReader = New StreamReader(WebResponse.GetResponseStream)
            'Read response and store in variable
            WebResponseString = Reader.ReadToEnd
            WebResponse.Close()
            ''Response.write(WebResponseString) 'Display response
        Catch ex As Exception
            WebResponseString = "Request Timeout" 'If any exception occurs
            boolAbort = True
            'MessageBox.Show("Encountered error while sending sms." & ex.Message, MsgBoxStyle.Exclamation, "Error")
            Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\Autosmserr.dat", True)
            objFileWriter.WriteLine(Err.Description & " error number " & Err.Number)
            objFileWriter.Close()
        End Try
        Return strReturn
    End Function

    Public Function ConvertToUnicode(ByVal str As String) As String
        Dim ArrayOFBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(str)
        Dim unicodeString As String = ""
        For v As Integer = 0 To ArrayOFBytes.Length - 1
            If v Mod 2 = 0 Then
                Dim t As Integer = ArrayOFBytes(v)
                ArrayOFBytes(v) = ArrayOFBytes(v + 1)
                ArrayOFBytes(v + 1) = t
            End If
        Next
        For v As Integer = 0 To ArrayOFBytes.Length - 1
            Dim c As String = Hex$(ArrayOFBytes(v))
            If c.Length = 1 Then
                c = "0" & c
            End If
            unicodeString = unicodeString & c
        Next
        Return unicodeString
    End Function

End Class
