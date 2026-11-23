Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmPrivateFeeStructure

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dGrid.EditingControlShowing
        Try
            If e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                AddHandler e.Control.KeyPress, AddressOf CheckCell
            Else
                'In order to prevent optical problems, we had to call the removeHandler twice
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
                RemoveHandler e.Control.KeyPress, AddressOf CheckCell
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex > 0 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
        End If
    End Sub

    Private Sub frmPrivateFeeStructure_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadClasses()
        LoadFees()
        lblTotalClasses.Text = dGrid.Rows.Count
    End Sub

    Private Sub LoadClasses()
        On Error GoTo RaiseErr
        Dim strSq As String = "Select DISTINCT(ClassName) from sc_classes ORDER BY ClassName"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSq, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows.Add(objReader(0), "0.00", "0.00", "0.00", "0.00", "0.00")
            End If
        End While
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On private schools fee structure details load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadFees()
        On Error GoTo RaiseErr
        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim strClass As String = Nothing
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strClass = dGrid.Rows(p).Cells(0).Value.ToString
                    Dim strSql As String = "SELECT Termly, Monthly, Weekly, Daily, Hourly " _
                        & "FROM SC_PrivateFeeStructure WHERE [Class] = '" & strClass & "'"
                    Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
                    Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                    If objReader.HasRows Then
                        objReader.Read()
                        If IsNumeric(objReader(0).ToString) Then dGrid.Rows(p).Cells(1).Value = Format(CDbl(objReader(0).ToString), "##0.00") Else dGrid.Rows(p).Cells(1).Value = "0.00"
                        If IsNumeric(objReader(1).ToString) Then dGrid.Rows(p).Cells(2).Value = Format(CDbl(objReader(1).ToString), "##0.00") Else dGrid.Rows(p).Cells(2).Value = "0.00"
                        If IsNumeric(objReader(2).ToString) Then dGrid.Rows(p).Cells(3).Value = Format(CDbl(objReader(2).ToString), "##0.00") Else dGrid.Rows(p).Cells(3).Value = "0.00"
                        If IsNumeric(objReader(3).ToString) Then dGrid.Rows(p).Cells(4).Value = Format(CDbl(objReader(3).ToString), "##0.00") Else dGrid.Rows(p).Cells(4).Value = "0.00"
                        If IsNumeric(objReader(4).ToString) Then dGrid.Rows(p).Cells(5).Value = Format(CDbl(objReader(4).ToString), "##0.00") Else dGrid.Rows(p).Cells(5).Value = "0.00"
                    End If
                End If
            End If
        Next
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On private schools fee structure details load"
        ShowErrorMessage()
    End Sub

    Private Sub btnSaveAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAll.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SC_PrivateFeeStructure", cnn)
        objCommand.ExecuteNonQuery()
        For p As Integer = 0 To dGrid.Rows.Count - 1
            Dim strClass As String = Nothing
            Dim dblTermly As Double = 0
            Dim dblMonthly As Double = 0
            Dim dblWeekly As Double = 0
            Dim dblDaily As Double = 0
            Dim dblHourly As Double = 0

            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString) Then
                    strClass = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(1).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(1).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(1).Value.ToString) Then
                        dblTermly = CDbl(dGrid.Rows(p).Cells(1).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(2).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(2).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(2).Value.ToString) Then
                        dblMonthly = CDbl(dGrid.Rows(p).Cells(2).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(3).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(3).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(3).Value.ToString) Then
                        dblWeekly = CDbl(dGrid.Rows(p).Cells(3).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(4).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(4).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(4).Value.ToString) Then
                        dblDaily = CDbl(dGrid.Rows(p).Cells(4).Value.ToString)
                    End If
                End If
            End If

            If Not Object.Equals(dGrid.Rows(p).Cells(5).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(5).Value.ToString) Then
                    If IsNumeric(dGrid.Rows(p).Cells(5).Value.ToString) Then
                        dblHourly = CDbl(dGrid.Rows(p).Cells(5).Value.ToString)
                    End If
                End If
            End If

            Dim strSql As String = "INSERT INTO SC_PrivateFeeStructure ([Class],[Termly],[Monthly],[Weekly],[Daily],[Hourly]) VALUES " _
                & "('" & strClass & "', " & dblTermly & ", " & dblMonthly & ", " & dblWeekly & ", " & dblDaily & ", " & dblHourly & ")"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()

        Next
        MessageBox.Show("Private school fee structure details saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On private schools fee structure details save"
        ShowErrorMessage()
    End Sub

End Class