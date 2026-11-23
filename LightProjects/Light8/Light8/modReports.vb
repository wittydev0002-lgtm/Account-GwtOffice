Imports System.Windows.Forms
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Module modReports

    Public Sub PrintReceivedInventoryReport()
        Dim strLocation As String = Nothing
        Dim intLimit As Integer = 0

        Dim strSql As String = "select CONVERT(NVARCHAR, ordersreceipt.TransDate, 105) AS [DATE], " _
            & "ordersreceipt.ItemCode, InventoryItems.GroupName, ordersreceipt.BaseBarcode, " _
            & "ordersreceipt.SerialNumbers, ordersreceipt.Quantity, ordersreceipt.DestinationBranch from ordersreceipt LEFT OUTER JOIN " _
            & "InventoryItems ON OrdersReceipt.ItemCode = InventoryItems.ItemCode " _
            & " WHERE TransDate BETWEEN '" & Format(StartDate, "dd-MMM-yyyy") & "' AND " _
            & "'" & Format(EndDate, "dd-MMM-yyyy") & "' ORDER BY " _
            & "ordersreceipt.DestinationBranch, ordersreceipt.ItemCode, ordersreceipt.TransDate"
        Dim strKeyValue As String = Nothing
        Dim i As Integer = 0
        Dim p As Integer = 1
        Dim intRunningQuantity As Integer = 0

        Try
            'Create the table layout for the report
            Dim arrPrintLine As New ArrayList
            Dim strLine As String = Nothing 'The formatted line entry to be added to the array list
            'Output Details            
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReader.Read

                Dim strDescription As String = Nothing
                Dim strItemCode As String = Nothing
                Dim strBarcode As String = Nothing
                Dim strReceiptDate As String = Nothing
                Dim strSerialNumber As String = Nothing
                Dim strDestinationBranch As String = Nothing
                Dim intQty As Integer = 0

                Dim strBlank As String = "" ' Just to allow the printing of empty cells
                'Assign the values
                If Not IsDBNull(objReader("Date").ToString) Then strReceiptDate = objReader("Date").ToString
                If Not IsDBNull(objReader("ItemCode").ToString) Then strItemCode = objReader("ItemCode").ToString
                If Not IsDBNull(objReader("GroupName").ToString) Then strDescription = objReader("GroupName").ToString
                If Not IsDBNull(objReader("BaseBarCode").ToString) Then strBarcode = objReader("BaseBarcode").ToString
                If Not IsDBNull(objReader("SerialNumbers").ToString) Then strSerialNumber = objReader("SerialNumbers").ToString
                If IsNumeric(objReader("Quantity").ToString) Then intQty = CInt(objReader("Quantity").ToString)
                If Not IsDBNull(objReader("DestinationBranch").ToString) Then strDestinationBranch = objReader("DestinationBranch").ToString

                If i = 0 Then strKeyValue = strItemCode

                If UCase(strKeyValue) <> UCase(strItemCode) Then
                    'Print the total line
                    strLine = " ; ; TOTAL ; ; ;" & intRunningQuantity & ";"
                    intRunningQuantity = 0
                    arrPrintLine.Add(strLine)
                    strLine = " ; ; ; ; ; ; "
                    arrPrintLine.Add(strLine)
                End If

                strKeyValue = strItemCode
                '****** PRINT RECORD LINE ********************************************
                strLine = strReceiptDate & ";" & UCase(strItemCode) & ";" & UCase(strDescription) & ";" & UCase(strBarcode) & ";" & UCase(strSerialNumber) & ";" & intQty & ";" & strDestinationBranch
                intRunningQuantity = intRunningQuantity + intQty
                arrPrintLine.Add(strLine)
                i = i + 1
                p = p + 1
            End While
            objReader.Close()
            Dim strPrintDetails(0 To arrPrintLine.Count - 1) As String
            For i = 0 To arrPrintLine.Count - 1
                strPrintDetails(i) = arrPrintLine.Item(i)
            Next

            Dim myReport As New SmartColumnReportWriter.SmartColumnReportWriter
            Dim DocumentPreview As New PrintPreviewDialog
            'Cursor = Cursors.WaitCursor

            With myReport
                .intNumberOfColumns = 7
                .intPrintRecordsCount = strPrintDetails.Length   'Or number of records in the text file
                .strColumnAlignments = "0|0|0|0|0|2|0"
                .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
                .strColumnHeaders = "DATE|ITEM CODE|DESCRIPTION|BARCODE|SER.NO.|QTY|BRANCH TO"
                .strColumnWidths = "50|150|200|60|60|40|150"
                .strColumnTotals = "NO|NO|NO|NO|NO|YES|NO"
                .FooterColor = Color.FromName("Black")
                .TitleColor = Color.FromName("Black")
                .DetailColor = Color.FromName("Black")
                .boolGroupDetails = False
                .boolPrintTotals = False
                .boolGenericReport = False
                .intKeyFieldIndex = 0
                .PrintSummary = False
                .DrawBorder = True
                .BorderColor = Color.FromName("WhiteSmoke")
                .DrawSummaryChart = False
                .VerticalLines = True
                .HorizontalLines = True
                .GridColor = Color.FromName("WhiteSmoke")
                .strPrintValues = strPrintDetails
                .strMainCaption = UCase(strCompanyName)
                .strMainHeader2 = "RECEIVED GOODS FOR THE PERIOD " & UCase(Format(StartDate, "dd-MMM-yyy")) & " AND " & UCase(Format(EndDate, "dd-MMM-yyyy"))
                .strFooterCaption = "Great Wits Financial Light. Technology In Motion"
                .DetailFont = fntFooterFont 'fntDetailsFont
                .HeaderFont = fntHeaderFont
                .FooterFont = fntFooterFont
                .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO"
                .boolPrintRecordCount = True
            End With
            'Cursor = Cursors.Default
            DocumentPreview.Document = myReport
            DocumentPreview.ShowDialog()
        Catch ex As Exception
            'Cursor = Cursors.Default
            boolAbort = True
            strErrorMessages = ex.Message
            gwt_comm.ShowErrorMessage()
        End Try
    End Sub


End Module
