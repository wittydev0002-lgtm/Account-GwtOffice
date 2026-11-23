Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDailyCurrencyEquivalence

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub AssignRates()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT RandRate, BondRate, TransaferRate, SwipeRate, EcocashRate FROM SystemKeyCurrencyRates"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblRand_Rate = CDbl(objReader(0).ToString)
            If IsNumeric(objReader(1).ToString) Then dblBond_Rate = CDbl(objReader(1).ToString)
            If IsNumeric(objReader(2).ToString) Then dblTransfer_Rate = CDbl(objReader(2).ToString)
            If IsNumeric(objReader(3).ToString) Then dblSwipe_Rate = CDbl(objReader(3).ToString)
            If IsNumeric(objReader(4).ToString) Then dblEcocash_Rate = CDbl(objReader(4).ToString)
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Key Rates Load"
        ShowErrorMessage()
    End Sub

    Private Sub RatedValues(ByVal SalesTotal As Double)
        txtRatedUsd.Text = Format(Math.Ceiling(SalesTotal * 1), "##0.00")
        txtRatedRand.Text = Format(Math.Ceiling(dblRand_Rate * SalesTotal), "##0.00")
        txtRatedBond.Text = Format(Math.Ceiling(dblBond_Rate * SalesTotal), "##0.00")
        txtRatedSwipe.Text = Format(Math.Ceiling(dblSwipe_Rate * SalesTotal), "##0.00")
        txtRatedTransfer.Text = Format(Math.Ceiling(dblTransfer_Rate * SalesTotal), "##0.00")
        txtRatedOther.Text = Format(Math.Ceiling(dblTransfer_Rate * SalesTotal), "##0.00")
        txtRatedEcocash.Text = Format(Math.Ceiling(dblEcocash_Rate * SalesTotal), "##0.00")
    End Sub

    Private Sub btnCalculate_Click(sender As System.Object, e As System.EventArgs) Handles btnCalculate.Click
        ComputeRates()
    End Sub

    Private Sub ComputeRates()
        If IsNumeric(txtAmount.Text) Then
            AssignRates()
            RatedValues(CDbl(txtAmount.Text))
        Else
            MessageBox.Show("The amount entered is invalid", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Select()
        End If
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyValue = Keys.Enter Then
            ComputeRates()
        End If
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ComputeRates()
        End If
    End Sub

    Private Sub txtAmount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAmount.Validating
        ComputeRates()
    End Sub

End Class