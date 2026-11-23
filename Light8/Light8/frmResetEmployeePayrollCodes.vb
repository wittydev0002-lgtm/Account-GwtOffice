Imports ComponentFactory.Krypton.Toolkit

Public Class frmResetEmployeePayrollCodes

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(cboCode.Text) Then
            MessageBox.Show("Please enter a numeric value for the payroll code", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCode.Focus()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("UPDATE EmployeeCodes SET Amount = 0 WHERE CodeNo = " & CInt(cboCode.Text) & "", cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Payroll code reset to zero successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        lblDescription.Text = "" : cboCode.Focus()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On payroll code value reset"
        ShowErrorMessage()
    End Sub

    Private Sub frmResetEmployeePayrollCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub cboCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCode.SelectedIndexChanged
        lblDescription.Text = ""
        If Not cboCode.SelectedItem Is Nothing Then
            lblDescription.Text = cboCode.SelectedItem.Col2
        End If
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT CONVERT(NVARCHAR, CodeNo) +';'+ Description  AS " _
            & "[Accounts] FROM SystemCodes ORDER BY CodeNo"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        Dim intWidth As Integer = cboCode.Width - 80

        With cboCode
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "80;" & intWidth
        End With

        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(CodeNo) FROM SystemCodes", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboCode.Items.Clear()
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
        If intItemsCount > 0 Then
            cboCode.SelectedIndex = -1
            cboCode.Items.Clear()
            cboCode.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCode.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Codes Details Load"
        ShowErrorMessage()
    End Sub

End Class
