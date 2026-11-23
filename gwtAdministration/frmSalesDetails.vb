Imports System.Drawing.Printing
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmSalesDetails

    Dim arrPrintDetails As ArrayList
    Dim strReferenceId As String = "0"

    Dim prFont As New Font("Arial", 8, FontStyle.Regular)
    Dim tlFont As New Font("Arial", 8, FontStyle.Bold)
    Dim HeaderFont As New Font("Arial", 12, FontStyle.Bold)

    Dim boolPrintFromPreview As Boolean
    Dim strCustomerName As String
    Dim strDate As String
    Dim strSalesRep As String
    Dim boolExitingWhile As Boolean
    Dim itm As Integer = 0
    Dim strValue As String
    Dim intPage As Single = 1
    Dim intPageTotals As Double = 1
    Dim dblInvoiceTotal As Double
    Dim dblTaxes As Double
    Dim dblDiscounts As Double
    Dim i As Double = 0
    Dim strInvoiceDetails As ArrayList

    Private Sub frmSalesDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UCase(strCalledBy) = "GROUP" Then
            btnVoid.Enabled = False
            btnUpdate.Enabled = False
            LoadGroupFormData()
        Else
            If UCase(strCalledBy) = UCase("TILL") Then
                btnVoid.Enabled = False
                btnUpdate.Enabled = False
                LoadFormData()
            Else
                LoadFormData()
            End If
        End If
        ComputeTotals()
        If boolVoidSale = True Then
            btnReprint.Enabled = False
            btnUpdate.Enabled = False
        End If
        If boolLoadedFromVoidedSales = True Then
            btnUpdate.Enabled = False
            btnVoid.Enabled = False
        End If
    End Sub

    Private Sub LoadGroupFormData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing
        If boolLoadedFromVoidedSales = True Then
            strSql = "select ItemCode, Description, Quantity, CAST(SalesPrice AS " _
                & "DECIMAL(10,2)) AS [UnitPrice], CAST(DiscountAllowed AS DECIMAL(10,2)) AS [Discounts], " _
                & "CAST(Taxes AS DECIMAL(10,2)) AS [Taxes], CAST(((Quantity * SalesPrice) - " _
                & "DiscountAllowed + Taxes) AS DECIMAL(10,2)) AS [Payable], SerialNumbers, TransactionId from GroupSales WHERE " _
                & "InvoiceNumber = " & intSelectedTransaction & " AND BranchName = '" & strSelectedBranch & "'"
        Else
            strSql = "select ItemCode, Description, Quantity, CAST(SalesPrice AS " _
                & "DECIMAL(10,2)) AS [UnitPrice], CAST(DiscountAllowed AS DECIMAL(10,2)) AS [Discounts], " _
                & "CAST(Taxes AS DECIMAL(10,2)) AS [Taxes], CAST(((Quantity * SalesPrice) - " _
                & "DiscountAllowed + Taxes) AS DECIMAL(10,2)) AS [Payable], SerialNumbers, TransactionId from GroupSales WHERE " _
                & "InvoiceNumber = " & intSelectedTransaction & " AND BranchName = '" & strSelectedBranch & "'"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
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
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Cash Sale Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadFormData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing

        If boolLoadedFromVoidedSales = True Then
            strSql = "select ItemCode, Description, Quantity, CAST(SalesPrice AS " _
                & "DECIMAL(10,2)) AS [UnitPrice], CAST(DiscountAllowed AS DECIMAL(10,2)) AS [Discounts], " _
                & "CAST(Taxes AS DECIMAL(10,2)) AS [Taxes], CAST(((Quantity * SalesPrice) - " _
                & "DiscountAllowed + Taxes) AS DECIMAL(10,2)) AS [Payable], SerialNumbers, TransactionId from VoidSales WHERE " _
                & "InvoiceNumber = " & intSelectedTransaction & ""
        Else
            strSql = "select ItemCode, Description, Quantity, CAST(SalesPrice AS " _
                & "DECIMAL(10,2)) AS [UnitPrice], CAST(DiscountAllowed AS DECIMAL(10,2)) AS [Discounts], " _
                & "CAST(Taxes AS DECIMAL(10,2)) AS [Taxes], CAST(((Quantity * SalesPrice) - " _
                & "DiscountAllowed + Taxes) AS DECIMAL(10,2)) AS [Payable], SerialNumbers, TransactionId from Sales WHERE " _
                & "InvoiceNumber = " & intSelectedTransaction & ""
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(2).Value = objReader(2).ToString

            If Not IsDBNull(objReader(3).ToString) Then
                If strTaxComputationType = "INCLUSIVE" Then
                    If IsNumeric(objReader(5).ToString) Then
                        dGrid.Rows(dGrid.Rows.Count - 1).Cells(3).Value = Format((CDbl(objReader(3).ToString) - CDbl(objReader(5).ToString)), "##0.00")
                    Else
                        dGrid.Rows(dGrid.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
                    End If
                End If
            End If

            If Not IsDBNull(objReader(4).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(5).Value = objReader(5).ToString

            If Not IsDBNull(objReader(6).ToString) Then
                If strTaxComputationType = "INCLUSIVE" Then
                    If IsNumeric(objReader(5).ToString) Then
                        If IsNumeric(objReader(6).ToString) Then
                            dGrid.Rows(dGrid.Rows.Count - 1).Cells(6).Value = Format((CDbl(objReader(6).ToString) - CDbl(objReader(5).ToString)), "##0.00")
                        End If
                    End If
                End If
            End If


            If Not IsDBNull(objReader(7).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(7).Value = objReader(7).ToString
            If Not IsDBNull(objReader(8).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(8).Value = objReader(8).ToString
        End While
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Cash Sale Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub PrintInvoice()
        On Error GoTo RaiseErr

        arrPrintDetails = New ArrayList
        '
        'ADD THE BRANCH INFORMATION
        '
        arrPrintDetails.Add(Space(2) & strCompanyName)
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchName))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress1))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress2))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress3))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress4))
        arrPrintDetails.Add(Space(2) & "PHONE: " & strPublicBranchTelephone)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        '
        'Print based on the grid values
        '
        Dim dblVatTax As Double = 0
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1
                Dim strDescription As String = .Rows(i).Cells(1).Value.ToString
                Dim strQuantity As String = .Rows(i).Cells(2).Value.ToString
                Dim strUnitPrice As String = Format(CDbl(.Rows(i).Cells(3).Value.ToString), "#,##0.00")
                Dim strLineTotal As String = Format(CDbl(.Rows(i).Cells(6).Value.ToString), "#,##0.00")
                If strDescription.Length > 30 Then strDescription = Mid(strDescription, 1, 30)
                arrPrintDetails.Add(Space(2) & strDescription)
                If chkOrdinaryPrinter.Checked = True Then
                    arrPrintDetails.Add(strQuantity & "|" & strUnitPrice & "|" & strLineTotal)
                Else
                    arrPrintDetails.Add(Space(4) & Space(5 - strQuantity.Length) & strQuantity & " @ " & Space(8 - strUnitPrice.Length) & strUnitPrice & Space(4) & Space(8 - strLineTotal.Length) & strLineTotal)
                End If
                dblVatTax = dblVatTax + Convert.ToDouble(.Rows(i).Cells(5).Value)
            Next
        End With

        'Add the dash line
        Dim strTaxCharged As String = Format(dblVatTax, "##0.00")

        Dim strTender As String = Format(dblAmountTendered, "##0.00")
        Dim strChange As String = Format(dblAmountChange, "##0.00")

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        If chkOrdinaryPrinter.Checked = True Then
            arrPrintDetails.Add(Space(2) & "|AMT + VAT|" & lblPayable.Text)
        Else
            arrPrintDetails.Add(Space(2) & "TOTAL INCL. VAT " & Space(14 - lblPayable.Text.Length) & lblPayable.Text)
        End If

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))

        If chkOrdinaryPrinter.Checked = True Then
            arrPrintDetails.Add(Space(2) & "|VAT AMT|" & strTaxCharged)
        Else
            arrPrintDetails.Add(Space(2) & "VAT CHARGED     " & Space(14 - strTaxCharged.Length) & strTaxCharged)
        End If

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))

        'If chkOrdinaryPrinter.Checked = True Then
        '    arrPrintDetails.Add(Space(2) & "|TENDERED|" & strTender)
        'Else
        '    arrPrintDetails.Add(Space(2) & "AMOUNT TENDERED " & Space(14 - strTender.Length) & strTender)
        'End If

        'If chkOrdinaryPrinter.Checked = True Then
        '    arrPrintDetails.Add(Space(2) & "|CHANGE|" & strChange)
        'Else
        '    arrPrintDetails.Add(Space(2) & "CHANGE          " & Space(14 - strChange.Length) & strChange)
        'End If

        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(2) & "SALES REP " & UCase(strUserName) & Space(3))
        arrPrintDetails.Add(Space(2) & "DATE AND TIME " & Now)
        arrPrintDetails.Add(Space(2) & " DOC NO " & intSelectedTransaction)
        arrPrintDetails.Add(Space(32))
        'arrPrintDetails.Add("** NO RETURNS ON TESTED ITEMS **")
        'arrPrintDetails.Add("* ORIGINAL PHONE 6MTH GUARANTE *")

        'Add the terms and condictions

        If arrConditionsOfSale.Count > 0 Then
            For j As Double = 0 To arrConditionsOfSale.Count - 1
                arrPrintDetails.Add(UCase(arrConditionsOfSale.Item(j)))
            Next j
        End If

        For i As Integer = 0 To 5
            arrPrintDetails.Add(Space(32))
        Next
        '
        'PRINTS FROM A FILE DIRECTLY TO THE PRINTER
        '
        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()

        If strRequestForReceiptPrinter = "YES" Then
            boolAbort = False
            gwt_comm.PrinterSelection()
            If boolAbort = True Then Exit Sub
            pd.PrinterSettings.PrinterName = strSessionPrinter
        End If

        If UCase(strPublicPrinterType) = "RAW" Then
            pb1.Value = 0 : pb1.Maximum = arrPrintDetails.Count
            For n = 0 To arrPrintDetails.Count - 1
                Dim strPrintLineDetails As String = arrPrintDetails.Item(n) & vbCrLf
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintLineDetails)
                pb1.Value = pb1.Value + 1
            Next
        Else
            Dim ppd As New PrintPreviewDialog
            ppd.Document = pdWindows
            pdWindows.Print()
        End If
        'Cut the paper on thermal printers
        Dim output As String = Chr(&H1D) & "V" & Chr(66) & Chr(0) 'Feeds paper & cut
        If strPublicCutReceipt = "YES" Then RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, output)

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Processing"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub ComputeTotals()
        If dGrid.Rows.Count = 0 Then Exit Sub
        Dim dblSubTotal As Double = 0
        Dim dblTaxesTotal As Double = 0
        Dim dblDiscountTotals As Double = 0
        Dim dblTotalPayable As Double = 0
        For n As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(4).Value), "")) Then
                dblDiscountTotals = dblDiscountTotals + CDbl(dGrid.Rows(n).Cells(4).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(5).Value), "")) Then
                dblTaxesTotal = dblTaxesTotal + CDbl(dGrid.Rows(n).Cells(5).Value.ToString)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(n).Cells(6).Value), "")) Then
                dblTotalPayable = dblTotalPayable + CDbl(dGrid.Rows(n).Cells(6).Value.ToString)
            End If
        Next
        dblSubTotal = (dblTotalPayable + dblDiscountTotals) - dblTaxesTotal
        lblSubTotal.Text = Format(dblSubTotal, "#,##0.00")
        lblTaxes.Text = Format(dblTaxesTotal, "#,##0.00")
        lblDiscounts.Text = Format(dblDiscountTotals, "#,##0.00")
        lblPayable.Text = Format(dblTotalPayable, "#,##0.00")
    End Sub

    Private Sub pdWindows_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdWindows.PrintPage
        'This will send the printing to the windows type

        'Dim prFont As New Font("Arial", 6, FontStyle.Regular)
        'Dim tlFont As New Font("Arial", 6, FontStyle.Bold)
        'Dim HeaderFont As New Font("Arial", 12, FontStyle.Bold)

        Dim y1 As Integer = 10

        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                'Dont print the company name as it is taken care of by the logo
                strCompanyName = ""
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (y1 - intImageYLocation) / 2
                'R = New Rectangle(100, intImageYLocation, objPicture.Width, objPicture.Height)
                R = New Rectangle(10, y1, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                y1 = y1 + objPicture.Height
            End If
        End If

        y1 = y1 + 15

        For i As Integer = 0 To arrPrintDetails.Count - 1
            If i = 0 Then
                Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, arrPrintDetails.Item(i), tlFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, arrPrintDetails.Item(i), prFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Next
        e.HasMorePages = False

    End Sub

    Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
        If UCase(strPublicReceiptType) = "DESKTOP PRINTER" Then
            If UCase(strUserLevel) = UCase("Cashier") Then
                MessageBox.Show("You do not have sufficient rights to perform this action. Contact your supervisor", "Invoking Unauthorized Process", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                PrintInvoiceTypeCashSlip(intSelectedTransaction)
            End If
        Else
            If UCase(strUserLevel) = UCase("Cashier") Then
                MessageBox.Show("You do not have sufficient rights to perform this action. Contact your supervisor", "Invoking Unauthorized Process", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                PrintInvoice()
            End If
        End If
    End Sub

    Private Sub PrintInvoiceTypeCashSlip(ByVal ReceiptNumber As Integer)
        GenerateTransactionDocument(ReceiptNumber)
        intSelectedTransaction = ReceiptNumber
        boolAbort = False
        gwt_comm.PrinterSelection()
        If boolAbort = True Then Exit Sub
        PrintDocument1.PrinterSettings.PrinterName = strSessionPrinter
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
        boolPrintFromPreview = True
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        'Re-enter the value back to the database as negative
        On Error GoTo RaiseErr

        If MessageBox.Show("Are you sure you want to void this transaction?", "Confirm Reversal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor

            Dim dblAmountTotal As Double = 0
            Dim dblTaxesTotal As Double = 0
            Dim dblDiscountsTotal As Double = 0

            Dim invoiceValue As Double = 0

            Dim strSql As String = Nothing
            Dim objCommand As Data.OleDb.OleDbCommand
            Dim objReader As Data.OleDb.OleDbDataReader

            strSql = "SELECT [InvoiceNumber],[CustomerId],[Status],[Amount],[Taxes],[Discount]," _
                & "[TransDate],[OriginalInvoice],[SalesRep],[UserName] FROM SalesMain WHERE InvoiceNumber = " & intSelectedTransaction & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(3).ToString) Then invoiceValue = objReader(3).ToString
                strSql = "INSERT INTO VoidSalesMain (InvoiceNumber, CustomerId, Status, Amount, Taxes, Discount, " _
                    & "TransDate, OriginalInvoice, SalesRep, UserName) VALUES (" & objReader(0).ToString & ", " _
                    & "'" & objReader(1).ToString & "', '" & objReader(2).ToString & "', " & objReader(3).ToString & ", " _
                    & "" & objReader(4).ToString & ", " & objReader(5).ToString & ", '" & objReader(6).ToString & "', " _
                    & "" & objReader(7).ToString & ", '" & objReader(8).ToString & "', '" & strUserName & "')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If
            objReader.Close()

            'Get the original sales data
            strSql = "SELECT [InvoiceNumber],[CustomerId],[ItemCode],[Description],[Quantity]," _
                & "[DiscountAllowed],[Taxes],[TransType],[SalesPrice],[TransDate],[ProductType],[SerialNumbers]," _
                & "[OriginalInvoice],[SalesRep],[UserName], [BaseBarcode], [CostPrice] FROM Sales WHERE InvoiceNumber = " & intSelectedTransaction & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader

            Dim strItemsMessage As String = Nothing

            While objReader.Read
                Dim dblLineAmount As Double = 0
                strSql = "INSERT INTO VoidSales (InvoiceNumber, CustomerId, ItemCode, Description, Quantity, DiscountAllowed, " _
                    & "Taxes, TransType, SalesPrice, TransDate, ProductType, SerialNumbers, OriginalInvoice, SalesRep, UserName, BaseBarcode, TransTime) " _
                    & "VALUES (" & objReader(0).ToString & ", '" & objReader(1).ToString & "', '" & objReader(2).ToString & "', " _
                    & "'" & objReader(3).ToString & "', " & objReader(4).ToString & ", " & objReader(5).ToString & ", " _
                    & "" & objReader(6).ToString & ", '" & objReader(7).ToString & "', " & objReader(8).ToString & ", " _
                    & "'" & objReader(9).ToString & "', '" & objReader(10).ToString & "', '" & objReader(11).ToString & "', " _
                    & "" & objReader(12).ToString & ", '" & objReader(13).ToString & "', '" & strUserName & "', '" & objReader("BaseBarcode").ToString & "', '" & Now & "')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                dblLineAmount = (CDbl(objReader("Quantity").ToString) * CDbl(objReader("SalesPrice").ToString)) - CDbl(objReader("DiscountAllowed").ToString)

                'Add the items back to the inventory
                If Not String.IsNullOrEmpty(objReader("SerialNumbers").ToString) Then
                    Dim lngComma As Long = InStr(1, objReader("SerialNumbers").ToString, ",", 1)
                    If lngComma > 0 Then
                        Dim strSeries() As String = Split(objReader("SerialNumbers").ToString, ",")
                        For n As Integer = 0 To strSeries.Length - 1
                            If Not String.IsNullOrEmpty(strSeries(n)) Then
                                strSql = "INSERT INTO SerialNumbers ([ItemCode], [SerialNumber], [BarCodeNo], " _
                                    & "[SourceSerialNo], [CostPrice], [Availability]) VALUES ('" & strSeries(n) & "', " _
                                    & "'" & objReader("SerialNumbers").ToString & "', '" & objReader("BaseBarcode").ToString & "', " _
                                    & "'" & Trim(objReader("BaseBarcode").ToString & objReader("SerialNumbers").ToString) & "', " _
                                    & "" & objReader("CostPrice").ToString & ", 'Y')"
                                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                objCommand.ExecuteNonQuery()
                            End If
                        Next
                    Else
                        strSql = "INSERT INTO SerialNumbers ([ItemCode], [SerialNumber], [BarCodeNo], " _
                                    & "[SourceSerialNo], [CostPrice], [Availability]) VALUES ('" & objReader("ItemCode").ToString & "', " _
                                    & "'" & objReader("SerialNumbers").ToString & "', '" & objReader("BaseBarcode").ToString & "', " _
                                    & "'" & Trim(objReader("BaseBarcode").ToString & objReader("SerialNumbers").ToString) & "', " _
                                    & "" & objReader("CostPrice").ToString & ", 'Y')"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                End If

                'Update the inventory table
                strSql = "UPDATE InventoryItems SET InventoryItems.Quantity = (InventoryItems.Quantity + " & CInt(objReader("Quantity").ToString) & ") " _
                    & "WHERE ItemCode = '" & objReader("ItemCode").ToString & "'"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                strItemsMessage = strItemsMessage & objReader(3).ToString & "-" & objReader(11).ToString & ":$" & Format(dblLineAmount, "##0.00") & ":>"

            End While
            objReader.Close()

            'Remove from the original sales table
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Sales WHERE InvoiceNumber = " & intSelectedTransaction & "", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SalesMain WHERE InvoiceNumber = " & intSelectedTransaction & "", cnn)
            objCommand.ExecuteNonQuery()
            'Remove from the cash book as well
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM CashbookTransactions WHERE Reference = '" & intSelectedTransaction & "'", cnn)
            objCommand.ExecuteNonQuery()
            'Remove from the ledger account as well
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LedgerTransactions WHERE Reference = '" & intSelectedTransaction & "'", cnn)
            objCommand.ExecuteNonQuery()

            'Send a message to the group administrator
            If UCase(strMachineTillStatus) = "CASHOUT" Then
                If Not String.IsNullOrEmpty(strMobileAlertNumbers) Then
                    Dim objSend As New SendHttpSms
                    Dim strSmsMessage As String = "Transaction voided: Doc.no. " & intSelectedTransaction & "; Total Amount involved is " & _
                        Format(invoiceValue, "##0.00") & " Receipt details as follows:> " & strItemsMessage & ">>" & UCase(strUserBranch)
                    Dim strStatus As String = objSend.InitializeHttpMessageSend(strMobileAlertNumbers, strSmsMessage)
                End If
            End If

            Cursor = Cursors.Default
            strPublicCustomerId = "0000"
            MessageBox.Show("Sales voided successfully.", "Transaction Void Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            boolTransactionVoided = True

        End If
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Void"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Cursor = Cursors.WaitCursor
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strSN As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "")) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(7).Value.ToString) Then
                    strSN = CInt(Convert.ToString(dGrid.Rows(i).Cells(7).Value))
                    Dim intNum As Long = CLng(dGrid.Rows(i).Cells(8).Value.ToString)
                    Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE Sales SET " _
                        & "SerialNumbers = '" & strSN & "' WHERE TransactionId = " & intNum & "", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        Next
        Cursor = Cursors.Default
        MessageBox.Show("Update of serial numbers completed successfully", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Document Number Fetch Failure"
        boolAbort = True
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If boolPrintFromPreview = True Then
            'requery records
            boolAbort = False
            Me.GenerateTransactionDocument(intSelectedTransaction)
            If boolAbort = True Then Exit Sub
            boolPrintFromPreview = False
        End If
        Dim strDType As String
        strDType = "CASH SALE RECEIPT"
        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer
        'Dim xx1 As Integer, xx2 As Integer, yy1 As Integer, yy2 As Integer
        x1 = e.PageBounds.Left + 100
        y1 = e.PageBounds.Top + 100
        p1 = e.PageBounds.Width - 200
        y2 = e.PageBounds.Height - 200

        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        Dim strS As String = Nothing
        Dim Yc As Integer
        Dim cols, lines As Integer

        'Draw the document rectangle
        reccurrent = New Rectangle(x1, y1, p1, y2)
        e.Graphics.DrawRectangle(Pens.Black, reccurrent)

        'Print the watermark here
        Dim g As Graphics = e.Graphics
        g.DrawString(UCase(strDType), New Font("Arial", 16, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, Color.Black)), 350, e.PageBounds.Top + 110)
        'Draw a line after
        y1 = y1 + 40
        e.Graphics.DrawLine(Pens.Black, x1, y1, p1 + 100, y1)

        'print the company logo
        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                Dim intImageYLocation As Integer = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                'R = New Rectangle(100, intImageYLocation, objPicture.Width, objPicture.Height)

                R = New Rectangle(intLogoXposition, intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
            End If
        End If

        y1 = y1 + 15
        'Print the company details at the extreme left of document
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, HeaderFont, Brushes.Black)
        'e.Graphics.DrawString(strDType, HeaderFont, Brushes.Black, 500, e.PageBounds.Top + 120)
        y1 = y1 + 20

        If Not String.IsNullOrEmpty(strCompanyAddress1) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress1, prFont, Brushes.Black)
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.  : " & UCase(strCompanyBPNumber), prFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.  : " & UCase(strCompanyBPNumber), prFont, Brushes.Black)
                y1 = y1 + 15
            End If
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress2) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress2, prFont, Brushes.Black)
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO. : " & UCase(strCompanyVatNumber), prFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO. : " & UCase(strCompanyVatNumber), prFont, Brushes.Black)
            End If
            y1 = y1 + 15
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress3) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress3, prFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyAddress4) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress4, prFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyTelephone) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "PHONE  : " & UCase(strCompanyTelephone), prFont, Brushes.Black)
            y1 = y1 + 15
        End If
        'strCompanyContactCellNumber
        If Not String.IsNullOrEmpty(strCompanyContactCellNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 550, 80, "CELL NO: " & UCase(strCompanyContactCellNumber), prFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyFaxNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "FAX NO.: " & UCase(strCompanyFaxNumber), prFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyEmailAddress) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "E-MAIL : " & strCompanyEmailAddress, prFont, Brushes.Black)
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
        e.Graphics.DrawString("CUSTOMER DETAILS", prFont, Brushes.Black, x1, y1)
        e.Graphics.DrawString("TRANSACTION DETAILS", prFont, Brushes.Black, 500, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 15
        'e.Graphics.DrawString("VAT No.: " & UCase(strCustomerVatNumber), prFont, Brushes.Black, x1, y1) '& Space(20) & " VAT No.: " & UCase(strCustomerVatNumber)
        y1 = y1 + 15

        If Not String.IsNullOrEmpty(strCustomerName) Then
            If strCustomerName.Length > 58 Then strCustomerName = Mid(strCustomerName, 1, 58)
        End If

        e.Graphics.DrawString(UCase(strCustomerName), prFont, Brushes.Black, x1, y1)
        'e.Graphics.DrawString(strCustomerName, prFont, Brushes.Black, x1, y1)
        'Print the date
        e.Graphics.DrawString("DATE", prFont, Brushes.Black, 500, y1)
        e.Graphics.DrawString(": " & strDate, prFont, Brushes.Black, 580, y1)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "INVOICE NUM", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, ": " & Format(CLng(intSelectedTransaction), "000000"), prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, "", prFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, "", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "ORDER REF.NO.", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, ": " & "0", prFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, "", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "SALES AGENT", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, ": " & UCase(strSalesRep), prFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, "", prFont, Brushes.Black)
        y1 += 15
        'e.Graphics.DrawString("TELEPHONE : " & strCustomerTelephone, prFont, Brushes.Black, x1, y1)
        y1 += 15
        'e.Graphics.DrawString("E-MAIL    :" & strCustomerEmailAddress, prFont, Brushes.Black, x1, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        Dim y1_before_headers As Integer = y1
        y1 = y1 + 12
        'print captions
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 60, 80, "QTY", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 180, 80, "DESCRIPTION", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x2 + 270, y1, 80, 80, "UNIT ", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, (X3 + 110), y1, 120, 80, "SUB TTL", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, (X4 + 80), y1, 120, 80, "TAX", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, (X5 + 50), y1, 120, 80, "DISCOUNT", prFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, (X6 + 20), y1, 120, 80, "TOTAL", prFont, Brushes.Black)
        'draw a line after
        y1 = y1 + 18
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 18
        itm = 0
        reccurrent = New Rectangle()
        boolExitingWhile = False
        Dim strBuffer() As String
        While itm < strInvoiceDetails.Count
            strBuffer = Split(strInvoiceDetails(itm), "|")
            Dim strUnitPriceBeforeTax As String = "0.00"
            Dim strTaxAmount As String = "0.00"
            Dim strDiscountAmount As String = "0.00"
            Dim strUnitPrice As String = "0.00"
            Dim strPayableAfterTax As String = "0.00"
            Dim strPrintQuantity As String = "0"
            Dim strPrintPrice As String = "0.00"

            Dim strItemCodeNumber As String = strBuffer(1)

            Dim strInventoryMeasure As String = gwt_comm.InventoryMeasurement(strItemCodeNumber)
            Dim strMeasureShortName As String = Nothing
            If Not String.IsNullOrEmpty(strInventoryMeasure) Then
                strMeasureShortName = gwt_comm.MeasurementShortName(strInventoryMeasure)
            End If

            'Quantity
            If Not strBuffer(0) Is Nothing Then strValue = strBuffer(0) Else strValue = "0"
            strPrintQuantity = strValue
            'Unit Price
            If Not strBuffer(3) Is Nothing Then strValue = CStr(Format(CDbl(strBuffer(3)), "#,##0.00")) Else strValue = "0.00"
            strUnitPrice = strValue
            'Discount
            If Not strBuffer(4) Is Nothing Then strValue = CStr(Format(CDbl(strBuffer(4)), "#,##0.00")) Else strValue = "0.00"
            strDiscountAmount = strValue
            'Tax Amount
            If Not strBuffer(5) Is Nothing Then strValue = CStr(Format(CDbl(strBuffer(5)), "#,##0.00")) Else strValue = "0.00"
            strTaxAmount = strValue
            If UCase(strTaxComputationType) = UCase("INCLUSIVE") Then
                strPrintPrice = Format(((CDbl((strUnitPrice) * CDbl(strPrintQuantity)) - CDbl(strTaxAmount)) / CDbl(strPrintQuantity)), "#,##0.00")
            Else
                strPrintPrice = Format(CDbl(strUnitPrice), "#,##.00")
            End If

            If IsNumeric(strPrintPrice) Then
                If CDbl(strPrintPrice) = 0 Then
                    strPrintQuantity = ""
                End If
            End If

            'QUANTITY PRINTING
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 50, 60, strPrintQuantity & strMeasureShortName, prFont, Brushes.Black)
            'UNIT PRICE PRINTING
            If IsNumeric(strPrintQuantity) Then
                Call gwt_comm.DrawStringInBoxRight(e, (X3 + 110), y1, 120, 80, Format(((CDbl(strUnitPrice) * CDbl(strPrintQuantity)) - 0), "#,##0.00"), prFont, Brushes.Black)
                ' Call gwt_comm.DrawStringInBoxRight(e, (X3 + 110), y1, 120, 80, Format(((CDbl(strUnitPrice) * CDbl(strPrintQuantity)) - CDbl(strTaxAmount)), "#,##0.00"), tlFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxRight(e, (X3 + 110), y1, 120, 80, "", prFont, Brushes.Black)
            End If

            'TAX PRINTING
            If IsNumeric(strPrintQuantity) Then
                Call gwt_comm.DrawStringInBoxRight(e, (X4 + 80), y1, 120, 80, strTaxAmount, prFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxRight(e, (X4 + 80), y1, 120, 80, "", prFont, Brushes.Black)
            End If

            'DISCOUNT PRINTING
            If IsNumeric(strPrintQuantity) Then
                Call gwt_comm.DrawStringInBoxRight(e, (X5 + 50), y1, 120, 80, strDiscountAmount, prFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxRight(e, (X5 + 50), y1, 120, 80, "", prFont, Brushes.Black)
            End If

            'Total payable
            If UCase(strTaxComputationType) = UCase("INCLUSIVE") Then
                If IsNumeric(strPrintQuantity) Then
                    strPayableAfterTax = Format(((CDbl(strPrintQuantity) * CDbl(strUnitPrice)) - CDbl(strDiscountAmount)) - 0, "#,##0.00")
                Else
                    strPayableAfterTax = ""
                End If
            Else
                If IsNumeric(strPrintQuantity) Then
                    strPayableAfterTax = Format(((CDbl(strPrintQuantity) * CDbl(strUnitPrice)) - CDbl(strDiscountAmount)) + CDbl(strTaxAmount), "#,##0.00")
                Else
                    strPayableAfterTax = ""
                End If
            End If

            'LINE TOTAL PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, (X6 + 20), y1, 120, 80, strPayableAfterTax, prFont, Brushes.Black)

            'If Not strBuffer(6) Is Nothing Then strvalue = CStr(Format(CDbl(strBuffer(6)), "#,##0.00")) Else strvalue = "0.00"

            'Print the description last as it is the column that will determine the next line position
            If IsNumeric(strPrintPrice) Then
                If CDbl(strPrintPrice) = 0 Then
                    strValue = strBuffer(2)
                Else
                    If Not strBuffer(2) Is Nothing Then strValue = strBuffer(2) Else strValue = ""
                End If
            Else
                If Not strBuffer(2) Is Nothing Then strValue = strBuffer(2) Else strValue = ""
            End If
            Call gwt_comm.DrawStringInBoxLeft(e, (x2 - 10), y1, 330, 80, strValue, prFont, Brushes.Black)

            'Print the unit price
            Call gwt_comm.DrawStringInBoxRight(e, (x2 + 225), y1, 80, 80, strPrintPrice, prFont, Brushes.Black)

            'Get the size of the description box
            e.Graphics.MeasureString(strValue, prFont, New SizeF(330, 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * prFont.Height + 5
            y1 = Math.Max(y1, Yc)
            'y1 = y1 + 20
            itm = itm + 1 : i = 0
            If itm = 23 Then
                'Print the page number of the statement
                Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, prFont, Brushes.Black)
                'print the compny bank details
                'Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 80, 600, 80, "OUR BANK DETAILS : " & UCase(strCompanyBankName) & " - ACCOUNT NO : " & UCase(strCompanyAccountNumber) & " BANK CODE : " & UCase(strCompanyBranchCode), prFont, Brushes.Black)
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
            Dim y1_after_headers As Integer = y1
            y1 = y1 + 30
            Dim y1_before As Integer = y1
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1, X5 + 250, y1)
            Call gwt_comm.DrawStringInBoxLeft(e, (X5 + 55), y1 + 3, 120, 80, "GROSS TOTAL", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, (y1 + 3), 120, 80, Format(((dblInvoiceTotal - dblTaxes) + dblDiscounts), "#,##0.00"), prFont, Brushes.Black)
            y1 = y1 + 20
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1, X5 + 250, y1)
            Call gwt_comm.DrawStringInBoxLeft(e, (X5 + 55), y1 + 3, 120, 80, "LESS DISCOUNTS", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, (y1 + 3), 120, 80, Format(dblDiscounts, "#,##0.00"), prFont, Brushes.Black)
            y1 = y1 + 20
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1, X5 + 250, y1)
            Call gwt_comm.DrawStringInBoxLeft(e, (X5 + 55), y1 + 3, 120, 80, "SUB TOTAL", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, (y1 + 3), 120, 80, Format((dblInvoiceTotal - dblTaxes), "#,##0.00"), prFont, Brushes.Black)
            y1 = y1 + 20
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1, X5 + 250, y1)
            Call gwt_comm.DrawStringInBoxLeft(e, (X5 + 55), y1 + 3, 120, 80, "ADD TAXES", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, (y1 + 3), 120, 80, Format(dblTaxes, "#,##0.00"), prFont, Brushes.Black)
            y1 = y1 + 20
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1, X5 + 250, y1)
            Call gwt_comm.DrawStringInBoxLeft(e, (X5 + 55), y1 + 3, 120, 80, "NET PAYABLE", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, (y1 + 3), 120, 80, Format(dblInvoiceTotal, "#,##0.00"), prFont, Brushes.Black)
            y1 = y1 + 20
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1, X5 + 250, y1)
            Dim y1_after As Integer = y1
            e.Graphics.DrawLine(Pens.Black, X5 + 50, y1_before, X5 + 50, y1_after)
            e.Graphics.DrawLine(Pens.Black, X5 + 150, y1_before, X5 + 150, y1_after)
            y1 = y1 + 15
            'Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 120, 80, "TOTALS ", prFont, Brushes.Black)
            'Call gwt_comm.DrawStringInBoxRight(e, X3, y1, 120, 80, Format(dblUnitPriceTotals, "#,##0.00"), prFont, Brushes.Black)


            'draw the drop down lines
            e.Graphics.DrawLine(Pens.Black, x1 + 35, y1_before_headers, x1 + 35, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, x2 + 310, y1_before_headers, x2 + 310, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, x2 + 250, y1_before_headers, x2 + 250, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, 540, y1_before_headers, 540, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, 610, y1_before_headers, 610, y1_after_headers)
            e.Graphics.DrawLine(Pens.Black, 680, y1_before_headers, 680, y1_after_headers)

            'Print the receiver information
            Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 150, 220, 80, "ACCEPTED BY ....................................... ", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x1 + 210, e.PageBounds.Bottom - 150, 200, 80, "SIGNATURE ..................................... ", prFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, x1 + 420, e.PageBounds.Bottom - 150, 200, 80, "DATE ...................................... ", prFont, Brushes.Black)

            'Print the banking details

            If arrCompanyBankDetails.Count > 0 Then

                Dim myBrush As System.Drawing.Brush
                myBrush = New SolidBrush(Color.Black)

                Dim GridPen As New Pen(Brushes.WhiteSmoke, 1)
                Dim myPen As System.Drawing.Pen
                myPen = New System.Drawing.Pen(Brushes.WhiteSmoke)

                Dim intBnkCount As Integer = 0
                Dim yBank As Integer = e.PageBounds.Bottom - 190
                If arrCompanyBankDetails.Count > 4 Then intBnkCount = 3 Else intBnkCount = arrCompanyBankDetails.Count - 1

                'Draw the main line
                Dim recBank As New Rectangle(x1 - 10, yBank, 510, 90)
                e.Graphics.DrawRectangle(GridPen, recBank)
                yBank = yBank + 3
                Call gwt_comm.DrawStringInBoxLeft(e, (x1), yBank, 150, 80, "OUR BANKING DATAILS", prFont, myBrush)
                yBank = yBank + 12
                e.Graphics.DrawLine(myPen, x1 - 10, yBank, 610, yBank)
                yBank = yBank + 3
                Call gwt_comm.DrawStringInBoxLeft(e, (x1), yBank, 150, 80, "BANK NAME", prFont, myBrush)
                Call gwt_comm.DrawStringInBoxLeft(e, (x1 + 150), yBank, 80, 80, "SORT CODE", prFont, myBrush)
                Call gwt_comm.DrawStringInBoxLeft(e, (x1 + 230), yBank, 150, 80, "ACCOUNT NAME", prFont, myBrush)
                Call gwt_comm.DrawStringInBoxLeft(e, (x1 + 405), yBank, 100, 80, "ACCOUNT NO.", prFont, myBrush)
                yBank = yBank + 12
                e.Graphics.DrawLine(myPen, x1 - 10, yBank, 610, yBank)
                yBank = yBank + 3

                For j As Integer = 0 To intBnkCount
                    Dim strSplitAccounts() As String = Split(arrCompanyBankDetails.Item(j), "|")
                    '51001|STEWARD BANK JOINA CITY|GREAT WITS TECHNOLOGIES PVT LTD|1006734495
                    Call gwt_comm.DrawStringInBoxLeft(e, (x1), yBank, 150, 80, strSplitAccounts(1), prFont, myBrush)
                    Call gwt_comm.DrawStringInBoxLeft(e, (x1 + 150), yBank, 80, 80, strSplitAccounts(0), prFont, myBrush)
                    Call gwt_comm.DrawStringInBoxLeft(e, (x1 + 230), yBank, 170, 80, strSplitAccounts(2), prFont, myBrush)
                    Call gwt_comm.DrawStringInBoxLeft(e, (x1 + 405), yBank, 100, 80, strSplitAccounts(3), prFont, myBrush)
                    yBank = yBank + 12
                    e.Graphics.DrawLine(myPen, x1 - 10, yBank, 610, yBank)
                    yBank = yBank + 3
                Next

            End If



            Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, prFont, Brushes.Black)
            'Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 80, 600, 80, "OUR BANK DETAILS : " & UCase(strCompanyBankName) & " ACCOUNT NO : " & UCase(strCompanyAccountNumber) & " BANK CODE : " & UCase(strCompanyBranchCode), tlFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", prFont, Brushes.Black)
            ' ''Print the terms and conditions

            y1 += 100
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 300, 80, "TERMS AND CONDITIONS ", tlFont, Brushes.Black)
            y1 += 20
            For np As Integer = 0 To arrConditionsOfSale.Count - 1
                Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 550, 80, arrConditionsOfSale.Item(np), prFont, Brushes.Black)
                y1 = y1 + 15
            Next

            e.HasMorePages = False
            Me.boolPrintFromPreview = True

        End If
    End Sub

    Private Sub GenerateTransactionDocument(ByVal intDocumentNumber As Integer)
        'get invoice number
        On Error GoTo RaiseErr
        Dim n As Integer = 0
        Dim dbReader As Data.OleDb.OleDbDataReader
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim strCustomerNumber As String = Nothing

        myCommand = New Data.OleDb.OleDbCommand("Select CONVERT(NVARCHAR, TransDate, 105) as [TransDate], Amount, Taxes, " _
            & "Discount, CustomerId, SalesRep FROM SalesMain Where InvoiceNumber = " & intDocumentNumber & "", cnn)
        dbReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            Dim strDateparts() As String = Split(dbReader(0).ToString, "-")
            If Not IsDBNull(dbReader(0).ToString) Then strDate = CDate(strDateparts(0) & "-" & MonthName(CInt(strDateparts(1)), True) & "-" & strDateparts(2))
            If IsNumeric(dbReader(1).ToString) Then dblInvoiceTotal = CDbl(dbReader(1).ToString) Else dblInvoiceTotal = 0
            If IsNumeric(dbReader(2).ToString) Then dblTaxes = dbReader(2).ToString Else dblTaxes = 0
            If IsNumeric(dbReader(3).ToString) Then dblDiscounts = dbReader(3).ToString Else dblDiscounts = 0
            'If Not IsDBNull(dbReader(4).ToString) Then strCustomerNumber = dbReader(4).ToString
            If Not IsDBNull(dbReader("SalesRep").ToString) Then strSalesRep = dbReader("SalesRep").ToString
        End If
        dbReader.Close()

        myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity, ItemCode, Description +' * '+ CONVERT(NVARCHAR, SerialNumbers) as [Description], SalesPrice, " _
            & "DiscountAllowed, Taxes, (((SalesPrice * Quantity) - DiscountAllowed) + Taxes) AS [Payable] " _
            & "from Sales where InvoiceNumber = " & intDocumentNumber & "", cnn)
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
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Cash receipt Generation Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEditQuantity_Click(sender As System.Object, e As System.EventArgs) Handles btnEditQuantity.Click
        boolAbort = False
        dblPublicQuantityFilterMinimum = 0
        Dim frm As New frmSalesQuantityUpdate
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        On Error GoTo RaiseErr
        Dim intTrans As Integer = CInt(dGrid.CurrentRow.Cells(dGrid.ColumnCount - 1).Value.ToString)
        Dim strSql As String = "UPDATE Sales SET Quantity = " & dblPublicQuantityFilterMinimum & ", " _
            & "Taxes = (Taxes * " & dblPublicQuantityFilterMinimum & ") WHERE TransactionId = " & intTrans & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Dim dblAmount As Double = 0
        Dim dblTaxes As Double = 0
        Dim dblDiscounts As Double = 0

        strSql = "SELECT SUM(SalesPrice * Quantity), SUM(Taxes), SUM(DiscountAllowed) FROM Sales WHERE InvoiceNumber = " & intSelectedTransaction & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then dblAmount = CDbl(objReader(0).ToString)
            If IsNumeric(objReader(1).ToString) Then dblTaxes = CDbl(objReader(1).ToString)
            If IsNumeric(objReader(2).ToString) Then dblDiscounts = CDbl(objReader(2).ToString)
        End If
        objReader.Close()
        'Update the sales main table as well
        strSql = "UPDATE SalesMain SET Amount = " & dblAmount & ", Taxes = " & dblTaxes & ", Discount = " & dblDiscounts & " " _
            & "WHERE InvoiceNumber = " & intSelectedTransaction & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Quantity has been changed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadFormData()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Cash receipt Generation Error"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class