
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing.Printing
Imports System.IO
Imports System.Text

Public Class frmPrintPrepacks

    Dim intActiveIndex As Integer
    Dim boolFormLoading As Boolean

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtCopies_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCopies.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnOK.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub PrintDosage()
        On Error GoTo RaiseErr
        Dim arrAllData As New ArrayList 'Holds the lines for all dosage instructions
        Dim strDrugName As String = Nothing
        Dim strPresentation As String = Nothing
        Dim strStrength As String = Nothing
        Dim strInstruction As String = Nothing

        Dim arrDosage As New ArrayList 'Hold the lines for the current dosage
        strInstruction = lblCipher.Text

        strDrugName = txtDrugName.Text
        strPresentation = lblPresentation.Text
        strStrength = lblStrength.Text

        'We are going to make sure that each line contains
        Dim intWordCnt As Integer = 0
        Dim strLine As String = Nothing
        arrDosage.Add(UCase(strDrugName) & " " & UCase(strPresentation) & " " & UCase(strStrength))
        arrDosage.Add(StrDup(48, "-"c))

        For n As Integer = 0 To strInstruction.Length - 1
            If intWordCnt < 48 Then
                strLine = strLine & strInstruction.Substring(n, 1)
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
        arrDosage.Add("PHARMACIST - " & UCase(strPublicActiveFullUserName))
        'Add the patient name
        arrDosage.Add(UCase("OTC DRUG") & " - " & UCase(Format(Now, "dd-MMM-yyyy")))
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
        For j As Integer = 0 To CInt(txtCopies.Text) - 1
            For y As Integer = 0 To arrDosage.Count - 1
                arrAllData.Add(arrDosage.Item(y))
            Next
            'Push the print 1 line down
            arrAllData.Add(Space(48))
        Next

        If arrAllData.Count > 0 Then
            Dim pd As New PrintDialog()
            pd.ShowDialog()
            pd.PrinterSettings = New PrinterSettings()
            strSessionPrinter = pd.PrinterSettings.PrinterName
            'Send to the raw printer
            For i As Integer = 0 To (CInt(txtCopies.Text) - 1)
                For n = 0 To arrAllData.Count - 1
                    Dim strPrintLineDetails As String = arrAllData.Item(n) & vbCrLf
                    RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, strPrintLineDetails)
                Next
            Next
            MsgBox("Printing completed successfully", MsgBoxStyle.Information, "Printing Success")
        Else
            MsgBox("No data to print", MsgBoxStyle.Exclamation, "Printing Error")
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error while printing medicines instructions"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        
        Dim arrData As New ArrayList

        'Add the instructions
        Dim intCol2Width As Integer = cboInstruction.Width - 90
        With cboInstruction
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "60;" & intCol2Width
        End With

        Dim strSql As String = "SELECT Code +'|'+ Instruction as [Data] FROM OchmasDispensingCiphers ORDER BY Code"

        arrData = New ArrayList

        Dim objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader = objCommand.ExecuteReader
        While objReader.Read
            arrData.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Dont proceed if there are no items selected

        If arrData.Count <= 0 Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim DropDownItemsCiphers(arrData.Count - 1) As MTGCComboBoxItem

        cboInstruction.Items.Clear()

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrData.Count - 1
            Dim strBuffer() As String = Split(arrData.Item(p), "|")
            DropDownItemsCiphers(p) = New MTGCComboBoxItem(strBuffer(0), strBuffer(1))
        Next

        'Load the banks to the combo box
        With cboInstruction
            If arrData.Count > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItemsCiphers)
            End If
        End With

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Medicines Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmPrintPrepacks_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        boolAbort = False
        boolEditStatus = False
        Dim f As New frmDispensingCipherSetup
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        LoadData()
    End Sub

    Private Sub cboInstruction_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboInstruction.SelectedIndexChanged
        lblCipher.Text = ""
        lblCipher.Text = cboInstruction.SelectedItem.Col2
    End Sub

    Private Sub btnOK_Click(sender As Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(lblPresentation.Text) Or String.IsNullOrEmpty(lblStrength.Text) Then
            MsgBox("Please check the drug selected for correctness", MsgBoxStyle.Exclamation, "Seemingly Invalid Drug")
            txtDrugName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblCipher.Text) Then
            MsgBox("Cannot proceed with printing as there are no instructions", MsgBoxStyle.Exclamation, "Missing Instructions")
            cboInstruction.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtCopies.Text) Then
            MsgBox("Please the number of labels to print", MsgBoxStyle.Exclamation, "Labels Quantity Not Specified")
            txtCopies.Focus()
            Exit Sub
        End If
        PrintDosage()
    End Sub

    Private Sub txtDrugName_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDrugName.KeyDown
        If e.KeyValue = Keys.Down Then
            If Not String.IsNullOrEmpty(txtDrugName.Text) Then
                dGridBrands.Focus()
                dGridBrands.SelectedRows(0).Selected = True
            Else
                SearchForItem("")
                dGridBrands.Focus()
                dGridBrands.SelectedRows(0).Selected = True
            End If
        Else
            SearchForItem(Chr(e.KeyCode))
        End If
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        If boolFormLoading = True Then Exit Sub
        On Error GoTo RaiseErr
        Dim strFind As String = txtDrugName.Text & strCurrentKey
        Cursor = Cursors.WaitCursor
        dGridBrands.Columns.Clear()

        Dim strSql As String = Nothing
        strSql = "SELECT ProductCode AS [Code], ProductName AS [Name], Strength as [Strength], CONVERT(NVARCHAR, " _
                    & "CAST(SellPrice AS DECIMAL (10,2))) AS [Unit Price], [StandardPackSize] AS [Package] from OchmasSystemMedicines " _
                    & "WHERE ProductName LIKE '%" & strFind & "%' ORDER BY ProductName"

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridBrands.DataSource = dTable

        Me.dGridBrands.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dGridBrands.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dGridBrands.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.dGridBrands.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        'dGridBrands.Focus()
        If dGridBrands.Rows.Count > 0 Then
            dGridBrands.FirstDisplayedScrollingRowIndex = 0
            dGridBrands.Rows(0).Selected = True
        End If

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Medicines Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub txtDrugName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDrugName.TextChanged
        SearchForItem("")
    End Sub

    Private Sub dGridBrands_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridBrands.DoubleClick
        If dGridBrands.Rows.Count > 0 Then
            txtDrugName.Text = dGridBrands.CurrentRow.Cells(1).Value.ToString
            lblCode.Text = dGridBrands.CurrentRow.Cells(0).Value.ToString
            lblStrength.Text = dGridBrands.CurrentRow.Cells(2).Value.ToString
            lblPresentation.Text = dGridBrands.CurrentRow.Cells(4).Value.ToString
            cboInstruction.Focus()
        End If
    End Sub

    Private Sub dGridBrands_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dGridBrands.KeyDown
        If e.KeyValue = Keys.Enter Then
            e.SuppressKeyPress = True
            If dGridBrands.Rows.Count > 0 Then
                txtDrugName.Text = dGridBrands.CurrentRow.Cells(1).Value.ToString
                lblCode.Text = dGridBrands.CurrentRow.Cells(0).Value.ToString
                lblStrength.Text = dGridBrands.CurrentRow.Cells(2).Value.ToString
                lblPresentation.Text = dGridBrands.CurrentRow.Cells(4).Value.ToString
                cboInstruction.Focus()
            End If
        End If
    End Sub

End Class
