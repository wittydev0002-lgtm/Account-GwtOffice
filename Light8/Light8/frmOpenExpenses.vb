Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmOpenExpenses

    Private Sub frmOpenExpenses_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadTransactions()
        ComputeTransactionTotals()
    End Sub

    Private Sub LoadTransactions()
        On Error GoTo RaiseErr
        'Show all the transactions entered so far
        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing

        strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "LedgerAccount, CostCenterCode, Description, VatNumber, AmtBeforeVat, " _
            & "VatAmt, TotalAmt, CashbookAccount, TransactionId FROM Temp_Expenses " _
            & "ORDER BY TransactionDate, TransactionId"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), _
                objReader(4), objReader(5), objReader(6), objReader(7), objReader(8), objReader(9))
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Transactions Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If dGrid.Rows.Count > 0 Then
            'Delete the transaction from the temp table
            If MessageBox.Show("Are you sure you want to delete this entry?", "Confirm Transaction Delete", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim intTransId As Integer = 0
                With dGrid
                    If Not Object.Equals(.CurrentRow.Cells(dGrid.ColumnCount - 1).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(.CurrentRow.Cells(dGrid.ColumnCount - 1).Value.ToString) Then
                            If IsNumeric(.CurrentRow.Cells(dGrid.ColumnCount - 1).Value.ToString) Then
                                intTransId = CInt(.CurrentRow.Cells(dGrid.ColumnCount - 1).Value.ToString)
                                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM Temp_Expenses " _
                                    & "WHERE TransactionId = " & intTransId & "", cnn)
                                objCommand.ExecuteNonQuery()
                                dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
                                ComputeTransactionTotals()
                                MessageBox.Show("Transaction has been deleted successfully", "Process Success", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                                LoadTransactions()
                            End If
                        End If
                    End If
                End With
            End If
        End If
        If dGrid.Rows.Count <= 0 Then
            dGrid.Rows.Add(1)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Transactions Row Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeTransactionTotals()
        On Error GoTo RaiseErr
        Dim dblTotalAmount As Double = 0
        Dim dblTotalTaxes As Double = 0
        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblAmount As Double = 0
            Dim dblTaxes As Double = 0
            If Not Object.Equals(dGrid.Rows(p).Cells(6).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(6).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(6).Value.ToString) Then
                        dblAmount = CDbl(dGrid.Rows(p).Cells(6).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(7).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(7).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(7).Value.ToString) Then
                        dblTaxes = CDbl(dGrid.Rows(p).Cells(7).Value.ToString)
                    End If
                End If
            End If
            dblTotalTaxes = dblTotalTaxes + dblTaxes
            dblTotalAmount = dblTotalAmount + dblAmount
        Next

        lblAmt.Text = Format(dblTotalAmount, "#,##0.00")
        lblVat.Text = Format(dblTotalTaxes, "#,##0.00")
        lblAllTotals.Text = Format((dblTotalAmount + dblTotalTaxes), "#,##0.00")

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Transactions Totals Computation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPost_Click(sender As System.Object, e As System.EventArgs) Handles btnPost.Click
        PostTransactions()
    End Sub

    Private Sub PostTransactions()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        With dGrid

            For p As Integer = 0 To .Rows.Count - 1

                Dim strLedgerAccount As String = Nothing
                Dim intCostCenter As Integer = 0
                Dim strDescription As String = Nothing
                Dim strVatNumber As String = Nothing
                Dim dblVatAmt As Double = 0
                Dim dblAmtBeforeVat As Double = 0
                Dim dblTotalAmt As Double = 0
                Dim intTransId As Integer = 0
                Dim strCashBook As String = Nothing
                Dim strDate As String = Nothing

                If Not Object.Equals(.Rows(p).Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(0).Value.ToString) Then
                        strDate = .Rows(p).Cells(0).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(1).Value.ToString) Then
                        strLedgerAccount = .Rows(p).Cells(1).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(2).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(2).Value.ToString) Then
                            intCostCenter = CInt(.Rows(p).Cells(2).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(3).Value.ToString) Then
                        strDescription = .Rows(p).Cells(3).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString) Then
                        strVatNumber = .Rows(p).Cells(4).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(5).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(5).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(5).Value.ToString) Then
                            dblAmtBeforeVat = CDbl(.Rows(p).Cells(5).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(6).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(6).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(6).Value.ToString) Then
                            dblVatAmt = CDbl(.Rows(p).Cells(6).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(7).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(7).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(7).Value.ToString) Then
                            dblTotalAmt = CDbl(.Rows(p).Cells(7).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(8).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(8).Value.ToString) Then
                        strCashBook = .Rows(p).Cells(8).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(dGrid.ColumnCount - 1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(dGrid.ColumnCount - 1).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(dGrid.ColumnCount - 1).Value.ToString) Then
                            intTransId = CInt(.Rows(p).Cells(dGrid.ColumnCount - 1).Value.ToString)
                        End If
                    End If
                End If

                If Not String.IsNullOrEmpty(strLedgerAccount) Then

                    Dim lngJvEntryNumber As Long = 1
                    Dim objCommand As New Data.OleDb.OleDbCommand("SELECT TransactionId FROM LedgerTransactions ORDER BY TransactionId DESC", cnn)
                    Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        If IsNumeric(objReader(0).ToString) Then
                            lngJvEntryNumber = CLng(objReader(0).ToString) + 1
                        End If
                    End If
                    objReader.Close()

                    Dim intSpecialKey As Integer = gwt_comm.SpecialKey()

                    Dim strEntryType As String = "CREDIT"
                    Dim strSql As String = "INSERT INTO CashbookTransactions (TransactionDate, Amount, Description, ContraAccount, " _
                            & "UserName, UserBranch, TransactionType, AccountNumber, Reference, VatAmount, VatNumber, LinkedProject, SpecialKey) VALUES " _
                            & "('" & gwt_comm.shortMonthDateFormat(CDate(strDate)) & "', " & dblTotalAmt & ", '" & strDescription & "', " _
                            & "'" & strLedgerAccount & "', '" & strUserName & "', '" & strUserBranch & "', '" & strEntryType & "', " _
                            & "'" & strCashBook & "', " & lngJvEntryNumber & ", " & dblVatAmt & ", '" & strVatNumber & "', " _
                            & "" & lngPublicLinkedProjectNumber & ", " & intSpecialKey & ")"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                    If dblVatAmt <> 0 Then
                        'post to the vat control account
                        If String.IsNullOrEmpty(strPublicTaxesAccount) Then
                            MessageBox.Show("The taxes control account has not been setup. This will seriously affect the trial balance", _
                                "Taxes Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            Dim strProcessStatus As String = gwt_comm.LedgerEntry("INSERT", gwt_comm.shortMonthDateFormat(CDate(strDate)),
                                strPublicTaxesAccount, strLedgerAccount, strDescription, dblVatAmt, "DEBIT",
                                lngJvEntryNumber, , , , lngJvEntryNumber, 0, 0, 0, intSpecialKey)
                            If strProcessStatus <> "SUCCESS" Then GoTo RaiseErr
                        End If
                    End If

                    Dim strContraType As String = Nothing
                    If strEntryType = "DEBIT" Then strContraType = "CREDIT" Else strContraType = "DEBIT"

                    strSql = "INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate],[Amount],[TransactionType],[ContraAccount]," _
                        & "[Description],[UserName],[UserBranch],[Reference], [CostCode], [SpecialKey]) VALUES " _
                        & "('" & strLedgerAccount & "', '" & gwt_comm.shortMonthDateFormat(CDate(strDate)) & "', " & dblAmtBeforeVat & ", " _
                        & "'" & strContraType & "', '" & strCashBook & "', '" & strDescription & "', '" & strUserName & "', " _
                        & "'" & strUserBranch & "', " & lngJvEntryNumber & ", " & intCostCenter & ", " & intSpecialKey & ")"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Temp_Expenses WHERE TransactionId = " & intTransId & "", cnn)
                    objCommand.ExecuteNonQuery()

                End If

            Next

        End With

        MessageBox.Show("Transactions have been posted successfully to the cashbooks", "Process Success", _
            MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadTransactions()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Cashbook Transactions Post"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class