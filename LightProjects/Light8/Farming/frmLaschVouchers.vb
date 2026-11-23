Public Class frmLaschVouchers

    Dim fntFinePrintFont As New Font("Arial", 6, FontStyle.Regular)
    Dim HeadingFont As New Font("Arial", 12, FontStyle.Bold)
    Dim SubHeadingFont As New Font("Arial", 7, FontStyle.Bold)
    Dim fntFooter As New Font("Arial", 6, FontStyle.Bold)
    Dim fntPrintFont As New Font("Arial", 7, FontStyle.Regular)

    Dim strHeaderFontName As String = "Arial"
    Dim strFooterFontName As String = "Arial"
    Dim strDetailFontName As String = "Arial"

    Dim intHeaderFontSize As Integer = 8
    Dim intFooterFontSize As Integer = 6
    Dim intDetailFontSize As Integer = 8

    Dim strHeaderFontFullNames As String = Chr(34) & "Arial" & Chr(34) & ", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point"
    Dim strFooterFontFullNames As String = Chr(34) & "Arial" & Chr(34) & ", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point"
    Dim strDetailFontFullNames As String = Chr(34) & "Arial" & Chr(34) & ", 6, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point"

    Dim strFooterForeColor As String = "Black"
    Dim strHeaderForeColor As String = "Black"
    Dim strDetailForeColor As String = "Black"

    Dim strGridLinesColor As String = "Black"
    Dim boolVerticalLines As Boolean = False
    Dim boolHorizontalLines As Boolean = False

    Dim X1, X2, X3, X4, X5, X6 As Integer
    Dim W1, W2, W3, W4, W5, W6 As Integer
    Dim Y As Integer
    Public itm As Integer = 0
    Dim nz As Integer 'item l
    Dim arrPrintDetails As ArrayList

    Dim intDocumentNumber As Integer = 0
    Dim boolLoading As Boolean

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

    Private Sub dGrid_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If boolLoading = True Then Exit Sub
        With dGrid
            Dim dblTotal As Double = 0
            If e.ColumnIndex = 3 Then
                If IsNumeric(.CurrentCell.Value) Then
                    .CurrentCell.Value = Format(CDbl(.CurrentCell.Value), "##0.00")
                Else
                    .CurrentCell.Value = "0.00"
                End If
                ComputeTotal()
            End If
        End With
    End Sub

    Private Sub ComputeTotal()
        Dim dblTotal As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    dblTotal = dblTotal + CDbl(dGrid.Rows(i).Cells(2).Value.ToString)
                End If
            End If
        Next
        'txtAmount.Text = Format(dblTotal, "##0.00")
    End Sub

    Private Sub cboName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboName.SelectedIndexChanged
        On Error Resume Next
        txtAccountHolderNumber.Text = ""
        txtAccountHolderNumber.Text = cboName.SelectedItem.Col2
        LoadSlectedCustomerDetails(txtAccountHolderNumber.Text)
    End Sub

    Private Sub LoadSlectedCustomerDetails(AccountNumber As String)
        On Error GoTo RaiseErr
        lblAddress1.Text = ""
        lblAddress2.Text = ""
        lblAddress3.Text = ""
        lblAddress4.Text = ""
        lblDistrict.Text = ""
        lblFarmType.Text = ""
        lblIdNumber.Text = ""
        lblProvince.Text = ""
        txtAccountHolderNumber.Text = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM LaschCustomers WHERE AccountNumber = '" & AccountNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("Address1").ToString) Then lblAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then lblAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then lblAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then lblAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("District").ToString) Then lblDistrict.Text = objReader("District").ToString
            If Not IsDBNull(objReader("Province").ToString) Then lblProvince.Text = objReader("Province").ToString
            If Not IsDBNull(objReader("FarmType").ToString) Then lblFarmType.Text = objReader("FarmType").ToString
            If Not IsDBNull(objReader("IdNumber").ToString) Then lblIdNumber.Text = objReader("IdNumber").ToString
            txtAccountHolderNumber.Text = AccountNumber
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " On customers details load"
        ShowErrorMessage()
    End Sub

    Private Sub CustomerLoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT LastName +' '+FirstName +' '+ OtherNames +';'+ AccountNumber AS [Customer] " _
            & "FROM LaschCustomers ORDER BY LastName, FirstName, OtherNames"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        'Set up the drop down combo box
        Dim intWidth As Integer = cboName.Width - 50
        With cboName
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "250;80"
        End With

        'Get a count of the items
        Dim intItemsCount As Double = 0

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(AccountNumber) FROM LaschCustomers", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()

        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboName.Items.Clear()
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
            cboName.SelectedIndex = -1
            cboName.Items.Clear()
            cboName.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboName.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " On customers details load"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub pdSmallPayslips_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdSmallPayslips.PrintPage

        On Error GoTo RaiseErr
        
        HeadingFont = New Font("Arial", 7, FontStyle.Regular)
        Dim intStatsCount As Integer = 0
        Dim eLineCnt As Integer, dLineCnt As Integer, sLineCnt As Integer
        Dim intX1, intX2, intY1, intY2 As Integer
        intLeftMargin = 50 : intRightMargin = 100 : intTopMargin = 40 : intBottomMargin = 40
        intX1 = intLeftMargin ' e.PageBounds.Left + 50
        intX2 = e.PageBounds.Right - intRightMargin
        intY1 = intTopMargin ' e.PageBounds.Top + 100
        intY2 = 500 'e.PageBounds.Bottom - intBottomMargin
        nz = 0

        Dim str As String
        Dim strAmt As String
        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        'Draw the main border
        Dim sbCurrent As SolidBrush 'penCurrent As Pen
        reccurrent = New Rectangle(intX1, intY1, (intX2 - 43), intY2)
        If boolDrawBorders = True Then e.Graphics.DrawRectangle(Pens.Navy, reccurrent)
        Dim intRectangleWidth As Integer = reccurrent.Width


        'Print the company logo as a watermark
        If Not String.IsNullOrEmpty(strCompanyLogoPath) Then
            If System.IO.File.Exists(strCompanyLogoPath) Then
                Dim picPrint As New PictureBox
                picPrint.SizeMode = PictureBoxSizeMode.AutoSize
                picPrint.Load(strCompanyLogoPath)
                Dim R As New Rectangle(390, 280, picPrint.Width, picPrint.Height)
                'Dim R As New Rectangle(20, 20, picPrint.Width, picPrint.Height)
                e.Graphics.DrawImage(picPrint.Image, R)
            End If
        End If

        '*** Start Printing and drawing the prefixed item
        '*** the value start position of x = intX1 and that of y = intY1

        'Print the pay advice header
        If boolDrawBorders = True Then Call DrawStringInBoxLeft(e, intX1, intY1 - 30, intX1 + 200, intY1 - 30, "DELIVERY NOTE VOUCHER", HeadingFont, Brushes.Black)
        If boolDrawBorders = True Then Call DrawStringInBoxLeft(e, intX1 + 400, intY1 - 30, intX1 + 600, intY1 - 30, "DOCUMENT NO: " & Format(CDbl(lblRef.Text), "000000"), HeadingFont, Brushes.Black)
        'Print the company name and the pay date the same font as that for document no
        e.Graphics.DrawString(UCase(strCompanyName), HeadingFont, System.Drawing.Brushes.Black, intX1 + 1, intTopMargin + 10)
        e.Graphics.DrawString(UCase(Format(dtPayslip, "dd-MMM-yyyy")), HeadingFont, System.Drawing.Brushes.Black, intX1 + 570, intTopMargin + 10)
        'Draw the 3 lines after
        intY1 = intY1 + 40
        If boolDrawBorders = True Then e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)
        'Print the headers
        intY1 = intY1 + 5
        If boolDrawBorders = True Then
            With e.Graphics
                e.Graphics.DrawLine(System.Drawing.Pens.Navy, intX1 + 600, intY1 + 60, _
                                intX1 + 600, intY2 + 41)
            End With
        End If

        'Write the farmer details here
        Call DrawStringInBoxLeft(e, intX1, intY1, intX1 + 500, intY1, "FARMER     : " & UCase(cboName.Text), HeadingFont, Brushes.Black)
        intY1 = intY1 + 15
        Call DrawStringInBoxLeft(e, intX1, intY1, intX1 + 500, intY1, "ID NUM     : " & UCase(lblIdNumber.Text), HeadingFont, Brushes.Black)
        intY1 = intY1 + 15
        Call DrawStringInBoxLeft(e, intX1, intY1, intX1 + 500, intY1, "PROVINCE   : " & UCase(lblProvince.Text), HeadingFont, Brushes.Black)
        intY1 = intY1 + 15
        Call DrawStringInBoxLeft(e, intX1, intY1, intX1 + 500, intY1, "DISTRICT   : " & UCase(lblDistrict.Text), HeadingFont, Brushes.Black)

        'Draw the horizontal lines for the employment and earnings and deduction sections
        intY1 = intY1 + 15
        'If boolDrawBorders = True Then e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)
        'intY1 = intY1 + 40
        If boolDrawBorders = True Then e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)
        intY1 = intY1 + 30
        If boolDrawBorders = True Then e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)
        'Print column headers at - 20 the value of y
        If boolDrawBorders = True Then e.Graphics.DrawString("DESCRIPTION", SubHeadingFont, Brushes.Navy, intX1 + 1, intY1 - 20)
        If boolDrawBorders = True Then e.Graphics.DrawString("PACKAGE", SubHeadingFont, Brushes.Navy, intX1 + 423, intY1 - 20)
        'If boolDrawBorders = True Then e.Graphics.DrawString("QTY", SubHeadingFont, Brushes.Navy, intX1 + 323, intY1 - 20)
        'If boolDrawBorders = True Then e.Graphics.DrawString("DEDUCTIONS", SubHeadingFont, Brushes.Navy, intX1 + 406, intY1 - 20)
        If boolDrawBorders = True Then e.Graphics.DrawString("QTY", SubHeadingFont, Brushes.Navy, intX1 + 628, intY1 - 20)
        'Print the totals row header
        Dim intTotalsYaxis As Integer = intY1 + 240
        'We begin printing the individual pay details
        '*******************************************************************************************
        '
        intY1 = intY1 + 15

        For i As Integer = 0 To arrPrintDetails.Count - 1
            Dim strBuffer() As String = Split(arrPrintDetails.Item(i), "|")
            str = strBuffer(0)
            Call DrawStringInBoxLeft(e, intX1, intY1, W1, 150, str, fntPrintFont, Brushes.Black)
            'Print pack
            str = strBuffer(1)
            Call DrawStringInBoxRight(e, intX1 + 503, intY1, W1, 100, str, fntPrintFont, Brushes.Black)
            'Print quantity
            strAmt = CStr(Format(CDbl(strBuffer(2)), "#,##0.00"))
            Call DrawStringInBoxRight(e, intX1 + 680, intY1, W1, 100, strAmt, fntPrintFont, Brushes.Black)
            intY1 = intY1 + 15
        Next


        'Call DrawStringInBoxLeft(e, intX1 + 306, intY1 + 615, W1, 250, UCase(strCompanyName), fntFooter, Brushes.Black)
        'Call DrawStringInBoxLeft(e, intX1 + 306, intY1 + 630, W1, 250, UCase(strCompanyAddress1), fntFooter, Brushes.Black)
        'Call DrawStringInBoxLeft(e, intX1 + 306, intY1 + 645, W1, 250, UCase(strCompanyAddress2), fntFooter, Brushes.Black)
        'Call DrawStringInBoxLeft(e, intX1 + 306, intY1 + 660, W1, 250, UCase(strCompanyAddress3), fntFooter, Brushes.Black)
        'Call DrawStringInBoxLeft(e, intX1 + 306, intY1 + 675, W1, 250, UCase(strCompanyAddress4), fntFooter, Brushes.Black)
        'Call DrawStringInBoxLeft(e, intX1 + 306, intY1 + 690, W1, 250, UCase(strCompanyTelephone), fntFooter, Brushes.Black)

        e.HasMorePages = False

        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Voucher Print"
        ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        'Save and print details

        If String.IsNullOrEmpty(txtAccountHolderNumber.Text) Then
            MessageBox.Show("Please select the correct account name", "Invalid Account Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboName.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboName.Text) Then
            MessageBox.Show("Please select the correct account name", "Invalid Account Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboName.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(lblIdNumber.Text) Then
            MessageBox.Show("The customer ID Number is not correct. This value is required", "Invalid ID Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboName.Focus()
            Exit Sub
        End If

        Dim intNextDocumentNumber As Integer = GetNextDocumentNumber("LaschVouchers")
        lblRef.Text = intNextDocumentNumber
        Dim strDate As String = Format(dpTransDate.Value, "dd-MMM-yyyy")
        arrPrintDetails = New ArrayList
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1
                Dim strItemCode As String = Nothing
                Dim strDesdription As String = Nothing
                Dim strPack As String = Nothing
                Dim dblQuantity As Double = 0
                If Not Object.Equals(.Rows(i).Cells(0).Value, Nothing) Then
                    If Not Object.Equals(.Rows(i).Cells(1).Value, Nothing) Then
                        If Not Object.Equals(.Rows(i).Cells(2).Value, Nothing) Then
                            If IsNumeric(.Rows(i).Cells(3).Value) Then
                                strItemCode = .Rows(i).Cells(0).Value.ToString
                                strDesdription = .Rows(i).Cells(1).Value.ToString
                                strPack = .Rows(i).Cells(2).Value.ToString
                                dblQuantity = CDbl(.Rows(i).Cells(3).Value.ToString)
                                Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO LaschVouchers " _
                                    & "(AccountNumber, TransDate, ItemCode, Description, Pack, Quantity, UserName, DocumentNumber) VALUES " _
                                    & "('" & txtAccountHolderNumber.Text & "', '" & strDate & "', '" & strItemCode & "', " _
                                    & "'" & strDesdription & "', '" & strPack & "', " & dblQuantity & ", '" & strUserName & "', " & lblRef.Text & ")", cnn)
                                objCommand.ExecuteNonQuery()
                                arrPrintDetails.Add(strDesdription & "|" & strPack & "|" & dblQuantity)
                            End If
                        End If
                    End If
                End If
            Next
        End With

        'Update control numbers
        Dim objComUpdate As New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET LaschVouchers = " & lblRef.Text & "", cnn)
        objComUpdate.ExecuteNonQuery()

        boolDrawBorders = True
        ppd.Document = pdSmallPayslips
        ppd.ShowDialog()
        dGrid.Rows.Clear()
        dGrid.Rows.Add(15)

        cboName.Text = ""
        lblAddress1.Text = ""
        lblAddress2.Text = ""
        lblAddress3.Text = ""
        lblAddress4.Text = ""
        lblDistrict.Text = ""
        lblProvince.Text = ""
        lblFarmType.Text = ""
        lblIdNumber.Text = ""
        lblRef.Text = "0"
        txtAccountHolderNumber.Text = Nothing

        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Voucher Print"
        ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub frmLaschVouchers_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        boolLoading = True
        CustomerLoadData()
        dGrid.Rows.Add(15)
        dpTransDate.Visible = True
        boolLoading = False
    End Sub

    Private Sub chkOverideDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverideDate.CheckedChanged
        If chkOverideDate.Checked = True Then
            If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
                pnlDate.Enabled = True
                dpTransDate.Enabled = True
            Else
                boolAbort = False
                boolAuthorized = False
                Dim f As New frmSupervisorAuthorizaton
                f.ShowDialog()
                If boolAbort = True Then
                    chkOverideDate.Checked = False
                    Exit Sub
                End If
                If boolAuthorized = True Then
                    pnlDate.Enabled = True
                    dpTransDate.Enabled = True
                    boolAuthorized = False
                End If
            End If
        Else
            pnlDate.Enabled = False
            dpTransDate.Enabled = False
            boolAuthorized = False
        End If
    End Sub

End Class
