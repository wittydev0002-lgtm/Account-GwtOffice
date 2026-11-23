Public Class frmLegalActionsSetup

    Private Sub frmLegalActionsSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadGroupActions()
        AddTreeNodes()
    End Sub

    Private Sub LoadGroupActions()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT CONVERT(NVARCHAR, [ProcedureId]) +';'+ [ActionName] AS [Data] " _
            & "FROM ProdedureAndActions WHERE [ParentStatus] = 'YES' ORDER BY [ActionName]"
        'WHERE SubAccountOf = 'None' 
        Dim sqlCommand As New Data.OleDb.OleDbCommand(strSql, conn)
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
        MsgBox(Err.Description)
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(txtAction.Text) Then
            If String.IsNullOrEmpty(cboParentStatus.Text) Then cboParentStatus.Text = "NO"
            Dim strSql As String = "INSERT INTO ProdedureAndActions ([ActionName], [SubActionOf], [ParentStatus]) " _
                & "VALUES ('" & txtAction.Text & "', " & cboActionCode.Text & ", '" & cboParentStatus.Text & "')"
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, conn)
            objCommand.ExecuteNonQuery()
            'MessageBox.Show("Action saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtAction.Clear()
            cboActionCode.Text = Nothing
            cboActionCode.Text = Nothing
            txtAction.Select()
            LoadGroupActions()
            AddTreeNodes()
        End If
        Exit Sub
RaiseErr:
        MsgBox(Err.Description)
    End Sub

    Private Sub cboActionCode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboActionCode.SelectedIndexChanged
        lblCodeDescription.Text = ""
        If Not cboActionCode.SelectedItem Is Nothing Then
            lblCodeDescription.Text = cboActionCode.SelectedItem.Col2
        End If
    End Sub

    'Private Sub cboParentStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboParentStatus.SelectedIndexChanged
    '    If cboParentStatus.Text = "YES" Then
    '        cboActionCode.Enabled = False
    '        cboActionCode.Text = "0"
    '    Else
    '        cboActionCode.Enabled = True
    '    End If
    'End Sub

    Private Sub AddTreeNodes()
        On Error GoTo RaiseErr
        tvAccounts.Nodes.Clear()
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = 0 ORDER BY [ProcedureId]"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, conn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim node As New TreeNode
            node.Text = objReader(0).ToString
            node.Tag = objReader(1).ToString
            AddNodes(node)
            tvAccounts.Nodes.Add(node)
        End While
        objReader.Close()
        tvAccounts.ExpandAll()
        Exit Sub
RaiseErr:
        MsgBox(Err.Description)
        'boolAbort = True
        'Cursor = Cursors.Default
        'strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Ledger Accounts Population"
        'ShowErrorMessage()
    End Sub

    Private Sub AddNodes(ByRef node As TreeNode)
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = '" & node.Tag & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, conn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim nNode As New TreeNode
            nNode.Text = objReader(0).ToString
            nNode.Tag = objReader(1).ToString
            AddNodes(nNode)
            node.Nodes.Add(nNode)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        MsgBox(Err.Description)
    End Sub

End Class