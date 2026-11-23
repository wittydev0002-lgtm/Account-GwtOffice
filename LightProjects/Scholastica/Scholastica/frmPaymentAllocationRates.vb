Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPaymentAllocationRates
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(cboCostCenter.Text) Then
            MessageBox.Show("Please select the cost center", "Missing Cost Center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCostCenter.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDescription.Text) Then
            MessageBox.Show("Please enter the description", "Missing Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDescription.Select()
            Exit Sub
        End If
        If Not IsNumeric(txtRating.Text) Then
            MessageBox.Show("Please enter a valid value for rate/priority", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRating.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboType.Text) Then
            MessageBox.Show("Please select the payment type", "Missing Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboType.Select()
            Exit Sub
        End If
        dGrid.Rows.Add(txtDescription.Text, txtRating.Text, cboType.Text, cboCostCenter.Text)
        txtDescription.Text = Nothing : txtRating.Text = "0.00"
        txtDescription.Select()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Function ValidateRates() As Boolean
        Dim boolReturn As Boolean = True
        Dim dblValue As Double = 0
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        dblValue = dblValue + CDbl(dGrid.Rows(p).Cells(1).Value.ToString)
                    End If
                End If
            End If
        Next
        If dblValue <> 100 Then
            boolReturn = False
        End If
        Return boolReturn
    End Function

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        On Error GoTo RaiseErr
        If ValidateRates() = False Then
            MessageBox.Show("The percentages do not add up t0 100. Please correct", "Invalid Percentage Rates", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboCostCenter.Text) Then
            MessageBox.Show("Please select the cost center", "Missing Cost Center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCostCenter.Select()
            Exit Sub
        End If
        Dim objCommand As Data.OleDb.OleDbCommand

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SC_PaymentDescription2 WHERE CostCenter = '" & cboCostCenter.Text & "'", cnn)
        objCommand.ExecuteNonQuery()

        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim strDescription As String = Nothing
            Dim dblRate As Double = 0
            Dim strType As String = Nothing
            Dim strCostCenter As String = Nothing
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strDescription = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If
            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        dblRate = CDbl(dGrid.Rows(p).Cells(1).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    strType = dGrid.Rows(p).Cells(2).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(3).Value.ToString) Then
                    strCostCenter = dGrid.Rows(p).Cells(3).Value.ToString
                End If
            End If

            Dim strSql As String = "INSERT INTO SC_PaymentDescription2 (Description, Rate, Type, CostCenter) VALUES " _
                & "('" & strDescription & "', " & dblRate & ", '" & strType & "', '" & strCostCenter & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Next
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Payments Description Setup"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub


    Private Sub LoadData(CostCenterName As String)
        On Error GoTo RaiseErr

        Dim strSql As String = "SELECT Description, CAST(Rate AS DECIMAL (10,2)) AS [Rate], " _
            & "Type AS [Type], CostCenter as [Cost Center] FROM SC_PaymentDescription2 " _
            & "WHERE CostCenter = '" & CostCenterName & "' ORDER BY Rate"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2), objReader(3))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Payments Description Setup"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadCostCenters()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT SystemCostCenters.CostCenterName " _
            & "FROM SystemCostCenters ORDER BY SystemCostCenters.CostCenterName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboCostCenter.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                cboCostCenter.Items.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On classes setup"
        ShowErrorMessage()
    End Sub

    Private Sub cboCostCenter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCostCenter.SelectedIndexChanged
        LoadData(cboCostCenter.Text)
    End Sub

    Private Sub frmPaymentAllocationRates_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCostCenters()
    End Sub

End Class


