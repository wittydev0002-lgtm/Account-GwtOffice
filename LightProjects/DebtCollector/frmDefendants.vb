Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports DevComponents.DotNetBar

Public Class frmDefendants

    Dim strRootAction As String = Nothing

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGridInventories_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridInventories.EditingControlShowing
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

    Private Sub dGridInventories_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridInventories.CellEndEdit
        If e.ColumnIndex = 1 Then
            If IsNumeric(dGridInventories.CurrentCell.Value) Then
                dGridInventories.CurrentCell.Value = Format(CDbl(dGridInventories.CurrentCell.Value), "##0.00")
            Else
                dGridInventories.CurrentCell.Value = "0.00"
            End If
            'Recompute total
            Dim dblEstimatedValue As Double = 0
            For p As Integer = 0 To dGridInventories.RowCount - 1
                If Not Object.Equals(dGridInventories.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridInventories.Rows(p).Cells(1).Value.ToString) Then
                        If IsNumeric(dGridInventories.Rows(p).Cells(1).Value.ToString) Then
                            dblEstimatedValue = dblEstimatedValue + CDbl(dGridInventories.Rows(p).Cells(1).Value.ToString)
                        End If
                    End If
                End If
            Next
            txtEstimatedValue.Text = Format(dblEstimatedValue, "#,##0.00")
        End If
    End Sub

    Private Sub btnLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLink.Click
        boolAbort = False
        strCalledBy = "PLAINTIFS"
        strSelectedCode = Nothing
        strSelectedDescription = Nothing
        strSelectedFileNumber = Nothing
        strSelectedCaseNumber = Nothing
        Dim frm As New frmBrowseLegalParties
        frm.ShowDialog()
        strCalledBy = Nothing
        If boolAbort = True Then Exit Sub
        txtPlaintifId.Text = strSelectedCode
        lblPlaintif.Text = strSelectedDescription
    End Sub

    Private Sub SaveDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        If Not IsNumeric(txtBalance.Text) Then
            txtBalance.Text = "0.00"
        End If
        If String.IsNullOrEmpty(cboStatus.Text) Then cboStatus.Text = "ACTIVE"

        If boolEditStatus = False Then
            strSql = "INSERT INTO [Defendants] ([DefendantId],[GivenNames],[PrimaryAddress1]," _
                & "[PrimaryAddress2],[PrimaryAddress3],[PrimaryAddress4],[Telephone],[EmailAddress]," _
                & "[SecondaryAddress1],[SecondaryAddress2],[SecondaryAddress3],[SecondaryAddress4]," _
                & "[ContactName],[ContactPhone],[Status],[ClientType],[PlaintifId],[FileId]," _
                & "[SecondaryEmailAddress],[Classification], [ClassId], [CaseNumber], [PrincipalDebt], " _
                & "[Cellphone], [Status], [Ownership]) VALUES " _
                & "('" & txtDefendantId.Text & "', '" & txtGivenNames.Text & "', '" & txtMainAddress1.Text & "', " _
                & "'" & txtMainAddress2.Text & "', '" & txtMainAddress3.Text & "', '" & txtMainAddress4.Text & "', " _
                & "'" & txtMainTelephone.Text & "', '" & txtMainEmailAddress.Text & "', '" & txtSecAddress1.Text & "', " _
                & "'" & txtSecAddress2.Text & "', '" & txtSecAddress3.Text & "', '" & txtSecAddress4.Text & "', " _
                & "'" & txtContactPerson.Text & "', '" & txtSecTelephone.Text & "', 'ACTIVE', " _
                & "'INDIVIDUAL', '" & txtPlaintifId.Text & "', '" & txtFileNo.Text & "', " _
                & "'" & txtSecEmailAddress.Text & "', '" & cboClassification.Text & "', " _
                & "" & txtClassId.Text & ", '" & txtCaseNumber.Text & "', " & txtBalance.Text & ", " _
                & "'" & txtCellphone.Text & "', '" & cboStatus.Text & "', '" & cboPropertyOwnership.Text & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Else
            strSql = "UPDATE [Defendants] SET [GivenNames] = '" & txtGivenNames.Text & "', " _
                & "[PrimaryAddress1] = '" & txtMainAddress1.Text & "', " _
                & "[PrimaryAddress2] = '" & txtMainAddress2.Text & "', " _
                & "[PrimaryAddress3] = '" & txtMainAddress3.Text & "', " _
                & "[PrimaryAddress4] = '" & txtMainAddress4.Text & "', " _
                & "[Telephone] = '" & txtMainTelephone.Text & "', [EmailAddress] = '" & txtMainEmailAddress.Text & "', " _
                & "[SecondaryAddress1] = '" & txtSecAddress1.Text & "', " _
                & "[SecondaryAddress2] = '" & txtSecAddress2.Text & "', " _
                & "[SecondaryAddress3] = '" & txtSecAddress3.Text & "', " _
                & "[SecondaryAddress4] = '" & txtSecAddress4.Text & "', " _
                & "[ContactName] = '" & txtContactPerson.Text & "', [ContactPhone] = '" & txtSecTelephone.Text & "', " _
                & "[PlaintifId] = '" & txtPlaintifId.Text & "', [FileId] = '" & txtFileNo.Text & "', " _
                & "[SecondaryEmailAddress] = '" & txtSecEmailAddress.Text & "', " _
                & "Classification = '" & cboClassification.Text & "', CaseNumber = '" & txtCaseNumber.Text & "', " _
                & "ClassId = " & txtClassId.Text & ", Cellphone = '" & txtCellphone.Text & "', " _
                & "PrincipalDebt = " & txtBalance.Text & ", Status = '" & cboStatus.Text & "', " _
                & "OwnerShip = '" & cboPropertyOwnership.Text & "' WHERE " _
                & "[DefendantId]='" & txtDefendantId.Text & "'"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        'Make and correct the transactions table as well with the principal debt balance
        Dim strUpdatePrincipal As String = "UPDATE DefendantTransactions SET Debit = " & txtBalance.Text & " " _
            & "WHERE DefendantId = '" & txtDefendantId.Text & "' AND Description = 'PRINCIPAL DEBT'"
        objCommand = New Data.OleDb.OleDbCommand(strUpdatePrincipal, cnn)
        objCommand.ExecuteNonQuery()

        SaveInventories()
        MessageBox.Show("Details have been updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Details Save"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSelectedData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Defendants WHERE DefendantId = '" & strSelectedAccount & "'", cnn) 'strSelectedAccount
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        txtDefendantId.Text = strSelectedAccount
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("GivenNames").ToString) Then
                txtGivenNames.Text = objReader("GivenNames").ToString
                Me.TextExtra = objReader("GivenNames").ToString
            End If
            If Not IsDBNull(objReader("PrimaryAddress1").ToString) Then txtMainAddress1.Text = objReader("PrimaryAddress1").ToString
            If Not IsDBNull(objReader("PrimaryAddress2").ToString) Then txtMainAddress2.Text = objReader("PrimaryAddress2").ToString
            If Not IsDBNull(objReader("PrimaryAddress3").ToString) Then txtMainAddress3.Text = objReader("PrimaryAddress3").ToString
            If Not IsDBNull(objReader("PrimaryAddress4").ToString) Then txtMainAddress4.Text = objReader("PrimaryAddress4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtMainTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtMainEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("SecondaryAddress1").ToString) Then txtSecAddress1.Text = objReader("SecondaryAddress1").ToString
            If Not IsDBNull(objReader("SecondaryAddress2").ToString) Then txtSecAddress2.Text = objReader("SecondaryAddress2").ToString
            If Not IsDBNull(objReader("SecondaryAddress3").ToString) Then txtSecAddress3.Text = objReader("SecondaryAddress3").ToString
            If Not IsDBNull(objReader("SecondaryAddress4").ToString) Then txtSecAddress4.Text = objReader("SecondaryAddress4").ToString
            If Not IsDBNull(objReader("ContactName").ToString) Then txtContactPerson.Text = objReader("ContactName").ToString
            If Not IsDBNull(objReader("ContactPhone").ToString) Then txtSecTelephone.Text = objReader("ContactPhone").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("Ownership").ToString) Then cboPropertyOwnership.Text = objReader("Ownership").ToString
            'cboPropertyOwnership
            If Not IsDBNull(objReader("PlaintifId").ToString) Then
                txtPlaintifId.Text = objReader("PlaintifId").ToString
                lblPlaintif.Text = UCase(GetPlaintifName(txtPlaintifId.Text))
            End If
            If Not IsDBNull(objReader("FileId").ToString) Then
                txtFileNo.Text = objReader("FileId").ToString
                Me.TextExtra = UCase(txtFileNo.Text) & "-" & Me.TextExtra
            End If

            If Not IsDBNull(objReader("SecondaryEmailAddress").ToString) Then txtSecEmailAddress.Text = objReader("SecondaryEmailAddress").ToString
            If Not IsDBNull(objReader("Status").ToString) Then lblStatus.Text = objReader("Status").ToString
            If Not IsDBNull(objReader("CaseNumber").ToString) Then txtCaseNumber.Text = objReader("CaseNumber").ToString

            If IsNumeric(objReader("ClassId").ToString) Then
                txtClassId.Text = objReader("ClassId").ToString
                cboClassification.Text = GetClassName(CInt(objReader("ClassId").ToString))
                'Update the class name for any changes
                UpdateClassName(cboClassification.Text)
            End If

            If IsNumeric(objReader("PrincipalDebt").ToString) Then
                txtBalance.Text = objReader("PrincipalDebt").ToString
            End If
            If Not IsDBNull(objReader("Status").ToString) Then cboStatus.Text = objReader("Status").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub UpdateClassName(ByVal NewClassName As String)
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE Defendants SET Classification = " _
            & "'" & NewClassName & "' WHERE DefendantId = '" & strSelectedAccount & "'", cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Details Load Classification Name Update"
        ShowErrorMessage()
    End Sub

    Private Function GetClassName(ByVal ClassId As Integer) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ClassName FROM LegalClasses " _
            & "WHERE ClassId = " & ClassId & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Details Load Classification Name Fetch"
        ShowErrorMessage()
    End Function

    Private Sub btnNewNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewNote.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtDefendantId.Text) Then
            MessageBox.Show("You must create and save the defendant details before assigning notes to defendant", "Missing Defendant ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDefendantId.Focus()
            Exit Sub
        End If
        strNoteEntry = Nothing
        boolAbort = False
        Dim frm As New frmNoteEntry
        frm.ShowDialog()
        If boolAbort = True Then
            strNoteEntry = Nothing
        End If
        'Add the note to the table
        If Not String.IsNullOrEmpty(strNoteEntry) Then
            Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO DefendantNotes (DefendantId, Notes, Priority) " _
                & "VALUES ('" & txtDefendantId.Text & "', '" & strNoteEntry & "', '" & strPublicNotePriority & "')", cnn)
            objCommand.ExecuteNonQuery()
        End If
        LoadNotes()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Notes Entry"
        ShowErrorMessage()
    End Sub

    Private Sub LoadTransactions()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CONVERT(NVARCHAR, TransactionDate, 105) AS [Date], " _
            & "Description, ReferenceNumber, CAST(Debit AS DECIMAL (10,2)) AS [Debit], " _
            & "CAST(Credit AS DECIMAL(10,2)) AS [Credit], Comments, TransactionId FROM DefendantTransactions " _
            & "WHERE DefendantId = '" & strSelectedAccount & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5), objReader(6))
        End While
        objReader.Close()
        With dGrid
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        lblBalance.Text = Format(dblClientBalance, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Transactions Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadNotes()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Notes, TransactionId FROM DefendantNotes " _
            & "WHERE DefendantId = '" & strSelectedAccount & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridNotes.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGridNotes.Rows.Add(objReader(0).ToString, objReader(1).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Notes Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmDefendants_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadLegalBranchesData()
        If boolEditStatus = True Then
            LoadSelectedData()
            LoadTransactions()
            LoadNotes()
            LoadActions(strSelectedAccount)
            LoadSummaryReceipts(strSelectedAccount)
            UpdateTotals()
            LoadPaymentPlans()
            LoadDefendentInventories()
            'Dim info As TaskDialogInfo = CreateTaskDialogInfo()

            'Dim result As eTaskDialogResult = TaskDialog.Show(info)
            ''Log("{0} Task-dialog closed with result: {1}", Date.Now, result)
            ''CreateTaskDialogInfo()
        End If
    End Sub

    Private Sub LoadPaymentPlans()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, [TransDate], 105) AS [TransDate], " _
            & "[ProcedureName], CONVERT(NVARCHAR, [EffectiveDate], 105) AS [EffectiveDate], " _
            & "[DayOfMonth],[Amount], [TransactionId] FROM DefendantPaymentTerms WHERE DefendantId = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridPlans.Rows.Clear()
        While objReader.Read
            dGridPlans.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Payment Plans Load"
        ShowErrorMessage()
    End Sub

    Private Function CreateTaskDialogInfo() As TaskDialogInfo
        Dim button As eTaskDialogButton = eTaskDialogButton.Ok
        button = button Or eTaskDialogButton.Yes
        Dim info As New TaskDialogInfo("Attention", CType(System.Enum.Parse(GetType(eTaskDialogIcon), "BlueStop"),  _
            eTaskDialogIcon), "HEADER TEXT", "This the note message content", button, _
            CType(System.Enum.Parse(GetType(eTaskDialogBackgroundColor), "Default"),  _
                eTaskDialogBackgroundColor), Nothing, Nothing, Nothing, "This is the footer", Nothing)
        Return info
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtDefendantId.Text) Then
            MessageBox.Show("Please assign the defendant reference number", "Missing Key Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDefendantId.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtGivenNames.Text) Then
            MessageBox.Show("Please the defendant name", "Missing Key Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtGivenNames.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtMainAddress1.Text) Then
            MessageBox.Show("Please enter the defendant address", "Missing Key Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMainAddress1.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblPlaintif.Text) Then
            MessageBox.Show("The linked plaintif record does not exist", "Missing Key Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnLink.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtPlaintifId.Text) Then
            MessageBox.Show("Please link this record to the plaintif", "Missing Key Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            btnLink.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtBalance.Text) Then txtBalance.Text = "0.00"

        SaveDetails()
        If boolAbort = True Then Exit Sub
        If boolEditStatus = False Then InitializeTransactions("DEFENDANTS", txtDefendantId.Text, _
            CDate(Format(Now, "dd-MMM-yyyy")), CDbl(txtBalance.Text), 0, "TAKE ON BALANCE", "Entry by " & strUserName)
    End Sub

    Private Function GetPlaintifName(ByVal PlaintifId As String) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT GivenNames FROM Plaintifs WHERE PlaintifId = '" & PlaintifId & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Notes Load"
        ShowErrorMessage()
    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If dGridNotes.Rows.Count > 0 Then
            If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Note Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM DefendantNotes WHERE TransactionId = " & dGridNotes.CurrentRow.Cells(1).Value.ToString, cnn)
                objCommand.ExecuteNonQuery()
                MessageBox.Show("Transaction deleted successful", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadNotes()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Notes Delete"
        ShowErrorMessage()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        On Error GoTo RaiseErr
        If dGridNotes.Rows.Count > 0 Then
            If Not Object.Equals(dGridNotes.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridNotes.CurrentRow.Cells(0).Value) Then
                    intSelectedTransaction = CInt(dGridNotes.CurrentRow.Cells(1).Value.ToString)
                    strEditNote = dGridNotes.CurrentRow.Cells(0).Value.ToString
                    strNoteEntry = Nothing
                    boolAbort = False
                    Dim f As New frmNoteEntry
                    f.ShowDialog()
                    If boolAbort = True Then Exit Sub
                    If Not String.IsNullOrEmpty(strNoteEntry) Then
                        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE DefendantNotes SET " _
                            & "Notes = '" & strNoteEntry & "', Priority = '" & strPublicNotePriority & "' " _
                            & "WHERE TransactionId = " & intSelectedTransaction & "", cnn)
                        objCommand.ExecuteNonQuery()
                        MessageBox.Show("Transaction updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        strEditNote = Nothing
                        LoadNotes()
                    End If
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Notes Edit"
        ShowErrorMessage()
    End Sub

    Private Sub LoadLegalBranchesData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ClassName +'|'+ CONVERT(NVARCHAR, ClassId) AS " _
            & "[Details] FROM LegalClasses ORDER BY ClassName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrData As New ArrayList

        'Add the rest from the database
        While objReader.Read
            Dim strSpitData() As String = Split(objReader(0).ToString, "|")
            If Not String.IsNullOrEmpty(strSpitData(0)) Then
                arrData.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboClassification.Width - 80

        'Add the items to the drop down box
        With cboClassification
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

        cboClassification.Items.Clear()
        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), Format(CInt(strRecordText(1)), "000"))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboClassification
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On legal branches details load"
        ShowErrorMessage()
    End Sub

    Private Sub cboClassification_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClassification.SelectedIndexChanged
        If Not cboClassification.SelectedItem Is Nothing Then
            txtClassId.Text = cboClassification.SelectedItem.Col2
        Else
            txtClassId.Text = ""
        End If
    End Sub

    Private Sub LoadSummaryReceipts(ByVal DefendantId As String)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "ReferenceNumber AS [Ref.#], CAST(SUM(Credit) AS DECIMAL (10,2)) AS [Amount] FROM DefendantTransactions " _
            & "WHERE DefendantId = '" & DefendantId & "' GROUP BY ReferenceNumber, TransactionDate"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        With dGridReceiptsSummery
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(objReader(0), objReader(1), objReader(2))
            End While
            objReader.Close()

            lblReceiptsTotals.Text = "0.00"
            Dim dblTotalReceipts As Double = 0
            For i As Integer = 0 To dGridReceiptsSummery.Rows.Count - 1
                If Not Object.Equals(.Rows(i).Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(i).Cells(2).Value.ToString) Then
                        If IsNumeric(.Rows(i).Cells(2).Value.ToString) Then
                            dblTotalReceipts = dblTotalReceipts + CDbl(.Rows(i).Cells(2).Value.ToString)
                        End If
                    End If
                End If
            Next
            lblReceiptsTotals.Text = Format(dblTotalReceipts, "#,##0.00")
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Debtor payments summary"
        ShowErrorMessage()
    End Sub

    Private Sub LoadActions(ByVal DefendantId As String)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date1], " _
            & "UPPER(REPLACE(CONVERT(CHAR(11), ActionDate, 106), ' ', '-')) as [Date2], ActionKey, TransactionId FROM LegalActions " _
            & "WHERE DefendantId = '" & DefendantId & "' ORDER BY ActionDate"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridActions.Rows.Clear()
        While objReader.Read
            Dim strProcess As String = Nothing
            Dim strAction As String = Nothing

            Dim objComAction As New Data.OleDb.OleDbCommand("SELECT ActionName FROM ProdedureAndActions " _
                & "WHERE ProcedureId = " & objReader("ActionKey").ToString & "", cnn)
            Dim objReadAction As Data.OleDb.OleDbDataReader = objComAction.ExecuteReader
            If objReadAction.HasRows Then
                objReadAction.Read()
                If Not IsDBNull(objReadAction(0).ToString) Then
                    If Not String.IsNullOrEmpty(objReadAction(0).ToString) Then
                        strAction = objReadAction(0).ToString
                    End If
                End If
            End If
            objReadAction.Close()
            MainAction(CInt(objReader("ActionKey").ToString))
            If Not String.IsNullOrEmpty(strRootAction) Then
                strProcess = strRootAction
            Else
                strProcess = strAction
            End If

            'If Not IsDBNull(objReader("ProcessAction").ToString) Then
            '    If Not String.IsNullOrEmpty(objReader("ProcessAction").ToString) Then
            '        Dim strBuffer() As String = Split(objReader("ProcessAction").ToString, "\")
            '        strProcess = strBuffer(0)
            '        strAction = strBuffer(strBuffer.Length - 1)
            '    End If
            'End If

            dGridActions.Rows.Add(objReader(0), objReader(1), UCase(strProcess), UCase(strAction), _
                gwt_comm.DaysDue(objReader(2).ToString, objReader(3).ToString, strSelectedAccount, _
                CDate(objReader(1).ToString)), objReader("TransactionId").ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Actions History Load"
        ShowErrorMessage()
    End Sub

    Private Sub MainAction(ProcedureId As Integer)
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SubActionOf, ActionName FROM ProdedureAndActions " _
            & "WHERE ProcedureId = " & ProcedureId & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(1).ToString) Then
                If Not String.IsNullOrEmpty(objReader(1).ToString) Then
                    strRootAction = objReader(1).ToString
                End If
            End If
            MainAction(objReader(0).ToString)
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Actions History Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnAddAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAction.Click
        boolEditStatusTwo = False
        boolCalledFromListing = True
        strSelectedAccountName = Me.TextExtra
        Dim frm As New frmLegalActionsStatusUpdate
        frm.ShowDialog()
        LoadActions(strSelectedAccount)
    End Sub

    Private Sub btnEditAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditAction.Click
        If dGridActions.Rows.Count > 0 Then
            intSelectedTransaction = CInt(dGridActions.CurrentRow.Cells(dGridActions.ColumnCount - 1).Value.ToString)
            strSelectedAccountName = Me.TextExtra
            boolEditStatusTwo = True
            boolCalledFromListing = True
            Dim frm As New frmLegalActionsStatusUpdate
            frm.ShowDialog()
            LoadActions(strSelectedAccount)
        End If
    End Sub

    Private Sub btnDeleteAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAction.Click
        On Error GoTo RaiseErr

        Dim strReverseCosts As String = Nothing
        Dim intTransaction As Integer = 0

        If dGridActions.Rows.Count > 0 Then

            Dim boolReverseCosts As Boolean = False
            intTransaction = dGridActions.CurrentRow.Cells(5).Value.ToString

            If MessageBox.Show("Are you sure you want to delete this action", "Confirm Action Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("Do you want to reverse costs associated with this action as well?", "Reverse Costs", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    boolReverseCosts = True
                End If
                If boolReverseCosts = True Then
                    'boolAbort = False
                    'Dim frm As New frmLegalActionsCostsReversals
                    'frm.ShowDialog()
                    'If boolAbort = True Then
                    '    MessageBox.Show("The whole process is terminated", "Process Termination", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Exit Sub
                    'End If
                    If Not Object.Equals(dGridActions.CurrentRow.Cells(5).Value, Nothing) Then
                        If IsNumeric(dGridActions.CurrentRow.Cells(5).Value.ToString) Then
                            Dim intRecordSpecialKey As Integer = 0
                            Dim strProcedure As String = Nothing
                            Dim strOption As String = Nothing
                            If Not Object.Equals(dGridActions.CurrentRow.Cells(2).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(dGridActions.CurrentRow.Cells(2).Value.ToString) Then
                                    strProcedure = dGridActions.CurrentRow.Cells(2).Value.ToString
                                End If
                            End If
                            If Not Object.Equals(dGridActions.CurrentRow.Cells(3).Value, Nothing) Then
                                If Not String.IsNullOrEmpty(dGridActions.CurrentRow.Cells(3).Value.ToString) Then
                                    strOption = dGridActions.CurrentRow.Cells(3).Value.ToString
                                End If
                            End If
                            Dim objComDetails As New Data.OleDb.OleDbCommand("SELECT * FROM LegalActions " _
                                & "WHERE TransactionId = " & intTransaction & "", cnn)
                            Dim objReadDetails As Data.OleDb.OleDbDataReader = objComDetails.ExecuteReader
                            If objReadDetails.HasRows Then
                                objReadDetails.Read()
                                If IsNumeric(objReadDetails("SpecialKey").ToString) Then intRecordSpecialKey = objReadDetails("SpecialKey").ToString

                                strReverseCosts = "UPDATE DefendantTransactions SET Credit = Debit, " _
                                    & "Description = '" & strProcedure & "-" & strOption & "', " _
                                    & "ReceivedBy = '" & strUserName & "', Comments = 'TRANSACTION REVERSED' " _
                                    & "WHERE SpecialKey = " & intRecordSpecialKey & " AND " _
                                    & "DefendantId = '" & objReadDetails("DefendantId").ToString & "' AND SpecialKey <> 0"
                            End If
                            objReadDetails.Close()
                        End If
                    End If

                End If
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM LegalActions WHERE TransactionId = " & intTransaction & "", cnn)
                objCommand.ExecuteNonQuery()

                If Not String.IsNullOrEmpty(strReverseCosts) Then
                    objCommand = New Data.OleDb.OleDbCommand(strReverseCosts, cnn)
                    objCommand.ExecuteNonQuery()
                End If

                MessageBox.Show("Action Reversed Successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadActions(strSelectedAccount)

            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Legal Action Delete"
        ShowErrorMessage()
    End Sub

    Private Sub dGridActions_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGridActions.DoubleClick
        If dGridActions.Rows.Count > 0 Then
            intSelectedTransaction = CInt(dGridActions.CurrentRow.Cells(dGridActions.ColumnCount - 1).Value.ToString)
            strSelectedAccountName = Me.TextExtra
            boolEditStatus = True
            boolCalledFromListing = True
            Dim frm As New frmLegalActionsStatusUpdate
            frm.ShowDialog()
            LoadActions(strSelectedAccount)
        End If
    End Sub

    Private Sub UpdateTotals()
        lblBalance.Text = "0.00"
        lblCredits.Text = "0.00"
        lblDebits.Text = "0.00"
        With dGrid
            Dim dblDebitsTotal As Double = 0
            Dim dblCreditsTotal As Double = 0
            For i As Integer = 0 To .RowCount - 1
                If Not Object.Equals(.Rows(i).Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(i).Cells(3).Value.ToString) Then
                        If IsNumeric(.Rows(i).Cells(3).Value.ToString) Then
                            dblDebitsTotal = dblDebitsTotal + CDbl(.Rows(i).Cells(3).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(i).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(i).Cells(4).Value.ToString) Then
                        If IsNumeric(.Rows(i).Cells(4).Value.ToString) Then
                            dblCreditsTotal = dblCreditsTotal + CDbl(.Rows(i).Cells(4).Value.ToString)
                        End If
                    End If
                End If
            Next
            lblDebits.Text = Format(dblDebitsTotal, "#,##0.00")
            lblCredits.Text = Format(dblCreditsTotal, "#,##0.00")
            lblBalance.Text = Format((dblDebitsTotal - dblCreditsTotal), "#,##0.00")
        End With

        With dGridTrustTransactions
            Dim dblDebitsTotal As Double = 0
            Dim dblCreditsTotal As Double = 0
            For i As Integer = 0 To .RowCount - 1
                If Not Object.Equals(.Rows(i).Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(i).Cells(3).Value.ToString) Then
                        If IsNumeric(.Rows(i).Cells(3).Value.ToString) Then
                            dblDebitsTotal = dblDebitsTotal + CDbl(.Rows(i).Cells(3).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(.Rows(i).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(i).Cells(4).Value.ToString) Then
                        If IsNumeric(.Rows(i).Cells(4).Value.ToString) Then
                            dblCreditsTotal = dblCreditsTotal + CDbl(.Rows(i).Cells(4).Value.ToString)
                        End If
                    End If
                End If
            Next
            lblTdebits.Text = Format(dblDebitsTotal, "#,##0.00")
            lblTcredits.Text = Format(dblCreditsTotal, "#,##0.00")
        End With

    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        If UCase(strUserLevel) <> "ADMINISTRATOR" Then
            If UCase(strUserLevel) <> "MANAGER" Then
                MessageBox.Show("You do not have authority to edit this record", "Unauthorised Access Stopped", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
        End If
        With dGrid
            If .RowCount <= 0 Then Exit Sub
            If Not Object.Equals(.CurrentRow.Cells(6).Value, Nothing) Then
                If IsNumeric(.CurrentRow.Cells(6).Value.ToString) Then
                    intSelectedTransaction = CInt(.CurrentRow.Cells(6).Value.ToString)
                    boolAbort = False
                    Dim frm As New frmLegalTransactionEdit
                    frm.ShowDialog()
                    If boolAbort = False Then
                        LoadTransactions()
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub dGridPlans_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridPlans.DoubleClick
        If dGridPlans.Rows.Count <= 0 Then Exit Sub
        intSelectedTransaction = CInt(dGridPlans.CurrentRow.Cells(5).Value.ToString)
        boolEditStatus = True
        Dim frm As New frmLegalPaymentPlanTerms
        frm.ShowDialog()
        LoadPaymentPlans()
    End Sub

    Private Sub btnAddPlan_Click(sender As System.Object, e As System.EventArgs) Handles btnAddPlan.Click
        Dim boolPriorStatus As Boolean = boolEditStatus
        boolEditStatus = False
        Dim f As New frmLegalPaymentPlanTerms
        f.ShowDialog()
        boolEditStatus = boolPriorStatus
        LoadPaymentPlans()
    End Sub

    Private Sub btnNewInventory_Click(sender As System.Object, e As System.EventArgs) Handles btnNewInventory.Click
        dGridInventories.Rows.Add(1)
    End Sub

    Private Sub SaveInventories()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM DefendantInventories " _
            & "WHERE DefendantId = '" & strSelectedAccount & "'", cnn)
        objCommand.ExecuteNonQuery()
        With dGridInventories
            For i As Integer = 0 To .Rows.Count - 1
                Dim strDescription As String = Nothing
                Dim dblValue As Double = 0
                If Not Object.Equals(.Rows(i).Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(i).Cells(0).Value.ToString) Then
                        strDescription = .Rows(i).Cells(0).Value.ToString
                    End If
                End If
                If Not Object.Equals(.Rows(i).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(i).Cells(1).Value.ToString) Then
                        If IsNumeric(.Rows(i).Cells(1).Value.ToString) Then
                            dblValue = CDbl(.Rows(i).Cells(1).Value.ToString)
                        End If
                    End If
                End If
                If Not String.IsNullOrEmpty(strDescription) Then
                    Dim strSql As String = "INSERT INTO DefendantInventories (DefendantId, Description, Value, UserName) VALUES " _
                        & "('" & txtDefendantId.Text & "', '" & strDescription & "', " & dblValue & ", '" & strUserName & "')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            Next
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Inventory Items Addition"
        ShowErrorMessage()
    End Sub

    Private Sub btnDeleteInventory_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteInventory.Click
        If dGridInventories.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        If MessageBox.Show("Are sure you want to delete this record", "Confirm Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM DefendantInventories " _
                & "WHERE TransactionId = " & CInt(dGridInventories.CurrentRow.Cells(2).Value.ToString) & "", cnn)
            objCommand.ExecuteNonQuery()
            LoadDefendentInventories()
            MessageBox.Show("Record has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Inventory Items Delete"
        ShowErrorMessage()
    End Sub

    Private Sub LoadDefendentInventories()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Description, Value, TransactionId FROM DefendantInventories " _
            & "WHERE DefendantId = '" & strSelectedAccount & "' ORDER BY Description"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridInventories.Rows.Clear()
        Dim dblEstimatedValue As Double = 0
        While objReader.Read
            dGridInventories.Rows.Add(objReader(0), objReader(1), objReader(2))
            If IsNumeric(objReader(1).ToString) Then
                dblEstimatedValue = dblEstimatedValue + CDbl(objReader(1).ToString)
            End If
        End While
        objReader.Close()
        txtEstimatedValue.Text = Format(dblEstimatedValue, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Defendant Inventory Items Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnSaveInventory_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveInventory.Click
        boolAbort = False
        SaveInventories()
        If boolAbort = True Then Exit Sub
        MessageBox.Show("Defendant Inventories have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
