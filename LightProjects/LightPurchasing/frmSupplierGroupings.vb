Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSupplierGroupings

    Private Sub frmSupplierGroupings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dGrid.Rows.Add(150)
        AlternateColors()
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Grouping FROM SupplierGroups ORDER BY Grouping", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim p As Integer = 0
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows(p).Cells(0).Value = objReader(0).ToString
                p = p + 1
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On supplier groupings load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub SaveGroups()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SupplierGroups", cnn)
        objCommand.ExecuteNonQuery()
        Dim p As Integer = 0
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                Dim strGrouping As String = Convert.ToString(dGrid.Rows(i).Cells(0).Value)
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SupplierGroups (Grouping) VALUES ('" & strGrouping & "')", cnn)
                objCommand.ExecuteNonQuery()
                p = p + 1
            End If
        Next
        If p > 0 Then
            MessageBox.Show("Supplier groupings saved successfully", "Groupings Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On supplier groupings save"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        SaveGroups()
        Me.Close()
    End Sub

    Private Sub dGrid_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dGrid.RowsRemoved
        Dim iBal As Integer = 150 - dGrid.Rows.Count
        dGrid.Rows.Add(iBal)
        AlternateColors()
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

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class
