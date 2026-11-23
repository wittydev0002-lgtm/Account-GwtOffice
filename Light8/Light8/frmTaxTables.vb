Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmTaxTables

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgrid.EditingControlShowing
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

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrid.CellEndEdit
        If IsNumeric(dgrid.CurrentCell.Value) Then
            dgrid.CurrentCell.Value = Format(CDbl(dgrid.CurrentCell.Value), "##0.00")
        Else
            dgrid.CurrentCell.Value = "0.00"
        End If
    End Sub

    Private Sub txtBands_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtBands.Validating
        On Error Resume Next
        If IsNumeric(txtBands.Text) Then
            If CInt(txtBands.Text) > 0 Then
                If dgrid.Rows.Count > 0 Then
                    Dim i As Integer = dgrid.Rows.Count
                    dgrid.Rows.Add(CInt(txtBands.Text) - i)
                Else
                    dgrid.Rows.Clear()
                    dgrid.Rows.Add(CInt(txtBands.Text))
                End If
                For n As Integer = 1 To dgrid.Rows.Count - 1
                    dgrid.Rows(n - 1).Cells(0).Value = Format(n, "00")
                Next
            End If
            AlternateColors()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmTaxTables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Create the tax table if it does not exist
        On Error GoTo RaiseErr
        Dim objCommand As Data.OleDb.OleDbCommand
        Dim objReader As Data.OleDb.OleDbDataReader
        Dim strSql As String = "IF OBJECT_ID(N'SystemTaxTables', N'U') IS NULL " _
            & "CREATE TABLE SystemTaxTables ([Band] [int] NOT NULL PRIMARY KEY, " _
            & "[Minima] [Float] NOT NULL DEFAULT 0, [Maxima][float] NOT NULL DEFAULT 0, " _
            & "[Rate][float] NOT NULL DEFAULT 0, [BaseDeduction][float] NOT NULL DEFAULT 0)"
        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()
        'Read the data from the database
        objCommand = New Data.OleDb.OleDbCommand("SELECT Band, Minima, Maxima, Rate, BaseDeduction " _
            & "FROM SystemTaxTables ORDER BY Band", cnn)
        objReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            While objReader.Read
                dgrid.Rows.Add(1)
                If IsNumeric(objReader(0).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = Format(CDbl(objReader(0).ToString), "##0.00")
                If IsNumeric(objReader(1).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(1).Value = Format(CDbl(objReader(1).ToString), "##0.00")
                If IsNumeric(objReader(2).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(2).Value = Format(CDbl(objReader(2).ToString), "##0.00")
                If IsNumeric(objReader(3).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(3).Value = Format(CDbl(objReader(3).ToString), "##0.00")
                If IsNumeric(objReader(4).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(4).Value = Format(CDbl(objReader(4).ToString), "##0.00")
            End While
        End If
        AlternateColors()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Tax Tables Setup"
        ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim sqlCommand As Data.OleDb.OleDbCommand
        If dgrid.Rows.Count > 0 Then
            sqlCommand = New Data.OleDb.OleDbCommand("DELETE FROM SystemTaxTables", cnn)
            sqlCommand.ExecuteNonQuery()
            For n As Integer = 0 To dgrid.Rows.Count - 1
                Dim strLineNumber As String = "0"
                Dim strValueMinima As String = "0"
                Dim strValueMaxima As String = "0"
                Dim strBaseDeduction As String = "0"
                Dim strRate As String = "0"
                If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(0).Value), "")) Then
                    If IsNumeric(dgrid.Rows(n).Cells(0).Value.ToString) Then
                        strLineNumber = dgrid.Rows(n).Cells(0).Value.ToString
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(1).Value), "")) Then
                    If IsNumeric(dgrid.Rows(n).Cells(1).Value.ToString) Then
                        strValueMinima = dgrid.Rows(n).Cells(1).Value.ToString
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(2).Value), "")) Then
                    If IsNumeric(dgrid.Rows(n).Cells(2).Value.ToString) Then
                        strValueMaxima = dgrid.Rows(n).Cells(2).Value.ToString
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(3).Value), "")) Then
                    If IsNumeric(dgrid.Rows(n).Cells(3).Value.ToString) Then
                        strRate = dgrid.Rows(n).Cells(3).Value.ToString
                    End If
                End If
                If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(4).Value), "")) Then
                    If IsNumeric(dgrid.Rows(n).Cells(4).Value.ToString) Then
                        strBaseDeduction = dgrid.Rows(n).Cells(4).Value.ToString
                    End If
                End If
                sqlCommand = New Data.OleDb.OleDbCommand("INSERT INTO SystemTaxTables " _
                    & "(Band, Minima, Maxima, Rate, BaseDeduction) VALUES " _
                    & "(" & (n + 1) & ", " & strValueMinima & ", " _
                    & "" & strValueMaxima & ", " & strRate & ", " & strBaseDeduction & ")", cnn)
                sqlCommand.ExecuteNonQuery()
            Next n
        End If
        MessageBox.Show("Tax Tables have been updated successfully", "Tax Tables Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & "On Tax Tables Setup"
        ShowErrorMessage()
        boolAbort = True
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 0 To dgrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dgrid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                dgrid.Rows(i).Cells(j).Style.BackColor = backColor
                dgrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub frmTaxTables_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        '616; 364
        Me.Width = 517 : Me.Height = 364
    End Sub

End Class