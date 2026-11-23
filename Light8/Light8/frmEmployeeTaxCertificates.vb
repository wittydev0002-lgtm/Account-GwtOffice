Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmEmployeeTaxCertificates

    Dim itm As Integer = 0
    Dim strStartDate As String = Nothing
    Dim strEndDate As String = Nothing
    Dim nz As Integer = 0
    Dim sPayslipLineText() As String
    Dim strPayslipColumnType As String
    Dim intPrintValues(0 To 999) As Double
    Dim arrMaster As ArrayList
    Dim intAidsLevyCode As Integer = 0

    Dim lngSalary As Double
    Dim lngTax As Double
    Dim lngSerialNumbers As Double

    'Declare and set the default fonts
    Dim fntPrintFont As New Font("Verdana", 7, FontStyle.Regular)
    Dim titleFont As New Font("Verdana", 8, FontStyle.Regular)
    Dim HeadingFont As New Font("Verdana", 7, FontStyle.Regular)
    Dim fntSmallPrintFont As New Font("Verdana", 7, FontStyle.Regular)
    Dim fntFinePrintFont As New Font("Verdana", 6, FontStyle.Regular)
    Dim fntSmallPrintFontRegular As New Font("Verdana", 7, FontStyle.Regular)
    Dim SubHeadingFont As New Font("Verdana", 6, FontStyle.Bold)
    Dim fntFooter As New Font("Verdana", 6, FontStyle.Bold)
    Dim ItalicFont As New Font("Verdana", 6, FontStyle.Italic)
    Dim SuperHeading As New Font("Verdana", 12, FontStyle.Bold)


    Dim strCurrentEmployeeBeingProcessed As String
    Dim strCurrentEmployeeBankDetails As String
    Dim strCurrentEmployeeBeingProcessedArray() As String
    Dim strCurrentEmployeeBankDetailsArray() As String
    Dim strCurrentEmployeeEmploymentDetails As String
    Dim strCurrentEmployeeEmploymentDetailsArray() As String
    Dim strPayslipImagePath As String = Nothing

    Dim X1, X2, X3, X4, X5, X6 As Integer
    Dim W1, W2, W3, W4, W5, W6 As Integer
    Dim Y As Integer


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chkPrintSelective_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintSelective.CheckedChanged
        If chkPrintSelective.Checked = True Then
            pnlFrom.Enabled = True : pnlTo.Enabled = True
            txtStartFrom.Enabled = True : txtEndAt.Enabled = True
            boolPrintSelective = True
        Else
            pnlFrom.Enabled = False : pnlTo.Enabled = False
            txtStartFrom.Enabled = False : txtEndAt.Enabled = False
            boolPrintSelective = False
        End If
    End Sub

    Private Sub txtStartFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtStartFrom.Validating
        If String.IsNullOrEmpty(txtStartFrom.Text) Then Exit Sub
        If Not IsNumeric(txtStartFrom.Text) Then
            MessageBox.Show("Please enter the first numeric employee number to be printed", "Invalid Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtStartFrom.Focus()
        End If
    End Sub

    Private Sub txtEndAt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEndAt.Validating
        If String.IsNullOrEmpty(txtEndAt.Text) Then Exit Sub
        If Not IsNumeric(txtEndAt.Text) Then
            MessageBox.Show("Please enter the last numeric employee number to be printed", "Invalid Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEndAt.Focus()
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        strStartDate = dpStartDate.Text
        strEndDate = dpEndDate.Text
        If UCase(strSystemDateFormat) = UCase("Endglish") Then
            strStartDate = shortMonthDateFormat(dpStartDate.Value)
            strEndDate = shortMonthDateFormat(dpEndDate.Value)
        End If
        If String.IsNullOrEmpty(txtCompanyName.Text) Then
            MessageBox.Show("Please enter the name of the company", "Invalid Company Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCompanyName.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAddress.Text) Then
            MessageBox.Show("Please enter the address of the company", "Invalid Company Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtTin.Text) Then
            MessageBox.Show("Please enter the company tax number", "Invalid Company TIN", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTin.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtStartNumber.Text) Then txtStartNumber.Text = "1"

        If chkPrintSelective.Checked = True Then
            If Not IsNumeric(txtStartFrom.Text) Then
                MessageBox.Show("Please enter a numeric employee number from which to start printing the payslips", _
                    "Invalid Start Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtStartFrom.Focus()
                Exit Sub
            End If
        End If
        If chkPrintSelective.Checked = True Then
            If Not IsNumeric(txtEndAt.Text) Then
                txtEndAt.Text = "99999999"
            End If
        End If
        If chkPrintSelective.Checked = True Then
            intStartNumber = CLng(txtStartFrom.Text)
            intEndNumber = CLng(txtEndAt.Text)
        End If
        If chkZeroPayslips.Checked = True Then
            boolPrintZeroPayslips = True
        Else
            boolPrintZeroPayslips = False
        End If
        If chkPrintAll.Checked = True Then
            intStartNumber = 0 : intEndNumber = 9999999
        Else
            If IsNumeric(txtStartFrom.Text) Then
                intStartNumber = CInt(txtStartFrom.Text)
            Else
                intStartNumber = 0
            End If
            If IsNumeric(txtEndAt.Text) Then
                intEndNumber = CInt(txtEndAt.Text)
            Else
                intEndNumber = 9999999
            End If
        End If
        If Not IsNumeric(txtJobRef.Text) Then txtJobRef.Text = "0"

        Select Case cboSortOrder.Text
            Case Is = "Paypoint/Employee Number Sequence"
                strSortOrder = "Paypoint/Employee Number Sequence"
            Case Is = "Paypoint/Clock Number Sequence"
                strSortOrder = "Paypoint/Clock Number Sequence"
            Case Is = "Paypoint/Alpha Sequence"
                strSortOrder = "Paypoint/Alpha Sequence"
            Case Is = "Paypoint/Cost Code/Employee Number"
                strSortOrder = "Paypoint/Cost Code/Employee Number"
            Case Is = "Employee Number Sequence"
                strSortOrder = "Employee Number Sequence"
            Case Else
                strSortOrder = "Employee Number Sequence"
        End Select

        '*** Sort the details before sending to print ***
        boolAbort = False
        GetYtdAidsLevyCode()
        If boolAbort = True Then Exit Sub
        lngSerialNumbers = CDbl(txtStartNumber.Text)
        boolAbort = False
        TaxData()
        If boolAbort = True Then Exit Sub
        PrintTaxCertificate()

        ' Me.Close()
    End Sub

    Private Sub PrintTaxCertificate()
        On Error GoTo RaiseErr

        ''AssignCompanyDetails()
        ''If boolAbort = True Then Exit Sub
        ''AssignProcessedEmployeeNumbers() 'Read from the current run file
        ''If boolAbort = True Then Exit Sub
        ''AssignPersonalDetails()
        ''If boolAbort = True Then Exit Sub

        ''itm = 0
        ''If strEmployeeFullDetails.Length = 0 Then
        ''    MessageBox.Show("No employee records were found for printing", MsgBoxStyle.Exclamation, "Empty Payroll File")
        ''    Exit Sub
        ''End If

        boolDrawBorders = True

        Dim ppd As New PrintPreviewDialog
        ppd.Document = pdTaxCertificates
        ppd.ShowDialog()

        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub pdTaxCertificates_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdTaxCertificates.PrintPage

        Dim EmployeeDetails() As String = Split(arrMaster(itm), ";")
        boolAbort = False
        Dim strPersonalDetails() As String = Split(GetEmployeePersonalDetails(EmployeeDetails(0)), "|")
        If boolAbort = True Then
            e.HasMorePages = False
            Exit Sub
        End If

        Dim intX1, intX2, intY1, intY2 As Integer
        'Right margin reduced from intRightMargin - 100 to minus 50
        intLeftMargin = 50 : intRightMargin = 50 : intTopMargin = 40 : intBottomMargin = 40
        intX1 = intLeftMargin ' e.PageBounds.Left + 50
        intX2 = e.PageBounds.Right - intRightMargin
        intY1 = intTopMargin ' e.PageBounds.Top + 100
        intY2 = 500 'e.PageBounds.Bottom - intBottomMargin

        'Dim str As String
        'Dim strAmt As String
        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        'Draw the main border
        'Dim sbCurrent As SolidBrush 'penCurrent As Pen
        reccurrent = New Rectangle(intX1, intY1, (intX2 - 43), intY2)
        If boolDrawBorders = True Then e.Graphics.DrawRectangle(Pens.Black, reccurrent)
        Dim intRectangleWidth As Integer = reccurrent.Width


        'Print the pay advice header
        e.Graphics.DrawString("ZIMBABWE REVENUE AUTHORITY", SubHeadingFont, Brushes.Black, intX1 + 1, intY1 + 7)
        e.Graphics.DrawString("EMPLOYEE'S TAX CERTIFICATE", SuperHeading, Brushes.Black, intX1 + 250, intY1)
        intY1 = intY1 + 30
        e.Graphics.DrawString("EARNINGS AND DEDUCTIONS FOR THE YEAR ENDED 31st DECEMBER " & DatePart(DateInterval.Year, dpEndDate.Value) & "                             SERIAL NUMBER ZIMRA", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Print certificate serial number
        e.Graphics.DrawString(lngSerialNumbers, SuperHeading, Brushes.Black, intX1 + 540, intY1 - 7)

        'Print the company name and the pay date the same font as that for document no
        ''e.Graphics.DrawString(UCase(strCompanyHeader), HeadingFont, System.Drawing.Brushes.Black, intX1 + 1, intTopMargin + 10)
        ''e.Graphics.DrawString(UCase(Format(dtPayslip, "dd-MMM-yyyy")), HeadingFont, System.Drawing.Brushes.Black, intX1 + 570, intTopMargin + 10)
        'Draw the 3 lines after
        intY1 = intY1 + 20
        If boolDrawBorders = True Then e.Graphics.DrawLine(Pens.Black, intX1, intY1, reccurrent.Right, intY1)
        'Print the headers
        intY1 = intY1 + 5
        boolDrawBorders = True
        If boolDrawBorders = True Then
            With e.Graphics

                '**** First Row print **************************************************************
                .DrawString("1. EMPLOYER'S NAME", SubHeadingFont, Brushes.Black, intX1 + 1, intY1)
                .DrawString("2. EMPLOYER'S ADDRESS", SubHeadingFont, Brushes.Black, intX1 + 253, intY1)
                .DrawString("3. EMPLOYER'S TIN", SubHeadingFont, Brushes.Black, intX1 + 503, intY1)
                '
                ' Print the actual details after advancing one line
                '
                intY1 = intY1 + 20

                .DrawString(UCase(txtCompanyName.Text), fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
                .DrawString(UCase(txtTin.Text), fntFinePrintFont, Brushes.Black, intX1 + 503, intY1)
                strCompanyAddressInformation = UCase(txtAddress.Text)
                If Not String.IsNullOrEmpty(strCompanyAddressInformation) Then
                    .DrawString(UCase(strCompanyAddressInformation), fntFinePrintFont, Brushes.Black, intX1 + 253, intY1)
                End If


                '*********** Second row print after drawing horizontal line ********************************
                '
                intY1 = intY1 + 15
                e.Graphics.DrawLine(Pens.Black, intX1, intY1, reccurrent.Right, intY1)
                intY1 = intY1 + 15
                .DrawString("4. SURNAME", SubHeadingFont, Brushes.Black, intX1 + 1, intY1)
                .DrawString("5. FULL FIRST NAMES", SubHeadingFont, Brushes.Black, intX1 + 153, intY1)
                .DrawString("6. EMPLOYEE'S ADDRESS", SubHeadingFont, Brushes.Black, intX1 + 303, intY1)
                '
                ' Employee details 
                '
                intY1 = intY1 + 15
                .DrawString(UCase(strPersonalDetails(0)), fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
                .DrawString(UCase(strPersonalDetails(1)), fntFinePrintFont, Brushes.Black, intX1 + 153, intY1)
                If UCase(strPersonalDetails(2)).Length > 50 Then strPersonalDetails(0) = Mid(strPersonalDetails(2), 1, 50)
                .DrawString(UCase(strPersonalDetails(2)), fntFinePrintFont, Brushes.Black, intX1 + 303, intY1)



                '****************** Third row print *****************************************************
                intY1 = intY1 + 15
                e.Graphics.DrawLine(Pens.Black, intX1, intY1, reccurrent.Right, intY1)
                intY1 = intY1 + 15
                'Employee details in this instance are printed on the same line as headers
                .DrawString("7. EMPLOYED FROM ", SubHeadingFont, Brushes.Black, intX1 + 1, intY1)
                Dim strDateSplit() As String = Split(strPersonalDetails(3), "-")
                Dim EmployeeStartDate As Date = CDate(strDateSplit(0) & "-" & MonthName(strDateSplit(1)) & "-" & strDateSplit(2))
                If EmployeeStartDate > CDate(dpStartDate.Value) Then
                    .DrawString(shortMonthDateFormat(CDate(strPersonalDetails(3))), fntFinePrintFont, Brushes.Black, intX1 + 160, intY1)
                Else
                    .DrawString(shortMonthDateFormat(dpStartDate.Value), fntFinePrintFont, Brushes.Black, intX1 + 160, intY1)
                End If
                .DrawString("TO", SubHeadingFont, Brushes.Black, intX1 + 221, intY1)

                strDateSplit = Split(strPersonalDetails(4), "-")
                Dim EmployeeEndDate As Date = CDate(strDateSplit(0) & "-" & MonthName(strDateSplit(1)) & "-" & strDateSplit(2))

                If UCase(shortMonthDateFormat(EmployeeEndDate)) = "01-JAN-1800" Or UCase(shortMonthDateFormat(EmployeeEndDate)) = "01-JAN-1900" Then
                    .DrawString(shortMonthDateFormat(dpEndDate.Value), fntFinePrintFont, Brushes.Black, intX1 + 240, intY1)
                Else
                    .DrawString(shortMonthDateFormat(CDate(strPersonalDetails(4))), fntFinePrintFont, Brushes.Black, intX1 + 240, intY1)
                End If

                .DrawString("AS", SubHeadingFont, Brushes.Black, intX1 + 302, intY1)
                .DrawString(UCase(EmployeeDetails(7)), fntFinePrintFont, Brushes.Black, intX1 + 320, intY1)
                .DrawString("8. EMPLOYEE'S TIN", SubHeadingFont, Brushes.Black, intX1 + 535, intY1)
                .DrawString(UCase(strPersonalDetails(6)), fntFinePrintFont, Brushes.Black, intX1 + 625, intY1)

                '****************** Forth row print ******************************************************
                intY1 = intY1 + 15
                e.Graphics.DrawLine(Pens.Black, intX1, intY1, reccurrent.Right, intY1)
                intY1 = intY1 + 15
                .DrawString("9. MARITAL STATUS", SubHeadingFont, Brushes.Black, intX1 + 1, intY1)
                .DrawString("SPOUSE'S FULL NAMES", SubHeadingFont, Brushes.Black, intX1 + 261, intY1)
                .DrawString("10. EPZ", SubHeadingFont, Brushes.Black, intX1 + 535, intY1)
                '
                'Print detail data
                '
                Select Case UCase(strPersonalDetails(8))
                    Case Is = "M"
                        .DrawString("MARRIED", fntFinePrintFont, Brushes.Black, intX1 + 161, intY1)
                    Case Is = "S"
                        .DrawString("SINGLE", fntFinePrintFont, Brushes.Black, intX1 + 161, intY1)
                    Case Is = "W"
                        .DrawString("WIDOW", fntFinePrintFont, Brushes.Black, intX1 + 161, intY1)
                    Case Else
                        .DrawString("SINGLE", fntFinePrintFont, Brushes.Black, intX1 + 161, intY1)
                End Select

                .DrawString(UCase(strPersonalDetails(8)), fntFinePrintFont, Brushes.Black, intX1 + 401, intY1)
                .DrawString("NO", fntFinePrintFont, Brushes.Black, intX1 + 602, intY1)

            End With

        End If

        boolDrawBorders = True 'Can always be turned off and on

        intY1 = intY1 + 15
        e.Graphics.DrawLine(Pens.Black, intX1, intY1, reccurrent.Right, intY1)
        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("11. EARNINGS", SubHeadingFont, Brushes.Black, intX1 + 1, intY1)
        If boolDrawBorders = True Then e.Graphics.DrawString("13. DEDUCTIONS", SubHeadingFont, Brushes.Black, intX1 + 406, intY1)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)
        'Skip 1 line and print the earnings static information
        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("a) Salary, Wages, Overtime", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Write Value
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format((CDbl(EmployeeDetails(8)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)

        'Right Column
        If boolDrawBorders = True Then e.Graphics.DrawString("a) Pension Contributions", fntFinePrintFont, Brushes.Black, intX1 + 406, intY1)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)
        'Write Value
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 620), intY1, 100, 80, Format((CDbl(EmployeeDetails(19)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)

        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("b) Bonus (Including non taxable portion)", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Write Value
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format((CDbl(EmployeeDetails(9)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)

        'Right Column
        If boolDrawBorders = True Then e.Graphics.DrawString("b) NSSA", fntFinePrintFont, Brushes.Black, intX1 + 406, intY1)
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 620), intY1, 100, 80, Format((CDbl(EmployeeDetails(20)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)

        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("c) Fees, Commission, CILOL", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Write Value
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format((CDbl(EmployeeDetails(10)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)

        'Right Column
        If boolDrawBorders = True Then e.Graphics.DrawString("c) Retirement Annuity Contributions", fntFinePrintFont, Brushes.Black, intX1 + 406, intY1)
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 620), intY1, 100, 80, Format((CDbl(EmployeeDetails(23)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)

        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("d) Gratuity", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Write Value
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format((CDbl(EmployeeDetails(12)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)

        'Right Column
        If boolDrawBorders = True Then e.Graphics.DrawString("d) Professional Subscriptions", fntFinePrintFont, Brushes.Black, intX1 + 406, intY1)
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 620), intY1, 100, 80, Format((CDbl(EmployeeDetails(21)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)

        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("e) Lump Sum Payments", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Write Value
        '*** LUMP SUM PAYMENTS *** Call DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format((CDbl(EmployeeDetails(8)) / 100), "#,##0.00"), fntPrintFont)

        'Right Column
        If boolDrawBorders = True Then e.Graphics.DrawString("e) Medical Aid Contributions", fntFinePrintFont, Brushes.Black, intX1 + 406, intY1)
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 620), intY1, 100, 80, Format((CDbl(EmployeeDetails(22)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)

        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("f) Severance Pay", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Write Value
        '** SEVERANCE PAY *** Call DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format((CDbl(EmployeeDetails(8)) / 100), "#,##0.00"), fntPrintFont)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)
        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("g) Any Other Earnings", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Write Value
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format((CDbl(EmployeeDetails(18)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)
        intY1 = intY1 + 20

        If boolDrawBorders = True Then e.Graphics.DrawString("12.BENEFITS", SubHeadingFont, Brushes.Black, intX1 + 1, intY1)
        'Right Column
        If boolDrawBorders = True Then e.Graphics.DrawString("14.AMOUNTS CONSIDERED FOR CREDITS", SubHeadingFont, Brushes.Black, intX1 + 406, intY1)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)

        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("a) Motor Vehicles", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Write Value
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format((CDbl(EmployeeDetails(14)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)

        'Right Column
        If boolDrawBorders = True Then e.Graphics.DrawString("a) Medical Expenses", fntFinePrintFont, Brushes.Black, intX1 + 406, intY1)
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 620), intY1, 100, 80, Format((CDbl(EmployeeDetails(29)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)

        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("b) Housing", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Write Value
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format((CDbl(EmployeeDetails(13)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)

        'Right Column
        If boolDrawBorders = True Then e.Graphics.DrawString("b) Elderly Person", fntFinePrintFont, Brushes.Black, intX1 + 406, intY1)
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 620), intY1, 100, 80, Format((CDbl(EmployeeDetails(28)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)

        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("c) Loan", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Write Value
        '*** LOAN *** Call DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format((CDbl(EmployeeDetails(8)) / 100), "#,##0.00"), fntPrintFont)

        'Right Column
        If boolDrawBorders = True Then e.Graphics.DrawString("c) Blind Person", fntFinePrintFont, Brushes.Black, intX1 + 406, intY1)
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 620), intY1, 100, 80, Format((CDbl(EmployeeDetails(26)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)

        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("d) Educational", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Write Value
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format((CDbl(EmployeeDetails(15)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)

        'Right Column
        If boolDrawBorders = True Then e.Graphics.DrawString("d) Disabled Person", fntFinePrintFont, Brushes.Black, intX1 + 406, intY1)
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 620), intY1, 100, 80, Format((CDbl(EmployeeDetails(27)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)

        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("e) Other", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Write Value
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format((CDbl(EmployeeDetails(16)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)

        'Right Column
        If boolDrawBorders = True Then e.Graphics.DrawString("e) Other", fntFinePrintFont, Brushes.Black, intX1 + 406, intY1)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)

        intY1 = intY1 + 15
        If boolDrawBorders = True Then e.Graphics.DrawString("f) Other", fntFinePrintFont, Brushes.Black, intX1 + 1, intY1)
        'Write Value
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format((CDbl(EmployeeDetails(17)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)

        'Right Column
        If boolDrawBorders = True Then e.Graphics.DrawString("f) Other", fntFinePrintFont, Brushes.Black, intX1 + 406, intY1)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)
        intY1 = intY1 + 20

        If boolDrawBorders = True Then e.Graphics.DrawString("TOTAL EARNINGS", SubHeadingFont, Brushes.Black, intX1 + 1, intY1)

        'Add up all the earnings
        Dim dblTotalEarnings As Double = (CDbl(EmployeeDetails(8)) / 100) + _
            (CDbl(EmployeeDetails(9)) / 100) + (CDbl(EmployeeDetails(10)) / 100) + _
            (CDbl(EmployeeDetails(12)) / 100) + _
            (CDbl(EmployeeDetails(18)) / 100) + (CDbl(EmployeeDetails(14)) / 100) + _
            (CDbl(EmployeeDetails(13)) / 100) + (CDbl(EmployeeDetails(15)) / 100) + _
            (CDbl(EmployeeDetails(16)) / 100)
        'Print total earnings
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 280), intY1, 100, 80, Format(dblTotalEarnings, "#,##0.00"), fntPrintFont, Brushes.Black)

        'Right Column
        If boolDrawBorders = True Then e.Graphics.DrawString("15. P.A.Y.E. DEDUCTED (Excl Aids Levy)", SubHeadingFont, Brushes.Black, intX1 + 406, intY1)
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 620), intY1, 100, 80, Format((CDbl(EmployeeDetails(25)) / 100), "#,##0.00"), fntPrintFont, Brushes.Black)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)
        intY1 = intY1 + 15

        If boolDrawBorders = True Then e.Graphics.DrawString("16. AIDS LEVY", SubHeadingFont, Brushes.Black, intX1 + 406, intY1)
        boolAbort = False
        Dim dblLevy As Double = EmployeeAidsLevy(EmployeeDetails(0))
        If boolAbort = True Then
            e.HasMorePages = False
            Exit Sub
        End If
        Call gwt_comm.DrawStringInBoxRight(e, (intX1 + 620), intY1, 100, 80, Format(dblLevy, "#,##0.00"), fntPrintFont, Brushes.Black)
        e.Graphics.DrawLine(Pens.Black, intX1, intY1 + 14, reccurrent.Right, intY1 + 14)
        intY1 = intY1 + 18

        If boolDrawBorders = True Then e.Graphics.DrawString("Employees on FDS not to submit Income Tax Returns unless in receipt of other income or change employment during the year.", ItalicFont, Brushes.Black, intX1 + 1, intY1)

        'Draw the drop down lines
        '
        'First row dropdowns
        e.Graphics.DrawLine(System.Drawing.Pens.Black, intX1 + 250, 90, _
                        intX1 + 250, 130) ' intY1 + 655)
        e.Graphics.DrawLine(System.Drawing.Pens.Black, intX1 + 500, 90, _
                        intX1 + 500, 130) ' intY1 + 655)
        'Second row dropdowns
        e.Graphics.DrawLine(System.Drawing.Pens.Black, intX1 + 150, 130, _
                        intX1 + 150, 175) ' intY1 + 655)
        e.Graphics.DrawLine(System.Drawing.Pens.Black, intX1 + 300, 130, _
                        intX1 + 300, 175) ' intY1 + 655)
        'Third and forth row dropdown
        e.Graphics.DrawLine(System.Drawing.Pens.Black, intX1 + 532, 175, _
                        intX1 + 532, 235) ' intY1 + 655)

        '
        'Last details dropdowns
        e.Graphics.DrawLine(System.Drawing.Pens.Black, intX1 + 300, 235, _
                        intX1 + 300, 513) ' intY1 + 655)
        e.Graphics.DrawLine(System.Drawing.Pens.Black, intX1 + 403, 235, _
                        intX1 + 403, 513) ' intY1 + 655)
        e.Graphics.DrawLine(System.Drawing.Pens.Black, intX1 + 638, 235, _
                        intX1 + 638, 513)
        '********************* END OF TAX CERTIFICATE PRINT *********************************************

        If itm >= arrMaster.Count - 1 Then
            e.HasMorePages = False
            itm = 0
        Else
            e.HasMorePages = True
            lngSerialNumbers = lngSerialNumbers + 1
            itm = itm + 1
        End If

    End Sub

    Private Sub TaxData()
        On Error GoTo RaiseErr


        If Not IsNumeric(txtStartFrom.Text) Then txtStartFrom.Text = "0"
        If Not IsNumeric(txtEndAt.Text) Then txtEndAt.Text = "0"

        Dim lngSerial As Long = 1
        Dim strSqlCounter As String = Nothing
        Dim strSplitBuffer() As String

        Cursor = Cursors.WaitCursor
        Dim intNoOfRecords As Integer = 0
        'Get a count of the records
        Dim objCommandCnt As Data.OleDb.OleDbCommand
        If boolPrintSelective = False Then
            objCommandCnt = New Data.OleDb.OleDbCommand("select count(EmployeeMaster.EmployeeNo) from EmployeeMaster", cnn)
        Else
            objCommandCnt = New Data.OleDb.OleDbCommand("select count(EmployeeMaster.EmployeeNo) from EmployeeMaster WHERE EmployeeMaster.EmployeeNo BETWEEN " & CInt(txtStartFrom.Text) & " AND " & CInt(txtEndAt.Text) & "", cnn)
        End If

        Dim objGetCnt As OleDb.OleDbDataReader = objCommandCnt.ExecuteReader
        While objGetCnt.Read
            If IsNumeric(objGetCnt(0).ToString) Then intNoOfRecords = CInt(objGetCnt(0).ToString)
        End While
        objGetCnt.Close()

        'read the details from the database table for paywell records

        'read the run file and get the employee numbers
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim strCountEmployees As String = Nothing
        If boolPrintSelective = False Then
            strCountEmployees = "SELECT Count(EmployeeNo) FROM EmployeeMaster"
            Select Case strSortOrder
                Case Is = "Paypoint/Employee Number Sequence"
                    strSql = "SELECT DISTINCT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName, EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames as [GivenNames], " _
                         & "CONVERT(NVARCHAR, EmployeeMaster.BirthDate, 105) AS BirthDate, CONVERT(NVARCHAR, Employment.HireDate, 105) AS EngageDate, " _
                         & "CONVERT(NVARCHAR, EmployeeMaster.DischDate, 105) AS DischDate, Employment.PayPoint,  EmployeeMaster.IdNumber, Employment.JobTitle " _
                         & "FROM EmployeeMaster LEFT OUTER JOIN Employment ON EmployeeMaster.EmployeeNo = Employment.EmployeeNo " _
                         & "ORDER BY Employment.PayPoint, EmployeeMaster.EmployeeNo"
                Case Is = "Paypoint/Clock Number Sequence"
                    strSql = "select DISTINCT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName, EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames as [GivenNames], " _
                         & "CONVERT(NVARCHAR, EmployeeMaster.BirthDate, 105) AS BirthDate,  EmployeeMaster.IdNumber, Employment.JobTitle, " _
                         & "CONVERT(NVARCHAR, Employment.HireDate, 105) AS EngageDate, CONVERT(NVARCHAR, EmployeeMaster.DischDate, 105) AS DischDate, Employment.PayPoint, EmployeeMaster.ClockNo " _
                         & "FROM EmployeeMaster LEFT OUTER JOIN Employment ON EmployeeMaster.EmployeeNo = Employment.EmployeeNo ORDER BY " _
                        & "Employment.Paypoint, EmployeeMaster.ClockNo, EmployeeMaster.EmployeeNo"
                Case Is = "Paypoint/Alpha Sequence"
                    strSql = "select DISTINCT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName, EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames as [GivenNames], " _
                         & "CONVERT(NVARCHAR, EmployeeMaster.BirthDate, 105) AS BirthDate,  EmployeeMaster.IdNumber, Employment.JobTitle, " _
                         & "CONVERT(NVARCHAR, Employment.HireDate, 105) AS EngageDate, CONVERT(NVARCHAR, EmployeeMaster.DischDate, 105) AS DischDate, Employment.PayPoint " _
                         & "FROM EmployeeMaster LEFT OUTER JOIN Employment ON EmployeeMaster.EmployeeNo = Employment.EmployeeNo ORDER BY " _
                        & "Employment.Paypoint, EmployeeMaster.LastName, EmployeeMaster.FirstName, EmployeeMaster.EmployeeNo"
                Case Is = "Paypoint/Cost Code/Employee Number"
                    strSql = "select DISTINCT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName, EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames as [GivenNames], " _
                         & "CONVERT(NVARCHAR, EmployeeMaster.BirthDate, 105) AS BirthDate,  EmployeeMaster.IdNumber, Employment.JobTitle, " _
                         & "CONVERT(NVARCHAR, Employment.HireDate, 105) AS EngageDate, CONVERT(NVARCHAR, EmployeeMaster.DischDate, 105) AS DischDate, Employment.PayPoint, Employment.CostCenter " _
                         & "FROM EmployeeMaster LEFT OUTER JOIN Employment ON EmployeeMaster.EmployeeNo = Employment.EmployeeNo ORDER BY Employment.Paypoint, Employment.CostCenter, EmployeeMaster.EmployeeNo"
                Case Is = "Employee Number Sequence"
                    strSql = "select DISTINCT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName, EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames as [GivenNames], " _
                         & "CONVERT(NVARCHAR, EmployeeMaster.BirthDate, 105) AS BirthDate,  EmployeeMaster.IdNumber, Employment.JobTitle, " _
                         & "CONVERT(NVARCHAR, Employment.HireDate, 105) AS EngageDate, CONVERT(NVARCHAR, EmployeeMaster.DischDate, 105) AS DischDate " _
                         & "FROM EmployeeMaster LEFT OUTER JOIN Employment ON EmployeeMaster.EmployeeNo = Employment.EmployeeNo ORDER BY EmployeeMaster.EmployeeNo"
                Case Else
                    strSql = "select DISTINCT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName, EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames as [GivenNames], " _
                         & "CONVERT(NVARCHAR, EmployeeMaster.BirthDate, 105) AS BirthDate, Employment.JobTitle, " _
                         & "CONVERT(NVARCHAR, Employment.HireDate, 105) AS EngageDate, CONVERT(NVARCHAR, EmployeeMaster.DischDate, 105) AS DischDate " _
                         & "FROM EmployeeMaster LEFT OUTER JOIN Employment ON EmployeeMaster.EmployeeNo = Employment.EmployeeNo ORDER BY EmployeeMaster.EmployeeNo"
            End Select
        Else
            'strCountEmployees = "SELECT Count(EmployeeNo) FROM EmployeeMaster WHERE EmployeeNo Between " & intStartNumber & " AND " & intEndNumber & ""
            intStartNumber = CInt(txtStartFrom.Text)
            intEndNumber = CInt(txtEndAt.Text)
            strSql = "select DISTINCT EmployeeMaster.EmployeeNo, EmployeeMaster.LastName, EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames as [GivenNames], " _
                & "CONVERT(NVARCHAR, EmployeeMaster.BirthDate, 105) AS BirthDate, EmployeeMaster.IdNumber, Employment.JobTitle, " _
                & "CONVERT(NVARCHAR, Employment.HireDate, 105) AS EngageDate, CONVERT(NVARCHAR, EmployeeMaster.DischDate, 105) AS DischDate " _
                & "FROM EmployeeMaster LEFT OUTER JOIN Employment ON EmployeeMaster.EmployeeNo = Employment.EmployeeNo " _
                & "WHERE EmployeeMaster.EmployeeNo Between " & intStartNumber & " AND " & intEndNumber & " " _
                & "ORDER BY EmployeeMaster.EmployeeNo ORDER BY EmployeeMaster.EmployeeNo"
        End If

        Dim cmdMaster As New OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = cmdMaster.ExecuteReader

        arrMaster = New ArrayList

        pb1.Value = 0 : pb1.Maximum = intNoOfRecords + 10 : pb1.Visible = True

        Dim strBuffer() As String
        Dim bDte As Date = Now

        If objReader.HasRows Then
            While objReader.Read
                'validate and convert the dates to the required format
                Dim strStartDate As String = "00000000"
                Dim strEndDate As String = "00000000"
                Dim strBirthDate As String = "00000000"
                strStartDate = "00000000"

                strEndDate = "00000000"
                If Not IsDBNull(objReader("dischdate").ToString) Then
                    strBuffer = Split(objReader("dischdate").ToString, "-")
                    If strBuffer.Length = 3 Then
                        bDte = CDate(strBuffer(0) & "-" & MonthName(strBuffer(1)) & "-" & strBuffer(2))
                        If Format(bDte, "yyyyMMdd") <> "18000101" Then
                            strEndDate = Format(bDte, "yyyyMMdd")
                        End If
                    End If
                End If

                If Not IsDBNull(objReader("birthdate").ToString) Then
                    strBuffer = Split(objReader("birthdate").ToString, "-")
                    If strBuffer.Length = 3 Then
                        Dim dtBirthDate As Date = CDate(strBuffer(0) & "-" & MonthName(strBuffer(1)) & "-" & strBuffer(2))
                        strBirthDate = Format(dtBirthDate, "yyyyMMdd")
                    End If
                End If
                'Build the master records here
                Dim strEmployeeNumber As String = "00000000"
                Dim strEmployeeSurname As String = Space(24)
                Dim strEmployeeNames As String = Space(24)
                Dim strEmployeeIdNumber As String = "000000000X00"

                If Not IsDBNull(objReader("EmployeeNo").ToString) Then
                    If IsNumeric(objReader("EmployeeNo").ToString) Then
                        strEmployeeNumber = CStr(Format(CInt(objReader("EmployeeNo")), "00000000"))
                    Else
                        strEmployeeNumber = objReader("EmployeeNo").ToString
                    End If
                End If

                If Not IsDBNull(objReader("LastName").ToString) Then
                    If objReader("LastName").ToString.Length > 24 Then
                        strEmployeeSurname = Mid(objReader("LastName").ToString, 1, 24)
                    Else
                        strEmployeeSurname = objReader("LastName").ToString & Space(24 - objReader("LastName").ToString.Length)
                    End If
                End If
                If Not IsDBNull(objReader("givennames").ToString) Then
                    If objReader("givennames").ToString.Length > 24 Then
                        strEmployeeNames = Mid(objReader("givennames").ToString, 1, 24)
                    Else
                        strEmployeeNames = objReader("givennames").ToString & Space(24 - objReader("givennames").ToString.Length)
                    End If
                End If

                'Get the employee id number and assign it to a variable
                Dim strId As String = "000000000000"

                If Not IsDBNull(objReader("IdNumber").ToString) Then
                    strEmployeeIdNumber = objReader("IdNumber").ToString
                End If
                If strEmployeeIdNumber.Length > 12 Then strEmployeeIdNumber = Mid(strEmployeeIdNumber, 1, 12) Else strEmployeeIdNumber = strEmployeeIdNumber & Space(12 - strEmployeeIdNumber.Length)


                'Get the employee job position
                Dim strPosition As String = Nothing
                If Not IsDBNull(objReader("JobTitle").ToString) Then strPosition = UCase(objReader("JobTitle").ToString)

                'Ensure that you skip all employees with invalid dates of birth
                strBuffer = Split(objReader("BirthDate").ToString, "-")

                If Not String.IsNullOrEmpty(strEmployeeNumber) Then
                    If strBuffer.Length = 3 Then
                        bDte = CDate(strBuffer(0) & "-" & MonthName(strBuffer(1)) & "-" & strBuffer(2))
                        If Format(bDte, "yyyyMMdd") <> "18000101" Then
                            arrMaster.Add(strEmployeeNumber & ";" & strEmployeeSurname & ";" & _
                                        strEmployeeNames & ";" & strEmployeeIdNumber & _
                                        ";" & strBirthDate & ";" & strStartDate & ";" & strEndDate & ";" & strPosition)
                        End If
                    Else
                        arrMaster.Add(strEmployeeNumber & ";" & strEmployeeSurname & ";" & _
                                        strEmployeeNames & ";" & strEmployeeIdNumber & _
                                        ";" & strBirthDate & ";" & strStartDate & ";" & strEndDate & ";" & strPosition)
                    End If
                End If
                pb1.Value = pb1.Value + 1
            End While
        End If
        pb1.Value = pb1.Maximum
        objReader.Close()
        Dim intRecordCount As Integer = arrMaster.Count
        Dim vFileDate As String = Format(Now, "yyyyMMdd")

        'LOOP THROUGH THE MASTER ARRAY IN CONJUCTION WITH THE ITF16 PARAMETER FILE AND EXTRACT THE
        'CODE VALUES FOR EACH EMPLOYEE WITHIN THE ARRAY.
        Dim strLine As String

        'Check first that the ITF16 parameters have been set up as yet
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CalcCodes FROM SystemTaxCalculations", cnn)
        Dim objReadParms As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        If objReadParms.HasRows Then
            objReadParms.Read()
            strLine = objReadParms(0).ToString
            objReadParms.Close()
            If String.IsNullOrEmpty(strLine) Then
                MessageBox.Show("The ITF16 Parameters have not been set. Please set them up before running this process", _
                    "Missing ITF16 Parameters", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Dim strCodes() As String = Split(strLine, ";")
            Dim p As Integer

            lngSalary = 0 : lngTax = 0
            pb1.Value = 0 : pb1.Maximum = arrMaster.Count + 10
            For p = 0 To arrMaster.Count - 1
                Dim i As Integer
                For i = 0 To strCodes.Length - 1

                    Dim n As Integer = 0
                    Dim strIndividualCodes() As String = Split(strCodes(i), "|")
                    Dim dblValue As Double = 0

                    For n = 0 To strIndividualCodes.Length - 1
                        Dim strMasterFields() As String = Split(arrMaster(p), ";")
                        'Dim intEmployeeNo As Integer = 0
                        Dim intActiveCode As Integer = 0
                        'If IsNumeric(strMasterFields(0)) Then intEmployeeNo = CInt(strMasterFields(0))
                        If IsNumeric(strIndividualCodes(n)) Then intActiveCode = CInt(strIndividualCodes(n))
                        Dim strSelectCode As String = "SELECT Amount FROM EmployeeCodes WHERE EmployeeNo = '" & strMasterFields(0) & "' AND CodeNo = " & intActiveCode
                        Dim cmdGetCodeValue As New Data.OleDb.OleDbCommand(strSelectCode, cnn)
                        Dim objReadCode As Data.OleDb.OleDbDataReader = cmdGetCodeValue.ExecuteReader
                        If objReadCode.HasRows Then
                            objReadCode.Read()
                            dblValue = dblValue + (CDbl(objReadCode(0).ToString) * 100)
                        End If
                        objReadCode.Close()
                    Next n


                    'Get the salary accumulation and tax accumulation
                    If i = 0 Then lngSalary = lngSalary + dblValue
                    If i = 17 Then lngTax = lngTax + dblValue
                    arrMaster(p) = arrMaster(p) & ";" & CStr(Format(dblValue, "000000000000"))
                Next
                pb1.Value = pb1.Value + 1
            Next
            Cursor = Cursors.Default
            Exit Sub
        Else
            MessageBox.Show("The ITF16 Parameters have not been set. Please set them up before running this process", _
                "Missing ITF16 Parameters", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        pb1.Value = pb1.Value + pb1.Maximum
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Tax Certificate Print Failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function GetEmployeePersonalDetails(ByVal EmployeeNo As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing 'return Surname|Givennames|Address|Start Date|EndDate|Job|Tax Number|Marital status|spouse names
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT EmployeeMaster.LastName, EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames as [GivenNames], " _
            & "EmployeeMaster.Address1 + ', ' + EmployeeMaster.Address2 + ', ' + EmployeeMaster.Address3 + ', ' + EmployeeMaster.Address4 as [Address], " _
            & "CONVERT(NVARCHAR, Employment.Hiredate, 105) as engagedate, CONVERT(NVARCHAR, EmployeeMaster.dischdate, 105) as dischdate, " _
            & "Employment.JobTitle, EmployeeMaster.TaxRef, EmployeeMaster.TaxCode, EmployeeMaster.MaidenName " _
            & "FROM EmployeeMaster LEFT OUTER JOIN Employment ON EmployeeMaster.EmployeeNo = Employment.EmployeeNo " _
            & "WHERE EmployeeMaster.EmployeeNo = '" & EmployeeNo & "'", cnn)
        Dim objReadData As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReadData.HasRows Then
            objReadData.Read()
            For i As Integer = 0 To objReadData.FieldCount - 1
                If Not IsDBNull(objReadData(i).ToString) Then
                    strReturn = strReturn & objReadData(i).ToString & "|"
                Else
                    strReturn = strReturn & "|"
                End If
            Next
        End If
        objReadData.Close()
        Return strReturn
        Exit Function
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Function

    Private Sub GetYtdAidsLevyCode()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AidsLevyYtdCode FROM SystemKeyData", cnn)
        Dim objReadData As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReadData.HasRows Then
            objReadData.Read()
            If IsNumeric(objReadData(0).ToString) Then intAidsLevyCode = CInt(objReadData(0).ToString)
        End If
        objReadData.Close()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Function EmployeeAidsLevy(ByVal EmployeeNumber As String) As Double
        Dim dblReturn As Double = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Amount FROM EmployeeCodes WHERE EmployeeNo = '" & EmployeeNumber & "' AND CodeNo = " & intAidsLevyCode & "", cnn)
        Dim objReadData As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReadData.HasRows Then
            objReadData.Read()
            If IsNumeric(objReadData(0).ToString) Then dblReturn = CDbl(objReadData(0).ToString)
        End If
        objReadData.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number
        gwt_comm.ShowErrorMessage()
        boolAbort = True
    End Function

    Private Sub txtStartNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStartNumber.KeyPress
        If Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub frmEmployeeTaxCertificates_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 610 : Me.Height = 413
    End Sub

End Class
