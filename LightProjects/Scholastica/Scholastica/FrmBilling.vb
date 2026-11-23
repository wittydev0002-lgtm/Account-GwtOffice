Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class FrmBilling

    'Dim strCostingCode As String

    'Dim intPrintCount As Integer = 0
    'Dim arrInvoiceDetails As ArrayList
    'Dim dblBalanceFromLastTerms As Double
    'Dim itm As Integer

    'Dim arrBilledStudentsNumbers As New ArrayList

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(cboTerm.Text) Then
            MessageBox.Show("Please select the relevant term", "Invalid Term", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboTerm.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboYear.Text) Then
            MessageBox.Show("Please select the relevant year", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboYear.Focus()
            Exit Sub
        End If

        dpDueDateSelected = dpDueDate.Value
        strSelectedTerm = cboTerm.Text
        intInvoiceYear = cboYear.Text
        dtSetDate = dpTransactionDate.Value
        strPublicNotePriority = txtSpecialNotes.Text

        boolAbort = False
        Me.Close()
        '        On Error GoTo RaiseErr

        '        Cursor = Cursors.WaitCursor

        '        Dim intCounter As Integer = 0
        '        arrBilledStudentsNumbers = New ArrayList

        '        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT COUNT(SC_Students.studentId) " _
        '            & "FROM SC_Students WHERE status = 'ACTIVE'", cnn)
        '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        '        If objReader.HasRows Then
        '            objReader.Read()
        '            If IsNumeric(objReader(0).ToString) Then
        '                intCounter = CInt(objReader(0).ToString)
        '            End If
        '        End If
        '        objReader.Close()

        '        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SC_LastBilledStudents", cnn)
        '        objCommand.ExecuteNonQuery()

        '        With ProgressBar1
        '            .Value = 0
        '            .Maximum = intCounter + 10
        '            .Visible = True
        '        End With
        '        Dim strSql As String = "SELECT SC_Students.studentId, " _
        '            & "ClassName FROM SC_Students WHERE status = 'ACTIVE'"
        '        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        '        objReader = objCommand.ExecuteReader()
        '        While objReader.Read
        '            If Not IsDBNull(objReader(0).ToString) Then
        '                Dim dblValue As Double = GetStudentTermFee(objReader(1).ToString)
        '                If dblValue <> 0 Then
        '                    strSql = "INSERT INTO SC_StudentTransactions (StudentId, Description, Debit, " _
        '                        & "UserName, TransactionDate, CostCode, ReceiptNo, SchoolTerm, TermYear) VALUES " _
        '                        & "('" & objReader(0).ToString & "', 'SCHOOL FEES-" & cboTerm.Text & "', " _
        '                        & "" & dblValue & ", '" & strUserName & "', '" & Format(dpTransactionDate.Value, "dd-MMM-yyyy") & "', " _
        '                        & "'" & strCostingCode & "', 0, '" & cboTerm.Text & "', " & cboYear.Text & ")"
        '                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        '                    objCommand.ExecuteNonQuery()
        '                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SC_LastBilledStudents (StudentId) VALUES ('" & objReader(0).ToString & "')", cnn)
        '                    objCommand.ExecuteNonQuery()
        '                End If
        '            End If
        '            ProgressBar1.Value = ProgressBar1.Value + 1
        '        End While
        '        objReader.Close()
        '        ProgressBar1.Value = ProgressBar1.Maximum
        '        Cursor = Cursors.Default
        '        MessageBox.Show("School fee postings have been completed successfully." & vbCrLf & "Please wait while statements are being generated", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '        arrBilledStudentsNumbers = New ArrayList
        '        objCommand = New Data.OleDb.OleDbCommand("SELECT SC_LastBilledStudents.StudentId, SC_Students.ClassName " _
        '            & "FROM SC_LastBilledStudents LEFT OUTER JOIN SC_Students ON SC_LastBilledStudents.StudentId = SC_Students.StudentId " _
        '            & "ORDER BY ClassName, LastName, FirstName", cnn)
        '        objReader = objCommand.ExecuteReader
        '        While objReader.Read
        '            If Not IsDBNull(objReader(0).ToString) Then
        '                arrBilledStudentsNumbers.Add(objReader(0).ToString)
        '            End If
        '        End While
        '        objReader.Close()

        '        itm = 0 : intPrintCount = arrBilledStudentsNumbers.Count
        '        Dim ppd As New PrintPreviewDialog
        '        ppd.Document = pdoc
        '        ppd.ShowDialog()

        '        Exit Sub
        'RaiseErr:
        '        boolAbort = True
        '        Cursor = Cursors.Default
        '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Students Term Billing"
        '        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    '    Private Function GetStudentTermFee(ClassName As String) As Double
    '        On Error GoTo RaiseErr
    '        Dim dblReturn As Double = 0
    '        strCostingCode = Nothing
    '        Dim strSql As String = "SELECT CostCenter FROM SC_Classes WHERE ClassName = '" & ClassName & "'"
    '        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '        If objReader.HasRows Then
    '            objReader.Read()
    '            If Not IsDBNull(objReader(0).ToString) Then strCostingCode = objReader(0).ToString
    '        End If
    '        objReader.Close()

    '        'Get the actual cost here. Also assign the payment descriptions for use in the invoice print
    '        arrInvoiceDetails = New ArrayList

    '        If Not String.IsNullOrEmpty(strCostingCode) Then
    '            strSql = "SELECT SUM(SC_PaymentDescriptionAmts.Amount) AS [Amt], " _
    '                & "SC_PaymentDescriptions.Description FROM SC_PaymentDescriptionAmts " _
    '                & "LEFT JOIN SC_PaymentDescriptions ON SC_PaymentDescriptionAmts.Description = " _
    '                & "SC_PaymentDescriptions.Description WHERE " _
    '                & "((SC_PaymentDescriptions.PaymentType = 'RECURRING') AND " _
    '                & "(SC_PaymentDescriptionAmts.CostCode = '" & strCostingCode & "')) " _
    '                & "GROUP BY SC_PaymentDescriptionAmts.Amount, SC_PaymentDescriptions.Description"
    '            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
    '            objReader = objCommand.ExecuteReader
    '            While objReader.Read
    '                If IsNumeric(objReader(0).ToString) Then
    '                    arrInvoiceDetails.Add(objReader(1).ToString & "|" & objReader(0).ToString)
    '                    dblReturn = dblReturn + CDbl(objReader(0).ToString)
    '                End If
    '            End While
    '            objReader.Close()
    '        End If
    '        Return dblReturn
    '        Exit Function
    'RaiseErr:
    '        boolAbort = True
    '        Cursor = Cursors.Default
    '        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Students Term Billing"
    '        ShowErrorMessage()
    '    End Function

    '    Private Sub pdoc_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoc.PrintPage

    '        'Print the school logo


    '        'Print the student information

    '        'Print the Year and term information
    '        'Print the document information : Invoice number, date of printing, due date

    '        'Print balance from previous term
    '        'Current billing
    '        'Total balance due

    '        'Special information

    '        Dim intY As Integer = 100
    '        Dim intX As Integer = 100


    '        Dim strSurname As String = Nothing
    '        Dim strGivenNames As String = Nothing
    '        Dim strStudentNumber As String = UCase(arrBilledStudentsNumbers.Item(itm))
    '        Dim strClass As String = Nothing

    '        '*************** GET THE SELECTED STUDENT DETAILS ****************

    '        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ClassName, LastName, " _
    '            & "FirstName +' '+ OtherNames AS [GivenNames], SchoolAllocatedNumber " _
    '            & "FROM SC_Students WHERE StudentId = '" & arrBilledStudentsNumbers.Item(itm) & "'", cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
    '        If objReader.HasRows Then
    '            objReader.Read()
    '            If Not IsDBNull(objReader(0).ToString) Then strClass = objReader(0).ToString
    '            If Not IsDBNull(objReader(1).ToString) Then strSurname = objReader(1).ToString
    '            If Not IsDBNull(objReader(2).ToString) Then strGivenNames = Trim(objReader(2).ToString)
    '            If Not IsDBNull(objReader(3).ToString) Then
    '                If Not String.IsNullOrEmpty(objReader(3).ToString) Then
    '                    If UCase(objReader(3).ToString) <> UCase(strStudentNumber) Then
    '                        strStudentNumber = UCase(objReader(3).ToString)
    '                    End If
    '                End If
    '            End If
    '        End If
    '        objReader.Close()

    '        'Get the past balance

    '        dblBalanceFromLastTerms = AccountBalance(arrBilledStudentsNumbers.Item(itm))
    '        Dim dblCurrentTotal As Double = GetStudentTermFee(strClass)

    '        'Draw a line thereafter
    '        e.Graphics.DrawLine(Pens.Black, intX, intY, intX + 600, intY)
    '        intY = intY + 15
    '        Call gwt_comm.DrawStringInBoxCenter(e, intX, intY, intX + 500, intY, "FEES INVOICE", fntHeaderFont, Brushes.Black)
    '        intY = intY + 25
    '        e.Graphics.DrawLine(Pens.Black, intX, intY, intX + 600, intY)
    '        intY = intY + 25 'This is the point where we started drawing the boxes
    '        Dim intYboxStart As Integer = intY

    '        'Draw the main student box
    '        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX, intY + 1, 300, 130))
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 10, 175, intX + 300, 175, "STUDENT DETAILS", fntHeaderFont, Brushes.Black)
    '        e.Graphics.DrawLine(Pens.Black, intX, 195, intX + 300, 195)
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 10, 200, intX + 100, 200, "Surname", fntDetailsFontBold, Brushes.Black)
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 10, 220, intX + 100, 220, "Given Names", fntDetailsFontBold, Brushes.Black)
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 10, 240, intX + 100, 240, "Class", fntDetailsFontBold, Brushes.Black)
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 10, 260, intX + 100, 260, "Student ID", fntDetailsFontBold, Brushes.Black)

    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 110, 200, intX + 200, 200, UCase(strSurname), fntDetailsFont, Brushes.Black)
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 110, 220, intX + 200, 220, UCase(strGivenNames), fntDetailsFont, Brushes.Black)
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 110, 240, intX + 200, 240, UCase(strClass), fntDetailsFont, Brushes.Black)
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 110, 260, intX + 200, 260, UCase(strStudentNumber), fntDetailsFont, Brushes.Black)

    '        'e.Graphics.DrawRectangle(Pens.Navy, intX, intY, intX + 250, intY + 150)
    '        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX + 400, 166, 200, 30))
    '        'Write the letters
    '        e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX + 402, 168, 50, 26))
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 405, 173, intX + 600, 173, "Year", fntHeaderFont, Brushes.Black)
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 455, 173, intX + 600, 173, UCase(cboYear.Text), fntHeaderFont, Brushes.Black)
    '        e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX + 500, 168, 50, 26))
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 505, 173, intX + 600, 173, "Term", fntHeaderFont, Brushes.Black)
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 555, 173, intX + 600, 173, UCase(cboTerm.Text), fntHeaderFont, Brushes.Black)

    '        'Print the docment number box
    '        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX + 400, 200, 200, 30))
    '        e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX + 401, 201, 100, 27))
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 405, 205, intX + 600, 205, "Invoice No.", fntHeaderFont, Brushes.Black)
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 505, 210, intX + 600, 210, "201600001", fntDetailsFont, Brushes.Black)

    '        'Print the due date box
    '        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX + 400, 235, 200, 30))
    '        e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX + 401, 236, 100, 27))
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 405, 240, intX + 600, 240, "Due Date", fntHeaderFont, Brushes.Black)
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 505, 245, intX + 600, 245, UCase(Format(dpDueDate.Value, "dd-MMM-yyyy")), fntDetailsFont, Brushes.Black)

    '        Call gwt_comm.DrawStringInBoxLeft(e, intX, 310, intX + 600, 240, "Balance brought forward from previous terms : " & Format(dblBalanceFromLastTerms, "#,##0.00"), fntDetailsFont, Brushes.Black)

    '        'Print the details header
    '        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX, 340, 600, 30))
    '        e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX, 342, 600, 27))
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 2, 345, intX + 600, 205, UCase("Description"), fntHeaderFont, Brushes.Black)
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 505, 350, intX + 600, 210, UCase("Amount"), fntHeaderFont, Brushes.Black)

    '        'Start printing the breakdown here

    '        intY = 390

    '        For p As Integer = 0 To arrInvoiceDetails.Count - 1
    '            'Write the details here
    '            Dim strBuffer() As String = Split(arrInvoiceDetails.Item(p), "|")
    '            Call gwt_comm.DrawStringInBoxLeft(e, intX + 2, intY, intX + 400, 80, strBuffer(0), fntDetailsFont, Brushes.Black)
    '            Call gwt_comm.DrawStringInBoxRight(e, intX + 505, intY + 10, intX + 500, 80, _
    '                Format(CDbl(strBuffer(1)), "#,##0.00"), fntDetailsFont, Brushes.Black)
    '            'dblCurrentTotal = dblCurrentTotal + CDbl(strBuffer(0))
    '            intY = intY + 15
    '        Next

    '        intY = intY + 20

    '        'Print the final balance total here 
    '        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX + 400, intY, 200, 30))
    '        e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX + 401, intY + 1, 100, 27))
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 405, intY + 5, intX + 600, 240, "Current Total", fntHeaderFont, Brushes.Black)
    '        Call gwt_comm.DrawStringInBoxRight(e, intX + 505, intY + 10, intX + 500, 80, Format(dblCurrentTotal, "#,##0.00"), fntDetailsFont, Brushes.Black)

    '        intY = intY + 35
    '        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(intX + 400, intY, 200, 30))
    '        e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(intX + 401, intY + 1, 100, 27))
    '        Call gwt_comm.DrawStringInBoxLeft(e, intX + 405, intY + 5, intX + 600, 240, "Balance Due", fntHeaderFont, Brushes.Black)
    '        Call gwt_comm.DrawStringInBoxRight(e, intX + 505, intY + 10, intX + 500, 80, _
    '            Format((dblBalanceFromLastTerms + dblCurrentTotal), "#,##0.00"), fntDetailsFont, Brushes.Black)

    '        If itm >= (intPrintCount - 1) Then
    '            e.HasMorePages = False
    '            itm = 0
    '        Else
    '            e.HasMorePages = True
    '            itm = itm + 1
    '        End If

    '    End Sub

    'Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    '    Dim ppd As New PrintPreviewDialog
    '    ppd.Document = pdoc
    '    ppd.ShowDialog()
    'End Sub

End Class
