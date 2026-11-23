Public Class frmTransactionEntry

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If IsNumeric(dGrid.CurrentCell.Value) Then
            dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")
        End If
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

    Private Sub frmTransactionEntry_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadCodes()
        LoadEmployees()
        If boolEmployeeCall = True Then
            cboPersonnel.Text = strSelectedEmployee
            lblId.Text = intSelectedTransactionId
            cboPersonnel.Enabled = False
        Else
            cboPersonnel.Enabled = True
            lblId.Text = intSelectedTransactionId
            cboPersonnel.Text = strSelectedDirectorDetails
        End If
        If boolEditStatus = True Then LoadSelectedTransactionData()
    End Sub

    Private Sub LoadSelectedTransactionData()
        'intSelectedTransactionId
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        'Description, Amount and Code {{Payments.DirectorId}}
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Payments.TransDate, " _
            & "EmployeeMaster.LastName +' '+ EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames AS [Director], " _
            & "Payments.PayCode, Payments.Purpose, Payments.Amount " _
            & "FROM Payments, EmployeeMaster WHERE TransId = " & intSelectedTransactionId & " AND " _
            & "Payments.DirectorId = EmployeeMaster.TransactionId", cnn)
        Dim objReader As OleDb.OleDbDataReader = objCommand.ExecuteReader

        While objReader.Read

            If IsDate(objReader("TransDate").ToString) Then dpTransDate.Value = CDate(objReader("TransDate").ToString)
            If Not IsDBNull(objReader("Director").ToString) Then cboPersonnel.Text = objReader("Director").ToString
            If Not IsDBNull(objReader("Purpose").ToString) Then txtPurpose.Text = objReader("Purpose").ToString

            'Get the code description
            Dim strCodeDescription As String = Nothing
            objCommand = New Data.OleDb.OleDbCommand("SELECT Description FROM PaymentCodes " _
                & "WHERE CodeNo = " & objReader("PayCode").ToString & "", cnn)
            Dim objReadCode As OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReadCode.Read
                If Not IsDBNull(objReadCode(0).ToString) Then strCodeDescription = objReadCode(0).ToString
                Exit While
            End While
            objReadCode.Close()

            dGrid.Rows.Clear()
            dGrid.Rows.Add(strCodeDescription, objReader("Amount"), objReader("PayCode"))

        End While
        objReader.Close()

        cboPersonnel.Enabled = False

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on selected payments load"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        'boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadCodes()
        On Error GoTo RaiseErr
        Dim myCommand As New Data.OleDb.OleDbCommand("SELECT Description, CodeNo " _
            & "FROM PaymentCodes ORDER BY Description", cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
        dGrid.Rows.Clear()
        While dbReader.Read
            dGrid.Rows.Add(dbReader(0), "0.00", dbReader(1))
        End While
        dbReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on payment codes load"
        ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(cboPersonnel.Text) Then
            MessageBox.Show("Please select the employee to which transactions will be posted", "Transaction Capture Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboPersonnel.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtPurpose.Text) Then
            MessageBox.Show("Please type in the purpose of the transaction", "Transaction Capture Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPurpose.Focus()
            Exit Sub
        End If
        If boolEditStatus = False Then
            SaveAsNew()
        Else
            UpdateTransaction()
        End If
    End Sub

    Private Sub UpdateTransaction()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(1).Value.ToString) Then
                    If CDbl(dGrid.Rows(i).Cells(1).Value.ToString) <> 0 Then
                        Dim intDirectorId As Integer = CInt(lblId.Text)
                        Dim intCode As Integer = CInt(dGrid.Rows(i).Cells(2).Value.ToString)
                        Dim dblAmount As Double = CDbl(dGrid.Rows(i).Cells(1).Value.ToString)
                        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE Payments " _
                            & "SET TransDate = '" & Format(CDate(dpTransDate.Value), "dd-MMM-yyyy") & "', " _
                            & "DirectorId = " & intDirectorId & ", PayCode = " & intCode & ", " _
                            & "Purpose = '" & txtPurpose.Text & "', Amount = " & dblAmount & ", " _
                            & "Status = 'PENDING' WHERE TransId = " & intSelectedTransactionId & "", cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                End If
            End If
        Next
        MessageBox.Show("Transaction entry saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If boolEmployeeCall = False Then
            LoadCodes()
            cboPersonnel.Text = ""
            txtPurpose.Text = ""
            cboPersonnel.Focus()
        End If
        Cursor = Cursors.Default
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on payment transactions save"
        ShowErrorMessage()
    End Sub

    Private Sub SaveAsNew()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                If IsNumeric(dGrid.Rows(i).Cells(1).Value.ToString) Then
                    If CDbl(dGrid.Rows(i).Cells(1).Value.ToString) <> 0 Then
                        Dim intDirectorId As Integer = CInt(lblId.Text)
                        Dim intCode As Integer = CInt(dGrid.Rows(i).Cells(2).Value.ToString)
                        Dim dblAmount As Double = CDbl(dGrid.Rows(i).Cells(1).Value.ToString)
                        Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO Payments " _
                            & "(TransDate, DirectorId, PayCode, Purpose, Amount, Status) VALUES " _
                            & "('" & Format(CDate(dpTransDate.Value), "dd-MMM-yyyy") & "', " _
                            & "" & intDirectorId & ", " & intCode & ", '" & txtPurpose.Text & "', " _
                            & "" & dblAmount & ", 'PENDING')", cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                End If
            End If
        Next
        MessageBox.Show("Transaction entry saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        If boolEmployeeCall = False Then
            LoadCodes()
            cboPersonnel.Text = ""
            txtPurpose.Text = ""
            cboPersonnel.Focus()
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on payment transactions save"
        ShowErrorMessage()
    End Sub

    Private Sub LoadEmployees()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim arrItems As New ArrayList

        Dim intWidth As Integer = cboPersonnel.Width
        strSql = "SELECT LastName +' '+FirstName +' '+ OtherNames +';'+ CONVERT(NVARCHAR, TransactionId) AS " _
            & "[Personnel] FROM EmployeeMaster ORDER BY LastName"
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
        strErrorMessages = Err.Description & " " & Err.Number & " on Personnel Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboPersonnel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPersonnel.SelectedIndexChanged
        lblId.Text = ""
        lblId.Text = cboPersonnel.SelectedItem.Col2
    End Sub

    Private Sub txtPurpose_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPurpose.KeyPress
        If e.KeyChar = "'" Or Asc(e.KeyChar) = 34 Or e.KeyChar = "|" Or e.KeyChar = "~" Then e.Handled = True
    End Sub

End Class
