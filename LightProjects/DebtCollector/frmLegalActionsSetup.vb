Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLegalActionsSetup

    Private Sub frmLegalActionsSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadGroupActions()
        AddStageTreeNodes()
    End Sub

    Private Sub LoadGroupActions()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, [ProcedureId]) +';'+ [ActionName] AS [Data] " _
            & "FROM ProdedureAndActions WHERE [ParentStatus] = 'YES' ORDER BY [ActionName]"
        'WHERE SubAccountOf = 'None' 
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        'Set up the drop down combo box
        With cboActionCode
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .MaxDropDownItems = 10
            .DropDownHeight = 110
            .ColumnWidth = "80;228"
        End With

        Dim arrItems As New ArrayList
        While objReader.Read
            arrItems.Add(objReader(0).ToString)
        End While
        objReader.Close()

        'Get a count of the items
        Dim intItemsCount As Integer = arrItems.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboActionCode.Items.Clear()

        'Continue to read until you reach the end of the file.
        For p As Integer = 0 To arrItems.Count - 1
            Dim strRecordText() As String = Split(arrItems.Item(p), ";")
            DropDownItems(p) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
        Next

        'Load the banks to the combo box
        If intItemsCount > 0 Then
            cboActionCode.SelectedIndex = -1
            cboActionCode.Items.Clear()
            cboActionCode.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            cboActionCode.Items.AddRange(DropDownItems)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(txtAction.Text) Then
            If String.IsNullOrEmpty(cboParentStatus.Text) Then cboParentStatus.Text = "NO"
            Dim strSql As String = "INSERT INTO ProdedureAndActions ([ActionName], [SubActionOf], [ParentStatus]) " _
                & "VALUES ('" & txtAction.Text & "', " & cboActionCode.Text & ", '" & cboParentStatus.Text & "')"
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            'MessageBox.Show("Action saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtAction.Clear()
            cboActionCode.Text = Nothing
            cboActionCode.Text = Nothing
            txtAction.Select()
            LoadGroupActions()
            AddStageTreeNodes()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
        ShowErrorMessage()
    End Sub

    Private Sub cboActionCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboActionCode.SelectedIndexChanged
        lblCodeDescription.Text = ""
        If Not cboActionCode.SelectedItem Is Nothing Then
            lblCodeDescription.Text = cboActionCode.SelectedItem.Col2
        End If
    End Sub

    Private Sub AddStageTreeNodes()
        On Error GoTo RaiseErr
        tvAccounts.Nodes.Clear()
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = 0 ORDER BY [ProcedureId]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim node As New TreeNode
            node.Text = objReader(0).ToString
            node.Tag = objReader(1).ToString
            AddStageNodes(node)
            tvAccounts.Nodes.Add(node)
        End While
        objReader.Close()
        tvAccounts.ExpandAll()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
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
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On debt collection stages setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        intSelectedTransaction = 0
        On Error GoTo RaiseErr
        intSelectedTransaction = CInt(tvAccounts.SelectedNode.Tag.ToString)
        strSelectedDescription = tvAccounts.SelectedNode.Text
        Dim frm As New frmModifyStage
        frm.ShowDialog()
        LoadGroupActions()
        AddStageTreeNodes()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = "Please make sure that you have selected at least one item for editing"
        ShowErrorMessage()
    End Sub

    Private Sub tvAccounts_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvAccounts.AfterSelect
        On Error Resume Next
        cboActionCode.Text = CInt(tvAccounts.SelectedNode.Tag.ToString)
    End Sub

End Class