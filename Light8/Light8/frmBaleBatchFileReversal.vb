Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmBaleBatchFileReversal

    Dim intNumberOfBalesInFile As Integer

    Private Sub frmBaleBatchFileReversal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dGrid.Rows.Clear()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT DISTINCT(FileNumber) FROM BaleItems WHERE FileNumber > 0"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        With dGridBatches
            .Rows.Clear()
            While objReader.Read
                .Rows.Add(False, objReader(0).ToString)
            End While
            objReader.Close()
        End With

        strSql = "UPDATE BaleItems SET Tare = 0"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Sent Batches Load"
        ShowErrorMessage()
    End Sub

    Private Sub dGridBatches_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGridBatches.CellEndEdit
        If e.ColumnIndex = 0 Then
            'Clear and repopulate the grid
            dGrid.Rows.Clear()
            For p As Integer = 0 To dGridBatches.Rows.Count - 1
                If dGridBatches.Rows(p).Cells(0).Value = True Then
                    PopulateDetails(p)
                    lblTotal.Text = dGrid.Rows.Count
                End If
            Next
        End If
    End Sub

    Private Sub dGridBatches_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dGridBatches.MouseUp
        If dGridBatches.Rows.Count <= 0 Then Exit Sub
        If dGridBatches.CurrentCell.ColumnIndex = 0 Then
            dGridBatches.EndEdit()
        End If
    End Sub

    Private Sub PopulateDetails(ByVal Row As Integer)
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim intBatch As Integer = 0
        If Not Object.Equals(dGridBatches.Rows(Row).Cells(1).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridBatches.Rows(Row).Cells(1).Value.ToString) Then
                If IsNumeric(dGridBatches.Rows(Row).Cells(1).Value.ToString) Then
                    intBatch = CInt(dGridBatches.Rows(Row).Cells(1).Value.ToString)
                End If
            End If
        End If
        Dim strSql As String = "SELECT BarCode, ControlGrade, CustomerGrade, Tare, Weight, Price, Grower, Moisture, LotNumber FROM BaleItems WHERE FileNumber = " & intBatch & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5), objReader(6), objReader(7), objReader(8))
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Sent Batches Details Load"
        ShowErrorMessage()
    End Sub


    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        dGrid.Rows.Clear()
        LoadData()
    End Sub

    Private Sub dGrid_RowsRemoved(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dGrid.RowsRemoved
        lblTotal.Text = dGrid.Rows.Count
    End Sub


    Private Sub btnReverseFile_Click(sender As System.Object, e As System.EventArgs) Handles btnReverseFile.Click
        On Error GoTo RaiseErr

        Dim arrSelectedFiles As New ArrayList
        For p As Integer = 0 To dGridBatches.Rows.Count - 1
            With dGridBatches
                If .Rows(p).Cells(0).Value = True Then
                    If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(.Rows(p).Cells(1).Value.ToString) Then
                            If IsNumeric(.Rows(p).Cells(1).Value.ToString) Then
                                arrSelectedFiles.Add(.Rows(p).Cells(1).Value.ToString)
                            End If
                        End If
                    End If
                End If
            End With
        Next

        If arrSelectedFiles.Count > 0 Then
            If MessageBox.Show("Are you sure you want to reverse this and rescan the bales?", "Confirm Reversal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                For p As Integer = 0 To arrSelectedFiles.Count - 1
                    Dim strSql As String = "Delete from BaleHeaders WHERE FileNumber = " & CInt(arrSelectedFiles.Item(p)) & ""
                    Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                Next
                With dGrid
                    For p As Integer = 0 To .Rows.Count - 1
                        Dim strBarcode As String = Nothing
                        If Not Object.Equals(.Rows(p).Cells(0).Value, Nothing) Then
                            If Not String.IsNullOrEmpty(.Rows(p).Cells(0).Value.ToString) Then
                                strBarcode = .Rows(p).Cells(0).Value.ToString
                            End If
                        End If
                        Dim strUpdate As String = "UPDATE BaleItems SET SentStatus = 'NO', " _
                            & "TransmissionDate = null, DriverName = '', FileNumber = 0, FileId = '', SendBatchNo = 0 " _
                            & "WHERE Barcode = '" & strBarcode & "'"
                        Dim objUpdate As New Data.OleDb.OleDbCommand(strUpdate, cnn)
                        objUpdate.ExecuteNonQuery()
                    Next
                End With
                MessageBox.Show("Selected files have been reversed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dGrid.Rows.Clear()
                LoadData()
            End If
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Sent Batches Reversal"
        ShowErrorMessage()
    End Sub

End Class