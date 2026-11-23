Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmExtraDescriptions

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGrid.EditingControlShowing
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

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex > 0 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please type in the description", "Missing Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a valid amount", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
        If DescriptionExists(txtDescription.Text) = True Then
            MessageBox.Show("An entry with a similar description already exists", "Duplicate Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Focus()
            Exit Sub
        End If
        dGrid.Rows.Add(txtDescription.Text, txtAmount.Text, lblLedgerAccount.Text)
        txtDescription.Clear()
        txtAmount.Text = "0.00"
        lblLedgerAccount.Text = Nothing
        cboContraAccount.Text = ""
        txtDescription.Select()
    End Sub

    Private Sub btnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAll.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_ExtraPaymentDescriptions", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strDescription As String = Nothing
            Dim dblAmount As Double = 0
            Dim strLedgerAccount As String = Nothing
            If Not Object.Equals(dGrid.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(0).Value.ToString) Then
                    strDescription = dGrid.Rows(i).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(1).Value.ToString) Then
                        dblAmount = CDbl(dGrid.Rows(i).Cells(1).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    strLedgerAccount = dGrid.Rows(i).Cells(2).Value.ToString
                End If
            End If
            Dim strSql As String = "INSERT INTO SC_ExtraPaymentDescriptions (Description, Amount, LedgerAccount) VALUES " _
                & "('" & strDescription & "', " & dblAmount & ", '" & strLedgerAccount & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Next
        MessageBox.Show("Details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Extra Payment Descriptions Setup"
        ShowErrorMessage()
    End Sub

    Private Function DescriptionExists(ByVal Description As String) As Boolean
        Dim boolReturn As Boolean = False
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(0).Value.ToString) Then
                    If UCase(dGrid.Rows(i).Cells(0).Value.ToString) = UCase(Description) Then
                        boolReturn = True
                        Exit For
                    End If
                End If
            End If
        Next
        Return boolReturn
    End Function

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Description, Amount, LedgerAccount FROM SC_ExtraPaymentDescriptions ORDER BY Description"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Extra Payment Descriptions Setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmExtraDescriptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
        LoadLedgerAccounts()
    End Sub

    Private Sub LoadLedgerAccounts()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT AccountName +';'+AccountNumber AS " _
            & "[Accounts] FROM LedgerAccounts WHERE AccountType = 'INCOME' ORDER BY AccountName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboContraAccount
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "260;100"
        End With

        Dim arrItems As New ArrayList
        arrItems.Add("--NONE--; ")
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                arrItems.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Dim intItemsCount As Integer = arrItems.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboContraAccount.Items.Clear()
        
        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        If intItemsCount > 0 Then
            cboContraAccount.SelectedIndex = -1
            cboContraAccount.Items.Clear()
            cboContraAccount.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboContraAccount.Items.AddRange(DropDownItems)
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Ledger Account Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmExtraDescriptions_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        '545, 503
        Me.Width = 545
        Me.Height = 503
    End Sub

    Private Sub txtDescription_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDescription.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtAmount.Select()
        End If
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnAdd.Focus()
        End If
    End Sub

    Private Sub cboContraAccount_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboContraAccount.SelectedIndexChanged
        lblLedgerAccount.Text = Nothing
        lblLedgerAccount.Text = cboContraAccount.SelectedItem.Col2
    End Sub

End Class