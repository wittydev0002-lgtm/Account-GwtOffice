Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmPayMethodChange

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If CDbl(lblTotalPaid.Text) <> CDbl(txtBillTotal.Text) Then
            MessageBox.Show("The amount total differs from the receipt total", "Values Not Accepted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTenderExchangeCash.Focus()
            Exit Sub
        Else
            If IsNumeric(txtTenderExchangeCash.Text) Then dblAmountTenderedCash = CDbl(txtTenderExchangeCash.Text)
            If IsNumeric(txtTenderExchangeEcocash.Text) Then dblAmountTenderedEcoCash = CDbl(txtTenderExchangeEcocash.Text)
            If IsNumeric(txtTenderExchangeSwipe.Text) Then dblAmountTenderedSwipe = CDbl(txtTenderExchangeSwipe.Text)
            If IsNumeric(txtTenderExchangeTransfer.Text) Then dblAmountTenderedTransfer = CDbl(txtTenderExchangeTransfer.Text)
            If IsNumeric(txtTenderExchangeOther.Text) Then dblAmountTenderedOther = CDbl(txtTenderExchangeOther.Text)
        End If
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub frmPayMethodChange_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblTotalPaid.Text = "0.00"
        txtBillTotal.Text = Format(dblReceiptAmount, "##0.00")
        txtBillTotal.Enabled = False
    End Sub

    Private Sub txtTenderExchangeCash_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenderExchangeCash.GotFocus
        txtTenderExchangeCash.SelectAll()
    End Sub

    Private Sub txtTenderExchangeCash_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenderExchangeCash.LostFocus
        If IsNumeric(txtTenderExchangeCash.Text) Then txtTenderExchangeCash.Text = Format(CDbl(txtTenderExchangeCash.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtTenderExchangeCash_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTenderExchangeCash.Validating
        If String.IsNullOrEmpty(txtTenderExchangeCash.Text) Then Exit Sub
        If Not IsNumeric(txtTenderExchangeCash.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTenderExchangeCash.Focus()
            Exit Sub
        End If
        'Compute the values
        txtTenderExchangeCash.Text = Format(CDbl(txtTenderExchangeCash.Text), "##0.00")
        ComputeChange()
    End Sub

    '******************** Ecocash ************************************************

    Private Sub txtTenderExchangeEcocash_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenderExchangeEcocash.GotFocus
        txtTenderExchangeEcocash.SelectAll()
    End Sub

    Private Sub txtTenderExchangeEcocash_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenderExchangeEcocash.LostFocus
        If IsNumeric(txtTenderExchangeEcocash.Text) Then txtTenderExchangeEcocash.Text = Format(CDbl(txtTenderExchangeEcocash.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtTenderExchangeEcocash_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTenderExchangeEcocash.Validating
        If String.IsNullOrEmpty(txtTenderExchangeEcocash.Text) Then Exit Sub
        If Not IsNumeric(txtTenderExchangeEcocash.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTenderExchangeEcocash.Focus()
            Exit Sub
        End If
        'Compute the values
        txtTenderExchangeEcocash.Text = Format(CDbl(txtTenderExchangeEcocash.Text), "##0.00")
        ComputeChange()
    End Sub

    '******************** Swipe ************************************************

    Private Sub txtTenderExchangeSwipe_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenderExchangeSwipe.GotFocus
        txtTenderExchangeSwipe.SelectAll()
    End Sub

    Private Sub txtTenderExchangeSwipe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenderExchangeSwipe.LostFocus
        If IsNumeric(txtTenderExchangeSwipe.Text) Then txtTenderExchangeSwipe.Text = Format(CDbl(txtTenderExchangeSwipe.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtTenderExchangeSwipe_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTenderExchangeSwipe.Validating
        If String.IsNullOrEmpty(txtTenderExchangeSwipe.Text) Then Exit Sub
        If Not IsNumeric(txtTenderExchangeSwipe.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTenderExchangeSwipe.Focus()
            Exit Sub
        End If
        'Compute the values
        txtTenderExchangeSwipe.Text = Format(CDbl(txtTenderExchangeSwipe.Text), "##0.00")
        ComputeChange()
    End Sub

    '******************** Transfer ************************************************

    Private Sub txtTenderExchangeTransfer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenderExchangeTransfer.GotFocus
        txtTenderExchangeTransfer.SelectAll()
    End Sub

    Private Sub txtTenderExchangeTransfer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenderExchangeTransfer.LostFocus
        If IsNumeric(txtTenderExchangeTransfer.Text) Then txtTenderExchangeTransfer.Text = Format(CDbl(txtTenderExchangeTransfer.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtTenderExchangeTransfer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTenderExchangeTransfer.Validating
        If String.IsNullOrEmpty(txtTenderExchangeTransfer.Text) Then Exit Sub
        If Not IsNumeric(txtTenderExchangeTransfer.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTenderExchangeTransfer.Focus()
            Exit Sub
        End If
        'Compute the values
        txtTenderExchangeTransfer.Text = Format(CDbl(txtTenderExchangeTransfer.Text), "##0.00")
        ComputeChange()
    End Sub

    '******************** Other ************************************************

    Private Sub txtTenderExchangeOther_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenderExchangeOther.GotFocus
        txtTenderExchangeOther.SelectAll()
    End Sub

    Private Sub txtTenderExchangeOther_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTenderExchangeOther.LostFocus
        If IsNumeric(txtTenderExchangeOther.Text) Then txtTenderExchangeOther.Text = Format(CDbl(txtTenderExchangeOther.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub txtTenderExchangeOther_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTenderExchangeOther.Validating
        If String.IsNullOrEmpty(txtTenderExchangeOther.Text) Then Exit Sub
        If Not IsNumeric(txtTenderExchangeOther.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTenderExchangeOther.Focus()
            Exit Sub
        End If
        'Compute the values
        txtTenderExchangeOther.Text = Format(CDbl(txtTenderExchangeOther.Text), "##0.00")
        ComputeChange()
    End Sub

    Private Sub ComputeChange()
        Dim dblTotalPaid As Double = 0
        If IsNumeric(txtTenderExchangeCash.Text) Then
            If CDbl(txtTenderExchangeCash.Text) <> 0 Then
                dblTotalPaid = dblTotalPaid + CDbl(txtTenderExchangeCash.Text)
            End If
        End If
        If IsNumeric(txtTenderExchangeEcocash.Text) Then
            If CDbl(txtTenderExchangeEcocash.Text) <> 0 Then
                dblTotalPaid = dblTotalPaid + CDbl(txtTenderExchangeEcocash.Text)
            End If
        End If
        If IsNumeric(txtTenderExchangeSwipe.Text) Then
            If CDbl(txtTenderExchangeSwipe.Text) <> 0 Then
                dblTotalPaid = dblTotalPaid + CDbl(txtTenderExchangeSwipe.Text)
            End If
        End If
        If IsNumeric(txtTenderExchangeTransfer.Text) Then
            If CDbl(txtTenderExchangeTransfer.Text) <> 0 Then
                dblTotalPaid = dblTotalPaid + CDbl(txtTenderExchangeTransfer.Text)
            End If
        End If
        If IsNumeric(txtTenderExchangeOther.Text) Then
            If CDbl(txtTenderExchangeOther.Text) <> 0 Then
                dblTotalPaid = dblTotalPaid + CDbl(txtTenderExchangeOther.Text)
            End If
        End If

        lblTotalPaid.Text = Format(dblTotalPaid, "##0.00")

    End Sub

    Private Sub txtTenderExchangeCash_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTenderExchangeCash.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtTenderExchangeEcocash.Focus()
        End If
    End Sub

    Private Sub txtTenderExchangeEcocash_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTenderExchangeEcocash.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtTenderExchangeSwipe.Focus()
        End If
    End Sub

    Private Sub txtTenderExchangeSwipe_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTenderExchangeSwipe.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtTenderExchangeTransfer.Focus()
        End If
    End Sub

    Private Sub txtTenderExchangeTransfer_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTenderExchangeTransfer.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtTenderExchangeOther.Focus()
        End If
    End Sub

    Private Sub txtTenderExchangeOther_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTenderExchangeOther.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnOK.Focus()
        End If
    End Sub

End Class
