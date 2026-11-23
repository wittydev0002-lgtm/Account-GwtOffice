Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmAccountBudgeting

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
        If e.ColumnIndex = 1 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
            ComputeTotals()
        End If
    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr
        Dim dblTotal As Double = 0
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        dblTotal = dblTotal + CDbl(dGrid.Rows(p).Cells(1).Value.ToString)
                    End If
                End If
            End If
        Next
        lblTotal.Text = CStr(Format(dblTotal, "#,##0.00"))
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Totals Computation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartment.SelectedIndexChanged
        lblDepartmentCode.Text = Nothing
        If Not Object.Equals(cboDepartment.SelectedItem, Nothing) Then
            lblDepartmentCode.Text = cboDepartment.SelectedItem.Col2.ToString
        End If
    End Sub

    Private Sub cboBranches_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBranches.SelectedIndexChanged
        lblBranches.Text = Nothing
        If Not Object.Equals(cboBranches.SelectedItem, Nothing) Then
            lblBranches.Text = cboBranches.SelectedItem.Col2.ToString
        End If
    End Sub

    Private Sub cboCostCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCostCode.SelectedIndexChanged
        lblCostCode.Text = Nothing
        If Not Object.Equals(cboCostCode.SelectedItem, Nothing) Then
            lblCostCode.Text = cboCostCode.SelectedItem.Col2.ToString
        End If
    End Sub

    Private Sub frmAccountBudgeting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = strSelectedAccount & ": " & strSelectedAccountName
        lblFinyear.Text = lblFinyear.Text & CStr(Format(intCurrentBudgetYear, "0000"))
        LoadWorkStructures()
        LoadData(0, 0, 0)
    End Sub

    Private Sub LoadData(ByVal BranchCode As Integer, ByVal DepartmentCode As Integer, ByVal CostCode As Integer)
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim strSql As String = Nothing

        For p As Integer = 1 To intActiveFinancialYearPeiods

            Dim strBranchFilter As String = Nothing
            Dim strDepartmentFilter As String = Nothing
            Dim strCostCodeFilter As String = Nothing

            If BranchCode <> 0 Then
                strBranchFilter = "Branch = " & BranchCode & ""
            End If

            If DepartmentCode <> 0 Then
                strDepartmentFilter = "Department = " & DepartmentCode & ""
            End If

            If CostCode <> 0 Then
                strCostCodeFilter = "CostCode = " & CostCode & ""
            End If

            If String.IsNullOrEmpty(strBranchFilter) And String.IsNullOrEmpty(strDepartmentFilter) _
                And String.IsNullOrEmpty(strCostCodeFilter) Then
                strSql = "SELECT ISNULL(SUM(Amount), 0) FROM FinancialBudgets " _
                    & "WHERE ActiveYear = " & intCurrentBudgetYear & " AND " _
                    & "AccountNumber = '" & strSelectedAccount & "' AND PeriodNo = " & p & ""
            Else
                Dim strFilter As String = Nothing
                If Not String.IsNullOrEmpty(strBranchFilter) Then
                    strFilter = strFilter & strBranchFilter
                End If
                If Not String.IsNullOrEmpty(strDepartmentFilter) Then
                    If String.IsNullOrEmpty(strFilter) Then
                        strFilter = strFilter & strDepartmentFilter
                    Else
                        strFilter = strFilter & " AND " & strDepartmentFilter
                    End If
                End If
                If Not String.IsNullOrEmpty(strCostCodeFilter) Then
                    If String.IsNullOrEmpty(strFilter) Then
                        strFilter = strFilter & strCostCodeFilter
                    Else
                        strFilter = strFilter & " AND " & strCostCodeFilter
                    End If
                End If

                strSql = "SELECT ISNULL(SUM(Amount), 0) FROM FinancialBudgets " _
                    & "WHERE ActiveYear = " & intCurrentBudgetYear & " AND " _
                    & "AccountNumber = '" & strSelectedAccount & "' AND PeriodNo " & p & " AND " & strFilter
            End If

            Dim dblAmount As Double = 0

            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader(0).ToString) Then
                    dblAmount = CDbl(objReader(0).ToString)
                End If
            End If
            objReader.Close()
            dGrid.Rows.Add(p, Format(dblAmount, "##0.00"), "")

        Next
        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadWorkStructures()
        On Error GoTo RaiseErr

        Dim sqlCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        cboCostCode.Items.Clear()
        cboDepartment.Items.Clear()
        cboBranches.Items.Clear()

        Dim intWidth As Integer = cboCostCode.Width - 85

        With cboCostCode
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intWidth) & ";60"
        End With

        With cboDepartment
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intWidth) & ";60"
        End With

        With cboBranches
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = CStr(intWidth) & ";60"
        End With

        Dim arrItems As New ArrayList

        'arrItems.Add("--ALL--|0")
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT CostCenterName +'|'+ Convert(NVARCHAR, OrdinalNo) " _
            & "FROM SystemCostCenters ORDER BY CostCenterName", cnn)
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim DropDownItems(arrItems.Count - 1) As MTGCComboBoxItem

        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), "|")
            DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
        Next
        With cboCostCode
            If arrItems.Count > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With

        arrItems = New ArrayList
        arrItems.Add("--ALL--|0")

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT BranchName +'|'+ " _
            & "Convert(NVARCHAR, BranchCode) FROM Branches ORDER BY BranchName", cnn)
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        ReDim DropDownItems(arrItems.Count - 1)

        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), "|")
            DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
        Next
        With cboBranches
            If arrItems.Count > 0 Then
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End If
        End With

        arrItems = New ArrayList
        'arrItems.Add("--ALL--|0")

        sqlCommand = New Data.OleDb.OleDbCommand("SELECT DepartmentName +'|'+ " _
            & "Convert(NVARCHAR, OrdinalNo) FROM SystemDepartments ORDER BY DepartmentName", cnn)
        objReader = sqlCommand.ExecuteReader
        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        ReDim DropDownItems(arrItems.Count - 1)

        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), "|")
            DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
        Next
        With cboDepartment
            If arrItems.Count > 0 Then
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
        strErrorMessages = Err.Description & " Error Number " & Err.Number & " On budget parameters load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        LoadData(CInt(lblBranches.Text), CInt(lblDepartmentCode.Text), CInt(lblCostCode.Text))
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If dGrid.Rows.Count <= 0 Then
            MessageBox.Show("There are no budgets to be saved", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim strSql As String = "DELETE FROM FinancialBudgets WHERE ActiveYear = " & intActiveFinancialYear & " " _
                               & "AND AccountNumber = '" & strSelectedAccount & "' AND CostCode = " & lblCostCode.Text & " " _
                               & "AND Department = " & lblDepartmentCode.Text & " AND Branch = " & lblBranches.Text & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim intPeriod As Integer
            Dim dblAmount As Double = 0
            Dim strComment As String = Nothing
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(0).Value.ToString) Then
                        intPeriod = CInt(dGrid.Rows(p).Cells(0).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        dblAmount = CDbl(dGrid.Rows(p).Cells(1).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    strComment = dGrid.Rows(p).Cells(2).Value.ToString
                End If
            End If
            strSql = "INSERT INTO FinancialBudgets (ActiveYear, AccountNumber, PeriodNo, Amount, " _
                & "CostCode, Department, Branch, UserName, Comments) VALUES " _
                & "(" & intCurrentBudgetYear & ", '" & strSelectedAccount & "', " & intPeriod & ", " _
                & "" & dblAmount & ", " & lblCostCode.Text & ", " & lblDepartmentCode.Text & ", " _
                & "" & lblBranches.Text & ", '" & strUserName & "', '" & strComment & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Next

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & " On budgets save"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
