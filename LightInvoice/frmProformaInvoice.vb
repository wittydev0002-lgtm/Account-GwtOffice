Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmProformaInvoice

    Dim prFont As New Font("Arial", 6, FontStyle.Bold)
    Dim tlFont As New Font("Arial", 6, FontStyle.Regular)
    Dim HeaderFont As New Font("Arial", 10, FontStyle.Bold)
    Dim strTaxStatus As String = Nothing
    Dim strCustomerDetails As String
    Dim strInvoiceDetails As ArrayList
    Dim rsInvoiceTotals As String

    Dim dblInvoiceTotal As Double
    Dim dblTaxes As Double
    Dim dblDiscounts As Double
    Dim i As Integer = 0
    Dim strvalue As String
    Dim strDate As String
    Dim itm As Integer
    Dim boolPrintFromPreview As Boolean
    Dim intPaymentReceiptNumber As Integer
    Dim strCustomerAccountNumberPayments As String
    Dim strTermsAndConditions As String = Nothing

    Dim strCustomerName As String
    Dim strCustomerAddress1 As String
    Dim strCustomerAddress2 As String
    Dim strCustomerAddress3 As String
    Dim strCustomerAddress4 As String
    Dim strCustomerTelephone As String
    Dim strCustomerEmailAddress As String
    Dim strCustomerVatNumber As String

    Dim boolExitingWhile As Boolean = False
    Dim intPage As Single = 1
    Dim intPageTotals As Integer = 1

    Dim strItemType As String = Nothing

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit

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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmProforma_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boolFormInitializing = True
        dGrid.Rows.Add(100)
        txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("Proforma"))
        LoadData()

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
        If boolEditStatusTwo = True Then
            LoadProformaDetails()
            btnPrint.Enabled = True
            btnConvert.Enabled = True
        Else
            btnPrint.Enabled = False
            btnConvert.Enabled = False
        End If
        If boolLoadedFromCustomerForm = True Then
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountNumber, AccountName, " _
            & "TakeOnDate, Address1, Address2, Address3, Address4, ContactPerson, PhoneNumber, " _
            & "FaxNumber, Cellphone, EmailAddress, VatNumber FROM Customers WHERE " _
            & "AccountNumber = '" & strSelectedAccount & "'", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader("AccountName").ToString) Then txtAccountName.Text = objReader("AccountName").ToString
                If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
                If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
                If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
                If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
                If Not IsDBNull(objReader("Cellphone").ToString) Then txtContactNumber.Text = objReader("Cellphone").ToString & "/" & objReader("PhoneNumber")
                If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
                If Not IsDBNull(objReader("VatNumber").ToString) Then txtTaxNumber.Text = objReader("VatNumber").ToString
            End If
            txtAccountName.Enabled = False
            txtAddress1.Enabled = False
            txtAddress2.Enabled = False
            txtAddress3.Enabled = False
            txtAddress4.Enabled = False
            txtContactNumber.Enabled = False
            txtEmailAddress.Enabled = False
            txtTaxNumber.Enabled = False
            objReader.Close()
        End If
        boolFormInitializing = False
        txtAccountName.Focus()
        txtAccountName.Select()
        Exit Sub
