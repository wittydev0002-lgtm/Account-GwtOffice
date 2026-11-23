Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmProjectResources

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        If String.IsNullOrEmpty(txtResourceName.Text) Then
            MessageBox.Show("Please type in the resource name", "invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtResourceName.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboType.Text) Then
            MessageBox.Show("Please select the resource type", "invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboType.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtCost.Text) Then txtCost.Text = "0.00"
        If Not IsNumeric(txtQuantity.Text) Then txtQuantity.Text = "0.00"

        Cursor = Cursors.WaitCursor
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strSql As String = Nothing

        If boolEditStatus = False Then
            strSql = "INSERT INTO ProjectResources ([ContractNumber], [ResourceName], [ResourceType], [Address], " _
                & "[Telephone], [FaxNumber], [EmailAddress], [Grouping], [UnitCost], [Quantity], [StartDate], " _
                & "[EndDate], [Notes]) VALUES (" & intSelectedProjectNumber & ", '" & txtResourceName.Text & "', " _
                & "'" & cboType.Text & "', '" & txtAddress.Text & "', '" & txtTelephone.Text & "', '" & txtFax.Text & "', " _
                & "'" & txtEmailAddress.Text & "', '" & cboGrouping.Text & "', " & CDbl(txtCost.Text) & ", " _
                & "" & CDbl(txtQuantity.Text) & ", '" & gwt_comm.shortMonthDateFormat(dpStart.Value) & "', " _
                & "'" & gwt_comm.shortMonthDateFormat(dpEndDate.Value) & "', '" & txtNotes.Text & "')"
        Else
            strSql = "UPDATE ProjectResources SET [ResourceName] = '" & txtResourceName.Text & "', " _
                & "[ResourceType] = '" & cboType.Text & "', [Address] = '" & txtAddress.Text & "', " _
                & "[Telephone] = '" & txtTelephone.Text & "', [FaxNumber] = '" & txtFax.Text & "', " _
                & "[EmailAddress] = '" & txtEmailAddress.Text & "', [Grouping] = '" & cboGrouping.Text & "', " _
                & "[UnitCost] = " & CDbl(txtCost.Text) & ", [Quantity] = " & CDbl(txtQuantity.Text) & ", " _
                & "[StartDate] = '" & gwt_comm.shortMonthDateFormat(dpStart.Value) & "', " _
                & "[EndDate] = '" & gwt_comm.shortMonthDateFormat(dpEndDate.Value) & "', " _
                & "[Notes] = '" & txtNotes.Text & "' WHERE TransactionId = " & intSelectedTransaction & ""
        End If
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Project resources have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Project Resources Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM ProjectResources WHERE TransactionId = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("ResourceName").ToString) Then txtResourceName.Text = objReader("ResourceName").ToString
            If Not IsDBNull(objReader("ResourceType").ToString) Then cboType.Text = objReader("ResourceType").ToString
            If Not IsDBNull(objReader("Address").ToString) Then txtAddress.Text = objReader("Address").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("FaxNumber").ToString) Then txtFax.Text = objReader("FaxNumber").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If IsNumeric(objReader("UnitCost").ToString) Then txtCost.Text = Format(CDbl(objReader("UnitCost").ToString), "###0.00")
            If IsNumeric(objReader("Quantity").ToString) Then txtQuantity.Text = Format(CDbl(objReader("Quantity").ToString), "###0.00")
            If IsDate(objReader("StartDate").ToString) Then dpStart.Value = CDate(objReader("StartDate").ToString)
            If IsDate(objReader("EndDate").ToString) Then dpEndDate.Value = CDate(objReader("EndDate").ToString)
            If Not IsDBNull(objReader("Notes").ToString) Then txtNotes.Text = objReader("Notes").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Project Resources Setup"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmProjectResources_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then
            LoadData()
        End If
    End Sub

End Class
