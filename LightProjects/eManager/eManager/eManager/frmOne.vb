Imports System.Data.SqlServerCe
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmOne

    Dim arrMaster As ArrayList
    Dim arrPrintDetails As ArrayList

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim arrExcelData As ArrayList

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnOrganisation_Click(sender As System.Object, e As System.EventArgs) Handles btnOrganisation.Click
        Dim f As New frmSettings
        f.ShowDialog()
    End Sub

    Private Sub btnBackupPath_Click(sender As System.Object, e As System.EventArgs) Handles btnBackupPath.Click
        Dim f As New frmRunBackup
        f.ShowDialog()
    End Sub

    Private Sub btnTaxCertifcates_Click(sender As System.Object, e As System.EventArgs) Handles btnTaxCertifcates.Click
        Dim frm As New frmEmployeeTaxCertificates
        frm.ShowDialog()
    End Sub

    Private Sub frmOne_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        Dim f As New frmLogin
        f.ShowDialog()
        If boolAbort = True Then Exit Sub

        LoadAllData()
        LoadEmployees()
        LoadTransactionData(Format(CDate(dpStartDate.Value), "dd-MMM-yyyy"), Format(CDate(dpEndDate.Value), "dd-MMM-yyyy"), "ALL")
        LoadProcessedData()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim f As New frmDirectorSetup
        f.ShowDialog()
        LoadData("Last Name")
    End Sub

    Private Sub GetSelected()
        If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(4).Value), "") Then
            If IsNumeric(dGrid.CurrentRow.Cells(4).Value.ToString) Then
                intSelectedTransactionId = CInt(dGrid.CurrentRow.Cells(4).Value.ToString)
                boolEditStatus = True
                Dim f As New frmDirectorSetup
                f.ShowDialog()
                LoadAllData()
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        GetSelected()
    End Sub

    Private Sub LoadAllData()
        On Error GoTo RaiseErr
        Dim strSql As String

        strSql = "SELECT LastName, FirstName +' '+ OtherNames AS [Given Names], Cellphone, EmailAddress, TransactionId " _
            & "FROM EmployeeMaster ORDER BY LastName, FirstName, OtherNames"

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New Data.OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New Data.OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        dGrid.Columns(dGrid.Columns.Count - 1).Visible = False

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On directors list details load"
        ShowErrorMessage()
    End Sub

    Private Sub cboSearchBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchBy.SelectedIndexChanged
        If cboSearchBy.SelectedItem.ToString = "Last Name" Then LoadData("Last Name") Else LoadData("First Name")
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        Dim strText As String = Nothing
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 18 Then
            strText = txtSearchString.Text
        Else
            strText = txtSearchString.Text & e.KeyChar
        End If
        SearchResults(strText)
    End Sub

    Private Sub SearchResults(SearchString As String)
        On Error GoTo RaiseErr
        'dGrid.Rows.Clear()

        Dim strSearchCriteria As String = cboSearchBy.SelectedItem.ToString

        Dim strSql As String = "SELECT LastName AS [Surname], FirstName +' '+ OtherNames AS [Given Names], " _
            & "Cellphone, EmailAddress as [Email Address], TransactionId " _
            & "FROM EmployeeMaster WHERE LastName LIKE '%" & SearchString & "%' ORDER BY LastName, FirstName, OtherNames"

        If UCase(strSearchCriteria) = UCase("First Name") Then
            strSql = "SELECT LastName as [Surname], FirstName +' '+ OtherNames as [Given Names], " _
                & "Cellphone, EmailAddress as [Email Address], TransactionId " _
                & "FROM EmployeeMaster WHERE FirstName LIKE '%" & SearchString & "%' ORDER BY FirstName, LastName, OtherNames"
        End If

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New Data.OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New Data.OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        dGrid.Columns(dGrid.Columns.Count - 1).Visible = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Directors Listing Search"
        ShowErrorMessage()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If dGrid.Rows.Count > 0 Then
            If MessageBox.Show("Are you sure you want to delete the selected record?", "Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                intSelectedTransactionId = CInt(dGrid.CurrentRow.Cells(4).Value.ToString)
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeMaster WHERE TransactionId = " & intSelectedTransactionId & "", cnn)
                objCommand.ExecuteNonQuery()
                MessageBox.Show("Record hase been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadAllData()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On record delete"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData(SearchBy As String)
        On Error GoTo RaiseErr
        Dim strSql As String
        Select Case UCase(SearchBy)
            Case Is = UCase("Surname")
                strSql = "SELECT LastName, FirstName +' '+ OtherNames AS [Given Names], Cellphone, EmailAddress, TransactionId " _
                    & "FROM EmployeeMaster ORDER BY LastName, FirstName, OtherNames"
            Case Is = UCase("Given Names")
                strSql = "SELECT LastName, FirstName +' '+ OtherNames AS [Given Names], Cellphone, EmailAddress, TransactionId " _
                    & "FROM EmployeeMaster ORDER BY FirstName, OtherNames, LastName"
            Case Else
                strSql = "SELECT LastName, FirstName +' '+ OtherNames AS [Given Names], Cellphone, EmailAddress, TransactionId " _
                    & "FROM EmployeeMaster ORDER BY LastName, FirstName, OtherNames"
        End Select
        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New Data.OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New Data.OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        dGrid.Columns(dGrid.Columns.Count - 1).Visible = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On directors list details load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellContentDoubleClick
        GetSelected()
    End Sub

    '********************************************************************************************
    '               TRANSACTIONS LISTING AND MAINTENANCE CODE BEGINS HERE                       *
    '********************************************************************************************

    Private Sub btnNewTransaction_Click(sender As System.Object, e As System.EventArgs) Handles btnNewTransaction.Click
        boolEditStatus = False
        Dim f As New frmTransactionEntry
        f.ShowDialog()
        LoadTransactionData(Format(dpStartDate.Value, "dd-MMM-yyyy"), Format(dpEndDate.Value, "dd-MMM-yyyy"), "ALL")
    End Sub

    Private Sub LoadTransactionData(StartDate As Date, EndDate As Date, Criteria As String)
        On Error GoTo RaiseErr
        'Date, Description, Reason, Director, Amount, Status, PaymentDate, Id
        Dim strSql As String = Nothing

        If UCase(Criteria) = "ALL" Then
            strSql = "SELECT UPPER(REPLACE(CONVERT(NVARCHAR(11), Payments.TransDate, 106), ' ', '-')) as [Date], " _
                & "PaymentCodes.Description, Payments.Purpose, " _
                & "EmployeeMaster.LastName + ' '+ EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames AS [Director], " _
                & "CAST(Payments.Amount AS DECIMAL (10,2)) AS [Amt], Payments.Status, Payments.PaymentDate, " _
                & "Payments.TransId, Payments.DirectorId, Payments.PayCode FROM Payments LEFT OUTER JOIN EmployeeMaster ON Payments.DirectorId = " _
                & "EmployeeMaster.TransactionId LEFT OUTER JOIN PaymentCodes ON Payments.PayCode = PaymentCodes.CodeNo " _
                & "WHERE Payments.TransDate BETWEEN '" & StartDate & "' AND '" & EndDate & "' AND Status = 'PENDING' ORDER BY Payments.TransDate"
        Else
            strSql = "SELECT UPPER(REPLACE(CONVERT(NVARCHAR(11), Payments.TransDate, 106), ' ', '-')) as [Date], " _
                & "PaymentCodes.Description, Payments.Purpose, " _
                & "EmployeeMaster.LastName + ' '+ EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames AS [Director], " _
                & "CAST(Payments.Amount AS DECIMAL (10,2)) AS [Amt], Payments.Status, Payments.PaymentDate, " _
                & "Payments.TransId, Payments.DirectorId, Payments.PayCode FROM Payments LEFT OUTER JOIN EmployeeMaster ON Payments.DirectorId = " _
                & "EmployeeMaster.TransactionId LEFT OUTER JOIN PaymentCodes ON Payments.PayCode = PaymentCodes.CodeNo " _
                & "WHERE Payments.TransDate BETWEEN '" & StartDate & "' AND '" & EndDate & "' AND " _
                & "Status = 'PENDING' AND EmployeeMaster.TransactionId = " & lblId.Text & " ORDER BY Payments.TransDate"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridTransactions.Rows.Clear()
        While objReader.Read
            dGridTransactions.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5), _
                objReader(6), objReader(7), objReader(8), objReader(9))
        End While
        objReader.Close()
        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Transaction Entry Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr
        Dim dblTotalEarnings As Double = 0
        Dim dblTotalDeductions As Double = 0
        Dim dblTotalPayable As Double = 0
        For i As Integer = 0 To dGridTransactions.Rows.Count - 1
            Dim intCode As Integer = CInt(dGridTransactions.Rows(i).Cells(9).Value.ToString)
            Dim dblAmount As Double = CDbl(dGridTransactions.Rows(i).Cells(4).Value.ToString)
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT PaymentCodes.PayType " _
                & "FROM PaymentCodes WHERE PaymentCodes.CodeNo = " & intCode & "", cnn)
            Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReader.Read
                If objReader(0).ToString = "EARNING" Then
                    dblTotalEarnings = dblTotalEarnings + dblAmount
                End If
                If objReader(0).ToString = "DEDUCTION" Then
                    dblTotalDeductions = dblTotalDeductions + dblAmount
                End If
                Exit While
            End While
            objReader.Close()
        Next
        dblTotalPayable = dblTotalEarnings - dblTotalDeductions
        lblTotalEarnings.Text = Format(dblTotalEarnings, "#,##0.00")
        lblTotalDeductions.Text = Format(dblTotalDeductions, "#,##0.00")
        lblNet.Text = Format(dblTotalPayable, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Transaction Entry Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnEditTransaction_Click(sender As System.Object, e As System.EventArgs) Handles btnEditTransaction.Click
        If dGridTransactions.Rows.Count > 0 Then
            boolEditStatus = True
            boolEmployeeCall = False
            intSelectedTransactionId = CInt(dGridTransactions.CurrentRow.Cells(7).Value.ToString)
            Dim f As New frmTransactionEntry
            f.ShowDialog()
            LoadTransactionData(Format(CDate(dpStartDate.Value), "dd-MMM-yyyy"), Format(CDate(dpEndDate.Value), "dd-MMM-yyyy"), "ALL")
        End If
    End Sub

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        If IsNumeric(lblId.Text) Then
            If CDbl(lblId.Text) <> 0 Then
                LoadTransactionData(Format(CDate(dpStartDate.Value), "dd-MMM-yyyy"), Format(CDate(dpEndDate.Value), "dd-MMM-yyyy"), lblId.Text)
            Else
                LoadTransactionData(Format(CDate(dpStartDate.Value), "dd-MMM-yyyy"), Format(CDate(dpEndDate.Value), "dd-MMM-yyyy"), "ALL")
            End If
        Else
            LoadTransactionData(Format(CDate(dpStartDate.Value), "dd-MMM-yyyy"), Format(CDate(dpEndDate.Value), "dd-MMM-yyyy"), "ALL")
        End If
    End Sub

    Private Sub btnPrintCurrent_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintCurrent.Click
        PrintStatement("Current")
    End Sub

    Private Sub PrintStatement(ByVal Type As String)

        On Error GoTo RaiseErr

        If dGridTransactions.Rows.Count <= 0 Then Exit Sub

        If UCase(Type) = "CURRENT" Then
            boolAbort = False
            Cursor = Cursors.WaitCursor
            arrSelectedItems = New ArrayList
            arrSelectedItems.Add(dGridTransactions.CurrentRow.Cells(8).Value.ToString)
            'PrintStatementOfEarnings(Format(CDate(dpStartDate.Value), "dd-MMM-yyyy"), Format(CDate(dpEndDate.Value), "dd-MMM-yyyy"))
            PrintCustomerDocument(3, "INVOICE")
            If boolAbort = True Then
                Cursor = Cursors.Default
                Exit Sub
            End If
        Else
            arrSelectedItems = New ArrayList
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Distinct(DirectorId) FROM Payments " _
                & "WHERE TransDate BETWEEN '" & Format(CDate(dpStartDate.Value), "dd-MMM-yyyy") & "' AND " _
                & "'" & Format(CDate(dpEndDate.Value), "dd-MMM-yyyy") & "'", cnn)
            Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then arrSelectedItems.Add(objReader(0).ToString)
            End While
            objReader.Close()
            If arrSelectedItems.Count > 0 Then
                boolAbort = False
                Cursor = Cursors.WaitCursor
                'PrintStatementOfEarnings(Format(CDate(dpStartDate.Value), "dd-MMM-yyyy"), Format(CDate(dpEndDate.Value), "dd-MMM-yyyy"))
                For p As Integer = 0 To arrSelectedItems.Count - 1
                    PrintCustomerDocument(CInt(arrSelectedItems.Item(p)), "INVOICE", False)
                Next
                If boolAbort = True Then
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Statement of Earnings Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnProcess_Click(sender As System.Object, e As System.EventArgs) Handles btnProcess.Click
        Dim f As New frmProcessTransactions
        f.ShowDialog()
    End Sub

    Private Sub btnDeleteTransaction_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteTransaction.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If dGridTransactions.Rows.Count > 0 Then
            If MessageBox.Show("Are you sure that you want to delete this item?", "Confirm Delete", _
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim intTrans As Integer = CInt(dGridTransactions.CurrentRow.Cells(7).Value.ToString)
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM Payments WHERE TransId = " & intTrans & "", cnn)
                objCommand.ExecuteReader()
                LoadTransactionData(CDate(dpStartDate.Value), CDate(dpEndDate.Value), "ALL")
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Statement of Earnings Print"
        ShowErrorMessage()
    End Sub

    Private Sub LoadEmployees()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim arrItems As New ArrayList

        Dim intWidth As Integer = cboPersonnel.Width
        strSql = "SELECT LastName +' '+FirstName +' '+ OtherNames +';'+ CONVERT(NVARCHAR, TransactionId) AS " _
            & "[Personnel] FROM EmployeeMaster ORDER BY LastName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        arrItems.Add("ALL;0")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                arrItems.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        'Set up the drop down combo box
        With cboPersonnel
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth & ";0"
        End With

        Dim DropDownItems(arrItems.Count - 1) As MTGCComboBoxItem

        cboPersonnel.Items.Clear()

        For i As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(i).ToString, ";")
            DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        If arrItems.Count > 0 Then
            cboPersonnel.SelectedIndex = -1
            cboPersonnel.Items.Clear()
            cboPersonnel.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboPersonnel.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Personnel Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboPersonnel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPersonnel.SelectedIndexChanged
        lblId.Text = ""
        lblId.Text = cboPersonnel.SelectedItem.Col2
    End Sub

    Private Sub btnRecurringTransactions_Click(sender As System.Object, e As System.EventArgs) Handles btnRecurringTransactions.Click
        Dim f As New frmRecurringDeductions
        f.ShowDialog()
    End Sub

    Private Sub btnPrintAll_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintAll.Click
        PrintStatement("All")
    End Sub

    '********************************************************************************************************
    '                       PROCESSED EMPLOYEES DATA LISTINGS AND REPORTS                                   *
    '********************************************************************************************************

    Private Sub LoadProcessedData()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(NVARCHAR(11), RunFile.PaymentDate, 106), ' ', '-')) AS Date, " _
            & "EmployeeMaster.LastName + ' ' + EmployeeMaster.FirstName + ' ' + EmployeeMaster.OtherNames AS Director, " _
            & "RunFile.DirectorId FROM RunFile LEFT OUTER JOIN EmployeeMaster ON RunFile.DirectorId = EmployeeMaster.TransactionId " _
            & "GROUP BY RunFile.PaymentDate, EmployeeMaster.LastName, EmployeeMaster.FirstName, " _
            & "EmployeeMaster.OtherNames, RunFile.DirectorId"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridProcessed.Rows.Clear()
        While objReader.Read
            Dim dblGross As Double = 0
            Dim dblDeductions As Double = 0
            Dim dblNetPay As Double = 0

            'Get the gross pay
            objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(GrossUp),  SUM(PAYE), " _
                & "SUM(AidsLevy), SUM(Deductions) FROM RunFile " _
                & "WHERE DirectorId = " & objReader(2).ToString & "", cnn)
            Dim objReadCodeValue As OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReadCodeValue.Read
                If IsNumeric(objReadCodeValue(0).ToString) Then dblGross = CDbl(objReadCodeValue(0).ToString)
                If IsNumeric(objReadCodeValue(1).ToString) Then dblDeductions = dblDeductions + CDbl(objReadCodeValue(1).ToString)
                If IsNumeric(objReadCodeValue(2).ToString) Then dblDeductions = dblDeductions + CDbl(objReadCodeValue(2).ToString)
                If IsNumeric(objReadCodeValue(3).ToString) Then dblDeductions = dblDeductions + CDbl(objReadCodeValue(3).ToString)
                'If IsNumeric(objReadCodeValue(4).ToString) Then dblDeductions = dblDeductions + CDbl(objReadCodeValue(4).ToString)
                Exit While
            End While
            objReadCodeValue.Close()
            dblNetPay = dblGross - dblDeductions

            dGridProcessed.Rows.Add(objReader(0), objReader(1), dblGross, dblDeductions, dblNetPay, objReader(2))

        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Transaction Entry Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnBankExtract_Click(sender As System.Object, e As System.EventArgs) Handles btnBankExtract.Click
        Dim f As New frmBankExtracts
        f.ShowDialog()
    End Sub

    Private Sub btnPrintCurrentEmployee_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintCurrentEmployee.Click
        On Error GoTo RaiseErr

        boolPrintSelection = True

        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(NVARCHAR(11), RunFile.PaymentDate, 106), ' ', '-')) AS Date FROM RunFile GROUP BY PaymentDate"
        Dim objComDate As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReadDate As OleDb.OleDbDataReader = objComDate.ExecuteReader
        While objReadDate.Read
            If Not IsDBNull(objReadDate(0).ToString) Then strStatementDate = objReadDate(0).ToString
            Exit While
        End While
        objReadDate.Close()

        boolAbort = False
        Cursor = Cursors.WaitCursor
        intSelectedTransaction = CInt(dGridProcessed.CurrentRow.Cells(5).Value.ToString)
        PrintCustomerDocument(intSelectedTransaction, "INVOICE", True)
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If
        'End If
        'End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Current Statement of Earnings Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintAllEmployees_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintAllEmployees.Click
        On Error GoTo RaiseErr

        boolPrintSelection = False

        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(NVARCHAR(11), RunFile.PaymentDate, 106), ' ', '-')) AS Date FROM RunFile GROUP BY PaymentDate"
        Dim objComDate As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReadDate As OleDb.OleDbDataReader = objComDate.ExecuteReader
        While objReadDate.Read
            If Not IsDBNull(objReadDate(0).ToString) Then strStatementDate = objReadDate(0).ToString
            Exit While
        End While
        objReadDate.Close()

        If dGridProcessed.Rows.Count > 0 Then
            boolAbort = False
            Cursor = Cursors.WaitCursor
            For i As Integer = 0 To dGridProcessed.Rows.Count - 1
                arrSelectedItems = New ArrayList
                arrSelectedItems.Add(dGridProcessed.Rows(i).Cells(5).Value.ToString)
                PrintCustomerDocument(dGridProcessed.Rows(i).Cells(5).Value.ToString, "INVOICE", False)
                If boolAbort = True Then
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            Next
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Current Statement of Earnings History Print"
        ShowErrorMessage()
    End Sub

    Private Sub PrintPaymentSummary()

        'boolAbort = False
        'Dim frmd As New frmDateSpecifier
        'frmd.ShowDialog()
        'If boolAbort = True Then Exit Sub

        On Error GoTo RaiseErr

        Dim intStartBranch As Integer = 0
        Dim intEndBranch As Integer = 99999999
        Dim intStartDepartment As Integer = 0
        Dim intEndDepartment As Integer = 99999999

        Dim arrPrintData As New ArrayList
        Dim arrExcelData As New ArrayList

        'Initialize headers 
        arrExcelData.Add("Date;Description;Earnings;Deductions;PAYE;Aid Levy;Net Pay;Note;Run Total")

        'Get a count of the ledger accounts
        Dim intCount As Integer = 0
        Dim objGetCount As New Data.OleDb.OleDbCommand("SELECT Distinct(DirectorId) FROM RunFile", cnn)
        Dim objReadCount As OleDb.OleDbDataReader = objGetCount.ExecuteReader
        While objReadCount.Read
            intCount = intCount + 1
        End While
        objReadCount.Close()


        'Get the last date to determine the run date

        Dim objGetLastDate As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, OriginalTransDate, 105) AS Date FROM RunFile ORDER BY OriginalTransDate DESC", cnn)
        Dim objReadLastDate As OleDb.OleDbDataReader = objGetLastDate.ExecuteReader

        Dim strEndindDate As String = Nothing
        While objReadLastDate.Read
            If IsDate(objReadLastDate(0).ToString) Then
                strEndindDate = Format(CDate(objReadLastDate(0).ToString), "dd-MMM-yyyy")
                Exit While
            End If
        End While
        objReadLastDate.Close()

        If Not String.IsNullOrEmpty(strEndindDate) Then
            Dim strDateBuffer() As String = Split(strEndindDate, "-")
            strEndindDate = strDateBuffer(1) & " " & strDateBuffer(2)
        End If

        With ProgressBarItem1
            .Maximum = intCount
            .Value = 0
            .Visible = True
        End With

        'loop through the EMPLOYEE DATA
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT(RunFile.DirectorId) AS [DirectorId], EmployeeMaster.LastName +' '+ " _
            & "EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames AS [Given Names] FROM RunFile " _
            & "LEFT OUTER JOIN EmployeeMaster ON RunFile.DirectorId = EmployeeMaster.TransactionId " _
            & "ORDER BY DirectorId", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim arrSourceData As New ArrayList

        Dim dblDebitTotals As Double = 0
        Dim dblCreditTotals As Double = 0
        Dim dblPayeTotals As Double = 0
        Dim dblAidsLevyTotals As Double = 0
        Dim dblMovingBalance As Double = 0
        Dim dblBalanceBefore As Double = 0
        Dim strBalanceBefore As String = ""
        Dim strColumn(0 To 8) As String

        Dim dblBalanceCredit As Double = 0
        Dim dblBalanceDebit As Double = 0
        Dim dblBaseTotal As Double = 0

        Dim strNetMovement As String = ""
        Dim dblNetMovement As Double = 0

        While objReader.Read

            arrSourceData = New ArrayList
            arrSourceData = PayrollSummaryPrint(objReader(0).ToString)

            dblDebitTotals = 0
            dblCreditTotals = 0
            dblPayeTotals = 0
            dblAidsLevyTotals = 0
            dblMovingBalance = 0
            dblBalanceBefore = 0
            strBalanceBefore = ""

            For xp As Integer = 0 To strColumn.Length - 1
                strColumn(xp) = Nothing
            Next

            For i As Integer = 0 To arrSourceData.Count - 1

                Dim strSplit() As String = Split(arrSourceData.Item(i), "|")
                Dim strDate As String = strSplit(0)
                Dim strDescription As String = strSplit(1)
                Dim dblEarning As Double = CDbl(strSplit(2))
                Dim dblDeduction As Double = CDbl(strSplit(3))
                Dim dblPaye As Double = CDbl(strSplit(4))
                Dim dblAidsLevy As Double = CDbl(strSplit(5))
                Dim dblNetAmount As Double = CDbl(strSplit(6))

                'dblDebitTotals = dblDebitTotals + dblDebit
                'dblCreditTotals = dblCreditTotals + dblCredit

                Dim strDebit As String = ""
                Dim strCredit As String = ""
                Dim strPaye As String = ""
                Dim strAidsLevy As String = ""
                Dim strNetPay As String = ""
                Dim strMovingBalance As String = ""

                If i = 0 Then
                    dblMovingBalance = 0
                    dblBalanceBefore = dblMovingBalance
                    If dblMovingBalance <> 0 Then strMovingBalance = Format(dblMovingBalance, "#,##0.00")
                    strColumn(0) = objReader(0).ToString & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(1) = objReader(1).ToString & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(8) = strMovingBalance & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                    arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & _
                        strColumn(6) & strColumn(7) & strColumn(8))

                    arrExcelData.Add(objReader(0).ToString & ";" & objReader(1).ToString & "; ; ; ; ; ; ; " & strMovingBalance)

                    strColumn(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strColumn(8) = strMovingBalance & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                    arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & _
                            strColumn(6) & strColumn(7) & strColumn(8))

                    arrExcelData.Add(" ; ; ; ; ; ; ; ; " & strMovingBalance)

                Else
                    dblMovingBalance = dblNetAmount + dblMovingBalance
                    If dblMovingBalance <> 0 Then strMovingBalance = Format(dblMovingBalance, "#,##0.00")

                    If dblEarning <> 0 Then strDebit = Format(dblEarning, "#,##0.00")
                    If dblDeduction <> 0 Then strCredit = Format(dblDeduction, "#,##0.00")
                    If dblPaye <> 0 Then strPaye = Format(dblPaye, "#,##0.00")
                    If dblAidsLevy <> 0 Then strAidsLevy = Format(dblAidsLevy, "#,##0.00")
                    If dblNetAmount <> 0 Then strNetPay = Format(dblNetAmount, "#,##0.00")

                    strColumn(0) = strDate & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                    strColumn(1) = StrConv(strDescription, VbStrConv.ProperCase) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                    strColumn(2) = strDebit & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                    strColumn(3) = strCredit & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                    strColumn(4) = strPaye & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                    strColumn(5) = strAidsLevy & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                    strColumn(6) = strNetPay & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                    strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                    strColumn(8) = strMovingBalance & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"

                    dblDebitTotals = dblDebitTotals + dblEarning
                    dblCreditTotals = dblCreditTotals + dblDeduction
                    dblPayeTotals = dblPayeTotals + dblPaye
                    dblAidsLevyTotals = dblAidsLevyTotals + dblAidsLevy

                    arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & _
                        strColumn(6) & strColumn(7) & strColumn(8))

                    arrExcelData.Add(strDate & ";" & StrConv(strDescription, VbStrConv.ProperCase) & ";" & _
                        strDebit & ";" & strCredit & ";" & strPaye & ";" & strAidsLevy & ";" & strNetPay & "; ; " & strMovingBalance)

                End If

            Next

            'Compute the ledger account balance

            dblBalanceCredit = 0
            dblBalanceDebit = 0
            dblBaseTotal = 0

            If dblDebitTotals > dblCreditTotals Then
                dblBalanceCredit = dblDebitTotals - dblCreditTotals
                dblBaseTotal = dblDebitTotals
            Else
                dblBalanceDebit = dblCreditTotals - dblDebitTotals
                dblBaseTotal = dblCreditTotals
            End If

            'Add the balance line and the totals line
            strNetMovement = ""
            dblNetMovement = dblMovingBalance - dblBalanceBefore
            If dblNetMovement <> 0 Then strNetMovement = Format(dblNetMovement, "#,##0.00")

            strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(1) = "Totals|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(2) = Format(dblDebitTotals, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(3) = Format(dblCreditTotals, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(4) = Format(dblPayeTotals, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(5) = Format(dblAidsLevyTotals, "#,##0.00") & " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(6) = "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(7) = "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(8) = "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
            'Format(dblBaseTotal, "#,##0.00") &

            arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & _
                                 strColumn(6) & strColumn(7) & strColumn(8))

            arrExcelData.Add(" ;Totals;" & Format(dblDebitTotals, "#,##0.00") & ";" & _
                Format(dblCreditTotals, "#,##0.00") & ";" & Format(dblPayeTotals, "#,##0.00") & ";" & _
                Format(dblAidsLevyTotals, "#,##0.00") & "; ; ; ;")

            'Add the net movement line
            strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(1) = "Net Pay Movement|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(2) = "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(8) = strNetMovement & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"

            arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & _
                                 strColumn(6) & strColumn(7) & strColumn(8))
            arrExcelData.Add(" ;Net Pay Movement; ; ; ; ; ; ; " & strNetMovement)

            'At end draw a line
            strColumn(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(8) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
            arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & _
                    strColumn(6) & strColumn(7) & strColumn(8))

            arrExcelData.Add(" ; ; ; ; ; ; ; ; ")

            ProgressBarItem1.Value = ProgressBarItem1.Value + 1

        End While

        objReader.Close()

        '********************************************************************************************************************************************
        'Print the final totals here
        arrSourceData = New ArrayList
        arrSourceData = PayrollSummaryPrintTotals()

        dblDebitTotals = 0
        dblCreditTotals = 0
        dblPayeTotals = 0
        dblAidsLevyTotals = 0
        dblMovingBalance = 0
        dblBalanceBefore = 0
        strBalanceBefore = ""

        For xp As Integer = 0 To strColumn.Length - 1
            strColumn(xp) = Nothing
        Next

        For i As Integer = 0 To arrSourceData.Count - 1

            Dim strSplit() As String = Split(arrSourceData.Item(i), "|")
            Dim strDate As String = strSplit(0)
            Dim strDescription As String = strSplit(1)
            Dim dblEarning As Double = CDbl(strSplit(2))
            Dim dblDeduction As Double = CDbl(strSplit(3))
            Dim dblPaye As Double = CDbl(strSplit(4))
            Dim dblAidsLevy As Double = CDbl(strSplit(5))
            Dim dblNetAmount As Double = CDbl(strSplit(6))

            'dblDebitTotals = dblDebitTotals + dblDebit
            'dblCreditTotals = dblCreditTotals + dblCredit

            Dim strDebit As String = ""
            Dim strCredit As String = ""
            Dim strPaye As String = ""
            Dim strAidsLevy As String = ""
            Dim strNetPay As String = ""
            Dim strMovingBalance As String = ""

            If i = 0 Then
                dblMovingBalance = 0
                dblBalanceBefore = dblMovingBalance
                If dblMovingBalance <> 0 Then strMovingBalance = Format(dblMovingBalance, "#,##0.00")
                strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(1) = "FINAL SUMMARY TOTALS|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(8) = strMovingBalance & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & _
                    strColumn(6) & strColumn(7) & strColumn(8))
                arrExcelData.Add(" ;FINAL SUMMARY; ; ; ; ; ; ; ")

                strColumn(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                strColumn(8) = strMovingBalance & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
                arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & _
                        strColumn(6) & strColumn(7) & strColumn(8))
                arrExcelData.Add(" ; ; ; ; ; ; ; ; " & strMovingBalance)

            Else
                dblMovingBalance = dblNetAmount + dblMovingBalance
                If dblMovingBalance <> 0 Then strMovingBalance = Format(dblMovingBalance, "#,##0.00")

                If dblEarning <> 0 Then strDebit = Format(dblEarning, "#,##0.00")
                If dblDeduction <> 0 Then strCredit = Format(dblDeduction, "#,##0.00")
                If dblPaye <> 0 Then strPaye = Format(dblPaye, "#,##0.00")
                If dblAidsLevy <> 0 Then strAidsLevy = Format(dblAidsLevy, "#,##0.00")
                If dblNetAmount <> 0 Then strNetPay = Format(dblNetAmount, "#,##0.00")

                strColumn(0) = UCase(strDate) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(1) = StrConv(strDescription, VbStrConv.ProperCase) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strColumn(2) = strDebit & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                strColumn(3) = strCredit & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                strColumn(4) = strPaye & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                strColumn(5) = strAidsLevy & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                strColumn(6) = strNetPay & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                strColumn(8) = strMovingBalance & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"

                dblDebitTotals = dblDebitTotals + dblEarning
                dblCreditTotals = dblCreditTotals + dblDeduction
                dblPayeTotals = dblPayeTotals + dblPaye
                dblAidsLevyTotals = dblAidsLevyTotals + dblAidsLevy

                arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & _
                    strColumn(6) & strColumn(7) & strColumn(8))
                arrExcelData.Add(UCase(strDate) & ";" & StrConv(strDescription, VbStrConv.ProperCase) & ";" & strDebit & ";" & _
                    strCredit & ";" & strPaye & ";" & strAidsLevy & ";" & strNetPay & "; ;" & strMovingBalance)

            End If

        Next

        'Compute the ledger account balance

        dblBalanceCredit = 0
        dblBalanceDebit = 0
        dblBaseTotal = 0

        If dblDebitTotals > dblCreditTotals Then
            dblBalanceCredit = dblDebitTotals - dblCreditTotals
            dblBaseTotal = dblDebitTotals
        Else
            dblBalanceDebit = dblCreditTotals - dblDebitTotals
            dblBaseTotal = dblCreditTotals
        End If

        'Add the balance line and the totals line
        strNetMovement = ""
        dblNetMovement = dblMovingBalance - dblBalanceBefore
        If dblNetMovement <> 0 Then strNetMovement = Format(dblNetMovement, "#,##0.00")

        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(1) = "Totals|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(2) = Format(dblDebitTotals, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(3) = Format(dblCreditTotals, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(4) = Format(dblPayeTotals, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(5) = Format(dblAidsLevyTotals, "#,##0.00") & " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(6) = "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(7) = "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(8) = "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
        'Format(dblBaseTotal, "#,##0.00") &

        arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & _
                             strColumn(6) & strColumn(7) & strColumn(8))
        arrExcelData.Add(" ;Totals;" & Format(dblDebitTotals, "#,##0.00") & ";" & _
            Format(dblCreditTotals, "#,##0.00") & ";" & Format(dblPayeTotals, "#,##0.00") & ";" & _
            Format(dblAidsLevyTotals, "#,##0.00") & "; ; ; ")

        'Add the net movement line
        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(1) = "Net Pay Movement|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(2) = "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(8) = strNetMovement & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"

        arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & _
                             strColumn(6) & strColumn(7) & strColumn(8))
        arrExcelData.Add(" ;Net Pay Movement; ; ; ; ; ; ;" & strNetMovement)

        'At end draw a line
        strColumn(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(7) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(8) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
        arrPrintData.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & _
                strColumn(6) & strColumn(7) & strColumn(8))
        arrExcelData.Add(" ; ; ; ; ; ; ; ; ")

        '********************************************************************************************************************************************

        On Error GoTo RaiseErr

        boolAbort = False
        Dim fm As New frmPrintOutputOptions
        fm.ShowDialog()
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        If boolOutputToExcel = True Then
            WriteToExcel(arrExcelData)
        End If

        If boolToExcelOnly = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        If arrPrintData.Count = 0 Then
            MessageBox.Show("No details to print were obtained from the system", "Printing Aborted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 9
            .strColumnHeaders = "DATE/ID|DESCRIPTION|EARNINGS|DEDUCTIONS|PAYE|AIDS LEVY|NET PAY| |RUN TOTAL"
            .strColumnWidths = "60|150|80|65|65|60|60|20|60"
            .strFooterCaption = "Payments Summary : " & UCase(strUserName)
            .strMainCaption = "PAYMENTS SUMMARY - " & UCase(strCompanyName)
            .strMainHeader2 = "PAYMENTS SUMMARY"
            .strMainHeader2 = "PERIOD TO END OF " & UCase(strEndindDate)
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
            .VerticalLines = False
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("Black")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .DetailColor = Color.Black
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
            .DetailFont = New Font("Ariel", 6, FontStyle.Bold)
        End With
        Cursor = Cursors.Default

        Dim frm As New frmPrinterSetup
        frm.ShowDialog()
        rpt.PrinterSettings.PrinterName = strSessionPrinter
        Dim ppd As New PrintPreviewDialog
        ppd.Document = rpt
        ppd.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Payment Statements Print"
        ShowErrorMessage()
    End Sub

    Private Sub brnPayrollSummary_Click(sender As System.Object, e As System.EventArgs) Handles brnPayrollSummary.Click
        PrintPaymentSummary()
    End Sub

    Private Sub btnTaxReturns_Click(sender As System.Object, e As System.EventArgs) Handles btnTaxReturns.Click
        On Error GoTo RaiseErr

        boolAbort = False
        Dim f As New frmDateSpecifier
        f.ShowDialog()
        If boolAbort = True Then Exit Sub

        Cursor = Cursors.WaitCursor

        Dim arrPrintData As New ArrayList

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT RunFile.DirectorId, EmployeeMaster.LastName + ' ' + " _
            & "EmployeeMaster.FirstName + ' ' + EmployeeMaster.OtherNames AS GivenNames,  " _
            & "SUM(RunFile.GrossUp) AS [Gross Pay], SUM(RunFile.PAYE)  AS PAYE, " _
            & "SUM(RunFile.AidsLevy) AS [Aids Levy] FROM  RunFile LEFT OUTER JOIN EmployeeMaster " _
            & "ON RunFile.DirectorId = EmployeeMaster.TransactionId GROUP BY RunFile.DirectorId, " _
            & "EmployeeMaster.LastName, EmployeeMaster.FirstName, EmployeeMaster.OtherNames " _
            & "ORDER BY GivenNames", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim dblPaye As Double = 0
            Dim dblAidsLevy As Double = 0
            Dim dblGross As Double = 0
            If IsNumeric(objReader(2).ToString) Then dblGross = CDbl(objReader(2).ToString)
            If IsNumeric(objReader(3).ToString) Then dblPaye = CDbl(objReader(3).ToString)
            If IsNumeric(objReader(4).ToString) Then dblAidsLevy = CDbl(objReader(4).ToString)
            arrPrintData.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" & Format(dblGross, "##0.00") & ";" & Format(dblPaye, "##0.00") & ";" & Format(dblAidsLevy, "##0.00") & ";" & Format((dblPaye + dblAidsLevy), "##0.00"))
        End While
        objReader.Close()

        Dim strPrintDetails(0 To arrPrintData.Count - 1) As String
        For i As Integer = 0 To arrPrintData.Count - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        boolAbort = False
        Dim frm As New frmPrintOutputOptions
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        If boolOutputToExcel = True Then
            Dim arrOut As New ArrayList
            arrOut.Add("DIR.ID;GIVEN NAMES;GROSS PAY;PAYE;AIDS LEVY;TOTAL")
            For j As Integer = 0 To arrPrintData.Count - 1
                arrOut.Add(arrPrintData.Item(j))
            Next
            WriteToExcel(arrOut)
        End If

        If boolToExcelOnly = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "DIR.ID|GIVEN NAMES|GROSS PAY|PAYE|AIDS LEVY|TOTAL"
            .strColumnAlignments = "0|0|2|2|2|2"
            .strColumnWidths = "80|220|80|80|80|80"
            .strFooterCaption = "Period Tax Returns printed by " & strUserName
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "TAX RETURN "
            .strMainHeader3 = "PERIOD : " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " - " & UCase(Format(EndDate, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|YES|YES|YES|YES"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .intBreakIndex = 0
            .AlternateBackColor = Color.WhiteSmoke
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|YES|YES|YES|YES"
            .strSummaryTotals = "NO|NO|YES|YES|YES|YES"
            .strPrintValues = strPrintDetails
        End With

        boolAbort = False
        Dim frm1 As New frmPrinterSetup
        frm1.ShowDialog()
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        rpt.PrinterSettings.PrinterName = strSessionPrinter
        Dim ppd As New PrintPreviewDialog
        ppd.Document = rpt
        ppd.ShowDialog()

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Tax Returns Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnCummulativeReport_Click(sender As System.Object, e As System.EventArgs) Handles btnCummulativeReport.Click
        PrintCummulativeTaxReport()
    End Sub

    Private Sub PrintCummulativeTaxReport()
        On Error GoTo RaiseErr

        boolAbort = False
        Dim f As New frmCummulativeTaxPrintParameters 'frmDateSpecifier
        f.ShowDialog()
        If boolAbort = True Then Exit Sub

        Cursor = Cursors.WaitCursor
        Dim arrPrintData As New ArrayList


        For n As Integer = 0 To arrSelectedItems.Count - 1

            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Payments.DirectorId, EmployeeMaster.LastName + ' ' + " _
                & "EmployeeMaster.FirstName + ' ' + EmployeeMaster.OtherNames AS GivenNames FROM Payments " _
                & "LEFT OUTER JOIN EmployeeMaster ON Payments.DirectorId = EmployeeMaster.TransactionId " _
                & "WHERE Payments.DirectorId = " & arrSelectedItems.Item(n) & " " _
                & "GROUP BY Payments.DirectorId, " _
                & "EmployeeMaster.LastName, EmployeeMaster.FirstName, EmployeeMaster.OtherNames " _
                & "ORDER BY GivenNames", cnn)
            Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader

            While objReader.Read
                arrPrintData.Add(UCase(objReader(1).ToString) & "; ; ; ; ; ")
                'arrPrintData.Add(" ; ; ; ; ; ")
                Dim strCodes As String = "SELECT DISTINCT(Payments.PayCode) FROM Payments WHERE Payments.DirectorId = " & objReader(0).ToString & ""
                objCommand = New Data.OleDb.OleDbCommand(strCodes, cnn)
                Dim objReadCodes As OleDb.OleDbDataReader = objCommand.ExecuteReader

                Dim dblMovEarnings As Double = 0
                Dim dblMovDeductions As Double = 0

                While objReadCodes.Read

                    Dim strCodeDescription As String = Nothing
                    Dim strCodeType As String = Nothing
                    Dim strSql As String = "SELECT PaymentCodes.Description, PayType FROM PaymentCodes WHERE CodeNo = " & objReadCodes(0).ToString & ""
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    Dim objReadDescription As OleDb.OleDbDataReader = objCommand.ExecuteReader
                    While objReadDescription.Read
                        If Not IsDBNull(objReadDescription(0).ToString) Then strCodeDescription = objReadDescription(0).ToString
                        If Not IsDBNull(objReadDescription(1).ToString) Then strCodeType = objReadDescription(1).ToString
                        Exit While
                    End While
                    objReadDescription.Close()

                    'Get the sum of such codes
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(PaymentsHistory.GrossUp) FROM " _
                        & "PaymentsHistory WHERE " _
                        & "CodeId = " & objReadCodes(0).ToString & " AND DirectorId = " & objReader(0).ToString & " AND " _
                        & "PaymentDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
                    Dim objReadSum As OleDb.OleDbDataReader = objCommand.ExecuteReader

                    Dim dblSumTotal As Double = 0
                    Dim dblSumCurrent As Double = 0

                    While objReadSum.Read
                        If IsNumeric(objReadSum(0).ToString) Then dblSumTotal = CDbl(objReadSum(0).ToString)

                        'Read as well from the current run file
                        objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(RunFile.GrossUp) FROM " _
                        & "RunFile WHERE " _
                        & "CodeId = " & objReadCodes(0).ToString & " AND DirectorId = " & objReader(0).ToString & " AND " _
                        & "PaymentDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
                        Dim objReadCurrent As OleDb.OleDbDataReader = objCommand.ExecuteReader

                        While objReadCurrent.Read
                            If IsNumeric(objReadCurrent(0).ToString) Then dblSumCurrent = CDbl(objReadCurrent(0).ToString)
                        End While
                        objReadCurrent.Close()

                        If UCase(strCodeType) = "EARNING" Then
                            arrPrintData.Add(UCase(strCodeDescription) & ";" & (dblSumTotal + dblSumCurrent) & "; ; ; ; ")
                            dblMovEarnings = dblMovEarnings + dblSumTotal + dblSumCurrent
                        Else
                            If UCase(strCodeType) = "DEDUCTION" Then
                                arrPrintData.Add(UCase(strCodeDescription) & "; ;" & (dblSumTotal + dblSumCurrent) & " ; ; ; ")
                                dblMovDeductions = dblMovDeductions + dblSumTotal + dblSumCurrent
                            End If
                        End If
                    End While
                    objReadSum.Close()

                End While

                'Get the sum of the aids levy and paye
                objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(PaymentsHistory.Paye) FROM " _
                        & "PaymentsHistory WHERE DirectorId = " & objReader(0).ToString & " AND " _
                        & "PaymentDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
                Dim objReadPaye As OleDb.OleDbDataReader = objCommand.ExecuteReader
                Dim dblTotalPaye As Double = 0
                While objReadPaye.Read
                    If IsNumeric(objReadPaye(0).ToString) Then dblTotalPaye = CDbl(objReadPaye(0).ToString)
                    dblMovDeductions = dblMovDeductions + dblTotalPaye
                    'arrPrintData.Add("PAYE" & "; ; ;" & dblTotalPaye & " ; ; ")
                End While
                objReadPaye.Close()

                'Get the sum of the aids levy and paye
                objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(RunFile.Paye) FROM " _
                        & "RunFile WHERE DirectorId = " & objReader(0).ToString & " AND " _
                        & "PaymentDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
                Dim objReadCurrentPaye As OleDb.OleDbDataReader = objCommand.ExecuteReader
                Dim dblTotalCurrentPaye As Double = 0
                While objReadCurrentPaye.Read
                    If IsNumeric(objReadCurrentPaye(0).ToString) Then dblTotalCurrentPaye = CDbl(objReadCurrentPaye(0).ToString)
                    dblMovDeductions = dblMovDeductions + dblTotalPaye
                End While
                objReadCurrentPaye.Close()
                dblTotalPaye = dblTotalPaye + dblTotalCurrentPaye

                'Get the sum of the aids levy and paye
                objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(PaymentsHistory.AidsLevy) FROM " _
                        & "PaymentsHistory WHERE DirectorId = " & objReader(0).ToString & " AND " _
                        & "PaymentDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
                Dim objReadAidsLevy As OleDb.OleDbDataReader = objCommand.ExecuteReader
                Dim dblTotalAidsLevy As Double = 0
                While objReadAidsLevy.Read
                    If IsNumeric(objReadAidsLevy(0).ToString) Then dblTotalAidsLevy = CDbl(objReadAidsLevy(0).ToString)
                    dblMovDeductions = dblMovDeductions + dblTotalAidsLevy
                End While
                objReadAidsLevy.Close()

                objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(PaymentsHistory.AidsLevy) FROM " _
                        & "PaymentsHistory WHERE DirectorId = " & objReader(0).ToString & " AND " _
                        & "PaymentDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
                Dim objReadCurrentAidsLevy As OleDb.OleDbDataReader = objCommand.ExecuteReader
                Dim dblTotalCurrentAidsLevy As Double = 0
                While objReadCurrentAidsLevy.Read
                    If IsNumeric(objReadCurrentAidsLevy(0).ToString) Then dblTotalCurrentAidsLevy = CDbl(objReadCurrentAidsLevy(0).ToString)
                    dblMovDeductions = dblMovDeductions + dblTotalCurrentAidsLevy
                End While
                objReadCurrentAidsLevy.Close()
                dblTotalAidsLevy = dblTotalAidsLevy + dblTotalCurrentAidsLevy

                arrPrintData.Add("TAXES" & "; ; ; " & dblTotalPaye & ";" & dblTotalAidsLevy & " ; ")

                'arrPrintData.Add(" ; ; ; ; ; ")
                arrPrintData.Add("TOTAL EARNINGS, DEDUCTIONS AND NET INCOME;" & dblMovEarnings & ";" & dblMovDeductions & "; ; ; " & dblMovEarnings - dblMovDeductions)
                arrPrintData.Add(" ; ; ; ; ; ")

                '0714768869 - Br. Chamhuna
            End While
            objReader.Close()

        Next


        'Send the details to the printing class
        arrExcelData = New ArrayList
        arrExcelData.Add("DETAILS;EARNINGS;DEDUCTIONS;PAYE;AIDS LEVY;NET")

        Dim strPrintDetails(0 To arrPrintData.Count - 1) As String
        For i As Integer = 0 To arrPrintData.Count - 1
            strPrintDetails(i) = arrPrintData.Item(i)
            arrExcelData.Add(arrPrintData.Item(i))
        Next

        boolAbort = False
        Dim fm As New frmPrintOutputOptions
        fm.ShowDialog()

        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        If boolOutputToExcel = True Then
            boolAbort = False
            WriteToExcel(arrExcelData)
            If boolAbort = True Then Exit Sub
            MessageBox.Show("Details written to Excel successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If boolToExcelOnly = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "DETAILS|EARNINGS|DEDUCTIONS|PAYE|AIDS LEVY|NET"
            .strColumnAlignments = "0|2|2|2|2|2"
            .strColumnWidths = "240|80|80|80|80|80"
            .strFooterCaption = "Cummulative Transaction Report Printed By " & strUserName
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "CUMMULATIVE TRANSACTION REPORT"
            .strMainHeader3 = "PERIOD : " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " - " & UCase(Format(EndDate, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .intBreakIndex = 0
            '.AlternateBackColor = Color.WhiteSmoke
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|YES|YES|YES|YES|YES"
            .strSummaryTotals = "NO|YES|YES|YES|YES|YES"
            .strPrintValues = strPrintDetails
        End With

        Dim frm As New frmPrinterSetup
        frm.ShowDialog()
        rpt.PrinterSettings.PrinterName = strSessionPrinter
        Dim ppd As New PrintPreviewDialog
        ppd.Document = rpt
        ppd.ShowDialog()

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Cummulative Tax Report Print"
        ShowErrorMessage()
    End Sub

    Private Sub WriteToExcel(DataToPrint As ArrayList)

        xlWorkBook = xlApp.Workbooks.Add '~~> Add a New Workbook
        xlApp.Visible = True '~~> Display Excel
        xlWorkSheet = xlWorkBook.Sheets("Sheet1") '~~> Set the relebant sheet that we want to work with

        With xlWorkSheet.Range("A1:Z" & DataToPrint.Count)
            With .Font
                .Size = 8
                .Name = "Tahoma"
                .Bold = False
            End With
        End With

        For p As Integer = 0 To DataToPrint.Count - 1

            Dim strBuffer() As String = Split(DataToPrint.Item(p), ";")

            With xlWorkSheet
                '~~> Directly type the values that we want
                Dim intRow As Integer = p + 1
                For q As Integer = 0 To strBuffer.Length - 1
                    Select Case (q + 1)
                        Case Is = 1
                            .Range("A" & intRow).Value = "'" & strBuffer(q)
                        Case Is = 2
                            .Range("B" & intRow).Value = strBuffer(q)
                        Case Is = 3
                            .Range("C" & intRow).Value = strBuffer(q)
                        Case Is = 4
                            .Range("D" & intRow).Value = strBuffer(q)
                        Case Is = 5
                            .Range("E" & intRow).Value = strBuffer(q)
                        Case Is = 6
                            .Range("F" & intRow).Value = strBuffer(q)
                        Case Is = 7
                            .Range("G" & intRow).Value = strBuffer(q)
                        Case Is = 8
                            .Range("H" & intRow).Value = strBuffer(q)
                        Case Is = 9
                            .Range("I" & intRow).Value = strBuffer(q)
                        Case Is = 10
                            .Range("J" & intRow).Value = strBuffer(q)
                        Case Is = 11
                            .Range("K" & intRow).Value = strBuffer(q)
                        Case Is = 12
                            .Range("L" & intRow).Value = strBuffer(q)
                        Case Is = 13
                            .Range("M" & intRow).Value = strBuffer(q)
                        Case Is = 14
                            .Range("N" & intRow).Value = strBuffer(q)
                        Case Is = 15
                            .Range("O" & intRow).Value = strBuffer(q)
                        Case Is = 16
                            .Range("P" & intRow).Value = strBuffer(q)
                        Case Is = 17
                            .Range("Q" & intRow).Value = strBuffer(q)
                        Case Is = 18
                            .Range("R" & intRow).Value = strBuffer(q)
                        Case Is = 19
                            .Range("S" & intRow).Value = strBuffer(q)
                        Case Is = 20
                            .Range("T" & intRow).Value = strBuffer(q)
                        Case Is = 21
                            .Range("U" & intRow).Value = strBuffer(q)
                        Case Is = 22
                            .Range("V" & intRow).Value = strBuffer(q)
                        Case Is = 23
                            .Range("W" & intRow).Value = strBuffer(q)
                        Case Is = 24
                            .Range("X" & intRow).Value = strBuffer(q)
                        Case Is = 25
                            .Range("Y" & intRow).Value = strBuffer(q)
                        Case Is = 26
                            .Range("Z" & intRow).Value = strBuffer(q)
                    End Select
                Next
            End With
        Next
        '~~> Autofitting text in columns
        xlWorkSheet.Columns("A:Z").EntireColumn.AutoFit()

    End Sub

    Private Sub btnSelectedEmployeeStatementHistory_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectedEmployeeStatementHistory.Click

        boolAbort = False
        Dim f As New frmDateSpecifier
        f.ShowDialog()
        If boolAbort = True Then Exit Sub

        On Error GoTo RaiseErr

        boolPrintSelection = True

        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(NVARCHAR(11), RunFile.PaymentDate, 106), ' ', '-')) AS Date FROM RunFile GROUP BY PaymentDate"
        Dim objComDate As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReadDate As OleDb.OleDbDataReader = objComDate.ExecuteReader
        While objReadDate.Read
            If Not IsDBNull(objReadDate(0).ToString) Then strStatementDate = objReadDate(0).ToString
            Exit While
        End While
        objReadDate.Close()

        boolAbort = False
        Cursor = Cursors.WaitCursor
        intSelectedTransaction = CInt(dGridProcessed.CurrentRow.Cells(5).Value.ToString)
        PrintCustomerDocument(intSelectedTransaction, "INVOICE", True, "HISTORICAL")
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If
        'End If
        'End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Historical Statement of Earnings Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnAllEmployeesStatementHistory_Click(sender As System.Object, e As System.EventArgs) Handles btnAllEmployeesStatementHistory.Click

        boolAbort = False
        Dim f As New frmDateSpecifier
        f.ShowDialog()
        If boolAbort = True Then Exit Sub

        On Error GoTo RaiseErr

        boolPrintSelection = False

        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(NVARCHAR(11), RunFile.PaymentDate, 106), ' ', '-')) AS Date FROM RunFile GROUP BY PaymentDate"
        Dim objComDate As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReadDate As OleDb.OleDbDataReader = objComDate.ExecuteReader
        While objReadDate.Read
            If Not IsDBNull(objReadDate(0).ToString) Then strStatementDate = objReadDate(0).ToString
            Exit While
        End While
        objReadDate.Close()

        If dGridProcessed.Rows.Count > 0 Then
            boolAbort = False
            Cursor = Cursors.WaitCursor
            For i As Integer = 0 To dGridProcessed.Rows.Count - 1
                arrSelectedItems = New ArrayList
                arrSelectedItems.Add(dGridProcessed.Rows(i).Cells(5).Value.ToString)
                PrintCustomerDocument(dGridProcessed.Rows(i).Cells(5).Value.ToString, "INVOICE", False, "HISTORICAL")
                If boolAbort = True Then
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            Next
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Historical Statement of Earnings Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnTaxCertificates_Click(sender As System.Object, e As System.EventArgs) Handles btnTaxCertificates.Click
        Dim frm As New frmEmployeeTaxCertificates
        frm.ShowDialog()
    End Sub

    Private Sub btnTaxCertificateSummary_Click(sender As System.Object, e As System.EventArgs) Handles btnTaxCertificateSummary.Click
        boolAbort = False
        Dim frm As New frmDateSpecifier
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        PrintConsolidatedTaxReport()
    End Sub

    Private Sub PrintConsolidatedTaxReport()
        On Error GoTo RaiseErr

        'Get the master file details first
        boolAbort = False
        EmployeeMasterData()
        If boolAbort = True Then Exit Sub

        arrPrintDetails = New ArrayList
        Dim arrEarningsBenefits As New ArrayList
        arrEarningsBenefits = EarningsAndBenefitsCodes()

        For p As Integer = 0 To arrMaster.Count - 1

            Dim strColumn(0 To 6) As String

            Dim EmployeeDetails() As String = Split(arrMaster.Item(p), ";")

            strColumn(0) = UCase(EmployeeDetails(1)) & " " & UCase(EmployeeDetails(2)) & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(1) = "ID NUMBER|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(2) = "DATE FROM|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(3) = "DATE TO|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0"
            arrPrintDetails.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & strColumn(6))

            'Print the 2nd row details
            strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(1) = UCase(EmployeeDetails(3)) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(2) = UCase(Format(StartDate, "dd-MMM-yyyy")) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(3) = UCase(Format(EndDate, "dd-MMM-yyyy")) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0"
            arrPrintDetails.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & strColumn(6))

            Dim intTrips As Integer = 0
            Dim dblCounterCheck As Double = arrEarningsBenefits.Count / 6
            Dim strCheck As String = CStr(Format(dblCounterCheck, "##0.00"))
            Dim strCheckValues() As String = Split(strCheck, ".")
            intTrips = CInt(strCheckValues(0))

            Dim intRemainder As Integer = arrEarningsBenefits.Count Mod 6

            Dim strLine1 As String = Nothing
            Dim strLine2 As String = Nothing

            Dim intIndex As Integer = 0
            For x As Integer = 0 To intTrips - 1
                strLine1 = Nothing : strLine2 = Nothing
                strColumn(0) = Nothing : strColumn(1) = Nothing : strColumn(2) = Nothing : strColumn(3) = Nothing
                strColumn(4) = Nothing : strColumn(5) = Nothing : strColumn(6) = Nothing

                strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"

                Dim strLine1Cols(0 To 5) As String
                Dim strLine2Cols(0 To 5) As String

                For a As Integer = 0 To 5
                    Dim strBuffer() As String = Split(arrEarningsBenefits.Item(intIndex), "|")
                    If Not IsNumeric(strBuffer(0)) Then strBuffer(0) = "0"
                    If String.IsNullOrEmpty(strBuffer(1)) Then strBuffer(0) = " "
                    Dim dblCodeValue As Double = TaxEmployeeCodeValue(CInt(strBuffer(0)), StartDate, EndDate, CInt(EmployeeDetails(0)))

                    If a = 5 Then
                        strLine1Cols(a) = strBuffer(1) & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0"
                        strLine2Cols(a) = Format(dblCodeValue, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                    Else
                        strLine1Cols(a) = strBuffer(1) & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                        strLine2Cols(a) = Format(dblCodeValue, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                    End If

                    intIndex = intIndex + 1
                Next

                arrPrintDetails.Add(strColumn(0) & strLine1Cols(0) & strLine1Cols(1) & strLine1Cols(2) & strLine1Cols(3) & strLine1Cols(4) & strLine1Cols(5))
                arrPrintDetails.Add(strColumn(0) & strLine2Cols(0) & strLine2Cols(1) & strLine2Cols(2) & strLine2Cols(3) & strLine2Cols(4) & strLine2Cols(5))

            Next

            If intRemainder > 0 Then

                strColumn(0) = Nothing : strColumn(1) = Nothing : strColumn(2) = Nothing : strColumn(3) = Nothing
                strColumn(4) = Nothing : strColumn(5) = Nothing : strColumn(6) = Nothing

                strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"

                Dim strLine1Cols(0 To 5) As String
                Dim strLine2Cols(0 To 5) As String

                For a As Integer = 0 To 5 'intRemainder - 1

                    If a <= intRemainder - 1 Then
                        Dim strBuffer() As String = Split(arrEarningsBenefits.Item(intIndex), "|")
                        If Not IsNumeric(strBuffer(0)) Then strBuffer(0) = "0"
                        If String.IsNullOrEmpty(strBuffer(1)) Then strBuffer(0) = " "
                        Dim dblCodeValue As Double = TaxEmployeeCodeValue(CInt(strBuffer(0)), StartDate, EndDate, CInt(EmployeeDetails(0)))

                        If a = 5 Then
                            strLine1Cols(a) = strBuffer(1) & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0"
                            strLine2Cols(a) = Format(dblCodeValue, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                        Else
                            strLine1Cols(a) = strBuffer(1) & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                            strLine2Cols(a) = Format(dblCodeValue, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                        End If

                        intIndex = intIndex + 1
                    Else
                        If a = 5 Then
                            strLine1Cols(a) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=True;FU=False;BC=WhiteSmoke;RH=20;AL=0"
                            strLine2Cols(a) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0"
                        Else
                            strLine1Cols(a) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=True;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                            strLine2Cols(a) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                        End If
                    End If
                Next

                arrPrintDetails.Add(strColumn(0) & strLine1Cols(0) & strLine1Cols(1) & strLine1Cols(2) & strLine1Cols(3) & strLine1Cols(4) & strLine1Cols(5))
                arrPrintDetails.Add(strColumn(0) & strLine2Cols(0) & strLine2Cols(1) & strLine2Cols(2) & strLine2Cols(3) & strLine2Cols(4) & strLine2Cols(5))

            End If

            'Write out the employee total earnings, paye and aids levy
            Dim dblTotalEarnings As Double = 0
            Dim arrEarnings As New ArrayList
            arrEarnings = EmployeeEarnings(CInt(EmployeeDetails(0)), StartDate, EndDate)
            For q As Integer = 0 To arrEarnings.Count - 1
                If IsNumeric(arrEarnings.Item(q)) Then
                    dblTotalEarnings = dblTotalEarnings + CDbl(arrEarnings.Item(q))
                End If
            Next

            'Aids levy
            Dim dblAidsLevy As Double = EmployeeAidsLevy(CInt(EmployeeDetails(0)), StartDate, EndDate)
            Dim dblPaye As Double = EmployeePaye(CInt(EmployeeDetails(0)), StartDate, EndDate)

            'Write out the details

            strColumn(0) = Nothing : strColumn(1) = Nothing : strColumn(2) = Nothing : strColumn(3) = Nothing
            strColumn(4) = Nothing : strColumn(5) = Nothing : strColumn(6) = Nothing

            'Leave blank line
            strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0"
            arrPrintDetails.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & strColumn(6))

            'Leave blank line
            strColumn(0) = "TOTALS|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(1) = "EARNINGS|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(2) = Format(dblTotalEarnings, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(3) = "PAYE|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(4) = Format(dblPaye, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
            strColumn(5) = "AIDS LEVY|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(6) = Format(dblAidsLevy, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
            arrPrintDetails.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & strColumn(6))

            'Leave blank line after
            strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0"
            arrPrintDetails.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & strColumn(6))

            'Draw line
            strColumn(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
            strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0"

        Next

        'Generate the final totals here
        boolAbort = False
        ConsolidatedTaxReportFinalTotals()
        If boolAbort = True Then Exit Sub

        Dim strPrintDetails(0 To (arrPrintDetails.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 7
            .strColumnHeaders = " | | | | | | "
            .strColumnWidths = "160|80|80|80|80|80|80"
            .strFooterCaption = UCase("CONSOLIDATED TAX REPORT " & UCase(Now))
            .strMainCaption = "CONSOLIDATED TAX REPORT"
            .strMainHeader2 = "PERIOD " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " TO " & UCase(Format(StartDate, "dd-MMM-yyyy"))
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
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
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With

        Dim documentPreview As New PrintPreviewDialog

        Dim f As New frmPrinterSetup
        f.ShowDialog()
        rpt.PrinterSettings.PrinterName = strSessionPrinter
        documentPreview.Document = rpt
        documentPreview.ShowDialog()


        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Consolidated Tax Certificates Print"
        ShowErrorMessage()
    End Sub

    Private Sub ConsolidatedTaxReportFinalTotals()
        On Error GoTo RaiseErr

        Dim arrEarningsBenefits As New ArrayList
        arrEarningsBenefits = EarningsAndBenefitsCodes()

        Dim strColumn(0 To 6) As String

        strColumn(0) = "FINAL TOTALS |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(1) = "PERIODS COVERED|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(2) = "FROM|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(3) = "TO|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0"
        arrPrintDetails.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & strColumn(6))

        'Print the 2nd row details
        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(2) = UCase(Format(StartDate, "dd-MMM-yyyy")) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(3) = UCase(Format(EndDate, "dd-MMM-yyyy")) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0"
        arrPrintDetails.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & strColumn(6))

        Dim intTrips As Integer = 0
        Dim dblCounterCheck As Double = arrEarningsBenefits.Count / 6
        Dim strCheck As String = CStr(Format(dblCounterCheck, "##0.00"))
        Dim strCheckValues() As String = Split(strCheck, ".")
        intTrips = CInt(strCheckValues(0))

        Dim intRemainder As Integer = arrEarningsBenefits.Count Mod 6

        Dim strLine1 As String = Nothing
        Dim strLine2 As String = Nothing

        Dim intIndex As Integer = 0
        For x As Integer = 0 To intTrips - 1
            strLine1 = Nothing : strLine2 = Nothing
            strColumn(0) = Nothing : strColumn(1) = Nothing : strColumn(2) = Nothing : strColumn(3) = Nothing
            strColumn(4) = Nothing : strColumn(5) = Nothing : strColumn(6) = Nothing

            strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"

            Dim strLine1Cols(0 To 5) As String
            Dim strLine2Cols(0 To 5) As String

            For a As Integer = 0 To 5
                Dim strBuffer() As String = Split(arrEarningsBenefits.Item(intIndex), "|")
                If Not IsNumeric(strBuffer(0)) Then strBuffer(0) = "0"
                If String.IsNullOrEmpty(strBuffer(1)) Then strBuffer(0) = " "
                Dim dblCodeValue As Double = TaxSummaryCodeValue(CInt(strBuffer(0)), StartDate, EndDate)

                If a = 5 Then
                    strLine1Cols(a) = strBuffer(1) & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0"
                    strLine2Cols(a) = Format(dblCodeValue, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                Else
                    strLine1Cols(a) = strBuffer(1) & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                    strLine2Cols(a) = Format(dblCodeValue, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                End If

                intIndex = intIndex + 1
            Next

            arrPrintDetails.Add(strColumn(0) & strLine1Cols(0) & strLine1Cols(1) & strLine1Cols(2) & strLine1Cols(3) & strLine1Cols(4) & strLine1Cols(5))
            arrPrintDetails.Add(strColumn(0) & strLine2Cols(0) & strLine2Cols(1) & strLine2Cols(2) & strLine2Cols(3) & strLine2Cols(4) & strLine2Cols(5))

        Next

        If intRemainder > 0 Then

            strColumn(0) = Nothing : strColumn(1) = Nothing : strColumn(2) = Nothing : strColumn(3) = Nothing
            strColumn(4) = Nothing : strColumn(5) = Nothing : strColumn(6) = Nothing

            strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"

            Dim strLine1Cols(0 To 5) As String
            Dim strLine2Cols(0 To 5) As String

            For a As Integer = 0 To 5 'intRemainder - 1

                If a <= intRemainder - 1 Then
                    Dim strBuffer() As String = Split(arrEarningsBenefits.Item(intIndex), "|")
                    If Not IsNumeric(strBuffer(0)) Then strBuffer(0) = "0"
                    If String.IsNullOrEmpty(strBuffer(1)) Then strBuffer(0) = " "
                    Dim dblCodeValue As Double = TaxSummaryCodeValue(CInt(strBuffer(0)), StartDate, EndDate)

                    If a = 5 Then
                        strLine1Cols(a) = strBuffer(1) & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0"
                        strLine2Cols(a) = Format(dblCodeValue, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2"
                    Else
                        strLine1Cols(a) = strBuffer(1) & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                        strLine2Cols(a) = Format(dblCodeValue, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=2</d>"
                    End If

                    intIndex = intIndex + 1
                Else
                    If a = 5 Then
                        strLine1Cols(a) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=True;FU=False;BC=WhiteSmoke;RH=20;AL=0"
                        strLine2Cols(a) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0"
                    Else
                        strLine1Cols(a) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=True;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
                        strLine2Cols(a) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                    End If
                End If
            Next

            arrPrintDetails.Add(strColumn(0) & strLine1Cols(0) & strLine1Cols(1) & strLine1Cols(2) & strLine1Cols(3) & strLine1Cols(4) & strLine1Cols(5))
            arrPrintDetails.Add(strColumn(0) & strLine2Cols(0) & strLine2Cols(1) & strLine2Cols(2) & strLine2Cols(3) & strLine2Cols(4) & strLine2Cols(5))

        End If

        'Write out the employee total earnings, paye and aids levy
        Dim dblTotalEarnings As Double = 0

        Dim objComSummary As Data.OleDb.OleDbCommand
        Dim objReadSummary As Data.OleDb.OleDbDataReader

        For g As Integer = 0 To arrEarningsBenefits.Count - 1

            Dim strBuffer() As String = Split(arrEarningsBenefits.Item(g), "|")
            If Not IsNumeric(strBuffer(0)) Then strBuffer(0) = "0"

            objComSummary = New Data.OleDb.OleDbCommand("SELECT SUM(PaymentsHistory.GrossUp) FROM PaymentsHistory " _
            & "WHERE CodeId = " & strBuffer(0) & " AND PaymentDate BETWEEN '" & Format(StartDate, "dd-MMM-yyyy") & "' AND " _
            & "'" & Format(EndDate, "dd-MMM-yyyy") & "'", cnn)
            objReadSummary = objComSummary.ExecuteReader
            While objReadSummary.Read
                If IsNumeric(objReadSummary(0).ToString) Then
                    dblTotalEarnings = dblTotalEarnings + CDbl(objReadSummary(0).ToString)
                End If
            End While
            objReadSummary.Close()

        Next

        'Aids levy
        Dim dblAidsLevy As Double = 0
        objComSummary = New Data.OleDb.OleDbCommand("SELECT SUM(PaymentsHistory.AidsLevy) FROM PaymentsHistory " _
        & "WHERE PaymentDate BETWEEN '" & Format(StartDate, "dd-MMM-yyyy") & "' AND " _
        & "'" & Format(EndDate, "dd-MMM-yyyy") & "'", cnn)
        objReadSummary = objComSummary.ExecuteReader
        While objReadSummary.Read
            If IsNumeric(objReadSummary(0).ToString) Then
                dblAidsLevy = dblAidsLevy + CDbl(objReadSummary(0).ToString)
            End If
        End While
        objReadSummary.Close()

        Dim dblPaye As Double = 0
        objComSummary = New Data.OleDb.OleDbCommand("SELECT SUM(PaymentsHistory.Paye) FROM PaymentsHistory " _
        & "WHERE PaymentDate BETWEEN '" & Format(StartDate, "dd-MMM-yyyy") & "' AND " _
        & "'" & Format(EndDate, "dd-MMM-yyyy") & "'", cnn)
        objReadSummary = objComSummary.ExecuteReader
        While objReadSummary.Read
            If IsNumeric(objReadSummary(0).ToString) Then
                dblPaye = dblPaye + CDbl(objReadSummary(0).ToString)
            End If
        End While
        objReadSummary.Close()

        'Write out the details

        strColumn(0) = Nothing : strColumn(1) = Nothing : strColumn(2) = Nothing : strColumn(3) = Nothing
        strColumn(4) = Nothing : strColumn(5) = Nothing : strColumn(6) = Nothing

        'Leave blank line
        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0"
        arrPrintDetails.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & strColumn(6))

        'Leave blank line
        strColumn(0) = "TOTALS|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(1) = "EARNINGS|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(2) = Format(dblTotalEarnings, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(3) = "PAYE|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(4) = Format(dblPaye, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2</d>"
        strColumn(5) = "AIDS LEVY|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(6) = Format(dblAidsLevy, "#,##0.00") & "|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=2"
        arrPrintDetails.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & strColumn(6))

        'Leave blank line after
        strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0"
        arrPrintDetails.Add(strColumn(0) & strColumn(1) & strColumn(2) & strColumn(3) & strColumn(4) & strColumn(5) & strColumn(6))

        'Draw line
        strColumn(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(1) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(2) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(3) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(4) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(5) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0</d>"
        strColumn(6) = " |FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=20;AL=0"

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Consolidated Tax Certificates Print"
        ShowErrorMessage()
    End Sub

    Private Sub EmployeeMasterData()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim strCountEmployees As String = Nothing

        strCountEmployees = "SELECT Count(EmployeeMaster.TransactionId) FROM EmployeeMaster"
        strSql = "select EmployeeMaster.TransactionId, EmployeeMaster.LastName, EmployeeMaster.FirstName, " _
            & "EmployeeMaster.IdNumber from EmployeeMaster ORDER BY EmployeeMaster.TransactionId"

        Dim cmdMaster As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As OleDb.OleDbDataReader = cmdMaster.ExecuteReader

        arrMaster = New ArrayList

        Dim strEcNum As String = Nothing

        While objReader.Read

            'validate and convert the dates to the required format
            Dim strStartDate As String = "00000000"
            Dim strEndDate As String = "00000000"
            Dim strBirthDate As String = "00000000"
            strStartDate = "00000000"

            strEndDate = "00000000"

            'Build the master records here
            Dim strEmployeeNumber As String = "00000000"
            Dim strEmployeeSurname As String = Space(24)
            Dim strEmployeeNames As String = Space(24)
            Dim strEmployeeIdNumber As String = "000000000X00"
            If Not IsDBNull(objReader("TransactionId").ToString) Then
                strEmployeeNumber = CStr(Format(CInt(objReader("TransactionId")), "00000000"))
            End If

            If Not IsDBNull(objReader("LastName").ToString) Then
                If objReader("LastName").ToString.Length > 24 Then
                    strEmployeeSurname = Mid(objReader("LastName").ToString, 1, 24)
                Else
                    strEmployeeSurname = objReader("LastName").ToString & Space(24 - objReader("LastName").ToString.Length)
                End If
            End If
            If Not IsDBNull(objReader("FirstName").ToString) Then
                If objReader("FirstName").ToString.Length > 24 Then
                    strEmployeeNames = Mid(objReader("FirstName").ToString, 1, 24)
                Else
                    strEmployeeNames = objReader("FirstName").ToString & Space(24 - objReader("FirstName").ToString.Length)
                End If
            End If

            strEmployeeIdNumber = "000000000000"
            If Not IsDBNull(objReader("IdNumber").ToString) Then
                strEmployeeIdNumber = objReader("IdNumber").ToString
            End If

            'TRIM OUT ALL SPACES IN THE ID NUMBER
            strEmployeeIdNumber = Replace(strEmployeeIdNumber, " ", "", 1)

            If strEmployeeIdNumber.Length > 12 Then
                strEmployeeIdNumber = Mid(strEmployeeIdNumber, 1, 12)
            Else
                strEmployeeIdNumber = strEmployeeIdNumber & Space(12 - strEmployeeIdNumber.Length)
            End If

            'Get the employee job position
            Dim strPosition As String = "Board Member"

            arrMaster.Add(strEmployeeNumber & ";" & strEmployeeSurname & ";" & _
                strEmployeeNames & ";" & strEmployeeIdNumber & _
                    ";" & strBirthDate & ";" & strStartDate & ";" & strEndDate & ";" & strPosition)

        End While

        objReader.Close()
        Dim intRecordCount As Integer = arrMaster.Count

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " Employee number " & strEcNum & vbCrLf & "Tax Certificate Print Failure"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadAllData()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

    End Sub

    Private Sub btnRefreshProcessed_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshProcessed.Click
        LoadProcessedData()
    End Sub

    Private Sub btnTaxGrossTracy_Click(sender As System.Object, e As System.EventArgs) Handles btnTaxGrossTracy.Click
        Dim frm As New frmTaxTracy
        frm.ShowDialog()
    End Sub

    Private Sub btnLineItems_Click(sender As System.Object, e As System.EventArgs) Handles btnLineItems.Click
        On Error GoTo RaiseErr

        boolAbort = False
        arrSelectedItems = New ArrayList
        Dim fm As New frmLineItemsPrintParameters
        fm.ShowDialog()
        If boolAbort = True Then Exit Sub

        Dim strSql As String = Nothing
        strSql = "SELECT LastName, FirstName +' '+ OtherNames AS [Given Names], TransactionId FROM EmployeeMaster ORDER BY LastName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        Dim arrPrintData As New ArrayList
        Dim objCommand As Data.OleDb.OleDbCommand

        While objReader.Read
            Dim strValues As String = Nothing
            For p As Integer = 0 To arrSelectedItems.Count - 1
                Dim dblAmount As Double = 0
                If CInt(arrSelectedItems.Item(p)) = 990 Or CInt(arrSelectedItems.Item(p)) = 991 Then
                    If CInt(arrSelectedItems.Item(p)) = 990 Then
                        'From the history file
                        objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(PaymentsHistory.Paye) FROM " _
                        & "PaymentsHistory WHERE DirectorId = " & objReader(2).ToString & " AND " _
                        & "PaymentDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
                        Dim objReadPaye As OleDb.OleDbDataReader = objCommand.ExecuteReader
                        Dim dblTotalPaye As Double = 0
                        While objReadPaye.Read
                            If IsNumeric(objReadPaye(0).ToString) Then dblTotalPaye = CDbl(objReadPaye(0).ToString)
                        End While
                        objReadPaye.Close()

                        'Get the sum of the aids levy and paye
                        objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(RunFile.Paye) FROM " _
                                & "RunFile WHERE DirectorId = " & objReader(2).ToString & " AND " _
                                & "PaymentDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
                        Dim objReadCurrentPaye As OleDb.OleDbDataReader = objCommand.ExecuteReader
                        Dim dblTotalCurrentPaye As Double = 0
                        While objReadCurrentPaye.Read
                            If IsNumeric(objReadCurrentPaye(0).ToString) Then dblTotalCurrentPaye = CDbl(objReadCurrentPaye(0).ToString)
                        End While
                        objReadCurrentPaye.Close()
                        dblAmount = dblTotalPaye + dblTotalCurrentPaye
                    End If
                    If CInt(arrSelectedItems.Item(p)) = 991 Then
                        'Aids Levy
                        objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(PaymentsHistory.AidsLevy) FROM " _
                        & "PaymentsHistory WHERE DirectorId = " & objReader(2).ToString & " AND " _
                        & "PaymentDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
                        Dim objReadAidsLevy As OleDb.OleDbDataReader = objCommand.ExecuteReader
                        Dim dblTotalAidsLevy As Double = 0
                        While objReadAidsLevy.Read
                            If IsNumeric(objReadAidsLevy(0).ToString) Then dblTotalAidsLevy = CDbl(objReadAidsLevy(0).ToString)
                        End While
                        objReadAidsLevy.Close()

                        objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(PaymentsHistory.AidsLevy) FROM " _
                                & "PaymentsHistory WHERE DirectorId = " & objReader(2).ToString & " AND " _
                                & "PaymentDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
                        Dim objReadCurrentAidsLevy As OleDb.OleDbDataReader = objCommand.ExecuteReader
                        Dim dblTotalCurrentAidsLevy As Double = 0
                        While objReadCurrentAidsLevy.Read
                            If IsNumeric(objReadCurrentAidsLevy(0).ToString) Then dblTotalCurrentAidsLevy = CDbl(objReadCurrentAidsLevy(0).ToString)
                        End While
                        objReadCurrentAidsLevy.Close()
                        dblAmount = dblTotalAidsLevy + dblTotalCurrentAidsLevy
                    End If
                Else
                    'Get the sum of such codes from the history
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(PaymentsHistory.GrossUp) FROM " _
                        & "PaymentsHistory WHERE CodeId = " & arrSelectedItems.Item(p) & " AND DirectorId = " & objReader(2).ToString & " AND " _
                        & "PaymentDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
                    Dim objReadSum As OleDb.OleDbDataReader = objCommand.ExecuteReader

                    Dim dblSumTotal As Double = 0
                    Dim dblSumCurrent As Double = 0

                    While objReadSum.Read
                        If IsNumeric(objReadSum(0).ToString) Then dblSumTotal = CDbl(objReadSum(0).ToString)
                    End While
                    objReadSum.Close()

                    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(RunFile.GrossUp) FROM " _
                        & "RunFile WHERE CodeId = " & arrSelectedItems.Item(p) & " AND DirectorId = " & objReader(2).ToString & " AND " _
                        & "PaymentDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
                    objReadSum = objCommand.ExecuteReader

                    While objReadSum.Read
                        If IsNumeric(objReadSum(0).ToString) Then dblSumCurrent = CDbl(objReadSum(0).ToString)
                    End While
                    objReadSum.Close()
                    dblAmount = dblSumTotal + dblSumCurrent
                End If

                strValues = strValues & Format(dblAmount, "##0.00") & ";"

            Next
            strValues = Mid(strValues, 1, strValues.Length - 1)
            arrPrintData.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" & strValues)
        End While
        objReader.Close()

        Dim strHeader As String = "SURNAME;GIVEN NAMES;"
        For p As Integer = 0 To arrSelectedItems.Count - 1
            strHeader = strHeader & Format(CInt(arrSelectedItems.Item(p)), "000") & ";"
        Next
        strHeader = Mid(strHeader, 1, strHeader.Length - 1)

        Dim arrOut As New ArrayList
        arrOut.Add(strHeader)
        arrOut.Add(" ; ")
        For p As Integer = 0 To arrPrintData.Count - 1
            arrOut.Add(arrPrintData.Item(p))
        Next

        arrOut.Add(" ; ")
        arrOut.Add("CODE KEY;")
        For p As Integer = 0 To arrCodeKey.Count - 1
            arrOut.Add(arrCodeKey.Item(p))
        Next

        WriteToExcel(arrOut)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " Line Items Print to Excel"
        ShowErrorMessage()
    End Sub

    Private Sub btnRestoreData_Click(sender As System.Object, e As System.EventArgs) Handles btnRestoreData.Click
        Dim f As New frmRunRestore
        f.ShowDialog()
    End Sub

End Class