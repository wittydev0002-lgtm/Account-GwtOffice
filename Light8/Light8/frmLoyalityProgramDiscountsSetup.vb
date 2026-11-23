Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmLoyalityProgramDiscountsSetup

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGrid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dGrid.CellEndEdit
        With dGrid
            .CurrentCell.Value = Format((CDbl(.CurrentCell.Value.ToString)), "##0.00")
        End With
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

    Private Sub frmLoyalityProgramDiscountsSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dGrid.Rows.Add(50)
        If boolEditStatus = True Then LoadSelected()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub SaveData()
        On Error GoTo RaiseError
        If String.IsNullOrEmpty(txtProgramName.Text) Then
            MessageBox.Show("Please enter the program promotion name", "Missing Program Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtProgramName.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(cboBasedOn.Text) Then
            MessageBox.Show("Please select the basis for making the discount", "Missing Discount Basis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboBasedOn.Focus()
            Exit Sub
        End If

        'Check that the name has not been used already if this is a new entry
        Dim objCommand As Data.OleDb.OleDbCommand
        If boolEditStatus = False Then
            objCommand = New Data.OleDb.OleDbCommand("SELECT ProgramName from LoyaltyPromotions WHERE ProgramName = '" & txtProgramName.Text & "'", cnn)
            Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
            If objReader.HasRows Then
                MessageBox.Show("The program name already exits. Please enter a different name", "Duplicate Program Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtProgramName.Focus()
                Exit Sub
            End If
            objReader.Close()
        End If

        objCommand = New Data.OleDb.OleDbCommand("DELETE FROM LoyaltyPromotions WHERE ProgramName = '" & txtProgramName.Text & "'", cnn)
        objCommand.ExecuteNonQuery()
        With dGrid
            For i As Integer = 0 To dGrid.Rows.Count - 1
                If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then
                    If IsNumeric(.Rows(i).Cells(0).Value.ToString) Then
                        If CDbl(.Rows(i).Cells(0).Value.ToString) >= 0 Then
                            Dim dblFactor As Double = 0, dblMinima As Double = 0, dblMaxima As Double = 0
                            If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(0).Value), "")) Then
                                If IsNumeric(.Rows(i).Cells(0).Value.ToString) Then
                                    dblMinima = CDbl(.Rows(i).Cells(0).Value.ToString)
                                End If
                            End If
                            If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(1).Value), "")) Then
                                If IsNumeric(.Rows(i).Cells(1).Value.ToString) Then
                                    dblMaxima = CDbl(.Rows(i).Cells(1).Value.ToString)
                                End If
                            End If
                            If Not (Object.Equals(Convert.ToString(.Rows(i).Cells(2).Value), "")) Then
                                If IsNumeric(.Rows(i).Cells(2).Value.ToString) Then
                                    dblFactor = CDbl(.Rows(i).Cells(2).Value.ToString)
                                End If
                            End If
                            objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LoyaltyPromotions " _
                                & "(ProgramName, Type, FactorMinima, FactorMaxima, Discount, ItemCode, BasedOn) VALUES " _
                                & "('" & txtProgramName.Text & "', '" & strPublicBenefitType & "', " _
                                & "" & dblMinima & ", " & dblMaxima & ", " _
                                & "" & dblFactor & ", '', '" & cboBasedOn.Text & "')", cnn)
                            objCommand.ExecuteNonQuery()
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
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT " _
            & "ProgramName, Type, FactorMinima, FactorMaxima, Discount, ItemCode, BasedOn FROM " _
            & "LoyaltyPromotions WHERE ProgramName = '" & strSelectedPromotionName & "' " _
            & "ORDER BY TransactionId", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        Dim i As Integer = 0
        While objReader.Read
            dGrid.Rows(i).Cells(0).Value = Format(CDbl(objReader(2).ToString), "##0.00")
            dGrid.Rows(i).Cells(1).Value = Format(CDbl(objReader(3).ToString), "##0.00")
            dGrid.Rows(i).Cells(2).Value = Format(CDbl(objReader(4).ToString), "##0.00")
            If Not IsDBNull(objReader(6).ToString) Then cboBasedOn.Text = objReader(6).ToString
            i = i + 1
        End While
        objReader.Close()
        Exit Sub
RaiseError:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Details Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmLoyalityProgramDiscountsSetup_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Width = 620 : Me.Height = 505
    End Sub

End Class
