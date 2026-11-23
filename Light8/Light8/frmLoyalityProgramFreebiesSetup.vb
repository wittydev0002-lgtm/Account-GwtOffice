Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoyalityProgramFreebiesSetup

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
            If IsNumeric(dGrid.CurrentCell.Value) Then
                dGrid.CurrentCell.Value = Format(CDbl(dGrid.CurrentCell.Value), "##0.00")
            Else
                dGrid.CurrentCell.Value = "0.00"
            End If
        End If
    End Sub

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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub SelectAll()
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1
                .Rows(i).Cells(0).Value = True
            Next
        End With
    End Sub

    Private Sub DeselectAll()
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1
                .Rows(i).Cells(0).Value = False
            Next
            For i As Integer = 0 To .Rows.Count - 1
                .Rows(i).Cells(3).Value = "0.00"
            Next
        End With
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseError
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT GroupName, ItemCode FROM InventoryItems ORDER BY GroupName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(False, objReader(0), objReader(1), "0.00")
        End While
        objReader.Close()
        Exit Sub
RaiseError:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory data load to grid"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmLoyalityProgramFreebiesSetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
        If boolEditStatus = True Then LoadSelected()
    End Sub

    Private Sub optSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSelectAll.CheckedChanged
        If optSelectAll.Checked = True Then
            SelectAll()
            txtDiscountFactor.Enabled = True
            txtVisits.Enabled = True
        Else
            txtDiscountFactor.Enabled = False
            txtVisits.Enabled = False
        End If
    End Sub

    Private Sub optUncheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUncheckAll.CheckedChanged
        If optUncheckAll.Checked = True Then
            DeselectAll()
        End If
    End Sub

    Private Sub txtSearchFor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchFor.TextChanged
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1
                If UCase(Mid(.Rows(i).Cells(1).Value, 1, Len(txtSearchFor.Text))) = UCase(txtSearchFor.Text) Then
                    .FirstDisplayedCell = .Rows(i).Cells(1)
                    .FirstDisplayedCell.Selected = True
                    Exit Sub
                End If
            Next
        End With
    End Sub

    Private Sub txtDiscountFactor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscountFactor.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtDiscountFactor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDiscountFactor.Validating
        If Not IsNumeric(txtDiscountFactor.Text) Then Exit Sub
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1
                .Rows(i).Cells(3).Value = Format(CDbl(txtDiscountFactor.Text), "##0.00")
            Next
        End With
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseError
        If String.IsNullOrEmpty(txtProgramName.Text) Then
            MessageBox.Show("Please enter the program promotion name", "Missing Program Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtProgramName.Focus()
            Exit Sub
        End If

        'Check that the name has not been used already if this is a new entry
        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = False Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT ProgramName from LoyaltyPromotions WHERE ProgramName = '" & txtProgramName.Text & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                MessageBox.Show("The program name already exits. Please enter a different name", _
                    "Duplicate Program Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtProgramName.Focus()
                Exit Sub
            End If
            objReader.Close()
        End If

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LoyaltyPromotions WHERE ProgramName = '" & txtProgramName.Text & "'", cnn)
        objCommand.ExecuteNonQuery()
        With dGrid
            For i As Integer = 0 To dGrid.Rows.Count - 1
                If .Rows(i).Cells(0).Value = True Then
                    If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(3).Value), "")) Then
                        Dim strRate As String = .Rows(i).Cells(3).Value.ToString
                        If IsNumeric(strRate) Then
                            'If CDbl(strRate) > 0 Then
                            Dim strItemCode As String = Nothing
                            Dim intVisits As Integer = 0
                            If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "")) Then
                                strItemCode = .Rows(i).Cells(2).Value.ToString
                            End If
                            If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(4).Value), "")) Then
                                If IsNumeric(.Rows(i).Cells(4).Value.ToString) Then
                                    intVisits = CInt(.Rows(i).Cells(4).Value.ToString)
                                End If
                            End If
                            If Not String.IsNullOrEmpty(strItemCode) Then
                                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LoyaltyPromotions " _
                                    & "(ProgramName, Type, FactorMinima, Discount, ItemCode) VALUES " _
                                    & "('" & txtProgramName.Text & "', 'FREEBIES', " & intVisits & ", " _
                                    & "" & CDbl(strRate) & ", '" & strItemCode & "')", cnn)
                                objCommand.ExecuteNonQuery()
                            End If
                            'End If
                        End If
                    End If
                End If
            Next
        End With
        MessageBox.Show("Data saved successfully", "Loyalty Program Parameters Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseError:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Saving Details"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SaveData()
    End Sub

    Private Sub LoadSelected()
        On Error GoTo RaiseError
        txtProgramName.Text = strSelectedPromotionName
        txtProgramName.Enabled = False
        For i As Integer = 0 To dGrid.Rows.Count - 1
            Dim strItemCode As String = Nothing
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(2).Value), "")) Then
                strItemCode = dGrid.Rows(i).Cells(2).Value.ToString
                Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Discount, FactorMinima FROM loyaltypromotions WHERE " _
                    & "ItemCode = '" & strItemCode & "' AND ProgramName = '" & strSelectedPromotionName & "'", cnn)
                Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
                If objReader.HasRows Then
                    objReader.Read()
                    If IsNumeric(objReader(0).ToString) Then
                        If CDbl(objReader(0).ToString) > 0 Then
                            dGrid.Rows(i).Cells(3).Value = Format(CDbl(objReader(0).ToString), "##0.00")
                            dGrid.Rows(i).Cells(0).Value = True
                        End If
                        If CDbl(objReader(1).ToString) > 0 Then
                            dGrid.Rows(i).Cells(4).Value = Format(CDbl(objReader(1).ToString), "##0.00")
                        End If
                    End If
                End If
                objReader.Close()
            End If
        Next
        Exit Sub
RaiseError:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Inventory data load to grid"
        gwt_comm.ShowErrorMessage()
    End Sub

    'Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
    '    With dGrid
    '        If e.ColumnIndex = 3 Then
    '            If .CurrentCell.Value = Nothing Then
    '                Exit Sub
    '            End If
    '            If Not IsNumeric(.CurrentCell.Value.ToString) Then
    '                MessageBox.Show("Invalid data input", MsgBoxStyle.Exclamation, "Invalid Data")
    '                .CurrentCell.Value = Nothing
    '            Else
    '                .CurrentCell.Value = Format((CDbl(.CurrentCell.Value.ToString)), "##0.00")
    '                .CurrentRow.Cells(0).Value = True
    '            End If
    '        End If
    '    End With
    'End Sub

    Private Sub btnResetValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetValues.Click
        Cursor = Cursors.WaitCursor
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1
                .Rows(i).Cells(3).Value = "0.00"
                .Rows(i).Cells(4).Value = "0.00"
            Next
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub txtVisits_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVisits.KeyPress
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If Asc(e.KeyChar) = 13 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub txtVisits_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVisits.TextChanged
        Cursor = Cursors.WaitCursor
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1
                If IsNumeric(txtVisits.Text) Then .Rows(i).Cells(4).Value = Format(CInt(txtVisits.Text), "##0")
            Next
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub frmLoyalityProgramFreebiesSetup_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 600 : Me.Height = 530
    End Sub

End Class
