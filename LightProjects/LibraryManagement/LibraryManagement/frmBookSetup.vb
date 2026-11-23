Public Class frmBookSetup

    Dim boolFormLoading As Boolean

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtIsbn.Text) Then
            MessageBox.Show("Please enter the ISBN (Internation Standard Book Number)", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtIsbn.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtTitle.Text) Then
            MessageBox.Show("Please enter the book title", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtTitle.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtAuthor.Text) Then
            MessageBox.Show("Please enter the author name", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtAuthor.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtEdition.Text) Then
            MessageBox.Show("Please enter the book edition", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtEdition.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtYearPublished.Text) Then
            MessageBox.Show("Please enter the year first published", "Missing Key Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtYearPublished.Focus()
            Exit Sub
        End If

        Dim strSql As String = Nothing

        txtRemarks.Text = Replace(txtRemarks.Text, "'", "", 1)
        txtTitle.Text = Replace(txtTitle.Text, "'", "", 1)
        txtAuthor.Text = Replace(txtAuthor.Text, "'", "", 1)

        If boolEditStatus = False Then
            strSql = "INSERT INTO [Books] ([ISBN],[Title],[Author],[Category],[Publisher],[YearPublished],[Edition],[Remarks]) " _
                & "VALUES ('" & txtIsbn.Text & "', '" & txtTitle.Text & "', '" & txtAuthor.Text & "', " _
                & "'" & cboCategory.Text & "', '" & txtPublisher.Text & "', " _
                & "" & txtYearPublished.Text & ", " & txtEdition.Text & ", '" & txtRemarks.Text & "')"
        Else
            strSql = "UPDATE [Books] SET [Title] = '" & txtTitle.Text & "', " _
                & "[Author] = '" & txtAuthor.Text & "', " _
                & "[Category] = '" & cboCategory.Text & "', [Publisher] = '" & txtPublisher.Text & "', " _
                & "[YearPublished] = " & txtYearPublished.Text & ", [Edition] = " & txtEdition.Text & ", " _
                & "[Remarks] =  '" & txtRemarks.Text & "' WHERE [ISBN] = '" & txtIsbn.Text & "'"
        End If
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Books Information Capture"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT * FROM Books WHERE Isbn = '" & strSelectedBookNumber & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader("Isbn").ToString) Then txtIsbn.Text = objReader("Isbn").ToString
            If Not IsDBNull(objReader("Title").ToString) Then txtTitle.Text = objReader("Title").ToString
            If Not IsDBNull(objReader("Author").ToString) Then txtAuthor.Text = objReader("Author").ToString
            If Not IsDBNull(objReader("Category").ToString) Then cboCategory.Text = objReader("Category").ToString
            If Not IsDBNull(objReader("Publisher").ToString) Then txtPublisher.Text = objReader("Publisher").ToString
            If Not IsDBNull(objReader("YearPublished").ToString) Then txtYearPublished.Text = objReader("YearPublished").ToString
            If Not IsDBNull(objReader("Edition").ToString) Then txtEdition.Text = objReader("Edition").ToString
            If Not IsDBNull(objReader("Remarks").ToString) Then txtRemarks.Text = objReader("Remarks").ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Books Information Load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadCategories()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Category FROM Categories ORDER BY Category", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        cboCategory.Items.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then cboCategory.Items.Add(objReader(0).ToString)
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Books Information Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmBookSetup_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        boolFormLoading = True
        LoadCategories()
        If boolEditStatus = True Then
            LoadData()
            txtIsbn.Enabled = False
        End If
        boolFormLoading = False
    End Sub

    Private Sub txtIsbn_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIsbn.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtTitle.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtYearPublished_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtYearPublished.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            txtEdition.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtEdition_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEdition.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then
            cboCategory.Focus()
            Exit Sub
        End If
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtTitle_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTitle.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtAuthor.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtAuthor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAuthor.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPublisher.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtPublisher_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPublisher.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtYearPublished.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
        If boolFormLoading = True Then Exit Sub
        txtRemarks.Focus()
    End Sub

    Private Sub btnAddCategory_Click(sender As System.Object, e As System.EventArgs) Handles btnAddCategory.Click
        Dim frm As New frmCategorySetup
        frm.ShowDialog()
        LoadCategories()
    End Sub

End Class
