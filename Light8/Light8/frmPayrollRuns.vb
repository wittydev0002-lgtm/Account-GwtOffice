Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPayrollRuns

    Dim strCurrentProcessingEmployee As String

    Private Sub frmPayrollRuns_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        boolPayrollLoaded = False
    End Sub

    Private Sub frmPayrollRuns_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        arrEmpOriginalCodes = New ArrayList
        boolRunningForDisplay = False
        LoadEmployeeDetails()
    End Sub

    Private Sub LoadEmployeeDetails()
        'read the employee file and populate the grid with only active employees
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT EmployeeNo, " _
            & "LastName, FirstName, OtherNames FROM EmployeeMaster WHERE Status = 'Active' ORDER BY " _
            & "EmployeeNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Setup the listview columns
        With ListView1
            .Clear()
            .Columns.Add("EC Number", 100, HorizontalAlignment.Left)
            .Columns.Add("Surname", 200, HorizontalAlignment.Left)
            .Columns.Add("Name", 200, HorizontalAlignment.Left)
            .Columns.Add("Other Names", (.Width - 505), HorizontalAlignment.Left)
        End With

        'Continue to read until you reach the end of the file.
        While objReader.Read
            Dim LItem As New ListViewItem
            LItem.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then LItem.SubItems.Add(objReader(1).ToString)
            If Not IsDBNull(objReader(2).ToString) Then LItem.SubItems.Add(objReader(2).ToString)
            If Not IsDBNull(objReader(3).ToString) Then LItem.SubItems.Add(objReader(3).ToString)
            ListView1.Items.Add(LItem)
        End While
        'Close the file.
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub


    '=======PAYROLL RUN MODULES==================

    Public Sub ProcessPayrollControl()
        'On Error GoTo RaiseErr
        boolAbort = False
        'First Get the neccessary resources from the files to run the payroll
        'First make a backup of the post run
        InitializePayrollRun()
        If boolAbort = True Then boolAbort = False
        gwt_comm.AssignSystemCodes()
        If boolAbort = True Then Exit Sub
        gwt_comm.BalanceDeductionCodes()
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignSystemMasterFields()
        If boolAbort = True Then Exit Sub
        gwt_comm.LoadCalculationsToArray()
        If boolAbort = True Then Exit Sub
        'TableValues()
        If boolAbort = True Then Exit Sub
        gwt_comm.CheckCalendar()
        If boolAbort = True Then Exit Sub
        gwt_comm.InitializeExceptionFile()
        If boolAbort = True Then Exit Sub
        gwt_comm.GetKeyDataFields()
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignTrekkedFields()
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignYearToDates()
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignBatchesToArray()
        If boolAbort = True Then Exit Sub
        gwt_comm.LoadConstantsToArray()
        If boolAbort = True Then Exit Sub
        gwt_comm.GetTaxTables()
        If boolAbort = True Then Exit Sub

        Dim p As Integer
        Me.tspb.Value = 0
        Me.tspb.Visible = True
        Me.tspb.Maximum = intSelectedEmployeesCnt
        '

        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeRunFile", cnn)
        sqlCommand.ExecuteNonQuery()
        'initialize the employee run array
        '
        arrPayrollRunCodes = New ArrayList
        arrPayrollStorageCodes = New ArrayList
        arrPayrollQmfCodes = New ArrayList
        arrExceptionsRaised = New ArrayList
        arrPayrollRunMasterFields = New ArrayList

        Cursor = Cursors.WaitCursor

        For p = 0 To (intSelectedEmployeesCnt - 1)
            strCurrentProcessingEmployee = strSelectedEmployees(p)
            'Crete a single line employee codes file
            gwt_comm.UpdateOnelineEmployeeCodes(strCurrentProcessingEmployee)
            If boolAbort = True Then Exit Sub
            gwt_comm.UpdateOnelineEmployeeMasterFields(strCurrentProcessingEmployee)
            If boolAbort = True Then Exit Sub
            gwt_comm.LoadIndicatorsToArray(strCurrentProcessingEmployee)
            If boolAbort = True Then Exit Sub
            'Load the current employee dates
            dtCurrentEmployeeBirthDate = CDate(gwt_comm.LoadBirthDate(strCurrentProcessingEmployee))
            If boolAbort = True Then GoTo CloseRoutine
            dtCurrentEmployeeHireDate = CDate(gwt_comm.LoadHireDate(strCurrentProcessingEmployee))
            If boolAbort = True Then GoTo CloseRoutine
            'based on the current employee, load that particular employee pay field values to an array
            gwt_comm.LoadActiveEmployeePayrollCodes(strCurrentProcessingEmployee)
            If boolAbort = True Then GoTo CloseRoutine
            gwt_comm.LoadActiveEmployeePayrollMasterFields(strCurrentProcessingEmployee)
            If boolAbort = True Then GoTo CloseRoutine
            gwt_comm.ComputePayroll(strCurrentProcessingEmployee)
            If boolAbort = True Then GoTo CloseRoutine
            Me.tspb.Value = Me.tspb.Value + 1
        Next
        'Update the current run period to Y
        UpdateCalendar()
        'Clear payroll batches
        Dim objClearBatches As Data.OleDb.OleDbCommand
        If MessageBox.Show("Do you want to clear the current payroll batches or move them to batch buffer?" & vbCrLf & _
            "Press YES to clear without saving. Otherwise press NO to save and then clear", "Confirm Batch Clearance", _
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            objClearBatches = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeBatches", cnn)
            objClearBatches.ExecuteNonQuery()
        Else
            'move them to the batches trek file
            UpdateBatchHistory()
            objClearBatches = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeBatches", cnn)
            objClearBatches.ExecuteNonQuery()
        End If
        'Request for the postrun backup
        Dim f As New frmRunBackup ' frmDatabaseBackup
        f.Text = "Post Run File Backups"
        f.ShowDialog()
        gwt_comm.GetCurrentPeriodRunDetails()
        MessageBox.Show("Payroll Run Completed Successfully", "Payroll Run Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
CloseRoutine:
        'Close all the opn files
        'objTemporaryRunFile.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Payroll Run Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Sub InitializePayrollRun()
        On Error GoTo RaiseErr
        'Request for a backup of the current files
        Dim f As New frmRunBackup 'frmDatabaseBackup '
        f.Text = "Pre Run File Backups"
        f.ShowDialog()
        'Initialize the payroll runfile table
        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeRunCodes", cnn)
        sqlCommand.ExecuteNonQuery()

        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeRunFile", cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Run Initialization"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub UpdateCalendar()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("UPDATE SystemCalendar SET " _
            & "RunStatus = 'Y' WHERE TaxPeriod = " & intCurrentRunNumber & "", cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Calendar Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        frmRunMode.ShowDialog()
        If boolAbort = True Then Exit Sub
        intSelectedEmployeesCnt = ListView1.Items.Count
        ReDim strSelectedEmployees(0 To (intSelectedEmployeesCnt - 1))
        'Get the employees numbers of all the employees and populate to the array
        Dim n As Integer
        Dim LItem As ListViewItem
        Dim LItems As ListView.ListViewItemCollection
        LItems = ListView1.Items
        n = 0
        For Each LItem In LItems
            strSelectedEmployees(n) = LItem.SubItems(0).Text
            n = n + 1
        Next
        ProcessPayrollControl()
        Me.Close()
    End Sub

    Private Sub btnCloseNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseNow.Click
        Me.Close()
    End Sub

    Private Sub UpdateBatchHistory()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [EntryLineNo],[BatchNo],[EmployeeNo],[Amount],[TransDate],[CodeNo]" _
            & ",[CostCode],[UserName],[EffectivePeriod],[Class] FROM [EmployeeBatches]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            strSql = "INSERT INTO [EmployeeBatches]([EntryLineNo],[BatchNo],[EmployeeNo],[Amount]" _
               & ",[TransDate],[CodeNo],[CostCode],[UserName],[EffectivePeriod]" _
               & ",[Class]) VALUES (" & objReader(0).ToString & "" _
               & "," & objReader(1).ToString & ", '" & objReader(2).ToString & "'" _
               & "," & objReader(3).ToString & ", '" & objReader(4).ToString & "'" _
               & "," & objReader(5).ToString & ", '" & objReader(6).ToString & "'" _
               & ",'" & objReader(7).ToString & "', " & objReader(8).ToString & "" _
               & "," & objReader(9).ToString & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Batch History Update"
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub frmPayrollRuns_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 541 : Me.Height = 178
    End Sub
End Class