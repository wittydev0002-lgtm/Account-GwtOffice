Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmRepeatDrugStatus

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        boolAbort = True
        Me.Close()
    End Sub

    Private Sub frmRepeatDrugStatus_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        With dgrid
            .Rows.Add(UCase("YES"))
            .Rows.Add(UCase("NO"))
        End With
        dgrid.Focus()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        SelectItem()
    End Sub

    Private Sub SelectItem()
        strRepeatDrug = dgrid.CurrentRow.Cells(0).Value.ToString
        boolAbort = False
        Me.Close()
    End Sub

    Private Sub dgrid_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgrid.CellContentClick
        SelectItem()
    End Sub

    Private Sub dgrid_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgrid.KeyDown
        If e.KeyValue = Keys.Enter Then
            e.SuppressKeyPress = True
            SelectItem()
        End If
    End Sub

End Class
