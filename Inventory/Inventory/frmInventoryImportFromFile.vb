Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventoryImportFromFile

    Dim arrErrors As ArrayList

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofd.ShowDialog()
        txtFileName.Text = ofd.FileName
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(txtFileName.Text) Then
            If System.IO.File.Exists(txtFileName.Text) Then
                If TabControl1.SelectedIndex = 0 Then
                    Dim objFileReader As New System.IO.StreamReader(txtFileName.Text)
                    Dim strLine As String = objFileReader.ReadToEnd
                    objFileReader.Close()
                    Dim strLineItems() As String = Split(strLine, vbCrLf)
                    Dim intCount As Integer = strLineItems.Length

                    pb1.Maximum = intCount + 1 : pb1.Value = 0 : pb1.Visible = True
                    dGrid.Rows.Clear()

                    For i As Integer = 0 To strLineItems.Length - 1
                        If Not String.IsNullOrEmpty(strLineItems(i)) Then
                            Dim strFieldItems() As String = Split(strLineItems(i), "|")
                            dGrid.Rows.Add(strFieldItems(0), strFieldItems(1), strFieldItems(2), strFieldItems(3), strFieldItems(4), _
                                strFieldItems(5), strFieldItems(6), strFieldItems(7), strFieldItems(8), strFieldItems(9), strFieldItems(10), _
                                strFieldItems(11), strFieldItems(12), strFieldItems(13), strFieldItems(14))
                        End If
                        pb1.Value = pb1.Value + 1
                    Next
                Else
                    Dim objFileReader As New System.IO.StreamReader(txtFileName.Text)
                    Dim strLine As String = objFileReader.ReadToEnd
                    objFileReader.Close()
                    Dim strLineItems() As String = Split(strLine, vbCrLf)
                    Dim intCount As Integer = strLineItems.Length

                    pb1.Maximum = intCount + 1 : pb1.Value = 0 : pb1.Visible = True
                    dGridUpdates.Rows.Clear()

                    For i As Integer = 0 To strLineItems.Length - 1
                        If Not String.IsNullOrEmpty(strLineItems(i)) Then
                            Dim strFieldItems() As String = Split(strLineItems(i), "|")
                            dGridUpdates.Rows.Add(strFieldItems(0), strFieldItems(1))
                        End If
                        pb1.Value = pb1.Value + 1
                    Next
                End If
            End If
        Else
            MessageBox.Show("Please select the source file name", "Missing File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnBrowse.Focus()
            Exit Sub
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On inventory details import"
        ShowErrorMessage()
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        If TabControl1.SelectedIndex = 0 Then UploadInventoryData() Else UpdateInventoryCodes()
    End Sub

    Private Sub UpdateInventoryCodes()
        On Error GoTo RaiseErr
        arrErrors = New ArrayList
        Dim strSql As String = Nothing
        If dGridUpdates.Rows.Count > 0 Then

            pb1.Maximum = dGridUpdates.Rows.Count + 1 : pb1.Value = 0 : pb1.Visible = True

            For n As Integer = 0 To dGridUpdates.Rows.Count - 1

                Dim strItemCode As String = Nothing
                Dim strNewItemCode As String = Nothing

                If Not (Object.Equals(Convert.ToString(dGridUpdates.Rows(n).Cells(0).Value), "")) Then
                    strItemCode = dGridUpdates.Rows(n).Cells(0).Value.ToString
                    If Not (Object.Equals(Convert.ToString(dGridUpdates.Rows(n).Cells(1).Value), "")) Then
                        strNewItemCode = dGridUpdates.Rows(n).Cells(1).Value.ToString
                    End If

                    If chkCapital.Checked = True Then
                        strNewItemCode = UCase(strNewItemCode)
                    End If
                    If chkRemoveSpaces.Checked = True Then
                        strNewItemCode = Trim(strNewItemCode)
                        strNewItemCode = Replace(strNewItemCode, " ", "-", 1)
                    End If

                    If Not String.IsNullOrEmpty(strNewItemCode) Then
                        'First check that the item does not exist in the database
                        Dim objCmdCheckExistence As New Data.OleDb.OleDbCommand("SELECT ItemCode FROM InventoryItems " _
                            & "WHERE ItemCode = '" & strNewItemCode & "'", cnn)
                        Dim objReader As Data.OleDb.OleDbDataReader = objCmdCheckExistence.ExecuteReader
                        If objReader.HasRows = False Then
                            'Update the main inventory table
                            strSql = "UPDATE InventoryItems SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update the sales table
                            strSql = "UPDATE Sales SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update the serial numbers table
                            strSql = "UPDATE SerialNumbers SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update the transfers table

                            'Update the invoices table 'CustomerSales
                            strSql = "UPDATE CustomerSales SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update the quotations table

                            'Update the credit notes entry 'CreditNoteEntries
                            strSql = "UPDATE CreditNoteEntries SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update the DisposedInventory
                            strSql = "UPDATE DisposedInventory SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update the GatePasses
                            strSql = "UPDATE GatePasses SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update the GenericItemsBarcodes
                            strSql = "UPDATE GenericItemsBarcodes SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update GroupSales
                            strSql = "UPDATE GroupSales SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update InventoryComponents
                            strSql = "UPDATE InventoryComponents SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update InventoryCounts
                            strSql = "UPDATE InventoryCounts SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update InventoryItemsCostsAnalysis
                            strSql = "UPDATE InventoryItemsCostsAnalysis SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update InventoryQuantitySplit
                            strSql = "UPDATE InventoryQuantitySplit SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update InventoryTransfers
                            strSql = "UPDATE InventoryTransfers SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update InventoryTransfersIn
                            strSql = "UPDATE InventoryTransfersIn SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update ItemAssemblies
                            strSql = "UPDATE ItemAssemblies SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update dbo.ItemSpecials == AppliesTo
                            strSql = "UPDATE ItemSpecials SET AppliesTo = '" & UCase(strNewItemCode) & "' WHERE AppliesTo = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update LaybySales
                            strSql = "UPDATE LaybySales SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update LoyaltyPromotions
                            strSql = "UPDATE LoyaltyPromotions SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update OrderApprovals
                            strSql = "UPDATE OrderApprovals SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update OrdersReceipt
                            strSql = "UPDATE OrdersReceipt SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update PrestockCounts
                            strSql = "UPDATE PrestockCounts SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update PrestockSerials
                            strSql = "UPDATE PrestockSerials SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update QuoteDetails
                            strSql = "UPDATE QuoteDetails SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update ReceivedOrders
                            strSql = "UPDATE ReceivedOrders SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update SalesExchanges
                            strSql = "UPDATE SalesExchanges SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update StaffSales
                            strSql = "UPDATE StaffSales SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update StockCount
                            strSql = "UPDATE StockCount SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update StockTake
                            strSql = "UPDATE StockTake SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update StoresIssues
                            strSql = "UPDATE StoresIssues SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update StoresReturns
                            strSql = "UPDATE StoresReturns SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update SupplierInvoicesDetails
                            strSql = "UPDATE SupplierInvoicesDetails SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Updaete SupplierOrders
                            strSql = "UPDATE SupplierOrders SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update TicketSales
                            strSql = "UPDATE TicketSales SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update VoidedGatePasses
                            strSql = "UPDATE VoidedGatePasses SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update VoidSales
                            strSql = "UPDATE VoidSales SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                            'Update stock take count
                            strSql = "UPDATE InventoryStockTake SET ItemCode = '" & UCase(strNewItemCode) & "' WHERE ItemCode = '" & strItemCode & "'"
                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()

                        Else
                            arrErrors.Add(strItemCode & " to " & strNewItemCode)
                        End If
                        objReader.Close()
                    End If
                    pb1.Value = pb1.Value + 1
                End If
            Next
        End If

        If arrErrors.Count > 0 Then
            MessageBox.Show("There were errors found and have been written to error file", "Item Code Change", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Dim objFileWriter As New StreamWriter(Application.StartupPath & "\Errors.txt")
            For i As Integer = 0 To arrErrors.Count - 1
                objFileWriter.WriteLine(arrErrors.Item(i))
            Next
            objFileWriter.Close()
        End If
        MessageBox.Show("Inventory Items Updated Successfully", "Inventory Items Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Data Items Update" & vbCrLf & strSql
        ShowErrorMessage()
    End Sub

    Private Sub UploadInventoryData()
        On Error GoTo RaiseErr
        If dGrid.Rows.Count > 0 Then

            pb1.Maximum = dGrid.Rows.Count + 1 : pb1.Value = 0 : pb1.Visible = True

            For n As Integer = 0 To dGrid.Rows.Count - 1

                Dim strItemCode As String = Nothing
                Dim strGroupName As String = Nothing
                Dim strDescription As String = Nothing
                Dim dblSellingPrice As Double = 0
                Dim dblCostPrice As Double = 0
                Dim strLocation As String = Nothing
                Dim strCategory As String = Nothing
                Dim strSubCategory As String = Nothing
                Dim intQuantity As Integer = 0
                Dim strInventoryType As String = Nothing
                Dim intMinimumLevel As Integer = 0
                Dim intWarningLevel As Integer = 0
                Dim intIdealLevel As Integer = 0
                Dim strTaxStatus As String = "YES"
                Dim strSerialNumbers As String = Nothing

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(0).Value), "")) Then
                    strItemCode = dGrid.Rows(n).Cells(0).Value.ToString
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(1).Value), "")) Then
                        strGroupName = dGrid.Rows(n).Cells(1).Value.ToString
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(2).Value), "")) Then
                        strDescription = dGrid.Rows(n).Cells(2).Value.ToString
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(3).Value), "")) Then
                        If IsNumeric(dGrid.Rows(n).Cells(3).Value.ToString) Then
                            dblSellingPrice = dGrid.Rows(n).Cells(3).Value.ToString
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(4).Value), "")) Then
                        If IsNumeric(dGrid.Rows(n).Cells(4).Value.ToString) Then
                            dblCostPrice = dGrid.Rows(n).Cells(4).Value.ToString
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(5).Value), "")) Then
                        strLocation = dGrid.Rows(n).Cells(5).Value.ToString
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(6).Value), "")) Then
                        strCategory = dGrid.Rows(n).Cells(6).Value.ToString
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(7).Value), "")) Then
                        strSubCategory = dGrid.Rows(n).Cells(7).Value.ToString
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(8).Value), "")) Then
                        If IsNumeric(dGrid.Rows(n).Cells(8).Value.ToString) Then
                            intQuantity = dGrid.Rows(n).Cells(8).Value.ToString
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(9).Value), "")) Then
                        strInventoryType = dGrid.Rows(n).Cells(9).Value.ToString
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(10).Value), "")) Then
                        If IsNumeric(dGrid.Rows(n).Cells(10).Value.ToString) Then
                            intMinimumLevel = dGrid.Rows(n).Cells(10).Value.ToString
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(11).Value), "")) Then
                        If IsNumeric(dGrid.Rows(n).Cells(11).Value.ToString) Then
                            intWarningLevel = dGrid.Rows(n).Cells(11).Value.ToString
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(12).Value), "")) Then
                        If IsNumeric(dGrid.Rows(n).Cells(12).Value.ToString) Then
                            intIdealLevel = dGrid.Rows(n).Cells(12).Value.ToString
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(13).Value), "")) Then
                        strTaxStatus = dGrid.Rows(n).Cells(13).Value.ToString
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(14).Value), "")) Then
                        strSerialNumbers = dGrid.Rows(n).Cells(14).Value.ToString
                    End If

                    'First check that the item does not exist in the database
                    Dim objCmdCheckExistence As New Data.OleDb.OleDbCommand("SELECT ItemCode FROM InventoryItems " _
                        & "WHERE ItemCode = '" & strItemCode & "'", cnn)
                    Dim objReader As Data.OleDb.OleDbDataReader = objCmdCheckExistence.ExecuteReader
                    If objReader.HasRows = False Then
                        Dim strSql As String = "INSERT INTO InventoryItems ([ItemCode],[GroupName],[Description]," _
                            & "[SellingPrice],[CostPrice],[Location],[Category],[SubCategory],[Quantity],[InventoryType]," _
                            & "[MinimumLevel],[WarningLevel],[IdealLevel],[TaxStatus],[SerialNumbers]) VALUES " _
                            & "('" & strItemCode & "', '" & strGroupName & "', '" & strDescription & "', " & dblSellingPrice & ", " _
                            & "" & dblCostPrice & ", '" & strLocation & "', '" & strCategory & "', '" & strSubCategory & "', " _
                            & "" & intQuantity & ", '" & strInventoryType & "', " & intMinimumLevel & ", " & intWarningLevel & ", " _
                            & "" & intIdealLevel & ", '" & strTaxStatus & "', '" & strSerialNumbers & "')"
                        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                    objReader.Close()

                    'Check that the category exists and add accordingly
                    objCmdCheckExistence = New Data.OleDb.OleDbCommand("SELECT Category FROM Categories WHERE Category = '" & strCategory & "'", cnn)
                    objReader = objCmdCheckExistence.ExecuteReader
                    If objReader.HasRows = False Then
                        objCmdCheckExistence = New Data.OleDb.OleDbCommand("INSERT INTO Categories (Category) VALUES ('" & strCategory & "')", cnn)
                        objCmdCheckExistence.ExecuteNonQuery()
                    End If
                    objReader.Close()

                    'Check that the sub category exists and add accordingly
                    objCmdCheckExistence = New Data.OleDb.OleDbCommand("SELECT SubCategory FROM SubCategories WHERE " _
                        & "Category = '" & strCategory & "' AND SubCategory = '" & strSubCategory & "'", cnn)
                    objReader = objCmdCheckExistence.ExecuteReader
                    If objReader.HasRows = False Then
                        objCmdCheckExistence = New Data.OleDb.OleDbCommand("INSERT INTO SubCategories (Category, SubCategory) VALUES " _
                            & "('" & strCategory & "', '" & strSubCategory & "')", cnn)
                        objCmdCheckExistence.ExecuteNonQuery()
                    End If
                    objReader.Close()

                End If
                pb1.Value = pb1.Value + 1
            Next
        End If
        MessageBox.Show("Inventory Items Updated Successfully", "Inventory Items Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Data Items Update"
        ShowErrorMessage()
    End Sub

End Class
