Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmInventorySpecials

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cboItemType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemType.SelectedIndexChanged
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Select Case UCase(cboItemType.Text)
            Case Is = "CATEGORY"
                strSql = "SELECT DISTINCT Category FROM Categories ORDER BY Category"
            Case Is = "SUB-CATEGORY"
                strSql = "SELECT DISTINCT SubCategory FROM SubCategories ORDER BY SubCategory"
            Case Else
                strSql = "SELECT ItemCode FROM InventoryItems ORDER BY ItemCode"
        End Select
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboItems.Items.Clear()
        Cursor = Cursors.WaitCursor
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboItems.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error encountered while populating items for the selected type"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub cboCondition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondition.SelectedIndexChanged
        If UCase(cboCondition.Text) = "NONE" Then
            txtConditionAmtMinima.Text = "0.00" : txtConditionAmtMinima.Enabled = False
            txtConditionAmtMaxima.Text = "0.00" : txtConditionAmtMaxima.Enabled = False
        Else
            txtConditionAmtMinima.Text = "0.00" : txtConditionAmtMinima.Enabled = True
            txtConditionAmtMaxima.Text = "0.00" : txtConditionAmtMaxima.Enabled = True
        End If
    End Sub

    Private Sub txtConditionAmtMinima_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConditionAmtMinima.KeyPress
        If Asc(e.KeyChar) = 13 Then txtConditionAmtMaxima.Focus()
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtConditionAmtMaxima_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConditionAmtMaxima.KeyPress
        If Asc(e.KeyChar) = 13 Then txtConditionAmtMaxima.Focus()
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtDiscount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscount.KeyPress
        If Asc(e.KeyChar) = 13 Then txtConditionAmtMaxima.Focus()
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'Validate data
        If String.IsNullOrEmpty(cboItemType.Text) Then
            MessageBox.Show("Please state to which item special applies to", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboItemType.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboItems.Text) Then
            MessageBox.Show("Please select the item or category or sub category to apply special on", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboItems.Focus()
            Exit Sub
        End If
        If dpEnd.Value < dpStart.Value Then
            MessageBox.Show("The end date cannot be less that the start date", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dpStart.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboCondition.Text) Then
            MessageBox.Show("Please state the condition", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboCondition.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtConditionAmtMinima.Text) Then
            MessageBox.Show("Please enter a valid numeric value for minima", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtConditionAmtMinima.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtConditionAmtMaxima.Text) Then
            MessageBox.Show("Please enter a valid numeric value for maxima", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtConditionAmtMaxima.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtDiscount.Text) Then
            MessageBox.Show("Please enter a valid numeric value for discount", "Invalid Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDiscount.Focus()
            Exit Sub
        End If
        If boolEditStatus = False Then InsertSpecial() Else UpdateSpecial()
    End Sub

    Private Sub InsertSpecial()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strFactor As String = "PERCENT"
        If optAmount.Checked Then strFactor = "AMOUNT"
        Dim strSql As String = "INSERT INTO ItemSpecials ([AppliesTo], [Description], [StartDate], [EndDate], " _
            & "[Condition], [ConditionalMinimaPrice], [ConditionalMaximaPrice], [Discount], [DiscountType]) VALUES " _
            & "('" & cboItemType.Text & "', '" & cboItems.Text & "', '" & gwt_comm.shortMonthDateFormat(dpStart.Value) & "', " _
            & "'" & gwt_comm.shortMonthDateFormat(dpEnd.Value) & "', '" & cboCondition.Text & "', " & CDbl(txtConditionAmtMinima.Text) & ", " _
            & "" & CDbl(txtConditionAmtMaxima.Text) & ", " & CDbl(txtDiscount.Text) & ", '" & strFactor & "')"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        txtConditionAmtMaxima.Text = "0.00"
        txtConditionAmtMinima.Text = "0.00"
        txtDiscount.Text = "0.00"
        cboItems.Items.Clear()
        cboItemType.Text = ""
        cboCondition.Text = "NONE"
        dpStart.Value = Now : dpEnd.Value = Now
        MessageBox.Show("Special Added Successfully", "Sales Special Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error encountered while populating items for the selected type"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub UpdateSpecial()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strFactor As String = "PERCENT"
        If optAmount.Checked Then strFactor = "AMOUNT"
        Dim strSql As String = "UPDATE ItemSpecials SET AppliesTo = '" & cboItemType.Text & "', " _
            & "Description = '" & cboItems.Text & "', StartDate = '" & gwt_comm.shortMonthDateFormat(dpStart.Value) & "', " _
            & "EndDate = '" & gwt_comm.shortMonthDateFormat(dpEnd.Value) & "', Condition = '" & cboCondition.Text & "', " _
            & "ConditionalMinimaPrice = " & CDbl(txtConditionAmtMinima.Text) & ", ConditionalMaximaPrice = " & CDbl(txtConditionAmtMaxima.Text) & ", " _
            & "Discount = " & CDbl(txtDiscount.Text) & ", DiscountType = '" & strFactor & "' WHERE TransactionId = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Special Updates Successfully", "Sales Special Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error encountered while saving data"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        'intSelectedTransaction
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM ItemSpecials WHERE TransactionId = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("AppliesTo").ToString) Then cboItemType.Text = objReader("AppliesTo").ToString
            If Not IsDBNull(objReader("Description").ToString) Then cboItems.Text = objReader("Description").ToString
            If IsDate(objReader("StartDate").ToString) Then dpStart.Value = CDate(objReader("StartDate").ToString)
            If IsDate(objReader("EndDate").ToString) Then dpEnd.Value = CDate(objReader("EndDate").ToString)
            If Not IsDBNull(objReader("Condition").ToString) Then cboCondition.Text = objReader("Condition").ToString
            If IsNumeric(objReader("ConditionalMinimaPrice").ToString) Then txtConditionAmtMinima.Text = Format(CDbl(objReader("ConditionalMinimaPrice").ToString), "##0.00")
            If IsNumeric(objReader("ConditionalMaximaPrice").ToString) Then txtConditionAmtMaxima.Text = Format(CDbl(objReader("ConditionalMaximaPrice").ToString), "##0.00")
            If IsNumeric(objReader("Discount").ToString) Then txtDiscount.Text = Format(CDbl(objReader("Discount").ToString), "##0.00")
            If Not IsDBNull(objReader("DiscountType").ToString) Then
                If UCase(objReader("DiscountType").ToString) = "PERCENT" Then
                    optPercent.Checked = True : optAmount.Checked = False
                Else
                    optPercent.Checked = False : optAmount.Checked = True
                End If
            End If
        End If
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Error encountered while populating details"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmInventorySpecials_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then LoadData()
    End Sub

    Private Sub frmInventorySpecials_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 622 : Me.Height = 299
    End Sub

End Class