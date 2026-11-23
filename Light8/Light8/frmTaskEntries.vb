Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmTaskEntries

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter the task description", "Missing Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboType.Text) Then
            MessageBox.Show("Please enter the task decision type", "Missing Decision Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboType.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboFrequency.Text) Then
            MessageBox.Show("Please enter the task decision frequency", "Missing Decision Frequency", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboFrequency.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboConsequency.Text) Then
            MessageBox.Show("Please enter the task decision consequency", "Missing Decision Consequency", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboConsequency.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboSupervision.Text) Then
            MessageBox.Show("Please enter the task supervision level", "Missing Supervision Level", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSupervision.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboDeadLines.Text) Then
            MessageBox.Show("Please enter the task dead line", "Missing Task Deadline", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboDeadLines.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboCommunication.Text) Then
            MessageBox.Show("Please enter the task communication links", "Missing Communication Links", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCommunication.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboResources.Text) Then
            MessageBox.Show("Please enter the task resources source", "Missing Resources Source", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboResources.Focus()
            Exit Sub
        End If

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = Nothing
        Dim objReader As Data.OleDb.OleDbDataReader
        If boolEditStatusTwo = False Then
            strSql = "INSERT INTO JobKeyTasks (Description, JobCode, DecisionMaking, Frequency, " _
                & "Consequencies, Supervision, InputSources, DeadLines, Relations) VALUES " _
                & "('" & txtDescription.Text & "', '" & strJobCode & "', '" & cboType.Text & "', " _
                & "'" & cboFrequency.Text & "', '" & cboConsequency.Text & "', '" & cboSupervision.Text & "', " _
                & "'" & cboResources.Text & "', '" & cboDeadLines.Text & "', '" & cboCommunication.Text & "')"
        Else
            strSql = "UPDATE JobKeyTasks SET Description = '" & txtDescription.Text & "', " _
                & "DecisionMaking = '" & cboType.Text & "', Frequency = '" & cboFrequency.Text & "', " _
                & "Consequencies = '" & cboConsequency.Text & "', Supervision = '" & cboSupervision.Text & "', " _
                & "InputSources = '" & cboResources.Text & "', DeadLines = '" & cboDeadLines.Text & "', " _
                & "Relations = '" & cboCommunication.Text & "' WHERE JobCode = '" & strJobCode & "' " _
                & "AND TransactionId = " & intSelectedTransaction & ""
        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        If boolEditStatusTwo = False Then
            If MessageBox.Show("Task saved successfully. Do you want to add another task?", "Job Task Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                txtDescription.Clear()
                txtDescription.Focus()
                Exit Sub
            End If
        End If
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Job Tasks Update"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        If boolEditStatusTwo = True Then
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM JobKeyTasks WHERE TransactionId = " & intSelectedTransaction & " AND JobCode = '" & strJobCode & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader("DecisionMaking").ToString) Then
                    cboType.SelectedText = objReader("DecisionMaking").ToString
                End If
                If Not IsDBNull(objReader("Frequency").ToString) Then
                    cboFrequency.SelectedText = objReader("Frequency").ToString
                End If
                If Not IsDBNull(objReader("Consequencies").ToString) Then
                    cboConsequency.SelectedText = objReader("Consequencies").ToString
                End If
                If Not IsDBNull(objReader("Supervision").ToString) Then
                    cboSupervision.SelectedText = objReader("Supervision").ToString
                End If
                If Not IsDBNull(objReader("InputSources").ToString) Then
                    cboResources.SelectedText = objReader("InputSources").ToString
                End If
                If Not IsDBNull(objReader("DeadLines").ToString) Then
                    cboDeadLines.SelectedText = objReader("DeadLines").ToString
                End If
                If Not IsDBNull(objReader("Relations").ToString) Then
                    cboCommunication.SelectedText = objReader("Relations").ToString
                End If
                txtDescription.Text = strSelectedValue
            End If
            objReader.Close()
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Job Tasks Load"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub frmTaskEntries_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub frmTaskEntries_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 589 : Me.Height = 404
    End Sub

End Class
