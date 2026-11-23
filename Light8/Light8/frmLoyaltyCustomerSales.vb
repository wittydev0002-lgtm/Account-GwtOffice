Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoyaltyCustomerSales

    '    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
    '        strPublicItemCode = Nothing
    '        strPublicItemDescription = Nothing
    '        boolAbort = False
    '        Dim f As New frmBrowseCustomer
    '        f.ShowDialog()
    '        If boolAbort = True Then Exit Sub
    '        txtLoyalityAccount.Text = strPublicItemCode
    '        txtLoyalityAccountHolder.Text = strPublicItemDescription
    '        CheckCustomerData()
    '    End Sub

    '    Private Sub btnAddNewCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewCustomer.Click
    '        boolEditStatus = False
    '        Dim f As New frmLoyalityCustomers
    '        f.ShowDialog()
    '    End Sub

    '    Private Sub CheckCustomerData()
    '        On Error GoTo RaiseErr
    '        If String.IsNullOrEmpty(txtLoyalityAccount.Text) Then Exit Sub
    '        txtLoyalityAccountHolder.Text = ""
    '        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName FROM " _
    '            & "LoyalityCustomers WHERE AccountNumber = '" & txtLoyalityAccount.Text & "'", cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '        If objReader.HasRows Then
    '            objReader.Read()
    '            If Not IsDBNull(objReader(0).ToString) Then txtLoyalityAccountHolder.Text = objReader(0).ToString
    '            'Read the loyality table visits and determine if this is a free service or not
    '            objCommand = New Data.OleDb.OleDbCommand("SELECT Count(TransactionId) FROM LoyalityEntries WHERE " _
    '                & "AccountNumber = '" & txtLoyalityAccount.Text & "'", cnn)
    '            Dim objReadVisits As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '            Dim intNumberOfVisits As Integer = 1
    '            If objReadVisits.HasRows Then
    '                objReadVisits.Read()
    '                If IsNumeric(objReadVisits(0).ToString) Then intNumberOfVisits = intNumberOfVisits + CInt(objReadVisits(0).ToString)
    '                If IsFreeService(intNumberOfVisits) = True Then
    '                    MessageBox.Show("The client is due for free service", MsgBoxStyle.Information, "Free Service")
    '                    'If IsNumeric(txtPriceOnSale.Text) Then
    '                    '    If IsNumeric(txtSalesQty.Text) Then
    '                    '        txtSalesDiscount.Text = CDbl(txtSalesQty.Text) * CDbl(txtPriceOnSale.Text)
    '                    '        txtSalesDiscount.Text = Format(CDbl(txtSalesDiscount.Text), "##0.00")
    '                    '        txtCurrentPayable.Text = "0.00"
    '                    '        txtSalesTax.Text = "0.00"
    '                    '    End If
    '                    'End If
    '                End If
    '            End If
    '            objReadVisits.Close()
    '        Else
    '            MessageBox.Show("The account number entered is not correct. Please re-enter", MsgBoxStyle.Exclamation, "Invalid Account Number")
    '            txtLoyalityAccount.SelectAll()
    '            txtLoyalityAccount.Focus()
    '            Exit Sub
    '        End If
    '        objReader.Close()
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " " & Err.Number & " on Loyality Account Number Search"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    Private Sub frmLoyaltyCustomerSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCustomers()
    End Sub

    Private Sub frmLoyaltyCustomerSales_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Width = 605 : Me.Height = 340 '605; 340
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        strSelectedAccount = txtAccountNumber.Text
        strSelectedCustomerName = cboAccountName.Text
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub LoadCustomers()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT LastName +' '+FirstName +' '+ OtherNames +';'+ AccountNumber AS [Customer] " _
            & "FROM LoyalityCustomers ORDER BY LastName, FirstName, OtherNames"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Set up the drop down combo box
        Dim intWidth As Integer = cboAccountName.Width - 50
        With cboAccountName
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "160;" & intWidth - 160


            'Get a count of the items
            Dim intItemsCount As Double = 0

            sqlCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(AccountNumber) FROM LoyalityCustomers", cnn)
            Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
            If objCount.HasRows Then
                objCount.Read()
                If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
            End If
            objCount.Close()

            Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

            .Items.Clear()
            Dim p As Double = 0

            'Continue to read until you reach the end of the file.
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                    DropDownItems(p) = New MTGCComboBoxItem(UCase(Trim(strRecordText(0))), UCase(strRecordText(1)))
                End If
                p = p + 1
            End While
            objReader.Close()

            If intItemsCount > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " On customers details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboAccountName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccountName.SelectedIndexChanged
        txtAccountNumber.Clear()
        If Not cboAccountName.SelectedItem Is Nothing Then
            txtAccountNumber.Text = cboAccountName.SelectedItem.Col2
            LoadSelectedCustomerDetails(txtAccountNumber.Text)
        Else
            txtAccountNumber.Text = Nothing
        End If
    End Sub

    Private Sub LoadSelectedCustomerDetails(ByVal AccountNumber As String)
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Address1, Address2, Address3, Address4, " _
            & "IdNumber FROM LoyalityCustomers WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim strAddress As String = Nothing
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then txtAddress1.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtAddress2.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtAddress3.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then txtAddress4.Text = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then txtIdNumber.Text = objReader(4).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " On selected customers details load"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
