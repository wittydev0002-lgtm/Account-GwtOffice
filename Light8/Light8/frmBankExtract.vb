Imports System.Data
Imports Microsoft.Office.Interop
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBankExtract

    Dim iNet As Integer = 0
    Dim intSplitNetCode1 As Integer = 0
    Dim intSplitNetCode2 As Integer = 0
    Dim intSplitNetCode3 As Integer = 0
    Dim intSplitNetCode4 As Integer = 0
    Dim intSplitNetCode5 As Integer = 0
    Dim strExemptBanks() As String
    Dim boolIsExcluded As Boolean
    Dim arrExcludedBanks As ArrayList
    Dim objCommand As Data.OleDb.OleDbCommand
    Dim arrPrintRecords As ArrayList
    'Declare and set the default fonts
    Dim fntHeaderFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    Dim fntDetailsFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Dim fntFooterFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Private lvwColumnSorter As ListViewColumnSorter
    Dim columnheader As ColumnHeader    ' Used for creating column headers.

    Dim strExcelValues() As String
    Dim sDetails As String = Nothing


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        If String.IsNullOrEmpty(cboVersion.Text) Then
            MsgBox("Please select the file version", MsgBoxStyle.Exclamation, "File Version Not Specified")
            TabControl1.SelectedIndex = 1
            cboVersion.Focus()
            Exit Sub
        End If
        'evaluate that the mandatory details are present
        If txtAccNum.Text = "" Or Mid(txtAccNum.Text, 1, 1) = " " Then
            MsgBox("You must enter a valid bank account", vbInformation, "Smart Extractor 1.0")
            txtAccNum.Focus()
            TabControl1.SelectedTab = Me.XtraTabPage1
            Exit Sub
        End If
        If txtSenderId.Text = "" Or Mid(txtSenderId.Text, 1, 1) = " " Then
            MsgBox("You must enter a valid sender id", vbInformation, "Smart Extractor 1.0")
            txtSenderId.Focus()
            TabControl1.SelectedTab = Me.XtraTabPage1
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboNetSalary.Text) Then
            MsgBox("The net pay code has not been defined. Please re-enter", MsgBoxStyle.Exclamation, "Invalid Net Salary Code")
            cboNetSalary.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDir.Text) Then
            MsgBox("Please enter a valid file name", MsgBoxStyle.Exclamation, "Invalid File Name")
            'btnBrowse.Focus()
            Exit Sub
        End If
        If cboBank.Text = "" Or Mid(cboBank.Text, 1, 1) = " " Then
            MsgBox("Please enter the company bank", vbInformation, "Smart Extractor 1.0")
            cboBank.Focus()
            TabControl1.SelectedTab = Me.XtraTabPage1
            Exit Sub
        End If
        If cboTransType.Text = "" Or Mid(cboTransType.Text, 1, 1) = " " Then
            MsgBox("Please select the transaction type", vbInformation, "Smart Extractor 1.0")
            cboTransType.Focus()
            TabControl1.SelectedTab = Me.XtraTabPage1
            Exit Sub
        End If
        ProgressBar1.Visible = True
        If cboVersion.Text = "Version 3" Then
            Version3File()
        Else
            Version4File()
        End If
    End Sub

    Private Sub LoadPayPoints()
        On Error GoTo RaiseErr
        Dim objComPayPoints As New Data.OleDb.OleDbCommand("SELECT DISTINCT PayPoint FROM Employment ORDER BY PayPoint", cnn)
        Dim objReader As data.oledb.oledbdatareader = objComPayPoints.ExecuteReader
        chkPayPoints.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then chkPayPoints.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Pay point details load failure")
    End Sub

    Private Sub frmBankExtract_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'check the mouse pointer
        ' Create an instance of a ListView column sorter and assign it 
        ' to the ListView control.
        lvwColumnSorter = New ListViewColumnSorter()
        Me.lstAvailableBanks.ListViewItemSorter = lvwColumnSorter
        sProcessDate.Value = Now
        'Me.Width = 572
        'Me.Height = 468
        InitialiazeDetails()
    End Sub

    Private Sub InitialiazeDetails()
        On Error GoTo raise_err

        Dim rBank As data.oledb.oledbdatareader
        Dim rCodes As data.oledb.oledbdatareader
        Dim rSplitCodes As data.oledb.oledbdatareader
        objCommand = New data.oledb.oledbCommand("SELECT CodeNo, Description " _
            & "From SystemCodes ORDER BY CodeNo", cnn)
        rCodes = objCommand.ExecuteReader
        objCommand = New data.oledb.oledbCommand("SELECT BankCode, BankName " _
            & "From SystemBanks ORDER BY BankName", cnn)
        rBank = objCommand.ExecuteReader

        objCommand = New data.oledb.oledbCommand("SELECT SplitCodeParameters.CodeNo, SystemCodes.Description " _
            & "From SplitCodeParameters LEFT OUTER JOIN SystemCodes ON SplitCodeParameters.CodeNo = SystemCodes.CodeNo " _
            & "ORDER BY CodeNo", cnn)
        rSplitCodes = objCommand.ExecuteReader

        lstAvailableBanks.Clear()
        With lstAvailableBanks
            .Columns.Add("Sort Code", 110, HorizontalAlignment.Left)
            .Columns.Add("Branch Name", (lstAvailableBanks.Width - 115), HorizontalAlignment.Left)
        End With

        ' Loop through and size each column header to fit the column header text.
        For Each columnheader In Me.lstAvailableBanks.Columns
            columnheader.Width = -2
        Next

        Dim arrPayrollCodes As New ArrayList
        Dim arrSplitCodes As New ArrayList

        'Initialize the array
        arrPayrollCodes.Add(UCase("000;No Code"))

        With cboNetSalary
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;300"
        End With
        With cboSplitPayCode1
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;300"
        End With
        With cboSplitPayCode2
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;300"
        End With
        With cboSplitPayCode3
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;300"
        End With
        With cboSplitPayCode4
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;300"
        End With
        With cboSplitPayCode5
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;300"
        End With

        While rCodes.Read
            If Not IsDBNull(rCodes("Description").ToString) Or _
                rCodes("Description").ToString <> "" Then
                arrPayrollCodes.Add(UCase(Format(CInt(rCodes("CodeNo").ToString), "000") & ";" & rCodes("Description").ToString))
            End If
        End While
        rCodes.Close()

        While rSplitCodes.Read
            If Not IsDBNull(rSplitCodes("Description").ToString) Or _
                rSplitCodes("Description").ToString <> "" Then
                arrSplitCodes.Add(UCase(Format(CInt(rSplitCodes("CodeNo").ToString), "000") & ";" & rSplitCodes("Description").ToString))
            End If
        End While
        rSplitCodes.Close()

        'Get a count of the items
        Dim intItemsCount As Integer = arrPayrollCodes.Count
        Dim intSplitItemsCount As Integer = arrSplitCodes.Count

        If intItemsCount <= 0 Then
            MsgBox("No payroll codes were found for this payroll. Process will be aborted", MsgBoxStyle.Exclamation, "No Payroll Codes")
            Exit Sub
        End If

        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem
        Dim DropDownItems1(intSplitItemsCount - 1) As MTGCComboBoxItem
        Dim DropDownItems2(intSplitItemsCount - 1) As MTGCComboBoxItem
        Dim DropDownItems3(intSplitItemsCount - 1) As MTGCComboBoxItem
        Dim DropDownItems4(intSplitItemsCount - 1) As MTGCComboBoxItem
        Dim DropDownItems5(intSplitItemsCount - 1) As MTGCComboBoxItem

        For p As Integer = 0 To arrPayrollCodes.Count - 1
            Dim strRecordText() As String = Split(arrPayrollCodes.Item(p).ToString, ";")
            DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
        Next

        For p As Integer = 0 To arrSplitCodes.Count - 1
            Dim strRecordText() As String = Split(arrSplitCodes.Item(p).ToString, ";")
            DropDownItems1(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            DropDownItems2(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            DropDownItems3(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            DropDownItems4(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            DropDownItems5(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
        Next

        With cboNetSalary
            .SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            .Items.AddRange(DropDownItems)
        End With
        With cboSplitPayCode1
            .SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            .Items.AddRange(DropDownItems1)
        End With
        With cboSplitPayCode2
            .SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            .Items.AddRange(DropDownItems2)
        End With
        With cboSplitPayCode3
            .SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            .Items.AddRange(DropDownItems3)
        End With
        With cboSplitPayCode4
            .SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            .Items.AddRange(DropDownItems4)
        End With
        With cboSplitPayCode5
            .SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            .Items.AddRange(DropDownItems5)
        End With

        If arrSplitCodes.Count <= 0 Then
            cboSplitPayCode1.Enabled = False
            cboSplitPayCode2.Enabled = False
            cboSplitPayCode3.Enabled = False
            cboSplitPayCode4.Enabled = False
            cboSplitPayCode5.Enabled = False
        End If

        Dim isp As Integer = 0
        cboBank.Items.Clear()
        cboBank.Items.Add("Add, ....")
        While rBank.Read
            Dim strBC As String = "0"
            If Not IsDBNull(rBank("BankCode").ToString) Then
                strBC = rBank("BankCode").ToString
            End If
            If Not IsNumeric(strBC) Then strBC = "0000000"
            If Not IsDBNull(rBank("BankCode").ToString) Then cboBank.Items.Add(Format(CLng(Mid(strBC, 1, 7)), "0000000") & ", " & rBank("BankName").ToString)
            Dim LItem As New ListViewItem
            If Not IsDBNull(rBank("BankCode").ToString) And Not IsDBNull(rBank("BankName").ToString) Then
                LItem.Text = CStr(Format(CLng(Mid(strBC, 1, 7)), "0000000"))
                LItem.SubItems.Add(rBank("BankName").ToString)
                lstAvailableBanks.Items.Add(LItem)
                isp = isp + 1
            End If
        End While
        rBank.Close()
        'Load the saved banks
        LoadSavedBanks()
        LoadPayPoints()
        Exit Sub
raise_err:
        If Err.Number = -2147217865 Then
            MsgBox("Bank Table could not be located !!!" & vbCrLf & _
                "Make sure that you are in the correct database", vbCritical, "Confide Pay")
            Me.Close()
        Else
            MsgBox(Err.Description, vbCritical, "Confide Pay")
            Me.Close()
        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        sfd.ShowDialog()
        txtDir.Text = sfd.FileName
    End Sub

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn.Click
        Dim i As Integer = TabControl1.SelectedIndex
        TabControl1.SelectedIndex = i - 1
    End Sub

    Private Sub btnNext1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext1.Click
        Dim i As Integer = TabControl1.SelectedIndex
        TabControl1.SelectedIndex = i + 1
    End Sub

    Private Sub btnBack1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack1.Click
        Dim i As Integer = TabControl1.SelectedIndex
        TabControl1.SelectedIndex = i - 1
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim i As Integer = TabControl1.SelectedIndex
        TabControl1.SelectedIndex = i + 1
    End Sub

    Private Sub Version3File()
        On Error GoTo RaiseErr

        'Dim rRec As ADODB.Recordset
        Dim rRec As data.oledb.oledbdatareader

        Dim cBnkCode As String
        Dim cBnkAcc As String
        Dim sRecType As String
        'Dim strBankSortCodeFormated As String
        Dim strEmployeeName As String

        'initialize the array
        arrPrintRecords = New ArrayList
        'Begin the data validation
        'tafadzwa.vukomba@aon.co.zw
        Dim strCoyBankCode() As String = Split(cboBank.Text, ",")
        'Get the company bankdetails
        If strCoyBankCode.Length < 2 Then
            MsgBox("Please enter the company bank", vbInformation, "Confide Pay")
            cboBank.Focus()
            Exit Sub
        Else
            cBnkCode = strCoyBankCode(0)
        End If
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

        Dim strBuffer() As String
        If Not String.IsNullOrEmpty(cboNetSalary.Text) Then
            iNet = CInt(cboNetSalary.Text)
        End If
        If Not String.IsNullOrEmpty(cboSplitPayCode1.Text) Then
            intSplitNetCode1 = CInt(cboSplitPayCode1.Text)
        End If

        If Not String.IsNullOrEmpty(cboSplitPayCode2.Text) Then
            intSplitNetCode2 = CInt(cboSplitPayCode2.Text)
        End If

        If Not String.IsNullOrEmpty(cboSplitPayCode3.Text) Then
            intSplitNetCode3 = CInt(cboSplitPayCode3.Text)
        End If

        If Not String.IsNullOrEmpty(cboSplitPayCode4.Text) Then
            intSplitNetCode4 = CInt(cboSplitPayCode4.Text)
        End If

        If Not String.IsNullOrEmpty(cboSplitPayCode5.Text) Then
            intSplitNetCode5 = CInt(cboSplitPayCode5.Text)
        End If

        Dim strSql As String = "SELECT EmployeeRunFile.EmployeeNo, EmployeeMaster.LastName, " _
            & "EmployeeMaster.FirstName, EmployeeMaster.OtherNames, " _
            & "EmployeeMaster.PayPoint FROM EmployeeRunFile LEFT OUTER JOIN EmployeeMaster ON " _
            & "EmployeeRunFile.EmployeeNo = EmployeeMaster.EmployeeNo"

        objCommand = New data.oledb.oledbCommand(strSql, cnn)
        rRec = objCommand.ExecuteReader

        Dim strSqlCount As String = "SELECT COUNT(EmployeeRunFile.EmployeeNo) FROM  EmployeeRunFile"
        Dim objCommandCount As New data.oledb.oledbCommand(strSqlCount, cnn)
        Dim readCount As data.oledb.oledbdatareader = objCommandCount.ExecuteReader
        Dim intCountRecs As Integer = 0

        While readCount.Read
            If IsNumeric(readCount(0).ToString) Then intCountRecs = CInt(readCount(0).ToString)
            Exit While
        End While
        readCount.Close()


        ProgressBar1.Value = 0 : ProgressBar1.Maximum = intCountRecs + 1

        'check for any excluded banks that may have been selected
        Dim LItem As ListViewItem
        Dim LItems As ListView.CheckedListViewItemCollection
        LItems = lstAvailableBanks.CheckedItems
        ReDim strExemptBanks(0 To (lstAvailableBanks.CheckedItems.Count - 1))
        Dim i As Integer
        i = 0
        For Each LItem In LItems
            strExemptBanks(i) = CInt(LItem.SubItems(0).Text)
            i = i + 1
        Next


        sDetails = Nothing

        'If rRec.RecordCount > 0 Then
        'If rRec.HasRows Then
        'initialize the values for amounts
        dblDebits = 0 : dblCredits = 0 : intDebits = 0 : intCredits = 0
        'print the header details

        sDetails = "UHL" & CStr(Format(sProcessDate.Value, "yyyyMMdd")) & txtSenderId.Text & Space(9 - txtSenderId.Text.Length) & txtReceiverId.Text & Space(9 - txtReceiverId.Text.Length) & "" & "000001" & cboTransType.Text & Space(15 - Len(cboTransType.Text)) & "003"
        PrintHeader(sDetails, txtDir.Text)

        'print the details
        While rRec.Read
            boolIsExcluded = False


            '*** GET THE BANKING DATA FROM THE NET AND THE SPLIT CODES

            Dim strAmountPaid_1 As String = "0000000000000000" 'Net salary value
            Dim strAmountPaid_2 As String = "0000000000000000" 'Split code 1 value
            Dim strAmountPaid_3 As String = "0000000000000000" 'Split code 2 value

            Dim strAmountPaid_4 As String = "0000000000000000" 'Split code 3 value
            Dim strAmountPaid_5 As String = "0000000000000000" 'Split code 4 value
            Dim strAmountPaid_6 As String = "0000000000000000" 'Split code 5 value

            Dim strBankSortCodeFormated_1 = "0000000"
            Dim strEmployeeBankAccount_1 As String = "000000000000000"

            Dim strBankSortCodeFormated_2 = "0000000"
            Dim strEmployeeBankAccount_2 As String = "000000000000000"

            Dim strBankSortCodeFormated_3 = "0000000"
            Dim strEmployeeBankAccount_3 As String = "000000000000000"

            Dim strBankSortCodeFormated_4 = "0000000"
            Dim strEmployeeBankAccount_4 As String = "000000000000000"

            Dim strBankSortCodeFormated_5 = "0000000"
            Dim strEmployeeBankAccount_5 As String = "000000000000000"

            Dim strBankSortCodeFormated_6 = "0000000"
            Dim strEmployeeBankAccount_6 As String = "000000000000000"


            Dim objCommandData1 As data.oledb.oledbCommand
            Dim objCommandData2 As data.oledb.oledbCommand
            Dim objCommandData3 As data.oledb.oledbCommand

            Dim objCommandData4 As data.oledb.oledbCommand
            Dim objCommandData5 As data.oledb.oledbCommand
            Dim objCommandData6 As data.oledb.oledbCommand

            'Get the Net pay amount and details
            '==================================

            objCommandData1 = New data.oledb.oledbCommand("SELECT EmployeeBanks.BankCode, " _
                & "EmployeeBanks.AccountNumber, EmployeeRunFile.RunAmounts FROM EmployeeBanks " _
                & "INNER JOIN EmployeeRunFile ON EmployeeBanks.EmployeeNo = EmployeeRunFile.EmployeeNo " _
                & "WHERE (EmployeeBanks.PayMethod = 'Bank') AND (EmployeeBanks.EmployeeNo = '" & rRec("EmployeeNo").ToString & "')", cnn)
            Dim objReadNetValue As data.oledb.oledbdatareader = objCommandData1.ExecuteReader

            Dim dblPayAmount As Double = 0

            While objReadNetValue.Read
                Dim strNetValues() As String = Split(objReadNetValue("RunAmounts").ToString, "|")
                If IsNumeric(strNetValues(iNet)) Then
                    dblPayAmount = CDbl(strNetValues(iNet))
                End If

                If dblPayAmount > 0 Then
                    strAmountPaid_1 = CStr(Format(dblPayAmount * 100, "0000000000000000"))
                    strBankSortCodeFormated_1 = CStr(Format(CLng(Mid(objReadNetValue("BankCode").ToString, 1, 7)), "0000000"))
                    strEmployeeBankAccount_1 = objReadNetValue("AccountNumber").ToString
                End If

                Exit While
            End While
            objReadNetValue.Close()

            'Create and assign to an array the split codes
            Dim arrSplitPaymentCodes As New ArrayList
            Dim objCommandSplits = New data.oledb.oledbCommand("SELECT DISTINCT(CodeNo) FROM SplitCodeParameters", cnn)
            Dim objReadSplits As Data.OleDb.OleDbDataReader = objCommandSplits.ExecuteReader

            While objReadSplits.Read
                arrSplitPaymentCodes.Add(objReadSplits(0).ToString)
            End While
            objReadSplits.Close()

            'Shortened Code
            Dim intCounting As Integer = 0
            Dim arrSplitAmounts As New ArrayList
            Dim arrSplitBankCodes As New ArrayList
            Dim arrSpliBankAccounts As New ArrayList

            For z = 0 To arrSplitPaymentCodes.Count - 1
                Dim objCommandGetSplits As New data.oledb.oledbCommand("SELECT EmployeeSplitPayments.BankCode, " _
                    & "EmployeeSplitPayments.AccountNumber, EmployeeRunFile.RunAmounts FROM EmployeeRunFile " _
                    & "INNER JOIN EmployeeSplitPayments ON EmployeeRunFile.EmployeeNo = EmployeeSplitPayments.EmployeeNo " _
                    & "WHERE EmployeeRunFile.EmployeeNo = '" & rRec("EmployeeNo").ToString & "' AND " _
                    & "EmployeeSplitPayments.CodeNo = " & arrSplitPaymentCodes.Item(z) & "", cnn)
                Dim objReadEmployeeSplits As data.oledb.oledbdatareader = objCommandGetSplits.ExecuteReader

                While objReadEmployeeSplits.Read
                    Dim strNetValues() As String = Split(objReadEmployeeSplits("RunAmounts").ToString, "|")
                    If IsNumeric(strNetValues(iNet)) Then
                        dblPayAmount = CDbl(strNetValues(CInt(arrSplitPaymentCodes.Item(z))))
                    End If
                    If dblPayAmount > 0 Then
                        arrSplitAmounts.Add(CStr(Format(dblPayAmount * 100, "0000000000000000")))
                        arrSplitBankCodes.Add(CStr(Format(CLng(Mid(objReadEmployeeSplits("BankCode").ToString, 1, 7)), "0000000")))
                        Dim strRawBankAccount As String = objReadEmployeeSplits("AccountNumber").ToString
                        If strRawBankAccount.Length > 15 Then strRawBankAccount = Mid(strRawBankAccount, 1, 15)
                        strRawBankAccount = Mid(strFillZeros, 1, (15 - strRawBankAccount.Length)) & strRawBankAccount
                        arrSpliBankAccounts.Add(strRawBankAccount)
                    End If

                    Exit While
                End While
                objReadEmployeeSplits.Close()
            Next

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

            For intSplits As Integer = 0 To arrSplitAmounts.Count - 1
                If IsNumeric(arrSplitAmounts.Item(intSplits)) Then
                    If CDbl(arrSplitAmounts.Item(intSplits)) > 0 Then
                        If ExcludeBank(arrSplitBankCodes(intSplits)) = False Then
                            Version3Writter(arrSplitBankCodes(intSplits), arrSpliBankAccounts(intSplits), _
                            cBnkCode, cBnkAcc, strEmployeeName, arrSplitAmounts.Item(intSplits), CInt(rRec("PayPoint").ToString), strPrintName, strPrintInits)
                        End If
                    End If
                End If
            Next
            If CDbl(strAmountPaid_1) > 0 Then
                If ExcludeBank(strBankSortCodeFormated_1) = False Then
                    Version3Writter(strBankSortCodeFormated_1, strEmployeeBankAccount_1, _
                    cBnkCode, cBnkAcc, strEmployeeName, strAmountPaid_1, CInt(rRec("PayPoint").ToString), strPrintName, strPrintInits)
                End If
            End If


            ProgressBar1.Value = ProgressBar1.Value + 1
        End While
        rRec.Close()
        'End If


        '==========================================
        If ProgressBar1.Value > 0 Then
            'print the trailing record
            PrintTrailer("UTL" & CStr(Format((dblDebits * 100), "0000000000000000")) & CStr(Format((dblDebits * 100), "0000000000000000")) & CStr(Format(intDebits, "000000")) & CStr(Format(intCredits, "000000")), txtDir.Text)
            'Save settings if required
            If boolFromSavedExtracts = False Then
                If MsgBox(intDebits & " have been processed successfully. Do you want to save the current settings?", MsgBoxStyle.YesNo, "Bank Extract Processing") = MsgBoxResult.Yes Then
                    boolAbort = False
                    Dim f As New frmExtractName
                    f.ShowDialog()
                    If boolAbort = True Then Exit Sub
                    SaveSettings()
                End If
            Else
                MsgBox(intDebits & " have been processed successfully. Do you want to save the current settings?", MsgBoxStyle.Information, "Bank Extract Processing")
            End If
            PrintBankReport()
            If chkOutputExcel.Checked = True Then
                ExportToExcelFromDataGrid()
                'OutputExcelFile()
            End If
        End If

        ClearControls()
        TabControl1.SelectedIndex = 0
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Bank File Extract Error")
    End Sub

    Private Sub OutputExcelFile()
        '        On Error GoTo RaiseErr
        '        Dim strNewFileName As String = Nothing
        '        With SaveFileDialog1
        '            .Title = "Save As"
        '            .FileName = ""
        '            .Filter = "Excel Files|*.xls"
        '            .DefaultExt = "xls"
        '        End With
        '        SaveFileDialog1.ShowDialog()
        '        strNewFileName = SaveFileDialog1.FileName
        '        If String.IsNullOrEmpty(strNewFileName) Then Exit Sub

        '        Dim ExcelApp As New Excel.Application ' Microsoft.Office.Interop.Excel.ApplicationClass()
        '        ExcelApp.Application.Workbooks.Add(Type.Missing)
        '        ExcelApp.Columns.ColumnWidth = 8
        '        'Add the column names first
        '        'For z As Integer = 0 To c.columns.count - 1
        '        '    Dim strCaption As String = c.Columns(z).HeaderText.ToString
        '        '    If Not String.IsNullOrEmpty(strCaption) Then
        '        '        ExcelApp.Cells(1, z + 1) = strCaption
        '        '    End If
        '        'Next
        '        For i As Integer = 0 To strExcelValues.Length - 1
        '            'Dim row As DataGridViewRow = c.Rows(i)
        '            Dim strSplitValues() As String = Split(strExcelValues(i), ";")
        '            For j As Integer = 0 To strSplitValues.Length - 1
        '                Dim strValue As String = strSplitValues(j)
        '                ExcelApp.Cells(i + 2, j + 1) = strValue
        '            Next
        '        Next
        '        ExcelApp.ActiveWorkbook.SaveCopyAs(strNewFileName)
        '        ExcelApp.ActiveWorkbook.Saved = True
        '        ExcelApp.Quit()
        '        MsgBox("Details have been successfully exported to Excel", MsgBoxStyle.Information, "Excel File Export Success")
        '        Exit Sub
        'RaiseErr:
        '        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Excel File Export Failure")
    End Sub

    Private Sub ExportToExcelFromDataGrid()
        'add the data to the grid
        DataGridView1.Rows.Clear()
        For i As Integer = 0 To strExcelValues.Length - 1
            'Dim row As DataGridViewRow = c.Rows(i)
            Dim strSplitValues() As String = Split(strExcelValues(i), ";")
            For j As Integer = 0 To strSplitValues.Length - 1
                Dim strValue As String = strSplitValues(j)
                DataGridView1.Rows(i).Cells(j + 1).Value = strValue
            Next
        Next
        'verfying the datagridview having data or not
        If ((DataGridView1.Columns.Count = 0) Or (DataGridView1.Rows.Count = 0)) Then
            Exit Sub
        End If

        'Creating dataset to export
        Dim dset As New DataSet
        'add table to dataset
        dset.Tables.Add()
        'add column to that table
        For i As Integer = 0 To DataGridView1.ColumnCount - 1
            dset.Tables(0).Columns.Add(DataGridView1.Columns(i).HeaderText)
        Next
        'add rows to the table
        Dim dr1 As DataRow
        For i As Integer = 0 To DataGridView1.RowCount - 1
            dr1 = dset.Tables(0).NewRow
            For j As Integer = 0 To DataGridView1.Columns.Count - 1
                dr1(j) = DataGridView1.Rows(i).Cells(j).Value
            Next
            dset.Tables(0).Rows.Add(dr1)
        Next

        Dim excel As New Excel.Application ' Microsoft.Office.Interop.Excel.ApplicationClass
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

        wBook = excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dt As System.Data.DataTable = dset.Tables(0)
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        For Each dc In dt.Columns
            colIndex = colIndex + 1
            excel.Cells(1, colIndex) = dc.ColumnName
        Next

        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)

            Next
        Next

        wSheet.Columns.AutoFit()
        Dim strFileName As String = "D:\ss.xls"
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If

        wBook.SaveAs(strFileName)
        excel.Workbooks.Open(strFileName)
        excel.Visible = True

    End Sub

    Private Function ExcludeBank(ByVal strBankCode As String) As Boolean
        'check that the bank is not part of the excluded
        boolIsExcluded = False
        For i As Integer = 0 To lstAvailableBanks.CheckedItems.Count - 1
            If CLng(strBankCode) = strExemptBanks(i) Then
                boolIsExcluded = True
                Exit For
            End If
        Next
        Return boolIsExcluded
    End Function


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

        If boolIsExcluded = False Then
            'Check that the employee selected is within the desired pay points
            If optAll.Checked Then
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
                Dim myCom As New data.oledb.oledbCommand("SELECT BankName FROM SystemBanks WHERE BankCode like '%" & CLng(Mid(strBankSortCodeFormated, 2, (strBankSortCodeFormated.Length - 1))) & "'", cnn)
                Dim objReadBankName As data.oledb.oledbdatareader = myCom.ExecuteReader
                Dim strBankName As String = Nothing
                While objReadBankName.Read()
                    If Not IsDBNull(objReadBankName(0).ToString) Then strBankName = objReadBankName(0).ToString Else strBankName = ""
                    Exit While
                End While
                objReadBankName.Close()
                arrPrintRecords.Add(UCase(Trim(strName)) & " " & UCase(Trim(strInits)) & ";" & CLng(strBankSortCodeFormated) & ";" & strBankName & ";" & strEmployeeBankAccount & ";" & strAmountPaid)
            Else
                If PayPointSelected(intPayPoint) = True Then
                    'print the details to file. First assign values
                    sDetails = "PAY" & strBankSortCodeFormated & _
                        strEmployeeBankAccount & "01" & "51" & _
                        cBnkCode & cBnkAcc & "01" & Space(15) & _
                        strEmployeeName & strAmountPaid & CStr(Format(sProcessDate.Value, "yyyyMMdd")) & "00" & Space(30)
                    PrintDetails(sDetails, txtDir.Text)
                    'accumulate the amount total and the records processed count
                    dblDebits = dblDebits + CDbl(strAmountPaid) 'rRec("Amt").ToString
                    intDebits = intDebits + 1
                    intCredits = intCredits + 1
                    Dim myCom As New data.oledb.oledbCommand("SELECT BankName FROM SystemBanks WHERE BankCode LIKE " _
                        & "'%" & CLng(Mid(strBankSortCodeFormated, 2, (strBankSortCodeFormated.Length - 1))) & "'", cnn)
                    Dim objReadBankName As data.oledb.oledbdatareader = myCom.ExecuteReader
                    Dim strBankName As String = Nothing
                    While objReadBankName.Read()
                        If Not IsDBNull(objReadBankName(0).ToString) Then strBankName = objReadBankName(0).ToString Else strBankName = ""
                        Exit While
                    End While
                    objReadBankName.Close()
                    arrPrintRecords.Add(UCase(Trim(strName)) & " " & UCase(Trim(strInits)) & ";" & CLng(strBankSortCodeFormated) & ";" & strBankName & ";" & strEmployeeBankAccount & ";" & strAmountPaid)
                End If
            End If
        End If
    End Sub

    Private Function PayPointSelected(ByVal PayPoint As Long) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim i As Integer = 0
        If chkPayPoints.CheckedItems.Count <> 0 Then
            ' If so, loop through all checked items and process options.
            For i = 0 To chkPayPoints.CheckedItems.Count - 1
                If PayPoint = CInt(chkPayPoints.CheckedItems(i).ToString) Then
                    boolReturn = True
                    Exit For
                End If
            Next i
        End If
        Return boolReturn
        Exit Function
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Error While Validating Pay Point")
    End Function

    Private Sub Version4File()
        On Error GoTo RaiseErr

        'Loop through an outside array

        Dim arrNets As New ArrayList

        Dim strNetCodes() As String
        If Not String.IsNullOrEmpty(cboNetSalary.Text) Then
            iNet = CInt(cboNetSalary.Text)
        End If
        If Not String.IsNullOrEmpty(cboSplitPayCode1.Text) Then
            intSplitNetCode1 = CInt(cboSplitPayCode1.Text)
        End If

        If Not String.IsNullOrEmpty(cboSplitPayCode2.Text) Then
            intSplitNetCode2 = CInt(cboSplitPayCode2.Text)
        End If

        If Not String.IsNullOrEmpty(cboSplitPayCode3.Text) Then
            intSplitNetCode3 = CInt(cboSplitPayCode3.Text)
        End If

        If Not String.IsNullOrEmpty(cboSplitPayCode4.Text) Then
            intSplitNetCode4 = CInt(cboSplitPayCode4.Text)
        End If

        If Not String.IsNullOrEmpty(cboSplitPayCode5.Text) Then
            intSplitNetCode5 = CInt(cboSplitPayCode5.Text)
        End If

        With arrNets
            .Add(iNet)
            .Add(intSplitNetCode1)
            .Add(intSplitNetCode2)
            .Add(intSplitNetCode3)
            .Add(intSplitNetCode4)
            .Add(intSplitNetCode5)
        End With

        'Dim rRec As ADODB.Recordset
        Dim strCurrency As String = txtCurrency.Text



        Dim rRec As data.oledb.oledbdatareader
        Dim cBnkCode As String
        Dim cBnkAcc As String
        Dim sRecType As String
        Dim strBankSortCodeFormated As String = "0000000"
        Dim strEmployeeName As String
        Dim strAmountPaid As String

        'initialize the array
        arrPrintRecords = New ArrayList

        'Begin the data validation
        If String.IsNullOrEmpty(txtCurrency.Text) Then
            MsgBox("Please specify the currency used for salary payments", MsgBoxStyle.Exclamation, "Missing Currency")
            txtCurrency.Focus()
            TabControl1.SelectedIndex = 1
            Exit Sub
        End If

        Dim strCoyBankCode() As String = Split(cboBank.Text, ",")
        'Get the company bankdetails
        If strCoyBankCode.Length < 2 Then
            MsgBox("Please enter the company bank", vbInformation, "Smart Extractor 1.0")
            cboBank.Focus()
            Exit Sub
        Else
            cBnkCode = strCoyBankCode(0)
        End If
        Dim strFillZeros As String = "00000000000000000000"
        If IsNumeric(txtAccNum.Text) Then
            cBnkAcc = CStr(Format(CDbl(txtAccNum.Text), "00000000000000000000"))
        Else
            If txtAccNum.Text.Length > 20 Then txtAccNum.Text = Mid(txtAccNum.Text, 1, 20)
            cBnkAcc = CStr(Mid(strFillZeros, 1, (20 - txtAccNum.Text.Length)) & txtAccNum.Text)
        End If

        'End data validation

        If strCurrency.Length < 3 Then strCurrency = strCurrency & Space(3 - strCurrency.Length)

        If cboTransType.Text = "SALARY DEPOSITS" Then sRecType = "PAY"
        If cboTransType.Text = "PAYORD CREDITS" Then sRecType = "PAY"
        If cboTransType.Text = "DEBMUL DEBITS" Then sRecType = "DEB"

        'check for any excluded banks that may have been selected
        Dim LItem As ListViewItem
        Dim LItems As ListView.CheckedListViewItemCollection
        LItems = lstAvailableBanks.CheckedItems
        ReDim strExemptBanks(0 To (lstAvailableBanks.CheckedItems.Count - 1))
        Dim i As Integer
        i = 0
        For Each LItem In LItems
            strExemptBanks(i) = CInt(LItem.SubItems(0).Text)
            i = i + 1
        Next

        'initialize the values for amounts
        dblDebits = 0 : dblCredits = 0 : intDebits = 0 : intCredits = 0

        'print the header details

        Dim sDetails As String = "UHL" & CStr(Format(sProcessDate.Value, "yyyyMMdd")) & txtSenderId.Text & Space(9 - txtSenderId.Text.Length) & txtReceiverId.Text & Space(9 - txtReceiverId.Text.Length) & "" & "000001" & cboTransType.Text & Space(15 - Len(cboTransType.Text)) & "004" & txtSenderName.Text & Space(30 - txtSenderName.Text.Length) & txtReceiverName.Text & Space(30 - txtReceiverName.Text.Length) & txtPackageName.Text & Space(30 - txtPackageName.Text.Length)
        PrintHeader(sDetails, txtDir.Text)

        Dim strSql As String = "SELECT EmployeeMaster.LastName, EmployeeMaster.FirstName, EmployeeMaster.OtherNames, EmployeeBanks.BankCode, " _
            & "EmployeeBanks.AccountNumber, EmployeeRunFile.RunAmounts, EmployeeMaster.PayPoint, EmployeeMaster.EmployeeNo FROM EmployeeMaster " _
            & "INNER JOIN EmployeeBanks ON EmployeeMaster.EmployeeNo = EmployeeBanks.EmployeeNo INNER JOIN " _
            & "EmployeeRunFile ON EmployeeMaster.EmployeeNo = EmployeeRunFile.EmployeeNo WHERE (EmployeeBanks.PayMethod = 'Bank')"
        objCommand = New data.oledb.oledbCommand(strSql, cnn)
        rRec = objCommand.ExecuteReader

        'Get the count of the all the records for the progress bar
        Dim strSqlCount As String = strSql
        Dim objCommandCount As New data.oledb.oledbCommand(strSqlCount, cnn)
        Dim readCount As data.oledb.oledbdatareader = objCommandCount.ExecuteReader
        Dim intCountRecs As Integer = 0
        While readCount.Read
            intCountRecs += 1
        End While
        readCount.Close()
        ProgressBar1.Value = 0 : ProgressBar1.Maximum = intCountRecs + 1

        'print the details

        While rRec.Read
            boolIsExcluded = False

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

            Dim strEmployeeBankAccount As String = "00000000000000000000"
            Dim strNetValues() As String = Split(rRec("RunAmounts").ToString, "|")

            For yp As Integer = 0 To arrNets.Count - 1

                strAmountPaid = "0"
                Dim intNetCode As Integer = CInt(arrNets.Item(yp)) - 1

                If yp = 0 Then

                    If intNetCode > 0 Then
                        strAmountPaid = CStr(Format((CDbl(strNetValues(intNetCode)) * 100), "000000000000000000000000"))
                        strBankSortCodeFormated = CStr(Format(CLng(Mid(rRec("BankCode").ToString, 1, 7)), "0000000"))
                        If Not IsDBNull(rRec("AccountNumber").ToString) Then strEmployeeBankAccount = rRec("AccountNumber").ToString
                        strEmployeeBankAccount = Mid(strFillZeros, 1, (20 - strEmployeeBankAccount.Length)) & strEmployeeBankAccount
                    End If

                Else

                    If intNetCode > 0 Then
                        Dim strSql1 As String = "SELECT EmployeeSplitPayments.BankCode, " _
                            & "EmployeeSplitPayments.AccountNumber FROM EmployeeSplitPayments WHERE " _
                            & "(EmployeeSplitPayments.CodeNo = " & arrNets.Item(yp) & ") AND " _
                            & "(EmployeeSplitPayments.EmployeeNo = '" & rRec("EmployeeNo").ToString & "')"
                        Dim objCommandGetSplits As New Data.OleDb.OleDbCommand(strSql1, cnn)
                        Dim objReadEmployeeSplits As Data.OleDb.OleDbDataReader = objCommandGetSplits.ExecuteReader

                        While objReadEmployeeSplits.Read
                            strAmountPaid = CStr(Format((CDbl(strNetValues(arrNets.Item(yp))) * 100), "000000000000000000000000"))
                            Dim dblPayAmount As Double = CDbl(strAmountPaid) / 100
                            If dblPayAmount > 0 Then
                                strBankSortCodeFormated = CStr(Format(CLng(Mid(rRec("BankCode").ToString, 1, 7)), "0000000"))
                                Dim strRawBankAccount As String = objReadEmployeeSplits("AccountNumber").ToString
                                If strRawBankAccount.Length > 20 Then strRawBankAccount = Mid(strRawBankAccount, 1, 15)
                                strRawBankAccount = Mid(strFillZeros, 1, (20 - strRawBankAccount.Length)) & strRawBankAccount
                                strEmployeeBankAccount = strRawBankAccount
                            End If

                            Exit While
                        End While
                        objReadEmployeeSplits.Close()
                    End If

                    End If

                    If CDbl(strAmountPaid) > 0 And Not String.IsNullOrEmpty(strEmployeeBankAccount) _
                        And Not String.IsNullOrEmpty(strBankSortCodeFormated) Then
                        'check that the bank is not part of the excluded
                        For i = 0 To lstAvailableBanks.CheckedItems.Count - 1
                            If CLng(strBankSortCodeFormated) = strExemptBanks(i) Then
                                boolIsExcluded = True
                                Exit For
                            End If
                        Next
                        If boolIsExcluded = False Then
                            'Check that the employee selected is within the desired pay points
                            If optAll.Checked = True Then
                                'print the details to file. First assign values
                                sDetails = "PAY" & strBankSortCodeFormated & _
                                    strEmployeeBankAccount & "01" & Space(27) & "51" & _
                                    cBnkCode & cBnkAcc & "01" & Space(27) & Space(15) & _
                                    strEmployeeName & strAmountPaid & UCase(strCurrency) & "   " & CStr(Format(sProcessDate.Value, "yyyyMMdd")) & "00" & Space(96)
                                PrintDetails(sDetails, txtDir.Text)
                                'accumulate the amount total and the records processed count
                                dblDebits = dblDebits + CDbl(strAmountPaid)
                                intDebits = intDebits + 1
                                intCredits = intCredits + 1
                                Dim myCom As New Data.OleDb.OleDbCommand("SELECT BankName FROM SystemBanks WHERE BankCode LIKE '%" & CLng(Mid(strBankSortCodeFormated, 2, (strBankSortCodeFormated.Length - 1))) & "'", cnn)
                                Dim objReadBankName As Data.OleDb.OleDbDataReader = myCom.ExecuteReader
                                Dim strBankName As String = Nothing
                                While objReadBankName.Read()
                                    If Not IsDBNull(objReadBankName(0).ToString) Then strBankName = objReadBankName(0).ToString Else strBankName = ""
                                    Exit While
                                End While
                                objReadBankName.Close()
                                arrPrintRecords.Add(UCase(Trim(strPrintName)) & " " & UCase(Trim(strPrintInits)) & ";" & CLng(strBankSortCodeFormated) & ";" & strBankName & ";" & strEmployeeBankAccount & ";" & strAmountPaid)
                            Else
                                If PayPointSelected(CInt(rRec("PayPoint").ToString)) = True Then
                                    'print the details to file. First assign values
                                    sDetails = "PAY" & strBankSortCodeFormated & _
                                        strEmployeeBankAccount & "01" & Space(27) & "51" & _
                                        cBnkCode & cBnkAcc & "01" & Space(27) & Space(15) & _
                                        strEmployeeName & strAmountPaid & UCase(strCurrency) & "   " & CStr(Format(sProcessDate.Value, "yyyyMMdd")) & "00" & Space(96)
                                    PrintDetails(sDetails, txtDir.Text)
                                    'accumulate the amount total and the records processed count
                                    dblDebits = dblDebits + CDbl(strAmountPaid)
                                    intDebits = intDebits + 1
                                    intCredits = intCredits + 1
                                    Dim myCom As New Data.OleDb.OleDbCommand("SELECT BankName FROM SystemBanks WHERE BankCode LIKE '%" & CLng(Mid(strBankSortCodeFormated, 2, (strBankSortCodeFormated.Length - 1))) & "'", cnn)
                                    Dim objReadBankName As Data.OleDb.OleDbDataReader = myCom.ExecuteReader
                                    Dim strBankName As String = Nothing
                                    While objReadBankName.Read()
                                        If Not IsDBNull(objReadBankName(0).ToString) Then strBankName = objReadBankName(0).ToString Else strBankName = ""
                                        Exit While
                                    End While
                                    objReadBankName.Close()
                                    arrPrintRecords.Add(UCase(Trim(strPrintName)) & " " & UCase(Trim(strPrintInits)) & ";" & CLng(strBankSortCodeFormated) & ";" & strBankName & ";" & strEmployeeBankAccount & ";" & strAmountPaid)
                                End If
                            End If
                        End If
                    End If
            Next
            'rRec.MoveNext()
            ProgressBar1.Value = ProgressBar1.Value + 1
        End While
        'End If
        rRec.Close()

        'print the trailing record
        PrintTrailer("UTL" & strCurrency & CStr(Format((dblDebits * 100), "000000000000000000000000")) & CStr(Format((dblDebits * 100), "000000000000000000000000")) & CStr(Format(intDebits, "000000")) & CStr(Format(intCredits, "000000") & "000000000000000000"), txtDir.Text)

        'Save settings if required
        If boolFromSavedExtracts = False Then
            If MsgBox(intDebits & " have been processed successfully. Do you want to save the current settings?", MsgBoxStyle.YesNo, "Bank Extract Processing") = MsgBoxResult.Yes Then
                boolAbort = False
                Dim f As New frmExtractName
                f.ShowDialog()
                If boolAbort = True Then Exit Sub
                SaveSettings()
            End If
        Else
            MsgBox(intDebits & " have been processed successfully.", MsgBoxStyle.Information, "Bank Extract Processing")
        End If

        PrintBankReport()
        ClearControls()
        TabControl1.SelectedIndex = 0
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Bank File Extract Error")
    End Sub

    Private Sub SaveSettings()
        On Error GoTo RaiseErr
        'Add the details to the database

        Dim intSplit1 As Integer = 0
        Dim intSplit2 As Integer = 0
        Dim intSplit3 As Integer = 0
        Dim intSplit4 As Integer = 0
        Dim intSplit5 As Integer = 0

        If IsNumeric(cboSplitPayCode1.Text) Then intSplit1 = CInt(cboSplitPayCode1.Text)
        If IsNumeric(cboSplitPayCode2.Text) Then intSplit2 = CInt(cboSplitPayCode2.Text)
        If IsNumeric(cboSplitPayCode3.Text) Then intSplit3 = CInt(cboSplitPayCode3.Text)
        If IsNumeric(cboSplitPayCode4.Text) Then intSplit4 = CInt(cboSplitPayCode4.Text)
        If IsNumeric(cboSplitPayCode5.Text) Then intSplit5 = CInt(cboSplitPayCode5.Text)

        Dim strInsert As String = "INSERT INTO ZIM_Bank_Extracts (ExtractName, FileVersion, CoyBank, " _
            & "CoyAccount, SenderId, ReceiverId, TransmissionType, SenderName, ReceiverName, " _
            & "PackageName, NetSalaryCode, FilePath, Split1, Split2, Split3, Split4, Split5) " _
            & "VALUES ('" & StrExtractName & "', '" & cboVersion.Text & "', " _
            & "'" & cboBank.Text & "', '" & txtAccNum.Text & "', '" & txtSenderId.Text & "', " _
            & "'" & txtReceiverId.Text & "', '" & cboTransType.Text & "', '" & txtSenderName.Text & "', " _
            & "'" & txtReceiverName.Text & "', '" & txtPackageName.Text & "', '" & cboNetSalary.Text & "', " _
            & "'" & txtDir.Text & "', " & intSplit1 & ", " & intSplit2 & ", " & intSplit3 & ", " & intSplit4 & ", " & intSplit5 & ")"
        objCommand = New data.oledb.oledbCommand(strInsert, cnn)
        objCommand.ExecuteNonQuery()
        'db.Execute(strInsert)
        'Loop through the excluded banks and add then to the database
        Dim i As Integer = 0
        Dim LItem As ListViewItem
        Dim LItems As ListView.CheckedListViewItemCollection
        LItems = lstAvailableBanks.CheckedItems
        arrExcludedBanks = New ArrayList
        For Each LItem In LItems
            Dim st As String = LItem.SubItems(0).Text
            arrExcludedBanks.Add(st)
        Next
        For i = 0 To arrExcludedBanks.Count - 1
            strInsert = "INSERT INTO ZIM_Bank_Excludes (ExtractName, BankDetails) VALUES ('" & StrExtractName & "', '" & arrExcludedBanks(i) & "')"
            objCommand = New data.oledb.oledbCommand(strInsert, cnn)
            objCommand.ExecuteNonQuery()
            'db.Execute(strInsert)
        Next
        'Immediately refresh the extract grid 
        LoadSavedBanks()
        MsgBox("Extract Details Saved Successfully !!", MsgBoxStyle.Information, "Extract Details Save Success")
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Bank File Extract Error")
    End Sub

    Private Sub cboVersion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVersion.SelectedIndexChanged
        cboTransType.Items.Clear()
        If cboVersion.Text = "Version 3" Then
            cboTransType.Items.Add("PAYMUL CREDITS")
            cboTransType.Items.Add("PAYORD CREDITS")
            cboTransType.Items.Add("DEBMUL DEBITS")
            'Label10.Enabled = False
            'Label11.Enabled = False
            'Label12.Enabled = False
            'Label13.Enabled = False
            txtReceiverName.Enabled = False
            txtSenderName.Enabled = True
            txtPackageName.Enabled = False
            txtCurrency.Enabled = False
            txtAccNum.MaxLength = 15
        Else
            cboTransType.Items.Add("SALARY DEPOSITS")
            cboTransType.Items.Add("PAYORD CREDITS")
            cboTransType.Items.Add("DEBMUL DEBITS")
            'Label10.Enabled = True
            'Label11.Enabled = True
            'Label12.Enabled = True
            txtReceiverName.Enabled = True
            txtSenderName.Enabled = True
            txtPackageName.Enabled = True
            txtCurrency.Enabled = True
            txtAccNum.MaxLength = 20
        End If
    End Sub

    Private Sub dgrid_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellClick
        On Error GoTo RaiseErr
        If e.ColumnIndex = 1 Then
            If MsgBox("Are you sure you want to delete this bank extract", MsgBoxStyle.YesNo, "Bank Extract Parameter Deletion") = MsgBoxResult.Yes Then
                Dim strSql As String = "DELETE FROM ZIM_Bank_Extracts WHERE ExtractName = '" & dgrid.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Value.ToString & "'"
                objCommand = New data.oledb.oledbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                strSql = "DELETE FROM ZIM_Bank_Excludes WHERE ExtractName = '" & dgrid.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Value.ToString & "'"
                objCommand = New data.oledb.oledbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                'remove the item from the grid
                dgrid.Rows.RemoveAt(e.RowIndex)
                MsgBox("Bank extract removed successfully", MsgBoxStyle.Information, "Bank Extract Parameter Deletion")
            End If
        End If
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Extract Delete Failure")
    End Sub

    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        If dgrid.Rows.Count <= 0 Then Exit Sub
        boolFromSavedExtracts = True
        On Error GoTo RaiseErr

        'Initialize the combo boxes

        If cboNetSalary.Items.Count > 0 Then cboNetSalary.SelectedIndex = 0
        If cboSplitPayCode1.Items.Count > 0 Then cboSplitPayCode1.SelectedIndex = 0
        If cboSplitPayCode2.Items.Count > 0 Then cboSplitPayCode2.SelectedIndex = 0
        If cboSplitPayCode3.Items.Count > 0 Then cboSplitPayCode3.SelectedIndex = 0
        If cboSplitPayCode4.Items.Count > 0 Then cboSplitPayCode4.SelectedIndex = 0
        If cboSplitPayCode5.Items.Count > 0 Then cboSplitPayCode5.SelectedIndex = 0

        'Get the saved report data from the text file
        Dim strSql As String = "SELECT * FROM ZIM_Bank_Extracts WHERE ExtractName = '" & dgrid.CurrentRow.Cells(0).Value.ToString & "'"
        objCommand = New data.oledb.oledbCommand(strSql, cnn)
        Dim rs As data.oledb.oledbdatareader = objCommand.ExecuteReader

        'Dim rs As New ADODB.Recordset
        'rs.Open(strSql, db, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        While (rs.Read)
            If Not IsDBNull(rs("FileVersion").ToString) Then cboVersion.Text = rs("FileVersion").ToString
            If Not IsDBNull(rs("CoyBank").ToString) Then cboBank.Text = rs("CoyBank").ToString
            If Not IsDBNull(rs("CoyAccount").ToString) Then txtAccNum.Text = rs("CoyAccount").ToString
            If Not IsDBNull(rs("SenderId").ToString) Then txtSenderId.Text = rs("SenderId").ToString
            If Not IsDBNull(rs("ReceiverId").ToString) Then txtReceiverId.Text = rs("ReceiverId").ToString
            If Not IsDBNull(rs("TransmissionType").ToString) Then cboTransType.Text = rs("TransmissionType").ToString
            If Not IsDBNull(rs("SenderName").ToString) Then txtSenderName.Text = rs("SenderName").ToString
            If Not IsDBNull(rs("ReceiverName").ToString) Then txtReceiverName.Text = rs("ReceiverName").ToString
            If Not IsDBNull(rs("PackageName").ToString) Then txtPackageName.Text = rs("PackageName").ToString
            If Not IsDBNull(rs("NetSalaryCode").ToString) Then cboNetSalary.Text = Format(CInt(rs("NetSalaryCode").ToString), "000")
            '    If Not IsNumeric(rs("NetSalaryCode").ToString) Then
            '        Dim strsplit() As String = Split(rs("NetSalaryCode").ToString, ",")
            '        If IsNumeric(strsplit(0)) Then cboNetSalary.Text = Format(CInt(strsplit(0)), "000")
            '    End If
            'End If

            If Not IsDBNull(rs("FilePath").ToString) Then txtDir.Text = rs("FilePath").ToString
            If IsNumeric(rs("Split1").ToString) Then cboSplitPayCode1.Text = Format(CInt(rs("Split1").ToString), "000")
            If IsNumeric(rs("Split2").ToString) Then cboSplitPayCode2.Text = Format(CInt(rs("Split2").ToString), "000")
            If IsNumeric(rs("Split3").ToString) Then cboSplitPayCode3.Text = Format(CInt(rs("Split3").ToString), "000")
            If IsNumeric(rs("Split4").ToString) Then cboSplitPayCode4.Text = Format(CInt(rs("Split4").ToString), "000")
            If IsNumeric(rs("Split5").ToString) Then cboSplitPayCode5.Text = Format(CInt(rs("Split5").ToString), "000")
        End While
        rs.Close()

        'Get the included banks
        strSql = "SELECT * FROM ZIM_Bank_Excludes WHERE ExtractName = '" & dgrid.CurrentRow.Cells(0).Value.ToString & "'"
        objCommand = New data.oledb.oledbCommand(strSql, cnn)
        rs = objCommand.ExecuteReader

        'rs = New ADODB.Recordset
        'rs.Open(strSql, db, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

        'Check all the available banks
        While rs.Read
            'Loop thru the listview and set the included banks to false
            Dim LItem As ListViewItem
            Dim LItems As ListView.ListViewItemCollection
            LItems = lstAvailableBanks.Items
            arrExcludedBanks = New ArrayList
            Dim i As Integer = 0
            For Each LItem In LItems
                Dim st As String = LItem.SubItems(0).Text
                If st = rs("BankDetails").ToString Then
                    lstAvailableBanks.Items(i).Checked = True
                    Exit For
                End If
                i += 1
            Next
            'rs.MoveNext()
        End While
        rs.Close()
        TabControl1.SelectedIndex = 1
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Extract Delete Failure")
    End Sub

    Private Sub LoadSavedBanks()
        'Check that the tables actually exist in the database, if the tables do not exist then create them
        On Error GoTo RaiseErr
        dgrid.Rows.Clear()
        Dim strSql As String = "IF OBJECT_ID(N'ZIM_Bank_Extracts', N'U') IS NULL " _
            & "CREATE TABLE [dbo].[ZIM_Bank_Extracts]([ExtractName] [nvarchar](50) NOT NULL PRIMARY KEY," _
            & "[FileVersion] [nvarchar](15) NOT NULL,[CoyBank] [nvarchar](150) NOT NULL,[CoyAccount] [nvarchar](35) NOT NULL," _
            & "[SenderId] [nvarchar](15) NOT NULL,[ReceiverId] [nvarchar](15) NOT NULL,[TransmissionType] [nvarchar](15) NOT NULL," _
            & "[SenderName] [nvarchar](150) NULL,[ReceiverName] [nvarchar](150) NULL,[PackageName] [nvarchar](150) NULL," _
            & "[NetSalaryCode] [nvarchar](150) NOT NULL,[FilePath] [nvarchar](300) NOT NULL," _
            & "[Split1] [int] NOT NULL DEFAULT (0),[Split2] [int] NOT NULL DEFAULT (0),[Split3] [int] NOT NULL DEFAULT (0)," _
            & "[Split4] [int] NOT NULL DEFAULT (0),[Split5] [int] NOT NULL DEFAULT (0))"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        strSql = "IF OBJECT_ID(N'ZIM_Bank_Excludes', N'U') IS NULL CREATE TABLE ZIM_Bank_Excludes ([ExtractName][nvarchar](50) NOT NULL, [BankDetails][nvarchar](150) NOT NULL)"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'After creating the tables you can now select from them


        objCommand = New data.oledb.oledbCommand("SELECT ExtractName FROM ZIM_Bank_Extracts ORDER BY ExtractName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        While objReader.Read
            dGrid.Rows.Add(1)
            dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Application Failed To Load Preset Extracts")
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
        strExcelValues = strPrintValues

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

    Private Sub optSelective_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSelective.CheckedChanged
        If optSelective.Checked = True Then
            grpPaypoints.Enabled = True
        Else
            grpPaypoints.Enabled = False
        End If
    End Sub

    Private Sub btnSaveSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSettings.Click
        Dim f As New frmExtractName
        f.ShowDialog()
        If boolAbort = True Then Exit Sub
        SaveSettings()
    End Sub

    Private Sub cboBank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBank.SelectedIndexChanged
        If cboBank.Text = "Add, ...." Then
            boolEditStatus = False
            boolAbort = False
            Dim f As New frmBanksMaintenance
            f.ShowDialog()
            InitialiazeDetails()
        End If
    End Sub

    Private Sub lstAvailableBanks_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstAvailableBanks.ColumnClick
        ' Determine if the clicked column is already the column that is 
        ' being sorted.
        If (e.Column = lvwColumnSorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        Me.lstAvailableBanks.Sort()
    End Sub

    Private Sub optCheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCheckAll.CheckedChanged
        If optCheckAll.Checked = True Then
            Dim LItem As ListViewItem
            Dim LItems As ListView.ListViewItemCollection
            LItems = lstAvailableBanks.Items
            Dim i As Integer = 0
            For Each LItem In LItems
                If LItem.Checked = False Then LItem.Checked = True
            Next
        End If
    End Sub

    Private Sub optUncheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUncheckAll.CheckedChanged
        If optUncheckAll.Checked = True Then
            Dim LItem As ListViewItem
            Dim LItems As ListView.ListViewItemCollection
            LItems = lstAvailableBanks.Items
            Dim i As Integer = 0
            For Each LItem In LItems
                If LItem.Checked = True Then LItem.Checked = False
            Next
        End If
    End Sub

    Private Sub Version4SplitPayment()

        On Error GoTo RaiseErr

        'Dim rRec As ADODB.Recordset
        Dim rRec As data.oledb.oledbdatareader

        Dim cBnkCode As String
        Dim cBnkAcc As String
        Dim sRecType As String
        'Dim strBankSortCodeFormated As String
        Dim strEmployeeName As String

        'initialize the array
        arrPrintRecords = New ArrayList
        'Begin the data validation
        'tafadzwa.vukomba@aon.co.zw
        Dim strCoyBankCode() As String = Split(cboBank.Text, ",")
        'Get the company bankdetails
        If strCoyBankCode.Length < 2 Then
            MsgBox("Please enter the company bank", vbInformation, "Smart Extractor 1.0")
            cboBank.Focus()
            Exit Sub
        Else
            cBnkCode = strCoyBankCode(0)
        End If
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

        Dim strBuffer() As String
        If Not String.IsNullOrEmpty(cboNetSalary.Text) Then
            strBuffer = Split(cboNetSalary.Text, ", ")
            If strBuffer.Length > 1 Then iNet = CInt(strBuffer(0))
        End If
        If Not String.IsNullOrEmpty(cboSplitPayCode1.Text) Then
            strBuffer = Split(cboSplitPayCode1.Text, ", ")
            If strBuffer.Length > 1 Then intSplitNetCode1 = CInt(strBuffer(0))
        End If

        If Not String.IsNullOrEmpty(cboSplitPayCode2.Text) Then
            strBuffer = Split(cboSplitPayCode2.Text, ", ")
            If strBuffer.Length > 1 Then intSplitNetCode2 = CInt(strBuffer(0))
        End If

        Dim strSql As String = "SELECT PW_Runf.EmpNo, PW_Runf.Surname, PW_Runf.Inits, PW_Runf.PayPoint FROM PW_Runf"

        objCommand = New data.oledb.oledbCommand(strSql, cnn)
        rRec = objCommand.ExecuteReader

        Dim strSqlCount As String = "SELECT COUNT(PW_Runf.EmpNo) FROM  PW_Runf"
        Dim objCommandCount As New data.oledb.oledbCommand(strSqlCount, cnn)
        Dim readCount As data.oledb.oledbdatareader = objCommandCount.ExecuteReader
        Dim intCountRecs As Integer = 0
        'While readCount.Read
        '    intCountRecs += 1
        'End While
        If readCount.HasRows Then
            readCount.Read()
            If IsNumeric(readCount(0).ToString) Then intCountRecs = CInt(readCount(0).ToString)
        End If
        readCount.Close()


        ProgressBar1.Value = 0 : ProgressBar1.Maximum = intCountRecs + 1
        'rRec.Open(strSql, db, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'check for any excluded banks that may have been selected
        Dim LItem As ListViewItem
        Dim LItems As ListView.CheckedListViewItemCollection
        LItems = lstAvailableBanks.CheckedItems
        ReDim strExemptBanks(0 To (lstAvailableBanks.CheckedItems.Count - 1))
        Dim i As Integer
        i = 0
        For Each LItem In LItems
            strExemptBanks(i) = CInt(LItem.SubItems(0).Text)
            i = i + 1
        Next


        sDetails = Nothing

        'If rRec.RecordCount > 0 Then
        If rRec.HasRows Then
            'initialize the values for amounts
            dblDebits = 0 : dblCredits = 0 : intDebits = 0 : intCredits = 0
            'print the header details

            sDetails = "UHL" & CStr(Format(sProcessDate.Value, "yyyyMMdd")) & txtSenderId.Text & Space(9 - txtSenderId.Text.Length) & txtReceiverId.Text & Space(9 - txtReceiverId.Text.Length) & "" & "000001" & cboTransType.Text & Space(15 - Len(cboTransType.Text)) & "003"
            PrintHeader(sDetails, txtDir.Text)

            'print the details
            While rRec.Read
                boolIsExcluded = False


                '*** GET THE BANKING DATA FROM THE NET AND THE SPLIT CODES

                Dim strAmountPaid_1 As String = "0000000000000000" 'Net salary value
                Dim strAmountPaid_2 As String = "0000000000000000" 'Split code 1 value
                Dim strAmountPaid_3 As String = "0000000000000000" 'Split code 2 value
                Dim strAmountPaid_4 As String = "0000000000000000" 'Split code 1 value
                Dim strAmountPaid_5 As String = "0000000000000000" 'Split code 2 value
                Dim strAmountPaid_6 As String = "0000000000000000" 'Split code 1 value

                Dim strBankSortCodeFormated_1 = "0000000"
                Dim strEmployeeBankAccount_1 As String = "000000000000000"
                '---------------------------------------------------------------------
                Dim strBankSortCodeFormated_2 = "0000000"
                Dim strEmployeeBankAccount_2 As String = "000000000000000"
                '---------------------------------------------------------------------
                Dim strBankSortCodeFormated_3 = "0000000"
                Dim strEmployeeBankAccount_3 As String = "000000000000000"
                '---------------------------------------------------------------------
                Dim strBankSortCodeFormated_4 = "0000000"
                Dim strEmployeeBankAccount_4 As String = "000000000000000"
                '---------------------------------------------------------------------
                Dim strBankSortCodeFormated_5 = "0000000"
                Dim strEmployeeBankAccount_5 As String = "000000000000000"
                '---------------------------------------------------------------------
                Dim strBankSortCodeFormated_6 = "0000000"
                Dim strEmployeeBankAccount_6 As String = "000000000000000"
                '---------------------------------------------------------------------


                Dim objCommandData1 As data.oledb.oledbCommand
                Dim objCommandData2 As data.oledb.oledbCommand
                Dim objCommandData3 As data.oledb.oledbCommand
                Dim objCommandData4 As data.oledb.oledbCommand
                Dim objCommandData5 As data.oledb.oledbCommand
                Dim objCommandData6 As data.oledb.oledbCommand

                'Get the Net pay amount and details
                '==================================

                objCommandData1 = New data.oledb.oledbCommand("SELECT PW_RunfPayeeDetails.DestinBankSortCode, " _
                    & "PW_RunfPayeeDetails.DestinBankAccountNumber, PW_RunfAmts.Amt FROM PW_RunfPayeeDetails " _
                    & "INNER JOIN PW_RunfAmts ON PW_RunfPayeeDetails.EmpNo = PW_RunfAmts.EmpNo " _
                    & "WHERE (PW_RunfAmts.OrdinalNo = " & iNet & ") AND (PW_RunfPayeeDetails.PayMode = 'B') " _
                    & "AND (PW_RunfAmts.Usage <= 2) AND (PW_RunfPayeeDetails.EmpNo = " & rRec("EmpNo").ToString & ") " _
                    & "and (PW_RunfPayeeDetails.SplitPayCode = " & iNet & ")", cnn)
                Dim objReadNetValue As data.oledb.oledbdatareader = objCommandData1.ExecuteReader
                If objReadNetValue.HasRows Then
                    objReadNetValue.Read()
                    If IsNumeric(objReadNetValue("Amt").ToString) Then
                        strAmountPaid_1 = CStr(Format(CDbl((objReadNetValue("Amt").ToString) * 100), "0000000000000000"))
                    End If
                    If Not IsDBNull(objReadNetValue("DestinBankSortCode").ToString) Then
                        strBankSortCodeFormated_1 = CStr(Format(CLng(Mid(objReadNetValue("DestinBankSortCode").ToString, 1, 7)), "0000000"))
                    End If
                    If Not IsDBNull(objReadNetValue("DestinBankAccountNumber").ToString) Then
                        strEmployeeBankAccount_1 = objReadNetValue("DestinBankAccountNumber").ToString
                    End If
                    strEmployeeBankAccount_1 = Mid(strFillZeros, 1, (15 - strEmployeeBankAccount_1.Length)) & strEmployeeBankAccount_1
                End If
                objReadNetValue.Close()

                'Get the 1st split pay code values
                '=================================
                objCommandData2 = New data.oledb.oledbCommand("SELECT PW_RunfPayeeDetails.DestinBankSortCode, " _
                    & "PW_RunfPayeeDetails.DestinBankAccountNumber, PW_RunfAmts.Amt FROM PW_RunfPayeeDetails " _
                    & "INNER JOIN PW_RunfAmts ON PW_RunfPayeeDetails.EmpNo = PW_RunfAmts.EmpNo " _
                    & "WHERE (PW_RunfAmts.OrdinalNo = " & intSplitNetCode1 & ") AND (PW_RunfPayeeDetails.PayMode = 'B') " _
                    & "AND (PW_RunfAmts.Usage <= 2) AND (PW_RunfPayeeDetails.EmpNo = " & rRec("EmpNo").ToString & ") " _
                    & "and (PW_RunfPayeeDetails.SplitPayCode = " & intSplitNetCode1 & ")", cnn)
                Dim objReadSplitOneValue As data.oledb.oledbdatareader = objCommandData2.ExecuteReader
                If objReadSplitOneValue.HasRows Then
                    objReadSplitOneValue.Read()
                    If IsNumeric(objReadSplitOneValue("Amt").ToString) Then
                        strAmountPaid_2 = CStr(Format(CDbl((objReadSplitOneValue("Amt").ToString) * 100), "0000000000000000"))
                    End If
                    If Not IsDBNull(objReadSplitOneValue("DestinBankSortCode").ToString) Then
                        strBankSortCodeFormated_2 = CStr(Format(CLng(Mid(objReadSplitOneValue("DestinBankSortCode").ToString, 1, 7)), "0000000"))
                    End If
                    If Not IsDBNull(objReadSplitOneValue("DestinBankAccountNumber").ToString) Then
                        strEmployeeBankAccount_2 = objReadSplitOneValue("DestinBankAccountNumber").ToString
                    End If
                    strEmployeeBankAccount_2 = Mid(strFillZeros, 1, (15 - strEmployeeBankAccount_2.Length)) & strEmployeeBankAccount_2
                End If
                objReadSplitOneValue.Close()

                'Get the 2nd split code values
                '=============================
                objCommandData3 = New data.oledb.oledbCommand("SELECT PW_RunfPayeeDetails.DestinBankSortCode, " _
                    & "PW_RunfPayeeDetails.DestinBankAccountNumber, PW_RunfAmts.Amt FROM PW_RunfPayeeDetails " _
                    & "INNER JOIN PW_RunfAmts ON PW_RunfPayeeDetails.EmpNo = PW_RunfAmts.EmpNo " _
                    & "WHERE (PW_RunfAmts.OrdinalNo = " & intSplitNetCode2 & ") AND (PW_RunfPayeeDetails.PayMode = 'B') " _
                    & "AND (PW_RunfAmts.Usage <= 2) AND (PW_RunfPayeeDetails.EmpNo = " & rRec("EmpNo").ToString & ") " _
                    & "and (PW_RunfPayeeDetails.SplitPayCode = " & intSplitNetCode2 & ")", cnn)
                Dim objReadSplitTwoValue As data.oledb.oledbdatareader = objCommandData3.ExecuteReader
                If objReadSplitTwoValue.HasRows Then
                    objReadSplitTwoValue.Read()
                    If IsNumeric(objReadSplitTwoValue("Amt").ToString) Then
                        strAmountPaid_3 = CStr(Format(CDbl((objReadSplitTwoValue("Amt").ToString) * 100), "0000000000000000"))
                    End If
                    If Not IsDBNull(objReadSplitTwoValue("DestinBankSortCode").ToString) Then
                        strBankSortCodeFormated_3 = CStr(Format(CLng(Mid(objReadSplitTwoValue("DestinBankSortCode").ToString, 1, 7)), "0000000"))
                    End If
                    If Not IsDBNull(objReadSplitTwoValue("DestinBankAccountNumber").ToString) Then
                        strEmployeeBankAccount_3 = objReadSplitTwoValue("DestinBankAccountNumber").ToString
                    End If
                    strEmployeeBankAccount_3 = Mid(strFillZeros, 1, (15 - strEmployeeBankAccount_3.Length)) & strEmployeeBankAccount_3
                End If
                objReadSplitTwoValue.Close()

                'Get the 3rd split pay code values
                '=================================
                objCommandData4 = New data.oledb.oledbCommand("SELECT PW_RunfPayeeDetails.DestinBankSortCode, " _
                    & "PW_RunfPayeeDetails.DestinBankAccountNumber, PW_RunfAmts.Amt FROM PW_RunfPayeeDetails " _
                    & "INNER JOIN PW_RunfAmts ON PW_RunfPayeeDetails.EmpNo = PW_RunfAmts.EmpNo " _
                    & "WHERE (PW_RunfAmts.OrdinalNo = " & intSplitNetCode3 & ") AND (PW_RunfPayeeDetails.PayMode = 'B') " _
                    & "AND (PW_RunfAmts.Usage <= 2) AND (PW_RunfPayeeDetails.EmpNo = " & rRec("EmpNo").ToString & ") " _
                    & "and (PW_RunfPayeeDetails.SplitPayCode = " & intSplitNetCode3 & ")", cnn)
                Dim objReadSplitThreeValue As data.oledb.oledbdatareader = objCommandData4.ExecuteReader
                If objReadSplitThreeValue.HasRows Then
                    objReadSplitThreeValue.Read()
                    If IsNumeric(objReadSplitThreeValue("Amt").ToString) Then
                        strAmountPaid_3 = CStr(Format(CDbl((objReadSplitThreeValue("Amt").ToString) * 100), "0000000000000000"))
                    End If
                    If Not IsDBNull(objReadSplitThreeValue("DestinBankSortCode").ToString) Then
                        strBankSortCodeFormated_3 = CStr(Format(CLng(Mid(objReadSplitThreeValue("DestinBankSortCode").ToString, 1, 7)), "0000000"))
                    End If
                    If Not IsDBNull(objReadSplitThreeValue("DestinBankAccountNumber").ToString) Then
                        strEmployeeBankAccount_3 = objReadSplitThreeValue("DestinBankAccountNumber").ToString
                    End If
                    strEmployeeBankAccount_3 = Mid(strFillZeros, 1, (15 - strEmployeeBankAccount_3.Length)) & strEmployeeBankAccount_3
                End If
                objReadSplitThreeValue.Close()

                'Get the 4th split code values
                '=============================
                objCommandData5 = New data.oledb.oledbCommand("SELECT PW_RunfPayeeDetails.DestinBankSortCode, " _
                    & "PW_RunfPayeeDetails.DestinBankAccountNumber, PW_RunfAmts.Amt FROM PW_RunfPayeeDetails " _
                    & "INNER JOIN PW_RunfAmts ON PW_RunfPayeeDetails.EmpNo = PW_RunfAmts.EmpNo " _
                    & "WHERE (PW_RunfAmts.OrdinalNo = " & intSplitNetCode4 & ") AND (PW_RunfPayeeDetails.PayMode = 'B') " _
                    & "AND (PW_RunfAmts.Usage <= 2) AND (PW_RunfPayeeDetails.EmpNo = " & rRec("EmpNo").ToString & ") " _
                    & "and (PW_RunfPayeeDetails.SplitPayCode = " & intSplitNetCode4 & ")", cnn)
                Dim objReadSplitFourValue As data.oledb.oledbdatareader = objCommandData5.ExecuteReader
                If objReadSplitFourValue.HasRows Then
                    objReadSplitFourValue.Read()
                    If IsNumeric(objReadSplitFourValue("Amt").ToString) Then
                        strAmountPaid_4 = CStr(Format(CDbl((objReadSplitFourValue("Amt").ToString) * 100), "0000000000000000"))
                    End If
                    If Not IsDBNull(objReadSplitFourValue("DestinBankSortCode").ToString) Then
                        strBankSortCodeFormated_4 = CStr(Format(CLng(Mid(objReadSplitFourValue("DestinBankSortCode").ToString, 1, 7)), "0000000"))
                    End If
                    If Not IsDBNull(objReadSplitFourValue("DestinBankAccountNumber").ToString) Then
                        strEmployeeBankAccount_4 = objReadSplitFourValue("DestinBankAccountNumber").ToString
                    End If
                    strEmployeeBankAccount_4 = Mid(strFillZeros, 1, (15 - strEmployeeBankAccount_4.Length)) & strEmployeeBankAccount_4
                End If
                objReadSplitFourValue.Close()

                'Get the 5th split pay code values
                '=================================
                objCommandData6 = New data.oledb.oledbCommand("SELECT PW_RunfPayeeDetails.DestinBankSortCode, " _
                    & "PW_RunfPayeeDetails.DestinBankAccountNumber, PW_RunfAmts.Amt FROM PW_RunfPayeeDetails " _
                    & "INNER JOIN PW_RunfAmts ON PW_RunfPayeeDetails.EmpNo = PW_RunfAmts.EmpNo " _
                    & "WHERE (PW_RunfAmts.OrdinalNo = " & intSplitNetCode5 & ") AND (PW_RunfPayeeDetails.PayMode = 'B') " _
                    & "AND (PW_RunfAmts.Usage <= 2) AND (PW_RunfPayeeDetails.EmpNo = " & rRec("EmpNo").ToString & ") " _
                    & "and (PW_RunfPayeeDetails.SplitPayCode = " & intSplitNetCode5 & ")", cnn)
                Dim objReadSplitFiveValue As data.oledb.oledbdatareader = objCommandData6.ExecuteReader
                If objReadSplitFiveValue.HasRows Then
                    objReadSplitFiveValue.Read()
                    If IsNumeric(objReadSplitFiveValue("Amt").ToString) Then
                        strAmountPaid_5 = CStr(Format(CDbl((objReadSplitFiveValue("Amt").ToString) * 100), "0000000000000000"))
                    End If
                    If Not IsDBNull(objReadSplitFiveValue("DestinBankSortCode").ToString) Then
                        strBankSortCodeFormated_5 = CStr(Format(CLng(Mid(objReadSplitFiveValue("DestinBankSortCode").ToString, 1, 7)), "0000000"))
                    End If
                    If Not IsDBNull(objReadSplitFiveValue("DestinBankAccountNumber").ToString) Then
                        strEmployeeBankAccount_5 = objReadSplitFiveValue("DestinBankAccountNumber").ToString
                    End If
                    strEmployeeBankAccount_5 = Mid(strFillZeros, 1, (15 - strEmployeeBankAccount_5.Length)) & strEmployeeBankAccount_5
                End If
                objReadSplitFiveValue.Close()

                '-----------------------------------------------------------------------------------------------------------------------------------

                Dim strPrintName As String = Nothing
                Dim strPrintInits As String = Nothing

                strEmployeeName = rRec("Surname").ToString & Space(26 - Len(rRec("Surname").ToString)) & rRec("Inits").ToString
                strEmployeeName = strEmployeeName & Space(30 - Len(strEmployeeName))

                If Not IsDBNull(rRec("Surname").ToString) Then strPrintName = rRec("Surname").ToString
                If Not IsDBNull(rRec("Inits").ToString) Then strPrintInits = rRec("Inits").ToString

                'Write the details after testing for the bank exclusion and split existence
                '==========================================================================
                If CDbl(strAmountPaid_2) > 0 Or CDbl(strAmountPaid_3) > 0 _
                    Or CDbl(strAmountPaid_4) > 0 Or CDbl(strAmountPaid_5) > 0 _
                    Or CDbl(strAmountPaid_6) > 0 Then

                    If CDbl(strAmountPaid_2) > 0 Then
                        If ExcludeBank(strBankSortCodeFormated_2) = False Then
                            Version3Writter(strBankSortCodeFormated_2, strEmployeeBankAccount_2, _
                            cBnkCode, cBnkAcc, strEmployeeName, strAmountPaid_2, CInt(rRec("PayPoint").ToString), strPrintName, strPrintInits)
                        End If
                    End If
                    If CDbl(strAmountPaid_3) > 0 Then
                        If ExcludeBank(strBankSortCodeFormated_3) = False Then
                            Version3Writter(strBankSortCodeFormated_3, strEmployeeBankAccount_3, _
                            cBnkCode, cBnkAcc, strEmployeeName, strAmountPaid_3, CInt(rRec("PayPoint").ToString), strPrintName, strPrintInits)
                        End If
                    End If

                    If CDbl(strAmountPaid_4) > 0 Then
                        If ExcludeBank(strBankSortCodeFormated_4) = False Then
                            Version3Writter(strBankSortCodeFormated_4, strEmployeeBankAccount_4, _
                            cBnkCode, cBnkAcc, strEmployeeName, strAmountPaid_4, CInt(rRec("PayPoint").ToString), strPrintName, strPrintInits)
                        End If
                    End If
                    If CDbl(strAmountPaid_5) > 0 Then
                        If ExcludeBank(strBankSortCodeFormated_5) = False Then
                            Version3Writter(strBankSortCodeFormated_5, strEmployeeBankAccount_5, _
                            cBnkCode, cBnkAcc, strEmployeeName, strAmountPaid_5, CInt(rRec("PayPoint").ToString), strPrintName, strPrintInits)
                        End If
                    End If
                    If CDbl(strAmountPaid_6) > 0 Then
                        If ExcludeBank(strBankSortCodeFormated_6) = False Then
                            Version3Writter(strBankSortCodeFormated_6, strEmployeeBankAccount_6, _
                            cBnkCode, cBnkAcc, strEmployeeName, strAmountPaid_6, CInt(rRec("PayPoint").ToString), strPrintName, strPrintInits)
                        End If
                    End If

                Else
                    If CDbl(strAmountPaid_1) > 0 Then
                        If ExcludeBank(strBankSortCodeFormated_1) = False Then
                            Version3Writter(strBankSortCodeFormated_1, strEmployeeBankAccount_1, _
                            cBnkCode, cBnkAcc, strEmployeeName, strAmountPaid_1, CInt(rRec("PayPoint").ToString), strPrintName, strPrintInits)
                        End If
                    End If
                End If


                ProgressBar1.Value = ProgressBar1.Value + 1
            End While
            rRec.Close()
        End If


        '==========================================
        If ProgressBar1.Value > 0 Then
            'print the trailing record
            PrintTrailer("UTL" & CStr(Format((dblDebits * 100), "0000000000000000")) & CStr(Format((dblDebits * 100), "0000000000000000")) & CStr(Format(intDebits, "000000")) & CStr(Format(intCredits, "000000")), txtDir.Text)
            'Save settings if required
            If boolFromSavedExtracts = False Then
                If MsgBox(intDebits & " have been processed successfully. Do you want to save the current settings?", MsgBoxStyle.YesNo, "Bank Extract Processing") = MsgBoxResult.Yes Then
                    boolAbort = False
                    Dim f As New frmExtractName
                    f.ShowDialog()
                    If boolAbort = True Then Exit Sub
                    SaveSettings()
                End If
            Else
                MsgBox(intDebits & " have been processed successfully. Do you want to save the current settings?", MsgBoxStyle.Information, "Bank Extract Processing")
            End If
            PrintBankReport()
            If chkOutputExcel.Checked = True Then
                ExportToExcelFromDataGrid()
                'OutputExcelFile()
            End If
        End If

        ClearControls()
        TabControl1.SelectedIndex = 0
        Exit Sub
RaiseErr:
        MsgBox(Err.Description & " " & Err.Number, MsgBoxStyle.Critical, "Bank File Extract Error")
    End Sub

    Private Sub cboNetSalary_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNetSalary.SelectedIndexChanged
        lblNetDescription.Text = ""
        lblNetDescription.Text = cboNetSalary.SelectedItem.Col2
    End Sub

    Private Sub cboSplitPayCode1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSplitPayCode1.SelectedIndexChanged
        lblSplit1Description.Text = ""
        lblSplit1Description.Text = cboSplitPayCode1.SelectedItem.Col2
    End Sub

    Private Sub cboSplitPayCode2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSplitPayCode2.SelectedIndexChanged
        lblSplit2Description.Text = ""
        lblSplit2Description.Text = cboSplitPayCode2.SelectedItem.Col2
    End Sub

    Private Sub cboSplitPayCode3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSplitPayCode3.SelectedIndexChanged
        lblSplit3Description.Text = ""
        lblSplit3Description.Text = cboSplitPayCode3.SelectedItem.Col2
    End Sub

    Private Sub cboSplitPayCode4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSplitPayCode4.SelectedIndexChanged
        lblSplit4Description.Text = ""
        lblSplit4Description.Text = cboSplitPayCode4.SelectedItem.Col2
    End Sub

    Private Sub cboSplitPayCode5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSplitPayCode5.SelectedIndexChanged
        lblSplit5Description.Text = ""
        lblSplit5Description.Text = cboSplitPayCode5.SelectedItem.Col2
    End Sub

    Private Sub UpdateTables()
        On Error GoTo RaiseErr
        Dim strSql As String = "CREATE TABLE [dbo].[ZIM_Bank_Excludes]([ExtractName] [nvarchar](50) NOT NULL PRIMARY KEY, " _
            & "[BankDetails] [nvarchar](150) NOT NULL )"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        strSql = "CREATE TABLE [dbo].[ZIM_Bank_Extracts]([ExtractName] [nvarchar](50) NOT NULL PRIMARY KEY," _
            & "[FileVersion] [nvarchar](15) NOT NULL,[CoyBank] [nvarchar](150) NOT NULL,[CoyAccount] [nvarchar](35) NOT NULL," _
            & "[SenderId] [nvarchar](15) NOT NULL,[ReceiverId] [nvarchar](15) NOT NULL,[TransmissionType] [nvarchar](15) NOT NULL," _
            & "[SenderName] [nvarchar](150) NULL,[ReceiverName] [nvarchar](150) NULL,[PackageName] [nvarchar](150) NULL," _
            & "[NetSalaryCode] [nvarchar](150) NOT NULL,[FilePath] [nvarchar](300) NOT NULL," _
            & "[Split1] [int] NOT NULL DEFAULT (0),[Split2] [int] NOT NULL DEFAULT (0),[Split3] [int] NOT NULL DEFAULT (0)," _
            & "[Split4] [int] NOT NULL DEFAULT (0),[Split5] [int] NOT NULL DEFAULT (0))"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Master Data Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class