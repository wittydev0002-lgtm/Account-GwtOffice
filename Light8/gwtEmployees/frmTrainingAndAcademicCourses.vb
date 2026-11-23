Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmTrainingAndAcademicCourses

    Dim boolFormLoading As Boolean = True

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmEducationCourses_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadPreliminaries()
        LoadSubjects()
        boolFormLoading = False
        If boolEditStatus = True Then LoadPastValues()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Courses Table Creation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadPastValues()
        On Error GoTo RaiseErr
        Dim objCmd As New Data.OleDb.OleDbCommand("SELECT * FROM SystemCourseDetails WHERE TransactionNo = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmd.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            txtCourseName.Text = objReader("CourseName").ToString
            cboLevel.Text = objReader("CourseLevel").ToString
            'Split the subjects
            Dim strValues() As String = Split(objReader("CourseSubjects").ToString, "|")
            For i As Integer = 0 To strValues.Length - 1
                chkLstSelected.Items.Add(strValues(i))
            Next
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Courses Table Creation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadPreliminaries()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT TrainingLevel FROM SystemTrainLevels", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboLevel.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboLevel.Items.Add(objReader(0).ToString)
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

    Private Sub LoadSubjects()
        On Error GoTo RaiseErr
        Dim strSelectedLevel As String = cboLevel.Text
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SubjectName FROM SystemTrainSubjects", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        chkLstSource.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                chkLstSource.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On subjects population"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub cboLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLevel.SelectedIndexChanged
        'If boolFormLoading = True Then Exit Sub
        'LoadSubjects()
    End Sub

    Private Sub btnAddSubject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSubject.Click
        Dim f As New frmEducationSubjects
        f.ShowDialog()
        LoadSubjects()
    End Sub

    Private Sub btnRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRight.Click
        If chkLstSource.CheckedItems.Count <> 0 Then
            ' If so, loop through all checked items and process options.
            For i As Integer = 0 To chkLstSource.CheckedItems.Count - 1
                chkLstSelected.Items.Add(chkLstSource.CheckedItems(i).ToString)
            Next i
            For i As Integer = 0 To chkLstSelected.Items.Count - 1
                'Immediately remove the item from the source list
                chkLstSource.Items.Remove(chkLstSelected.Items(i).ToString)
            Next
        End If
    End Sub

    Private Sub btnRightAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRightAll.Click
        'On Error Resume Next
        For i As Integer = 0 To chkLstSource.Items.Count - 1
            chkLstSource.SetItemCheckState(i, CheckState.Checked)
        Next
        If chkLstSource.CheckedItems.Count <> 0 Then
            ' If so, loop through all checked items and process options.
            For i As Integer = 0 To chkLstSource.CheckedItems.Count - 1
                chkLstSelected.Items.Add(chkLstSource.CheckedItems(i).ToString)
            Next i
            For i As Integer = 0 To chkLstSelected.Items.Count - 1
                'Immediately remove the item from the source list
                chkLstSource.Items.Remove(chkLstSelected.Items(i).ToString)
            Next
        End If
    End Sub

    Private Sub btnLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeft.Click
        If chkLstSelected.CheckedItems.Count <> 0 Then
            ' If so, loop through all checked items and process options.
            chkLstSource.Items.Add(chkLstSelected.SelectedItem.ToString)
            'Immediately remoe the item from the source list
            chkLstSelected.Items.Remove(chkLstSelected.SelectedItem.ToString)
        End If
    End Sub

    Private Sub btnLeftAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeftAll.Click
        For i As Integer = 0 To chkLstSelected.Items.Count - 1
            chkLstSelected.SetItemCheckState(i, CheckState.Checked)
        Next
        If chkLstSelected.CheckedItems.Count <> 0 Then
            ' If so, loop through all checked items and process options.
            For i As Integer = 0 To chkLstSelected.CheckedItems.Count - 1
                chkLstSource.Items.Add(chkLstSelected.CheckedItems(i).ToString)
            Next i
            For i As Integer = 0 To chkLstSource.Items.Count - 1
                'Immediately remoe the item from the source list
                chkLstSelected.Items.Remove(chkLstSource.Items(i).ToString)
            Next
        End If
    End Sub

    Private Sub chkSelectLeftAll_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSelectLeftAll.CheckStateChanged
        If chkSelectLeftAll.Checked = True Then
            For i As Integer = 0 To chkLstSource.Items.Count - 1
                chkLstSource.SetItemCheckState(i, CheckState.Checked)
            Next
        End If
        If chkSelectLeftAll.Checked = False Then
            For i As Integer = 0 To chkLstSource.Items.Count - 1
                chkLstSource.SetItemCheckState(i, CheckState.Unchecked)
            Next
        End If
    End Sub

    Private Sub chkSelectRightAll_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSelectRightAll.CheckStateChanged
        If chkSelectRightAll.Checked = True Then
            For i As Integer = 0 To chkLstSelected.Items.Count - 1
                chkLstSelected.SetItemCheckState(i, CheckState.Checked)
            Next
        End If
        If chkSelectRightAll.Checked = False Then
            For i As Integer = 0 To chkLstSelected.Items.Count - 1
                chkLstSelected.SetItemCheckState(i, CheckState.Unchecked)
            Next
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If chkLstSelected.Items.Count <= 0 Then
            MessageBox.Show("For a course to be set up, it must have at least 1 subject", "Missing Subjects", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtCourseName.Text) Then
            MessageBox.Show("Please enter a valid name for the course", "Invalid Course Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCourseName.Focus()
            Exit Sub
        End If
        Dim strSubjects As String = Nothing
        For i As Integer = 0 To chkLstSelected.Items.Count - 1
            strSubjects = strSubjects & "|" & chkLstSelected.Items(i).ToString
        Next
        'Take off the first harsh
        strSubjects = Mid(strSubjects, 2, strSubjects.Length)
        Dim strSql As String = Nothing
        If boolEditStatus = False Then
            strSql = "INSERT INTO SystemCourseDetails (CourseName, CourseLevel, InceptionDate, CourseSubjects) VALUES " _
                & "('" & txtCourseName.Text & "', '" & cboLevel.Text & "', '" & Now & "', '" & strSubjects & "')"
        Else
            strSql = "UPDATE SystemCourseDetails SET CourseName = '" & txtCourseName.Text & "', " _
                & "CourseLevel = '" & cboLevel.Text & "', InceptionDate = '" & Now & "', " _
                & "CourseSubjects = '" & strSubjects & "' WHERE TransactionNo = " & intSelectedTransaction & ""
        End If
        Dim objCmd As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCmd.ExecuteNonQuery()
        MessageBox.Show("Course updates successfully", "Course Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Education Courses Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAddLevel_Click(sender As System.Object, e As System.EventArgs) Handles btnAddLevel.Click
        Dim f As New frmEducationLevels
        f.ShowDialog()
        LoadPreliminaries()
    End Sub

End Class
