Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmOrderFromInventory

    Private Sub txtSearchString_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchString.TextChanged
        Dim i As Integer = 0
        With dGrid
            For i = 0 To .Rows.Count - 1
                Select Case UCase(cboSearchOptions.Text)
                    Case Is = UCase("Item Code")
                        If UCase(Mid(.Rows(i).Cells(1).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(1)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                    Case Is = UCase("Item Name")
                        If UCase(Mid(.Rows(i).Cells(2).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(2)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                    Case Else
                        'Use the name
                        If UCase(Mid(.Rows(i).Cells(2).Value, 1, Len(txtSearchString.Text))) = UCase(txtSearchString.Text) Then
                            .FirstDisplayedCell = .Rows(i).Cells(2)
                            .FirstDisplayedCell.Selected = True
                            Exit Sub
                        End If
                End Select
            Next
        End With
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT ItemCode, GroupName, " _
            & "CAST(CostPrice AS DECIMAL (30,2)) AS [Cost Price] FROM InventoryItems ORDER BY ItemCode, GroupName", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(False, objReader(0), objReader(1), objReader(2))
        End While
        objReader.Close()
        AlternateColors()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On inventory details load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmOrderFromInventory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        arrSelectedItems = New ArrayList
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If dGrid.Rows(i).Cells(0).Value = True Then
                arrSelectedItems.Add(dGrid.Rows(i).Cells(1).Value.ToString & "|" & dGrid.Rows(i).Cells(2).Value.ToString & "|" & dGrid.Rows(i).Cells(3).Value.ToString)
            End If
        Next
        Me.Close()
    End Sub

    Private Sub AlternateColors()
        For i As Integer = 0 To dGrid.Rows.Count - 1 Step 2
            For j As Integer = 0 To dGrid.Columns.Count - 1
                Dim foreColor As Color = Color.Black
                Dim backColor As Color = Color.WhiteSmoke
                dGrid.Rows(i).Cells(j).Style.BackColor = backColor
                dGrid.Rows(i).Cells(j).Style.ForeColor = foreColor
            Next j
        Next i
    End Sub

    Private Sub frmOrderFromInventory_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 595 : Me.Height = 375
    End Sub

End Class