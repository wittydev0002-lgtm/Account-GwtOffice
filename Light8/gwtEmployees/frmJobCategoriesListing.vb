Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmJobCategoriesListing

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        boolEditStatus = False
        Dim f As New frmJobCategories
        f.ShowDialog()
        LoadDetails()
        boolEditStatus = True
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        boolEditStatus = True
        If dGrid.RowCount <= 0 Then Exit Sub
        GetSelected()
        Dim f As New frmJobCategories
        f.ShowDialog()
        LoadDetails()
    End Sub

    Private Sub GetSelected()
        If dGrid.Rows.Count > 0 Then
            intSelectedCode = CInt(dGrid.CurrentRow.Cells(0).Value.ToString)
            strCodeDescription = dGrid.CurrentRow.Cells(1).Value
        End If
    End Sub

    Private Sub LoadDetails()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT * FROM SystemJobCategories ORDER BY JobCategory", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader("JobCategory").ToString) Then
                With dGrid
                    .Rows.Add(1)
                    .Rows(.Rows.Count - 1).Cells(0).Value = objReader("TransactionNo").ToString
                    .Rows(.Rows.Count - 1).Cells(1).Value = objReader("JobCategory").ToString
                End With
            End If
        End While
        objReader.Close()
        AlternateColors()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Job Categories Setup"
        gwt_comm.ShowErrorMessage()
    End Sub


    Private Sub frmJobCategoriesListing_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDetails()
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        If dGrid.RowCount <= 0 Then Exit Sub
        boolEditStatus = True
        GetSelected()
        Dim f As New frmJobCategories
        f.ShowDialog()
        LoadDetails()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        If dGrid.RowCount <= 0 Then Exit Sub
        GetSelected()
        If MessageBox.Show("Are you sure you want to delete " & strSelectedCodeDescription & "?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            'First check that there are no employees in this job category
            Dim objCommand As New Data.OleDb.OleDbCommand("SELECT JobCategory FROM JobProfiles WHERE JobCategory = '" & strSelectedCodeDescription & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                MessageBox.Show("This category cannot be deleted as there are jobs in this category" & vbCrLf & _
                    "Please remove jobs from this category before you can delete it", "Process Terminated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                objReader.Close()
                Exit Sub
            Else
                'proceed and delete the job category
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemJobCategories WHERE TransactionNo = " & intSelectedCode & "", cnn)
                objCommand.ExecuteNonQuery()
                MessageBox.Show("Record has been deleted from the system", "Record Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDetails()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On Job Category Delete"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub AlternateColors()
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1 Step 2
                For j As Integer = 0 To .Columns.Count - 1
                    Dim foreColor As Color = Color.Black
                    Dim backColor As Color = Color.WhiteSmoke
                    .Rows(i).Cells(j).Style.BackColor = backColor
                    .Rows(i).Cells(j).Style.ForeColor = foreColor
                Next j
            Next i
        End With
    End Sub

End Class
