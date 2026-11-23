Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoanTypesListing

    Private Sub btnNewEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewEmployee.Click
        boolEditStatus = False
        Dim f As New frmLoanTypes
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub GetSelected()
        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        boolEditStatus = True
        GetSelected()
        Dim f As New frmLoanTypes
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [OrdinalNo], " _
            & "[LoanName], [MaximumCapital], [InterestRate], [MinimumRepaymentAmount], [MinimumRepaymentPeriod], [MaximumRepaymentPeriod] " _
            & " FROM LoanTypes ORDER BY OrdinalNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5), objReader(6))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On loan types setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmLoanTypesListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If dGrid.RowCount <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to delete this loan type", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                    If IsNumeric(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                        Dim strSql As String = "DELETE FROM LoanTypes WHERE OrdinalNo = " & CInt(dGrid.CurrentRow.Cells(0).Value.ToString) & ""
                        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                        MessageBox.Show("Loan type has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadData()
                    End If
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On loan types delete"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        'Print list 

    End Sub
End Class
