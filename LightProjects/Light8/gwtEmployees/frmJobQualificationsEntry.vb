Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmJobQualificationsEntry

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(cboCourseName.Text) Then
            MessageBox.Show("Please enter the qualification description", "Invalid Qualification Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCourseName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboLevels.Text) Then
            MessageBox.Show("Please enter the minimum qualification entry", "Invalid Minimum Qualification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboLevels.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboWeighting.Text) Then
            MessageBox.Show("Please enter the qualification weighting", "Invalid Qualification Weighting", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboWeighting.Focus()
            Exit Sub
        End If
        Dim strSql As String = Nothing
        If boolEditStatusTwo = False Then
            strSql = "INSERT INTO JobQualifications (JobCode, Description, MinimumLevel, Weighting) VALUES " _
                & "('" & strJobCode & "', '" & cboCourseName.Text & "', '" & cboLevels.Text & "', '" & cboWeighting.Text & "')"
        Else
            strSql = "UPDATE JobQualifications  SET Description =  '" & cboCourseName.Text & "', " _
                & "MinimumLevel = '" & cboLevels.Text & "', Weighting = '" & cboWeighting.Text & "' WHERE " _
                & "JobCode = '" & strJobCode & "' AND TransactionId = " & intSelectedTransaction & ""
        End If
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        sqlCommand.ExecuteNonQuery()
        If boolEditStatusTwo = True Then
            MessageBox.Show("Qualification updated successfully", "Transaction Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            If MessageBox.Show("Qualification updated successfully. Do you want to add more qualifications?", _
                    "Transaction Update Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                cboWeighting.Text = "Optional"
            Else
                Me.Close()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCourses()
        On Error GoTo RaiseErr
        Dim objCmd As New Data.OleDb.OleDbCommand("SELECT CourseName FROM SystemCourseDetails ORDER BY CourseName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmd.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboCourseName.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Qualifications Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadLevels()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT TrainingLevel FROM SystemTrainLevels", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboLevels.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On training levels population"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub LoadDetails()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM JobQualifications " _
            & "WHERE TransactionId = " & intSelectedTransaction & " AND JobCode = '" & strJobCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("Description").ToString) Then cboCourseName.Text = objReader("Description").ToString
            If Not IsDBNull(objReader("MinimumLevel").ToString) Then cboLevels.Text = objReader("MinimumLevel").ToString
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

    Private Sub frmQualificationsEntry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCourses()
        LoadLevels()
        If boolEditStatusTwo = True Then LoadDetails()
    End Sub

End Class
