Imports System.Drawing.Printing
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons

Public Class frmSalesPreview

    Dim strInvoiceDetails As ArrayList
    Dim prFont As New Font("Arial", 6, FontStyle.Bold)
    Dim tlFont As New Font("Arial", 6, FontStyle.Regular)
    Dim HeaderFont As New Font("Arial", 10, FontStyle.Bold)
    Dim strValue As String
    Dim itm As Integer
    Dim intPage As Integer
    Dim arrTransmittedInvoices As ArrayList
    Dim boolPrintFromPreview As Boolean
    Dim strCustomerAddress1 As String
    Dim strCustomerAddress2 As String
    Dim strCustomerAddress3 As String
    Dim strCustomerTelephone As String
    Dim strCustomerEmailaddress As String
    Dim strOrderNumber As String
    Dim strCustomerName As String
    Dim strCustomerVatNumber As String
    Dim strDate As String
    Dim strSalesRep As String
    Dim strCustomerAddress4 As String
    Dim boolExitingWhile As Boolean
    Dim dblInvoiceTotal As Double
    Dim dblTaxes As Double
    Dim dblDiscounts As Double
    Dim dblUnitPriceTotals As Double
    Dim i As Integer = 0

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        'select SalesRep AS [Agent], CAST((sum(amount)) AS DECIMAL (10,2)) AS [SALES], CAST((SUM((Amount - (amount * .35)))) AS DECIMAL (10,2)) AS BASEAMOUNT, CAST((SUM(((Amount - (amount * .35)) * .50))) AS DECIMAL (10,2)) AS COMMISSION FROM SalesMain GROUP BY SalesRep

        LoadSalesDetails()
        LoadSalesByInventory()
        LoadJobData()
        LoadCommissionsData()
        LoadSalesCounts()
        LoadInvoice()
        StockMovements()

        AlternateColors(dGrid)
        AlternateColors(dGridCommissions)
        AlternateColors(dGridJc)
        ' AlternateColors(dGridAllData)
        AlternateColors(dGridInvoices)
        AlternateColors(dGridStockMovement)

    End Sub

    Private Sub LoadInvoice()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing

        If UCase(cboUser.Text) = "--- ALL ---" Then
            strSql = "SELECT CustomerSalesMain.InvoiceNumber, CONVERT(NVARCHAR, CustomerSalesMain.TransDate, 105) AS [Date], Customers.AccountName, " _
                & "CAST(CustomerSalesMain.Amount AS DECIMAL (10,2)) AS [Value], CAST(CustomerSalesMain.Discount AS DECIMAL (10,2)) AS [Discounts], " _
                & "CAST(CustomerSalesMain.Taxes AS DECIMAL (10,2)) AS [Taxes] FROM CustomerSalesMain LEFT OUTER JOIN Customers ON " _
                & "CustomerSalesMain.CustomerId = Customers.AccountNumber WHERE TransDate BETWEEN " _
                & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND '" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' "

        Else
            strSql = "SELECT CustomerSalesMain.InvoiceNumber, CONVERT(NVARCHAR, CustomerSalesMain.TransDate, 105) AS [Date], Customers.AccountName, " _
                & "CAST(CustomerSalesMain.Amount AS DECIMAL (10,2)) AS [Value], CAST(CustomerSalesMain.Discount AS DECIMAL (10,2)) AS [Discounts], " _
                & "CAST(CustomerSalesMain.Taxes AS DECIMAL (10,2)) AS [Taxes] FROM CustomerSalesMain LEFT OUTER JOIN Customers ON " _
                & "CustomerSalesMain.CustomerId = Customers.AccountNumber WHERE TransDate BETWEEN " _
                & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' " _
                & "AND '" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' AND SalesRep = '" & cboUser.Text & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim i As Integer = 0
        With dGridInvoices
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then .Rows(i).Cells(0).Value = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then .Rows(i).Cells(1).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(i).Cells(2).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then .Rows(i).Cells(3).Value = objReader(3).ToString
                If Not IsDBNull(objReader(4).ToString) Then .Rows(i).Cells(4).Value = objReader(4).ToString
                If Not IsDBNull(objReader(5).ToString) Then .Rows(i).Cells(5).Value = objReader(5).ToString
                i = i + 1
            End While
            objReader.Read()

            'Calculate totals
            Dim dblMovingT As Double = 0
            Dim dblMovingTx As Double = 0
            Dim dblMovingDs As Double = 0
            Dim strValue As String
            For i = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "")) Then
                    strValue = Convert.ToString(.Rows(i).Cells(3).Value)
                    If IsNumeric(strValue) Then
                        dblMovingT = dblMovingT + CDbl(strValue)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "")) Then
                    strValue = Convert.ToString(.Rows(i).Cells(4).Value)
                    If IsNumeric(strValue) Then
                        dblMovingTx = dblMovingTx + CDbl(strValue)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "")) Then
                    strValue = Convert.ToString(.Rows(i).Cells(5).Value)
                    If IsNumeric(strValue) Then
                        dblMovingDs = dblMovingDs + CDbl(strValue)
                    End If
                End If
            Next

            .Rows.Add("", "", "TOTAL", Format(dblMovingT, "#,##0.00"), Format(dblMovingDs, "#,##0.00"), Format(dblMovingTx, "#,##0.00"))

        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSalesCounts()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Sales.SalesRep, COUNT(Sales.ItemCode) AS Total, " _
            & "CAST(SUM((Quantity * SalesPrice) - DiscountAllowed) AS DECIMAL (10,2)) AS [Amount] " _
            & "FROM Sales WHERE Sales.TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
            & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' " _
            & "GROUP BY SalesRep ORDER BY Total, SalesRep"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        With dGridCountBased
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(objReader(0), objReader(1), objReader(2))
            End While
            objReader.Close()
        End With
        AlternateColors(dGridCountBased)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Sales based on items sold load failure"
        ShowErrorMessage()
    End Sub

    Private Sub AlternateColors(ByVal myGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView)
        With myGrid
            For i As Integer = 0 To .Rows.Count - 1
                For j As Integer = 0 To .ColumnCount - 1
                    Dim backColor As Color = Color.White
                    .Rows(i).Cells(j).Style.BackColor = backColor
                Next
            Next
            For i As Integer = 0 To .Rows.Count - 1 Step 2
                For j As Integer = 0 To .Columns.Count - 1
                    Dim foreColor As Color = Color.Black
                    Dim backColor As Color = Color.WhiteSmoke
                    .Rows(i).Cells(j).Style.BackColor = backColor
                    .Rows(i).Cells(j).Style.ForeColor = foreColor
                Next j
            Next i
        End With
    End Sub

    Private Sub LoadCommissionsData()
        On Error GoTo RaiseErr

        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT LastName, FirstName, OtherNames, " _
            & "EmployeeClass FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        dGridCommissions.Rows.Clear()

        While objReader.Read

            Dim strRepName As String = Nothing
            Dim strCurrentEmployeeClass As String = Nothing

            If Not IsDBNull(objReader(0).ToString) Then strRepName = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strRepName = strRepName & " " & objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strRepName = strRepName & " " & objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then strCurrentEmployeeClass = objReader(3).ToString

            'Get the expenses and commission rate

            Dim dblExpensesRate As Double = 0
            Dim dblCommissionRate As Double = 0

            strRepName = Trim(strRepName)

            '
            '*** FIRST GET THE FIGURE FOR STAFF PURCHASE
            '
            Dim dblAgentExpenses As Double = 0
            Dim strSqlStatement As String = "SELECT SUM(StaffSales.Payable) FROM StaffSales " _
                & "WHERE TransactionDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
                & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' AND SalesAgent = '" & strRepName & "'"
            Dim objCommandStaffSales As New Data.OleDb.OleDbCommand(strSqlStatement, cnn)
            Dim objReadStaffSales As Data.OleDb.OleDbDataReader = objCommandStaffSales.ExecuteReader
            If objReadStaffSales.HasRows Then
                objReadStaffSales.Read()
                If IsNumeric(objReadStaffSales(0).ToString) Then dblAgentExpenses = CDbl(objReadStaffSales(0).ToString)
            End If
            objReadStaffSales.Close()

            '
            ' **** GET THE SALES INFORMATION FIRST ****
            '

            Dim dblSumOfSales As Double = 0
            Dim dblSumOfExpenses As Double = 0
            Dim dblSumAfterPurchases As Double = 0
            Dim dblSumOfCommissions As Double = 0

            strSqlStatement = "SELECT SalesMain.InvoiceNumber, SalesMain.SalesRep, " _
                & "SUM(SalesMain.Amount) as [Sales], SalesMain.ExpensesRate, SalesMain.CommissionRate AS " _
                & "[Commission] FROM SalesMain WHERE SalesMain.TransDate " _
                & "BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
                & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' AND SalesRep = '" & strRepName & "' " _
                & "GROUP BY SalesMain.SalesRep, SalesMain.ExpensesRate, SalesMain.Amount, SalesMain.InvoiceNumber, " _
                & "SalesMain.CommissionRate ORDER BY SalesMain.SalesRep"
            objCommand = New Data.OleDb.OleDbCommand(strSqlStatement, cnn)
            Dim objReadBaseValues As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            Dim Cnt As Integer = 0
            While objReadBaseValues.Read
                If IsNumeric(objReadBaseValues(2).ToString) Then dblSumOfSales = dblSumOfSales + CDbl(objReadBaseValues(2).ToString)
                If IsNumeric(objReadBaseValues(3).ToString) Then
                    If Cnt = 0 Then
                        dblSumOfExpenses = dblSumOfExpenses + ((dblSumOfSales - dblAgentExpenses) * CDbl(objReadBaseValues(3).ToString))
                    Else
                        dblSumOfExpenses = dblSumOfExpenses + (CDbl(objReadBaseValues(2).ToString) * CDbl(objReadBaseValues(3).ToString))
                    End If
                End If
                If IsNumeric(objReadBaseValues(4).ToString) Then
                    If Cnt = 0 Then
                        dblSumOfCommissions = dblSumOfCommissions + ((CDbl(objReadBaseValues(2).ToString) - dblSumOfExpenses - dblAgentExpenses) * CDbl(objReadBaseValues(4).ToString))
                    Else
                        dblSumOfCommissions = dblSumOfCommissions + ((CDbl(objReadBaseValues(2).ToString) - (CDbl(objReadBaseValues(2).ToString) * CDbl(objReadBaseValues(3).ToString))) * CDbl(objReadBaseValues(4).ToString))
                    End If
                End If
                Cnt = Cnt + 1
            End While
            objReadBaseValues.Close()

            With dGridCommissions
                .Rows.Add(UCase(strRepName), dblSumOfSales, dblAgentExpenses, (dblSumOfSales - dblAgentExpenses), dblSumOfExpenses, (dblSumOfSales - dblAgentExpenses - dblSumOfExpenses), dblSumOfCommissions)
            End With
            'objCommand = New Data.OleDb.OleDbCommand("SELECT ExpensesRate, CommissionRate FROM HairDressingCommissions " _
            '    & "WHERE EmployeeClass = '" & strCurrentEmployeeClass & "'", cnn)
            'Dim objReadRates As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            'If objReadRates.HasRows Then
            '    objReadRates.Read()
            '    If IsNumeric(objReadRates(0).ToString) Then dblExpensesRate = CDbl(objReadRates(0).ToString)
            '    If IsNumeric(objReadRates(1).ToString) Then dblCommissionRate = CDbl(objReadRates(1).ToString)
            'End If
            'objReadRates.Close()
            ''Dim strSqlStatement As String = "SELECT SalesRep, SUM((salesprice * quantity) - DiscountAllowed) as [Sales], " _
            ''    & "SUM(((salesprice * quantity) - DiscountAllowed) * ExpensesRate) AS [Expenses], " _
            ''    & "SUM((((salesprice * quantity) - DiscountAllowed) - (((salesprice * quantity) - DiscountAllowed) * " _
            ''    & "ExpensesRate)) * CommissionRate) AS [Commission] FROM Sales WHERE TransDate " _
            ''    & "BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
            ''    & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' AND SalesRep = '" & strRepName & "' " _
            ''    & "GROUP BY SalesRep"
            'objCommand = New Data.OleDb.OleDbCommand(strSqlStatement, cnn)

            ''objCommand = New Data.OleDb.OleDbCommand("SELECT SalesRep AS [Agent], CAST((sum(amount)) AS DECIMAL (10,2)) AS [SALES], " _
            ''    & "CAST((SUM((Amount - (amount * ExpensesRate)))) AS DECIMAL (10,2)) AS BASEAMOUNT, " _
            ''    & "CAST((SUM(((Amount - (amount * ExpensesRate)) * CommissionRate))) AS DECIMAL (10,2)) AS " _
            ''    & "[COMMISSION], ExpensesRate, CommissionRate FROM SalesMain WHERE TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
            ''    & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' AND SalesRep = '" & strRepName & "' " _
            ''    & "GROUP BY SalesRep, ExpensesRate, CommissionRate", cnn)

            ''Dim objEmployeeRecord As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

            'If UCase(strRepName) = "MUNEMO GESHMEN" Then
            '    KryptonMessageBox.Show("here")
            'End If
            'Get the employee staff purchases

            'Agent, Sales, Baseamount, Commission

            'Employee
            'Gross Sales
            'Staff Purchases
            'Net Sales
            'Deemed Expenses
            'Sales After Expenses
            'Commission

            'While objEmployeeRecord.Read
            '    With dGridCommissions
            '        .Rows.Add(1)

            '        'Get the commission rates

            '        If IsNumeric(objEmployeeRecord(2).ToString) Then dblExpensesRate = CDbl(objEmployeeRecord(2).ToString)
            '        If IsNumeric(objEmployeeRecord(3).ToString) Then dblCommissionRate = CDbl(objEmployeeRecord(3).ToString)

            '        If dblExpensesRate <> 0 Then dblExpensesRate = dblExpensesRate / 100
            '        If dblCommissionRate <> 0 Then dblCommissionRate = dblCommissionRate / 100

            '        'Get the staff purchases

            '        objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Payable) FROM StaffSales WHERE " _
            '            & "SalesAgent = '" & strRepName & "' AND TransactionDate BETWEEN " _
            '            & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
            '            & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "'", cnn)
            '        Dim objReadStaffPurchases As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            '        Dim dblStaffPurchases As Double = 0
            '        If objReadStaffPurchases.HasRows Then
            '            objReadStaffPurchases.Read()
            '            If IsNumeric(objReadStaffPurchases(0).ToString) Then dblStaffPurchases = CDbl(objReadStaffPurchases(0).ToString)
            '        End If
            '        objReadStaffPurchases.Close()

            '        If Not IsDBNull(objEmployeeRecord(0).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objEmployeeRecord(0).ToString
            '        If Not IsDBNull(objEmployeeRecord(1).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objEmployeeRecord(1).ToString
            '        .Rows(.Rows.Count - 1).Cells(2).Value = Format(dblStaffPurchases, "##0.00")

            '        Dim dblNetSales As Double = 0
            '        dblNetSales = CDbl(objEmployeeRecord(1).ToString) - dblStaffPurchases
            '        .Rows(.Rows.Count - 1).Cells(3).Value = Format(dblNetSales, "##0.00")

            '        Dim dblDeemedExpenses As Double = 0
            '        dblDeemedExpenses = dblNetSales * dblExpensesRate
            '        .Rows(.Rows.Count - 1).Cells(4).Value = Format(dblDeemedExpenses, "##0.00")

            '        Dim dblSalesAfterExpenses As Double = 0
            '        dblSalesAfterExpenses = dblNetSales - dblDeemedExpenses
            '        .Rows(.Rows.Count - 1).Cells(5).Value = Format(dblSalesAfterExpenses, "##0.00")

            '        Dim dblCommission As Double = 0
            '        dblCommission = dblSalesAfterExpenses * dblCommissionRate
            '        .Rows(.Rows.Count - 1).Cells(6).Value = Format(dblCommission, "##0.00")

            '        'If Not IsDBNull(objEmployeeRecord(2).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objEmployeeRecord(2).ToString
            '        'If Not IsDBNull(objEmployeeRecord(3).ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = objEmployeeRecord(3).ToString
            '    End With
            'End While
            'objEmployeeRecord.Close()

        End While
        objReader.Close()

        'Get the total line
        Dim dblValue As Double = 0
        Dim dblFees As Double = 0
        Dim dblTotal As Double = 0

        With dGridCommissions
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = "TOTALS"
            For p As Integer = 1 To .Columns.Count - 1
                dblValue = 0
                For i As Integer = 0 To .Rows.Count - 1
                    If IsNumeric(.Rows(i).Cells(p).Value) Then
                        dblValue = dblValue + CDbl(.Rows(i).Cells(p).Value.ToString)
                    End If
                Next
                .Rows(.Rows.Count - 1).Cells(p).Value = Format(dblValue, "##0.00")
                .Rows(.Rows.Count - 1).Cells(p).Style.BackColor = Color.FromArgb(195, 217, 242)
                .Rows(.Rows.Count - 1).Cells(p).Style.ForeColor = Color.Black
            Next
        End With
        'With dGridCommissions

        '    .Rows(.Rows.Count - 1).Cells(1).Value = Format(dblValue, "##0.00")
        '    .Rows(.Rows.Count - 1).Cells(2).Value = Format(dblFees, "##0.00")
        '    .Rows(.Rows.Count - 1).Cells(3).Value = Format(dblTotal, "##0.00")
        '    'Change the row line back color
        '    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = Color.FromArgb(195, 217, 242)
        '    .Rows(.Rows.Count - 1).Cells(1).Style.BackColor = Color.FromArgb(195, 217, 242)
        '    .Rows(.Rows.Count - 1).Cells(2).Style.BackColor = Color.FromArgb(195, 217, 242)
        '    .Rows(.Rows.Count - 1).Cells(3).Style.BackColor = Color.FromArgb(195, 217, 242)
        '    'Make the font bold
        '    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = Color.Black
        '    .Rows(.Rows.Count - 1).Cells(1).Style.ForeColor = Color.Black
        '    .Rows(.Rows.Count - 1).Cells(2).Style.ForeColor = Color.Black
        '    .Rows(.Rows.Count - 1).Cells(3).Style.ForeColor = Color.Black
        'End With
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Commissions Calculations"
        ShowErrorMessage()
    End Sub

    Private Sub LoadJobData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ReferenceNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "CustomerName, CAST(JobValue AS DECIMAL (10,2)) AS [Value], CAST(InspectionFee AS DECIMAL (10,2)) AS [Fee], " _
            & "CAST((JobValue + InspectionFee) AS DECIMAL (10,2)) AS [Total] FROM JobCards " _
            & "WHERE TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
            & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' ORDER BY ReferenceNumber", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridJc.Rows.Clear()
        While objReader.Read
            With dGridJc
                .Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
                If Not IsDBNull(objReader(4).ToString) Then .Rows(.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
                If Not IsDBNull(objReader(5).ToString) Then .Rows(.Rows.Count - 1).Cells(5).Value = objReader(5).ToString
            End With
        End While
        objReader.Close()

        'Get the total line
        Dim dblValue As Double = 0
        Dim dblFees As Double = 0
        Dim dblTotal As Double = 0

        For i As Integer = 0 To dGridJc.Rows.Count - 1
            If IsNumeric(dGridJc.Rows(i).Cells(3).Value) Then
                dblValue = dblValue + CDbl(dGridJc.Rows(i).Cells(3).Value.ToString)
            End If
            If IsNumeric(dGridJc.Rows(i).Cells(4).Value) Then
                dblFees = dblFees + CDbl(dGridJc.Rows(i).Cells(4).Value.ToString)
            End If
            If IsNumeric(dGridJc.Rows(i).Cells(5).Value) Then
                dblTotal = dblTotal + CDbl(dGridJc.Rows(i).Cells(5).Value.ToString)
            End If
        Next
        With dGridJc
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = ""
            .Rows(.Rows.Count - 1).Cells(1).Value = ""
            .Rows(.Rows.Count - 1).Cells(2).Value = "TOTALS"
            .Rows(.Rows.Count - 1).Cells(3).Value = Format(dblValue, "##0.00")
            .Rows(.Rows.Count - 1).Cells(4).Value = Format(dblFees, "##0.00")
            .Rows(.Rows.Count - 1).Cells(5).Value = Format(dblTotal, "##0.00")
            'Change the row line back color
            .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = Color.FromArgb(195, 217, 242)
            .Rows(.Rows.Count - 1).Cells(1).Style.BackColor = Color.FromArgb(195, 217, 242)
            .Rows(.Rows.Count - 1).Cells(2).Style.BackColor = Color.FromArgb(195, 217, 242)
            .Rows(.Rows.Count - 1).Cells(3).Style.BackColor = Color.FromArgb(195, 217, 242)
            .Rows(.Rows.Count - 1).Cells(4).Style.BackColor = Color.FromArgb(195, 217, 242)
            .Rows(.Rows.Count - 1).Cells(5).Style.BackColor = Color.FromArgb(195, 217, 242)
            'Make the font bold
            .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = Color.Black
            .Rows(.Rows.Count - 1).Cells(1).Style.ForeColor = Color.Black
            .Rows(.Rows.Count - 1).Cells(2).Style.ForeColor = Color.Black
            .Rows(.Rows.Count - 1).Cells(3).Style.ForeColor = Color.Black
            .Rows(.Rows.Count - 1).Cells(4).Style.ForeColor = Color.Black
            .Rows(.Rows.Count - 1).Cells(5).Style.ForeColor = Color.Black
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Job costing details load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSalesDetails()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        dGridAllData.Columns.Clear()

        Dim strSql As String = Nothing

        'If Not IsNumeric(txtDocNumber.Text) Then txtDocNumber.Text = "0"

        Dim dblDivisionFactor As Double = (1 / (100 + dblSalesTaxRate)) * 100
        dblDivisionFactor = 1

        If UCase(cboUser.Text) = "--- ALL ---" Then

            If UCase(strTaxComputationType) = "INCLUSIVE" Then
                strSql = "Select InvoiceNumber AS [Trans. ID], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CAST((Amount * " & dblDivisionFactor & ") AS DECIMAL (10,2)) AS [Pre-Tax], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                    & "CAST(Taxes AS DECIMAL (10,2)) AS [Tax], PaymentMethod AS [Pay Method], SalesRep AS [Sales Rep], KeyNumber as [Doc. No], " _
                    & "SalesMain.Username as [Operator] from SalesMain WHERE TransDate BETWEEN " _
                    & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
                    & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' order by TransDate, InvoiceNumber"

            Else
                strSql = "Select InvoiceNumber AS [Trans. ID], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CAST(Amount AS DECIMAL (10,2)) AS [Pre-Tax], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                    & "CAST(Taxes AS DECIMAL (10,2)) AS [Tax], PaymentMethod AS [Pay Method], SalesRep AS [Sales Rep], KeyNumber as [Doc. No], " _
                    & "SalesMain.Username as [Operator] from SalesMain WHERE TransDate BETWEEN " _
                    & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
                    & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' order by TransDate, InvoiceNumber"

            End If

        Else
            If UCase(strTaxComputationType) = "INCLUSIVE" Then

                strSql = "Select InvoiceNumber as [Trans. ID], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                   & "CAST((Amount * " & dblDivisionFactor & ") AS DECIMAL (10,2)) AS [Pre-Tax], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                   & "CAST(Taxes AS DECIMAL (10,2)) AS [Tax], PaymentMethod AS [Pay Method], SalesRep AS [Sales Rep], KeyNumber as [Doc. No], SalesMain.Username as [Operator] " _
                   & "from SalesMain WHERE UserName = '" & UCase(cboUser.Text) & "' " _
                   & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
                   & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' order by TransDate, InvoiceNumber"
            Else

                strSql = "Select InvoiceNumber as [Trans. ID], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                   & "CAST(Amount AS DECIMAL (10,2)) AS [Pre-Tax], CAST(Discount AS DECIMAL(10,2)) AS [Discounts], " _
                   & "CAST(Taxes AS DECIMAL (10,2)) AS [Tax], PaymentMethod AS [Pay Method], SalesRep AS [Sales Rep], KeyNumber as [Doc. No], SalesMain.Username as [Operator] " _
                   & "from SalesMain WHERE UserName = '" & UCase(cboUser.Text) & "' " _
                   & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
                   & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' order by TransDate, InvoiceNumber"

            End If

        End If

        'Populate the all sales grid
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridAllData.DataSource = dTable
        FormatSalesGrids(dGridAllData)
        ComputeTotals(dGridAllData)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        ShowErrorMessage()
    End Sub

    Private Sub FormatSalesGrids(ByVal Grid As KryptonDataGridView)
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        'Cash, Ecocash, Transfer, Swipe
        With Grid
            .Columns.Add("Cash", "Cash")
            .Columns.Add("Ecocash", "Ecocash")
            .Columns.Add("Swipe", "Swipe")
            .Columns.Add("Transfer", "Transfer")
            '.Columns.Add("Totals", "Total")

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

            Dim strPayMethod As String = "Cash"

            For i As Integer = 0 To .RowCount - 1
                Dim dblAmtBvat As Double = 0
                Dim dblAmtVat As Double = 0
                If Not Object.Equals(.Rows(i).Cells(2).Value, Nothing) Then
                    If IsNumeric(.Rows(i).Cells(2).Value.ToString) Then
                        dblAmtBvat = CDbl(.Rows(i).Cells(2).Value.ToString)
                    End If
                End If
                If Not Object.Equals(.Rows(i).Cells(4).Value, Nothing) Then
                    If IsNumeric(.Rows(i).Cells(4).Value.ToString) Then
                        dblAmtVat = CDbl(.Rows(i).Cells(4).Value.ToString)
                    End If
                End If
                If Not Object.Equals(.Rows(i).Cells(5).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(i).Cells(5).Value.ToString) Then
                        strPayMethod = .Rows(i).Cells(5).Value.ToString
                    End If
                End If

                Select Case UCase(strPayMethod)
                    Case Is = "CASH"
                        .Rows(i).Cells(.Columns.Count - 4).Value = Format(dblAmtBvat + dblAmtVat, "##0.00")
                    Case Is = "ECOCASH"
                        .Rows(i).Cells(.Columns.Count - 3).Value = Format(dblAmtBvat + dblAmtVat, "##0.00")
                    Case Is = "SWIPE"
                        .Rows(i).Cells(.Columns.Count - 2).Value = Format(dblAmtBvat + dblAmtVat, "##0.00")
                    Case Is = "TRANSFER"
                        .Rows(i).Cells(.Columns.Count - 1).Value = Format(dblAmtBvat + dblAmtVat, "##0.00")
                End Select
                '.Rows(i).Cells(.Columns.Count - 1).Value = Format(dblAmtBvat + dblAmtVat, "##0.00")
            Next
            For i As Integer = 0 To .Columns.Count - 1
                .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                If i >= 2 And i <= 4 Then
                    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
                If i >= .Columns.Count - 4 Then
                    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    '.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next
        End With
        'dGridAllData.DataSource = Nothing
        'dGridAllData.Rows.Add(1)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On grid view formatting"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSalesByInventory()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing

        If UCase(cboUser.Text) = "--- ALL ---" Then
            'strSql = "select Sales.ItemCode AS [Code], RTRIM(Sales.Description) as [Description], sum(Sales.Quantity) as [Qty], " _
            '    & "RTRIM(Sales.SerialNumbers) as [S.N.], CAST((sum(InventoryItems.SellingPrice * Sales.Quantity)) AS DECIMAL (10,2)) as " _
            '    & "[Sales $], CAST(sum(Sales.DiscountAllowed) AS DECIMAL (10,2)) AS [Discount], CAST((sum(Sales.Quantity) * sum(InventoryItems.CostPrice)) AS DECIMAL (10,2)) " _
            '    & "as [Cost $], CAST((sum(Sales.Quantity) * sum(InventoryItems.SellingPrice)) - " _
            '    & "(sum(Sales.DiscountAllowed) + (sum(InventoryItems.CostPrice) * sum(Sales.Quantity))) AS DECIMAL (10,2)) as " _
            '    & "[Profit] FROM Sales LEFT OUTER JOIN InventoryItems ON Sales.ItemCode = " _
            '    & "InventoryItems.ItemCode where Sales.TransDate BETWEEN " _
            '    & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' " _
            '    & "AND '" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' " _
            '    & "group by Sales.ItemCode, Sales.Description, Sales.SerialNumbers"

            strSql = "SELECT Sales.Itemcode, Sales.Description, Sales.SerialNumbers, Sales.Quantity, " _
                & "CAST(sales.SalesPrice AS DECIMAL (10,2)) AS [Sale], CAST(sales.DiscountAllowed AS DECIMAL (10,2)) AS [Discount], " _
                & "CAST(Sales.CostPrice AS DECIMAL (10,2)) AS [Cost], CAST((Sales.SalesPrice - Sales.CostPrice) AS DECIMAL (10,2)) AS " _
                & "[Profit], TransactionId AS [Id], Sales.InvoiceNumber FROM Sales WHERE Sales.TransDate BETWEEN " _
                & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' " _
                & "AND '" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' order by ItemCode, TransDate"

        Else
            'strSql = "select Sales.ItemCode as [Code], RTRIM(Sales.Description) as [Description], sum(Sales.Quantity) as [Qty], " _
            '    & "RTRIM(Sales.SerialNumbers) as [S.N.], CAST((sum(InventoryItems.SellingPrice * Sales.Quantity)) AS DECIMAL (10,2)) as " _
            '    & "[Sales $], CAST(sum(Sales.DiscountAllowed) AS DECIMAL (10,2)) as [Discount], CAST((sum(Sales.Quantity) * sum(InventoryItems.CostPrice)) AS DECIMAL (10,2)) " _
            '    & "as [Cost $], CAST((sum(Sales.Quantity) * sum(InventoryItems.SellingPrice)) - " _
            '    & "(sum(Sales.DiscountAllowed) + (sum(InventoryItems.CostPrice) * sum(Sales.Quantity))) AS DECIMAL (10,2)) as " _
            '    & "[Profit] FROM Sales LEFT OUTER JOIN InventoryItems ON Sales.ItemCode = " _
            '    & "InventoryItems.ItemCode WHERE Sales.UserName = '" & UCase(cboUser.Text) & "' " _
            '    & "AND Sales.InvoiceNumber > " & (CInt(txtDocNumber.Text) - 1) & " AND Sales.TransDate BETWEEN " _
            '    & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' " _
            '    & "AND '" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' " _
            '    & "group by Sales.ItemCode, Sales.Description, Sales.SerialNumbers"

            strSql = "SELECT Sales.Itemcode, Sales.Description, Sales.SerialNumbers, Sales.Quantity, " _
                & "CAST(sales.SalesPrice AS DECIMAL (10,2)) AS [Sale], CAST(sales.DiscountAllowed AS DECIMAL (10,2)) AS [Discount], " _
                & "CAST(Sales.CostPrice AS DECIMAL (10,2)) AS [Cost], CAST((Sales.SalesPrice - Sales.CostPrice) AS DECIMAL (10,2)) AS " _
                & "[Profit], TransactionId AS [Id], Sales.InvoiceNumber FROM Sales WHERE TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' and " _
                & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' AND Sales.UserName = '" & UCase(cboUser.Text) & "' " _
                & "ORDER BY ItemCode, TransDate"

        End If

        'Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        'cmd.CommandType = CommandType.Text

        'Dim da As New OleDb.OleDbDataAdapter(cmd)
        'Dim dTable As New DataTable()
        'da.Fill(dTable)
        'dGrid.DataSource = dTable

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        With dGrid
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    If UCase(objReader(0).ToString) <> ("00000") Then
                        .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), _
                            objReader(4), objReader(5), objReader(6), objReader(7), objReader(8), objReader(9))
                    End If
                End If
            End While
        End With
        objReader.Close()

        'Add the sales from invoices

        If UCase(cboUser.Text) = "--- ALL ---" Then
            'strSql = "select CustomerSales.ItemCode AS [Code], RTRIM(CustomerSales.Description) as [Description], sum(CustomerSales.Quantity) as [Qty], " _
            '    & "RTRIM(CustomerSales.SerialNumbers) as [S.N.], CAST((sum(InventoryItems.SellingPrice * CustomerSales.Quantity)) AS DECIMAL (10,2)) as " _
            '    & "[Sales $], CAST(sum(CustomerSales.DiscountAllowed) AS DECIMAL (10,2)) AS [Discount], CAST((sum(CustomerSales.Quantity) * sum(InventoryItems.CostPrice)) AS DECIMAL (10,2)) " _
            '    & "as [Cost $], CAST((sum(CustomerSales.Quantity) * sum(InventoryItems.SellingPrice)) - " _
            '    & "(sum(CustomerSales.DiscountAllowed) + (sum(InventoryItems.CostPrice) * sum(CustomerSales.Quantity))) AS DECIMAL (10,2)) as " _
            '    & "[Profit] FROM CustomerSales LEFT OUTER JOIN InventoryItems ON CustomerSales.ItemCode = " _
            '    & "InventoryItems.ItemCode where CustomerSales.TransDate BETWEEN " _
            '    & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' " _
            '    & "AND '" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' " _
            '    & "group by CustomerSales.ItemCode, CustomerSales.Description, CustomerSales.SerialNumbers"

            strSql = "SELECT CustomerSales.Itemcode, CustomerSales.Description, CustomerSales.SerialNumbers, CustomerSales.Quantity, " _
                & "CAST(CustomerSales.SalesPrice AS DECIMAL (10,2)) AS [Sale], CAST(CustomerSales.DiscountAllowed AS DECIMAL (10,2)) AS [Discount], " _
                & "CAST(CustomerSales.CostPrice AS DECIMAL (10,2)) AS [Cost], CAST((CustomerSales.SalesPrice - CustomerSales.CostPrice) AS DECIMAL (10,2)) AS " _
                & "[Profit], TransactionId AS [Id], CustomerSales.InvoiceNumber FROM CustomerSales WHERE CustomerSales.TransDate BETWEEN " _
                & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' " _
                & "AND '" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' order by ItemCode, TransDate"

        Else
            'strSql = "select CustomerSales.ItemCode as [Code], RTRIM(CustomerSales.Description) as [Description], sum(CustomerSales.Quantity) as [Qty], " _
            '    & "RTRIM(CustomerSales.SerialNumbers) as [S.N.], CAST((sum(InventoryItems.SellingPrice * CustomerSales.Quantity)) AS DECIMAL (10,2)) as " _
            '    & "[Sales $], CAST(sum(CustomerSales.DiscountAllowed) AS DECIMAL (10,2)) as [Discount], CAST((sum(CustomerSales.Quantity) * sum(InventoryItems.CostPrice)) AS DECIMAL (10,2)) " _
            '    & "as [Cost $], CAST((sum(CustomerSales.Quantity) * sum(InventoryItems.SellingPrice)) - " _
            '    & "(sum(CustomerSales.DiscountAllowed) + (sum(InventoryItems.CostPrice) * sum(CustomerSales.Quantity))) AS DECIMAL (10,2)) as " _
            '    & "[Profit] FROM CustomerSales LEFT OUTER JOIN InventoryItems ON CustomerSales.ItemCode = " _
            '    & "InventoryItems.ItemCode WHERE CustomerSales.UserName = '" & UCase(cboUser.Text) & "' " _
            '    & "AND CustomerSales.InvoiceNumber > " & (CInt(txtDocNumber.Text) - 1) & " AND CustomerSales.TransDate BETWEEN " _
            '    & "'" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' " _
            '    & "AND '" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' " _
            '    & "group by CustomerSales.ItemCode, CustomerSales.Description, CustomerSales.SerialNumbers"

            strSql = "SELECT CustomerSales.Itemcode, CustomerSales.Description, CustomerSales.SerialNumbers, CustomerSales.Quantity, " _
                & "CAST(CustomerSales.SalesPrice AS DECIMAL (10,2)) AS [Sale], CAST(CustomerSales.DiscountAllowed AS DECIMAL (10,2)) AS [Discount], " _
                & "CAST(CustomerSales.CostPrice AS DECIMAL (10,2)) AS [Cost], CAST((CustomerSales.SalesPrice - CustomerSales.CostPrice) AS DECIMAL (10,2)) AS " _
                & "[Profit], TransactionId AS [Id], CustomerSales.InvoiceNumber FROM CustomerSales WHERE TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' and " _
                & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' AND CustomerSales.UserName = '" & UCase(cboUser.Text) & "' " _
                & "ORDER BY ItemCode, TransDate"

        End If

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        With dGrid
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    If UCase(objReader(0).ToString) <> ("00000") Then
                        .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), _
                            objReader(5), objReader(6), objReader(7), objReader(8), objReader(9))
                    End If
                End If
            End While
        End With
        objReader.Close()

        dGrid.Columns(dGrid.ColumnCount - 2).Visible = False

        'Add the image column at the end

        'Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        'Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        'For p As Integer = 0 To dGrid.Columns.Count - 1
        '    dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        '    If p = 2 Or p = 4 Or p = 5 Or p = 6 Or p = 7 Then
        '        dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    End If
        'Next


        '' ''Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        '' ''Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        '' ''Dim dblTotalSales As Double = 0
        '' ''Dim dblTotalCosts As Double = 0
        '' ''Dim dblTotalGross As Double = 0
        '' ''While objReader.Read
        '' ''    dGrid.Rows.Add(1)
        '' ''    If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
        '' ''    If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
        '' ''    If Not IsDBNull(objReader(2).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
        '' ''    If Not IsDBNull(objReader(3).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
        '' ''    If IsNumeric(objReader(4).ToString) Then
        '' ''        dGrid.Rows(dGrid.Rows.Count - 1).Cells(4).Value = Format(CDbl(objReader(4).ToString), "##0.00")
        '' ''        dblTotalSales = dblTotalSales + CDbl(objReader(4).ToString)
        '' ''    End If
        '' ''    If IsNumeric(objReader(5).ToString) Then
        '' ''        If IsNumeric(objReader(6).ToString) Then
        '' ''            dGrid.Rows(dGrid.Rows.Count - 1).Cells(5).Value = Format(CDbl(objReader(6).ToString), "##0.00")
        '' ''            dblTotalCosts = dblTotalCosts + CDbl(objReader(6).ToString)
        '' ''        Else
        '' ''            dGrid.Rows(dGrid.Rows.Count - 1).Cells(5).Value = "0.00"
        '' ''            dblTotalCosts = dblTotalCosts + 0
        '' ''        End If
        '' ''    End If
        '' ''    If IsNumeric(objReader(6).ToString) Then
        '' ''        If IsNumeric(objReader(7).ToString) Then
        '' ''            dGrid.Rows(dGrid.Rows.Count - 1).Cells(6).Value = Format(CDbl(objReader(7).ToString), "##0.00")
        '' ''            dblTotalGross = dblTotalGross + CDbl(objReader(7).ToString)
        '' ''        Else
        '' ''            dGrid.Rows(dGrid.Rows.Count - 1).Cells(6).Value = "0.00"
        '' ''            dblTotalGross = dblTotalGross + 0
        '' ''        End If
        '' ''    End If

        '' ''End While
        'Add two lines at end and show the totals
        'dGrid.Rows.Add(2)
        'dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = "TOTALS"
        'dGrid.Rows(dGrid.Rows.Count - 1).Cells(4).Value = Format(dblTotalSales, "##0.00")
        'dGrid.Rows(dGrid.Rows.Count - 1).Cells(5).Value = Format(dblTotalCosts, "##0.00")
        'dGrid.Rows(dGrid.Rows.Count - 1).Cells(6).Value = Format(dblTotalGross, "##0.00")

        'With dGrid
        '    'Change the row line back color
        '    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = Color.FromArgb(195, 217, 242)
        '    .Rows(.Rows.Count - 1).Cells(1).Style.BackColor = Color.FromArgb(195, 217, 242)
        '    .Rows(.Rows.Count - 1).Cells(2).Style.BackColor = Color.FromArgb(195, 217, 242)
        '    .Rows(.Rows.Count - 1).Cells(3).Style.BackColor = Color.FromArgb(195, 217, 242)
        '    .Rows(.Rows.Count - 1).Cells(4).Style.BackColor = Color.FromArgb(195, 217, 242)
        '    .Rows(.Rows.Count - 1).Cells(5).Style.BackColor = Color.FromArgb(195, 217, 242)
        '    .Rows(.Rows.Count - 1).Cells(6).Style.BackColor = Color.FromArgb(195, 217, 242)
        '    'Make the font bold
        '    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = Color.Black
        '    .Rows(.Rows.Count - 1).Cells(1).Style.ForeColor = Color.Black
        '    .Rows(.Rows.Count - 1).Cells(2).Style.ForeColor = Color.Black
        '    .Rows(.Rows.Count - 1).Cells(3).Style.ForeColor = Color.Black
        '    .Rows(.Rows.Count - 1).Cells(4).Style.ForeColor = Color.Black
        '    .Rows(.Rows.Count - 1).Cells(5).Style.ForeColor = Color.Black
        '    .Rows(.Rows.Count - 1).Cells(6).Style.ForeColor = Color.Black
        'End With

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals(ByVal Grid As KryptonDataGridView)
        Dim dblPreTaxAmount As Double = 0
        Dim dblTaxes As Double = 0
        Dim dblDiscounts As Double = 0
        Dim dblCash As Double = 0
        Dim dblEcocash As Double = 0
        Dim dblSwipes As Double = 0
        Dim dblTransfers As Double = 0
        With Grid
            For n As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(2).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(2).Value.ToString) Then
                        dblPreTaxAmount = dblPreTaxAmount + CDbl(.Rows(n).Cells(2).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(3).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(3).Value.ToString) Then
                        dblDiscounts = dblDiscounts + CDbl(.Rows(n).Cells(3).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(4).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(4).Value.ToString) Then
                        dblTaxes = dblTaxes + CDbl(.Rows(n).Cells(4).Value.ToString)
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(9).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(9).Value.ToString) Then
                        dblCash = dblCash + CDbl(.Rows(n).Cells(9).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(10).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(10).Value.ToString) Then
                        dblEcocash = dblEcocash + CDbl(.Rows(n).Cells(10).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(11).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(11).Value.ToString) Then
                        dblSwipes = dblSwipes + CDbl(.Rows(n).Cells(11).Value.ToString)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(n).Cells(12).Value), "")) Then
                    If IsNumeric(.Rows(n).Cells(12).Value.ToString) Then
                        dblTransfers = dblTransfers + CDbl(.Rows(n).Cells(12).Value.ToString)
                    End If
                End If
            Next

            lblPreTax.Text = Format(dblPreTaxAmount, "#,##0.00")
            lblDiscounts.Text = Format(dblDiscounts, "#,##0.00")
            lblTaxes.Text = Format(dblTaxes, "#,##0.00")
            lblCash.Text = Format(dblCash, "#,##0.00")
            lblEcocash.Text = Format(dblEcocash, "#,##0.00")
            lblSwipes.Text = Format(dblSwipes, "#,##0.00")
            lblTransfers.Text = Format(dblTransfers, "#,##0.00")
            lblTotals.Text = Format((dblCash + dblEcocash + dblSwipes + dblTransfers), "#,##0.00")
        End With

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If dGridAllData.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridAllData.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridAllData.CurrentRow.Cells(0).Value.ToString) Then
                boolTransactionVoided = False
                intSelectedTransaction = CInt(dGridAllData.CurrentRow.Cells(0).Value.ToString)
                strCalledBy = Nothing
                Dim f As New frmSalesDetails
                f.ShowDialog()
                If boolTransactionVoided = True Then LoadSalesDetails()
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        ShowErrorMessage()
    End Sub

    Private Sub PrintReceipt()
        On Error GoTo RaiseErr
        Dim arrPrintDetails As New ArrayList
        arrPrintDetails.Add(Space(2) & strCompanyName)
        arrPrintDetails.Add(Space(2) & strCompanyAddress1)
        arrPrintDetails.Add(Space(2) & strCompanyAddress2)
        arrPrintDetails.Add(Space(2) & strCompanyAddress3)
        arrPrintDetails.Add(Space(2) & "PHONE: " & strCompanyTelephone)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        arrPrintDetails.Add(Space(2) & "DATE FROM " & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy"))
        arrPrintDetails.Add(Space(2) & "DATE TO   " & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy"))
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "REC.NO    AMOUNT      DISCOUNT     TAX")
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        Dim dblAmount As Double = 0
        Dim dblDiscounts As Double = 0
        Dim dblTaxes As Double = 0

        Dim strDoc As String = Nothing
        Dim strDate As String = Nothing
        Dim strAmount As String = "0.00"
        Dim strDiscount As String = "0.00"
        Dim strTaxes As String = "0.00"

        With dGridAllData
            For i As Integer = 0 To dGridAllData.Rows.Count - 1
                strDoc = Nothing
                strDate = Nothing
                strAmount = "0.00"
                strDiscount = "0.00"
                strTaxes = "0.00"
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then
                    strDoc = Format(CInt(Convert.ToString(.Rows(i).Cells(0).Value)), "00000")
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "")) Then
                    strAmount = Format(CDbl(Convert.ToString(.Rows(i).Cells(2).Value)), "##0.00")
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "")) Then
                    strDiscount = Format(CDbl(Convert.ToString(.Rows(i).Cells(3).Value)), "##0.00")
                End If
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "")) Then
                    strTaxes = Format(CDbl(Convert.ToString(.Rows(i).Cells(4).Value)), "##0.00")
                End If

                arrPrintDetails.Add(strDoc & Space(2) & Space(8 - strAmount.Length) & strAmount & Space(3) & Space(8 - strDiscount.Length) & strDiscount & Space(3) & Space(8 - strTaxes.Length) & strTaxes)

                dblAmount = dblAmount + CDbl(strAmount)
                dblDiscounts = dblDiscounts + CDbl(strDiscount)
                dblTaxes = dblTaxes + CDbl(strTaxes)

            Next
            'Add the total Line
            strAmount = CStr(Format(dblAmount, "##0.00"))
            strDiscount = CStr(Format(dblDiscounts, "##0.00"))
            strTaxes = CStr(Format(dblTaxes, "##0.00"))
            arrPrintDetails.Add("TOTAL" & Space(2) & Space(8 - strAmount.Length) & strAmount & Space(3) & Space(8 - strDiscount.Length) & strDiscount & Space(3) & Space(8 - strTaxes.Length) & strTaxes)
            arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
            For p As Integer = 0 To 14
                arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
            Next p
        End With

        'Send the details to the printer
        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()
        For n = 0 To arrPrintDetails.Count - 1
            Dim strPrintLineDetails As String = arrPrintDetails.Item(n) & vbCrLf
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintLineDetails)
        Next
        KryptonMessageBox.Show("Report printed successfully", "Sales Details Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis print"
        ShowErrorMessage()
    End Sub

    Private Sub btnTransmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransmit.Click
        FinishProcess()
        'txtBatchNo.Text = GetBatchNumber()
    End Sub

    Private Sub FinishProcess()

        If dGridAllData.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.Default
        intStartNumber = CInt(dGridAllData.Rows(0).Cells(0).Value.ToString)
        intEndNumber = CInt(dGridAllData.Rows(dGridAllData.Rows.Count - 1).Cells(0).Value.ToString)
        gwt_comm.SalesInternetTransfers(intStartNumber, intEndNumber, "CASH SALES")
        If boolAbort = False Then
            MessageBox.Show("Transmission performed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Transmissions"
        ShowErrorMessage()

        '        On Error GoTo RaiseErr
        '        txtBatchNo.Text = GetBatchNumber()
        '        Dim fileString As String = Nothing
        '        Dim strDetailedSales As String = Nothing
        '        frmMainOne.ProgressBar1.Visible = True : frmMainOne.ProgressBar1.Maximum = dGridAllData.Rows.Count + 1 : frmMainOne.ProgressBar1.Value = 0
        '        arrTransmittedInvoices = New ArrayList
        '        For i As Integer = 0 To dGridAllData.Rows.Count - 1
        '            Dim strInvNo As String = "0"
        '            If Not (Object.Equals(Convert.ToString(dGridAllData.Rows(i).Cells(0).Value), "")) Then
        '                strInvNo = Convert.ToString(dGridAllData.Rows(i).Cells(0).Value)
        '                arrTransmittedInvoices.Add(strInvNo)
        '                Dim objGetSalesMainData As New Data.OleDb.OleDbCommand("SELECT [InvoiceNumber]," _
        '                    & "[CustomerId],[Status],[Amount],[Taxes],[Discount]" _
        '                    & ",CONVERT(NVARCHAR, [TransDate], 105) AS [TransDate], [SalesRep],[UserName]," _
        '                    & "[OriginalInvoice] FROM SalesMain WHERE InvoiceNumber = " & CInt(strInvNo) & "", cnn)
        '                Dim objReadSales As OleDb.OleDbDataReader = objGetSalesMainData.ExecuteReader
        '                While objReadSales.Read

        '                    Dim strTaxCharged As String = "0.00"
        '                    Dim strDiscountAllowed As String = "0.00"
        '                    Dim strAmountPayable As String = "0.00"
        '                    Dim strDate As String = Nothing
        '                    Dim strCustomerId As String = Nothing
        '                    Dim strStatus As String = Nothing
        '                    Dim strSalesAgent As String = Nothing
        '                    Dim strSalesUser As String = Nothing
        '                    Dim intOriginalInvoice As Int16 = 0
        '                    Dim strOriginatingBranch As String = Nothing

        '                    If Not IsDBNull(objReadSales("TransDate").ToString) Then
        '                        strDate = objReadSales("TransDate").ToString
        '                        Dim strDateSplit() As String = Split(strDate, "-")
        '                        strDate = strDateSplit(0) & "-" & getMonth(CInt(strDateSplit(1))) & "-" & strDateSplit(2)
        '                    End If
        '                    If Not IsDBNull(objReadSales("Amount").ToString) Then
        '                        If IsNumeric(objReadSales("Amount").ToString) Then
        '                            strAmountPayable = objReadSales("Amount").ToString
        '                        End If
        '                    End If
        '                    If Not IsDBNull(objReadSales("Discount").ToString) Then
        '                        If IsNumeric(objReadSales("Discount").ToString) Then
        '                            strDiscountAllowed = objReadSales("Discount").ToString
        '                        End If
        '                    End If
        '                    If Not IsDBNull(objReadSales("Taxes").ToString) Then
        '                        If IsNumeric(objReadSales("Taxes").ToString) Then
        '                            strTaxCharged = objReadSales("Taxes").ToString
        '                        End If
        '                    End If

        '                    If Not IsDBNull(objReadSales("CustomerId").ToString) Then
        '                        strCustomerId = objReadSales("CustomerId").ToString
        '                    End If

        '                    If Not IsDBNull(objReadSales("Status").ToString) Then
        '                        strStatus = objReadSales("Status").ToString
        '                    End If

        '                    If Not IsDBNull(objReadSales("SalesRep").ToString) Then
        '                        strSalesAgent = objReadSales("SalesRep").ToString
        '                    End If
        '                    If Not IsDBNull(objReadSales("UserName").ToString) Then
        '                        strSalesUser = objReadSales("UserName").ToString
        '                    End If
        '                    If Not IsDBNull(objReadSales("OriginalInvoice").ToString) Then
        '                        If IsNumeric(objReadSales("OriginalInvoice").ToString) Then
        '                            intOriginalInvoice = objReadSales("OriginalInvoice").ToString
        '                        End If
        '                    End If

        '                    fileString = fileString & "MAIN SALES|" & txtBatchNo.Text & "|" & strInvNo & "|" & strCustomerId & "|" _
        '                        & strStatus & "|" & strAmountPayable & "|" & strTaxCharged & "|" & strDiscountAllowed & "|" & strDate & "|" _
        '                        & strSalesAgent & "|" & strSalesUser & "|" & intOriginalInvoice & "|" & strUserBranch & "|" & strUserName & vbCrLf

        '                End While
        '                objReadSales.Close()
        '            End If
        '            frmMainOne.ProgressBar1.Value = frmMainOne.ProgressBar1.Value + 1
        '        Next

        '        'Transmit the sales details
        '        frmMainOne.ProgressBar1.Maximum = arrTransmittedInvoices.Count + 1 : frmMainOne.ProgressBar1.Value = 0
        '        For i As Integer = 0 To arrTransmittedInvoices.Count - 1
        '            Dim objSalesDetails As New Data.OleDb.OleDbCommand("SELECT [InvoiceNumber],[CustomerId]," _
        '                & "[ItemCode],[Description],[Quantity],[DiscountAllowed],[Taxes]" _
        '                & ",[TransType],[SalesPrice],[TransDate],[ProductType],[SerialNumbers],[OriginalInvoice]" _
        '                & ",[SalesRep],[UserName] FROM Sales WHERE InvoiceNumber = " & arrTransmittedInvoices.Item(i) & "", cnn)
        '            Dim objReadSales As Data.OleDb.OleDbDataReader = objSalesDetails.ExecuteReader
        '            While objReadSales.Read
        '                fileString = fileString & "DETAILED SALES|" & txtBatchNo.Text & "|" & objReadSales(0).ToString & "|" & objReadSales(1).ToString & "|" _
        '                    & objReadSales(2).ToString & "|" & objReadSales(3).ToString & "|" & objReadSales(4).ToString & "|" _
        '                    & objReadSales(5).ToString & "|" & objReadSales(6).ToString & "|" & objReadSales(7).ToString & "|" _
        '                    & objReadSales(8).ToString & "|" & objReadSales(9).ToString & "|" & objReadSales(10).ToString & "|" _
        '                    & objReadSales(11).ToString & "|" & objReadSales(12).ToString & "|" & objReadSales(13).ToString & "|" _
        '                    & objReadSales(14).ToString & "|" & strUserBranch & "|" & strUserName & vbCrLf
        '            End While
        '            objReadSales.Close()
        '            frmMainOne.ProgressBar1.Value = frmMainOne.ProgressBar1.Value + 1
        '        Next
        '        frmMainOne.ProgressBar1.Value = frmMainOne.ProgressBar1.Maximum
        '        If UCase(strNetworkOperationStatus) = "SERVER" Then
        '            boolServerAdditions = True
        '        End If
        '        Cursor = Cursors.WaitCursor
        '        boolAbort = False
        '        strDownloadingType = "SALES"
        '        ServerDestinationFolder = strWebMainBranch.Replace(" ", "") & "/Sales"
        '        strDestinationBranch = strWebMainBranch
        '        'Transmit the main sales data first
        '        AddDataChanges(fileString)
        '        If boolAbort = True Then
        '            KryptonMessageBox.Show("There were errors encountered when transmit sales data. Make sure that the connection is on and retry sending", _
        '                "Data Transmission Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Else
        '            Dim objUpdate As New Data.OleDb.OleDbCommand("UPDATE SalesTranmissonBatches SET BatchNo = (BatchNo + 1)", cnn)
        '            objUpdate.ExecuteNonQuery()
        '            txtBatchNo.Text = CInt(txtBatchNo.Text) + 1
        '        End If
        '        Cursor = Cursors.Default
        '        Exit Sub
        'RaiseErr:
        '        Cursor = Cursors.Default
        '        boolAbort = True
        '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Web Sales Data Transmissions"
        '        ShowErrorMessage()
    End Sub

    Private Sub frmSalesPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''Preset the tab colors
        'tabMain.Tabs(0).PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Orange
        'tabMain.Tabs(1).PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Green
        'tabMain.Tabs(2).PredefinedColor = DevComponents.DotNetBar.eTabItemColor.PurpleMist
        'tabMain.Tabs(3).PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Apple
        'tabMain.Tabs(4).PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Yellow
        'tabMain.Tabs(5).PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Teal
        LoadUsers()
        LoadSalesDetails()
        TabControl1.SelectedTabIndex = 0
    End Sub

    Private Sub LoadUsers()
        On Error GoTo RaiseErr
        cboUser.Items.Clear()
        cboUser.Items.Add("--- ALL ---")
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT UserName FROM Users ORDER BY UserName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboUser.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Usernames Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGridAllData_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridAllData.CellContentDoubleClick
        If dGridAllData.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridAllData.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridAllData.CurrentRow.Cells(0).Value.ToString) Then
                boolTransactionVoided = False
                intSelectedTransaction = CInt(dGridAllData.CurrentRow.Cells(0).Value.ToString)
                strCalledBy = Nothing
                Dim f As New frmSalesDetails
                f.ShowDialog()
                If boolTransactionVoided = True Then LoadSalesDetails()
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On daily sales analysis"
        ShowErrorMessage()
    End Sub

    'Private Sub dGridAllData_DoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridAllData.DoubleClick

    'End Sub

    Private Sub ViewAgentSalesDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAgentSalesDetailsToolStripMenuItem.Click
        'Get the selected agent name and then call the view details form
        If dGridCommissions.RowCount <= 0 Then Exit Sub
        strSelectedCustomerName = dGridCommissions.CurrentRow.Cells(0).Value
        StartDate = dpStartFrom.Value : EndDate = dpEndTo.Value
        Dim f As New frmSalesDetailedCommissionView
        f.ShowDialog()
        strSelectedCustomerName = Nothing
        'Reload the grid for commissions only
        LoadCommissionsData()
    End Sub

    'Private Sub EnterAgentPurchasesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnterAgentPurchasesToolStripMenuItem.Click
    '    If dGridAllData.RowCount <= 0 Then Exit Sub
    '    intLinkedDocumentNumber = CInt(dGridAllData.CurrentRow.Cells(0).Value.ToString)
    '    Dim strBuffer() As String = Split(dGridAllData.CurrentRow.Cells(1).Value.ToString, "-")
    '    dpLinkedDate = CDate(strBuffer(0) & "-" & MonthName(CInt(strBuffer(1)), True) & "-" & strBuffer(2))
    '    Dim f As New frmSalesToAgents
    '    f.ShowDialog()
    'End Sub

    Private Sub btnTaxInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaxInvoice.Click
        If dGridAllData.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim i As Integer = dGridAllData.CurrentRow.Index
        'If Not (Object.Equals(dGridAllData.Rows(i).Cells(0).Value, Nothing)) Then
        '    If Not String.IsNullOrEmpty(dGridAllData.Rows(i).Cells(0).Value.ToString) Then
        '        If IsNumeric(dGridAllData.Rows(i).Cells(0).Value.ToString) Then
        intSelectedTransaction = CInt(dGridAllData.Rows(i).Cells(0).Value.ToString)
        Dim boolTaxInvoiceDone As Boolean = False

        'Check that no saved invoice has been made against this record
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Count(DocumentNumber) FROM CashTaxInvoices WHERE DocumentNumber = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                If CInt(objReader(0).ToString) > 0 Then
                    boolTaxInvoiceDone = True
                End If
            End If
        End If
        objReader.Close()

        If boolTaxInvoiceDone = True Then
            MessageBox.Show("A tax invoice has already been done against this receipt" & vbCrLf & "You can re-print from the list of saved tax invoices", "Tax Invoice Already Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        boolPrintingSavedTaxInvoice = False
        boolPrinterAlreadySelected = False
        gwt_comm.PrintCustomerDocument(intSelectedTransaction, "TAX INVOICE")
        '        End If
        '    End If
        'End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Tax Invoice"
        ShowErrorMessage()
    End Sub

    Private Sub GenerateTransactionDocument(ByVal intDocumentNumber As Integer)
        'get invoice number
        On Error GoTo RaiseErr
        Dim n As Integer = 0
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim strCustomerNumber As String = Nothing

        myCommand = New Data.OleDb.OleDbCommand("Select CONVERT(NVARCHAR, TransDate, 105) as [TransDate], Amount, Taxes, " _
            & "Discount, CustomerId, OrderNumber, SalesRep " _
            & "FROM CustomerSalesMain Where InvoiceNumber = " & intDocumentNumber & "", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            Dim strDateparts() As String = Split(dbReader(0).ToString, "-")
            If Not IsDBNull(dbReader(0).ToString) Then strDate = CDate(strDateparts(0) & "-" & MonthName(CInt(strDateparts(1)), True) & "-" & strDateparts(2))
            If IsNumeric(dbReader(1).ToString) Then dblInvoiceTotal = CDbl(dbReader(1).ToString) Else dblInvoiceTotal = 0
            If IsNumeric(dbReader(2).ToString) Then dblTaxes = dbReader(2).ToString Else dblTaxes = 0
            If IsNumeric(dbReader(3).ToString) Then dblDiscounts = dbReader(3).ToString Else dblDiscounts = 0
            If Not IsDBNull(dbReader(4).ToString) Then strCustomerNumber = dbReader(4).ToString
            If Not IsDBNull(dbReader("OrderNumber").ToString) Then strOrderNumber = dbReader("OrderNumber").ToString
            If Not IsDBNull(dbReader("SalesRep").ToString) Then strSalesRep = dbReader("SalesRep").ToString
        End If
        dbReader.Close()

        'Get the customer details
        myCommand = New Data.OleDb.OleDbCommand("SELECT AccountName, Address1, Address2, Address3, Address4, " _
            & "PhoneNumber, EmailAddress, VatNumber FROM Customers WHERE AccountNumber = '" & strCustomerNumber & "'", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            If Not IsDBNull(dbReader(0).ToString) Then strCustomerName = dbReader(0).ToString
            If Not IsDBNull(dbReader(1).ToString) Then strCustomerAddress1 = dbReader(1).ToString
            If Not IsDBNull(dbReader(2).ToString) Then strCustomerAddress2 = dbReader(2).ToString
            If Not IsDBNull(dbReader(3).ToString) Then strCustomerAddress3 = dbReader(3).ToString
            If Not IsDBNull(dbReader(4).ToString) Then strCustomerAddress4 = dbReader(4).ToString
            If Not IsDBNull(dbReader(5).ToString) Then strCustomerTelephone = dbReader(5).ToString
            If Not IsDBNull(dbReader(6).ToString) Then strCustomerEmailaddress = dbReader(6).ToString
            If Not IsDBNull(dbReader(7).ToString) Then strCustomerVatNumber = dbReader(7).ToString
        End If

        myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity, ItemCode, Description as [Description], SalesPrice, " _
            & "DiscountAllowed, Taxes, (((SalesPrice * Quantity) - DiscountAllowed) + Taxes) AS [Payable] " _
            & "from CustomerSales where InvoiceNumber = " & intDocumentNumber & "", cnn)
        dbReader = myCommand.ExecuteReader
        strInvoiceDetails = New ArrayList
        While dbReader.Read
            Dim strLine As String = Nothing
            For n = 0 To dbReader.FieldCount - 1
                If n = 0 Then
                    strLine = dbReader(n).ToString & "|"
                Else
                    strLine = strLine & dbReader(n).ToString & "|"
                End If
            Next
            strInvoiceDetails.Add(strLine)
        End While
        dbReader.Close()

        boolPrintFromPreview = False

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Invoice Generation Error"
        ShowErrorMessage()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        boolAbort = False
        Dim f As New frmCostPriceAdjustmentOnSales
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        'Get the item id
        On Error GoTo RaiseErr
        Dim intId As Integer = CInt(dGrid.CurrentRow.Cells(dGrid.ColumnCount - 1).Value.ToString)
        Dim dblSalesPrc As Double = CDbl(dGrid.CurrentRow.Cells(4).Value.ToString)
        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE Sales SET CostPrice = " & dblNewCostPrice & " WHERE InvoiceNumber = " & intId & "", cnn)
        objCommand.ExecuteNonQuery()
        'Change the current cell value for the cost price
        dGrid.CurrentRow.Cells(6).Value = Format(dblNewCostPrice, "##0.00")
        dGrid.CurrentRow.Cells(7).Value = Format((dblSalesPrc - dblNewCostPrice), "##0.00")
        If KryptonMessageBox.Show("Cost Price adjusted successfully. Do you want to refresh items right away?", _
                "Cost Price Update Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            LoadSalesByInventory()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On cost price adjustment after sales"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintReceipt.Click
        PrintReceipt()
    End Sub

    Private Sub BuildRXML(ByVal myGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView, ByVal strReportHeader As String)
        On Error GoTo RaiseErr
        Dim arrPrintDetails As New ArrayList
        If myGrid.Rows.Count <= 0 Then
            KryptonMessageBox.Show("No details to print. Process will be aborted", "Report Generation Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        With myGrid
            For i As Integer = 0 To .Rows.Count - 1
                Dim strLineData As String = Nothing
                For p As Integer = 0 To .ColumnCount - 1
                    'FN=Arial;FS=8;FC=White;FB=False;FI=False;FU=False;BC=Navy;RH=25
                    Dim strFontName As String = "Arial"
                    Dim intFontSize As Integer = 6
                    Dim strFontColor As String = "Black"
                    Dim strFontBold As String = "False"
                    Dim strFontItalic As String = "False"
                    Dim strFontUnderline As String = "False"
                    Dim strBackColor As String = "White"
                    Dim intRectangleHeight As Integer = 25
                    Dim strPrintData As String = Nothing

                    If .Columns(p).Visible = True Then
                        If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(p).Value), "")) Then
                            strPrintData = .Rows(i).Cells(p).Value.ToString
                            'Get the actual font and style used in the grid
                            Dim fnt As Font = .Rows(i).Cells(p).Style.Font
                            If fnt Is Nothing Then intFontSize = 6 Else intFontSize = fnt.Size
                            If fnt Is Nothing Then strFontName = "Ariel" Else strFontName = fnt.Name
                            Dim strFontStyle As String = "False"
                            If Not fnt Is Nothing Then strFontStyle = fnt.Style
                            If strFontStyle = "1" Then strFontBold = "True"
                            If strFontStyle = "2" Then strFontItalic = "True"
                            If strFontStyle = "3" Then ' Bold and italic
                                strFontBold = "True"
                                strFontItalic = "True"
                            End If
                            If strFontStyle = "4" Then strFontUnderline = "True"
                            If strFontStyle = "5" Then ' Bold and underline
                                strFontBold = "True"
                                strFontUnderline = "True"
                            End If
                            If strFontStyle = "6" Then ' italic and underline
                                strFontItalic = "True"
                                strFontUnderline = "True"
                            End If
                            If strFontStyle = "7" Then ' italic and underline
                                strFontItalic = "True"
                                strFontUnderline = "True"
                                strFontBold = "True"
                            End If

                            Dim intAlignment As Integer = 0

                            'Get the column alignment DataGridViewContentAlignment.MiddleCenter
                            Dim selectedCell As DataGridViewCell = .Rows(i).Cells(p)
                            Dim align As System.Drawing.ContentAlignment
                            'For Each selectedCell In .SelectedCells
                            align = selectedCell.InheritedStyle.Alignment
                            If selectedCell.InheritedStyle.Alignment = DataGridViewContentAlignment.MiddleLeft Then
                                intAlignment = 0
                            End If
                            If selectedCell.InheritedStyle.Alignment = DataGridViewContentAlignment.MiddleCenter Then
                                intAlignment = 1
                            End If
                            If selectedCell.InheritedStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                                intAlignment = 2
                            End If
                            'Next


                            strLineData = strLineData & strPrintData & "|FN=" & strFontName & ";FS=" & intFontSize _
                                & ";FC=" & strFontColor & ";FB=" & strFontBold & ";FI=" & strFontItalic & ";FU=" & strFontUnderline _
                                & ";BC=" & strBackColor & ";RH=" & intRectangleHeight & ";AL=" & intAlignment & "</d>"
                        Else
                            strLineData = strLineData & " |FN=" & strFontName & ";FS=" & intFontSize _
                                & ";FC=" & strFontColor & ";FB=" & strFontBold & ";FI=" & strFontItalic & ";FU=" & strFontUnderline _
                                & ";BC=" & strBackColor & ";RH=" & intRectangleHeight & ";AL=0</d>"
                        End If
                    End If
                Next
                strLineData = Mid(strLineData, 1, strLineData.Length - 4)
                arrPrintDetails.Add(strLineData)

            Next


            Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
            For i As Integer = 0 To arrPrintDetails.Count - 1
                strPrintDetails(i) = arrPrintDetails.Item(i)
            Next

            Dim strColumnHeaders As String = Nothing
            For i As Integer = 0 To .ColumnCount - 1
                If .Columns(i).Visible = True Then strColumnHeaders = strColumnHeaders & .Columns(i).HeaderText & "|"
            Next
            strColumnHeaders = Mid(strColumnHeaders, 1, (strColumnHeaders.Length - 1))

            'Request for print properties
            Dim prnt As New PrintDialog
            prnt.ShowDialog()

            Dim intPrintPageAreaWidth As Integer = prnt.PrinterSettings.DefaultPageSettings.PaperSize.Width _
                    - (prnt.PrinterSettings.DefaultPageSettings.Margins.Left + prnt.PrinterSettings.DefaultPageSettings.Margins.Right)

            'Widths are based on the percentage point of the paper size and the grid
            Dim strColumnWidths As String = Nothing
            Dim strColumsVisible As String = Nothing

            Dim intTotalGridWidth As Integer = 0
            'calculate the total column widths
            For y As Integer = 0 To .ColumnCount - 1
                intTotalGridWidth = intTotalGridWidth + .Columns(y).Width
            Next

            Dim intValidateWidth As Integer = 0
            For i As Integer = 0 To myGrid.ColumnCount - 1
                Dim intCurrentWidth As Integer = 0
                If .Columns(i).Visible = True Then
                    'Calculate the width based on the percentage in the grid
                    Dim intEqualWidth As Integer = intPrintPageAreaWidth / .Columns.Count
                    Dim intPercentagePrintArea As Integer = (.Columns(i).Width / intTotalGridWidth) * 100
                    intCurrentWidth = intPrintPageAreaWidth * (intPercentagePrintArea / 100)

                    strColumnWidths = strColumnWidths & intCurrentWidth & "|"

                    If intCurrentWidth = 0 Then
                        strColumsVisible = strColumsVisible & "NO" & "|"
                    Else
                        strColumsVisible = strColumsVisible & "YES" & "|"
                    End If
                    intValidateWidth = intValidateWidth + intCurrentWidth
                End If
            Next
            strColumnWidths = Mid(strColumnWidths, 1, (strColumnWidths.Length - 1))
            strColumsVisible = Mid(strColumsVisible, 1, (strColumsVisible.Length - 1))

            Dim intNumberOfColumns As Integer = 0
            For z As Integer = 0 To .Columns.Count - 1
                If .Columns(z).Visible = True Then intNumberOfColumns = intNumberOfColumns + 1
            Next

            Dim rpt As New SmartReportWriter.SmartReportWriter
            With rpt
                .intPrintRecordsCount = strPrintDetails.Length
                .intNumberOfColumns = intNumberOfColumns
                .strColumnHeaders = UCase(strColumnHeaders)
                .strColumnWidths = strColumnWidths
                .strFooterCaption = strReportHeader
                .strMainCaption = UCase(strReportHeader)
                .strMainHeader2 = "PERIOD COVERED " & UCase(StartDate.ToShortDateString) & " TO " & UCase(EndDate.ToShortDateString)
                .strMainHeader3 = ""
                .FooterColor = Color.FromName("Black")
                .TitleColor = Color.FromName("Black")
                .DrawBorder = True
                .HorizontalLines = True
                .VerticalLines = True
                .GridColor = Color.WhiteSmoke
                .BorderColor = Color.FromName("WhiteSmoke")
                .HeaderFont = New Font("Arial", 10, FontStyle.Bold)
                .FooterFont = New Font("Arial", 6, FontStyle.Bold)
                .boolGenericReport = False
                .strPrintValues = strPrintDetails
                .VisibleColumns = strColumsVisible
                .DetailColor = Color.Black
                .DetailFont = fntDetailsFont
                .boolPrintTotals = True
            End With

            Dim documentPreview As New PrintPreviewDialog
            documentPreview.Document = rpt
            documentPreview.ShowDialog()

        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Report Generation"
        ShowErrorMessage()
    End Sub

    Private Sub btnInventoryBased_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventoryBased.Click
        BuildRXML(dGrid, "Sales By Products Report")
    End Sub

    Private Sub StockMovements()
        On Error GoTo RaiseErr
        'Cursor = Cursors.WaitCursor

        ''LEFT OUTER JOIN InventoryItems " _
        ''& "ON Sales.ItemCode = InventoryItems.ItemCode WHERE TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        ''& "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "' 

        'dGridStockMovement.Rows.Clear()

        'Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT InventoryItems.ItemCode, " _
        '    & "InventoryItems.GroupName, InventoryType FROM InventoryItems " _
        '    & "GROUP BY ItemCode, InventoryItems.GroupName, InventoryItems.InventoryType ORDER BY ItemCode", cnn)
        'Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        'While objReader.Read

        '    Dim objReadValues As Data.OleDb.OleDbDataReader
        '    Dim dblClosingQty As Double = 0
        '    Dim dblSalesQty As Double = 0
        '    Dim dblTransfersOut As Double = 0
        '    Dim dblDeliveryOut As Double = 0
        '    Dim dblReceivedQty As Double = 0
        '    Dim dblTransfersIn As Double = 0

        '    'Get the closing stock qty
        '    If UCase(objReader(2).ToString) = "SPECIFIC" Then
        '        objCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(ItemCode) FROM SerialNumbers WHERE ItemCode = '" & objReader(0).ToString & "'", cnn)
        '        objReadValues = objCommand.ExecuteReader
        '        If objReadValues.HasRows Then
        '            objReadValues.Read()
        '            If IsNumeric(objReadValues(0).ToString) Then dblClosingQty = CDbl(objReadValues(0).ToString)
        '        End If
        '        objReadValues.Close()
        '    Else
        '        objCommand = New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & objReader(0).ToString & "'", cnn)
        '        objReadValues = objCommand.ExecuteReader
        '        If objReadValues.HasRows Then
        '            objReadValues.Read()
        '            If IsNumeric(objReadValues(0).ToString) Then dblClosingQty = CDbl(objReadValues(0).ToString)
        '        End If
        '        objReadValues.Close()
        '    End If

        '    'Get the sales quantity this includes both cash and debtors

        '    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Quantity) FROM Sales WHERE ItemCode = '" & objReader(0).ToString & "' " _
        '        & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        '        & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "'", cnn)
        '    objReadValues = objCommand.ExecuteReader
        '    If objReadValues.HasRows Then
        '        objReadValues.Read()
        '        If IsNumeric(objReadValues(0).ToString) Then dblSalesQty = CDbl(objReadValues(0).ToString)
        '    End If
        '    objReadValues.Close()

        '    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Quantity) FROM CustomerSales WHERE ItemCode = '" & objReader(0).ToString & "' " _
        '        & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        '        & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "'", cnn)
        '    objReadValues = objCommand.ExecuteReader
        '    If objReadValues.HasRows Then
        '        objReadValues.Read()
        '        If IsNumeric(objReadValues(0).ToString) Then dblSalesQty = dblSalesQty + CDbl(objReadValues(0).ToString)
        '    End If
        '    objReadValues.Close()

        '    'Get the transfers out to branches
        '    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Quantity) from InventoryTransfers WHERE " _
        '        & "ReceivingBranch <> '" & strUserBranch & "' AND ItemCode = '" & objReader(0).ToString & "' " _
        '        & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        '        & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "'", cnn)
        '    objReadValues = objCommand.ExecuteReader
        '    If objReadValues.HasRows Then
        '        objReadValues.Read()
        '        If IsNumeric(objReadValues(0).ToString) Then dblTransfersOut = CDbl(objReadValues(0).ToString)
        '    End If
        '    objReadValues.Close()

        '    'Get the deliveries out

        '    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Quantity) from GatePasses WHERE " _
        '        & "PassType <> 'TRANSFER' AND ItemCode = '" & objReader(0).ToString & "' " _
        '        & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        '        & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "'", cnn)
        '    objReadValues = objCommand.ExecuteReader
        '    If objReadValues.HasRows Then
        '        objReadValues.Read()
        '        If IsNumeric(objReadValues(0).ToString) Then dblDeliveryOut = CDbl(objReadValues(0).ToString)
        '    End If
        '    objReadValues.Close()

        '    'Get the received items quantity
        '    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Quantity) from OrdersReceipt WHERE " _
        '        & "DestinationBranch <> '" & strUserBranch & "' AND ItemCode = '" & objReader(0).ToString & "' " _
        '        & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        '        & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "'", cnn)
        '    objReadValues = objCommand.ExecuteReader
        '    If objReadValues.HasRows Then
        '        objReadValues.Read()
        '        If IsNumeric(objReadValues(0).ToString) Then dblReceivedQty = CDbl(objReadValues(0).ToString)
        '    End If
        '    objReadValues.Close()

        '    'Get the transfers in 
        '    objCommand = New Data.OleDb.OleDbCommand("SELECT SUM(Quantity) from InventoryTransfers WHERE " _
        '        & "ReceivingBranch = '" & strUserBranch & "' AND ItemCode = '" & objReader(0).ToString & "' " _
        '        & "AND TransDate BETWEEN '" & Format(CDate(dpStartFrom.Value), "dd-MMM-yyyy") & "' AND " _
        '        & "'" & Format(CDate(dpEndTo.Value), "dd-MMM-yyyy") & "'", cnn)
        '    objReadValues = objCommand.ExecuteReader
        '    If objReadValues.HasRows Then
        '        objReadValues.Read()
        '        If IsNumeric(objReadValues(0).ToString) Then dblTransfersIn = CDbl(objReadValues(0).ToString)
        '    End If
        '    objReadValues.Close()

        '    Dim dblOpeningStock As Double = (dblClosingQty + dblSalesQty + dblDeliveryOut + dblTransfersOut) - (dblTransfersIn + dblReceivedQty)
        '    dGridStockMovement.Rows.Add(objReader(0), objReader(1), dblClosingQty, dblSalesQty, dblDeliveryOut, dblTransfersOut, dblTransfersIn, dblReceivedQty, dblOpeningStock)

        'End While
        'objReader.Close()
        'Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Stock Movement Report Generation"
        ShowErrorMessage()
    End Sub

    Private Sub btnStockMovement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStockMovement.Click
        BuildRXML(dGridStockMovement, "Sales By Products Report")
    End Sub

End Class