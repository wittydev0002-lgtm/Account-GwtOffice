Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports ComponentFactory.Krypton.Toolkit

Public Class frmYearStartClassUpdates

    Private Sub frmYearStartClassUpdates_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadClasses()
    End Sub

    Private Sub LoadClasses()
        On Error GoTo RaiseErr
        Dim strSql As String = Nothing
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader

        strSql = "SELECT GroupName FROM SC_ClassGroups ORDER BY GroupName"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objReader = objCommand.ExecuteReader

        dGridClasses.Columns.Clear()
        dGridClasses.Columns.Add("Column1", "Classes")

        Dim arrClasses As New ArrayList

        While objReader.Read
            strSql = "SELECT SC_Classes.ClassName FROM SC_Classes " _
                & "WHERE GroupName = '" & objReader(0).ToString & "' ORDER BY ClassName"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            Dim objReadClasses As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            While objReadClasses.Read
                If Not IsDBNull(objReadClasses(0).ToString) Then
                    arrClasses.Add(objReadClasses(0).ToString)
                End If
            End While
            objReadClasses.Close()
        End While
        objReader.Close()

        For p As Integer = 0 To arrClasses.Count - 1
            dGridClasses.Rows.Add(arrClasses.Item(p))
        Next

        'Add the last item in the list of classes as the outgoing class
        arrClasses.Add("OUT-GOING")
        arrClasses.Add("NO-CHANGE")
        arrClasses.Add("1-UP-SAME")

        'Add the combobox column to hold all the classes

        Dim cmb As New KryptonDataGridViewComboBoxColumn
        cmb.HeaderText = "Move To"
        cmb.Name = "cmb"
        cmb.MaxDropDownItems = 4
        'cmb.DropDownStyle = ComboBoxStyle.DropDownList
        cmb.SortMode = DataGridViewColumnSortMode.Automatic

        For p As Integer = 0 To arrClasses.Count - 1
            If Not String.IsNullOrEmpty(arrClasses.Item(p)) Then cmb.Items.Add(arrClasses.Item(p))
        Next

        With dGridClasses
            .Columns.Add(cmb)
            .Columns(0).ReadOnly = True
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Columns(1).Width = 250
        End With

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "Year End/Year Start class details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub chkOneUpSame_CheckedChanged(sender As Object, e As DevComponents.DotNetBar.CheckBoxChangeEventArgs) Handles chkOneUpSame.CheckedChanged
        If chkOneUpSame.Checked = True Then

            boolAbort = False
            Dim frm As New frmHighestGrade
            frm.showdialog()
            If boolAbort = True Then Exit Sub

            For p As Integer = 0 To dGridClasses.Rows.Count - 1
                Dim strCurrentGrade As String = Nothing
                If Not Object.Equals(dGridClasses.Rows(p).Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dGridClasses.Rows(p).Cells(0).Value.ToString) Then
                        strCurrentGrade = dGridClasses.Rows(p).Cells(0).Value.ToString
                    End If
                End If

                Dim strNextGrade As String = Nothing

                If Not String.IsNullOrEmpty(strCurrentGrade) Then
                    Dim strBuffer() As String = Split(strCurrentGrade, " ")
                    If IsNumeric(strBuffer(0)) Then
                        strBuffer(0) = CStr(CInt(strBuffer(0)) + 1)
                        If CInt(strBuffer(0)) > intHighestSchoolGrade Then
                            strNextGrade = "OUT-GOING"
                        Else
                            For j As Integer = 0 To strBuffer.Length - 1
                                strNextGrade = strNextGrade & strBuffer(j) & " "
                            Next
                            strNextGrade = Mid(strNextGrade, 1, strNextGrade.Length - 1)
                        End If

                    End If
                End If
                dGridClasses.Rows(p).Cells(1).Value = strNextGrade
            Next
        Else
            For p As Integer = 0 To dGridClasses.Rows.Count - 1
                dGridClasses.Rows(p).Cells(1).Value = Nothing
            Next
        End If
    End Sub

    Private Sub btnProcess_Click(sender As System.Object, e As System.EventArgs) Handles btnProcess.Click
        If dGridClasses.RowCount <= 0 Then Exit Sub
        On Error GoTo RaiseErr

        boolAbort = False
        Dim frm As New frmYearWoundDown
        frm.ShowDialog()
        If boolAbort = True Then Exit Sub

        Dim objCommand As Data.OleDb.OleDbCommand

        ' Start with the outgoing classes by moving them to the archives table
        ' We read this grid starting from the bottom

        With pb1
            .Value = 0
            .Visible = True
            .Maximum = dGridClasses.Rows.Count
        End With

        'Get the last used record id from the archive table to use to update the year part of the table
        Dim intLastRecordId As Integer = 0
        
        objCommand = New Data.OleDb.OleDbCommand("SELECT [RecordId] FROM SC_StudentsArchive ORDER BY [RecordId] DESC", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                intLastRecordId = CInt(objReader(0).ToString)
            End If
        End If
        objReader.Close()

        Dim strSql As String = Nothing

        For p As Integer = dGridClasses.RowCount - 1 To 0 Step -1

            'Get the current student class
            Dim strCurrentClass As String = Nothing
            If Not Object.Equals(dGridClasses.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridClasses.Rows(p).Cells(0).Value.ToString) Then
                    strCurrentClass = dGridClasses.Rows(p).Cells(0).Value.ToString
                End If
            End If

            Dim strFutureClass As String = Nothing
            If Not Object.Equals(dGridClasses.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGridClasses.Rows(p).Cells(1).Value.ToString) Then
                    strFutureClass = dGridClasses.Rows(p).Cells(1).Value.ToString
                End If
            End If

            If UCase(strFutureClass) = "OUT-GOING" Then
                'Get the current student class
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO [SC_StudentsArchive] ([StudentId], [DateOfBirth], " _
                    & "[Address1], [Address2], [Address3], [Address4], [ContactTelephone], [EntryDate], [Grade], " _
                    & "[ClassName], [ClassTeacher], [Remarks], [LastName], [FirstName], [OtherNames], [PickupPoint], " _
                    & "[Distance], [TransportFee], [Gender], [CessionDate], [Status], [TerminationReason], [BirthEntryNumber], " _
                    & "[SchoolAllocatedNumber], [BillingCategory], [SubjectOptions], [ConventionalOptions], [BillingAmount]) " _
                    & "SELECT [StudentId], [DateOfBirth], [Address1], [Address2], [Address3], [Address4], [ContactTelephone], " _
                    & "[EntryDate], [Grade], [ClassName], [ClassTeacher], [Remarks], [LastName], [FirstName], [OtherNames], " _
                    & "[PickupPoint], [Distance], [TransportFee], [Gender], [CessionDate], [Status], [TerminationReason], " _
                    & "[BirthEntryNumber], [SchoolAllocatedNumber], [BillingCategory], [SubjectOptions], [ConventionalOptions], " _
                    & "[BillingAmount] FROM [SC_Students] WHERE ClassName = '" & strCurrentClass & "'", cnn)
                objCommand.ExecuteNonQuery()

                'Copy the transactions table as well
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO  SC_StudentTransactionsArchive ([StudentId], " _
                    & "[Description], [Reference], [Debit], [Credit], [UserName], [TransactionDate], [Remarks], [CostCode], " _
                    & "[ReceiptNo], [SchoolTerm], [TermYear]) SELECT [StudentId], [Description], [Reference], [Debit], [Credit], " _
                    & "[UserName], [TransactionDate], [Remarks], [CostCode], [ReceiptNo], [SchoolTerm], [TermYear] " _
                    & "FROM [SC_StudentTransactions] WHERE StudentId IN " _
                    & "(SELECT StudentId FROM SC_Students WHERE ClassName = '" & strCurrentClass & "')", cnn)
                objCommand.ExecuteNonQuery()

                'Copy the guardins table
                strSql = "INSERT INTO [SC_GuardiansArchive]([StudentId], [GivenNames], [Address1], [Address2], " _
                    & "[Address3], [Address4], [Cellphone], [Telephone], [Email]) " _
                    & "SELECT [StudentId], [GivenNames], [Address1], [Address2], " _
                    & "[Address3], [Address4], [Cellphone], [Telephone], [Email] FROM SC_Guardians " _
                    & "WHERE StudentId IN (SELECT StudentId FROM SC_Students WHERE ClassName = '" & strCurrentClass & "')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                'Archive the grades
                strSql = "INSERT INTO [SC_StudentGradesArchive] ([StudentId], [SubjectName], [Grade], [Semister], [GradeYear], [Remarks],[RemarksAuthor]) " _
                    & "SELECT [StudentId], [SubjectName], [Grade], [Semister], [GradeYear], [Remarks],[RemarksAuthor] FROM SC_StudentGrades " _
                    & "WHERE StudentId IN (SELECT StudentId FROM SC_Students WHERE ClassName = '" & strCurrentClass & "')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                'Archive grades
                strSql = "INSERT INTO [SC_StudentSubjectsAchieve] ([StudentId], [SubjectName]) " _
                    & "SELECT [StudentId], [SubjectName] FROM [SC_StudentSubjects] " _
                    & "WHERE StudentId IN (SELECT StudentId FROM SC_Students WHERE ClassName = '" & strCurrentClass & "')"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()

                'Delete the students from the current students table
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM [SC_StudentTransactions] WHERE StudentId IN " _
                    & "(SELECT StudentId FROM SC_Students WHERE ClassName = '" & strCurrentClass & "')", cnn)
                objCommand.ExecuteNonQuery()

                'Delete guardians
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM [SC_Guardians] WHERE StudentId IN " _
                    & "(SELECT StudentId FROM SC_Students WHERE ClassName = '" & strCurrentClass & "')", cnn)
                objCommand.ExecuteNonQuery()

                'Delete grades
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM [SC_StudentGrades] WHERE StudentId IN " _
                    & "(SELECT StudentId FROM SC_Students WHERE ClassName = '" & strCurrentClass & "')", cnn)
                objCommand.ExecuteNonQuery()

                'Delete subjects
                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM [SC_StudentSubjects] WHERE StudentId IN " _
                    & "(SELECT StudentId FROM SC_Students WHERE ClassName = '" & strCurrentClass & "')", cnn)
                objCommand.ExecuteNonQuery()

                objCommand = New Data.OleDb.OleDbCommand("DELETE FROM SC_Students WHERE ClassName = '" & strCurrentClass & "'", cnn)
                objCommand.ExecuteNonQuery()

                objCommand = New Data.OleDb.OleDbCommand("UPDATE SC_StudentsArchive SET YearLeft = " & intYearStudentLeft & " " _
                    & "WHERE RecordId > " & intLastRecordId & "", cnn)
                objCommand.ExecuteNonQuery()

            Else
                If Not String.IsNullOrEmpty(strFutureClass) Then
                    objCommand = New Data.OleDb.OleDbCommand("UPDATE SC_Students SET ClassName = '" & strFutureClass & "' " _
                        & "WHERE ClassName = '" & strCurrentClass & "'", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If

            pb1.Value = pb1.Value + 1
        Next

        objCommand = New Data.OleDb.OleDbCommand("UPDATE [SC_StudentsArchive] SET [YearLeft] = " & intYearStudentLeft & " WHERE RecordId > " & intLastRecordId & "", cnn)
        objCommand.ExecuteNonQuery()

        MessageBox.Show("Process has been completed successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On year-end/year-start class movements"
        gwt_comm.ShowErrorMessage()
    End Sub

End Class
