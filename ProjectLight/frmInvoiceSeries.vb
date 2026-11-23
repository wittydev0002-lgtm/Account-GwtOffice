Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInvoiceSeries
    Private Sub frmInvoiceSeries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr

        Dim strLastDayOfMonth As String = gwt_comm.LastDateofMonth(DatePart(DateInterval.Month, invoiceDate), DatePart(DateInterval.Year, invoiceDate))
        Dim strFirstDayOfMonth As String = gwt_comm.FirstDateofMonth(DatePart(DateInterval.Month, invoiceDate), DatePart(DateInterval.Year, invoiceDate))

        On Error GoTo RaiseErr

        Dim intStartingNumber As Long = 0
        Dim intEndingNumber As Long = gwt_comm.GetNextDocumentNumber("Invoices")

        Dim strSql As String = "SELECT InvoiceNumber FROM CustomerSalesMain WHERE TransDate BETWEEN '" & strFirstDayOfMonth & "' AND '" & strLastDayOfMonth & "' ORDER BY InvoiceNumber"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intStartingNumber = CLng(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        If intStartingNumber = 0 Then
            intStartingNumber = gwt_comm.GetNextDocumentNumber("Invoices")
        End If

        Dim intTempEndingNumber As Long = 0
        strSql = "SELECT InvoiceNumber FROM CustomerSalesMain WHERE TransDate = '" & strFirstDayOfMonth & "' ORDER BY InvoiceNumber DESC"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intTempEndingNumber = CLng(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        If intTempEndingNumber > intEndingNumber Then
            intEndingNumber = intTempEndingNumber
        End If

        For p As Long = intStartingNumber To intEndingNumber - 1
            dGrid.Rows.Add(False, p, Nothing)
        Next

        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim inv As Long = 0
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        inv = CLng(dGrid.Rows(p).Cells(1).Value.ToString)
                        strSql = "SELECT UPPER(REPLACE(CONVERT(NVARCHAR, [TransDate], 106), ' ', '-')) AS [Date] " _
                            & "FROM CustomerSalesMain WHERE InvoiceNumber = " & inv & ""
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objReader = objCommand.ExecuteReader
                        If objReader.HasRows Then
                            objReader.Read()
                            If Not IsDBNull(objReader(0).ToString) Then
                                dGrid.Rows(p).Cells(2).Value = objReader(0).ToString
                            End If
                        End If
                        objReader.Close()
                    End If
                End If
            End If
        Next

        'strSql = "SELECT InvoiceNumber, UPPER(REPLACE(CONVERT(NVARCHAR, [TransDate], 106), ' ', '-')) AS [Date] " _
        '    & "FROM CustomerSalesMain WHERE TransDate BETWEEN '" & strFirstDayOfMonth & "' AND '" & strLastDayOfMonth & "'"
        'objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        'objReader = objCommand.ExecuteReader
        'dGrid.Rows.Clear()
        'While objReader.Read
        '    dGrid.Rows.Add(False, objReader(0), objReader(1))
        'End While
        'objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Invoice Series Fetch"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        intNextInvoiceNumber = gwt_comm.GetNextDocumentNumber("Invoices")
        Me.Close()
    End Sub

    Private Sub btnSelected_Click(sender As Object, e As EventArgs) Handles btnSelected.Click
        intNextInvoiceNumber = 0
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If dGrid.Rows(p).Cells(0).Value = True Then
                If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                            intNextInvoiceNumber = CInt(dGrid.Rows(p).Cells(1).Value.ToString)
                            Exit For
                        End If
                    End If
                End If
            End If
        Next
        If intNextInvoiceNumber = 0 Then
            MessageBox.Show("You did not select any number to use", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            boolInvoiceOverwritten = True
            Me.Close()
        End If
    End Sub

    Private Sub dGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dGrid.MouseUp
        If dGrid.CurrentCell.ColumnIndex <> 0 Then Exit Sub

        On Error GoTo RaiseErr
        Dim cell As DataGridViewCheckBoxCell = Me.dGrid.CurrentCell
        'Get the value of the current cell
        Dim checked As Boolean = cell.GetEditedFormattedValue(cell.RowIndex, DataGridViewDataErrorContexts.Parsing)
        If checked = True Then
            If cell.ColumnIndex = 0 Then
                If Not Object.Equals(dGrid.CurrentRow.Cells(2).Value, Nothing) Then
                    MessageBox.Show("This invoice cannot used", "Invoice Number In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.dGrid.EndEdit()
                    For p As Integer = 0 To dGrid.Rows.Count - 1
                        dGrid.Rows(p).Cells(0).Value = False
                    Next
                Else
                    Dim intRow As Integer = dGrid.CurrentRow.Index
                    For p As Integer = 0 To dGrid.Rows.Count - 1
                        If p <> intRow Then
                            dGrid.Rows(p).Cells(0).Value = False
                        End If
                    Next
                End If
            End If
        End If
        Me.dGrid.EndEdit()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Invoice Series Processing"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmInvoiceSeries_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 335 : Me.Height = 415
    End Sub

End Class