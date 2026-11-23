Imports System.Drawing
Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmStudentTransactionsEntry

    Dim boolExtrasAdded As Boolean = False

    'Declare the pen color for use now nd in future 
    Dim myPen As System.Drawing.Pen
    Dim myBrush As System.Drawing.Brush

    Dim HeaderFont As New System.Drawing.Font("Arial", 14, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    Dim DetailsFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Dim FooterFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Dim dblExcessAmount As Double = 0
    Dim intTrip As Integer = 0
    Dim strSelectedStudentClassName As String

    Dim nz As Integer 'item line counter
    Public itm As Integer = 0
    Dim fntFinePrintFont As New Font("Arial", 6, FontStyle.Regular)
    Dim SubHeaderFont As New Font("Arial", 7, FontStyle.Bold)
    Dim fntPrintFont As New Font("Arial", 7, FontStyle.Regular)
    Dim fntFooter As New Font("Arial", 6, FontStyle.Bold)

    Dim strSponsorNames As String
    Dim strSponsorAddress1 As String
    Dim strSponsorAddress2 As String
    Dim strSponsorAddress3 As String
    Dim strSponsorAddress4 As String
    Dim strSponsorTelephone As String

    Dim dblBalanceBefore As Double = 0

    Dim dblPastPaymentAmount As Double = 0
    Dim strPastPaymentDate As String = Nothing

    Private Sub frmStudentTransactionsEntry_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F5 Then
            boolAbort = False
            SaveData()
        End If
    End Sub

    Private Sub frmStudentTransactionsEntry_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.TextExtra = strTransferType
        LoadClients()
        dpTransDate.Value = Now
        If Not String.IsNullOrEmpty(strSelectedAccountName) Then
            cboClients.SelectedText = strSelectedAccountName
            lblStudentDetails.Text = strSelectedAccount
            lblSchoolAllocatedNum.Text = strSchoolNumber
            DisplayDueBreakdown(lblStudentDetails.Text)
            lblAccBalance.Text = Format(AccountBalance(strSelectedAccount), "##0.00")
            dblBalanceBefore = CDbl(lblAccBalance.Text)
            cboClients.Enabled = False
            txtAmount.Select()
        End If
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        boolAbort = False
        If boolExtrasAdded = False Then
            ValidateAmount()
        End If
        If boolAbort = True Then Exit Sub
        SaveData()
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseErr

        If Not IsDate(dpTransDate.Value) Then
            MessageBox.Show("Please enter the correct transaction date", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dpTransDate.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboClients.Text) Then
            MessageBox.Show("Please enter the correct student number", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClients.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblStudentDetails.Text) Then
            MessageBox.Show("Please enter the correct student number", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClients.Focus()
            Exit Sub
        End If

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        If chkOverrideNo.Checked = True Then
            If Not IsNumeric(txtReceiptNumber.Text) Then
                MessageBox.Show("Please enter a valid receipt number", "Invalid Receipt Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtReceiptNumber.Focus()
            Else
                If CInt(txtReceiptNumber.Text) = 0 Then
                    MessageBox.Show("Receipt number must be greater than 0", "Invalid Receipt Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtReceiptNumber.Focus()
                End If
            End If
        Else
            If strTransferType = "Credit" Then
                txtReceiptNumber.Text = gwt_comm.GetNextDocumentNumber("CashSales")
            Else
                txtReceiptNumber.Text = gwt_comm.GetNextDocumentNumber("Invoices")
            End If
        End If

        Dim strRemarks As String = txtRemarks.Text

        For p As Integer = 0 To dGrid.Rows.Count - 1

            Dim strDescription As String = Nothing
            'Dim strReference As String = Nothing
            Dim dblValue As Double = 0


            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strDescription = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(4).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(4).Value.ToString) Then
                        dblValue = dGrid.Rows(p).Cells(4).Value.ToString
                    End If
                End If
            End If

            If strTransferType = "Credit" Then
                strSql = "INSERT INTO [SC_StudentTransactions] ([StudentId],[Description],[Reference]," _
                    & "[Debit],[Credit],[UserName],[TransactionDate],[Remarks], [ReceiptNo]) VALUES " _
                    & "('" & lblStudentDetails.Text & "', '" & strDescription & "', " _
                    & "'', 0, " & dblValue & ", " _
                    & "'" & strUserName & "', '" & Format(dpTransDate.Value, "dd-MMM-yyyy") & "', " _
                    & "'" & strRemarks & "', " & txtReceiptNumber.Text & ")"
            Else
                strSql = "INSERT INTO [SC_StudentTransactions] ([StudentId],[Description],[Reference]," _
                    & "[Debit],[Credit],[UserName],[TransactionDate],[Remarks]) VALUES " _
                    & "('" & lblStudentDetails.Text & "', '" & strDescription & "', " _
                    & "'', " & dblValue & ", 0, " _
                    & "'" & strUserName & "', '" & Format(dpTransDate.Value, "dd-MMM-yyyy") & "', " _
                    & "'" & strRemarks & "')"
            End If

            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

        Next

        'Update the control numbers
        If chkOverrideNo.Checked = False Then
            If strTransferType = "Credit" Then
                objCommand = New Data.OleDb.OleDbCommand("Update ControlNumbers SET CashSales = (CashSales + 1)", cnn)
                objCommand.ExecuteNonQuery()
            Else
                objCommand = New Data.OleDb.OleDbCommand("Update ControlNumbers SET Invoices = (Invoices + 1)", cnn)
                objCommand.ExecuteNonQuery()
            End If
        End If

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If UCase(strTransferType) = UCase("Credit") Then
            If MessageBox.Show("Do you want to print the receipt right now?", "Confirm Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'PrintReceipt()
                PrintReceiptFormat2()
            End If
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
                If Not Object.Equals(.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(4).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(4).Value.ToString) Then
                            dblTotalPaid = dblTotalPaid + CDbl(.Rows(p).Cells(4).Value.ToString)
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

    Private Sub LoadClients()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName + ' '+ OtherNames +'|'+ StudentId AS " _
            & "[Details] FROM SC_Students ORDER BY Lastname", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrData As New ArrayList

        'add the first item of the array data
        arrData.Add("--ALL--|0")
        'Add the rest from the database
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboClients.Width - 80

        'Add the items to the drop down box
        With cboClients
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth1 & ";80"
        End With
        'Get a count of the items
        Dim intItemsCount As Integer = arrData.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboClients.Items.Clear()
        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboClients
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Student Names Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboClients_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboClients.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtAmount.Select()
            Exit Sub
        End If
        lblStudentDetails.Text = Nothing
    End Sub

    Private Sub cboClients_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboClients.SelectedIndexChanged
        lblStudentDetails.Text = ""
        If Not cboClients.SelectedItem Is Nothing Then
            lblStudentDetails.Text = cboClients.SelectedItem.Col2
            lblAccBalance.Text = CStr(Format(AccountBalance(lblStudentDetails.Text), "##0.00"))
            'Assign the breakdown for the amounts
            DisplayDueBreakdown(lblStudentDetails.Text)
        Else
            lblStudentDetails.Text = Nothing
            lblAccBalance.Text = "0.00"
        End If
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtRemarks.Select()
        End If
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If Asc(e.KeyChar) = 13 Then txtRemarks.Focus()
    End Sub

    Private Sub lblStudentDetails_TextChanged(sender As Object, e As System.EventArgs) Handles lblStudentDetails.TextChanged
        lblAccBalance.Text = Format(AccountBalance(lblStudentDetails.Text), "#,##0.00")
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
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 200, 80, "REC. # : " & UCase(txtReceiptNumber.Text), DetailsFont, Brushes.Black)
        intY = intY + 25

        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 500, 80, UCase(cboClients.Text) & " CLASS : " & UCase(strSelectedStudentClassName), DetailsFont, Brushes.Black)
        intY = intY + 15
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 500, 80, "STUDENT NUMBER : " & UCase(strSchoolNumber), DetailsFont, Brushes.Black)
        intY = intY + 15

        intY = intY + 15
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
            'If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
            '    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
            '        strReference = dGrid.Rows(p).Cells(1).Value.ToString
            '    End If
            'End If
            If Not Object.Equals(dGrid.Rows(p).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(4).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(4).Value.ToString) Then
                        dblValue = dGrid.Rows(p).Cells(4).Value.ToString
                    End If
                End If
            End If
            'If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
            '    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(3).Value.ToString) Then
            '        strRemarks = dGrid.Rows(p).Cells(3).Value.ToString
            '    End If
            'End If

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

    Private Sub DisplayDueBreakdown(StudentNumber As String)
        On Error GoTo RaiseErr

        'Get the student class name
        Dim strClassName As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ClassName FROM SC_Students WHERE SC_Students.StudentId = '" & StudentNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                strClassName = objReader(0).ToString
                strSelectedStudentClassName = strClassName
            End If
        Else
            MessageBox.Show("Application failed to get the student class. Check" & vbCrLf & _
                "that the student information has been updated correctly", "Missing Student Class", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            objReader.Close()
            Exit Sub
        End If
        objReader.Close()

        If String.IsNullOrEmpty(strClassName) Then
            MessageBox.Show("Application failed to get the student class. Check" & vbCrLf & _
                "that the student information has been updated correctly", "Missing Student Class", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        dGrid.Rows.Clear()

        If UCase(strSchoolOperationType) <> "CONVENTIONAL" Then

            'In non conventiona schools there is only one line entry 
            Dim strStudentBillingCategory As String = Nothing
            Dim strFrequency As String = Nothing
            Dim strSubjectChoices As String = Nothing
            Dim dblBillamt As Double = 0

            Dim mySql As String = "SELECT BillingCategory, ConventionalOptions, SubjectOptions, BillingAmount FROM SC_Students WHERE StudentId = '" & lblStudentDetails.Text & "'"
            objCommand = New Data.OleDb.OleDbCommand(mySql, cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then
                    strStudentBillingCategory = objReader(0).ToString
                End If
                If Not IsDBNull(objReader(1).ToString) Then
                    strFrequency = objReader(1).ToString
                End If
                If Not IsDBNull(objReader(2).ToString) Then
                    strSubjectChoices = objReader(2).ToString
                End If
                If Not IsDBNull(objReader(3).ToString) Then
                    If IsNumeric(objReader(3).ToString) Then
                        dblBillamt = CDbl(objReader(3).ToString)
                    End If
                End If
            Else
                MessageBox.Show("No billing information has been set for this student", "Missing Billing Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                objReader.Close()
                Exit Sub
            End If
            objReader.Close()


            Select Case UCase(strStudentBillingCategory)
                Case Is = UCase("Conventional")
                    dblBillamt = GetConvenctionalBillingAmount(strFrequency, strClassName)
                    dGrid.Rows.Add("STUDENT " & UCase(strFrequency) & " PAYMENT", Format(dblBillamt, "##0.00"), "0.00", Format(dblBillamt, "##0.00"), "0.00")
                Case Is = UCase("Remedial")
                    Dim intNumberOfSubjectsTaken As Integer = 0
                    'Get a count of the subject the student studies
                    mySql = "SELECT Count(SubjectName) FROM SC_StudentSubjects WHERE StudentId = " & lblStudentDetails.Text & ""
                    objCommand = New Data.OleDb.OleDbCommand(mySql, cnn)
                    objReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        If Not IsDBNull(objReader(0).ToString) Then
                            If IsNumeric(objReader(0).ToString) Then
                                intNumberOfSubjectsTaken = CInt(objReader(0).ToString)
                            End If
                        End If
                    End If
                    objReader.Close()

                    If intNumberOfSubjectsTaken > intBilliableSubjectsLimit Then
                        intNumberOfSubjectsTaken = intBilliableSubjectsLimit
                    End If

                    'Get the fees from here
                    mySql = "SELECT Fees FROM SC_SubjectsPaymentsTable WHERE Level = '" & strSubjectChoices & "' AND Subjects = " & intNumberOfSubjectsTaken & ""
                    objCommand = New Data.OleDb.OleDbCommand(mySql, cnn)
                    objReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        If Not IsDBNull(objReader(0).ToString) Then
                            If IsNumeric(objReader(0).ToString) Then
                                dblBillamt = CDbl(objReader(1).ToString)
                            End If
                        End If
                    End If
                    objReader.Close()
                    dGrid.Rows.Add("FEE PAYMENT FOR " & UCase(intNumberOfSubjectsTaken) & " SUBJECTS", Format(dblBillamt, "##0.00"), "0.00", Format(dblBillamt, "##0.00"), "0.00")
                Case Else
                    dGrid.Rows.Add("STUDENT " & UCase(strStudentBillingCategory) & " COMPUTED FEES PAYMENT", Format(dblBillamt, "##0.00"), "0.00", Format(dblBillamt, "##0.00"), "0.00")
            End Select

        Else
            '************ ALWAYS DEFAULT TO CONVENTIONAL SCHOOLS **************

            'Get the class cost code
            Dim strCostCode As String = Nothing
            objCommand = New Data.OleDb.OleDbCommand("SELECT SC_Classes.CostCenter FROM SC_Classes " _
                & "WHERE SC_Classes.ClassName = '" & strClassName & "'", cnn)
            objReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then strCostCode = objReader(0).ToString
            End If
            objReader.Close()

            'Get the costings based on the class name
            objCommand = New Data.OleDb.OleDbCommand("SELECT SC_PaymentDescriptionAmts.Description, " _
                & "CAST(SC_PaymentDescriptionAmts.Amount AS DECIMAL(10,2)) AS [Amount] FROM SC_PaymentDescriptionAmts " _
                & "WHERE CostCode = '" & strCostCode & "' AND SC_PaymentDescriptionAmts.Description " _
                & "NOT IN (SELECT SC_PaymentDescriptions.Description FROM SC_PaymentDescriptions WHERE PaymentType = 'ONCE OFF')", cnn)
            objReader = objCommand.ExecuteReader
            dGrid.Rows.Clear()
            While objReader.Read
                dGrid.Rows.Add(objReader(0), objReader(1), "0.00", "0.00")
            End While
            objReader.Close()

            'Populate the amount already paid to date for the term

            'Compute the due
            For p As Integer = 0 To dGrid.Rows.Count - 1
                Dim dblAmount As Double = 0
                Dim dblPaid As Double = 0
                If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                            dblAmount = CDbl(dGrid.Rows(p).Cells(1).Value.ToString)
                        End If
                    End If
                End If
                If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                        If IsNumeric(dGrid.Rows(p).Cells(2).Value.ToString) Then
                            dblPaid = CDbl(dGrid.Rows(p).Cells(2).Value.ToString)
                        End If
                    End If
                End If
                Dim dblDue As Double = dblAmount - dblPaid
                dGrid.Rows(p).Cells(3).Value = Format(dblDue, "##0.00")
            Next

            If dGrid.Rows.Count = 0 Then
                txtAmount.Enabled = False
                btnOk.Enabled = False
                txtRemarks.Enabled = False
            Else
                txtAmount.Enabled = True
                btnOk.Enabled = True
                txtRemarks.Enabled = True
            End If

        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On student dues breakdown information load"
        ShowErrorMessage()
    End Sub

    Private Sub DistributePayment(AmountPaid As Double)
        On Error GoTo RaiseErr
        Dim dblAvailableAmount As Double = AmountPaid

        If dGrid.RowCount <= 1 Then

            Dim dblAllocated As Double = 0
            dGrid.Rows(0).Cells(4).Value = txtAmount.Text
            For p As Integer = 0 To dGrid.Rows.Count - 1
                If Not Object.Equals(dGrid.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(4).Value.ToString) Then
                        If IsNumeric(dGrid.Rows(p).Cells(4).Value.ToString) Then
                            dblAllocated = dblAllocated + CDbl(dGrid.Rows(p).Cells(4).Value.ToString)
                        End If
                    End If
                End If
            Next
            dblExcessAmount = CDbl(txtAmount.Text) - dblAllocated
            If dblExcessAmount <= 0 Then
                ComputeTotal()
            End If

        Else
            For p As Integer = 0 To dGrid.Rows.Count - 1
                If intTrip = 0 Then dGrid.Rows(p).Cells(4).Value = "0.00"
                Dim dblCurrentValue As Double = 0
                If Not Object.Equals(dGrid.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(4).Value.ToString) Then
                        If IsNumeric(dGrid.Rows(p).Cells(4).Value.ToString) Then
                            dblCurrentValue = CDbl(dGrid.Rows(p).Cells(4).Value.ToString)
                        End If
                    End If
                End If
                If dblAvailableAmount > 0 Then
                    Dim dblDue As Double = 0
                    If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
                        If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(3).Value.ToString) Then
                            If IsNumeric(dGrid.Rows(p).Cells(3).Value.ToString) Then
                                dblDue = CDbl(dGrid.Rows(p).Cells(3).Value.ToString)
                            End If
                        End If
                    End If
                    If dblDue > 0 Then
                        Dim dblBalance As Double = dblAvailableAmount - dblDue
                        If dblBalance < 0 Then
                            dGrid.Rows(p).Cells(4).Value = Format((dblAvailableAmount), "##0.00")
                            dblAvailableAmount = 0
                        Else
                            dGrid.Rows(p).Cells(4).Value = Format((dblDue + dblCurrentValue), "##0.00")
                            dblAvailableAmount = dblBalance '
                        End If
                    End If
                End If
            Next

            'Add all the totals
            'dblExcessAmount
            Dim dblAllocated As Double = 0
            For p As Integer = 0 To dGrid.Rows.Count - 1
                If Not Object.Equals(dGrid.Rows(p).Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(4).Value.ToString) Then
                        If IsNumeric(dGrid.Rows(p).Cells(4).Value.ToString) Then
                            dblAllocated = dblAllocated + CDbl(dGrid.Rows(p).Cells(4).Value.ToString)
                        End If
                    End If
                End If
            Next
            dblExcessAmount = CDbl(txtAmount.Text) - dblAllocated
            If dblExcessAmount <= 0 Then
                ComputeTotal()
            End If
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On student dues breakdown allocation"
        ShowErrorMessage()
    End Sub

    'Private Sub txtAmount_LostFocus(sender As Object, e As System.EventArgs) Handles txtAmount.LostFocus
    '    ValidateAmount()
    'End Sub

    Private Sub txtAmount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAmount.Validating
        ValidateAmount()
    End Sub

    Private Sub ValidateAmount()
        dblExcessAmount = 0
        intTrip = 0
        If IsNumeric(txtAmount.Text) Then
            'Compute the amount expected
            Dim dblExpectedAmount As Double = 0
            dblExcessAmount = CDbl(txtAmount.Text)
            For p As Integer = 0 To dGrid.Rows.Count - 1
                If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                            dblExpectedAmount = dblExpectedAmount + CDbl(dGrid.Rows(p).Cells(1).Value.ToString)
                        End If
                    End If
                End If
            Next
            If Not IsNumeric(lblAccBalance.Text) Then lblAccBalance.Text = "0.00"

            If CDbl(txtAmount.Text) > (dblExpectedAmount + CDbl(lblAccBalance.Text)) Then
                If MessageBox.Show("The amount paid is in excess of the expected." & vbCrLf & _
                    "Do you want to continue with this transaction and " & vbCrLf & _
                    "distributions be based on set allocation?", "Excess Payment", _
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    While dblExcessAmount > 0
                        DistributePayment(dblExcessAmount)
                        intTrip = intTrip + 1
                    End While
                Else
                    boolAbort = True
                    For j As Integer = 0 To dGrid.Rows.Count - 1
                        dGrid.Rows(j).Cells(4).Value = "0.00"
                        txtAmount.Text = "0.00"
                        txtAmount.Select()
                    Next
                    Exit Sub
                End If
            Else
                DistributePayment(CDbl(txtAmount.Text))
            End If
        End If
    End Sub

    Private Sub chkOverrideNo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOverrideNo.CheckedChanged
        If chkOverrideNo.Checked = True Then
            txtReceiptNumber.Clear()
            txtReceiptNumber.Enabled = True
        Else
            txtReceiptNumber.Enabled = False
            'Get the next document number
            txtReceiptNumber.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))
        End If
    End Sub

    Private Function ReceiptUsed(ReceiptNumber As Integer) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT COUNT(ReceiptNo) " _
            & "FROM SC_StudentTransactions WHERE ReceiptNo = " & ReceiptNumber & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                If CInt(objReader(0).ToString) > 0 Then
                    boolReturn = True
                End If
            End If
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On receipt number validation"
        ShowErrorMessage()
    End Function

    Private Sub txtReceiptNumber_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtReceiptNumber.Validating
        If Not String.IsNullOrEmpty(txtReceiptNumber.Text) Then
            If IsNumeric(txtReceiptNumber.Text) Then
                If ReceiptUsed(CInt(txtReceiptNumber.Text)) = True Then
                    MessageBox.Show("The receipt number entered has already been used", "Used Receipt Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtReceiptNumber.Clear()
                End If
            Else
                MessageBox.Show("Please enter a valid receipt number", "Invalid Receipt Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtReceiptNumber.Clear()
            End If
        End If
    End Sub

    Private Sub pdReceipt_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles pdReceipt.PrintPage
        'Resest
        On Error GoTo RaiseErr
        
        HeaderFont = New Font("Arial", 7, FontStyle.Regular)
        Dim intStatsCount As Integer = 0
        Dim eLineCnt As Integer, dLineCnt As Integer, sLineCnt As Integer
        Dim intX1, intX2, intY1, intY2 As Integer
        intLeftMargin = 50 : intRightMargin = 100 : intTopMargin = 40 : intBottomMargin = 40
        intX1 = intLeftMargin ' e.PageBounds.Left + 50
        intX2 = e.PageBounds.Right - intRightMargin
        intY1 = intTopMargin ' e.PageBounds.Top + 100
        intY2 = 500 'e.PageBounds.Bottom - intBottomMargin
        nz = 0

        Dim str As String
        Dim strAmt As String
        Dim pencurrent As New Pen(Color.Black, 3)
        Dim reccurrent As Rectangle
        Dim graCurrent As Graphics = e.Graphics
        'Draw the main border
        Dim sbCurrent As SolidBrush 'penCurrent As Pen
        reccurrent = New Rectangle(intX1, intY1, (intX2 - 43), intY2)
        If boolDrawBorders = True Then e.Graphics.DrawRectangle(Pens.Navy, reccurrent)
        Dim intRectangleWidth As Integer = reccurrent.Width

        'Print the company logo as a watermark
        'intX1 + 405, (intTopMargin + 10)
        If Not String.IsNullOrEmpty(strCompanyLogoPath) Then
            If System.IO.File.Exists(strCompanyLogoPath) Then
                Dim picPrint As New PictureBox
                picPrint.SizeMode = PictureBoxSizeMode.AutoSize
                picPrint.Load(strCompanyLogoPath)
                Dim R As New Rectangle(intLogoXposition, intLogoYposition, picPrint.Width, picPrint.Height)
                'Dim R As New Rectangle(20, 20, picPrint.Width, picPrint.Height)
                e.Graphics.DrawImage(picPrint.Image, R)
            End If
        End If

        '*** Start Printing and drawing the prefixed item
        '*** the value start position of x = intX1 and that of y = intY1

        'Print the pay advice header
        Call gwt_comm.DrawStringInBoxLeft(e, intX1, intY1 - 30, intX1 + 200, intY1 - 30, "PAYMENT ADVICE", HeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 405, intY1 - 30, intX1 + 405, intY1 - 30, "DOCUMENT NO: " & Format(CInt(txtReceiptNumber.Text), "000000"), HeaderFont, Brushes.Black)
        e.Graphics.DrawString(UCase(Format(Now, "dd-MMM-yyyy")), HeaderFont, System.Drawing.Brushes.Black, intX1 + 580, intY1 - 30)

        '********************** PRINT STUDENT DETAILS FROM HEE ******************************************************************
        intY1 = (intTopMargin + 10)

        Dim strStudentNames As String = cboClients.Text
        gwt_comm.DrawStringInBoxLeft(e, intX1, intY1, 200, intY1, UCase(strStudentNames), HeaderFont, Brushes.Black)
        gwt_comm.DrawStringInBoxLeft(e, intX1 + 205, intY1, 200, intY1, UCase(lblSchoolAllocatedNum.Text & Space(5) & _
                                        strSelectedStudentClassName), HeaderFont, Brushes.Black)

        intY1 = (intTopMargin + 10) + 15

        If Not String.IsNullOrEmpty(strSponsorAddress1) Then
            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 1, intY1, 120, 250, UCase(strSponsorAddress1), HeaderFont, Brushes.Black)
            intY1 = intY1 + 15
        End If
        If Not String.IsNullOrEmpty(strSponsorAddress2) Then
            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 1, intY1, 120, 250, UCase(strSponsorAddress2), HeaderFont, Brushes.Black)
            intY1 = intY1 + 15
        End If
        If Not String.IsNullOrEmpty(strSponsorAddress3) Then
            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 1, intY1, 120, 250, UCase(strSponsorAddress3), HeaderFont, Brushes.Black)
            intY1 = intY1 + 15
        End If
        If Not String.IsNullOrEmpty(strSponsorAddress4) Then
            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 1, intY1, 120, 250, UCase(strSponsorAddress4), HeaderFont, Brushes.Black)
            intY1 = intY1 + 15
        End If
        If Not String.IsNullOrEmpty(strSponsorTelephone) Then
            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 1, intY1, 120, 250, UCase(strSponsorTelephone), HeaderFont, Brushes.Black)
            intY1 = intY1 + 15
        End If


        '********************** PRINT COMPANY DETAILS FROM HERE *****************************************************************
        'Print the company name and the pay date the same font as that for document no
        e.Graphics.DrawString(UCase(strCompanyName), HeaderFont, System.Drawing.Brushes.Black, intX1 + 405, (intTopMargin + 10))

        intY1 = (intTopMargin + 10) + 15

        If Not String.IsNullOrEmpty(strCompanyAddress1) Then
            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 405, intY1, 120, 250, UCase(strCompanyAddress1), HeaderFont, Brushes.Black)
            intY1 = intY1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyAddress2) Then
            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 405, intY1, 120, 250, UCase(strCompanyAddress2), HeaderFont, Brushes.Black)
            intY1 = intY1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyAddress3) Then
            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 405, intY1, 120, 250, UCase(strCompanyAddress3), HeaderFont, Brushes.Black)
            intY1 = intY1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyAddress4) Then
            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 405, intY1, 120, 250, UCase(strCompanyAddress4), HeaderFont, Brushes.Black)
            intY1 = intY1 + 15
        End If
        If Not String.IsNullOrEmpty(strCompanyTelephone) Then
            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 405, intY1, 120, 250, UCase(strCompanyTelephone), HeaderFont, Brushes.Black)
            intY1 = intY1 + 15
        End If

        intY1 = intY1 + 15

        Dim intYpredetails As Integer = intY1
        e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)
        'Print the headers
        intY1 = intY1 + 15
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 1, intY1, 120, 250, "DESCRIPTION", HeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxCenter(e, intX1 + 500, intY1, 120, 250, "AMOUNT", HeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxCenter(e, intX1 + 600, intY1, 120, 250, "AMOUNT", HeaderFont, Brushes.Black)
        intY1 = intY1 + 20
        e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)

        intY1 = intY1 + 20
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 1, intY1, 350, 250, "BALANCE BEFORE PAYMENT", HeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, intX1 + 475, intY1, 120, 250, Format(dblBalanceBefore, "##0.00"), HeaderFont, Brushes.Black)
        'Call gwt_comm.DrawStringInBoxRight(e, intX1 + 575, intY1, 120, 250, "0.00", HeaderFont, Brushes.Black)

        'intY1 = intY1 + 15
        'Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 1, intY1, 350, 250, "CURRENT PAYMENTS ", HeaderFont, Brushes.Black)
        ''Call gwt_comm.DrawStringInBoxRight(e, intX1 + 475, intY1, 120, 250, "0.00", HeaderFont, Brushes.Black)

        intY1 = intY1 + 15
        For g As Integer = 0 To dGrid.RowCount - 1
            If Not Object.Equals(dGrid.Rows(g).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(g).Cells(4).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(g).Cells(4).Value.ToString) Then
                        If CDbl(dGrid.Rows(g).Cells(4).Value.ToString) <> 0 Then
                            Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 1, intY1, 350, 250, UCase(dGrid.Rows(g).Cells(0).Value.ToString), HeaderFont, Brushes.Black)
                            Call gwt_comm.DrawStringInBoxRight(e, intX1 + 575, intY1, 120, 250, Format(CDbl(dGrid.Rows(g).Cells(4).Value.ToString), "##0.00"), HeaderFont, Brushes.Black)
                            intY1 = intY1 + 15
                        End If
                    End If
                End If
            End If
        Next

        'intY1 = intY1 + 15
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 1, intY1, 350, 250, "BALANCE AFTER PAYMENT", HeaderFont, Brushes.Black)
        'Call gwt_comm.DrawStringInBoxRight(e, intX1 + 475, intY1, 120, 250, "0.00", HeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, intX1 + 575, intY1, 120, 250, Format((dblBalanceBefore - CDbl(txtAmount.Text)), "##0.00"), HeaderFont, Brushes.Black)

        intY1 = intY1 + 20
        e.Graphics.DrawLine(Pens.Navy, intX1, intY1, reccurrent.Right, intY1)

        'Draw the amounts and descriptions seperator lines
        e.Graphics.DrawLine(Pens.Navy, intX1 + 500, intYpredetails, intX1 + 500, intY1)
        e.Graphics.DrawLine(Pens.Navy, intX1 + 600, intYpredetails, intX1 + 600, intY1)

        intY1 = intY1 + 20
        Dim intYpast As Integer = intY1
        e.Graphics.DrawLine(Pens.Navy, intX1, intY1, 300, intY1)
        intY1 = intY1 + 5
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 3, intY1, 250, 250, UCase("Past Immediate Payment"), HeaderFont, Brushes.Black)
        intY1 = intY1 + 15
        Dim intYpast2 As Integer = intY1
        e.Graphics.DrawLine(Pens.Navy, intX1, intY1, 300, intY1)
        intY1 = intY1 + 5
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 3, intY1, 120, 250, UCase("DATE"), HeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 175, intY1, 120, 200, UCase(strPastPaymentDate), HeaderFont, Brushes.Black)
        intY1 = intY1 + 15
        e.Graphics.DrawLine(Pens.Navy, intX1, intY1, 300, intY1)
        intY1 = intY1 + 5
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 3, intY1, 250, 250, UCase("AMOUNT"), HeaderFont, Brushes.Black)
        Call gwt_comm.DrawStringInBoxRight(e, intX1 + 137, intY1, 100, 250, Format(dblPastPaymentAmount, "##0.00"), HeaderFont, Brushes.Black)
        intY1 = intY1 + 15
        e.Graphics.DrawLine(Pens.Navy, intX1, intY1, 300, intY1)

        'Draw the verticals for the past information
        e.Graphics.DrawLine(Pens.Navy, 300, intYpast, 300, intY1)
        e.Graphics.DrawLine(Pens.Navy, 200, intYpast2, 200, intY1)


        'PRINT SPECIAL NOTES SUCH AS NEXT OPENING DAY, INCREASES ETC
        Dim intRightEdge As Integer = reccurrent.Width + intX1
        Dim intStartPosition As Integer = intRightEdge - 300

        intY1 = intY1 + 20
        Dim intYbeginspecialnotes As Integer = intY1
        e.Graphics.DrawLine(Pens.Navy, intStartPosition, intY1, (intStartPosition + 300), intY1)
        intY1 = intY1 + 5
        Call gwt_comm.DrawStringInBoxLeft(e, intStartPosition + 3, intY1, 120, 250, UCase("SPECIAL NOTES"), HeaderFont, Brushes.Black)
        intY1 = intY1 + 15
        e.Graphics.DrawLine(Pens.Navy, intStartPosition, intY1, (intStartPosition + 300), intY1)
        intY1 = intY1 + 5
        Call gwt_comm.DrawStringInBoxLeft(e, intStartPosition + 3, intY1, 300, 100, UCase(strReceiptSpecialNotes), HeaderFont, Brushes.Black)
        intY1 = intY1 + 100
        e.Graphics.DrawLine(Pens.Navy, intStartPosition, intY1, (intStartPosition + 300), intY1)
        ' Draw the drop down line to make a box
        e.Graphics.DrawLine(Pens.Navy, intStartPosition, intYbeginspecialnotes, intStartPosition, intY1)

        intY1 = intY1 + 50
        Call gwt_comm.DrawStringInBoxLeft(e, intX1 + 3, intY1, 600, 250, "RECEIVED BY : " & UCase(strPublicActiveFullUserName) & " ON THE " & UCase(Now), HeaderFont, Brushes.Black)
        '-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*

        If itm >= (intPayslipProcessingCount - 1) Then
            e.HasMorePages = False
            itm = 0
        Else
            e.HasMorePages = True
            itm = itm + 1
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Scholastica Receipt Print"
        ShowErrorMessage()
    End Sub

    Private Sub PrintReceiptFormat2()
        boolAbort = False
        Dim prnt As New frmPrinterSetup
        prnt.ShowDialog()
        If boolAbort = True Then Exit Sub
        GetStudentSponsorAndAddress(lblStudentDetails.Text)
        If boolAbort = True Then Exit Sub
        Dim arrPastData As New ArrayList
        arrPastData = PastImmediateTransactions(lblStudentDetails.Text)
        If boolAbort = True Then Exit Sub

        If Not String.IsNullOrEmpty(arrPastData.Item(0)) Then
            strPastPaymentDate = arrPastData.Item(0)
        End If
        If Not String.IsNullOrEmpty(arrPastData.Item(1)) Then
            If IsNumeric(arrPastData.Item(1)) Then
                dblPastPaymentAmount = CDbl(arrPastData.Item(1))
            End If
        End If

        boolDrawBorders = True
        pdReceipt.PrinterSettings.PrinterName = strSessionPrinter

        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = pdReceipt
        documentPreview.ShowDialog()
    End Sub

    Private Sub GetStudentSponsorAndAddress(ByVal StudentNumber As String)
        On Error GoTo RaiseErr

        strSponsorNames = Nothing
        strSponsorAddress1 = Nothing
        strSponsorAddress2 = Nothing
        strSponsorAddress3 = Nothing
        strSponsorAddress4 = Nothing
        strSponsorTelephone = Nothing

        Dim strSql As String = "SELECT GivenNames, Address1, Address2, Address3, Address4, Telephone " _
                                & "FROM SC_Guardians WHERE StudentId = '" & StudentNumber & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strSponsorNames = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then strSponsorAddress1 = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then strSponsorAddress2 = objReader(2).ToString
            If Not IsDBNull(objReader(3).ToString) Then strSponsorAddress3 = objReader(3).ToString
            If Not IsDBNull(objReader(4).ToString) Then strSponsorAddress4 = objReader(4).ToString
            If Not IsDBNull(objReader(5).ToString) Then strSponsorTelephone = objReader(5).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Scholastica Sponsor Details Fetch"
        ShowErrorMessage()
    End Sub


    Private Sub btnExtraPayments_Click(sender As System.Object, e As System.EventArgs) Handles btnExtraPayments.Click
        boolAbort = False
        Dim frm As New frmExtraPayments
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        dGrid.Rows.Add(UCase(strExtraPaymentDescription), Format(dblExtraAmount, "##0.00"), "0.00", _
                       Format(dblExtraAmount, "##0.00"), Format(dblExtraAmount, "##0.00"))
        lblTotalPaid.Text = CDbl(lblTotalPaid.Text) + dblExtraAmount
        If IsNumeric(txtAmount.Text) Then
            txtAmount.Text = Format((CDbl(txtAmount.Text) + dblExtraAmount), "##0.00")
        Else
            txtAmount.Text = Format(dblExtraAmount, "##0.00")
        End If
        boolExtrasAdded = True
    End Sub

    Private Sub txtAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAmount.TextChanged

    End Sub
End Class
