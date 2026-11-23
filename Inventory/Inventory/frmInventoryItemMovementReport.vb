Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventoryItemMovementReport

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing
        strSql = "SELECT ItemCode +';'+GroupName AS " _
            & "[Items] FROM InventoryItems ORDER BY ItemCode"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "160;300"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboItems.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboItems.SelectedIndex = -1
            cboItems.Items.Clear()
            cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboItems.Items.AddRange(DropDownItems)
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On items data load"
        ShowErrorMessage()
    End Sub

    Private Sub frmInventoryItemMovementReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrPrintData As New ArrayList
        For n As Integer = 0 To dGrid.Rows.Count - 2
            Dim strDataRow As String = Nothing
            For i As Integer = 0 To dGrid.Columns.Count - 1
                If i = 0 Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(n).Cells(i).Value) Then strDataRow = dGrid.Rows(n).Cells(i).Value.ToString & ";" Else strDataRow = ";"
                Else
                    strDataRow = strDataRow & dGrid.Rows(n).Cells(i).Value.ToString & ";"
                End If
            Next
            strDataRow = Mid(strDataRow, 1, (strDataRow.Length - 1))
            arrPrintData.Add(strDataRow)
        Next

        'Add the details to the print class print array

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = UCase(arrPrintData.Item(i))
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 5
            .strColumnHeaders = "DATE IN|INPUT SERIAL #|DATE OUT|OUTPUT SERIAL #|IN-STOCK SERIAL #"
            .strColumnAlignments = "0|0|0|0|0"
            .strColumnWidths = "80|130|80|130|130"
            .strFooterCaption = "ITEM/PRODUCT TRACK"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "ITEM/PRODUCT TRACK - " & UCase(strUserBranch)
            .strMainHeader3 = UCase(cboItems.Text)
            .strColumnTotals = "NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
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
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On item track report print"
        ShowErrorMessage()
    End Sub

    Private Sub btnTrack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrack.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(cboItems.Text) Then
            MessageBox.Show("Please select the inventory item that you need to report on", "Missing Item Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboItems.Focus()
            Exit Sub
        End If
        If CDate(Format(dpStartDate.Value, "dd-MMM-yyyy")) > CDate(Format(dpEndDate.Value, "dd-MMM-yyyy")) Then
            MessageBox.Show("The start date must be less than the end date", "Date Selection Inconsistence", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dpStartDate.Focus()
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        Dim arrDataIn As New ArrayList
        Dim arrDataOut As New ArrayList
        Dim arrDataLeft As New ArrayList

        Dim strSqlOrders As String = "SELECT CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "CONVERT(NVARCHAR, BaseBarcode) +'-'+ CONVERT(NVARCHAR, SerialNumbers) AS [Serial] from ordersreceipt " _
            & "WHERE transdate BETWEEN '" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "' " _
            & "AND ItemCode = '" & cboItems.Text & "' ORDER BY SerialNumbers, BaseBarcode"

        Dim strSqlTransfersIn As String = "SELECT CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "CONVERT(NVARCHAR, BaseBarcode) +'-'+ CONVERT(NVARCHAR, SerialNumber) AS [Serial] FROM InventoryTransfersIn " _
            & "WHERE TransDate BETWEEN '" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "' " _
            & "AND ItemCode = '" & cboItems.Text & "' ORDER BY SerialNumber"

        ' ******************* GET THE TRANSFERS OUT RECORDS ******************************************

        Dim strSqlSales As String = "SELECT CONVERT(NVARCHAR, TransDate, 105) AS [Date], CONVERT(NVARCHAR, SerialNumbers) AS [Serial] " _
            & "FROM Sales WHERE transdate BETWEEN '" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "' " _
            & "AND ItemCode = '" & cboItems.Text & "' ORDER BY SerialNumbers"

        Dim strSqlInvoices As String = "SELECT CONVERT(NVARCHAR, TransDate, 105) AS [Date], CONVERT(NVARCHAR, SerialNumbers) AS [Serial] " _
            & "FROM CustomerSales WHERE transdate BETWEEN '" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "' " _
            & "AND ItemCode = '" & cboItems.Text & "' ORDER BY SerialNumbers"

        Dim strSqlTransfersOut As String = "SELECT CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "CONVERT(NVARCHAR, BaseBarcode) +'-'+ CONVERT(NVARCHAR, SerialNumber) AS [Serial] FROM InventoryTransfers " _
            & "WHERE TransDate BETWEEN '" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndDate.Value, "dd-MMM-yyyy") & "' " _
            & "AND ItemCode = '" & cboItems.Text & "' ORDER BY SerialNumber "

        '******************** GET SERIAL NUMBERS CUURENTLY ON DATABASE ******************************

        Dim strSqlSerialNumbers As String = "SELECT SerialNumber from SerialNumbers WHERE ItemCode = '" & cboItems.Text & "' ORDER BY SerialNumber"

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        objCommand = New Data.OleDb.OleDbCommand(strSqlOrders, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            'arrDataIn.Add("RECEIVED;ORDER")
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    arrDataIn.Add(objReader(0).ToString & ";" & objReader(1).ToString)
                End If
            End While
        End If
        objReader.Close()

        objCommand = New Data.OleDb.OleDbCommand(strSqlTransfersIn, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            'arrDataIn.Add(" ; ")
            arrDataIn.Add("TRANSFERS;IN")
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    arrDataIn.Add(objReader(0).ToString & ";" & objReader(1).ToString)
                End If
            End While
        End If
        objReader.Close()

        objCommand = New Data.OleDb.OleDbCommand(strSqlSales, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            'arrDataOut.Add("CASH;SALES")
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    arrDataOut.Add(objReader(0).ToString & ";" & objReader(1).ToString)
                End If
            End While
        End If
        objReader.Close()

        objCommand = New Data.OleDb.OleDbCommand(strSqlInvoices, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            'arrDataOut.Add(" ; ")
            'arrDataOut.Add("INVOICED;SALES")
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    arrDataOut.Add(objReader(0).ToString & ";" & objReader(1).ToString)
                End If
            End While
        End If
        objReader.Close()

        objCommand = New Data.OleDb.OleDbCommand(strSqlTransfersOut, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            'arrDataOut.Add(" ; ")
            'arrDataOut.Add("TRANSFERS;OUT")
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    arrDataOut.Add(objReader(0).ToString & ";" & objReader(1).ToString)
                End If
            End While
        End If
        objReader.Close()

        objCommand = New Data.OleDb.OleDbCommand(strSqlSerialNumbers, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            While objReader.Read
                If Not IsDBNull(objReader(0).ToString) Then
                    arrDataLeft.Add(" ; " & objReader(0).ToString)
                End If
            End While
        End If
        objReader.Close()

        'Compare the counts and make equal

        Dim intCnt As Integer = arrDataIn.Count
        If arrDataOut.Count > intCnt Then intCnt = arrDataOut.Count
        If arrDataLeft.Count > intCnt Then intCnt = arrDataLeft.Count

        For i As Integer = arrDataIn.Count To intCnt
            arrDataIn.Add(" ; ")
        Next
        For i As Integer = arrDataOut.Count To intCnt
            arrDataOut.Add(" ; ")
        Next
        For i As Integer = arrDataLeft.Count To intCnt
            arrDataLeft.Add(" ; ")
        Next


        dGrid.Rows.Clear()
        For i As Integer = 0 To arrDataIn.Count - 1
            Dim strBuffer1() As String = Split(arrDataIn.Item(i), ";")
            Dim strBuffer2() As String = Split(arrDataOut.Item(i), ";")
            Dim strBuffer3() As String = Split(arrDataLeft.Item(i), ";")
            dGrid.Rows.Add(strBuffer1(0), strBuffer1(1), strBuffer2(0), strBuffer2(1), strBuffer3(1))
        Next

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On item track report print"
        ShowErrorMessage()
    End Sub

End Class
