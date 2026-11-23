Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmReceiveDrugs

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGridEntry_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridEntry.EditingControlShowing
        If dGridEntry.CurrentCell.ColumnIndex = 2 Then
            RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            Exit Sub
        End If
        Exit Sub
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

    Private Sub frmReceiveDrugs_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dGridEntry.Rows.Add(1)
        LoadSuppliers()
    End Sub

    Private Sub LoadSuppliers()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM Suppliers ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboSuppliers
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "200;60"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(AccountNumber) FROM Suppliers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboSuppliers.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()
        If intItemsCount > 0 Then
            cboSuppliers.SelectedIndex = -1
            cboSuppliers.Items.Clear()
            cboSuppliers.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboSuppliers.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Supplier Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGridEntry_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridEntry.CellEndEdit
        If dGridEntry.CurrentCell.ColumnIndex = 6 Or dGridEntry.CurrentCell.ColumnIndex = 7 Or dGridEntry.CurrentCell.ColumnIndex = 4 Then
            Dim dblQty As Double = 1
            Dim dblTaxes As Double = 0
            Dim dblUnitPrice As Double = 0

            If IsNumeric(dGridEntry.CurrentRow.Cells(4).Value) Then
                dblQty = CDbl(dGridEntry.CurrentRow.Cells(4).Value)
            End If

            If IsNumeric(dGridEntry.CurrentRow.Cells(6).Value) Then
                dblUnitPrice = CDbl(dGridEntry.CurrentRow.Cells(6).Value.ToString)
            End If

            If IsNumeric(dGridEntry.CurrentRow.Cells(7).Value) Then
                dblTaxes = CDbl(dGridEntry.CurrentRow.Cells(7).Value.ToString)
            End If

            If IsNumeric(dGridEntry.CurrentCell.Value) Then
                dGridEntry.CurrentCell.Value = Format(CDbl(dGridEntry.CurrentCell.Value.ToString), "##0.00")
            End If

            dGridEntry.CurrentRow.Cells(8).Value = Format((dblTaxes + (dblQty * dblUnitPrice)), "##0.00")

        End If
    End Sub

    Private Sub cboSuppliers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSuppliers.SelectedIndexChanged
        On Error Resume Next
        txtSupplierId.Text = Nothing
        txtSupplierId.Text = cboSuppliers.SelectedItem.Col2
    End Sub

    Private Sub dGridEntriy_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridEntry.KeyDown
        If e.KeyValue = 9 Then
            If dGridEntry.CurrentCell.ColumnIndex = 0 Then
                strSelectedCode = Nothing
                strSelectedCodeDescription = Nothing
                boolAbort = False
                Dim frm As New frmDrugSearchShort
                frm.ShowDialog()
                If boolAbort = True Then
                    e.SuppressKeyPress = True
                    'dGridEntriy.CurrentCell = dGridEntriy.CurrentRow.Cells(0)
                Else
                    dGridEntry.CurrentCell.Value = strSelectedCodeDescription
                    dGridEntry.CurrentRow.Cells(1).Value = strSelectedCode
                    dGridEntry.CurrentRow.Cells(5).Value = strSelectedPackSize
                    dGridEntry.CurrentCell = dGridEntry.CurrentRow.Cells(1)
                End If
            End If

            If dGridEntry.CurrentCell.ColumnIndex = dGridEntry.ColumnCount - 1 Then
                'Check that the data is correctly entered
                Dim strDrugName As String = Nothing
                Dim strDrugCode As String = Nothing
                Dim strBatchNumber As String = Nothing
                Dim strExpiryDate As String = Nothing
                Dim dblQuantity As Double = 0
                Dim strPackSize As String = Nothing
                Dim dblPrice As Double = 0
                Dim dblTaxes As Double = 0
                Dim dblPayable As Double = 0

                e.SuppressKeyPress = True

                If Not Object.Equals(dGridEntry.CurrentRow.Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridEntry.CurrentRow.Cells(0).Value.ToString) Then
                        strDrugName = dGridEntry.CurrentRow.Cells(0).Value.ToString
                    End If
                End If
                If Not Object.Equals(dGridEntry.CurrentRow.Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridEntry.CurrentRow.Cells(1).Value.ToString) Then
                        strDrugCode = dGridEntry.CurrentRow.Cells(1).Value.ToString
                    End If
                End If
                If Not Object.Equals(dGridEntry.CurrentRow.Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridEntry.CurrentRow.Cells(2).Value.ToString) Then
                        strBatchNumber = dGridEntry.CurrentRow.Cells(2).Value.ToString
                    End If
                End If
                If Not Object.Equals(dGridEntry.CurrentRow.Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridEntry.CurrentRow.Cells(3).Value.ToString) Then
                        strExpiryDate = dGridEntry.CurrentRow.Cells(3).Value.ToString
                    End If
                End If

                If Not Object.Equals(dGridEntry.CurrentRow.Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridEntry.CurrentRow.Cells(4).Value.ToString) Then
                        If IsNumeric(dGridEntry.CurrentRow.Cells(4).Value.ToString) Then
                            dblQuantity = dGridEntry.CurrentRow.Cells(4).Value.ToString
                        End If
                    End If
                End If

                If Not Object.Equals(dGridEntry.CurrentRow.Cells(5).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridEntry.CurrentRow.Cells(5).Value.ToString) Then
                        strPackSize = dGridEntry.CurrentRow.Cells(5).Value.ToString
                    End If
                End If

                If Not Object.Equals(dGridEntry.CurrentRow.Cells(6).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridEntry.CurrentRow.Cells(6).Value.ToString) Then
                        If IsNumeric(dGridEntry.CurrentRow.Cells(6).Value.ToString) Then
                            dblPrice = dGridEntry.CurrentRow.Cells(6).Value.ToString
                        End If
                    End If
                End If

                If Not Object.Equals(dGridEntry.CurrentRow.Cells(7).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridEntry.CurrentRow.Cells(7).Value.ToString) Then
                        If IsNumeric(dGridEntry.CurrentRow.Cells(7).Value.ToString) Then
                            dblTaxes = dGridEntry.CurrentRow.Cells(7).Value.ToString
                        End If
                    End If
                End If

                If Not Object.Equals(dGridEntry.CurrentRow.Cells(8).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridEntry.CurrentRow.Cells(8).Value.ToString) Then
                        If IsNumeric(dGridEntry.CurrentRow.Cells(8).Value.ToString) Then
                            dblPayable = dGridEntry.CurrentRow.Cells(8).Value.ToString
                        End If
                    End If
                End If

                If String.IsNullOrEmpty(strDrugName) Then
                    MessageBox.Show("Missing the drug name. Please correct this error", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGridEntry.CurrentCell = dGridEntry.CurrentRow.Cells(0)
                    Exit Sub
                End If

                If String.IsNullOrEmpty(CStr(dblQuantity)) Then
                    MessageBox.Show("Missing quantity. Please correct this error", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGridEntry.CurrentCell = dGridEntry.CurrentRow.Cells(4)
                    Exit Sub
                End If

                If String.IsNullOrEmpty(strDrugCode) Then
                    MessageBox.Show("Missing the drug code. Please correct this error", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGridEntry.CurrentCell = dGridEntry.CurrentRow.Cells(0)
                    Exit Sub
                End If

                If String.IsNullOrEmpty(strExpiryDate) Then
                    MessageBox.Show("Missing the drug cipher. Please correct this error", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGridEntry.CurrentCell = dGridEntry.CurrentRow.Cells(3)
                    Exit Sub
                Else
                    Dim strDateComponents() As String = Split(strExpiryDate, "-")
                    If strDateComponents.Length < 3 Then
                        MessageBox.Show("Missing the drug cipher. Please correct this error", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        dGridEntry.CurrentCell = dGridEntry.CurrentRow.Cells(3)
                        Exit Sub
                    Else
                        For p As Integer = 0 To strDateComponents.Length - 1
                            If Not IsNumeric(strDateComponents(p)) Then
                                MessageBox.Show("Missing the drug cipher. Please correct this error", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                dGridEntry.CurrentCell = dGridEntry.CurrentRow.Cells(3)
                                Exit Sub
                            End If
                        Next
                        If CInt(strDateComponents(0)) <= 0 Or CInt(strDateComponents(0)) > 31 Or _
                            CInt(strDateComponents(1)) <= 0 Or CInt(strDateComponents(1)) > 12 Then
                            MessageBox.Show("Missing the drug cipher. Please correct this error", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            dGridEntry.CurrentCell = dGridEntry.CurrentRow.Cells(3)
                            Exit Sub
                        End If
                        Dim strFormattedExpiryDate As String = strDateComponents(0) & "-" & MonthName(CInt(strDateComponents(1)), True) & "-" & strDateComponents(2)
                        If Not IsDate(strFormattedExpiryDate) Then
                            MessageBox.Show("Missing the drug cipher. Please correct this error", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            dGridEntry.CurrentCell = dGridEntry.CurrentRow.Cells(3)
                            Exit Sub
                        End If
                        strExpiryDate = strFormattedExpiryDate
                    End If
                End If

                'Accept the items here
                dGrid.Rows.Add(strDrugName, strDrugCode, strBatchNumber, strExpiryDate, dblQuantity, _
                    strPackSize, Format(dblPrice, "##0.00"), Format(dblTaxes, "##0.00"), Format(dblPayable, "##0.00"))

                'Accumulate the totals on top
                Dim MovingTotal As Double = 0
                MovingTotal = CDbl(lblPayable.Text) + dblPayable
                lblPayable.Text = Format(MovingTotal, "##0.00")

                'Compute payable
                Dim dblTaxesTotal As Double = 0
                dblTaxesTotal = CDbl(lblTaxes.Text) + dblTaxes
                lblTaxes.Text = Format(dblTaxesTotal, "##0.00")

                'Reset the grid values to nothing 
                For p As Integer = 0 To dGridEntry.ColumnCount - 1
                    dGridEntry.Rows(0).Cells(p).Value = Nothing
                Next
                dGridEntry.CurrentCell = dGridEntry.CurrentRow.Cells(0)

            End If
        End If
    End Sub

    Private Sub btnSaveNew_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveNew.Click
        boolAbort = False
        SaveData()
        If boolAbort = True Then Exit Sub
        InitializeControls()
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = Nothing

        If String.IsNullOrEmpty(txtSupplierId.Text) Then
            MessageBox.Show("Please select the supplier from the given list", "Missing Supplier Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSuppliers.Select()
            Exit Sub
        End If

        Dim intNextDocumentNumber As Integer = 0
        If boolEditStatus = True Then
            intNextDocumentNumber = intSelectedOrderEntryId
            AdjustItemsAndQuantities(intSelectedOrderEntryId)
        Else
            intNextDocumentNumber = gwt_comm.GetNextDocumentNumber("Orders")
        End If

        For p As Integer = 0 To dGrid.Rows.Count - 1

            'Check that the data is correctly entered
            Dim strDrugName As String = Nothing
            Dim strDrugCode As String = Nothing
            Dim strBatchNumber As String = Nothing
            Dim strExpiryDate As String = Nothing
            Dim dblQuantity As Double = 0
            Dim strPackSize As String = Nothing
            Dim dblPrice As Double = 0
            Dim dblTaxes As Double = 0
            Dim dblPayable As Double = 0

            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strDrugName = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    strDrugCode = dGrid.Rows(p).Cells(1).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    strBatchNumber = dGrid.Rows(p).Cells(2).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(3).Value.ToString) Then
                    strExpiryDate = dGrid.Rows(p).Cells(3).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(4).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(4).Value.ToString) Then
                        dblQuantity = dGrid.Rows(p).Cells(4).Value.ToString
                    End If
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(5).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(5).Value.ToString) Then
                    strPackSize = dGrid.Rows(p).Cells(5).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(6).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(6).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(6).Value.ToString) Then
                        dblPrice = dGrid.Rows(p).Cells(6).Value.ToString
                    End If
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(7).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(7).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(7).Value.ToString) Then
                        dblTaxes = dGrid.Rows(p).Cells(7).Value.ToString
                    End If
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(8).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(8).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(8).Value.ToString) Then
                        dblPayable = dGrid.Rows(p).Cells(8).Value.ToString
                    End If
                End If
            End If

            strSql = "INSERT INTO OchmasReceivedDrugs ([TransactionDate],[BatchNumber],[OrderNumber]," _
                & "[DrugCode],[OrderPrice],[Quantity],[BranchName],[UserName],[ChangeDate]," _
                & "[ExpiryDate],[Taxes],[Payable],[PackSize],[SupplierId],[ReferenceNumber],[ManufacturerName]) VALUES " _
                & "('" & Format(dpDate.Value, "dd-MMM-yyyy") & "', '" & strBatchNumber & "', '" & txtOrderNumber.Text & "', " _
                & "'" & strDrugCode & "', " & dblPrice & ", " & dblQuantity & ", '" & strUserBranch & "', " _
                & "'" & strUserName & "', '" & Now & "', '" & strExpiryDate & "', " & dblTaxes & ", " & dblPayable & ", " _
                & "'" & strPackSize & "', '" & txtSupplierId.Text & "', " & intNextDocumentNumber & ", '')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

            objCommand = New Data.OleDb.OleDbCommand("UPDATE OchmasSystemMedicines SET Quantity = (Quantity + " & dblQuantity & ")", cnn)
            objCommand.ExecuteNonQuery()

        Next

        If Not String.IsNullOrEmpty(txtComments.Text) Then
            If boolEditStatus = True Then
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM OchmasReceivedDrugsNotes WHERE " _
                    & "ReferenceNumber = " & intSelectedOrderEntryId & "", cnn)
                objCommand.ExecuteNonQuery()
            End If
            strSql = "INSERT INTO OchmasReceivedDrugsNotes (ReferenceNumber, Notes) VALUES " _
                & "(" & intNextDocumentNumber & ", '" & txtComments.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If boolEditStatus = False Then
            objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET Orders = " & intNextDocumentNumber & "", cnn)
            objCommand.ExecuteNonQuery()
        End If

        boolEditStatus = False

        MessageBox.Show("Medicines have been received successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on medicines receiving save"
        ShowErrorMessage()
    End Sub

    Private Sub AdjustItemsAndQuantities(ByVal OrderReferenceNumber As Integer)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT DrugCode, Quantity FROM OchmasReceivedDrugs " _
            & "WHERE ReferenceNumber = " & OrderReferenceNumber & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If IsNumeric(objReader(1).ToString) Then
                objCommand = New Data.OleDb.OleDbCommand("UPDATE OchmasSystemDrugs SET " _
                    & "Quantity = (Quantity - " & CInt(objReader(1).ToString) & ")", cnn)
                objCommand.ExecuteNonQuery()
            End If
        End While
        objReader.Close()
        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM OchmasReceivedDrugs WHERE " _
            & "ReferenceNumber = " & intSelectedOrderEntryId & "", cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on received items quantity adjustment"
        ShowErrorMessage()
    End Sub

    Private Sub InitializeControls()
        dGrid.Rows.Clear()
        lblPayable.Text = "0.00"
        lblTaxes.Text = "0.00"
        txtSupplierId.Text = Nothing
        cboSuppliers.Text = Nothing
        txtOrderNumber.Text = Nothing
        txtOrderNumber.Select()
        boolEditStatus = False
    End Sub

    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click
        If dGrid.Rows.Count > 0 Then
            If MessageBox.Show("Do you want to save the information currently in process?", "Save or Discard Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                SaveData()
            End If
            dGrid.Rows.Clear()
        End If
        intSelectedOrderEntryId = 0
        Dim frm As New frmReceivedDrugOrdersListing
        frm.ShowDialog()
        If intSelectedOrderEntryId = 0 Then Exit Sub
        boolEditStatus = True
        LoadSelectedOrderDetails()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

    End Sub

    Private Sub LoadSelectedOrderDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT [TransactionDate],[BatchNumber],[OrderNumber]," _
            & "[DrugCode],[OrderPrice],[Quantity],[BranchName],[UserName],[ChangeDate]," _
            & "[ExpiryDate],[Taxes],[Payable],[PackSize],[SupplierId],[ReferenceNumber] " _
            & "FROM OchmasReceivedDrugs WHERE ReferenceNumber = " & intSelectedOrderEntryId & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        Dim TransDate As Date
        Dim strSupplierId As String = Nothing

        While objReader.Read
            dGrid.Rows.Add(1)
            If dGrid.Rows.Count = 1 Then
                dpDate.Value = CDate(objReader("TransactionDate").ToString)
                If Not IsDBNull(objReader("SupplierId").ToString) Then
                    txtSupplierId.Text = objReader("SupplierId").ToString
                    Dim strSupplierName = SupplierName(txtSupplierId.Text)
                    cboSuppliers.Text = Nothing
                    cboSuppliers.SelectedText = strSupplierName
                End If
                If Not IsDBNull(objReader("OrderNumber").ToString) Then txtOrderNumber.Text = objReader("OrderNumber").ToString
            End If
            'Medicine, Code, Batch Number, Exp. Date, Quantity, Pack, Price, Taxes, Payable
            If Not IsDBNull(objReader("DrugCode").ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader("DrugCode").ToString
            If Not IsDBNull(objReader("BatchNumber").ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(2).Value = objReader("BatchNumber").ToString
            If IsDate(objReader("ExpiryDate").ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(3).Value = Format(CDate(objReader("ExpiryDate").ToString), "dd-MMM-yyyy")
            If IsNumeric(objReader("Quantity").ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(4).Value = objReader("Quantity").ToString
            If IsNumeric(objReader("PackSize").ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(5).Value = objReader("PackSize").ToString
            If IsNumeric(objReader("OrderPrice").ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(6).Value = Format(CDbl(objReader("OrderPrice").ToString), "##0.00")
            If IsNumeric(objReader("Taxes").ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(7).Value = Format(CDbl(objReader("Taxes").ToString), "##0.00")
            If IsNumeric(objReader("Payable").ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(8).Value = Format(CDbl(objReader("Payable").ToString), "##0.00")
            If Not IsDBNull(objReader("DrugCode").ToString) Then
                Dim strDrugName As String = DrugName(objReader("DrugCode").ToString)
                If Not String.IsNullOrEmpty(strDrugName) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = strDrugName
            End If
        End While
        objReader.Close()

        'Get the totals
        ComputeTotals()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Pharmacy Inventory Orders Load"
        ShowErrorMessage()
    End Sub

    Private Function DrugName(ByVal DrugCode As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ProductName FROM OchmasSystemDrugs " _
            & "WHERE MedpraxProductCode = '" & DrugCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Pharmacy Inventory Orders Load"
        ShowErrorMessage()
    End Function

    Private Function SupplierName(ByVal SupplierId As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountName FROM Suppliers " _
            & "WHERE AccountNumber = '" & SupplierId & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Supplier Name Details Fetch"
        ShowErrorMessage()
    End Function

    Private Sub btnNewOrder_Click(sender As System.Object, e As System.EventArgs) Handles btnNewOrder.Click
        boolEditStatus = False
        InitializeControls()
    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr

        Dim dblCost As Double = 0
        Dim dblTaxes As Double = 0
        Dim dblPayable As Double = 0

        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(6).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(6).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(6).Value.ToString) Then
                        dblCost = dblCost + CDbl(dGrid.Rows(p).Cells(6).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(7).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(7).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(7).Value.ToString) Then
                        dblTaxes = dblTaxes + CDbl(dGrid.Rows(p).Cells(7).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(8).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(8).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(8).Value.ToString) Then
                        dblPayable = dblPayable + CDbl(dGrid.Rows(p).Cells(8).Value.ToString)
                    End If
                End If
            End If
        Next

        lblSubTotal.Text = Format(dblCost, "##0.00")
        lblTaxes.Text = Format(dblTaxes, "##0.00")
        lblPayable.Text = Format(dblPayable, "##0.00")

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on order totals summation"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dGrid.RowsRemoved
        ComputeTotals()
    End Sub

    Private Sub KryptonPanel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles KryptonPanel.Paint

    End Sub

End Class
