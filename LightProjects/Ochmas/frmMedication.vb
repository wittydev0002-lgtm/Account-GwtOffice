Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmMedication

    Private Sub CheckCell(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 18 Then Exit Sub
        If e.KeyChar = "." Then Exit Sub
        If e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub dGridEntry_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgridEntry.CellEndEdit
        If dGridEntry.CurrentCell.ColumnIndex = 1 Then
            If IsNumeric(dGridEntry.CurrentCell.Value) Then
                dGridEntry.CurrentCell.Value = Format(CDbl(dGridEntry.CurrentCell.Value.ToString), "##0.00")
            Else
                dGridEntry.CurrentCell.Value = "0.00"
            End If
        End If
    End Sub

    Private Sub dGridEntry_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgridEntry.EditingControlShowing
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

    Private Sub dGridEntriy_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgridEntry.KeyDown
        If e.KeyValue = 9 Then
            If dgridEntry.CurrentCell.ColumnIndex = 0 Then
                strSelectedCode = Nothing
                strSelectedCodeDescription = Nothing
                strSelectedItemTaxStatus = Nothing
                boolAbort = False

                Dim frm As New frmDrugSearch
                frm.ShowDialog()
                If boolAbort = True Then
                    e.SuppressKeyPress = True
                    'dGridEntriy.CurrentCell = dGridEntriy.CurrentRow.Cells(0)
                Else
                    dgridEntry.CurrentCell.Value = strSelectedCodeDescription
                    dgridEntry.CurrentRow.Cells(1).Value = strSelectedCode
                    dgridEntry.CurrentCell = dgridEntry.CurrentRow.Cells(1)
                End If
            End If

            If dgridEntry.CurrentCell.ColumnIndex = 3 Then
                strSelectedCode = Nothing
                strSelectedCodeDescription = Nothing
                boolAbort = False
                Dim frm As New frmDispensingCiphersSearch
                frm.ShowDialog()
                If boolAbort = True Then
                    e.SuppressKeyPress = True
                    'dGridEntriy.CurrentCell = dGridEntriy.CurrentRow.Cells(0)
                Else
                    dgridEntry.CurrentCell.Value = strSelectedCode
                    dgridEntry.CurrentRow.Cells(4).Value = strSelectedCodeDescription
                    'dGridEntriy.CurrentCell = dGridEntriy.CurrentRow.Cells(1)
                End If
            End If

            If dgridEntry.CurrentCell.ColumnIndex = dgridEntry.ColumnCount - 1 Then
                'Check that the data is correctly entered
                Dim strDrugName As String = Nothing
                Dim strDrugCode As String = Nothing
                Dim dblQuantity As Double = 0
                Dim strDrugCipher As String = Nothing
                Dim strCipher As String = Nothing

                e.SuppressKeyPress = True
                If Not Object.Equals(dgridEntry.CurrentRow.Cells(0).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dgridEntry.CurrentRow.Cells(0).Value.ToString) Then
                        strDrugName = dgridEntry.CurrentRow.Cells(0).Value.ToString
                    End If
                End If
                If Not Object.Equals(dgridEntry.CurrentRow.Cells(1).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dgridEntry.CurrentRow.Cells(1).Value.ToString) Then
                        strDrugCode = dgridEntry.CurrentRow.Cells(1).Value.ToString
                    End If
                End If
                If Not Object.Equals(dgridEntry.CurrentRow.Cells(2).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dgridEntry.CurrentRow.Cells(2).Value.ToString) Then
                        If IsNumeric(dgridEntry.CurrentRow.Cells(2).Value.ToString) Then
                            dblQuantity = dgridEntry.CurrentRow.Cells(2).Value.ToString
                        End If
                    End If
                End If
                If Not Object.Equals(dgridEntry.CurrentRow.Cells(3).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dgridEntry.CurrentRow.Cells(3).Value.ToString) Then
                        strDrugCipher = dgridEntry.CurrentRow.Cells(3).Value.ToString
                    End If
                End If

                If Not Object.Equals(dgridEntry.CurrentRow.Cells(4).Value, Nothing) Then
                    If Not String.IsNullOrEmpty(dgridEntry.CurrentRow.Cells(4).Value.ToString) Then
                        strCipher = dgridEntry.CurrentRow.Cells(4).Value.ToString
                    End If
                End If

                If String.IsNullOrEmpty(strDrugName) Then
                    MessageBox.Show("Missing the drug name. Please correct this error", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgridEntry.CurrentCell = dgridEntry.CurrentRow.Cells(0)
                    Exit Sub
                End If

                If String.IsNullOrEmpty(CStr(dblQuantity)) Then
                    MessageBox.Show("Missing the dispensing quantity. Please correct this error", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgridEntry.CurrentCell = dgridEntry.CurrentRow.Cells(2)
                    Exit Sub
                End If

                If String.IsNullOrEmpty(strDrugCode) Then
                    MessageBox.Show("Missing the drug code. Please correct this error", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgridEntry.CurrentCell = dgridEntry.CurrentRow.Cells(0)
                    Exit Sub
                End If

                If String.IsNullOrEmpty(strDrugCipher) Then
                    MessageBox.Show("Missing the drug cipher. Please correct this error", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    dgridEntry.CurrentCell = dgridEntry.CurrentRow.Cells(3)
                    Exit Sub
                End If

                ' ''Accept the items here
                Dim dblUnitPrice As Double = DrugUnitPrice(strDrugCode)
                Dim dblLineTotal As Double = dblUnitPrice * dblQuantity

                dGrid.Rows.Add(strDrugName, dblQuantity, Format(dblUnitPrice, "##0.00"), "0.00", Format(dblLineTotal, "##0.00"), "0.00", _
                   strCipher, strDrugCode)

                ' ''Accumulate the totals on top
                ''Dim MovingTotal As Double = 0
                ''MovingTotal = CDbl(lblTotal.Text) + dblLineTotal
                ''lblTotal.Text = Format(MovingTotal, "##0.00")

                ' ''Compute payable
                ''Dim dblPayable As Double = 0
                ''dblPayable = CDbl(lblTotal.Text) - CDbl(lblShortfall.Text)
                ''lblPayable.Text = Format(dblPayable, "##0.00")


                'Reset the grid values to nothing 
                For p As Integer = 0 To dgridEntry.ColumnCount - 1
                    dgridEntry.Rows(0).Cells(p).Value = Nothing
                Next
                dgridEntry.CurrentCell = dgridEntry.CurrentRow.Cells(0)

            End If

        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmMedication_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        dgridEntry.Rows.Add(1)
    End Sub

    Private Function DrugUnitPrice(DrugCode As String) As Double
        Dim dblReturn As Double = 0
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SellPrice FROM OchmasSystemMedicines " _
            & "WHERE ProductCode = '" & DrugCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        If objReader.HasRows Then
            objReader.Read()
            If IsNumeric(objReader(0).ToString) Then
                dblReturn = CDbl(objReader(0).ToString)
            End If
        End If
        objReader.Close()
        Return dblReturn
        Exit Function
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Drug Unit Price Fetch"
        gwt_comm.ShowErrorMessage()
    End Function

End Class
