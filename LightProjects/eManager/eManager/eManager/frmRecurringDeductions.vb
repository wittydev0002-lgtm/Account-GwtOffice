Public Class frmRecurringDeductions

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        MessageBox.Show("Reurring transactions set successfully", "Recurring Transaction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On recurring transactions setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmRecurringDeductions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadDirectors()
        LoadPayCodes()
    End Sub

    Private Sub LoadDirectors()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strSql As String

        strSql = "SELECT TransactionId, LastName +' '+ FirstName +' '+ OtherNames as [GivenNames] " _
            & "FROM EmployeeMaster ORDER BY LastName, FirstName, OtherNames"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1))
        End While
        objReader.Close()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On recurring transactions setup"
        ShowErrorMessage()
    End Sub

    Private Sub LoadPayCodes()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
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
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On recurring transactions setup"
        ShowErrorMessage()
    End Sub

End Class
