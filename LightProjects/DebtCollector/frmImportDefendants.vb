Imports CommonLibrary.Commons

Public Class frmImportDefendants

    Dim boolUpdateCommission As Boolean = False

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        If String.IsNullOrEmpty(cboSourceType.Text) Then
            MessageBox.Show("Please select the file source type", "Missing Source Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSourceType.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtSourceFile.Text) Then
            MessageBox.Show("Please browse the file source file", "Missing Source File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnBrowse.Focus()
            Exit Sub
        End If
        If UCase(cboSourceType.Text) = "Excel" Then
            LoadExcelFile()
        Else
            If String.IsNullOrEmpty(txtDelimiter.Text) Then
                MessageBox.Show("Please type in the text file record delimiter", "Missing Delimiter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtDelimiter.Focus()
                Exit Sub
            Else
                SuperTabControl1.SelectedTabIndex = 1
                SuperTabControl1.Tabs(1).Focus()
                LoadTextFile()
            End If
        End If
    End Sub

    Private Sub LoadExcelFile()

    End Sub

    Private Sub LoadTextFile()
        On Error GoTo RaiseErr
        Dim objFile As New System.IO.StreamReader(txtSourceFile.Text)
        Dim strData As String = objFile.ReadToEnd
        objFile.Close()
        Dim strLines() As String = Split(strData, vbCrLf)
        Dim intStart As Integer = 0

        Dim myGrid As New ComponentFactory.Krypton.Toolkit.KryptonDataGridView
        Select Case SuperTabControl2.SelectedTabIndex
            Case Is = 0
                myGrid = dGrid
            Case Is = 1
                myGrid = dGridStatus
            Case Is = 2
                myGrid = dGridPrincipal
            Case Is = 3
                myGrid = dGridTransactions
            Case Is = 4
                myGrid = dgridAddress
            Case Is = 5
                myGrid = dGridSwitch
        End Select

        myGrid.Columns.Clear()

        Cursor = Cursors.WaitCursor

        If chkFirstRowHeader.Checked = True Then
            Dim strHeaders() As String = Split(strLines(0), txtDelimiter.Text)
            For i As Integer = 0 To strHeaders.Length - 1
                With myGrid
                    .Columns.Add("Column" & i + 1, strHeaders(i))
                End With
            Next
            intStart = 1
        Else
            Dim strHeaders() As String = Split(strLines(0), txtDelimiter.Text)
            For i As Integer = 0 To strHeaders.Length - 1
                With myGrid
                    .Columns.Add("Column" & i + 1, "Column" & i + 1)
                End With
            Next
        End If

        For p As Integer = intStart To strLines.Length - 2
            Dim strFields() As String = Split(strLines(p), txtDelimiter.Text)
            myGrid.Rows.Add(1)
            For i As Integer = 0 To strFields.Length - 1
                With myGrid
                    .Rows(.Rows.Count - 1).Cells(i).Value = strFields(i)
                End With
            Next
        Next

        For i As Integer = 0 To myGrid.Columns.Count - 1
            myGrid.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Data Import"
        ShowErrorMessage()
    End Sub

    Private Sub btnProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceed.Click
        On Error GoTo RaiseErr
        boolUpdateCommission = False
        If String.IsNullOrEmpty(lblClientId.Text) Then
            MessageBox.Show("Please select the client to import details for", "Missing Client Id", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClients.Focus()
            Exit Sub
        End If

        With pb1
            .Value = 0
            Select Case SuperTabControl2.SelectedTabIndex
                Case Is = 0
                    .Maximum = dGrid.Rows.Count + 3
                Case Is = 1
                    boolAbort = True
                    Dim f As New frmBrowseStage
                    f.ShowDialog()
                    If boolAbort = True Then Exit Sub
                    .Maximum = dGridStatus.Rows.Count + 3
                Case Is = 2
                    .Maximum = dGridPrincipal.Rows.Count + 3
                Case Is = 3
                    .Maximum = dGridTransactions.Rows.Count + 1
                Case Is = 4
                    .Maximum = dgridAddress.Rows.Count + 1
                Case Is = 5
                    .Maximum = dGridSwitch.Rows.Count + 1
            End Select
            .Visible = True
        End With

        Cursor = Cursors.WaitCursor

        Dim dblAmount As Double = 0
        Dim strAccountNo As String = Nothing

        Select Case SuperTabControl2.SelectedTabIndex

            Case Is = 0
                With dGrid

                    If MessageBox.Show("Do you want to have commission updated automatically", "Confirm Commission Auto Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        boolUpdateCommission = True
                    End If

                    For i As Integer = 0 To .Rows.Count - 1
                        'File|Account|Name|Address|Amount|Cellphone|LocationArea|Comments
                        Dim strFileNo As String = Nothing
                        strAccountNo = Nothing
                        Dim strGivenNames As String = Nothing
                        Dim strAddress1 As String = Nothing
                        Dim strAddress2 As String = Nothing
                        Dim strAddress3 As String = Nothing
                        Dim strAddress4 As String = Nothing
                        dblAmount = 0
                        Dim strCellphoneNo As String = Nothing
                        Dim strPlaintif As String = lblClientId.Text
                        Dim strLocationArea As String = Nothing
                        Dim strComments As String = Nothing
                        Dim strCaseNumber As String = Nothing

                        If .ColumnCount > 0 Then
                            If Not Object.Equals(.Rows(i).Cells(0).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(0).Value.ToString) Then
                                    strFileNo = Trim(.Rows(i).Cells(0).Value)
                                End If
                            End If
                        End If

                        If .ColumnCount > 1 Then
                            If Not Object.Equals(.Rows(i).Cells(1).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(1).Value.ToString) Then
                                    strCaseNumber = Trim(.Rows(i).Cells(1).Value)
                                End If
                            End If
                        End If

                        If .ColumnCount > 2 Then
                            If Not Object.Equals(.Rows(i).Cells(2).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(2).Value.ToString) Then
                                    strAccountNo = Trim(.Rows(i).Cells(2).Value)
                                End If
                            End If
                        End If

                        If .ColumnCount > 3 Then
                            If Not Object.Equals(.Rows(i).Cells(3).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(3).Value.ToString) Then
                                    strGivenNames = Trim(.Rows(i).Cells(3).Value)
                                End If
                            End If
                        End If

                        If .ColumnCount > 4 Then
                            If Not Object.Equals(.Rows(i).Cells(4).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(4).Value.ToString) Then
                                    strAddress1 = Trim(.Rows(i).Cells(4).Value)
                                End If
                            End If
                        End If

                        If .ColumnCount > 5 Then
                            If Not Object.Equals(.Rows(i).Cells(5).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(5).Value.ToString) Then
                                    strAddress2 = Trim(.Rows(i).Cells(5).Value)
                                End If
                            End If
                        End If

                        If .ColumnCount > 6 Then
                            If Not Object.Equals(.Rows(i).Cells(6).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(6).Value.ToString) Then
                                    strAddress3 = Trim(.Rows(i).Cells(6).Value)
                                End If
                            End If
                        End If

                        If .ColumnCount > 7 Then
                            If Not Object.Equals(.Rows(i).Cells(7).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(7).Value.ToString) Then
                                    strAddress4 = Trim(.Rows(i).Cells(7).Value)
                                End If
                            End If
                        End If

                        If .ColumnCount > 8 Then
                            If Not Object.Equals(.Rows(i).Cells(8).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(8).Value.ToString) Then
                                    If IsNumeric(.Rows(i).Cells(8).Value.ToString) Then dblAmount = CDbl(.Rows(i).Cells(8).Value)
                                End If
                            End If
                        End If

                        If .ColumnCount > 9 Then
                            If Not Object.Equals(.Rows(i).Cells(9).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(9).Value.ToString) Then
                                    strCellphoneNo = "0" & Trim(.Rows(i).Cells(9).Value)
                                End If
                            End If
                        End If

                        If .ColumnCount > 10 Then
                            If Not Object.Equals(.Rows(i).Cells(10).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(10).Value.ToString) Then
                                    strLocationArea = .Rows(i).Cells(10).Value.ToString
                                End If
                            End If
                        End If

                        If .ColumnCount > 11 Then
                            If Not Object.Equals(.Rows(i).Cells(11).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(11).Value.ToString) Then
                                    strComments = .Rows(i).Cells(11).Value.ToString
                                End If
                            End If
                        End If

                        If Not String.IsNullOrEmpty(strAccountNo) Then

                            Dim objCommand As Data.OleDb.OleDbCommand
                            Dim objFileWriter As System.IO.StreamWriter

                            If gwt_comm.CheckLegalRecordExistence(strAccountNo, "DEFENDANTS") = True Then
                                If chkDuplicates.Checked = True Then
                                    If gwt_comm.CheckLegalFileExistence(strFileNo, "DEFENDANTS") = False Then
                                        '
                                        '**** APPENDED RECORD IF **********************

                                        strAccountNo = strAccountNo & "-" & strFileNo

                                        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO Defendants " _
                                            & "(DefendantId, GivenNames, PrimaryAddress1, PrimaryAddress2, PrimaryAddress3, PrimaryAddress4, Cellphone, PlaintifId, " _
                                            & "ClientType, Status, FileId, LocationArea, CaseNumber) VALUES " _
                                            & "('" & strAccountNo & "', '" & strGivenNames & "', '" & strAddress1 & "', '" & strAddress2 & "', '" & strAddress3 & "', '" & strAddress4 & "', " _
                                            & "'" & strCellphoneNo & "', '" & strPlaintif & "', 'INDIVIDUAL', 'ACTIVE', " _
                                            & "'" & strFileNo & "', '" & strLocationArea & "', '" & strCaseNumber & "')", cnn)
                                        objCommand.ExecuteNonQuery()

                                        'Update the notes as well
                                        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO DefendantNotes (DefendantId, Notes) " _
                                            & "VALUES ('" & strAccountNo & "', '" & strComments & "')", cnn)
                                        objCommand.ExecuteNonQuery()

                                        'Insert the principal amount based on the action date
                                        Dim strDefendantIdNumber As String = DefendantIdFromFileNumber(strFileNo)

                                        Dim strEntryDescription As String = "PRINCIPAL DEBT"

                                        If Not String.IsNullOrEmpty(strDefendantIdNumber) Then
                                            strAccountNo = strDefendantIdNumber
                                            If gwt_comm.CheckLegalRecordExistence(strAccountNo, "DEFENDANTS") = True Then
                                                If dblAmount <> 0 Then
                                                    If dblAmount >= 0 Then
                                                        InitializeTransactions("DEFENDANTS", strAccountNo, Format(dpStarting.Value, "dd-MMM-yyyy"), dblAmount, 0, _
                                                            strEntryDescription, "IMPORTED TRANSACTIONS FROM EXCEL SOURCE")
                                                    Else
                                                        InitializeTransactions("DEFENDANTS", strAccountNo, Format(dpStarting.Value, "dd-MMM-yyyy"), 0, dblAmount, _
                                                            strEntryDescription, "IMPORTED TRANSACTIONS FROM EXCEL SOURCE")
                                                    End If
                                                    If boolUpdateCommission = True Then
                                                        strEntryDescription = "COMMISSION"
                                                        Dim dblCommission As Double = dblAmount * 0.1
                                                        InitializeTransactions("DEFENDANTS", strAccountNo, Format(dpStarting.Value, "dd-MMM-yyyy"), dblCommission, 0, _
                                                            strEntryDescription, "IMPORTED TRANSACTIONS FROM EXCEL SOURCE")
                                                    End If
                                                End If
                                            End If
                                        End If

                                    Else
                                        objFileWriter = New System.IO.StreamWriter(Application.StartupPath & "\Duplicates.txt", True)
                                        objFileWriter.WriteLine(strAccountNo & "', '" & strGivenNames & "', '" & strAddress1 & "', " _
                                            & "'" & strCellphoneNo & "-" & strPlaintif & "-" & strFileNo & "-" & strLocationArea & "-" & strCaseNumber)
                                        objFileWriter.Close()
                                    End If

                                    '**********************************************
                                    '
                                Else
                                    objFileWriter = New System.IO.StreamWriter(Application.StartupPath & "\Duplicates.txt", True)
                                    objFileWriter.WriteLine(strAccountNo & "', '" & strGivenNames & "', '" & strAddress1 & "', " _
                                        & "'" & strCellphoneNo & "-" & strPlaintif & "-" & strFileNo & "-" & strLocationArea & "-" & strCaseNumber)
                                    objFileWriter.Close()
                                End If

                            Else

                                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO Defendants " _
                                    & "(DefendantId, GivenNames, PrimaryAddress1, PrimaryAddress2, PrimaryAddress3, PrimaryAddress4, Cellphone, PlaintifId, " _
                                    & "ClientType, Status, FileId, LocationArea, CaseNumber) VALUES " _
                                    & "('" & strAccountNo & "', '" & strGivenNames & "', '" & strAddress1 & "', '" & strAddress2 & "', '" & strAddress3 & "', '" & strAddress4 & "', " _
                                    & "'" & strCellphoneNo & "', '" & strPlaintif & "', 'INDIVIDUAL', 'ACTIVE', " _
                                    & "'" & strFileNo & "', '" & strLocationArea & "', '" & strCaseNumber & "')", cnn)
                                objCommand.ExecuteNonQuery()

                                'Update the notes as well
                                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO DefendantNotes (DefendantId, Notes) " _
                                    & "VALUES ('" & strAccountNo & "', '" & strComments & "')", cnn)
                                objCommand.ExecuteNonQuery()

                                'Insert the principal amount based on the action date
                                Dim strDefendantIdNumber As String = DefendantIdFromFileNumber(strFileNo)

                                Dim strEntryDescription As String = "PRINCIPAL DEBT"

                                If Not String.IsNullOrEmpty(strDefendantIdNumber) Then
                                    strAccountNo = strDefendantIdNumber
                                    If gwt_comm.CheckLegalRecordExistence(strAccountNo, "DEFENDANTS") = True Then
                                        If dblAmount <> 0 Then
                                            If dblAmount >= 0 Then
                                                InitializeTransactions("DEFENDANTS", strAccountNo, Format(dpStarting.Value, "dd-MMM-yyyy"), dblAmount, 0, _
                                                    strEntryDescription, "IMPORTED TRANSACTIONS FROM EXCEL SOURCE")
                                                objCommand = New Data.OleDb.OleDbCommand("UPDATE Defendants SET PrincipalDebt = " & dblAmount & " " _
                                                     & "WHERE DefendantId = '" & strDefendantIdNumber & "'", cnn)
                                                objCommand.ExecuteNonQuery()
                                            Else
                                                InitializeTransactions("DEFENDANTS", strAccountNo, Format(dpStarting.Value, "dd-MMM-yyyy"), 0, dblAmount, _
                                                    strEntryDescription, "IMPORTED TRANSACTIONS FROM EXCEL SOURCE")
                                            End If

                                            If boolUpdateCommission = True Then
                                                strEntryDescription = "COMMISSION"
                                                Dim dblCommission As Double = dblAmount * 0.1
                                                InitializeTransactions("DEFENDANTS", strAccountNo, Format(dpStarting.Value, "dd-MMM-yyyy"), dblCommission, 0, _
                                                    strEntryDescription, "IMPORTED TRANSACTIONS FROM EXCEL SOURCE")
                                            End If
                                        End If
                                    End If
                                End If

                            End If

                        End If

                        pb1.Value = pb1.Value + 1
                    Next
                    pb1.Value = pb1.Maximum
                    MessageBox.Show(.Rows.Count & " Record imported successfully", _
                        "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End With

            Case Is = 1

                With dGridStatus
                    For i As Integer = 0 To .Rows.Count - 1
                        Dim strStatus As String = Nothing

                        strAccountNo = Nothing
                        Dim strFileNumber As String = Nothing

                        If Not Object.Equals(.Rows(i).Cells(0).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.Rows(i).Cells(0).Value.ToString) Then
                                strFileNumber = .Rows(i).Cells(0).Value.ToString
                            End If
                        End If

                        'If Not Object.Equals(.Rows(i).Cells(1).Value, Nothing) Then
                        '    If Not String.IsNullOrEmpty(.Rows(i).Cells(1).Value.ToString) Then
                        '        strAccountNo = .Rows(i).Cells(1).Value.ToString
                        '    End If
                        'End If

                        Dim ActionDate As Date = CDate(Format(dpStarting.Value, "dd-MMM-yyyy"))
                        For n As Integer = 1 To .Columns.Count - 1
                            strStatus = Nothing
                            If Not Object.Equals(.Rows(i).Cells(n).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(n).Value.ToString) Then
                                    If .Rows(i).Cells(n).Value.ToString = "1" Then
                                        strStatus = .Columns(n).HeaderText.ToString
                                    End If
                                End If
                            End If
                            If Not String.IsNullOrEmpty(strStatus) Then
                                Dim strDefendantIdNumber As String = DefendantIdFromFileNumber(strFileNumber)
                                If Not String.IsNullOrEmpty(strDefendantIdNumber) Then
                                    If gwt_comm.CheckLegalRecordExistence(strDefendantIdNumber, "DEFENDANTS") = True Then
                                        strAccountNo = strDefendantIdNumber
                                        Dim strSql As String = "INSERT INTO LegalActions (DefendantId, ProcedureName, " _
                                            & "ActionTaken, ActionDate, Comments, TransactionDate, UserName, PlaintifId) VALUES " _
                                            & "('" & strAccountNo & "', '" & strPublicSelectedProcedureName & "', " _
                                            & "'" & strStatus & "', '" & CDate(Format(ActionDate, "dd-MMM-yyyy")) & "', " _
                                            & "'TAKE ON DATA IMPORT', '" & Now & "', '" & strUserName & "', '" & lblClientId.Text & "')"
                                        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                                        objCommand.ExecuteNonQuery()
                                    End If
                                End If
                            End If
                            ActionDate = DateAdd(DateInterval.Day, 8, ActionDate)
                        Next

                        pb1.Value = pb1.Value + 1
                    Next
                    pb1.Value = pb1.Maximum
                    MessageBox.Show(.Rows.Count & " Record imported successfully", _
                        "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End With
            Case Is = 2

                'Import capital amounts
                'Update the transaction table as well
                'CheckLegalRecordExistence
                With dGridPrincipal
                    For i As Integer = 0 To .Rows.Count - 1
                        strAccountNo = Nothing
                        Dim strFileNumber As String = Nothing

                        If Not Object.Equals(.Rows(i).Cells(0).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.Rows(i).Cells(0).Value.ToString) Then
                                strFileNumber = .Rows(i).Cells(0).Value.ToString
                            End If
                        End If

                        Dim strDefendantIdNumber As String = DefendantIdFromFileNumber(strFileNumber)

                        For n As Integer = 1 To .Columns.Count - 1
                            dblAmount = 0
                            Dim strEntryDescription As String = .Columns(n).HeaderText.ToString
                            If Not Object.Equals(.Rows(i).Cells(n).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(n).Value.ToString) Then
                                    If IsNumeric(.Rows(i).Cells(n).Value.ToString) Then dblAmount = CDbl(.Rows(i).Cells(n).Value.ToString)
                                End If
                            End If
                            If Not String.IsNullOrEmpty(strDefendantIdNumber) Then
                                strAccountNo = strDefendantIdNumber
                                If gwt_comm.CheckLegalRecordExistence(strAccountNo, "DEFENDANTS") = True Then
                                    If dblAmount <> 0 Then
                                        If dblAmount >= 0 Then
                                            InitializeTransactions("DEFENDANTS", strAccountNo, Format(dpStarting.Value, "dd-MMM-yyyy"), dblAmount, 0, _
                                                strEntryDescription, "IMPORTED TRANSACTIONS FROM EXCEL SOURCE")
                                        Else
                                            InitializeTransactions("DEFENDANTS", strAccountNo, Format(dpStarting.Value, "dd-MMM-yyyy"), 0, dblAmount, _
                                                strEntryDescription, "IMPORTED TRANSACTIONS FROM EXCEL SOURCE")
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        pb1.Value = pb1.Value + 1
                    Next
                    pb1.Value = pb1.Maximum
                    MessageBox.Show(.Rows.Count & " Record imported successfully", _
                        "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End With

            Case Is = 3

                With dGridTransactions
                    For i As Integer = 0 To .Rows.Count - 1
                        strAccountNo = Nothing

                        Dim strTransDate As String = Nothing
                        Dim strFileNo As String = Nothing

                        If Not Object.Equals(.Rows(i).Cells(0).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.Rows(i).Cells(0).Value.ToString) Then
                                strFileNo = .Rows(i).Cells(0).Value.ToString
                            End If
                        End If

                        If Not Object.Equals(.Rows(i).Cells(1).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.Rows(i).Cells(1).Value.ToString) Then
                                strTransDate = .Rows(i).Cells(1).Value.ToString
                            End If
                        End If

                        For z As Integer = 2 To .ColumnCount - 1
                            dblAmount = 0
                            Dim strEntryDescription As String = .Columns(z).HeaderText.ToString
                            If Not Object.Equals(.Rows(i).Cells(z).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(.Rows(i).Cells(z).Value.ToString) Then
                                    If IsNumeric(.Rows(i).Cells(z).Value.ToString) Then dblAmount = CDbl(.Rows(i).Cells(z).Value.ToString)
                                End If
                            End If

                            Dim strDefendantIdNumber As String = DefendantIdFromFileNumber(strFileNo)

                            If gwt_comm.CheckLegalRecordExistence(strDefendantIdNumber, "DEFENDANTS") = True Then
                                If IsDate(strTransDate) Then
                                    If dblAmount <> 0 Then
                                        If UCase(cboTransType.Text) = "DEBIT" Then
                                            InitializeTransactions("DEFENDANTS", strDefendantIdNumber, Format(CDate(strTransDate), "dd-MMM-yyyy"), dblAmount, 0,
                                                strEntryDescription, "IMPORTED TRANSACTIONS FROM EXCEL SOURCE")
                                        Else
                                            InitializeTransactions("DEFENDANTS", strDefendantIdNumber, Format(CDate(strTransDate), "dd-MMM-yyyy"), 0, dblAmount,
                                                strEntryDescription, "IMPORTED TRANSACTIONS FROM EXCEL SOURCE")
                                        End If
                                    End If
                                End If
                            End If
                        Next

                        pb1.Value = pb1.Value + 1
                    Next
                    pb1.Value = pb1.Maximum
                    MessageBox.Show(.Rows.Count & " Record imported successfully", _
                        "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End With


            Case Is = 4

                With dgridAddress
                    For i As Integer = 0 To .Rows.Count - 1
                        Dim strFileNumber As String = Nothing
                        Dim strAddress1 As String = Nothing
                        Dim strAddress2 As String = Nothing
                        Dim strAddress3 As String = Nothing
                        Dim strAddress4 As String = Nothing

                        If Not Object.Equals(.Rows(i).Cells(0).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.Rows(i).Cells(0).Value.ToString) Then
                                strFileNumber = .Rows(i).Cells(0).Value.ToString
                            End If
                        End If

                        If Not Object.Equals(.Rows(i).Cells(1).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.Rows(i).Cells(1).Value.ToString) Then
                                strAddress1 = .Rows(i).Cells(1).Value.ToString
                            End If
                        End If

                        If Not Object.Equals(.Rows(i).Cells(2).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.Rows(i).Cells(2).Value.ToString) Then
                                strAddress2 = .Rows(i).Cells(2).Value.ToString
                            End If
                        End If

                        If Not Object.Equals(.Rows(i).Cells(3).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.Rows(i).Cells(3).Value.ToString) Then
                                strAddress3 = .Rows(i).Cells(3).Value.ToString
                            End If
                        End If

                        If Not Object.Equals(.Rows(i).Cells(4).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.Rows(i).Cells(4).Value.ToString) Then
                                strAddress4 = .Rows(i).Cells(4).Value.ToString
                            End If
                        End If

                        Dim strSql As String = "UPDATE Defendants SET PrimaryAddress1 = '" & strAddress1 & "', " _
                            & "PrimaryAddress2 = '" & strAddress2 & "', PrimaryAddress3 = '" & strAddress3 & "', " _
                            & "PrimaryAddress4 = '" & strAddress4 & "' WHERE DefendantId = '" & strFileNumber & "'"
                        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()

                        pb1.Value = pb1.Value + 1

                    Next

                    pb1.Value = pb1.Maximum
                    MessageBox.Show(.Rows.Count & " Record imported successfully", _
                        "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End With

            Case Is = 5

                With dGridSwitch
                    For i As Integer = 0 To .Rows.Count - 1
                        Dim strFileNumber As String = Nothing
                        If Not Object.Equals(.Rows(i).Cells(0).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.Rows(i).Cells(0).Value.ToString) Then
                                strFileNumber = .Rows(i).Cells(0).Value.ToString
                            End If
                        End If

                        Dim strSql As String = "UPDATE Defendants SET PlaintifId = '" & lblClientId.Text & "' " _
                            & "WHERE FileId = '" & strFileNumber & "'"
                        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()

                        Dim strDefendantIdNumber As String = DefendantIdFromFileNumber(strFileNumber)

                        strSql = "UPDATE LegalActions SET PlaintifId = '" & lblClientId.Text & "' " _
                            & "WHERE DefendantId = '" & strDefendantIdNumber & "'"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()

                        pb1.Value = pb1.Value + 1

                    Next

                    pb1.Value = pb1.Maximum
                    MessageBox.Show(.Rows.Count & " Record imported successfully", _
                        "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End With

        End Select
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Data Import"
        ShowErrorMessage()
    End Sub

    Private Function DefendantIdFromFileNumber(FileNumber As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        strSql = "SELECT DefendantId FROM Defendants " _
                        & "WHERE FileId = '" & FileNumber & "'"

        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objCheckEmployee As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objCheckEmployee.HasRows Then
            objCheckEmployee.Read()
            If Not IsDBNull(objCheckEmployee(0).ToString) Then strReturn = objCheckEmployee(0).ToString
        End If
        objCheckEmployee.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Record Validation"
        ShowErrorMessage()
    End Function

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        txtSourceFile.Text = ofd.FileName
    End Sub

    Private Sub btnUpDateStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpDateStatus.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT DefendantId, PlaintifId FROM Defendants ORDER BY DefendantId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        objCommand = New Data.OleDb.OleDbCommand("SELECT Count(DefendantId) FROM Defendants", cnn)
        Dim objReadCount As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim intCount As Integer = 0
        If objReadCount.HasRows Then
            objReadCount.Read()
            If IsNumeric(objReadCount(0).ToString) Then intCount = CInt(objReadCount(0).ToString)
        End If
        objReadCount.Close()

        With pb1
            .Value = 0
            .Visible = True
            .Maximum = intCount + 5
        End With

        While objReader.Read
            objCommand = New Data.OleDb.OleDbCommand("UPDATE LegalActions SET Status = 'PAST' " _
                & "WHERE DefendantId = '" & objReader(0).ToString & "'", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("SELECT ActionDate, TransactionId " _
                & "FROM LegalActions WHERE DefendantId = '" & objReader(0).ToString & "' ORDER BY TransactionDate DESC", cnn)
            Dim objReadDates As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReadDates.HasRows Then
                objReadDates.Read()
                objCommand = New Data.OleDb.OleDbCommand("UPDATE LegalActions SET Status = 'CURRENT' " _
                    & "WHERE TransactionId = " & objReadDates(1).ToString & "", cnn)
                objCommand.ExecuteNonQuery()
                'Update plaintifid
                objCommand = New Data.OleDb.OleDbCommand("UPDATE LegalActions SET PlaintifId = '" & objReader(1).ToString & "' " _
                    & "WHERE DefendantId = '" & objReader(0).ToString & "'", cnn)
                objCommand.ExecuteNonQuery()
            End If
            objReadDates.Close()
            'If Not IsDBNull(objReader(0).ToString) Then
            '    objCommand = New Data.OleDb.OleDbCommand("SELECT * FROM LegalActions WHERE " _
            '        & "DefendantId = '" & objReader(0).ToString & "' ORDER BY ActionDate DESC", cnn)
            '    Dim objReadImports As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            '    If objReadImports.HasRows Then
            '        objReadImports.Read()
            '        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO CurrentLegalActions " _
            '            & "(ActionTaken, ProcedureName, ActionDate, DefendantId) " _
            '            & "VALUES ('" & objReadImports("ActionTaken").ToString & "', " _
            '            & "'" & objReadImports("ProcedureName").ToString & "', " _
            '            & "'" & objReadImports("ActionDate").ToString & "', '" & objReader(0).ToString & "')", cnn)
            '        objCommand.ExecuteNonQuery()
            '    End If
            '    objReadImports.Close()
            'End If
            pb1.Value = pb1.Value + 1
        End While
        objReader.Close()

        Cursor = Cursors.Default
        MessageBox.Show("Records updated successfully", _
                        "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Data Import"
        ShowErrorMessage()
    End Sub

    Private Sub LoadClients()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT GivenNames +'|'+ PlaintifID AS " _
            & "[Details] FROM Plaintifs ORDER BY GivenNames", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrData As New ArrayList

        'add the first item of the array data
        arrData.Add("--ALL--|0")
        'Add the rest from the database
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboClients.Width - 80

        'Add the items to the drop down box
        With cboClients
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth1 & ";80"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = arrData.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboClients.Items.Clear()
        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboClients
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Client Names Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClients.SelectedIndexChanged
        If Not cboClients.SelectedItem Is Nothing Then
            lblClientId.Text = cboClients.SelectedItem.Col2
        Else
            lblClientId.Text = "0"
        End If
    End Sub

    Private Sub frmImportDefendants_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadClients()
    End Sub

End Class