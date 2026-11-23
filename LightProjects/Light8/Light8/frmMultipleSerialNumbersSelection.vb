Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Drawing

Public Class frmMultipleSerialNumbersSelection

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Populate the selected numbers to a public array
        arrSelectedSerialNumbers = New ArrayList
        If dGrid.Rows.Count > 0 Then
            ' If so, loop through all checked items and process options.
            For i As Integer = 0 To dGrid.Rows.Count - 1
                If dGrid.Rows(i).Cells(0).Value = True Then
                    arrSelectedSerialNumbers.Add(dGrid.Rows(i).Cells(1).Value.ToString)
                End If
            Next i
        End If
        Me.Close()
    End Sub

    Private Sub frmMultipleSerialNumbersSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load the particular item serial numbers
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SerialNumber FROM SerialNumbers " _
                    & "WHERE ItemCode = '" & strPublicItemCode & "'", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            dGrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader(0).ToString()
            End If
        End While
        objReader.Close()
        AlternateColors()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Form Data Load"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub AlternateColors()
        With dGrid
            For i As Integer = 0 To .Rows.Count - 1 Step 2
                For j As Integer = 0 To .Columns.Count - 1
                    Dim foreColor As Color = Color.Black
                    Dim backColor As Color = Color.WhiteSmoke
                    .Rows(i).Cells(j).Style.BackColor = backColor
                    .Rows(i).Cells(j).Style.ForeColor = foreColor
                Next j
            Next i
        End With
    End Sub

    Private Sub optSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSelectAll.CheckedChanged
        Dim i As Integer = 0
        For i = 0 To dGrid.Rows.Count - 1
            dGrid.Rows(i).Cells(0).Value = True
        Next
    End Sub

    Private Sub optClearAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optClearAll.CheckedChanged
        Dim i As Integer = 0
        For i = 0 To dGrid.Rows.Count - 1
            dGrid.Rows(i).Cells(0).Value = False
        Next
    End Sub

End Class