Public Class frmProcessTransactions

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmProcessTransactions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If TableExists("RunFile") = False Then CreateRunTable()
        LoadDirectors()
        optAllPending.Checked = True
    End Sub

    Private Sub LoadDirectors()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql = "SELECT LastName +' '+FirstName +' '+ OtherNames AS [Given Names], CONVERT(NVARCHAR, TransactionId) AS " _
            & "[Id] FROM EmployeeMaster ORDER BY LastName"
        Dim dbCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As OleDb.OleDbDataReader = dbCommand.ExecuteReader()
        dGrid.Rows.Clear()
        While objReader.Read
            Dim strDirector As String = Nothing
            Dim strId As String = Nothing
            If Not IsDBNull(objReader(0).ToString) Then strDirector = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strId = objReader(1).ToString
            dGrid.Rows.Add(False, strDirector, strId)
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on directors details load"
        ShowErrorMessage()
    End Sub

    Private Sub optAllPending_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optAllPending.CheckedChanged
        If optAllPending.Checked = True Then
            pnlSelection.Enabled = False
        Else
            pnlSelection.Enabled = True
        End If
    End Sub

    Private Sub optDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optDate.CheckedChanged
        If optDate.Checked = True Then
            pnlDates.Enabled = True
            pnlDirectors.Enabled = False
        Else
            pnlDates.Enabled = False
            pnlDirectors.Enabled = True
        End If
    End Sub

    Private Sub btnProcess_Click(sender As System.Object, e As System.EventArgs) Handles btnProcess.Click

        Dim strProcessingDate As String = Format(Now, "dd-MMM-yyyy")

        On Error GoTo RaiseErr

        arrSelectedItems = New ArrayList

        Dim arrOutput As New ArrayList
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As OleDb.OleDbDataReader

        If optAllPending.Checked = True Then
            arrSelectedItems = AllPaymentsArray()
        Else
            If optDirectors.Checked = True Then
                For i As Integer = 0 To dGrid.Rows.Count - 1
                    If dGrid.Rows(i).Cells(0).Value = True Then
                        arrSelectedItems.Add(dGrid.Rows(i).Cells(2).Value.ToString)
                    End If
                Next
            Else
                'Print selective date
                arrSelectedItems = DatePaymentsArray()
            End If
        End If

        pb1.Visible = True
        pb1.Maximum = arrSelectedItems.Count + 5
        pb1.Value = 0

        'Before delete copy all the transactions to the payments history
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO PaymentsHistory (DirectorId, CodeId, " _
                & "Description, Amount, PaymentDate, ColumnSide, OriginalTransDate, GrossUp, BoardTax, PAYE, " _
                & "AidsLevy, Deductions) SELECT DirectorId, CodeId, " _
                & "Description, Amount, PaymentDate, ColumnSide, OriginalTransDate, GrossUp, BoardTax, PAYE, " _
                & "AidsLevy, Deductions FROM RunFile", cnn)
        Dim objReadRunFile As OleDb.OleDbDataReader = objCommand.ExecuteReader()

        'While objReadRunFile.Read
        '    Dim strSqlInsert As String = "INSERT INTO PaymentsHistory (DirectorId, CodeId, " _
        '        & "Description, Amount, PaymentDate, ColumnSide, OriginalTransDate, GrossUp, BoardTax, PAYE, " _
        '        & "AidsLevy, Deductions) VALUES (" & objReadRunFile(0).ToString & ", " & objReadRunFile(1).ToString & ", " _
        '        & "'" & objReadRunFile(2).ToString & "', " & objReadRunFile(3).ToString & ", '" & objReadRunFile(4).ToString & "', " _
        '        & "" & objReadRunFile(5).ToString & ", '" & objReadRunFile(6).ToString & "', " _
        '        & "" & objReadRunFile(7).ToString & ", " & objReadRunFile(8).ToString & ", " & objReadRunFile(9).ToString & ", " _
        '        & "" & objReadRunFile(10).ToString & ", " & objReadRunFile(11).ToString & ")"
        '    objCommand = New Data.OleDb.OleDbCommand(strSqlInsert, cnn)
        '    objCommand.ExecuteNonQuery()
        'End While
        'objReadRunFile.Close()

        'Proceed and delete the transactions there after

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM RunFile", cnn)
        objCommand.ExecuteNonQuery()

        For i As Integer = 0 To arrSelectedItems.Count - 1

            Dim dblTotalEarnings As Double = 0
            Dim dblTotalDeductions As Double = 0
            Dim dblCurrentTaxableIncome As Double = 0
            Dim dblCurrentTaxableTwenty As Double = 0
            Dim dblCurrentTax As Double = 0
            Dim dblCurrentAidsLevy As Double = 0

            arrOutput = New ArrayList

            'Initialize public tax variables

            dblActiveEmployeePaye = 0
            dblActiveEmployeeAidsLevy = 0

            'If CDbl(arrSelectedItems.Item(i)) = 11 Then
            '    MsgBox("stop")
            'End If

            'Get the grossing factors
            Dim dblTestTaxValue As Double = GrossUpFactor(arrSelectedItems.Item(i))
            'Dim dblTaxRatePlusLevy As Double = dblEmployeeTaxRate + (dblEmployeeTaxRate * 0.03)


            Dim dblGrossedUp As Double = GrossAmount(dblTestTaxValue) '(dblTestTaxValue - dblBaseCredit) / (1 - dblTaxRatePlusLevy)

            'All the earnings will be grossed up in the ratio of their contribution to gross
            Dim dblGrossingFactor As Double = dblGrossedUp / dblTestTaxValue ' (dblGrossedUp - dblTestTaxValue) / dblTestTaxValue
            If dblGrossingFactor <= 0 Then dblGrossingFactor = 1

            'Get the record of all the earning and deductions for that director
            Dim strSql As String = Nothing
            If optAllPending.Checked = True Then
                strSql = "SELECT SUM(Payments.Amount), Payments.PayCode, " _
                    & "PaymentCodes.Description, PaymentCodes.PayType, PaymentCodes.TaxType, Payments.TransDate FROM Payments " _
                    & "LEFT OUTER JOIN PaymentCodes ON PaymentCodes.CodeNo = Payments.PayCode WHERE " _
                    & "Payments.DirectorId = " & arrSelectedItems.Item(i) & " AND Payments.Status = 'PENDING' " _
                    & "GROUP BY Payments.Amount, Payments.PayCode, PaymentCodes.Description, PaymentCodes.PayType, " _
                    & "PaymentCodes.TaxType, Payments.TransDate"
            Else
                If optDate.Checked = True Then
                    strSql = "SELECT SUM(Payments.Amount), Payments.PayCode, " _
                        & "PaymentCodes.Description, PaymentCodes.PayType, PaymentCodes.TaxType, Payments.TransDate FROM Payments " _
                        & "LEFT OUTER JOIN PaymentCodes ON PaymentCodes.CodeNo = Payments.PayCode WHERE " _
                        & "Payments.DirectorId = " & arrSelectedItems.Item(i) & " AND Payments.Status = 'PENDING' " _
                        & "TransDate BETWEEN '" & Format(CDate(dpStartDate.Value), "dd-MMM-yyyy") & "' AND " _
                        & "'" & Format(CDate(dpEndDate.Value), "dd-MMM-yyyy") & "' " _
                        & "GROUP BY Payments.Amount, Payments.PayCode, PaymentCodes.Description, PaymentCodes.PayType, " _
                        & "PaymentCodes.TaxType, Payments.TransDate"
                Else
                    strSql = "SELECT SUM(Payments.Amount), Payments.PayCode, " _
                    & "PaymentCodes.Description, PaymentCodes.PayType, PaymentCodes.TaxType, Payments.TransDate, PaymentCodes.GrossupStatus FROM Payments " _
                    & "LEFT OUTER JOIN PaymentCodes ON PaymentCodes.CodeNo = Payments.PayCode WHERE " _
                    & "Payments.DirectorId = " & arrSelectedItems.Item(i) & " AND Payments.Status = 'PENDING' " _
                    & "GROUP BY Payments.Amount, Payments.PayCode, PaymentCodes.Description, PaymentCodes.PayType, " _
                    & "PaymentCodes.TaxType, Payments.TransDate, PaymentCodes.GrossupStatus"
                End If
            End If

            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader

            While objReader.Read

                Dim strColumn As String = Nothing
                Dim dblNewGrossedUpAmount As Double = 0 'CDbl(objReader(0).ToString) * (1 + dblGrossingFactor)
                Dim dblBoardTax As Double = 0
                Dim dblPaye As Double = 0
                Dim dblAidsLevy As Double = 0
                Dim dblDeduction As Double = 0

                Dim dblCheckAmount As Double = 0

                If IsNumeric(objReader(0).ToString) Then

                    'Accumulate earnings and deductions
                    If UCase(objReader(3).ToString) = "EARNING" Or UCase(objReader(3).ToString) = "BENEFIT" Then
                        If UCase(objReader(4).ToString) = "YNM" Or UCase(objReader(4).ToString) = "Y20" Then
                            If dblGrossingFactor = 1 Then
                                dblNewGrossedUpAmount = CDbl(objReader(0).ToString)
                            Else
                                dblNewGrossedUpAmount = CDbl(objReader(0).ToString) * dblGrossingFactor '/ (1 - (dblEmployeeTaxRate + (dblEmployeeTaxRate * 0.03)))
                            End If

                            Dim dblProportionFactor As Double = CDbl(objReader(0).ToString) / dblTestTaxValue

                            '**** COMMENTED OUT ON ADJUSTMENT *************
                            dblPaye = dblActiveEmployeePaye * dblProportionFactor ' dblNewGrossedUpAmount * dblEmployeeTaxRate
                            dblAidsLevy = dblActiveEmployeeAidsLevy * dblProportionFactor  'dblPaye * 0.03

                            dblTotalEarnings = dblTotalEarnings + dblNewGrossedUpAmount 'CDbl(objReader(0).ToString)
                            strColumn = "2"
                        Else
                            dblNewGrossedUpAmount = CDbl(objReader(0).ToString)
                        End If

                        'If UCase(objReader(4).ToString) = "Y20" Then
                        '    dblNewGrossedUpAmount = CDbl(objReader(0).ToString) / (1 - 0.2)
                        '    dblBoardTax = dblNewGrossedUpAmount * 0.2
                        'End If
                        'If IsNumeric(objReader(0).ToString) Then
                        'If CDbl(objReader(0).ToString) = 1000 Then
                        'MsgBox("Test")
                        'End If
                        'End If

                        'If Math.Round(dblNewGrossedUpAmount, 0) = 1564 Then
                        'MsgBox("test")
                        'End If

                        dblNewGrossedUpAmount = Math.Round(dblNewGrossedUpAmount, 0)

                        dblPaye = Math.Round(dblPaye, 0)
                        dblAidsLevy = Math.Round(dblAidsLevy, 0)
                        dblBoardTax = Math.Round(dblBoardTax, 0)
                        dblCheckAmount = dblNewGrossedUpAmount - (dblBoardTax + dblPaye + dblAidsLevy)
                        dblCheckAmount = Math.Round(dblCheckAmount, 0)


                        If dblCheckAmount <> CDbl(objReader(0).ToString) Then
                            Dim dblDiff As Double = dblCheckAmount - CDbl(objReader(0).ToString)
                            dblPaye = dblPaye + dblDiff
                        End If


                    Else
                        If UCase(objReader(3).ToString) = "DEDUCTION" Then

                            'Check that the deduction is to be grossed up or not here before assigning value
                            If IsGroossUpCode(CInt(objReader(1).ToString)) = True Then
                                dblDeduction = CDbl(objReader(0).ToString) / (1 - (dblEmployeeTaxRate + (dblEmployeeTaxRate * 0.03)))
                            Else
                                dblDeduction = CDbl(objReader(0).ToString)
                            End If

                            dblTotalDeductions = dblTotalDeductions + dblDeduction 'CDbl(objReader(0).ToString)  'CDbl(objReader(0).ToString)
                            strColumn = "1"

                        End If
                    End If

                    If dblPaye < 0 Then dblPaye = 0
                    If dblAidsLevy < 0 Then dblAidsLevy = 0

                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO RunFile " _
                    & "(DirectorId, CodeId, Description, Amount, PaymentDate, ColumnSide, OriginalTransDate, " _
                    & "GrossUp, BoardTax, PAYE, AidsLevy, Deductions) VALUES " _
                    & "(" & arrSelectedItems.Item(i) & ", " & objReader("PayCode").ToString & ", " _
                    & "'" & objReader("Description").ToString & "', " & objReader(0).ToString & ", " _
                    & "'" & Format(Now, "dd-MMM-yyyy") & "', '" & strColumn & "', '" & objReader("TransDate").ToString & "', " _
                    & "" & dblNewGrossedUpAmount & ", " & dblBoardTax & ", " & dblPaye & ", " & dblAidsLevy & ", " & dblDeduction & ")", cnn)
                    objCommand.ExecuteNonQuery()

                End If

            End While
            objReader.Close()

            ''dblCurrentTax = TaxTables(dblCurrentTaxableIncome)
            ''dblCurrentTax = dblCurrentTax + (dblCurrentTaxableTwenty * 0.2)
            ''dblCurrentAidsLevy = dblCurrentTax * 0.05

            ''dblTotalDeductions = dblTotalDeductions + (dblCurrentTax + dblCurrentAidsLevy)
            ''Dim dblNetSalary As Double = dblTotalEarnings - dblTotalDeductions

            If optAllPending.Checked = True Then
                objCommand = New Data.OleDb.OleDbCommand("UPDATE Payments SET " _
                    & "Status = 'PROCESSED', PaymentDate = '" & Format(Now, "dd-MMM-yyyy") & "' " _
                    & "WHERE DirectorId = " & arrSelectedItems.Item(i) & "", cnn)
                objCommand.ExecuteNonQuery()
            Else
                If optDate.Checked = True Then
                    objCommand = New Data.OleDb.OleDbCommand("UPDATE Payments SET " _
                        & "Status = 'PROCESSED', PaymentDate = '" & Format(Now, "dd-MMM-yyyy") & "' " _
                        & "WHERE DirectorId = " & arrSelectedItems.Item(i) & " AND TransDate BETWEEN " _
                        & "'" & Format(CDate(dpStartDate.Value), "dd-MMM-yyyy") & "' AND " _
                        & "'" & Format(CDate(dpEndDate.Value), "dd-MMM-yyyy") & "'", cnn)
                    objCommand.ExecuteNonQuery()
                Else
                    objCommand = New Data.OleDb.OleDbCommand("UPDATE Payments SET " _
                    & "Status = 'PROCESSED', PaymentDate = '" & Format(Now, "dd-MMM-yyyy") & "' " _
                    & "WHERE DirectorId = " & arrSelectedItems.Item(i) & "", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If

            pb1.Value = pb1.Value + 1

        Next

        pb1.Value = pb1.Maximum

        'Write the details to the processed records

        MessageBox.Show("Transactions Processed Successfully", "Process Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on payment processing"
        ShowErrorMessage()
    End Sub

    Private Function AllPaymentsArray() As ArrayList
        Dim arrReturn As New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Distinct(TransactionId) FROM EmployeeMaster ORDER BY TransactionId", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            arrReturn.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on payment processing details fetch"
        ShowErrorMessage()
    End Function

    Private Function DatePaymentsArray() As ArrayList
        Dim arrReturn As New ArrayList
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Distinct(DirectorId) FROM Payments " _
            & "WHERE Status = 'PENDING' AND TransDate BETWEEN '" & Format(CDate(dpStartDate.Value), "dd-MMM-yyyy") & "' " _
            & "AND '" & Format(CDate(dpEndDate.Value), "dd-MMM-yyyy") & "' ORDER BY DirectorId", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            arrReturn.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on payment processing details fetch"
        ShowErrorMessage()
    End Function

End Class
