Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDateBranchFilter
    Private Sub frmDateBranchFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBranches()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(cboLocation.Text) Then
            MessageBox.Show("Please select one option from the branch options", "Missing Branch Filter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboLocation.Focus()
            Exit Sub
        End If
        StartDate = Format(dpStartDate.Value, "dd-MMM-yyyy")
        EndDate = Format(dpEndDate.Value, "dd-MMM-yyyy")
        strPrintBranchFilter = cboLocation.Text
        Me.Close()
    End Sub

    Private Sub LoadBranches()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT BranchName FROM Branches ORDER BY BranchName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboLocation.Items.Add("ALL")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(strUserBranch) <> UCase(objReader(0).ToString) Then
                    cboLocation.Items.Add(UCase(objReader(0).ToString))
                End If
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Branch Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class