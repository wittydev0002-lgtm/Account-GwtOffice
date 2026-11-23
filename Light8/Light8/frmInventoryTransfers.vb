Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Transactions

Public Class frmInventoryTransfers

    Dim boolFormLoading As Boolean

    Dim boolBatchRecall As Boolean = False
    Dim boolStockUpdated As Boolean
    Dim arrPrintDetails As ArrayList
    Dim strValue As String
    Dim itm As Integer
    Dim intPage As Integer = 1
    Dim strSelectedReport As String
    Dim strNotes As String
    Dim i As Double = 0

    Dim strType As String

    Dim iNextNumber As Double = 1
    Dim boolPrintFromPreview As Boolean
    Dim boolExitingWhile As Boolean
    Dim iNextPassNumber As Integer

    Dim arrSourceSerials As ArrayList

    Dim strReportHeader As String

    Private Sub btnRecallBatch_Click(sender As System.Object, e As System.EventArgs) Handles btnRecallBatch.Click
        boolAbort = False
        boolBatchRecall = True
        Dim f As New frmWebBatchesView
        f.ShowDialog()
        If boolAbort = True Then
            boolBatchRecall = False
            Exit Sub
        End If

        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT InventoryTransfers.BatchNo, InventoryTransfers.ItemCode, " _
            & "InventoryItems.GroupName, InventoryTransfers.SourceBranch, " _
            & "InventoryTransfers.ReceivingBranch, InventoryTransfers.Quantity, " _
            & "InventoryTransfers.SerialNumbers, InventoryTransfers.Category, " _
            & "InventoryTransfers.SubCategory, InventoryTransfers.ItemType, " _
            & "InventoryTransfers.UnitPrice, InventoryTransfers.SourceSerialNo " _
            & "FROM InventoryTransfers LEFT OUTER JOIN InventoryItems " _
            & "ON InventoryTransfers.ItemCode = InventoryItems.ItemCode WHERE " _
            & "BatchNo = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        dGrid.Rows.Clear()
        Dim i As Integer = 0
        While objReader.Read
            With dGrid
                .Rows.Add(1)
                If Not IsDBNull(objReader(1).ToString) Then .Rows(.Rows.Count - 1).Cells(0).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then .Rows(.Rows.Count - 1).Cells(1).Value = objReader(2).ToString
                If Not IsDBNull(objReader(6).ToString) Then .Rows(.Rows.Count - 1).Cells(2).Value = objReader(6).ToString
                If Not IsDBNull(objReader(5).ToString) Then .Rows(.Rows.Count - 1).Cells(4).Value = objReader(5).ToString
                If Not IsDBNull(objReader(7).ToString) Then .Rows(.Rows.Count - 1).Cells(5).Value = objReader(7).ToString
                If Not IsDBNull(objReader(8).ToString) Then .Rows(.Rows.Count - 1).Cells(6).Value = objReader(8).ToString
                If Not IsDBNull(objReader(9).ToString) Then .Rows(.Rows.Count - 1).Cells(7).Value = objReader(9).ToString
                If Not IsDBNull(objReader(10).ToString) Then .Rows(.Rows.Count - 1).Cells(8).Value = objReader(10).ToString
                If Not IsDBNull(objReader(11).ToString) Then .Rows(.Rows.Count - 1).Cells(10).Value = objReader(11).ToString
            End With
        End While
        objReader.Close()
        'cboItems.Visible = False
        boolBatchRecall = False
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Batch Recall Data Population"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        AddItem()
        txtBarcode.Focus()
    End Sub

    Private Sub AddItem()
        On Error GoTo RaiseErr
        If UCase(lblItemType.Text) = "SPECIFIC" Then
            If String.IsNullOrEmpty(txtSerialNumbers.Text) Then
                MessageBox.Show("Please enter the serial number of the item to transfer", "Invalid Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        If Not String.IsNullOrEmpty(lblDescription.Text) Or Not String.IsNullOrEmpty(lblPrice.Text) _
            Or Not String.IsNullOrEmpty(lblItemType.Text) Or Not String.IsNullOrEmpty(cboItems.Text) Then
            Dim strSourceBarcode As String = Nothing
            Dim objCommand As Data.OleDb.OleDbCommand
            Dim objReader As Data.OleDb.OleDbDataReader
            If UCase(lblItemType.Text) = "SPECIFIC" Then
                If isItemAlreadyAdded(cboItems.Text, txtSerialNumbers.Text) = True Then
                    MessageBox.Show("Item cannot be added to transfer multiple time", "Process Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else
                    objCommand = New Data.OleDb.OleDbCommand("SELECT SourceSerialNo FROM SerialNumbers WHERE " _
                        & "ItemCode = '" & cboItems.Text & "' AND SerialNumber = '" & txtSerialNumbers.Text & "'", cnn)
                    objReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        If Not IsDBNull(objReader(0).ToString) Then strSourceBarcode = objReader(0).ToString
                    End If
                    objReader.Close()
                End If
            Else
                objCommand = New Data.OleDb.OleDbCommand("SELECT Barcode FROM GenericItemsBarcodes WHERE " _
                        & "ItemCode = '" & cboItems.Text & "'", cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then strSourceBarcode = objReader(0).ToString
                End If
                objReader.Close()
            End If
            With dGrid
                .Rows.Add(1)
                .Rows(.Rows.Count - 1).Cells(0).Value = cboItems.Text
                .Rows(.Rows.Count - 1).Cells(1).Value = lblDescription.Text
                .Rows(.Rows.Count - 1).Cells(2).Value = txtSerialNumbers.Text
                .Rows(.Rows.Count - 1).Cells(4).Value = txtQuantity.Text
                .Rows(.Rows.Count - 1).Cells(5).Value = lblCategory.Text
                .Rows(.Rows.Count - 1).Cells(6).Value = lblSubCategory.Text
                .Rows(.Rows.Count - 1).Cells(7).Value = lblItemType.Text
                .Rows(.Rows.Count - 1).Cells(8).Value = lblPrice.Text
                .Rows(.Rows.Count - 1).Cells(10).Value = strSourceBarcode
            End With
            lblCategory.Text = ""
            lblDescription.Text = ""
            lblItemType.Text = ""
            lblPrice.Text = "0.00"
            lblSubCategory.Text = ""
            cboItems.Text = ""
            txtSerialNumbers.Text = Nothing
            txtBarcode.Clear()
            txtBarcode.Focus()
            btnBulkItems.Enabled = False
        Else
            MessageBox.Show("Please enter a valid item code or barcode", "Invalid Item Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Web stock transfers"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnBulkItems_Click(sender As System.Object, e As System.EventArgs) Handles btnBulkItems.Click
        If String.IsNullOrEmpty(cboItems.Text) Then Exit Sub

        'If UCase(lblItemType.Text) = "SPECIFIC" Then
        '    If String.IsNullOrEmpty(txtSerialNumbers.Text) Then
        '        MessageBox.Show("Please enter the serial number of the item to transfer", "Invalid Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    End If
        'End If
        If String.IsNullOrEmpty(lblDescription.Text) Or String.IsNullOrEmpty(lblPrice.Text) _
            Or String.IsNullOrEmpty(lblItemType.Text) Or String.IsNullOrEmpty(cboItems.Text) Then
            Exit Sub
        End If

        If Not String.IsNullOrEmpty(lblDescription.Text) Or Not String.IsNullOrEmpty(lblPrice.Text) _
            Or Not String.IsNullOrEmpty(lblItemType.Text) Or Not String.IsNullOrEmpty(cboItems.Text) Then

            boolAbort = False
            strPublicItemCode = cboItems.Text
            Dim f As New frmMultipleSerialNumbersSelection
            f.ShowDialog()
            If boolAbort = True Then Exit Sub
            For i As Integer = 0 To arrSelectedSerialNumbers.Count - 1
                Dim strSourceBarcode As String = Nothing
                Dim objCommand As Data.OleDb.OleDbCommand
                Dim objReader As Data.OleDb.OleDbDataReader
                If UCase(lblItemType.Text) = "SPECIFIC" Then
                    If isItemAlreadyAdded(cboItems.Text, arrSelectedSerialNumbers(i)) = True Then
                        MessageBox.Show("Item cannot be added to transfer multiple time", "Process Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    Else
                        objCommand = New Data.OleDb.OleDbCommand("SELECT SourceSerialNo FROM SerialNumbers WHERE " _
                            & "ItemCode = '" & cboItems.Text & "' AND SerialNumber = '" & arrSelectedSerialNumbers(i) & "'", cnn)
                        objReader = objCommand.ExecuteReader
                        If objReader.HasRows Then
                            objReader.Read()
                            If Not IsDBNull(objReader(0).ToString) Then strSourceBarcode = objReader(0).ToString
                        End If
                        objReader.Close()
                    End If
                Else
                    objCommand = New Data.OleDb.OleDbCommand("SELECT Barcode FROM GenericItemsBarcodes WHERE " _
                            & "ItemCode = '" & cboItems.Text & "'", cnn)
                    objReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        If Not IsDBNull(objReader(0).ToString) Then strSourceBarcode = objReader(0).ToString
                    End If
                    objReader.Close()
                End If
                With dGrid
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = cboItems.Text
                    .Rows(.Rows.Count - 1).Cells(1).Value = lblDescription.Text
                    .Rows(.Rows.Count - 1).Cells(2).Value = arrSelectedSerialNumbers(i)
                    .Rows(.Rows.Count - 1).Cells(4).Value = txtQuantity.Text
                    .Rows(.Rows.Count - 1).Cells(5).Value = lblCategory.Text
                    .Rows(.Rows.Count - 1).Cells(6).Value = lblSubCategory.Text
                    .Rows(.Rows.Count - 1).Cells(7).Value = lblItemType.Text
                    .Rows(.Rows.Count - 1).Cells(8).Value = lblPrice.Text
                    .Rows(.Rows.Count - 1).Cells(10).Value = strSourceBarcode
                End With
            Next
            lblCategory.Text = ""
            lblDescription.Text = ""
            lblItemType.Text = ""
            lblPrice.Text = "0.00"
            lblSubCategory.Text = ""
            cboItems.Text = ""
            txtSerialNumbers.Text = Nothing
            txtBarcode.Clear()
            txtBarcode.Focus()
            btnBulkItems.Enabled = False
        End If
    End Sub

    Private Sub btnBulkItemsByBranch_Click(sender As System.Object, e As System.EventArgs) Handles btnBulkItemsByBranch.Click
        boolAbort = False
        gwt_comm.DateRangeSpecification()
        If boolAbort = True Then Exit Sub
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT OrdersReceipt.ItemCode, " _
            & "InventoryItems.GroupName, InventoryItems.Category, InventoryItems.SubCategory, " _
            & "InventoryItems.InventoryType, InventoryItems.SellingPrice, OrdersReceipt.Quantity, " _
            & "OrdersReceipt.SerialNumbers, OrdersReceipt.BaseBarCode +''+ OrdersReceipt.SerialNumbers AS [SourceSerialNo] " _
            & "FROM OrdersReceipt LEFT OUTER JOIN InventoryItems ON " _
            & "OrdersReceipt.ItemCode = InventoryItems.ItemCode " _
            & "WHERE OrdersReceipt.DestinationBranch = '" & cboBranches.Text & "' AND " _
            & "TransDate BETWEEN '" & StartDate & "' AND '" & EndDate & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read

            Dim strItemCde As String = Nothing
            Dim strDesc As String = Nothing
            Dim strSerial As String = Nothing
            Dim dblQty As Double = 0
            Dim strCat As String = Nothing
            Dim strSubCat As String = Nothing
            Dim strTyp As String = "GENERIC"
            Dim dblPrice As Double = 0
            Dim strSourceSerial As String = Nothing

            If Not IsDBNull(objReader("ItemCode").ToString) Then strItemCde = objReader("ItemCode").ToString
            If Not IsDBNull(objReader("GroupName").ToString) Then strDesc = objReader("GroupName").ToString
            If Not IsDBNull(objReader("SerialNumbers").ToString) Then strSerial = objReader("SerialNumbers").ToString
            If IsNumeric(objReader("Quantity").ToString) Then dblQty = CDbl(objReader("Quantity").ToString)
            If Not IsDBNull(objReader("Category").ToString) Then strCat = objReader("Category").ToString
            If Not IsDBNull(objReader("SubCategory").ToString) Then strSubCat = objReader("SubCategory").ToString
            If Not IsDBNull(objReader("InventoryType").ToString) Then strTyp = objReader("InventoryType").ToString
            If IsNumeric(objReader("SellingPrice").ToString) Then dblPrice = CDbl(objReader("SellingPrice").ToString)
            If Not IsDBNull(objReader("SourceSerialNo").ToString) Then strSourceSerial = objReader("SourceSerialNo").ToString

            With dGrid
                .Rows.Add(1)
                .Rows(.Rows.Count - 1).Cells(0).Value = strItemCde
                .Rows(.Rows.Count - 1).Cells(1).Value = strDesc
                .Rows(.Rows.Count - 1).Cells(2).Value = strSerial
                .Rows(.Rows.Count - 1).Cells(4).Value = dblQty
                .Rows(.Rows.Count - 1).Cells(5).Value = strCat
                .Rows(.Rows.Count - 1).Cells(6).Value = strSubCat
                .Rows(.Rows.Count - 1).Cells(7).Value = strTyp
                .Rows(.Rows.Count - 1).Cells(8).Value = dblPrice
                .Rows(.Rows.Count - 1).Cells(10).Value = strSourceSerial
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Web stock transfers"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnFinishSale_Click(sender As System.Object, e As System.EventArgs) Handles btnFinishSale.Click
        If String.IsNullOrEmpty(cboBranches.Text) Then
            MessageBox.Show("Please select the branch to which stocks are transfered.", _
                "Invalid Destination Branch", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboBranches.Focus()
            Exit Sub
        End If
        FinishProcess()
        GetBatchNumber()
    End Sub

    Private Sub btnFile_Click(sender As System.Object, e As System.EventArgs) Handles btnFile.Click
        On Error GoTo RaiseErr
        Dim fileString As String = Nothing
        boolStockUpdated = False

        arrSourceSerials = New ArrayList

        If boolBatchRecall = False Then
            iNextPassNumber = CInt(gwt_comm.GetNextDocumentNumber("GatePass"))
        End If

        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strCode As String = Nothing
            Dim strSerial As String = Nothing
            Dim strQty As String = 0
            Dim strCategory As String = Nothing
            Dim strSubCategory As String = Nothing
            Dim strInventoryType As String = Nothing
            Dim strPrice As String = Nothing
            Dim strGroupName As String = Nothing
            Dim strSourceBarCode As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strCode = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                    strGroupName = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                    strSerial = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                    strQty = Convert.ToString(dGrid.Rows(i).Cells(4).Value)
                End If

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                    strCategory = Convert.ToString(dGrid.Rows(i).Cells(5).Value)
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(6).Value), "")) Then
                    strSubCategory = Convert.ToString(dGrid.Rows(i).Cells(6).Value)
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "")) Then
                    strInventoryType = Convert.ToString(dGrid.Rows(i).Cells(7).Value)
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(8).Value), "")) Then
                    strPrice = Convert.ToString(dGrid.Rows(i).Cells(8).Value)
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(10).Value), "")) Then
                    strSourceBarCode = Convert.ToString(dGrid.Rows(i).Cells(10).Value)
                End If

                fileString = fileString & txtBatchNo.Text & "|" & strCode & "|" & strSerial & "|" & _
                    strQty & "|" & strCategory & "|" & strSubCategory & "|" & strGroupName & "|" & _
                    strInventoryType & "|" & strPrice & "|" & Now & "|" & strUserBranch & "|" & strSourceBarCode & vbCrLf

                If chkFromStock.Checked = True Then
                    Dim objRemoveFromStock As New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = (Quantity - " & CInt(strQty) & ") " _
                        & "WHERE ItemCode = '" & strCode & "'", cnn)
                    objRemoveFromStock.ExecuteNonQuery()
                    'Remove the serials as well
                    If Not String.IsNullOrEmpty(strSerial) Then
                        Dim strSerialNumbers() As String = Split(strSerial, ",")
                        objRemoveFromStock = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers " _
                            & "WHERE SourceSerialNo = '" & strSourceBarCode & "' AND ItemCode = '" & Trim(strCode) & "'", cnn)
                        objRemoveFromStock.ExecuteNonQuery()
                    End If
                End If
            End If
        Next

        boolStockUpdated = True

        Cursor = Cursors.WaitCursor
        boolAbort = False

        Dim strFileName As String = Nothing
        sfd.ShowDialog()
        strFileName = sfd.FileName

        If Not String.IsNullOrEmpty(strFileName) Then
            Dim objFile As New System.IO.StreamWriter(strFileName, False)
            objFile.Write(fileString)
            objFile.Close()
        Else
            MessageBox.Show("Destination file not specified. Process will be aborted.", "Missing DestinationFile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Print the gate pass
        boolAbort = False
        UpdateGatePassDetails()

        If boolAbort = True Then Exit Sub
        PrintGatePass(gwt_comm.shortMonthDateFormat(Now))

        dGrid.Rows.Clear()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        dGrid.Rows.Clear()
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Web Stocks Data Transmissions" & vbCrLf & vbCrLf & strErrorMessages
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrintPass_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintPass.Click
        If dGrid.Rows.Count <= 0 Then
            MessageBox.Show("There are no transactions to be processed", "Process Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        itm = 0
        PrintGatePass(gwt_comm.shortMonthDateFormat(Now))
    End Sub

    Private Sub btnRefreshItems_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshItems.Click
        boolBatchRecall = False
        'dGrid.Rows.Add(50)
        LoadTransfersData()
        GetBatchNumber()
    End Sub

    Private Sub FinishProcess()
        On Error GoTo RaiseErr
        Dim fileString As String = Nothing
        boolStockUpdated = False

        arrSourceSerials = New ArrayList

        Dim arrInventoryRemovals As New ArrayList

        If boolBatchRecall = False Then
            iNextPassNumber = CInt(gwt_comm.GetNextDocumentNumber("GatePass"))
        End If

        Dim arrSqlItems As New ArrayList

        Dim [option] = New TransactionOptions With {.IsolationLevel = IsolationLevel.ReadCommitted, .Timeout = TimeSpan.FromSeconds(60)}
        Using InputTransactions = New TransactionScope(TransactionScopeOption.Required, [option])

            For i As Integer = 0 To dGrid.Rows.Count - 1
                Dim strCode As String = Nothing
                Dim strSerial As String = Nothing
                Dim strQty As String = 0
                Dim strCategory As String = Nothing
                Dim strSubCategory As String = Nothing
                Dim strInventoryType As String = Nothing
                Dim strPrice As String = Nothing
                Dim strGroupName As String = Nothing
                Dim strSourceBarCode As String = Nothing
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    strCode = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                        strGroupName = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                        strSerial = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                        strQty = Convert.ToString(dGrid.Rows(i).Cells(4).Value)
                    End If

                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                        strCategory = Convert.ToString(dGrid.Rows(i).Cells(5).Value)
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(6).Value), "")) Then
                        strSubCategory = Convert.ToString(dGrid.Rows(i).Cells(6).Value)
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "")) Then
                        strInventoryType = Convert.ToString(dGrid.Rows(i).Cells(7).Value)
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(8).Value), "")) Then
                        strPrice = Convert.ToString(dGrid.Rows(i).Cells(8).Value)
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(10).Value), "")) Then
                        strSourceBarCode = Convert.ToString(dGrid.Rows(i).Cells(10).Value)
                    End If


                    'Get the cost price based on receiving and actually updated
                    Dim dblItemCostPrice As Double = 0
                    Dim ojjGetCostPrice As New Data.OleDb.OleDbCommand("SELECT CostPrice FROM InventoryItems WHERE ItemCode = '" & strCode & "'", cnn)
                    Dim objReadCostPrice As Data.OleDb.OleDbDataReader = ojjGetCostPrice.ExecuteReader
                    If objReadCostPrice.HasRows Then
                        objReadCostPrice.Read()
                        If IsNumeric(objReadCostPrice(0).ToString) Then dblItemCostPrice = CDbl(objReadCostPrice(0).ToString)
                    End If
                    objReadCostPrice.Close()

                    'get the item's base barcode
                    Dim strBaseBarCode As String = Nothing
                    Dim objGetBasebarcode As New Data.OleDb.OleDbCommand("SELECT [BarCodeNo], [CostPrice] FROM SerialNumbers " _
                        & "WHERE ItemCode = '" & strCode & "' AND SerialNumber = '" & strSerial & "'", cnn)
                    Dim objReadBasebarcode As Data.OleDb.OleDbDataReader = objGetBasebarcode.ExecuteReader
                    If objReadBasebarcode.HasRows Then
                        objReadBasebarcode.Read()
                        If Not IsDBNull(objReadBasebarcode(0).ToString) Then strBaseBarCode = objReadBasebarcode(0).ToString
                        If IsNumeric(objReadBasebarcode(1).ToString) Then
                            If CDbl(objReadBasebarcode(1).ToString) > 0 Then
                                dblItemCostPrice = CDbl(objReadBasebarcode(1).ToString)
                            End If
                        End If
                    End If
                    objReadBasebarcode.Close()

                    fileString = fileString & txtBatchNo.Text & "|" & strCode & "|" & strSerial & "|" & _
                        strQty & "|" & strCategory & "|" & strSubCategory & "|" & strGroupName & "|" & _
                        strInventoryType & "|" & strPrice & "|" & Now & "|" & strUserBranch & "|" & strSourceBarCode & "|" & dblItemCostPrice & vbCrLf

                    If boolBatchRecall = False Then
                        Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO InventoryTransfers ([BatchNo], [ItemCode]," _
                            & "[SourceBranch],[ReceivingBranch],[Quantity],[UserName],[TransDate], [SerialNumbers], [Category], " _
                            & "[SubCategory], [ItemType], [UnitPrice], [SourceSerialNo], [PassNumber]) VALUES " _
                            & "(" & CInt(txtBatchNo.Text) & ", '" & strCode & "', '" & strUserBranch & "', '" & cboBranches.Text & "', " _
                            & "" & strQty & ", '" & strUserName & "', '" & gwt_comm.shortMonthDateFormat(Now) & "', " _
                            & "'" & strSerial & "', '" & strCategory & "', '" & strSubCategory & "', '" & strInventoryType & "', " _
                            & "" & CDbl(strPrice) & ", '" & strSourceBarCode & "', " & iNextPassNumber & ")", cnn)
                        objCommand.ExecuteNonQuery()

                        'update the centralized stores values
                        If UCase(strPublicStockManagementType) = "CENTRALIZED" Then
                            'Update the branch stores table and the sbu serial number table
                            If UCase(cboBranches.Text) <> UCase(strUserBranch) Then
                                'In the branch items, first check that the record exist before inserting, otherwise update
                                objCommand = New Data.OleDb.OleDbCommand("SELECT ItemCode FROM SbuInventoryItems WHERE " _
                                    & "ItemCode = '" & strCode & "' AND Branch = '" & cboBranches.Text & "'", cnn)
                                Dim objReadItem As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                                If objReadItem.HasRows = False Then
                                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SbuInventoryItems (ItemCode, Quantity, Branch) VALUES " _
                                        & "('" & strCode & "', " & strQty & ", '" & cboBranches.Text & "')", cnn)
                                    objCommand.ExecuteNonQuery()
                                Else
                                    objCommand = New Data.OleDb.OleDbCommand("UPDATE SbuInventoryItems SET Quantity = " _
                                        & "(Quantity + " & strQty & ") WHERE ItemCode = '" & strCode & "' AND " _
                                        & "Branch = '" & cboBranches.Text & "'", cnn)
                                    objCommand.ExecuteNonQuery()
                                End If
                                objReadItem.Close()

                                If Not String.IsNullOrEmpty(strSerial) Then
                                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SbuSerialNumbers (ItemCode, SerialNumber, " _
                                        & "BarCodeNo, SourceSerialNo, Branch) VALUES ('" & strCode & "', '" & strSerial & "', " _
                                        & "'', '" & strSourceBarCode & "', '" & cboBranches.Text & "')", cnn)
                                    objCommand.ExecuteNonQuery()
                                End If
                            End If
                        End If

                        'Get the source serial number and the base barcode and add to array
                        Dim objGetSerialNumberDetails As New Data.OleDb.OleDbCommand("SELECT BarCodeNo, SourceSerialNo FROM SerialNumbers " _
                            & "WHERE ItemCode = '" & strCode & "'", cnn)
                        Dim objReadSerialNmberDetails As Data.OleDb.OleDbDataReader = objGetSerialNumberDetails.ExecuteReader
                        If objReadSerialNmberDetails.HasRows Then
                            objReadSerialNmberDetails.Read()
                            Dim strBseCode As String = " ", strSceCode As String = " "
                            If Not IsDBNull(objReadSerialNmberDetails(0).ToString) Then strBseCode = objReadSerialNmberDetails(0).ToString
                            If Not IsDBNull(objReadSerialNmberDetails(1).ToString) Then strSceCode = objReadSerialNmberDetails(1).ToString
                            arrSourceSerials.Add(strBseCode & "|" & strSceCode)
                        Else
                            arrSourceSerials.Add(" | ")
                        End If
                        objReadSerialNmberDetails.Close()
                    End If
                    If chkFromStock.Checked = True Then
                        arrInventoryRemovals.Add(strQty & "|" & strCode & "|" & strSerial & "|" & strSourceBarCode)
                    End If
                End If
            Next

            boolStockUpdated = True
            If UCase(strNetworkOperationStatus) = "SERVER" Then
                boolServerAdditions = True
            End If

            If strOnlineInventoryTransfer = "YES" Then
                Cursor = Cursors.WaitCursor
                boolAbort = False
                ServerDestinationFolder = cboBranches.Text.Replace(" ", "") & "/Stocks"
                strDestinationBranch = cboBranches.Text
                gwt_comm.AddDataChanges(fileString)
                Dim objUpdateStatus As Data.OleDb.OleDbCommand
                If boolAbort = True Then
                    'Update the status
                    objUpdateStatus = New Data.OleDb.OleDbCommand("UPDATE InventoryTransfers SET Status = 'FAILED' " _
                        & "WHERE BatchNo = " & CInt(txtBatchNo.Text) & "", cnn)
                    objUpdateStatus.ExecuteNonQuery()
                    MessageBox.Show("There were errors encountered when transfering stock. Make sure that the connection is on and retry sending", _
                        "Data Transmission Failure", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    'Update the status
                    objUpdateStatus = New Data.OleDb.OleDbCommand("UPDATE InventoryTransfers SET Status = 'SENT' " _
                        & "WHERE BatchNo = " & CInt(txtBatchNo.Text) & "", cnn)
                    objUpdateStatus.ExecuteNonQuery()
                End If
            End If

            InputTransactions.Complete()
        End Using

        'Print the gate pass
        boolAbort = False
        UpdateGatePassDetails()

        If boolAbort = True Then Exit Sub

        strSelectedReport = iNextNumber
        PrintGatePass(gwt_comm.shortMonthDateFormat(Now))

        'PrintCustomerDocument(iNextPassNumber, "DELIVERY NOTE")

        If chkFromStock.Checked = True Then
            For i As Integer = 0 To arrInventoryRemovals.Count - 1
                Dim strValue() As String = Split(arrInventoryRemovals.Item(i), "|")
                Dim objRemoveFromStock As New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = (Quantity - " & CInt(strValue(0)) & ") " _
                    & "WHERE ItemCode = '" & strValue(1) & "'", cnn)
                objRemoveFromStock.ExecuteNonQuery()
                'Remove the serials as well
                If Not String.IsNullOrEmpty(strValue(2)) Then
                    Dim strSerialNumbers() As String = Split(strValue(2), ",")
                    objRemoveFromStock = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers " _
                        & "WHERE SourceSerialNo = '" & strValue(3) & "' AND ItemCode = '" & Trim(strValue(1)) & "'", cnn)
                    objRemoveFromStock.ExecuteNonQuery()
                End If
            Next
        End If

        dGrid.Rows.Clear()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        Dim strEr As String = Nothing
        If boolStockUpdated = True Then
            strEr = "Transactions however have been updated"
        End If
        dGrid.Rows.Clear()
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Web Stocks Data Transmissions" & vbCrLf & vbCrLf & strEr
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub UpdateGatePassDetails()
        On Error GoTo RaiseErr
        'Get the next gate pass number 

        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim strSql As String = Nothing
        Dim myCommand As Data.OleDb.OleDbCommand

        'Send the data being transfered to the pass registry before printing. This will allow for the 
        're-printing of the gate pass if required in future
        arrPrintDetails = New ArrayList

        Dim arrSqlItems As New ArrayList

        For i As Integer = 0 To dGrid.Rows.Count - 1

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then

                Dim strItemSerialNo As String = Nothing
                Dim strLineItemType As String = Nothing
                Dim strSelectedId As String = Nothing
                Dim strDescription As String = Nothing
                Dim intQty As Integer = 0
                Dim dblUprice As Double = 0
                Dim strSourceSerialCode As String = Nothing

                strSelectedId = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                strDescription = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
                intQty = Convert.ToDouble(dGrid.Rows(i).Cells(4).Value)
                dblUprice = Convert.ToDouble(dGrid.Rows(i).Cells(8).Value)

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                    strItemSerialNo = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "")) Then
                    strLineItemType = Convert.ToString(dGrid.Rows(i).Cells(7).Value)
                End If

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                    strItemSerialNo = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(10).Value), "")) Then
                    strSourceSerialCode = Convert.ToString(dGrid.Rows(i).Cells(10).Value)
                End If

                Dim strInsert As String = "INSERT INTO GatePasses (PassNumber, TransDate, ItemCode, Quantity, " _
                    & "Description, ProductType, SerialNumber, UserName, CollectingAgent, Branch, PassType, " _
                    & "BarCodeNo, SourceSerialNo) VALUES " _
                    & "(" & iNextPassNumber & ", '" & Format(Now, "dd-MMM-yyy") & "', '" & strSelectedId & "', " & intQty & ", " _
                    & "'" & strDescription & "', '" & strLineItemType & "', '" & strItemSerialNo & "', " _
                    & "'" & strUserBranch & "', '" & cboBranches.Text & "', '" & strUserName & "', 'TRANSFER', " _
                    & "'" & strItemSerialNo & "', '" & strSourceSerialCode & "')"
                arrSqlItems.Add(strInsert)

                'myCommand = New Data.OleDb.OleDbCommand(strInsert, cnn)
                'myCommand.ExecuteNonQuery()

                'Assign the values to the print array
                arrPrintDetails.Add(intQty & "|" & strDescription & "|" & strItemSerialNo)

            End If

        Next i

        'Add the record to the gate pass main
        strNotes = "INVENTORY TRANSFERS FROM " & UCase(strUserBranch) _
            & " TO " & UCase(cboBranches.Text) & ". PLEASE CONFIRM DETAILS AND SIGN THIS DOCUMENT. ANY DISCREPANCIES " _
            & "SHOULD BE COMMUNICATED IMMEDIATELY. NO JUSTIFICATIONS WILL BE ALLOWED ONCE THE GOODS LEAVE THIS OFFICE"


        If arrSqlItems.Count > 0 Then

            Dim [option] = New TransactionOptions With {.IsolationLevel = IsolationLevel.ReadCommitted, .Timeout = TimeSpan.FromSeconds(60)}
            Using scopeOuter = New TransactionScope(TransactionScopeOption.Required, [option])
                myCommand = New Data.OleDb.OleDbCommand("INSERT INTO GatePassesMain (PassNumber, " _
                    & "TransDate, UserName, Branch, Comment, CollectingAgent, PassType) VALUES " _
                    & "(" & iNextPassNumber & ", '" & gwt_comm.shortMonthDateFormat(Now) & "', " _
                    & "'" & strUserName & "', '" & strUserBranch & "', '" & strNotes & "', " _
                    & "'" & cboBranches.Text & "', 'TRANSFER')", cnn)
                myCommand.ExecuteNonQuery()
                Using scopeInner = New TransactionScope(TransactionScopeOption.Required, [option])
                    For intItems As Integer = 0 To arrSqlItems.Count - 1
                        myCommand = New Data.OleDb.OleDbCommand(arrSqlItems.Item(intItems), cnn)
                        myCommand.ExecuteNonQuery()
                    Next
                    scopeInner.Complete()
                End Using
                scopeOuter.Complete()
            End Using

        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Transfer and Gate Pass Generation Failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub PrintGatePass(ByVal dtReceiptDate As Date)
        On Error GoTo RaiseErr

        strType = "INVENTORY GATE PASS"
        strSelectedReport = iNextPassNumber

        arrPrintDetails = New ArrayList

        If dGrid.Rows.Count <= 0 Then
            MessageBox.Show("Cannot print gate pass as there are no items to take out of stores", "No Items To Process", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        With dGrid
            For i As Integer = 0 To dGrid.Rows.Count - 1

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then

                    Dim strItemSerialNo As String = Nothing
                    Dim strLineItemType As String = Nothing
                    Dim strSelectedId As String = Nothing
                    Dim strDescription As String = Nothing
                    Dim intQty As Integer = 0
                    Dim dblUprice As Double = 0

                    strSelectedId = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                    strDescription = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
                    intQty = Convert.ToDouble(dGrid.Rows(i).Cells(4).Value)
                    dblUprice = Convert.ToDouble(dGrid.Rows(i).Cells(8).Value)

                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                        strItemSerialNo = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "")) Then
                        strLineItemType = Convert.ToString(dGrid.Rows(i).Cells(7).Value)
                    End If

                    'Assign the values to the print array
                    arrPrintDetails.Add(intQty & "|" & strDescription & "|" & strItemSerialNo)

                End If

            Next i
        End With

        ' Allow the user to select a printer.
        itm = 0

        If strRequestForReceiptPrinter = "YES" Then
            boolAbort = False
            gwt_comm.PrinterSelection()
            If boolAbort = True Then Exit Sub
            pdWindows.PrinterSettings.PrinterName = strSessionPrinter
        End If

        PrintPreviewDialog1.Document = pdWindows
        PrintPreviewDialog1.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Gate Pass Processing"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadTransfersData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT ItemCode +';'+GroupName +';'+ Category +';'+ SubCategory +';'+ " _
            & "InventoryType +';'+ CONVERT(NVARCHAR, SellingPrice) AS " _
            & "[Items] FROM InventoryItems ORDER BY ItemCode"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 6
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "160;180;0;0;0;0"
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
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2), strRecordText(3), strRecordText(4), strRecordText(5))
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

        'Load the employee details
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT BranchName FROM Branches ORDER BY BranchName", cnn)
        objReader = sqlCommand.ExecuteReader
        cboBranches.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                'If UCase(objReader(0).ToString) <> UCase(strUserBranch) Then
                cboBranches.Items.Add(objReader(0).ToString)
                'End If
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetBatchNumber()
        'Get the batch number
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT Distinct BatchNo FROM InventoryTransfers ORDER BY BatchNo DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                txtBatchNo.Text = CInt(objReader(0).ToString) + 1
            Else
                txtBatchNo.Text = "1"
            End If
        Else
            txtBatchNo.Text = "1"
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Function isItemAlreadyAdded(ByVal ItemCode As String, ByVal SerialNumber As String) As Boolean
        Dim boolReturn As Boolean = False
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strCode As String = Nothing
            Dim strSerial As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strCode = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                strSerial = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
            End If
            If UCase(strCode) = UCase(ItemCode) And UCase(strSerial) = UCase(SerialNumber) Then
                boolReturn = True
                Exit For
            End If
        Next
        Return boolReturn
    End Function

    Private Sub pdWindows_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdWindows.PrintPage
        If boolPrintFromPreview = True Then
            'requery records
            itm = 0
            boolAbort = False
            '''''''''---------------Me.GenerateTransactionDocument(CDbl(txtReference.Text))
            If boolAbort = True Then Exit Sub
            boolPrintFromPreview = False
        End If
        Dim strDType As String

        strDType = "GATE PASS"
        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer
        'Dim xx1 AS DOUBLE, xx2 AS DOUBLE, yy1 AS DOUBLE, yy2 AS DOUBLE
        x1 = e.PageBounds.Left + 100
        y1 = e.PageBounds.Top + 100
        p1 = e.PageBounds.Width - 200
        y2 = e.PageBounds.Height - 200

        Dim pencurrent As New Pen(Color.Gray, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        Dim strS As String = Nothing
        Dim Yc As Double
        Dim cols, lines As Double

        'Draw the document rectangle

        reccurrent = New Rectangle(x1, y1, p1, y2)
        e.Graphics.DrawRectangle(Pens.Gray, reccurrent)

        'Print the watermark here
        'Dim g As Graphics = e.Graphics
        'g.TranslateTransform(200, 200)
        'g.RotateTransform(e.PageSettings.Landscape)
        'g.DrawString("DRAFT VERSION", New Font("Verdana", 75, FontStyle.Bold), New SolidBrush(Color.FromArgb(64, Color.Black)), 0, 0)

        'print the company logo
        Dim g As Graphics = e.Graphics

        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                'Dont print the company name as it is taken care of by the logo
                strCompanyName = ""
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoXposition, intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
            End If
        End If

        g.DrawString("GATE PASS", New Font("Arial", 20, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, Color.Black)), 500, e.PageBounds.Top + 120)

        y1 = y1 + 30

        'Get the sales agent details
        'Print the company details at the extreme left of document

        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 500, 80, strCompanyName, fntHeaderFont, Brushes.Black)
        'e.Graphics.DrawString(strDType, fntHeaderFont, Brushes.Black, 500, e.PageBounds.Top + 120)
        y1 = y1 + 20
        Dim strAddressInfo As String = strCompanyAddress1 & vbCrLf & strCompanyAddress2 & vbCrLf & _
            strCompanyAddress3 & vbCrLf & strCompanyAddress4 & vbCrLf & "Tel No.:  " & strPublicBranchTelephone & "Fax : " _
            & strCompanyFaxNumber & vbCrLf & "Email   : " & strCompanyEmailAddress
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strAddressInfo, fntDetailsFont, Brushes.Black)

        'Get the size of the address box
        e.Graphics.MeasureString(strAddressInfo, fntDetailsFont, New SizeF(200, 80), New StringFormat(), cols, lines)
        Yc = y1
        y1 = y1 + lines * fntDetailsFont.Height + 5
        y1 = Math.Max(y1, Yc)

        'print captions
        x1 = x1 + 10
        x2 = x1 + 50
        X3 = x2 + 420
        X4 = X3 + 100
        X5 = X4 + 100
        X6 = X5 + 100

        e.Graphics.DrawLine(Pens.Gray, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        e.Graphics.DrawString("PROCESSOR DETAILS", fntHeaderFont, Brushes.Black, x1, y1)
        e.Graphics.DrawString("TRANSACTION DETAILS", fntHeaderFont, Brushes.Black, 500, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Gray, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 15

        'Print processor details
        e.Graphics.DrawString(UCase(strUserName) & vbCrLf & UCase(strUserBranch), fntDetailsFont, Brushes.Black, x1, y1)

        'Print the date
        e.Graphics.DrawString("DATE : " & dpTransDate.Value, fntDetailsFont, Brushes.Black, 500, y1)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "DOCUMENT NO.  : " & Format(CLng(iNextPassNumber), "000000"), fntDetailsFont, Brushes.Black)
        y1 += 45

        e.Graphics.DrawLine(Pens.Gray, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20

        'print captions
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 60, 80, "QTY", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 250, 80, "DESCRIPTION", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, X3, y1, 120, 80, "SERIAL NO", fntHeaderFont, Brushes.Black)

        'draw a line after
        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Gray, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 30

        reccurrent = New Rectangle()
        boolExitingWhile = False

        Dim strBuffer() As String
        Dim intLineCounter As Integer = 0

        While itm < arrPrintDetails.Count
            strBuffer = Split(arrPrintDetails.Item(itm), "|")
            If Not strBuffer(0) Is Nothing Then strValue = strBuffer(0) Else strValue = "-"
            Call gwt_comm.DrawStringInBoxCenter(e, x1, y1, 50, 60, strValue, fntDetailsFont, Brushes.Black)
            If Not strBuffer(1) Is Nothing Then strValue = strBuffer(1) Else strValue = " "
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 400, 80, strValue, fntDetailsFont, Brushes.Black)
            If Not strBuffer(2) Is Nothing Then strValue = strBuffer(2) Else strValue = " "
            Call gwt_comm.DrawStringInBoxLeft(e, X3, y1, 120, 80, strValue, fntDetailsFont, Brushes.Black)

            'Get the size of the address box based on the possible longest i.e. the description
            If Not strBuffer(1) Is Nothing Then strValue = strBuffer(1) Else strValue = " "
            e.Graphics.MeasureString(strValue, fntDetailsFont, New SizeF(400, 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * fntDetailsFont.Height + 5
            y1 = Math.Max(y1, Yc)

            intLineCounter = intLineCounter + 1
            itm = itm + 1 : i = 0

            If intLineCounter = 35 Then
                'Print the page number of the statement
                Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 350, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", fntDetailsFont, Brushes.Black)
                e.HasMorePages = True
                boolExitingWhile = True
                intPage += 1
                Exit While
            End If
        End While

        'print totals

        If boolExitingWhile = False Then
            y1 = y1 + 30
            e.Graphics.DrawLine(Pens.Gray, x1 - 10, y1, p1 + 100, y1)
            y1 = y1 + 30
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 550, 80, "NOTES : " & strNotes, fntDetailsFont, Brushes.Black)

            'Get the size of the address box based on the possible longest i.e. the description
            strValue = "NOTES : " & strNotes
            e.Graphics.MeasureString(strValue, fntDetailsFont, New SizeF(400, 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * fntDetailsFont.Height + 5
            y1 = Math.Max(y1, Yc)
            y1 = y1 + 30

            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 500, 60, "Authorised by ..........................................................", fntHeaderFont, Brushes.Black)
            y1 = y1 + 30
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 500, 60, "Approved by   ..........................................................", fntHeaderFont, Brushes.Black)

            'Print the page number of the statement
            Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, fntDetailsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 350, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", fntDetailsFont, Brushes.Black)

            e.HasMorePages = False
            Me.boolPrintFromPreview = True

        End If

    End Sub

    Private Sub btnSerialNumbers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerialNumbers.Click
        If Not String.IsNullOrEmpty(cboItems.Text) Then
            strSerialNumberForTransfer = Nothing
            strPublicItemCode = cboItems.Text
            Dim f As New frmSalesSerialNumbers
            f.ShowDialog()
            If Not String.IsNullOrEmpty(strSerialNumberForTransfer) Then
                txtSerialNumbers.Text = strSerialNumberForTransfer
            End If
        Else
            MessageBox.Show("Please enter the item code first", "Invalid Item Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        strPublicItemCode = Nothing
        gwt_comm.InventorySearch()
        If Not String.IsNullOrEmpty(strPublicItemCode) Then
            cboItems.Text = strPublicItemCode
            strPublicItemCode = Nothing
        End If
    End Sub

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            If String.IsNullOrEmpty(txtBarcode.Text) Then Exit Sub
            ProcessBarcode()
        End If
    End Sub

    Private Sub ProcessBarcode()
        On Error GoTo RaiseErr

        lblCategory.Text = ""
        lblDescription.Text = ""
        lblItemType.Text = ""
        lblPrice.Text = "0.00"
        lblSubCategory.Text = ""
        cboItems.Text = ""
        txtSerialNumbers.Text = Nothing

        If String.IsNullOrEmpty(txtBarcode.Text) Then Exit Sub

        boolAbort = False
        Dim strValues() As String = gwt_comm.ReadBarcode(txtBarcode.Text)
        If boolAbort = True Then Exit Sub

        'The return array contains the item code, transactionid, Foundstatus, serial number

        If String.IsNullOrEmpty(strValues(0)) Then
            MessageBox.Show("Item barcode not found in the system", "Invalid Item Bar Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Get the description and item type
        cboItems.Text = strValues(0)
        Dim objGetDetails As New Data.OleDb.OleDbCommand("SELECT GroupName, InventoryType, Category, " _
            & "SubCategory, CAST(SellingPrice as DECIMAL (30,2)) as [Price] FROM InventoryItems " _
            & "WHERE ItemCode = '" & strValues(0) & "'", cnn)
        Dim objReadDetails As Data.OleDb.OleDbDataReader = objGetDetails.ExecuteReader
        If objReadDetails.HasRows Then
            objReadDetails.Read()
            If Not IsDBNull(objReadDetails(0).ToString) Then lblDescription.Text = objReadDetails(0).ToString
            If Not IsDBNull(objReadDetails(1).ToString) Then lblItemType.Text = objReadDetails(1).ToString
            If Not IsDBNull(objReadDetails(2).ToString) Then lblCategory.Text = objReadDetails(2).ToString
            If Not IsDBNull(objReadDetails(3).ToString) Then lblSubCategory.Text = objReadDetails(3).ToString
            If Not IsDBNull(objReadDetails(4).ToString) Then lblPrice.Text = objReadDetails(4).ToString
            txtSerialNumbers.Text = strValues(3)
            AddItem()
        End If
        objReadDetails.Close()
        txtBarcode.Focus()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCritical & "Bar code fetch failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtBatchNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBatchNo.KeyPress
        If Asc(e.KeyChar) = 13 Then dGrid.Focus()
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then
            Exit Sub
        End If
        If e.KeyChar = "." Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub


    Private Sub cboItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.SelectedIndexChanged
        CommitValueChanged()
        ComputeFinancialData()
    End Sub

    Private Sub ComputeFinancialData()
        On Error GoTo RaiseErr
        lblQuantityInStock.Text = "0" : lblCostValue.Text = "0.00" : lblSalesValue.Text = "0.00"
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Quantity, (Quantity * CostPrice) AS [Cost], " _
            & "(Quantity * SellingPrice) AS [Sales] FROM InventoryItems WHERE ItemCode = '" & cboItems.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then lblQuantityInStock.Text = objReader(0).ToString
            If IsNumeric(objReader(1).ToString) Then lblCostValue.Text = CStr(Format(CDbl(objReader(1).ToString), "#,##0.00"))
            If IsNumeric(objReader(2).ToString) Then lblSalesValue.Text = CStr(Format(CDbl(objReader(2).ToString), "#,##0.00"))
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Web Inventory Transfers"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr
        'If cboItems.Focused = False Then Exit Sub
        If Not cboItems.SelectedItem Is Nothing Then
            'dGrid.CurrentRow.Cells(0).Value = cboItems.SelectedItem.Col1
            lblDescription.Text = cboItems.SelectedItem.Col2
            txtQuantity.Text = "1"
            lblCategory.Text = cboItems.SelectedItem.Col3
            lblSubCategory.Text = cboItems.SelectedItem.Col4
            lblItemType.Text = cboItems.SelectedItem.Col5
            lblPrice.Text = cboItems.SelectedItem.Col6
            If IsNumeric(lblPrice.Text) Then
                lblPrice.Text = Format(CDbl(lblPrice.Text), "###.00")
            End If
            If UCase(lblItemType.Text) = "SPECIFIC" Then btnBulkItems.Enabled = True Else btnBulkItems.Enabled = False
        Else
            lblDescription.Text = Nothing
            txtQuantity.Text = "1"
            lblCategory.Text = Nothing
            lblSubCategory.Text = Nothing
            lblItemType.Text = Nothing
            lblPrice.Text = Nothing
            cboItems.Text = Nothing
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Web Inventory Transfers"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellValidated
        If dGrid.CurrentCell.ColumnIndex = 4 Then
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value), "")) Then
                If Not IsNumeric(dGrid.CurrentCell.Value) Then
                    MessageBox.Show("Invalid Non Numeric Value Detected. Cell value defaulted to 0", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGrid.CurrentCell.Value = "0"
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub dGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellClick
        If dGrid.Rows.Count > 0 Then
            If dGrid.CurrentCell.ColumnIndex = 9 Then
                dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
            End If
        End If
    End Sub

    Private Sub btnStoresToSales_Click(sender As System.Object, e As System.EventArgs) Handles btnStoresToSales.Click
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Or IntPublicStoresManagement > 0 Then
            strStoresOperationType = "ISSUE"
            Dim frm As New frmWarehouseStockIssues
            frm.ShowDialog()
        Else
            MessageBox.Show("You do not have the right to access this part of the system", _
                "Invoking Unauthorised Access", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
    End Sub

    Private Sub btnSalesToStores_Click(sender As System.Object, e As System.EventArgs) Handles btnSalesToStores.Click
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Or IntPublicStoresManagement > 0 Then
            strStoresOperationType = "RETURN"
            Dim frm As New frmWarehouseStockIssues
            frm.ShowDialog()
        Else
            MessageBox.Show("You do not have the right to access this part of the system", _
                "Invoking Unauthorised Access", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
    End Sub

    Private Sub frmInventoryTransfers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetBatchNumber()
        If boolAbort = True Then Exit Sub
        LoadTransfersData()
        If boolAbort = True Then Exit Sub
    End Sub

    Private Sub btnRemoveItem_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveItem.Click
        If dGrid.Rows.Count > 0 Then
            dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
        End If
    End Sub

End Class
