Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmAccountAllocations

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
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

    Private Sub frmAccountAllocations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCostCenters()
        AlternateColors()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_PaymentDescriptionAmts WHERE CostCode = '" & cboCostCode.Text & "'", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblRate As Double = 0
            If Not Object.Equals(dGrid.Rows(i).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(1).Value.ToString) Then
                        dblRate = CDbl(dGrid.Rows(i).Cells(1).Value.ToString)
                    End If
                End If
            End If
            Dim strDescription As String = Nothing
            If Not Object.Equals(dGrid.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(0).Value.ToString) Then
                    strDescription = dGrid.Rows(i).Cells(0).Value.ToString
                End If
            End If
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SC_PaymentDescriptionAmts (CostCode, Description, Amount) " _
                & "VALUES ('" & cboCostCode.Text & "', '" & strDescription & "', " & dblRate & ")", cnn)
            objCommand.ExecuteNonQuery()
        Next
        MessageBox.Show("School fees breakdown amounts updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On school fees breakdown analysis and update"
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
        If dGrid.CurrentCell.ColumnIndex = 1 Then
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                If IsNumeric(dGrid.CurrentCell.Value.ToString) Then
                    dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")
                End If
            End If
        End If
    End Sub

    Private Sub dGrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellValueChanged
        On Error Resume Next
        If dGrid.CurrentCell.ColumnIndex = 1 Then
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                If IsNumeric(dGrid.CurrentCell.Value.ToString) Then
                    dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")
                End If
            End If
        End If
    End Sub

    Private Sub cboCostCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCostCode.SelectedIndexChanged
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SC_PaymentDescriptions.Description FROM SC_PaymentDescriptions ORDER BY Priority", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0).ToString, "0.00")
        End While
        objReader.Close()

        'Get the actual amount set 
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    Dim strDescription As String = dGrid.Rows(p).Cells(0).Value.ToString
                    objCommand = New Data.OleDb.OleDbCommand("SELECT CAST(Amount AS DECIMAL (10,2)) AS [Amt] " _
                        & "FROM SC_PaymentDescriptionAmts WHERE CostCode = '" & cboCostCode.Text & "' AND " _
                        & "SC_PaymentDescriptionAmts.Description = '" & strDescription & "'", cnn)
                    objReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        If IsNumeric(objReader(0).ToString) Then
                            dGrid.Rows(p).Cells(1).Value = objReader(0).ToString
                        End If
                    End If
                    objReader.Close()
                End If
            End If
        Next
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On payment description amounts allocation"
        ShowErrorMessage()
    End Sub

End Class
