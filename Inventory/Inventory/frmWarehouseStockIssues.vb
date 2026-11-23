Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmWarehouseStockIssues

    Dim arrPrintData As ArrayList

    Private Sub LoadBranches()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT BranchName FROM Branches ORDER BY BranchName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboBranches.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Transfer"
        ShowErrorMessage()
    End Sub

    Private Sub LoadPersonnel()
        On Error GoTo RaiseErr
        'Load the employee details
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames " _
            & "AS [EmployeeDetails] FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        cboPersonnel.Items.Clear()
        cboPersonnel.Items.Add("")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboPersonnel.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT ItemCode +';'+GroupName +';'+ InventoryType AS " _
            & "[Items] FROM InventoryItems ORDER BY ItemCode"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 3
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "300;150;50"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboItems.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)), UCase(strRecordText(2)))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboItems.SelectedIndex = -1
            cboItems.Items.Clear()
            cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboItems.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboItems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboItems.KeyPress
        lblDescription.Text = ""
    End Sub

    Private Sub cboItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.SelectedIndexChanged
        On Error Resume Next
        lblAvailability.Text = ""
        lblDescription.Text = ""
        lblItemType.Text = ""
        lblDescription.Text = cboItems.SelectedItem.Col2
        lblItemType.Text = cboItems.SelectedItem.Col3
    End Sub

    Private Sub frmWarehouseStockIssues_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If strStoresOperationType = "RETURN" Then
            Me.Text = "Stores Item Return"
            Me.lblIndicator.BackColor = Color.Firebrick
            lblIndicator.Text = "Item Return"
        End If
        txtQuantity.Enabled = False
        LoadBranches()
        LoadData()
        LoadPersonnel()
        txtBarcode.Focus()
    End Sub

    Private Sub btnSerials_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerials.Click
        If String.IsNullOrEmpty(cboItems.Text) Then
            MessageBox.Show("Please type in the item code first", "Invalid Item Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboItems.Focus()
            Exit Sub
        End If
        strSerialNumberForTransfer = Nothing
        strPublicItemCode = cboItems.Text
        boolAbort = False
        Dim f As New frmSerialNumberSelection
        f.ShowDialog()
        If boolAbort = True Then Exit Sub

        If arrSelectedSerialNumbers.Count > 0 Then
            txtSerialNumbers.Text = arrSelectedSerialNumbers.Item(0)
            txtQuantity.Text = "1"
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Or IntPublicStoresManagement > 0 Then
            AddItem()
        Else
            MessageBox.Show("You do not have enough rights to access this module. Process aborted", "Access Violation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub AddItem()
        If String.IsNullOrEmpty(lblDescription.Text) Then
            MessageBox.Show("Please enter a valid item code", "Invalid Item Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboItems.Focus()
            Exit Sub
        End If
        If strStoresOperationType = "ISSUE" Then
            If UCase(lblAvailability.Text) = "OUT OF STORES" Then
                MessageBox.Show("Item cannot be issued as already issued from stores", "Item Not Available For Issue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtSerialNumbers.Focus()
                Exit Sub
            End If
        End If
        With dGrid
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = cboItems.Text
            .Rows(.Rows.Count - 1).Cells(1).Value = lblDescription.Text
            .Rows(.Rows.Count - 1).Cells(2).Value = txtSerialNumbers.Text
            .Rows(.Rows.Count - 1).Cells(3).Value = txtQuantity.Text
        End With
        lblDescription.Text = ""
        txtQuantity.Text = "1"
        txtSerialNumbers.Clear()
        txtBarcode.Clear()
        cboItems.Text = ""
        lblItemType.Text = ""
        txtQuantity.Enabled = False
        txtSerialNumbers.Enabled = True
    End Sub

    Private Sub dGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dGrid.CellValidating
        If dGrid.CurrentCell.ColumnIndex = 3 Then
            If Not IsNumeric(dGrid.CurrentCell.Value) Then
                MessageBox.Show("Quantity must be numeric", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dGrid.CurrentCell.Value = "0"
            End If
        End If
    End Sub

    Private Sub dGrid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dGrid.KeyPress
        If dGrid.CurrentCell.ColumnIndex = 3 Then
            If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
            If e.KeyChar = "." Then e.Handled = True
            If Not IsNumeric(e.KeyChar) Then e.Handled = True
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If strStoresOperationType = "ISSUE" Then ProcessTransaction() Else ProcessReturn()
    End Sub

    Private Sub ProcessReturn()
        On Error GoTo RaiseErr
        arrPrintData = New ArrayList
        If String.IsNullOrEmpty(cboPersonnel.Text) Then
            MessageBox.Show("Please select the name of the person collecting the items", "Missing Collecting Person", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPersonnel.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboBranches.Text) Then
            MessageBox.Show("Please select the name of the receiving branch", "Missing Receiving Branch", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboBranches.Focus()
            Exit Sub
        End If
        For n As Integer = 0 To dGrid.Rows.Count - 1

            Dim strSerials As String = Nothing
            Dim intQty As Integer = 0
            Dim strItemCode As String = Nothing
            Dim strDescript As String = Nothing

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(0).Value), "")) Then
                strItemCode = Convert.ToString(dGrid.Rows(n).Cells(0).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(1).Value), "")) Then
                strDescript = Convert.ToString(dGrid.Rows(n).Cells(1).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(2).Value), "")) Then
                strSerials = Convert.ToString(dGrid.Rows(n).Cells(2).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(3).Value), "")) Then
                If IsNumeric(dGrid.Rows(n).Cells(3).Value.ToString) Then
                    intQty = Convert.ToString(dGrid.Rows(n).Cells(3).Value)
                End If
            End If

            If Not String.IsNullOrEmpty(strItemCode) Then
                Dim strSql As String = "INSERT INTO StoresReturns ([TransactionDate],[ItemCode],[Description]," _
                    & "[SerialNumbers],[Quantity],[ReturnedBy],[OriginatingBranch],[UserBranch]) VALUES " _
                    & "('" & Format(dpDate.Value, "dd-MMM-yyyy") & "','" & strItemCode & "', '" & strDescript & "', " _
                    & "'" & strSerials & "', " & intQty & ", '" & cboPersonnel.Text & "', '" & cboBranches.Text & "', " _
                    & "'" & strUserBranch & "')"
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                'Update the serial numbers availabilty flag
                objCommand = New Data.OleDb.OleDbCommand("UPDATE SerialNumbers SET Availability = 'Y' WHERE ItemCode = '" & strItemCode & "' AND SerialNumber = '" & strSerials & "'", cnn)
                objCommand.ExecuteNonQuery()
                arrPrintData.Add(strItemCode & ";" & strDescript & ";" & strSerials & ";" & intQty)
            End If
        Next
        MessageBox.Show("Process executed successfully", "Stores Stock Item Return", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtQuantity.Text = "1"
        cboItems.Text = ""
        dGrid.Rows.Clear()
        lblDescription.Text = ""
        txtSerialNumbers.Clear()
        txtBarcode.Focus()
        lblItemType.Text = ""
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Stores Item Return Processing"
        ShowErrorMessage()
    End Sub

    Private Sub ProcessTransaction()
        On Error GoTo RaiseErr
        arrPrintData = New ArrayList
        If String.IsNullOrEmpty(cboPersonnel.Text) Then
            MessageBox.Show("Please select the name of the person collecting the items", "Missing Collecting Person", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPersonnel.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboBranches.Text) Then
            MessageBox.Show("Please select the name of the receiving branch", "Missing Receiving Branch", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboBranches.Focus()
            Exit Sub
        End If
        For n As Integer = 0 To dGrid.Rows.Count - 1

            Dim strSerials As String = Nothing
            Dim intQty As Integer = 0
            Dim strItemCode As String = Nothing
            Dim strDescript As String = Nothing

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(0).Value), "")) Then
                strItemCode = Convert.ToString(dGrid.Rows(n).Cells(0).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(1).Value), "")) Then
                strDescript = Convert.ToString(dGrid.Rows(n).Cells(1).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(2).Value), "")) Then
                strSerials = Convert.ToString(dGrid.Rows(n).Cells(2).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(3).Value), "")) Then
                If IsNumeric(dGrid.Rows(n).Cells(3).Value.ToString) Then
                    intQty = Convert.ToString(dGrid.Rows(n).Cells(3).Value)
                End If
            End If

            If Not String.IsNullOrEmpty(strItemCode) Then
                Dim strSql As String = "INSERT INTO StoresIssues ([TransactionDate],[ItemCode],[Description]," _
                    & "[SerialNumbers],[Quantity],[CollectedBy],[DestinationBranch],[UserBranch]) VALUES " _
                    & "('" & Format(dpDate.Value, "dd-MMM-yyyy") & "','" & strItemCode & "', '" & strDescript & "', " _
                    & "'" & strSerials & "', " & intQty & ", '" & cboPersonnel.Text & "', '" & cboBranches.Text & "', " _
                    & "'" & strUserBranch & "')"
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                'Update the serial numbers availabilty flag
                objCommand = New Data.OleDb.OleDbCommand("UPDATE SerialNumbers SET Availability = 'N' WHERE ItemCode = '" & strItemCode & "' AND SerialNumber = '" & strSerials & "'", cnn)
                objCommand.ExecuteNonQuery()
                arrPrintData.Add(strItemCode & ";" & strDescript & ";" & strSerials & ";" & intQty)
            End If
        Next
        MessageBox.Show("Process executed successfully", "Stores Stock Transfers", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtQuantity.Text = "1"
        cboItems.Text = ""
        dGrid.Rows.Clear()
        lblDescription.Text = ""
        txtSerialNumbers.Clear()
        txtBarcode.Focus()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Stores Transfer Processing"
        ShowErrorMessage()
    End Sub

    Private Sub ProcessBarcodeData()

        On Error GoTo RaiseErr

        lblAvailability.Text = ""
        boolAbort = False
        Dim strValues() As String = gwt_comm.ReadBarcode(txtBarcode.Text)
        If boolAbort = True Then Exit Sub

        'The return array contains the item code, transactionid, Foundstatus, serial number

        If Not String.IsNullOrEmpty(strValues(0)) Then
            cboItems.SelectedText = strValues(0)
            'Get the description and item type
            Dim objGetDetails As New Data.OleDb.OleDbCommand("SELECT GroupName, InventoryType FROM InventoryItems " _
                & "WHERE ItemCode = '" & Trim(strValues(0)) & "'", cnn)
            Dim objReadDetails As Data.OleDb.OleDbDataReader = objGetDetails.ExecuteReader
            If objReadDetails.HasRows Then
                objReadDetails.Read()
                If Not IsDBNull(objReadDetails(0).ToString) Then lblDescription.Text = objReadDetails(0).ToString
                If Not IsDBNull(objReadDetails(1).ToString) Then lblItemType.Text = objReadDetails(1).ToString
            End If
            objReadDetails.Close()
            txtSerialNumbers.Text = strValues(3)
            btnAdd.Focus()
        Else
            MessageBox.Show("Item barcode not found in the system", "Invalid Item Bar Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error Encountered while attempting to read scanned barcode"
        ShowErrorMessage()
    End Sub

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            If String.IsNullOrEmpty(txtBarcode.Text) Then Exit Sub
            ProcessBarcodeData()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Stores Transfer Processing"
        ShowErrorMessage()
    End Sub

    Private Sub txtQuantity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
        If Asc(e.KeyChar) = 13 Then btnAdd.Focus()
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub lblItemType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblItemType.TextChanged
        If UCase(lblItemType.Text) = "GENERIC" Then txtQuantity.Enabled = True Else txtQuantity.Enabled = False
    End Sub

    Private Sub txtSerialNumbers_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerialNumbers.Validated
        On Error GoTo RaiseErr
        'Check that the item has not as yet been flagged out from the stores
        If String.IsNullOrEmpty(txtSerialNumbers.Text) Then Exit Sub
        If String.IsNullOrEmpty(cboItems.Text) Then Exit Sub
        If strStoresOperationType = "ISSUE" Then
            If UCase(lblItemType.Text) = "SPECIFIC" Then
                Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Availability FROM SerialNumbers " _
                    & "WHERE ItemCode = '" & cboItems.Text & "' AND SerialNumber = '" & txtSerialNumbers.Text & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If UCase(objReader(0).ToString) = "N" Then
                        lblAvailability.Visible = True
                        lblAvailability.Text = "OUT OF STORES"
                    Else
                        lblAvailability.Visible = False
                        lblAvailability.Text = ""
                    End If
                End If
                objReader.Close()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Serial number availability check failure"
        ShowErrorMessage()
    End Sub

    Private Sub txtSerialNumbers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerialNumbers.TextChanged
        On Error GoTo RaiseErr
        'Check that the item has not as yet been flagged out from the stores
        If String.IsNullOrEmpty(txtSerialNumbers.Text) Then Exit Sub
        If String.IsNullOrEmpty(cboItems.Text) Then Exit Sub
        If strStoresOperationType = "ISSUE" Then
            If UCase(lblItemType.Text) = "SPECIFIC" Then
                Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Availability FROM SerialNumbers " _
                    & "WHERE ItemCode = '" & cboItems.Text & "' AND SerialNumber = '" & txtSerialNumbers.Text & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If UCase(objReader(0).ToString) = "N" Then
                        lblAvailability.Visible = True
                        lblAvailability.Text = "OUT OF STORES"
                    Else
                        lblAvailability.Visible = False
                        lblAvailability.Text = ""
                    End If
                End If
                objReader.Close()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Serial number availability check failure"
        ShowErrorMessage()
    End Sub

End Class