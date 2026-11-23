Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmGatePassPrintOptions

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub optDelivery_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optDelivery.CheckedChanged
        If optDelivery.Checked = True Then
            grpDelivery.Enabled = True
        Else
            grpDelivery.Enabled = False
        End If
    End Sub

    Private Sub optGatePass_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optGatePass.CheckedChanged
        If optGatePass.Checked = True Then
            grpDelivery.Enabled = False
        Else
            grpDelivery.Enabled = True
        End If
    End Sub

    Private Sub optBoth_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optBoth.CheckedChanged
        If optBoth.Checked = True Then
            grpDelivery.Enabled = True
        Else
            grpDelivery.Enabled = False
        End If
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If grpDelivery.Enabled = True Then
            If String.IsNullOrEmpty(txtCustomer.Text) Then
                MessageBox.Show("Please enter the customer name", "Missing Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCustomer.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtAddress1.Text) Then
                MessageBox.Show("Please enter the customer address", "Missing Customer Address", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAddress1.Focus()
                Exit Sub
            End If
        End If
        strPublicCustomerName = txtCustomer.Text
        strpublicDeliverAddress1 = txtAddress1.Text
        strpublicDeliverAddress2 = txtAddress2.Text
        strPublicDeliverAddress3 = txtAddress3.Text
        strPublicDeliverAddress4 = txtAddress4.Text
        If optBoth.Checked = True Then strGataPassPrintOptions = "BOTH"
        If optGatePass.Checked = True Then strGataPassPrintOptions = "PASS"
        If optDelivery.Checked = True Then strGataPassPrintOptions = "DELIVERY"
        boolAbort = False
        Me.Close()
    End Sub
End Class
