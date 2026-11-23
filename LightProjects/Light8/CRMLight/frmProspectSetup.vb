Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmProspectSetup

    Private Sub btnNewNote_Click(sender As System.Object, e As System.EventArgs) Handles btnNewNote.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtAccountNo.Text) Then
            MessageBox.Show("You must create and save the prospect details before assigning notes to prospect", _
                "Missing Prospect ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountNo.Focus()
            Exit Sub
        End If
        strNoteEntry = Nothing
        boolAbort = False
        Dim frm As New frmNoteEntry
        frm.ShowDialog()
        If boolAbort = True Then
            strNoteEntry = Nothing
        End If
        'Add the note to the table
        If Not String.IsNullOrEmpty(strNoteEntry) Then
            Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO ProspectNotes (ProspectId, Comments, Priority) " _
                & "VALUES (" & txtAccountNo.Text & ", '" & strNoteEntry & "', '" & strPublicNotePriority & "')", cnn)
            objCommand.ExecuteNonQuery()
        End If
        LoadNotes()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Prospect Notes Entry"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadNotes()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Comments, TransactionId FROM ProspectNotes " _
            & "WHERE ProspectId = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGridNotes.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGridNotes.Rows.Add(objReader(0).ToString, objReader(1).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Prospect Notes Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmProspectSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        LoadServices()
        If boolAbort = True Then Exit Sub
        LoadEmployees()
        If boolAbort = True Then Exit Sub
        If boolEditStatus = True Then
            LoadNotes()
            LoadProspectDetails()
            SelectServices()
        End If
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        'Validate data
        If String.IsNullOrEmpty(txtAccountName.Text) Then
            MessageBox.Show("Please enter the prospect name", "Missing Prospect Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAccountName.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the prospect address", "Missing Prospect Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Focus()
            Exit Sub
        End If

        Dim strSql As String = Nothing
        If boolEditStatus = False Then
            strSql = "INSERT INTO Prospects ([ContactDate], [ProspectName], [Address1], [Address2], [Address3], " _
                & "[Address4], [Telephone], [FaxNumber], [Cellphone], [EmailAddress], [ContactTitle], " _
                & "[ContactName], [ContactTelephone], [ContactCellphone], [ContactEmail], [Agent]) VALUES " _
                & "('" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', '" & txtAccountName.Text & "', " _
                & "'" & txtAddress1.Text & "', '" & txtAddress2.Text & "', '" & txtAddress3.Text & "', " _
                & "'" & txtAddress4.Text & "', '" & txtTelephone.Text & "', '" & txtFaxNumber.Text & "', " _
                & "'" & txtCellphone.Text & "', '" & txtEmailAddress.Text & "', '" & cboSalutation.Text & "', " _
                & "'" & txtContactPerson.Text & "', '" & txtContactTelephone.Text & "', '" & txtContactCellphone.Text & "', " _
                & "'" & txtContactEmailAddress.Text & "', '" & cboAgent.Text & "')"
        Else
            strSql = "UPDATE Prospects SET [ContactDate] = '" & Format(dpDateOn.Value, "dd-MMM-yyyy") & "', " _
                & "[ProspectName] = '" & txtAccountName.Text & "', [Address1] = '" & txtAddress1.Text & "', " _
                & "[Address2] = '" & txtAddress2.Text & "', [Address3] = '" & txtAddress3.Text & "', " _
                & "[Address4] = '" & txtAddress4.Text & "', [Telephone] = '" & txtTelephone.Text & "', " _
                & "[FaxNumber] = '" & txtFaxNumber.Text & "', [Cellphone] = '" & txtCellphone.Text & "', " _
                & "[EmailAddress] = '" & txtEmailAddress.Text & "', [ContactTitle] = '" & cboSalutation.Text & "', " _
                & "[ContactName] = '" & txtContactPerson.Text & "', [ContactTelephone] = '" & txtContactTelephone.Text & "', " _
                & "[ContactCellphone] = '" & txtContactCellphone.Text & "', " _
                & "[ContactEmail] = '" & txtContactEmailAddress.Text & "', Agent = '" & cboAgent.Text & "' WHERE ProspectId = " & txtAccountNo.Text & ""
        End If
        If Not String.IsNullOrEmpty(strSql) Then
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            boolAbort = False

            Dim intLastId As Integer = LastProspectId()

            If boolEditStatus = False Then
                If intLastId <= 0 Then
                    MessageBox.Show("Failed to get the last record ID for prospects", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else
                    txtAccountNo.Text = intLastId
                End If
            End If

            SaveServiceRequirements()

            If boolAbort = True Then
                'Reverse the entry completely
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM Prospects WHERE ProspectId = " & intLastId & "", cnn)
                objCommand.ExecuteReader()
                Exit Sub
            End If

            MessageBox.Show("Prospect details have been saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            boolAbort = False
            Me.Close()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Prospect Details Update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadProspectDetails()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM Prospects WHERE ProspectId = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            txtAccountNo.Text = intSelectedTransaction
            If IsDate(objReader("ContactDate").ToString) Then dpDateOn.Value = CDate(objReader("ContactDate").ToString)
            If Not IsDBNull(objReader("ProspectName").ToString) Then txtAccountName.Text = objReader("ProspectName").ToString
            If Not IsDBNull(objReader("Address1").ToString) Then txtAddress1.Text = objReader("Address1").ToString
            If Not IsDBNull(objReader("Address2").ToString) Then txtAddress2.Text = objReader("Address2").ToString
            If Not IsDBNull(objReader("Address3").ToString) Then txtAddress3.Text = objReader("Address3").ToString
            If Not IsDBNull(objReader("Address4").ToString) Then txtAddress4.Text = objReader("Address4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtTelephone.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("FaxNumber").ToString) Then txtFaxNumber.Text = objReader("FaxNumber").ToString
            If Not IsDBNull(objReader("Cellphone").ToString) Then txtCellphone.Text = objReader("Cellphone").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("ContactTitle").ToString) Then cboSalutation.Text = objReader("ContactTitle").ToString
            If Not IsDBNull(objReader("ContactName").ToString) Then txtContactPerson.Text = objReader("ContactName").ToString
            If Not IsDBNull(objReader("ContactTelephone").ToString) Then txtContactTelephone.Text = objReader("ContactTelephone").ToString
            If Not IsDBNull(objReader("ContactCellphone").ToString) Then txtContactCellphone.Text = objReader("ContactCellphone").ToString
            If Not IsDBNull(objReader("ContactEmail").ToString) Then txtContactEmailAddress.Text = objReader("ContactEmail").ToString
            If Not IsDBNull(objReader("Agent").ToString) Then cboAgent.Text = objReader("Agent").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Prospect Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadServices()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ProductName, TransactionId FROM CrmProducts ORDER BY ProductName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            With dGrid
                If Not IsDBNull(objReader(0).ToString) Then .Rows.Add(False, objReader(0).ToString, objReader(1).ToString)
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Products and Services Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub SelectServices()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT ServiceId FROM CrmProspectRequirements WHERE ProspectId = " & intSelectedTransaction & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            For p As Integer = 0 To dGrid.RowCount - 1
                If CInt(objReader(0).ToString) = CInt(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    dGrid.Rows(p).Cells(0).Value = True
                End If
            Next
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Products and Services Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub SaveServiceRequirements()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM CrmProspectRequirements WHERE ProspectId = " & txtAccountNo.Text & "", cnn)
        objCommand.ExecuteNonQuery()
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If dGrid.Rows(p).Cells(0).Value = True Then
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO CrmProspectRequirements " _
                    & "(ProspectId, ServiceId) VALUES (" & txtAccountNo.Text & ", " & dGrid.Rows(p).Cells(2).Value.ToString & ")", cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Products and Services Details Save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadEmployees()
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames " _
            & "AS [EmployeeDetails] FROM EmployeeMaster ORDER BY LastName, FirstName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        cboAgent.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboAgent.Items.Add(UCase(objReader(0).ToString))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Item Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
