
Public Class frmPrintOutputOptions

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        boolOutputToExcel = False
        strFileName = Nothing
        boolToExcelOnly = False
        If optExcel.Checked = True Or optBoth.Checked = True Then
            'sfd.ShowDialog()
            'strFileName = sfd.FileName
            'If String.IsNullOrEmpty(strFileName) Then
            '    MessageBox.Show("Please specify the output file name", "Missing File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If
            boolOutputToExcel = True
            If optExcel.Checked = True Then
                boolToExcelOnly = True
            End If
        End If
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub frmPrintOutputOptions_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 484 : Me.Height = 207
    End Sub

End Class
