Public Class frmLaschCustomerPrintOptions

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub LoadProvinces()
        On Error GoTo RaiseErr
        Dim objCmmand As New Data.OleDb.OleDbCommand("SELECT Province FROM Provinces ORDER BY Province", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCmmand.ExecuteReader
        While objReader.Read
            If Not IsDBNull(objReader(0).ToString) Then
                dGrid.Rows.Add(False, objReader(0).ToString)
            End If
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On Provinces Load"
        ShowErrorMessage()
    End Sub

    Private Sub frmLaschCustomerPrintOptions_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadProvinces()
        optAll.Checked = True : optSelective.Checked = False
    End Sub

    Private Sub optAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optAll.CheckedChanged
        If optAll.Checked = True Then
            dGrid.Enabled = False
        Else
            dGrid.Enabled = True
        End If
    End Sub

    Private Sub optSelective_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSelective.CheckedChanged
        If optSelective.Checked = True Then
            dGrid.Enabled = True
        Else
            dGrid.Enabled = False
        End If
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        arrSelectedItems = New ArrayList
        If optAll.Checked = True Then
            For i As Integer = 0 To dGrid.Rows.Count - 1
                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                    arrSelectedItems.Add(dGrid.Rows(i).Cells(1).Value.ToString)
                End If
            Next
            boolAbort = False
            Me.Close()
        Else
            For i As Integer = 0 To dGrid.Rows.Count - 1
                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                    If dGrid.Rows(i).Cells(0).Value = True Then
                        arrSelectedItems.Add(dGrid.Rows(i).Cells(1).Value.ToString)
                    End If
                End If
            Next
            boolAbort = False
            Me.Close()
        End If
    End Sub

End Class
