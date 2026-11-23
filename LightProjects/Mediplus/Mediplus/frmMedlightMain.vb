Imports System.IO
Imports System.Text
Imports System.ComponentModel
Imports DevComponents.DotNetBar
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing.Printing

Public Class frmMedlightMain

    Dim boolFormLoading As Boolean
    Dim dblInitialQuantity As Double
    Dim arrInvoiceData As ArrayList
    Dim arrPrintDetails As ArrayList
    Dim strType As String

    Dim strSelectedReport As String
    Dim prFont As New Font("Arial", 8, FontStyle.Regular)
    Dim tlFont As New Font("Arial", 8, FontStyle.Bold)
    Dim HeaderFont As New Font("Arial", 12, FontStyle.Bold)

    Dim strNavigateDirection As String = Nothing
    Dim boolHeaderClicked As Boolean = False
    Dim strViewMode As String = "USER BRANCH"

    Private Sub LoadMedicinesData()
        On Error GoTo RaiseErr

        'Update for the serial numbers table
        Dim strSql As String = "SELECT ProductCode as [Drug Code], ProductName as [Product Name], Category, " _
            & "ManCode AS [Manf], Strength as [Strength], StandardPackSize AS [Pack Size], " _
            & "GenericIndicator as [B/G], CAST(SellPrice AS decimal(10,2)) AS [Price] " _
            & "FROM OchmasSystemMedicines ORDER BY ProductName"

        dGridMedicines.Columns.Clear()
        'Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridMedicines.DataSource = dTable

        dGridMedicines.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        For i As Integer = 0 To dGridMedicines.Columns.Count - 1
            If i = dGridMedicines.Columns.Count - 1 Then
                dGridMedicines.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        lblTotalRecords.Text = dGridMedicines.Rows.Count
        Exit Sub
