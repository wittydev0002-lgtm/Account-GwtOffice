Imports System.Windows.Forms
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing

Public Class frmJobProfileSetup

    Dim boolIsLoading As Boolean

    'Declare the print fonts
    Dim titleFont As New Font("Verdana", 9, FontStyle.Bold)
    Dim fntSmallPrintFont As New Font("Verdana", 7, FontStyle.Bold)
    Dim fntSmallPrintFontRegular As New Font("Verdana", 7, FontStyle.Regular)
    Dim SubHeadingFont As New Font("Verdana", 8, FontStyle.Bold)
    Dim fntFooter As New Font("Verdana", 6, FontStyle.Bold)

    Dim arrTasks As ArrayList
    Dim arrQualifications As ArrayList
    Dim arrSkills As ArrayList
    Dim arrAttibutes As ArrayList

    Dim intItemCount As Integer
    Dim intQualificationsCount As Integer
    Dim intSkillsExperience As Integer
    Dim intAttributes As Integer

    Dim boolInNextPage As Boolean = False

    Dim strRemarks As String = Nothing

    Dim _originalSplitterDistance As Integer

    Private Sub frmProfiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        boolIsLoading = True
        Dim objCommand As Data.OleDb.OleDbCommand

        cboCategory.DropDownStyle = ComboBoxStyle.DropDownList
        LoadParentJobCodes()
        LoadCategories()
        LoadGrades()

        If boolEditStatusTwo = False Then
            txtJobCode.Enabled = True
        Else
            txtJobCode.Enabled = False
            LoadQualifications()
            LoadSkills()
            LoadTasks()
            LoadAttributes()
            LoadProfile()
        End If
        If txtGrade.Items.Count <= 0 Or txtNecGrade.Items.Count <= 0 Then lblWarning.Visible = True
        boolIsLoading = False
        TabControl1.SelectedIndex = 0
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On job profiles setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadParentJobCodes()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT JobTitle +';'+JobCode AS [Details] FROM JobProfiles ORDER BY ParentJob"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboParentJobCode
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "250;60"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(JobCode) FROM JobProfiles", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboParentJobCode.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboParentJobCode.SelectedIndex = -1
            cboParentJobCode.Items.Clear()
            cboParentJobCode.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboParentJobCode.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Parent Jobs Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadProfile()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT JobCode, JobTitle, JobCategory, JobFunction, " _
            & "JobGrade, Location, Notes, JobStatus, CONVERT(NVARCHAR, EffectiveDate, 105) AS [EffectiveDate], " _
            & "CONVERT(NVARCHAR, DiscontinueDate, 105) AS [DiscontinueDate], NecGrade, ParentJob FROM " _
            & "JobProfiles WHERE JobCode = '" & strJobCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            Dim strBuffer() As String
            If Not IsDBNull(objReader("JobCode").ToString) Then txtJobCode.Text = objReader("JobCode").ToString
            If Not IsDBNull(objReader("JobTitle").ToString) Then txtJobTitle.Text = objReader("JobTitle").ToString
            If Not IsDBNull(objReader("JobCategory").ToString) Then cboCategory.SelectedItem = objReader("JobCategory").ToString
            If Not IsDBNull(objReader("JobFunction").ToString) Then cboFunction.SelectedItem = objReader("JobFunction").ToString
            If Not IsDBNull(objReader("JobGrade").ToString) Then txtGrade.Text = objReader("JobGrade").ToString
            If Not IsDBNull(objReader("Location").ToString) Then txtLocation.Text = objReader("Location").ToString
            If Not IsDBNull(objReader("Notes").ToString) Then txtNotes.Text = objReader("Notes").ToString
            If Not IsDBNull(objReader("JobStatus").ToString) Then cboStatus.Text = objReader("JobStatus").ToString

            If Not IsDBNull(objReader("EffectiveDate").ToString) Then
                strBuffer = Split(objReader("EffectiveDate").ToString, "-")
                dpStartDate.Value = CDate(CInt(strBuffer(0)) & "-" & gwt_comm.getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
            End If

            lblTerminationDate.Text = Nothing
            If Not IsDBNull(objReader("DiscontinueDate").ToString) Then
                strBuffer = Split(objReader("DiscontinueDate").ToString, "-")
                lblTerminationDate.Text = CDate(CInt(strBuffer(0)) & "-" & gwt_comm.getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
                If lblTerminationDate.Text = "01-JAN-1900" Then lblTerminationDate.Text = Nothing
            End If

            If Not IsDBNull(objReader("NecGrade").ToString) Then txtNecGrade.Text = objReader("NecGrade").ToString
            If Not IsDBNull(objReader("ParentJob").ToString) Then
                If Not String.IsNullOrEmpty(objReader("ParentJob").ToString) Then
                    Dim objGetDescription As New Data.OleDb.OleDbCommand("SELECT JobTitle FROM JobProfiles " _
                        & "WHERE JobCode = '" & objReader("ParentJob").ToString & "'", cnn)
                    Dim objReadJob As Data.OleDb.OleDbDataReader = objGetDescription.ExecuteReader
                    If objReadJob.HasRows Then
                        objReadJob.Read()
                        cboParentJobCode.Text = objReadJob(0).ToString
                        lblCode.Text = objReader("ParentJob").ToString
                    End If
                    objReadJob.Close()
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = False
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On job profile setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveData()
        boolEditStatusTwo = True
        Me.Close()
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseErr
        boolAbort = False
        If String.IsNullOrEmpty(txtJobCode.Text) Then
            MessageBox.Show("The job code is missing. Please re-enter", "Invalid Job Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtJobCode.Focus()
            boolAbort = True
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtJobTitle.Text) Then
            MessageBox.Show("The job title is missing. Please re-enter", "Invalid Job Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtJobTitle.Focus()
            boolAbort = True
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboCategory.Text) Then
            MessageBox.Show("The job category is missing. Please re-enter", "Invalid Job Category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCategory.Focus()
            boolAbort = True
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtGrade.Text) Then
            MessageBox.Show("The job grade is missing. Please re-enter", "Invalid Job Grade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGrade.Focus()
            boolAbort = True
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboFunction.Text) Then
            MessageBox.Show("The job function is missing. Please re-enter", "Invalid Job Function", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboFunction.Focus()
            boolAbort = True
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtLocation.Text) Then
            MessageBox.Show("The job location is missing. Please re-enter", "Invalid Job Location", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLocation.Focus()
            boolAbort = True
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblCode.Text) Then lblCode.Text = "0"
        If String.IsNullOrEmpty(lblCode.Text) Then
            MessageBox.Show("Please state to which this job reports to.", "Missing Reporting Structure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboParentJobCode.Focus()
            boolAbort = True
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboStatus.Text) Then
            cboStatus.Text = "ACTIVE"
        End If
        Dim strSql As String = Nothing
        Dim strEffectiveDate As String = "01-JAN-2000"
        'Dim strDiscontinueDate As String = "01-JAN-1900"
        If dpStartDate.Checked = True Then
            strEffectiveDate = dpStartDate.Text
            If UCase(strSystemDateFormat) = UCase("English") Then strEffectiveDate = CStr(gwt_comm.shortMonthDateFormat(dpStartDate.Value))
        End If
        'If dpEndDate.Checked = True Then
        '    strDiscontinueDate = dpEndDate.Text
        '    If UCase(strSystemDateFormat) = UCase("English") Then strDiscontinueDate = CStr(Format(dpEndDate.Value, "dd-MMM-yyyy"))
        'End If
        Dim sqlCommand As Data.OleDb.OleDbCommand
        If gwt_comm.CheckColumnExistence("JobProfiles", "JobCatery") = True Then
            strSql = "ALTER TABLE JobProfiles DROP COLUMN JobCatery"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            sqlCommand.ExecuteNonQuery()
        End If

        If boolEditStatusTwo = False Then
            strSql = "INSERT INTO JobProfiles (JobCode, JobTitle, JobCategory, JobFunction, " _
                & "JobGrade, Location, Notes, EffectiveDate, JobStatus, NecGrade, ParentJob) VALUES " _
                & "('" & txtJobCode.Text & "', '" & txtJobTitle.Text & "', '" & cboCategory.Text & "', " _
                & "'" & cboFunction.Text & "', '" & txtGrade.Text & "', '" & txtLocation.Text & "', " _
                & "'" & txtNotes.Text & "', '" & strEffectiveDate & "', '" & cboStatus.Text & "', " _
                & "'" & txtNecGrade.Text & "', '" & lblCode.Text & "')"
        Else
            strSql = "UPDATE JobProfiles SET JobTitle = '" & txtJobTitle.Text & "', JobCategory = '" & cboCategory.Text & "', " _
                & "JobFunction = '" & cboFunction.Text & "', JobGrade = '" & txtGrade.Text & "', " _
                & "Location = '" & txtLocation.Text & "', Notes = '" & txtNotes.Text & "', " _
                & "EffectiveDate = '" & strEffectiveDate & "', JobStatus = '" & cboStatus.Text & "', " _
                & "NecGrade = '" & txtNecGrade.Text & "', ParentJob = '" & lblCode.Text & "' WHERE JobCode = '" & txtJobCode.Text & "'"
        End If

        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        sqlCommand.ExecuteNonQuery()

        'Just make sure that the job code is carried through out
        strJobCode = txtJobCode.Text

        MessageBox.Show("Job Profile saved successfully", "Job Profile Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadGrades()
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT InternalGrade FROM JobGrades ORDER BY InternalGrade", cnn)
        objReader = objCommand.ExecuteReader
        txtGrade.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then txtGrade.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT NecGrade FROM JobGrades ORDER BY NecGrade", cnn)
        objReader = objCommand.ExecuteReader
        txtNecGrade.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then txtNecGrade.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadQualifications()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM JobQualifications WHERE " _
            & "JobCode = '" & strJobCode & "' ORDER BY Weighting, TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dgrdQualifications.Rows.Clear()
        While objReader.Read
            With dgrdQualifications
                .Rows.Add(1)
                If Not IsDBNull(objReader("TransactionId").ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader("TransactionId").ToString
                If Not IsDBNull(objReader("Description").ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader("Description").ToString
                If Not IsDBNull(objReader("MinimumLevel").ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader("MinimumLevel").ToString
                If Not IsDBNull(objReader("Weighting").ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = objReader("Weighting").ToString
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dgrdQualifications_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrdQualifications.DoubleClick
        GetSelectedRecord()
    End Sub

    Private Sub GetSelectedRecord()
        If dgrdQualifications.Rows.Count > 0 Then
            boolEditStatusTwo = True
            intSelectedTransaction = CInt(dgrdQualifications.CurrentRow.Cells(0).Value)
            Dim f As New frmJobQualificationsEntry
            f.ShowDialog()
            LoadQualifications()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        boolEditStatusTwo = False
        Dim f As New frmJobCategories
        f.ShowDialog()
        LoadCategories()
    End Sub

    Private Sub LoadCategories()
        On Error GoTo RaiseErr
        cboCategory.Items.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT JobCategory FROM SystemJobCategories ORDER BY JobCategory", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboCategory.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        btnAdd.Enabled = False
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on Job Categories Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAddQualification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddQualification.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtJobCode.Text) Then
            MessageBox.Show("Cannot add qualification to this job. Missing the job code", "Missing Mandatory Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtJobCode.Focus()
            Exit Sub
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT JobCode FROM JobProfiles WHERE JobCode = '" & txtJobCode.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows = False Then
            If MessageBox.Show("Job details must be saved before saving qualifications. Do you want to save now?", "Save Job Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                SaveData()
            Else
                objReader.Close()
                Exit Sub
            End If
        End If
        objReader.Close()
        boolEditStatusTwo = False
        strJobCode = txtJobCode.Text
        Dim f As New frmJobQualificationsEntry
        f.ShowDialog()
        LoadQualifications()
        boolEditStatusTwo = True
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on qualifications add"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEditQualification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditQualification.Click
        boolEditStatusTwo = True
        If dgrdQualifications.Rows.Count > 0 Then
            intSelectedTransaction = CInt(dgrdQualifications.CurrentRow.Cells(0).Value.ToString)
            Dim f As New frmJobQualificationsEntry
            f.ShowDialog()
            LoadQualifications()
        End If
    End Sub

    Private Sub btnAddSkill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSkill.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtJobCode.Text) Then
            MessageBox.Show("Cannot add skills to this job. Missing the job code", "Missing Mandatory Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtJobCode.Focus()
            Exit Sub
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT JobCode FROM JobProfiles WHERE JobCode = '" & txtJobCode.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows = False Then
            If MessageBox.Show("Job details must be saved before saving skills. Do you want to save now?", _
                "Save Job Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                SaveData()
            Else
                objReader.Close()
                Exit Sub
            End If
        End If
        objReader.Close()
        boolEditStatusTwo = False
        strJobCode = txtJobCode.Text
        Dim f As New frmSkillsEntry
        f.ShowDialog()
        LoadSkills()
        boolEditStatusTwo = True
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on Job Skills"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadSkills()
        'INSERT INTO JobSkills (JobCode, Description, MinimumYears, Weighting)
        On Error GoTo RaiseErr
        dgridSkills.Rows.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT JobCode, " _
            & "Description, MinimumYears, Weighting, TransactionId FROM JobSkills WHERE " _
            & "JobCode = '" & strJobCode & "' ORDER BY Description", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            With dgridSkills
                .Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                End If
                If Not IsDBNull(objReader(1).ToString) Then
                    .Rows(.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                End If
                If Not IsDBNull(objReader(2).ToString) Then
                    .Rows(.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
                End If
                If Not IsDBNull(objReader(3).ToString) Then
                    .Rows(.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
                End If
                If Not IsDBNull(objReader(4).ToString) Then
                    .Rows(.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
                End If
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        btnAdd.Enabled = False
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on Job Skills Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEditSkill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditSkill.Click
        If dgridSkills.Rows.Count > 0 Then
            If dgridSkills.SelectedRows.Count > 0 Then
                intSelectedTransaction = CInt(dgridSkills.CurrentRow.Cells(4).Value.ToString)
                strJobCode = dgridSkills.CurrentRow.Cells(0).Value.ToString
                boolEditStatusTwo = True
                Dim f As New frmSkillsEntry
                f.ShowDialog()
                LoadSkills()
            End If
        End If
    End Sub

    Private Sub btnAddAttitude_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAttitude.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtJobCode.Text) Then
            MessageBox.Show("Cannot add attributes to this job. Missing the job code", "Missing Mandatory Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtJobCode.Focus()
            Exit Sub
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT JobCode FROM JobProfiles WHERE JobCode = '" & txtJobCode.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows = False Then
            If MessageBox.Show("Job details must be saved before saving attributes. Do you want to save now?", "Save Job Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                boolAbort = False
                SaveData()
                If boolAbort = True Then Exit Sub
            Else
                objReader.Close()
                Exit Sub
            End If
        End If
        objReader.Close()
        boolEditStatusTwo = False
        Dim f As New frmAttitudeEntries
        f.ShowDialog()
        LoadAttributes()
        boolEditStatusTwo = True
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on Job Attributes"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAddTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTask.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtJobCode.Text) Then
            MessageBox.Show("Cannot add tasks to this job. Missing the job code", "Missing Mandatory Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TabControl1.SelectedIndex = 0
            txtJobCode.Focus()
            Exit Sub
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT JobCode FROM JobProfiles WHERE JobCode = '" & txtJobCode.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows = False Then
            If MessageBox.Show("Job details must be saved before saving tasks. Do you want to save now?", "Save Job Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                boolAbort = False
                SaveData()
                If boolAbort = True Then Exit Sub
            Else
                objReader.Close()
                Exit Sub
            End If
        End If
        objReader.Close()
        boolEditStatusTwo = False
        Dim f As New frmTaskEntries
        f.ShowDialog()
        LoadTasks()
        boolEditStatusTwo = True
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on Job Tasks"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEditTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditTask.Click
        If dGridTasks.Rows.Count > 0 Then
            'If dGridTasks.Focused = True Then
            intSelectedTransaction = CInt(dGridTasks.CurrentRow.Cells(0).Value.ToString)
            strSelectedValue = dGridTasks.CurrentRow.Cells(1).Value.ToString
            boolEditStatusTwo = True
            Dim f As New frmTaskEntries
            f.ShowDialog()
            LoadTasks()
            Exit Sub
            'End If
        End If
    End Sub

    Private Sub LoadTasks()
        On Error GoTo RaiseErr
        boolIsLoading = True
        dGridTasks.Rows.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM JobKeyTasks WHERE JobCode = '" & strJobCode & "' ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGridTasks.Rows.Add(1)
            If Not IsDBNull(objReader("TransactionId").ToString) Then
                dGridTasks.Rows(dGridTasks.Rows.Count - 1).Cells(0).Value = objReader("TransactionId").ToString
            End If
            If Not IsDBNull(objReader("Description").ToString) Then
                dGridTasks.Rows(dGridTasks.Rows.Count - 1).Cells(1).Value = objReader("Description").ToString
            End If

            If Not IsDBNull(objReader("DecisionMaking").ToString) Then
                dGridTasks.Rows(dGridTasks.Rows.Count - 1).Cells(2).Value = objReader("DecisionMaking").ToString
            End If
            If Not IsDBNull(objReader("Frequency").ToString) Then
                dGridTasks.Rows(dGridTasks.Rows.Count - 1).Cells(3).Value = objReader("Frequency").ToString
            End If
            If Not IsDBNull(objReader("Consequencies").ToString) Then
                dGridTasks.Rows(dGridTasks.Rows.Count - 1).Cells(4).Value = objReader("Consequencies").ToString
            End If
            If Not IsDBNull(objReader("Supervision").ToString) Then
                dGridTasks.Rows(dGridTasks.Rows.Count - 1).Cells(5).Value = objReader("Supervision").ToString
            End If
            If Not IsDBNull(objReader("InputSources").ToString) Then
                dGridTasks.Rows(dGridTasks.Rows.Count - 1).Cells(6).Value = objReader("InputSources").ToString
            End If
            If Not IsDBNull(objReader("DeadLines").ToString) Then
                dGridTasks.Rows(dGridTasks.Rows.Count - 1).Cells(7).Value = objReader("DeadLines").ToString
            End If
            If Not IsDBNull(objReader("Relations").ToString) Then
                dGridTasks.Rows(dGridTasks.Rows.Count - 1).Cells(8).Value = objReader("Relations").ToString
            End If

        End While
        objReader.Close()
        boolIsLoading = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on Job Skills"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEditAttitude_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditAttitude.Click
        If dgridAttitudes.Rows.Count > 0 Then
            'If dGridTasks.Focused = True Then
            intSelectedTransaction = CInt(dgridAttitudes.CurrentRow.Cells(0).Value.ToString)
            strSelectedValue = dgridAttitudes.CurrentRow.Cells(1).Value.ToString
            boolEditStatusTwo = True
            Dim f As New frmAttitudeEntries
            f.ShowDialog()
            LoadAttributes()
            Exit Sub
            'End If
        End If
    End Sub

    Private Sub LoadAttributes()
        On Error GoTo RaiseErr
        dgridAttitudes.Rows.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM JobDesiredAttitudes WHERE JobCode = '" & strJobCode & "' ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dgridAttitudes.Rows.Add(1)
            If Not IsDBNull(objReader("TransactionId").ToString) Then
                dgridAttitudes.Rows(dgridAttitudes.Rows.Count - 1).Cells(0).Value = objReader("TransactionId").ToString
            End If
            If Not IsDBNull(objReader("Description").ToString) Then
                dgridAttitudes.Rows(dgridAttitudes.Rows.Count - 1).Cells(1).Value = objReader("Description").ToString
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on Job Attitudes"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDeleteQualification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteQualification.Click
        On Error GoTo RaiseErr
        If dgrdQualifications.Rows.Count > 0 Then
            intSelectedTransaction = CInt(dgrdQualifications.CurrentRow.Cells(0).Value.ToString)
            If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM JobQualifications WHERE TransactionId = " & intSelectedTransaction & " AND JobCode = '" & strJobCode & "'", cnn)
                objCommand.ExecuteNonQuery()
                MessageBox.Show("Record deleted successfully", "Record Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadQualifications()
            End If
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on Job Qualifications Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDeleteSkill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteSkill.Click
        On Error GoTo RaiseErr
        If dgridSkills.Rows.Count > 0 Then
            intSelectedTransaction = CInt(dgridSkills.CurrentRow.Cells(4).Value.ToString)
            If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM JobSkills WHERE TransactionId = " & intSelectedTransaction & " AND JobCode = '" & strJobCode & "'", cnn)
                objCommand.ExecuteNonQuery()
                MessageBox.Show("Record deleted successfully", "Record Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadSkills()
            End If
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on Job Skills Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDeleteAttribute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAttribute.Click
        On Error GoTo RaiseErr
        If dgridAttitudes.Rows.Count > 0 Then
            intSelectedTransaction = CInt(dgridAttitudes.CurrentRow.Cells(0).Value.ToString)
            If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM JobDesiredAttitudes WHERE TransactionId = " & intSelectedTransaction & " AND JobCode = '" & strJobCode & "'", cnn)
                objCommand.ExecuteNonQuery()
                MessageBox.Show("Record deleted successfully", "Record Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadAttributes()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on Job Attitudes Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDeleteTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteTask.Click
        On Error GoTo RaiseErr
        If dGridTasks.Rows.Count > 0 Then
            intSelectedTransaction = CInt(dGridTasks.CurrentRow.Cells(0).Value.ToString)
            If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM JobKeyTasks WHERE TransactionId = " & intSelectedTransaction & " AND JobCode = '" & strJobCode & "'", cnn)
                objCommand.ExecuteNonQuery()
                MessageBox.Show("Record deleted successfully", "Record Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadTasks()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on Job Tasks Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboParentJobCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboParentJobCode.SelectedIndexChanged
        If cboParentJobCode.Focused = False Then Exit Sub
        If Not cboParentJobCode.SelectedItem Is Nothing Then
            lblCode.Text = cboParentJobCode.SelectedItem.Col2
        Else
            lblCode.Text = ""
        End If
    End Sub

    Private Sub dGridTasks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridTasks.Click
        If dGridTasks.Rows.Count > 0 Then PopulateTaskDetails()
    End Sub

    Private Sub PopulateTaskDetails()
        With dgrdTaskDetails
            .Rows.Clear()
            Dim backColor As Color = Color.FromArgb(255, 255, 255)
            Dim foreColor As Color = Color.FromArgb(255, 128, 40)

            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
            .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
            .Rows(.Rows.Count - 1).Cells(0).Value = "DECISION TYPE"
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = dGridTasks.CurrentRow.Cells(2).Value.ToString

            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
            .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
            .Rows(.Rows.Count - 1).Cells(0).Value = "FREQUENCY"
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = dGridTasks.CurrentRow.Cells(3).Value.ToString

            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
            .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
            .Rows(.Rows.Count - 1).Cells(0).Value = "CONSEQUENCIES"
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = dGridTasks.CurrentRow.Cells(4).Value.ToString

            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
            .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
            .Rows(.Rows.Count - 1).Cells(0).Value = "SUPERVISION"
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = dGridTasks.CurrentRow.Cells(5).Value.ToString

            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
            .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
            .Rows(.Rows.Count - 1).Cells(0).Value = "RESOURCES"
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = dGridTasks.CurrentRow.Cells(6).Value.ToString

            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
            .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
            .Rows(.Rows.Count - 1).Cells(0).Value = "TIME LINES"
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = dGridTasks.CurrentRow.Cells(7).Value.ToString

            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
            .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
            .Rows(.Rows.Count - 1).Cells(0).Value = "COMMUNICATIONS"
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = dGridTasks.CurrentRow.Cells(8).Value.ToString

        End With
    End Sub

    Private Sub dGridTasks_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridTasks.DoubleClick
        If dGridTasks.Rows.Count > 0 Then
            'If dGridTasks.Focused = True Then
            intSelectedTransaction = CInt(dGridTasks.CurrentRow.Cells(0).Value.ToString)
            strSelectedValue = dGridTasks.CurrentRow.Cells(1).Value.ToString
            boolEditStatusTwo = True
            Dim f As New frmTaskEntries
            f.ShowDialog()
            LoadTasks()
            Exit Sub
            'End If
        End If
    End Sub

    Private Sub dGridTasks_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridTasks.SelectionChanged
        If boolIsLoading = True Then Exit Sub
        PopulateTaskDetails()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        PrintJobDescription()
    End Sub

    Public Sub PrintJobDescription()
        '************* Printing Logic ***********************************************
        'Identification
        'Duties and Responsibilities and Time Commitments (Key Tasks)
        boolAbort = False
        GetTasks()
        If boolAbort = True Then Exit Sub
        boolAbort = False
        GetQualifications()
        If boolAbort = True Then Exit Sub
        boolAbort = False
        GetSkillsExperience()
        If boolAbort = True Then Exit Sub
        boolAbort = False
        GetAttributes()
        If boolAbort = True Then Exit Sub
        'Occupationl Risk Profile
        '-Environmental
        '-Physical
        '-Psychological
        '-Chemical
        'Remarks
        intItemCount = 0
        intQualificationsCount = 0
        intSkillsExperience = 0
        intAttributes = 0

        boolInNextPage = False

        ppd.Document = pdProfile
        ppd.ShowDialog()
    End Sub

    Private Sub GetAttributes()
        On Error GoTo RaiseErr
        arrAttibutes = New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM JobDesiredAttitudes WHERE JobCode = '" & strJobCode & "' ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader("Description").ToString) Then
                arrAttibutes.Add(objReader("Description").ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCr & "on Job Attitudes Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetSkillsExperience()
        On Error GoTo RaiseErr
        arrSkills = New ArrayList
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT JobCode, " _
            & "Description, MinimumYears, Weighting, TransactionId FROM JobSkills WHERE " _
            & "JobCode = '" & strJobCode & "' ORDER BY Description", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        While objReader.Read
            Dim strDescription As String = Nothing
            Dim strLevel As String = Nothing
            Dim strWeight As String = Nothing
            With dgrdQualifications
                If Not IsDBNull(objReader("Description").ToString) Then
                    strDescription = objReader("Description").ToString
                End If
                If Not IsDBNull(objReader("MinimumYears").ToString) Then
                    strLevel = objReader("MinimumYears").ToString
                End If
                If Not IsDBNull(objReader("Weighting").ToString) Then
                    strWeight = objReader("Weighting").ToString
                End If
                arrSkills.Add(strDescription & "|" & strLevel & "|" & strWeight)
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Skills and Experience Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetQualifications()
        On Error GoTo RaiseErr
        arrQualifications = New ArrayList
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM JobQualifications WHERE " _
            & "JobCode = '" & strJobCode & "' ORDER BY Weighting, TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        While objReader.Read
            Dim strDescription As String = Nothing
            Dim strLevel As String = Nothing
            Dim strWeight As String = Nothing
            With dgrdQualifications
                If Not IsDBNull(objReader("Description").ToString) Then
                    strDescription = objReader("Description").ToString
                End If
                If Not IsDBNull(objReader("MinimumLevel").ToString) Then
                    strLevel = objReader("MinimumLevel").ToString
                End If
                If Not IsDBNull(objReader("Weighting").ToString) Then
                    strWeight = objReader("Weighting").ToString
                End If
                arrQualifications.Add(strDescription & "|" & strLevel & "|" & strWeight)
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Qualifications Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetTasks()
        On Error GoTo RaiseErr
        arrTasks = New ArrayList
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM JobKeyTasks WHERE JobCode = '" & strJobCode & "' ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader("Description").ToString) Then
                arrTasks.Add(objReader("Description").ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Tasks Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub pdProfile_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdProfile.PrintPage

        On Error GoTo RaiseErr

        Dim x1 As Integer = pdProfile.DefaultPageSettings.Margins.Left
        Dim x2 As Integer = x1 + 100
        Dim x3 As Integer = x2 + 100
        Dim x4 As Integer = x3 + 100
        Dim x5 As Integer = x4 + 100
        Dim x6 As Integer = x5 + 100
        Dim y As Integer = pdProfile.DefaultPageSettings.Margins.Top
        Dim yBottom As Integer = e.PageBounds.Height - (pdProfile.DefaultPageSettings.Margins.Bottom) ' + pdProfile.DefaultPageSettings.Margins.Top)

        Dim grdCurrent As Graphics = e.Graphics
        Dim recCurrent As Rectangle
        Dim sbCurrent As SolidBrush
        Dim myPen As System.Drawing.Pen
        Dim WhiteBrush As System.Drawing.Brush
        Dim BlackBrush As System.Drawing.Brush

        WhiteBrush = New SolidBrush(Color.White)
        BlackBrush = New SolidBrush(Color.Black)

        'Draw the page border
        myPen = New Pen(Brushes.Gray)
        With pdProfile.DefaultPageSettings
            recCurrent = New Rectangle(.Margins.Left, .Margins.Top, e.PageBounds.Width - (.Margins.Left + .Margins.Right), e.PageBounds.Height - (.Margins.Bottom + .Margins.Top))
            e.Graphics.DrawRectangle(myPen, rect:=recCurrent)
        End With

        If boolInNextPage = False Then
            y = y + 15
            recCurrent = New Rectangle(x1, (y - 4), e.PageBounds.Right - e.PageBounds.Left - 200, 20)
            sbCurrent = New SolidBrush(Color.Black)
            grdCurrent.FillRectangle(sbCurrent, recCurrent)
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y, x2, y, "JOB IDENTIFICATION DETAILS", titleFont, Brushes.White)
            y = y + 15

            'Indext a bit from the border by adjusting the X1 position
            x1 = x1 + 5

            'Print details advancing 15 pixels between lines
            Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM JobProfiles WHERE JobCode = '" & strJobCode & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader("JobCode").ToString) Then
                    y = y + 15
                    Call gwt_comm.DrawStringInBoxLeft(e, x1, y, x2, y, "Job Code", SubHeadingFont, Brushes.Black)
                    Call gwt_comm.DrawStringInBoxLeft(e, x3, y, x5, y, objReader("JobCode").ToString(), fntSmallPrintFontRegular, Brushes.Black)
                End If

                If Not IsDBNull(objReader("JobTitle").ToString) Then
                    y = y + 15
                    Call gwt_comm.DrawStringInBoxLeft(e, x1, y, x2, y, "Job Title", SubHeadingFont, Brushes.Black)
                    Call gwt_comm.DrawStringInBoxLeft(e, x3, y, x5, y, objReader("JobTitle").ToString(), fntSmallPrintFontRegular, Brushes.Black)
                End If

                If Not IsDBNull(objReader("JobCategory").ToString) Then
                    y = y + 15
                    Call gwt_comm.DrawStringInBoxLeft(e, x1, y, x2, y, "Category", SubHeadingFont, Brushes.Black)
                    Call gwt_comm.DrawStringInBoxLeft(e, x3, y, x5, y, objReader("JobCategory").ToString(), fntSmallPrintFontRegular, Brushes.Black)
                End If

                If Not IsDBNull(objReader("JobFunction").ToString) Then
                    y = y + 15
                    Call gwt_comm.DrawStringInBoxLeft(e, x1, y, x2, y, "Job Function", SubHeadingFont, Brushes.Black)
                    Call gwt_comm.DrawStringInBoxLeft(e, x3, y, x5, y, objReader("JobFunction").ToString(), fntSmallPrintFontRegular, Brushes.Black)
                End If

                If Not IsDBNull(objReader("JobGrade").ToString) Then
                    y = y + 15
                    Call gwt_comm.DrawStringInBoxLeft(e, x1, y, x2, y, "Internal Grade", SubHeadingFont, Brushes.Black)
                    Call gwt_comm.DrawStringInBoxLeft(e, x3, y, x5, y, objReader("JobGrade").ToString(), fntSmallPrintFontRegular, Brushes.Black)
                End If

                If Not IsDBNull(objReader("NecGrade").ToString) Then
                    y = y + 15
                    Call gwt_comm.DrawStringInBoxLeft(e, x1, y, x2, y, "NEC Grade", SubHeadingFont, Brushes.Black)
                    Call gwt_comm.DrawStringInBoxLeft(e, x3, y, x5, y, objReader("NecGrade").ToString(), fntSmallPrintFontRegular, Brushes.Black)
                End If

                If Not IsDBNull(objReader("Location").ToString) Then
                    y = y + 15
                    Call gwt_comm.DrawStringInBoxLeft(e, x1, y, x2, y, "Location", SubHeadingFont, Brushes.Black)
                    Call gwt_comm.DrawStringInBoxLeft(e, x3, y, x5, y, objReader("Location").ToString(), fntSmallPrintFontRegular, Brushes.Black)
                End If

                If Not IsDBNull(objReader("Notes").ToString) Then
                    strRemarks = objReader("Notes").ToString
                End If

                If Not IsDBNull(objReader("JobStatus").ToString) Then
                    y = y + 15
                    Call gwt_comm.DrawStringInBoxLeft(e, x1, y, x2, y, "Job Status", SubHeadingFont, Brushes.Black)
                    Call gwt_comm.DrawStringInBoxLeft(e, x3, y, x5, y, objReader("JobStatus").ToString(), fntSmallPrintFontRegular, Brushes.Black)
                End If

                'If IsDate(objReader("EffectiveDate").ToString) Then
                '    y = y + 15

                '    dpStartDate.Value = CDate(objReader("EffectiveDate").ToString)
                'End If

                'If IsDate(objReader("DiscontinueDate").ToString) Then
                '    y = y + 15

                '    dpEndDate.Value = CDate(objReader("DiscontinueDate").ToString)
                'End If

                If Not IsDBNull(objReader("ParentJob").ToString) Then
                    If Not String.IsNullOrEmpty(objReader("ParentJob").ToString) Then
                        Dim objGetDescription As New Data.OleDb.OleDbCommand("SELECT JobTitle FROM JobProfiles " _
                            & "WHERE JobCode = '" & objReader("ParentJob").ToString & "'", cnn)
                        Dim objReadJob As Data.OleDb.OleDbDataReader = objGetDescription.ExecuteReader
                        If objReadJob.HasRows Then
                            objReadJob.Read()
                            y = y + 15
                            Call gwt_comm.DrawStringInBoxLeft(e, x1, y, x2, y, "Reports To", SubHeadingFont, Brushes.Black)
                            'cboParentJobCode.Text = objReadJob(0).ToString
                            'lblCode.Text = objReader("ParentJob").ToString
                            Call gwt_comm.DrawStringInBoxLeft(e, x3, y, x5, y, objReadJob(0).ToString(), fntSmallPrintFontRegular, Brushes.Black)
                        End If
                        objReadJob.Close()
                    End If
                End If
            End If
            objReader.Close()
            y = y + 35

        End If
        '
        '*************** Print the key Job Tasks *****************************************************************
        '
        y = y + 15

        While intItemCount < arrTasks.Count
            If intItemCount = 0 Then
                recCurrent = New Rectangle((x1 - 5), (y - 4), e.PageBounds.Right - e.PageBounds.Left - 200, 20)
                sbCurrent = New SolidBrush(Color.Black)
                grdCurrent.FillRectangle(sbCurrent, recCurrent)
                Call gwt_comm.DrawStringInBoxLeft(e, (x1 - 5), y, x4, y, "KEY TASKS", titleFont, Brushes.White)
                y = y + 15
            End If
            y = y + 15
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y, (x1 + 13), y, "* ", SubHeadingFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x1 + 15, y, x5, y, arrTasks.Item(intItemCount).ToString, fntSmallPrintFontRegular, Brushes.Black)
            intItemCount = intItemCount + 1
            If y > (yBottom - 30) Then
                boolInNextPage = True
                e.HasMorePages = True
                Exit Sub
            End If
        End While

        'Print the qualifications
        '
        '*************** Print the Job Qualifications *****************************************************************
        '
        y = y + 30
        While intQualificationsCount < arrQualifications.Count
            If intQualificationsCount = 0 Then
                recCurrent = New Rectangle((x1 - 5), (y - 4), e.PageBounds.Right - e.PageBounds.Left - 200, 20)
                sbCurrent = New SolidBrush(Color.Black)
                grdCurrent.FillRectangle(sbCurrent, recCurrent)
                Call gwt_comm.DrawStringInBoxLeft(e, (x1 - 5), y, x4, y, "EDUCATIONAL QUALIFICATIONS", titleFont, Brushes.White)
                y = y + 30
                'Print the sub headers for description, level and weighting
                Call gwt_comm.DrawStringInBoxLeft(e, x1, y, (x1 + 300), y, "Qualification", SubHeadingFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, x4, y, (x4 + 200), y, "Level", SubHeadingFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, x6, y, (x6 + 100), y, "Requirement", SubHeadingFont, Brushes.Black)
                y = y + 15
            End If
            y = y + 15
            Dim strValues() As String = Split(arrQualifications.Item(intQualificationsCount), "|")
            'Call DrawStringInBoxLeft(e, x1, y, (x1 + 13), y, "* ", SubHeadingFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y, (x1 + 300), y, strValues(0), fntSmallPrintFontRegular, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x4, y, (x4 + 200), y, strValues(1), fntSmallPrintFontRegular, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x6, y, (x6 + 100), y, strValues(2), fntSmallPrintFontRegular, Brushes.Black)
            intQualificationsCount = intQualificationsCount + 1
            If y > (yBottom - 30) Then
                boolInNextPage = True
                e.HasMorePages = True
                Exit Sub
            End If
        End While


        'Print the Skills and experience
        '
        '*************** Print the Job Skills and experience ***************************************************
        '
        y = y + 30
        While intSkillsExperience < arrSkills.Count
            If intSkillsExperience = 0 Then
                recCurrent = New Rectangle((x1 - 5), (y - 4), e.PageBounds.Right - e.PageBounds.Left - 200, 20)
                sbCurrent = New SolidBrush(Color.Black)
                grdCurrent.FillRectangle(sbCurrent, recCurrent)
                Call gwt_comm.DrawStringInBoxLeft(e, (x1 - 5), y, x4, y, "SKILLS AND EXPERIENCE", titleFont, Brushes.White)
                y = y + 30
                'Print the sub headers for description, level and weighting
                Call gwt_comm.DrawStringInBoxLeft(e, x1, y, (x1 + 300), y, "Skill/Experience", SubHeadingFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, x4, y, (x4 + 200), y, "Period(Mths)", SubHeadingFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, x6, y, (x6 + 100), y, "Requirement", SubHeadingFont, Brushes.Black)
                y = y + 15
            End If
            y = y + 15
            Dim strValues() As String = Split(arrSkills.Item(intSkillsExperience), "|")
            'Call DrawStringInBoxLeft(e, x1, y, (x1 + 13), y, "* ", SubHeadingFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y, (x1 + 300), y, strValues(0), fntSmallPrintFontRegular, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x4, y, (x4 + 200), y, strValues(1), fntSmallPrintFontRegular, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x6, y, (x6 + 100), y, strValues(2), fntSmallPrintFontRegular, Brushes.Black)
            intSkillsExperience = intSkillsExperience + 1
            If y > (yBottom - 30) Then
                boolInNextPage = True
                e.HasMorePages = True
                Exit Sub
            End If
        End While

        'Print the Attributes
        '
        '*************** Print the Job Skills and experience ***************************************************
        '
        y = y + 30
        While intAttributes < arrAttibutes.Count
            If intAttributes = 0 Then
                recCurrent = New Rectangle((x1 - 5), (y - 4), e.PageBounds.Right - e.PageBounds.Left - 200, 20)
                sbCurrent = New SolidBrush(Color.Black)
                grdCurrent.FillRectangle(sbCurrent, recCurrent)
                Call gwt_comm.DrawStringInBoxLeft(e, (x1 - 5), y, x4, y, "DESIRED PERSON ATTRIBUTES", titleFont, Brushes.White)
                y = y + 15
            End If
            y = y + 15
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y, (x1 + 13), y, "* ", SubHeadingFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x1 + 15, y, x5, y, arrAttibutes.Item(intAttributes).ToString, fntSmallPrintFontRegular, Brushes.Black)
            intAttributes = intAttributes + 1
            If y > (yBottom - 30) Then
                boolInNextPage = True
                e.HasMorePages = True
                Exit Sub
            End If
        End While

        'At end print the remarks
        y = y + 30
        recCurrent = New Rectangle((x1 - 5), (y - 4), e.PageBounds.Right - e.PageBounds.Left - 200, 20)
        sbCurrent = New SolidBrush(Color.Black)
        grdCurrent.FillRectangle(sbCurrent, recCurrent)
        Call gwt_comm.DrawStringInBoxLeft(e, (x1 - 5), y, x4, y, "REMARKS", titleFont, Brushes.White)
        y = y + 30
        Call gwt_comm.DrawStringInBoxLeft(e, (x1 - 5), y, x5, y, strRemarks, fntSmallPrintFontRegular, Brushes.Black)

        e.HasMorePages = False

        'Reset the values to handle on print preview printing
        intItemCount = 0
        intQualificationsCount = 0
        intSkillsExperience = 0
        intAttributes = 0
        boolInNextPage = False

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Job Profile Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnNewGrade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGrade.Click
        boolEditStatusTwo = False
        Dim f As New frmGradeSetup
        f.ShowDialog()
        LoadGrades()
    End Sub

    Private Sub expandablePanel1_ExpandedChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles expandablePanel1.ExpandedChanged
        AdjustSplitter()
    End Sub

    Private Sub AdjustSplitter()
        ' Suspend layout changes until all splitter properties have been updated
        splitMain.SuspendLayout()
        expandablePanel1.Dock = DockStyle.None
        'Is the left header group currently expanded?
        If (splitMain.FixedPanel = FixedPanel.None) Then

            'Make the right panel of the splitter fixed in size
            splitMain.FixedPanel = FixedPanel.Panel1
            splitMain.IsSplitterFixed = True

            ' Remember the current height of the header group

            ' We have not changed the orientation of the header yet, so the width of 
            ' the splitter panel is going to be the height of the collapsed header group
            Dim newWidth As Integer = expandablePanel1.Width + 1 'kryptonHeaderGroupLeft.PreferredSize.Width

            ' Make the header group fixed just as the new height
            _originalSplitterDistance = splitMain.SplitterDistance
            splitMain.SplitterDistance = _originalSplitterDistance + (splitMain.Panel2.Width - newWidth) 'splitMain.SplitterDistance + (_widthLeftRight - 32) 'newWidth)
            splitMain.Panel1MinSize = newWidth
        Else

            ' Make the bottom panel not-fixed in size anymore
            splitMain.FixedPanel = FixedPanel.None
            splitMain.IsSplitterFixed = False

            ' Put back the minimise size to the original

            ' Calculate the correct splitter we want to put back
            splitMain.SplitterDistance = _originalSplitterDistance
            expandablePanel1.Dock = DockStyle.Fill

        End If

        splitMain.ResumeLayout()
    End Sub

    Private Sub dgridSkills_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgridSkills.DoubleClick
        If dgridSkills.Rows.Count > 0 Then
            If dgridSkills.SelectedRows.Count > 0 Then
                intSelectedTransaction = CInt(dgridSkills.CurrentRow.Cells(4).Value.ToString)
                strJobCode = dgridSkills.CurrentRow.Cells(0).Value.ToString
                boolEditStatusTwo = True
                Dim f As New frmSkillsEntry
                f.ShowDialog()
                LoadSkills()
            End If
        End If
    End Sub

    Private Sub dgridAttitudes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgridAttitudes.DoubleClick
        If dgridAttitudes.Rows.Count > 0 Then
            'If dGridTasks.Focused = True Then
            intSelectedTransaction = CInt(dgridAttitudes.CurrentRow.Cells(0).Value.ToString)
            strSelectedValue = dgridAttitudes.CurrentRow.Cells(1).Value.ToString
            boolEditStatusTwo = True
            Dim f As New frmAttitudeEntries
            f.ShowDialog()
            LoadAttributes()
            Exit Sub
            'End If
        End If
    End Sub

    Private Sub frmJobProfileSetup_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 691 : Me.Height = 484
    End Sub
End Class
