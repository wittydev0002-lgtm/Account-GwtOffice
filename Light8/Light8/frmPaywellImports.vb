Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports System.Windows.Forms

Public Class frmPaywellImports

    Dim PayConn As Data.OleDb.OleDbConnection

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ImportPaywellCalculations()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT OrdinalNo, CalcCode, " _
            & "IndSub, IndVal, OpCode, Op1A, Op1N, Op2A, Op2N, Op3A, " _
            & "Op3N from PW_Parm_Calculations WHERE CalcSet = 1 AND Payroll = 1", PayConn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim arrCalcs As New ArrayList
        Dim i As Integer = 0
        While objReader.Read
            Dim strData As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strData = strData & objReader(i).ToString & "|"
            Next
            strData = Mid(strData, 1, strData.Length - 1)
            arrCalcs.Add(strData)
        End While
        objReader.Close()
        'Reader the array list and use it for inserting into the payroll calculations
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemCalculations WHERE CalcNo = 1", cnn)
        sqlCommand.ExecuteNonQuery()
        'Add the calculation name
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemCalculationNames WHERE CalculationNo = 1", cnn)
        sqlCommand.ExecuteNonQuery()
        sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemCalculationNames (CalculationNo, CalculationName) " _
            & "VALUES (1, 'Main Payroll Run Calculations')", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim newConn As New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()
        pb1.Value = 0
        pb1.Visible = True
        pb1.Maximum = arrCalcs.Count
        Dim strSql As String = Nothing
        For i = 0 To arrCalcs.Count - 1
            Dim strBuffer() As String = Split(arrCalcs(i), "|")
            strSql = "INSERT INTO SystemCalculations (OrdinalNo, CalcTime, " _
            & "IndicatorSub, IndicatorValue, CalcFunction, OperandOneId, " _
            & "OperandOneCode, OperandTwoId, OperandTwoCode, ResultantId, " _
            & "ResultantCode, CalcNo) VALUES (" & strBuffer(0) & ", " & strBuffer(1) & ", " _
            & "" & strBuffer(2) & ", '" & strBuffer(3) & "', '" & strBuffer(4) & "', " _
            & "'" & strBuffer(5) & "', " & strBuffer(6) & ", '" & strBuffer(7) & "', " & strBuffer(8) & ", " _
            & "'" & strBuffer(9) & "', " & strBuffer(10) & ", " & 1 & ")"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Calculations Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ImportPaywellCodes()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT OrdinalNo, " _
            & "CodeName, CodeType, TaxType, TaxIncAsn, QmfDisplayInd, " _
            & "ManualDisplayInd, ConsolArnFlag, ConsolCode, ProRataInd, " _
            & "AdjustFlag FROM PW_Parm_Codes WHERE Payroll = 1 ORDER BY OrdinalNo", PayConn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim arrCodes As New ArrayList
        Dim i As Integer = 0
        While objReader.Read
            Dim strData As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strData = strData & Replace(objReader(i).ToString, "'", "", 1) & "|"
            Next
            strData = Mid(strData, 1, strData.Length - 1)
            arrCodes.Add(strData)
        End While
        objReader.Close()
        'Reader the array list and use it for inserting into the payroll codes
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemCodes", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim newConn As New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()
        pb1.Value = 0
        pb1.Visible = True
        pb1.Maximum = arrCodes.Count
        Dim strSql As String = Nothing
        For i = 0 To arrCodes.Count - 1
            Dim strBuffer() As String = Split(arrCodes(i), "|")
            strSql = "INSERT INTO SystemCodes (CodeNo, Description, " _
            & "CodeType, TaxType, TaxTreatment, DisplayStatus, " _
            & "ManualDisplayInd, ConsolArnFlag, ConsolCode, ProRataInd, " _
            & "AdjustFlag) VALUES (" & strBuffer(0) & ", '" & strBuffer(1) & "', " _
            & "'" & strBuffer(2) & "', '" & strBuffer(3) & "', '" & strBuffer(4) & "', " _
            & "'" & strBuffer(5) & "', '" & strBuffer(6) & "', '" & strBuffer(7) & "', " & strBuffer(8) & ", " _
            & "'" & strBuffer(9) & "', '" & strBuffer(10) & "')"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Calculations Update line no " & (i + 1)
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub InitializeImports()
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtServerName.Text) Then
            MessageBox.Show("Please enter the Paywell database server name", "Invalid Paywell Server Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtServerName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDatabaseName.Text) Then
            MessageBox.Show("Please enter the Paywell database name", "Invalid Paywell Database Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDatabaseName.Focus()
            Exit Sub
        End If
        If Me.cboAuthentication.Text = "Windows Authentication" Then
            'Do nothing 
        Else
            If String.IsNullOrEmpty(txtUserName.Text) Then
                MessageBox.Show("Please enter the Paywell user login name", "Invalid Paywell User Login Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtUserName.Focus()
                Exit Sub
            End If
        End If

        'If String.IsNullOrEmpty(txtPassword.Text) Then
        '    MessageBox.Show("Please enter the Paywell database password", MsgBoxStyle.Exclamation, "Invalid Paywell Database Password")
        '    txtPassword.Focus()
        '    Exit Sub
        'End If

        Dim arrSelectedOptions As New ArrayList
        Dim i As Integer = 0

        ' Determine if there are any items checked.
        If chkOptions.CheckedItems.Count <> 0 Then
            ' If so, loop through all checked items and process options.
            For i = 0 To chkOptions.CheckedItems.Count - 1
                arrSelectedOptions.Add(chkOptions.CheckedItems(i).ToString)
            Next i
        Else
            MessageBox.Show("No import options have been selected", "Zero Import Options", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Open the paywell database
        Dim strMyConnection As String
        If cboAuthentication.Text = "SQL Server Authentication" Then
            strMyConnection = "Data Source=" & Me.txtServerName.Text & ";Initial Catalog=" & txtDatabaseName.Text & ";User ID=" & Me.txtUserName.Text & ";Password=" & txtPassword.Text & ";provider=SQLOLEDB"
        Else
            'This is using the windows authentication
            strMyConnection = "data source=" & txtServerName.Text & ";initial catalog=" & txtDatabaseName.Text & ";integrated security=SSPI;persist security info=False;Enlist=True;Pooling=False;Connection Lifetime=30;provider=SQLOLEDB"
        End If

        PayConn = New Data.OleDb.OleDbConnection(strMyConnection)
        PayConn.Open()

        For i = 0 To arrSelectedOptions.Count - 1
            Select Case UCase(arrSelectedOptions.Item(i).ToString)
                Case Is = "CALCULATIONS"
                    ImportPaywellCalculations()
                Case Is = "CODES"
                    ImportPaywellCodes()
                Case Is = "REGISTERS"
                    ImportPaywellRegisters()
                Case Is = "MASTER FILE"
                    ImportPaywellMasterFile()
                Case Is = "DATES"
                    ImportPaywellDates()
                Case Is = "INDICATORS"
                    ImportPaywellIndicators()
                Case Is = "REFERENCE NUMBERS"
                    ImportPaywellRefnumbers()
                Case Is = "YEAR TO DATES"
                    ImportPaywellYearToDates()
                Case Is = "BANKS"
                    ImportPaywellBanks()
                Case Is = "COLUMN REPORTS"
                    ImportPaywellColumnReports()
                Case Is = "PAYROLL BATCHES"
                    ImportPaywellPayrollBatches()
                Case Is = "RUN FILE"
                    ImportRunFile()
                Case Is = "PAYSLIPS"
                    ImportPaywellPayslipDescriptions()
                Case Is = "EXCEPTIONS"
                    ImportExceptions()
                Case Is = UCase("Year-To-Date Codes")
                    ImportYearToDates()
            End Select
        Next
        'Close the paywell connection 
        PayConn.Close()
        MessageBox.Show("Paywell data has been successfully imported", "Paywell Data Import Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Paywell Data Import"
        gwt_comm.ShowErrorMessage()
    End Sub


    Private Sub ImportYearToDates()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT SourceCodeN, DestinationCodeN FROM PW_Parm_AutoYTD", PayConn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        While objReader.Read
            Dim strUpdate As String = "UPDATE SystemCodes SET " _
                & "YtdCode = " & CInt(objReader(1).ToString) & " " _
                & "WHERE CodeNo = " & CInt(objReader(0).ToString) & ""
            sqlCommand = New Data.OleDb.OleDbCommand(strUpdate, cnn)
            sqlCommand.ExecuteNonQuery()
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Paywell Data Import"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ImportPaywellPayslipDescriptions()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim sqlCommand As New Data.OleDb.OleDbCommand("Select " _
            & "PW_Parm_ListTypePayslDesc.Description, PW_Parm_ListTypePayslDesc.Dcol, " _
            & "PW_Parm_ListTypePayslAmts.UOpN, PW_Parm_ListTypePayslAmts.AopN FROM " _
            & "PW_Parm_ListTypePayslAmts, PW_Parm_ListTypePayslDesc WHERE " _
            & "PW_Parm_ListTypePayslAmts.ARow = PW_Parm_ListTypePayslDesc.DRow " _
            & "AND PW_Parm_ListTypePayslAmts.Acol = PW_Parm_ListTypePayslDesc.DCol " _
            & "AND PW_Parm_ListTypePayslAmts.Payroll = 1", PayConn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Delete payslip records first
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemPayslipParameters", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim n As Integer = 1
        While objReader.Read
            Dim strDesc As String = Nothing
            Dim strType As String = Nothing
            Dim intUnits As Integer = 0
            Dim intAmounts As Integer = 0
            If Not IsDBNull(objReader(0).ToString) Then strDesc = objReader(0).ToString
            If IsNumeric(objReader(1).ToString) Then
                If CInt(objReader(1).ToString) = 1 Then strType = "Earnings"
                If CInt(objReader(1).ToString) = 2 Then strType = "Deductions"
                If CInt(objReader(1).ToString) = 0 Then strType = "Statistics"
            End If

            If IsNumeric(objReader(2).ToString) Then intUnits = CInt(objReader(2).ToString)
            If IsNumeric(objReader(3).ToString) Then intAmounts = CInt(objReader(3).ToString)

            'Insert the record to payslip parameters
            sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemPayslipParameters " _
                & "(OrdinalNo, Description, EntryType, UnitCode, AmountCode) VALUES " _
                & "(" & n & ", '" & strDesc & "', '" & strType & "', " & intUnits & ", " & intAmounts & ")", cnn)
            sqlCommand.ExecuteNonQuery()
            n = n + 1
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Paywell Payslip Parameters Import"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ImportPaywellPayrollBatches()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("Select Batch, " _
            & "Line, EmpNo, Code, Amt, Class, Operator, CostCodes FROM " _
            & "PW_BatchfDetails WHERE Payroll = 1 ORDER BY Batch, Line", PayConn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim arrBatches As New ArrayList
        Dim i As Integer = 0
        While objReader.Read
            Dim strData As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strData = strData & Replace(objReader(i).ToString, "'", "", 1) & "|"
            Next
            strData = Mid(strData, 1, strData.Length - 1)
            arrBatches.Add(strData)
        End While
        objReader.Close()
        'Reader the array list and use it for inserting into the payroll 
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeBatches", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim newConn As New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()
        pb1.Value = 0
        pb1.Visible = True
        pb1.Maximum = arrBatches.Count
        Dim strSql As String = Nothing
        For i = 0 To arrBatches.Count - 1
            Dim strBuffer() As String = Split(arrBatches(i), "|")
            strSql = "INSERT INTO EmployeeBatches (BatchNo, EntryLineNo, " _
                & "EmployeeNo, CodeNo, Amount, Class, UserName, CostCode, TransDate) " _
                & " VALUES (" & strBuffer(0) & ", " & strBuffer(1) & ", " _
                & "'" & strBuffer(2) & "', " & strBuffer(3) & ", " & strBuffer(4) & ", " _
                & "" & strBuffer(5) & ", '" & strBuffer(6) & "', '" & strBuffer(7) & "', '" & gwt_comm.shortMonthDateFormat(Now) & "')"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next
        '
        'Due to the major differencies between the two systems all the batches 
        'Will be owned by the current user
        '
        'Update the Batches Control Table
        '
        Dim objInnerRead As Data.OleDb.OleDbDataReader
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT(BatchNo) FROM EmployeeBatches ORDER BY BatchNo", cnn)
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            Dim dblTotalAmount As Double = 0
            Dim intNumEntries As Integer = 0
            sqlCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Amount) " _
                & "FROM EmployeeBatches WHERE BatchNo = " & objReader(0).ToString & "", cnn)
            objInnerRead = sqlCommand.ExecuteReader
            While objInnerRead.Read
                If IsNumeric(objInnerRead(0).ToString) Then dblTotalAmount = CDbl(objInnerRead(0).ToString)
            End While
            objInnerRead.Close()
            sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(Amount) " _
                & "FROM EmployeeBatches WHERE BatchNo = " & objReader(0).ToString & "", cnn)
            objInnerRead = sqlCommand.ExecuteReader
            While objInnerRead.Read
                If IsNumeric(objInnerRead(0).ToString) Then intNumEntries = CInt(objInnerRead(0).ToString)
            End While
            objInnerRead.Close()
            sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemBatchesControl WHERE BatchNo = " & objReader(0).ToString & "", cnn)
            sqlCommand.ExecuteNonQuery()
            sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO " _
                & "SystemBatchesControl (BatchNo, CreationDate, Author, " _
                & "Status, BatchTotal, NumberOfEntries) VALUES " _
                & "(" & objReader(0).ToString & ", '" & Now & "', " _
                & "'" & strUserName & "', 'Not Processed', " & dblTotalAmount & ", " & intNumEntries & ")", cnn)
            sqlCommand.ExecuteNonQuery()
        End While
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Paywell Data Import"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ImportPaywellColumnReports()
        On Error GoTo RaiseErr
        '
        'Import the report headers and parameters first
        '
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT ReportNo, " _
            & "Header, EachLineInd, IncludeManualPay, SuppressZeros, " _
            & "ReferenceNo, RefNoHead1, RefNoHead2, BreakTotalNewPage " _
            & "FROM PW_Parm_ColumnReport WHERE Payroll = 1 ORDER BY ReportNo", PayConn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim arrReports As New ArrayList
        Dim i As Integer = 0
        While objReader.Read
            Dim strData As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strData = strData & Replace(objReader(i).ToString, "'", "", 1) & "|"
            Next
            strData = Mid(strData, 1, strData.Length - 1)
            arrReports.Add(strData)
        End While
        objReader.Close()
        'Reader the array list and use it for inserting into the payroll 
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemColumnReportParameters", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim newConn As New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()
        pb1.Value = 0
        pb1.Visible = True
        pb1.Maximum = arrReports.Count
        Dim strSql As String = Nothing
        For i = 0 To arrReports.Count - 1
            Dim strBuffer() As String = Split(arrReports(i), "|")
            strSql = "INSERT INTO SystemColumnReportParameters (ReportNo, " _
            & "Header, EachLineInd, IncludeManualPay, SuppressZeros, " _
            & "ReferenceNo, RefNoHead1, RefNoHead2, BreakTotalNewPage)" _
            & " VALUES (" & strBuffer(0) & ", '" & strBuffer(1) & "', " _
            & "'" & strBuffer(2) & "', '" & strBuffer(3) & "', '" & strBuffer(4) & "', " _
            & "" & strBuffer(5) & ", '" & strBuffer(6) & "', '" & strBuffer(7) & "', " _
            & "'" & strBuffer(8) & "')"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next
        '
        'Import the calculations as well
        '
        '
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT [IndNo],[IndVal]," _
            & "[OP1A],[OP1N],[OP2A],[OP2N],[OP3A],[OP3N],[OPCode],[OrdinalNo],[ReportNo] " _
            & "FROM [PW_Parm_ColumnReportCalcs] WHERE Payroll = 1 ORDER BY ReportNo", PayConn)
        objReader = sqlCommand.ExecuteReader
        Dim arrReportCalcs As New ArrayList
        i = 0
        While objReader.Read
            Dim strData As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strData = strData & Replace(objReader(i).ToString, "'", "", 1) & "|"
            Next
            strData = Mid(strData, 1, strData.Length - 1)
            arrReportCalcs.Add(strData)
        End While
        objReader.Close()
        'Reader the array list and use it for inserting into the payroll 
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemReportColumnCalculations", cnn)
        sqlCommand.ExecuteNonQuery()
        newConn = New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()
        pb1.Value = 0
        pb1.Visible = True
        pb1.Maximum = arrReportCalcs.Count
        strSql = Nothing
        For i = 0 To arrReportCalcs.Count - 1
            Dim strBuffer() As String = Split(arrReportCalcs(i), "|")
            strSql = "INSERT INTO SystemReportColumnCalculations ([IndNo]," _
                & "[IndVal],[OP1A],[OP1N],[OP2A],[OP2N],[OP3A],[OP3N]," _
                & "[OPCode],[OrdinalNo],[ReportNo])" _
                & " VALUES (" & strBuffer(0) & ", '" & strBuffer(1) & "', " _
                & "'" & strBuffer(2) & "', " & strBuffer(3) & ", '" & strBuffer(4) & "', " _
                & "" & strBuffer(5) & ", '" & strBuffer(6) & "', " & strBuffer(7) & ", " _
                & "'" & strBuffer(8) & "', " & strBuffer(9) & ", " & strBuffer(10) & ")"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next
        '
        'Import the column headers
        '
        MessageBox.Show("Unfortunately due to poor table structure of the column headers, you have to input them manually", _
            "Paywell Column Reports Import", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Paywell Column Reports Import"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ImportPaywellYearToDates()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT [SourceCodeA]," _
            & "[SourceCodeN],[DestinationCodeA],[DestinationCodeN] FROM " _
            & "[PW_Parm_AutoYTD] WHERE Payroll = 1 ORDER BY OrdinalNo", PayConn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim arrYtds As New ArrayList
        Dim i As Integer = 0
        While objReader.Read
            Dim strData As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strData = strData & Replace(objReader(i).ToString, "'", "", 1) & "|"
            Next
            strData = Mid(strData, 1, strData.Length - 1)
            arrYtds.Add(strData)
        End While
        objReader.Close()
        'Reader the array list and use it for inserting into the payroll 
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemYearToDates", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim newConn As New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()
        pb1.Value = 0
        pb1.Visible = True
        pb1.Maximum = arrYtds.Count
        Dim strSql As String = Nothing
        For i = 0 To arrYtds.Count - 1
            Dim strBuffer() As String = Split(arrYtds(i), "|")
            strSql = "INSERT INTO SystemYearToDates (SourceCodeA, SourceCodeN, DestinationCodeA, DestinationCodeN) " _
            & " VALUES ('" & strBuffer(0) & "', " & strBuffer(1) & ", '" & strBuffer(2) & "', " & strBuffer(3) & ")"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next

        'Dynamicx auto year to dates are in build into the code description
        'After import, transfer the values to the relevant codes
        strSql = "SELECT SourceCodeN, DestinationCodeN FROM SystemYearToDates"
        sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            strSql = "UPDATE SystemCodes SET YtdCode = " & objReader(1).ToString & " WHERE CodeNo = " & objReader(0).ToString & ""
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
            sqlCommand.ExecuteNonQuery()
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Paywell Year-To-Dates Import"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ImportPaywellBanks()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT [BankSortCode]," _
            & "[BankName],[BranchAddr1],[BranchAddr2],[BranchAddr3]," _
            & "[BranchAddr4] FROM [PW_Bankf]", PayConn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim arrBanks As New ArrayList
        Dim i As Integer = 0
        While objReader.Read
            Dim strData As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strData = strData & Replace(objReader(i).ToString, "'", "", 1) & "|"
            Next
            strData = Mid(strData, 1, strData.Length - 1)
            arrBanks.Add(strData)
        End While
        objReader.Close()
        'Reader the array list and use it for inserting into the payroll 
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemBanks", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim newConn As New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()
        pb1.Value = 0
        pb1.Visible = True
        pb1.Maximum = arrBanks.Count
        Dim strSql As String = Nothing
        For i = 0 To arrBanks.Count - 1
            Dim strBuffer() As String = Split(arrBanks(i), "|")
            strSql = "INSERT INTO SystemBanks (BankCode, BankName, Address1, Address2, Address3, Address4) " _
            & " VALUES ('" & strBuffer(0) & "', '" & strBuffer(1) & "', '" & strBuffer(2) & "', '" & strBuffer(3) & "', '" & strBuffer(4) & "', '" & strBuffer(5) & "')"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Paywell Banks Import"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ImportPaywellDates()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT OrdinalNo, " _
            & "DateName FROM PW_Parm_DateNames WHERE Payroll = 1 ORDER BY OrdinalNo", PayConn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim arrDates As New ArrayList
        Dim i As Integer = 0
        While objReader.Read
            Dim strData As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strData = strData & Replace(objReader(i).ToString, "'", "", 1) & "|"
            Next
            strData = Mid(strData, 1, strData.Length - 1)
            arrDates.Add(strData)
        End While
        objReader.Close()
        If arrDates.Count < 25 Then
            For i = arrDates.Count To 24
                Dim strData As String = Nothing
                strData = (i + 1) & "|"
                arrDates.Add(strData)
            Next
        End If
        'Reader the array list and use it for inserting into the payroll codes
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemDates", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim newConn As New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()
        pb1.Value = 0
        pb1.Visible = True
        pb1.Maximum = arrDates.Count
        Dim strSql As String = Nothing
        For i = 0 To arrDates.Count - 1
            Dim strBuffer() As String = Split(arrDates(i), "|")
            strSql = "INSERT INTO SystemDates (OrdinalNo, DateName) " _
            & " VALUES (" & strBuffer(0) & ", '" & strBuffer(1) & "')"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Paywell Dates Import"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ImportPaywellIndicators()
        On Error GoTo RaiseErr
        '
        'First Import the indicator names and then the indicator values
        '
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT [IndicatorNo]," _
            & "[IndName],[IndDefaultNo] FROM [PW_Parm_IndicatorNames] WHERE " _
            & "[Payroll] = 1", PayConn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim arrIndNames As New ArrayList
        Dim i As Integer = 0
        While objReader.Read
            Dim strData As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strData = strData & Replace(objReader(i).ToString, "'", "", 1) & "|"
            Next
            strData = Mid(strData, 1, strData.Length - 1)
            arrIndNames.Add(strData)
        End While
        objReader.Close()
        'Reader the array list and use it for inserting into the payroll codes
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemFlagNames", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim newConn As New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()
        pb1.Value = 0
        pb1.Visible = True
        pb1.Maximum = arrIndNames.Count
        Dim strSql As String = Nothing
        For i = 0 To arrIndNames.Count - 1
            Dim strBuffer() As String = Split(arrIndNames(i), "|")
            strSql = "INSERT INTO SystemFlagNames (FlagNo, FlagName, FlagDefault) " _
            & " VALUES (" & strBuffer(0) & ", '" & strBuffer(1) & "', " & strBuffer(2) & ")"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next
        '
        'Get the indicator values
        '
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT [IndicatorNo]," _
            & "[IndVal],[IndValName],[OrdinalNo] FROM [PW_Parm_IndicatorValues] " _
            & "WHERE [Payroll] = 1", PayConn)
        objReader = sqlCommand.ExecuteReader
        Dim arrIndValues As New ArrayList
        i = 0
        While objReader.Read
            Dim strData As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strData = strData & Replace(objReader(i).ToString, "'", "", 1) & "|"
            Next
            strData = Mid(strData, 1, strData.Length - 1)
            arrIndValues.Add(strData)
        End While
        objReader.Close()
        'Reader the array list and use it for inserting into the payroll codes
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemFlagValues", cnn)
        sqlCommand.ExecuteNonQuery()
        newConn = New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()
        pb1.Value = 0
        pb1.Visible = True
        pb1.Maximum = arrIndValues.Count
        strSql = Nothing
        For i = 0 To arrIndValues.Count - 1
            Dim strBuffer() As String = Split(arrIndValues(i), "|")
            strSql = "INSERT INTO SystemFlagValues (FlagNo, FlagValue, FlagName, OrdinalNo) " _
            & " VALUES (" & strBuffer(0) & ", '" & strBuffer(1) & "', '" & strBuffer(2) & "', " & strBuffer(3) & ")"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Paywell Indicators Import"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ImportPaywellRefnumbers()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT OrdinalNo, " _
            & "RefNoName FROM PW_Parm_RefNoNames WHERE Payroll = 1 ORDER BY OrdinalNo", PayConn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim arrRefs As New ArrayList
        Dim i As Integer = 0
        While objReader.Read
            Dim strData As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strData = strData & Replace(objReader(i).ToString, "'", "", 1) & "|"
            Next
            strData = Mid(strData, 1, strData.Length - 1)
            arrRefs.Add(strData)
        End While
        objReader.Close()

        'Reader the array list and use it for inserting into the payroll codes
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemReferences", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim newConn As New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()
        pb1.Value = 0
        pb1.Visible = True
        pb1.Maximum = arrRefs.Count
        Dim strSql As String = Nothing
        For i = 0 To arrRefs.Count - 1
            Dim strBuffer() As String = Split(arrRefs(i), "|")
            strSql = "INSERT INTO SystemReferences (OrdinalNo, ReferenceName) " _
            & " VALUES (" & strBuffer(0) & ", '" & strBuffer(1) & "')"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Paywell Reference Names Import"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.cboAuthentication.Text = "" Then
            MessageBox.Show("Please select the authentication mode", "Missing Database Authentication Mode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAuthentication.Focus()
            Exit Sub
        End If
        InitializeImports()
        Me.Close()
    End Sub

    Private Sub ImportExceptions()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT Mess, OrdinalNo FROM PW_Parm_Exceptions " _
            & "WHERE Payroll = 1 ORDER BY OrdinalNo", PayConn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim arrExceptions As New ArrayList
        Dim i As Integer = 0
        While objReader.Read
            Dim strData As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strData = strData & Replace(objReader(i).ToString, "'", "", 1) & "|"
            Next
            strData = Mid(strData, 1, strData.Length - 1)
            arrExceptions.Add(strData)
        End While
        objReader.Close()

        'Reader the array list and use it for inserting into the payroll codes
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemExceptions", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim newConn As New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()
        pb1.Value = 0
        pb1.Visible = True
        pb1.Maximum = arrExceptions.Count
        'Create the blank records first
        For i = 1 To 100
            Dim strSqlStatement As String = "INSERT INTO SystemExceptions (OrdinalNo, Mess) VALUES (" & i & ", '')"
            sqlCommand = New Data.OleDb.OleDbCommand(strSqlStatement, newConn)
            sqlCommand.ExecuteNonQuery()
        Next
        For i = 0 To arrExceptions.Count - 1
            Dim strValues() As String = Split(arrExceptions.Item(i), "|")
            Dim strSqlStatement As String = "UPDATE SystemExceptions " _
                & "SET Mess = '" & strValues(0) & "' WHERE OrdinalNo = " & strValues(1) & ""
            sqlCommand = New Data.OleDb.OleDbCommand(strSqlStatement, newConn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Paywell Exceptions Import"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ImportPaywellRegisters()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT OrdinalNo, " _
            & "RegName, RegValue FROM PW_Parm_Registers WHERE Payroll = 1 ORDER BY OrdinalNo", PayConn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim arrConstants As New ArrayList
        Dim i As Integer = 0
        While objReader.Read
            Dim strData As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strData = strData & Replace(objReader(i).ToString, "'", "", 1) & "|"
            Next
            strData = Mid(strData, 1, strData.Length - 1)
            arrConstants.Add(strData)
        End While
        objReader.Close()
        If arrConstants.Count < 100 Then
            For i = arrConstants.Count To 99
                Dim strData As String = Nothing
                strData = (i + 2) & "|" & "|0000.0000"
                arrConstants.Add(strData)
            Next
        End If
        'Reader the array list and use it for inserting into the payroll codes
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemConstants", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim newConn As New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()
        pb1.Value = 0
        pb1.Visible = True
        pb1.Maximum = arrConstants.Count
        'Create the blank records first
        For i = 1 To 100
            Dim strSqlStatement As String = "INSERT INTO SystemConstants (ConstantNo, Description, " _
            & "ConstantValue) VALUES (" & i & ", '', 0)"
            sqlCommand = New Data.OleDb.OleDbCommand(strSqlStatement, newConn)
            sqlCommand.ExecuteNonQuery()
        Next

        Dim strSql As String = Nothing
        For i = 0 To arrConstants.Count - 1
            Dim strBuffer() As String = Split(arrConstants(i), "|")
            strSql = "Update SystemConstants SET Description =  '" & strBuffer(1) & "', " _
            & "ConstantValue = " & strBuffer(2) & " WHERE ConstantNo = " & strBuffer(0) & ""
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Constants Import line no " & (i + 1)
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ImportPaywellMasterFile()
        On Error GoTo RaiseErr

        'Open paybasic database and make the insertions
        Dim newConn As New Data.OleDb.OleDbConnection(strConnection)
        newConn.Open()

        If MessageBox.Show("Do you want to empty tables before adding new records?", "Confirm Clear Table", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim objDeleteRecords As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeDates", cnn)
            objDeleteRecords.ExecuteNonQuery()
            objDeleteRecords = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeMaster", cnn)
            objDeleteRecords.ExecuteNonQuery()
            objDeleteRecords = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeDates", cnn)
            objDeleteRecords.ExecuteNonQuery()
            objDeleteRecords = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeBanks", cnn)
            objDeleteRecords.ExecuteNonQuery()
            objDeleteRecords = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeFlags", cnn)
            objDeleteRecords.ExecuteNonQuery()
            objDeleteRecords = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeCodes", cnn)
            objDeleteRecords.ExecuteNonQuery()
            objDeleteRecords = New Data.OleDb.OleDbCommand("DELETE FROM Employment", cnn)
            objDeleteRecords.ExecuteNonQuery()
            objDeleteRecords = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeContacts", cnn)
            objDeleteRecords.ExecuteNonQuery()
        End If

        Dim strSql As String = "SELECT pw_imf.EmpNo, pw_imf.Surname, pw_imf.GivenNames, " _
          & "dateadd(dd, pw_imf.birthdate, '1/1/1800') as birthdate, pw_imf.Addr1, pw_imf.Addr2, " _
          & "pw_imf.Addr3, pw_imf.Addr4, pw_imf.TelephoneNo, pw_imf.Email, " _
          & "pw_imf.ClockNo, pw_imf.DirAmt, pw_imf.DirPercent, pw_imf.DischDate, " _
          & "pw_imf.DischRsn, pw_imf.Inits, pw_imf.StopFrom, pw_imf.StopTo, " _
          & "pw_imf.TaxCode, pw_imf.TaxDependants, pw_imf.TaxRef, " _
          & "pw_imf.Title FROM pw_imf ORDER BY pw_imf.empno"
        Dim i As Integer = 0
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, PayConn)
        Dim arrMaster As New ArrayList
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        While objReader.Read
            Dim strRecord As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strRecord = strRecord & objReader(i).ToString & "|"
            Next
            If Not String.IsNullOrEmpty(strRecord) Then
                strRecord = Mid(strRecord, 1, (strRecord.Length - 1))
            End If
            arrMaster.Add(strRecord)
        End While
        objReader.Close()

        'Get employee employment details like codt code and paypoint and add to array
        strSql = "SELECT DISTINCT EmpNo, CostCodes, PayPoint, EngageDate FROM PW_Imf ORDER BY EmpNo"
        sqlCommand = New Data.OleDb.OleDbCommand(strSql, PayConn)
        Dim arrEmployment As New ArrayList
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            Dim strRecord As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strRecord = strRecord & objReader(i).ToString & "|"
            Next
            If Not String.IsNullOrEmpty(strRecord) Then
                strRecord = Mid(strRecord, 1, (strRecord.Length - 1))
            End If
            arrEmployment.Add(strRecord)
        End While
        objReader.Close()

        'Get the employee dates
        strSql = "SELECT EmpNo, OrdinalNo, DateValue FROM PW_Dates ORDER BY EmpNo"
        sqlCommand = New Data.OleDb.OleDbCommand(strSql, PayConn)
        Dim arrEmployeeDates As New ArrayList
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            Dim strRecord As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strRecord = strRecord & objReader(i).ToString & "|"
            Next
            If Not String.IsNullOrEmpty(strRecord) Then
                strRecord = Mid(strRecord, 1, (strRecord.Length - 1))
            End If
            arrEmployeeDates.Add(strRecord)
        End While

        'Get the employee reference numbers
        strSql = "SELECT EmpNo, OrdinalNo, RefNo FROM PW_RefNos ORDER BY EmpNo"
        sqlCommand = New Data.OleDb.OleDbCommand(strSql, PayConn)
        Dim arrEmployeeRefs As New ArrayList
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            Dim strRecord As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strRecord = strRecord & objReader(i).ToString & "|"
            Next
            If Not String.IsNullOrEmpty(strRecord) Then
                strRecord = Mid(strRecord, 1, (strRecord.Length - 1))
            End If
            arrEmployeeRefs.Add(strRecord)
        End While

        'Get the employee banking details
        strSql = "SELECT EmpNo, PayMode, DestinBankSortCode, DestinBankAccountNumber, DestinAccountType FROM PW_PayeeDetails"
        sqlCommand = New Data.OleDb.OleDbCommand(strSql, PayConn)
        Dim arrEmployeeBanks As New ArrayList
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            Dim strRecord As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strRecord = strRecord & objReader(i).ToString & "|"
            Next
            If Not String.IsNullOrEmpty(strRecord) Then
                strRecord = Mid(strRecord, 1, (strRecord.Length - 1))
            End If
            arrEmployeeBanks.Add(strRecord)
        End While

        'Get the employee Indicators
        strSql = "SELECT EmpNo, OrdinalNo, Ind FROM PW_Inds ORDER BY EmpNo"
        sqlCommand = New Data.OleDb.OleDbCommand(strSql, PayConn)
        Dim arrEmployeeInds As New ArrayList
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            Dim strRecord As String = Nothing
            For i = 0 To objReader.FieldCount - 1
                strRecord = strRecord & objReader(i).ToString & "|"
            Next
            If Not String.IsNullOrEmpty(strRecord) Then
                strRecord = Mid(strRecord, 1, (strRecord.Length - 1))
            End If
            arrEmployeeInds.Add(strRecord)
        End While

        '-*-*-----------------------------------------------------------------------------*-*'       
        'We begin with the master record
        Dim strEnum As String = 0
        For i = 0 To arrMaster.Count - 1
            Dim strBuffer() As String = Split(arrMaster.Item(i), "|")
            strEnum = strBuffer(0)
            'Replace all the undesired characters
            Dim x As Integer = 0
            For x = 0 To strBuffer.Length - 1
                strBuffer(x) = Replace(strBuffer(x), "'", "", 1)
                strBuffer(x) = Replace(strBuffer(x), Chr(34), "", 1)
            Next
            Dim strSplitName() As String = Split(strBuffer(2), " ")
            Dim strOtherNames As String = Nothing
            Dim strFirstName As String = Nothing
            If strSplitName.Length > 1 Then
                Dim p As Integer = 0
                For p = 1 To strSplitName.Length - 1
                    strOtherNames = strOtherNames & strSplitName(p) & " "
                Next
                strOtherNames = Mid(strOtherNames, 1, (strOtherNames.Length - 1))
                strFirstName = strSplitName(0)
            Else
                strFirstName = strBuffer(2)
            End If
            Dim strInits As String = Mid(strFirstName, 1, 1)
            If Not String.IsNullOrEmpty(strOtherNames) Then
                strInits = strInits & " " & Mid(strOtherNames, 1, 1)
            End If
            strInits = UCase(strInits)
            Dim strDischargeDate As String
            If CInt(strBuffer(13)) = 0 Then
                strDischargeDate = Nothing
            Else
                strDischargeDate = CStr(DateAdd(DateInterval.Day, CInt(strBuffer(13)), CDate("01-01-1800")))
            End If
            Dim strEmpState As String = "ACTIVE"
            If Not String.IsNullOrEmpty(strDischargeDate) Then strEmpState = "INACTIVE"
            If strBuffer(0) <> "0" Then
                strSql = "INSERT INTO EmployeeMaster (EmployeeNo,LastName," _
                    & "FirstName,OtherNames,IdNumber,Gender,BirthDate," _
                    & "MaritalStatus,Address1,Address2,Address3,Address4," _
                    & "Telephone,Cellphone,EmailAddress,ClockNo,DirAmt," _
                    & "DirPercent,DischDate,DischRsn,Inits,StopFrom,StopTo," _
                    & "TaxCode,TaxDependents,TaxRef,Title,Status)  VALUES (" _
                    & "'" & strBuffer(0) & "', '" & strBuffer(1) & "', '" & strFirstName & "', " _
                    & "'" & strOtherNames & "', '0', 'Male', '" & strBuffer(3) & "', '', " _
                    & "'" & strBuffer(4) & "', '" & strBuffer(5) & "', '" & strBuffer(6) & "', " _
                    & "'" & strBuffer(7) & "', '" & strBuffer(8) & "', '', '" & strBuffer(9) & "', " _
                    & "" & strBuffer(10) & ", " & strBuffer(11) & ", " & strBuffer(12) & ", " _
                    & "'" & strDischargeDate & "', '" & strBuffer(14) & "', '" & strBuffer(15) & "', " _
                    & "" & strBuffer(16) & ", " & strBuffer(17) & ", '" & strBuffer(18) & "', " _
                    & "'" & strBuffer(19) & "', '" & strBuffer(20) & "', '" & strBuffer(21) & "', '" & strEmpState & "')"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
                sqlCommand.ExecuteNonQuery()
            End If
        Next

        'Insert the employee dates
        For i = 0 To arrEmployeeDates.Count - 1
            If strEnum <> "0" Then
                Dim strBuffer() As String = Split(arrEmployeeDates.Item(i), "|")
                Dim strDateValue As String = Nothing
                If CInt(strBuffer(2)) > 0 Then
                    strDateValue = CStr(DateAdd(DateInterval.Day, CInt(strBuffer(2)), CDate("01-01-1800")))
                End If
                strSql = "INSERT INTO EmployeeDates (EmployeeNo, OrdinalNo, DateValue) VALUES (" _
                    & "'" & strBuffer(0) & "', " & strBuffer(1) & ", '" & strDateValue & "')"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
                sqlCommand.ExecuteNonQuery()
            End If
        Next

        'Insert the employment table
        For i = 0 To arrEmployment.Count - 1
            If strEnum <> "0" Then
                Dim strBuffer() As String = Split(arrEmployment.Item(i), "|")
                Dim strEmploymentValue As String = Nothing
                Dim strHireDate As String
                If CInt(strBuffer(3)) = 0 Then
                    strHireDate = Nothing
                Else
                    strHireDate = CStr(DateAdd(DateInterval.Day, CInt(strBuffer(3)), CDate("01-01-1800")))
                End If
                strSql = "INSERT INTO Employment (EmployeeNo, CostCenter, PayPoint, HireDate) VALUES (" _
                    & "'" & strBuffer(0) & "', '" & strBuffer(1) & "', '" & strBuffer(2) & "', '" & strHireDate & "')"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
                sqlCommand.ExecuteNonQuery()
            End If
        Next

        'Insert the employee references
        For i = 0 To arrEmployeeRefs.Count - 1
            If strEnum <> "0" Then
                Dim strBuffer() As String = Split(arrEmployeeRefs.Item(i), "|")
                Dim strRef As String = Nothing
                strSql = "INSERT INTO EmployeeReferences (EmployeeNo, OrdinalNo, Reference) VALUES (" _
                    & "'" & strBuffer(0) & "', " & strBuffer(1) & ", '" & strBuffer(2) & "')"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
                sqlCommand.ExecuteNonQuery()
                'Update id number
                If CInt(strBuffer(1)) = 1 Then
                    sqlCommand = New Data.OleDb.OleDbCommand("UPDATE EmployeeMaster SET " _
                        & "IdNumber = '" & strBuffer(2) & "' WHERE EmployeeNo = '" & strBuffer(0) & "'", newConn)
                    sqlCommand.ExecuteNonQuery()
                End If
            End If
        Next

        'Insert the employee banking details
        For i = 0 To arrEmployeeBanks.Count - 1
            If strEnum <> "0" Then
                Dim strBuffer() As String = Split(arrEmployeeBanks.Item(i), "|")
                strSql = "INSERT INTO EmployeeBanks (EmployeeNo, PayMethod, BankCode, AccountNumber, AccountType) VALUES (" _
                    & "'" & strBuffer(0) & "', '" & strBuffer(1) & "', '" & strBuffer(2) & "', '" & strBuffer(3) & "', '" & strBuffer(4) & "')"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
                sqlCommand.ExecuteNonQuery()
            End If
        Next

        'Insert the employee indicators
        For i = 0 To arrEmployeeInds.Count - 1
            If strEnum <> "0" Then
                Dim strBuffer() As String = Split(arrEmployeeInds.Item(i), "|")
                strSql = "INSERT INTO EmployeeFlags (EmployeeNo, OrdinalNo, Flag) VALUES (" _
                    & "'" & strBuffer(0) & "', '" & strBuffer(1) & "', '" & strBuffer(2) & "')"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
                sqlCommand.ExecuteNonQuery()
            End If
        Next
        'Add the employee contacts
        For i = 0 To arrMaster.Count - 1
            If strEnum <> "0" Then
                Dim strBuffer() As String = Split(arrMaster.Item(i), "|")
                strSql = "INSERT INTO EmployeeContacts (EmployeeNo, Relationship) VALUES (" _
                    & "'" & strBuffer(0) & "', '')"
                sqlCommand = New Data.OleDb.OleDbCommand(strSql, newConn)
                sqlCommand.ExecuteNonQuery()
            End If
        Next
        'Initialize employee codes and then update afterwards
        'Get the count of paywell codes
        If strEnum <> "0" Then
            strSql = "SELECT count(OrdinalNo) FROM PW_Parm_Codes"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, PayConn)
            objReader = sqlCommand.ExecuteReader
            Dim intCodeCount As Integer = 0
            While objReader.Read
                intCodeCount = CInt(objReader(0).ToString)
            End While
            objReader.Close()
            pb1.Visible = True
            pb1.Value = 0
            pb1.Maximum = (arrMaster.Count * intCodeCount)
            strSql = "SELECT EmpNo, OrdinalNo, Amt FROM PW_Amts ORDER BY EmpNo"
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, PayConn)
            objReader = sqlCommand.ExecuteReader
            While objReader.Read
                Dim strInsert As String = "INSERT INTO EmployeeCodes (EmployeeNo, CodeNo, Amount) VALUES (" _
                        & "'" & objReader(0).ToString & "', " & CInt(objReader(1).ToString) & ", " & CDbl(objReader(2).ToString) & ")"
                sqlCommand = New Data.OleDb.OleDbCommand(strInsert, newConn)
                sqlCommand.ExecuteNonQuery()
                pb1.Value = pb1.Value + 1
            End While
            pb1.Value = pb1.Maximum
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Master File line no " & (i + 1)
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ImportRunFile()
        On Error GoTo RaiseErr
        'Using the employee master record get the details from the run file
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReadMaster As Data.OleDb.OleDbDataReader
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeRunFile", cnn)
        objCommand.ExecuteNonQuery()
        objCommand = New Data.OleDb.OleDbCommand("SELECT DISTINCT EmployeeNo FROM EmployeeMaster ORDER BY EmployeeNo", cnn)
        objReadMaster = objCommand.ExecuteReader
        'Get the last code number in the codes file
        Dim intNumberOfCodes As Integer = 1000
        Dim objComCodes As New Data.OleDb.OleDbCommand("SELECT CodeNo FROM SystemCodes ORDER BY CodeNo DESC", cnn)
        Dim objReadCodes As Data.OleDb.OleDbDataReader = objComCodes.ExecuteReader
        If objReadCodes.HasRows Then
            objReadCodes.Read()
            If IsNumeric(objReadCodes(0).ToString) Then intNumberOfCodes = CInt(objReadCodes(0).ToString)
        End If
        objReadCodes.Close()
        Dim i As Integer = 0
        pb1.Value = 0 : pb1.Maximum = 100 : pb1.Visible = True
        While objReadMaster.Read
            Dim objCommandPaywellRunFile As New Data.OleDb.OleDbCommand("SELECT " _
                & "OrdinalNo, Amt FROM PW_Runfamts WHERE EmpNo = " & objReadMaster(0).ToString & "", PayConn)
            Dim objReadRunFile As Data.OleDb.OleDbDataReader = objCommandPaywellRunFile.ExecuteReader
            Dim strValues(0 To (intNumberOfCodes - 1)) As String
            'Initialize the values to zero
            For i = 0 To intNumberOfCodes - 1
                strValues(i) = "0.00"
            Next
            While objReadRunFile.Read
                strValues(CInt(objReadRunFile(0).ToString) - 1) = objReadRunFile(1).ToString
            End While
            Dim strCodeLine As String = Nothing
            For i = 0 To strValues.Length - 1
                strCodeLine = strCodeLine & "|" & strValues(i)
            Next
            strCodeLine = Mid(strCodeLine, 2, (strCodeLine.Length - 1))
            'Insert the details into the run file in Pay Basics
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeRunFile " _
                & "(EmployeeNo, RunAmounts) VALUES ('" & objReadMaster(0).ToString & "', " _
                & "'" & strCodeLine & "')", cnn)
            objCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
            If pb1.Value = 99 Then pb1.Value = 0
        End While
        objReadMaster.Close()
        'Update the Employee Codes with the values as well
        objCommand = New Data.OleDb.OleDbCommand("SELECT EmployeeNo, RunAmounts FROM EmployeeRunFile", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        pb1.Value = 0 : pb1.Maximum = 100
        While objReader.Read
            Dim strCodeValues() As String
            If Not IsDBNull(objReader(1).ToString) Then
                strCodeValues = Split(objReader(1).ToString, "|")
                For i = 0 To strCodeValues.Length - 1
                    objCommand = New Data.OleDb.OleDbCommand("UPDATE EmployeeCodes SET " _
                        & "Amount = " & CDbl(strCodeValues(i)) & " WHERE EmployeeNo = " _
                        & "'" & objReader(0).ToString & "' AND CodeNo = " & (i + 1) & "", cnn)
                    objCommand.ExecuteNonQuery()
                Next
            End If
            pb1.Value = pb1.Value + 1
            If pb1.Value = 99 Then pb1.Value = 0
        End While
        objReader.Close()
        MessageBox.Show("Employee Run File Details Uploaded Successfully", "Run File Upload Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Run File Import"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboAuthentication_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAuthentication.SelectedIndexChanged
        If Me.cboAuthentication.Text = "Windows Authentication" Then
            txtUserName.Enabled = False
            txtPassword.Enabled = False
        Else
            txtPassword.Enabled = True
            txtUserName.Enabled = True
        End If
    End Sub

    Private Sub frmPaywellImports_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
