Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmColumnReportDesigner

    Dim boolFormLoading As Boolean

    Private Sub frmColumnReportDesigner_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        With dGrid
            .Rows.Add(7)
            .Rows(0).Cells(0).Value = "Captions"
            .Rows(1).Cells(0).Value = "Fields"
            .Rows(2).Cells(0).Value = "Size"
            .Rows(3).Cells(0).Value = "Alignment"
            .Rows(4).Cells(0).Value = "Column Visible"
            .Rows(5).Cells(0).Value = "Format Column"
            .Rows(6).Cells(0).Value = "Column Totals"
            .Columns(0).DefaultCellStyle.BackColor = Color.WhiteSmoke
            For i As Integer = 1 To dGrid.Columns.Count - 1
                dGrid.Rows(1).Cells(i).Value = "0"
            Next
        End With
        LoadCodeDetails()
        If boolEditStatus = True Then LoadData()
        boolFormLoading = False
    End Sub

    Private Sub dGrid_CellValidated(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellValidated
        If e.RowIndex = 2 Then
            If Not IsNumeric(dGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                MessageBox.Show("Value of the cell must be numeric. Value will be changed to default", _
                    "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dGrid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0"
            End If
        End If
    End Sub

    Private Sub dGrid_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellValueChanged
        dGrid.Columns(e.ColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    End Sub

    Private Sub dGrid_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dGrid.ColumnWidthChanged
        On Error GoTo RaiseErr
        If boolFormLoading = True Then Exit Sub
        If e.Column.Index > 0 Then
            cboFields.Width = dGrid.Columns(e.Column.Index).Width
            cboFields.Refresh()
            cboAlignment.Width = dGrid.Columns(e.Column.Index).Width
            cboAlignment.Refresh()
        End If
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Multi column report writer grid sizing error"
        ShowErrorMessage()
    End Sub

    Private Sub cboFields_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFields.LostFocus
        cboFields.Visible = False
    End Sub

    Private Sub cboFields_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFields.SelectedIndexChanged
        If Not cboFields.SelectedItem Is Nothing Then
            If UCase(cboFields.SelectedItem.Col1.ToString) = "SUM" Then
                strMultiColumnFormular = Nothing
                boolAbort = False
                Dim f As New frmMultiColumnReportSummation
                f.ShowDialog()
                If boolAbort = False Then
                    If Not String.IsNullOrEmpty(strMultiColumnFormular) Then
                        dGrid.CurrentCell.Value = strMultiColumnFormular
                    End If
                End If
            Else
                dGrid.CurrentCell.Value = cboFields.SelectedItem.Col1
            End If
        End If
    End Sub

    Private Sub cboAlignment_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlignment.LostFocus
        cboAlignment.Visible = False
    End Sub

    Private Sub cboAlignment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlignment.SelectedIndexChanged
        dGrid.CurrentCell.Value = cboAlignment.SelectedItem.ToString
    End Sub

    Private Sub LoadCodeDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT CONVERT(NVARCHAR, CodeNo) +';'+Description AS [Codes] FROM SystemCodes WHERE Description <> NULL or Description <> '' ORDER BY CodeNo"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboFields
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "60;200"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = 2
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(CodeNo) FROM SystemCodes WHERE Description <> NULL or Description <> ''", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CInt(objCount(0).ToString) + 2
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboFields.Items.Clear()
        Dim i As Integer = 0
        Dim p As Integer = 2
        'Continue to read until you reach the end of the file.
        DropDownItems(0) = New MTGCComboBoxItem("SUM", "COMPUTE MULTIPLE FIELDS")
        DropDownItems(1) = New MTGCComboBoxItem("0", "")
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
            cboFields.SelectedIndex = -1
            cboFields.Items.Clear()
            cboFields.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboFields.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Bank Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEnter
        On Error GoTo RaiseErr
        'cboSerials.Visible = False
        If cboFields.Visible = True Then cboFields.Visible = False
        If e.ColumnIndex > 0 And e.RowIndex = 1 Then
            cboFields.Size = dGrid.CurrentCell.Size
            cboFields.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + 86
            cboFields.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                cboFields.Text = Convert.ToString(dGrid.CurrentCell.Value)
            Else
                cboFields.Text = ""
            End If
            cboFields.Visible = True '152
            cboFields.Focus()
            cboFields.SelectAll()
        End If
        If e.ColumnIndex > 0 And e.RowIndex = 3 Then
            cboAlignment.Size = dGrid.CurrentCell.Size
            cboAlignment.Top = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + 86
            cboAlignment.Left = dGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                cboAlignment.Text = Convert.ToString(dGrid.CurrentCell.Value)
            Else
                cboAlignment.Text = ""
            End If
            cboAlignment.Visible = True '152
            cboAlignment.Focus()
            cboAlignment.SelectAll()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on payroll code search"
        ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        If String.IsNullOrEmpty(txtReportName.Text) Then
            MessageBox.Show("Please enter the report name", "Missing Report Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtReportName.Focus()
            Exit Sub
        End If
        Dim strValues(0 To 25) As String
        Dim objCommand As Data.OleDb.OleDbCommand
        'Start with the report headers
        If boolEditStatus = True Then
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM MultiColumnReportHeaders WHERE ReportNo = " & intSelectedReport & "", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM MultiColumnReportCaptions WHERE ReportNo = " & intSelectedReport & "", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM MultiColumnReportFields WHERE ReportNo = " & intSelectedReport & "", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM MultiColumnReportSizes WHERE ReportNo = " & intSelectedReport & "", cnn)
            objCommand.ExecuteNonQuery()
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM MultiColumnReportAlignments WHERE ReportNo = " & intSelectedReport & "", cnn)
            objCommand.ExecuteNonQuery()
        End If
        'Insert the report header and immediately get the reportnumber
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO MultiColumnReportHeaders(ReportName) VALUES ('" & txtReportName.Text & "')", cnn)
        objCommand.ExecuteNonQuery()
        'Get the allocated report number
        Dim intReport As Integer = 0
        objCommand = New Data.OleDb.OleDbCommand("SELECT ReportNo FROM MultiColumnReportHeaders ORDER BY ReportNo DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intReport = CInt(objReader(0).ToString)
        End If
        objReader.Close()

        'Get the report captions and add them to the database
        '
        For i As Integer = 0 To strValues.Length - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(0).Cells(i + 1).Value), "")) Then
                strValues(i) = dGrid.Rows(0).Cells(i + 1).Value.ToString
            Else
                strValues(i) = ""
            End If
        Next
        strSql = "INSERT INTO MultiColumnReportCaptions (ReportNo, CaptionA, CaptionB, CaptionC, CaptionD, CaptionE, CaptionF, CaptionG, " _
            & "CaptionH, CaptionI, CaptionJ, CaptionK, CaptionL, CaptionM, CaptionN, CaptionO, CaptionP, CaptionQ, CaptionR, " _
            & "CaptionS, CaptionT, CaptionU, CaptionV, CaptionW, CaptionX, CaptionY, CaptionZ) VALUES " _
            & "(" & intReport & ", '" & strValues(0) & "', " _
            & "'" & strValues(1) & "'," _
            & "'" & strValues(2) & "'," _
            & "'" & strValues(3) & "'," _
            & "'" & strValues(4) & "'," _
            & "'" & strValues(5) & "'," _
            & "'" & strValues(6) & "'," _
            & "'" & strValues(7) & "'," _
            & "'" & strValues(8) & "'," _
            & "'" & strValues(9) & "'," _
            & "'" & strValues(10) & "'," _
            & "'" & strValues(11) & "'," _
            & "'" & strValues(12) & "'," _
            & "'" & strValues(13) & "'," _
            & "'" & strValues(14) & "'," _
            & "'" & strValues(15) & "'," _
            & "'" & strValues(16) & "'," _
            & "'" & strValues(17) & "'," _
            & "'" & strValues(18) & "'," _
            & "'" & strValues(19) & "'," _
            & "'" & strValues(20) & "'," _
            & "'" & strValues(21) & "'," _
            & "'" & strValues(22) & "'," _
            & "'" & strValues(23) & "'," _
            & "'" & strValues(24) & "'," _
            & "'" & strValues(25) & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        '
        'INSERT THE REPORT FIELDS
        '
        For i As Integer = 0 To strValues.Length - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(1).Cells(i + 1).Value), "")) Then
                strValues(i) = dGrid.Rows(1).Cells(i + 1).Value.ToString
            Else
                strValues(i) = "0"
            End If
        Next
        strSql = "INSERT INTO MultiColumnReportFields (ReportNo, FieldA, FieldB, FieldC, FieldD, FieldE, FieldF, FieldG, " _
            & "FieldH, FieldI, FieldJ, FieldK, FieldL, FieldM, FieldN, FieldO, FieldP, FieldQ, FieldR, " _
            & "FieldS, FieldT, FieldU, FieldV, FieldW, FieldX, FieldY, FieldZ) VALUES " _
            & "(" & intReport & ", '" & strValues(0) & "', " _
            & "'" & strValues(1) & "'," _
            & "'" & strValues(2) & "'," _
            & "'" & strValues(3) & "'," _
            & "'" & strValues(4) & "'," _
            & "'" & strValues(5) & "'," _
            & "'" & strValues(6) & "'," _
            & "'" & strValues(7) & "'," _
            & "'" & strValues(8) & "'," _
            & "'" & strValues(9) & "'," _
            & "'" & strValues(10) & "'," _
            & "'" & strValues(11) & "'," _
            & "'" & strValues(12) & "'," _
            & "'" & strValues(13) & "'," _
            & "'" & strValues(14) & "'," _
            & "'" & strValues(15) & "'," _
            & "'" & strValues(16) & "'," _
            & "'" & strValues(17) & "'," _
            & "'" & strValues(18) & "'," _
            & "'" & strValues(19) & "'," _
            & "'" & strValues(20) & "'," _
            & "'" & strValues(21) & "'," _
            & "'" & strValues(22) & "'," _
            & "'" & strValues(23) & "'," _
            & "'" & strValues(24) & "'," _
            & "'" & strValues(25) & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        '
        'INSERT THE REPORT SIZES
        '
        For i As Integer = 0 To strValues.Length - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(2).Cells(i + 1).Value), "")) Then
                If IsNumeric(dGrid.Rows(2).Cells(i + 1).Value.ToString) Then
                    strValues(i) = dGrid.Rows(2).Cells(i + 1).Value.ToString
                Else
                    strValues(i) = "0"
                End If
            Else
                strValues(i) = "0"
            End If
        Next
        strSql = "INSERT INTO MultiColumnReportSizes (ReportNo, FieldA, FieldB, FieldC, FieldD, FieldE, FieldF, FieldG, " _
            & "FieldH, FieldI, FieldJ, FieldK, FieldL, FieldM, FieldN, FieldO, FieldP, FieldQ, FieldR, " _
            & "FieldS, FieldT, FieldU, FieldV, FieldW, FieldX, FieldY, FieldZ) VALUES " _
            & "(" & intReport & ", " & strValues(0) & ", " _
            & "" & strValues(1) & "," _
            & "" & strValues(2) & "," _
            & "" & strValues(3) & "," _
            & "" & strValues(4) & "," _
            & "" & strValues(5) & "," _
            & "" & strValues(6) & "," _
            & "" & strValues(7) & "," _
            & "" & strValues(8) & "," _
            & "" & strValues(9) & "," _
            & "" & strValues(10) & "," _
            & "" & strValues(11) & "," _
            & "" & strValues(12) & "," _
            & "" & strValues(13) & "," _
            & "" & strValues(14) & "," _
            & "" & strValues(15) & "," _
            & "" & strValues(16) & "," _
            & "" & strValues(17) & "," _
            & "" & strValues(18) & "," _
            & "" & strValues(19) & "," _
            & "" & strValues(20) & "," _
            & "" & strValues(21) & "," _
            & "" & strValues(22) & "," _
            & "" & strValues(23) & "," _
            & "" & strValues(24) & "," _
            & "" & strValues(25) & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        '
        'INSERT THE REPORT ALIGNMENTS
        '
        For i As Integer = 0 To strValues.Length - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(3).Cells(i + 1).Value), "")) Then
                Select Case UCase(dGrid.Rows(3).Cells(i + 1).Value.ToString)
                    Case Is = "LEFT"
                        strValues(i) = "0"
                    Case Is = "CENTER"
                        strValues(i) = "1"
                    Case Is = "RIGHT"
                        strValues(i) = "2"
                    Case Else
                        strValues(i) = "0"
                End Select
            Else
                strValues(i) = "0"
            End If
        Next
        strSql = "INSERT INTO MultiColumnReportAlignments (ReportNo, FieldA, FieldB, FieldC, FieldD, FieldE, FieldF, FieldG, " _
            & "FieldH, FieldI, FieldJ, FieldK, FieldL, FieldM, FieldN, FieldO, FieldP, FieldQ, FieldR, " _
            & "FieldS, FieldT, FieldU, FieldV, FieldW, FieldX, FieldY, FieldZ) VALUES " _
            & "(" & intReport & ", " & strValues(0) & ", " _
            & "" & strValues(1) & "," _
            & "" & strValues(2) & "," _
            & "" & strValues(3) & "," _
            & "" & strValues(4) & "," _
            & "" & strValues(5) & "," _
            & "" & strValues(6) & "," _
            & "" & strValues(7) & "," _
            & "" & strValues(8) & "," _
            & "" & strValues(9) & "," _
            & "" & strValues(10) & "," _
            & "" & strValues(11) & "," _
            & "" & strValues(12) & "," _
            & "" & strValues(13) & "," _
            & "" & strValues(14) & "," _
            & "" & strValues(15) & "," _
            & "" & strValues(16) & "," _
            & "" & strValues(17) & "," _
            & "" & strValues(18) & "," _
            & "" & strValues(19) & "," _
            & "" & strValues(20) & "," _
            & "" & strValues(21) & "," _
            & "" & strValues(22) & "," _
            & "" & strValues(23) & "," _
            & "" & strValues(24) & "," _
            & "" & strValues(25) & ")"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        intSelectedReport = intReport
        boolEditStatus = True
        MessageBox.Show("Report Details Saved Successfully", "Multi Column Report Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on multi column report designer save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        strSql = "SELECT ReportName FROM MultiColumnReportHeaders WHERE ReportNo = " & intSelectedReport & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then txtReportName.Text = objReader(0).ToString
        End If
        objReader.Close()

        strSql = "SELECT CaptionA, CaptionB, CaptionC, CaptionD, CaptionE, CaptionF, CaptionG, " _
            & "CaptionH, CaptionI, CaptionJ, CaptionK, CaptionL, CaptionM, CaptionN, CaptionO, CaptionP, CaptionQ, CaptionR, " _
            & "CaptionS, CaptionT, CaptionU, CaptionV, CaptionW, CaptionX, CaptionY, CaptionZ " _
            & "FROM MultiColumnReportCaptions WHERE ReportNo = " & intSelectedReport & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            For i As Integer = 0 To objReader.FieldCount - 1
                If Not IsDBNull(objReader(i).ToString) Then dGrid.Rows(0).Cells(i + 1).Value = objReader(i).ToString
            Next
        End If
        objReader.Close()

        strSql = "SELECT FieldA, FieldB, FieldC, FieldD, FieldE, FieldF, FieldG, " _
            & "FieldH, FieldI, FieldJ, FieldK, FieldL, FieldM, FieldN, FieldO, FieldP, FieldQ, FieldR, " _
            & "FieldS, FieldT, FieldU, FieldV, FieldW, FieldX, FieldY, FieldZ " _
            & "FROM MultiColumnReportFields WHERE ReportNo = " & intSelectedReport & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            For i As Integer = 0 To objReader.FieldCount - 1
                If Not IsDBNull(objReader(i).ToString) Then dGrid.Rows(1).Cells(i + 1).Value = objReader(i).ToString
            Next
        End If
        objReader.Close()

        strSql = "SELECT FieldA, FieldB, FieldC, FieldD, FieldE, FieldF, FieldG, " _
            & "FieldH, FieldI, FieldJ, FieldK, FieldL, FieldM, FieldN, FieldO, FieldP, FieldQ, FieldR, " _
            & "FieldS, FieldT, FieldU, FieldV, FieldW, FieldX, FieldY, FieldZ " _
            & "FROM MultiColumnReportSizes WHERE ReportNo = " & intSelectedReport & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            For i As Integer = 0 To objReader.FieldCount - 1
                If Not IsDBNull(objReader(i).ToString) Then dGrid.Rows(2).Cells(i + 1).Value = objReader(i).ToString
            Next
        End If
        objReader.Close()

        strSql = "SELECT  FieldA, FieldB, FieldC, FieldD, FieldE, FieldF, FieldG, " _
            & "FieldH, FieldI, FieldJ, FieldK, FieldL, FieldM, FieldN, FieldO, FieldP, FieldQ, FieldR, " _
            & "FieldS, FieldT, FieldU, FieldV, FieldW, FieldX, FieldY, FieldZ " _
            & "FROM MultiColumnReportAlignments WHERE ReportNo = " & intSelectedReport & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            For i As Integer = 0 To objReader.FieldCount - 1
                If IsNumeric(objReader(i).ToString) Then
                    Select Case CInt(objReader(i).ToString)
                        Case Is = 0
                            dGrid.Rows(3).Cells(i + 1).Value = "Left"
                        Case Is = 1
                            dGrid.Rows(3).Cells(i + 1).Value = "Center"
                        Case Is = 2
                            dGrid.Rows(3).Cells(i + 1).Value = "Right"
                        Case Else
                            dGrid.Rows(3).Cells(i + 1).Value = "Left"
                    End Select
                End If
            Next
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & " on multi column report designer load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        If boolEditStatus = True Then
            gwt_comm.PrintMultiColumnReport(intSelectedReport)
        Else
            MessageBox.Show("You can only print the report if you are in edit mode", "Process Intercepted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

End Class