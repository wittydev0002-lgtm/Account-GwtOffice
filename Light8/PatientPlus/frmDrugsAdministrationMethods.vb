Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDrugsAdministrationMethods

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AddMethod()
    End Sub

    Private Sub AddMethod()
        If String.IsNullOrEmpty(txtMethod.Text) Then
            MessageBox.Show("Please enter a method for medication taking", "Invalid Method", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtMethod.Select()
            Exit Sub
        Else
            dGrid.Rows.Add(txtMethod.Text)
            txtMethod.Clear()
            txtMethod.Select()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr

        Dim strSql As String = "DELETE FROM OchmasSystemMedicinesAdminMethods"
        Dim objCommand As New Data.OleDb.OleDbCommand(strSql, cnn)
        objCommand.ExecuteNonQuery()

        For p As Integer = 0 To dGrid.RowCount - 1
            Dim strMethod As String = Nothing
            If Not Object.Equals(dGrid.Rows(p).Cells(0).Value, Nothing) Then
                If Not String.IsNullOrEmpty(dGrid.Rows(p).Cells(0).Value.ToString()) Then
                    strMethod = dGrid.Rows(p).Cells(0).Value.ToString
                End If
            End If
            strSql = "INSERT INTO OchmasSystemMedicinesAdminMethods (Method) VALUES ('" & strMethod & "')"
            objCommand = New Data.OleDb.OleDbCommand(strSql, cnn)
            objCommand.ExecuteNonQuery()
        Next

        MessageBox.Show("Medicines administration methods have been set successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        boolAbort = False
        Me.Close()

        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " Error Number " & Err.Number & vbCrLf & " On medicines intake methods setup"
        ShowErrorMessage()
    End Sub

    Private Sub txtMethod_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMethod.KeyDown
        If e.KeyValue = Keys.Enter Then
            AddMethod()
        End If
    End Sub

End Class