RaiseErr:
        boolFormInitializing = False
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter
        On Error GoTo RaiseErr
        If e.RowIndex < 0 Then Exit Sub
        If cboItems.Visible = True Then cboItems.Visible = False
        If e.ColumnIndex = 0 Then
            LoadData()
            cboItems.Size = dGrid.CurrentCell.Size
            cboItems.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top
            cboItems.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left + 3
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                cboItems.Text = Convert.ToString(dGrid.CurrentCell.Value)
            Else
                cboItems.Text = ""
            End If
            cboItems.Visible = True '152
            cboItems.Focus()
            cboItems.SelectAll()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item code search"
        ShowErrorMessage()
    End Sub

    Private Sub cboItems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboItems.KeyPress
        If Asc(e.KeyChar) = 13 Then
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

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSalesData() As String = gwt_comm.SalesInventoryItems(strMainCompanyServiceOffering, strDefaultSearchFilter)
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSalesData(0), cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 4
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "160;180;60;60"
        End With
        'Get a count of the items
        Dim intItemsCount As Double = CDbl(strSalesData(1))
        Dim DropDownItems(intItemsCount + 1) As MTGCComboBoxItem

        cboItems.Items.Clear()
        Dim i As Double = 0
        Dim p As Double = 0

        'Add extra 1st lines for comment
        DropDownItems(p) = New MTGCComboBoxItem("--- COMMENT ---", "", "0.00", "NO")
        p += 1
        DropDownItems(p) = New MTGCComboBoxItem("--- SERVICE ---", "", "0.00", "NO")
        p += 1
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2), strRecordText(3))
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
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr
        If cboItems.Focused = False Then Exit Sub
        Dim objCommand As Data.OleDb.OleDbCommand
        For z As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.CurrentRow.Cells(z).Value = Nothing
        Next

        Dim boolItemTaxable As Boolean = True

        RecalculateAmount()
        If Not cboItems.SelectedItem Is Nothing Then
            dGrid.CurrentRow.Cells(0).Value = cboItems.SelectedItem.Col1
            dGrid.CurrentRow.Cells(1).Value = cboItems.SelectedItem.Col2
            dGrid.CurrentRow.Cells(3).Value = cboItems.SelectedItem.Col3
            dGrid.CurrentRow.Cells(4).Value = "1"
            dGrid.CurrentRow.Cells(6).Value = "0"

            If UCase(cboItems.SelectedItem.Col4) = "YES" Then boolItemTaxable = True Else boolItemTaxable = False

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

            ComputeValues(CDbl(dGrid.CurrentRow.Cells(3).Value.ToString), CDbl(dGrid.CurrentRow.Cells(4).Value.ToString), _
                dGrid.CurrentRow.Index, CDbl(dGrid.CurrentRow.Cells(6).Value.ToString), dblSalesTaxRate, boolItemTaxable)
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
        ShowErrorMessage()
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
            If UCase(strTaxComputationType) = "INCLUSIVE" Then
                dblTaxes = ((dblUnitPrice * intQuantity) - dblDiscount) - (((dblUnitPrice * intQuantity) - dblDiscount) * (100 / (100 + dblTaxRate)))
            Else
                dblTaxes = (dblSubTotal - dblDiscount) * (dblTaxRate / 100) 'dblTaxRate
            End If
        Else
            dblTaxes = 0
        End If

        'If UCase(strTaxComputationType) = "EXCLUSIVE" Then
        dblPayable = (dblSubTotal - dblDiscount) + dblTaxes
        'Else
        'dblPayable = (dblSubTotal - dblDiscount)
        'End If

        dGrid.Rows(intRowIndex).Cells(7).Value = Format(dblTaxes, "##0.00")
        dGrid.Rows(intRowIndex).Cells(8).Value = Format(dblPayable, "##0.00")

        RecalculateAmount()
        ComputeTotals()

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
        lblTaxable.Text = Format(((dblSubTotal - dblDiscountTotals) + 0), "#,##0.00")
        lblTaxes.Text = Format(dblTaxesTotal, "#,##0.00")
        lblDiscounts.Text = Format(dblDiscountTotals, "#,##0.00")
        lblPayable.Text = Format(dblTotalPayable, "#,##0.00")
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If IntPublicInvoicing <> 2 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountName.Text) Then
            MessageBox.Show("Please enter the prospect name", "Missing Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountName.Focus()
            Exit Sub
        Else
            strCustomerName = txtAccountName.Text
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the prospect address first line", "Missing Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If
        FinishTransaction()
        txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("Proforma"))
    End Sub

    Private Sub FinishTransaction()
        On Error GoTo RaiseErr
        If boolEditStatusTwo = True Then
            Dim objDeleteOld As New Data.OleDb.OleDbCommand("DELETE FROM ProformaMain WHERE ReferenceNumber = " & txtReference.Text, cnn)
            objDeleteOld.ExecuteNonQuery()
            objDeleteOld = New Data.OleDb.OleDbCommand("DELETE FROM ProformaDetails WHERE ReferenceNumber = " & txtReference.Text, cnn)
            objDeleteOld.ExecuteNonQuery()
        End If
        'First insert the prospect details
        ''CustomerAccountNumber
        ''IsCustomerStatus
        Dim strIsCustomerStatus As String = "NO"
        If chkCustomerStatus.Checked = True Then strIsCustomerStatus = "YES"
        Dim dtTransDate As String = Format(CInt(DatePart(DateInterval.Day, dpDateOn.Value)), "00") & "-" & UCase(Mid((MonthName(DatePart(DateInterval.Month, dpDateOn.Value))), 1, 3)) & "-" & DatePart(DateInterval.Year, dpDateOn.Value)
        Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO ProformaMain ([TransDate], [SalesAgent], " _
            & "[CustomerName], [Address1], [Address2], [Address3], [Address4], [ContactNumber], [EmailAddress], " _
            & "[UserName], [UserBranch], [ReferenceNumber], [Terms], [QuoteValue], [TotalDiscount], [TotalTaxes], " _
            & "[TaxNumber], [CustomerAccountNumber], [IsCustomerStatus]) " _
            & "VALUES ('" & dtTransDate & "', '" & cboPersonnel.Text & "', " _
            & "'" & txtAccountName.Text & "', '" & txtAddress1.Text & "', '" & txtAddress2.Text & "', '" & txtAddress3.Text & "', " _
            & "'" & txtAddress4.Text & "', '" & txtContactNumber.Text & "', '" & txtEmailAddress.Text & "', " _
            & "'" & strUserName & "', '" & strUserBranch & "', " & CInt(txtReference.Text) & ", '" & txtTerms.Text & "', " _
            & "" & CDbl(lblPayable.Text) & ", " & CDbl(lblDiscounts.Text) & ", " & CDbl(lblTaxes.Text) & ", " _
            & "'" & txtTaxNumber.Text & "', '" & txtAccountNumber.Text & "', '" & strIsCustomerStatus & "')", cnn)
        objCommand.ExecuteNonQuery()


        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim intQty As Double = 0
            Dim strItmCode As String = Nothing
            Dim strDesc As String = Nothing
            Dim dblUnitPrice As Double = 0
            Dim dblDiscounts As Double = 0
            Dim dblTax As Double = 0
            Dim dblPayable As Double = 0
            Dim dblSubTotal As Double = 0
            Dim strEntryType As String = "Item"

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(9).Value), "")) Then
                strEntryType = Convert.ToString(dGrid.Rows(i).Cells(9).Value)
            End If

            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strItmCode = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
            End If

            If Not String.IsNullOrEmpty(strItmCode) Then
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                    strvalue = Convert.ToString(dGrid.Rows(i).Cells(4).Value)
                    If IsNumeric(strvalue) Then
                        intQty = CDbl(strvalue)
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                    strDesc = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                    strvalue = Convert.ToString(dGrid.Rows(i).Cells(3).Value)
                    If IsNumeric(strvalue) Then
                        dblUnitPrice = CDbl(strvalue)
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                    strvalue = Convert.ToString(dGrid.Rows(i).Cells(5).Value)
                    If IsNumeric(strvalue) Then
                        dblSubTotal = CDbl(strvalue)
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(6).Value), "")) Then
                    strvalue = Convert.ToString(dGrid.Rows(i).Cells(6).Value)
                    If IsNumeric(strvalue) Then
                        dblDiscounts = CDbl(strvalue)
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "")) Then
                    strvalue = Convert.ToString(dGrid.Rows(i).Cells(7).Value)
                    If IsNumeric(strvalue) Then
                        dblTax = CDbl(strvalue)
                    End If
                End If

                'If UCase(strTaxComputationType) = "INCLUSIVE" Then
                '    dblPayable = ((dblUnitPrice * intQty) - dblDiscounts) + dblTax
                '    dblSubTotal = ((dblUnitPrice * intQty) - dblDiscounts)
                'Else
                '    dblPayable = ((dblUnitPrice * intQty) - dblDiscounts) - dblTax
                '    dblSubTotal = ((dblUnitPrice * intQty) - dblDiscounts)
                'End If
                dblPayable = dblSubTotal + dblTax

                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO ProformaDetails ([ReferenceNumber], [Quantity], " _
                    & "[ItemCode], [Description], [UnitPrice], [Discount], [Tax], [Payable], [SubTotal], [EntryType]) VALUES " _
                    & "(" & CInt(txtReference.Text) & ", " & intQty & ", '" & strItmCode & "', '" & strDesc & "', " _
                    & "" & dblUnitPrice & ", " & dblDiscounts & ", " & dblTax & ", " & dblPayable & ", " & dblSubTotal & ", '" & strEntryType & "')", cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next
        'Update the controls table
        objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET Proforma = " & CDbl(txtReference.Text) & "", cnn)
        objCommand.ExecuteNonQuery()
        If MessageBox.Show("Proforma has been processed successfully. Do you want to print it now", _
                "Proforma Generation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            'Print the quotation
            boolPrinterAlreadySelected = False
            gwt_comm.PrintCustomerDocument(txtReference.Text, "PROFORMA")
        End If


        dGrid.Rows.Clear()
        dGrid.Rows.Add(100)
        lblDiscounts.Text = "0.00"
        lblPayable.Text = "0.00"
        lblSubTotal.Text = "0.00"
        lblTaxable.Text = "0.00"
        lblTaxes.Text = "0.00"

        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True

        'roll back the transaction
        Dim objDelete As New Data.OleDb.OleDbCommand("DELETE FROM ProformaMain WHERE ReferenceNumber = " & txtReference.Text, cnn)
        objDelete.ExecuteNonQuery()
        objDelete = New Data.OleDb.OleDbCommand("DELETE FROM ProformaDetails WHERE ReferenceNumber = " & txtReference.Text, cnn)
        objDelete.ExecuteNonQuery()

        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Proforma Generation Error"
        ShowErrorMessage()
    End Sub

    Private Sub LoadProformaDetails()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM ProformaMain WHERE ReferenceNumber = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            txtReference.Text = intSelectedTransaction
            If Not IsDBNull(objReader("CustomerName").ToString) Then txtAccountName.Text = objReader("CustomerName").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("ContactNumber").ToString) Then txtContactNumber.Text = objReader("ContactNumber").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("TaxNumber").ToString) Then txtTaxNumber.Text = objReader("TaxNumber").ToString
            If Not IsDBNull(objReader("SalesAgent").ToString) Then cboPersonnel.Text = objReader("SalesAgent").ToString
            If IsDate(objReader("TransDate").ToString) Then dpDateOn.Value = CDate(objReader("TransDate").ToString)
            If Not IsDBNull(objReader("Terms").ToString) Then txtTerms.Text = objReader("Terms").ToString

            If Not IsDBNull(objReader("CustomerAccountNumber").ToString) Then
                txtAccountNumber.Text = objReader("CustomerAccountNumber").ToString
                'Get the account holder details
                objCommand = New Data.OleDb.OleDbCommand("SELECT Address1, Address2, Address3, Address4, EmailAddress, " _
                    & "AccountName FROM Customers WHERE AccountNumber = '" & txtAccountNumber.Text & "'", cnn)
                Dim objReaderAccount As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReaderAccount.HasRows Then
                    objReaderAccount.Read()
                    If Not IsDBNull(objReaderAccount(0).ToString) Then txtAddress1.Text = objReaderAccount(0).ToString
                    If Not IsDBNull(objReaderAccount(1).ToString) Then txtAddress2.Text = objReaderAccount(1).ToString
                    If Not IsDBNull(objReaderAccount(2).ToString) Then txtAddress3.Text = objReaderAccount(2).ToString
                    If Not IsDBNull(objReaderAccount(3).ToString) Then txtAddress4.Text = objReaderAccount(3).ToString
                    If Not IsDBNull(objReaderAccount(4).ToString) Then txtEmailAddress.Text = objReaderAccount(4).ToString
                    If Not IsDBNull(objReaderAccount(5).ToString) Then txtAccountName.Text = UCase(objReaderAccount(5).ToString)
                End If
                objReaderAccount.Close()
            End If

            If Not IsDBNull(objReader("IsCustomerStatus").ToString) Then
                If UCase(objReader("IsCustomerStatus").ToString) = "YES" Then chkCustomerStatus.Checked = True Else chkCustomerStatus.Checked = False
            End If

        End If
        objReader.Close()
        objCommand = New Data.OleDb.OleDbCommand("SELECT ItemCode, Quantity, UnitPrice, EntryType, " _
            & "Description, Tax, Discount, Payable, SubTotal FROM ProformaDetails WHERE " _
            & "ReferenceNumber = " & intSelectedTransaction & "", cnn)
        objReader = objCommand.ExecuteReader
        Dim i As Integer = 0
        While objReader.Read
            'objReader.Read()
            With dGrid
                If Not IsDBNull(objReader("EntryType").ToString) Then .Rows(i).Cells(9).Value = objReader("EntryType").ToString
                If Not IsDBNull(objReader("Quantity").ToString) Then .Rows(i).Cells(4).Value = objReader("Quantity").ToString
                If Not IsDBNull(objReader("ItemCode").ToString) Then .Rows(i).Cells(0).Value = objReader("ItemCode").ToString
                If Not IsDBNull(objReader("Description").ToString) Then .Rows(i).Cells(1).Value = objReader("Description").ToString
                If IsNumeric(objReader("UnitPrice").ToString) Then .Rows(i).Cells(3).Value = Format(CDbl(objReader("UnitPrice").ToString), "##0.00")
                If IsNumeric(objReader("Discount").ToString) Then .Rows(i).Cells(6).Value = Format(CDbl(objReader("Discount").ToString), "##0.00")
                If IsNumeric(objReader("Tax").ToString) Then .Rows(i).Cells(7).Value = Format(CDbl(objReader("Tax").ToString), "##0.00")
                If IsNumeric(objReader("Payable").ToString) Then .Rows(i).Cells(8).Value = Format(CDbl(objReader("Payable").ToString), "##0.00")
                If IsNumeric(objReader("SubTotal").ToString) Then .Rows(i).Cells(5).Value = Format(CDbl(objReader("SubTotal").ToString), "##0.00")

                'Recompute totals

                Dim dblColumn3 As Double = 0
                Dim dblColumn4 As Double = 0
                Dim dblColumn6 As Double = 0
                Dim dblColumn7 As Double = 0

                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "") Then
                    If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                        dblColumn3 = CDbl(dGrid.Rows(i).Cells(3).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "") Then
                    If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                        dblColumn4 = CDbl(dGrid.Rows(i).Cells(4).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(6).Value), "") Then
                    If IsNumeric(dGrid.Rows(i).Cells(6).Value.ToString) Then
                        dblColumn6 = CDbl(dGrid.Rows(i).Cells(6).Value.ToString)
                    End If
                End If

                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "") Then
                    If IsNumeric(dGrid.Rows(i).Cells(7).Value.ToString) Then
                        dblColumn7 = CDbl(dGrid.Rows(i).Cells(7).Value.ToString)
                    End If
                End If

                ' ComputeValues(dblColumn3, dblColumn4, i, dblColumn6, dblSalesTaxRate)

                dGrid.Rows(i).Cells(4).Value = Format(dblColumn4, "##0.00")

                'End total recomputation

                i = i + 1

            End With
        End While
        objReader.Close()
        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Proforma Generation Error"
        ShowErrorMessage()
    End Sub

    Private Sub txtEmailAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailAddress.KeyPress
        If Asc(e.KeyChar) = 13 Then txtTaxNumber.Focus()
    End Sub

    Private Sub txtEmailAddress_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEmailAddress.Validating
        If Not String.IsNullOrEmpty(txtEmailAddress.Text) Then
            If gwt_comm.IsEmailAddress(txtEmailAddress.Text) = False Then
                MessageBox.Show("Invalid email address", "Invalid Email Adrress", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtEmailAddress.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvert.Click
        If IntPublicInvoicing <> 2 Then
            Dim frmErr As New frmDenyAcces
            frmErr.ShowDialog()
            Exit Sub
        End If
        boolAbort = False
        strSelectedAccountName = txtAccountName.Text
        strSelectedAccount = txtAccountNumber.Text
        strPublicDeliverAddress1 = txtAddress1.Text
        strPublicDeliverAddress2 = txtAddress2.Text
        strPublicDeliverAddress3 = txtAddress3.Text
        strPublicDeliverAddress4 = txtAddress4.Text

        If String.IsNullOrEmpty(txtAccountNumber.Text) Then
            If MessageBox.Show("It looks like this is a new customer. Do you want to create" & vbCrLf & _
                "the customer profile first before conversion to invoices", "New Account", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim boolPriorStatus As Boolean = boolEditStatus
                boolEditStatus = False
                Dim f As New frmCustomerDetails
                f.ShowDialog()
                boolEditStatus = boolPriorStatus
            Else
                MessageBox.Show("The process cannot carry on without first creating customer details", "Process Discontinued", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim frm As New frmDocumentConversion
        frm.ShowDialog()

        strSelectedAccountName = Nothing
        strSelectedAccount = Nothing
        strPublicDeliverAddress1 = Nothing
        strPublicDeliverAddress2 = Nothing
        strPublicDeliverAddress3 = Nothing
        strPublicDeliverAddress4 = Nothing
        If boolAbort = True Then Exit Sub
        intPublicConvertedDocumentNumber = CStr(gwt_comm.GetNextDocumentNumber("Proforma"))
        gwt_comm.SaveConvertedInvoice(dGrid, txtTerms.Text, cboPersonnel.Text, CDbl(lblPayable.Text), dtSetDate, CDbl(lblTaxes.Text))
    End Sub

    Private Sub chkCustomerStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCustomerStatus.CheckedChanged
        If chkCustomerStatus.Checked Then
            txtAccountName.ReadOnly = True
            btnFind.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True
        Else
            txtAccountName.ReadOnly = False
            btnFind.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False
            If Not String.IsNullOrEmpty(txtAccountNumber.Text) Then
                txtAccountName.Clear()
                txtAccountNumber.Text = ""
            End If
        End If
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        strPublicItemCode = Nothing
        strPublicItemDescription = Nothing
        boolAbort = False
        Dim f As New frmBrowseDebtors
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        txtAccountNumber.Text = strPublicItemCode
        txtAccountName.Text = strPublicItemDescription
        chkCustomerStatus.Checked = True
        'Get the selected customer details
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Address1, Address2, Address3, Address4, EmailAddress " _
            & "FROM Customers WHERE AccountNumber = '" & txtAccountNumber.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtAddress1.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtAddress2.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then txtAddress3.Text = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then txtAddress4.Text = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then txtEmailAddress.Text = objReader(4).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub txtAddress1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress1.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAddress2.Focus()
    End Sub

    Private Sub txtAddress2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress2.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAddress3.Focus()
    End Sub

    Private Sub txtAddress3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress3.KeyPress
        If Asc(e.KeyChar) = 13 Then txtAddress4.Focus()
    End Sub

    Private Sub txtAddress4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress4.KeyPress
        If Asc(e.KeyChar) = 13 Then txtContactNumber.Focus()
    End Sub

    Private Sub txtContactNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then txtEmailAddress.Focus()
    End Sub

    Private Sub txtTaxNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTaxNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            dGrid.Focus()
            dGrid.FirstDisplayedCell = dGrid.Rows(0).Cells(0)
            dGrid.FirstDisplayedCell.Selected = True
        End If
    End Sub

    Private Sub frmQuotation_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Width = 853
        Me.Height = 663
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

    End Sub

End Class