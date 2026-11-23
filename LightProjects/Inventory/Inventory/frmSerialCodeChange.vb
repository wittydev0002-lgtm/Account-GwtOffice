Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSerialCodeChange

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub SearchForItem()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strSqlReceipts As String = Nothing

        'Search by serial number
        strSqlReceipts = "SELECT SerialNumbers.ItemCode FROM SerialNumbers WHERE SerialNumbers.SerialNumber = '" & txtSerialNumber.Text & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSqlReceipts, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtCurrentCode.Text = objReader(0).ToString
        End If
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Serial Numbers Misallocation changes"
        ShowErrorMessage()
    End Sub

    Private Sub txtSerialNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerialNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not String.IsNullOrEmpty(txtSerialNumber.Text) Then SearchForItem()
        End If
    End Sub

    'Private Sub txtSerialNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerialNumber.TextChanged
    '    If Not String.IsNullOrEmpty(txtSerialNumber.Text) Then SearchForItem()
    'End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor
        Dim strSql As String = Nothing
        strSql = "SELECT ItemCode +';'+GroupName AS " _
            & "[Items] FROM InventoryItems ORDER BY ItemCode"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboItems
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "160;300"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(ItemCode) FROM InventoryItems", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboItems.Items.Clear()
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
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboItems.SelectedIndex = -1
            cboItems.Items.Clear()
            cboItems.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboItems.Items.AddRange(DropDownItems)
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On items data load"
        ShowErrorMessage()
    End Sub

    Private Sub frmSerialCodeChange_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(txtCurrentCode.Text) Then
            If Not String.IsNullOrEmpty(cboItems.Text) Then
                Dim strSql As String = "UPDATE SerialNumbers SET ItemCode = '" & cboItems.Text & "' " _
                    & "WHERE ItemCode = '" & txtCurrentCode.Text & "' AND " _
                    & "SerialNumber = '" & txtSerialNumber.Text & "'"
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                MessageBox.Show("Serial number item code changed successfully", "Item Serial Code Change", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCurrentCode.Clear()
                txtSerialNumber.Clear()
            End If
        Else
            MessageBox.Show("Insufficient input to effect the changes requested", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSerialNumber.Focus()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On item serial number to item code change"
        ShowErrorMessage()
    End Sub

End Class
