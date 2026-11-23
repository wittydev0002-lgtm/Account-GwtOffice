Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmBankCodeChange

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtOldBankCode.Text) Or String.IsNullOrEmpty(txtNewBankCode.Text) Then
            MessageBox.Show("Either the current bank code or the new bank code is missing. Please re-enter", _
                "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtOldBankCode.Focus()
            Exit Sub
        Else
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT BankCode FROM SystemBanks WHERE BankCode = '" & txtNewBankCode.Text & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                MessageBox.Show("The new bank code is already in existence. No change can be effected", _
                    "Duplicate Code Exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                objReader.Close()
                Exit Sub
            End If
            objReader.Close()
            objCommand = New Data.OleDb.OleDbCommand("UPDATE SystemBanks SET BankCode = '" & txtNewBankCode.Text & "' WHERE BankCode = '" & txtOldBankCode.Text & "'", cnn)
            objCommand.ExecuteNonQuery()
            'Update the employee records as well
            objCommand = New Data.OleDb.OleDbCommand("UPDATE EmployeeBanks SET BankCode = '" & txtNewBankCode.Text & "' WHERE BankCode = '" & txtOldBankCode.Text & "'", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Bank code changed successfully", "Bank Code Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On bank code mass change"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmBankCodeChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtOldBankCode.Text = lngPublicBankSortCode
    End Sub

End Class
