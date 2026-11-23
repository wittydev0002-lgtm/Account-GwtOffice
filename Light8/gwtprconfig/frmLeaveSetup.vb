Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmLeaveSetup

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub txtMaximum_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaximum.GotFocus
        txtMaximum.SelectAll()
    End Sub

    Private Sub txtMaximum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaximum.KeyPress
        If Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtMinimum.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtMinimum_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMinimum.GotFocus
        txtMinimum.SelectAll()
    End Sub

    Private Sub txtMinimum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMinimum.KeyPress
        If Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtCycle.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtCycle_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCycle.GotFocus
        txtCycle.SelectAll()
    End Sub

    Private Sub txtCycle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCycle.KeyPress
        If Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then txtCommutation.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtCommutation_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCommutation.GotFocus
        txtCommutation.SelectAll()
    End Sub

    Private Sub txtCommutation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCommutation.KeyPress
        If Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtDescription_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescription.GotFocus
        txtDescription.SelectAll()
    End Sub

    Private Sub txtDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress
        If Asc(e.KeyChar) = 13 Then txtMaximum.Focus()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = Nothing
        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter the leave description", "Missing Leave Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtMaximum.Text) Then txtMaximum.Text = "0"
        If Not IsNumeric(txtMinimum.Text) Then txtMinimum.Text = "0"
        If Not IsNumeric(txtCycle.Text) Then txtCycle.Text = "12"
        If Not IsNumeric(txtCommutation.Text) Then txtCommutation.Text = "0"
        If boolEditStatus = False Then
            strSql = "INSERT INTO SystemLeaveParameters (Description, MaximumDays, MinimumDays, CyclePeriod, CommutationMax) " _
                & "VALUES ('" & txtDescription.Text & "', " & txtMaximum.Text & ", " & txtMinimum.Text & ", " & txtCycle.Text & ", " & txtCommutation.Text & ")"
        Else
            strSql = "UPDATE SystemLeaveParameters SET Description = '" & txtDescription.Text & "', " _
                & "MaximumDays = " & txtMaximum.Text & ", MinimumDays = " & txtMinimum.Text & ", " _
                & "CyclePeriod = " & txtCycle.Text & ", CommutationMax = " & txtCommutation.Text & " " _
                & "WHERE TransactionId = " & intSelectedTransaction & ""
        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        If boolEditStatus = True Then
            MessageBox.Show("Leave set successfully.", "Leave Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            If MessageBox.Show("Leave set successfully. Do you want to set up more leave types?", "Leave Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                ResetControls()
                txtDescription.Focus()
            Else
                Me.Close()
            End If
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Leave Setup Save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ResetControls()
        txtDescription.Clear()
        txtMaximum.Text = "0"
        txtMinimum.Text = "0"
        txtCommutation.Text = "0"
        txtCycle.Text = "0"
    End Sub

    Private Sub frmLeaveSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        If boolEditStatus = True Then
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM SystemLeaveParameters WHERE TransactionId = " & intSelectedTransaction & "", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader("Description").ToString) Then txtDescription.Text = objReader("Description").ToString
                If IsNumeric(objReader("MaximumDays").ToString) Then txtMaximum.Text = objReader("MaximumDays").ToString
                If IsNumeric(objReader("MinimumDays").ToString) Then txtMinimum.Text = objReader("MinimumDays").ToString
                If IsNumeric(objReader("CyclePeriod").ToString) Then txtCycle.Text = objReader("CyclePeriod").ToString
                If IsNumeric(objReader("CommutationMax").ToString) Then txtCommutation.Text = objReader("CommutationMax").ToString
            End If
            objReader.Close()
        Else
            ResetControls()
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Leave Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
