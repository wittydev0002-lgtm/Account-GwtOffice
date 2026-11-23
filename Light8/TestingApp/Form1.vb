Imports CustomerDocumentWriter.WriteDocument

Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim prnPreview As New PrintPreviewDialog
        Dim myDoc As New CustomerDocumentWriter.WriteDocument
        myDoc.DrawBorder = True
        prnPreview.Document = myDoc

        Try
            prnPreview.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub PrintCompanyDetailsLogo(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        On Error GoTo RaiseErr



        Exit Sub
RaiseErr:

    End Sub

End Class
