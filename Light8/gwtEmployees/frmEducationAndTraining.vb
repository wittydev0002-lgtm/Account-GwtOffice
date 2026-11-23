Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Imports System.Windows.Forms

Public Class frmEducationAndTraining

    Private Sub LoadQualifications()
        On Error GoTo RaiseErr
        Dim objCmd As New Data.OleDb.OleDbCommand("SELECT TransactionId, CourseName, CourseLevel, " _
            & "CONVERT(NVARCHAR, StartDate, 105) AS [StartDate], CONVERT(NVARCHAR, EndDate, 105) AS [EndDate], " _
            & "Institute, Outcome, SubjectsTaken FROM EmployeeQualifications WHERE " _
            & "EmployeeNo = '" & strPublicEmployeeId & "' ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmd.ExecuteReader
        dgrdEducation.Rows.Clear()
        While objReader.Read
            With dgrdEducation
                .Rows.Add(1)
                Dim strBuffer() As String
                'TransactionId, CourseName, CourseLevel, StartDate, EndDate, Institute, Outcome, SubjectsTaken
                .Rows(.Rows.Count - 1).Cells(0).Value = objReader("TransactionId").ToString
                .Rows(.Rows.Count - 1).Cells(1).Value = objReader("CourseName").ToString
                .Rows(.Rows.Count - 1).Cells(2).Value = objReader("CourseLevel").ToString
                If Not IsDBNull(objReader("StartDate").ToString) Then
                    strBuffer = Split(objReader("StartDate").ToString, "-")
                    .Rows(.Rows.Count - 1).Cells(3).Value = UCase(strBuffer(0) & "-" & gwt_comm.getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
                End If
                If Not IsDBNull(objReader("EndDate").ToString) Then
                    strBuffer = Split(objReader("EndDate").ToString, "-")
                    .Rows(.Rows.Count - 1).Cells(4).Value = UCase(strBuffer(0) & "-" & gwt_comm.getMonth(CInt(strBuffer(1))) & "-" & CInt(strBuffer(2)))
                End If

                .Rows(.Rows.Count - 1).Cells(5).Value = objReader("Institute").ToString
                .Rows(.Rows.Count - 1).Cells(6).Value = objReader("Outcome").ToString
                .Rows(.Rows.Count - 1).Cells(7).Value = objReader("SubjectsTaken").ToString
            End With
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & " on Qualifications Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmEducationAndTraining_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblEmployee.Text = strPublicEmployeeId
        lblEmployeeNames.Text = strEmployeeLastName & " " & strEmployeeFirstName
        LoadQualifications()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        boolEditStatus = False
        Dim frm As New frmEmployeeQualifications
        frm.ShowDialog()
        LoadQualifications()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        boolEditStatus = True
        Dim frm As New frmEmployeeQualifications
        frm.ShowDialog()
        LoadQualifications()
    End Sub

    Private Sub dgrdEducation_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrdEducation.CellClick
        If e.RowIndex < 0 Then Exit Sub
        DisplaySubjects(e.RowIndex)
    End Sub

    Private Sub DisplaySubjects(ByVal RowIndex As Integer)
        On Error GoTo RaiseErr
        dGridSubjects.Rows.Clear()
        With dgrdEducation
            If Not Object.Equals(.Rows(RowIndex).Cells(7).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.Rows(RowIndex).Cells(7).Value.ToString) Then
                    Dim strData() As String = Split(.Rows(RowIndex).Cells(7).Value.ToString, "|")
                    For p As Integer = 0 To strData.Length - 1
                        Dim strFields() As String = Split(strData(p), "~")
                        If Not String.IsNullOrEmpty(strFields(0)) Then
                            dGridSubjects.Rows.Add(strFields(0), strFields(1))
                        End If
                    Next
                End If
            End If
        End With
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On subject details show"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dgrdEducation_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgrdEducation.SelectionChanged
        If dgrdEducation.Rows.Count < 0 Then Exit Sub
        DisplaySubjects(dgrdEducation.CurrentRow.Index)
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If dgrdEducation.RowCount <= 0 Then Exit Sub
        On Error GoTo RaiseErr
        Dim intTid As Integer = 0
        With dgrdEducation
            If Not Object.Equals(.CurrentRow.Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(.CurrentRow.Cells(0).Value.ToString) Then
                    If IsNumeric(.CurrentRow.Cells(0).Value.ToString) Then
                        If MessageBox.Show("Are you sure you want to delete this qualification", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            intTid = CInt(.CurrentRow.Cells(0).Value.ToString)
                            Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM EmployeeQualifications " _
                                & "WHERE TransactionId = " & intTid & "", cnn)
                            objCommand.ExecuteNonQuery()
                            MessageBox.Show("Qualification has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            'Reload the subjects
                            LoadQualifications()
                        End If
                    End If
                End If
            End If
        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On training and education qualification delete"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
