Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMedicinesAndExtrasListing

    Dim boolFormLoading As Boolean

    Private Sub LoadMedicinesData()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        'Update for the serial numbers table
        Dim strSql As String = "SELECT ProductCode as [Drug Code], ProductName as [Product Name], Category, " _
            & "ManCode AS [Manf], Strength as [Strength], StandardPackSize AS [Pack Size], " _
            & "GenericIndicator as [B/G], CAST(SellPrice AS decimal(10,2)) AS [Price] " _
            & "FROM OchmasSystemMedicines ORDER BY ProductName"

        dGridMedicines.Columns.Clear()
        'Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridMedicines.DataSource = dTable

        For i As Integer = 0 To dGridMedicines.Columns.Count - 1
            dGridMedicines.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            If i = dGridMedicines.Columns.Count - 1 Then
                dGridMedicines.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        lblTotalRecords.Text = dGridMedicines.Rows.Count

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = False
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Medicines Listing Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnNewDrug_Click(sender As Object, e As EventArgs) Handles btnNewDrug.Click
        boolEditStatus = False
        Dim f As New frmDrugSetup
        f.ShowDialog()
        LoadMedicinesData()
    End Sub

    Private Sub btnEditDrug_Click(sender As Object, e As EventArgs) Handles btnEditDrug.Click
        If dGridMedicines.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedDetails()
            If Not String.IsNullOrEmpty(strDrugCode) Then
                Dim f As New frmDrugSetup
                f.ShowDialog()
            End If
            SearchForItem("")
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshDrug.Click
        LoadMedicinesData()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchStringDrug.KeyPress
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        If boolFormLoading = True Then Exit Sub
        On Error GoTo RaiseErr

        Dim strFind As String = txtSearchStringDrug.Text & strCurrentKey
        Cursor = Cursors.WaitCursor

        dGridMedicines.Columns.Clear()

        Dim strSql As String = Nothing
        dGridMedicines.DataSource = Nothing

        Select Case cboSearchByDrug.SelectedIndex
            Case Is = 0
                strSql = "SELECT ProductCode as [Drug Code], ProductName as [Product Name], Category, " _
                    & "ManCode AS [Manf], Strength as [Strength], StandardPackSize AS [Pack Size], " _
                    & "GenericIndicator as [B/G], CAST(SellPrice AS decimal(10,2)) AS [Price] " _
                    & "FROM OchmasSystemMedicines WHERE ProductCode LIKE '%" & strFind & "%' ORDER BY ProductCode"

            Case Is = 1
                strSql = "SELECT ProductCode as [Drug Code], ProductName as [Product Name], Category, " _
                    & "ManCode AS [Manf], Strength as [Strength], StandardPackSize AS [Pack Size], " _
                    & "GenericIndicator as [B/G], CAST(SellPrice AS decimal(10,2)) AS [Price] " _
                    & "FROM OchmasSystemMedicines WHERE ProductName LIKE '%" & strFind & "%' ORDER BY ProductName, ProductCode"

            Case Else
                strSql = "SELECT ProductCode as [Drug Code], ProductName as [Product Name], Category, " _
                    & "ManCode AS [Manf], Strength as [Strength], StandardPackSize AS [Pack Size], " _
                    & "GenericIndicator as [G/B], CAST(SellPrice AS decimal(10,2)) AS [Price] " _
                    & "FROM OchmasSystemMedicines WHERE ProductCode LIKE '%" & strFind & "%' ORDER BY ProductCode"
        End Select

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridMedicines.DataSource = dTable

        For i As Integer = 0 To dGridMedicines.Columns.Count - 1
            dGridMedicines.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            If i = dGridMedicines.Columns.Count - 1 Then
                dGridMedicines.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        lblTotalRecords.Text = dGridMedicines.Rows.Count

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Medicines Search"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDrug.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ProductCode as [Drug Code], ProductName as [Product Name], Category, " _
                    & "Classification, GenericIndicator as [G/B], CAST(SellPrice AS decimal(10,2)) AS [Price], Quantity " _
                    & "FROM OchmasSystemMedicines ORDER BY ProductName, MedpraxProductCode", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        'Assign the values to the print array
        Dim arrPrintData As New ArrayList
        While objReader.Read
            Dim strDataRow As String = Nothing
            For i As Integer = 0 To objReader.FieldCount - 1
                If i = 0 Then
                    If Not IsDBNull(objReader(i).ToString) Then strDataRow = objReader(i).ToString & ";" Else strDataRow = ";"
                Else
                    strDataRow = strDataRow & objReader(i).ToString & ";"
                End If
            Next
            strDataRow = Mid(strDataRow, 1, (strDataRow.Length - 1))
            arrPrintData.Add(strDataRow)
        End While
        objReader.Close()

        'Add the details to the print class print array

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 7
            .strColumnHeaders = "CODE|DESCRIPTION|CATEGORY|CLASS|GENERIC|UNIT $|QTY"
            .strColumnAlignments = "0|0|0|0|0|2|2"
            .strColumnWidths = "120|140|140|80|50|50|50"
            .strFooterCaption = "Medicines Analysis Report "
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "MEDICINES REPORT"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|NO|YES|YES"
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
            .boolPrintTotals = True
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|YES|YES|YES"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Medicines Report Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtSearchString_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearchStringDrug.KeyDown
        If e.KeyValue = Keys.Down Then
            If Not String.IsNullOrEmpty(txtSearchStringDrug.Text) Then
                dGridMedicines.Focus()
            Else
                SearchForItem("")
            End If
        End If
    End Sub

    Private Sub GetSelectedDetails()
        Dim CurrentCellValue As String
        On Error Resume Next
        CurrentCellValue = dGridMedicines.CurrentRow.Cells(0).Value.ToString
        strDrugCode = CurrentCellValue
    End Sub

    Private Sub frmMedicinesAndExtrasListing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMedicinesData()
        cboSearchByDrug.SelectedIndex = 1
    End Sub

    Private Sub dGridMedicines_DoubleClick(sender As Object, e As EventArgs) Handles dGridMedicines.DoubleClick
        If dGridMedicines.Rows.Count > 0 Then
            If dGridMedicines.CurrentCell.RowIndex > 0 Then
                boolEditStatus = True
                GetSelectedDetails()
                If Not String.IsNullOrEmpty(strDrugCode) Then
                    Dim f As New frmDrugSetup
                    f.ShowDialog()
                End If
                SearchForItem("")
            End If
        End If
    End Sub

End Class