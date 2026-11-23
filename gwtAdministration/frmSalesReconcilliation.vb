Imports CommonLibrary.Commons
Imports CommonLibrary.Commons.CommonFunctions

Public Class frmSalesReconcilliation

    Private Sub KryptonButton1_Click(sender As System.Object, e As System.EventArgs) Handles KryptonButton1.Click
        Me.Close()
    End Sub

    Private Sub frmSalesReconcilliation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        With dGrid
            .Rows.Clear()
            .Rows.Add("Total Sales", arrSelectedItems.Item(0))
            .Rows.Add("Less :")
            .Rows.Add("Transfers", arrSelectedItems.Item(1))
            .Rows.Add("Swipes", arrSelectedItems.Item(2))
            .Rows.Add("EcoCash", arrSelectedItems.Item(3))
            .Rows.Add("")
            .Rows.Add("Deemed Cash Balance", arrSelectedItems.Item(4))
            .Rows.Add("Less Expenses", arrSelectedItems.Item(5))
            .Rows.Add("Deemed Cash On Hand", arrSelectedItems.Item(6))
        End With
    End Sub

End Class
