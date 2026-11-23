Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLightAirMain

    Dim boolPrintFromPreview As Boolean

    Private Sub frmLightAirMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadAirServices()
        LoadPermitsInvoice(Now, Now)
    End Sub

    Private Sub LoadAirServices()
        On Error GoTo RaiseErr
        dGridAirCards.Rows.Clear()
        Dim objCmmand As New Data.OleDb.OleDbCommand("SELECT ServiceName, TransactionId FROM AirHandlingServices ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmmand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGridAirCards.Rows.Add(False, objReader(0).ToString, "0.00", False, objReader(1).ToString)
            End If
        End While
        objReader.Close()
        Label1.BackColor = Color.FromArgb(62, 120, 143)
        Label1.BackColor = Color.FromArgb(62, 120, 143) : Label1.ForeColor = Color.White
        Label2.BackColor = Color.FromArgb(62, 120, 143) : Label2.ForeColor = Color.White
        Label3.BackColor = Color.FromArgb(62, 120, 143) : Label3.ForeColor = Color.White
        Label4.BackColor = Color.FromArgb(62, 120, 143) : Label4.ForeColor = Color.White
        Label5.BackColor = Color.FromArgb(62, 120, 143) : Label5.ForeColor = Color.White
        Label6.BackColor = Color.FromArgb(62, 120, 143) : Label6.ForeColor = Color.White
        Label7.BackColor = Color.FromArgb(62, 120, 143) : Label7.ForeColor = Color.White
        Label8.BackColor = Color.FromArgb(62, 120, 143) : Label8.ForeColor = Color.White
        Label9.BackColor = Color.FromArgb(62, 120, 143) : Label9.ForeColor = Color.White
        Label10.BackColor = Color.FromArgb(62, 120, 143) : Label10.ForeColor = Color.White
        Label11.BackColor = Color.FromArgb(62, 120, 143) : Label11.ForeColor = Color.White
        Label12.BackColor = Color.FromArgb(62, 120, 143) : Label12.ForeColor = Color.White
        Label13.BackColor = Color.FromArgb(62, 120, 143) : Label13.ForeColor = Color.White
        Label14.BackColor = Color.FromArgb(62, 120, 143) : Label14.ForeColor = Color.White

        Label15.BackColor = Color.FromArgb(62, 120, 143) : Label15.ForeColor = Color.White
        Label16.BackColor = Color.FromArgb(62, 120, 143) : Label16.ForeColor = Color.White
        Label17.BackColor = Color.FromArgb(62, 120, 143) : Label17.ForeColor = Color.White
        Label18.BackColor = Color.FromArgb(62, 120, 143) : Label18.ForeColor = Color.White
        Label19.BackColor = Color.FromArgb(62, 120, 143) : Label19.ForeColor = Color.White

        Label20.BackColor = Color.FromArgb(62, 120, 143) : Label20.ForeColor = Color.White
        Label21.BackColor = Color.FromArgb(62, 120, 143) : Label21.ForeColor = Color.White
        Label22.BackColor = Color.FromArgb(62, 120, 143) : Label22.ForeColor = Color.White
        Label23.BackColor = Color.FromArgb(62, 120, 143) : Label23.ForeColor = Color.White
        Label24.BackColor = Color.FromArgb(62, 120, 143) : Label24.ForeColor = Color.White
        Label25.BackColor = Color.FromArgb(62, 120, 143) : Label25.ForeColor = Color.White
        Label28.BackColor = Color.FromArgb(62, 120, 143) : Label28.ForeColor = Color.White

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Air Services Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadPermitsInvoice(StartingDate As Date, EndingDate As Date)
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing

        strSql = "SELECT CustomerPermitSalesMain.InvoiceNumber, CONVERT(NVARCHAR, CustomerPermitSalesMain.TransDate, 105) AS [Date], Customers.AccountName, " _
                & "CAST(CustomerPermitSalesMain.Amount AS DECIMAL (10,2)) AS [Value], CAST(CustomerPermitSalesMain.Discount AS DECIMAL (10,2)) AS [Discounts], " _
                & "CAST(CustomerPermitSalesMain.Taxes AS DECIMAL (10,2)) AS [Taxes] FROM CustomerPermitSalesMain LEFT OUTER JOIN Customers ON " _
                & "CustomerPermitSalesMain.CustomerId = Customers.AccountNumber WHERE TransDate BETWEEN " _
                & "'" & Format(StartingDate, "dd-MMM-yyyy") & "' AND '" & Format(EndingDate, "dd-MMM-yyyy") & "' "

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim i As Integer = 0
        dGridPermits.Rows.Clear()
        While objReader.Read
            dGridPermits.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGridPermits.Rows(i).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGridPermits.Rows(i).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGridPermits.Rows(i).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dGridPermits.Rows(i).Cells(3).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then dGridPermits.Rows(i).Cells(4).Value = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then dGridPermits.Rows(i).Cells(5).Value = objReader(5).ToString
            i = i + 1
        End While
        objReader.Read()

        'Calculate totals
        Dim dblMovingT As Double = 0
        Dim dblMovingTx As Double = 0
        Dim dblMovingDs As Double = 0
        Dim strValue As String
        For i = 0 To dGridPermits.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGridPermits.Rows(i).Cells(3).Value), "")) Then
                strValue = Convert.ToString(dGridPermits.Rows(i).Cells(3).Value)
                If IsNumeric(strValue) Then
                    dblMovingT = dblMovingT + CDbl(strValue)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridPermits.Rows(i).Cells(4).Value), "")) Then
                strValue = Convert.ToString(dGridPermits.Rows(i).Cells(4).Value)
                If IsNumeric(strValue) Then
                    dblMovingTx = dblMovingTx + CDbl(strValue)
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridPermits.Rows(i).Cells(5).Value), "")) Then
                strValue = Convert.ToString(dGridPermits.Rows(i).Cells(5).Value)
                If IsNumeric(strValue) Then
                    dblMovingDs = dblMovingDs + CDbl(strValue)
                End If
            End If
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Permit Invoice Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnAirCardParameters_Click(sender As System.Object, e As System.EventArgs) Handles btnAirCardParameters.Click
        boolAbort = False
        Dim frm As New frmAirCardParameters
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        LoadAirServices()
    End Sub

    Private Sub btnRefreshAirCards_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshAirCards.Click
        LoadAirServices()
    End Sub

    Private Sub btnSaveAirCard_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAirCard.Click
        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtAcLocation.Text) Then
            MessageBox.Show("Please enter the location", "Missing Location", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAcLocation.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAcBillTo.Text) Then
            MessageBox.Show("Please enter to whom to bill", "Missing Billing Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAcBillTo.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAcJobNo.Text) Then
            MessageBox.Show("Please enter the Job Number", "Missing Job Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAcJobNo.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAcIcao.Text) Then
            MessageBox.Show("Please enter the ICAO (Internation Civil Aviation Organisation))", "Missing ICAO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAcIcao.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAcReference.Text) Then
            MessageBox.Show("Please enter the reference", "Missing Reference", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAcReference.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAcOperator.Text) Then
            MessageBox.Show("Please enter the operator name", "Missing Operator Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAcOperator.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtAcMtow.Text) Then txtAcMtow.Text = "0"
        If Not IsNumeric(txtAcJobNo.Text) Then
            MessageBox.Show("Missing the job number. This is key. Process will not proceed", "Missing Job Number", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtAcJobNo.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtAcCrewIn.Text) Then txtAcCrewIn.Text = "0"
        If Not IsNumeric(txtAcCrewOut.Text) Then txtAcCrewOut.Text = "0"
        If Not IsNumeric(txtAcPaxIn.Text) Then txtAcPaxIn.Text = "0"
        If Not IsNumeric(txtAcPaxOut.Text) Then txtAcPaxOut.Text = "0"

        Dim strSql As String = "INSERT INTO AirCardsMain ([Location], [ICAO], [JobNumber], [OperatorName], [BillTo], " _
            & "[ReferenceNumber], [AccountType], [Registry], [CallSign], [MTOW], [ETATime], [ETADate], [ICAOfrom], " _
            & "[ETDTime], [ETDDate], [ICAOto], [CrewIn], [CrewOut], [PAXin], [PAXout], [PayMethod], [CreditCardType], " _
            & "[CardHolderName], [CardNumber], [CardExpiryDate], [AgentName], [CrewName], [TransDate]) VALUES " _
            & "('" & txtAcLocation.Text & "', '" & txtAcIcao.Text & "', " & CInt(txtAcJobNo.Text) & ", " _
            & "'" & txtAcOperator.Text & "', '" & txtAcBillTo.Text & "', '" & txtAcReference.Text & "', " _
            & "'" & txtAcAccountType.Text & "', '" & txtAcRegistry.Text & "', '" & txtAcCallIn.Text & "', " _
            & "" & txtAcMtow.Text & ", '" & txtAcETAtime.Text & "', '" & Format(dtpAcETAdate.Value, "dd-MMM-yyyy") & "', " _
            & "'" & txtAcFromICAO.Text & "', '" & txtAcETDtime.Text & "', '" & Format(dtpAcETDdate.Value, "dd-MMM-yyyy") & "', " _
            & "'" & txtAcToICAO.Text & "', " & txtAcCrewIn.Text & ", " & txtAcCrewOut.Text & ", " & txtAcPaxIn.Text & ", " _
            & "" & txtAcPaxOut.Text & ", '" & cboAcPaymethod.Text & "', '" & cboAcCreditCardType.Text & "', " _
            & "'" & txtAcCardHolderName.Text & "', '" & txtAcCreditCardNumber.Text & "', '" & txtAcCreditCardExpiryDate.Text & "', " _
            & "'" & txtAcAgentName.Text & "', '" & txtAcCrewName.Text & "', '" & Format(dtAcTrans.Value, "dd-MMM-yyyy") & "')"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Save details
        '
        With dGridAirCards
            For p As Integer = 0 To dGridAirCards.RowCount - 1
                If .Rows(p).Cells(0).Value = True Then
                    strSql = "INSERT INTO AirCardDetails ([JobNumber], [ServiceKey]) VALUES " _
                        & "(" & txtAcJobNo.Text & ", " & CInt(.Rows(p).Cells(4).Value.ToString) & ")"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            Next
        End With

        'Clear the control
        ClearAirBillControls()

        MessageBox.Show("Air Handling Job Card Saved Successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Air Services Save"
        ShowErrorMessage()
    End Sub

    Private Sub ClearAirBillControls()
        With dGridAirCards
            For p As Integer = 0 To .Rows.Count - 1
                .Rows(p).Cells(0).Value = False
                .Rows(p).Cells(3).Value = False
            Next
        End With
        txtAcAccountType.Clear()
        txtAcAgentName.Clear()
        txtAcBillTo.Clear()
        txtAcCallIn.Clear()
        txtAcCardHolderName.Clear()
        txtAcCreditCardExpiryDate.Clear()
        txtAcCrewIn.Text = "0"
        txtAcCrewName.Clear()
        txtAcCrewOut.Text = "0"
        txtAcETAtime.Text = "0000"
        txtAcETDtime.Text = "0000"
        txtAcFromICAO.Clear()
        txtAcIcao.Clear()
        txtAcLocation.Clear()
        txtAcMtow.Text = "0"
        txtAcOperator.Clear()
        txtAcPaxIn.Text = "0"
        txtAcPaxOut.Text = "0"
        txtAcReference.Clear()
        txtAcRegistry.Clear()
        txtAcToICAO.Clear()
    End Sub

    Private Sub ButtonItem5_Click(sender As System.Object, e As System.EventArgs) Handles btnNewAirJobCard.Click
        boolEditStatus = False
        ClearAirBillControls()
    End Sub

    Private Sub btnEditAirJobCard_Click(sender As System.Object, e As System.EventArgs) Handles btnEditAirJobCard.Click
        boolAbort = False
        Dim frm As New frmAirCardsListing
        frm.ShowDialog()
        If boolAbort = False Then boolEditStatus = True
    End Sub

    Private Sub ButtonItem7_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem7.Click
        Dim frm As New frmAirCardsListing
        frm.ShowDialog()
    End Sub

    Private Sub btnNewPermit_Click(sender As System.Object, e As System.EventArgs) Handles btnNewPermit.Click
        boolEditStatusTwo = False
        boolLoadedFromCustomerForm = False
        Dim frm As New frmPermitInvoicing
        frm.ShowDialog()
        LoadPermitsInvoice(CDate(Format(Now, "dd-MMM-yyyy")), CDate(Format(Now, "dd-MMM-yyyy")))
    End Sub

    Private Sub btnEditPermit_Click(sender As System.Object, e As System.EventArgs) Handles btnEditPermit.Click
        If dGridPermits.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If Not (Object.Equals(Convert.ToString(dGridPermits.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridPermits.CurrentRow.Cells(0).Value.ToString) Then
                boolEditStatusTwo = True
                boolLoadedFromCustomerForm = False
                intSelectedTransaction = CInt(dGridPermits.CurrentRow.Cells(0).Value.ToString)
                Dim f As New frmPermitInvoicing
                f.ShowDialog()
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Permits and Invoices Edit"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefreshPermit_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshPermit.Click
        LoadPermitsInvoice(CDate(Format(Now, "dd-MMM-yyyy")), CDate(Format(Now, "dd-MMM-yyyy")))
    End Sub

    Private Sub btnPrintPermit_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintPermit.Click
        If dGridPermits.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        boolPrinterAlreadySelected = False
        If Not (Object.Equals(Convert.ToString(dGridPermits.CurrentRow.Cells(0).Value), "")) Then
            If IsNumeric(dGridPermits.CurrentRow.Cells(0).Value.ToString) Then
                If UCase(CommonLibrary.Commons.strInvoiceDesignType) = "CUSTOM" Then
                    Dim f As New PrintDialog
                    f.ShowDialog()
                    boolEditStatusTwo = True
                    boolPrintFromPreview = True
                    PrintDocument2.PrinterSettings.PrinterName = f.PrinterSettings.PrinterName
                    PrintPreviewDialog1.Document = PrintDocument2
                    PrintPreviewDialog1.ShowDialog()
                Else
                    'Print generic invoice
                    intSelectedTransaction = CInt(dGridPermits.CurrentRow.Cells(0).Value.ToString)
                    Dim gwt_comm As New CommonLibrary.Commons.CommonFunctions
                    gwt_comm.PrintCustomerDocument(intSelectedTransaction, "INVOICE")
                End If
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Analysis"
        ShowErrorMessage()
    End Sub

End Class
