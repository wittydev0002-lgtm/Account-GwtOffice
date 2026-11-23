Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit

Public Class frmResetYearToDates

    Private Sub btnProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        'go through the employee code file and zero all the fields with ytd status set to yes
        On Error GoTo RaiseErr
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If dGrid.Rows(i).Cells(0).Value = True Then
                Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE EmployeeCodes SET Amount = 0 " _
                    & "WHERE CodeNo = " & CInt(dGrid.Rows(i).Cells(1).Value.ToString) & "", cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next
        MessageBox.Show("Payroll code reset to zero successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Payroll Code Value Reset"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmResetYearToDates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPayrollCodes()
    End Sub

    Private Sub LoadPayrollCodes()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CodeNo, Description FROM SystemCodes ORDER BY CodeNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(False, objReader(0), objReader(1))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Payroll Code Details Load"
        ShowErrorMessage()
    End Sub

End Class
