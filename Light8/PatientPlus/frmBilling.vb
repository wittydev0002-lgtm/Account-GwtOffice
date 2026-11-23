Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBilling

    Dim dblBalanceBefore As Double = 0

    Dim dblPastPaymentAmount As Double = 0
    Dim strPastPaymentDate As String = Nothing
    Dim intLastRecordId As Integer = 1

    Dim dblAmountPayable As Double
    Dim boolPrintFromPreview As Boolean

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGrid.EditingControlShowing
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

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex >= 4 And e.ColumnIndex < 7 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
            If e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
                Dim dblQty As Double = 0
                Dim dblUnitPrice As Double = 0
                If IsNumeric(dGrid.CurrentRow.Cells(4).Value) Then
                    dblUnitPrice = CDbl(dGrid.CurrentRow.Cells(4).Value.ToString)
                End If
                If IsNumeric(dGrid.CurrentRow.Cells(5).Value) Then
                    dblQty = CDbl(dGrid.CurrentRow.Cells(5).Value.ToString)
                End If
                dGrid.Rows(dGrid.CurrentRow.Index).Cells(6).Value = Format((dblQty * dblUnitPrice), "##0.00")
            End If
            ComputeTotals()
        End If
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)

        If strCurrentKey = vbCr Then Exit Sub

        Dim strFind As String = txtSearchString.Text & strCurrentKey

        If strFind.Length <= 0 Then
            pnlMain.Height = txtSearchString.Height
            Exit Sub
        End If

        If strFind.Length > 0 Then
            If strFind.Length < intSearchCharactersFrom Then Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        With dGridItems
            .Columns.Clear()

            Dim strSql As String = Nothing

            If optConsultations.Checked = True Then
                If UCase(cboSearchOption.Text) = UCase("Code") Then
                    strSql = "SELECT Code AS [Code], Description AS [Description], CAST(Units AS DECIMAL(10,2)) AS [Units], " _
                        & "CAST(Value AS DECIMAL(10,2)) AS [Price] FROM OchmasSystemConsultations WHERE Code LIKE '" & strFind & "%' " _
                        & "ORDER BY Code"
                Else
                    strSql = "SELECT Code AS [Codes], Description AS [Description], CAST(Units AS DECIMAL(10,2)) AS [Units], " _
                        & "CAST(Value AS DECIMAL(10,2)) AS [Price] FROM OchmasSystemConsultations WHERE Description Like '%" & strFind & "%' " _
                        & "ORDER BY Description"
                End If
            End If
            If optDrugs.Checked = True Then
                If UCase(cboSearchOption.Text) = UCase("Code") Then
                    strSql = "SELECT ProductCode as [Drug Code], ProductName as [Product Name], GenericIndicator as [B/G], " _
                        & "CAST(SellPrice AS decimal(10,2)) AS [Price] FROM OchmasSystemMedicines " _
                        & "WHERE ProductCode LIKE '%" & strFind & "%' ORDER BY ProductCode"
                Else
                    strSql = "SELECT ProductCode as [Drug Code], ProductName as [Product Name], GenericIndicator as [B/G], " _
                        & "CAST(SellPrice AS decimal(10,2)) AS [Price] FROM OchmasSystemMedicines " _
                        & "WHERE ProductName LIKE '%" & strFind & "%' ORDER BY ProductName"
                End If
            End If
            If optExtraServices.Checked = True Then
                If UCase(lblPayMethod.Text) = UCase("MEDICAL AID") Then
                    strSql = "SELECT RIGHT(100000 + TransactionId, 5) as [Code], Description as [Description], Classification as [Cls], " _
                        & "CAST([UnitPriceMedaid] AS decimal(10,2)) AS [Price] FROM OchmasExtrasAndServices " _
                        & "WHERE Description LIKE '%" & strFind & "%' ORDER BY Description"
                Else
                    If UCase(lblPayMethod.Text) = UCase("CASH") Then
                        strSql = "SELECT RIGHT(100000 + TransactionId, 5) as [Code], Description as [Description], Classification as [Cls], " _
                            & "CAST([UnitPriceCash] AS decimal(10,2)) AS [Price] FROM OchmasExtrasAndServices " _
                            & "WHERE Description LIKE '%" & strFind & "%' ORDER BY Description"
                    Else
                        strSql = "SELECT RIGHT(100000 + TransactionId, 5) as [Code], Description as [Description], Classification as [Cls], " _
                            & "CAST([UnitPriceOther] AS decimal(10,2)) AS [Price] FROM OchmasExtrasAndServices " _
                            & "WHERE Description LIKE '%" & strFind & "%' ORDER BY Description"
                    End If
                End If
            End If

            Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New OleDb.OleDbDataAdapter(cmd)
            Dim dTable As New DataTable()
            da.Fill(dTable)
            .DataSource = dTable

            For p As Integer = 0 To .Columns.Count - 1
                If p = 1 Then
                    .Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Else
                    .Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next
            pnlMain.Height = 260
            'If .RowCount > 0 Then
            '    Dim intHeight As Integer = TotalRowsHeight() + 70
            '    If intHeight < 260 Then
            '        pnlMain.Height = intHeight
            '    Else
            '        pnlMain.Height = 260
            '    End If
            'Else
            '    pnlMain.Height = txtSearchString.Height
            'End If
        End With

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Data Filter Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Function TotalRowsHeight() As Integer
        Dim intReturn As Integer = 0
        For p As Integer = 0 To dGridItems.RowCount - 1
            intReturn = intReturn + dGridItems.Rows(p).Height
        Next
        Return intReturn
    End Function

    Private Sub txtSearchString_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearchString.KeyDown
        If e.KeyValue = Keys.Down Then
            If Not String.IsNullOrEmpty(txtSearchString.Text) Then
                dGridItems.Focus()
                dGridItems.SelectedRows(0).Selected = True
            Else
                SearchForItem("")
                dGridItems.Focus()
                If dGridItems.RowCount > 0 Then dGridItems.SelectedRows(0).Selected = True
            End If
        End If
        If e.KeyValue = Keys.Enter Then
            If dGridItems.Rows.Count > 0 Then
                pnlMain.Height = txtSearchString.Height
                dGridItems.Rows(0).Selected = True
                AssignSelected()
                txtSearchString.Clear()
                txtSearchString.Select()
                dGridItems.DataSource = Nothing
                dGridItems.Rows.Clear()

            End If
        End If
    End Sub

    Private Sub dGridItems_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridItems.KeyDown
        If e.KeyValue = Keys.Enter Or e.KeyValue = 9 Then
            e.SuppressKeyPress = True
            If dGridItems.Rows.Count > 0 Then
                AssignSelected()
                txtSearchString.Clear()
                pnlMain.Height = txtSearchString.Height
                txtSearchString.Select()
                dGridItems.DataSource = Nothing
                dGridItems.Rows.Clear()
            End If
        End If
    End Sub

    Private Sub txtSearchString_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchString.TextChanged
        If String.IsNullOrEmpty(txtSearchString.Text) Then Exit Sub
        SearchForItem("")
    End Sub

    Private Sub AssignSelected()

        With dGridItems

            Dim strCode As String = Nothing
            Dim strDescription As String = Nothing
            Dim strExtraInfo As String = Nothing
            Dim dblQty As Double = 1
            Dim dblAmount As Double = 0
            Dim strType As String = Nothing

            If optConsultations.Checked Then strType = "CONSULTATION"
            If optDrugs.Checked Then strType = "DRUG"
            If optExtraServices.Checked Then strType = "EXTRA"

            If Not Object.Equals(.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(0).Value.ToString) Then
                    strCode = .CurrentRow.Cells(0).Value.ToString
                End If
            End If

            If Not Object.Equals(.CurrentRow.Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(1).Value.ToString) Then
                    strDescription = .CurrentRow.Cells(1).Value.ToString
                End If
            End If

            If Not Object.Equals(.CurrentRow.Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(2).Value.ToString) Then
                    strExtraInfo = .CurrentRow.Cells(2).Value.ToString
                End If
            End If

            If Not Object.Equals(.CurrentRow.Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(3).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(3).Value.ToString) Then
                        dblAmount = CDbl(.CurrentRow.Cells(3).Value.ToString)
                    End If
                End If
            End If

            dGrid.Rows.Add(UCase(gwt_comm.shortMonthDateFormat(dtSetDate)), strCode, strDescription,
                strExtraInfo, Format(dblAmount, "##0.00"), dblQty, Format((dblAmount * dblQty), "##0.00"), strType, "C")
            ComputeTotals()

        End With

        pnlMain.Height = txtSearchString.Height

        'If optConsultations.Checked = True Then optExtraServices.Checked = True

    End Sub

    Private Sub frmBilling_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        On Error GoTo RaiseErr

        dtSetDate = Now

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        If gwt_comm.CheckColumnExistence("OchmasBillingMain", "InvoiceStatus") = False Then
            strSql = "ALTER TABLE OchmasBillingMain ADD [InvoiceStatus][NVARCHAR](1) NOT NULL DEFAULT 'N'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If gwt_comm.CheckColumnExistence("OchmasBillingMain", "InvoiceDate") = False Then
            strSql = "ALTER TABLE OchmasBillingMain ADD [InvoiceDate][SmallDateTime] NULL"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        optConsultations.Checked = True

        pnlMain.Height = txtSearchString.Height

        lblPatientId.Text = Nothing
        lblPatientId.Text = intSelectedPatient

        'Load the patinet details

        strSql = "SELECT LastName +' '+ FirstName +' '+ OtherNames AS [Given Names], BillingMethod " _
            & "FROM OchmasPatients WHERE PatientId = " & intSelectedPatient & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then lblPatientNames.Text = UCase(objReader(0).ToString)
            If Not IsDBNull(objReader(1).ToString) Then lblPayMethod.Text = UCase(objReader(1).ToString)
            If UCase(lblPayMethod.Text) = UCase("Medical Aid") Then
                'Get the medical aid scheme name
                Dim arrMedicalAidSchemeDetails As New ArrayList
                arrMedicalAidSchemeDetails = MedicalAidSchemeDetails(intSelectedPatient)
                lblBillTo.Text = arrMedicalAidSchemeDetails.Item(0)
                lblSchemeCode.Text = arrMedicalAidSchemeDetails.Item(1)
            Else
                lblBillTo.Text = "PATIENT"
                lblSchemeCode.Text = "000000"
            End If
        End If

        objReader.Close()

        'Get the date of the last consulatation
        lblLastVisitDate.Text = "00-000-0000"
        strSql = "SELECT  UPPER(REPLACE(CONVERT(CHAR(11), [TransDate], 106), ' ', '-')) as [DOB] FROM OchmasBillingMain " _
            & "WHERE PatientId = " & intSelectedPatient & " ORDER BY [TransDate] DESC"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then lblLastVisitDate.Text = objReader(0).ToString
        End If
        objReader.Close()

        boolAbort = False
        SponsorDetails(intSelectedPatient)
        If boolAbort = True Then Exit Sub
        LoadOpenBillings(intSelectedPatient)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Patient Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadOpenBillings(ByVal PatientId As Integer)
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()

        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), OchmasBillingMain.TransDate, 106), ' ', '-')) as [Date], " _
            & "OchmasBillingMain.DocumentNumber FROM OchmasBillingMain WHERE OchmasBillingMain.InvoiceStatus = 'N' " _
            & "AND OchmasBillingMain.PatientId = " & PatientId & " ORDER BY OchmasBillingMain.TransDate"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            strSql = "SELECT OchmasBillingDetails.ItemCode, OchmasBillingDetails.Description, OchmasBillingDetails.UnitPrice, " _
                & "OchmasBillingDetails.Quantity, (OchmasBillingDetails.UnitPrice * OchmasBillingDetails.Quantity) AS [Total], " _
                & "OchmasBillingDetails.ItemType, 'P' AS [Status] from OchmasBillingDetails " _
                & "WHERE OchmasBillingDetails.DocumentNumber = " & objReader(1).ToString & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReadDetails As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReadDetails.Read
                With dGrid
                    .Rows.Add(objReader(0), objReadDetails(0), objReadDetails(1), Nothing, objReadDetails(2),
                              objReadDetails(3), objReadDetails(4), objReadDetails(5))
                    'Lock all past details from editing and change the font color as well to blue
                    For j As Integer = 0 To dGrid.ColumnCount - 1
                        dGrid.Rows(dGrid.Rows.Count - 1).Cells(j).ReadOnly = True
                        dGrid.Rows(dGrid.Rows.Count - 1).Cells(j).Style.ForeColor = Color.Blue
                    Next
                End With
            End While
            objReadDetails.Close()
        End While
        objReader.Close()
        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Patient Open Bills Load"
        ShowErrorMessage()
    End Sub

    Private Function MedicalAidSchemeDetails(ByVal PatientId As Integer) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList
        Dim strSql As String = "SELECT Name, SchemeCode FROM OchmasSystemMedicalAids WHERE SchemeCode IN " _
            & "(SELECT SchemeNumber FROM OchmasMedaidMembership WHERE PatientId = " & PatientId & ")"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then arrReturn.Add(objReader(0).ToString) Else arrReturn.Add("")
            If Not IsDBNull(objReader(1).ToString) Then arrReturn.Add(objReader(1).ToString) Else arrReturn.Add("")
        End If
        objReader.Close()

        If arrReturn.Count <= 0 Then
            arrReturn.Add("")
            arrReturn.Add("")
        End If

        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Medical Aid Scheme Information Fetch"
        ShowErrorMessage()
    End Function

    Private Sub ComputeTotals()
        Dim dblAmount As Double = 0
        Dim dblPrevious As Double = 0

        With dGrid
            For p As Integer = 0 To dGrid.RowCount - 1
                Dim strPostStatus As String = Nothing
                If Not Object.Equals(.Rows(p).Cells(8).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(8).Value.ToString()) Then
                        strPostStatus = .Rows(p).Cells(8).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(6).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(6).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(6).Value.ToString) Then
                            If UCase(strPostStatus) = "C" Then
                                dblAmount = dblAmount + CDbl(.Rows(p).Cells(6).Value.ToString)
                            Else
                                dblPrevious = dblPrevious + CDbl(.Rows(p).Cells(6).Value.ToString)
                            End If
                        End If
                    End If
                End If
            Next
        End With

        lblPayable.Text = Format(dblAmount, "##0.00")
        lblPastBillings.Text = Format(dblPrevious, "##0.00")
        lblGrossTotal.Text = Format((dblAmount + dblPrevious), "##0.00")
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click

        boolPrintFromPreview = False

        If dGrid.RowCount <= 0 Then
            MessageBox.Show("No items were added to the bill", "Missing Billing Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        boolAbort = False

        strReceiptSpecialNotes = Nothing
        strSponsorNames = Nothing
        strSponsorAddress1 = Nothing
        strSponsorAddress2 = Nothing
        strSponsorAddress3 = Nothing
        strSponsorAddress4 = Nothing
        strSponsorTelephone = Nothing

        If MessageBox.Show("Do you want to add any special notes?", "Add Notes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim frm As New frmSpecialNotes
            frmSpecialNotes.ShowDialog()
            If boolAbort = True Then Exit Sub
        End If

        On Error GoTo RaiseErr

        dblCash = 0
        dblEcocash = 0
        dblSwipe = 0
        dblTransfer = 0
        dblOtherPaymentMethods = 0

        If UCase(lblBillTo.Text) = UCase("PATIENT") Then
            boolAbort = False
            dblBilledAmount = CDbl(lblPayable.Text)
            Dim f As New frmTenderPayment
            f.ShowDialog()
            If boolAbort = True Then Exit Sub
        End If

        intPayslipProcessingCount = 0
        itm = 0
        dblAmountPayable = 0

        'First add the main record

        Dim strReference As String = "BPID" & Format(CInt(lblPatientId.Text), "0000")
        Dim strBillTo As String = "PATIENT"
        If lblBillTo.Text <> "PATIENT" Then
            strBillTo = "MEDICAL AID"
        End If

        Dim strInvoiced As String = "N"
        If UCase(lblPayMethod.Text) = UCase("CASH") Then
            strInvoiced = "Y"
        End If

        Dim strSql As String = "INSERT INTO OchmasBillingMain ([TransDate], [PatientId], [SchemeCode], " _
            & "[Amount], [TransType], [Reference], [PayMode], [UserName], [ChangeDate], [Comments], [BillTo], " _
            & "[Cash], [Ecocash], [Swipe], [Transfer], [OtherMethods], [InvoiceStatus]) VALUES " _
            & "('" & gwt_comm.shortMonthDateFormat(dtSetDate) & "', " & lblPatientId.Text & ", '" & lblSchemeCode.Text & "', " _
            & "" & CDbl(lblPayable.Text) & ", 'BILLING', '" & strReference & "', '" & UCase(lblPayMethod.Text) & "', " _
            & "'" & strUserName & "', '" & Now & "', '', '" & strBillTo & "', " & dblCash & ", " & dblEcocash & ", " _
            & "" & dblSwipe & ", " & dblTransfer & ", " & dblOtherPaymentMethods & ", '" & strInvoiced & "')"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Get the last key used for the document number

        strSql = "SELECT IDENT_CURRENT('OchmasBillingMain')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intLastRecordId = CInt(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        lblCurrentDocNumber.Text = CStr(intLastRecordId)

        With dGrid

            For p As Integer = 0 To .RowCount - 1

                Dim strCode As String = Nothing
                Dim strDescription As String = Nothing
                Dim dblUnitPrice As Double = 0
                Dim dblQty As Double = 0
                Dim dblPayable As Double = 0
                Dim strType As String = Nothing
                Dim strPostStatus As String = Nothing

                If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(1).Value.ToString()) Then
                        strCode = .Rows(p).Cells(1).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(2).Value.ToString()) Then
                        strDescription = .Rows(p).Cells(2).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString()) Then
                        If IsNumeric(.Rows(p).Cells(4).Value.ToString) Then
                            dblUnitPrice = CDbl(.Rows(p).Cells(4).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(5).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(5).Value.ToString()) Then
                        If IsNumeric(.Rows(p).Cells(5).Value.ToString) Then
                            dblQty = CDbl(.Rows(p).Cells(5).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(6).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(6).Value.ToString()) Then
                        If IsNumeric(.Rows(p).Cells(6).Value.ToString) Then
                            dblPayable = CDbl(.Rows(p).Cells(6).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(7).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(7).Value.ToString()) Then
                        strType = .Rows(p).Cells(7).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(8).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(8).Value.ToString()) Then
                        strPostStatus = .Rows(p).Cells(8).Value.ToString
                    End If
                End If

                If UCase(strPostStatus) = "C" Then
                    'Insert the details
                    strSql = "INSERT INTO OchmasBillingDetails ([DocumentNumber], [ItemCode], " _
                        & "[Description], [Quantity], [UnitPrice], [ItemType]) VALUES (" & intLastRecordId & ", " _
                        & "'" & strCode & "', '" & strDescription & "', " & dblQty & ", " & dblUnitPrice & ", '" & strType & "')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If

            Next

        End With

        'Print the document receipt

        intPayslipProcessingCount = 0
        If MessageBox.Show("Do you want To print the receipt right now?", "Confirm Receipt Print",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            boolAbort = False
            Dim printSelect As New PrintDialog
            printSelect.ShowDialog()
            strSessionPrinter = printSelect.PrinterSettings.PrinterName
            If boolAbort = True Then Exit Sub

            boolDrawBorders = True
            pdSmartBilling.PrinterSettings.PrinterName = strSessionPrinter

            dblAmountPayable = 0
            itm = 0
            arrReceiptItems = New ArrayList
            arrReceiptItems = CreatePrintArray(CInt(lblCurrentDocNumber.Text))

            Dim documentPreview As New PrintPreviewDialog
            documentPreview.Document = pdSmartBilling
            documentPreview.ShowDialog()
        End If

        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On patient invoicing and receipt printing"
        ShowErrorMessage()
    End Sub

    Private Function MedicalAidNumber(ByVal PatientId As Integer) As String
        Dim strReturn As String = Nothing
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT MemberNumber FROM OchmasMedaidMembership WHERE PatientId = " & PatientId & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Patient Receipt Print Medical Aid Number Fetch"
        ShowErrorMessage()
    End Function

    Private Function PatientSuffix(ByVal PatientId As Integer) As String
        Dim strReturn As String = "00"
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DependentCode FROM OchmasPatients WHERE PatientId = " & PatientId & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If IsNumeric(objReader(0).ToString) Then
                    strReturn = Format(CDbl(objReader(0).ToString), "00")
                End If
            End If
            End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Patient Receipt Print Dependent Code Fetch"
        ShowErrorMessage()
    End Function

    Private Sub SponsorDetails(PatientId)

        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        strSponsorNames = Nothing
        strSponsorAddress1 = Nothing
        strSponsorAddress2 = Nothing
        strSponsorAddress3 = Nothing
        strSponsorAddress4 = Nothing
        strSponsorTelephone = Nothing

        If lblBillTo.Text = "PATIENT" Then
            'Get the arddress of the main member
            strSql = "SELECT OchmasPatients.LastName +' '+ OchmasPatients.FirstName +' '+ OchmasPatients.OtherNames as [Name], " _
                & "OchmasAddresses.Address1, OchmasAddresses.Address2, " _
                & "OchmasAddresses.Address3, OchmasAddresses.Address4, " _
                & "OchmasPatients.Telephone FROM OchmasPatients LEFT OUTER JOIN OchmasAddresses ON " _
                & "OchmasPatients.PatientId = OchmasAddresses.PatientId WHERE OchmasPatients.PatientId = " & PatientId & ""
        Else
            strSql = "SELECT Name, PostalAddress1, PostalAddress2, PostalAddress3, PostalAddress4, Telephone FROM OchmasSystemMedicalAids " _
                & "WHERE SchemeCode = '" & lblSchemeCode.Text & "'"
        End If

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strSponsorNames = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strSponsorAddress1 = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strSponsorAddress2 = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then strSponsorAddress3 = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then strSponsorAddress4 = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then strSponsorTelephone = objReader(5).ToString
        End If
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Sponsor Details Fetch"
        ShowErrorMessage()
    End Sub

    Private Sub pdSmartBilling_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pdSmartBilling.PrintPage

        If boolPrintFromPreview = True Then
            itm = 0
        End If

        Dim reccurrent As Rectangle

        Dim intX As Integer = 100
        Dim intY As Integer = 100
        Dim intY_height As Integer = 15

        With gwt_comm

            '
            '**************** Print company logo always at the far top left
            '
            If Not String.IsNullOrEmpty(strCompanyLogoPath) Then
                If System.IO.File.Exists(strCompanyLogoPath) Then
                    Dim picPrint As New PictureBox
                    picPrint.SizeMode = PictureBoxSizeMode.AutoSize
                    picPrint.Load(strCompanyLogoPath)
                    Dim R As New Rectangle(intLogoXposition, intLogoYposition, picPrint.Width, picPrint.Height)
                    e.Graphics.DrawImage(picPrint.Image, R)
                End If
            End If

            '
            '************** PRINT COMPANY NAME AND ADDRESS
            '
            .DrawStringInBoxLeft(e, 250, 40, 300, 25, strCompanyName, SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, 250, 52, 300, 25, strCompanyAddress1, FooterFont, Brushes.Black)
            .DrawStringInBoxLeft(e, 250, 64, 300, 25, strCompanyAddress2, FooterFont, Brushes.Black)
            .DrawStringInBoxLeft(e, 250, 76, 300, 25, strCompanyAddress3, FooterFont, Brushes.Black)
            .DrawStringInBoxLeft(e, 250, 88, 300, 25, strCompanyAddress4, FooterFont, Brushes.Black)
            .DrawStringInBoxLeft(e, 250, 100, 300, 25, strCompanyTelephone & " Email: " & strCompanyEmailAddress, FooterFont, Brushes.Black)

            'write out header
            If UCase(lblBillTo.Text) = UCase("PATIENT") Then
                .DrawStringInBoxRight(e, intX, intY, 600, 25, "Receipt", MainHeaderFont, Brushes.Black)
            Else
                .DrawStringInBoxRight(e, intX, intY, 600, 25, "Invoice", MainHeaderFont, Brushes.Black)
            End If

            intY = intY + 25

            'Draw grey box
            reccurrent = New Rectangle(intX, intY, 600, intY_height)
            e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)
            e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), reccurrent)

            'Fill key data and underline immediately

            intY = intY + reccurrent.Height + 5
            .DrawStringInBoxLeft(e, intX, intY, 80, 30, "Patient ID", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 85, intY, 10, 30, ":", DetailFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 95, intY, 250, 30, Format(CInt(lblPatientId.Text), "000000"), DetailFont, Brushes.Black)

            .DrawStringInBoxLeft(e, intX + 375, intY, 60, 30, "Date", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 440, intY, 10, 30, ":", DetailFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 455, intY, 140, 30, UCase(dtSetDate), DetailFont, Brushes.Black)
            '
            'Draw line under neith an repeat above 3 times
            '
            intY = intY + 15
            e.Graphics.DrawLine(Pens.LightGray, intX, intY, 700, intY)

            '**** SECOND LINE ITEMS 
            '
            intY = intY + 5

            .DrawStringInBoxLeft(e, intX, intY, 80, 30, "Patient Name", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 85, intY, 10, 30, ":", DetailFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 95, intY, 250, 30, UCase(lblPatientNames.Text), DetailFont, Brushes.Black)

            .DrawStringInBoxLeft(e, intX + 375, intY, 60, 30, "Reciept No.", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 440, intY, 10, 30, ":", DetailFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 455, intY, 140, 30, Format(CInt(lblCurrentDocNumber.Text), "000000"), DetailFont, Brushes.Black)

            intY = intY + 15
            e.Graphics.DrawLine(Pens.LightGray, intX, intY, 700, intY)

            '**** THIRD LINE ITEMS 
            '
            intY = intY + 5

            .DrawStringInBoxLeft(e, intX, intY, 80, 30, "Bill to", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 85, intY, 10, 30, ":", DetailFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 95, intY, 250, 30, UCase(lblBillTo.Text), DetailFont, Brushes.Black)

            .DrawStringInBoxLeft(e, intX + 375, intY, 60, 30, "Bill No.", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 440, intY, 10, 30, ":", DetailFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 455, intY, 140, 30, "000001", DetailFont, Brushes.Black)

            intY = intY + 15
            e.Graphics.DrawLine(Pens.LightGray, intX, intY, 700, intY)

            Dim intVerticalHeight As Integer = intY

            Dim X1 As Integer = 0, X2 As Integer = 0, X3 As Integer = 0, X4 As Integer = 0, X5 As Integer = 0, X6 As Integer = 0, X7 As Integer = 0
            X1 = 100 : X2 = 183 : X3 = 193 : X4 = 472 : X5 = 538 : X6 = 548 : X7 = 700

            '***** DRAW TOP PART VERTICAL LINES
            e.Graphics.DrawLine(Pens.LightGray, X1, 125, X1, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X2, 125, X2, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X3, 125, X3, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X4, 125, X4, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X5, 125, X5, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X6, 125, X6, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X7, 125, X7, intVerticalHeight)


            '**********************************************************************
            ' TRANSACTIONS PRINTING. BEGIN WITH THE HEADER LINE 
            '**********************************************************************

            Dim yStart As Integer = 0

            intY = intY + 20
            e.Graphics.DrawLine(Pens.LightGray, X1, intY, 700, intY)
            yStart = intY

            intY = intY + 10

            X1 = 100 : X2 = 160 : X3 = 460 : X4 = 500 : X5 = 580

            .DrawStringInBoxLeft(e, X1, intY, 55, 15, "Code", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X2, intY, 300, 15, "Description", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X3, intY, 40, 15, "Qty", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X4, intY, 80, 15, "Unit Rate", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X5, intY, 80, 15, "Gross Amt", SubHeaderFont, Brushes.Black)

            intY = intY + 15
            e.Graphics.DrawLine(Pens.LightGray, X1, intY, 700, intY)
            intY = intY + 15

            'Loop through the items and add them to the printing while keep track of the y-value


            While itm < arrReceiptItems.Count

                If intPayslipProcessingCount > 35 Then
                    intPayslipProcessingCount = 0
                    e.HasMorePages = True
                    Exit Sub
                End If

                Dim strBuffer() As String = Split(arrReceiptItems.Item(itm), "|")

                .DrawStringInBoxLeft(e, X1 + 5, intY, 55, 15, UCase(strBuffer(0)), DetailFont, Brushes.Black)
                .DrawStringInBoxLeft(e, X2 + 5, intY, 300, 15, UCase(strBuffer(1)), DetailFont, Brushes.Black)
                .DrawStringInBoxRight(e, X3 - 5, intY, 40, 15, Format(CDbl(strBuffer(2)), "##0.00"), DetailFont, Brushes.Black)
                .DrawStringInBoxRight(e, X4 - 5, intY, 80, 15, Format(CDbl(strBuffer(3)), "##0.00"), DetailFont, Brushes.Black)
                .DrawStringInBoxRight(e, X5 - 5, intY, 80, 15, Format(CDbl(strBuffer(4)), "##0.00"), DetailFont, Brushes.Black)

                dblAmountPayable = dblAmountPayable + CDbl(strBuffer(4))

                'Draw bottom line

                'Check that description is not longer than the allocated cell and has wrapped
                ' and then get the real height to y
                intY = intY + 15
                e.Graphics.DrawLine(Pens.LightGray, X1, intY, 700, intY)
                intY = intY + 5

                intPayslipProcessingCount = intPayslipProcessingCount + 1
                itm = itm + 1

            End While

            'Write out the total line in bold
            .DrawStringInBoxLeft(e, X1 + 5, intY, 55, 15, "", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X2 + 5, intY, 300, 15, UCase("Net Bill Amount"), SubHeaderFont, Brushes.Black)
            .DrawStringInBoxRight(e, X3 + 5, intY, 40, 15, "", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxRight(e, X4 + 5, intY, 80, 15, "", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxRight(e, X5 - 5, intY, 80, 15, Format(CDbl(lblPayable.Text), "##0.00"), SubHeaderFont, Brushes.Black)

            intY = intY + 15
            e.Graphics.DrawLine(Pens.LightGray, X1, intY, 700, intY)
            intY = intY + 5

            intVerticalHeight = intY - 5

            'Draw the vericals after items 
            e.Graphics.DrawLine(Pens.LightGray, X1, yStart, X1, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X2, yStart, X2, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X3, yStart, X3, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X4, yStart, X4, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X5, yStart, X5, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X7, yStart, X7, intVerticalHeight)


            '
            '********************* CREATE PAYMENT SPLIT 
            '
            intY = intY + 10

            reccurrent = New Rectangle(intX, intY, 600, intY_height)
            e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)
            e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), reccurrent)

            .DrawStringInBoxLeft(e, intX + 10, intY + 3, 600, 15, "Payment Breakdown", SubHeaderFont, Brushes.Black)

            ' Draw table withou filling in first
            intY = intY + 17
            reccurrent = New Rectangle(intX, intY, 600, 40)
            e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)

            'draw line accross the rectangle
            e.Graphics.DrawLine(Pens.LightGray, X1, intY + 20, 700, intY + 20)


            'Draw the vericals after items
            X1 = 100 : X2 = 200 : X3 = 300 : X4 = 400 : X5 = 500 : X6 = 600

            yStart = intY
            intVerticalHeight = yStart + 40

            e.Graphics.DrawLine(Pens.LightGray, X1, yStart, X1, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X2, yStart, X2, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X3, yStart, X3, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X4, yStart, X4, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X5, yStart, X5, intVerticalHeight)
            e.Graphics.DrawLine(Pens.LightGray, X6, yStart, X6, intVerticalHeight)

            .DrawStringInBoxLeft(e, X1 + 10, intY + 5, 100, 15, "Cash", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X2 + 10, intY + 5, 100, 15, "Ecocash", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X3 + 10, intY + 5, 100, 15, "Swipe", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X4 + 10, intY + 5, 100, 15, "Transfer", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X5 + 10, intY + 5, 100, 15, "Other", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X6 + 10, intY + 5, 100, 15, "Total", SubHeaderFont, Brushes.Black)

            intY = intY + 25

            'Print the actual values
            .DrawStringInBoxRight(e, X1 + 10, intY, 85, 15, CStr(Format(dblCash, "#,##0.00")), DetailFont, Brushes.Black)
            .DrawStringInBoxRight(e, X2 + 10, intY, 85, 15, CStr(Format(dblEcocash, "#,##0.00")), DetailFont, Brushes.Black)
            .DrawStringInBoxRight(e, X3 + 10, intY, 85, 15, CStr(Format(dblSwipe, "#,##0.00")), DetailFont, Brushes.Black)
            .DrawStringInBoxRight(e, X4 + 10, intY, 85, 15, CStr(Format(dblTransfer, "#,##0.00")), DetailFont, Brushes.Black)
            .DrawStringInBoxRight(e, X5 + 10, intY, 85, 15, CStr(Format(dblOtherPaymentMethods, "#,##0.00")), DetailFont, Brushes.Black)
            .DrawStringInBoxRight(e, X6 + 10, intY, 85, 15, CStr(Format((dblCash + dblEcocash + dblSwipe + dblTransfer + dblOtherPaymentMethods), "#,##0.00")), DetailFont, Brushes.Black)

            strReceiptSpecialNotes = "Testing the note and remarks entry"

            intY = intY + 30
            reccurrent = New Rectangle(intX, intY, 600, 20)
            e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)
            .DrawStringInBoxRight(e, X1, intY + 5, 90, 15, "REMARKS :", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X2, intY + 5, 500, 15, strReceiptSpecialNotes, DetailFont, Brushes.Black)

            'Cashier and doctor details
            '
            intY = intY + 20
            reccurrent = New Rectangle(intX, intY, 600, 20)
            e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)
            .DrawStringInBoxRight(e, X1, intY + 5, 90, 15, "CASHIER :", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X2, intY + 5, 150, 15, strPublicActiveFullUserName, DetailFont, Brushes.Black)

            .DrawStringInBoxLeft(e, X3 + 70, intY + 5, 85, 15, "ATTENDING DR :", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X3 + 140, intY + 5, 150, 15, strAttendingDoctor, DetailFont, Brushes.Black)

            ' Load the Greatwits image - Greatwits_small_new.png
            '
            intY = intY + 30
            If Not String.IsNullOrEmpty(GreatwitsSmallLogo) Then
                If System.IO.File.Exists(GreatwitsSmallLogo) Then
                    Dim picPrint As New PictureBox
                    picPrint.SizeMode = PictureBoxSizeMode.AutoSize
                    picPrint.Load(GreatwitsSmallLogo)
                    Dim R As New Rectangle(X6 + 17, intY, picPrint.Width, picPrint.Height)
                    e.Graphics.DrawImage(picPrint.Image, R)
                End If
            End If

            e.HasMorePages = False
            boolPrintFromPreview = True

        End With

    End Sub

    Private Sub btnTestPrint_Click(sender As Object, e As EventArgs) Handles btnTestPrint.Click
        intPayslipProcessingCount = 0
        If MessageBox.Show("Do you want To print the receipt right now?", "Confirm Receipt Print",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            boolAbort = False
            Dim printSelect As New PrintDialog
            printSelect.ShowDialog()
            strSessionPrinter = printSelect.PrinterSettings.PrinterName
            If boolAbort = True Then Exit Sub
            boolDrawBorders = True
            pdSmartBilling.PrinterSettings.PrinterName = strSessionPrinter

            dblAmountPayable = 0
            itm = 0
            arrReceiptItems = New ArrayList
            arrReceiptItems = CreatePrintArray(3)

            Dim documentPreview As New PrintPreviewDialog
            documentPreview.Document = pdSmartBilling
            documentPreview.ShowDialog()
        End If
    End Sub

    Private Sub optConsultations_CheckedChanged(sender As Object, e As EventArgs) Handles optConsultations.CheckedChanged
        If optConsultations.Checked = True Then
            cboSearchOption.Text = strConsultationsDefaultSearchKey
            cboSearchOption.Text = strConsultationsDefaultSearchKey
        End If
    End Sub

    Private Sub frmBilling_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        intSelectedPatient = 0
    End Sub

    Private Sub optDrugs_CheckedChanged(sender As Object, e As EventArgs) Handles optDrugs.CheckedChanged
        If optDrugs.Checked = True Then
            cboSearchOption.Text = strMedicinesDefaultSearchKey
            cboSearchOption.Text = strMedicinesDefaultSearchKey
        End If
    End Sub

    Private Sub optExtraServices_CheckedChanged(sender As Object, e As EventArgs) Handles optExtraServices.CheckedChanged
        If optExtraServices.Checked = True Then
            cboSearchOption.Text = strExtrasDefaultSearchKey
            cboSearchOption.Text = strExtrasDefaultSearchKey
        End If
    End Sub

    Private Sub btnOverideDate_Click(sender As System.Object, e As System.EventArgs) Handles btnOverideDate.Click
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Or IntPublicStoresManagement > 0 Then
            boolAbort = False
            gwt_comm.DateSpecification()
            If boolAbort = True Then Exit Sub
        Else
            gwt_comm.AccessViolation()
            Exit Sub
        End If
    End Sub

    Private Sub dGrid_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellContentClick
        If dGrid.CurrentCell.ColumnIndex = dGrid.ColumnCount - 1 Then
            Dim strPostStatus As String = Nothing
            If Not Object.Equals(dGrid.CurrentRow.Cells(8).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(8).Value.ToString()) Then
                    strPostStatus = dGrid.CurrentRow.Cells(8).Value.ToString
                End If
            End If

            If UCase(strPostStatus) = "C" Then
                dGrid.Rows.RemoveAt(dGrid.CurrentRow.Index)
            Else
                MessageBox.Show("The selected row is locked for delete", "Record Read Only", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

End Class