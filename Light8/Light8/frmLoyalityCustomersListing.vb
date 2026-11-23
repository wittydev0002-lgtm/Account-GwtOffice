Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoyalityCustomersListing

    Dim strNavigateDirection As String = Nothing
    Dim boolHeaderClicked As Boolean = False

    Private Sub btnCloseTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim f As New frmLoyalityCustomers
        f.ShowDialog()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        strSql = "SELECT AccountNumber as [Account Number], LastName as [Surname], FirstName as [Name], " _
                    & "OtherNames AS [Other Names], ContactNumber AS [Contact Number], Category FROM " _
                    & "LoyalityCustomers ORDER BY LastName, FirstName, OtherNames, AccountNumber"

        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        'Me.dGrid.Columns(2).Visible = False
        'Me.dGrid.Columns(3).Visible = False
        'Me.dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        AlternateColors()

        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Items Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmInventoryListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
        If UCase(strUserLevel) = UCase("Administrator") Or UCase(strUserLevel) = UCase("Manager") Then
            btnEdit.Enabled = True
            btnNew.Enabled = True
            btnRefresh.Enabled = True
            btnPrint.Enabled = True
        Else
            Select Case IntPublicInventory
                Case Is = 2
                    btnEdit.Enabled = True
                    btnNew.Enabled = True
                    btnRefresh.Enabled = True
                    btnPrint.Enabled = True
                Case Is = 1
                    btnEdit.Enabled = True
                    btnNew.Enabled = False
                    btnRefresh.Enabled = True
                    btnPrint.Enabled = True
                Case Else
                    btnEdit.Enabled = False
                    btnNew.Enabled = False
                    btnRefresh.Enabled = False
                    btnPrint.Enabled = False
            End Select
        End If
    End Sub

    Private Sub dGrid_ColumnDividerDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnDividerDoubleClickEventArgs) Handles dGrid.ColumnDividerDoubleClick
        boolHeaderClicked = True
    End Sub

    Private Sub dGrid_ColumnHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dGrid.ColumnHeaderMouseDoubleClick
        boolHeaderClicked = True
    End Sub

    Private Sub dGrid_dblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        If boolHeaderClicked = True Then
            boolHeaderClicked = False
            Exit Sub
        End If
        If dGrid.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedDetails()
            Dim f As New frmLoyalityCustomers
            f.ShowDialog()
            If UCase(strActiveSearch) = "SEARCH ITEM" Then
                txtSearchString.Text = strInventoryItemCode
            Else
                If String.IsNullOrEmpty(txtSearchString.Text) Then
                    LoadData()
                Else
                    txtSearchString.Text = strActiveSearch
                End If
            End If
        End If
    End Sub

    Private Sub GetSelectedDetails()
        Dim CurrentCellValue As String
        CurrentCellValue = dGrid.CurrentRow.Cells(0).Value
        strSelectedAccount = CurrentCellValue
    End Sub


    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If dGrid.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedDetails()
            Dim f As New frmLoyalityCustomers
            f.ShowDialog()
            If UCase(strActiveSearch) = "SEARCH ITEM" Then
                txtSearchString.Text = strInventoryItemCode
            Else
                If String.IsNullOrEmpty(txtSearchString.Text) Then
                    LoadData()
                Else
                    txtSearchString.Text = strActiveSearch
                End If
            End If
        End If
        'pmabaya@agribank.co.zw - Point of sale plus terminus pfmabaya@gmail.com
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        strActiveSearch = strFind
        Cursor = Cursors.WaitCursor
        'dGrid.Rows.Clear()
        dGrid.Columns.Clear()
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dim strSql As String = Nothing

        Select Case cboSearchBy.Text
            Case Is = "Account Number"
                strSql = "SELECT AccountNumber as [Account Number], LastName as [Surname], FirstName as [Name], " _
                    & "OtherNames AS [Other Names], ContactNumber AS [Contact Number], Category FROM " _
                    & "LoyalityCustomers WHERE AccountNumber LIKE '%" & strFind & "%' ORDER BY AccountNumber, LastName, FirstName, OtherNames"

            Case Is = "Surname" 'Use the grup name
                strSql = "SELECT AccountNumber as [Account Number], LastName as [Surname], FirstName as [Name], " _
                    & "OtherNames AS [Other Names], ContactNumber AS [Contact Number], Category FROM " _
                    & "LoyalityCustomers WHERE LastName LIKE '%" & strFind & "%' ORDER BY LastName, FirstName, OtherNames, AccountNumber"

            Case Is = "Name"
                strSql = "SELECT AccountNumber as [Account Number], LastName as [Surname], FirstName as [Name], " _
                    & "OtherNames AS [Other Names], ContactNumber AS [Contact Number], Category FROM " _
                    & "LoyalityCustomers WHERE FirstName LIKE '%" & strFind & "%' ORDER BY FirstName, LastName, OtherNames, AccountNumber"

            Case Else
                strSql = "SELECT AccountNumber as [Account Number], LastName as [Surname], FirstName as [Name], " _
                    & "OtherNames AS [Other Names], ContactNumber AS [Contact Number], Category FROM " _
                    & "LoyalityCustomers WHERE AccountNumber LIKE '%" & strFind & "%' ORDER BY LastName, FirstName, OtherNames, AccountNumber"
        End Select

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        'Me.dGrid.Columns(2).Visible = False
        'Me.dGrid.Columns(3).Visible = False
        'Me.dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        AlternateColors()
        For p As Integer = 0 To dGrid.Columns.Count - 1
            dGrid.Columns(p).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        Next
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory Search"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
        Exit Sub
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        On Error GoTo RaiseErr
        Dim arrPrintDetails As New ArrayList
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strLineData As String = Nothing
            For p As Integer = 0 To dGrid.ColumnCount - 1
                'FN=Arial;FS=8;FC=White;FB=False;FI=False;FU=False;BC=Navy;RH=25
                Dim strFontName As String = "Arial"
                Dim intFontSize As Integer = 6
                Dim strFontColor As String = "Black"
                Dim strFontBold As String = "False"
                Dim strFontItalic As String = "False"
                Dim strFontUnderline As String = "False"
                Dim strBackColor As String = "White"
                Dim intRectangleHeight As Integer = 25
                Dim strPrintData As String = Nothing
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(p).Value), "")) Then
                    strPrintData = dGrid.Rows(i).Cells(p).Value.ToString
                    'Get the actual font and style used in the grid
                    Dim fnt As Font = dGrid.Rows(i).Cells(p).Style.Font
                    If fnt Is Nothing Then intFontSize = 6 Else intFontSize = fnt.Size
                    If fnt Is Nothing Then strFontName = "Ariel" Else strFontName = fnt.Name
                    Dim strFontStyle As String = "False"
                    If Not fnt Is Nothing Then strFontStyle = fnt.Style
                    If strFontStyle = "1" Then strFontBold = "True"
                    If strFontStyle = "2" Then strFontItalic = "True"
                    If strFontStyle = "3" Then ' Bold and italic
                        strFontBold = "True"
                        strFontItalic = "True"
                    End If
                    If strFontStyle = "4" Then strFontUnderline = "True"
                    If strFontStyle = "5" Then ' Bold and underline
                        strFontBold = "True"
                        strFontUnderline = "True"
                    End If
                    If strFontStyle = "6" Then ' italic and underline
                        strFontItalic = "True"
                        strFontUnderline = "True"
                    End If
                    If strFontStyle = "7" Then ' italic and underline
                        strFontItalic = "True"
                        strFontUnderline = "True"
                        strFontBold = "True"
                    End If
                End If
                strLineData = strLineData & strPrintData & "|FN=" & strFontName & ";FS=" & intFontSize _
                    & ";FC=" & strFontColor & ";FB=" & strFontBold & ";FI=" & strFontItalic & ";FU=" & strFontUnderline _
                    & ";BC=" & strBackColor & ";RH=" & intRectangleHeight & "</d>"
            Next
            strLineData = Mid(strLineData, 1, strLineData.Length - 4)
            arrPrintDetails.Add(strLineData)
        Next

        Dim strPrintDetails(0 To arrPrintDetails.Count - 1) As String
        For i As Integer = 0 To arrPrintDetails.Count - 1
            strPrintDetails(i) = arrPrintDetails.Item(i)
        Next

        Dim strColumnHeaders As String = Nothing
        For i As Integer = 0 To dGrid.ColumnCount - 1
            strColumnHeaders = strColumnHeaders & dGrid.Columns(i).HeaderText & "|"
        Next
        strColumnHeaders = Mid(strColumnHeaders, 1, (strColumnHeaders.Length - 1))

        'Request for print properties
        Dim prnt As New PrintDialog
        prnt.ShowDialog()

        Dim intPrintPageAreaWidth As Integer = prnt.PrinterSettings.DefaultPageSettings.PaperSize.Width _
                - (prnt.PrinterSettings.DefaultPageSettings.Margins.Left + prnt.PrinterSettings.DefaultPageSettings.Margins.Right)

        'Widths are based on the percentage point of the paper size and the grid
        Dim strColumnWidths As String = Nothing
        Dim strColumsVisible As String = Nothing

        Dim intTotalGridWidth As Integer = 0
        'calculate the total column widths
        For y As Integer = 0 To dGrid.ColumnCount - 1
            intTotalGridWidth = intTotalGridWidth + dGrid.Columns(y).Width
        Next

        Dim intValidateWidth As Integer = 0
        For i As Integer = 0 To dGrid.ColumnCount - 1
            Dim intCurrentWidth As Integer = 0
            'If intValidateWidth < intPrintPageAreaWidth Then
            '    If dGrid.Columns(i).Width > (intPrintPageAreaWidth - intValidateWidth) Then
            '        intCurrentWidth = intPrintPageAreaWidth - intValidateWidth
            '    Else
            '        intCurrentWidth = dGrid.Columns(i).Width
            '    End If
            'Else
            '    intCurrentWidth = 0
            'End If

            'Calculate the width based on the percentage in the grid
            Dim intEqualWidth As Integer = intPrintPageAreaWidth / dGrid.Columns.Count
            Dim intPercentagePrintArea As Integer = (dGrid.Columns(i).Width / intTotalGridWidth) * 100
            intCurrentWidth = intPrintPageAreaWidth * (intPercentagePrintArea / 100)

            strColumnWidths = strColumnWidths & intCurrentWidth & "|"

            If intCurrentWidth = 0 Then
                strColumsVisible = strColumsVisible & "NO" & "|"
            Else
                strColumsVisible = strColumsVisible & "YES" & "|"
            End If
            intValidateWidth = intValidateWidth + intCurrentWidth
        Next
        strColumnWidths = Mid(strColumnWidths, 1, (strColumnWidths.Length - 1))
        strColumsVisible = Mid(strColumsVisible, 1, (strColumsVisible.Length - 1))

        Dim rpt As New SmartReportWriter.SmartReportWriter
        With rpt
            .intPrintRecordsCount = strPrintDetails.Length
            .intNumberOfColumns = dGrid.ColumnCount
            .strColumnHeaders = UCase(strColumnHeaders)
            .strColumnWidths = strColumnWidths
            .strFooterCaption = "Loyality Customers"
            .strMainCaption = UCase("LOYALITY CUSTOMERS")
            .strMainHeader2 = ""
            .strMainHeader3 = ""
            .FooterColor = Color.FromName("Black")
            .TitleColor = Color.FromName("Black")
            .DrawBorder = True
            .HorizontalLines = True
            .VerticalLines = True
            .GridColor = Color.Gray
            .BorderColor = Color.FromName("WhiteSmoke")
            .HeaderFont = New Font("Verdana", 10, FontStyle.Bold)
            .FooterFont = New Font("Verdana", 6, FontStyle.Bold)
            .boolGenericReport = False
            .strPrintValues = strPrintDetails
            .VisibleColumns = strColumsVisible
            .DetailColor = Color.Black
            .DetailFont = fntDetailsFont
        End With
        Dim documentPreview As New PrintPreviewDialog
        documentPreview.Document = rpt
        documentPreview.ShowDialog()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Report Generation"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub txtSearchString_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchString.TextChanged
        SearchForItem("")
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 0 To dGrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
                dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub btnUpdateCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New frmLoyalityCategoryUpdates
        f.ShowDialog()
    End Sub

End Class
