Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmProjectSelect

    Private Sub frmProjectSelect_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub frmProjectSelect_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 430 : Me.Height = 490
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        strSql = "SELECT ProjectsMain.ContractNumber AS [Proj.#], " _
            & "ProjectsMain.ContractName AS [Contract Name], ProjectsMain.Owner AS [Owner] FROM " _
            & "ProjectsMain ORDER BY ProjectsMain.ContractName"

        dGridProjects.Columns.Clear()

        Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
        cmd.CommandType = CommandType.Text

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim dTable As New DataTable()
        da.Fill(dTable)
        dGridProjects.DataSource = dTable

        dGridProjects.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        For i As Integer = 0 To dGridProjects.Columns.Count - 1
            dGridProjects.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On project details listing load"
        ShowErrorMessage()
    End Sub

    Private Sub dGridProjects_DoubleClick(sender As Object, e As System.EventArgs) Handles dGridProjects.DoubleClick
        SelectProject()
    End Sub

    Private Sub SelectProject()
        If dGridProjects.Rows.Count <= 0 Then Exit Sub
        If Not Object.Equals(dGridProjects.Rows(dGridProjects.CurrentRow.Index).Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGridProjects.Rows(dGridProjects.CurrentRow.Index).Cells(0).Value.ToString) Then
                If IsNumeric(dGridProjects.Rows(dGridProjects.CurrentRow.Index).Cells(0).Value.ToString) Then
                    lngPublicLinkedProjectNumber = CDbl(dGridProjects.Rows(dGridProjects.CurrentRow.Index).Cells(0).Value.ToString)
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        SelectProject()
    End Sub

End Class