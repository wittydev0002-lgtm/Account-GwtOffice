Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSalesAlertTimes

    Dim boolModified As Boolean = False

    Private Sub frmSalesAlertTimes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dGrid.Rows.Add(12)
        LoadData()
    End Sub

    Private Sub LoadData()
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("SELECT AlertTimes FROM SalesAlertTimes", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = objCommand.ExecuteReader
        Dim i As Integer = 0
        While objReader.Read
            dGrid.Rows(i).Cells(0).Value = objReader(0)
            i = i + 1
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On sales alerts data load"
        ShowErrorMessage()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        On Error GoTo RaiseErr
        Dim objCommand As New Data.OleDb.OleDbCommand("DELETE FROM SalesAlertTimes", cnn)
        objCommand.ExecuteNonQuery()
        For i As Integer = 0 To dGrid.Rows.Count - 1
            If Not (Object.Equals(Convert.ToString(dGrid.Rows(i).Cells(0).Value), "")) Then
                objCommand = New Data.OleDb.OleDbCommand("INSERT INTO SalesAlertTimes (AlertTimes) " _
                    & "VALUES ('" & dGrid.Rows(i).Cells(0).Value.ToString & "')", cnn)
                objCommand.ExecuteNonQuery()
            End If
        Next
        gwt_comm.SalesAlertTimes()
        MessageBox.Show("Sales alert time saved successfully", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "On sales alerts setup"
        ShowErrorMessage()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub dGrid_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dGrid.RowsRemoved
        Dim i As Integer = 12 - dGrid.Rows.Count
        If i > 0 Then dGrid.Rows.Add(i)
    End Sub

    Private Sub frmSalesAlertTimes_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 285 : Me.Height = 395
    End Sub

End Class
