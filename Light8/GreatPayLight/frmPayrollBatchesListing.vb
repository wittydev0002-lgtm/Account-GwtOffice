Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPayrollBatchesListing

    Dim strHighlights As String = Nothing
    Dim boolPreviewReport As Boolean

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        boolEditStatus = False
        Dim f As New frmPayrollBatches
        f.ShowDialog()
        boolEditStatus = True
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'Delete the batch if not yet processed
        If dgrid.Rows.Count <= 0 Then Exit Sub
        If MessageBox.Show("Are you sure you want to delete this batch?", _
            "Batch Deletion Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            'proceed to delete the batch
            Dim CurrentCell As DataGridViewCell
            CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(0)
            intSelectedBatchNumber = CInt(CurrentCell.Value)
            Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM " _
                & "EmployeeBatches WHERE BatchNo = " & intSelectedBatchNumber & "", cnn)
            sqlCommand.ExecuteNonQuery()
            sqlCommand = New Data.OleDb.OleDbCommand("UPDATE SystemBatchesControl SET " _
                & "Status = 'DELETED' WHERE BatchNo = " & intSelectedBatchNumber & "", cnn)
            sqlCommand.ExecuteNonQuery()
            MessageBox.Show("Batch has been deleted successfully", _
                "Batch Deletion Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadBatchInformation()
        End If
    End Sub

    Private Sub frmBatchMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadBatchInformation()
    End Sub

    Private Sub LoadBatchInformation()
        On Error GoTo RaiseErr

        Dim intCnt As Integer = 0
        Dim dblAmt As Double = 0

        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT BatchNo, " _
            & "CONVERT(NVARCHAR, CreationDate, 105) AS [DateCreated], NumberOfEntries, " _
            & "CAST(BatchTotal AS DECIMAL (10,2)) AS [Total], Status, Author  " _
            & "FROM SystemBatchesControl ORDER BY BatchNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        dgrid.Rows.Clear()

        While objReader.Read
            dgrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
            If IsNumeric(objReader(2).ToString) Then
                intCnt = intCnt + CInt(objReader(2).ToString)
            End If
            If IsNumeric(objReader(3).ToString) Then
                dblAmt = dblAmt + CDbl(objReader(3).ToString)
            End If
        End While
        objReader.Close()

        If dgrid.Rows.Count <= 0 Then
            btnEdit.Enabled = False
        Else
            btnEdit.Enabled = True
        End If

        lblGrandEntries.Text = Format(intCnt, "##0")
        lblGrandAmount.Text = Format(dblAmt, "##0.00")

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Batches List Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dgrid_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgrid.SelectionChanged
        If dgrid.Rows.Count <= 0 Then Exit Sub
        boolEditStatus = True
        Dim CurrentCell As DataGridViewCell
        CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(0)
        intSelectedBatchNumber = CInt(CurrentCell.Value)
        DisplayBatchDetails(intSelectedBatchNumber)
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadBatchInformation()
    End Sub

    Private Sub DisplayBatchDetails(ByVal BatchNumber As Integer)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT EmployeeBatches.EntryLineNo, EmployeeBatches.EmployeeNo, " _
            & "EmployeeMaster.LastName +' '+ EmployeeMaster.Inits AS [GivenNames], " _
            & "EmployeeBatches.CodeNo, SystemCodes.Description, EmployeeBatches.Amount " _
            & "FROM EmployeeBatches " _
            & "LEFT JOIN EmployeeMaster ON EmployeeBatches.EmployeeNo = EmployeeMaster.EmployeeNo " _
            & "LEFT JOIN SystemCodes ON EmployeeBatches.CodeNo = SystemCodes.CodeNo " _
            & "WHERE EmployeeBatches.BatchNo = " & BatchNumber & " ORDER BY EntryLineNo"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim dblTotal As Double = 0
        While objReader.Read
            dgridDetails.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
            If IsNumeric(objReader(5).ToString) Then
                dblTotal = dblTotal + CDbl(objReader(5).ToString)
            End If
        End While
        objReader.Close()
        lblBatchCostTotalOrders.Text = Format(dblTotal, "#,##0.00")
        lblEntriesCountOrders.Text = dgridDetails.Rows.Count
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & "on Batch Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrintBatchDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintBatchDetails.Click
        On Error GoTo RaiseErr

        'Create the print array based on the grid details
        Dim strPrintValues(0 To dgridDetails.Rows.Count - 1) As String

        If dgridDetails.Rows.Count > 0 Then
            Dim i As Integer = 0
            Dim n As Integer = 0
            For i = 0 To dgridDetails.Rows.Count - 1
                Dim strValues As String = Nothing
                For n = 1 To dgridDetails.Columns.Count - 1
                    strValues = strValues & dgridDetails.Rows(i).Cells(n).Value.ToString & ";"
                Next
                strPrintValues(i) = Mid(strValues, 1, (strValues.Length - 1))
            Next
        End If

        Dim myReport As New SmartColumnReportWriter.SmartColumnReportWriter
        With myReport
            .intNumberOfColumns = 6
            .intPrintRecordsCount = strPrintValues.Length      'Or number of records in the text file
            .strColumnAlignments = "0|0|0|0|0|2"
            .strColumnFormating = "NO|NO|NO|NO|NO|YES"
            .strColumnHeaders = "LINE|EC NUMBER|GIVEN NAMES|CODE|DESCRIPTION|AMOUNT"
            .strColumnWidths = "50|80|160|50|160|80"
            .strColumnTotals = "NO|NO|NO|NO|NO|YES"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .boolGroupDetails = False
            .intBreakIndex = 0
            .strSummaryTotals = "NO|NO|NO|NO|NO|YES"
            .boolPrintTotals = True
            .boolGenericReport = False
            .intKeyFieldIndex = 0
            .PrintSummary = False
            .DrawBorder = True
            .BorderColor = Color.FromName("LightGray")
            .DrawSummaryChart = True
            .VerticalLines = True ' boolPrintVerticalLines
            .HorizontalLines = True 'boolPrintHorizontalLines
            .GridColor = Color.FromName("LightGray")
            .strPrintValues = strPrintValues
            .strMainCaption = UCase(strDefaultReportHeader)
            .strMainHeader2 = "PAYROLL BATCHES PRINT: PERIOD " & strReportPeriod & " RUN " & intReportRunNumber
            .strMainHeader3 = "BATCH NUMBER : " & intSelectedBatchNumber
            .strFooterCaption = "Powered by Brainco Softworx"
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .strHighlightColors = strHighlights
            .boolPrintRecordCount = False
        End With
        Dim DocumentPreview As New PrintPreviewDialog
        DocumentPreview.Document = myReport
        DocumentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & "on Batch Details Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If dgrid.Rows.Count > 0 Then
            If Not Object.Equals(dgrid.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dgrid.CurrentRow.Cells(0).Value.ToString) Then
                    If IsNumeric(dgrid.CurrentRow.Cells(0).Value.ToString) Then
                        intSelectedBatchNumber = CInt(dgrid.CurrentRow.Cells(0).Value.ToString)
                        boolEditStatus = True
                        Dim frm As New frmPayrollBatches
                        frm.ShowDialog()
                        'Reload the grid data
                        LoadBatchInformation()
                    End If
                End If
            End If
        End If
    End Sub
End Class