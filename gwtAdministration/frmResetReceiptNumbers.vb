Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms

Public Class frmResetReceiptNumbers

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not IsNumeric(txtStartNumber.Text) Then
            MessageBox.Show("Please enter the new starting number", "Missing Starting Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtStartNumber.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboDocType.Text) Then
            MessageBox.Show("Please the document types to be adjusted", "Missing Document Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboDocType.Focus()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim strSql As String = Nothing
        Dim intCount As Integer = 0
        Cursor = Cursors.WaitCursor
        Select Case cboDocType.Text

            Case Is = "Invoices"
                strSql = "SELECT COUNT(InvoiceNumber) FROM CustomerSalesMain WHERE TransDate " _
                    & "BETWEEN '" & gwt_comm.shortMonthDateFormat(dpFrom.Value) & "' AND " _
                    & "'" & gwt_comm.shortMonthDateFormat(dpTo.Value) & "'"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then intCount = CInt(objReader(0).ToString)
                End If
                objReader.Close()
                With pb1
                    .Value = 0
                    .Maximum = intCount + 10
                    .Visible = True
                End With
                strSql = "SELECT InvoiceNumber, UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date] " _
                    & "FROM CustomerSalesMain WHERE TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpFrom.Value) & "' AND " _
                    & "'" & gwt_comm.shortMonthDateFormat(dpTo.Value) & "' ORDER BY InvoiceNumber  "
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objReader = objCommand.ExecuteReader
                Dim intNewInvoiceNumber As Long = CLng(txtStartNumber.Text)
                While objReader.Read
                    objCommand = New Data.OleDb.OleDbCommand("UPDATE CustomerSalesMain SET InvoiceNumber = " & intNewInvoiceNumber & " " _
                        & "WHERE InvoiceNumber = " & objReader(0).ToString & "", cnn)
                    objCommand.ExecuteNonQuery()
                    objCommand = New Data.OleDb.OleDbCommand("UPDATE CustomerSales SET InvoiceNumber = " & intNewInvoiceNumber & " " _
                        & "WHERE InvoiceNumber = " & objReader(0).ToString & "", cnn)
                    objCommand.ExecuteNonQuery()
                    intNewInvoiceNumber = intNewInvoiceNumber + 1
                    pb1.Value = pb1.Value + 1
                End While
                objReader.Close()
            Case Is = "Cash Receipts"
                strSql = "SELECT COUNT(InvoiceNumber) FROM SalesMain WHERE TransDate " _
                    & "BETWEEN '" & gwt_comm.shortMonthDateFormat(dpFrom.Value) & "' AND " _
                    & "'" & gwt_comm.shortMonthDateFormat(dpTo.Value) & "'"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then intCount = CInt(objReader(0).ToString)
                End If
                objReader.Close()
                With pb1
                    .Value = 0
                    .Maximum = intCount + 10
                    .Visible = True
                End With
                strSql = "SELECT InvoiceNumber, UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date] " _
                    & "FROM SalesMain WHERE TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpFrom.Value) & "' AND " _
                    & "'" & gwt_comm.shortMonthDateFormat(dpTo.Value) & "' ORDER BY InvoiceNumber  "
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objReader = objCommand.ExecuteReader
                Dim intNewInvoiceNumber As Long = CLng(txtStartNumber.Text)
                While objReader.Read
                    objCommand = New Data.OleDb.OleDbCommand("UPDATE SalesMain SET InvoiceNumber = " & intNewInvoiceNumber & " " _
                        & "WHERE InvoiceNumber = " & objReader(0).ToString & "", cnn)
                    objCommand.ExecuteNonQuery()
                    objCommand = New Data.OleDb.OleDbCommand("UPDATE Sales SET InvoiceNumber = " & intNewInvoiceNumber & " " _
                        & "WHERE InvoiceNumber = " & objReader(0).ToString & "", cnn)
                    objCommand.ExecuteNonQuery()
                    intNewInvoiceNumber = intNewInvoiceNumber + 1
                    pb1.Value = pb1.Value + 1
                End While
                objReader.Close()
            Case Is = "Quotations"
                strSql = "SELECT COUNT(ReferenceNumber) FROM QuoteMain WHERE TransDate " _
                    & "BETWEEN '" & gwt_comm.shortMonthDateFormat(dpFrom.Value) & "' AND " _
                    & "'" & gwt_comm.shortMonthDateFormat(dpTo.Value) & "'"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then intCount = CInt(objReader(0).ToString)
                End If
                objReader.Close()
                With pb1
                    .Value = 0
                    .Maximum = intCount + 10
                    .Visible = True
                End With
                strSql = "SELECT ReferenceNumber, UPPER(REPLACE(CONVERT(CHAR(11), TransDate, 106), ' ', '-')) as [Date] " _
                    & "FROM QuoteMain WHERE TransDate BETWEEN '" & gwt_comm.shortMonthDateFormat(dpFrom.Value) & "' AND " _
                    & "'" & gwt_comm.shortMonthDateFormat(dpTo.Value) & "' ORDER BY ReferenceNumber  "
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objReader = objCommand.ExecuteReader
                Dim intNewInvoiceNumber As Long = CLng(txtStartNumber.Text)
                While objReader.Read
                    objCommand = New Data.OleDb.OleDbCommand("UPDATE QuoteMain SET ReferenceNumber = " & intNewInvoiceNumber & " " _
                        & "WHERE ReferenceNumber = " & objReader(0).ToString & "", cnn)
                    objCommand.ExecuteNonQuery()
                    objCommand = New Data.OleDb.OleDbCommand("UPDATE QuoteDetails SET ReferenceNumber = " & intNewInvoiceNumber & " " _
                        & "WHERE ReferenceNumber = " & objReader(0).ToString & "", cnn)
                    objCommand.ExecuteNonQuery()
                    intNewInvoiceNumber = intNewInvoiceNumber + 1
                    pb1.Value = pb1.Value + 1
                End While
                objReader.Close()
        End Select
        Cursor = Cursors.Default
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On document numbers reset"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
