Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmIssueLoan

    Dim boolAbort As Boolean
    Dim strSessionPrinter As String

    Public fntHeaderFont As New System.Drawing.Font("Arial", 7, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    Public fntDetailsFont As New System.Drawing.Font("Arial", 7, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Public fntFooterFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Public fntFooterFontItalic As New System.Drawing.Font("Times New Roman", 6, Drawing.FontStyle.Italic, Drawing.GraphicsUnit.Point)
    Public fntDetailsFontBold As New System.Drawing.Font("Arial", 7, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Private Function Balance(ByVal mPayment As Double, ByVal prin As Double, ByVal mRate As Double) As Double
        Dim newBal As Double
        'compute balance at end of month
        newBal = (1 + mRate) * prin
        If newBal < mPayment Then
            mPayment = newBal
            Balance = 0
        Else
            Balance = newBal - mPayment
        End If
    End Function

    Private Sub btnAmort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAmort.Click
        boolAbort = False
        ValidateControls()
        If boolAbort = True Then Exit Sub
        Dim principal As Double = CDbl(txtAmt.Text) 'amount of loan
        Dim yearlyRate As Double = CDbl(txtApr.Text) 'annual rate of interest
        Dim numMonths As Integer = CInt(txtYrs.Text) 'number of months to repay loan
        Call InputData(principal, yearlyRate, numMonths)
        Call ShowAmortSched(principal, yearlyRate, numMonths)
    End Sub

    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        boolAbort = False
        ValidateControls()
        If boolAbort = True Then Exit Sub
        Dim principal As Double = CDbl(txtAmt.Text) 'amount of loan
        Dim yearlyRate As Double = CDbl(txtApr.Text) 'annual rate of interest
        Dim numMonths As Integer = CInt(txtYrs.Text) 'number of months to repay loan
        Call InputData(principal, yearlyRate, numMonths)
        Call ShowPayment(principal, yearlyRate, numMonths)
    End Sub

    Private Sub btnRateTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRateTable.Click
        boolAbort = False
        ValidateControls()
        If boolAbort = True Then Exit Sub
        Dim principal As Double = CDbl(txtAmt.Text) 'amount of loan
        Dim yearlyRate As Double = CDbl(txtApr.Text) 'annual rate of interest
        Dim numMonths As Integer = CInt(txtYrs.Text) 'number of months to repay loan
        Call InputData(principal, yearlyRate, numMonths)
        Call ShowAmortSched(principal, yearlyRate, numMonths)
    End Sub

    Private Sub InputData(ByVal prin As Double, ByVal yearlyRate As Double, ByVal numMs As Integer)
        Dim percentageRate As Double, numYears As Integer
        'input the loan amount, yearly rate of interest, and duration
        prin = CDbl(txtAmt.Text)
        percentageRate = CDbl(txtApr.Text)
        numYears = CInt(txtYrs.Text)
        yearlyRate = percentageRate / 100
        numMs = numYears '* 12
    End Sub

    Private Function Payment(ByVal prin As Double, ByVal mRate As Double, ByVal numMs As Integer) As Double
        Dim payEst As Double
        If numMs = 0 Then
            payEst = prin
        ElseIf mRate = 0 Then
            payEst = prin / numMs
        Else
            payEst = prin * mRate / (1 - (1 + mRate) ^ (-numMs))
        End If
        If payEst <> Math.Round(payEst, 2) Then
            Payment = Math.Round(payEst + 0.005, 2) 'round up to the nearest cent
        End If
    End Function

    Private Sub ShowAmortSched(ByVal prin As Double, ByVal yearlyRate As Double, ByVal numMs As Integer)
        Dim msg As String, startmonth As Integer, mRate As Double
        Dim monthlyPayment As Double, totalInterest As Double
        Dim yearInterest As Double, oldBalance As Double
        Dim monthNum As Integer, newBalance As Double
        Dim principalPaid As Double, interestPaid As Double
        Dim reducPrin As Double, loanYears As Integer
        Dim TotalRepaymentAmt As Double
        'Display amortization schedule
        'msg = "Please enter year (1-" & Str(numMs / 12)
        'msg = msg & ") for which amortization is to be shown:"
        startmonth = 1 '12 * Val(InputBox(msg)) - 11
        With dGrid
            .Columns.Clear()
            .Rows.Clear()
            .Columns.Add("Column1", "Period")
            .Columns.Add("Column6", "Balance b/f")
            .Columns.Add("Column2", "Principal")
            .Columns.Add("Column3", "Interest")
            .Columns.Add("Column4", "Repayment")
            .Columns.Add("Column5", "Balance c/f")
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        mRate = (yearlyRate / 12) / 100 'monthly rate
        monthlyPayment = Payment(prin, mRate, numMs)
        totalInterest = 0
        yearInterest = 0
        'set the number of rows
        dGrid.Rows.Add(numMs + 1)
        oldBalance = prin
        For monthNum = 1 To (dGrid.Rows.Count - 1) 'numMs
            newBalance = Balance(monthlyPayment, oldBalance, mRate)
            principalPaid = oldBalance - newBalance
            interestPaid = monthlyPayment - principalPaid
            totalInterest = totalInterest + interestPaid
            If (monthNum >= startmonth) And (monthNum <= startmonth + numMs) Then
                dGrid.Rows(monthNum - 1).Cells(0).Value = FormatNumber(monthNum, 0)
                dGrid.Rows(monthNum - 1).Cells(1).Value = FormatNumber(oldBalance, 2, , vbTrue)
                dGrid.Rows(monthNum - 1).Cells(2).Value = FormatNumber(principalPaid, 2, , , vbTrue)
                dGrid.Rows(monthNum - 1).Cells(3).Value = FormatNumber(interestPaid, 2, , , vbTrue)
                TotalRepaymentAmt = principalPaid + interestPaid
                dGrid.Rows(monthNum - 1).Cells(4).Value = FormatNumber(TotalRepaymentAmt, 2, , , vbTrue)
                dGrid.Rows(monthNum - 1).Cells(5).Value = FormatNumber(newBalance, 2, , , vbTrue)
                yearInterest = yearInterest + interestPaid
            End If
            oldBalance = newBalance
        Next monthNum
        reducPrin = numMs * monthlyPayment - yearInterest
        loanYears = numMs / 12
        lblPrincipal.Text = FormatNumber(reducPrin, 2, , , vbTrue)
        lblInterest.Text = FormatNumber(yearInterest, 2, , , vbTrue)
        lblInstallment.Text = FormatNumber((numMs * monthlyPayment), 2, , , vbTrue)
        dGrid.Rows.RemoveAt(dGrid.Rows.Count - 1)
    End Sub

    Private Sub ShowInterestChanges(ByVal prin As Double, ByVal yearlyRate As Double, ByVal numMs As Integer)
        Dim newRate As Double, mRate As Double, py As Double
        Dim pymnt As String
        'grd.Cols = 2
        dGrid.Columns.Clear()
        dGrid.Rows.Clear()
        dGrid.Columns.Add("Column1", "Annual")
        dGrid.Columns.Add("Column2", "Interest")
        dGrid.Columns.Add("Column3", "Monthly")
        dGrid.Columns.Add("Column4", "Payment")
        newRate = yearlyRate - 0.01
        Do
            mRate = newRate / 12 'monthly rate
            py = Payment(prin, mRate, numMs)
            pymnt = FormatNumber(py, 2, , , vbTrue)
            dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = FormatPercent(newRate, 3)
            dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = FormatNumber(pymnt, 2, , , vbTrue)
            newRate = newRate + 0.00125
            'add 1 line to the grid
            dGrid.Rows.Add(1) ' = grd.Rows + 1
        Loop Until newRate > yearlyRate + 0.01
    End Sub

    Private Sub ShowPayment(ByVal prin As Double, ByVal yearlyRate As Double, ByVal numMs As Integer)
        Dim mRate As Double, prn As String, apr As String
        Dim yrs As String, pay As Double, pymnt As String
        'display monthly payment amount
        mRate = yearlyRate / 12 'monthly rate
        prn = FormatNumber(prin, 2, , , vbTrue)
        apr = FormatNumber((yearlyRate / 100), 4, , vbTrue)
        yrs = FormatNumber(numMs / 12, 0)
        pay = Payment(prin, (mRate / 100), numMs)
        pymnt = FormatNumber(pay, 2, , , vbTrue)
        MessageBox.Show("The monthly repayment for a " & prn & " loan at " &
            vbCrLf & apr & "% annual rate of interest for " & vbCrLf & yrs & " years Is " & pymnt,
            "Repayment Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub txtAmt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmt.GotFocus
        txtAmt.SelectAll()
    End Sub

    Private Sub txtAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmt.KeyPress
        If Asc(e.KeyChar) = 13 Then txtApr.Focus()
    End Sub

    Private Sub txtAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmt.LostFocus
        txtAmt.Text = FormatNumber(Val(txtAmt.Text), 2, , , vbTrue)
    End Sub

    Private Sub txtApr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApr.GotFocus
        txtApr.SelectAll()
    End Sub

    Private Sub txtApr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApr.KeyPress
        If Asc(e.KeyChar) = 13 Then txtYrs.Focus()
    End Sub

    Private Sub txtApr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtApr.LostFocus
        txtApr.Text = FormatNumber(Val(txtApr.Text), 2, , , vbTrue)
    End Sub

    Private Sub txtYrs_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYrs.GotFocus
        txtYrs.SelectAll()
    End Sub

    Private Sub txtYrs_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYrs.LostFocus
        txtYrs.Text = FormatNumber(Val(txtYrs.Text), 2, , , vbTrue)
    End Sub

    Private Sub ValidateControls()
        If Not IsNumeric(txtAmt.Text) Then
            MessageBox.Show("Please enter a valid numeric value for amount", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmt.Focus()
            boolAbort = True
            Exit Sub
        End If
        If Not IsNumeric(txtApr.Text) Then
            MessageBox.Show("Please enter a valid numeric value for percentage", "Invalid Percentage", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtApr.Focus()
            boolAbort = True
            Exit Sub
        End If
        If Not IsNumeric(txtYrs.Text) Then
            MessageBox.Show("Please enter a valid numeric value for period", "Invalid Period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtYrs.Focus()
            boolAbort = True
            Exit Sub
        End If
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        PrintDataGrid(dGrid, "LOAN AMORTIZATION SCHEDULE")
    End Sub

    Public Sub PrintDataGrid(dGrid As ComponentFactory.Krypton.Toolkit.KryptonDataGridView, ReportHeader As String)
        On Error GoTo RaiseErr

        Dim arrPrintData As New ArrayList
        Dim strColumnWidths As String = Nothing
        Dim strColumnHeaders As String = Nothing
        Dim strColumnVisible As String = Nothing
        Dim strColumnFormatting As String = Nothing
        Dim strColumnAlignments As String = Nothing
        Dim strColumnTotals As String = Nothing

        boolAbort = False
        'Dim f As New frmPrinterSetup
        'f.ShowDialog()
        Dim pd As New PrintDialog
        pd.ShowDialog()
        strSessionPrinter = pd.PrinterSettings.PrinterName

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        rpt.PrinterSettings.PrinterName = strSessionPrinter

        Dim intPaperWidth As Integer = rpt.PrinterSettings.DefaultPageSettings.PrintableArea.Width

        With dGrid
            'Get the column headers
            For i As Integer = 0 To .ColumnCount - 1

                If .Columns(i).Visible = True Then
                    strColumnHeaders = strColumnHeaders & .Columns(i).HeaderText & "|"
                Else
                    strColumnHeaders = strColumnHeaders & " " & "|"
                End If
                strColumnFormatting = strColumnFormatting & "NO" & "|"

                Dim value As DataGridViewCellStyle
                value = .Columns(i).DefaultCellStyle

                Dim str As String = .Columns(i).InheritedStyle.Alignment.ToString

                If UCase(str) = "MIDDLECENTER" Or UCase(str) = "BOTTOMCENTER" Or UCase(str) = "TOPCENTER" Then
                    strColumnAlignments = strColumnAlignments & "1" & "|"
                Else
                    If UCase(str) = "MIDDLERIGHT" Or UCase(str) = "BOTTOMRIGHT" Or UCase(str) = "TOPRIGHT" Then
                        strColumnAlignments = strColumnAlignments & "2" & "|"
                    Else
                        'This is the default value
                        strColumnAlignments = strColumnAlignments & "0" & "|"
                    End If
                End If

                strColumnTotals = strColumnTotals & "NO" & "|"

            Next
            If strColumnHeaders.Length > 0 Then strColumnHeaders = Mid(strColumnHeaders, 1, strColumnHeaders.Length - 1)
            If strColumnFormatting.Length > 0 Then strColumnFormatting = Mid(strColumnFormatting, 1, strColumnFormatting.Length - 1)
            If strColumnAlignments.Length > 0 Then strColumnAlignments = Mid(strColumnAlignments, 1, strColumnAlignments.Length - 1)
            If strColumnTotals.Length > 0 Then strColumnTotals = Mid(strColumnTotals, 1, strColumnTotals.Length - 1)

            'Get the column widths
            Dim intGridWidth As Integer = .Width - .RowHeadersWidth
            Dim dblWidthFactor As Double = CDbl(intPaperWidth) / intGridWidth

            For i As Integer = 0 To .ColumnCount - 1
                If .Columns(i).Visible = True Then
                    strColumnWidths = strColumnWidths & CStr(CInt((.Columns(i).Width * dblWidthFactor) + 15)) & "|"
                Else
                    strColumnWidths = strColumnWidths & CStr(CInt((0 * dblWidthFactor) * 1)) & "|"
                End If
            Next
            If strColumnWidths.Length > 0 Then strColumnWidths = Mid(strColumnWidths, 1, strColumnWidths.Length - 1)

            'Get the column visibility
            For i As Integer = 0 To .ColumnCount - 1
                If .Columns(i).Visible = True Then
                    strColumnVisible = strColumnVisible & "YES" & "|"
                Else
                    strColumnVisible = strColumnVisible & "NO" & "|"
                End If
            Next
            If strColumnVisible.Length > 0 Then strColumnVisible = Mid(strColumnVisible, 1, strColumnVisible.Length - 1)

            For r As Integer = 0 To .Rows.Count - 1
                Dim strDataLine As String = Nothing
                For i As Integer = 0 To .Columns.Count - 1
                    Dim strValue As String = " "
                    If .Columns(i).Visible = True Then
                        If Not Object.Equals(Convert.ToString(.Rows(r).Cells(i).Value), "") Then strValue = .Rows(r).Cells(i).Value.ToString
                    End If
                    If UCase(strValue) = UCase("System.Drawing.Bitmap") Then strValue = Nothing
                    strDataLine = strDataLine & strValue & ";"
                Next
                If strDataLine.Length > 0 Then strDataLine = Mid(strDataLine, 1, strDataLine.Length - 1)
                arrPrintData.Add(strDataLine)
            Next

        End With

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = dGrid.ColumnCount
            .strColumnHeaders = strColumnHeaders
            .strColumnAlignments = strColumnAlignments
            .strColumnWidths = strColumnWidths
            .strFooterCaption = "Business Light Edge © 2017"
            .strMainCaption = UCase("LOAN AMORTIZATION")
            .strMainHeader2 = ReportHeader.ToUpper
            .strMainHeader3 = ""
            .strColumnTotals = strColumnTotals
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Black
            .BorderColor = Color.WhiteSmoke
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFontItalic
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = True
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = strColumnVisible
            .strColumnFormating = strColumnFormatting
            .strSummaryTotals = strColumnTotals
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        MsgBox(Err.Description)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmIssueLoan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLoanCustomers()
    End Sub

    Private Sub LoadLoanCustomers()

        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        strSql = "SELECT [AccountNumber] +'-'+ [AccountName] FROM [Customers] (NOLOCK) 
            WHERE [CustomerType] = 'LOAN' ORDER BY [AccountName]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboClients.Items.Clear()
        cboClients.Items.Add("")
        While objReader.Read
            cboClients.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Loan Clients Load"
        ShowErrorMessage()
    End Sub

End Class