Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmQuantitySplit

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If txtPackSize.Text.Length <= 0 Then
            MessageBox.Show("Please Enter the pack Size", "Missing Field Pack size", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPackSize.Focus()
            Exit Sub

        End If
        If txtQty.Text.Length <= 0 Then
            MessageBox.Show("Please Enter the Quantity", "Missing Field Quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtQty.Focus()
            Exit Sub

        End If
        With dgrid
            'add 1 row to the datagrid
            .Rows.Add(1)

            Dim x As String = ddItemColor.SelectedColor.ToString
            Dim strActualColor As String = Mid(x, 8, x.Length - 8)
            Dim strIdentifier As String = Mid(strActualColor, 1, 2)
            Dim strRbg As String = Nothing
            Dim strKnownColor As String = strActualColor
            If UCase(strIdentifier) = "A=" Then
                'We know that it has returned an rbg
                Dim strBuffer() As String = Split(strActualColor, ", ")
                strRbg = Mid(strBuffer(0), 3, strBuffer(0).Length - 2) & ", " & _
                    Mid(strBuffer(1), 3, strBuffer(1).Length - 2) & ", " & _
                    Mid(strBuffer(2), 3, strBuffer(2).Length - 2) & ", " & _
                    Mid(strBuffer(3), 3, strBuffer(3).Length - 2)
                strKnownColor = gwt_comm.GetDefinedColor(CInt(Mid(strBuffer(0), 3, strBuffer(0).Length - 2)), _
                    CInt(Mid(strBuffer(1), 3, strBuffer(1).Length - 2)), CInt(Mid(strBuffer(2), 3, strBuffer(2).Length - 2)), _
                    CInt(Mid(strBuffer(3), 3, strBuffer(3).Length - 2)))
            End If
            .Rows(.Rows.Count - 1).Cells(0).Value = txtPackSize.Text.ToString
            .Rows(.Rows.Count - 1).Cells(1).Value = strActualColor
            .Rows(.Rows.Count - 1).Cells(2).Value = txtQty.Text.ToString
        End With
        ComputeQuantity()

    End Sub

    Public Function GetKnownColor(ByVal iARGBValue As Integer, ByRef strKnownColor As String) As Boolean
        Dim someColor As Color

        Dim aListofKnownColors As Array = [Enum].GetValues(GetType(KnownColor))
        For Each eKnownColor As KnownColor In aListofKnownColors
            someColor = Color.FromKnownColor(eKnownColor)
            If iARGBValue = someColor.ToArgb() AndAlso Not someColor.IsSystemColor Then
                strKnownColor = someColor.Name
                Return True
            End If
        Next
        strKnownColor = ""
        Return False
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        On Error GoTo RaiseErr
        If CInt(lblInventoryQty.Text) <> CInt(lblSplitQuantity.Text) Then
            If MessageBox.Show("The split quantity is not equal to the inventory quantity. Do you want to proceed?", _
                "Quantity Mismatch", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then

                Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM InventoryQuantitySplit WHERE " _
                    & "ItemCode = '" & strSelectedInventoryItemCode & "'", cnn)
                objCommand.ExecuteNonQuery()

                For n As Integer = 0 To dgrid.Rows.Count - 1
                    Dim strSize As String = Nothing
                    Dim strColor As String = Nothing
                    Dim intQty As Integer = 0
                    If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(0).Value), "")) Then
                        strSize = dgrid.Rows(n).Cells(0).Value.ToString
                        If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(1).Value), "")) Then
                            strColor = dgrid.Rows(n).Cells(1).Value.ToString
                        End If
                        If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(2).Value), "")) Then
                            If IsNumeric(dgrid.Rows(n).Cells(2).Value.ToString) Then
                                intQty = CInt(dgrid.Rows(n).Cells(2).Value.ToString)
                            End If
                        End If
                        Dim strSql As String = "INSERT INTO InventoryQuantitySplit ([ItemCode], [ItemSize], [ItemColor], [Quantity]) " _
                            & "VALUES ('" & strSelectedInventoryItemCode & "', '" & strSize & "', '" & strColor & "', " & intQty & ")"
                        objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
                        objCommand.ExecuteNonQuery()
                    End If
                Next
                intSelectedInventoryReturnQuantity = CInt(lblSplitQuantity.Text)
                MessageBox.Show("Quantity split details saved successfully", "Inventory Quantity Split", MessageBoxButtons.OK, MessageBoxIcon.Information)
                boolAbort = False
                Me.Close()
            End If
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On inventory quantity split"
        ShowErrorMessage()
    End Sub

    Private Sub ComputeQuantity()
        Dim intCount As Integer = 0
        For n As Integer = 0 To dgrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dgrid.Rows(n).Cells(2).Value), "")) Then
                If IsNumeric(dgrid.Rows(n).Cells(2).Value.ToString) Then
                    intCount = intCount + CInt(dgrid.Rows(n).Cells(2).Value.ToString)
                End If
            End If
        Next
        lblSplitQuantity.Text = intCount
    End Sub

    Private Sub dgrid_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgrid.RowsRemoved
        ComputeQuantity()
    End Sub

    Private Sub frmQuantitySplit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblInventoryQty.Text = intSelectedInventoryQuantity
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim strSql As String = "SELECT [ItemSize], [ItemColor], [Quantity] FROM InventoryQuantitySplit " _
            & "WHERE [ItemCode] = '" & strSelectedInventoryItemCode & "'"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dgrid.Rows.Clear()
        While objReader.Read
            dgrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
            If Not IsDBNull(objReader(2).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(2).Value = objReader(2).ToString
        End While
        objReader.Close()
        Exit Sub
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On inventory quantity split"
        ShowErrorMessage()
    End Sub

End Class
