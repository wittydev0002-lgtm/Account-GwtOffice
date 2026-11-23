Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventoryCodeChange

    Private Sub frmInventoryCodeChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
        If boolCalledFromListing = True Then
            cboItems.SelectedText = strInventoryItemCode
            lblDescription.Text = strSelectedCodeDescription
            txtNewCode.Text = strInventoryItemCode
            txtNewCode.Focus()
            cboItems.Enabled = False
        End If
        txtNewCode.Focus()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Select Case UCase(strMainCompanyServiceOffering)
            Case Is = "PRODUCTS"
                strSql = "SELECT ItemCode +';'+GroupName AS " _
                    & "[Items] FROM InventoryItems WHERE Offering = 'PRODUCT' ORDER BY ItemCode"
            Case Is = "SERVICES"
                strSql = "SELECT ItemCode +';'+GroupName AS " _
                    & "[Items] FROM InventoryItems WHERE Offering = 'SERVICE' ORDER BY ItemCode"
            Case Is = "HIRING ITEMS"
                strSql = "SELECT ItemCode +';'+GroupName AS " _
                    & "[Items] FROM InventoryItems WHERE Offering = 'HIRE ITEM' ORDER BY ItemCode"
            Case Else
                strSql = "SELECT ItemCode +';'+GroupName AS " _
                    & "[Items] FROM InventoryItems ORDER BY ItemCode"
        End Select

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "220;240"
        End With
        'Get a count of the items
        Dim intItemsCount As Double = 0

        Select Case UCase(strMainCompanyServiceOffering)
            Case Is = "PRODUCTS"
                strSql = "SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'PRODUCT'"
            Case Is = "SERVICES"
                strSql = "SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'SERVICE'"
            Case Is = "HIRING ITEMS"
                strSql = "SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'HIRE ITEM'"
            Case Else
                strSql = "SELECT Count(ItemCode) FROM InventoryItems"
        End Select

        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboItems.Items.Clear()
        Dim i As Double = 0
        Dim p As Double = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
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

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtNewCode.Text) Then
            MessageBox.Show("Please enter the new inventory code", "Missing New Inventory Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNewCode.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboItems.Text) Or String.IsNullOrEmpty(lblDescription.Text) Then
            MessageBox.Show("Please enter the old inventory code", "Missing Old Inventory Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboItems.Focus()
            Exit Sub
        End If

        'Check that the item does not already exist

        Dim boolItemExists As Boolean = False
        Dim dblCurrentQuantity As Double = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & txtNewCode.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblCurrentQuantity = CDbl(objReader(0).ToString)
            End If
            boolItemExists = True
        End If
        objReader.Close()

        Dim strAffectedTables As String = "InventoryItems|sales|CustomerSales|GenericItemsBarcodes|GroupSales|" _
            & "InventoryQuantitySplit|InventoryTransfers|InventoryTransfersIn|ItemAssemblies|" _
            & "InventoryGroup|ItemSpecials|OrderApprovals|OrdersReceipt|OrdersTransactions|PrestockCounts|PrestockSerials|" _
            & "QuoteDetails|ReceivedOrders|SalesExchanges|StockCount|StockTake|StoresIssues|" _
            & "StoresReturns|SupplierOrders|VoidSales|InventoryComponents|SerialNumbers"
        Dim strBuffer() As String = Split(strAffectedTables, "|")
        ProgressBar1.Value = 0 : ProgressBar1.Maximum = (strBuffer.Length + 1)

        If boolItemExists = True Then
            If MessageBox.Show("This item code already exists. Do you want to update instead?", _
                "Duplicate Item Code", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                For n As Integer = 0 To strBuffer.Length - 1
                    If UCase(strBuffer(n)) <> UCase("InventoryGroup") Then

                        If UCase(strBuffer(n)) = UCase("ItemSpecials") Then
                            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM " & strBuffer(n) & " WHERE AppliesTo = '" & cboItems.Text & "'", cnn)
                            objCommand.ExecuteNonQuery()
                        Else
                            If UCase(strBuffer(n)) = UCase("InventoryComponents") Then
                                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM " & strBuffer(n) & " WHERE ItemCode = '" & cboItems.Text & "'", cnn)
                                objCommand.ExecuteNonQuery()
                                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM " & strBuffer(n) & " WHERE MakeupItemCode = '" & cboItems.Text & "'", cnn)
                                objCommand.ExecuteNonQuery()
                            Else
                                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM " & strBuffer(n) & " WHERE ItemCode = '" & cboItems.Text & "'", cnn)
                                objCommand.ExecuteNonQuery()
                            End If
                        End If
                    End If
                    ProgressBar1.Value = ProgressBar1.Value + 1
                Next

                'Update the new code with quantinty
                objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET " _
                    & "Quantity = (Quantity + " & dblCurrentQuantity & ") " _
                    & "WHERE ItemCode = '" & txtNewCode.Text & "'", cnn)
                objCommand.ExecuteNonQuery()

                MessageBox.Show("Item code successfully changed in the entire system", _
                    "Item Code Change Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtNewCode.Clear()
                cboItems.Text = ""
                cboItems.Focus()

            Else
                Exit Sub
            End If

        Else

            For n As Integer = 0 To strBuffer.Length - 1
                If UCase(strBuffer(n)) <> UCase("InventoryGroup") Then

                    If UCase(strBuffer(n)) = UCase("ItemSpecials") Then
                        objCommand = New Data.OleDb.OleDbCommand("UPDATE " & strBuffer(n) & " SET AppliesTo = '" & txtNewCode.Text & "' " _
                            & "WHERE AppliesTo = '" & cboItems.Text & "'", cnn)
                        objCommand.ExecuteNonQuery()
                    Else
                        If UCase(strBuffer(n)) = UCase("InventoryComponents") Then
                            objCommand = New Data.OleDb.OleDbCommand("UPDATE " & strBuffer(n) & " SET ItemCode = '" & txtNewCode.Text & "' " _
                                & "WHERE ItemCode = '" & cboItems.Text & "'", cnn)
                            objCommand.ExecuteNonQuery()
                            objCommand = New Data.OleDb.OleDbCommand("UPDATE " & strBuffer(n) & " SET MakeupItemCode = '" & txtNewCode.Text & "' " _
                                & "WHERE MakeupItemCode = '" & cboItems.Text & "'", cnn)
                            objCommand.ExecuteNonQuery()
                        Else
                            objCommand = New Data.OleDb.OleDbCommand("UPDATE " & strBuffer(n) & " SET ItemCode = '" & txtNewCode.Text & "' " _
                                & "WHERE ItemCode = '" & cboItems.Text & "'", cnn)
                            objCommand.ExecuteNonQuery()
                        End If
                    End If
                End If
                ProgressBar1.Value = ProgressBar1.Value + 1
            Next
            MessageBox.Show("Item code successfully changed in the entire system", "Item Code Change Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNewCode.Clear()
            cboItems.Text = ""
            cboItems.Focus()

        End If
        
        If boolCalledFromListing = True Then
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Change"
        ShowErrorMessage()
    End Sub

    Private Sub cboItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItems.SelectedIndexChanged
        On Error Resume Next
        lblDescription.Text = ""
        lblDescription.Text = cboItems.SelectedItem.Col2
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtNewCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNewCode.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If e.KeyChar = " " Then
            If strCompanyAllowsSpacesOnItemCodes = "NO" Then
                e.KeyChar = "-"
            End If
        End If
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
    End Sub

End Class
