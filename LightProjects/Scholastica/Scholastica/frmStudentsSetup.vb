Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmStudentsSetup

    Dim boolFormLoading As Boolean

    Dim myPen As System.Drawing.Pen
    Dim myBrush As System.Drawing.Brush

    Dim HeaderFont As New System.Drawing.Font("Arial", 14, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    Dim DetailsFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Dim FooterFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Dim intNewStudentReceiptNumber As Integer = 0
    Dim boolProcessPayments As Boolean = False

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(txtStudentNumberKey.Text) Then
            MessageBox.Show("Please enter the student number", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtStudentNumberKey.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtLastName.Text) Then
            MessageBox.Show("Please enter the last name", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtLastName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtFirstName.Text) Then
            MessageBox.Show("Please enter the first name", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFirstName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboClass.Text) Then
            MessageBox.Show("Please enter the class name", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboClass.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter Address", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboGender.Text) Then
            MessageBox.Show("Please enter student gender", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboGender.Focus()
            Exit Sub
        End If
        boolAbort = False
        If boolEditStatus = False Then
            If MessageBox.Show("Do you want to process the new student payments now?", "Process New Student Payments", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                boolProcessPayments = True
                strNewStudentClassName = cboClass.Text
                Dim frm As New frmNewStudentOnceOffPayment
                frm.ShowDialog()
                If boolAbort = True Then
                    MessageBox.Show("This process has been terminated. Record will not be saved into the system", "Process Terminated", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            Else
                boolProcessPayments = False
            End If
        End If

        If boolEditStatus = False Then
            If UCase(strStudentNumberAllocationMethod) <> "SYSTEM" Then
                If UCase(strStudentNumberAllocationMethod) = "USER" Then
                    If String.IsNullOrEmpty(txtStudentNumber.Text) Then
                        MessageBox.Show("Please type in a valid student number", "Invalid Student Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txtStudentNumber.Focus()
                        Exit Sub
                    End If
                    If CheckStudentNumberExistence(txtStudentNumber.Text) = True Then
                        MessageBox.Show("A record with this student number already exists. Enter a new one", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        txtStudentNumber.Focus()
                        Exit Sub
                    End If
                Else
                    txtStudentNumber.Text = UserDefinedStudentNumber(lblClassShortName.Text)
                End If
            Else
                txtStudentNumber.Text = txtStudentNumberKey.Text
            End If
        End If

        If UCase(strSchoolOperationType) <> "CONVENTIONAL" Then

            If String.IsNullOrEmpty(cboCategory.Text) Then
                MessageBox.Show("Please select the student billing category from the given list", "Invalid Billing Category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TabControl1.SelectedIndex = 2
                cboCategory.Focus()
                Exit Sub
            End If

            If cboSubjectBasedOptions.Enabled = True Then
                If String.IsNullOrEmpty(cboSubjectBasedOptions.Text) Then
                    MessageBox.Show("Please select the subject payment options from the given list", "Invalid Subject Payment Options", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TabControl1.SelectedIndex = 2
                    cboSubjectBasedOptions.Focus()
                    Exit Sub
                End If
            End If

            If cboConventionalOptions.Enabled = True Then
                If String.IsNullOrEmpty(cboConventionalOptions.Text) Then
                    MessageBox.Show("Please select the payment frequency from the given list", "Invalid Payment Frequency", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TabControl1.SelectedIndex = 2
                    cboConventionalOptions.Focus()
                    Exit Sub
                End If
            End If

        End If
        SaveData()
        boolModified = True

    End Sub

    Private Function CheckStudentNumberExistence(ByVal StudentNumber As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SchoolAllocatedNumber FROM SC_Students " _
            & "WHERE SchoolAllocatedNumber = '" & StudentNumber & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            boolReturn = True
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On student number duplicate record test"
        ShowErrorMessage()
    End Function

    Private Sub SaveData()
        On Error GoTo RaiseErr
        Dim strSql As String

        Dim dblDistance As Double = 0
        Dim dblTransportFee As Double = 0

        Dim intCurrentMonth As Integer = DatePart(DateInterval.Month, dpTakenDate.Value)
        Dim dpCessionDate As Date = DateAdd(DateInterval.Month, CDbl(intLearnershipPeriod - 1), dpTakenDate.Value)
        Dim LastOfMonth As DateTime = dpCessionDate.Date.AddDays(-(dpCessionDate.Day - 1)).AddMonths(1).AddDays(-1)

        Dim strBillingCategory As String = Nothing
        Dim strSubjectOptions As String = Nothing
        Dim strConventionalOptions As String = Nothing
        Dim dblBillingAmount As Double = 0

        If UCase(strSchoolOperationType) <> "CONVENTIONAL" Then
            strBillingCategory = cboCategory.Text
            If cboSubjectBasedOptions.Enabled = True Then
                strSubjectOptions = cboSubjectBasedOptions.Text
            End If
            If cboConventionalOptions.Enabled = True Then
                strConventionalOptions = cboConventionalOptions.Text
            End If
            If IsNumeric(txtBillingAmount.Text) Then
                dblBillingAmount = CDbl(txtBillingAmount.Text)
            End If
        End If

        If String.IsNullOrEmpty(cboType.Text) Then cboType.Text = "Day"

        If boolEditStatus = False Then
            strSql = "INSERT INTO [SC_Students]([StudentId],[DateOfBirth],[Address1],[Address2]," _
                & "[Address3],[Address4],[ContactTelephone],[EntryDate],[ClassName]," _
                & "[Remarks],[LastName],[FirstName],[OtherNames], [PickupPoint], [Distance], [TransportFee], " _
                & "[Gender], [Status], [BirthEntryNumber], [SchoolAllocatedNumber], " _
                & "[BillingCategory], [SubjectOptions], [ConventionalOptions], [BillingAmount], [StudentType]) " _
                & "VALUES ('" & txtStudentNumberKey.Text & "', " _
                & "'" & Format(dpBirthDate.Value, "dd-MMM-yyyy") & "', '" & txtAddress1.Text & "', " _
                & "'" & txtAddress2.Text & "', '" & txtAddress3.Text & "', '" & txtAddress4.Text & "', " _
                & "'" & txtTelephone.Text & "', '" & Format(dpTakenDate.Value, "dd-MMM-yyyy") & "', " _
                & "'" & cboClass.Text & "', " _
                & "'" & txtRemarks.Text & "', '" & txtLastName.Text & "', '" & txtFirstName.Text & "', " _
                & "'" & txtOtherNames.Text & "', '', " & dblDistance & ", " & dblTransportFee & ", " _
                & "'" & cboGender.Text & "', 'ACTIVE', '" & txtBirthEntryNumber.Text & "', '" & txtStudentNumber.Text & "', " _
                & "'" & strBillingCategory & "', '" & strSubjectOptions & "', " _
                & "'" & strConventionalOptions & "', " & dblBillingAmount & ", '" & cboType.Text & "')"

        Else
            strSql = "UPDATE [SC_Students] SET [DateOfBirth] = '" & Format(dpBirthDate.Value, "dd-MMM-yyyy") & "', " _
                & "[Address1] = '" & txtAddress1.Text & "', [Address2] = '" & txtAddress2.Text & "', " _
                & "[Address3] = '" & txtAddress3.Text & "', [Address4] = '" & txtAddress4.Text & "', " _
                & "[ContactTelephone] = '" & txtTelephone.Text & "', [EntryDate] = '" & Format(dpTakenDate.Value, "dd-MMM-yyyy") & "', " _
                & "[ClassName] = '" & cboClass.Text & "', [Remarks] = '" & txtRemarks.Text & "', [LastName] = '" & txtLastName.Text & "', " _
                & "[FirstName] = '" & txtFirstName.Text & "', [OtherNames] = '" & txtOtherNames.Text & "', " _
                & "[PickupPoint] = '', [Distance] = " & dblDistance & ", " _
                & "[TransportFee] = " & dblTransportFee & ", [Gender] = '" & cboGender.Text & "', " _
                & "BirthEntryNumber = '" & txtBirthEntryNumber.Text & "', [SchoolAllocatedNumber] = '" & txtStudentNumber.Text & "', " _
                & "[BillingCategory] = '" & strBillingCategory & "', [SubjectOptions] = '" & strSubjectOptions & "', " _
                & "[ConventionalOptions] = '" & strConventionalOptions & "', " _
                & "[StudentType] = '" & cboType.Text & "', [BillingAmount] = " & dblBillingAmount & " " _
                & "WHERE [StudentId] = '" & txtStudentNumberKey.Text & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        boolAbort = False
        SaveStudentSubjects()
        If boolAbort = True Then Exit Sub
        SaveGuardians()
        If boolAbort = True Then Exit Sub

        If boolEditStatus = False Then
            If boolProcessPayments = True Then
                'Save payments and Print the invoice
                ProcessPayments()
                Cursor = Cursors.Default
                If MessageBox.Show("Do you want to print the receipt right now?", "Confirm Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    PrintReceipt()
                End If
            End If
        End If

        MessageBox.Show("Process completed auccessfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Students Setup"
        ShowErrorMessage()
    End Sub

    Private Sub ProcessPayments()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        'Get the next receipt number 
        If boolIncreamentCounter = True Then
            intNewStudentReceiptNumber = gwt_comm.GetNextDocumentNumber("CashSales")
        Else
            intNewStudentReceiptNumber = intOverideReceiptNumber
        End If

        For p As Integer = 0 To arrNewStudentPaymentDetails.Count - 1
            Dim strSplitData() As String = Split(arrNewStudentPaymentDetails.Item(p), "|")
            strSql = "INSERT INTO [SC_StudentTransactions] ([StudentId],[Description],[Reference]," _
                & "[Debit],[Credit],[UserName],[TransactionDate],[Remarks], [ReceiptNo]) VALUES " _
                & "('" & txtStudentNumberKey.Text & "', '" & strSplitData(0) & "', " _
                & "'', 0, " & CDbl(strSplitData(1)) & ", " _
                & "'" & strUserName & "', '" & Format(dtSetDate, "dd-MMM-yyyy") & "', " _
                & "'" & strNewStudentPaymentRemarks & "', " & intNewStudentReceiptNumber & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Next

        'Update the control numbers accordingly
        If boolIncreamentCounter = True Then
            objCommand = New Data.OleDb.OleDbCommand("Update ControlNumbers SET CashSales = (CashSales + 1)", cnn)
            objCommand.ExecuteNonQuery()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Students Payments Update"
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

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM [SC_Students] WHERE StudentId = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("StudentId").ToString) Then txtStudentNumberKey.Text = objReader("StudentId").ToString
            If IsDate(objReader("DateOfBirth").ToString) Then dpBirthDate.Value = CDate(objReader("DateOfBirth").ToString)
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("ContactTelephone").ToString) Then txtTelephone.Text = objReader("ContactTelephone").ToString
            If IsDate(objReader("EntryDate").ToString) Then dpTakenDate.Value = CDate(objReader("EntryDate").ToString)
            'If Not IsDBNull(objReader("Grade").ToString) Then txtGrade.Text = objReader("Grade").ToString
            If Not IsDBNull(objReader("ClassName").ToString) Then cboClass.Text = objReader("ClassName").ToString
            'If Not IsDBNull(objReader("ClassTeacher").ToString) Then cboHeadTeacher.Text = objReader("ClassTeacher").ToString
            If Not IsDBNull(objReader("Remarks").ToString) Then txtRemarks.Text = objReader("Remarks").ToString
            If Not IsDBNull(objReader("LastName").ToString) Then txtLastName.Text = objReader("LastName").ToString
            If Not IsDBNull(objReader("FirstName").ToString) Then txtFirstName.Text = objReader("FirstName").ToString
            If Not IsDBNull(objReader("StudentType").ToString) Then cboType.Text = objReader("StudentType").ToString
            Me.TextExtra = txtLastName.Text & " " & txtFirstName.Text

            If Not IsDBNull(objReader("OtherNames").ToString) Then txtOtherNames.Text = objReader("OtherNames").ToString
            If Not IsDBNull(objReader("SchoolAllocatedNumber").ToString) Then txtStudentNumber.Text = objReader("SchoolAllocatedNumber").ToString
            'If IsNumeric(objReader("Distance").ToString) Then txtDistance.Text = CDbl(objReader("Distance").ToString)
            'If IsNumeric(objReader("TransportFee").ToString) Then txtTransportCost.Text = CDbl(objReader("TransportFee").ToString)
            'If IsNumeric(txtDistance.Text) Then
            '    'txtIdealCost.Text = Format(ComputeIdealPrice(CDbl(txtDistance.Text), txtPickupPoint.Text), "#,##0.00")
            'End If
            If Not IsDBNull(objReader("Gender").ToString) Then cboGender.Text = objReader("Gender").ToString
            If Not IsDBNull(objReader("BirthEntryNumber").ToString) Then txtBirthEntryNumber.Text = objReader("BirthEntryNumber").ToString

            '[BillingCategory], [SubjectOptions], [ConventionalOptions], [BillingAmount]
            If Not IsDBNull(objReader("BillingCategory").ToString) Then cboCategory.Text = objReader("BillingCategory").ToString

            If Not IsDBNull(objReader("SubjectOptions").ToString) Then
                If Not String.IsNullOrEmpty(objReader("SubjectOptions").ToString) Then
                    cboSubjectBasedOptions.Text = objReader("SubjectOptions").ToString
                End If
            End If

            If Not IsDBNull(objReader("ConventionalOptions").ToString) Then
                If Not String.IsNullOrEmpty(objReader("ConventionalOptions").ToString) Then
                    cboConventionalOptions.Text = objReader("ConventionalOptions").ToString
                End If
            End If
            If IsNumeric(objReader("BillingAmount").ToString) Then txtBillingAmount.Text = Format(CDbl(objReader("BillingAmount").ToString), "##0.00")

        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Students Setup"
        ShowErrorMessage()
    End Sub

    Private Sub LoadClasses()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT (ClassName) FROM SC_Classes " _
            & "ORDER BY (ClassName)", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboClass.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Class Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmStudentsSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        If UCase(strSchoolOperationType) = "CONVENTIONAL" Then
            cboCategory.Enabled = False
        End If
        LoadClasses()
        LoadSystemSubjects()
        LoadSubjectTable()
        If boolEditStatus = True Then
            LoadData()
            LoadFinancials()
            LoadGrades()
            LoadGuardians()
            LoadSubjects()
            txtStudentNumberKey.Enabled = False
        Else
            txtStudentNumberKey.Text = NewStudentNumber()
            txtStudentNumberKey.Enabled = False
        End If
        If UCase(strStudentNumberAllocationMethod) = "USER" Then txtStudentNumber.Enabled = True Else txtStudentNumber.Enabled = False
        If boolEditStatus = True Then
            txtStudentNumber.Enabled = False
        End If
        boolFormLoading = False
    End Sub

    Private Sub LoadSystemSubjects()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT Subject FROM SC_Subjects ORDER BY Subject"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboAddSubject.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboAddSubject.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Subjects Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadSubjects()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM SC_StudentSubjects WHERE StudentId = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridSubjects.Rows.Clear()
        While objReader.Read
            dGridSubjects.Rows.Add(objReader("SubjectName"), objReader("TransactionId"))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Subjects Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadGrades()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM SC_StudentGrades WHERE StudentId = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridSubjects.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader("SubjectName"), objReader("Grade"), _
                objReader("Semister"), objReader("GradeYear"), _
                objReader("Remarks"), objReader("RemarksAuthor"), objReader("TransactionId"))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Grades Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadFinancials()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT UPPER(REPLACE(CONVERT(CHAR(11), TransactionDate, 106), ' ', '-')) as [Date], " _
            & "Description, Reference, CAST(Debit AS DECIMAL (10,2)) AS [Debit], CAST(Credit AS DECIMAL (10,2)) AS [Credit], " _
            & "Remarks, TransactionId FROM SC_StudentTransactions WHERE StudentId = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), _
                objReader(2), objReader(3), _
                objReader(4), objReader(5), objReader(6))
        End While
        objReader.Close()
        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Financials Load"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr
        Dim dblBalance As Double = 0
        Dim dblDebitTotal As Double = 0
        Dim dblCreditTotal As Double = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblDebit As Double = 0
            Dim dblCredit As Double = 0
            If Not Object.Equals(dGrid.Rows(i).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(3).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(3).Value.ToString) Then
                        dblDebit = CDbl(dGrid.Rows(i).Cells(3).Value.ToString)
                    End If
                End If
            End If
            If Not Object.Equals(dGrid.Rows(i).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(4).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(i).Cells(4).Value.ToString) Then
                        dblCredit = CDbl(dGrid.Rows(i).Cells(4).Value.ToString)
                    End If
                End If
            End If
            dblDebitTotal = dblDebitTotal + dblDebit
            dblCreditTotal = dblCreditTotal + dblCredit
            dblBalance = dblBalance + (dblDebit - dblCredit)
        Next
        lblBalance.Text = Format(dblBalance, "#,##0.00")
        lblDebits.Text = Format(dblDebitTotal, "#,##0.00")
        lblCredits.Text = Format(dblCreditTotal, "#,##0.00")
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Financials Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnAddSubject_Click(sender As System.Object, e As System.EventArgs) Handles btnAddSubject.Click
        If String.IsNullOrEmpty(cboAddSubject.Text) Then
            MessageBox.Show("Please select the subject from the given list", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAddSubject.Focus()
            Exit Sub
        End If
        dGridSubjects.Rows.Add(cboAddSubject.Text, "0")
    End Sub

    Private Sub SaveStudentSubjects()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_StudentSubjects " _
            & "WHERE StudentId = '" & txtStudentNumberKey.Text & "'", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGridSubjects.Rows.Count - 1
            If Not Object.Equals(dGridSubjects.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridSubjects.Rows(i).Cells(0).Value.ToString) Then
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SC_StudentSubjects " _
                        & "(StudentId, SubjectName) VALUES ('" & txtStudentNumberKey.Text & "', " _
                        & "'" & dGridSubjects.Rows(i).Cells(0).Value.ToString & "')", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Student Subject Save"
        ShowErrorMessage()
    End Sub

    Private Sub SaveGuardians()
        On Error GoTo RaiseErr
        Dim strSql As String = "DELETE FROM [SC_Guardians] WHERE [StudentId] = '" & txtStudentNumberKey.Text & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        strSql = "INSERT INTO [SC_Guardians] ([StudentId],[GivenNames],[Address1],[Address2]," _
            & "[Address3],[Address4],[Cellphone],[Telephone],[Email]) VALUES ('" & txtStudentNumberKey.Text & "', " _
            & "'" & txtSponsorName.Text & "', '" & txtSponsorAddress1.Text & "', '" & txtSponsorAddress2.Text & "', " _
            & "'" & txtSponsorAddress3.Text & "', '" & txtSponsorAddress4.Text & "', '" & txtSponsorCellphone.Text & "', " _
            & "'" & txtSponsorTelephone.Text & "', '" & txtSponsorEmail.Text & "')"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Student Guardians Save"
        ShowErrorMessage()
    End Sub

    Private Sub LoadGuardians()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM [SC_Guardians] WHERE [StudentId] = '" & strSelectedAccount & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("GivenNames").ToString) Then txtSponsorName.Text = objReader("GivenNames").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtSponsorAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtSponsorAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtSponsorAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtSponsorAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtSponsorCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtSponsorTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("Email").ToString) Then txtSponsorEmail.Text = objReader("Email").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Student Guardians Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnImportFinancials_Click(sender As System.Object, e As System.EventArgs) Handles btnImportFinancials.Click
        On Error GoTo RaiseErr
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        Dim strFileName As String = ofd.FileName
        Dim objFileReader As New System.IO.StreamReader(strFileName)
        Dim strData As String = objFileReader.ReadToEnd
        objFileReader.Close()
        Dim strRecords() As String = Split(strData, vbCrLf)
        Dim arrHeaders As New ArrayList

        For i As Integer = 0 To strRecords.Length - 2

            Dim strDate As String = "01-DEC-2015"
            Dim strFields() As String = Split(strRecords(i), "|")
            If i = 0 Then
                For z As Integer = 1 To strFields.Length - 1
                    arrHeaders.Add(strFields(z))
                Next
            Else
                'For p As Integer = 1 To strFields.Length - 1
                Dim dblDebit As Double = 0
                Dim dblCredit As Double = 0
                If IsNumeric(strFields(1)) Then dblDebit = CDbl(strFields(1))
                If IsNumeric(strFields(2)) Then dblCredit = CDbl(strFields(2))

                Dim strSql As String = Nothing
                Dim objCommand As Data.OleDb.OleDbCommand

                If dblDebit <> 0 Then
                    strSql = "INSERT INTO SC_StudentTransactions " _
                        & "(StudentId, Description, Reference, Debit, UserName, TransactionDate, Remarks) VALUES " _
                        & "('" & Trim(strFields(0)) & "', '" & Trim(arrHeaders(1)) & "', '', " _
                        & "" & dblDebit & ", '" & strUserName & "', '" & strDate & "', 'INITIAL DATA IMPORT')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
                If dblCredit <> 0 Then
                    strSql = "INSERT INTO SC_StudentTransactions " _
                        & "(StudentId, Description, Reference, Credit, UserName, TransactionDate, Remarks) VALUES " _
                        & "('" & Trim(strFields(0)) & "', '" & Trim(arrHeaders(1)) & "', '', " _
                        & "" & dblCredit & ", '" & strUserName & "', '" & strDate & "', 'INITIAL DATA IMPORT')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If

                'Next
            End If
        Next
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Scholastica Student Guardians Load"
        ShowErrorMessage()
    End Sub

    Private Sub dpBirthDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dpBirthDate.Validating
        If boolFormLoading = True Then Exit Sub
        If IsDate(dpBirthDate.Value) Then
            Dim lngYear As Long = DatePart(DateInterval.Year, dpBirthDate.Value)
            Dim strStartValueDate As String = "01-JAN-" & (lngYear + intStartingAge)

            Dim myDateFormat() = {"dd/MM/yyyy", "dd-MM-yyyy", "dd-MMM-yyyy"}

            Dim dt1 As Date = Date.ParseExact(strStartValueDate, myDateFormat,
                System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None)
            dpTakenDate.Value = dt1
        End If
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
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 200, 80, "DATE   : " & UCase(Format(dtSetDate, "dd-MMM-yyyy")), DetailsFont, Brushes.Black)
        intY = intY + 15

        'Print receipt number
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 200, 80, "REC. # : " & UCase(intNewStudentReceiptNumber), DetailsFont, Brushes.Black)
        intY = intY + 25

        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 500, 80, UCase(txtLastName.Text & " " & txtFirstName.Text & " " & txtOtherNames.Text) & _
            " CLASS : " & UCase(cboClass.Text), DetailsFont, Brushes.Black)
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

        For p As Integer = 0 To arrNewStudentPaymentDetails.Count - 1

            Dim strBuffer() As String = Split(arrNewStudentPaymentDetails.Item(p), "|")

            Dim strDescription As String = strBuffer(0)
            Dim strReference As String = Nothing
            Dim dblValue As Double = CDbl(strBuffer(1))
            Dim strRemarks As String = Nothing

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
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 500, 80, "TOTAL AMOUNT RECEIVED $" & dblNewStudentPaymentsTotal, HeaderFont, Brushes.Black)
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

    Private Sub btnNewStudentPayments_Click(sender As System.Object, e As System.EventArgs) Handles btnNewStudentPayments.Click
        'Save payments and Print the invoice
        strNewStudentClassName = cboClass.Text
        Dim frm As New frmNewStudentOnceOffPayment
        frm.ShowDialog()
        ProcessPayments()
        Cursor = Cursors.Default
        If MessageBox.Show("Do you want to print the receipt right now?", "Confirm Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            PrintReceipt()
        End If
    End Sub

    Private Sub cboClass_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboClass.SelectedIndexChanged
        On Error GoTo RaiseErr
        lblClassShortName.Text = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ShortName FROM SC_Classes WHERE ClassName = '" & cboClass.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                lblClassShortName.Text = objReader(0).ToString
            End If
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On class shortname fetch"
        ShowErrorMessage()
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
        Select Case UCase(cboCategory.Text)
            Case Is = UCase("Conventional")
                cboSubjectBasedOptions.Enabled = False
                txtBillingAmount.Enabled = False
                txtBillingAmount.Text = "0.00"
                cboConventionalOptions.Enabled = True
            Case Is = UCase("Remedial")
                cboSubjectBasedOptions.Enabled = True
                txtBillingAmount.Enabled = False
                txtBillingAmount.Text = "0.00"
                cboConventionalOptions.Enabled = False
            Case Else
                cboSubjectBasedOptions.Enabled = False
                txtBillingAmount.Enabled = True
                txtBillingAmount.Text = "0.00"
                cboConventionalOptions.Enabled = False
        End Select
    End Sub

    Private Sub LoadSubjectTable()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "SELECT Level +';'+ CONVERT(NVARCHAR, Subjects) +';'+ CONVERT(NVARCHAR, CAST(Fees AS DECIMAL(10,2))) " _
            & "FROM SC_SubjectsPaymentsTable ORDER BY Level"
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboSubjectBasedOptions
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 3
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = "140;30;80"
        End With
        'Get a count of the items

        Dim arrItems As New ArrayList
        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        Dim DropDownItems(arrItems.Count - 1) As MTGCComboBoxItem

        cboSubjectBasedOptions.Items.Clear()

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p).ToString, ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1), strRecordText(2))
        Next

        If arrItems.Count > 0 Then
            cboSubjectBasedOptions.SelectedIndex = -1
            cboSubjectBasedOptions.Items.Clear()
            cboSubjectBasedOptions.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboSubjectBasedOptions.Items.AddRange(DropDownItems)
        End If
        cboSubjectBasedOptions.Enabled = False
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On Subjects Payment Table Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboConventionalOptions_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboConventionalOptions.SelectedIndexChanged
        txtBillingAmount.Text = Format(GetConvenctionalBillingAmount(cboConventionalOptions.Text, cboClass.Text), "##0.00")
    End Sub

    Private Sub cboSubjectBasedOptions_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubjectBasedOptions.SelectedIndexChanged
        lblSubjects.Text = 0
        txtBillingAmount.Text = 0
        If Not cboSubjectBasedOptions.SelectedItem Is Nothing Then
            lblSubjects.Text = cboSubjectBasedOptions.SelectedItem.Col2
            txtBillingAmount.Text = cboSubjectBasedOptions.SelectedItem.Col3
        End If
    End Sub

    Private Sub btnDeleteTransaction_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteTransaction.Click
        On Error GoTo RaiseErr
        If dGrid.RowCount <= 0 Then Exit Sub
        If UCase(strUserLevel) <> "ADMINISTRATOR" Then
            MessageBox.Show("You do not have rights to perform this function. Please contact your system administrator", "Invalid User Rights", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        If MessageBox.Show("Are you sure you want to delete this transaction?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim strSql As String = "DELETE FROM SC_StudentTransactions " _
                & "WHERE TransactionId = " & CInt(dGrid.CurrentRow.Cells(dGrid.ColumnCount - 1).Value.ToString) & ""
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Transaction has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadFinancials()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On financial transaction delete"
        ShowErrorMessage()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        boolAbort = False
        strSelectedDescription = Nothing
        Dim frm As New frmSearchSponsor
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        txtSponsorName.Text = strSelectedDescription
    End Sub

End Class