Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSalesToAgents

    Dim boolLoadAll As Boolean = False

    Private Sub frmSalesToAgents_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F3 Then
            FinishSale()
        End If
        'If e.KeyValue = Keys.F2 Then
        '    strPublicItemCode = Nothing
        '    strShortItemCode = Nothing
        '    intCallingForm = 1
        '    Dim f As New frmFindInventory
        '    f.ShowDialog()
        '    If Not String.IsNullOrEmpty(strShortItemCode) Then
        '        txtShortCode.Text = strShortItemCode
        '        txtShortCode.Focus()
        '        txtSalesQty.Focus()
        '    End If
        'End If

        If e.KeyValue = Keys.F10 Then
            Me.Close()
        End If
    End Sub

    Private Sub frmSalesToAgents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtLinkDocumentNumber.Text = intLinkedDocumentNumber
        dpDate.Value = dpLinkedDate
        dpDate.Enabled = False
        LoadPersonnel()
        LoadTransactions()
    End Sub

    Private Sub LoadTransactions()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim strSql As String = Nothing

        If boolLoadAll = False Then
            strSql = "SELECT [TransactionId], CONVERT(NVARCHAR, TransactionDate, 105) AS [Date], " _
                & "[ItemCode],[ItemDescription],[Quantity], CAST(UnitPrice AS DECIMAL (10,2)) AS [Unit Price], " _
                & "CAST(Discount AS DECIMAL (10,2)) AS [Discount], CAST(Payable AS DECIMAL (10,2)) AS [Payable]," _
                & "[SalesAgent] FROM StaffSales WHERE TransactionDate = '" & Format(dpDate.Value, "dd-MMM-yyyy") & "' " _
                & "ORDER BY TransactionDate, TransactionId"
        Else
            strSql = "SELECT [TransactionId], CONVERT(NVARCHAR, TransactionDate, 105) AS [Date], " _
                & "[ItemCode],[ItemDescription],[Quantity], CAST(UnitPrice AS DECIMAL (10,2)) AS [Unit Price], " _
                & "CAST(Discount AS DECIMAL (10,2)) AS [Discount], CAST(Payable AS DECIMAL (10,2)) AS [Payable]," _
                & "[SalesAgent] FROM StaffSales ORDER BY TransactionDate, TransactionId"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(5).Value = objReader(5).ToString
            If Not IsDBNull(objReader(6).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(6).Value = objReader(6).ToString
            If Not IsDBNull(objReader(7).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(7).Value = objReader(7).ToString
            If Not IsDBNull(objReader(8).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(8).Value = objReader(8).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadPersonnel()
        On Error GoTo RaiseErr
        'Load the employee details
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames " _
            & "AS [EmployeeDetails] FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        cboPersonnel.Items.Clear()
        cboPersonnel.Items.Add("")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboPersonnel.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtShortCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShortCode.KeyPress
        If Asc(e.KeyChar) = 13 Then txtSalesQty.Focus()
    End Sub

    Private Sub txtShortCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtShortCode.Validating
        If String.IsNullOrEmpty(txtShortCode.Text) Then Exit Sub
        GetInventory(txtShortCode.Text)
    End Sub

    Private Sub GetInventory(ByVal strShortCode As String)
        On Error GoTo RaiseErr
        lblItemCode.Text = Nothing
        lblItemDescription.Text = Nothing
        txtPriceOnSale.Text = "0.00"
        txtSalesDiscount.Text = "0.00"
        txtSalesQty.Text = "1"
        txtSalesTax.Text = "0.00"
        Dim strSql As String = "SELECT ItemCode, GroupName, CONVERT(NVARCHAR, " _
            & "CAST(SellingPrice AS DECIMAL (10,2))), TaxStatus FROM InventoryItems " _
            & "WHERE ShortCode = '" & strShortCode & "' AND Status = 'ACTIVE'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then lblItemCode.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then lblItemDescription.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtPriceOnSale.Text = objReader(2).ToString Else txtPriceOnSale.Text = "0.00"
            txtSalesQty.Text = "1" : txtSalesDiscount.Text = "0.00"
            Dim dblDiscounts() As Double = gwt_comm.ItemOnSpecials(lblItemCode.Text, CDbl(txtPriceOnSale.Text))
            txtSalesDiscount.Text = Format(dblDiscounts(1), "##0.00")

            Dim dblTaxes As Double = 0, dblUnitPrice As Double = CDbl(txtPriceOnSale.Text), intQuantity As Integer = 1
            Dim dblSubTotal As Double = 0
            Dim dblPayable As Double = 0

            '*********** Compute the tax payable *********************

            ' Compute the sub total
            dblSubTotal = dblUnitPrice * intQuantity
            If UCase(strTaxComputationType) = "INCLUSIVE" Then
                dblTaxes = (dblUnitPrice * intQuantity) - ((dblUnitPrice * intQuantity) * (100 / (100 + dblSalesTaxRate)))
            Else
                dblTaxes = (dblSubTotal - CDbl(txtSalesDiscount.Text)) * (dblSalesTaxRate / 100) 'dblTaxRate
            End If


            If UCase(strTaxComputationType) = "EXCLUSIVE" Then
                dblPayable = (dblSubTotal - CDbl(txtSalesDiscount.Text)) + dblTaxes
            Else
                dblPayable = (dblSubTotal - CDbl(txtSalesDiscount.Text))
            End If
            txtSalesTax.Text = Format(dblTaxes, "##0.00")
            txtCurrentPayable.Text = Format(dblPayable, "##0.00")
        Else
            MessageBox.Show("Oops!! You have entered an invalid short code. Re-enter", "Invalid Short Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtShortCode.Focus()
            txtShortCode.SelectAll()
            Exit Sub
        End If

        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Fetch"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub FinishSale()
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(lblItemDescription.Text) Then
            MessageBox.Show("Please select the item to enter", "Invalid Sales Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtShortCode.Focus()
            Exit Sub
        End If

        If CDbl(txtCurrentPayable.Text) < 0 Then
            MessageBox.Show("Transaction will not be processed as the final payment is negative", _
                "Negative Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'With dGridSales
        If Not IsNumeric(txtPriceOnSale.Text) Then txtPriceOnSale.Text = "0"
        If Not IsNumeric(txtSalesQty.Text) Then txtSalesQty.Text = "1"
        If Not IsNumeric(txtSalesDiscount.Text) Then txtSalesDiscount.Text = "0"

        If String.IsNullOrEmpty(cboSaleType.Text) Then cboSaleType.Text = "CREDIT"

        Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO StaffSales (TransactionDate, ItemCode, ItemDescription, " _
            & "Quantity, UnitPrice, Discount, Payable, UserName, SaleType, SalesAgent, LinkedDocumentNumber) VALUES " _
            & "('" & Format(dpDate.Value, "dd-MMM-yyyy") & "', '" & lblItemCode.Text & "', '" & lblItemDescription.Text & "', " & txtSalesQty.Text & ", " _
            & "" & txtPriceOnSale.Text & ", " & txtSalesDiscount.Text & ", " _
            & "" & (CDbl(txtSalesQty.Text) * CDbl(txtPriceOnSale.Text)) - CDbl(txtSalesDiscount.Text) & ", " _
            & "'" & strUserName & "', '" & cboSaleType.Text & "', '" & cboPersonnel.Text & "', " & CInt(txtLinkDocumentNumber.Text) & ")", cnn)
        objCommand.ExecuteNonQuery()

        'Update the products table
        Dim intStockBalance As Double = 0
        objCommand = New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & lblItemCode.Text & "'", cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            If IsNumeric(dbReader(0).ToString) Then intStockBalance = CDbl(dbReader(0).ToString) Else intStockBalance = 0
        Else
            intStockBalance = 0
        End If
        dbReader.Close()
        intStockBalance = intStockBalance - CDbl(txtSalesQty.Text)
        objCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = " & intStockBalance & " WHERE ItemCode = '" & lblItemCode.Text & "'", cnn)
        objCommand.ExecuteNonQuery()

        'Reset fields
        txtSalesQty.Text = "1"
        txtSalesDiscount.Text = "0.00"
        txtPriceOnSale.Text = "0.00"
        txtCurrentPayable.Text = "0.00"
        lblItemDescription.Text = ""
        txtShortCode.Text = ""
        txtShortCode.Focus()
        txtSalesTax.Text = "0.00"

        MessageBox.Show("Transaction processed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtShortCode.Focus()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Staff sales processing"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellClick
        On Error GoTo RaiseErr
        If dGrid.Rows.Count > 0 Then
            If dGrid.CurrentCell.ColumnIndex = 9 Then
                If MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm Record Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    'Reverse the item back to inventory
                    Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = " _
                        & "Quantity + " & dGrid.CurrentRow.Cells(4).Value.ToString & " WHERE ItemCode = " _
                        & "'" & dGrid.CurrentRow.Cells(2).Value.ToString & "'", cnn)
                    objCommand.ExecuteNonQuery()
                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM StaffSales WHERE TransactionId = " _
                        & "" & dGrid.CurrentRow.Cells(0).Value.ToString & "", cnn)
                    objCommand.ExecuteNonQuery()
                    dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
                    MessageBox.Show("Transaction deleted successfully", "Transaction Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Staff sales transaction delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAcceptSaleEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceptSaleEntry.Click
        FinishSale()
        LoadTransactions()
    End Sub

    Private Sub btnNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewItem.Click
        'boolEditStatus = False
        'Dim f As New frmInventorySetup
        'f.ShowDialog()
    End Sub

    Private Sub txtSalesQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalesQty.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            txtSalesDiscount.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtSalesDiscount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalesDiscount.KeyPress
        If e.KeyChar = "." Then Exit Sub
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            cboSaleType.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtSalesDiscount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSalesDiscount.Validating
        ComputePayable()
    End Sub

    Private Sub ComputePayable()
        Dim dblDiscount As Double = 0
        Dim dblUnitPrice As Double = 0
        Dim intQuantity As Integer = 0
        If IsNumeric(txtSalesDiscount.Text) Then dblDiscount = CDbl(txtSalesDiscount.Text)
        If IsNumeric(txtSalesQty.Text) Then intQuantity = CInt(txtSalesQty.Text)
        If IsNumeric(txtPriceOnSale.Text) Then dblUnitPrice = CDbl(txtPriceOnSale.Text)
        txtCurrentPayable.Text = Format(((dblUnitPrice * intQuantity) - dblDiscount), "##0.00")

        Dim dblSubTotal As Double = CDbl(txtCurrentPayable.Text)
        Dim dblTaxes As Double = 0
        Dim dblPayable As Double = 0

        If UCase(strTaxComputationType) = "INCLUSIVE" Then
            dblTaxes = dblSubTotal - (dblSubTotal * (100 / (100 + dblSalesTaxRate)))
        Else
            dblTaxes = (dblSubTotal - CDbl(txtSalesDiscount.Text)) * (dblSalesTaxRate / 100) 'dblTaxRate
        End If
        txtSalesTax.Text = Format(dblTaxes, "##0.00")
    End Sub

    Private Sub txtSalesQty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSalesQty.Validating
        ComputePayable()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub dpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpDate.ValueChanged
        LoadTransactions()
    End Sub

    Private Sub chkViewAllSales_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewAllSales.CheckedChanged
        If chkViewAllSales.Checked = True Then
            boolLoadAll = True
        Else
            boolLoadAll = False
        End If
        LoadTransactions()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'strPublicItemCode = Nothing
        'strShortItemCode = Nothing
        'intCallingForm = 1
        'Dim f As New frmFindInventory
        'f.ShowDialog()
        'If Not String.IsNullOrEmpty(strShortItemCode) Then
        '    txtShortCode.Text = strShortItemCode
        '    txtShortCode.Focus()
        '    txtSalesQty.Focus()
        'End If
    End Sub

End Class
