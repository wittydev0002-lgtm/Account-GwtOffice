Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary
Imports CommonLibrary.Commons

Public Class frmReceivedItemsCostAdjust

    Private Sub frmReceivedItemsCostAdjust_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If arrSelectedItems.Count > 0 Then
            txtItemCode.Text = arrSelectedItems.Item(0)
            txtDescription.Text = arrSelectedItems.Item(1)
            txtSerial.Text = arrSelectedItems.Item(2)
            txtCost.Text = arrSelectedItems.Item(3)
            txtQty.Text = arrSelectedItems.Item(4)
            txtBatchNo.Text = intSelectedBatchNumber
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtCost_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCost.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            btnOK.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtCost.Text) Then
            MessageBox.Show("Invalid Data", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCost.Focus()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim strSql As String = "UPDATE OrdersReceipt SET CostPrice = " & txtCost.Text & " WHERE TransactionId = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Get the actual serial number from OrdersReceipt.SerialNumbers
        Dim strItemSerial As String = Nothing
        strSql = "SELECT OrdersReceipt.SerialNumbers FROM OrdersReceipt WHERE TransactionId = " & intSelectedTransaction & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strItemSerial = objReader(0).ToString
        End If
        objReader.Close()

        'Update the inventory serial numbers and quantity if the user branch is the same as the receiving branch
        strSql = "UPDATE SerialNumbers SET CostPrice = " & txtCost.Text & " WHERE ItemCode = '" & txtItemCode.Text & "' AND " _
             & "SerialNumber = '" & strItemSerial & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Update with the new serial number
        If Not String.IsNullOrEmpty(txtNewSerial.Text) Then
            'Decode the the barcode
            Dim strSerials As String = txtNewSerial.Text

            'Check the item existence
            If gwt_comm.CheckSerialExistence(strSerials) = True Then
                MessageBox.Show("Serial number has already been captured", "Duplicate Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                txtNewSerial.Focus()
                Exit Sub
            End If

            Dim strNewBarCode As String = Nothing
            Dim strNewSerialNo As String = Nothing
            Dim strBaseBarCode As String = Nothing

            strNewBarCode = Space(intBarcodeLength - strSerials.Length) & strSerials
            strNewSerialNo = Mid(strNewBarCode, (intBarcodeLength - (intBarcodeUserLength - 1)), intBarcodeUserLength)
            strBaseBarCode = Mid(strNewBarCode, 1, (intBarcodeLength - intBarcodeUserLength))

            If Not String.IsNullOrEmpty(txtSerial.Text) Then
                strSql = "UPDATE SerialNumbers SET SerialNumber = '" & strNewSerialNo & "', " _
                    & "BarCodeNo = '" & Trim(strBaseBarCode) & "', SourceSerialNo = '" & strSerials & "' " _
                    & "WHERE ItemCode = '" & txtItemCode.Text & "' AND SerialNumber = '" & strItemSerial & "'"
            Else
                'Insert as new item serial number
                strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber, BarCodeNo, SourceSerialNo, CostPrice) VALUES " _
                    & "('" & txtItemCode.Text & "', '" & strNewSerialNo & "', '" & Trim(strBaseBarCode) & "', " _
                    & "'" & strSerials & "', " & txtCost.Text & ")"
            End If

            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            'Update the received table as well
            strSql = "UPDATE OrdersReceipt SET SerialNumbers = '" & strNewSerialNo & "', " _
                & "BaseBarCode = '" & Trim(strBaseBarCode) & "' WHERE TransactionId = " & intSelectedTransaction & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

        End If

        MessageBox.Show("Received Item Details Adjusted Successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Item save"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
