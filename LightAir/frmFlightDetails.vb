Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmFlightDetails

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtOperator.Text) Then
            MessageBox.Show("Please enter the operator name", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtOperator.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtLocation.Text) Then
            MessageBox.Show("Please enter the location name", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLocation.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtCaptain.Text) Then
            MessageBox.Show("Please enter the captain name", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCaptain.Focus()
            Exit Sub
        End If
        strFlightDetails = txtOperator.Text & "|" & txtRegistration.Text & "|" _
            & txtLocation.Text & "|" & Format(dpArrival.Value, "dd-MMM-yyyy") & "|" _
            & Format(dpDepature.Value, "dd-MMM-yyyy") & "|" & txtCaptain.Text & "|" _
            & txtJobNumber.Text & "|" & Format(dpInvoiceDueDate.Value, "dd-MMM-yyyy") & "|" _
            & txtReference.Text

        boolAbort = False
        Me.Close()
    End Sub

End Class
