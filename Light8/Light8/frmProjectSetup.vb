Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmProjectSetup

    Private Sub btnAddResource_Click(sender As System.Object, e As System.EventArgs) Handles btnAddResource.Click
        boolEditStatus = False
        Dim frm As New frmProjectResources
        frm.ShowDialog()
        LoadResources()
    End Sub

    Private Sub LoadResources()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT ResourceName AS [Resource], Grouping as [Group], " _
            & "Telephone as [Telephone], FaxNumber AS [Fax], EmailAddress as [Email], " _
            & "CAST(UnitCost AS DECIMAL (30,2)) AS [Unit Cost], CAST(Quantity AS DECIMAL (30,2)) AS [Quantity], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), StartDate, 106), ' ', '-')) as [Start Date], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), EndDate, 106), ' ', '-')) as [End Date], [TransactionId] AS [ID] " _
            & "FROM ProjectResources WHERE ContractNumber = " & intSelectedProjectNumber & ""
        dGridResources.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridResources.DataSource = dTable

        Me.dGridResources.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGridResources.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGridResources.Columns.Count - 1
            dGridResources.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            If p >= 5 And p <= 6 Then
                dGridResources.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGridResources.Columns(p).DefaultCellStyle.Format = "N2"
            End If
            If p = dGridResources.ColumnCount - 1 Then
                dGridResources.Columns(p).Visible = False
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Project Resources Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadMainDetails()
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
            If Not IsDBNull(objReader("Owner").ToString) Then
                'Keep the saved owner selectable even when that person is no longer in the employee list
                Dim strOwner As String = objReader("Owner").ToString
                If strOwner <> "" AndAlso cboPersonnel.Items.IndexOf(strOwner) < 0 Then cboPersonnel.Items.Add(strOwner)
                cboPersonnel.Text = strOwner
            End If
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

    Private Sub frmProjectSetup_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadResources()
        dGridResources.Columns(0).DefaultCellStyle.BackColor = Color.WhiteSmoke
        LoadCustomers()
        LoadEmployees()
        If boolEditStatus = False Then
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("ProjectsNumber"))
            'Started from a client's project list: the client is already known
            If Not String.IsNullOrEmpty(GtiPresetProjectCustomerNumber) Then
                cboClient.Text = UCase(GtiPresetProjectCustomerName & "")
                txtCustomerNumber.Text = GtiPresetProjectCustomerNumber
                'Lock the client so it cannot be changed by accident while the other fields are filled in
                cboClient.Enabled = False : txtCustomerNumber.Enabled = False
                btnFindAccount.Enabled = False : btnAddNew.Enabled = False
            End If
        Else
            txtReference.Text = intSelectedProjectNumber
            LoadMainDetails()
            LoadCashbookTransactions()
        End If
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
        gwt_comm.CustomerSearch()
        If boolAbort = True Then Exit Sub
        txtCustomerNumber.Text = strSelectedAccount
        cboClient.Text = strSelectedAccountName
    End Sub

    Private Sub btnAddExpense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddExpense.Click
        If boolEditStatus = False Then
            MessageBox.Show("Transactions cannot be entered while you are creating a new project", "Process Ignored", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Not IsNumeric(txtReference.Text) Then
            MessageBox.Show("Application has detected an invalid project number. Please check", "Invalid Project Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        lngPublicLinkedProjectNumber = CLng(txtReference.Text)

        boolAbort = False
        gwt_comm.CashbookSelection()
        If boolAbort = True Then Exit Sub

        boolCalledFromProjects = True

        Dim f As New frmCashbookDataEntry
        f.ShowDialog()

        boolCalledFromProjects = False
        strPublicActiveCashbook = Nothing
        LoadCashbookTransactions()
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
                Dim intKey As Integer = CInt(dGridCredits.CurrentRow.Cells(9).Value.ToString)
                If intKey = 0 Then
                    MessageBox.Show("This transaction cannot be deleted. To reverse this transaction use the journal entry module. " _
                        & "For assistance consult your Business Light consultant", "Legacy Transaction Delete Issue",
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
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Cashbook Transactions Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEditResource_Click(sender As System.Object, e As System.EventArgs) Handles btnEditResource.Click
        EditResource()
    End Sub

    Private Sub btnDeleteResource_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteResource.Click
        On Error GoTo RaiseErr
        If dGridResources.RowCount <= 0 Then Exit Sub
        boolEditStatus = True
        intSelectedTransaction = CInt(dGridResources.CurrentRow.Cells(dGridResources.ColumnCount - 1).Value.ToString)
        If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM ProjectResources WHERE TransactionId = " & intSelectedTransaction & "", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Record has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadResources()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Resource Entry Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGridResources_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridResources.CellDoubleClick
        EditResource()
    End Sub

    Private Sub EditResource()
        If dGridResources.RowCount <= 0 Then Exit Sub
        boolEditStatus = True
        intSelectedTransaction = CInt(dGridResources.CurrentRow.Cells(dGridResources.ColumnCount - 1).Value.ToString)
        Dim frm As New frmProjectResources
        frm.ShowDialog()
        LoadResources()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOk.Click
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

        'A project started from a client's project list always belongs to that client
        If boolEditStatus = False AndAlso Not String.IsNullOrEmpty(GtiPresetProjectCustomerNumber) Then
            txtCustomerNumber.Text = GtiPresetProjectCustomerNumber
        End If

        If Not IsNumeric(txtContractValue.Text) Then txtContractValue.Text = "0.00"
        If Not IsNumeric(txtRevisedValue.Text) Then txtRevisedValue.Text = "0.00"

        If boolEditStatus = True Then
            'Update the project in place. The record used to be deleted and added again, which
            'cleared the variation orders, the consultants and the site details of the project.
            GtiExecute("UPDATE ProjectsMain SET [TakeOnDate] = ?, [ContractName] = ?, [CustomerNumber] = ?, " _
                & "[InitialValue] = ?, [RevisedValue] = ?, [Owner] = ? WHERE [ContractNumber] = ?",
                dpTakeonDate.Value.Date, txtContractName.Text, txtCustomerNumber.Text, CDbl(txtContractValue.Text),
                CDbl(txtRevisedValue.Text), cboPersonnel.Text, intSelectedProjectNumber)
        Else
            GtiExecute("INSERT INTO ProjectsMain ([ContractNumber],[TakeOnDate],[ContractName],[CustomerNumber]," _
                & "[InitialValue],[RevisedValue],[Owner]) VALUES (?, ?, ?, ?, ?, ?, ?)",
                CInt(txtReference.Text), dpTakeonDate.Value.Date, txtContractName.Text, txtCustomerNumber.Text,
                CDbl(txtContractValue.Text), CDbl(txtRevisedValue.Text), cboPersonnel.Text)
        End If

        If boolEditStatus = False Then
            objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET ProjectsNumber = " & txtReference.Text & "", cnn)
            objCommand.ExecuteNonQuery()
        End If

        MessageBox.Show("Project details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On contact details setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmProjectSetup_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 670 : Me.Height = 475
    End Sub

End Class
