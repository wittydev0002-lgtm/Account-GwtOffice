Public Class frmBankExtracts

    Dim iNet As Integer = 0

    Dim boolIsExcluded As Boolean
    Dim arrExcludedBanks As ArrayList
    Dim objCommand As Data.OleDb.OleDbCommand
    Dim arrPrintRecords As ArrayList
    'Declare and set the default fonts
    Dim fntHeaderFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    Dim fntDetailsFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Dim fntFooterFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Dim sDetails As String = Nothing


    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        If String.IsNullOrEmpty(cboVersion.Text) Then
            MsgBox("Please select the file version", MsgBoxStyle.Exclamation, "File Version Not Specified")
            cboVersion.Focus()
            Exit Sub
        End If
        'evaluate that the mandatory details are present
        If txtAccNum.Text = "" Or Mid(txtAccNum.Text, 1, 1) = " " Then
            MsgBox("You must enter a valid bank account", vbInformation, "eManager 1.0 2014")
            txtAccNum.Focus()
            Exit Sub
        End If
        If txtSenderId.Text = "" Or Mid(txtSenderId.Text, 1, 1) = " " Then
            MsgBox("You must enter a valid sender id", vbInformation, "eManager 1.0 2014")
            txtSenderId.Focus()
            Exit Sub
        End If
        If txtBankCode.Text = "" Or Mid(txtBankCode.Text, 1, 1) = " " Then
            MsgBox("You must enter a valid bank code", vbInformation, "eManager 1.0 2014")
            txtBankCode.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDir.Text) Then
            MsgBox("Please enter a valid file name", MsgBoxStyle.Exclamation, "Invalid File Name")
            'btnBrowse.Focus()
            Exit Sub
        End If
        If cboTransType.Text = "" Or Mid(cboTransType.Text, 1, 1) = " " Then
            MsgBox("Please select the transaction type", vbInformation, "eManager 1.0 2014")
            cboTransType.Focus()
            Exit Sub
        End If
        ProgressBar1.Visible = True
        If cboVersion.Text = "Version 3" Then
            Version3File()
        Else
            'Version4File()
        End If
    End Sub

    Private Sub frmBankExtract_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sProcessDate.Value = Now
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        sfd.ShowDialog()
        txtDir.Text = sfd.FileName
    End Sub

    Private Sub Version3File()
        On Error GoTo RaiseErr

        'Dim rRec As ADODB.Recordset
        Dim rRec As Data.OleDb.OleDbDataReader

        Dim cBnkCode As String
        Dim cBnkAcc As String
        Dim sRecType As String
        'Dim strBankSortCodeFormated As String
        Dim strEmployeeName As String

        'initialize the array
        arrPrintRecords = New ArrayList
        'Begin the data validation
        'tafadzwa.vukomba@aon.co.zw
        'Get the company bankdetails
        cBnkCode = txtBankCode.Text

        Dim strFillZeros As String = "000000000000000"
        If IsNumeric(txtAccNum.Text) Then
            cBnkAcc = CStr(Format(CDbl(txtAccNum.Text), "000000000000000"))
        Else
            If txtAccNum.Text.Length > 15 Then txtAccNum.Text = Mid(txtAccNum.Text, 1, 15)
            cBnkAcc = CStr(Mid(strFillZeros, 1, (15 - txtAccNum.Text.Length)) & txtAccNum.Text)
        End If
        'End data validation

        If cboTransType.Text = "PAYMUL CREDITS" Then sRecType = "PAY"
        If cboTransType.Text = "PAYORD CREDITS" Then sRecType = "PAY"
        If cboTransType.Text = "DEBMUL DEBITS" Then sRecType = "DEB"

        Dim strSql As String = "SELECT RunFile.DirectorId, EmployeeMaster.LastName, " _
            & "EmployeeMaster.FirstName, EmployeeMaster.OtherNames, EmployeeMaster.BankCode, " _
            & "EmployeeMaster.BankAccountNumber FROM RunFile LEFT OUTER JOIN EmployeeMaster ON " _
            & "RunFile.DirectorId = EmployeeMaster.TransactionId " _
            & "GROUP BY RunFile.DirectorId, EmployeeMaster.LastName, EmployeeMaster.FirstName, " _
            & "EmployeeMaster.OtherNames, EmployeeMaster.BankAccountNumber, EmployeeMaster.BankCode"

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        rRec = objCommand.ExecuteReader

        Dim strSqlCount As String = "SELECT COUNT(RunFile.CodeId) FROM  RunFile WHERE CodeId = 998"
        Dim objCommandCount As New Data.OleDb.OleDbCommand(strSqlCount, cnn)
        Dim readCount As Data.OleDb.OleDbDataReader = objCommandCount.ExecuteReader
        Dim intCountRecs As Integer = 0

        While readCount.Read
            If IsNumeric(readCount(0).ToString) Then intCountRecs = CInt(readCount(0).ToString)
            Exit While
        End While
        readCount.Close()


        ProgressBar1.Value = 0 : ProgressBar1.Maximum = intCountRecs + 1

        sDetails = Nothing

        'initialize the values for amounts
        dblDebits = 0 : dblCredits = 0 : intDebits = 0 : intCredits = 0
        'print the header details

        sDetails = "UHL" & CStr(Format(sProcessDate.Value, "yyyyMMdd")) & txtSenderId.Text & _
            Space(9 - txtSenderId.Text.Length) & txtReceiverId.Text & Space(9 - txtReceiverId.Text.Length) & _
            "" & "000001" & cboTransType.Text & Space(15 - Len(cboTransType.Text)) & "003"
        PrintHeader(sDetails, txtDir.Text)

        'print the details
        While rRec.Read

            boolIsExcluded = False

            Dim strAmountPaid_1 As String = "0000000000000000" 'Net salary value
            Dim strBankSortCodeFormated_1 = "0000000"
            Dim strEmployeeBankAccount_1 As String = "000000000000000"

            Dim objCommandData1 As Data.OleDb.OleDbCommand

            'Get the Net pay amount and details
            '==================================

            objCommandData1 = New Data.OleDb.OleDbCommand("SELECT RunFile.Amount FROM RunFile " _
                & "WHERE (RunFile.DirectorId = " & rRec(0).ToString & ") AND (RunFile.CodeId = 999)", cnn)
            Dim objReadNetValue As Data.OleDb.OleDbDataReader = objCommandData1.ExecuteReader

            Dim dblPayAmount As Double = 0

            While objReadNetValue.Read
                If IsNumeric(objReadNetValue(0).ToString) Then
                    dblPayAmount = CDbl(objReadNetValue(0).ToString)
                End If
                If dblPayAmount > 0 Then
                    strAmountPaid_1 = CStr(Format(dblPayAmount * 100, "0000000000000000"))
                    strBankSortCodeFormated_1 = CStr(Format(CLng(Mid(rRec("BankCode").ToString, 1, 7)), "0000000"))
                    strEmployeeBankAccount_1 = rRec("BankAccountNumber").ToString
                End If
                Exit While
            End While
            objReadNetValue.Close()

            Dim strPrintName As String = Nothing
            Dim strPrintInits As String = Nothing

            Dim strEmpInitials As String = Nothing
            If Not IsDBNull(rRec("FirstName").ToString) Then strEmpInitials = Mid(rRec("FirstName").ToString, 1, 1)
            If Not IsDBNull(rRec("OtherNames").ToString) Then
                strEmpInitials = strEmpInitials & " " & Mid(rRec("OtherNames").ToString, 1, 1)
            End If

            strEmployeeName = rRec("LastName").ToString & Space(26 - Len(rRec("LastName").ToString)) & UCase(strEmpInitials)
            If strEmployeeName.Length > 30 Then strEmployeeName = Mid(strEmployeeName, 1, 30)
            strEmployeeName = UCase(strEmployeeName & Space(30 - Len(strEmployeeName)))

            If Not IsDBNull(rRec("LastName").ToString) Then strPrintName = rRec("LastName").ToString
            strPrintInits = strEmpInitials

            'Write the details after testing for the bank exclusion and split existence
            '==========================================================================

            If CDbl(strAmountPaid_1) > 0 Then
                Version3Writter(strBankSortCodeFormated_1, strEmployeeBankAccount_1, _
                    cBnkCode, cBnkAcc, strEmployeeName, strAmountPaid_1, 0, strPrintName, strPrintInits)
            End If

            ProgressBar1.Value = ProgressBar1.Value + 1

        End While
        rRec.Close()
        'End If


        '==========================================
        If ProgressBar1.Value > 0 Then
            'print the trailing record
            PrintTrailer("UTL" & CStr(Format((dblDebits * 100), "0000000000000000")) & CStr(Format((dblDebits * 100), "0000000000000000")) & CStr(Format(intDebits, "000000")) & CStr(Format(intCredits, "000000")), txtDir.Text)
            MsgBox(intDebits & " have been processed successfully. Do you want to save the current settings?", MsgBoxStyle.Information, "Bank Extract Processing")
            PrintBankReport()
        End If

        ClearControls()

        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Bank File Extract Error")
    End Sub

    Private Sub Version3Writter(ByVal strBankSortCodeFormated As String, _
            ByVal strEmployeeBankAccount As String, ByVal cBnkCode As String, ByVal cBnkAcc As String, _
            ByVal strEmployeeName As String, ByVal strAmountPaid As String, ByVal intPayPoint As Integer, ByVal strName As String, ByVal strInits As String)

        Dim strOriginatorName As String = Space(15)

        If Not String.IsNullOrEmpty(txtSenderName.Text) Then
            If txtSenderName.Text.Length > 15 Then
                strOriginatorName = Mid(txtSenderName.Text, 1, 15)
            Else
                strOriginatorName = txtSenderName.Text & Space(15 - txtSenderName.Text.Length)
            End If
        End If

        'print the details to file. First assign values
        sDetails = "PAY" & strBankSortCodeFormated & _
            strEmployeeBankAccount & "01" & "51" & _
            cBnkCode & cBnkAcc & "01" & strOriginatorName & _
            strEmployeeName & strAmountPaid & CStr(Format(sProcessDate.Value, "yyyyMMdd")) & "00" & Space(30)
        PrintDetails(sDetails, txtDir.Text)
        'accumulate the amount total and the records processed count
        dblDebits = dblDebits + (CDbl(strAmountPaid) / 100) 'rRec("Amt").ToString
        intDebits = intDebits + 1
        intCredits = intCredits + 1

        Dim strBankName As String = Nothing
        arrPrintRecords.Add(UCase(Trim(strName)) & " " & UCase(Trim(strInits)) & ";" & CLng(strBankSortCodeFormated) & ";" & strBankName & ";" & strEmployeeBankAccount & ";" & strAmountPaid)

    End Sub

    Private Sub cboVersion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVersion.SelectedIndexChanged
        cboTransType.Items.Clear()
        If cboVersion.Text = "Version 3" Then
            cboTransType.Items.Add("PAYMUL CREDITS")
            cboTransType.Items.Add("PAYORD CREDITS")
            cboTransType.Items.Add("DEBMUL DEBITS")
            txtReceiverName.Enabled = False
            txtSenderName.Enabled = True
            txtPackageName.Enabled = False
            txtCurrency.Enabled = False
            txtAccNum.MaxLength = 15
        Else
            cboTransType.Items.Add("SALARY DEPOSITS")
            cboTransType.Items.Add("PAYORD CREDITS")
            cboTransType.Items.Add("DEBMUL DEBITS")
            txtReceiverName.Enabled = True
            txtSenderName.Enabled = True
            txtPackageName.Enabled = True
            txtCurrency.Enabled = True
            txtAccNum.MaxLength = 20
        End If
    End Sub

    Private Sub ClearControls()
        txtDir.Clear()
        txtSenderId.Clear()
        txtReceiverName.Clear()
    End Sub

    Private Sub PrintBankReport()

        On Error GoTo RaiseErr

        'send the array to printing and viewing
        Dim y As Integer = arrPrintRecords.Count - 1
        Dim strPrintValues(0 To y + 2) As String
        Dim dblTransferTotal As Double = 0

        Dim P As Integer = 0
        For P = 0 To arrPrintRecords.Count - 1
            Dim strBuffer() As String = Split(arrPrintRecords.Item(P), ";")
            strPrintValues(P) = RTrim(strBuffer(0)) & ";" & CDbl(strBuffer(1)) & ";" & strBuffer(2) & ";" & CDbl(strBuffer(3)) & ";" & Format((CDbl(strBuffer(4)) / 100), "#,##0.00")
            dblTransferTotal = dblTransferTotal + CDbl(strBuffer(4)) / 100
        Next

        strPrintValues(y + 1) = " ; ; ; ; "
        strPrintValues(y + 2) = "TOTAL;;;;" & Format(CDbl(dblTransferTotal), "#,##0.00")

        Dim myReport As New SmartColumnReportWriter.SmartColumnReportWriter
        With myReport
            .intNumberOfColumns = 5
            .intPrintRecordsCount = strPrintValues.Length   'Or number of records in the text file
            .strColumnAlignments = "0|0|0|0|2"
            .strColumnFormating = "NO|NO|NO|NO|NO"
            .strColumnHeaders = " EMPLOYEE NAMES|BANK|BANK NAME|ACC.NO|AMOUNT" 'NO HEADERS
            .strColumnWidths = "160|50|240|100|78"
            .strColumnTotals = "NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .boolGroupDetails = False
            .boolPrintTotals = False
            .boolGenericReport = True
            .intKeyFieldIndex = 0
            .PrintSummary = False
            .DrawBorder = True
            .BorderColor = Color.FromName("LightGray")
            .DrawSummaryChart = False
            .VerticalLines = True
            .HorizontalLines = True
            .GridColor = Color.FromName("LightGray")
            .strPrintValues = strPrintValues
            .strMainCaption = "SALARIES BANK EXTRACT AS AT " & UCase(Now)
            .strFooterCaption = "TRANSFERS FROM ACCOUNT " & txtAccNum.Text
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            '.strHighlightColors = strHighlights
        End With
        Cursor = Cursors.Default
        ppDialog.Document = myReport
        ppDialog.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Report Generation Error")
    End Sub

End Class
