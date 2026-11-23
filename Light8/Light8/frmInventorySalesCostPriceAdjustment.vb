Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventorySalesCostPriceAdjustment

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        strPublicItemCode = Nothing
        boolAbort = False
        gwt_comm.InventorySearch()
        If boolAbort = True Then Exit Sub
        If Not String.IsNullOrEmpty(strPublicItemCode) Then
            txtItemCode.Text = strPublicItemCode
            strPublicItemCode = Nothing
        End If
    End Sub

    Private Sub txtUnitPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnitPrice.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            dpDateFrom.Focus()
            Exit Sub
        End If
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT ItemCode +';'+InventoryType +';'+ GroupName AS " _
            & "[Items] FROM InventoryItems ORDER BY ItemCode"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With txtItemCode
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 3
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "200;100;200"
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

        txtItemCode.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            txtItemCode.SelectedIndex = -1
            txtItemCode.Items.Clear()
            txtItemCode.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            txtItemCode.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmInventorySalesCostPriceAdjustment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub frmInventorySalesCostPriceAdjustment_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Width = 566 : Me.Height = 237 '566; 237
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtItemCode.Text) Then
            MessageBox.Show("Please enter the item code for that items that need change", _
                "Missing Item Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtItemCode.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtUnitPrice.Text) Then
            MessageBox.Show("Please enter a valid value for the cost price", _
                "Invalid Cost Price", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUnitPrice.Focus()
            Exit Sub
        End If
        If dpDateFrom.Value > dtDateTo.Value Then
            MessageBox.Show("The start date must be before the end date", _
                "Inconsistent Date Range", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dpDateFrom.Focus()
            Exit Sub
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE Sales SET CostPrice = " & CDbl(txtUnitPrice.Text) & " " _
            & "WHERE ItemCode = '" & txtItemCode.Text & "' AND TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpDateFrom.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dtDateTo.Value) & "'", cnn)
        objCommand.ExecuteNonQuery()
        If MessageBox.Show("Process completed successfully. Do you want to change more?", "Process Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            txtUnitPrice.Text = "0.00"
            txtItemCode.Focus()
            Exit Sub
        Else
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Sales Cost Price Adjustment"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
