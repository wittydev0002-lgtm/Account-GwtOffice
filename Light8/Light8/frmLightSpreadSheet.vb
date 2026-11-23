Imports System.Drawing.Text
Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Reflection
Imports System.Collections
Imports xtraLightComponents
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLightSpreadSheet

    Private Sub frmExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshGrid()
        LoadFonts()
        'LoadColors()
        txtFormulae.Text = strSelectedFormular
        cboFontName.Text = "Verdana"
        cboFontSize.Text = "8"
    End Sub

    Private Sub RefreshGrid()
        dGrid.Rows.Clear()
        dGrid.Rows.Add(999)
    End Sub

    Private Sub LoadFonts()
        On Error GoTo RaiseErr
        Dim installed_Fonts As New InstalledFontCollection
        cboFontName.Items.Clear()
        Cursor = Cursors.WaitCursor
        For Each font_family As FontFamily In installed_Fonts.Families
            cboFontName.Items.Add(font_family.Name)
        Next
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error while loding the system fonts"
        ShowErrorMessage()
    End Sub

    Private Sub btnFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFunction.Click
        Dim f As New frmXtraLightFunctions
        f.ShowDialog()
        txtFormulae.Text = txtFormulae.Text & strSelectedFormular
    End Sub

    Private Sub btnBold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBold.Click
        BoldText()
    End Sub

    Private Sub BoldText()
        If dGrid.Rows.Count > 0 Then
            With dGrid
                Dim selectedCell As DataGridViewCell
                Dim fnt As System.Drawing.FontStyle
                For Each selectedCell In .SelectedCells
                    fnt = selectedCell.InheritedStyle.Font.Style
                    If selectedCell.InheritedStyle.Font.Bold Then
                        fnt = (fnt Or FontStyle.Regular)
                    Else
                        fnt = (fnt Or FontStyle.Bold)
                    End If
                    selectedCell.Style.Font = New Font(selectedCell.InheritedStyle.Font, fnt)
                Next
            End With
        End If
    End Sub

    Private Sub btnItalic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItalic.Click
        ItalicText()
    End Sub

    Private Sub ItalicText()
        If dGrid.Rows.Count > 0 Then
            With dGrid
                Dim selectedCell As DataGridViewCell
                Dim fnt As System.Drawing.FontStyle
                For Each selectedCell In .SelectedCells
                    fnt = selectedCell.InheritedStyle.Font.Style
                    If selectedCell.InheritedStyle.Font.Italic Then
                        fnt = (fnt Or FontStyle.Regular)
                    Else
                        fnt = (fnt Or FontStyle.Italic)
                    End If
                    selectedCell.Style.Font = New Font(selectedCell.InheritedStyle.Font, fnt)
                Next
            End With
        End If
    End Sub

    Private Sub btnUnderline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnderline.Click
        UnderlineText()
    End Sub

    Private Sub UnderlineText()
        If dGrid.Rows.Count > 0 Then
            With dGrid
                Dim selectedCell As DataGridViewCell
                Dim fnt As System.Drawing.FontStyle
                For Each selectedCell In .SelectedCells
                    fnt = selectedCell.InheritedStyle.Font.Style
                    If selectedCell.InheritedStyle.Font.Underline Then
                        fnt = (fnt Or FontStyle.Regular)
                    Else
                        fnt = (fnt Or FontStyle.Underline)
                    End If
                    selectedCell.Style.Font = New Font(selectedCell.InheritedStyle.Font, fnt)
                Next
            End With
        End If
    End Sub

    Private Sub btnLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeft.Click
        LeftText()
    End Sub

    Private Sub LeftText()
        With dGrid
            Dim selectedCell As DataGridViewCell
            For Each selectedCell In .SelectedCells
                selectedCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            Next
        End With
    End Sub

    Private Sub btnRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRight.Click
        RightText()
    End Sub

    Private Sub RightText()
        With dGrid
            Dim selectedCell As DataGridViewCell
            For Each selectedCell In .SelectedCells
                selectedCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            Next
        End With
    End Sub

    Private Sub btnCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCenter.Click
        CenterText()
    End Sub

    Private Sub CenterText()
        With dGrid
            Dim selectedCell As DataGridViewCell
            For Each selectedCell In .SelectedCells
                selectedCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End With
    End Sub

    Private Sub BuildRXML()
        On Error GoTo RaiseErr
        Dim arrPrintDetails As New ArrayList
        rpb1.Value = 0
        rpb1.Visible = True
        rpb1.Maximum = dGrid.Rows.Count
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
            rpb1.Value = rpb1.Value + 1
        Next
        rpb1.Value = rpb1.Maximum

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
            'If intValidateWidth < intPrintPageAreaWidth Then
            '    If dGrid.Columns(i).Width > (intPrintPageAreaWidth - intValidateWidth) Then
            '        intCurrentWidth = intPrintPageAreaWidth - intValidateWidth
            '    Else
            '        intCurrentWidth = dGrid.Columns(i).Width
            '    End If
            'Else
            '    intCurrentWidth = 0
            'End If

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
            .strFooterCaption = ""
            .strMainCaption = ""
            .strMainHeader2 = ""
            .strMainHeader3 = ""
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .HeaderFont = New Font("Arial", 10, FontStyle.Bold)
            .FooterFont = New Font("Arial", 6, FontStyle.Bold)
            .boolGenericReport = False
            .strPrintValues = strPrintDetails
            .VisibleColumns = strColumsVisible
            .DetailColor = Color.Black
            .DetailFont = fntDetailsFont
        End With
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On xtraLight Sheet"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        BuildRXML()
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 1 To dGrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim foreColor As Color = clrForeColor1
                Dim backColor As Color = clrBackColor1
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
                dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
        For i As Integer = 0 To dGrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim foreColor As Color = clrForeColor2
                Dim backColor As Color = clrBackColor2
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
                dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub btnAlternateRowColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlternateRowColor.Click
        boolAbort = False
        Dim f As New frmXtraLightAlternateColors
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        AlternateColors()
    End Sub

    Private Sub UpdateLabelText()

        Dim WithdrawalTotal As Integer = 0
        Dim DepositTotal As Integer = 0
        Dim SelectedCellTotal As Integer = 0
        Dim counter As Integer

        ' Iterate through all the rows and sum up the appropriate columns. 
        For counter = 0 To (dGrid.Rows.Count - 1)
            If Not dGrid.Rows(counter) _
                .Cells("Withdrawals").Value Is Nothing Then

                If Not dGrid.Rows(counter) _
                    .Cells("Withdrawals").Value.ToString().Length = 0 Then

                    WithdrawalTotal += _
                        Integer.Parse(dGrid.Rows(counter) _
                        .Cells("Withdrawals").Value.ToString())
                End If
            End If

            If Not dGrid.Rows(counter) _
                .Cells("Deposits").Value Is Nothing Then

                If Not dGrid.Rows(counter) _
                    .Cells("Deposits").Value.ToString().Length = 0 Then

                    DepositTotal += _
                        Integer.Parse(dGrid.Rows(counter) _
                        .Cells("Deposits").Value.ToString())
                End If
            End If
        Next

        ' Iterate through the SelectedCells collection and sum up the values. 
        For counter = 0 To (dGrid.SelectedCells.Count - 1)
            If dGrid.SelectedCells(counter).FormattedValueType Is _
            Type.GetType("System.String") Then

                Dim value As String = Nothing

                ' If the cell contains a value that has not been commited, 
                ' use the modified value. 
                If (dGrid.IsCurrentCellDirty = True) Then

                    value = dGrid.SelectedCells(counter) _
                        .EditedFormattedValue.ToString()
                Else

                    value = dGrid.SelectedCells(counter) _
                        .FormattedValue.ToString()
                End If

                If value IsNot Nothing Then

                    ' Ignore cells in the Description column. 
                    If Not dGrid.SelectedCells(counter).ColumnIndex = _
                        dGrid.Columns("Description").Index Then

                        If Not value.Length = 0 Then
                            SelectedCellTotal += Integer.Parse(value)
                        End If
                    End If
                End If
            End If

        Next

        '' Set the labels to reflect the current state of the DataGridView.
        'Label1.Text = "Withdrawals Total: " & WithdrawalTotal.ToString()
        'Label2.Text = "Deposits Total: " & DepositTotal.ToString()
        'Label3.Text = "Selected Cells Total: " & SelectedCellTotal.ToString()
        'Label4.Text = "Total entries: " & dGrid.RowCount.ToString()
    End Sub

    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter
        Me.dGrid.Invalidate()
    End Sub

    Private Sub dataGridView1_CellFormatting(ByVal sender As Object, _
    ByVal e As DataGridViewCellFormattingEventArgs) _
    Handles dGrid.CellFormatting
        ' If the column is the Artist column, check the 
        ' value. 
        If Me.dGrid.Columns(e.ColumnIndex).Name _
            = "Artist" Then
            If e.Value IsNot Nothing Then

                ' Check for the string "pink" in the cell. 
                Dim stringValue As String = _
                CType(e.Value, String)
                stringValue = stringValue.ToLower()
                If ((stringValue.IndexOf("pink") > -1)) Then
                    e.CellStyle.BackColor = Color.Pink
                End If

            End If
        ElseIf Me.dGrid.Columns(e.ColumnIndex).Name _
            = "Release Date" Then
            ShortFormDateFormat(e)
        End If
    End Sub

    'Even though the date internaly stores the year as YYYY, using formatting, the 
    'UI can have the format in YY.   
    Private Shared Sub ShortFormDateFormat(ByVal formatting As DataGridViewCellFormattingEventArgs)
        If formatting.Value IsNot Nothing Then
            Try
                Dim dateString As System.Text.StringBuilder = New System.Text.StringBuilder()
                Dim theDate As Date = DateTime.Parse(formatting.Value.ToString())

                dateString.Append(theDate.Month)
                dateString.Append("/")
                dateString.Append(theDate.Day)
                dateString.Append("/")
                dateString.Append(theDate.Year.ToString().Substring(2))
                formatting.Value = dateString.ToString()
                formatting.FormattingApplied = True
            Catch notInDateFormat As FormatException
                ' Set to false in case there are other handlers interested trying to 
                ' format this DataGridViewCellFormattingEventArgs instance.
                formatting.FormattingApplied = False
            End Try
        End If
    End Sub

    'Private Sub LoadColors()
    '    Dim colorType As Type = GetType(System.Drawing.Color)
    '    Dim propInfoList As PropertyInfo() = colorType.GetProperties(BindingFlags.[Static] Or BindingFlags.DeclaredOnly Or BindingFlags.[Public])
    '    For Each c As PropertyInfo In propInfoList
    '        Me.cpFontColor.Items.Add(c.Name)
    '    Next
    'End Sub

    Private Sub btnFillColor_SelectedColorChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFillColor.SelectedColorChanged
        On Error Resume Next
        Dim myColor As Color = btnFillColor.SelectedColor
        For i As Integer = 0 To dGrid.SelectedCells.Count - 1
            dGrid.SelectedCells(i).Style.BackColor = myColor
        Next
    End Sub

    Private Sub btnForeColor_SelectedColorChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForeColor.SelectedColorChanged
        On Error Resume Next
        Dim myColor As Color = btnForeColor.SelectedColor
        For i As Integer = 0 To dGrid.SelectedCells.Count - 1
            dGrid.SelectedCells(i).Style.ForeColor = myColor
        Next
    End Sub

    Private Sub txtFormulae_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFormulae.KeyPress
        Select Case Asc(e.KeyChar)
            Case 13
                e.Handled = True
                dGrid.Focus()
                Exit Select
            Case 27
                e.Handled = True
                dGrid_SelectionChanged(sender, e)
                Exit Select
        End Select
    End Sub

    Private Sub txtFormulae_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFormulae.Validating
        Dim pt As Point = dGrid.CurrentCellAddress
        Dim row As Integer = pt.Y
        Dim col As Integer = pt.X
        If (row > -1 And col > -1) Then
            Dim cell = dGrid.Rows(row).Cells(col)
            cell.Value = txtFormulae.Text
        End If
    End Sub

    Private Sub dGrid_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellLeave
        Me.dGrid.Invalidate()
    End Sub

    Private Sub dGrid_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dGrid.CellPainting
        If e.ColumnIndex = Me.dGrid.CurrentCell.ColumnIndex AndAlso e.RowIndex = Me.dGrid.CurrentCell.RowIndex Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.Border)
            Using p As New Pen(Color.Black, 1)
                Dim rect As Rectangle = e.CellBounds
                rect.Width -= 2
                rect.Height -= 2
                e.Graphics.DrawRectangle(p, rect)
            End Using
            e.Handled = True
        End If
    End Sub

    Private Sub dGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dGrid.CellValidating
        On Error GoTo RaiseErr
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed To Paste From Excel"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.SelectionChanged
        ' show cell content above grid
        Dim address As String = Nothing
        Dim strText As String = Nothing
        Dim status As String = "Ready"
        Dim row As Integer = dGrid.CurrentCellAddress.Y
        Dim col As Integer = dGrid.CurrentCellAddress.X
        If (row > -1 And col > -1) Then

            Dim cell As DataGridViewCell = dGrid.Rows(row).Cells(col)
            Dim val = cell.Value
            If Not (Object.Equals(Convert.ToString(cell.Value), "")) Then
                strText = val.ToString
            Else
                strText = Nothing
            End If
            address = dGrid.GetAddress(row, col)
            Dim selection = New CellRange(dGrid.SelectedCells)
            If selection.IsSingleCell = False Then
                Dim sel = dGrid.GetAddress(selection)
                Try
                    Dim avg = dGrid.Evaluate(String.Format("Average({0})", sel))
                    Dim count = dGrid.Evaluate(String.Format("Count({0})", sel))
                    Dim sum = dGrid.Evaluate(String.Format("Sum({0})", sel))
                    If CDbl(count) > 0 Then
                        status = String.Format("Average: {0:#,##0.##} Count: {1:n0} Sum: {2:#,##0.##}", avg, count, sum)
                    End If
                Catch ex As Exception
                    ' the selection contains errors...
                End Try
            End If
            _lblAddress.Text = address
            txtFormulae.Text = strText
            txtFormulae.SelectAll()
            _lblStatus.Text = status
        End If
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        strSelectedFileName = Nothing
        strSelectedFileTemplate = Nothing
        strSelectedFileType = Nothing
        boolLoadedFromTemplate = False
        Dim f As New frmXtraLightFileOpen
        f.ShowDialog()
        If Not String.IsNullOrEmpty(strSelectedFileName) Then
            'Open and load the file
            LoadSelectedFileData()
        End If
    End Sub

    Private Sub btnPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click
        PasteData()
    End Sub

    Private Sub PasteData()

        Dim s As String = Clipboard.GetText()                   'Get clipboard data as a string
        Dim rows() As String = s.Split(ControlChars.NewLine)    'Split into rows
        Dim i, j As Integer                                     'Counters

        'Get the current cell index in terms of the row
        Dim intCurrentRowIndex As Integer = dGrid.CurrentCell.RowIndex

        'Make sure that the rows are enough for the paste. If not add the required

        If dGrid.Rows.Count < rows.Length Then
            Dim intNumberOfRowsRequired As Integer = rows.Length - dGrid.Rows.Count
            dGrid.Rows.Add(intNumberOfRowsRequired)
        End If

        For i = 0 To rows.Length - 1
            'Split row into cells
            Dim bufferCell() As String = rows(i).Split(ControlChars.Tab)

            'Copy to grid, cell by cell
            Dim intCurrentColumnIndex As Integer = dGrid.CurrentCell.ColumnIndex
            For j = 0 To bufferCell.Length - 1
                'Remove line feed characters 
                If bufferCell(j).ToString.Contains(ControlChars.Lf) Then
                    bufferCell(j) = bufferCell(j).ToString.Replace(ControlChars.Lf, "")
                End If
                'Check that the columns are enough
                If dGrid.Columns.Count < bufferCell.Length Then
                    Dim intNumberOfColumnsRequired As Integer = bufferCell.Length - dGrid.Columns.Count
                    For p As Integer = 0 To intNumberOfColumnsRequired - 1
                        dGrid.Columns.Add("NewColumn" & p, "NewColumn" & p) 'strPreviousColumnHeader & strNextColumnHeader)
                    Next
                End If
                dGrid.Rows(intCurrentRowIndex).Cells(intCurrentColumnIndex).Value = bufferCell(j)
                intCurrentColumnIndex += 1
            Next
            intCurrentRowIndex += 1
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = "INPUT ERROR" & ControlChars.NewLine & "Number of columns shall be max " & dGrid.ColumnCount & vbCrLf & Err.Description & " error number " & Err.Number & vbCrLf & "On Excel Data Copy Paste"
        ShowErrorMessage()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'Check that the currently loaded cell has been saved or not
        'and then load based on the save status
        strSelectedFileName = Nothing
        strSelectedFileTemplate = Nothing
        strSelectedFileType = Nothing
        boolLoadedFromTemplate = False

        boolAbort = False
        Dim f As New frmXtraLightNewDataSheet
        f.showdialog()
        If boolAbort = True Then Exit Sub
        'enable the save button
        btnSave.Enabled = True
        LoadSelectedFileData()
    End Sub

    Private Sub LoadSelectedFileData()

        On Error GoTo RaiseErr

        RefreshGrid()

        Dim clrBack As Color
        Dim clrFore As Color
        Dim strFontName As String = "Verdana"
        Dim intFontSize As Integer = 9

        Dim strFontBold As String = "False"
        Dim strFontItalic As String = "False"
        Dim strFontUnderline As String = "False"

        '1 Bold
        '2 Italic
        '3 (2+1) Bold, Italic
        '4 Underline
        '5 (4+1) Bold, Underlined
        '6 (4+2) Italic, Underlined
        '7 (4+2+1) Italic, Underined, Bold
        '8 Strikethru
        '9 (8+1) Strikethru, Bold
        '10 (8+2) Strikethru, Italic
        '11 (8+3) Strikethru, Bold,Italic
        '12 (8+4) Strikethru, Underline
        '13 (8+4+1) Strikethru, Underline, Bold
        '14 (8+4+2) Strikethru, Underline, Italic
        '15 (8+4+3) Strikethru, Underline, Bold, Italic



        'Dim NewFont As New Font(RichTextBox1.Font, CType(1, FontStyle))
        'RichTextBox1.Font = NewFont



        Cursor = Cursors.WaitCursor

        'Load the cell formats and the data
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CellRowIndex, CellColumnIndex, CellFormats FROM XtraLightDataSheetCellFormats " _
            & "WHERE FileName = '" & strSelectedFileName & "' AND DataSheetType = '" & strSelectedFileType & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            'Dim Cell As DataGridViewCell = FormatCell(objReader(2).ToString, dGrid, CInt(objReader(0).ToString), CInt(objReader(1).ToString))

            Dim strSplitProperty() As String = Split(objReader(2).ToString, "||")
            For i As Integer = 0 To strSplitProperty.Length - 1
                Dim strSplitPropertyItem() As String = Split(Trim(strSplitProperty(i)), "=")

                'Dim fnt As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
                Select Case UCase(strSplitPropertyItem(0))
                    Case Is = "BC"
                        clrBack = System.Drawing.ColorTranslator.FromHtml(strSplitPropertyItem(1))
                    Case Is = "FC"
                        clrFore = System.Drawing.ColorTranslator.FromHtml(strSplitPropertyItem(1))
                    Case Is = "FN"
                        strFontName = strSplitPropertyItem(1)
                    Case Is = "FS"
                        intFontSize = CInt(strSplitPropertyItem(1))
                    Case Is = "FB"
                        If UCase(strSplitPropertyItem(1)) = "TRUE" Then strFontBold = "True"
                    Case Is = "FI"
                        If UCase(strSplitPropertyItem(1)) = "TRUE" Then strFontItalic = "True"
                    Case Is = "FU"
                        If UCase(strSplitPropertyItem(1)) = "TRUE" Then strFontUnderline = "True"
                End Select
            Next

            Dim CellFont As Font = New Font(strFontName, intFontSize, FontStyle.Regular)
            Dim FormattedFont As Font = CellFont

            If strFontBold = "True" Then
                FormattedFont = New Font(CellFont, CType(1, FontStyle))
            End If
            If strFontItalic = "True" Then
                FormattedFont = New Font(CellFont, CType(2, FontStyle))
            End If
            If strFontUnderline = "True" Then
                FormattedFont = New Font(CellFont, CType(4, FontStyle))
            End If
            '475382.28
            With dGrid.Rows(CInt(objReader(0).ToString)).Cells(CInt(objReader(1).ToString))
                Dim clrBackSelect As Color = .InheritedStyle.SelectionBackColor
                Dim clrForeSelect As Color = .InheritedStyle.SelectionForeColor
                .Style = New DataGridViewCellStyle() With { _
                  .BackColor = clrBack, _
                  .Font = FormattedFont, _
                  .ForeColor = clrFore, _
                  .SelectionBackColor = clrBackSelect, _
                  .SelectionForeColor = clrForeSelect _
                }
            End With
        End While

        objReader.Close()

        'test the results
        'For z As Integer = 0 To dGrid.Rows.Count - 1
        '    For y As Integer = 0 To dGrid.Columns.Count - 1
        '        dGrid.Rows(z).Cells(y).Value = "1"
        '    Next
        'Next

        'Populate the grid with values

        Dim objCommandGetData As New Data.OleDb.OleDbCommand("SELECT [Column1],[Column2]," _
            & "[Column3],[Column4],[Column5],[Column6],[Column7],[Column8],[Column9],[Column10]," _
            & "[Column11],[Column12],[Column13],[Column14],[Column15],[Column16],[Column17],[Column18]," _
            & "[Column19],[Column20],[Column21],[Column22],[Column23],[Column24],[Column25],[Column26], " _
            & "[CellRowIndex] FROM XtraLightDataSheetData WHERE FileName = '" & strSelectedFileName & "'", cnn)
        Dim objReaderData As Data.OleDb.OleDbDataReader = objCommandGetData.ExecuteReader
        While objReaderData.Read
            With dGrid
                For p As Integer = 0 To 25
                    .Rows(CInt(objReaderData("CellRowIndex").ToString)).Cells(p).Value = objReaderData(p).ToString
                Next
            End With
        End While
        objReaderData.Close()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "New File Creation"
        ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        boolAbort = False
        Dim f As New frmXtraLightDataSheetSave
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        gwt_comm.SaveDGVStyle(Me, dGrid)
        If boolAbort = True Then Exit Sub
        SaveData()
        If boolAbort = True Then Exit Sub
        MessageBox.Show("File saved successfully", "Datasheet Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseErr
        Dim strSql As String = "INSERT INTO XtraLightDataSheetData ([FileName],[SheetName],[LinkedProject]," _
            & "[FileType],[CellRowIndex],[Column1],[Column2],[Column3],[Column4],[Column5]," _
            & "[Column6],[Column7],[Column8],[Column9],[Column10],[Column11],[Column12],[Column13],[Column14]," _
            & "[Column15],[Column16],[Column17],[Column18],[Column19],[Column20],[Column21],[Column22]," _
            & "[Column23],[Column24],[Column25],[Column26]) VALUES ("

        Dim strValues As String = Nothing

        Dim objCommandDelete As New Data.OleDb.OleDbCommand("DELETE FROM XtraLightDataSheetData WHERE FileName = '" & strSelectedFileName & "' " _
            & "AND FileType = '" & strSelectedFileType & "'", cnn)
        objCommandDelete.ExecuteNonQuery()

        For i As Integer = 0 To dGrid.RowCount - 1

            Dim boolRowHasData As Boolean = False
            Dim strCellValues(0 To 25) As String

            If i = 0 Then boolRowHasData = True 'add at least one blank line

            For p As Integer = 0 To dGrid.ColumnCount - 1
                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(p).Value), "") Then
                    strCellValues(p) = dGrid.Rows(i).Cells(p).Value.ToString
                    boolRowHasData = True
                End If
            Next

            If boolRowHasData = True Then
                strValues = "'" & strSelectedFileName & "', 'Sheet1', 0, '" & strSelectedFileType & "', " & i & ","
                For j As Integer = 0 To strCellValues.Length - 1
                    If j = strCellValues.Length - 1 Then
                        strValues = strValues & "'" & Replace(strCellValues(j), "'", "''", 1) & "')"
                    Else
                        strValues = strValues & "'" & Replace(strCellValues(j), "'", "''", 1) & "',"
                    End If
                Next
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql & strValues, cnn)
                objCommand.ExecuteNonQuery()
            End If
            boolRowHasData = False
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Data Save Error"
        ShowErrorMessage()
    End Sub

    Private Sub mnuPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPaste.Click
        PasteData()
    End Sub

    Private Sub mnuBold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBold.Click
        BoldText()
    End Sub

    Private Sub mnuItalic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuItalic.Click
        ItalicText()
    End Sub

    Private Sub mnuUnderline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUnderline.Click
        UnderlineText()
    End Sub

    Private Sub mnuAlignLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAlignLeft.Click
        LeftText()
    End Sub

    Private Sub mnuAlignCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAlignCenter.Click
        CenterText()
    End Sub

    Private Sub mnuAlignRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAlignRight.Click
        RightText()
    End Sub

    Private Sub GridBorderLine(ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs)
        'Declare Border Style and Border Color
        Dim vBStyle As ButtonBorderStyle = ButtonBorderStyle.Solid
        Dim vBColor As Color = Color.Black

        'Custom Row Border (Horizontal)
        If e.RowIndex Mod 2 = False AndAlso e.RowIndex > 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All - DataGridViewPaintParts.ContentBackground)

            Dim H As Integer = 0
            ControlPaint.DrawBorder(e.Graphics, e.CellBounds, vBColor, 0, vBStyle, vBColor, 3, vBStyle, vBColor, 0, vBStyle, vBColor, 0, vBStyle)
            e.Handled = True
        End If

        'Custom Column Border (Vertical)
        If e.ColumnIndex Mod 5 = False AndAlso e.ColumnIndex > 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All - DataGridViewPaintParts.ContentBackground)

            Dim W As Integer = 0
            If e.RowIndex Mod 2 = False And e.RowIndex > 0 Then W = 3 Else W = 0
            ControlPaint.DrawBorder(e.Graphics, e.CellBounds, vBColor, 3, vBStyle, vBColor, W, vBStyle, vBColor, 0, vBStyle, vBColor, 0, vBStyle)
            e.Handled = True
        End If
        ''Custom Cell Color
        'If e.FormattedValue.ToString.Contains(txt.Text) Then
        '    CellColor(e)
        'End If
    End Sub

    Private Sub cboFontName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFontName.SelectedIndexChanged
        AssignFontNameSize()
    End Sub

    Private Sub AssignFontNameSize()
        If Not String.IsNullOrEmpty(cboFontName.Text) Then
            Dim CellFont As Font = dGrid.SelectedCells(0).InheritedStyle.Font
            Dim FormattedFont As Font = CellFont

            Dim strFontName As String = cboFontName.Text  ' CellFont.Name
            Dim intFontSize As Integer = CellFont.Size
            Dim Style As FontStyle = CellFont.Style

            FormattedFont = New Font(strFontName, intFontSize, Style)

            If IsNumeric(cboFontSize.Text) Then
                intFontSize = CInt(cboFontSize.Text)
            End If

            For i As Integer = 0 To dGrid.SelectedCells.Count - 1
                Dim clrBack As Color = dGrid.SelectedCells(i).InheritedStyle.BackColor
                Dim clrFore As Color = dGrid.SelectedCells(i).InheritedStyle.ForeColor
                Dim clrBackSelect As Color = dGrid.SelectedCells(i).InheritedStyle.SelectionBackColor
                Dim clrForeSelect As Color = dGrid.SelectedCells(i).InheritedStyle.SelectionForeColor
                With dGrid.SelectedCells(i)
                    .Style = New DataGridViewCellStyle() With { _
                      .BackColor = clrBack, _
                      .Font = FormattedFont, _
                      .ForeColor = clrFore, _
                      .SelectionBackColor = clrBackSelect, _
                      .SelectionForeColor = clrForeSelect _
                    }
                End With
            Next
        End If
    End Sub

    Private Sub cboFontSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFontSize.SelectedIndexChanged
        AssignFontNameSize()
    End Sub

End Class
