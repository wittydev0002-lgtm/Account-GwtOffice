Imports System.ComponentModel
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmTenderPayment

    Dim dblCurrentTotalAmount As Double

    Private Sub frmTenderPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtCash.Select()
        txtCash.SelectAll()

        Label6.BackColor = Color.Firebrick
        lblBillTotal.BackColor = Color.Firebrick
        Label8.BackColor = Color.Firebrick
        lblTotalPaid.BackColor = Color.Firebrick
        Label9.BackColor = Color.DarkGreen
        lblChange.BackColor = Color.DarkGreen
        Label1.BackColor = Color.Teal
        Label2.BackColor = Color.Teal
        Label3.BackColor = Color.Teal
        Label4.BackColor = Color.Teal
        Label5.BackColor = Color.Teal

        Label6.ForeColor = Color.White
        lblBillTotal.ForeColor = Color.White
        Label8.ForeColor = Color.White
        lblTotalPaid.ForeColor = Color.White
        Label9.ForeColor = Color.White
        lblChange.ForeColor = Color.White
        Label1.ForeColor = Color.White
        Label2.ForeColor = Color.White
        Label3.ForeColor = Color.White
        Label4.ForeColor = Color.White
        Label5.ForeColor = Color.White

        lblBillTotal.Text = Format(dblBilledAmount, "##0.00")
        dblCurrentTotalAmount = 0

    End Sub

    Private Sub txtCash_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCash.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtEcocash.Select()
            txtEcocash.SelectAll()
        End If
    End Sub

    Private Sub txtEcocash_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEcocash.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtSwipe.Select()
            txtSwipe.SelectAll()
        End If
    End Sub

    Private Sub txtSwipe_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSwipe.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtTransfer.Select()
            txtTransfer.SelectAll()
        End If
    End Sub

    Private Sub txtTransfer_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransfer.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtOthers.Select()
            txtOthers.SelectAll()
        End If
    End Sub

    Private Sub txtOthers_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOthers.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnOk.Select()
            btnOk.Focus()
        End If
    End Sub

    Private Sub txtOthers_Validating(sender As Object, e As CancelEventArgs) Handles txtOthers.Validating
        If IsNumeric(txtOthers.Text) Then
            txtOthers.Text = Format(CDbl(txtOthers.Text), "##0.00")
            UpdateTotalPaid
        End If
    End Sub

    Private Sub txtTransfer_Validating(sender As Object, e As CancelEventArgs) Handles txtTransfer.Validating
        If IsNumeric(txtTransfer.Text) Then
            txtTransfer.Text = Format(CDbl(txtTransfer.Text), "##0.00")
            UpdateTotalPaid()
        End If
    End Sub

    Private Sub txtSwipe_Validating(sender As Object, e As CancelEventArgs) Handles txtSwipe.Validating
        If IsNumeric(txtSwipe.Text) Then
            txtSwipe.Text = Format(CDbl(txtSwipe.Text), "##0.00")
            UpdateTotalPaid()
        End If
    End Sub

    Private Sub txtEcocash_Validating(sender As Object, e As CancelEventArgs) Handles txtEcocash.Validating
        If IsNumeric(txtEcocash.Text) Then
            txtEcocash.Text = Format(CDbl(txtEcocash.Text), "##0.00")
            UpdateTotalPaid()
        End If
    End Sub

    Private Sub txtCash_Validating(sender As Object, e As CancelEventArgs) Handles txtCash.Validating
        If IsNumeric(txtCash.Text) Then
            txtCash.Text = Format(CDbl(txtCash.Text), "##0.00")
            UpdateTotalPaid()
        End If
    End Sub

    Private Sub UpdateTotalPaid()
        dblCurrentTotalAmount = CDbl(txtCash.Text) + CDbl(txtEcocash.Text) +
            CDbl(txtSwipe.Text) + CDbl(txtTransfer.Text) + CDbl(txtOthers.Text)
        lblTotalPaid.Text = Format(dblCurrentTotalAmount, "##0.00")
        lblChange.Text = Format((dblBilledAmount - dblCurrentTotalAmount), "##0.00")
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If CDbl(lblChange.Text) < 0 Then
            MessageBox.Show("The amount entered is less that the expected amount", "Insufficient Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCash.Select()
            Exit Sub
        End If

        If Not IsNumeric(txtCash.Text) Then dblCash = 0 Else dblCash = CDbl(txtCash.Text)
        If Not IsNumeric(txtEcocash.Text) Then dblEcocash = 0 Else dblEcocash = CDbl(txtEcocash.Text)
        If Not IsNumeric(txtSwipe.Text) Then dblSwipe = 0 Else dblSwipe = CDbl(txtSwipe.Text)
        If Not IsNumeric(txtTransfer.Text) Then dblTransfer = 0 Else dblTransfer = CDbl(txtTransfer.Text)
        If Not IsNumeric(txtOthers.Text) Then dblOtherPaymentMethods = 0 Else dblOtherPaymentMethods = CDbl(txtOthers.Text)
        boolAbort = False
        Me.Close()
    End Sub

End Class