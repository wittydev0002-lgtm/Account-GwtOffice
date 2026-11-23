Public Class frmCummulativeTaxPrintParameters

    Private Sub frmCummulativeTaxPrintParameters_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing

        strSql = "SELECT LastName, FirstName +' '+ OtherNames AS [Given Names], CONVERT(NVARCHAR, TransactionId) AS " _
            & "[ID] FROM EmployeeMaster ORDER BY LastName"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(False, objReader(0), objReader(1), objReader(2))
        End While
        objReader.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On employee details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        StartDate = Format(dpStartDate.Value, "dd-MMM-yyyy")
        EndDate = Format(dpEndDate.Value, "dd-MMM-yyyy")
        arrSelectedItems = New ArrayList
        Dim intCounter As Integer = 0
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If dGrid.Rows(p).Cells(0).Value = True Then
                arrSelectedItems.Add(dGrid.Rows(p).Cells(3).Value.ToString)
                intCounter = intCounter + 1
            End If
        Next
        If intCounter = 0 Then
            MessageBox.Show("No employees have been selected for details print.", "Process will be aborted", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            boolAbort = True
        Else
            boolAbort = False
        End If
        Me.Close()
    End Sub

    Private Sub chkSelectAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If chkSelectAll.Checked = True Then
                dGrid.Rows(p).Cells(0).Value = True
            Else
                dGrid.Rows(p).Cells(0).Value = False
            End If
        Next
    End Sub

    Private Sub dGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dGrid.MouseUp
        On Error GoTo RaiseErr
        If dGrid.CurrentCell.ColumnIndex = 0 Then
            Dim cell As DataGridViewCheckBoxCell = Me.dGrid.CurrentCell
            'Get the value of the current cell
            Dim checked As Boolean = cell.GetEditedFormattedValue(cell.RowIndex, DataGridViewDataErrorContexts.Parsing)
            If checked = True Then
                dGrid.CurrentCell.Value = True
            End If
        Else
            Exit Sub
        End If
        Me.dGrid.EndEdit()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Cummulative Print Parameters Setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmCummulativeTaxPrintParameters_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 432 : Me.Height = 485
    End Sub

End Class
