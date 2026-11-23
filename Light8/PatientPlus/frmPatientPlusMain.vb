Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPatientPlusMain

    Dim boolPrintFromPreview As Boolean

    Dim strBillTo As String
    Dim intPatientId As Integer
    Dim strPatientNames As String
    Dim intDocumentNumber As Integer
    Dim dblAmountPayable As Double
    Dim strTransDate As String = "00-000-0000"

    Private Sub frmPatientPlusMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        boolAbort = False
        Dim f As New frmLogin
        f.ShowDialog()
        If boolAbort = True Then End
        LoadPatients()
        LoadMedicines()
        LoadTransactions(CDate(gwt_comm.shortMonthDateFormat(Now)), CDate(gwt_comm.shortMonthDateFormat(Now)))
    End Sub

    Private Sub LoadPatients()
        Dim frm As New frmPatientsAdmin
        tabPatients.Tabs.Clear()
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Green
        AddTabbedForm(frm, tabPatients, CurrentTabColor)
    End Sub

    Private Sub LoadMedicines()
        tabMedicines.Tabs.Clear()
        Dim frm As New frmMedicinesAndExtrasListing
        tabPatients.Tabs.Clear()
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Gold
        AddTabbedForm(frm, tabMedicines, CurrentTabColor)
    End Sub

    Public Sub AddTabbedForm(ByVal frm As System.Windows.Forms.Form,
                ByVal ActiveTab As DevComponents.DotNetBar.SuperTabControl,
                ByVal TabColor As DevComponents.DotNetBar.eTabItemColor)

        'Iterate through the item tabs and make sure that the item has not be loaded before
        'If item already loaded then activate it instead

        Cursor = Cursors.WaitCursor

        Dim boolTabLoaded As Boolean = False
        For i As Integer = 0 To ActiveTab.Tabs.Count - 1
            If UCase(ActiveTab.Tabs.Item(i).Text) = UCase(frm.Text) Then
                boolTabLoaded = True
                ActiveTab.SelectedTabIndex = i
                Cursor = Cursors.Default
                Exit Sub
            End If
        Next

        If boolTabLoaded = False Then
            frm.TopLevel = False
            frm.Visible = True
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill

            Dim myTabPanel As New DevComponents.DotNetBar.SuperTabControlPanel 'TabControlPanel()
            Dim myTabItem As New DevComponents.DotNetBar.SuperTabItem 'TabItem()

            myTabItem.Text = frm.Text
            ActiveTab.Controls.Add(myTabPanel)
            myTabItem.AttachedControl = myTabPanel
            ActiveTab.Tabs.Add(myTabItem)

            myTabPanel.Location = New System.Drawing.Point(0, 26)
            myTabPanel.Name = "TabControlPanel" & ActiveTab.Tabs.Count
            myTabPanel.Padding = New System.Windows.Forms.Padding(0)
            myTabPanel.Size = New System.Drawing.Size(616, 385)
            myTabPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            myTabPanel.Dock = System.Windows.Forms.DockStyle.Fill
            myTabPanel.TabItem = myTabItem
            myTabItem.PredefinedColor = TabColor ' DevComponents.DotNetBar.eTabItemColor.Purple
            myTabPanel.Controls.Add(frm)
            ActiveTab.Refresh()
            ActiveTab.Visible = True
            RefreshTabs(ActiveTab)
            ActiveTab.SelectedTabIndex = ActiveTab.Tabs.Count - 1
            Cursor = Cursors.Default
        End If

    End Sub

    Private Sub RefreshTabs(ByVal ActiveTab As DevComponents.DotNetBar.SuperTabControl)
        Me.Refresh()
        ActiveTab.Refresh()
    End Sub

    Private Sub tabPatients_TabItemClose(sender As Object, e As DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs) Handles tabPatients.TabItemClose
        If UCase(e.Tab.Text) = UCase("Patients") Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub tabMedicines_TabItemClose(sender As Object, e As DevComponents.DotNetBar.SuperTabStripTabItemCloseEventArgs) Handles tabMedicines.TabItemClose
        If UCase(e.Tab.Text) = UCase("Medicines and Services") Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub btnMedicalAids_Click(sender As Object, e As EventArgs) Handles btnMedicalAids.Click
        Dim frm As New frmMedicalAidSchemes
        tabPatients.Tabs.Clear()
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Blue
        AddTabbedForm(frm, tabSettings, CurrentTabColor)
    End Sub

    Private Sub btnConsultationCodes_Click(sender As Object, e As EventArgs) Handles btnConsultationCodes.Click
        Dim frm As New frmConsultationCodesListing
        tabPatients.Tabs.Clear()
        Dim CurrentTabColor As DevComponents.DotNetBar.eTabItemColor = DevComponents.DotNetBar.eTabItemColor.OfficeMobile2014Lilac
        AddTabbedForm(frm, tabSettings, CurrentTabColor)
    End Sub

    Private Sub btnOrganisation_Click(sender As Object, e As EventArgs) Handles btnOrganisation.Click
        Dim frm As New frmOrganisation
        frm.ShowDialog()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        LoadTransactions(CDate(gwt_comm.shortMonthDateFormat(dpStartDate.Value)), CDate(gwt_comm.shortMonthDateFormat(dpEnd.Value)))
        ComputeGrandTotals()
    End Sub

    Private Sub LoadTransactions(ByVal StartingDate As Date, ByVal endingDate As Date)
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT OchmasBillingMain.DocumentNumber AS [Ref.], " _
            & "OchmasBillingMain.PatientId as [PID], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), OchmasBillingMain.TransDate, 106), ' ', '-')) AS [Date], " _
            & "OchmasPatients.LastName +' '+ OchmasPatients.FirstName +' '+ OchmasPatients.OtherNames AS [Patient Names], " _
            & "ISNULL(OchmasSystemMedicalAids.Name, '') AS [Bill To], " _
            & "CAST(OchmasBillingMain.Amount AS DECIMAL (10,2)) AS [Billed], " _
            & "CAST(OchmasBillingMain.Cash AS DECIMAL (10,2)) AS [Cash], " _
            & "CAST(OchmasBillingMain.Ecocash AS DECIMAL (10,2)) AS [Ecocash], " _
            & "CAST(OchmasBillingMain.Swipe AS DECIMAL (10,2)) AS [Swipe], " _
            & "CAST(OchmasBillingMain.Transfer AS DECIMAL (10,2)) AS [Transfer], " _
            & "CAST(OchmasBillingMain.OtherMethods AS DECIMAL (10,2)) AS [Others], " _
            & "CAST((Cash + EcoCash + Swipe + Transfer + OtherMethods) AS DECIMAL (10,2)) AS [Paid], " _
            & "[Comments] AS [Comments] FROM OchmasBillingMain " _
            & "LEFT OUTER JOIN OchmasPatients ON OchmasBillingMain.PatientId = OchmasPatients.PatientId " _
            & "LEFT OUTER JOIN OchmasSystemMedicalAids ON OchmasBillingMain.SchemeCode = OchmasSystemMedicalAids.SchemeCode " _
            & "WHERE OchmasBillingMain.TransDate BETWEEN '" & StartingDate & "' AND '" & endingDate & "' " _
            & "ORDER BY OchmasBillingMain.TransDate, OchmasBillingMain.DocumentNumber"

        With dGridTransactions

            .Columns.Clear()
            .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New OleDb.OleDbDataAdapter(cmd)
            Dim dTable As New DataTable()
            da.Fill(dTable)
            .DataSource = dTable

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            For p As Integer = 0 To .Columns.Count - 1
                .Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                If p = 1 Or p = .ColumnCount - 1 Then
                    .Columns(p).Visible = False
                End If
                If p > 4 Then
                    .Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Next

        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On period receipts analysis"
        ShowErrorMessage()
    End Sub

    Private Sub btnReprintInvoice_Click(sender As Object, e As EventArgs) Handles btnReprintInvoice.Click
        If dGridTransactions.RowCount <= 0 Then Exit Sub

        On Error GoTo RaiseErr

        boolPrintFromPreview = False

        With dGridTransactions

            strBillTo = Nothing
            intPatientId = 0
            strPatientNames = Nothing
            intDocumentNumber = 0
            dblAmountPayable = 0

            dblCash = 0
            dblEcocash = 0
            dblSwipe = 0
            dblTransfer = 0
            dblOtherPaymentMethods = 0

            If Not Object.Equals(.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(0).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(0).Value.ToString) Then
                        intDocumentNumber = CInt(.CurrentRow.Cells(0).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(.CurrentRow.Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(1).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(1).Value.ToString) Then
                        intPatientId = CInt(.CurrentRow.Cells(1).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(.CurrentRow.Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(2).Value.ToString) Then
                    strTransDate = .CurrentRow.Cells(2).Value.ToString
                End If
            End If

            If Not Object.Equals(.CurrentRow.Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(3).Value.ToString) Then
                    strPatientNames = .CurrentRow.Cells(3).Value.ToString
                End If
            End If

            If Not Object.Equals(.CurrentRow.Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(4).Value.ToString) Then
                    strBillTo = .CurrentRow.Cells(4).Value.ToString
                End If
            End If
            If String.IsNullOrEmpty(strBillTo) Then strBillTo = "PATIENT"

            If Not Object.Equals(.CurrentRow.Cells(5).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(5).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(5).Value.ToString) Then
                        dblBilledAmount = CDbl(.CurrentRow.Cells(5).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(.CurrentRow.Cells(6).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(6).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(6).Value.ToString) Then
                        dblCash = CDbl(.CurrentRow.Cells(6).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(.CurrentRow.Cells(7).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(7).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(7).Value.ToString) Then
                        dblEcocash = CDbl(.CurrentRow.Cells(7).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(.CurrentRow.Cells(8).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(8).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(8).Value.ToString) Then
                        dblSwipe = CDbl(.CurrentRow.Cells(8).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(.CurrentRow.Cells(9).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(9).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(9).Value.ToString) Then
                        dblTransfer = CDbl(.CurrentRow.Cells(9).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(.CurrentRow.Cells(10).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(10).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(10).Value.ToString) Then
                        dblOtherPaymentMethods = CDbl(.CurrentRow.Cells(10).Value.ToString)
                    End If
                End If
            End If

            'Send the dtails to printing again here

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
            arrReceiptItems = CreatePrintArray(intDocumentNumber)

            Dim documentPreview As New PrintPreviewDialog
            documentPreview.Document = pdSmartBilling
            documentPreview.ShowDialog()

        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On document reprint"
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
            If UCase(strBillTo) = UCase("PATIENT") Then
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
            .DrawStringInBoxLeft(e, intX + 95, intY, 250, 30, Format(intPatientId, "000000"), DetailFont, Brushes.Black)

            .DrawStringInBoxLeft(e, intX + 375, intY, 60, 30, "Date", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 440, intY, 10, 30, ":", DetailFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 455, intY, 140, 30, UCase(strTransDate), DetailFont, Brushes.Black)
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
            .DrawStringInBoxLeft(e, intX + 95, intY, 250, 30, UCase(strPatientNames), DetailFont, Brushes.Black)

            .DrawStringInBoxLeft(e, intX + 375, intY, 60, 30, "Reciept No.", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 440, intY, 10, 30, ":", DetailFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 455, intY, 140, 30, FormatCurrency(intDocumentNumber, "000000"), DetailFont, Brushes.Black)

            intY = intY + 15
            e.Graphics.DrawLine(Pens.LightGray, intX, intY, 700, intY)

            '**** THIRD LINE ITEMS 
            '
            intY = intY + 5

            .DrawStringInBoxLeft(e, intX, intY, 80, 30, "Bill to", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 85, intY, 10, 30, ":", DetailFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 95, intY, 250, 30, UCase(strBillTo), DetailFont, Brushes.Black)

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
            .DrawStringInBoxRight(e, X5 - 5, intY, 80, 15, Format(CDbl(dblBilledAmount), "##0.00"), SubHeaderFont, Brushes.Black)

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

            strReceiptSpecialNotes = "Testing the note And remarks entry"

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

    Private Sub ComputeGrandTotals()

        Cursor = Cursors.WaitCursor
        On Error GoTo RaiseErr

        Dim dblGrandCash As Double = 0
        Dim dblGrandEcocash As Double = 0
        Dim dblGrandSwipe As Double = 0
        Dim dblGrandTransfer As Double = 0
        Dim dblGrandOthers As Double = 0

        With dGridTransactions
            For p As Integer = 0 To .RowCount - 1
                If Not Object.Equals(.Rows(p).Cells(6).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(6).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(6).Value.ToString) Then
                            dblGrandCash = dblGrandCash + CDbl(.Rows(p).Cells(6).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(7).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(7).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(7).Value.ToString) Then
                            dblGrandEcocash = dblGrandEcocash + CDbl(.Rows(p).Cells(7).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(8).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(8).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(8).Value.ToString) Then
                            dblGrandSwipe = dblGrandSwipe + CDbl(.Rows(p).Cells(8).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(9).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(9).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(9).Value.ToString) Then
                            dblGrandTransfer = dblGrandTransfer + CDbl(.Rows(p).Cells(9).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(10).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(10).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(10).Value.ToString) Then
                            dblGrandOthers = dblGrandOthers + CDbl(.Rows(p).Cells(10).Value.ToString)
                        End If
                    End If
                End If
            Next
        End With

        lblCash.Text = Format(dblGrandCash, "#,##0.00")
        lblEcocash.Text = Format(dblGrandEcocash, "#,##0.00")
        lblSwipe.Text = Format(dblGrandSwipe, "#,##0.00")
        lblTransfer.Text = Format(dblGrandTransfer, "#,##0.00")
        lblOthers.Text = Format(dblGrandOthers, "#,##0.00")
        lblGrandTotal.Text = Format((dblGrandCash + dblGrandEcocash + dblGrandSwipe + dblGrandTransfer + dblGrandOthers), "#,##0.00")
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On grand totals computation"
        ShowErrorMessage()
    End Sub

    Private Sub SearchVitalsPatients(ByVal strCurrentKey As String)

        Dim strFind As String = txtPatientSearch.Text & strCurrentKey
        strActiveSearch = strFind
        Dim strSql As String = "SELECT OchmasPatients.PatientId as [PID], " _
            & "OchmasPatients.LastName +' '+ OchmasPatients.FirstName +' '+ OchmasPatients.OtherNames AS [Patient Names], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), OchmasPatients.BirthDate, 106), ' ', '-')) AS [DOB] " _
            & "FROM OchmasPatients WHERE " _
            & "(LastName Like '%" & strFind & "%' OR FirstName LIKE '%" & strFind & "%' OR OtherNames LIKE '%" & strFind & "%') " _
            & "ORDER BY LastName, FirstName, OtherNames "

        With dGridPatientsList

            .Columns.Clear()
            Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New OleDb.OleDbDataAdapter(cmd)
            Dim dTable As New DataTable()
            da.Fill(dTable)
            .DataSource = dTable

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            For p As Integer = 0 To .Columns.Count - 1
                .Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

        End With
    End Sub

    Private Sub txtPatientSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPatientSearch.KeyPress
        SearchVitalsPatients(e.KeyChar)
    End Sub

    Private Sub btnSelectForVitals_Click(sender As Object, e As EventArgs) Handles btnSelectForVitals.Click
        GetSelectedVitals
    End Sub

    Private Sub GetSelectedVitals()
        With dGridPatientsList
            If .RowCount <= 0 Then Exit Sub
            If Not Object.Equals(.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(0).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(0).Value.ToString) Then
                        intSelectedPatient = CInt(.CurrentRow.Cells(0).Value.ToString)
                        If Not Object.Equals(.CurrentRow.Cells(1).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.CurrentRow.Cells(1).Value.ToString) Then
                                strSelectedAccountName = .CurrentRow.Cells(1).Value.ToString
                            End If
                        End If
                        boolEditStatus = False
                        Dim frm As New frmVitalsEntry
                        frm.ShowDialog()
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub dGridPatientsList_DoubleClick(sender As Object, e As EventArgs) Handles dGridPatientsList.DoubleClick
        On Error Resume Next
        GetSelectedVitals()
    End Sub

    Private Sub txtPatientSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPatientSearch.KeyDown
        If e.KeyValue = Keys.Enter Then
            GetSelectedVitals()
        End If
    End Sub

    Private Sub btnDispensingCiphers_Click(sender As Object, e As EventArgs) Handles btnDispensingCiphers.Click
        Dim frm As New frmDispensingCiphersListing
        frm.ShowDialog()
    End Sub

    Private Sub btnAdminMethods_Click(sender As Object, e As EventArgs) Handles btnAdminMethods.Click
        Dim frm As New frmDrugsAdministrationMethods
        frm.ShowDialog()
    End Sub

    Private Sub btnExtras_Click(sender As Object, e As EventArgs) Handles btnExtras.Click
        Dim frm As New frmExtrasAndServicesListing
        frm.ShowDialog()
    End Sub

    Private Sub ButtonItem1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem1.Click
        With dGridPatientsList
            If .RowCount <= 0 Then Exit Sub
            If Not Object.Equals(.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(0).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(0).Value.ToString) Then
                        intSelectedPatient = CInt(.CurrentRow.Cells(0).Value.ToString)
                        If Not Object.Equals(.CurrentRow.Cells(1).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.CurrentRow.Cells(1).Value.ToString) Then
                                strSelectedAccountName = .CurrentRow.Cells(1).Value.ToString
                            End If
                        End If
                        boolEditStatus = False
                        Dim frm As New frmExaminations
                        frm.ShowDialog()
                    End If
                End If
            End If
        End With
    End Sub
End Class