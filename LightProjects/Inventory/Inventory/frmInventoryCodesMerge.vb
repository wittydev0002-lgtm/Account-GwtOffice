Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventoryCodesMerge

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT ItemCode +';'+GroupName AS " _
            & "[Items] FROM InventoryItems ORDER BY ItemCode"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboSourceItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "240;280"
        End With
        With cboDestinationItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "240;280"
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

        cboSourceItems.Items.Clear() : cboDestinationItems.Items.Clear()
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
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboSourceItems.SelectedIndex = -1
            cboSourceItems.Items.Clear()
            cboSourceItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboSourceItems.Items.AddRange(DropDownItems)

            cboDestinationItems.SelectedIndex = -1
            cboDestinationItems.Items.Clear()
            cboDestinationItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboDestinationItems.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboSourceItems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSourceItems.KeyPress
        lblSourceDescription.Text = ""
    End Sub

    Private Sub cboSourceItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSourceItems.SelectedIndexChanged
        On Error Resume Next
        lblSourceDescription.Text = ""
        lblSourceDescription.Text = cboSourceItems.SelectedItem.Col2
    End Sub

    Private Sub cboDestinationItems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDestinationItems.KeyPress
        lblDestineDescription.Text = ""
    End Sub

    Private Sub cboDestinationItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDestinationItems.SelectedIndexChanged
        On Error Resume Next
        lblDestineDescription.Text = ""
        lblDestineDescription.Text = cboDestinationItems.SelectedItem.Col2
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(cboSourceItems.Text) Or String.IsNullOrEmpty(lblSourceDescription.Text) Then
            MessageBox.Show("Please enter a valid item code for the source inventory code", "Invalid Item Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSourceItems.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboDestinationItems.Text) Or String.IsNullOrEmpty(cboDestinationItems.Text) Then
            MessageBox.Show("Please enter a valid item code for the destination inventory code", "Invalid Item Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboDestinationItems.Focus()
            Exit Sub
        End If
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strErredTable As String = Nothing
        'The affected tables are :
        '
        ' Sales, VoidedSales, CustomerSales, VoidedCustomerSales, SerialNumbers, Ordersreceipt
        ' InventoryTransfers, InventoryTransfersIn, InventoryComponents, InventoryCostPrices, InventoryCostsParameters, 
        ' InventoryCounts, InventoryGroup, InventoryItemsCostsAnalysis, InventoryOrders, InventoryQuantitySplit, 
        ' InventoryRejections, InventoryRejectionsStatus, InventoryTransfers, InventoryTransfersIn, ItemAssemblies, 
        ' ItemSpecials, LaybySales, LoyalityEntries, OrderApprovals, OrdersReceipt, OrdersTransactions, PrestockCounts, 
        ' PrestockSerials, QuoteDetails, ReceivedOrders, SalesExchanges, SbuInventoryItems, SbuSerialNumbers, SerialNumbers, 
        ' StaffSales, StockCount, StockTake, StoresIssues, StoresReturns, SupplierInvoicesDetails, SupplierOrders, 
        ' TicketSales, VoidedGatePasses, GatePasses
        '

        Dim strTables As String = "Sales, VoidSales, CustomerSales, " _
            & "InventoryTransfers, InventoryTransfersIn, InventoryComponents, InventoryCostPrices, " _
            & "InventoryCounts, InventoryItemsCostsAnalysis, InventoryQuantitySplit, " _
            & "InventoryRejections, ItemAssemblies, " _
            & "LaybySales, LoyalityEntries, OrderApprovals, OrdersReceipt, OrdersTransactions, PrestockCounts,  " _
            & "PrestockSerials, QuoteDetails, ReceivedOrders, SalesExchanges, SbuInventoryItems, SbuSerialNumbers, SerialNumbers, " _
            & "StaffSales, StockCount, StockTake, StoresIssues, StoresReturns, SupplierInvoicesDetails, SupplierOrders, " _
            & "TicketSales, VoidedGatePasses, GatePasses"
        'ItemSpecials, InventoryRejectionStatus

        Dim strCurrentActionTable() As String = Split(strTables, ", ")
        pb1.Maximum = strCurrentActionTable.Length : pb1.Value = 0
        For i As Integer = 0 To strCurrentActionTable.Length - 1
            strErredTable = strCurrentActionTable(i)
            Dim objCommand As Data.OleDb.OleDbCommand
            If i = 0 Then
                Dim intQuantity As Integer = 0
                objCommand = New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & cboSourceItems.Text & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then intQuantity = CInt(objReader(0).ToString)
                End If
                objReader.Close()
                'Delete the record from the Inventory table
                If chkDelete.Checked = True Then
                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM InventoryItems WHERE ItemCode = '" & cboSourceItems.Text & "'", cnn)
                    objCommand.ExecuteNonQuery()
                    'InventoryGroup
                    'objCommand = New Data.OleDb.OleDbCommand("DELETE FROM InventoryGroup WHERE ItemCode = '" & cboSourceItems.Text & "'", cnn)
                    'objCommand.ExecuteNonQuery()
                End If
                'Update the inventory table quantities
                objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = " & intQuantity & " WHERE ItemCode = '" & cboDestinationItems.Text & "'", cnn)
                objCommand.ExecuteNonQuery()
            End If

            'Update the inventory table quantities
            objCommand = New Data.OleDb.OleDbCommand("UPDATE " & strCurrentActionTable(i) & " SET ItemCode = '" & cboDestinationItems.Text & "'", cnn)
            objCommand.ExecuteNonQuery()

            pb1.Value = pb1.Value + 1
        Next
        Cursor = Cursors.Default
        If MessageBox.Show("Inventory Codes merged successfully. Do you want to make further changes?", _
                "Inventory Codes Merge", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            lblSourceDescription.Text = "" : cboSourceItems.Text = ""
            lblDestineDescription.Text = "" : cboDestinationItems.Text = ""
        Else
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On item merge processing for table " & strErredTable
        ShowErrorMessage()
    End Sub

    Private Sub frmInventoryCodesMerge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

End Class
