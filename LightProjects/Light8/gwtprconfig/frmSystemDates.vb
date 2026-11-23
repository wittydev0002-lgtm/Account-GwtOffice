Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmSystemDates

    Private Sub frmSystemDates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT * FROM SystemDates ORDER BY OrdinalNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGrid.Rows.Clear()
        If objReader.HasRows = False Then
            'Create the default for the dates up to 20
            sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemDates", cnn)
            sqlCommand.ExecuteNonQuery()
            For i As Integer = 1 To 20
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemDates (DateName, OrdinalNo) VALUES ('', " & i & ")", cnn)
                sqlCommand.ExecuteNonQuery()
                dGrid.Rows.Add(Format(i, "00"), "")
                'dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = (i)
            Next
        Else
            While objReader.Read
                dGrid.Rows.Add(1)
                If Not IsDBNull(objReader("OrdinalNo").ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader("OrdinalNo").ToString
                If Not IsDBNull(objReader("DateName").ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader("DateName").ToString
            End While
        End If
        objReader.Close()
        AlternateColors()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Syatem dates Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Dim i As Integer = 0
        For i = 0 To dGrid.Rows.Count - 1
            Dim strDateName As String = Nothing
            Dim intDateId As Integer = 0
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                strDateName = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                intDateId = Convert.ToSingle(dGrid.Rows(i).Cells(0).Value)
            End If
            Dim sqlCommand As New Data.OleDb.OleDbCommand("UPDATE SystemDates SET DateName = '" & strDateName & "' WHERE OrdinalNo = " & intDateId & "", cnn)
            sqlCommand.ExecuteNonQuery()
        Next
        MessageBox.Show("Dates saved successfully", "Dates Setup Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on System Dates Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 0 To dGrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
                dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrPrintDetails As New ArrayList
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strLineData As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
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

            End If
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
            .strFooterCaption = "User Defined Dates"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "USER DEFINED DATES"
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
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On User Defined Dates Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnRecreate_Click(sender As System.Object, e As System.EventArgs) Handles btnRecreate.Click
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemDates", cnn)
        sqlCommand.ExecuteNonQuery()
        dGrid.Rows.Clear()
        For i As Integer = 1 To 20
            sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemDates (DateName, OrdinalNo) VALUES ('', " & i & ")", cnn)
            sqlCommand.ExecuteNonQuery()
            dGrid.Rows.Add(Format(i, "00"), "")
        Next
        MessageBox.Show("Process has been completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On User Defined Dates Print"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
