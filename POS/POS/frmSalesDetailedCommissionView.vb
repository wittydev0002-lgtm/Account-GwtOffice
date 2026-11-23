Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons

Public Class frmSalesDetailedCommissionView

    Private Sub LoadCommissionsData(ByVal strRepName As String)
        On Error GoTo RaiseErr

        dGridCommissions.Rows.Clear()

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        Dim strSqlStatement As String = "SELECT SalesMain.InvoiceNumber, SalesMain.SalesRep, " _
            & "SalesMain.Amount as [Sales], SalesMain.ExpensesRate, SalesMain.CommissionRate AS " _
            & "[Commission], SalesMain.ServiceCategory, CONVERT(NVARCHAR, SalesMain.TransDate, 105) as [Date], " _
            & "SalesMain.ExpensesRate FROM SalesMain WHERE SalesMain.TransDate " _
            & "BETWEEN '" & gwt_comm.shortMonthDateFormat(StartDate) & "' AND " _
            & "'" & gwt_comm.shortMonthDateFormat(EndDate) & "' AND SalesRep = '" & strRepName & "' " _
            & "GROUP BY SalesMain.SalesRep, SalesMain.ExpensesRate, SalesMain.Amount, SalesMain.InvoiceNumber, " _
            & "SalesMain.CommissionRate, SalesMain.ServiceCategory, SalesMain.TransDate, SalesMain.ExpensesRate ORDER BY SalesMain.SalesRep"
        objCommand = New Data.OleDb.OleDbCommand(strSqlStatement, cnn)
        Dim objReadBaseValues As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim Cnt As Integer = 0

        While objReadBaseValues.Read

            Dim dblExpensesRate As Double = 0
            Dim dblCommissionRate As Double = 0

            Dim dblSumOfSales As Double = 0
            Dim dblSumOfExpenses As Double = 0
            Dim dblSumAfterPurchases As Double = 0
            Dim dblSumOfCommissions As Double = 0

            'Get the staff sales based on the LinkedDocumentNumber link to the invoice number 
            Dim dblAgentExpenses As Double = 0
            strSqlStatement = "SELECT StaffSales.Payable FROM StaffSales " _
                & "WHERE LinkedDocumentNumber = " & CInt(objReadBaseValues(0).ToString) & " AND SalesAgent = '" & strRepName & "'"
            Dim objCommandStaffSales As New Data.OleDb.OleDbCommand(strSqlStatement, cnn)
            Dim objReadStaffSales As Data.OleDb.OleDbDataReader = objCommandStaffSales.ExecuteReader
            If objReadStaffSales.HasRows Then
                objReadStaffSales.Read()
                If IsNumeric(objReadStaffSales(0).ToString) Then dblAgentExpenses = CDbl(objReadStaffSales(0).ToString)
            End If
            objReadStaffSales.Close()

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

            With dGridCommissions
                .Rows.Add(objReadBaseValues(6), dblSumOfSales, dblAgentExpenses, (dblSumOfSales - dblAgentExpenses), dblSumOfExpenses, (dblSumOfSales - dblAgentExpenses - dblSumOfExpenses), dblSumOfCommissions, objReadBaseValues(5), objReadBaseValues(7), objReadBaseValues(4), objReadBaseValues(0))
            End With

        End While
        objReadBaseValues.Close()

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
                '.Rows(.Rows.Count - 1).Cells(p).Style.BackColor = Color.FromArgb(195, 217, 242)
                '.Rows(.Rows.Count - 1).Cells(p).Style.ForeColor = Color.Black
            Next
            .Rows(.RowCount - 1).Cells(7).Value = " "
            .Rows(.RowCount - 1).Cells(10).Value = "0"
        End With
        AlternateColors()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On sales commissions data preview"
        ShowErrorMessage()
    End Sub

    Private Sub AlternateColors()
        With dGridCommissions
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

    Private Sub frmSalesDetailedCommissionView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = UCase(strSelectedCustomerName)
        LoadCommissionsData(strSelectedCustomerName)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    '    Private Sub btnCorrectService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorrectService.Click
    '        If dGridCommissions.RowCount <= 0 Then Exit Sub
    '        strAgentServiceClass = Nothing
    '        dblAgentServiceCommissionRate = 0
    '        dblAgentServiceExpenseRate = 0
    '        boolAbort = False
    '        Dim f As New frmSalesServiceCorrection
    '        f.ShowDialog()
    '        If boolAbort = True Then Exit Sub

    '        On Error GoTo RaiseErr
    '        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE SalesMain SET ServiceCategory = '" & strAgentServiceClass & "', " _
    '            & "ExpensesRate = " & dblAgentServiceExpenseRate & ", CommissionRate = " & dblAgentServiceCommissionRate & " " _
    '            & "WHERE InvoiceNumber = " & CLng(dGridCommissions.CurrentRow.Cells(10).Value.ToString) & "", cnn)
    '        objCommand.ExecuteNonQuery()
    '        objCommand = New Data.OleDb.OleDbCommand("UPDATE Sales SET ServiceCategory = '" & strAgentServiceClass & "', " _
    '            & "ExpensesRate = " & dblAgentServiceExpenseRate & ", CommissionRate = " & dblAgentServiceCommissionRate & " " _
    '            & "WHERE InvoiceNumber = " & CLng(dGridCommissions.CurrentRow.Cells(10).Value.ToString) & "", cnn)
    '        objCommand.ExecuteNonQuery()
    '        MessageBox.Show("Service category adjusted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        'Reload with the correct values
    '        LoadCommissionsData(strSelectedCustomerName)
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On sales service class change"
    '        ShowErrorMessage()
    '    End Sub

End Class
