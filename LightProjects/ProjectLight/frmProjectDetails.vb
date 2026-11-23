Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmProjectDetails

    Dim boolSaveOnly As Boolean

    Private Sub frmConstructionJobsClaimSetup_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        boolCreditNoteCalledFromProjectClaims = False
        strPublicActiveCashbook = Nothing
    End Sub

    Private Sub frmConstructionJobsClaimSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Chande the color settings for invoices to light orange
        LoadCashbooks()

        LoadCallings()
        dGridContractors.Columns(0).DefaultCellStyle.BackColor = Color.WhiteSmoke
        LoadCustomers()
        LoadEmployees()
        If boolEditStatus = False Then
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("ProjectsNumber"))
        Else
            txtReference.Text = intSelectedProjectNumber
            LoadSelectedTransactions()
            LoadCashbookTransactions()
            'LoadClaims(intSelectedProjectNumber)
        End If
    End Sub

    Private Sub LoadSelectedTransactions()
        On Error GoTo RaiseErr

        'Load the main details
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM ProjectsMain WHERE ContractNumber = " & intSelectedProjectNumber & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("ContractName").ToString) Then txtContractName.Text = objReader("ContractName").ToString
            If Not IsDBNull(objReader("CustomerNumber").ToString) Then txtCustomerNumber.Text = objReader("CustomerNumber").ToString
            If IsNumeric(objReader("InitialValue").ToString) Then txtContractValue.Text = Format(CDbl(objReader("InitialValue").ToString), "##0.00")
            If IsNumeric(objReader("RevisedValue").ToString) Then txtRevisedValue.Text = Format(CDbl(objReader("RevisedValue").ToString), "##0.00")
            If IsDate(objReader("TakeOnDate").ToString) Then dpTakeonDate.Value = objReader("TakeOnDate").ToString
            If Not IsDBNull(objReader("Owner").ToString) Then cboPersonnel.Text = objReader("Owner").ToString
            txtReference.Text = intSelectedProjectNumber
            'Get the customer name
            objCommand = New Data.OleDb.OleDbCommand("SELECT AccountName FROM Customers WHERE AccountNumber = '" & objReader("CustomerNumber").ToString & "'", cnn)
            Dim objCustomer As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objCustomer.HasRows Then
                objCustomer.Read()
                If Not IsDBNull(objCustomer(0).ToString) Then
                    cboClient.Text = UCase(objCustomer(0).ToString)
                End If
            End If
            objCustomer.Close()
        End If
        objReader.Close()

        'Disable the customer details
        cboClient.Enabled = False : txtCustomerNumber.Enabled = False

        'Load the callings
        objCommand = New Data.OleDb.OleDbCommand("SELECT [ConsultantCalling],[ConsultantName],[ContactPerson],[Telephone]," _
            & "[FaxNumber],[Cellphone],[EmailAddress] FROM ProjectsConsultants WHERE ContractNumber = " & intSelectedProjectNumber & " " _
            & "ORDER BY ConsultantCalling", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            For i As Integer = 0 To dGridContractors.Rows.Count - 1
                Dim strCalling As String = Nothing
                If Not (Object.Equals(Convert.ToString(dGridContractors.Rows(i).Cells(0).Value), "")) Then
                    strCalling = dGridContractors.Rows(i).Cells(0).Value.ToString
                End If
                If Not IsDBNull(objReader(0).ToString) Then
                    If UCase(strCalling) = UCase(objReader(0).ToString) Then
                        dGridContractors.Rows(i).Cells(1).Value = objReader("ConsultantName")
                        dGridContractors.Rows(i).Cells(2).Value = objReader("ContactPerson")
                        dGridContractors.Rows(i).Cells(3).Value = objReader("Telephone")
                        dGridContractors.Rows(i).Cells(4).Value = objReader("FaxNumber")
                        dGridContractors.Rows(i).Cells(5).Value = objReader("Cellphone")
                        dGridContractors.Rows(i).Cells(6).Value = objReader("EmailAddress")
                        Exit For
                    End If
                End If
            Next
        End While
        objReader.Close()

        'Load the transactions
        'LoadProjectTransactions(intSelectedProjectNumber)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On project details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadEmployees()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames " _
            & "AS [EmployeeDetails] FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        cboPersonnel.Items.Clear()
        cboPersonnel.Items.Add("--- NONE ---")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboPersonnel.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Personnel Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    'Private Sub dGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If dGrid.Rows.Count > 0 Then
    '        Dim f As Form
    '        Dim objCommand As Data.OleDb.OleDbCommand
    '        Dim objReader As Data.OleDb.OleDbDataReader
    '        Select Case dGrid.CurrentCell.ColumnIndex
    '            Case Is = 0
    '                CurrentActiveInvoiceNumber = 0
    '                boolEditStatus = False
    '                boolAbort = False
    '                f = New frmInvoice
    '                f.ShowDialog()
    '                If (CurrentActiveInvoiceNumber - 1) <= 0 Then Exit Sub
    '                objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
    '                    & "(Amount - Taxes) AS AmtBeforeTax, Amount as [AmtAfterTax] FROM CustomerSalesMain WHERE " _
    '                    & "InvoiceNumber = " & (CurrentActiveInvoiceNumber - 1) & "", cnn)
    '                objReader = objCommand.ExecuteReader
    '                If objReader.HasRows Then
    '                    objReader.Read()
    '                    dGrid.CurrentRow.Cells(3).Value = CurrentActiveInvoiceNumber - 1
    '                    If Not IsDBNull(objReader(0).ToString) Then dGrid.CurrentRow.Cells(4).Value = objReader(0).ToString
    '                    If IsNumeric(objReader(1).ToString) Then dGrid.CurrentRow.Cells(5).Value = Format(CDbl(objReader(1).ToString), "##0.00")
    '                    If IsNumeric(objReader(2).ToString) Then dGrid.CurrentRow.Cells(6).Value = Format(CDbl(objReader(2).ToString), "##0.00")
    '                End If
    '                objReader.Close()

    '            Case Is = 1
    '                Cursor = Cursors.WaitCursor
    '                If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(3).Value), "")) Then
    '                    If IsNumeric(dGrid.CurrentRow.Cells(3).Value.ToString) Then
    '                        boolEditStatusTwo = True
    '                        boolLoadedFromCustomerForm = False
    '                        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(3).Value.ToString)
    '                        f = New frmInvoice
    '                        f.ShowDialog()
    '                        objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
    '                            & "(Amount - Taxes) AS AmtBeforeTax, Amount as [AmtAfterTax] FROM CustomerSalesMain WHERE " _
    '                            & "InvoiceNumber = " & intSelectedTransaction & "", cnn)
    '                        objReader = objCommand.ExecuteReader
    '                        If objReader.HasRows Then
    '                            objReader.Read()
    '                            dGrid.CurrentRow.Cells(3).Value = intSelectedTransaction
    '                            If Not IsDBNull(objReader(0).ToString) Then dGrid.CurrentRow.Cells(4).Value = objReader(0).ToString
    '                            If IsNumeric(objReader(1).ToString) Then dGrid.CurrentRow.Cells(5).Value = Format(CDbl(objReader(1).ToString), "##0.00")
    '                            If IsNumeric(objReader(2).ToString) Then dGrid.CurrentRow.Cells(6).Value = Format(CDbl(objReader(2).ToString), "##0.00")
    '                        End If
    '                        objReader.Close()
    '                    End If
    '                End If
    '                Cursor = Cursors.Default

    '            Case Is = 2
    '                If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(3).Value), "")) Then
    '                    If IsNumeric(dGrid.CurrentRow.Cells(3).Value.ToString) Then
    '                        boolEditStatusTwo = True
    '                        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(3).Value.ToString)
    '                        If MessageBox.Show("Are you sure you want to delete this Invoice? All invoice items will be sent back to stores", MsgBoxStyle.YesNo, "Confirm Invoice Delete") = MsgBoxResult.Yes Then
    '                            Cursor = Cursors.WaitCursor
    '                            'Reverse the items back to the stores

    '                            'Get the original sales data
    '                            Dim strSql As String = "SELECT [InvoiceNumber],[CustomerId],[ItemCode],[Description],[Quantity]," _
    '                                & "[DiscountAllowed],[Taxes],[TransType],[SalesPrice],[TransDate],[ProductType],[SerialNumbers]," _
    '                                & "[OriginalInvoice],[SalesRep],[UserName] FROM CustomerSales WHERE InvoiceNumber = " & intSelectedTransaction & ""
    '                            Dim objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
    '                            objReader = objCommandReverse.ExecuteReader
    '                            While objReader.Read
    '                                'Add the items back to the inventory
    '                                If Not String.IsNullOrEmpty(objReader("SerialNumbers").ToString) Then
    '                                    Dim lngComma As Long = InStr(1, objReader("SerialNumbers").ToString, ",", 1)
    '                                    If lngComma > 0 Then
    '                                        Dim strSeries() As String = Split(objReader("SerialNumbers").ToString, ",")
    '                                        For n As Integer = 0 To strSeries.Length - 1
    '                                            If Not String.IsNullOrEmpty(strSeries(n)) Then
    '                                                strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber) VALUES ('" & strSeries(n) & "', " _
    '                                                    & "'" & objReader("SerialNumbers").ToString & "')"
    '                                                objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
    '                                                objCommandReverse.ExecuteNonQuery()
    '                                            End If
    '                                        Next
    '                                    Else
    '                                        strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber) VALUES ('" & objReader("ItemCode").ToString & "', " _
    '                                            & "'" & objReader("SerialNumbers").ToString & "')"
    '                                        objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
    '                                        objCommandReverse.ExecuteNonQuery()
    '                                    End If
    '                                End If
    '                                'Update the inventory table
    '                                strSql = "UPDATE InventoryItems SET InventoryItems.Quantity = (InventoryItems.Quantity + " & CInt(objReader("Quantity").ToString) & ") " _
    '                                    & "WHERE ItemCode = '" & objReader("ItemCode").ToString & "'"
    '                                objCommandReverse = New Data.OleDb.OleDbCommand(strSql, cnn)
    '                                objCommandReverse.ExecuteNonQuery()
    '                            End While

    '                            Dim objDelete As New Data.OleDb.OleDbCommand("DELETE FROM CustomerSalesMain WHERE InvoiceNumber = " & intSelectedTransaction, cnn)
    '                            objDelete.ExecuteNonQuery()
    '                            objDelete = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSales WHERE InvoiceNumber = " & intSelectedTransaction, cnn)
    '                            objDelete.ExecuteNonQuery()
    '                            objDelete = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE FolioReference = '" & intSelectedTransaction & "' AND AccountNumber = '" & strPublicTaxesAccount & "'", cnn)
    '                            objDelete.ExecuteNonQuery()
    '                            LoadProjectTransactions(intSelectedProjectNumber)
    '                            MessageBox.Show("Invoice deleted successfully !!!", MsgBoxStyle.Information, "Invoice Delete Success")
    '                            Cursor = Cursors.Default
    '                        End If
    '                    End If
    '                End If

    '            Case Is = 7
    '                boolEditStatusTwo = False
    '                CurrentActiveCreditNote = 0
    '                boolCreditNoteCalledFromProjectClaims = True
    '                strPublicItemCode = txtCustomerNumber.Text : strPublicItemDescription = cboClient.Text
    '                f = New frmCreditNoteEntry
    '                f.ShowDialog()
    '                boolCreditNoteCalledFromProjectClaims = False
    '                If (CurrentActiveCreditNote - 1) <= 0 Then Exit Sub
    '                objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, CreditNotesMain.TransDate, 105) AS [Date], " _
    '                    & "SUM(((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity) - CreditNoteEntries.Taxes)) AS AmtBeforeTax, " _
    '                    & "SUM((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity)) as [AmtAfterTax] FROM CreditNoteEntries " _
    '                    & "LEFT OUTER JOIN CreditNotesMain ON CreditNoteEntries.NoteNumber = CreditNotesMain.NoteNumber WHERE " _
    '                    & "CreditNoteEntries.NoteNumber = " & CurrentActiveCreditNote & " GROUP BY CreditNotesMain.TransDate", cnn)
    '                objReader = objCommand.ExecuteReader
    '                If objReader.HasRows Then
    '                    objReader.Read()
    '                    dGrid.CurrentRow.Cells(10).Value = CurrentActiveCreditNote - 1
    '                    If Not IsDBNull(objReader(0).ToString) Then dGrid.CurrentRow.Cells(11).Value = objReader(0).ToString
    '                    If IsNumeric(objReader(1).ToString) Then dGrid.CurrentRow.Cells(12).Value = Format(CDbl(objReader(1).ToString), "##0.00")
    '                    If IsNumeric(objReader(2).ToString) Then dGrid.CurrentRow.Cells(13).Value = Format(CDbl(objReader(2).ToString), "##0.00")
    '                End If
    '                objReader.Close()

    '            Case Is = 8
    '                Cursor = Cursors.WaitCursor
    '                If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(10).Value), "")) Then
    '                    If IsNumeric(dGrid.CurrentRow.Cells(10).Value.ToString) Then
    '                        boolEditStatusTwo = True
    '                        boolLoadedFromCustomerForm = False
    '                        intSelectedTransaction = CInt(dGrid.CurrentRow.Cells(10).Value.ToString)
    '                        f = New frmCreditNoteEntry
    '                        f.ShowDialog()
    '                        objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, CreditNotesMain.TransDate, 105) AS [Date], " _
    '                            & "SUM(((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity) - CreditNoteEntries.Taxes)) AS AmtBeforeTax, " _
    '                            & "SUM((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity)) as [AmtAfterTax] FROM CreditNoteEntries " _
    '                            & "LEFT OUTER JOIN CreditNotesMain ON CreditNoteEntries.NoteNumber = CreditNotesMain.NoteNumber WHERE " _
    '                            & "CreditNoteEntries.NoteNumber = " & intSelectedTransaction & " GROUP BY CreditNotesMain.TransDate", cnn)
    '                        objReader = objCommand.ExecuteReader
    '                        If objReader.HasRows Then
    '                            objReader.Read()
    '                            dGrid.CurrentRow.Cells(10).Value = intSelectedTransaction
    '                            If Not IsDBNull(objReader(0).ToString) Then dGrid.CurrentRow.Cells(11).Value = objReader(0).ToString
    '                            If IsNumeric(objReader(1).ToString) Then dGrid.CurrentRow.Cells(12).Value = Format(CDbl(objReader(1).ToString), "##0.00")
    '                            If IsNumeric(objReader(2).ToString) Then dGrid.CurrentRow.Cells(13).Value = Format(CDbl(objReader(2).ToString), "##0.00")
    '                        End If
    '                        objReader.Close()
    '                    End If
    '                End If
    '                Cursor = Cursors.Default

    '            Case Is = 9
    '                If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(10).Value), "")) Then
    '                    If IsNumeric(dGrid.CurrentRow.Cells(10).Value.ToString) Then
    '                        If MessageBox.Show("Are you sure you want to delete this credit note off from the system?", MsgBoxStyle.YesNo, "Confirm Delete") = MsgBoxResult.Yes Then
    '                            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CreditNoteEntries WHERE NoteNumber = " & CDbl(dGrid.CurrentRow.Cells(10).Value.ToString) & "", cnn)
    '                            objCommand.ExecuteNonQuery()
    '                            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CreditNotesMain WHERE NoteNumber = " & CDbl(dGrid.CurrentRow.Cells(10).Value.ToString) & "", cnn)
    '                            objCommand.ExecuteNonQuery()
    '                            'Reset the values back to zeros
    '                            dGrid.CurrentRow.Cells(10).Value = "0"
    '                            dGrid.CurrentRow.Cells(11).Value = ""
    '                            dGrid.CurrentRow.Cells(12).Value = "0.00"
    '                            dGrid.CurrentRow.Cells(13).Value = "0.00"
    '                            MessageBox.Show("Credit note has been deleted successfully", MsgBoxStyle.Information, "Process Success")
    '                        End If
    '                    End If
    '                End If

    '            Case Is = 14
    '                If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(15).Value), "")) Then
    '                    If String.IsNullOrEmpty(txtCustomerNumber.Text) Or String.IsNullOrEmpty(cboClient.Text) Then
    '                        MessageBox.Show("Please enter the client details first.", MsgBoxStyle.Exclamation, "Missing Client Details")
    '                        TabControl1.SelectedIndex = 0
    '                        cboClient.Focus()
    '                        Exit Sub
    '                    End If
    '                    If IsNumeric(dGrid.CurrentRow.Cells(15).Value.ToString) Then
    '                        If CInt(dGrid.CurrentRow.Cells(15).Value.ToString) <> 0 Then
    '                            If MessageBox.Show("There is a receipt already attached to this entry." & vbCrLf & "Do you want to delete it first?", MsgBoxStyle.YesNo, "Project Receipting") = MsgBoxResult.Yes Then
    '                                'Customer transactions
    '                                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerTransactions WHERE " _
    '                                    & "ReferenceNumber = '" & dGrid.CurrentRow.Cells(15).Value.ToString & "' AND AccountNumber = '" & txtCustomerNumber.Text & "'", cnn)
    '                                objCommand.ExecuteNonQuery()
    '                                'Delete from the cashbook
    '                                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CashbookTransactions WHERE " _
    '                                    & "Reference = " & CDbl(dGrid.CurrentRow.Cells(15).Value.ToString) & " AND TransactionType = 'DEBIT' " _
    '                                    & "AND Description LIKE 'CASH SALE - ACCOUNT PAYMENT%' AND AccountNumber = '" & strPublicActiveCashbook & "'", cnn)
    '                                objCommand.ExecuteNonQuery()
    '                                'Delete from the ledger
    '                                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE " _
    '                                    & "Reference = " & CDbl(dGrid.CurrentRow.Cells(15).Value.ToString) & " AND " _
    '                                    & "TransactionType = 'CREDIT' AND AccountNumber = '" & strPublicDebtorsAccount & "'", cnn)
    '                                objCommand.ExecuteNonQuery()
    '                                'Reset in the project entries to zero the receipt number
    '                                Dim strNewDateValue As String = Nothing
    '                                objCommand = New Data.OleDb.OleDbCommand("UPDATE ProjectsTransactions SET ReceiptNumber = 0, " _
    '                                    & "SettlementAmount = 0, SettlementDate = '" & strNewDateValue & "' WHERE ReceiptNumber = " _
    '                                    & "" & CInt(dGrid.CurrentRow.Cells(15).Value.ToString) & "", cnn)
    '                                objCommand.ExecuteNonQuery()
    '                                'Requery the project transactions
    '                                LoadProjectTransactions(intSelectedProjectNumber)
    '                                MessageBox.Show("The payment has been deleted and reset. Please proceed and re-enter", MsgBoxStyle.Information, "Project Receipts Reset")
    '                            End If
    '                            Exit Sub
    '                        Else
    '                            CurrentActiveReceiptNumber = 0
    '                            boolReceptCustomerFromForm = True
    '                            strSelectedAccount = txtCustomerNumber.Text
    '                            strSelectedAccountName = cboClient.Text
    '                            boolAbort = False
    '                            f = New frmAdvanceInvoiceSettlement
    '                            f.ShowDialog()
    '                            strSelectedAccount = Nothing
    '                            strSelectedAccountName = Nothing
    '                            If boolAbort = True Then Exit Sub
    '                            dGrid.CurrentRow.Cells(15).Value = CurrentActiveReceiptNumber
    '                            dGrid.CurrentRow.Cells(16).Value = StartDate
    '                            dGrid.CurrentRow.Cells(17).Value = Format(CurrentAmountReceived, "##0.00")
    '                        End If
    '                    End If
    '                Else
    '                    CurrentActiveReceiptNumber = 0
    '                    boolReceptCustomerFromForm = True
    '                    strSelectedAccount = txtCustomerNumber.Text
    '                    strSelectedAccountName = cboClient.Text
    '                    boolAbort = False
    '                    f = New frmAdvanceInvoiceSettlement
    '                    f.ShowDialog()
    '                    If boolAbort = True Then Exit Sub
    '                    dGrid.CurrentRow.Cells(15).Value = CurrentActiveReceiptNumber
    '                    dGrid.CurrentRow.Cells(16).Value = StartDate
    '                    dGrid.CurrentRow.Cells(17).Value = Format(CurrentAmountReceived, "##0.00")
    '                End If


    '        End Select
    '        ComputeBalance()
    '    End If
    'End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SaveData()
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtContractName.Text) Then
            MessageBox.Show("Please enter the contract name", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtContractName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtCustomerNumber.Text) Then
            MessageBox.Show("Please enter the client for the project", "Missing Client Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClient.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboPersonnel.Text) Then
            MessageBox.Show("Please enter the project owner", "Missing Project Owner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPersonnel.Focus()
            Exit Sub
        End If
        Dim objCommand As Data.OleDb.OleDbCommand

        '
        If boolEditStatus = True Then
            'Delete the record completely
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM ProjectsConsultants WHERE ContractNumber = " & intSelectedProjectNumber & "", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM ProjectsTransactions WHERE ContractNumber = " & intSelectedProjectNumber & "", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM ProjectsMain WHERE ContractNumber = " & intSelectedProjectNumber & "", cnn)
            objCommand.ExecuteNonQuery()
        End If
        '

        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO ProjectsMain ([ContractNumber],[TakeOnDate]," _
            & "[ContractName],[CustomerNumber],[InitialValue],[RevisedValue], [Owner]) VALUES " _
            & "(" & txtReference.Text & ", '" & Format(dpTakeonDate.Value, "dd-MMM-yyyy") & "', " _
            & "'" & txtContractName.Text & "', '" & txtCustomerNumber.Text & "', " & CDbl(txtContractValue.Text) & ", " _
            & "" & CDbl(txtRevisedValue.Text) & ", '" & cboPersonnel.Text & "')", cnn)
        objCommand.ExecuteNonQuery()

        'Add the contractor details
        For i As Integer = 0 To dGridContractors.Rows.Count - 1
            Dim strCalling As String = Nothing
            Dim strContractorName As String = Nothing
            Dim strContactName As String = Nothing
            Dim strContactTelephone As String = Nothing
            Dim strContactFaxNumber As String = Nothing
            Dim strContactCellphone As String = Nothing
            Dim strContactEmailAddress As String = Nothing

            If Not (Object.Equals(Convert.ToString(dGridContractors.Rows(i).Cells(0).Value), "")) Then
                strCalling = dGridContractors.Rows(i).Cells(0).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGridContractors.Rows(i).Cells(1).Value), "")) Then
                strContractorName = dGridContractors.Rows(i).Cells(1).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGridContractors.Rows(i).Cells(2).Value), "")) Then
                strContactName = dGridContractors.Rows(i).Cells(2).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGridContractors.Rows(i).Cells(3).Value), "")) Then
                strContactTelephone = dGridContractors.Rows(i).Cells(3).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGridContractors.Rows(i).Cells(4).Value), "")) Then
                strContactFaxNumber = dGridContractors.Rows(i).Cells(4).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGridContractors.Rows(i).Cells(5).Value), "")) Then
                strContactCellphone = dGridContractors.Rows(i).Cells(5).Value.ToString
            End If
            If Not (Object.Equals(Convert.ToString(dGridContractors.Rows(i).Cells(6).Value), "")) Then
                strContactEmailAddress = dGridContractors.Rows(i).Cells(6).Value.ToString
            End If

            If Not String.IsNullOrEmpty(strContractorName) Or Not String.IsNullOrEmpty(strContactName) _
                Or Not String.IsNullOrEmpty(strContactTelephone) Or Not String.IsNullOrEmpty(strContactFaxNumber) _
                Or Not String.IsNullOrEmpty(strContactCellphone) Or Not String.IsNullOrEmpty(strContactEmailAddress) Then
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO ProjectsConsultants ([ContractNumber],[ConsultantCalling]," _
                    & "[ConsultantName],[ContactPerson],[Telephone],[FaxNumber],[Cellphone],[EmailAddress]) VALUES " _
                    & "(" & txtReference.Text & ", '" & strCalling & "', '" & strContractorName & "', '" & strContactName & "', '" & strContactTelephone & "', " _
                    & "'" & strContactFaxNumber & "', '" & strContactCellphone & "', '" & strContactEmailAddress & "')", cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next

        'Add the transactions
        'With dGrid
        '    For i As Integer = 0 To .Rows.Count - 1
        '        Dim intInvoiceNumber As Integer = 0
        '        Dim intCreditNoteNumber As Integer = 0
        '        Dim strReceiptDate As String = Nothing
        '        Dim dblReceiptValue As Double = 0
        '        Dim intReceiptNumber As Double = 0

        '        If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "")) Then
        '            intInvoiceNumber = Convert.ToDouble(.Rows(i).Cells(3).Value)
        '        End If
        '        If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(10).Value), "")) Then
        '            intCreditNoteNumber = Convert.ToDouble(.Rows(i).Cells(10).Value)
        '        End If
        '        If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(15).Value), "")) Then
        '            intReceiptNumber = Convert.ToDouble(.Rows(i).Cells(15).Value)
        '        End If
        '        If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(16).Value), "")) Then
        '            strReceiptDate = Convert.ToString(.Rows(i).Cells(16).Value)
        '        End If
        '        If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(17).Value), "")) Then
        '            dblReceiptValue = Convert.ToDouble(.Rows(i).Cells(17).Value)
        '        End If
        '        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO ProjectsTransactions ([ContractNumber]," _
        '            & "[InvoiceNumber],[CreditNoteNumber],[SettlementDate],[SettlementAmount],[ReceiptNumber]) " _
        '            & "VALUES (" & txtReference.Text & ", " & intInvoiceNumber & ", " & intCreditNoteNumber & ", " _
        '            & "'" & strReceiptDate & "', " & dblReceiptValue & ", " & intReceiptNumber & ")", cnn)
        '        objCommand.ExecuteNonQuery()
        '    Next
        'End With
        ''0771709669 - Chaumbuka J
        ''Update the control number entry
        If boolEditStatus = False Then
            objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET ProjectsNumber = " & txtReference.Text & "", cnn)
            objCommand.ExecuteNonQuery()
            'lblStatusMode.Text = "MODE: UPDATE"
            'boolEditStatus = True
            ''Reload the project transactions
            'intSelectedProjectNumber = CInt(txtReference.Text)
            'lblStatusMode.Text = "MODE: Update"
            'LoadSelectedTransactions()
            'LoadCashbookTransactions()
        End If

        'If boolSaveOnly = False Then
        MessageBox.Show("Project details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On contact details setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCallings()
        On Error GoTo RaiseErr
        dGridContractors.Rows.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT Calling FROM ConstructionCallings ORDER BY Calling", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGridContractors.Rows.Add(objReader(0), "", "", "", "", "")
            End If
        End While
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On construction calling detaild load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCustomers()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT AccountName +';'+AccountNumber AS [Customer] FROM Customers ORDER BY AccountName"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Set up the drop down combo box
        Dim intWidth As Integer = cboClient.Width - 50
        With cboClient
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "250;" & intWidth - 250
        End With

        'Get a count of the items
        Dim intItemsCount As Double = 0

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(AccountNumber) FROM Customers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()

        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboClient.Items.Clear()
        Dim p As Double = 0

        'Continue to read until you reach the end of the file.
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            End If
            p = p + 1
        End While
        objReader.Close()

        If intItemsCount > 0 Then
            cboClient.SelectedIndex = -1
            cboClient.Items.Clear()
            cboClient.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboClient.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " On customers details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboSupplierName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClient.SelectedIndexChanged
        txtCustomerNumber.Clear()
        If Not cboClient.SelectedItem Is Nothing Then
            txtCustomerNumber.Text = cboClient.SelectedItem.Col2
        Else
            txtCustomerNumber.Text = Nothing
        End If
    End Sub

    'Private Sub frmConstructionJobsClaimSetup_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    Me.Width = 752
    '    Me.Height = 518
    'End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        boolEditStatus = False
        Dim f As New frmCustomerDetails
        f.ShowDialog()
        LoadCustomers()
    End Sub

    Private Sub btnFindAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindAccount.Click
        strPublicItemCode = Nothing
        strPublicItemDescription = Nothing
        boolAbort = False
        Dim f As New frmBrowseDebtors
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        txtCustomerNumber.Text = strPublicItemCode
        cboClient.Text = strPublicItemDescription
    End Sub

    'Private Sub dGrid_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles dGrid.Paint
    'Dim hc As DataGridViewCell = dGrid.Columns(0).HeaderCell
    ''Handles the first 7 cells
    'Dim hcRct As Rectangle = dGrid.GetCellDisplayRectangle(hc.ColumnIndex, -1, True)
    'Dim multiHeaderWidth As Integer = dGrid.Columns(hc.ColumnIndex).Width + _
    '    dGrid.Columns(1).Width + _
    '    dGrid.Columns(2).Width + _
    '    dGrid.Columns(3).Width + _
    '    dGrid.Columns(4).Width + _
    '    dGrid.Columns(5).Width + dGrid.Columns(6).Width
    'Dim headRct As New Rectangle(hcRct.Left, hc.ContentBounds.Y + 2, multiHeaderWidth, dGrid.ColumnHeadersHeight)
    'headRct.Height = 3
    'Dim sz As SizeF = e.Graphics.MeasureString("Invoice Transaction Entries", dGrid.Font)
    'Dim headerTop As Integer = Convert.ToInt32((headRct.Height / 2) - (sz.Height / 2)) + 4
    'Dim GridFont As New System.Drawing.Font("Times New Roman", 10, Drawing.FontStyle.Italic, Drawing.GraphicsUnit.Point)
    'e.Graphics.DrawString("Invoice Transaction Entries", GridFont, Brushes.Black, hcRct.Left + 2, headerTop)
    'End Sub

    '    Private Sub ComputeBalance()
    '        On Error GoTo RaiseErr
    '        For i As Integer = 0 To dGrid.Rows.Count - 1
    '            Dim dblInvoice As Double = 0
    '            Dim dblCreditNote As Double = 0
    '            Dim dblPayment As Double = 0

    '            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(6).Value), "") Then
    '                If IsNumeric(dGrid.Rows(i).Cells(6).Value.ToString) Then
    '                    dblInvoice = CDbl(dGrid.Rows(i).Cells(6).Value.ToString)
    '                End If
    '            End If
    '            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(13).Value), "") Then
    '                If IsNumeric(dGrid.Rows(i).Cells(13).Value.ToString) Then
    '                    dblCreditNote = CDbl(dGrid.Rows(i).Cells(13).Value.ToString)
    '                End If
    '            End If
    '            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(17).Value), "") Then
    '                If IsNumeric(dGrid.Rows(i).Cells(17).Value.ToString) Then
    '                    dblPayment = CDbl(dGrid.Rows(i).Cells(17).Value.ToString)
    '                End If
    '            End If
    '            dGrid.Rows(i).Cells(18).Value = Format(dblInvoice - (dblCreditNote + dblPayment), "##0.00")
    '        Next
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Balance computation"
    '        ShowErrorMessage()
    '    End Sub

    Private Sub btnAddExpense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddExpense.Click
        If boolEditStatus = False Then
            MessageBox.Show("Transactions cannot be entered while you are creating a new project", "Process Ignored", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblAccountDescription.Text) Then
            MessageBox.Show("Please select the cashbook to which the transactions will be posted", "Missing Cashbook Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccount.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtReference.Text) Then
            MessageBox.Show("Application has detected an invalid project number. Please check", "Invalid Project Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        strPublicActiveCashbook = cboAccount.Text
        lngPublicLinkedProjectNumber = CLng(txtReference.Text)

        boolCalledFromProjects = True

        Dim f As New frmCashbookExpenses
        f.ShowDialog()

        boolCalledFromProjects = False
        strPublicActiveCashbook = Nothing
        LoadCashbookTransactions()
    End Sub

    Private Sub cboAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccount.SelectedIndexChanged
        lblAccountDescription.Text = ""
        If Not cboAccount.SelectedItem Is Nothing Then
            lblAccountDescription.Text = cboAccount.SelectedItem.Col2
        End If
    End Sub

    Private Sub LoadCashbooks()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountNumber +';'+AccountName AS " _
            & "[Accounts] FROM Cashbooks ORDER BY AccountNumber"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboAccount
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;180"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM Cashbooks", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboAccount.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()
        If intItemsCount > 0 Then
            cboAccount.SelectedIndex = -1
            cboAccount.Items.Clear()
            cboAccount.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboAccount.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Cashbooks Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCashbookTransactions()
        On Error GoTo RaiseErr
        dGridCredits.Rows.Clear()

        Dim strSql As String = Nothing

        strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')), " _
            & "Description, ContraAccount, Amount, TransactionId, " _
            & "Reference, TransactionType, VatAmount, VatNumber, SpecialKey FROM CashbookTransactions WHERE " _
            & "LinkedProject = " & CInt(txtReference.Text) & " ORDER BY TransactionDate"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)

        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader("TransactionType").ToString) Then
                If UCase(objReader("TransactionType").ToString) = "CREDIT" Then
                    With dGridCredits
                        .Rows.Add(1)
                        If Not IsDBNull(objReader(0).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                        If Not IsDBNull(objReader("Description").ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader("Description").ToString
                        If Not IsDBNull(objReader("ContraAccount").ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader("ContraAccount").ToString
                        If IsNumeric(objReader("Amount").ToString) Then .Rows(.Rows.Count - 1).Cells(3).Value = Format(CDbl(objReader("Amount").ToString), "##0.00")
                        If Not IsDBNull(objReader("TransactionId").ToString) Then .Rows(.Rows.Count - 1).Cells(4).Value = objReader("TransactionId").ToString
                        If Not IsDBNull(objReader("Reference").ToString) Then .Rows(.Rows.Count - 1).Cells(5).Value = objReader("Reference").ToString
                        If IsNumeric(objReader("VatAmount").ToString) Then .Rows(.Rows.Count - 1).Cells(6).Value = Format(CDbl(objReader("VatAmount").ToString), "##0.00")
                        If Not IsDBNull(objReader("VatNumber").ToString) Then .Rows(.Rows.Count - 1).Cells(7).Value = objReader("VatNumber").ToString
                        If IsNumeric(objReader("SpecialKey").ToString) Then .Rows(.Rows.Count - 1).Cells(9).Value = objReader("SpecialKey").ToString Else .Rows(.Rows.Count - 1).Cells(9).Value = "0"
                    End With
                End If
            End If
        End While
        objReader.Close()
        ComputeExpensesTotal()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Cashbook Transactions Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeExpensesTotal()
        Dim dblTotalCredits As Double = 0
        Dim dblTotalDebits As Double = 0
        Dim dblBalance As Double = 0
        With dGridCredits
            For i As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "")) Then
                    If IsNumeric(.Rows(i).Cells(3).Value) Then
                        dblTotalCredits = dblTotalCredits + CDbl(.Rows(i).Cells(3).Value.ToString)
                    End If
                End If
            Next
        End With
        lblTotal.Text = Format(dblTotalCredits, "#,##0.00")
    End Sub

    Private Sub dGridCredits_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridCredits.CellClick
        If dGridCredits.RowCount <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        If dGridCredits.CurrentCell.ColumnIndex = 8 Then
            If MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                ''Get the selected transaction contra account details
                'Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ContraAccount, AccountNumber, " _
                '    & "Amount, TransactionDate FROM CashbookTransactions WHERE TransactionId = " & CLng(dGridCredits.CurrentRow.Cells(4).Value.ToString) & "", cnn)
                'Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                'Dim strContra As String = Nothing
                'Dim strAccount As String = Nothing
                'Dim dblAmt As Double = 0
                'Dim strDate As Date = Format(Now, "dd-MMM-yyyy")
                'If objReader.HasRows Then
                '    objReader.Read()
                '    If Not IsDBNull(objReader(0).ToString) Then strContra = objReader(0).ToString
                '    If Not IsDBNull(objReader(1).ToString) Then strAccount = objReader(1).ToString
                '    If IsNumeric(objReader(2).ToString) Then dblAmt = objReader(2).ToString
                '    If IsDate(objReader(3).ToString) Then strDate = Format(CDate(objReader(3).ToString), "dd-MMM-yyyy")
                'End If
                'objReader.Close()
                'objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CashbookTransactions " _
                '    & "WHERE TransactionId = " & CInt(dGridCredits.CurrentRow.Cells(4).Value.ToString) & "", cnn)
                'objCommand.ExecuteNonQuery()
                ''Delete the reocord from the ledger as well
                'objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE " _
                '    & "AccountNumber = '" & strContra & "' AND ContraAccount = '" & strAccount & "' " _
                '    & "AND Amount = " & dblAmt & " AND TransactionDate = '" & strDate & "'", cnn)
                'objCommand.ExecuteNonQuery()
                Dim intKey As Integer = CInt(dGridCredits.CurrentRow.Cells(9).Value.ToString)
                If intKey = 0 Then
                    MessageBox.Show("This transaction cannot be deleted. To reverse this transaction use the journal entry module. " _
                        & "For assistance consult your Business Light consultant", "Legacy Transaction Delete Issue", _
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If gwt_comm.DeleteSpecialKeyTransaction(intKey) = True Then
                    MessageBox.Show("Transaction has been deleted successfully from the system", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadCashbookTransactions()
                End If

            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Cashbook Transactions Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
'Private Sub btnNewClaim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'    If UCase(lblStatusMode.Text) = "MODE: CREATE" Then
'        MessageBox.Show("You must save the main project details before adding transactions to it", MsgBoxStyle.Exclamation, "Procedure Not Allowed")
'        Me.TabControl1.SelectedIndex = 0
'        Exit Sub
'    End If
'    boolEditStatusTwo = False
'    strSelectedProjectAccountName = cboClient.Text
'    strSelectedProjectAccountNumber = txtCustomerNumber.Text
'    boolAbort = False
'    Dim f As Form
'    f = New frmConstructionClaimsTempleteSelection
'    f.ShowDialog()
'    If boolAbort = True Then Exit Sub
'    f = New frmConstructionProjectClaims
'    f.ShowDialog()
'End Sub

'    Private Sub LoadClaims(ByVal ProjectNumber As Integer)
'        On Error GoTo RaiseErr
'        Dim strSql As String = "select UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')), " _
'            & "ClaimNumber, CAST(ClaimValue AS DECIMAL (10,2)) from ProjectClaimsMain " _
'            & "WHERE ContractNumber = " & ProjectNumber & ""
'        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
'        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
'        dGridClaims.Rows.Clear()
'        While objReader.Read
'            dGridClaims.Rows.Add(objReader(0), objReader(1), objReader(2))
'        End While
'        objReader.Close()
'        Exit Sub
'RaiseErr:
'        boolAbort = True
'        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Project Claims Load"
'        ShowErrorMessage()
'    End Sub

'    Private Sub dGridClaims_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
'        On Error GoTo RaiseErr
'        If dGridClaims.Rows.Count <= 0 Then Exit Sub
'        Select Case dGridClaims.CurrentCell.ColumnIndex
'            Case Is = 3
'                'Edit Record
'                boolEditStatusTwo = True
'                intselectedClaimNumber = CInt(dGridClaims.CurrentRow.Cells(1).Value.ToString)
'                strSelectedProjectAccountName = cboClient.Text
'                strSelectedProjectAccountNumber = txtCustomerNumber.Text
'                Dim f As New frmConstructionProjectClaims
'                f.ShowDialog()
'                LoadClaims(intSelectedProjectNumber)
'            Case Is = 4
'                'Delete record
'                If MessageBox.Show("Are you sure you want to delete this claim?", MsgBoxStyle.YesNo, "Confirm Claim Delete") = MsgBoxResult.Yes Then
'                    Dim intClaimNumber As Integer = CInt(dGridClaims.CurrentRow.Cells(1).Value.ToString)
'                    Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM ProjectClaimDetails WHERE ClaimNumber = " & intClaimNumber & "", cnn)
'                    objCommand.ExecuteNonQuery()
'                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM ProjectClaimsMain WHERE ClaimNumber = " & intClaimNumber & "", cnn)
'                    objCommand.ExecuteNonQuery()
'                    MessageBox.Show("Record deleted successfully", MsgBoxStyle.Information, "Process Success")
'                    LoadClaims(intSelectedProjectNumber)
'                End If
'        End Select
'        Exit Sub
'RaiseErr:
'        boolAbort = True
'        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Project Claims Load"
'        ShowErrorMessage()
'    End Sub

'End Class

'Private Sub LoadProjectTransactions(ByVal ProjectNumber As Integer)
'    On Error GoTo RaiseErr
'    dGrid.Rows.Clear()
'    Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [ContractNumber],[InvoiceNumber]," _
'        & "[CreditNoteNumber],[SettlementDate],[SettlementAmount],[ReceiptNumber] FROM " _
'        & "ProjectsTransactions WHERE ContractNumber = " & ProjectNumber & "", cnn)
'    Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
'    Dim objReadValues As Data.OleDb.OleDbDataReader
'    While objReader.Read
'        Dim intInvoiceNumber As Integer = 0
'        Dim dblInvoiceValueBeforeTax As Double = 0
'        Dim dblInvoiceValueAfterTax As Double = 0
'        Dim strInvoiceDate As String = Nothing
'        Dim intCreditNoteNumber As Integer = 0
'        Dim dblCrNoteValueBeforeTax As Double = 0
'        Dim dblCrNoteValueAfterTax As Double = 0
'        Dim strCrNoteDate As String = Nothing
'        Dim strReceiptDate As String = Nothing
'        Dim dblReceiptValue As Double = 0
'        Dim intReceiptNumber As Double = 0

'        dGrid.Rows.Add(1)
'        If IsNumeric(objReader("InvoiceNumber").ToString) Then
'            If CInt(objReader("InvoiceNumber").ToString) > 0 Then
'                'Get the values
'                objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
'                    & "(Amount - Taxes) AS AmtBeforeTax, Amount as [AmtAfterTax] FROM CustomerSalesMain WHERE " _
'                    & "InvoiceNumber = " & objReader("InvoiceNumber").ToString & "", cnn)
'                objReadValues = objCommand.ExecuteReader
'                If objReadValues.HasRows Then
'                    objReadValues.Read()
'                    dGrid.Rows(dGrid.Rows.Count - 1).Cells(3).Value = objReader("InvoiceNumber").ToString
'                    If Not IsDBNull(objReadValues(0).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(4).Value = objReadValues(0).ToString
'                    If IsNumeric(objReadValues(1).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(5).Value = Format(CDbl(objReadValues(1).ToString), "##0.00")
'                    If IsNumeric(objReadValues(2).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(6).Value = Format(CDbl(objReadValues(2).ToString), "##0.00")
'                End If
'                objReadValues.Close()
'            End If
'        End If

'        'Get the credit notes
'        If IsNumeric(objReader("CreditNoteNumber").ToString) Then
'            If CInt(objReader("CreditNoteNumber").ToString) > 0 Then
'                'Get the values
'                objCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, CreditNotesMain.TransDate, 105) AS [Date], " _
'                            & "SUM(((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity) - CreditNoteEntries.Taxes)) AS AmtBeforeTax, " _
'                            & "SUM((CreditNoteEntries.UnitPrice * CreditNoteEntries.Quantity)) as [AmtAfterTax] FROM CreditNoteEntries " _
'                            & "LEFT OUTER JOIN CreditNotesMain ON CreditNoteEntries.NoteNumber = CreditNotesMain.NoteNumber WHERE " _
'                            & "CreditNoteEntries.NoteNumber = " & objReader("CreditNoteNumber").ToString & " GROUP BY CreditNotesMain.TransDate", cnn)
'                objReadValues = objCommand.ExecuteReader
'                If objReadValues.HasRows Then
'                    objReadValues.Read()
'                    dGrid.Rows(dGrid.Rows.Count - 1).Cells(10).Value = objReader("CreditNoteNumber").ToString
'                    If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(11).Value = objReadValues(0).ToString
'                    If IsNumeric(objReader(1).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(12).Value = Format(CDbl(objReadValues(1).ToString), "##0.00")
'                    If IsNumeric(objReader(2).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(13).Value = Format(CDbl(objReadValues(2).ToString), "##0.00")
'                End If
'                objReadValues.Close()
'            End If
'        End If

'    End While
'    ComputeBalance()
'    Exit Sub
'RaiseErr:
'    boolAbort = True
'    strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On project details load"
'    ShowErrorMessage()
'End Sub

'Private Sub btnAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'    If UCase(lblStatusMode.Text) = "MODE: CREATE" Then
'        MessageBox.Show("You must save the main project details before adding transactions to it", MsgBoxStyle.Exclamation, "Procedure Not Allowed")
'        Me.TabControl1.SelectedIndex = 0
'        Exit Sub
'    Else
'        dGrid.Rows.Add(1)
'    End If
'End Sub

'Private Sub btnDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'    If UCase(lblStatusMode.Text) = "MODE: CREATE" Then
'        MessageBox.Show("You must save the main project details before adding transactions to it", MsgBoxStyle.Exclamation, "Procedure Not Allowed")
'        Me.TabControl1.SelectedIndex = 0
'        Exit Sub
'    End If
'    If dGrid.Rows.Count > 0 Then dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
'End Sub