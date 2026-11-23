Imports CommonLibrary.Commons

Module modReports

    Dim winCursor As System.Windows.Forms.Cursor
    Dim arrPrintData As ArrayList

    Public Sub InventoryListing()
        On Error GoTo RaiseErr

        winCursor = Cursors.WaitCursor
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ItemCode as [Item Code], GroupName as [Description], Category, " _
            & "SubCategory as [Sub Category], Quantity as [Qty], CAST(CostPrice AS DECIMAL (10,2)) AS [Cost Price], " _
            & "CAST(SellingPrice AS DECIMAL (10,2)) AS [Sale Price], Location, Offering " _
            & "FROM InventoryItems ORDER BY ItemCode", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        arrPrintData = New ArrayList
        While objReader.Read
            arrPrintData.Add(objReader(0) & ";" & objReader(1) & ";" & objReader(2) & ";" & _
                objReader(3) & ";" & objReader(4) & ";" & objReader(5) & ";" & _
                objReader(6) & ";" & objReader(7) & ";" & objReader(8))
        End While

        Dim strPrintDetails(0 To arrPrintData.Count - 1) As String

        For i As Integer = 0 To arrPrintData.Count - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 13
            .strColumnHeaders = "EMPLOYEE|100.00|50.00|20.00|10.00|5.00|2.00|1.00|0.50|0.10|0.05|0.01|NET"
            .strColumnAlignments = "0|2|2|2|2|2|2|2|2|2|2|2|2"
            .strColumnWidths = "120|40|40|40|40|40|40|40|40|40|40|40|60"
            .strFooterCaption = "COINAGE ANALYSIS - DETAILED"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "COINAGE ANAYLYSIS - " & UCase(strCompanyName)
            .strMainHeader3 = "PERIOD " & strReportPeriod & " RUN " & intReportRunNumber & " BETWEEN " & UCase(strReportStartDate) & " AND " & UCase(strReportEndDate)
            .strColumnTotals = "NO|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("LightGray")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()


        winCursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        winCursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory List Print"
        ShowErrorMessage()
    End Sub

End Module
