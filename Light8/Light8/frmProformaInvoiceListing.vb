Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmProformaInvoiceListing

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

    Private Sub loadProformaEmployees()
        On Error GoTo RaiseErr
        'Load the employee details
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames " _
            & "AS [EmployeeDetails] FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        cboUserProforma.Items.Clear()
        cboUserProforma.Items.Add("ALL")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboUserProforma.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadProformas(BeginingDate As Date, EndingDate As Date)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing

        If UCase(cboUserProforma.Text) = "ALL" Then
            strSql = "SELECT ReferenceNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], CustomerName, " _
                & "CAST(QuoteValue AS DECIMAL (30,2)) AS [Value], CAST(TotalDiscount AS DECIMAL (30,2)) AS [Discounts], " _
                & "CAST(TotalTaxes AS DECIMAL (30,2)) AS [Taxes] FROM ProformaMain WHERE TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(BeginingDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndingDate) & "'"
        Else
            If String.IsNullOrEmpty(cboUserProforma.Text) Then
                strSql = "SELECT ReferenceNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], CustomerName, " _
                & "CAST(QuoteValue AS DECIMAL (30,2)) AS [Value], CAST(TotalDiscount AS DECIMAL (30,2)) AS [Discounts], " _
                & "CAST(TotalTaxes AS DECIMAL (30,2)) AS [Taxes] FROM ProformaMain WHERE TransDate BETWEEN " _
                & "'" & gwt_comm.shortMonthDateFormat(BeginingDate) & "' AND '" & gwt_comm.shortMonthDateFormat(EndingDate) & "'"
            Else
                strSql = "SELECT ReferenceNumber, CONVERT(NVARCHAR, TransDate, 105) AS [Date], CustomerName, " _
                    & "CAST(QuoteValue AS DECIMAL (30,2)) AS [Value], CAST(TotalDiscount AS DECIMAL (30,2)) AS [Discounts], " _
                    & "CAST(TotalTaxes AS DECIMAL (30,2)) AS [Taxes] FROM ProformaMain WHERE TransDate BETWEEN " _
                    & "'" & gwt_comm.shortMonthDateFormat(BeginingDate) & "' " _
                    & "AND '" & gwt_comm.shortMonthDateFormat(EndingDate) & "' AND SalesAgent = '" & cboUserProforma.Text & "'"
            End If
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim i As Integer = 0
        dGridProformas.Rows.Clear()
        While objReader.Read
            dGridProformas.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridProformas.Rows(i).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridProformas.Rows(i).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGridProformas.Rows(i).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dGridProformas.Rows(i).Cells(3).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then dGridProformas.Rows(i).Cells(4).Value = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then dGridProformas.Rows(i).Cells(5).Value = objReader(5).ToString
            i = i + 1
        End While
        objReader.Read()

        'Calculate totals
        Dim dblMovingT As Double = 0
        Dim dblMovingTx As Double = 0
        Dim dblMovingDs As Double = 0
        Dim strValue As String
        For i = 0 To dGridProformas.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGridProformas.Rows(i).Cells(3).Value), "")) Then
                strValue = Convert.ToString(dGridProformas.Rows(i).Cells(3).Value)
                If IsNumeric(strValue) Then
                    dblMovingT = dblMovingT + CDbl(strValue)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridProformas.Rows(i).Cells(4).Value), "")) Then
                strValue = Convert.ToString(dGridProformas.Rows(i).Cells(4).Value)
                If IsNumeric(strValue) Then
                    dblMovingTx = dblMovingTx + CDbl(strValue)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridProformas.Rows(i).Cells(5).Value), "")) Then
                strValue = Convert.ToString(dGridProformas.Rows(i).Cells(5).Value)
                If IsNumeric(strValue) Then
                    dblMovingDs = dblMovingDs + CDbl(strValue)
                End If
            End If
        Next
        lblTotalProforma.Text = Format(dblMovingT, "#,##0.00")
        lblTaxesProforma.Text = Format(dblMovingTx, "#,##0.00")
        lblDiscountsProforma.Text = Format(dblMovingDs, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmProformaInvoiceListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadProformaEmployees()
    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoProforma.Click
        LoadProformas(dpStartFromProforma.Value, dpEndToProforma.Value)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditProforma.Click
        If IntPublicInvoicing = 0 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If dGridProformas.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridProformas.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridProformas.CurrentRow.Cells(0).Value.ToString) Then
                boolEditStatusTwo = True
                intSelectedTransaction = CInt(dGridProformas.CurrentRow.Cells(0).Value.ToString)
                Dim f As New frmProformaInvoice
                f.ShowDialog()
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Quotations Analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGridProformas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridProformas.CellClick
        If IntPublicInvoicing <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If dGridProformas.Rows.Count <= 0 Then Exit Sub
        If dGridProformas.CurrentCell.ColumnIndex <> 6 Then Exit Sub
        DeleteDocument()
    End Sub

    Private Sub DeleteDocument()
        On Error GoTo RaiseErr

        If Not (Object.Equals(Convert.ToString(dGridProformas.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridProformas.CurrentRow.Cells(0).Value.ToString) Then
                boolEditStatusTwo = True
                intSelectedTransaction = CInt(dGridProformas.CurrentRow.Cells(0).Value.ToString)
                If MessageBox.Show("Are you sure you want to delete this quotation?", "Confirm Proforma Invoice Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim objDelete As New Data.OleDb.OleDbCommand("DELETE FROM ProformaMain WHERE ReferenceNumber = " & intSelectedTransaction, cnn)
                    objDelete.ExecuteNonQuery()
                    objDelete = New Data.OleDb.OleDbCommand("DELETE FROM ProformaDetails WHERE ReferenceNumber = " & intSelectedTransaction, cnn)
                    objDelete.ExecuteNonQuery()
                    LoadProformas(dpStartFromProforma.Value, dpEndToProforma.Value)
                    MessageBox.Show("Proforma Invoice deleted successfully", "Proforma Invoice Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Cursor = Cursors.Default
                End If
            End If
        End If

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Proforma Invoice Analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGridProformas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridProformas.DoubleClick
        If IntPublicInvoicing = 0 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If dGridProformas.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridProformas.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridProformas.CurrentRow.Cells(0).Value.ToString) Then
                boolEditStatusTwo = True
                intSelectedTransaction = CInt(dGridProformas.CurrentRow.Cells(0).Value.ToString)
                Dim f As New frmProformaInvoice
                f.ShowDialog()
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Proforma Invoice Analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GenerateProformaTransactionDocument(ByVal intDocumentNumber As Integer)
        'get invoice number
        On Error GoTo RaiseErr
        Dim n As Integer = 0
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim myCommand As Data.OleDb.OleDbCommand

        myCommand = New Data.OleDb.OleDbCommand("Select CONVERT(NVARCHAR, TransDate, 105) as [TransDate], CustomerName, " _
            & "Address1, Address2, Address3, Address4, ContactNumber, EmailAddress, QuoteValue, TotalTaxes, TotalDiscount, " _
            & "TaxNumber, Terms FROM ProformaMain Where ReferenceNumber = " & intDocumentNumber & "", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            If Not IsDBNull(dbReader(0).ToString) Then strDate = dbReader(0).ToString
            If Not IsDBNull(dbReader(1).ToString) Then strCustomerName = dbReader(1).ToString
            If Not IsDBNull(dbReader(2).ToString) Then strCustomerAddress1 = dbReader(2).ToString
            If Not IsDBNull(dbReader(3).ToString) Then strCustomerAddress2 = dbReader(3).ToString
            If Not IsDBNull(dbReader(4).ToString) Then strCustomerAddress3 = dbReader(4).ToString
            If Not IsDBNull(dbReader(5).ToString) Then strCustomerAddress4 = dbReader(5).ToString
            If Not IsDBNull(dbReader(6).ToString) Then strCustomerTelephone = dbReader(6).ToString
            If Not IsDBNull(dbReader(7).ToString) Then strCustomerEmailAddress = dbReader(7).ToString
            If IsNumeric(dbReader(8).ToString) Then dblInvoiceTotal = CDbl(dbReader(8).ToString) Else dblInvoiceTotal = 0
            If IsNumeric(dbReader(9).ToString) Then dblTaxes = dbReader(9).ToString Else dblTaxes = 0
            If IsNumeric(dbReader(10).ToString) Then dblDiscounts = dbReader(10).ToString Else dblDiscounts = 0
            If Not IsDBNull(dbReader(11).ToString) Then strCustomerVatNumber = dbReader(11).ToString
            If Not IsDBNull(dbReader(12).ToString) Then strTermsAndConditions = dbReader(12).ToString
        End If
        dbReader.Close()

        myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity, ItemCode, Description, UnitPrice, " _
            & "Discount, Tax, Payable from ProformaDetails where ReferenceNumber = " & intDocumentNumber & "", cnn)
        dbReader = myCommand.ExecuteReader
        strInvoiceDetails = New ArrayList
        While dbReader.Read
            Dim strLine As String = Nothing
            For n = 0 To dbReader.FieldCount - 1
                If n = 0 Then
                    strLine = dbReader(n).ToString & "|"
                Else
                    strLine = strLine & dbReader(n).ToString & "|"
                End If
            Next
            strInvoiceDetails.Add(strLine)
        End While
        dbReader.Close()

        boolPrintFromPreview = False
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Proforma Invoice Generation Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrintSummaryProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintSummaryProforma.Click
        'gwt_comm.PrintDataGrid(dGridProformas, "PROFORMA INVOICES SUMMARY FROM " & UCase(Format(dpStartFromProforma.Value, "dd-MMM-yyyy")) & " TO " & _
        '    UCase(Format(dpEndToProforma.Value, "dd-MMM-yyyy")))
    End Sub

    Private Sub btnNewProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewProforma.Click
        If IntPublicInvoicing <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        boolEditStatusTwo = False
        Dim f As New frmProformaInvoice
        f.ShowDialog()
    End Sub

    Private Sub btnPrintSelectedProforma_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintSelectedProforma.Click
        If dGridProformas.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridProformas.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridProformas.CurrentRow.Cells(0).Value.ToString) Then
                intSelectedTransaction = CInt(dGridProformas.CurrentRow.Cells(0).Value.ToString)
                boolPrinterAlreadySelected = False

                Dim documentType As String = "PROFORMA"
                Dim docNumber As Long = intSelectedTransaction
                If UCase(strPrintDocumentsTo) = UCase("pdf") Then
                    boolAbort = False
                    PrintCustomerPdfDocument(docNumber, documentType)
                    If boolAbort = False Then
                        Cursor = DefaultCursor
                        MessageBox.Show(documentType & " has been generated to pdf successfully",
                                "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                Else
                    gwt_comm.PrintCustomerDocument(docNumber, documentType)
                End If

            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Proforma Invoice Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDeleteProforma_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteProforma.Click
        If IntPublicInvoicing <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If dGridProformas.Rows.Count <= 0 Then Exit Sub
        DeleteDocument()
    End Sub

    Private Sub btnRefreshProforma_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshProforma.Click
        LoadProformas(dpStartFromProforma.Value, dpEndToProforma.Value)
    End Sub

End Class