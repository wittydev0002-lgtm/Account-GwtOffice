Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmEmployeeFlagOptions

    Private Sub frmEmployeeFlagOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo RaiseErr
        Dim sqlCommand As New Data.OleDb.OleDbCommand("SELECT FlagName, " _
            & "FlagValue FROM SystemFlagValues WHERE FlagNo = " & intSelectedTransaction & "", cnn)
        Dim objReader As Data.OleDb.OleDbDataReader = sqlCommand.ExecuteReader
        dgrid.Rows.Clear()
        While objReader.Read
            dgrid.Rows.Add(1)
            If Not IsDBNull(objReader(0).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(0).Value = objReader(0).ToString
            If Not IsDBNull(objReader(1).ToString) Then dgrid.Rows(dgrid.Rows.Count - 1).Cells(1).Value = objReader(1).ToString
        End While
        objReader.Close()
        Exit Sub
RaiseErr:
        boolAbort = True
        Cursor = Cursors.Default
        strErrorMessages = Err.Description & " " & Err.Number & " on Work Structure Details Load"
        ShowErrorMessage()
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If dgrid.Rows.Count > 0 Then
            If Not (Object.Equals(Convert.ToString(dgrid.CurrentRow.Cells(1).Value), "")) Then
                strSelectedValue = Convert.ToString(dgrid.CurrentRow.Cells(1).Value)
            End If
            Me.Close()
        End If
    End Sub

    Private Sub dgrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrid.DoubleClick
        If dgrid.Rows.Count > 0 Then
            If Not (Object.Equals(Convert.ToString(dgrid.CurrentRow.Cells(1).Value), "")) Then
                strSelectedValue = Convert.ToString(dgrid.CurrentRow.Cells(1).Value)
            End If
            Me.Close()
        End If
    End Sub

End Class
