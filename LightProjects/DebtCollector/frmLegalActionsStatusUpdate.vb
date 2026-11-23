Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing

Public Class frmLegalActionsStatusUpdate

    'Times New Roman

    Private fntHeaderFontLocal As New System.Drawing.Font("Times New Roman", 12, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    Private fntDetailsFontLocal As New System.Drawing.Font("Times New Roman", 11, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Private fntFooterFontLocal As New System.Drawing.Font("Times New Roman", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Private fntFooterFontItalicLocal As New System.Drawing.Font("Times New Roman", 11, Drawing.FontStyle.Italic, Drawing.GraphicsUnit.Point)
    Private fntDetailsFontBoldLocal As New System.Drawing.Font("Times New Roman", 11, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Dim strAddress1 As String
    Dim strAddress2 As String
    Dim strAddress3 As String
    Dim strAddress4 As String
    Dim strFileNumber As String
    Dim strPrincipalAmount As String
    Dim strStartingDate As String = Nothing
    Dim strPlaintifName As String

    Dim strLegalName As String
    Dim strJurisdiction As String
    Dim strProvince As String
    Dim strFirmAddress1 As String
    Dim strFirmAddress2 As String
    Dim strFirmAddress3 As String
    Dim strFirmAddress4 As String
    Dim strDefendantName As String

    Dim strRootAction As String

    Private Sub AddStageTreeNodes()
        On Error GoTo RaiseErr
        tvActions.Nodes.Clear()
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = 0 ORDER BY [ProcedureId]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim node As New TreeNode
            node.Text = objReader(0).ToString
            node.Tag = objReader(1).ToString
            AddStageNodes(node)
            tvActions.Nodes.Add(node)
        End While
        objReader.Close()
        tvActions.ExpandAll()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
        ShowErrorMessage()
    End Sub

    Private Sub AddStageNodes(ByRef node As TreeNode)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = '" & node.Tag & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim nNode As New TreeNode
            nNode.Text = objReader(0).ToString
            nNode.Tag = objReader(1).ToString
            AddStageNodes(nNode)
            node.Nodes.Add(nNode)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmLegalActionsStatusUpdate_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        With txtCurrentStagging
            .ForeColor = Color.White
            .BackColor = Color.Teal
        End With
        AddStageTreeNodes()
        If boolAbort = True Then Exit Sub
        On Error GoTo RaiseErr
        dpDateOn.Value = Now
        If boolCalledFromListing Then
            cboAccountHolder.Text = strSelectedAccountName
            txtAccountNumber.Text = strSelectedAccount
            cboAccountHolder.Enabled = False
            txtFileNumber.Enabled = False

            txtCurrentStagging.Text = CurrentStagging(strSelectedAccount)

            If boolEditStatus = True Then
                Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM LegalActions " _
                    & "WHERE TransactionId = " & intSelectedTransaction & "", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    'If Not IsDBNull(objReader("ActionKey").ToString) Then
                    '    txtCurrentStagging.Text = objReader("ProcessAction").ToString
                    '    txtSelectedAction.Text = objReader("ProcessAction").ToString
                    'End If
                    If Not IsDBNull(objReader("Comments").ToString) Then txtComment.Text = objReader("Comments").ToString
                    If IsDate(objReader("ActionDate").ToString) Then dpDateOn.Value = CDate(objReader("ActionDate").ToString)
                    If IsNumeric(objReader("SpecialKey").ToString) Then lblSpecialKey.Text = objReader("SpecialKey").ToString
                End If
                objReader.Close()
                'Load the cost
                objCommand = New Data.OleDb.OleDbCommand("SELECT Debit FROM DefendantTransactions WHERE SpecialKey = " & lblSpecialKey.Text & "", cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then lblTotals.Text = Format(CDbl(objReader(0).ToString), "##0.00")
                End If
                objReader.Close()
            End If
        Else
            LoadClients("Defendants")
        End If

        If boolEditStatus = False Then
            dpDateOn.Value = Now
        Else
            lblTransactionId.Text = intSelectedTransaction
        End If
        LoadFileNumber()
        Label1.BackColor = Color.Orange
        lblTotals.BackColor = Color.BlueViolet

        With txtCurrentStagging
            .ForeColor = Color.White
            .BackColor = Color.Teal
        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Legal Actions Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmLegalActionsStatusUpdate_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 685
        Me.Height = 485 '685, 485
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadFileNumber()
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtAccountNumber.Text) Then Exit Sub
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT FileID FROM Defendants " _
            & "WHERE DefendantId = '" & txtAccountNumber.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtFileNumber.Text = objReader(0).ToString.ToUpper
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Legal Actions Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadClients(ByVal AccountType As String)
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing

        If UCase(AccountType) = UCase("Defendants") Then
            strSql = "SELECT GivenNames +'|'+ DefendantID AS " _
                & "[Details] FROM Defendants ORDER BY GivenNames"
        Else
            strSql = "SELECT GivenNames +'|'+ PlaintifID AS " _
                & "[Details] FROM Plaintifs ORDER BY GivenNames"
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrData As New ArrayList

        'Add the rest from the database
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboAccountHolder.Width - 80

        'Add the items to the drop down box
        With cboAccountHolder
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

        cboAccountHolder.Items.Clear()
        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboAccountHolder
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Client Names Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboAccountHolder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAccountHolder.KeyPress
        If Asc(e.KeyChar) = 13 Then
            tvActions.Focus()
            Exit Sub
        End If
        If Asc(e.KeyChar) <> 13 Then
            txtAccountNumber.Text = Nothing
        End If
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(cboAccountHolder.Text) Then
            MessageBox.Show("Please select a valid defendant", "Invalid Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccountHolder.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAccountNumber.Text) Then
            MessageBox.Show("Please select a valid defendant", "Invalid Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccountHolder.Focus()
            Exit Sub
        End If

        If Not IsNumeric(lblTotals.Text) Then lblTotals.Text = "0.00"
        If Not IsNumeric(txtOverideAmt.Text) Then txtOverideAmt.Text = "0.00"

        Dim strSql As String = Nothing
        Dim strSqlAmount As String = Nothing

        Dim dblProcessCosts As Double = CDbl(lblTotals.Text)
        If chkOverride.Checked = True Then dblProcessCosts = CDbl(txtOverideAmt.Text)

        Dim strActionDate As String = dpDateOn.Value

        'The new upgrade does not require the declared null string hence included as nothing to maintain code only
        Dim strProcedure As String = Nothing
        Dim strOpt As String = Nothing

        If boolEditStatusTwo = False Then

            boolAbort = False
            If CheckActionStatus(txtProcedureKey.Text, txtAccountNumber.Text) = True Then
                If MessageBox.Show("This debtor has gone through this stage. " _
                    & "Do you want to proceed anyway?", "Process Passed", MessageBoxButtons.YesNo, _
                    MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                    boolAbort = True
                    Exit Sub
                End If
            End If
            If boolAbort = True Then Exit Sub

            Dim intSpecialKey As Integer = gwt_comm.SpecialKey()

            strSql = "INSERT INTO LegalActions (DefendantId, ActionDate, TransactionDate, " _
                & "ProcedureName, ActionTaken, Comments, UserName, SpecialKey, [ActionKey]) " _
                & "VALUES ('" & txtAccountNumber.Text & "', '" & strActionDate & "', '" & Now & "', " _
                & "'" & txtSelectedAction.Text & "', '', '" & txtComment.Text & "', " _
                & "'" & strUserName & "', " & intSpecialKey & ", " & txtProcedureKey.Text & ")"

            strSqlAmount = "INSERT INTO DefendantTransactions ([DefendantId],[TransactionDate]," _
                & "[ReferenceNumber],[FileId],[Description],[Debit],[Credit],[Comments]," _
                & "[ReceiptNumber],[ReceivedBy]) VALUES ('" & txtAccountNumber.Text & "', " _
                & "'" & strActionDate & "', '', '" & txtFileNumber.Text & "', " _
                & "'" & txtSelectedAction.Text & "', " & dblProcessCosts & ", " _
                & "0, '" & txtComment.Text & "', '', '" & strUserName & "')"

        Else
            strSql = "UPDATE LegalActions SET ActionDate = '" & strActionDate & "', " _
                & "TransactionDate = '" & Now & "', " _
                & "ProcedureName = '" & txtSelectedAction.Text & "', " _
                & "ActionKey = " & txtProcedureKey.Text & ", Comments = '" & txtComment.Text & "', " _
                & "UserName = '" & strUserName & "' WHERE " _
                & "TransactionId = " & lblTransactionId.Text & ""

            strSqlAmount = "UPDATE DefendantTransactions SET Debit = " & dblProcessCosts & ", " _
                & "Description = '" & txtSelectedAction.Text & "', " _
                & "ReceivedBy = '" & strUserName & "' WHERE SpecialKey = " & lblSpecialKey.Text & " AND " _
                & "DefendantId = '" & txtAccountNumber.Text & "' AND SpecialKey <> 0"

        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Execute the amount update
        objCommand = New Data.OleDb.OleDbCommand(strSqlAmount, cnn)
        objCommand.ExecuteNonQuery()

        UpdateActionsTable(txtAccountNumber.Text, GetDefendantPlaintif(txtAccountNumber.Text))

        MessageBox.Show("Transaction has been updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Legal Procedures Options Load Failure"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SaveData()
    End Sub

    Private Sub tvActions_AfterSelect(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvActions.AfterSelect
        On Error Resume Next
        With txtSelectedAction
            .Text = Nothing
            .Text = tvActions.SelectedNode.FullPath
        End With
        txtProcedureKey.Text = tvActions.SelectedNode.Tag.ToString
        If Not String.IsNullOrEmpty(txtSelectedAction.Text) Then
            Dim strPlaintifId As String = GetDefendantPlaintif(txtAccountNumber.Text)
            Dim dblCost As Double = gwt_comm.LegalActionCost(tvActions.SelectedNode.Parent.Text, tvActions.SelectedNode.Text, strPlaintifId)
            lblTotals.Text = Format(dblCost, "##0.00")
        End If
    End Sub

    Private Sub txtFileNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFileNumber.KeyPress
        Dim strSearch As String = txtFileNumber.Text
        If Asc(e.KeyChar) = 13 Then
            strSearch = txtFileNumber.Text
        Else
            strSearch = txtFileNumber.Text & e.KeyChar
        End If
        SearchForItem(strSearch)
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = strCurrentKey
        strActiveSearch = strFind
        Cursor = Cursors.WaitCursor

        cboAccountHolder.Text = Nothing
        txtAccountNumber.Clear()

        Dim strSql As String = Nothing
        strSql = "SELECT GivenNames, DefendantID FROM Defendants WHERE FileId LIKE '%" & strFind & "%'"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then cboAccountHolder.SelectedText = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then txtAccountNumber.SelectedText = objReader(1).ToString
        End If
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Debtor details search by file id"
        ShowErrorMessage()
    End Sub

    Private Sub chkOverride_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOverride.CheckedChanged
        If chkOverride.Checked = True Then
            txtOverideAmt.Enabled = True
        Else
            txtOverideAmt.Enabled = False
        End If
    End Sub

    Private Sub GetDebtorDetails(AccountNumber As String)
        On Error GoTo RaiseErr
        strAddress1 = Nothing
        strAddress2 = Nothing
        strAddress3 = Nothing
        strAddress4 = Nothing
        strFileNumber = Nothing
        strPrincipalAmount = "0.00"
        strPlaintifName = Nothing

        strLegalName = Nothing
        strJurisdiction = Nothing
        strProvince = Nothing
        strFirmAddress1 = Nothing
        strFirmAddress2 = Nothing
        strFirmAddress3 = Nothing
        strFirmAddress4 = Nothing
        strDefendantName = Nothing

        Dim strSql As String = "SELECT PrimaryAddress1, PrimaryAddress2, " _
            & "PrimaryAddress3, PrimaryAddress4, FileId, GivenNames FROM Defendants WHERE DefendantId = '" & AccountNumber & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strAddress1 = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strAddress2 = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strAddress3 = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then strAddress4 = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then strFileNumber = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then strDefendantName = objReader(5).ToString
        End If
        objReader.Close()
        'Get the principal amount
        strSql = "SELECT CAST(SUM(Debit) AS DECIMAL (10,2)) AS [Amt], TransactionDate FROM DefendantTransactions " _
            & "WHERE DefendantId = '" & AccountNumber & "' AND Description = 'PRINCIPAL DEBT' GROUP BY DefendantTransactions.TransactionDate"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                strPrincipalAmount = Format(CDbl(objReader(0).ToString), "#,##0.00")
            End If
            If IsDate(objReader(1).ToString) Then
                strStartingDate = DatePart(DateInterval.Day, CDate(objReader(1).ToString)) & " " & _
                    MonthName(DatePart(DateInterval.Month, CDate(objReader(1).ToString)), False) & " " & _
                    DatePart(DateInterval.Year, CDate(objReader(1).ToString))
                strStartingDate = UCase(strStartingDate)
            End If
        End If
        objReader.Close()
        'Get the plaintif details
        strSql = "SELECT Defendants.PlaintifId, Plaintifs.GivenNames, LegalName, Jurisdiction, Province, " _
            & "FirmAddress1, FirmAddress2, FirmAddress3, FirmAddress4 FROM Defendants " _
            & "LEFT OUTER JOIN Plaintifs ON Defendants.PlaintifId = Plaintifs.PlaintifId " _
            & "WHERE Defendants.DefendantId = '" & AccountNumber & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(1).ToString) Then strPlaintifName = UCase(objReader(1).ToString)
            If Not IsDBNull(objReader(2).ToString) Then strLegalName = UCase(objReader(2).ToString)
            If Not IsDBNull(objReader(3).ToString) Then strJurisdiction = UCase(objReader(3).ToString)
            If Not IsDBNull(objReader(4).ToString) Then strProvince = UCase(objReader(4).ToString)
            If Not IsDBNull(objReader(5).ToString) Then strFirmAddress1 = UCase(objReader(5).ToString)
            If Not IsDBNull(objReader(6).ToString) Then strFirmAddress2 = UCase(objReader(6).ToString)
            If Not IsDBNull(objReader(7).ToString) Then strFirmAddress3 = UCase(objReader(7).ToString)
            If Not IsDBNull(objReader(8).ToString) Then strFirmAddress4 = UCase(objReader(8).ToString)
        End If
        objReader.Close()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Debtor details search by file id"
        ShowErrorMessage()
    End Sub

    Private Sub ppDoc_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles ppDoc.PrintPage

        Dim x As Integer = 100
        Dim y As Integer = 100

        'Declare the pens
        Dim myPen As System.Drawing.Pen
        Dim myBrush As System.Drawing.Brush

        Dim intHorizontalLineLength As Integer = DefaultPageSettings.PaperSize.Width - 200

        Dim x1 As Integer, x2 As Integer, X3 As Integer, X4 As Integer, X5 As Integer, X6 As Integer
        Dim y1 As Integer, y2 As Integer, p1 As Integer

        x1 = e.PageBounds.Left + 100
        y1 = e.PageBounds.Top + 100
        p1 = e.PageBounds.Width - 200
        y2 = e.PageBounds.Height - 200

        Dim pencurrent As New Pen(Brushes.WhiteSmoke, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        Dim strS As String = Nothing
        Dim Yc As Double
        Dim cols, lines As Double
        Dim GridPen As New Pen(Brushes.WhiteSmoke, 1)
        Dim g As Graphics = e.Graphics

        'Draw the document rectangle
        reccurrent = New Rectangle(x1, y1, p1, y2)
        e.Graphics.DrawRectangle(GridPen, reccurrent)

        myBrush = New SolidBrush(Color.Black)

        Dim strPrintValue As String = Nothing

        y1 = y1 + 7
        Call DrawStringInBoxLeft(e, x1, y1, 375, 80, "NO. CIV SUMMONS COMMENCING ACTION", myBrush, fntHeaderFontLocal)
        Call DrawStringInBoxLeft(e, x1 + 390, y1, 300, 80, "CASE NO.", myBrush, fntHeaderFontLocal)
        y1 = y1 + 22
        Call DrawStringInBoxLeft(e, x1, y1, 375, 80, "CLERK OF COURT ", myBrush, fntHeaderFontLocal)
        Call DrawStringInBoxLeft(e, x1 + 390, y1, 300, 80, "PROVINCE OF " & UCase(strProvince) & " ", myBrush, fntHeaderFontLocal)
        y1 = y1 + 22
        Call DrawStringInBoxLeft(e, x1, y1, 375, 80, "MAGISTRATES COURT", myBrush, fntHeaderFontLocal)
        Call DrawStringInBoxLeft(e, x1 + 390, y1, 300, 80, "HELD AT " & UCase(strJurisdiction), myBrush, fntHeaderFontLocal)
        y1 = y1 + 22
        Call DrawStringInBoxLeft(e, x1, y1, 375, 80, "PLAINTIFF", myBrush, fntHeaderFontLocal)
        Call DrawStringInBoxLeft(e, x1 + 390, y1, 300, 80, UCase(strLegalName), myBrush, fntHeaderFontLocal)
        y1 = y1 + 22
        Call DrawStringInBoxLeft(e, x1, y1, 375, 80, "DEFENDANT", myBrush, fntHeaderFontLocal)
        Call DrawStringInBoxLeft(e, x1 + 390, y1, 300, 80, UCase(strDefendantName), myBrush, fntHeaderFontLocal)
        y1 = y1 + 50

        'Print the details
        Dim strFullCoyAddress As String = Nothing
        If Not String.IsNullOrEmpty(strFirmAddress1) Then
            strFullCoyAddress = UCase(strFirmAddress1)
        End If
        If Not String.IsNullOrEmpty(strFirmAddress2) Then
            strFullCoyAddress = strFullCoyAddress & ", " & UCase(strFirmAddress2)
        End If
        If Not String.IsNullOrEmpty(strFirmAddress3) Then
            strFullCoyAddress = strFullCoyAddress & ", " & UCase(strFirmAddress3)
        End If
        If Not String.IsNullOrEmpty(strFirmAddress4) Then
            strFullCoyAddress = strFullCoyAddress & ", " & UCase(strFirmAddress4)
        End If

        strPrintValue = "You are hereby summoned that you do within seven (7) " _
            & "days after the service of this summons upon, you, enter or cause to be entered with me and " _
            & "also the Plaintiff’s Legal Practitioners at the address specified herein, appearance i.e. " _
            & "(file a notice of intention to defend) or answer the claim by " & UCase(strLegalName) & " " _
            & "whose address for service is MANGWANA AND PARTNERS " & UCase(strFullCoyAddress) & " " _
            & "the Plaintiff herein for (see particulars of claim)."

        Call DrawStringInBoxLeft(e, x1, y1, 650, 120, strPrintValue, myBrush, fntDetailsFontLocal)

        e.Graphics.MeasureString(strPrintValue, fntDetailsFontLocal, New SizeF(650, 120), New StringFormat(), cols, lines)
        Yc = y1
        y1 = y1 + lines * (fntDetailsFontLocal.Height + 1)
        y1 = Math.Max(y1, Yc) + 2

        y1 = y1 + 20
        strPrintValue = "TAKE NOTE THAT:"
        Call DrawStringInBoxLeft(e, x1, y1, 650, 80, strPrintValue, myBrush, fntHeaderFontLocal)

        e.Graphics.MeasureString(strPrintValue, fntDetailsFontLocal, New SizeF(650, 80), New StringFormat(), cols, lines)
        Yc = y1
        y1 = y1 + lines * (fntDetailsFontLocal.Height + 1)
        y1 = Math.Max(y1, Yc) + 2
        y1 = y1 + 20

        strPrintValue = "In default of doing so, you will be held to have " _
            & "admitted the said claims and the Plaintiff may proceed therein and judgment may be entered " _
            & "against you in your absence, but that, upon payment of the said claim and costs to me " _
            & "within the said time, judgment will not be given against you and that, if before the expiration " _
            & "of the said time you so pay the plaintiff or his legal Practitioner, a consent to judgment, " _
            & "you will save judgment costs. If you allege any exception, defense or counter claim you must " _
            & "within seven (7) days after appearance, deliver to me the Plaintiff’s Legal Practitioner a " _
            & "statement in writing of the nature and grounds therefore."
        Call DrawStringInBoxLeft(e, x1, y1, 650, 120, strPrintValue, myBrush, fntDetailsFontLocal)

        e.Graphics.MeasureString(strPrintValue, fntDetailsFontLocal, New SizeF(650, 120), New StringFormat(), cols, lines)
        Yc = y1
        y1 = y1 + lines * (fntDetailsFontLocal.Height + 1)
        y1 = Math.Max(y1, Yc) + 2
        y1 = y1 + 20

        strPrintValue = "PARTICULARS OF CLAIM: "
        Call DrawStringInBoxLeft(e, x1, y1, 650, 80, strPrintValue, myBrush, fntHeaderFontLocal)

        e.Graphics.MeasureString(strPrintValue, fntDetailsFontLocal, New SizeF(650, 80), New StringFormat(), cols, lines)
        Yc = y1
        y1 = y1 + lines * (fntDetailsFontLocal.Height + 1)
        y1 = Math.Max(y1, Yc) + 2
        y1 = y1 + 20

        strPrintValue = "Plaintiff claims payment of the sum of US$" & strPrincipalAmount & " being arrears for treatment and " _
            & "medication for the period ending " & strStartingDate & " due to plaintiff and payable by the defendant in " _
            & "terms of the Urban Council Act chapter 29: 15. Despite demand the Defendant has failed, " _
            & "refused and neglected to pay."
        Call DrawStringInBoxLeft(e, x1, y1, 650, 120, strPrintValue, myBrush, fntDetailsFontLocal)

        e.Graphics.MeasureString(strPrintValue, fntDetailsFontLocal, New SizeF(650, 120), New StringFormat(), cols, lines)
        Yc = y1
        y1 = y1 + lines * (fntDetailsFontLocal.Height + 1)
        y1 = Math.Max(y1, Yc) + 2
        y1 = y1 + 20

        strPrintValue = "Wherefore Plaintiff claims "
        Call DrawStringInBoxLeft(e, x1, y1, 650, 80, strPrintValue, myBrush, fntDetailsFontLocal)
        y1 = y1 + 20
        strPrintValue = "a)	Plaintiff claims payment of the sum of US$" & strPrincipalAmount
        Call DrawStringInBoxLeft(e, x1 + 20, y1, 650, 80, strPrintValue, myBrush, fntDetailsFontLocal)
        y1 = y1 + 15
        strPrintValue = "b)	Interest at the prescribed rate from " & strStartingDate & " to date of payment"
        Call DrawStringInBoxLeft(e, x1 + 20, y1, 650, 80, strPrintValue, myBrush, fntDetailsFontLocal)
        y1 = y1 + 15
        strPrintValue = "c)	Costs of Suit."
        Call DrawStringInBoxLeft(e, x1 + 20, y1, 650, 80, strPrintValue, myBrush, fntDetailsFontLocal)
        y1 = y1 + 30

        strPrintValue = "DATED AT " & strProvince & " THIS……………………………..DAY OF " & _
            UCase(MonthName(DatePart(DateInterval.Month, dpDateOn.Value), False) & " " & DatePart(DateInterval.Year, dpDateOn.Value))
        Call DrawStringInBoxLeft(e, x1 + 20, y1, 650, 80, strPrintValue, myBrush, fntHeaderFontLocal)
        y1 = y1 + 50

        Call DrawStringInBoxLeft(e, x1 + 350, y1, 300, 80, "MANGWANA & PARTNERS", myBrush, fntHeaderFontLocal)
        y1 = y1 + 20
        Call DrawStringInBoxLeft(e, x1 + 350, y1, 300, 80, "Plaintiff Legal Practitioners", myBrush, fntDetailsFontBoldLocal)
        y1 = y1 + 15
        Call DrawStringInBoxLeft(e, x1 + 350, y1, 300, 80, strFullCoyAddress, myBrush, fntDetailsFontBoldLocal)
        y1 = y1 + 15
        Call DrawStringInBoxLeft(e, x1 + 350, y1, 300, 80, "(MPM/MHC/RSC8)", myBrush, fntDetailsFontBoldLocal)
        y1 = y1 + 30

        reccurrent = New Rectangle(x1 + 350, y1, 250, 130)
        e.Graphics.DrawRectangle(Pens.Black, reccurrent)

        'Write in the box
        y1 = y1 + 5
        Call DrawStringInBoxLeft(e, x1 + 360, y1, 250, 80, "Legal practitioner charges", myBrush, fntDetailsFontBoldLocal)
        Call DrawStringInBoxRight(e, x1 + 525, y1, 80, 80, "$44.00", myBrush, fntDetailsFontBoldLocal)
        'Write Debtor Address as well
        Call DrawStringInBoxLeft(e, x1, y1, 250, 80, "Address of Defendant", myBrush, fntDetailsFontBoldLocal)
        y1 = y1 + 18
        'Write Debtor Address as well
        Call DrawStringInBoxLeft(e, x1, y1, 250, 80, strAddress1, myBrush, fntDetailsFontBoldLocal)
        Call DrawStringInBoxLeft(e, x1 + 360, y1, 280, 80, "Court Fees", myBrush, fntDetailsFontBoldLocal)
        Call DrawStringInBoxRight(e, x1 + 525, y1, 80, 80, "$5.00", myBrush, fntDetailsFontBoldLocal)
        y1 = y1 + 18
        'Write Debtor Address as well
        Call DrawStringInBoxLeft(e, x1, y1, 250, 80, strAddress2, myBrush, fntDetailsFontBoldLocal)
        Call DrawStringInBoxLeft(e, x1 + 360, y1, 250, 80, "Collection Commission", myBrush, fntDetailsFontBoldLocal)
        y1 = y1 + 18
        'Write Debtor Address as well
        Call DrawStringInBoxLeft(e, x1, y1, 250, 80, strAddress3, myBrush, fntDetailsFontBoldLocal)
        Call DrawStringInBoxLeft(e, x1 + 360, y1, 250, 80, "Messenger Fees", myBrush, fntDetailsFontBoldLocal)
        y1 = y1 + 18
        'Write Debtor Address as well
        Call DrawStringInBoxLeft(e, x1, y1, 250, 80, strAddress4, myBrush, fntDetailsFontBoldLocal)
        Call DrawStringInBoxLeft(e, x1 + 360, y1, 280, 80, "Letter of Demand", myBrush, fntDetailsFontBoldLocal)
        Call DrawStringInBoxRight(e, x1 + 525, y1, 80, 80, "$13.00", myBrush, fntDetailsFontBoldLocal)
        y1 = y1 + 18

        'Draw line here
        Call DrawStringInBoxLeft(e, x1, y1, 250, 80, "File No. " & strFileNumber, myBrush, fntDetailsFontBoldLocal)
        Call DrawStringInBoxLeft(e, x1 + 360, y1, 250, 80, "Total", myBrush, fntDetailsFontBoldLocal)
        y1 = y1 + 15

    End Sub

    Private Sub DrawStringInBoxRight(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
                ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal sBrush As System.Drawing.Brush, ByVal sFnt As System.Drawing.Font)
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF(x1, y1, (x2 - 5), y2)
        sfCurrent.Alignment = Drawing.StringAlignment.Far
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Private Sub DrawStringInBoxLeft(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
        ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal sBrush As System.Drawing.Brush, ByVal sFnt As System.Drawing.Font)
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF(x1, y1, x2, y2)
        sfCurrent.Alignment = Drawing.StringAlignment.Near
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

    Private Sub DrawStringInBoxCenter(ByVal ev As System.Drawing.Printing.PrintPageEventArgs, _
        ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single, ByVal s As String, ByVal sBrush As System.Drawing.Brush, ByVal sFnt As System.Drawing.Font)
        Dim sfCurrent As New Drawing.StringFormat()
        Dim recCurrent As New Drawing.RectangleF(x1, y1, x2, y2)
        sfCurrent.Alignment = Drawing.StringAlignment.Center
        ev.Graphics.DrawString(s, sFnt, sBrush, recCurrent, sfCurrent)
    End Sub

End Class