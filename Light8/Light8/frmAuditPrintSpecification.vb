Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmAuditPrintSpecification

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub cboPrintOptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrintOptions.SelectedIndexChanged
        If UCase(cboPrintOptions.Text) = "ALL" Then
            dpFrom.Enabled = False : dpTo.Enabled = False
        Else
            dpFrom.Enabled = True : dpTo.Enabled = True
        End If
    End Sub

    Private Sub frmAuditPrintSpecification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboPrintOptions.SelectedText = "All"
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not String.IsNullOrEmpty(cboPrintOptions.Text) Then
            strSelectedValue = cboPrintOptions.Text
            strReportStartDate = dpFrom.Text
            strReportEndDate = dpTo.Text
            boolAbort = False
            Me.Close()
        Else
            MessageBox.Show("Please select the print options from the list provided", "Invalid Print Options", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPrintOptions.Focus()
            Exit Sub
        End If
    End Sub

End Class