Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmEmployeeDetails

    Dim strSelectedEmployeeLastName As String = Nothing
    Dim strSelectedEmployeeFirstName As String = Nothing
    Dim strSelectedEmployeeOtherNames As String = Nothing

    Private Sub frmEmployeeDetails_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlEarnings.Width = pnlPayslip.Width / 2
    End Sub

    Dim strInitialDateValue As String = Nothing
    Dim strActivityStatus As String = Nothing
    Dim _originalSplitterDistance As Integer
    Dim strBirthDate As String = Nothing
    Dim strHireDate As String = Nothing
    Dim strDischargeDate As String = Nothing
    Dim strMedaidDate As String = Nothing
    Dim strPensionDate As String = Nothing

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub GetSelectedEmployeeNames()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT LastName, FirstName, OtherNames FROM EmployeeMaster WHERE EmployeeNo = '" & strPublicEmployeeId & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strSelectedEmployeeLastName = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strSelectedEmployeeFirstName = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strSelectedEmployeeOtherNames = objReader(2).ToString
        End If
        objReader.Close()
        'Get the key employment details
        strSql = "SELECT PayPoint, CostCenter, Department FROM Employment WHERE EmployeeNo = '" & strPublicEmployeeId & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then lblPaypoint.Text = UCase(objReader(0).ToString)
            If Not IsDBNull(objReader(1).ToString) Then lblCostCode.Text = UCase(objReader(1).ToString)
            If Not IsDBNull(objReader(2).ToString) Then lblDepartment.Text = UCase(objReader(2).ToString)
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On key employee details fetch"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dgvEarnings_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEarnings.CellEndEdit
        If IsNumeric(dgvEarnings.CurrentCell.Value) Then dgvEarnings.CurrentCell.Value = Format(CDbl(dgvEarnings.CurrentCell.Value.ToString), "##0.00")
    End Sub

    Private Sub dgvDeductions_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDeductions.CellEndEdit
        If IsNumeric(dgvDeductions.CurrentCell.Value) Then dgvDeductions.CurrentCell.Value = Format(CDbl(dgvDeductions.CurrentCell.Value.ToString), "##0.00")
    End Sub

    Private Sub dgvOther_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOther.CellEndEdit
        If IsNumeric(dgvOther.CurrentCell.Value) Then dgvOther.CurrentCell.Value = Format(CDbl(dgvOther.CurrentCell.Value.ToString), "##0.00")
    End Sub

    Private Sub dgvEarnings_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvEarnings.EditingControlShowing
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

    Private Sub dgvDeductions_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvDeductions.EditingControlShowing
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

    Private Sub dgvOther_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvOther.EditingControlShowing
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

    Private Sub frmEmployeeDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        On Error GoTo RaiseErr

        boolAbort = False
        GetSelectedEmployeeNames()
        If boolAbort = True Then Exit Sub

        'load the banks
        GetBankFileDetails()

        Me.TextExtra = UCase(Mid(strEmployeeLastName, 1, 1)) & LCase(Mid(strEmployeeLastName, 2, (strEmployeeLastName.Length - 1))) & " " _
                & UCase(Mid(strEmployeeFirstName, 1, 1)) & LCase(Mid(strEmployeeFirstName, 2, (strEmployeeFirstName.Length - 1))) & " " &
                strPublicEmployeeId
        LoadSelectedEmployee()

        'Get the prior values for the codes
        Dim i As Integer = 0
        For i = 0 To dgvEarnings.Rows.Count - 1
            gwt_comm.PriorCodeValues(CInt(dgvEarnings.Rows(i).Cells(0).Value.ToString), CDbl(dgvEarnings.Rows(i).Cells(2).Value.ToString))
        Next
        For i = 0 To dgvDeductions.Rows.Count - 1
            gwt_comm.PriorCodeValues(CInt(dgvDeductions.Rows(i).Cells(0).Value.ToString), CDbl(dgvDeductions.Rows(i).Cells(2).Value.ToString))
        Next
        For i = 0 To dgvOther.Rows.Count - 1
            gwt_comm.PriorCodeValues(CInt(dgvOther.Rows(i).Cells(0).Value.ToString), CDbl(dgvOther.Rows(i).Cells(2).Value.ToString))
        Next
        If boolEditStatus = False Then btnSplitPayments.Enabled = False Else btnSplitPayments.Enabled = True

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On employee details form load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboBankCodes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBankCodes.SelectedIndexChanged
        If cboBankCodes.Focused = False Then Exit Sub
        If Not cboBankCodes.SelectedItem Is Nothing Then
            lblBankCode.Text = cboBankCodes.SelectedItem.Col2
        Else
            lblBankCode.Text = ""
        End If
    End Sub

    Private Sub InsertBankingRecord()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "INSERT INTO EmployeeBanks (EmployeeNo, BankCode, AccountType, " _
            & "AccountHolder, AccountNumber) VALUES ('" & strPublicEmployeeId & "', " _
            & "'" & lblBankCode.Text & "', '" & cboAccountType.Text & "', " _
            & "'" & txtAccountOwner.Text & "', '" & txtAccountNumber.Text & "')"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Banking Details Insert"
        ShowErrorMessage()
    End Sub

    Private Sub InsertDates()
        On Error GoTo RaiseErr
        'First delete everything that relates to the current employee
        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeDates WHERE EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim i As Integer = 0
        For i = 0 To dGridDates.Rows.Count - 1
            Dim strDateValue As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGridDates.Rows(i).Cells(2).Value), "")) Then
                strDateValue = Convert.ToString(dGridDates.Rows(i).Cells(2).Value)
                If IsDate(strDateValue) Then
                    If strSystemDateFormat = "English" Then strDateValue = CStr(Format(CDate(strDateValue), "dd-MMM-yyyy"))
                    sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeDates " _
                        & "(EmployeeNo, OrdinalNo, DateValue) VALUES ('" & strPublicEmployeeId & "', " _
                        & "" & CInt(dGridDates.Rows(i).Cells(0).Value.ToString) & ", " _
                        & "'" & CDate(strDateValue) & "')", cnn)
                    sqlCommand.ExecuteNonQuery()
                End If
            End If
        Next
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Date Details Insert"
        ShowErrorMessage()
    End Sub

    Private Sub InsertReferences()
        On Error GoTo RaiseErr
        'First delete everything that relates to the current employee
        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeReferences WHERE EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim i As Integer = 0
        For i = 0 To dGridReferences.Rows.Count - 1
            Dim strReference As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGridReferences.Rows(i).Cells(2).Value), "")) Then
                strReference = Convert.ToString(dGridReferences.Rows(i).Cells(2).Value)
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeReferences " _
                    & "(EmployeeNo, OrdinalNo, Reference) VALUES ('" & strPublicEmployeeId & "', " _
                    & "" & CInt(dGridReferences.Rows(i).Cells(0).Value.ToString) & ", " _
                    & "'" & strReference & "')", cnn)
                sqlCommand.ExecuteNonQuery()
            End If
        Next
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Reference Details Insert"
        ShowErrorMessage()
    End Sub

    Private Sub InsertFlags()
        On Error GoTo RaiseErr
        'First delete everything that relates to the current employee
        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeFlags WHERE EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim i As Integer = 0
        For i = 0 To dGridFlags.Rows.Count - 1
            Dim strFlag As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGridFlags.Rows(i).Cells(2).Value), "")) Then
                strFlag = Convert.ToString(dGridFlags.Rows(i).Cells(2).Value)
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeFlags " _
                    & "(EmployeeNo, OrdinalNo, Flag) VALUES ('" & strPublicEmployeeId & "', " _
                    & "" & CInt(dGridFlags.Rows(i).Cells(0).Value.ToString) & ", " _
                    & "'" & strFlag & "')", cnn)
                sqlCommand.ExecuteNonQuery()
            End If
        Next
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Flags Details Insert"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSelectedEmployee()
        On Error GoTo RaiseErr

        If boolDisallowSave = True Then btnOK.Enabled = False
        'Load the bank codes
        'GetBankFileDetails()

        'If the form load status is edit then open populate the employee codes and other values

        Dim strSelect As String = "SELECT SystemCodes.CodeNo, SystemCodes.Description, EmployeeCodes.Amount, " _
            & "SystemCodes.CodeType FROM SystemCodes LEFT OUTER JOIN EmployeeCodes ON " _
            & "SystemCodes.CodeNo = EmployeeCodes.CodeNo WHERE SystemCodes.DisplayStatus = 'Y' " _
            & "AND EmployeeCodes.EmployeeNo = '" & strPublicEmployeeId & "'"
        boolAbort = False
        PopulateCodes(strSelect)
        If boolAbort = True Then Exit Sub
        PopulateMaster()
        If boolAbort = True Then Exit Sub
        PopulateEmployeeBankDetails()
        If boolAbort = True Then Exit Sub
        LoadFlags()
        If boolAbort = True Then Exit Sub
        LoadDates()
        If boolAbort = True Then Exit Sub
        LoadReferenceNumbers()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Employee Master Details Load Failure"
        ShowErrorMessage()
    End Sub

    Private Sub GetBankFileDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT BankName +';'+BankCode AS [Banking] FROM SystemBanks ORDER BY BankName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboBankCodes
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "250;60"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(BankCode) FROM SystemBanks", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboBankCodes.Items.Clear()
        Dim i As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            i = i + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboBankCodes.SelectedIndex = -1
            cboBankCodes.Items.Clear()
            cboBankCodes.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboBankCodes.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Bank Information Load"
        ShowErrorMessage()
    End Sub

    Private Sub PopulateMaster()
        On Error GoTo RaiseErr
        'open the masterfile and assign values relating to the selected employee
        Dim strSql As String = "SELECT EmployeeNo, LastName, FirstName, IdNumber, OtherNames, CONVERT(NVARCHAR, BirthDate, 105) AS [BirthDate], " _
            & "Gender, MaritalStatus, Address1, Address2, Address3, Address4, Telephone, Cellphone, EmailAddress, Status, " _
            & "ClockNo, DirAmt, DirPercent, CONVERT(NVARCHAR, DischDate, 105) AS [DischDate], DischRsn, StopFrom, StopTo, TaxCode, TaxDependents, " _
            & "TaxRef, Title, MaidenName, EmployeeNotes, PicturePath, FingerPrintPath, EmployeeClass FROM EmployeeMaster " _
            & "WHERE EmployeeNo = '" & strPublicEmployeeId & "'"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim strBuffer() As String

        If objReader.HasRows Then
            objReader.Read()

            If Not IsDBNull(objReader("DirAmt").ToString) Then txtTaxDirectiveAmt.Text = objReader("DirAmt").ToString
            If Not IsDBNull(objReader("DirPercent").ToString) Then txtTaxDirectivePercent.Text = objReader("DirPercent").ToString
            If Not IsDBNull(objReader("TaxCode").ToString) Then txtTaxCode.Text = objReader("TaxCode").ToString
            If Not IsDBNull(objReader("TaxDependents").ToString) Then txtTaxDependents.Text = objReader("TaxDependents").ToString
            If Not IsDBNull(objReader("TaxRef").ToString) Then txtTaxReference.Text = objReader("TaxRef").ToString
            If Not IsDBNull(objReader("EmployeeNotes").ToString) Then txtNotes.Text = objReader("EmployeeNotes").ToString

        End If
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Master Data Load Error"
        ShowErrorMessage()
    End Sub

    Private Sub PopulateEmployeeBankDetails()
        'open the employee bank details and assign the selected employee records
        On Error GoTo RaiseErr
        'open the masterfile and assign values relating to the selected employee
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT *, SystemBanks.BankName FROM " _
            & "EmployeeBanks LEFT OUTER JOIN SystemBanks ON EmployeeBanks.BankCode = SystemBanks.BankCode " _
            & "WHERE EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Continue to read until you reach the end of the file.
        While objReader.Read
            cboPaymentMethod.Text = objReader("PayMethod").ToString
            lblBankCode.Text = objReader("BankName").ToString
            txtAccountNumber.Text = objReader("AccountNumber").ToString
            cboAccountType.Text = objReader("AccountType").ToString
            txtAccountOwner.Text = objReader("AccountHolder").ToString
            cboBankCodes.Text = objReader("BankCode").ToString
            lblBankCode.Text = objReader("BankCode").ToString
        End While
        'Close the file.
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Employee Contact Data Load Error"
        ShowErrorMessage()
    End Sub

    Private Sub PopulateCodes(ByVal strSql As String)
        'Set the default row number for earnings, deductions and other codes grids
        dgvEarnings.Rows.Clear()
        dgvDeductions.Rows.Clear()
        dgvOther.Rows.Clear()
        'open the codes file and read the code number and the description
        'open the codes file and load the payroll codes
        'On initial installation the codes file contain only code numbers
        On Error GoTo RaiseErr
        Dim sqlCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim objStreamReaderEmployeeValues As StreamReader
        Dim strLine As String
        Dim strEmployeeId As String
        Dim strLineEmployeeCodes As String
        Dim dblValue As Double 'Holds the value of the employee code
        Dim strRecordText() As String 'creates the record fields array
        Dim strCodeText() As String
        Dim ie As Integer 'datagrid row identifier for earnings
        Dim id As Integer 'datagrid row identifier for deductions
        Dim io As Integer 'datagrid row identifier for other

        Dim CurrentCell As DataGridViewCell
        ie = 0 : id = 0 : io = 0
        'First populate the blank codes from the system codes
        Dim strCodes As String = "SELECT SystemCodes.CodeNo, SystemCodes.Description, " _
            & "SystemCodes.CodeType FROM SystemCodes WHERE SystemCodes.DisplayStatus = 'Y' ORDER BY CodeNo"
        sqlCommand = New Data.OleDb.OleDbCommand(strCodes, cnn)
        objReader = sqlCommand.ExecuteReader
        'Continue to read until you reach the end of the file.
        While objReader.Read
            If Not IsDBNull(objReader("Description").ToString) Then
                If Not IsDBNull(objReader("CodeType").ToString) Then
                    Select Case UCase(objReader("CodeType").ToString)
                        Case Is = "E"
                            dgvEarnings.Rows.Add(1)
                            CurrentCell = dgvEarnings.Rows(ie).Cells(0)
                            CurrentCell.Value = Format(CInt(objReader("CodeNo").ToString), "0000")
                            CurrentCell = dgvEarnings.Rows(ie).Cells(1)
                            CurrentCell.Value = objReader("Description").ToString
                            CurrentCell = dgvEarnings.Rows(ie).Cells(2)
                            CurrentCell.Value = "0.00"
                            ie = ie + 1
                        Case Is = "D"
                            dgvDeductions.Rows.Add(1)
                            CurrentCell = dgvDeductions.Rows(id).Cells(0)
                            CurrentCell.Value = Format(CInt(objReader("CodeNo").ToString), "0000")
                            CurrentCell = dgvDeductions.Rows(id).Cells(1)
                            CurrentCell.Value = objReader("Description").ToString
                            CurrentCell = dgvDeductions.Rows(id).Cells(2)
                            CurrentCell.Value = "0.00"
                            id = id + 1
                        Case Else
                            dgvOther.Rows.Add(1)
                            CurrentCell = dgvOther.Rows(io).Cells(0)
                            CurrentCell.Value = Format(CInt(objReader("CodeNo").ToString), "0000")
                            CurrentCell = dgvOther.Rows(io).Cells(1)
                            CurrentCell.Value = objReader("Description").ToString
                            CurrentCell = dgvOther.Rows(io).Cells(2)
                            CurrentCell.Value = "0.00"
                            io = io + 1
                    End Select
                End If
            End If
        End While
        objReader.Close()
        'Now get the actual records and fill the actual values
        If boolEditStatus = False Then Exit Sub
        sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = sqlCommand.ExecuteReader
        Dim i As Integer = 0
        While objReader.Read
            If Not IsDBNull(objReader("Description").ToString) Then
                If Not IsDBNull(objReader("CodeType").ToString) Then
                    Select Case UCase(objReader("CodeType").ToString)
                        Case Is = "E"
                            For i = 0 To dgvEarnings.Rows.Count - 1
                                If CInt(dgvEarnings.Rows(i).Cells(0).Value.ToString) = CInt(objReader("CodeNo").ToString) Then
                                    If IsNumeric(objReader("Amount").ToString) Then dgvEarnings.Rows(i).Cells(2).Value = Format(CDbl(objReader("Amount").ToString), "##0.00")
                                    Exit For
                                End If
                            Next
                        Case Is = "D"
                            For i = 0 To dgvDeductions.Rows.Count - 1
                                If CInt(dgvDeductions.Rows(i).Cells(0).Value.ToString) = CInt(objReader("CodeNo").ToString) Then
                                    If IsNumeric(objReader("Amount").ToString) Then dgvDeductions.Rows(i).Cells(2).Value = Format(CDbl(objReader("Amount").ToString), "##0.00")
                                    Exit For
                                End If
                            Next
                        Case Else
                            For i = 0 To dgvOther.Rows.Count - 1
                                If CInt(dgvOther.Rows(i).Cells(0).Value.ToString) = CInt(objReader("CodeNo").ToString) Then
                                    If IsNumeric(objReader("Amount").ToString) Then dgvOther.Rows(i).Cells(2).Value = Format(CDbl(objReader("Amount").ToString), "##0.00")
                                    Exit For
                                End If
                            Next
                    End Select
                End If
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
    End Sub

    Private Sub UpdateEmployeeCodes()
        On Error GoTo RaiseErr
        Dim objStreamWriter As StreamWriter
        Dim strLine As String
        Dim strCodeText() As String
        Dim dblNewValue As Double
        Dim i As Integer
        Dim CurrentCell As DataGridViewCell
        Dim currentCode As Integer
        Dim currentCodeValue As Double
        Dim boolPassed As Boolean = False
        Dim sqlCommand As Data.OleDb.OleDbCommand
        'If the record is new, create the codes record for that particular employee first
        If boolEditStatus = False Then
            sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeCodes " _
                & "WHERE EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
            sqlCommand.ExecuteNonQuery()
            For i = 0 To dgvEarnings.Rows.Count - 1
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO " _
                    & "EmployeeCodes (EmployeeNo, CodeNo, Amount) VALUES " _
                    & "('" & strPublicEmployeeId & "', " & CInt(dgvEarnings.Rows(i).Cells(0).Value.ToString) & ", 0)", cnn)
                sqlCommand.ExecuteNonQuery()
            Next
            For i = 0 To dgvDeductions.Rows.Count - 1
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO " _
                    & "EmployeeCodes (EmployeeNo, CodeNo, Amount) VALUES " _
                    & "('" & strPublicEmployeeId & "', " & CInt(dgvDeductions.Rows(i).Cells(0).Value.ToString) & ", 0)", cnn)
                sqlCommand.ExecuteNonQuery()
            Next
            For i = 0 To dgvOther.Rows.Count - 1
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO " _
                    & "EmployeeCodes (EmployeeNo, CodeNo, Amount) VALUES " _
                    & "('" & strPublicEmployeeId & "', " & CInt(dgvOther.Rows(i).Cells(0).Value.ToString) & ", 0)", cnn)
                sqlCommand.ExecuteNonQuery()
            Next
        End If

        boolPassed = False
        With dgvEarnings
            For i = 0 To .Rows.Count - 1
                CurrentCell = .Rows(i).Cells(0)
                currentCode = CInt(CurrentCell.Value)
                CurrentCell = .Rows(i).Cells(2)
                currentCodeValue = CDbl(CurrentCell.Value)
                'Check that the code exists in anywhere
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeCodes " _
                    & "WHERE CodeNo = " & currentCode & " AND EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
                Dim objCheck As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
                If objCheck.HasRows Then
                    dblNewValue = currentCodeValue
                    sqlCommand = New Data.OleDb.OleDbCommand("UPDATE EmployeeCodes SET " _
                        & "Amount = " & dblNewValue & " WHERE EmployeeNo " _
                        & "= '" & strPublicEmployeeId & "' AND CodeNo = " & currentCode & "", cnn)
                    sqlCommand.ExecuteNonQuery()
                Else
                    If CDbl(currentCodeValue) > 0 Then
                        sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeCodes (EmployeeNo, " _
                                    & "CodeNo, Amount) VALUES ('" & strPublicEmployeeId & "', " & currentCode & ", " _
                                    & "" & currentCodeValue & ")", cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If
                objCheck.Close()
            Next i
        End With
        'If boolPassed = False Then
        With dgvDeductions
            For i = 0 To .Rows.Count - 1
                CurrentCell = .Rows(i).Cells(0)
                currentCode = CInt(CurrentCell.Value)
                CurrentCell = .Rows(i).Cells(2)
                currentCodeValue = CDbl(CurrentCell.Value)
                'Check that the code exists in anywhere
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeCodes " _
                    & "WHERE CodeNo = " & currentCode & " AND EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
                Dim objCheck As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
                If objCheck.HasRows Then
                    dblNewValue = currentCodeValue
                    sqlCommand = New Data.OleDb.OleDbCommand("UPDATE EmployeeCodes SET " _
                        & "Amount = " & dblNewValue & " WHERE EmployeeNo " _
                        & "= '" & strPublicEmployeeId & "' AND CodeNo = " & currentCode & "", cnn)
                    sqlCommand.ExecuteNonQuery()
                Else
                    If CDbl(currentCodeValue) > 0 Then
                        sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeCodes (EmployeeNo, " _
                                    & "CodeNo, Amount) VALUES ('" & strPublicEmployeeId & "', " & currentCode & ", " _
                                    & "" & currentCodeValue & ")", cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If
                objCheck.Close()
            Next i
        End With
        'End If
        'If boolPassed = False Then
        With dgvOther
            For i = 0 To .Rows.Count - 1
                CurrentCell = .Rows(i).Cells(0)
                currentCode = CInt(CurrentCell.Value)
                CurrentCell = .Rows(i).Cells(2)
                currentCodeValue = CDbl(CurrentCell.Value)
                'Check that the code exists in anywhere
                sqlCommand = New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeCodes " _
                    & "WHERE CodeNo = " & currentCode & " AND EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
                Dim objCheck As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
                If objCheck.HasRows Then
                    dblNewValue = currentCodeValue
                    sqlCommand = New Data.OleDb.OleDbCommand("UPDATE EmployeeCodes SET " _
                        & "Amount = " & dblNewValue & " WHERE EmployeeNo " _
                        & "= '" & strPublicEmployeeId & "' AND CodeNo = " & currentCode & "", cnn)
                    sqlCommand.ExecuteNonQuery()
                Else
                    If CDbl(currentCodeValue) > 0 Then
                        sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeCodes (EmployeeNo, " _
                                    & "CodeNo, Amount) VALUES ('" & strPublicEmployeeId & "', " & currentCode & ", " _
                                    & "" & currentCodeValue & ")", cnn)
                        sqlCommand.ExecuteNonQuery()
                    End If
                End If
                objCheck.Close()
            Next i
        End With
        sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeCodes WHERE " _
            & "Amount = 0 AND EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
        sqlCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Employee Codes Update Error"
        ShowErrorMessage()
    End Sub

    Private Sub cboPaymentMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPaymentMethod.SelectedIndexChanged
        If cboPaymentMethod.Text = "Cash" Or cboPaymentMethod.Text = "Cheque" Then
            cboBankCodes.Enabled = False
            txtAccountNumber.Enabled = False
            cboAccountType.Enabled = False
            txtAccountOwner.Enabled = False
        Else
            cboBankCodes.Enabled = True
            txtAccountNumber.Enabled = True
            cboAccountType.Enabled = True
            txtAccountOwner.Enabled = True
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SaveEmployeeData()
    End Sub

    Private Sub SaveEmployeeData()
        Dim strDetails As String
        Dim strContacts As String
        Dim strBankDetails As String
        Dim strEmployment As String

        On Error GoTo RaiseErr

        'Verify if the record alredy exist
        boolAbort = False

        Cursor = Cursors.WaitCursor


        'Get the initials from the given names and other names


        Dim strUpdate As String = "UPDATE EmployeeMaster SET " _
                & "DirAmt = " & txtTaxDirectiveAmt.Text & "" _
                & ",DirPercent = " & txtTaxDirectivePercent.Text & "" _
                & ",DischDate = '" & strDischargeDate & "'" _
                & ",TaxCode = '" & txtTaxCode.Text & "'" _
                & ",TaxDependents = '" & txtTaxDependents.Text & "'" _
                & ",TaxRef = '" & txtTaxReference.Text & "'" _
                & ",EmployeeNotes = '" & txtNotes.Text & "'" _
                & ",Status = '" & strActivityStatus & "'" _
                & "WHERE EmployeeNo = '" & strPublicEmployeeId & "'"

        Dim sqlCommand As New Data.OleDb.OleDbCommand(strUpdate, cnn)
        sqlCommand.ExecuteNonQuery()

        strUpdate = "UPDATE EmployeeBanks SET BankCode = '" & lblBankCode.Text & "'" _
                  & ",AccountType = '" & cboAccountType.Text & "'" _
                  & ",AccountHolder = '" & txtAccountOwner.Text & "'" _
                  & ",AccountNumber = '" & txtAccountNumber.Text & "'" _
                  & ",PayMethod = '" & cboPaymentMethod.Text & "' " _
                  & "WHERE EmployeeNo = '" & strPublicEmployeeId & "'"
        sqlCommand = New Data.OleDb.OleDbCommand(strUpdate, cnn)
        sqlCommand.ExecuteNonQuery()

        boolAbort = False
        UpdateEmployeeCodes()

        If boolAbort = True Then Exit Sub
        InsertDates()
        If boolAbort = True Then Exit Sub
        InsertFlags()
        If boolAbort = True Then Exit Sub
        InsertReferences()
        If boolAbort = True Then Exit Sub

        'Check and write out code changes as well
        Dim i As Integer = 0
        For i = 0 To dgvEarnings.Rows.Count - 1
            gwt_comm.CodeValueChanges(CInt(dgvEarnings.Rows(i).Cells(0).Value.ToString),
                dgvEarnings.Rows(i).Cells(1).Value.ToString, CDbl(dgvEarnings.Rows(i).Cells(2).Value.ToString))
        Next
        For i = 0 To dgvDeductions.Rows.Count - 1
            gwt_comm.CodeValueChanges(CInt(dgvDeductions.Rows(i).Cells(0).Value.ToString),
                dgvDeductions.Rows(i).Cells(1).Value.ToString, CDbl(dgvDeductions.Rows(i).Cells(2).Value.ToString))
        Next
        For i = 0 To dgvOther.Rows.Count - 1
            gwt_comm.CodeValueChanges(CInt(dgvOther.Rows(i).Cells(0).Value.ToString),
                dgvOther.Rows(i).Cells(1).Value.ToString, CDbl(dgvOther.Rows(i).Cells(2).Value.ToString))
        Next
        Cursor = Cursors.Default

        If boolAbort = False Then
            MessageBox.Show("Employee details saved successfully ", "Employee Details Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadSelectedEmployee()
        End If
        Me.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & "on Employee Record Save"
        ShowErrorMessage()
    End Sub

    Private Sub cboPaymentMethod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPaymentMethod.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then cboBankCodes.Focus()
    End Sub

    Private Sub cboBankCodes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboBankCodes.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtAccountNumber.Focus()
    End Sub

    Private Sub txtAccountNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountNumber.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then cboAccountType.Focus()
    End Sub

    Private Sub cboAccountType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAccountType.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then txtAccountOwner.Focus()
    End Sub

    Private Sub txtAccountOwner_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountOwner.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then TabControl1.SelectedIndex = 2
    End Sub

    Private Sub ClearControls()
        cboPaymentMethod.Text = ""
        cboBankCodes.Text = ""
        txtAccountNumber.Clear()
        cboAccountType.Text = ""
        txtAccountOwner.Clear()
    End Sub

    Private Sub LoadPayrollDetails()
        If TabControl1.SelectedTab.Text = "Current Payroll Information" Then
            If boolEditStatus = True Then
                With grdEarnings
                    .Rows.Clear()
                End With
                With grdDeductions
                    .Rows.Clear()
                End With
                Dim i As Integer = 0
                Dim dblGrossPay As Double = 0 : Dim dblTotalDeductions As Double = 0 : Dim dblNetSalary As Double = 0
                gwt_comm.GetKeyDataFields()
                Dim objCommand As New Data.OleDb.OleDbCommand("SELECT EmployeeNo, " _
                    & "RunAmounts FROM EmployeeRunFile WHERE EmployeeNo = " _
                    & "'" & strPublicEmployeeId & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                ArrDisplayEarnings = New ArrayList : arrDisplayDeductions = New ArrayList
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(1).ToString) Then
                        Dim strBuffer() As String = Split(objReader(1).ToString, "|")
                        Dim n As Integer = 0
                        For n = 0 To strBuffer.Length - 1
                            objCommand = New Data.OleDb.OleDbCommand("SELECT Description, CodeType FROM SystemCodes WHERE CodeNo = " & (n + 1) & "", cnn)
                            Dim objCodeReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                            If objCodeReader.HasRows Then
                                objCodeReader.Read()
                                If Not IsDBNull(objCodeReader(1).ToString) Then
                                    If UCase(objCodeReader(1).ToString) = "E" Then
                                        ArrDisplayEarnings.Add(Format((n + 1), "000") & ";" & UCase(objCodeReader(0).ToString) & ";" & strBuffer(n))
                                    End If
                                    If UCase(objCodeReader(1).ToString) = ("D") Then
                                        arrDisplayDeductions.Add(Format((n + 1), "000") & ";" & UCase(objCodeReader(0).ToString) & ";" & strBuffer(n))
                                    End If
                                End If
                            End If
                        Next
                        dblGrossPay = strBuffer(intPayrollGrossIncomeCode - 1)
                        dblTotalDeductions = strBuffer(intPayrollTotalDeductions - 1)
                        dblNetSalary = strBuffer(intPayrollNetIncomeCode - 1)
                    End If
                End If

                For i = 0 To (ArrDisplayEarnings.Count - 1)
                    Dim strbuffer() As String = Split(ArrDisplayEarnings(i), ";")
                    If IsNumeric(strbuffer(2)) Then
                        If CDbl(strbuffer(2)) <> 0 Then
                            grdEarnings.Rows.Add(1)
                            grdEarnings.Rows(grdEarnings.Rows.Count - 1).Cells(0).Value = CStr(Format(CInt(strbuffer(0)), "000"))
                            grdEarnings.Rows(grdEarnings.Rows.Count - 1).Cells(1).Value = strbuffer(1)
                            grdEarnings.Rows(grdEarnings.Rows.Count - 1).Cells(2).Value = Format(CDbl(strbuffer(2)), "##0.00")
                        End If
                    End If
                Next i
                For i = 0 To (arrDisplayDeductions.Count - 1)
                    Dim strbuffer() As String = Split(arrDisplayDeductions(i), ";")
                    If IsNumeric(strbuffer(2)) Then
                        If CDbl(strbuffer(2)) <> 0 Then
                            grdDeductions.Rows.Add(1)
                            grdDeductions.Rows(grdDeductions.Rows.Count - 1).Cells(0).Value = CStr(Format(CInt(strbuffer(0)), "000"))
                            grdDeductions.Rows(grdDeductions.Rows.Count - 1).Cells(1).Value = strbuffer(1)
                            grdDeductions.Rows(grdDeductions.Rows.Count - 1).Cells(2).Value = Format(CDbl(strbuffer(2)), "##0.00")
                        End If
                    End If
                Next i

                lblGrossPay.Text = CStr(Format(dblGrossPay, "#,##0.00"))
                lblTotalDeductions.Text = CStr(Format(dblTotalDeductions, "#,##0.00"))
                lblNetPay.Text = CStr(Format((dblGrossPay - dblTotalDeductions), "#,##0.00"))

            End If
        End If
    End Sub

    Private Sub LoadFlags()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT " _
            & "SystemFlagNames.FlagNo, SystemFlagNames.FlagName FROM " _
            & "SystemFlagNames ORDER BY FlagNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGridFlags.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(1).ToString) Then
                If Not String.IsNullOrEmpty(objReader(1).ToString) Then
                    dGridFlags.Rows.Add(1)
                    If Not IsDBNull(objReader(0).ToString) Then dGridFlags.Rows(dGridFlags.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                    If Not IsDBNull(objReader(1).ToString) Then dGridFlags.Rows(dGridFlags.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                End If
            End If
        End While
        objReader.Close()
        If boolEditStatus = False Then Exit Sub
        'Assign the values for the flags
        Dim i As Integer = 0
        For i = 0 To dGridFlags.Rows.Count - 1
            Dim intFlag As Integer = 0
            If Not (Object.Equals(Convert.ToString(dGridFlags.Rows(i).Cells(0).Value), "")) Then
                intFlag = Convert.ToString(dGridFlags.Rows(i).Cells(0).Value)
            End If
            Dim strSql As String = "SELECT Flag from EmployeeFlags WHERE " _
                & "EmployeeFlags.EmployeeNo = '" & strPublicEmployeeId & "' AND " _
                & "EmployeeFlags.OrdinalNo = " & intFlag & ""
            sqlCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = sqlCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then dGridFlags.Rows(i).Cells(2).Value = objReader(0).ToString
            End If
        Next
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Work Structure Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadReferenceNumbers()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT OrdinalNo, ReferenceName FROM SystemReferences ORDER BY OrdinalNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGridReferences.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(1).ToString) Then
                Dim strReferenceName As String = objReader(1).ToString
                If Not String.IsNullOrEmpty(strReferenceName) Then
                    dGridReferences.Rows.Add(1)
                    If Not IsDBNull(objReader(0).ToString) Then dGridReferences.Rows(dGridReferences.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                    If Not IsDBNull(objReader(1).ToString) Then dGridReferences.Rows(dGridReferences.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                End If
            End If
        End While
        objReader.Close()
        'Get the employee values
        If boolEditStatus = False Then Exit Sub
        Dim i As Integer = 0
        For i = 0 To dGridReferences.Rows.Count - 1
            Dim intNum As Integer = 0
            If Not (Object.Equals(Convert.ToString(dGridReferences.Rows(i).Cells(0).Value), "")) Then
                If IsNumeric(Convert.ToString(dGridReferences.Rows(i).Cells(0).Value)) Then
                    intNum = CInt(Convert.ToString(dGridReferences.Rows(i).Cells(0).Value))
                End If
            End If
            sqlCommand = New Data.OleDb.OleDbCommand("SELECT Reference FROM EmployeeReferences WHERE EmployeeNo = '" & strPublicEmployeeId & "' AND OrdinalNo = " & intNum & "", cnn)
            objReader = sqlCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then
                    dGridReferences.Rows(i).Cells(2).Value = objReader(0).ToString
                End If
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Reference Numbers Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadDates()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT OrdinalNo, DateName FROM SystemDates ORDER BY OrdinalNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGridDates.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(1).ToString) Then
                Dim strDateName As String = objReader(1).ToString
                If Not String.IsNullOrEmpty(strDateName) Then
                    dGridDates.Rows.Add(1)
                    If Not IsDBNull(objReader(0).ToString) Then dGridDates.Rows(dGridDates.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                    If Not IsDBNull(objReader(1).ToString) Then dGridDates.Rows(dGridDates.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                End If
            End If
        End While
        objReader.Close()
        If boolEditStatus = False Then Exit Sub
        'Get the employee values
        Dim i As Integer = 0
        For i = 0 To dGridDates.Rows.Count - 1
            Dim intNum As Integer = 0
            If Not (Object.Equals(Convert.ToString(dGridDates.Rows(i).Cells(0).Value), "")) Then
                If IsNumeric(Convert.ToString(dGridDates.Rows(i).Cells(0).Value)) Then
                    intNum = CInt(Convert.ToString(dGridDates.Rows(i).Cells(0).Value))
                End If
            End If
            sqlCommand = New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, DateValue, 105) AS [DateValue] " _
                & "FROM EmployeeDates WHERE EmployeeNo = '" & strPublicEmployeeId & "' AND OrdinalNo = " & intNum & "", cnn)
            objReader = sqlCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then
                    Dim strBuffer() As String = Split(objReader(0).ToString, "-")
                    If UCase(CStr(Format(CDate(strBuffer(0) & "-" & gwt_comm.getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2))), "dd-MMM-yyyy"))) <> "01-JAN-1900" Then
                        dGridDates.Rows(i).Cells(2).Value = CStr(Format(CDate(strBuffer(0) & "-" & gwt_comm.getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))))
                    End If
                End If
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Dates Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGridFlags_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridFlags.CellClick
        If dGridFlags.CurrentCell.ColumnIndex = 3 Then
            Dim intRow As Integer = dGridFlags.CurrentCell.RowIndex
            If Not dGridFlags.CurrentRow.Cells(2).Value = Nothing Then
                strSelectedValue = dGridFlags.Rows(intRow).Cells(2).Value.ToString
            Else
                strSelectedValue = ""
            End If
            If Not (Object.Equals(Convert.ToString(dGridFlags.CurrentRow.Cells(0).Value), "")) Then
                intSelectedTransaction = Convert.ToString(dGridFlags.CurrentRow.Cells(0).Value)
                Dim f As New frmEmployeeFlagOptions
                f.ShowDialog()
                dGridFlags.CurrentRow.Cells(2).Value = strSelectedValue
            End If
        End If
    End Sub

    Private Sub dGridDates_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridDates.CellClick
        If dGridDates.CurrentCell.ColumnIndex = 3 Then
            Dim intRow As Integer = dGridDates.CurrentCell.RowIndex
            If Not dGridDates.CurrentRow.Cells(2).Value = Nothing Then
                strSelectedDate = dGridDates.Rows(intRow).Cells(2).Value.ToString
            Else
                strSelectedDate = ""
            End If
            If Not (Object.Equals(Convert.ToString(dGridDates.CurrentRow.Cells(0).Value), "")) Then
                intSelectedTransaction = Convert.ToString(dGridDates.CurrentRow.Cells(0).Value)
                boolAbort = False
                gwt_comm.DateSpecification()
                If boolAbort = True Then Exit Sub
                dGridDates.CurrentRow.Cells(2).Value = strSelectedDate
            End If
        End If
    End Sub

    Private Sub SaveDates()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeDates WHERE EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
        sqlCommand.ExecuteNonQuery()
        Dim i As Integer = 0
        For i = 0 To dGridDates.Rows.Count - 1
            Dim intOrdinal As Integer = 0
            Dim strDateValue As String = "01-JAN-1900"
            If Not (Object.Equals(Convert.ToString(dGridDates.Rows(i).Cells(0).Value), "")) Then
                If IsNumeric(Convert.ToString(dGridDates.Rows(i).Cells(0).Value)) Then
                    intOrdinal = CInt(Convert.ToString(dGridDates.Rows(i).Cells(0).Value))
                End If
            End If
            If Not (Object.Equals(Convert.ToString(dGridDates.Rows(i).Cells(2).Value), "")) Then
                If IsDate(Convert.ToString(dGridDates.Rows(i).Cells(2).Value)) Then
                    strDateValue = Format(Convert.ToDateTime(dGridDates.Rows(i).Cells(2).Value), "dd-MMM-yyyy")
                End If
            End If
            sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO EmployeeDates (OrdinalNo, DateValue, " _
                & "EmployeeNo) VALUES (" & intOrdinal & ", '" & strDateValue & "', " _
                & "'" & strPublicEmployeeId & "')", cnn)
            sqlCommand.ExecuteNonQuery()
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Work Structure Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnBankingTaxInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBankingTaxInfo.Click
        'Banking information
        Dim arrPrintDetails As New ArrayList
        Dim strLineValues(0 To 3) As String
        strLineValues(0) = UCase(strPublicEmployeeId) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(strSelectedEmployeeLastName) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(2) = UCase(strSelectedEmployeeFirstName) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(strSelectedEmployeeOtherNames) & "|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print the detail header and draw a line after
        strLineValues(0) = "BANK/TAX DETAILS|FN=Ariel;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))


        strLineValues(0) = "<DRAWLINE>|FN=Arial;FS=6;FC=Black;FB=True;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
        strLineValues(1) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print payment method and bank name
        strLineValues(0) = "PAY METHOD |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(cboPaymentMethod.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "BANK|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(lblBankCode.Text & "-" & cboBankCodes.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print Account number
        strLineValues(0) = "ACCOUNT NO. |FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAccountNumber.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "ACCOUNT TYPE|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(cboAccountType.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print account owner
        strLineValues(0) = "ACCOUNT HOLDER|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtAccountOwner.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(3) = "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print tax code, dependents, reference number
        strLineValues(0) = "TAX CODE|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(txtTaxCode.Text & "-" & txtTaxDependents.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "TAX NUMBER|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(txtTaxReference.Text) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Print Directives
        strLineValues(0) = "DIRECTIVE $|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(1) = UCase(Format(CDbl(txtTaxDirectiveAmt.Text), "##0.00")) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0</d>"
        strLineValues(2) = "DIRECTIVE %|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=WhiteSmoke;RH=25;AL=0</d>"
        strLineValues(3) = UCase(Format(CDbl(txtTaxDirectivePercent.Text), "##0.00")) & "|FN=Ariel;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=25;AL=0"
        arrPrintDetails.Add(strLineValues(0) & strLineValues(1) & strLineValues(2) & strLineValues(3))

        'Assign the print data to the print array
        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        GeneralPrint(strPrintDetails, 4, "EC. NO|LAST NAME|FIRST NAME|OTHER NAMES", "100|120|120|310", "YES|YES|YES|YES", "Employee Contact Details", strCompanyName, "EMPLOYEE CONTACT DETAILS", "")

    End Sub

    Private Sub GeneralPrint(ByVal strPrintDetails() As String, ByVal ColumnCount As Int16, ByVal strColumnHeaders As String,
            ByVal strColumnWidths As String, ByVal strColumnVisible As String, ByVal Footer As String, ByVal MainHeader As String,
            ByVal Header2 As String, ByVal Header3 As String)
        On Error GoTo RaiseErr
        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = ColumnCount
            .strColumnHeaders = UCase(strColumnHeaders)
            .strColumnWidths = strColumnWidths
            .strFooterCaption = Footer
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = Header2
            .strMainHeader3 = Header3
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = False
            .VerticalLines = False
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .HeaderFont = New Font("Verdana", 10, FontStyle.Bold)
            .FooterFont = New Font("Verdana", 6, FontStyle.Bold)
            .boolGenericReport = False
            .strPrintValues = strPrintDetails
            .VisibleColumns = strColumnVisible
            .DetailColor = Color.Black
            .DetailFont = fntDetailsFont
        End With
        Cursor = Cursors.Default
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()

        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On employee data print"
    End Sub

    Private Sub btnSplitPayments_Click(sender As System.Object, e As System.EventArgs) Handles btnSplitPayments.Click
        Dim frm As New frmEmployeeSplitBanks
        frm.ShowDialog()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

End Class