RaiseErr:
        boolAbort = False
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Medicines Listing Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmMedlightMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        boolFormLoading = True
        gwt_comm = New CommonLibrary.Commons.CommonFunctions
        gwt_comm.UserAuthentication()
        If boolAbort = True Then Exit Sub
        LoadMedicinesData()
        LoadScriptsData(dpStartFrom.Value, dpEndTo.Value)
        cboSearchBy.SelectedIndex = 1
        sideNav1.TabIndex = 0

        LoadPatientData()
        dGridSalesEntry.Rows.Add(1)
        If Not String.IsNullOrEmpty(strUserName) Then
            lblUsername.Text = UCase(Mid(strUserName, 1, 1)) & LCase(Mid(strUserName, 2, (strUserName.Length - 1)))
        End If
        dGridSalesEntry.Select()
        dGridSalesEntry.CurrentCell = dGridSalesEntry.Rows(0).Cells(0)

        InventoryFormDataLoad()

        boolFormLoading = False
    End Sub

    Private Sub GetSelectedDetails()
        Dim CurrentCellValue As String
        On Error Resume Next
        CurrentCellValue = dGridMedicines.CurrentRow.Cells(0).Value.ToString
        strDrugCode = CurrentCellValue
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If dGridMedicines.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedDetails()
            If Not String.IsNullOrEmpty(strDrugCode) Then
                Dim f As New frmDrugSetup
                f.ShowDialog()
            End If
            SearchForItem("")
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadMedicinesData()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        If boolFormLoading = True Then Exit Sub
        On Error GoTo RaiseErr
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        Cursor = Cursors.WaitCursor

        dGridMedicines.Columns.Clear()

        Dim strSql As String = Nothing
        dGridMedicines.DataSource = Nothing

        Select Case cboSearchBy.SelectedIndex
            Case Is = 0
                strSql = "SELECT ProductCode as [Drug Code], ProductName as [Product Name], Category, " _
                    & "ManCode AS [Manf], Strength as [Strength], StandardPackSize AS [Pack Size], " _
                    & "GenericIndicator as [B/G], CAST(SellPrice AS decimal(10,2)) AS [Price] " _
                    & "FROM OchmasSystemMedicines WHERE ProductCode LIKE '%" & strFind & "%' ORDER BY ProductCode"

            Case Is = 1
                strSql = "SELECT ProductCode as [Drug Code], ProductName as [Product Name], Category, " _
                    & "ManCode AS [Manf], Strength as [Strength], StandardPackSize AS [Pack Size], " _
                    & "GenericIndicator as [B/G], CAST(SellPrice AS decimal(10,2)) AS [Price] " _
                    & "FROM OchmasSystemMedicines WHERE ProductName LIKE '%" & strFind & "%' ORDER BY ProductName, ProductCode"

            Case Else
                strSql = "SELECT ProductCode as [Drug Code], ProductName as [Product Name], Category, " _
                    & "ManCode AS [Manf], Strength as [Strength], StandardPackSize AS [Pack Size], " _
                    & "GenericIndicator as [G/B], CAST(SellPrice AS decimal(10,2)) AS [Price] " _
                    & "FROM OchmasSystemMedicines WHERE ProductCode LIKE '%" & strFind & "%' ORDER BY ProductCode"
        End Select

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridMedicines.DataSource = dTable

        dGridMedicines.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        lblTotalRecords.Text = dGridMedicines.Rows.Count

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Medicines Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ProductCode as [Drug Code], ProductName as [Product Name], Category, " _
                    & "Classification, GenericIndicator as [G/B], CAST(SellPrice AS decimal(10,2)) AS [Price], Quantity " _
                    & "FROM OchmasSystemMedicines ORDER BY ProductName, MedpraxProductCode", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        'Assign the values to the print array
        Dim arrPrintData As New ArrayList
        While objReader.Read
            Dim strDataRow As String = Nothing
            For i As Integer = 0 To objReader.FieldCount - 1
                If i = 0 Then
                    If Not IsDBNull(objReader(i).ToString) Then strDataRow = objReader(i).ToString & ";" Else strDataRow = ";"
                Else
                    strDataRow = strDataRow & objReader(i).ToString & ";"
                End If
            Next
            strDataRow = Mid(strDataRow, 1, (strDataRow.Length - 1))
            arrPrintData.Add(strDataRow)
        End While
        objReader.Close()

        'Add the details to the print class print array

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 7
            .strColumnHeaders = "CODE|DESCRIPTION|CATEGORY|CLASS|GENERIC|UNIT $|QTY"
            .strColumnAlignments = "0|0|0|0|0|2|2"
            .strColumnWidths = "120|140|140|80|50|50|50"
            .strFooterCaption = "Medicines Analysis Report "
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "MEDICINES REPORT"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|NO|YES|YES"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("LightGray")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|YES|YES|YES"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Medicines Report Print"
        ShowErrorMessage()
    End Sub

    Private Sub txtSearchString_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearchString.KeyDown
        If e.KeyValue = Keys.Down Then
            If Not String.IsNullOrEmpty(txtSearchString.Text) Then
                dGridMedicines.Focus()
            Else
                SearchForItem("")
            End If
        End If
    End Sub

    'Private Sub txtSearchString_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchString.TextChanged
    '    SearchForItem("")
    'End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim f As New frmDrugSetup
        f.ShowDialog()
        LoadMedicinesData()
    End Sub

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click

        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        Dim strFileName As String = ofd.FileName

        Dim p As Integer = 0
        Dim strCurrentLine As String = Nothing

        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        If Not String.IsNullOrEmpty(strFileName) Then
            If File.Exists(strFileName) Then
                Dim objFileReader As New StreamReader(strFileName)
                Dim strData As String = objFileReader.ReadToEnd
                objFileReader.Close()

                Dim strLineDetails() As String = Split(strData, vbCrLf)

                With ProgressBar1
                    .Value = 0
                    .Visible = True
                    .Maximum = strLineDetails.Length + 10
                End With

                For p = 0 To strLineDetails.Length - 2

                    strCurrentLine = strLineDetails(p)

                    Dim strProductCode As String = Nothing
                    Dim strProductName As String = Nothing
                    Dim strManufacture As String = Nothing
                    Dim strStrength As String = Nothing
                    Dim strPackage As String = Nothing
                    Dim strDrugClass As String = Nothing
                    Dim strEffectiveDate As String = "01-JAN-1950"
                    Dim strDischargeDate As String = Nothing

                    strProductCode = Trim(Mid(strLineDetails(p), 1, 6))
                    strProductName = Trim(Mid(strLineDetails(p), 9, 40))
                    strManufacture = Trim(Mid(strLineDetails(p), 51, 4))

                    strStrength = Trim(Mid(strLineDetails(p), 57, 10))
                    strPackage = Trim(Mid(strLineDetails(p), 69, 10))
                    strDrugClass = Trim(Mid(strLineDetails(p), 81, 4))
                    strEffectiveDate = Trim(Mid(strLineDetails(p), 99, 8))
                    strDischargeDate = Trim(Mid(strLineDetails(p), 131, 8))

                    strProductName = Replace(strProductName, "'", "-", 1)
                    strProductName = Replace(strProductName, Chr(34), "-", 1)
                    strStrength = Replace(strStrength, "'", "-", 1)
                    strStrength = Replace(strStrength, Chr(34), "-", 1)
                    strPackage = Replace(strPackage, "'", "-", 1)
                    strPackage = Replace(strPackage, Chr(34), "-", 1)

                    If Not String.IsNullOrEmpty(strEffectiveDate) Then
                        Dim strSplitted() As String = Split(strEffectiveDate, "/")
                        If strSplitted.Length > 2 Then
                            strEffectiveDate = Format(CInt(strSplitted(0)), "00") & "-" & _
                                MonthName(CInt(strSplitted(1)), True) & "-" & _
                                Format(CInt(strSplitted(2)), "00")
                        End If
                    End If

                    If Not String.IsNullOrEmpty(strDischargeDate) Then
                        Dim strSplitted() As String = Split(strDischargeDate, "/")
                        If strSplitted.Length > 2 Then
                            strDischargeDate = Format(CInt(strSplitted(0)), "00") & "-" & _
                                MonthName(CInt(strSplitted(1)), True) & "-" & _
                                Format(CInt(strSplitted(2)), "00")
                        End If
                    End If

                    Dim strSql As String = Nothing

                    If Not String.IsNullOrEmpty(strProductCode) Then
                        If Not String.IsNullOrEmpty(strProductName) Then
                            If Not String.IsNullOrEmpty(strDischargeDate) Then
                                strSql = "INSERT INTO OchmasSystemMedicines ([ProductCode], [ProductName], " _
                                    & "[ManCode], [Strength], [StandardPackSize], [Classification], " _
                                    & "[EffectiveDate], [DischargeDate]) VALUES ('" & strProductCode & "', " _
                                    & "'" & strProductName & "', '" & strManufacture & "', '" & strStrength & "', " _
                                    & "'" & strPackage & "', '" & strDrugClass & "', '" & UCase(strEffectiveDate) & "', " _
                                    & "'" & UCase(strDischargeDate) & "')"
                            Else
                                strSql = "INSERT INTO OchmasSystemMedicines ([ProductCode], [ProductName], " _
                                    & "[ManCode], [Strength], [StandardPackSize], [Classification], " _
                                    & "[EffectiveDate]) VALUES ('" & strProductCode & "', " _
                                    & "'" & strProductName & "', '" & strManufacture & "', '" & strStrength & "', " _
                                    & "'" & strPackage & "', '" & strDrugClass & "', '" & UCase(strEffectiveDate) & "')"
                            End If

                            'Delete the medicine if it already exist and then insert the new one

                            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM OchmasSystemMedicines " _
                                & "WHERE ProductCode = '" & strProductCode & "'", cnn)
                            objCommand.ExecuteNonQuery()

                            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                            objCommand.ExecuteNonQuery()
                        End If
                    End If

                    ProgressBar1.Value = ProgressBar1.Value + 1

                Next

                ProgressBar1.Value = ProgressBar1.Maximum
                Cursor = Cursors.Default
                MessageBox.Show("Medicines have been imported successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadMedicinesData()

            End If

        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & strCurrentLine & vbCrLf & "On Medicines Data Import"
        ShowErrorMessage()
    End Sub

    Private Sub btnManufacturers_Click(sender As System.Object, e As System.EventArgs) Handles btnManufacturers.Click
        Dim frm As New frmDrugManufacturers
        frm.ShowDialog()
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridMedicines.DoubleClick
        If dGridMedicines.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedDetails()
            Dim f As New frmDrugSetup
            f.ShowDialog()
            SearchForItem("")
        End If
    End Sub

    Private Sub btnDrugCategories_Click(sender As System.Object, e As System.EventArgs) Handles btnDrugCategories.Click
        Dim frm As New frmDrugCategories
        frm.ShowDialog()
    End Sub

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        LoadScriptsData(dpStartFrom.Value, dpEndTo.Value)
    End Sub

    Private Sub LoadScriptsData(StartingDate As Date, EndingDate As Date)
        On Error GoTo RaiseErr
        'Get the detailed information from the details table
        'Item, Code, Qty, Unit Price, Cost, Discount, Vat, Payable

        Dim strSql As String = "SELECT DispensingMain.PrescriptionNumber as [Ref.#], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), DispensingMain.TransactionDate, 106), ' ', '-')) as [Date], " _
            & "PatientNames AS [Patient], PatientMemberNames as [Main Member], PatientMemberNumber as [Medaid #], " _
            & "PatientSuffix as [Sfx], CAST(SUM(((DispensingDetails.Quantity * DispensingDetails.SellingPrice) - " _
            & "DispensingDetails.Discount) + DispensingDetails.Taxes) AS DECIMAL (10,2)) AS [Value] FROM DispensingMain " _
            & "LEFT OUTER JOIN DispensingDetails ON DispensingMain.PrescriptionNumber = DispensingDetails.PrescriptionNumber " _
            & "WHERE DispensingMain.TransactionDate BETWEEN '" & Format(StartingDate, "dd-MMM-yyyy") & "' AND '" & Format(EndingDate, "dd-MMM-yyyy") & "' " _
            & "GROUP BY DispensingMain.PrescriptionNumber, DispensingMain.TransactionDate, DispensingMain.PatientNames, " _
            & "DispensingMain.PatientMemberNames, DispensingMain.PatientMemberNumber, DispensingMain.PatientSuffix"

        dGridDispensing.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridDispensing.DataSource = dTable

        For i As Integer = 0 To dGridDispensing.ColumnCount - 1
            Me.dGridDispensing.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If i = dGridDispensing.ColumnCount - 1 Then
                Me.dGridDispensing.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        '
        Me.dGridDispensing.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Prescribed Patient Data Load"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr
        Dim dblTotal As Double = 0
        For i As Integer = 0 To dGridDispensing.Rows.Count - 1
            If Not Object.Equals(dGridDispensing.Rows(i).Cells(dGridDispensing.ColumnCount - 1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridDispensing.Rows(i).Cells(dGridDispensing.ColumnCount - 1).Value.ToString) Then
                    If IsNumeric(dGridDispensing.Rows(i).Cells(dGridDispensing.ColumnCount - 1).Value.ToString) Then
                        dblTotal = dblTotal + CDbl(dGridDispensing.Rows(i).Cells(dGridDispensing.ColumnCount - 1).Value.ToString)
                    End If
                End If
            End If
        Next
        lblDispensingTotal.Text = Format(dblTotal, "##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Prescriptions Data Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnEditDispense_Click(sender As System.Object, e As System.EventArgs) Handles btnEditDispense.Click
        If dGridDispensing.Rows.Count > 0 Then
            GetSelectedDispense()
            boolEditStatus = True
            Dim frm As New frmDispensingProcess
            frm.ShowDialog()
            LoadScriptsData(dpStartFrom.Value, dpEndTo.Value)
        End If
    End Sub

    Private Sub GetSelectedDispense()
        If Not Object.Equals(dGridDispensing.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridDispensing.CurrentRow.Cells(0).Value.ToString) Then
                If IsNumeric(dGridDispensing.CurrentRow.Cells(0).Value.ToString) Then
                    intSelectedTransaction = CInt(dGridDispensing.CurrentRow.Cells(0).Value.ToString)
                End If
            End If
        End If
    End Sub

    Private Sub btnNewDispense_Click(sender As System.Object, e As System.EventArgs) Handles btnNewDispense.Click
        boolEditStatus = False
        Dim frm As New frmDispensingStart ' frmDispensingProcess
        frm.ShowDialog()
        LoadScriptsData(dpStartFrom.Value, dpEndTo.Value)
    End Sub

    Private Sub btnRefreshDispense_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshDispense.Click
        LoadScriptsData(dpStartFrom.Value, dpEndTo.Value)
    End Sub

    Private Sub dGridDispensing_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridDispensing.DoubleClick
        If dGridDispensing.Rows.Count > 0 Then
            GetSelectedDispense()
            boolEditStatus = True
            Dim frm As New frmDispensingProcess
            frm.ShowDialog()
            LoadScriptsData(dpStartFrom.Value, dpEndTo.Value)
        End If
    End Sub

    Private Sub sideNav1_StyleChanged(sender As Object, e As System.EventArgs) Handles sideNav1.StyleChanged
        Me.Refresh()
    End Sub

    Private Sub mnuDrugInformation_Click(sender As System.Object, e As System.EventArgs) Handles mnuDrugInformation.Click
        'GetSelectedDetails()
        'Dim frm As New frmDrugInformation
        'frm.ShowDialog()
    End Sub

    Private Sub mnuAlternateDrugName_Click(sender As System.Object, e As System.EventArgs) Handles mnuAlternateDrugName.Click
        GetSelectedDetails()
        Dim frm As New frmDrugAlternatives
        frm.ShowDialog()
    End Sub

    Private Sub btnDispensingCiphers_Click(sender As System.Object, e As System.EventArgs) Handles btnDispensingCiphers.Click
        Dim frm As New frmDispensingCiphersListing
        frm.ShowDialog()
    End Sub

    Private Sub btnPrepacks_Click(sender As System.Object, e As System.EventArgs) Handles btnPrepacks.Click
        Dim frm As New frmPrintPrepacks
        frm.ShowDialog()
    End Sub

    Private Sub btnOrganisation_Click(sender As System.Object, e As System.EventArgs) Handles btnOrganisation.Click
        On Error GoTo RaiseErr
        Dim strFilename As String = Application.StartupPath & "\gwtOrganization.exe"
        'If ApplicationIsLicensed(strFilename) = True Then
        Cursor = Cursors.WaitCursor
        Shell(strFilename, AppWinStyle.NormalFocus, False)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        MessageBox.Show("The called module is not licensed on your computer" & vbCrLf & _
            "Please contact your software provider for assistance", "Application Licensing Error",
            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
    End Sub

    '*****************************************************************************************
    ' SALES CASHOUT PROCEDURES                                                               *
    '*****************************************************************************************

    Private Sub LoadPatientData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT DISTINCT (PatientNames) +';'+ CONVERT(NVARCHAR, PrescriptionNumber) +';'+ " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) +';'+ CONVERT(NVARCHAR, PatientReferenceNumber) as [Details] " _
            & "FROM DispensingMain WHERE TransactionDate = '" & Format(dpTransDate.Value, "dd-MMM-yyyy") & "'"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboPatientName
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 4
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "200;40;80;40"
        End With

        Dim arrData As New ArrayList
        'Add in the blank walk in client data
        arrData.Add("WALK-IN CLIENT;0;" & Format(Now, "dd-MMM-yyyy") & ";0")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Get a count of the items
        Dim intItemsCount As Double = arrData.Count
        Dim DropDownItems(0 To (intItemsCount - 1)) As MTGCComboBoxItem

        cboPatientName.Items.Clear()

        For p As Integer = 0 To arrData.Count - 1
            Dim strRecordText() As String = Split(arrData.Item(p), ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2), strRecordText(3))
        Next

        If intItemsCount > 0 Then
            cboPatientName.SelectedIndex = -1
            cboPatientName.Items.Clear()
            cboPatientName.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboPatientName.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Prescribed Patient Data Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboPatientName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPatientName.SelectedIndexChanged
        If boolFormLoading = True Then Exit Sub
        lblPrescriptionNo.Text = Nothing
        txtPatientId.Text = "0"
        If Not String.IsNullOrEmpty(cboPatientName.Text) Then
            lblPrescriptionNo.Text = cboPatientName.SelectedItem.Col2
            txtPatientId.Text = cboPatientName.SelectedItem.Col4
            If IsNumeric(lblPrescriptionNo.Text) Then
                LoadPrescriptionDetails(CInt(lblPrescriptionNo.Text), CDate(Format(dpTransDate.Value, "dd-MMM-yyyy")))
            End If
        End If
    End Sub

    Private Sub dpTransDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dpTransDate.ValueChanged
        If boolFormLoading = True Then Exit Sub
        LoadPatientData()
        If IsNumeric(lblPrescriptionNo.Text) Then
            LoadPrescriptionDetails(CInt(lblPrescriptionNo.Text), CDate(Format(dpTransDate.Value, "dd-MMM-yyyy")))
        End If
    End Sub

    Private Sub LoadPrescriptionDetails(ByVal PrescriptionId As Integer, ByVal TransactionDate As Date)
        On Error GoTo RaiseErr
        'Get the detailed information from the details table
        'Item, Code, Qty, Unit Price, Cost, Discount, Vat, Payable

        Dim strSql As String = "SELECT DispensingDetails.DrugName, DispensingDetails.DrugCode, " _
            & "CAST(DispensingDetails.Quantity AS DECIMAL (10,2)) AS [Qty], " _
            & "CAST(DispensingDetails.SellingPrice AS DECIMAL (10,2)) AS [Unit Price], " _
            & "CAST((DispensingDetails.SellingPrice * DispensingDetails.Quantity) AS DECIMAL (10,2)) AS [Cost], " _
            & "CAST(DispensingDetails.Discount AS DECIMAL (10,2)) AS [Discount], " _
            & "CAST(DispensingDetails.Taxes AS DECIMAL (10,2)) AS [Taxes], " _
            & "CAST((((DispensingDetails.Quantity * DispensingDetails.SellingPrice) - DispensingDetails.Discount) + DispensingDetails.Taxes) AS DECIMAL (10,2)) AS [Payable], " _
            & "DispensingDetails.TransactionId AS [Id] FROM DispensingDetails LEFT OUTER JOIN DispensingMain ON " _
            & "DispensingDetails.PrescriptionNumber = DispensingMain.PrescriptionNumber " _
            & "WHERE DispensingDetails.PrescriptionNumber = " & PrescriptionId & " AND " _
            & "DispensingMain.TransactionDate = '" & TransactionDate & "' AND Status = 'PENDING'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        If dGridItems.Rows.Count > 0 Then
            If MessageBox.Show("Do you want to clear the items already entered?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                dGridItems.Rows.Clear()
            End If
        End If

        While objReader.Read
            dGridItems.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5), objReader(6), objReader(7), "Drugs", "P", objReader(8))
        End While
        objReader.Close()
        boolAbort = False
        ComputePaymentTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Prescribed Patient Data Load"
        ShowErrorMessage()
    End Sub

    Private Sub ComputePaymentTotals()
        On Error GoTo RaiseErr
        'Item, Code, Qty, Unit Price, Cost, Discount, Vat, Payable
        With dGridItems
            Dim dblTotalCost As Double = 0
            Dim dblTotalTaxes As Double = 0
            Dim dblTotalPayable As Double = 0
            Dim dblTotalDiscounts As Double = 0
            For p As Integer = 0 To .Rows.Count - 1
                Dim dblQty As Double = 0
                Dim dblCostPrice As Double = 0
                Dim dblPayable As Double = 0
                Dim dblTaxes As Double = 0
                Dim dblDiscounts As Double = 0
                If Not Object.Equals(.Rows(p).Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(2).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(2).Value.ToString) Then
                            dblQty = CDbl(.Rows(p).Cells(2).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(4).Value.ToString) Then
                            dblCostPrice = CDbl(.Rows(p).Cells(4).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(5).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(5).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(5).Value.ToString) Then
                            dblDiscounts = CDbl(.Rows(p).Cells(5).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(6).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(6).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(6).Value.ToString) Then
                            dblTaxes = CDbl(.Rows(p).Cells(6).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(7).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(7).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(7).Value.ToString) Then
                            dblPayable = CDbl(.Rows(p).Cells(7).Value.ToString)
                        End If
                    End If
                End If
                dblTotalCost = dblTotalCost + dblCostPrice
                dblTotalTaxes = dblTotalTaxes + dblTaxes
                dblTotalDiscounts = dblTotalDiscounts + dblDiscounts
                dblTotalPayable = dblTotalPayable + dblPayable
            Next
            lblCostPrice.Text = Format(dblTotalCost, "#,##0.00")
            lblVat.Text = Format(dblTotalTaxes, "#,##0.00")
            lblDiscounts.Text = Format(dblTotalDiscounts, "#,##0.00")
            lblPayable.Text = Format(dblTotalPayable, "#,##0.00")
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Prescribed Patient Data Load"
        ShowErrorMessage()
    End Sub

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGridEntry_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dGridSalesEntry.CellBeginEdit
        If e.ColumnIndex = 3 Then
            If Not Object.Equals(dGridSalesEntry.CurrentRow.Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridSalesEntry.CurrentRow.Cells(3).Value.ToString) Then
                    If IsNumeric(dGridSalesEntry.CurrentRow.Cells(3).Value.ToString) Then
                        dblInitialQuantity = CDbl(dGridSalesEntry.CurrentRow.Cells(3).Value.ToString)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dGridEntry_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridSalesEntry.CellEndEdit
        'Item, Code, Qty, Unit Price, Cost, Discount, Vat, Payable
        If dGridSalesEntry.CurrentCell.ColumnIndex = 3 Or dGridSalesEntry.CurrentCell.ColumnIndex = 6 Then
            If IsNumeric(dGridSalesEntry.CurrentCell.Value) Then
                dGridSalesEntry.CurrentCell.Value = Format(CDbl(dGridSalesEntry.CurrentCell.Value.ToString), "##0.00")
            Else
                dGridSalesEntry.CurrentCell.Value = "0.00"
            End If
            RecalculateValues()
        End If
    End Sub

    Private Sub dGridEntry_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridSalesEntry.EditingControlShowing
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

    Private Sub RecalculateValues()
        On Error GoTo RaiseErr
        'Get the value of the unit price and that of the tax and quantity
        'Item, Code, Qty, Unit Price, Cost, Discount, Vat, Payable

        Dim dblQuantity As Double = 0
        Dim dblUnitPrice As Double = 0
        Dim dblUnitTaxes As Double = 0
        Dim dblDiscounts As Double = 0
        Dim dblSubTotalCost As Double = 0
        If Not Object.Equals(dGridSalesEntry.CurrentRow.Cells(3).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridSalesEntry.CurrentRow.Cells(3).Value.ToString) Then
                If IsNumeric(dGridSalesEntry.CurrentRow.Cells(3).Value.ToString) Then
                    dblQuantity = CDbl(dGridSalesEntry.CurrentRow.Cells(3).Value.ToString)
                End If
            End If
        End If

        If Not Object.Equals(dGridSalesEntry.CurrentRow.Cells(4).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridSalesEntry.CurrentRow.Cells(4).Value.ToString) Then
                If IsNumeric(dGridSalesEntry.CurrentRow.Cells(4).Value.ToString) Then
                    dblUnitPrice = CDbl(dGridSalesEntry.CurrentRow.Cells(4).Value.ToString)
                End If
            End If
        End If

        If Not Object.Equals(dGridSalesEntry.CurrentRow.Cells(6).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridSalesEntry.CurrentRow.Cells(6).Value.ToString) Then
                If IsNumeric(dGridSalesEntry.CurrentRow.Cells(6).Value.ToString) Then
                    dblDiscounts = CDbl(dGridSalesEntry.CurrentRow.Cells(6).Value.ToString)
                End If
            End If
        End If

        If UCase(strTaxComputationType) = "INCLUSIVE" Then
            If strSelectedItemTaxStatus = "YES" Then
                dblUnitPrice = (dblUnitPrice / (100 + dblSalesTaxRate)) * 100 '(dblTax / dblQuantity)
            End If
        End If

        'Recompute tax
        Dim dblTax As Double = 0
        Dim dblTaxableAmount As Double = 0
        dblTaxableAmount = (dblQuantity * dblUnitPrice) - dblDiscounts

        If strSelectedItemTaxStatus = "YES" Then
            dblTax = VatComputation(dblTaxableAmount)
        End If

        'Assign total cost
        dGridSalesEntry.CurrentRow.Cells(5).Value = Format((dblUnitPrice * dblQuantity), "##0.00")

        'Assign tax amount
        dGridSalesEntry.CurrentRow.Cells(7).Value = Format(dblTax, "##0.00")

        'Assign payable
        dGridSalesEntry.CurrentRow.Cells(8).Value = Format((((dblUnitPrice * dblQuantity) - dblDiscounts) + dblTax), "##0.00")

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Items Cashout"
        ShowErrorMessage()
    End Sub

    Private Sub dGridEntriy_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridSalesEntry.KeyDown
        If e.KeyValue = 9 Then
            'frmCashoutItemTypes
            If dGridSalesEntry.CurrentCell.ColumnIndex = 0 Then
                strSelectedDescription = Nothing
                boolAbort = False
                Dim f As New frmSalesEntryType
                f.ShowDialog()
                If boolAbort = True Then Exit Sub
                dGridSalesEntry.CurrentRow.Cells(0).Value = strSelectedDescription
                dGridSalesEntry.CurrentCell = dGridSalesEntry.CurrentRow.Cells(1)
            End If

            If dGridSalesEntry.CurrentCell.ColumnIndex = 1 Then

                Dim strItemType As String = Nothing
                If Not Object.Equals(dGridSalesEntry.CurrentRow.Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridSalesEntry.CurrentRow.Cells(0).Value.ToString) Then
                        strItemType = dGridSalesEntry.CurrentRow.Cells(0).Value.ToString
                    End If
                End If

                'Verify if entry type has been selected
                If Not String.IsNullOrEmpty(strItemType) Then
                    strSelectedCode = Nothing
                    strSelectedCodeDescription = Nothing
                    boolAbort = False
                    strCallingForm = "CASHOUT"
                    Dim frm As Form
                    If UCase(strItemType) = UCase("Drugs") Then
                        frm = New frmDrugSearch
                    Else
                        frm = New frmFindInventory
                    End If
                    frm.ShowDialog()

                    If boolAbort = True Then
                        e.SuppressKeyPress = True
                        'dGridEntriy.CurrentCell = dGridEntriy.CurrentRow.Cells(0)
                    Else
                        dGridSalesEntry.CurrentCell.Value = strSelectedCodeDescription
                        dGridSalesEntry.CurrentRow.Cells(2).Value = strSelectedCode
                        dGridSalesEntry.CurrentRow.Cells(dGridSalesEntry.ColumnCount - 1).Value = strSelectedItemTaxStatus

                        Dim dblUnitPrice As Double = 0
                        If UCase(strItemType) = UCase("Drugs") Then
                            dblUnitPrice = UnitPrice(strSelectedCode, "Drugs")
                        Else
                            dblUnitPrice = UnitPrice(strSelectedCode, "Extras")
                        End If

                        Dim dblTax As Double = 0
                        If strSelectedItemTaxStatus = "YES" Then
                            If UCase(strTaxComputationType) = "INCLUSIVE" Then
                                dblUnitPrice = dblUnitPrice - dblTax
                            End If
                            dblTax = VatComputation(dblUnitPrice)
                        End If

                        'Item, Code, Qty, Unit Price, Cost, Discount, Vat, Payable

                        dGridSalesEntry.CurrentRow.Cells(3).Value = "1.00"
                        dGridSalesEntry.CurrentRow.Cells(4).Value = Format(dblUnitPrice, "##0.00")
                        dGridSalesEntry.CurrentRow.Cells(5).Value = Format((dblUnitPrice * 1), "##0.00")
                        dGridSalesEntry.CurrentRow.Cells(6).Value = "0.00"
                        dGridSalesEntry.CurrentRow.Cells(7).Value = Format(dblTax, "##0.00")

                        Dim dblLineTotal As Double = dblUnitPrice * 1 + dblTax
                        dGridSalesEntry.CurrentRow.Cells(8).Value = Format(dblLineTotal, "##0.00")

                        dGridSalesEntry.CurrentCell = dGridSalesEntry.CurrentRow.Cells(2)

                        Exit Sub

                    End If
                Else
                    MessageBox.Show("Please enter the item type first before item code entry", "Missing Item Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGridSalesEntry.CurrentCell = dGridSalesEntry.CurrentRow.Cells(0)
                    Exit Sub
                End If
            End If

            If dGridSalesEntry.CurrentCell.ColumnIndex = dGridSalesEntry.ColumnCount - 2 Then
                'Check that the data is correctly entered
                Dim strDrugName As String = Nothing
                Dim strDrugCode As String = Nothing
                Dim dblQuantity As Double = 0
                Dim dblPrice As Double = 0
                Dim dblVat As Double = 0
                Dim dblPayable As Double = 0

                e.SuppressKeyPress = True
                If Not Object.Equals(dGridSalesEntry.CurrentRow.Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridSalesEntry.CurrentRow.Cells(1).Value.ToString) Then
                        strDrugName = dGridSalesEntry.CurrentRow.Cells(1).Value.ToString
                    End If
                End If
                If Not Object.Equals(dGridSalesEntry.CurrentRow.Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridSalesEntry.CurrentRow.Cells(2).Value.ToString) Then
                        strDrugCode = dGridSalesEntry.CurrentRow.Cells(2).Value.ToString
                    End If
                End If
                If Not Object.Equals(dGridSalesEntry.CurrentRow.Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridSalesEntry.CurrentRow.Cells(3).Value.ToString) Then
                        If IsNumeric(dGridSalesEntry.CurrentRow.Cells(3).Value.ToString) Then
                            dblQuantity = dGridSalesEntry.CurrentRow.Cells(3).Value.ToString
                        End If
                    End If
                End If

                If String.IsNullOrEmpty(strDrugName) Then
                    MessageBox.Show("Missing the drug name. Please correct this error", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGridSalesEntry.CurrentCell = dGridSalesEntry.CurrentRow.Cells(1)
                    Exit Sub
                End If

                If String.IsNullOrEmpty(CStr(dblQuantity)) Then
                    MessageBox.Show("Missing the dispensing quantity. Please correct this error", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGridSalesEntry.CurrentCell = dGridSalesEntry.CurrentRow.Cells(3)
                    Exit Sub
                End If

                If String.IsNullOrEmpty(strDrugCode) Then
                    MessageBox.Show("Missing the drug code. Please correct this error", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dGridSalesEntry.CurrentCell = dGridSalesEntry.CurrentRow.Cells(1)
                    Exit Sub
                End If

                Dim strItemFlag As String = "Extras"
                If dGridSalesEntry.CurrentRow.Cells(0).Value.ToString = "Drugs" Then
                    strItemFlag = "Drugs"
                End If
                dGridItems.Rows.Add(dGridSalesEntry.Rows(0).Cells(1).Value, _
                dGridSalesEntry.Rows(0).Cells(2).Value, _
                dGridSalesEntry.Rows(0).Cells(3).Value, _
                dGridSalesEntry.Rows(0).Cells(4).Value, _
                dGridSalesEntry.Rows(0).Cells(5).Value, _
                dGridSalesEntry.Rows(0).Cells(6).Value, _
                dGridSalesEntry.Rows(0).Cells(7).Value, _
                dGridSalesEntry.Rows(0).Cells(8).Value, _
                strItemFlag, "C", "0")

                ComputePaymentTotals()

                'Reset the grid values to nothing 
                For p As Integer = 0 To dGridSalesEntry.ColumnCount - 1
                    dGridSalesEntry.Rows(0).Cells(p).Value = Nothing
                Next
                dGridSalesEntry.CurrentCell = dGridSalesEntry.CurrentRow.Cells(0)

            End If

        End If
    End Sub

    Private Function VatComputation(Price As Double) As Double
        Dim dblReturn As Double = 0
        If UCase(strTaxComputationType) = "INCLUSIVE" Then
            dblReturn = ((Price * 1) - 0) - (((Price * 1) - 0) * (100 / (100 + dblSalesTaxRate)))
        Else
            dblReturn = Price
        End If
        Return dblReturn
    End Function

    Private Function UnitPrice(Code As String, ItemType As String) As Double
        Dim dblReturn As Double = 0
        Dim strSql As String = Nothing
        If UCase(ItemType) = "DRUGS" Then
            strSql = "SELECT SellPrice FROM OchmasSystemMedicines " _
                & "WHERE ProductCode = '" & Code & "'"
        Else
            strSql = "SELECT SellingPrice FROM InventoryItems " _
                & "WHERE ItemCode = '" & Code & "'"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblReturn = CDbl(objReader(0).ToString)
            End If
        End If
        objReader.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Sales Item Unit Price Fetch"
        ShowErrorMessage()
    End Function

    Private Sub chkOverideDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOverideDate.CheckedChanged
        If chkOverideDate.Checked = True Then
            If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
                dpTransDate.Enabled = True
            Else
                boolAbort = False
                boolAuthorized = False
                Dim f As New frmSupervisorAuthorizaton
                f.ShowDialog()
                If boolAbort = True Then
                    chkOverideDate.Checked = False
                    Exit Sub
                End If
                If boolAuthorized = True Then
                    dpTransDate.Enabled = True
                    boolAuthorized = False
                End If
            End If
        Else
            dpTransDate.Enabled = False
            boolAuthorized = False
        End If
    End Sub

    Private Sub btnFinish_Click(sender As System.Object, e As System.EventArgs) Handles btnFinishCashout.Click
        If dGridItems.Rows.Count > 0 Then
            If String.IsNullOrEmpty(strPublicSalesAccount) Then
                MessageBox.Show("Missing the default sales ledger control account. Please set it up. For now the default will be used", _
                    "Missing Sales Control Account Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                strPublicSalesAccount = "0000"
            End If
            FinishSale()
        Else
            MessageBox.Show("No document transactions to print !!!", "Empty Document Transactions", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub FinishSale()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSqlTransmit As String = Nothing

        Dim insertCustomer As String
        Dim dblTax As Double
        Dim i As Double
        Dim dpProcessDate As Date = Format(DateTime.Now, "dd-MMM-yyyy")
        Dim dblDisAmount As Double 'for discounts
        Dim dblSumTaxes As Double = 0, dblSumDiscounts As Double = 0, dblSumPayable As Double = 0
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim dbReader As Data.OleDb.OleDbDataReader

        Dim strTransactionProcessStatus As String = Nothing

        strTillPaymentMethod = Nothing

        Dim strPersonnel As String = "CASH PAYMENT"

        dblAmountTendered = 0
        dblAmountChange = 0

        'Perform the till ring routine
        boolAbort = False
        dblSaleTotal = CDbl(lblPayable.Text)

        If dblSaleTotal <= 0 Then
            MessageBox.Show("Sale cannot be processed when there are no valid sub total values", _
                "Sale Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        strCustomerTelephoneNumber = Nothing
        strTillCustomerName = Nothing

        Dim f As New frmTenderAmount
        f.ShowDialog()
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))

        If chkOverideDate.Checked = True Then
            dpProcessDate = Format(dpTransDate.Value, "dd-MMM-yyyy")
        End If

        Cursor = Cursors.WaitCursor

        arrInvoiceData = New ArrayList

        For i = 0 To dGridItems.Rows.Count - 1

            If Not (Object.Equals(Convert.ToString(dGridItems.Rows(i).Cells(0).Value), "")) Then

                Dim strSelectedId As String = Nothing
                Dim strDescription As String = Nothing
                Dim intQty As Double = 0
                Dim dblUprice As Double = 0
                Dim intRecordId As Integer = 0
                Dim strRecordFlag As String = Nothing
                Dim strEntryType As String = Nothing

                'Item, Code, Qty, Unit Price, Cost, Discount, Vat, Payable

                strSelectedId = Convert.ToString(dGridItems.Rows(i).Cells(1).Value)
                strDescription = Convert.ToString(dGridItems.Rows(i).Cells(0).Value)
                intQty = Convert.ToDouble(dGridItems.Rows(i).Cells(2).Value)
                dblTax = Convert.ToDouble(dGridItems.Rows(i).Cells(6).Value)
                dblUprice = Convert.ToDouble(dGridItems.Rows(i).Cells(3).Value)
                dblDisAmount = Convert.ToDouble(dGridItems.Rows(i).Cells(5).Value)
                If Not Object.Equals(dGridItems.Rows(i).Cells(dGridItems.ColumnCount - 1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridItems.Rows(i).Cells(dGridItems.ColumnCount - 1).Value.ToString) Then
                        If IsNumeric(dGridItems.Rows(i).Cells(dGridItems.ColumnCount - 1).Value.ToString) Then
                            intRecordId = CInt(dGridItems.Rows(i).Cells(dGridItems.ColumnCount - 1).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(dGridItems.Rows(i).Cells(dGridItems.ColumnCount - 2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridItems.Rows(i).Cells(dGridItems.ColumnCount - 2).Value.ToString) Then
                        strRecordFlag = dGridItems.Rows(i).Cells(dGridItems.ColumnCount - 2).Value.ToString
                    End If
                End If

                If Not Object.Equals(dGridItems.Rows(i).Cells(dGridItems.ColumnCount - 3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridItems.Rows(i).Cells(dGridItems.ColumnCount - 3).Value.ToString) Then
                        strEntryType = dGridItems.Rows(i).Cells(dGridItems.ColumnCount - 3).Value.ToString
                    End If
                End If

                arrInvoiceData.Add(strSelectedId & "|" & strDescription & "|" & intQty & "|" & Format(dblUprice, "##0.00") & _
                    "|" & Format((dblUprice * intQty), "##0.00") & "|" & Format(dblDisAmount, "##0.00") & "|" & Format(dblTax, "##0.00") & _
                    "|" & Format(((dblUprice * intQty) - dblDisAmount) + dblTax, "##0.00"))

                'Get the item cost price
                Dim dblItemCostPrice As Double = 0

                Dim strSqlCostPrice As String = Nothing

                If UCase(strEntryType) = "DRUGS" Then
                    strSqlCostPrice = "SELECT CostPrice FROM OchmasSystemMedicines WHERE ProductCode = '" & strSelectedId & "'"
                Else
                    strSqlCostPrice = "SELECT CostPrice FROM InventoryItems WHERE ItemCode = '" & strSelectedId & "'"
                End If

                Dim ojjGetCostPrice As New Data.OleDb.OleDbCommand(strSqlCostPrice, cnn)
                Dim objReadCostPrice As Data.OleDb.OleDbDataReader = ojjGetCostPrice.ExecuteReader
                If objReadCostPrice.HasRows Then
                    objReadCostPrice.Read()
                    If IsNumeric(objReadCostPrice(0).ToString) Then dblItemCostPrice = CDbl(objReadCostPrice(0).ToString)
                End If
                objReadCostPrice.Close()
                '

                Dim intMasterKey As Integer = gwt_comm.SpecialKey()
                If Not IsNumeric(txtKeyNumber.Text) Then txtKeyNumber.Text = intMasterKey
                Dim strBaseBarCode As String = Nothing

                Dim strLineItemType As String = "Extras"
                If UCase(strEntryType) = "DRUGS" Then
                    strLineItemType = "MEDICINES"
                End If

                Dim strItemSerialNo As String = Nothing

                insertCustomer = "INSERT INTO SALES (CustomerId, InvoiceNumber, TransDate, ItemCode, Quantity, " _
                    & "SalesPrice, TransType, Description, Taxes, DiscountAllowed, ProductType, SerialNumbers, " _
                    & "UserName, SalesRep, CostPrice, KeyNumber, BaseBarcode) VALUES " _
                    & "('" & txtPatientId.Text & "', " & CDbl(txtReference.Text) & ", '" & dpProcessDate & "', " _
                    & "'" & strSelectedId & "', " & intQty & ", " & dblUprice & ", 'CASH SALE', " _
                    & "'" & strDescription & "', " & dblTax & ", " & dblDisAmount & ", " _
                    & "'" & strLineItemType & "', '" & strItemSerialNo & "', '" & lblUsername.Text & "', " _
                    & "'" & strPersonnel & "', " & dblItemCostPrice & ", " & Convert.ToDouble(txtKeyNumber.Text) & ", " _
                    & "'" & strBaseBarCode & "')"
                myCommand = New Data.OleDb.OleDbCommand(insertCustomer, cnn)
                myCommand.ExecuteNonQuery()

                'Insert into cost of sales
                'strPublicCostOfSales
                If Not String.IsNullOrEmpty(strPublicCostOfSales) And Not String.IsNullOrEmpty(strPublicPurchasesAccount) Then
                    myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                        & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                        & "('" & strPublicCostOfSales & "', '" & dpProcessDate & "', " & dblItemCostPrice & ", " _
                        & "'DEBIT', '" & strPublicPurchasesAccount & "', '" & strDescription & "', " _
                        & "'" & strUserName & "', '" & strUserBranch & "', " & CDbl(txtReference.Text) & ", " & Convert.ToDouble(txtKeyNumber.Text) & ")", cnn)
                    myCommand.ExecuteNonQuery()
                    myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                        & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference], [SpecialKey]) VALUES " _
                        & "('" & strPublicPurchasesAccount & "', '" & dpProcessDate & "', " & dblItemCostPrice & ", " _
                        & "'CREDIT', '" & strPublicCostOfSales & "', '" & strDescription & "', " _
                        & "'" & strUserName & "', '" & strUserBranch & "', " & CDbl(txtReference.Text) & ", " & Convert.ToDouble(txtKeyNumber.Text) & ")", cnn)
                    myCommand.ExecuteNonQuery()
                Else
                    MessageBox.Show("The system has detected that you have not set the cost of sales account" & vbCrLf & _
                        "This will seriously affect the ledger account and trial balance", "Missing Cost of Sales Account", _
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                dblSumTaxes = dblSumTaxes + dblTax
                dblSumDiscounts = dblSumDiscounts + dblDisAmount

                'Update quantities in the table

                Dim intStockBalance As Double = 0

                If UCase(strEntryType) = "DRUGS" Then
                    myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity FROM OchmasSystemMedicines WHERE ProductCode = '" & strSelectedId & "'", cnn)
                    dbReader = myCommand.ExecuteReader
                    If dbReader.HasRows Then
                        dbReader.Read()
                        If IsNumeric(dbReader(0).ToString) Then intStockBalance = CDbl(dbReader(0).ToString) Else intStockBalance = 0
                    Else
                        intStockBalance = 0
                    End If
                    dbReader.Close()
                    intStockBalance = intStockBalance - intQty 'CDbl(dGridItems.Rows(i).Cells(2).Value)
                    myCommand = New Data.OleDb.OleDbCommand("UPDATE OchmasSystemMedicines SET Quantity = " & intStockBalance & " WHERE ProductCode = '" & strSelectedId & "'", cnn)
                    myCommand.ExecuteNonQuery()
                Else
                    myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & strSelectedId & "'", cnn)
                    dbReader = myCommand.ExecuteReader
                    If dbReader.HasRows Then
                        dbReader.Read()
                        If IsNumeric(dbReader(0).ToString) Then intStockBalance = CDbl(dbReader(0).ToString) Else intStockBalance = 0
                    Else
                        intStockBalance = 0
                    End If
                    dbReader.Close()
                    intStockBalance = intStockBalance - intQty ' CDbl(dGridItems.Rows(i).Cells(2).Value)
                    myCommand = New Data.OleDb.OleDbCommand("UPDATE InventoryItems SET Quantity = " & intStockBalance & " " _
                        & "WHERE ItemCode = '" & strSelectedId & "'", cnn)
                    myCommand.ExecuteNonQuery()
                End If

                'Update the dispensing details status
                If UCase(strRecordFlag) = "P" Then
                    myCommand = New Data.OleDb.OleDbCommand("UPDATE DispensingDetails SET Status = 'DISPENSED' " _
                        & "WHERE TransactionId = " & intRecordId & "", cnn)
                    myCommand.ExecuteNonQuery()
                End If

            End If

        Next i

        dblSumPayable = CDbl(lblPayable.Text)

        'Add the record to the sales main
        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO SalesMain (InvoiceNumber, CustomerId, " _
            & "TransDate, Discount, Taxes, Amount, UserName, SalesRep, ContactNumber, ContactName, " _
            & "KeyNumber, PaymentMethod) VALUES " _
            & "(" & Convert.ToDouble(txtReference.Text) & ", '" & txtPatientId.Text & "', '" & dpProcessDate & "', " & dblSumDiscounts & ", " _
            & "" & dblSumTaxes & ", " & dblSumPayable & ", '" & lblUsername.Text & "', '" & strPersonnel & "', " _
            & "'" & strCustomerTelephoneNumber & "', '" & strTillCustomerName & "', " _
            & "" & Convert.ToDouble(txtKeyNumber.Text) & ", '" & strTillPaymentMethod & "')", cnn)
        myCommand.ExecuteNonQuery()

        If strPublicDirectCashbookSalesPosting = "YES" Then

            'Update the cashbook with the values
            Dim strCashbookDescription As String = "CASH SALE - " & UCase(strPersonnel)
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO CashbookTransactions (AccountNumber, TransactionDate, Amount, Description, ContraAccount, UserName, UserBranch, TransactionType, Reference, KeyNumber) VALUES " _
                & "('" & strPublicActiveCashbook & "', '" & dpProcessDate & "', " & dblSumPayable + CDbl(lblVat.Text) & ", '" & strCashbookDescription & "', '" & strPublicSalesAccount & "', '" & strUserName & "', " _
                & "'" & strUserBranch & "', 'DEBIT', " & Convert.ToDouble(txtReference.Text) & ", " & Convert.ToDouble(txtKeyNumber.Text) & ")", cnn)
            myCommand.ExecuteNonQuery()

            'Post the account to the contra ledger account
            '
            myCommand = New Data.OleDb.OleDbCommand("INSERT INTO LedgerTransactions ([AccountNumber],[TransactionDate]," _
                & "[Amount],[TransactionType],[ContraAccount],[Description],[UserName],[UserBranch], [Reference]) VALUES " _
                & "('" & strPublicSalesAccount & "', '" & dpProcessDate & "', " & dblSumPayable & ", 'CREDIT', " _
                & "'" & strPublicActiveCashbook & "', '" & strCashbookDescription & "', '" & strUserName & "', " _
                & "'" & strUserBranch & "', " & Convert.ToDouble(txtReference.Text) & ")", cnn)
            myCommand.ExecuteNonQuery()

            'Update the taxes control account as well
            '
            If IsNumeric(lblVat.Text) Then
                If CDbl(lblVat.Text) > 0 Then
                    If String.IsNullOrEmpty(strPublicTaxesAccount) Then
                        MessageBox.Show("The taxes control account has not been setup. This will serious affect the trial balance", _
                            "Taxes Control Account Not Set", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        strTransactionProcessStatus = gwt_comm.LedgerEntry("INSERT", dpProcessDate, strPublicTaxesAccount, _
                            strPublicActiveCashbook, "CASH SALE-" & txtReference.Text, CDbl(lblVat.Text), "CREDIT", _
                            txtReference.Text, , , , txtReference.Text, 0, 0, 0)
                        If strTransactionProcessStatus <> "SUCCESS" Then GoTo RaiseErr
                    End If
                End If
            End If

        End If

        'Update the control numbers table
        Dim intNewInvoiceNumber As Double = CDbl(txtReference.Text)
        myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET CashSales = " & CDbl(txtReference.Text) & "", cnn)
        myCommand.ExecuteNonQuery()

        'Update the keynumbers
        Dim intNewKeyNumber As Double = CDbl(txtKeyNumber.Text)
        myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET KeyNumber = " & CDbl(txtKeyNumber.Text) & "", cnn)
        myCommand.ExecuteNonQuery()

        strPublicCustomerId = "0000"

        If UCase(strPublicReceiptType) = "DESKTOP PRINTER" Then
            PrintReceiptQuote("CASH RECEIPT")
            'PrintInvoiceTypeCashSlip(CInt(txtReference.Text))
        Else
            PrintInvoice(dpProcessDate)
        End If

        ''OpenCashdrawer()
        MessageBox.Show("Sales document generated successfully.", "Transaction Document Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.lblPayable.Text = "0.00"
        Me.lblCostPrice.Text = "0.00"
        Me.lblDiscounts.Text = "0.00"
        Me.lblVat.Text = "0.00"

        'Clear the controls
        dGridItems.Rows.Clear()

        txtReference.Text = ""
        txtKeyNumber.Text = ""
        txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))

        'lblDate.Visible = False
        dpTransDate.Enabled = False
        If strPublicMaintainTransactionDate = "NO" Then dpTransDate.Value = Now
        If strPublicMaintainTransactionDate = "NO" Then chkOverideDate.Checked = False
        dblAmountChange = 0
        dblAmountTendered = 0
        Cursor = Cursors.Default

        If UCase(strWebConnectionType) = "REALTIME" Then
            SalesInternetTransfers(intNewInvoiceNumber, intNewInvoiceNumber, "CASH SALES")
        End If

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Sales Processing"
        ShowErrorMessage()
    End Sub

    Public Sub SalesInternetTransfers(StartInvoiveNumber As Integer, EndingInvoiceNumber As Integer, DocumentType As String)
        On Error GoTo RaiseErr

        Dim arrData As New ArrayList
        Dim strDataInsertSql As String = Nothing

        Dim strSql As String = Nothing
        If UCase(DocumentType) = "INVOICE" Then
            Dim strSqlCustomers As String = ScriptCustomerData()
            'get the main sales details
            strSql = gwt_comm.ScriptTableFields("CustomerSalesMain", "SELECT")
            strSql = strSql & " WHERE InvoiceNumber BETWEEN " & StartInvoiveNumber & " AND " & EndingInvoiceNumber & ""
            strDataInsertSql = strDataInsertSql & strSqlCustomers & vbCrLf
            strDataInsertSql = strDataInsertSql & gwt_comm.ScriptDataInsertStatement(strSql, "CustomerSalesMain")
            'Get the sales details
            strSql = Nothing
            strSql = gwt_comm.ScriptTableFields("CustomerSales", "SELECT")
            strSql = strSql & " WHERE InvoiceNumber BETWEEN " & StartInvoiveNumber & " AND " & EndingInvoiceNumber & ""
            strDataInsertSql = strDataInsertSql & gwt_comm.ScriptDataInsertStatement(strSql, "CustomerSales")
        End If

        If UCase(DocumentType) = "CASH SALES" Then
            'get the main sales details
            strSql = gwt_comm.ScriptTableFields("SalesMain", "SELECT")
            strSql = strSql & " WHERE InvoiceNumber BETWEEN " & StartInvoiveNumber & " AND " & EndingInvoiceNumber & ""
            strDataInsertSql = strDataInsertSql & gwt_comm.ScriptDataInsertStatement(strSql, "SalesMain")
            'Get the sales details
            strSql = Nothing
            strSql = gwt_comm.ScriptTableFields("Sales", "SELECT")
            strSql = strSql & " WHERE InvoiceNumber BETWEEN " & StartInvoiveNumber & " AND " & EndingInvoiceNumber & ""
            strDataInsertSql = strDataInsertSql & gwt_comm.ScriptDataInsertStatement(strSql, "Sales")
        End If

        ServerDestinationFolder = strWebMainBranch.Replace(" ", "") & "/DailySales"
        strDestinationBranch = ServerDestinationFolder

        strDownloadingType = "SALES"
        gwt_comm.AddDataChanges(strDataInsertSql)

        If boolAbort = True Then
            MessageBox.Show("There were errors encountered when transmit sales data. " _
                & "Make sure that the connection is on and retry sending", "Data Transmission Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim objUpdate As New Data.OleDb.OleDbCommand("UPDATE SalesTranmissonBatches SET BatchNo = (BatchNo + 1)", cnn)
            objUpdate.ExecuteNonQuery()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Sales and Other Documents Internet Transfers"
        ShowErrorMessage()
    End Sub

    Public Function ScriptCustomerData() As String
        Dim strReturn As String = Nothing

        Dim strSql As String = Nothing
        Dim strDataInsertSql As String = Nothing
        strSql = gwt_comm.ScriptTableFields("Customers", "SELECT")
        strDataInsertSql = strDataInsertSql & gwt_comm.ScriptDataInsertStatement(strSql, "Customers")

        strReturn = strDataInsertSql

        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Customer Data Internet Transfers"
        ShowErrorMessage()
    End Function

    Private Sub PrintReceiptQuote(DocumentType As String)
        On Error GoTo RaiseErr

        'Print the document number together with the vat number and document type (cash receipt or quote)
        Dim objFile As New System.IO.StreamWriter(Application.StartupPath & "\TestDoc.txt", True)

        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()

        'First Print the company details

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, Space(30) & UCase(DocumentType) & Space(30))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(Space(30) & UCase(DocumentType) & Space(30))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, "-"c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strCompanyName))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strCompanyName))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strPublicBranchName))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strPublicBranchName))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strPublicBranchAddress1))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strPublicBranchAddress1))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strPublicBranchAddress2))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strPublicBranchAddress2))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strPublicBranchAddress3))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strPublicBranchAddress3))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(strPublicBranchAddress4))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(strPublicBranchAddress4))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, "PHONE: " & strPublicBranchTelephone)
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine("PHONE: " & strPublicBranchTelephone)

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, "-"c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, "-"c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, "DOC.NO : " & txtReference.Text)
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine("DOC.NO : " & txtReference.Text)

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        If UCase(DocumentType) = "QUOTATION" Then
            For j As Integer = 0 To 2
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
                objFile.WriteLine(StrDup(110, " "c))
            Next j
            'strFlyQuoteName = Nothing
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strFlyQuoteName)
            objFile.WriteLine(strFlyQuoteName)
            'strFlyQuoteAddress1 = Nothing
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strFlyQuoteAddress1)
            objFile.WriteLine(strFlyQuoteAddress1)
            'strFlyQuoteAddress2 = Nothing
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strFlyQuoteAddress2)
            objFile.WriteLine(strFlyQuoteAddress2)
            'strFlyQuoteAddress3 = Nothing
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strFlyQuoteAddress3)
            objFile.WriteLine(strFlyQuoteAddress3)
            strFlyQuoteAddress4 = Nothing
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strFlyQuoteAddress4)
            objFile.WriteLine(strFlyQuoteAddress4)
        End If
        '
        'Print based on the grid values
        '
        'ITEM CODE, DESCRIPTION, UNIT PRICE, QTY, SUB TOTAL, DISCOUNTS, TAXES, PAYABLE

        Dim strHeader As String = "CODE           DESCRIPTION                      QTY      PRICE      SUB TTL     DISC.         TAX     PAYABLE   "

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strHeader)
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(strHeader)

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, "-"c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, "-"c))

        Dim dblSubTotal As Double = 0
        Dim dblDiscounts As Double = 0
        Dim dblVat As Double = 0
        Dim dblPayableTotal As Double = 0

        For n = 0 To arrInvoiceData.Count - 1
            Dim strPrintLineDetails() As String = Split(arrInvoiceData.Item(n), "|")
            If strPrintLineDetails(1).Length > 24 Then strPrintLineDetails(1) = Mid(strPrintLineDetails(1), 1, 24)
            If strPrintLineDetails(0).Length > 12 Then strPrintLineDetails(0) = Mid(strPrintLineDetails(0), 1, 12)
            Dim strPrintData As String = strPrintLineDetails(0) & Space(12 - strPrintLineDetails(0).Length) & Space(2) & _
                strPrintLineDetails(1) & Space(25 - strPrintLineDetails(1).Length) & _
                Space(12 - strPrintLineDetails(2).Length) & strPrintLineDetails(2) & _
                Space(8 - strPrintLineDetails(3).Length) & strPrintLineDetails(3) & _
                Space(12 - strPrintLineDetails(4).Length) & strPrintLineDetails(4) & _
                Space(12 - strPrintLineDetails(5).Length) & strPrintLineDetails(5) & _
                Space(12 - strPrintLineDetails(6).Length) & strPrintLineDetails(6) & _
                Space(12 - strPrintLineDetails(7).Length) & strPrintLineDetails(7)

            Dim strValT, strValD, strValV, strValP As String

            strValT = Replace(strPrintLineDetails(4), ",", "", 1)
            If IsNumeric(strValT) Then dblSubTotal = dblSubTotal + CDbl(strValT)

            strValD = Replace(strPrintLineDetails(5), ",", "", 1)
            If IsNumeric(strValD) Then dblDiscounts = dblDiscounts + CDbl(strValD)

            strValV = Replace(strPrintLineDetails(6), ",", "", 1)
            If IsNumeric(strValV) Then dblVat = dblVat + CDbl(strValV)

            strValP = Replace(strPrintLineDetails(7), ",", "", 1)
            If IsNumeric(strValP) Then dblPayableTotal = dblPayableTotal + CDbl(strValP)


            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintData)
            If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(strPrintData)
        Next


        'Print the totals

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, "-"c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, "-"c))

        Dim strSubValue As String = Format(dblSubTotal, "##0.00")
        Dim strDiscValue As String = Format(dblDiscounts, "##0.00")
        Dim strTaxValue As String = Format(dblVat, "##0.00")
        Dim strPayValue As String = Format(dblPayableTotal, "##0.00")

        Dim strTotalLine As String = "               TOTALS                                        " & _
            Space(12 - strSubValue.Length) & strSubValue & _
                Space(12 - strDiscValue.Length) & strDiscValue & _
                Space(12 - strTaxValue.Length) & strTaxValue & _
                Space(12 - strPayValue.Length) & strPayValue

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strTotalLine)
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(strTotalLine)

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, "-"c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, "-"c))

        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, StrDup(110, " "c))
        If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(StrDup(110, " "c))

        'Print the terms and condictions

        If arrConditionsOfSale.Count > 0 Then
            For j As Double = 0 To arrConditionsOfSale.Count - 1
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, UCase(arrConditionsOfSale.Item(j)))
                If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine(UCase(arrConditionsOfSale.Item(j)))
            Next j
        End If

        For i As Integer = 0 To 9
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, "")
            If UCase(DocumentType) = "QUOTATION" Then objFile.WriteLine("")
        Next

        objFile.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Cash receipt Generation Error"
        ShowErrorMessage()
    End Sub

    Private Sub PrintInvoice(ByVal dtReceiptDate As Date)
        On Error GoTo RaiseErr
        strType = UCase(strReceiptHeader)
        strSelectedReport = Me.txtReference.Text

        Dim arrFiscalReceiptItems As New ArrayList

        arrPrintDetails = New ArrayList
        '
        'ADD THE BRANCH INFORMATION
        '
        arrPrintDetails.Add(Space(2) & UCase(strCompanyName))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchName))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress1))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress2))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress3))
        arrPrintDetails.Add(Space(2) & UCase(strPublicBranchAddress4))
        arrPrintDetails.Add(Space(2) & "PHONE: " & strPublicBranchTelephone)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        '
        'Print based on the grid values
        '
        If Not String.IsNullOrEmpty(strCustomerTelephoneNumber) Then
            arrPrintDetails.Add(Space(2) & "YOUR NO.: " & strCustomerTelephoneNumber)
            arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
            arrPrintDetails.Add(Space(2) & StrDup(30, " "c))
        End If
        Dim dblVatTax As Double = 0

        With dGridItems
            For i As Double = 0 To .Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then

                    'Item, Code, Qty, Unit Price, Cost, Discount, Vat, Payable

                    Dim strDescription As String = .Rows(i).Cells(0).Value.ToString
                    Dim strQuantity As String = .Rows(i).Cells(2).Value.ToString
                    Dim strUnitPrice As String = Format(CDbl(.Rows(i).Cells(3).Value.ToString), "#,##0.00")

                    Dim strLineTotal As String = Format(CDbl(.Rows(i).Cells(7).Value.ToString), "#,##0.00")
                    If strDescription.Length > 30 Then strDescription = Mid(strDescription, 1, 32)
                    arrPrintDetails.Add(Space(2) & strDescription)
                    arrPrintDetails.Add(Space(4) & Space(5 - strQuantity.Length) & strQuantity & " @ " & _
                        Space(8 - strUnitPrice.Length) & strUnitPrice & Space(4) & _
                        Space(8 - strLineTotal.Length) & strLineTotal)
                    dblVatTax = dblVatTax + Convert.ToDouble(.Rows(i).Cells(6).Value)

                    'If UCase(strPublicTaxFiscalStatus) = "YES" Then
                    '    Dim strFiscalUnitPrice As String = Format(CDbl(.Rows(i).Cells(3).Value.ToString), "###0.00")
                    '    Dim strFiscalItemCode As String = .Rows(i).Cells(0).Value.ToString
                    '    Dim strFiscalTaxCode As String = "A"
                    '    'Get the item taxcode
                    '    Dim objGetItemTaxCode As New Data.OleDb.OleDbCommand("SELECT TaxCode FROM InventoryItems WHERE ItemCode = '" & strFiscalItemCode & "'", cnn)
                    '    Dim objReadTaxCode As Data.OleDb.OleDbDataReader = objGetItemTaxCode.ExecuteReader
                    '    If objReadTaxCode.HasRows Then
                    '        objReadTaxCode.Read()
                    '        If Not IsDBNull(objReadTaxCode(0).ToString) Then strFiscalTaxCode = objReadTaxCode(0).ToString
                    '    End If
                    '    objReadTaxCode.Close()
                    '    arrFiscalReceiptItems.Add(strFiscalItemCode & "|" & strDescription & "|" & strFiscalUnitPrice & "|" & strQuantity & "|" & strFiscalTaxCode)
                    'End If

                End If
            Next
        End With

        'Add the dash line
        Dim strTaxCharged As String = Format(dblVatTax, "##0.00")

        Dim strTender As String = Format(dblAmountTendered, "##0.00")
        Dim strChange As String = Format(dblAmountChange, "##0.00")

        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "TOTAL INCL. VAT " & Space(14 - lblPayable.Text.Length) & lblPayable.Text)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "VAT CHARGED     " & Space(14 - strTaxCharged.Length) & strTaxCharged)
        arrPrintDetails.Add(Space(2) & StrDup(30, "="c))
        arrPrintDetails.Add(Space(2) & "AMOUNT TENDERED " & Space(14 - strTender.Length) & strTender)
        arrPrintDetails.Add(Space(2) & "CHANGE          " & Space(14 - strChange.Length) & strChange)

        Dim strZimDate As String = Format(Now, "dd-MMM-yyyy")

        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(2) & "TILL OPER :" & UCase(strUserName) & Space(3))

        arrPrintDetails.Add(Space(1) & "DATE AND TIME " & strZimDate & " " & DatePart(DateInterval.Hour, Now) & ":" & DatePart(DateInterval.Minute, Now))
        arrPrintDetails.Add(Space(2) & UCase(strReceiptHeader) & " DATE  " & Format(dtReceiptDate, "dd-MMM-yyyy"))
        arrPrintDetails.Add(Space(2) & " DOC NO " & txtReference.Text & ": KEY " & txtKeyNumber.Text)
        arrPrintDetails.Add(Space(32))
        arrPrintDetails.Add(Space(1) & "CURRENCY : " & UCase(strSalesCurrency))
        arrPrintDetails.Add(Space(1) & "RATE USED: " & dblSaleExchangeRate)
        'If boolProcessingAccountPayment = False Then
        If Not arrConditionsOfSale Is Nothing Then
            If arrConditionsOfSale.Count > 0 Then
                For j As Double = 0 To arrConditionsOfSale.Count - 1
                    arrPrintDetails.Add(UCase(arrConditionsOfSale.Item(j)))
                Next j
            End If
        End If

        'End If
        For i As Double = 0 To 5
            arrPrintDetails.Add(Space(32))
        Next

        'WRITE EVERY THING TO THE AUDIT FILE
        Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\TILLSLIP", True)
        For x As Double = 0 To arrPrintDetails.Count - 1
            objFileWriter.WriteLine(arrPrintDetails.Item(x))
        Next
        objFileWriter.Close()
        '
        'PRINTS FROM A FILE DIRECTLY TO THE PRINTER
        '
        'Try printing using the line printer
        ' Allow the user to select a file.
        Dim pd As New PrintDialog()
        pd.PrinterSettings = New PrinterSettings()
        Dim output As String = Chr(&H1D) & "V" & Chr(66) & Chr(0) 'Feeds paper & cut



        If strPublicConfirmReceiptPrint = "YES" Then
            If MessageBox.Show("Do you want to print the receipt right now?", "Confirm Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If strRequestForReceiptPrinter = "YES" Then
                    boolAbort = False
                    Dim f As New frmPrinterSetup
                    f.ShowDialog()
                    If boolAbort = True Then Exit Sub
                    pd.PrinterSettings.PrinterName = strSessionPrinter
                End If
                If UCase(strPublicPrinterType) = "RAW" Then
                    For n = 0 To arrPrintDetails.Count - 1
                        Dim strPrintLineDetails As String = arrPrintDetails.Item(n) & vbCrLf
                        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintLineDetails)
                    Next
                Else
                    Dim ppd As New PrintPreviewDialog
                    ppd.Document = pdWindows
                    pdWindows.Print()
                    'RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, output)
                    Exit Sub
                End If
                'Cut the paper on thermal printers
                If strPublicCutReceipt = "YES" Then
                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, output)
                End If
            End If
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sale Transaction Processing"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub pdWindows_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdWindows.PrintPage
        'This will send the printing to the windows type

        Dim y1 As Integer = 10

        If Not String.IsNullOrEmpty(strLogoPath) Then
            If System.IO.File.Exists(strLogoPath) Then
                'Dont print the company name as it is taken care of by the logo
                strCompanyName = ""
                Dim R As Drawing.Rectangle
                Dim objPicture As New Windows.Forms.PictureBox
                objPicture.SizeMode = PictureBoxSizeMode.AutoSize
                objPicture.Load(strLogoPath)
                R = New Rectangle(10, y1, objPicture.Width, objPicture.Height)
                e.Graphics.DrawImage(objPicture.Image, R)
                y1 = y1 + objPicture.Height
            End If
        End If

        y1 = y1 + 15

        For i As Integer = 0 To arrPrintDetails.Count - 1
            If i = 0 Then
                Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, arrPrintDetails.Item(i), tlFont, Brushes.Black)
            Else
                Call gwt_comm.DrawStringInBoxLeft(e, 10, y1, 300, 80, arrPrintDetails.Item(i), prFont, Brushes.Black)
            End If
            y1 = y1 + 15
        Next

        e.HasMorePages = False

    End Sub

    Private Sub InventoryFormDataLoad()
        'Bar1.Visible = False
        LoadInventoryData()
        'LoadBranches()
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
            btnEditInventory.Enabled = True
            btnNewInventory.Enabled = True
            btnRefreshInventory.Enabled = True
            btnPrintInventory.Enabled = True
        Else
            Select Case IntPublicInventory
                Case Is = 2
                    btnEditInventory.Enabled = True
                    btnNewInventory.Enabled = True
                    btnRefreshInventory.Enabled = True
                    btnPrintInventory.Enabled = True
                Case Is = 1
                    btnEditInventory.Enabled = True
                    btnNewInventory.Enabled = False
                    btnRefreshInventory.Enabled = True
                    btnPrintInventory.Enabled = True
                Case Else
                    btnEditInventory.Enabled = False
                    btnNewInventory.Enabled = False
                    btnRefreshInventory.Enabled = False
                    btnPrintInventory.Enabled = False
            End Select
        End If

        'cboBranchView.Text = UCase(strUserBranch)
        'If UCase(strPublicStockManagementType) = "DE-CENTRALIZED" Then cboBranchView.Enabled = False Else cboBranchView.Enabled = True
        If UCase(strDefaultSearchFilter) = "DESCRIPTION" Then cboSearchByInventory.SelectedIndex = 1 Else cboSearchByInventory.SelectedIndex = 0
        'Bar1.Visible = True
    End Sub

    Private Sub LoadInventoryData()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim strViewStatus As String = "ALL"
        strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
            & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
            & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
            & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
            & "FROM InventoryItems ORDER BY ItemCode"

        dGridInventoryItems.Columns.Clear()
        Me.dGridInventoryItems.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridInventoryItems.DataSource = dTable

        Me.dGridInventoryItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGridInventoryItems.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

        If UCase(strUserLevel) <> "MANAGER" Then
            If UCase(strUserLevel) <> "ADMINISTRATOR" Then
                dGridInventoryItems.Columns(4).Visible = False
            End If
        End If

        For p As Integer = 0 To dGridInventoryItems.Columns.Count - 1
            dGridInventoryItems.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p = 2 Then dGridInventoryItems.Columns(p).Visible = False
            If p = 3 Or p = 4 Then
                dGridInventoryItems.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Items Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnNewInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewInventory.Click
        boolEditStatus = False
        Dim f As New frmInventorySetup
        f.ShowDialog()
        LoadInventoryData()
    End Sub

    Private Sub dGridInventoryItems_ColumnDividerDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnDividerDoubleClickEventArgs) Handles dGridInventoryItems.ColumnDividerDoubleClick
        boolHeaderClicked = True
    End Sub

    Private Sub dGridInventoryItems_ColumnHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dGridInventoryItems.ColumnHeaderMouseDoubleClick
        boolHeaderClicked = True
    End Sub

    Private Sub dGridInventoryItems_dblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridInventoryItems.DoubleClick
        EditSelectedInventory()
    End Sub

    Private Sub EditSelectedInventory()
        'boolHeaderClicked = False
        If dGridInventoryItems.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedInventoryDetails()
            arrInventoryEditData = New ArrayList
            Dim iRowIndex As Integer = dGridInventoryItems.CurrentRow.Index
            Dim f As New frmInventorySetup
            f.ShowDialog()
            If UCase(strActiveSearch) = "SEARCH ITEM" Then
                txtSearchStringInventory.Text = strInventoryItemCode
            Else
                If String.IsNullOrEmpty(txtSearchStringInventory.Text) Then
                    'LoadData()
                    'Set the current row data to updated view
                    With dGridInventoryItems
                        If arrInventoryEditData.Count <= 0 Then Exit Sub
                        For p As Integer = 0 To arrInventoryEditData.Count - 1
                            .Rows(iRowIndex).Cells(p).Value = UCase(arrInventoryEditData.Item(p))
                        Next
                        .FirstDisplayedScrollingRowIndex = iRowIndex
                    End With
                Else
                    txtSearchStringInventory.Text = strActiveSearch
                    With dGridInventoryItems
                        If Not arrInventoryEditData Is Nothing Then
                            For p As Integer = 0 To arrInventoryEditData.Count - 1
                                .Rows(iRowIndex).Cells(p).Value = UCase(arrInventoryEditData.Item(p))
                            Next
                            .FirstDisplayedScrollingRowIndex = iRowIndex
                        End If
                    End With
                End If
            End If
        End If
    End Sub

    Private Sub GetSelectedInventoryDetails()
        Dim CurrentCellValue As String
        CurrentCellValue = dGridInventoryItems.CurrentRow.Cells(0).Value
        strActiviteStatus = dGridInventoryItems.CurrentRow.Cells(6).Value
        strInventoryItemCode = CurrentCellValue
    End Sub


    Private Sub btnEditInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditInventory.Click
        EditSelectedInventory()
    End Sub

    Private Sub btnRefreshInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshInventory.Click
        LoadInventoryData()
    End Sub

    Private Sub txtSearchStringInventory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchStringInventory.KeyPress
        SearchForInventoryItem(e.KeyChar)
    End Sub

    Private Sub SearchForInventoryItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = txtSearchStringInventory.Text & strCurrentKey
        strActiveSearch = strFind
        Cursor = Cursors.WaitCursor

        dGridInventoryItems.Columns.Clear()
        Me.dGridInventoryItems.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim strSql As String = Nothing

        Select Case cboSearchByInventory.Text
            Case Is = "Item Code"
                strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                    & "FROM InventoryItems WHERE ItemCode LIKE '%" & strFind & "%' ORDER BY ItemCode"

            Case Is = "Description" 'Use the group name
                strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                    & "FROM InventoryItems WHERE GroupName LIKE '%" & strFind & "%' ORDER BY GroupName, ItemCode"

            Case Is = "Category"
                strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                    & "FROM InventoryItems WHERE Category LIKE '%" & strFind & "%' ORDER BY Category, ItemCode"

            Case Is = "Sub Category"
                strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                    & "FROM InventoryItems WHERE SubCategory LIKE '%" & strFind & "%' ORDER BY SubCategory, ItemCode"

            Case Else
                strSql = "SELECT ItemCode as [Item Code], GroupName as [General Description], Description, " _
                    & "CAST(SellingPrice AS decimal(10,2)) AS [Sell Price], CAST(CostPrice AS decimal(10,2)) " _
                    & "AS [Cost Price], Location, Status, Category, SubCategory as [Sub Category], Quantity, InventoryType as [Type], " _
                    & "MinimumLevel as [Min Qty], WarningLevel as [Warn Qty], IdealLevel as [Ideal Qty], TaxStatus as [Tax] " _
                    & "FROM InventoryItems WHERE ItemCode LIKE '%" & strFind & "%' ORDER BY ItemCode"

        End Select

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridInventoryItems.DataSource = dTable

        Me.dGridInventoryItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        For p As Integer = 0 To dGridInventoryItems.Columns.Count - 1
            dGridInventoryItems.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            If p = 2 Then dGridInventoryItems.Columns(p).Visible = False
            If p = 3 Or p = 4 Then
                dGridInventoryItems.Columns(p).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        'grd.Columns(2).Visible = False
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
        Exit Sub
    End Sub

    Private Sub btnPrintInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintInventory.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("select ItemCode, GroupName as [Description], " _
            & "Category, SubCategory, CAST(SellingPrice AS DECIMAL (10,2)) AS [Sale Price], " _
            & "CAST(CostPrice AS DECIMAL (10,2)) AS [Cost Price], Quantity from inventoryitems " _
            & "ORDER BY Category, SubCategory, GroupName, ItemCode", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        'Assign the values to the print array
        Dim arrPrintData As New ArrayList
        While objReader.Read
            Dim strDataRow As String = Nothing
            For i As Integer = 0 To objReader.FieldCount - 1
                If i = 0 Then
                    If Not IsDBNull(objReader(i).ToString) Then strDataRow = objReader(i).ToString & ";" Else strDataRow = ";"
                Else
                    strDataRow = strDataRow & objReader(i).ToString & ";"
                End If
            Next
            strDataRow = Mid(strDataRow, 1, (strDataRow.Length - 1))
            arrPrintData.Add(strDataRow)
        End While
        objReader.Close()

        If arrPrintData.Count <= 0 Then
            MessageBox.Show("No details to print", "No Print Details", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        'Add the details to the print class print array

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 7
            .strColumnHeaders = "CODE|DESCRIPTION|CATEGORY|SUB CAT.|SALE $|COST $|"
            .strColumnAlignments = "0|0|0|0|2|2|2"
            .strColumnWidths = "175|175|90|80|65|65|0"
            .strFooterCaption = "Inventory Analysis Report "
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "INVENTORY REPORT"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|YES|YES|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = True
            .boolPrintTotals = True
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = True
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|NO"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|YES|YES|NO"
            .intKeyFieldIndex = 3
            .strPrintValues = strPrintDetails
        End With
        If strRequestForReceiptPrinter = "YES" Then
            boolAbort = False
            Dim f As New frmPrinterSetup
            f.ShowDialog()
            If boolAbort = True Then Exit Sub
            rpt.PrinterSettings.PrinterName = strSessionPrinter
        End If
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Report Print"
        ShowErrorMessage()
    End Sub

    Private Sub txtSearchStringInventory_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchStringInventory.TextChanged
        SearchForInventoryItem("")
    End Sub

    Private Sub DeleteSelectedInventoryItems()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrRemoveRows As New ArrayList
        If dGridInventoryItems.Rows.Count > 0 Then
            'GetSelectedDetails()
            If MessageBox.Show("Are you sure you want to delete the selected items?", _
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                For i As Integer = 0 To dGridInventoryItems.SelectedRows.Count - 1
                    strInventoryItemCode = dGridInventoryItems.SelectedRows.Item(i).Cells(0).Value.ToString
                    Dim strSql As String = "SELECT [ItemCode],[GroupName],[Description],[SellingPrice]," _
                        & "[CostPrice],[Location],[Category],[SubCategory],[Quantity],[InventoryType]," _
                        & "[MinimumLevel],[WarningLevel],[IdealLevel],[TaxStatus],[SerialNumbers],[BarCodeNo]," _
                        & "[ItemColor],[Size],[UnitOfMeasure],[FullBarcodeSerialStatus],[Offering],[Status]," _
                        & "[ShortCode],[Uom],[MasterPackQty],[InnerPackQty],[CaseLength],[CaseWidth]," _
                        & "[CaseHeight],[CaseWeight],[ProductLength],[ProductWidth],[ProductHeight]," _
                        & "[ProductWeight],[DateIntroduced],[SoUomName],[SoUomRatioStd],[SoUomRatio]," _
                        & "[PoUomName],[PoUomRatioStd],[PoUomRatio],[SupplyPackaging],[SalesPackaging]," _
                        & "[SupplyPackagingQuantity],[SalesPackagingQuantity],[PackItemCostPrice]," _
                        & "[PackItemSalePrice],[CostCode],[TaxCode],[ItemShortCode] FROM InventoryItems WHERE ItemCode = '" & strInventoryItemCode & "'"
                    Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                    Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        strSql = "INSERT INTO InventoryItemsDeleted ([ItemCode],[GroupName],[Description],[SellingPrice]," _
                        & "[CostPrice],[Location],[Category],[SubCategory],[Quantity],[InventoryType]," _
                        & "[MinimumLevel],[WarningLevel],[IdealLevel],[TaxStatus],[SerialNumbers],[BarCodeNo]," _
                        & "[ItemColor],[Size],[UnitOfMeasure],[FullBarcodeSerialStatus],[Offering],[Status]," _
                        & "[ShortCode],[Uom],[MasterPackQty],[InnerPackQty],[CaseLength],[CaseWidth]," _
                        & "[CaseHeight],[CaseWeight],[ProductLength],[ProductWidth],[ProductHeight]," _
                        & "[ProductWeight],[DateIntroduced],[SoUomName],[SoUomRatioStd],[SoUomRatio]," _
                        & "[PoUomName],[PoUomRatioStd],[PoUomRatio],[SupplyPackaging],[SalesPackaging]," _
                        & "[SupplyPackagingQuantity],[SalesPackagingQuantity],[PackItemCostPrice]," _
                        & "[PackItemSalePrice],[CostCode],[TaxCode],[ItemShortCode], [UserName], [TransDate]) VALUES " _
                        & "('" & objReader("ItemCode") & "', '" & objReader("GroupName") & "', '" & objReader("Description") & "', " _
                        & "" & objReader("SellingPrice") & ", " & objReader("CostPrice") & ", " _
                        & "'" & objReader("Location") & "', '" & objReader("Category") & "', '" & objReader("SubCategory") & "', " & objReader("Quantity") & ", " _
                        & "'" & objReader("InventoryType") & "', " & objReader("MinimumLevel") & ", " & objReader("WarningLevel") & ", " & objReader("IdealLevel") & ", " _
                        & "'" & objReader("TaxStatus") & "', '" & objReader("SerialNumbers") & "', '" & objReader("BarCodeNo") & "', '" & objReader("ItemColor") & "', " _
                        & "'" & objReader("Size") & "', '" & objReader("UnitOfMeasure") & "', '" & objReader("FullBarcodeSerialStatus") & "', '" & objReader("Offering") & "', " _
                        & "'" & objReader("Status") & "', '" & objReader("ShortCode") & "', '" & objReader("Uom") & "', " & objReader("MasterPackQty") & ", " _
                        & "" & objReader("InnerPackQty") & ", " & objReader("CaseLength") & ", " & objReader("CaseWidth") & ", " & objReader("CaseHeight") & ", " _
                        & "" & objReader("CaseWeight") & ", " & objReader("ProductLength") & ", " & objReader("ProductWidth") & ", " & objReader("ProductHeight") & ", " _
                        & "" & objReader("ProductWeight") & ", '" & objReader("DateIntroduced") & "', '" & objReader("SoUomName") & "', '" & objReader("SoUomRatioStd") & "', " _
                        & "'" & objReader("SoUomRatio") & "', '" & objReader("PoUomName") & "', '" & objReader("PoUomRatioStd") & "', '" & objReader("PoUomRatio") & "', " _
                        & "'" & objReader("SupplyPackaging") & "', '" & objReader("SalesPackaging") & "', " & objReader("SupplyPackagingQuantity") & ", '" & objReader("SalesPackagingQuantity") & "', " _
                        & "" & objReader("PackItemCostPrice") & ", " & objReader("PackItemSalePrice") & ", " & objReader("CostCode") & ", '" & objReader("TaxCode") & "', " _
                        & "'" & objReader("ItemShortCode") & "', '" & strUserName & "', '" & Now & "')"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                    objReader.Close()

                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM InventoryItems WHERE Itemcode = '" & strInventoryItemCode & "'", cnn)
                    objCommand.ExecuteNonQuery()

                    'Store the deleted serial numbers as well
                    'SerialNumbersDeleted
                    strSql = "SELECT [ItemCode],[SerialNumber],[BarCodeNo],[SourceSerialNo],[Availability],[CostPrice] " _
                        & "FROM SerialNumbers WHERE ItemCode = '" & strInventoryItemCode & "'"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objReader = objCommand.ExecuteReader
                    While objReader.Read
                        strSql = "INSERT INTO SerialNumbersDeleted ([ItemCode],[SerialNumber],[BarCodeNo],[SourceSerialNo]," _
                            & "[Availability],[CostPrice], [UserName], [TransDate]) VALUES ('" & objReader(0) & "', " _
                            & "'" & objReader(1) & "', '" & objReader(2) & "', '" & objReader(3) & "', " _
                            & "'" & objReader(4) & "', " & objReader(5) & ", '" & strUserName & "', '" & Now & "')"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End While
                    objReader.Close()
                    objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SerialNumbers WHERE Itemcode = '" & strInventoryItemCode & "'", cnn)
                    objCommand.ExecuteNonQuery()
                    arrRemoveRows.Add(dGridInventoryItems.SelectedRows.Item(i).Index)
                Next

                'Delete all the selected items from the grid
                'LoadData()
                For i As Integer = 0 To arrRemoveRows.Count - 1
                    dGridInventoryItems.Rows.RemoveAt(CInt(arrRemoveRows.Item(i)))
                Next
                MessageBox.Show("Inventory Item Deleted successfully", "Inventory Item Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On inventory item delete"
        ShowErrorMessage()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteInventory.Click
        DeleteSelectedInventoryItems()
    End Sub

    Private Sub DeactivateInventoryItems()
        On Error GoTo RaiseErr
        If dGridInventoryItems.Rows.Count <= 0 Then
            MessageBox.Show("Process cannot be executed as there are no inventory items", "No Inventory Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim arrRemoveRows As New ArrayList
        Cursor = Cursors.WaitCursor
        If MessageBox.Show("Are you sure you want to de-activate the selected inventory items?", "Confirm De-activation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            'GetSelectedDetails()

            For i As Integer = 0 To dGridInventoryItems.SelectedRows.Count - 1
                strInventoryItemCode = dGridInventoryItems.SelectedRows.Item(i).Cells(0).Value.ToString
                'Check that the quantity is zero and that there are no serial numbers attached
                Dim dblQty As Double = 0
                Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Quantity FROM InventoryItems WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then dblQty = CDbl(objReader(0).ToString)
                End If
                objReader.Close()
                If dblQty <> 0 Then
                    MessageBox.Show("Item cannot be de-activated until you have resolved the quantity issue." & vbCrLf & _
                        "Currently there are " & dblQty & " units of this item in stock", _
                        "Process Cannot Proceed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                'Check the serial numbers as well
                Dim dblSerialCnt As Double = 0
                objCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(ItemCode) FROM SerialNumbers WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then dblSerialCnt = CDbl(objReader(0).ToString)
                End If
                objReader.Close()
                If dblSerialCnt <> 0 Then
                    MessageBox.Show("Item cannot be de-activated until you have resolved the serial numbers issue." & vbCrLf & _
                        "Currently there are " & dblSerialCnt & " units of this item in serial numbers", _
                        "Process Cannot Proceed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                objCommand = New Data.OleDb.OleDbCommand("Update InventoryItems SET Status = 'INACTIVE' " _
                    & "WHERE ItemCode = '" & strInventoryItemCode & "'", cnn)
                objCommand.ExecuteNonQuery()

                arrRemoveRows.Add(dGridInventoryItems.SelectedRows.Item(i).Index)

            Next

            'Delete all the selected items from the grid
            'LoadData()
            For i As Integer = 0 To arrRemoveRows.Count - 1
                dGridInventoryItems.Rows.RemoveAt(CInt(arrRemoveRows.Item(i)))
            Next
            MessageBox.Show("Inventory item de-activated from active inventory items", "Inventory De-activation", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Inventory De-activation"
        ShowErrorMessage()
    End Sub

    Private Sub btnReceiveDrugs_Click(sender As System.Object, e As System.EventArgs) Handles btnReceiveDrugs.Click
        Dim frm As New frmReceiveDrugs
        frm.ShowDialog()
    End Sub

    Private Sub btnDelete_Click_1(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click

    End Sub

    Private Sub ButtonItem9_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItem9.Click

    End Sub
End Class