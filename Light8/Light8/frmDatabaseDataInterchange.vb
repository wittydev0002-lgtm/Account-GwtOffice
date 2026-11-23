Imports Microsoft.SqlServer.Management.Smo
Imports System.Collections.Specialized
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDatabaseDataInterchange

    Dim connSource As Data.OleDb.OleDbConnection
    Dim arrScriptLines As ArrayList
    Dim arrExtraTables As ArrayList

    Private Sub ProcessData(ByVal TableName As String)

        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor

        Dim strDataInsertSql As String = Nothing

        Dim strSql As String = Nothing
        strSql = ScriptTableFields(TableName, "SELECT", connSource)
        strDataInsertSql = strDataInsertSql & ScriptDataInsertStatement(strSql, TableName, connSource)

        Dim objCommand As Data.OleDb.OleDbCommand
        If optClearInsert.Checked = True Then
            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM " & TableName & "", cnn)
            objCommand.ExecuteNonQuery()
        End If

        Dim strDatalines() As String = Split(strDataInsertSql, vbCrLf)
        With pb1
            .Value = 0
            .Visible = True
            .Maximum = strDatalines.Length + 10
        End With

        Dim intIndex As Integer = 0
        For p As Integer = 0 To strDatalines.Length - 1
            intIndex = p
            If Not String.IsNullOrEmpty(strDatalines(p)) Then
                objCommand = New Data.OleDb.OleDbCommand(strDatalines(p), cnn)
                objCommand.ExecuteNonQuery()
            End If
            pb1.Value = pb1.Value + 1
        Next
        pb1.Value = pb1.Maximum

        Exit Sub
