Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmResetAndReinputInventory

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        If Not IsNumeric(txtCostPrice.Text) Then
            MessageBox.Show("Please enter a valid amount for cost price", "Invalid Cost Price", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCostPrice.Focus()
            Exit Sub
        End If

        If CDbl(txtCostPrice.Text) = 0 Then
            MessageBox.Show("Cost price cannot be zero. Please re-enter", "Unacceptable Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCostPrice.Focus()
            Exit Sub
        End If

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim intQuantity As Integer = 0
        If MessageBox.Show("Are you sure you want to proceed with this process?", _
            "Confirm Quantity Re-initialization", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then

            Dim dblItemCostPrice As Double = CDbl(txtCostPrice.Text)

            'Reset the inventory values
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers WHERE ItemCode = '" & txtItemCode.Text & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = 0 WHERE ItemCode = '" & txtItemCode.Text & "'", cnn)
            objCommand.ExecuteNonQuery()

            For n As Integer = 0 To dgrvSerials.Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(dgrvSerials.Rows(n).Cells(1).Value), "")) Then
                    Dim strItemCode As String = txtItemCode.Text
                    Dim strSerials As String = dgrvSerials.Rows(n).Cells(1).Value.ToString()
                    Dim strNewBarCode As String = Nothing
                    Dim strNewSerialNo As String = Nothing
                    Dim strBaseBarCode As String = Nothing

                    If Not String.IsNullOrEmpty(strSerials) Then
                        strNewBarCode = Space(intBarcodeLength - strSerials.Length) & strSerials
                        strNewSerialNo = Mid(strNewBarCode, (intBarcodeLength - (intBarcodeUserLength - 1)), intBarcodeUserLength)
                        strBaseBarCode = Mid(strNewBarCode, 1, (intBarcodeLength - intBarcodeUserLength))
                    End If

                    'Update the inventory serial numbers and quantity if the user branch is the same as the receiving branch
                    If Not String.IsNullOrEmpty(strSerials) Then
                        strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber, BarCodeNo, SourceSerialNo, CostPrice) VALUES " _
                                & "('" & strItemCode & "', '" & strNewSerialNo & "', '" & Trim(strBaseBarCode) & "', " _
                                & "'" & strSerials & "', " & dblItemCostPrice & ")"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                    strSql = "UPDATE InventoryItems SET Quantity = (InventoryItems.Quantity + 1) WHERE ItemCode = '" & strItemCode & "'"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                    intQuantity = intQuantity + 1
                End If
            Next

            'Update the inventory quantities
            objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = " & intQuantity & " WHERE ItemCode = '" & txtItemCode.Text & "'", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Order has been successfully saved", "Inventory Details Reset", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Details Reset"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmResetAndReinputInventory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtItemCode.Text = strInventoryItemCode
        txtCostPrice.Text = Format(dblSelectedItemCostPrice, "##0.00")
        dgrvSerials.Rows.Add(500)
        For i As Integer = 0 To dgrvSerials.Rows.Count - 1
            With dgrvSerials
                .Rows(i).Cells(0).Value = (i + 1)
            End With
        Next
        AlternateColors()
    End Sub

    Private Sub AlternateColors()
        With dgrvSerials
            For i As Integer = 0 To .Rows.Count - 1 Step 2
                For j As Integer = 0 To .Columns.Count - 1
                    Dim foreColor As Color = Color.Black
                    Dim backColor As Color = Color.WhiteSmoke
                    .Rows(i).Cells(j).Style.BackColor = backColor
                    .Rows(i).Cells(j).Style.ForeColor = foreColor
                Next j
            Next i
        End With
    End Sub

End Class
