Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmEmployeeListing

    Dim _heightUpDown As Integer
    Dim _widthLeftRight As Integer
    Dim _originalLeftWidth As Integer
    Dim _originalSplitterDistance As Integer
    Dim intPriorSplitterDistance As Integer

    Dim strArrEmployeeDetails() As String
    Dim strNavigateDirection As String = Nothing

    Private Sub frmEmployeeListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        boolRunningForDisplay = True
        LoadEmployees()
        If grd.Rows.Count > 0 Then
            DisplayEmployeeData(grd.CurrentRow.Cells(0).Value.ToString)
        End If
        boolRunningForDisplay = False
        '_originalLeftWidth = kryptonSplitContainerHorizontal.Panel1.Width
        'AdjustSplitter()
    End Sub

    Sub LoadEmployees()
        On Error GoTo RaiseErr
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT EmployeeNo, " _
            & "LastName, FirstName, OtherNames, IdNumber, Status FROM " _
            & "EmployeeMaster ORDER BY LastName, FirstName, OtherNames, EmployeeNo", cnn)
        'Pass the file path and the file name to the StreamReader constructor.
        objReader = sqlCommand.ExecuteReader
        Dim currentCell As DataGridViewCell
        Dim i As Integer = 0
        grd.Rows.Clear()
        'set the number of rows
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Or Not IsDBNull(objReader(1).ToString) Then
                grd.Rows.Add(1)
                If Not IsDBNull(objReader(0).ToString) Then grd.Rows(grd.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
                If Not IsDBNull(objReader(1).ToString) Then grd.Rows(grd.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
                If Not IsDBNull(objReader(2).ToString) Then grd.Rows(grd.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
                If Not IsDBNull(objReader(3).ToString) Then grd.Rows(grd.Rows.Count - 1).Cells(3).Value = objReader(3).ToString
                If Not IsDBNull(objReader(4).ToString) Then grd.Rows(grd.Rows.Count - 1).Cells(4).Value = objReader(4).ToString
                If Not IsDBNull(objReader(5).ToString) Then grd.Rows(grd.Rows.Count - 1).Cells(5).Value = objReader(5).ToString
            End If
        End While
        'If grd.Rows.Count <= 0 Then
        '    txtRecordIndex.Text = "0 of " & grd.Rows.Count
        'Else
        '    txtRecordIndex.Text = "1 of " & grd.Rows.Count
        'End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Details Load error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetSelectedEmployeeDetails()
        Dim CurrentCellValue As String
        boolDisallowSave = False
        CurrentCellValue = grd.CurrentRow.Cells(0).Value
        strPublicEmployeeId = CurrentCellValue
        'Get the name of the employee for update on the details form
        If Not (Object.Equals(Convert.ToString(grd.CurrentRow.Cells(1).Value), "")) Then
            strEmployeeLastName = Convert.ToString(grd.CurrentRow.Cells(1).Value)
        End If
        If Not (Object.Equals(Convert.ToString(grd.CurrentRow.Cells(2).Value), "")) Then
            strEmployeeFirstName = Convert.ToString(grd.CurrentRow.Cells(2).Value)
        End If
        Dim CurrentCellStatus As String = grd.CurrentRow.Cells(4).Value
        If UCase(CStr(CurrentCellStatus)) = "INACTIVE" Then
            boolDisallowSave = True
        End If
    End Sub

    Private Sub grd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.Click
        If grd.Rows.Count > 0 Then
            'txtRecordIndex.Text = CStr(grd.CurrentRow.Index + 1) & " of " & grd.Rows.Count
            DisplayEmployeeData(grd.CurrentRow.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub grd_dblClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.DoubleClick
        If grd.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedEmployeeDetails()
            If boolDisallowSave = True Then
                MessageBox.Show("You have accessed a terminated employee. You can only view the record. No changes will be saved", _
                    "Terminated Employee Record Assess", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Dim f As New frmEmployeeDetails
            f.ShowDialog()
        End If
    End Sub

    Private Sub grd_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectionChanged
        If boolRunningForDisplay = True Then Exit Sub
        If grd.Rows.Count > 0 Then
            'txtRecordIndex.Text = CStr(grd.CurrentRow.Index + 1) & " of " & grd.Rows.Count
            DisplayEmployeeData(grd.CurrentRow.Cells(0).Value.ToString)
        End If
    End Sub

    'Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
    '    If grd.Rows.Count <= 0 Then Exit Sub
    '    strNavigateDirection = "First"
    '    grd.Rows(0).Selected = True
    '    grd.CurrentCell = grd(0, 0)
    '    'txtRecordIndex.Text = CStr(grd.CurrentRow.Index + 1) & " of " & grd.Rows.Count
    'End Sub

    'Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
    '    If grd.CurrentRow.Index = grd.Rows.Count - 1 Or grd.Rows.Count <= 0 Then Exit Sub
    '    strNavigateDirection = "Next"
    '    grd.Rows(grd.CurrentRow.Index + 1).Selected = True
    '    grd.CurrentCell = grd(0, grd.CurrentRow.Index + 1)
    '    txtRecordIndex.Text = CStr(grd.CurrentRow.Index + 1) & " of " & grd.Rows.Count
    'End Sub

    'Private Sub btnPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
    '    If grd.CurrentRow.Index = 0 Or grd.Rows.Count <= 0 Then Exit Sub
    '    strNavigateDirection = "Previous"
    '    grd.Rows(grd.CurrentRow.Index - 1).Selected = True
    '    grd.CurrentCell = grd(0, grd.CurrentRow.Index - 1)
    '    txtRecordIndex.Text = CStr(grd.CurrentRow.Index + 1) & " of " & grd.Rows.Count
    'End Sub

    'Private Sub btnLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLast.Click
    '    If grd.Rows.Count <= 0 Then Exit Sub
    '    strNavigateDirection = "Last"
    '    grd.Rows(grd.Rows.Count - 1).Selected = True
    '    grd.CurrentCell = grd(0, grd.Rows.Count - 1)
    '    txtRecordIndex.Text = CStr(grd.CurrentRow.Index + 1) & " of " & grd.Rows.Count
    'End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        If chkAutoIncreament.Checked = True Then boolAutoNextNumber = True Else boolAutoNextNumber = False
        Dim f As New frmEmployeeDetails
        f.ShowDialog()
        boolRunningForDisplay = True
        LoadEmployees()
        boolRunningForDisplay = False
        boolEditStatus = True
    End Sub

    Private Sub txtSearchString_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearchString.TextChanged
        'Handles the search function. as the use types the string, the grid positions itself to the nearest match
        Dim i As Integer = 0
        For i = 0 To grd.Rows.Count - 1
            Select Case cboSearchBy.Text
                Case Is = "Employee Number"
                    If UCase(Mid(grd.Rows(i).Cells(0).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                        grd.FirstDisplayedCell = grd.Rows(i).Cells(0)
                        grd.FirstDisplayedCell.Selected = True
                        Exit Sub
                    End If
                Case Is = "First Name"
                    If UCase(Mid(grd.Rows(i).Cells(2).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                        grd.FirstDisplayedCell = grd.Rows(i).Cells(2)
                        grd.FirstDisplayedCell.Selected = True
                        Exit Sub
                    End If
                Case Is = "Other Names"
                    If UCase(Mid(grd.Rows(i).Cells(3).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                        grd.FirstDisplayedCell = grd.Rows(i).Cells(3)
                        grd.FirstDisplayedCell.Selected = True
                        Exit Sub
                    End If
                Case Is = "Id Number"
                    If UCase(Mid(grd.Rows(i).Cells(4).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                        grd.FirstDisplayedCell = grd.Rows(i).Cells(4)
                        grd.FirstDisplayedCell.Selected = True
                        Exit Sub
                    End If
                Case Else
                    'Use the last name
                    If UCase(Mid(grd.Rows(i).Cells(1).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                        grd.FirstDisplayedCell = grd.Rows(i).Cells(1)
                        grd.FirstDisplayedCell.Selected = True
                        Exit Sub
                    End If
            End Select
        Next
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        boolRunningForDisplay = True
        LoadEmployees()
        boolRunningForDisplay = False
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If grd.Rows.Count > 0 Then
            boolEditStatus = True
            GetSelectedEmployeeDetails()
            If boolDisallowSave = True Then
                MessageBox.Show("You have accessed a terminated employee. You can only view the record. " _
                    & "No changes will be saved", "Terminated Employee Record Assess", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Dim f As New frmEmployeeDetails
            f.ShowDialog()
        End If
    End Sub

    ''Private Sub buttonSpecLeftRight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonSpecLeftRight.Click
    ''    ' Suspend layout changes until all splitter properties have been updated
    ''    kryptonSplitContainerHorizontal.SuspendLayout()

    ''    'Is the left header group currently expanded?
    ''    If (kryptonSplitContainerHorizontal.FixedPanel = FixedPanel.None) Then

    ''        'Make the right panel of the splitter fixed in size
    ''        kryptonSplitContainerHorizontal.FixedPanel = FixedPanel.Panel2
    ''        kryptonSplitContainerHorizontal.IsSplitterFixed = True

    ''        ' Remember the current height of the header group
    ''        _widthLeftRight = kryptonHeaderGroupLeft.Width



    ''        ' Change header to be vertical and button to near edge
    ''        kryptonHeaderGroupLeft.HeaderPositionPrimary = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right
    ''        kryptonHeaderGroupLeft.ButtonSpecs(0).Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near

    ''        ' We have not changed the orientation of the header yet, so the width of 
    ''        ' the splitter panel is going to be the height of the collapsed header group
    ''        Dim newWidth As Integer = 32 'kryptonHeaderGroupLeft.PreferredSize.Width

    ''        ' Make the header group fixed just as the new height
    ''        _originalSplitterDistance = kryptonSplitContainerHorizontal.SplitterDistance
    ''        kryptonSplitContainerHorizontal.SplitterDistance = kryptonSplitContainerHorizontal.SplitterDistance + (_widthLeftRight - 32) 'newWidth)
    ''        kryptonSplitContainerHorizontal.Panel2MinSize = newWidth
    ''    Else

    ''        ' Make the bottom panel not-fixed in size anymore
    ''        kryptonSplitContainerHorizontal.FixedPanel = FixedPanel.None
    ''        kryptonSplitContainerHorizontal.IsSplitterFixed = False

    ''        ' Put back the minimise size to the original
    ''        'kryptonSplitContainerHorizontal.Panel2MinSize = _originalLeftWidth

    ''        ' Calculate the correct splitter we want to put back
    ''        kryptonSplitContainerHorizontal.SplitterDistance = _originalSplitterDistance

    ''        ' Change header to be horizontal and button to far edge
    ''        kryptonHeaderGroupLeft.HeaderPositionPrimary = ComponentFactory.Krypton.Toolkit.VisualOrientation.Top
    ''        kryptonHeaderGroupLeft.ButtonSpecs(0).Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far
    ''    End If

    ''    kryptonSplitContainerHorizontal.ResumeLayout()
    ''End Sub

    Private Sub DisplayEmployeeData(ByVal EmployeeNumer As String)
        On Error GoTo RaiseErr
        'Get the employee data and display on the datagrid by the side
        Dim rand As Random = New Random()
        'Dim foreColor As Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256))
        'Dim backColor As Color = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256))

        'Dim backColor As Color = Color.FromArgb(255, 255, 255)
        'Dim foreColor As Color = Color.FromArgb(195, 215, 239)

        Dim foreColor As Color = Color.FromArgb(237, 243, 244)
        Dim backColor As Color = Color.Black
        Dim fnt As System.Drawing.FontStyle

        Dim objCmd As New Data.OleDb.OleDbCommand("SELECT * FROM EmployeeMaster WHERE EmployeeNo = '" & EmployeeNumer & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmd.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            With dgrdDetails
                .Rows.Clear()
                If Not IsDBNull(objReader("Title").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "TITLE"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("Title").ToString
                End If

                If Not IsDBNull(objReader("OtherNames").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "OTHER NAMES"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("OtherNames").ToString
                End If

                If IsDate(objReader("BirthDate").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "DATE OF BIRTH"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = UCase(shortMonthDateFormat(CDate(objReader("BirthDate").ToString)))
                End If

                If Not IsDBNull(objReader("Gender").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "GENDER"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("Gender").ToString
                End If

                If Not IsDBNull(objReader("MaritalStatus").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "MARITAL STATUS"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("MaritalStatus").ToString
                End If

                If Not IsDBNull(objReader("Address1").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "ADDRESS"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("Address1").ToString
                    If Not IsDBNull(objReader("Address2").ToString) Then
                        .Rows.Add(1)
                        .Rows(.Rows.Count - 1).Cells(0).Value = objReader("Address2").ToString
                    End If
                    If Not IsDBNull(objReader("Address3").ToString) Then
                        .Rows.Add(1)
                        .Rows(.Rows.Count - 1).Cells(0).Value = objReader("Address3").ToString
                    End If
                    If Not IsDBNull(objReader("Address4").ToString) Then
                        .Rows.Add(1)
                        .Rows(.Rows.Count - 1).Cells(0).Value = objReader("Address4").ToString
                    End If
                End If

                If Not IsDBNull(objReader("Telephone").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "TELEPHONE"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("Telephone").ToString
                End If

                If Not IsDBNull(objReader("Cellphone").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "CELLPHONE"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("Cellphone").ToString
                End If

                If Not IsDBNull(objReader("EmailAddress").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "EMAIL ADDRESS"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("EmailAddress").ToString
                End If

                If Not IsDBNull(objReader("ClockNo").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "CLOCK NO"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("ClockNo").ToString
                End If

                If Not IsDBNull(objReader("DirAmt").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "DIRECTIVE AMOUNT"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("DirAmt").ToString
                End If

                If Not IsDBNull(objReader("DirPercent").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "DIRECTIVE PERCENT"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("DirPercent").ToString
                End If

                If IsDate(objReader("DischDate").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "TERMINATION DATE"
                    .Rows.Add(1)
                    If IsDate(objReader("DischDate").ToString) Then
                        .Rows(.Rows.Count - 1).Cells(0).Value = UCase(shortMonthDateFormat(CDate(objReader("DischDate").ToString)))
                    Else
                        .Rows(.Rows.Count - 1).Cells(0).Value = objReader("DischDate").ToString
                    End If
                End If

                If Not IsDBNull(objReader("DischRsn").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "TERMINATION REASON"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("DischRsn").ToString
                End If

                If Not IsDBNull(objReader("StopFrom").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "STOP PAY FROM"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("StopFrom").ToString
                End If

                If Not IsDBNull(objReader("StopTo").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "STOP PAY TO"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("StopTo").ToString
                End If

                If Not IsDBNull(objReader("TaxCode").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "TAX CODE"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("TaxCode").ToString
                End If

                If Not IsDBNull(objReader("TaxDependents").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "TAX DEPENDENTS"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("TaxDependents").ToString
                End If

                If Not IsDBNull(objReader("TaxRef").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "TAX NUMBER"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("TaxRef").ToString
                End If

                If Not IsDBNull(objReader("MaidenName").ToString) Then
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Style.BackColor = foreColor
                    .Rows(.Rows.Count - 1).Cells(0).Style.ForeColor = backColor
                    fnt = (fnt Or FontStyle.Bold)
                    .Rows(.Rows.Count - 1).Cells(0).Style.Font = New Font(.Rows(.Rows.Count - 1).Cells(0).InheritedStyle.Font, fnt)
                    .Rows(.Rows.Count - 1).Cells(0).Value = "MAIDEN NAME"
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("MaidenName").ToString
                End If

            End With
        End If
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Information Quick View"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If grd.SelectedRows.Count <= 0 Then Exit Sub
        Cursor = Cursors.WaitCursor
        boolAbort = False
        gwt_comm.PrintFullMasterFileDetails(grd.CurrentRow.Cells(0).Value.ToString)
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If
        gwt_comm.GenerateMasterFileReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptions.Click
        Dim x As Integer = 0
        While x < grd.Rows.Count
            Dim y As Integer = 0
            While y < grd.Rows(x).Cells.Count
                Dim c As DataGridViewCell = grd.Rows(x).Cells(y)
                If Not c.Value Is DBNull.Value Or Nothing Then
                    If UCase(CType(c.Value, String)) = UCase(txtSearchString.Text) Then
                        'MessageBox.Show("Found!")
                        grd.Rows(x).Cells(y).Style.BackColor = Color.Yellow
                        grd.Rows(x).Cells(y).Style.ForeColor = Color.Black
                        'Set the row pointer to the row
                        Exit Sub
                    End If
                End If
                System.Math.Min(System.Threading.Interlocked.Increment(y), y - 1)
            End While
            System.Math.Min(System.Threading.Interlocked.Increment(x), x - 1)
        End While
        MessageBox.Show("Search Complete.No matching records found !!")
    End Sub

    'Private Sub AlternateColors()
    '    With grd
    '        For i As Integer = 0 To .Rows.Count - 1 Step 2
    '            For j As Integer = 0 To .Columns.Count - 1
    '                Dim foreColor As Color = Color.Black
    '                Dim backColor As Color = Color.WhiteSmoke
    '                .Rows(i).Cells(j).Style.BackColor = backColor
    '                .Rows(i).Cells(j).Style.ForeColor = foreColor
    '            Next j
    '        Next i
    '    End With
    'End Sub

    'Private Sub expandablePanel1_ExpandedChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles expandablePanel1.ExpandedChanged
    '    AdjustSplitter()
    'End Sub

    'Private Sub AdjustSplitter()
    '    If expandablePanel1.Expanded Then
    '        If (splitMain.Width - splitMain.Panel1.Width) < 200 Then intPriorSplitterDistance = splitMain.Width - 250
    '        splitMain.SplitterDistance = intPriorSplitterDistance
    '        splitMain.IsSplitterFixed = False
    '    Else
    '        intPriorSplitterDistance = splitMain.SplitterDistance
    '        splitMain.SplitterDistance = splitMain.Width - 32
    '        splitMain.IsSplitterFixed = True
    '    End If
    'End Sub

    'Private Sub frmEmployeeListing_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
    '    AdjustSplitter()
    'End Sub

    Private Sub btnPrintAllEmployeeList_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintAllEmployeeList.Click

    End Sub
End Class
