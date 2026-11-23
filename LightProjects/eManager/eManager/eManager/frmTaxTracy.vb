Public Class frmTaxTracy

    Private Sub txtNetAmount_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNetAmount.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            If IsNumeric(txtNetAmount.Text) Then
                ProcessRequest(CDbl(txtNetAmount.Text))
            Else
                MessageBox.Show("The amount entered is not valid", "Invalid Amount Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub ProcessRequest(NetPay As Double)
        Dim dblGrossAmount As Double = GrossAmount(NetPay)
        With dGrid.Rows
            .Clear()
            .Add("Computed Gross", Format(dblGrossAmount, "#,##0.00"))
            .Add("Tax Band Minima", Format(TaxBandMinima, "#,##0.00"))
            .Add("Tax Band Maxima", Format(TaxBandMaxima, "#,##0.00"))
            .Add("Tax Rate Applied", Format(TaxBandRate, "#,##0.00"))
            .Add("Tax Band Credit", Format(TaxBandBaseDeduction, "#,##0.00"))
            .Add("Tax Computation", "")
            Dim dblGrossPaye As Double = dblGrossAmount * TaxBandRate
            .Add("GROSS PAYE [" & Format(dblGrossAmount, "#,##0.00") & " * " & Format(TaxBandRate, "0.00") & "]", Format(dblGrossPaye, "#,##0.00"))
            .Add("LESS CREDIT", "(" & Format(TaxBandBaseDeduction, "#,##0.00") & ")")
            Dim dblNetPaye As Double = dblGrossPaye - TaxBandBaseDeduction
            .Add("NET PAYE", Format(dblNetPaye, "#,##0.00"))
            Dim dblAidsLevy As Double = dblNetPaye * 0.03
            .Add("AIDS LEVY [3% of NET PAYE]", Format(dblAidsLevy, "#,##0.00"))
            .Add("TOTAL TAXES", "(" & Format((dblAidsLevy + dblNetPaye), "#,##0.00") & ")")
            Dim dblNet As Double = dblGrossAmount - (dblNetPaye + dblAidsLevy)
            .Add("NET AFTER TAXES", Format(dblNet, "#,##0.00"))
        End With
    End Sub

    Private Sub btnCalculate_Click(sender As System.Object, e As System.EventArgs) Handles btnCalculate.Click
        If IsNumeric(txtNetAmount.Text) Then
            ProcessRequest(CDbl(txtNetAmount.Text))
        Else
            MessageBox.Show("The amount entered is not valid", "Invalid Amount Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
