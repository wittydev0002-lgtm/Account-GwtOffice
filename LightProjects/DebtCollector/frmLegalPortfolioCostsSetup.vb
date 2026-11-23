Imports CommonLibrary.Commons

Public Class frmLegalPortfolioCostsSetup

    Private data As List(Of Node)
    Dim strNodePath As String = Nothing
    Dim boolFormLoading As Boolean

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmLegalPortfolioCostsSetup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadClients()
        If boolCalledFromListing = True Then
            cboClients.SelectedText = strSelectedPlaintifName
            lblClientId.Text = strSelectedPlaintifId
            cboClients.Enabled = False
        End If
    End Sub

    Private Sub LoadClients()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT GivenNames +'|'+ PlaintifID AS " _
            & "[Details] FROM Plaintifs ORDER BY GivenNames", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim arrData As New ArrayList

        While objReader.Read
            If UCase(strUserLevel) <> UCase("Administrator") Then
                If Not IsDBNull(objReader(0).ToString) Then
                    Dim strSplitName() As String = Split(objReader(0).ToString, "|")
                    For z As Integer = 0 To arrPublicPotfolioClientName.Count - 1
                        If UCase(strSplitName(0)) = UCase(arrPublicPotfolioClientName.Item(z)) Then
                            arrData.Add(objReader(0).ToString)
                        End If
                    Next
                End If
            Else
                If Not IsDBNull(objReader(0).ToString) Then arrData.Add(objReader(0).ToString)
            End If
        End While
        objReader.Close()

        Dim intWidth1 As Integer = cboClients.Width - 80

        'Add the items to the drop down box
        With cboClients
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown
            .ColumnNum = 2
            .HighlightBorderOnMouseEvents = True
            .ManagingFastMouseMoving = True
            .Enabled = True
            .GridLineHorizontal = True
            .GridLineVertical = True
            .ColumnWidth = intWidth1 & ";80"
        End With

        'Get a count of the items
        Dim intItemsCount As Integer = arrData.Count
        Dim DropDownItems(intItemsCount - 1) As MTGCComboBoxItem

        cboClients.Items.Clear()

        For i As Integer = 0 To arrData.Count - 1
            'File the listview with details.
            If Not String.IsNullOrEmpty(arrData.Item(i)) Then
                Dim strRecordText() As String = Split(arrData.Item(i), "|")
                DropDownItems(i) = New MTGCComboBoxItem(strRecordText(0), strRecordText(1))
            End If
        Next

        'Load the clients to the combo box
        If intItemsCount > 0 Then
            With cboClients
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .Items.AddRange(DropDownItems)
            End With
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Portfolio costs details load"
        ShowErrorMessage()
    End Sub

    Private Sub cboClients_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClients.SelectedIndexChanged
        If Not cboClients.SelectedItem Is Nothing Then
            lblClientId.Text = cboClients.SelectedItem.Col2
            InitializeData(lblClientId.Text)
        Else
            lblClientId.Text = "0"
        End If
    End Sub

    Private Function ActionCost(ByVal ActionKey As Integer, ByVal ClientId As String) As Double
        On Error GoTo RaiseErr
        Dim dblReturn As Double

        Dim strSql As String = Nothing
        Dim strSqlCurrent As String = Nothing

        strSql = "SELECT Cost FROM LegalPortfolioCosts WHERE PlaintifId = '" & ClientId & "' AND ActionKey = " & ActionKey & ""

        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblReturn = CDbl(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Return dblReturn
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Key Cost Fetch"
        ShowErrorMessage()
    End Function

    Private Sub InitializeData(ByVal SelectedPortfolio As String)
        On Error GoTo RaiseErr

        data = New List(Of Node)()
        TreeListView1.Columns.Clear()
        TreeListView1.Items.Clear()
        boolFormLoading = True

        'My code cracking
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT [ActionName], [ProcedureId] " _
            & "FROM ProdedureAndActions WHERE ParentStatus = 'YES' AND [SubActionOf] = 0", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            strNodePath = Nothing
            Dim dblStageCost As Double = ActionCost(CInt(objReader(1).ToString), SelectedPortfolio)
            Dim parent1 As New Node(objReader(0).ToString(), CStr(Format(dblStageCost, "##0.00")), CInt(objReader(1).ToString), "", "")
            AddNodes(parent1, objReader(1).ToString, SelectedPortfolio)
            data.Add(parent1)
        End While
        objReader.Close()
        With TreeListView1
            .FullRowSelect = True
            .GridLines = True
        End With
        FillTree()
        boolFormLoading = False
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On action stages populate"
        ShowErrorMessage()
    End Sub

    Private Sub AddNodes(ByRef sNode As Node, intActionId As Integer, ByVal strPortfolio As String)
        On Error GoTo RaiseErr
        If Not String.IsNullOrEmpty(strNodePath) Then
            strNodePath = strNodePath & "\" & sNode.ActionName
        Else
            strNodePath = sNode.ActionName
        End If
        Dim strSql As String = "SELECT [ActionName], [ProcedureId] FROM ProdedureAndActions " _
            & "WHERE [SubActionOf] = " & intActionId & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            Dim dblStageCost As Double = ActionCost(CInt(objReader(1).ToString), strPortfolio)
            Dim nNode As New Node(objReader(0).ToString(), CStr(Format(dblStageCost, "##0.00")), CInt(objReader(1).ToString), "", "")
            sNode.Children.Add(nNode)
            AddNodes(nNode, objReader(1).ToString, strPortfolio)
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On action stages populate"
        ShowErrorMessage()
    End Sub

    Private Sub FillTree()

        Me.TreeListView1.CanExpandGetter = Function(x As Object) DirectCast(x, Node).Children.Count > 0
        Me.TreeListView1.ChildrenGetter = Function(x As Object) DirectCast(x, Node).Children

        ' create the tree columns and set the delegates to print the desired object proerty
        Dim ActionNameCol As New BrightIdeasSoftware.OLVColumn("Action Taken", "ActionName")
        ActionNameCol.AspectGetter = Function(x As Object) DirectCast(x, Node).ActionName

        Dim Count1Col As New BrightIdeasSoftware.OLVColumn("Cost", "Count1")
        Count1Col.AspectGetter = Function(x As Object) DirectCast(x, Node).Count1
        Count1Col.TextAlign = HorizontalAlignment.Right

        Dim KeyCol As New BrightIdeasSoftware.OLVColumn("ActionKey", "Key")
        KeyCol.AspectGetter = Function(x As Object) DirectCast(x, Node).Value1
        KeyCol.TextAlign = HorizontalAlignment.Left

        ' add the columns to the tree
        Me.TreeListView1.Columns.Add(ActionNameCol)
        Me.TreeListView1.Columns.Add(Count1Col)
        Me.TreeListView1.Columns.Add(KeyCol)

        ' set the tree roots
        Me.TreeListView1.Roots = Data

        TreeListView1.Columns(0).Width = TreeListView1.Width - 110
        TreeListView1.Columns(1).Width = 100
        TreeListView1.Columns(2).Width = 0

        TreeListView1.ExpandAll()

    End Sub

    Private Sub TreeListView1_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles TreeListView1.ColumnWidthChanged
        If boolFormLoading = True Then Exit Sub
        Select Case e.ColumnIndex
            Case Is = 0
                TreeListView1.Columns(0).Width = TreeListView1.Width - 110
            Case Is = 1
                TreeListView1.Columns(1).Width = 100
            Case Is = 2
                TreeListView1.Columns(2).Width = 0
        End Select
    End Sub

    Private Sub TreeListView1_DoubleClick(sender As Object, e As System.EventArgs) Handles TreeListView1.DoubleClick
        On Error GoTo RaiseErr
        With TreeListView1
            If .Items.Count <= 0 Then Exit Sub
            dblNewCostPrice = 0
            If IsNumeric(.SelectedItem.SubItems(0).Text.ToString) Then
                dblNewCostPrice = CDbl(.SelectedItem.SubItems(1).Text.ToString)
            End If
            intSelectedTransaction = CInt(.SelectedItem.SubItems(2).Text.ToString)
            boolAbort = False
            Dim frm As New frmPortfolioCostAmount
            frm.ShowDialog()
            If boolAbort = False Then
                Dim strSql As String = "DELETE FROM LegalPortfolioCosts WHERE " _
                    & "PlaintifId = '" & lblClientId.Text & "' AND ActionKey = " & intSelectedTransaction & ""
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                strSql = "INSERT INTO LegalPortfolioCosts (PlaintifId, ActionKey, Cost) VALUES " _
                    & "('" & lblClientId.Text & "', " & intSelectedTransaction & ", " & dblNewCostPrice & ")"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
                MessageBox.Show("Portfolio cost updated successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                InitializeData(lblClientId.Text)
            End If
        End With
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On action cost setup"
        ShowErrorMessage()
    End Sub

End Class