Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBaleListing

    Dim boolFormLoading As Boolean

    Private Sub frmBaleListing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        boolFormLoading = True
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        If gwt_comm.CheckTableExistence("BaleItems") = False Then
            'PRICE	coupon	SALEDATE	GROWER	SUFFIX	lotnumber	BALEEXT	weight	tare	moisture	BUYERCODE	customergrade	controlgrade

            strSql = "CREATE TABLE BaleItems ([Price][FLOAT] NOT NULL DEFAULT 0, [Barcode][NVARCHAR](35) NOT NULL PRIMARY KEY, " _
                & "[SaleDate][SmallDateTime] NULL, [Grower][NVARCHAR](150) NOT NULL DEFAULT '', [Suffix][NVARCHAR](4) NOT NULL DEFAULT '', " _
                & "[LotNumber][NVARCHAR](35) NOT NULL DEFAULT '', [BaleExtension][NVARCHAR](10) NOT NULL DEFAULT '', " _
                & "[Weight][FLOAT] NOT NULL DEFAULT 0, [Tare][FLOAT] NOT NULL DEFAULT 0, [Moisture][FLOAT] NOT NULL DEFAULT 0, " _
                & "[BuyerCode][NVARCHAR](3) NOT NULL DEFAULT '', [CustomerGrade][NVARCHAR](10) NOT NULL DEFAULT '', " _
                & "[ControlGrade][NVARCHAR](5) NOT NULL DEFAULT '')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("BaleItems", "SentStatus") = False Then
            strSql = "ALTER TABLE BaleItems ADD [SentStatus][NVARCHAR](3) NOT NULL DEFAULT 'NO'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("BaleItems", "SendBatchNo") = False Then
            strSql = "ALTER TABLE BaleItems ADD [SendBatchNo][INT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("BaleItems", "TransmissionDate") = False Then
            strSql = "ALTER TABLE BaleItems ADD [TransmissionDate][SmallDateTime] NULL"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("BaleItems", "DriverName") = False Then
            strSql = "ALTER TABLE BaleItems ADD [DriverName][NVARCHAR](250) NOT NULL DEFAULT ''"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("BaleItems", "FileNumber") = False Then
            strSql = "ALTER TABLE BaleItems ADD [FileNumber][INT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        If gwt_comm.CheckColumnExistence("BaleHeaders", "FileNumber") = False Then
            strSql = "ALTER TABLE BaleHeaders ADD [FileNumber][INT] NOT NULL DEFAULT 0"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If
        LoadData()
        boolFormLoading = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Bale Items Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        strSql = "UPDATE BaleItems SET Tare = 0"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "SELECT Barcode as [Bar Code], BaleExtension AS [Ext], Grower as [Grower], Suffix AS [SFX], " _
                    & "CAST(Price AS decimal(10,2)) AS [Price], CAST(Moisture AS decimal(10,2)) " _
                    & "AS [Moisture], CAST(Tare AS decimal(10,2)) AS [Tare], CAST(Weight AS decimal(10,2)) AS [Weight], " _
                    & "BuyerCode AS [Buyer Code], CustomerGrade AS [Customer Grade], ControlGrade AS [Control Grade], " _
                    & "LotNumber AS [Lot No.] FROM BaleItems ORDER BY Barcode"
        
        grd.Columns.Clear()
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        grd.DataSource = dTable

        Me.grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To grd.Columns.Count - 1
            grd.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'If p = 2 Then grd.Columns(p).Visible = False
            If p > 3 Or p < 8 Then
                grd.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        lblTotalSelected.Text = grd.RowCount
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Bale Items Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmBaleDetails
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub GetSelectedDetails()
        Dim CurrentCellValue As String
        CurrentCellValue = grd.CurrentRow.Cells(0).Value
        strSelectedCodeDescription = grd.CurrentRow.Cells(1).Value
        strActiviteStatus = grd.CurrentRow.Cells(6).Value
        strInventoryItemCode = CurrentCellValue
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        GetSelectedDetails()
        Dim iRowIndex As Integer = grd.CurrentRow.Index
        boolEditStatus = True
        Dim f As New frmBaleDetails
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        On Error GoTo RaiseErr
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        Dim strFileName As String = ofd.FileName

        If Not String.IsNullOrEmpty(strFileName) Then
            If System.IO.File.Exists(strFileName) Then
                Dim objFile As New System.IO.StreamReader(strFileName)
                Dim strData As String = objFile.ReadToEnd
                objFile.Close()

                Dim strLines() As String = Split(strData, vbCrLf)
                For p As Integer = 1 To strLines.Length - 1
                    If Not String.IsNullOrEmpty(strLines(p)) Then
                        Dim strFields() As String = Split(strLines(p), "|")

                        If RecordExists(strFields(1)) = False Then
                            If Not IsNumeric(strFields(0)) Then strFields(0) = "0"
                            If Not IsDate(strFields(2)) Then strFields(2) = Nothing
                            If Not IsNumeric(strFields(7)) Then strFields(7) = "0"
                            If Not IsNumeric(strFields(8)) Then strFields(8) = "0"
                            If Not IsNumeric(strFields(9)) Then strFields(9) = "0"
                            If Not IsNumeric(strFields(13)) Then strFields(13) = "0"
                            Dim strSql As String = "INSERT INTO BaleItems ([Price],[Barcode],[SaleDate]," _
                                & "[Grower],[Suffix],[LotNumber],[BaleExtension],[Weight],[Tare],[Moisture]," _
                                & "[BuyerCode],[CustomerGrade],[ControlGrade], [GrossAmount]) VALUES " _
                                & "(" & strFields(0) & ", '" & strFields(1) & "', '" & strFields(2) & "', " _
                                & "'" & strFields(3) & "', '" & strFields(4) & "', '" & strFields(5) & "', " _
                                & "'" & strFields(6) & "', " & strFields(7) & ", " & strFields(8) & ", " _
                                & "" & strFields(9) & ", '" & strFields(10) & "', '" & strFields(11) & "', " _
                                & "'" & strFields(12) & "', " & strFields(13) & ")"
                            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()
                        End If

                    End If
                Next
                MsgBox("Done")
            End If
        End If

        LoadData()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Bale Items Import"
        ShowErrorMessage()
    End Sub

    Private Function RecordExists(ByVal Barcode As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim strSql As String = "SELECT Barcode FROM BaleItems WHERE Barcode = '" & Barcode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            boolReturn = True
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Bale Items Import"
        ShowErrorMessage()
    End Function

    Private Sub txtSearchString_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchString.TextChanged
        SearchForItem("")
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        If boolFormLoading = True Then Exit Sub
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        strActiveSearch = strFind
        Cursor = Cursors.WaitCursor

        grd.Columns.Clear()
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim strSql As String = Nothing

        Select Case UCase(cboSearchBy.Text)
            Case Is = UCase("Barcode")
                strSql = "SELECT Barcode as [Bar Code], BaleExtension AS [Ext], Grower as [Grower], Suffix AS [SFX], " _
                    & "CAST(Price AS decimal(10,2)) AS [Price], CAST(Moisture AS decimal(10,2)) " _
                    & "AS [Moisture], CAST(Tare AS decimal(10,2)) AS [Tare], CAST(Weight AS decimal(10,2)) AS [Weight], " _
                    & "BuyerCode AS [Buyer Code], CustomerGrade AS [Customer Grade], ControlGrade AS [Control Grade], " _
                    & "LotNumber AS [Lot No.] FROM BaleItems WHERE Barcode LIKE '%" & strFind & "%' " _
                    & "ORDER BY Barcode, LotNumber, Grower"
            Case Is = UCase("Grower")
                strSql = "SELECT Barcode as [Bar Code], BaleExtension AS [Ext], Grower as [Grower], Suffix AS [SFX], " _
                    & "CAST(Price AS decimal(10,2)) AS [Price], CAST(Moisture AS decimal(10,2)) " _
                    & "AS [Moisture], CAST(Tare AS decimal(10,2)) AS [Tare], CAST(Weight AS decimal(10,2)) AS [Weight], " _
                    & "BuyerCode AS [Buyer Code], CustomerGrade AS [Customer Grade], ControlGrade AS [Control Grade], " _
                    & "LotNumber AS [Lot No.] FROM BaleItems WHERE Grower LIKE '%" & strFind & "%' " _
                    & "ORDER BY Grower, LotNumber, Barcode"
            Case Is = UCase("Lot Number")
                strSql = "SELECT Barcode as [Bar Code], BaleExtension AS [Ext], Grower as [Grower], Suffix AS [SFX], " _
                    & "CAST(Price AS decimal(10,2)) AS [Price], CAST(Moisture AS decimal(10,2)) " _
                    & "AS [Moisture], CAST(Tare AS decimal(10,2)) AS [Tare], CAST(Weight AS decimal(10,2)) AS [Weight], " _
                    & "BuyerCode AS [Buyer Code], CustomerGrade AS [Customer Grade], ControlGrade AS [Control Grade], " _
                    & "LotNumber AS [Lot No.] FROM BaleItems WHERE LotNumber LIKE '%" & strFind & "%' " _
                    & "ORDER BY LotNumber, Grower, Barcode"
            Case Else
                strSql = "SELECT Barcode as [Bar Code], BaleExtension AS [Ext], Grower as [Grower], Suffix AS [SFX], " _
                    & "CAST(Price AS decimal(10,2)) AS [Price], CAST(Moisture AS decimal(10,2)) " _
                    & "AS [Moisture], CAST(Tare AS decimal(10,2)) AS [Tare], CAST(Weight AS decimal(10,2)) AS [Weight], " _
                    & "BuyerCode AS [Buyer Code], CustomerGrade AS [Customer Grade], ControlGrade AS [Control Grade], " _
                    & "LotNumber AS [Lot No.] FROM BaleItems WHERE Barcode LIKE '%" & strFind & "%' " _
                    & "ORDER BY Barcode, LotNumber, Grower"
        End Select

        grd.Columns.Clear()
        Me.grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        grd.DataSource = dTable

        Me.grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        grd.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To grd.Columns.Count - 1
            grd.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'If p = 2 Then grd.Columns(p).Visible = False
            If p = 3 Or p = 4 Then
                grd.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        lblTotalSelected.Text = grd.RowCount
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Tobacco Item Search"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub grd_DoubleClick(sender As Object, e As System.EventArgs) Handles grd.DoubleClick
        GetSelectedDetails()
        Dim iRowIndex As Integer = grd.CurrentRow.Index
        boolEditStatus = True
        Dim f As New frmBaleDetails
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        DeleteSelectedItems()
    End Sub

    Private Sub DeleteSelectedItems()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If grd.Rows.Count > 0 Then
            'GetSelectedDetails()
            If MessageBox.Show("Are you sure you want to delete the selected items?", _
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                strInventoryItemCode = grd.CurrentRow.Cells(0).Value.ToString
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM BaleItems WHERE BarCode = '" & strInventoryItemCode & "'", cnn)
                objCommand.ExecuteNonQuery()
                MessageBox.Show("Item Has Been Deleted successfully", "Item Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Tobacco Item Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnTonnage_Click(sender As System.Object, e As System.EventArgs) Handles btnTonnage.Click
        TonnageReport()
    End Sub

    Private Sub TonnageReport()

        On Error GoTo RaiseErr

        Dim arrPrintData As New ArrayList

        Dim strSql As String = "SELECT Barcode, Grower, LotNumber AS [Lot], ControlGrade AS [Grade], " _
            & "CAST(Weight AS DECIMAL (30,2)) AS [Mass], CAST(Price AS DECIMAL (30,2)) AS [Price] FROM BaleItems " _
            & "WHERE SentStatus = 'NO' ORDER BY LotNumber, ControlGrade"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            arrPrintData.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" & objReader(2).ToString & ";" _
                             & objReader(3).ToString & ";" & objReader(4).ToString & ";" & objReader(5).ToString)
        End While
        objReader.Close()

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For n As Integer = 0 To arrPrintData.Count - 1
            strPrintDetails(n) = arrPrintData.Item(n)
        Next
        'Send the details to the printer
        Dim myReport As New SmartColumnReportWriter.SmartColumnReportWriter
        Dim DocumentPreview As New PrintPreviewDialog
        Cursor = Cursors.WaitCursor

        With myReport
            .intNumberOfColumns = 6
            .intPrintRecordsCount = strPrintDetails.Length   'Or number of records in the text file
            .strColumnAlignments = "0|0|0|0|2|2"
            .strColumnFormating = "NO|NO|NO|NO|YES|YES"
            .strColumnHeaders = "BARCODE|GROWER|LOT|GRADE|MASS|PRICE"
            .strColumnWidths = "100|100|100|100|100|100"
            .strColumnTotals = "NO|NO|NO|NO|YES|YES"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .boolGroupDetails = True
            .boolPrintTotals = False
            .boolGenericReport = False
            .intKeyFieldIndex = 2
            .PrintSummary = False
            .DrawBorder = True
            .BorderColor = Color.FromName("WhiteSmoke")
            .DrawSummaryChart = False
            .VerticalLines = True
            .HorizontalLines = True
            .GridColor = Color.FromName("WhiteSmoke")
            .strPrintValues = strPrintDetails
            .strMainCaption = "TONNAGE REPORT AS AT " & UCase(gwt_comm.shortMonthDateFormat(Now))
            .strFooterCaption = "Great Wits Financial Light. Technology In Motion"
            .DetailFont = fntFooterFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .strSummaryTotals = "NO|NO|NO|NO|YES|YES"
            .boolPrintRecordCount = True
        End With
        Cursor = Cursors.Default
        DocumentPreview.Document = myReport
        DocumentPreview.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Tonnage Report Print"
        gwt_comm.ShowErrorMessage()
    End Sub


    Private Sub StockValuePerGrade()
        On Error GoTo RaiseErr

        Dim arrPrintData As New ArrayList

        Dim strSql As String = "SELECT ControlGrade AS [Grade], " _
            & "CAST(SUM(Weight) AS DECIMAL (30,2)) AS [Mass], CAST(AVG(Weight) AS DECIMAL (30,2)) AS [AVg1], " _
            & "CAST(SUM(Price) AS DECIMAL (30,2)) AS [Price], CAST(AVG(Price) AS DECIMAL (30,2)) AS [AVg2] FROM BaleItems " _
            & "WHERE SentStatus = 'NO' GROUP BY ControlGrade ORDER BY ControlGrade"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            arrPrintData.Add(objReader(0).ToString & ";" & objReader(1).ToString & ";" & objReader(2).ToString & ";" & objReader(3).ToString & ";" & objReader(4).ToString)
        End While
        objReader.Close()

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For n As Integer = 0 To arrPrintData.Count - 1
            strPrintDetails(n) = arrPrintData.Item(n)
        Next
        'Send the details to the printer
        Dim myReport As New SmartColumnReportWriter.SmartColumnReportWriter
        Dim DocumentPreview As New PrintPreviewDialog
        Cursor = Cursors.WaitCursor

        With myReport
            .intNumberOfColumns = 5
            .intPrintRecordsCount = strPrintDetails.Length   'Or number of records in the text file
            .strColumnAlignments = "0|2|2|2|2"
            .strColumnFormating = "NO|YES|YES|YES|YES"
            .strColumnHeaders = "GRADE|MASS|AV.KG|PRICE|AV.$"
            .strColumnWidths = "100|100|100|100|100"
            .strColumnTotals = "NO|YES|YES|YES|YES"
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
            .strMainCaption = "VALUE PER GRADE REPORT AS AT " & UCase(gwt_comm.shortMonthDateFormat(Now))
            .strFooterCaption = "Great Wits Financial Light. Technology In Motion"
            .DetailFont = fntFooterFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .strSummaryTotals = "NO|YES|YES|YES|YES"
            .boolPrintRecordCount = True
        End With
        Cursor = Cursors.Default
        DocumentPreview.Document = myReport
        DocumentPreview.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Stock Value Per Grade Report Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnValuePerGrade_Click(sender As System.Object, e As System.EventArgs) Handles btnValuePerGrade.Click
        StockValuePerGrade()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

End Class