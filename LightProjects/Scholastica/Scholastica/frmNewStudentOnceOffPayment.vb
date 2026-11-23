Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmNewStudentOnceOffPayment

    Dim dblExcessAmount As Double
    Dim intTrip As Integer

    Private Sub frmNewStudentOnceOffPayment_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'cboClients.SelectedText = strSelectedAccountName
        'lblStudentDetails.Text = strSelectedAccount
        DisplayDueBreakdown(strNewStudentClassName)
        txtAmount.Select()
        dtTransDate.Enabled = False
        txtReceiptNumber.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))
        txtReceiptNumber.Enabled = False
    End Sub

    Private Sub txtAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyValue = Keys.Enter Then
            txtRemarks.Select()
        End If
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnOk.Focus()
        End If
    End Sub

    Private Sub txtAmount_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAmount.Validating
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

    Private Sub DistributePayment(AmountPaid As Double)
        On Error GoTo RaiseErr
        Dim dblAvailableAmount As Double = AmountPaid
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

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On student dues breakdown allocation"
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

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On payment totals computation"
        ShowErrorMessage()
    End Sub

    Private Sub frmNewStudentOnceOffPayment_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 667
        Me.Height = 451
    End Sub

    Private Sub DisplayDueBreakdown(StudentClassName As String)
        On Error GoTo RaiseErr

        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        'Get the class cost code
        Dim strCostCode As String = Nothing
        objCommand = New Data.OleDb.OleDbCommand("SELECT SC_Classes.CostCenter FROM SC_Classes " _
            & "WHERE SC_Classes.ClassName = '" & StudentClassName & "'", cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strCostCode = objReader(0).ToString
        End If
        objReader.Close()

        'Get the costings based on the class name
        objCommand = New Data.OleDb.OleDbCommand("SELECT [SC_NewStudentPaymentDescriptionAmts].Description, " _
            & "CAST([SC_NewStudentPaymentDescriptionAmts].Amount AS DECIMAL(10,2)) AS [Amount] FROM [SC_NewStudentPaymentDescriptionAmts] " _
            & "WHERE CostCode = '" & strCostCode & "'", cnn)
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

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On student dues breakdown information load"
        ShowErrorMessage()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr

        boolAbort = False

        arrNewStudentPaymentDetails = New ArrayList

        Dim strNewStudentPaymentRemarks As String = txtRemarks.Text

        If chkOverrideNo.Checked = True Then
            If Not IsNumeric(txtReceiptNumber.Text) Then
                MessageBox.Show("Please enter a valid receipt number", "Invalid Receipt Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtReceiptNumber.Focus()
                Exit Sub
            Else
                If CInt(txtReceiptNumber.Text) <= 0 Then
                    MessageBox.Show("Please enter a valid receipt number", "Invalid Receipt Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtReceiptNumber.Focus()
                    Exit Sub
                End If
            End If
            boolIncreamentCounter = False
            intOverideReceiptNumber = CInt(txtReceiptNumber.Text)
        Else
            boolIncreamentCounter = True
        End If

        For p As Integer = 0 To dGrid.Rows.Count - 1

            Dim strDescription As String = Nothing
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

            arrNewStudentPaymentDetails.Add(strDescription & "|" & dblValue)
        Next

        dblNewStudentPaymentsTotal = CDbl(lblTotalPaid.Text)
        dtSetDate = dtTransDate.Value

        boolAbort = False
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error number " & Err.Number & vbCrLf & "On new student payment processing"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub chkOverrideNo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOverrideNo.CheckedChanged
        If chkOverrideNo.Checked = True Then
            txtReceiptNumber.Clear()
            txtReceiptNumber.Enabled = True
            boolIncreamentCounter = True
        Else
            txtReceiptNumber.Enabled = False
            'Get the next document number
            boolIncreamentCounter = False
            txtReceiptNumber.Text = CStr(gwt_comm.GetNextDocumentNumber("CashSales"))
        End If
    End Sub

    Private Sub chkOverideDate_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOverideDate.CheckedChanged
        If chkOverideDate.Checked = True Then
            dtTransDate.Value = Now
            dtTransDate.Enabled = True
        Else
            dtTransDate.Enabled = False
        End If
    End Sub

End Class
