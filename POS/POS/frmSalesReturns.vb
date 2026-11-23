Imports System.Drawing.Printing
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSalesReturns

    Dim arrPrintDetails As ArrayList

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    '    Private Sub LoadData()
    '        On Error GoTo RaiseErr
    '        Dim strSalesData() As String = SalesInventoryItems(strMainCompanyServiceOffering, strDefaultSearchFilter)
    '        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSalesData(0), cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
    '        'Set up the drop down combo box
    '        With cboItems
    '            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
    '            .ColumnNum = 4
    '            .HighlightBorderOnMouseEvents = True
    '            .ManagingFastMouseMoving = True
    '            .Enabled = True
    '            .DropDownHeight = 110
    '            .GridLineHorizontal = True
    '            .GridLineVertical = True
    '            .ColumnWidth = "160;180;60;60"
    '        End With
    '        'Get a count of the items
    '        Dim intItemsCount As Integer = CDbl(strSalesData(1))
    '        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

    '        cboItems.Items.Clear()
    '        Dim i As Integer = 0
    '        Dim p As Integer = 0
    '        'Continue to read until you reach the end of the file.
    '        While objReader.Read
    '            'File the listview with details.
    '            If Not IsDBNull(objReader(0).ToString) Then
    '                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
    '                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2), strRecordText(3))
    '            End If
    '            p = p + 1
    '        End While
    '        objReader.Close()
    '        'Load the banks to the combo box
    '        If intItemsCount > 0 Then
    '            cboItems.SelectedIndex = -1
    '            cboItems.Items.Clear()
    '            cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
    '            cboItems.Items.AddRange(DropDownItems)
    '        End If
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
    '        ShowErrorMessage()
    '    End Sub

    Private Sub frmSalesReturns_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'LoadData()
        txtReturnNumber.Text = CStr(gwt_comm.GetNextDocumentNumber("ItemReturns"))
    End Sub

    Private Sub cboItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.SelectedIndexChanged
        lblDescription.Text = "" : txtSerialNo.Text = ""
        lblDescription.Text = cboItems.SelectedItem.Col2
        txtOriginalSerialNumber.Text = Trim(cboItems.SelectedItem.Col3)
        txtSerialNo.Text = Trim(cboItems.SelectedItem.Col4)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If Not IsNumeric(txtDocNo.Text) Then
            MessageBox.Show("Please enter the original document number", "Missing Original Document Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocNo.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblDescription.Text) Then
            MessageBox.Show("Please select the item code from the drop down list", "Invalid Item Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboItems.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtReason.Text) Then
            MessageBox.Show("There must be a reason why item is exchanged. Please enter it", "Missing Reason For Exchange", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtReason.Focus()
            Exit Sub
        End If
        'If Not IsNumeric(lblSerialNo.Text) Then lblSerialNo.Text = "0.00"
        Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO SalesExchanges ([TransactionDate]," _
            & "[OriginalDocNumber],[ItemCode],[CurrentSerialNumber],[OriginalSerialNumber],[SellingPrice]," _
            & "[Reason],[UserName],[BranchName]) VALUES ('" & gwt_comm.shortMonthDateFormat(Now) & "', " & CInt(txtDocNo.Text) & ", " _
            & "'" & cboItems.Text & "', '" & txtCurrentSerialNumber.Text & "', '" & txtOriginalSerialNumber.Text & "', " _
            & "0.00, '" & txtReason.Text & "', '" & strUserName & "', '" & strUserBranch & "')", cnn)
        objCommand.ExecuteNonQuery()

        'Update the inventory serial numbers table

        '
        'First delete the new serial number and then add back the old serial number

        'Format the serial number

        Dim strNewBarCode As String = Nothing
        Dim strNewSerialNo As String = Nothing
        Dim strBaseBarCode As String = Nothing
        Dim strSerials As String = txtCurrentSerialNumber.Text

        If Not String.IsNullOrEmpty(strSerials) Then
            strNewBarCode = Space(intBarcodeLength - strSerials.Length) & strSerials
            strNewSerialNo = Mid(strNewBarCode, (intBarcodeLength - (intBarcodeUserLength - 1)), intBarcodeUserLength)
            strBaseBarCode = Mid(strNewBarCode, 1, (intBarcodeLength - intBarcodeUserLength))
        End If

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers WHERE SerialNumber = '" & strNewSerialNo & "' " _
            & "AND BarCodeNo = '" & Trim(strBaseBarCode) & "' AND ItemCode = '" & cboItems.Text & "'", cnn)
        objCommand.ExecuteNonQuery()

        Dim strSql As String = Nothing
        If Not String.IsNullOrEmpty(txtOriginalSerialNumber.Text) Then
            'Get the cost price
            Dim dblUnitPrice As Double = 0
            strSql = "SELECT CostPrice FROM Sales WHERE InvoiceNumber = " & txtDocNo.Text & " AND " _
                & "SerialNumbers = '" & txtSerialNo.Text & "' AND ItemCode = '" & cboItems.Text & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader(0).ToString) Then dblUnitPrice = CDbl(objReader(0).ToString)
            End If
            objReader.Close()

            strSql = "INSERT INTO SerialNumbers (ItemCode, SerialNumber, BarCodeNo, SourceSerialNo, CostPrice) VALUES " _
                & "('" & cboItems.Text & "', '" & txtSerialNo.Text & "', '" & Trim(txtOriginalSerialNumber.Text) & "', " _
                & "'" & txtOriginalSerialNumber.Text & txtSerialNo.Text & "', " & dblUnitPrice & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        'Update the control numbers table
        objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET ItemReturns = " & CDbl(txtReturnNumber.Text) & "", cnn)
        objCommand.ExecuteNonQuery()

        PrintExchangeReceipt()
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Item Exchange Processing"
        ShowErrorMessage()
    End Sub

    Private Sub PrintExchangeReceipt()
        On Error GoTo RaiseErr
        Dim strType As String = "ITEM EXCHANGE"
        Dim strSelectedReport As String = Me.txtReturnNumber.Text

        arrPrintDetails = New ArrayList
        '
        'ADD THE BRANCH INFORMATION
        '
        arrPrintDetails.Add(Space(2) & UCase(strCompanyName))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchName))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress1))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress2))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress3))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress4))
        arrPrintDetails.Add(Space(2) & "PHONE: " & strPublicBranchTelephone)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        arrPrintDetails.Add(Space(2) & "PRODUCT EXCHANGE")
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        '
        arrPrintDetails.Add(Space(2) & UCase(lblDescription.Text))
        arrPrintDetails.Add(Space(2) & "ORIGINAL  S.N. " & UCase(txtOriginalSerialNumber.Text & txtSerialNo.Text))
        arrPrintDetails.Add(Space(2) & "REPLACING S.N. " & UCase(txtCurrentSerialNumber.Text))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))


        Dim strZimDate As String = gwt_comm.shortMonthDateFormat(Now)

        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(2) & "SALES REP " & UCase(strUserName) & Space(3))
        arrPrintDetails.Add(Space(1) & "DATE AND TIME " & strZimDate & " " & DatePart(DateInterval.Hour, Now) & ":" & DatePart(DateInterval.Minute, Now))
        arrPrintDetails.Add(Space(2) & "EXCHANGE DATE  " & gwt_comm.shortMonthDateFormat(Now))
        arrPrintDetails.Add(Space(2) & " DOC NO " & txtReturnNumber.Text)
        arrPrintDetails.Add(Space(32))
        For i As Integer = 0 To 14
            arrPrintDetails.Add(Space(32))
        Next

        'WRITE EVERY THING TO THE AUDIT FILE
        Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\EXCHANGES", True)
        For x As Integer = 0 To arrPrintDetails.Count - 1
            objFileWriter.WriteLine(arrPrintDetails.Item(x))
        Next
        objFileWriter.Close()
        '
        'PRINTS FROM A FILE DIRECTLY TO THE PRINTER
        '
        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()

        If MessageBox.Show("Do you want to print the receipt right now?", "Confirm Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            For n = 0 To arrPrintDetails.Count - 1
                Dim strPrintLineDetails As String = arrPrintDetails.Item(n) & vbCrLf
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintLineDetails)
            Next
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Processing"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub txtDocNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDocNo.KeyPress
        If Asc(e.KeyChar) = 13 Then cboItems.Focus()
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If e.KeyChar = "." Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtDocNo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDocNo.Validating
        cboItems.Items.Clear() : txtOriginalSerialNumber.Text = "" : txtSerialNo.Text = "" : lblDescription.Text = ""
        cboItems.Text = Nothing : txtCurrentSerialNumber.Text = Nothing
        If Not String.IsNullOrEmpty(txtDocNo.Text) Then LoadReceiptData()
    End Sub

    Private Sub LoadReceiptData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT ItemCode +';'+ Description +';'+ BaseBarcode +';'+ SerialNumbers AS " _
            & "[Items] FROM Sales WHERE InvoiceNumber = " & CInt(txtDocNo.Text) & " ORDER BY ItemCode"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
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
            .ColumnWidth = "150;150;120;100"
        End With

        'Get a count of the items
        strSql = "SELECT count(InvoiceNumber) FROM Sales WHERE InvoiceNumber = " & CInt(txtDocNo.Text) & ""
        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReaderCount = sqlCommand.ExecuteReader

        Dim intItemsCount As Integer
        If objReaderCount.HasRows Then
            objReaderCount.Read()
            If IsNumeric(objReaderCount(0).ToString) Then
                intItemsCount = CInt(objReaderCount(0).ToString)
            End If
        End If
        objReaderCount.Close()

        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboItems.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
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

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub txtCurrentSerialNumber_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCurrentSerialNumber.Validating
        If Not String.IsNullOrEmpty(txtCurrentSerialNumber.Text) Then
            boolAbort = False
            Dim strValues() As String = gwt_comm.ReadBarcode(txtCurrentSerialNumber.Text)
            If boolAbort = True Then Exit Sub

            'The return array contains the item code, transactionid, Foundstatus, serial number

            If String.IsNullOrEmpty(strValues(0)) Then
                MessageBox.Show("Item barcode not found in the system", "Invalid Item Bar Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCurrentSerialNumber.Focus()
                Exit Sub
            End If
        End If
    End Sub

End Class