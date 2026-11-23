Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPayrollBatches

    Dim intLineNumber As Integer
    Dim intBatchNumber As Integer

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dgrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrid.CellEndEdit
        If IsNumeric(dgrid.CurrentCell.Value) Then
            dgrid.CurrentCell.Value = Format(CDbl(dgrid.CurrentCell.Value.ToString), "##0.00")
            ComputeTotals()
        End If
    End Sub

    Private Sub dgrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgrid.EditingControlShowing
        Try
            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                'In order to prevent optical problems, we had to call the removeHandler twice
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        strSelectedEmployeeName = Nothing
        boolAbort = False
        gwt_comm.EmployeeSearch()
        'frmBrowseEmployees.ShowDialog()
        If boolAbort = True Then Exit Sub
        txtEcNumber.Text = strSelectedAccount  'strEmployeeNumber
        lblName.Text = strSelectedAccountName  'strSelectedEmployeeName
        txtCode.Focus()
    End Sub

    Private Sub btnFindCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindCode.Click
        strSelectedCodeDescription = Nothing
        strSelectedCode = Nothing
        frmBrowseCodes.ShowDialog()
        txtCode.Text = strSelectedCode
        lblCode.Text = strSelectedCodeDescription
    End Sub

    Private Sub txtEcNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEcNumber.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtCode.Focus()
        Else
            If Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtEcNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEcNumber.TextChanged
        'Get the employee details based on the entered text
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtEcNumber.Text) Then Exit Sub
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ Inits " _
            & "AS [GivenNames] FROM EmployeeMaster WHERE EmployeeNo = '" & txtEcNumber.Text & "'", cnn)
        Dim objreader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        While objreader.Read
            lblName.Text = ""
            If Not IsDBNull(objreader(0).ToString) Then
                lblName.Text = objreader(0).ToString
                Exit While
            End If
        End While
        objreader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Details Find"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtCode_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyData = Keys.Enter Then
            txtAmount.Focus()
        End If
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        lblCode.Text = txtCode.Text
        Dim strCodeText As String = Nothing
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 18 Or Not IsNumeric(e.KeyChar) Then
            'Do nothing
        Else
            lblCode.Text = txtCode.Text & e.KeyChar
        End If
        If Not IsNumeric(txtCode.Text) Then Exit Sub
        lblCode.Text = CodeName(CInt(txtCode.Text))
    End Sub

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged
        lblCode.Text = Nothing
        If Not IsNumeric(txtCode.Text) Then Exit Sub
        lblCode.Text = CodeName(CInt(txtCode.Text))
    End Sub

    Private Function CodeName(ByVal CodeNo As Integer) As String
        Dim strReturn As String = Nothing
        'Get the employee details based on the entered text
        On Error GoTo RaiseErr
        'If String.IsNullOrEmpty(txtCode.Text) Then Exit Sub
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT Description " _
            & "FROM SystemCodes WHERE CodeNo = " & CInt(txtCode.Text) & " AND " _
            & "DisplayStatus = 'N'", cnn)
        Dim objreader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        While objreader.Read
            If Not IsDBNull(objreader(0).ToString) Then
                strReturn = objreader(0).ToString
                Exit While
            End If
        End While
        objreader.Close()
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Payroll Code Details Find"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub txtAmount_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnOk.Focus()
        End If
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnOk.Focus()
        Else
            If e.KeyChar = "." Then Exit Sub
            If Asc(e.KeyChar) <> 8 Then
                If Not IsNumeric(e.KeyChar) Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub frmPayrollBatches_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then
            intBatchNumber = intSelectedBatchNumber
            LoadBatchDetails()
        Else
            intBatchNumber = GetNextBatchNumber()
        End If
    End Sub

    Private Sub LoadBatchDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT EmployeeBatches.BatchNo, EmployeeBatches.EmployeeNo, " _
            & "EmployeeMaster.LastName +' '+ EmployeeMaster.FirstName +' '+ EmployeeMaster.OtherNames AS [Given Names], " _
            & "EmployeeBatches.CodeNo, SystemCodes.Description, CAST(EmployeeBatches.Amount AS DECIMAL(10,2)) AS [Amount] " _
            & "FROM EmployeeBatches LEFT OUTER JOIN EmployeeMaster ON EmployeeBatches.EmployeeNo = EmployeeMaster.EmployeeNo " _
            & "LEFT OUTER JOIN SystemCodes ON EmployeeBatches.CodeNo = SystemCodes.CodeNo where BatchNo = " & intSelectedBatchNumber & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dgrid.Rows.Clear()
        While objReader.Read
            With dgrid
                .Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3), objReader(4), objReader(5))
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Batch Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Function GetNextBatchNumber() As Integer
        'Get the number of the next batch from the payroll batches file
        On Error GoTo RaiseErr
        Dim intReturn As Integer = 1
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT BatchNo " _
            & "FROM SystemBatchesControl ORDER BY BatchNo DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then intReturn = CInt(objReader(0).ToString) + 1
        End If
        objReader.Close()
        Return intReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Batch Number Allocation"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        'Add the details to the list view
        If txtEcNumber.Text = "" Then
            MessageBox.Show("Please enter a value for the employee number", _
                "Invalid Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEcNumber.Focus()
            Exit Sub
        End If
        If lblName.Text = "" Then
            MessageBox.Show("It looks like you have not entered the correct employee number." & vbCrLf & "Please correct before proceeding", _
                "Invalid Employee Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEcNumber.Focus()
            Exit Sub
        End If
        If txtCode.Text = "" Then
            MessageBox.Show("Please enter the payroll code to assign value to", _
                "Invalid Payroll Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCode.Focus()
            Exit Sub
        End If
        If lblCode.Text = "" Then
            MessageBox.Show("It looks like the code number you have entered is incorrect." & vbCrLf & _
                "Please correct before proceeding", "Invalid Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCode.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Please enter a valid value for amount", "Invalid Amount Entered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAmount.Focus()
            Exit Sub
        End If
        'Add the details to the grid control if correct
        dgrid.Rows.Add(1)
        ''Before the actual save to the payroll batches, the batch number is 0
        'Dim LItem As New ListViewItem
        dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = intBatchNumber
        dgrid.Rows(dgrid.Rows.Count - 1).Cells(1).Value = txtEcNumber.Text
        dgrid.Rows(dgrid.Rows.Count - 1).Cells(2).Value = lblName.Text
        dgrid.Rows(dgrid.Rows.Count - 1).Cells(3).Value = txtCode.Text
        dgrid.Rows(dgrid.Rows.Count - 1).Cells(4).Value = lblCode.Text
        dgrid.Rows(dgrid.Rows.Count - 1).Cells(5).Value = CStr(Format(CDbl(txtAmount.Text), "#,##0.00"))

        ComputeTotals()

        'clear the control and return focus to start
        txtEcNumber.Clear()
        txtCode.Clear()
        txtAmount.Clear()
        lblName.Text = ""
        lblCode.Text = ""
        txtEcNumber.Focus()

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        Dim i As Integer
        If Me.dgrid.Rows.Count > 0 Then
            dgrid.Rows.RemoveAt(dgrid.CurrentRow.Index)
        End If
        ComputeTotals()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " Batch Line Delete Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Write the information read off the listview
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand

        'Allocate the batch number at this point
        If boolEditStatus = False Then
            intBatchNumber = GetNextBatchNumber()
            MessageBox.Show("You batch number is " & intBatchNumber, "Batch Number Control", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'Delete the previous batch details and the header line as well
            strSql = "DELETE FROM SystemBatchesControl WHERE BatchNo = " & intBatchNumber & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            strSql = "DELETE FROM EmployeeBatches WHERE BatchNo = " & intBatchNumber & ""
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        Dim dblTotals As Double = 0
        For i = 0 To dgrid.Rows.Count - 1
            strSql = "INSERT INTO EmployeeBatches (EntryLineNo, BatchNo, " _
                & "EmployeeNo, Amount, TransDate, CodeNo, CostCode, " _
                & "UserName, EffectivePeriod, Class) VALUES (" & (i + 1) & ", " _
                & "" & intBatchNumber & ", '" & dgrid.Rows(i).Cells(1).Value.ToString & "', " _
                & "" & CDbl(dgrid.Rows(i).Cells(5).Value.ToString) & ", '" & Now & "', " & dgrid.Rows(i).Cells(3).Value.ToString & ", " _
                & "'', '" & strUserName & "', 0, 1)"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            dblTotals = dblTotals + CDbl(dgrid.Rows(i).Cells(5).Value.ToString)
        Next

        'Write the batch control values
        objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemBatchesControl " _
            & "(BatchNo, CreationDate, Author, Status, BatchTotal, NumberOfEntries) VALUES (" _
            & "" & intBatchNumber & ", '" & Now & "', '" & strUserName & "', 'NOT PROCESSED', " _
            & "" & dblTotals & ", " & dgrid.Rows.Count & ")", cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("The batch has been successfully written to file", "Payroll Batches Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Batch Transactions Save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmPayrollBatches_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 685 : Me.Height = 512
    End Sub

    Private Sub ComputeTotals()
        On Error GoTo RaiseErr

        Dim intCount As Integer = 0
        Dim dblTotal As Double = 0

        For p As Integer = 0 To dgrid.Rows.Count - 1
            If Not Object.Equals(dgrid.Rows(p).Cells(5).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dgrid.Rows(p).Cells(5).Value.ToString) Then
                    If IsNumeric(dgrid.Rows(p).Cells(5).Value.ToString) Then
                        dblTotal = dblTotal + CDbl(dgrid.Rows(p).Cells(5).Value.ToString)
                    End If
                End If
            End If
        Next

        lblTotalAmt.Text = Format(dblTotal, "#,##0.00")
        lblCount.Text = Format(intCount, "#,##0")

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Batch Transactions Totals Computation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtCode_Validated(sender As Object, e As System.EventArgs) Handles txtCode.Validated
        If String.IsNullOrEmpty(txtCode.Text) Then
            strSelectedCodeDescription = Nothing
            strSelectedCode = Nothing
            frmBrowseCodes.ShowDialog()
            txtCode.Text = strSelectedCode
            lblCode.Text = strSelectedCodeDescription
        End If
    End Sub

    Private Sub txtEcNumber_Validated(sender As Object, e As System.EventArgs) Handles txtEcNumber.Validated
        If String.IsNullOrEmpty(txtEcNumber.Text) Then
            strSelectedEmployeeName = Nothing
            boolAbort = False
            gwt_comm.EmployeeSearch()
            'frmBrowseEmployees.ShowDialog()
            If boolAbort = True Then Exit Sub
            txtEcNumber.Text = strSelectedAccount  'strEmployeeNumber
            lblName.Text = strSelectedAccountName  'strSelectedEmployeeName
            txtCode.Focus()
        End If
    End Sub

End Class