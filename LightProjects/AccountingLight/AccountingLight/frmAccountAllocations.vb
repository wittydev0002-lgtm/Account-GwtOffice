Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmAccountAllocations

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadCostCenters()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT SystemCostCenters.OrdinalNo, SystemCostCenters.CostCenterName " _
            & "FROM SystemCostCenters ORDER BY SystemCostCenters.OrdinalNo"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1))
        End While
        objReader.Close()
        'Get the values for the particular selected account
        For i As Integer = 0 To dGrid.Rows.Count - 1
            strSql = "SELECT CAST(AccountsAllocations.AllocationPercent AS DECIMAL (10,2)) AS [AllocationPercent] " _
                & "FROM AccountsAllocations WHERE AccountsAllocations.AccountNumber = '" & strSelectedAccount & "' " _
                & "AND AccountsAllocations.CostCode = " & dGrid.Rows(i).Cells(0).Value.ToString & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If IsNumeric(objReader(0).ToString) Then
                    dGrid.Rows(i).Cells(2).Value = Format(CDbl(objReader(0).ToString), "##0.00")
                End If
            End If
            objReader.Close()
        Next
        AlternateColors()
        dGrid.Focus()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Ledger account cost centers percentages allocation"
        ShowErrorMessage()
    End Sub

    Private Sub frmAccountAllocations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtAccountNumber.Text = strSelectedAccount
        lblDescription.Text = strSelectedAccountName
        LoadCostCenters()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM AccountsAllocations WHERE AccountNumber = '" & txtAccountNumber.Text & "'")
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblRate As Double = 0
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                If IsNumeric(dGrid.Rows(i).Cells(2).Value.ToString) Then
                    dblRate = CDbl(dGrid.Rows(i).Cells(2).Value.ToString)
                End If
            End If
            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO AccountsAllocations (AccountNumber, CostCode, AllocationPercent) " _
                & "VALUES ('" & txtAccountNumber.Text & "', " & dGrid.Rows(i).Cells(0).Value.ToString & ", " & dblRate & ")", cnn)
            objCommand.ExecuteNonQuery()
        Next
        MessageBox.Show("Cost Center allocation rate set successfully", "Cost Center Allocation Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
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
        If dGrid.CurrentCell.ColumnIndex = 2 Then
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                If IsNumeric(dGrid.CurrentCell.Value.ToString) Then
                    dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")
                End If
            End If
        End If
    End Sub

    Private Sub dGrid_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellValueChanged
        On Error Resume Next
        If dGrid.CurrentCell.ColumnIndex = 2 Then
            If Not (Object.Equals(Convert.ToString(dGrid.CurrentCell.Value), "")) Then
                If IsNumeric(dGrid.CurrentCell.Value.ToString) Then
                    dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value.ToString), "##0.00")
                End If
            End If
        End If
    End Sub

End Class
