Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.IO

Public Class frmDiagnosisCodesListing

    Dim boolFormLoading As Boolean

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        'Open the file for input

        Dim strFileName As String = Nothing
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        strFileName = ofd.FileName

        If String.IsNullOrEmpty(strFileName) Then Exit Sub

        Dim objReader As New StreamReader(strFileName)
        Dim strWholeFile As String = objReader.ReadToEnd
        objReader.Close()

        Dim strBuffer() As String = Split(strWholeFile, vbCrLf)
        Dim intRecordCount As Integer = strBuffer.Length + 10
        pb1.Value = 0 : pb1.Maximum = intRecordCount

        'First delete any records that may exist
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM OchmasSystemIcdTen", cnn)
        objCommand.ExecuteNonQuery()

        'iterate through the buffer string and insert into the table
        For i As Integer = 0 To strBuffer.Length - 2
            Dim strLine As String = strBuffer(i)
            Dim strFields() As String = Split(strLine, "|")
            strSql = "INSERT INTO OchmasSystemIcdTen (Code, ShortDescription, LongDescription, Validation) VALUES " _
                        & "('" & strFields(1) & "', '" & strFields(2) & "', '" & strFields(3) & "', '" & strFields(4) & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            pb1.Value = pb1.Value + 1
        Next

        MessageBox.Show("Diagnosis codes updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadData()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Diagnosis codes (ICD10) data upload"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmDiagnosisCodesListing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        boolFormLoading = True
        LoadData()
        boolFormLoading = False
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = "Select Code, ShortDescription AS [Short Description], Validation, LongDescription " _
            & "FROM OchmasSystemIcdten ORDER BY Code"
        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGrid.Columns.Clear()
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dGrid.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Me.dGrid.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dGrid.Columns(3).Visible = False
        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        lblCount.Text = dGrid.RowCount

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Diagnosis codes (ICD10) data update"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        If Asc(e.KeyChar) = 18 Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13 Then
            SearchForItem("")
        Else
            SearchForItem(e.KeyChar)
        End If
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)
        If boolFormLoading = True Then Exit Sub
        Dim i As Integer = 0
        Dim strFind As String = txtSearchString.Text & strCurrentKey
        strActiveSearch = strFind
        Cursor = Cursors.WaitCursor

        dGrid.Columns.Clear()

        Dim strSql As String = Nothing

        If UCase(cboSearchBy.Text) = UCase("Code") Then
            strSql = "Select Code, ShortDescription AS [Short Description], Validation, LongDescription FROM OchmasSystemIcdten " _
                & "WHERE Code LIKE '%" & strFind & "%' ORDER BY Code"
        Else
            strSql = "Select Code, ShortDescription AS [Short Description], Validation, LongDescription FROM OchmasSystemIcdten " _
                & "WHERE ShortDescription LIKE '%" & strFind & "%' ORDER BY ShortDescription"
        End If

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        dGrid.Columns.Clear()
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGrid.DataSource = dTable

        Me.dGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dGrid.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Me.dGrid.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Me.dGrid.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.dGrid.Columns(3).Visible = False
        Me.dGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        lblCount.Text = dGrid.RowCount


        lblCount.Text = dGrid.RowCount
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Diagnosis Code Setup"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
        Exit Sub
    End Sub

    Private Sub dGrid_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellDoubleClick
        GetSelected()
    End Sub

    Private Sub dGrid_SelectionChanged(sender As Object, e As System.EventArgs) Handles dGrid.SelectionChanged
        txtFullDescription.Clear()
        If Not Object.Equals(dGrid.CurrentRow.Cells(3).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(3).Value.ToString) Then
                txtFullDescription.Text = dGrid.CurrentRow.Cells(3).Value.ToString
            End If
        End If
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmDiagnosticsCodeSetup
        frm.ShowDialog()
    End Sub

    Private Sub GetSelected()
        strSelectedCode = Nothing
        If dGrid.RowCount <= 0 Then Exit Sub
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                strSelectedCode = dGrid.CurrentRow.Cells(0).Value.ToString
                boolEditStatus = True
                boolAbort = False
                Dim frm As New frmDiagnosticsCodeSetup
                frm.ShowDialog()
                If boolAbort = True Then Exit Sub
                LoadData()
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        GetSelected()
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        strSelectedCode = Nothing
        If dGrid.RowCount <= 0 Then Exit Sub
        If Not Object.Equals(dGrid.CurrentRow.Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.CurrentRow.Cells(0).Value.ToString) Then
                If MessageBox.Show("Are you sure you want to delete this diagnosis code: " & strSelectedCode & "?", _
                        "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    strSelectedCode = dGrid.CurrentRow.Cells(0).Value.ToString
                    Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM OchmasSystemIcdten WHERE Code = '" & strSelectedCode & "'", cnn)
                    objCommand.ExecuteNonQuery()
                    MessageBox.Show("Diagnosis code has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadData()
                End If
            End If
        End If
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Diagnosis Code Delete"
        gwt_comm.ShowErrorMessage()
        Cursor = Cursors.Default
        Exit Sub
    End Sub

End Class
