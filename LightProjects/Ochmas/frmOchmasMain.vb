Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.IO

Public Class frmOchmasMain

    Dim boolFormLoading As Boolean

    'Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
    '    If e.KeyChar = "." Then Exit Sub
    '    If e.KeyChar = "-" Then Exit Sub
    '    If Not IsNumeric(e.KeyChar) Then e.Handled = True
    'End Sub

    'Private Sub dGridConEntries_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridConEntries.CellEndEdit
    '    If dGridConEntries.CurrentCell.ColumnIndex = 10 Then
    '        If IsNumeric(dGridConEntries.CurrentCell.Value) Then
    '            dGridConEntries.CurrentCell.Value = Format(CDbl(dGridConEntries.CurrentCell.Value.ToString), "##0.00")
    '        End If
    '    End If
    'End Sub

    'Private Sub dGridConEntries_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridConEntries.EditingControlShowing
    '    Try
    '        If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
    '            AddHandler e.Control.KeyPress, AddressOf CheckCell
    '        Else
    '            'In order to prevent optical problems, we had to call the removeHandler twice
    '            RemoveHandler e.Control.KeyPress, AddressOf CheckCell
    '            RemoveHandler e.Control.KeyPress, AddressOf CheckCell
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub frmOchmasMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        gwt_comm = New CommonLibrary.Commons.CommonFunctions
        gwt_comm.UserAuthentication()
        If boolAbort = True Then End
        boolFormLoading = True
        LoadPatients()
        LoadMedicinesData()
        boolFormLoading = False
    End Sub

    Private Sub btnControlNumber_Click(sender As System.Object, e As System.EventArgs) Handles btnControlNumber.Click
        Dim frm As New frmControlNumber
        frm.ShowDialog()
    End Sub

    Private Sub btnConCodes_Click(sender As System.Object, e As System.EventArgs) Handles btnConCodes.Click
        Dim frm As New frmConsultationCodesListing
        frm.ShowDialog()
    End Sub

    Private Sub btnListNewPatient_Click(sender As System.Object, e As System.EventArgs) Handles btnListNewPatient.Click
        boolEditStatus = False
        Dim frm As New frmPatientDetails
        frm.ShowDialog()
        LoadPatients()
    End Sub

    Private Sub btnListEditPatient_Click(sender As System.Object, e As System.EventArgs) Handles btnListEditPatient.Click
        GetSelected()
    End Sub

    Private Sub GetSelected()
        If dGrid.RowCount <= 0 Then Exit Sub
        intSelectedPatient = CInt(dGrid.CurrentRow.Cells(dGrid.ColumnCount - 1).Value.ToString)
        boolEditStatus = True
        Dim frm As New frmPatientDetails
        frm.ShowDialog()
        loadPatients()
    End Sub

    Private Sub LoadPatients()
        On Error GoTo RaiseErr
        dGrid.Columns.Clear()
        Dim strSql As String = "SELECT LastName +' '+ FirstName as [Given Names], MedicalAidNumber AS [Medaid No.], " _
            & "DependentCode AS [Sfx], Gender, UPPER(REPLACE(CONVERT(CHAR(11), BirthDate, 106), ' ', '-')) as [DOB], " _
            & "[IdNumber] AS [ID Number], FileNumber AS [File Number], PatientId as [PID] FROM OchmasPatients " _
            & "ORDER BY LastName, FirstName, BirthDate"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable
        With dGrid
            For p As Integer = 0 To .ColumnCount - 1
                .Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                If p = .ColumnCount - 1 Then
                    .Columns(p).Visible = False
                End If
            Next
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Patient Details Management"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellDoubleClick
        GetSelected()
    End Sub

    Private Sub btnListDeletePatient_Click(sender As System.Object, e As System.EventArgs) Handles btnListDeletePatient.Click
        On Error GoTo RaiseErr
        If dGrid.RowCount <= 0 Then Exit Sub
        intSelectedPatient = CInt(dGrid.CurrentRow.Cells(dGrid.ColumnCount - 1).Value.ToString)

        'Check that the patient does not have any consultation information in then database

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Patient Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnListRefreshPatient_Click(sender As System.Object, e As System.EventArgs) Handles btnListRefreshPatient.Click
        LoadPatients()
    End Sub

    Private Sub btnMedicalAids_Click(sender As System.Object, e As System.EventArgs) Handles btnMedicalAids.Click
        Dim frm As New frmMedicalAidsListing
        frm.ShowDialog()
    End Sub

    Private Sub btnIcdTenCodes_Click(sender As System.Object, e As System.EventArgs) Handles btnIcdTenCodes.Click
        Dim frm As New frmDiagnosisCodesListing
        frm.ShowDialog()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim f As New frmDrugSetup
        f.ShowDialog()
        LoadMedicinesData()
    End Sub

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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
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

    Private Sub GetSelectedDetails()
        Dim CurrentCellValue As String
        On Error Resume Next
        CurrentCellValue = dGridMedicines.CurrentRow.Cells(0).Value.ToString
        strDrugCode = CurrentCellValue
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
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click

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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
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
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadMedicinesData()
    End Sub

    Private Sub btnDrugCategories_Click(sender As System.Object, e As System.EventArgs) Handles btnDrugCategories.Click
        Dim frm As New frmDrugCategories
        frm.ShowDialog()
    End Sub

    Private Sub btnManufacturers_Click(sender As System.Object, e As System.EventArgs) Handles btnManufacturers.Click
        Dim frm As New frmDrugManufacturers
        frm.ShowDialog()
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

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub btnNewConsultation_Click(sender As System.Object, e As System.EventArgs) Handles btnNewConsultation.Click
        boolEditStatus = False
        boolAbort = False
        Dim frm As New frmConsultations
        frm.ShowDialog()
        If boolAbort = False Then
            LoadConsultations()
        End If
    End Sub

    Private Sub LoadConsultations()

    End Sub

End Class
