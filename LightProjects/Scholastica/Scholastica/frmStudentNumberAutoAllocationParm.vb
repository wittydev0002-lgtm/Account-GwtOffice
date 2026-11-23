Imports CommonLibrary.Commons

Public Class frmStudentNumberAutoAllocationParm

    Dim strMethod As String = "SYSTEM"

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub optSystem_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSystem.CheckedChanged
        If optSystem.Checked = True Then
            strMethod = "SYSTEM"
            grpSystemUser.Enabled = True
            cboSuffixBase.Enabled = False
            cboAutoAllocationBase.Enabled = False
            cboAutoAllocationBase.Text = "System"
            cboSuffixBase.Text = "Other"
        End If
    End Sub

    Private Sub optSystemUser_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSystemUser.CheckedChanged
        If optSystemUser.Checked = True Then
            strMethod = "SYSTEM PLUS USER"
            grpSystemUser.Enabled = True
            cboSuffixBase.Enabled = True
            cboAutoAllocationBase.Enabled = True
        End If
    End Sub

    Private Sub optUser_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optUser.CheckedChanged
        If optUser.Checked = True Then
            strMethod = "USER"
            grpSystemUser.Enabled = False
        End If
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If optSystemUser.Checked = True Then
            If String.IsNullOrEmpty(cboAutoAllocationBase.Text) Then
                MessageBox.Show("Please select the 'Atou Allocation Based On' option", "Invalid Option", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboAutoAllocationBase.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(cboAutoAllocationBase.Text) Then
                MessageBox.Show("Please select the 'Atou Allocation Based On' option", "Invalid Option", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboAutoAllocationBase.Focus()
                Exit Sub
            End If
        End If

        Dim strSql As String = "INSERT INTO SC_StudentNumberAllocationParms ([Method], " _
            & "[Prefix], [AllocationBase], [Suffix], [Seperator], [SuffixBase]) VALUES ('" & strMethod & "', " _
            & "'" & txtPrefix.Text & "', '" & cboAutoAllocationBase.Text & "', " _
            & "'" & txtSuffix.Text & "', '" & txtSeperator.Text & "', '" & cboSuffixBase.Text & "')"
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_StudentNumberAllocationParms", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        GetStudentNumberAllocationFormular()
        MessageBox.Show("Details saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Student Number Allocation Parameters Setup"
        ShowErrorMessage()
    End Sub

    Private Sub cboSuffixBase_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSuffixBase.SelectedIndexChanged
        txtSuffix.Text = Nothing
        If UCase(cboSuffixBase.Text) = UCase("Other") Then
            txtSuffix.Enabled = True
        Else
            txtSuffix.Enabled = False
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [Method], [Prefix], [AllocationBase], [Suffix], " _
            & "[Seperator], [SuffixBase] FROM SC_StudentNumberAllocationParms"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("Prefix").ToString) Then txtPrefix.Text = objReader("Prefix").ToString
            If Not IsDBNull(objReader("AllocationBase").ToString) Then cboAutoAllocationBase.Text = objReader("AllocationBase").ToString
            If Not IsDBNull(objReader("Suffix").ToString) Then txtSuffix.Text = objReader("Suffix").ToString
            If Not IsDBNull(objReader("SuffixBase").ToString) Then cboSuffixBase.Text = objReader("SuffixBase").ToString
            If Not IsDBNull(objReader("Method").ToString) Then
                Select Case UCase(objReader("Method").ToString)
                    Case Is = "USER"
                        optUser.Checked = True
                    Case Is = "SYSTEM"
                        optSystem.Checked = True
                    Case Is = "SYSTEM PLUS USER"
                        optSystemUser.Checked = True
                    Case Else
                        optSystem.Checked = True
                End Select
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Student Number Allocation Parameters Setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmStudentNumberAutoAllocationParm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

End Class