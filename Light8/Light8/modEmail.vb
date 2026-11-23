Imports Microsoft.Office.Interop

Module modEmail

    Public Sub SendEmail(ByVal EmailAddress As String, Optional ByVal AttachmentPath As String = Nothing, _
        Optional ByVal EmailSubject As String = Nothing, Optional ByVal EmailBody As String = Nothing, _
        Optional ByVal CoptTo As String = Nothing, Optional ByVal FileDisplayName As String = Nothing)

        ' Create an Outlook application.
        Dim oApp As Outlook._Application
        oApp = New Outlook.Application()

        ' Create a new MailItem.
        Dim oMsg As Microsoft.Office.Interop.Outlook._MailItem
        oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
        oMsg.Subject = EmailSubject
        oMsg.Body = EmailBody & vbCr & vbCr

        ' TODO: Replace with a valid e-mail address.
        oMsg.To = EmailAddress

        ' Add an attachment

        Dim sSource As String = Nothing
        If Not String.IsNullOrEmpty(AttachmentPath) Then
            sSource = AttachmentPath
        End If

        Dim sDisplayName As String = FileDisplayName

        Dim sBodyLen As String = oMsg.Body.Length
        Dim oAttachs As Outlook.Attachments = oMsg.Attachments
        Dim oAttach As Outlook.Attachment

        'Add attachments only if available
        If Not String.IsNullOrEmpty(AttachmentPath) Then
            oAttach = oAttachs.Add(sSource, , sBodyLen + 1, sDisplayName)
        End If

        ' Send
        oMsg.Send()

        ' Clean up
        oApp = Nothing
        oMsg = Nothing
        oAttach = Nothing
        oAttachs = Nothing

    End Sub
End Module
