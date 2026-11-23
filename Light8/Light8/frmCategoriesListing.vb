Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmCategoriesListing

    Dim _heightUpDown As Integer
    Dim _widthLeftRight As Integer
    Dim _originalLeftWidth As Integer
    Dim _originalSplitterDistance As Integer
    Dim strNavigateDirection As String = Nothing

    Private Sub grd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.Click
        If grd.Rows.Count > 0 Then
            'txtRecordIndex.Text = CStr(grd.CurrentRow.Index + 1) & " of " & grd.Rows.Count
            DisplayData(grd.CurrentRow.Cells(1).Value.ToString)
        End If
    End Sub

    Private Sub grd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.DoubleClick
        If IntPublicCategoriesSetup <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If grd.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedDetails()
            Dim f As New frmCategorySetup
            f.ShowDialog()
            LoadFormData()
        End If
    End Sub

    Private Sub DisplayData(ByVal varNumber As String)
        On Error GoTo RaiseErr
        'Get the employee data and display on the datagrid by the side
        Dim rand As Random = New Random()
        'Dim foreColor As Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256))
        'Dim backColor As Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256))

        Dim backColor As Color = Color.FromArgb(255, 255, 255)
        Dim foreColor As Color = Color.FromArgb(255, 128, 40)

        Dim objCmd As New Data.OleDb.OleDbCommand("SELECT SubCategory FROM SubCategories WHERE Category = '" & varNumber & "' ORDER BY SubCategory", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmd.ExecuteReader
        dgrdDetails.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dgrdDetails.Rows.Add(1)
                dgrdDetails.Rows(dgrdDetails.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Information Quick View"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If IntPublicCategoriesSetup <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        boolEditStatus = False
        Dim f As New frmCategorySetup
        f.ShowDialog()
        LoadFormData()
    End Sub

    Private Sub frmCategoriesListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        boolRunningForDisplay = True
        LoadFormData()
        boolRunningForDisplay = False
        _originalLeftWidth = kryptonSplitContainerHorizontal.Panel1.Width
    End Sub

    Sub LoadFormData()
        On Error GoTo RaiseErr
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT TransactionId, " _
            & "Category FROM Categories ORDER BY Category", cnn)
        'Pass the file path and the file name to the StreamReader constructor.
        objReader = sqlCommand.ExecuteReader
        grd.Rows.Clear()
        'set the number of rows
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Or Not IsDBNull(objReader(1).ToString) Then
                grd.Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then grd.Rows(grd.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then grd.Rows(grd.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            End If
        End While
        AlternateColors()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Categories Load error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 0 To grd.Rows.Count - 1 Step 2
            For j As Integer = 0 To grd.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                grd.Rows(i).Cells(j).Style.BackColor = backColor
                grd.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadFormData()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If IntPublicCategoriesSetup <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If grd.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedDetails()
            Dim f As New frmCategorySetup
            f.ShowDialog()
            LoadFormData()
        End If
    End Sub

    Private Sub GetSelectedDetails()
        Dim CurrentCellValue As String
        CurrentCellValue = grd.CurrentRow.Cells(0).Value
        intSelectedCategoryId = CurrentCellValue
        CurrentCellValue = grd.CurrentRow.Cells(1).Value
        strSelectedCategory = CurrentCellValue
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If IntPublicCategoriesSetup <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        On Error GoTo RaiseErr
        If grd.Rows.Count > 0 Then
            Dim CurrentCellValue As String
            CurrentCellValue = grd.CurrentRow.Cells(0).Value
            intSelectedCategoryId = CurrentCellValue
            CurrentCellValue = grd.CurrentRow.Cells(1).Value
            strSelectedCategory = CurrentCellValue
            If MessageBox.Show("Are you sure you want to delete this category and all it sub categories?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM Categories WHERE Category = '" & strSelectedCategory & "'", cnn)
                objCommand.ExecuteNonQuery()
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SubCategories WHERE Category = '" & strSelectedCategory & "'", cnn)
                objCommand.ExecuteNonQuery()
                LoadFormData()
                MessageBox.Show("Category deleted successfully", "Category Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Record Delete Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrintSelected_Click(sender As Object, e As EventArgs) Handles btnPrintSelected.Click
        If IntPublicCategoriesSetup <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If grd.Rows.Count <= 0 Then Exit Sub
        Dim strPrintCategory As String = Nothing
        If Not Object.Equals(Convert.ToString(grd.CurrentRow.Cells(1).Value), "") Then
            strPrintCategory = grd.CurrentRow.Cells(1).Value.ToString
        End If
        If Not String.IsNullOrEmpty(strPrintCategory) Then
            GenerateReportXml("SELECTIVE", strPrintCategory)
        End If
    End Sub

    Private Sub GenerateReportXml(PrintType As String, PrintCategory As String)
        On Error GoTo RaiseErr

        Dim arrDetails As New ArrayList
        Dim strColumn(0 To 4) As String

        Dim strSql As String = Nothing

        If PrintType = "ALL" Then
            strSql = "SELECT Category, SubCategory FROM SubCategories ORDER BY Category"
        Else
            If Not String.IsNullOrEmpty(PrintCategory) Then
                strSql = "SELECT Category, SubCategory FROM SubCategories WHERE Category = '" & PrintCategory & "' ORDER BY Category"
            Else
                MessageBox.Show("No category has been selected", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim strKey As String = Nothing

        While objReader.Read
            If UCase(objReader(0).ToString) <> UCase(strKey) Then
                strColumn(0) = UCase(objReader(0).ToString) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
                strKey = UCase(objReader(0).ToString)
            Else
                strColumn(0) = " |FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0</d>"
            End If
            strColumn(1) = UCase(objReader(1).ToString) & "|FN=Arial;FS=6;FC=Black;FB=False;FI=False;FU=False;BC=White;RH=20;AL=0"
            arrDetails.Add(strColumn(0) & strColumn(1))
        End While
        objReader.Close()

        'Send the print details to the reporting class

        Dim strPrintDetails(0 To (arrDetails.Count - 1)) As String
        For i As Integer = 0 To strPrintDetails.Length - 1
            strPrintDetails(i) = arrDetails.Item(i)
        Next

        If arrDetails.Count = 0 Then
            MessageBox.Show("No details to print were obtained from the system", "Printing Aborted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = 2
            .strColumnHeaders = "CATEGORY|SUB-CATEGORIES"
            .strColumnWidths = "150|300"
            .strFooterCaption = UCase("Inventory Categories Printed by " & strUserName)
            .strMainCaption = UCase(strCompanyName)
            .strMainHeader2 = "INVENTORY CATEGORIES AND SUB CATEGORIE"
            .strMainHeader3 = ""
            .strColumnTotals = "NO|NO"
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DetailColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.WhiteSmoke
            .BorderColor = Color.FromName("LightGray")
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .boolGroupDetails = False
            .boolPrintTotals = False
            .intBreakIndex = 0
            .RestartPageNumbersOnGroupChange = False
            .NewPageBreak = False
            .boolGenericReport = False
            .boolPrintRecordCount = False
            .PrintSummary = False
            .VisibleColumns = "YES|YES"
            .strColumnFormating = "NO|NO"
            .strSummaryTotals = "NO|NO"
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
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Printing Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrintAll_Click(sender As Object, e As EventArgs) Handles btnPrintAll.Click
        If IntPublicCategoriesSetup <> 2 Then
            gwt_comm.DenyAccess()
            Exit Sub
        End If
        If grd.Rows.Count <= 0 Then Exit Sub
        Dim strPrintCategory As String = "NONE"
        If Not String.IsNullOrEmpty(strPrintCategory) Then
            GenerateReportXml("ALL", strPrintCategory)
        End If
    End Sub

    Private Sub ExpandablePanel1_ExpandedChanged(sender As Object, e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles expandablePanel1.ExpandedChanged
        kryptonSplitContainerHorizontal.SuspendLayout()

        'Is the left header group currently expanded?
        If (kryptonSplitContainerHorizontal.FixedPanel = FixedPanel.None) Then

            'Make the right panel of the splitter fixed in size
            kryptonSplitContainerHorizontal.FixedPanel = FixedPanel.Panel2
            kryptonSplitContainerHorizontal.IsSplitterFixed = True

            ' Remember the current height of the header group
            _widthLeftRight = ExpandablePanel1.Width

            ' We have not changed the orientation of the header yet, so the width of 
            ' the splitter panel is going to be the height of the collapsed header group
            Dim newWidth As Integer = 25 'kryptonHeaderGroupLeft.PreferredSize.Width

            ' Make the header group fixed just as the new height
            _originalSplitterDistance = kryptonSplitContainerHorizontal.SplitterDistance
            kryptonSplitContainerHorizontal.SplitterDistance = kryptonSplitContainerHorizontal.SplitterDistance + (_widthLeftRight - 32) 'newWidth)
            kryptonSplitContainerHorizontal.Panel2MinSize = newWidth
        Else
            ' Make the bottom panel not-fixed in size anymore
            kryptonSplitContainerHorizontal.FixedPanel = FixedPanel.None
            kryptonSplitContainerHorizontal.IsSplitterFixed = False

            ' Calculate the correct splitter we want to put back
            kryptonSplitContainerHorizontal.SplitterDistance = _originalSplitterDistance

        End If
        kryptonSplitContainerHorizontal.ResumeLayout()
    End Sub

End Class