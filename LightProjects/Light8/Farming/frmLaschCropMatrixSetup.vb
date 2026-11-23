Public Class frmLaschCropMatrixSetup

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnAddAsNew_Click(sender As System.Object, e As System.EventArgs) Handles btnAddAsNew.Click
        On Error GoTo RaiseErr
        boolAbort = False
        If String.IsNullOrEmpty(txtCropDescription.Text) Then
            MessageBox.Show("Please enter a valid name for the crop", "Invalid Date Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCropDescription.Focus()
            Exit Sub
        End If
        Dim strSimilar As String = Nothing
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                If UCase(dGrid.Rows(i).Cells(1).Value.ToString) = UCase(txtCropDescription.Text) Then
                    strSimilar = txtCropDescription.Text
                    Exit For
                End If
            End If
        Next

        If String.IsNullOrEmpty(strSimilar) Then
            Dim objCommand As New Data.OleDb.OleDbCommand("INSERT INTO LaschApprovedCrops (Crop) VALUES " _
                & "('" & txtCropDescription.Text & "')", cnn)
            objCommand.ExecuteNonQuery()
            LoadData()
            txtCropDescription.Clear()
            txtCropDescription.Focus()
        Else
            MessageBox.Show("Crop name already exists. Entry will be ignored", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On crop information load"
        ShowErrorMessage()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        boolAbort = False
        'Reload the details to the grid
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Crop FROM LaschApprovedCrops ORDER BY Crop", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader()
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(False, objReader(0))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On crop information load"
        ShowErrorMessage()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As System.EventArgs) Handles btnSelect.Click
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If dGrid.Rows(i).Cells(0).Value = True Then
                If Not Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(1).Value), "") Then
                    strSelectedDescription = strSelectedDescription & dGrid.Rows(i).Cells(1).Value.ToString & ";"
                End If
            End If
        Next
        If Not String.IsNullOrEmpty(strSelectedDescription) Then
            strSelectedDescription = Mid(strSelectedDescription, 1, (strSelectedDescription.Length - 1))
        End If
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub txtCropDescription_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCropDescription.KeyPress
        If e.KeyChar = ";" Then e.Handled = True
    End Sub

    Private Sub frmLaschCropMatrix_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        LoadData()
    End Sub

End Class
