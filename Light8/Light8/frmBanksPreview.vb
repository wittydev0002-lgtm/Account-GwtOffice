Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBanksPreview

    Private Sub frmBanksPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReloadBankDetails()
        cboSearchBy.SelectedIndex = 1
    End Sub

    Private Sub ReloadBankDetails()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT BankCode, BankName, Address1, Address2, Address3, Address4 FROM SystemBanks ORDER BY BankName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        dgrid.Rows.Clear()

        While objReader.Read
            dgrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(5).Value = objReader(5).ToString
        End While
        objReader.Close()
        AlternateColors()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Bank Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        boolEditStatus = False
        Dim f As New frmBanksMaintenance
        f.ShowDialog()
        ReloadBankDetails()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'Delete the batch if not yet processed
        On Error GoTo RaiseErr
        If dgrid.Rows.Count <= 0 Then Exit Sub
        lngPublicBankSortCode = 0
        If MessageBox.Show("Are you sure you want to delete this bank?", _
            "Bank Record Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            'proceed to delete the batch
            Dim CurrentCell As DataGridViewCell
            CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(0)
            lngPublicBankSortCode = CLng(CurrentCell.Value)
            Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemBanks WHERE BankCode = " & lngPublicBankSortCode & "", cnn)
            sqlCommand.ExecuteNonQuery()
            MessageBox.Show("Bank record deleted successfully", _
                "Record Deletion Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ReloadBankDetails()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Bank Deletion"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        'Call the selected batch with all its entries displayed
        lngPublicBankSortCode = 0
        If dgrid.Rows.Count <= 0 Then Exit Sub
        Dim CurrentCell As DataGridViewCell
        boolEditStatus = True
        CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(0)
        lngPublicBankSortCode = CLng(CurrentCell.Value)
        Dim f As New frmBanksMaintenance
        f.ShowDialog()
        ReloadBankDetails()
    End Sub

    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrid.DoubleClick
        lngPublicBankSortCode = 0
        If dgrid.Rows.Count <= 0 Then Exit Sub
        Dim CurrentCell As DataGridViewCell
        boolEditStatus = True
        CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(0)
        lngPublicBankSortCode = CLng(CurrentCell.Value)
        frmBanksMaintenance.ShowDialog()
        ReloadBankDetails()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        On Error GoTo RaiseErr
        boolAbort = False
        Dim f As New frmImportBanksFileName
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        'Insert the Zimbabwe banks listing
        Dim strSql As String = Nothing
        Dim myCommand As Data.OleDb.OleDbCommand
        Dim strLine As String = Nothing
        Dim strBuffer() As String
        If File.Exists(strSelectedFileName) Then
            Dim objStreamReader As New StreamReader(strSelectedFileName)
            strLine = objStreamReader.ReadToEnd
            objStreamReader.Close()
            strBuffer = Split(strLine, vbCrLf)
            With frmLight8.pb1
                .Value = 0
                .Maximum = strBuffer.Length
                .Visible = True
            End With
            'Gisable constraints
            strSql = "ALTER TABLE SystemBanks NOCHECK CONSTRAINT ALL"
            myCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            myCommand.ExecuteNonQuery()

            'dbo.EmployeeSplitPayments
            strSql = "ALTER TABLE EmployeeSplitPayments NOCHECK CONSTRAINT ALL"
            myCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            myCommand.ExecuteNonQuery()

            strSql = "DELETE FROM SystemBanks"
            myCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            myCommand.ExecuteNonQuery()

            For i = 0 To strBuffer.Length - 1

                If Not String.IsNullOrEmpty(strBuffer(i)) Then

                    Dim strItems() As String = Split(strBuffer(i), "|")

                    If gwt_comm.RecordExists("BankCode", "SystemBanks", Trim(strItems(2)), "STRING") = False Then

                        strSql = "INSERT INTO SystemBanks ([BankName], Address1, [BankCode]) VALUES " _
                            & "('" & Trim(strItems(0)) & "', '" & Trim(strItems(1)) & "', '" & Trim(strItems(2)) & "')"
                        myCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        myCommand.ExecuteNonQuery()
                        frmLight8.pb1.Value = frmLight8.pb1.Value + 1

                    Else
                        Dim objErrFile As New System.IO.StreamWriter(Application.StartupPath & "\Data\BnkErrs.txt", True)
                        objErrFile.WriteLine("RECORD EXISTS : " & UCase(strBuffer(i)))
                        objErrFile.Close()
                    End If

                End If

            Next i

            'Re-enable constraints
            strSql = "ALTER TABLE SystemBanks WITH CHECK CHECK CONSTRAINT ALL"
            myCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            myCommand.ExecuteNonQuery()

            strSql = "ALTER TABLE EmployeeSplitPayments WITH CHECK CHECK CONSTRAINT ALL"
            myCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            myCommand.ExecuteNonQuery()

        End If
        MessageBox.Show("Default payroll banks successfully loaded. Please check the error file at " & vbCrLf &
                        Application.StartupPath & "\Data\BnkErrs.txt for any errors encountered", _
            "Payroll Banks Import Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ReloadBankDetails()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Default on Zimbabwe banks load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        Dim intSearchColumn As Integer = 0
        Select Case UCase(cboSearchBy.SelectedItem.ToString)
            Case Is = UCase("Code")
                Dim y As DataGridViewColumn = dgrid.Columns(0)
                dgrid.Sort(y, System.ComponentModel.ListSortDirection.Ascending)
                intSearchColumn = 0
            Case Is = UCase("Name")
                Dim y As DataGridViewColumn = dgrid.Columns(1)
                dgrid.Sort(y, System.ComponentModel.ListSortDirection.Ascending)
                intSearchColumn = 1
            Case Else
                Dim y As DataGridViewColumn = dgrid.Columns(0)
                dgrid.Sort(y, System.ComponentModel.ListSortDirection.Ascending)
                intSearchColumn = 0
        End Select
        If (Char.IsLetter(e.KeyChar)) Then
            Dim strSearchString As String = txtSearchString.Text & e.KeyChar
            For i As Integer = 0 To dgrid.Rows.Count - 1
                If dgrid.Rows(i).Cells(intSearchColumn).Value.ToString().StartsWith(strSearchString, True, System.Globalization.CultureInfo.InvariantCulture) Then
                    dgrid.CurrentCell = dgrid(0, i)
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 0 To dgrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dgrid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                dgrid.Rows(i).Cells(j).Style.BackColor = backColor
                dgrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub btnChangeCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeCode.Click
        Dim CurrentCell As DataGridViewCell
        CurrentCell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(0)
        lngPublicBankSortCode = CLng(CurrentCell.Value)
        Dim f As New frmBankCodeChange
        f.ShowDialog()
        ReloadBankDetails()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr

        Dim arrPrintDetails As New ArrayList

        For i As Integer = 0 To dgrid.RowCount - 1
            Dim strData As String = Nothing
            For p As Integer = 0 To dgrid.Columns.Count - 1
                If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(p).Value), "")) Then
                    strData = strData & Convert.ToString(dgrid.Rows(i).Cells(p).Value) & ";"
                Else
                    strData = strData & " ;"
                End If
            Next
            strData = Mid(strData, 1, (strData.Length - 1))
            arrPrintDetails.Add(strData)
        Next

        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String

        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        Dim objPrint As New SmartColumnReportWriter.SmartColumnReportWriter

        With objPrint
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "CODE|NAME|ADDRESS|ADDRESS|ADDRESS|ADDRESS"
            .strColumnAlignments = "0|0|0|0|0|0"
            .strColumnWidths = "80|120|120|120|120|120"
            .strFooterCaption = "Bank Details Print"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "BANK LISTING"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|NO|NO"
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
            .boolGroupDetails = False
            .boolPrintTotals = False
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Cursor = Cursors.Default
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        objPrint.PrinterSettings.PrinterName = prnt.PrinterSettings.PrinterName
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = objPrint
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Bank Details Print Failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        ReloadBankDetails()
    End Sub

End Class