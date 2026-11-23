Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmEmployeeQualifications

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub lstAvailableSubjects_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAvailableSubjects.DoubleClick
        If lstAvailableSubjects.Items.Count > 0 Then
            strSubjectName = lstAvailableSubjects.SelectedItem.ToString
            strSubjectGrade = Nothing
            Dim f As New frmEmployeeSubjectsGrades
            f.ShowDialog()
            If Not String.IsNullOrEmpty(strSubjectGrade) Then
                'Add the item to the subjects datagrid
                With dGrid
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = strSubjectName
                    .Rows(.Rows.Count - 1).Cells(1).Value = strSubjectGrade
                End With
            End If
        End If
    End Sub

    Private Sub LoadComboBoxes()
        On Error GoTo RaiseErr
        Dim objCmd As New Data.OleDb.OleDbCommand("SELECT CourseName FROM SystemCourseDetails ORDER BY CourseName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmd.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboCourseName.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        objCmd = New Data.OleDb.OleDbCommand("SELECT TrainingLevel FROM SystemTrainLevels ORDER BY TrainingLevel", cnn)
        objReader = objCmd.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboCourseLevel.Items.Add(objReader(0).ToString)
            End If
        End While
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Qualifications Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboCourseName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCourseName.SelectedIndexChanged
        If boolFormInitializing = True Then Exit Sub
        If String.IsNullOrEmpty(cboCourseName.Text) Then
            MessageBox.Show("Please select the course before setting up individual subjects", _
                "Missing Course Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboCourseName.Focus()
            Exit Sub
        Else
            LoadFormParms()
        End If
    End Sub

    Private Sub LoadFormParms()
        On Error GoTo RaiseErr
        If optParmSet.Checked = True Then
            Dim objCmd As New Data.OleDb.OleDbCommand("SELECT CourseSubjects FROM SystemCourseDetails WHERE CourseName = '" & cboCourseName.Text & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCmd.ExecuteReader
            lstAvailableSubjects.Items.Clear()
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then
                    Dim strValues() As String = Split(objReader(0).ToString, "|")
                    For i As Integer = 0 To strValues.Length - 1
                        lstAvailableSubjects.Items.Add(strValues(i))
                    Next
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Subject Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub optGeneric_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optGeneric.CheckedChanged
        On Error GoTo RaiseErr
        If optGeneric.Checked = True Then
            Dim objCmd As New Data.OleDb.OleDbCommand("SELECT SubjectName FROM SystemTrainSubjects ORDER BY SubjectName", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCmd.ExecuteReader
            lstAvailableSubjects.Items.Clear()
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    lstAvailableSubjects.Items.Add(objReader(0).ToString)
                End If
            End While
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Subject Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmEmployeeQualifications_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        boolFormInitializing = True
        LoadComboBoxes()
        If boolEditStatus = True Then
            'Populate the form with values for the edit record
            PopulateSavedData()
        End If
        boolFormInitializing = False
        'Force listbox refresh
        optParmSet.Checked = False : optParmSet.Checked = True
    End Sub

    Private Sub PopulateSavedData()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeQualifications WHERE TransactionId = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("CourseName").ToString) Then cboCourseName.SelectedItem = objReader("CourseName").ToString
            If IsDate(objReader("StartDate").ToString) Then dpStartDate.Value = CDate(objReader("StartDate").ToString)
            If IsDate(objReader("EndDate").ToString) Then dpEndDate.Value = CDate(objReader("EndDate").ToString)
            If Not IsDBNull(objReader("Institute").ToString) Then txtInstitute.Text = objReader("Institute").ToString
            If Not IsDBNull(objReader("Outcome").ToString) Then cboOutcome.SelectedItem = objReader("Outcome").ToString
            If Not IsDBNull(objReader("CourseLevel").ToString) Then cboCourseLevel.SelectedItem = objReader("CourseLevel").ToString
            'Split the subjects back to the grid
            If Not IsDBNull(objReader("SubjectsTaken").ToString) Then
                Dim strValues() As String = Split(objReader("SubjectsTaken").ToString, "|")
                For n As Integer = 0 To strValues.Length - 1
                    Dim strSubjectDetails() As String = Split(strValues(n), "~")
                    If strSubjectDetails.Length >= 2 Then
                        dGrid.Rows.Add(1)
                        dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = strSubjectDetails(0)
                        dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = strSubjectDetails(1)
                    End If
                Next
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Qualifications Edit"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub optParmSet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optParmSet.CheckedChanged
        If optParmSet.Checked = True Then
            LoadFormParms()
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(cboCourseName.Text) Then
            MessageBox.Show("Please select the course name from the list provided", "Invalid Course Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCourseName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboCourseLevel.Text) Then
            MessageBox.Show("Please select the course level from the list provided", "Invalid Course Level", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCourseLevel.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtInstitute.Text) Then
            MessageBox.Show("Please enter the name of the awarding institute", "Invalid Institute Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtInstitute.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboOutcome.Text) Then
            MessageBox.Show("Please select the course overall results from the list provided", "Invalid Course Outcomes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboOutcome.Focus()
            Exit Sub
        End If
        If dGrid.Rows.Count <= 0 Then
            MessageBox.Show("Any course must at least have 1 subject to it. Please enter this information", "Missing Course Subjects", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            lstAvailableSubjects.Focus()
            Exit Sub
        End If

        'All thing being fine, prepare data for saving or updating
        Dim strSql As String = Nothing
        Dim strSubjectDetails As String = Nothing

        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strSubject As String = Nothing
            Dim strGrade As String = "Pending"
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strSubject = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                strGrade = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
            End If
            strSubjectDetails = strSubjectDetails & strSubject & "~" & strGrade & "|"
        Next
        strSubjectDetails = Mid(strSubjectDetails, 1, (strSubjectDetails.Length - 1))

        Dim sStartDate As String = dpStartDate.Text
        Dim sEndDate As String = dpEndDate.Text
        If UCase(strSystemDateFormat) = UCase("English") Then
            sStartDate = Format(dpStartDate.Value, "dd-MMM-yyyy")
            sEndDate = Format(dpEndDate.Value, "dd-MMM-yyyy")
        End If
        If boolEditStatus = False Then
            strSql = "INSERT INTO EmployeeQualifications (EmployeeNo, CourseName, StartDate, " _
                & "EndDate, Institute, Outcome, SubjectsTaken, CourseLevel) VALUES ('" & strPublicEmployeeId & "', " _
                & "'" & cboCourseName.Text & "', '" & sStartDate & "', '" & sEndDate & "', " _
                & "'" & txtInstitute.Text & "', '" & cboOutcome.Text & "', '" & strSubjectDetails & "', '" & cboCourseLevel.Text & "')"
        Else
            strSql = "UPDATE EmployeeQualifications SET CourseName = '" & cboCourseName.Text & "', " _
                & "StartDate = '" & sStartDate & "', EndDate = '" & sEndDate & "', " _
                & "Institute = '" & txtInstitute.Text & "', Outcome = '" & cboOutcome.Text & "', " _
                & "SubjectsTaken = '" & strSubjectDetails & "', CourseLevel = '" & cboCourseLevel.Text & "' " _
                & "WHERE TransactionId = " & intSelectedTransaction & ""
        End If
        Dim objCmd As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCmd.ExecuteNonQuery()
        MessageBox.Show("Qualification details updated successfully", "Qualifications Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Subject Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
