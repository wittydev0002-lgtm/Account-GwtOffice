Public Class frmSettings

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGridTaxes_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridTaxes.CellEndEdit
        If IsNumeric(dGridTaxes.CurrentCell.Value) Then
            dGridTaxes.CurrentCell.Value = Format(CDbl(dGridTaxes.CurrentCell.Value.ToString), "##0.00")
        End If
    End Sub

    Private Sub dGridTaxes_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGridTaxes.EditingControlShowing
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

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        boolEditStatus = False
        Dim f As New frmPaymentCodeSetup
        f.ShowDialog()
        LoadPaymentCodes()
    End Sub

    Private Sub LoadPaymentCodes()
        On Error GoTo RaiseErr
        Dim myCommand As New Data.OleDb.OleDbCommand("SELECT Description, PayType, TaxType, CodeNo, GrossUpStatus " _
            & "FROM PaymentCodes ORDER BY Description", cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
        dGrid.Rows.Clear()
        While dbReader.Read
            dGrid.Rows.Add(dbReader(0), dbReader(1), dbReader(2), dbReader(3), dbReader(4))
        End While
        dbReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCritical & "On Company Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        chkGrossUpTax.Checked = False
        Dim myCommand As New Data.OleDb.OleDbCommand("SELECT * FROM Company", cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
        While dbReader.Read
            If Not IsDBNull(dbReader("CompanyName").ToString) Then txtCoyName.Text = dbReader("CompanyName").ToString Else txtCoyName.Text = ""
            If Not IsDBNull(dbReader("Address1").ToString) Then txtAddress1.Text = dbReader("Address1").ToString Else txtAddress1.Text = ""
            If Not IsDBNull(dbReader("Address2").ToString) Then txtAddress2.Text = dbReader("Address2").ToString Else txtAddress2.Text = ""
            If Not IsDBNull(dbReader("Address3").ToString) Then txtAddress3.Text = dbReader("Address3").ToString Else txtAddress3.Text = ""
            If Not IsDBNull(dbReader("Address4").ToString) Then txtAddress4.Text = dbReader("Address4").ToString Else txtAddress4.Text = ""
            If Not IsDBNull(dbReader("Telephone").ToString) Then txtTelephone.Text = dbReader("Telephone").ToString Else txtTelephone.Text = ""
            If Not IsDBNull(dbReader("EmailAddress").ToString) Then txtEmailAddress.Text = dbReader("EmailAddress").ToString Else txtEmailAddress.Text = ""
            If Not IsDBNull(dbReader("PayeNumber").ToString) Then txtPayeNumber.Text = dbReader("PayeNumber").ToString Else txtPayeNumber.Text = ""
            If IsNumeric(dbReader("SittingCodeNo").ToString) Then
                lblId.Text = dbReader("SittingCodeNo").ToString
                cboPersonnel.Text = CodeDescription(CInt(dbReader("SittingCodeNo").ToString))
            End If
            If Not IsDBNull(dbReader("TaxGrossing").ToString) Then
                If UCase(dbReader("TaxGrossing").ToString) = "YES" Then
                    chkGrossUpTax.Checked = True
                Else
                    chkGrossUpTax.Checked = False
                End If
            End If
        End While
        dbReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCritical & "On Company Details Load"
        ShowErrorMessage()
    End Sub

    Private Function CodeDescription(CodeNo As Integer) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim myCommand As New Data.OleDb.OleDbCommand("SELECT Description FROM PaymentCodes WHERE CodeNo = " & CodeNo & "", cnn)
        Dim objReader As OleDb.OleDbDataReader = myCommand.ExecuteReader()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
            Exit While
        End While
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCritical & "On Company Details Load"
        ShowErrorMessage()
    End Function

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        GetSelected()
    End Sub

    Private Sub DeletePaymentCode()
        If dGrid.Rows.Count > 0 Then
            If MessageBox.Show("Are you sure you want to delete the selected record?", "Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                intSelectedTransactionId = CInt(dGrid.CurrentRow.Cells(3).Value.ToString)
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM PaymentCodes WHERE CodeNo = " & intSelectedTransactionId & "", cnn)
                objCommand.ExecuteNonQuery()
                MessageBox.Show("Record hase been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadPaymentCodes()
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        DeletePaymentCode()
    End Sub

    Private Sub SaveDetails()
        On Error GoTo RaiseErr
        boolAbort = False
        Dim myCommand As Data.OleDb.OleDbCommand
        If Me.txtCoyName.Text = "" Or Mid(txtCoyName.Text, 1, 1) = " " Then
            MessageBox.Show("Please enter a valid name for company. No spaces or names begining with spaces", _
                "Invalid Company Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCoyName.Focus()
            Exit Sub
        End If
        If txtAddress1.Text = "" Or Mid(txtAddress1.Text, 1, 1) = " " Then
            MessageBox.Show("Please enter a valid address for the company. No spaces or addresses begining with spaces", _
                "Invalid Address Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If

        Dim strGrossUp As String = "YES"
        If chkGrossUpTax.Checked = False Then strGrossUp = "NO"

        Dim intSittingCode As Integer = 0
        If IsNumeric(lblId.Text) Then intSittingCode = CInt(lblId.Text)

        Cursor = Cursors.WaitCursor
        myCommand = New Data.OleDb.OleDbCommand("DELETE FROM Company", cnn)
        myCommand.ExecuteNonQuery()
        myCommand = New Data.OleDb.OleDbCommand("INSERT INTO Company (CompanyName, Address1, Address2, " _
            & "Address3, Address4, Telephone, EmailAddress, " _
            & "PayeNumber, TaxGrossing, SittingCodeNo) VALUES " _
            & "('" & txtCoyName.Text & "', '" & txtAddress1.Text & "', '" & txtAddress2.Text & "', " _
            & "'" & txtAddress3.Text & "', '" & txtAddress4.Text & "', '" & txtTelephone.Text & "', " _
            & "'" & txtEmailAddress.Text & "', " _
            & "'" & txtPayeNumber.Text & "', '" & strGrossUp & "', " & intSittingCode & ")", cnn)
        myCommand.ExecuteNonQuery()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Company Details Maintenance"
        ShowErrorMessage()
    End Sub

    Private Sub txtCoyName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCoyName.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then
            txtAddress1.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtAddress1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress1.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then
            txtAddress2.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtAddress2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress2.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then
            txtAddress3.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtAddress4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress4.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then
            txtTelephone.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtAddress3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress3.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then
            txtAddress4.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtEmailAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailAddress.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then
            txtPayeNumber.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtEmailAddress_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEmailAddress.Validating
        If Not String.IsNullOrEmpty(txtEmailAddress.Text) Then
            If IsEmailAddress(txtEmailAddress.Text) = False Then
                MessageBox.Show("Invalid email address", "Invalid Email Adrress", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtEmailAddress.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtTelephone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelephone.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then
            txtEmailAddress.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtPayeNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPayeNumber.KeyPress
        If e.KeyChar = ";" Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
        If Asc(e.KeyChar) = 13 Then
            btnSave.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub frmSettings_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadPaymentCodes()
        LoadTaxTables()
        LoadCodes()
        LoadData()
        LoadUsers()
    End Sub

    Private Sub LoadUsers()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT UserName FROM Users ORDER BY UserName", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridUsers.Rows.Clear()
        While objReader.Read
            dGridUsers.Rows.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On User Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub GetSelected()
        If Not Object.Equals(Convert.ToString(dGrid.CurrentRow.Cells(3).Value), "") Then
            If IsNumeric(dGrid.CurrentRow.Cells(3).Value.ToString) Then
                intSelectedTransactionId = CInt(dGrid.CurrentRow.Cells(3).Value.ToString)
                boolEditStatus = True
                Dim f As New frmPaymentCodeSetup
                f.ShowDialog()
                LoadPaymentCodes()
            End If
        End If
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        GetSelected()
    End Sub

    Private Sub txtBands_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBands.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then dGridTaxes.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtBands_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBands.Validating
        On Error Resume Next
        If IsNumeric(txtBands.Text) Then
            If CInt(txtBands.Text) > 0 Then
                If dGridTaxes.Rows.Count > 0 Then
                    Dim i As Integer = dGridTaxes.Rows.Count
                    dGridTaxes.Rows.Add(CInt(txtBands.Text) - i)
                Else
                    dGridTaxes.Rows.Clear()
                    dGridTaxes.Rows.Add(CInt(txtBands.Text))
                End If
                For n As Integer = 1 To dGridTaxes.Rows.Count - 1
                    dGridTaxes.Rows(n - 1).Cells(0).Value = Format(n, "00")
                Next
            End If
        End If
    End Sub

    Private Sub LoadTaxTables()

        'Create the tax table if it does not exist
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As OleDb.OleDbDataReader

        Dim strSql As String = "CREATE TABLE SystemTaxTables ([Band] [int] NOT NULL PRIMARY KEY, " _
            & "[Minima] [Float] NOT NULL DEFAULT 0, [Maxima][float] NOT NULL DEFAULT 0, " _
            & "[Rate][float] NOT NULL DEFAULT 0, [BaseDeduction][float] NOT NULL DEFAULT 0)"

        If TableExists("SystemTaxTables") = False Then
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        'Update the company table for tax grossing

        If CheckColumnExistence("Company", "TaxGrossing") = False Then
            strSql = "ALTER TABLE Company ADD [TaxGrossing][NVARCHAR] (3) NOT NULL DEFAULT 'NO'"
            Dim dbCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            dbCommand.ExecuteNonQuery()
        End If

        'Add also the column that identifies the sitting fees Code Id that is taxed at 20%
        If CheckColumnExistence("Company", "SittingCodeNo") = False Then
            strSql = "ALTER TABLE Company ADD [SittingCodeNo][INT] NOT NULL DEFAULT 0"
            Dim dbCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            dbCommand.ExecuteNonQuery()
        End If

        'Read the data from the database
        objCommand = New Data.OleDb.OleDbCommand("SELECT Band, Minima, Maxima, Rate, BaseDeduction " _
            & "FROM SystemTaxTables ORDER BY Band", cnn)
        objReader = objCommand.ExecuteReader

        dGridTaxes.Rows.Clear()

        While objReader.Read
            dGridTaxes.Rows.Add(1)
            If IsNumeric(objReader(0).ToString) Then dGridTaxes.Rows(dGridTaxes.Rows.Count - 1).Cells(0).Value = Format(CDbl(objReader(0).ToString), "##0.00")
            If IsNumeric(objReader(1).ToString) Then dGridTaxes.Rows(dGridTaxes.Rows.Count - 1).Cells(1).Value = Format(CDbl(objReader(1).ToString), "##0.00")
            If IsNumeric(objReader(2).ToString) Then dGridTaxes.Rows(dGridTaxes.Rows.Count - 1).Cells(2).Value = Format(CDbl(objReader(2).ToString), "##0.00")
            If IsNumeric(objReader(3).ToString) Then dGridTaxes.Rows(dGridTaxes.Rows.Count - 1).Cells(3).Value = Format(CDbl(objReader(3).ToString), "##0.00")
            If IsNumeric(objReader(4).ToString) Then dGridTaxes.Rows(dGridTaxes.Rows.Count - 1).Cells(4).Value = Format(CDbl(objReader(4).ToString), "##0.00")
        End While

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Tax Tables Setup"
        ShowErrorMessage()
    End Sub

    Private Sub SaveTaxTables()
        On Error GoTo RaiseErr
        Dim sqlCommand As Data.OleDb.OleDbCommand
        If dGridTaxes.Rows.Count > 0 Then
            sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemTaxTables", cnn)
            sqlCommand.ExecuteNonQuery()
            For n As Integer = 0 To dGridTaxes.Rows.Count - 1
                Dim strLineNumber As String = "0"
                Dim strValueMinima As String = "0"
                Dim strValueMaxima As String = "0"
                Dim strBaseDeduction As String = "0"
                Dim strRate As String = "0"
                If Not (Object.Equals(Convert.ToString(dGridTaxes.Rows(n).Cells(0).Value), "")) Then
                    If IsNumeric(dGridTaxes.Rows(n).Cells(0).Value.ToString) Then
                        strLineNumber = dGridTaxes.Rows(n).Cells(0).Value.ToString
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(dGridTaxes.Rows(n).Cells(1).Value), "")) Then
                    If IsNumeric(dGridTaxes.Rows(n).Cells(1).Value.ToString) Then
                        strValueMinima = dGridTaxes.Rows(n).Cells(1).Value.ToString
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(dGridTaxes.Rows(n).Cells(2).Value), "")) Then
                    If IsNumeric(dGridTaxes.Rows(n).Cells(2).Value.ToString) Then
                        strValueMaxima = dGridTaxes.Rows(n).Cells(2).Value.ToString
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(dGridTaxes.Rows(n).Cells(3).Value), "")) Then
                    If IsNumeric(dGridTaxes.Rows(n).Cells(3).Value.ToString) Then
                        strRate = dGridTaxes.Rows(n).Cells(3).Value.ToString
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(dGridTaxes.Rows(n).Cells(4).Value), "")) Then
                    If IsNumeric(dGridTaxes.Rows(n).Cells(4).Value.ToString) Then
                        strBaseDeduction = dGridTaxes.Rows(n).Cells(4).Value.ToString
                    End If
                End If
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemTaxTables " _
                    & "(Band, Minima, Maxima, Rate, BaseDeduction) VALUES " _
                    & "(" & (n + 1) & ", " & strValueMinima & ", " _
                    & "" & strValueMaxima & ", " & strRate & ", " & strBaseDeduction & ")", cnn)
                sqlCommand.ExecuteNonQuery()
            Next n
        End If
        MsgBox("Tax Tables have been updated successfully !!!", MsgBoxStyle.Information, "Tax Tables Update")
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Tax Tables Setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        boolAbort = False
        SaveDetails()
        If boolAbort = True Then Exit Sub
        SaveTaxTables()
        If boolAbort = True Then Exit Sub
        GetTaxTables()
        AssignCompanyDetails()
    End Sub

    Private Sub LoadCodes()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim arrItems As New ArrayList

        Dim intWidth As Integer = cboPersonnel.Width
        strSql = "SELECT Description +';'+ CONVERT(NVARCHAR, CodeNo) AS " _
            & "[Personnel] FROM PaymentCodes ORDER BY Description"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                arrItems.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        'Set up the drop down combo box
        With cboPersonnel
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth & ";0"
        End With

        Dim DropDownItems(arrItems.Count - 1) As MTGCComboBoxItem

        cboPersonnel.Items.Clear()

        For i As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(i).ToString, ";")
            DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        If arrItems.Count > 0 Then
            cboPersonnel.SelectedIndex = -1
            cboPersonnel.Items.Clear()
            cboPersonnel.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboPersonnel.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payment Code Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboPersonnel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPersonnel.SelectedIndexChanged
        lblId.Text = ""
        lblId.Text = cboPersonnel.SelectedItem.Col2
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnDeleteUser_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteUser.Click
        If dGridUsers.Rows.Count <= 1 Then
            MessageBox.Show("You must have at least two users set up before you can delete one", "Process Abort", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        Else
            If MessageBox.Show("Are you sure you want to delete this user?", "Confirm User Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim strSelectedUser As String = Nothing
                If Not Object.Equals(dGridUsers.CurrentRow.Cells(0).Value, Nothing) Then
                    strSelectedUser = dGridUsers.CurrentRow.Cells(0).Value.ToString
                    Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM Users WHERE UserName = '" & strSelectedUser & "'", cnn)
                    objCommand.ExecuteNonQuery()
                    MessageBox.Show("User has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadUsers()
                End If
            End If
        End If
    End Sub

    Private Sub btnAddUser_Click(sender As System.Object, e As System.EventArgs) Handles btnAddUser.Click
        boolEditStatus = False
        Dim frm As New frmUserSetup
        frm.ShowDialog()
        LoadUsers()
    End Sub

    Private Sub btnEditUser_Click(sender As System.Object, e As System.EventArgs) Handles btnEditUser.Click
        boolEditStatus = True
        Dim frm As New frmUserSetup
        frm.ShowDialog()
        LoadUsers()
    End Sub

End Class
