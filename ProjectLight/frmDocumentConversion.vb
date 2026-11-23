Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports ComponentFactory.Krypton.Toolkit

Public Class frmDocumentConversion

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub cboSupplierName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSupplierName.SelectedIndexChanged
        txtAccountNumber.Clear()
        If Not cboSupplierName.SelectedItem Is Nothing Then
            txtAccountNumber.Text = cboSupplierName.SelectedItem.Col2
            LoadSelectedSupplierDetails(txtAccountNumber.Text)
        Else
            txtAccountNumber.Text = Nothing
        End If
    End Sub

    Private Sub LoadSelectedSupplierDetails(ByVal AccountNumber As String)
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Address1, Address2, Address3, Address4, " _
            & "PhoneNumber, EmailAddress, AccountName FROM Customers WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim strAddress As String = Nothing
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then strAddress = strAddress & objReader(0).ToString & vbCrLf
            If Not IsDBNull(objReader(1).ToString) Then strAddress = strAddress & objReader(1).ToString & vbCrLf
            If Not IsDBNull(objReader(2).ToString) Then strAddress = strAddress & objReader(2).ToString & vbCrLf
            If Not IsDBNull(objReader(3).ToString) Then strAddress = strAddress & objReader(3).ToString & vbCrLf
            If Not IsDBNull(objReader(4).ToString) Then strAddress = strAddress & objReader(4).ToString & vbCrLf
            If Not IsDBNull(objReader(5).ToString) Then strAddress = strAddress & objReader(5).ToString

            If String.IsNullOrEmpty(cboSupplierName.Text) Then
                If Not IsDBNull(objReader("AccountName").ToString) Then cboSupplierName.Text = objReader("AccountName").ToString
            End If
        End While
        txtAddress.Text = strAddress
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " On selected customer details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(cboSupplierName.Text) Then
            MessageBox.Show("Missing customer name. Please re-enter", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSupplierName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountNumber.Text) Then
            MessageBox.Show("Missing customer number. Please re-enter", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNumber.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboSupplierName.Text) Then
            MessageBox.Show("Missing customer address. Please re-enter", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress.Focus()
            Exit Sub
        End If

        boolAbort = False
        strPublicSelectedDocumentHolderAccount = cboSupplierName.Text
        strPublicSelectedDocumentHolderAccount = txtAccountNumber.Text
        dtSetDate = CDate(gwt_comm.shortMonthDateFormat(dpDateOn.Value))

        Me.Close()

    End Sub


    Private Sub frmDocumentConversion_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtAccountNumber.Enabled = False
        LoadCustomers()
        'Load the forwarded data
        cboSupplierName.Text = strSelectedAccountName
        txtAddress.Text = strPublicDeliverAddress1 & vbCrLf & strPublicDeliverAddress2 & _
            vbCrLf & strPublicDeliverAddress3 & vbCrLf & strPublicDeliverAddress4
        If String.IsNullOrEmpty(txtAccountNumber.Text) Then
            MessageBox.Show("It looks like this is a new customer. You must create the customer profile first before conversion to invoices", "New Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub LoadCustomers()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT AccountName +';'+AccountNumber AS [Customer] FROM Customers ORDER BY AccountName"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Set up the drop down combo box
        Dim intWidth As Integer = cboSupplierName.Width - 50
        With cboSupplierName
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

        cboSupplierName.Items.Clear()
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
            cboSupplierName.SelectedIndex = -1
            cboSupplierName.Items.Clear()
            cboSupplierName.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboSupplierName.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " On customers details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAddNew_Click(sender As System.Object, e As System.EventArgs) Handles btnAddNew.Click
        cboSupplierName.Text = ""
        txtAccountNumber.Clear()
        txtAddress.Clear()
        Dim boolPriorEditStatus As Boolean = boolEditStatus
        boolEditStatus = False
        Dim f As New frmCustomerDetails
        f.ShowDialog()
        boolEditStatus = boolPriorEditStatus
        LoadCustomers()
        cboSupplierName.Text = strSelectedAccountName
    End Sub

    Private Sub btnFindAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindAccount.Click
        strPublicItemCode = Nothing
        strPublicItemDescription = Nothing
        boolAbort = False
        Dim f As New frmBrowseDebtors
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        txtAccountNumber.Text = strPublicItemCode
        cboSupplierName.Text = strPublicItemDescription
    End Sub

End Class
