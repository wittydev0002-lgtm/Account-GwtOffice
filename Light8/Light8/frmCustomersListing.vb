Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Imports System.Net
Imports System.Management
Imports System.Management.Instrumentation
Imports System.Drawing
Imports ComponentFactory.Krypton.Toolkit
Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmCustomersListing


    Dim boolFormLoading As Boolean
    Dim boolPrintFromPreview As Boolean
    Dim strReportHeader As String
    Public itm As Integer = 0

    Dim strTaxStatus As String = Nothing
    Dim strCustomerDetails As String
    Dim strInvoiceDetails As ArrayList
    Dim rsInvoiceTotals As String

    Dim dblInvoiceTotal As Double
    Dim dblTaxes As Double
    Dim dblDiscounts As Double
    Dim i As Integer = 0
    Dim strvalue As String
    Dim strDate As String
    Dim intPaymentReceiptNumber As Integer
    Dim strCustomerAccountNumberPayments As String
    Dim strTermsAndConditions As String = Nothing

    Dim strCustomerName As String
    Dim strCustomerAddress1 As String
    Dim strCustomerAddress2 As String
    Dim strCustomerAddress3 As String
    Dim strCustomerAddress4 As String
    Dim strCustomerTelephone As String
    Dim strCustomerEmailAddress As String
    Dim strCustomerVatNumber As String

    Dim boolExitingWhile As Boolean = False
    Dim intPage As Single = 1
    Dim intPageTotals As Integer = 1

    Dim strItemType As String = Nothing

    Private Sub frmCustomersListing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        UpdateFormTables()
        LoadCustomerData("ALL")
        cboCustomerSearchBy.SelectedIndex = 1
    End Sub

    Private Sub btnNewCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnNewCustomer.Click
        If IntPublicCustomers <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        boolEditStatus = False
        Dim f As New frmCustomerDetails
        f.ShowDialog()
        LoadCustomerData("ALL")
    End Sub

    Private Sub btnEditCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnEditCustomer.Click
        If IntPublicCustomers <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        EditCustomerDetails()
    End Sub

    Private Sub EditCustomerDetails()
        GetSelectedCustomer()
        boolEditStatus = True
        boolAbort = False
        Dim f As New frmCustomerDetails
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        LoadCustomerData("ALL")
    End Sub

    Private Sub LoadCustomerData(Optional ByVal SearchFor As String = "ALL")
        On Error GoTo RaiseErr
        'dGrid.Rows.Clear()
        Dim strSql As String = Nothing

        'Select Case UCase(SearchFor)
        '    Case = "ALL"

        'End Select
        If UCase(SearchFor) = "ALL" Then
            strSql = "SELECT Customers.AccountNumber AS [Account No.], Customers.AccountName as [Name], " _
                & "PhoneNumber as [Telephone], CONVERT(NVARCHAR, TakeOnDate, 105) AS [Take On Date], " _
                & "Cellphone AS [Cellphone], ISNULL(CAST(SUM(CustomerTransactions.Amount) AS DECIMAL (30,2)), 0) AS [Balance] " _
                & "FROM Customers left outer join CustomerTransactions ON Customers.AccountNumber = CustomerTransactions.AccountNumber " _
                & "GROUP BY Customers.AccountName, Customers.AccountNumber, Customers.PhoneNumber, Customers.TakeOnDate, Customers.Cellphone"
        Else
            If UCase(cboCustomerSearchBy.Text) = UCase("Account Number") Then

                strSql = "SELECT Customers.AccountNumber AS [Account No.], Customers.AccountName as [Name], " _
                    & "PhoneNumber as [Telephone], CONVERT(NVARCHAR, TakeOnDate, 105) AS [Take On Date], " _
                    & "Cellphone AS [Cellphone], ISNULL(CAST(SUM(CustomerTransactions.Amount) AS DECIMAL (30,2)), 0) AS [Balance] " _
                    & "FROM Customers left outer join CustomerTransactions ON Customers.AccountNumber = CustomerTransactions.AccountNumber " _
                    & "WHERE Customers.AccountNumber LIKE '%" & SearchFor & "%' GROUP BY Customers.AccountName, Customers.AccountNumber, " _
                    & "Customers.PhoneNumber, Customers.TakeOnDate, Customers.Cellphone ORDER BY Customers.AccountNumber "

                'strSql = "SELECT AccountNumber AS [Account No.], AccountName as [Name], " _
                '    & "PhoneNumber as [Telephone], CONVERT(NVARCHAR, TakeOnDate, 105) AS [Take On Date], " _
                '    & "REPLACE((Address1 +', '+ Address2 +', '+ Address3 +', '+ Address4), ', ,', '') AS [Address], " _
                '    & "EmailAddress as [Email Address], Cellphone AS [Cellphone] FROM " _
                '    & "Customers WHERE AccountNumber LIKE '%" & SearchFor & "%' ORDER BY AccountNumber"
            Else
                'strSql = "SELECT AccountNumber AS [Account No.], AccountName as [Name], " _
                '    & "PhoneNumber as [Telephone], CONVERT(NVARCHAR, TakeOnDate, 105) AS [Take On Date], " _
                '    & "REPLACE((Address1 +', '+ Address2 +', '+ Address3 +', '+ Address4), ', ,', '') AS [Address], " _
                '    & "EmailAddress as [Email Address], Cellphone AS [Cellphone] FROM " _
                '    & "Customers  WHERE AccountName LIKE '%" & SearchFor & "%' ORDER BY AccountName"

                strSql = "SELECT Customers.AccountNumber AS [Account No.], Customers.AccountName as [Name], " _
                    & "PhoneNumber as [Telephone], CONVERT(NVARCHAR, TakeOnDate, 105) AS [Take On Date], " _
                    & "Cellphone AS [Cellphone], ISNULL(CAST(SUM(CustomerTransactions.Amount) AS DECIMAL (30,2)), 0) AS [Balance] " _
                    & "FROM Customers left outer join CustomerTransactions ON Customers.AccountNumber = CustomerTransactions.AccountNumber " _
                    & "WHERE Customers.AccountName LIKE '%" & SearchFor & "%' GROUP BY Customers.AccountName, Customers.AccountNumber, " _
                    & "Customers.PhoneNumber, Customers.TakeOnDate, Customers.Cellphone ORDER BY Customers.AccountNumber "

            End If
        End If




        dGridCustomers.Columns.Clear()
        Me.dGridCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridCustomers.DataSource = dTable
        For p As Integer = 0 To dGridCustomers.Columns.Count - 1
            dGridCustomers.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            If p = dGridCustomers.Columns.Count - 1 Then
                dGridCustomers.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Summary Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub GetSelectedCustomer()
        If dGridCustomers.Rows.Count > 0 Then
            strSelectedAccount = dGridCustomers.CurrentRow.Cells(0).Value.ToString
            strSelectedAccountName = dGridCustomers.CurrentRow.Cells(1).Value.ToString
        End If
    End Sub

    Private Sub btnDeleteCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteCustomer.Click
        DeleteCustomer()
    End Sub

    Private Sub DeleteCustomer()
        If IntPublicCustomers = 1 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        GetSelectedCustomer()
        If MessageBox.Show("Are you sure you want to delete this reord? Deleting " & vbCrLf & "customers may have adverse effect to your financial records", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM Customers WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSales WHERE CustomerId = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerSalesMain WHERE CustomerId = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerTerms WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CustomerTransactions WHERE AccountNumber = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE ContraAccount = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CashbookTransactions WHERE ContraAccount = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()

            objCommand = New Data.OleDb.OleDbCommand("SELECT NoteNumber FROM CreditNotesMain WHERE AccountId = '" & strSelectedAccount & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReader.Read
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CreditNoteEntries WHERE NoteNumber = " & objReader(0).ToString & "", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CreditNotesMain WHERE NoteNumber = " & objReader(0).ToString & "", cnn)
                objCommand.ExecuteNonQuery()
            End While

            MessageBox.Show("Customer record deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadCustomerData("ALL")
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Listing Search"
        ShowErrorMessage()
    End Sub

    Private Sub btnExportCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btnExportCustomers.Click
        If IntPublicCustomers <= 1 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim sfd As New SaveFileDialog
        sfd.ShowDialog()
        Dim strFileName As String = sfd.FileName
        If Not String.IsNullOrEmpty(strFileName) Then
            Cursor = Cursors.WaitCursor
            Dim strData As String = gwt_comm.ScriptCustomerData()
            Dim objFileWriter As New System.IO.StreamWriter(strFileName, False)
            objFileWriter.WriteLine(strData)
            objFileWriter.Close()
            Cursor = Cursors.Default
            MessageBox.Show("Customers Export File Generated Successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Details Export"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefreshCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshCustomers.Click
        LoadCustomerData("ALL")
    End Sub

    Private Sub txtSearchString_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If chkActiveSearch.Checked = True Then
            If Char.IsLetter(e.KeyChar) Then
                LoadCustomerData(txtSearchString.Text)
            End If
        Else
            If Asc(e.KeyChar) = 13 Then
                LoadCustomerData(txtSearchString.Text)
            End If
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        LoadCustomerData(txtSearchString.Text)
    End Sub

    Private Sub mnuOpen_Click(sender As System.Object, e As System.EventArgs) Handles mnuOpen.Click
        If IntPublicCustomers <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        EditCustomerDetails()
    End Sub

    Private Sub mnuDeleteCustomer_Click(sender As System.Object, e As System.EventArgs) Handles mnuDeleteCustomer.Click
        DeleteCustomer()
    End Sub

    Private Sub btnPrintAllCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintAllCustomers.Click

    End Sub

    Private Sub dGridCustomers_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dGridCustomers.CellMouseDown
        If e.Button = MouseButtons.Right Then
            ' Add this
            dGridCustomers.CurrentCell = dGridCustomers.Rows(e.RowIndex).Cells(e.ColumnIndex)
            ' Can leave these here - doesn't hurt
            dGridCustomers.Rows(e.RowIndex).Selected = True
            dGridCustomers.Focus()
        End If
    End Sub

    Private Sub mnuPrintCustomerStatement_Click(sender As System.Object, e As System.EventArgs) Handles mnuPrintCustomerStatement.Click
        GetSelectedCustomer()
        Dim prntCom As New CommonLibrary.Commons.CommonFunctions
        prntCom.PrintCustomerStatement(strSelectedAccount)
    End Sub

    Private Sub dGridCustomers_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridCustomers.DoubleClick
        If IntPublicCustomers <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        EditCustomerDetails()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintToolStripMenuItem.Click

    End Sub

    Private Sub mnuNewCustomerQuote_Click(sender As System.Object, e As System.EventArgs) Handles mnuNewCustomerQuote.Click

    End Sub

    Private Sub mnuNewCashsale_Click(sender As System.Object, e As System.EventArgs) Handles mnuNewCashsale.Click

    End Sub

    Private Sub mnuReceivePayment_Click(sender As System.Object, e As System.EventArgs) Handles mnuReceivePayment.Click

    End Sub

    Private Sub mnuEmailCustomer_Click(sender As System.Object, e As System.EventArgs) Handles mnuEmailCustomer.Click

    End Sub

    Private Sub mnuActivateCustomer_Click(sender As System.Object, e As System.EventArgs) Handles mnuActivateCustomer.Click

    End Sub

    Private Sub mnuDeactivateCustomer_Click(sender As System.Object, e As System.EventArgs) Handles mnuDeactivateCustomer.Click

    End Sub

    Private Sub txtSearchString_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchString.TextChanged

    End Sub

    Private Sub btnDebtorClasses_Click(sender As Object, e As EventArgs) Handles btnDebtorClasses.Click
        Dim frm As New frmDebtorsMainClasses
        frm.ShowDialog()
    End Sub

    Private Sub UpdateFormTables()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        If gwt_comm.CheckTableExistence("SystemDebtorsMainClasses") = False Then
            strSql = "CREATE TABLE [SystemDebtorsMainClasses]([TransactionId][INT] NOT NULL PRIMARY KEY IDENTITY (1,1), " _
                & "[Description][NVARCHAR](250) NOT NULL DEFAULT '')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckTableExistence("SystemDebtorClassOptions") = False Then
            strSql = "CREATE TABLE [SystemDebtorClassOptions] ([TransactionId][INT] NOT NULL PRIMARY KEY IDENTITY (1,1), " _
                & "[Option][NVARCHAR](35) Not NULL DEFAULT '', [OrdinalNo][INT] NOT NULL REFERENCES [SystemDebtorsMainClasses] (TransactionId))"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = DefaultCursor
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On System Debtors Main Classes Table Create"
        ShowErrorMessage()
    End Sub

End Class