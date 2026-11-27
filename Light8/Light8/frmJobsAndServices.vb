Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmJobsAndServices

    Private Sub LoadJobsDataByDate(ByVal startDate As String, ByVal endDate As String)
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT ReferenceNumber AS [Doc #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "CustomerName AS [Customer], CAST(InspectionFee AS DECIMAL (30,2)) AS [Inspection], CAST(JobValue AS DECIMAL (30,2)) AS " _
            & "[Value], Status, ContraInvoiceNumber AS [Invoice] FROM JobCards " _
            & "WHERE TransDate BETWEEN '" & startDate & "' AND '" & endDate & "' ORDER BY ReferenceNumber"

        dGridJobs.Columns.Clear()
        Me.dGridJobs.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridJobs.DataSource = dTable

        For n As Integer = 0 To dGridJobs.Columns.Count - 1
            dGridJobs.Columns(n).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            If n >= 3 And n <= 4 Then
                dGridJobs.Columns(n).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        dGridJobs.Columns(dGridJobs.Columns.Count - 1).Visible = False

        DisplayValues()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Job costing details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub DisplayValues()
        Dim dblInspectionFees As Double = 0
        Dim dblJobValue As Double = 0
        For i As Integer = 0 To dGridJobs.RowCount - 1
            If Not (Object.Equals(Convert.ToString(dGridJobs.Rows(i).Cells(3).Value), "")) Then
                If IsNumeric(dGridJobs.Rows(i).Cells(3).Value.ToString) Then
                    dblInspectionFees = dblInspectionFees + CDbl(dGridJobs.Rows(i).Cells(3).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridJobs.Rows(i).Cells(4).Value), "")) Then
                If IsNumeric(dGridJobs.Rows(i).Cells(4).Value.ToString) Then
                    dblJobValue = dblJobValue + CDbl(dGridJobs.Rows(i).Cells(4).Value.ToString)
                End If
            End If
        Next
        lblFeeTotalJob.Text = Format(dblInspectionFees, "##0.00")
        lblLabourJob.Text = Format(dblJobValue, "##0.00")
        lblJobTotals.Text = Format((dblInspectionFees + dblJobValue), "##0.00")
    End Sub

    Private Sub btnRefreshJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshJob.Click
        LoadJobsDataByDate(CStr(gwt_comm.shortMonthDateFormat(Now)), CStr(gwt_comm.shortMonthDateFormat(Now)))
    End Sub

    Private Sub txtNameSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNameSearchJobs.KeyPress
        If Asc(e.KeyChar) = 18 Then
            SearchForItem("")
        Else
            SearchForItem(e.KeyChar)
        End If
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = txtNameSearchJobs.Text & strCurrentKey
        strActiveSearch = strFind
        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing

        Select Case UCase(cboFilterJobs.Text)
            Case Is = UCase("Customer name")
                strSql = "SELECT ReferenceNumber as [Doc #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CustomerName as [Customer], CAST(InspectionFee AS DECIMAL (30,2)) AS [Inspection], CAST(JobValue AS DECIMAL (30,2)) AS " _
                    & "[Value], Status, SerialNumber AS [Serial #], ItemName AS [Item], ContraInvoiceNumber AS [Invoice] FROM JobCards " _
                    & "WHERE CustomerName LIKE '%" & strFind & "%' ORDER BY ReferenceNumber"
            Case Is = UCase("Phone type")
                'ItemState like '&Nok%' or ItemName like '%Nok%'
                strSql = "SELECT ReferenceNumber AS [Doc #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CustomerName AS [Customer], CAST(InspectionFee AS DECIMAL (30,2)) AS [Inspection], CAST(JobValue AS DECIMAL (30,2)) AS " _
                    & "[Value], Status, SerialNumber AS [Serial #], ItemName AS [Item], ContraInvoiceNumber AS [Invoice] FROM JobCards " _
                    & "WHERE ItemState like '%" & strFind & "%' or ItemName like '%" & strFind & "%' ORDER BY ReferenceNumber"

            Case Is = UCase("Serial number")
                strSql = "SELECT ReferenceNumber AS [Doc #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CustomerName AS [Customer], CAST(InspectionFee AS DECIMAL (30,2)) AS [Inspection], CAST(JobValue AS DECIMAL (30,2)) AS " _
                    & "[Value], Status, SerialNumber AS [Serial #], ItemName AS [Item], ContraInvoiceNumber AS [Invoice] FROM JobCards " _
                    & "WHERE SerialNumber LIKE '%" & strFind & "%' ORDER BY ReferenceNumber"

            Case Is = UCase("Contact Number")
                strSql = "SELECT ReferenceNumber AS [Doc #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CustomerName AS [Customer], CAST(InspectionFee AS DECIMAL (30,2)) AS [Inspection], CAST(JobValue AS DECIMAL (30,2)) AS " _
                    & "[Value], Status, SerialNumber AS [Serial #], ItemName AS [Item], ContraInvoiceNumber AS [Invoice] FROM JobCards " _
                    & "WHERE ContactNumber LIKE '%" & strFind & "%' ORDER BY ReferenceNumber"

            Case Else
                strSql = "SELECT ReferenceNumber AS [Doc #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CustomerName AS [Customer], CAST(InspectionFee AS DECIMAL (30,2)) AS [Inspection], CAST(JobValue AS DECIMAL (30,2)) AS " _
                    & "[Value], Status, SerialNumber AS [Serial #], ItemName AS [Item], ContraInvoiceNumber AS [Invoice] FROM JobCards " _
                    & "WHERE CustomerName LIKE '%" & strFind & "%' ORDER BY ReferenceNumber"
        End Select

        dGridJobs.Columns.Clear()
        Me.dGridJobs.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridJobs.DataSource = dTable

        For n As Integer = 0 To dGridJobs.Columns.Count - 1
            dGridJobs.Columns(n).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next

        dGridJobs.Columns(dGridJobs.Columns.Count - 1).Visible = False

        DisplayValues()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Job Card Search"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
        Exit Sub
    End Sub

    Private Sub txtNameSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNameSearchJobs.TextChanged
        SearchForItem("")
    End Sub

    Private Sub btnDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetailsJob.Click
        intSelectedTransaction = 0
        GetSelectedJob()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ContraInvoiceNumber FROM jobcards WHERE ReferenceNumber = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intSelectedTransaction = CInt(objReader(0).ToString)
                Dim f As New frmJobCardInvoiceDetails
                f.ShowDialog()
            End If
        Else
            MessageBox.Show("The selected job card does not have an invoice tied to it", "No Invoice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        objReader.Close()
        Exit Sub
        'intSelectedTransaction
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Failed to get the corresponding job card invoice details"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnNewJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewJob.Click
        boolEditStatus = False
        strSelectedStatus = "OPEN"
        Dim f As New frmJobCardEntry
        f.ShowDialog()
        LoadJobsDataByDate(CStr(gwt_comm.shortMonthDateFormat(Now)), CStr(gwt_comm.shortMonthDateFormat(Now)))
    End Sub

    Private Sub btnEditJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditJob.Click
        If dGridJobs.Rows.Count = 0 Then Exit Sub
        ViewJobDetails()
    End Sub

    Private Sub GetSelectedJob()
        If IsNumeric(dGridJobs.CurrentRow.Cells(0).Value) Then
            intSelectedTransaction = CInt(dGridJobs.CurrentRow.Cells(0).Value.ToString)
            strSelectedStatus = dGridJobs.CurrentRow.Cells(5).Value.ToString
            intSelectedReferencedInvoice = CInt(dGridJobs.CurrentRow.Cells(dGridJobs.Columns.Count - 1).Value.ToString)
        End If
    End Sub

    Private Sub btnConvertJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConvertJob.Click
        If dGridJobs.Rows.Count <= 0 Then Exit Sub
        If IsNumeric(dGridJobs.CurrentRow.Cells(0).Value) Then
            GetSelectedJob()
            If strSelectedStatus = "CLOSED" Then
                MessageBox.Show("You cannot convert a closed job to an invoice",
                    "Process Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            intSelectedTransaction = CInt(dGridJobs.CurrentRow.Cells(0).Value.ToString)
            boolEditStatus = False
            Dim f As New frmJobInvoicing
            f.ShowDialog()
            LoadJobsDataByDate(CStr(gwt_comm.shortMonthDateFormat(Now)), CStr(gwt_comm.shortMonthDateFormat(Now)))
        End If
    End Sub

    Private Sub dGridJobs_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridJobs.CellDoubleClick
        If e.RowIndex = -1 Then Exit Sub
        If dGridJobs.Rows.Count = 0 Then Exit Sub
        ViewJobDetails()
    End Sub

    Private Sub ViewJobDetails()
        GetSelectedJob()
        boolEditStatus = True
        If strSelectedStatus = "OPEN" Then
            Dim f As New frmJobCardEntry
            f.ShowDialog()
        Else
            Dim f As New frmJobInvoicing
            f.ShowDialog()
        End If
        LoadJobsDataByDate(CStr(gwt_comm.shortMonthDateFormat(dpStartFromJobs.Value)), CStr(gwt_comm.shortMonthDateFormat(dpEndToJobs.Value)))
    End Sub

    Private Sub btnGoJobSummaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoJobSummaries.Click
        LoadJobAnalysisData()
    End Sub

    Private Sub LoadJobAnalysisData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If String.IsNullOrEmpty(cboUserJobSummaries.Text) Then
            MessageBox.Show("Please select the technician options", "Missing View Options", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboUserJobSummaries.Focus()
            Exit Sub
        End If
        Dim strSql As String = Nothing
        Select Case UCase(cboUserJobSummaries.Text)
            Case Is = "ALL"
                strSql = "SELECT jobcards.ContraInvoiceNumber AS [Job Number], CONVERT(NVARCHAR, " _
                    & "JobCards.TransDate, 105) AS [Date], jobcards.Status, jobinvoicedetails.SalesRep, " _
                    & "CAST((jobcards.InspectionFee) AS DECIMAL (10,1)) AS [Inspection Fee], " _
                    & "CAST((SUM(jobinvoicedetails.SalesPrice * jobinvoicedetails.quantity)) - 0 AS DECIMAL (10,1)) AS [Service Costs], " _
                    & "CAST((SUM((jobinvoicedetails.SalesPrice * jobinvoicedetails.quantity)) + jobcards.InspectionFee) AS DECIMAL (10,1)) AS [Total], JobCards.ItemName +' SN- '+ JobCards.SerialNumber AS [ItemDetails], jobcards.ReferenceNumber " _
                    & "FROM jobcards LEFT OUTER JOIN jobinvoicedetails ON jobcards.ContraInvoiceNumber = jobinvoicedetails.ReferenceNumber " _
                    & "WHERE jobinvoicedetails.TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartFromJobSummaries.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpEndToJobSummaries.Value) & "' " _
                    & "GROUP BY jobcards.InspectionFee, jobcards.Status, jobcards.ContraInvoiceNumber, jobinvoicedetails.SalesRep, " _
                    & "JobCards.TransDate, JobCards.ItemName, JobCards.SerialNumber, jobcards.ReferenceNumber ORDER BY Status, SalesRep, [Job Number], JobCards.TransDate"
            Case Else

                strSql = "SELECT jobcards.ContraInvoiceNumber AS [Job Number], CONVERT(NVARCHAR, " _
                    & "JobCards.TransDate, 105) AS [Date], jobcards.Status, jobinvoicedetails.SalesRep, " _
                    & "CAST((jobcards.InspectionFee) AS DECIMAL (10,1)) AS [Inspection Fee], " _
                    & "CAST((SUM(jobinvoicedetails.SalesPrice * jobinvoicedetails.quantity)) - 0 AS DECIMAL (10,1)) AS [Service Costs], " _
                    & "CAST((SUM((jobinvoicedetails.SalesPrice * jobinvoicedetails.quantity)) + jobcards.InspectionFee) AS DECIMAL (10,1)) AS [Total], JobCards.ItemName +' SN- '+ JobCards.SerialNumber AS [ItemDetails], jobcards.ReferenceNumber " _
                    & "FROM jobcards LEFT OUTER JOIN jobinvoicedetails ON jobcards.ContraInvoiceNumber = jobinvoicedetails.ReferenceNumber " _
                    & "WHERE jobinvoicedetails.SalesRep = '" & UCase(cboUserJobSummaries.Text) & "' AND jobinvoicedetails.TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartFromJobSummaries.Value) & "' AND '" & shortMonthDateFormat(CDate(dpEndToJobSummaries.Value)) & "' " _
                    & "GROUP BY jobcards.InspectionFee, jobcards.Status, jobcards.ContraInvoiceNumber, jobinvoicedetails.SalesRep, " _
                    & "JobCards.TransDate, JobCards.ItemName, JobCards.SerialNumber, jobcards.ReferenceNumber ORDER BY Status, SalesRep, [Job Number], JobCards.TransDate"

                'strSql = "SELECT jobcards.ContraInvoiceNumber AS [Job Number], CONVERT(NVARCHAR, JobCards.TransDate, 105) AS [Date], jobcards.Status, jobinvoicedetails.SalesRep, " _
                '    & "CAST((jobcards.InspectionFee) AS DECIMAL (10,1)) AS [Inspection Fee], " _
                '    & "CAST((SUM(jobinvoicedetails.SalesPrice * jobinvoicedetails.quantity)) AS DECIMAL (10,1)) AS [Service Costs], " _
                '    & "CAST((SUM((jobinvoicedetails.SalesPrice * jobinvoicedetails.quantity))) - jobcards.InspectionFee AS DECIMAL (10,1)) AS [Total] FROM " _
                '    & "jobcards LEFT OUTER JOIN jobinvoicedetails ON jobcards.ContraInvoiceNumber = jobinvoicedetails.ReferenceNumber " _
                '    & "WHERE jobinvoicedetails.SalesRep = '" & UCase(cboUser.Text) & "' AND jobinvoicedetails.TransDate " _
                '    & "BETWEEN '" & Format(dpStartFrom.Value, "dd-MMM-yyyy") & "' AND '" & Format(dpEndTo.Value, "dd-MMM-yyyy") & "' " _
                '    & "GROUP BY jobcards.InspectionFee, jobcards.Status, jobcards.ContraInvoiceNumber, jobinvoicedetails.SalesRep, JobCards.TransDate " _
                '    & "ORDER BY Status, SalesRep, [Job Number]"
        End Select
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridJobSummaries.Rows.Clear()
        While objReader.Read
            dGridJobSummaries.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(3).Value = objReader(3).ToString

            'INSPECTION
            If IsNumeric(objReader(4).ToString) Then dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(4).Value = objReader(4).ToString Else dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(4).Value = "0.00"

            'SERVICE
            If IsNumeric(objReader(5).ToString) Then
                If CDbl(objReader(5).ToString) < 0 Then
                    dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(5).Value = "0.00"
                    dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(6).Value = "0.00"
                Else
                    'We want to split the amounts between service and spare
                    Dim strSqlService As String = "SELECT JobInvoicedetails.ItemCode, " _
                        & "((JobInvoiceDetails.SalesPrice * JobInvoiceDetails.Quantity) - JobInvoiceDetails.DiscountAllowed) AS [Paid] " _
                        & "from JobInvoiceDetails WHERE ReferenceNumber = " & objReader(0).ToString & " AND " _
                        & "(JobInvoicedetails.ItemCode = '--- SERVICE ---' OR JobInvoicedetails.ItemCode = '--- COMMENT ---')"

                    'Dim objGetServiceValues As New Data.OleDb.OleDbCommand("Select JobInvoiceDetails.ItemCode, " _
                    '    & "InventoryItems.Offering, " _
                    '    & "((JobInvoiceDetails.SalesPrice * JobInvoiceDetails.Quantity) - JobInvoiceDetails.DiscountAllowed) AS [Paid] " _
                    '    & "from JobInvoiceDetails, InventoryItems " _
                    '    & "WHERE ReferenceNumber = " & objReader(0).ToString & " " _
                    '    & "AND JobInvoiceDetails.ItemCode = InventoryItems.ItemCode", cnn)
                    Dim objGetServiceValues As New Data.OleDb.OleDbCommand(strSqlService, cnn)
                    Dim objReadService As Data.OleDb.OleDbDataReader = objGetServiceValues.ExecuteReader
                    Dim dblServiceCosts As Double = 0
                    While objReadService.Read
                        If IsNumeric(objReadService(1).ToString) Then
                            dblServiceCosts = dblServiceCosts + CDbl(objReadService(1).ToString)
                        End If
                    End While
                    objReadService.Close()
                    If dblServiceCosts <= 0.1 Then dblServiceCosts = 0

                    dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(5).Value = Format(dblServiceCosts, "##0.00")
                    dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(6).Value = Format((CDbl(objReader(5).ToString) - dblServiceCosts), "##0.00")
                End If
            Else
                dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(5).Value = "0.00"
                dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(6).Value = "0.00"
            End If

            'COST
            dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(7).Value = CDbl(dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(4).Value.ToString) _
                + CDbl(dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(5).Value.ToString) + CDbl(dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(6).Value.ToString)

            'If IsNumeric(objReader(6).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(6).Value = objReader(6).ToString Else dGrid.Rows(dGrid.Rows.Count - 1).Cells(6).Value = "0.00"

            If Not IsDBNull(objReader(7).ToString) Then dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(8).Value = objReader(7).ToString
            If Not IsDBNull(objReader(8).ToString) Then dGridJobSummaries.Rows(dGridJobSummaries.Rows.Count - 1).Cells(9).Value = objReader(8).ToString

        End While
        objReader.Close()
        ComputeJobAnalysisTotals()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Job Cards Report Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadJobAnalysisUsers()
        On Error GoTo RaiseErr
        cboUserJobSummaries.Items.Clear()
        cboUserJobSummaries.Items.Add("ALL")
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DISTINCT JobInvoiceDetails.SalesRep FROM JobInvoiceDetails ORDER BY SalesRep", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboUserJobSummaries.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Usernames Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ComputeJobAnalysisTotals()
        Dim dblInspections As Double = 0
        Dim dblLabourCosts As Double = 0
        Dim dblTotal As Double = 0
        Dim dblMaterials As Double = 0
        For i As Integer = 0 To dGridJobSummaries.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGridJobSummaries.Rows(i).Cells(4).Value), "")) Then
                If IsNumeric(dGridJobSummaries.Rows(i).Cells(4).Value.ToString) Then
                    dblInspections = dblInspections + CDbl(dGridJobSummaries.Rows(i).Cells(4).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridJobSummaries.Rows(i).Cells(5).Value), "")) Then
                If IsNumeric(dGridJobSummaries.Rows(i).Cells(5).Value.ToString) Then
                    dblLabourCosts = dblLabourCosts + CDbl(dGridJobSummaries.Rows(i).Cells(5).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridJobSummaries.Rows(i).Cells(6).Value), "")) Then
                If IsNumeric(dGridJobSummaries.Rows(i).Cells(6).Value.ToString) Then
                    dblMaterials = dblMaterials + CDbl(dGridJobSummaries.Rows(i).Cells(6).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridJobSummaries.Rows(i).Cells(7).Value), "")) Then
                If IsNumeric(dGridJobSummaries.Rows(i).Cells(7).Value.ToString) Then
                    dblTotal = dblTotal + CDbl(dGridJobSummaries.Rows(i).Cells(7).Value.ToString)
                End If
            End If
        Next
        lblInspectionsJobSummaries.Text = Format(dblInspections, "##0.00")
        lblTotalServicesJobSummaries.Text = Format(dblLabourCosts, "##0.00")
        lblTotalIncomesJobSummaries.Text = Format(dblTotal, "##0.00")
        lblMaterialsJobSummaries.Text = Format(dblMaterials, "##0.00")
    End Sub

    Private Sub btnPrintJobSummaries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintJobSummaries.Click
        If dGridJobSummaries.Rows.Count <= 0 Then
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim arrPrintData As New ArrayList

        For i As Integer = 0 To dGridJobSummaries.Rows.Count - 1
            arrPrintData.Add(UCase(dGridJobSummaries.Rows(i).Cells(0).Value.ToString) & ";" & dGridJobSummaries.Rows(i).Cells(1).Value & ";" _
                & dGridJobSummaries.Rows(i).Cells(2).Value & ";" & dGridJobSummaries.Rows(i).Cells(3).Value _
                & ";" & dGridJobSummaries.Rows(i).Cells(4).Value & ";" & dGridJobSummaries.Rows(i).Cells(5).Value & ";" & dGridJobSummaries.Rows(i).Cells(6).Value _
                & ";" & dGridJobSummaries.Rows(i).Cells(7).Value & ";" & dGridJobSummaries.Rows(i).Cells(8).Value & ";" & dGridJobSummaries.Rows(i).Cells(9).Value)
        Next

        'arrPrintData.Add("** ; ; ; ; ; ; ")
        'arrPrintData.Add("** ; ; ; GRAND TOTALS ;" & lblInspections.Text _
        '        & ";" & lblTotalServices.Text & ";" & lblTotalIncomes.Text)

        Dim strPrintDetails(0 To ((arrPrintData.Count - 1) + 2)) As String
        For i As Integer = 0 To arrPrintData.Count - 1
            strPrintDetails(i + 2) = arrPrintData.Item(i)
        Next

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 10
            .strColumnHeaders = "NO#|DATE|STATUS|TECHNICIAN|INSPECT|SERV.|MATRLS|TOTAL|ITEM|INV.#"
            .strColumnAlignments = "0|0|0|0|2|2|2|2|0|0"
            .strColumnWidths = "40|60|40|120|52|52|53|53|140|40"
            .strFooterCaption = "JOB CARD DETAILS ANALYSIS"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "JOB CARD ANALYSIS"
            .strMainHeader3 = "DATE FROM " & UCase(gwt_comm.shortMonthDateFormat(dpStartFromJobSummaries.Value)) & " TO " & UCase(gwt_comm.shortMonthDateFormat(dpEndToJobSummaries.Value))
            .strColumnTotals = "NO|NO|NO|NO|YES|YES|YES|YES|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .intBreakIndex = 0
            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|YES|YES|YES|YES|NO|NO"
            .intKeyFieldIndex = 3
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        strSessionPrinter = prnt.PrinterSettings.PrinterName
        Dim documentPreview As New PrintPreviewDialog
        rpt.PrinterSettings.PrinterName = strSessionPrinter
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Job Cards Report Print"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnRefreshJobSummaries_Click(sender As Object, e As System.EventArgs) Handles btnRefreshJobSummaries.Click
        LoadJobAnalysisData()
    End Sub

    Private Sub frmJobsAndServices_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Technicians work on job sheets only: no deleting, no invoicing and no value summaries
        If GtiCurrentAccessLevel = GtiLevelTechnician Then
            btnDeleteJob.Visible = False
            btnConvertJob.Visible = False
            SuperTabItem2.Visible = False
        End If
    End Sub

    Private Sub btnMore_Click(sender As Object, e As EventArgs) Handles btnMore.Click
        boolAbort = False
        Dim frm As New frmAdvancedSearch
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        strSql = "SELECT ReferenceNumber AS [Doc #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "CustomerName AS [Customer], CAST(InspectionFee AS DECIMAL (30,2)) AS [Inspection], " _
            & "CAST(JobValue AS DECIMAL (30,2)) AS [Value], Status, SerialNumber AS [Serial #], " _
            & "ItemName AS [Item], DATEDIFF (dd , TransDate , GetDate()) AS [Period], " _
            & "ContraInvoiceNumber AS [Invoice]  FROM JobCards WHERE Status = 'OPEN' AND " _
            & "(DATEDIFF (dd , TransDate , GetDate()) BETWEEN " & intMinima & " and " & intMaxima & ") " _
            & "ORDER BY TransDate"

        dGridJobs.Columns.Clear()
        Me.dGridJobs.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridJobs.DataSource = dTable

        For n As Integer = 0 To dGridJobs.Columns.Count - 1
            dGridJobs.Columns(n).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next

        dGridJobs.Columns(dGridJobs.Columns.Count - 1).Visible = False

        DisplayValues()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Job Card Search"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
        Exit Sub
    End Sub

    Private Sub btnGoJobs_Click(sender As System.Object, e As System.EventArgs) Handles btnGoJobs.Click
        LoadJobsDataByDate(CStr(gwt_comm.shortMonthDateFormat(dpStartFromJobs.Value)), CStr(gwt_comm.shortMonthDateFormat(dpEndToJobs.Value)))
    End Sub

End Class