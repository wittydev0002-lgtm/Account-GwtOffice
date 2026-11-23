Imports System.Drawing.Imaging
Imports System.Drawing
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmEmailDocument

    Dim myGR As Graphics
    Dim strFileName As String = Nothing

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        On Error GoTo RaiseErr
        boolAbort = False
        Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
        If gwt_comm.IsEmailAddress(txtTo.Text) Then
            'Send the email here
            '**********************************
            Cursor = Cursors.WaitCursor
            'You can send an email with all other fields blank. Outlook will handle the rest of the staff
            SendEmail(txtTo.Text, Application.StartupPath & "\Data\DocumentImage.jpeg", _
                txtSubject.Text, txtMessage.Text, txtCopyTo.Text, strPublicDocumentType)
            Cursor = Cursors.Default
        Else
            MessageBox.Show("The email address typed in does not seem valid. Please check", "Invalid Email Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "EMAIL SEND ATTEMPT FAILED"
        boolAbort = True
        Cursor = Cursors.Default
        ShowErrorMessage()
    End Sub

    Private Function DrawText(ByVal Text As String, ByVal sFont As Font, ByVal sBrush As Brush, ByVal intX As Integer, ByVal intY As Integer) As Bitmap
        Dim TextBitmap As New Bitmap(100, 100)
        Dim Brush As New SolidBrush(Color.Blue)
        Dim SelectedFont = New Font(FontFamily.GenericSerif, 40)
        Using Graphic = Graphics.FromImage(TextBitmap)
            Graphic.DrawString(Text, sFont, sBrush, intX, intY)
        End Using
        Return TextBitmap
    End Function

    Private Sub btnAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttach.Click
        strFileName = Nothing
        ofd.ShowDialog()
        strFileName = ofd.FileName
        If String.IsNullOrEmpty(txtAttachment.Text) Then
            txtAttachment.Text = strFileName
        Else
            txtAttachment.Text = txtAttachment.Text & ";" & strFileName
        End If

    End Sub

    Private Sub frmEmailDocument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAttachment.Text = Application.StartupPath & "\Data\DocumentImage.jpeg"
        btnAttach.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
    End Sub

End Class