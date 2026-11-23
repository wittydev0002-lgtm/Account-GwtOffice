Imports CommonLibrary.Commons

Public Class Form1

    Dim strFileName As String = Nothing
    Dim intLineNum As Integer = 0

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        On Error GoTo RaiseErr

        Dim strSql As String = Nothing
        intLineNum = 4

        Dim objCommand As Data.OleDb.OleDbCommand
        If gwt_comm.CheckTableExistence("TEMP_TABLE_F") = False Then
            strSql = "CREATE TABLE TEMP_TABLE_F ([ItemCode][NVARCHAR](150) Null, " _
                & "[Description][NVARCHAR](350) NULL, [CostPrice][FLOAT] NOT NULL DEFAULT 0, " _
                & "[Category][NVARCHAR](150) NULL, [SubCategory][NVARCHAR](150) NULL, [LineId][INT] NOT NULL DEFAULT 0)"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        End If

        If System.IO.File.Exists(strFileName) Then
            Dim objFile As New System.IO.StreamReader(strFileName)
            Dim strData As String = objFile.ReadToEnd
            objFile.Close()
            Dim strLines() As String = Split(strData, vbCrLf)

            With ProgressBar1
                .Value = 0
                .Maximum = strLines.Length + 3
                .Visible = True
            End With

            objCommand = New Data.OleDb.OleDbCommand("DELETE FROM InventoryItems", cnn)
            objCommand.ExecuteNonQuery()

            For p As Integer = 0 To strLines.Length - 2
                intLineNum = intLineNum + 1
                Dim strFields() As String = Split(strLines(p), vbTab)
                If DuplicateItemCode(strFields(0)) = False Then
                    'If DuplicateDescription(Trim(strFields(1))) = False Then
                    For t As Integer = 0 To strFields.Length - 1
                        strFields(t) = Replace(strFields(t), ",", "", 1)
                        strFields(t) = Replace(strFields(t), "'", "", 1)
                        strFields(t) = Trim(strFields(t))
                        If t = 4 Or t = 6 Then
                            If Not IsNumeric(strFields(t)) Then
                                strFields(t) = "0"
                            End If
                        End If
                    Next
                    'strSql = "INSERT INTO TEMP_TABLE_F (ItemCode, Description, CostPrice, Category, SubCategory, LineId) " _
                    '    & "VALUES ('" & Trim(strFields(0)) & "', '" & Trim(strFields(1)) & "', " & strFields(4) & ", " _
                    '    & "'" & Trim(strFields(7)) & "', '" & Trim(strFields(8)) & "', " & intLineNum & ")"

                    strSql = "INSERT INTO InventoryItems (ItemCode, GroupName, CostPrice, Category, SubCategory, SellingPrice, Location) " _
                        & "VALUES ('" & Trim(strFields(0)) & "', '" & Trim(strFields(1)) & "', " & strFields(4) & ", " _
                        & "'" & Trim(strFields(7)) & "', '" & Trim(strFields(8)) & "', " & strFields(6) & ", 'HEAD OFFICE')"
                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                    objCommand.ExecuteNonQuery()
                    'End If
                End If
        ProgressBar1.Value = ProgressBar1.Value + 1
            Next
        End If
        ProgressBar1.Value = ProgressBar1.Maximum
        MessageBox.Show("Process Completed", "Process End", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & _
            "Inventory Data Import Error on the source file Line Number " & intLineNum & vbCrLf & strSql
        ShowErrorMessage()
    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.ShowDialog()
        strFileName = OpenFileDialog1.FileName
    End Sub

    Private Function DuplicateDescription(ByVal Description As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        Description = Replace(Description, "'", "", 1)

        Dim strSql As String = "SELECT LineId FROM TEMP_TABLE_F WHERE Description = '" & Description & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    Dim objFile As New System.IO.StreamWriter(Application.StartupPath & "\Duplicates.txt", True)
                    objFile.WriteLine("CURRENT LINE NO. :" & intLineNum & " " & Description & ": !!! DESCRIPTION ALREADY EXISTS AT LINE " & objReader(0).ToString & " OF THE SOURCE FILE !!! : ")
                    objFile.Close()
                    boolReturn = True
                End If
            End If
        End If
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Inventory Data Import Error"
        ShowErrorMessage()
    End Function

    Private Function DuplicateItemCode(ByVal ItemCode As String) As Boolean
        On Error GoTo RaiseErr
        Dim boolReturn As Boolean = False
        ItemCode = Replace(ItemCode, "'", "", 1)

        Dim strSql As String = "SELECT ItemCode FROM InventoryItems WHERE ItemCode = '" & ItemCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If Not IsDBNull(objReader(0).ToString) Then
                If Not String.IsNullOrEmpty(objReader(0).ToString) Then
                    Dim objFile As New System.IO.StreamWriter(Application.StartupPath & "\Duplicates.txt", True)
                    objFile.WriteLine("CURRENT LINE NO. :" & intLineNum & " " & ItemCode & ": !!! ITEM CODE ALREADY EXISTS !!! : ")
                    objFile.Close()
                    boolReturn = True
                End If
            End If
        End If
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Inventory Data Import Error"
        ShowErrorMessage()
    End Function

End Class