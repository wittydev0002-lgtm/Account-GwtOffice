Imports System.IO
Imports System.Text
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBenefitsStopOrders

    Dim arrStopOrders As ArrayList
    Dim dblTotal As Double = 0

    Private Sub txtSsbCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSsbCode.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then btnSaveCompany.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub cboProcessAs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProcessAs.SelectedIndexChanged
        Dim strType As String = "SSB"
        If UCase(cboProcessAs.Text) <> UCase("SSB STOP ORDERS") Then strType = "BANK"
        LoadTransactionsForProcessing(strType)
    End Sub

    Private Sub LoadTransactionsForProcessing(ByVal StopOrderType As String)
        On Error GoTo RaiseErr
        If File.Exists(Application.StartupPath & "\CUSTOMERS.dat") Then
            Dim objFileReader As New StreamReader(Application.StartupPath & "\CUSTOMERS.dat")
            Dim strLine As String = objFileReader.ReadToEnd
            objFileReader.Close()
            Dim strRecords() As String = Split(strLine, vbCrLf)
            dGrid.Rows.Clear()
            For i As Integer = 0 To strRecords.Length - 2
                Dim strFields() As String = Split(strRecords(i), "|")
                If strFields.Length <= 17 Then
                    strRecords(i) = strRecords(i) & "| "
                    strFields = Split(strRecords(i), "|")
                End If
                If UCase(strFields(12)) = UCase(StopOrderType) Then
                    With dGrid
                        .Rows.Add(1)
                        For p As Integer = 0 To strFields.Length - 1
                            'EmployeeNo(2), Names(1), Account#(0), Amount(11)
                            If p = 2 Then .Rows(.Rows.Count - 1).Cells(0).Value = strFields(p)
                            If p = 1 Then .Rows(.Rows.Count - 1).Cells(1).Value = strFields(p)
                            If p = 0 Then .Rows(.Rows.Count - 1).Cells(2).Value = strFields(p)
                            If p = 11 Then .Rows(.Rows.Count - 1).Cells(5).Value = strFields(p)
                            If p = 13 Then .Rows(.Rows.Count - 1).Cells(3).Value = strFields(p)
                            'If p = 14 Then .Rows(.Rows.Count - 1).Cells(4).Value = strFields(p)
                            If UCase(StopOrderType) = UCase("SSB") Then
                                If p = 15 Then .Rows(.Rows.Count - 1).Cells(6).Value = strFields(p)
                                If p = 16 Then .Rows(.Rows.Count - 1).Cells(7).Value = strFields(p)
                                If p = 17 Then .Rows(.Rows.Count - 1).Cells(8).Value = strFields(p)
                            End If
                        Next
                    End With
                End If
            Next
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Customer Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        On Error GoTo RaiseErr
        If dGrid.Rows.Count <= 0 Then
            MsgBox("There are no records to process to SSB", MsgBoxStyle.Exclamation, "No Records")
            Exit Sub
        Else

            If String.IsNullOrEmpty(cboProcessAs.Text) Then
                MsgBox("Please select the processing type", MsgBoxStyle.Exclamation, "Invalid Process Type")
                cboProcessAs.Focus()
                Exit Sub
            End If

            If UCase(cboProcessAs.Text) = "SSB STOPORDERS" Then
                If String.IsNullOrEmpty(txtSsbCode.Text) Then
                    MsgBox("Please enter the Payee code", MsgBoxStyle.Exclamation, "Missing Payee Code")
                    txtSsbCode.Focus()
                    TabControl1.SelectedIndex = 0
                    Exit Sub
                End If
                If Not IsNumeric(txtSsbCode.Text) Then
                    MsgBox("Please enter a valid Payee code", MsgBoxStyle.Exclamation, "Invalid Payee Code")
                    txtSsbCode.Focus()
                    TabControl1.SelectedIndex = 0
                    Exit Sub
                End If
                If String.IsNullOrEmpty(txtAdCode.Text) Then
                    MsgBox("Please enter the Payee code", MsgBoxStyle.Exclamation, "Missing Payee Code")
                    txtAdCode.Focus()
                    TabControl1.SelectedIndex = 0
                    Exit Sub
                End If
                If Not IsNumeric(txtAdCode.Text) Then
                    MsgBox("Please enter a valid Payee code", MsgBoxStyle.Exclamation, "Invalid Payee Code")
                    txtAdCode.Focus()
                    TabControl1.SelectedIndex = 0
                    Exit Sub
                End If

            Else
                'Check that the sender id, receiver id and company bank account number have been set

                If Not IsNumeric(txtSenderId.Text) Then
                    MsgBox("Please enter a valid Sender Id", MsgBoxStyle.Exclamation, "Invalid Sender ID")
                    txtSenderId.Focus()
                    TabControl1.SelectedIndex = 0
                    Exit Sub
                End If
                If String.IsNullOrEmpty(txtReceiverId.Text) Then
                    MsgBox("Please enter the receiver code", MsgBoxStyle.Exclamation, "Missing Receiver Id")
                    txtReceiverId.Focus()
                    TabControl1.SelectedIndex = 0
                    Exit Sub
                End If
                If Not IsNumeric(txtCompanyBankAccountNo.Text) Then
                    MsgBox("Please enter a valid company bank account number", MsgBoxStyle.Exclamation, "Missing Company Bank Number")
                    txtCompanyBankAccountNo.Focus()
                    TabControl1.SelectedIndex = 0
                    Exit Sub
                End If

            End If

            arrStopOrders = New ArrayList
            dblTotal = 0

            pb1.Visible = True : pb1.Maximum = dGrid.Rows.Count + 1 : pb1.Value = 0

            For i As Integer = 0 To dGrid.Rows.Count - 1
                'EmployeeNo(2), Names(1), Account#(0), Amount(11)

                If dGrid.Rows(i).Cells(dGrid.ColumnCount - 1).Value = True Then

                    Dim strEcNum As String = Nothing
                    Dim strNames As String = Nothing
                    Dim strAcc As String = Nothing
                    Dim dblAmt As Double = 0

                    Dim strBankCode As String = "0"
                    Dim strBankAccountNumber As String = "0"
                    Dim strEmpIdNumber As String = Nothing

                    Dim strEffectiveDate As String = Format(dpProcessDate.Value, "yyyyMMdd")

                    Dim strStartingDate As String = Format(dpProcessDate.Value, "yyyyMMdd")
                    Dim strEndingDate As String = Format(dpProcessDate.Value, "yyyyMMdd")

                    If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "") Then
                        strEcNum = dGrid.Rows(i).Cells(0).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                        strNames = dGrid.Rows(i).Cells(1).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "") Then
                        strAcc = dGrid.Rows(i).Cells(2).Value.ToString
                    End If

                    If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(3).Value), "") Then
                        strBankCode = dGrid.Rows(i).Cells(3).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "") Then
                        strBankAccountNumber = dGrid.Rows(i).Cells(4).Value.ToString
                    End If

                    If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(5).Value), "") Then
                        If IsNumeric(dGrid.Rows(i).Cells(5).Value.ToString) Then
                            dblAmt = CDbl(dGrid.Rows(i).Cells(5).Value.ToString)
                        End If
                    End If

                    'If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(4).Value), "") Then
                    '    strEffectiveDate = dGrid.Rows(i).Cells(4).Value.ToString
                    'End If

                    If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(6).Value), "") Then
                        strStartingDate = dGrid.Rows(i).Cells(6).Value.ToString
                    End If
                    If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(7).Value), "") Then
                        strEndingDate = dGrid.Rows(i).Cells(7).Value.ToString
                    End If

                    If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(8).Value), "") Then
                        strEmpIdNumber = dGrid.Rows(i).Cells(8).Value.ToString
                    End If

                    If strEcNum.Length > 8 Then strEcNum = Mid(strEcNum, 1, 8)
                    If strAcc.Length > 12 Then strAcc = Mid(strAcc, 1, 12)
                    dblTotal = dblTotal + dblAmt

                    Dim strAmount As String = Nothing
                    Dim strDataLine As String = Nothing

                    If strEmpIdNumber.Length > 15 Then strEmpIdNumber = Mid(strEmpIdNumber, 1, 15)
                    strEmpIdNumber = strEmpIdNumber & Space(15 - Len(strEmpIdNumber))

                    If UCase(cboProcessAs.Text) = "SSB STOP ORDERS" Then
                        strAmount = CStr(Format((dblAmt * 100), "0000000000000000"))
                        strDataLine = "DED" & strEcNum & Space(8 - strEcNum.Length) & "N" & txtAdCode.Text & _
                            txtSsbCode.Text & strAcc & Space(12 - strAcc.Length) & strStartingDate & strEndingDate & _
                            strEmpIdNumber & strAmount
                        'strStartDate & strEndDate & strIdNumber & strAmountPaid
                    Else
                        strAmount = CStr(Format((dblAmt * 100), "0000000000000000"))
                        strDataLine = "PAY" & CStr(Format(CDbl(strBankCode), "0000000")) & _
                            strBankAccountNumber & "01" & "51" & _
                            CStr(Format(CDbl(txtCompanyBankSortCode.Text), "0000000")) & txtCompanyBankAccountNo.Text & "01" & Space(15) & _
                            strNames & strAmount & strEffectiveDate & "00" & Space(30) & Space(30) & Space(30)
                    End If

                    arrStopOrders.Add(strDataLine)
                    pb1.Value = pb1.Value + 1

                End If
            Next
        End If
        pb1.Value = pb1.Maximum

        If arrStopOrders.Count > 0 Then
            If UCase(cboProcessAs.Text) = "SSB STOP ORDERS" Then
                boolAbort = False
                WriteToSSBFile()
            Else
                WriteToBankFile()
            End If
            If boolAbort = True Then
                Exit Sub
            Else
                MsgBox("The stop order file has been generated successfully", MsgBoxStyle.Information, "File Process Success")
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Stop Order File Processing"
        ShowErrorMessage()
    End Sub

    Private Sub WriteToBankFile()
        On Error GoTo RaiseErr
        'Open file for writing
        Dim sfd As New SaveFileDialog
        sfd.ShowDialog()
        Dim strFileName As String = sfd.FileName

        boolAbort = False
        If String.IsNullOrEmpty(strFileName) Then
            boolAbort = True
            MsgBox("No destination file path has been defined. Process will be aborted", MsgBoxStyle.Exclamation, "Missing Path")
            Exit Sub
        End If

        Dim objFileWriter As New StreamWriter(strFileName, False)
        pb1.Value = 0 : pb1.Maximum = arrStopOrders.Count + 1 : pb1.Visible = True

        If strCompanyName.Length > 30 Then strCompanyName = Mid(strCompanyName, 1, 30)

        'Write the header
        Dim strBatchControlNumber As String = "000001"
        Dim strTransactionType As String = "DEBMUL DEBITS"
        objFileWriter.WriteLine("UHL" & Format(dpProcessDate.Value, "yyyyMMdd") & txtSenderId.Text & _
            Space(9 - txtSenderId.Text.Length) & txtReceiverId.Text & Space(9 - txtReceiverId.Text.Length) & "" & _
            strBatchControlNumber & strTransactionType & Space(15 - Len(strTransactionType)) & "003")

        'Write the details
        For p As Integer = 0 To arrStopOrders.Count - 1
            objFileWriter.WriteLine(arrStopOrders.Item(p))
            pb1.Value = pb1.Value + 1
        Next
        pb1.Value = pb1.Maximum

        'Write the trailer
        Dim strValue As String = CStr(Format((dblTotal * 100), "0000000000000000"))
        Dim strCount As String = CStr(Format(CInt(arrStopOrders.Count), "000000"))

        objFileWriter.WriteLine("UTL" & strValue & strValue & strCount & strCount)

        'Close the file
        objFileWriter.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On SSB File Extract Failure"
        ShowErrorMessage()
    End Sub

    Private Sub WriteToSSBFile()
        On Error GoTo RaiseErr
        Dim sfd As New FolderBrowserDialog
        sfd.ShowDialog()
        Dim strPath As String = sfd.SelectedPath

        boolAbort = False
        If String.IsNullOrEmpty(strPath) Then
            boolAbort = True
            MsgBox("No destination file path has been defined. Process will be aborted", MsgBoxStyle.Exclamation, "Missing Path")
            Exit Sub
        End If
        Dim objFileWriter As New StreamWriter(strPath & "\ssb" & UCase(txtSsbCode.Text) & ".ins", False)

        'SSB PAYEECODE .INS
        'Trailer record
        '
        'TRL	X3
        'NO.OF REC 9(6) 4,6 RIGHT JUSTFIED.
        'VALUE 9(18) 10,18 RIGHT JUSTFIED
        '
        'HEADER RECORD
        '
        'HDR	X(3) 1,3
        'COMPANY NAME 	X(30) 4, 30 LEFT JUSTIFIED
        'YEAR		9999 34,4
        'MONTH	99 38,2
        'DAY 		99 40,2

        'Write the header first
        pb1.Value = 0 : pb1.Maximum = arrStopOrders.Count + 1 : pb1.Visible = True
        Dim strCompanyName As String = strCompanyName
        If strCompanyName.Length > 30 Then strCompanyName = Mid(strCompanyName, 1, 30)
        objFileWriter.WriteLine("HDR" & UCase(strCompanyName) & Space(30 - strCompanyName.Length) & Format(dpProcessDate.Value, "yyyyMMdd"))
        For p As Integer = 0 To arrStopOrders.Count - 1
            objFileWriter.WriteLine(arrStopOrders.Item(p))
            pb1.Value = pb1.Value + 1
        Next
        pb1.Value = pb1.Maximum
        'Write the trailer details
        Dim strValue As String = CStr(Format((dblTotal * 100), "000000000000000000"))
        Dim strCount As String = CStr(Format(CInt(arrStopOrders.Count), "000000"))
        objFileWriter.WriteLine("TRL" & Space(6 - strCount.Length) & strCount & strValue)
        objFileWriter.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On SSB File Extract Failure"
        ShowErrorMessage()
    End Sub

    Private Sub btnSaveCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveCompany.Click
        If String.IsNullOrEmpty(txtSsbCode.Text) Then
            MsgBox("Please enter the SSB Payee Code", MsgBoxStyle.Exclamation, "Invalid SSB Code")
            txtSsbCode.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAdCode.Text) Then
            MsgBox("Please enter the SSB Payee Code", MsgBoxStyle.Exclamation, "Invalid SSB Code")
            txtAdCode.Focus()
            Exit Sub
        End If

        On Error GoTo RaiseErr

        Dim objFileWriter As New StreamWriter(Application.StartupPath & "\Company.dat", False)
        objFileWriter.WriteLine(txtSsbCode.Text & "|" & txtAdCode.Text & "|" & txtCompanyBankSortCode.Text & "|" & _
            txtCompanyBankAccountNo.Text & "|" & txtSenderId.Text & "|" & txtReceiverId.Text)
        objFileWriter.Close()
        MsgBox("Company details saved successfully", MsgBoxStyle.Information, "Company Details Save")
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Company Details Update"
        ShowErrorMessage()
    End Sub

    Private Sub LoadCompanyDetails()
        On Error GoTo RaiseErr
        If File.Exists(Application.StartupPath & "\Company.dat") Then
            Dim objFileReader As New StreamReader(Application.StartupPath & "\Company.dat")
            Dim strLine As String = objFileReader.ReadLine
            objFileReader.Close()
            If Not String.IsNullOrEmpty(strLine) Then
                Dim strFileds() As String = Split(strLine, "|")
                txtSsbCode.Text = strFileds(8)
                txtAdCode.Text = strFileds(9)

                txtCompanyBankSortCode.Text = strFileds(10)
                txtCompanyBankAccountNo.Text = strFileds(11)
                txtSenderId.Text = strFileds(12)
                txtReceiverId.Text = strFileds(13)
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Company Details Load"
        ShowErrorMessage()
    End Sub

End Class
