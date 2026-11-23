Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmUserDefinedFormFields

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(txtFieldName.Text) Then
            MessageBox.Show("Please enter a valid field name", "Invalid Field Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtFieldName.Select()
            Exit Sub
        Else
            AddFieldName(txtFieldName.Text)
        End If
    End Sub

    Private Sub AddFieldName(ByVal FieldName As String)
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        Dim strSql As String = "INSERT INTO UserDefinedParms (FieldName, OptionId) VALUES " _
            & "('" & FieldName & "', 0)"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        Cursor = Cursors.Default

        LoadFields()

        txtFieldName.Clear()
        txtFieldName.Select()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Erro Number " & Err.Number & vbCrLf & "On user fields definition"
        ShowErrorMessage()
    End Sub

    Private Sub LoadFields()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        dGrid.Rows.Clear()
        Dim strSql As String = "SELECT OrdinalNo, FieldName, OptionId FROM UserDefinedParms ORDER BY OrdinalNo"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(objReader(0), objReader(1), objReader(2))
        End While
        objReader.Close()
        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Erro Number " & Err.Number & vbCrLf & "On user fields load"
        ShowErrorMessage()
    End Sub

    Private Sub frmUserDefinedFormFields_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadFields()
    End Sub

    Private Sub frmUserDefinedFormFields_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 580 : Me.Height = 420
    End Sub

    Private Sub txtFieldName_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFieldName.KeyDown
        If e.KeyValue = Keys.Enter Then
            btnAdd.Focus()
        End If
    End Sub

    Private Sub dGrid_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellClick
        If e.ColumnIndex = 4 Then
            DeleteRecord()
        End If
        If e.ColumnIndex = 3 Then
            OpenOptions()
        End If
    End Sub

    Private Sub DeleteRecord()

    End Sub

    Private Sub OpenOptions()

    End Sub

End Class