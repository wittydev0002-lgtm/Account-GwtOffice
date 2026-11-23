Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmAdvancedLedgerAccountChanges
    
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr

        ProgressBar1.Value = 0 : ProgressBar1.Maximum = dGrid.Rows.Count + 3
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        Cursor = Cursors.WaitCursor

        For i As Integer = 0 To dGrid.Rows.Count - 1

            Dim strNewAccount As String = Nothing
            Dim strOldAccount As String = Nothing

            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "") Then

                strNewAccount = dGrid.Rows(i).Cells(2).Value.ToString
                strOldAccount = dGrid.Rows(i).Cells(0).Value.ToString

                If Not String.IsNullOrEmpty(strNewAccount) And Not String.IsNullOrEmpty(strOldAccount) Then
                    'Check that the code does not exist before changing
                    objCommand = New Data.OleDb.OleDbCommand("SELECT AccountNumber FROM LedgerAccounts WHERE AccountNumber = '" & strNewAccount & "'", cnn)
                    Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        MessageBox.Show("The new account number already exists. This process will be aborted", _
                            "Duplicate Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        objReader.Close()
                        Exit Sub
                    Else
                        objReader.Close()
                    End If

                    strSql = "UPDATE LedgerAccounts SET AccountNumber = '" & strNewAccount & "' WHERE AccountNumber = '" & strOldAccount & "'"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                    strSql = "UPDATE CashbookTransactions SET ContraAccount = '" & strNewAccount & "' WHERE ContraAccount = '" & strOldAccount & "'"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                    strSql = "UPDATE JournalEntries SET DebitAccount = '" & strNewAccount & "' WHERE DebitAccount = '" & strOldAccount & "'"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                    strSql = "UPDATE JournalEntries SET CreditAccount = '" & strNewAccount & "' WHERE CreditAccount = '" & strOldAccount & "'"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                    strSql = "UPDATE LedgerTransactions SET ContraAccount = '" & strNewAccount & "' WHERE ContraAccount = '" & strOldAccount & "'"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                    strSql = "UPDATE LedgerTransactions SET AccountNumber = '" & strNewAccount & "' WHERE AccountNumber = '" & strOldAccount & "'"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                End If
            End If
            ProgressBar1.Value = ProgressBar1.Value + 1
        Next

        ProgressBar1.Value = ProgressBar1.Maximum
        Cursor = Cursors.Default
        MessageBox.Show("Ledger code successfully changed in the entire system", "Ledger Code Change Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Details Change"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AccountNumber, AccountName FROM LedgerAccounts ORDER BY AccountNumber"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), "")
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Details Change"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmAdvancedLedgerAccountChanges_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

End Class