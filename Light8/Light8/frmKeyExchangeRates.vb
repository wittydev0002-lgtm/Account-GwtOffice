Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmKeyExchangeRates

    Private Sub frmKeyExchangeRates_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadRates()
    End Sub

    Private Sub frmKeyExchangeRates_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 314 : Me.Height = 340 '314, 265
    End Sub

    Private Sub LoadRates()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If gwt_comm.CheckColumnExistence("SystemKeyCurrencyRates", "PulaRate") = False Then
            strSql = "ALTER TABLE [SystemKeyCurrencyRates] ADD [PulaRate][FLOAT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        strSql = "SELECT RandRate, BondRate, TransaferRate, 
            SwipeRate, EcocashRate, UsdRate, PulaRate FROM SystemKeyCurrencyRates"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then txtRandRate.Text = Format(CDbl(objReader(0).ToString), "##0.0000")
            If IsNumeric(objReader(1).ToString) Then txtBondRate.Text = Format(CDbl(objReader(1).ToString), "##0.0000")
            If IsNumeric(objReader(2).ToString) Then txtTransferRate.Text = Format(CDbl(objReader(2).ToString), "##0.0000")
            If IsNumeric(objReader(3).ToString) Then txtSwipeRate.Text = Format(CDbl(objReader(3).ToString), "##0.0000")
            If IsNumeric(objReader(4).ToString) Then txtEcocashRate.Text = Format(CDbl(objReader(4).ToString), "##0.0000")
            If IsNumeric(objReader(5).ToString) Then txtUsd.Text = Format(CDbl(objReader(5).ToString), "##0.0000")
            If IsNumeric(objReader("PulaRate").ToString) Then txtPulaRate.Text = Format(CDbl(objReader("PulaRate").ToString), "##0.0000")
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Key Rates Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If Not IsNumeric(txtRandRate.Text) Or Not IsNumeric(txtRandRate.Text) Or Not IsNumeric(txtTransferRate.Text) _
            Or Not IsNumeric(txtSwipeRate.Text) Or Not IsNumeric(txtEcocashRate.Text) Or Not IsNumeric(txtUsd.Text) Then
            MessageBox.Show("One or more of the entered rates is invalid. Please check and correct", "Invalid Rates Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRandRate.Focus()
            txtRandRate.SelectAll()
            Exit Sub
        Else
            Dim strSql As String = "DELETE FROM SystemKeyCurrencyRates"
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            strSql = "INSERT INTO SystemKeyCurrencyRates (RandRate, BondRate, TransaferRate, 
                SwipeRate, EcocashRate, UsdRate, PulaRate) VALUES 
                (" & CDbl(txtRandRate.Text) & ", " & CDbl(txtBondRate.Text) & ", 
                " & CDbl(txtTransferRate.Text) & ", 
                " & CDbl(txtSwipeRate.Text) & ", " & CDbl(txtEcocashRate.Text) & ", 
                " & txtUsd.Text & ", " & txtPulaRate.Text & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Key Currency Rates Have Been Saved Successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Key Rates Save"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class