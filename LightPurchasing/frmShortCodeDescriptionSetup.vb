Imports CommonLibrary.Commons
Imports System.Windows.Forms

Public Class frmShortCodeDescriptionSetup

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmShortCodeDescriptionSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.TextExtra = strselectedShortCode
        If boolCalledFromListing = True Then
            If boolEditStatus = True Then
                txtShortCode.Text = strselectedShortCode
                txtShortCode.Enabled = False
            Else
                txtShortCode.Enabled = True
            End If
        Else
            txtShortCode.Enabled = False
            txtShortCode.Text = strselectedShortCode
        End If
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtShortCode.Text) Then
            MessageBox.Show("Please enter the short code", "Invalid Short Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtShortCode.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter the description", "Invalid Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        End If
        Dim strSql As String = Nothing
        If boolEditStatus = False Then
            strSql = "INSERT INTO InventoryShortCodeDescriptions (ShortCode, Description) VALUES ('" & txtShortCode.Text & "', '" & txtDescription.Text & "')"
        Else
            strSql = "UPDATE InventoryShortCodeDescriptions SET Description = '" & txtDescription.Text & "' WHERE ShortCode = '" & txtShortCode.Text & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        If MessageBox.Show("Process completed successfully. Do you want to add more?", "Process Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            txtShortCode.Clear()
            txtDescription.Clear()
            txtShortCode.Focus()
        Else
            Me.Close()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On short code descriptions setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtShortCode_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtShortCode.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtDescription.Focus()
        End If
    End Sub

    Private Sub txtDescription_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescription.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnOK.Focus()
        End If
    End Sub

    Private Sub txtShortCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShortCode.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If e.KeyChar = " " Then
            If strCompanyAllowsSpacesOnItemCodes = "NO" Then
                e.KeyChar = "-"
            End If
        End If
    End Sub

End Class
