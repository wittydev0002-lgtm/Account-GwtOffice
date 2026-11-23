Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmReceiptDetails

    'Declare the pen color for use now nd in future 
    Dim myPen As System.Drawing.Pen
    Dim myBrush As System.Drawing.Brush

    Dim HeaderFont As New System.Drawing.Font("Arial", 14, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    Dim DetailsFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Dim FooterFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Dim strSelectedStudentClassName As String = Nothing
    Dim strStudentNames As String = Nothing
    Dim dblInitialTotal As Double = 0

    Private Sub frmReceiptDetails_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F5 Then
            boolAbort = False
            SaveData()
        End If
    End Sub

    Private Sub frmReceiptDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        lblReceiptNumber.Text = intSelectedReceipt
        dpTransDate.Value = CDate(strSelectedDate)
        Dim strStudentId As String = Nothing
        Dim strSql As String = "SELECT SC_StudentTransactions.Description, " _
            & "CAST(CREDIT AS DECIMAL (10,2)) AS [Amount], TransactionId as [Id], " _
            & "SC_StudentTransactions.StudentId FROM SC_StudentTransactions " _
            & "WHERE ReceiptNo = " & intSelectedReceipt & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2))
            If Not IsDBNull(objReader(3).ToString) Then
                strStudentId = objReader(3).ToString
            End If
        End While
        objReader.Close()

        'Get the student details
        strSql = "SELECT LastName +' '+ FirstName +' '+ OtherNames +':'+ ClassName AS [Details] " _
            & "FROM SC_Students WHERE SC_Students.StudentId = '" & strStudentId & "'"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                lblStudentDetails.Text = objReader(0).ToString
            End If
        End If
        objReader.Close()

        If Not String.IsNullOrEmpty(lblStudentDetails.Text) Then
            Dim strBuffer() As String = Split(lblStudentDetails.Text, ":")
            strSelectedStudentClassName = strBuffer(1)
            strStudentNames = strBuffer(0)
        End If

        ComputeTotal()

        dblInitialTotal = CDbl(lblTotalPaid.Text)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Receipt Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        boolAbort = False
        SaveData()
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        For p As Integer = 0 To dGrid.Rows.Count - 1

            Dim strDescription As String = Nothing
            Dim dblValue As Double = 0
            Dim intTransactionId As Integer = 0

            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strDescription = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        dblValue = dGrid.Rows(p).Cells(1).Value.ToString
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(2).Value.ToString) Then
                        intTransactionId = CInt(dGrid.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
            End If

            strSql = "UPDATE [SC_StudentTransactions] SET [Description] = '" & strDescription & "', " _
                & "[Credit] = " & dblValue & ", TransactionDate = '" & Format(dpTransDate.Value, "dd-MMM-yyyy") & "' " _
                & "WHERE TransactionId = " & intTransactionId & ""

            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

        Next

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If MessageBox.Show("Do you want to print the receipt right now?", "Confirm Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            PrintReceipt()
        End If

        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Student Entries Updates"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeTotal()
        On Error GoTo RaiseErr
        Dim dblTotalPaid As Double = 0
        With dGrid
            For p As Integer = 0 To .Rows.Count - 1
                If Not Object.Equals(.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(1).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(1).Value.ToString) Then
                            dblTotalPaid = dblTotalPaid + CDbl(.Rows(p).Cells(1).Value.ToString)
                        End If
                    End If
                End If
            Next
        End With
        lblTotalPaid.Text = Format(dblTotalPaid, "##0.00")

        'Adjust the current balance as well
        lblAccBalance.Text = "0.00"
        If strTransferType = "Credit" Then
            lblAccBalance.Text = Format(CDbl(AccountBalance(lblStudentDetails.Text) - CDbl(lblTotalPaid.Text)), "#,##0.00")
        Else
            lblAccBalance.Text = Format(CDbl(AccountBalance(lblStudentDetails.Text) + CDbl(lblTotalPaid.Text)), "#,##0.00")
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On payment totals computation"
        ShowErrorMessage()
    End Sub

    Private Function AccountBalance(StudentId As String) As Double
        On Error GoTo RaiseErr
        Dim dblReturn As Double = 0
        Dim strSql As String = "SELECT CAST(SUM(SC_StudentTransactions.Debit - SC_StudentTransactions.Credit) AS DECIMAL (10,2)) AS [Balance] " _
            & "FROM SC_StudentTransactions WHERE SC_StudentTransactions.StudentId = '" & StudentId & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblReturn = CDbl(objReader(0).ToString)
            End If
        End If
        objReader.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Student Balance Fetch"
        ShowErrorMessage()
    End Function

    Private Sub PrintReceipt()
        boolAbort = False
        Dim prnt As New frmPrinterSetup
        prnt.ShowDialog()
        If boolAbort = True Then Exit Sub
        PrintDocument1.PrinterSettings.PrinterName = strSessionPrinter

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = PrintDocument1
        documentPreview.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        On Error GoTo RaiseErr
        'Print the school details on top first
        Dim intX As Integer = 100 'left first alignment
        Dim intY As Integer = 100 'top first alignment
        myPen = New Pen(Brushes.Black)

        'Print the school name in bold
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 500, 80, strCompanyName, HeaderFont, Brushes.Black)
        intY = intY + 30
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 200, 80, strCompanyAddress1, DetailsFont, Brushes.Black)
        intY = intY + 15
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 200, 80, strCompanyAddress2, DetailsFont, Brushes.Black)
        intY = intY + 15
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 200, 80, strCompanyAddress3, DetailsFont, Brushes.Black)
        intY = intY + 15
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 200, 80, strCompanyAddress4, DetailsFont, Brushes.Black)
        intY = intY + 15
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 200, 80, strCompanyTelephone, DetailsFont, Brushes.Black)
        intY = intY + 25

        'Print date
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 200, 80, "DATE   : " & UCase(Format(dpTransDate.Value, "dd-MMM-yyyy")), DetailsFont, Brushes.Black)
        intY = intY + 15

        'Print receipt number
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 200, 80, "REC. # : " & UCase(lblReceiptNumber.Text), DetailsFont, Brushes.Black)
        intY = intY + 25

        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 500, 80, UCase(strStudentNames) & " CLASS : " & UCase(strSelectedStudentClassName), DetailsFont, Brushes.Black)
        intY = intY + 25

        'Draw line under
        e.Graphics.DrawLine(myPen, intX, intY, intX + 600, intY)
        intY = intY + 15

        'Draw the line headers
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 200, 80, "Description", DetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 200, intY, 150, 80, "Reference", DetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 290, intY, 100, 80, "Amount", DetailsFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX + 380, intY, 200, 80, "Remarks", DetailsFont, Brushes.Black)

        intY = intY + 20
        'Draw line under
        e.Graphics.DrawLine(myPen, intX, intY, intX + 600, intY)
        intY = intY + 15

        For p As Integer = 0 To dGrid.Rows.Count - 1

            Dim strDescription As String = Nothing
            Dim strReference As String = Nothing
            Dim dblValue As Double = 0
            Dim strRemarks As String = Nothing

            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strDescription = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        dblValue = dGrid.Rows(p).Cells(1).Value.ToString
                    End If
                End If
            End If

            If dblValue <> 0 Then
                Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 200, 80, strDescription, DetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, intX + 200, intY, 150, 80, strReference, DetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxRight(e, intX + 250, intY, 100, 80, CStr(Format(dblValue, "#,##0.00")), DetailsFont, Brushes.Black)
                Call gwt_comm.DrawStringInBoxLeft(e, intX + 380, intY, 300, 80, strRemarks, DetailsFont, Brushes.Black)

                intY = intY + 15
            End If

        Next

        'Draw a line and the print the receipt total

        intY = intY + 15
        e.Graphics.DrawLine(myPen, intX, intY, intX + 600, intY)
        intY = intY + 15
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 500, 80, "TOTAL AMOUNT RECEIVED $" & lblTotalPaid.Text, HeaderFont, Brushes.Black)
        intY = intY + 30
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 500, 80, "Received with thanks by " & strUserName, DetailsFont, Brushes.Black)
        intY = intY + 15
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 500, 80, "Date and time " & UCase(Now), DetailsFont, Brushes.Black)

        e.HasMorePages = False

        Exit Sub

RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On Receipt Printing"
        ShowErrorMessage()
    End Sub

    Private Sub chkOverideDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOverideDate.CheckedChanged
        If chkOverideDate.Checked = True Then
            If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
                dpTransDate.Enabled = True
            Else
                boolAbort = False
                boolAuthorized = False
                Dim f As New frmSupervisorAuthorizaton
                f.ShowDialog()
                If boolAbort = True Then
                    chkOverideDate.Checked = False
                    Exit Sub
                End If
                If boolAuthorized = True Then
                    dpTransDate.Enabled = True
                    boolAuthorized = False
                End If
            End If
        Else
            dpTransDate.Enabled = False
            boolAuthorized = False
        End If
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        If dblInitialTotal <> CDbl(lblTotalPaid.Text) Then
            MessageBox.Show("Changes have been made to this transaction." & vbCrLf & "Printing can only be done through saving first", "Printing Inconsistancy", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Else
            PrintReceipt()
        End If
    End Sub

    Private Sub dGrid_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex = 1 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
            ComputeTotal()
        End If
    End Sub

End Class
