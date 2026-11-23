Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDiagnosisAndTreatment

    Dim boolPrintFromPreview As Boolean
    Dim arrDrugs As ArrayList

    Dim intNextPrescriptionNumber As Long
    Dim strPatientAddress As String
    Dim strDobGender As String

    Private Function PatientKeyDetails(ByVal PatientId As Integer) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList
        Dim strAddress As String = Nothing
        Dim strSql As String = "SELECT OchmasAddresses.Address1, OchmasAddresses.Address2, OchmasAddresses.Address3, " _
            & "OchmasAddresses.Address4 FROM OchmasAddresses WHERE PatientId = " & PatientId & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strAddress = strAddress & UCase(objReader(0).ToString) & ", "
            If Not IsDBNull(objReader(1).ToString) Then strAddress = strAddress & UCase(objReader(1).ToString) & ", "
            If Not IsDBNull(objReader(2).ToString) Then strAddress = strAddress & UCase(objReader(2).ToString) & ", "
            If Not IsDBNull(objReader(3).ToString) Then strAddress = strAddress & UCase(objReader(3).ToString) & ", "
        End If
        objReader.Close()

        If strAddress.Length >= 2 Then
            strAddress = Mid(strAddress, 1, strAddress.Length - 2)
        End If

        arrReturn.Add(strAddress)

        'Get the gender and date of birth

        strSql = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), BirthDate, 106), ' ', '-')) +' - '+ Gender FROM OchmasPatients WHERE PatientId = " & PatientId & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then arrReturn.Add(UCase(objReader(0).ToString)) Else arrReturn.Add("")
        End If
        objReader.Close()

        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On key patient details fetch"
        ShowErrorMessage()
    End Function

    Private Sub frmDiagnosisAndTreatment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlMain.Height = txtSearchString.Height
        lblPatientId.Text = intSelectedPatient
        'Get the PatientNames
        lblPatientNames.Text = UCase(FullPatientNames(lblPatientId.Text))
        If boolEditStatus = False Then
            lblConsultationId.Text = gwt_comm.GetNextDocumentNumber("Consultations")
        Else
            lblConsultationId.Text = intSelectedConsultation
        End If
        LoadCiphers()
        AddGridColumns()
        'Datagrid update for auto drop down items
        'With dGrid
        '    .CellEnter += DataGridViewCellEventHandler(AddressOf dGrid_CellEnter)
        'End With
    End Sub

    'Private Sub dGrid_CellEnter(sender As Object, e As DataGridViewCellEventArgs)
    '    Dim dg As DataGridView = DirectCast(sender, DataGridView)
    '    If dg.CurrentCell.EditType = GetType(DataGridViewComboBoxEditingControl) Then
    '        SendKeys.Send("{F4}")
    '    End If
    'End Sub

    Private Sub frmDiagnosisAndTreatment_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 715 : Me.Height = 520 '715; 518
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGrid.EditingControlShowing

        If e.Control.GetType = GetType(ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxEditingControl) Then
            SendKeys.Send("{F4}")
            Exit Sub
        End If

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
        If e.ColumnIndex = 3 Or e.ColumnIndex = 5 Then Exit Sub
        If e.ColumnIndex = 4 And e.ColumnIndex = 6 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
        End If
    End Sub

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
                dGridItems.Rows(0).Selected = True
                AssignSelected()
                txtSearchString.Clear()
                pnlMain.Height = txtSearchString.Height
                'txtSearchString.Select()
                dGrid.Select()
                dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Selected = True
                dGrid.CurrentCell = dGrid.Rows(dGrid.Rows.Count - 1).Cells(0)
                dGridItems.DataSource = Nothing
                dGridItems.Rows.Clear()
            End If
        End If
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)

        Dim strFind As String = txtSearchString.Text & strCurrentKey
        If strFind.Length < 3 Then Exit Sub

        Cursor = Cursors.WaitCursor

        With dGridItems
            .Columns.Clear()

            Dim strSql As String = Nothing


            strSql = "SELECT ProductCode as [Drug Code], ProductName as [Product Name], GenericIndicator as [B/G], " _
                & "CAST(SellPrice AS decimal(10,2)) AS [Price] FROM OchmasSystemMedicines " _
                & "WHERE ProductName LIKE '%" & strFind & "%' ORDER BY ProductName"

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

        End With

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Data Filter Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub dGridItems_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridItems.KeyDown
        If e.KeyValue = Keys.Enter Or e.KeyValue = 9 Then
            e.SuppressKeyPress = True
            If dGridItems.Rows.Count > 0 Then
                AssignSelected()
                txtSearchString.Clear()
                pnlMain.Height = txtSearchString.Height
                'txtSearchString.Select()
                dGrid.Select()
                dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Selected = True
                dGrid.CurrentCell = dGrid.Rows(dGrid.Rows.Count - 1).Cells(0)
                dGridItems.DataSource = Nothing
                dGridItems.Rows.Clear()
            End If
        End If
    End Sub

    Private Sub txtSearchString_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchString.TextChanged
        SearchForItem("")
    End Sub

    Private Sub AssignSelected()

        With dGridItems

            Dim strCode As String = Nothing
            Dim strDescription As String = Nothing
            Dim strExtraInfo As String = Nothing
            Dim dblQty As Double = 1
            Dim dblAmount As Double = 0

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

            dGrid.Rows.Add(strCode, strDescription, strExtraInfo, "", dblQty, "", "0", "N")

        End With

    End Sub

    Private Sub dGrid_KeyDown(sender As Object, e As KeyEventArgs) Handles dGrid.KeyDown
        If e.KeyValue = 9 Then
            If dGrid.CurrentCell.ColumnIndex = dGrid.ColumnCount - 1 Then
                txtSearchString.Select()
                txtSearchString.SelectAll()
            End If
        End If
    End Sub

    Private Sub btnAddDiagnosis_Click(sender As Object, e As EventArgs) Handles btnAddDiagnosis.Click
        AddDiagnosis()
    End Sub

    Private Sub txtDiagnosis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiagnosis.KeyPress
        If Asc(e.KeyChar) = 13 Then AddDiagnosis()
    End Sub

    Private Sub AddDiagnosis()
        If Not String.IsNullOrEmpty(txtDiagnosis.Text) Then
            dGridDiagnosis.Rows.Add("000", txtDiagnosis.Text, "")
            txtDiagnosis.Clear()
            txtDiagnosis.Select()
        Else
            MessageBox.Show("Please enter the diagnosis", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDiagnosis.Select()
        End If
    End Sub

    Private Sub dGridDiagnosis_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGridDiagnosis.CellContentClick
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        If e.ColumnIndex = dGridDiagnosis.ColumnCount - 1 Then
            Dim intTid As Integer = 0
            If Not Object.Equals(dGridDiagnosis.CurrentRow.Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridDiagnosis.CurrentRow.Cells(1).Value.ToString) Then
                    If IsNumeric(dGridDiagnosis.CurrentRow.Cells(1).Value.ToString) Then
                        intTid = CInt(dGridDiagnosis.CurrentRow.Cells(1).Value.ToString)
                    End If
                End If
            End If

            If intTid = 0 Then
                dGridDiagnosis.Rows.RemoveAt(dGridDiagnosis.CurrentRow.Index)
            Else
                Dim strSql As String = "DELETE FROM OchmasPatientsDiagnosis WHERE [TransactionId] = " & intTid & ""
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                dGridDiagnosis.Rows.RemoveAt(dGridDiagnosis.CurrentRow.Index)
            End If
        End If
        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Delete Diagnosis"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If dGridDiagnosis.RowCount <= 0 Then
            If MessageBox.Show("Are you sure you want to proceed with no diagnosis?", "Confirm Process",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Exit Sub
            End If
        End If

        intNextPrescriptionNumber = gwt_comm.GetNextDocumentNumber("Prescriptions")

        If Not String.IsNullOrEmpty(txtTreatmentPlan.Text) Then
            AddTreatmentPlans()
        End If
        If dGridDiagnosis.RowCount > 0 Then
            SaveDiagnosis()
        End If

        'Save Priscription here
        boolAbort = False
        SavePrescription(intNextPrescriptionNumber)
        If boolAbort = True Then Exit Sub

        'Print the prescription here
        Dim arrKeyData As New ArrayList
        arrKeyData = PatientKeyDetails(lblPatientId.Text)

        strPatientAddress = UCase(arrKeyData.Item(0))
        strDobGender = UCase(arrKeyData.Item(1))

        intPayslipProcessingCount = 0

        If MessageBox.Show("Do you want To print the script right now?", "Confirm Script Print",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            boolAbort = False
            Dim printSelect As New PrintDialog
            printSelect.ShowDialog()
            strSessionPrinter = printSelect.PrinterSettings.PrinterName
            If boolAbort = True Then Exit Sub

            boolDrawBorders = True
            pdSmartBilling.PrinterSettings.PrinterName = strSessionPrinter

            itm = 0
            arrDrugs = New ArrayList
            arrDrugs = CreatePrescriptionArray(intNextPrescriptionNumber)

            Dim documentPreview As New PrintPreviewDialog
            documentPreview.Document = pdSmartBilling
            documentPreview.ShowDialog()
        End If

        'Update the consultations key here

        Dim objUpdate As New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET Consultations = (Consultations + 1)", cnn)
        objUpdate.ExecuteNonQuery()

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

    End Sub

    Private Sub SavePrescription(ByVal ScriptNumber As Integer)
        On Error GoTo RaiseErr

        arrDrugs = New ArrayList

        With dGrid

            For p As Integer = 0 To .RowCount - 1

                Dim strCode As String = Nothing
                Dim strName As String = Nothing
                Dim strInfo As String = Nothing
                Dim strCipher As String = Nothing
                Dim dblDosage As Double = 0
                Dim dblDuration As Double = 0
                Dim strRepeat As String = Nothing
                Dim strAdministration As String = Nothing

                If Not Object.Equals(.Rows(p).Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(0).Value.ToString) Then
                        strCode = .Rows(p).Cells(0).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(1).Value.ToString) Then
                        strName = .Rows(p).Cells(1).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(2).Value.ToString) Then
                        strInfo = .Rows(p).Cells(2).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(3).Value.ToString) Then
                        strCipher = .Rows(p).Cells(3).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(4).Value.ToString) Then
                            dblDosage = CDbl(.Rows(p).Cells(4).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(5).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(5).Value.ToString) Then
                        strAdministration = .Rows(p).Cells(5).Value.ToString
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(6).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(6).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(6).Value.ToString) Then
                            dblDuration = CDbl(.Rows(p).Cells(6).Value.ToString)
                        End If
                    End If
                End If

                If Not Object.Equals(.Rows(p).Cells(7).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(7).Value.ToString) Then
                        strRepeat = .Rows(p).Cells(7).Value.ToString
                    End If
                End If

                arrDrugs.Add(strName & "|" & strAdministration & "| " & strCipher & "|" & CStr(Format(dblDosage, "##0.00")) & "|" &
                    CStr(Format(dblDosage, "##0.00")) & "|" & CStr(Format(dblDuration, "##0.00")) & "|" & strRepeat)

                Dim strSql As String = "INSERT INTO [OchmasPatientsPrescriptions] " _
                    & "([PatientId], [TransDate], [DrugCode], [Frequency], [Dosage], " _
                    & "[Administration], [Duration], [RepeatStatus], [UserName], " _
                    & "[ChangeDate], [ConsultationId], [ScriptNumber]) VALUES (" & lblPatientId.Text & ", " _
                    & "'" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', '" & strCode & "', " _
                    & "'" & strCipher & "', " & dblDosage & ", '" & strAdministration & "', " _
                    & "" & dblDuration & ", '" & strRepeat & "', '" & strUserName & "', " _
                    & "'" & Now & "', " & lblConsultationId.Text & ", " & ScriptNumber & ")"
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

            Next

        End With

        'Update the control number here
        Dim objUpdate As New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET Prescriptions = (Prescriptions + 1)", cnn)
        objUpdate.ExecuteNonQuery()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On prescription details save"
        ShowErrorMessage()
    End Sub

    Private Sub AddTreatmentPlans()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        If boolEditStatus = False Then
            strSql = "INSERT INTO OchmasPatientsTreatmentPlans ([PatientId], [TransDate], [Plan], " _
                & "[UserName], [ChangeDate], [ConsultationId]) VALUES (" & lblPatientId.Text & ", " _
                & "'" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', '" & txtTreatmentPlan.Text & "', " _
                & "'" & strUserName & "', '" & Now & "', " & lblConsultationId.Text & ")"
        Else
            strSql = "UPDATE OchmasPatientsTreatmentPlans SET [TransDate] = '" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', " _
                & "[Plan] = '" & txtTreatmentPlan.Text & "', " _
                & "[UserName] = '" & strUserName & "', [ChangeDate] = '" & Now & "' " _
                & "WHERE ConsultationId = " & lblConsultationId.Text & ""
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On Treatment Plans Save"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub SaveDiagnosis()
        On Error GoTo RaiseErr

        Dim strSql As String = "DELETE FROM OchmasPatientsDiagnosis WHERE ConsultationId = " & lblConsultationId.Text & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        With dGridDiagnosis
            For p As Integer = 0 To .RowCount - 1
                Dim strCode As String = Nothing
                Dim strDiagnosis As String = Nothing
                If Not Object.Equals(.Rows(p).Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(0).Value.ToString) Then
                        strCode = .Rows(p).Cells(0).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(1).Value.ToString) Then
                        strDiagnosis = .Rows(p).Cells(1).Value.ToString
                    End If
                End If
                strSql = "INSERT INTO OchmasPatientsDiagnosis (PatientId, ConsultationId, " _
                    & "TransDate, DiagnosisCode, Diagnosis, UserName, ChangeDate) VALUES " _
                    & "(" & lblPatientId.Text & ", " & lblConsultationId.Text & ", " _
                    & "'" & gwt_comm.shortMonthDateFormat(dpTransDate.Value) & "', '" & strCode & "', " _
                    & "'" & strDiagnosis & "', '" & strUserName & "', '" & Now & "')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            Next
        End With


        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On Diagnosis Save"
        ShowErrorMessage()
        Cursor = Cursors.Default
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
            .DrawStringInBoxRight(e, intX, intY, 600, 25, UCase("DRUGS PRESCRIBED"), MainHeaderFont, Brushes.Black)

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
            .DrawStringInBoxLeft(e, intX + 455, intY, 140, 30, UCase(Now), DetailFont, Brushes.Black)
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

            .DrawStringInBoxLeft(e, intX + 375, intY, 60, 30, "Script No.", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 440, intY, 10, 30, ":", DetailFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 455, intY, 140, 30, FormatCurrency(intNextPrescriptionNumber, "000000"), DetailFont, Brushes.Black)

            intY = intY + 15
            e.Graphics.DrawLine(Pens.LightGray, intX, intY, 700, intY)

            '**** THIRD LINE ITEMS 
            '
            intY = intY + 5

            .DrawStringInBoxLeft(e, intX, intY, 80, 30, "Patient Address", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 85, intY, 10, 30, ":", DetailFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 95, intY, 250, 30, UCase(strPatientAddress), DetailFont, Brushes.Black)

            .DrawStringInBoxLeft(e, intX + 375, intY, 70, 30, "DOB/Gender", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 440, intY, 10, 30, ":", DetailFont, Brushes.Black)
            .DrawStringInBoxLeft(e, intX + 455, intY, 140, 30, strDobGender, DetailFont, Brushes.Black)

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

            X1 = 100 : X2 = 320 : X3 = 380 : X4 = 440 : X5 = 550 : X6 = 590 : X7 = 630

            .DrawStringInBoxLeft(e, X1 + 2, intY, 195, 15, "Description", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X2 + 2, intY, 55, 15, "Cipher", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X3 + 2, intY, 55, 15, "Dose", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X4 + 2, intY, 105, 15, "Admin", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X5 + 2, intY, 40, 15, "Days", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxCenter(e, X6 + 2, intY, 30, 15, "RPT", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxCenter(e, X7 + 2, intY, 50, 15, "FORM", SubHeaderFont, Brushes.Black)

            intY = intY + 15
            e.Graphics.DrawLine(Pens.LightGray, X1, intY, 700, intY)
            intY = intY + 15

            'Loop through the items and add them to the printing while keep track of the y-value


            While itm < arrDrugs.Count

                If intPayslipProcessingCount > 35 Then
                    intPayslipProcessingCount = 0
                    e.HasMorePages = True
                    Exit Sub
                End If

                Dim strBuffer() As String = Split(arrDrugs.Item(itm), "|")

                ''.DrawStringInBoxLeft(e, X1 + 5, intY, 55, 15, UCase(strBuffer(0)), DetailFont, Brushes.Black)
                ''.DrawStringInBoxLeft(e, X2 + 5, intY, 300, 15, UCase(strBuffer(1)), DetailFont, Brushes.Black)
                ''.DrawStringInBoxRight(e, X3 - 5, intY, 40, 15, Format(CDbl(strBuffer(2)), "##0.00"), DetailFont, Brushes.Black)
                ''.DrawStringInBoxRight(e, X4 - 5, intY, 80, 15, Format(CDbl(strBuffer(3)), "##0.00"), DetailFont, Brushes.Black)
                ''.DrawStringInBoxRight(e, X5 - 5, intY, 80, 15, Format(CDbl(strBuffer(4)), "##0.00"), DetailFont, Brushes.Black)

                .DrawStringInBoxLeft(e, X1 + 2, intY, 195, 15, UCase(strBuffer(0)), DetailFont, Brushes.Black)
                .DrawStringInBoxLeft(e, X2 + 2, intY, 55, 15, UCase(strBuffer(1)), DetailFont, Brushes.Black)
                .DrawStringInBoxRight(e, X3 + 2, intY, 55, 15, Format(CDbl(strBuffer(2)), "##0.00"), DetailFont, Brushes.Black)
                .DrawStringInBoxLeft(e, X4 + 2, intY, 105, 15, UCase(strBuffer(3)), DetailFont, Brushes.Black)
                .DrawStringInBoxRight(e, X5 + 2, intY, 40, 15, Format(CDbl(strBuffer(4)), "##0.00"), DetailFont, Brushes.Black)
                .DrawStringInBoxCenter(e, X6 + 2, intY, 30, 15, UCase(strBuffer(5)), DetailFont, Brushes.Black)
                .DrawStringInBoxLeft(e, X7 + 2, intY, 50, 15, "TABS", DetailFont, Brushes.Black)

                ''dblAmountPayable = dblAmountPayable + CDbl(strBuffer(4))

                'Draw bottom line

                'Check that description is not longer than the allocated cell and has wrapped
                ' and then get the real height to y
                intY = intY + 15
                e.Graphics.DrawLine(Pens.LightGray, X1, intY, 700, intY)
                intY = intY + 5

                intPayslipProcessingCount = intPayslipProcessingCount + 1
                itm = itm + 1

            End While

            ''Write out the total line in bold
            '.DrawStringInBoxLeft(e, X1 + 5, intY, 55, 15, "", SubHeaderFont, Brushes.Black)
            '.DrawStringInBoxLeft(e, X2 + 5, intY, 300, 15, UCase("Net Bill Amount"), SubHeaderFont, Brushes.Black)
            '.DrawStringInBoxRight(e, X3 + 5, intY, 40, 15, "", SubHeaderFont, Brushes.Black)
            '.DrawStringInBoxRight(e, X4 + 5, intY, 80, 15, "", SubHeaderFont, Brushes.Black)
            '.DrawStringInBoxRight(e, X5 - 5, intY, 80, 15, Format(CDbl(dblAmountPayable), "##0.00"), SubHeaderFont, Brushes.Black)

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
            e.Graphics.DrawLine(Pens.LightGray, X6, yStart, X6, intVerticalHeight)

            X7 = 700
            e.Graphics.DrawLine(Pens.LightGray, X7, yStart, X7, intVerticalHeight)


            '''
            '''********************* CREATE PAYMENT SPLIT 
            '''
            ''intY = intY + 10

            ''reccurrent = New Rectangle(intX, intY, 600, intY_height)
            ''e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)
            ''e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), reccurrent)

            ''.DrawStringInBoxLeft(e, intX + 10, intY + 3, 600, 15, "Payment Breakdown", SubHeaderFont, Brushes.Black)

            ''' Draw table withou filling in first
            ''intY = intY + 17
            ''reccurrent = New Rectangle(intX, intY, 600, 40)
            ''e.Graphics.DrawRectangle(Pens.LightGray, reccurrent)

            '''draw line accross the rectangle
            ''e.Graphics.DrawLine(Pens.LightGray, X1, intY + 20, 700, intY + 20)


            '''Draw the vericals after items
            ''X1 = 100 : X2 = 200 : X3 = 300 : X4 = 400 : X5 = 500 : X6 = 600

            ''yStart = intY
            ''intVerticalHeight = yStart + 40

            ''e.Graphics.DrawLine(Pens.LightGray, X1, yStart, X1, intVerticalHeight)
            ''e.Graphics.DrawLine(Pens.LightGray, X2, yStart, X2, intVerticalHeight)
            ''e.Graphics.DrawLine(Pens.LightGray, X3, yStart, X3, intVerticalHeight)
            ''e.Graphics.DrawLine(Pens.LightGray, X4, yStart, X4, intVerticalHeight)
            ''e.Graphics.DrawLine(Pens.LightGray, X5, yStart, X5, intVerticalHeight)
            ''e.Graphics.DrawLine(Pens.LightGray, X6, yStart, X6, intVerticalHeight)

            ''.DrawStringInBoxLeft(e, X1 + 10, intY + 5, 100, 15, "Cash", SubHeaderFont, Brushes.Black)
            ''.DrawStringInBoxLeft(e, X2 + 10, intY + 5, 100, 15, "Ecocash", SubHeaderFont, Brushes.Black)
            ''.DrawStringInBoxLeft(e, X3 + 10, intY + 5, 100, 15, "Swipe", SubHeaderFont, Brushes.Black)
            ''.DrawStringInBoxLeft(e, X4 + 10, intY + 5, 100, 15, "Transfer", SubHeaderFont, Brushes.Black)
            ''.DrawStringInBoxLeft(e, X5 + 10, intY + 5, 100, 15, "Other", SubHeaderFont, Brushes.Black)
            ''.DrawStringInBoxLeft(e, X6 + 10, intY + 5, 100, 15, "Total", SubHeaderFont, Brushes.Black)

            ''intY = intY + 25

            '''Print the actual values
            ''.DrawStringInBoxRight(e, X1 + 10, intY, 85, 15, CStr(Format(dblCash, "#,##0.00")), DetailFont, Brushes.Black)
            ''.DrawStringInBoxRight(e, X2 + 10, intY, 85, 15, CStr(Format(dblEcocash, "#,##0.00")), DetailFont, Brushes.Black)
            ''.DrawStringInBoxRight(e, X3 + 10, intY, 85, 15, CStr(Format(dblSwipe, "#,##0.00")), DetailFont, Brushes.Black)
            ''.DrawStringInBoxRight(e, X4 + 10, intY, 85, 15, CStr(Format(dblTransfer, "#,##0.00")), DetailFont, Brushes.Black)
            ''.DrawStringInBoxRight(e, X5 + 10, intY, 85, 15, CStr(Format(dblOtherPaymentMethods, "#,##0.00")), DetailFont, Brushes.Black)
            ''.DrawStringInBoxRight(e, X6 + 10, intY, 85, 15, CStr(Format((dblCash + dblEcocash + dblSwipe + dblTransfer + dblOtherPaymentMethods), "#,##0.00")), DetailFont, Brushes.Black)

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
            .DrawStringInBoxRight(e, X1, intY + 5, 90, 15, "PROCESSED BY :", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X2, intY + 5, 150, 15, strPublicActiveFullUserName, DetailFont, Brushes.Black)

            .DrawStringInBoxLeft(e, X3 + 70, intY + 5, 120, 15, "REFERRING DR :", SubHeaderFont, Brushes.Black)
            .DrawStringInBoxLeft(e, X3 + 160, intY + 5, 150, 15, strAttendingDoctor, DetailFont, Brushes.Black)

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

    Private Sub dGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGrid.CellContentClick
        If e.ColumnIndex = dGrid.ColumnCount - 1 Then
            dGrid.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter
        On Error GoTo RaiseErr

        'If cboCipher.Visible = True Then cboCipher.Visible = False

        Dim dg As DataGridView = DirectCast(sender, DataGridView)
        If dg.CurrentCell.EditType = GetType(DataGridViewComboBoxEditingControl) Then
            SendKeys.Send("{F4}")
            Exit Sub
        End If

        'If e.ColumnIndex = 3 Then
        '    With cboCipher
        '        .Size = dGrid.CurrentCell.Size
        '        .Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + 42
        '        .Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left + 1
        '        .Visible = True
        '        .Focus()
        '        .SelectAll()
        '        .DroppedDown = True
        '    End With
        'End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on dispensing ciphers load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadCiphers()

        '        On Error GoTo RaiseErr

        '        'Load the cost centers
        '        Dim objCommand As Data.OleDb.OleDbCommand
        '        Dim objReader As Data.OleDb.OleDbDataReader
        '        Dim strSql As String = Nothing

        '        If UCase(strSearchCriteria) = UCase("Description") Then
        '            strSql = "SELECT Instruction +';'+ Code FROM OchmasDispensingCiphers ORDER BY Instruction"
        '        Else
        '            strSql = "SELECT Code +';'+ Instruction FROM OchmasDispensingCiphers ORDER BY Code"
        '        End If

        '        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        '        objReader = objCommand.ExecuteReader
        '        'Set up the drop down combo box
        '        With cboCipher
        '            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
        '            .ColumnNum = 2
        '            .HighlightBorderOnMouseEvents = True
        '            .ManagingFastMouseMoving = True
        '            .Enabled = True
        '            .DropDownHeight = 110
        '            .GridLineHorizontal = True
        '            .GridLineVertical = True
        '            If UCase(strSearchCriteria) = UCase("Code") Then
        '                .ColumnWidth = "75;160"
        '            Else
        '                .ColumnWidth = "160;75"
        '            End If
        '        End With

        '        Dim arrItems As New ArrayList
        '        arrItems.Add(" ; ")

        '        While objReader.Read
        '            arrItems.Add(objReader(0).ToString)
        '        End While
        '        objReader.Close()

        '        Dim DropDownItemsCenters(arrItems.Count - 1) As MTGCComboBoxItem

        '        'Continue to read until you reach the end of the file.
        '        'Add blank line

        '        For p As Integer = 0 To arrItems.Count - 1
        '            Dim strRecordText() As String = Split(arrItems.Item(p), ";")
        '            DropDownItemsCenters(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        '        Next

        '        If arrItems.Count > 0 Then
        '            With cboCipher
        '                .SelectedIndex = -1
        '                .Items.Clear()
        '                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        '                .Items.AddRange(DropDownItemsCenters)
        '            End With
        '        End If

        '        Exit Sub
        'RaiseErr:
        '        boolAbort = True
        '        Cursor = Cursors.Default
        '        strErrorMessages = Err.Description & " " & Err.Number & " on dispensing ciphers Load"
        '        ShowErrorMessage()
    End Sub

    'Private Sub cboCipher_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCipher.LostFocus
    '    cboCipher.Visible = False
    'End Sub

    'Private Sub cboCipher_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCipher.SelectedIndexChanged
    '    If Not cboCipher.SelectedItem Is Nothing Then
    '        If UCase(strSearchCriteria) = UCase("Description") Then
    '            dGrid.CurrentRow.Cells(3).Value = cboCipher.SelectedItem.Col2
    '        Else
    '            dGrid.CurrentRow.Cells(3).Value = cboCipher.SelectedItem.Col1
    '        End If
    '    Else
    '        dGrid.CurrentRow.Cells(3).Value = Nothing
    '    End If
    'End Sub

    ''Private Sub cboCipher_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCipher.KeyPress
    ''    If Asc(e.KeyChar) = 13 Then
    ''        dGrid.CurrentCell = dGrid.Rows(dGrid.CurrentRow.Index).Cells(4)
    ''        dGrid.Focus()
    ''    End If
    ''End Sub

    Private Function ComboBoxColumn(ArrItems As ArrayList, Optional HeaderText As String = Nothing, Optional Alignment As String = "Left") As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn
        Dim column As New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn
        With column
            .HeaderText = ""
            .DropDownWidth = 100
            .MaxDropDownItems = 5
            .HeaderText = HeaderText
            .Items.Clear()
            For p As Integer = 0 To ArrItems.Count - 1
                .Items.Add(ArrItems.Item(p))
            Next
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Select Case UCase(Alignment)
                Case = "LEFT"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case = "RIGHT"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case = "CENTER"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End Select
        End With
        Return column
    End Function

    Private Function TextColumn(Optional HeaderText As String = Nothing, Optional Alignment As String = "Left") As ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn
        Dim txt As New ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn
        With txt
            .HeaderText = HeaderText
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Select Case UCase(Alignment)
                Case = "LEFT"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                Case = "RIGHT"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case = "CENTER"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End Select
        End With
        Return txt
    End Function

    Private Sub AddGridColumns()

        On Error GoTo RaiseErr

        Dim arrCiphers As New ArrayList
        Dim arrAdmin As New ArrayList
        Dim arrRepeat As New ArrayList

        With arrRepeat
            .Add("N")
            .Add("Y")
        End With

        Dim strSql As String = "SELECT Code From OchmasDispensingCiphers ORDER BY Code"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            arrCiphers.Add(objReader(0).ToString)
        End While
        objReader.Close()

        strSql = "SELECT DISTINCT(Method) FROM OchmasSystemMedicinesAdminMethods ORDER BY Method"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            arrAdmin.Add(objReader(0).ToString)
        End While
        objReader.Close()

        With dGrid
            '.Columns.Clear()
            .Columns.Insert(0, TextColumn("Code", "Left"))
            .Columns.Insert(1, TextColumn("Name", "Left"))
            .Columns.Insert(2, TextColumn("Info", "Left"))
            .Columns.Insert(3, ComboBoxColumn(arrCiphers, "Cipher", "Left"))
            .Columns.Insert(4, TextColumn("Dos", "Right"))
            .Columns.Insert(5, ComboBoxColumn(arrAdmin, "Admin", "Left"))
            .Columns.Insert(6, TextColumn("Period", "Right"))
            .Columns.Insert(7, ComboBoxColumn(arrRepeat, "RPT", "Left"))
            '.Columns.Add(TextColumn("DEL", "Left"))
        End With

        For p As Integer = 0 To dGrid.ColumnCount - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            If p = 0 Or p = 1 Then
                dGrid.Columns(p).ReadOnly = True
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on grid columns create"
        ShowErrorMessage()
    End Sub

End Class