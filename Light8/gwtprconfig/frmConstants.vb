Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmConstants

    Dim boolIsNewConstantSet As Boolean = False

    Private Sub frmConstants_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadValues()
    End Sub

    Private Sub LoadValues()
        'open the constants file and load the payroll codes
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("Select ConstantNo, " _
            & "Description, ConstantValue from SystemConstants ORDER BY ConstantNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim i As Integer = 0
        Dim CurrentCell As DataGridViewCell

        'Continue to read until you reach the end of the file.
        If objReader.HasRows = False Then
            boolIsNewConstantSet = True
            dgrid.Rows.Add(100)
            For i = 0 To dgrid.Rows.Count - 1
                dgrid.Rows(i).Cells(0).Value = Format((i + 1), "000")
                dgrid.Rows(i).Cells(2).Value = "0000.00"
            Next
        Else
            While objReader.Read
                With dgrid
                    .Rows.Add(1)
                    CurrentCell = .Rows(.Rows.Count - 1).Cells(0)
                    If Not IsDBNull(objReader(0).ToString) Then
                        If IsNumeric(objReader(0).ToString) Then
                            CurrentCell.Value = Format(CInt(objReader(0).ToString), "000")
                        End If
                    End If
                    CurrentCell = .Rows(.Rows.Count - 1).Cells(1)
                    If Not IsDBNull(objReader(1).ToString) Then CurrentCell.Value = objReader(1).ToString
                    CurrentCell = .Rows(.Rows.Count - 1).Cells(2)
                    If Not IsDBNull(objReader(2).ToString) Then
                        If IsNumeric(objReader(2).ToString) Then
                            CurrentCell.Value = Format(CDbl(objReader(2).ToString), "##0.0000")
                        Else
                            CurrentCell.Value = "0000.00"
                        End If
                    End If
                End With
            End While
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Constants Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub tsSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsSave.Click
        On Error GoTo RaiseErr
        Dim CurrentCell As DataGridViewCell
        Dim i As Integer
        Dim strConstantId As String
        Dim strConstantDescription As String
        Dim strConstantValue As String
        Dim strConstantLine As String
        'frmMainOne.ProgressBar1.Value = 0
        'frmMainOne.ProgressBar1.Maximum = 100
        'frmMainOne.ProgressBar1.Visible = True
        For i = 0 To dgrid.Rows.Count - 1
            CurrentCell = dgrid.Rows(i).Cells(0)
            strConstantId = CurrentCell.Value
            CurrentCell = dgrid.Rows(i).Cells(1)
            strConstantDescription = CurrentCell.Value
            CurrentCell = dgrid.Rows(i).Cells(2)
            strConstantValue = CurrentCell.Value
            If Not IsNumeric(strConstantValue) Then strConstantValue = "0.00"
            If boolIsNewConstantSet = False Then
                strConstantLine = "UPDATE SystemConstants SET Description = '" & strConstantDescription & "', ConstantValue = " & strConstantValue & " WHERE ConstantNo = " & CInt(strConstantId) & ""
            Else
                strConstantLine = "INSERT INTO SystemConstants (ConstantNo, Description, ConstantValue) VALUES (" & CInt(strConstantId) & ", '" & strConstantDescription & "', " & strConstantValue & ")"
            End If
            Dim sqlCommand As New Data.OleDb.OleDbCommand(strConstantLine, cnn)
            sqlCommand.ExecuteNonQuery()
            'frmMainOne.ProgressBar1.Value = frmMainOne.ProgressBar1.Value + 1
        Next i
        boolIsNewConstantSet = False
        MessageBox.Show("Payroll constants updated successfully", "Payroll Constants Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = False
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Constants Update"
        gwt_comm.ShowErrorMessage()
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
                    If p = 2 Then
                        strLineData = strLineData & strPrintData & "|FN=" & strFontName & ";FS=" & intFontSize _
                            & ";FC=" & strFontColor & ";FB=" & strFontBold & ";FI=" & strFontItalic & ";FU=" & strFontUnderline _
                            & ";BC=" & strBackColor & ";RH=" & intRectangleHeight & ";AL=2</d>"
                    Else
                        strLineData = strLineData & strPrintData & "|FN=" & strFontName & ";FS=" & intFontSize _
                            & ";FC=" & strFontColor & ";FB=" & strFontBold & ";FI=" & strFontItalic & ";FU=" & strFontUnderline _
                            & ";BC=" & strBackColor & ";RH=" & intRectangleHeight & ";AL=0</d>"
                    End If
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
            .strFooterCaption = "Payroll Constants"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "PAYROLL CONSTANTS"
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
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Constants Fields Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadValues()
    End Sub

End Class