RaiseErr:
        If Err.Number = 5 Then
            Dim objFile As New System.IO.StreamWriter(Application.StartupPath & "\ImportDuplicates.txt", True)
            objFile.WriteLine(strDatalines(intIndex))
            objFile.Close()
            Resume Next
        Else
            boolAbort = True
            Cursor = Cursors.Default
            strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Table-to-Table Data Imports"
            gwt_comm.ShowErrorMessage()
        End If
    End Sub

    Private Sub ConnectToSourceDatabase()
        On Error GoTo RaiseErr
        Cursor = Cursors.WaitCursor
        'Connect to the source database
        Dim strSourceConnectionString As String = "data source=" & txtSourceServerName.Text & ";" _
            & "initial catalog=" & txtSourceDatabaseName.Text & ";" _
            & "User ID=" & txtSourceLoginName.Text & ";" _
            & "Password=" & txtSourceLoginPassword.Text & ";provider=SQLOLEDB"
        connSource = New Data.OleDb.OleDbConnection(strSourceConnectionString)
        connSource.Open()

        'Load the tables from the source database
        cboSourceTable.Items.Clear()
        Dim SchemaTable As DataTable
        SchemaTable = connSource.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, Nothing})
        For int As Integer = 0 To SchemaTable.Rows.Count - 1
            If SchemaTable.Rows(int)!TABLE_TYPE.ToString = "TABLE" Then
                Dim strTempTableName As String = SchemaTable.Rows(int)!TABLE_NAME.ToString()
                cboSourceTable.Items.Add(strTempTableName)
            End If
        Next

        gpOptions.Enabled = True
        cboSourceTable.Enabled = True

        Cursor = Cursors.Default
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Source database connection"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtSourceServerName.Text) Then
            MessageBox.Show("Please enter the source database server name or address", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSourceServerName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtSourceDatabaseName.Text) Then
            MessageBox.Show("Please enter the source database name", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSourceDatabaseName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtSourceLoginName.Text) Then
            MessageBox.Show("Please enter the source server login name", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSourceLoginName.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtSourceLoginPassword.Text) Then
            MessageBox.Show("There is no password to the source server. This may or may not be correct", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSourceLoginPassword.Focus()
        End If
        If String.IsNullOrEmpty(cboSourceTable.Text) Then
            MessageBox.Show("Please select the source table from the list given", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSourceTable.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        boolAbort = False
        ScriptTable(cboSourceTable.Text)
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        If optAppend.Checked = False And optClearInsert.Checked = False Then
            MessageBox.Show("Please choose how the data is to be inserted in the destination table" & vbCrLf & _
                            "You can choose to clear the data in the destination table before inserting " & vbCrLf & _
                            "data from the source table or you can choose to append data from the source " & vbCrLf & _
                            "table to the destination database table", "Missing Input Option", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            optAppend.Focus()
            Exit Sub
        End If

        ' Check that the selected exists if not then request the user to confirm whether to create it or not
        If gwt_comm.CheckTableExistence(cboSourceTable.Text) = False Then
            If MessageBox.Show("This table does not exist in the target database. Do you want to create it?", "Confirm Table Creation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'Create the table based on the source table schema
                For p As Integer = 0 To arrScriptLines.Count - 1
                    If Not String.IsNullOrEmpty(arrScriptLines.Item(p)) Then
                        Dim objCommand As New Data.OleDb.OleDbCommand(arrScriptLines(p), cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                Next
            Else
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        boolAbort = False
        ProcessData(cboSourceTable.Text)
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        Cursor = Cursors.Default
        MessageBox.Show("Data from source database updated to your current database successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Table-to-Table data import failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub ScriptTable(ByVal TableName As String)
        On Error GoTo RaiseErr
        Dim myServer As New Server(txtSourceServerName.Text)
        Dim myScripter As New Scripter
        Dim myDatabase As Database = myServer.Databases(txtSourceDatabaseName.Text)
        Dim myTable As Table = myDatabase.Tables(TableName)

        ' Generate sripts of table along with all objects on which this table depends on

        Dim myScriptOption As New ScriptingOptions()
        myScriptOption.WithDependencies = True
        myScriptOption.DriAll = True
        myScriptOption.FileName = Application.StartupPath & "\SqlScript.sql"
        Dim tableScripts As StringCollection = myTable.Script(myScriptOption)

        arrScriptLines = New ArrayList
        For Each Scpt As String In tableScripts
            arrScriptLines.Add(Scpt)
        Next

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Source database table scripting"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnConnect_Click(sender As System.Object, e As System.EventArgs) Handles btnConnect.Click
        boolAbort = False
        ConnectToSourceDatabase()
        If boolAbort = True Then Exit Sub
        btnOk.Enabled = True
        btnMatchAll.Enabled = True
        btnUpdateQuanties.Enabled = True
    End Sub

    Private Function ExtraTables() As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList

        Dim arrCurrentConnectionTables As New ArrayList

        Cursor = Cursors.WaitCursor

        'Load the tables from the source database
        Dim SchemaTable As DataTable
        SchemaTable = cnn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, Nothing})
        For int As Integer = 0 To SchemaTable.Rows.Count - 1
            If SchemaTable.Rows(int)!TABLE_TYPE.ToString = "TABLE" Then
                Dim strTempTableName As String = SchemaTable.Rows(int)!TABLE_NAME.ToString()
                arrCurrentConnectionTables.Add(strTempTableName)
            End If
        Next

        For p As Integer = 0 To cboSourceTable.Items.Count - 1
            Dim ActiveTable As String = cboSourceTable.Items(p)
            Dim boolExists As Boolean = False
            For z As Integer = 0 To arrCurrentConnectionTables.Count - 1
                If UCase(ActiveTable) = UCase(arrCurrentConnectionTables.Item(z)) Then
                    boolExists = True
                    Exit For
                End If
            Next
            If boolExists = False Then
                arrReturn.Add(ActiveTable)
            End If
        Next

        Return arrReturn
        Cursor = Cursors.Default
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Source database tables matching"
        gwt_comm.ShowErrorMessage()
    End Function

    Private Sub btnMatchAll_Click(sender As System.Object, e As System.EventArgs) Handles btnMatchAll.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(txtSourceServerName.Text) Then
            MessageBox.Show("Please enter the source database server name or address", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSourceServerName.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtSourceDatabaseName.Text) Then
            MessageBox.Show("Please enter the source database name", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSourceDatabaseName.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtSourceLoginName.Text) Then
            MessageBox.Show("Please enter the source server login name", "Invalid Data Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSourceLoginName.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtSourceLoginPassword.Text) Then
            MessageBox.Show("There is no password to the source server. This may or may not be correct", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtSourceLoginPassword.Focus()
            Cursor = Cursors.Default
        End If

        If optAppend.Checked = False And optClearInsert.Checked = False Then
            MessageBox.Show("Please choose how the data is to be inserted in the destination table" & vbCrLf & _
                            "You can choose to clear the data in the destination table before inserting " & vbCrLf & _
                            "data from the source table or you can choose to append data from the source " & vbCrLf & _
                            "table to the destination database table", "Missing Input Option", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            optAppend.Focus()
            Cursor = Cursors.Default
            Exit Sub
        End If


        Dim arrAffectedTables As New ArrayList

        boolAbort = False
        arrAffectedTables = ExtraTables()
        If boolAbort = True Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        For z As Integer = 0 To arrAffectedTables.Count - 1
            ' Check that the selected exists if not then request the user to confirm whether to create it or not
            If gwt_comm.CheckTableExistence(arrAffectedTables.Item(z)) = False Then
                ScriptTable(arrAffectedTables.Item(z))
                For p As Integer = 0 To arrScriptLines.Count - 1
                    If Not String.IsNullOrEmpty(arrScriptLines.Item(p)) Then
                        Dim objCommand As New Data.OleDb.OleDbCommand(arrScriptLines(p), cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                Next
            End If
            ProcessData(arrAffectedTables.Item(z))
        Next
        Cursor = Cursors.Default
        MessageBox.Show("Data from source database updated to your current database successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Table-to-Table data import failure"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmDatabaseDataInterchange_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 624 : Me.Height = 389
    End Sub

    Private Sub btnUpdateQuanties_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdateQuanties.Click
        On Error GoTo RaiseErr
        If String.IsNullOrEmpty(cboSourceTable.Text) Then
            MessageBox.Show("Please select the source table", "Missing Source Table", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboSourceTable.Focus()
            Exit Sub
        Else
            boolAbort = False
            strSelectedTableQuantityField = Nothing
            arrSelectedArray = New ArrayList
            arrSelectedArray = TableColumnNames(cboSourceTable.Text, connSource)
            Dim frm As New frmTableFields
            frm.showdialog()
            If boolAbort = True Then Exit Sub
            If String.IsNullOrEmpty(strSelectedTableQuantityField) Then
                MessageBox.Show("No quantity field has been defined from the source table", "Missing Table Field Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                Cursor = Cursors.WaitCursor
                Dim strSql As String = "SELECT " & strSourceTableKeyField & ", " _
                    & strSelectedTableQuantityField & " FROM " & cboSourceTable.Text & ""
                Dim objCommand As New Data.OleDb.OleDbCommand(strSql, connSource)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

                'Get the count of items
                Dim intCount As Integer = 0
                strSql = "SELECT COUNT (" & strSourceTableKeyField & ") FROM " & cboSourceTable.Text & ""
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                Dim objReadTotal As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReadTotal.HasRows Then
                    objReadTotal.Read()
                    If IsNumeric(objReadTotal(0).ToString) Then
                        intCount = CInt(objReadTotal(0).ToString)
                    End If
                End If
                objReadTotal.Close()

                With pb1
                    .Value = 0
                    .Visible = True
                    .Maximum = intCount + 10
                End With

                While objReader.Read

                    Dim dblQuantity As Double = 0
                    If IsNumeric(objReader(1).ToString) Then
                        dblQuantity = CDbl(objReader(1).ToString)
                    End If
                    'Get the current quantity 
                    objCommand = New Data.OleDb.OleDbCommand("SELECT " & strSelectedTableQuantityField & " FROM " & _
                        cboSourceTable.Text & " WHERE " & strSourceTableKeyField & " = '" & objReader(0).ToString & "'", cnn)
                    Dim objReadCount As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    If objReadCount.HasRows Then
                        objReadCount.Read()
                        If IsNumeric(objReadCount(0).ToString) Then
                            dblQuantity = dblQuantity + CDbl(objReadCount(0).ToString)
                        End If
                    End If
                    objReadCount.Close()

                    objCommand = New Data.OleDb.OleDbCommand("UPDATE " & cboSourceTable.Text & " SET " & _
                        strSelectedTableQuantityField & " = " & dblQuantity & " WHERE " & _
                        strSourceTableKeyField & " = '" & objReader(0).ToString & "'", cnn)
                    objCommand.ExecuteNonQuery()

                    pb1.Value = pb1.Value + 1

                End While
                objReader.Close()

                pb1.Value = pb1.Maximum

                Cursor = Cursors.Default
                MessageBox.Show("Process has been completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Table-to-Table data import failure"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
