Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMocRemovals

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadDefaulters()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT CaseNo +';'+ Defendant AS " _
            & "[Accounts] FROM MocCases ORDER BY Defendant"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        Dim intWidth1 As Integer = cboAccountHolder.Width - 100
        With cboAccountHolder
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "100;" & intWidth1
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(CaseNo) FROM MocCases", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboAccountHolder.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
            p = p + 1
        End While
        objReader.Close()
        With cboAccountHolder
            If intItemsCount > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on debtors Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmMocRemovals_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dGrid.Rows.Add(50)
        LoadDefaulters()
        If boolEditStatus = True Then
            LoadSelectedData()
        End If
    End Sub

    Private Sub LoadSelectedData()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = "SELECT * FROM MocAttachmentMains WHERE CaseNo = '" & strSelectedAccount & "' " _
            & "AND Sequence = " & intSelectedBatchNumber & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReadMain As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReadMain.HasRows Then
            objReadMain.Read()
            If Not IsDBNull(objReadMain("CaseNo").ToString) Then cboAccountHolder.Text = objReadMain("CaseNo").ToString
            If IsDate(objReadMain("TransactionDate").ToString) Then dpTransDate.Value = CDate(objReadMain("TransactionDate").ToString)
            If Not IsDBNull(objReadMain("AssistantSheriff").ToString) Then txtAssistantMoc.Text = objReadMain("AssistantSheriff").ToString
            If IsDate(objReadMain("RemovalDueDate").ToString) Then dpRemoval.Value = CDate(objReadMain("RemovalDueDate").ToString)
            If Not IsDBNull(objReadMain("Remarks").ToString) Then cboComments.Text = objReadMain("Remarks").ToString
        End If
        objReadMain.Close()
        'Get the details
        strSql = "SELECT * FROM MocAttachmentDetails WHERE CaseNo = '" & strSelectedAccount & "' AND " _
            & "Sequence = " & intSelectedBatchNumber & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReadDetails As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim i As Integer = 0
        While objReadDetails.Read
            If Not IsDBNull(objReadDetails("Description").ToString) Then dGrid.Rows(i).Cells(0).Value = objReadDetails("Description").ToString
            If Not IsDBNull(objReadDetails("Model").ToString) Then dGrid.Rows(i).Cells(1).Value = objReadDetails("Model").ToString
            If Not IsDBNull(objReadDetails("ItemColor").ToString) Then dGrid.Rows(i).Cells(2).Value = objReadDetails("ItemColor").ToString
            If Not IsDBNull(objReadDetails("Identification").ToString) Then dGrid.Rows(i).Cells(3).Value = objReadDetails("Identification").ToString
            i += 1
        End While
        objReadDetails.Close()
        cboAccountHolder.Enabled = False
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on debtor attachment details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboAccountHolder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountHolder.SelectedIndexChanged
        If Not cboAccountHolder.SelectedItem Is Nothing Then
            txtAccountNumber.Text = cboAccountHolder.SelectedItem.Col2
        Else
            txtAccountNumber.Text = Nothing
        End If
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtAccountNumber.Text) Then
            MessageBox.Show("Please select the case number from the given list", "Missing Case Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccountHolder.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboAccountHolder.Text) Then
            MessageBox.Show("Please select the case number from the given list", "Missing Case Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAccountHolder.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAssistantMoc.Text) Then
            MessageBox.Show("Please the name of the assistant messenger of court", "Missing MOC Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAssistantMoc.Focus()
            Exit Sub
        End If

        Dim strSql As String = Nothing

        Dim objCommand As Data.OleDb.OleDbCommand

        If boolEditStatus = True Then
            'delete the records first
            strSql = "DELETE FROM MocAttachmentMains Where CaseNo = '" & strSelectedAccount & "' AND Sequence = " & intSelectedBatchNumber & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            strSql = "DELETE FROM MocAttachmentDetails Where CaseNo = '" & strSelectedAccount & "' AND Sequence = " & intSelectedBatchNumber & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        Dim intNextNumber As Integer = gwt_comm.GetNextDocumentNumber("Attachments")

        strSql = "INSERT INTO MocAttachmentMains ([CaseNo], [TransactionDate], [AssistantSheriff], " _
                & "[RemovalDueDate], [Remarks], [Sequence], [Stagging]) VALUES ('" & cboAccountHolder.Text & "', " _
                & "'" & Format(dpTransDate.Value, "dd-MMM-yyyy") & "', '" & txtAssistantMoc.Text & "', " _
                & "'" & Format(dpRemoval.Value, "dd-MMM-yyyy") & "', '" & cboComments.Text & "', " _
                & "" & intNextNumber & ", 'REMOVED')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strDescription As String = Nothing
            Dim strColor As String = Nothing
            Dim strModel As String = Nothing
            Dim strIdentification As String = Nothing
            If Not Object.Equals(dGrid.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(0).Value.ToString) Then
                    strDescription = dGrid.Rows(i).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(1).Value.ToString) Then
                    strModel = dGrid.Rows(i).Cells(1).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    strColor = dGrid.Rows(i).Cells(2).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    strIdentification = dGrid.Rows(i).Cells(3).Value.ToString
                End If
            End If
            If Not String.IsNullOrEmpty(strDescription) Then
                strSql = "INSERT INTO MocAttachmentDetails ([CaseNo], [Description], [Model], [ItemColor], " _
                    & "[Identification], [Sequence]) VALUES ('" & cboAccountHolder.Text & "', '" & strDescription & "', " _
                    & "'" & strModel & "', '" & strColor & "', '" & strIdentification & "', " & intNextNumber & ")"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next

        'Update the control numbers
        objCommand = New Data.OleDb.OleDbCommand("UPDATE ControlNumbers SET Attachments = " & intNextNumber + 1 & "", cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on attachments additions"
        ShowErrorMessage()
    End Sub

End Class
