Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmEmployeeSplitBanks

    Private Sub btnAbort_Click(sender As System.Object, e As System.EventArgs) Handles btnAbort.Click
        Me.Close()
    End Sub

    Private Sub LoadBanks()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT BankCode +';'+BankName AS [Banking] FROM SystemBanks ORDER BY BankName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        Dim intWidth As Integer = cboSplitPayCode1.Width
        With cboSplitPayCode1
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "60;200"
        End With
        With cboSplitPayCode2
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "60;200"
        End With
        With cboSplitPayCode3
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "60;200"
        End With
        With cboSplitPayCode4
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "60;200"
        End With
        With cboSplitPayCode5
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "60;200"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(BankCode) FROM SystemBanks", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        While objCount.Read
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
            Exit While
        End While
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboSplitPayCode1.Items.Clear()
        cboSplitPayCode2.Items.Clear()
        cboSplitPayCode3.Items.Clear()
        cboSplitPayCode4.Items.Clear()
        cboSplitPayCode5.Items.Clear()

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
            With cboSplitPayCode1
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
            With cboSplitPayCode2
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
            With cboSplitPayCode3
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
            With cboSplitPayCode4
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
            With cboSplitPayCode5
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Bank Information Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmEmployeeSplitBanks_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadBanks()
        LoadSplitPayDescriptions()
        LoadEmployeeSplits()
    End Sub

    Private Sub cboSplitPayCode1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSplitPayCode1.SelectedIndexChanged
        If cboSplitPayCode1.Focused = False Then Exit Sub
        If Not cboSplitPayCode1.SelectedItem Is Nothing Then
            lblSplit1Description.Text = cboSplitPayCode1.SelectedItem.Col2
        Else
            lblSplit1Description.Text = ""
        End If
    End Sub

    Private Sub cboSplitPayCode2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSplitPayCode2.SelectedIndexChanged
        If cboSplitPayCode2.Focused = False Then Exit Sub
        If Not cboSplitPayCode2.SelectedItem Is Nothing Then
            lblSplit2Description.Text = cboSplitPayCode2.SelectedItem.Col2
        Else
            lblSplit2Description.Text = ""
        End If
    End Sub

    Private Sub cboSplitPayCode3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSplitPayCode3.SelectedIndexChanged
        If cboSplitPayCode3.Focused = False Then Exit Sub
        If Not cboSplitPayCode3.SelectedItem Is Nothing Then
            lblSplit3Description.Text = cboSplitPayCode3.SelectedItem.Col2
        Else
            lblSplit3Description.Text = ""
        End If
    End Sub

    Private Sub cboSplitPayCode4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSplitPayCode4.SelectedIndexChanged
        If cboSplitPayCode4.Focused = False Then Exit Sub
        If Not cboSplitPayCode4.SelectedItem Is Nothing Then
            lblSplit4Description.Text = cboSplitPayCode4.SelectedItem.Col2
        Else
            lblSplit4Description.Text = ""
        End If
    End Sub

    Private Sub cboSplitPayCode5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSplitPayCode5.SelectedIndexChanged
        If cboSplitPayCode5.Focused = False Then Exit Sub
        If Not cboSplitPayCode5.SelectedItem Is Nothing Then
            lblSplit5Description.Text = cboSplitPayCode5.SelectedItem.Col2
        Else
            lblSplit5Description.Text = ""
        End If
    End Sub

    Private Sub LoadSplitPayDescriptions()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT SplitCodeParameters.CodeNo, SystemCodes.Description " _
            & "FROM SplitCodeParameters LEFT OUTER JOIN SystemCodes ON " _
            & "SystemCodes.CodeNo = SplitCodeParameters.CodeNo ORDER BY SystemCodes.CodeNo"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        Dim i As Integer = 0
        While objReader.Read
            If i >= 5 Then Exit While
            Select Case i
                Case Is = 0
                    If Not IsDBNull(objReader(1).ToString) Then lblSplitOne.Text = objReader(1).ToString
                    If Not IsDBNull(objReader(0).ToString) Then lblCode1.Text = objReader(0).ToString
                Case Is = 1
                    If Not IsDBNull(objReader(1).ToString) Then lblSplitTwo.Text = objReader(1).ToString
                    If Not IsDBNull(objReader(0).ToString) Then lblCode2.Text = objReader(0).ToString
                Case Is = 2
                    If Not IsDBNull(objReader(1).ToString) Then lblSplitThree.Text = objReader(1).ToString
                    If Not IsDBNull(objReader(0).ToString) Then lblCode3.Text = objReader(0).ToString
                Case Is = 3
                    If Not IsDBNull(objReader(1).ToString) Then lblSplitFour.Text = objReader(1).ToString
                    If Not IsDBNull(objReader(0).ToString) Then lblCode4.Text = objReader(0).ToString
                Case Is = 4
                    If Not IsDBNull(objReader(1).ToString) Then lblSplitFive.Text = objReader(1).ToString
                    If Not IsDBNull(objReader(0).ToString) Then lblCode5.Text = objReader(0).ToString
            End Select
            i = i + 1
        End While
        objReader.Close()

        If String.IsNullOrEmpty(lblSplitOne.Text) Then
            cboSplitPayCode1.Enabled = False
            txtSplitAccount1.Enabled = False
        Else
            cboSplitPayCode1.Enabled = True
            txtSplitAccount1.Enabled = True
        End If

        If String.IsNullOrEmpty(lblSplitTwo.Text) Then
            cboSplitPayCode2.Enabled = False
            txtSplitAccount2.Enabled = False
        Else
            cboSplitPayCode2.Enabled = True
            txtSplitAccount2.Enabled = True
        End If

        If String.IsNullOrEmpty(lblSplitThree.Text) Then
            cboSplitPayCode3.Enabled = False
            txtSplitAccount3.Enabled = False
        Else
            cboSplitPayCode3.Enabled = True
            txtSplitAccount3.Enabled = True
        End If

        If String.IsNullOrEmpty(lblSplitFour.Text) Then
            cboSplitPayCode4.Enabled = False
            txtSplitAccount4.Enabled = False
        Else
            cboSplitPayCode4.Enabled = True
            txtSplitAccount4.Enabled = True
        End If

        If String.IsNullOrEmpty(lblSplitFive.Text) Then
            cboSplitPayCode5.Enabled = False
            txtSplitAccount5.Enabled = False
        Else
            cboSplitPayCode5.Enabled = True
            txtSplitAccount5.Enabled = True
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Bank Information Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim arrSqlCommands As New ArrayList
        Dim sqlCommand As Data.OleDb.OleDbCommand
        If Not String.IsNullOrEmpty(txtSplitAccount1.Text) Then
            If Not String.IsNullOrEmpty(cboSplitPayCode1.Text) Then
                arrSqlCommands.Add("INSERT INTO EmployeeSplitPayments (EmployeeNo, BankCode, AccountNumber, CodeNo) " _
                    & "VALUES ('" & strPublicEmployeeId & "', '" & cboSplitPayCode1.Text & "', '" & txtSplitAccount1.Text & "', '" & lblCode1.Text & "')")
            End If
        End If

        If Not String.IsNullOrEmpty(txtSplitAccount2.Text) Then
            If Not String.IsNullOrEmpty(cboSplitPayCode2.Text) Then
                arrSqlCommands.Add("INSERT INTO EmployeeSplitPayments (EmployeeNo, BankCode, AccountNumber, CodeNo) " _
                    & "VALUES ('" & strPublicEmployeeId & "', '" & cboSplitPayCode2.Text & "', '" & txtSplitAccount2.Text & "', '" & lblCode2.Text & "')")
            End If
        End If

        If Not String.IsNullOrEmpty(txtSplitAccount3.Text) Then
            If Not String.IsNullOrEmpty(cboSplitPayCode3.Text) Then
                arrSqlCommands.Add("INSERT INTO EmployeeSplitPayments (EmployeeNo, BankCode, AccountNumber, CodeNo) " _
                    & "VALUES ('" & strPublicEmployeeId & "', '" & cboSplitPayCode3.Text & "', '" & txtSplitAccount3.Text & "', '" & lblCode3.Text & "')")
            End If
        End If

        If Not String.IsNullOrEmpty(txtSplitAccount4.Text) Then
            If Not String.IsNullOrEmpty(cboSplitPayCode4.Text) Then
                arrSqlCommands.Add("INSERT INTO EmployeeSplitPayments (EmployeeNo, BankCode, AccountNumber, CodeNo) " _
                    & "VALUES ('" & strPublicEmployeeId & "', '" & cboSplitPayCode4.Text & "', '" & txtSplitAccount4.Text & "', '" & lblCode4.Text & "')")
            End If
        End If

        If Not String.IsNullOrEmpty(txtSplitAccount5.Text) Then
            If Not String.IsNullOrEmpty(cboSplitPayCode5.Text) Then
                arrSqlCommands.Add("INSERT INTO EmployeeSplitPayments (EmployeeNo, BankCode, AccountNumber, CodeNo) " _
                    & "VALUES ('" & strPublicEmployeeId & "', '" & cboSplitPayCode5.Text & "', '" & txtSplitAccount5.Text & "', '" & lblCode5.Text & "')")
            End If
        End If

        If arrSqlCommands.Count > 0 Then
            sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM EmployeeSplitPayments WHERE EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
            sqlCommand.ExecuteNonQuery()
            For p As Integer = 0 To arrSqlCommands.Count - 1
                sqlCommand = New Data.OleDb.OleDbCommand(arrSqlCommands.Item(p), cnn)
                sqlCommand.ExecuteNonQuery()
            Next
        End If

        KryptonMessageBox.Show("Details Saved Successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on Bank Information Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadEmployeeSplits()
        On Error GoTo RaiseErr
        Dim sqlCommand = New Data.OleDb.OleDbCommand("SELECT EmployeeSplitPayments.BankCode, " _
            & "SystemBanks.BankName, EmployeeSplitPayments.AccountNumber FROM EmployeeSplitPayments " _
            & "LEFT OUTER JOIN SystemBanks ON EmployeeSplitPayments.BankCode = SystemBanks.BankCode " _
            & "WHERE EmployeeSplitPayments.EmployeeNo = '" & strPublicEmployeeId & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        Dim i As Integer = 0
        While objReader.Read
            If i >= 5 Then Exit While
            Select Case i
                Case Is = 0
                    cboSplitPayCode1.Text = objReader(0).ToString
                    lblSplit1Description.Text = objReader(1).ToString
                    txtSplitAccount1.Text = objReader(2).ToString
                Case Is = 1
                    cboSplitPayCode2.Text = objReader(0).ToString
                    lblSplit2Description.Text = objReader(1).ToString
                    txtSplitAccount2.Text = objReader(2).ToString
                Case Is = 2
                    cboSplitPayCode3.Text = objReader(0).ToString
                    lblSplit3Description.Text = objReader(1).ToString
                    txtSplitAccount3.Text = objReader(2).ToString
                Case Is = 3
                    cboSplitPayCode4.Text = objReader(0).ToString
                    lblSplit4Description.Text = objReader(1).ToString
                    txtSplitAccount4.Text = objReader(2).ToString
                Case Is = 4
                    cboSplitPayCode5.Text = objReader(0).ToString
                    lblSplit5Description.Text = objReader(1).ToString
                    txtSplitAccount5.Text = objReader(2).ToString
            End Select
            i = i + 1
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & " on split payments Load"
        ShowErrorMessage()
    End Sub

End Class
