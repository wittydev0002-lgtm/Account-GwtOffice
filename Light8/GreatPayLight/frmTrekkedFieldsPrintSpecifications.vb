Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmTrekkedFieldsPrintSpecifications

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadCodeDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT SystemCodes.Description +';'+ CONVERT(NVARCHAR, " _
            & "SystemTrakkedFields.CodeNo) AS [CodeDetails] FROM SystemCodes, " _
            & "SystemTrakkedFields WHERE SystemTrakkedFields.CodeNo = SystemCodes.CodeNo " _
            & "AND SystemTrakkedFields.CodeNo > 0 ORDER BY SystemCodes.Description"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboCode
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "250;60"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT COUNT(SystemTrakkedFields.CodeNo) FROM " _
            & "SystemTrakkedFields WHERE SystemTrakkedFields.CodeNo > 0", cnn)
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
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboCode.SelectedIndex = -1
            cboCode.Items.Clear()
            cboCode.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboCode.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Trekked Codes Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCode.SelectedIndexChanged
        If cboCode.Focused = False Then Exit Sub
        If Not cboCode.SelectedItem Is Nothing Then
            lblCode.Text = cboCode.SelectedItem.Col2
            txtPeriodFrom.Focus()
        Else
            lblCode.Text = ""
        End If
    End Sub

    Private Sub txtPeriodFrom_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeriodFrom.GotFocus
        txtPeriodFrom.SelectAll()
    End Sub

    Private Sub txtPeriodTo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeriodTo.GotFocus
        txtPeriodTo.SelectAll()
    End Sub

    Private Sub txtPeriodTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeriodTo.KeyPress
        If Asc(e.KeyChar) = 13 Then txtEndYear.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtReportHeading_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReportHeading.GotFocus
        txtReportHeading.SelectAll()
    End Sub

    Private Sub txtReportHeading_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReportHeading.KeyPress
        If Asc(e.KeyChar) = 13 Then chkDrawGraph.Focus()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(lblCode.Text) Then
            MessageBox.Show("Please select the code to analyse and report on from the provided list", _
                "Invalid Analysis Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCode.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtPeriodFrom.Text) Then
            MessageBox.Show("Please specify the period to start analysing from", _
                "Missing Start Period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPeriodFrom.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtPeriodTo.Text) Then
            MessageBox.Show("Please specify the period to analysing to", _
                "Missing End Period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPeriodTo.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtEndYear.Text) Then
            MessageBox.Show("Please specify the end year to analyse to", _
                "Missing End Year", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEndYear.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtReportHeading.Text) Then
            MessageBox.Show("Please enter the report header", _
                "Invalid Report Header", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtReportHeading.Focus()
            Exit Sub
        End If

        'Check that the periods do not overlap to more than 6 months
        Dim strStartPeriod As String = "01-" & gwt_comm.getMonth(CInt(txtPeriodFrom.Text)) & "-" & txtEndYear.Text
        Dim strEndPeriod As String = "01-" & gwt_comm.getMonth(CInt(txtPeriodTo.Text)) & "-" & txtEndYear.Text

        Dim intMonths As Integer = DateDiff(DateInterval.Month, CDate(strStartPeriod), CDate(strEndPeriod))
        If intMonths > 6 Then
            MessageBox.Show("You can only analyse six periods at any given time. Please reduce your analyses accordingly", _
                "Analyses Periods Exceeded Limit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If chkDrawGraph.Checked = True Then boolDrawGraph = True Else boolDrawGraph = False
        intTrekkedCode = CInt(lblCode.Text)
        intTrekPeriodFrom = CInt(txtPeriodFrom.Text)
        intTrekPeriodTo = CInt(txtPeriodTo.Text)
        intTrekYear = CInt(txtEndYear.Text)
        strTrekkedFieldsHeader = UCase(txtReportHeading.Text)
        Me.Hide()
        Me.Close()
    End Sub

    Private Sub txtStartYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then txtPeriodTo.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtEndYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEndYear.KeyPress
        If Asc(e.KeyChar) = 13 Then txtReportHeading.Focus()
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub frmTrekkedFieldsPrintSpecifications_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadCodeDetails()
    End Sub

End Class
