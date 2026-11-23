Imports System.Drawing.Printing
Imports ComponentFactory.Krypton.Toolkit
Imports System.Transactions
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmGatePasses

    Dim strSelectedReport As String
    Dim strType As String
    Dim arrPrintDetails As ArrayList
    Dim arrDeliveryDetails As ArrayList

    Dim strCustomerDetails As String
    Dim strInvoiceDetails As ArrayList
    Dim rsInvoiceTotals As String

    Dim dblInvoiceTotal As Double
    Dim dblTaxes As Double
    Dim dblDiscounts As Double
    Dim i As Double = 0
    Dim strvalue As String
    Dim strDate As Date
    Dim itm As Double
    Dim boolPrintFromPreview As Boolean
    Dim intPaymentReceiptNumber As Double
    Dim strCustomerAccountNumberPayments As String

    Dim strCustomerName As String
    Dim strCustomerAddress As String
    Dim strCustomerTelephone As String
    Dim strCustomerFaxNumber As String
    Dim strCustomerVatNumber As String
    Dim strCustomerEmailAddress As String

    Dim boolExitingWhile As Boolean = False
    Dim intPage As Single = 1
    Dim intPageTotals As Double = 1

    Dim strItemType As String = Nothing

    Dim dblRunningDiscounts As Double
    Dim dblRunningGross As Double
    Dim dblRunningTaxes As Double

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter

        intTotalSerialNumbersSelected = 0
        Dim intResetRowIndex As Integer = 0

        If dGrid.CurrentCell.ColumnIndex = 2 Then
            strSerialNumberForTransfer = Nothing
            Dim intRow As Double = dGrid.CurrentCell.RowIndex
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(0).Value), "")) Then
                strPublicItemCode = dGrid.CurrentRow.Cells(0).Value.ToString

                Dim boolIsGeneric As Boolean = True

                Dim objGenTest As New Data.OleDb.OleDbCommand("SELECT InventoryType FROM InventoryItems " _
                    & "WHERE ItemCode = '" & strPublicItemCode & "'", cnn)
                Dim objReadTest As Data.OleDb.OleDbDataReader = objGenTest.ExecuteReader
                If objReadTest.HasRows Then
                    objReadTest.Read()
                    If Not IsDBNull(objReadTest(0).ToString) Then
                        If UCase(objReadTest(0).ToString) = "SPECIFIC" Then boolIsGeneric = False
                    End If
                End If
                objReadTest.Close()

                If boolIsGeneric = False Then
                    boolAbort = False
                    boolMultiSelect = True
                    Dim f As New frmSalesSerialNumbers
                    f.ShowDialog()
                    boolMultiSelect = False
                    If boolAbort = True Then Exit Sub

                    For j As Integer = 0 To arrSelectedExitPassSerialNumbers.Count - 1
                        If isItemAlreadyAdded(dGrid.CurrentRow.Cells(0).Value.ToString, strSerialNumberForTransfer) = True Then
                            ''MessageBox.Show("Item cannot be added to transfer multiple time",
                            ''    "Process Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            ''For p As Integer = 0 To dGrid.Columns.Count - 1
                            ''    If p = 3 Then
                            ''        'do nothing 
                            ''    Else
                            ''        dGrid.CurrentRow.Cells(p).Value = Nothing
                            ''    End If
                            ''Next

                        Else
                            'RecalculateAmount()
                            ''Exit Sub
                            If j > 0 Then
                                dGrid.Rows(intRow + j).Cells(0).Value = dGrid.Rows(intRow + (j - 1)).Cells(0).Value
                                dGrid.Rows(intRow + j).Cells(1).Value = dGrid.Rows(intRow + (j - 1)).Cells(1).Value
                            End If
                            dGrid.Rows(intRow + j).Cells(2).Value = arrSelectedExitPassSerialNumbers.Item(j).ToString ' strSerialNumberForTransfer ' arrSelectedSerialNumbers.Item(0)
                            dGrid.Rows(intRow + j).Cells(5).Value = "1"
                        End If
                    Next j
                    intResetRowIndex = intRow + arrSelectedExitPassSerialNumbers.Count
                Else
                    dGrid.CurrentRow.Cells(2).Value = strSerialNumberForTransfer ' arrSelectedSerialNumbers.Item(0)
                    dGrid.CurrentRow.Cells(5).Value = "1"
                End If
                'dGrid.CurrentCell.ColumnIndex = 0
                'dGrid.Rows(intResetRowIndex).Cells(0)
            End If
        End If
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

    Private Sub frmGatePasses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = False Then
            txtOriginator.Text = UCase(strUserName)
        End If
        With Me.dGrid
            .Rows.Add(150)
        End With
        'LoadData()
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
        If boolEditStatus = True Then
            LoadSavedData()
        End If

        dGrid.Focus()
        dGrid.CurrentCell = dGrid.Rows(0).Cells(0)
        dGrid.Rows(0).Cells(0).Selected = True
        dGrid.BeginEdit(False)

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadSavedData()
        'intSelectedTransaction
        On Error GoTo RaiseErr
        txtReference.Text = CStr(intSelectedTransaction)
        Dim strSql As String = "SELECT  ItemCode, Description, Quantity, " _
            & "ProductType, SerialNumber FROM GatePasses WHERE PassNumber = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim n As Integer = 0
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(n).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(n).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(4).ToString) Then dGrid.Rows(n).Cells(2).Value = objReader(4).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGrid.Rows(n).Cells(5).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dGrid.Rows(n).Cells(6).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then dGrid.Rows(n).Cells(7).Value = objReader(4).ToString
            n = n + 1
        End While
        objReader.Close()

        'Get the Notes and the collecting agent details
        strSql = "SELECT Comment, CollectingAgent, PassType, TransDate, UserName FROM GatePassesMain WHERE PassNumber = " & intSelectedTransaction & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtNotes.Text = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then cboPersonnel.Text = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then cboPurpose.Text = objReader(2).ToString
            If IsDate(objReader(3).ToString) Then dpTransDate.Value = CDate(objReader(3).ToString)
            If Not IsDBNull(objReader(4).ToString) Then txtOriginator.Text = objReader(4).ToString
        End If
        objReader.Close()

        'cboItems.Visible = False
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmGatePasses_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F3 Then
            FinishProcess()
        End If
        If e.KeyValue = Keys.F9 Then
            If dGrid.Rows.Count > 0 Then
                dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
            End If
        End If
        If e.KeyValue = Keys.F10 Then
            Me.Close()
            'End
        End If
    End Sub

    Private Sub CheckSerialNumberEntry(ByVal ItemCode As String, ByVal SerialNumber As String)
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT InventoryType FROM InventoryItems WHERE ItemCode = '" & ItemCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim intQty As Double = 0
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If UCase(objReader(0).ToString) = "SPECIFIC" Then
                    If String.IsNullOrEmpty(SerialNumber) Then
                        MessageBox.Show("Please enter the serial number for item code " & ItemCode, _
                            "Missing Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        boolAbort = True
                    End If
                End If
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Serial Number Check"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub checkAvailability(ByVal ItemCode As String)
        On Error GoTo RaiseErr
        If strIgnoreZeroQuantity = "YES" Then Exit Sub
        If String.IsNullOrEmpty(ItemCode) Then Exit Sub
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & ItemCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim intQty As Double = 0
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intQty = CDbl(objReader(0).ToString)
        End If
        objReader.Close()
        If intQty <= 0 Then
            MessageBox.Show("This item is not available in stock", _
                "Item Not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            boolAbort = True
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Item Quantity Check"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub CommitValueChanged()
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand
        For z As Integer = 0 To dGrid.Columns.Count - 1
            If z <> 3 Then dGrid.CurrentRow.Cells(z).Value = Nothing
        Next

        If Not String.IsNullOrEmpty(strFullItemDetails) Then

            Dim strSplitValues() As String = Split(strFullItemDetails, ";")

            dGrid.CurrentRow.Cells(0).Value = UCase(strSplitValues(0))
            dGrid.CurrentRow.Cells(1).Value = UCase(strSplitValues(1))
            dGrid.CurrentRow.Cells(4).Value = UCase(strSplitValues(2))
            dGrid.CurrentRow.Cells(2).Value = ""
            dGrid.CurrentRow.Cells(5).Value = "1"

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
        Else
            dGrid.CurrentRow.Cells(0).Value = Nothing
            dGrid.CurrentRow.Cells(1).Value = Nothing
            dGrid.CurrentRow.Cells(4).Value = Nothing
            dGrid.CurrentRow.Cells(5).Value = Nothing
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Item Selection"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellValidated
        If dGrid.CurrentCell.ColumnIndex = 5 Or dGrid.CurrentCell.ColumnIndex = 7 Then
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value), "")) Then
                If Not IsNumeric(dGrid.CurrentCell.Value) Then
                    MessageBox.Show("Invalid Non Numeric Value Detected. Cell value defaulted to 0", _
                        "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGrid.CurrentCell.Value = "0"
                    'ComputeValues(CDbl(dGrid.CurrentRow.Cells(4).Value.ToString), CDbl(dGrid.CurrentRow.Cells(5).Value.ToString), dGrid.CurrentRow.Index, CDbl(dGrid.CurrentRow.Cells(7).Value.ToString), 0)
                    Exit Sub
                Else
                    'ComputeValues(CDbl(dGrid.CurrentRow.Cells(4).Value.ToString), CDbl(dGrid.CurrentRow.Cells(5).Value.ToString), dGrid.CurrentRow.Index, CDbl(dGrid.CurrentRow.Cells(7).Value.ToString), 0)
                End If
            End If
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If IntPublicGatePasses <> 2 Then
            boolAbort = False
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If dGrid.Rows.Count > 0 Then
            dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
        End If
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        If IntPublicGatePasses <> 2 Then
            boolAbort = False
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        intPage = 1
        boolAbort = False
        Dim f As New frmGatePassPrintOptions
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        FinishProcess()
    End Sub

    Private Sub FinishProcess()

        Dim strSqlTransmit As String = Nothing
        Dim strSelectedId As String
        Dim strDescription As String
        Dim intQty As Double
        Dim dblUprice As Double
        Dim insertCustomer As String
        Dim dblTax As Double
        Dim i As Double
        Dim dpProcessDate As String = CStr(shortMonthDateFormat(DateTime.Now))
        Dim dblDisAmount As Double 'for discounts
        Dim dblSumTaxes As Double = 0, dblSumDiscounts As Double = 0, dblSumPayable As Double = 0
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim dbReader As Data.OleDb.OleDbDataReader

        dblRunningDiscounts = 0
        dblRunningGross = 0
        dblRunningTaxes = 0

        arrDeliveryDetails = New ArrayList

        If String.IsNullOrEmpty(cboPersonnel.Text) Then
            MessageBox.Show("Please select the name of the person collecting the items", _
                "Missing Personnel Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPersonnel.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboPurpose.Text) Then
            MessageBox.Show("Please select the purpose", _
                "Missing Purpose", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPurpose.Focus()
            Exit Sub
        End If

        Dim strPassType As String = UCase(cboPurpose.Text)

        dblAmountTendered = 0
        dblAmountChange = 0

        If dGrid.Rows.Count <= 0 Then
            MessageBox.Show("No document transactions to print !!!", _
                "Empty Document Transactions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboPersonnel.Text) Then
            MessageBox.Show("Please select the name of the sales representative from the list provided", _
                "Missing Sales Agent Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPersonnel.Focus()
            Exit Sub
        End If

        If boolEditStatus = True Then

            Using tran As IDbTransaction = cnn.BeginTransaction()
                Try
                    ' transactional code...
                    Dim objDelete As New Data.OleDb.OleDbCommand("DELETE FROM GatePasses WHERE PassNumber = " & intSelectedTransaction & "", cnn)
                    objDelete.ExecuteNonQuery()
                    objDelete = New Data.OleDb.OleDbCommand("DELETE FROM GatePassesMain WHERE PassNumber = " & intSelectedTransaction & "", cnn)
                    objDelete.ExecuteNonQuery()
                    tran.Commit()
                Catch ex As Exception
                    tran.Rollback()
                    Cursor = Cursors.Default
                    boolAbort = True
                    strErrorMessages = ex.Message & vbCrLf & "On Gate Pass Transaction Processing"
                    gwt_comm.ShowErrorMessage()
                End Try
            End Using
        End If

        boolAbort = False

        For i = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                Dim strItemSerialTest As String = Nothing
                Dim strSelectedIdTest As String = Nothing
                strSelectedIdTest = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                    strItemSerialTest = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
                End If
                'Validate the serial number entry
                boolAbort = False
                CheckSerialNumberEntry(strSelectedIdTest, strItemSerialTest)
                If boolAbort = True Then Exit Sub
            End If
        Next i

        'On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        If boolEditStatus = True Then
            txtReference.Text = intSelectedTransaction
        Else
            'CInt(GetNextDocumentNumber("GatePass"))
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("GatePass"))
        End If

        If chkOverideDate.Checked = True Then
            dpProcessDate = CStr(shortMonthDateFormat(dpTransDate.Value))
        End If

        Cursor = Cursors.WaitCursor

        Dim arrSqlItems As New ArrayList

        'For the gate pass number get the actual

        Dim intNextRefNo As Integer = 1
        'GatePassesMain (PassNumber
        Dim objRefNumber As New Data.OleDb.OleDbCommand("SELECT DISTINCT(PassNumber) FROM GatePassesMain ORDER BY PassNumber DESC", cnn)
        Dim objReadRef As Data.OleDb.OleDbDataReader = objRefNumber.ExecuteReader
        If objReadRef.HasRows Then
            objReadRef.Read()
            If IsNumeric(objReadRef(0).ToString) Then intNextRefNo = CInt(objReadRef(0).ToString) + 1
        End If
        objReadRef.Close()

        txtReference.Text = intNextRefNo

        Try

            For i = 0 To dGrid.Rows.Count - 1

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then

                    Dim strItemSerialNo As String = Nothing
                    Dim strLineItemType As String = Nothing
                    strSelectedId = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                    strDescription = Convert.ToString(dGrid.Rows(i).Cells(1).Value)

                    If Not Object.Equals(dGrid.Rows(i).Cells(5).Value, Nothing) Then
                        If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                            intQty = Convert.ToDouble(dGrid.Rows(i).Cells(5).Value)
                        End If
                    End If


                    If Not Object.Equals(dGrid.Rows(i).Cells(4).Value, Nothing) Then
                        If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                            dblUprice = Convert.ToDouble(dGrid.Rows(i).Cells(4).Value)
                        End If
                    End If
                    'dblTax = Convert.ToDouble(dGrid.Rows(i).Cells(8).Value)

                    'dblDisAmount = Convert.ToDouble(dGrid.Rows(i).Cells(7).Value)
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                        strItemSerialNo = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
                    End If
                    If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(6).Value), "")) Then
                        strLineItemType = Convert.ToString(dGrid.Rows(i).Cells(6).Value)
                    End If

                    insertCustomer = "INSERT INTO GatePasses (PassNumber, TransDate, ItemCode, Quantity, " _
                        & "Description, ProductType, SerialNumber, UserName, CollectingAgent, Branch, PassType) VALUES " _
                        & "(" & CDbl(txtReference.Text) & ", '" & dpProcessDate & "', " _
                        & "'" & strSelectedId & "', " & intQty & ", " _
                        & "'" & strDescription & "', '" & strLineItemType & "', " _
                        & "'" & strItemSerialNo & "', '" & strUserName & "', '" & cboPersonnel.Text & "', '" & strUserBranch & "', '" & strPassType & "')"

                    arrSqlItems.Add(insertCustomer)

                    'Update the products table
                    Dim intStockBalance As Double = 0
                    myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & strSelectedId & "'", cnn)
                    dbReader = myCommand.ExecuteReader
                    If dbReader.HasRows Then
                        dbReader.Read()
                        If IsNumeric(dbReader(0).ToString) Then intStockBalance = CDbl(dbReader(0).ToString) Else intStockBalance = 0
                    Else
                        intStockBalance = 0
                    End If
                    dbReader.Close()
                    intStockBalance = intStockBalance - CDbl(dGrid.Rows(i).Cells(5).Value)

                    Dim strUpdateQuantity As String = "UPDATE InventoryItems SET Quantity = " & intStockBalance & " WHERE ItemCode = '" & strSelectedId & "'"
                    arrSqlItems.Add(strUpdateQuantity)

                    'Update the table for serial numbers
                    If Not String.IsNullOrEmpty(strItemSerialNo) Then
                        Dim strDeleteSerial As String = "DELETE FROM SerialNumbers WHERE ItemCode = '" & strSelectedId & "' AND SerialNumber = '" & strItemSerialNo & "'"
                        arrSqlItems.Add(strDeleteSerial)
                    End If

                    'If this is a delivery, write the details to the customer orders table
                    Dim strSqlInsert As String = "INSERT INTO CustomerDeliveries (PassNumber, TransDate, ItemCode, Quantity, " _
                        & "Description, ProductType, SerialNumber, UserName, CollectingAgent, Branch, Purpose) VALUES " _
                        & "(" & CDbl(txtReference.Text) & ", '" & dpProcessDate & "', " _
                        & "'" & strSelectedId & "', " & intQty & ", " _
                        & "'" & strDescription & "', '" & strLineItemType & "', " _
                        & "'" & strItemSerialNo & "', '" & strUserName & "', '" & cboPersonnel.Text & "', " _
                        & "'" & strUserBranch & "', '" & strPassType & "')"
                    arrSqlItems.Add(strSqlInsert)

                End If

            Next i

            'Add the record to the gate pass main
            If arrSqlItems.Count > 0 Then

                'Assign the document number based on the actual records

                'Dim [option] = New TransactionOptions With {.IsolationLevel = IsolationLevel.ReadCommitted, .Timeout = TimeSpan.FromSeconds(60)}
                'Using scopeOuter = New TransactionScope(TransactionScopeOption.Required, [option])
                myCommand = New Data.OleDb.OleDbCommand("INSERT INTO GatePassesMain (PassNumber, " _
                    & "TransDate, UserName, Branch, Comment, CollectingAgent, PassType) VALUES " _
                    & "(" & Convert.ToDouble(txtReference.Text) & ", '" & dpProcessDate & "', " _
                    & "'" & strUserName & "', '" & strUserBranch & "', '" & txtNotes.Text & "', " _
                    & "'" & cboPersonnel.Text & "', '" & strPassType & "')", cnn)
                myCommand.ExecuteNonQuery()
                'Using scopeInner = New TransactionScope(TransactionScopeOption.Required, [option])
                For intItems As Integer = 0 To arrSqlItems.Count - 1
                    myCommand = New Data.OleDb.OleDbCommand(arrSqlItems.Item(intItems), cnn)
                    myCommand.ExecuteNonQuery()
                Next
                'scopeInner.Complete()
                'End Using

                'Update the control numbers table
                Dim intNewInvoiceNumber As Double = CDbl(txtReference.Text)
                myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET GatePass = " & CDbl(txtReference.Text) & "", cnn)
                myCommand.ExecuteNonQuery()

                'scopeOuter.Complete()
                'End Using

            End If


            strPublicCustomerId = "0000"

            itm = 0

            PrintInvoice(dpProcessDate)

            MessageBox.Show("Gate Pass generated successfully.", "Gate Pass Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Clear the controls
            dGrid.Rows.Clear()
            dGrid.Rows.Add(50)
            cboPersonnel.Text = ""
            txtReference.Text = ""
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("GatePass"))
            dpTransDate.Enabled = False
            chkOverideDate.Checked = False
            dblAmountChange = 0
            Me.Close()

        Catch ex As Exception

            'tran.ROLLBACK
            Cursor = Cursors.Default
            boolAbort = True
            strErrorMessages = ex.Message & vbCrLf & "On Gate Pass Transaction Processing"
            Dim TestPos As Long = InStr(1, strErrorMessages, "Violation of PRIMARY KEY", CompareMethod.Text)
            If TestPos > 0 Then
                strErrorMessages = "This record will create a duplicate reference number. " _
                    & "You can correct this data corruption by going to NAVIGATE >> SETTINGS >> CONTROL NUMBERS. " _
                    & "In the exit passes number, enter a number higher than the currently displayed and then re-try this process"
            End If
            gwt_comm.ShowErrorMessage()

        End Try

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

    Private Sub PrintInvoice(ByVal dtReceiptDate As Date)
        On Error GoTo RaiseErr
        strType = "INVENTORY GATE PASS"
        strSelectedReport = Me.txtReference.Text

        arrPrintDetails = New ArrayList

        dblRunningDiscounts = 0
        dblRunningGross = 0
        dblRunningTaxes = 0

        With dGrid
            For i As Double = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    Dim strSerial As String = Nothing
                    Dim strItemCode As String = dGrid.Rows(i).Cells(0).Value.ToString
                    If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "")) Then
                        strSerial = Convert.ToString(.Rows(i).Cells(2).Value)
                        If strSerial.Length > 30 Then
                            strSerial = Mid(strSerial, 1, 30) & vbCrLf & Mid(strSerial, 31, strSerial.Length)
                        End If
                    End If

                    Dim strDescription As String = .Rows(i).Cells(1).Value.ToString
                    Dim strQuantity As String = .Rows(i).Cells(5).Value.ToString
                    'Dim strUnitPrice As String = Format(CDbl(.Rows(i).Cells(4).Value.ToString), "#,##0.00")
                    If strDescription.Length > 30 Then strDescription = Mid(strDescription, 1, 32)

                    'arrPrintDetails.Add(Space(2) & strDescription)
                    If UCase(strGataPassPrintOptions) = "PASS" Then
                        arrPrintDetails.Add(strQuantity & "|" & strDescription & "|" & strSerial & "|" & strItemCode)
                    Else
                        arrPrintDetails.Add(strQuantity & "|" & strDescription & "|" & strSerial & "|" & strItemCode)

                        'Get the item selling price
                        Dim objGetPrice As Data.OleDb.OleDbCommand
                        Dim strSqlPrice As String = Nothing

                        If UCase(strTaxComputationType) = "INCLUSIVE" Then
                            'strSqlPrice = "SELECT (SellingPrice * " & CDbl(strQuantity) & ") - ((SellingPrice * " & CDbl(strQuantity) & " * (100 / (100 + " & dblSalesTaxRate & ")))) AS [Cost], (SellingPrice * " & CDbl(strQuantity) & ") - (((SellingPrice * " & CDbl(strQuantity) & " * (100 / (100 + " & dblSalesTaxRate & ")))) AS [Tax] FROM InventoryItems WHERE ItemCode = '" & strItemCode & "'"
                            strSqlPrice = "SELECT (((SellingPrice * " & CDbl(strQuantity) & ") * 100/(100 + " & dblSalesTaxRate & "))) AS [Cost], (SellingPrice * " & CDbl(strQuantity) & ") - (((SellingPrice * " & CDbl(strQuantity) & ") * 100/(100 + " & dblSalesTaxRate & "))) AS [Tax] FROM InventoryItems WHERE ItemCode = '" & strItemCode & "'"
                        Else
                            strSqlPrice = "SELECT (SellingPrice * " & CDbl(strQuantity) & ") AS [Cost], (SellingPrice * " & CDbl(strQuantity) & " * " & dblSalesTaxRate & ")/100 AS [TAX] FROM InventoryItems WHERE ItemCode = '" & strItemCode & "'"
                        End If

                        objGetPrice = New Data.OleDb.OleDbCommand(strSqlPrice, cnn)

                        Dim objReadPrice As Data.OleDb.OleDbDataReader = objGetPrice.ExecuteReader
                        Dim dblSellingPrice As Double = 0
                        Dim dblTaxCharges As Double = 0
                        If objReadPrice.HasRows Then
                            objReadPrice.Read()
                            If IsNumeric(objReadPrice(0).ToString) Then dblSellingPrice = CDbl(objReadPrice(0).ToString)
                            If IsNumeric(objReadPrice(1).ToString) Then dblTaxCharges = CDbl(objReadPrice(1).ToString)
                            dblRunningDiscounts = dblRunningDiscounts + 0
                            dblRunningGross = dblRunningGross + dblSellingPrice
                            dblRunningTaxes = dblRunningTaxes + dblTaxCharges
                        End If
                        objReadPrice.Close()
                        arrDeliveryDetails.Add(strQuantity & "|" & strDescription & "|" & strSerial & "|" & Format(dblSellingPrice, "##0.00") & "|" & Format(dblTaxCharges, "##0.00") & "|" & Format((dblSellingPrice + dblTaxCharges), "##0.00"))
                    End If

                End If
            Next
        End With

        ' Allow the user to select a file.

        If UCase(strGataPassPrintOptions) = "PASS" Then
            If strRequestForReceiptPrinter = "YES" Then
                boolAbort = False
                gwt_comm.PrinterSelection()
                If boolAbort = True Then Exit Sub
                pdWindows.PrinterSettings.PrinterName = strSessionPrinter
            End If
            PrintPreviewDialog1.Document = pdWindows
            PrintPreviewDialog1.ShowDialog()
        End If
        If UCase(strGataPassPrintOptions) = "DELIVERY" Then
            GenerateDocument()
        End If
        If UCase(strGataPassPrintOptions) = "BOTH" Then
            If strRequestForReceiptPrinter = "YES" Then
                boolAbort = False
                gwt_comm.PrinterSelection()
                If boolAbort = True Then Exit Sub
                pdWindows.PrinterSettings.PrinterName = strSessionPrinter
            End If
            PrintPreviewDialog1.Document = pdWindows
            PrintPreviewDialog1.ShowDialog()
            'Print delivery note immediately
            GenerateDocument()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Gate Pass Processing"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub GenerateDocument()
        On Error GoTo RaiseErr

        Dim strPrintDetails(0 To arrDeliveryDetails.Count - 1) As String
        For i As Integer = 0 To arrDeliveryDetails.Count - 1
            strPrintDetails(i) = arrDeliveryDetails.Item(i)
        Next
        Dim docPrint As New DocumentWriter
        With docPrint
            .intNumberOfColumns = 6
            .intPrintRecordsCount = strPrintDetails.Length
            .strMainCaption = strGatePassHeader
            .CustomerName = strPublicCustomerName
            .CustomerAddress1 = strPublicDeliverAddress1
            .CustomerAddress2 = strPublicDeliverAddress2
            .CustomerAddress3 = strPublicDeliverAddress3
            .CustomerAddress4 = strPublicDeliverAddress4
            .CustomerTelephone = Nothing
            .CustomerEmailAddress = Nothing
            .CustomerVatNumber = Nothing
            .TaxesCharged = 0
            .DocumentTotal = 0
            .DiscountAllowed = 0
            .strColumnAlignments = "0|0|0|2|2|2"
            .PrintDate = gwt_comm.shortMonthDateFormat(dpTransDate.Value)
            .ReferenceNumber = txtReference.Text
            .SalesRep = cboPersonnel.Text
            .strPrintValues = strPrintDetails
            .strColumnHeaders = "QTY|DESCRIPTION|SERIAL NO.|UNIT PRICE|VAT|PAYABLE"
            .boolGenericReport = True
            .PrintBankingDetails = False
            .PrintSummaryTotals = True
            .DetailColor = Color.FromName("Black")
            .GridColor = Color.LightGray
            .strColumnWidths = "40|240|130|80|80|80"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO"
            'Remember to carter for the notes printing

            'If there are summry totals activate this code
            .strSummaryCaptions = "UNITS TOTAL|LESS DISCOUNTS|SUB TOTAL|ADD TAXES|NET PAYABLE"

            'Compute the totals

            Dim dblSubTotal As Double = dblRunningGross - dblRunningDiscounts
            Dim dblTotalPayable As Double = dblSubTotal + dblRunningTaxes

            .strSummaryValues = Format(dblRunningGross, "##0.00") & "|" & _
                Format(dblRunningDiscounts, "##0.00") & "|" & Format(dblSubTotal, "##0.00") & "|" & _
                Format(dblRunningTaxes, "##0.00") & "|" & Format(dblTotalPayable, "##0.00")
            .strSummaryAlignments = "2|2|2|2|2|2|2"

        End With

        If strRequestForReceiptPrinter = "YES" Then
            boolAbort = False
            gwt_comm.PrinterSelection()
            If boolAbort = True Then Exit Sub
            docPrint.PrinterSettings.PrinterName = strSessionPrinter
        End If
        PrintPreviewDialog1.Document = docPrint
        PrintPreviewDialog1.ShowDialog()

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Delivery Note Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        If Not String.IsNullOrEmpty(txtBarcode.Text) Then
            If Asc(e.KeyChar) = 13 Then
                e.Handled = True
                ProcessBarCode()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ProcessBarCode()

        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtBarcode.Text) Then Exit Sub

        'Get the current available line entry number
        'cboItems.Visible = False

        boolAbort = False
        Dim strValues() As String = gwt_comm.ReadBarcode(txtBarcode.Text)
        If boolAbort = True Then Exit Sub

        'The return array contains the item code, transactionid, Foundstatus, serial number

        If String.IsNullOrEmpty(strValues(0)) Then
            MessageBox.Show("Item barcode not found in the system", _
                "Invalid Item Bar Code", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim intActiveLine As Double = 0
        For i As Double = 0 To dGrid.Rows.Count - 1
            If (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                intActiveLine = i
                'Reset the cell values
                For z As Integer = 0 To dGrid.Columns.Count - 1
                    If z = 1 Or z = 4 Then
                        'do nothing 
                    Else
                        dGrid.Rows(intActiveLine).Cells(z).Value = Nothing
                    End If
                Next

                'RecalculateAmount()

                If UCase(strValues(4)) = "SPECIFIC" Then
                    If isItemAlreadyAdded(strValues(0), strValues(3)) = True Then
                        MessageBox.Show("Item cannot be added to transfer multiple time", _
                            "Process Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If

                Dim strSql As String = Nothing
                strSql = "SELECT ItemCode, GroupName, CONVERT(NVARCHAR, " _
                    & "CAST(SellingPrice AS DECIMAL (30,2))) AS [Price], TaxStatus, FullBarcodeSerialStatus " _
                    & "FROM InventoryItems WHERE ItemCode = '" & strValues(0) & "'"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(intActiveLine).Cells(0).Value = objReader(0).ToString
                    If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(intActiveLine).Cells(1).Value = objReader(1).ToString
                    If Not IsDBNull(objReader(2).ToString) Then dGrid.Rows(intActiveLine).Cells(4).Value = objReader(2).ToString

                    dGrid.Rows(intActiveLine).Cells(2).Value = strValues(3)
                    dGrid.Rows(intActiveLine).Cells(5).Value = "1"
                    dGrid.Rows(intActiveLine).Cells(7).Value = strValues(1)

                End If

                txtBarcode.Text = ""
                txtBarcode.Focus()
                Exit For
            End If
        Next
        txtBarcode.Clear()
        txtBarcode.Focus()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCritical & "Bar code fetch failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmScannedSales_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        panelMain.Refresh()
    End Sub

    Public Function isItemAlreadyAdded(ByVal ItemCode As String, ByVal SerialNumber As String) As Boolean
        Dim boolReturn As Boolean = False
        For i As Double = 0 To dGrid.Rows.Count - 1
            Dim strCode As String = Nothing
            Dim strSerial As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                strCode = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                strSerial = Convert.ToString(dGrid.Rows(i).Cells(2).Value)
            End If
            If UCase(strCode) = UCase(ItemCode) And UCase(strSerial) = UCase(SerialNumber) Then
                boolReturn = True
                Exit For
            End If
        Next
        Return boolReturn
    End Function

    Private Sub pdWindows_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdWindows.PrintPage

        If boolPrintFromPreview = True Then
            'requery records
            boolAbort = False
            itm = 0
            '''''''''---------------Me.GenerateTransactionDocument(CDbl(txtReference.Text))
            If boolAbort = True Then Exit Sub
            boolPrintFromPreview = False
        End If
        Dim strDType As String

        strDType = "GATE PASS"
        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer
        'Dim xx1 AS DOUBLE, xx2 AS DOUBLE, yy1 AS DOUBLE, yy2 AS DOUBLE
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

        'Print the watermark here
        'Dim g As Graphics = e.Graphics
        'g.TranslateTransform(200, 200)
        'g.RotateTransform(e.PageSettings.Landscape)
        'g.DrawString("DRAFT VERSION", New Font("Verdana", 75, FontStyle.Bold), New SolidBrush(Color.FromArgb(64, Color.Black)), 0, 0)

        'print the company logo
        Dim g As Graphics = e.Graphics
        g.DrawString("GATE PASS", New Font("Arial", 14, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, Color.Black)), 500, e.PageBounds.Top + 120)

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

        y1 = y1 + 30

        'Get the sales agent details
        'Print the company details at the extreme left of document

        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, fntHeaderFont, Brushes.Black)
        'e.Graphics.DrawString(strDType, HeaderFont, Brushes.Black, 500, e.PageBounds.Top + 120)
        y1 = y1 + 20
        Dim strAddressInfo As String = strCompanyAddress1 & vbCrLf & strCompanyAddress2 & vbCrLf & _
            strCompanyAddress3 & vbCrLf & strCompanyAddress4 & vbCrLf & "Tel No.:  " & strPublicBranchTelephone & "Fax : " _
            & strCompanyFaxNumber & vbCrLf & "Email   : " & strCompanyEmailAddress
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strAddressInfo, fntDetailsFont, Brushes.Black)

        'Get the size of the address box
        e.Graphics.MeasureString(strAddressInfo, fntDetailsFont, New SizeF(200, 80), New StringFormat(), cols, lines)
        Yc = y1
        y1 = y1 + lines * fntDetailsFont.Height + 5
        y1 = Math.Max(y1, Yc)

        'print captions
        x1 = x1 + 10
        x2 = x1 + 50
        X3 = x2 + 250
        X4 = X3 + 100
        X5 = X4 + 100
        X6 = X5 + 100

        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        e.Graphics.DrawString("PROCESSOR DETAILS", fntDetailsFontBold, Brushes.Black, x1, y1)
        e.Graphics.DrawString("TRANSACTION DETAILS", fntDetailsFontBold, Brushes.Black, 500, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 15

        'Print processor details
        e.Graphics.DrawString(UCase(txtOriginator.Text) & vbCrLf & UCase(strUserBranch), fntDetailsFontBold, Brushes.Black, x1, y1)
        'Print the date

        e.Graphics.DrawString("DATE : " & UCase(gwt_comm.shortMonthDateFormat(dpTransDate.Value)), fntDetailsFontBold, Brushes.Black, 500, y1)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "PASS NUMBER  : " & Format(CLng(txtReference.Text), "000000"), fntHeaderFont, Brushes.Black)
        y1 += 45

        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20

        'print captions
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 60, 80, "QTY", fntDetailsFontBold, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 250, 80, "DESCRIPTION", fntDetailsFontBold, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, X3, y1, 100, 80, "SERIAL NO", fntDetailsFontBold, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, X4 + 50, y1, 120, 80, "UNIT PRICE", fntDetailsFontBold, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, X5 + 60, y1, 120, 80, "TOTAL", fntDetailsFontBold, Brushes.Black)

        'draw a line after
        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 30

        reccurrent = New Rectangle()
        boolExitingWhile = False

        Dim intLineCounter As Integer = 0
        Dim strBuffer() As String

        Dim dblNoteTotal As Double = 0

        While itm < arrPrintDetails.Count 'arrPrintDetails.Count

            Dim dblQty As Double = 0

            strBuffer = Split(arrPrintDetails.Item(itm), "|")
            If Not strBuffer(0) Is Nothing Then strvalue = strBuffer(0) Else strvalue = "-"
            If IsNumeric(strvalue) Then
                dblQty = CDbl(strvalue)
            End If
            Call gwt_comm.DrawStringInBoxCenter(e, x1, y1, 50, 60, strvalue, fntDetailsFont, Brushes.Black)
            If Not strBuffer(1) Is Nothing Then strvalue = strBuffer(1) Else strvalue = " "
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 400, 80, strvalue, fntDetailsFont, Brushes.Black)
            If Not strBuffer(2) Is Nothing Then strvalue = strBuffer(2) Else strvalue = " "
            Call gwt_comm.DrawStringInBoxLeft(e, X3, y1, 120, 80, strvalue, fntDetailsFont, Brushes.Black)

            'Get the selling price
            strvalue = "0.00"
            Dim strSql As String = "SELECT SellingPrice FROM InventoryItems WHERE ItemCode = '" & strBuffer(3) & "'"
            Dim objComPrice As New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReadPrice As Data.OleDb.OleDbDataReader = objComPrice.ExecuteReader
            If objReadPrice.HasRows Then
                objReadPrice.Read()
                If IsNumeric(objReadPrice(0).ToString) Then
                    strvalue = CStr(Format(CDbl(objReadPrice(0).ToString), "##0.00"))
                End If
            End If
            Call gwt_comm.DrawStringInBoxRight(e, X4, y1, 100, 80, strvalue, fntDetailsFont, Brushes.Black)

            'Total price line
            Dim dblLineTotal As Double = 0
            If IsNumeric(strvalue) Then
                strvalue = Format((CDbl(strvalue) * dblQty), "##0.00")
                dblNoteTotal = dblNoteTotal + CDbl(strvalue)
            End If

            Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 100, 80, strvalue, fntDetailsFont, Brushes.Black)

            'Get the size of the address box based on the possible longest i.e. the description
            If Not strBuffer(1) Is Nothing Then strvalue = strBuffer(1) Else strvalue = " "
            e.Graphics.MeasureString(strvalue, fntDetailsFont, New SizeF(400, 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * fntDetailsFont.Height + 5
            y1 = Math.Max(y1, Yc)

            intLineCounter = intLineCounter + 1
            itm = itm + 1 : i = 0

            If intLineCounter = 35 Then
                'Print the page number of the statement
                Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", fntFooterFontItalic, Brushes.Black)
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
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 250, 80, "DELIVERY PASS TOTAL", fntDetailsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 100, 80, Format(dblNoteTotal, "##0.00"), fntDetailsFont, Brushes.Black)
            y1 = y1 + 30
            e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
            y1 = y1 + 30
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 550, 80, "NOTES : " & txtNotes.Text, fntDetailsFontBold, Brushes.Black)

            'Get the size of the address box based on the possible longest i.e. the description
            strvalue = "NOTES : " & txtNotes.Text
            e.Graphics.MeasureString(strvalue, fntFooterFontItalic, New SizeF(400, 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * fntFooterFontItalic.Height + 5
            y1 = Math.Max(y1, Yc)
            y1 = y1 + 30

            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 500, 60, "Authorised by ..........................................................", fntDetailsFont, Brushes.Black)
            y1 = y1 + 30
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 500, 60, "Approved by   ..........................................................", fntDetailsFont, Brushes.Black)
            y1 = y1 + 30
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 500, 60, "Collected by  ..........................................................", fntDetailsFont, Brushes.Black)

            'Print the page number of the statement
            Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, fntFooterFontItalic, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 350, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", fntFooterFontItalic, Brushes.Black)

            e.HasMorePages = False
            Me.boolPrintFromPreview = True

        End If

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        itm = 0
        strGataPassPrintOptions = "PASS"
        PrintInvoice(gwt_comm.shortMonthDateFormat(dpTransDate.Value))
    End Sub

    Private Sub dGrid_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGrid.KeyDown
        If e.KeyValue = 9 Then
            'frmCashoutItemTypes
            If dGrid.CurrentCell.ColumnIndex = 0 Then
                strPublicItemCode = Nothing
                strFullItemDetails = Nothing
                boolAbort = False
                gwt_comm.InventorySearch()
                If boolAbort = True Then Exit Sub
                CommitValueChanged()
                dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(1)
            End If
        End If
    End Sub

End Class