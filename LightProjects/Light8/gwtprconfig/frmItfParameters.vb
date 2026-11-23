Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmItfParameters

    Dim boolDiscontinue As Boolean
    Dim CurrentCell As DataGridViewCell
    Dim i As Integer

    Private Sub frmItfParameters_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F1 Or _
                    Keys.F2 Or _
                    Keys.F3 Or _
                    Keys.F4 Or _
                    Keys.F5 Or _
                    Keys.F6 Or _
                    Keys.F7 Or _
                    Keys.F8 Or _
                    Keys.F9 Or _
                    Keys.F10 Or _
                    Keys.Left Or _
                    Keys.Down Or _
                    Keys.Up Or _
                    Keys.Right Or _
                    Keys.Escape Or _
                    Keys.F12 Then
            FuncKeysModule(e.KeyValue)
            'e.Handled = True
        End If
    End Sub

    Public Sub FuncKeysModule(ByVal value As Keys)
        'Check what function key is in a pressed state, and then perform the corresponding action. 
        Select Case value
            Case Keys.F1

            Case Keys.F3

            Case Keys.F4

            Case Keys.F7
                strSelectedCode = "0"
                If dgrid.CurrentCell.ColumnIndex > 1 Then
                    boolAbort = False
                    gwt_comm.PayrollCodesSearch()
                    If boolAbort = True Then Exit Sub
                    If CInt(strSelectedCode) = 0 Then
                        Exit Sub
                    Else
                        dgrid.CurrentCell.Value = CInt(strSelectedCode)
                    End If
                End If
            Case Keys.Down

            Case Keys.Up

            Case Keys.Escape

            Case Keys.Left
        End Select
    End Sub

    Private Sub frmItfParameters_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadValues()
    End Sub

    Private Sub LoadValues()

        On Error GoTo RaiseErr
        boolDiscontinue = False
        With dgrid
            .Rows.Clear()
            .Rows.Add(31)
            .Rows(0).Cells(0).Value = "01"
            CurrentCell = .Rows(0).Cells(1)
            CurrentCell.Value = "SALARY, WAGES, FEES, OVERTIME ETC YTD"
            .Rows(1).Cells(0).Value = "02"
            CurrentCell = .Rows(1).Cells(1)
            CurrentCell.Value = "BONUS YTD"
            .Rows(2).Cells(0).Value = "03"
            CurrentCell = .Rows(2).Cells(1)
            CurrentCell.Value = "COMMISSIONS YTD"
            .Rows(3).Cells(0).Value = "04"
            CurrentCell = .Rows(3).Cells(1)
            CurrentCell.Value = "IRREGULAR EARNINGS YTD"
            .Rows(4).Cells(0).Value = "05"
            CurrentCell = .Rows(4).Cells(1)
            CurrentCell.Value = "GRATUITY YTD"
            .Rows(5).Cells(0).Value = "06"
            CurrentCell = .Rows(5).Cells(1)
            CurrentCell.Value = "HOUSE BENEFIT YTD"
            .Rows(6).Cells(0).Value = "07"
            CurrentCell = .Rows(6).Cells(1)
            CurrentCell.Value = "VEHICLE BENEFIT YTD"
            .Rows(7).Cells(0).Value = "08"
            CurrentCell = .Rows(7).Cells(1)
            CurrentCell.Value = "EDUCATION BENEFIT YTD"
            .Rows(8).Cells(0).Value = "09"
            CurrentCell = .Rows(8).Cells(1)
            CurrentCell.Value = "OTHER BENEFIT-1 YTD"
            .Rows(9).Cells(0).Value = "10"
            CurrentCell = .Rows(9).Cells(1)
            CurrentCell.Value = "OTHER BENEFIT-2 YTD"
            .Rows(10).Cells(0).Value = "11"
            CurrentCell = .Rows(10).Cells(1)
            CurrentCell.Value = "NON TAXABLE EARNINGS YTD"
            .Rows(11).Cells(0).Value = "12"
            CurrentCell = .Rows(11).Cells(1)
            CurrentCell.Value = "PENSION YTD"
            .Rows(12).Cells(0).Value = "13"
            CurrentCell = .Rows(12).Cells(1)
            CurrentCell.Value = "NSSA YTD"
            .Rows(13).Cells(0).Value = "14"
            CurrentCell = .Rows(13).Cells(1)
            CurrentCell.Value = "SUBSCRIPTIONS YTD"
            .Rows(14).Cells(0).Value = "15"
            CurrentCell = .Rows(14).Cells(1)
            CurrentCell.Value = "MEDICAL AID YTD"
            .Rows(15).Cells(0).Value = "16"
            CurrentCell = .Rows(15).Cells(1)
            CurrentCell.Value = "ANNUITIES YTD"
            .Rows(16).Cells(0).Value = "17"
            CurrentCell = .Rows(16).Cells(1)
            CurrentCell.Value = "OTHER DEDUCTIONS YTD"
            .Rows(17).Cells(0).Value = "18"
            CurrentCell = .Rows(17).Cells(1)
            CurrentCell.Value = "PAYE DEDUCTION YTD"
            .Rows(18).Cells(0).Value = "19"
            CurrentCell = .Rows(18).Cells(1)
            CurrentCell.Value = "BLIND CREDITS YTD"
            .Rows(19).Cells(0).Value = "20"
            CurrentCell = .Rows(19).Cells(1)
            CurrentCell.Value = "DISABILITY CREDITS YTD"
            .Rows(20).Cells(0).Value = "21"
            CurrentCell = .Rows(20).Cells(1)
            CurrentCell.Value = "ELDERLY CREDITS YTD"
            .Rows(21).Cells(0).Value = "22"
            CurrentCell = .Rows(21).Cells(1)
            CurrentCell.Value = "MEDICAL EXPENSES YTD"
            .Rows(22).Cells(0).Value = "23"
            CurrentCell = .Rows(22).Cells(1)
            CurrentCell.Value = "CURRENT REGULAR EARNINGS"
            .Rows(23).Cells(0).Value = "24"
            CurrentCell = .Rows(23).Cells(1)
            CurrentCell.Value = "CURRENT IRREGULAR EARNINGS"
            .Rows(24).Cells(0).Value = "25"
            CurrentCell = .Rows(24).Cells(1)
            CurrentCell.Value = "CURRENT BONUS"
            .Rows(25).Cells(0).Value = "26"
            CurrentCell = .Rows(25).Cells(1)
            CurrentCell.Value = "CURRENT PENSION AND NSSA"
            .Rows(26).Cells(0).Value = "27"
            CurrentCell = .Rows(26).Cells(1)
            CurrentCell.Value = "CURRENT ALLOWED DEDUCTIONS"
            .Rows(27).Cells(0).Value = "28"
            CurrentCell = .Rows(27).Cells(1)
            CurrentCell.Value = "CURRENT MEDICAL AID"
            .Rows(28).Cells(0).Value = "29"
            CurrentCell = .Rows(28).Cells(1)
            CurrentCell.Value = "CURRENT MEDICAL AID SHORTFALLS"
            .Rows(29).Cells(0).Value = "30"
            CurrentCell = .Rows(29).Cells(1)
            CurrentCell.Value = "CUMMULATIVE BONUS"
            .Rows(30).Cells(0).Value = "31"
            CurrentCell = .Rows(30).Cells(1)
            CurrentCell.Value = "AIDS LEVY YTD"

            'Initialize the default 0 code first
            For i = 0 To 29
                Dim n As Integer
                For n = 0 To 9
                    dgrid.Rows(i).Cells(n + 2).Value = 0
                Next
            Next


            Dim objReader As Data.OleDb.OleDbDataReader  'StreamReader
            Dim objReadCalculations As New Data.OleDb.OleDbCommand("SELECT CalcCodes FROM SystemTaxCalculations", cnn)
            objReader = objReadCalculations.ExecuteReader

            Dim strLine As String
            Dim strBuffer() As String

            If boolDiscontinue = False Then
                If objReader.HasRows Then
                    objReader.Read()
                    strLine = objReader(0).ToString
                    strBuffer = Split(strLine, ";")
                    For i = 0 To 30
                        Dim n As Integer = 0
                        Dim strSplit() As String = Split(strBuffer(i), "|")
                        For n = 0 To strSplit.Length - 1
                            CurrentCell = .Rows(i).Cells(n + 2)
                            CurrentCell.Value = strSplit(n)
                        Next n
                    Next
                End If
                objReader.Close()
            End If
            'objReader.Close()
        End With
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        If Err.Number = 53 Or Err.Number = 5 Then
            boolDiscontinue = True
            Resume Next
        Else
            boolAbort = True
            Cursor = Cursors.Default
            strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Payroll ITF16 Parameter Codes Print"
            gwt_comm.ShowErrorMessage()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Dim strText As String = Nothing
        Dim strValue As String = Nothing
        For i = 0 To 30
            Dim n As Integer
            strValue = Nothing
            For n = 0 To 9
                CurrentCell = dgrid.Rows(i).Cells(n + 2)
                If IsNumeric(CurrentCell.Value) Then
                    strValue = strValue & CurrentCell.Value.ToString & "|"
                Else
                    strValue = strValue & "0|"
                End If
            Next n
            strValue = Mid(strValue, 1, (strValue.Length - 1))
            'If i > 0 Then
            strText = strText & strValue & ";"
            'Else
            '    strText = strValue
            'End If
        Next
        strText = Mid(strText, 1, (strText.Length - 1))

        Dim objCommand As Data.OleDb.OleDbCommand

        'write the details to file. Delete first the previous values
        Dim strSql As String = "DELETE FROM SystemTaxCalculations"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "INSERT INTO SystemTaxCalculations (CalcCodes) VALUES ('" & strText & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("ITF16 codes saved successfully", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Payroll ITF16 Parameter Codes"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrPrintDetails As New ArrayList
        For i As Integer = 0 To dgrid.Rows.Count - 1
            Dim strLineData As String = Nothing
            For p As Integer = 0 To dgrid.ColumnCount - 1
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
                If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(p).Value), "")) Then
                    strPrintData = dgrid.Rows(i).Cells(p).Value.ToString
                    'Get the actual font and style used in the grid
                    Dim fnt As Font = dgrid.Rows(i).Cells(p).Style.Font
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
        For i As Integer = 0 To dgrid.ColumnCount - 1
            strColumnHeaders = strColumnHeaders & dgrid.Columns(i).HeaderText & "|"
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
        For y As Integer = 0 To dgrid.ColumnCount - 1
            intTotalGridWidth = intTotalGridWidth + dgrid.Columns(y).Width
        Next

        Dim intValidateWidth As Integer = 0
        For i As Integer = 0 To dgrid.ColumnCount - 1
            Dim intCurrentWidth As Integer = 0

            'Calculate the width based on the percentage in the grid
            Dim intEqualWidth As Integer = intPrintPageAreaWidth / dgrid.Columns.Count
            Dim intPercentagePrintArea As Integer = (dgrid.Columns(i).Width / intTotalGridWidth) * 100
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
            .intNumberOfColumns = dgrid.ColumnCount
            .strColumnHeaders = UCase(strColumnHeaders)
            .strColumnWidths = strColumnWidths
            .strFooterCaption = "Payroll ITF16 Parameter Codes"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "PAYROLL ITF16 PARAMETER CODES"
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
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Payroll ITF16 Parameter Codes Print"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class