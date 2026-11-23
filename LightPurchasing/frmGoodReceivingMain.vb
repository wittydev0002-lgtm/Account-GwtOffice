Imports CommonLibrary
Imports CommonLibrary.Commons

Public Class frmGoodReceivingMain

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmGoodReceivingMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        lblBatchNo.Text = NextDocumentNumber()
        LoadSuppliers()
        LoadBranches()
    End Sub

    Private Function NextDocumentNumber() As Integer
        'OrdersReceipt
        On Error GoTo RaiseErr
        Dim intReturn As Integer = 1
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT(BatchNo) FROM OrdersReceipt ORDER BY BatchNo DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intReturn = CInt(objReader(0).ToString) + 1
            End If
        End If
        Return intReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on next batch number fetch"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub LoadBranches()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT BranchName FROM Branches ORDER BY BranchName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboBranch.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Transfer"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmGoodReceivingMain_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 545 : Me.Height = 329
    End Sub

    Private Sub LoadSuppliers()
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM Suppliers ORDER BY AccountNumber"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        Dim intX1 As Integer = 260
        Dim intX2 As Integer = cboSupplierNameOrders.Width - (25 + intX1)
        With cboSupplierNameOrders
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intX1) & ";" & CStr(intX2)
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM Suppliers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboSupplierNameOrders.Items.Clear()
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
            cboSupplierNameOrders.SelectedIndex = -1
            cboSupplierNameOrders.Items.Clear()
            cboSupplierNameOrders.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboSupplierNameOrders.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Supplier Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboSupplierName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSupplierNameOrders.SelectedIndexChanged
        lblSupplierId.Text = ""
        lblVatNumber.Text = ""
        txtDescriptionOrders.Clear()
        If Not cboSupplierNameOrders.SelectedItem Is Nothing Then
            lblSupplierId.Text = cboSupplierNameOrders.SelectedItem.Col2
            GetSupplierVatNumber(cboSupplierNameOrders.SelectedItem.Col2)
        End If
    End Sub

    Private Sub GetSupplierVatNumber(SupplierNumber As String)
        On Error GoTo RaiseErr
        lblAddress.Text = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT VatNumber, Address1, Address2, Address3, Address4 " _
            & "FROM Suppliers WHERE AccountNumber = '" & SupplierNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                lblVatNumber.Text = UCase(objReader(0).ToString)
            End If
            If Not IsDBNull(objReader(1).ToString) Then lblAddress.Text = lblAddress.Text & objReader(1).ToString & vbCrLf
            If Not IsDBNull(objReader(2).ToString) Then lblAddress.Text = lblAddress.Text & objReader(2).ToString & vbCrLf
            If Not IsDBNull(objReader(3).ToString) Then lblAddress.Text = lblAddress.Text & objReader(3).ToString & vbCrLf
            If Not IsDBNull(objReader(4).ToString) Then lblAddress.Text = lblAddress.Text & objReader(4).ToString & vbCrLf
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on supplier vat number fetch"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click

        strSelectedAccount = Nothing
        strSelectedAccountName = Nothing
        strOrderDescription = Nothing
        strOrderDate = UCase(CStr(gwt_comm.shortMonthDateFormat(Now)))
        intSelectedBatchNumber = 0
        strSelectedVatNumber = Nothing
        strReceivingBranchName = Nothing

        If String.IsNullOrEmpty(lblSupplierId.Text) Then
            MessageBox.Show("Please select a valid supplier from the list", "Missing Supplier Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSupplierNameOrders.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboSupplierNameOrders.Text) Then
            MessageBox.Show("Please select a valid supplier from the list", "Missing Supplier Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSupplierNameOrders.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboBranch.Text) Then
            MessageBox.Show("Please select the receiving branch from the list", "Missing Receiving Branch Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboBranch.Focus()
            Exit Sub
        End If

        strSelectedAccount = lblSupplierId.Text
        strSelectedAccountName = cboSupplierNameOrders.Text
        strOrderDescription = txtDescriptionOrders.Text
        strOrderDate = UCase(CStr(gwt_comm.shortMonthDateFormat(dpDateOrders.Value)))
        intSelectedBatchNumber = CInt(lblBatchNo.Text)
        strSelectedVatNumber = lblVatNumber.Text
        strReceivingBranchName = cboBranch.Text
        intNewOrderNumber = gwt_comm.GetNextDocumentNumber("ORDERS")

        boolAbort = False
        Dim frm As New frmGoodsReceipt
        frm.ShowDialog()
        If boolAbort = False Then
            InitializeForm()
        Else
            Me.Close()
        End If

    End Sub

End Class
