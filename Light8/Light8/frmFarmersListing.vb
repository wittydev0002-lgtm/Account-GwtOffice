Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmFarmersListing

    Private Sub btnNewCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnNewCustomer.Click
        boolEditStatus = False
        Dim frm As New frmFarmersData
        frm.ShowDialog()
        LoadCustomerData("ALL")
    End Sub

    Private Sub btnEditCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnEditCustomer.Click
        EditCustomerDetails()
    End Sub

    Private Sub EditCustomerDetails()
        GetSelectedCustomer()
        boolEditStatus = True
        boolAbort = False
        Dim f As New frmFarmersData
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        LoadCustomerData("ALL")
    End Sub


    Private Sub LoadCustomerData(Optional ByVal SearchFor As String = "ALL")
        On Error GoTo RaiseErr
        'dGrid.Rows.Clear()
        Dim strSql As String = Nothing

        'Select Case UCase(SearchFor)
        '    Case = "ALL"

        'End Select
        If UCase(SearchFor) = "ALL" Then
            strSql = "SELECT GrowerNumber AS [Account No.], LastName as [Last Name], " _
                & "FirstName as [First Name], OtherNames AS [Other Names], " _
                & "Province AS [Province], District as [District], [Chairman], [FieldOfficer] AS [Officer], Status FROM " _
                & "FarmersData  ORDER BY LastName, FirstName, OtherNames"
        Else
            Select Case UCase(cboCustomerSearchBy.Text)
                Case Is = UCase("Last Name")
                    strSql = "SELECT GrowerNumber AS [Account No.], LastName as [Last Name], " _
                        & "FirstName as [First Name], OtherNames AS [Other Names], " _
                        & "Province AS [Province], District as [District], [Chairman], [FieldOfficer] AS [Officer], Status FROM " _
                        & "FarmersData WHERE LastName LIKE '%" & txtSearchString.Text & "%' ORDER BY LastName, FirstName, OtherNames"
                Case Is = UCase("First Name")
                    strSql = "SELECT GrowerNumber AS [Account No.], LastName as [Last Name], " _
                        & "FirstName as [First Name], OtherNames AS [Other Names], " _
                        & "Province AS [Province], District as [District], [Chairman], [FieldOfficer] AS [Officer], Status FROM " _
                        & "FarmersData WHERE FirstName LIKE '%" & txtSearchString.Text & "%' ORDER BY FirstName, LastName, OtherNames"
                Case Is = UCase("Province")
                    strSql = "SELECT GrowerNumber AS [Account No.], LastName as [Last Name], " _
                        & "FirstName as [First Name], OtherNames AS [Other Names], " _
                        & "Province AS [Province], District as [District], [Chairman], [FieldOfficer] AS [Officer], Status FROM " _
                        & "FarmersData WHERE Province LIKE '%" & txtSearchString.Text & "%' ORDER BY LastName, FirstName, OtherNames"
                Case Is = UCase("District")
                    strSql = "SELECT GrowerNumber AS [Account No.], LastName as [Last Name], " _
                        & "FirstName as [First Name], OtherNames AS [Other Names], " _
                        & "Province AS [Province], District as [District], [Chairman], [FieldOfficer] AS [Officer], Status FROM " _
                        & "FarmersData WHERE District LIKE '%" & txtSearchString.Text & "%' ORDER BY LastName, FirstName, OtherNames"
                Case Is = UCase("Chairman")
                    strSql = "SELECT GrowerNumber AS [Account No.], LastName as [Last Name], " _
                        & "FirstName as [First Name], OtherNames AS [Other Names], " _
                        & "Province AS [Province], District as [District], [Chairman], [FieldOfficer] AS [Officer], Status FROM " _
                        & "FarmersData WHERE Chairman LIKE '%" & txtSearchString.Text & "%' ORDER BY LastName, FirstName, OtherNames"
                Case Is = UCase("Field Officer")
                    strSql = "SELECT GrowerNumber AS [Account No.], LastName as [Last Name], " _
                        & "FirstName as [First Name], OtherNames AS [Other Names], " _
                        & "Province AS [Province], District as [District], [Chairman], [FieldOfficer] AS [Officer], Status FROM " _
                        & "FarmersData WHERE FieldOfficer LIKE '%" & txtSearchString.Text & "%' ORDER BY LastName, FirstName, OtherNames"
            End Select
        End If

        dGridCustomers.Columns.Clear()
        Me.dGridCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridCustomers.DataSource = dTable
        For p As Integer = 0 To dGridCustomers.Columns.Count - 1
            dGridCustomers.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            'If p = 4 Then
            '    dGridCustomers.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            '    'dGridCustomers.Columns(p).Visible = False
            'Else
            '    dGridCustomers.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'End If
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Farmer Summary Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetSelectedCustomer()
        If dGridCustomers.Rows.Count > 0 Then
            strSelectedAccount = dGridCustomers.CurrentRow.Cells(0).Value.ToString
            strSelectedAccountName = dGridCustomers.CurrentRow.Cells(1).Value.ToString
        End If
    End Sub

    Private Sub btnDeleteCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteCustomer.Click
        DeleteCustomer()
    End Sub

    Private Sub DeleteCustomer()
        If IntPublicCustomers = 1 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        GetSelectedCustomer()
        If MessageBox.Show("Are you sure you want to delete this reord? Deleting " & vbCrLf & "farmers may have adverse effect to your financial records", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM FarmersData WHERE GrowerNumber = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()

            MessageBox.Show("Farmer record deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadCustomerData("ALL")
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Farmer Listing Search"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGridCustomers_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridCustomers.DoubleClick
        EditCustomerDetails()
    End Sub

    Private Sub btnRefreshCustomers_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshCustomers.Click
        LoadCustomerData("ALL")
    End Sub

    Private Sub btnPrintListing_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintListing.Click
        PrintDefaultAlphaListing("General")
    End Sub

    Private Sub PrintDefaultAlphaListing(ByVal Grouping As String)
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim arrPrintData As New ArrayList

        Dim strSql As String = Nothing

        Dim strOrderBy As String = Nothing

        Select Case UCase(Grouping)
            Case Is = UCase("General")
                strOrderBy = "LastName, FirstName, OtherNames, Province, District, FieldOfficer"
            Case Is = UCase("Province")
                strOrderBy = "Province, LastName, FirstName, OtherNames, District"
            Case Is = UCase("District")
                strOrderBy = "District, LastName, FirstName, OtherNames, Province"
            Case Is = UCase("Agent")
                strOrderBy = "FieldOfficer, LastName, FirstName, OtherNames, Province, District"
            Case Else
                strOrderBy = "LastName, FirstName, OtherNames, Province, District, FieldOfficer"
        End Select

        strSql = "SELECT GrowerNumber AS [Account No.], RTRIM(LTRIM(LastName +' '+ FirstName +' '+ OtherNames)) AS [Farmer Details], " _
            & "Province AS [Province], District as [District], FieldOfficer AS [Agent], Status FROM " _
            & "FarmersData  ORDER BY " & strOrderBy

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            arrPrintData.Add(UCase(objReader(0).ToString) & ";" & UCase(objReader(1).ToString) & ";" & _
                UCase(objReader(2).ToString) & ";" & UCase(objReader(3).ToString) & ";" & _
                UCase(objReader(4).ToString))
        End While

        'Send the information to the printer

        Dim strPrintDetails(0 To arrPrintData.Count - 1) As String
        For i As Integer = 0 To arrPrintData.Count - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next

        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter

        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 5
            .strColumnHeaders = "GROWER #|FARMER DETAILS|PROVINCE|DISTRICT|AGENT"
            .strColumnAlignments = "0|0|0|0|0"
            .strColumnWidths = "65|190|170|120|100"
            .strFooterCaption = "Farmers Listing"
            .strMainCaption = UCase(strCompanyName) & " " & UCase(strUserBranch)
            .strMainHeader2 = "CONTRACT FARMERS LISTING BY " & UCase(Grouping)
            '.strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|NO"
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
            Select Case UCase(Grouping)
                Case Is = UCase("General")
                    .intBreakIndex = 0
                    .boolGroupDetails = False
                    .strSummaryTotals = "NO|NO|NO|NO|NO"
                Case Is = UCase("District")
                    .boolGroupDetails = True
                    .intBreakIndex = 3
                    .intKeyFieldIndex = 3
                    .strSummaryTotals = "NO|NO|NO|NO|NO"
                Case Is = UCase("Province")
                    .boolGroupDetails = True
                    .intBreakIndex = 2
                    .intKeyFieldIndex = 2
                    .strSummaryTotals = "NO|NO|NO|NO|NO"
                Case Is = UCase("Agent")
                    .boolGroupDetails = True
                    .intBreakIndex = 4
                    .intKeyFieldIndex = 4
                    .strSummaryTotals = "NO|NO|NO|NO|NO"
            End Select
            .boolPrintTotals = True

            '.AlternateBackColor = Color.LightGray
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO"
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On report printing"
        ShowErrorMessage()
    End Sub

    Private Sub btnAdvanceLoann_Click(sender As System.Object, e As System.EventArgs) Handles btnAdvanceLoann.Click
        Dim frm As New frmFarmersAdvancement
        frm.ShowDialog()
    End Sub

    Private Sub btnLoanRepay_Click(sender As System.Object, e As System.EventArgs) Handles btnLoanRepay.Click
        Dim frm As New frmFarmersLoanRepayment
        frm.ShowDialog()
    End Sub

    Private Sub btnInvoices_Click(sender As System.Object, e As System.EventArgs) Handles btnInvoices.Click
        Dim frm As New frmFarmerInvoice
        frm.ShowDialog()
    End Sub

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click

        On Error GoTo RaiseErr

        Dim strFileName As String = Nothing
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        strFileName = ofd.FileName

        If Not String.IsNullOrEmpty(strFileName) Then
            If System.IO.File.Exists(strFileName) Then
                Dim objFile As New System.IO.StreamReader(strFileName)
                Dim strData As String = objFile.ReadToEnd
                objFile.Close()

                If Not String.IsNullOrEmpty(strData) Then
                    Dim strLines() As String = Split(strData, vbCrLf)

                    With frmLight8.pb1
                        .Value = 0
                        .Maximum = strLines.Length + 10
                        .Visible = True
                    End With

                    For p As Integer = 0 To strLines.Length - 1
                        If Not String.IsNullOrEmpty(strLines(p)) Then

                            Dim strFields() As String = Split(strLines(p), "|")

                            Dim strContractor As String = Nothing
                            Dim strGrowerNumber As String = Nothing
                            Dim strFirstName As String = Nothing
                            Dim strLastName As String = Nothing
                            Dim strIdNumber As String = Nothing
                            Dim intCurrentRegistrationYear As Integer = 0
                            Dim intNextRegistrationYear As Integer = 0
                            Dim strProvince As String = Nothing
                            Dim strDistrict As String = Nothing
                            Dim strAgent As String = Nothing

                            If Not String.IsNullOrEmpty(strFields(0).ToString) Then strContractor = Trim(strFields(0))
                            If Not String.IsNullOrEmpty(strFields(1).ToString) Then strGrowerNumber = Trim(strFields(1))
                            If Not String.IsNullOrEmpty(strFields(2).ToString) Then strFirstName = Trim(strFields(2))
                            If Not String.IsNullOrEmpty(strFields(3).ToString) Then strLastName = Trim(strFields(3))
                            If Not String.IsNullOrEmpty(strFields(4).ToString) Then strIdNumber = Trim(strFields(4))
                            If IsNumeric(strFields(5).ToString) Then intCurrentRegistrationYear = CInt(Trim(strFields(5)))
                            If IsNumeric(strFields(6).ToString) Then intNextRegistrationYear = CInt(Trim(strFields(6)))
                            If Not String.IsNullOrEmpty(strFields(7).ToString) Then strProvince = Trim(strFields(7))
                            If Not String.IsNullOrEmpty(strFields(8).ToString) Then strDistrict = Trim(strFields(8))
                            If Not String.IsNullOrEmpty(strFields(9).ToString) Then strAgent = Trim(strFields(9))

                            If gwt_comm.RecordExists("GrowerNumber", "FarmersData", Trim(strGrowerNumber), "string") = False Then
                                Dim strSql As String = "INSERT INTO FarmersData (Contractor, GrowerNumber, FirstName, LastName, " _
                                    & "IdNumber, CurrentRegStatusYear, NextRegStatusYear, Province, District, FieldOfficer) VALUES " _
                                    & "('" & strContractor & "', '" & strGrowerNumber & "', '" & strFirstName & "', " _
                                    & "'" & strLastName & "', '" & strIdNumber & "', " & intCurrentRegistrationYear & ", " _
                                    & "" & intNextRegistrationYear & ", '" & strProvince & "', '" & strDistrict & "', '" & strAgent & "')"
                                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                                objCommand.ExecuteNonQuery()
                            Else
                                Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\FarmersImportERR.txt", True)
                                objFileWriter.WriteLine(strLines(p) & ":GROWER ACCOUNT ALREADY EXISTS:" & UCase(Now))
                                objFileWriter.Close()
                            End If
                        End If
                        frmLight8.pb1.Value = frmLight8.pb1.Value + 1
                    Next

                    frmLight8.pb1.Value = frmLight8.pb1.Maximum

                    Cursor = Cursors.Default

                    MessageBox.Show("Contract Farmers data has been imported successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadCustomerData("ALL")

                End If
            Else
                MessageBox.Show("The selected file does not exist", "Non Existant File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Contract Farmers Data Import"
        ShowErrorMessage()
    End Sub

    Private Sub btnPrintByOfficer_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintByOfficer.Click
        PrintDefaultAlphaListing("Agent")
    End Sub

    Private Sub btnByProvince_Click(sender As System.Object, e As System.EventArgs) Handles btnByProvince.Click
        PrintDefaultAlphaListing("Province")
    End Sub

    Private Sub btnByDistrict_Click(sender As System.Object, e As System.EventArgs) Handles btnByDistrict.Click
        PrintDefaultAlphaListing("District")
    End Sub

    Private Sub btnFind_Click(sender As System.Object, e As System.EventArgs) Handles btnFind.Click
        LoadCustomerData(cboCustomerSearchBy.Text)
    End Sub

    Private Sub txtSearchString_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearchString.KeyDown
        If e.KeyValue = Keys.Enter Then
            LoadCustomerData(cboCustomerSearchBy.Text)
        End If
    End Sub

    Private Sub cboCustomerSearchBy_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCustomerSearchBy.SelectedIndexChanged
        LoadCustomerData(cboCustomerSearchBy.Text)
    End Sub

    Private Sub LoadByFilter(ByVal FilterName As String)

        On Error GoTo RaiseErr
        Dim strSql As String = Nothing

        Select Case UCase(FilterName)
            Case Is = UCase("Province")
                strSql = "SELECT GrowerNumber AS [Account No.], LastName as [Last Name], " _
                    & "FirstName as [First Name], OtherNames AS [Other Names], " _
                    & "Province AS [Province], District as [District], [Chairman], [FieldOfficer] AS [Officer], Status FROM " _
                    & "FarmersData ORDER BY Province, LastName, FirstName, OtherNames"
            Case Is = UCase("District")
                strSql = "SELECT GrowerNumber AS [Account No.], LastName as [Last Name], " _
                    & "FirstName as [First Name], OtherNames AS [Other Names], " _
                    & "Province AS [Province], District as [District], [Chairman], [FieldOfficer] AS [Officer], Status FROM " _
                    & "FarmersData ORDER BY District, LastName, FirstName, OtherNames"
            Case Is = UCase("Chairman")
                strSql = "SELECT GrowerNumber AS [Account No.], LastName as [Last Name], " _
                    & "FirstName as [First Name], OtherNames AS [Other Names], " _
                    & "Province AS [Province], District as [District], [Chairman], [FieldOfficer] AS [Officer] FROM " _
                    & "FarmersData ORDER BY Chairman, LastName, FirstName, OtherNames"
            Case Is = UCase("Field Officer")
                strSql = "SELECT GrowerNumber AS [Account No.], LastName as [Last Name], " _
                            & "FirstName as [First Name], OtherNames AS [Other Names], " _
                            & "Province AS [Province], District as [District], [Chairman], [FieldOfficer] AS [Officer], FROM " _
                            & "Status FarmersData ORDER BY FieldOfficer, LastName, FirstName, OtherNames"
            Case Else

        End Select

        If String.IsNullOrEmpty(strSql) Then Exit Sub

        dGridCustomers.Columns.Clear()
        Me.dGridCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridCustomers.DataSource = dTable
        For p As Integer = 0 To dGridCustomers.Columns.Count - 1
            dGridCustomers.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            'If p = 4 Then
            '    dGridCustomers.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            '    'dGridCustomers.Columns(p).Visible = False
            'Else
            '    dGridCustomers.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'End If
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Farmer Summary Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnDeregister_Click(sender As System.Object, e As System.EventArgs) Handles btnDeregister.Click
        If IntPublicCustomers = 1 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        GetSelectedCustomer()

        boolAbort = False
        Dim frm As New frmDecontractReason
        frm.showdialog()
        If boolAbort = True Then Exit Sub

        If MessageBox.Show("Are you sure you want to de-register this farmer? De-registering " & vbCrLf & "farmers may have adverse effect to your financial records", "Confirm De-registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE FarmersData SET Status = 'INACTIVE', DecontractReason = '" & strDecontractingReason & "' WHERE GrowerNumber = '" & strSelectedAccount & "'", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Farmer de-registered successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadCustomerData("ALL")
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Farmer De-registration"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmFarmersListing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

End Class