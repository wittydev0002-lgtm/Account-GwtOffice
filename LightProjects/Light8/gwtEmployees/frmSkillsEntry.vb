Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmSkillsEntry

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub txtExperience_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtExperience.KeyPress
        If Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtDescripton.Text) Then
            MessageBox.Show("Please enter the skills description", "Invalid Skill Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescripton.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtExperience.Text) Then
            MessageBox.Show("Please enter the experience entry", "Invalid Experience", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtExperience.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboWeighting.Text) Then
            MessageBox.Show("Please enter the skill weighting", "Invalid skill Weighting", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboWeighting.Focus()
            Exit Sub
        End If
        Dim strSql As String = Nothing
        If boolEditStatusTwo = False Then
            strSql = "INSERT INTO JobSkills (JobCode, Description, MinimumYears, Weighting) VALUES " _
                & "('" & strJobCode & "', '" & txtDescripton.Text & "', " & txtExperience.Text & ", '" & cboWeighting.Text & "')"
        Else
            strSql = "UPDATE JobSkills  SET Description =  '" & txtDescripton.Text & "', " _
                & "MinimumYears = " & txtExperience.Text & ", Weighting = '" & cboWeighting.Text & "' WHERE " _
                & "JobCode = '" & strJobCode & "' AND TransactionId = " & intSelectedTransaction & ""
        End If
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        sqlCommand.ExecuteNonQuery()
        If boolEditStatusTwo = True Then
            MessageBox.Show("Skill updated successfully", "Transaction Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            If MessageBox.Show("Skill updated successfully. Do you want to add more skills?", _
                    "Transaction Update Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                txtDescripton.Clear()
                txtExperience.Text = "0"
                cboWeighting.Text = "Optional"
            Else
                Me.Close()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number
         gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadDetails()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM JobSkills " _
            & "WHERE TransactionId = " & intSelectedTransaction & " AND JobCode = '" & strJobCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("Description").ToString) Then txtDescripton.Text = objReader("Description").ToString
            If Not IsDBNull(objReader("MinimumYears").ToString) Then txtExperience.Text = objReader("MinimumYears").ToString
            If Not IsDBNull(objReader("Weighting").ToString) Then cboWeighting.Text = objReader("Weighting").ToString
            If Not IsDBNull(objReader("TransactionId").ToString) Then lblId.Text = objReader("TransactionId").ToString
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmSkillsEntry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If boolEditStatusTwo = True Then LoadDetails()
    End Sub

End Class
