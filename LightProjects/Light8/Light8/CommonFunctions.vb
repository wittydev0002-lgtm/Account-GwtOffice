Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Module CommonFunctions

    Public strSelectedTableQuantityField As String = Nothing
    Public strSourceTableKeyField As String = Nothing
    Public arrSelectedArray As ArrayList
    Public boolRegistrationSuccessfull As Boolean

    Public strLicenseData As String

    Public strDatabaseName As String
    Public strNewCompanyName As String
    Public strLoginName As String
    Public strServerName As String
    Public strPassword As String
    Public strAuthentication As String

    Public strNewInventoryItemCode As String
    Public strselectedShortCode As String

    Public arrSerialsCaptured As ArrayList
    Public dblSerializedCostPrice As Double

    Public strOrderDate As String
    Public intNewOrderNumber As Integer
    Public strOrderDescription As String
    Public strSelectedVatNumber As String
    Public strReceivingBranchName As String
   
    Public Function ScriptTableFields(TableName As String, ScriptType As String, dbConnection As Data.OleDb.OleDbConnection) As String
        On Error GoTo RaiseErr
        Dim strReturn As String = Nothing

        Dim dt_field As System.Data.DataTable = _
                    dbConnection.GetOleDbSchemaTable( _
                        OleDb.OleDbSchemaGuid.Columns, _
                        New Object() {Nothing, Nothing, TableName})
        'Add the field names to the treeview view 
        Dim n As Integer = 0

        Select Case UCase(ScriptType)
            Case Is = "INSERT"
                strReturn = "INSERT INTO " & TableName & " ("
            Case Is = "SELECT"
                strReturn = "SELECT "
        End Select

        For Each dr_field As DataRow In dt_field.Rows
            If UCase(dr_field("COLUMN_NAME").ToString) = UCase("TransId") Or _
                UCase(dr_field("COLUMN_NAME").ToString) = UCase("TransactionId") Then
                'If UCase(ScriptType) <> "INSERT" Then
                '    strReturn = strReturn & "[" & dr_field("COLUMN_NAME").ToString & "], "
                'End If
            Else
                strReturn = strReturn & "[" & dr_field("COLUMN_NAME").ToString & "], "
            End If
        Next
        strReturn = Mid(strReturn, 1, strReturn.Length - 2)
        Select Case UCase(ScriptType)
            Case Is = "INSERT"
                strReturn = strReturn & ") VALUES ("
            Case Is = "SELECT"
                strReturn = strReturn & " FROM " & TableName
        End Select
        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Action Costs Fetch"
        gwt_comm.ShowErrorMessage()
    End Function

    Public Function ScriptDataInsertStatement(QuerySring As String, TableName As String, dbConnection As Data.OleDb.OleDbConnection) As String
        Dim strReturn As String = Nothing

        Dim objCommand As New Data.OleDb.OleDbCommand(QuerySring, dbConnection)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader

        Dim arrData As New ArrayList

        Dim strInsertData As String = ScriptTableFields(TableName, "INSERT", dbConnection)

        While objReader.Read
            Dim strLine As String = strInsertData
            For p As Integer = 0 To objReader.FieldCount - 1
                If objReader.GetFieldType(p) Is GetType(String) Or objReader.GetFieldType(p) Is GetType(Date) Then
                    If objReader.GetFieldType(p) Is GetType(Date) Then
                        If IsDate(objReader(p).ToString) Then
                            strLine = strLine & "'" & objReader(p).ToString & "', "
                        Else
                            strLine = strLine & "" & "NULL" & ", "
                        End If
                    Else
                        Dim strFieldData As String = ""
                        If Not IsDBNull(objReader(p).ToString) Then
                            strFieldData = Replace(objReader(p), "'", "", 1)
                            Replace(objReader(p), vbCrLf, " ", 1)
                        End If
                        strLine = strLine & "'" & strFieldData & "', "
                    End If
                Else
                    If objReader.GetFieldType(p) Is GetType(Integer) Or objReader.GetFieldType(p) Is GetType(Double) Then
                        strLine = strLine & "" & Replace(objReader(p), "'", "", 1) & ", "
                    Else
                        strLine = strLine & "'" & Replace(objReader(p), "'", "", 1) & "', "
                    End If
                End If
            Next
            strLine = Mid(strLine, 1, strLine.Length - 2) & ")"
            arrData.Add(strLine)
        End While
        objReader.Close()

        Dim fileString As String = Nothing
        For p As Integer = 0 To arrData.Count - 1
            fileString = fileString & arrData.Item(p) & vbCrLf
        Next

        strReturn = fileString

        Return strReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Action Costs Fetch"
        gwt_comm.ShowErrorMessage()
    End Function

    Public Function TableExists(ByVal strTableName As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Dim myCommand As New Data.OleDb.OleDbCommand("IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES " _
            & "WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='" & strTableName & "')SELECT 'tablename exists.'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = myCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If objReader(0).ToString = "tablename exists." Then
                    boolReturn = True
                End If
            End If
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Table Existence Check Failed"
        gwt_comm.ShowErrorMessage()
    End Function

    Public Function TableColumnNames(TableName As String, Connection As Data.OleDb.OleDbConnection) As ArrayList
        On Error GoTo RaiseErr
        Dim arrReturn As New ArrayList
        Dim strSql As String = "SELECT TOP 1 * FROM " & TableName & ""
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, Connection)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        For p As Integer = 0 To objReader.FieldCount - 1
            arrReturn.Add(objReader.GetName(p).ToString)
        Next
        objReader.Close()
        Return arrReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "Table Existence Check Failed"
        gwt_comm.ShowErrorMessage()
    End Function

End Module
