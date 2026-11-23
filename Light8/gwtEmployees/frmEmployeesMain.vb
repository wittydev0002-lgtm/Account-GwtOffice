Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmEmployeesMain

    Dim _originalSplitterDistance As Integer
    Dim _originalSplitterDistanceSub As Integer
    Dim _widthLeftRight As Integer
    Dim _CurrentSplitterDistance As Integer
    Dim intPriorSplitterDistance As Integer

    Private Sub expandablePanel1_ExpandedChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles expandablePanel1.ExpandedChanged
        AdjustPanes()
    End Sub

    Private Sub AdjustPanes()
        If expandablePanel1.Expanded Then
            If (splitMain.Width - splitMain.Panel1.Width) < 150 Then intPriorSplitterDistance = splitMain.Width - 200
            splitMain.SplitterDistance = intPriorSplitterDistance
            splitMain.IsSplitterFixed = False
        Else
            intPriorSplitterDistance = splitMain.SplitterDistance
            splitMain.SplitterDistance = splitMain.Width - 32
            splitMain.IsSplitterFixed = True
        End If
    End Sub

    Private Sub frmEmployeesMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        LoadEmployeeData()
        If boolAbort = True Then Exit Sub
        LoadJobPrifiles()
    End Sub

    Private Sub LoadEmployeeData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strSql As String = "SELECT EmployeeMaster.EmployeeNo AS [Employee #], " _
            & "EmployeeMaster.LastName AS [Last Name], EmployeeMaster.FirstName AS [First Name], " _
            & "EmployeeMaster.OtherNames AS [Other Names], EmployeeMaster.IdNumber AS [ID Number], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), EmployeeMaster.BirthDate, 106), ' ', '-')) as [Birth Date], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), Employment.HireDate, 106), ' ', '-')) as [Hire Date], " _
            & "Status FROM EmployeeMaster LEFT OUTER JOIN Employment ON " _
            & "EmployeeMaster.EmployeeNo = Employment.EmployeeNo ORDER BY " _
            & "EmployeeMaster.LastName, EmployeeMaster.FirstName, EmployeeMaster.OtherNames, " _
            & "EmployeeMaster.EmployeeNo"

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable
        dGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        lblTotalRecords.Text = dGrid.RowCount
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Details Load error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If dGrid.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedEmployeeDetails()
            If boolDisallowSave = True Then
                MessageBox.Show("You have accessed a terminated employee. You can only view the record. " _
                    & "No changes will be saved", "Terminated Employee Record Assess", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Dim f As New frmEmployeeDetails
            f.ShowDialog()
        End If
    End Sub

    Private Sub GetSelectedEmployeeDetails()

        strPublicEmployeeId = Nothing
        strEmployeeLastName = Nothing
        strEmployeeFirstName = Nothing

        boolDisallowSave = False
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                strPublicEmployeeId = dGrid.CurrentRow.Cells(0).Value.ToString
            End If
        End If

        'Get the name of the employee for update on the details form
        If Not Object.Equals(dGrid.CurrentRow.Cells(1).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                strEmployeeLastName = Convert.ToString(dGrid.CurrentRow.Cells(1).Value)
            End If
        End If

        If Not Object.Equals(dGrid.CurrentRow.Cells(2).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(2).Value.ToString) Then
                strEmployeeFirstName = Convert.ToString(dGrid.CurrentRow.Cells(2).Value)
            End If
        End If
        If Not Object.Equals(dGrid.CurrentRow.Cells(6).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(6).Value.ToString) Then
                Dim CurrentCellStatus As String = dGrid.CurrentRow.Cells(6).Value.ToString
                If UCase(CStr(CurrentCellStatus)) = "INACTIVE" Then
                    boolDisallowSave = True
                End If
            End If
        End If

    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmEmployeeDetails
        frm.ShowDialog()
        LoadEmployeeData()
    End Sub

    Private Sub btnTraining_Click(sender As System.Object, e As System.EventArgs) Handles btnTraining.Click
        If dGrid.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedEmployeeDetails()
            If boolDisallowSave = True Then
                MessageBox.Show("You have accessed a terminated employee. You can only view the record. " _
                    & "No changes will be saved", "Terminated Employee Record Assess", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Dim f As New frmEducationAndTraining
            f.ShowDialog()
        End If
    End Sub

    Private Sub btnTrainingSetup_Click(sender As System.Object, e As System.EventArgs) Handles btnTrainingSetup.Click
        Dim frm As New frmTrainingAndAcademicCourses
        frm.ShowDialog()
    End Sub

    Private Sub btnSubjectSetup_Click(sender As System.Object, e As System.EventArgs) Handles btnSubjectSetup.Click
        Dim frm As New frmEducationSubjects
        frm.ShowDialog()
    End Sub

    Private Sub btnAcademicLevels_Click(sender As System.Object, e As System.EventArgs) Handles btnAcademicLevels.Click
        Dim frm As New frmEducationLevels
        frm.ShowDialog()
    End Sub

    Private Sub btnAddJob_Click(sender As System.Object, e As System.EventArgs) Handles btnAddJob.Click
        boolEditStatus = False : boolEditStatusTwo = False
        Dim frm As New frmJobProfileSetup
        frm.ShowDialog()
        LoadJobPrifiles()
    End Sub

    Private Function getJobReportTo(JobCode As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT JobTitle FROM JobProfiles WHERE JobCode = '" & JobCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                strReturn = objReader(0).ToString
            End If
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        Cursor = Cursors.Default
        Return strReturn
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On job profiles load"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Function getNumberOfHolders(JobCode As String) As Integer
        On Error GoTo RaiseErr
        Dim intReturn As Integer = 0
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT Count(JobCode) FROM JobProfiles WHERE JobCode = '" & JobCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If IsNumeric(objReader(0).ToString) Then
                    intReturn = CInt(objReader(0).ToString)
                End If
            End If
            End If
        objReader.Close()
        Return intReturn
        Exit Function
RaiseErr:
        Cursor = Cursors.Default
        Return intReturn
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On job profiles load"
        gwt_comm.ShowErrorMessage()
    End Function
    Private Sub LoadJobPrifiles()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT JobCode, JobTitle, [Location], JobGrade, JobStatus FROM JobProfiles ORDER BY JobCode", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGridJobs.Rows.Clear()
        While objReader.Read
            dGridJobs.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridJobs.Rows(dGridJobs.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridJobs.Rows(dGridJobs.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGridJobs.Rows(dGridJobs.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dGridJobs.Rows(dGridJobs.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
            dGridJobs.Rows(dGridJobs.Rows.Count - 1).Cells(4).Value = getJobReportTo(objReader(0).ToString)
            dGridJobs.Rows(dGridJobs.Rows.Count - 1).Cells(5).Value = getNumberOfHolders(objReader(0).ToString)
            If Not IsDBNull(objReader(4).ToString) Then dGridJobs.Rows(dGridJobs.Rows.Count - 1).Cells(6).Value = objReader(4).ToString
        End While
        objReader.Close()
        If dGridJobs.Rows.Count > 0 Then
            btnDeleteJob.Enabled = False
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On job profiles load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnJobCVategories_Click(sender As System.Object, e As System.EventArgs) Handles btnJobCVategories.Click
        Dim frm As New frmJobCategoriesListing
        frm.ShowDialog()
    End Sub

    Private Sub btnEditJob_Click(sender As System.Object, e As System.EventArgs) Handles btnEditJob.Click
        GetSelectedJob()
    End Sub

    Private Sub GetSelectedJob()
        boolEditStatus = True : boolEditStatusTwo = True
        If dGridJobs.Rows.Count > 0 Then
            strJobCode = dGridJobs.CurrentRow.Cells(0).Value
            Dim f As New frmJobProfileSetup
            f.ShowDialog()
        End If
    End Sub

    Private Sub dGridJobs_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridJobs.DoubleClick
        GetSelectedJob()
    End Sub

    Private Sub btnDeleteJob_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteJob.Click
        On Error GoTo RaiseErr
        If dGrid.Rows.Count <= 0 Then Exit Sub
        If dGrid.Rows.Count > 0 Then
            strJobCode = dGrid.CurrentRow.Cells(1).Value
            If MessageBox.Show("Are you sure you want to delete this job from the system?", "Confirm Job Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM JobProfiles WHERE JobCode = '" & strJobCode & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM JobOreps WHERE JobCode = '" & strJobCode & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM JobKeyTasks WHERE JobCode = '" & strJobCode & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM JobDesiredAttitudes WHERE JobCode = '" & strJobCode & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM JobQualifications WHERE JobCode = '" & strJobCode & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM JobSkills WHERE JobCode = '" & strJobCode & "'", cnn)
                objCommand.ExecuteNonQuery()
                LoadJobPrifiles()
                MessageBox.Show("Job deleted successfully", "Job Profile Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On Job Profile Deletion"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnBrintJob_Click(sender As System.Object, e As System.EventArgs) Handles btnBrintJob.Click
        If dGridJobs.Rows.Count <= 0 Then Exit Sub
        If dGridJobs.Rows.Count > 0 Then
            strJobCode = dGridJobs.CurrentRow.Cells(1).Value
            'Create the print job

        End If
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As EventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedEmployeeDetails()
            If boolDisallowSave = True Then
                MessageBox.Show("You have accessed a terminated employee. You can only view the record. " _
                    & "No changes will be saved", "Terminated Employee Record Assess", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Dim f As New frmEmployeeDetails
            f.ShowDialog()
            LoadEmployeeData()
        End If
    End Sub

    Private Sub btnEmployeeClasses_Click(sender As Object, e As EventArgs) Handles btnEmployeeClasses.Click
        Dim f As New frmEmployeeClassesSetup
        f.ShowDialog()
    End Sub

    Private Sub btnJobOreps_Click(sender As System.Object, e As System.EventArgs) Handles btnJobOreps.Click

    End Sub
End Class