Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventoryPricesUpdate

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click

        boolAbort = False

        If Not IsNumeric(txtPublic.Text) Then
            MessageBox.Show("Please enter price for the public", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPublic.Select()
            Exit Sub
        End If
        If Not IsNumeric(txtRetail.Text) Then
            MessageBox.Show("Please enterthe retail price", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRetail.Select()
            Exit Sub
        End If
        If Not IsNumeric(txtWholesale.Text) Then
            MessageBox.Show("Please enter wholesale price", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtWholesale.Select()
            Exit Sub
        End If
        If Not IsNumeric(txtSpecial.Text) Then
            MessageBox.Show("Please enter special price", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSpecial.Select()
            Exit Sub
        End If

        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = "UPDATE InventoryItems SET SellingPrice = " & CDbl(txtPublic.Text) & ", " _
            & "[RetailPrice] = " & CDbl(txtRetail.Text) & ", " _
            & "[WholesalePrice] = " & CDbl(txtWholesale.Text) & ", " _
            & "[SpecialPrice] = " & CDbl(txtSpecial.Text) & " " _
            & "WHERE ItemCode = '" & lblItemCode.Text & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Cursor = Cursors.Default

        MessageBox.Show("Inventory Prices Updated Successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Inventory Price Update"
        ShowErrorMessage()
    End Sub

    Private Sub frmInventoryPricesUpdate_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        lblItemCode.Text = UCase(strInventoryItemCode)

        Dim strSql As String = "SELECT [SellingPrice], [RetailPrice], [WholesalePrice], " _
            & "[SpecialPrice] FROM InventoryItems WHERE ItemCode = '" & strInventoryItemCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then txtPublic.Text = Format(CDbl(objReader(0).ToString), "##0.00")
            If IsNumeric(objReader(1).ToString) Then txtRetail.Text = Format(CDbl(objReader(1).ToString), "##0.00")
            If IsNumeric(objReader(2).ToString) Then txtWholesale.Text = Format(CDbl(objReader(2).ToString), "##0.00")
            If IsNumeric(objReader(3).ToString) Then txtSpecial.Text = Format(CDbl(objReader(3).ToString), "##0.00")
        End If
        objReader.Close()

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Inventory Price Update Details Load"
        ShowErrorMessage()
    End Sub

End Class