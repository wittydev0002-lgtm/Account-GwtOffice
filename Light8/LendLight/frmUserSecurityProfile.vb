Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmUserSecurityProfile

    Dim arrUserOptions As ArrayList

    Private Sub frmUserSecurityProfile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Add the security attributes
        pbStrength.Maximum = 100 : pbStrength.Value = 0 : pbStrength.Visible = True
        With dGrid
            .Rows.Add("Quotations")
            .Rows.Add("Invoicing")
            .Rows.Add("Customers")
            .Rows.Add("Suppliers")
            .Rows.Add("Sales Agents")
            .Rows.Add("Inventory")
            .Rows.Add("Cash Sales")
            .Rows.Add("Store Management")
            .Rows.Add("Receive Goods")
            .Rows.Add("Cashbook Entries")
            .Rows.Add("Stock Take")
            .Rows.Add("Ledger Entries")
            .Rows.Add("Asset Management")
            .Rows.Add("Print Statements")
            .Rows.Add("Print Ledgers")
            .Rows.Add("Print Trial Balance")
            .Rows.Add("Bank Reconciliation")
            .Rows.Add("Setup Cashbook")
            .Rows.Add("Setup Branches")
            .Rows.Add("Setup Control Numbers")
            .Rows.Add("Transfer Stock")
            .Rows.Add("Setup Default Sales Account")
            .Rows.Add("Re-initialize Inventory Quantities")
            .Rows.Add("Define Server Backup")
            .Rows.Add("Setup Setup Categories")
            .Rows.Add("Web Stock Uploads")
            .Rows.Add("Web Stock Downloads")
            .Rows.Add("Web Sales Downloads")
            .Rows.Add("Web Sales Uploads")
            .Rows.Add("Web Cashbook Transactions Uploads")
            .Rows.Add("Web Cashbook Transactions Downloads")
            .Rows.Add("Expenses")
            .Rows.Add("Exchanges and Topups")
            .Rows.Add("User Setup")
            .Rows.Add("Prescribed Drugs")
            .Rows.Add("Returns and Rejections Management")
        End With
        LoadBranches()
        If boolEditStatus = True Then
            LoadData()
            txtUserPassword.Enabled = False
            txtConfirmPassword.Enabled = False
        End If

    End Sub

    Private Sub dGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dGrid.MouseUp
        If dGrid.CurrentCell.ColumnIndex = 0 Then Exit Sub
        'Get the current cell
        On Error GoTo RaiseErr
        Dim cell As DataGridViewCheckBoxCell = Me.dGrid.CurrentCell
        'Get the value of the current cell
        Dim checked As Boolean = cell.GetEditedFormattedValue(cell.RowIndex, DataGridViewDataErrorContexts.Parsing)
        'Change the other cell to the opposite value
        If checked = True Then
            If cell.ColumnIndex = 1 Then
                Me.dGrid.CurrentRow.Cells(2).Value = False
                Me.dGrid.CurrentRow.Cells(3).Value = False
            ElseIf cell.ColumnIndex = 2 Then
                Me.dGrid.CurrentRow.Cells(1).Value = False
                Me.dGrid.CurrentRow.Cells(3).Value = False
            ElseIf cell.ColumnIndex = 3 Then
                Me.dGrid.CurrentRow.Cells(1).Value = False
                Me.dGrid.CurrentRow.Cells(2).Value = False
            End If
        End If
        Me.dGrid.EndEdit()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On User Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Check that the user given names have been entered as well
        If String.IsNullOrEmpty(txtGivenNames.Text) Then
            MessageBox.Show("Please enter the user's given names", "Missing Given Names", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGivenNames.Focus()
            Exit Sub
        End If
        'Check the organisation password policy


        If strPasswordComplexity.ToUpper = "YES" Then
            If pbStrength.Value <= 50 Then
                MessageBox.Show("The password does not meet the minimum complexity level. " _
                    & "Please re-enter and include special characters", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        If txtConfirmPassword.Text <> txtUserPassword.Text Then
            MessageBox.Show("The confirmed password differs from the password", "Password Inconsistence", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUserPassword.Focus()
            txtUserPassword.SelectAll()
            Exit Sub
        End If
        'check that the other fields have been entered
        If txtUserName.Text = "" Or Mid(txtUserName.Text, 1, 1) = " " _
        Or txtUserPassword.Text = "" Or Mid(txtUserPassword.Text, 1, 1) = " " _
        Or txtConfirmPassword.Text = "" Or Mid(txtConfirmPassword.Text, 1, 1) = " " Then
            MessageBox.Show("One or more of the mandatory fields is missing. Please re-enter", "Missing Mandatory Data Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUserName.Focus()
            Exit Sub
        End If

        GetSelectedValues()

        On Error GoTo RaiseErr

        Dim strInUserName As String = Nothing
        Dim strInUserPassword As String = Nothing
        Dim strInUserLevel As String = Nothing
        Dim strInBranchName As String = Nothing
        Dim strInChangeDate As String = Nothing
        Dim strInEmailAddress As String = Nothing
        Dim IntQuotations As Integer = 0
        Dim IntInvoicing As Integer = 0
        Dim IntCustomers As Integer = 0
        Dim IntSuppliers As Integer = 0
        Dim IntSalesAgents As Integer = 0
        Dim IntInventory As Integer = 0
        Dim IntCashSales As Integer = 0
        Dim IntStoresManagement As Integer = 0
        Dim IntReceiveGoods As Integer = 0
        Dim IntCashbookEntries As Integer = 0
        Dim IntStockTake As Integer = 0
        Dim IntLedgerEntries As Integer = 0
        Dim IntAssetManagement As Integer = 0
        Dim IntPrintStatements As Integer = 0
        Dim IntPrintLedgers As Integer = 0
        Dim IntPrintTrialBalance As Integer = 0
        Dim IntBankReconciliation As Integer = 0
        Dim IntCashbookSetup As Integer = 0
        Dim IntBranchSetup As Integer = 0
        Dim IntControlNumbersSetup As Integer = 0
        Dim IntTransferStock As Integer = 0
        Dim IntDefaultSalesAccountSetup As Integer = 0
        Dim IntReinitialiseInventoryQuantities As Integer = 0
        Dim IntDefineServerBackupPath As Integer = 0
        Dim IntCategoriesSetup As Integer = 0
        Dim IntStockDataUpload As Integer = 0
        Dim IntStockDataDownload As Integer = 0
        Dim IntSalesDataDownloads As Integer = 0
        Dim IntSalesDataUploads As Integer = 0
        Dim IntCashbookDataUpload As Integer = 0
        Dim IntCashbookDataDownload As Integer = 0
        Dim IntExpenses As Integer = 0
        Dim IntUserSetup As Integer = 0
        Dim IntExchanges As Integer = 0
        Dim intPrescribedDrugs As Integer = 0
        Dim intReturnsRejections As Integer = 0

        'Assign values to the relevent variables
        strInUserName = txtUserName.Text
        strInBranchName = cboLocation.Text
        strInChangeDate = CStr(gwt_comm.shortMonthDateFormat(Now))
        strInEmailAddress = txtEmailAddress.Text
        strInUserLevel = cboUserLevel.Text

        IntQuotations = CInt(arrUserOptions.Item(0))
        IntInvoicing = CInt(arrUserOptions.Item(1))
        IntCustomers = CInt(arrUserOptions.Item(2))
        IntSuppliers = CInt(arrUserOptions.Item(3))
        IntSalesAgents = CInt(arrUserOptions.Item(4))
        IntInventory = CInt(arrUserOptions.Item(5))
        IntCashSales = CInt(arrUserOptions.Item(6))
        IntStoresManagement = CInt(arrUserOptions.Item(7))
        IntReceiveGoods = CInt(arrUserOptions.Item(8))
        IntCashbookEntries = CInt(arrUserOptions.Item(9))
        IntStockTake = CInt(arrUserOptions.Item(10))
        IntLedgerEntries = CInt(arrUserOptions.Item(11))
        IntAssetManagement = CInt(arrUserOptions.Item(12))
        IntPrintStatements = CInt(arrUserOptions.Item(13))
        IntPrintLedgers = CInt(arrUserOptions.Item(14))
        IntPrintTrialBalance = CInt(arrUserOptions.Item(15))
        IntBankReconciliation = CInt(arrUserOptions.Item(16))
        IntCashbookSetup = CInt(arrUserOptions.Item(17))
        IntBranchSetup = CInt(arrUserOptions.Item(18))
        IntControlNumbersSetup = CInt(arrUserOptions.Item(19))
        IntTransferStock = CInt(arrUserOptions.Item(20))
        IntDefaultSalesAccountSetup = CInt(arrUserOptions.Item(21))
        IntReinitialiseInventoryQuantities = CInt(arrUserOptions.Item(22))
        IntDefineServerBackupPath = CInt(arrUserOptions.Item(23))
        IntCategoriesSetup = CInt(arrUserOptions.Item(24))
        IntStockDataUpload = CInt(arrUserOptions.Item(25))
        IntStockDataDownload = CInt(arrUserOptions.Item(26))
        IntSalesDataDownloads = CInt(arrUserOptions.Item(27))
        IntSalesDataUploads = CInt(arrUserOptions.Item(28))
        IntCashbookDataUpload = CInt(arrUserOptions.Item(29))
        IntCashbookDataDownload = CInt(arrUserOptions.Item(30))
        IntExpenses = CInt(arrUserOptions.Item(31))
        IntUserSetup = CInt(arrUserOptions.Item(32))
        IntExchanges = CInt(arrUserOptions.Item(33))
        intPrescribedDrugs = CInt(arrUserOptions.Item(34))
        intReturnsRejections = CInt(arrUserOptions.Item(35))

        'Whether you are in edit mode or new entry mode, delete any previous similar record
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM Users WHERE UserName = '" & txtUserName.Text & "'", Cnn)
        objCommand.ExecuteNonQuery()

        If boolEditStatus = False Then strInUserPassword = gwt_comm.UnEncryption(txtUserPassword.Text) Else strInUserPassword = txtUserPassword.Text

        Dim strSql As String = "INSERT INTO [Users] ([UserName],[UserPassword],[UserLevel],[BranchName]," _
            & "[ChangeDate],[EmailAddress],[Quotations],[Invoicing],[Customers] " _
            & ",[Suppliers],[SalesAgents],[Inventory],[CashSales],[StoresManagement],[ReceiveGoods],[CashbookEntries] " _
            & ",[StockTake],[LedgerEntries],[AssetManagement],[PrintStatements],[PrintLedgers],[PrintTrialBalance] " _
            & ",[BankReconciliation],[CashbookSetup],[BranchSetup],[ControlNumbersSetup],[TransferStock],[DefaultSalesAccountSetup] " _
            & ",[ReinitialiseInventoryQuantities],[DefineServerBackupPath],[CategoriesSetup],[StockDataUpload] " _
            & ",[StockDataDownload],[SalesDataDownloads],[SalesDataUploads],[CashbookDataUpload],[CashbookDataDownload] " _
            & ",[Expenses],[UserSetup],[Exchanges], [PrescribedDrugs], [ReturnsRejections], [GivenNames]) " _
            & " VALUES ('" & strInUserName & "', '" & strInUserPassword & "', '" & strInUserLevel & "', '" & strInBranchName & "', " _
            & "'" & strInChangeDate & "', '" & strInEmailAddress & "', " & IntQuotations & ", " & IntInvoicing & ", " & IntCustomers & ", " _
            & "" & IntSuppliers & ", " & IntSalesAgents & ", " & IntInventory & ", " & IntCashSales & ", " & IntStoresManagement & ", " _
            & "" & IntReceiveGoods & ", " & IntCashbookEntries & ", " & IntStockTake & ", " & IntLedgerEntries & ", " _
            & "" & IntAssetManagement & ", " & IntPrintStatements & ", " & IntPrintLedgers & ", " & IntPrintTrialBalance & ", " _
            & "" & IntBankReconciliation & ", " & IntCashbookSetup & ", " & IntBranchSetup & ", " & IntControlNumbersSetup & ", " _
            & "" & IntTransferStock & ", " & IntDefaultSalesAccountSetup & ", " & IntReinitialiseInventoryQuantities & ", " _
            & "" & IntDefineServerBackupPath & ", " & IntCategoriesSetup & ", " & IntStockDataUpload & ", " & IntStockDataDownload & ", " _
            & "" & IntSalesDataDownloads & ", " & IntSalesDataUploads & ", " & IntCashbookDataUpload & ", " & IntCashbookDataDownload & ", " _
            & "" & IntExpenses & ", " & IntUserSetup & ", " & IntExchanges & ", " & intPrescribedDrugs & ", " & intReturnsRejections & ", '" & txtGivenNames.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, Cnn)
        objCommand.ExecuteNonQuery()

        'Send a message to the group administrator
        If UCase(strMachineTillStatus) = "CASHOUT" Then
            If Not String.IsNullOrEmpty(strMobileAlertNumbers) Then
                Cursor = Cursors.WaitCursor
                Dim objSend As New SendHttpSms
                Dim strSmsMessage As String = "Abnormal user profile change. Changed from a cash-out machine. " _
                    & "Username is " & txtUserName.Text & " and password is " & txtUserPassword.Text _
                    & ". >>" & UCase(strUserBranch)
                Dim strStatus As String = objSend.InitializeHttpMessageSend(strMobileAlertNumbers, strSmsMessage)
                Cursor = Cursors.Default
            End If
        End If

        If MessageBox.Show("User has been set successfully. Do you want to add more users?", "User Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            For i As Integer = 0 To dGrid.Rows.Count - 1
                dGrid.Rows(i).Cells(1).Value = False
                dGrid.Rows(i).Cells(2).Value = False
                dGrid.Rows(i).Cells(3).Value = False
            Next
            txtConfirmPassword.Clear()
            txtUserName.Clear()
            txtUserPassword.Clear()
            txtEmailAddress.Clear()
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On User Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetSelectedValues()
        On Error GoTo RaiseErr
        arrUserOptions = New ArrayList
        Dim strValue As String = "0"
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If dGrid.Rows(p).Cells(1).Value = True Then strValue = "2"
            If dGrid.Rows(p).Cells(2).Value = True Then strValue = "1"
            If dGrid.Rows(p).Cells(3).Value = True Then strValue = "0"
            arrUserOptions.Add(strValue)
        Next
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On User Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        txtUserName.Enabled = False
        Dim strSql As String = "SELECT[UserName],[UserPassword],[UserLevel],[BranchName]," _
            & "[ChangeDate],[EmailAddress],[Quotations],[Invoicing],[Customers] " _
            & ",[Suppliers],[SalesAgents],[Inventory],[CashSales],[StoresManagement],[ReceiveGoods],[CashbookEntries] " _
            & ",[StockTake],[LedgerEntries],[AssetManagement],[PrintStatements],[PrintLedgers],[PrintTrialBalance] " _
            & ",[BankReconciliation],[CashbookSetup],[BranchSetup],[ControlNumbersSetup],[TransferStock],[DefaultSalesAccountSetup] " _
            & ",[ReinitialiseInventoryQuantities],[DefineServerBackupPath],[CategoriesSetup],[StockDataUpload] " _
            & ",[StockDataDownload],[SalesDataDownloads],[SalesDataUploads],[CashbookDataUpload],[CashbookDataDownload] " _
            & ",[Expenses],[UserSetup],[Exchanges], [PrescribedDrugs], [ReturnsRejections], [GivenNames] FROM USERS WHERE UserName = '" & strSelectedUser & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, Cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtUserName.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then
                txtUserPassword.Text = objReader(1).ToString
                txtConfirmPassword.Text = objReader(1).ToString
            End If
            If Not IsDBNull(objReader(2).ToString) Then cboUserLevel.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then cboLocation.Text = objReader(3).ToString
            If Not IsDBNull(objReader(5).ToString) Then txtEmailAddress.Text = objReader(5).ToString
            If Not IsDBNull(objReader("GivenNames").ToString) Then txtGivenNames.Text = objReader("GivenNames").ToString

            Dim p As Integer = 0
            For i As Integer = 6 To objReader.FieldCount - 1
                If IsNumeric(objReader(i).ToString) Then
                    Select Case CInt(objReader(i).ToString)
                        Case Is = 2
                            dGrid.Rows(p).Cells(1).Value = True
                        Case Is = 1
                            dGrid.Rows(p).Cells(2).Value = True
                        Case Is = 0
                            dGrid.Rows(p).Cells(3).Value = True
                    End Select
                End If
                p = p + 1
            Next
        End If

        pbStrength.Value = gwt_comm.PasswordStrength(txtUserPassword.Text)
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On User Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadBranches()
        Try
            Dim strSql As String = "SELECT BranchName FROM Branches"
            Dim MyCommand As New Data.OleDb.OleDbCommand(strSql, Cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = MyCommand.ExecuteReader()
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    cboLocation.Items.Add(objReader(0).ToString)
                End If
            End While
            objReader.Close()
            Exit Sub
        Catch ex As Exception
            boolAbort = True
            strErrorMessages = Err.Description & " error number " & vbCrLf & "Error Raised on Branches Load"
            gwt_comm.ShowErrorMessage()
            Exit Try
        End Try
    End Sub

    Private Sub txtUserPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserPassword.KeyPress
        pbStrength.Value = gwt_comm.PasswordStrength(txtUserPassword.Text & e.KeyChar)
    End Sub

End Class