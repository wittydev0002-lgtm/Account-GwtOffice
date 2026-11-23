Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPayrollSummarySortOptions

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(cboOptions.Text) Then
            MessageBox.Show("Please select a valid sort option from the list given", "Invalid Option", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboOptions.Focus()
            Exit Sub
        Else
            strReportSortOption = cboOptions.Text
            boolAbort = False
            Me.Close()
        End If
    End Sub

End Class