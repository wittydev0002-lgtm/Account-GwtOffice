Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.IO
Imports System.Text

Public Class frmScholasticaMain

    Dim itm As Double
    Dim boolFormLoading As Boolean
    Dim boolSorting As Boolean
    Dim boolPrintForHandover As Boolean = False
    Dim arrBilledStudentsNumbers As ArrayList
    Dim intPrintCount As Integer
    Dim dblBalanceFromLastTerms As Double = 0
    Dim arrInvoiceDetails As ArrayList
    Dim strCostingCode As String
    Dim intInvoiceNumber As Integer
    Dim arrPayValues As ArrayList

    Dim arrPrintData As ArrayList

    Dim _originalSplitterDistance As Integer

    Dim _originalSplitterDistanceSub As Integer
    Dim _widthLeftRight As Integer
    Dim _CurrentSplitterDistance As Integer
    Dim intPriorSplitterDistance As Integer
    Dim intPriorSplitterDistance2 As Integer

    Dim strStatementArray As ArrayList
    Dim dblCummulativeStatementBalance As Double

    Dim strReportHeader As String

    Dim intLineNumber As Integer
    Dim intLinesMaximum As Integer = 23

    Private Sub frmScholasticaMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'boolAbort = False
        'boolFormLoading = True
        'gwt_comm = New CommonLibrary.Commons.CommonFunctions
        'gwt_comm.UserAuthentication()
        'If boolAbort = True Then Exit Sub

        GetOperationType()
        GetStudentNumberAllocationFormular()
        BilliableSubjectsLimit()
        GetSpecialNotes()

        SideNav1.TabIndex = 0
        Me.Refresh()
        LoadDailyTakings()
        boolSorting = False
        cboGender.SelectedItem = 0
        cboType.SelectedItem = 0
        LoadStudentsData()
        AddTreeNodes(tvClasses)
        AddTreeNodes(tvClasses2)
        LoadOwingsData("ALL", 0, 99999999)

        boolRunningForDisplay = True
        LoadEmployees()
        boolRunningForDisplay = False

        boolFormLoading = False

    End Sub

    Sub LoadEmployees()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strSql As String = "SELECT UPPER(EmployeeNo) AS [Employee #], " _
            & "UPPER(LastName) AS [Last Name], UPPER(FirstName) AS [First Name], UPPER(OtherNames) AS [Other Names], " _
            & "UPPER(IdNumber) AS [ID #], UPPER(Status) AS [Status] FROM EmployeeMaster " _
            & "ORDER BY LastName, FirstName, OtherNames, EmployeeNo"

        dGridSchoolStaff.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridSchoolStaff.DataSource = dTable

        Me.dGridSchoolStaff.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Me.dGridSchoolStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        For p As Integer = 0 To dGridSchoolStaff.Columns.Count - 1
            dGridSchoolStaff.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

        lblTotalSelected.Text = dGridSchoolStaff.Rows.Count

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Details Load error"
        ShowErrorMessage()
    End Sub

    Private Sub GetSelectedEmployeeDetails()
        Dim CurrentCellValue As String
        boolDisallowSave = False
        CurrentCellValue = dGridSchoolStaff.CurrentRow.Cells(0).Value
        strPublicEmployeeId = CurrentCellValue
        'Get the name of the employee for update on the details form
        If Not (Object.Equals(Convert.ToString(dGridSchoolStaff.CurrentRow.Cells(1).Value), "")) Then
            strEmployeeLastName = Convert.ToString(dGridSchoolStaff.CurrentRow.Cells(1).Value)
        End If
        If Not (Object.Equals(Convert.ToString(dGridSchoolStaff.CurrentRow.Cells(2).Value), "")) Then
            strEmployeeFirstName = Convert.ToString(dGridSchoolStaff.CurrentRow.Cells(2).Value)
        End If
        Dim CurrentCellStatus As String = dGridSchoolStaff.CurrentRow.Cells(4).Value
        If UCase(CStr(CurrentCellStatus)) = "INACTIVE" Then
            boolDisallowSave = True
        End If
    End Sub

    Private Sub dGridSchoolStaff_dblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridSchoolStaff.DoubleClick
        If dGridSchoolStaff.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedEmployeeDetails()
            If boolDisallowSave = True Then
                MessageBox.Show("You have accessed a terminated employee. You can only view the record. No changes will be saved",
                    "Terminated Employee Record Assess", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Dim f As New frmEmployeeDetails
            f.ShowDialog()
        End If
    End Sub

    Private Sub AddTreeNodes(myTreeView As TreeView)
        On Error GoTo RaiseErr
        myTreeView.Nodes.Clear()
        Dim strSql As String = "SELECT GroupName FROM SC_ClassGroups ORDER BY GroupName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim node As New TreeNode
            node.Text = objReader(0).ToString
            node.Tag = objReader(0).ToString
            node.ImageIndex = 5
            AddNodes(node)
            myTreeView.Nodes.Add(node)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Classes Load"
        ShowErrorMessage()
    End Sub

    Private Sub AddNodes(ByRef node As TreeNode)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT SC_Classes.ClassName FROM SC_Classes " _
            & "WHERE GroupName = '" & node.Tag & "' ORDER BY ClassName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim nNode As New TreeNode
            nNode.Text = objReader(0).ToString
            nNode.Tag = objReader(0).ToString
            nNode.ImageIndex = 2
            'AddNodes(nNode)
            node.Nodes.Add(nNode)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Classes Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadStudentsData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT UPPER(StudentId) AS [System ID], UPPER(SchoolAllocatedNumber) AS [Student #], " _
            & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
            & "UPPER(Gender) AS [Gender], UPPER(ClassName) AS [Class] FROM SC_Students WHERE Status = 'ACTIVE' ORDER BY FirstName"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGridStudents.Columns.Clear()

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridStudents.DataSource = dTable

        Me.dGridStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGridStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        'For p As Integer = 0 To dGrid.Columns.Count - 1
        '    dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        'Next


        '******** PROCEDURE MADE OBSOLUTE ******
        'LoadFinancials()


        'dGrid.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        lblTotalSelected.Text = dGridStudents.Rows.Count

        dGridStudents.Columns(2).Width = 250
        dGridStudents.Columns(2).MinimumWidth = 200
        dGridStudents.Columns(2).Frozen = True

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Students Load"
        ShowErrorMessage()
    End Sub

    'Private Sub GetSelected()
    '    If Not Object.Equals(dGridStudents.CurrentRow.Cells(0).Value, Nothing) Then
    '        If Not String.IsNullOrEmpty(dGridStudents.CurrentRow.Cells(0).Value.ToString) Then
    '            strSelectedAccount = dGridStudents.CurrentRow.Cells(0).Value.ToString
    '        End If
    '    End If
    'End Sub

    Private Sub btnNewStudent_Click(sender As System.Object, e As System.EventArgs) Handles btnNewStudent.Click
        boolEditStatus = False
        boolModified = False
        Dim frm As New frmStudentsSetup
        frm.ShowDialog()
        If boolModified = True Then LoadStudentsData()
    End Sub

    Private Sub btnEditStudent_Click(sender As System.Object, e As System.EventArgs) Handles btnEditStudent.Click
        If dGridStudents.Rows.Count <= 0 Then Exit Sub
        GetSelectedStudentRecord()
        boolEditStatus = True
        boolModified = False
        Dim frm As New frmStudentsSetup
        frm.ShowDialog()
        If boolModified = True Then LoadStudentsData()
    End Sub

    Private Sub btnDeleteStudent_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteStudent.Click
        If dGridStudents.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to delete this record", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'Get the selected record
            Dim strRecordToDelete As String = Nothing
            If Not Object.Equals(dGridStudents.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridStudents.CurrentRow.Cells(0).Value.ToString) Then
                    strRecordToDelete = dGridStudents.CurrentRow.Cells(0).Value.ToString
                End If
            End If
            If Not String.IsNullOrEmpty(strRecordToDelete) Then
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_StudentTransactions WHERE StudentId = '" & strRecordToDelete & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SC_StudentSubjects WHERE StudentId = '" & strRecordToDelete & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SC_StudentGrades WHERE StudentId = '" & strRecordToDelete & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SC_Guardians WHERE StudentId = '" & strRecordToDelete & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SC_Students WHERE StudentId = '" & strRecordToDelete & "'", cnn)
                objCommand.ExecuteNonQuery()
            End If
            LoadStudentsData()
            MessageBox.Show("Student record deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Students Management"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefreshStudents_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshStudents.Click
        AddTreeNodes(tvClasses)
        AddTreeNodes(tvClasses2)
        lblCurrentClass.Text = "ALL"
        cboGender.SelectedIndex = 0
        cboType.SelectedItem = 0
        LoadStudentsData()
        lblActiveClass.Text = Nothing
    End Sub

    Private Sub PrintStudentsListing()
        On Error GoTo RaiseErr
        Cursor = Cursors.Default

        Dim strCellValues(0 To dGridStudents.ColumnCount - 1) As String
        Dim arrPrintData As New ArrayList

        For p As Integer = 0 To dGridStudents.Rows.Count - 1
            For y As Integer = 0 To strCellValues.Length - 1
                strCellValues(y) = Nothing
            Next
            For n As Integer = 0 To dGridStudents.ColumnCount - 1
                If Not Object.Equals(dGridStudents.Rows(p).Cells(n).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridStudents.Rows(p).Cells(n).Value.ToString) Then
                        strCellValues(n) = dGridStudents.Rows(p).Cells(n).Value.ToString
                    End If
                End If
            Next
            Dim strLineDetails As String = Nothing
            For y As Integer = 0 To strCellValues.Length - 1
                strLineDetails = strLineDetails & strCellValues(y) & ";"
            Next
            strLineDetails = Mid(strLineDetails, 1, (strLineDetails.Length - 1))
            arrPrintData.Add(strLineDetails)
        Next

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        If arrPrintData.Count = 0 Then
            MessageBox.Show("No details to print were obtained from the system", "Printing Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = dGridStudents.ColumnCount
            .strColumnHeaders = "STD #|SCHOOL #|GIVEN NAMES|DOB|DOA|GENDER|CLASS"
            .strColumnAlignments = "0|0|0|0|0|0|0"
            .strColumnWidths = "60|80|200|80|80|60|80"
            .strFooterCaption = UCase("Students Listing")
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "STUDENTS LISTING "
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With

        Dim prnt As New frmPrinterSetup
        prnt.ShowDialog()
        If boolAbort = True Then Exit Sub
        rpt.PrinterSettings.PrinterName = strSessionPrinter

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Students Management"
        ShowErrorMessage()
    End Sub

    Private Sub tvClasses_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvClasses.AfterSelect
        lblCurrentClass.Text = tvClasses.SelectedNode.Text
        lblActiveClass.Text = tvClasses.SelectedNode.Text
        LoadDataBasedOnClases(lblCurrentClass.Text, "ALL", "ALL")
    End Sub

    Private Sub tvClasses2_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvClasses2.AfterSelect
        On Error Resume Next
        lblActiveClassOwings.Text = Nothing
        lblActiveClassOwings.Text = tvClasses2.SelectedNode.Text
        LoadOwingsData(tvClasses2.SelectedNode.Text, txtAmountFrom.Text, txtAmountTo.Text)
    End Sub

    Private Sub LoadDataBasedOnClases(ClassName As String, ByVal Gender As String, sType As String)
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing

        If UCase(ClassName) = "ALL" Then
            If UCase(Gender) = "ALL" Then
                If UCase(sType) = "ALL" Then
                    strSql = "SELECT UPPER(StudentId) AS [System ID], SchoolAllocatedNumber AS [Student #], " _
                                    & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                                    & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                                    & "UPPER(Gender) AS [Gender], UPPER(ClassName) AS [Class] FROM SC_Students WHERE " _
                                    & "Status = 'ACTIVE' ORDER BY ClassName, " _
                                    & "LastName, FirstName, OtherNames"
                Else
                    strSql = "SELECT UPPER(StudentId) AS [System ID], SchoolAllocatedNumber AS [Student #], " _
                                    & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                                    & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                                    & "UPPER(Gender) AS [Gender], UPPER(ClassName) AS [Class] FROM SC_Students WHERE " _
                                    & "Status = 'ACTIVE' AND StudentType = '" & sType & "' ORDER BY ClassName, " _
                                    & "LastName, FirstName, OtherNames"
                End If

            Else
                If UCase(sType) = "ALL" Then
                    strSql = "SELECT UPPER(StudentId) AS [System ID], UPPER(SchoolAllocatedNumber) AS [Student #], " _
                       & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                       & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                       & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                       & "UPPER(Gender) AS [Gender], ClassName AS [Class] FROM SC_Students WHERE " _
                       & "Status = 'ACTIVE' AND Gender = '" & Gender & "' ORDER BY ClassName, " _
                       & "LastName, FirstName, OtherNames"
                Else
                    strSql = "SELECT UPPER(StudentId) AS [System ID], UPPER(SchoolAllocatedNumber) AS [Student #], " _
                        & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                        & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                        & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                        & "UPPER(Gender) AS [Gender], ClassName AS [Class] FROM SC_Students WHERE " _
                        & "Status = 'ACTIVE' AND Gender = '" & Gender & "' AND StudentType = '" & sType & "' ORDER BY ClassName, " _
                        & "LastName, FirstName, OtherNames"
                End If

            End If
        Else
            If UCase(Gender) = "ALL" Then
                If UCase(sType) = "ALL" Then
                    strSql = "SELECT UPPER(StudentId) AS [System ID], UPPER(SchoolAllocatedNumber) AS [Student #], " _
                                    & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                                    & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                                    & "UPPER(Gender) AS [Gender], UPPER(ClassName) AS [Class] FROM SC_Students WHERE " _
                                    & "Status = 'ACTIVE' AND ClassName = '" & ClassName & "' ORDER BY ClassName, " _
                                    & "LastName, FirstName, OtherNames"
                Else
                    strSql = "SELECT UPPER(StudentId) AS [System ID], UPPER(SchoolAllocatedNumber) AS [Student #], " _
                                    & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                                    & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                                    & "UPPER(Gender) AS [Gender], UPPER(ClassName) AS [Class] FROM SC_Students WHERE " _
                                    & "Status = 'ACTIVE' AND ClassName = '" & ClassName & "' AND StudentType = '" & sType & "' ORDER BY ClassName, " _
                                    & "LastName, FirstName, OtherNames"
                End If
            Else
                If UCase(sType) = "ALL" Then
                    strSql = "SELECT UPPER(StudentId) AS [System ID], UPPER(SchoolAllocatedNumber) AS [Student #], " _
                                   & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                                   & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                                   & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                                   & "UPPER(Gender) AS [Gender], UPPER(ClassName) AS [Class] FROM SC_Students WHERE ClassName = '" & ClassName & "' " _
                                   & "AND Status = 'ACTIVE' AND Gender = '" & Gender & "' ORDER BY ClassName, " _
                                   & "LastName, FirstName, OtherNames"
                Else
                    strSql = "SELECT UPPER(StudentId) AS [System ID], UPPER(SchoolAllocatedNumber) AS [Student #], " _
                                    & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                                    & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                                    & "UPPER(Gender) AS [Gender], UPPER(ClassName) AS [Class] FROM SC_Students WHERE ClassName = '" & ClassName & "' " _
                                    & "AND Status = 'ACTIVE' AND Gender = '" & Gender & "' AND StudentType = '" & sType & "' ORDER BY ClassName, " _
                                    & "LastName, FirstName, OtherNames"
                End If

            End If
        End If
        dGridStudents.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridStudents.DataSource = dTable

        Me.dGridStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGridStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        '****** PROCEDURE MADE OBSOLUTE **************
        'LoadFinancials()

        For p As Integer = 0 To dGridStudents.Columns.Count - 1
            dGridStudents.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next

        dGridStudents.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        lblTotalSelected.Text = dGridStudents.Rows.Count

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Students Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub GetSelectedStudentRecord()
        If dGridStudents.Rows.Count > 0 Then
            strSelectedAccountName = dGridStudents.CurrentRow.Cells(2).Value.ToString
            strSchoolNumber = dGridStudents.CurrentRow.Cells(1).Value.ToString
            strSelectedAccount = dGridStudents.CurrentRow.Cells(0).Value.ToString
        End If
    End Sub

    Private Sub txtSearchString_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If chkActiveSearch.Checked = True Then
            If Char.IsLetter(e.KeyChar) Then
                SearchForItem(txtSearchString.Text)
            End If
        Else
            If Asc(e.KeyChar) = 13 Then
                SearchForItem(txtSearchString.Text)
            End If
        End If
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0

        Dim strFind As String = strCurrentKey
        strActiveSearch = strFind

        Cursor = Cursors.WaitCursor

        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        'First Name, Last Name, Student Number
        boolSorting = False
        Select Case cboSearchBy.Text
            Case Is = "First Name"
                strSql = "SELECT UPPER(StudentId) AS [System ID], UPPER(SchoolAllocatedNumber) AS [Student #], " _
                    & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                    & "UPPER(Gender) AS [Gender], UPPER(ClassName) AS [Class] FROM SC_Students WHERE FirstName LIKE '%" & strFind & "%' " _
                    & "AND Status = 'ACTIVE' ORDER BY FirstName"
            Case Is = "Last Name"
                strSql = "SELECT UPPER(StudentId) AS [System ID], UPPER(SchoolAllocatedNumber) AS [Student #], " _
                    & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                    & "UPPER(Gender) AS [Gender], UPPER(ClassName) AS [Class] FROM SC_Students WHERE LastName LIKE '%" & strFind & "%' " _
                    & "AND Status = 'ACTIVE' ORDER BY LastName"
            Case Is = "Student Number"
                strSql = "SELECT UPPER(StudentId) AS [System ID], UPPER(SchoolAllocatedNumber) AS [Student #], " _
                    & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                    & "UPPER(Gender) AS [Gender], UPPER(ClassName) AS [Class] FROM SC_Students WHERE SchoolAllocatedNumber LIKE '%" & strFind & "%' " _
                    & "AND Status = 'ACTIVE' ORDER BY SchoolAllocatedNumber"
            Case Is = "Class"
                strSql = "SELECT UPPER(StudentId) AS [System ID], UPPER(SchoolAllocatedNumber) AS [Student #], " _
                    & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                    & "UPPER(Gender) AS [Gender], UPPER(ClassName) AS [Class] FROM SC_Students WHERE ClassName LIKE '%" & strFind & "%' " _
                    & "AND Status = 'ACTIVE' ORDER BY ClassName, " _
                    & "LastName, FirstName, OtherNames"
            Case "--All--"
                strSql = "SELECT UPPER(StudentId) AS [System ID], UPPER(SchoolAllocatedNumber) AS [Student #], " _
                    & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                    & "UPPER(Gender) AS [Gender], UPPER(ClassName) AS [Class] FROM SC_Students WHERE LastName LIKE '%" & strFind & "%' " _
                    & "ORDER BY LastName, FirstName, OtherNames"
            Case Else
                strSql = "SELECT UPPER(StudentId) AS [System ID], UPPER(SchoolAllocatedNumber) AS [Student #], " _
                    & "UPPER(LastName) +' '+ UPPER(FirstName) +' '+ UPPER(OtherNames) AS [Student Names], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), DateOfBirth, 106), ' ', '-')) as [Birth Date], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), EntryDate, 106), ' ', '-')) as [Entry Date], " _
                    & "UPPER(Gender) AS [Gender], UPPER(ClassName) AS [Class] FROM SC_Students WHERE LastName LIKE '%" & strFind & "%' " _
                    & "AND Status = 'ACTIVE' ORDER BY LastName"
        End Select

        dGridStudents.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridStudents.DataSource = dTable

        Me.dGridStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGridStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        dGridStudents.Columns(2).Width = 250
        dGridStudents.Columns(2).MinimumWidth = 200
        dGridStudents.Columns(2).Frozen = True

        lblTotalSelected.Text = dGridStudents.Rows.Count

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Students Management"
        ShowErrorMessage()
    End Sub

    Private Sub cboGender_Click(sender As System.Object, e As System.EventArgs) Handles cboGender.Click
        If Object.Equals(cboGender.SelectedItem, Nothing) Then cboGender.SelectedIndex = 0
        If Object.Equals(cboType.SelectedItem, Nothing) Then cboType.SelectedIndex = 0
        LoadDataBasedOnClases(lblCurrentClass.Text, cboGender.SelectedItem.ToString, cboType.SelectedItem.ToString)
    End Sub

    Private Sub cboType_Click(sender As System.Object, e As System.EventArgs) Handles cboType.Click
        If Object.Equals(cboGender.SelectedItem, Nothing) Then cboGender.SelectedIndex = 0
        If Object.Equals(cboType.SelectedItem, Nothing) Then cboType.SelectedIndex = 0
        LoadDataBasedOnClases(lblCurrentClass.Text, cboGender.SelectedItem.ToString, cboType.SelectedItem.ToString)
    End Sub

    Private Sub btnNewStaff_Click(sender As System.Object, e As System.EventArgs) Handles btnNewStaff.Click
        boolEditStatus = False
        Dim f As New frmEmployeeDetails
        f.ShowDialog()
        boolRunningForDisplay = True
        LoadEmployees()
        boolRunningForDisplay = False
        boolEditStatus = True
    End Sub

    Private Sub btnEditStaff_Click(sender As System.Object, e As System.EventArgs) Handles btnEditStaff.Click
        If dGridSchoolStaff.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedEmployeeDetails()
            If boolDisallowSave = True Then
                MessageBox.Show("You have accessed a terminated employee. You can only view the record. " _
                    & "No changes will be saved", "Terminated Employee Record Assess", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Dim f As New frmEmployeeDetails
            f.ShowDialog()
            LoadEmployees()
        End If
    End Sub

    Private Sub btnPrintStaffList_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintStaffList.Click
        PrintListing()
    End Sub

    Private Sub PrintListing()
        On Error GoTo RaiseErr
        Cursor = Cursors.Default

        Dim strCellValues(0 To dGridSchoolStaff.ColumnCount - 1) As String
        Dim arrPrintData As New ArrayList

        For p As Integer = 0 To dGridSchoolStaff.Rows.Count - 1
            For y As Integer = 0 To strCellValues.Length - 1
                strCellValues(y) = Nothing
            Next
            For n As Integer = 0 To dGridSchoolStaff.ColumnCount - 1
                If Not Object.Equals(dGridSchoolStaff.Rows(p).Cells(n).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridSchoolStaff.Rows(p).Cells(n).Value.ToString) Then
                        strCellValues(n) = dGridSchoolStaff.Rows(p).Cells(n).Value.ToString
                    End If
                End If
            Next
            Dim strLineDetails As String = Nothing
            For y As Integer = 0 To strCellValues.Length - 1
                strLineDetails = strLineDetails & strCellValues(y) & ";"
            Next
            strLineDetails = Mid(strLineDetails, 1, (strLineDetails.Length - 1))
            arrPrintData.Add(strLineDetails)
        Next

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        If arrPrintData.Count = 0 Then
            MessageBox.Show("No details to print were obtained from the system", "Printing Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        'Employee # LastName, FirstName, OtherNames, ID #, Status
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "EC #|SURNAME|NAME|OTHER NAMES|ID NUMBER|STATUS"
            .strColumnAlignments = "0|0|0|0|0|0"
            .strColumnWidths = "70|120|120|100|80|80"
            .strFooterCaption = UCase("Teaching Staff Listing " & Format(EndDate, "dd-MMM-yyyy"))
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "TEACHING STAFF LISTING "
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With

        Dim prnt As New frmPrinterSetup
        prnt.ShowDialog()
        If boolAbort = True Then Exit Sub
        rpt.PrinterSettings.PrinterName = strSessionPrinter

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Teachers Listing Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefreshStaff_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshStaff.Click
        boolRunningForDisplay = True
        LoadEmployees()
        boolRunningForDisplay = False
    End Sub

    Private Sub btnAmtFilter_Click(sender As System.Object, e As System.EventArgs) Handles btnAmtFilter.Click
        If Not IsNumeric(txtAmountFrom.Text) Then txtAmountFrom.Text = 0
        If Not IsNumeric(txtAmountTo.Text) Then txtAmountTo.Text = 0
        LoadOwingsData("ALL", CDbl(txtAmountFrom.Text), CDbl(txtAmountTo.Text))
    End Sub

    Private Sub ComputeOwingsTotals()
        On Error GoTo RaiseErr

        Dim dblBalance As Double = 0
        For p As Integer = 0 To dGridOwings.RowCount - 1
            If Not Object.Equals(dGridOwings.Rows(p).Cells(dGridOwings.ColumnCount - 1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridOwings.Rows(p).Cells(dGridOwings.ColumnCount - 1).Value.ToString) Then
                    If IsNumeric(dGridOwings.Rows(p).Cells(dGridOwings.ColumnCount - 1).Value.ToString) Then
                        dblBalance = dblBalance + CDbl(dGridOwings.Rows(p).Cells(dGridOwings.ColumnCount - 1).Value.ToString)
                    End If
                End If
            End If
        Next
        lblTotalOwings.Text = Format(dblBalance, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.WaitCursor
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On students with balances load"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintListOwings_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintListOwings.Click
        boolPrintForHandover = False
        PrintBalancesListing()
    End Sub

    Private Sub PrintBalancesListing()
        On Error GoTo RaiseErr
        Cursor = Cursors.Default

        Dim strCellValues(0 To dGridOwings.ColumnCount - 1) As String
        Dim arrPrintData As New ArrayList

        For p As Integer = 0 To dGridOwings.Rows.Count - 1
            For y As Integer = 0 To strCellValues.Length - 1
                strCellValues(y) = Nothing
            Next
            Dim strParentDetails As String = Nothing
            For n As Integer = 0 To dGridOwings.ColumnCount - 1
                If Not Object.Equals(dGridOwings.Rows(p).Cells(n).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridOwings.Rows(p).Cells(n).Value.ToString) Then
                        strCellValues(n) = dGridOwings.Rows(p).Cells(n).Value.ToString
                        If n = 0 Then
                            If boolPrintForHandover = True Then
                                strParentDetails = GetParentDetails(strCellValues(n))
                            End If
                            If UCase(strCellValues(n)) <> UCase(GetSchoolAllocatedNumber(strCellValues(n))) Then
                                strCellValues(n) = GetSchoolAllocatedNumber(strCellValues(n))
                            End If
                        End If
                        If n = 1 Then
                            If boolPrintForHandover = True Then
                                strCellValues(n) = strCellValues(n) & vbCrLf & strParentDetails
                            End If
                        End If
                    End If
                End If
            Next
            Dim strLineDetails As String = Nothing
            For y As Integer = 0 To strCellValues.Length - 1
                strLineDetails = strLineDetails & strCellValues(y) & ";"
            Next
            strLineDetails = Mid(strLineDetails, 1, (strLineDetails.Length - 1))
            arrPrintData.Add(strLineDetails)
        Next

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        If arrPrintData.Count = 0 Then
            MessageBox.Show("No details to print were obtained from the system", "Printing Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = dGridOwings.ColumnCount
            .strColumnHeaders = "STD #|GIVEN NAMES|CLASS|PHONE|INVOICED|PAID|BALANCE"
            .strColumnAlignments = "0|0|0|0|2|2|2"
            .strColumnWidths = "80|180|100|60|70|70|70"
            .strFooterCaption = UCase("Outstanding Students Balances Listing as at " & Format(EndDate, "dd-MMM-yyyy"))
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "OUTSTANDING BALANCE LISTING "
            If boolPrintForHandover = True Then
                .strMainHeader3 = "BALANCES TO BE HANDED OVER"
            Else
                .strMainHeader3 = ""
            End If
            .strColumnTotals = "NO|NO|NO|NO|YES|YES|YES"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|YES|YES|YES"
            .strSummaryTotals = "NO|NO|NO|NO|YES|YES|YES"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With

        Dim prnt As New frmPrinterSetup
        prnt.ShowDialog()
        If boolAbort = True Then Exit Sub
        rpt.PrinterSettings.PrinterName = strSessionPrinter

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Outstanding Balances Listing"
        ShowErrorMessage()
    End Sub

    Private Function GetSchoolAllocatedNumber(ByVal StudentNumber As String) As String
        Dim strRetun As String = StudentNumber
        Dim strSql As String = "SELECT SchoolAllocatedNumber FROM SC_Students WHERE StudentId = '" & StudentNumber & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    strRetun = objReader(0).ToString
                End If
            End If
        End If
        objReader.Close()
        Return strRetun
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On school allocated student number fetch"
        ShowErrorMessage()
    End Function

    Private Function GetParentDetails(ByVal StudentNumber As String) As String
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT GivenNames, Address1, Address2, Address3, " _
            & "Address4, Cellphone, Telephone FROM SC_Guardians WHERE StudentId = '" & StudentNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    strReturn = strReturn & objReader(0).ToString & vbCrLf
                End If
            End If
            If Not IsDBNull(objReader(1).ToString) Then
                If Not String.IsNullOrEmpty(objReader(1).ToString) Then
                    strReturn = strReturn & objReader(1).ToString & vbCrLf
                End If
            End If
            If Not IsDBNull(objReader(2).ToString) Then
                If Not String.IsNullOrEmpty(objReader(2).ToString) Then
                    strReturn = strReturn & objReader(2).ToString & vbCrLf
                End If
            End If
            If Not IsDBNull(objReader(3).ToString) Then
                If Not String.IsNullOrEmpty(objReader(3).ToString) Then
                    strReturn = strReturn & objReader(3).ToString & vbCrLf
                End If
            End If
            If Not IsDBNull(objReader(4).ToString) Then
                If Not String.IsNullOrEmpty(objReader(4).ToString) Then
                    strReturn = strReturn & objReader(4).ToString & vbCrLf
                End If
            End If
            If Not IsDBNull(objReader(5).ToString) Then
                If Not String.IsNullOrEmpty(objReader(5).ToString) Then
                    strReturn = strReturn & objReader(5).ToString
                End If
            End If
            If Not IsDBNull(objReader(6).ToString) Then
                If Not String.IsNullOrEmpty(objReader(6).ToString) Then
                    strReturn = strReturn & "\" & objReader(6).ToString & vbCrLf
                End If
            End If
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On parent details fetch"
        ShowErrorMessage()
    End Function

    Private Sub btnPrintForHandOver_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintForHandOver.Click
        boolPrintForHandover = True
        PrintBalancesListing()
    End Sub

    Private Sub btnPrintInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintInvoice.Click
        If dGridOwings.RowCount <= 0 Then Exit Sub
        boolAbort = False
        Dim frm As New FrmBilling
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        On Error GoTo RaiseErr
        arrBilledStudentsNumbers = New ArrayList

        For p As Integer = 0 To dGridOwings.Rows.Count - 1
            If dGridOwings.Rows(p).Cells(0).Value = True Then
                arrBilledStudentsNumbers.Add(dGridOwings.Rows(p).Cells(1).Value.ToString)
            End If
        Next

        itm = 0 : intPrintCount = arrBilledStudentsNumbers.Count
        Dim ppd As New PrintPreviewDialog
        ppd.Document = pdoc
        ppd.ShowDialog()

        LoadOwingsData(tvClasses2.SelectedNode.Text, txtAmountFrom.Text, txtAmountTo.Text)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Students Term Billing Invoice Printing"
        ShowErrorMessage()
    End Sub

    Private Sub pdoc_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoc.PrintPage

        While itm < arrBilledStudentsNumbers.Count

            'Print the school logo
            Dim intPictureWidth As Integer
            Dim intPictureHeight As Integer

            If Not String.IsNullOrEmpty(strLogoPath) Then
                If System.IO.File.Exists(strLogoPath) Then
                    'Dont print the company name as it is taken care of by the logo
                    'strCompanyName = ""
                    Dim R As Drawing.Rectangle
                    Dim objPicture As New Windows.Forms.PictureBox
                    objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                    objPicture.Load(strLogoPath)
                    Dim intImageYLocation As Double = objPicture.Height
                    intImageYLocation = (100 - intImageYLocation) / 2
                    R = New Rectangle(intLogoXposition, intLogoYposition, objPicture.Width, objPicture.Height)
                    e.Graphics.DrawImage(objPicture.Image, R)
                    intPictureWidth = objPicture.Width
                    intPictureHeight = objPicture.Height
                End If
            End If

            'Print the company information here
            Dim y1 As Integer = intLogoYposition
            Dim x1 As Integer = intLogoXposition + intPictureWidth + 10

            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 500, 80, strCompanyName, fntHeaderFont, Brushes.Black)
            y1 = y1 + 20
            If Not String.IsNullOrEmpty(strCompanyAddress1) Then
                Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 250, 80, strCompanyAddress1, fntDetailsFont, Brushes.Black)
                y1 = y1 + 15
            End If
            If Not String.IsNullOrEmpty(strCompanyAddress2) Then
                Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 250, 80, strCompanyAddress2, fntDetailsFont, Brushes.Black)
                y1 = y1 + 15
            End If

            If Not String.IsNullOrEmpty(strCompanyAddress3) Then
                Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 250, 80, strCompanyAddress3, fntDetailsFont, Brushes.Black)
                y1 = y1 + 15
            End If
            If Not String.IsNullOrEmpty(strCompanyAddress4) Then
                Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 250, 80, strCompanyAddress4, fntDetailsFont, Brushes.Black)
                y1 = y1 + 15
            End If
            If Not String.IsNullOrEmpty(strCompanyTelephone) Then
                Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 250, 80, "PHONE  : " & UCase(strCompanyTelephone), fntDetailsFont, Brushes.Black)
                y1 = y1 + 15
            End If

            'Print the student information

            'Print the Year and term information
            'Print the document information : Invoice number, date of printing, due date

            'Print balance from previous term
            'Current billing
            'Total balance due

            'Special information

            Dim intY As Integer = y1 'intLogoYposition
            Dim intX As Integer = 100


            Dim strSurname As String = Nothing
            Dim strGivenNames As String = Nothing
            Dim strStudentNumber As String = UCase(arrBilledStudentsNumbers.Item(itm))
            Dim strClass As String = Nothing

            '*************** GET THE SELECTED STUDENT DETAILS ****************

            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ClassName, LastName, " _
                & "FirstName +' '+ OtherNames AS [GivenNames], SchoolAllocatedNumber " _
                & "FROM SC_Students WHERE StudentId = '" & arrBilledStudentsNumbers.Item(itm) & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then strClass = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then strSurname = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then strGivenNames = Trim(objReader(2).ToString)
                If Not IsDBNull(objReader(3).ToString) Then
                    If Not String.IsNullOrEmpty(objReader(3).ToString) Then
                        If UCase(objReader(3).ToString) <> UCase(strStudentNumber) Then
                            strStudentNumber = UCase(objReader(3).ToString)
                        End If
                    End If
                End If
            End If
            objReader.Close()

            'Get the past balance

            dblBalanceFromLastTerms = AccountBalance(arrBilledStudentsNumbers.Item(itm))
            Dim dblCurrentTotal As Double = GetStudentTermFee(strClass)

            'dblBalanceFromLastTerms = dblBalanceFromLastTerms - dblCurrentTotal

            'Draw a line thereafter
            'e.Graphics.DrawLine(Pens.Black, intX, intY, intX + 600, intY)
            'intY = intY + 15

            Call gwt_comm.DrawStringInBoxCenter(e, intX, intY, intX + 500, intY, "FEES INVOICE", fntHeaderFont, Brushes.Black)
            intY = intY + 25
            e.Graphics.DrawLine(Pens.Black, intX, intY, intX + 600, intY)
            intY = intY + 25 'This is the point where we started drawing the boxes
            Dim intYboxStart As Integer = intY

            'Draw the main student box
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX, intY + 1, 300, 130))
            intY = intY + 20
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 10, intY, intX + 300, 175, "STUDENT DETAILS", fntHeaderFont, Brushes.Black)
            intY = intY + 20
            e.Graphics.DrawLine(Pens.Black, intX, intY, intX + 300, intY)
            intY = intY + 5
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 10, intY, intX + 100, 200, "Surname", fntDetailsFontBold, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 110, intY, intX + 200, 200, UCase(strSurname), fntDetailsFont, Brushes.Black)
            intY = intY + 20
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 10, intY, intX + 100, 220, "Given Names", fntDetailsFontBold, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 110, intY, intX + 200, 220, UCase(strGivenNames), fntDetailsFont, Brushes.Black)
            intY = intY + 20
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 10, intY, intX + 100, 240, "Class", fntDetailsFontBold, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 110, intY, intX + 200, 240, UCase(strClass), fntDetailsFont, Brushes.Black)
            intY = intY + 20
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 10, intY, intX + 100, 260, "Student ID", fntDetailsFontBold, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 110, intY, intX + 200, 260, UCase(strStudentNumber), fntDetailsFont, Brushes.Black)

            'e.Graphics.DrawRectangle(Pens.Navy, intX, intY, intX + 250, intY + 150)
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX + 400, intYboxStart, 200, 30))
            'Write the letters
            'e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX + 402, intYboxStart + 2, 50, 26))
            intYboxStart = intYboxStart + 5
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 405, intYboxStart, intX + 600, 173, "Year", fntHeaderFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 455, intYboxStart, intX + 600, 173, UCase(intInvoiceYear), fntHeaderFont, Brushes.Black)
            'e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX + 500, intYboxStart - 1, 50, 26))
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 505, intYboxStart, intX + 600, 173, "Term", fntHeaderFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 555, intYboxStart, intX + 600, 173, UCase(strSelectedTerm), fntHeaderFont, Brushes.Black)

            'Print the docment number box
            Dim strInvoiveNumber As String = Format(DatePart(DateInterval.Year, Now), "0000") &
                "-" & strSelectedTerm & "-" & Format((itm + 1), "00000")
            intYboxStart = intYboxStart + 30
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX + 400, intYboxStart, 200, 30))
            'e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX + 401, intYboxStart + 1, 100, 27))
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 405, intYboxStart + 5, intX + 600, 205, "Invoice No.", fntHeaderFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 505, intYboxStart + 10, intX + 600, 210, strInvoiveNumber, fntDetailsFont, Brushes.Black)

            'Print the due date box
            intYboxStart = intYboxStart + 25
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX + 400, intYboxStart, 200, 30))
            'e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX + 401, intYboxStart + 1, 100, 27))
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 405, intYboxStart + 5, intX + 600, 240, "Due Date", fntHeaderFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 505, intYboxStart + 10, intX + 600, 245, UCase(Format(dpDueDateSelected, "dd-MMM-yyyy")), fntDetailsFont, Brushes.Black)

            intYboxStart = intYboxStart + 80
            Call gwt_comm.DrawStringInBoxLeft(e, intX, intYboxStart, intX + 600, 240, UCase("Balance brought forward from previous terms : ") &
                UCase(Format(dblBalanceFromLastTerms, "#,##0.00")), fntDetailsFont, Brushes.Black)

            'Print the details header
            intYboxStart = intYboxStart + 25
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX, intYboxStart, 600, 30))
            e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX, intYboxStart + 2, 600, 27))
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 2, intYboxStart + 5, intX + 600, 205, UCase("Description"), fntHeaderFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 505, intYboxStart + 10, intX + 600, 210, UCase("Amount"), fntHeaderFont, Brushes.Black)

            'Start printing the breakdown here

            intY = intYboxStart + 40

            For p As Integer = 0 To arrInvoiceDetails.Count - 1
                'Write the details here
                Dim strBuffer() As String = Split(arrInvoiceDetails.Item(p), "|")
                Call gwt_comm.DrawStringInBoxLeft(e, intX + 2, intY, intX + 400, 80, strBuffer(0), fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, intX + 505, intY, 80, 80,
                    Format(CDbl(strBuffer(1)), "#,##0.00"), fntDetailsFont, Brushes.Black)
                'dblCurrentTotal = dblCurrentTotal + CDbl(strBuffer(0))
                intY = intY + 15
            Next

            intY = intY + 20
            Dim intYnoteStart As Integer = intY

            'Print the final balance total here 
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX + 400, intY, 200, 30))
            e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX + 401, intY + 1, 100, 27))
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 405, intY + 5, intX + 600, 240, "Current Total", fntHeaderFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, intX + 505, intY + 10, 80, 80, Format(dblCurrentTotal, "#,##0.00"), fntDetailsFont, Brushes.Black)

            intY = intY + 35
            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX + 400, intY, 200, 30))
            e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX + 401, intY + 1, 100, 27))
            Call gwt_comm.DrawStringInBoxLeft(e, intX + 405, intY + 5, intX + 600, 240, "Balance Due", fntHeaderFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, intX + 505, intY + 10, 80, 80,
                Format((dblBalanceFromLastTerms + dblCurrentTotal), "#,##0.00"), fntDetailsFont, Brushes.Black)

            'Update the student transactions
            UpdateCurrentStudentBill(arrBilledStudentsNumbers.Item(itm), dblCurrentTotal)


            If Not String.IsNullOrEmpty(strPublicNotePriority) Then
                e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX, intYnoteStart + 1, 300, 65))
                'intY = intY + 35
                Call gwt_comm.DrawStringInBoxLeft(e, intX + 2, intYnoteStart + 8, 300, 130, strPublicNotePriority, fntDetailsFont, Brushes.Black)
            End If

            'If itm >= (intPrintCount - 1) Then
            '    e.HasMorePages = False
            '    itm = 0
            'Else
            '    e.HasMorePages = True
            '    itm = itm + 1
            'End If

            itm = itm + 1
            e.HasMorePages = True

            Exit Sub

        End While

        e.HasMorePages = False

    End Sub

    Private Sub dGridOwings_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dGridOwings.CellMouseDown
        If e.Button = MouseButtons.Right Then
            ' Add this
            dGridOwings.CurrentCell = dGridOwings.Rows(e.RowIndex).Cells(e.ColumnIndex)
            ' Can leave these here - doesn't hurt
            dGridOwings.Rows(e.RowIndex).Selected = True
            dGridOwings.Focus()
        End If

    End Sub

    Private Sub UpdateCurrentStudentBill(StudentId As Integer, Amount As Double)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Debit, " _
            & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & StudentId & "', " _
            & "'TERM BILLING', '', " & Amount & ", '" & strPublicActiveFullUserName & "', " _
            & "'" & Format(dtSetDate, "dd-MMM-yyyy") & "', 'TERM BILLING', 'TERM " & strSelectedTerm & "', " & intInvoiceYear & ")"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On student bills update"
        ShowErrorMessage()
    End Sub
    Private Function GetStudentTermFee(ClassName As String) As Double
        On Error GoTo RaiseErr
        Dim dblReturn As Double = 0
        strCostingCode = Nothing
        Dim strSql As String = "SELECT CostCenter FROM SC_Classes WHERE ClassName = '" & ClassName & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strCostingCode = objReader(0).ToString
        End If
        objReader.Close()

        'Get the actual cost here. Also assign the payment descriptions for use in the invoice print
        arrInvoiceDetails = New ArrayList

        If Not String.IsNullOrEmpty(strCostingCode) Then
            strSql = "SELECT SUM(SC_PaymentDescriptionAmts.Amount) AS [Amt] FROM SC_PaymentDescriptionAmts " _
                & "WHERE SC_PaymentDescriptionAmts.CostCode = '" & strCostingCode & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader
            While objReader.Read
                If IsNumeric(objReader(0).ToString) Then
                    dblReturn = dblReturn + CDbl(objReader(0).ToString)
                End If
            End While
            objReader.Close()
        End If

        arrInvoiceDetails = InvoiceBreakDown(dblReturn, strCostingCode)

        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Students Term Billing"
        ShowErrorMessage()
    End Function

    Private Function InvoiceBreakDown(Amount As Double, CostCenter As String) As ArrayList
        Dim arrReturn As New ArrayList
        Dim strSql As String = "SELECT Description, Rate FROM SC_PaymentDescription2 " _
            & "WHERE CostCenter = '" & CostCenter & "' AND Type = 'RECURRING'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim dblAmount As Double = 0
            Dim strDescription As String = Nothing
            If Not IsDBNull(objReader(1).ToString) Then
                If IsNumeric(objReader(1).ToString) Then
                    dblAmount = (CDbl(objReader(1).ToString) / 100) * Amount
                End If
            End If
            If Not IsDBNull(objReader(0).ToString) Then
                strDescription = objReader(0).ToString
            End If
            arrReturn.Add(UCase(strDescription) & "|" & CStr(Format(dblAmount, "##0.00")))
        End While
        objReader.Close()

        Return arrReturn
    End Function

    Private Sub btnRefreshOwings_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshOwings.Click
        lblActiveClassOwings.Text = Nothing
        LoadOwingsData("ALL", 0, 99999999)
    End Sub

    Private Sub LoadOwingsData(ByVal LoadMethod As String, ByVal StartingBalance As Double, ByVal endingBalance As Double)
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        strSql = "IF OBJECT_ID(N'Temp_Balances', N'U')  IS NOT NULL DROP TABLE Temp_Balances"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        If UCase(LoadMethod) = "ALL" Then
            strSql = "SELECT SC_Students.StudentId, " _
                & "UPPER(SC_Students.LastName) +' '+ UPPER(SC_Students.FirstName) AS [Student Names], " _
                & "UPPER(SC_Students.ClassName) AS [Class], UPPER(SC_Students.ContactTelephone) AS [Phone], " _
                & "SUM(SC_StudentTransactions.Debit) AS [Invoiced], SUM(SC_StudentTransactions.Credit) AS [Paid], " _
                & "SUM(SC_StudentTransactions.Debit - SC_StudentTransactions.Credit) AS [Balance] " _
                & "INTO Temp_Balances FROM SC_Students LEFT OUTER JOIN SC_StudentTransactions ON " _
                & "SC_Students.StudentId = SC_StudentTransactions.StudentId " _
                & "GROUP BY SC_Students.StudentId, SC_Students.LastName, " _
                & "SC_Students.FirstName, SC_Students.ClassName, SC_Students.ContactTelephone " _
                & "ORDER BY SC_Students.ClassName, SC_Students.LastName, SC_Students.FirstName"
        Else
            strSql = "SELECT SC_Students.StudentId, " _
                & "UPPER(SC_Students.LastName) +' '+ UPPER(SC_Students.FirstName) AS [Student Names], " _
                & "UPPER(SC_Students.ClassName) AS [Class], UPPER(SC_Students.ContactTelephone) AS [Phone], " _
                & "SUM(SC_StudentTransactions.Debit) AS [Invoiced], SUM(SC_StudentTransactions.Credit) AS [Paid], " _
                & "SUM(SC_StudentTransactions.Debit - SC_StudentTransactions.Credit) AS [Balance] " _
                & "INTO Temp_Balances FROM SC_Students LEFT OUTER JOIN SC_StudentTransactions " _
                & "ON SC_Students.StudentId = SC_StudentTransactions.StudentId " _
                & "WHERE SC_Students.ClassName = '" & LoadMethod & "' " _
                & "GROUP BY SC_Students.StudentId, SC_Students.LastName, " _
                & "SC_Students.FirstName, SC_Students.ClassName, SC_Students.ContactTelephone " _
                & "ORDER BY SC_Students.ClassName, SC_Students.LastName, SC_Students.FirstName"
        End If

        'cut sql statement after where
        '(SC_StudentTransactions.Debit - SC_StudentTransactions.Credit) <> 0 AND 

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "SELECT StudentId as [Student #], [Student Names], Class, Phone, " _
            & "ISNULL(Invoiced, 0) AS [Invoiced], ISNULL(Paid, 0) AS [Paid], " _
            & "ISNULL(Balance, 0) AS [Balance] FROM Temp_Balances"
        'WHERE Balance BETWEEN " & StartingBalance & " And " & endingBalance & ""

        dGridOwings.SuspendLayout()
        dGridOwings.Columns.Clear()
        Me.dGridOwings.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridOwings.DataSource = dTable
        'dGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dGridOwings.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dGridOwings.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dGridOwings.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dGridOwings.Columns(4).DefaultCellStyle.Format = "N2"
        dGridOwings.Columns(5).DefaultCellStyle.Format = "N2"
        dGridOwings.Columns(6).DefaultCellStyle.Format = "N2"

        lblTotalRecords.Text = dGridOwings.RowCount
        dGridOwings.ResumeLayout()
        ComputeOwingsTotals()

        'add checkbox
        Dim crm As New DataGridViewCheckBoxColumn
        With crm
            .Width = 25
            .HeaderText = ""
        End With
        dGridOwings.Columns.Insert(0, crm)
        dGridOwings.Columns(0).ReadOnly = False
        dGridOwings.Columns(2).Frozen = True

        For p As Integer = 0 To dGridOwings.Columns.Count - 1
            If p = 0 Then
                dGridOwings.Columns(p).ReadOnly = False
            Else
                dGridOwings.Columns(p).ReadOnly = True
            End If
        Next
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.WaitCursor
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On students with balances load"
        ShowErrorMessage()
    End Sub

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        DailyTakingsReport(dpStartFrom.Value, dpEndTo.Value)
        lblReceiptTotalSelected.Text = dGridReceipts.Rows.Count - 1
    End Sub

    Private Sub DailyTakingsReport(dtStart As Date, dtEnd As Date)
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), " _
            & "SC_StudentTransactions.TransactionDate, 106), ' ', '-')) as [Date], " _
            & "SC_StudentTransactions.ReceiptNo, SC_StudentTransactions.StudentId, " _
            & "SC_Students.LastName +' '+ SC_Students.FirstName +' '+ SC_Students.OtherNames AS [Student Names], " _
            & "CAST(SUM(SC_StudentTransactions.Credit) AS DECIMAL (10,2)) AS [Amount] " _
            & "FROM SC_StudentTransactions LEFT OUTER JOIN SC_Students ON SC_StudentTransactions.StudentId = SC_Students.StudentId " _
            & "WHERE SC_StudentTransactions.TransactionDate BETWEEN '" & Format(dtStart, "dd-MMM-yyyy") & "' " _
            & "AND '" & Format(dtEnd, "dd-MMM-yyyy") & "' " _
            & "GROUP BY SC_StudentTransactions.TransactionDate, SC_Students.LastName, " _
            & "SC_Students.FirstName, SC_Students.OtherNames, SC_StudentTransactions.ReceiptNo, " _
            & "SC_StudentTransactions.StudentId ORDER BY SC_StudentTransactions.ReceiptNo "

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        dGridReceipts.Rows.Clear()

        ''Get the count of the items here
        'objCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(DISTINCT(SC_StudentTransactions.ReceiptNo)) " _
        '    & "FROM SC_StudentTransactions WHERE SC_StudentTransactions.TransactionDate BETWEEN '" & Format(dtStart, "dd-MMM-yyyy") & "' " _
        '    & "AND '" & Format(dtEnd, "dd-MMM-yyyy") & "'", cnn)
        'Dim objCount As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        'Dim intRows As Integer = 0
        'If objCount.HasRows Then
        '    objCount.Read()
        '    If IsNumeric(objCount(0).ToString) Then
        '        intRows = CInt(objCount(0).ToString) + 20
        '    End If
        'End If
        'objCount.Close()

        Dim dblTotals As Double = 0

        'Me.ProgressBar1.Value = 0
        'Me.ProgressBar1.Maximum = intRows

        While objReader.Read
            With dGridReceipts
                .Rows.Add(UCase(objReader(0)), UCase(objReader(1)), UCase(objReader(2)), UCase(objReader(3)), UCase(objReader(4)))
                If IsNumeric(objReader(4).ToString) Then
                    dblTotals = dblTotals + CDbl(objReader(4).ToString)
                End If
                'Get the details and populate below
                For j As Integer = 0 To arrPayValues.Count - 1
                    If Not IsDBNull(objReader(1).ToString) Then
                        objCommand = New Data.OleDb.OleDbCommand("SELECT SC_StudentTransactions.Description, " _
                            & "CAST(SC_StudentTransactions.Credit AS DECIMAL (10,2)) AS [Amount] FROM " _
                            & "SC_StudentTransactions WHERE ReceiptNo = " & objReader(1).ToString & " AND " _
                            & "SC_StudentTransactions.StudentId = '" & objReader(2).ToString & "' AND " _
                            & "SC_StudentTransactions.Description = '" & arrPayValues.Item(j) & "'", cnn)
                        Dim objReadDetails As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                        While objReadDetails.Read
                            .Rows(.Rows.Count - 1).Cells(j + 5).Value = objReadDetails(1).ToString
                        End While
                        objReadDetails.Close()
                    End If
                Next
            End With
            'Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1
        End While
        objReader.Close()
        lblAllReceiptAmt.Text = Format(dblTotals, "#,##0.00")

        'Me.ProgressBar1.Value = Me.ProgressBar1.Maximum

        'Add the totals line
        dGridReceipts.Rows.Add(1)
        For k As Integer = 4 To dGridReceipts.Columns.Count - 1
            Dim dblColumnTotal As Double = 0
            For h As Integer = 0 To dGridReceipts.Rows.Count - 1
                If Not Object.Equals(dGridReceipts.Rows(h).Cells(k).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridReceipts.Rows(h).Cells(k).Value.ToString) Then
                        If IsNumeric(dGridReceipts.Rows(h).Cells(k).Value.ToString) Then
                            dblColumnTotal = dblColumnTotal + CDbl(dGridReceipts.Rows(h).Cells(k).Value.ToString)
                        End If
                    End If
                End If
            Next
            dGridReceipts.Rows(dGridReceipts.Rows.Count - 1).Cells(k).Value = Format(dblColumnTotal, "##0.00")
        Next

        For p As Integer = 0 To dGridReceipts.Columns.Count - 1
            dGridReceipts.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p > 3 Then
                dGridReceipts.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Report Generation"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintReceiptDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintReceiptDetails.Click
        On Error GoTo RaiseErr
        gwt_comm.PrintDataGrid(dGridReceipts, "Daily Takings for the period : " &
            UCase(Format(dpStartFrom.Value, "dd-MM-yy")) & " TO " & UCase(Format(dpEndTo.Value, "dd-MM-yy")))
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Daily Takings Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnReceiptDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnReceiptDetails.Click
        If dGridReceipts.Rows.Count <= 0 Then Exit Sub
        If Not Object.Equals(dGridReceipts.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridReceipts.CurrentRow.Cells(0).Value.ToString) Then
                strSelectedDate = dGridReceipts.CurrentRow.Cells(0).Value.ToString
            End If
        End If
        If Not Object.Equals(dGridReceipts.CurrentRow.Cells(1).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridReceipts.CurrentRow.Cells(1).Value.ToString) Then
                If IsNumeric(dGridReceipts.CurrentRow.Cells(1).Value.ToString) Then
                    intSelectedReceipt = CInt(dGridReceipts.CurrentRow.Cells(1).Value.ToString)
                End If
            End If
        End If
        Dim frm As New frmReceiptDetails
        frm.ShowDialog()
        DailyTakingsReport(dpStartFrom.Value, dpEndTo.Value)
    End Sub

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

    'Private Sub mnuReceiptStudent_Click(sender As System.Object, e As System.EventArgs) Handles mnuReceiptStudent.Click
    '    ReceiptStudent()
    'End Sub

    'Private Sub ReceiptStudent()
    '    strTransferType = "Credit"
    '    GetSelectedStudentRecord()
    '    Dim frm As New frmFeesPayments ' frmStudentTransactionsEntry
    '    frm.ShowDialog()

    'End Sub
    Private Sub TerminateStudent()
        GetSelectedStudentRecord()
        Dim frm As New frmTerminateStudent
        frm.ShowDialog()
    End Sub

    Private Sub btnTerminateSelectedStudent_Click(sender As System.Object, e As System.EventArgs) Handles btnTerminateSelectedStudent.Click
        TerminateStudent()
    End Sub

    Private Sub PrintSelectedStudentStatement()
        If dGridStudents.Rows.Count <= 0 Then Exit Sub
        boolAbort = False
        Dim f As New frmDateSpecifier
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        strSelectedAccount = dGridStudents.CurrentRow.Cells(0).Value.ToString
        LoadStatementFinancials(strSelectedAccount)
        PrintStudentStatement()
    End Sub

    Private Sub btnPrintSelectedStudentStatement_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSelectedStudentStatement.Click
        PrintSelectedStudentStatement()
    End Sub

    Private Sub PrintStudentStatement()

        On Error GoTo RaiseErr

        strStatementArray = New ArrayList

        dblCummulativeStatementBalance = 0

        'Get the balance brought forwd
        For i As Integer = 0 To dGridStatements.Rows.Count - 1

            Dim dblDr As Double = 0
            Dim dblCr As Double = 0
            Dim strDt As String = Nothing

            If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(0).Value), "")) Then
                strDt = dGridStatements.Rows(i).Cells(0).Value.ToString
            End If

            If CDate(strDt) < StartDate Then
                'If CDate(strDt) <= EndDate Then
                If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(3).Value), "")) Then
                    If IsNumeric(dGridStatements.Rows(i).Cells(3).Value.ToString) Then
                        dblDr = CDbl(dGridStatements.Rows(i).Cells(3).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(4).Value), "")) Then
                    If IsNumeric(dGridStatements.Rows(i).Cells(4).Value.ToString) Then
                        dblCr = CDbl(dGridStatements.Rows(i).Cells(4).Value.ToString)
                    End If
                End If
                dblCummulativeStatementBalance = dblCummulativeStatementBalance + (dblDr - dblCr)
                'End If
            End If

        Next

        strStatementArray.Add(UCase(Format(StartDate, "dd-MMM-yyyy")) & "|" & UCase("Balance brought forward") & "| | | | |" & Format(dblCummulativeStatementBalance, "#,##0.00"))
        Dim dblBalance As Double = dblCummulativeStatementBalance

        For i As Integer = 0 To dGridStatements.Rows.Count - 1
            Dim strDate As String = Nothing
            Dim strReference As String = Nothing
            Dim strDescription As String = Nothing
            Dim dblDebit As Double = 0
            Dim dblCredit As Double = 0
            Dim strProjectName As String = Nothing

            If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(0).Value), "")) Then
                strDate = dGridStatements.Rows(i).Cells(0).Value.ToString
            End If

            If CDate(strDate) >= StartDate Then
                If CDate(strDate) <= EndDate Then
                    If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(2).Value), "")) Then
                        strReference = dGridStatements.Rows(i).Cells(2).Value.ToString
                    End If
                    If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(1).Value), "")) Then
                        strDescription = dGridStatements.Rows(i).Cells(1).Value.ToString
                    End If
                    If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(3).Value), "")) Then
                        If IsNumeric(dGridStatements.Rows(i).Cells(3).Value.ToString) Then
                            dblDebit = CDbl(dGridStatements.Rows(i).Cells(3).Value.ToString)
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(4).Value), "")) Then
                        If IsNumeric(dGridStatements.Rows(i).Cells(4).Value.ToString) Then
                            dblCredit = CDbl(dGridStatements.Rows(i).Cells(4).Value.ToString)
                        End If
                    End If
                    dblBalance = dblBalance + (dblDebit - dblCredit)
                    'DATE, DESCRIPTION, REF, PROJECT, DEBIT, CREDIT, BALANCE
                    strStatementArray.Add(strDate & "|" & strDescription & "|" & strReference & "|" & strProjectName & "|" &
                        Format(dblDebit, "#,##0.00") & "|" & Format(dblCredit, "#,##0.00") & "|" &
                        Format(dblBalance, "#,##0.00"))
                End If
            End If
        Next
        itm = 0

        dblCurrentStatementBalance = dblBalance
        'Adjustment of the moving balance ***

        arrStatementDetails = New ArrayList
        arrStatementDetails = strStatementArray

        'boolPrinterAlreadySelected = False
        PrintCustomerDocument(intSelectedTransaction, "STUDENT STATEMENT")

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Statement Print Error"
        ShowErrorMessage()
    End Sub

    Private Sub LoadStatementFinancials(StudentNumber As String)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "Description, Reference, CAST(Debit AS DECIMAL (10,2)) AS [Debit], CAST(Credit AS DECIMAL (10,2)) AS [Credit], " _
            & "Remarks, TransactionId FROM SC_StudentTransactions WHERE StudentId = '" & StudentNumber & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridStatements.Rows.Clear()
        While objReader.Read
            dGridStatements.Rows.Add(objReader(0), objReader(1),
                objReader(2), objReader(3),
                objReader(4), objReader(5), objReader(6))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Financials Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnMasterImport_Click(sender As System.Object, e As System.EventArgs) Handles btnMasterImport.Click
        On Error GoTo RaiseErr
        Dim strFileName As String = Nothing
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        strFileName = ofd.FileName

        If Not String.IsNullOrEmpty(strFileName) Then
            If File.Exists(strFileName) Then
                Dim sr As New StreamReader(strFileName)
                Dim strData As String = sr.ReadToEnd
                sr.Close()
                Dim strLines() As String = Split(strData, vbCrLf)

                With Me.ProgressBar1
                    .Value = 0
                    .Visible = True
                    .Maximum = strLines.Length + 10
                End With

                Dim strPrefix As String = Nothing
                strPrefix = InputBox("Please type in the number prefix if any", "Prefix Definition")

                For p As Integer = 0 To strLines.Length - 2
                    Dim strFields() As String = Split(strLines(p), "|")
                    If Not String.IsNullOrEmpty(strFields(0)) Then
                        'Get the next student number here
                        Dim lngStudentNumber As Long = NewStudentNumber()
                        Dim dt1 As Date

                        Dim strGender As String = "Female"
                        If Not String.IsNullOrEmpty(strFields(5)) Then
                            If UCase(Mid(strFields(5), 1, 1)) = "M" Then
                                strGender = "Male"
                            End If
                        End If

                        If Mid(Trim(strFields(4)), 1, 1) = "8" Then strFields(4) = Replace(Trim(strFields(4)), "8 ", "", 1)

                        Dim strSql As String = Nothing
                        strSql = "INSERT INTO [SC_Students] ([StudentId], [SchoolAllocatedNumber], [DateOfBirth],[EntryDate],[ClassName]," _
                            & "[LastName],[FirstName],[Gender], [Status], [OtherNames], [BillingCategory], [BillingAmount], [Address1], [Address2]) " _
                            & "VALUES ('" & lngStudentNumber & "', '" & strPrefix & "-" & CStr(lngStudentNumber) & "', '" & Trim(strFields(2)) & "', '" & Trim(strFields(3)) & "', " _
                            & "'" & Trim(strFields(4)) & "', '" & strFields(0) & "', '" & Trim(strFields(1)) & "', " _
                            & "'" & strGender & "', 'ACTIVE', '" & Trim(strFields(6)) & "', 'MANUAL', 0, " _
                            & "'" & Trim(strFields(7)) & "', '" & Trim(strFields(8)) & "')"

                        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()

                    End If

                    Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1

                Next

            End If
        End If
        Me.ProgressBar1.Value = Me.ProgressBar1.Maximum
        LoadStudentsData()
        MessageBox.Show("Details have been imported successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Students Data Import"
        ShowErrorMessage()
    End Sub

    Private Sub btnTransactionImport_Click(sender As System.Object, e As System.EventArgs) Handles btnTransactionImport.Click
        On Error GoTo RaiseErr
        Dim strFileName As String = Nothing
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        strFileName = ofd.FileName

        If Not String.IsNullOrEmpty(strFileName) Then
            If File.Exists(strFileName) Then
                Dim sr As New StreamReader(strFileName)
                Dim strData As String = sr.ReadToEnd
                sr.Close()
                Dim strLines() As String = Split(strData, vbCrLf)

                With Me.ProgressBar1
                    .Value = 0
                    .Visible = True
                    .Maximum = strLines.Length + 10
                End With

                For p As Integer = 0 To strLines.Length - 2
                    Dim strFields() As String = Split(strLines(p), "|")
                    If Not String.IsNullOrEmpty(strFields(0)) Then

                        Dim strClass As String = Trim(strFields(0))
                        Dim strGender As String = Trim(strFields(1))
                        If UCase(strGender) = "F" Then strGender = "FEMALE" Else strGender = "MALE"
                        Dim strLastName As String = Trim(strFields(2))
                        Dim strFirstName As String = Trim(strFields(3))
                        Dim strOtherNames As String = Trim(strFields(4))
                        Dim dblAmount1 As Double = 0
                        If IsNumeric(Trim(strFields(5))) Then dblAmount1 = CDbl(Trim(strFields(5)))
                        Dim strReceipt1 As String = Trim(strFields(6))
                        Dim dblAmount2 As Double = 0
                        If IsNumeric(Trim(strFields(7))) Then dblAmount2 = CDbl(Trim(strFields(7)))
                        Dim strReceipt2 As String = Trim(strFields(8))

                        'Get the student number
                        Dim strSql As String = Nothing
                        strSql = "SELECT [StudentId] FROM [SC_Students] WHERE ClassName = '" & strClass & "' AND " _
                            & "[LastName] = '" & strLastName & "' AND [FirstName] = '" & strFirstName & "' AND " _
                            & "[OtherNames] = '" & strOtherNames & "'"

                        Dim strStudentNumber As String = Nothing
                        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
                        If objReader.HasRows Then
                            objReader.Read()
                            If Not IsDBNull(objReader(0).ToString) Then strStudentNumber = objReader(0).ToString
                        End If
                        objReader.Close()

                        If Not String.IsNullOrEmpty(strStudentNumber) Then
                            strSql = Nothing
                            If dblAmount1 <> 0 Then
                                strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                    & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & strStudentNumber & "', " _
                                    & "'SCHOOL FEE PAYMENT', '" & strReceipt1 & "', " & dblAmount1 & ", '" & strPublicActiveFullUserName & "', " _
                                    & "'12-JAN-2016', 'INITIAL TRANSACTIONS IMPORT', 'TERM 1', 2016)"
                            End If
                            If Not String.IsNullOrEmpty(strSql) Then
                                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                objCommand.ExecuteNonQuery()
                            End If
                            strSql = Nothing
                            If dblAmount2 <> 0 Then
                                strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                    & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & strStudentNumber & "', " _
                                    & "'SCHOOL FEE PAYMENT', '" & strReceipt2 & "', " & dblAmount2 & ", '" & strPublicActiveFullUserName & "', " _
                                    & "'03-MAY-2016', 'INITIAL TRANSACTIONS IMPORT', 'TERM 2', 2016)"
                            End If
                            If Not String.IsNullOrEmpty(strSql) Then
                                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                objCommand.ExecuteNonQuery()
                            End If
                        End If

                    End If

                    Me.ProgressBar1.Value = Me.ProgressBar1.Value + 1

                Next

            End If
        End If
        Me.ProgressBar1.Value = Me.ProgressBar1.Maximum
        LoadStudentsData()
        MessageBox.Show("Financial transactions have been imported successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Students Transactions Import"
        ShowErrorMessage()
    End Sub

    Private Sub dGridStudents_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridStudents.CellContentDoubleClick
        If dGridStudents.Rows.Count <= 0 Then Exit Sub
        GetSelectedStudentRecord()
        boolEditStatus = True
        boolModified = False
        Dim frm As New frmStudentsSetup
        frm.ShowDialog()
        If boolModified = True Then LoadStudentsData()
    End Sub

    Private Sub btnClasses_Click(sender As System.Object, e As System.EventArgs) Handles btnClasses.Click
        Dim frm As New frmClasses
        frm.ShowDialog()
    End Sub

    Private Sub btnSubjects_Click(sender As System.Object, e As System.EventArgs) Handles btnSubjects.Click
        Dim frm As New frmStudentSubjects
        frm.ShowDialog()
    End Sub

    Private Sub btnExtraPaymentDescriptions_Click(sender As System.Object, e As System.EventArgs) Handles btnExtraPaymentDescriptions.Click
        Dim frm As New frmExtraDescriptions
        frm.ShowDialog()
    End Sub

    Private Sub btnSubjectsPaymentsTable_Click(sender As System.Object, e As System.EventArgs) Handles btnSubjectsPaymentsTable.Click
        Dim frm As New frmSubjectsPaymentTable
        frm.ShowDialog()
    End Sub

    Private Sub btnPrivateSchoolFees_Click(sender As System.Object, e As System.EventArgs) Handles btnPrivateSchoolFees.Click
        Dim frm As New frmPrivateFeeStructure
        frm.ShowDialog()
    End Sub

    Private Sub btnSchoolClassification_Click(sender As System.Object, e As System.EventArgs) Handles btnSchoolClassification.Click
        Dim frm As New frmSchoolClassification
        frm.ShowDialog()
    End Sub

    Private Sub btnNewStudentNumberParameters_Click(sender As System.Object, e As System.EventArgs) Handles btnNewStudentNumberParameters.Click
        Dim frm As New frmStudentNumberAutoAllocationParm
        frm.ShowDialog()
    End Sub

    Private Sub btnBilliableMaximum_Click(sender As System.Object, e As System.EventArgs) Handles btnBilliableMaximum.Click
        Dim frm As New frmSubjectsForBillingMaximum
        frm.ShowDialog()
    End Sub

    Private Sub btnTakeonBalances_Click(sender As System.Object, e As System.EventArgs) Handles btnTakeonBalances.Click
        Dim frm As New frmTakeOnBalances
        frm.ShowDialog()
    End Sub

    Private Sub btnPrintTermInvoices_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintTermInvoices.Click
        boolAbort = False
        Dim frm As New FrmBilling
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        On Error GoTo RaiseErr
        arrBilledStudentsNumbers = New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SC_Students.StudentId, SC_Students.ClassName " _
            & "FROM SC_Students WHERE Status = 'ACTIVE' " _
            & "ORDER BY ClassName, LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                arrBilledStudentsNumbers.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        itm = 0 : intPrintCount = arrBilledStudentsNumbers.Count
        Dim ppd As New PrintPreviewDialog
        ppd.Document = pdoc
        ppd.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Students Term Billing Invoice Printing"
        ShowErrorMessage()
    End Sub

    Private Sub expandablePanel2_ExpandedChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles ExpandablePanel2.ExpandedChanged
        AdjustPanesOwing()
    End Sub

    Private Sub AdjustPanesOwing()
        If ExpandablePanel2.Expanded Then
            If (splitOwings.Width - splitOwings.Panel1.Width) < 150 Then intPriorSplitterDistance2 = splitOwings.Width - 200
            splitOwings.SplitterDistance = intPriorSplitterDistance2
            splitOwings.IsSplitterFixed = False
        Else
            intPriorSplitterDistance2 = splitOwings.SplitterDistance
            splitOwings.SplitterDistance = splitOwings.Width - 32
            splitOwings.IsSplitterFixed = True
        End If
    End Sub

    Private Sub LoadDailyTakings()
        On Error GoTo RaiseErr
        arrPayValues = New ArrayList
        With dGridReceipts
            .Columns.Clear()
            .Columns.Add("Col1", "TRANS. DTE")
            .Columns.Add("Col2", "REC.#")
            .Columns.Add("Col3", "STUDENT #")
            .Columns.Add("Col4", "STUDENT NAMES")
            .Columns.Add("Col5", "TOTAL")

            'Dim strSql As String = "SELECT Description, Priority FROM SC_PaymentDescriptions ORDER BY Description"
            'strSql = "SELECT DISTINCT(Description) FROM SC_StudentTransactions WHERE Credit > 0"

            Dim strSql As String = Nothing ' "SELECT DISTINCT(Description) FROM SC_StudentTransactions ORDER BY Description"
            strSql = "SELECT DISTINCT(Description) FROM SC_StudentTransactions WHERE Credit > 0"

            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            Dim intCol As Integer = 6
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    arrPayValues.Add(objReader(0).ToString)
                    Dim strSplit() As String = Split(objReader(0).ToString, " ")
                    Dim strColumnHeader As String = Nothing
                    For i As Integer = 0 To strSplit.Length - 1
                        If i = strSplit.Length - 1 Then
                            strColumnHeader = strColumnHeader & strSplit(i)
                        Else
                            strColumnHeader = strColumnHeader & strSplit(i) & vbCrLf
                        End If
                    Next
                    .Columns.Add("Col" & intCol, strColumnHeader)
                End If
                intCol = intCol + 1
            End While
            objReader.Close()
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Daily Takings Layout Formatting"
        ShowErrorMessage()
    End Sub

    Private Sub btnYearEndProcedures_Click(sender As System.Object, e As System.EventArgs) Handles btnYearEndProcedures.Click
        boolAbort = False
        Dim frm As New frmYearStartClassUpdates
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        AddTreeNodes(tvClasses)
        AddTreeNodes(tvClasses2)
    End Sub

    Private Sub btnRefreshReceipts_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshReceipts.Click
        LoadDailyTakings()
    End Sub

    Private Sub btnImportAll_Click(sender As Object, e As EventArgs) Handles btnImportAll.Click
        On Error GoTo RaiseErr

        boolAbort = False
        strSelectedAccount = Nothing
        Dim frm As New frmClassOnImport
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        Dim strFileName As String = Nothing
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        strFileName = ofd.FileName
        If String.IsNullOrEmpty(strFileName) Then
            MessageBox.Show("Please select a valid file", "Invalid File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        Dim strGender As String = Nothing

        Dim objFile As New StreamReader(strFileName)
        Dim strData As String = objFile.ReadToEnd
        objFile.Close()
        Dim strLines() As String = Split(strData, vbCrLf)

        With Me.ProgressBar1
            .Value = 0
            .Visible = True
            .Maximum = strLines.Length
        End With

        Dim strClassName As String = strSelectedAccount

        If strLines.Length > 0 Then
            Dim strHeaders() As String = Split(strLines(0), vbTab)
            For p As Integer = 1 To strLines.Length - 1
                If Not String.IsNullOrEmpty(strLines(p)) Then
                    Dim strFields() As String = Split(strLines(p), vbTab)

                    Dim lngStudentNumber As Long = NewStudentNumber()
                    Dim dt1 As Date

                    If UCase(strFields(0)) = "GIRLS" Then strGender = "Female"
                    If UCase(strFields(0)) = "BOYS" Then strGender = "Male"

                    If UCase(strFields(0)) <> "GIRLS" Then
                        If UCase(strFields(0)) <> "BOYS" Then

                            'Create a blank record
                            Dim strSql As String = "INSERT INTO [SC_Students] ([StudentId],[DateOfBirth],[Address1]," _
                                & "[Address2],[Address3],[Address4],[ContactTelephone],[EntryDate],[Grade],[ClassName]," _
                                & "[ClassTeacher],[Remarks],[LastName],[FirstName],[OtherNames],[PickupPoint],[Distance]," _
                                & "[TransportFee],[Gender],[Status],[TerminationReason],[BirthEntryNumber],[SchoolAllocatedNumber]," _
                                & "[BillingCategory],[SubjectOptions],[ConventionalOptions],[BillingAmount],[StudentType]) VALUES " _
                                & "('" & lngStudentNumber & "','" & Format(Now, "dd-MMM-yyyy") & "','','','','',''," _
                                & "'" & Format(Now, "dd-MMM-yyyy") & "','','" & strClassName & "'," _
                                & "'','','','','','',0,0,'','','','','" & lngStudentNumber & "','','','',0,'')"
                            Dim objcommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                            objcommand.ExecuteNonQuery()

                            strSql = "UPDATE SC_Students SET Status = 'ACTIVE' WHERE StudentId = '" & lngStudentNumber & "'"
                            objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objcommand.ExecuteNonQuery()

                            strSql = "UPDATE SC_Students SET Gender = '" & strGender & "' WHERE StudentId = '" & lngStudentNumber & "'"
                            objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objcommand.ExecuteNonQuery()

                            'Create
                            For n As Integer = 0 To strFields.Length - 1
                                strSql = Nothing
                                If UCase(strHeaders(n)) = "SURNAME" Then
                                    strSql = "UPDATE SC_Students SET [LastName] = '" & strFields(n) & "' WHERE [StudentId] = '" & lngStudentNumber & "'"
                                    objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                    objcommand.ExecuteNonQuery()
                                End If

                                If UCase(strHeaders(n)) = "NAME" Then
                                    strSql = "UPDATE SC_Students SET [FirstName] = '" & strFields(n) & "' WHERE [StudentId] = '" & lngStudentNumber & "'"
                                    objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                    objcommand.ExecuteNonQuery()
                                End If

                                If UCase(strHeaders(n)) = "ADDRESS" Then
                                    Dim strSpliAddress() As String = Split(strFields(n), " ")
                                    For m As Integer = 0 To strSpliAddress.Length - 1
                                        Dim Address As String = "Address" & CStr(m + 1)
                                        strSql = "UPDATE SC_Students SET [" & Address & "] = '" & strSpliAddress(m) & "' WHERE [StudentId] = '" & lngStudentNumber & "'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    Next
                                End If

                                If UCase(strHeaders(n)) = "OTHER NAME" Then
                                    strSql = "UPDATE SC_Students SET [OtherNames] = '" & strFields(n) & "' WHERE [StudentId] = '" & lngStudentNumber & "'"
                                    objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                    objcommand.ExecuteNonQuery()
                                End If

                                If UCase(strHeaders(n)) = "TELEPHONE" Then
                                    strSql = "UPDATE SC_Students SET [ContactTelephone] = '" & strFields(n) & "' WHERE [StudentId] = '" & lngStudentNumber & "'"
                                    objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                    objcommand.ExecuteNonQuery()
                                End If

                                If UCase(strHeaders(n)) = "D.O.B" Then
                                    If IsDate(strFields(n)) Then
                                        strSql = "UPDATE SC_Students SET [DateOfBirth] = '" & strFields(n) & "' WHERE [StudentId] = '" & lngStudentNumber & "'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "BIRTH ENTRY" Then
                                    strSql = "UPDATE SC_Students SET [BirthEntryNumber] = '" & strFields(n) & "' WHERE [StudentId] = '" & lngStudentNumber & "'"
                                    objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                    objcommand.ExecuteNonQuery()
                                End If

                                If UCase(strHeaders(n)) = "BIRTH ENTRY" Then
                                    strSql = "UPDATE SC_Students SET [BirthEntryNumber] = '" & strFields(n) & "' WHERE [StudentId] = '" & lngStudentNumber & "'"
                                    objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                    objcommand.ExecuteNonQuery()
                                End If

                                If UCase(strHeaders(n)) = "STUDENT NUM" Then
                                    strSql = "UPDATE SC_Students SET [SchoolAllocatedNumber] = '" & strFields(n) & "' WHERE [StudentId] = '" & lngStudentNumber & "'"
                                    objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                    objcommand.ExecuteNonQuery()
                                End If

                                'Gender
                                If UCase(strHeaders(n)) = "GENDER" Then
                                    strSql = "UPDATE SC_Students SET [Gender] = '" & strFields(n) & "' WHERE [StudentId] = '" & lngStudentNumber & "'"
                                    objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                    objcommand.ExecuteNonQuery()
                                End If

                                If UCase(strHeaders(n)) = "START DATE" Then
                                    If IsDate(strFields(n)) Then
                                        strSql = "UPDATE SC_Students SET [EntryDate] = '" & strFields(n) & "' WHERE [StudentId] = '" & lngStudentNumber & "'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TA1/1" Then
                                    If IsNumeric(strFields(n)) Then
                                        strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                            & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & lngStudentNumber & "', " _
                                            & "'SCHOOL FEE PAYMENTTERM 1 PAYMENT 1', '', " & CDbl(strFields(n)) & ", '" & strPublicActiveFullUserName & "', " _
                                            & "'" & Format(Now, "dd-MMM-yyyy") & "', 'INITIAL TRANSACTIONS IMPORT', 'TERM 1', 2016)"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TA1/2" Then
                                    If IsNumeric(strFields(n)) Then
                                        strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                            & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & lngStudentNumber & "', " _
                                            & "'SCHOOL FEE PAYMENT TERM 1 PAYMENT 2', '', " & CDbl(strFields(n)) & ", '" & strPublicActiveFullUserName & "', " _
                                            & "'" & Format(Now, "dd-MMM-yyyy") & "', 'INITIAL TRANSACTIONS IMPORT', 'TERM 1', 2016)"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TA1/3" Then
                                    If IsNumeric(strFields(n)) Then
                                        strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                            & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & lngStudentNumber & "', " _
                                            & "'SCHOOL FEE PAYMENT TERM 1 PAYMENT 3', '', " & CDbl(strFields(n)) & ", '" & strPublicActiveFullUserName & "', " _
                                            & "'" & Format(Now, "dd-MMM-yyyy") & "', 'INITIAL TRANSACTIONS IMPORT', 'TERM 1', 2016)"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TA1/3" Then
                                    If IsNumeric(strFields(n)) Then
                                        strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                            & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & lngStudentNumber & "', " _
                                            & "'SCHOOL FEE PAYMENT TERM 1 PAYMENT 4', '', " & CDbl(strFields(n)) & ", '" & strPublicActiveFullUserName & "', " _
                                            & "'" & Format(Now, "dd-MMM-yyyy") & "', 'INITIAL TRANSACTIONS IMPORT', 'TERM 1', 2016)"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TR1/1" Then
                                    If Not String.IsNullOrEmpty(strFields(n)) Then
                                        strSql = "UPDATE  SC_StudentTransactions SET Reference = '" & strFields(n) & "' WHERE " _
                                            & "StudentId = '" & lngStudentNumber & "' AND Description = 'SCHOOL FEE PAYMENT TERM 1 PAYMENT 1'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TR1/2" Then
                                    If Not String.IsNullOrEmpty(strFields(n)) Then
                                        strSql = "UPDATE  SC_StudentTransactions SET Reference = '" & strFields(n) & "' WHERE " _
                                            & "StudentId = '" & lngStudentNumber & "' AND Description = 'SCHOOL FEE PAYMENT TERM 1 PAYMENT 2'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TR1/3" Then
                                    If Not String.IsNullOrEmpty(strFields(n)) Then
                                        strSql = "UPDATE  SC_StudentTransactions SET Reference = '" & strFields(n) & "' WHERE " _
                                            & "StudentId = '" & lngStudentNumber & "' AND Description = 'SCHOOL FEE PAYMENT TERM 1 PAYMENT 3'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TR1/4" Then
                                    If Not String.IsNullOrEmpty(strFields(n)) Then
                                        strSql = "UPDATE  SC_StudentTransactions SET Reference = '" & strFields(n) & "' WHERE " _
                                            & "StudentId = '" & lngStudentNumber & "' AND Description = 'SCHOOL FEE PAYMENT TERM 1 PAYMENT 4'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                'End of the first term

                                If UCase(strHeaders(n)) = "TA2/1" Then
                                    If IsNumeric(strFields(n)) Then
                                        strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                            & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & lngStudentNumber & "', " _
                                            & "'SCHOOL FEE PAYMENTTERM 2 PAYMENT 1', '', " & CDbl(strFields(n)) & ", '" & strPublicActiveFullUserName & "', " _
                                            & "'" & Format(Now, "dd-MMM-yyyy") & "', 'INITIAL TRANSACTIONS IMPORT', 'TERM 2', 2016)"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TA2/2" Then
                                    If IsNumeric(strFields(n)) Then
                                        strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                            & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & lngStudentNumber & "', " _
                                            & "'SCHOOL FEE PAYMENT TERM 2 PAYMENT 2', '', " & CDbl(strFields(n)) & ", '" & strPublicActiveFullUserName & "', " _
                                            & "'" & Format(Now, "dd-MMM-yyyy") & "', 'INITIAL TRANSACTIONS IMPORT', 'TERM 2', 2016)"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TA2/3" Then
                                    If IsNumeric(strFields(n)) Then
                                        strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                            & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & lngStudentNumber & "', " _
                                            & "'SCHOOL FEE PAYMENT TERM 2 PAYMENT 3', '', " & CDbl(strFields(n)) & ", '" & strPublicActiveFullUserName & "', " _
                                            & "'" & Format(Now, "dd-MMM-yyyy") & "', 'INITIAL TRANSACTIONS IMPORT', 'TERM 2', 2016)"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TA2/4" Then
                                    If IsNumeric(strFields(n)) Then
                                        strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                            & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & lngStudentNumber & "', " _
                                            & "'SCHOOL FEE PAYMENT TERM 2 PAYMENT 4', '', " & CDbl(strFields(n)) & ", '" & strPublicActiveFullUserName & "', " _
                                            & "'" & Format(Now, "dd-MMM-yyyy") & "', 'INITIAL TRANSACTIONS IMPORT', 'TERM 2', 2016)"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TR2/1" Then
                                    If Not String.IsNullOrEmpty(strFields(n)) Then
                                        strSql = "UPDATE  SC_StudentTransactions SET Reference = '" & strFields(n) & "' WHERE " _
                                            & "StudentId = '" & lngStudentNumber & "' AND Description = 'SCHOOL FEE PAYMENT TERM 2 PAYMENT 1'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TR2/2" Then
                                    If Not String.IsNullOrEmpty(strFields(n)) Then
                                        strSql = "UPDATE  SC_StudentTransactions SET Reference = '" & strFields(n) & "' WHERE " _
                                            & "StudentId = '" & lngStudentNumber & "' AND Description = 'SCHOOL FEE PAYMENT TERM 2 PAYMENT 2'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TR2/3" Then
                                    If Not String.IsNullOrEmpty(strFields(n)) Then
                                        strSql = "UPDATE  SC_StudentTransactions SET Reference = '" & strFields(n) & "' WHERE " _
                                            & "StudentId = '" & lngStudentNumber & "' AND Description = 'SCHOOL FEE PAYMENT TERM 2 PAYMENT 3'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TR2/4" Then
                                    If Not String.IsNullOrEmpty(strFields(n)) Then
                                        strSql = "UPDATE  SC_StudentTransactions SET Reference = '" & strFields(n) & "' WHERE " _
                                            & "StudentId = '" & lngStudentNumber & "' AND Description = 'SCHOOL FEE PAYMENT TERM 2 PAYMENT 4'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                'Term 3 begins here

                                If UCase(strHeaders(n)) = "TA3/1" Then
                                    If IsNumeric(strFields(n)) Then
                                        strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                            & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & lngStudentNumber & "', " _
                                            & "'SCHOOL FEE PAYMENTTERM 3 PAYMENT 1', '', " & CDbl(strFields(n)) & ", '" & strPublicActiveFullUserName & "', " _
                                            & "'" & Format(Now, "dd-MMM-yyyy") & "', 'INITIAL TRANSACTIONS IMPORT', 'TERM 3', 2016)"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TA3/2" Then
                                    If IsNumeric(strFields(n)) Then
                                        strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                            & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & lngStudentNumber & "', " _
                                            & "'SCHOOL FEE PAYMENT TERM 3 PAYMENT 2', '', " & CDbl(strFields(n)) & ", '" & strPublicActiveFullUserName & "', " _
                                            & "'" & Format(Now, "dd-MMM-yyyy") & "', 'INITIAL TRANSACTIONS IMPORT', 'TERM 3', 2016)"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TA3/3" Then
                                    If IsNumeric(strFields(n)) Then
                                        strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                            & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & lngStudentNumber & "', " _
                                            & "'SCHOOL FEE PAYMENT TERM 3 PAYMENT 3', '', " & CDbl(strFields(n)) & ", '" & strPublicActiveFullUserName & "', " _
                                            & "'" & Format(Now, "dd-MMM-yyyy") & "', 'INITIAL TRANSACTIONS IMPORT', 'TERM 3', 2016)"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TA3/4" Then
                                    If IsNumeric(strFields(n)) Then
                                        strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Reference, Credit, " _
                                            & "UserName, TransactionDate, Remarks, SchoolTerm, TermYear) VALUES ('" & lngStudentNumber & "', " _
                                            & "'SCHOOL FEE PAYMENT TERM 3 PAYMENT 4', '', " & CDbl(strFields(n)) & ", '" & strPublicActiveFullUserName & "', " _
                                            & "'" & Format(Now, "dd-MMM-yyyy") & "', 'INITIAL TRANSACTIONS IMPORT', 'TERM 3', 2016)"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TR3/1" Then
                                    If Not String.IsNullOrEmpty(strFields(n)) Then
                                        strSql = "UPDATE  SC_StudentTransactions SET Reference = '" & strFields(n) & "' WHERE " _
                                            & "StudentId = '" & lngStudentNumber & "' AND Description = 'SCHOOL FEE PAYMENT TERM 3 PAYMENT 1'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TR3/2" Then
                                    If Not String.IsNullOrEmpty(strFields(n)) Then
                                        strSql = "UPDATE  SC_StudentTransactions SET Reference = '" & strFields(n) & "' WHERE " _
                                            & "StudentId = '" & lngStudentNumber & "' AND Description = 'SCHOOL FEE PAYMENT TERM 3 PAYMENT 2'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TR3/3" Then
                                    If Not String.IsNullOrEmpty(strFields(n)) Then
                                        strSql = "UPDATE  SC_StudentTransactions SET Reference = '" & strFields(n) & "' WHERE " _
                                            & "StudentId = '" & lngStudentNumber & "' AND Description = 'SCHOOL FEE PAYMENT TERM 3 PAYMENT 3'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                                If UCase(strHeaders(n)) = "TR4/4" Then
                                    If Not String.IsNullOrEmpty(strFields(n)) Then
                                        strSql = "UPDATE  SC_StudentTransactions SET Reference = '" & strFields(n) & "' WHERE " _
                                            & "StudentId = '" & lngStudentNumber & "' AND Description = 'SCHOOL FEE PAYMENT TERM 4 PAYMENT 4'"
                                        objcommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objcommand.ExecuteNonQuery()
                                    End If
                                End If

                            Next
                        End If
                    End If

                    ProgressBar1.Value = ProgressBar1.Value + 1
                End If
            Next

        End If

        Cursor = Cursors.Default

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Data Import"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPayments_Click(sender As Object, e As EventArgs) Handles btnPayments.Click
        Dim frm As New frmFeesPayments
        frm.ShowDialog()
    End Sub

    Private Sub btnStudentsListing_Click(sender As Object, e As EventArgs) Handles btnStudentsListing.Click
        PrintStudentsListing()
    End Sub

    Private Sub btnStudentStatement_Click(sender As Object, e As EventArgs) Handles btnStudentStatement.Click
        PrintSelectedStudentStatement()
    End Sub

    Private Sub btnTerminateStudent_Click(sender As Object, e As EventArgs) Handles btnTerminateStudent.Click
        TerminateStudent()
    End Sub

    Private Sub btnPaymentAllocations_Click(sender As Object, e As EventArgs) Handles btnPaymentAllocations.Click
        Dim frm As New frmPaymentAllocationRates
        frm.ShowDialog()
    End Sub

    Private Sub PrintSelectedReport(strSelectedNodeText As String, Optional PrintedFrom As String = Nothing)
        On Error GoTo RaiseErr
        Select Case UCase(strSelectedNodeText)
            Case Is = UCase("Students by Type")
                PrintStudentsByType()
            Case Is = UCase("Students by Sponsor")
                PrintStudentsBySponsor()
            Case Is = UCase("Balance by Sponsor")
                BalanceBySponsor()
        End Select

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Report Print Error"
        ShowErrorMessage()
    End Sub

    Private Sub PrintStudentsBySponsor()
        On Error GoTo RaiseErr
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Report Print Error"
        ShowErrorMessage()
    End Sub

    Private Sub BalanceBySponsor()

        On Error GoTo RaiseErr

        strReportType = "SPONSORS"
        boolAbort = False
        Dim frm As New frmCriteria
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        Dim strSql As String = "SELECT SC_Students.LastName +';'+ " _
            & "SC_Students.FirstName +' '+ SC_Students.OtherNames +';'+ " _
            & "SC_Students.ClassName +';'+ " _
            & "CONVERT(NVARCHAR, SUM(SC_StudentTransactions.Debit - SC_StudentTransactions.Credit)) +';'+ " _
            & "SC_Guardians.GivenNames FROM SC_Students " _
            & "LEFT OUTER JOIN SC_StudentTransactions ON SC_Students.StudentId = SC_StudentTransactions.StudentId " _
            & "LEFT OUTER JOIN SC_Guardians ON SC_Students.StudentId = SC_Guardians.StudentId " _
            & "WHERE SC_Guardians.GivenNames = '" & strSelectedDescription & "' " _
            & "GROUP BY SC_Students.LastName, SC_Students.FirstName, " _
            & "SC_Students.OtherNames, SC_Students.ClassName, SC_Guardians.GivenNames"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        arrPrintData = New ArrayList
        While objReader.Read
            arrPrintData.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        If arrPrintData.Count = 0 Then
            MessageBox.Show("No details to print were obtained from the system", "Printing Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 5
            .strColumnHeaders = "SURNAME|GIVEN NAMES|CLASS|BALANCE|SPONSOR"
            .strColumnAlignments = "0|0|0|2|0"
            .strColumnWidths = "120|120|100|80|180"
            .strFooterCaption = UCase("SPONSORED STUDENTS Listing as at " & Format(Now, "dd-MMM-yyyy"))
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "SPONSORED STUDENT BALANCE : " & UCase(strSelectedDescription)
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|YES|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.LightGray
            .BorderColor = Color.LightGray
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = True
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = True
            .boolPrintRecordCount = True
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|YES|NO"
            .strSummaryTotals = "NO|NO|NO|YES|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With

        Dim prnt As New frmPrinterSetup
        prnt.ShowDialog()
        If boolAbort = True Then Exit Sub
        rpt.PrinterSettings.PrinterName = strSessionPrinter

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Report Print Error"
        ShowErrorMessage()
    End Sub

    Private Sub PrintStudentsByType()
        On Error GoTo RaiseErr

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Report Print Error"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintPreview_Click(sender As Object, e As System.EventArgs) Handles btnPrintPreview.Click
        On Error GoTo RaiseErr
        If Not Object.Equals(tvReports.SelectedNode, Nothing) Then
            strReportHeader = UCase(tvReports.SelectedNode.Text)
            If UCase(strReportHeader) = UCase("A/R Aging Analysis") Then
                PrintSelectedReport(strReportHeader, "PREVIEW")
                Exit Sub
            End If
            PrintSelectedReport(strReportHeader)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Report Preview Error"
        ShowErrorMessage()
    End Sub

    Private Sub tvReports_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvReports.DoubleClick
        On Error GoTo RaiseErr
        If Not Object.Equals(tvReports.SelectedNode, Nothing) Then
            strReportHeader = UCase(tvReports.SelectedNode.Text)
            PrintSelectedReport(strReportHeader)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Report Preview Error"
        ShowErrorMessage()
    End Sub

    Private Sub KryptonButton1_Click(sender As Object, e As EventArgs) Handles KryptonButton1.Click
        arrStatementDetails = New ArrayList
        gwt_comm.PrintCustomerDocument(97359, "FEES")
    End Sub

    Private Sub btnSponsors_Click_1(sender As Object, e As EventArgs) Handles btnSponsors.Click
        Dim frm As New frmSponsorsListing
        frm.ShowDialog()
    End Sub

    Private Sub btnPrior_Click(sender As Object, e As EventArgs) Handles btnPrior.Click
        arrSelectedItems = New ArrayList
        For p As Integer = 0 To dGridOwings.Rows.Count - 1
            Dim intStudent As Integer = 0
            Dim strDetails As String = Nothing
            Dim dblBalance As Double = 0
            If Not Object.Equals(dGridOwings.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridOwings.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGridOwings.Rows(p).Cells(1).Value.ToString) Then
                        intStudent = CInt(dGridOwings.Rows(p).Cells(1).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGridOwings.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridOwings.Rows(p).Cells(2).Value.ToString) Then
                    strDetails = dGridOwings.Rows(p).Cells(2).Value.ToString
                End If
            End If

            '
            If Not Object.Equals(dGridOwings.Rows(p).Cells(dGridOwings.ColumnCount - 1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridOwings.Rows(p).Cells(dGridOwings.ColumnCount - 1).Value.ToString) Then
                    If IsNumeric(dGridOwings.Rows(p).Cells(dGridOwings.ColumnCount - 1).Value.ToString) Then
                        dblBalance = CDbl(dGridOwings.Rows(p).Cells(dGridOwings.ColumnCount - 1).Value.ToString)
                    End If
                End If
            End If
            arrSelectedItems.Add(CStr(intStudent) & "|" & UCase(strDetails) & "|" & Format(dblBalance, "##0.00"))
        Next
        Dim frm As New frmMassPriorReceipts
        frm.ShowDialog()
        LoadOwingsData(tvClasses2.SelectedNode.Text, txtAmountFrom.Text, txtAmountTo.Text)
    End Sub

    Private Sub btnFees_Click(sender As Object, e As EventArgs) Handles btnFees.Click
        Dim frm As New frmTermFees
        frm.ShowDialog()
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click

    End Sub

    Private Sub pStats_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pStats.PrintPage

        'On Error GoTo RaiseErr

        While itm < arrSelectedItems.Count


            Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
            Dim y1 As Integer, y2 As Integer, p1 As Integer

            'Dim xx1 AS DOUBLE, xx2 AS DOUBLE, yy1 AS DOUBLE, yy2 AS DOUBLE
            x1 = e.PageBounds.Left + 100
            y1 = e.PageBounds.Top + 100
            p1 = e.PageBounds.Width - 200
            y2 = e.PageBounds.Height - 170

            Dim pencurrent As New Pen(Color.Black, 3)
            Dim reccurrent As Rectangle
            Dim graCurrent As Graphics = e.Graphics
            Dim strS As String = Nothing
            Dim Yc As Double
            Dim cols, lines As Double



            '************************************************************************
            'Begin the stringing of the statements here

            strStatementArray = New ArrayList
            dblCummulativeStatementBalance = 0

            LoadStatementFinancials(arrSelectedItems.Item(itm))

            'get the selected student details
            Dim strSurname As String = Nothing
            Dim strGivenNames As String = Nothing
            Dim strStudentNumber As String = UCase(arrSelectedItems.Item(itm))
            Dim strClass As String = Nothing

            '*************** GET THE SELECTED STUDENT DETAILS ****************

            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ClassName, LastName, " _
            & "FirstName +' '+ OtherNames AS [GivenNames], SchoolAllocatedNumber " _
            & "FROM SC_Students WHERE StudentId = '" & arrSelectedItems.Item(itm) & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then strClass = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then strSurname = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then strGivenNames = Trim(objReader(2).ToString)
                If Not IsDBNull(objReader(3).ToString) Then
                    If Not String.IsNullOrEmpty(objReader(3).ToString) Then
                        If UCase(objReader(3).ToString) <> UCase(strStudentNumber) Then
                            strStudentNumber = UCase(objReader(3).ToString)
                        End If
                    End If
                End If
            End If
            objReader.Close()


            'Get the balance brought forwd
            For i As Integer = 0 To dGridStatements.Rows.Count - 1

                Dim dblDr As Double = 0
                Dim dblCr As Double = 0
                Dim strDt As String = Nothing

                If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(0).Value), "")) Then
                    strDt = dGridStatements.Rows(i).Cells(0).Value.ToString
                End If

                If CDate(strDt) < StartDate Then
                    'If CDate(strDt) <= EndDate Then
                    If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(3).Value), "")) Then
                        If IsNumeric(dGridStatements.Rows(i).Cells(3).Value.ToString) Then
                            dblDr = CDbl(dGridStatements.Rows(i).Cells(3).Value.ToString)
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(4).Value), "")) Then
                        If IsNumeric(dGridStatements.Rows(i).Cells(4).Value.ToString) Then
                            dblCr = CDbl(dGridStatements.Rows(i).Cells(4).Value.ToString)
                        End If
                    End If
                    dblCummulativeStatementBalance = dblCummulativeStatementBalance + (dblDr - dblCr)
                    'End If
                End If

            Next

            strStatementArray.Add(UCase(Format(StartDate, "dd-MMM-yyyy")) & "|" & UCase("Balance brought forward") & "| | | | |" & Format(dblCummulativeStatementBalance, "#,##0.00"))
            Dim dblBalance As Double = dblCummulativeStatementBalance

            For i As Integer = 0 To dGridStatements.Rows.Count - 1

                Dim strDate As String = Nothing
                Dim strReference As String = Nothing
                Dim strDescription As String = Nothing
                Dim dblDebit As Double = 0
                Dim dblCredit As Double = 0
                Dim strProjectName As String = Nothing

                If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(0).Value), "")) Then
                    strDate = dGridStatements.Rows(i).Cells(0).Value.ToString
                End If

                If CDate(strDate) >= StartDate Then
                    If CDate(strDate) <= EndDate Then
                        If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(2).Value), "")) Then
                            strReference = dGridStatements.Rows(i).Cells(2).Value.ToString
                        End If
                        If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(1).Value), "")) Then
                            strDescription = dGridStatements.Rows(i).Cells(1).Value.ToString
                        End If
                        If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(3).Value), "")) Then
                            If IsNumeric(dGridStatements.Rows(i).Cells(3).Value.ToString) Then
                                dblDebit = CDbl(dGridStatements.Rows(i).Cells(3).Value.ToString)
                            End If
                        End If
                        If Not (Object.Equals(Convert.ToString(dGridStatements.Rows(i).Cells(4).Value), "")) Then
                            If IsNumeric(dGridStatements.Rows(i).Cells(4).Value.ToString) Then
                                dblCredit = CDbl(dGridStatements.Rows(i).Cells(4).Value.ToString)
                            End If
                        End If
                        dblBalance = dblBalance + (dblDebit - dblCredit)
                        'DATE, DESCRIPTION, REF, PROJECT, DEBIT, CREDIT, BALANCE
                        strStatementArray.Add(strDate & "|" & strDescription & "|" & strReference & "|" & strProjectName & "|" &
                            Format(dblDebit, "#,##0.00") & "|" & Format(dblCredit, "#,##0.00") & "|" &
                            Format(dblBalance, "#,##0.00"))
                    End If
                End If

            Next


            If strStatementArray.Count > 0 Then

                'Get the student details here

                If Not String.IsNullOrEmpty(strLogoPath) Then
                    If System.IO.File.Exists(strLogoPath) Then
                        'Dont print the company name in that case as it is taken up by the logo
                        strCompanyName = ""
                        Dim R As Drawing.Rectangle
                        Dim objPicture As New Windows.Forms.PictureBox
                        objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                        objPicture.Load(strLogoPath)
                        Dim intImageYLocation As Double = objPicture.Height
                        intImageYLocation = (100 - intImageYLocation) / 2
                        R = New Rectangle(intLogoXposition, intLogoYposition, objPicture.Width, objPicture.Height)
                        e.Graphics.DrawImage(objPicture.Image, R)
                    End If
                End If

                'Draw the document rectangle
                reccurrent = New Rectangle(x1, y1, p1, y2)
                e.Graphics.DrawRectangle(Pens.Black, reccurrent)
                y1 = e.PageBounds.Top + 120

                'Print the company details at the extreme left of document
                Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, fntHeaderFont, Brushes.Black)
                e.Graphics.DrawString("STUDENT STATEMENT", fntHeaderFont, Brushes.Black, 500, e.PageBounds.Top + 120)
                y1 = y1 + 20
                Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCompanyAddressFull, fntHeaderFont, Brushes.Black)

                'Get the size of the address box
                e.Graphics.MeasureString(strCompanyAddressFull, fntHeaderFont, New SizeF(200, 80), New StringFormat(), cols, lines)
                Yc = y1
                y1 = y1 + lines * fntHeaderFont.Height + 5
                y1 = Math.Max(y1, Yc)

                e.Graphics.MeasureString(strCompanyTelephone, fntHeaderFont, New SizeF(500, 80), New StringFormat(), cols, lines)
                Yc = y1
                y1 = y1 + lines * fntHeaderFont.Height + 5
                y1 = Math.Max(y1, Yc)
                'Call gwt_comm.DrawStringInBoxLeft(e, 550, y1 - 18, 250, 80, "Vat Number : " & strCompanyVatNumber, fntHeaderFont, Brushes.Black)

                'Print the bank details
                If Not String.IsNullOrEmpty(strCompanyBankName) Then
                    Dim strBank As String = "BANK NAME"
                    Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 600, 80, strBank.PadRight(12) & ": " & UCase(strCompanyBankName), fntDetailsFontBold, Brushes.Black)
                    y1 += 15
                    strBank = "BRANCH CODE"
                    Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 600, 80, strBank.PadRight(12) & ": " & UCase(strCompanyBranchCode), fntDetailsFontBold, Brushes.Black)
                    y1 += 15
                    strBank = "ACCOUNT NUMBER"
                    Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 600, 80, strBank.PadRight(12) & ": " & strCompanyAccountNumber, fntDetailsFontBold, Brushes.Black)
                    y1 += 20
                End If

                'print captions
                x1 = x1 + 10
                x2 = x1 + 110
                X3 = x2 + 180
                X4 = X3 + 80
                X5 = X4 + 80
                X6 = X5 + 80

                e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
                y1 = y1 + 20
                e.Graphics.DrawString("CUSTOMER DETAILS", fntDetailsFont, Brushes.Black, x1, y1)
                e.Graphics.DrawString("STATEMENT DETAILS", fntDetailsFont, Brushes.Black, 500, y1)
                y1 = y1 + 20
                e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
                y1 = y1 + 30

                'Read the customer details
                'drCustomerDetails.Read()
                'Continue and print the customer details

                Call gwt_comm.DrawStringInBoxLeft(e, x1 + 10, y1, x1 + 100, 200, "Surname", fntDetailsFontBold, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, x1 + 110, y1, x1 + 200, 200, UCase(strSurname), fntDetailsFont, Brushes.Black)
                y1 = y1 + 20
                Call gwt_comm.DrawStringInBoxLeft(e, x1 + 10, y1, x1 + 100, 220, "Given Names", fntDetailsFontBold, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, x1 + 110, y1, x1 + 200, 220, UCase(strGivenNames), fntDetailsFont, Brushes.Black)
                y1 = y1 + 20
                Call gwt_comm.DrawStringInBoxLeft(e, x1 + 10, y1, x1 + 100, 240, "Class", fntDetailsFontBold, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, x1 + 110, y1, x1 + 200, 240, UCase(strClass), fntDetailsFont, Brushes.Black)
                y1 = y1 + 20
                Call gwt_comm.DrawStringInBoxLeft(e, x1 + 10, y1, x1 + 100, 260, "Student ID", fntDetailsFontBold, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, x1 + 110, y1, x1 + 200, 260, UCase(strStudentNumber), fntDetailsFont, Brushes.Black)

                e.Graphics.DrawString(UCase("STATEMENT DATE : " & Format(Now, "dd-MMM-yyyy")), fntDetailsFont, Brushes.Black, 450, y1)
                y1 = y1 + 25

                e.Graphics.DrawString(UCase("PERIOD COVERED : " & Format(StartDate, "dd-MMM-yyyy") & " - " & Format(EndDate, "dd-MMM-yyyy")),
                                      fntDetailsFont, Brushes.Black, 450, y1)

                y1 = y1 + 75
                e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
                y1 = y1 + 20

                'print captions
                Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 100, 80, "DATE", fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 180, 80, "DESCRIPTION", fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, X3, y1, 60, 80, "REF.", fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 80, 80, "DEBIT", fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 80, 80, "CREDIT", fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 80, 80, "BALANCE", fntDetailsFont, Brushes.Black)

                'draw a line after
                y1 = y1 + 30
                e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
                y1 = y1 + 30

                reccurrent = New Rectangle()

                ''Print the cummulative balance first
                'Call gwt_comm.DrawStringInBoxLeft(e, X3, y1, 180, 80, "Balance b/d", fntDetailsFont, Brushes.Black)
                ''If printing to the next page then you take the balance from the previous page

                'Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, Format(dblBalance, "#,##0.00"), fntDetailsFont, Brushes.Black)

                y1 = y1 + 30


                Dim strValue As String = Nothing
                Dim dblPeriodEndBalance As Double = 0

                For j As Integer = 0 To strStatementArray.Count - 1

                    Dim strbuffer() As String
                    strbuffer = Split(strStatementArray(j), "|")
                    If Not strbuffer(0) Is Nothing Then strValue = CStr(Format(CDate(strbuffer(0)), "dd-MMM-yyyy")) Else strValue = ""
                    Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 100, 80, strValue, fntDetailsFont, Brushes.Black)
                    If Not strbuffer(1) Is Nothing Then strValue = strbuffer(1) Else strValue = ""
                    Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 180, 80, strValue, fntDetailsFont, Brushes.Black)
                    If Not strbuffer(2) Is Nothing Then strValue = strbuffer(2) Else strValue = ""
                    Call gwt_comm.DrawStringInBoxLeft(e, X3, y1, 60, 80, strValue, fntDetailsFont, Brushes.Black)
                    If IsNumeric(strbuffer(4)) Then strValue = CStr(Format(CDbl(strbuffer(4)), "#,##0.00")) Else strValue = "0.00"
                    Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 80, 80, strValue, fntDetailsFont, Brushes.Black)
                    If IsNumeric(strbuffer(5)) Then strValue = CStr(Format(CDbl(strbuffer(5)), "#,##0.00")) Else strValue = "0.00"
                    Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 80, 80, strValue, fntDetailsFont, Brushes.Black)
                    If IsNumeric(strbuffer(6)) Then strValue = CStr(Format(CDbl(strbuffer(6)), "#,##0.00")) Else strValue = "0.00"
                    Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 80, 80, strValue, fntDetailsFont, Brushes.Black)

                    If IsNumeric(strValue) Then dblPeriodEndBalance = CDbl(strValue)

                    e.Graphics.MeasureString(strbuffer(1), fntDetailsFont, New SizeF(200, 80), New StringFormat(), cols, lines)
                    Yc = y1
                    y1 = y1 + lines * (fntDetailsFont.Height + 1)
                    y1 = Math.Max(y1, Yc) + 2

                Next

                y1 = y1 + 20
                e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
                y1 = y1 + 20
                Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 180, 80, "AMOUNT DUE", fntDetailsFontBold, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 80, 80, Format(dblPeriodEndBalance, "#,##0.00"), fntDetailsFontBold, Brushes.Black)

            End If

            itm = itm + 1
            e.HasMorePages = True
            Exit Sub 

        End While

        e.HasMorePages = False

        ' reset the flag counter to 0
        itm = 0
        Exit Sub

RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Multiple statements Print Error"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintAllStatements_Click(sender As Object, e As EventArgs) Handles btnPrintAllStatements.Click
        If dGridStudents.Rows.Count <= 0 Then Exit Sub
        boolAbort = False
        arrSelectedItems = New ArrayList
        Dim f As New frmDateSpecifier
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        For j As Integer = 0 To dGridStudents.Rows.Count - 1
            arrSelectedItems.Add(dGridStudents.Rows(j).Cells(0).Value.ToString)
        Next
        intPrintCount = arrSelectedItems.Count - 1
        itm = 0
        Dim frm As New frmPrinterSetup
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        pStats.PrinterSettings.PrinterName = strSessionPrinter
        Dim ppd As New PrintPreviewDialog
        ppd.Document = pStats
        ppd.ShowDialog()
    End Sub

    Private Sub btnReceiptSelected_Click(sender As Object, e As EventArgs) Handles btnReceiptSelected.Click
        If dGridStudents.Rows.Count <= 0 Then Exit Sub
        boolCalledFromListing = True
        strSelectedAccountName = Nothing
        strSelectedAccount = Nothing
        If Not Object.Equals(dGridStudents.CurrentRow.Cells(2).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridStudents.CurrentRow.Cells(2).Value.ToString) Then
                strSelectedAccountName = dGridStudents.CurrentRow.Cells(2).Value.ToString
            End If
        End If

        If Not Object.Equals(dGridStudents.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridStudents.CurrentRow.Cells(0).Value.ToString) Then
                strSelectedAccount = dGridStudents.CurrentRow.Cells(0).Value.ToString
            End If
        End If

        Dim frm As New frmFeesPayments
        frm.ShowDialog()
        boolCalledFromListing = False
    End Sub

    Private Sub btnBillSelectedStudent_Click(sender As Object, e As EventArgs) Handles btnBillSelectedStudent.Click
        If dGridStudents.RowCount <= 0 Then Exit Sub
        boolAbort = False
        Dim frm As New FrmBilling
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        On Error GoTo RaiseErr
        arrBilledStudentsNumbers = New ArrayList
        arrBilledStudentsNumbers.Add(dGridStudents.CurrentRow.Cells(0).Value.ToString)

        itm = 0 : intPrintCount = arrBilledStudentsNumbers.Count
        Dim ppd As New PrintPreviewDialog
        ppd.Document = pdoc
        ppd.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Students Term Billing Invoice Printing"
        ShowErrorMessage()
    End Sub

    Private Sub btnAdhocBilling_Click(sender As Object, e As EventArgs) Handles btnAdhocBilling.Click
        Dim frm As New frmTakeOnBalances
        frm.ShowDialog()
    End Sub

    Private Sub optSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles optSelectAll.CheckedChanged
        For p As Integer = 0 To dGridOwings.Rows.Count - 1
            dGridOwings.Rows(p).Cells(0).Value = True
        Next
    End Sub

    Private Sub optUnselectAll_CheckedChanged(sender As Object, e As EventArgs) Handles optUnselectAll.CheckedChanged
        For p As Integer = 0 To dGridOwings.Rows.Count - 1
            dGridOwings.Rows(p).Cells(0).Value = False
        Next
    End Sub

    Private Sub dGridOwings_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dGridOwings.CellMouseUp
        If e.ColumnIndex = 0 Then dGridOwings.EndEdit()
    End Sub

End Class
