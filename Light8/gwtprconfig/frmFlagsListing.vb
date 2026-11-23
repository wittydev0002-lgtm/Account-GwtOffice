Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmFlagsListing

    Private Sub frmFlagsListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeValues()
        LoadDetails()
    End Sub

    Private Sub InitializeValues()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT COUNT(FlagNo) FROM SystemFlagNames", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader()
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                If CInt(objReader(0).ToString) <= 0 Then
                    Dim i As Integer = 1
                    For i = 1 To 100
                        sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemFlagNames (FlagNo) VALUES (" & i & ")", cnn)
                        sqlCommand.ExecuteNonQuery()
                    Next
                End If
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & "on System Flags Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadDetails()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT FlagNo, " _
            & "FlagName FROM SystemFlagNames ORDER BY FlagNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dgrid.Rows.Clear()
        While objReader.Read
            dgrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = Format(CInt(objReader(0).ToString), "000")
            If Not IsDBNull(objReader(1).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & "on System Flags Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrid.DoubleClick
        If dgrid.Rows.Count <= 0 Then Exit Sub
        strSelectedDescription = Nothing
        intSelectedTransaction = CInt(dgrid.CurrentRow.Cells(0).Value.ToString)
        strSelectedDescription = dgrid.CurrentRow.Cells(1).Value.ToString
        boolEditStatus = True
        Dim f As New frmFlags
        f.ShowDialog()
        LoadDetails()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim f As New frmFlags
        f.ShowDialog()
        LoadDetails()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If dgrid.Rows.Count <= 0 Then Exit Sub
        strSelectedDescription = Nothing
        intSelectedTransaction = CInt(dgrid.CurrentRow.Cells(0).Value.ToString)
        strSelectedDescription = dgrid.CurrentRow.Cells(1).Value.ToString
        boolEditStatus = True
        Dim f As New frmFlags
        f.ShowDialog()
        LoadDetails()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If dgrid.Rows.Count <= 0 Then Exit Sub
        strSelectedDescription = Nothing
        intSelectedTransaction = CInt(dgrid.CurrentRow.Cells(0).Value.ToString)
        strSelectedDescription = dgrid.CurrentRow.Cells(1).Value.ToString
        If MessageBox.Show("Are you sure you want to delete this Indicator?", _
            "Confirm Indicator Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.Yes Then
            'First check that the indicator has not been used in any calculations
            Dim objCheckCalcUsage As New Data.OleDb.OleDbCommand("SELECT CalcNo, OrdinalNo, IndicatorSub FROM " _
                & "SystemCalculations WHERE IndicatorSub = " & intSelectedTransaction & " ORDER BY CalcNo", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCheckCalcUsage.ExecuteReader
            If objReader.HasRows Then
                'Add the information to a public array and display in another form
                arrPublicDisplay = New ArrayList
                While objReader.Read
                    arrPublicDisplay.Add(objReader(0).ToString & "|" & objReader(1).ToString & "|" & objReader(2).ToString)
                End While
                objReader.Close()
                Dim f As New frmUsedIndicators
                f.ShowDialog()
                Exit Sub
            End If
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemFlagNames WHERE FlagNo = " & intSelectedTransaction & "", cnn)
            objCommand.ExecuteNonQuery()
            'Delete the sub values
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemFlagValues WHERE FlagNo = " & intSelectedTransaction & "", cnn)
            objCommand.ExecuteNonQuery()
            'Delete the indicator from the employee records
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeFlags WHERE OrdinalNo = " & intSelectedTransaction & "", cnn)
            objCommand.ExecuteNonQuery()
            LoadDetails()
            MessageBox.Show("Indicator has been deleted successfully", "Indicator Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = False
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Indicator Deletion"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        InitializeValues()
        LoadDetails()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrPrintDetails As New ArrayList
        For i As Integer = 0 To dgrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(1).Value), "")) Then
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
            End If
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
            .strFooterCaption = "Payroll Flags"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "PAYROLL FLAGS"
            .strMainHeader3 = ""
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
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
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Flags Print"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
