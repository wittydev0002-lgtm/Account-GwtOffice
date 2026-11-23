Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmInventoryCostsMassUpdate

    Private Sub frmInventoryCostsMassUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "Select InventoryItems.ItemCode, InventoryItems.GroupName, CAST(InventoryItems.CostPrice AS DECIMAL (30,2)), " _
            & "CAST(InventoryItems.SellingPrice AS DECIMAL (30,2)) FROM InventoryItems ORDER BY InventoryItems.ItemCode"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Items Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    'Private Sub cboSearchType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchType.SelectedIndexChanged
    '    If cboSearchType.Text = "Item Code" Then LoadData("Item Code") Else LoadData("Description")
    'End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        Dim intSearchColumn As Integer = 0
        'Item Code
        'Description
        Select Case cboSearchType.Text
            Case Is = "Item Code"
                intSearchColumn = 0
            Case Is = "Description"
                intSearchColumn = 1
            Case Else
                intSearchColumn = 1
        End Select
        If (Char.IsLetter(e.KeyChar)) Then
            Dim strSearchString As String = txtSearchString.Text & e.KeyChar
            For i As Integer = 0 To dGrid.Rows.Count - 1
                If dGrid.Rows(i).Cells(intSearchColumn).Value.ToString().StartsWith(strSearchString, True, System.Globalization.CultureInfo.InvariantCulture) Then
                    dGrid.CurrentCell = dGrid(0, i)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        'Update also the selling prices based on user preference
        If MessageBox.Show("Do you want to also update the sales cost prices?", "Confirm Sales Costs Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            boolAbort = False
            gwt_comm.DateRangeSpecification()
            If boolAbort = True Then
                MessageBox.Show("Process has been aborted. Exiting procedure", "Process Abort", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Cursor = Cursors.Default
                Exit Sub
            Else
                boolUpdateSalesAsWell = True
            End If
        End If

        pb1.Value = 0 : pb1.Maximum = dGrid.Rows.Count + 1
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblCostPrice As Double = 0
            Dim dblSalePrice As Double = 0
            Dim strItemCode As String = Nothing
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    dblCostPrice = CDbl(dGrid.Rows(i).Cells(2).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    dblSalePrice = CDbl(dGrid.Rows(i).Cells(3).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "") Then
                strItemCode = dGrid.Rows(i).Cells(0).Value.ToString
            End If

            Dim objCommand As Data.OleDb.OleDbCommand
            If boolUpdateSalesAsWell = True Then
                objCommand = New Data.OleDb.OleDbCommand("UPDATE Sales SET CostPrice = " _
                 & "" & dblCostPrice & " WHERE ItemCode = '" & strItemCode & "' AND " _
                 & "TransDate Between '" & StartDate & "' AND '" & EndDate & "'", cnn)
                objCommand.ExecuteNonQuery()
            End If
            'Update the cost and sales prices in the inventory table and the serial numbers table
            objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET CostPrice = " _
             & "" & dblCostPrice & ", SellingPrice = " & dblSalePrice & " WHERE " _
             & "ItemCode = '" & strItemCode & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("UPDATE SerialNumbers SET CostPrice = " _
             & "" & dblCostPrice & " WHERE ItemCode = '" & strItemCode & "'", cnn)
            objCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next
        Cursor = Cursors.Default
        MessageBox.Show("Costs saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Price Update"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
