Imports System.Drawing
Imports System.Drawing.Printing
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmStudentTransactionsEntryInvoice

    'Declare the pen color for use now nd in future 
    Dim myPen As System.Drawing.Pen
    Dim myBrush As System.Drawing.Brush

    Dim HeaderFont As New System.Drawing.Font("Arial", 14, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    Dim DetailsFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    Dim FooterFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Dim dblExcessAmount As Double = 0
    Dim intTrip As Integer = 0
    Dim strSelectedStudentClassName As String

    Private Sub frmStudentTransactionsEntry_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F5 Then
            boolAbort = False
            SaveData()
        End If
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

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        boolAbort = False
        ValidateAmount()
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
            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(2).Value.ToString) Then
                        dblValue = dGrid.Rows(p).Cells(2).Value.ToString
                    End If
                End If
            End If

            If dblValue <> 0 Then
                strSql = "INSERT INTO [SC_StudentTransactions] ([StudentId],[Description],[Reference]," _
                    & "[Debit],[Credit],[UserName],[TransactionDate],[Remarks]) VALUES " _
                    & "('" & lblStudentDetails.Text & "', '" & strDescription & "', " _
                    & "'', " & dblValue & ", 0, " _
                    & "'" & strUserName & "', '" & Format(dpTransDate.Value, "dd-MMM-yyyy") & "', " _
                    & "'" & strRemarks & "')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next

        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        If MessageBox.Show("Do you want to print the receipt right now?", "Confirm Receipt Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            PrintInvoice()
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
                If Not Object.Equals(.Rows(p).Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(.Rows(p).Cells(2).Value.ToString) Then
                        If IsNumeric(.Rows(p).Cells(2).Value.ToString) Then
                            dblTotalPaid = dblTotalPaid + CDbl(.Rows(p).Cells(2).Value.ToString)
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

    Private Sub PrintInvoice()
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
        'Call gwt_Comm.DrawStringInBoxLeft(e, intX, intY, 200, 80, "REC. # : " & UCase(txtReceiptNumber.Text), DetailsFont, Brushes.Black)
        'intY = intY + 25

        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 500, 80, UCase(cboClients.Text) & " CLASS : " & UCase(strSelectedStudentClassName), DetailsFont, Brushes.Black)
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
            'If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
            '    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
            '        strReference = dGrid.Rows(p).Cells(1).Value.ToString
            '    End If
            'End If
            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(2).Value.ToString) Then
                        dblValue = dGrid.Rows(p).Cells(2).Value.ToString
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
        Call gwt_comm.DrawStringInBoxLeft(e, intX, intY, 500, 80, "TOTAL AMOUNT INVOICED $" & lblTotalPaid.Text, HeaderFont, Brushes.Black)
        intY = intY + 30
        'Call gwt_Comm.DrawStringInBoxLeft(e, intX, intY, 500, 80, "Received with thanks by " & strUserName, DetailsFont, Brushes.Black)
        'intY = intY + 15
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
            dGrid.Rows.Add(objReader(0), objReader(1))
        End While
        objReader.Close()

        'Populate the amount already paid to date for the term

        'Compute the due
        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim dblAmount As Double = 0
            Dim dblPaid As Double = 0
            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(2).Value.ToString) Then
                        dblAmount = CDbl(dGrid.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
            End If
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
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If intTrip = 0 Then dGrid.Rows(p).Cells(2).Value = "0.00"
            Dim dblCurrentValue As Double = 0
            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(2).Value.ToString) Then
                        dblCurrentValue = CDbl(dGrid.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
            End If
            If dblAvailableAmount > 0 Then
                Dim dblDue As Double = 0
                If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                            dblDue = CDbl(dGrid.Rows(p).Cells(1).Value.ToString)
                        End If
                    End If
                End If
                If dblDue > 0 Then
                    Dim dblBalance As Double = dblAvailableAmount - dblDue
                    If dblBalance < 0 Then
                        dGrid.Rows(p).Cells(2).Value = Format((dblAvailableAmount), "##0.00")
                        dblAvailableAmount = 0
                    Else
                        dGrid.Rows(p).Cells(2).Value = Format((dblDue + dblCurrentValue), "##0.00")
                        dblAvailableAmount = dblBalance '
                    End If
                End If
            End If
        Next

        'Add all the totals
        'dblExcessAmount
        Dim dblAllocated As Double = 0
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(2).Value.ToString) Then
                        dblAllocated = dblAllocated + CDbl(dGrid.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
            End If
        Next
        dblExcessAmount = CDbl(txtAmount.Text) - dblAllocated
        If dblExcessAmount <= 0 Then
            ComputeTotal()
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On student dues breakdown allocation"
        ShowErrorMessage()
    End Sub

    Private Sub frmStudentTransactionsEntryInvoice_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.TextExtra = strTransferType
        LoadClients()
        dpTransDate.Value = Now
        If Not String.IsNullOrEmpty(strSelectedAccountName) Then
            cboClients.SelectedText = strSelectedAccountName
            lblStudentDetails.Text = strSelectedAccount
            DisplayDueBreakdown(lblStudentDetails.Text)
            lblAccBalance.Text = Format(AccountBalance(strSelectedAccount), "##0.00")
            cboClients.Enabled = False
            txtAmount.Select()
        End If
    End Sub

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
            If CDbl(txtAmount.Text) > dblExpectedAmount Then
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
                        dGrid.Rows(j).Cells(2).Value = "0.00"
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

End Class
