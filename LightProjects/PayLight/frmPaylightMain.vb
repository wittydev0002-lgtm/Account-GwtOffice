Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing.Text
Imports System.IO
Imports System.Text

Public Class frmPaylightMain

    Dim strCurrentProcessingEmployee As String
    Dim strReportHeader As String
    Dim intPayslipFormat As Integer
    Dim itm As Integer

    Dim fntPrintFont As New Font("Arial", 7, FontStyle.Regular)
    Dim titleFont As New Font("Arial", 8, FontStyle.Bold)
    Public HeadingFont As New Font("Arial", 12, FontStyle.Bold)
    Dim fntSmallPrintFont As New Font("Arial", 7, FontStyle.Bold)
    Dim fntSmallPrintFontRegular As New Font("Arial", 7, FontStyle.Regular)
    Dim SubHeadingFont As New Font("Arial", 7, FontStyle.Bold)
    Dim fntFooter As New Font("Arial", 6, FontStyle.Bold)
    'our user defined report has six columns in each page which are declared here
    Dim X1, X2, X3, X4, X5, X6 As Integer
    Dim W1, W2, W3, W4, W5, W6 As Integer
    Dim Y As Integer

    Dim nz As Integer 'item line counter
    Dim strPayslipColumnType As String
    Dim sPayslipLineText() As String
    Dim strSummaryColumnType As String
    Dim sSummaryLineText() As String
    Dim strCurrentEmployeeBeingProcessed As String
    Dim strCurrentEmployeeBankDetails As String
    Dim strCurrentEmployeeBeingProcessedArray() As String
    Dim strCurrentEmployeeBankDetailsArray() As String
    Dim strCurrentEmployeeEmploymentDetails As String
    Dim strCurrentEmployeeEmploymentDetailsArray() As String
    Dim objPayslipRunfile As StreamReader
    Dim strRunfText As String
    Dim intPrintCodes() As Integer
    Dim intPrintValues() As Double
    Dim strRunfLine() As String
    Dim boolNewPage As Boolean = True
    Dim pageNum As Integer
    Dim dblSummaryTotals() As Double
    Dim dblGroupTotals() As Double

    Dim strNewPrintDetails As New ArrayList
    Dim strMyNewPrintLine As String

    Dim dblFinalGrossSalaryTotal As Double
    Dim dblFinalTotalDeductionsTotal As Double
    Dim dblFinalNetSalaryTotal As Double

    Dim dblGroupGrossSalaryTotal As Double
    Dim dblGroupNetSalaryTotal As Double
    Dim dblGroupTotalDeductionsTotal As Double

    Dim boolPrintingFinalPage As Boolean = False
    Dim boolPrintFromPreview As Boolean
    Dim boolPrintingCommerced As Boolean
    Dim strSortBreak As String
    Dim boolStarting As Boolean

    Dim boolStartPrint As Boolean
    Dim intPrintRecordsCount As Integer
    Dim strEmployeeFields As New ArrayList
    Dim strBankDetails As New ArrayList
    Dim strKeyBreak As String
    Dim strBnkSortCode() As String

    Dim strFinalPrintLine As ArrayList 'The record lines from which the payroll summary prints from
    Dim strDetailPrintLine() As String 'Used to split the print details line
    Dim strEmployeeIdentificationLine As String
    Dim boolOne As Boolean

    Dim dblTransferAmount As Double
    Dim strPrintDetails As New ArrayList
    Dim strBatchPrintArray As ArrayList

    Dim intBatchLineCount As Integer
    Dim strBatchPrintDetails() As String

    Dim xp As PrintPreviewDialog


    'new brainco reporter variables

    Dim strPrintColumns As String = Nothing
    Dim strColumnHeaders As String = Nothing
    Dim strColumnSizes As String = Nothing
    Dim strColumnFormating As String = Nothing
    Dim strColumnAlignment As String = Nothing
    Dim strColumnTotals As String = Nothing
    Dim intColumns As Integer = 0

    'Declare and set the default fonts
    'Dim fntHeaderFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    'Dim fntDetailsFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    'Dim fntFooterFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Dim strHeaderFontName As String = "Arial"
    Dim strFooterFontName As String = "Arial"
    Dim strDetailFontName As String = "Arial"

    Dim intHeaderFontSize As Integer = 8
    Dim intFooterFontSize As Integer = 6
    Dim intDetailFontSize As Integer = 8

    Dim strHeaderFontFullNames As String = Chr(34) & "Arial" & Chr(34) & ", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point"
    Dim strFooterFontFullNames As String = Chr(34) & "Arial" & Chr(34) & ", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point"
    Dim strDetailFontFullNames As String = Chr(34) & "Arial" & Chr(34) & ", 6, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point"

    Dim strFooterForeColor As String = "Black"
    Dim strHeaderForeColor As String = "Black"
    Dim strDetailForeColor As String = "Black"

    Dim strGridLinesColor As String = "Black"
    Dim boolVerticalLines As Boolean = False
    Dim boolHorizontalLines As Boolean = False

    Dim boolPrintSummary As Boolean = False
    Dim boolDrawGraph As Boolean = False
    Dim boolPrintFinalTotals As Boolean = False

    Dim boolGroupData As Boolean = False
    Dim intBreakIndex As Integer = -1
    Dim strHighlights As String = Nothing
    Dim strPrintBorder As String = "False"
    Dim boolPrintBorder As Boolean = False
    Dim strBorderColor As String = "Black"
    Dim boolPreviewReport As Boolean
    Dim fntFinePrintFont As New Font("Verdana", 6, FontStyle.Regular)

    Private Sub frmPaylightMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadEmployeeData()
        LoadReports()
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
        ShowErrorMessage()
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

    Private Sub dGrid_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellDoubleClick
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

    Private Sub LoadReports()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT [ReportNo],[ReportName] FROM ListTypeParmsMain ORDER BY ReportName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridReports.Rows.Clear()
        While objReader.Read
            With dGridReports
                .Rows.Add(objReader(0), "List", objReader(1))
            End With
        End While
        objReader.Close()

        'Get the column reports
        strSql = "SELECT [ReportNo],[ReportName] FROM SystemColumnReportHeaders ORDER BY ReportName"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            With dGridReports
                .Rows.Add(objReader(0), "6 COLUMN", objReader(1))
            End With
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On User reports listing load"
        ShowErrorMessage()
    End Sub

    Private Sub btnSaveBatch_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveBatch.Click
        'Write the information read off the listview
        On Error GoTo RaiseErr
        'Allocate the batch number at this point
        If lblBatchNumber.Text = 0 Then
            GetNextBatchNumber()
            MessageBox.Show("You batch number is " & intCurrentBatchNumber, "Batch Number Control", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Not IsNumeric(lblBatchNumber.Text) Then
                MessageBox.Show("The batch you are trying to update does not exist", "Invalid Batch Number",
                                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                intCurrentBatchNumber = CInt(lblBatchNumber.Text)
            End If
        End If

        Dim intNumberOfEntries As Integer = 0

        'Delete any transactions for this batch if they exist at all
        Dim strSql As String = "DELETE FROM EmployeeBatches WHERE BatchNo = " & intCurrentBatchNumber & " AND " _
            & "PayrollNo = " & intPayrollNumber & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "DELETE FROM SystemBatchesControl WHERE BatchNo = " & intCurrentBatchNumber & " AND " _
            & "PayrollNo = " & intPayrollNumber & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Dim dblTotals As Double = 0
        For i = 0 To dGridTransactions.Rows.Count - 1
            Dim strEc As String = Nothing
            Dim dblValue As String = 0
            Dim intCode As Integer = 0
            If Not Object.Equals(dGridTransactions.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridTransactions.Rows(i).Cells(0).Value.ToString) Then
                    strEc = dGridTransactions.Rows(i).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGridTransactions.Rows(i).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridTransactions.Rows(i).Cells(2).Value.ToString) Then
                    If IsNumeric(dGridTransactions.Rows(i).Cells(2).Value.ToString) Then
                        dblValue = CDbl(dGridTransactions.Rows(i).Cells(2).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGridTransactions.Rows(i).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridTransactions.Rows(i).Cells(1).Value.ToString) Then
                    If IsNumeric(dGridTransactions.Rows(i).Cells(1).Value.ToString) Then
                        intCode = CDbl(dGridTransactions.Rows(i).Cells(1).Value.ToString)
                    End If
                End If
            End If
            If Not String.IsNullOrEmpty(strEc) Then
                If intCode <> 0 Then
                    strSql = "INSERT INTO EmployeeBatches (EntryLineNo, BatchNo, " _
                        & "EmployeeNo, Amount, TransDate, CodeNo, CostCode, " _
                        & "UserName, EffectivePeriod, Class, PayrollNo) VALUES (" & (i + 1) & ", " _
                        & "" & intCurrentBatchNumber & ", '" & strEc & "', " _
                        & "" & dblValue & ", '" & Format(Now, "dd-MMM-yyyy") & "', " _
                        & "" & intCode & ", " _
                        & "'', '" & strUserName & "', 0, 1, " & intPayrollNumber & ")"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                    dblTotals = dblTotals + dblValue 'CDbl(dGridTransactions.Rows(i).Cells(2).Value.ToString)
                    intNumberOfEntries = intNumberOfEntries + 1
                End If
            End If
        Next

        'Write the batch control values
        Dim sqlBatchesCommand As New Data.OleDb.OleDbCommand("INSERT INTO SystemBatchesControl " _
            & "(BatchNo, CreationDate, Author, Status, BatchTotal, NumberOfEntries) VALUES (" _
            & "" & intCurrentBatchNumber & ", '" & Format(Now, "dd-MMM-yyyy") & "', '" & strPublicActiveFullUserName & "', 'NOT PROCESSED', " _
            & "" & dblTotals & ", " & intNumberOfEntries & ")", cnn)
        sqlBatchesCommand.ExecuteNonQuery()
        MessageBox.Show("The batch has been successfully written to file", "Payroll Batches Save", MessageBoxButtons.OK, MessageBoxIcon.Information)

        dGridTransactions.Rows.Clear()
        dGridTransactions.Rows.Add(100)

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Batch Transactions Save"
        ShowErrorMessage()
    End Sub

    Private Sub btnNewBatch_Click(sender As System.Object, e As System.EventArgs) Handles btnNewBatch.Click
        dGridTransactions.Rows.Clear()
        dGridTransactions.Rows.Add(100)
    End Sub

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGridTransactions_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridTransactions.CellEndEdit

        If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Then
            If Not Object.Equals(dGridTransactions.CurrentCell.Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridTransactions.CurrentCell.Value.ToString) Then
                    If e.ColumnIndex = 1 Then
                        If IsNumeric(dGridTransactions.CurrentCell.Value) Then
                            dGridTransactions.CurrentCell.Value = Format(CDbl(dGridTransactions.CurrentCell.Value.ToString), "##0")
                        End If
                    Else
                        If IsNumeric(dGridTransactions.CurrentCell.Value) Then
                            dGridTransactions.CurrentCell.Value = Format(CDbl(dGridTransactions.CurrentCell.Value.ToString), "000")
                        End If
                    End If
                    DisplayDescriptions(e.ColumnIndex, dGridTransactions.CurrentCell.Value.ToString)
                End If
            End If
        Else
            If e.ColumnIndex = 2 Then
                If Not Object.Equals(dGridTransactions.CurrentCell.Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridTransactions.CurrentCell.Value.ToString) Then
                        If IsNumeric(dGridTransactions.CurrentCell.Value) Then
                            dGridTransactions.CurrentCell.Value = Format(CDbl(dGridTransactions.CurrentCell.Value.ToString), "##0.00")
                            ComputeBatchTotals()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dGridTransactions_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridTransactions.EditingControlShowing
        Try
            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                'In order to prevent optical problems, we had to call the removeHandler twice
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DisplayDescriptions(ByVal ColumnNumber As Integer, ByVal strColumnValue As String)

        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        If ColumnNumber = 1 Then
            If Not IsNumeric(strColumnValue) Then strColumnValue = "0"
            objCommand = New Data.OleDb.OleDbCommand("SELECT Description FROM SystemCodes WHERE CodeNo = " & strColumnValue & "", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then dGridTransactions.CurrentRow.Cells(4).Value = objReader(0).ToString
            Else
                MessageBox.Show("Code entered does not exist in the system", "Invalid Code Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dGridTransactions.CurrentCell.Value = "0"
            End If
            objReader.Close()
        End If
        If ColumnNumber = 0 Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName FROM EmployeeMaster WHERE EmployeeNo = '" & strColumnValue & "'", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then dGridTransactions.CurrentRow.Cells(3).Value = objReader(0).ToString
            Else
                MessageBox.Show("Employee number entered does not exist in the system", "Invalid Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dGridTransactions.CurrentCell.Value = Nothing
            End If
            objReader.Close()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to get description for the entered field"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeBatchTotals()
        On Error GoTo RaiseErr
        Dim dblTotalAmount As Double = 0
        For p As Integer = 0 To dGridTransactions.Rows.Count - 1
            If Not Object.Equals(dGridTransactions.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridTransactions.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGridTransactions.Rows(p).Cells(2).Value.ToString) Then
                        dblTotalAmount = dblTotalAmount + CDbl(dGridTransactions.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
            End If
        Next
        lblBatchTotal.Text = Format(dblTotalAmount, "##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Batch amounts total computation"
        ShowErrorMessage()
    End Sub

    Private Sub btnViewBatch_Click(sender As System.Object, e As System.EventArgs) Handles btnViewBatch.Click
        intSelectedBatchNumber = 0
        Dim frm As New frmTransactionBatchesListing
        frm.ShowDialog()
        If intSelectedBatchNumber <> 0 Then
            lblBatchNumber.Text = intSelectedBatchNumber
            LoadSelectedBatchTransactions(intSelectedBatchNumber)
        End If
    End Sub

    Private Sub LoadSelectedBatchTransactions(BatchNumber As Integer)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT EmployeeNo, CodeNo, Amount FROM EmployeeBatches " _
            & "WHERE BatchNo = " & BatchNumber & " AND PayrollNo = " & intPayrollNumber & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim p As Integer = 0
        While objReader.Read
            Dim strEcnum As String = Nothing
            Dim intCode As Integer = 0
            Dim dblValue As Double = 0
            If Not IsDBNull(objReader(0).ToString) Then
                strEcnum = objReader(0).ToString
            End If
            If Not IsDBNull(objReader(1).ToString) Then
                If IsNumeric(objReader(1).ToString) Then
                    intCode = CInt(objReader(1).ToString)
                End If
            End If
            If Not IsDBNull(objReader(2).ToString) Then
                If IsNumeric(objReader(2).ToString) Then
                    dblValue = CDbl(objReader(2).ToString)
                End If
            End If
            With dGridTransactions
                .Rows(p).Cells(0).Value = strEcnum
                .Rows(p).Cells(1).Value = intCode
                .Rows(p).Cells(2).Value = dblValue
            End With
            p = p + 1
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Batch details load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadEmployeeDetailsForPayment()
        'read the employee file and populate the grid with only active employees
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT EmployeeNo AS [Employee #], " _
            & "LastName AS [Last Name], FirstName AS [First Name], OtherNames AS [Other Names] " _
            & "FROM EmployeeMaster WHERE Status = 'Active' ORDER BY EmployeeNo"

        dGridEmployeeToPay.Columns.Clear()
        Me.dGridEmployeeToPay.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridEmployeeToPay.DataSource = dTable
        dGridEmployeeToPay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        lblActiveEmployees.Text = dGridEmployeeToPay.RowCount
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Active Employee Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnPreparePayrun_Click(sender As Object, e As System.EventArgs) Handles btnPreparePayrun.Click
        LoadEmployeeDetailsForPayment()
    End Sub

    Private Sub btnProcessPay_Click(sender As System.Object, e As System.EventArgs) Handles btnProcessPay.Click
        If dGridEmployeeToPay.Rows.Count <= 0 Then
            MessageBox.Show("No employees have been prepared for payment",
                "Zero Employees To Pay", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        boolAbort = True
        Dim frm As New frmRunMode
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        intSelectedEmployeesCnt = CInt(lblActiveEmployees.Text)
        ReDim strSelectedEmployees(0 To (intSelectedEmployeesCnt - 1))
        'Get the employees numbers of all the employees and populate to the array
        For n As Integer = 0 To dGridEmployeeToPay.RowCount - 1
            strSelectedEmployees(n) = dGridEmployeeToPay.Rows(n).Cells(0).Value.ToString
        Next
        ProcessPayrollControl()
        Cursor = Cursors.Default
    End Sub

    '=======PAYROLL RUN MODULES==================

    Public Sub ProcessPayrollControl()
        'On Error GoTo RaiseErr
        boolAbort = False
        'First Get the neccessary resources from the files to run the payroll
        'First make a backup of the post run
        InitializePayrollRun()
        If boolAbort = True Then boolAbort = False

        With gwt_comm
            .AssignSystemCodes()
            If boolAbort = True Then Exit Sub
            .BalanceDeductionCodes()
            If boolAbort = True Then Exit Sub
            .AssignSystemMasterFields()
            If boolAbort = True Then Exit Sub
            .LoadCalculationsToArray()
            If boolAbort = True Then Exit Sub
            'TableValues()
            If boolAbort = True Then Exit Sub
            .CheckCalendar()
            If boolAbort = True Then Exit Sub
            .InitializeExceptionFile()
            If boolAbort = True Then Exit Sub
            .GetKeyDataFields()
            If boolAbort = True Then Exit Sub
            .AssignTrekkedFields()
            If boolAbort = True Then Exit Sub
            .AssignYearToDates()
            If boolAbort = True Then Exit Sub
            .AssignBatchesToArray()
            If boolAbort = True Then Exit Sub
            .LoadConstantsToArray()
            If boolAbort = True Then Exit Sub
            .GetTaxTables()
            If boolAbort = True Then Exit Sub
        End With

        Dim p As Integer
        Me.ProgressBarItem1.Value = 0
        Me.ProgressBarItem1.Visible = True
        Me.ProgressBarItem1.Maximum = intSelectedEmployeesCnt
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
            Me.ProgressBarItem1.Value = Me.ProgressBarItem1.Value + 1
        Next

        'Update the current run period to Y
        UpdateCalendar()

        'Clear payroll batches
        Dim objClearBatches As Data.OleDb.OleDbCommand
        objClearBatches = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeBatches", cnn)
        objClearBatches.ExecuteNonQuery()

        'If MessageBox.Show("Do you want to clear the current payroll batches or move them to batch buffer?" & vbCrLf &
        '    "Press YES to clear without saving. Otherwise press NO to save and then clear", "Confirm Batch Clearance",
        '    MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
        '    objClearBatches = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeBatches", cnn)
        '    objClearBatches.ExecuteNonQuery()
        'Else
        '    'move them to the batches trek file
        '    UpdateBatchHistory()
        '    objClearBatches = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeBatches", cnn)
        '    objClearBatches.ExecuteNonQuery()
        'End If
        'Request for the postrun backup

        boolAbort = False
        gwt_comm.BackupDatabase()
        If boolAbort = True Then Exit Sub
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
        ShowErrorMessage()
    End Sub

    Sub InitializePayrollRun()
        On Error GoTo RaiseErr
        'Request for a backup of the current files
        boolAbort = False
        gwt_comm.BackupDatabase()
        If boolAbort = True Then Exit Sub
        'Initialize the payroll runfile table
        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeRunCodes", cnn)
        sqlCommand.ExecuteNonQuery()

        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeRunFile", cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Run Initialization"
        ShowErrorMessage()
        boolAbort = True
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
        ShowErrorMessage()
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
        ShowErrorMessage()
    End Sub

    Private Sub btnBankExtracts_Click(sender As System.Object, e As System.EventArgs) Handles btnBankExtracts.Click
        Dim frm As New frmBankExtract
        frm.ShowDialog()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadEmployeeData()
    End Sub

    Private Sub btnRefreshReports_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshReports.Click
        LoadReports()
    End Sub

    Private Sub btnDeleteReport_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteReport.Click
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to delete this report",
                           "Confirm Report Delete", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            If dGridReports.Rows.Count > 0 Then
                Dim strSql As String = Nothing
                Dim objCommand As Data.OleDb.OleDbCommand
                intSelectedReport = dGridReports.CurrentRow.Cells(0).Value.ToString
                strReportType = dGridReports.CurrentRow.Cells(1).Value.ToString
                Select Case UCase(strReportType)
                    Case Is = "6 COLUMN"
                        strSql = "DELETE FROM SystemColumnReportHeaders WHERE ReportNo  = " & intSelectedReport & ""
                    Case Is = "MULTI-COLUMN"
                        strSql = "DELETE FROM "
                    Case Is = "LIST"
                        strSql = "DELETE FROM ListTypeParmsMain WHERE ReportNo = " & intSelectedReport & ""
                End Select
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                MessageBox.Show("Report has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadReports()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On report delete"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintReport_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintReport.Click
        PrintSelectedReport()
    End Sub

    Private Sub PrintSelectedReport()
        If dGridReports.Enabled = True Then
            If dGridReports.Rows.Count > 0 Then
                intSelectedReport = CInt(dGridReports.CurrentRow.Cells(0).Value.ToString)
                Select Case UCase(dGridReports.CurrentRow.Cells(1).Value.ToString)
                    Case Is = "6 COLUMN"
                        gwt_comm.PrintColumnReport(intSelectedReport)
                    Case Is = "LIST"

                    Case Is = "MULTI-COLUMN"

                End Select

            End If
        End If
    End Sub

    Private Sub tvReports_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvReports.DoubleClick
        strReportHeader = UCase(tvReports.SelectedNode.Text)
        Select Case UCase(tvReports.SelectedNode.Text)

            Case Is = UCase("A5 Payslips")
                intPayslipFormat = 1
                PrintSmallPayslip()
            Case Is = UCase("A5 Payslips Format 2")
                intPayslipFormat = 2
                PrintSmallPayslip()
            Case Is = UCase("Employee Control")
                boolAbort = False
                Dim f As New frmPrintPayrollRegister
                f.ShowDialog()
                If boolAbort = True Then Exit Sub
                EmployeePayrollRegister(strSelectedEmployee)
            Case Is = UCase("Payroll Control Totals")
                PrintControlTotals()
            Case Is = UCase("Bank Transfer Schedule")
                boolAbort = False
                gwt_comm.DateSpecification()
                If boolAbort = True Then Exit Sub
                PrintBankSchedules()
            Case Is = UCase("Payroll Summary")
                PrintPayrollSummary()
            Case Is = UCase("Audit Trail")
                boolAbort = False
                Dim f As New frmAuditPrintSpecification
                f.ShowDialog()
                If boolAbort = True Then Exit Sub
                PrintAuditReport()
            Case Is = UCase("Coinage Analysis")
                PrintCoinageAnalysis()
            Case Is = UCase("Tax Certificates")
                Dim f As New frmEmployeeTaxCertificates
                f.ShowDialog()
        End Select

    End Sub

    Private Sub dGridTransactions_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridTransactions.KeyDown
        If e.KeyValue = Keys.F3 Then
            If dGridTransactions.CurrentCell.ColumnIndex = 0 Then
                strPublicItemCode = Nothing
                strFullItemDetails = Nothing
                boolAbort = False
                gwt_comm.EmployeeSearch()
                If boolAbort = True Then Exit Sub
                dGridTransactions.CurrentRow.Cells(3).Value = strSelectedAccountName
                dGridTransactions.CurrentRow.Cells(0).Value = strSelectedAccount
                dGridTransactions.CurrentCell = dGridTransactions.Rows(dGridTransactions.CurrentRow.Index).Cells(1)
            End If
        End If
    End Sub

    Public Sub PrintAuditReport()
        On Error GoTo RaiseErr
        'Check that the variables are correctly set
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        If UCase(strSelectedValue) = "ALL" Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, " _
                & "ChangeDate, 105) as [ChangeDate], UserNAme, ElementId, ValueBefore, " _
                & "ValueAfter FROM Audit ORDER BY TransactionId", cnn)
        Else
            objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, " _
                & "ChangeDate, 105) as [ChangeDate], UserNAme, ElementId, ValueBefore, " _
                & "ValueAfter FROM Audit WHERE ChangeDate BETWEEN '" & strReportStartDate & "' " _
                & "AND '" & strReportEndDate & "' ORDER BY TransactionId", cnn)
        End If
        objReader = objCommand.ExecuteReader

        Dim arrPrintResults As New ArrayList
        While objReader.Read
            Dim str1 As String = Nothing, str2 As String = Nothing, str3 As String = Nothing
            Dim str4 As String = Nothing, str5 As String = Nothing
            If Not IsDBNull(objReader(0).ToString) Then str1 = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then str2 = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then str3 = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then str4 = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then str5 = objReader(4).ToString
            arrPrintResults.Add(str1 & ";" & str2 & ";" & str3 & ";" & str4 & ";" & str5)
        End While
        objReader.Close()

        Dim strPrintValues(0 To arrPrintResults.Count - 1) As String

        For i = 0 To arrPrintResults.Count - 1
            strPrintValues(i) = arrPrintResults.Item(i)
        Next

        Dim myReport As New SmartColumnReportWriter.SmartColumnReportWriter
        Dim DocumentPreview As New PrintPreviewDialog

        'Build the print details string based on the checked fields
        'For each column value, remove the semicolon so that the class does not fall over
        With Me.ProgressBarItem1
            .Visible = True
            .Value = 0
            .Maximum = strPrintValues.Length
        End With
        'lblStatus.Text = "Processing Report. Please Wait !!!"

        Cursor = Cursors.WaitCursor

        Me.ProgressBarItem1.Value = Me.ProgressBarItem1.Maximum
        With myReport
            .intNumberOfColumns = 5
            .intPrintRecordsCount = strPrintValues.Length   'Or number of records in the text file
            .strColumnAlignments = "0|0|0|0|0"
            .strColumnFormating = "NO|NO|NO|NO|NO"
            .strColumnHeaders = "DATE|OPERATOR|DESCRIPTION|BEFORE|AFTER"
            .strColumnWidths = "80|80|150|150|150"
            .strColumnTotals = "NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .boolPrintTotals = boolPrintFinalTotals
            .BorderColor = Color.FromName("LightGray")
            .GridColor = Color.FromName("LightGray")
            .strPrintValues = strPrintValues
            .strMainCaption = UCase(strDefaultReportHeader)
            .strMainHeader2 = "AUDIT REPORT PRINT: PERIOD " & strReportPeriod & " RUN " & intReportRunNumber
            If UCase(strSelectedValue) = "ALL" Then
                .strMainHeader3 = "ALL RECORDS PRINT"
            Else
                .strMainHeader3 = "SELECTED RANGE FROM " & strReportStartDate & " TO " & strReportEndDate
            End If
            .strFooterCaption = "Audit Trail Print"
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Gray
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
        End With
        Me.ProgressBarItem1.Visible = False
        Cursor = Cursors.Default
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        DocumentPreview.Document = myReport
        DocumentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Audit Report Generation Error"
        ShowErrorMessage()
    End Sub

    Public Sub PrintPayrollSummary()
        'Payroll summary
        On Error GoTo RaiseErr
        boolAbort = False
        ' DepartmentSurnameSort("Department/Surname")
        'If boolAbort = True Then Exit Sub
        Dim f As New frmPayrollSummarySortOptions
        f.ShowDialog()
        If boolAbort = True Then Exit Sub

        Cursor = Cursors.WaitCursor

        gwt_comm.PayrollSummaryPrintCodes()
        If boolAbort = True Then Exit Sub

        gwt_comm.AssignProcessedEmployeeNumbers()
        If boolAbort = True Then Exit Sub

        '******************* THIS PROCEDURE IS NOT AVAILABLE IN THIS VERSION **************************
        '**                                                                                          ** 
        '** GetKeyDataFields()                                                                       **
        '** If boolAbort = True Then Exit Sub                                                        **
        '**********************************************************************************************


        'ReadSortFileData()
        boolAbort = False
        gwt_comm.AssignCompanyDetails()
        If boolAbort = True Then Exit Sub

        gwt_comm.GetReportTaxPeriodNumber()

        If boolAbort = True Then Exit Sub

        boolPrintFromPreview = False
        itm = 0 : nz = 0 : dblFinalGrossSalaryTotal = 0 : dblFinalTotalDeductionsTotal = 0 : dblFinalNetSalaryTotal = 0
        pageNum = 1
        'initialize the totals array
        Dim p As Integer
        ReDim dblSummaryTotals(0 To (strSummaryLineCodes.Length - 1))
        ReDim dblGroupTotals(0 To (strSummaryLineCodes.Length - 1))
        ReDim intPrintCodes(0 To (strSummaryLineCodes.Length - 1))
        ReDim intPrintValues(0 To (strSummaryLineCodes.Length - 1))
        For p = 0 To strSummaryLineCodes.Length - 1
            dblSummaryTotals(p) = 0
            dblGroupTotals(p) = 0
        Next

        boolNewPage = True : boolPrintingFinalPage = False
        strSortBreak = "" : boolStarting = False
        CreatePrintArray()
        If boolAbort = True Then Exit Sub

        'Use the brainco smart reporter
        '
        'THE REPORT FORMAT IS AS FOLLOWS
        '
        'GetCompanyDetails()
        Dim intRecordsCount As Integer = strNewPrintDetails.Count
        Dim strPrintDetails(0 To (intRecordsCount - 1)) As String
        If intRecordsCount <= 0 Then
            MessageBox.Show("No details to print", "No Print Records", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If


        'Select the details from the temp summary table
        Dim strSqlStatement As String = Nothing

        Dim strPrintDetails2(0 To (strNewPrintDetails.Count - 1)) As String

        For p = 0 To strNewPrintDetails.Count - 1
            strPrintDetails2(p) = UCase(strNewPrintDetails.Item(p))
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 8
            .strColumnHeaders = "EMPLOYEE|EARNINGS|UNITS|AMOUNT|DEDUCTIONS|UNIT|AMOUNT|"
            .strColumnAlignments = "0|0|2|2|0|2|2|0"
            .strColumnWidths = "120|120|70|75|120|70|75|0"
            .strFooterCaption = "Powered by Brainco Software Solutions"
            .strMainCaption = UCase(strDefaultReportHeader)
            .strMainHeader2 = "PAYROLL SUMMARY FOR " & UCase(strCompanyName)
            .strMainHeader3 = "PERIOD " & strReportPeriod & " RUN " & intReportRunNumber & " BETWEEN " & UCase(strReportStartDate) & " AND " & UCase(strReportEndDate)
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .AlternateBackColor = Color.WhiteSmoke
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .RestartPageNumbersOnGroupChange = True
            .boolPrintTotals = False
            .boolGenericReport = True
            .intBreakIndex = 7
            .intKeyFieldIndex = 7
            .strColumnFormating = "NO|NO|YES|YES|NO|YES|YES|NO"
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails2
        End With
        ppd.Document = rpt
        ppd.ShowDialog()
        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Summary Print"
        ShowErrorMessage()
        boolAbort = True
    End Sub

    Public Sub PrintBankSchedules()
        'Will print the bank schedules in the order of banks
        '***************************************************************************************************
        'LOGIC
        '
        'Get the bank file information, the bankcode, name and address
        'Get all the employees with the bank status on and put them in an array sorted by bank code
        'Build a new array list containg the bank code, bank name, employee names, account number and net salary
        '
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        'Get all the employees with the bank status set to 
        objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT EmployeeBanks.EmployeeNo, " _
            & "EmployeeMaster.LastName, EmployeeMaster.Inits, EmployeeBanks.BankCode, " _
            & "SystemBanks.BankName, SystemBanks.Address1, SystemBanks.Address2, " _
            & "SystemBanks.Address3, SystemBanks.Address4, EmployeeBanks.AccountNumber, " _
            & "EmployeeBanks.PayMethod  FROM EmployeeBanks LEFT JOIN EmployeeMaster ON " _
            & "EmployeeBanks.EmployeeNo = EmployeeMaster.EmployeeNo LEFT JOIN SystemBanks " _
            & "ON CONVERT(INT, EmployeeBanks.BankCode ) = CONVERT(INT, SystemBanks.BankCode) " _
            & "WHERE PayMethod = 'BANK' AND EmployeeMaster.Status = 'ACTIVE' " _
            & "ORDER BY EmployeeBanks.BankCode", cnn)
        objReader = objCommand.ExecuteReader

        'Get the key data fields to get the net salary code

        gwt_comm.GetKeyDataFields()

        Dim arrBankSchedule As New ArrayList
        Dim i As Integer
        Dim intCounter As Integer = 1
        Dim strBankCode As String = Nothing
        '
        'Build the ouput string to be handled by the reporting class
        '
        Dim strKeyBreak As String = Nothing
        Dim dblTransferTotal As Double = 0
        While objReader.Read
            Dim strEcNum As String = Nothing
            Dim strEmpSurnames As String = Nothing
            Dim strEmpInitials As String = Nothing
            Dim strBankName As String = Nothing
            Dim strBankAddress1 As String = Nothing
            Dim strBankAddress2 As String = Nothing
            Dim strBankAddress3 As String = Nothing
            Dim strBankAddress4 As String = Nothing
            Dim strEmpAccountNumber As String = Nothing
            Dim dblNetSalary As Double = 0
            If Not IsDBNull(objReader("EmployeeNo").ToString) Then strEcNum = objReader("EmployeeNo").ToString
            If Not IsDBNull(objReader("LastName").ToString) Then strEmpSurnames = objReader("LastName").ToString
            If Not IsDBNull(objReader("Inits").ToString) Then strEmpInitials = objReader("Inits").ToString
            If Not IsDBNull(objReader("BankCode").ToString) Then strBankCode = objReader("BankCode").ToString Else strBankCode = Nothing
            If Not IsDBNull(objReader("BankName").ToString) Then strBankName = objReader("BankName").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then strBankAddress1 = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then strBankAddress2 = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then strBankAddress3 = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then strBankAddress4 = objReader("Address4").ToString
            If Not IsDBNull(objReader("AccountNumber").ToString) Then strEmpAccountNumber = objReader("AccountNumber").ToString
            '
            'Get the employee net salary from the run file
            '
            Dim objCommandNet As New Data.OleDb.OleDbCommand("SELECT RunAmounts FROM EmployeeRunFile WHERE EmployeeNo = '" & strEcNum & "'", cnn)
            Dim objReadNet As Data.OleDb.OleDbDataReader = objCommandNet.ExecuteReader
            If objReadNet.HasRows Then
                objReadNet.Read()
                Dim strBuffer() As String = Split(objReadNet(0).ToString, "|")
                If IsNumeric(strBuffer(intPayrollNetIncomeCode - 1)) Then
                    dblNetSalary = CDbl(strBuffer(intPayrollNetIncomeCode - 1))
                End If
                If dblNetSalary > 0 Then
                    'Check that the string break is different or not
                    If strKeyBreak <> strBankCode Then
                        If dblTransferTotal > 0 Then
                            arrBankSchedule.Add(" ; ; ; ; ; ;" & strKeyBreak)
                            arrBankSchedule.Add(" ;TOTAL TRANSFERED; ; ;" & Format(dblTransferTotal, "#,##0.00") & "; ;" & strKeyBreak)
                        End If
                        strKeyBreak = strBankCode
                        dblTransferTotal = 0
                        intCounter = 1
                        'Write the header lines before writing the details
                        arrBankSchedule.Add(" ;" & strBankCode & " " & strBankName & "; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ;" & strBankAddress1 & "; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ;" & strBankAddress2 & "; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ;" & strBankAddress3 & "; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ;" & strBankAddress4 & "; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ; ; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ; ; ; ; ; ;" & strBankCode)
                        arrBankSchedule.Add(" ; ; ; ; ; ;" & strBankCode)
                        'Print the column headers
                        arrBankSchedule.Add("EC NO.;SURNAME;INITS;ACCOUNT NO.;NET SALARY;REC.NO.;" & strBankCode)
                        arrBankSchedule.Add(" ; ; ; ; ; ;" & strBankCode)
                        'Print the first detail line
                        arrBankSchedule.Add(strEcNum & ";" & strEmpSurnames & ";" & strEmpInitials & ";" & strEmpAccountNumber & ";" & Format(dblNetSalary, "#,##0.00") & ";" & Format(intCounter, "0000") & ";" & strBankCode)

                        dblTransferTotal = dblTransferTotal + dblNetSalary
                    Else
                        arrBankSchedule.Add(strEcNum & ";" & strEmpSurnames & ";" & strEmpInitials & ";" & strEmpAccountNumber & ";" & Format(dblNetSalary, "#,##0.00") & ";" & Format(intCounter, "0000") & ";" & strBankCode)
                        dblTransferTotal = dblTransferTotal + dblNetSalary
                        intCounter = intCounter + 1
                    End If
                End If
            End If
        End While
        '
        'At the end, add the total line for the last branch code
        If dblTransferTotal > 0 Then
            arrBankSchedule.Add(" ; ; ; ; ; ;" & strBankCode)
            arrBankSchedule.Add(" ;TOTAL TRANSFERED; ; ;" & Format(dblTransferTotal, "#,##0.00") & "; ;" & strBankCode)
        End If
        objReader.Close()

        '
        'Send the details for printing
        '
        Dim strTransferDetails(0 To arrBankSchedule.Count - 1) As String
        For i = 0 To arrBankSchedule.Count - 1
            strTransferDetails(i) = arrBankSchedule.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .NewPageBreak = True
            .intPrintRecordsCount = strTransferDetails.Length
            .intNumberOfColumns = 7
            .strColumnHeaders = " | | | | | | "
            .strColumnAlignments = "0|0|0|0|2|0|0"
            .strColumnWidths = "80|200|40|80|80|40|80"
            .strFooterCaption = "Bank transfer schedule " & Now
            .strMainCaption = UCase(strDefaultReportHeader)
            .strMainHeader2 = "BANK TRANSFER SCHEDULES: PERIOD " & strReportPeriod & " RUN " & intReportRunNumber & " BETWEEN " & UCase(strReportStartDate) & " AND " & UCase(strReportEndDate)
            .strMainHeader3 = "TRANSFER EFFECTIVE ON " & UCase(Format(CDate(dtSetDate), "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
            .VerticalLines = False
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("LightGray")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .boolGroupDetails = True
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 6
            .strPrintValues = strTransferDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        ppd.Document = rpt
        ppd.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Bank Transfer Schedules Print"
        ShowErrorMessage()
    End Sub

    Public Sub PrintControlTotals()
        'Print and preview payroll control totals. The style is the same as that of the payroll register
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim arrPrintCodeValues As New ArrayList

        objCommand = New Data.OleDb.OleDbCommand("SELECT RunAmounts FROM EmployeeRunFile", cnn)
        objReader = objCommand.ExecuteReader
        '
        'Build only one string line for all the totals
        '
        Dim dblCodeTotals(0 To 0) As Double
        Dim cnt As Integer = 0
        Dim strSplitter() As String
        While objReader.Read
            strSplitter = Split(objReader(0).ToString, "|")
            If cnt = 0 Then
                ReDim dblCodeTotals(0 To (strSplitter.Length - 1))
            End If
            For n = 0 To strSplitter.Length - 1
                dblCodeTotals(n) = dblCodeTotals(n) + CDbl(strSplitter(n))
            Next
            cnt = cnt + 1
        End While
        objReader.Close()

        For n = 0 To dblCodeTotals.Length - 1
            Dim objCommandCodes As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, CodeNo) +';'+ Description AS [CodeDetails] FROM SystemCodes WHERE CodeNo = " & (n + 1) & "", cnn)
            Dim objReadCodes As Data.OleDb.OleDbDataReader = objCommandCodes.ExecuteReader
            objReadCodes.Read()
            If CDbl(dblCodeTotals(n)) <> 0 Then
                Dim strAmount As String = CStr(Format(CDbl(dblCodeTotals(n)), "#,##0.00"))
                Dim strDesc As String = objReadCodes(0).ToString
                arrPrintCodeValues.Add(strDesc & ";" & strAmount)
            End If
        Next

        If arrPrintCodeValues.Count > 0 Then
            'Format the code numbers first
            Dim z As Integer = 0
            For z = 0 To arrPrintCodeValues.Count - 1
                Dim strSplitted() As String = Split(arrPrintCodeValues.Item(z), ";")
                arrPrintCodeValues.Item(z) = CStr(Format(CInt(strSplitted(0)), "000")) & ";" & strSplitted(1) & ";" & strSplitted(2)
            Next
            'Call the BraincoSmartReport writer to handle the output
            Dim intRecordsCount As Integer = arrPrintCodeValues.Count
            Dim intIteration As Integer = 0
            If intRecordsCount Mod 2 = 0 Then
                intIteration = intRecordsCount / 2
            Else
                arrPrintCodeValues.Add(";;")
                intRecordsCount = intRecordsCount + 1
                intIteration = intRecordsCount / 2
            End If

            Dim strPrintDetails(0 To (intIteration - 1)) As String
            Dim y As Integer = 0
            For p = 0 To intIteration - 1
                strPrintDetails(p) = arrPrintCodeValues.Item(y) & ";;" & arrPrintCodeValues(y + 1)
                y = y + 2
            Next

            Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
            With rpt
                .intPrintRecordsCount = strPrintDetails.Length
                .intNumberOfColumns = 7
                .strColumnHeaders = "CODE|DESCRIPTION|AMOUNT| |CODE|DESCRIPTION|AMOUNT"
                .strColumnAlignments = "0|0|2|0|0|0|2"
                .strColumnWidths = "40|170|80|30|40|170|80"
                .strFooterCaption = "Employee payroll register " & Now
                .strMainCaption = UCase(strDefaultReportHeader)
                .strMainHeader2 = "PAYROLL CONTROL TOTALS: PERIOD " & strReportPeriod & " RUN " & intReportRunNumber & " BETWEEN " & UCase(strReportStartDate) & " AND " & UCase(strReportEndDate)
                .strMainHeader3 = ""
                .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO"
                .FooterColor = Color.FromName("Black")
                .TitleColor = Color.FromName("Black")
                .DetailColor = Color.FromName("Black")
                .DrawBorder = True
                .HorizontalLines = True
                .VerticalLines = True
                .GridColor = Color.Gray
                .BorderColor = Color.FromName("LightGray")
                .DetailFont = fntDetailsFont
                .HeaderFont = fntHeaderFont
                .FooterFont = fntFooterFont
                .boolGroupDetails = False
                .boolPrintTotals = False
                .boolGenericReport = False
                .boolPrintRecordCount = False
                .PrintSummary = False
                .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
                .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO"
                .intKeyFieldIndex = 0
                .strPrintValues = strPrintDetails
            End With
            ppdUserReports.Document = rpt
            ppdUserReports.ShowDialog()
        End If
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Payroll Control Totals Print"
        ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub PrintCoinageAnalysis()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim arrCoinage As New ArrayList
        Dim strArr() As String

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT EmployeeBanks.EmployeeNo, " _
            & "EmployeeMaster.LastName, EmployeeMaster.Inits, EmployeeBanks.PayMethod FROM EmployeeBanks LEFT JOIN " _
            & "EmployeeMaster ON EmployeeBanks.EmployeeNo = EmployeeMaster.EmployeeNo WHERE PayMethod = 'CASH' " _
            & "AND EmployeeMaster.Status = 'ACTIVE' ORDER BY EmployeeMaster.LastName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        gwt_comm.GetKeyDataFields()

        While objReader.Read

            'Get the employee net salary and pass it for spliting

            objCommand = New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeRunFile WHERE EmployeeNo = '" & objReader(0).ToString & "'", cnn)
            Dim objReadAmounts As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadAmounts.HasRows Then
                objReadAmounts.Read()

                Dim dblamout As Double = 0
                Dim strSplitAmounts() As String = Split(objReadAmounts("RunAmounts").ToString, "|")
                If IsNumeric(strSplitAmounts(intPayrollNetIncomeCode - 1)) Then
                    dblamout = CDbl(strSplitAmounts(intPayrollNetIncomeCode - 1))
                End If

                strArr = gwt_comm.Breakdown(CStr(Format(dblamout, "##0.00")))

                Dim strHundreds As String = "0"
                Dim strFifties As String = "0"
                Dim strTwenties As String = "0"
                Dim strTens As String = "0"
                Dim strFives As String = "0"
                Dim strTwos As String = "0"
                Dim strOnes As String = "0"
                Dim strFiftyCents As String = "0"
                Dim strTenCents As String = "0"
                Dim strFiveCents As String = "0"
                Dim strCents As String = "0"

                'Divide the number first with 100
                Dim y As Integer = Math.Floor(dblamout / 100)
                strHundreds = CStr(y)
                'Get the fifties by multiplying back the hundreds and subtracting from original figure
                Dim dblHundreds As Double = y * 100
                Dim dblFifties As Double = dblamout - dblHundreds
                y = Math.Floor(dblFifties / 50)
                strFifties = CStr(y)
                Dim dblTwenties As Double = dblamout - (CDbl(strHundreds) * 100 + CDbl(strFifties) * 50)
                y = Math.Floor(dblTwenties / 20)
                strTwenties = CStr(y)

                Dim dblTens As Double = dblamout - (CDbl(strHundreds) * 100 + CDbl(strFifties) * 50 + CDbl(strTwenties) * 20)
                y = Math.Floor(dblTens / 10)
                strTens = CStr(y)

                Dim dblFives As Double = dblamout - (CDbl(strHundreds) * 100 + CDbl(strFifties) * 50 + CDbl(strTwenties) * 20 + CDbl(strTens) * 10)
                y = Math.Floor(dblFives / 5)
                strFives = CStr(y)

                Dim dblTwos As Double = dblamout - (CDbl(strHundreds) * 100 + CDbl(strFifties) * 50 + CDbl(strTwenties) * 20 + CDbl(strTens) * 10 + CDbl(strFives) * 5)
                y = Math.Floor(dblTwos / 2)
                strTwos = CStr(y)

                Dim dblOnes As Double = dblamout - (CDbl(strHundreds) * 100 + CDbl(strFifties) * 50 + CDbl(strTwenties) * 20 + CDbl(strTens) * 10 + CDbl(strFives) * 5 + CDbl(strTwos) * 2)
                y = Math.Floor(dblOnes / 1)
                strOnes = CStr(y)

                'Get the cents values
                Dim dblAmountsInCents As Double = CDbl(strArr(strArr.Length - 2) & strArr(strArr.Length - 1))

                y = Math.Floor(dblAmountsInCents / 50)
                strFiftyCents = CStr(y)

                'Get the 10 cents
                Dim dblTenCents As Double = dblAmountsInCents - (CDbl(strFiftyCents) * 50)
                y = Math.Floor(dblTenCents / 10)
                strTenCents = CStr(y)

                'Get the 5 cents
                Dim dblFiveCents As Double = dblAmountsInCents - (CDbl(strFiftyCents) * 50 + CDbl(strTenCents) * 10)
                y = Math.Floor(dblFiveCents / 5)
                strFiveCents = CStr(y)

                'Get the last cents
                Dim dblCents As Double = dblAmountsInCents - (CDbl(strFiftyCents) * 50 + CDbl(strTenCents) * 10 + CDbl(strFiveCents) * 5)
                y = Math.Floor(dblCents / 1)
                strCents = CStr(y)

                arrCoinage.Add(objReader(1) & " " & objReader(2) & " " & objReader(0) & ";" & strHundreds & ";" & strFifties & ";" & strTwenties & ";" & strTens & ";" & strFives & ";" _
                    & strTwos & ";" & strOnes & ";" & strFiftyCents & ";" & strTenCents & ";" & strFiveCents & ";" & strCents & ";" & Format(dblamout, "##0.00"))
            End If
            objReadAmounts.Close()
        End While
        objReader.Close()

        Dim strPrintDetails(0 To arrCoinage.Count - 1) As String

        For i As Integer = 0 To arrCoinage.Count - 1
            strPrintDetails(i) = arrCoinage.Item(i)
        Next

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 13
            .strColumnHeaders = "EMPLOYEE|100.00|50.00|20.00|10.00|5.00|2.00|1.00|0.50|0.10|0.05|0.01|NET"
            .strColumnAlignments = "0|2|2|2|2|2|2|2|2|2|2|2|2"
            .strColumnWidths = "120|40|40|40|40|40|40|40|40|40|40|40|60"
            .strFooterCaption = "COINAGE ANALYSIS - DETAILED"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "COINAGE ANAYLYSIS - " & UCase(strCompanyName)
            .strMainHeader3 = "PERIOD " & strReportPeriod & " RUN " & intReportRunNumber & " BETWEEN " & UCase(strReportStartDate) & " AND " & UCase(strReportEndDate)
            .strColumnTotals = "NO|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("LightGray")
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
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On coinage analysis print"
        ShowErrorMessage()
    End Sub

    Public Sub EmployeePayrollRegister(ByVal strEmpNumber As String)
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim arrPrintCodeValues As New ArrayList
        Dim strPersonalDetails As String = Nothing
        If Not String.IsNullOrEmpty(strEmpNumber) Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT RunAmounts FROM EmployeeRunFile WHERE EmployeeNo = '" & strEmpNumber & "'", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then
                    'Get the employee personal details
                    Dim objCommandPersonal As New Data.OleDb.OleDbCommand("SELECT EmployeeNo +' '+ LastName +' '+ Inits AS [Personal] FROM EmployeeMaster WHERE EmployeeNo = '" & strEmpNumber & "'", cnn)
                    Dim objReadPersonal As Data.OleDb.OleDbDataReader = objCommandPersonal.ExecuteReader
                    If objReadPersonal.HasRows Then
                        objReadPersonal.Read()
                        If Not IsDBNull(objReadPersonal(0).ToString) Then strPersonalDetails = objReadPersonal(0).ToString
                    End If
                    objReadPersonal.Close()
                    Dim strBuffer() As String = Split(objReader(0).ToString, "|")
                    Dim i As Integer = 0
                    For i = 0 To strBuffer.Length - 1
                        Dim objCommandCodes As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, CodeNo) +';'+ Description AS [CodeDetails] FROM SystemCodes WHERE CodeNo = " & (i + 1) & "", cnn)
                        Dim objReadCodes As Data.OleDb.OleDbDataReader = objCommandCodes.ExecuteReader
                        objReadCodes.Read()
                        If CDbl(strBuffer(i)) <> 0 Then
                            Dim strAmount As String = CStr(Format(CDbl(strBuffer(i)), "#,##0.00"))
                            Dim strDesc As String = objReadCodes(0).ToString
                            arrPrintCodeValues.Add(strDesc & ";" & strAmount)
                        End If
                        objReadCodes.Close()
                    Next
                End If
            End If
            objReader.Close()
        Else
            MessageBox.Show("Please enter the employee number for whom the register is to be printed",
                "Invalid Selective Print Option", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If arrPrintCodeValues.Count > 0 Then
            'Format the code numbers first
            Dim z As Integer = 0
            For z = 0 To arrPrintCodeValues.Count - 1
                Dim strSplitted() As String = Split(arrPrintCodeValues.Item(z), ";")
                arrPrintCodeValues.Item(z) = CStr(Format(CInt(strSplitted(0)), "000")) & ";" & strSplitted(1) & ";" & strSplitted(2)
            Next
            'Call the BraincoSmartReport writer to handle the output
            Dim intRecordsCount As Integer = arrPrintCodeValues.Count
            Dim intIteration As Integer = 0
            If intRecordsCount Mod 2 = 0 Then
                intIteration = intRecordsCount / 2
            Else
                arrPrintCodeValues.Add(";;")
                intRecordsCount = intRecordsCount + 1
                intIteration = intRecordsCount / 2
            End If

            Dim strPrintDetails(0 To (intIteration - 1)) As String
            Dim y As Integer = 0
            For p = 0 To intIteration - 1
                strPrintDetails(p) = arrPrintCodeValues.Item(y) & ";;" & arrPrintCodeValues(y + 1)
                y = y + 2
            Next

            Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
            With rpt
                .intPrintRecordsCount = strPrintDetails.Length
                .intNumberOfColumns = 7
                .strColumnHeaders = "CODE|DESCRIPTION|AMOUNT| |CODE|DESCRIPTION|AMOUNT"
                .strColumnAlignments = "0|0|2|0|0|0|2"
                .strColumnWidths = "40|170|80|30|40|170|80"
                .strFooterCaption = "Employee payroll register " & Now
                .strMainCaption = UCase(strDefaultReportHeader)
                .strMainHeader2 = "PAYROLL REGISTER: PERIOD " & strReportPeriod & " RUN " & intReportRunNumber & " BETWEEN " & UCase(strReportStartDate) & " AND " & UCase(strReportEndDate)
                .strMainHeader3 = strPersonalDetails
                .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO"
                .FooterColor = Color.FromName("Black")
                .TitleColor = Color.FromName("Black")
                .DetailColor = Color.FromName("Black")
                .DrawBorder = True
                .HorizontalLines = True
                .VerticalLines = True
                .GridColor = Color.Gray
                .BorderColor = Color.FromName("LightGray")
                .DetailFont = fntDetailsFont
                .HeaderFont = fntHeaderFont
                .FooterFont = fntFooterFont
                .boolGroupDetails = False
                .boolPrintTotals = False
                .boolGenericReport = False
                .boolPrintRecordCount = False
                .PrintSummary = False
                .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
                .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO"
                .intKeyFieldIndex = 0
                .strPrintValues = strPrintDetails
            End With
            Dim prnt As New PrintDialog
            prnt.ShowDialog()
            ppdUserReports.Document = rpt
            ppdUserReports.ShowDialog()
        End If
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Payroll Register Print"
        ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub PrintSmallPayslip()
        'payslip printing
        boolAbort = False
        boolDrawBorders = True
        Dim f As New frmDateSpecificationCustom
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        gwt_comm.GetKeyDataFields()
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignProcessedEmployeeNumbers() 'Read from the current run file
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignPersonalDetails()
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignBankingDetails()
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignEmploymentDetails()
        If boolAbort = True Then Exit Sub
        gwt_comm.AssignCompanyDetails()
        If boolAbort = True Then Exit Sub
        gwt_comm.GetPayslipDetails()
        If boolAbort = True Then Exit Sub
        itm = 0

        'Dim img As Icon
        'img = New Icon(Application.StartupPath & "\people.ico")
        'ppd.Icon = img
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        If intPayslipFormat = 2 Then
            ppd.Document = pdFormatTwo
        Else
            ppd.Document = pdSmallPayslips
        End If
        ppd.ShowDialog()
    End Sub

    Private Sub pdSmallPayslips_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdSmallPayslips.PrintPage
        'Resest
        On Error GoTo RaiseErr
        'If boolPrintFirstThreePayslips = True Then
        '    If itm > 2 Then
        '        e.HasMorePages = False
        '        itm = 0
        '        Exit Sub
        '    End If
        'End If
        HeadingFont = New Font("Arial", 7, FontStyle.Regular)
        Dim intStatsCount As Integer = 0
        Dim eLineCnt As Integer, dLineCnt As Integer, sLineCnt As Integer
        Dim intX1, intX2, intY1, intY2 As Integer
        intLeftMargin = 50 : intRightMargin = 100 : intTopMargin = 40 : intBottomMargin = 40
        intX1 = intLeftMargin ' e.PageBounds.Left + 50
        intX2 = e.PageBounds.Right - intRightMargin
        intY1 = intTopMargin ' e.PageBounds.Top + 100
        intY2 = 500 'e.PageBounds.Bottom - intBottomMargin
        nz = 0

        Dim str As String
        Dim strAmt As String
        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        'Draw the main border
        Dim sbCurrent As SolidBrush 'penCurrent As Pen
        reccurrent = New Rectangle(intX1, intY1, (intX2 - 43), intY2)
        If boolDrawBorders = True Then e.Graphics.DrawRectangle(Pens.Navy, reccurrent)
        Dim intRectangleWidth As Integer = reccurrent.Width
        'chech that it is not a blank payslip
        'If intPrintValues(CInt(intPayslipGrossSalaryCode - 1)) = 0 And _
        '        intPrintValues(CInt(intPayslipTotalDeductionsCode - 1)) = 0 And _
        '        intPrintValues(CInt(intPayslipNetSalaryCode - 1)) = 0 Then
        '    itm = itm + 1
        '    e.HasMorePages = True
        '    Exit Sub
        'End If


        'Print the company logo as a watermark
        If Not String.IsNullOrEmpty(strCompanyLogoPath) Then
            If System.IO.File.Exists(strCompanyLogoPath) Then
                Dim picPrint As New PictureBox
                picPrint.SizeMode = PictureBoxSizeMode.AutoSize
                picPrint.Load(strCompanyLogoPath)
                Dim R As New Rectangle(390, 280, picPrint.Width, picPrint.Height)
                'Dim R As New Rectangle(20, 20, picPrint.Width, picPrint.Height)
                e.Graphics.DrawImage(picPrint.Image, R)
            End If
        End If

        '*** Start Printing and drawing the prefixed item
        '*** the value start position of x = intX1 and that of y = intY1

        'Print the pay advice header
        If boolDrawBorders = True Then Call gwt_comm.DrawStringInBoxLeft(e, intX1, intY1 - 30, intX1 + 200, intY1 - 30, "PAY ADVICE", HeadingFont, Brushes.Black)
        If boolDrawBorders = True Then Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 400, intY1 - 30, intX1 + 600, intY1 - 30, "DOCUMENT NO: " & Format((itm + 1), "000000"), HeadingFont, Brushes.Black)
        'Print the company name and the pay date the same font as that for document no
        e.Graphics.DrawString(UCase(strCompanyName), HeadingFont, System.Drawing.Brushes.Black, intX1 + 1, intTopMargin + 10)
        e.Graphics.DrawString(UCase(Format(dtPayslip, "dd-MMM-yyyy")), HeadingFont, System.Drawing.Brushes.Black, intX1 + 570, intTopMargin + 10)
        'e.Graphics.DrawString("Powered by Embassy@Great Wits Technologies", fntSmallPrintFont, Brushes.Black, intX1, intY2 + ((intBottomMargin / 2) * 1.5))
        'Draw the 3 lines after
        intY1 = intY1 + 40
        If boolDrawBorders = True Then e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)
        'Print the headers
        intY1 = intY1 + 5
        If boolDrawBorders = True Then
            With e.Graphics
                .DrawString("PAYROLL", fntFinePrintFont, Brushes.Navy, intX1 + 1, intY1)
                .DrawString("PAYPOINT", fntFinePrintFont, Brushes.Navy, intX1 + 53, intY1)
                .DrawString("EMPLOYEE NO", fntFinePrintFont, Brushes.Navy, intX1 + 103, intY1)
                .DrawString("CLOCK NO", fntFinePrintFont, Brushes.Navy, intX1 + 175, intY1)
                .DrawString("TAX CODE", fntFinePrintFont, Brushes.Navy, intX1 + 235, intY1)
                .DrawString("COST CENTER", fntFinePrintFont, Brushes.Navy, intX1 + 293, intY1)
                .DrawString("BASIC RATE", fntFinePrintFont, Brushes.Navy, intX1 + 435, intY1)
                .DrawString("BANK ACCOUNT NUMBER", fntFinePrintFont, Brushes.Navy, intX1 + 531, intY1)
                'Draw the small box margins
                'right of payroll column header
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 50, intY1 - 5,
                                intX1 + 50, intY1 + 60)
                'right of paypoint column header
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 100, intY1 - 5,
                                intX1 + 100, intY1 + 60)
                'right of employee number column header
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 173, intY1 - 5,
                                intX1 + 173, intY1 + 60)
                'right of the clock number code column
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 233, intY1 - 5,
                                intX1 + 233, intY1 + 60)
                'right of the tax code code column
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 290, intY1 - 5,
                                intX1 + 290, intY1 + 60)
                'right of the cost center code column
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 432, intY1 - 5,
                                intX1 + 432, intY1 + 60)
                'right of the basic rate code column
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 528, intY1 - 5,
                                intX1 + 528, intY1 + 60)

                'The next 3 lines drop down further that the others
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 190, intY1 + 60,
                                intX1 + 190, (intY2 + 41)) ' intY1 + 655)
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 303, intY1 + 60,
                                intX1 + 303, (intY2 + 41)) ' intY1 + 655)
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 408, intY1 + 60,
                                intX1 + 408, intY1 + 453)
                ''e.Graphics.DrawLine(System.Drawing.Pens.Black, intX1 + 453, intY1 - 5, _
                ''                intX1 + 453, intY1 + 60)
                ''e.Graphics.DrawLine(System.Drawing.Pens.Black, intX1 + 528, intY1 - 45, _
                ''                intX1 + 528, intY1 + 60)
                'Print the earnings amount left division line
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 600, intY1 + 60,
                                intX1 + 600, intY2 + 41) ' intY1 + 655)
                'Draw the totals horizontal lines
                e.Graphics.DrawLine(Pens.Navy, intX1, intY1 + 225, reccurrent.Right, intY1 + 225)
                e.Graphics.DrawLine(Pens.Navy, intX1, intY1 + 255, reccurrent.Right, intY1 + 255)
                e.Graphics.DrawLine(Pens.Navy, intX1, intY1 + 285, reccurrent.Right, intY1 + 285)
            End With
        End If
        'Draw the horizontal lines for the employment and earnings and deduction sections
        intY1 = intY1 + 20
        If boolDrawBorders = True Then e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)
        intY1 = intY1 + 40
        If boolDrawBorders = True Then e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)
        intY1 = intY1 + 30
        If boolDrawBorders = True Then e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)
        'Print column headers at - 20 the value of y
        If boolDrawBorders = True Then e.Graphics.DrawString("EARNINGS", SubHeadingFont, Brushes.Navy, intX1 + 1, intY1 - 20)
        If boolDrawBorders = True Then e.Graphics.DrawString("UNITS", SubHeadingFont, Brushes.Navy, intX1 + 223, intY1 - 20)
        If boolDrawBorders = True Then e.Graphics.DrawString("AMOUNT", SubHeadingFont, Brushes.Navy, intX1 + 323, intY1 - 20)
        If boolDrawBorders = True Then e.Graphics.DrawString("DEDUCTIONS", SubHeadingFont, Brushes.Navy, intX1 + 406, intY1 - 20)
        If boolDrawBorders = True Then e.Graphics.DrawString("AMOUNT", SubHeadingFont, Brushes.Navy, intX1 + 628, intY1 - 20)
        'Print the totals row header
        If boolDrawBorders = True Then e.Graphics.DrawString("TOTALS", SubHeadingFont, Brushes.Navy, intX1 + 1, 320)
        Dim intTotalsYaxis As Integer = intY1 + 240
        'We begin printing the individual pay details
        '*******************************************************************************************
        '
        'Begin by getting the print details
        'Open the payslip runfile and get the current employee details
        strCurrentEmployeeBeingProcessed = strEmployeeFullDetails(itm)
        'Get the bank account details
        strCurrentEmployeeBankDetails = strBankAccountDetails(itm)
        If String.IsNullOrEmpty(strCurrentEmployeeBeingProcessed) Then strCurrentEmployeeBeingProcessed = ";;"
        If String.IsNullOrEmpty(strCurrentEmployeeBankDetails) Then strCurrentEmployeeBankDetails = ";;"
        strCurrentEmployeeBeingProcessedArray = Split(strCurrentEmployeeBeingProcessed, ";")
        strCurrentEmployeeBankDetailsArray = Split(strCurrentEmployeeBankDetails, ";")
        'Get the employment details
        strCurrentEmployeeEmploymentDetails = strEmploymentFullDetails(itm)
        If String.IsNullOrEmpty(strCurrentEmployeeEmploymentDetails) Then strCurrentEmployeeEmploymentDetails = ";;;;"
        strCurrentEmployeeEmploymentDetailsArray = Split(strCurrentEmployeeEmploymentDetails, ";")

        '-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        'Employee number
        e.Graphics.DrawString(strCurrentEmployeeBeingProcessedArray(0), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 102, (125 + (intEmploymentIndent * 15)))
        'Paypoint
        e.Graphics.DrawString(strCurrentEmployeeEmploymentDetailsArray(1), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 53, (125 + (intEmploymentIndent * 15)))
        'Clock number
        e.Graphics.DrawString(strCurrentEmployeeEmploymentDetailsArray(3), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 175, (125 + (intEmploymentIndent * 15)))
        'Tax Code
        e.Graphics.DrawString(strCurrentEmployeeEmploymentDetailsArray(4), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 235, (125 + (intEmploymentIndent * 15)))

        'Build the surname and initials string
        Dim strShortName As String = strCurrentEmployeeBeingProcessedArray(1)
        If Not String.IsNullOrEmpty(strCurrentEmployeeBeingProcessedArray(2)) Then
            strShortName = strShortName & " " & strCurrentEmployeeBeingProcessedArray(2)
        End If
        'If Not String.IsNullOrEmpty(strCurrentEmployeeBeingProcessedArray(3)) Then
        '    strShortName = strShortName & " " & Mid(strCurrentEmployeeBeingProcessedArray(3), 1, 1)
        'End If
        'Print the employee name up in the same row as company name
        e.Graphics.DrawString(UCase(strShortName), HeadingFont, System.Drawing.Brushes.Black, intX1 + 305, (intTopMargin + 10))

        'Print the bank account number
        e.Graphics.DrawString(UCase(strCurrentEmployeeBankDetailsArray(2)), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 530, (125 + (intEmploymentIndent * 15)))

        '-*- Print the employment details for the cost center and department and paypoint
        '-*- Limit the six of these fields accordingly so that there is no printing overlap

        '-*- EMPLOYEE NUMBER -*-
        If strCurrentEmployeeEmploymentDetailsArray(2).Length > 8 Then strCurrentEmployeeEmploymentDetailsArray(2) = Mid(strCurrentEmployeeEmploymentDetailsArray(2), 1, 8)

        '-*- COST CENTER -*-
        If strCurrentEmployeeEmploymentDetailsArray(5).Length > 15 Then strCurrentEmployeeEmploymentDetailsArray(5) = Mid(strCurrentEmployeeEmploymentDetailsArray(5), 1, 15)
        e.Graphics.DrawString(strCurrentEmployeeEmploymentDetailsArray(5), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 305, (125 + (intEmploymentIndent * 15)))
        'PRINT PAYROLL NUMBER
        e.Graphics.DrawString(strCurrentEmployeeEmploymentDetailsArray(0), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 20, (125 + (intEmploymentIndent * 15)))
        '' ''****e.Graphics.DrawString(strCurrentEmployeeEmploymentDetailsArray(6), fntPrintFont, System.Drawing.Brushes.Black, intX1 + 205, 180)

        '-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        'Get the runfile details from the run table
        Dim strSql As String = Nothing
        Dim strRunfText As String = Nothing

        'strSql = "SELECT CONVERT(NVARCHAR, EmpNo) +';'+ CONVERT(NVARCHAR, OrdinalNo) +';'+ CONVERT(NVARCHAR, Amt) AS [Details] FROM PW_RunfAmts WHERE Usage = 1" 'Verify the value for the non manual payslips
        strSql = "SELECT RunAmounts FROM EmployeeRunFile WHERE EmployeeNo = '" & strCurrentEmployeeBeingProcessedArray(0) & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objPayslipRunfile As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objPayslipRunfile.HasRows Then
            objPayslipRunfile.Read()
            strRunfText = objPayslipRunfile(0).ToString
            Dim intCdeCnt As Integer = 0
            Dim strRunfLine() As String = Split(strRunfText, "|")
            ReDim intPrintValues(0 To strRunfLine.Length - 1)
            For intCdeCnt = 0 To strRunfLine.Length - 1
                If Not String.IsNullOrEmpty(strRunfLine(intCdeCnt)) Then
                    intPrintValues(intCdeCnt) = CDbl(strRunfLine(intCdeCnt))
                Else
                    intPrintValues(intCdeCnt) = 0
                End If
            Next
        End If

        'Close the file
        objPayslipRunfile.Close()

        'Loop through payslip file and print details based on it
        eLineCnt = intY1 + (intEarningsIndent * 15) + 5 : dLineCnt = intY1 + (intEarningsIndent * 15) + 5
        sLineCnt = intY1 + (intStatisticsIndent * 15) + 200
        'Print the employee main details here

        For nz = 0 To intPayslipLinesCount - 1

            sPayslipLineText = Split(strPayslipLineDetails(nz), ";")
            strPayslipColumnType = sPayslipLineText(2)

            'Get the value of the amounts
            Dim dblUnitValue As Double = 0
            Dim dblAmountValue As Double = 0

            If CInt(sPayslipLineText(3)) - 1 >= 0 Then dblUnitValue = intPrintValues(CInt(sPayslipLineText(3)) - 1)
            If CInt(sPayslipLineText(4)) - 1 >= 0 Then dblAmountValue = intPrintValues(CInt(sPayslipLineText(4)) - 1)

            Select Case UCase(strPayslipColumnType)
                Case Is = "E"
                    'check that the value is greater than zero
                    If CInt(sPayslipLineText(4)) > 0 Then

                        '********* strAmt = CStr(Format(intPrintValues(CInt(sPayslipLineText(3) - 1)), "#,##0.00"))
                        If CDbl(dblAmountValue) > 0 Then
                            'Print the description
                            str = sPayslipLineText(1)
                            Call gwt_comm.DrawStringInBoxLeft(e, intX1, eLineCnt, W1, 150, str, fntPrintFont, Brushes.Black)

                            'Print the units. First get the value of the unit column from the run file
                            If CInt(sPayslipLineText(3)) > 0 Then
                                If dblUnitValue > 0 Then
                                    str = CStr(Format(dblUnitValue, "#,##0.00"))
                                    Call gwt_comm.DrawStringInBoxRight(e, intX1 + 303, eLineCnt, W1, 100, str, fntPrintFont, Brushes.Black)
                                End If
                            End If

                            'Print the amounts
                            str = CStr(Format(dblAmountValue, "#,##0.00"))
                            Call gwt_comm.DrawStringInBoxRight(e, intX1 + 403, eLineCnt, W1, 100, str, fntPrintFont, Brushes.Black)
                            'increament the line counter for earnings
                            eLineCnt = eLineCnt + 15
                        End If
                    End If
                Case Is = "D"
                    'Print the description
                    If CInt(sPayslipLineText(4)) > 0 Then
                        strAmt = CStr(Format(dblAmountValue, "#,##0.00"))
                        If CDbl(strAmt) > 0 Then
                            str = sPayslipLineText(1)
                            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 409, dLineCnt, W1, 150, str, fntPrintFont, Brushes.Black)
                            'Print the amounts
                            Call gwt_comm.DrawStringInBoxRight(e, intX1 + 680, dLineCnt, W1, 100, strAmt, fntPrintFont, Brushes.Black)
                            'increament the line counter for deductions
                            dLineCnt = dLineCnt + 15
                        End If
                    End If
                Case Is = "L"
                    'Print the description
                    If CInt(sPayslipLineText(4)) > 0 Then
                        strAmt = CStr(Format(dblAmountValue, "#,##0.00"))
                        If CDbl(strAmt) > 0 Then
                            str = sPayslipLineText(1)
                            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 409, dLineCnt, W1, 150, str, fntPrintFont, Brushes.Black)
                            'Print the amounts
                            Call gwt_comm.DrawStringInBoxRight(e, intX1 + 680, dLineCnt, W1, 100, strAmt, fntPrintFont, Brushes.Black)
                            'increament the line counter for deductions
                            dLineCnt = dLineCnt + 15
                        End If
                    End If
                Case Is = "S"
                    'Print the description
                    If CInt(sPayslipLineText(4)) > 0 Then
                        strAmt = CStr(Format(dblAmountValue, "#,##0.00"))
                        If CDbl(strAmt) > 0 Then
                            If intStatsCount < 10 Then
                                str = sPayslipLineText(1)
                                Call gwt_comm.DrawStringInBoxLeft(e, intX1, sLineCnt, W1, 150, str, fntPrintFont, Brushes.Black)
                                'Print the amounts
                                Call gwt_comm.DrawStringInBoxRight(e, intX1 + 300, sLineCnt, W1, 100, strAmt, fntPrintFont, Brushes.Black)
                                'increament the line counter for statistics
                                sLineCnt = sLineCnt + 15
                                intStatsCount += 1
                            End If
                        End If
                    End If
            End Select
        Next
        'Print the payslip gross and deductions total
        'intY1 = intY1 - 30
        str = CStr(Format(intPrintValues(intPayrollGrossIncomeCode - 1), "#,##0.00"))
        Call gwt_comm.DrawStringInBoxRight(e, X1 + 443, 320, W1, 100, str, fntPrintFont, Brushes.Black)
        'Print the total deductions amount
        str = CStr(Format(intPrintValues(intPayrollTotalDeductions - 1), "#,##0.00"))
        Call gwt_comm.DrawStringInBoxRight(e, X1 + 723, 325, W1, 100, str, fntPrintFont, Brushes.Black)
        'print the net salary
        str = CStr(Format(intPrintValues(intPayrollNetIncomeCode - 1), "#,##0.00"))
        If boolDrawBorders = True Then Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 410, 350, W1, 150, "NET PAY", SubHeadingFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X1 + 730, 350, W1, 100, str, fntPrintFont, Brushes.Black)
        'Print the net salary line divide with messages

        'Print the employer details
        'If Not String.IsNullOrEmpty(strCompanyAddressInformation) Then
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 600, W1, 250, UCase("Proudly employed by:"), fntFooter, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 615, W1, 250, UCase(strCompanyName), fntFooter, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 630, W1, 250, UCase(strCompanyAddress1), fntFooter, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 645, W1, 250, UCase(strCompanyAddress2), fntFooter, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 660, W1, 250, UCase(strCompanyAddress3), fntFooter, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 675, W1, 250, UCase(strCompanyAddress4), fntFooter, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 306, intY1 + 690, W1, 250, UCase(strCompanyTelephone), fntFooter, Brushes.Black)
        'End if
        If itm >= (intPayslipProcessingCount - 1) Then
            e.HasMorePages = False
            itm = 0
        Else
            e.HasMorePages = True
            itm = itm + 1
        End If
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Payslip Print"
        ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub CreatePrintArray()
        On Error GoTo RaiseErr
        Dim str As String
        strNewPrintDetails = New ArrayList
        Dim dblPrintTotals(0 To (strSummaryLineCodes.Length - 1)) As Double
        Dim intInitialize As Integer = 0
        Dim arrEarningsLine As New ArrayList
        Dim arrDeductionsLine As New ArrayList
        Dim intEarningsCount As Integer = 0, intDeductionsCount As Integer = 0
        For intInitialize = 0 To strSummaryLineCodes.Length - 1
            dblPrintTotals(intInitialize) = 0
        Next

        boolAbort = False
        gwt_comm.GetKeyDataFields()
        If boolAbort = True Then Exit Sub

        While itm < intPayslipProcessingCount

            Dim strGroupKey As String = GetGroupKey(strProcessedEmployeeNumbers(itm), strReportSortOption)

            'Open the payslip runfile and get the current employee details
            Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeRunFile where EmployeeNo = " _
                & "'" & strProcessedEmployeeNumbers(itm) & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                'Get the employee being processed's details
                Dim strBlockEmployeeNo As String = Nothing
                Dim sqlCommandEmpDetails As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ Inits +' '+ EmployeeNo " _
                    & "AS [Details] FROM EmployeeMaster WHERE EmployeeNo = '" & strProcessedEmployeeNumbers(itm) & "'", cnn)
                Dim objReadDetails As Data.OleDb.OleDbDataReader = sqlCommandEmpDetails.ExecuteReader
                If objReadDetails.HasRows Then
                    objReadDetails.Read()
                    If Not IsDBNull(objReadDetails(0).ToString) Then strCurrentEmployeeBeingProcessed = objReadDetails(0).ToString
                End If
                'strCurrentEmployeeBeingProcessed = strEmployeeFullDetails(itm)
                'strCurrentEmployeeBeingProcessedArray = Split(strCurrentEmployeeBeingProcessed, ";")
                If Not IsDBNull(objReader("RunAmounts").ToString) Then
                    strRunfLine = Split(objReader("RunAmounts").ToString, "|")
                    Dim z As Integer = 0
                    For z = 0 To strSummaryLineCodes.Length - 1
                        intPrintValues(z) = CDbl(strRunfLine(z))
                        dblPrintTotals(z) = dblPrintTotals(z) + CDbl(strRunfLine(z))
                    Next z
                End If
            End If

            objReader.Close()
            intEarningsCount = 0 : intDeductionsCount = 0
            arrEarningsLine = New ArrayList
            arrDeductionsLine = New ArrayList
            '0773926348

            For nz = 0 To strSummaryLineCodes.Length - 1
                strMyNewPrintLine = ""
                'If nz = 236 Then
                '    MessageBox.Show(nz)
                'End If
                sSummaryLineText = Split(strSummaryLineCodes(nz), ";")
                strSummaryColumnType = sSummaryLineText(2)
                Dim strUnitAmt As String = "0.00"
                If IsNumeric(sSummaryLineText(4)) Then
                    If CInt(sSummaryLineText(4) - 1) > 0 Then
                        strUnitAmt = CStr(Format(intPrintValues(CInt(sSummaryLineText(4) - 1)), "#,##0.00"))
                    End If
                End If

                Select Case UCase(strSummaryColumnType)
                    Case Is = "E"
                        str = CStr(Format(intPrintValues(CInt(sSummaryLineText(0) - 1)), "#,##0.00"))
                        If CDbl(str) <> 0 Then
                            If intEarningsCount = 0 Then
                                arrEarningsLine.Add(strCurrentEmployeeBeingProcessed & ";" & sSummaryLineText(1) & ";" & strUnitAmt & ";" & str)
                            Else
                                arrEarningsLine.Add(" ;" & sSummaryLineText(1) & ";" & strUnitAmt & ";" & str)
                            End If
                            intEarningsCount = intEarningsCount + 1
                        End If
                    Case Is = "D"
                        str = CStr(Format(intPrintValues(CInt(sSummaryLineText(0) - 1)), "#,##0.00"))
                        If CDbl(str) <> 0 Then
                            arrDeductionsLine.Add(sSummaryLineText(1) & ";" & strUnitAmt & ";" & str)
                            intDeductionsCount = intDeductionsCount + 1
                        End If
                End Select
            Next
            'Print the net salary, gross salary and total deductions totals
            str = CStr(Format(intPrintValues(CInt(intPayrollGrossIncomeCode - 1)), "#,##0.00"))
            arrEarningsLine.Add(" ;GROSS PAY;;" & str)
            intEarningsCount = intEarningsCount + 1
            'Print the total deductions amount
            str = CStr(Format(intPrintValues(CInt(intPayrollTotalDeductions - 1)), "#,##0.00"))
            arrEarningsLine.Add(" ;TOTAL DEDUCTIONS;;" & str)
            intEarningsCount = intEarningsCount + 1
            'Print the net salary
            str = CStr(Format(intPrintValues(CInt(intPayrollNetIncomeCode - 1)), "#,##0.00"))
            arrEarningsLine.Add(" ;NET PAY;;" & str)
            intEarningsCount = intEarningsCount + 1

            If intEarningsCount > intDeductionsCount Then
                Dim n As Integer = 0
                For n = (intDeductionsCount + 1) To intEarningsCount
                    arrDeductionsLine.Add(" ; ; ")
                    intDeductionsCount = intDeductionsCount + 1
                Next
            Else
                Dim n As Integer = 0
                For n = (intEarningsCount + 1) To intDeductionsCount
                    arrEarningsLine.Add(" ; ; ; ")
                    intEarningsCount = intEarningsCount + 1
                Next
            End If
            For nz = 0 To intDeductionsCount - 1
                strNewPrintDetails.Add(arrEarningsLine(nz) & ";" & arrDeductionsLine(nz) & ";" & strGroupKey)
            Next nz
            'Add a blank line
            strNewPrintDetails.Add(" ; ; ; ; ; ; ;" & strGroupKey)
            itm += 1
        End While

        'Print the report total at end

        intEarningsCount = 0 : intDeductionsCount = 0
        arrEarningsLine = New ArrayList
        arrDeductionsLine = New ArrayList

        For nz = 0 To strSummaryLineCodes.Length - 1
            strMyNewPrintLine = ""
            sSummaryLineText = Split(strSummaryLineCodes(nz), ";")
            strSummaryColumnType = sSummaryLineText(2)
            Select Case UCase(strSummaryColumnType)
                Case Is = "E"
                    str = CStr(Format(dblPrintTotals(CInt(sSummaryLineText(0) - 1)), "#,##0.00"))
                    If CDbl(str) <> 0 Then
                        If intEarningsCount = 0 Then
                            arrEarningsLine.Add("TOTALS ;" & sSummaryLineText(1) & ";;" & str)
                        Else
                            arrEarningsLine.Add(" ;" & sSummaryLineText(1) & ";;" & str)
                        End If
                        intEarningsCount = intEarningsCount + 1
                    End If
                Case Is = "D"
                    str = CStr(Format(dblPrintTotals(CInt(sSummaryLineText(0) - 1)), "#,##0.00"))
                    If CDbl(str) <> 0 Then
                        arrDeductionsLine.Add(sSummaryLineText(1) & ";;" & str)
                        intDeductionsCount = intDeductionsCount + 1
                    End If
            End Select
        Next
        'Print the net salary, gross salary and total deductions totals
        str = CStr(Format(dblPrintTotals(CInt(intPayrollGrossIncomeCode - 1)), "#,##0.00"))
        arrEarningsLine.Add(" ;GROSS PAY;;" & str)
        intEarningsCount = intEarningsCount + 1
        'Print the total deductions amount
        str = CStr(Format(dblPrintTotals(CInt(intPayrollTotalDeductions - 1)), "#,##0.00"))
        arrEarningsLine.Add(" ;TOTAL DEDUCTIONS;;" & str)
        intEarningsCount = intEarningsCount + 1
        'Print the net salary
        str = CStr(Format(dblPrintTotals(CInt(intPayrollNetIncomeCode - 1)), "#,##0.00"))
        arrEarningsLine.Add(" ;NET PAY;;" & str)
        intEarningsCount = intEarningsCount + 1

        If intEarningsCount > intDeductionsCount Then
            Dim n As Integer = 0
            For n = (intDeductionsCount + 1) To intEarningsCount
                arrDeductionsLine.Add(" ; ; ")
                intDeductionsCount = intDeductionsCount + 1
            Next
        Else
            Dim n As Integer = 0
            For n = (intEarningsCount + 1) To intDeductionsCount
                arrEarningsLine.Add(" ; ; ; ")
                intEarningsCount = intEarningsCount + 1
            Next
        End If
        For nz = 0 To intDeductionsCount - 1
            strNewPrintDetails.Add(arrEarningsLine(nz) & ";" & arrDeductionsLine(nz) & "; ")
        Next nz

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Summary Details Spooling"
        ShowErrorMessage()
    End Sub

    Private Function GetGroupKey(EmployeeNumber As String, Grouping As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim strSql As String = Nothing

        Select Case UCase(Grouping)
            Case Is = UCase("Employee Number")
                strReturn = EmployeeNumber
                Exit Function
            Case Is = UCase("Surname")
                strSql = "SELECT LastName +' '+ OtherNames FROM EmployeeMaster WHERE EmployeeNo = '" & EmployeeNumber & "'"
            Case Is = UCase("Department")
                strSql = "SELECT Department FROM Employment WHERE EmployeeNo = '" & EmployeeNumber & "'"
            Case Is = UCase("Cost Center")
                strSql = "SELECT CostCenter FROM Employment WHERE EmployeeNo = '" & EmployeeNumber & "'"
            Case Is = UCase("Pay Point")
                strSql = "SELECT PayPoint FROM Employment WHERE EmployeeNo = '" & EmployeeNumber & "'"
            Case Else
                strReturn = EmployeeNumber
                Exit Function
        End Select
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                strReturn = objReader(0).ToString
            End If
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On payroll report print"
        ShowErrorMessage()
        boolAbort = True
    End Function

End Class