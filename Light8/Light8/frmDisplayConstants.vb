Imports System.IO
Imports System.Text
Imports ComponentFactory.Krypton.Toolkit
Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmDisplayConstants

    Private Sub frmDisplayConstants_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT ConstantNo, Description " _
            & "FROM SystemConstants ORDER BY ConstantNo", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dGrid.Rows.Clear()
        While objReader.Read
            dGrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dGrid.Rows(dGrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
        End While
        objreader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " error number " & Err.Number & vbCrLf & "Payroll Constants Load Error"
        gwt_comm.ShowErrorMessage()
    End Sub

    Private Sub GetSelectedItem()
        If dGrid.Rows.Count > 0 Then
            strSelectedCode = dGrid.CurrentRow.Cells(0).Value.ToString
            strSelectedCodeDescription = dGrid.CurrentRow.Cells(1).Value.ToString
        End If
    End Sub

    Private Sub dGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dGrid.DoubleClick
        GetSelectedItem()
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        GetSelectedItem()
        Me.Close()
    End Sub

    Private Sub frmDisplayConstants_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.Width = 402 : Me.Height = 474
    End Sub
End Class
