Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmAccountSettlement

    Dim boolFormIsLoading As Boolean = True
    Dim dblCurrencyRate As Double = 1

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtAmountExchange.Text) Then
            MessageBox.Show("Please enter a valid amount for payment", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        Else
            dblAccountSettlementAmount = CDbl(txtAmountExchange.Text)
            boolAbort = False
            Me.Close()
        End If
    End Sub

    Private Sub txtAmount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAmount.Validating
        If String.IsNullOrEmpty(txtAmount.Text) Then Exit Sub
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a numeric value for the amont tendered", "Invalid Tender Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        Else
            'Compute the values
            txtAmountExchange.Text = Format((CDbl(txtAmount.Text) / dblCurrencyRate), "##0.00")
            dblAmountTendered = CDbl(txtAmountExchange.Text)
            If strRoundOnExchange = "YES" Then dblAmountTendered = Math.Round(dblAmountTendered, 0)
            If strRoundOnExchange = "YES" Then RoundValues()
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CurrencyName FROM Currencies ORDER BY CurrencyName", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboCurrency.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        cboCurrency.Text = UCase(strDefaultCurrency)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On currencies load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub frmAccountSettlement_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        boolFormIsLoading = True
        LoadData()
        boolFormIsLoading = False
    End Sub

    Private Sub cboCurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurrency.SelectedIndexChanged
        On Error GoTo RaiseErr
        If boolFormIsLoading = True Then Exit Sub

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CurrencyRate FROM Currencies WHERE CurrencyName = '" & cboCurrency.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblCurrencyRate = CDbl(objReader(0).ToString)
            If IsNumeric(txtAmount.Text) Then
                If CDbl(txtAmount.Text) <> 0 Then
                    txtAmountExchange.Text = Format(((CDbl(txtAmount.Text) / dblCurrencyRate)), "##0.00")
                End If
            End If
        End If
        objReader.Close()
        If strRoundOnExchange = "YES" Then RoundValues()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On exchange computation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub RoundValues()
        If IsNumeric(txtAmount.Text) Then
            txtAmount.Text = Format((Math.Round(CDbl(txtAmount.Text), 0)), "##0.00")
        End If
        If IsNumeric(txtAmountExchange.Text) Then
            txtAmountExchange.Text = Format((Math.Round(CDbl(txtAmountExchange.Text), 0)), "##0.00")
        End If
    End Sub

    Private Sub frmAccountSettlement_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 520 : Me.Height = 210
    End Sub

End Class