Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmConsultationCodesListing

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        boolEditStatus = False
        Dim frm As New frmConsultationCodeSetup
        frm.ShowDialog()
        LoadData
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strSql As String = "SELECT Code AS [Code], Description AS [Decription], CAST(ConversionFactor AS DECIMAL (10,2)) AS [Con. Factor], " _
            & "CAST(Units AS DECIMAL(10,2)) AS [Units], CAST(BaseFactor AS DECIMAL(10,2)) AS [Base Factor], Flag AS [Flag], " _
            & "CAST(Value AS DECIMAL(10,2)) AS [Price] FROM OchmasSystemConsultations ORDER BY Code, Description"

        With dGrid
            .Columns.Clear()

            Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New OleDb.OleDbDataAdapter(cmd)
            Dim dTable As New DataTable()
            da.Fill(dTable)
            .DataSource = dTable

            .DefaultCellStyle.WrapMode = DataGridViewTriState.True

            For i As Integer = 0 To .Columns.Count - 1
                If i = 2 Or i = 3 Or i = 4 Or i = .ColumnCount - 1 Then
                    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Else
                    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End If
                If i = 1 Then
                    .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Else
                    .Columns(i).Width = 80
                End If
            Next

        End With

        Cursor = Cursors.Default

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Consultation Codes Setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        GetSelected()
    End Sub

    Private Sub GetSelected()
        If dGrid.RowCount <= 0 Then Exit Sub
        If dGrid.CurrentRow.Index >= 0 Then
            boolEditStatus = True
            If Not Object.Equals(dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value.ToString) Then
                    strSelectedCode = dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value.ToString
                    Dim frm As New frmConsultationCodeSetup
                    frm.ShowDialog()
                    LoadData()
                End If
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        On Error GoTo RaiseErr
        Dim strDeleteCode As String = Nothing
        If Not Object.Equals(dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value, Nothing) Then
            If Not String.IsNullOrEmpty(dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value.ToString) Then
                strDeleteCode = dGrid.Rows(dGrid.CurrentRow.Index).Cells(0).Value.ToString
            End If
        End If

        If MessageBox.Show("Are you sure you want to delete this consultation code " & strDeleteCode & "?",
                           "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim strSql As String = "DELETE FROM OchmasSystemConsultations WHERE Code = " & strDeleteCode & ""
            Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
            LoadData()
            MessageBox.Show("Record has been deleted successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Consultation Codes Setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub dGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dGrid.CellContentClick

    End Sub

    Private Sub dGrid_DoubleClick(sender As Object, e As EventArgs) Handles dGrid.DoubleClick
        GetSelected()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

    End Sub

    Private Sub frmConsultationCodesListing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub txtSearchString_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchString.KeyPress
        SearchForItem(e.KeyChar)
    End Sub

    Private Sub SearchForItem(ByVal strCurrentKey As String)

        Dim strFind As String = txtSearchString.Text & strCurrentKey
        Dim strActiveSearch As String = strFind
        Cursor = Cursors.WaitCursor

        Dim strSql As String = "SELECT Code AS [Code], Description AS [Decription], CAST(ConversionFactor AS DECIMAL (10,2)) AS [Con. Factor], " _
            & "CAST(Units AS DECIMAL(10,2)) AS [Units], CAST(BaseFactor AS DECIMAL(10,2)) AS [Base Factor], Flag AS [Flag], " _
            & "CAST(Value AS DECIMAL(10,2)) AS [Price] FROM OchmasSystemConsultations " _
            & "WHERE Description LIKE '%" & strFind & "%' ORDER BY Code, Description"

        With dGrid

            .Columns.Clear()

            Dim cmd As New OleDb.OleDbCommand(strSql, cnn)
            cmd.CommandType = CommandType.Text

            Dim da As New OleDb.OleDbDataAdapter(cmd)
            Dim dTable As New DataTable()
            da.Fill(dTable)
            .DataSource = dTable

            .DefaultCellStyle.WrapMode = DataGridViewTriState.True

            For i As Integer = 0 To .Columns.Count - 1
                If i = 2 Or i = 3 Or i = 4 Or i = .ColumnCount - 1 Then
                    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Else
                    .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End If
                If i = 1 Then
                    .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                Else
                    .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next

        End With

        Cursor = Cursors.Default

            Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Data Filter Search"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click

        'Dim arrSmallCases As New ArrayList
        'Dim arrLargeCases As New ArrayList

        'Dim strFileName As String = Nothing
        'Dim ofd As New OpenFileDialog
        'ofd.ShowDialog()
        'strFileName = ofd.FileName

        'If System.IO.File.Exists(strFileName) Then
        '    Dim objFileReader As New System.IO.StreamReader(strFileName)
        '    Dim strData As String = objFileReader.ReadToEnd
        '    objFileReader.Close()

        '    Dim strLines() As String = Split(strData, vbCrLf)

        '    Dim objSmallFile As New System.IO.StreamWriter(Application.StartupPath & "\Source.txt", False)
        '    Dim objBigFile As New System.IO.StreamWriter(Application.StartupPath & "\Destine.txt", False)

        '    For p As Integer = 0 To strLines.Length - 1
        '        If Not String.IsNullOrEmpty(strLines(p)) Then
        '            If strLines(p) = UCase(strLines(p)) Then
        '                objBigFile.WriteLine(strLines(p))
        '            Else
        '                objSmallFile.WriteLine(strLines(p))
        '            End If
        '        End If
        '    Next

        '    objSmallFile.Close()
        '    objBigFile.Close()

        '    MsgBox("Done")

        'End If

        'On Error GoTo RaiseErr

        Cursor = Cursors.WaitCursor

        Dim strFileName As String = Nothing
        Dim ofd As New OpenFileDialog
        ofd.ShowDialog()
        strFileName = ofd.FileName

        If String.IsNullOrEmpty(strFileName) Then
            MessageBox.Show("No file has been selected. Process will be aborted", "Process Terminated", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Cursor = Cursors.Default
            Exit Sub
        End If

        If System.IO.File.Exists(strFileName) Then
            Dim objCommand As Data.OleDb.OleDbCommand
            Dim strSql As String = Nothing

            If MessageBox.Show("Do you want to clear information before import?", "Confirm Data Clearance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                strSql = "DELETE FROM OchmasSystemConsultations"
                objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                objCommand.ExecuteNonQuery()
            End If

            Dim objFileReader As New System.IO.StreamReader(strFileName)
            Dim strData As String = objFileReader.ReadToEnd
            objFileReader.Close()

            Dim strLines() As String = Split(strData, vbCrLf)
            With frmPatientPlusMain.pb1
                .Value = 0
                .Maximum = strLines.Length + 10
                .Visible = True

                For p As Integer = 0 To strLines.Length - 1
                    If Not String.IsNullOrEmpty(strLines(p)) Then
                        Dim strBuffer() As String = Split(strLines(p), "|")
                        If strBuffer.Length >= 4 Then
                            If CodeExists(Trim(strBuffer(0))) = False Then
                                Dim dblValue As Double = 0
                                If IsNumeric(strBuffer(3)) Then
                                    dblValue = CDbl(strBuffer(3))
                                End If
                                If IsNumeric(Trim(strBuffer(0))) Then
                                    strSql = "INSERT INTO OchmasSystemConsultations (Code, Description, ConversionFactor, Units, " _
                                        & "BaseFactor, Value, Flag, Branch, UserName, ChangeDate, MedicalAidValue, OthersValue) VALUES " _
                                        & "('" & Trim(strBuffer(0)) & "', '" & Trim(strBuffer(1)) & "', 1, 1, 1, " & dblValue & ", 'Y', " _
                                        & "'" & strUserBranch & "', '" & strUserName & "', '" & Now & "', " & dblValue & ", " & dblValue & ")"
                                    objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                                    objCommand.ExecuteNonQuery()
                                End If
                                .Value = .Value + 1
                            End If
                        End If
                    End If
                Next
                .Value = .Maximum
            End With
            MessageBox.Show("Data has been imported successfully", "Data Import Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("The selected does not exist", "Invalid File Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Cursor = Cursors.Default
        '0782794380 CLIFFORD KAMWE
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On consultation codes import"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Sub

    Private Function CodeExists(Code As String) As Boolean
        Dim boolReturn As Boolean = False
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Code FROM OchmasSystemConsultations WHERE Code = '" & Code & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            boolReturn = True
        End If
        objReader.Close()
        Return boolReturn
        Exit Function
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On consultation codes import"
        ShowErrorMessage()
        Cursor = Cursors.Default
    End Function

End Class