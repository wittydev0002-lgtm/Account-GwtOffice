Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmFeesPayments

    Dim arrAllocations As ArrayList
    Dim intYear As Integer = DatePart(DateInterval.Year, Now)

    Private Sub txtStudent_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStudent.KeyDown
        If e.KeyData = Keys.Enter Then
            strSearchText = txtStudent.Text
            boolAbort = False
            Dim frm As New frmStudentSearch
            frm.ShowDialog()
            If boolAbort = True Then Exit Sub
            lblGivenName.Text = strSelectedAccountName
            lblStudentId.Text = strSelectedAccount
            lblClassName.Text = GetStudentClass(CInt(lblStudentId.Text))
            txtStudent.Text = strSelectedAccount
            FeeAllocations(strSelectedAccount)
            If IsNumeric(strSelectedAccount) Then
                lblBalance.Text = Format(GetStudentBalance(CInt(strSelectedAccount)), "##0.00")
            Else
                lblBalance.Text = "0.00"
            End If
            txtAmount.Select()
        End If
    End Sub

    Private Function GetStudentBalance(StudentId As Long) As Double
        On Error GoTo RaiseErr
        Dim dblReturn As Double = 0
        Dim strSql As String = "SELECT SUM(Debit - Credit) FROM SC_StudentTransactions WHERE StudentId = " & StudentId & ""
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
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On students payments receipting"
        ShowErrorMessage()
    End Function

    Private Sub txtAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyData = Keys.Enter Then
            If IsNumeric(txtAmount.Text) Then
                If CDbl(txtAmount.Text) <> 0 Then
                    AllocateFunds(txtAmount.Text)
                    txtReference.Select()
                    Exit Sub
                Else
                    MessageBox.Show("The amount must not be equal to 0", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtAmount.Text = "0.00"
                End If
            Else
                MessageBox.Show("You have entered an invalid amount", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtAmount.Text = "0.00"
            End If
        End If
    End Sub

    Private Function GetStudentClass(StudentNumber As Integer) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ClassName FROM SC_Students WHERE StudentId = " & StudentNumber & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then strReturn = objReader(0).ToString
        End If
        objReader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Student class get"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub AllocateFunds(Amount As Double)
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        If Not String.IsNullOrEmpty(lblStudentId.Text) Then
            FeeAllocations(lblStudentId.Text)
            For p As Integer = 0 To arrAllocations.Count - 1
                Dim strBuffer() As String = Split(arrAllocations.Item(p), "|")
                Dim dblValue As Double = 0
                Dim dblRate As Double = 0
                If IsNumeric(strBuffer(1)) Then
                    dblRate = CDbl(strBuffer(1)) / 100
                    dblValue = Amount * dblRate
                End If
                dGrid.Rows.Add(UCase(strBuffer(0)), Format(TermFees(lblStudentId.Text, CInt(txtTerm.Text), dblRate), "##0.00"),
                   Format(PaidTermFees(lblStudentId.Text, CInt(txtTerm.Text), dblRate), "##0.00"), Format(dblValue, "##0.00"))
            Next
            ComputeTotal()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Payment Processing"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub FeeAllocations(StudentId As String)
        On Error GoTo RaiseErr
        arrAllocations = New ArrayList
        Dim strCostCode As String = Nothing
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT CostCenter FROM SC_Classes WHERE ClassName IN " _
            & "(SELECT ClassName FROM SC_Students WHERE StudentId = '" & StudentId & "')", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                strCostCode = objReader(0).ToString
            End If
        End If
        objReader.Close()

        Dim strSql As String = "SELECT Description, CAST(Rate AS DECIMAL (10,0)) AS [Rate] " _
            & "FROM SC_PaymentDescription2 WHERE CostCenter = '" & strCostCode & "' ORDER BY Description"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader
        While objReader.Read
            arrAllocations.Add(objReader(0).ToString & "|" & objReader(1).ToString)
        End While
        objReader.Close()
        cboPayMethod.SelectedIndex = 0
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function TermFees(StudentId As Integer, Term As String, Rate As Double) As Double
        On Error GoTo RaiseErr
        Dim dblReturn As Double = 0
        Dim strSql As String = "SELECT ISNULL(SUM(Debit), 0) FROM SC_StudentTransactions " _
            & "WHERE SchoolTerm = 'TERM " & Term & "' AND TermYear = " & intYear & " AND StudentId = " & StudentId & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblReturn = CDbl(objReader(0).ToString) * Rate
            End If
        End If
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Data Load"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Function PaidTermFees(StudentId As Integer, Term As String, Rate As Double) As Double
        On Error GoTo RaiseErr
        Dim dblReturn As Double = 0
        Dim strSql As String = "SELECT ISNULL(SUM(Credit), 0)FROM SC_StudentTransactions " _
            & "WHERE SchoolTerm = 'TERM " & Term & "' AND TermYear = " & intYear & " AND StudentId = " & StudentId & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblReturn = CDbl(objReader(0).ToString) * Rate
            End If
        End If
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Data Load"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub txtReference_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReference.KeyDown
        If e.KeyData = Keys.Enter Then
            btnOk.Focus()
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If CDate(Format(dpTrans.Value, "dd-MMM-yyyy")) > CDate(Format(Now, "dd-MMM-yyyy")) Then
            MessageBox.Show("Receipt cannot be dated into the future", "Future Date Transaction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dpTrans.Select()
            Exit Sub
        End If
        Dim objCommand As Data.OleDb.OleDbCommand
        txtReceiptNumber.Text = gwt_comm.GetNextDocumentNumber("CashSales")
        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim strDescription As String = Nothing
            Dim dblAmount As Double = 0
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strDescription = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(3).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(3).Value.ToString) Then
                        dblAmount = CDbl(dGrid.Rows(p).Cells(3).Value.ToString)
                    End If
                End If
            End If
            Dim strSql As String = "INSERT INTO [SC_StudentTransactions] ([StudentId],[Description],[Reference]," _
                    & "[Debit],[Credit],[UserName],[TransactionDate],[Remarks], [ReceiptNo], [SchoolTerm], [TermYear]) VALUES " _
                    & "('" & lblStudentId.Text & "', '" & strDescription & "', " _
                    & "'', 0, " & dblAmount & ", " _
                    & "'" & strUserName & "', '" & Format(dpTrans.Value, "dd-MMM-yyyy") & "', " _
                    & "'', " & txtReceiptNumber.Text & ", 'TERM " & CInt(txtTerm.Text) & "', " & intYear & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Next
        dGrid.Rows.Clear()
        lblClassName.Text = Nothing
        lblGivenName.Text = Nothing
        lblStudentId.Text = Nothing
        txtStudent.Text = Nothing
        txtAmount.Text = "0.00"
        txtStudent.Select()
        txtReference.Clear()

        'Update the receipts counter
        objCommand = New Data.OleDb.OleDbCommand("Update ControlNumbers SET CashSales = (CashSales + 1)", cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Payment processed successfuly", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'Print the receipt here
        SettlementDate = CDate(Format(dpTrans.Value, "dd-MMM-yyyy"))
        dblSettlementInvoiceTotals = CDbl(lblBalance.Text)
        dblSettlementReceivedCurrently = CDbl(lblTotalPayment.Text)
        dblSettlementCurrentBalance = CDbl(lblBalance.Text) - CDbl(lblTotalPayment.Text)
        gwt_comm.PrintCustomerDocument(txtReceiptNumber.Text, "FEES", dblSettlementInvoiceTotals, 0, 0, dblSettlementReceivedCurrently, dblSettlementCurrentBalance)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Payment Receipting"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnExtraPayments_Click(sender As Object, e As EventArgs) Handles btnExtraPayments.Click
        boolAbort = False
        Dim frm As New frmExtraPayments
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        With dGrid
            .Rows.Add(strExtraPaymentDescription, "0.00", "0.00", Format(dblExtraAmount, "##0.00"))
        End With
        ComputeTotal()
    End Sub

    Private Sub ComputeTotal()
        Dim dblTotal As Double = 0
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(3).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(3).Value.ToString) Then
                        dblTotal = dblTotal + CDbl(dGrid.Rows(p).Cells(3).Value.ToString)
                    End If
                End If
            End If
        Next
        lblTotalPayment.Text = Format(dblTotal, "##0.00")
    End Sub

    Private Sub txtAmount_Leave(sender As Object, e As EventArgs) Handles txtAmount.Leave
        If IsNumeric(txtAmount.Text) Then
            If CDbl(txtAmount.Text) <> 0 Then
                AllocateFunds(txtAmount.Text)
                lblTotalPayment.Text = Format(CDbl(txtAmount.Text), "##0.00")
                txtReference.Select()
                Exit Sub
            Else
                MessageBox.Show("The amount must not be equal to 0", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtAmount.Text = "0.00"
            End If
        Else
            MessageBox.Show("You have entered an invalid amount", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Text = "0.00"
        End If
    End Sub

    Private Sub frmFeesPayments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If boolCalledFromListing = True Then
            lblGivenName.Text = strSelectedAccountName
            lblStudentId.Text = strSelectedAccount
            lblClassName.Text = GetStudentClass(CInt(lblStudentId.Text))
            txtStudent.Text = strSelectedAccount
            FeeAllocations(strSelectedAccount)
            If IsNumeric(strSelectedAccount) Then
                lblBalance.Text = Format(GetStudentBalance(CInt(strSelectedAccount)), "##0.00")
            Else
                lblBalance.Text = "0.00"
            End If
            txtAmount.Select()
        End If
    End Sub

End Class