Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing.Printing

Public Class frmProjectsMain

    Dim strCustomerName As String
    Dim strCustomerAddress As String
    Dim strCustomerTelephone As String
    Dim strCustomerFaxNumber As String
    Dim strCustomerVatNumber As String
    Dim strCustomerEmailAddress As String

    Dim strCustomerAddress1 As String
    Dim strCustomerAddress2 As String
    Dim strCustomerAddress3 As String
    Dim strCustomerAddress4 As String

    Dim boolFormInitializing As Boolean = True
    Dim boolPrintFromPreview As Boolean
    Dim arrPrintValues As ArrayList
    Dim itm As Integer = 0
    Dim intPage As Integer
    Dim boolExitingWhile As Boolean
    Dim intLineCounter As Integer

    Dim dblCertifiedTotalRunning As Double
    Dim dblInvoicedTotalRunning As Double
    Dim dblPaidTotalRunning As Double
    Dim dblBalanceTotalRunning As Double
    Dim dblPaidTotalRunning2 As Double

    Dim boolLoadingHistory As Boolean = True
    Dim intPageHeight As Integer

    Dim fntTotalsFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnNewProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewProject.Click
        boolEditStatus = False
        intSelectedProjectNumber = 0
        Dim f As New frmProjectSetup ' frmProjectDetails
        f.ShowDialog()
        LoadData(Now, Now, "--- ALL ---")
    End Sub

    Private Sub frmProjectsMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo RaiseErr
        boolAbort = False
        LoadEmployees()
        If boolAbort = True Then Exit Sub
        LoadData(Now, Now, "--- ALL ---")
        If boolAbort = True Then Exit Sub
        'Attend to claims history

        boolFormInitializing = True
        CalcuteRevisedValue()
        If boolAbort = True Then Exit Sub
        LoadJobAnalysisUsers()
        If boolAbort = True Then Exit Sub
        LoadProjectOwners()
        If boolAbort = True Then Exit Sub
        LoadJobsDataByDate(CStr(gwt_comm.shortMonthDateFormat(Now)), CStr(gwt_comm.shortMonthDateFormat(Now)))
        If boolAbort = True Then Exit Sub
        'dGridAnalysis.Rows.Add(9999)
        boolFormInitializing = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Projects and Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData(ByVal startDate As Date, ByVal EndDate As Date, ByVal ProjectOwner As String)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader 'UPPER(REPLACE(CONVERT(CHAR(11), ProjectsMain.TakeOnDate, 106), ' ', '-')) as [Date Taken]
        If UCase(ProjectOwner) = "--- ALL ---" Then
            strSql = "SELECT ProjectsMain.ContractNumber AS [Proj.#], " _
                & "UPPER(REPLACE(CONVERT(CHAR(11), ProjectsMain.TakeOnDate, 106), ' ', '-')) as [Date Taken], " _
                & "ProjectsMain.ContractName AS [Contract Name], [Owner] AS [Owner], " _
                & "Customers.AccountName AS [Customer], CAST(ProjectsMain.InitialValue AS DECIMAL (10,2)) AS " _
                & "[Initial Value], CAST(ProjectsMain.RevisedValue AS DECIMAL (10,2)) AS [Revised Value] FROM " _
                & "ProjectsMain LEFT OUTER JOIN Customers ON Customers.AccountNumber = ProjectsMain.CustomerNumber"
        Else
            strSql = "SELECT ProjectsMain.ContractNumber AS [Proj.#], " _
                & "UPPER(REPLACE(CONVERT(CHAR(11), ProjectsMain.TakeOnDate, 106), ' ', '-')) as [Date Taken], " _
                & "ProjectsMain.ContractName AS [Contract Name], [Owner] AS [Owner], " _
                & "Customers.AccountName AS [Customer], CAST(ProjectsMain.InitialValue AS DECIMAL (10,2)) AS " _
                & "[Initial Value], CAST(ProjectsMain.RevisedValue AS DECIMAL (10,2)) AS [Revised Value] FROM " _
                & "ProjectsMain LEFT OUTER JOIN Customers ON Customers.AccountNumber = ProjectsMain.CustomerNumber " _
                & "WHERE TakeOnDate BETWEEN '" & startDate & "' AND '" & EndDate & "' AND ProjectsMain.Owner = '" & ProjectOwner & "'"
        End If

        dGridProjects.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridProjects.DataSource = dTable

        dGridProjects.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        For i As Integer = 0 To dGridProjects.Columns.Count - 1
            If i = 5 Or i = 6 Then
                dGridProjects.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dGridProjects.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End If
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On project details listing load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadEmployees()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames " _
            & "AS [EmployeeDetails] FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        cboPersonnelProjects.Items.Clear()
        cboPersonnelProjects.Items.Add("--- ALL ---")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboPersonnelProjects.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Personnel Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnGoProjects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoProjects.Click
        LoadData(dpStartFromProjects.Value, dpEndToProjects.Value, cboPersonnelProjects.Text)
    End Sub

    Private Sub dGridProjects_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridProjects.CellContentDoubleClick
        If dGridProjects.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridProjects.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridProjects.CurrentRow.Cells(0).Value.ToString) Then
                intSelectedProjectNumber = CInt(dGridProjects.CurrentRow.Cells(0).Value.ToString)
                boolEditStatus = True

                If Not Object.Equals(dGridProjects.CurrentRow.Cells(4).Value, Nothing) Then
                    strCallingProjectCustomer = dGridProjects.CurrentRow.Cells(4).Value.ToString
                End If
                If Not Object.Equals(dGridProjects.CurrentRow.Cells(2).Value, Nothing) Then
                    strCallingProjectName = dGridProjects.CurrentRow.Cells(2).Value.ToString
                End If

                Dim f As New frmProjectSetup
                f.ShowDialog()

                strCallingProjectCustomer = Nothing
                strCallingProjectName = Nothing
                LoadData(Now, Now, "--- ALL ---")
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On projects analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEditProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditProject.Click
        If dGridProjects.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridProjects.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridProjects.CurrentRow.Cells(0).Value.ToString) Then
                intSelectedProjectNumber = CInt(dGridProjects.CurrentRow.Cells(0).Value.ToString)
                boolEditStatus = True
                Dim f As New frmProjectSetup
                f.ShowDialog()
                LoadData(Now, Now, "--- ALL ---")
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On projects analysis"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnProjectCallings_Click(sender As System.Object, e As System.EventArgs) Handles btnProjectCallings.Click
        Dim frm As New frmProjectCallings
        frm.ShowDialog()
    End Sub

    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click
        boolAbort = False
        strSelectedProjectOwnerNumber = Nothing
        intSelectedProjectNumber = Nothing
        strSelectedAccountName = Nothing
        Dim frm As New frmOpenProjectClaims
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        SelectProject()
    End Sub

    Private Sub SelectProject()
        lblProjectNo.Text = intSelectedProjectNumber
        lblProjectOwner.Text = strSelectedAccountName
        lblCustomerNo.Text = strSelectedProjectOwnerNumber
        LoadClaimHistory()
        ComputeAllTotals()
    End Sub

    Private Sub LoadClaimHistory()
        On Error GoTo RaiseErr
        dgrid.Rows.Clear()
        boolLoadingHistory = True
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT " _
            & "ClaimDate, ClaimNumber, ClaimAmount, InvoiceDate, InvoiceNumber, AmountBeforeVat, " _
            & "AmountAfterVat, CONVERT(NVARCHAR, CreditNoteDate, 105), CreditNoteNumber, CreditNoteAmountBeforeVat, " _
            & "CreditNoteAmountAfterVat, CONVERT(NVARCHAR, PaymentDate1, 105), PaymentAmount1, " _
            & "CONVERT(NVARCHAR, PaymentDate2, 105), PaymentAmount2, Balance FROM ConstructionClaimsHistory " _
            & "WHERE ProjectNumber = " & intSelectedProjectNumber & " ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        With dgrid
            While objReader.Read
                .Rows.Add(1)
                For p = 0 To .ColumnCount - 1
                    If p = 0 Or p = 3 Or p = 7 Or p = 11 Or p = 13 Then
                        Dim strDate As String = Nothing
                        If Not IsDBNull(objReader(p).ToString) Then
                            If IsDate(objReader(p).ToString) Then
                                strDate = Format(CDate(objReader(p).ToString), "dd-MM-yyyy")
                                If UCase(strDate) = "01-01-1900" Then strDate = Nothing
                            End If
                        End If
                        .Rows(.Rows.Count - 1).Cells(p).Value = strDate
                    Else
                        .Rows(.Rows.Count - 1).Cells(p).Value = objReader(p)
                    End If
                Next
            End While
            objReader.Close()
        End With

        'Get the project details
        objCommand = New Data.OleDb.OleDbCommand("SELECT CAST(InitialValue AS DECIMAL (10,2)), " _
            & "CAST(RevisedValue AS DECIMAL (10,2)), CAST(Overtime AS DECIMAL (10,2)), " _
            & "CAST(VariationOrders AS DECIMAL (10,2)), CAST(ConBrackets AS DECIMAL (10,2)) " _
            & "FROM ProjectsMain WHERE ContractNumber = " & intSelectedProjectNumber & "", cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                txtContractValue.Text = objReader(0).ToString
            End If
            If Not IsDBNull(objReader(1).ToString) Then
                lblRevisedValue.Text = objReader(1).ToString
            End If
            If Not IsDBNull(objReader(2).ToString) Then
                txtOvertime.Text = objReader(2).ToString
            End If
            If Not IsDBNull(objReader(3).ToString) Then
                txtVariationOrders.Text = objReader(3).ToString
            End If
            If Not IsDBNull(objReader(4).ToString) Then
                txtConBrackets.Text = objReader(4).ToString
            End If
        End If
        objReader.Close()

        RecalculateAmountTotals()

        boolLoadingHistory = False

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Project Claims History Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dgrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrid.CellValueChanged
        If boolFormInitializing = True Then Exit Sub
        If boolLoadingHistory = True Then Exit Sub
        If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Or
            e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or
            e.ColumnIndex = 7 Or e.ColumnIndex = 8 Or
            e.ColumnIndex = 11 Or e.ColumnIndex = 13 Then
            Exit Sub
        Else
            If IsNumeric(dgrid.CurrentCell.Value) Then
                dgrid.CurrentCell.Value = Format(CDbl(dgrid.CurrentCell.Value), "##0.00")
            Else
                dgrid.CurrentCell.Value = "0.00"
            End If
            ComputeTotals()
        End If
    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgrid.EditingControlShowing
        Try
            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                'In order to prevent optical problems, we had to call the removeHandler twice
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComputeAllTotals()

        If dgrid.Rows.Count = 0 Then Exit Sub

        For n As Integer = 0 To dgrid.Rows.Count - 1

            Dim dblClaimValue As Double = 0
            Dim dblAmtBeforeVat As Double = 0
            Dim dblAmtAfterVat As Double = 0
            Dim dblCrBeforeVat As Double = 0
            Dim dblCrAfterVat As Double = 0
            Dim dblPayment1 As Double = 0
            Dim dblPayment2 As Double = 0
            Dim dblBalance As Double = 0

            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(2).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(2).Value.ToString) Then
                    dblClaimValue = CDbl(dgrid.Rows(n).Cells(2).Value.ToString)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(5).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(5).Value.ToString) Then
                    dblAmtBeforeVat = CDbl(dgrid.Rows(n).Cells(5).Value.ToString)
                End If
            End If
            '=SUM(D18*14%)+D18
            dblAmtAfterVat = (dblAmtBeforeVat * (dblSalesTaxRate / 100)) + dblAmtBeforeVat

            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(9).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(9).Value.ToString) Then
                    dblCrBeforeVat = CDbl(dgrid.Rows(n).Cells(9).Value.ToString)
                End If
            End If

            dblCrAfterVat = (dblCrBeforeVat * (dblSalesTaxRate / 100)) + dblCrBeforeVat

            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(12).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(12).Value.ToString) Then
                    dblPayment1 = CDbl(dgrid.Rows(n).Cells(12).Value.ToString)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(14).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(14).Value.ToString) Then
                    dblPayment2 = CDbl(dgrid.Rows(n).Cells(14).Value.ToString)
                End If
            End If

            If UCase(strClaimsBalanceComputation) = UCase("Invoice Value") Then
                dblBalance = dblAmtAfterVat - (dblCrAfterVat + dblPayment1 + dblPayment2)
            Else
                dblBalance = dblClaimValue - (dblCrAfterVat + dblPayment1 + dblPayment2)
            End If

            'assign the calculated values
            With dgrid.Rows(n)
                .Cells(6).Value = dblAmtAfterVat
                .Cells(10).Value = dblCrAfterVat
                .Cells(15).Value = dblBalance
            End With

        Next

        RecalculateAmountTotals()
        'CalcuteRevisedValue()

    End Sub

    Private Sub ComputeTotals()
        If dgrid.Rows.Count = 0 Then Exit Sub

        Dim n As Integer = dgrid.CurrentCell.RowIndex

        Dim dblClaimValue As Double = 0
        Dim dblAmtBeforeVat As Double = 0
        Dim dblAmtAfterVat As Double = 0
        Dim dblCrBeforeVat As Double = 0
        Dim dblCrAfterVat As Double = 0
        Dim dblPayment1 As Double = 0
        Dim dblPayment2 As Double = 0
        Dim dblBalance As Double = 0

        If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(2).Value), "")) Then
            If IsNumeric(dgrid.Rows(n).Cells(2).Value.ToString) Then
                dblClaimValue = CDbl(dgrid.Rows(n).Cells(2).Value.ToString)
            End If
        End If

        If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(5).Value), "")) Then
            If IsNumeric(dgrid.Rows(n).Cells(5).Value.ToString) Then
                dblAmtBeforeVat = CDbl(dgrid.Rows(n).Cells(5).Value.ToString)
            End If
        End If
        '=SUM(D18*14%)+D18
        dblAmtAfterVat = (dblAmtBeforeVat * (dblSalesTaxRate / 100)) + dblAmtBeforeVat

        If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(9).Value), "")) Then
            If IsNumeric(dgrid.Rows(n).Cells(9).Value.ToString) Then
                dblCrBeforeVat = CDbl(dgrid.Rows(n).Cells(9).Value.ToString)
            End If
        End If

        dblCrAfterVat = (dblCrBeforeVat * (dblSalesTaxRate / 100)) + dblCrBeforeVat

        If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(12).Value), "")) Then
            If IsNumeric(dgrid.Rows(n).Cells(12).Value.ToString) Then
                dblPayment1 = CDbl(dgrid.Rows(n).Cells(12).Value.ToString)
            End If
        End If

        If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(14).Value), "")) Then
            If IsNumeric(dgrid.Rows(n).Cells(14).Value.ToString) Then
                dblPayment2 = CDbl(dgrid.Rows(n).Cells(14).Value.ToString)
            End If
        End If

        If UCase(strClaimsBalanceComputation) = UCase("Invoice Value") Then
            dblBalance = dblAmtAfterVat - (dblCrAfterVat + dblPayment1 + dblPayment2)
        Else
            dblBalance = dblClaimValue - (dblCrAfterVat + dblPayment1 + dblPayment2)
        End If

        'assign the calculated values
        With dgrid.Rows(n)
            .Cells(6).Value = dblAmtAfterVat
            .Cells(10).Value = dblCrAfterVat
            .Cells(15).Value = dblBalance
        End With

        RecalculateAmountTotals()
        'CalcuteRevisedValue()

    End Sub

    Private Sub RecalculateAmountTotals()

        Dim dblAmtBeforeVat As Double = 0
        Dim dblAmtAfterVat As Double = 0
        Dim dblCrBeforeVat As Double = 0
        Dim dblCrAfterVat As Double = 0
        Dim dblPayment1 As Double = 0
        Dim dblPayment2 As Double = 0
        Dim dblBalance As Double = 0
        Dim dblTotalCertifiedClaims As Double = 0

        For n As Integer = 0 To dgrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(2).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(2).Value.ToString) Then
                    dblTotalCertifiedClaims = dblTotalCertifiedClaims + CDbl(dgrid.Rows(n).Cells(2).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(5).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(5).Value.ToString) Then
                    dblAmtBeforeVat = dblAmtBeforeVat + CDbl(dgrid.Rows(n).Cells(5).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(6).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(6).Value.ToString) Then
                    dblAmtAfterVat = dblAmtAfterVat + CDbl(dgrid.Rows(n).Cells(6).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(9).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(9).Value.ToString) Then
                    dblCrBeforeVat = dblCrBeforeVat + CDbl(dgrid.Rows(n).Cells(9).Value.ToString)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(10).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(10).Value.ToString) Then
                    dblCrAfterVat = dblCrAfterVat + CDbl(dgrid.Rows(n).Cells(10).Value.ToString)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(12).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(12).Value.ToString) Then
                    dblPayment1 = dblPayment1 + CDbl(dgrid.Rows(n).Cells(12).Value.ToString)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(14).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(14).Value.ToString) Then
                    dblPayment2 = dblPayment2 + CDbl(dgrid.Rows(n).Cells(14).Value.ToString)
                End If
            End If

            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(15).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(15).Value.ToString) Then
                    dblBalance = dblBalance + CDbl(dgrid.Rows(n).Cells(15).Value.ToString)
                End If
            End If

        Next

        lblCertifiedClaimsTotal.Text = Format(dblTotalCertifiedClaims, "#,##0.00")

        lblAmtAfterVat.Text = Format(dblAmtAfterVat, "#,##0.00")
        lblAmtBeforeVat.Text = Format(dblAmtBeforeVat, "#,##0.00")
        lblCrAfterVat.Text = Format(dblCrAfterVat, "#,##0.00")
        lblCrBeforeVat.Text = Format(dblCrBeforeVat, "#,##0.00")

        lblPayAfterVat.Text = Format((dblPayment1 + dblPayment2), "#,##0.00")
        lblPayBeforeVat.Text = Format(0, "#,##0.00")
        lblBalance.Text = Format(dblBalance, "#,##0.00")

        CalcuteRevisedValue()

    End Sub

    Private Sub CalcuteRevisedValue()
        If Not IsNumeric(txtConBrackets.Text) Then txtConBrackets.Text = 0
        If Not IsNumeric(txtContractValue.Text) Then txtContractValue.Text = 0
        If Not IsNumeric(txtOvertime.Text) Then txtOvertime.Text = 0
        If Not IsNumeric(txtVariationOrders.Text) Then txtVariationOrders.Text = 0
        lblRevisedValue.Text = Format((CDbl(txtConBrackets.Text) + CDbl(txtContractValue.Text) _
            + CDbl(txtOvertime.Text) + CDbl(txtVariationOrders.Text)), "##0.00")
        lblRevisedValue.Text = Format(((CDbl(lblRevisedValue.Text) * (dblSalesTaxRate / 100)) + CDbl(lblRevisedValue.Text)), "##0.00")
        'Calculate the still to invoice
        If Not IsNumeric(lblAmtAfterVat.Text) Then lblAmtAfterVat.Text = "0.00"
        If Not IsNumeric(lblRevisedValue.Text) Then lblRevisedValue.Text = "0.00"
        lblStillToInvoice.Text = Format(CDbl(lblRevisedValue.Text) - CDbl(lblAmtAfterVat.Text), "##0.00")
        lblUninvoicedBalance.Text = lblStillToInvoice.Text
        lblTotalOutstanding.Text = Format((CDbl(lblBalance.Text) + CDbl(lblUninvoicedBalance.Text)), "##0.00")
    End Sub

    Private Sub btnAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddLine.Click
        If Not IsNumeric(lblProjectNo.Text) Then
            MessageBox.Show("It looks like there are no projects to save." & vbCrLf & "Select the project and  proceed from then",
                "Invalid Project Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        dgrid.Rows.Add(1)
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrid.CellEndEdit
        If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Or
            e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or
            e.ColumnIndex = 7 Or e.ColumnIndex = 8 Or
            e.ColumnIndex = 11 Or e.ColumnIndex = 13 Then
            Exit Sub
        Else
            If IsNumeric(dgrid.CurrentCell.Value) Then
                dgrid.CurrentCell.Value = Format(CDbl(dgrid.CurrentCell.Value), "##0.00")
            Else
                dgrid.CurrentCell.Value = "0.00"
            End If
            ComputeTotals()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not IsNumeric(lblProjectNo.Text) Then
            MessageBox.Show("It looks like there are no projects to save." & vbCrLf & "Select the project and  proceed from then",
                "Invalid Project Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        SaveProjectData()
    End Sub

    Private Sub SaveProjectData()

        On Error GoTo RaiseErr

        'Delete all the records from the table relating to this project

        Cursor = Cursors.WaitCursor

        Dim objCommandDelete As New Data.OleDb.OleDbCommand("DELETE FROM ConstructionClaimsHistory " _
            & "WHERE ProjectNumber = " & CInt(lblProjectNo.Text) & "", cnn)
        objCommandDelete.ExecuteNonQuery()

        With dgrid

            For i As Integer = 0 To dgrid.Rows.Count - 1

                Dim strInvoiceDate As String = Nothing
                Dim intInvoiceNumber As Integer = 0
                Dim intClaimNumber As Integer = 0
                Dim dblInvoiceAmtNoVat As Double = 0
                Dim dblInvoiceAmtWithVat As Double = 0
                Dim strCreditNoteDate As String = Nothing
                Dim intCreditNoteNumber As Integer = 0
                Dim dblCnoteAmtNoVat As Double = 0
                Dim dblCnoteAmtWithVat As Double = 0
                Dim strPayDate1 As String = Nothing
                Dim dblPayAmt1 As Double = 0
                Dim strPayDate2 As String = Nothing
                Dim dblPayAmt2 As Double = 0
                Dim dblBalance As Double = 0
                Dim dblClaimAmt As Double = 0

                Dim strClaimDate As String = Nothing

                Dim strBuffer() As String

                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "") Then
                    strClaimDate = .Rows(i).Cells(0).Value.ToString
                    strBuffer = Split(strClaimDate, "-")
                    If strBuffer.Length = 3 Then
                        If IsNumeric(strBuffer(0)) And IsNumeric(strBuffer(1)) And IsNumeric(strBuffer(2)) Then
                            strClaimDate = strBuffer(0) & "-" & UCase(MonthName(CInt(strBuffer(1)), False)) & "-" & strBuffer(2)
                        Else
                            strClaimDate = Nothing
                        End If
                    Else
                        strClaimDate = Nothing
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(1).Value.ToString) Then
                        intClaimNumber = CInt(.Rows(i).Cells(1).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(2).Value.ToString) Then
                        dblClaimAmt = CDbl(.Rows(i).Cells(2).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "") Then
                    strInvoiceDate = .Rows(i).Cells(3).Value.ToString
                    strBuffer = Split(strInvoiceDate, "-")
                    If strBuffer.Length = 3 Then
                        If IsNumeric(strBuffer(0)) And IsNumeric(strBuffer(1)) And IsNumeric(strBuffer(2)) Then
                            strInvoiceDate = strBuffer(0) & "-" & UCase(MonthName(CInt(strBuffer(1)), False)) & "-" & strBuffer(2)
                        Else
                            strInvoiceDate = Nothing
                        End If
                    Else
                        strInvoiceDate = Nothing
                    End If
                End If

                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(4).Value.ToString) Then
                        intInvoiceNumber = CInt(.Rows(i).Cells(4).Value.ToString)
                    End If
                End If

                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(5).Value.ToString) Then
                        dblInvoiceAmtNoVat = CDbl(.Rows(i).Cells(5).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(6).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(6).Value.ToString) Then
                        dblInvoiceAmtWithVat = CInt(.Rows(i).Cells(6).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(7).Value), "") Then
                    strCreditNoteDate = .Rows(i).Cells(7).Value.ToString
                    strBuffer = Split(strCreditNoteDate, "-")
                    If strBuffer.Length = 3 Then
                        If IsNumeric(strBuffer(0)) And IsNumeric(strBuffer(1)) And IsNumeric(strBuffer(2)) Then
                            strCreditNoteDate = strBuffer(0) & "-" & UCase(MonthName(CInt(strBuffer(1)), True)) & "-" & strBuffer(2)
                        Else
                            strCreditNoteDate = Nothing
                        End If
                    Else
                        strCreditNoteDate = Nothing
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(8).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(8).Value.ToString) Then
                        intCreditNoteNumber = CInt(.Rows(i).Cells(8).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(9).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(9).Value.ToString) Then
                        dblCnoteAmtNoVat = CDbl(.Rows(i).Cells(9).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(10).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(10).Value.ToString) Then
                        dblCnoteAmtWithVat = CDbl(.Rows(i).Cells(10).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(11).Value), "") Then
                    strPayDate1 = .Rows(i).Cells(11).Value.ToString
                    strBuffer = Split(strPayDate1, "-")
                    If strBuffer.Length = 3 Then
                        If IsNumeric(strBuffer(0)) And IsNumeric(strBuffer(1)) And IsNumeric(strBuffer(2)) Then
                            strPayDate1 = strBuffer(0) & "-" & UCase(MonthName(CInt(strBuffer(1)), True)) & "-" & strBuffer(2)
                        Else
                            strPayDate1 = Nothing
                        End If
                    Else
                        strPayDate1 = Nothing
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(12).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(12).Value.ToString) Then
                        dblPayAmt1 = CDbl(.Rows(i).Cells(12).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(13).Value), "") Then
                    strPayDate2 = .Rows(i).Cells(13).Value.ToString
                    strBuffer = Split(strPayDate2, "-")
                    If strBuffer.Length = 3 Then
                        If IsNumeric(strBuffer(0)) And IsNumeric(strBuffer(1)) And IsNumeric(strBuffer(2)) Then
                            strPayDate2 = strBuffer(0) & "-" & UCase(MonthName(CInt(strBuffer(1)), True)) & "-" & strBuffer(2)
                        Else
                            strPayDate2 = Nothing
                        End If
                    Else
                        strPayDate2 = Nothing
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(14).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(14).Value.ToString) Then
                        dblPayAmt2 = CDbl(.Rows(i).Cells(14).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(15).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(15).Value.ToString) Then
                        dblBalance = CDbl(.Rows(i).Cells(15).Value.ToString)
                    End If
                End If
                Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO ConstructionClaimsHistory " _
                    & "(ProjectNumber, InvoiceDate, InvoiceNumber, ClaimNumber, AmountBeforeVat, " _
                    & "AmountAfterVat, CreditNoteDate, CreditNoteNumber, CreditNoteAmountBeforeVat, " _
                    & "CreditNoteAmountAfterVat, PaymentDate1, PaymentAmount1, PaymentDate2, PaymentAmount2, Balance, ClaimAmount, ClaimDate) VALUES " _
                    & "(" & CInt(lblProjectNo.Text) & ", '" & strInvoiceDate & "', " & intInvoiceNumber & ", " _
                    & "" & intClaimNumber & ", " & dblInvoiceAmtNoVat & ", " & dblInvoiceAmtWithVat & ", " _
                    & "'" & strCreditNoteDate & "', " & intCreditNoteNumber & ", " & dblCnoteAmtNoVat & ", " & dblCnoteAmtWithVat & ", " _
                    & "'" & strPayDate1 & "', " & dblPayAmt1 & ", '" & strPayDate2 & "', " & dblPayAmt2 & ", " _
                    & "" & dblBalance & ", " & dblClaimAmt & ", '" & strClaimDate & "')", cnn)
                objCommand.ExecuteNonQuery()

            Next
        End With

        'Save the following data to the project main
        If Not IsNumeric(txtConBrackets.Text) Then txtConBrackets.Text = "0.00"
        If Not IsNumeric(txtContractValue.Text) Then txtContractValue.Text = "0.00"
        If Not IsNumeric(txtOvertime.Text) Then txtOvertime.Text = "0.00"
        If Not IsNumeric(txtVariationOrders.Text) Then txtVariationOrders.Text = "0.00"

        Dim strSql As String = "UPDATE ProjectsMain SET Overtime = " & CDbl(txtOvertime.Text) & ", " _
            & "VariationOrders = " & CDbl(txtVariationOrders.Text) & ", ConBrackets = " & CDbl(txtConBrackets.Text) & ", " _
            & "RevisedValue = " & CDbl(lblRevisedValue.Text) & " WHERE ContractNumber = " & intSelectedProjectNumber & ""
        Dim objCmd As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCmd.ExecuteNonQuery()

        '0775040043 Rodney Whatsapp
        MessageBox.Show("Project Transaction History saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Project Claims History Save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtConBrackets_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConBrackets.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            txtOvertime.Focus()
            CalcuteRevisedValue()
            Exit Sub
        End If
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtContractValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContractValue.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            txtVariationOrders.Focus()
            CalcuteRevisedValue()
            Exit Sub
        End If
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtOvertime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOvertime.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            CalcuteRevisedValue()
            Exit Sub
        End If
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtVariationOrders_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVariationOrders.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            txtConBrackets.Focus()
            CalcuteRevisedValue()
            Exit Sub
        End If
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtVariationOrders_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtVariationOrders.Validating
        If IsNumeric(txtVariationOrders.Text) Then txtVariationOrders.Text = Format(CDbl(txtVariationOrders.Text), "##0.00")
        CalcuteRevisedValue()
    End Sub

    Private Sub txtOvertime_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOvertime.Validating
        If IsNumeric(txtOvertime.Text) Then txtOvertime.Text = Format(CDbl(txtOvertime.Text), "##0.00")
        CalcuteRevisedValue()
    End Sub

    Private Sub txtContractValue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtContractValue.Validating
        If IsNumeric(txtContractValue.Text) Then txtContractValue.Text = Format(CDbl(txtContractValue.Text), "##0.00")
        CalcuteRevisedValue()
    End Sub

    Private Sub txtConBrackets_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtConBrackets.Validating
        If IsNumeric(txtConBrackets.Text) Then txtConBrackets.Text = Format(CDbl(txtConBrackets.Text), "##0.00")
        CalcuteRevisedValue()
    End Sub

    Private Sub prntDocument_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles prntDocument.PrintPage

        If boolPrintFromPreview = True Then
            PrintData()
        End If

        Dim x1 As Integer = 0, x2 As Integer = 0, X3 As Integer = 0,
            X4 As Integer = 0, X5 As Integer = 0, X6 As Integer = 0,
            X7 As Integer = 0, X8 As Integer = 0, X9 As Integer = 0,
            X10 As Integer = 0, X11 As Integer = 0

        Dim y1 As Integer = 0, y2 As Integer = 0, p1 As Integer = 0
        x1 = e.PageBounds.Left + 100
        y1 = e.PageBounds.Top + 100
        p1 = e.PageBounds.Width - 200
        y2 = e.PageBounds.Height - 200

        intPageHeight = e.PageBounds.Height - 100
        intPageHeight = intPageHeight - 30

        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        Dim strS As String = Nothing
        Dim Yc As Double = 0
        Dim cols As Double = 0, lines As Double = 0

        'Draw the document rectangle
        reccurrent = New Rectangle(x1, y1, p1, y2)
        e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)

        Dim intLogoNextXPosition As Integer = intLogoXposition

        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                Dim intImageYLocation As Double = objPicture.Height
                intImageYLocation = (100 - intImageYLocation) / 2
                R = New Rectangle(intLogoXposition, intLogoYposition, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                intLogoNextXPosition = R.X + R.Width + 3
            End If
        End If

        '
        'Draw the company details border
        '
        ' '' ''reccurrent = New Rectangle(x1, y1, 323, 150)
        ' '' ''e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)
        ' '' ''Call DrawStringInBoxLeft(e, x1 + 15, y1 + 15, 300, 25, "COMPANY DETAILS", fntHeaderFont, Brushes.Black)

        '' '' ''Draw the document details box
        ' '' ''reccurrent = New Rectangle(x1 + 325, y1, 325, 150)
        ' '' ''e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)
        ' '' ''Call DrawStringInBoxLeft(e, x1 + 345, y1 + 15, 300, 25, "DOCUMENT DETAILS", fntHeaderFont, Brushes.Black)

        '' '' ''
        '' '' '' *** DRAW THE BOTTOM BOXES
        '' '' ''
        ' '' ''y1 = y1 + 160

        ' '' ''reccurrent = New Rectangle(x1, y1, 323, 150)
        ' '' ''e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)
        ' '' ''Call DrawStringInBoxLeft(e, x1 + 15, y1 + 15, 300, 25, "CUSTOMER DETAILS", fntHeaderFont, Brushes.Black)

        '' '' ''Draw the document details box
        ' '' ''reccurrent = New Rectangle(x1 + 325, y1, 325, 150)
        ' '' ''e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)
        ' '' ''Call DrawStringInBoxLeft(e, x1 + 345, y1 + 15, 300, 25, "PROJECT DETAILS", fntHeaderFont, Brushes.Black)


        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 300, 80, strCompanyName, fntHeaderFont, Brushes.Black)
        y1 = y1 + 20

        If Not String.IsNullOrEmpty(strCompanyAddress1) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress1, fntDetailsFont, Brushes.Black)
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "CK NO.  : " & UCase(strCompanyRegistrationNumber), fntDetailsFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the company number
            If Not String.IsNullOrEmpty(strCompanyRegistrationNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "CK NO.  : " & UCase(strCompanyRegistrationNumber), fntDetailsFont, Brushes.Black)
                y1 = y1 + 15
            End If
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress2) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress2, fntDetailsFont, Brushes.Black)
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO. : " & UCase(strCompanyVatNumber), fntDetailsFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Else
            'Print the vat number
            If Not String.IsNullOrEmpty(strCompanyVatNumber) Then
                Call gwt_comm.DrawStringInBoxLeft(e, 400, y1, 250, 80, "VAT NO. : " & UCase(strCompanyVatNumber), fntDetailsFont, Brushes.Black)
            End If
            y1 = y1 + 15
        End If

        If Not String.IsNullOrEmpty(strCompanyAddress3) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress3, fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyAddress4) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, strCompanyAddress4, fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If

        If Not String.IsNullOrEmpty(strCompanyTelephone) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "PHONE  : " & UCase(strCompanyTelephone), fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        'strCompanyContactCellNumber
        If Not String.IsNullOrEmpty(strCompanyContactCellNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 550, 80, "CELL NO: " & UCase(strCompanyContactCellNumber), fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyFaxNumber) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "FAX NO.: " & UCase(strCompanyFaxNumber), fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyEmailAddress) Then
            Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 250, 80, "E-MAIL : " & strCompanyEmailAddress, fntDetailsFont, Brushes.Black)
            y1 = y1 + 15
        End If
        y1 = y1 + 5

        e.Graphics.DrawLine(Pens.LightGray, x1, y1, p1 + 100, y1)
        y1 = y1 + 20
        e.Graphics.DrawString("CUSTOMER DETAILS", fntHeaderFont, Brushes.Black, x1 + 10, y1)
        e.Graphics.DrawString("PROJECT DETAILS", fntHeaderFont, Brushes.Black, 500, y1)
        y1 = y1 + 20
        e.Graphics.DrawLine(Pens.LightGray, x1, y1, p1 + 100, y1)
        y1 = y1 + 15
        e.Graphics.DrawString("VAT No.: " & strCustomerVatNumber, fntDetailsFont, Brushes.Black, x1 + 10, y1) '& Space(20) & " VAT No.: " & UCase(strCustomerVatNumber)
        y1 = y1 + 15

        If Not String.IsNullOrEmpty(strCustomerName) Then
            If strCustomerName.Length > 58 Then strCustomerName = Mid(strCustomerName, 1, 58)
        End If

        e.Graphics.DrawString(UCase(strCustomerName), fntDetailsFont, Brushes.Black, x1 + 10, y1)
        'e.Graphics.DrawString(strCustomerName, fntDetailsFont, Brushes.Black, x1, y1)
        'Print the date
        e.Graphics.DrawString("DATE", fntDetailsFont, Brushes.Black, 500, y1)
        e.Graphics.DrawString(": " & gwt_comm.shortMonthDateFormat(Now), fntDetailsFont, Brushes.Black, 600, y1)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "PROJECT NUM", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 600, y1, 300, 80, ": " & Format(CLng(lblProjectNo.Text), "000000") & Space(5) & "SITE : " & UCase(lblProjectOwner.Text), fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress1, fntDetailsFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress2, fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "OUR REF.NO.", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 600, y1, 300, 80, ": " & UCase("GTI-" & lblProjectNo.Text), fntDetailsFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress3, fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "INITIAL VALUE", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 600, y1, 300, 80, ": " & UCase(txtContractValue.Text), fntDetailsFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress4, fntDetailsFont, Brushes.Black)
        'PRINT REVISED VALUE
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "REVISED VALUE", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 600, y1, 300, 80, ": " & Format(CDbl(lblRevisedValue.Text), "##0.00"), fntDetailsFont, Brushes.Black)
        y1 += 15
        e.Graphics.DrawString("TELEPHONE : " & strCustomerTelephone, fntDetailsFont, Brushes.Black, x1 + 10, y1)
        'PRINT STILL TO INVOICE
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 150, 80, "STILL TO INVOICE", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 600, y1, 150, 80, ": " & Format(CDbl(lblStillToInvoice.Text), "##0.00"), fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 750, y1, 300, 80, "TOTAL TO INVOICE : " & Format(Format(CDbl(lblTotalOutstanding.Text), "#,##0.00")), fntTotalsFont, Brushes.Black)
        y1 += 15
        e.Graphics.DrawString("E-MAIL    :" & strCustomerEmailAddress, fntDetailsFont, Brushes.Black, x1 + 10, y1)
        'PAGE NUMBER
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "PAGE No.", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 600, y1, 300, 80, ": " & intPage, fntDetailsFont, Brushes.Black)
        y1 = y1 + 20

        '
        ' *** DRAW THE MAIN TRANSACTIONS BOX
        '

        ' &&&&&& y1 = y1 + 200 &&&&&&

        'Set the cordinate values for x
        x1 = 100
        x2 = x1 + 80
        X3 = x2 + 80
        X4 = X3 + 80
        X5 = X4 + 80
        X6 = X5 + 80
        X7 = X6 + 80
        X8 = X7 + 80
        X9 = X8 + 80
        X10 = X9 + 80
        X11 = X10 + 80

        Dim intPageWidth As Integer = e.PageBounds.Width - 200

        reccurrent = New Rectangle(x1, y1, intPageWidth, 280)
        e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)
        Call gwt_comm.DrawStringInBoxLeft(e, x1 + 15, y1 + 10, 300, 25, "CERTIFIED CLAIMS", fntHeaderFont, Brushes.Black)
        'Print the invoice area label
        Call gwt_comm.DrawStringInBoxLeft(e, X4 + 15, y1 + 10, 300, 25, "INVOICED CLAIMS", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, X7 + 15, y1 + 10, 300, 25, "FIRST PAYMENT", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, X9 + 10, y1 + 10, 300, 25, "SECOND PAYMENT", fntHeaderFont, Brushes.Black)
        '************************DRAW THE VERICALS ********************************************

        e.Graphics.DrawLine(Pens.LightGray, x2, y1 + 35, x2, y1 + reccurrent.Height)
        e.Graphics.DrawLine(Pens.LightGray, X3, y1 + 35, X3, y1 + reccurrent.Height)
        e.Graphics.DrawLine(Pens.LightGray, X4, y1, X4, y1 + reccurrent.Height)
        e.Graphics.DrawLine(Pens.LightGray, X5, y1 + 35, X5, y1 + reccurrent.Height)
        e.Graphics.DrawLine(Pens.LightGray, X6, y1 + 35, X6, y1 + reccurrent.Height)

        e.Graphics.DrawLine(Pens.LightGray, X7, y1, X7, y1 + reccurrent.Height)
        e.Graphics.DrawLine(Pens.LightGray, X8, y1 + 35, X8, y1 + reccurrent.Height)
        e.Graphics.DrawLine(Pens.LightGray, X9, y1, X9, y1 + reccurrent.Height)

        e.Graphics.DrawLine(Pens.LightGray, X10, y1 + 35, X10, y1 + reccurrent.Height)
        e.Graphics.DrawLine(Pens.LightGray, X11, y1, X11, y1 + reccurrent.Height)

        '*** DRAW HORIZONTAL LINE ACCROSS 
        e.Graphics.DrawLine(Pens.LightGray, x1, y1 + 35, x1 + intPageWidth, y1 + 35)
        'Draw the second divider horizontal line
        e.Graphics.DrawLine(Pens.LightGray, x1, y1 + 70, x1 + intPageWidth, y1 + 70)
        'Draw horizontal line at the bottom
        e.Graphics.DrawLine(Pens.LightGray, x1, (intPageHeight - 45), x1 + intPageWidth, (intPageHeight - 45))

        'Write the column headings

        Call gwt_comm.DrawStringInBoxLeft(e, x1 + 5, y1 + 40, 80, 25, "DATE", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, x2 + 5, y1 + 40, 80, 25, "NO.", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, X3 + 2, y1 + 40, 80, 25, "AMOUNT", fntHeaderFont, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, X4 + 5, y1 + 40, 80, 25, "DATE", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, X5 + 5, y1 + 40, 80, 25, "NO.", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, X6 + 2, y1 + 40, 80, 25, "AMOUNT", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, X7 + 2, y1 + 40, 80, 25, "DATE", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, X8 + 5, y1 + 40, 100, 25, "PAID", fntHeaderFont, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, X9 + 5, y1 + 40, 100, 25, "DATE", fntHeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, X10 + 5, y1 + 40, 100, 25, "PAID", fntHeaderFont, Brushes.Black)

        Call gwt_comm.DrawStringInBoxLeft(e, X11 + 5, y1 + 40, 100, 25, "BALANCE", fntHeaderFont, Brushes.Black)

        '
        '########################################### ADD THE TRANSACTIONS #####################

        Dim intYprint As Integer = y1 + 75
        boolExitingWhile = False
        intLineCounter = 0

        Dim dblCertifiedTotal As Double = 0
        Dim dblInvoicedTotal As Double = 0
        Dim dblPaidTotal As Double = 0
        Dim dblBalanceTotal As Double = 0
        Dim dblPaidTotal2 As Double = 0

        While itm <= arrPrintValues.Count - 1
            Dim strBuffer() As String = Split(arrPrintValues(itm), "|")
            'Claim Date
            Call gwt_comm.DrawStringInBoxLeft(e, x1, intYprint, 75, 60, strBuffer(0), fntDetailsFont, Brushes.Black)
            'Claim Number
            Call gwt_comm.DrawStringInBoxLeft(e, x2, intYprint, 75, 60, strBuffer(1), fntDetailsFont, Brushes.Black)
            'Claim Value
            Call gwt_comm.DrawStringInBoxRight(e, X3, intYprint, 75, 60, Format(CDbl(strBuffer(2)), "#,##0.00"), fntDetailsFont, Brushes.Black)
            If IsNumeric(strBuffer(2)) Then dblCertifiedTotal = dblCertifiedTotal + CDbl(strBuffer(2))
            If IsNumeric(strBuffer(2)) Then dblCertifiedTotalRunning = dblCertifiedTotalRunning + CDbl(strBuffer(2))

            'Invoice Date
            Call gwt_comm.DrawStringInBoxLeft(e, X4, intYprint, 75, 60, strBuffer(3), fntDetailsFont, Brushes.Black)
            'Invoice Number
            Call gwt_comm.DrawStringInBoxLeft(e, X5, intYprint, 75, 60, strBuffer(4), fntDetailsFont, Brushes.Black)
            'Invoice Amount
            Call gwt_comm.DrawStringInBoxRight(e, X6, intYprint, 75, 60, Format(CDbl(strBuffer(5)), "#,##0.00"), fntDetailsFont, Brushes.Black)
            If IsNumeric(strBuffer(5)) Then dblInvoicedTotal = dblInvoicedTotal + CDbl(strBuffer(5))
            If IsNumeric(strBuffer(5)) Then dblInvoicedTotalRunning = dblInvoicedTotalRunning + CDbl(strBuffer(5))

            'Receipt Date value
            Call gwt_comm.DrawStringInBoxLeft(e, X7, intYprint, 75, 60, strBuffer(6), fntDetailsFont, Brushes.Black)
            'Receipt 1 amount
            Call gwt_comm.DrawStringInBoxRight(e, X8, intYprint, 75, 60, Format(CDbl(strBuffer(7)), "#,##0.00"), fntDetailsFont, Brushes.Black)

            If IsNumeric(strBuffer(7)) Then dblPaidTotal = dblPaidTotal + CDbl(strBuffer(7))
            If IsNumeric(strBuffer(7)) Then dblPaidTotalRunning = dblPaidTotalRunning + CDbl(strBuffer(7))

            'Receipt 2 Date
            Call gwt_comm.DrawStringInBoxLeft(e, X9, intYprint, 75, 60, strBuffer(8), fntDetailsFont, Brushes.Black)
            'Receipt 2 Amount
            Call gwt_comm.DrawStringInBoxRight(e, X10, intYprint, 75, 60, Format(CDbl(strBuffer(9)), "#,##0.00"), fntDetailsFont, Brushes.Black)
            If IsNumeric(strBuffer(9)) Then dblPaidTotal2 = dblPaidTotal2 + CDbl(strBuffer(9))
            If IsNumeric(strBuffer(9)) Then dblPaidTotalRunning2 = dblPaidTotalRunning2 + CDbl(strBuffer(9))

            'Balance
            Call gwt_comm.DrawStringInBoxRight(e, X11, intYprint, 75, 60, Format(CDbl(strBuffer(10)), "#,##0.00"), fntDetailsFont, Brushes.Black)
            If IsNumeric(strBuffer(10)) Then dblBalanceTotal = dblBalanceTotal + CDbl(strBuffer(7))
            If IsNumeric(strBuffer(10)) Then dblBalanceTotalRunning = dblBalanceTotalRunning + CDbl(strBuffer(10))

            'Increament the line counter
            intYprint = intYprint + 15

            itm = itm + 1
            intLineCounter = intLineCounter + 1

            If intLineCounter = 12 Then
                intPage += 1
                Call gwt_comm.DrawStringInBoxLeft(e, x1, intPageHeight - 30, 75, 60, "TOTALS", fntTotalsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, X3, intPageHeight - 30, 75, 60, Format(dblCertifiedTotalRunning, "#,##0.00"), fntTotalsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, X6, intPageHeight - 30, 75, 60, Format(dblInvoicedTotalRunning, "#,##0.00"), fntTotalsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, X8, intPageHeight - 30, 75, 60, Format(dblPaidTotalRunning, "#,##0.00"), fntTotalsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, X10, intPageHeight - 30, 75, 60, Format(dblPaidTotalRunning2, "#,##0.00"), fntTotalsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, X11, intPageHeight - 30, 75, 60, Format(dblBalanceTotalRunning, "#,##0.00"), fntTotalsFont, Brushes.Black)
                boolExitingWhile = True
                e.HasMorePages = True
                Exit While
            End If

        End While

        '######################################### TRANSACTION PRINT END #####################



        '
        '**************************************************************************************
        '

        '
        ' *** DRAW THE SUMMARY BOX
        '

        'y1 = y1 + 435
        'reccurrent = New Rectangle(x1, y1, 323, 100)
        'e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)
        'Call DrawStringInBoxLeft(e, x1 + 15, y1 + 15, 300, 25, "SUMMARY DETAILS", fntHeaderFont, Brushes.Black)

        If boolExitingWhile = False Then
            Call gwt_comm.DrawStringInBoxLeft(e, x1, intPageHeight - 30, 75, 60, "TOTALS", fntTotalsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X3, intPageHeight - 30, 75, 60, Format(dblCertifiedTotalRunning, "#,##0.00"), fntTotalsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X6, intPageHeight - 30, 75, 60, Format(dblInvoicedTotalRunning, "#,##0.00"), fntTotalsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X8, intPageHeight - 30, 75, 60, Format(dblPaidTotalRunning, "#,##0.00"), fntTotalsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X10, intPageHeight - 30, 75, 60, Format(dblPaidTotalRunning2, "#,##0.00"), fntTotalsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxRight(e, X11, intPageHeight - 30, 75, 60, Format(dblBalanceTotalRunning, "#,##0.00"), fntTotalsFont, Brushes.Black)
            Call gwt_comm.DrawStringInBoxLeft(e, (x1 + 5), intPageHeight - 5, intPageWidth - 10, 50, strCommonMessage, fntDetailsFont, Brushes.Black)
            e.HasMorePages = False
            Me.boolPrintFromPreview = True
            itm = 0
        End If

    End Sub

    Private Sub PrintData()

        ' build the print array based on the date selections
        arrPrintValues = New ArrayList
        GetCustomerDetails(lblCustomerNo.Text)

        dblCertifiedTotalRunning = 0
        dblInvoicedTotalRunning = 0
        dblPaidTotalRunning = 0
        dblBalanceTotalRunning = 0
        dblPaidTotalRunning2 = 0

        'For t As Integer = 0 To 19
        With dgrid
            For i As Integer = 0 To .RowCount - 1

                Dim strValues As String = Nothing
                Dim strInvoiceDate As String = Nothing
                Dim intInvoiceNumber As Integer = 0
                Dim intClaimNumber As Integer = 0
                Dim dblInvoiceAmtNoVat As Double = 0
                Dim dblInvoiceAmtWithVat As Double = 0
                Dim strCreditNoteDate As String = Nothing
                Dim intCreditNoteNumber As Integer = 0
                Dim dblCnoteAmtNoVat As Double = 0
                Dim dblCnoteAmtWithVat As Double = 0
                Dim strPayDate1 As String = Nothing
                Dim dblPayAmt1 As Double = 0
                Dim strPayDate2 As String = Nothing
                Dim dblPayAmt2 As Double = 0
                Dim dblBalance As Double = 0
                Dim dblClaimAmt As Double = 0

                Dim strClaimDate As String = Nothing

                Dim strBuffer() As String

                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "") Then
                    strClaimDate = .Rows(i).Cells(0).Value.ToString
                    strBuffer = Split(strClaimDate, "-")
                    If strBuffer.Length = 3 Then
                        If IsNumeric(strBuffer(0)) And IsNumeric(strBuffer(1)) And IsNumeric(strBuffer(2)) Then
                            strClaimDate = strBuffer(0) & "-" & UCase(MonthName(CInt(strBuffer(1)), True)) & "-" & strBuffer(2)
                        Else
                            strClaimDate = Nothing
                        End If
                    Else
                        strClaimDate = Nothing
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(1).Value.ToString) Then
                        intClaimNumber = CInt(.Rows(i).Cells(1).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(2).Value.ToString) Then
                        dblClaimAmt = CDbl(.Rows(i).Cells(2).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "") Then
                    strInvoiceDate = .Rows(i).Cells(3).Value.ToString
                    strBuffer = Split(strInvoiceDate, "-")
                    If strBuffer.Length = 3 Then
                        If IsNumeric(strBuffer(0)) And IsNumeric(strBuffer(1)) And IsNumeric(strBuffer(2)) Then
                            strInvoiceDate = strBuffer(0) & "-" & UCase(MonthName(CInt(strBuffer(1)), True)) & "-" & strBuffer(2)
                        Else
                            strInvoiceDate = Nothing
                        End If
                    Else
                        strInvoiceDate = Nothing
                    End If
                End If

                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(4).Value.ToString) Then
                        intInvoiceNumber = CInt(.Rows(i).Cells(4).Value.ToString)
                    End If
                End If

                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(5).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(5).Value.ToString) Then
                        dblInvoiceAmtNoVat = CDbl(.Rows(i).Cells(5).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(6).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(6).Value.ToString) Then
                        dblInvoiceAmtWithVat = CInt(.Rows(i).Cells(6).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(7).Value), "") Then
                    strCreditNoteDate = .Rows(i).Cells(7).Value.ToString
                    strBuffer = Split(strCreditNoteDate, "-")
                    If strBuffer.Length = 3 Then
                        If IsNumeric(strBuffer(0)) And IsNumeric(strBuffer(1)) And IsNumeric(strBuffer(2)) Then
                            strCreditNoteDate = strBuffer(0) & "-" & UCase(MonthName(CInt(strBuffer(1)), True)) & "-" & strBuffer(2)
                        Else
                            strCreditNoteDate = Nothing
                        End If
                    Else
                        strCreditNoteDate = Nothing
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(8).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(8).Value.ToString) Then
                        intCreditNoteNumber = CInt(.Rows(i).Cells(8).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(9).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(9).Value.ToString) Then
                        dblCnoteAmtNoVat = CDbl(.Rows(i).Cells(9).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(10).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(10).Value.ToString) Then
                        dblCnoteAmtWithVat = CDbl(.Rows(i).Cells(10).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(11).Value), "") Then
                    strPayDate1 = .Rows(i).Cells(11).Value.ToString
                    strBuffer = Split(strPayDate1, "-")
                    If strBuffer.Length = 3 Then
                        If IsNumeric(strBuffer(0)) And IsNumeric(strBuffer(1)) And IsNumeric(strBuffer(2)) Then
                            strPayDate1 = strBuffer(0) & "-" & UCase(MonthName(CInt(strBuffer(1)), True)) & "-" & strBuffer(2)
                        Else
                            strPayDate1 = Nothing
                        End If
                    Else
                        strPayDate1 = Nothing
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(12).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(12).Value.ToString) Then
                        dblPayAmt1 = CDbl(.Rows(i).Cells(12).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(13).Value), "") Then
                    strPayDate2 = .Rows(i).Cells(13).Value.ToString
                    strBuffer = Split(strPayDate2, "-")
                    If strBuffer.Length = 3 Then
                        If IsNumeric(strBuffer(0)) And IsNumeric(strBuffer(1)) And IsNumeric(strBuffer(2)) Then
                            strPayDate2 = strBuffer(0) & "-" & UCase(MonthName(CInt(strBuffer(1)), True)) & "-" & strBuffer(2)
                        Else
                            strPayDate2 = Nothing
                        End If
                    Else
                        strPayDate2 = Nothing
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(14).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(14).Value.ToString) Then
                        dblPayAmt2 = CDbl(.Rows(i).Cells(14).Value.ToString)
                    End If
                End If
                If Not Object.Equals(Convert.ToString(.Rows(i).Cells(15).Value), "") Then
                    If IsNumeric(.Rows(i).Cells(15).Value.ToString) Then
                        dblBalance = CDbl(.Rows(i).Cells(15).Value.ToString)
                    End If
                End If

                strValues = strClaimDate & "|" & intClaimNumber & "|" & CStr(Format(dblClaimAmt, "##0.00")) &
                    "|" & strInvoiceDate & "|" & intInvoiceNumber & "|" & dblInvoiceAmtWithVat & "|" &
                    strPayDate1 & "|" & (Format((dblPayAmt1), "##0.00")) & "|" & strPayDate2 & "|" &
                    Format(dblPayAmt2, "##0.00") & "|" & CStr(Format(dblBalance, "##0.00") & "|" & strPayDate1)

                If UCase(strValues) = "|||||||||" Then
                    'This means that the string is empty so do nothing tot
                Else
                    arrPrintValues.Add(strValues)
                End If

            Next
        End With
        'Next

    End Sub

    Private Sub GetCustomerDetails(ByVal strCustomerNumber As String)
        On Error GoTo RaiseErr
        'Get the customer details
        Dim myCommand As New Data.OleDb.OleDbCommand("SELECT AccountName, Address1, Address2, Address3, Address4, " _
            & "PhoneNumber, EmailAddress, VatNumber FROM Customers WHERE AccountNumber = '" & strCustomerNumber & "'", cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
        If dbReader.HasRows Then
            dbReader.Read()
            If Not IsDBNull(dbReader(0).ToString) Then strCustomerName = dbReader(0).ToString
            If Not IsDBNull(dbReader(1).ToString) Then strCustomerAddress1 = dbReader(1).ToString
            If Not IsDBNull(dbReader(2).ToString) Then strCustomerAddress2 = dbReader(2).ToString
            If Not IsDBNull(dbReader(3).ToString) Then strCustomerAddress3 = dbReader(3).ToString
            If Not IsDBNull(dbReader(4).ToString) Then strCustomerAddress4 = dbReader(4).ToString
            If Not IsDBNull(dbReader(5).ToString) Then strCustomerTelephone = dbReader(5).ToString
            If Not IsDBNull(dbReader(6).ToString) Then strCustomerEmailAddress = dbReader(6).ToString
            If Not IsDBNull(dbReader(7).ToString) Then strCustomerVatNumber = dbReader(7).ToString
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Details Fetch"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoice.Click
        If String.IsNullOrEmpty(lblCustomerNo.Text) Then
            MessageBox.Show("Please select the customer first and then proceed", "Missing Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblProjectNo.Text) Then
            MessageBox.Show("Please select the project to work with first", "Missing Project Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        boolEditStatusTwo = False
        intSelectedProjectNumber = CInt(lblProjectNo.Text)
        strSelectedAccount = lblCustomerNo.Text
        boolLoadedFromCustomerForm = True
        Dim f As New frmInvoice
        f.ShowDialog()
        intSelectedProjectNumber = 0
        'LoadTransactions()
    End Sub

    Private Sub btnRemoveLine_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveLine.Click
        If dgrid.Rows.Count <= 0 Then Exit Sub
        dgrid.Rows.RemoveAt(dgrid.CurrentRow.Index)
        ComputeTotals()
    End Sub

    Private Sub mnuInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInvoice.Click
        If String.IsNullOrEmpty(lblProjectOwner.Text) Then Exit Sub
        If dgrid.Rows.Count <= 0 Then Exit Sub
        boolAbort = False
        'Dim strBuffer() As String = Split(lblProjectOwner.Text, "..")
        strSelectedAccount = strSelectedProjectOwnerNumber
        dblAccountSettlementAmount = 0
        strSelectedDate = Nothing
        intSelectedTransaction = 0
        strCalledBy = "Invoices"
        Dim f As New frmTransactionsPickList
        f.ShowDialog()
        If boolAbort = False Then
            With dgrid.CurrentRow
                .Cells(4).Value = intSelectedTransaction
                .Cells(3).Value = strSelectedDate
                .Cells(5).Value = dblAccountSettlementAmount
            End With
        End If
        'Reset the public variables immediately
        strSelectedAccount = Nothing
        dblAccountSettlementAmount = 0
        strSelectedDate = Nothing
        intSelectedTransaction = 0
        strCalledBy = Nothing
    End Sub

    Private Sub mnuReceipt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuReceipt.Click
        If String.IsNullOrEmpty(lblProjectOwner.Text) Then Exit Sub
        If dgrid.Rows.Count <= 0 Then Exit Sub
        boolAbort = False
        'Dim strBuffer() As String = Split(cboProjectOwner.Text, "..")
        strSelectedAccount = strSelectedProjectOwnerNumber 'Trim(strBuffer(1))
        dblAccountSettlementAmount = 0
        strSelectedDate = Nothing
        intSelectedTransaction = 0
        strCalledBy = "Payments"
        Dim f As New frmTransactionsPickList
        f.ShowDialog()
        If boolAbort = False Then
            With dgrid.CurrentRow
                .Cells(11).Value = strSelectedDate
                .Cells(12).Value = dblAccountSettlementAmount
            End With
        End If
        'Reset the public variables immediately
        strSelectedAccount = Nothing
        dblAccountSettlementAmount = 0
        strSelectedDate = Nothing
        intSelectedTransaction = 0
        strCalledBy = Nothing
    End Sub

    Private Sub mnuCreditNote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuCreditNote.Click
        If String.IsNullOrEmpty(lblProjectOwner.Text) Then Exit Sub
        If dgrid.Rows.Count <= 0 Then Exit Sub
        boolAbort = False
        'Dim strBuffer() As String = Split(lblProjectOwner.Text, "..")
        strSelectedAccount = strSelectedProjectOwnerNumber
        dblAccountSettlementAmount = 0
        strSelectedDate = Nothing
        intSelectedTransaction = 0
        strCalledBy = "Credit Notes"
        Dim f As New frmTransactionsPickList
        f.ShowDialog()
        If boolAbort = False Then
            With dgrid.CurrentRow
                .Cells(7).Value = strSelectedDate
                .Cells(8).Value = intSelectedTransaction
                .Cells(9).Value = dblAccountSettlementAmount
            End With
        End If
        'Reset the public variables immediately
        strSelectedAccount = Nothing
        dblAccountSettlementAmount = 0
        strSelectedDate = Nothing
        intSelectedTransaction = 0
        strCalledBy = Nothing
    End Sub

    Private Sub btnPrintClaim_Click(sender As Object, e As System.EventArgs) Handles btnPrintClaim.Click
        strCommonMessage = Nothing

        If dgrid.Rows.Count <= 0 Then
            MessageBox.Show("Document cannot be printed. There are no transactions to this project", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If MessageBox.Show("Do you want to add any comments?", "Confirm Comment Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            boolAbort = False
            Dim frm As New frmClaimsComment
            frm.ShowDialog()
            If boolAbort = True Then strCommonMessage = Nothing
            boolPrintFromPreview = False
        End If
        PrintData()

        itm = 0
        intPage = 1

        'Dim pd As New PrintDialog()
        'pd.PrinterSettings = New PrinterSettings()
        boolAbort = False
        gwt_comm.PrinterSelection()
        If boolAbort = True Then Exit Sub
        'boolPrintFromPreview = True
        prntDocument.PrinterSettings.PrinterName = strSessionPrinter
        prntDocument.DefaultPageSettings.Landscape = True
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = prntDocument
        'boolPrintFromPreview = False
        documentPreview.ShowDialog()

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

    Private Sub btnGoJobs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGoJobs.Click
        LoadJobsDataByDate(CStr(gwt_comm.shortMonthDateFormat(dpStartFromJobs.Value)), CStr(gwt_comm.shortMonthDateFormat(dpEndToJobs.Value)))
    End Sub

    Private Sub LoadJobsDataByDate(ByVal startDate As String, ByVal endDate As String)
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT ReferenceNumber AS [Doc #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "CustomerName AS [Customer], CAST(InspectionFee AS DECIMAL (10,2)) AS [Inspection], CAST(JobValue AS DECIMAL (10,2)) AS " _
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
                    & "CustomerName as [Customer], CAST(InspectionFee AS DECIMAL (10,2)) AS [Inspection], CAST(JobValue AS DECIMAL (10,2)) AS " _
                    & "[Value], Status, SerialNumber AS [Serial #], ItemName AS [Item], ContraInvoiceNumber AS [Invoice] FROM JobCards " _
                    & "WHERE CustomerName LIKE '%" & strFind & "%' ORDER BY ReferenceNumber"
            Case Is = UCase("Phone type")
                'ItemState like '&Nok%' or ItemName like '%Nok%'
                strSql = "SELECT ReferenceNumber AS [Doc #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CustomerName AS [Customer], CAST(InspectionFee AS DECIMAL (10,2)) AS [Inspection], CAST(JobValue AS DECIMAL (10,2)) AS " _
                    & "[Value], Status, SerialNumber AS [Serial #], ItemName AS [Item], ContraInvoiceNumber AS [Invoice] FROM JobCards " _
                    & "WHERE ItemState like '%" & strFind & "%' or ItemName like '%" & strFind & "%' ORDER BY ReferenceNumber"

            Case Is = UCase("Serial number")
                strSql = "SELECT ReferenceNumber AS [Doc #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CustomerName AS [Customer], CAST(InspectionFee AS DECIMAL (10,2)) AS [Inspection], CAST(JobValue AS DECIMAL (10,2)) AS " _
                    & "[Value], Status, SerialNumber AS [Serial #], ItemName AS [Item], ContraInvoiceNumber AS [Invoice] FROM JobCards " _
                    & "WHERE SerialNumber LIKE '%" & strFind & "%' ORDER BY ReferenceNumber"

            Case = UCase("Contact Number")
                strSql = "SELECT ReferenceNumber AS [Doc #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CustomerName AS [Customer], CAST(InspectionFee AS DECIMAL (10,2)) AS [Inspection], CAST(JobValue AS DECIMAL (10,2)) AS " _
                    & "[Value], Status, SerialNumber AS [Serial #], ItemName AS [Item], ContraInvoiceNumber AS [Invoice] FROM JobCards " _
                    & "WHERE ContactNumber LIKE '%" & strFind & "%' ORDER BY ReferenceNumber"

            Case Else
                strSql = "SELECT ReferenceNumber AS [Doc #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
                    & "CustomerName AS [Customer], CAST(InspectionFee AS DECIMAL (10,2)) AS [Inspection], CAST(JobValue AS DECIMAL (10,2)) AS " _
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

    Private Sub btnJobServiceParameters_Click(sender As System.Object, e As System.EventArgs) Handles btnJobServiceParameters.Click
        Dim frm As New frmJobsServiceParameters
        frm.ShowDialog()
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
                    & "WHERE jobinvoicedetails.SalesRep = '" & UCase(cboUserJobSummaries.Text) & "' AND jobinvoicedetails.TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpStartFromJobSummaries.Value) & "' AND '" & gwt_comm.shortMonthDateFormat(dpEndToJobSummaries.Value) & "' " _
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

    Private Sub btnExpenses_Click(sender As System.Object, e As System.EventArgs) Handles btnExpenses.Click
        Dim frm As New frmProjectExpenses
        frm.ShowDialog()
    End Sub

    Private Sub btnMore_Click(sender As Object, e As EventArgs) Handles btnMore.Click
        boolAbort = False
        Dim frm As New frmAdvancedSearch
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        strSql = "SELECT ReferenceNumber AS [Doc #], CONVERT(NVARCHAR, TransDate, 105) AS [Date], " _
            & "CustomerName AS [Customer], CAST(InspectionFee AS DECIMAL (10,2)) AS [Inspection], " _
            & "CAST(JobValue AS DECIMAL (10,2)) AS [Value], Status, SerialNumber AS [Serial #], " _
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


    '***************************** PROJECT ANALYSIS CODE PROCEDURES *****************************

    Private Sub btnPrintAnalysis_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintAnalysis.Click
        If dGridAnalysis.Rows.Count <= 0 Then Exit Sub
        Dim strOwner() As String = Split(cboProjectOwner.Text, "..")
        Dim strProject() As String = Split(cboProject.Text, "..")
        'gwt_comm.PrintDataGrid(dGridAnalysis, "PROJECT FINANCIAL ANALYSIS FOR " & vbCrLf & UCase(Trim(strOwner(0))) & vbCrLf &
        '    "PROJECT NAME : " & UCase(Trim(strProject(0))))
    End Sub

    Private Sub ProjectProfitAndLossAnalysis()

        On Error GoTo RaiseErr
        dGridAnalysis.Rows.Clear()

        'Load Claims First
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT " _
            & "ClaimDate, ClaimNumber, CAST(ClaimAmount AS DECIMAL (10,2)) AS [Claim] FROM ConstructionClaimsHistory " _
            & "WHERE ProjectNumber = " & intSelectedProjectNumber & " ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        With dGridAnalysis
            While objReader.Read
                If IsNumeric(objReader(2).ToString) Then
                    If CDbl(objReader(2).ToString) <> 0 Then
                        Dim strDate As String = Nothing
                        If IsDate(objReader(0).ToString) Then
                            strDate = Format(CDate(objReader(0).ToString), "dd-MM-yyyy")
                            If UCase(strDate) = "01-01-1900" Then strDate = Nothing
                        End If
                        .Rows.Add(strDate, "CLAIM NUMBER " & objReader(1).ToString, Format(CDbl(objReader(2).ToString), "##0.00"), "", "")
                    End If
                End If
            End While
            objReader.Close()
        End With

        'Get the Invoices
        objCommand = New Data.OleDb.OleDbCommand("SELECT " _
            & "InvoiceDate, InvoiceNumber, CAST(AmountAfterVat AS DECIMAL (10,2)) AS [Invoice] FROM ConstructionClaimsHistory " _
            & "WHERE ProjectNumber = " & intSelectedProjectNumber & " ORDER BY TransactionId", cnn)
        objReader = objCommand.ExecuteReader
        With dGridAnalysis
            While objReader.Read
                If IsNumeric(objReader(2).ToString) Then
                    If CDbl(objReader(2).ToString) <> 0 Then
                        Dim strDate As String = Nothing
                        If IsDate(objReader(0).ToString) Then
                            strDate = Format(CDate(objReader(0).ToString), "dd-MM-yyyy")
                            If UCase(strDate) = "01-01-1900" Then strDate = Nothing
                        End If
                        .Rows.Add(strDate, "INVOICE NUMBER " & objReader(1).ToString, "", Format(CDbl(objReader(2).ToString), "##0.00"), "")
                    End If
                End If
            End While
            objReader.Close()
        End With

        'Get the expenses

        objCommand = New Data.OleDb.OleDbCommand("SELECT " _
            & "TransactionDate, Description, CAST(Amount AS DECIMAL (10,2)) AS [Amount] FROM cashbooktransactions " _
            & "WHERE LinkedProject = " & intSelectedProjectNumber & " ORDER BY TransactionId", cnn)
        objReader = objCommand.ExecuteReader
        With dGridAnalysis
            While objReader.Read
                If IsNumeric(objReader(2).ToString) Then
                    If CDbl(objReader(2).ToString) <> 0 Then
                        Dim strDate As String = Nothing
                        If IsDate(objReader(0).ToString) Then
                            strDate = Format(CDate(objReader(0).ToString), "dd-MM-yyyy")
                            If UCase(strDate) = "01-01-1900" Then strDate = Nothing
                        End If
                        .Rows.Add(strDate, objReader(1).ToString, "", "", Format(CDbl(objReader(2).ToString), "##0.00"))
                    End If
                End If
            End While
            objReader.Close()
        End With

        'Add Up the total

        Dim dblClaimsTotal As Double = 0
        Dim dblInvoiceTotal As Double = 0
        Dim dblExpensesTotal As Double = 0

        For i As Integer = 0 To dGridAnalysis.Rows.Count - 1
            If Not Object.Equals(dGridAnalysis.Rows(i).Cells(2).Value, Nothing) Then
                If IsNumeric(dGridAnalysis.Rows(i).Cells(2).Value.ToString) Then
                    dblClaimsTotal = dblClaimsTotal + CDbl(dGridAnalysis.Rows(i).Cells(2).Value.ToString)
                End If
            End If
            If Not Object.Equals(dGridAnalysis.Rows(i).Cells(3).Value, Nothing) Then
                If IsNumeric(dGridAnalysis.Rows(i).Cells(3).Value.ToString) Then
                    dblInvoiceTotal = dblInvoiceTotal + CDbl(dGridAnalysis.Rows(i).Cells(3).Value.ToString)
                End If
            End If
            If Not Object.Equals(dGridAnalysis.Rows(i).Cells(4).Value, Nothing) Then
                If IsNumeric(dGridAnalysis.Rows(i).Cells(4).Value.ToString) Then
                    dblExpensesTotal = dblExpensesTotal + CDbl(dGridAnalysis.Rows(i).Cells(4).Value.ToString)
                End If
            End If
        Next

        lblClaimValue.Text = Format(dblClaimsTotal, "##0.00")
        lblInvoices.Text = Format(dblInvoiceTotal, "##0.00")
        lblExpenses.Text = Format(dblExpensesTotal, "##0.00")
        lblProfit.Text = Format((dblInvoiceTotal - dblExpensesTotal), "##0.00")

        'Add the last 2 lines to grid showing totals
        dGridAnalysis.Rows.Add("", "TOTALS", Format(dblClaimsTotal, "##0.00"), Format(dblInvoiceTotal, "##0.00"), Format(dblExpensesTotal, "##0.00"))
        dGridAnalysis.Rows.Add("", "NET PROFIT/LOSS", Format(CDbl(lblProfit.Text), "##0.00"), "", "")

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Project Claims History Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadProjectOwners()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT AccountName +'..'+AccountNumber AS [Customer] FROM Customers ORDER BY AccountName"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        cboProjectOwner.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboProjectOwner.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Project Claims Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadClientProjects(ByVal CustomerNumber As String)
        On Error GoTo RaiseErr

        If boolFormInitializing = True Then Exit Sub
        Dim strSql As String = "SELECT ContractName +'..'+ CONVERT(NVARCHAR, ContractNumber) " _
            & "FROM ProjectsMain WHERE CustomerNumber = '" & CustomerNumber & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboProject.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboProject.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Project Claims Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboProjectOwner_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProjectOwner.Click
        If Not String.IsNullOrEmpty(cboProjectOwner.Text) Then
            Dim strSplit() As String = Split(cboProjectOwner.Text, "..")
            lblCustomerNoAnalysis.Text = strSplit(1)
            LoadClientProjects(strSplit(1))
        End If
    End Sub

    Private Sub cboProjectOwner_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProjectOwner.LostFocus
        If Not String.IsNullOrEmpty(cboProjectOwner.Text) Then
            Dim strSplit() As String = Split(cboProjectOwner.Text, "..")
            lblCustomerNoAnalysis.Text = strSplit(1)
            LoadClientProjects(strSplit(1))
        End If
    End Sub

    Private Sub cboProjectOwner_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProjectOwner.SelectedIndexChanged
        If Not String.IsNullOrEmpty(cboProjectOwner.Text) Then
            Dim strSplit() As String = Split(cboProjectOwner.Text, "..")
            lblCustomerNoAnalysis.Text = strSplit(1)
            LoadClientProjects(strSplit(1))
        End If
    End Sub

    Private Sub cboProject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProject.Click
        SelectAnalaysisProject()
    End Sub

    Private Sub cboProject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProject.SelectedIndexChanged
        SelectAnalaysisProject()
    End Sub

    Private Sub SelectAnalaysisProject()
        intSelectedProjectNumber = 0
        If Not String.IsNullOrEmpty(cboProject.Text) Then
            Dim strSplit() As String = Split(cboProject.Text, "..")
            intSelectedProjectNumber = CInt(strSplit(1))
            lblProjectNoAnalysis.Text = intSelectedProjectNumber
            ProjectProfitAndLossAnalysis()
        End If
    End Sub

    Private Sub btnDeleteProject_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteProject.Click

    End Sub

    Private Sub btnProjectsSummary_Click(sender As System.Object, e As System.EventArgs) Handles btnProjectsSummary.Click

    End Sub

    Private Sub btnFullProjectData_Click(sender As System.Object, e As System.EventArgs) Handles btnFullProjectData.Click

    End Sub
End Class
