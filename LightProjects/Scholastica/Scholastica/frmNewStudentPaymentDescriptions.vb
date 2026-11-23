Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmNewStudentPaymentDescriptions


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
        If e.ColumnIndex >= 1 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
        End If
    End Sub

    Private Sub frmNewStudentPaymentDescriptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadCostCenters()
        AlternateColors()
    End Sub

    Private Sub frmNewStudentPaymentDescriptions_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 515
        Me.Height = 397
    End Sub

    Private Sub LoadCostCenters()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT SystemCostCenters.CostCenterName " _
            & "FROM SystemCostCenters ORDER BY SystemCostCenters.CostCenterName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboCostCode.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboCostCode.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger account cost centers percentages allocation"
        ShowErrorMessage()
    End Sub

    Private Sub AlternateColors()
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1 Step 2
                For j As Integer = 0 To .Columns.Count - 1
                    Dim foreColor As Color = Color.Black
                    Dim backColor As Color = Color.WhiteSmoke
                    .Rows(i).Cells(j).Style.BackColor = backColor
                    .Rows(i).Cells(j).Style.ForeColor = foreColor
                Next j
            Next i
        End With
    End Sub

    Private Sub dGrid_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dGrid.CellValidating
        If dGrid.CurrentCell.ColumnIndex = 1 Or dGrid.CurrentCell.ColumnIndex = 2 Then
            If Not Object.Equals(dGrid.CurrentCell.Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentCell.Value.ToString) Then
                    If IsNumeric(dGrid.CurrentCell.Value.ToString) Then
                        dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dGrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellValueChanged
        On Error Resume Next
        If dGrid.CurrentCell.ColumnIndex = 1 Or dGrid.CurrentCell.ColumnIndex = 2 Then
            If Not Object.Equals(dGrid.CurrentCell.Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.CurrentCell.Value.ToString) Then
                    If IsNumeric(dGrid.CurrentCell.Value.ToString) Then
                        dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboCostCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCostCode.SelectedIndexChanged
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SC_NewStudentPaymentDescriptionAmts.Description, " _
            & "SC_NewStudentPaymentDescriptionAmts.Priority, CAST(SC_NewStudentPaymentDescriptionAmts.Amount AS DECIMAL (10,2)) AS [Amt] " _
            & "FROM SC_NewStudentPaymentDescriptionAmts WHERE [CostCode] = '" & cboCostCode.Text & "' ORDER BY Priority", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        dGrid.Rows.Add(10)
        AlternateColors()
        Dim i As Integer = 0
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(i).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(i).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dGrid.Rows(i).Cells(2).Value = objReader(2).ToString
            i = i + 1
        End While
        objReader.Close()

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On new student payment description amounts allocation"
        ShowErrorMessage()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM [SC_NewStudentPaymentDescriptionAmts] " _
            & "WHERE CostCode = '" & cboCostCode.Text & "'", cnn)
        objCommand.ExecuteNonQuery()
        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim strDescription As String = Nothing
            Dim intPriority As Integer = 0
            Dim dblAmount As Double = 0
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strDescription = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        intPriority = CInt(dGrid.Rows(p).Cells(1).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(2).Value.ToString) Then
                        dblAmount = CDbl(dGrid.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
            End If
            If Not String.IsNullOrEmpty(strDescription) Then
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO [SC_NewStudentPaymentDescriptionAmts] " _
                    & "(Description, Priority, Amount, CostCode) VALUES ('" & strDescription & "', " & intPriority & ", " _
                    & "" & dblAmount & ", '" & cboCostCode.Text & "')", cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next
        MessageBox.Show("Payment descriptions have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On new student payment description amounts allocation save"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

End Class
