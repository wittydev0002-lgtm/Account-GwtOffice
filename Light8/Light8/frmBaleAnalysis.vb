Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBaleAnalysis

    Dim arrBales As ArrayList
    Dim dblGradeWeights() As Double
    Dim dblGradeAveragePrices() As Double
    Dim intGradeCount() As Integer
    Dim dblGradeTotalPrices() As Double

    Private Sub btnRunInvoice_Click(sender As System.Object, e As System.EventArgs) Handles btnRunInvoice.Click
        Dim strSql As String = Nothing
        Select Case UCase(cboAnalyzeFor.Text)
            Case Is = UCase("Stock Holding")
                strSql = "SELECT Barcode as [Bar Code], BaleExtension AS [Ext], Grower as [Grower], Suffix AS [SFX], " _
                    & "CAST(Price AS decimal(10,2)) AS [Price], CAST(Moisture AS decimal(10,2)) " _
                    & "AS [Moisture], CAST(Tare AS decimal(10,2)) AS [Tare], CAST(Weight AS decimal(10,2)) AS [Weight], " _
                    & "BuyerCode AS [Buyer Code], CustomerGrade AS [Customer Grade], ControlGrade AS [Control Grade], " _
                    & "LotNumber AS [Lot No.] FROM BaleItems " _
                    & "WHERE SentStatus = 'NO' AND SendBatchNo = 0 AND FileNumber = 0 ORDER BY Barcode"

            Case Is = UCase("Dispatched Bales")
                strSql = "SELECT Barcode as [Bar Code], BaleExtension AS [Ext], Grower as [Grower], Suffix AS [SFX], " _
                    & "CAST(Price AS decimal(10,2)) AS [Price], CAST(Moisture AS decimal(10,2)) " _
                    & "AS [Moisture], CAST(Tare AS decimal(10,2)) AS [Tare], CAST(Weight AS decimal(10,2)) AS [Weight], " _
                    & "BuyerCode AS [Buyer Code], CustomerGrade AS [Customer Grade], ControlGrade AS [Control Grade], " _
                    & "LotNumber AS [Lot No.], [FileNumber] AS [File #], [SendBatchNo] AS [Batch #] FROM BaleItems " _
                    & "WHERE FileNumber > 0 AND (TransmissionDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartInvoice.Value) & "' " _
                    & "AND '" & gwt_comm.shortMonthDateFormat(dpEndInvoice.Value) & "') ORDER BY FileNumber, SendBatchNo"

            Case Is = UCase("Scanned Not Dispatched")
        End Select

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'If p = 2 Then grd.Columns(p).Visible = False
            If p > 3 Or p < 8 Then
                dGrid.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        lblTotalSelected.Text = dGrid.RowCount


    End Sub


    Private Sub cboAnalyzeFor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAnalyzeFor.SelectedIndexChanged
        dpStartInvoice.Enabled = True
        dpEndInvoice.Enabled = True
        Select Case UCase(cboAnalyzeFor.Text)
            Case Is = UCase("Stock Holding")
                dpStartInvoice.Enabled = False
                dpEndInvoice.Enabled = False
            Case Is = UCase("Dispatched Bales")

            Case Is = UCase("Scanned Not Dispatched")
        End Select
    End Sub

    Private Sub btnViewSummary_Click(sender As System.Object, e As System.EventArgs) Handles btnViewSummary.Click
        On Error GoTo RaiseErr

        If dGrid.RowCount <= 0 Then
            MessageBox.Show("You cannot run this analysis without first generating the main analysis", "No records to analyse", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        dblTobaccoTonage = 0
        dblTobaccoAveragePrice = 0
        dblTobaccoBalesCount = 0
        dblTobaccoTotalPrice = 0

        boolAbort = False

        With dGrid

            Dim intPriceIndex As Integer = 0
            Dim intWeightIndex As Integer = 0
            Dim intGradeIndex As Integer = 0

            Select Case UCase(cboAnalyzeFor.Text)
                Case Is = UCase("Stock Holding")
                    intPriceIndex = 4
                    intWeightIndex = 7
                    intGradeIndex = 9
                Case Is = UCase("Dispatched Bales")
                    intPriceIndex = 4
                    intWeightIndex = 7
                    intGradeIndex = 9
                Case Is = UCase("Scanned Not Dispatched")
            End Select

            For p As Integer = 0 To .RowCount - 1
                Dim dblWeight As Double = 0
                Dim dblPrice As Double = 0
                Dim strGrade As String = Nothing
                If Not Object.Equals(.Rows(p).Cells(intPriceIndex).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(intPriceIndex).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(intPriceIndex).Value.ToString) Then
                            dblPrice = CDbl(.Rows(p).Cells(intPriceIndex).Value.ToString)
                            dblTobaccoTotalPrice = dblTobaccoTotalPrice + dblPrice
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(intWeightIndex).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(intWeightIndex).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(intWeightIndex).Value.ToString) Then
                            dblWeight = CDbl(.Rows(p).Cells(intWeightIndex).Value.ToString)
                            dblTobaccoTonage = dblTobaccoTonage + dblWeight
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(intGradeIndex).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(intGradeIndex).Value.ToString) Then
                        strGrade = .Rows(p).Cells(intGradeIndex).Value.ToString
                    End If
                End If

                boolAbort = False
                GradeSplits(strGrade, p, dblWeight, dblPrice)
                If boolAbort = True Then
                    Cursor = Cursors.Default
                End If
                dblTobaccoBalesCount = dblTobaccoBalesCount + 1

            Next

        End With

        arrSelectedItems = New ArrayList

        For j As Integer = 0 To arrBales.Count - 1
            arrSelectedItems.Add(arrBales.Item(j) & "|" & CStr(intGradeCount(j)) & "|" &
                CStr(dblGradeTotalPrices(j)) & "|" & CStr(dblGradeTotalPrices(j) / intGradeCount(j)) & "|" &
                CStr(dblGradeWeights(j)) & "|" & CStr(dblGradeWeights(j) / intGradeCount(j)))
        Next

        Cursor = Cursors.Default

        Dim frm As New frmBaleSummaries
        frm.ShowDialog()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Tobacco Bales Deep Analysis"
        ShowErrorMessage()
    End Sub

    Private Sub LoadGrades()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT DISTINCT(CustomerGrade) FROM BaleItems ORDER BY CustomerGrade"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        arrBales = New ArrayList

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                arrBales.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        ReDim dblGradeWeights(0 To arrBales.Count - 1)
        ReDim dblGradeAveragePrices(0 To arrBales.Count - 1)
        ReDim intGradeCount(0 To arrBales.Count - 1)
        ReDim dblGradeTotalPrices(0 To arrBales.Count - 1)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On tobacco grades fetch"
        ShowErrorMessage()
    End Sub

    Private Sub frmBaleAnalysis_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadGrades()
    End Sub

    Private Sub GradeSplits(ByVal Grade As String, ByVal RowIndex As Integer, ByVal Weight As Double, ByVal Price As Double)
        On Error GoTo RaiseErr
        For p As Integer = 0 To arrBales.Count - 1
            If UCase(Grade) = UCase(arrBales.Item(p)) Then
                dblGradeWeights(p) = dblGradeWeights(p) + Weight
                intGradeCount(p) = intGradeCount(p) + 1
                dblGradeTotalPrices(p) = dblGradeTotalPrices(p) + Price
                Exit For
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On tobacco grades splits"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadGrades()
    End Sub

End Class