Imports CommonLibrary.Commons

Public Class frmLegalPaymentInitiators

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If Not String.IsNullOrEmpty(txtInitiator.Text) Then
            dGrid.Rows.Add(txtInitiator.Text)
            txtInitiator.Clear()
            txtInitiator.Select()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not Object.Equals(dGrid.Rows(i).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(i).Cells(0).Value.ToString) Then
                    Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM LegalPaymentInitiators WHERE Initiator = '" & dGrid.Rows(i).Cells(0).Value.ToString & "'", cnn)
                    objCommand.ExecuteNonQuery()
                    objCommand = New Data.OleDb.OleDbCommand("INSERT INTO LegalPaymentInitiators (Initiator) VALUES ('" & dGrid.Rows(i).Cells(0).Value.ToString & "')", cnn)
                    objCommand.ExecuteNonQuery()
                End If
            End If
        Next
        MessageBox.Show("Legal Payment Initiators saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On legal payment initiators setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmLegalPaymentInitiators_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT Initiator FROM LegalPaymentInitiators ORDER BY Initiator", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(objReader(0))
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & vbCrLf & "On legal payment initiators setup"
        ShowErrorMessage()
    End Sub

    Private Sub frmLegalPaymentInitiators_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 360 : Me.Height = 425
    End Sub

End Class