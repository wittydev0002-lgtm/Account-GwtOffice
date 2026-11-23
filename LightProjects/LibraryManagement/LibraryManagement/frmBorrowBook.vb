Public Class frmBorrowBook

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        If String.IsNullOrEmpty(txtIsbn.Text) Or String.IsNullOrEmpty(lblBookTitle.Text) Then
            MessageBox.Show("Please enter the book number", "Invalid Book Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtIsbn.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboMemberDetails.Text) Or String.IsNullOrEmpty(lblMemberId.Text) Then
            MessageBox.Show("Please enter the member details", "Invalid Member Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboMemberDetails.Focus()
            Exit Sub
        End If
        If Format(dpDueDate.Value, "dd-MMM-yyyy") <= Format(Now, "dd-MMM-yyyy") Then
            MessageBox.Show("The due date cannot be today or before today", "Invalid Due Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dpDueDate.Focus()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strSql As String = "INSERT INTO [BorrowingsOut] ([MembershipId],[DateOut],[DateDue],[Isbn]) VALUES " _
            & "(" & lblMemberId.Text & ", '" & Format(dpDateOut.Value, "dd-MMM-yyyy") & "', " _
            & "'" & Format(dpDueDate.Value, "dd-MMM-yyyy") & "', '" & txtIsbn.Text & "')"

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Process completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Cursor = Cursors.Default
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Book Borrowing"
        ShowErrorMessage()
    End Sub

    Private Sub frmBorrowBook_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.F3 Then
            boolAbort = False
            Dim frm As New frmBrowseBooks
            frm.ShowDialog()
            If boolAbort = True Then
                boolAbort = False
                Exit Sub
            End If
            txtIsbn.Text = strSelectedBookNumber
            cboMemberDetails.Focus()
        End If
    End Sub

    Private Sub frmBorrowBook_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadMembers()
        dpDateOut.Value = Now
        dpDueDate.Value = DateAdd(DateInterval.Day, intBorrowingPeriod, Now)
        dpDateOut.Enabled = False : dpDueDate.Enabled = False
    End Sub

    Private Sub LoadMembers()
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT LastName +' '+ FirstName +' '+ OtherNames +';'+ CONVERT(NVARCHAR, MembershipId) " _
            & "FROM Members ORDER BY LastName, FirstName, OtherNames", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        Dim intW As Integer = cboMemberDetails.Width
        With cboMemberDetails
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .DropDownHeight = 110
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = (intW - 60) & ";60"
        End With
        'Get a count of the items
        Dim intItemsCount As Double = 0
        sqlCommand = New Data.OleDb.OleDbCommand("SELECT Count(MembershipId) FROM Members", cnn)
        Dim objCount As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        If objCount.HasRows Then
            objCount.Read()
            If IsNumeric(objCount(0).ToString) Then intItemsCount = CDbl(objCount(0).ToString)
        End If
        objCount.Close()
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboMemberDetails.Items.Clear()
        Dim i As Double = 0
        Dim p As Double = 0
        'Continue to read until you reach the end of the file.
        While objReader.Read
            'File the listview with details.
            If Not IsDBNull(objReader(0).ToString) Then
                Dim strRecordText() As String = Split(objReader(0).ToString, ";")
                DropDownItems(p) = New MTGCComboBoxItem(UCase(strRecordText(0)), UCase(strRecordText(1)))
            End If
            p = p + 1
        End While
        objReader.Close()
        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboMemberDetails.SelectedIndex = -1
            cboMemberDetails.Items.Clear()
            cboMemberDetails.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboMemberDetails.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Members Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub cboMemberDetails_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMemberDetails.SelectedIndexChanged
        On Error Resume Next
        lblMemberId.Text = ""
        lblMemberId.Text = cboMemberDetails.SelectedItem.Col2
    End Sub

    Private Sub txtIsbn_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIsbn.KeyPress
        If Asc(e.KeyChar) = 13 Then cboMemberDetails.Select()
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

    Private Sub frmBorrowBook_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 589 : Me.Height = 295
    End Sub

End Class
