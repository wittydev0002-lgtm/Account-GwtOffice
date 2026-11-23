Imports CommonLibrary.Commons

Public Class frmSpecialKeys

    Private Sub frmSpecialKeys_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If UCase(strSpecialKeysId) = "US" Then
            Me.Text = "Unserved Actions Keys Setup"
        Else
            Me.Text = "Payment Plans Keys Setup"
        End If
        AddStageTreeNodes()
        LoadData()
    End Sub

    Private Sub AddStageTreeNodes()
        On Error GoTo RaiseErr
        tvStages.Nodes.Clear()
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = 0 ORDER BY [ProcedureId]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim node As New TreeNode
            node.Text = objReader(0).ToString
            node.Tag = objReader(1).ToString
            AddStageNodes(node)
            tvStages.Nodes.Add(node)
        End While
        objReader.Close()
        tvStages.ExpandAll()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Special Keys setup"
        ShowErrorMessage()
    End Sub

    Private Sub AddStageNodes(ByRef node As TreeNode)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = '" & node.Tag & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim nNode As New TreeNode
            nNode.Text = objReader(0).ToString
            nNode.Tag = objReader(1).ToString
            AddStageNodes(nNode)
            node.Nodes.Add(nNode)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Special Keys setup"
        ShowErrorMessage()
    End Sub

    Private Sub tvStages_DoubleClick(sender As Object, e As System.EventArgs) Handles tvStages.DoubleClick
        On Error Resume Next
        dGrid.Rows.Add(tvStages.SelectedNode.Tag.ToString)
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim strTable As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        If UCase(strSpecialKeysId) = "US" Then
            strTable = "SystemUnservedKeys"
        Else
            strTable = "SystemPaymentPlanKeys"
        End If

        strSql = "DELETE FROM " & strTable & ""
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        For p As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(0).Value.ToString) Then
                        strSql = "INSERT INTO " & strTable & " (ActionKey) VALUES " _
                            & "(" & CInt(dGrid.Rows(p).Cells(0).Value.ToString) & ")"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                End If
            End If
        Next

        MessageBox.Show("Process has been completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Special Keys setup"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim strTable As String = Nothing
        If UCase(strSpecialKeysId) = "US" Then
            strTable = "SystemUnservedKeys"
        Else
            strTable = "SystemPaymentPlanKeys"
        End If
        strSql = "SELECT ActionKey FROM " & strTable & " ORDER BY TransactionId"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Special Keys setup"
        ShowErrorMessage()
    End Sub

    Private Sub SearchTree(ByVal ActionKey As Integer)
        For p As Integer = 0 To tvStages.Nodes.Count - 1
            If tvStages.Nodes(p).Tag = CStr(ActionKey) Then
                tvStages.SelectedNode = tvStages.Nodes(p)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub dGrid_RowEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.RowEnter
        On Error Resume Next
        SearchTree(CInt(dGrid.CurrentRow.Cells(0).Value.ToString))
    End Sub

    Private Sub dGrid_SelectionChanged(sender As Object, e As System.EventArgs) Handles dGrid.SelectionChanged
        On Error Resume Next
        SearchTree(CInt(dGrid.CurrentRow.Cells(0).Value.ToString))
    End Sub

End Class