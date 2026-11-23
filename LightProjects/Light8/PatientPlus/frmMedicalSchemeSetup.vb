Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMedicalSchemeSetup
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not String.IsNullOrEmpty(txtPackage.Text) Then
            If PackageExists(txtPackage.Text) = False Then
                dGrid.Rows.Add(txtPackage.Text)
                txtPackage.Clear()
                txtPackage.Select()
            End If
        End If
    End Sub

    Private Function PackageExists(ByVal PackageName As String) As Boolean
        Dim boolReturn As Boolean = False
        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    If UCase(PackageName) = UCase(dGrid.Rows(p).Cells(0).Value.ToString) Then
                        boolReturn = True
                        Exit For
                    End If
                End If
            End If
        Next
        Return boolReturn
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtCode.Text) Then
            MessageBox.Show("Please enter the medical aid registration code", "Invalid Scheme Code", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCode.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtName.Text) Then
            MessageBox.Show("Please enter the medical aid name", "Invalid Scheme Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtName.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(txtAddress1.Text) Then
            MessageBox.Show("Please enter the medical aid address", "Invalid Scheme Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAddress1.Select()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboStatus.Text) Then
            MessageBox.Show("Please enter the status of the scheme", "Invalid Scheme Status", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboStatus.Select()
            Exit Sub
        End If

        Dim strSql As String = Nothing

        If boolEditStatus = False Then
            If gwt_comm.RecordExists("RegistrationNumber", "OchmasSystemMedicalAids", txtCode.Text, "Text") = True Then
                MessageBox.Show("A medical aid scheme with a similar registration number already exists", "Duplicate Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCode.Select()
                Exit Sub
            End If
            strSql = "INSERT INTO OchmasSystemMedicalAids ([Name],[RegistrationNumber],[RegistrationDate],[SchemeType]," _
                & "[PostalAddress1],[PostalAddress2],[PostalAddress3],[PostalAddress4],[Telephone],[SwitchCode] ,[EmailAddress], [Status]) " _
                & "VALUES " _
                & "('" & txtName.Text & "', '" & txtCode.Text & "', '" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "', " _
                & "'OPEN', '" & txtAddress1.Text & "', '" & txtAddress2.Text & "', '" & txtAddress3.Text & "', '" & txtAddress4.Text & "', " _
                & "'" & txtContactNumbers.Text & "', '" & txtSwitchCode.Text & "', '" & txtEmailAddress.Text & "', '" & cboStatus.Text & "')"
        Else
            strSql = "UPDATE OchmasSystemMedicalAids SET [Name] = '" & txtName.Text & "', " _
                & "[RegistrationDate] = '" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "', [SchemeType] = 'OPEN'," _
                & "[PostalAddress1] = '" & txtAddress1.Text & "', [PostalAddress2] = '" & txtAddress2.Text & "', " _
                & "[PostalAddress3] = '" & txtAddress3.Text & "', [PostalAddress4] = '" & txtAddress4.Text & "', " _
                & "[Telephone] = '" & txtContactNumbers.Text & "', [SwitchCode] = '" & txtSwitchCode.Text & "', " _
                & "[EmailAddress] = '" & txtEmailAddress.Text & "', Status = '" & cboStatus.Text & "' WHERE [RegistrationNumber] = '" & txtCode.Text & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        'Save the Scheme packages
        strSql = "DELETE FROM OchmasSystemMedicalAidPackages"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strSql = "INSERT INTO OchmasSystemMedicalAidPackages (RegistrationNumber, Package) " _
                        & "VALUES ('" & txtCode.Text & "', '" & dGrid.Rows(p).Cells(0).Value.ToString & "')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        Next



        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()

        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On medical aid scheme details update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtPackage_TextChanged(sender As Object, e As EventArgs) Handles txtPackage.TextChanged

    End Sub

    Private Sub txtPackage_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPackage.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not String.IsNullOrEmpty(txtPackage.Text) Then
                If PackageExists(txtPackage.Text) = False Then
                    dGrid.Rows.Add(txtPackage.Text)
                    txtPackage.Clear()
                    txtPackage.Select()
                End If
            End If
        End If
    End Sub

    Private Sub dGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGrid.CellClick
        If e.ColumnIndex = 1 Then
            On Error GoTo RaiseErr
            If boolEditStatus = True Then
                Dim strPackage As String = Nothing
                If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                        strPackage = dGrid.CurrentRow.Cells(0).Value.ToString
                        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM OchmasSystemMedicalAidPackages " _
                            & "WHERE Package = '" & strPackage & "' AND RegistrationNumber = '" & txtCode.Text & "'", cnn)
                        objCommand.ExecuteNonQuery()
                        LoadPackages()
                    End If
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Scheme package delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadPackages()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Package FROM OchmasSystemMedicalAidPackages " _
            & "WHERE RegistrationNumber = '" & txtCode.Text & "' ORDER BY Package", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Scheme packages load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        txtCode.Enabled = False

        'Dim strsql As String = "SET [Name] = '" & txtName.Text & "', " _
        '        & "[RegistrationDate] = '" & Format(dpStartDate.Value, "dd-MMM-yyyy") & "', [SchemeType] = 'OPEN'," _
        '        & "[PostalAddress1] = '" & txtAddress1.Text & "', [PostalAddress2] = '" & txtAddress2.Text & "', " _
        '        & "[PostalAddress3] = '" & txtAddress3.Text & "', [PostalAddress4] = '" & txtAddress4.Text & "', " _
        '        & "[Telephone] = '" & txtContactNumbers.Text & "', [SwitchCode] = '" & txtSwitchCode.Text & "', " _
        '        & "[EmailAddress] = '" & txtEmailAddress.Text & "', Status = '" & cboStatus.Text & "' WHERE [RegistrationNumber] = '" & txtCode.Text & "'"

        Dim objCommand As New Data.OleDb.OleDbCommand("Select * FROM [OchmasSystemMedicalAids] WHERE RegistrationNumber = '" & strSelectedMedicalScheme & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("Name").ToString) Then txtName.Text = objReader("Name").ToString
            If IsDate(objReader("RegistrationDate").ToString) Then dpStartDate.Value = CDate(objReader("RegistrationDate").ToString)
            'If Not IsDBNull(objReader("SchemeType").ToString) Then txt.text = objReader("SchemeType").ToString
            If Not IsDBNull(objReader("PostalAddress1").ToString) Then txtAddress1.Text = objReader("PostalAddress1").ToString
            If Not IsDBNull(objReader("PostalAddress2").ToString) Then txtAddress2.Text = objReader("PostalAddress2").ToString
            If Not IsDBNull(objReader("PostalAddress3").ToString) Then txtAddress3.Text = objReader("PostalAddress3").ToString
            If Not IsDBNull(objReader("PostalAddress4").ToString) Then txtAddress4.Text = objReader("PostalAddress4").ToString
            If Not IsDBNull(objReader("Telephone").ToString) Then txtContactNumbers.Text = objReader("Telephone").ToString
            If Not IsDBNull(objReader("SwitchCode").ToString) Then txtSwitchCode.Text = objReader("SwitchCode").ToString
            If Not IsDBNull(objReader("EmailAddress").ToString) Then txtEmailAddress.Text = objReader("EmailAddress").ToString
            If Not IsDBNull(objReader("RegistrationNumber").ToString) Then txtCode.Text = objReader("RegistrationNumber").ToString
            If Not IsDBNull(objReader("Status").ToString) Then cboStatus.Text = objReader("Status").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Scheme Data load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmMedicalSchemeSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If boolEditStatus = True Then
            LoadData()
            LoadPackages()
        End If
    End Sub

End Class