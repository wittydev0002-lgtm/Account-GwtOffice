Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmRsaPrimaryRebates

    Private Sub frmRsaPrimaryRebates_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM SystemTaxRebatesRSA"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader("PrimaryRebate").ToString) Then txtPrimary.Text = Format(CDbl(objReader("PrimaryRebate").ToString), "##0.00")
            If IsNumeric(objReader("SecondaryRebate").ToString) Then txtSecondary.Text = Format(CDbl(objReader("SecondaryRebate").ToString), "##0.00")
            If IsNumeric(objReader("TertiaryRebate").ToString) Then txtTertiary.Text = Format(CDbl(objReader("TertiaryRebate").ToString), "##0.00")
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On South Africa Primary Rebates Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmRsaPrimaryRebates_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 306 : Me.Height = 242
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtPrimary.Text) Then
            MessageBox.Show("Please enter a valid amount for primary rebate", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPrimary.Select()
            Exit Sub
        End If
        If Not IsNumeric(txtSecondary.Text) Then
            MessageBox.Show("Please enter a valid amount for secondary rebate", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSecondary.Select()
            Exit Sub
        End If
        If Not IsNumeric(txtTertiary.Text) Then
            MessageBox.Show("Please enter a valid amount for tertiary rebate", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTertiary.Select()
            Exit Sub
        End If

        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = "DELETE FROM SystemTaxRebatesRSA"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "INSERT INTO SystemTaxRebatesRSA (PrimaryRebate, SecondaryRebate, TertiaryRebate) VALUES " _
            & "(" & txtPrimary.Text & ", " & txtSecondary.Text & ", " & txtTertiary.Text & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default

        MessageBox.Show("Rebates have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On South Africa Primary Rebates Save"
        ShowErrorMessage()
    End Sub

    Private Sub txtPrimary_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPrimary.KeyDown
        If e.KeyData = Keys.Enter Then
            txtSecondary.Select()
        End If
    End Sub

    Private Sub txtSecondary_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSecondary.KeyDown
        If e.KeyData = Keys.Enter Then
            txtTertiary.Select()
        End If
    End Sub

    Private Sub txtTertiary_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTertiary.KeyDown
        If e.KeyData = Keys.Enter Then
            btnOK.Select()
        End If
    End Sub

End Class