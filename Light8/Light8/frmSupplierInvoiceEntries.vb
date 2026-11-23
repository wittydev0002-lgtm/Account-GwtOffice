Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSupplierInvoiceEntries

    Dim strMainDetails As String
    Dim arrPrintDetails As ArrayList

    Dim prFont As New Font("Arial", 8, FontStyle.Bold)
    Dim tlFont As New Font("Arial", 8, FontStyle.Regular)
    Dim HeaderFont As New Font("Arial", 10, FontStyle.Bold)
    Dim ItalicFont As New Font("Times New Roman", 8, FontStyle.Italic)

    Dim intPage As Integer = 1
    Dim strSupplierName As String
    Dim strSupplierAddress1 As String
    Dim strSupplierAddress2 As String
    Dim strSupplierAddress3 As String
    Dim strSupplierAddress4 As String
    Dim strSupplierTelephone As String
    Dim strSupplierEmailAddress As String
    Dim strSupplierVatNumber As String
    Dim boolPrintFromPreview As Boolean
    Dim boolExitingWhile As Boolean
    Dim strValue As String
    Dim itm As Integer

    Dim boolFormLoading As Boolean

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        'If IsNumeric(dGrid.CurrentCell.Value) Then
        '    dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")
        'End If
        'If dGrid.CurrentCell.ColumnIndex = 2 Or dGrid.CurrentCell.ColumnIndex = 3 _
        '    Or dGrid.CurrentCell.ColumnIndex = 4 Or dGrid.CurrentCell.ColumnIndex = 5 Then
        '    ComputeLineTotal(dGrid.CurrentCell.RowIndex)
        'End If
        'ComputeTotals()
        UpdateCells()
    End Sub

    Private Sub UpdateCells()

        If boolFormLoading = True Then Exit Sub

        If IsNumeric(dGrid.CurrentCell.Value) Then
            dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")
        End If
        If dGrid.CurrentCell.ColumnIndex = 3 Or dGrid.CurrentCell.ColumnIndex = 4 _
            Or dGrid.CurrentCell.ColumnIndex = 6 Or dGrid.CurrentCell.ColumnIndex = 7 Then

            Dim dblColumn3 As Double = 0
            Dim dblColumn4 As Double = 0
            Dim dblColumn6 As Double = 0
            Dim dblColumn7 As Double = 0

            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(3).Value), "") Then
                If IsNumeric(dGrid.CurrentRow.Cells(3).Value.ToString) Then
                    dblColumn3 = CDbl(dGrid.CurrentRow.Cells(3).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(4).Value), "") Then
                If IsNumeric(dGrid.CurrentRow.Cells(4).Value.ToString) Then
                    dblColumn4 = CDbl(dGrid.CurrentRow.Cells(4).Value.ToString)
                End If
            End If
            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(6).Value), "") Then
                If IsNumeric(dGrid.CurrentRow.Cells(6).Value.ToString) Then
                    dblColumn6 = CDbl(dGrid.CurrentRow.Cells(6).Value.ToString)
                End If
            End If

            If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(7).Value), "") Then
                If IsNumeric(dGrid.CurrentRow.Cells(7).Value.ToString) Then
                    dblColumn7 = CDbl(dGrid.CurrentRow.Cells(7).Value.ToString)
                End If
            End If

            If dGrid.CurrentCell.ColumnIndex = 7 Then
                If dblColumn7 = 0 Then
                    ComputeValues(dblColumn3, dblColumn4, dGrid.CurrentRow.Index, dblColumn6, 0)
                End If
            Else
                ComputeValues(dblColumn3, dblColumn4, dGrid.CurrentRow.Index, dblColumn6, CommonLibrary.Commons.dblSalesTaxRate)
            End If

            dGrid.CurrentRow.Cells(4).Value = Format(dblColumn4, "##0.00")
        End If
        ComputeTotals()
    End Sub

    Private Sub ComputeValues(ByVal dblUnitPrice As Double, ByVal intQuantity As Double, _
        ByVal intRowIndex As Double, _
        Optional ByVal dblDiscount As Double = 0, Optional ByVal dblTaxRate As Double = 0, Optional ByVal Taxable As Boolean = True)
        Dim dblTaxes As Double = 0
        Dim dblSubTotal As Double = 0
        Dim dblPayable As Double = 0

        'Compute the sub total

        If Taxable = True Then
            If UCase(CommonLibrary.Commons.strTaxComputationType) = "INCLUSIVE" Then
                Dim dblTempTax As Double = 0
                dblTempTax = ((dblUnitPrice * intQuantity) - dblDiscount) - (((dblUnitPrice * intQuantity) - dblDiscount) * (100 / (100 + dblTaxRate)))
                dblSubTotal = (dblUnitPrice * intQuantity) - dblTempTax
            Else
                dblSubTotal = dblUnitPrice * intQuantity
            End If
        End If

        dGrid.Rows(intRowIndex).Cells(5).Value = Format(dblSubTotal, "##0.00")

        'Compute the tax payable
        If Taxable = True Then
            If UCase(CommonLibrary.Commons.strTaxComputationType) = "INCLUSIVE" Then
                dblTaxes = ((dblUnitPrice * intQuantity) - dblDiscount) - (((dblUnitPrice * intQuantity) - dblDiscount) * (100 / (100 + dblTaxRate)))
            Else
                dblTaxes = (dblSubTotal - dblDiscount) * (dblTaxRate / 100) 'dblTaxRate
            End If
        Else
            dblTaxes = 0
        End If

        'If UCase(CommonLibrary.Commons.strTaxComputationType) = "EXCLUSIVE" Then
        dblPayable = (dblSubTotal - dblDiscount) + dblTaxes
        'Else
        '    dblPayable = (dblSubTotal - dblDiscount)
        'End If

        dGrid.Rows(intRowIndex).Cells(7).Value = Format(dblTaxes, "##0.00")
        dGrid.Rows(intRowIndex).Cells(8).Value = Format(dblPayable, "##0.00")

        RecalculateAmount()
        ComputeTotals()

    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGrid.EditingControlShowing
        Try
            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                'In order to prevent optical problems, we had to call the removeHandler twice
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dGrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dGrid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim numCols As Integer = dGrid.ColumnCount
            Dim numRows As Integer = dGrid.RowCount
            Dim currCell As DataGridViewCell = dGrid.CurrentCell
            If currCell.ColumnIndex = numCols - 1 Then
                If currCell.RowIndex < numRows - 1 Then
                    dGrid.CurrentCell = dGrid.Item(0, currCell.RowIndex + 1)
                End If
            Else
                dGrid.CurrentCell = dGrid.Item(currCell.ColumnIndex + 1, currCell.RowIndex)
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub frmSupplierInvoiceEntries_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        boolFormLoading = True
        dGrid.Rows.Add(250)
        AlternateColors()
        LoadPersonnel()
        LoadData()
        LoadCreditors()
        If boolEditStatus = False Then
            btnPrint.Enabled = False
            txtDocumentNumber.Text = CStr(gwt_comm.GetNextDocumentNumber("SupplierInvoices"))
            dGrid.CurrentCell = dGrid.Rows(0).Cells(1)
            btnSaveNew.Enabled = True
        Else
            btnPrint.Enabled = True
            btnSaveNew.Enabled = False
            LoadInvoiceDetails(intSelectedTransaction)
            ComputeTotals()
        End If
        boolFormLoading = False
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim backColor As Color = Color.White
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
            Next
        Next
        For i As Integer = 0 To dGrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
                dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub frmSupplierInvoiceEntries_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Width = 867 : Me.Height = 613
    End Sub

    Private Sub LoadPersonnel()
        On Error GoTo RaiseErr
        'Load the employee details
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames " _
            & "AS [EmployeeDetails] FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        cboBuyer.Items.Clear()
        cboBuyer.Items.Add("--- NONE ---")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboBuyer.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Select Case UCase(strMainCompanyServiceOffering)
            Case Is = "PRODUCTS"
                strSql = "SELECT ItemCode +';'+GroupName AS " _
                    & "[Items] FROM InventoryItems WHERE Offering = 'PRODUCT' AND Status = 'ACTIVE' ORDER BY ItemCode"
            Case Is = "SERVICES"
                strSql = "SELECT ItemCode +';'+GroupName AS " _
                    & "[Items] FROM InventoryItems WHERE Offering = 'SERVICE' AND Status = 'ACTIVE' ORDER BY ItemCode"
            Case Is = "HIRING ITEMS"
                strSql = "SELECT ItemCode +';'+GroupName AS " _
                    & "[Items] FROM InventoryItems WHERE Offering = 'HIRE ITEM' AND Status = 'ACTIVE' ORDER BY ItemCode"
            Case Else
                strSql = "SELECT ItemCode +';'+GroupName AS " _
                    & "[Items] FROM InventoryItems WHERE Status = 'ACTIVE' ORDER BY ItemCode"
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
            .ColumnWidth = "160;180"
        End With
        'Get a count of the items
        Dim intItemsCount As Double = 0

        Select Case UCase(strMainCompanyServiceOffering)
            Case Is = "PRODUCTS"
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'PRODUCT' AND Status = 'ACTIVE'", cnn)
            Case Is = "SERVICES"
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'SERVICE' AND Status = 'ACTIVE'", cnn)
            Case Is = "HIRING ITEMS"
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Offering = 'HIRE ITEM' AND Status = 'ACTIVE'", cnn)
            Case Else
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems WHERE Status = 'ACTIVE'", cnn)
        End Select

        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()

        Dim DropDownItems(intItemsCount) As MTGCComboBoxItem
        DropDownItems(0) = New MTGCComboBoxItem(UCase("--- NONE ---"), UCase(""))

        cboItems.Items.Clear()
        Dim p As Double = 1
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
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    '    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter
    '        On Error GoTo RaiseErr
    '        'cboSerials.Visible = False
    '        If cboItems.Visible = True Then cboItems.Visible = False
    '        If e.ColumnIndex = 0 Then
    '            LoadData()
    '            cboItems.Size = dGrid.CurrentCell.Size
    '            cboItems.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top
    '            cboItems.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left
    '            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
    '                cboItems.Text = Convert.ToString(dGrid.CurrentCell.Value)
    '            Else
    '                cboItems.Text = ""
    '            End If
    '            cboItems.Visible = True '152
    '            cboItems.Focus()
    '            cboItems.SelectAll()
    '        End If
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " error number " & Err.Number & " on Item code search"
    '        gwt_comm.ShowErrorMessage()
    '    End Sub

    Private Sub cboItems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboItems.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'dGrid.Focus()
            dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(1)
            dGrid.Focus()
        End If
    End Sub

    Private Sub cboItems_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.LostFocus
        cboItems.Visible = False
    End Sub

    Private Sub cboItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.SelectedIndexChanged
        CommitValueChanged()
    End Sub

    'Private Sub CommitValueChanged()
    '    If cboItems.Focused = False Then Exit Sub
    '    If Not cboItems.SelectedItem Is Nothing Then
    '        dGrid.CurrentRow.Cells(0).Value = cboItems.SelectedItem.Col1
    '        dGrid.CurrentRow.Cells(1).Value = cboItems.SelectedItem.Col2
    '    Else
    '        dGrid.CurrentRow.Cells(0).Value = Nothing
    '        dGrid.CurrentRow.Cells(1).Value = Nothing
    '    End If
    'End Sub

    Private Sub LoadCreditors()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT AccountName +';'+AccountNumber AS [Supplier] FROM Suppliers ORDER BY AccountName"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Set up the drop down combo box
        Dim intWidth As Integer = cboSupplierName.Width - 50
        With cboSupplierName
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "160;" & intWidth - 160
        End With

        'Get a count of the items
        Dim intItemsCount As Double = 0

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(AccountNumber) FROM Suppliers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()

        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboSupplierName.Items.Clear()
        Dim p As Double = 0

        'Continue to read until you reach the end of the file.
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            End If
            p = p + 1
        End While
        objReader.Close()

        If intItemsCount > 0 Then
            cboSupplierName.SelectedIndex = -1
            cboSupplierName.Items.Clear()
            cboSupplierName.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboSupplierName.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " On creditors details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        Dim boolPriorStatus As Boolean = boolEditStatus
        boolEditStatus = False
        Dim f As New frmSupplierDetails
        f.ShowDialog()
        boolEditStatus = boolPriorStatus
    End Sub

    Private Sub cboSupplierName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSupplierName.SelectedIndexChanged
        txtAccountNumber.Clear()
        If Not cboSupplierName.SelectedItem Is Nothing Then
            txtAccountNumber.Text = cboSupplierName.SelectedItem.Col2
            LoadSelectedSupplierDetails(txtAccountNumber.Text)
        Else
            txtAccountNumber.Text = Nothing
        End If
    End Sub

    Private Sub LoadSelectedSupplierDetails(ByVal AccountNumber As String)
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Address1, Address2, Address3, Address4, " _
            & "PhoneNumber, EmailAddress, AccountName FROM Suppliers WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim strAddress As String = Nothing
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then strAddress = strAddress & objReader(0).ToString & vbCrLf
            If Not IsDBNull(objReader(1).ToString) Then strAddress = strAddress & objReader(1).ToString & vbCrLf
            If Not IsDBNull(objReader(2).ToString) Then strAddress = strAddress & objReader(2).ToString & vbCrLf
            If Not IsDBNull(objReader(3).ToString) Then strAddress = strAddress & objReader(3).ToString & vbCrLf
            If Not IsDBNull(objReader(4).ToString) Then strAddress = strAddress & objReader(4).ToString & vbCrLf
            If Not IsDBNull(objReader(5).ToString) Then strAddress = strAddress & objReader(5).ToString

            If String.IsNullOrEmpty(cboSupplierName.Text) Then
                If Not IsDBNull(objReader("AccountName").ToString) Then cboSupplierName.Text = objReader("AccountName").ToString
            End If
        End While
        txtAddress.Text = strAddress
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " On selected creditors details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeLineTotal(ByVal intRowIndex As Integer)

        Dim dblQuantity As Double = 0
        Dim dblUnitPrice As Double = 0
        Dim dblDiscount As Double = 0
        Dim dblTax As Double = 0

        If Not (Object.Equals(Convert.ToString(dGrid.Rows(intRowIndex).Cells(2).Value), "")) Then
            If IsNumeric(dGrid.Rows(intRowIndex).Cells(2).Value.ToString) Then
                dblQuantity = CDbl(dGrid.Rows(intRowIndex).Cells(2).Value.ToString)
            End If
        End If
        If Not (Object.Equals(Convert.ToString(dGrid.Rows(intRowIndex).Cells(3).Value), "")) Then
            If IsNumeric(dGrid.Rows(intRowIndex).Cells(3).Value.ToString) Then
                dblUnitPrice = CDbl(dGrid.Rows(intRowIndex).Cells(3).Value.ToString)
            End If
        End If
        If Not (Object.Equals(Convert.ToString(dGrid.Rows(intRowIndex).Cells(4).Value), "")) Then
            If IsNumeric(dGrid.Rows(intRowIndex).Cells(4).Value.ToString) Then
                dblDiscount = CDbl(dGrid.Rows(intRowIndex).Cells(4).Value.ToString)
            End If
        End If
        If Not (Object.Equals(Convert.ToString(dGrid.Rows(intRowIndex).Cells(5).Value), "")) Then
            If IsNumeric(dGrid.Rows(intRowIndex).Cells(5).Value.ToString) Then
                dblTax = CDbl(dGrid.Rows(intRowIndex).Cells(5).Value.ToString)
            End If
        End If

        Dim dblLineTotal As Double = ((dblQuantity * dblUnitPrice) - dblDiscount) + dblTax

        dGrid.Rows(intRowIndex).Cells(6).Value = Format(dblLineTotal, "##0.00")

    End Sub

    Private Sub ComputeTotals()
        If dGrid.Rows.Count = 0 Then Exit Sub
        Dim dblSubTotal As Double = 0
        Dim dblTaxesTotal As Double = 0
        Dim dblDiscountTotals As Double = 0
        Dim dblTotalPayable As Double = 0
        For n As Double = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(5).Value), "")) Then
                dblSubTotal = dblSubTotal + CDbl(dGrid.Rows(n).Cells(5).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(7).Value), "")) Then
                dblTaxesTotal = dblTaxesTotal + CDbl(dGrid.Rows(n).Cells(7).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(6).Value), "")) Then
                dblDiscountTotals = dblDiscountTotals + CDbl(dGrid.Rows(n).Cells(6).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(8).Value), "")) Then
                dblTotalPayable = dblTotalPayable + CDbl(dGrid.Rows(n).Cells(8).Value.ToString)
            End If
        Next
        lblSubTotal.Text = Format(dblSubTotal, "#,##0.00")
        'If UCase(CommonLibrary.Commons.strTaxComputationType) = UCase("INCLUSIVE") Then
        '    lblTaxable.Text = Format(((dblSubTotal - dblDiscountTotals) - dblTaxesTotal), "#,##0.00")
        'Else
        lblTaxable.Text = Format(((dblSubTotal - dblDiscountTotals) + 0), "#,##0.00")
        Dim dblTaxable As Double = dblSubTotal - dblDiscountTotals
        'End If
        lblTaxes.Text = Format(dblTaxesTotal, "#,##0.00")
        lblDiscounts.Text = Format(dblDiscountTotals, "#,##0.00")
        lblPayable.Text = Format((dblTaxable + dblTaxesTotal), "#,##0.00") 'Format(dblTotalPayable, "#,##0.00")
    End Sub

    Private Sub RecalculateAmount()
        Dim dblMovingTotal As Double = 0
        Dim dblSubs As Double = 0
        Dim dblTxs As Double = 0
        Dim dblDis As Double = 0
        For i As Double = 0 To dGrid.Rows.Count - 1
            Dim strValue As String = "0"
            Dim strValTx As String = "0"
            Dim strValDis As String = "0"
            Dim strValSubs As String = "0"
            Dim dblQuantity As Double = 0
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    dblQuantity = CDbl(dGrid.Rows(i).Cells(3).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(8).Value), "")) Then
                strValue = Convert.ToString(dGrid.Rows(i).Cells(8).Value)
                If IsNumeric(strValue) Then
                    dblMovingTotal = dblMovingTotal + CDbl(strValue)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "")) Then
                strValTx = Convert.ToString(dGrid.Rows(i).Cells(7).Value)
                If IsNumeric(strValTx) Then
                    dblTxs = dblTxs + CDbl(strValTx)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(6).Value), "")) Then
                strValDis = Convert.ToString(dGrid.Rows(i).Cells(6).Value)
                If IsNumeric(strValDis) Then
                    dblDis = dblDis + CDbl(strValDis)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                strValSubs = Convert.ToString(dGrid.Rows(i).Cells(5).Value)
                If IsNumeric(strValSubs) Then
                    dblSubs = dblSubs + CDbl(strValSubs)
                End If
            End If

        Next
        lblPayable.Text = Format(dblMovingTotal, "#,##0.00")
        lblSubTotal.Text = Format(dblSubs, "#,##0.00")
        lblDiscounts.Text = Format(dblDis, "#,##0.00")
        lblTaxes.Text = Format(dblTxs, "#,##0.00")
    End Sub

    'Private Sub ComputeTotals()

    '    Dim dblGrossAmount As Double = 0
    '    Dim dblDiscounts As Double = 0
    '    Dim dblTaxes As Double = 0
    '    Dim dblAmountPayable As Double = 0
    '    Dim dblQuantity As Double = 0

    '    lblDiscounts.Text = "0.00"
    '    lblPayable.Text = "0.00"
    '    lblSubTotal.Text = "0.00"
    '    lblTaxable.Text = "0.00"
    '    lblTaxes.Text = "0.00"

    '    With dGrid
    '        For i As Integer = 0 To .Rows.Count - 1
    '            If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then
    '                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "")) Then
    '                    If IsNumeric(Convert.ToString(.Rows(i).Cells(2).Value)) Then
    '                        dblQuantity = CDbl(Convert.ToString(.Rows(i).Cells(2).Value))
    '                    End If
    '                End If
    '                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "")) Then
    '                    If IsNumeric(Convert.ToString(.Rows(i).Cells(3).Value)) Then
    '                        dblGrossAmount = dblGrossAmount + (CDbl(Convert.ToString(.Rows(i).Cells(3).Value)) * dblQuantity)
    '                    End If
    '                End If
    '                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "")) Then
    '                    If IsNumeric(Convert.ToString(.Rows(i).Cells(4).Value)) Then
    '                        dblDiscounts = dblDiscounts + CDbl(Convert.ToString(.Rows(i).Cells(4).Value))
    '                    End If
    '                End If
    '                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "")) Then
    '                    If IsNumeric(Convert.ToString(.Rows(i).Cells(5).Value)) Then
    '                        dblTaxes = dblTaxes + CDbl(Convert.ToString(.Rows(i).Cells(5).Value))
    '                    End If
    '                End If
    '                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(6).Value), "")) Then
    '                    If IsNumeric(Convert.ToString(.Rows(i).Cells(6).Value)) Then
    '                        dblAmountPayable = dblAmountPayable + CDbl(Convert.ToString(.Rows(i).Cells(6).Value))
    '                    End If
    '                End If
    '            End If
    '        Next

    '        lblSubTotal.Text = Format(dblGrossAmount, "##0.00")
    '        lblDiscounts.Text = Format(dblDiscounts, "##0.00")
    '        lblTaxable.Text = Format((dblGrossAmount - dblDiscounts), "##0.00")
    '        lblTaxes.Text = Format(dblTaxes, "##0.00")
    '        lblPayable.Text = Format(dblAmountPayable, "##0.00")

    '    End With
    'End Sub

    Private Function IsValidUserData() As Boolean
        Dim boolReturn As Boolean = True
        If String.IsNullOrEmpty(txtOrderNumber.Text) Then txtOrderNumber.Text = "0"
        If String.IsNullOrEmpty(cboSupplierName.Text) Then
            MessageBox.Show("Please enter the creditor name",
                "Missing Creditor Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSupplierName.Focus()
            boolReturn = False
        Else
            If String.IsNullOrEmpty(txtAccountNumber.Text) Then
                MessageBox.Show("Please enter the creditor name", "Missing Creditor Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboSupplierName.Focus()
                boolReturn = False
            Else
                If String.IsNullOrEmpty(txtInvoiceNumber.Text) Then
                    MessageBox.Show("Please enter the invoice number a per the supplier invoice", "Missing Supplier Invoice Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtInvoiceNumber.Focus()
                    boolReturn = False
                Else
                    If String.IsNullOrEmpty(cboBuyer.Text) Then
                        MessageBox.Show("Please select the buyer details from the list provided", "Missing Buyer Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        cboBuyer.Focus()
                        boolReturn = False
                    Else
                        If Not IsNumeric(txtOrderNumber.Text) Then
                            MessageBox.Show("Order numbers are numeric. Please enter a numeric value or 0 as default", "Invalid Order Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            txtOrderNumber.Focus()
                            boolReturn = False
                        End If
                    End If
                End If
            End If
        End If
        Return boolReturn
    End Function

    Private Sub btnSaveClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveClose.Click
        SaveData()
        Me.Close()
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseErr
        If IsValidUserData() = False Then Exit Sub

        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = True Then
            Dim intKeyToDelete As Integer = 0
            'Get the special key and then delete usinu the special key
            objCommand = New Data.OleDb.OleDbCommand("SELECT SpecialKey FROM SupplierInvoicesMain WHERE DocumentNumber = " & CLng(txtDocumentNumber.Text) & "", cnn)
            Dim objReadKey As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadKey.HasRows Then
                objReadKey.Read()
                If IsNumeric(objReadKey(0).ToString) Then intKeyToDelete = CInt(objReadKey(0).ToString)
            End If
            objReadKey.Close()

            If intKeyToDelete <> 0 Then
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SupplierInvoicesDetails WHERE DocumentNumber = " & intKeyToDelete & "", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SupplierTransactions  WHERE DocumentNumber = " & intKeyToDelete & "", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SupplierInvoicesMain WHERE DocumentNumber = " & intKeyToDelete & "", cnn)
                objCommand.ExecuteNonQuery()
                'objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE DocumentNumber = " & intKeyToDelete & "", cnn)
                'objCommand.ExecuteNonQuery()
            Else
                gwt_comm.DeleteSpecialKeyTransaction(intKeyToDelete)
                'objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SupplierInvoicesDetails WHERE SpecialKey = " & intKeyToDelete & "", cnn)
                'objCommand.ExecuteNonQuery()
                'objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SupplierTransactions  WHERE SpecialKey = " & intKeyToDelete & "", cnn)
                'objCommand.ExecuteNonQuery()
                'objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SupplierInvoicesMain WHERE SpecialKey = " & intKeyToDelete & "", cnn)
                'objCommand.ExecuteNonQuery()
                'objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE SpecialKey = " & intKeyToDelete & "", cnn)
                'objCommand.ExecuteNonQuery()
            End If

        End If

        'Get the document number and save to the main
        txtDocumentNumber.Text = CStr(gwt_comm.GetNextDocumentNumber("SupplierInvoices"))
        Dim intSpecialKey As Integer = gwt_comm.SpecialKey

        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SupplierInvoicesMain ([AccountNumber],[SupplierReference]," _
            & "[TransDate],[OrderNumber],[Buyer],[Value],[Discount],[Taxes],[DocumentNumber],[Status],[UserName],[Notes], [SpecialKey]) VALUES " _
            & "('" & txtAccountNumber.Text & "', '" & txtInvoiceNumber.Text & "', '" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', " _
            & "" & txtOrderNumber.Text & ", '" & cboBuyer.Text & "', " & CDbl(lblPayable.Text) & ", " & CDbl(lblDiscounts.Text) & ", " _
            & "" & CDbl(lblTaxes.Text) & ", " & CLng(txtDocumentNumber.Text) & ", 'UNPAID', '" & strUserName & "', '" & txtNotes.Text & "', " & intSpecialKey & ")", cnn)
        objCommand.ExecuteNonQuery()

        'Insert into the supplier transactions as well
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SupplierTransactions ([AccountNumber],[TransactionDate],[Amount]," _
            & "[TransactionType],[Description],[ReferenceNumber],[UserName],[BranchName], [DocumentNumber], [SpecialKey]) VALUES " _
            & "('" & txtAccountNumber.Text & "', '" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', " _
            & "" & CDbl(lblPayable.Text) & ", 'INVOICE', '" & cboSupplierName.Text & "', '" & txtInvoiceNumber.Text & "', " _
            & "'" & strUserName & "', '" & strUserBranch & "', " & txtDocumentNumber.Text & ", " & intSpecialKey & ")", cnn)
        objCommand.ExecuteNonQuery()

        With dGrid
            For i As Integer = 0 To dGrid.Rows.Count - 1

                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then

                    Dim strItemCode As String = Convert.ToString(.Rows(i).Cells(0).Value)
                    Dim strDescription As String = Nothing
                    Dim dblQuantity As Double = 0
                    Dim dblCostPrice As Double = 0
                    Dim dblDiscounts As Double = 0
                    Dim dblTaxes As Double = 0

                    If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "")) Then
                        strDescription = Convert.ToString(.Rows(i).Cells(1).Value)
                    End If
                    If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "")) Then
                        If IsNumeric(Convert.ToString(.Rows(i).Cells(4).Value)) Then
                            dblQuantity = CDbl(Convert.ToString(.Rows(i).Cells(4).Value))
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "")) Then
                        If IsNumeric(Convert.ToString(.Rows(i).Cells(3).Value)) Then
                            dblCostPrice = CDbl(Convert.ToString(.Rows(i).Cells(3).Value))
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(6).Value), "")) Then
                        If IsNumeric(Convert.ToString(.Rows(i).Cells(6).Value)) Then
                            dblDiscounts = dblDiscounts + CDbl(Convert.ToString(.Rows(i).Cells(6).Value))
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(7).Value), "")) Then
                        If IsNumeric(Convert.ToString(.Rows(i).Cells(7).Value)) Then
                            dblTaxes = CDbl(Convert.ToString(.Rows(i).Cells(7).Value))
                        End If
                    End If

                    Dim strSql As String = "INSERT INTO SupplierInvoicesDetails ([DocumentNumber],[SupplierNumber],[ItemCode]," _
                        & "[Description],[Discount],[Taxes],[TransDate],[Buyer],[UserName],[Quantity],[CostPrice],[ChangeDate]) VALUES " _
                        & "(" & CLng(txtDocumentNumber.Text) & ", '" & txtAccountNumber.Text & "', '" & strItemCode & "', " _
                        & "'" & strDescription & "', " & dblDiscounts & ", " & dblTaxes & ", '" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', " _
                        & "'" & cboBuyer.Text & "', '" & strUserName & "', " & dblQuantity & ", " & dblCostPrice & ", '" & Now & "')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()

                End If

            Next

        End With

        'Post the transaction to the ledger account. The affected accounts are the creditors accounts
        'and the purchases control account

        'update the default sales account as well
        'strPublicPurchasesAccount
        If String.IsNullOrEmpty(strPublicPurchasesAccount) Then
            MessageBox.Show("The purchases control account has not been setup. This will seriously affect the trial balance",
                 "Purchases Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], " _
                & "[FolioReference], [BranchCode], [CostCode], [SpecialKey]) VALUES " _
                & "('" & strPublicPurchasesAccount & "', '" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', " _
                & "" & CDbl(lblPayable.Text) & ", 'DEBIT', '" & strPublicCreditorsAccount & "', " _
                & "'" & cboSupplierName.Text & "-" & txtAccountNumber.Text & "', '" & strUserName & "', " _
                & "'" & strUserBranch & "', " & Convert.ToDouble(txtDocumentNumber.Text) & ", '" & txtInvoiceNumber.Text & "', " _
                & "0, 0, " & intSpecialKey & ")", cnn)
            objCommand.ExecuteNonQuery()
        End If

        'Update the creditors control account
        If String.IsNullOrEmpty(strPublicCreditorsAccount) Then
            MessageBox.Show("The creditors control account has not been setup. This will seriously affect the trial balance",
                 "Creditors Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], " _
                & "[FolioReference], [BranchCode], [CostCode], [SpecialKey]) VALUES " _
                & "('" & strPublicCreditorsAccount & "', '" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', " & CDbl(lblPayable.Text) & ", 'CREDIT', " _
                & "'" & strPublicPurchasesAccount & "', '" & cboSupplierName.Text & "-" & txtAccountNumber.Text & "', '" & strUserName & "', " _
                & "'" & strUserBranch & "', " & Convert.ToDouble(txtDocumentNumber.Text) & ", " _
                & "'" & txtInvoiceNumber.Text & "', 0, 0, " & intSpecialKey & ")", cnn)
            objCommand.ExecuteNonQuery()
        End If

        'Update the taxes control account as well
        If IsNumeric(lblTaxes.Text) Then
            If CDbl(lblTaxes.Text) > 0 Then
                If String.IsNullOrEmpty(strPublicTaxesAccount) Then
                    MessageBox.Show("The taxes control account has not been setup. This will seriously affect the trial balance", _
                        "Taxes Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Dim strProcessStatus As String = gwt_comm.LedgerEntry("INSERT", gwt_comm.shortMonthDateFormat(dpTransDate.Value), strPublicTaxesAccount,
                        txtAccountNumber.Text, cboSupplierName.Text, CDbl(lblTaxes.Text), "DEBIT",
                        txtDocumentNumber.Text, txtInvoiceNumber.Text, , , 0, 0, 0, 0, intSpecialKey, 0)
                    If strProcessStatus <> "SUCCESS" Then GoTo RaiseErr
                End If
            End If
        End If

        'Update the control numbers table
        objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET SupplierInvoices = " & CDbl(txtDocumentNumber.Text) & "", cnn)
        objCommand.ExecuteNonQuery()

        txtDocumentNumber.Text = CStr(gwt_comm.GetNextDocumentNumber("SupplierInvoices"))

        MessageBox.Show("Supplier invoice saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Creditors Invoice Entries"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveNew.Click
        SaveData()
        'Clear controls and get the next document number
        txtDocumentNumber.Text = CStr(gwt_comm.GetNextDocumentNumber("SupplierInvoices"))
        txtAddress.Clear()
        txtAccountNumber.Clear()
        txtNotes.Clear()
        txtInvoiceNumber.Clear()
        txtOrderNumber.Clear()
        dGrid.Rows.Clear()
        dGrid.Rows.Add(250)
        AlternateColors()
        cboSupplierName.Focus()
    End Sub

    Private Sub LoadInvoiceDetails(ByVal DocumentNumber As Long)
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [AccountNumber],[SupplierReference]," _
            & "[TransDate],[OrderNumber],[Buyer],[Value],[Discount],[Taxes],[DocumentNumber], " _
            & "[Status],[UserName],[Notes] FROM SupplierInvoicesMain WHERE DocumentNumber = " & DocumentNumber & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                txtAccountNumber.Text = objReader(0).ToString
                'Get the address and name details
                LoadSelectedSupplierDetails(txtAccountNumber.Text)
            End If
            If Not IsDBNull(objReader("SupplierReference").ToString) Then txtInvoiceNumber.Text = objReader("SupplierReference").ToString
            If IsDate(objReader("TransDate").ToString) Then dpTransDate.Value = CDate(objReader("TransDate").ToString)
            If Not IsDBNull(objReader("OrderNumber").ToString) Then txtOrderNumber.Text = objReader("OrderNumber").ToString
            If Not IsDBNull(objReader("Buyer").ToString) Then cboBuyer.Text = objReader("Buyer").ToString
            If Not IsDBNull(objReader("DocumentNumber").ToString) Then txtDocumentNumber.Text = objReader("DocumentNumber").ToString
            If Not IsDBNull(objReader("Notes").ToString) Then txtNotes.Text = objReader("Notes").ToString
        End If
        objReader.Close()

        'Get the details
        objCommand = New Data.OleDb.OleDbCommand("SELECT [ItemCode],[Description],[Quantity],[CostPrice], " _
            & "[Discount],[Taxes] FROM SupplierInvoicesDetails WHERE DocumentNumber = " & DocumentNumber & "", cnn)
        objReader = objCommand.ExecuteReader
        Dim p As Integer = 0
        While objReader.Read
            If Not IsDBNull(objReader("ItemCode").ToString) Then dGrid.Rows(p).Cells(0).Value = objReader("ItemCode").ToString
            If Not IsDBNull(objReader("Description").ToString) Then dGrid.Rows(p).Cells(1).Value = objReader("Description").ToString
            If Not IsDBNull(objReader("Quantity").ToString) Then dGrid.Rows(p).Cells(4).Value = objReader("Quantity").ToString
            If Not IsDBNull(objReader("CostPrice").ToString) Then dGrid.Rows(p).Cells(3).Value = objReader("CostPrice").ToString
            If Not IsDBNull(objReader("Discount").ToString) Then dGrid.Rows(p).Cells(6).Value = objReader("Discount").ToString
            If Not IsDBNull(objReader("Taxes").ToString) Then dGrid.Rows(p).Cells(7).Value = objReader("Taxes").ToString
            ComputeLineTotal(p)
            p = p + 1
        End While
        objReader.Close()
        dGrid.CurrentCell = dGrid.Rows(0).Cells(1)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Creditors Invoice Entries"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub chkOverideDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverideDate.CheckedChanged
        If chkOverideDate.Checked = True Then
            If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
                dpTransDate.Enabled = True
            Else
                boolAbort = False
                boolAuthorized = False
                gwt_comm.SuperUserAuthentication()
                If boolAbort = True Then
                    chkOverideDate.Checked = False
                    Exit Sub
                End If
                If boolAuthorized = True Then
                    dpTransDate.Enabled = True
                    boolAuthorized = False
                End If
            End If
        Else
            dpTransDate.Enabled = False
            boolAuthorized = False
        End If
    End Sub

    Public Sub GenerateTransactionDocument(ByVal DocumentNumber As Long)
        On Error GoTo RaiseErr

        'Get the order main details
        Dim strAccountNumber As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, SupplierInvoicesMain.TransDate, 105) AS [Date], " _
            & "SupplierInvoicesMain.AccountNumber, Suppliers.AccountName, SupplierInvoicesMain.Value, SupplierInvoicesMain.Notes, " _
            & "SupplierInvoicesMain.Buyer FROM SupplierInvoicesMain LEFT OUTER JOIN Suppliers ON SupplierInvoicesMain.AccountNumber " _
            & "= Suppliers.AccountNumber WHERE DocumentNumber = " & DocumentNumber & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(1).ToString) Then strAccountNumber = objReader(1).ToString
            strMainDetails = objReader(0) & "|" & objReader(1) & "|" & objReader(2) & "|" & objReader(3) & "|" & objReader(4) & "|" & objReader(5)
        Else
            objReader.Close()
            MessageBox.Show("There is a problem printing this order. Missing key details", _
                "Missing Key Order Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            boolAbort = True
            Exit Sub
        End If
        objReader.Close()

        'Get the order transactions
        arrPrintDetails = New ArrayList
        objCommand = New Data.OleDb.OleDbCommand("SELECT CAST(Quantity AS DECIMAL (30,2)) AS [Quantity], Description, " _
            & "CAST(CostPrice AS DECIMAL (30,2)) AS [CostPrice], CAST(Discount AS DECIMAL (30,2)) AS [Discount], " _
            & "CAST(Taxes AS DECIMAL (30,2)) AS [Taxes], CAST((((Quantity * CostPrice ) - Discount) + Taxes) AS DECIMAL (30,2)) AS [LineTotal] " _
            & "FROM SupplierInvoicesDetails WHERE DocumentNumber = " & DocumentNumber & "", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            arrPrintDetails.Add(objReader(0).ToString & "|" & objReader(1).ToString & "|" & objReader(2).ToString _
                & "|" & objReader(3).ToString & "|" & objReader(4).ToString & "|" & objReader(5).ToString)
        End While
        objReader.Close()

        'Get the supplier details
        objCommand = New Data.OleDb.OleDbCommand("SELECT Address1, Address2, Address3, Address4, " _
            & "AccountName, PhoneNumber, EmailAddress, VatNumber FROM Suppliers " _
            & "WHERE AccountNumber = '" & strAccountNumber & "'", cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strSupplierAddress1 = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strSupplierAddress2 = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strSupplierAddress3 = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then strSupplierAddress4 = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then strSupplierName = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then strSupplierTelephone = objReader(5).ToString
            If Not IsDBNull(objReader(6).ToString) Then strSupplierEmailAddress = objReader(6).ToString
            If Not IsDBNull(objReader(7).ToString) Then strSupplierVatNumber = objReader(7).ToString
        End If
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to print the order"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub pdWindows_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdWindows.PrintPage

        If boolPrintFromPreview = True Then
            'requery records
            boolAbort = False
            Me.GenerateTransactionDocument(CDbl(txtDocumentNumber.Text))
            If boolAbort = True Then Exit Sub
            boolPrintFromPreview = False
        End If
        Dim strDType As String
        strDType = UCase("SUPPLIER ORDER ACCEPTANCE")
        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer

        x1 = e.PageBounds.Left + 100
        y1 = e.PageBounds.Top + 100
        p1 = e.PageBounds.Width - 200
        y2 = e.PageBounds.Height - 200

        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        Dim strS As String = Nothing
        Dim Yc As Double
        Dim cols, lines As Double

        'Draw the document rectangle
        reccurrent = New Rectangle(x1, y1, p1, y2)
        e.Graphics.DrawRectangle(Pens.Black, reccurrent)

        'print the company logo
        Dim g As Graphics = e.Graphics
        g.DrawString(UCase("SUPPLIER ORDER ACCEPTANCE"), New Font("Arial", 16, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, Color.Black)), 350, e.PageBounds.Top + 110)
        'Draw a line after
        y1 = y1 + 40
        e.Graphics.DrawLine(Pens.Black, x1, y1, p1 + 100, y1)

        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                'Dont print the company name as it is taken care of by the logo
                strCompanyName = ""
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoXposition, intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
            End If
        End If

        y1 = y1 + 15

        'Print the company details at the extreme left of document
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, HeaderFont, Brushes.Black)
        y1 = y1 + 20

        If Not String.IsNullOrEmpty(strCompanyAddress1) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress1, tlFont, Brushes.Black)
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.", tlFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyBPNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.", tlFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyBPNumber), tlFont, Brushes.Black)
                y1 = y1 + 15
            End If
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress2) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress2, tlFont, Brushes.Black)
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO.", tlFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyVatNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO.", tlFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyVatNumber), tlFont, Brushes.Black)
            End If
            y1 = y1 + 15
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress3) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress3, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyAddress4) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress4, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyTelephone) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "PHONE", tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 250, 80, UCase(strCompanyTelephone), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        'strCompanyContactCellNumber
        If Not String.IsNullOrEmpty(strCompanyContactCellNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 550, 80, "CELL NO", tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 550, 80, UCase(strCompanyContactCellNumber), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyFaxNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "FAX NO.", tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 250, 80, UCase(strCompanyFaxNumber), tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyEmailAddress) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "E-MAIL", tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 250, 80, strCompanyEmailAddress, tlFont, Brushes.Black)
            y1 = y1 + 15
        End If
        y1 = y1 + 5

        'print captions
        x1 = x1 + 10
        x2 = x1 + 50
        X3 = x2 + 140
        X4 = X3 + 100
        X5 = X4 + 100
        X6 = X5 + 100

        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        e.Graphics.DrawString("SUPPLIER DETAILS", prFont, Brushes.Black, x1, y1)
        e.Graphics.DrawString("TRANSACTION DETAILS", prFont, Brushes.Black, 500, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 15
        'e.Graphics.DrawString("VAT No.: " & strSupplierVatNumber, tlFont, Brushes.Black, x1, y1)
        'y1 = y1 + 15
        If strSupplierName.Length > 58 Then strSupplierName = Mid(strSupplierName, 1, 58)
        e.Graphics.DrawString(UCase(strSupplierName), tlFont, Brushes.Black, x1, y1)

        'Print the date
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "DATE", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(gwt_comm.shortMonthDateFormat(dpTransDate.Value)), tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "YOUR REF.", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(txtInvoiceNumber.Text), tlFont, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress1, tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress2, tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "OUR REF.", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, Format(CLng(txtDocumentNumber.Text), "000000"), prFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress3, tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "ORDER NO.", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(txtOrderNumber.Text), tlFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress4, tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "BUYER", tlFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(cboBuyer.Text), tlFont, Brushes.Black)
        y1 += 15
        e.Graphics.DrawString("PHONE  : " & strSupplierTelephone, tlFont, Brushes.Black, x1, y1)
        y1 += 15
        e.Graphics.DrawString("E-MAIL : " & strSupplierEmailAddress, tlFont, Brushes.Black, x1, y1)
        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        'print captions
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 60, 80, "QTY", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 250, 80, "DESCRIPTION", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X3, y1, 120, 80, "UNIT PRICE", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 120, 80, "TAX", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, "DISCOUNT", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, "TOTAL", prFont, Brushes.Black)
        'draw a line after
        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 30
        itm = 0
        reccurrent = New Rectangle()
        boolExitingWhile = False
        Dim strBuffer() As String
        While itm < arrPrintDetails.Count

            strBuffer = Split(arrPrintDetails(itm), "|")

            'QUANTITY PRINTING
            Call gwt_comm.DrawStringInBoxCenter(e, x1, y1, 50, 60, strBuffer(0), tlFont, Brushes.Black)
            'UNIT PRICE PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, X3, y1, 120, 80, strBuffer(2), tlFont, Brushes.Black)
            'TAX PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 120, 80, strBuffer(4), tlFont, Brushes.Black)
            'DISCOUNT PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, strBuffer(3), tlFont, Brushes.Black)
            'LINE TOTAL PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, strBuffer(5), tlFont, Brushes.Black)

            'Print the description last as it is the column that will determine the next line position
            If Not strBuffer(1) Is Nothing Then strValue = strBuffer(1) Else strValue = ""
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 480, 80, strValue, tlFont, Brushes.Black)

            'Get the size of the address box
            e.Graphics.MeasureString(strValue, tlFont, New SizeF(200, 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * tlFont.Height + 5
            y1 = Math.Max(y1, Yc)

            itm = itm + 1 : Dim i As Integer = 0
            If itm = 23 Then
                'Print the page number of the statement
                Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, tlFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", prFont, Brushes.Black)
                e.HasMorePages = True
                boolExitingWhile = True
                intPage += 1
                Exit While
            End If
        End While

        'print totals
        'draw a line
        If boolExitingWhile = False Then
            y1 = y1 + 30
            e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
            y1 = y1 + 30

            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 120, 80, "TOTALS ", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 120, 80, Format(CDbl(lblTaxes.Text), "#,##0.00"), prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, Format(CDbl(lblDiscounts.Text), "#,##0.00"), prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, Format(CDbl(lblPayable.Text), "#,##0.00"), prFont, Brushes.Black)

            y1 = y1 + 45
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 400, 80, txtNotes.Text, ItalicFont, Brushes.Black)

            Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", prFont, Brushes.Black)

            e.HasMorePages = False
            Me.boolPrintFromPreview = True

        End If

    End Sub

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        boolAbort = False
        GenerateTransactionDocument(CLng(txtDocumentNumber.Text))
        If boolAbort = True Then Exit Sub
        PrintPreviewDialog1.Document = pdWindows
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub frmSupplierInvoiceEntry_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Enter Or e.KeyValue = 9 Or e.KeyValue = Keys.F5 Then
            If dGrid.CurrentCell.ColumnIndex = 0 Then
                strPublicItemCode = Nothing
                strFullItemDetails = Nothing
                boolAbort = False
                gwt_comm.InventorySearch()
                If boolAbort = True Then Exit Sub
                CommitValueChanged()
                dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(2)
            End If
        End If

        If e.KeyValue = Keys.F3 Then
            SaveData()
        End If

    End Sub

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand
        For z As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.CurrentRow.Cells(z).Value = Nothing
        Next

        Dim boolItemTaxable As Boolean = True

        RecalculateAmount()

        If Not String.IsNullOrEmpty(strFullItemDetails) Then

            Dim strSplitValues() As String = Split(strFullItemDetails, ";")

            dGrid.CurrentRow.Cells(0).Value = UCase(strSplitValues(0))
            dGrid.CurrentRow.Cells(1).Value = UCase(strSplitValues(1))
            dGrid.CurrentRow.Cells(3).Value = strSplitValues(2)
            dGrid.CurrentRow.Cells(4).Value = "1"
            dGrid.CurrentRow.Cells(6).Value = "0"

            If UCase(strSplitValues(4)) = "YES" Then boolItemTaxable = True Else boolItemTaxable = False

            'Get the item type
            dGrid.CurrentRow.Cells(5).ReadOnly = False
            Dim strCodeSelected As String = dGrid.CurrentRow.Cells(0).Value.ToString
            Dim dblSalePrice As Double = 0
            objCommand = New Data.OleDb.OleDbCommand("SELECT InventoryType, SellingPrice FROM InventoryItems " _
                & "WHERE ItemCode = '" & strCodeSelected & "'", cnn)
            Dim objReadType As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadType.HasRows Then
                objReadType.Read()
                If Not IsDBNull(objReadType(0).ToString) Then
                    If UCase(objReadType(0).ToString) = "SPECIFIC" Then
                        dGrid.CurrentRow.Cells(5).ReadOnly = True
                    End If
                End If
                If IsNumeric(objReadType(1).ToString) Then dblSalePrice = CDbl(objReadType(1).ToString)
            End If
            objReadType.Close()

            'Apply the discount
            Dim dblDiscounts() As Double = gwt_comm.ItemOnSpecials(strCodeSelected, dblSalePrice)
            dGrid.CurrentRow.Cells(6).Value = CStr(Format((dblDiscounts(1) * CDbl(dGrid.CurrentRow.Cells(4).Value.ToString)), "##0.00"))

            ComputeValues(CDbl(dGrid.CurrentRow.Cells(3).Value.ToString), CDbl(dGrid.CurrentRow.Cells(4).Value.ToString), dGrid.CurrentRow.Index, dGrid.CurrentRow.Cells(6).Value.ToString, 0, boolItemTaxable)
        Else
            dGrid.CurrentRow.Cells(0).Value = Nothing
            dGrid.CurrentRow.Cells(1).Value = Nothing
            dGrid.CurrentRow.Cells(3).Value = Nothing
            dGrid.CurrentRow.Cells(4).Value = Nothing
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On discount computation"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
