Imports CommonLibrary.Commons
Imports System.Windows.Forms

Public Class frmInventoryNewCode

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub txtItemCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemCode.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Or e.KeyChar = "'" Then e.Handled = True
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Then e.Handled = True
        If e.KeyChar = " " Then
            If strCompanyAllowsSpacesOnItemCodes = "NO" Then
                e.KeyChar = "-"
            End If
            'e.Handled = True
        End If
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtItemCode.Text) Then
            MessageBox.Show("Please enter the new inventory code", "Missing New Inventory Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtItemCode.Focus()
            Exit Sub
        End If

        Dim strAffectedTables As String = "InventoryItems|sales|CustomerSales|GenericItemsBarcodes|GroupSales|" _
            & "InventoryGroup|InventoryQuantitySplit|InventoryTransfers|InventoryTransfersIn|ItemAssemblies|" _
            & "ItemSpecials|OrderApprovals|OrdersReceipt|OrdersTransactions|PrestockCounts|PrestockSerials|" _
            & "QuoteDetails|ReceivedOrders|SalesExchanges|StockCount|StockTake|StoresIssues|" _
            & "StoresReturns|SupplierOrders|VoidSales|InventoryComponents|SerialNumbers"
        Dim strBuffer() As String = Split(strAffectedTables, "|")

        Cursor = Cursors.WaitCursor

        For n As Integer = 0 To strBuffer.Length - 1
            If UCase(strBuffer(n)) <> UCase("InventoryGroup") Then
                Dim objCommand As Data.OleDb.OleDbCommand
                If UCase(strBuffer(n)) = UCase("ItemSpecials") Then
                    objCommand = New Data.OleDb.OleDbCommand("UPDATE " & strBuffer(n) & " SET AppliesTo = '" & txtItemCode.Text & "' " _
                        & "WHERE AppliesTo = '" & strInventoryItemCode & "'", cnn)
                    objCommand.ExecuteNonQuery()
                Else
                    If UCase(strBuffer(n)) = UCase("InventoryComponents") Then
                        objCommand = New Data.OleDb.OleDbCommand("UPDATE " & strBuffer(n) & " SET ItemCode = '" & txtItemCode.Text & "' " _
                            & "WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
                        objCommand.ExecuteNonQuery()
                        objCommand = New Data.OleDb.OleDbCommand("UPDATE " & strBuffer(n) & " SET MakeupItemCode = '" & txtItemCode.Text & "' " _
                            & "WHERE MakeupItemCode = '" & strInventoryItemCode & "'", cnn)
                        objCommand.ExecuteNonQuery()
                    Else
                        objCommand = New Data.OleDb.OleDbCommand("UPDATE " & strBuffer(n) & " SET ItemCode = '" & txtItemCode.Text & "' " _
                            & "WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                End If
            End If

        Next
        strNewInventoryItemCode = txtItemCode.Text
        Cursor = Cursors.Default
        MessageBox.Show("Item code successfully changed in the entire system", "Item Code Change Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        boolAbort = False
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Change"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmInventoryNewCode_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtItemCode.Text = strInventoryItemCode
    End Sub

End Class
