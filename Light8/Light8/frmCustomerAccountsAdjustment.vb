Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCustomerAccountsAdjustment

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmCustomerAccountsAdjustment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadTransactions()
    End Sub

    Private Sub LoadTransactions()
        On Error GoTo RaiseErr

        'Get the customer details first
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountName +': '+ AccountNumber FROM " _
            & "Customers WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then lblCustomerNames.Text = UCase(objReader(0).ToString)
        End If
        objReader.Close()

        Dim strSql As String = Nothing

        If UCase(CommonLibrary.Commons.strTaxComputationType) = "INCLUSIVE" Then
            strSql = "SELECT CONVERT(NVARCHAR, TransDate, 105) as [Date], InvoiceNumber, " _
                & "CAST(SUM((SalesPrice * Quantity) - DiscountAllowed) AS DECIMAL (30,2)) as [Paid] " _
                & "FROM CustomerSales WHERE CustomerId = '" & strSelectedAccount & "' " _
                & "GROUP BY TransDate, InvoiceNumber ORDER BY TransDate"
        Else
            strSql = "SELECT CONVERT(NVARCHAR, TransDate, 105) as [Date], InvoiceNumber, " _
                & "CAST(SUM((SalesPrice * Quantity) - DiscountAllowed + Taxes) AS DECIMAL (30,2)) as [Paid] " _
                & "FROM CustomerSales WHERE CustomerId = '" & strSelectedAccount & "' " _
                & "GROUP BY TransDate, InvoiceNumber ORDER BY TransDate"
        End If

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        Dim arrTransactions As New ArrayList

        While objReader.Read
            Dim strLine As String = Nothing
            For n As Integer = 0 To objReader.FieldCount - 1
                If n = 2 Then
                    strLine = strLine & ";POSTED INVOICE;0;" & objReader(n).ToString
                Else
                    strLine = strLine & ";" & objReader(n).ToString
                End If
            Next
            strLine = Mid(strLine, 2, (strLine.Length - 1)) & ";"
            arrTransactions.Add(strLine & ";INVOICE")
        End While
        objReader.Close()
        'Get the payments
        strSql = "SELECT CONVERT(NVARCHAR, TransactionDate, 105) AS [Dte], [ReferenceNumber], " _
            & "[Description], CAST(Amount AS DECIMAL (30,2)) AS [Amt] FROM CustomerTransactions " _
            & "WHERE AccountNumber = '" & strSelectedAccount & "' ORDER BY TransactionDate"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        Dim strLastPaymentAmount As String = "0.00"
        Dim strLastPaymentDate As String = Nothing
        While objReader.Read
            arrTransactions.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" _
                & objReader(2).ToString & ";1;;" & objReader(3).ToString & ";PAYMENT")
            If IsDate(objReader(0).ToString) Then strLastPaymentDate = Format(CDate(objReader(0).ToString), "dd-MM-yyyy")
            If IsNumeric(objReader(3).ToString) Then strLastPaymentAmount = CStr(Format(CDbl(objReader(3).ToString), "##0.00"))
        End While
        objReader.Close()

        'Get the credit note entries
        strSql = "SELECT CONVERT(NVARCHAR, CreditNotesMain.TransDate, 105) as [Date], CreditNoteEntries.NoteNumber, " _
            & "CreditNoteEntries.Description, SUM(CreditNoteEntries.Quantity) as [Qty], " _
            & "CAST(SUM((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity) - 0) AS DECIMAL (30,2)) as [Paid] " _
            & "FROM CreditNoteEntries, CreditNotesMain WHERE CreditNoteEntries.NoteNumber = CreditNotesMain.NoteNumber " _
            & "AND CreditNotesMain.AccountId = '" & strSelectedAccount & "' AND ((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity) - 0) > 0 " _
            & "GROUP BY CreditNotesMain.TransDate, CreditNoteEntries.NoteNumber, CreditNoteEntries.Description " _
            & "ORDER BY CreditNotesMain.TransDate"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            arrTransactions.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" _
                & objReader(2).ToString & ";" & objReader(3).ToString & ";;" & objReader(4).ToString & ";CREDIT NOTE")
        End While
        objReader.Close()

        If arrTransactions.Count > 0 Then arrTransactions.Sort()

        Dim dblDebitTotal As Double = 0
        Dim dblCreditTotal As Double = 0
        Dim dblBalance As Double = 0
        dGrid.Rows.Clear()
        For i As Integer = 0 To arrTransactions.Count - 1
            dGrid.Rows.Add(1)
            Dim strValues() As String = Split(arrTransactions(i), ";")
            For n As Integer = 0 To strValues.Length - 1
                With dGrid
                    .Rows(.Rows.Count - 1).Cells(n).Value = strValues(n)
                End With
            Next n
            If IsNumeric(strValues(strValues.Length - 3)) Then
                dblDebitTotal = dblDebitTotal + CDbl(strValues(strValues.Length - 3))
            End If
            If IsNumeric(strValues(strValues.Length - 2)) Then
                dblCreditTotal = dblCreditTotal + CDbl(strValues(strValues.Length - 2))
            End If
        Next
        dblBalance = dblDebitTotal - dblCreditTotal

        'Add the totals and balance line

        'dGrid.Rows.Add("", "", "TOTALS", "", CStr(Format(dblDebitTotal, "##0.00")), CStr(Format(dblCreditTotal, "##0.00")), "")
        'dGrid.Rows.Add("", "", "BALANCE", "", CStr(Format(dblBalance, "##0.00")), "", "")

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Transactions Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellClick
        On Error GoTo RaiseErr
        If dGrid.CurrentCell.ColumnIndex = 7 Then
            Dim strReference As String = Nothing
            Dim strType As String = Nothing
            Dim dblDebit As Double = 0
            Dim dblCredit As Double = 0
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(1).Value), "")) Then
                strReference = dGrid.CurrentRow.Cells(1).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(6).Value), "")) Then
                strType = dGrid.CurrentRow.Cells(6).Value.ToString
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(4).Value), "")) Then
                If IsNumeric(dGrid.CurrentRow.Cells(4).Value.ToString) Then dblDebit = CDbl(dGrid.CurrentRow.Cells(4).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(5).Value), "")) Then
                If IsNumeric(dGrid.CurrentRow.Cells(5).Value.ToString) Then dblCredit = CDbl(dGrid.CurrentRow.Cells(5).Value.ToString)
            End If

            If MessageBox.Show("Are you sure you want to proceed and delete this entry?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                Dim objCommand As Data.OleDb.OleDbCommand
                If UCase(strType) = "INVOICE" Then
                    DeleteInvoice(strReference, dblDebit)
                Else
                    'Delete from customer transactions
                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerTransactions WHERE " _
                        & "ReferenceNumber = " & strReference & " AND Amount = " & dblCredit & "", cnn)
                    objCommand.ExecuteNonQuery()
                    'Delete from ledger control account
                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE " _
                        & "Reference = " & strReference & " AND AccountNumber = '" & CommonLibrary.Commons.strPublicDebtorsAccount & "' " _
                        & "AND Amount = " & dblCredit & "", cnn)
                    objCommand.ExecuteNonQuery()
                End If
                MessageBox.Show("Transaction has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                Exit Sub
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Transactions delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub DeleteInvoice(ByVal ReferenceNumber As Integer, ByVal Amount As Double)
        On Error GoTo RaiseErr

        boolAbort = False
        Cursor = Cursors.WaitCursor

        'Get the original sales data
        Dim strSql As String = "SELECT [InvoiceNumber],[CustomerId],[ItemCode],[Description],[Quantity]," _
            & "[DiscountAllowed],[Taxes],[TransType],[SalesPrice],[TransDate],[ProductType],[SerialNumbers]," _
            & "[OriginalInvoice],[SalesRep],[UserName] FROM CustomerSales WHERE InvoiceNumber = " & ReferenceNumber & ""
        Dim objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommandReverse.ExecuteReader
        While objReader.Read
            'Add the items back to the inventory
            If Not String.IsNullOrEmpty(objReader("SerialNumbers").ToString) Then
                Dim lngComma As Long = InStr(1, objReader("SerialNumbers").ToString, ",", 1)
                If lngComma > 0 Then
                    Dim strSeries() As String = Split(objReader("SerialNumbers").ToString, ",")
                    For n As Integer = 0 To strSeries.Length - 1
                        If Not String.IsNullOrEmpty(strSeries(n)) Then
                            strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber) VALUES ('" & strSeries(n) & "', " _
                                & "'" & objReader("SerialNumbers").ToString & "')"
                            objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommandReverse.ExecuteNonQuery()
                        End If
                    Next
                Else
                    strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber) VALUES ('" & objReader("ItemCode").ToString & "', " _
                        & "'" & objReader("SerialNumbers").ToString & "')"
                    objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommandReverse.ExecuteNonQuery()
                End If
            End If
            'Update the inventory table
            strSql = "UPDATE InventoryItems SET InventoryItems.Quantity = (InventoryItems.Quantity + " & CInt(objReader("Quantity").ToString) & ") " _
                & "WHERE ItemCode = '" & objReader("ItemCode").ToString & "'"
            objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommandReverse.ExecuteNonQuery()
        End While

        Dim objDelete As New Data.OleDb.OleDbCommand("DELETE FROM CustomerSalesMain WHERE InvoiceNumber = " & ReferenceNumber, cnn)
        objDelete.ExecuteNonQuery()
        objDelete = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSales WHERE InvoiceNumber = " & ReferenceNumber, cnn)
        objDelete.ExecuteNonQuery()
        objDelete = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE FolioReference = '" & _
            ReferenceNumber & "' AND AccountNumber = '" & CommonLibrary.Commons.strPublicTaxesAccount & "'", cnn)
        objDelete.ExecuteNonQuery()
        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Transactions delete"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
