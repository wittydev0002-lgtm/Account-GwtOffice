Public Class frmMainOne

    Dim boolFormLoading As Boolean

    Private Sub frmMainOne_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolAbort = False
        boolFormLoading = True
        Dim frm As New frmSplash
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub
        LoadMembers()
        LoadBooks()
        LoadDueBooks("--ALL--")
        'Initiaise the sales forms
        cboSearchBy.SelectedIndex = 1
        'comboBoxEx1.Items.AddRange(New Object() {eStyle.Office2013, eStyle.OfficeMobile2014, eStyle.Office2010Blue, eStyle.Office2010Silver, eStyle.Office2010Black, eStyle.VisualStudio2010Blue, eStyle.VisualStudio2012Light, eStyle.VisualStudio2012Dark, eStyle.Office2007Blue, eStyle.Office2007Silver, eStyle.Office2007Black})
        'comboBoxEx1.SelectedIndex = 0
        sideNav1.TabIndex = 0
        boolFormLoading = False
    End Sub

    Private Sub LoadMembers()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT MembershipId as [Member #], LastName AS [Last Name], FirstName as [First Name], " _
            & "OtherNames as [Other Names], Gender, Status, School FROM Members ORDER BY LastName, FirstName, OtherNames"
        dGrid.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        For i As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        lblTotalRecords.Text = dGrid.Rows.Count
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Errors encounted while trying to update member information"
        ShowErrorMessage()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmMembers
        frm.ShowDialog()
        LoadMembers()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As System.EventArgs) Handles btnEdit.Click
        If dGrid.Rows.Count <= 0 Then Exit Sub
        boolEditStatus = True
        GetSelectedMember()
        Dim frm As New frmMembers
        frm.ShowDialog()
        LoadMembers()
    End Sub

    Private Sub GetSelectedMember()
        If dGrid.Rows.Count > 0 Then
            intSelectedRecord = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.Rows.Count <= 0 Then Exit Sub
        boolEditStatus = True
        GetSelectedMember()
        Dim frm As New frmMembers
        frm.ShowDialog()
        LoadMembers()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadMembers()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        'MsgBox(Asc(e.KeyChar))
        If Asc(e.KeyChar) = 8 Then
            SearchForItem("")
        Else
            SearchForItem(e.KeyChar)
        End If
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        If boolFormLoading = True Then Exit Sub
        On Error GoTo RaiseErr
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        Cursor = Cursors.WaitCursor

        dGrid.Columns.Clear()

        Dim strSql As String = Nothing
        dGrid.DataSource = Nothing

        Select Case cboSearchBy.SelectedIndex
            Case Is = 0
                strSql = "SELECT MembershipId as [Member #], LastName AS [Last Name], FirstName as [First Name], " _
                    & "OtherNames as [Other Names], Gender, Status, School FROM Members WHERE LastName LIKE '%" & strFind & "%' " _
                    & "ORDER BY LastName, FirstName, OtherNames"
            Case Is = 1
                strSql = "SELECT MembershipId as [Member #], LastName AS [Last Name], FirstName as [First Name], " _
                      & "OtherNames as [Other Names], Gender, Status, School FROM Members WHERE FirstName LIKE '%" & strFind & "%' " _
                      & "ORDER BY FirstName, LastName, OtherNames"
            Case Else
                strSql = "SELECT MembershipId as [Member #], LastName AS [Last Name], FirstName as [First Name], " _
                      & "OtherNames as [Other Names], Gender, Status, School FROM Members WHERE LastName LIKE '%" & strFind & "%' " _
                      & "ORDER BY LastName, FirstName, OtherNames"
        End Select

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        lblTotalRecords.Text = dGrid.Rows.Count

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Members Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT LastName as [Last Name], FirstName as [First Name], OtherNames AS [Other Names], " _
                    & "School, ParentName AS [Parent/Guardian], ParentTelephone AS [Contact No.] " _
                    & "FROM Members ORDER BY LastName, FirstName, OtherNames", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        'Assign the values to the print array
        Dim arrPrintData As New ArrayList
        While objReader.Read
            Dim strDataRow As String = Nothing
            For i As Integer = 0 To objReader.FieldCount - 1
                strDataRow = strDataRow & objReader(i).ToString & ";"
            Next
            strDataRow = Mid(strDataRow, 1, (strDataRow.Length - 1))
            arrPrintData.Add(strDataRow)
        End While
        objReader.Close()

        'Add the details to the print class print array

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "LAST NAME|FIRST NAME|OTHER NAMES|SCHOOL|PARENT/GUARDIAN|TELEPHONE"
            .strColumnAlignments = "0|0|0|0|0|0"
            .strColumnWidths = "100|100|80|130|130|80"
            .strFooterCaption = "Members Listing Report"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "MEMBERS LISTING REPORT"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Members Report Print"
        ShowErrorMessage()
    End Sub

    Private Sub txtSearchString_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearchString.KeyDown
        If e.KeyValue = Keys.Down Then
            If Not String.IsNullOrEmpty(txtSearchString.Text) Then
                dGrid.Focus()
            Else
                SearchForItem("")
            End If
        End If
    End Sub

    Private Sub btnNewDispense_Click(sender As Object, e As EventArgs) Handles btnNewDispense.Click
        boolEditStatus = False
        Dim frm As New frmBookSetup
        frm.ShowDialog()
        LoadBooks()
    End Sub

    Private Sub LoadBooks()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "SELECT Isbn, Title, Author, Publisher, YearPublished AS [Pub. Year], Edition FROM Books ORDER BY Title"

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGridBooks.Columns.Clear()

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridBooks.DataSource = dTable

        For i As Integer = 0 To dGridBooks.Columns.Count - 1
            dGridBooks.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Books Listing  Load"
        ShowErrorMessage()
    End Sub

    Private Sub SearchForBook(ByVal strCurrentKey As String)
        If boolFormLoading = True Then Exit Sub
        On Error GoTo RaiseErr

        Dim strFind As String = txtSearchBookString.Text & strCurrentKey
        Cursor = Cursors.WaitCursor

        dGridBooks.Columns.Clear()

        Dim strSql As String = Nothing
        dGrid.DataSource = Nothing

        Select Case UCase(cboSearchBookBy.Text)
            Case Is = "AUTHOR"
                strSql = "SELECT Isbn, Title, Author, Publisher, YearPublished AS [Pub. Year], Edition FROM Books " _
                    & "WHERE Author LIKE '%" & strFind & "%' ORDER BY Author, Title, YearPublished, Edition"
            Case Is = "TITLE"
                strSql = "SELECT Isbn, Title, Author, Publisher, YearPublished AS [Pub. Year], Edition FROM Books " _
                    & "WHERE Title LIKE '%" & strFind & "%' ORDER BY Title, Author, YearPublished, Edition"
            Case Else
                strSql = "SELECT Isbn, Title, Author, Publisher, YearPublished AS [Pub. Year], Edition FROM Books " _
                    & "WHERE Title LIKE '%" & strFind & "%' ORDER BY Title, Author, YearPublished, Edition"
        End Select

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridBooks.DataSource = dTable

        For i As Integer = 0 To dGridBooks.Columns.Count - 1
            dGridBooks.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Book Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub txtSearchBookString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchBookString.KeyPress
        SearchForBook(e.KeyChar)
    End Sub

    Private Sub btnCategories_Click(sender As System.Object, e As System.EventArgs) Handles btnCategories.Click
        Dim frm As New frmCategorySetup
        frm.ShowDialog()
    End Sub

    Private Sub EditBook()
        boolEditStatus = True
        strSelectedBookNumber = dGridBooks.CurrentRow.Cells(0).Value.ToString
        Dim frm As New frmBookSetup
        frm.ShowDialog()
        LoadBooks()
    End Sub

    Private Sub btnEditDispense_Click(sender As Object, e As System.EventArgs) Handles btnEditDispense.Click
        If dGridBooks.Rows.Count > 0 Then
            EditBook()
        End If
    End Sub

    Private Sub dGridBooks_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridBooks.DoubleClick
        If dGridBooks.Rows.Count > 0 Then
            EditBook()
        End If
    End Sub

    Private Sub btnDeleteDispense_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteDispense.Click
        If dGridBooks.Rows.Count <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        strSelectedBookNumber = dGridBooks.CurrentRow.Cells(0).Value.ToString
        If MessageBox.Show("Are you sure you want to delete this book record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM Books WHERE Isbn = '" & strSelectedBookNumber & "'", cnn)
            objCommand.ExecuteNonQuery()
            MessageBox.Show("Book record has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadBooks()
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Book Information Delete"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnRefreshDispense_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshDispense.Click
        LoadBooks()
    End Sub

    Private Sub btnPrintDispense_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintDispense.Click
        On Error GoTo RaiseErr
        'Isbn, Title, Author, Publisher, YearPublished AS [Pub. Year], Edition 
        Dim arrPrintData As New ArrayList
        For p As Integer = 0 To dGridBooks.Rows.Count - 1
            Dim strDataRow As String = Nothing
            For i As Integer = 0 To dGridBooks.Columns.Count - 1
                strDataRow = strDataRow & dGridBooks.Rows(p).Cells(i).Value.ToString & ";"
            Next
            strDataRow = Mid(strDataRow, 1, (strDataRow.Length - 1))
            arrPrintData.Add(strDataRow)
        Next

        'Add the details to the print class print array

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 6
            .strColumnHeaders = "ISBN|TITLE|AUTHOR|PUBLISHER|YEAR|ED"
            .strColumnAlignments = "0|0|0|0|0|0"
            .strColumnWidths = "80|200|140|140|40|20"
            .strFooterCaption = "Book Listing Report"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "BOOKS LISTING REPORT"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Books Report Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnOrganisation_Click(sender As System.Object, e As System.EventArgs) Handles btnOrganisation.Click
        Dim frm As New frmOrganisation
        frm.ShowDialog()
    End Sub

    Private Sub btnLogout_Click(sender As System.Object, e As System.EventArgs) Handles btnLogout.Click
        Dim frm As New frmBorrowBook
        frm.ShowDialog()
    End Sub

    Private Sub LoadDueBooks(strFilter As String)
        If boolFormLoading = True Then Exit Sub
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strSql As String = Nothing
        Select Case UCase(strFilter)
            Case Is = "--ALL--"
                strSql = "SELECT Members.LastName +' '+ Members.FirstName +' '+ Members.OtherNames AS [Member], " _
                    & "BorrowingsOut.Isbn AS [ISBN], Books.Title AS [Title], Books.Author AS [Author], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), BorrowingsOut.DateOut, 106), ' ', '-')) AS [Date Out], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), BorrowingsOut.DateDue, 106), ' ', '-')) AS [Date Due], " _
                    & "DATEDIFF (d, BorrowingsOut.DateDue, getdate()) AS [Over Due] FROM BorrowingsOut " _
                    & "LEFT OUTER JOIN Members ON BorrowingsOut.MembershipId = Members.MembershipId " _
                    & "LEFT OUTER JOIN Books ON BorrowingsOut.Isbn = Books.ISBN " _
                    & "WHERE BorrowingsOut.Isbn NOT IN (SELECT BorrowingsIn.Isbn FROM BorrowingsIn)"
            Case Is = "OVER DUE"
                strSql = "SELECT Members.LastName +' '+ Members.FirstName +' '+ Members.OtherNames AS [Member], " _
                    & "BorrowingsOut.Isbn AS [ISBN], Books.Title AS [Title], Books.Author AS [Author], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), BorrowingsOut.DateOut, 106), ' ', '-')) AS [Date Out], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), BorrowingsOut.DateDue, 106), ' ', '-')) AS [Date Due], " _
                    & "DATEDIFF (d, BorrowingsOut.DateDue, getdate()) AS [Over Due] FROM BorrowingsOut " _
                    & "LEFT OUTER JOIN Members ON BorrowingsOut.MembershipId = Members.MembershipId " _
                    & "LEFT OUTER JOIN Books ON BorrowingsOut.Isbn = Books.ISBN WHERE DATEDIFF (d, BorrowingsOut.DateDue, getdate()) > 0 " _
                    & "AND BorrowingsOut.Isbn NOT IN (SELECT BorrowingsIn.Isbn FROM BorrowingsIn)"
            Case Is = "DUE TODAY"
                strSql = "SELECT Members.LastName +' '+ Members.FirstName +' '+ Members.OtherNames AS [Member], " _
                    & "BorrowingsOut.Isbn AS [ISBN], Books.Title AS [Title], Books.Author AS [Author], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), BorrowingsOut.DateOut, 106), ' ', '-')) AS [Date Out], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), BorrowingsOut.DateDue, 106), ' ', '-')) AS [Date Due], " _
                    & "DATEDIFF (d, BorrowingsOut.DateDue, getdate()) AS [Over Due] FROM BorrowingsOut " _
                    & "LEFT OUTER JOIN Members ON BorrowingsOut.MembershipId = Members.MembershipId " _
                    & "LEFT OUTER JOIN Books ON BorrowingsOut.Isbn = Books.ISBN WHERE DATEDIFF (d, BorrowingsOut.DateDue, getdate()) = 0 " _
                    & "AND BorrowingsOut.Isbn NOT IN (SELECT BorrowingsIn.Isbn FROM BorrowingsIn)"
            Case Else
                strSql = "SELECT Members.LastName +' '+ Members.FirstName +' '+ Members.OtherNames AS [Member], " _
                    & "BorrowingsOut.Isbn AS [ISBN], Books.Title AS [Title], Books.Author AS [Author], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), BorrowingsOut.DateOut, 106), ' ', '-')) AS [Date Out], " _
                    & "UPPER(REPLACE(CONVERT(CHAR(11), BorrowingsOut.DateDue, 106), ' ', '-')) AS [Date Due], " _
                    & "DATEDIFF (d, BorrowingsOut.DateDue, getdate()) AS [Over Due] FROM BorrowingsOut " _
                    & "LEFT OUTER JOIN Members ON BorrowingsOut.MembershipId = Members.MembershipId " _
                    & "LEFT OUTER JOIN Books ON BorrowingsOut.Isbn = Books.ISBN " _
                    & "AND BorrowingsOut.Isbn NOT IN (SELECT BorrowingsIn.Isbn FROM BorrowingsIn)"
        End Select

        dGridDueBooks.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridDueBooks.DataSource = dTable

        For i As Integer = 0 To dGridDueBooks.Columns.Count - 1
            dGridDueBooks.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On due books details listing"
        ShowErrorMessage()
    End Sub

    Private Sub cboDueBooksFilter_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDueBooksFilter.SelectedIndexChanged
        LoadDueBooks(UCase(cboDueBooksFilter.Text))
    End Sub

    Private Sub btnPrintLog_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintLog.Click
        On Error GoTo RaiseErr
        'Isbn, Title, Author, Publisher, YearPublished AS [Pub. Year], Edition 
        Dim arrPrintData As New ArrayList
        For p As Integer = 0 To dGridDueBooks.Rows.Count - 1
            Dim strDataRow As String = Nothing
            For i As Integer = 0 To dGridDueBooks.Columns.Count - 1
                strDataRow = strDataRow & dGridDueBooks.Rows(p).Cells(i).Value.ToString & ";"
            Next
            strDataRow = Mid(strDataRow, 1, (strDataRow.Length - 1))
            arrPrintData.Add(strDataRow)
        Next

        'Add the details to the print class print array

        Dim strPrintDetails(0 To (arrPrintData.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrPrintData.Item(i)
        Next
        Dim rpt As New SmartColumnReportWriter.SmartColumnReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 7
            .strColumnHeaders = "MEMBER|ISBN|TITLE|AUTHOR|DATE OUT|DATE DUE|DYS DUE"
            .strColumnAlignments = "0|0|0|0|0|0|2"
            .strColumnWidths = "120|78|140|120|71|71|55"
            .strFooterCaption = "Overdue Books Listing Report"
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "OVER DUE BOOKS LISTING REPORT"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO|NO|NO|NO|NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("WhiteSmoke")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = True
            .boolGenericReport = False
            .boolPrintRecordCount = True
            .PrintSummary = False
            .VisibleColumns = "YES|YES|YES|YES|YES|YES|YES"
            .strColumnFormating = "NO|NO|NO|NO|NO|NO|NO"
            .strSummaryTotals = "NO|NO|NO|NO|NO|NO|NO"
            .intKeyFieldIndex = 0
            .strPrintValues = strPrintDetails
        End With
        Dim prnt As New PrintDialog
        prnt.ShowDialog()
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Overdue Books Report Print"
        ShowErrorMessage()
    End Sub

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        Dim frm As New frmLoginBooks
        frm.ShowDialog()
    End Sub

    Private Sub btnRefreshLog_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshLog.Click
        LoadDueBooks(UCase(cboDueBooksFilter.Text))
    End Sub

    Private Sub btnPrinters_Click(sender As System.Object, e As System.EventArgs) Handles btnPrinters.Click
        Dim f As New frmPrinterSetup
        f.ShowDialog()
    End Sub

    Private Sub btnBackupPath_Click(sender As System.Object, e As System.EventArgs) Handles btnBackupPath.Click
        Dim f As New frmServerPath
        f.ShowDialog()
    End Sub

    Private Sub btnProfileChange_Click(sender As System.Object, e As System.EventArgs) Handles btnProfileChange.Click
        Dim f As New frmPasswordChange
        f.ShowDialog()
    End Sub

    Private Sub btnSystemUsers_Click(sender As System.Object, e As System.EventArgs) Handles btnSystemUsers.Click
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
            Dim f As New frmUsersListing
            f.ShowDialog()
        Else
            MessageBox.Show("You do not have enough rights to access this module. Process aborted", _
                "Access Violation", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
    End Sub

End Class
