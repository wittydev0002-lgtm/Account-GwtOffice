Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms


Public Class frmTablesView

    '    Dim boolContinue As Boolean

    '    Private Sub LoadTables()
    '        On Error GoTo RaiseErr
    '        dgrid.Rows.Clear()
    '        boolContinue = True
    '        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT TableNo, TableName, TableType FROM SystemTableNames ORDER BY TableNo", cnn)
    '        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
    '        If objReader.HasRows Then
    '            While objReader.Read
    '                If Not IsDBNull(objReader(1).ToString) Then
    '                    dgrid.Rows.Add()
    '                    If Not IsDBNull(objReader(0).ToString) Then
    '                        dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = Format(CInt(objReader(0).ToString), "000")
    '                    End If
    '                    If Not IsDBNull(objReader(1).ToString) Then
    '                        dgrid.Rows(dgrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
    '                    End If
    '                    If Not IsDBNull(objReader(2).ToString) Then
    '                        dgrid.Rows(dgrid.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
    '                    End If
    '                End If
    '            End While
    '        Else
    '            'Initialize the tables
    '            For i As Integer = 1 To 100
    '                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemTableNames ([TableName],[TableType]," _
    '                & "[InputCode1],[OutputCode1],[InputCodeId1],[InputCodeId2] " _
    '                & ",[InputCode2],[InputCodeId3],[InputCode3],[OutputCodeId1],[OutputCodeId2],[OutputCode2],[OutputCodeId3] " _
    '                & ",[OutputCode3], [TableNo]) VALUES ('', '', 0, 0, '', '', 0, '', 0, '', '', 0, '', 0, " & i & ")", cnn)
    '                sqlCommand.ExecuteNonQuery()
    '                With dgrid
    '                    .Rows.Add(Format(i, "000"), "", "")
    '                End With
    '            Next
    '        End If
    '        AlternateColors()
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " " & Err.Number & " on Table Details Load"
    '        ShowErrorMessage()
    '    End Sub

    '    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrid.DoubleClick
    '        If dgrid.Rows.Count <= 0 Then Exit Sub
    '         GetSelected()
    '        If intTableNumber > 0 Then
    '            Dim f As New frmNewTable
    '            f.ShowDialog()
    '        End If
    '        LoadTables()
    '    End Sub

    '    Private Sub GetSelected()
    '        If Not (Object.Equals(Convert.ToString(dgrid.CurrentRow.Cells(0).Value), "")) Then
    '            intTableNumber = CInt(dgrid.CurrentRow.Cells(0).Value.ToString)
    '        End If
    '    End Sub

    '    Private Sub tsEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsEdit.Click
    '        If dgrid.Rows.Count <= 0 Then Exit Sub
    '        GetSelected()
    '        If intTableNumber > 0 Then
    '            Dim f As New frmNewTable
    '            f.ShowDialog()
    '        End If
    '        LoadTables()
    '    End Sub

    '    Private Sub tsDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsDelete.Click
    '        On Error GoTo RaiseErr
    '        If dgrid.Rows.Count <= 0 Then Exit Sub
    '        If MessageBox.Show("Are you sure you want to delete this table?", "Table Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
    '            GetSelected()
    '            Dim sqlCommand As New Data.OleDb.OleDbCommand("DELETE FROM SystemTables WHERE TableNo = " & intTableNumber & "", cnn)
    '            sqlCommand.ExecuteNonQuery()
    '            sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemTableValues WHERE TableNo = " & intTableNumber & "", cnn)
    '            sqlCommand.ExecuteNonQuery()
    '            LoadTables()
    '        End If
    '        Exit Sub
    'RaiseErr:
    '        boolAbort = True
    '        strErrorMessages = Err.Description & " " & Err.Number & " on Table Deletion"
    '        ShowErrorMessage()
    '    End Sub

    '    Private Sub frmTablesView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        LoadTables()
    '    End Sub

    '    Private Sub tsClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.Close()
    '    End Sub

    '    Private Sub tsNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsNew.Click
    '        Dim f As New frmNewTable
    '        f.ShowDialog()
    '    End Sub

    '    Private Sub AlternateColors()
    '        For i As Integer = 0 To dGrid.Rows.Count - 1 Step 2
    '            For j As Integer = 0 To dGrid.Columns.Count - 1
    '                Dim foreColor As Color = Color.Black
    '                Dim backColor As Color = Color.WhiteSmoke
    '                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
    '                dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
    '            Next j
    '        Next i
    '    End Sub

End Class