Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmJobsListing

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
        If dGridJobs.Rows.Count <= 0 Then Exit Sub
        If dGridJobs.Rows.Count > 0 Then
            strJobCode = dGridJobs.CurrentRow.Cells(1).Value
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


    Private Sub btnJobOreps_Click(sender As System.Object, e As System.EventArgs) Handles btnJobOreps.Click

    End Sub

    Private Sub frmJobsListing_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadJobPrifiles()
    End Sub

End Class
