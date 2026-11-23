Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmUsedIndicators

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmUsedIndicators_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgrd.Rows.Clear()
        For i As Integer = 0 To arrPublicDisplay.Count - 1
            Dim strValues() As String = Split(arrPublicDisplay.Item(i), "|")
            dgrd.Rows.Add(1)
            dgrd.Rows(dgrd.Rows.Count - 1).Cells(0).Value = strValues(0)
            dgrd.Rows(dgrd.Rows.Count - 1).Cells(1).Value = strValues(1)
            dgrd.Rows(dgrd.Rows.Count - 1).Cells(2).Value = strValues(2)
        Next
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Dim strPrintValues(0 To arrPublicDisplay.Count - 1) As String

        For i = 0 To arrPublicDisplay.Count - 1
            'Dim s As String = Replace("Embassy", "s", "x", 1)
            strPrintValues(i) = Replace(arrPublicDisplay.Item(i), "|", ";", 1)
        Next

        Dim myReport As New SmartColumnReportWriter.SmartColumnReportWriter
        Dim DocumentPreview As New PrintPreviewDialog

        Cursor = Cursors.WaitCursor

        With myReport
            .intNumberOfColumns = 3
            .intPrintRecordsCount = strPrintValues.Length   'Or number of records in the text file
            .strColumnAlignments = "0|0|0"
            .strColumnFormating = "NO|NO|NO"
            .strColumnHeaders = "CALC|LINE|INDICATOR"
            .strColumnWidths = "100|100|100"
            .strColumnTotals = "NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .BorderColor = Color.FromName("LightGray")
            .GridColor = Color.FromName("LightGray")
            .strPrintValues = strPrintValues
            .strMainCaption = UCase(strDefaultReportHeader)
            .strMainHeader2 = "INDICATOR USAGE IN CALCULTIONS"
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Gray
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES"
            .strColumnFormating = "NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO"
            .intKeyFieldIndex = 0
        End With
        Cursor = Cursors.Default
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        DocumentPreview.Document = myReport
        DocumentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Used Indicators Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmUsedIndicators_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 347 : Me.Height = 454
    End Sub
End Class