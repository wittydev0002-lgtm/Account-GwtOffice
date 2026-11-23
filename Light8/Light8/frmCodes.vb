Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports DevComponents.DotNetBar

Public Class frmCodes

    Dim _widthLeftRight As Integer

    Private Sub frmCodes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolRunningForDisplay = True
        LoadCodes()
        boolRunningForDisplay = False
    End Sub

    Private Sub dGrid_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.SelectionChanged
        If boolRunningForDisplay = True Then Exit Sub
        If dGrid.Rows.Count > 0 Then
            DisplayCodeData(dGrid.CurrentRow.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub DisplayCodeData(ByVal CodeNumber As Integer)
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim objCmd As New Data.OleDb.OleDbCommand("SELECT CodeType, TaxType, TaxTreatment, " _
            & "DisplayStatus, YtdStatus, ProRataInd, BalanceCode, InterestCode, InterestRateRegister, " _
            & "YtdCode, PayslipDisplay, LedgerAccount, LedgerSide, LedgerCostCode FROM SystemCodes " _
            & "WHERE CodeNo = " & CInt(CodeNumber) & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmd.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            For n As Integer = 0 To objReader.FieldCount - 1
                dgrdDetails.Rows(n).Cells(1).Value = objReader(n).ToString
            Next
        End If
        objReader.Close()

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Payroll Code Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadCodes()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing
        If gwt_comm.CheckTableExistence("SystemPayrollCodeMaps") = False Then
            strSql = "CREATE TABLE SystemPayrollCodeMaps ([CodeNo][INT] NOT NULL DEFAULT 0)"
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            For p As Integer = 1 To 1000
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO " _
                    & "SystemPayrollCodeMaps (CodeNo) VALUES (" & p & ")", cnn)
                objCommand.ExecuteNonQuery()
            Next
        End If

        strSql = "SELECT RIGHT(10000 + SystemPayrollCodeMaps.CodeNo, 4) AS [No.], SystemCodes.Description AS [Description], " _
            & "SystemCodes.CodeType AS [Type],  SystemCodes.TaxType AS [Tx Type], SystemCodes.TaxTreatment AS [Tx Usage], " _
            & "SystemCodes.DisplayStatus AS [Display],  SystemCodes.YtdCode AS [YTD Code], " _
            & "SystemCodes.LedgerAccount AS [Ledger Account] FROM SystemPayrollCodeMaps " _
            & "LEFT OUTER JOIN SystemCodes ON SystemPayrollCodeMaps.CodeNo = SystemCodes.CodeNo ORDER BY SystemPayrollCodeMaps.CodeNo"

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        With dgrdDetails
            .Rows.Add("Code Type")
            .Rows.Add("Tax Type")
            .Rows.Add("Tax Usage")
            .Rows.Add("Display")
            .Rows.Add("Is YTD")
            .Rows.Add("Prorata")
            .Rows.Add("Balance Code")
            .Rows.Add("Interest Code")
            .Rows.Add("Interest Register")
            .Rows.Add("YTD Code")
            .Rows.Add("Payslip Display")
            .Rows.Add("Ledger Account")
            .Rows.Add("Ledger Side")
            .Rows.Add("Ledger Costing Code")

            'Color the first cell
            For p As Integer = 0 To dgrdDetails.Rows.Count - 1
                .Rows(p).Cells(0).Style.BackColor = Color.WhiteSmoke
            Next

        End With

        If dGrid.Rows.Count > 0 Then
            DisplayCodeData(dGrid.CurrentRow.Cells(0).Value.ToString)
        End If

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Payroll Codes Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        boolEditStatus = True
        GetSeletectedCode()
        boolChangesEffected = False
        If intSelectedCode > 0 Then
            Dim f As New frmCodeSetup
            f.ShowDialog()
        End If
        If boolChangesEffected = True Then
            LoadChangedCode(intSelectedCode)
        End If
    End Sub

    Private Sub GetSeletectedCode()
        strCodeDescription = Nothing
        intSelectedCode = 0
        If dGrid.Rows.Count > 0 Then
            intSelectedCode = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
            If Not Object.Equals(dGrid.CurrentRow.Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(1).Value.ToString) Then
                    strCodeDescription = dGrid.CurrentRow.Cells(1).Value
                End If
            End If
        End If
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        boolEditStatus = True
        GetSeletectedCode()
        boolChangesEffected = False
        If intSelectedCode > 0 Then
            Dim f As New frmCodeSetup
            f.ShowDialog()
        End If
        If boolChangesEffected = True Then
            LoadChangedCode(intSelectedCode)
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrPrintDetails As New ArrayList
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strLineData As String = Nothing
            For p As Integer = 0 To dGrid.ColumnCount - 1
                'FN=Arial;FS=8;FC=White;FB=False;FI=False;FU=False;BC=Navy;RH=25
                Dim strFontName As String = "Arial"
                Dim intFontSize As Integer = 6
                Dim strFontColor As String = "Black"
                Dim strFontBold As String = "False"
                Dim strFontItalic As String = "False"
                Dim strFontUnderline As String = "False"
                Dim strBackColor As String = "White"
                Dim intRectangleHeight As Integer = 25
                Dim strPrintData As String = Nothing
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(p).Value), "")) Then
                    strPrintData = dGrid.Rows(i).Cells(p).Value.ToString
                    'Get the actual font and style used in the grid
                    Dim fnt As Font = dGrid.Rows(i).Cells(p).Style.Font
                    If fnt Is Nothing Then intFontSize = 6 Else intFontSize = fnt.Size
                    If fnt Is Nothing Then strFontName = "Ariel" Else strFontName = fnt.Name
                    Dim strFontStyle As String = "False"
                    If Not fnt Is Nothing Then strFontStyle = fnt.Style
                    If strFontStyle = "1" Then strFontBold = "True"
                    If strFontStyle = "2" Then strFontItalic = "True"
                    If strFontStyle = "3" Then ' Bold and italic
                        strFontBold = "True"
                        strFontItalic = "True"
                    End If
                    If strFontStyle = "4" Then strFontUnderline = "True"
                    If strFontStyle = "5" Then ' Bold and underline
                        strFontBold = "True"
                        strFontUnderline = "True"
                    End If
                    If strFontStyle = "6" Then ' italic and underline
                        strFontItalic = "True"
                        strFontUnderline = "True"
                    End If
                    If strFontStyle = "7" Then ' italic and underline
                        strFontItalic = "True"
                        strFontUnderline = "True"
                        strFontBold = "True"
                    End If
                End If
                strLineData = strLineData & strPrintData & "|FN=" & strFontName & ";FS=" & intFontSize _
                    & ";FC=" & strFontColor & ";FB=" & strFontBold & ";FI=" & strFontItalic & ";FU=" & strFontUnderline _
                    & ";BC=" & strBackColor & ";RH=" & intRectangleHeight & "</d>"
            Next
            strLineData = Mid(strLineData, 1, strLineData.Length - 4)
            arrPrintDetails.Add(strLineData)
        Next

        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        Dim strColumnHeaders As String = Nothing
        For i As Integer = 0 To dGrid.ColumnCount - 1
            strColumnHeaders = strColumnHeaders & dGrid.Columns(i).HeaderText & "|"
        Next
        strColumnHeaders = Mid(strColumnHeaders, 1, (strColumnHeaders.Length - 1))

        'Request for print properties
        Dim prnt As New PrintDialog
        prnt.ShowDialog()

        Dim intPrintPageAreaWidth As Integer = prnt.PrinterSettings.DefaultPageSettings.PaperSize.Width _
                - (prnt.PrinterSettings.DefaultPageSettings.Margins.Left + prnt.PrinterSettings.DefaultPageSettings.Margins.Right)

        'Widths are based on the percentage point of the paper size and the grid
        Dim strColumnWidths As String = Nothing
        Dim strColumsVisible As String = Nothing

        Dim intTotalGridWidth As Integer = 0
        'calculate the total column widths
        For y As Integer = 0 To dGrid.ColumnCount - 1
            intTotalGridWidth = intTotalGridWidth + dGrid.Columns(y).Width
        Next

        Dim intValidateWidth As Integer = 0
        For i As Integer = 0 To dGrid.ColumnCount - 1
            Dim intCurrentWidth As Integer = 0

            'Calculate the width based on the percentage in the grid
            Dim intEqualWidth As Integer = intPrintPageAreaWidth / dGrid.Columns.Count
            Dim intPercentagePrintArea As Integer = (dGrid.Columns(i).Width / intTotalGridWidth) * 100
            intCurrentWidth = intPrintPageAreaWidth * (intPercentagePrintArea / 100)

            strColumnWidths = strColumnWidths & intCurrentWidth & "|"

            If intCurrentWidth = 0 Then
                strColumsVisible = strColumsVisible & "NO" & "|"
            Else
                strColumsVisible = strColumsVisible & "YES" & "|"
            End If
            intValidateWidth = intValidateWidth + intCurrentWidth
        Next
        strColumnWidths = Mid(strColumnWidths, 1, (strColumnWidths.Length - 1))
        strColumsVisible = Mid(strColumsVisible, 1, (strColumsVisible.Length - 1))

        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = dGrid.ColumnCount
            .strColumnHeaders = UCase(strColumnHeaders)
            .strColumnWidths = strColumnWidths
            .strFooterCaption = "Payroll Codes"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "PAYROLL MASTER CODES"
            .strMainHeader3 = ""
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .HeaderFont = New Font("Verdana", 10, FontStyle.Bold)
            .FooterFont = New Font("Verdana", 6, FontStyle.Bold)
            .boolGenericReport = False
            .strPrintValues = strPrintDetails
            .VisibleColumns = strColumsVisible
            .DetailColor = Color.Black
            .DetailFont = fntDetailsFont
        End With
        Cursor = Cursors.Default
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Payroll Codes Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadChangedCode(CodeNo As Integer)
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReadData As Data.OleDb.OleDbDataReader

        Dim strSql As String = "SELECT RIGHT(10000 + SystemPayrollCodeMaps.CodeNo, 4) AS [No.], SystemCodes.Description AS [Description], " _
                   & "SystemCodes.CodeType AS [Type],  SystemCodes.TaxType AS [Tx Type], SystemCodes.TaxTreatment AS [Tx Usage], " _
                   & "SystemCodes.DisplayStatus AS [Display],  SystemCodes.YtdCode AS [YTD Code], " _
                   & "SystemCodes.LedgerAccount AS [Ledger Account] FROM SystemPayrollCodeMaps " _
                   & "LEFT OUTER JOIN SystemCodes ON SystemPayrollCodeMaps.CodeNo = SystemCodes.CodeNo " _
                   & "WHERE SystemCodes.CodeNo = " & CodeNo & " ORDER BY SystemPayrollCodeMaps.CodeNo"
        'strsql = "SELECT Description, CodeNo, CodeType, DisplayStatus, " _
        '    & "TaxType, TaxTreatment, ProrataInd, BalanceCode, InterestCode, InterestRateRegister, " _
        '    & "YtdCode, UnitCode, PayslipDisplay, LedgerAccount, LedgerSide FROM SystemCodes WHERE CodeNo = " & CodeNo & ""
        'Get the code information from the table
        objCommand = New Data.OleDb.OleDbCommand(strsql, cnn)
        objReadData = objCommand.ExecuteReader

        If objReadData.HasRows Then
            objReadData.Read()
            With dGrid
                .Rows(CodeNo - 1).Cells(0).Value = CStr(Format(CInt(objReadData(0).ToString), "0000"))
                If Not IsDBNull(objReadData(0).ToString) Then
                    .Rows(CodeNo - 1).Cells(1).Value = objReadData(1).ToString
                End If
                If Not IsDBNull(objReadData(2).ToString) Then
                    .Rows(CodeNo - 1).Cells(2).Value = objReadData(2).ToString
                End If
                If Not IsDBNull(objReadData(3).ToString) Then
                    .Rows(CodeNo - 1).Cells(3).Value = objReadData(3).ToString
                End If

                If Not IsDBNull(objReadData(4).ToString) Then
                    .Rows(CodeNo - 1).Cells(4).Value = objReadData(4).ToString
                End If
                If Not IsDBNull(objReadData(5).ToString) Then
                    .Rows(CodeNo - 1).Cells(5).Value = objReadData(5).ToString
                End If
                If Not IsDBNull(objReadData(6).ToString) Then
                    .Rows(CodeNo - 1).Cells(6).Value = objReadData(6).ToString
                End If
                If Not IsDBNull(objReadData(7).ToString) Then
                    .Rows(CodeNo - 1).Cells(7).Value = objReadData(7).ToString
                End If
                'If Not IsDBNull(objReadData(8).ToString) Then
                '    .Rows(CodeNo - 1).Cells(8).Value = objReadData(8).ToString
                'End If
                'If Not IsDBNull(objReadData(9).ToString) Then
                '    .Rows(CodeNo - 1).Cells(9).Value = objReadData(9).ToString
                'End If
                'If Not IsDBNull(objReadData(10).ToString) Then
                '    .Rows(CodeNo - 1).Cells(10).Value = objReadData(10).ToString
                'End If
                'If Not IsDBNull(objReadData(11).ToString) Then
                '    .Rows(CodeNo - 1).Cells(11).Value = objReadData(11).ToString
                'End If
                'If Not IsDBNull(objReadData(12).ToString) Then
                '    .Rows(CodeNo - 1).Cells(12).Value = objReadData(12).ToString
                'End If
                'If Not IsDBNull(objReadData(13).ToString) Then
                '    .Rows(CodeNo - 1).Cells(13).Value = objReadData(13).ToString
                'End If
                'If Not IsDBNull(objReadData(14).ToString) Then
                '    .Rows(CodeNo - 1).Cells(14).Value = objReadData(14).ToString
                'End If
            End With
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On payroll codes configurations load data"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        On Error GoTo RaiseErr
        GetSeletectedCode()
        If intSelectedCode > 0 Then
            If MessageBox.Show("Are you sure you want to remove this code from the payroll?", "Confirm Code Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                'First check that there are no employees with this code
                arrCommons = New ArrayList
                Dim objDataCommand As New Data.OleDb.OleDbCommand("SELECT PAY_DATA_EMPLOYEES.EmployeeNo, " _
                    & "PAY_DATA_EMPLOYEES.LastName, PAY_DATA_EMPLOYEES.FirstName, PAY_DATA_CODES.Amount " _
                    & "FROM PAY_DATA_EMPLOYEES, PAY_DATA_CODES WHERE PAY_DATA_EMPLOYEES.EmployeeNumber = " _
                    & "PAY_DATA_CODES.EmployeeNumber AND PAY_DATA_CODES.CodeNo = " & intSelectedCode & "", cnn)
                Dim objDataReader As Data.OleDb.OleDbDataReader = objDataCommand.ExecuteReader

                While objDataReader.Read
                    arrCommons.Add(objDataReader(0).ToString & "|" & objDataReader(1).ToString & "|" & objDataReader(2).ToString & "|" & objDataReader(3).ToString)
                End While
                objDataReader.Close()
                If arrCommons.Count > 0 Then
                    MessageBox.Show("The system has detected that some employees have values in this code" & vbCrLf &
                        "This code will not be removed until the values for these employees have been cleared",
                        "Code Reset Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Dim f As New frmEmployeesWithValue
                    f.ShowDialog()
                    Exit Sub
                Else
                    objDataCommand = New Data.OleDb.OleDbCommand("DELETE FROM PAY_SYS_CODES WHERE CodeNo = " & intSelectedCode & "", cnn)
                    objDataCommand.ExecuteNonQuery()
                    MessageBox.Show("Code has been deleted successfully", "Record Deletion Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On payroll Codes Reset"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEmployeesWith_Click(sender As System.Object, e As System.EventArgs) Handles btnEmployeesWith.Click
        If dGrid.RowCount <= 0 Then Exit Sub
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                If IsNumeric(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                    intSelectedCode = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
                    Dim frm As New frmEmployeesWithValue
                    frm.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub ExpandablePanel1_ExpandedChanged(sender As Object, e As ExpandedChangeEventArgs) Handles ExpandablePanel1.ExpandedChanged
        If ExpandablePanel1.Expanded = False Then
            _widthLeftRight = KryptonSplitContainer1.SplitterDistance
            KryptonSplitContainer1.Panel2MinSize = 30
            KryptonSplitContainer1.SplitterDistance = KryptonSplitContainer1.Width - 30
            KryptonSplitContainer1.IsSplitterFixed = True
        Else
            KryptonSplitContainer1.IsSplitterFixed = False
            KryptonSplitContainer1.SplitterDistance = _widthLeftRight
        End If
    End Sub

End Class