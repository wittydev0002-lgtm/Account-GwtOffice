Public Class frmLineItemsPrintParameters

    Private Sub frmLineItemsPrintParameters_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadPaymentCodes()
    End Sub

    Private Sub LoadPaymentCodes()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim myCommand As New Data.OleDb.OleDbCommand("SELECT CodeNo, Description " _
            & "FROM PaymentCodes ORDER BY Description", cnn)
        Dim dbReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
        dGrid.Rows.Clear()
        While dbReader.Read
            dGrid.Rows.Add(False, Format(CInt(dbReader(0).ToString), "000"), dbReader(1))
        End While
        dbReader.Close()
        'add the aids levy and PAYE field options
        With dGrid
            .Rows.Add(False, "990", "PAYE")
            .Rows.Add(False, "991", "AIDS LEVY")
        End With
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCritical & "On Payment Code Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dGrid.MouseUp
        On Error GoTo RaiseErr
        If dGrid.CurrentCell.ColumnIndex = dGrid.ColumnCount - 1 Then
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Line Items Print Options"
        ShowErrorMessage()
    End Sub

    Private Sub frmLineItemsPrintParameters_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 405 : Me.Height = 468
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        StartDate = Format(dpStartDate.Value, "dd-MMM-yyyy")
        EndDate = Format(dpEndDate.Value, "dd-MMM-yyyy")
        arrSelectedItems = New ArrayList
        arrCodeKey = New ArrayList
        Dim intCounter As Integer = 0
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If dGrid.Rows(p).Cells(0).Value = True Then
                arrSelectedItems.Add(dGrid.Rows(p).Cells(1).Value.ToString)
                arrCodeKey.Add(dGrid.Rows(p).Cells(1).Value.ToString & " = " & dGrid.Rows(p).Cells(2).Value.ToString)
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

End Class
