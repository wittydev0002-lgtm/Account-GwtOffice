Imports System
Imports System.Collections.Generic
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Text
Imports System.Windows.Forms
Imports CodeEngine.Framework
Imports System.IO
Imports System.Net
Imports System.Drawing.Text
Imports CodeEngine.Framework.QueryBuilder
Imports System.Windows.Forms.DataVisualization.Charting
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Partial Public Class frmSqlQueries

    Dim boolIsLoading As Boolean = True
    Dim arrayFieldType As ArrayList
    'Dim conn As New ADODB.Connection
    Dim lngNumberOfLines As Long = 0
    Dim dblNextNumber As Double = 0
    Dim arrWhere As ArrayList
    Dim boolPreviewReport As Boolean
    Dim intPriorSplitterDistance As Integer

    Dim strPrintColumns As String = Nothing
    Dim strColumnHeaders As String = Nothing
    Dim strColumnSizes As String = Nothing
    Dim strColumnFormating As String = Nothing
    Dim strColumnAlignment As String = Nothing
    Dim strColumnTotals As String = Nothing
    Dim intColumns As Integer = 0

    'Declare and set the default fonts
    'Dim fntHeaderFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point)
    'Dim fntDetailsFont As New System.Drawing.Font("Arial", 8, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
    'Dim fntFooterFont As New System.Drawing.Font("Arial", 6, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)

    Dim strHeaderFontName As String = "Arial"
    Dim strFooterFontName As String = "Arial"
    Dim strDetailFontName As String = "Arial"

    Dim intHeaderFontSize As Integer = 8
    Dim intFooterFontSize As Integer = 6
    Dim intDetailFontSize As Integer = 8

    Dim strHeaderFontFullNames As String = Chr(34) & "Arial" & Chr(34) & ", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point"
    Dim strFooterFontFullNames As String = Chr(34) & "Arial" & Chr(34) & ", 8, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point"
    Dim strDetailFontFullNames As String = Chr(34) & "Arial" & Chr(34) & ", 6, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point"

    Dim strFooterForeColor As String = "Black"
    Dim strHeaderForeColor As String = "Black"
    Dim strDetailForeColor As String = "Black"

    Dim strGridLinesColor As String = "Black"
    Dim boolVerticalLines As Boolean = False
    Dim boolHorizontalLines As Boolean = False

    Dim boolPrintSummary As Boolean = False
    Dim boolDrawGraph As Boolean = False
    Dim boolPrintFinalTotals As Boolean = False

    Dim boolGroupData As Boolean = False
    Dim intBreakIndex As Integer = -1
    Dim strHighlights As String = Nothing
    Dim strPrintBorder As String = "False"
    Dim boolPrintBorder As Boolean = False
    Dim strBorderColor As String = "Black"

    Private Sub frmSqlQueries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        intPriorSplitterDistance = 750
        boolIsLoading = True
        LoadTables()
        LoadFonts()
        boolIsLoading = False
        KryptonSplitContainer1.SplitterDistance = intPriorSplitterDistance
        KryptonSplitContainer1.IsSplitterFixed = True
        TabFunctions.SelectedTabIndex = 0
        'AdjustPanes()
    End Sub

    Private Sub expandablePanel1_ExpandedChanged(sender As Object, e As DevComponents.DotNetBar.ExpandedChangeEventArgs) Handles expandablePanel1.ExpandedChanged
        AdjustPanes()
    End Sub

    Private Sub AdjustPanes()
        If expandablePanel1.Expanded Then
            KryptonSplitContainer1.SplitterDistance = intPriorSplitterDistance
            KryptonSplitContainer1.IsSplitterFixed = False
        Else
            intPriorSplitterDistance = KryptonSplitContainer1.SplitterDistance
            KryptonSplitContainer1.SplitterDistance = KryptonSplitContainer1.Width - 32
            KryptonSplitContainer1.IsSplitterFixed = True
        End If
    End Sub

    Private Sub GenerateSqlStatement(ByVal strColumns As String, ByVal strTables As String, Optional ByVal strOrderBy As String = "", Optional ByVal strGroupBy As String = "")

        Dim query As New SelectQueryBuilder()
        Dim strTableArray() As String = Split(strTables, ", ")
        query.SelectColumns(strColumns)
        If dGridRelations.Rows.Count > 0 Then
            If strTableArray.Length > 1 Then
                query.SelectFromTables(strTableArray(0))
            End If
        Else
            query.SelectFromTables(strTables)
        End If
        If Not String.IsNullOrEmpty(strOrderBy) Then
            query.AddOrderBy(strOrderBy, Enums.Sorting.Descending)
        End If
        If Not String.IsNullOrEmpty(strGroupBy) Then
            query.GroupBy(strGroupBy)
        End If
        Dim i As Integer = 0
        For i = 0 To arrWhere.Count - 1
            Dim strBuffer() As String = Split(arrWhere.Item(i), ":")
            If InStr(strBuffer(2), Chr(39), Microsoft.VisualBasic.CompareMethod.Text) Then strBuffer(2) = Replace(strBuffer(2), Chr(39), "", 1)
            Select Case strBuffer(1)
                Case Is = "Equals"
                    If i = 0 Then
                        query.AddWhere(strBuffer(0), Enums.Comparison.Equals, strBuffer(0), 1)
                    Else
                        If UCase(strBuffer(3)) = "OR" Then
                            query.AddWhere(strBuffer(0), Enums.Comparison.Equals, strBuffer(2), 2)
                        Else
                            query.AddWhere(strBuffer(0), Enums.Comparison.Equals, strBuffer(2), 1)
                        End If
                    End If
                Case Is = "GreaterOrEquals"
                    If i = 0 Then
                        query.AddWhere(strBuffer(0), Enums.Comparison.GreaterOrEquals, strBuffer(2), 1)
                    Else
                        If UCase(strBuffer(3)) = "OR" Then
                            query.AddWhere(strBuffer(0), Enums.Comparison.GreaterOrEquals, strBuffer(2), 2)
                        Else
                            query.AddWhere(strBuffer(0), Enums.Comparison.GreaterOrEquals, strBuffer(2), 1)
                        End If
                    End If
                Case Is = "GreaterThan"
                    If i = 0 Then
                        query.AddWhere(strBuffer(0), Enums.Comparison.GreaterThan, strBuffer(2), 1)
                    Else
                        If UCase(strBuffer(3)) = "OR" Then
                            query.AddWhere(strBuffer(0), Enums.Comparison.GreaterThan, strBuffer(2), 2)
                        Else
                            query.AddWhere(strBuffer(0), Enums.Comparison.GreaterThan, strBuffer(2), 1)
                        End If
                    End If
                Case Is = "In"
                    If i = 0 Then
                        query.AddWhere(strBuffer(0), Enums.Comparison.In, strBuffer(2), 1)
                    Else
                        If UCase(strBuffer(3)) = "OR" Then
                            query.AddWhere(strBuffer(0), Enums.Comparison.In, strBuffer(2), 2)
                        Else
                            query.AddWhere(strBuffer(0), Enums.Comparison.In, strBuffer(2), 1)
                        End If
                    End If
                Case Is = "LessOrEquals"
                    If i = 0 Then
                        query.AddWhere(strBuffer(0), Enums.Comparison.LessOrEquals, strBuffer(2), 1)
                    Else
                        If UCase(strBuffer(3)) = "OR" Then
                            query.AddWhere(strBuffer(0), Enums.Comparison.LessOrEquals, strBuffer(2), 2)
                        Else
                            query.AddWhere(strBuffer(0), Enums.Comparison.LessOrEquals, strBuffer(2), 1)
                        End If
                    End If
                Case Is = "LessThan"
                    If i = 0 Then
                        query.AddWhere(strBuffer(0), Enums.Comparison.LessThan, strBuffer(2), 1)
                    Else
                        If UCase(strBuffer(3)) = "OR" Then
                            query.AddWhere(strBuffer(0), Enums.Comparison.LessThan, strBuffer(2), 2)
                        Else
                            query.AddWhere(strBuffer(0), Enums.Comparison.LessThan, strBuffer(2), 1)
                        End If
                    End If
                Case Is = "Like"
                    If i = 0 Then
                        query.AddWhere(strBuffer(0), Enums.Comparison.Like, strBuffer(2) & "%", 1)
                    Else
                        If UCase(strBuffer(3)) = "OR" Then
                            query.AddWhere(strBuffer(0), Enums.Comparison.Like, strBuffer(2) & "%", 2)
                        Else
                            query.AddWhere(strBuffer(0), Enums.Comparison.Like, strBuffer(2) & "%", 1)
                        End If
                    End If
                Case Is = "NotEquals"
                    If i = 0 Then
                        query.AddWhere(strBuffer(0), Enums.Comparison.NotEquals, strBuffer(2), 1)
                    Else
                        If UCase(strBuffer(3)) = "OR" Then
                            query.AddWhere(strBuffer(0), Enums.Comparison.NotEquals, strBuffer(2), 2)
                        Else
                            query.AddWhere(strBuffer(0), Enums.Comparison.NotEquals, strBuffer(2), 1)
                        End If
                    End If
                Case Is = "NotLike"
                    If i = 0 Then
                        query.AddWhere(strBuffer(0), Enums.Comparison.NotLike, strBuffer(2) & "%", 1)
                    Else
                        If UCase(strBuffer(3)) = "OR" Then
                            query.AddWhere(strBuffer(0), Enums.Comparison.NotLike, strBuffer(2) & "%", 2)
                        Else
                            query.AddWhere(strBuffer(0), Enums.Comparison.NotLike, strBuffer(2) & "%", 1)
                        End If
                    End If
            End Select
        Next
        'Generate the join
        For i = 0 To dGridRelations.Rows.Count - 1
            Dim strLeftTable As String = dGridRelations.Rows(i).Cells(0).Value.ToString
            Dim strLeftField As String = dGridRelations.Rows(i).Cells(1).Value.ToString
            Dim strRightTable As String = dGridRelations.Rows(i).Cells(2).Value.ToString
            Dim strRightField As String = dGridRelations.Rows(i).Cells(3).Value.ToString
            Dim strMyJoinType As String = dGridRelations.Rows(i).Cells(4).Value.ToString
            If UCase(strMyJoinType) = "INNERJOIN" Then
                query.AddJoin(Enums.JoinType.InnerJoin, strRightTable, strRightField, Enums.Comparison.Equals, strLeftTable, strLeftField)
            Else
                query.AddJoin(Enums.JoinType.LeftJoin, strRightTable, strRightField, Enums.Comparison.Equals, strLeftTable, strLeftField)
            End If
        Next
        ' ''query.SelectFromTable("Consultations")
        ' ''query.SelectColumns("Consultations.VisitDate AS [Date]", "Patients.LastName +' '+ Patients.FirstName AS [Given Names]")

        ' ''query.AddJoin(Enums.JoinType.InnerJoin, "Patients", "ReferenceNumber", _
        ' ''      Enums.Comparison.Equals, "Consultations", "ReferenceNumber")
        '' '' Add 'Criteria' column to level 1

        ' ''query.AddWhere("LastName", Enums.Comparison.Like, "Cha%", 1)
        ' ''query.AddWhere("VisitDate", Enums.Comparison.Equals, New DateTime(2009, 4, 1), 1)

        '' '' Add 'Or...' column to level 2

        ' ''query.AddWhere("LastName", Enums.Comparison.Equals, "Mathebula", 2)

        '' '' Add the date selection clause

        ' ''Dim clause As WhereClause = query.AddWhere("VisitDate", Enums.Comparison.Equals, New DateTime(2009, 5, 30), 2)

        '' '' Add a nested clause to the captured clause

        ' ''clause.AddClause(Enums.LogicOperator.[Or], Enums.Comparison.GreaterThan, New DateTime(2009, 1, 1))
        Dim statement As String = query.BuildQuery()
        txtSql.Text = statement
        TabFunctions.SelectedTab = TabItem8
    End Sub

    Private Sub LoadTables()
        If boolIsLoading = False Then Exit Sub
        On Error GoTo RaiseErr
        treeView1.Nodes.Clear()
        Dim SchemaTable As DataTable
        Dim arrViews() As String = Nothing
        Dim arrTables() As String = Nothing
        SchemaTable = cnn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, Nothing})
        Dim int As Integer
        Dim incr As Integer = 0
        For int = 0 To SchemaTable.Rows.Count - 1
            If SchemaTable.Rows(int)!TABLE_TYPE.ToString = "TABLE" Then
                Dim strTempTableName As String = SchemaTable.Rows(int)!TABLE_NAME.ToString()
                Dim node As TreeNode = treeView1.Nodes.Add(strTempTableName)
                'Get the field names and add them in under this node
                Dim dt_field As System.Data.DataTable = _
                    cnn.GetOleDbSchemaTable( _
                        OleDb.OleDbSchemaGuid.Columns, _
                        New Object() {Nothing, Nothing, strTempTableName})
                'Add the field names to the treeview view 
                Dim n As Integer = 0
                For Each dr_field As DataRow In dt_field.Rows
                    node.Nodes.Add(dr_field("COLUMN_NAME").ToString)
                Next
            End If
        Next
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
    End Sub

    Private Sub treeView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles treeView1.DoubleClick
        On Error Resume Next
        If String.IsNullOrEmpty(treeView1.SelectedNode.Parent.Text) Then
            Exit Sub
        Else
            dGridFields.Rows.Add(1)
            dGridFields.Rows(dGridFields.Rows.Count - 1).Cells(0).Value = treeView1.SelectedNode.Parent.Text.ToString
            dGridFields.Rows(dGridFields.Rows.Count - 1).Cells(1).Value = treeView1.SelectedNode.Text.ToString
            AddToSortAndGroupFields()

        End If
    End Sub

    Private Sub tsGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGenerate.Click
        'Generate the statement for the tables
        On Error GoTo RaiseErr
        Dim strSelectedFields As String = Nothing
        Dim strTablesFrom As String = Nothing
        Dim i As Integer = 0
        For i = 0 To dGridFields.Rows.Count - 1
            Dim strFriendlyName As String = Nothing
            Dim strTableName As String = Nothing
            Dim strFieldName As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGridFields.Rows(i).Cells(0).Value), "")) Then
                strTableName = Convert.ToString(dGridFields.Rows(i).Cells(0).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGridFields.Rows(i).Cells(1).Value), "")) Then
                strFieldName = Convert.ToString(dGridFields.Rows(i).Cells(1).Value)
            End If
            If Not (Object.Equals(Convert.ToString(dGridFields.Rows(i).Cells(2).Value), "")) Then
                strFriendlyName = Convert.ToString(dGridFields.Rows(i).Cells(2).Value)
            End If
            If Not String.IsNullOrEmpty(strTableName) Then
                If Not String.IsNullOrEmpty(strFieldName) Then
                    If Not String.IsNullOrEmpty(strFriendlyName) Then
                        strSelectedFields = strSelectedFields & " " & strTableName & "." & strFieldName & " AS [" & strFriendlyName & "],"
                    Else
                        strSelectedFields = strSelectedFields & " " & strTableName & "." & strFieldName & ","
                    End If

                    Dim strTestBuffer() As String = Split(strTablesFrom, ", ")
                    Dim boolAlreadyIn As Boolean = False
                    For p As Integer = 0 To strTestBuffer.Length - 1
                        If UCase(strTestBuffer(p)) = UCase(strTableName) Then
                            boolAlreadyIn = True
                            Exit For
                        End If
                    Next
                    If boolAlreadyIn = False Then
                        strTablesFrom = strTablesFrom & strTableName & ", "
                    End If

                    'If InStr(1, strTablesFrom, strTableName, 1) Then
                    '    'do nothing
                    'Else
                    '    strTablesFrom = strTablesFrom & strTableName & ", "
                    'End If



                End If
            End If
        Next

        'Format the string at end
        If Not String.IsNullOrEmpty(strSelectedFields) Then
            strSelectedFields = Mid(strSelectedFields, 2, strSelectedFields.Length - 1)
            If Not String.IsNullOrEmpty(strTablesFrom) Then strTablesFrom = Mid(strTablesFrom, 1, strTablesFrom.Length - 2)
            'Get the sort string
            Dim strSortFields As String = Nothing
            Dim strGroupFields As String = Nothing
            Dim p As Integer = 0
            For p = 0 To dGridSorts.Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(dGridSorts.Rows(p).Cells(0).Value), "")) Then
                    strSortFields = strSortFields & dGridSorts.Rows(p).Cells(0).Value.ToString & ", "
                End If
            Next
            'Get the sort string as well
            For p = 0 To dGridGroups.Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(dGridGroups.Rows(p).Cells(0).Value), "")) Then
                    strGroupFields = strGroupFields & dGridGroups.Rows(p).Cells(0).Value.ToString & ", "
                End If
            Next
            'format the sort string
            If Not String.IsNullOrEmpty(strSortFields) Then
                strSortFields = Mid(strSortFields, 1, strSortFields.Length - 2)
            End If
            'Format the group string 
            If Not String.IsNullOrEmpty(strGroupFields) Then
                strGroupFields = Mid(strGroupFields, 1, strGroupFields.Length - 2)
            End If
            'Initialize the condiction statements
            arrWhere = New ArrayList
            For i = 0 To dGridFilter.Rows.Count - 1
                arrWhere.Add(dGridFilter.Rows(i).Cells(0).Value.ToString & ":" & _
                    dGridFilter.Rows(i).Cells(1).Value.ToString & ":" & dGridFilter.Rows(i).Cells(2).Value.ToString & ":" & _
                    dGridFilter.Rows(i).Cells(3).Value.ToString)
            Next

            'Pass the string the sql builder dll
            If Not String.IsNullOrEmpty(strSortFields) And String.IsNullOrEmpty(strGroupFields) Then
                GenerateSqlStatement(strSelectedFields, strTablesFrom, strSortFields)
            Else
                If Not String.IsNullOrEmpty(strGroupFields) Then
                    GenerateSqlStatement(strSelectedFields, strTablesFrom, strSortFields, strGroupFields)
                Else
                    GenerateSqlStatement(strSelectedFields, strTablesFrom)
                End If
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
    End Sub

    Private Sub tsRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRun.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtSql.Text) Then
            MessageBox.Show("Please generate the SQL Statement before running it", "Missing Sql Statement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim cmd As New OleDb.OleDbCommand(txtSql.Text, cnn)
        cmd.CommandType = CommandType.Text
        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim diagnosis As New DataTable()
        da.Fill(diagnosis)
        dGrid.DataSource = diagnosis
        TabFunctions.SelectedTab = TabItem9
        txtResults.Text = dGrid.Rows.Count & " row(s) selected"
        lblRowCount.Text = "Number of rows retrieved = " & dGrid.Rows.Count
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number
        ShowErrorMessage()
    End Sub

    Private Sub txtResults_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtResults.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If String.IsNullOrEmpty(cboSortFields.Text) Then
            MessageBox.Show("Please select the field to be used for sorting data before adding", "Missing Sort Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSortFields.Focus()
            Exit Sub
        End If
        Dim strSortDirection As String = "ASC"
        If String.IsNullOrEmpty(cboDirection.Text) Then strSortDirection = "ASC" Else strSortDirection = cboDirection.Text
        dGridSorts.Rows.Add(1)
        dGridSorts.Rows(dGridSorts.Rows.Count - 1).Cells(0).Value = cboSortFields.Text
        dGridSorts.Rows(dGridSorts.Rows.Count - 1).Cells(1).Value = strSortDirection
    End Sub

    Private Sub AddToSortAndGroupFields()
        Dim i As Integer = 0
        cboSortFields.Items.Clear() : cboGroupField.Items.Clear()
        cboFilterTableName.Items.Clear()
        cboLeftField.Items.Clear() : cboRightField.Items.Clear()
        cboLeftTable.Items.Clear() : cboRightTable.Items.Clear()
        For i = 0 To dGridFields.Rows.Count - 1
            cboSortFields.Items.Add(dGridFields.Rows(i).Cells(0).Value.ToString & "." & dGridFields.Rows(i).Cells(1).Value.ToString)
            cboGroupField.Items.Add(dGridFields.Rows(i).Cells(0).Value.ToString & "." & dGridFields.Rows(i).Cells(1).Value.ToString)
        Next

        'Add the unique table names
        Dim strTablesFrom As String = Nothing
        For i = 0 To dGridFields.Rows.Count - 1
            Dim strTableName As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGridFields.Rows(i).Cells(0).Value), "")) Then
                strTableName = Convert.ToString(dGridFields.Rows(i).Cells(0).Value)
            End If
            If Not String.IsNullOrEmpty(strTableName) Then
                Dim strTestBuffer() As String = Split(strTablesFrom, ", ")
                Dim boolAlreadyIn As Boolean = False
                For p As Integer = 0 To strTestBuffer.Length - 1
                    If UCase(strTestBuffer(p)) = UCase(strTableName) Then
                        boolAlreadyIn = True
                        Exit For
                    End If
                Next
                If boolAlreadyIn = False Then
                    strTablesFrom = strTablesFrom & strTableName & ", "
                End If
            End If
        Next

        If Not String.IsNullOrEmpty(strTablesFrom) Then
            strTablesFrom = Mid(strTablesFrom, 1, strTablesFrom.Length - 2)
            Dim strbuffer() As String = Split(strTablesFrom, ", ")
            For i = 0 To strbuffer.Length - 1
                cboFilterTableName.Items.Add(strbuffer(i).ToString)
                cboRightTable.Items.Add(strbuffer(i).ToString)
                cboLeftTable.Items.Add(strbuffer(i).ToString)
            Next
            cboFilterTableName.SelectedIndex = 0
            cboRightTable.SelectedIndex = 0
            cboLeftTable.SelectedIndex = 0
        End If
    End Sub

    Private Sub dGridFields_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dGridFields.RowsRemoved
        AddToSortAndGroupFields()
    End Sub

    Private Sub btnAddGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddGroup.Click
        If String.IsNullOrEmpty(cboGroupField.Text) Then
            MessageBox.Show("Please select the field to be used for grouping data before adding", _
                "Missing Group Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSortFields.Focus()
            Exit Sub
        End If
        dGridGroups.Rows.Add(1)
        dGridGroups.Rows(dGridGroups.Rows.Count - 1).Cells(0).Value = cboGroupField.Text
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        txtSql.Clear()
        dGrid.DataSource = Nothing
        dGrid.Rows.Clear()
        dGridFields.Rows.Clear()
        dGridGroups.Rows.Clear()
        dGridSorts.Rows.Clear()
        cboGroupField.Items.Clear()
        cboSortFields.Items.Clear()
        txtResults.Clear()
        dGridRelations.Rows.Clear()
    End Sub
    '0774426336

    Private Sub cboFilterTableName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFilterTableName.SelectedIndexChanged
        On Error GoTo RaiseErr
        'Get the field names from the selected table
        cboTableField.Items.Clear() : cboDataType.Items.Clear()
        Dim strTempTableName As String = cboFilterTableName.Text
        Dim dt_field As System.Data.DataTable = _
                    cnn.GetOleDbSchemaTable( _
                        OleDb.OleDbSchemaGuid.Columns, _
                        New Object() {Nothing, Nothing, strTempTableName})
        For Each dr_field As DataRow In dt_field.Rows
            cboTableField.Items.Add(dr_field("COLUMN_NAME").ToString)
            cboDataType.Items.Add(dr_field("DATA_TYPE").ToString)
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
    End Sub

    Private Sub btnAddFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFilter.Click
        If String.IsNullOrEmpty(cboFilterTableName.Text) Or String.IsNullOrEmpty(cboTableField.Text) Or _
            String.IsNullOrEmpty(cboComparison.Text) Or String.IsNullOrEmpty(txtValue.Text) Then
            MessageBox.Show("One or more of the filter data items is not set.", _
                "Missing Mandatory Filter Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim strCombination As String = "AND"
        If String.IsNullOrEmpty(cboCombination.Text) Then strCombination = "AND" Else strCombination = cboCombination.Text
        dGridFilter.Rows.Add(1)
        dGridFilter.Rows(dGridFilter.Rows.Count - 1).Cells(0).Value = cboFilterTableName.Text & "." & cboTableField.Text
        dGridFilter.Rows(dGridFilter.Rows.Count - 1).Cells(1).Value = cboComparison.Text
        Replace(txtValue.Text, Chr(39), 1)
        If CInt(cboDataType.Items(cboTableField.SelectedIndex).ToString) <= 5 Then
            dGridFilter.Rows(dGridFilter.Rows.Count - 1).Cells(2).Value = txtValue.Text
        Else
            dGridFilter.Rows(dGridFilter.Rows.Count - 1).Cells(2).Value = Chr(39) & txtValue.Text & Chr(39)
        End If
        dGridFilter.Rows(dGridFilter.Rows.Count - 1).Cells(3).Value = strCombination
    End Sub

    Private Sub cboLeftTable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLeftTable.SelectedIndexChanged
        On Error GoTo RaiseErr
        'Get the field names from the selected table
        cboLeftField.Items.Clear()
        Dim strTempTableName As String = cboLeftTable.Text
        Dim dt_field As System.Data.DataTable = _
                    cnn.GetOleDbSchemaTable( _
                        OleDb.OleDbSchemaGuid.Columns, _
                        New Object() {Nothing, Nothing, strTempTableName})
        For Each dr_field As DataRow In dt_field.Rows
            cboLeftField.Items.Add(dr_field("COLUMN_NAME").ToString)
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
    End Sub

    Private Sub cboRightTable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRightTable.SelectedIndexChanged
        On Error GoTo RaiseErr
        'Get the field names from the selected table
        cboRightField.Items.Clear()
        Dim strTempTableName As String = cboRightTable.Text
        Dim dt_field As System.Data.DataTable = _
                    cnn.GetOleDbSchemaTable( _
                        OleDb.OleDbSchemaGuid.Columns, _
                        New Object() {Nothing, Nothing, strTempTableName})
        For Each dr_field As DataRow In dt_field.Rows
            cboRightField.Items.Add(dr_field("COLUMN_NAME").ToString)
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
    End Sub

    Private Sub btnAddJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddJoin.Click
        If String.IsNullOrEmpty(cboJoinType.Text) Then
            MessageBox.Show("You must specify either one of the join types", _
                "Invalid Join Type Option", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboJoinType.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboLeftTable.Text) Or String.IsNullOrEmpty(cboLeftField.Text) _
            Or String.IsNullOrEmpty(cboRightTable.Text) Or String.IsNullOrEmpty(cboRightField.Text) Then
            MessageBox.Show("You must select the items from each of the drop down boxes", _
                "Invalid Join Items", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboLeftTable.Focus()
            Exit Sub
        End If
        Dim strJoinType As String = "InnerJoin"

        'Left Outer Join
        'Left Inner Join

        If UCase(cboJoinType.Text) = UCase("Left Outer Join") Then strJoinType = "OuterJoin"
        dGridRelations.Rows.Add(1)
        dGridRelations.Rows(dGridRelations.Rows.Count - 1).Cells(0).Value = cboLeftTable.Text
        dGridRelations.Rows(dGridRelations.Rows.Count - 1).Cells(1).Value = cboLeftField.Text
        dGridRelations.Rows(dGridRelations.Rows.Count - 1).Cells(2).Value = cboRightTable.Text
        dGridRelations.Rows(dGridRelations.Rows.Count - 1).Cells(3).Value = cboRightField.Text
        dGridRelations.Rows(dGridRelations.Rows.Count - 1).Cells(4).Value = strJoinType
    End Sub

    Private Sub LoadFonts()
        cboFooterFont.Items.Clear() : cboHeaderFont.Items.Clear() : cboDetailsFont.Items.Clear()
        'Load the system fonts
        Dim installed_fonts As New InstalledFontCollection
        'Get an array of the system's installed fonts
        Dim font_families() As FontFamily = installed_fonts.Families
        'Load the fonts to the combo box
        For Each FontFamily As FontFamily In font_families
            cboFooterFont.Items.Add(FontFamily.Name)
            cboHeaderFont.Items.Add(FontFamily.Name)
            cboDetailsFont.Items.Add(FontFamily.Name)
        Next
    End Sub

    Private Sub mnuPreviewReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPreviewReport.Click
        boolPreviewReport = True
        PrintReport()
    End Sub

    Private Sub PrintReport()
        On Error GoTo RaiseErr
        'Check that the variables are correctly set
        If dGrid.Rows.Count <= 0 Then
            MessageBox.Show("Please generate the query and then run it before preview or printing data. Results must not be empty", _
                "Missing Print Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtPageHeader.Text) Then
            MessageBox.Show("A report must have a title. Please type it in with all its properties", _
                "Invalid Report Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPageHeader.Focus()
            Exit Sub
        End If

        'Get the number of columns to be printed
        intColumns = 0
        Dim i As Integer = 0
        strColumnHeaders = Nothing
        strColumnSizes = Nothing
        strColumnFormating = Nothing
        strColumnAlignment = Nothing
        strColumnTotals = Nothing
        strPrintColumns = Nothing

        For i = 0 To dgridReportFieldProperty.Rows.Count - 1
            If dgridReportFieldProperty.Rows(i).Cells(0).Value = True Then
                'Get the width, alignment, formating, totaling values
                If Not (Object.Equals(Convert.ToString(dgridReportFieldProperty.Rows(i).Cells(2).Value), "")) Then
                    strColumnHeaders = strColumnHeaders & Convert.ToString(dgridReportFieldProperty.Rows(i).Cells(2).Value) & "|"
                Else
                    strColumnHeaders = strColumnHeaders & "|"
                End If
                If Not (Object.Equals(Convert.ToString(dgridReportFieldProperty.Rows(i).Cells(3).Value), "")) Then
                    'Check that the size is an integer. If not set it to zero
                    If IsNumeric(dgridReportFieldProperty.Rows(i).Cells(3).Value.ToString) Then
                        strColumnSizes = strColumnSizes & Convert.ToString(dgridReportFieldProperty.Rows(i).Cells(3).Value) & "|"
                    Else
                        strColumnSizes = strColumnSizes & "0|"
                    End If
                Else
                    strColumnSizes = strColumnSizes & "0|"
                End If
                If Not (Object.Equals(Convert.ToString(dgridReportFieldProperty.Rows(i).Cells(4).Value), "")) Then
                    strColumnFormating = strColumnFormating & Convert.ToString(dgridReportFieldProperty.Rows(i).Cells(4).Value) & "|"
                Else
                    strColumnFormating = strColumnFormating & "NO|"
                End If
                If Not (Object.Equals(Convert.ToString(dgridReportFieldProperty.Rows(i).Cells(5).Value), "")) Then
                    Select Case UCase(dgridReportFieldProperty.Rows(i).Cells(5).Value.ToString)
                        Case Is = "RIGHT"
                            strColumnAlignment = strColumnAlignment & "2" & "|"
                        Case Is = "CENTER"
                            strColumnAlignment = strColumnAlignment & "1" & "|"
                        Case Else
                            strColumnAlignment = strColumnAlignment & "0" & "|"
                    End Select

                Else
                    strColumnHeaders = strColumnHeaders & "0|"
                End If
                If Not (Object.Equals(Convert.ToString(dgridReportFieldProperty.Rows(i).Cells(6).Value), "")) Then
                    strColumnTotals = strColumnTotals & Convert.ToString(dgridReportFieldProperty.Rows(i).Cells(6).Value) & "|"
                Else
                    strColumnTotals = strColumnTotals & "NO|"
                End If
                intColumns += 1
                strPrintColumns = strPrintColumns & CStr(i) & "|"
            End If
        Next
        If intColumns <= 0 Then
            MessageBox.Show("No fields have been selected for print. Make sure you have checked the fields you want printed", _
                "No Fields To Print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Take off the extra pipe on the column properties
        strColumnAlignment = Mid(strColumnAlignment, 1, (strColumnAlignment.Length - 1))
        strColumnFormating = Mid(strColumnFormating, 1, (strColumnFormating.Length - 1))
        strColumnHeaders = Mid(strColumnHeaders, 1, (strColumnHeaders.Length - 1))
        strColumnSizes = Mid(strColumnSizes, 1, (strColumnSizes.Length - 1))
        strColumnTotals = Mid(strColumnTotals, 1, (strColumnTotals.Length - 1))
        strPrintColumns = Mid(strPrintColumns, 1, (strPrintColumns.Length - 1))

        If Not String.IsNullOrEmpty(cboHeaderFont.Text) Then strHeaderFontName = cboHeaderFont.Text
        If Not String.IsNullOrEmpty(cboFooterFont.Text) Then strFooterFontName = cboFooterFont.Text
        If Not String.IsNullOrEmpty(cboDetailsFont.Text) Then strDetailFontName = cboDetailsFont.Text

        If Not String.IsNullOrEmpty(cboHeaderFontSize.Text) And CInt(cboHeaderFontSize.Text) <> 8 Then
            intHeaderFontSize = CInt(cboHeaderFontSize.Text)
        End If
        If Not String.IsNullOrEmpty(cboDetailsFontSize.Text) And CInt(cboDetailsFontSize.Text) <> 8 Then
            intDetailFontSize = CInt(cboDetailsFontSize.Text)
        End If
        If Not String.IsNullOrEmpty(cboFooterSize.Text) And CInt(cboFooterSize.Text) <> 6 Then
            intFooterFontSize = CInt(cboFooterSize.Text)
        End If

        If strHeaderFontName <> "Arial" Or intHeaderFontSize <> 8 Then
            fntHeaderFont = New System.Drawing.Font(strHeaderFontName, intHeaderFontSize, FontStyle.Bold, GraphicsUnit.Point)
            strHeaderFontFullNames = strHeaderFontName & ", " & intHeaderFontSize & ", FontStyle.Regular, GraphicsUnit.Point"
        End If
        If strDetailFontName <> "Arial" Or intDetailFontSize <> 8 Then
            fntDetailsFont = New System.Drawing.Font(strDetailFontName, intDetailFontSize, FontStyle.Regular, GraphicsUnit.Point)
            strFooterFontFullNames = strDetailFontName & ", " & intDetailFontSize & ", FontStyle.Regular, GraphicsUnit.Point"
        End If
        If strFooterFontName <> "Arial" Or intDetailFontSize <> 8 Then
            fntFooterFont = New System.Drawing.Font(strFooterFontName, intDetailFontSize, FontStyle.Regular, GraphicsUnit.Point)
            strDetailFontFullNames = strFooterFontName & ", " & intFooterFontSize & ", FontStyle.Regular, GraphicsUnit.Point"
        End If

        'Before proceeding to print, make sure that the total line size can fit into the page
        Dim intRowSize As Integer = 200 'We start at 200 because we will always leave an inch from left and right of the page border
        Dim strSizes() As String = Split(strColumnSizes, "|")
        For i = 0 To strSizes.Length - 1
            If IsNumeric(strSizes(i)) Then
                intRowSize = intRowSize + CInt(strSizes(i))
            Else
                intRowSize = intRowSize + 0
            End If
        Next

        Dim myReport As New SmartColumnReportWriter.SmartColumnReportWriter
        Dim DocumentPreview As New PrintPreviewDialog

        Dim PrinterPageWidth As Integer = myReport.DefaultPageSettings.PaperSize.Width
        If PrinterPageWidth < intRowSize Then
            MessageBox.Show("The report rows fall over the default printer width. Please respecify print column widths", _
                "Printer Width Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Get the font colors

        If Not String.IsNullOrEmpty(cboFooterColor.Text) And UCase(cboFooterColor.Text) <> "DEFAULT" Then
            strFooterForeColor = cboFooterColor.Text
        End If
        If Not String.IsNullOrEmpty(cboHeaderColor.Text) And UCase(cboHeaderColor.Text) <> "DEFAULT" Then
            strHeaderForeColor = cboHeaderColor.Text
        End If
        If Not String.IsNullOrEmpty(cboDetailsFontColor.Text) And UCase(cboDetailsFontColor.Text) <> "DEFAULT" Then
            strDetailForeColor = cboDetailsFontColor.Text
        End If

        If Not String.IsNullOrEmpty(cboPrintBorder.Text) And cboPrintBorder.Text = "True" Then
            boolPrintBorder = True
            strPrintBorder = "True"
            'Get the border color
            If Not String.IsNullOrEmpty(cboBorderColor.Text) And UCase(cboBorderColor.Text) <> "DEFAULT" Then
                strBorderColor = cboBorderColor.Text
            End If
        End If

        If Not String.IsNullOrEmpty(cboGridLines.Text) And UCase(cboGridLines.Text) <> "NONE" Then
            If UCase(cboGridLines.Text) = "VERTICAL" Then
                boolVerticalLines = True
            End If
            If UCase(cboGridLines.Text) = "HORIZONTAL" Then
                boolHorizontalLines = True
            End If
            If UCase(cboGridLines.Text) = "BOTH" Then
                boolVerticalLines = True
                boolHorizontalLines = True
            End If
            If Not String.IsNullOrEmpty(cboGridColor.Text) And UCase(cboGridColor.Text) <> "DEFAULT" Then
                strGridLinesColor = cboGridColor.Text
            End If
        End If

        If chkPrintSummary.Checked = True Then boolPrintSummary = True
        If chkDrawChart.Checked = True Then boolDrawGraph = True
        If chkPrintFinalTotals.Checked = True Then boolPrintFinalTotals = True

        If Not String.IsNullOrEmpty(cboGroupIndex.Text) And UCase(cboGroupIndex.Text) <> "NO" Then
            If CInt(cboGroupIndex.Text) <= intColumns Then
                boolGroupData = True
                intBreakIndex = CInt(cboGroupIndex.Text)
            End If
        End If

        'Get the highlight colors and fields as well
        strHighlights = Nothing
        For i = 0 To dGridHighLights.Rows.Count - 1
            With dGridHighLights
                strHighlights = strHighlights & .Rows(i).Cells(0).Value.ToString & ":" & _
                .Rows(i).Cells(1).Value.ToString & ":" & _
                .Rows(i).Cells(2).Value.ToString & "|"
            End With
        Next
        If Not String.IsNullOrEmpty(strHighlights) Then
            strHighlights = Mid(strHighlights, 1, (strHighlights.Length - 1))
        End If
        'Build the print details string based on the checked fields
        'For each column value, remove the semicolon so that the class does not fall over
        With frmLight8.pb1
            .Visible = True
            .Value = 0
            .Maximum = dGrid.Rows.Count
        End With
        'lblStatus.Text = "Processing Report. Please Wait !!!"
        Cursor = Cursors.WaitCursor
        Dim strPrintDetails(dGrid.Rows.Count - 1) As String
        Dim strSplitter() As String = Split(strPrintColumns, "|")
        For i = 0 To dGrid.Rows.Count - 1
            Dim n As Integer = 0
            For n = 0 To strSplitter.Length - 1
                strPrintDetails(i) = strPrintDetails(i) & dGrid.Rows(i).Cells(CInt(strSplitter(n))).Value.ToString & ";"
            Next
            If Not String.IsNullOrEmpty(strPrintDetails(i)) Then
                strPrintDetails(i) = Mid(strPrintDetails(i), 1, (strPrintDetails(i).Length - 1))
            End If
            frmLight8.pb1.Value = frmLight8.pb1.Value + 1
        Next
        frmLight8.pb1.Value = frmLight8.pb1.Maximum
        With myReport
            .intNumberOfColumns = intColumns
            .intPrintRecordsCount = dGrid.Rows.Count 'Or number of records in the text file
            .strColumnAlignments = strColumnAlignment
            .strColumnFormating = strColumnFormating
            .strColumnHeaders = strColumnHeaders
            .strColumnWidths = strColumnSizes
            .strColumnTotals = strColumnTotals
            .FooterColor = Color.FromName(strFooterForeColor)
            .TitleColor = Color.FromName(strHeaderForeColor)
            .DetailColor = Color.FromName(strDetailForeColor)
            .boolGroupDetails = boolGroupData
            .boolPrintTotals = boolPrintFinalTotals
            .boolGenericReport = True
            .intKeyFieldIndex = intBreakIndex
            .PrintSummary = boolPrintSummary
            .DrawBorder = boolPrintBorder
            .BorderColor = Color.FromName(strBorderColor)
            .DrawSummaryChart = boolDrawGraph
            .VerticalLines = boolVerticalLines
            .HorizontalLines = boolHorizontalLines
            .GridColor = Color.FromName(strGridLinesColor)
            .strPrintValues = strPrintDetails
            .strMainCaption = txtPageHeader.Text
            .strFooterCaption = TxtFooterTitle.Text
            .DetailFont = fntDetailsFont
            .HeaderFont = fntHeaderFont
            .FooterFont = fntFooterFont
            .strHighlightColors = strHighlights
        End With
        frmLight8.pb1.Visible = False
        Cursor = Cursors.Default
        DocumentPreview.Document = myReport
        If boolPreviewReport = True Then
            DocumentPreview.ShowDialog()
        Else
            myReport.Print()
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
    End Sub

    Private Sub tabReport_SelectedPageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabReport.SelectedTabChanged
        On Error Resume Next
        If TabControl1.SelectedTab.Text = "Report Properties" Then
            'Get the details entered in the fields grid across to the field selection grid
            If dgridReportFieldProperty.Rows.Count > 0 Then
                If MessageBox.Show("Do you want to clear prior column setting or to preserve them?", _
                    "Clear Prior Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                    dgridReportFieldProperty.Rows.Clear()
                Else
                    Exit Sub
                End If
            End If
            Dim i As Integer = 0
            For i = 0 To dGridFields.Rows.Count - 1
                dgridReportFieldProperty.Rows.Add(1)
                dgridReportFieldProperty.Rows(dgridReportFieldProperty.Rows.Count - 1).Cells(1).Value = dGridFields.Rows(i).Cells(1).Value.ToString
                dgridReportFieldProperty.Rows(dgridReportFieldProperty.Rows.Count - 1).Cells(2).Value = dGridFields.Rows(i).Cells(2).Value.ToString
            Next
        End If
    End Sub

    Private Sub mnuPrintReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuPrintReport.Click
        boolPreviewReport = False
        PrintReport()
    End Sub

    Private Sub btnAddHighLight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddHighLight.Click
        Dim strHighColor As String = "Red"
        If Not IsNumeric(txtColumnNumber.Text) Then
            MessageBox.Show("Please enter a numeric value for the column index", _
                "Invalid Column Index", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtColumnNumber.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtColumnValue.Text) Then
            MessageBox.Show("Please enter the value of the string that will be evaluated", _
                "Invalid Evaluation String", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtColumnValue.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(cboHighlightColor.Text) Then
            MessageBox.Show("Please select the highlight color from the list provided", _
                "Invalid Color Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboHighlightColor.Focus()
            Exit Sub
        Else
            If cboHighlightColor.Text <> "Default" Then
                strHighColor = cboHighlightColor.Text
            End If
        End If
        With dGridHighLights
            .Rows.Add(1)
            .Rows(.Rows.Count - 1).Cells(0).Value = txtColumnNumber.Text
            .Rows(.Rows.Count - 1).Cells(1).Value = txtColumnValue.Text
            .Rows(.Rows.Count - 1).Cells(2).Value = strHighColor
        End With
    End Sub

    Private Sub cboSourceData_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSourceData.SelectedIndexChanged
        If cboSourceData.Text = "Count" Then dgridCharting.Enabled = False
    End Sub

    Private Sub ChartingByCount()
        On Error GoTo RaiseErr
        If dGrid.Rows.Count <= 0 Then
            MessageBox.Show("No query results have been generated. Chart will not be printed", _
                "Query Not Generated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If IsNumeric(txtChartColumnIndex.Text) Then
            If CInt(txtChartColumnIndex.Text) < dGridFields.Rows.Count Then
                'It means this is correct
            Else
                MessageBox.Show("Please enter a valid column number for which a chart is to be generated", _
                    "Invalid Column Index", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Else
            MessageBox.Show("Please enter a valid column number for which a chart is to be generated", _
                "Invalid Column Index", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim i As Integer = 0
        Dim strFactors As String = Nothing
        For i = 0 To dGrid.Rows.Count - 1
            If i = 0 Then
                strFactors = dGrid.Rows(i).Cells(CInt(txtChartColumnIndex.Text)).Value.ToString & "|"
            Else
                Dim SearchFor As String = dGrid.Rows(i).Cells(CInt(txtChartColumnIndex.Text)).Value.ToString
                Dim rex As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex(SearchFor)
                Dim count As Integer = rex.Matches(strFactors).Count
                If count = 0 Then
                    strFactors = strFactors & dGrid.Rows(i).Cells(CInt(txtChartColumnIndex.Text)).Value.ToString & "|"
                End If
            End If
        Next
        If Not String.IsNullOrEmpty(strFactors) Then
            strFactors = Mid(strFactors, 1, (strFactors.Length - 1))
        Else
            MessageBox.Show("There was an error in retrieving the specified column factors. Please recheck your parameters", _
                "Charting Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'Now that we have the unique factors, we are going to take a count of each
        Dim strCounts As String = Nothing
        Dim strKeys() As String = Split(strFactors, "|")
        Dim intCounts(0 To strKeys.Length - 1) As Integer
        For i = 0 To dGrid.Rows.Count - 1
            Dim n As Integer = 0
            For n = 0 To strKeys.Length - 1
                If dGrid.Rows(i).Cells(CInt(txtChartColumnIndex.Text)).Value.ToString = strKeys(n) Then
                    intCounts(n) = intCounts(n) + 1
                End If
            Next
        Next
        'send the values to the print chart form
        Dim yvalOne As Integer() = intCounts '{intMales, intFemales}
        Dim xvalOne As String() = strKeys '{"Males", "Females"}
        'Chart1.Series("Series1").Points.DataBindXY(xvalOne, yvalOne)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
    End Sub

    Private Sub btnPreviewChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviewChart.Click
        ChartingByCount()
    End Sub

    Private Sub mnuSaveReportOnly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveReportOnly.Click
        SaveReport()
    End Sub

    Private Sub SaveReport()
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(strPrintColumns) Then
            MessageBox.Show("Report cannot be saved now. Either you have not run the query or " & vbCrLf & _
                    "set and runthe report. Run and preview report before saving it", "No Report To Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim strFileName As String = Nothing
        SaveFileDialog1.ShowDialog()
        strFileName = SaveFileDialog1.FileName
        If String.IsNullOrEmpty(strFileName) Then Exit Sub
        Dim i As Integer = 0
        'lblStatus.Text = "Processing Report. Please Wait !!!"
        Cursor = Cursors.WaitCursor
        With frmLight8.pb1
            .Visible = True
            .Value = 0
            .Maximum = dGrid.Rows.Count
        End With
        Dim objWriter As New StreamWriter(strFileName, False)
        Dim strPrintDetails(dGrid.Rows.Count - 1) As String
        Dim strSplitter() As String = Split(strPrintColumns, "|")
        For i = 0 To dGrid.Rows.Count - 1
            Dim n As Integer = 0
            For n = 0 To strSplitter.Length - 1
                strPrintDetails(i) = strPrintDetails(i) & dGrid.Rows(i).Cells(CInt(strSplitter(n))).Value.ToString & ";"
            Next
            If Not String.IsNullOrEmpty(strPrintDetails(i)) Then
                strPrintDetails(i) = Mid(strPrintDetails(i), 1, (strPrintDetails(i).Length - 1))
            End If
            objWriter.WriteLine(strPrintDetails(i))
            frmLight8.pb1.Value = frmLight8.pb1.Value + 1
        Next
        objWriter.Close()
        Cursor = Cursors.Default
        MessageBox.Show("Report details have been saved successfully", "Process Completed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        On Error Resume Next
        boolAbort = True : objWriter.Close()
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number
        ShowErrorMessage()
    End Sub

    Private Sub mnuSaveStructureOnly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveStructureOnly.Click
        'boolAbort = True
        'Dim f As New frmSaveColumnReport
        'f.ShowDialog()
        'If boolAbort = False Then SaveStructure()
    End Sub

    Private Sub SaveStructure()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        strSql = "INSERT INTO ColumnReports (ReportName, QueryStatement, NumberOfColumns, " _
            & "PrintRecordsCount, ColumnAlignments, ColumnFormating, ColumnHeaders, ColumnWidths, " _
            & "ColumnTotals, FooterColor, TitleColor, DetailColor, GroupDetails, PrintTotals, " _
            & "GenericReport, KeyFieldIndex, PrintSummary, DrawBorder, BorderColor, DrawSummaryChart, " _
            & "VerticalLines, HorizontalLines, GridColor, MainCaption, FooterCaption, DetailFont, " _
            & "HeaderFont, FooterFont, HighlightColors) VALUES ('" & strReportName & "', '" & txtSql.Text & "', " & intColumns & ", " _
            & "" & dGrid.Rows.Count & ", '" & strColumnAlignment & "', '" & strColumnFormating & "', " _
            & "'" & strColumnHeaders & "', '" & strColumnSizes & "', '" & strColumnTotals & "', " _
            & "'" & strFooterForeColor & "', '" & strHeaderForeColor & "', '" & strDetailForeColor & "', " _
            & "'" & boolGroupData.ToString() & "', '" & CStr(boolPrintFinalTotals) & "', 'True', " _
            & "" & intBreakIndex & ", '" & CStr(boolPrintSummary) & "', '" & strPrintBorder & "', " _
            & "'" & strGridLinesColor & "', '" & CStr(boolDrawGraph) & "', '" & CStr(boolVerticalLines) & "', " _
            & "'" & CStr(boolHorizontalLines) & "', '" & strGridLinesColor & "', '" & txtPageHeader.Text & "', " _
            & "'" & TxtFooterTitle.Text & "', '" & strDetailFontFullNames & "', '" & strHeaderFontFullNames & "', " _
            & "'" & strFooterFontFullNames & "', '" & strHighlights & "')"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        MessageBox.Show("Report structure has been saved successfully", "Process Completed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number
        ShowErrorMessage()
    End Sub

    Private Sub mnuSaveBoth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveBoth.Click
        SaveReport()
        SaveStructure()
    End Sub

    Private Sub btnNewConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewConnection.Click
        Dim x As String = InputBox("Please enter the new connection database name", "Connection Database Name", 200, 40)
        'If Not String.IsNullOrEmpty(x) Then
        '    'Get the new connection name 
        '    cnn.Close()
        '    cnn.ConnectionString = "data source=.\SQLExpress;initial catalog=TkcDriving;integrated security=SSPI;persist security info=False;Enlist=True;Pooling=False;Connection Lifetime=30;provider=SQLOLEDB"
        '    cnn.Open()
        '    boolIsLoading = True
        '    LoadTables()
        '    LoadFonts()
        '    boolIsLoading = False
        'End If
    End Sub

    Private Sub frmSqlQueries_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        intPriorSplitterDistance = KryptonSplitContainer1.Width - KryptonSplitContainer1.Panel2.Width
        Me.SuspendLayout()
        AdjustPanes()
        Me.Refresh()
        Me.ResumeLayout()
    End Sub

    Private Sub btnPrintWysiwhyg_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintWysiwhyg.Click
        Dim m_print As New PrintControl.ControlPrint
        m_print.SetControl(dGrid)
        Dim ppd As New EnhancedPrintPreviewDialog
        ppd.Document = DirectCast(m_print, PrintDocument)
        ppd.ShowDialog()
    End Sub

End Class
