Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmProjectClaims

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
        lblProject.Text = strSelectedDescription
        LoadClaimHistory()
        ComputeAllTotals()
    End Sub

    Private Function InvoicedAmount() As Double
        On Error GoTo RaiseErr
        Dim dblReturn As Double = 0
        For p As Integer = 0 To dgrid.RowCount - 1
            If Not Object.Equals(dgrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dgrid.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dgrid.Rows(p).Cells(2).Value.ToString) Then
                        dblReturn = dblReturn + CDbl(dgrid.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
            End If
        Next
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Total Invoiced Claims Computation"
        ShowErrorMessage()
    End Function

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
        objCommand = New Data.OleDb.OleDbCommand("SELECT CAST(InitialValue AS DECIMAL (30,2)), " _
            & "CAST(RevisedValue AS DECIMAL (30,2)), CAST(Overtime AS DECIMAL (30,2)), " _
            & "CAST(VariationOrders AS DECIMAL (30,2)), CAST(ConBrackets AS DECIMAL (30,2)) " _
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

        Dim dblInvoiced As Double = InvoicedAmount()
        Dim dblContractValue As Double = 0

        If IsNumeric(lblRevisedValue.Text) Then dblContractValue = CDbl(lblRevisedValue.Text)
        Dim dblStillToInvoice As Double = dblContractValue - dblInvoiced

        lblStillToInvoice.Text = Format(dblStillToInvoice, "##0.00")

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
        lblRevisedValue.Text = Format((CDbl(txtConBrackets.Text) + CDbl(txtContractValue.Text) + CDbl(txtOvertime.Text) + CDbl(txtVariationOrders.Text)), "##0.00")
        lblRevisedValue.Text = Format(((CDbl(lblRevisedValue.Text) * (dblSalesTaxRate / 100)) + CDbl(lblRevisedValue.Text)), "##0.00")
        'Calculate the still to invoice
        If Not IsNumeric(lblAmtAfterVat.Text) Then lblAmtAfterVat.Text = "0.00"
        If Not IsNumeric(lblRevisedValue.Text) Then lblRevisedValue.Text = "0.00"
        lblStillToInvoice.Text = Format(CDbl(lblRevisedValue.Text) - CDbl(lblAmtAfterVat.Text), "##0.00")

        Dim dblInvoiced As Double = InvoicedAmount()
        Dim dblContractValue As Double = 0
        If IsNumeric(lblRevisedValue.Text) Then dblContractValue = CDbl(lblRevisedValue.Text)
        Dim dblStillToInvoice As Double = dblContractValue - dblInvoiced
        lblStillToInvoice.Text = Format(dblStillToInvoice, "##0.00")

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

    Private Sub btnRemoveLine_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveLine.Click
        If dgrid.Rows.Count <= 0 Then Exit Sub
        dgrid.Rows.RemoveAt(dgrid.CurrentRow.Index)
        ComputeTotals()
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
        Call gwt_comm.DrawStringInBoxLeft(e, 600, y1, 300, 80, ": " & Format(CLng(lblProjectNo.Text), "000000") & Space(5) & "SITE : " & UCase(lblproject.Text), fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress1, fntDetailsFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress2, fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "OUR REF.NO.", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 600, y1, 300, 80, ": " & UCase("GTI-" & lblProjectNo.Text), fntDetailsFont, Brushes.Black)
        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress3, fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "INITIAL VALUE", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 600, y1, 300, 80, ": " & UCase(txtContractValue.Text), fntDetailsFont, Brushes.Black)

        Dim dblVoValue As Double = 0
        If IsNumeric(txtVariationOrders.Text) Then dblVoValue = dblVoValue + CDbl(txtVariationOrders.Text)
        If IsNumeric(txtOvertime.Text) Then dblVoValue = dblVoValue + CDbl(txtOvertime.Text)
        If IsNumeric(txtConBrackets.Text) Then dblVoValue = dblVoValue + CDbl(txtConBrackets.Text)

        Call gwt_comm.DrawStringInBoxLeft(e, 750, y1, 150, 80, "VO VALUE : " & Format(dblVoValue, "##0.00"), fntDetailsFont, Brushes.Black)
        'Call gwt_comm.DrawStringInBoxRight(e, 850, y1, 150, 80, ": " & Format(dblVoValue, "##0.00"), fntDetailsFont, Brushes.Black)

        y1 += 15
        Call gwt_comm.DrawStringInBoxLeft(e, 110, y1, 200, 80, strCustomerAddress4, fntDetailsFont, Brushes.Black)
        'PRINT REVISED VALUE
        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 300, 80, "GROSS VAL", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 600, y1, 300, 80, ": " & Format(CDbl(txtContractValue.Text + dblVoValue), "##0.00"), fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 750, y1, 300, 80, "REVISED GROSS + VAT : " & Format(CDbl(lblRevisedValue.Text), "##0.00"), fntDetailsFont, Brushes.Black)

        y1 += 15
        e.Graphics.DrawString("TELEPHONE : " & strCustomerTelephone, fntDetailsFont, Brushes.Black, x1 + 10, y1)
        'PRINT REVISED VALUE

        'Call gwt_comm.DrawStringInBoxLeft(e, 600, y1, 300, 80, ": " & Format(CDbl(lblRevisedValue.Text), "##0.00"), fntDetailsFont, Brushes.Black)


        'PRINT STILL TO INVOICE
        ''
        Dim dblInvoiced As Double = InvoicedAmount()
        Dim dblContractValue As Double = 0

        If IsNumeric(lblRevisedValue.Text) Then dblContractValue = CDbl(lblRevisedValue.Text)
        Dim dblStillToInvoice As Double = dblContractValue - dblInvoiced

        Call gwt_comm.DrawStringInBoxLeft(e, 500, y1, 150, 80, "STILL TO INVOICE", fntDetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, 600, y1, 150, 80, ": " & Format(dblStillToInvoice, "##0.00"), fntDetailsFont, Brushes.Black) 'lblTotalOutstanding.Text
        Call gwt_comm.DrawStringInBoxLeft(e, 750, y1, 300, 80, "TOTAL TO INVOICE : " & Format(Format(CDbl(dblStillToInvoice), "#,##0.00")), fntTotalsFont, Brushes.Black)
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

    Private Sub btnPrintClaim_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintClaim.Click
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

    'Private Sub frmProjectClaims_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    'End Sub
End Class