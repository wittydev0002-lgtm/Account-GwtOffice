Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmEducationCoursesView

    Dim _heightUpDown As Integer
    Dim _widthLeftRight As Integer
    Dim _originalLeftWidth As Integer
    Dim _originalSplitterDistance As Integer

    Private Sub frmEducationCoursesView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadFormData()
    End Sub

    Private Sub LoadFormData()
        On Error GoTo RaiseErr
        Dim objCmd As New Data.OleDb.OleDbCommand("SELECT * FROM SystemCourseDetails ORDER BY TransactionNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmd.ExecuteReader
        grd.Rows.Clear()
        While objReader.Read
            With grd
                .Rows.Add(1)
                .Rows(.Rows.Count - 1).Cells(0).Value = objReader("TransactionNo").ToString
                .Rows(.Rows.Count - 1).Cells(1).Value = objReader("CourseName").ToString
                .Rows(.Rows.Count - 1).Cells(2).Value = objReader("CourseLevel").ToString
                .Rows(.Rows.Count - 1).Cells(3).Value = objReader("CourseSubjects").ToString
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Course Listing Display"
        boolAbort = True
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim f As New frmEducationCourses
        f.ShowDialog()
        LoadFormData()
        boolEditStatus = True
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadFormData()
    End Sub

    Private Sub btnCloseTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub GetSelectedItem()
        Dim CurrentCellValue As String
        intSelectedTransaction = 0
        CurrentCellValue = grd.CurrentRow.Cells(0).Value
        intSelectedTransaction = CInt(CurrentCellValue)
        boolEditStatus = True
        Dim f As New frmEducationCourses
        f.ShowDialog()
        LoadFormData()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        GetSelectedItem()
    End Sub

    Private Sub grd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.DoubleClick
        GetSelectedItem()
    End Sub

    Private Sub DisplayData()
        On Error GoTo RaiseErr
        dgrdDetails.Rows.Clear()
        With grd
            Dim strValues() As String = Split(.CurrentRow.Cells(3).Value, "|")
            For i As Integer = 0 To strValues.Length - 1
                dgrdDetails.Rows.Add(1)
                dgrdDetails.Rows(dgrdDetails.Rows.Count - 1).Cells(0).Value = strValues(i)
            Next
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & " on Employee Information Quick View"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub grd_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grd.RowHeaderMouseClick
        DisplayData()
    End Sub

    Private Sub grd_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grd.SelectionChanged
        DisplayData()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If grd.Rows.Count > 0 Then
            If MessageBox.Show("Are you sure want to delete this record?", _
                    "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                intSelectedTransaction = CInt(grd.CurrentRow.Cells(0).Value.ToString)
                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemCourseDetails WHERE TransactionNo = " & intSelectedTransaction & "", cnn)
                objCommand.ExecuteNonQuery()
                LoadFormData()
                MessageBox.Show("Record deleted successfully", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Course Deletion"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub expandablePanel1_ExpandedChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles expandablePanel1.ExpandedChanged
        AdjustSplitter()
    End Sub

    Private Sub AdjustSplitter()
        ' Suspend layout changes until all splitter properties have been updated
        splitMain.SuspendLayout()
        expandablePanel1.Dock = DockStyle.None
        'Is the left header group currently expanded?
        If (splitMain.FixedPanel = FixedPanel.None) Then

            'Make the right panel of the splitter fixed in size
            splitMain.FixedPanel = FixedPanel.Panel1
            splitMain.IsSplitterFixed = True

            ' Remember the current height of the header group

            ' We have not changed the orientation of the header yet, so the width of 
            ' the splitter panel is going to be the height of the collapsed header group
            Dim newWidth As Integer = expandablePanel1.Width + 1 'kryptonHeaderGroupLeft.PreferredSize.Width

            ' Make the header group fixed just as the new height
            _originalSplitterDistance = splitMain.SplitterDistance
            splitMain.SplitterDistance = _originalSplitterDistance + (splitMain.Panel2.Width - newWidth) 'splitMain.SplitterDistance + (_widthLeftRight - 32) 'newWidth)
            splitMain.Panel1MinSize = newWidth
        Else

            ' Make the bottom panel not-fixed in size anymore
            splitMain.FixedPanel = FixedPanel.None
            splitMain.IsSplitterFixed = False

            ' Put back the minimise size to the original

            ' Calculate the correct splitter we want to put back
            splitMain.SplitterDistance = _originalSplitterDistance
            expandablePanel1.Dock = DockStyle.Fill

        End If

        splitMain.ResumeLayout()
    End Sub


End Class