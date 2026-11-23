Imports CommonLibrary.Commons

Public Class frmLegalFileHold

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtReason.Text) Then
            MessageBox.Show("Please enter the reason for putting this case on hold", "Missing Reason", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtReason.Focus()
            Exit Sub
        End If
        Dim objCommand As Data.OleDb.OleDbCommand


        If arrSelectedItems.Count > 0 Then
            For i As Integer = 0 To arrSelectedItems.Count - 1
                Dim strBuffer() As String = Split(arrSelectedItems.Item(i), "|")
                Dim strPlaintifId As String = GetPlaintifId(strBuffer(0))
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO HeldLegalCases " _
                    & "(ClientId, DateFrom, DateTo, ClientType, FileNo, Reason, UserName) VALUES " _
                    & "('" & strPlaintifId & "', '" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "', " _
                    & "'" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "', '" & strPublicFinancialClientType & "', '" & strBuffer(1) & "', " _
                    & "'" & txtReason.Text & "', '" & strUserName & "')", cnn)
                objCommand.ExecuteNonQuery()

                'Update the file status as well
                Dim strStatusUpdateType As String = "A"

                Dim strSql As String = "UPDATE Defendants SET Status = '" & strSelectedFileStatus & "' WHERE FileId = '" & strBuffer(1) & "'"
                'UpdateFileStatus(strData(1))
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            Next
        End If

        MessageBox.Show("Case placed on hold successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On case file hold"
        ShowErrorMessage()
    End Sub

    Private Sub frmLegalFileHold_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 511 : Me.Height = 253
    End Sub

End Class