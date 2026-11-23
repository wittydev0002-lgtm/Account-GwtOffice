Imports System.Drawing
Imports System.Drawing.Printing

Public Class frmEmployeeTaxCertificates

    Dim myPen As System.Drawing.Pen
    Dim myBrush As System.Drawing.Brush
    Dim recBox As Rectangle

    Dim arrMaster As ArrayList
    Dim itm As Integer = 0
    Dim lngSerialNumbers As Double
    Dim strStartDate As String = Nothing
    Dim strEndDate As String = Nothing
    Dim strPrintingOptions As String = "ALL"
    Dim intAidsLevyCode As Integer = 0
    Dim lngSalary As Double
    Dim lngTax As Double

    Private Sub PrintDocument1_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim y As Integer = 100
        Dim x As Integer = 100
        Dim intPrintAreaWidth As Integer

        Dim intYnotes As Integer

        'Assign the default background for textboxes to black
        Dim clr As SolidBrush
        clr = New SolidBrush(Color.LightGray)

        Dim clrWhite As SolidBrush
        clrWhite = New SolidBrush(Color.White)

        'Draw the certificate border
        With Me.PrintDocument1.DefaultPageSettings

            .Margins.Left = 100
            .Margins.Top = 100

            myPen = New Pen(Brushes.LightGray)
            recBox = New Rectangle(.Margins.Left, .Margins.Top, e.PageBounds.Width - (.Margins.Left + .Margins.Right), e.PageBounds.Height - (.Margins.Bottom + .Margins.Top))
            e.Graphics.DrawRectangle(myPen, rect:=recBox)
            intPrintAreaWidth = e.PageBounds.Width - (.Margins.Left + .Margins.Right)

        End With

        Dim EmployeeDetails() As String = Split(arrMaster(itm), ";")

        boolAbort = False
        Dim strPersonalDetails() As String = Split(GetEmployeePersonalDetails(CLng(EmployeeDetails(0))), "|")
        If boolAbort = True Then
            e.HasMorePages = False
            Exit Sub
        End If

        'Draw the certificate header




        DrawFormattedTextBox(e, x + 2, y + 2, intPrintAreaWidth - 4, 30, "EMPLOYEE TAX CERTIFICATE", fntHeaderFont, Brushes.Black, 1, 0, clr)

        'Print the first header and serial number
        y = y + 40
        x = x + 5
        DrawFormattedTextBox(e, x, y, 400, 20, "EARNINGS AND DEDUCTIONS FOR THE YEAR ENDED " & UCase(Format(dpEndDate.Value, "dd-MMM-yyyy")), fntDetailsFontBold, Brushes.Black, 0, 0, clrWhite)
        DrawFormattedTextBox(e, x + 420, y, 180, 20, "SERIAL NO ZIMRA " & Format(lngSerialNumbers, "0000000"), fntDetailsFontBold, Brushes.Black, 0, 0, clrWhite)

        'Draw the horizontal line
        y = y + 30
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 10
        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, x + 2, y + 2, 16, 17, "1", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 18, y + 2, 198, 17, "EMPLOYER'S NAME", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, x + 218, y + 2, 16, 17, "2", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 234, y + 2, 192, 17, "EMPLOYER ADDRESS", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, x + 428, y + 2, 16, 17, "3", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 444, y + 2, 197, 17, "EMPLOYER TIN", fntDetailsFontBold, Brushes.Black, 0, 0, clr)

        'Print the actual company details
        y = y + 20
        clr = New SolidBrush(Color.White)
        DrawFormattedTextBox(e, x + 18, y + 2, 195, 30, UCase(txtCompanyName.Text), fntDetailsFont, Brushes.Black, 0, 0, clr)

        strCompanyAddressInformation = txtAddress.Text
        If Not String.IsNullOrEmpty(strCompanyAddressInformation) Then
            DrawFormattedTextBox(e, x + 234, y + 2, 195, 30, UCase(strCompanyAddressInformation), fntDetailsFont, Brushes.Black, 0, 0, clr)
        End If

        DrawFormattedTextBox(e, x + 444, y + 2, 195, 30, UCase(txtTin.Text), fntDetailsFont, Brushes.Black, 0, 0, clr)
        y = y + 35
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)



        '********* PRINT EMPLOYEE DETAILS ******************
        y = y + 10
        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, x + 2, y + 2, 16, 17, "4", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 18, y + 2, 198, 17, "SURNAME", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, x + 218, y + 2, 16, 17, "5", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 234, y + 2, 192, 17, "FULL FIRST NAMES", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, x + 428, y + 2, 16, 17, "6", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 444, y + 2, 197, 17, "EMPLOYEE ADDRESS", fntDetailsFontBold, Brushes.Black, 0, 0, clr)

        'Print the actual details
        y = y + 20
        clr = New SolidBrush(Color.White)
        DrawFormattedTextBox(e, x + 18, y + 2, 195, 30, UCase(strPersonalDetails(0)), fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, x + 234, y + 2, 195, 30, UCase(strPersonalDetails(1)), fntDetailsFont, Brushes.Black, 0, 0, clr)
        If UCase(strPersonalDetails(2)).Length > 50 Then strPersonalDetails(2) = Mid(strPersonalDetails(2), 1, 50)
        strPersonalDetails(2) = Replace(strPersonalDetails(2), ",", " ", 1)
        DrawFormattedTextBox(e, x + 444, y + 2, 195, 30, UCase(strPersonalDetails(2)), fntDetailsFont, Brushes.Black, 0, 0, clr)
        y = y + 35
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)



        '*********** PRINT EMPLOYMENT PERIOD AND OTHER DETAILS *****************

        y = y + 10
        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, x + 2, y + 2, 16, 17, "7", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 18, y + 2, 198, 17, "EMPLOYED FROM", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 218, y + 2, 16, 17, " ", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 234, y + 2, 192, 17, "OCCUPATION", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, x + 428, y + 2, 16, 17, "8", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 444, y + 2, 197, 17, "EMPLOYEE'S TIN", fntDetailsFontBold, Brushes.Black, 0, 0, clr)

        'Print the actual details
        y = y + 20
        clr = New SolidBrush(Color.White)

        Dim strPrintStartDate As String = Format(dpStartDate.Value, "dd-MMM-yyyy")
        Dim strPrintEndDate As String = Format(dpEndDate.Value, "dd-MMM-yyyy")

        If String.IsNullOrEmpty(strPersonalDetails(3)) Then
            strPrintStartDate = Format(dpStartDate.Value, "dd-MMM-yyyy")
        Else
            If CDate(strPersonalDetails(3)) > CDate(dpStartDate.Value) Then
                strPrintStartDate = Format(CDate(strPersonalDetails(3)), "dd-MMM-yyyy")
            End If
        End If

        If String.IsNullOrEmpty(strPersonalDetails(4)) Then
            strPrintEndDate = Format(dpEndDate.Value, "dd-MMM-yyyy")
        Else
            If UCase(Format(CDate(strPersonalDetails(4)), "dd-MMM-yyyy")) = "01-JAN-1800" Then
                strPrintEndDate = Format(dpEndDate.Value, "dd-MMM-yyyy")
            Else
                If CDate(strPersonalDetails(4)) > CDate(strPrintStartDate) Then
                    If CDate(strPersonalDetails(4)) < CDate(strPrintEndDate) Then
                        strPrintEndDate = Format(CDate(strPersonalDetails(4)), "dd-MMM-yyyy")
                    End If
                End If
            End If
        End If

        Dim ActiveEmployeeNumber As Long = 0

        Dim strSplitBuffer() As String = Split(arrMaster.Item(itm), ";")
        If IsNumeric(strSplitBuffer(0)) Then ActiveEmployeeNumber = CLng(strSplitBuffer(0))

        Dim arrOptionals As New ArrayList
        arrOptionals = GetOptionalData(ActiveEmployeeNumber)

        DrawFormattedTextBox(e, x + 18, y + 2, 195, 30, UCase(strPrintStartDate) & " TO " & UCase(strPrintEndDate), fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, x + 234, y + 2, 195, 30, UCase(arrOptionals(1)), fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, x + 444, y + 2, 195, 30, UCase(arrOptionals(0)), fntDetailsFont, Brushes.Black, 0, 0, clr)
        y = y + 35
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)


        '************* PRINT MARITAL STATUS AND SPOUSE DETAILS *************************

        y = y + 10
        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, x + 2, y + 2, 16, 17, "9", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 18, y + 2, 120, 17, "MARITAL STATUS", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 118, y + 2, 16, 17, " ", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 140, y + 2, 292, 17, "SPOUSE FULL NAMES", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, x + 428, y + 2, 20, 17, "10", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 448, y + 2, 197, 17, "EPZ STATUS", fntDetailsFontBold, Brushes.Black, 0, 0, clr)

        'Print the actual details
        y = y + 20
        clr = New SolidBrush(Color.White)

        'Get the marital status
        Dim strMaritalStatus As String = "SINGLE"
        Select Case UCase(strPersonalDetails(7))
            Case Is = "M"
                strMaritalStatus = "MARRIED"
            Case Is = "S"
                strMaritalStatus = "SINGLE"
            Case Is = "W"
                strMaritalStatus = "WIDOW"
            Case Else
                strMaritalStatus = "SINGLE"
        End Select

        DrawFormattedTextBox(e, x + 18, y + 2, 100, 20, UCase(strMaritalStatus), fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, x + 140, y + 2, 295, 20, UCase(strPersonalDetails(8)), fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, x + 448, y + 2, 100, 20, "NO", fntDetailsFont, Brushes.Black, 0, 0, clr)
        y = y + 25
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)


        ' *************** DRAW THE DROP DOWN LINES *********************

        Dim intBottomY As Integer = e.PageSettings.PaperSize.Height - 130
        e.Graphics.DrawLine(Pens.LightGray, 100, intBottomY, intPrintAreaWidth + 100, intBottomY)

        ' Drop down lines
        e.Graphics.DrawLine(Pens.LightGray, 350, y, 350, intBottomY)
        e.Graphics.DrawLine(Pens.LightGray, 450, y, 450, intBottomY)
        e.Graphics.DrawLine(Pens.LightGray, 650, y, 650, intBottomY)


        'e.Graphics.DrawLine(Pens.LightGray, 100, intBottomY, intPrintAreaWidth + 100, intBottomY)
        'e.Graphics.DrawLine(Pens.LightGray, 100, intBottomY, intPrintAreaWidth + 100, intBottomY)

        intBottomY = intBottomY + 5
        clr = New SolidBrush(Color.White)
        DrawFormattedTextBox(e, x + 5, intBottomY, 600, 15, _
            "Employees on FDS not to submit Tax Returns unless in receipt of other income or change employment during the year", _
            fntFooterFontItalic, Brushes.Black, 0, 0, clr)

        ' *************** PRINT THE EARNINGS AND BENEFITS AND DEDUCTIONS

        y = y + 10
        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, x + 2, y + 2, 20, 17, "11", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 22, y + 2, 165, 17, "EARNINGS", fntDetailsFontBold, Brushes.Black, 0, 0, clr)

        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, 460, y + 2, 20, 17, "13", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, 480, y + 2, 165, 17, "DEDUCTIONS", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        y = y + 20
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 5


        ' ******** GET THE EMPLOYEE CODE VALUES AS DEFINED BY THE ITF PARAMETER FILE

        Dim arrPaymentValues As New ArrayList
        arrPaymentValues = EmployeeEarnings(CLng(EmployeeDetails(0)), dpStartDate.Value, dpEndDate.Value)

        Dim dblTotalEmployeeEarnings As Double = 0
        For q As Integer = 0 To arrPaymentValues.Count - 1
            If IsNumeric(arrPaymentValues.Item(q)) Then
                dblTotalEmployeeEarnings = dblTotalEmployeeEarnings + CDbl(arrPaymentValues.Item(q))
            End If
        Next

        ' *************** PRINT KEY DETAILS ***************************************

        clr = New SolidBrush(Color.White)
        DrawFormattedTextBox(e, 105, y, 200, 17, "a) Salary, Wages, Overtime", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "a) Pension Contributions", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        DrawFormattedTextBox(e, 105, y, 200, 17, "b) Bonus [Including non tax portion]", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "b) NSSA", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        DrawFormattedTextBox(e, 105, y, 200, 17, "c) Fees, Commission, CILOL", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(dblTotalEmployeeEarnings, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "c) Retirement Annuity Contributions", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        DrawFormattedTextBox(e, 105, y, 200, 17, "d) Gratuity", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "d) Professional Subscriptions", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        DrawFormattedTextBox(e, 105, y, 200, 17, "e) Lump Sum Payments", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "e) Medical Aid Contributions", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        DrawFormattedTextBox(e, 105, y, 200, 17, "f) Severance Pay", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, "", fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        'Cellphone benefits
        DrawFormattedTextBox(e, 105, y, 200, 17, "g) Any Other Earnings", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, "", fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        DrawFormattedTextBox(e, 105, y, 200, 17, "", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, "", fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, "", fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3


        '************** SUB HEADINGS ********************

        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, x + 2, y + 2, 20, 17, "12", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, x + 22, y + 2, 165, 17, "BENEFITS", fntDetailsFontBold, Brushes.Black, 0, 0, clr)

        clr = New SolidBrush(Color.Black)
        DrawFormattedTextBox(e, 460, y + 2, 20, 17, "14", fntDetailsFontBold, Brushes.White, 1, 0, clr)
        clr = New SolidBrush(Color.LightGray)
        DrawFormattedTextBox(e, 480, y + 2, 165, 17, "AMOUNTS FOR CREDITS", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        y = y + 20
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 5

        clr = New SolidBrush(Color.White)


        '************************************************

        DrawFormattedTextBox(e, 105, y, 200, 17, "a) Motor Vehicles", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "a) Medical Expenses", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        DrawFormattedTextBox(e, 105, y, 200, 17, "b) Housing", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "b) Elderly Person", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        DrawFormattedTextBox(e, 105, y, 200, 17, "c) Loan", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "c) Blind Person", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        DrawFormattedTextBox(e, 105, y, 200, 17, "d) Educational", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "d) Disabled Person", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        DrawFormattedTextBox(e, 105, y, 200, 17, "e) Other-Cellphone", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "e) Other", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        DrawFormattedTextBox(e, 105, y, 200, 17, "f) Other", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "f) Other", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3


        DrawFormattedTextBox(e, 105, y, 200, 17, "", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, "", fntDetailsFont, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "", fntDetailsFont, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, "", fntDetailsFont, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        '******************** HIGHLIGHTED

        'Dim dblEarningsTotal As Double = (CDbl((arrPaymentValues.Item(0)) / 100) + _
        '    CDbl((arrPaymentValues.Item(1)) / 100) +
        '    CDbl((arrPaymentValues.Item(2)) / 100) +
        '    CDbl((arrPaymentValues.Item(3)) / 100) +
        '    CDbl((arrPaymentValues.Item(4)) / 100) +
        '    CDbl((arrPaymentValues.Item(5)) / 100) +
        '    CDbl((arrPaymentValues.Item(6)) / 100) +
        '    CDbl((arrPaymentValues.Item(7)) / 100) +
        '    CDbl((arrPaymentValues.Item(8)) / 100) +
        '    CDbl((arrPaymentValues.Item(9)) / 100) +
        '    CDbl((arrPaymentValues.Item(10)) / 100) +
        '    CDbl((arrPaymentValues.Item(11)) / 100) +
        '    CDbl((arrPaymentValues.Item(12)) / 100))
        Dim dblEarningsTotal As Double = dblTotalEmployeeEarnings

        'irregula - 4
        'Retrenchment pay 7
        'Non taxable 13


        DrawFormattedTextBox(e, 105, y, 200, 17, "TOTAL EARNINGS", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, Format(dblEarningsTotal, "#,##0.00"), fntDetailsFontBold, Brushes.Black, 2, 0, clr)

        'Second column data
        Dim dblAidsLevy As Double = EmployeeAidsLevy(CLng(EmployeeDetails(0)), dpStartDate.Value, dpEndDate.Value)
        Dim dblPaye As Double = EmployeePaye(CLng(EmployeeDetails(0)), dpStartDate.Value, dpEndDate.Value)

        DrawFormattedTextBox(e, 460, y, 185, 17, "15. PAYE [Ex. Aids Levy]", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, Format(dblPaye, "#,##0.00"), fntDetailsFontBold, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        DrawFormattedTextBox(e, 105, y, 200, 17, "", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 355, y, 90, 17, "", fntDetailsFontBold, Brushes.Black, 2, 0, clr)
        'Second column data
        DrawFormattedTextBox(e, 460, y, 185, 17, "16. AIDS LEVY", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
        DrawFormattedTextBox(e, 655, y, 90, 17, Format(dblAidsLevy, "#,##0.00"), fntDetailsFontBold, Brushes.Black, 2, 0, clr)
        y = y + 18
        e.Graphics.DrawLine(Pens.LightGray, 100, y, intPrintAreaWidth + 100, y)
        y = y + 3

        'PRINT THE NOTES ON RETRENCHMENTS PAY
        intYnotes = y + 18
        If CDbl(arrPaymentValues.Item(6)) > 0 Then
            DrawFormattedTextBox(e, 105, y, 200, 17, "* RETRENCHMENT PAID ", fntDetailsFontBold, Brushes.Black, 0, 0, clr)
            DrawFormattedTextBox(e, 355, y, 90, 17, Format(0, "#,##0.00"), fntDetailsFontBold, Brushes.Black, 2, 0, clr)
        End If


        ' ********  Check and test end of certificate print

        If itm >= arrMaster.Count - 1 Then
            e.HasMorePages = False
            itm = 0
        Else
            e.HasMorePages = True
            lngSerialNumbers = lngSerialNumbers + 1
            itm = itm + 1
        End If

    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click

        If Not IsNumeric(txtStartFrom.Text) Then txtStartFrom.Text = "0"
        If Not IsNumeric(txtEndAt.Text) Then txtEndAt.Text = "0"

        fntHeaderFont = New System.Drawing.Font("Arial", 12, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
        fntDetailsFont = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
        fntFooterFont = New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
        fntFooterFontItalic = New System.Drawing.Font("Times New Roman", 8, Drawing.FontStyle.Italic, Drawing.GraphicsUnit.Point)
        fntDetailsFontBold = New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)

        strStartDate = dpStartDate.Text
        strEndDate = dpEndDate.Text

        If String.IsNullOrEmpty(txtCompanyName.Text) Then
            MsgBox("Please enter the name of the company", MsgBoxStyle.Exclamation, "Invalid Company Name")
            txtCompanyName.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAddress.Text) Then
            MsgBox("Please enter the address of the company", MsgBoxStyle.Exclamation, "Invalid Company Address")
            txtAddress.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtTin.Text) Then
            MsgBox("Please enter the company tax number", MsgBoxStyle.Exclamation, "Invalid Company TIN")
            txtTin.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtStartNumber.Text) Then txtStartNumber.Text = "1"

        If chkPrintSelective.Checked = True Then
            If Not IsNumeric(txtStartFrom.Text) Then
                MsgBox("Please enter a numeric employee number from which to start printing the payslips", MsgBoxStyle.Exclamation, "Invalid Start Employee Number")
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
        
        strSortOrder = "Employee Number Sequence"

        '*** Sort the details before sending to print ***
        
        lngSerialNumbers = CDbl(txtStartNumber.Text)
        boolAbort = False
        If chkNonFdsEmployeesOnly.Checked = True Then strPrintingOptions = "NONFDS" Else strPrintingOptions = "ALL"

        'Get the tax data
        TaxData()

        If boolAbort = True Then Exit Sub

        Cursor = Cursors.Default

        boolAbort = False
        Dim f As New frmPrinterSetup
        f.ShowDialog()
        If boolAbort = True Then Exit Sub

        PrintDocument1.PrinterSettings.PrinterName = strSessionPrinter

        Dim ppd As New PrintPreviewDialog

        ppd.Document = PrintDocument1
        ppd.ShowDialog()

        Cursor = Cursors.Default

    End Sub

    Private Function GetEmployeePersonalDetails(ByVal EmployeeNo As Long) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing 'return Surname|Givennames|Address|Start Date|EndDate|Job|Tax Number|Marital status|spouse names
        Dim strSql As String = "SELECT EmployeeMaster.LastName, EmployeeMaster.FirstName, EmployeeMaster.Address1 + ', " _
            & "' + EmployeeMaster.Address2 + ', ' + EmployeeMaster.Address3 + ', ' + EmployeeMaster.Address4 as [Address], " _
            & "EmployeeMaster.HireDate FROM EmployeeMaster WHERE EmployeeMaster.TransactionId = " & EmployeeNo & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReadData As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReadData.Read()
            For i As Integer = 0 To objReadData.FieldCount - 1
                If Not IsDBNull(objReadData(i).ToString) Then
                    strReturn = strReturn & objReadData(i).ToString & "|"
                Else
                    strReturn = strReturn & "|"
                End If
            Next
        End While
        objReadData.Close()
        strReturn = strReturn & "| | | | | | "
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
    End Function

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtStartNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtStartNumber.KeyPress
        If Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 8 Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub chkNonFdsEmployeesOnly_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkNonFdsEmployeesOnly.CheckedChanged
        If chkNonFdsEmployeesOnly.Checked = True Then strPrintingOptions = "NONFDS"
    End Sub

    Private Sub TaxData()
        On Error GoTo RaiseErr

        Dim lngSerial As Long = 1
        Dim strSqlCounter As String = Nothing
        Dim strSplitBuffer() As String

        Cursor = Cursors.WaitCursor
        Dim intNoOfRecords As Integer = 0
        'Get a count of the records
        Dim objCommandCnt As Data.OleDb.OleDbCommand
        Dim intYear As Integer = DatePart(DateInterval.Year, dpStartDate.Value)
        Dim nonFdsStartDate As Date = CDate("01-FEB-" & intYear)
        Dim nonFdsEndDate As Date = CDate("31-DEC-" & intYear)

        If boolPrintSelective = False Then
            objCommandCnt = New Data.OleDb.OleDbCommand("select count(EmployeeMaster.TransactionId) from EmployeeMaster", cnn)
        Else
            objCommandCnt = New Data.OleDb.OleDbCommand("select count(EmployeeMaster.TransactionId) from EmployeeMaster " _
                & "WHERE EmployeeMaster.TransactionId " _
                & "BETWEEN " & CInt(txtStartFrom.Text) & " AND " & CInt(txtEndAt.Text) & "", cnn)
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
            strCountEmployees = "SELECT Count(EmployeeMaster.TransactionId) FROM EmployeeMaster"
            strSql = "select EmployeeMaster.TransactionId, EmployeeMaster.LastName, EmployeeMaster.FirstName, " _
                & "EmployeeMaster.IdNumber from EmployeeMaster ORDER BY EmployeeMaster.TransactionId"
        Else
            'strCountEmployees = "SELECT Count(EmpNo) FROM PW_imf WHERE EmpNo Between " & intStartNumber & " AND " & intEndNumber & ""
            intStartNumber = CInt(txtStartFrom.Text)
            intEndNumber = CInt(txtEndAt.Text)
            strSql = "SELECT EmployeeMaster.TransactionId, EmployeeMaster.LastName, EmployeeMaster.FirstName, " _
                & "EmployeeMaster.IdNumber FROM EmployeeMaster WHERE " _
                & "EmployeeMaster.TransactionId BETWEEN " & intStartNumber & " AND " & intEndNumber & " ORDER BY EmployeeMaster.TransactionId"
        End If

        Dim cmdMaster As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As OleDb.OleDbDataReader = cmdMaster.ExecuteReader

        arrMaster = New ArrayList

        pb1.Value = 0 : pb1.Maximum = intNoOfRecords + 100 : pb1.Visible = True

        Dim strEcNum As String = Nothing


        While objReader.Read
            'validate and convert the dates to the required format
            Dim strStartDate As String = "00000000"
            Dim strEndDate As String = "00000000"
            Dim strBirthDate As String = "00000000"
            strStartDate = "00000000"

            strEndDate = "00000000"

            'Build the master records here
            Dim strEmployeeNumber As String = "00000000"
            Dim strEmployeeSurname As String = Space(24)
            Dim strEmployeeNames As String = Space(24)
            Dim strEmployeeIdNumber As String = "000000000X00"
            If Not IsDBNull(objReader("TransactionId").ToString) Then
                strEmployeeNumber = CStr(Format(CInt(objReader("TransactionId")), "00000000"))
                strEcNum = strEmployeeNumber
            End If

            If Not IsDBNull(objReader("LastName").ToString) Then
                If objReader("LastName").ToString.Length > 24 Then
                    strEmployeeSurname = Mid(objReader("LastName").ToString, 1, 24)
                Else
                    strEmployeeSurname = objReader("LastName").ToString & Space(24 - objReader("LastName").ToString.Length)
                End If
            End If
            If Not IsDBNull(objReader("FirstName").ToString) Then
                If objReader("FirstName").ToString.Length > 24 Then
                    strEmployeeNames = Mid(objReader("FirstName").ToString, 1, 24)
                Else
                    strEmployeeNames = objReader("FirstName").ToString & Space(24 - objReader("FirstName").ToString.Length)
                End If
            End If

            strEmployeeIdNumber = "000000000000"
            If Not IsDBNull(objReader("IdNumber").ToString) Then
                strEmployeeIdNumber = objReader("IdNumber").ToString
            End If

            'TRIM OUT ALL SPACES IN THE ID NUMBER
            strEmployeeIdNumber = Replace(strEmployeeIdNumber, " ", "", 1)

            If strEmployeeIdNumber.Length > 12 Then
                strEmployeeIdNumber = Mid(strEmployeeIdNumber, 1, 12)
            Else
                strEmployeeIdNumber = strEmployeeIdNumber & Space(12 - strEmployeeIdNumber.Length)
            End If

            'Get the employee job position
            Dim strPosition As String = "Board Member"

            arrMaster.Add(strEmployeeNumber & ";" & strEmployeeSurname & ";" & _
                strEmployeeNames & ";" & strEmployeeIdNumber & _
                    ";" & strBirthDate & ";" & strStartDate & ";" & strEndDate & ";" & strPosition)

            pb1.Value = pb1.Value + 1

        End While

        pb1.Value = pb1.Maximum
        objReader.Close()
        Dim intRecordCount As Integer = arrMaster.Count
        Dim vFileDate As String = Format(Now, "yyyyMMdd")

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " Employee number " & strEcNum & vbCrLf & "Tax Certificate Print Failure"
        ShowErrorMessage()
    End Sub

    Private Sub frmEmployeeTaxCertificates_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadTaxDates()
    End Sub

    Private Sub LoadTaxDates()
        dpStartDate.Value = CDate("01-JAN-" & DatePart(DateInterval.Year, Now))
        dpEndDate.Value = CDate("31-DEC-" & DatePart(DateInterval.Year, Now))
    End Sub

    Private Sub chkPrintSelective_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrintSelective.CheckedChanged
        If chkPrintSelective.Checked = True Then
            'kLabel1.Visible = True : kLabel2.Visible = True
            txtStartFrom.Visible = True : txtEndAt.Visible = True
            strPrintingOptions = "SELECTIVE"
            boolPrintSelective = True
        Else
            'kLabel1.Visible = False : kLabel2.Visible = False
            txtStartFrom.Visible = False : txtEndAt.Visible = False
            boolPrintSelective = False
        End If
    End Sub

    Private Sub txtStartFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtStartFrom.Validating
        If String.IsNullOrEmpty(txtStartFrom.Text) Then Exit Sub
        If Not IsNumeric(txtStartFrom.Text) Then
            MsgBox("Please enter the first numeric employee number to be printed", MsgBoxStyle.Exclamation, "Invalid Employee Number")
            txtStartFrom.Focus()
        End If
    End Sub

    Private Sub txtEndAt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEndAt.Validating
        If String.IsNullOrEmpty(txtEndAt.Text) Then Exit Sub
        If Not IsNumeric(txtEndAt.Text) Then
            MsgBox("Please enter the last numeric employee number to be printed", MsgBoxStyle.Exclamation, "Invalid Employee Number")
            txtEndAt.Focus()
        End If
    End Sub

    Private Sub chkPrintAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkPrintAll.CheckedChanged
        If chkPrintAll.Checked = True Then strPrintingOptions = "ALL"
    End Sub

    Private Function GetOptionalData(EmployeeNumber As Integer) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList

        'Get the id number 
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT IdNumber FROM EmployeeMaster " _
            & "WHERE TransactionId = " & EmployeeNumber & "", cnn)
        Dim objReadIdnumber As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim strIdNumber As String = " "
        While objReadIdnumber.Read()
            If Not IsDBNull(objReadIdnumber(0).ToString) Then strIdNumber = objReadIdnumber(0).ToString
        End While
        objReadIdnumber.Close()
        arrReturn.Add(strIdNumber)

        'Get the occupation 
        'objCommand = New Data.OleDb.OleDbCommand("SELECT RefNo FROM PW_RefNos WHERE EmpNo = " & EmployeeNumber & " " _
        '    & "AND OrdinalNo = " & CInt(txtJobRef.Text) & "", cnn)
        'objReadIdnumber = objCommand.ExecuteReader
        Dim strOccupation As String = " "
        'If objReadIdnumber.HasRows Then
        '    objReadIdnumber.Read()
        '    If Not IsDBNull(objReadIdnumber(0).ToString) Then strOccupation = objReadIdnumber(0).ToString
        'End If
        'objReadIdnumber.Close()

        arrReturn.Add(strOccupation)

        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error no " & Err.Number & vbCrLf & " On Tax Certificate Print Failure"
        ShowErrorMessage()
    End Function


End Class