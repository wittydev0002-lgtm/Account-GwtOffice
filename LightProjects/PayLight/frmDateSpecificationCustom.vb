Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDateSpecificationCustom

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        dtSetDate = dpDate.Value
        If chkPrintSelective.Checked = True Then
            If Not IsNumeric(txtStartFrom.Text) Then
                MessageBox.Show("Please enter a numeric employee number from which to start printing the payslips",
                    "Invalid Start Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtStartFrom.Focus()
                Exit Sub
            End If
        End If
        If chkPrintSelective.Checked = True Then
            If Not IsNumeric(txtEndAt.Text) Then
                txtEndAt.Text = "99999999"
            End If
        End If
        If chkPrintSelective.Checked = True Then
            intStartNumber = CLng(txtStartFrom.Text)
            intEndNumber = CLng(txtEndAt.Text)
        End If
        If chkZeroPayslips.Checked = True Then
            boolPrintZeroPayslips = True
        Else
            boolPrintZeroPayslips = False
        End If
        If chkPrintAll.Checked = True Then
            intStartNumber = 0 : intEndNumber = 9999999
        Else
            If IsNumeric(txtStartFrom.Text) Then
                intStartNumber = CInt(txtStartFrom.Text)
            Else
                intStartNumber = 0
            End If
            If IsNumeric(txtEndAt.Text) Then
                intEndNumber = CInt(txtEndAt.Text)
            Else
                intEndNumber = 9999999
            End If
        End If
        Select Case cboSortOrder.Text
            Case Is = "Paypoint/Employee Number Sequence"
                strPayslipSortOrder = "Paypoint/Employee Number Sequence"
            Case Is = "Paypoint/Clock Number Sequence"
                strPayslipSortOrder = "Paypoint/Clock Number Sequence"
            Case Is = "Paypoint/Alpha Sequence"
                strPayslipSortOrder = "Paypoint/Alpha Sequence"
            Case Is = "Paypoint/Cost Code/Employee Number"
                strPayslipSortOrder = "Paypoint/Cost Code/Employee Number"
            Case Is = "Employee Number Sequence"
                strPayslipSortOrder = "Employee Number Sequence"
            Case Else
                strPayslipSortOrder = "Employee Number Sequence"
        End Select
        Me.Hide()
        Me.Close()
    End Sub

    Private Sub chkPrintSelective_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintSelective.CheckedChanged
        If chkPrintSelective.Checked = True Then
            kLabel1.Visible = True : kLabel2.Visible = True
            txtStartFrom.Visible = True : txtEndAt.Visible = True
            boolPrintSelective = True
        Else
            kLabel1.Visible = False : kLabel2.Visible = False
            txtStartFrom.Visible = False : txtEndAt.Visible = False
            boolPrintSelective = False
        End If
    End Sub

    Private Sub txtStartFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtStartFrom.Validating
        If String.IsNullOrEmpty(txtStartFrom.Text) Then Exit Sub
        If Not IsNumeric(txtStartFrom.Text) Then
            MessageBox.Show("Please enter the first numeric employee number to be printed",
                "Invalid Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtStartFrom.Focus()
        End If
    End Sub

    Private Sub txtEndAt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEndAt.Validating
        If String.IsNullOrEmpty(txtEndAt.Text) Then Exit Sub
        If Not IsNumeric(txtEndAt.Text) Then
            MessageBox.Show("Please enter the last numeric employee number to be printed",
                "Invalid Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEndAt.Focus()
        End If
    End Sub

End Class