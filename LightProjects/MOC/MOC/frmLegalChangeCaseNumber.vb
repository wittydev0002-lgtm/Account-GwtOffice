Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLegalChangeCaseNumber

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        'First check that the new number does not exist
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CaseNo FROM MocCases WHERE CaseNo = '" & txtNewAccountNo.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            MessageBox.Show("This number has already been allocated. Please enter a new one", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            objReader.Close()
            Exit Sub
        Else

            'Get the address details

            objCommand = New Data.OleDb.OleDbCommand("SELECT DefendantAddress1, DefendantAddress2, DefendantAddress3, DefendantAddress4, " _
                & "PlaintifAddress1, PlaintifAddress2, PlaintifAddress3, PlaintifAddress4 FROM MocCaseAddresses WHERE CaseNo = '" & txtOldAccountNo.Text & "'", cnn)
            Dim obReadAddresses As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader


            'Delete the address from the table first 
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM MocCaseAddresses WHERE CaseNo = '" & txtOldAccountNo.Text & "'", cnn)
            objCommand.ExecuteNonQuery()

            'Update main cases
            objCommand = New Data.OleDb.OleDbCommand("UPDATE MocCases SET CaseNo = '" & txtNewAccountNo.Text & "' " _
                & "WHERE CaseNo = '" & txtOldAccountNo.Text & "'", cnn)
            objCommand.ExecuteNonQuery()


            ''MocCaseAddresses 
            'objCommand = New Data.OleDb.OleDbCommand("UPDATE MocCaseAddresses SET CaseNo = '" & txtNewAccountNo.Text & "' " _
            '    & "WHERE CaseNo = '" & txtOldAccountNo.Text & "'", cnn)
            'objCommand.ExecuteNonQuery()

            'INSERT THE ADDRESSES ANEW

            If obReadAddresses.HasRows Then
                obReadAddresses.Read()
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO MocCaseAddresses (DefendantAddress1, DefendantAddress2, DefendantAddress3, DefendantAddress4, " _
                & "PlaintifAddress1, PlaintifAddress2, PlaintifAddress3, PlaintifAddress4, CaseNo) VALUES ('" & obReadAddresses(0).ToString & "', " _
                & "'" & obReadAddresses(1).ToString & "', '" & obReadAddresses(2).ToString & "', '" & obReadAddresses(3).ToString & "', " _
                & "'" & obReadAddresses(4).ToString & "', '" & obReadAddresses(5).ToString & "', '" & obReadAddresses(6).ToString & "', " _
                & "'" & obReadAddresses(7).ToString & "', '" & txtNewAccountNo.Text & "')", cnn)
                objCommand.ExecuteNonQuery()
            End If
            obReadAddresses.Close()

            'MocAttachmentMains
            objCommand = New Data.OleDb.OleDbCommand("UPDATE MocAttachmentMains SET CaseNo = '" & txtNewAccountNo.Text & "' " _
                & "WHERE CaseNo = '" & txtOldAccountNo.Text & "'", cnn)
            objCommand.ExecuteNonQuery()

            'MocAttachmentDetails
            objCommand = New Data.OleDb.OleDbCommand("UPDATE MocAttachmentDetails SET CaseNo = '" & txtNewAccountNo.Text & "' " _
                & "WHERE CaseNo = '" & txtOldAccountNo.Text & "'", cnn)
            objCommand.ExecuteNonQuery()

            'MocPlaintifTransactions
            objCommand = New Data.OleDb.OleDbCommand("UPDATE MocPlaintifTransactions SET CaseNo = '" & txtNewAccountNo.Text & "' " _
                & "WHERE CaseNo = '" & txtOldAccountNo.Text & "'", cnn)
            objCommand.ExecuteNonQuery()

        End If
        objReader.Close()
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On case number change"
        ShowErrorMessage()
    End Sub

    Private Sub frmLegalChangeCaseNumber_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtOldAccountNo.Text = strSelectedAccount
        txtOldAccountNo.Enabled = False
    End Sub

End Class
