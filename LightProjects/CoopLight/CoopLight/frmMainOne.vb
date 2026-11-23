Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMainOne

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmBenefitsMembersSetup
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [PolicyNumber] AS [Stand #], LastName +' '+ FirstName +' '+ OtherNames AS [Member Names], " _
            & "IdNumber as [ID Number], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), InceptionDate, 106), ' ', '-')) as [Entry Date], " _
            & "CAST(Capital AS DECIMAL (10,2)) AS [Property], CAST(StandSize AS DECIMAL (10,2)) AS [Stand], " _
            & "CAST(PeriodPremiums AS DECIMAL (10,2)) AS [Payment], BenefitType AS [Category] FROM BM_Master ORDER BY LastName, FirstName"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGrid.Columns.Clear()

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

        'Add table
        strSql = "IF OBJECT_ID(N'BM_TransactionHistory', N'U') IS NULL CREATE TABLE [dbo].[BM_TransactionHistory] " _
            & "([PolicyNumber][NVARCHAR](35) NOT NULL REFERENCES BM_Master (PolicyNumber), " _
            & "[TransYear][INT] NOT NULL DEFAULT 0, [Amount][FLOAT] NOT NULL DEFAULT 0, " _
            & "[TransactionId][INT] NOT NULL PRIMARY KEY IDENTITY (1,1), " _
            & "[AdminFee][Float] NOT NULL DEFAULT 0, [CoopFee][FLOAT] NOT NULL DEFAULT 0, " _
            & "[TransactionDate][SmallDateTime] Not NULL DEFAULT GetDate())"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Policy Holders Load"
        ShowErrorMessage()
    End Sub

    Private Sub GetSelected()
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                strSelectedAccount = dGrid.CurrentRow.Cells(0).Value.ToString
            End If
        End If
    End Sub

    Private Sub frmBenefitsMembers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        GetSelected()
        boolEditStatus = True
        Dim frm As New frmBenefitsMembersSetup
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count <= 0 Then Exit Sub
        GetSelected()
        boolEditStatus = True
        Dim frm As New frmBenefitsMembersSetup
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        If MessageBox.Show("Are you sure you want to delete this record", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'Get the selected record
            Dim strRecordToDelete As String = Nothing
            If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                    strRecordToDelete = dGrid.CurrentRow.Cells(0).Value.ToString
                End If
            End If
            If Not String.IsNullOrEmpty(strRecordToDelete) Then
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM BM_BankingDetails WHERE PolicyNumber = '" & strRecordToDelete & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM BM_Claims WHERE PolicyNumber = '" & strRecordToDelete & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM BM_Financials WHERE PolicyNumber = '" & strRecordToDelete & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM BM_Master WHERE PolicyNumber = '" & strRecordToDelete & "'", cnn)
                objCommand.ExecuteNonQuery()
            End If
            LoadData()
            MessageBox.Show("Student record deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Members Management"
        ShowErrorMessage()
    End Sub

    Private Sub txtSearchString_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            SearchForItem(txtSearchString.Text & e.KeyChar)
        Else
            SearchForItem(txtSearchString.Text)
        End If
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = strCurrentKey
        strActiveSearch = strFind

        Cursor = Cursors.WaitCursor

        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        'First Name, Last Name, Student Number

        Select Case cboSearchBy.Text
            Case Is = "First Name"
                strSql = "SELECT [PolicyNumber] AS [Stand #], LastName +' '+ FirstName +' '+ OtherNames AS [Member Names], " _
                    & "IdNumber as [ID Number], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), InceptionDate, 106), ' ', '-')) as [Entry Date], " _
                    & "CAST(Capital AS DECIMAL (10,2)) AS [Property], CAST(StandSize AS DECIMAL (10,2)) AS [Stand], " _
                    & "CAST(PeriodPremiums AS DECIMAL (10,2)) AS [Payment], BenefitType AS [Category] " _
                    & "FROM BM_Master WHERE FirstName Like '%" & strFind & "%' ORDER BY FirstName"
            Case Is = "Last Name"
                strSql = "SELECT [PolicyNumber] AS [Stand #], LastName +' '+ FirstName +' '+ OtherNames AS [Member Names], " _
                    & "IdNumber as [ID Number], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), InceptionDate, 106), ' ', '-')) as [Entry Date], " _
                    & "CAST(Capital AS DECIMAL (10,2)) AS [Property], CAST(StandSize AS DECIMAL (10,2)) AS [Stand], " _
                    & "CAST(PeriodPremiums AS DECIMAL (10,2)) AS [Payment], BenefitType AS [Category] " _
                    & "FROM BM_Master WHERE LastName Like '%" & strFind & "%' ORDER BY LastName"
            Case Is = "Member Number"
                strSql = "SELECT [PolicyNumber] AS [Stand #], LastName +' '+ FirstName +' '+ OtherNames AS [Member Names], " _
                    & "IdNumber as [ID Number], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), InceptionDate, 106), ' ', '-')) as [Entry Date], " _
                    & "CAST(Capital AS DECIMAL (10,2)) AS [Property], CAST(StandSize AS DECIMAL (10,2)) AS [Stand], " _
                    & "CAST(PeriodPremiums AS DECIMAL (10,2)) AS [Payment], BenefitType AS [Category] " _
                    & "FROM BM_Master WHERE [PolicyNumber] Like '%" & strFind & "%' ORDER BY [PolicyNumber]"
            Case Is = "Category"
                strSql = "SELECT [PolicyNumber] AS [Stand #], LastName +' '+ FirstName +' '+ OtherNames AS [Member Names], " _
                    & "IdNumber as [ID Number], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), InceptionDate, 106), ' ', '-')) as [Entry Date], " _
                    & "CAST(Capital AS DECIMAL (10,2)) AS [Property], CAST(StandSize AS DECIMAL (10,2)) AS [Stand], " _
                    & "CAST(PeriodPremiums AS DECIMAL (10,2)) AS [Payment], BenefitType AS [Category] " _
                    & "FROM BM_Master WHERE [BenefitType] Like '%" & strFind & "%' ORDER BY [PolicyNumber]"
            Case Else
                strSql = "SELECT [PolicyNumber] AS [Stand #], LastName +' '+ FirstName +' '+ OtherNames AS [Member Names], " _
                    & "IdNumber as [ID Number], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), InceptionDate, 106), ' ', '-')) as [Entry Date], " _
                    & "CAST(Capital AS DECIMAL (10,2)) AS [Property], CAST(StandSize AS DECIMAL (10,2)) AS [Stand], " _
                    & "CAST(PeriodPremiums AS DECIMAL (10,2)) AS [Payment], BenefitType AS [Category] " _
                    & "FROM BM_Master WHERE LastName Like '%" & strFind & "%' ORDER BY LastName"
        End Select

        dGrid.Columns.Clear()

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
        Next

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Members Management"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        gwt_comm.PrintDataGrid(dGrid, "Members Listing")
    End Sub

    Private Sub btnReceivePayment_Click(sender As System.Object, e As System.EventArgs) Handles btnReceivePayment.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        GetSelected()
        Dim frm As New frmBenefitsPropertyPayments
        frm.ShowDialog()
    End Sub

    Private Sub btnBillAll_Click(sender As System.Object, e As System.EventArgs) Handles btnBillAll.Click
        strBillingMethod = "ALL"
        Dim frm As New frmMembershipBilling
        frm.ShowDialog()
    End Sub

    Private Sub btnBillSelected_Click(sender As System.Object, e As System.EventArgs) Handles btnBillSelected.Click
        strBillingMethod = "SELECTIVE"
        GetSelected()
        Dim frm As New frmMembershipBilling
        frm.ShowDialog()
    End Sub

    Private Sub btnSchemes_Click(sender As System.Object, e As System.EventArgs) Handles btnSchemes.Click
        Dim frm As New frmBenefitSchemes
        frm.ShowDialog()
    End Sub

    Private Sub btnPrinters_Click(sender As System.Object, e As System.EventArgs) Handles btnPrinters.Click
        gwt_comm.PrinterSelection()
    End Sub

    Private Sub btnInterestRates_Click(sender As System.Object, e As System.EventArgs) Handles btnInterestRates.Click
        Dim frm As New frmBenefitsManagementInterestAllocationRatesSetup
        frm.ShowDialog()
    End Sub

    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles btnBillAllMembers.Click
        Dim frm As New frmMembershipBilling
        frm.ShowDialog()
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim frm As New frmImportData
        frm.ShowDialog()
        LoadData()
    End Sub

    Private Sub btnRefreshMain_Click(sender As Object, e As EventArgs) Handles btnRefreshMain.Click
        LoadData()
    End Sub

    Private Sub txtSearchString_TextChanged(sender As Object, e As EventArgs) Handles txtSearchString.TextChanged

    End Sub

    Private Sub cboHistoryYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboHistoryYear.SelectedIndexChanged
        If Not String.IsNullOrEmpty(cboHistoryYear.Text) Then
            LaodHistoricalPayments(CInt(cboHistoryYear.Text))
        Else
            MessageBox.Show("Please select the year from the drop down list", "No year defined", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub LaodHistoricalPayments(nYear As Integer)
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strCreate As String = "IF OBJECT_ID(N'BM_Payments_History', N'U') IS NULL " _
            & "CREATE TABLE BM_Payments_History ([PolicyNumber][NVARCHAR](35) Not NULL REFERENCES BM_Master (PolicyNumber), " _
            & "[JAN][FLOAT] Not NULL DEFAULT 0, [FEB][FLOAT] Not NULL DEFAULT 0, [MAR][FLOAT] Not NULL DEFAULT 0, " _
            & "[APR][FLOAT] Not NULL DEFAULT 0, [MAY][FLOAT] Not NULL DEFAULT 0, [JUN][FLOAT] Not NULL DEFAULT 0, " _
            & "[JUL][FLOAT] Not NULL DEFAULT 0, [AUG][FLOAT] Not NULL DEFAULT 0, [SEP][FLOAT] Not NULL DEFAULT 0, " _
            & "[OCT][FLOAT] Not NULL DEFAULT 0, [NOV][FLOAT] Not NULL DEFAULT 0, [DEC][FLOAT] Not NULL DEFAULT 0, " _
            & "[FINYEAR][INT] Not NULL DEFAULT 0)"
        Dim objCommand As New Data.OleDb.OleDbCommand(strCreate, cnn)
        objCommand.ExecuteNonQuery()

        Dim strSql As String = "SELECT BM_Master.PolicyNumber AS [Stand #], " _
            & "BM_Master.LastName +' '+ BM_Master.FirstName +' '+ BM_Master.OtherNames AS [Member Names], " _
            & "IsNull(BM_Payments_History.JAN, 0), IsNull(BM_Payments_History.FEB, 0), IsNull(BM_Payments_History.MAR, 0), IsNull(BM_Payments_History.APR, 0), " _
            & "IsNull(BM_Payments_History.MAY, 0), IsNull(BM_Payments_History.Jun, 0), IsNull(BM_Payments_History.Jul, 0), IsNull(BM_Payments_History.Aug, 0), " _
            & "IsNull(BM_Payments_History.Sep, 0), IsNull(BM_Payments_History.Oct, 0), IsNull(BM_Payments_History.Nov, 0), IsNull(BM_Payments_History.Dec, 0) " _
            & "FROM BM_Master LEFT OUTER JOIN BM_Payments_History ON BM_Master.PolicyNumber = BM_Payments_History.PolicyNumber " _
            & "WHERE BM_Payments_History.FinYear = " & nYear & " ORDER BY BM_Master.LastName, BM_Master.FirstName, " _
            & "BM_Master.OtherNames"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridPayments.Rows.Clear()

        'If objReader.HasRows = True Then
        While objReader.Read
            dGridPayments.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4),
                objReader(5), objReader(6), objReader(7), objReader(8), objReader(9),
                objReader(10), objReader(11), objReader(12), objReader(13))
        End While
        objReader.Close()

        'Else
        '    strSql = "SELECT BM_Master.PolicyNumber AS [Stand #], " _
        '        & "BM_Master.LastName +' '+ BM_Master.FirstName +' '+ BM_Master.OtherNames AS [Member Names], " _
        '        & "IsNull(BM_Payments_History.JAN, 0), IsNull(BM_Payments_History.FEB, 0), IsNull(BM_Payments_History.MAR, 0), IsNull(BM_Payments_History.APR, 0), " _
        '        & "IsNull(BM_Payments_History.MAY, 0), IsNull(BM_Payments_History.JUN, 0), IsNull(BM_Payments_History.Jul, 0), IsNull(BM_Payments_History.Aug, 0), " _
        '        & "IsNull(BM_Payments_History.Sep, 0), IsNull(BM_Payments_History.Oct, 0), IsNull(BM_Payments_History.Nov, 0), IsNull(BM_Payments_History.Dec, 0) " _
        '        & "FROM BM_Master LEFT OUTER JOIN BM_Payments_History ON BM_Master.PolicyNumber = BM_Payments_History.PolicyNumber " _
        '        & "ORDER BY BM_Master.LastName, BM_Master.FirstName, BM_Master.OtherNames"
        '    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        '    objReader = objCommand.ExecuteReader
        '    While objReader.Read
        '        dGridPayments.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4),
        '                              objReader(5), objReader(6), objReader(7), objReader(8), objReader(9),
        '                              objReader(10), objReader(11), objReader(12), objReader(13))
        '    End While
        '    objReader.Close()
        'End If

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Historical Payments Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefreshPaymentHistory_Click(sender As Object, e As EventArgs) Handles btnRefreshPaymentHistory.Click
        If Not String.IsNullOrEmpty(cboHistoryYear.Text) Then
            LaodHistoricalPayments(CInt(cboHistoryYear.Text))
        Else
            MessageBox.Show("Please select the year from the drop down list", "No year defined", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnSaveHistory_Click(sender As Object, e As EventArgs) Handles btnSaveHistory.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(cboHistoryYear.Text) Then
            MessageBox.Show("Please select the year from the drop down list", "No year defined", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        Dim objCommand As Data.OleDb.OleDbCommand
        With dGridPayments
            For p As Integer = 0 To .Rows.Count - 1
                Dim strKey As String = Nothing
                If Not Object.Equals(.Rows(p).Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(0).Value.ToString) Then
                        strKey = .Rows(p).Cells(0).Value.ToString
                        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM BM_Payments_History " _
                            & "WHERE FinYear = " & CInt(cboHistoryYear.Text) & " AND PolicyNumber = '" & strKey & "'", cnn)
                        objCommand.ExecuteNonQuery()

                        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO BM_Payments_History " _
                            & "(PolicyNumber, FinYear) VALUES ('" & strKey & "', " & CInt(cboHistoryYear.Text) & ")", cnn)
                        objCommand.ExecuteNonQuery()

                        For j As Integer = 2 To .Columns.Count - 2
                            Dim strMonth As String = Nothing
                            Select Case j
                                Case = 2
                                    strMonth = "Jan"
                                Case = 3
                                    strMonth = "Feb"
                                Case = 4
                                    strMonth = "Mar"
                                Case = 5
                                    strMonth = "Apr"
                                Case = 6
                                    strMonth = "May"
                                Case = 7
                                    strMonth = "Jun"
                                Case = 8
                                    strMonth = "Jul"
                                Case = 9
                                    strMonth = "Aug"
                                Case = 10
                                    strMonth = "Sep"
                                Case = 11
                                    strMonth = "Oct"
                                Case = 12
                                    strMonth = "Nov"
                                Case = 13
                                    strMonth = "Dec"
                            End Select
                            Dim dblValue As Double = 0
                            If Not Object.Equals(.Rows(p).Cells(j).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(p).Cells(j).Value.ToString) Then
                                    If IsNumeric(.Rows(p).Cells(j).Value.ToString) Then
                                        dblValue = CDbl(.Rows(p).Cells(j).Value.ToString)
                                    End If
                                End If
                            End If
                            If Not String.IsNullOrEmpty(strMonth) Then
                                objCommand = New Data.OleDb.OleDbCommand("UPDATE BM_Payments_History " _
                                & "SET " & strMonth & " = " & dblValue & " WHERE " _
                                & "FinYear = " & CInt(cboHistoryYear.Text) & " And PolicyNumber = '" & strKey & "'", cnn)
                                objCommand.ExecuteNonQuery()
                            End If
                        Next
                    End If
                End If

            Next
        End With
        Cursor = Cursors.Default
        MessageBox.Show("Transactions have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Historical Payments Load"
        ShowErrorMessage()
    End Sub

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGridPayments_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridPayments.CellEndEdit
        If e.ColumnIndex >= 2 Then
            If IsNumeric(dGridPayments.CurrentCell.Value) Then
                dGridPayments.CurrentCell.Value = Format(CDbl(dGridPayments.CurrentCell.Value), "##0.00")
            Else
                dGridPayments.CurrentCell.Value = "0.00"
            End If
        End If
    End Sub

    Private Sub dGridPayments_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridPayments.EditingControlShowing
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

    Private Sub btnUpdatePaymentsHistory_Click(sender As Object, e As EventArgs) Handles btnUpdatePaymentsHistory.Click
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing

        Dim intCount As Integer = 0
        strSql = "SELECT Count(PolicyNumber) FROM BM_Payments_History"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intCount = CInt(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        With Me.ProgressBarItem1
            .Value = 0
            .Visible = True
            .Maximum = intCount + 10
        End With

        strSql = "SELECT PolicyNumber, FinYear, Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec " _
            & "FROM BM_Payments_History ORDER BY FinYear, PolicyNumber "
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            strSelectedAccount = objReader(0).ToString
            Dim intYear As Integer = CInt(objReader(1).ToString)
            For j As Integer = 2 To 13
                Dim intMonth As Integer = j - 1
                Dim strPeriodDate As String = gwt_comm.LastDateofMonth(intMonth, intYear)
                Dim strReferenceNumber As String = "REC" & CStr(gwt_comm.GetNextDocumentNumber("CashSales"))
                strSql = "INSERT INTO BM_Financials (PolicyNumber, CapitalPayment, AdminFees, PeriodMonth, " _
                            & "PeriodYear, Reference, TransactionDate, UserName, Description, InterestsPaid) VALUES " _
                            & "('" & strSelectedAccount & "', " & CDbl(objReader(j).ToString) & ", 0, " _
                            & "" & intMonth & ", " & intYear & ", '" & strReferenceNumber & "', " _
                            & "'" & strPeriodDate & "', '" & strUserName & "', 'MONTHLY PAYMENTS', 0)"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                'Update the refenece number 
                objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET CashSales = CashSales + 1", cnn)
                objCommand.ExecuteNonQuery()
            Next
            Me.ProgressBarItem1.Value = Me.ProgressBarItem1.Value + 1
        End While
        objReader.Close()

        Me.ProgressBarItem1.Value = Me.ProgressBarItem1.Maximum
        Cursor = Cursors.Default

        MessageBox.Show("Payment transactions have been updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On financial transactions updates from history entries"
        ShowErrorMessage()
    End Sub

    Private Sub btnBillMember_Click(sender As Object, e As EventArgs) Handles btnBillMember.Click

    End Sub

    Private Sub UpdateBilling()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing

        Dim intCount As Integer = 0
        strSql = "SELECT Count(PolicyNumber) FROM BM_Payments_History"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intCount = CInt(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        With Me.ProgressBarItem1
            .Value = 0
            .Visible = True
            .Maximum = intCount + 10
        End With

        strSql = "SELECT PolicyNumber, FinYear, Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec " _
            & "FROM BM_Payments_History WHERE FinYear > 2013 ORDER BY FinYear, PolicyNumber "
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        While objReader.Read
            strSelectedAccount = objReader(0).ToString
            Dim intYear As Integer = CInt(objReader(1).ToString)
            For j As Integer = 2 To 13
                Dim intMonth As Integer = j - 1
                Dim strPeriodDate As String = gwt_comm.FirstDateofMonth(intMonth, intYear)
                Dim strReferenceNumber As String = "INV" & CStr(gwt_comm.GetNextDocumentNumber("Invoices"))

                Dim dblInterestCharge As Double = 0
                Dim strDescription As String = "MONTHLY BILLING"

                strSql = "INSERT INTO BM_Financials (PolicyNumber, Amount, PeriodMonth, " _
                    & "PeriodYear, Reference, TransactionDate, UserName, Description, InterestsCharged) VALUES " _
                    & "('" & objReader(0).ToString & "', 45.00, " _
                    & "" & intMonth & ", " & intYear & ", '" & strReferenceNumber & "', " _
                    & "'" & strPeriodDate & "', '" & strUserName & "', '" & strDescription & "', " & dblInterestCharge & ")"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                'Update the refenece number 
                objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET Invoices = Invoices + 1", cnn)
                objCommand.ExecuteNonQuery()
            Next
            Me.ProgressBarItem1.Value = Me.ProgressBarItem1.Value + 1
        End While
        objReader.Close()

        Dim arrDelete As New ArrayList
        With arrDelete
            .Add("01-JAN-2014")
            .Add("01-FEB-2014")
            .Add("01-MAR-2014")
            .Add("01-APR-2014")
        End With

        For p As Integer = 0 To arrDelete.Count - 1
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM BM_Financials WHERE " _
                & "TransactionDate = '" & arrDelete.Item(p) & "' AND Description = 'MONTHLY BILLING'", cnn)
            objCommand.ExecuteNonQuery()
        Next

        Me.ProgressBarItem1.Value = Me.ProgressBarItem1.Maximum
        Cursor = Cursors.Default

        MessageBox.Show("Payment transactions have been updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On financial transactions updates from history entries"
        ShowErrorMessage()
    End Sub

    Private Sub btnUpdateBilling_Click(sender As Object, e As EventArgs) Handles btnUpdateBilling.Click
        UpdateBilling()
    End Sub

    Private Sub btnTakeOnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnTakeOnUpdate.Click
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing
        strSql = "SELECT COUNT(PolicyNumber) FROM BM_Master"
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        Dim intCount As Integer = 0
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows = True Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intCount = CInt(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        strSql = "SELECT PolicyNumber, InceptionDate, Capital FROM BM_Master Order BY PolicyNumber"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        With ProgressBarItem1
            .Visible = True
            .Value = 0
            .Maximum = intCount + 10
        End With

        While objReader.Read
            Dim intMonth As Integer = 1
            Dim intYear As Integer = DatePart(DateInterval.Year, Now)

            If IsDate(objReader(1).ToString) Then
                intMonth = DatePart(DateInterval.Month, CDate(objReader(1).ToString))
                intYear = DatePart(DateInterval.Year, CDate(objReader(1).ToString))
            End If
            Dim strReference As String = Nothing

            strSql = "INSERT INTO BM_Financials (PolicyNumber, Amount, PeriodMonth, PeriodYear, Reference, " _
                & "TransactionDate, UserName, Description, CapitalPayment, AdminFees, InterestsCharged, InterestsPaid) VALUES " _
                & "('" & objReader(0).ToString & "', 5400, " & intMonth & ", " & intYear & ", " _
                & "'" & strReference & "', '" & objReader(1).ToString & "', '" & strUserName & "', 'PROPERT VALUES POSTING', " _
                & "0, 0, 0, 0)"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            ProgressBarItem1.Value = ProgressBarItem1.Value + 1
        End While
        objReader.Close()

        ProgressBarItem1.Value = ProgressBarItem1.Maximum

        Cursor = Cursors.Default

        MessageBox.Show("Take-on balance have been updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On financial transactions take-on updates"
        ShowErrorMessage()
    End Sub

End Class