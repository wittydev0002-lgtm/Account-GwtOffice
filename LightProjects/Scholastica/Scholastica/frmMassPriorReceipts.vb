Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMassPriorReceipts

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
        If e.ColumnIndex = 2 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
        End If
    End Sub

    Private Sub frmMassPriorReceipts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With arrSelectedItems
            For p As Integer = 0 To .Count - 1
                Dim strBuffer() As String = Split(arrSelectedItems.Item(p), "|")
                dGrid.Rows.Add(UCase(strBuffer(0)), UCase(strBuffer(1)), Format(CDbl(strBuffer(2)), "##0.00"), "0.00", "")
            Next
        End With
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim intStudent As Integer = 0
            Dim dblAmount As Double = 0
            Dim strReceptNo As String = Nothing
            Dim strDetails As String = Nothing
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(0).Value.ToString) Then
                        intStudent = CInt(dGrid.Rows(p).Cells(0).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    strDetails = dGrid.Rows(p).Cells(1).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(3).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(3).Value.ToString) Then
                        dblAmount = CDbl(dGrid.Rows(p).Cells(3).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(4).Value.ToString) Then
                    strReceptNo = dGrid.Rows(p).Cells(4).Value.ToString
                End If
            End If

            If dblAmount <> 0 Then
                Dim strSql As String = "INSERT INTO [SC_StudentTransactions] ([StudentId],[Description],[Reference]," _
                    & "[Debit],[Credit],[UserName],[TransactionDate],[Remarks], [ReceiptNo]) VALUES " _
                    & "(" & intStudent & ", '" & strDetails & "', '" & strReceptNo & "', " _
                    & " 0, " & dblAmount & ", " _
                    & "'" & strUserName & "', '" & Format(Now, "dd-MMM-yyyy") & "', " _
                    & "'UPDATING PRIOR PAYMENTS', 0)"
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next
        MessageBox.Show("Process has been completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On receipt update"
        ShowErrorMessage()
    End Sub

End Class
