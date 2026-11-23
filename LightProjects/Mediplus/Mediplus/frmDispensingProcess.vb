Imports System.Drawing.Printing
Imports System.IO
Imports System.Text
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDispensingProcess

    Dim strPatientAddress(0 To 3) As String
    Dim strProviderAddress(0 To 3) As String

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGridEntry_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgridEntry.CellEndEdit
        If dGridEntry.CurrentCell.ColumnIndex = 1 Then
            If IsNumeric(dGridEntry.CurrentCell.Value) Then
                dGridEntry.CurrentCell.Value = Format(CDbl(dGridEntry.CurrentCell.Value.ToString), "##0.00")
            Else
                dGridEntry.CurrentCell.Value = "0.00"
            End If
        End If
    End Sub

    Private Sub dGridEntry_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgridEntry.EditingControlShowing
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

    Private Sub frmPrescriptionProcessing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        With Me
            .Width = 905
            .Height = 645 '903, 644
        End With
        dGridEntry.Rows.Add(1)
        LoadPatients()
        LoadProviders()
        If boolEditStatus = True Then
            LoadSelectedPrescriptionData()
        End If
    End Sub

    Private Sub LoadSelectedPrescriptionData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT DrugCode, CAST(CostPrice AS DECIMAL (10,2)) AS [Cost], " _
            & "CAST(SellingPrice AS DECIMAL (10,2)) AS [SalePrice], CAST(Quantity AS DECIMAL (10,2)) AS [Qty], " _
            & "CAST(Discount AS DECIMAL (10,2)) AS [Discount], CAST(Taxes AS DECIMAL (10,2)) AS [Tax], " _
            & "Dosage, DrugName, DispensingFees, PatientReferenceNumber, CAST(ShortFall AS DECIMAL (10,2)) AS [ShortFall] " _
            & "FROM DispensingDetails WHERE PrescriptionNumber = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim intCount As Integer = 0
        Dim PatientNumber As Integer = 0
        'DrugName, Qty, UnitPrice, Fee, Payable, Shortfall, Dosage, DrugCode

        dGrid.Rows.Clear()
        Dim dblLineTotal As Double = 0
        While objReader.Read
            If intCount = 0 Then
                PatientNumber = CInt(objReader("PatientReferenceNumber").ToString)
            End If
            Dim dblPayable As Double = ((CDbl(objReader("SalePrice")) * CDbl(objReader("Qty"))) - CDbl(objReader("Discount"))) + CDbl(objReader("Tax"))
            dGrid.Rows.Add(objReader("DrugName"), objReader("Qty"), objReader("SalePrice"), _
                objReader("DispensingFees"), Format(dblPayable, "##0.00"), objReader("ShortFall"), _
                objReader("Dosage"), objReader("DrugCode"))
            dblLineTotal = dblLineTotal + dblPayable
            intCount = intCount + 1
        End While
        objReader.Close()
        lblTotal.Text = Format(dblLineTotal, "##0.00")
        lblPayable.Text = Format(dblLineTotal, "##0.00")

        'Load the patient details
        strSql = "SELECT * FROM DispensingMain WHERE PatientReferenceNumber = " & PatientNumber & " " _
            & "AND PrescriptionNumber = " & intSelectedTransaction & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows = True Then
            objReader.Read()
            If Not IsDBNull(objReader("PatientNames").ToString) Then cboPatientName.Text = objReader("PatientNames").ToString
            If Not IsDBNull(objReader("PractitionerName").ToString) Then txtProvider.Text = objReader("PractitionerName").ToString

            If Not IsDBNull(objReader("PractitionerAddress1").ToString) Then txtProviderAddress.Text = objReader("PractitionerAddress1").ToString
            If Not IsDBNull(objReader("PractitionerAddress2").ToString) Then txtProviderAddress.Text = txtProviderAddress.Text & vbCrLf & objReader("PractitionerAddress2").ToString
            If Not IsDBNull(objReader("PractitionerAddress3").ToString) Then txtProviderAddress.Text = txtProviderAddress.Text & vbCrLf & objReader("PractitionerAddress3").ToString
            If Not IsDBNull(objReader("PractitionerAddress4").ToString) Then txtProviderAddress.Text = txtProviderAddress.Text & vbCrLf & objReader("PractitionerAddress4").ToString

            If Not IsDBNull(objReader("PractitionerNumber").ToString) Then txtProviderNumber.Text = objReader("PractitionerNumber").ToString
            If IsDate(objReader("DoctorVisitDate").ToString) Then dpVisitDate.Text = CDate(objReader("DoctorVisitDate").ToString)
            If IsDate(objReader("TransactionDate").ToString) Then dpTransDate.Text = CDate(objReader("TransactionDate").ToString)
            dpTransDate.Enabled = False
        End If
        objReader.Close()

        txtReference.Text = intSelectedTransaction
        lblStatus.Text = "DISPENSED"
        objCommand = New Data.OleDb.OleDbCommand("SELECT Status from DispensingDetails WHERE PrescriptionNumber = " & intSelectedTransaction & "", cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then lblStatus.Text = UCase(objReader(0).ToString)
        End If
        objReader.Close()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Dispensind Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadProviders()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT Name +';'+ " _
            & "RegistrationNumber FROM OchmasSystemMedicalAids ORDER BY Name"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboMedicalAid
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "200;60"
        End With

        Dim arrData As New ArrayList

        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Get a count of the items
        Dim intItemsCount As Double = arrData.Count
        Dim DropDownItems(0 To (intItemsCount - 1)) As MTGCComboBoxItem

        cboMedicalAid.Items.Clear()

        For p As Integer = 0 To arrData.Count - 1
            Dim strRecordText() As String = Split(arrData.Item(p), ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        If intItemsCount > 0 Then
            cboMedicalAid.SelectedIndex = -1
            cboMedicalAid.Items.Clear()
            cboMedicalAid.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboMedicalAid.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Medical Aid Providers Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadPatients()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT LastName +' '+ FirstName +';'+ " _
            & "CONVERT(NVARCHAR, ReferenceNumber) FROM OchmasPatients ORDER BY LastName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        Dim intCol1Width As Integer = cboPatientName.Width - 30
        With cboPatientName
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intCol1Width & ";0"
        End With

        Dim arrData As New ArrayList

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
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
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
        strErrorMessages = Err.Description & " " & Err.Number & " on Patient Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGridEntriy_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgridEntry.KeyDown
        If UCase(lblStatus.Text) <> "PENDING" Then
            MessageBox.Show("The prescription has already been processed " & _
                 vbCrLf & "and paid for. No changes can be made it", _
                "Process Prevented by System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.SuppressKeyPress = True
            Exit Sub
        End If
        If e.KeyValue = 9 Then
            If dgridEntry.CurrentCell.ColumnIndex = 0 Then
                strSelectedCode = Nothing
                strSelectedCodeDescription = Nothing
                strSelectedItemTaxStatus = Nothing
                boolAbort = False
                strCallingForm = "DISPENSING"
                Dim frm As New frmDrugSearch
                frm.ShowDialog()
                If boolAbort = True Then
                    e.SuppressKeyPress = True
                    'dGridEntriy.CurrentCell = dGridEntriy.CurrentRow.Cells(0)
                Else
                    dgridEntry.CurrentCell.Value = strSelectedCodeDescription
                    dgridEntry.CurrentRow.Cells(1).Value = strSelectedCode
                    dgridEntry.CurrentCell = dgridEntry.CurrentRow.Cells(1)
                End If
            End If

            If dgridEntry.CurrentCell.ColumnIndex = 3 Then
                strSelectedCode = Nothing
                strSelectedCodeDescription = Nothing
                boolAbort = False
                Dim frm As New frmDispensingCiphersSearch
                frm.ShowDialog()
                If boolAbort = True Then
                    e.SuppressKeyPress = True
                    'dGridEntriy.CurrentCell = dGridEntriy.CurrentRow.Cells(0)
                Else
                    dgridEntry.CurrentCell.Value = strSelectedCode
                    dgridEntry.CurrentRow.Cells(4).Value = strSelectedCodeDescription
                    'dGridEntriy.CurrentCell = dGridEntriy.CurrentRow.Cells(1)
                End If
            End If

            If dgridEntry.CurrentCell.ColumnIndex = dgridEntry.ColumnCount - 1 Then
                'Check that the data is correctly entered
                Dim strDrugName As String = Nothing
                Dim strDrugCode As String = Nothing
                Dim dblQuantity As Double = 0
                Dim strDrugCipher As String = Nothing
                Dim strCipher As String = Nothing

                e.SuppressKeyPress = True
                If Not Object.Equals(dgridEntry.CurrentRow.Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dgridEntry.CurrentRow.Cells(0).Value.ToString) Then
                        strDrugName = dgridEntry.CurrentRow.Cells(0).Value.ToString
                    End If
                End If
                If Not Object.Equals(dgridEntry.CurrentRow.Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dgridEntry.CurrentRow.Cells(1).Value.ToString) Then
                        strDrugCode = dgridEntry.CurrentRow.Cells(1).Value.ToString
                    End If
                End If
                If Not Object.Equals(dgridEntry.CurrentRow.Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dgridEntry.CurrentRow.Cells(2).Value.ToString) Then
                        If IsNumeric(dgridEntry.CurrentRow.Cells(2).Value.ToString) Then
                            dblQuantity = dgridEntry.CurrentRow.Cells(2).Value.ToString
                        End If
                    End If
                End If
                If Not Object.Equals(dgridEntry.CurrentRow.Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dgridEntry.CurrentRow.Cells(3).Value.ToString) Then
                        strDrugCipher = dgridEntry.CurrentRow.Cells(3).Value.ToString
                    End If
                End If

                If Not Object.Equals(dgridEntry.CurrentRow.Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dgridEntry.CurrentRow.Cells(4).Value.ToString) Then
                        strCipher = dgridEntry.CurrentRow.Cells(4).Value.ToString
                    End If
                End If

                If String.IsNullOrEmpty(strDrugName) Then
                    MessageBox.Show("Missing the drug name. Please correct this error", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgridEntry.CurrentCell = dgridEntry.CurrentRow.Cells(0)
                    Exit Sub
                End If

                If String.IsNullOrEmpty(CStr(dblQuantity)) Then
                    MessageBox.Show("Missing the dispensing quantity. Please correct this error", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgridEntry.CurrentCell = dgridEntry.CurrentRow.Cells(2)
                    Exit Sub
                End If

                If String.IsNullOrEmpty(strDrugCode) Then
                    MessageBox.Show("Missing the drug code. Please correct this error", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgridEntry.CurrentCell = dgridEntry.CurrentRow.Cells(0)
                    Exit Sub
                End If

                If String.IsNullOrEmpty(strDrugCipher) Then
                    MessageBox.Show("Missing the drug cipher. Please correct this error", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgridEntry.CurrentCell = dgridEntry.CurrentRow.Cells(3)
                    Exit Sub
                End If

                'Accept the items here
                Dim dblUnitPrice As Double = DrugUnitPrice(strDrugCode)
                Dim dblLineTotal As Double = dblUnitPrice * dblQuantity

                dGrid.Rows.Add(strDrugName, dblQuantity, Format(dblUnitPrice, "##0.00"), "0.00", Format(dblLineTotal, "##0.00"), "0.00", _
                    strCipher, strDrugCode)
                'Accumulate the totals on top
                Dim MovingTotal As Double = 0
                MovingTotal = CDbl(lblTotal.Text) + dblLineTotal
                lblTotal.Text = Format(MovingTotal, "##0.00")

                'Compute payable
                Dim dblPayable As Double = 0
                dblPayable = CDbl(lblTotal.Text) - CDbl(lblShortfall.Text)
                lblPayable.Text = Format(dblPayable, "##0.00")


                'Reset the grid values to nothing 
                For p As Integer = 0 To dgridEntry.ColumnCount - 1
                    dgridEntry.Rows(0).Cells(p).Value = Nothing
                Next
                dgridEntry.CurrentCell = dgridEntry.CurrentRow.Cells(0)

            End If

        End If
    End Sub

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

    Private Function DrugUnitPrice(DrugCode As String) As Double
        Dim dblReturn As Double = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SellPrice FROM OchmasSystemMedicines " _
            & "WHERE ProductCode = '" & DrugCode & "'", cnn)
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
        strErrorMessages = Err.Description & " " & Err.Number & " on Drug Unit Price Fetch"
        ShowErrorMessage()
    End Function

    Private Sub btnFinish_Click(sender As System.Object, e As System.EventArgs) Handles btnFinish.Click
        boolAbort = False
        FinishSale()
        If boolAbort = True Then Exit Sub
        If UCase(strCompanyPrintClaim) = "YES" Then
            'If MsgBox("Do you want to print the medical claim now?", MsgBoxStyle.YesNo, "Confirm Claim Print") = MsgBoxResult.Yes Then
            'PrintInvoice(Format(dpTransDate.Value, "dd-MMM-yyyy"))
            PrintToFile()
        End If
        'Make sure that the printer is different this time around. Preferable have the user select the printer
        PrintDosage()
        ClearControls()
        If strPublicSalesAccount = "0000" Then strPublicSalesAccount = Nothing
    End Sub

    Private Sub ClearControls()
        dGrid.Rows.Clear()
        lblPayable.Text = "0.00"
        lblShortfall.Text = "0.00"
        lblTotal.Text = "0.00"
        txtMainMemberName.Clear()
        txtMedaidNumber.Clear()
        txtPatientAddress.Clear()
        txtProvider.Clear()
        txtProviderAddress.Clear()
        txtProviderNumber.Clear()
        txtReference.Clear()
        txtSuffix.Text = "00"
        cboMedicalAid.Text = ""
        cboPatientName.Text = ""
    End Sub

    Private Sub PrintDosage()
        On Error GoTo RaiseErr
        Dim arrAllData As New ArrayList 'Holds the lines for all dosage instructions
        For i As Int16 = 0 To dGrid.Rows.Count - 1
            Dim strDrugName As String = Nothing
            Dim strPresentation As String = Nothing
            Dim strStrength As String = Nothing
            Dim strInstruction As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(6).Value), "")) Then
                Dim arrDosage As New ArrayList 'Hold the lines for the current dosage
                strInstruction = dGrid.Rows(i).Cells(6).Value.ToString

                'The instruction is built from the ciphers. We split the string to get the actual instructions
                Dim strCipheredInstruction As String = Nothing

                'If Mid(strInstruction, 1, 1) = "*" And Mid(strInstruction, strInstruction.Length, 1) = "*" Then
                'This means that the instruction must be taken literal

                strCipheredInstruction = strCipheredInstruction & strInstruction

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    strDrugName = dGrid.Rows(i).Cells(0).Value.ToString
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(1).Value.ToString) Then
                        strPresentation = "QTY:" & dGrid.Rows(i).Cells(1).Value.ToString
                    End If
                End If

                'If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                Dim strDrugCode As String = Nothing
                If Not Object.Equals(dGrid.Rows(i).Cells(7).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(7).Value.ToString) Then
                        strDrugCode = dGrid.Rows(i).Cells(7).Value.ToString
                    End If
                End If

                'Get the strength and batchnumber and expiry date at the same time
                strStrength = GetDrugStrength(strDrugCode)

                'End If

                'We are going to make sure that each line contains
                Dim intWordCnt As Integer = 0
                Dim strLine As String = Nothing
                arrDosage.Add(UCase(strDrugName) & " " & UCase(strPresentation) & " " & UCase(strStrength))
                arrDosage.Add(StrDup(48, "-"c))
                For n As Int16 = 0 To strCipheredInstruction.Length - 1
                    If intWordCnt < 48 Then
                        strLine = strLine & strCipheredInstruction.Substring(n, 1)
                    Else
                        strLine = strLine & "-"
                        arrDosage.Add(strLine)
                        strLine = Nothing
                        intWordCnt = 0
                    End If
                Next
                'Add the last line
                arrDosage.Add(strLine)
                'Add the user name
                arrDosage.Add(UCase(strUserName))
                'Add the patient name
                arrDosage.Add(UCase(cboPatientName.Text) & " - " & UCase(Format(dpTransDate.Value, "dd-MMM-yyyy")))
                arrDosage.Add(StrDup(48, "-"c))
                'Add the pharmacy name
                arrDosage.Add(UCase(strCompanyName))
                'Add the company address and contact number
                arrDosage.Add(UCase(strCompanyAddress1) & ", " & UCase(strCompanyAddress2) & ", " & UCase(strCompanyTelephone))
                'Check that the number of lines per instruction is 9
                If arrDosage.Count < 8 Then
                    For y As Int16 = arrDosage.Count To 7
                        arrDosage.Add(Space(48))
                    Next
                End If
                'Add the data to the final print array
                For y As Integer = 0 To arrDosage.Count - 1
                    arrAllData.Add(arrDosage.Item(y))
                Next
                'push label 2 lines down
                arrAllData.Add(Space(48))
                'arrAllData.Add(Space(48))
                'arrDosage.Add(Space(48))
                'arrDosage.Add(Space(48))
            End If
        Next

        If arrAllData.Count > 0 Then
            boolAbort = False

            Dim pd As New PrintDialog()
            pd.PrinterSettings = New PrinterSettings()

            Dim frmPrinter As New frmPrinterSetup()
            frmPrinter.ShowDialog()

            If boolAbort = True Then Exit Sub
            pd.PrinterSettings.PrinterName = strSessionPrinter

            If MsgBox("Do you want to continue and print?", MsgBoxStyle.YesNo, "Confirm Printing") = MsgBoxResult.Yes Then
                'Send to the raw printer
                For n = 0 To arrAllData.Count - 1
                    Dim strPrintLineDetails As String = arrAllData.Item(n) & vbCrLf
                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintLineDetails)
                Next
                MsgBox("Printing completed successfully", MsgBoxStyle.Information, "Printing Success")
            End If
        Else
            MsgBox("No data to print", MsgBoxStyle.Exclamation, "Printing Error")
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error while printing medicines instructions"
        ShowErrorMessage()
    End Sub

    Private Function GetDrugStrength(DrugCode) As String
        Dim strReturn As String = Nothing
        Dim strSql As String = "SELECT Strength FROM OchmasSystemMedicines WHERE ProductCode = '" & DrugCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
        End If
        objReader.Close()

        Dim intReference As Integer = 0
        strSql = "SELECT MAX(ReferenceNumber) FROM OchmasReceivedDrugs WHERE DrugCode = '" & DrugCode & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intReference = CInt(objReader(0).ToString)
        End If
        objReader.Close()

        strSql = "SELECT BatchNumber, UPPER(REPLACE(CONVERT(CHAR(11), ExpiryDate, 105), ' ', '-')) AS [Date] " _
            & "FROM OchmasReceivedDrugs WHERE DrugCode = '" & DrugCode & "' AND ReferenceNumber = " & intReference & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                strReturn = strReturn & " BATCH NO. " & UCase(objReader(0).ToString)
            End If
            If Not IsDBNull(objReader(1).ToString) Then
                strReturn = strReturn & " EX. DATE " & UCase(objReader(1).ToString)
            End If
        End If
        objReader.Close()

        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error while printing medicines instructions"
        ShowErrorMessage()
    End Function

    Private Sub PrintToFile()
        On Error GoTo RaiseErr
        Dim objFileWriter As New System.IO.StreamWriter(Application.StartupPath & "\SCRIPT", False)
        Dim strLine As String = Space(80)

        For p As Integer = 0 To 3
            strPatientAddress(p) = Nothing
        Next

        Dim strAddressData() As String = Split(txtPatientAddress.Text, vbCrLf)
        If strAddressData.Length > 1 Then strPatientAddress1 = strAddressData(0)
        If strAddressData.Length > 2 Then strPatientAddress2 = strAddressData(1)
        If strAddressData.Length > 3 Then strPatientAddress3 = strAddressData(2)
        If strAddressData.Length = 4 Then strPatientAddress4 = strAddressData(3)

        'Write 4 blank lines at the top
        For i As Integer = 0 To 3
            objFileWriter.WriteLine(strLine)
        Next
        strLine = Space(11) & UCase(cboPatientName.Text) & Space(50 - cboPatientName.Text.Length) & Space(18) & UCase(cboMedicalAid.Text)
        objFileWriter.WriteLine(strLine)

        'Write the address 1
        strLine = Space(11) & UCase(strPatientAddress(1))
        objFileWriter.WriteLine(strLine)
        'Write the second address and the date at the far left
        strLine = Space(11) & UCase(strPatientAddress(2)) & Space(73) & UCase(Format(dpTransDate.Value, "dd-MMM-yyyy"))
        objFileWriter.WriteLine(strLine)
        'write the third line address
        strLine = Space(11) & UCase(strPatientAddress(3))
        objFileWriter.WriteLine(strLine)
        'Skip one line and print the member name
        objFileWriter.WriteLine(Space(80))

        Dim strMemberName As String = cboPatientName.Text
        If Not String.IsNullOrEmpty(txtMainMemberName.Text) Then strMemberName = txtMainMemberName.Text
        strLine = Space(25) & UCase(strMemberName)
        objFileWriter.WriteLine(strLine)
        'Print the claim number at the extreme right
        'strLine = Space(80) & UCase(txtReference.Text)
        'objFileWriter.WriteLine(strLine)

        'Print the medical aid number of the member after skipping 1 line
        strLine = Space(80)
        objFileWriter.WriteLine(strLine)
        strLine = Space(25) & UCase(txtMedaidNumber.Text)
        objFileWriter.WriteLine(strLine)

        'Skip 1 line and then print the gross amount claimed i.e. payable label
        strLine = Space(80)
        objFileWriter.WriteLine(strLine)
        strLine = Space(40) & UCase(Format(CDbl(lblPayable.Text), "##0.00"))
        objFileWriter.WriteLine(strLine)

        'Skip a line and then print the suffix and the date of birth
        strLine = Space(80)
        objFileWriter.WriteLine(strLine)
        Dim strSuffix As String = "0"
        If IsNumeric(txtSuffix.Text) Then strSuffix = txtSuffix.Text
        strSuffix = Format(CInt(strSuffix), "00")
        Dim strSplit() As String = Split(dpDob.Text, "-")
        strLine = Space(59) & UCase(strSuffix) & Space(6) & Format(CInt(strSplit(0)), "00") & Space(4) & Format(CInt(strSplit(2)), "00") & Space(4) & Mid(CStr(Format(CInt(strSplit(2)), "0000")), 3, 2)
        objFileWriter.WriteLine(strLine)

        'Skip the next 6 lines up to the practitioner details
        strLine = Space(80)
        For i As Integer = 0 To 4
            objFileWriter.WriteLine(strLine)
        Next

        strLine = Space(5) & UCase(txtProviderNumber.Text) & Space(28 - txtProviderNumber.Text.Length) & UCase(strCompanyRegistrationNumber) & Space(30 - UCase(strCompanyRegistrationNumber.Length)) & UCase(txtReference.Text)
        objFileWriter.WriteLine(strLine)

        'Print the name of the pharmacy after advancing 4 lines
        strLine = Space(80)
        objFileWriter.WriteLine(strLine)

        strLine = Space(17) & UCase(strCompanyName) & Space(70 - strCompanyName.Length) & UCase(txtProvider.Text)
        objFileWriter.WriteLine(strLine)

        'Print the details after advancing 2 lines
        strLine = Space(80)
        For i As Integer = 0 To 1
            objFileWriter.WriteLine(strLine)
        Next
        Dim intLinesCount As Integer = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then

                Dim intQty As Integer = 0, dblTax As Double = 0, dblUprice As Double = 0, dblDisAmount As Double = 0, _
                   strDescription As String = Nothing, strSelectedId As String = Nothing

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                    strSelectedId = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
                    If strSelectedId.Length > 8 Then strSelectedId = Mid(strSelectedId, 1, 8)
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    strDescription = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                    If strDescription.Length > 34 Then strDescription = Mid(strDescription, 1, 34)
                End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                    intQty = Convert.ToDouble(dGrid.Rows(i).Cells(5).Value)
                End If
                'If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(8).Value), "")) Then
                '    dblTax = Convert.ToDouble(dGrid.Rows(i).Cells(8).Value)
                'End If
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "")) Then
                    dblUprice = Convert.ToDouble(dGrid.Rows(i).Cells(4).Value)
                End If
                'If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "")) Then
                '    dblDisAmount = Convert.ToDouble(dGrid.Rows(i).Cells(7).Value)
                'End If
                strLine = strDescription & Space(35 - strDescription.Length) & Space(4) & strSelectedId & Space(12 - strSelectedId.Length) & CStr(intQty) & Space(16 - CStr(intQty).Length) & Space(10 - CStr(Format(dblUprice, "##0.00")).Length) & CStr(Format(dblUprice, "##0.00"))
                objFileWriter.WriteLine(UCase(strLine))
                objFileWriter.WriteLine(Space(80))
                intLinesCount = intLinesCount + 1
            End If
        Next
        'Insert balnk lines for empty spaces
        For i As Integer = (intLinesCount + 1) To 5
            objFileWriter.WriteLine(Space(80))
        Next
        'Print the gross payable
        strLine = Space(68) & Space(10 - CStr(Format(CDbl(lblPayable.Text), "##0.00")).Length) & CStr(Format(CDbl(lblPayable.Text), "##0.00"))
        objFileWriter.Write(strLine)
        objFileWriter.Close()
        PrintScript()
        MsgBox("Script generated successfully", MsgBoxStyle.Information, "Script Generation Success")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Prescription Print to file"
        ShowErrorMessage()
    End Sub

    Private Sub PrintScript()
        On Error GoTo RaiseErr
        If System.IO.File.Exists(Application.StartupPath & "\SCRIPT") Then
            Dim objFileReader As New System.IO.StreamReader(Application.StartupPath & "\SCRIPT")
            Dim strLine As String = objFileReader.ReadToEnd
            objFileReader.Close()
            Dim strPrintData() As String = Split(strLine, vbCrLf)
            Dim pd As New PrintDialog()
            pd.ShowDialog()
            pd.PrinterSettings = New PrinterSettings()
            For i As Integer = 0 To strPrintData.Length - 2
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintData(i))
            Next
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Prescription Print Failure"
        ShowErrorMessage()
    End Sub

    Private Sub FinishSale()

        On Error GoTo RaiseErr

        Dim strSelectedId As String
        Dim strDescription As String
        Dim strDosage As String
        Dim intQty As Double
        Dim dblUprice As Double
        Dim insertCustomer As String
        Dim dblTax As Double
        Dim i As Double
        Dim dblShortfall As Double = 0
        Dim dpProcessDate As Date = Format(DateTime.Now, "dd-MMM-yyyy")
        Dim dblDisAmount As Double 'for discounts
        Dim dblSumTaxes As Double = 0, dblSumDiscounts As Double = 0, dblSumPayable As Double = 0
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim dbReader As Data.OleDb.OleDbDataReader

        If Not IsNumeric(txtSuffix.Text) Then txtSuffix.Text = "00"

        If dGrid.Rows.Count <= 0 Then
            MsgBox("No document transactions to print !!!", MsgBoxStyle.Exclamation, "Empty Document Transactions")
            Exit Sub
        End If

        'Get the formated patient address

        For p As Integer = 0 To 3
            strPatientAddress(p) = Nothing
        Next

        Dim strAddressData() As String = Split(txtPatientAddress.Text, vbCrLf)
        If strAddressData.Length >= 1 Then strPatientAddress1 = strAddressData(0)
        If strAddressData.Length >= 2 Then strPatientAddress2 = strAddressData(1)
        If strAddressData.Length >= 3 Then strPatientAddress3 = strAddressData(2)
        If strAddressData.Length >= 4 Then strPatientAddress4 = strAddressData(3)

        'Get the provider address formatted

        For p As Integer = 0 To strAddressData.Length - 1
            strAddressData(p) = Nothing
        Next

        strAddressData = Split(txtProviderAddress.Text, vbCrLf)
        If strAddressData.Length >= 1 Then strProviderAddress1 = strAddressData(0)
        If strAddressData.Length >= 2 Then strProviderAddress2 = strAddressData(1)
        If strAddressData.Length >= 3 Then strProviderAddress3 = strAddressData(2)
        If strAddressData.Length >= 4 Then strProviderAddress4 = strAddressData(3)


        'Perform the till ring routine
        boolAbort = False

        dblSaleTotal = CDbl(lblPayable.Text)

        If dblSaleTotal <= 0 Then
            MsgBox("Sale cannot be processed when there are no valid sub total values", MsgBoxStyle.Critical, "Transaction Aborted")
            Exit Sub
        End If

        ' ''Dim f As New frmTenderAmount
        ' ''f.ShowDialog()
        If boolAbort = True Then Exit Sub

        Cursor = Cursors.WaitCursor
        If boolEditStatus = True Then

            'Reverse the items only if the prescription has not been paid for
            Dim objVerify As New Data.OleDb.OleDbCommand("SELECT Status from DispensingDetails WHERE PrescriptionNumber = " & intSelectedTransaction & "", cnn)
            Dim objReadVerification As Data.OleDb.OleDbDataReader = objVerify.ExecuteReader
            If objReadVerification.HasRows Then
                objReadVerification.Read()
                If Not IsDBNull(objReadVerification(0).ToString) Then
                    If UCase(objReadVerification(0).ToString) <> "PENDING" Then
                        MessageBox.Show("This prescription has been finalised and therefore cannot be edited", "Update Prevented", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        boolAbort = True
                        objReadVerification.Close()
                        Exit Sub
                    End If
                End If
            Else
                MessageBox.Show("System could not verify the status of prescription", "Verification Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                boolAbort = True
                objReadVerification.Close()
                Exit Sub
            End If

            Dim objDeleteInvoice As New Data.OleDb.OleDbCommand("DELETE FROM DispensingDetails WHERE PrescriptionNumber = " & intSelectedTransaction & "", cnn)
            objDeleteInvoice.ExecuteNonQuery()
            objDeleteInvoice = New Data.OleDb.OleDbCommand("DELETE FROM DispensingMain WHERE PrescriptionNumber = " & intSelectedTransaction & "", cnn)
            objDeleteInvoice.ExecuteNonQuery()

            txtReference.Text = intSelectedTransaction
        Else
            txtReference.Text = CStr(gwt_comm.GetNextDocumentNumber("Prescriptions"))
        End If
        If chkOverideDate.Checked = True Then
            dpProcessDate = Format(dpTransDate.Value, "dd-MMM-yyyy")
        End If

        For i = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then

                intQty = 0 : dblShortfall = 0 : dblTax = 0 : dblUprice = 0 : dblDisAmount = 0 : strDosage = Nothing : strDescription = Nothing
                Dim dblFees As Double = 0

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "")) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(7).Value.ToString) Then
                        strSelectedId = Convert.ToString(dGrid.Rows(i).Cells(7).Value)
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(0).Value) Then
                        strDescription = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(1).Value) Then
                        intQty = Convert.ToDouble(dGrid.Rows(i).Cells(1).Value)
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(2).Value.ToString) Then
                        If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                            Dim strPrice As String = dGrid.Rows(i).Cells(2).Value.ToString
                            dblUprice = Convert.ToDouble(dGrid.Rows(i).Cells(2).Value)
                        End If
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "")) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(3).Value) Then
                        If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                            dblFees = Convert.ToDouble(dGrid.Rows(i).Cells(3).Value)
                        End If
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(6).Value), "")) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(6).Value.ToString) Then
                        strDosage = dGrid.Rows(i).Cells(6).Value.ToString
                    End If
                End If

                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "")) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(5).Value.ToString) Then
                        If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                            dblShortfall = Convert.ToDouble(dGrid.Rows(i).Cells(5).Value)
                        End If
                    End If
                End If

                'Get the item cost price
                Dim dblItemCostPrice As Double = 0
                Dim objGetCostPrice As New Data.OleDb.OleDbCommand("SELECT OchmasSystemMedicines.CostPrice FROM OchmasSystemMedicines " _
                    & "WHERE OchmasSystemMedicines.ProductCode = '" & strSelectedId & "'", cnn)
                Dim objReadCostPrice As Data.OleDb.OleDbDataReader = objGetCostPrice.ExecuteReader
                If objReadCostPrice.HasRows Then
                    objReadCostPrice.Read()
                    If IsNumeric(objReadCostPrice(0).ToString) Then dblItemCostPrice = CDbl(objReadCostPrice(0).ToString)
                End If
                objReadCostPrice.Close()

                insertCustomer = "INSERT INTO DispensingDetails (PrescriptionNumber, DrugCode, CostPrice, SellingPrice, " _
                    & "Quantity, Discount, Taxes, Dosage, UserName, DrugName, ShortFall, DispensingFees, PatientReferenceNumber) VALUES (" & CDbl(txtReference.Text) & ", " _
                    & "'" & strSelectedId & "', " & dblItemCostPrice & ", " & dblUprice & ", " & intQty & ", " & dblDisAmount & ", " _
                    & "" & dblTax & ", '" & strDosage & "', '" & strUserName & "', '" & strDescription & "', " & dblShortfall & ", " & dblFees & ", " & lblPatientId.Text & ")"
                myCommand = New Data.OleDb.OleDbCommand(insertCustomer, cnn)
                myCommand.ExecuteNonQuery()

                dblSumTaxes = dblSumTaxes + dblTax
                dblSumDiscounts = dblSumDiscounts + dblDisAmount


                'Update the products table
                Dim intStockBalance As Double = 0
                myCommand = New Data.OleDb.OleDbCommand("SELECT Quantity FROM OchmasSystemDrugs WHERE MedpraxProductCode = '" & strSelectedId & "'", cnn)
                dbReader = myCommand.ExecuteReader
                If dbReader.HasRows Then
                    dbReader.Read()
                    If IsNumeric(dbReader(0).ToString) Then intStockBalance = CDbl(dbReader(0).ToString) Else intStockBalance = 0
                Else
                    intStockBalance = 0
                End If
                dbReader.Close()
                intStockBalance = intStockBalance - CDbl(dGrid.Rows(i).Cells(5).Value)
                myCommand = New Data.OleDb.OleDbCommand("UPDATE OchmasSystemDrugs SET Quantity = " & intStockBalance & " " _
                    & "WHERE MedpraxProductCode = '" & strSelectedId & "'", cnn)
                myCommand.ExecuteNonQuery()

            End If

        Next i

        dblSumPayable = CDbl(lblPayable.Text)

        'Add the record to the sales main

        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO DispensingMain (PrescriptionNumber, PatientNames, PatientAddress1, " _
            & "PatientAddress2, PatientAddress3, PatientAddress4, PatientContactNumber, PatientMedicalAidScheme, PatientMemberNumber, " _
            & "PatientSuffix, PatientDob, PractitionerName, PractitionerAddress1, PractitionerAddress2, PractitionerAddress3, " _
            & "PractitionerAddress4, PractitionerNumber, PrescriptionValue, TransactionDate, PatientMemberNames, DoctorVisitDate, PatientReferenceNumber) " _
            & "VALUES (" & CInt(txtReference.Text) & ", '" & cboPatientName.Text & "', '" & strPatientAddress1 & "', " _
            & "'" & strPatientAddress2 & "', '" & strPatientAddress3 & "', '', " _
            & "'', '" & cboMedicalAid.Text & "', '" & txtMedaidNumber.Text & "', '" & txtSuffix.Text & "', " _
            & "'" & Format(dpDob.Value, "dd-MMM-yyyy") & "', '" & txtProvider.Text & "', '" & strProviderAddress1 & "', " _
            & "'" & strProviderAddress2 & "','" & strProviderAddress3 & "', '" & strProviderAddress4 & "', " _
            & "'" & txtProviderNumber.Text & "', " & dblSumPayable & ", '" & Format(dpTransDate.Value, "dd-MMM-yyyy") & "', " _
            & "'" & txtMainMemberName.Text & "', '" & Format(dpVisitDate.Value, "dd-MMM-yyyy") & "', " & lblPatientId.Text & ")", cnn)
        myCommand.ExecuteNonQuery()

        'Update the control numbers table
        myCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET Prescriptions = " & CDbl(txtReference.Text) & "", cnn)
        myCommand.ExecuteNonQuery()

        strPublicCustomerId = cboPatientName.Text
        'MessageBox.Show("Prescription document generated successfully.", "Transaction Document Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Prescription Transaction Processing"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub cboPatientName_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboPatientName.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtPatientAddress.Focus()
            Exit Sub
        Else
            txtPatientAddress.Text = Nothing
            cboMedicalAid.Text = Nothing
            txtMainMemberName.Text = Nothing
            txtMedaidNumber.Text = Nothing
            txtSuffix.Text = "00"
        End If
    End Sub

    Private Sub cboPatientName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPatientName.SelectedIndexChanged
        lblPatientId.Text = Nothing

        If cboPatientName.Text = Nothing Then
            Exit Sub
        End If
        On Error GoTo RaiseErr
        lblPatientId.Text = Nothing
        lblPatientId.Text = cboPatientName.SelectedItem.Col2
        'Get the patient details from the patients table
        PatientDetails(lblPatientId.Text)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Prescription Patient Details Load"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub PatientDetails(PatientId As Integer)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM OchmasPatients WHERE ReferenceNumber = " & PatientId & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("Address").ToString) Then txtPatientAddress.Text = objReader("Address").ToString
            If Not IsDBNull(objReader("BirthDate").ToString) Then dpDob.Text = objReader("BirthDate").ToString
        End If
        objReader.Close()
        strSql = "SELECT * FROM OchmasMedaidMembership WHERE ReferenceNumber = " & PatientId & ""
        objCommand = New OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader("SchemeName").ToString) Then cboMedicalAid.Text = objReader("SchemeName").ToString
            If Not IsDBNull(objReader("SchemeNumber").ToString) Then lblMedaidNumber.Text = objReader("SchemeNumber").ToString
            If Not IsDBNull(objReader("MemberNumber").ToString) Then txtMedaidNumber.Text = objReader("MemberNumber").ToString
            If IsNumeric(objReader("Suffix").ToString) Then txtSuffix.Text = Format(CInt(objReader("Suffix").ToString), "00")
            If Not IsDBNull(objReader("MainMemberNames").ToString) Then txtMainMemberName.Text = objReader("MainMemberNames").ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Patient Details Load"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub cboMedicalAid_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMedicalAid.SelectedIndexChanged
        lblMedaidNumber.Text = Nothing
        If cboMedicalAid.Text = Nothing Then Exit Sub
        On Error Resume Next
        lblMedaidNumber.Text = cboMedicalAid.SelectedItem.Col2
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        boolEditStatus = False
        Dim frm As New frmPatientDetails
        frm.ShowDialog()
        LoadPatients()
    End Sub

    Private Sub btnPrintInstruction_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintInstruction.Click
        PrintDosage()
    End Sub

    Private Sub btnPrintScript_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintScript.Click
        PrintToFile()
        PrintScript()
    End Sub
End Class