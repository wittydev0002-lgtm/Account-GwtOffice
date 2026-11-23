Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmCalculations

    Dim boolLoading As Boolean
    Dim intCurrentColumnIndex As Integer
    Dim intCurrentRowIndex As Integer

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dgrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrid.CellEndEdit
        If IsNumeric(dgrid.CurrentCell.Value) Then dgrid.CurrentCell.Value = Format(CDbl(dgrid.CurrentCell.Value.ToString), "##0")
    End Sub

    Private Sub dgrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgrid.EditingControlShowing
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

    Private Sub frmCalculations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boolLoading = True
        LoadHelpers()
        LoadCalculations()
    End Sub

    Private Sub LoadHelpers()
        Dim arrValues As New ArrayList
        Dim arrOperands As New ArrayList
        'Add the functions to the array list
        With arrValues
            .Add(";Blank")
            .Add("ADD;Add")
            .Add("ADC;Add and accumulate")
            .Add("AGE;Compute Age")
            .Add("GRP;Grossup For Tax")
            .Add("SUB;Subtract")
            .Add("SUC;Subtract and accumulate")
            .Add("DIV;Divide")
            .Add("MUL;Multiply")
            .Add("MUC;Multiply and accumulate")
            .Add("MOV;Move value")
            .Add("NGT;Not Greater Than Logic")
            .Add("GT;Greater Than Logic")
            .Add("NLT;Not Greater Than")
            .Add("LT;Less Than")
            .Add("EQ;Equal To")
            .Add("NEQ;Not Equal To")
            .Add("GO;Branch To")
            .Add("SRV;Compute Service Period")
            .Add("TBL;Table Lookup")
        End With
        With cboFunctions
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "50;200"
        End With
        Dim DropDownItems(arrValues.Count - 1) As MTGCComboBoxItem
        For i As Integer = 0 To arrValues.Count - 1
            Dim strRecordText() As String = Split(arrValues(i), ";")
            DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next
        cboFunctions.SelectedIndex = -1
        cboFunctions.Items.Clear()
        cboFunctions.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        cboFunctions.Items.AddRange(DropDownItems)

        'Load the operands
        With arrOperands
            .Add(";Blank")
            .Add("C;Run Code")
            .Add("D;Date")
            .Add("S;Store")
            .Add("B;Balance")
            .Add("R;Register")
            .Add("Q;QMF Code")
            .Add("L;Literal")
        End With
        With cboOperands
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "40;70"
        End With
        Dim DropDownItemsOps(arrOperands.Count - 1) As MTGCComboBoxItem
        cboOperands.Items.Clear()
        For i As Integer = 0 To arrOperands.Count - 1
            Dim strRecordText() As String = Split(arrOperands(i), ";")
            DropDownItemsOps(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next
        cboOperands.SelectedIndex = -1
        cboOperands.Items.Clear()
        cboOperands.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
        cboOperands.Items.AddRange(DropDownItemsOps)

    End Sub

    Private Sub LoadCalculations()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT OrdinalNo, CalcTime, " _
            & "IndicatorSub, IndicatorValue, CalcFunction, OperandOneId, " _
            & "OperandOneCode, OperandTwoId, OperandTwoCode, ResultantId, " _
            & "ResultantCode FROM SystemCalculations WHERE " _
            & "CalcNo = " & intNextCalculationNumber & " ORDER BY OrdinalNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader

        Dim i As Integer 'datagrid row identifier
        Dim CurrentCell As DataGridViewCell
        'set the properties for the datagridview
        dgrid.Rows.Clear()
        dgrid.Rows.Add(1000)
        For i = 1 To 1000
            dgrid.Rows(i - 1).Cells(0).Value = Format(i, "0000")
            dgrid.Rows(i - 1).Cells(2).Value = "0"
            dgrid.Rows(i - 1).Cells(6).Value = "0"
            dgrid.Rows(i - 1).Cells(8).Value = "0"
            dgrid.Rows(i - 1).Cells(10).Value = "0"
        Next
        ' Exit Sub
        While objReader.Read
            Dim intLineNumber As Integer = 0
            Dim intCalculationTime As Integer = 0
            Dim intIndicatorSub As Integer = 0
            Dim strIndicatorValue As String = Nothing
            Dim strCalculationFunction As String = Nothing
            Dim strOp1id As String = Nothing
            Dim intOp1 As Integer = 0
            Dim strOp2id As String = Nothing
            Dim intOp2 As Integer = 0
            Dim strOp3id As String = Nothing
            Dim intOp3 As Integer = 0
            'Assign the values before writing them to the grid
            If Not IsDBNull(objReader(0).ToString) Then intLineNumber = CInt(objReader(0).ToString)
            If Not IsDBNull(objReader(1).ToString) Then intCalculationTime = CInt(objReader(1).ToString)
            If Not IsDBNull(objReader(2).ToString) Then intIndicatorSub = CInt(objReader(2).ToString)
            If Not IsDBNull(objReader(3).ToString) Then strIndicatorValue = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then strCalculationFunction = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then strOp1id = objReader(5).ToString
            If Not IsDBNull(objReader(6).ToString) Then intOp1 = CInt(objReader(6).ToString)
            If Not IsDBNull(objReader(7).ToString) Then strOp2id = objReader(7).ToString
            If Not IsDBNull(objReader(8).ToString) Then intOp2 = CInt(objReader(8).ToString)
            If Not IsDBNull(objReader(9).ToString) Then strOp3id = objReader(9).ToString
            If Not IsDBNull(objReader(10).ToString) Then intOp3 = CInt(objReader(10).ToString)

            'Get the descriptions
            Dim strDescription1 As String = FieldDescriptions(strOp1id, intOp1)
            Dim strDescription2 As String = FieldDescriptions(strOp2id, intOp2)
            Dim strDescription3 As String = FieldDescriptions(strOp3id, intOp3)

            Dim intRowIndex As Integer = intLineNumber - 1

            With dgrid
                .Rows(intRowIndex).Cells(1).Value = intCalculationTime
                .Rows(intRowIndex).Cells(2).Value = intIndicatorSub
                .Rows(intRowIndex).Cells(3).Value = strIndicatorValue
                .Rows(intRowIndex).Cells(4).Value = strCalculationFunction
                .Rows(intRowIndex).Cells(5).Value = strOp1id
                .Rows(intRowIndex).Cells(6).Value = intOp1
                .Rows(intRowIndex).Cells(7).Value = strOp2id
                .Rows(intRowIndex).Cells(8).Value = intOp2
                .Rows(intRowIndex).Cells(9).Value = strOp3id
                .Rows(intRowIndex).Cells(10).Value = intOp3
                .Rows(intRowIndex).Cells(11).Value = strDescription1
                .Rows(intRowIndex).Cells(12).Value = strDescription2
                .Rows(intRowIndex).Cells(13).Value = strDescription3
            End With
        End While
        boolLoading = False
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Calculations Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function FieldDescriptions(ByVal FieldType As String, ByVal FieldId As Integer) As String
        On Error GoTo RaiseErr
        Dim intFld As Integer = FieldId
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim strReturn As String = Nothing
        Select Case UCase(FieldType)
            Case Is = "C"
                objCommand = New Data.OleDb.OleDbCommand("SELECT Description FROM SystemCodes WHERE CodeNo = " & intFld & "", cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
                End If
                objReader.Close()
            Case Is = "S"
                objCommand = New Data.OleDb.OleDbCommand("SELECT Description FROM SystemCodes WHERE CodeNo = " & intFld & "", cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
                End If
                objReader.Close()
            Case Is = "B"
                objCommand = New Data.OleDb.OleDbCommand("SELECT Description FROM SystemCodes WHERE CodeNo = " & intFld & "", cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
                End If
                objReader.Close()
            Case Is = "Q"
                objCommand = New Data.OleDb.OleDbCommand("SELECT Description FROM SystemCodes WHERE CodeNo = " & intFld & "", cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
                End If
                objReader.Close()
            Case Is = "R"
                objCommand = New Data.OleDb.OleDbCommand("SELECT " _
                    & "Description +' '+ CONVERT(NVARCHAR, ConstantValue) AS " _
                    & "[Constant] FROM SystemConstants WHERE ConstantNo = " & intFld & "", cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
                End If
                objReader.Close()
            Case Else
                strReturn = ""
        End Select
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Field descriptions search"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr

        Dim CurrentCell As DataGridViewCell
        Dim i As Integer

        Dim intLineNumber As Integer = 0
        Dim intCalculationTime As Integer = 0
        Dim intIndicatorSub As Integer = 0
        Dim strIndicatorValue As String = Nothing
        Dim strCalculationFunction As String = Nothing
        Dim strOp1id As String = Nothing
        Dim intOp1 As Integer = 0
        Dim strOp2id As String = Nothing
        Dim intOp2 As Integer = 0
        Dim strOp3id As String = Nothing
        Dim intOp3 As Integer = 0

        pb1.Value = 0
        pb1.Maximum = 1000

        For i = 0 To 999
            Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemCalculations " _
                & "WHERE CalcNo = " & intNextCalculationNumber & " AND OrdinalNo = " & i + 1 & "", cnn)
            sqlCommand.ExecuteNonQuery()
            CurrentCell = dgrid.Rows(i).Cells(0)
            intLineNumber = CurrentCell.Value
            CurrentCell = dgrid.Rows(i).Cells(1)
            intCalculationTime = CurrentCell.Value
            CurrentCell = dgrid.Rows(i).Cells(2)
            If Not IsNumeric(CurrentCell.Value) Then intIndicatorSub = 0 Else intIndicatorSub = CInt(CurrentCell.Value)
            CurrentCell = dgrid.Rows(i).Cells(3)
            strIndicatorValue = CurrentCell.Value
            CurrentCell = dgrid.Rows(i).Cells(4)
            strCalculationFunction = CurrentCell.Value
            CurrentCell = dgrid.Rows(i).Cells(5)
            strOp1id = CurrentCell.Value
            CurrentCell = dgrid.Rows(i).Cells(6)
            If Not IsNumeric(CurrentCell.Value) Then intOp1 = 0 Else intOp1 = CInt(CurrentCell.Value)
            CurrentCell = dgrid.Rows(i).Cells(7)
            strOp2id = CurrentCell.Value
            CurrentCell = dgrid.Rows(i).Cells(8)
            If Not IsNumeric(CurrentCell.Value) Then intOp2 = 0 Else intOp2 = CInt(CurrentCell.Value)
            CurrentCell = dgrid.Rows(i).Cells(9)
            strOp3id = CurrentCell.Value
            CurrentCell = dgrid.Rows(i).Cells(10)
            If Not IsNumeric(CurrentCell.Value) Then intOp3 = 0 Else intOp3 = CInt(CurrentCell.Value)
            sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemCalculations (OrdinalNo, CalcTime, " _
            & "IndicatorSub, IndicatorValue, CalcFunction, OperandOneId, " _
            & "OperandOneCode, OperandTwoId, OperandTwoCode, ResultantId, " _
            & "ResultantCode, CalcNo) VALUES (" & intLineNumber & ", " & intCalculationTime & ", " _
            & "" & intIndicatorSub & ", '" & strIndicatorValue & "', '" & strCalculationFunction & "', " _
            & "'" & strOp1id & "', " & intOp1 & ", '" & strOp2id & "', " & intOp2 & ", " _
            & "'" & strOp3id & "', " & intOp3 & ", " & intNextCalculationNumber & ")", cnn)
            sqlCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next i
        MessageBox.Show("Payroll calculations updated successfully", "Payroll Calculations Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Calculations Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrid.CellEnter

        'Get the current cell over
        On Error GoTo RaiseErr
        If boolLoading = True Then Exit Sub
        Dim strId As String
        Dim intId As Integer
        Dim intFld As Integer
        Dim currentcell As DataGridViewCell
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strBuffer() As String
        Dim strLine As String

        cboFunctions.Visible = False : cboOperands.Visible = False

        'set the functions combo box visible
        If e.ColumnIndex = 4 Then
            'set date picker for category datagrid
            cboFunctions.Size = dgrid.CurrentCell.Size
            cboFunctions.Top = dgrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + 64
            cboFunctions.Left = dgrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left + 0
            If Not (Object.Equals(Convert.ToString(dgrid.CurrentCell.Value), "")) Then
                cboFunctions.Text = Convert.ToString(dgrid.CurrentCell.Value)
            Else
                cboFunctions.Text = Nothing
            End If
            cboFunctions.Visible = True
            Exit Sub
        End If

        'set the operands combo box visible
        If e.ColumnIndex = 5 Or e.ColumnIndex = 7 Or e.ColumnIndex = 9 Then
            'set date picker for category datagrid
            intCurrentColumnIndex = e.ColumnIndex
            intCurrentRowIndex = e.RowIndex
            cboOperands.Size = dgrid.CurrentCell.Size
            cboOperands.Top = dgrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Top + 64
            cboOperands.Left = dgrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left + 0
            If Not (Object.Equals(Convert.ToString(dgrid.CurrentCell.Value), "")) Then
                cboOperands.Text = Convert.ToString(dgrid.CurrentCell.Value)
            Else
                cboOperands.Text = Nothing
            End If
            cboOperands.Visible = True
            Exit Sub
        End If

        If dgrid.CurrentCell.ColumnIndex = 6 Or dgrid.CurrentCell.ColumnIndex = 8 _
                            Or dgrid.CurrentCell.ColumnIndex = 10 Then
            lblStatus.Text = ""
            intId = dgrid.CurrentCell.ColumnIndex - 1
            currentcell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(intId)
            strId = currentcell.Value
            intFld = CInt(dgrid.CurrentCell.Value)
            lblStatus.Text = FieldDescriptions(strId, intFld)
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Field Description Display Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrid.CellLeave
        If boolLoading = True Then Exit Sub
        If dgrid.CurrentCell.ColumnIndex = 6 Or dgrid.CurrentCell.ColumnIndex = 8 _
            Or dgrid.CurrentCell.ColumnIndex = 10 Or dgrid.CurrentCell.ColumnIndex = 2 Then
            If Not IsNumeric(dgrid.CurrentCell.Value) Then
                dgrid.CurrentCell.Value = "0"
            Else
                Dim intId As Integer = dgrid.CurrentCell.ColumnIndex - 1
                Dim strId As String = Nothing
                Dim intFld As Integer = 0
                If Not (Object.Equals(Convert.ToString(dgrid.Rows(dgrid.CurrentRow.Index).Cells(intId).Value), "")) Then
                    strId = dgrid.Rows(dgrid.CurrentRow.Index).Cells(intId).Value
                End If
                intFld = CInt(dgrid.CurrentCell.Value.ToString)
                If dgrid.CurrentCell.ColumnIndex = 6 Then
                    dgrid.CurrentRow.Cells(11).Value = FieldDescriptions(strId, intFld)
                End If
                If dgrid.CurrentCell.ColumnIndex = 8 Then
                    dgrid.CurrentRow.Cells(12).Value = FieldDescriptions(strId, intFld)
                End If
                If dgrid.CurrentCell.ColumnIndex = 10 Then
                    dgrid.CurrentRow.Cells(13).Value = FieldDescriptions(strId, intFld)
                End If
            End If
        End If
    End Sub

    Private Sub dgrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrid.CellValueChanged
        If boolLoading = True Then Exit Sub
        On Error Resume Next
        If dgrid.CurrentCell.ColumnIndex = 6 Or dgrid.CurrentCell.ColumnIndex = 8 _
            Or dgrid.CurrentCell.ColumnIndex = 10 Or dgrid.CurrentCell.ColumnIndex = 2 Then
            If Not IsNumeric(dgrid.CurrentCell.Value) Then
                dgrid.CurrentCell.Value = "0"
            Else
                Dim intId As Integer = dgrid.CurrentCell.ColumnIndex - 1
                Dim strId As String = Nothing
                Dim intFld As Integer = 0
                If Not (Object.Equals(Convert.ToString(dgrid.Rows(dgrid.CurrentRow.Index).Cells(intId).Value), "")) Then
                    strId = dgrid.Rows(dgrid.CurrentRow.Index).Cells(intId).Value
                End If
                intFld = CInt(dgrid.CurrentCell.Value.ToString)
                If dgrid.CurrentCell.ColumnIndex = 6 Then
                    dgrid.CurrentRow.Cells(11).Value = FieldDescriptions(strId, intFld)
                End If
                If dgrid.CurrentCell.ColumnIndex = 8 Then
                    dgrid.CurrentRow.Cells(12).Value = FieldDescriptions(strId, intFld)
                End If
                If dgrid.CurrentCell.ColumnIndex = 10 Then
                    dgrid.CurrentRow.Cells(13).Value = FieldDescriptions(strId, intFld)
                End If
            End If
        End If
    End Sub

    Private Sub dGrid_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrid.CurrentCellChanged
        If boolLoading = True Then Exit Sub
        On Error Resume Next
        If dgrid.CurrentCell.ColumnIndex = 6 Or dgrid.CurrentCell.ColumnIndex = 8 _
            Or dgrid.CurrentCell.ColumnIndex = 10 Or dgrid.CurrentCell.ColumnIndex = 2 Then
            If Not IsNumeric(dgrid.CurrentCell.Value) Then
                dgrid.CurrentCell.Value = "0"
            End If
        End If
    End Sub

    Private Sub KryptonContextMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonContextMenuItem1.Click
        gwt_comm.PayrollCodesSearch()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then e.Handled = True
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
        If Not IsNumeric(txtSearchString.Text) Then
            MessageBox.Show("Please enter a number for the field you want to search for", "Search Field Not Defined", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSearchString.Focus()
            Exit Sub
        End If
        intCalcElement = CInt(txtSearchString.Text)
        HighlightCalcElement(intCalcElement)
    End Sub

    Private Sub HighlightCalcElement(ByVal intFindFieldId As Integer)
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim strCellValue As String = Nothing
        For i = 0 To dgrid.Rows.Count - 1
            For j = 5 To dgrid.ColumnCount - 1
                If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(j).Value), "")) Then
                    strCellValue = Convert.ToString(dgrid.Rows(i).Cells(j).Value)
                    If IsNumeric(strCellValue) Then
                        If CInt(strCellValue) = intFindFieldId Then
                            dgrid.Rows(i).Cells(j).Style.BackColor = Color.LightYellow
                            dgrid.Rows(i).Cells(j).Style.ForeColor = Color.Black
                        End If
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub ClearHighlights()
        Dim i As Integer = 0
        Dim j As Integer = 0
        For i = 0 To dgrid.Rows.Count - 1
            For j = 5 To dgrid.ColumnCount - 1
                dgrid.Rows(i).Cells(j).Style.BackColor = Color.White
                dgrid.Rows(i).Cells(j).Style.ForeColor = Color.Black
            Next
        Next
    End Sub

    Private Sub btnClearHighLights_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearHighLights.Click
        ClearHighlights()
    End Sub

    Private Sub KryptonContextMenuItem2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonContextMenuItem2.Click
        'View Constants
    End Sub

    Private Sub cboFunctions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFunctions.SelectedIndexChanged
        If cboFunctions.Focused = False Then Exit Sub
        If Not cboFunctions.SelectedItem Is Nothing Then
            dgrid.CurrentCell.Value = cboFunctions.SelectedItem.Col1
        End If
    End Sub

    Private Sub frmCalculations_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        On Error Resume Next
        cboFunctions.Width = dgrid.Columns(4).Width
        cboOperands.Width = dgrid.Columns(5).Width
        Dim x As Integer = (60 / 310) * dgrid.Columns(4).Width
        Dim y As Integer = (250 / 310) * dgrid.Columns(4).Width
        'cboFunctions.ColumnWidth = CStr(x) & ";" & CStr(y) '250"
        cboOperands.Left = dgrid.GetCellDisplayRectangle(intCurrentColumnIndex, intCurrentRowIndex, True).Left + 0
    End Sub

    Private Sub cboOperands_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOperands.SelectedIndexChanged
        If cboOperands.Focused = False Then Exit Sub
        If Not cboOperands.SelectedItem Is Nothing Then
            dgrid.CurrentCell.Value = cboOperands.SelectedItem.Col1
        End If
    End Sub

    Private Sub dgrid_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgrid.KeyDown
        If boolLoading = True Then Exit Sub
        If dgrid.CurrentRow.Index >= 0 Then
            If e.KeyValue = Keys.F7 Then
                If dgrid.CurrentCell.ColumnIndex = 6 Or dgrid.CurrentCell.ColumnIndex = 8 _
                            Or dgrid.CurrentCell.ColumnIndex = 10 Then
                    'Get the value of the preceeding cell
                    If Not (Object.Equals(Convert.ToString(dgrid.CurrentCell.Value), "")) Then
                        strSelectedCode = Convert.ToString(dgrid.CurrentCell.Value)
                    End If
                    Dim currentcell As DataGridViewCell
                    currentcell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(dgrid.CurrentCell.ColumnIndex - 1)
                    Dim frm As Form
                    boolAbort = False
                    If UCase(currentcell.Value) = "R" Then
                        gwt_comm.PayrollConstantsSearch()
                    Else
                        gwt_comm.PayrollCodesSearch()
                    End If
                    dgrid.CurrentCell.Value = strSelectedCode
                End If
            End If
            'Get also the values for the indicators
            If e.KeyValue = Keys.F7 Then
                If dgrid.CurrentCell.ColumnIndex = 2 Then
                    'Get the value of the preceeding cell
                    strSelectedValue = ""
                    Dim currentcell As DataGridViewCell
                    currentcell = dgrid.Rows(dgrid.CurrentRow.Index).Cells(dgrid.CurrentCell.ColumnIndex - 1)
                    intSelectedTransaction = CInt(currentcell.Value.ToString)
                    'Display the indicator view codes
                    boolAbort = False
                    gwt_comm.PayrollFlagOptions()
                    If boolAbort = True Then Exit Sub
                    dgrid.CurrentCell.Value = strSelectedValue
                End If
            End If
            'Get also the values for the function codes [Asci(e,keychar) = 19]
            If e.KeyValue = Keys.F7 Then
                If dgrid.CurrentCell.ColumnIndex = 4 Then
                    boolAbort = False
                    gwt_comm.PayrollMathFunctions()
                    If boolAbort = True Then Exit Sub
                    dgrid.CurrentCell.Value = strFunctionCode
                End If
            End If
        End If
    End Sub

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim arrPrintDetails As New ArrayList
        For i As Integer = 0 To dgrid.Rows.Count - 1
            Dim strLineData As String = Nothing
            For p As Integer = 0 To dgrid.ColumnCount - 1
                'FN=Arial;FS=8;FC=White;FB=False;FI=False;FU=False;BC=Navy;RH=25
                Dim strFontName As String = "Arial"
                Dim intFontSize As Integer = 6
                Dim strFontColor As String = "Black"
                Dim strFontBold As String = "False"
                Dim strFontItalic As String = "False"
                Dim strFontUnderline As String = "False"
                Dim strBackColor As String = "White"
                Dim intRectangleHeight As Integer = 25
                Dim strPrintData As String = Nothing
                If Not (Object.Equals(Convert.ToString(dgrid.Rows(i).Cells(p).Value), "")) Then
                    strPrintData = dgrid.Rows(i).Cells(p).Value.ToString
                    'Get the actual font and style used in the grid
                    Dim fnt As Font = dgrid.Rows(i).Cells(p).Style.Font
                    If fnt Is Nothing Then intFontSize = 6 Else intFontSize = fnt.Size
                    If fnt Is Nothing Then strFontName = "Ariel" Else strFontName = fnt.Name
                    Dim strFontStyle As String = "False"
                    If Not fnt Is Nothing Then strFontStyle = fnt.Style
                    If strFontStyle = "1" Then strFontBold = "True"
                    If strFontStyle = "2" Then strFontItalic = "True"
                    If strFontStyle = "3" Then ' Bold and italic
                        strFontBold = "True"
                        strFontItalic = "True"
                    End If
                    If strFontStyle = "4" Then strFontUnderline = "True"
                    If strFontStyle = "5" Then ' Bold and underline
                        strFontBold = "True"
                        strFontUnderline = "True"
                    End If
                    If strFontStyle = "6" Then ' italic and underline
                        strFontItalic = "True"
                        strFontUnderline = "True"
                    End If
                    If strFontStyle = "7" Then ' italic and underline
                        strFontItalic = "True"
                        strFontUnderline = "True"
                        strFontBold = "True"
                    End If
                End If
                strLineData = strLineData & strPrintData & "|FN=" & strFontName & ";FS=" & intFontSize _
                    & ";FC=" & strFontColor & ";FB=" & strFontBold & ";FI=" & strFontItalic & ";FU=" & strFontUnderline _
                    & ";BC=" & strBackColor & ";RH=" & intRectangleHeight & "</d>"
            Next
            strLineData = Mid(strLineData, 1, strLineData.Length - 4)
            arrPrintDetails.Add(strLineData)
        Next

        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        Dim strColumnHeaders As String = Nothing
        For i As Integer = 0 To dgrid.ColumnCount - 1
            strColumnHeaders = strColumnHeaders & dgrid.Columns(i).HeaderText & "|"
        Next
        strColumnHeaders = Mid(strColumnHeaders, 1, (strColumnHeaders.Length - 1))

        'Request for print properties
        Dim prnt As New PrintDialog
        prnt.ShowDialog()

        Dim intPrintPageAreaWidth As Integer = prnt.PrinterSettings.DefaultPageSettings.PaperSize.Width _
                - (prnt.PrinterSettings.DefaultPageSettings.Margins.Left + prnt.PrinterSettings.DefaultPageSettings.Margins.Right)

        'Widths are based on the percentage point of the paper size and the grid
        Dim strColumnWidths As String = Nothing
        Dim strColumsVisible As String = Nothing

        Dim intTotalGridWidth As Integer = 0
        'calculate the total column widths
        For y As Integer = 0 To dgrid.ColumnCount - 1
            intTotalGridWidth = intTotalGridWidth + dgrid.Columns(y).Width
        Next

        Dim intValidateWidth As Integer = 0
        For i As Integer = 0 To dgrid.ColumnCount - 1
            Dim intCurrentWidth As Integer = 0

            'Calculate the width based on the percentage in the grid
            Dim intEqualWidth As Integer = intPrintPageAreaWidth / dgrid.Columns.Count
            Dim intPercentagePrintArea As Integer = (dgrid.Columns(i).Width / intTotalGridWidth) * 100
            intCurrentWidth = intPrintPageAreaWidth * (intPercentagePrintArea / 100)

            strColumnWidths = strColumnWidths & intCurrentWidth & "|"

            If intCurrentWidth = 0 Then
                strColumsVisible = strColumsVisible & "NO" & "|"
            Else
                strColumsVisible = strColumsVisible & "YES" & "|"
            End If
            intValidateWidth = intValidateWidth + intCurrentWidth
        Next
        strColumnWidths = Mid(strColumnWidths, 1, (strColumnWidths.Length - 1))
        strColumsVisible = Mid(strColumsVisible, 1, (strColumsVisible.Length - 1))

        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = dgrid.ColumnCount
            .strColumnHeaders = UCase(strColumnHeaders)
            .strColumnWidths = strColumnWidths
            .strFooterCaption = "Payroll Calculations"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "PAYROLL CALCULATIONS"
            .strMainHeader3 = ""
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.WhiteSmoke
            .HeaderFont = New Font("Verdana", 10, FontStyle.Bold)
            .FooterFont = New Font("Verdana", 6, FontStyle.Bold)
            .boolGenericReport = False
            .strPrintValues = strPrintDetails
            .VisibleColumns = strColumsVisible
            .DetailColor = Color.Black '+263736157834 '+263775020449
            .DetailFont = fntDetailsFont
        End With
        Cursor = Cursors.Default
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Calculations Print"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class