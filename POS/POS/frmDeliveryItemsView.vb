Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDeliveryItemsView

    Private Sub txtDocument_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDocument.KeyPress
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        'If Asc(e.KeyChar) = 13 Then

        'End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub LoadDetails(ByVal DocumentNumber As Integer)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT GatePasses.ItemCode, InventoryItems.GroupName, GatePasses.Quantity, " _
            & "CAST(InventoryItems.SellingPrice AS DECIMAL (10,2)) AS [Sell Price], " _
            & "CAST((GatePasses.Quantity * InventoryItems.SellingPrice) AS DECIMAL (10,2)) AS [Gross Amt], " _
            & "InventoryItems.TaxStatus, GatePasses.SerialNumber, GatePasses.SourceSerialNo, TransactionId " _
            & "FROM GatePasses LEFT OUTER JOIN InventoryItems ON GatePasses.ItemCode = InventoryItems.ItemCode " _
            & "WHERE GatePasses.PassNumber = " & DocumentNumber & " AND (GatePasses.PassType = 'DELIVERY' OR GatePasses.PassType = 'OTHER') AND " _
            & "GatePasses.Status <> 'PROCESSED' ORDER BY GatePasses.TransactionId"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            'Item Code, Description, Unit Price, Quantity, Payable, Serial, Full Serial, Tax Status
            dGrid.Rows.Add(False, objReader(0), objReader(1), objReader(3), objReader(2), objReader(4), objReader(6), objReader(7), objReader(5), objReader(8))
        End While
        objReader.Close()

        'Load for all items on the delivery note
        strSql = "SELECT GatePasses.ItemCode, InventoryItems.GroupName, GatePasses.Quantity, " _
            & "CAST(InventoryItems.SellingPrice AS DECIMAL (10,2)) AS [Sell Price], " _
            & "CAST((GatePasses.Quantity * InventoryItems.SellingPrice) AS DECIMAL (10,2)) AS [Gross Amt], " _
            & "InventoryItems.TaxStatus, GatePasses.SerialNumber, GatePasses.SourceSerialNo, TransactionId " _
            & "FROM GatePasses LEFT OUTER JOIN InventoryItems ON GatePasses.ItemCode = InventoryItems.ItemCode " _
            & "WHERE GatePasses.PassNumber = " & DocumentNumber & " AND GatePasses.PassType = 'DELIVERY' " _
            & "ORDER BY GatePasses.TransactionId"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        dGridAllItems.Rows.Clear()
        While objReader.Read
            dGridAllItems.Rows.Add(objReader(0), objReader(1), objReader(3), objReader(2), _
                objReader(4), objReader(6), objReader(7), objReader(5), objReader(8))
        End While
        objReader.Close()

        ComputeTotal()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On delivery note details load"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        arrSelectedItems = New ArrayList
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If dGrid.Rows(i).Cells(0).Value = True Then
                arrSelectedItems.Add(dGrid.Rows(i).Cells(1).Value & "|" & dGrid.Rows(i).Cells(2).Value & "|" _
                    & dGrid.Rows(i).Cells(3).Value & "|" & dGrid.Rows(i).Cells(4).Value & "|" _
                    & dGrid.Rows(i).Cells(5).Value & "|" & dGrid.Rows(i).Cells(6).Value & "|" _
                    & dGrid.Rows(i).Cells(7).Value & "|" & dGrid.Rows(i).Cells(8).Value & "|" & dGrid.Rows(i).Cells(9).Value)
            End If
        Next
        If arrSelectedItems.Count = 0 Then
            MessageBox.Show("No items were selected", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On delivery note items add to sales"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeTotal()
        Dim dblAmount As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                    dblAmount = dblAmount + CDbl(dGrid.Rows(i).Cells(5).Value.ToString)
                End If
            End If
        Next
        lblPayable.Text = Format(dblAmount, "#,##0.00")
    End Sub

    Private Sub dGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dGrid.MouseUp
        On Error GoTo RaiseErr
        If dGrid.Rows.Count = 0 Then Exit Sub
        If dGrid.CurrentCell.ColumnIndex = 0 Then
            Dim cell As DataGridViewCheckBoxCell = Me.dGrid.CurrentCell
            'Get the value of the current cell
            Dim checked As Boolean = cell.GetEditedFormattedValue(cell.RowIndex, DataGridViewDataErrorContexts.Parsing)
            'Change the other cell to the opposite value
            Dim dblValue As Double = 0

            Dim dblPayable As Double = 0

            Dim n As Integer = dGrid.CurrentRow.Index
            If checked = True Then
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(5).Value), "")) Then
                    If IsNumeric(dGrid.Rows(n).Cells(5).Value.ToString) Then
                        dblPayable = CDbl(dGrid.Rows(n).Cells(5).Value.ToString)
                    End If
                End If
                dblValue = dblValue + dblPayable
                lblSelected.Text = Format((CDbl(lblSelected.Text) + dblValue), "##0.00")
            Else
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(5).Value), "")) Then
                    dblPayable = CDbl(dGrid.Rows(n).Cells(5).Value.ToString)
                End If
                If CDbl(lblSelected.Text) > 0 Then
                    lblSelected.Text = Format((CDbl(lblSelected.Text) - (dblPayable + 0)), "##0.00")
                End If
            End If
            Me.dGrid.EndEdit()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & "On delivery note processing"
        ShowErrorMessage()
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        If IsNumeric(txtDocument.Text) Then
            LoadDetails(CInt(txtDocument.Text))
        Else
            MessageBox.Show("Please enter the original pass number", "Missing Pass Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocument.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

End Class
