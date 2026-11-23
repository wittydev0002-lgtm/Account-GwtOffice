Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmClientBalances

    Private Sub frmClientBalances_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim arrCustomers As New ArrayList
        Dim strSql As String = Nothing

        If UCase(strCalledBy) = UCase("Customers") Then
            strSql = "SELECT AccountNumber, AccountName FROM Customers ORDER BY AccountName"
            Me.Text = "Customer Balances"
        Else
            strSql = "SELECT AccountNumber, AccountName FROM Suppliers ORDER BY AccountName"
            Me.Text = "Supplier Balances"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim dblBalance As Double = 0
            If UCase(strCalledBy) = UCase("Customers") Then
                dblBalance = gwt_comm.ClientBalanceOnSpecificDate(objReader(0).ToString, CDate(gwt_comm.shortMonthDateFormat(dpCutoffDate.Value)), "Customer")
            Else
                dblBalance = gwt_comm.ClientBalanceOnSpecificDate(objReader(0).ToString, CDate(gwt_comm.shortMonthDateFormat(dpCutoffDate.Value)), "Supplier")
            End If

            If dblBalance <> 0 Then
                arrCustomers.Add(UCase(objReader(0).ToString) & ";" & UCase(objReader(1).ToString) & ";" & dblBalance & ";")
            End If
        End While
        objReader.Close()

        Dim dblTotal As Double = 0

        With dGrid
            .Rows.Clear()
            For p As Integer = 0 To arrCustomers.Count - 1
                Dim strBuffer() As String = Split(arrCustomers.Item(p), ";")
                Dim dblVal As Double = 0
                If IsNumeric(strBuffer(2)) Then dblVal = CDbl(strBuffer(2))
                .Rows.Add(strBuffer(0), strBuffer(1), Format(dblVal, "##0.00"))
                dblTotal = dblTotal + dblVal
            Next
        End With

        lblTotals.Text = CStr(Format(dblTotal, "#,##0.00"))

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Balance Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmClientBalances_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 670 : Me.Height = 475
    End Sub

    Private Sub PrintData()
        Dim arrCustomers As New ArrayList

        Dim strSql As String = Nothing
        Dim strClientType As String = Nothing

        If UCase(strCalledBy) = UCase("customers") Then
            strSql = "SELECT AccountNumber, AccountName FROM Customers ORDER BY AccountName"
            strClientType = "customer"
        Else
            strClientType = "supplier"
            strSql = "SELECT AccountNumber, AccountName FROM Suppliers ORDER BY AccountName"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim dblBalance As Double = gwt_comm.ClientBalanceOnSpecificDate(objReader(0).ToString, CDate(gwt_comm.shortMonthDateFormat(dpCutoffDate.Value)), strClientType)
            If dblBalance <> 0 Then
                arrCustomers.Add(UCase(objReader(0).ToString) & ";" & UCase(objReader(1).ToString) & ";" & dblBalance & ";")
            End If
        End While
        objReader.Close()
        'Send the information to the printer

        Dim strPrintDetails(0 To arrCustomers.Count - 1) As String
        For i As Integer = 0 To arrCustomers.Count - 1
            strPrintDetails(i) = arrCustomers.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 4
            .strColumnHeaders = "CLIENT NAME|ACCOUNT NO|AMOUNT|"
            .strColumnAlignments = "0|0|2|0"
            .strColumnWidths = "150|250|100|100"
            If UCase(strCalledBy) = UCase("customers") Then .strFooterCaption = "Customer balances report" Else .strFooterCaption = "Supplier Balances Report"

            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            If UCase(strCalledBy) = UCase("customers") Then
                .strMainHeader2 = "CUSTOMER BALANCES AS AT " & UCase(gwt_comm.shortMonthDateFormat(dtSetDate))
            Else
                .strMainHeader2 = "SUPPLIER BALANCES AS AT " & UCase(gwt_comm.shortMonthDateFormat(dtSetDate))
            End If

            '.strMainHeader3 = "PERIOD COVERED " & UCase(Format(StartDate, "dd-MMM-yyyy")) & " - " & UCase(Format(EndDate, "dd-MMM-yyyy"))
            .strColumnTotals = "NO|NO|YES|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|YES|NO"
            .strSummaryTotals = "NO|NO|YES|NO"
            '.intKeyFieldIndex = 7
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Client Balance printing"
        ShowErrorMessage()
    End Sub

End Class