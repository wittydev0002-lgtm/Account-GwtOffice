Imports CommonLibrary
Imports CommonLibrary.Commons
Imports System.Windows.Forms

Public Class frmGoodsReceipt

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGridReceiveOrders_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridReceiveOrders.EditingControlShowing
        Try
            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                'In order to prevent optical problems, we had to call the removeHandler twice
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dGridReceiveOrders_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridReceiveOrders.CellEndEdit
        If e.ColumnIndex >= 3 And e.ColumnIndex <= 4 Then
            If IsNumeric(dGridReceiveOrders.CurrentCell.Value) Then
                dGridReceiveOrders.CurrentCell.Value = Format(CDbl(dGridReceiveOrders.CurrentCell.Value), "##0.00")
            Else
                dGridReceiveOrders.CurrentCell.Value = "0.00"
            End If
            Dim dblUnitPrice As Double = 0
            Dim dblQuantity As Double = 0
            If Not Object.Equals(dGridReceiveOrders.CurrentRow.Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridReceiveOrders.CurrentRow.Cells(3).Value.ToString) Then
                    If IsNumeric(dGridReceiveOrders.CurrentRow.Cells(3).Value.ToString) Then
                        dblUnitPrice = CDbl(dGridReceiveOrders.CurrentRow.Cells(3).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGridReceiveOrders.CurrentRow.Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridReceiveOrders.CurrentRow.Cells(4).Value.ToString) Then
                    If IsNumeric(dGridReceiveOrders.CurrentRow.Cells(4).Value.ToString) Then
                        dblQuantity = CDbl(dGridReceiveOrders.CurrentRow.Cells(4).Value.ToString)
                    End If
                End If
            End If
            Dim dblTotal As Double = dblUnitPrice * dblQuantity
            dGridReceiveOrders.CurrentRow.Cells(5).Value = Format(dblTotal, "##0.00")
        End If
        ComputeTotals()
    End Sub

    Private Sub frmGoodsReceipt_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Enter Or e.KeyValue = 9 Then
            If dGridReceiveOrders.CurrentCell.ColumnIndex = 0 Then
                strPublicItemCode = Nothing
                strFullItemDetails = Nothing
                boolAbort = False
                gwt_comm.InventorySearch()
                If boolAbort = True Then Exit Sub
                'Assign the description
                CommitValueChanged()
                dGridReceiveOrders.CurrentCell = dGridReceiveOrders.Rows(dGridReceiveOrders.CurrentRow.Index).Cells(2)
                e.SuppressKeyPress = True
                Exit Sub
            End If
            If dGridReceiveOrders.CurrentCell.ColumnIndex = dGridReceiveOrders.ColumnCount - 1 Then
                Dim strCellValue As String = Nothing
                If Not Object.Equals(dGridReceiveOrders.CurrentRow.Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridReceiveOrders.CurrentRow.Cells(0).Value.ToString) Then
                        strCellValue = dGridReceiveOrders.CurrentRow.Cells(0).Value.ToString
                    End If
                End If
                If String.IsNullOrEmpty(strCellValue) Then
                    InitializeRowValues(dGridReceiveOrders.CurrentRow.Index)
                    dGridReceiveOrders.CurrentCell = dGridReceiveOrders.CurrentRow.Cells(0)
                    e.SuppressKeyPress = True
                    Exit Sub
                Else
                    dGridReceiveOrders.Rows.Add(1)
                    dGridReceiveOrders.CurrentCell = dGridReceiveOrders.Rows(dGridReceiveOrders.Rows.Count - 1).Cells(0)
                    e.SuppressKeyPress = True
                    Exit Sub
                End If
            End If
            'Else
            '    e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub InitializeRowValues(RowIndex As Integer)
        For z As Integer = 0 To dGridReceiveOrders.Columns.Count - 1
            dGridReceiveOrders.Rows(RowIndex).Cells(z).Value = Nothing
        Next
    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr
        Dim dblPriceTotal As Double = 0
        Dim dblQuantityTotal As Double = 0
        Dim dblTotal As Double = 0
        For i As Integer = 0 To dGridReceiveOrders.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGridReceiveOrders.Rows(i).Cells(4).Value), "") Then
                If IsNumeric(dGridReceiveOrders.Rows(i).Cells(4).Value.ToString) Then
                    dblQuantityTotal = dblQuantityTotal + CDbl(dGridReceiveOrders.Rows(i).Cells(4).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGridReceiveOrders.Rows(i).Cells(3).Value), "") Then
                If IsNumeric(dGridReceiveOrders.Rows(i).Cells(3).Value.ToString) Then
                    dblPriceTotal = dblPriceTotal + CDbl(dGridReceiveOrders.Rows(i).Cells(3).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGridReceiveOrders.Rows(i).Cells(5).Value), "") Then
                If IsNumeric(dGridReceiveOrders.Rows(i).Cells(5).Value.ToString) Then
                    dblTotal = dblTotal + CDbl(dGridReceiveOrders.Rows(i).Cells(5).Value.ToString)
                End If
            End If
        Next
        lblCostTotal.Text = Format(dblPriceTotal, "#,##0.00")
        lblQuantityTotal.Text = Format(dblQuantityTotal, "#,##0.00")
        lblVatTotal.Text = Format(dblTotal, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on totals computation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand

        InitializeRowValues(dGridReceiveOrders.CurrentRow.Index)

        Dim boolItemTaxable As Boolean = True

        RecalculateAmount()

        If Not String.IsNullOrEmpty(strFullItemDetails) Then

            Dim strSplitValues() As String = Split(strFullItemDetails, ";")

            With dGridReceiveOrders
                .CurrentRow.Cells(0).Value = UCase(strSplitValues(0))
                .CurrentRow.Cells(1).Value = UCase(strSplitValues(1))
            End With


            Dim strCodeSelected As String = dGridReceiveOrders.CurrentRow.Cells(0).Value.ToString
            Dim dblSalePrice As Double = 0
            objCommand = New Data.OleDb.OleDbCommand("SELECT InventoryType, SellingPrice FROM InventoryItems " _
                & "WHERE ItemCode = '" & strCodeSelected & "'", cnn)
            Dim objReadType As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadType.HasRows Then
                objReadType.Read()
                If Not IsDBNull(objReadType(0).ToString) Then
                    If UCase(objReadType(0).ToString) = "SPECIFIC" Then
                        boolAbort = False
                        Dim frm As New frmSerialNumbersEntry
                        frm.showdialog()
                        If boolAbort = True Then
                            InitializeRowValues(dGridReceiveOrders.CurrentRow.Index)
                            dGridReceiveOrders.CurrentCell = dGridReceiveOrders.CurrentRow.Cells(0)
                            Exit Sub
                        Else
                            'Populate the grid downwards with the serialized items entries

                            'Item Code, Description, Serial, Unit Price, Qty, Total, Type, Image

                            With dGridReceiveOrders
                                For i As Integer = 0 To arrSerialsCaptured.Count - 1
                                    If i = 0 Then
                                        .CurrentRow.Cells(0).Value = UCase(strSplitValues(0))
                                        .CurrentRow.Cells(1).Value = UCase(strSplitValues(1))
                                        .CurrentRow.Cells(2).Value = UCase(arrSerialsCaptured.Item(i))
                                        .CurrentRow.Cells(3).Value = Format(dblSerializedCostPrice, "##0.00")
                                        .CurrentRow.Cells(4).Value = Format(1, "##0.00")
                                        .CurrentRow.Cells(5).Value = Format(dblSerializedCostPrice * 1, "##0.00")
                                        .CurrentRow.Cells(6).Value = "SPECIFIC"
                                    Else
                                        .Rows.Add(UCase(strSplitValues(0)), UCase(strSplitValues(1)), UCase(arrSerialsCaptured.Item(i)), _
                                            Format(dblSerializedCostPrice, "##0.00"), _
                                            Format(1, "##0.00"), Format(dblSerializedCostPrice * 1, "##0.00"), "SPECIFIC")
                                    End If
                                Next
                                .Rows.Add(1)
                                .CurrentCell = .Rows(.Rows.Count - 1).Cells(0)
                            End With
                            ComputeTotals()
                        End If
                    End If
                End If
                If IsNumeric(objReadType(1).ToString) Then dblSalePrice = CDbl(objReadType(1).ToString)
            End If
            objReadType.Close()
        Else
            InitializeRowValues(dGridReceiveOrders.CurrentRow.Index)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Goods Receiving"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub RecalculateAmount()

    End Sub

    Private Sub frmGoodsReceipt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Assign the summary data
        lblSupplierId.Text = strSelectedAccount
        lblSupplierName.Text = strSelectedAccountName
        lblDescription.Text = strOrderDescription
        lblDate.Text = strOrderDate
        lblBatchNo.Text = intSelectedBatchNumber
        lblVatNumber.Text = strSelectedVatNumber
        lblBranchName.Text = strReceivingBranchName
        lblOrderNumber.Text = Format(intNewOrderNumber, "000000")
        dGridReceiveOrders.Rows.Add(1)
    End Sub

    Private Sub btnSaveOrders_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveOrders.Click
        If IntPublicReceiveGoods <> 2 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        If dGridReceiveOrders.Rows.Count <= 0 Then
            MessageBox.Show("There are no items to be received", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        ReceiveGoods()
    End Sub

    Private Sub ReceiveGoods()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim dblTotalCosts As Double = 0
        Dim dblTaxAmount As Double = 0
        Dim objCommand As Data.OleDb.OleDbCommand

        Dim strTme As String = Format(Now, "dd-MMM-yyyy H:mm")

        For intRowIndex As Integer = 0 To dGridReceiveOrders.Rows.Count - 1

            If Not Object.Equals(dGridReceiveOrders.Rows(intRowIndex).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridReceiveOrders.Rows(intRowIndex).Cells(0).Value.ToString) Then


                    Dim strSql As String = Nothing

                    'Item Code, Description, Serial, Unit Price, Qty, Total, Type

                    Dim strItemType As String = "GENERIC"
                    If Not Object.Equals(dGridReceiveOrders.Rows(intRowIndex).Cells(6).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(dGridReceiveOrders.Rows(intRowIndex).Cells(6).Value.ToString) Then
                            strItemType = dGridReceiveOrders.Rows(intRowIndex).Cells(6).Value.ToString
                        End If
                    End If

                    Dim strItemCode As String = dGridReceiveOrders.Rows(intRowIndex).Cells(0).Value.ToString
                    Dim strSerials As String = Nothing
                    If Not Object.Equals(Convert.ToString(dGridReceiveOrders.Rows(intRowIndex).Cells(2).Value), "") Then
                        strSerials = dGridReceiveOrders.Rows(intRowIndex).Cells(2).Value.ToString
                    End If
                    Dim dblUnitPrice As Double = 0
                    If Not Object.Equals(Convert.ToString(dGridReceiveOrders.Rows(intRowIndex).Cells(3).Value), "") Then
                        If IsNumeric(dGridReceiveOrders.Rows(intRowIndex).Cells(3).Value.ToString) Then
                            dblUnitPrice = CDbl(dGridReceiveOrders.Rows(intRowIndex).Cells(3).Value.ToString)
                        End If
                    End If

                    Dim dblVat As Double = 0
                    'If Not Object.Equals(Convert.ToString(dGridReceiveOrders.Rows(intRowIndex).Cells(9).Value), "") Then
                    '    If IsNumeric(dGridReceiveOrders.Rows(intRowIndex).Cells(9).Value.ToString) Then
                    '        dblVat = CDbl(dGridReceiveOrders.Rows(intRowIndex).Cells(9).Value.ToString)
                    '    End If
                    'End If

                    Dim strItemDescription As String = Nothing
                    If Not Object.Equals(Convert.ToString(dGridReceiveOrders.Rows(intRowIndex).Cells(1).Value), "") Then
                        strItemDescription = dGridReceiveOrders.Rows(intRowIndex).Cells(1).Value.ToString
                    End If

                    Dim dblQuantityReceived As Double = 0
                    If Not Object.Equals(Convert.ToString(dGridReceiveOrders.Rows(intRowIndex).Cells(4).Value), "") Then
                        If IsNumeric(dGridReceiveOrders.Rows(intRowIndex).Cells(4).Value.ToString) Then
                            dblQuantityReceived = CDbl(dGridReceiveOrders.Rows(intRowIndex).Cells(4).Value.ToString)
                        End If
                    End If

                    Dim intOrderNumber As Integer = CInt(lblOrderNumber.Text)

                    Dim strNewBarCode As String = Nothing
                    Dim strNewSerialNo As String = Nothing
                    Dim strBaseBarCode As String = Nothing

                    If UCase(strItemType) = "SPECIFIC" Then
                        If Not String.IsNullOrEmpty(strSerials) Then
                            strNewBarCode = Space(intBarcodeLength - strSerials.Length) & strSerials
                            strNewSerialNo = Mid(strNewBarCode, (intBarcodeLength - (intBarcodeUserLength - 1)), intBarcodeUserLength)
                            strBaseBarCode = Mid(strNewBarCode, 1, (intBarcodeLength - intBarcodeUserLength))
                        End If
                        strSql = "INSERT INTO OrdersReceipt (TransDate, OrderNumber, Quantity, SerialNumbers, " _
                            & "UserName, Branch, ChangeDate, ItemCode, CostPrice, BaseBarCode, DestinationBranch, " _
                            & "BatchNo, SupplierId, VatNumber, VatAmount) " _
                            & "VALUES ('" & lblDate.Text & "', " _
                            & "" & intOrderNumber & ", 1, '" & strNewSerialNo & "', '" & strUserName & "', " _
                            & "'" & strUserBranch & "', '" & strTme & "', '" & strItemCode & "', " & dblUnitPrice & ", " _
                            & "'" & Trim(strBaseBarCode) & "', '" & lblBranchName.Text & "', " _
                            & "" & CInt(lblBatchNo.Text) & ", '" & lblSupplierId.Text & "', '" & lblVatNumber.Text & "', " & dblVat & ")"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()

                        'Update the inventory serial numbers and quantity if the user branch is the same as the receiving branch
                        If UCase(strUserBranch) = UCase(lblBranchName.Text) Then
                            If Not String.IsNullOrEmpty(strSerials) Then
                                strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber, BarCodeNo, SourceSerialNo, CostPrice) VALUES " _
                                    & "('" & strItemCode & "', '" & strNewSerialNo & "', '" & Trim(strBaseBarCode) & "', " _
                                    & "'" & strSerials & "', " & dblUnitPrice & ")"
                                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                objCommand.ExecuteNonQuery()
                            End If

                            strSql = "UPDATE InventoryItems SET Quantity = (InventoryItems.Quantity + 1) WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()
                        End If

                        'strItemsReceivedSerials = strItemsReceivedSerials & strSerials & ":>"

                    Else

                        'Get the packaging details

                        objCommand = New Data.OleDb.OleDbCommand("SELECT SupplyPackaging, SupplyPackagingQuantity FROM " _
                            & "InventoryItems WHERE ItemCode = '" & strItemCode & "'", cnn)
                        Dim objReadPackage As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                        Dim strPackType As String = "SINGLE"
                        Dim dblPackagingQuantity As Double = 1
                        If objReadPackage.HasRows Then
                            objReadPackage.Read()
                            If Not IsDBNull(objReadPackage(0).ToString) Then strPackType = UCase(objReadPackage(0).ToString)
                            If IsNumeric(objReadPackage(1).ToString) Then dblPackagingQuantity = CDbl(objReadPackage(1).ToString)
                        End If
                        objReadPackage.Close()

                       
                        strSql = "INSERT INTO OrdersReceipt (TransDate, OrderNumber, Quantity, SerialNumbers, " _
                            & "UserName, Branch, ChangeDate, ItemCode, CostPrice, BaseBarCode, Packaging, " _
                            & "DestinationBranch, BatchNo, SupplierId, VatNumber, VatAmount) VALUES ('" & lblDate.Text & "', " _
                            & "" & CInt(lblOrderNumber.Text) & ", " & dblQuantityReceived & ", '" & strSerials & "', '" & strUserName & "', " _
                            & "'" & strUserBranch & "', '" & strTme & "', '" & strItemCode & "', " & dblUnitPrice & ", " _
                            & "'" & strSerials & "', '" & strPackType & "', '" & lblBranchName.Text & "', " _
                            & "" & CInt(lblBatchNo.Text) & ", '" & lblSupplierId.Text & "', '" & lblVatNumber.Text & "', " & dblVat & ")"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()

                        'Update the item Quantity based on the pack

                        If UCase(strPackType) = "PACK" Then
                            dblQuantityReceived = dblQuantityReceived * dblPackagingQuantity
                        End If

                        strSql = "UPDATE InventoryItems SET Quantity = (InventoryItems.Quantity + " & dblQuantityReceived & ") " _
                            & "WHERE ItemCode = '" & strItemCode & "'"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()

                        'strItemsReceivedSerials = strSerials

                    End If

                    dblTotalCosts = dblTotalCosts + dblUnitPrice
                    dblTaxAmount = dblTaxAmount + dblVat

                    'Adjust cost 
                    If Not Object.Equals(dGridReceiveOrders.Rows(intRowIndex).Cells(dGridReceiveOrders.ColumnCount - 1).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(dGridReceiveOrders.Rows(intRowIndex).Cells(dGridReceiveOrders.ColumnCount - 1).Value.ToString) Then
                            If UCase(dGridReceiveOrders.Rows(intRowIndex).Cells(dGridReceiveOrders.ColumnCount - 1).Value.ToString) = "Y" Then
                                UpdateCostPrice(strItemCode, dblUnitPrice)
                            End If
                        End If
                    End If

                End If
            End If
        Next


        Dim intSpecialKey As Integer = gwt_comm.SpecialKey()

        'Update the orders next number
        objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET Orders = " & intNewOrderNumber + 1 & "", cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default

        MessageBox.Show("Order has been successfully saved", "Orders Processing", MessageBoxButtons.OK, MessageBoxIcon.Information)

        boolPrinterAlreadySelected = False
        gwt_comm.PrintCustomerDocument(CInt(lblBatchNo.Text), "GOODS RECEIVED NOTE")

        dGridReceiveOrders.Rows.Clear()
        boolAbort = False
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Item save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        On Error Resume Next
        With dGridReceiveOrders
            .Rows.RemoveAt(dGridReceiveOrders.CurrentRow.Index)
            ComputeTotals()
            If .Rows.Count <= 0 Then
                .Rows.Add(1)
                .CurrentCell = .Rows(0).Cells(0)
            End If
        End With
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        boolEditStatus = False
        Dim frm As New frmInventorySetup
        frm.ShowDialog()
    End Sub

    Private Sub UpdateCostPrice(ByVal ItemCode As String, ByVal CostPrice As Double)
        On Error GoTo RaiseErr
        Dim dblNewCostPrice As Double = CostPrice
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CostFactor FROM InventoryItemsCostsAnalysis WHERE ItemCode = '" & ItemCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If IsNumeric(objReader(0).ToString) Then
                If CDbl(objReader(0).ToString) <> 0 Then
                    dblNewCostPrice = dblNewCostPrice + (CostPrice * (CDbl(objReader(0).ToString) / 100))
                End If
            End If
        End While
        objReader.Close()

        'Update the cost price
        objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET CostPrice = " & dblNewCostPrice & " " _
            & "WHERE ItemCode = '" & ItemCode & "'", cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On orders received form load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmGoodsReceipt_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 872 : Me.Height = 650
    End Sub

End Class
