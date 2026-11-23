Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmSalesSerialNumbers

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
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

    Private Sub LoadSerials()
        On Error GoTo RaiseErr
        dGrid.Rows.Clear()
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT SerialNumber FROM SerialNumbers " _
            & "WHERE ItemCode = '" & strPublicItemCode & "' ORDER BY SerialNumber", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows.Add(1)
                dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader(0).ToString
            End If
        End While
        objReader.Close()
        AlternateColors()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Serial Numbers Loa"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim strSerialNo As String = Nothing
        arrSelectedExitPassSerialNumbers = New ArrayList
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If dGrid.Rows(i).Cells(0).Value = True Then
                If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "")) Then
                    strSerialNo = Convert.ToString(dGrid.Rows(i).Cells(1).Value)
                    intTotalSerialNumbersSelected = 1
                    arrSelectedExitPassSerialNumbers.Add(strSerialNo)
                End If
            End If
        Next
        strSerialNumberForTransfer = strSerialNo
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Serial Numbers Selection"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub dGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dGrid.MouseUp
        'Get the current cell
        On Error GoTo RaiseErr

        If dGrid.CurrentCell.ColumnIndex = 1 Then Exit Sub

        Dim cell As DataGridViewCheckBoxCell = Me.dGrid.CurrentCell
        Dim intRowIndex As Integer = cell.RowIndex

        If boolMultiSelect = True Then
            Me.dGrid.EndEdit()
        Else

            'Get the value of the current cell
            Dim checked As Boolean = cell.GetEditedFormattedValue(cell.RowIndex, DataGridViewDataErrorContexts.Parsing)
            'Change the other cell to the opposite value
            If checked = True Then
                For n As Integer = 0 To dGrid.RowCount - 1
                    If n <> intRowIndex Then
                        dGrid.Rows(n).Cells(0).Value = False
                    End If
                Next
            End If

        End If
        Me.dGrid.EndEdit()
        Exit Sub
RaiseErr:
        Cursor = Cursors.Default
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Sales Serial Number Selection"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub frmSalesSerialNumbers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSerials()
        If boolMultiSelect = True Then
            dGrid.MultiSelect = True
        Else
            dGrid.MultiSelect = False
        End If
        If dGrid.Rows.Count > 0 Then lblCount.Text = CStr(dGrid.Rows.Count)
    End Sub

End Class