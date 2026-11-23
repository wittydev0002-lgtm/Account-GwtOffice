Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmAttachDocument

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtFilename.Text) Then
            MessageBox.Show("Please enter the file name", "Missing File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFilename.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDocumentName.Text) Then
            MessageBox.Show("Please enter the document name", "Missing Document Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumentName.Select()
            Exit Sub
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO BM_AttachedDocuments " _
            & "(DocumentName, FileName, PolicyNumber) VALUES " _
            & "('" & txtDocumentName.Text & "', '" & txtFilename.Text & "', '" & strSelectedAccount & "')", cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Documents have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Documents Attachment"
        ShowErrorMessage()
    End Sub

    Private Sub ButtonSpecAny1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonSpecAny1.Click
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        txtFilename.Text = ofd.FileName
    End Sub

    Private Sub ButtonSpecAny2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonSpecAny2.Click
        txtFilename.Clear()
    End Sub

End Class
