Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmOrdersPlacement

    Dim strMainDetails As String
    Dim arrPrintDetails As ArrayList

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

    Private Sub frmOrdersPlacement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dGrid.Rows.Add(150)
        AlternateColors()
        LoadPersonnel()
        If boolEditStatus = False Then
            txtOrderNumber.Text = CStr(gwt_comm.GetNextDocumentNumber("Orders"))
        Else
            LoadSelectedOrder()
        End If
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

    'Private Sub frmOrdersPlacement_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    If Me.WindowState <> FormWindowState.Minimized Then
    '        Me.Width = 652
    '        Me.Height = 472
    '    End If
    'End Sub

    Private Sub btnAddSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSupplier.Click
        boolEditStatus = False
        Dim f As New frmSupplierDetails
        f.ShowDialog()
        'The new account becomes the active account
    End Sub

    Private Sub dGrid_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dGrid.RowsRemoved
        Dim iBal As Integer = 150 - dGrid.Rows.Count
        dGrid.Rows.Add(iBal)
        AlternateColors()
        ComputeTotals()
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 0 To dGrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
                dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub txtNotes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNotes.KeyPress
        If Asc(e.KeyChar) = 13 Then e.Handled = True
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        strPublicItemCode = Nothing
        strPublicItemDescription = Nothing
        txtAccountNo.Text = Nothing
        txtAccountName.Text = Nothing
        boolAbort = False
        gwt_comm.SupplierSearch()
        If boolAbort = True Then Exit Sub
        txtAccountNo.Text = strPublicItemCode
        txtAccountName.Text = strPublicItemDescription
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        With dGrid
            If .CurrentCell.ColumnIndex = 1 Or .CurrentCell.ColumnIndex = 2 Then
                If Not IsNumeric(.CurrentCell.Value) Then
                    MessageBox.Show("Please enter a numeric value in this column. Value will be reset to zero",
                        "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    .CurrentCell.Value = "0.00"
                Else
                    If .CurrentCell.ColumnIndex = 2 Then
                        .CurrentCell.Value = Format(CDbl(.CurrentCell.Value.ToString), "##0.00")
                    End If
                End If
                On Error Resume Next
                .CurrentRow.Cells(.ColumnCount - 1).Value = Format((CDbl(.CurrentRow.Cells(.ColumnCount - 2).Value.ToString) * CDbl(.CurrentRow.Cells(.ColumnCount - 3).Value.ToString)), "##0.00")
                ComputeTotals()
            End If
        End With
    End Sub

    Private Sub ComputeTotals()
        With dGrid
            Dim dblTotal As Double = 0
            For i As Integer = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "")) Then
                    If IsNumeric(Convert.ToString(.Rows(i).Cells(3).Value)) Then
                        dblTotal = dblTotal + CDbl(Convert.ToString(.Rows(i).Cells(3).Value))
                    End If
                End If
            Next
            txtTotal.Text = Format(dblTotal, "##0.00")
        End With
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If IntPublicReceiveGoods <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountName.Text) Or String.IsNullOrEmpty(txtAccountNo.Text) Then
            MessageBox.Show("Please enter the supplier details", "Missing Supplier Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNo.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboPersonnel.Text) Then
            MessageBox.Show("Please enter the details", "Missing Buyer Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPersonnel.Focus()
            Exit Sub
        End If
        If CDbl(txtTotal.Text) = 0 Then
            If MessageBox.Show("The orders total is zero. Are you sure you want to proceed?", "Zero Amount Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                SaveOrder()
            Else
                Exit Sub
            End If
        Else
            SaveOrder()
        End If
        Me.Close()
    End Sub

    Private Sub SaveOrder()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If boolEditStatus = True Then
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM PurchasesOrderDetails where OrderNumber = " & txtOrderNumber.Text & "", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM PurchasesOrderMain where OrderNumber = " & txtOrderNumber.Text & "", cnn)
            objCommand.ExecuteNonQuery()
        End If

        strSql = "INSERT INTO PurchasesOrderMain ([OrderNumber], [TransDate], [Buyer], " _
            & "[AccountNumber], [AccountHolder], [Value], [Notes], [UserName], [ChangeDate]) VALUES " _
            & "(" & CDbl(txtOrderNumber.Text) & ", '" & gwt_comm.shortMonthDateFormat(dpDate.Value) & "', " _
            & "'" & cboPersonnel.Text & "', '" & txtAccountNo.Text & "', '" & txtAccountName.Text & "', " _
            & "" & CDbl(txtTotal.Text) & ", '" & txtNotes.Text & "', '" & strUserName & "', '" & Now & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Inser the transaction
        With dGrid
            For i As Integer = 0 To dGrid.Rows.Count - 1

                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then
                    Dim strOrderDescription As String = .Rows(i).Cells(0).Value.ToString
                    Dim intQuantity As Integer = 1
                    Dim dblUnitPrice As Double = 0
                    If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "")) Then
                        If IsNumeric(.Rows(i).Cells(1).Value.ToString) Then
                            intQuantity = CLng(.Rows(i).Cells(1).Value.ToString)
                        End If
                    End If
                    If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "")) Then
                        If IsNumeric(.Rows(i).Cells(2).Value.ToString) Then
                            dblUnitPrice = CDbl(.Rows(i).Cells(2).Value.ToString)
                        End If
                    End If
                    strSql = "INSERT INTO PurchasesOrderDetails ([OrderNumber], [ItemDetails], [Quantity], [UnitPrice]) VALUES " _
                        & "(" & CDbl(txtOrderNumber.Text) & ", '" & strOrderDescription & "', " & intQuantity & ", " & dblUnitPrice & ")"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            Next
        End With

        boolAbort = False
        GenerateTransactionDocument(CLng(txtOrderNumber.Text))

        If boolAbort = True Then Exit Sub

        UpdateDocumentNumber()
        If boolAbort = True Then Exit Sub

        ppd.Document = pdOrders
        ppd.ShowDialog()

        MessageBox.Show("Order saved successfully", "Order Processing Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Order Insert Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub UpdateDocumentNumber()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET Orders = " & CLng(txtOrderNumber.Text) & "", cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Order Document Number Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Public Sub GenerateTransactionDocument(ByVal orderNumber As Long)
        On Error GoTo RaiseErr

        'Get the order main details
        Dim strAccountNumber As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "[AccountNumber], [AccountHolder], [Value], [Notes], [Buyer] FROM PurchasesOrderMain WHERE OrderNumber = " & txtOrderNumber.Text & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(1).ToString) Then strAccountNumber = objReader(1).ToString
            strMainDetails = objReader(0) & "|" & objReader(1) & "|" & objReader(2) & "|" & objReader(3) & "|" & objReader(4) & "|" & objReader(5)
        Else
            objReader.Close()
            MessageBox.Show("There is a problem printing this order. Missing key details",
                "Missing Key Order Details", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            boolAbort = True
            Exit Sub
        End If
        objReader.Close()

        'Get the order transactions
        arrPrintDetails = New ArrayList
        objCommand = New Data.OleDb.OleDbCommand("SELECT [ItemDetails], [Quantity], [UnitPrice] " _
            & "FROM PurchasesOrderDetails WHERE OrderNumber = " & txtOrderNumber.Text & "", cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            arrPrintDetails.Add(objReader(0).ToString & "|" & objReader(1).ToString & "|" & objReader(2).ToString)
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to print the order"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub pdOrders_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdOrders.PrintPage

        If boolPrintFromPreview = True Then
            'requery records
            boolAbort = False
            Me.GenerateTransactionDocument(CDbl(txtOrderNumber.Text))
            If boolAbort = True Then Exit Sub
            boolPrintFromPreview = False
        End If
        Dim strDType As String
        strDType = UCase(strOrderHeader)
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
        g.DrawString(UCase(strOrderHeader), New Font("Arial", 16, FontStyle.Bold), New SolidBrush(Color.FromArgb(255, Color.Black)), 350, e.PageBounds.Top + 110)
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
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, fntHeaderFont, Brushes.Black)
        y1 = y1 + 20

        If Not String.IsNullOrEmpty(strCompanyAddress1) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress1, fntDetailsFont, Brushes.Black)
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.", fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyBPNumber), fntDetailsFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "BP NO.", fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyBPNumber), fntDetailsFont, Brushes.Black)
                y1 = y1 + 15
            End If
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress2) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress2, fntDetailsFont, Brushes.Black)
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO.", fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyVatNumber), fntDetailsFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO.", fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, 480, y1, 250, 80, UCase(strCompanyVatNumber), fntDetailsFont, Brushes.Black)
            End If
            y1 = y1 + 15
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress3) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress3, fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyAddress4) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress4, fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyTelephone) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "PHONE", fntDetailsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 250, 80, UCase(strCompanyTelephone), fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        'strCompanyContactCellNumber
        If Not String.IsNullOrEmpty(strCompanyContactCellNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 550, 80, "CELL NO", fntDetailsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 550, 80, UCase(strCompanyContactCellNumber), fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyFaxNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "FAX NO.", fntDetailsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 250, 80, UCase(strCompanyFaxNumber), fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyEmailAddress) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "E-MAIL", fntDetailsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, 170, y1, 250, 80, strCompanyEmailAddress, fntDetailsFont, Brushes.Black)
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
        e.Graphics.DrawString("SUPPLIER DETAILS", fntHeaderFont, Brushes.Black, x1, y1)
        e.Graphics.DrawString("TRANSACTION DETAILS", fntHeaderFont, Brushes.Black, 500, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 15
        'e.Graphics.DrawString("VAT No.: " & strSupplierVatNumber, fntDetailsFont, Brushes.Black, x1, y1)
        'y1 = y1 + 15
        If strSupplierName.Length > 58 Then strSupplierName = Mid(strSupplierName, 1, 58)
        e.Graphics.DrawString(UCase(strSupplierName), fntDetailsFont, Brushes.Black, x1, y1)

        'Print the date
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "DATE", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(gwt_comm.shortMonthDateFormat(dpDate.Value)), fntDetailsFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "VAT NO.", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(strSupplierVatNumber), fntDetailsFont, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress1, fntDetailsFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress2, fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "ORDER NO.", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, Format(CLng(txtOrderNumber.Text), "000000"), fntDetailsFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress3, fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "BUYER", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 580, y1, 300, 80, UCase(cboPersonnel.Text), fntDetailsFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strSupplierAddress4, fntDetailsFont, Brushes.Black)
        y1 += 15
        e.Graphics.DrawString("PHONE :" & strSupplierTelephone & " Email : " & strSupplierEmailAddress, fntDetailsFont, Brushes.Black, x1, y1)
        y1 = y1 + 30
        e.Graphics.DrawLine(Pens.Black, x1 - 10, y1, p1 + 100, y1)
        y1 = y1 + 20
        'print captions
        Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 60, 80, "QTY", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 480, 80, "DESCRIPTION", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, "UNIT PRICE", fntHeaderFont, Brushes.Black)
        'Call DrawStringInBoxRight(e, X4, y1, 120, 80, "TAX", fntHeaderFont, Brushes.Black)
        'Call DrawStringInBoxRight(e, X5, y1, 120, 80, "DISCOUNT", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, "TOTAL", fntHeaderFont, Brushes.Black)
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
            Dim strUnitPriceBeforeTax As String = "0.00"
            Dim strTaxAmount As String = "0.00"
            Dim strDiscountAmount As String = "0.00"
            Dim strUnitPrice As String = "0.00"
            Dim strPayableAfterTax As String = "0.00"
            Dim strPrintQuantity As String = "0"
            Dim strPrintPrice As String = "0.00"

            'Quantity
            If Not strBuffer(1) Is Nothing Then strValue = strBuffer(1) Else strValue = "0"
            strPrintQuantity = strValue
            'Unit Price
            If Not strBuffer(2) Is Nothing Then strValue = CStr(Format(CDbl(strBuffer(2)), "#,##0.00")) Else strValue = "0.00"
            strUnitPrice = strValue
            strPrintPrice = Format(CDbl(strUnitPrice) * CDbl(strPrintQuantity), "#,##0.00")
            strPayableAfterTax = Format((CDbl(strUnitPrice) * CDbl(strPrintQuantity)), "#,##0.00")

            'QUANTITY PRINTING
            Call gwt_comm.DrawStringInBoxCenter(e, x1, y1, 50, 60, strPrintQuantity, fntDetailsFont, Brushes.Black)
            'UNIT PRICE PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, X5, y1, 120, 80, strPrintPrice, fntDetailsFont, Brushes.Black)
            'LINE TOTAL PRINTING
            Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, strPayableAfterTax, fntDetailsFont, Brushes.Black)

            'Print the description last as it is the column that will determine the next line position
            If Not strBuffer(0) Is Nothing Then strValue = strBuffer(0) Else strValue = ""
            Call gwt_comm.DrawStringInBoxLeft(e, x2, y1, 480, 80, strValue, fntDetailsFont, Brushes.Black)

            'Get the size of the address box
            e.Graphics.MeasureString(strValue, fntDetailsFont, New SizeF(200, 80), New StringFormat(), cols, lines)
            Yc = y1
            y1 = y1 + lines * fntDetailsFont.Height + 5
            y1 = Math.Max(y1, Yc)

            itm = itm + 1 : Dim i As Integer = 0
            If itm = 23 Then
                'Print the page number of the statement
                Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, fntDetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", fntHeaderFont, Brushes.Black)
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
            Call gwt_comm.DrawStringInBoxLeft(e, x1, y1, 120, 80, "TOTALS ", fntHeaderFont, Brushes.Black)

            Call gwt_comm.DrawStringInBoxRight(e, X6, y1, 120, 80, Format(CDbl(txtTotal.Text), "#,##0.00"), fntHeaderFont, Brushes.Black)

            Call gwt_comm.DrawStringInBoxLeft(e, x1, e.PageBounds.Bottom - 50, 120, 80, "Page " & intPage, fntDetailsFont, Brushes.Black)
            'Call DrawStringInBoxLeft(e, X6 - 50, e.PageBounds.Bottom - 50, 200, 80, "powered by brainco intelligency", fntHeaderFont, Brushes.Black)

            'Print the notes

            y1 = y1 + 45
            reccurrent = New Rectangle(x1 + 5, y1, 300, 100)
            e.Graphics.DrawRectangle(Pens.Gray, reccurrent)
            Call gwt_comm.DrawStringInBoxLeft(e, (x1 + 5), y1 + 3, 120, 80, "NOTES", fntHeaderFont, Brushes.Black)
            y1 = y1 + 25
            Call gwt_comm.DrawStringInBoxLeft(e, (x1 + 5), y1, 280, 145, txtNotes.Text, fntDetailsFont, Brushes.Black)

            e.HasMorePages = False
            Me.boolPrintFromPreview = True

        End If

    End Sub

    Private Sub LoadSelectedOrder()
        On Error GoTo RaiseErr
        txtOrderNumber.Text = intSelectedTransaction
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "[AccountNumber], [AccountHolder], [Value], [Notes], [Buyer] FROM PurchasesOrderMain WHERE " _
            & "OrderNumber = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("AccountNumber").ToString) Then txtAccountNo.Text = objReader("AccountNumber").ToString
            If Not IsDBNull(objReader("AccountHolder").ToString) Then txtAccountName.Text = objReader("AccountHolder").ToString
            If Not IsDBNull(objReader("Buyer").ToString) Then cboPersonnel.Text = objReader("Buyer").ToString
            If IsNumeric(objReader("Value").ToString) Then txtTotal.Text = Format(CDbl(objReader("Value").ToString), "##0.00")
            If Not IsDBNull(objReader("Notes").ToString) Then txtNotes.Text = objReader("Notes").ToString
        End If
        objReader.Close()

        objCommand = New Data.OleDb.OleDbCommand("SELECT [ItemDetails], [Quantity], [UnitPrice] " _
            & "FROM PurchasesOrderDetails WHERE OrderNumber = " & intSelectedTransaction & "", cnn)
        objReader = objCommand.ExecuteReader

        Dim p As Integer = 0
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(p).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(p).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGrid.Rows(p).Cells(2).Value = objReader(2).ToString
            If IsNumeric(objReader(1).ToString) And IsNumeric(objReader(2).ToString) Then
                dGrid.Rows(p).Cells(3).Value = Format((CDbl(objReader(1).ToString) * CDbl(objReader(2).ToString)), "##0.00")
            End If
            p = p + 1
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On selected order details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function SearchSupplier(ByVal AccountNumber As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AccountName, AccountNumber FROM Suppliers WHERE AccountNumber Like '%" & AccountNumber & "%'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = UCase(objReader(0).ToString)
            'txtAccountNo.Text = objReader(1).ToString
            'txtAccountNo.Select(2, 3)
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On selected order details load"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub txtAccountNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountNo.KeyPress
        Dim strSearch As String = txtAccountNo.Text & e.KeyChar
        txtAccountName.Text = SearchSupplier(strSearch)
    End Sub

    Private Sub btnAddFromInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFromInventory.Click
        arrSelectedItems = Nothing
        Dim f As New frmOrderFromInventory
        f.ShowDialog()
        If arrSelectedItems.Count > 0 Then
            AddInventoryItems()
        End If
    End Sub

    Private Sub AddInventoryItems()
        Dim intLastRow As Integer = 0
        For i As Integer = 0 To arrSelectedItems.Count - 1
            For p As Integer = intLastRow To dGrid.Rows.Count - 1
                If (Object.Equals(Convert.ToString(dGrid.Rows(p).Cells(0).Value), "")) Then
                    Dim strBuffer() As String = Split(arrSelectedItems.Item(i), "|")
                    dGrid.Rows(p).Cells(0).Value = strBuffer(1)
                    dGrid.Rows(p).Cells(1).Value = "1"
                    dGrid.Rows(p).Cells(2).Value = strBuffer(2)
                    dGrid.Rows(p).Cells(3).Value = strBuffer(2)
                    intLastRow = p
                    Exit For
                End If
            Next
        Next
        ComputeTotals()
    End Sub

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
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

End Class