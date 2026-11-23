Public Class frmLoginBooks

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtIsbn_Validated(sender As Object, e As System.EventArgs) Handles txtIsbn.Validated
        On Error GoTo RaiseErr
        lblBookTitle.Text = Nothing
        If String.IsNullOrEmpty(txtIsbn.Text) Then Exit Sub
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Title FROM Books WHERE Isbn = '" & txtIsbn.Text & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then lblBookTitle.Text = objReader(0).ToString
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on book title details fetch"
        ShowErrorMessage()
    End Sub

    Private Sub txtIsbn_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIsbn.KeyPress
        If Asc(e.KeyChar) = 13 Then dpDateIn.Select()
    End Sub

    Private Sub frmLoginBooks_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        On Error GoTo RaiseErr
        If e.KeyValue = Keys.F3 Then
            boolAbort = False
            Dim frm As New frmBrowseBooks
            frm.ShowDialog()
            If boolAbort = True Then
                boolAbort = False
                Exit Sub
            End If
            txtIsbn.Text = strSelectedBookNumber
            'Get the last member details
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT BorrowingsOut.MembershipId, " _
                & "Members.LastName +' '+ Members.FirstName +' '+ Members.OtherNames AS [MemberNames] FROM " _
                & "BorrowingsOut LEFT OUTER JOIN Members ON BorrowingsOut.MembershipId = Members.MembershipId " _
                & "WHERE BorrowingsOut.MembershipId NOT IN (SELECT BorrowingsIn.MembershipId FROM BorrowingsIn " _
                & "WHERE BorrowingsIn.Isbn = '" & strSelectedBookNumber & "')", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                objReader.Read()
                If Not IsDBNull(objReader(0).ToString) Then lblMemberId.Text = UCase(objReader(0).ToString)
                If Not IsDBNull(objReader(1).ToString) Then lblMemberDetails.Text = UCase(objReader(1).ToString)
            End If
            objReader.Close()
            Cursor = Cursors.Default
            dpDateIn.Focus()
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Book Login"
        ShowErrorMessage()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(txtIsbn.Text) Or String.IsNullOrEmpty(lblBookTitle.Text) Then
            MessageBox.Show("Please enter the book number", "Invalid Book Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtIsbn.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblMemberDetails.Text) Or String.IsNullOrEmpty(lblMemberId.Text) Then
            MessageBox.Show("It seems that this book is not issued out. Please check and correct", "Possible Data Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strSql As String = "INSERT INTO [BorrowingsIn] ([MembershipId],[DateIn],[Isbn]) VALUES " _
            & "(" & lblMemberId.Text & ", '" & Format(dpDateIn.Value, "dd-MMM-yyyy") & "', '" & txtIsbn.Text & "')"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Book Login"
        ShowErrorMessage()
    End Sub

End Class
